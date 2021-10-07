// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="NameAndDescriptionWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  11-AUG-08   Created
//  [KellyMor]  13-AUG-08   Updated control ID's and resource strings.
//                          Updated constructor to take a string for wizard
//                          window title/caption.
//  [KellyMor]  18-AUG-08   Updated Email and IM wizard title resources.
//                          Added resources for default IM name and description
//  [KellyMor]  22-AUG-08   Updated resource strings
//  [KellyMor]  04-SEP-08   Updated channel wizard title strings
//  [KellyMor]  06-SEP-08   Updated resource strings for move from Administration
//                          library to components library.
//  [KellyMor]  10-SEP-08   More updates for resource string move to components
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - INameAndDescriptionWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, INameAndDescriptionWindow, for 
    /// NameAndDescriptionWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface INameAndDescriptionWindow
    {
        /// <summary>
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
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
    }

    #endregion Interface Definition - INameAndDescriptionWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Name and Description step
    /// in the Create Notification Channel Wizard.  This class is used by all
    /// types of the channel wizard:  email, IM, SMS, and command.
    /// </summary>
    /// <history>
    ///     [KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class NameAndDescriptionWindow : Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, INameAndDescriptionWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members

        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;

        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;

        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;

        #endregion Private Members

        #region Constructors

        /// -----------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Owner of ConsoleWizardBase of type ConsoleApp
        /// </param>
        /// <param name="wizardTitle">
        /// Wizard window title string.
        /// </param>
        /// <history>
        ///     [KellyMor] 11-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------
        public NameAndDescriptionWindow(ConsoleApp app, string wizardTitle)
            : base(app, wizardTitle)
        {
            // Add constructor logic
        }

        #endregion Constructors

        #region Interface Control Properties

        #region INameAndDescriptionWindow Controls Property

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
        public new INameAndDescriptionWindow Controls
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

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }

            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
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

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        TextBox INameAndDescriptionWindow.NameTextBox 
        {
            get
            {
                if (null == this.cachedNameTextBox)
                {
                    this.cachedNameTextBox =
                        new TextBox(
                            this,
                            ControlIDs.NameTextBox);
                }

                return this.cachedNameTextBox;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        TextBox INameAndDescriptionWindow.DescriptionTextBox
        {
            get
            {
                if (null == this.cachedDescriptionTextBox)
                {
                    this.cachedDescriptionTextBox =
                        new TextBox(
                            this.AccessibleObject.Window,
                            ControlIDs.DescriptionTextBox);
                }

                return this.cachedDescriptionTextBox;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl INameAndDescriptionWindow.NameStaticControl
        {
            get
            {
                if (null == this.cachedNameStaticControl)
                {
                    this.cachedNameStaticControl =
                        new StaticControl(
                            this.AccessibleObject.Window,
                            ControlIDs.NameTextBox);
                }

                return this.cachedNameStaticControl;
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
        StaticControl INameAndDescriptionWindow.DescriptionStaticControl
        {
            get
            {
                if (null == this.cachedDescriptionStaticControl)
                {
                    this.cachedDescriptionStaticControl =
                        new StaticControl(
                            this.AccessibleObject.Window,
                            ControlIDs.DescriptionStaticControl);
                }

                return this.cachedDescriptionStaticControl;
            }
        }

        #endregion Control Properties

        #region Strings

        /// -------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
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
            private const string ResourceEmailChannelWizardTitle =
                ";E-Mail Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";EmailChannelWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstantMessageChannelWizardTitle =
                ";IM Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";IMChannelWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSmsChannelWizardTitle =
                ";SMS Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SmsChannelWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCommandChannelWizardTitle =
                ";Command Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";CommandChannelWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Name label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceName =
                ";&Channel name:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ChannelGeneralPage" +
                ";nameLabel.Text";
                        
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Description label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDescription =
                ";&Description (optional):" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ChannelGeneralPage" +
                ";descriptionLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the DescriptionNavigationLink 
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDescriptionNavigationLink =
                ";Description" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ChannelWizardNameDescriptionPageTitle";

            #region Default Channel Names and Descriptions

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the default email channel name.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDefaultEmailChannelName =
                ";SmtpEndpoint" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";EmailChannel";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the default email channel 
            /// Description
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDefaultEmailChannelDescription =
                ";SMTP E-Mail" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";EmailChannelDescription";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the default instant message 
            /// channel name.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDefaultInstantMessageChannelName =
                ";ImEndpoint" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ImChannel";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the default instant message
            /// channel description
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDefaultInstantMessageChannelDescription =
                ";Instant Messaging" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ImChannelDescription";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the default short message channel 
            /// name.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDefaultShortMessageChannelName =
                ";SmsEndpoint" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SmsChannel";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the default short message channel 
            /// description
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDefaultShortMessageChannelDescription =
                ";Short Message Service" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SmsChannelDescription";

            #endregion Default Channel Names and Descriptions

            #endregion Constants

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the email channel wizard window 
            /// title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedEmailChannelWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the instant message channel 
            /// wizard window title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstantMessageChannelWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the SMS channel wizard window 
            /// title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSmsChannelWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the command channel wizard 
            /// window title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCommandChannelWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Name label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedName;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Description label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDescription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the DescriptionNavigationLink 
            /// label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDescriptionNavigationLink;

            #region Default Channel Names and Descriptions

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the DefaultEmailChannelName 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDefaultEmailChannelName;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the 
            /// DefaultEmailChannelDescription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDefaultEmailChannelDescription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the 
            /// DefaultInstantMessageChannelName 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDefaultInstantMessageChannelName;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the 
            /// DefaultInstantMessageChannelDescription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDefaultInstantMessageChannelDescription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the 
            /// DefaultShortMessageChannelName 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDefaultShortMessageChannelName;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the 
            /// DefaultShortMessageChannelDescription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDefaultShortMessageChannelDescription;

            #endregion Default Channel Names and Descriptions

            #endregion

            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EmailChannelWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string EmailChannelWizardTitle
            {
                get
                {
                    if ((cachedEmailChannelWizardTitle == null))
                    {
                        cachedEmailChannelWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEmailChannelWizardTitle);
                    }

                    return cachedEmailChannelWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InstantMessageChannelWizardTitle 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string InstantMessageChannelWizardTitle
            {
                get
                {
                    if ((cachedInstantMessageChannelWizardTitle == null))
                    {
                        cachedInstantMessageChannelWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceInstantMessageChannelWizardTitle);
                    }

                    return cachedInstantMessageChannelWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SmsChannelWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SmsChannelWizardTitle
            {
                get
                {
                    if ((cachedSmsChannelWizardTitle == null))
                    {
                        cachedSmsChannelWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSmsChannelWizardTitle);
                    }

                    return cachedSmsChannelWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CommandChannelWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CommandChannelWizardTitle
            {
                get
                {
                    if ((cachedCommandChannelWizardTitle == null))
                    {
                        cachedCommandChannelWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCommandChannelWizardTitle);
                    }

                    return cachedCommandChannelWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceName);
                    }

                    return cachedName;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDescription);
                    }

                    return cachedDescription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DescriptionNavigationLink translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DescriptionNavigationLink
            {
                get
                {
                    if ((cachedDescriptionNavigationLink == null))
                    {
                        cachedDescriptionNavigationLink =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDescriptionNavigationLink);
                    }

                    return cachedDescriptionNavigationLink;
                }
            }

            #region Default Channel Names and Descriptions

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultEmailChannelName translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DefaultEmailChannelName
            {
                get
                {
                    if ((cachedDefaultEmailChannelName == null))
                    {
                        cachedDefaultEmailChannelName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultEmailChannelName);
                    }

                    return cachedDefaultEmailChannelName;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultEmailChannelDescription translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DefaultEmailChannelDescription
            {
                get
                {
                    if ((cachedDefaultEmailChannelDescription == null))
                    {
                        cachedDefaultEmailChannelDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultEmailChannelDescription);
                    }

                    return cachedDefaultEmailChannelDescription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultInstantMessageChannelName 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DefaultInstantMessageChannelName
            {
                get
                {
                    if ((cachedDefaultInstantMessageChannelName == null))
                    {
                        cachedDefaultInstantMessageChannelName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultInstantMessageChannelName);
                    }

                    return cachedDefaultInstantMessageChannelName;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultInstantMessageChannelDescription 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DefaultInstantMessageChannelDescription
            {
                get
                {
                    if ((cachedDefaultInstantMessageChannelDescription == null))
                    {
                        cachedDefaultInstantMessageChannelDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultInstantMessageChannelDescription);
                    }

                    return cachedDefaultInstantMessageChannelDescription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultShortMessageChannelName 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DefaultShortMessageChannelName
            {
                get
                {
                    if ((cachedDefaultShortMessageChannelName == null))
                    {
                        cachedDefaultShortMessageChannelName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultShortMessageChannelName);
                    }

                    return cachedDefaultShortMessageChannelName;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultShortMessageChannelDescription 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DefaultShortMessageChannelDescription
            {
                get
                {
                    if ((cachedDefaultShortMessageChannelDescription == null))
                    {
                        cachedDefaultShortMessageChannelDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultShortMessageChannelDescription);
                    }

                    return cachedDefaultShortMessageChannelDescription;
                }
            }

            #endregion Default Channel Names and Descriptions

            #endregion Properties
        }

        #endregion Strings

        #region Control ID's

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameBox";

            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionBox";

            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";

            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descriptionLabel";
        }

        #endregion Control ID's
    }
}
