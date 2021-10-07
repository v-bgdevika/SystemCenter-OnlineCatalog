// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ClassSearchDialog.cs">
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
    /// Class to encapsulate the base functionality of the Class Search Dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 21-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class ClassSearchDialog : Mom.Test.UI.Core.Console.Administration.PickerDialogBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Reference to the parent application.
        /// </param>
        public ClassSearchDialog(ConsoleApp app)
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
                ";Class Search" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ClassPickerDialog" +
                ";$this.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableClasses 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAvailableClasses =
                ";Available classes:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AvailableClassesCaptionText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedClasses 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSelectedClasses =
                ";Selected classes:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SelectedClassesCaptionText";

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
            /// AvailableClasses
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAvailableClasses;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// SelectedClasses
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSelectedClasses;

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
            /// Exposes access to the AvailableClasses translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 21-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AvailableClasses
            {
                get
                {
                    if ((cachedAvailableClasses == null))
                    {
                        cachedAvailableClasses =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAvailableClasses);
                    }

                    return cachedAvailableClasses;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedClasses translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 21-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SelectedClasses
            {
                get
                {
                    if ((cachedSelectedClasses == null))
                    {
                        cachedSelectedClasses =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSelectedClasses);
                    }

                    return cachedSelectedClasses;
                }
            }

            #endregion
        }

        #endregion
    }
}
