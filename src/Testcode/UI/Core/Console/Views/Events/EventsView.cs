//-------------------------------------------------------------------
// <copyright file="EventsView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Events View support
// </summary>
//  <history>
//   [mbickle] 02DEC04: Created
//  </history>
//  <history>
//   [lucyra] 08NOV07: Added constructor and content
//  </history>
//  <history>
//   [lucyra] 09NOV07: Added support for Events view criteria dialogs
//   [kellymor] 29MAY08: Added resource for "Show associated rule properties"
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.Events
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    using Maui.Core.Utilities;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Console.GlobalSettings;
    #endregion

    /// <summary>
    /// Events View
    /// </summary>
    public class EventsView
    {
        #region Private Member Variables

        // Timeout
        private const int Timeout = 3000;

        private const int MaxWait = 60;

        #endregion

        #region Private Members

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;

        #endregion

        #region Constructor

        /// <summary>
        /// Events View
        /// </summary>
        public EventsView()
        {
            this.consoleApp = CoreManager.MomConsole; 
        }

        #endregion

        #region Properties

        #endregion

        #region Strings Class

        /// <summary>
        /// Strings Class
        /// </summary>
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains resource string for: Event view crtieria: specific
            /// </summary>   
            private const string ResourceEventViewCriteriaSpecificString =
                "specific";

            /// <summary>
            /// Contains resource string for: Event view crtieria: Event Number Dialog Title
            /// </summary>   
            private const string ResourceEventNumberDialogTitle =
                "Event number";

            /// <summary>
            /// Contains resource string for: Event view crtieria: Logging Computer Dialog Title
            /// </summary>   
            private const string ResourceLoggingComputerDialogTitle =
                "Logging Computer";

            /// <summary>
            /// Contains resource string for: Event view crtieria: Object Name Dialog Title
            /// </summary>   
            private const string ResourceObjectNameDialogTitle =
                "Object Name";

            /// <summary>
            /// Contains resource string for: Event view crtieria: Source Name Dialog Title
            /// </summary>   
            private const string ResourceSourceNameDialogTitle =
                "Source Name";

            /// <summary>
            /// Contains resource string for: Event view crtieria: User Dialog Title
            /// </summary>   
            private const string ResourceUserDialogTitle =
                "User";

            /// <summary>
            /// Contains resource string for: Show Associated Rule Properties Actions context menu
            /// </summary>
            private const string ResourceShowAssociatedRulePropertiesContextMenu =
                ";Show associated rule properties..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.EventResources" +
                ";RulePropertiesCommand";

            #endregion

            #region Member Variables

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedEventViewCriteriaSpecificString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventViewCriteriaSpecificString;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedEventNumberDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventNumberDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedLoggingComputerDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLoggingComputerDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedObjectNameDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectNameDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedSourceNameDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSourceNameDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedUserDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedShowAssociatedRulePropertiesContextMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowAssociatedRulePropertiesContextMenu;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event view criteria "specific" String
            /// </summary>
            /// <history>
            /// 	[lucyra] 06NOV07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventViewCriteriaSpecificString
            {
                get
                {
                    if ((cachedEventViewCriteriaSpecificString == null))
                    {
                        cachedEventViewCriteriaSpecificString =
                            CoreManager.MomConsole.GetIntlStr(ResourceEventViewCriteriaSpecificString);
                    }

                    return cachedEventViewCriteriaSpecificString;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event view criteria "EventNumberDialogTitle" String
            /// </summary>
            /// <history>
            /// 	[lucyra] 17DEC07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventNumberDialogTitle
            {
                get
                {
                    if ((cachedEventNumberDialogTitle == null))
                    {
                        cachedEventNumberDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceEventNumberDialogTitle);
                    }

                    return cachedEventNumberDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event view criteria "LoggingComputerDialogTitle" String
            /// </summary>
            /// <history>
            /// 	[lucyra] 17DEC07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LoggingComputerDialogTitle
            {
                get
                {
                    if ((cachedLoggingComputerDialogTitle == null))
                    {
                        cachedLoggingComputerDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceLoggingComputerDialogTitle);
                    }

                    return cachedLoggingComputerDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event view criteria "ObjectNameDialogTitle" String
            /// </summary>
            /// <history>
            /// 	[lucyra] 17DEC07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectNameDialogTitle
            {
                get
                {
                    if ((cachedObjectNameDialogTitle == null))
                    {
                        cachedObjectNameDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceObjectNameDialogTitle);
                    }

                    return cachedObjectNameDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event view criteria "SourceNameDialogTitle" String
            /// </summary>
            /// <history>
            /// 	[lucyra] 17DEC07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SourceNameDialogTitle
            {
                get
                {
                    if ((cachedSourceNameDialogTitle == null))
                    {
                        cachedSourceNameDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceSourceNameDialogTitle);
                    }

                    return cachedSourceNameDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event view criteria "UserDialogTitle" String
            /// </summary>
            /// <history>
            /// 	[lucyra] 17DEC07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserDialogTitle
            {
                get
                {
                    if ((cachedUserDialogTitle == null))
                    {
                        cachedUserDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceUserDialogTitle);
                    }

                    return cachedUserDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowAssociatedRulePropertiesContextMenu String
            /// </summary>
            /// <history>
            /// 	[kellymor] 29MAY08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowAssociatedRulePropertiesContextMenu
            {
                get
                {
                    if ((cachedShowAssociatedRulePropertiesContextMenu == null))
                    {
                        cachedShowAssociatedRulePropertiesContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceShowAssociatedRulePropertiesContextMenu);
                    }

                    return cachedShowAssociatedRulePropertiesContextMenu;
                }
            }

            #endregion

        }

        #endregion

    }
}
