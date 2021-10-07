// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SubscriberSearchDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor] 04-OCT-08 Created
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards.AlertCriteria
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the base functionality of the Subscriber Search
    /// Dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 04-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class SubscriberSearchDialog : Mom.Test.UI.Core.Console.Administration.PickerDialogBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Reference to the parent application.
        /// </param>
        public SubscriberSearchDialog(ConsoleApp app)
            : base(app, Strings.DialogTitle)
        {
            // default constructor
        }

        #endregion

        #region Strings

        /// -------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class Strings
        {
            #region Resource Constants

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDialogTitle =
                ";Subscriber Search" + 
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.SubscriberPickerDialog" +
                ";$this.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableSubscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAvailableSubscribers =
                ";Available subscribers:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AvailableSubscribersCaptionText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedSubscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSelectedSubscribers =
                ";Selected subscribers:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SelectedSubscribersCaptionText";
            
            #endregion

            #region Cached Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDialogTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// AvailableSubscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAvailableSubscribers;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedSubscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSelectedSubscribers;

            #endregion

            #region Public Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AvailableItems translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AvailableSubscribers
            {
                get
                {
                    if ((cachedAvailableSubscribers == null))
                    {
                        cachedAvailableSubscribers = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAvailableSubscribers);
                    }
                    return cachedAvailableSubscribers;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedSubscribers translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SelectedSubscribers
            {
                get
                {
                    if ((cachedSelectedSubscribers == null))
                    {
                        cachedSelectedSubscribers = CoreManager.MomConsole.GetIntlStr(ResourceSelectedSubscribers);
                    }
                    return cachedSelectedSubscribers;
                }
            }

            #endregion
        }

        #endregion
    }
}
