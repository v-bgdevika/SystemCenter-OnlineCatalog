// ------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SubscriptionSummaryWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  07-OCT-08   Created
// </history>
// ------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - ISubscriptionSummaryWindow

    /// -------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISubscriptionSummaryWindow, for 
    /// SubscriptionSummaryWindow. Defines properties for accessing UI 
    /// controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 07-OCT-08 Created
    /// </history>
    /// -------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISubscriptionSummaryWindow
    {
        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EnableThisNotificationSubscriptionCheckBox
        /// </summary>
        CheckBox EnableThisNotificationSubscriptionCheckBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConfirmNotificationSubscriptionSettingsStaticControl
        /// </summary>
        StaticControl ConfirmNotificationSubscriptionSettingsStaticControl
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

    /// -------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the subscription summary page
    /// </summary>
    /// <history>
    /// 	[KellyMor] 07-OCT-08 Created
    /// </history>
    /// -------------------------------------------------------------------
    public class SubscriptionSummaryWindow : 
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, 
        ISubscriptionSummaryWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;

        /// <summary>
        /// Cache to hold a reference to EnableThisNotificationSubscriptionCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnableThisNotificationSubscriptionCheckBox;

        /// <summary>
        /// Cache to hold a reference to ConfirmNotificationSubscriptionSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfirmNotificationSubscriptionSettingsStaticControl;

        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl2;

        #endregion
        
        #region Constructors

        /// ---------------------------------------------------------------
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
        /// 	[KellyMor] 24-SEP-08 Created
        ///     [KellyMor] 08-OCT-08 Added parameter to determine if the wizard
        ///                          is open in new or edit mode.
        /// </history>
        /// ---------------------------------------------------------------
        public SubscriptionSummaryWindow(MomConsoleApp ownerWindow, bool editExisting)
            : base(ownerWindow, (editExisting ? Strings.ModifyWindowTitle : Strings.WindowTitle))
        {
            // Add Constructor logic here. 
        }

        #endregion
 
        #region Interface Control Properties

        #region ISubscriptionSummaryWindow Controls Property

        /// ---------------------------------------------------------------
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
        /// ---------------------------------------------------------------
        public new ISubscriptionSummaryWindow Controls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IConsoleWizardBase Controls Property

        /// ---------------------------------------------------------------
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
        /// ---------------------------------------------------------------
        public Mom.Test.UI.Core.Console.Administration.IConsoleWizardBase BaseControls
        {
            get
            {
                return base.Controls;
            }
        }

        #endregion

        #endregion

        #region Checkbox Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox EnableThisNotificationSubscription
        /// </summary>
        /// <history>
        /// 	[KellyMor] 07-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual bool EnableThisNotificationSubscription
        {
            get
            {
                return this.Controls.EnableThisNotificationSubscriptionCheckBox.Checked;
            }

            set
            {
                this.Controls.EnableThisNotificationSubscriptionCheckBox.Checked = value;
            }
        }

        #endregion

        #region Text Field Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <history>
        /// 	[KellyMor] 07-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }

            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 07-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        TextBox ISubscriptionSummaryWindow.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = 
                        new TextBox(
                            this, 
                            SubscriptionSummaryWindow.ControlIDs.DescriptionTextBox);
                }

                return this.cachedDescriptionTextBox;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnableThisNotificationSubscriptionCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 07-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        CheckBox ISubscriptionSummaryWindow.EnableThisNotificationSubscriptionCheckBox
        {
            get
            {
                if ((this.cachedEnableThisNotificationSubscriptionCheckBox == null))
                {
                    this.cachedEnableThisNotificationSubscriptionCheckBox = 
                        new CheckBox(
                            this, 
                            SubscriptionSummaryWindow.ControlIDs.EnableThisNotificationSubscriptionCheckBox);
                }

                return this.cachedEnableThisNotificationSubscriptionCheckBox;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfirmNotificationSubscriptionSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 07-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionSummaryWindow.ConfirmNotificationSubscriptionSettingsStaticControl
        {
            get
            {
                if ((this.cachedConfirmNotificationSubscriptionSettingsStaticControl == null))
                {
                    this.cachedConfirmNotificationSubscriptionSettingsStaticControl = 
                        new StaticControl(
                            this, 
                            SubscriptionSummaryWindow.ControlIDs.ConfirmNotificationSubscriptionSettingsStaticControl);
                }

                return this.cachedConfirmNotificationSubscriptionSettingsStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 07-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionSummaryWindow.SummaryStaticControl2
        {
            get
            {
                if ((this.cachedSummaryStaticControl2 == null))
                {
                    this.cachedSummaryStaticControl2 = 
                        new StaticControl(
                            this, 
                            SubscriptionSummaryWindow.ControlIDs.SummaryStaticControl2);
                }

                return this.cachedSummaryStaticControl2;
            }
        }

        #endregion

        #region Click Methods

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EnableThisNotificationSubscription
        /// </summary>
        /// <history>
        /// 	[KellyMor] 07-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual void ClickEnableThisNotificationSubscription()
        {
            this.Controls.EnableThisNotificationSubscriptionCheckBox.Click();
        }

        #endregion

        #region Strings Class

        /// ---------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 07-OCT-08 Created
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
            /// Contains resource string for:  EnableThisNotificationSubscription
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceEnableThisNotificationSubscription =
                ";&Enable this notification subscription" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSummaryPage" + 
                ";enableSubscriptionChkBox.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfirmNotificationSubscriptionSettings
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceConfirmNotificationSubscriptionSettings =
                ";Confirm notification subscription settings" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSummaryPage" +
                ";pageSectionLabel1.Text";
    
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
            /// Caches the translated resource string for:  EnableThisNotificationSubscription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedEnableThisNotificationSubscription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfirmNotificationSubscriptionSettings
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedConfirmNotificationSubscriptionSettings;
            
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
                        cachedWindowTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWindowTitle);
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
                        cachedNavigationLinkSummary = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNavigationLinkSummary);
                    }

                    return cachedNavigationLinkSummary;
                }
            }

            /// -------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnableThisNotificationSubscription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 07-OCT-08 Created
            /// </history>
            /// -------------------------------------------------------------------------
            public static string EnableThisNotificationSubscription
            {
                get
                {
                    if ((cachedEnableThisNotificationSubscription == null))
                    {
                        cachedEnableThisNotificationSubscription = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEnableThisNotificationSubscription);
                    }

                    return cachedEnableThisNotificationSubscription;
                }
            }

            /// -------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfirmNotificationSubscriptionSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 07-OCT-08 Created
            /// </history>
            /// -------------------------------------------------------------------------
            public static string ConfirmNotificationSubscriptionSettings
            {
                get
                {
                    if ((cachedConfirmNotificationSubscriptionSettings == null))
                    {
                        cachedConfirmNotificationSubscriptionSettings = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceConfirmNotificationSubscriptionSettings);
                    }

                    return cachedConfirmNotificationSubscriptionSettings;
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
        /// 	[KellyMor] 07-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "summaryBox";

            /// <summary>
            /// Control ID for EnableThisNotificationSubscriptionCheckBox
            /// </summary>
            public const string EnableThisNotificationSubscriptionCheckBox = "enableSubscriptionChkBox";

            /// <summary>
            /// Control ID for ConfirmNotificationSubscriptionSettingsStaticControl
            /// </summary>
            public const string ConfirmNotificationSubscriptionSettingsStaticControl = "pageSectionLabel1";

            /// <summary>
            /// Control ID for SummaryStaticControl2
            /// </summary>
            public const string SummaryStaticControl2 = "headerLabel";
        }

        #endregion
    }
}
