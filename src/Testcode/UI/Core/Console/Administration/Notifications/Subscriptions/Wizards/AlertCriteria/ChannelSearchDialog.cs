// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ChannelSearchDialog.cs">
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
    /// Class to encapsulate the base functionality of the Channels Search
    /// Dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 04-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class ChannelSearchDialog : Mom.Test.UI.Core.Console.Administration.PickerDialogBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Reference to the parent application.
        /// </param>
        public ChannelSearchDialog(ConsoleApp app)
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
                ";Channel Search" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ChannelPickerDialog" +
                ";$this.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableChannels
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAvailableChannels =
                ";Available channels:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AvailableChannelsCaptionText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedChannels
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSelectedChannels =
                ";Selected channels:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SelectedChannelsCaptionText";

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
            /// AvailableChannels
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAvailableChannels;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedChannels
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSelectedChannels;

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
            public static string AvailableChannels
            {
                get
                {
                    if ((cachedAvailableChannels == null))
                    {
                        cachedAvailableChannels =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAvailableChannels);
                    }
                    return cachedAvailableChannels;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedChannels translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SelectedChannels
            {
                get
                {
                    if ((cachedSelectedChannels == null))
                    {
                        cachedSelectedChannels = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSelectedChannels);
                    }
                    return cachedSelectedChannels;
                }
            }

            #endregion
        }

        #endregion
    }
}