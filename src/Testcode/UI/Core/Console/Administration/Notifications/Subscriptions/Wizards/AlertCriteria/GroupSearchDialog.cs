// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GroupSearchDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor] 21-OCT-08 Created
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards.AlertCriteria
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the base functionality of the Groups Search 
    /// Dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 21-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class GroupSearchDialog : Mom.Test.UI.Core.Console.Administration.PickerDialogBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Reference to the parent application.
        /// </param>
        public GroupSearchDialog(ConsoleApp app)
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
        /// 	[KellyMor] 21-OCT-08 Created
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
                ";Group Search" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.GroupPickerDialog" +
                ";$this.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableGroups 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAvailableGroups =
                ";Available groups:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AvailableGroupsCaptionText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedGroups 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSelectedGroups =
                ";Selected groups:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SelectedGroupsCaptionText";

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
            /// AvailableGroups
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAvailableGroups;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// SelectedGroups
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSelectedGroups;

            #endregion

            #region Public Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 21-OCT-08 Created
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
            /// Exposes access to the AvailableGroups translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 21-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AvailableGroups
            {
                get
                {
                    if ((cachedAvailableGroups == null))
                    {
                        cachedAvailableGroups =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAvailableGroups);
                    }

                    return cachedAvailableGroups;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedGroups translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 21-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SelectedGroups
            {
                get
                {
                    if ((cachedSelectedGroups == null))
                    {
                        cachedSelectedGroups =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSelectedGroups);
                    }

                    return cachedSelectedGroups;
                }
            }

            #endregion
        }

        #endregion
    }
}
