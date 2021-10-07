// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EmailSettingsWindow.cs">
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
//  [KellyMor]  15-AUG-08   Modified retry interval control to EditComboBox.
//  [KellyMor]  18-AUG-08   Updated Email and IM wizard title resources.
//  [KellyMor]  04-SEP-08   Updated channel wizard title string.
//  [KellyMor]  06-SEP-08   Updated resource strings for move from Administration
//                          library to components library.
//  [KellyMor]  10-SEP-08   More updates for resource string move to components
//  [KellyMor]  23-SEP-08   Modified RetryPrimaryAfterText property to use the
//                          TextBox reference on the combobox control.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - IEmailSettingsWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEmailSettingsWindow, for 
    /// EmailSettingsWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEmailSettingsWindow
    {
        /// <summary>
        /// Read-only property to access SMTPServersStaticControl
        /// </summary>
        StaticControl SMTPServersStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServersListToolStrip
        /// </summary>
        ToolStrip ServersListToolStrip
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServersListView
        /// </summary>
        ListView ServersListView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ReturnAddressStaticControl
        /// </summary>
        StaticControl ReturnAddressStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ReturnAddressTextBox
        /// </summary>
        TextBox ReturnAddressTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RetryPrimaryAfterStaticControl
        /// </summary>
        StaticControl RetryPrimaryAfterStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RetryPrimaryAfterEditComboBox
        /// </summary>
        EditComboBox RetryPrimaryAfterEditComboBox
        {
            get;
        }
    }

    #endregion Interface Definition - IEmailSettingsWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Email Settings page of the Email Channel
    /// Wizard.
    /// </summary>
    /// <history>
    ///     [KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class EmailSettingsWindow : Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, IEmailSettingsWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members

        /// <summary>
        /// Cache to hold a reference to SMTPServersStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedSMTPServersStaticControl;

        /// <summary>
        /// Cache to hold a reference to ServersListToolStrip of type ToolStrip
        /// </summary>
        private ToolStrip cachedServersListToolStrip;

        /// <summary>
        /// Cache to hold a reference to ServersListView of type ListView
        /// </summary>
        private ListView cachedServersListView;

        /// <summary>
        /// Cache to hold a reference to ReturnAddressStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedReturnAddressStaticControl;

        /// <summary>
        /// Cache to hold a reference to ReturnAddressTextBox of type TextBox
        /// </summary>
        private TextBox cachedReturnAddressTextBox;

        /// <summary>
        /// Cache to hold a reference to RetryPrimaryAfterStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedRetryPrimaryAfterStaticControl;

        /// <summary>
        /// Cache to hold a reference to RetryPrimaryAfterEditComboBox of type 
        /// EditComboBox
        /// </summary>
        private EditComboBox cachedRetryPrimaryAfterEditComboBox;

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
        ///     [KellyMor] 11-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------
        public EmailSettingsWindow(ConsoleApp app)
            : base(app, Strings.DialogTitle)
        {
            // Add constructor logic
        }

        #endregion Constructors

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
        public new IEmailSettingsWindow Controls
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

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ReturnAddress
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual string ReturnAddressText
        {
            get
            {
                return this.Controls.ReturnAddressTextBox.Text;
            }

            set
            {
                this.Controls.ReturnAddressTextBox.Text = value;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RetryPrimaryAfter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual string RetryPrimaryAfterText
        {
            get
            {
                return this.Controls.RetryPrimaryAfterEditComboBox.Text;
            }

            set
            {
                this.Controls.RetryPrimaryAfterEditComboBox.TextBox.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SMTPServersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl IEmailSettingsWindow.SMTPServersStaticControl
        {
            get
            {
                if ((this.cachedSMTPServersStaticControl == null))
                {
                    this.cachedSMTPServersStaticControl = 
                        new StaticControl(
                            this,
                            EmailSettingsWindow.ControlIDs.SMTPServersStaticControl);
                }

                return this.cachedSMTPServersStaticControl;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServersListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ListView IEmailSettingsWindow.ServersListView
        {
            get
            {
                if ((this.cachedServersListView == null))
                {
                    this.cachedServersListView = 
                        new ListView(
                            this,
                            EmailSettingsWindow.ControlIDs.ServersListView);
                }

                return this.cachedServersListView;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServersListToolStrip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ToolStrip IEmailSettingsWindow.ServersListToolStrip
        {
            get
            {
                if ((this.cachedServersListToolStrip == null))
                {
                    this.cachedServersListToolStrip = new ToolStrip(this);
                }

                return this.cachedServersListToolStrip;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReturnAddressStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl IEmailSettingsWindow.ReturnAddressStaticControl
        {
            get
            {
                if ((this.cachedReturnAddressStaticControl == null))
                {
                    this.cachedReturnAddressStaticControl = 
                        new StaticControl(
                            this,
                            EmailSettingsWindow.ControlIDs.ReturnAddressStaticControl);
                }

                return this.cachedReturnAddressStaticControl;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReturnAddressTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        TextBox IEmailSettingsWindow.ReturnAddressTextBox
        {
            get
            {
                if ((this.cachedReturnAddressTextBox == null))
                {
                    this.cachedReturnAddressTextBox = 
                        new TextBox(
                            this,
                            EmailSettingsWindow.ControlIDs.ReturnAddressTextBox);
                }

                return this.cachedReturnAddressTextBox;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RetryPrimaryAfterEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        EditComboBox IEmailSettingsWindow.RetryPrimaryAfterEditComboBox
        {
            get
            {
                if ((this.cachedRetryPrimaryAfterEditComboBox == null))
                {
                    this.cachedRetryPrimaryAfterEditComboBox = 
                        new EditComboBox(
                            this,
                            EmailSettingsWindow.ControlIDs.RetryPrimaryAfterEditComboBox);
                }

                return this.cachedRetryPrimaryAfterEditComboBox;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RetryPrimaryAfterStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl IEmailSettingsWindow.RetryPrimaryAfterStaticControl
        {
            get
            {
                if ((this.cachedRetryPrimaryAfterStaticControl == null))
                {
                    this.cachedRetryPrimaryAfterStaticControl = 
                        new StaticControl(
                            this,
                            EmailSettingsWindow.ControlIDs.RetryPrimaryAfterStaticControl);
                }

                return this.cachedRetryPrimaryAfterStaticControl;
            }
        }

        #endregion Control Properties

        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Add" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.ServersListToolStrip.ToolStripItems[0].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Edit" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.ServersListToolStrip.ToolStripItems[1].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Remove" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.ServersListToolStrip.ToolStripItems[2].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Up" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickMoveUp()
        {
            this.Controls.ServersListToolStrip.ToolStripItems[3].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Down" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickMoveDown()
        {
            this.Controls.ServersListToolStrip.ToolStripItems[4].Click();
        }

        #endregion

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
            private const string ResourceDialogTitle =
                ";Email Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";EmailChannelWizardTitle";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SMTPServers
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSMTPServers =
                ";&SMTP servers:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelSettingsPage" +
                ";serversLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServersListToolStrip
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceServersListToolStrip = 
                ";toolStrip1" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework" +
                ";stripTop.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAddToolStripItem = 
                ";A&dd..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelSettingsPage" +
                ";add.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EditToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceEditToolStripItem =
                ";&Edit..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelSettingsPage" +
                ";edit.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemoveToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceRemoveToolStripItem =
                ";Remo&ve" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelSettingsPage" +
                ";remove.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ReturnAddress
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceReturnAddress =
                ";Re&turn address:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelSettingsPage" +
                ";returnAddressLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RetryPrimaryAfter
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceRetryPrimaryAfter =
                ";Retry primary a&fter:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelSettingsPage" +
                ";retryLabel.Text";

            #endregion Constants

            #region Private Members
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDialogTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SMTPServers
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSMTPServers;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServersListToolStrip
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedServersListToolStrip;

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
            /// Caches the translated resource string for:  ReturnAddress
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedReturnAddress;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RetryPrimaryAfter
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedRetryPrimaryAfter;

            #endregion

            #region Properties
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
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
            /// Exposes access to the SMTPServers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SMTPServers
            {
                get
                {
                    if ((cachedSMTPServers == null))
                    {
                        cachedSMTPServers = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSMTPServers);
                    }

                    return cachedSMTPServers;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ServersListToolStrip
            {
                get
                {
                    if ((cachedServersListToolStrip == null))
                    {
                        cachedServersListToolStrip = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceServersListToolStrip);
                    }

                    return cachedServersListToolStrip;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
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
            /// 	[KellyMor] 11-AUG-08 Created
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
            /// 	[KellyMor] 11-AUG-08 Created
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
            /// Exposes access to the ReturnAddress translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ReturnAddress
            {
                get
                {
                    if ((cachedReturnAddress == null))
                    {
                        cachedReturnAddress = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceReturnAddress);
                    }

                    return cachedReturnAddress;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RetryPrimaryAfter translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string RetryPrimaryAfter
            {
                get
                {
                    if ((cachedRetryPrimaryAfter == null))
                    {
                        cachedRetryPrimaryAfter = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRetryPrimaryAfter);
                    }

                    return cachedRetryPrimaryAfter;
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
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for SMTPServersStaticControl
            /// </summary>
            public const string SMTPServersStaticControl = "serversLabel";

            /// <summary>
            /// Control ID for ServersListToolStrip
            /// </summary>
            public const string ServersListToolStrip = "toolStrip";

            /// <summary>
            /// Control ID for ServersListView
            /// </summary>
            public const string ServersListView = "servers";

            /// <summary>
            /// Control ID for ReturnAddressStaticControl
            /// </summary>
            public const string ReturnAddressStaticControl = "returnAddressLabel";

            /// <summary>
            /// Control ID for ReturnAddressTextBox
            /// </summary>
            public const string ReturnAddressTextBox = "returnAddress";

            /// <summary>
            /// Control ID for RetryPrimaryAfterStaticControl
            /// </summary>
            public const string RetryPrimaryAfterStaticControl = "retryLabel";

            /// <summary>
            /// Control ID for RetryPrimaryAfterEditComboBox
            /// </summary>
            public const string RetryPrimaryAfterEditComboBox = "retryMinutes";
        }

        #endregion Control ID's
    }
}
