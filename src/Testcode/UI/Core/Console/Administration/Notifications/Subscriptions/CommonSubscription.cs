// ----------------------------------------------------------------------------
// <copyright file="CommonSubscription.cs" company="Microsoft">
//  Copyright (c) Microsoft Corporation 2008
// </copyright>
// 
// <summary>
// Class to implement common test methods for the subscription tests.
// </summary>
// 
// <note>
// See the end of this source file for a detailed history
// </note>
// 
// <history>
//		[kellymor]  27-SEP-08   Created.
//      [KellyMor]  04-OCT-08   Updated StartWizard, DisplayProperties, and
//                              DeleteSubscriber to use new Actions pane
//                              "Subscription" group.
//                              Implemented SetSubscriptionName,
//                              WaitForSubscriptionSave, DisplayProperties, and
//                              DeleteSubscription.
//                              Added resource string for Delete confirmation
//                              dialog
//      [KellyMor]  07-OCT-08   Updated navigation code to use correct timeout
//      [KellyMor]  08-OCT-08   Changed StartPoint constant name and value for
//                              StartPoint.ActionsPaneLinkMenu to 
//                              StartPoint.ActionsPaneLink.
//                              Added stub implementation for SetCriteria.
//      [KellyMor]  09-OCT-08   Added private NavigateToView() method to add
//                              another layer of retry logic around the Core
//                              NavigationPane.SelectNode() method.  The new
//                              dynamic admin tree view updates/refreshes on
//                              every MP import, which happens every time a
//                              subscription is created, edited or deleted.
//      [KellyMor]  10-OCT-08   Initial implementation of AddSubscribers and
//                              AddChannels.
//                              Reliability fixes for AddChannels and
//                              AddSubscribers
//      [KellyMor]  11-OCT-08   Added another reliability fix to AddSubscribers
//                              and AddChannels to wait for the list of 
//                              available items to populate after a search
//                              completes.
//      [KellyMor]  16-OCT-08   Modified StartWizard to use new tree view
//                              context menu for new channel...
//      [KellyMor]  20-OCT-08   Initial implementation of SetCriteria
//      [KellyMor]  21-OCT-08   Added helper methods for 
//                              TranslateAlertCriteriaItem, 
//                              SelectAlertCriteriaItem,
//                              SetAlertCriteriaItemData,
//                              GetAlertCriteriaLabel, 
//                              SetAlertCriteriaDataInDialog,
//                              SearchForAlertDataItem, and
//                              SetTextBasedAlertDataItem.
//      [KellyMor]  22-OCT-08   Added helper methods for 
//                              SetCategoryBasedAlertDataItem and
//                              TranslateAlertCategoryItem.
//      [KellyMor]  23-OCT-08   Fixed bug in SelectAlertCriteriaItem.
//      [KellyMor]  24-OCT-08   Fixed bug in SetCategoryBasedAlertDataItem that
//                              didn't correctly check for the "Select All" 
//                              option.
//      [KellyMor]  27-OCT-08   Fixed an issue with the tooltip blocking the
//                              context menu when an item's description is
//                              longer than the grid cell in DisplayProperties
//                              and DeleteSubscription.
//      [KellyMor]  28-OCT-08   Added fix to default case for same context menu
//                              issue in DisplayProperties and DeleteChannel.
//                              Added support for random text data for alert
//                              text criteria.
//      [KellyMor]  30-OCT-08   Added constants class for Instances to contain
//                              values for instance types such as AgentComputer
// </history>
// 
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;
    using Mom.Test.UI.Core.Common;

    /// <summary>
    /// Class to implement the common methods for the subscription tests.
    /// </summary>
    public class CommonSubscription
    {

        #region Public Static Methods
        /// <summary>
        /// Method to start a subscription wizard from the specified start 
        /// point in the Administration space of the UI using the specified
        /// context menu item text or link.
        /// </summary>
        /// <param name="startPoint">
        /// The start point in the Administration UI.  Valid values are defined
        /// in the Constants.StartPoint class.
        /// </param>
        /// <param name="subscriptionMenuItemText">
        /// The context menu item text.  The same text is used for action pane
        /// links.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if the start point passed
        /// is not among the defined types in the Constants.StartPoint class.
        /// </exception>
        public static void StartWizard(
            string startPoint,
            string subscriptionMenuItemText)
        {
            CommonSubscription.StartWizard(startPoint,
                subscriptionMenuItemText,
                String.Empty,
                String.Empty);
        }
        /// <summary>
        /// Method to start a subscription wizard from the specified start 
        /// point in the Administration space of the UI using the specified
        /// context menu item text or link.
        /// </summary>
        /// <param name="startPoint">
        /// The start point in the Administration UI.  Valid values are defined
        /// in the Constants.StartPoint class.
        /// </param>
        /// <param name="subscriptionMenuItemText">
        /// The context menu item text.  The same text is used for action pane
        /// links.
        /// </param>
        /// <param name="alertSource">
        /// The item in the alert view, find it and call context menu to start wizard
        /// </param>
        /// <param name="alertSourceName">
        /// The item in the alert view, find it and call context menu to start wizard
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if the start point passed
        /// is not among the defined types in the Constants.StartPoint class.
        /// </exception>
        public static void StartWizard(
            string startPoint,
            string subscriptionMenuItemText,
            string alertSource,
            string alertSourceName)
        {
            StartWizard(startPoint, subscriptionMenuItemText, alertSource, alertSourceName, null);
        }

        /// <summary>
        /// Method to start a subscription wizard from the specified start 
        /// point in the Administration space of the UI using the specified
        /// context menu item text or link.
        /// </summary>
        /// <param name="startPoint">
        /// The start point in the Administration UI.  Valid values are defined
        /// in the Constants.StartPoint class.
        /// </param>
        /// <param name="subscriptionMenuItemText">
        /// The context menu item text.  The same text is used for action pane
        /// links.
        /// </param>
        /// <param name="alertSource">
        /// The item in the alert view, find it and call context menu to start wizard
        /// </param>
        /// <param name="alertSourceName">
        /// The item in the alert view, find it and call context menu to start wizard
        /// </param>
        /// <param name="alertPath">
        /// The item in the alert view, find it and call context menu to start wizard
        /// If no such item is specified, we can use RMS server, else use whatever the user supplied
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if the start point passed
        /// is not among the defined types in the Constants.StartPoint class.
        /// </exception>
        public static void StartWizard(
            string startPoint,
            string subscriptionMenuItemText,
            string alertSource,
            string alertSourceName,
            string alertPath)
        {
            // start the wizard from the specified start point
            switch (startPoint)
            {
                case Constants.StartPoint.ViewContextMenu:
                    {
                        #region View Pane Context Menu

                        CommonSubscription.NavigateToView(
                            NavigationPane.Strings.AdminTreeViewSubscriptions);

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
                            CommonSubscription.Strings.NewSubscriptionContextMenu +
                            "'");

                        // display subscribers sub-menu
                        contextMenu.ExecuteMenuItem(
                            CommonSubscription.Strings.NewSubscriptionContextMenu);

                        #endregion View Pane Context Menu
                    }

                    break;
                case Constants.StartPoint.TreeViewContextMenu:
                    {
                        #region Tree View Context Menu

                        // navigate to the 'Subscriptions' view
                        Maui.Core.WinControls.TreeNode subscribersViewNode =
                            CommonSubscription.NavigateToView(
                                NavigationPane.Strings.AdminTreeViewSubscriptions);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard:: Using shiftF10 to launch the context menu and then execute the context menu...");
                        CoreManager.MomConsole.ExecuteContextMenu(
                            NavigationPane.Strings.ContextMenuNewSubscription,
                            true);
                        Core.Common.Utilities.LogMessage(
                            "StartWizard:: Executed the context menu: " + NavigationPane.Strings.ContextMenuNewSubscription);
                        #endregion Tree View Context Menu
                    }

                    break;
                case Constants.StartPoint.ActionsPaneLink:
                    {
                        #region Actions Pane Links

                        CommonSubscription.NavigateToView(
                            NavigationPane.Strings.AdminTreeViewSubscriptions);

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                CommonSubscription.Strings.NewSubscriptionContextMenu);

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
                            NavigationPane.Strings.AdminTreeViewSubscriptions;

                        CoreManager.MomConsole.ActionsPane.ClickLink(
                            NavigationPane.WunderBarButton.Administration,
                            pathToView,
                            Core.Console.ActionsPane.Strings.ActionsPaneSubscription,
                            actionsPaneLinkText);

                        #endregion
                    }

                    break;
                case Constants.StartPoint.AlertViewContextMenu:
                    {
                        #region Alert View Context Menu (Notification Subscription->Create...)

                        #region Navigation to Monitoring->UI Test->Alerts
                        NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

                        Core.Common.Utilities.LogMessage("StartWizard:: Select Monitoring->UI Test->Alerts View");

                        // Select Alert View
                        navPane.SelectNode(
                            NavigationPane.Strings.Monitoring
                            + Core.Common.Constants.PathDelimiter
                            + Core.Common.Constants.UITestViewFolder
                            + Core.Common.Constants.PathDelimiter
                            + Core.Console.Views.Views.Strings.AlertView,
                            NavigationPane.NavigationTreeView.Monitoring);
                        #endregion

                        #region Verify alert exists during default heartbeat time 90 sec

                        Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                        Maui.Core.WinControls.DataGridViewRow row = null;

                        #region Check alert source, set find condition according to alert source

                        string source = null;

                        switch (alertSource)
                        {
                            case Constants.AlertSource.SpoolerMonitor:
                                {
                                    source = Constants.SpoolerService;

                                    //The path for SpoolerMonitor alert is Machine DNS name
                                    if (alertPath == null)
                                    {
                                        alertPath = Core.Common.Utilities.GetServerNameFqdn(Core.Common.Utilities.MomServerName);
                                    }
                                }
                                break;
                            case Constants.AlertSource.EventRule:
                                {
                                    if (alertPath == null)
                                    {
                                        source = Core.Common.Utilities.MomServerName;
                                    }
                                    else
                                    {
                                        source = alertPath;                                        
                                    }

                                    //The path for 998 EventRule alert is null in UI, so using resource string "(null)"
                                    alertPath = Strings.NullString;                                  
                                }
                                break;
                            default:
                                throw new System.ArgumentOutOfRangeException(
                                    "Unknown or undefined alert source" +
                                    alertSource + "");
                        }
                        #endregion

                        #region Try to find alert in the alert view and call context menu

                        int maxTries = 20;

                        if (viewGrid != null)
                        {
                            Core.Common.Utilities.LogMessage("StartWizard:: Found Alert View Grid");

                            int attempt = 0;
                            while ((row == null) && (attempt < maxTries))
                            {
                                Core.Common.Utilities.LogMessage("StartWizard:: Try to found alert, Source= " + source);
                                row = viewGrid.FindInstanceRow(
                                Core.Console.Views.Alerts.AlertsView.Strings.SourceColumnTitle,
                                Core.Console.Views.Alerts.AlertsView.Strings.AlertNameColumnTitle,
                                Core.Console.Views.Alerts.AlertsView.Strings.AlertPathColumnTitle,
                                source,
                                TranslateAlertCategoryItem(alertSourceName),
                                alertPath,
                                2);
                                                               
                                if (row != null)
                                {
                                    Core.Common.Utilities.LogMessage("StartWizard :: " +
                                       "Find New alert of the machine specified");

                                    #region Call out Context menu and click Notification Subscription->Create...

                                    Core.Common.Utilities.LogMessage(
                                        "StartWizard::Using left-click, SHIFT-F10...");
                                    if(!Core.Console.MomControls.GridControl.CellVisible(row.Cells[0].AccessibleObject))
                                 
                                     // scroll to row
                                    { viewGrid.ScrollToRow(row.AccessibleObject.Index);}

                                    // left-click item
                                    row.AccessibleObject.Click(
                                        MouseFlags.LeftButton);

                                    //Use shift+F10 to launch and execute context menu
                                    CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Alerts.AlertsView.Strings.NotificationsContextMenu + 
                                        UI.Core.Common.Constants.PathDelimiter + 
                                        Core.Console.Views.Alerts.AlertsView.Strings.CreateSubscriptionContextMenu, 
                                        true);

                                    #endregion

                                    break;
                                }
                                else
                                {
                                    Core.Common.Utilities.LogMessage("StartWizard :: " +
                                       "Didn't find New alert of the machine specified");

                                    attempt++;
                                    viewGrid.SendKeys(Core.Common.KeyboardCodes.F5);
                                    CoreManager.MomConsole.Waiters.WaitForReady();
                                    Core.Common.Utilities.LogMessage("StartWizard :: Attempt Number " +
                                        attempt.ToString());

                                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 9);
                                }
                            }
                        }
                        #endregion

                        #endregion

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
        /// <param name="name">
        /// The text for the name.  The channel name can also be
        /// one of the constants defined in Constants.ChannelNameType.
        /// This will cause the method to generate a name and description based
        /// on the type specified.
        /// </param>
        /// <param name="description">
        /// The description of the subscription.  Optional:  may be null or 
        /// empty string.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throw System.ArgumentNullException if the subscription name is null
        /// or emtpy string.
        /// </exception>
        public static void SetSubscriptionName(
            string name,
            string description)
        {
            CommonSubscription.SetSubscriptionName(
                name,
                description,
                false);
        }

        /// <summary>
        /// Method to set the subscriber name text.  The method reference to a 
        /// NameAndDescriptionWindow and the specified text for the name and 
        /// description.
        /// </summary>
        /// <param name="name">
        /// The text for the name.  The channel name can also be
        /// one of the constants defined in Constants.ChannelNameType.
        /// This will cause the method to generate a name and description based
        /// on the type specified.
        /// </param>
        /// <param name="description">
        /// The description of the subscription.  Optional:  may be null or 
        /// empty string.
        /// </param>
        /// <param name="editExisting">
        /// Flag indicating if this is occuring on a new subscription or an
        /// existing one.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throw System.ArgumentNullException if the subscription name is null
        /// or emtpy string.
        /// </exception>
        public static void SetSubscriptionName(
            string name,
            string description,
            bool editExisting)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new System.ArgumentNullException(
                    "Subscription name parameter must not be null or empty string!");
            }

            if (null == description)
            {
                description = String.Empty;
            }

            // reference to the name and description wizard window
            Wizards.NameAndDescriptionWindow subscriptionNameWindow =
                new Wizards.NameAndDescriptionWindow(
                    CoreManager.MomConsole, editExisting);

            #region Generate the Subscription Name and Description

            // generate the channel name
            string generatedSubscriptionName = null;
            string generatedSubscriptionDescription = null;

            switch (name)
            {
                case Constants.NameType.Default:
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetSubscriptionName::Using default name...");

                        #region Create Default Subscription Name and Description

                        generatedSubscriptionName =
                            System.Environment.UserName +
                            " " +
                            ActionsPane.Strings.ActionsPaneSubscription +
                            " " +
                            System.DateTime.Now.ToString();

                        generatedSubscriptionDescription =
                            generatedSubscriptionName +
                            " " +
                            Wizards.NameAndDescriptionWindow.Strings.NavigationLinkDescription;

                        #endregion Create Default Subscription Name and Description
                    }

                    break;
                case Constants.NameType.RandomShort:
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetSubscriptionName::Using Random Short name...");

                        // generate a short random name and description
                        generatedSubscriptionName =
                            Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                Constants.NameShortLength);
                        generatedSubscriptionDescription =
                            Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                Constants.DescriptionShortLength);
                    }

                    break;
                case Constants.NameType.RandomLong:
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetSubscriptionName::Using Random Long name...");

                        // generate a long random name and description
                        generatedSubscriptionName =
                            Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                Constants.NameMaxLength);
                        generatedSubscriptionDescription =
                            Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                Constants.DescriptionMaxLength);
                    }

                    break;
                case Constants.NameType.MinLength:
                    {
                        #region Minimum Length Name and Description

                        Core.Common.Utilities.LogMessage(
                            "SetSubscriptionName::Using Minimum Length name...");

                        // generate shortest, valid name and description
                        generatedSubscriptionName =
                            Administration.Notifications.Channels.CommonChannel.GenerateRandomString(1);

                        // verify that the name isn't composed of whitespace
                        if (generatedSubscriptionName.Trim().Equals(String.Empty))
                        {
                            // regenerate the string
                            generatedSubscriptionName =
                                Administration.Notifications.Channels.CommonChannel.GenerateRandomString(1);

                            // check for whitespace again
                            if (generatedSubscriptionName.Trim().Equals(String.Empty))
                            {
                                // use a simple character
                                generatedSubscriptionName = "X";
                            }
                        }

                        generatedSubscriptionDescription = String.Empty;

                        #endregion Minimum Length Name and Description
                    }

                    break;
                case Constants.NameType.MaxLength:
                    {
                        #region Max Length Name and Description

                        Core.Common.Utilities.LogMessage(
                            "SetSubscriptionName::Using Maximum Length name...");

                        // generate a maximum length random name
                        generatedSubscriptionName =
                            Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                Constants.NameMaxLength);

                        // if the generated string is not at the max length
                        if (Constants.NameMaxLength >
                            generatedSubscriptionName.Length)
                        {
                            // pad the remaining length
                            generatedSubscriptionName.PadRight(
                                Constants.NameMaxLength,
                                'X');
                        }

                        // generate a maximum length random description
                        generatedSubscriptionDescription =
                            Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                Constants.DescriptionMaxLength);

                        // if the generated string is not at the max length
                        if (Constants.DescriptionMaxLength >
                            generatedSubscriptionDescription.Length)
                        {
                            // pad the remaining length
                            generatedSubscriptionDescription.PadRight(
                                Constants.DescriptionMaxLength,
                                'X');
                        }

                        #endregion Max Length Name and Description
                    }

                    break;
                default:
                    {
                        Core.Common.Utilities.LogMessage(
                            "SetSubscriptionName::Using Subscription Parameters defined name...");

                        // use the name passed as parameters 
                        generatedSubscriptionName =
                            name;
                        generatedSubscriptionDescription =
                            description;
                    }

                    break;
            }

            Core.Common.Utilities.LogMessage(
                "SetSubscriptionName::Generated name for subscription := '" +
                    generatedSubscriptionName +
                    "'");
            Core.Common.Utilities.LogMessage(
                "SetSubscriptionName::Generated description for subscription := '" +
                    generatedSubscriptionDescription +
                    "'");

            #endregion Generate the Channel Name and Description

            Core.Common.Utilities.LogMessage(
                "SetNameAndDescription::Setting subscription name and description...");

            // set the name and description
            subscriptionNameWindow.SubscriptionNameText =
                generatedSubscriptionName;

            subscriptionNameWindow.DescriptionText =
                generatedSubscriptionDescription;
        }

        /// <summary>
        /// Method to set matching alert criteria in the current
        /// subscription.
        /// </summary>
        /// <param name="alertCriteria">
        /// A collection of name/value pairs specifying the name of the
        /// alert criteria to select and the values used.  The name or key
        /// is one of the constant values from Constants.AlertCriteriaRecords.
        /// The value is a text string representing text, date/times, or 
        /// numeric values used for category-based items like severity or
        /// resolution state.
        /// </param>
        /// <param name="editExisting">
        /// A flag indicating if this is editing existing criteria.
        /// </param>
        /// <returns>String The alert criteria data</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throw System.ArgumentNullException if the criteria name/value is null
        /// or emtpy string.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throw System.ArgumentNullException if the criteria name/value is null
        /// or emtpy string.
        /// </exception>
        public static string SetCriteria(
            IDictionary<string, string> alertCriteria,
            bool editExisting)
        {
            string returnValue = string.Empty;

            if (null == alertCriteria)
            {
                throw new System.ArgumentNullException(
                    "The collection of alert criteria name/value pairs must not be null!");
            }

            if (0 == alertCriteria.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                    "The collection of alert criteria name/value pairs must not be empty!");
            }

            // get a reference to the subscription criteria window
            Wizards.SubscriptionCriteriaWindow criteriaWindow =
                new Wizards.SubscriptionCriteriaWindow(
                    CoreManager.MomConsole,
                    editExisting);

            foreach (string alertCriteriaItem in alertCriteria.Keys)
            {
                // select the alert criteria item in the first list
                CommonSubscription.SelectAlertCriteriaItem(
                    alertCriteriaItem,
                    criteriaWindow);

                // set the alert criteria data in the second list
                returnValue= CommonSubscription.SetAlertCriteriaItemData(
                    alertCriteriaItem,
                    alertCriteria[alertCriteriaItem],
                    criteriaWindow);
            }
            return returnValue;
        }

        /// <summary>
        /// Method to verify matching alert criteria in the current
        /// subscription.
        /// </summary>
        /// <param name="alertCriteria">
        /// A collection of name/value pairs specifying the name of the
        /// alert criteria to select and the values used.  The name or key
        /// is one of the constant values from Constants.AlertCriteriaRecords.
        /// The value is a text string representing text, date/times, or 
        /// numeric values used for category-based items like severity or
        /// resolution state.
        /// </param>
        /// <param name="editExisting">
        /// A flag indicating if this is editing existing criteria.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throw System.ArgumentNullException if the alertCriteria is null
        /// or empty string.
        /// </exception>        
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if alertCriteria Count is 0.
        /// </exception>
        public static bool VerifyCriteria(
            IDictionary<string, string> alertCriteria,
            bool editExisting)
        {
            bool retValue = false;

            if (null == alertCriteria)
            {
                throw new System.ArgumentNullException(
                    "The collection of alert criteria name/value pairs must not be null!");
            }

            if (0 == alertCriteria.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                    "The collection of alert criteria name/value pairs must not be empty!");
            }

            // get a reference to the subscription criteria window
            Wizards.SubscriptionCriteriaWindow criteriaWindow =
                new Wizards.SubscriptionCriteriaWindow(
                    CoreManager.MomConsole,
                    editExisting);

            foreach (string alertCriteriaItem in alertCriteria.Keys)
            {
                // verify the selected alert criteria item in the first list
                retValue = CommonSubscription.VerifySelectedAlertCriteriaItem(
                    alertCriteriaItem,
                    criteriaWindow);

                if (retValue == false)
                {
                    break;
                }
            }

            return retValue;
        }

        /// <summary>
        /// Add the specified subscriber to the current subscription.
        /// </summary>
        /// <param name="specifiedSubscribers">
        /// A typed list containing the specified subscribers to add to the
        /// current subscription.
        /// </param>
        public static void AddSubscribers(
            List<Subscribers.SubscriberParams> specifiedSubscribers)
        {
            if (null == specifiedSubscribers)
            {
                throw new System.ArgumentNullException(
                    "Collection of specified subscribers must not be null!");
            }

            if (0 == specifiedSubscribers.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                    "Collection of specified subscribers must not be empty!");
            }

            Core.Common.Utilities.LogMessage(
                "AddSubscribers...");

            // reference to the name and description wizard window
            Wizards.SubscribersWindow subscribersWindow = null;

            // reference to the Subscibers (Object) Picker Dialog
            Wizards.AlertCriteria.SubscriberSearchDialog subscriberSearchDialog = null;

            #region Get Wizard Window

            Core.Common.Utilities.LogMessage(
                "AddSubscribers::Getting a new reference...");

            // get a new reference
            subscribersWindow =
                new Wizards.SubscribersWindow(
                    CoreManager.MomConsole, false);
            UISynchronization.WaitForUIObjectReady(
                subscribersWindow,
                Core.Common.Constants.DefaultDialogTimeout);

            #endregion Get Wizard Window

            #region Searching and Adding Subscribers

            #region Searching For Subscriber

            Core.Common.Utilities.LogMessage(
                "AddSubscribers::Selecting subscribers...");

            // Click "Choose"
            subscribersWindow.ClickChoose();

            Core.Common.Utilities.LogMessage(
                "AddSubscribers::Starting the Subscribers Search dialog...");

            // Look for the Subscibers (Object) Picker Dialog
            subscriberSearchDialog =
                new Wizards.AlertCriteria.SubscriberSearchDialog(
                    CoreManager.MomConsole);
            UISynchronization.WaitForUIObjectReady(
                subscriberSearchDialog,
                Core.Common.Constants.DefaultDialogTimeout);

            Core.Common.Utilities.LogMessage(
                "AddSubscribers::Searching for all available subscribers...");

            // click "Search"
            subscriberSearchDialog.ClickSearch();

            // delay for one second to allow search to start
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);

            Core.Common.Utilities.LogMessage(
                "AddSubscribers::Waiting for search to complete...");

            // wait for the search to complete
            subscriberSearchDialog.WaitForSearchResults(
                Core.Console.Administration.PickerDialogBase.MaxSearchWaitTime);

            Core.Common.Utilities.LogMessage(
                "AddSubscribers::Search complete.");

            // delay for one second to allow the list view to populate
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);

            #endregion Searching For Subscriber

            #region Adding Subscribers

            // wait for list view to populate
            const int MaxAttempts = 10;
            for (int currentAttempt = 0;
                ((currentAttempt < MaxAttempts) && (0 >= subscriberSearchDialog.Controls.AvailableItemsListView.Count));
                currentAttempt++)
            {
                // log the attempt
                Core.Common.Utilities.LogMessage(
                    "AddSubscribers::Checking list view count, attempt " +
                    currentAttempt +
                    " of " +
                    MaxAttempts);

                // delay
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);
            }

            if (subscriberSearchDialog.Controls.AvailableItemsListView.Count > 0)
            {
                #region Match Specified Subscribers to Available Subscribers

                Core.Common.Utilities.LogMessage(
                    "AddSubscribers::Selecting subscribers...");

                // iterate over the list of specified subscribers
                foreach (Subscribers.SubscriberParams currentSubscriber in
                    specifiedSubscribers)
                {
                    // get the name/ID of the subscriber
                    Core.Common.Utilities.LogMessage(
                        "AddSubscribers::Looking for subscriber := '" +
                        currentSubscriber.SubscriberId +
                        "'");

                    // iterate over the list of available subscribers
                    foreach (Maui.Core.WinControls.ListViewItem availableSubscriber in
                        subscriberSearchDialog.Controls.AvailableItemsListView.Items)
                    {
                        // select the available subscriber
                        availableSubscriber.Click();
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        Core.Common.Utilities.LogMessage(
                            "AddSubscribers::Currently selected subscriber := '" +
                            availableSubscriber.Text +
                            "'");

                        string subscriberDetails = null;

                        // get the subscriber details
                        foreach (Maui.Core.WinControls.ListViewSubItem details in
                            availableSubscriber.SubItems)
                        {
                            // log the items
                            Core.Common.Utilities.LogMessage(
                                "AddSubscribers::Subscriber details := '" +
                                details.Text +
                                "'");

                            subscriberDetails = subscriberDetails + ", ";
                        }

                        // check to see if the subscriber ID matches the available subscriber
                        if (availableSubscriber.Text.Contains(currentSubscriber.SubscriberId))
                        {
                            // find the subscriber in the list
                            Core.Common.Utilities.LogMessage(
                                "AddSubscribers::Adding subscriber, '" +
                                currentSubscriber.SubscriberId +
                                "', to selected list...");

                            // click "Add"
                            subscriberSearchDialog.ClickAdd();
                            Maui.Core.Utilities.Sleeper.Delay(
                                Core.Common.Constants.OneSecond);
                        }                        
                    }
                }

                #endregion Match Specified Subscribers to Available Subscribers

                Core.Common.Utilities.LogMessage(
                    "AddSubscribers::Closing search dialog...");

                // click OK
                subscriberSearchDialog.ClickOK();
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                // drop the reference
                subscriberSearchDialog = null;
            }
            else
            {
                // close the search dialog
                subscriberSearchDialog.ClickTitleBarClose();
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                // drop the reference
                subscriberSearchDialog = null;

                throw new Exception(
                    "Failed to find any subscribers in the search dialog!");
            }

            #endregion Adding Subscribers

            #endregion Searching and Adding Subscribers
        }

        /// <summary>
        /// Add the specified channel to the current subscription.
        /// </summary>
        /// <param name="specifiedChannelNames">
        /// A typed list containing the names of the channels to add to the
        /// current subscription.
        /// </param>
        public static void AddChannels(
            List<string> specifiedChannelNames)
        {
            if (null == specifiedChannelNames)
            {
                throw new System.ArgumentNullException(
                    "Collection of specified channel names must not be null!");
            }

            if (0 == specifiedChannelNames.Count)
            {
                throw new System.ArgumentOutOfRangeException(
                    "Collection of specified channel names must not be empty!");
            }

            Core.Common.Utilities.LogMessage(
                "AddChannels...");

            // reference to the name and description wizard window
            Wizards.ChannelsWindow channelsWindow = null;

            // reference to the Channels (Object) Picker Dialog
            Wizards.AlertCriteria.ChannelSearchDialog channelSearchDialog = null;

            #region Get Wizard Window

            Core.Common.Utilities.LogMessage(
                "AddChannels::Getting a new reference...");

            // get a new reference
            channelsWindow =
                new Wizards.ChannelsWindow(
                    CoreManager.MomConsole, false);
            UISynchronization.WaitForUIObjectReady(
                channelsWindow,
                Core.Common.Constants.DefaultDialogTimeout);

            #endregion Get Wizard Window

            #region Searching and Adding Channels

            #region Searching Channels

            Core.Common.Utilities.LogMessage(
                "AddChannels::Selecting channels...");

            // Click "Choose"
            channelsWindow.ClickChoose();

            Core.Common.Utilities.LogMessage(
                "AddChannels::Starting the Channels Search dialog...");

            // Look for the Channels (Object) Picker Dialog
            channelSearchDialog =
                new Wizards.AlertCriteria.ChannelSearchDialog(
                    CoreManager.MomConsole);
            UISynchronization.WaitForUIObjectReady(
                channelSearchDialog,
                Core.Common.Constants.DefaultDialogTimeout);

            Core.Common.Utilities.LogMessage(
                "AddChannels::Searching for all available channels...");

            // click "Search"
            channelSearchDialog.ClickSearch();

            // wait for the search to complete
            channelSearchDialog.WaitForSearchResults(
                Core.Console.Administration.PickerDialogBase.MaxSearchWaitTime);

            // delay for one second to allow the list view to populate
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.OneSecond);

            #endregion Searching Channels

            #region Adding Channels

            // wait for list view to populate
            const int MaxAttempts = 10;
            for (int currentAttempt = 0;
                ((currentAttempt < MaxAttempts) && 
                (0 >= channelSearchDialog.Controls.AvailableItemsListView.Count));
                currentAttempt++)
            {
                // log the attempt
                Core.Common.Utilities.LogMessage(
                    "AddChannels::Checking list view count, attempt " +
                    currentAttempt +
                    " of " +
                    MaxAttempts);

                // delay
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);
            }

            if (channelSearchDialog.Controls.AvailableItemsListView.Count > 0)
            {
                #region Match Specified Channels to Available Channels

                Core.Common.Utilities.LogMessage(
                    "AddChannels::Selecting channels...");

                // iterate over the list of specified channels
                foreach (string currentChannel in
                    specifiedChannelNames)
                {
                    // get the name/ID of the channel
                    Core.Common.Utilities.LogMessage(
                        "AddChannels::Looking for channel := '" +
                        currentChannel +
                        "'");

                    // iterate over the list of available channels
                    foreach (Maui.Core.WinControls.ListViewItem availableChannel in
                        channelSearchDialog.Controls.AvailableItemsListView.Items)
                    {
                        // select the available channel
                        availableChannel.Click();
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        Core.Common.Utilities.LogMessage(
                            "AddChannels::Currently selected channel := '" +
                            availableChannel.Text +
                            "'");

                        string channelDetails = null;

                        // get the channel details
                        foreach (Maui.Core.WinControls.ListViewSubItem details in
                            availableChannel.SubItems)
                        {
                            // log the items
                            Core.Common.Utilities.LogMessage(
                                "AddChannels::Channel details := '" +
                                details.Text +
                                "'");

                            channelDetails = channelDetails + ", ";
                        }

                        // check to see if the channel name matches the available channel
                        if (availableChannel.Text.Contains(currentChannel))
                        {
                            // find the channel in the list
                            Core.Common.Utilities.LogMessage(
                                "AddChannels::Adding channel, '" +
                                currentChannel +
                                "', to selected list...");

                            // click "Add"
                            channelSearchDialog.ClickAdd();
                            Maui.Core.Utilities.Sleeper.Delay(
                                Core.Common.Constants.OneSecond);
                        }
                    }
                }

                #endregion Match Specified Channels to Available Channels

                Core.Common.Utilities.LogMessage(
                    "AddChannels::Closing search dialog...");

                // click OK
                channelSearchDialog.ClickOK();
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                // drop the reference
                channelSearchDialog = null;
            }
            else
            {
                // close the search dialog
                channelSearchDialog.ClickTitleBarClose();
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                // drop the reference
                channelSearchDialog = null;

                throw new System.ArgumentException(
                    "Failed to find any channels in the search dialog!");
            }

            #endregion Adding Channels

            #endregion Searching and Adding Channels
        }
        
        /// <summary>
        /// Method to wait for the wizard to finish saving the newly created
        /// subscription.  The method looks for the Summary Wizard window 
        /// specified by the caller and makes 30 attempts with a 2 second delay
        /// between attempts.
        /// </summary>
        /// <param name="editExisting">
        /// Flag indicating if this is occuring on a new subscription or an
        /// existing one.
        /// </param>
        /// <returns>
        /// True if subscription save was successful otherwise returns false.
        /// </returns>
        public static bool WaitForSubscriptionSave(bool editExisting)
        {
            return CommonSubscription.WaitForSubscriptionSave(
                Constants.MaxWaitAttemptsForSubscriptionSave,
                Constants.DelayIntervalForSubscriptionSave,
                editExisting);
        }

        /// <summary>
        /// Method to wait for the wizard to finish saving the newly created
        /// subscription.  The method looks for the Summary Wizard window 
        /// specified by the caller and makes the specified number of attemtps 
        /// with a short, specified delay.
        /// </summary>
        /// <param name="maxAttempts">
        /// The maximum number of attemtps to make.
        /// </param>
        /// <param name="delayIntervalMilliseconds">
        /// The delay between attemtps in milliseconds.
        /// </param>
        /// <param name="editExisting">
        /// Flag indicating if this is occuring on a new subscription or an
        /// existing one.
        /// </param>
        /// <returns>
        /// True if subscription save succeeded, otherwise false.
        /// </returns>
        public static bool WaitForSubscriptionSave(
            int maxAttempts,
            int delayIntervalMilliseconds,
            bool editExisting)
        {
            bool returnValue = false;

            // get a reference to the summary wizard page
            Wizards.SummaryWindow summaryWizardWindow =
                new Wizards.SummaryWindow(
                    CoreManager.MomConsole,
                    editExisting);

            Core.Common.Utilities.LogMessage(
                "WaitForSubscriptionSave::Waiting for wizard to finish saving Subscriber...");

            /* Wait for the results to indicate that the wizard is done.
             * The code checks the results label text for success or 
             * failure messages.  If neither message is present, the code
             * delays for two seconds.
             */
            bool doneSavingSubscription = false;
            for (int currentAttempt = 0;
                 (currentAttempt < maxAttempts) &&
                 (doneSavingSubscription == false);
                 currentAttempt++)
            {
                Core.Common.Utilities.LogMessage(
                    "WaitForSubscriptionSave::Checking the results label, attempt " +
                    (currentAttempt + 1) +
                    " of " +
                    maxAttempts);
                if (null != summaryWizardWindow.Controls.ResultsStaticControl)
                {
                    if (summaryWizardWindow.Controls.ResultsStaticControl.Text.Contains(
                        Wizards.SummaryWindow.Strings.SubscriptionSavedSuccessfully))
                    {
                        Core.Common.Utilities.LogMessage(
                            "WaitForSubscriptionSave::Subscription saved successfully!");

                        doneSavingSubscription = true;
                        returnValue = true;

                        break;
                    }
                    else
                    {
                        // reformat Subscriber saved error message
                        string subscriptionSaveFailedText =
                            String.Format(
                                Wizards.SummaryWindow.Strings.SubscriptionSaveFailed,
                                String.Empty);

                        // check for failed save operation
                        if (summaryWizardWindow.Controls.ResultsStaticControl.Text.Contains(
                            subscriptionSaveFailedText))
                        {
                            Core.Common.Utilities.LogMessage(
                                "WaitForSubscriptionSave::Subscription saved failed!");

                            doneSavingSubscription = true;
                            returnValue = false;

                            break;
                        }
                    }
                }

                Core.Common.Utilities.LogMessage(
                    "WaitForSubscriptionSave::Waiting for " +
                    (delayIntervalMilliseconds / Core.Common.Constants.OneSecond) +
                    " seconds...");

                // sleep for a two seconds
                Maui.Core.Utilities.Sleeper.Delay(
                    delayIntervalMilliseconds);
            }

            return returnValue;
        }

        /// <summary>
        /// Method to display the properties of an existing subscription.  The 
        /// method takes the subscriber name and the display method as 
        /// parameters.
        /// </summary>
        /// <param name="subscriptionName">
        /// The name of the subscription.
        /// </param>
        /// <param name="displayPropertiesMethod">
        /// The method used to display the subscription properties.  These 
        /// methods are defined in DisplayPropertiesAction.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if either parameter is null or
        /// empty string.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if method fails to find the 
        /// specified subscription in the view, assumes subscription name was 
        /// incorrect.
        /// </exception>
        public static void DisplayProperties(
            string subscriptionName,
            string displayPropertiesMethod)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(subscriptionName))
            {
                throw new System.ArgumentNullException(
                    "Subscription name parameter cannot be null or empty string!");
            }

            if (String.IsNullOrEmpty(displayPropertiesMethod))
            {
                throw new System.ArgumentNullException(
                    "Dispaly properties method parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Navigate to View and Select Item

            CommonSubscription.NavigateToView(
                NavigationPane.Strings.AdminTreeViewSubscriptions);

            // refresh the view
            CoreManager.MomConsole.ViewPane.Grid.Click();
            CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                Core.Common.KeyboardCodes.F5);

            Core.Common.Utilities.LogMessage(
                "DisplayProperties::Selecting subscription row with name := '" +
                subscriptionName +
                "'");

            // select the subscriber in the grid view
            Maui.Core.WinControls.DataGridViewRow subscriptionRow =
                CoreManager.MomConsole.ViewPane.Grid.FindData(
                    subscriptionName);

            // check for valid row
            if (null == subscriptionRow)
            {
                throw new System.ArgumentException(
                    "Failed to find the subscriber in the view with name := '" +
                    subscriptionName +
                    "'");
            }

            Core.Common.Utilities.LogMessage(
                "DisplayProperties::Clicking the row...");

            // display the subscriber properties
            subscriptionRow.AccessibleObject.Click();

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

                        subscriptionRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using right-click, context menu...");

                        // right-click item, properties menu
                        subscriptionRow.AccessibleObject.Click(
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
                        subscriptionRow.AccessibleObject.Click(
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
                            NavigationPane.Strings.AdminTreeViewSubscriptions;

                        CoreManager.MomConsole.ActionsPane.ClickLink(
                            NavigationPane.WunderBarButton.Administration,
                            pathToView,
                            Core.Console.ActionsPane.Strings.ActionsPaneSubscription,
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
                        subscriptionRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        subscriptionRow.AccessibleObject.Window.SendKeys(
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
                        subscriptionRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        subscriptionRow.AccessibleObject.Window.SendKeys(
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

                        subscriptionRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DisplayProperties::Using right-click, context menu...");

                        // right-click item, properties menu
                        subscriptionRow.AccessibleObject.Click(
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
        /// Method to delete a subscription from the UI and confirm the 
        /// deletion.
        /// </summary>
        /// <param name="subscriptionName">
        /// The name of the subscription.
        /// </param>
        /// <param name="deleteSubscriptionMethod">
        /// The method used to delete the subscription.  These are defined in 
        /// the Constants.DeleteSubscriptionActions class.
        /// </param>
        public static void DeleteSubscription(
            string subscriptionName,
            string deleteSubscriptionMethod)
        {
            CommonSubscription.DeleteSubscription(
                subscriptionName,
                deleteSubscriptionMethod,
                true);
        }

        /// <summary>
        /// Method to delete a subscription from the UI and confirm or cancel 
        /// the deletion based on the specified value for confirmDeletion.
        /// </summary>
        /// <param name="subscriptionName">
        /// The name of the subscription.
        /// </param>
        /// <param name="deleteSubscriptionMethod">
        /// The method used to delete the subscription.  These are defined in 
        /// the Constants.DeleteSubscriberActions class.
        /// </param>
        /// <param name="confirmDeletion">
        /// Flag indicating if the deletion should be confirmed and committed.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if channel name or delete
        /// subscription method parameters are null or empty string.
        /// </exception>
        /// /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if method fails to find the 
        /// specified subscription in the view, assumes channel name was 
        /// incorrect.
        /// </exception>
        public static void DeleteSubscription(
            string subscriptionName,
            string deleteSubscriptionMethod,
            bool confirmDeletion)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(subscriptionName))
            {
                throw new System.ArgumentNullException(
                    "Subscriber name parameter cannot be null or empty string!");
            }

            if (String.IsNullOrEmpty(deleteSubscriptionMethod))
            {
                throw new System.ArgumentNullException(
                    "Delete subscriber method parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Select Subscription

            CommonSubscription.NavigateToView(
                NavigationPane.Strings.AdminTreeViewSubscriptions);

            int maxRetry = 10;
            Maui.Core.WinControls.DataGridViewRow subscriptionRow = null;
            int loopNumber = 0;
            while (null == subscriptionRow && loopNumber++ < maxRetry)
            {
                // refresh the view
                CoreManager.MomConsole.ViewPane.Grid.Click();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                Core.Common.Utilities.LogMessage(
                    "VerifySubscription::Selecting subscription row with name := '" +
                    subscriptionName +
                    "'" +
                    " Retry times := " +
                    loopNumber);

                // select the subscriber in the grid view
                subscriptionRow = CoreManager.MomConsole.ViewPane.Grid.FindData(
                        subscriptionName);

                Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);
            }

            // check for valid row
            if (null == subscriptionRow)
            {
                throw new System.ArgumentException(
                    "Failed to find the subscriber in the view with name := '" +
                    subscriptionName +
                    "'");
            }

            Core.Common.Utilities.LogMessage(
                "DeleteSubscription::Clicking the row...");

            // display the subscriber properties
            subscriptionRow.AccessibleObject.Click();

            Core.Common.Utilities.LogMessage(
                "DeleteSubscription::Waiting for the tooltip to disappear...");

            // wait for the tooltip to disappear
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.DefaultContextMenuTimeout);

            #endregion Select Subscription

            #region Choose Delete Method

            Core.Common.Utilities.LogMessage(
                "DeleteSubscription::Using deletion method := '" +
                deleteSubscriptionMethod +
                "'");

            switch (deleteSubscriptionMethod)
            {
                case Constants.DeleteSubscriptionAction.ViewContextMenu:
                    {
                        #region Right-Click Item, Select Delete Context Menu

                        subscriptionRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Using right-click, context menu...");

                        // right-click item, properties menu
                        subscriptionRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Right-Click Item, Select Delete Context Menu
                    }

                    break;
                case Constants.DeleteSubscriptionAction.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Delete Link

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Using link text := '" +
                            actionsPaneLinkText +
                            "'");

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Clicking actions pane link...");

                        ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                        taskPane.ClickLink(
                            Core.Console.ActionsPane.Strings.ActionsPaneSubscription,
                            actionsPaneLinkText);

                        #endregion Actions Pane Delete Link
                    }

                    break;
                case Constants.DeleteSubscriptionAction.ViewShiftF10MenuHotKey:
                    {
                        #region Left-Click Item, SHIFT-F10, Select Delete Context Menu

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Using left-click, SHIFT-F10...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        subscriptionRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        subscriptionRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.ShiftF10);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Left-Click Item, SHIFT-F10, Select Delete Context Menu
                    }

                    break;
                case Constants.DeleteSubscriptionAction.ViewDeleteKey:
                    {
                        #region Left-Click Item, Press DELETE Key

                        // select item, press ENTER key
                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Using left-click, DELETE...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        subscriptionRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        subscriptionRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.Delete);

                        #endregion Left-Click Item, Press DELETE Key
                    }

                    break;
                default:
                    {
                        #region Right-Click Item, Select Delete Context Menu

                        subscriptionRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Using right-click, context menu...");

                        // right-click item, properties menu
                        subscriptionRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteSubscription::Selecting context menu '" +
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
                "DeleteSubscription::Confirm deletion := '" +
                confirmDeletion.ToString() +
                "'");

            // confirm the delete
            CoreManager.MomConsole.ConfirmChoiceDialog(
                confirmDeletion,
                Strings.ConfirmSubscriptionDeleteDialogTitle);

            // wait for the UI to settle
            CoreManager.MomConsole.Waiters.WaitForStatusReady(
                Core.Common.Constants.DefaultDialogTimeout);

            // ensure the DeleteAll action is done
            int waitcount = 0;
            while (CoreManager.MomConsole.ViewPane.Grid.Rows.Count > 1 && waitcount < 6)
            {
                Core.Common.Utilities.LogMessage("DeleteSubscription::Wait");
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                waitcount++;
            }

            Core.Common.Utilities.TakeScreenshot("Before_Exit_DeleteAllSubscription");
            Maui.Core.Keyboard.SendKeys(Mom.Test.UI.Core.Common.KeyboardCodes.F5);

            #endregion
        }

        /// <summary>
        /// Method to translate an Alert Criteria Record name into the 
        /// translated text from resource strings.
        /// </summary>
        /// <param name="alertCategoryItem">
        /// The Alert Criteria Record name that corresponds to a constant in
        /// Constants.Severities, Constants.Priorities, or
        /// Constants.ResolutionStates.
        /// </param>
        /// <returns>
        /// The translated text from resource strings.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the parameter passed is null
        /// or empty string.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentException if the parameter passed does not
        /// match any constants in Constants.Severities, Constants.Priorities,
        /// or Constants.ResolutionStates.
        /// </exception>
        public static string TranslateAlertCategoryItem(
            string alertCategoryItem)
        {
            if (String.IsNullOrEmpty(alertCategoryItem))
            {
                throw new System.ArgumentNullException(
                    "Alert category item must not be null or empty string!");
            }

            Core.Common.Utilities.LogMessage(
                "TranslateAlertCategoryItem::Translating alert category item := '" +
                alertCategoryItem +
                "'...");

            string returnValue = String.Empty;

            switch (alertCategoryItem)
            {
                case Constants.Severities.Critical:
                    {
                        returnValue = Wizards.AlertCriteria.AlertSeverityTypeDialog.Strings.CriticalAlertSeverity;
                    }

                    break;

                case Constants.Severities.Warning:
                    {
                        returnValue = Wizards.AlertCriteria.AlertSeverityTypeDialog.Strings.WarningAlertSeverity;
                    }

                    break;

                case Constants.Severities.Information:
                    {
                        returnValue = Wizards.AlertCriteria.AlertSeverityTypeDialog.Strings.InformationAlertSeverity;
                    }

                    break;

                case Constants.Priorities.High:
                    {
                        returnValue = Wizards.AlertCriteria.AlertPriorityDialog.Strings.HighAlertPriority;
                    }

                    break;

                case Constants.Priorities.Medium:
                    {
                        returnValue = Wizards.AlertCriteria.AlertPriorityDialog.Strings.MediumAlertPriority;
                    }

                    break;

                case Constants.Priorities.Low:
                    {
                        returnValue = Wizards.AlertCriteria.AlertPriorityDialog.Strings.LowAlertPriority;
                    }

                    break;

                case Constants.ResolutionStates.New:
                    {
                        returnValue = Wizards.AlertCriteria.ResolutionStateDialog.Strings.NewResolutionState;
                    }

                    break;

                case Constants.ResolutionStates.Closed:
                    {
                        returnValue = Wizards.AlertCriteria.ResolutionStateDialog.Strings.ClosedResolutionState;
                    }

                    break;

                case Constants.AlertCriteriaValues.AgentManagedComputerGroup:
                    {
                        returnValue = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemCenterLibraryMP, ManagementPackConstants.SystemAgentManagedComputerGroupName);
                    }
                    break;

                case Constants.AlertCriteriaValues.ServiceRunningState:
                    {
                        returnValue = Utilities.GetManagementPackMonitorDisplayName(ManagementPackConstants.GUIDSystemCenterNTServiceLibraryMP, ManagementPackConstants.ServiceStateMonitorName);
                    }
                    break;

                case Constants.AlertCriteriaValues.WindowsComputer:
                    {
                        returnValue = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerGroupName);
                    }
                    break;

                case Constants.AlertCriteriaValues.WindowsServiceStopped:
                    {
                        returnValue = Utilities.GetManagementPackStringResourceDisplayName(ManagementPackConstants.GUIDSystemCenterNTServiceLibraryMP, ManagementPackConstants.ServiceStateMonitorAlertMessageName);
                    }
                    break;

                case Constants.AlertCriteriaValues.AllWindowsComputers:
                    {
                        returnValue = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemCenterLibraryMP, ManagementPackConstants.WindowsAllWindowsComputersName);
                    }
                    break;
                    

                default:
                    {
                        returnValue = alertCategoryItem;
                        break;
                    }
            }

            Core.Common.Utilities.LogMessage(
                "TranslateAlertCategoryItem::Returning translated alert category item := '" +
                returnValue +
                "'");

            return returnValue;
        }

        /// <summary>
        /// Method to get the label for the alert criteria item that
        /// corresponds to the specified alert criteria record.
        /// </summary>
        /// <param name="alertCriteriaRecord">
        /// The specified alert criteria item.  The string is one of the 
        /// constant values from Constants.AlertCriteriaRecords.
        /// </param>
        /// <param name="criteriaWindow">
        /// Throws System.ArgumentNullException if the alert criteria parameter
        /// passed is null or empty string, or the reference to the window is
        /// null.
        /// </param>
        /// <returns>
        /// A StaticControl reference for the label that corresponds to the
        /// specified alert criteria record.
        /// </returns>
        public static StaticControl GetAlertCriteriaLabel(
            string alertCriteriaRecord,
            Wizards.SubscriptionCriteriaWindow criteriaWindow)
        {
            if (String.IsNullOrEmpty(alertCriteriaRecord))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria item must not be null or empty string!");
            }

            if (null == criteriaWindow)
            {
                throw new System.ArgumentNullException(
                    "Subscription criteria window reference must not be null!");
            }

            StaticControl returnValue = null;

            Core.Common.Utilities.LogMessage(
                "GetAlertCriteriaLabel::Getting label for '" +
                alertCriteriaRecord +
                "'...");

            switch (alertCriteriaRecord)
            {
                case Constants.AlertCriteriaRecords.Groups:
                    {
                        returnValue = criteriaWindow.Controls.RaisedByInstanceInSpecificGroupStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Classes:
                    {
                        returnValue = criteriaWindow.Controls.RaisedByInstanceOfASpecificClassStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.RulesOrMonitors:
                    {
                        returnValue = criteriaWindow.Controls.CreatedByASpecificRuleOrMonitorStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Instances:
                    {
                        returnValue = criteriaWindow.Controls.RaisedByAnInstanceWithASpecificNameStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Severities:
                    {
                        returnValue = criteriaWindow.Controls.OfASpecificSeverityStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Priorities:
                    {
                        returnValue = criteriaWindow.Controls.OfASpecificPriorityStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolutionStates:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificResolutionStateStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Names:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificNameStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Descriptions:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInDescriptionStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CreatedInTimePeriod:
                    {
                        returnValue = criteriaWindow.Controls.CreatedInSpecificTimePeriodStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.AssignedToOwners:
                    {
                        returnValue = criteriaWindow.Controls.AssignedToASpecificOwnerStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.LastModifiedByUsers:
                    {
                        returnValue = criteriaWindow.Controls.LastModifiedByASpecificUserStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.LastModifiedTimes:
                    {
                        returnValue = criteriaWindow.Controls.ModifiedInASpecificTimePeriodStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolutionStateChangedTimes:
                    {
                        returnValue = criteriaWindow.Controls.ResolutionStateChangedInASpecificTimePeriodStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolvedTimes:
                    {
                        returnValue = criteriaWindow.Controls.ResolvedInASpecificTimePeriodStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolvedByUsers:
                    {
                        returnValue = criteriaWindow.Controls.ResolvedByASpecificUserStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.TicketIds:
                    {
                        returnValue = criteriaWindow.Controls.WithASpecificTicketIdStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.AddedToDatabaseTimes:
                    {
                        returnValue = criteriaWindow.Controls.AddedToTheDatabaseInASpecificTimePeriodStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.SiteNames:
                    {
                        returnValue = criteriaWindow.Controls.FromASpecificSiteStaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField1:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField1StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField2:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField2StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField3:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField3StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField4:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField4StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField5:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField5StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField6:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField6StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField7:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField7StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField8:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField8StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField9:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField9StaticControl;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField10:
                    {
                        returnValue = criteriaWindow.Controls.WithSpecificTextInCustomField10StaticControl;
                    }

                    break;

                default:
                    {
                        throw new System.ArgumentException(
                            "Unknown or invalid alert criteria record name := '" +
                            alertCriteriaRecord +
                            "'");
                    }
            }

            Core.Common.Utilities.LogMessage(
                "GetAlertCriteriaLabel::Returning label '" +
                returnValue.Text +
                "' with control ID := '" +
                returnValue.Extended.CtrlID +
                "'");

            return returnValue;
        }

        #endregion

        #region Private Static Methods

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
        /// Method to translate an Alert Criteria Record name into the 
        /// translated text from resource strings.
        /// </summary>
        /// <param name="alertCriteriaItem">
        /// The Alert Criteria Record name that corresponds to a constant in
        /// Constants.AlertCriteriaRecords.
        /// </param>
        /// <returns>
        /// The translated text from resource strings.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the parameter passed is null
        /// or empty string.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if the parameter passed does not
        /// match any constants in Constants.AlertCriteriaRecords.
        /// </exception>
        private static string TranslateAlertCriteriaItem(
            string alertCriteriaItem)
        {
            if (String.IsNullOrEmpty(alertCriteriaItem))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria item must not be null or empty string!");
            }

            string returnValue = null;

            Core.Common.Utilities.LogMessage(
                "TranslateAlertCriteriaItem::Translating '" +
                alertCriteriaItem +
                "'...");

            switch (alertCriteriaItem)
            {
                case Constants.AlertCriteriaRecords.Groups:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.RaisedByAnyInstanceInASpecificGroup;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Classes:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.RaisedByAnyInstanceOfASpecificClass;
                    }

                    break;

                case Constants.AlertCriteriaRecords.RulesOrMonitors:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.CreatedByASpecificRuleOrMonitor;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Instances:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.RaisedByAnInstanceWithASpecificName;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Severities:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.OfASpecificSeverity;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Priorities:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.OfASpecificPriority;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolutionStates:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificResolutionState;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Names:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithASpecificName;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Descriptions:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInDescription;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CreatedInTimePeriod:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.CreatedInSpecificTimePeriod;
                    }

                    break;

                case Constants.AlertCriteriaRecords.AssignedToOwners:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.AssignedToSpecificOwner;
                    }

                    break;

                case Constants.AlertCriteriaRecords.LastModifiedByUsers:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.LastModifiedBySpecificUser;
                    }

                    break;

                case Constants.AlertCriteriaRecords.LastModifiedTimes:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.ModifiedInASpecificTimePeriod;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolutionStateChangedTimes:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.ResolutionStateChangedInASpecificTimePeriod;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolvedTimes:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.ResolvedInASpecificTimePeriod;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolvedByUsers:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.ResolvedBySpecificUser;
                    }

                    break;

                case Constants.AlertCriteriaRecords.TicketIds:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTicketId;
                    }

                    break;

                case Constants.AlertCriteriaRecords.AddedToDatabaseTimes:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.AddedToDatabaseInASpecificTimePeriod;
                    }

                    break;

                case Constants.AlertCriteriaRecords.SiteNames:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.FromSpecificSite;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField1:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField1;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField2:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField2;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField3:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField3;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField4:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField4;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField5:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField5;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField6:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField6;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField7:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField7;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField8:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField8;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField9:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField9;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField10:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.WithSpecificTextInCustomField10;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Monitors:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.CreatedByASpecificRuleOrMonitor;
                    }
                    break;

                case Constants.AlertCriteriaRecords.Rules:
                    {
                        returnValue = Wizards.SubscriptionCriteriaWindow.Strings.CreatedByASpecificRuleOrMonitor;
                    }

                    break;

                default:
                    {
                        throw new System.ArgumentException(
                            "Unknown or invalid alert criteria record name := '" +
                            alertCriteriaItem +
                            "'");
                    }
            }

            Core.Common.Utilities.LogMessage(
                "TranslateAlertCriteriaItem::Translated '" +
                alertCriteriaItem +
                "' into '" +
                returnValue +
                "'");

            return returnValue;
        }        

        /// <summary>
        /// Method to select the specified alert criteria item in the wizard
        /// window.
        /// </summary>
        /// <param name="alertCriteriaItem">
        /// The text of the specified alert criteria item.
        /// </param>
        /// <param name="criteriaWindow">
        /// Reference to the wizard window and its controls.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the alert criteria parameter
        /// passed is null or empty string, or the reference to the window is
        /// null.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentException if the alert criteria parameter 
        /// passed does not match any of the items in the wizard window.
        /// </exception>
        private static void SelectAlertCriteriaItem(
            string alertCriteriaItem,
            Wizards.SubscriptionCriteriaWindow criteriaWindow)
        {
            if (String.IsNullOrEmpty(alertCriteriaItem))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria item must not be null or empty string!");
            }

            if (null == criteriaWindow)
            {
                throw new System.ArgumentNullException(
                    "Subscription criteria window reference must not be null!");
            }

            string translatedAlertCriteriaItem =
                CommonSubscription.TranslateAlertCriteriaItem(
                    alertCriteriaItem);

            // remove any leading placeholders
            if (translatedAlertCriteriaItem.Contains("{0}"))
            {
                Core.Common.Utilities.LogMessage(
                    "SelectAlertCriteriaItem::Removing leading placeholder...");

                translatedAlertCriteriaItem =
                    translatedAlertCriteriaItem.Replace(
                        "{0}",
                        String.Empty);

                translatedAlertCriteriaItem =
                    translatedAlertCriteriaItem.Trim();
            }

            Core.Common.Utilities.LogMessage(
                "SelectAlertCriteriaItem::Looking for item := '" +
                translatedAlertCriteriaItem +
                "'");

            bool foundRequestedItem = false;

            // walk through the list box items looking for the specified one
            foreach (Maui.Core.WinControls.CheckedListBoxItem currentItem in
                criteriaWindow.Controls.SubscriptionCriteriaCheckedListBox.Items)
            {
                Core.Common.Utilities.LogMessage(
                    "SelectAlertCriteriaItem::Current list item := '" +
                    currentItem.Text +
                    "'");
                
                // check to see if the current item matches the requested item
                if (currentItem.Text.Equals(translatedAlertCriteriaItem))
                {
                    Core.Common.Utilities.LogMessage(
                        "SelectAlertCriteriaItem::Found matching item!");
                    foundRequestedItem = true;

                    // select the item
                    currentItem.Select();

                    // set the checked state of the item to true
                    currentItem.CheckState = ButtonState.Checked;

                    // we're done
                    break;
                }
                else
                {
                    //remove space character in the string
                    string stringCurrentItem = currentItem.Text.Replace(" ", "");
                    string stringTranslatedAlertCriteriaItem = translatedAlertCriteriaItem.Replace(" ", "");

                    //try again
                    // check to see if the current item matches the requested item
                    if (stringCurrentItem.Equals(stringTranslatedAlertCriteriaItem))
                    {
                        Core.Common.Utilities.LogMessage(
                            "SelectAlertCriteriaItem::Found matching item!");
                        foundRequestedItem = true;

                        // select the item
                        currentItem.Select();

                        // set the checked state of the item to true
                        currentItem.CheckState = ButtonState.Checked;

                        // we're done
                        break;
                    }
                }
            }

            // check to see if the item was found
            if (false == foundRequestedItem)
            {
                throw new System.ArgumentOutOfRangeException(
                    "Failed to find requested alert criteria item, '" +
                    translatedAlertCriteriaItem +
                    "', in the list view!");
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "SelectAlertCriteriaItem::Found item := '" +
                    translatedAlertCriteriaItem +
                    "'");
            }
        }

        /// <summary>
        /// Method to verify Selected the specified alert criteria item in the wizard
        /// window.
        /// </summary>
        /// <param name="alertCriteriaItem">
        /// The text of the specified alert criteria item.
        /// </param>
        /// <param name="criteriaWindow">
        /// Reference to the wizard window and its controls.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the alert criteria parameter
        /// passed is null or empty string, or the reference to the window is
        /// null.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentException if the alert criteria parameter 
        /// passed does not match any of the items in the wizard window.
        /// </exception>
        private static bool VerifySelectedAlertCriteriaItem(
            string alertCriteriaItem,
            Wizards.SubscriptionCriteriaWindow criteriaWindow)
        {
            bool retValue = false;

            if (String.IsNullOrEmpty(alertCriteriaItem))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria item must not be null or empty string!");
            }

            if (null == criteriaWindow)
            {
                throw new System.ArgumentNullException(
                    "Subscription criteria window reference must not be null!");
            }

            string translatedAlertCriteriaItem =
                CommonSubscription.TranslateAlertCriteriaItem(
                    alertCriteriaItem);

            // remove any leading placeholders
            if (translatedAlertCriteriaItem.Contains("{0}"))
            {
                Core.Common.Utilities.LogMessage(
                    "SelectAlertCriteriaItem::Removing leading placeholder...");

                translatedAlertCriteriaItem =
                    translatedAlertCriteriaItem.Replace(
                        "{0}",
                        String.Empty);

                translatedAlertCriteriaItem =
                    translatedAlertCriteriaItem.Trim();
            }

            Core.Common.Utilities.LogMessage(
                "SelectAlertCriteriaItem::Looking for item := '" +
                translatedAlertCriteriaItem +
                "'");

            bool foundRequestedItem = false;

            // walk through the list box items looking for the specified one
            foreach (Maui.Core.WinControls.CheckedListBoxItem currentItem in
                criteriaWindow.Controls.SubscriptionCriteriaCheckedListBox.Items)
            {
                Core.Common.Utilities.LogMessage(
                    "SelectAlertCriteriaItem::Current list item := '" +
                    currentItem.Text +
                    "'");

                // check to see if the current item matches the requested item
                if (currentItem.Text.Equals(translatedAlertCriteriaItem))
                {
                    Core.Common.Utilities.LogMessage(
                        "SelectAlertCriteriaItem::Found matching item!");
                    foundRequestedItem = true;

                    // set the checked state of the item to true
                    if (currentItem.CheckState == ButtonState.Checked)
                    {
                        retValue = true;
                    }
                    else
                    {
                        retValue = false;
                    }
                    // we're done
                    break;
                }
            }

            // check to see if the item was found
            if (false == foundRequestedItem)
            {
                throw new System.ArgumentOutOfRangeException(
                    "Failed to find requested alert criteria item, '" +
                    translatedAlertCriteriaItem +
                    "', in the list view!");
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "SelectAlertCriteriaItem::Found item := '" +
                    translatedAlertCriteriaItem +
                    "'");
            }

            return retValue;
        }

        /// <summary>
        /// Method to set the data for the specified alert criteria item.
        /// </summary>
        /// <param name="alertCriteriaRecord">
        /// The specified alert criteria item.  The string is one of the 
        /// constant values from Constants.AlertCriteriaRecords.
        /// </param>
        /// <param name="alertCriteriaItemData">
        /// The text data for the specified alert criteria item.  
        /// The value is a text string representing text, date/times, or 
        /// numeric values used for category-based items like severity or
        /// resolution state.
        /// </param>
        /// <param name="criteriaWindow">
        /// Reference to the wizard window and its controls.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the alert criteria parameter
        /// passed is null or empty string, or the reference to the window is
        /// null.
        /// </exception>
        private static string SetAlertCriteriaItemData(
            string alertCriteriaRecord,
            string alertCriteriaItemData,
            Wizards.SubscriptionCriteriaWindow criteriaWindow)
        {
            string returnValue = string.Empty;

            #region Validate Parameters

            if (String.IsNullOrEmpty(alertCriteriaRecord))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria record must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(alertCriteriaItemData))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria item data must not be null or empty string!");
            }

            if (null == criteriaWindow)
            {
                throw new System.ArgumentNullException(
                    "Subscription criteria window reference must not be null!");
            }

            #endregion Validate Parameters
            
            Core.Common.Utilities.LogMessage(
                "SetAlertCriteriaItemData::Getting static control for '" +
                alertCriteriaRecord +
                "'...");

            // get corresponding label control in criteria description field
            StaticControl alertCriteriaLabel =
                CommonSubscription.GetAlertCriteriaLabel(
                    alertCriteriaRecord, 
                    criteriaWindow);

            // check for valid label control
            if (null != alertCriteriaLabel)
            {
                #region Start Corresponding Dialog from Link Label

                Core.Common.Utilities.LogMessage(
                    "SetAlertCriteriaItemData::Looking for link label in static control, '" +
                    alertCriteriaLabel.Text +
                    "'");

                // get and click the link label inside the label control
                LinkLabel alertCriteriaLinkLabel =
                    new LinkLabel(alertCriteriaLabel.Extended.AccessibleObject);

                // check for valid link label control
                if (null != alertCriteriaLinkLabel)
                {
//                     Core.Common.Utilities.LogMessage(
//                         "SetAlertCriteriaItemData::Clicking link label...");
                    
                        // click the link in the middle of the left-hand side
//                         alertCriteriaLinkLabel.AccessibleObject.Click(
//                             MouseClickType.SingleClick,
//                             MouseFlags.LeftButton,
//                             (alertCriteriaLinkLabel.AccessibleObject.Width / 2),
//                             (alertCriteriaLinkLabel.AccessibleObject.Height / 2),
//                             KeyboardFlags.NoFlag);


                    Core.Common.Utilities.LogMessage(
                        "SetAlertCriteriaItemData::Tabbing to link text...");

                    Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);

                    // tab to link text
                    alertCriteriaLabel.SendKeys(
                        Core.Common.KeyboardCodes.Tab);

                    Core.Common.Utilities.LogMessage(
                        "SetAlertCriteriaItemData::Triggering link text...");

                    Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);

                    // trigger link text
                    alertCriteriaLabel.SendKeys(
                        Core.Common.KeyboardCodes.Enter);


                    Core.Common.Utilities.LogMessage(
                        "SetAlertCriteriaItemData::Setting data in the dialog...");

                    // set the data item in the corresponding criteria dialog
                    CommonSubscription.SetAlertCriteriaDataInDialog(
                        alertCriteriaRecord,
                        alertCriteriaItemData,
                        criteriaWindow);

                    //catch the control again after set it value
                    alertCriteriaLabel =
                CommonSubscription.GetAlertCriteriaLabel(
                    alertCriteriaRecord,
                    criteriaWindow);

                    returnValue = alertCriteriaLabel.Text;
                    Utilities.LogMessage("SetAlertCriteriaItemData :: criteria label return value : " + returnValue);
                }
                else
                {
                    // the link label was not found
                    throw new StaticControl.Exceptions.WindowNotFoundException(
                        "Failed to find the link label in the static control := '" +
                        alertCriteriaLabel.Text +
                        "'");
                }

                #endregion Start Corresponding Dialog from Link Label
            }
            else
            {
                throw new StaticControl.Exceptions.WindowNotFoundException(
                    "Failed to find the static control for '" +
                    alertCriteriaRecord +
                    "'");
            }
            return returnValue;
        }        

        /// <summary>
        /// Method to set alert criteria data in the appropriate dialog from
        /// within the current subscription wizard window.
        /// </summary>
        /// <param name="alertCriteriaRecord">
        /// The specified alert criteria item.  The string is one of the 
        /// constant values from Constants.AlertCriteriaRecords.
        /// </param>
        /// <param name="alertCriteriaDataItem">
        /// The text data for the specified alert criteria item.  
        /// The value is a text string representing text, date/times, or 
        /// numeric values used for category-based items like severity or
        /// resolution state.
        /// </param>
        /// <param name="criteriaWindow">
        /// Reference to the wizard window and its controls.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if the alert criteria parameter
        /// passed is null or empty string, or the reference to the window is
        /// null.
        /// </exception>
        private static void SetAlertCriteriaDataInDialog(
            string alertCriteriaRecord,
            string alertCriteriaDataItem,
            Wizards.SubscriptionCriteriaWindow criteriaWindow)
        {
            #region Check for Valid Parameters

            if (String.IsNullOrEmpty(alertCriteriaRecord))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria record must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(alertCriteriaDataItem))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria data item must not be null or empty string!");
            }

            if (null == criteriaWindow)
            {
                throw new System.ArgumentNullException(
                    "Subscription criteria window reference must not be null!");
            }

            #endregion Check for Valid Parameters

            Core.Common.Utilities.LogMessage(
                "SetAlertCriteriaDataInDialog::Setting data for '" +
                alertCriteriaRecord +
                "'...");

            switch (alertCriteriaRecord)
            {
                case Constants.AlertCriteriaRecords.Groups:
                    {
                        // use group search dialog
                        SearchForAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.Classes:
                    {
                        // use class search dialog
                        SearchForAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.RulesOrMonitors:
                    {
                        // use rule and monitor search dialog
                        SearchForAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.Instances:
                    {
                        // use object search dialog
                        SearchForAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.Severities:
                    {
                        // use alert severity dialog
                        SetCategoryBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.Priorities:
                    {
                        // use alert priority dialog
                        SetCategoryBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolutionStates:
                    {
                        // use resolution state dialog
                        SetCategoryBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.Names:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.Descriptions:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CreatedInTimePeriod:
                    {
                        // use date and time range dialog
                        SetDateTimeBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.AssignedToOwners:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.LastModifiedByUsers:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.LastModifiedTimes:
                    {
                        // use date and time range dialog
                        SetDateTimeBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolutionStateChangedTimes:
                    {
                        // use date and time range dialog
                        SetDateTimeBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolvedTimes:
                    {
                        // use date and time range dialog
                        SetDateTimeBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolvedByUsers:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.TicketIds:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.AddedToDatabaseTimes:
                    {
                        // use date and time range dialog
                        SetDateTimeBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.SiteNames:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField1:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField2:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField3:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField4:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField5:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField6:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField7:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField8:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField9:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField10:
                    {
                        // use text criteria dialog
                        SetTextBasedAlertDataItem(
                            alertCriteriaRecord,
                            alertCriteriaDataItem);
                    }

                    break;

                default:
                    {
                        throw new System.ArgumentException(
                            "Unknown or invalid alert criteria record name := '" +
                            alertCriteriaRecord +
                            "'");
                    }
            }
        }

        /// <summary>
        /// Method to select and use one of the search dialogs to find and add
        /// the specified data item to the current subscription criteria.
        /// </summary>
        /// <param name="alertCriteriaRecord">
        /// The specified alert criteria item.  The string is one of the 
        /// constant values from Constants.AlertCriteriaRecords.
        /// </param>
        /// <param name="alertCriteriaDataItem">
        /// The text data for the specified alert criteria item.  
        /// The value is a text string representing text, date/times, or 
        /// numeric values used for category-based items like severity or
        /// resolution state.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if either argument is null or
        /// empty string.
        /// </exception>
        private static void SearchForAlertDataItem(
            string alertCriteriaRecord,
            string alertCriteriaDataItem)
        {
            #region Check for Valid Parameters

            if (String.IsNullOrEmpty(alertCriteriaRecord))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria record must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(alertCriteriaDataItem))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria data item must not be null or empty string!");
            }

            #endregion Check for Valid Parameters

            #region Select Appropriate Search Dialog

            Core.Common.Utilities.LogMessage(
                "SearchForAlertDataItem::Using search dialog for '" +
                alertCriteriaRecord +
                "'...");

            Core.Console.Administration.PickerDialogBase searchDialog = null;

            switch (alertCriteriaRecord)
            {
                case Constants.AlertCriteriaRecords.Groups:
                    {
                        // use group search dialog
                        searchDialog =
                            new Wizards.AlertCriteria.GroupSearchDialog(
                                CoreManager.MomConsole);
                    }

                    break;

                case Constants.AlertCriteriaRecords.Classes:
                    {
                        // use class search dialog
                        searchDialog =
                            new Wizards.AlertCriteria.ClassSearchDialog(
                                CoreManager.MomConsole);
                    }

                    break;

                case Constants.AlertCriteriaRecords.RulesOrMonitors:
                    {
                        // use rule and monitor search dialog
                        searchDialog = 
                            new Wizards.AlertCriteria.RulesAndMonitorsSearchDialog(
                                CoreManager.MomConsole);
                    }

                    break;

                case Constants.AlertCriteriaRecords.Instances:
                    {
                        // use object search dialog
                        searchDialog =
                            new Wizards.AlertCriteria.ObjectOrInstanceSearchDialog(
                                CoreManager.MomConsole);
                    }

                    break;

                default:
                    {
                        throw new System.ArgumentException(
                            "Unknown or invalid alert criteria record name := '" +
                            alertCriteriaRecord +
                            "'");
                    }
            }

            #endregion Select Appropriate Search Dialog

            #region Search and Add Item

            // check for valid search dialog reference
            if (null != searchDialog)
            {
                string translatedAlertCriteriaItemData =
                CommonSubscription.TranslateAlertCategoryItem(
                    alertCriteriaDataItem);

                Core.Common.Utilities.LogMessage(
                    "SearchForAlertDataItem::Setting filter text := '" +
                    translatedAlertCriteriaItemData +
                    "'");

                // enter the search text
                searchDialog.FilterByTextBoxText =
                    translatedAlertCriteriaItemData;
                Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);

                Core.Common.Utilities.LogMessage(
                    "SearchForAlertDataItem::Searching...");

                // click the search button
                searchDialog.ClickSearch();

                // wait for the search to complete
                searchDialog.WaitForSearchResults(
                    Core.Console.Administration.PickerDialogBase.MaxSearchWaitTime);

                #region Wait for List to Populate

                Core.Common.Utilities.LogMessage(
                    "SearchForAlertDataItem::Waiting for list of results to populate...");

                // wait for the list of available items to populate
                const int MaxAttempts = 10;
                for (int currentAttempt = 0;
                    ((currentAttempt < MaxAttempts) &&
                    (0 >= searchDialog.Controls.AvailableItemsListView.Count));
                    currentAttempt++)
                {
                    // log the attempt
                    Core.Common.Utilities.LogMessage(
                        "SearchForAlertDataItem::Checking list view count, attempt " +
                        currentAttempt +
                        " of " +
                        MaxAttempts);

                    // delay
                    Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);
                }

                #endregion

                // check for available items
                if (searchDialog.Controls.AvailableItemsListView.Count > 0)
                {
                    #region Match Specified Item to Available Items

                    Core.Common.Utilities.LogMessage(
                        "SearchForAlertDataItem::Selecting items...");

                    // iterate over the list of available channels
                    foreach (Maui.Core.WinControls.ListViewItem availableItem in
                        searchDialog.Controls.AvailableItemsListView.Items)
                    {
                        // select the available channel
                        availableItem.Click();
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        Core.Common.Utilities.LogMessage(
                            "SearchForAlertDataItem::Currently selected item := '" +
                            availableItem.Text +
                            "'");

                        // check to see if the channel name matches the available channel                        
                        //if (availableItem.Text.Equals(alertCriteriaDataItem))
                        if (String.Compare(availableItem.Text, translatedAlertCriteriaItemData, true) == 0)
                        {
                            // find the channel in the list
                            Core.Common.Utilities.LogMessage(
                                "SearchForAlertDataItem::Adding item, '" +
                                availableItem.Text +
                                "', to selected list...");

                            // click "Add"
                            searchDialog.ClickAdd();
                            Maui.Core.Utilities.Sleeper.Delay(
                                Core.Common.Constants.OneSecond);
                        }                        
                    }

                    #endregion Match Specified Channels to Available Channels

                    Core.Common.Utilities.LogMessage(
                        "SearchForAlertDataItem::Closing search dialog...");

                    // click OK
                    searchDialog.ClickOK();
                    Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);

                    // drop the reference
                    searchDialog = null;
                }
                else
                {
                    // close the search dialog
                    searchDialog.ClickTitleBarClose();
                    Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);

                    // drop the reference
                    searchDialog = null;

                    throw new System.ArgumentException(
                        "Failed to find the item, '" +
                        translatedAlertCriteriaItemData +
                        "', in the search dialog!");
                }
            }
            else
            {
                throw new Window.Exceptions.WindowNotFoundException(
                    "Failed to find the appropriate search dialog for := '" +
                    alertCriteriaRecord +
                    "'");
            }

            #endregion Search and Add Item
        }

        /// <summary>
        /// Method to set text-based criteria data for the specified alert
        /// criteria item.
        /// </summary>
        /// <param name="alertCriteriaRecord">
        /// The specified alert criteria item.  The string is one of the 
        /// constant values from Constants.AlertCriteriaRecords.
        /// </param>
        /// <param name="alertCriteriaDataItem">
        /// The text data for the specified alert criteria item.  
        /// The value is a text string representing text, date/times, or 
        /// numeric values used for category-based items like severity or
        /// resolution state.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if either argument is null or
        /// empty string.
        /// </exception>
        private static void SetTextBasedAlertDataItem(
            string alertCriteriaRecord,
            string alertCriteriaDataItem)
        {
            #region Check for Valid Parameters

            if (String.IsNullOrEmpty(alertCriteriaRecord))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria record must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(alertCriteriaDataItem))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria data item must not be null or empty string!");
            }

            #endregion Check for Valid Parameters

            #region Select Appropriate Text Dialog

            Core.Common.Utilities.LogMessage(
                "SetTextBasedAlertDataItem::Using text dialog for '" +
                alertCriteriaRecord +
                "'...");

            // window reference for text criteria dialog
            Wizards.AlertCriteria.TextCriteriaDialog textCriteriaDialog = null;

            // reference to the window title string
            string textCriteriaDialogTitle = null;

            switch (alertCriteriaRecord)
            {
                case Constants.AlertCriteriaRecords.Names:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.AlertNameDialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.Descriptions:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.AlertDescriptionDialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.AssignedToOwners:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.AssignedOwnerDialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.LastModifiedByUsers:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.LastModifiedByDialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolvedByUsers:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.ResolvedByDialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.TicketIds:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.TicketIdDialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.SiteNames:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.FromSiteDialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField1:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField1DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField2:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField2DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField3:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField3DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField4:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField4DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField5:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField5DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField6:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField6DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField7:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField7DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField8:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField8DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField9:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField9DialogTitle;
                    }

                    break;

                case Constants.AlertCriteriaRecords.CustomField10:
                    {
                        // use text criteria dialog
                        textCriteriaDialogTitle =
                            Wizards.AlertCriteria.TextCriteriaDialog.Strings.CustomField10DialogTitle;
                    }

                    break;

                default:
                    {
                        throw new System.ArgumentException(
                            "Unknown or invalid alert criteria record name := '" +
                            alertCriteriaRecord +
                            "'");
                    }
            }

            textCriteriaDialog = 
                new Wizards.AlertCriteria.TextCriteriaDialog(
                    textCriteriaDialogTitle,
                    CoreManager.MomConsole);

            #endregion Select Appropriate Text Dialog

            #region Set Text-Based Data

            // check for valid dialg reference
            if (null != textCriteriaDialog)
            {
                Core.Common.Utilities.LogMessage(
                    "SetTextBasedAlertDataItem::Setting text data := '" +
                    alertCriteriaDataItem +
                    "'...");

                // set the text                
                switch (alertCriteriaDataItem)
                {
                    case Constants.NameType.Default:
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetTextBasedAlertDataItem::Using description := '" +
                                alertCriteriaDataItem +
                                "'");

                            // use string as-is
                            textCriteriaDialog.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                                alertCriteriaDataItem;
                        }

                        break;

                    case Constants.NameType.MinLength:
                        {
                            #region Minimum Length Data Item

                            Core.Common.Utilities.LogMessage(
                                "SetTextBasedAlertDataItem::Using Minimum Length name...");

                            // generate shortest, valid name and description
                            string generatedAlertCriteriaDataItem =
                                Administration.Notifications.Channels.CommonChannel.GenerateRandomString(1);

                            // verify that the name isn't composed of whitespace
                            if (generatedAlertCriteriaDataItem.Trim().Equals(String.Empty))
                            {
                                // regenerate the string
                                generatedAlertCriteriaDataItem =
                                    Administration.Notifications.Channels.CommonChannel.GenerateRandomString(1);

                                // check for whitespace again
                                if (generatedAlertCriteriaDataItem.Trim().Equals(String.Empty))
                                {
                                    // use a simple character
                                    generatedAlertCriteriaDataItem = "X";
                                }
                            }

                            textCriteriaDialog.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                                generatedAlertCriteriaDataItem;

                            #endregion Minimum Length Data Item
                        }

                        break;

                    case Constants.NameType.MaxLength:
                        {
                            #region Max Length Data Item

                            Core.Common.Utilities.LogMessage(
                                "SetTextBasedAlertDataItem::Using Maximum Length name...");

                            // generate a maximum length random name
                            string generatedAlertCriteriaDataItem =
                                Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                    Constants.NameMaxLength);

                            // if the generated string is not at the max length
                            if (Constants.NameMaxLength >
                                generatedAlertCriteriaDataItem.Length)
                            {
                                // pad the remaining length
                                generatedAlertCriteriaDataItem.PadRight(
                                    Constants.NameMaxLength,
                                    'X');
                            }

                            textCriteriaDialog.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                                generatedAlertCriteriaDataItem;

                            #endregion Max Length Data Item
                        }

                        break;

                    case Constants.NameType.RandomShort:
                        {
                            // use a random short name
                            Core.Common.Utilities.LogMessage(
                                "SetTextBasedAlertDataItem::Using Random Short name...");

                            // generate a short random name and description
                            textCriteriaDialog.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                                Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                    Constants.NameShortLength);
                        }

                        break;

                    case Constants.NameType.RandomLong:
                        {
                            // use a random long name
                            Core.Common.Utilities.LogMessage(
                                "SetTextBasedAlertDataItem::Using Random Short name...");

                            // generate a short random name and description
                            textCriteriaDialog.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                                Administration.Notifications.Channels.CommonChannel.GenerateRandomString(
                                    Constants.NameMaxLength);
                        }

                        break;

                    default:
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetTextBasedAlertDataItem::Using description := '" +
                                alertCriteriaDataItem +
                                "'");

                            // use string as-is
                            textCriteriaDialog.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                                alertCriteriaDataItem;
                        }

                        break;
                }

                textCriteriaDialog.ClickOK();
                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.OneSecond);

                // drop the reference
                textCriteriaDialog = null;
            }
            else
            {
                throw new Window.Exceptions.WindowNotFoundException(
                    "Failed to find the appropriate text dialog for := '" +
                    alertCriteriaRecord +
                    "'");
            }

            #endregion Set Text-Based Data
        }

        /// <summary>
        /// Method to set category-based criteria data for the specified alert
        /// criteria item.
        /// </summary>
        /// <param name="alertCriteriaRecord">
        /// The specified alert criteria item.  The string is one of the 
        /// constant values from Constants.Severities, Constants.Priorities, or
        /// Constants.ResolutionStates.
        /// </param>
        /// <param name="alertCriteriaDataItem">
        /// The category item data for the specified alert criteria item.  
        /// The value is a text string representing severity, priority or
        /// resolution state.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if either argument is null or
        /// empty string.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if the alert criteria
        /// item does not match one of items defined 
        /// </exception>
        private static void SetCategoryBasedAlertDataItem(
            string alertCriteriaRecord,
            string alertCriteriaDataItem)
        {
            #region Check for Valid Parameters

            if (String.IsNullOrEmpty(alertCriteriaRecord))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria record must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(alertCriteriaDataItem))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria data item must not be null or empty string!");
            }

            #endregion Check for Valid Parameters

            #region Select Appropriate Dialog and Select Categories

            Core.Common.Utilities.LogMessage(
                "SetCategoryBasedAlertDataItem::Using search dialog for '" +
                alertCriteriaRecord +
                "'...");

            switch (alertCriteriaRecord)
            {
                case Constants.AlertCriteriaRecords.Severities:
                    {
                        #region Set Alert Severities

                        Core.Common.Utilities.LogMessage(
                            "SetCategoryBasedAlertDataItem::Setting alert severities...");

                        Wizards.AlertCriteria.AlertSeverityTypeDialog severityDialog =
                            new Wizards.AlertCriteria.AlertSeverityTypeDialog(
                                CoreManager.MomConsole);

                        Core.Common.Utilities.LogMessage(
                            "SetCategoryBasedAlertDataItem::Alert severities data := '" +
                            alertCriteriaDataItem +
                            "'");

                        // check for "All" or "SelectAll"
                        if (alertCriteriaDataItem.Equals(Constants.SelectAll))
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetCategoryBasedAlertDataItem::Check all severities...");

                            // click "Select All" button
                            severityDialog.ClickSelectAll();
                        }
                        else
                        {
                            #region Select Specific Severities

                            Core.Common.Utilities.LogMessage(
                                "SetCategoryBasedAlertDataItem::Checking specific severities...");

                            // split the data item to check for multiple values
                            string[] categoryValues = alertCriteriaDataItem.Split(',');

                            // for each data item
                            for (int index = 0; index < categoryValues.Length; index++)
                            {
                                Core.Common.Utilities.LogMessage(
                                    "SetCategoryBasedAlertDataItem::Checking severity := '" +
                                    categoryValues[index] +
                                    "'...");

                                // translate the data item
                                string translatedAlertCriteriaDataItem =
                                    CommonSubscription.TranslateAlertCategoryItem(
                                        categoryValues[index]);

                                Core.Common.Utilities.LogMessage(
                                    "SetCategoryBasedAlertDataItem::Using translated severity := '" +
                                    translatedAlertCriteriaDataItem +
                                    "'...");

                                #region Match Alert Data Item in List of Items

                                // for each item in the list
                                foreach (Maui.Core.WinControls.CheckedListBoxItem categoryItem in
                                    severityDialog.Controls.SeveritiesCheckedListBox.Items)
                                {
                                    Core.Common.Utilities.LogMessage(
                                        "SetCategoryBasedAlertDataItem::Matching severity item := '" +
                                        categoryItem.Text +
                                        "'...");

                                    // does the current item contain the translated item?
                                    if (categoryItem.Text.StartsWith(translatedAlertCriteriaDataItem))
                                    {
                                        Core.Common.Utilities.LogMessage(
                                            "SetCategoryBasedAlertDataItem::Selecting severity item := '" +
                                            categoryItem.Text +
                                            "'...");

                                        // yes, select it, check it, break out
                                        categoryItem.Select();

                                        // set the check state to checked
                                        categoryItem.CheckState = ButtonState.Checked;
                                    }
                                }

                                #endregion Match Alert Data Item in List of Items
                            }

                            #endregion Select Specific Severities
                        }

                        // close the dialog
                        severityDialog.ClickOK();

                        #endregion
                    }

                    break;

                case Constants.AlertCriteriaRecords.Priorities:
                    {
                        #region Set Alert Priorities

                        Core.Common.Utilities.LogMessage(
                            "SetCategoryBasedAlertDataItem::Setting alert priorities...");

                        Wizards.AlertCriteria.AlertPriorityDialog priorityDialog =
                            new Wizards.AlertCriteria.AlertPriorityDialog(
                                CoreManager.MomConsole);

                        Core.Common.Utilities.LogMessage(
                            "SetCategoryBasedAlertDataItem::Alert severities data := '" +
                            alertCriteriaDataItem +
                            "'");

                        // check for "All" or "SelectAll"
                        if (alertCriteriaDataItem.Equals(Constants.SelectAll))
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetCategoryBasedAlertDataItem::Check all priorities...");

                            // click "Select All" button
                            priorityDialog.ClickSelectAll();
                        }
                        else
                        {
                            #region Select Specific Priorities

                            Core.Common.Utilities.LogMessage(
                                "SetCategoryBasedAlertDataItem::Checking specific priorities...");

                            // split the data item to check for multiple values
                            string[] categoryValues = alertCriteriaDataItem.Split(',');

                            // for each data item
                            for (int index = 0; index < categoryValues.Length; index++)
                            {
                                Core.Common.Utilities.LogMessage(
                                    "SetCategoryBasedAlertDataItem::Checking priority := '" +
                                    categoryValues[index] +
                                    "'...");

                                // translate the data item
                                string translatedAlertCriteriaDataItem =
                                    CommonSubscription.TranslateAlertCategoryItem(
                                        categoryValues[index]);

                                Core.Common.Utilities.LogMessage(
                                    "SetCategoryBasedAlertDataItem::Using translated priority := '" +
                                    translatedAlertCriteriaDataItem +
                                    "'...");
                                
                                #region Match Alert Data Item in List of Items

                                // for each item in the list
                                foreach (Maui.Core.WinControls.CheckedListBoxItem categoryItem in
                                    priorityDialog.Controls.PrioritiesCheckedListBox.Items)
                                {
                                    Core.Common.Utilities.LogMessage(
                                        "SetCategoryBasedAlertDataItem::Matching priority item := '" +
                                        categoryItem.Text +
                                        "'...");

                                    // does the current item contain the translated item?
                                    if (categoryItem.Text.StartsWith(translatedAlertCriteriaDataItem))
                                    {
                                        Core.Common.Utilities.LogMessage(
                                            "SetCategoryBasedAlertDataItem::Selecting priority item := '" +
                                            categoryItem.Text +
                                            "'...");

                                        // yes, select it, check it, break out
                                        categoryItem.Select();

                                        // set the check state to checked
                                        categoryItem.CheckState = ButtonState.Checked;
                                    }
                                }

                                #endregion Match Alert Data Item in List of Items
                            }

                            #endregion Select Specific Priorities
                        }

                        // close the dialog
                        priorityDialog.ClickOK();

                        #endregion
                    }

                    break;

                case Constants.AlertCriteriaRecords.ResolutionStates:
                    {
                        #region Set Alert Resolution States

                        Core.Common.Utilities.LogMessage(
                            "SetCategoryBasedAlertDataItem::Setting alert resolution states...");

                        Wizards.AlertCriteria.ResolutionStateDialog resolutionStatesDialog =
                            new Wizards.AlertCriteria.ResolutionStateDialog(
                                CoreManager.MomConsole);

                        Core.Common.Utilities.LogMessage(
                            "SetCategoryBasedAlertDataItem::Alert severities data := '" +
                            alertCriteriaDataItem +
                            "'");

                        // check for "All" or "SelectAll"
                        if (alertCriteriaDataItem.Equals(Constants.SelectAll))
                        {
                            Core.Common.Utilities.LogMessage(
                                "SetCategoryBasedAlertDataItem::Check all resolution states...");

                            // click "Select All" button
                            resolutionStatesDialog.ClickSelectAll();
                        }
                        else
                        {
                            #region Select Specific Priorities

                            Core.Common.Utilities.LogMessage(
                                "SetCategoryBasedAlertDataItem::Checking specific resolution states...");

                            // split the data item to check for multiple values
                            string[] categoryValues = alertCriteriaDataItem.Split(',');

                            // for each data item
                            for (int index = 0; index < categoryValues.Length; index++)
                            {
                                Core.Common.Utilities.LogMessage(
                                    "SetCategoryBasedAlertDataItem::Checking priority := '" +
                                    categoryValues[index] +
                                    "'...");

                                // translate the data item
                                string translatedAlertCriteriaDataItem =
                                    CommonSubscription.TranslateAlertCategoryItem(
                                        categoryValues[index]);

                                Core.Common.Utilities.LogMessage(
                                    "SetCategoryBasedAlertDataItem::Using translated resolution state := '" +
                                    translatedAlertCriteriaDataItem +
                                    "'...");

                                #region Match Alert Data Item in List of Items

                                // for each item in the list
                                foreach (Maui.Core.WinControls.CheckedListBoxItem categoryItem in
                                    resolutionStatesDialog.Controls.ResolutionStateCheckedListBox.Items)
                                {
                                    Core.Common.Utilities.LogMessage(
                                        "SetCategoryBasedAlertDataItem::Matching resolution state item := '" +
                                        categoryItem.Text +
                                        "'...");

                                    // does the current item contain the translated item?
                                    if (categoryItem.Text.StartsWith(translatedAlertCriteriaDataItem))
                                    {
                                        Core.Common.Utilities.LogMessage(
                                            "SetCategoryBasedAlertDataItem::Selecting resolution state item := '" +
                                            categoryItem.Text +
                                            "'...");

                                        // yes, select it, check it, break out
                                        categoryItem.Select();

                                        // set the check state to checked
                                        categoryItem.CheckState = ButtonState.Checked;
                                    }
                                }

                                #endregion Match Alert Data Item in List of Items
                            }

                            #endregion Select Specific Priorities
                        }

                        // close the dialog
                        resolutionStatesDialog.ClickOK();

                        #endregion
                    }

                    break;

                default:
                    {
                        throw new System.ArgumentException(
                            "Unknown or invalid alert criteria record name := '" +
                            alertCriteriaRecord +
                            "'");
                    }
            }

            #endregion Select Appropriate Dialog and Select Categories
        }

        /// <summary>
        /// Method to set Date/Time-based criteria data for the specified alert
        /// criteria item.
        /// </summary>
        /// <param name="alertCriteriaRecord">
        /// The specified alert criteria item.  The string is one of the 
        /// constant values from Constants.AlertCriteriaRecords, Constants.Priorities
        /// </param>
        /// <param name="alertCriteriaDataItem">
        /// The date time item data for the specified alert criteria item.  
        /// The value is a text string representing Time range.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if either argument is null or
        /// empty string.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if the alert criteria
        /// item does not match one of items defined 
        /// </exception>
        private static void SetDateTimeBasedAlertDataItem(
            string alertCriteriaRecord,
            string alertCriteriaDataItem)
        {
            #region Check for Valid Parameters

            if (String.IsNullOrEmpty(alertCriteriaRecord))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria record must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(alertCriteriaDataItem))
            {
                throw new System.ArgumentNullException(
                    "Alert criteria data item must not be null or empty string!");
            }

            #endregion Check for Valid Parameters

            #region Select Appropriate Dialog and Select DateTime

            Core.Common.Utilities.LogMessage(
                "SetDateTimeBasedAlertDataItem::Using search dialog for '" +
                alertCriteriaRecord +
                "'...");

            switch (alertCriteriaRecord)
            {
                case Constants.AlertCriteriaRecords.CreatedInTimePeriod:
                    {
                        #region Set Alert Created In A Specific Time Period view criteria

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Setting alert Created Time...");

                        Wizards.AlertCriteria.DateandTimeRangeDialog createdDialog =
                            new Wizards.AlertCriteria.DateandTimeRangeDialog(Wizards.AlertCriteria.DateandTimeRangeDialog.Strings.DateAndTimeGeneratedDialogTitle,
                                CoreManager.MomConsole);

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Alert Created Time := '" +
                            alertCriteriaDataItem +
                            "'");
                        switch (alertCriteriaDataItem)
                        {
                            case Constants.TimeRange.After:
                                //check afer checkbox and keep the value default for now
                                if (createdDialog.After == false)
                                {
                                    createdDialog.ClickAfter();
                                }
                                if (createdDialog.Before == true)
                                {
                                    createdDialog.ClickBefore();
                                }
                                break;
                            case Constants.TimeRange.Before:
                                //check before checkbox and keep the value default for now
                                if (createdDialog.After == true)
                                {
                                    createdDialog.ClickAfter();
                                }
                                if (createdDialog.Before == false)
                                {
                                    createdDialog.ClickBefore();
                                }
                                break;

                            default:
                                throw new System.ArgumentException(
                            "Unknown or invalid alert criteria data := '" +
                            alertCriteriaDataItem +
                            "'");
                        }

                        // close the dialog
                        createdDialog.ClickOK();

                        #endregion
                    }
                    break;

                case Constants.AlertCriteriaRecords.LastModifiedTimes:
                    {
                     #region Set Alert that was modified in A Specific Time Period view criteria

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Setting alert last modified Time...");

                        Wizards.AlertCriteria.DateandTimeRangeDialog lastModifiedTimeDialog =
                            new Wizards.AlertCriteria.DateandTimeRangeDialog(Wizards.AlertCriteria.DateandTimeRangeDialog.Strings.LastModifiedTimeDialogTitle,
                                CoreManager.MomConsole);

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Alert last modified Time:= '" +
                            alertCriteriaDataItem +
                            "'");
                        SetDateTime(alertCriteriaDataItem, lastModifiedTimeDialog); 
                      
                     #endregion
                    }
                    break;
            
                case Constants.AlertCriteriaRecords.ResolvedTimes:
                    {
                        #region Set Alert that was resolved in A Specific Time Period view criteria

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Setting alert that was resolved in a specific time period...");

                        Wizards.AlertCriteria.DateandTimeRangeDialog timeResolvedDialog =
                            new Wizards.AlertCriteria.DateandTimeRangeDialog(Wizards.AlertCriteria.DateandTimeRangeDialog.Strings.TimeResolvedDialogTitle,
                                CoreManager.MomConsole);

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Alert time resolved data := '" +
                            alertCriteriaDataItem +
                            "'");

                        SetDateTime(alertCriteriaDataItem, timeResolvedDialog); 

                        #endregion
                    }
                    break;

                case Constants.AlertCriteriaRecords.AddedToDatabaseTimes:
                    {
                        #region Set Alert that was added to the database in A Specific Time Period view criteria

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Setting alert added to the database...");

                        Wizards.AlertCriteria.DateandTimeRangeDialog timeAddedDialog =
                            new Wizards.AlertCriteria.DateandTimeRangeDialog(Wizards.AlertCriteria.DateandTimeRangeDialog.Strings.TimeAddedDialogTitle,
                                CoreManager.MomConsole);

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Alert Time added to the database := '" +
                            alertCriteriaDataItem +
                            "'");
                        SetDateTime(alertCriteriaDataItem, timeAddedDialog); 
                        #endregion
                    }
                    break;

                case Constants.AlertCriteriaRecords.ResolutionStateChangedTimes:
                    {
                        #region Set Alert has its state changed in a specific time period view criteria

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Setting alert resolution state last modified...");

                        Wizards.AlertCriteria.DateandTimeRangeDialog resolutionStateLastModifiedDialog =
                            new Wizards.AlertCriteria.DateandTimeRangeDialog(Wizards.AlertCriteria.DateandTimeRangeDialog.Strings.ResolutionStateLastModifiedDialogTitle,
                                CoreManager.MomConsole);

                        Core.Common.Utilities.LogMessage(
                            "SetDateTimeBasedAlertDataItem::Alert resolution state last modified data := '" +
                            alertCriteriaDataItem +
                            "'");
                        SetDateTime(alertCriteriaDataItem, resolutionStateLastModifiedDialog); 

                        #endregion
                    }
                    break;
                default:
                    throw new System.ArgumentException(
                            "SetDateTimeBasedAlertDataItem::Unknown or invalid alert criteria record name := '" +
                            alertCriteriaRecord +
                            "'");
            }
            #endregion
        }

        /// <summary>
        /// Method to set Date Time
        /// criteria item.
        /// </summary>
        /// <param name="alertCriteriaDataItem">
        /// The date time item data for the specified alert criteria item.  
        /// constant values from Constants.AlertCriteriaRecords, Constants.Priorities
        /// </param>
        /// <param name="dateTimeDialog">
        /// The dialog for every date time dialog  
        /// </param>
        private static void SetDateTime(string alertCriteriaDataItem, Wizards.AlertCriteria.DateandTimeRangeDialog dateTimeDialog)
        {
            switch (alertCriteriaDataItem)
            {
                case Constants.TimeRange.WithinRange:
                    {
                        dateTimeDialog.DateandTimeRangeOption = Wizards.AlertCriteria.DateandTimeRangeOption.WithinTheTimeRange;
                    }
                    break;
                case Constants.TimeRange.Before:
                    {
                        dateTimeDialog.DateandTimeRangeOption = Wizards.AlertCriteria.DateandTimeRangeOption.WithinTheTimeRange;

                        //check before checkbox and keep the value default for now
                        if (dateTimeDialog.After == true)
                        {
                            dateTimeDialog.ClickAfter();
                        }
                        if (dateTimeDialog.Before == false)
                        {
                            dateTimeDialog.ClickBefore();
                        }
                    }
                    break;
                case Constants.TimeRange.After:
                    {
                        dateTimeDialog.DateandTimeRangeOption = Wizards.AlertCriteria.DateandTimeRangeOption.WithinTheTimeRange;

                        //check after checkbox and keep the value default for now
                        if (dateTimeDialog.After == false)
                        {
                            dateTimeDialog.ClickAfter();
                        }
                        if (dateTimeDialog.Before == true)
                        {
                            dateTimeDialog.ClickBefore();
                        }
                    }
                    break;
                case Constants.TimeRange.WithinLast:
                    {
                        dateTimeDialog.DateandTimeRangeOption = Wizards.AlertCriteria.DateandTimeRangeOption.WithinTheLast;
                    }
                    break;
                default:
                    Utilities.LogMessage("SetDateTime::alertCriteriaDataItem is invalid: " + alertCriteriaDataItem);
                    break;
            }

            // close the dialog
            dateTimeDialog.ClickOK();
        }
                    
        #endregion Private Static Methods
 
        /// <summary>
        /// Resource strings class.
        /// </summary>
        public sealed class Strings
        {
            #region Resource Constants

            /// <summary>
            /// Contains resource string for: NewSubscriptionContextMenu
            /// </summary>
            private const string ResourceNewSubscriptionContextMenu =
                ";New..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";NewEllipsis";

            /// <summary>
            /// Contains the resource identifier for 
            /// ConfirmSubscriberDeleteDialogTitle
            /// </summary>
            private const string ResourceConfirmSubscriptionDeleteDialogTitle =
                ";Confirm Subscription Delete" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionDeleteConfirmationTitle";

            /// <summary>
            /// Contains resource string for (null) string
            /// </summary>
            private const string ResourceNull = ";(null);ManagedString;System.Windows.Forms.dll;System.Windows.Forms;DataGridNullText";

            #endregion

            #region Private Members

            /// <summary>
            /// Cached translated value for NewSubscriptionContextMenu
            /// </summary>
            private static string cachedNewSubscriptionContextMenu;

            /// <summary>
            /// Cached translated value for ConfirmSubscriberDeleteDialogTitle
            /// </summary>
            private static string cachedConfirmSubscriptionDeleteDialogTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for (null) string
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedResourceNull;

            #endregion

            #region Public Properties

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewSubscriptionContextMenu translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 27-SEP-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string NewSubscriptionContextMenu
            {
                get
                {
                    if (cachedNewSubscriptionContextMenu == null)
                    {
                        cachedNewSubscriptionContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNewSubscriptionContextMenu);
                    }

                    return cachedNewSubscriptionContextMenu;
                }
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfirmSubscriptionDeleteDialogTitle 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string ConfirmSubscriptionDeleteDialogTitle
            {
                get
                {
                    if (cachedConfirmSubscriptionDeleteDialogTitle == null)
                    {
                        cachedConfirmSubscriptionDeleteDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceConfirmSubscriptionDeleteDialogTitle);
                    }

                    return cachedConfirmSubscriptionDeleteDialogTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Resource (null) Sting
            /// </summary>            
            /// ---------------------------------------------------------------
            public static string NullString
            {
                get
                {
                    if ((cachedResourceNull == null))
                    {
                        cachedResourceNull = CoreManager.MomConsole.GetIntlStr(ResourceNull);
                    }

                    return cachedResourceNull;
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
            /// Maximum number of wait attempts for subscription save 
            /// operation.
            /// </summary>
            public const int MaxWaitAttemptsForSubscriptionSave = 90;

            /// <summary>
            /// Delay interval between wait attempts for subscription save 
            /// operation.
            /// </summary>
            public const int DelayIntervalForSubscriptionSave = 2000;

            /// <summary>
            /// The maximum length of a subscription name
            /// </summary>
            public const int NameMaxLength = 256;

            /// <summary>
            /// The short length of a subscription name
            /// </summary>
            public const int NameShortLength = 64;

            /// <summary>
            /// The maximum length of a subscription description
            /// </summary>
            public const int DescriptionMaxLength = 4000;

            /// <summary>
            /// The short length of a subscription description
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
            /// Constant for value "Select All".  Used by category-based alert
            /// criteria to indicate if all values of the specified category
            /// should be selected.
            /// </summary>
            public const string SelectAll = "SelectAll";

            /// <summary>
            /// Constant defining the address identifier character used in
            /// email address to separate the user name from the domain
            /// address.
            /// </summary>
            public const string EmailAddressIdentifier = "@";

            /// <summary>
            /// Constant defining for printer service "Spooler" 
            /// </summary>
            public const string SpoolerService = "Spooler";

            /// <summary>
            /// Class to contain constant values for var-map record StartPoint.
            /// </summary>
            public sealed class StartPoint
            {
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
                public const string ActionsPaneLink = "ActionsPaneLink";

                /// <summary>
                /// Constant for the value AlertViewContextMenu
                /// </summary>
                public const string AlertViewContextMenu = "AlertViewContextMenu";
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
            /// DeleteSubscriptionAction.
            /// </summary>
            public sealed class DeleteSubscriptionAction
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
            /// Class to contain constant values for var-map records
            /// AlertCriteriaRecords.
            /// </summary>
            public sealed class AlertCriteriaRecords
            {
                /// <summary>
                /// Constant for the value Groups
                /// </summary>
                public const string Groups = "Groups";

                /// <summary>
                /// Constant for the value Classes
                /// </summary>
                public const string Classes = "Classes";

                /// <summary>
                /// Constant for the value Instances
                /// </summary>
                public const string Instances = "Instances";

                /// <summary>
                /// Constant for the value Names
                /// </summary>
                public const string Names = "Names";

                /// <summary>
                /// Constant for the value Severities
                /// </summary>
                public const string Severities = "Severities";

                /// <summary>
                /// Constant for the value Priorities
                /// </summary>
                public const string Priorities = "Priorities";

                /// <summary>
                /// Constant for the value ResolutionStates
                /// </summary>
                public const string ResolutionStates = "ResolutionStates";

                /// <summary>
                /// Constant for the value RulesOrMonitors
                /// </summary>
                public const string RulesOrMonitors = "RulesOrMonitors";

                /// <summary>
                /// Constant for the value Descriptions
                /// </summary>
                public const string Descriptions = "Description";

                /// <summary>
                /// Constant for the value CreatedInTimePeriod
                /// </summary>
                public const string CreatedInTimePeriod =
                    "CreatedInTimePeriod";

                /// <summary>
                /// Constant for the value AssignedToOwners
                /// </summary>
                public const string AssignedToOwners = "AssignedToOwners";

                /// <summary>
                /// Constant for the value LastModifiedByUsers
                /// </summary>
                public const string LastModifiedByUsers =
                    "LastModifiedByUsers";

                /// <summary>
                /// Constant for the value LastModifiedTimes
                /// </summary>
                public const string LastModifiedTimes = "LastModifiedTimes";

                /// <summary>
                /// Constant for the value ResolutionStateChangedTimes
                /// </summary>
                public const string ResolutionStateChangedTimes =
                    "ResolutionStateChangedTimes";

                /// <summary>
                /// Constant for the value ViewShiftF10MenuHotKey
                /// </summary>
                public const string ResolvedTimes = "ResolvedTimes";

                /// <summary>
                /// Constant for the value ResolvedByUsers
                /// </summary>
                public const string ResolvedByUsers = "ResolvedByUsers";

                /// <summary>
                /// Constant for the value TicketIds
                /// </summary>
                public const string TicketIds = "TicketIds";

                /// <summary>
                /// Constant for the value AddedToDatabaseTimes
                /// </summary>
                public const string AddedToDatabaseTimes =
                    "AddedToDatabaseTimes";

                /// <summary>
                /// Constant for the value SiteNames
                /// </summary>
                public const string SiteNames = "SiteNames";

                /// <summary>
                /// Constant for the value CustomField1
                /// </summary>
                public const string CustomField1 = "CustomField1";

                /// <summary>
                /// Constant for the value CustomField2
                /// </summary>
                public const string CustomField2 = "CustomField2";

                /// <summary>
                /// Constant for the value CustomField3
                /// </summary>
                public const string CustomField3 = "CustomField3";

                /// <summary>
                /// Constant for the value CustomField4
                /// </summary>
                public const string CustomField4 = "CustomField4";

                /// <summary>
                /// Constant for the value CustomField5
                /// </summary>
                public const string CustomField5 = "CustomField5";

                /// <summary>
                /// Constant for the value CustomField6
                /// </summary>
                public const string CustomField6 = "CustomField6";

                /// <summary>
                /// Constant for the value CustomField7
                /// </summary>
                public const string CustomField7 = "CustomField7";

                /// <summary>
                /// Constant for the value CustomField8
                /// </summary>
                public const string CustomField8 = "CustomField8";

                /// <summary>
                /// Constant for the value CustomField9
                /// </summary>
                public const string CustomField9 = "CustomField9";

                /// <summary>
                /// Constant for the value CustomField10
                /// </summary>
                public const string CustomField10 = "CustomField10";

                /// <summary>
                /// Constant for the value Monitors
                /// </summary>
                public const string Monitors = "Monitors";

                /// <summary>
                /// Constant for the value Rules
                /// </summary>
                public const string Rules = "Rules";
            }

            /// <summary>
            /// Class to contain constant values for var-map records
            /// Severities.
            /// </summary>
            public sealed class Severities
            {
                /// <summary>
                /// Constant for the value Critical
                /// </summary>
                public const string Critical = "Critical";

                /// <summary>
                /// Constant for the value Warning
                /// </summary>
                public const string Warning = "Warning";

                /// <summary>
                /// Constant for the value Information
                /// </summary>
                public const string Information = "Information";
            }

            /// <summary>
            /// Class to contain constant values for var-map records
            /// Priorities.
            /// </summary>
            public sealed class Priorities
            {
                /// <summary>
                /// Constant for the value High
                /// </summary>
                public const string High = "High";

                /// <summary>
                /// Constant for the value Medium
                /// </summary>
                public const string Medium = "Medium";

                /// <summary>
                /// Constant for the value Low
                /// </summary>
                public const string Low = "Low";
            }

            /// <summary>
            /// Class to contain constant values for var-map records
            /// ResolutionStates.
            /// </summary>
            public sealed class ResolutionStates
            {
                /// <summary>
                /// Constant for the value New
                /// </summary>
                public const string New = "New";

                /// <summary>
                /// Constant for the value Closed
                /// </summary>
                public const string Closed = "Closed";
            }

            /// <summary>
            /// Class to contain constant values for var-map records
            /// Instances.
            /// </summary>
            public sealed class Instances
            {
                /// <summary>
                /// Constant for the value New
                /// </summary>
                public const string AgentComputer = "AgentComputer";

                /// <summary>
                /// Constant for the value New
                /// </summary>
                public const string ManagementServer = "ManagementServer";
            }

            /// <summary>
            /// Class to contain constant values for var-map records
            /// AlartSource.
            /// </summary>
            public sealed class AlertSource
            {
                /// <summary>
                /// Constant for the value New
                /// </summary>
                public const string SpoolerMonitor = "SpoolerMonitor";

                /// <summary>
                /// Constant for the value New
                /// </summary>
                public const string EventRule = "EventRule";
            }

            /// <summary>
            /// Class to contain constant values for var-map records
            /// AlartSource.
            /// </summary>
            public sealed class AlertCriteriaValues
            {
                /// <summary>
                /// Constant for the value AgentManagedComputerGroup
                /// </summary>
                public const string AgentManagedComputerGroup = "Agent Managed Computer Group";

                /// <summary>
                /// Constant for the value ServiceRunningState
                /// </summary>
                public const string ServiceRunningState = "Service Running State";

                /// <summary>
                /// Constant for the value WindowsComputer
                /// </summary>
                public const string WindowsComputer = "Windows Computer";

                /// <summary>
                /// Constant for the value WindowsServiceStopped
                /// </summary>
                public const string WindowsServiceStopped = "Windows Service Stopped";

                /// <summary>
                /// Constant for the value AllWindowsComputers
                /// </summary>
                public const string AllWindowsComputers = "All Windows Computers";
            }

            /// <summary>
            /// Class to contain constant values for var-map records
            /// TimeRange
            public sealed class TimeRange
            {
                /// <summary>
                /// Constant for the value WithinRange
                /// </summary>
                public const string WithinRange = "WithinRange";

                /// <summary>
                /// Constant for the value WithinLast
                /// </summary>
                public const string WithinLast = "WithinLast";

                /// <summary>
                /// Constant for the value Before
                /// </summary>
                public const string Before = "Before";

                /// <summary>
                /// Constant for the value After
                /// </summary>
                public const string After = "After";
            }
        }
    }
}