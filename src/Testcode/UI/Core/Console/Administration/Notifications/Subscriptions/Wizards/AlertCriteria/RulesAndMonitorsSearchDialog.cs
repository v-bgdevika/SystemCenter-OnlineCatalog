// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RulesAndMonitorsSearchDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  04-OCT-08   Created
//  [KellyMor]  21-OCT-08   StyleCop fixes.
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
    /// Class to encapsulate the base functionality of the Rules And Monitors
    /// Search Dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 04-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class RulesAndMonitorsSearchDialog : Mom.Test.UI.Core.Console.Administration.PickerDialogBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Reference to the parent application.
        /// </param>
        public RulesAndMonitorsSearchDialog(ConsoleApp app)
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
                ";Monitor and Rule Search" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.MonitorAndRulePickerDialog" +
                ";$this.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableRulesAndMonitors
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAvailableRulesAndMonitors =
                ";Available rules and monitors:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AvailableElementCaptionText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedRulesAndMonitors
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSelectedRulesAndMonitors =
                ";Selected rules and monitors:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SelectedElementCaptionText";

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
            /// AvailableRulesAndMonitors
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAvailableRulesAndMonitors;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// SelectedRulesAndMonitors
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSelectedRulesAndMonitors;

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
            public static string AvailableRulesAndMonitors
            {
                get
                {
                    if ((cachedAvailableRulesAndMonitors == null))
                    {
                        cachedAvailableRulesAndMonitors =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAvailableRulesAndMonitors);
                    }

                    return cachedAvailableRulesAndMonitors;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedRulesAndMonitors translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 04-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SelectedRulesAndMonitors
            {
                get
                {
                    if ((cachedSelectedRulesAndMonitors == null))
                    {
                        cachedSelectedRulesAndMonitors =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSelectedRulesAndMonitors);
                    }

                    return cachedSelectedRulesAndMonitors;
                }
            }

            #endregion
        }

        #endregion
    }
}