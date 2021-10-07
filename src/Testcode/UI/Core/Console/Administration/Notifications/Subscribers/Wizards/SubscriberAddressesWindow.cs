// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SubscriberAddressesWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  22-AUG-08   Created
//  [KellyMor]  27-AUG-08   Added click methods for schedules list toolbar
//  [KellyMor]  23-SEP-08   Updated control ID's.
//                          Updated resource strings.
//  [KellyMor}  27-SEP-08   Updated resource string for wizard window title
//                          Updated navigation link resource string.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - ISubscriberAddressesWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISubscriberAddressesWindow, for 
    /// SubscriberAddressesWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 22-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISubscriberAddressesWindow
    {
        /// <summary>
        /// Read-only property to access AddressesListToolStrip
        /// </summary>
        ToolStrip AddressesListToolStrip
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddressesListView
        /// </summary>
        ListView AddressesListView
        {
            get;
        }
    }

    #endregion Interface Definition - ISubscriberAddressesWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Subscriber Addresses setp
    /// in the Subscriber Wizard.
    /// </summary>
    /// <history>
    ///     [KellyMor] 22-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class SubscriberAddressesWindow :
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase,
        ISubscriberAddressesWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members

        /// <summary>
        /// Cache to hold a reference to AddressesListToolStrip of type ToolStrip
        /// </summary>
        private ToolStrip cachedAddressesListToolStrip;

        /// <summary>
        /// Cache to hold a reference to AddressesListView of type ListView
        /// </summary>
        private ListView cachedAddressesListView;

        #endregion
                
        #region Constructors

        /// -----------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Owner of ConsoleWizardBase of type ConsoleApp
        /// </param>
        /// <history>
        ///     [KellyMor] 22-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------
        public SubscriberAddressesWindow(ConsoleApp app)
            : base(app, Strings.SubscriberWizardTitle)
        {
            // Add constructor logic
        }

        #endregion Constructors

        #region Interface Control Properties

        #region ISubscriberAddressesWindow Controls Property

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
        public new ISubscriberAddressesWindow Controls
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
        /// 	[KellyMor] 22-AUG-08 Created
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
        ///  Exposes access to the AddressesListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ListView ISubscriberAddressesWindow.AddressesListView
        {
            get
            {
                if ((this.cachedAddressesListView == null))
                {
                    this.cachedAddressesListView =
                        new ListView(
                            this,
                            SubscriberAddressesWindow.ControlIDs.AddressesListView);
                }

                return this.cachedAddressesListView;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddressesListToolStrip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ToolStrip ISubscriberAddressesWindow.AddressesListToolStrip
        {
            get
            {
                if ((this.cachedAddressesListToolStrip == null))
                {
                    this.cachedAddressesListToolStrip = new ToolStrip(this);
                }

                return this.cachedAddressesListToolStrip;
            }
        }

        #endregion

        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Add" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 27-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddressesListToolStrip.ToolStripItems[0].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Edit" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 27-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.AddressesListToolStrip.ToolStripItems[1].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Remove" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 27-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.AddressesListToolStrip.ToolStripItems[2].Click();
        }

        #endregion

        #region Strings

        /// -------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class Strings
        {
            #region Constants

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriberWizardTitle =
                ";Notification Subscriber Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriberWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Instruction label
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceInstructions =
                ";Associating specific addresses with notification schedules allows subscribers to be contacted when and where they are available. For example, a subscriber could be notified using E-mail between 9 AM and 5 PM, then notified using text messaging outside of those hours." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.RecipientDevicePage" +
                ";titleLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddToolStripItem
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceAddToolStripItem =
                ";A&dd" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.RecipientDevicePage" +
                ";addButton.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EditToolStripItem
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceEditToolStripItem =
                ";&Edit" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.RecipientDevicePage" +
                ";editButton.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemoveToolStripItem
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceRemoveToolStripItem =
                ";&Remove" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.RecipientDevicePage" +
                ";removeButton.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Addresses  navigation link 
            /// label
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkAddresses =
                ";Addresses" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";RecipientWizardAddressPageNavigationText";

            #endregion Constants

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Subscriber window title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAddToolStripItem;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EditToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedEditToolStripItem;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RemoveToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedRemoveToolStripItem;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Instructions 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstructions;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the NavigationLinkAddresses link 
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkAddresses;

            #endregion

            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriberWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriberWizardTitle
            {
                get
                {
                    if ((cachedSubscriberWizardTitle == null))
                    {
                        cachedSubscriberWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscriberWizardTitle);
                    }

                    return cachedSubscriberWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AddToolStripItem
            {
                get
                {
                    if ((cachedAddToolStripItem == null))
                    {
                        cachedAddToolStripItem =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAddToolStripItem);
                    }

                    return cachedAddToolStripItem;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EditToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string EditToolStripItem
            {
                get
                {
                    if ((cachedEditToolStripItem == null))
                    {
                        cachedEditToolStripItem =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEditToolStripItem);
                    }

                    return cachedEditToolStripItem;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RemoveToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string RemoveToolStripItem
            {
                get
                {
                    if ((cachedRemoveToolStripItem == null))
                    {
                        cachedRemoveToolStripItem =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRemoveToolStripItem);
                    }

                    return cachedRemoveToolStripItem;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instructions 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Instructions
            {
                get
                {
                    if ((cachedInstructions == null))
                    {
                        cachedInstructions =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceInstructions);
                    }

                    return cachedInstructions;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NavigationLinkAddresses translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkAddresses
            {
                get
                {
                    if ((cachedNavigationLinkAddresses == null))
                    {
                        cachedNavigationLinkAddresses =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNavigationLinkAddresses);
                    }

                    return cachedNavigationLinkAddresses;
                }
            }

            #endregion Properties
        }

        #endregion Strings

        #region Control ID's

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for AddressesListToolStrip
            /// </summary>
            public const string AddressesListToolStrip = "toolStrip";

            /// <summary>
            /// Control ID for AddressesListView
            /// </summary>
            public const string AddressesListView = "deviceList";
        }

        #endregion
    }
}
