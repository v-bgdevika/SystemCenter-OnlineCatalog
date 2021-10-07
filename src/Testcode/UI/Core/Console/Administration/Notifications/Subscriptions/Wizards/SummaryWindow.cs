// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SummaryWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  24-SEP-08   Created
//  [KellyMor]  07-OCT-08   Updated class header comment.
//                          Updated resource string for navigation link
//  [KellyMor]  08-OCT-08   Updated control ID for result label
//                          Updated resources strings for successful or failed
//                          save operation.
//  [KellyMor]  08-OCT-08   Added string resource for "Modify..." wizard title
//                          Modified constructor to take a flag indicating which
//                          wizard title to use, i.e. open in edit mode or not.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISummaryWindow

    /// ---------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISummaryWindow, for SummaryWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 25-SEP-08 Created
    /// </history>
    /// ---------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISummaryWindow
    {
        /// <summary>
        /// Read-only property to access ChannelCompleteStaticControl
        /// </summary>
        StaticControl ChannelCompleteStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExitWizardStaticControl
        /// </summary>
        StaticControl ExitWizardStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ResultsStaticControl
        /// </summary>
        StaticControl ResultsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ErrorDetailsStaticControl
        /// </summary>
        StaticControl ErrorDetailsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SummaryStaticControl2
        /// </summary>
        StaticControl SummaryStaticControl2
        {
            get;
        }
    }

    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the subscription wizard summary window.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 25-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class SummaryWindow : 
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, 
        ISummaryWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
       
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ChannelCompleteStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedChannelCompleteStaticControl;

        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to ExitWizardStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedExitWizardStaticControl;

        /// <summary>
        /// Cache to hold a reference to cachedResultsStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedResultsStaticControl;

        /// <summary>
        /// Cache to hold a reference to cachedErrorDetailsStaticControlof type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedErrorDetailsStaticControl;

        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl2;

        #endregion
        
        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of SummaryWindow of type MomConsoleApp
        /// </param>
        /// <param name="editExisting">
        /// Flag indicating if this wizard window is displaying a new 
        /// subscription or opening an existing one in edit mode.
        /// </param>
        /// <history>
        /// 	[KellyMor] 25-SEP-08 Created
        ///     [KellyMor] 08-OCT-08 Added parameter to determine if the wizard
        ///                          is open in new or edit mode.
        /// </history>
        /// -------------------------------------------------------------------
        public SummaryWindow(MomConsoleApp ownerWindow, bool editExisting) : 
                base(ownerWindow, (editExisting ? Strings.ModifyWindowTitle : Strings.WindowTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
 
        #region Interface Control Properties

        #region ISummaryWindow Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new ISummaryWindow Controls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IConsoleWizardBase Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for the base class of the 
        /// dialog.
        /// </summary>
        /// <value>
        /// An interface that groups all of the base class dialog's control 
        /// properties together.
        /// </value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public Mom.Test.UI.Core.Console.Administration.IConsoleWizardBase BaseControls
        {
            get
            {
                return base.Controls;
            }
        }

        #endregion

        #endregion

        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelCompleteStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.ChannelCompleteStaticControl
        {
            get
            {
                if (null == this.cachedChannelCompleteStaticControl)
                {
                    this.cachedChannelCompleteStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.ChannelCompleteStaticControl);
                }

                return this.cachedChannelCompleteStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.DescriptionStaticControl
        {
            get
            {
                if (null == this.cachedDescriptionStaticControl)
                {
                    this.cachedDescriptionStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.DescriptionStaticControl);
                }

                return this.cachedDescriptionStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExitWizardStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.ExitWizardStaticControl
        {
            get
            {
                if (null == this.cachedExitWizardStaticControl)
                {
                    this.cachedExitWizardStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.ExitWizardStaticControl);
                }

                return this.cachedExitWizardStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResultsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.ResultsStaticControl
        {
            get
            {              
                if (null == this.cachedResultsStaticControl)
                {
                    CoreManager.MomConsole.Waiters.WaitForWindowAppeared(this, new QID(";[UIA]AutomationId='" + ControlIDs.ResultsStaticControl + "'")
, Core.Console.ConsoleConstants.DefaultControlTimeout);
                    this.cachedResultsStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.ResultsStaticControl);
                }

                return this.cachedResultsStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISummaryWindow.ErrorDetailsStaticControl
        {
            get
            {
                if (this.cachedErrorDetailsStaticControl == null)
                {
                    this.cachedErrorDetailsStaticControl =
                        new StaticControl(
                            this,
                            ControlIDs.ErrorDetailsStaticControl);
                }

                return this.cachedErrorDetailsStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISummaryWindow.SummaryStaticControl2
        {
            get
            {
                if ((this.cachedSummaryStaticControl2 == null))
                {
                    this.cachedSummaryStaticControl2 = new StaticControl(this, SummaryWindow.ControlIDs.SummaryStaticControl2);
                }
                
                return this.cachedSummaryStaticControl2;
            }
        }

        #endregion
       
        #region Strings Class

        /// ---------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new class Strings
        {
            #region Constants

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceWindowTitle =
                ";Notification Subscription Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceModifyWindowTitle =
                ";Modify Notification Subscription Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionWizardTitleEdit";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NavigationLinkSummary
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkSummary =
                ";Summary" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSummaryPage" +
                ";$this.NavigationText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the ExitSubscriptionWizard label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceExitSubscriptionWizard =
                ";To exit the wizard click Close." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SMTPChannelCompletionPage" +
                ";label3.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the SubscriberSavedSuccessfully
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriptionSavedSuccessfully =
                ";Subscription saved successfully." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionSaved";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the SubscriberSaveFailed label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriptionSaveFailed =
                ";Failed to save the notification subscription.\n{0}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionSaveError";

            #endregion
            
            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWindowTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedModifyWindowTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NavigationLinkSummary
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkSummary;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExitSubscriptionWizard 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedExitSubscriptionWizard;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SubscriptionSavedSuccessfully 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriptionSavedSuccessfully;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SubscriptionSaveFailed 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriptionSaveFailed;

            #endregion
            
            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    
                    return cachedWindowTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ModifyWindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ModifyWindowTitle
            {
                get
                {
                    if ((cachedModifyWindowTitle == null))
                    {
                        cachedModifyWindowTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceModifyWindowTitle);
                    }

                    return cachedModifyWindowTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NavigationLinkSummary translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkSummary
            {
                get
                {
                    if ((cachedNavigationLinkSummary == null))
                    {
                        cachedNavigationLinkSummary = CoreManager.MomConsole.GetIntlStr(ResourceNavigationLinkSummary);
                    }
                    
                    return cachedNavigationLinkSummary;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExitSubscriptionWizard translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ExitSubscriptionWizard
            {
                get
                {
                    if ((cachedExitSubscriptionWizard == null))
                    {
                        cachedExitSubscriptionWizard = CoreManager.MomConsole.GetIntlStr(ResourceExitSubscriptionWizard);
                    }

                    return cachedExitSubscriptionWizard;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriptionSavedSuccessfully translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriptionSavedSuccessfully
            {
                get
                {
                    if ((cachedSubscriptionSavedSuccessfully == null))
                    {
                        cachedSubscriptionSavedSuccessfully = CoreManager.MomConsole.GetIntlStr(ResourceSubscriptionSavedSuccessfully);
                    }

                    return cachedSubscriptionSavedSuccessfully;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriptionSaveFailed translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriptionSaveFailed
            {
                get
                {
                    if ((cachedSubscriptionSaveFailed == null))
                    {
                        cachedSubscriptionSaveFailed = CoreManager.MomConsole.GetIntlStr(ResourceSubscriptionSaveFailed);
                    }

                    return cachedSubscriptionSaveFailed;
                }
            }
            
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// ---------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for ChannelCompleteStaticControl
            /// </summary>
            public const string ChannelCompleteStaticControl = "pageSectionLabel";

            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "label2";

            /// <summary>
            /// Control ID for ExitWizardStaticControl
            /// </summary>
            public const string ExitWizardStaticControl = "label3";

            /// <summary>
            /// Control ID for ResultsStaticControl
            /// </summary>
            public const string ResultsStaticControl = "resultText";

            /// <summary>
            /// Control ID for ErrorDetailsStaticControl
            /// </summary>
            public const string ErrorDetailsStaticControl = "errorLinkLabel";

            /// <summary>
            /// Control ID for SummaryStaticControl2
            /// </summary>
            public const string SummaryStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
