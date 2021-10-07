// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ObjectOrInstanceSearchDialog.cs">
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
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the base functionality of the Object Search 
    /// Dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 21-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class ObjectOrInstanceSearchDialog : Mom.Test.UI.Core.Console.Administration.PickerDialogBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Reference to the parent application.
        /// </param>
        public ObjectOrInstanceSearchDialog(ConsoleApp app)
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
                ";Object Search" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerDialog" +
                ";$this.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableObjects 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAvailableObjects =
                ";Available objects:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AvailableObjectsCaptionText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedObjects 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSelectedObjects =
                ";Selected objects:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SelectedObjectsCaptionText";

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
            /// AvailableObjects
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAvailableObjects;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// SelectedObjects
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSelectedObjects;

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
            /// Exposes access to the AvailableObjects translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 21-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AvailableObjects
            {
                get
                {
                    if ((cachedAvailableObjects == null))
                    {
                        cachedAvailableObjects =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAvailableObjects);
                    }

                    return cachedAvailableObjects;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedObjects translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 21-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SelectedObjects
            {
                get
                {
                    if ((cachedSelectedObjects == null))
                    {
                        cachedSelectedObjects =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSelectedObjects);
                    }

                    return cachedSelectedObjects;
                }
            }

            #endregion
        }

        #endregion
    }
}
