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
// 	[KellyMor]  22-AUG-08   Created
//  [KellyMor]  23-SEP-08   Modified to remove description controls and add the
//                          browse button control.
//                          Updated string resources.
//  [KellyMor}  27-SEP-08   Updated resource string for wizard window title
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers.Wizards
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
    /// 	[KellyMor] 22-AUG-08 Created
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
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton 
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
    ///     [KellyMor] 22-AUG-08 Created
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
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;

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
        public NameAndDescriptionWindow(ConsoleApp app)
            : base(app, Strings.SubscriberWizardTitle)
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
        /// 	[KellyMor] 22-AUG-08 Created
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
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
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

        #endregion

        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
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
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
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
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 23-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button INameAndDescriptionWindow.BrowseButton
        {
            get
            {
                if (null == this.cachedBrowseButton)
                {
                    this.cachedBrowseButton =
                        new Button(
                            this.AccessibleObject.Window,
                            ControlIDs.BrowseButton);
                }

                return this.cachedBrowseButton;
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
            /// Contains resource string for the Name label
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceName =
                ";&Subscriber Name:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.RecipientGeneralPage" +
                ";nameLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Instruction label
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceInstructions =
                ";Provide a name and description for this subscriber that will make it easy to indentify later." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.RecipientGeneralPage" +
                ";titleLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Description navigation link
            /// label
            /// </summary>
            /// <remarks>
            /// TODO:  Find resource string
            /// </remarks>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkDescription =
                ";Description" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";RecipientWizardDescriptionPageNavigationText";

            #endregion Constants

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the email channel wizard window 
            /// title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Name label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedName;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Instructions 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstructions;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the NavigationLinkDescription 
            /// link label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkDescription;

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
            /// Exposes access to the NavigationLinkDescription translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkDescription
            {
                get
                {
                    if ((cachedNavigationLinkDescription == null))
                    {
                        cachedNavigationLinkDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNavigationLinkDescription);
                    }

                    return cachedNavigationLinkDescription;
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
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameBox";

            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";

            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "browseButton";
        }

        #endregion Control ID's
    }
}
