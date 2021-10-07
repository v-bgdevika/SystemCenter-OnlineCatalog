// ----------------------------------------------------------------------------
// <copyright file="CommonSubscriber.cs" company="Microsoft">
//  Copyright (c) Microsoft Corporation 2008
// </copyright>
// 
// <summary>
// Class to implement common test methods for the subscriber tests.
// </summary>
// 
// <note>
// See the end of this source file for a detailed history
// </note>
// 
// <history>
//		[kellymor]  25-SEP-08   Created.
//      [kellymor]  29-SEP-08   Added ChannelType class to Constants class.
//                              Implemented SetSubscriberSchedule and
//                              SetSubscriberAddress.
//      [KellyMor]  04-OCT-08   Completed the SetSubscriberName implementation.
//                              Updated StartWizard, DisplayProperties, and
//                              DeleteSubscriber to use new Actions pane
//                              "Subscriber" group.
//                              Added resource string for Delete confirmation
//                              dialog.
//                              Enabled delete confirmation.
//      [KellyMor]  07-OCT-08   Updated resource for new notification 
//                              subscriber context menu and actions pane link
//                              Updated navigation code to use correct timeout
//      [KellyMor]  09-OCT-08   Added private NavigateToView() method to add
//                              another layer of retry logic around the Core
//                              NavigationPane.SelectNode() method.  The new
//                              dynamic admin tree view updates/refreshes on
//                              every MP import, which happens every time a
//                              subscription is created, edited or deleted.
//      [KellyMor]  10-OCT-08   Reliability fixes for SetSubscriberAddress
//                              Fixed a bug in SetSubscriberAddress that would
//                              allow a mismatch to occur between specified
//                              delivery address and address from AD.  The
//                              user-specified address wins out.
//      [KellyMor]  11-OCT-08   Added retry logic to AddSubscriberAddress to
//                              handle odd timing issue with address name text
//                              box.
//      [KellyMor]  16-OCT-08   Modified StartWizard to use new tree view
//                              context menu for new channel...
//      [KellyMor]  27-OCT-08   Fixed an issue with the tooltip blocking the
//                              context menu when an item's description is
//                              longer than the grid cell in DisplayProperties
//                              and DeleteSubscriber.
//      [KellyMor]  28-OCT-08   Added fix to default case for same context menu
//                              issue in DisplayProperties and DeleteChannel.
// </history>
// 
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers
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
    /// Class to implement the common methods for the subscriber tests.
    /// </summary>
    public class CommonSubscriber
    {
        /// <summary>
        /// Method to start a subscriber wizard from the specified start point
        /// in the Administration space of the UI using the specified context
        /// menu item text or link.
        /// </summary>
        /// <param name="startPoint">
        /// The start point in the Administration UI.  Valid values are defined
        /// in the Constants.StartPoint class.
        /// </param>
        /// <param name="subscriberMenuItemText">
        /// The context menu item text.  The same text is used for action pane
        /// links.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if the start point passed
        /// is not among the defined types in the Constants.StartPoint class.
        /// </exception>
        public static void StartWizard(
            string startPoint,
            string subscriberMenuItemText)
        {
            // start the wizard from the specified start point
            switch (startPoint)
            {
                case Constants.StartPoint.SubscriptionWizardSubscribersPage:
                    {
                        #region Subscription Wizard Subscribers Page

                        #endregion Subscription Wizard Subscribers Page
                    }

                    break;
                case Constants.StartPoint.ViewContextMenu:
                    {
                        #region View Pane Context Menu

                        CommonSubscriber.NavigateToView(
                            NavigationPane.Strings.AdminTreeViewRecipients);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Selecting the view pane grid...");

                        // select the view pane
                        CoreManager.MomConsole.ViewPane.Grid.Click();

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Looking for context menu...");

                        // right-click and display context menu
                        CoreManager.MomConsole.ViewPane.Grid.Click(
                            MouseFlags.RightButton);

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Selecting context menu := '" +
                            CommonSubscriber.Strings.NewSubscriberContextMenu +
                            "'");

                        // display subscribers sub-menu
                        contextMenu.ExecuteMenuItem(
                            CommonSubscriber.Strings.NewSubscriberContextMenu);

                        #endregion View Pane Context Menu
                    }

                    break;
                case Constants.StartPoint.TreeViewContextMenu:
                    {
                        #region Tree View Context Menu

                        // get the tree view node
                        Maui.Core.WinControls.TreeNode subscribersViewNode =
                            CommonSubscriber.NavigateToView(
                                NavigationPane.Strings.AdminTreeViewRecipients);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Looking for context menu...");

                        // get the context menu
                        subscribersViewNode.Click(
                            MouseFlags.RightButton);
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Selecting context menu := '" +
                            NavigationPane.Strings.ContextMenuNewSubscriber +
                            "'");

                        // select the create new subscriber menu item
                        contextMenu.ExecuteMenuItem(
                            NavigationPane.Strings.ContextMenuNewSubscriber);

                        #endregion Tree View Context Menu
                    }

                    break;
                case Constants.StartPoint.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Links

                        CommonSubscriber.NavigateToView(
                            NavigationPane.Strings.AdminTreeViewRecipients);

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                CommonSubscriber.Strings.NewSubscriberContextMenu);

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
                            NavigationPane.Strings.AdminTreeViewRecipients;

                        CoreManager.MomConsole.ActionsPane.ClickLink(
                            NavigationPane.WunderBarButton.Administration,
                            pathToView,
                            Core.Console.ActionsPane.Strings.ActionsPaneSubscriber,
                            actionsPaneLinkText);

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
        /// Method to set the subscriber name text.  The method reference to a 
        /// NameAndDescriptionWindow and the specified text for the name and 
        /// description.
        /// </summary>
        /// <param name="subscriberId">
        /// The subscriber ID, usually the UPN (username@domain.tld) 
        /// or NetBIOS (DOMAIN\username) ID.  
        /// </param>
        /// <param name="setSubscriberIdMethod">
        /// Specifies how the subscriber ID is set or selected.  This can be
        /// one of the options specified in Constants.SetSubscriberIdMethod.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws exception if either parameter is null or empty string.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Throws exception if SetSubscriberIdMethod is Default and the
        /// pre-populated subscriber ID does not match current, logged-on user
        /// ID in DOMAIN\username format.
        /// </exception>
        public static void SetSubscriberName(
            string subscriberId,
            string setSubscriberIdMethod)
        {
            if (String.IsNullOrEmpty(subscriberId))
            {
                throw new System.ArgumentNullException(
                    "Subscriber ID text must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(setSubscriberIdMethod))
            {
                throw new System.ArgumentNullException(
                    "Set subscriber method parameter must not be null or empty string!");
            }

            // get the wizard window
            Wizards.NameAndDescriptionWindow subscriberNameWindow =
                new Wizards.NameAndDescriptionWindow(
                    CoreManager.MomConsole);

            #region Set Subscriber ID

            switch (setSubscriberIdMethod)
            {
                case Constants.SetSubscriberIdMethod.TypeIn:
                    {
                        #region Type In

                        Core.Common.Utilities.LogMessage(
                            "SetSubscriberName::Typing in subscriber ID := '" +
                            subscriberId +
                            "'");

                        subscriberNameWindow.NameText =
                            subscriberId;

                        #endregion Type In
                    }

                    break;

                case Constants.SetSubscriberIdMethod.BrowseFor:
                    {
                        #region Browse For Subscriber in AD

                        // Implement AD Browse for username
                        // browse for the user name
                        subscriberNameWindow.Controls.BrowseButton.Click();

                        Core.Console.UserRole.Dialogs.SelectUsersOrGroups selectUserOrGroup =
                            new Core.Console.UserRole.Dialogs.SelectUsersOrGroups(true);

                        selectUserOrGroup.TextBox5Text = subscriberId;

                        selectUserOrGroup.ClickOK();

                        #endregion
                    }

                    break;

                case Constants.SetSubscriberIdMethod.Default:
                    {
                        #region Default - Use Pre-Populated Field

                        // check the name field to see if it is pre-populated
                        if (false == String.IsNullOrEmpty(subscriberNameWindow.NameText))
                        {
                            // log the displayed user
                            Core.Common.Utilities.LogMessage(
                                "SetSubscriberId::Using pre-populated subscriber ID := '" +
                                subscriberNameWindow.NameText +
                                "'");

                            // get the current, logged on username
                            string currentUsername =
                                System.Environment.UserName;

                            // get the current, logged on user's NetBIOS domain name
                            string currentUserDomain =
                                System.Environment.UserDomainName;

                            // munge the username and domain into the same format as subscriber ID
                            string mungedUserDomainSlashUsername =
                                currentUserDomain +
                                @"\" +
                                currentUsername;

                            Core.Common.Utilities.LogMessage(
                                "SetSubscriberId::Comparing current user ID, '" +
                                mungedUserDomainSlashUsername + 
                                "', with subscriber ID, '" +
                                subscriberNameWindow.NameText +
                                "'...");

                            // check if the displayed user matches the current user
                            if (mungedUserDomainSlashUsername.Equals(subscriberNameWindow.NameText))
                            {
                                Core.Common.Utilities.LogMessage(
                                    "SetSubscriberId::ID's match!");
                            }
                            else
                            {
                                throw new System.ArgumentException(
                                    "Pre-populated subscriber ID does not match current user ID!" +
                                    "  Expected := '" +
                                    mungedUserDomainSlashUsername +
                                    "'.  Found := '" +
                                    subscriberNameWindow.NameText +
                                    "'");
                            }
                        }

                        #endregion
                    }

                    break;

                default:
                    {
                        #region Type In

                        Core.Common.Utilities.LogMessage(
                            "SetSubscriberName::Typing in subscriber ID := '" +
                            subscriberId +
                            "'");

                        subscriberNameWindow.NameText =
                            subscriberId;

                        #endregion
                    }

                    break;
            }

            #endregion
        }

        /// <summary>
        /// Method to set the subscriber's schedule data in a subscriber wizard
        /// instance.
        /// </summary>
        /// <param name="subscriberScheduleData">
        /// The schedule data item.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the schedule data item is 
        /// null.
        /// </exception>
        public static void SetSubscriberSchedule(
            ScheduleData subscriberScheduleData)
        {
            // check for valid shedule item
            if (null == subscriberScheduleData)
            {
                throw new System.ArgumentNullException(
                    "Subscriber schedule data item must not be null!");
            }

            // get subscriber schedule window
            Subscribers.Wizards.NotificationCalendarWindow notificationCalendarWindow =
                new Subscribers.Wizards.NotificationCalendarWindow(
                    CoreManager.MomConsole);

            Core.Common.Utilities.LogMessage(
                "SetSubscriberSchedule::Clicking 'Add' button...");

            // set the notification schedule
            notificationCalendarWindow.ClickAdd();

            Core.Common.Utilities.LogMessage(
                "SetSubscriberSchedule::Looking for schedule period dialog...");

            // find the specify schedule period dialog
            Subscribers.Wizards.SpecifySchedulePeriodDialog schedulePeriodDialog =
                new Subscribers.Wizards.SpecifySchedulePeriodDialog(
                    CoreManager.MomConsole);

            Core.Common.Utilities.LogMessage(
                "SetSubscriberSchedule::Setting date range option...");

            #region Set Date Range Options

            // check for date range
            if (subscriberScheduleData.Always == true)
            {
                Core.Common.Utilities.LogMessage(
                    "SetSubscriberSchedule::Setting 'Always' date option...");

                // set the "Always" option
                schedulePeriodDialog.DateRangeOption = 
                    Subscribers.Wizards.DateRangeOptions.Always;
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "SetSubscriberSchedule::Setting 'Within Date Range' option...");

                // set the date range option
                schedulePeriodDialog.DateRangeOption = 
                    Subscribers.Wizards.DateRangeOptions.WithinDateRange;

                Core.Common.Utilities.LogMessage(
                    "SetSubscriberSchedule::Setting 'From' date := '" +
                    subscriberScheduleData.StartDate.ToShortDateString() +
                    "'");

                // set the "From" date
                schedulePeriodDialog.Controls.StartDateDatePicker.DateTime =
                    subscriberScheduleData.StartDate;

                Core.Common.Utilities.LogMessage(
                    "SetSubscriberSchedule::Setting 'To' date := '" +
                    subscriberScheduleData.StopDate.ToShortDateString() +
                    "'");

                // set the "To" date
                schedulePeriodDialog.Controls.EndDateDatePicker.DateTime =
                    subscriberScheduleData.StopDate;
            }

            #endregion Set Date Range Options

            #region Set Time Range Options

            // check time range option
            if (subscriberScheduleData.AllDay == true)
            {
                Core.Common.Utilities.LogMessage(
                    "SetSubscriberSchedule::Setting 'All day' date option...");

                // set the "All day" option
                schedulePeriodDialog.WeeklyOccurenceOption = 
                    Subscribers.Wizards.WeeklyOccurenceOptions.AllDay24Hours;
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "SetSubscriberSchedule::Setting 'Within Date Range' option...");

                // set the time range option
                schedulePeriodDialog.WeeklyOccurenceOption = 
                    Subscribers.Wizards.WeeklyOccurenceOptions.WithinTimeRange;

                Core.Common.Utilities.LogMessage(
                    "SetSubscriberSchedule::Setting 'From' time := '" +
                    subscriberScheduleData.StartTime.ToShortTimeString() +
                    "'");

                // set the "From" time
                schedulePeriodDialog.Controls.StartTimeTimePicker.DateTime =
                    subscriberScheduleData.StartTime;

                Core.Common.Utilities.LogMessage(
                    "SetSubscriberSchedule::Setting 'To' time := '" +
                    subscriberScheduleData.StopTime.ToShortTimeString() +
                    "'");

                // set the "To" time
                schedulePeriodDialog.Controls.EndTimeTimePicker.DateTime =
                    subscriberScheduleData.StopTime;
            }

            // TODO:  check exclusion time range.  Not yet implemented.

            #endregion Set Time Range Options

            #region Set Days of Week

            Core.Common.Utilities.LogMessage(
                "SetSubscriberSchedule::Setting days of the week...");

            // check for days of the week values
            if (null != subscriberScheduleData.EachDayOfTheWeek &&
                6 < subscriberScheduleData.EachDayOfTheWeek.Length)
            {
                // check Sunday
                schedulePeriodDialog.Sunday =
                    subscriberScheduleData.EachDayOfTheWeek[0];

                // check Monday
                schedulePeriodDialog.Monday =
                   subscriberScheduleData.EachDayOfTheWeek[1];

                // check Tuesday
                schedulePeriodDialog.Tuesday =
                   subscriberScheduleData.EachDayOfTheWeek[2];

                // check Wednesday
                schedulePeriodDialog.Wednesday =
                   subscriberScheduleData.EachDayOfTheWeek[3];

                // check Thursday
                schedulePeriodDialog.Thursday =
                   subscriberScheduleData.EachDayOfTheWeek[4];

                // check Friday
                schedulePeriodDialog.Friday =
                   subscriberScheduleData.EachDayOfTheWeek[5];

                // check Saturday
                schedulePeriodDialog.Saturday =
                   subscriberScheduleData.EachDayOfTheWeek[6];
            }

            #endregion

            #region Set Time Zone

            // TODO:  Find out if time zone values are translated.

            #endregion

            // commit the change
            schedulePeriodDialog.ClickOK();
        }

        /// <summary>
        /// Method to set subscriber addresses in the current subscriber
        /// wizard.
        /// </summary>
        /// <param name="deliveryAddress">
        /// The delivery address for the subscriber address.
        /// </param>
        /// <param name="channelType">
        /// The channel type used for the delivery address.
        /// </param>
        /// <param name="commandChannelName">
        /// The command channel name to use if the channel type is command
        /// channel.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the list of subscriber
        /// addresses is null or the list is empty.
        /// </exception>
        public static void SetSubscriberAddress(
            string deliveryAddress,
            string channelType,
            string commandChannelName)
        {
            if (String.IsNullOrEmpty(deliveryAddress))
            {
                throw new System.ArgumentNullException(
                    "Delivery address must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(channelType))
            {
                throw new System.ArgumentNullException(
                    "Channel type must not be null or empty string!");
            }

            if (null == commandChannelName)
            {
                throw new System.ArgumentNullException(
                    "Command channel name must not be null!");
            }

            // create a subscriber address name
            string subscriberAddressName =
                deliveryAddress + 
                " - " + 
                System.DateTime.Now.ToShortDateString() + 
                " " + 
                System.DateTime.Now.ToShortTimeString();

            // create a new subscriber address
            SubscriberAddressParams subscriberAddress =
                new SubscriberAddressParams(
                subscriberAddressName, 
                commandChannelName, 
                channelType, 
                deliveryAddress);

            // create a new list of subscribers
            List<SubscriberAddressParams> listOfAddresses =
                new List<SubscriberAddressParams>();

            // add subscriber to list
            listOfAddresses.Add(subscriberAddress);

            // call appropriate core method
            CommonSubscriber.SetSubscriberAddress(listOfAddresses);
        }

        /// <summary>
        /// Method to set subscriber addresses in the current subscriber
        /// wizard.
        /// </summary>
        /// <param name="subscriberAddresses">
        /// The list of subscriber addresses.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the list of subscriber
        /// addresses is null or the list is empty.
        /// </exception>
        public static void SetSubscriberAddress(
            List<SubscriberAddressParams> subscriberAddresses)
        {
            Core.Common.Utilities.LogMessage(
                "SetSubscriberAddress...");

            // check for valid list of subscriber addresses
            if (null == subscriberAddresses || 0 == subscriberAddresses.Count)
            {
                throw new System.ArgumentNullException(
                    "List of subscriber addresses must not be null or empty list!");
            }

            // reference to the Notification Calendar wizard window
            Wizards.SubscriberAddressesWindow subscriberAddressesWindow = null;

            #region Get Wizard Window

            Core.Common.Utilities.LogMessage(
                "SetSubscriberAddress::Looking for Subscriber Addresses window...");

            // get a new reference
            subscriberAddressesWindow =
                new Wizards.SubscriberAddressesWindow(
                    CoreManager.MomConsole);
            UISynchronization.WaitForUIObjectReady(
                subscriberAddressesWindow,
                Core.Common.Constants.DefaultDialogTimeout);

            #endregion Get Wizard Window

            #region Add Subscriber Address

            Core.Common.Utilities.LogMessage(
                "SetSubscriberAddress::Setting addresses...");

            foreach (SubscriberAddressParams currentAddress in
                subscriberAddresses)
            {
                // click the "Add" button
                subscriberAddressesWindow.ClickAdd();

                Core.Common.Utilities.LogMessage(
                    "SetSubscriberAddress::Looking for Subscriber Address wizard...");

                // find the subscriber address name wizard window
                Wizards.SubscriberAddressNameWindow addressNameWindow =
                    new Wizards.SubscriberAddressNameWindow(
                        CoreManager.MomConsole);
                UISynchronization.WaitForUIObjectReady(
                    addressNameWindow,
                    Core.Common.Constants.DefaultDialogTimeout);

                #region Set Subscriber Address Name

                Core.Common.Utilities.LogMessage(
                    "SetSubscriberAddress::Setting address name := '" +
                    currentAddress.Name +
                    "'");

                // HACK:  Work-around for odd timing issue with text box
                bool nameTextBoxFound = false;
                const int MaxAttempts = 30;
                for (int currentAttempt = 0; 
                    ((currentAttempt < MaxAttempts) && 
                        (nameTextBoxFound == false)); 
                    currentAttempt++)
                {
                    try
                    {
                        // access text field and determine enabled and visible
                        nameTextBoxFound = 
                            addressNameWindow.Controls.NameTextBox.IsEnabled &&
                            addressNameWindow.Controls.NameTextBox.IsVisible;
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {

                        addressNameWindow =
                            new Wizards.SubscriberAddressNameWindow(
                                CoreManager.MomConsole);

                        UISynchronization.WaitForUIObjectReady(
                            addressNameWindow,
                            Core.Common.Constants.DefaultDialogTimeout);

                        // log the attempt
                        Core.Common.Utilities.LogMessage(
                            "SetSubscriberAddress::Attempt " +
                            currentAttempt +
                            " of " +
                            MaxAttempts);

                        // delay
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.DefaultContextMenuTimeout);
                    }
                }

                if (nameTextBoxFound == false)
                {
                    /* Try one more time to get the window as there may be some
                     * confusion on MAUI's part between the 
                     * "Subscriber Addresses" window, this one, and it's parent
                     * window.  The parent window has a subtitle of
                     * "Subscriber Addresses" and it's possible that the Init
                     * method for the wizard window finds the parent instead of
                     * the child.
                     */
                    addressNameWindow =
                        new Wizards.SubscriberAddressNameWindow(
                            CoreManager.MomConsole);
                    UISynchronization.WaitForUIObjectReady(
                        addressNameWindow,
                        Core.Common.Constants.DefaultDialogTimeout);
                }

                try
                {
                    // enter the address name
                    addressNameWindow.NameText =
                        currentAddress.Name;
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    throw new Maui.Core.WinControls.TextBox.Exceptions.WindowNotFoundException(
                    "Unable to access name text box, WinFormsID := '" +
                    Subscribers.Wizards.SubscriberAddressNameWindow.ControlIDs.NameTextBox +
                    "', on parent window with title := '" +
                    Subscribers.Wizards.SubscriberAddressNameWindow.Strings.SubscriberAddressWizardTitle +
                    "'");
                }                

                // click "Next"
                addressNameWindow.ClickNext();

                #endregion Set Subscriber Address Name

                Core.Common.Utilities.LogMessage(
                    "SetSubscriberAddress::Looking for Subscriber Address Channel window...");

                // find the subscriber address channel wizard window
                Wizards.SubscriberAddressChannelWindow addressChannelWindow =
                    new Wizards.SubscriberAddressChannelWindow(
                        CoreManager.MomConsole);
                UISynchronization.WaitForUIObjectReady(
                    addressChannelWindow,
                    Core.Common.Constants.DefaultDialogTimeout);

                #region Set Subscriber Address Channel

                Core.Common.Utilities.LogMessage(
                    "SetSubscriberAddress::Selecting channel by type := '" +
                    currentAddress.ChannelType +
                    "'");

                #region Translate Channel Type Parameter

                // Convert channel name to localized resource
                string translatedChannelTypeName = null;
                switch (currentAddress.ChannelType)
                {
                    case Constants.ChannelType.Email:
                        {
                            translatedChannelTypeName =
                                Channels.CommonChannel.Strings.EmailChannelText;
                        }

                        break;
                    case Constants.ChannelType.InstantMessage:
                        {
                            translatedChannelTypeName =
                                Channels.CommonChannel.Strings.InstantMessageChannelText;
                        }

                        break;
                    case Constants.ChannelType.ShortMessage:
                        {
                            translatedChannelTypeName =
                                Channels.CommonChannel.Strings.SmsChannelText;
                        }

                        break;
                    case Constants.ChannelType.Command:
                        {
                            translatedChannelTypeName =
                                Channels.CommonChannel.Strings.CommandChannelText;
                        }

                        break;
                    default:
                        {
                            throw new ApplicationException(
                                "Unknown or unrecognized channel type := '" +
                                currentAddress.ChannelName +
                                "'");
                        }
                }
                
                Core.Common.Utilities.LogMessage(
                    "SetSubscriberAddress::Using translated channel type name := '" +
                    translatedChannelTypeName +
                    "'...");

                #endregion Translate Channel Type Parameter

                // click the combo-box button to display list of options
                addressChannelWindow.Controls.ChannelComboBox.ClickDropDown();

                // set the channel type
                addressChannelWindow.Controls.ChannelComboBox.SelectByText(
                    translatedChannelTypeName);

                // If channel type is command then select specific command channel
                if (currentAddress.ChannelType.Equals(Constants.ChannelType.Command))
                {
                    Core.Common.Utilities.LogMessage(
                        "SetSubscriberAddress::Selecting command channel by name := '" +
                        currentAddress.ChannelName +
                        "'");

                    // expand the drop down
                    addressChannelWindow.Controls.CommandChannelListComboBox.ClickDropDown();

                    // select the command channel
                    addressChannelWindow.Controls.CommandChannelListComboBox.SelectByText(
                        currentAddress.ChannelName);
                }

                #endregion Set Subscriber Address Channel

                #region Set Delivery Address

                // check to see if delivery address is set automatically
                if (String.IsNullOrEmpty(addressChannelWindow.DeliveryAddressText))
                {
                    Core.Common.Utilities.LogMessage(
                        "SetSubscriberAddress::Setting delivery address := '" +
                        currentAddress.DeliveryAddress +
                        "'");

                    // set the delivery address
                    if (addressChannelWindow.Controls.DeliveryAddressTextBox.IsEnabled == true)
                    {
                        addressChannelWindow.DeliveryAddressText =
                            currentAddress.DeliveryAddress;
                    }
                }
                else
                {
                    // check to see if AD address matches specified address
                    if (currentAddress.DeliveryAddress.Equals(addressChannelWindow.DeliveryAddressText))
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetSubscriberAddress::Using delivery address from Active Directory := '" +
                            addressChannelWindow.DeliveryAddressText +
                            "'");
                    }
                    else
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetSubscriberAddress::Overriding delivery address from AD, '" +
                            addressChannelWindow.DeliveryAddressText +
                            ", with specified address, '" +
                            currentAddress.DeliveryAddress +
                            "'");

                        // override AD address
                        addressChannelWindow.DeliveryAddressText =
                            currentAddress.DeliveryAddress;

                        // delete the AD address
//                          addressChannelWindow.Controls.DeliveryAddressTextBox.SetSelection(
//                              currentAddress.DeliveryAddress.Length,
//                              (addressChannelWindow.Controls.DeliveryAddressTextBox.Text.Length - currentAddress.DeliveryAddress.Length));
//                          addressChannelWindow.Controls.DeliveryAddressTextBox.SendKeys(
//                              Core.Common.KeyboardCodes.Del);
                    }
                }

                // sleep two seconds for delivery address text inputed
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond*2);

                // click "Next"
                addressChannelWindow.ClickNext();

                #endregion Set Delivery Address

                // find the subscriber address schedule wizard window
                Wizards.SubscriberAddressScheduleWindow addressScheduleWindow =
                    new Wizards.SubscriberAddressScheduleWindow(
                        CoreManager.MomConsole);
                UISynchronization.WaitForUIObjectReady(
                    addressScheduleWindow,
                    Core.Common.Constants.DefaultDialogTimeout);

                #region Set Subscriber Address Schedule

                // TODO: Set the subscriber address (device) schedule option

                // click "Next"
                addressScheduleWindow.ClickNext();

                #endregion

                // click "Finish"
                addressScheduleWindow.ClickFinish();
            }

            #endregion Add Subscriber Address

            Core.Common.Utilities.LogMessage(
                "SetSubscriberAddress::Clicking 'Save' button...");

            subscriberAddressesWindow.ClickFinish();

            // drop the reference
            subscriberAddressesWindow = null;
        }

        /// <summary>
        /// Method to wait for the wizard to finish saving the newly created
        /// subscriber.  The method looks for the Summary Wizard window 
        /// specified by the caller and makes 30 attempts with a 2 second delay
        /// between attempts.
        /// </summary>
        /// <returns>
        /// True if subscriber save was successful otherwise returns false.
        /// </returns>
        public static bool WaitForSubscriberSave()
        {
            return CommonSubscriber.WaitForSubscriberSave(
                Constants.MaxWaitAttemptsForSubscriberSave,
                Constants.DelayIntervalForSubscriberSave);
        }

        /// <summary>
        /// Method to wait for the wizard to finish saving the newly created
        /// subscriber.  The method looks for the Summary Wizard window 
        /// specified by the caller and makes the specified number of attemtps 
        /// with a short, specified delay.
        /// </summary>
        /// <param name="maxAttempts">
        /// The maximum number of attemtps to make.
        /// </param>
        /// <param name="delayIntervalMilliseconds">
        /// The delay between attemtps in milliseconds.
        /// </param>
        /// <returns>
        /// True if subscriber save succeeded, otherwise false.
        /// </returns>
        public static bool WaitForSubscriberSave(
            int maxAttempts,
            int delayIntervalMilliseconds)
        {
            bool returnValue = false;

            // get a reference to the summary wizard page
            Wizards.SummaryWindow summaryWizardWindow =
                new Wizards.SummaryWindow(
                    CoreManager.MomConsole,
                    Wizards.SummaryWindow.Strings.SubscriberWizardTitle);

            Core.Common.Utilities.LogMessage(
                "WaitForSubscriberSave::Waiting for wizard to finish saving Subscriber...");

            /* Wait for the results to indicate that the wizard is done.
             * The code checks the results label text for success or 
             * failure messages.  If neither message is present, the code
             * delays for two seconds.
             */
            bool doneSavingSubscriber = false;
            for (int currentAttempt = 0;
                 (currentAttempt < maxAttempts) &&
                 (doneSavingSubscriber == false);
                 currentAttempt++)
            {
                Core.Common.Utilities.LogMessage(
                    "WaitForSubscriberSave::Checking the results label, attempt " +
                    (currentAttempt + 1) +
                    " of " +
                    maxAttempts);

                if (summaryWizardWindow.Controls.ResultsStaticControl.Text.Contains(
                    Wizards.SummaryWindow.Strings.SubscriberSavedSuccessfully))
                {
                    Core.Common.Utilities.LogMessage(
                        "WaitForSubscriberSave::Subscriber saved successfully!");

                    doneSavingSubscriber = true;
                    returnValue = true;

                    break;
                }
                else
                {
                    // reformat Subscriber saved error message
                    string subscriberSaveFailedText =
                        String.Format(
                            Wizards.SummaryWindow.Strings.SubscriberSaveFailed,
                            String.Empty);

                    // check for failed save operation
                    if (summaryWizardWindow.Controls.ResultsStaticControl.Text.Contains(
                        subscriberSaveFailedText))
                    {
                        Core.Common.Utilities.LogMessage(
                            "WaitForSubscriberSave::Subscriber saved failed!");

                        doneSavingSubscriber = true;
                        returnValue = false;

                        break;
                    }
                }

                Core.Common.Utilities.LogMessage(
                    "WaitForSubscriberSave::Waiting for " +
                    (delayIntervalMilliseconds / Core.Common.Constants.OneSecond) +
                    " seconds...");

                // sleep for a two seconds
                Maui.Core.Utilities.Sleeper.Delay(
                    delayIntervalMilliseconds);
            }

            return returnValue;
        }

        /// <summary>
        /// Method to display the properties of an existing subscriber.  The 
        /// method takes the subscriber name and the display method as 
        /// parameters.
        /// </summary>
        /// <param name="subscriberName">
        /// The name of the subscriber.
        /// </param>
        /// <param name="displayPropertiesMethod">
        /// The method used to display the subscriber properties.  These 
        /// methods are defined in DisplayPropertiesAction.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if either parameter is null or
        /// empty string.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if method fails to find the 
        /// specified subscriber in the view, assumes channel name was incorrect.
        /// </exception>
        public static void DisplayProperties(
            string subscriberName,
            string displayPropertiesMethod)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(subscriberName))
            {
                throw new System.ArgumentNullException(
                    "Subscriber name parameter cannot be null or empty string!");
            }

            if (String.IsNullOrEmpty(displayPropertiesMethod))
            {
                throw new System.ArgumentNullException(
                    "Dispaly properties method parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Navigate to View and Select Item

            CommonSubscriber.NavigateToView(
                NavigationPane.Strings.AdminTreeViewRecipients);

            // refresh the view
            CoreManager.MomConsole.ViewPane.Grid.Click();
            CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                Core.Common.KeyboardCodes.F5);

            Core.Common.Utilities.LogMessage(
                "DisplayProperties::Selecting subscriber row with name := '" +
                subscriberName +
                "'");

            // select the subscriber in the grid view
            Maui.Core.WinControls.DataGridViewRow subscriberRow =
                CoreManager.MomConsole.ViewPane.Grid.FindData(
                    subscriberName);

            // check for valid row
            if (null == subscriberRow)
            {
                throw new System.ArgumentException(
                    "Failed to find the subscriber in the view with name := '" +
                    subscriberName +
                    "'");
            }

            Core.Common.Utilities.LogMessage(
                "DisplayProperties::Clicking the row...");

            // display the subscriber properties
            subscriberRow.AccessibleObject.Click();

            Core.Common.Utilities.LogMessage(
                "DisplayProperties::Waiting for the tooltip to disappear...");

            // wait for the tooltip to disappear
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.DefaultContextMenuTimeout);

            #endregion Navigate to View and Select Item

            #region Display Properties (Wizard)

            switch (displayPropertiesMethod)
            {
                case Constants.DisplayPropertiesAction.ViewContextMenu:
                    {
                        #region Right-Click Item, Select Properties Context Menu

                        subscriberRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using right-click, context menu...");

                        // right-click item, properties menu
                        subscriberRow.AccessibleObject.Click(
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
                            "DisplayProperties::Double-clicking subscriber row...");

                        // double-click subscriber
                        subscriberRow.AccessibleObject.Click(
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
                            NavigationPane.Strings.AdminTreeViewRecipients;

                        CoreManager.MomConsole.ActionsPane.ClickLink(
                            NavigationPane.WunderBarButton.Administration,
                            pathToView,
                            Core.Console.ActionsPane.Strings.ActionsPaneSubscriber,
                            actionsPaneLinkText);

                        #endregion Actions Pane Properties Link
                    }

                    break;
                case Constants.DisplayPropertiesAction.ViewEnterKey:
                    {
                        #region Left-Click Item, Press ENTER Key

                        // select item, press ENTER key
                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using left-click, SHIFT-F10...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        subscriberRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        subscriberRow.AccessibleObject.Window.SendKeys(
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
                        subscriberRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        subscriberRow.AccessibleObject.Window.SendKeys(
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

                        subscriberRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using right-click, context menu...");

                        // right-click item, properties menu
                        subscriberRow.AccessibleObject.Click(
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
        /// Method to delete a subscriber from the UI and confirm the deletion.
        /// </summary>
        /// <param name="subscriberName">
        /// The name of the subscriber.
        /// </param>
        /// <param name="deleteSubscriberMethod">
        /// The method used to delete the subscriber.  These are defined in the
        /// Constants.DeleteSubscriberActions class.
        /// </param>
        public static void DeleteSubscriber(
            string subscriberName,
            string deleteSubscriberMethod)
        {
            CommonSubscriber.DeleteSubscriber(
                subscriberName,
                deleteSubscriberMethod,
                true);
        }

        /// <summary>
        /// Method to delete a subscriber from the UI and confirm or cancel the
        /// deletion based on the specified value for confirmDeletion.
        /// </summary>
        /// <param name="subscriberName">
        /// The name of the subscriber.
        /// </param>
        /// <param name="deleteSubscriberMethod">
        /// The method used to delete the subscriber.  These are defined in the 
        /// Constants.DeleteSubscriberActions class.
        /// </param>
        /// <param name="confirmDeletion">
        /// Flag indicating if the deletion should be confirmed and committed.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if subscriber name or delete
        /// subscriber method parameters are null or empty string.
        /// </exception>
        /// /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if method fails to find the 
        /// specified subscriber in the view, assumes channel name was incorrect.
        /// </exception>
        public static void DeleteSubscriber(
            string subscriberName,
            string deleteSubscriberMethod,
            bool confirmDeletion)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(subscriberName))
            {
                throw new System.ArgumentNullException(
                    "Subscriber name parameter cannot be null or empty string!");
            }

            if (String.IsNullOrEmpty(deleteSubscriberMethod))
            {
                throw new System.ArgumentNullException(
                    "Delete subscriber method parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Select Subscriber

            CommonSubscriber.NavigateToView(
                NavigationPane.Strings.AdminTreeViewRecipients);

            // select the subscriber in the grid view
            int maxRetry = 10;
            Maui.Core.WinControls.DataGridViewRow subscriberRow = null;
            int loopNumber = 0;
            while (null == subscriberRow && loopNumber++ < maxRetry)
            {
                // refresh the view
                CoreManager.MomConsole.ViewPane.Grid.Click();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                // wait for the UI to settle
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

                Core.Common.Utilities.LogMessage(
                    "DeleteSubscriber::Selecting Subscriber row with name := '" +
                    subscriberName +
                    "'" +
                    " Retry times := " +
                    loopNumber);

                // select the channel in the grid view
                subscriberRow = CoreManager.MomConsole.ViewPane.Grid.FindData(
                    subscriberName);

                Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);
            }

            // check for valid row
            if (null == subscriberRow)
            {
                throw new System.ArgumentException(
                    "Failed to find the subscriber in the view with name := '" +
                    subscriberName +
                    "'");
            }

            Core.Common.Utilities.LogMessage(
                "DeleteSubscriber::Clicking the row...");

            // display the subscriber properties
            subscriberRow.AccessibleObject.Click();

            Core.Common.Utilities.LogMessage(
                "DeleteSubscriber::Waiting for the tooltip to disappear...");

            // wait for the tooltip to disappear
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.DefaultContextMenuTimeout);

            #endregion Select Subscriber

            #region Choose Delete Method

            Core.Common.Utilities.LogMessage(
                "DeleteSubscriber::Using deletion method := '" +
                deleteSubscriberMethod +
                "'");

            switch (deleteSubscriberMethod)
            {
                case Constants.DeleteSubscriberAction.ViewContextMenu:
                    {
                        #region Right-Click Item, Select Delete Context Menu

                        subscriberRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Using right-click, context menu...");

                        // right-click item, properties menu
                        subscriberRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Right-Click Item, Select Delete Context Menu
                    }

                    break;
                case Constants.DeleteSubscriberAction.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Properties Link

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Using link text := '" +
                            actionsPaneLinkText +
                            "'");

                        ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                        taskPane.ClickLink(
                            Core.Console.ActionsPane.Strings.ActionsPaneSubscriber,
                            actionsPaneLinkText);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Clicking actions pane link...");

                        #endregion Actions Pane Properties Link
                    }

                    break;
                case Constants.DeleteSubscriberAction.ViewShiftF10MenuHotKey:
                    {
                        #region Left-Click Item, SHIFT-F10, Select Delete Context Menu

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Using left-click, SHIFT-F10...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        subscriberRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        subscriberRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.ShiftF10);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Left-Click Item, SHIFT-F10, Select Delete Context Menu
                    }

                    break;
                case Constants.DeleteSubscriberAction.ViewDeleteKey:
                    {
                        #region Left-Click Item, Press DELETE Key

                        // select item, press ENTER key
                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Using left-click, DELETE...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        subscriberRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        subscriberRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.Delete);

                        #endregion Left-Click Item, Press DELETE Key
                    }

                    break;
                default:
                    {
                        #region Right-Click Item, Select Delete Context Menu

                        subscriberRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Using right-click, context menu...");

                        // right-click item, properties menu
                        subscriberRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscriber::Selecting context menu '" +
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
                "DeleteSubscriber::Confirm deletion := '" +
                confirmDeletion.ToString() +
                "'");

            // confirm the delete
            CoreManager.MomConsole.ConfirmChoiceDialog(
                confirmDeletion,
                CommonSubscriber.Strings.ConfirmSubscriberDeleteDialogTitle);

            // wait for the UI to settle
            CoreManager.MomConsole.Waiters.WaitForStatusReady(
                Core.Common.Constants.DefaultDialogTimeout);

            #endregion
        }

        /// <summary>
        /// Method to delete all subscriber from the UI and confirm or cancel the
        /// deletion based on the specified value for confirmDeletion.
        /// </summary>        
        /// <param name="confirmDeletion">
        /// Flag indicating if the deletion should be confirmed and committed.
        /// </param>        
        public static void DeleteAllSubscriber(
            bool confirmDeletion)
        {           

            #region Select Subscriber

            CommonSubscriber.NavigateToView(
                NavigationPane.Strings.AdminTreeViewRecipients);

            if (CoreManager.MomConsole.ViewPane.Grid.Rows.Count > 1)
            {
                // refresh the view
                Core.Common.Utilities.LogMessage(
                    "DeleteAllChannel::Refresh the view by 'F5'.");
                CoreManager.MomConsole.ViewPane.Grid.Click();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                // Select All Subscriber
                Core.Common.Utilities.LogMessage(
                    "DeleteAllChannel::Select all channels by 'Ctrl + a'.");
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.Ctrl + "a");

                // Delete All Subscriber
                Core.Common.Utilities.LogMessage(
                    "DeleteAllChannel::Delete all channels by Delete.");
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.Delete);

                #region Confirm Deletion

                Core.Common.Utilities.LogMessage(
                "DeleteSubscriber::Confirm deletion := '" +
                confirmDeletion.ToString() +
                "'");

                // confirm the delete
                CoreManager.MomConsole.ConfirmChoiceDialog(
                    confirmDeletion,
                    CommonSubscriber.Strings.ConfirmSubscriberDeleteDialogTitle);

                // wait for the UI to settle
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

                #endregion
            }
            #endregion                        
        }

        /// <summary>
        /// Method to determine if the specified subscriber exists.
        /// </summary>
        /// <param name="subscriberName">
        /// The name of the subscriber.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if subscriber name or delete
        /// subscriber method parameters are null or empty string.
        /// </exception>
        /// <returns>
        /// True if specified subscriber is found in the UI, otherwise false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if subscriber name is null or empty string.
        /// </exception>
        public static bool SubscriberExists(
            string subscriberName)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(subscriberName))
            {
                throw new System.ArgumentNullException(
                    "Subscriber name parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Select Subscriber

            Maui.Core.Keyboard.SendKeys(Mom.Test.UI.Core.Common.KeyboardCodes.F5);
            CommonSubscriber.NavigateToView(
                NavigationPane.Strings.AdminTreeViewRecipients);

            Core.Common.Utilities.LogMessage(
                "SubscriberExists::Looking for subscriber := '" +
                subscriberName +
                "'");

            int loopNum = 0;
            int maxRetry = 10;
            Maui.Core.WinControls.DataGridViewRow subscriberRow = null;

            // refresh the view
            CoreManager.MomConsole.ViewPane.Grid.Click();
            CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                Core.Common.KeyboardCodes.F5);
            // wait for the UI to settle
            CoreManager.MomConsole.Waiters.WaitForStatusReady(
                Core.Common.Constants.DefaultDialogTimeout);
            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();

            while (subscriberRow == null && loopNum++ < maxRetry)
            {
                                
                // select the subscriber in the grid view
                subscriberRow = CoreManager.MomConsole.ViewPane.Grid.FindData(
                    subscriberName);

                Core.Common.Utilities.LogMessage(
                    "SubscriberExists::Try to find subscriber := '" +
                    subscriberName +
                    "'" + 
                    "retry times :=" +
                    loopNum.ToString());

                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);
            }

            // check for valid row
            if (null == subscriberRow)
            {
                Core.Common.Utilities.LogMessage(
                    "SubscriberExists::No such subscriber exists.");

                return false;
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "SubscriberExists::Found subscriber.");

                return true;
            }

            #endregion Select Subscriber
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
            Maui.Core.WinControls.TreeNode specifiedViewNode =
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
        /// Resource strings class.
        /// </summary>
        public sealed class Strings
        {
            #region Resource Constants

            /// <summary>
            /// Contains resource string for: NewSubscriberContextMenu
            /// </summary>
            private const string ResourceNewSubscriberContextMenu =
                ";New..." + 
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";NewEllipsis";

            /// <summary>
            /// Contains the resource identifier for 
            /// ConfirmSubscriberDeleteDialogTitle
            /// </summary>
            private const string ResourceConfirmSubscriberDeleteDialogTitle =
                ";Confirm Subscriber Delete" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriberDeleteConfirmationTitle";

            #endregion

            #region Private Members

            /// <summary>
            /// Cached translated value for NewSubscriberContextMenu
            /// </summary>
            private static string cachedNewSubscriberContextMenu;

            /// <summary>
            /// Cached translated value for ConfirmSubscriberDeleteDialogTitle
            /// </summary>
            private static string cachedConfirmSubscriberDeleteDialogTitle;

            #endregion

            #region Public Properties

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewSubscriberContextMenu translated resource
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string NewSubscriberContextMenu
            {
                get
                {
                    if (cachedNewSubscriberContextMenu == null)
                    {
                        cachedNewSubscriberContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNewSubscriberContextMenu);
                    }

                    return cachedNewSubscriberContextMenu;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfirmSubscriberDeleteDialogTitle translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string ConfirmSubscriberDeleteDialogTitle
            {
                get
                {
                    if (cachedConfirmSubscriberDeleteDialogTitle == null)
                    {
                        cachedConfirmSubscriberDeleteDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceConfirmSubscriberDeleteDialogTitle);
                    }

                    return cachedConfirmSubscriberDeleteDialogTitle;
                }
            }

            #endregion
        }

        /// <summary>
        /// Class to contain constants for the channels
        /// </summary>
        public sealed class Constants
        {
            /// <summary>
            /// Maximum number of wait attempts for subscriber save operation.
            /// </summary>
            public const int MaxWaitAttemptsForSubscriberSave = 90;

            /// <summary>
            /// Delay interval between wait attempts for subscriber save 
            /// operation.
            /// </summary>
            public const int DelayIntervalForSubscriberSave = 2000;

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
            /// Class to contain constant values for var-map record StartPoint.
            /// </summary>
            public sealed class StartPoint
            {
                /// <summary>
                /// Constant for the value SubscriptionWizardSubscribersPage
                /// </summary>
                public const string SubscriptionWizardSubscribersPage = "SubscriptionWizardSubscribersPage";

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
                public const string ActionsPaneLinkMenu = "ActionsPaneLink";
            }

            /// <summary>
            /// Class to contain constant values for var-map record
            /// NameType.
            /// </summary>
            public sealed class NameType
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
            /// SetSubscriberIdMethod.
            /// </summary>
            public sealed class SetSubscriberIdMethod
            {
                /// <summary>
                /// Constant for the value Default
                /// </summary>
                public const string Default = "Default";

                /// <summary>
                /// Constant for the value TypeIn
                /// </summary>
                public const string TypeIn = "TypeIn";

                /// <summary>
                /// Constant for the value BrowseFor
                /// </summary>
                public const string BrowseFor = "BrowseFor";
            }

            /// <summary>
            /// Class to contain constant values for var-map record
            /// ChannelType.
            /// </summary>
            public sealed class ChannelType
            {
                /// <summary>
                /// Constant for the value Email
                /// </summary>
                public const string Email = "Email";

                /// <summary>
                /// Constant for the value InstantMessage
                /// </summary>
                public const string InstantMessage = "InstantMessage";

                /// <summary>
                /// Constant for the value ShortMessage
                /// </summary>
                public const string ShortMessage = "ShortMessage";

                /// <summary>
                /// Constant for the value Command
                /// </summary>
                public const string Command = "Command";
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
            /// DeleteSubscriberAction.
            /// </summary>
            public sealed class DeleteSubscriberAction
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
        }
    }
}
