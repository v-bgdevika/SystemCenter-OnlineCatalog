// ----------------------------------------------------------------------------
// <copyright file="CommonChannel.cs" company="Microsoft">
//  Copyright (c) Microsoft Corporation 2008
// </copyright>
// 
// <summary>
// Class to implement common test methods for the channel tests.
// </summary>
// 
// <note>
// See the end of this source file for a detailed history
// </note>
// 
// <history>
//		[kellymor]  19-AUG-08   Created.
//      [kellymor]  20-AUG-08   Completed implementation of ProcessMessageText
//                              and MapAlertParameterToMenuText.
//      [kellymor]  21-AUG-08   Added GenerateRandomString method.
//                              Added WaitForChannelSave method.
//                              Added StartWizard method.
//                              Added SetNameAndDescription method.
//                              Added DisplayProperties method.
//                              Added DeleteChannel method.
//      [kellymor]  25-AUG-08   Fixed issue setting default channel name
//                              Moved to UI.Core.Console.Administration.Notifications.Channels
//      [kellymor]  26-AUG-08   Added overload for SetNameAndDescription that
//                              takes a third argument for description text.
//                              Created core method to set email servers.
//                              Added Encoding class constants.
//      [kellymor]  04-SEP-08   Updated WaitForChannelSave.
//                              Added constants for channel save max wait
//                              attempts and delay interval.
//      [KellyMor]  08-SEP-08   StyleCop fixes.
//      [KellyMor]  09-SEP-08   Renamed constants for name and description max
//                              length to remove SMTP reference.
//                              Moved wait for channel save constants into the
//                              Constants class.
//      [KellyMor]  10-SEP-08   Moved common resource strings from Views class
//                              to this class.
//                              Updated DeleteChannel to confirm the deletion.
//                              Added an overload to DeleteChannel to take a
//                              flag indicating if the delete operation should
//                              be committed.
//                              Added resource string for the Confirm Channel
//                              Delete dialog title.
//                              Moved alert parameters menu items from email,
//                              IM, SMS and command channel dialogs to here.
//      [KellyMor]  11-SEP-08   Added constants for short name and description
//                              lengths.
//                              Added check for all whitespace channel name for
//                              generating a minimum length channel name.
//                              Added check for invalid characters in mail
//                              server name and to check for a leading numeric.
//                              Increased number of attempts for channel save
//                              from 30 to 90 for low memory machines.
//      [KellyMor]  23-SEP-08   Fixed issue returning alert last modified time
//                              for alert last modified by parameter.
//                              Fixed issue matching alert parameters due to
//                              trailing or leading whitespace characters.
//      [KellyMor]  27-SEP-08   Modified resource strings for channel context
//                              menus to use new resource identifier.
//                              Added new string properties for channel type
//                              combo box items.
//                              Added resource for diereisis (...).
//                              Modified channel context menu string properties
//                              to use new diereisis string property.
//      [KellyMor}  29-SEP-08   Removed hardcoded strings SetNameAndDescription
//                              Added new string properties for default command
//                              name and description.
//                              Modified SetNameAndDescription to use constants
//                              for generating short name and description.
//      [KellyMor]  04-OCT-08   Updated StartWizard, DisplayProperties, and
//                              DeleteSubscriber to use new Actions pane
//                              "Channel" group.
//      [KellyMor]  07-OCT-08   Updated navigation code to use correct timeout
//      [KellyMor]  09-OCT-08   Added private NavigateToView() method to add
//                              another layer of retry logic around the Core
//                              NavigationPane.SelectNode() method.  The new
//                              dynamic admin tree view updates/refreshes on
//                              every MP import, which happens every time a
//                              subscription is created, edited or deleted.
//      [KellyMor]  16-OCT-08   Modified StartWizard to use new tree view
//                              context menu for new channel...
//                              Modified resource string for view pane context
//                              menu
//      [KellyMor]  27-OCT-08   Fixed an issue with the tooltip blocking the
//                              context menu when an item's description is
//                              longer than the grid cell in DisplayProperties
//                              and DeleteChannel.
//      [KellyMor]  28-OCT-08   Added fix to default case for same context menu
//                              issue in DisplayProperties and DeleteChannel.
//      [a-joelj]   23-JAN-09   Added ExcludedCharacters support for the Generate
//                              RandomString method to exclude unsafe chars.
// </history>
// 
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;

    /// <summary>
    /// Class to implement the test methods for the  channel tests.
    /// </summary>
    public class CommonChannel
    {
        /// <summary>
        /// Method to start a channel wizard from the specified start point
        /// in the Administration space of the UI using the specified context
        /// menu item text.
        /// </summary>
        /// <param name="startPoint">
        /// The start point in the Administration UI.  Valid values are defined
        /// in the Constants.StartPoint class.
        /// </param>
        /// <param name="channelMenuItemText">
        /// The context menu item text.  The same text is used for action pane
        /// links.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if the start point passed
        /// is not among the defined types in the Constants.StartPoint class.
        /// </exception>
        public static void StartWizard(
            string startPoint,
            string channelMenuItemText)
        {
            // start the wizard from the specified start point
            switch (startPoint)
            {
                case Constants.StartPoint.AdminOverviewPageHyperLink:
                    {
                        try
                        {                        
                            #region Administration Overview Page Hyperlink

                        CommonChannel.NavigateToView(
                            NavigationPane.Strings.AdminTreeViewAdministrationRoot);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Looking for the hyperlink := '" +
                            Core.Console.Views.Views.Strings.RequiredEnableNotificationLinkLabel +
                            "' in the overview page...");

                        // locate the 'Required:  Enable Notification Channels' link
                        Maui.Core.WinControls.StaticControl requiredEnableNotificationsLink =
                            new Maui.Core.WinControls.StaticControl(
                                CoreManager.MomConsole.ViewPane.Extended.AccessibleObject.Window,
                                Core.Console.Views.Views.Strings.RequiredEnableNotificationLinkLabel);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Found link.  Clicking link...");

                        // click the link
                        requiredEnableNotificationsLink.Click();

                        CoreManager.MomConsole.ExecuteContextMenu(channelMenuItemText, false);

                        #endregion Administration Overview Page Hyperlink
                        }
                        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                        {
                            StartWizard(Constants.StartPoint.ViewContextMenu, channelMenuItemText);
                        }
                    }

                    break;
                case Constants.StartPoint.ViewContextMenu:
                    {
                        #region View Pane Context Menu

                        CommonChannel.NavigateToView(
                            NavigationPane.Strings.AdminTreeViewChannelsView);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Selecting the view pane grid...");

                        // select the view pane
                        CoreManager.MomConsole.ViewPane.Grid.Click();

                        string menuPath = CommonChannel.Strings.CreateNewChannelContextMenu +
                                          Core.Common.Constants.PathDelimiter +
                                          channelMenuItemText;
                        Core.Common.Utilities.LogMessage("StartWizard:: menu path:" + menuPath);
                        CoreManager.MomConsole.ExecuteContextMenu(menuPath, true);

                        #endregion View Pane Context Menu
                    }

                    break;
                case Constants.StartPoint.TreeViewContextMenu:
                    {
                        #region Tree View Context Menu

                        // navigate to the 'Channels' view
                        Maui.Core.WinControls.TreeNode channelsViewNode =
                            CommonChannel.NavigateToView(
                                NavigationPane.Strings.AdminTreeViewChannelsView);

                        // execute context menu
                        string menuPath = NavigationPane.Strings.ContextMenuNewChannel +
                                          Core.Common.Constants.PathDelimiter +
                                          channelMenuItemText;
                        Core.Common.Utilities.LogMessage("StartWizard:: menu path:"+ menuPath);
                        CoreManager.MomConsole.ExecuteContextMenu(menuPath, true);

                        #endregion Tree View Context Menu
                    }

                    break;
                case Constants.StartPoint.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Links

                        CommonChannel.NavigateToView(
                            NavigationPane.Strings.AdminTreeViewChannelsView);

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                CommonChannel.Strings.CreateNewChannelContextMenu);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Using link text := '" +
                            actionsPaneLinkText +
                            "'");

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Clicking actions pane link...");

                        string pathToView = 
                            Core.Console.NavigationPane.Strings.AdminTreeViewAdministrationRoot +
                            Core.Common.Constants.PathDelimiter +
                            Core.Console.NavigationPane.Strings.AdminTreeViewNotifications +
                            Core.Common.Constants.PathDelimiter +
                            NavigationPane.Strings.AdminTreeViewChannelsView;

                        CoreManager.MomConsole.ActionsPane.ClickLink(
                            NavigationPane.WunderBarButton.Administration,
                            pathToView,
                            Core.Console.ActionsPane.Strings.ActionsPaneChannel,
                            actionsPaneLinkText);

                        CoreManager.MomConsole.ExecuteContextMenu(channelMenuItemText, false);

                        #endregion
                    }

                    break;
                default:
                    {
                        throw new System.ArgumentOutOfRangeException(
                            "Unknown or undefined start point := '" +
                            startPoint +
                            "'");
                    }
            }
        }

        /// <summary>
        /// Method to set the channel name and description text.  The method
        /// takes a reference to a NameAndDescriptionWindow and the specified
        /// text for the name and description.
        /// </summary>
        /// <param name="channelNameWindowTitle">
        /// The Mom.Test.UI.Core.Console.Administration.Notifications.Channels.Wizards.NameAndDescriptionWindow
        /// reference.
        /// </param>
        /// <param name="channelName">
        /// The text for the name and description.  The channel name can also be
        /// one of the constants defined in Constants.ChannelNameType.
        /// This will cause the method to generate a name and description based
        /// on the type specified.
        /// </param>
        public static void SetNameAndDescription(
            string channelNameWindowTitle,
            string channelName)
        {
            Core.Common.Utilities.LogMessage(
                "SetNameAndDescription::Setting channel name...");

            // set the name and description
            SetNameAndDescription(
                channelNameWindowTitle,
                channelName,
                String.Empty);
        }

        /// <summary>
        /// Method to set the channel name and description text.  The method
        /// takes a reference to a NameAndDescriptionWindow and the specified
        /// text for the name and description.
        /// </summary>
        /// <param name="channelNameWindowTitle">
        /// The Mom.Test.UI.Core.Console.Administration.Notifications.Channels.Wizards.NameAndDescriptionWindow
        /// reference.
        /// </param>
        /// <param name="channelName">
        /// The text for the name.  The channel name can also be
        /// one of the constants defined in Constants.ChannelNameType.
        /// This will cause the method to generate a name and description based
        /// on the type specified.
        /// </param>
        /// <param name="channelDescription">
        /// The text for the description.
        /// </param>
        public static void SetNameAndDescription(
            string channelNameWindowTitle,
            string channelName,
            string channelDescription)
        {
            // reference to the name and description wizard window
            Wizards.NameAndDescriptionWindow channelNameWindow =
                new Wizards.NameAndDescriptionWindow(
                    CoreManager.MomConsole,
                    channelNameWindowTitle);

            #region Generate the Channel Name and Description

            // generate the channel name
            string generatedChannelName = null;
            string generatedChannelDescription = null;

            switch (channelName)
            {
                case Constants.ChannelNameType.Default:
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetChannelName::Using default name...");

                        #region Get Default Channel Name and Description

                        if (channelNameWindowTitle.Equals(Wizards.NameAndDescriptionWindow.Strings.EmailChannelWizardTitle))
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetChannelName::Using default email channel name...");

                            // use default email name and description
                            generatedChannelName =
                                Wizards.NameAndDescriptionWindow.Strings.DefaultEmailChannelName;
                            generatedChannelDescription =
                                Wizards.NameAndDescriptionWindow.Strings.DefaultEmailChannelDescription;
                        }
                        else if (channelNameWindowTitle.Equals(Wizards.NameAndDescriptionWindow.Strings.InstantMessageChannelWizardTitle))
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetChannelName::Using default instant message channel name...");

                            // use default instant message name and description
                            generatedChannelName =
                                Wizards.NameAndDescriptionWindow.Strings.DefaultInstantMessageChannelName;
                            generatedChannelDescription =
                                Wizards.NameAndDescriptionWindow.Strings.DefaultInstantMessageChannelDescription;
                        }
                        else if (channelNameWindowTitle.Equals(Wizards.NameAndDescriptionWindow.Strings.SmsChannelWizardTitle))
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetChannelName::Using default short message channel name...");

                            // use default short message name and description
                            generatedChannelName =
                                Wizards.NameAndDescriptionWindow.Strings.DefaultShortMessageChannelName;
                            generatedChannelDescription =
                                Wizards.NameAndDescriptionWindow.Strings.DefaultShortMessageChannelDescription;
                        }
                        else if (channelNameWindowTitle.Equals(Wizards.NameAndDescriptionWindow.Strings.CommandChannelWizardTitle))
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetChannelName::Using default command channel name...");

                            // use default command name and description
                            generatedChannelName =
                                CommonChannel.Strings.DefaultCommandChannelName;
                            generatedChannelDescription =
                                CommonChannel.Strings.DefaultCommandChannelDescription;
                        }
                        else
                        {
                            throw new Maui.GlobalExceptions.MauiException(
                                "Unknown or unrecognized channel wizard window title := '" +
                                channelNameWindowTitle +
                                "'");
                        }

                        #endregion Get Default Channel Name and Description
                    }

                    break;
                case Constants.ChannelNameType.RandomShort:
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetChannelName::Using Random Short name...");

                        // generate a short random name and description
                        generatedChannelName =
                            CommonChannel.GenerateRandomString(
                                CommonChannel.Constants.NameShortLength);
                        generatedChannelDescription =
                            CommonChannel.GenerateRandomString(
                                CommonChannel.Constants.DescriptionShortLength);
                    }

                    break;
                case Constants.ChannelNameType.RandomLong:
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetChannelName::Using Random Long name...");

                        // generate a long random name and description
                        generatedChannelName =
                            CommonChannel.GenerateRandomString(
                                Constants.NameMaxLength);
                        generatedChannelDescription =
                            CommonChannel.GenerateRandomString(
                                Constants.DescriptionMaxLength);
                    }

                    break;
                case Constants.ChannelNameType.MinLength:
                    {
                        #region Minimum Length Name and Description

                        Core.Common.Utilities.LogMessage(
                            "SetChannelName::Using Minimum Length name...");

                        // generate shortest, valid name and description
                        generatedChannelName =
                            CommonChannel.GenerateRandomString(1);

                        // verify that the name isn't composed of whitespace
                        if (generatedChannelName.Trim().Equals(String.Empty))
                        {
                            // regenerate the string
                            generatedChannelName =
                                CommonChannel.GenerateRandomString(1);

                            // check for whitespace again
                            if (generatedChannelName.Trim().Equals(String.Empty))
                            {
                                // use a simple character
                                generatedChannelName = "X";
                            }
                        }

                        generatedChannelDescription = String.Empty;

                        #endregion Minimum Length Name and Description
                    }

                    break;
                case Constants.ChannelNameType.MaxLength:
                    {
                        #region Max Length Name and Description

                        Core.Common.Utilities.LogMessage(
                            "SetChannelName::Using Maximum Length name...");

                        // generate a maximum length random name
                        generatedChannelName =
                            CommonChannel.GenerateRandomString(
                                Constants.NameMaxLength);

                        // if the generated string is not at the max length
                        if (Constants.NameMaxLength >
                            generatedChannelName.Length)
                        {
                            // pad the remaining length
                            generatedChannelName.PadRight(
                                Constants.NameMaxLength,
                                'X');
                        }

                        // generate a maximum length random description
                        generatedChannelDescription =
                            CommonChannel.GenerateRandomString(
                                Constants.DescriptionMaxLength);

                        // if the generated string is not at the max length
                        if (Constants.DescriptionMaxLength >
                            generatedChannelDescription.Length)
                        {
                            // pad the remaining length
                            generatedChannelDescription.PadRight(
                                Constants.DescriptionMaxLength,
                                'X');
                        }

                        #endregion Max Length Name and Description
                    }

                    break;
                default:
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetChannelName::Using Channel Parameters defined name...");

                        // use the name stored in the channel params instance
                        generatedChannelName =
                            channelName;
                        generatedChannelDescription =
                            channelDescription;
                    }

                    break;
            }

            Core.Common.Utilities.LogMessage(
                "SetChannelName::Generated name for channel := '" +
                    generatedChannelName +
                    "'");
            Core.Common.Utilities.LogMessage(
                "SetChannelName::Generated description for channel := '" +
                    generatedChannelDescription +
                    "'");

            #endregion Generate the Channel Name and Description

            Core.Common.Utilities.LogMessage(
                "SetNameAndDescription::Setting channel name and description...");

            // set the name and description
            channelNameWindow.NameText =
                generatedChannelName;

            channelNameWindow.DescriptionText =
                generatedChannelDescription;
        }

        /// <summary>
        /// Method to set the email servers in the Email Channel wizard
        /// Settings step.
        /// </summary>
        /// <param name="primaryEmailServer">
        /// The network name of the primary e-mail servers.
        /// </param>
        /// <param name="secondaryEmailServer">
        /// The network name of the secondary e-mail servers 
        /// (optional, can be null or emtpy string).
        /// </param>
        /// <param name="tertiaryEmailServer">
        /// The network name of the tertiary e-mail servers
        /// (optional, can be null or emtpy string).
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the primary email server
        /// parameter is null or empty string.
        /// </exception>
        public static void SetEmailServers(
            string primaryEmailServer,
            string secondaryEmailServer,
            string tertiaryEmailServer)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(primaryEmailServer))
            {
                throw new System.ArgumentNullException(
                    "Primary e-mail server parameter must not be null or empty string!");
            }

            // create a new notification server for the primary e-mail server
            NotificationServer primaryNotificationServer =
                new NotificationServer(
                    primaryEmailServer,
                    (int)NotificationServer.NetworkPorts.Smtp);

            // create a new list of email servers
            List<NotificationServer> emailNotificationServers =
                new List<NotificationServer>();

            #region Secondary and Tertiary Servers

            // add the primary server
            emailNotificationServers.Add(primaryNotificationServer);

            // check for secondary server
            if (false == String.IsNullOrEmpty(secondaryEmailServer))
            {
                // create a new notification server for the secondary server
                NotificationServer secondaryNotificationServer =
                    new NotificationServer(
                        secondaryEmailServer,
                        (int)NotificationServer.NetworkPorts.Smtp);

                // add it to the collection
                emailNotificationServers.Add(secondaryNotificationServer);
            }

            // check for tertiary (3rd) server
            if (false == String.IsNullOrEmpty(tertiaryEmailServer))
            {
                // create a new notification server for the secondary server
                NotificationServer tertiaryNotificationServer =
                    new NotificationServer(
                        tertiaryEmailServer,
                        (int)NotificationServer.NetworkPorts.Smtp);

                // add it to the collection
                emailNotificationServers.Add(tertiaryNotificationServer);
            }

            #endregion Secondary and Tertiary Servers

            // set the e-mail servers using the list of notification servers
            SetEmailServers(emailNotificationServers);
        }

        /// <summary>
        /// Method to set the email servers in the Email Channel wizard
        /// Settings step.
        /// </summary>
        /// <param name="emailChannel">
        /// An instance of a Channels.EmailChannelParams class.  This instance
        /// contains all the necessary information to create the channel. This
        /// method uses the list of notification servers specified by the
        /// channel.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the email channel parameter
        /// is null.
        /// </exception>
        public static void SetEmailServers(
            Channels.EmailChannelParams emailChannel)
        {
            // check for valid parameters
            if (null == emailChannel)
            {
                throw new System.ArgumentNullException(
                    "E-mail channel parameters instance must not be null!");
            }

            // set the e-mail servers using the list of notification servers
            SetEmailServers(emailChannel.NotificationServers);
        }

        /// <summary>
        /// Method to set the email servers in the Email Channel wizard
        /// Settings step.
        /// </summary>
        /// <param name="notificationServers">
        /// A generic List containing instances of NotificationServer class.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the list of notification
        /// servers is null.
        /// </exception>
        /// <exception cref="Maui.GlobalExceptions.MauiException">
        /// Throws Maui.GlobalExceptions.MauiException.
        /// </exception>
        public static void SetEmailServers(
            List<NotificationServer> notificationServers)
        {
            // check for valid parameters
            if (null == notificationServers || 0 == notificationServers.Count)
            {
                throw new System.ArgumentNullException(
                    "Notification servers parameter must not be null or emtpy!");
            }

            // find the "Settings" wizard window
            Channels.Wizards.EmailSettingsWindow channelSettingsWindow =
                new Channels.Wizards.EmailSettingsWindow(
                    CoreManager.MomConsole);            

            #region Set Email Servers

            Core.Common.Utilities.LogMessage(
                "SetEmailServers::Adding email servers...");

            // reference for the "Add SMTP Server" dialog
            Channels.Wizards.AddSmtpServerDialog addSmtpServerDialog;

            // add all email servers listed in the parameters instance
            foreach (NotificationServer mailServer in notificationServers)
            {
                Core.Common.Utilities.LogMessage(
                    "SetEmailServers::Clicking 'Add' button...");

                // click 'Add' button
                channelSettingsWindow.ClickAdd();

                // find the 'Add SMTP Server' window
                addSmtpServerDialog =
                    new Channels.Wizards.AddSmtpServerDialog(
                        CoreManager.MomConsole);

                #region Set Server FQDN

                // check for invalid characters in server name
                char[] excludedCharacters = 
                    Core.Common.Utilities.ExcludedCharacters();
                for (int index = 0; index < excludedCharacters.Length; index++)
                {
                    if (mailServer.FullyQualifiedName.Contains(excludedCharacters[index].ToString()))
                    {
                        throw new System.ArgumentException(
                            "Mail server name contains invalid characters, mail server := '" +
                            mailServer.FullyQualifiedName +
                            "', contains := '" +
                            excludedCharacters[index].ToString() +
                            "'");
                    }
                }

                // create a regex to check for name starting with a digit
                Regex startsWithDigit = new Regex(@"^\d");

                // check the mail server name for a digit at the start
                if (startsWithDigit.IsMatch(mailServer.FullyQualifiedName))
                {
                    throw new System.ArgumentException(
                        "Mail server name cannot start with a numeric, mail server := '" +
                        mailServer.FullyQualifiedName +
                        "'");
                }

                Core.Common.Utilities.LogMessage(
                    "SetEmailServers::Setting mail server FQDN := '" +
                    mailServer.FullyQualifiedName +
                    "'");

                // set the server name
                addSmtpServerDialog.SMTPServerFQDNText =
                    mailServer.FullyQualifiedName;

                // retry several times to wait OK button is enabled
                int retryMax = 10;
                int loopNum = 0;
                while (false == addSmtpServerDialog.Controls.OKButton.IsEnabled && loopNum++ < retryMax)
                {
                    Core.Common.Utilities.LogMessage(
                    "SetEmailServers:: Waiting for OK button enable, retry = " + 
                    loopNum.ToString());

                    Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);
                }

                // check the OK button is enabled
                if (false == addSmtpServerDialog.Controls.OKButton.IsEnabled)
                {
                    throw new MauiException(
                        "Failed to enable OK button after entering required parameter!");
                }

                #endregion

                #region Set Port Number

                Core.Common.Utilities.LogMessage(
                    "SetEmailServers::Setting port number := '" +
                    mailServer.PortNumber.ToString() +
                    "'");

                // set the port number
                addSmtpServerDialog.PortNumberText =
                    mailServer.PortNumber.ToString();

                #endregion Set Port Number

                #region Select Authentication Method

                // get the translated authentication method
                string authenticationMethodText = null;
                switch (mailServer.AuthenticationMethod)
                {
                    case Channels.NotificationServer.AuthenticationMethods.Anonymous:
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetEmailServers::Using 'Anonymous' authentication...'");
                            authenticationMethodText =
                                Channels.Wizards.AddSmtpServerDialog.Strings.Anonymous;
                        }

                        break;
                    case Channels.NotificationServer.AuthenticationMethods.WindowsIntegrated:
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetEmailServers::Using 'Window Integrated' authentication...'");
                            authenticationMethodText =
                                Channels.Wizards.AddSmtpServerDialog.Strings.WindowsIntegrated;
                        }

                        break;
                    default:
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetEmailServers::Using 'Anonymous' authentication...'");
                            authenticationMethodText =
                                Channels.Wizards.AddSmtpServerDialog.Strings.Anonymous;
                        }

                        break;
                }

                Core.Common.Utilities.LogMessage(
                    "SetEmailServers::Selecting authentication method with text := '" +
                    authenticationMethodText +
                    "'");

                // set the authentication method
                addSmtpServerDialog.Controls.AuthenticationMethodComboBox.ClickDropDown();
                addSmtpServerDialog.Controls.AuthenticationMethodComboBox.SelectByText(
                    authenticationMethodText);

                #endregion Select Authentication Method

                Core.Common.Utilities.LogMessage(
                    "SetEmailServers::Saving the mail server...");

                // commit the change
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addSmtpServerDialog.Controls.OKButton, Mom.Test.UI.Core.Common.Constants.OneMinute);
                addSmtpServerDialog.ClickOK();
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);
            }

            #endregion Set Email Servers

            // clear the references on success
            addSmtpServerDialog = null;
            channelSettingsWindow = null;
        }

        /// <summary>
        /// Method to process message text from the variation map.  The method
        /// takes a string representing the message text, translates any 
        /// environment variables (%environ_var%) to their respective values,
        /// converts any alert parameters (@alertparam@) into alert parameter 
        /// menu actions using the specified menu button, and inserts text 
        /// into the specified text field.
        /// </summary>
        /// <param name="messageText">
        /// Message text from the variation map.
        /// </param>
        /// <param name="messageTextBox">
        /// A Maui.Core.WinControls.TextBox control, typically a message
        /// subject or body field.
        /// </param>
        /// <param name="alertParametersButton">
        /// A Maui.Core.WinControls.Button control representing the alert 
        /// parameters menu button.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if any of the parameters are
        /// null or empty string.
        /// </exception>
        public static void ProcessMessageText(
            string messageText,
            Maui.Core.WinControls.TextBox messageTextBox,
            Maui.Core.WinControls.Button alertParametersButton)
        {
            #region Parameter Checks

            // check parameters
            if (String.IsNullOrEmpty(messageText))
            {
                throw new System.ArgumentNullException(
                    "Message text parameter cannot be null or empty string!");
            }

            if (null == messageTextBox || null == alertParametersButton)
            {
                throw new System.ArgumentNullException(
                    "TextBox or Button parameter cannot be null!");
            }

            #endregion Parameter Checks

            // check for custom separator character
            if (messageText.Contains(Constants.MessageTokenSeparator))
            {
                // split the string into tokens
                string[] messageTokens =
                    messageText.Split(
                        Constants.MessageTokenSeparator.ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);

                // iterate over tokens
                for (int index = 0; index < messageTokens.Length; index++)
                {
                    // if token is environment variable
                    if (messageTokens[index].Trim().StartsWith(Constants.EnvironmentVariableMarker) &&
                        messageTokens[index].Trim().EndsWith(Constants.EnvironmentVariableMarker))
                    {
                        #region Environment Variable

                        Core.Common.Utilities.LogMessage(
                            "ProcessMessageText::Environment variable := '" +
                            messageTokens[index] +
                            "'");

                        Core.Common.Utilities.LogMessage(
                            "ProcessMessageText::Munging environment variable...");

                        // remove environment variable markers
                        messageTokens[index] =
                            messageTokens[index].Replace(
                                Constants.EnvironmentVariableMarker,
                                String.Empty);

                        Core.Common.Utilities.LogMessage(
                            "ProcessMessageText::Getting value for environment variable := '" +
                            messageTokens[index].ToLowerInvariant() +
                            "'");

                        // replace with environment value
                        messageTokens[index] =
                            System.Environment.GetEnvironmentVariable(
                                messageTokens[index].Trim().ToLowerInvariant());

                        Core.Common.Utilities.LogMessage(
                            "ProcessMessageText::Enviroment value := '" +
                            messageTokens[index] +
                            "'");

                        // put insertion point to the end of the current text field
                        messageTextBox.SetSelection(
                            messageTextBox.Text.Length,
                            0);

                        // add the new text to the text field
                        messageTextBox.SendKeys(
                            messageTokens[index]);

                        #endregion Environment Variable
                    }
                    //// if token is alert parameter menu item
                    else if (messageTokens[index].Trim().StartsWith(Constants.AlertParameterMarker) &&
                        messageTokens[index].Trim().EndsWith(Constants.AlertParameterMarker))
                    {
                        #region Alert Parameter

                        Core.Common.Utilities.LogMessage(
                            "ProcessMessageText::Alert Parameter := '" +
                            messageTokens[index] +
                            "'");
                        
                        // map alert parameter to menu item text
                        string alertParameterMenuItemText =
                            CommonChannel.MapAlertParameterToMenuText(
                                messageTokens[index]);

                        Core.Common.Utilities.LogMessage(
                            "ProcessMessageText::Mapped to menu item := '" +
                            alertParameterMenuItemText +
                            "'");

                        // check for context menu item text
                        if (alertParameterMenuItemText.Equals(String.Empty))
                        {
                            #region Plain Text

                            // just use the string as is
                            Core.Common.Utilities.LogMessage(
                                "ProcessMessageText::Message Text := '" +
                                messageTokens[index] +
                                "'");

                            // put insertion point to the end of the current text field
                            messageTextBox.SetSelection(
                                messageTextBox.Text.Length,
                                0);

                            // add the new text to the text field
                            messageTextBox.SendKeys(
                                messageTokens[index]);

                            #endregion
                        }
                        else
                        {
                            #region Click Alert Parameter Menu

                            // put insertion point to the end of the current text field
                            messageTextBox.SetSelection(
                                messageTextBox.Text.Length,
                                0);

                            // select corresponding menu item
                            alertParametersButton.Click();
                            Maui.Core.Utilities.Sleeper.Delay(
                                Core.Common.Constants.OneSecond);

                            Core.Common.Utilities.LogMessage(
                                "ProcessMessageText::Clicking menu item := '" +
                                alertParameterMenuItemText +
                                "'");

                            CoreManager.MomConsole.ExecuteContextMenu(alertParameterMenuItemText, false);

                            #endregion Click Alert Parameter Menu
                        }

                        #endregion Alert Parameter
                    }
                    else
                    {
                        #region Plain Text

                        // else just use the string as is
                        Core.Common.Utilities.LogMessage(
                            "ProcessMessageText::Message Text := '" +
                            messageTokens[index] +
                            "'");

                        // put insertion point to the end of the current text field
                        messageTextBox.SetSelection(
                            messageTextBox.Text.Length,
                            0);

                        // add the new text to the text field
                        messageTextBox.SendKeys(
                            messageTokens[index]);

                        #endregion
                    }
                }
            }
            else
            {
                #region Plain Text

                if (messageText.Equals(CommonChannel.Constants.DefaultValue))
                {
                    // use the current message text as-is
                    Core.Common.Utilities.LogMessage(
                        "ProcessMessageText::Using default message text := '" +
                        messageTextBox.Text +
                        "'");
                }
                else
                {
                    // else just use the string as is
                    Core.Common.Utilities.LogMessage(
                        "ProcessMessageText::Message Text := '" +
                        messageText +
                        "'");

                    // put insertion point to the end of the current text field
                    messageTextBox.SetSelection(
                        messageTextBox.Text.Length,
                        0);

                    // add the new text to the text field
                    messageTextBox.SendKeys(
                        messageText);
                }

                #endregion
            }
        }

        /// <summary>
        /// Method to convert variation map alert parameters to their 
        /// corresponding context menu strings.  For the 'Alert Custom Fields'
        /// menu, the method returns both the 'Alert Custom Fields' string AND
        /// the specific custom field string for the sub-menu separated by the
        /// path delimiter character, defined in 
        /// Mom.Test.UI.Core.Common.Constants.PathDelimiter.
        /// If the method cannot match the specified alert parameter with a 
        /// known alert context menu, it will return an empty string.
        /// </summary>
        /// <param name="alertParameter">
        /// A string containing the alert parameter.
        /// </param>
        /// <returns>
        /// A translated context menu resource string or an empty string.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the alert parameter is null
        /// or empty string.
        /// </exception>
        public static string MapAlertParameterToMenuText(
            string alertParameter)
        {
            string alertParameterMenuItemText = string.Empty;

            if (String.IsNullOrEmpty(alertParameter))
            {
                throw new System.ArgumentNullException(
                    "Alert parameter text may not be null or emtpy string!");
            }

            if (alertParameter.Trim().StartsWith(Constants.AlertParameterMarker) &&
                alertParameter.Trim().EndsWith(Constants.AlertParameterMarker))
            {
                Core.Common.Utilities.LogMessage(
                    "MapAlertParameterToMenuText::Mapping parameter := '" +
                    alertParameter +
                    "'");

                // convert alert parameter to context menu text
                switch (alertParameter.Trim())
                {
                    case Constants.AlertParameters.AlertName:
                        {                            
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertName;
                        }

                        break;
                    case Constants.AlertParameters.AlertSource:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertSource;
                        }

                        break;
                    case Constants.AlertParameters.AlertDescription:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertDescription;
                        }

                        break;
                    case Constants.AlertParameters.AlertSeverity:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertSeverity;
                        }

                        break;
                    case Constants.AlertParameters.AlertPriority:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertPriority;
                        }

                        break;
                    case Constants.AlertParameters.AlertCategory:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCategory;
                        }

                        break;
                    case Constants.AlertParameters.AlertResolutionState:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertResolutionState;
                        }

                        break;
                    case Constants.AlertParameters.AlertOwner:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertOwner;
                        }

                        break;
                    case Constants.AlertParameters.AlertResolvedBy:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertResolvedBy;
                        }

                        break;
                    case Constants.AlertParameters.AlertTimeRaised:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertTimeRaised;
                        }

                        break;
                    case Constants.AlertParameters.AlertResolutionTime:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertTimeResolved;
                        }

                        break;
                    case Constants.AlertParameters.AlertLastModifiedTime:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertLastModifiedTime;
                        }

                        break;
                    case Constants.AlertParameters.AlertLastModifiedBy:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertLastModifiedBy;
                        }

                        break;
                    case Constants.AlertParameters.CustomField1:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField1;
                        }

                        break;
                    case Constants.AlertParameters.CustomField2:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField2;
                        }

                        break;
                    case Constants.AlertParameters.CustomField3:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField3;
                        }

                        break;
                    case Constants.AlertParameters.CustomField4:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField4;
                        }

                        break;
                    case Constants.AlertParameters.CustomField5:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField5;
                        }

                        break;
                    case Constants.AlertParameters.CustomField6:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField6;
                        }

                        break;
                    case Constants.AlertParameters.CustomField7:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField7;
                        }

                        break;
                    case Constants.AlertParameters.CustomField8:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField8;
                        }

                        break;
                    case Constants.AlertParameters.CustomField9:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField9;
                        }

                        break;
                    case Constants.AlertParameters.CustomField10:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.AlertCustomField +
                                Core.Common.Constants.PathDelimiter +
                                CommonChannel.Strings.CustomField10;
                        }

                        break;
                    case Constants.AlertParameters.WebConsoleLink:
                        {
                            alertParameterMenuItemText =
                                CommonChannel.Strings.WebConsoleLink;
                        }

                        break;
                    default:
                        {
                            // no corresponding menu
                            alertParameterMenuItemText = String.Empty;
                        }

                        break;
                }

                Core.Common.Utilities.LogMessage(
                    "MapAlertParameterToMenuText::Returning menu text := '" +
                    alertParameterMenuItemText +
                    "'");
            }

            return alertParameterMenuItemText;
        }

        /// <summary>
        /// Method to generate a random string with the specified range limit
        /// for min/max length
        /// </summary>
        /// <param name="range">
        /// Value indicating the range for min/max length
        /// </param>
        /// <returns>String</returns>
        public static string GenerateRandomString(int range)
        {
            return CommonChannel.GenerateRandomString(range, false);
        }

        /// <summary>
        /// Method to generate a random string with the specified range limit
        /// for min/max length
        /// </summary>
        /// <param name="range">
        /// Value indicating the range for min/max length
        /// </param>
        /// <param name="allowEmptyStrings">
        /// Flag indicating whether or not to allow the creation of empty
        /// strings as valid return values
        /// </param>
        /// <returns>String</returns>
        public static string GenerateRandomString(int range, bool allowEmptyStrings)
        {
            #region Create Random Generators

            // create a random string generator
            Core.Common.RandomStrings randomText =
                new Core.Common.RandomStrings(Core.Common.Utilities.Seed);

            // create a random number generator
            Random randomLengths = new Random(Core.Common.Utilities.Seed);
            int minLength = 0;
            int maxLength = 0;
            char[] excludedCharacters =
                Core.Common.Utilities.ExcludedCharacters();

            #endregion

            // set min/max length based on range value            
            maxLength = (int)(range * randomLengths.NextDouble());

            // allow zero-length strings?
            if (false == allowEmptyStrings)
            {
                // no, generate a random, minimum length and add 2
                minLength = ((int)(range * randomLengths.NextDouble())) + 5;

                // make sure the length is not zero
                if (0 >= minLength)
                {
                    // set the minimum length
                    minLength = 5;
                }
                if (0 >= maxLength)
                {
                    // set the maximum length
                    maxLength = 6;
                }
            }
            else
            {
                // zero-length strings are acceptable
                minLength = 0;
            }

            // if min is greater than max...
            if (minLength > maxLength)
            {
                // swap them
                int temp = minLength;
                minLength = maxLength;
                maxLength = temp;
            }

            string returnString = randomText.CreateRandomString(
                minLength,
                maxLength, excludedCharacters);

            // make sure the return string is not a single space.
            int maxTry = 0;
            while (returnString == " " && maxTry < 6)
            {
                returnString = randomText.CreateRandomString(
                minLength,
                maxLength, excludedCharacters);
                maxTry++;
            }


            // return the random string
            return returnString;
        }

        /// <summary>
        /// Method to wait for the wizard to finish saving the newly created
        /// channel.  The method looks for the Summary Wizard window specified
        /// by the caller and makes 30 attempts with a 2 second delay between
        /// attempts.
        /// </summary>
        /// <param name="summaryWizardWindowTitle">
        /// The title of the Summary Wizard window to look for.
        /// </param>
        /// <returns>
        /// True if channel save was successful otherwise returns false.
        /// </returns>
        public static bool WaitForChannelSave(
            string summaryWizardWindowTitle)
        {
            return CommonChannel.WaitForChannelSave(
                summaryWizardWindowTitle,
                Constants.MaxWaitAttemptsForChannelSave,
                Constants.DelayIntervalForChannelSave);
        }

        /// <summary>
        /// Method to wait for the wizard to finish saving the newly created
        /// channel.  The method looks for the Summary Wizard window specified
        /// by the caller and makes the specified number of attemtps with
        /// a short, specified delay.
        /// </summary>
        /// <param name="summaryWizardWindowTitle">
        /// The title of the Summary Wizard window to look for.
        /// </param>
        /// <param name="maxAttempts">
        /// The maximum number of attemtps to make.
        /// </param>
        /// <param name="delayIntervalMilliseconds">
        /// The delay between attemtps in milliseconds.
        /// </param>
        /// <returns>True if channel save succeeded, otherwise false.</returns>
        public static bool WaitForChannelSave(
            string summaryWizardWindowTitle,
            int maxAttempts,
            int delayIntervalMilliseconds)
        {
            bool returnValue = false;

            // get a reference to the summary wizard page
            Wizards.SummaryWindow summaryWizardWindow =
                new Wizards.SummaryWindow(
                    CoreManager.MomConsole,
                    summaryWizardWindowTitle);

            Core.Common.Utilities.LogMessage(
                "WaitForChannelSave::Waiting for wizard to finish saving channel...");

            /* Wait for the results to indicate that the wizard is done.
             * The code checks the results label text for success or 
             * failure messages.  If neither message is present, the code
             * delays for two seconds.
             */
            bool doneSavingChannel = false;
            for (int currentAttempt = 0;
                 (currentAttempt < maxAttempts) &&
                 (doneSavingChannel == false);
                 currentAttempt++)
            {
                Core.Common.Utilities.LogMessage(
                    "WaitForChannelSave::Checking the results label, attempt " +
                    (currentAttempt + 1) +
                    " of " +
                    maxAttempts);

                if (summaryWizardWindow.Controls.ResultsStaticControl.Text.Contains(
                    Wizards.SummaryWindow.Strings.ChannelSavedSuccessfully))
                {
                    Core.Common.Utilities.LogMessage(
                        "WaitForChannelSave::Channel saved successfully!");

                    doneSavingChannel = true;
                    returnValue = true;

                    break;
                }
                else
                {
                    // reformat channel saved error message
                    string channelSaveFailedText =
                        String.Format(
                            Wizards.SummaryWindow.Strings.ChannelSaveFailed,
                            String.Empty);

                    // check for failed save operation
                    if (summaryWizardWindow.Controls.ResultsStaticControl.Text.Contains(
                        channelSaveFailedText))
                    {
                        Core.Common.Utilities.LogMessage(
                            "WaitForChannelSave::Channel saved failed!");

                        doneSavingChannel = true;
                        returnValue = false;

                        break;
                    }
                }

                Core.Common.Utilities.LogMessage(
                    "WaitForChannelSave::Waiting for " +
                    (delayIntervalMilliseconds / Core.Common.Constants.OneSecond) +
                    " seconds...");

                // sleep for a two seconds
                Maui.Core.Utilities.Sleeper.Delay(
                    delayIntervalMilliseconds);
            }

            return returnValue;
        }

        /// <summary>
        /// Method to display the properties of an existing channel.  The 
        /// method takes the channel name and the display method as parameters.
        /// </summary>
        /// <param name="channelName">
        /// The name of the channel.
        /// </param>
        /// <param name="displayPropertiesMethod">
        /// The method used to display the channel properties.  These methods 
        /// are defined in DisplayPropertiesAction.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if either parameter is null or
        /// empty string.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if method fails to find the 
        /// specified channel in the view, assumes channel name was incorrect.
        /// </exception>
        public static void DisplayProperties(
            string channelName,
            string displayPropertiesMethod)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(channelName))
            {
                throw new System.ArgumentNullException(
                    "Channel name parameter cannot be null or empty string!");
            }

            if (String.IsNullOrEmpty(displayPropertiesMethod))
            {
                throw new System.ArgumentNullException(
                    "Display properties method parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Navigate to View and Select Item

            CommonChannel.NavigateToView(
                NavigationPane.Strings.AdminTreeViewChannelsView);

            int maxRetry = 10;
            Maui.Core.WinControls.DataGridViewRow channelRow = null;
            int loopNumber = 0;
            while (null == channelRow && loopNumber++ < maxRetry)
            {
                // refresh the view
                CoreManager.MomConsole.ViewPane.Grid.Click();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                // wait for the UI to settle
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

                Core.Common.Utilities.LogMessage(
                    "DisplayProperties::Selecting channel row with name := '" +
                    channelName +
                    "'" +
                    " Retry times := " +
                    loopNumber);

                // select the channel in the grid view
                channelRow = CoreManager.MomConsole.ViewPane.Grid.FindData(
                    channelName);

                Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);
            }            

            // check for valid row
            if (null == channelRow)
            {
                throw new System.ArgumentException(
                    "Failed to find the channel in the view with name := '" +
                    channelName +
                    "'");
            }

            Core.Common.Utilities.LogMessage(
                "DisplayProperties::Clicking the row...");

            // display the channel properties
            channelRow.AccessibleObject.Click();

            Core.Common.Utilities.LogMessage(
                "DisplayProperties::Waiting for the tooltip to disappear...");

            // wait for the tooltip to disappear
            CoreManager.MomConsole.Waiters.WaitForReady(Core.Common.Constants.DefaultContextMenuTimeout);

            #endregion Navigate to View and Select Item

            #region Display Properties (Wizard)

            switch (displayPropertiesMethod)
            {
                case Constants.DisplayPropertiesAction.ViewContextMenu:
                    {
                        #region Right-Click Item, Select Properties Context Menu

                        // put focus back on the row in case tooltip appeared
                        channelRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using right-click, context menu...");

                        // right-click item, properties menu
                        channelRow.AccessibleObject.Click(
                            MouseClickType.SingleClick,
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuProperties +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuProperties);

                        #endregion Right-Click Item, Select Properties Context Menu
                    }

                    break;
                case Constants.DisplayPropertiesAction.ViewDoubleClickItem:
                    {
                        #region Double-Click Item

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Double-clicking channel row...");

                        // double-click channel
                        channelRow.AccessibleObject.Click(
                            MouseClickType.DoubleClick);

                        #endregion
                    }

                    break;
                case Constants.DisplayPropertiesAction.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Properties Link

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                Core.Console.ViewPane.Strings.AdministrationContextMenuProperties);

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using link text := '" +
                            actionsPaneLinkText +
                            "'");

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Clicking actions pane link...");

                        string pathToView = 
                            Core.Console.NavigationPane.Strings.AdminTreeViewAdministrationRoot +
                            Core.Common.Constants.PathDelimiter +
                            Core.Console.NavigationPane.Strings.AdminTreeViewNotifications +
                            Core.Common.Constants.PathDelimiter +
                            NavigationPane.Strings.AdminTreeViewChannelsView;

                        CoreManager.MomConsole.ActionsPane.ClickLink(
                            NavigationPane.WunderBarButton.Administration,
                            pathToView,
                            Core.Console.ActionsPane.Strings.ActionsPaneChannel,
                            actionsPaneLinkText);

                        #endregion Actions Pane Properties Link
                    }

                    break;
                case Constants.DisplayPropertiesAction.ViewEnterKey:
                    {
                        #region Left-Click Item, Press ENTER Key

                        // select item, press ENTER key
                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using left-click, send Enter...");

                        // display context menu using keyboard
                        channelRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.Enter);

                        #endregion Left-Click Item, Press ENTER Key
                    }

                    break;
                case Constants.DisplayPropertiesAction.ViewShiftF10MenuHotKey:
                    {
                        #region Left-Click Item, SHIFT-F10, Select Properties Context Menu

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using left-click, SHIFT-F10...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        channelRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        channelRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.ShiftF10);

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuProperties +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuProperties);

                        #endregion Left-Click Item, SHIFT-F10, Select Properties Context Menu
                    }

                    break;
                default:
                    {
                        #region Right-Click Item, Select Properties Context Menu

                        // put focus back on the row in case tooltip appeared
                        channelRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using right-click, context menu...");

                        // right-click item, properties menu
                        channelRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuProperties +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuProperties);

                        #endregion Right-Click Item, Select Properties Context Menu
                    }

                    break;
            }

            #endregion Display Properties (Wizard)
        }

        /// <summary>
        /// Method to delete a channel from the UI and confirm the deletion.
        /// </summary>
        /// <param name="channelName">
        /// The name of the channel
        /// </param>
        /// <param name="deleteChannelMethod">
        /// The method used to delete the channel.  These are defined in the 
        /// Constants.DeleteChannelActions class.
        /// </param>
        public static void DeleteChannel(
            string channelName,
            string deleteChannelMethod)
        {
            CommonChannel.DeleteChannel(
                channelName,
                deleteChannelMethod,
                true);
        }

        /// <summary>
        /// Method to delete a channel from the UI and confirm or cancel the
        /// deletion based on the specified value for confirmDeletion.
        /// </summary>
        /// <param name="channelName">
        /// The name of the channel
        /// </param>
        /// <param name="deleteChannelMethod">
        /// The method used to delete the channel.  These are defined in the 
        /// Constants.DeleteChannelActions class.
        /// </param>
        /// <param name="confirmDeletion">
        /// Flag indicating if the deletion should be confirmed and committed.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if channel name or delete
        /// channel method parameters are null or empty string.
        /// </exception>
        /// /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if method fails to find the 
        /// specified channel in the view, assumes channel name was incorrect.
        /// </exception>
        public static void DeleteChannel(
            string channelName, 
            string deleteChannelMethod,
            bool confirmDeletion)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(channelName))
            {
                throw new System.ArgumentNullException(
                    "Channel name parameter cannot be null or empty string!");
            }

            if (String.IsNullOrEmpty(deleteChannelMethod))
            {
                throw new System.ArgumentNullException(
                    "Delete channel method parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Select Channel

            CommonChannel.NavigateToView(
                NavigationPane.Strings.AdminTreeViewChannelsView);

            int maxRetry = 20;
            Maui.Core.WinControls.DataGridViewRow channelRow = null;
            int loopNumber = 0;
            while (null == channelRow && loopNumber++ < maxRetry)
            {
                // refresh the view
                CoreManager.MomConsole.ViewPane.Grid.ScreenElement.BringUp();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                // wait for the UI to settle
                
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);
		CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();


                Core.Common.Utilities.LogMessage(
                    "DeleteChannel::Selecting channel row with name := '" +
                    channelName +
                    "'" +
                    " Retry times := " +
                    loopNumber);

                // select the channel in the grid view
                channelRow = CoreManager.MomConsole.ViewPane.Grid.FindData(
                    channelName);

                Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);
            }

            // check for valid row
            if (null == channelRow)
            {
                throw new System.ArgumentException(
                    "Failed to find the channel in the view with name := '" +
                    channelName +
                    "'");
            }

            Core.Common.Utilities.LogMessage(
                "DeleteChannel::Clicking the row...");

            // select the channel row
            channelRow.AccessibleObject.Click();

            Core.Common.Utilities.LogMessage(
                "DeleteChannel::Waiting for the tooltip to disappear...");

            // wait for the tooltip to disappear
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.DefaultContextMenuTimeout);

            #endregion Select Channel

            #region Choose Delete Method

            Core.Common.Utilities.LogMessage(
                "DeleteChannel::Using deletion method := '" +
                deleteChannelMethod +
                "'");

            switch (deleteChannelMethod)
            {
                case Constants.DeleteChannelAction.ViewContextMenu:
                    {
                        #region Right-Click Item, Select Delete Context Menu

                        // put focus back on the row in case tooltip appeared
                        channelRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Using right-click, context menu...");

                        // right-click item, properties menu
                        channelRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Right-Click Item, Select Delete Context Menu
                    }

                    break;
                case Constants.DeleteChannelAction.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Properties Link

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Using link text := '" +
                            actionsPaneLinkText +
                            "'");

                        ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                        taskPane.ClickLink(
                            Core.Console.ActionsPane.Strings.ActionsPaneChannel,
                            actionsPaneLinkText);

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Clicking actions pane link...");

                        #endregion Actions Pane Properties Link
                    }

                    break;
                case Constants.DeleteChannelAction.ViewShiftF10MenuHotKey:
                    {
                        #region Left-Click Item, SHIFT-F10, Select Delete Context Menu

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Using left-click, SHIFT-F10...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        channelRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        channelRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.ShiftF10);

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Left-Click Item, SHIFT-F10, Select Delete Context Menu
                    }

                    break;
                case Constants.DeleteChannelAction.ViewDeleteKey:
                    {
                        #region Left-Click Item, Press DELETE Key

                        // select item, press ENTER key
                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Using left-click, DELETE...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        channelRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        channelRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.Delete);

                        #endregion Left-Click Item, Press DELETE Key
                    }

                    break;
                default:
                    {
                        #region Right-Click Item, Select Delete Context Menu

                        // put focus back on the row in case tooltip appeared
                        channelRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Using right-click, context menu...");

                        // right-click item, properties menu
                        channelRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteChannel::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Right-Click Item, Select Delete Context Menu
                    }

                    break;
            }

            #endregion

            #region Confirm Deletion

            Core.Common.Utilities.LogMessage(
                "DeleteChannel::Confirm deletion := '" +
                confirmDeletion.ToString() +
                "'");

            // confirm the delete
            CoreManager.MomConsole.ConfirmChoiceDialog(
                confirmDeletion,
                CommonChannel.Strings.ConfirmChannelDeleteDialogTitle);

            // wait for the UI to settle
            CoreManager.MomConsole.Waiters.WaitForStatusReady(
                Core.Common.Constants.DefaultDialogTimeout);

            #endregion
        }

        /// <summary>
        /// Method to delete all channels from the UI and confirm or cancel the
        /// deletion based on the specified value for confirmDeletion.
        /// </summary>   
        /// <param name="confirmDeletion">
        /// Flag indicating if the deletion should be confirmed and committed.
        /// </param>
        public static void DeleteAllChannel(
            bool confirmDeletion)
        {            
            #region Select and delete all Channel

            CommonChannel.NavigateToView(
                NavigationPane.Strings.AdminTreeViewChannelsView);

            if (CoreManager.MomConsole.ViewPane.Grid.Rows.Count > 1)
            {
                // refresh the view
                Core.Common.Utilities.LogMessage(
                    "DeleteAllChannel::Refresh the view by F5.");
                CoreManager.MomConsole.ViewPane.Grid.Click();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                // Select All Channel
                Core.Common.Utilities.LogMessage(
                    "DeleteAllChannel::Select all channels by Ctrl + a.");
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.Ctrl + "a");

                // Delete All Channel
                Core.Common.Utilities.LogMessage(
                    "DeleteAllChannel::Delete all channels by Delete.");
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.Delete);

                #region Confirm Deletion

                Core.Common.Utilities.LogMessage(
                    "DeleteAllChannel::Confirm deletion := '" +
                    confirmDeletion.ToString() +
                    "'");

                // confirm the delete
                CoreManager.MomConsole.ConfirmChoiceDialog(
                    confirmDeletion,
                    CommonChannel.Strings.ConfirmChannelDeleteDialogTitle);

                // wait for the UI to settle
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);
                // ensure the DeleteAll action is done
                int waitcount = 0;
                while (CoreManager.MomConsole.ViewPane.Grid.Rows.Count > 1 && waitcount < 6)
                {
                    Core.Common.Utilities.LogMessage(
                    "DeleteAllChannel::Wait");
                    Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);
                    waitcount++;
                }
               
                Core.Common.Utilities.TakeScreenshot("Before_Exit_DeleteAll");
                Maui.Core.Keyboard.SendKeys(Mom.Test.UI.Core.Common.KeyboardCodes.F5);
                #endregion
            }

            #endregion Select and delete all Channel

        }

        /// <summary>
        /// Method to Check a channel if exist in the channel view
        /// </summary>
        /// <param name="channelName">
        /// The name of the channel
	/// </param>        
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if channel name is null or empty string.
        /// </exception>
        public static bool ChannelExists(
            string channelName)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(channelName))
            {
                throw new System.ArgumentNullException(
                    "Channel name parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Check Channel if exist

            CommonChannel.NavigateToView(
                NavigationPane.Strings.AdminTreeViewChannelsView);

            int maxRetry = 5;
            Maui.Core.WinControls.DataGridViewRow channelRow = null;
            int loopNumber = 0;
            while (null == channelRow && loopNumber++ < maxRetry)
            {
                // refresh the view
                CoreManager.MomConsole.ViewPane.Grid.Click();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                // wait for the UI to settle
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

                Core.Common.Utilities.LogMessage(
                    "IsExistChannel::Selecting channel row with name := '" +
                    channelName +
                    "'" +
                    " Retry times := " +
                    loopNumber);

                // select the channel in the grid view
                channelRow = CoreManager.MomConsole.ViewPane.Grid.FindData(
                    channelName);

                Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);
            }

            // check for valid row
            if (null == channelRow)
            {
                Core.Common.Utilities.LogMessage(
                    "IsExistChannel::The Channel '" +
                    channelName +
                    "' is not exist.");
                return false;
            }

            Core.Common.Utilities.LogMessage(
                    "IsExistChannel::The Channel '" +
                    channelName +
                    "' is exist.");
            return true;            

            #endregion Check Channel if exist
        }

        /// <summary>
        /// Method to navigate to the specified view in the Administration 
        /// space.
        /// </summary>
        /// <param name="viewName">
        /// The name of the view to search for and select.
        /// </param>
        /// <returns>
        /// A reference to the specified view tree node.
        /// </returns>
        /// <exception cref="Maui.Core.WinControls.TreeView.Exceptions.NodeNotFoundException">
        /// Throws 
        /// Maui.Core.WinControls.TreeView.Exceptions.NodeNotFoundException if
        /// the code fails to find and select the specified view.
        /// </exception>
        private static Maui.Core.WinControls.TreeNode NavigateToView(
            string viewName)
        {
            Core.Common.Utilities.LogMessage(
                "NavigateToView::Looking for tree view node := '" +
                viewName +
                "'");
            // navigate to the specified view
            Maui.Core.WinControls.TreeNode specifiedViewNode = null;

            try
            {

                // navigate to the specified view
                specifiedViewNode =
                    CoreManager.MomConsole.NavigationPane.SelectNode(
                        viewName,
                        NavigationPane.NavigationTreeView.Administration);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);
            }
            catch (Maui.Core.WinControls.TreeNode.Exceptions.InvalidItemHandleException)
            {
                Core.Common.Utilities.LogMessage(
                    "NavigateToView:: Got InvalidItemHandleException; " +
                    " re-trying SelectNode...");

                // navigate to the specified view
                specifiedViewNode =
                    CoreManager.MomConsole.NavigationPane.SelectNode(
                        viewName,
                        NavigationPane.NavigationTreeView.Administration);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

            }

            Core.Common.Utilities.LogMessage(
                "NavigateToView::Checking that current node is requested node...");
            Core.Common.Utilities.LogMessage(
                "NavigateToView::Current node := '" +
                specifiedViewNode.Text +
                "'");
            Core.Common.Utilities.LogMessage(
                "NavigateToView::Requested node := '" +
                viewName +
                "'");

            // check that the requested view is really the current view
            if (specifiedViewNode != null &&
                specifiedViewNode.Text.Equals(viewName) == false)
            {
                Core.Common.Utilities.LogMessage(
                    "NavigateToView::2nd chance, looking for tree view node := '" +
                    viewName +
                    "'");

                // try to navigate again
                specifiedViewNode =
                    CoreManager.MomConsole.NavigationPane.SelectNode(
                        viewName,
                        NavigationPane.NavigationTreeView.Administration);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

                Core.Common.Utilities.LogMessage(
                    "NavigateToView::Checking that current node is requested node...");
                Core.Common.Utilities.LogMessage(
                    "NavigateToView::Current node := '" +
                    specifiedViewNode.Text +
                    "'");

                // check again
                if (specifiedViewNode != null &&
                specifiedViewNode.Text.Equals(viewName) == false)
                {
                    throw new Maui.Core.WinControls.TreeView.Exceptions.NodeNotFoundException(
                        "Failed to select the '" +
                        viewName +
                        "' tree view node!");
                }
            }

            return specifiedViewNode;
        }

        /// <summary>
        /// Class to contain constants for the channels
        /// </summary>
        public sealed class Constants
        {
            /// <summary>
            /// Maximum number of wait attempts for channel save operation.
            /// </summary>
            public const int MaxWaitAttemptsForChannelSave = 90;

            /// <summary>
            /// Delay interval between wait attempts for channel save operation.
            /// </summary>
            public const int DelayIntervalForChannelSave = 2000;

            /// <summary>
            /// The maximum length of an channel name
            /// </summary>
            public const int NameMaxLength = 256;

            /// <summary>
            /// The short length of an channel name
            /// </summary>
            public const int NameShortLength = 64;

            /// <summary>
            /// The maximum length of an channel description
            /// </summary>
            public const int DescriptionMaxLength = 4000;

            /// <summary>
            /// The short length of an channel description
            /// </summary>
            public const int DescriptionShortLength = 128;

            /// <summary>
            /// The character used to separate tokens in message text, subject or
            /// body.
            /// </summary>
            public const string MessageTokenSeparator = "|";

            /// <summary>
            /// The character used to identify environment variables
            /// </summary>
            public const string EnvironmentVariableMarker = "%";

            /// <summary>
            /// The character used to identify alert parameters
            /// </summary>
            public const string AlertParameterMarker = "@";

            /// <summary>
            /// Constant for default value.  Used to indicate if default value
            /// for a UI field should be used, i.e. left at the current value.
            /// </summary>
            public const string DefaultValue = "Default";

            /// <summary>
            /// Constant defining the address identifier character used in
            /// email address to separate the user name from the domain
            /// address.
            /// </summary>
            public const string EmailAddressIdentifier = "@";

            /// <summary>
            /// Constant for the instant message return address prefix.  This
            /// is used to specify the protocol for instant message addresses.
            /// </summary>
            public const string InstantMessageReturnAddressPrefix = "sip:";

            /// <summary>
            /// Class to contain constant values for var-map record StartPoint.
            /// </summary>
            public sealed class StartPoint
            {
                /// <summary>
                /// Constant for the value AdminOverviewPageHyperLink
                /// </summary>
                public const string AdminOverviewPageHyperLink = "AdminOverviewPageHyperLink";

                /// <summary>
                /// Constant for the value ViewContextMenu
                /// </summary>
                public const string ViewContextMenu = "ViewContextMenu";

                /// <summary>
                /// Constant for the value TreeViewContextMenu
                /// </summary>
                public const string TreeViewContextMenu = "TreeViewContextMenu";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ActionsPaneLinkMenu = "ActionsPaneLinkMenu";
            }

            /// <summary>
            /// Class to contain constant values for var-map record
            /// ChannelNameType.
            /// </summary>
            public sealed class ChannelNameType
            {
                /// <summary>
                /// Constant for the value Default
                /// </summary>
                public const string Default = "Default";

                /// <summary>
                /// Constant for the value RandomShort
                /// </summary>
                public const string RandomShort = "RandomShort";

                /// <summary>
                /// Constant for the value RandomLong
                /// </summary>
                public const string RandomLong = "RandomLong";

                /// <summary>
                /// Constant for the value MaxLength
                /// </summary>
                public const string MaxLength = "MaxLength";

                /// <summary>
                /// Constant for the value MinLength
                /// </summary>
                public const string MinLength = "MinLength";
            }

            /// <summary>
            /// Class to contain constant values for var-map record
            /// DisplayPropertiesAction.
            /// </summary>
            public sealed class DisplayPropertiesAction
            {
                /// <summary>
                /// Constant for the value ViewContextMenu
                /// </summary>
                public const string ViewContextMenu = "ViewContextMenu";

                /// <summary>
                /// Constant for the value ViewEnterKey
                /// </summary>
                public const string ViewEnterKey = "ViewEnterKey";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ActionsPaneLinkMenu = "ActionsPaneLinkMenu";

                /// <summary>
                /// Constant for the value ViewDoubleClickItem
                /// </summary>
                public const string ViewDoubleClickItem = "ViewDoubleClickItem";

                /// <summary>
                /// Constant for the value ViewShiftF10MenuHotKey
                /// </summary>
                public const string ViewShiftF10MenuHotKey = "ViewShiftF10MenuHotKey";
            }

            /// <summary>
            /// Class to contain constant values for var-map record
            /// DeleteChannelAction.
            /// </summary>
            public sealed class DeleteChannelAction
            {
                /// <summary>
                /// Constant for the value ViewContextMenu
                /// </summary>
                public const string ViewContextMenu = "ViewContextMenu";

                /// <summary>
                /// Constant for the value ViewDeleteKey
                /// </summary>
                public const string ViewDeleteKey = "ViewDeleteKey";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ActionsPaneLinkMenu = "ActionsPaneLinkMenu";

                /// <summary>
                /// Constant for the value ViewShiftF10MenuHotKey
                /// </summary>
                public const string ViewShiftF10MenuHotKey = "ViewShiftF10MenuHotKey";
            }

            /// <summary>
            /// Class to contain constant values for var-map record
            /// AlertParameters.
            /// </summary>
            public sealed class AlertParameters
            {
                /// <summary>
                /// Constant for the value AlertSource
                /// </summary>
                public const string AlertSource = "@AlertSource@";

                /// <summary>
                /// Constant for the value AlertName
                /// </summary>
                public const string AlertName = "@AlertName@";

                /// <summary>
                /// Constant for the value AlertDescription
                /// </summary>
                public const string AlertDescription = "@AlertDescription@";

                /// <summary>
                /// Constant for the value AlertSeverity
                /// </summary>
                public const string AlertSeverity = "@AlertSeverity@";

                /// <summary>
                /// Constant for the value AlertPriority
                /// </summary>
                public const string AlertPriority = "@AlertPriority@";

                /// <summary>
                /// Constant for the value AlertCategory
                /// </summary>
                public const string AlertCategory = "@AlertCategory@";

                /// <summary>
                /// Constant for the value AlertResolutionState
                /// </summary>
                public const string AlertResolutionState = "@AlertResolutionState@";

                /// <summary>
                /// Constant for the value AlertOwner
                /// </summary>
                public const string AlertOwner = "@AlertOwner@";

                /// <summary>
                /// Constant for the value AlertResolvedBy
                /// </summary>
                public const string AlertResolvedBy = "@AlertResolvedBy@";

                /// <summary>
                /// Constant for the value AlertTimeRaised
                /// </summary>
                public const string AlertTimeRaised = "@AlertTimeRaised@";

                /// <summary>
                /// Constant for the value AlertResolutionTime
                /// </summary>
                public const string AlertResolutionTime = "@AlertResolutionTime@";

                /// <summary>
                /// Constant for the value AlertLastModifiedTime
                /// </summary>
                public const string AlertLastModifiedTime = "@AlertLastModifiedTime@";

                /// <summary>
                /// Constant for the value AlertLastModifiedBy
                /// </summary>
                public const string AlertLastModifiedBy = "@AlertLastModifiedBy@";

                /// <summary>
                /// Constant for the value WebConsoleLink
                /// </summary>
                public const string WebConsoleLink = "@WebConsoleLink@";

                /// <summary>
                /// Constant for the value CustomField1
                /// </summary>
                public const string CustomField1 = "@CustomField1@";

                /// <summary>
                /// Constant for the value CustomField2
                /// </summary>
                public const string CustomField2 = "@CustomField2@";

                /// <summary>
                /// Constant for the value CustomField3
                /// </summary>
                public const string CustomField3 = "@CustomField3@";

                /// <summary>
                /// Constant for the value CustomField4
                /// </summary>
                public const string CustomField4 = "@CustomField4@";

                /// <summary>
                /// Constant for the value CustomField5
                /// </summary>
                public const string CustomField5 = "@CustomField5@";

                /// <summary>
                /// Constant for the value CustomField6
                /// </summary>
                public const string CustomField6 = "@CustomField6@";

                /// <summary>
                /// Constant for the value CustomField7
                /// </summary>
                public const string CustomField7 = "@CustomField7@";

                /// <summary>
                /// Constant for the value CustomField8
                /// </summary>
                public const string CustomField8 = "@CustomField8@";

                /// <summary>
                /// Constant for the value CustomField9
                /// </summary>
                public const string CustomField9 = "@CustomField9@";

                /// <summary>
                /// Constant for the value CustomField10
                /// </summary>
                public const string CustomField10 = "@CustomField10@";
            }

            /// <summary>
            /// Class to contain constant values for var-map record Encoding.
            /// </summary>
            public sealed class Encoding
            {
                /// <summary>
                /// Constant for the value Default
                /// </summary>
                public const string Default = "Default";

                /// <summary>
                /// Constant for the value Unicode (UTF-8)
                /// </summary>
                public const string UTF8 = "Unicode (UTF-8)";

                /// <summary>
                /// Constant for the value Unicode (UTF-16)
                /// </summary>
                public const string UTF16 = "Unicode (UTF-16)";

                /// <summary>
                /// Constant for the value US-ASCII
                /// </summary>
                public const string US_ASCII = "US-ASCII";

                /// <summary>
                /// Constant for the value Unicode (UTF-7)
                /// </summary>
                public const string UTF7 = "Unicode (UTF-7)";

                /// <summary>
                /// Constant for the value Unicode
                /// </summary>
                public const string Unicode = "Unicode";
            }
        }

        /// <summary>
        /// Resource strings class.
        /// </summary>
        public sealed class Strings
        {
            #region Resource Constants

            /// <summary>
            /// Contains the resource identifier for 
            /// ConfirmChannelDeleteDialogTitle
            /// </summary>
            private const string ResourceConfirmChannelDeleteDialogTitle =
                ";Confirm Channel Delete" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ChannelDeleteConfirmationTitle";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SettingsNavigationLink
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceSettingsNavigationLink =
                ";Settings" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ChannelWizardSettingsPageTitle";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FormatNavigationLink
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceFormatNavigationLink =
                ";Format" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ChannelWizardFormatPageTitle";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultCommandChannelName 
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceDefaultCommandChannelName =
                "Default Command Channel Name";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultCommandChannelDescription 
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceDefaultCommandChannelDescription =
                "Default Command Channel Description";

            #region Context Menus

            /// <summary>
            /// Contains resource string for: Create new channel
            /// </summary>
            private const string ResourceCreateNewChannelContextMenu =
                ";New" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";New";

            /// <summary>
            /// Contains resource string for: Email...
            /// </summary>
            private const string ResourceEmailChannelContextMenu =
                ";E-Mail (SMTP)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";EmailChannelType";

            /// <summary>
            /// Contains resource string for: Instant Message (IM)...
            /// </summary>
            private const string ResourceInstantMessageChannelContextMenu =
                ";Instant Message (IM)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";IMChannelType";

            /// <summary>
            /// Contains resource string for: Text Message (SMS)...
            /// </summary>
            private const string ResourceSmsChannelContextMenu =
                ";Text Message (SMS)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";SMSChannelType";

            /// <summary>
            /// Contains resource string for: Command...
            /// </summary>
            private const string ResourceCommandChannelContextMenu =
                ";Command" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandChannelType";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Diereisis (...)
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceDiereisis =
                ";..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";Dieresis";

            #endregion Context Menus

            #region Alert Parameter Menu Items

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSource 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSource =
                ";Alert Source;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertSource";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertName 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertName =
                ";Alert Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertDescription =
                ";Alert Description;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertDescription";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSeverity =
                ";Alert Severity;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertSeverity";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertPriority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertPriority =
                ";Alert Priority;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertPriority";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertCategory =
                ";Alert Category;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCategory";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertResolutionState =
                ";Alert Resolution State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertResolutionState";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertOwner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertOwner =
                ";Alert Owner;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertOwner";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertResolvedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertResolvedBy =
                ";Alert Resolved By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertResolvedBy";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertLastModifiedTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertLastModifiedTime =
                ";Alert Last Modified Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertLastModifiedTime";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertTimeRaised
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertTimeRaised =
                ";Alert Raised Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertRaisedTime";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertTimeResolved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertTimeResolved =
                ";Alert Resolution Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertResolutionTime";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertCustomField
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertCustomField =
                ";Alert Custom Field;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustomField";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertLastModifiedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertLastModifiedBy =
                ";Alert Last Modified By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertLastModifiedBy";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WebConsoleLink
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebConsoleLink =
                ";WebConsole Link;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;WebConsoleLink";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField1 =
                ";Custom Field1;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField2 =
                ";Custom Field2;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField3 =
                ";Custom Field3;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField4 =
                ";Custom Field4;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom4";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField5 =
                ";Custom Field5;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom5";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField6 =
                ";Custom Field6;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom6";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField7
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField7 =
                ";Custom Field7;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom7";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField8 =
                ";Custom Field8;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom8";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField9
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField9 =
                ";Custom Field9;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom9";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField10
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField10 =
                ";Custom Field10;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom10";

            #endregion Alert Parameter Menu Items

            #endregion

            #region Private Members

            /// <summary>
            /// Cached translated value for ConfirmChannelDeleteDialogTitle
            /// </summary>
            private static string cachedConfirmChannelDeleteDialogTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// SettingsNavigationLink
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSettingsNavigationLink;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// FormatNavigationLink
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedFormatNavigationLink;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// DefaultCommandChannelName
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDefaultCommandChannelName;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// DefaultCommandChannelDescription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDefaultCommandChannelDescription;

            #region Context Menus

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

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Diereisis
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDiereisis;

            #endregion Context Menus

            #region ComboBox Items

            /// <summary>
            /// Contains resource string for: Email Channel Text
            /// </summary>
            private static string cachedEmailChannelText;

            /// <summary>
            /// Contains resource string for: Instant Message Channel Text
            /// </summary>
            private static string cachedInstantMessageChannelText;

            /// <summary>
            /// Contains resource string for: Text (SMS) Channel Text
            /// </summary>
            private static string cachedSmsChannelText;

            /// <summary>
            /// Contains resource string for: Command Channel Text
            /// </summary>
            private static string cachedCommandChannelText;

            #endregion

            #region Alert Parameter Menu Items

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSource;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSeverity;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertPriority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPriority;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertCategory;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolutionState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertOwner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertOwner;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertResolvedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolvedBy;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertLastModifiedTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertLastModifiedTime;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertTimeRaised
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertTimeRaised;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertTimeResolved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertTimeResolved;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertCustomField
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertCustomField;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertLastModifiedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertLastModifiedBy;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WebConsoleLink
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebConsoleLink;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField1;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField3;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField4;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField5;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField6;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField7
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField7;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField8;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField9
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField9;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField10
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField10;

            #endregion Alert Parameter Menu Items

            #endregion

            #region Public Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfirmChannelDeleteDialogTitletranslated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[kellymor] 10-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmChannelDeleteDialogTitle
            {
                get
                {
                    if ((cachedConfirmChannelDeleteDialogTitle == null))
                    {
                        cachedConfirmChannelDeleteDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceConfirmChannelDeleteDialogTitle);
                    }

                    return cachedConfirmChannelDeleteDialogTitle;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SettingsNavigationLink translated resource
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string SettingsNavigationLink
            {
                get
                {
                    if (cachedSettingsNavigationLink == null)
                    {
                        cachedSettingsNavigationLink =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSettingsNavigationLink);
                    }

                    return cachedSettingsNavigationLink;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FormatNavigationLink translated resource
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string FormatNavigationLink
            {
                get
                {
                    if (cachedFormatNavigationLink == null)
                    {
                        cachedFormatNavigationLink =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceFormatNavigationLink);
                    }

                    return cachedFormatNavigationLink;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultCommandChannelName translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 29-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string DefaultCommandChannelName
            {
                get
                {
                    if (null == cachedDefaultCommandChannelName)
                    {
                        cachedDefaultCommandChannelName =
                            ResourceDefaultCommandChannelName;
                    }

                    return cachedDefaultCommandChannelName;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultCommandChannelDescription translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 29-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string DefaultCommandChannelDescription
            {
                get
                {
                    if (null == cachedDefaultCommandChannelDescription)
                    {
                        cachedDefaultCommandChannelDescription =
                            ResourceDefaultCommandChannelDescription;
                    }

                    return cachedDefaultCommandChannelDescription;
                }
            }

            #region Context Menus

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create New Channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 10-SEP-08 Created
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
            /// 	[kellymor] 10-SEP-08 Created
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
                                ResourceEmailChannelContextMenu) +
                                Strings.Diereisis;
                    }

                    return cachedEmailChannelContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instant Message channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 10-SEP-08 Created
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
                                ResourceInstantMessageChannelContextMenu) +
                                Strings.Diereisis;
                    }

                    return cachedInstantMessageChannelContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Text (SMS) channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 10-SEP-08 Created
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
                                ResourceSmsChannelContextMenu) +
                                Strings.Diereisis;
                    }

                    return cachedSmsChannelContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Command channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 10-SEP-08 Created
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
                                ResourceCommandChannelContextMenu) +
                                Strings.Diereisis;
                    }

                    return cachedCommandChannelContextMenu;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Diereisis (...) resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 27-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Diereisis
            {
                get
                {
                    if ((cachedDiereisis == null))
                    {
                        cachedDiereisis =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDiereisis);
                    }

                    return cachedDiereisis;
                }
            }

            #endregion Context Menus

            #region ComboBox Items
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Email Channel text translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 27-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EmailChannelText
            {
                get
                {
                    if ((cachedEmailChannelText == null))
                    {
                        cachedEmailChannelText =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEmailChannelContextMenu);
                    }

                    return cachedEmailChannelText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instant Message channel text translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 27-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InstantMessageChannelText
            {
                get
                {
                    if ((cachedInstantMessageChannelText == null))
                    {
                        cachedInstantMessageChannelText =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceInstantMessageChannelContextMenu);
                    }

                    return cachedInstantMessageChannelText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Text (SMS) channel text translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 27-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SmsChannelText
            {
                get
                {
                    if ((cachedSmsChannelText == null))
                    {
                        cachedSmsChannelText =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSmsChannelContextMenu);
                    }

                    return cachedSmsChannelText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Command channel text translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 27-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommandChannelText
            {
                get
                {
                    if ((cachedCommandChannelText == null))
                    {
                        cachedCommandChannelText =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCommandChannelContextMenu);
                    }

                    return cachedCommandChannelText;
                }
            }
 
            #endregion

            #region Alert Parameter Menu Items

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSource translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertSource
            {
                get
                {
                    if ((cachedAlertSource == null))
                    {
                        cachedAlertSource =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertSource);
                    }

                    return cachedAlertSource;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertName
            {
                get
                {
                    if ((cachedAlertName == null))
                    {
                        cachedAlertName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertName);
                    }

                    return cachedAlertName;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertDescription
            {
                get
                {
                    if ((cachedAlertDescription == null))
                    {
                        cachedAlertDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertDescription);
                    }

                    return cachedAlertDescription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSeverity translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertSeverity
            {
                get
                {
                    if ((cachedAlertSeverity == null))
                    {
                        cachedAlertSeverity =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertSeverity);
                    }

                    return cachedAlertSeverity;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertPriority translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertPriority
            {
                get
                {
                    if ((cachedAlertPriority == null))
                    {
                        cachedAlertPriority =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertPriority);
                    }

                    return cachedAlertPriority;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertCategory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertCategory
            {
                get
                {
                    if ((cachedAlertCategory == null))
                    {
                        cachedAlertCategory =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertCategory);
                    }

                    return cachedAlertCategory;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertResolutionState translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertResolutionState
            {
                get
                {
                    if ((cachedAlertResolutionState == null))
                    {
                        cachedAlertResolutionState =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertResolutionState);
                    }

                    return cachedAlertResolutionState;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertOwner translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertOwner
            {
                get
                {
                    if ((cachedAlertOwner == null))
                    {
                        cachedAlertOwner =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertOwner);
                    }

                    return cachedAlertOwner;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertResolvedBy translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertResolvedBy
            {
                get
                {
                    if ((cachedAlertResolvedBy == null))
                    {
                        cachedAlertResolvedBy =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertResolvedBy);
                    }

                    return cachedAlertResolvedBy;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertLastModifiedTime translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertLastModifiedTime
            {
                get
                {
                    if ((cachedAlertLastModifiedTime == null))
                    {
                        cachedAlertLastModifiedTime =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertLastModifiedTime);
                    }

                    return cachedAlertLastModifiedTime;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertTimeRaised translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertTimeRaised
            {
                get
                {
                    if ((cachedAlertTimeRaised == null))
                    {
                        cachedAlertTimeRaised =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertTimeRaised);
                    }

                    return cachedAlertTimeRaised;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertTimeResolved translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertTimeResolved
            {
                get
                {
                    if ((cachedAlertTimeResolved == null))
                    {
                        cachedAlertTimeResolved =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertTimeResolved);
                    }

                    return cachedAlertTimeResolved;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertCustomField translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertCustomField
            {
                get
                {
                    if ((cachedAlertCustomField == null))
                    {
                        cachedAlertCustomField =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertCustomField);
                    }

                    return cachedAlertCustomField;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertLastModifiedBy translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertLastModifiedBy
            {
                get
                {
                    if ((cachedAlertLastModifiedBy == null))
                    {
                        cachedAlertLastModifiedBy =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertLastModifiedBy);
                    }

                    return cachedAlertLastModifiedBy;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebConsoleLink translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WebConsoleLink
            {
                get
                {
                    if ((cachedWebConsoleLink == null))
                    {
                        cachedWebConsoleLink =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWebConsoleLink);
                    }

                    return cachedWebConsoleLink;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField1
            {
                get
                {
                    if ((cachedCustomField1 == null))
                    {
                        cachedCustomField1 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField1);
                    }

                    return cachedCustomField1;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField2
            {
                get
                {
                    if ((cachedCustomField2 == null))
                    {
                        cachedCustomField2 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField2);
                    }

                    return cachedCustomField2;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField3 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField3
            {
                get
                {
                    if ((cachedCustomField3 == null))
                    {
                        cachedCustomField3 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField3);
                    }

                    return cachedCustomField3;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField4 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField4
            {
                get
                {
                    if ((cachedCustomField4 == null))
                    {
                        cachedCustomField4 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField4);
                    }

                    return cachedCustomField4;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField5 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField5
            {
                get
                {
                    if ((cachedCustomField5 == null))
                    {
                        cachedCustomField5 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField5);
                    }

                    return cachedCustomField5;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField6 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField6
            {
                get
                {
                    if ((cachedCustomField6 == null))
                    {
                        cachedCustomField6 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField6);
                    }

                    return cachedCustomField6;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField7 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField7
            {
                get
                {
                    if ((cachedCustomField7 == null))
                    {
                        cachedCustomField7 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField7);
                    }

                    return cachedCustomField7;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField8 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField8
            {
                get
                {
                    if ((cachedCustomField8 == null))
                    {
                        cachedCustomField8 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField8);
                    }

                    return cachedCustomField8;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField9 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField9
            {
                get
                {
                    if ((cachedCustomField9 == null))
                    {
                        cachedCustomField9 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField9);
                    }

                    return cachedCustomField9;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField10 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField10
            {
                get
                {
                    if ((cachedCustomField10 == null))
                    {
                        cachedCustomField10 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField10);
                    }

                    return cachedCustomField10;
                }
            }

            #endregion Alert Parameter Menu Items

            #endregion
        }
    }
}
