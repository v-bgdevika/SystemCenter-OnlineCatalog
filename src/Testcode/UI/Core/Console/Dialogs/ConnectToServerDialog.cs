// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConnectToServerDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 Console
// </project>
// <summary>
// 	Connect to Server Dialog Class.
// </summary>
// <history>
// 	[mbickle] 21SEP05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using System.ComponentModel;
    #endregion

    #region Interface Definition - IConnectToServerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConnectToServerDialogControls, for ConnectToServerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 21SEP05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConnectToServerDialogControls
    {
        /// <summary>
        /// Read-only property to access ServerNameToolbar
        /// </summary>
        Toolbar ServerNameToolbar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServerNameListView
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ListView ServerNameListView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConnectButton
        /// </summary>
        Button ConnectButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServerNameTextBox
        /// </summary>
        TextBox ServerNameTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ServerNameStaticControl
        /// </summary>
        StaticControl ServerNameStaticControl
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[mbickle] 21SEP05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConnectToServerDialog : Dialog, IConnectToServerDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ServerNameToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedServerNameToolbar;

        /// <summary>
        /// Cache to hold a reference to ServerNameListView of type ListView
        /// </summary>
        private ListView cachedServerNameListView;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to ConnectButton of type Button
        /// </summary>
        private Button cachedConnectButton;

        /// <summary>
        /// Cache to hold a reference to ServerNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedServerNameTextBox;

        /// <summary>
        /// Cache to hold a reference to ServerNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServerNameStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConnectToServerDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConnectToServerDialog(ConsoleApp app)
            : base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IConnectToServerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConnectToServerDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ServerName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServerNameText
        {
            get
            {
                return this.Controls.ServerNameTextBox.Text;
            }

            set
            {
                this.Controls.ServerNameTextBox.Text = value;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServerNameToolbar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IConnectToServerDialogControls.ServerNameToolbar
        {
            get
            {
                if ((this.cachedServerNameToolbar == null))
                {
                    this.cachedServerNameToolbar = new Toolbar(this, ConnectToServerDialog.ControlIDs.ServerNameToolbar);
                }
                return this.cachedServerNameToolbar;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServerNameListView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IConnectToServerDialogControls.ServerNameListView
        {
            get
            {
                if ((this.cachedServerNameListView == null))
                {
                    this.cachedServerNameListView = new ListView(this, ConnectToServerDialog.ControlIDs.ServerNameListView);
                }
                return this.cachedServerNameListView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConnectToServerDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConnectToServerDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConnectToServerDialogControls.ConnectButton
        {
            get
            {
                if ((this.cachedConnectButton == null))
                {
                    this.cachedConnectButton = new Button(this, ConnectToServerDialog.ControlIDs.ConnectButton);
                }
                return this.cachedConnectButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServerNameTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConnectToServerDialogControls.ServerNameTextBox
        {
            get
            {
                if ((this.cachedServerNameTextBox == null))
                {
                    this.cachedServerNameTextBox = new TextBox(this, ConnectToServerDialog.ControlIDs.ServerNameTextBox);
                }
                return this.cachedServerNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServerNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConnectToServerDialogControls.ServerNameStaticControl
        {
            get
            {
                if ((this.cachedServerNameStaticControl == null))
                {
                    this.cachedServerNameStaticControl = new StaticControl(this, ConnectToServerDialog.ControlIDs.ServerNameStaticControl);
                }
                return this.cachedServerNameStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Connect
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConnect()
        {
            this.Controls.ConnectButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Routine to click on RecentConnections Button
        /// </summary>
        /// <history>
        ///     [mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRecentConnections()
        {
            this.Controls.ServerNameToolbar[Strings.RecentConnections].Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Routine to click on RegisteredServers Button
        /// </summary>
        /// <history>
        ///     [mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRegisteredServers()
        {
            this.Controls.ServerNameToolbar[Strings.RegisteredServers].Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                Utilities.LogMessage("ConnectToServerDialog.Init:: Looking for Dialog.");

                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("ConnectToServerDialog.Init:: Didn't find dialog, so lets try and bring it up.");

                //Execute File\Connect to bring up dialog.
                Commands.ToolsConnect.Execute(app, CommandMethod.Default);
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);

                if (tempWindow != null)
                {
                    return tempWindow;
                }
                throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog with a title of " + Strings.DialogTitle + ".");
            }
            return tempWindow;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Connect To Server;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Connect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConnect = ";Connect;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagemen" +
                "t.Mom.Internal.UI.Console.ConnectionDialog;connectButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServerName = ";Server name:;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.Console.ConnectionDialog;serverNameLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RecentConnections
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRecentConnections = ";Recent Connections;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;recentConnectionsMenu.ToolTipText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RegisteredServers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRegisteredServers = ";Registered Servers;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;registeredServersMenu.ToolTipText";
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Connect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConnect;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServerName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RecentConnections
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecentConnections;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RegisteredServers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRegisteredServers;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 21SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 21SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    return cachedCancel;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Connect translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 21SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Connect
            {
                get
                {
                    if ((cachedConnect == null))
                    {
                        cachedConnect = CoreManager.MomConsole.GetIntlStr(ResourceConnect);
                    }
                    return cachedConnect;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServerName translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 21SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServerName
            {
                get
                {
                    if ((cachedServerName == null))
                    {
                        cachedServerName = CoreManager.MomConsole.GetIntlStr(ResourceServerName);
                    }
                    return cachedServerName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RecentConnections translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 21SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecentConnections
            {
                get
                {
                    if ((cachedRecentConnections == null))
                    {
                        cachedRecentConnections = CoreManager.MomConsole.GetIntlStr(ResourceRecentConnections);
                    }
                    return cachedRecentConnections;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RegisteredServers translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 21SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RegisteredServers
            {
                get
                {
                    if ((cachedRegisteredServers == null))
                    {
                        cachedRegisteredServers = CoreManager.MomConsole.GetIntlStr(ResourceRegisteredServers);
                    }
                    return cachedRegisteredServers;
                }
            }
            #endregion
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mbickle] 21SEP05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ServerNameToolbar
            /// </summary>
            public const string ServerNameToolbar = "menu";

            /// <summary>
            /// Control ID for ServerNameListView
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ServerNameListView = "serverList";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for ConnectButton
            /// </summary>
            public const string ConnectButton = "connectButton";

            /// <summary>
            /// Control ID for ServerNameTextBox
            /// </summary>
            public const string ServerNameTextBox = "serverNameEditor";

            /// <summary>
            /// Control ID for ServerNameStaticControl
            /// </summary>
            public const string ServerNameStaticControl = "serverNameLabel";
        }
        #endregion
    }
}
