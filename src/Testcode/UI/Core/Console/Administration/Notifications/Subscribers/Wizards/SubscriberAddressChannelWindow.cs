// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SubscriberAddressChannelWindow.cs">
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
//  [KellyMor]  12-SEP-08   Updated control ID's and resource strings.
//  [KellyMor]  25-SEP-08   Modified to add new combo-box for command channels
//                          list.
//                          Added resource string for channel type combo-box
//                          items.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - ISubscriberAddressChannelWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISubscriberAddressChannelWindow, for 
    /// SubscriberAddressChannelWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 22-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISubscriberAddressChannelWindow
    {
        /// <summary>
        /// Read-only property to access ChannelStaticControl
        /// </summary>
        StaticControl ChannelStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ChannelComboBox
        /// </summary>
        ComboBox ChannelComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DeliveryAddressTextBox
        /// </summary>
        TextBox DeliveryAddressTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DeliveryAddressStaticControl
        /// </summary>
        StaticControl DeliveryAddressStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CommandChannelListComboBox
        /// </summary>
        ComboBox CommandChannelListComboBox
        {
            get;
        }
    }

    #endregion Interface Definition - ISubscriberAddressChannelWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Name step Create 
    /// Subscriber Address Wizard.
    /// </summary>
    /// <history>
    ///     [KellyMor] 22-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class SubscriberAddressChannelWindow :
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase,
        ISubscriberAddressChannelWindow
    {       
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members
        
        /// <summary>
        /// Cache to hold a reference to ChannelComboBox of type TextBox
        /// </summary>
        private ComboBox cachedChannelComboBox;

        /// <summary>
        /// Cache to hold a reference to ChannelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChannelStaticControl;

        /// <summary>
        /// Cache to hold a reference to DeliveryAddressTextBox of type TextBox
        /// </summary>
        private TextBox cachedDeliveryAddressTextBox;

        /// <summary>
        /// Cache to hold a reference to DeliveryAddressStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDeliveryAddressStaticControl;

        /// <summary>
        /// Cache to hold a reference to CommandChannelListComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedCommandChannelListComboBox;

        #endregion Private Members

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
        public SubscriberAddressChannelWindow(ConsoleApp app)
            : base(app, Strings.SubscriberAddressWizardTitle)
        {
            // Add constructor logic
        }

        #endregion Constructors

        #region Interface Control Properties

        #region ISubscriberAddressChannelWindow Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new ISubscriberAddressChannelWindow Controls
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

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DeliveryAddressTextBox
        /// </summary>
        /// <history>
        /// 	[KellyMor] 26-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DeliveryAddressText
        {
            get
            {
                return this.Controls.DeliveryAddressTextBox.Text;
            }

            set
            {
                this.Controls.DeliveryAddressTextBox.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ComboBox ISubscriberAddressChannelWindow.ChannelComboBox
        {
            get
            {
                if (null == this.cachedChannelComboBox)
                {
                    this.cachedChannelComboBox =
                        new ComboBox(
                            this,
                            ControlIDs.ChannelComboBox);
                }

                return this.cachedChannelComboBox;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISubscriberAddressChannelWindow.ChannelStaticControl
        {
            get
            {
                if (null == this.cachedChannelStaticControl)
                {
                    this.cachedChannelStaticControl =
                        new StaticControl(
                            this.AccessibleObject.Window,
                            ControlIDs.ChannelStaticControl);
                }

                return this.cachedChannelStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeliveryAddressTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        TextBox ISubscriberAddressChannelWindow.DeliveryAddressTextBox
        {
            get
            {
                if (null == this.cachedDeliveryAddressTextBox)
                {
                    this.cachedDeliveryAddressTextBox =
                        new TextBox(
                            this,
                            ControlIDs.DeliveryAddressTextBox);
                }

                return this.cachedDeliveryAddressTextBox;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeliveryAddressStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ISubscriberAddressChannelWindow.DeliveryAddressStaticControl
        {
            get
            {
                if (null == this.cachedDeliveryAddressStaticControl)
                {
                    this.cachedDeliveryAddressStaticControl =
                        new StaticControl(
                            this.AccessibleObject.Window,
                            ControlIDs.DeliveryAddressStaticControl);
                }

                return this.cachedDeliveryAddressStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommandChannelListComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ComboBox ISubscriberAddressChannelWindow.CommandChannelListComboBox
        {
            get
            {
                if (null == this.cachedCommandChannelListComboBox)
                {
                    this.cachedCommandChannelListComboBox =
                        new ComboBox(
                            this,
                            ControlIDs.CommandChannelListComboBox);
                }

                return this.cachedCommandChannelListComboBox;
            }
        }

        #endregion Control Properties

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
            /// ---------------------------------------------------------------
            private const string ResourceSubscriberAddressWizardTitle =
                ";Subscriber Address" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";DeviceWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Channel label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceChannel =
                ";&Notification channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceChannelPage" +
                ";channelLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the delivery address label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDeliveryAddress =
                ";Delivery &address for the selected channel:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceChannelPage" +
                ";addressLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Instruction label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstructions =
                ";Select the notification channel and enter your address for that channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceChannelPage" +
                ";titleLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Channel navigation link
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkChannel =
                ";Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceChannelPage" +
                ";$this.NavigationText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the EmailChannelType 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceEmailChannelType =
                ";E-Mail (SMTP)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";EmailChannelType";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the InstantMessageChannelType  
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstantMessageChannelType =
                ";Instant Message (IM)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";IMChannelType";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the TextMessageChannelType  
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceTextMessageChannelType =
                ";Text Message (SMS)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";SMSChannelType";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the CommandChannelType  
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCommandChannelType =
                ";Command" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandChannelType";

            #endregion Constants

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Subscriber Address wizard 
            /// window title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberAddressWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Channel label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedChannel;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the delivery address label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDeliveryAddress;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Instructions 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstructions;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the NavigationLinkChannel
            /// link label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkChannel;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the EmailChannelType  
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedEmailChannelType;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the InstantMessageChannelType  
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstantMessageChannelType;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the TextMessageChannelType  
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedTextMessageChannelType;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the CommandChannelType  
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCommandChannelType;

            #endregion

            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriberAddressWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriberAddressWizardTitle
            {
                get
                {
                    if ((cachedSubscriberAddressWizardTitle == null))
                    {
                        cachedSubscriberAddressWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscriberAddressWizardTitle);
                    }

                    return cachedSubscriberAddressWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Channel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Channel
            {
                get
                {
                    if ((cachedChannel == null))
                    {
                        cachedChannel =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceChannel);
                    }

                    return cachedChannel;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedDeliveryAddress == null))
                    {
                        cachedDeliveryAddress =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDeliveryAddress);
                    }

                    return cachedDeliveryAddress;
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
            /// Exposes access to the NavigationLinkChannel translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkChannel
            {
                get
                {
                    if ((cachedNavigationLinkChannel == null))
                    {
                        cachedNavigationLinkChannel =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNavigationLinkChannel);
                    }

                    return cachedNavigationLinkChannel;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EmailChannelType translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string EmailChannelType
            {
                get
                {
                    if ((cachedEmailChannelType == null))
                    {
                        cachedEmailChannelType =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEmailChannelType);
                    }

                    return cachedEmailChannelType;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InstantMessageChannelType translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string InstantMessageChannelType
            {
                get
                {
                    if ((cachedInstantMessageChannelType == null))
                    {
                        cachedInstantMessageChannelType =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceInstantMessageChannelType);
                    }

                    return cachedInstantMessageChannelType;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TextMessageChannelType translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string TextMessageChannelType
            {
                get
                {
                    if ((cachedTextMessageChannelType == null))
                    {
                        cachedTextMessageChannelType =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceTextMessageChannelType);
                    }

                    return cachedTextMessageChannelType;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CommandChannelType translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CommandChannelType
            {
                get
                {
                    if ((cachedCommandChannelType == null))
                    {
                        cachedCommandChannelType =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCommandChannelType);
                    }

                    return cachedCommandChannelType;
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
            /// Control ID for ChannelComboBox
            /// </summary>
            public const string ChannelComboBox = "channelList";

            /// <summary>
            /// Control ID for ChannelStaticControl
            /// </summary>
            public const string ChannelStaticControl = "channelLabel";

            /// <summary>
            /// Control ID for DeliveryAddressTextBox
            /// </summary>
            public const string DeliveryAddressTextBox = "addressBox";

            /// <summary>
            /// Control ID for DeliveryAddressStaticControl
            /// </summary>
            public const string DeliveryAddressStaticControl = "addressLabel";

            /// <summary>
            /// Control ID for CommandChannelListComboBox
            /// </summary>
            public const string CommandChannelListComboBox = "commandChannelList";
        }

        #endregion Control ID's
    }
}
