// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CommandSettingsWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  12-AUG-08   Created
//  [KellyMor]  19-AUG-08   Added resources for alert parameters context menu
//  [KellyMor]  04-SEP-08   Updated channel wizard title string
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

    #region Interface Definition - ICommandSettingsWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICommandSettingsWindow, for 
    /// CommandSettingsWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 12-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICommandSettingsWindow
    {
        /// <summary>
        /// Read-only property to access CommandAlertParametersButton
        /// </summary>
        Button CommandAlertParametersButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DirectoryExampleStaticControl
        /// </summary>
        StaticControl DirectoryExampleStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access InitialDirectoryTextBox
        /// </summary>
        TextBox InitialDirectoryTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access InitialDirectoryStaticControl
        /// </summary>
        StaticControl InitialDirectoryStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ParametersExampleStaticControl
        /// </summary>
        StaticControl ParametersExampleStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CommandLineParametersTextBox
        /// </summary>
        TextBox CommandLineParametersTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CommandLineParametersStaticControl
        /// </summary>
        StaticControl CommandLineParametersStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PathExampleStaticControl
        /// </summary>
        StaticControl PathExampleStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FullPathToFileTextBox
        /// </summary>
        TextBox FullPathToFileTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FullPathToFileStaticControl
        /// </summary>
        StaticControl FullPathToFileStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CommandConfigurationStaticControl
        /// </summary>
        StaticControl CommandConfigurationStaticControl
        {
            get;
        }
    }

    #endregion

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Command Settings page of the Command Channel
    /// Wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 12-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class CommandSettingsWindow : Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, ICommandSettingsWindow
    {        
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CommandAlertParametersButton of type Button
        /// </summary>
        private Button cachedCommandAlertParametersButton;
        
        /// <summary>
        /// Cache to hold a reference to DirectoryExampleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDirectoryExampleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InitialDirectoryTextBox of type TextBox
        /// </summary>
        private TextBox cachedInitialDirectoryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to InitialDirectoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInitialDirectoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ParametersExampleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParametersExampleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CommandLineParametersTextBox of type TextBox
        /// </summary>
        private TextBox cachedCommandLineParametersTextBox;
        
        /// <summary>
        /// Cache to hold a reference to CommandLineParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommandLineParametersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PathExampleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPathExampleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FullPathToFileTextBox of type TextBox
        /// </summary>
        private TextBox cachedFullPathToFileTextBox;
        
        /// <summary>
        /// Cache to hold a reference to FullPathToFileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFullPathToFileStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CommandConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommandConfigurationStaticControl;
        
        #endregion
        
        #region Constructors
        
        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Owner of ConsoleWizardBase of type ConsoleApp
        /// </param>
        /// <history>
        ///     [KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public CommandSettingsWindow(ConsoleApp app)
            : base(app, Strings.DialogTitle)
        {
            // Add constructor logic
        }

        #endregion

        #region Interface Control Properties

        #region IShortMessageFormatWindow Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new ICommandSettingsWindow Controls
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
        /// 	[KellyMor] 12-AUG-08 Created
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
        ///  Routine to set/get the text in control InitialDirectoryTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual string InitialDirectoryText
        {
            get
            {
                return this.Controls.InitialDirectoryTextBox.Text;
            }
            
            set
            {
                this.Controls.InitialDirectoryTextBox.Text = value;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control 
        /// CommandLineParametersTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual string CommandLineParametersText
        {
            get
            {
                return this.Controls.CommandLineParametersTextBox.Text;
            }
            
            set
            {
                this.Controls.CommandLineParametersTextBox.Text = value;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FullPathToFileTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual string FullPathToFileText
        {
            get
            {
                return this.Controls.FullPathToFileTextBox.Text;
            }
            
            set
            {
                this.Controls.FullPathToFileTextBox.Text = value;
            }
        }

        #endregion
        
        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommandAlertParametersButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        Button ICommandSettingsWindow.CommandAlertParametersButton
        {
            get
            {
                if ((this.cachedCommandAlertParametersButton == null))
                {
                    this.cachedCommandAlertParametersButton = 
                        new Button(
                            this, 
                            CommandSettingsWindow.ControlIDs.CommandAlertParametersButton);
                }
                
                return this.cachedCommandAlertParametersButton;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DirectoryExampleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ICommandSettingsWindow.DirectoryExampleStaticControl
        {
            get
            {
                if ((this.cachedDirectoryExampleStaticControl == null))
                {
                    this.cachedDirectoryExampleStaticControl = 
                        new StaticControl(
                            this, 
                            CommandSettingsWindow.ControlIDs.DirectoryExampleStaticControl);
                }
                
                return this.cachedDirectoryExampleStaticControl;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InitialDirectoryTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        TextBox ICommandSettingsWindow.InitialDirectoryTextBox
        {
            get
            {
                if ((this.cachedInitialDirectoryTextBox == null))
                {
                    this.cachedInitialDirectoryTextBox = 
                        new TextBox(
                            this, 
                            CommandSettingsWindow.ControlIDs.InitialDirectoryTextBox);
                }
                
                return this.cachedInitialDirectoryTextBox;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InitialDirectoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ICommandSettingsWindow.InitialDirectoryStaticControl
        {
            get
            {
                if ((this.cachedInitialDirectoryStaticControl == null))
                {
                    this.cachedInitialDirectoryStaticControl = 
                        new StaticControl(
                            this, 
                            CommandSettingsWindow.ControlIDs.InitialDirectoryStaticControl);
                }
                
                return this.cachedInitialDirectoryStaticControl;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersExampleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ICommandSettingsWindow.ParametersExampleStaticControl
        {
            get
            {
                if ((this.cachedParametersExampleStaticControl == null))
                {
                    this.cachedParametersExampleStaticControl = 
                        new StaticControl(
                            this, 
                            CommandSettingsWindow.ControlIDs.ParametersExampleStaticControl);
                }
                
                return this.cachedParametersExampleStaticControl;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommandLineParametersTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        TextBox ICommandSettingsWindow.CommandLineParametersTextBox
        {
            get
            {
                if ((this.cachedCommandLineParametersTextBox == null))
                {
                    this.cachedCommandLineParametersTextBox = 
                        new TextBox(
                            this, 
                            CommandSettingsWindow.ControlIDs.CommandLineParametersTextBox);
                }
                
                return this.cachedCommandLineParametersTextBox;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommandLineParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ICommandSettingsWindow.CommandLineParametersStaticControl
        {
            get
            {
                if ((this.cachedCommandLineParametersStaticControl == null))
                {
                    this.cachedCommandLineParametersStaticControl = 
                        new StaticControl(
                            this, 
                            CommandSettingsWindow.ControlIDs.CommandLineParametersStaticControl);
                }
                
                return this.cachedCommandLineParametersStaticControl;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PathExampleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ICommandSettingsWindow.PathExampleStaticControl
        {
            get
            {
                if ((this.cachedPathExampleStaticControl == null))
                {
                    this.cachedPathExampleStaticControl = 
                        new StaticControl(
                            this, 
                            CommandSettingsWindow.ControlIDs.PathExampleStaticControl);
                }
                
                return this.cachedPathExampleStaticControl;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FullPathToFileTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        TextBox ICommandSettingsWindow.FullPathToFileTextBox
        {
            get
            {
                if ((this.cachedFullPathToFileTextBox == null))
                {
                    this.cachedFullPathToFileTextBox =
                        new TextBox(
                            this, 
                            CommandSettingsWindow.ControlIDs.FullPathToFileTextBox);
                }
                
                return this.cachedFullPathToFileTextBox;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FullPathToFileStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ICommandSettingsWindow.FullPathToFileStaticControl
        {
            get
            {
                if ((this.cachedFullPathToFileStaticControl == null))
                {
                    this.cachedFullPathToFileStaticControl = 
                        new StaticControl(
                            this, 
                            CommandSettingsWindow.ControlIDs.FullPathToFileStaticControl);
                }
                
                return this.cachedFullPathToFileStaticControl;
            }
        }
        
        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommandConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        StaticControl ICommandSettingsWindow.CommandConfigurationStaticControl
        {
            get
            {
                if ((this.cachedCommandConfigurationStaticControl == null))
                {
                    this.cachedCommandConfigurationStaticControl = 
                        new StaticControl(
                            this, 
                            CommandSettingsWindow.ControlIDs.CommandConfigurationStaticControl);
                }
                
                return this.cachedCommandConfigurationStaticControl;
            }
        }

        #endregion
        
        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CommandAlertParametersButton
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickCommandAlertParametersButton()
        {
            this.Controls.CommandAlertParametersButton.Click();
        }
        
        #endregion
        
        #region Strings Class

        /// -------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
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
                ";Command Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";CommandChannelWizardTitle";

            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExampleDirectory
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceExampleDirectory =
                ";Example: C:\\data_files" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.CommandChannelSettingsPage" +
                ";directoryExampleLabel.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InitialDirectory
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceInitialDirectory =
                ";&Initial directory:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.CommandChannelSettingsPage" +
                ";directoryLabel.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExampleParameters
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceExampleParameters =
                ";Example: -t" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.CommandChannelSettingsPage" +
                ";parametersExampleLabel.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CommandLineParameters
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceCommandLineParameters =
                ";&Command line parameters:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.CommandChannelSettingsPage" +
                ";parametersLabel.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExampleFullPathToFile
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceExampleFullPathToFile =
                ";Example: C:\\Windows\\system32\\ping.exe" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.CommandChannelSettingsPage" +
                ";pathExampleLabel.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FullPathToFile
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceFullPathToFile =
                ";F&ull path to file:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.CommandChannelSettingsPage" +
                ";pathLabel.Text";
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CommandConfiguration
            /// </summary>
            /// -------------------------------------------------------------------
            private const string ResourceCommandConfiguration =
                ";Notification command configuration:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.CommandChannelSettingsPage" +
                ";configurationLabel.Text";

            #region Alert Parameter Menu Items

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSource 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSource =
                ";Alert Source;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertSource";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertName 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertName =
                ";Alert Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertDescription =
                ";Alert Description;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertDescription";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSeverity =
                ";Alert Severity;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertSeverity";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertPriority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertPriority =
                ";Alert Priority;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertPriority";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertCategory =
                ";Alert Category;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCategory";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertResolutionState =
                ";Alert Resolution State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertResolutionState";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertOwner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertOwner =
                ";Alert Owner;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertOwner";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertResolvedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertResolvedBy =
                ";Alert Resolved By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertResolvedBy";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertLastModifiedTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertLastModifiedTime =
                ";Alert Last Modified Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertLastModifiedTime";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertTimeRaised
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertTimeRaised =
                ";Alert Raised Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertRaisedTime";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertTimeResolved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertTimeResolved =
                ";Alert Resolution Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertResolutionTime";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertCustomField
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertCustomField =
                ";Alert Custom Field;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustomField";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertLastModifiedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertLastModifiedBy =
                ";Alert Last Modified By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertLastModifiedBy";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WebConsoleLink
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebConsoleLink =
                ";WebConsole Link;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;WebConsoleLink";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField1 =
                ";Custom Field1;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField2 =
                ";Custom Field2;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField3 =
                ";Custom Field3;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField4 =
                ";Custom Field4;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom4";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField5 =
                ";Custom Field5;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom5";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField6 =
                ";Custom Field6;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom6";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField7
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField7 =
                ";Custom Field7;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom7";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField8 =
                ";Custom Field8;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom8";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField9
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField9 =
                ";Custom Field9;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom9";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField10
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField10 =
                ";Custom Field10;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;AlertCustom10";

            #endregion Alert Parameter Menu Items

            #endregion
            
            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExampleDirectory
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedExampleDirectory;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InitialDirectory
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedInitialDirectory;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExampleParameters
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedExampleParameters;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CommandLineParameters
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedCommandLineParameters;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExampleFullPathToFile
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedExampleFullPathToFile;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FullPathToFile
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedFullPathToFile;
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CommandConfiguration
            /// </summary>
            /// -------------------------------------------------------------------
            private static string cachedCommandConfiguration;

            #region Alert Parameter Menu Items

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSource;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSeverity;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertPriority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPriority;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertCategory;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolutionState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertOwner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertOwner;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertResolvedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolvedBy;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertLastModifiedTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertLastModifiedTime;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertTimeRaised
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertTimeRaised;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertTimeResolved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertTimeResolved;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertCustomField
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertCustomField;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertLastModifiedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertLastModifiedBy;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WebConsoleLink
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebConsoleLink;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField1;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField3;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField4;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField5;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField6;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField7
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField7;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField8;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField9
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField9;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField10
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField10;

            #endregion Alert Parameter Menu Items

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

            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExampleDirectory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 12-AUG-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string ExampleDirectory
            {
                get
                {
                    if ((cachedExampleDirectory == null))
                    {
                        cachedExampleDirectory = CoreManager.MomConsole.GetIntlStr(ResourceExampleDirectory);
                    }
                    
                    return cachedExampleDirectory;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InitialDirectory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 12-AUG-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string InitialDirectory
            {
                get
                {
                    if ((cachedInitialDirectory == null))
                    {
                        cachedInitialDirectory = CoreManager.MomConsole.GetIntlStr(ResourceInitialDirectory);
                    }
                    
                    return cachedInitialDirectory;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExampleParameters translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 12-AUG-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string ExampleParameters
            {
                get
                {
                    if ((cachedExampleParameters == null))
                    {
                        cachedExampleParameters = CoreManager.MomConsole.GetIntlStr(ResourceExampleParameters);
                    }
                    
                    return cachedExampleParameters;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CommandLineParameters translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 12-AUG-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string CommandLineParameters
            {
                get
                {
                    if ((cachedCommandLineParameters == null))
                    {
                        cachedCommandLineParameters = CoreManager.MomConsole.GetIntlStr(ResourceCommandLineParameters);
                    }
                    
                    return cachedCommandLineParameters;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExampleFullPathToFile translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 12-AUG-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string ExampleFullPathToFile
            {
                get
                {
                    if ((cachedExampleFullPathToFile == null))
                    {
                        cachedExampleFullPathToFile = CoreManager.MomConsole.GetIntlStr(ResourceExampleFullPathToFile);
                    }
                    
                    return cachedExampleFullPathToFile;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FullPathToFile translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 12-AUG-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string FullPathToFile
            {
                get
                {
                    if ((cachedFullPathToFile == null))
                    {
                        cachedFullPathToFile = CoreManager.MomConsole.GetIntlStr(ResourceFullPathToFile);
                    }
                    
                    return cachedFullPathToFile;
                }
            }
            
            /// -------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CommandConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 12-AUG-08 Created
            /// </history>
            /// -------------------------------------------------------------------
            public static string CommandConfiguration
            {
                get
                {
                    if ((cachedCommandConfiguration == null))
                    {
                        cachedCommandConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceCommandConfiguration);
                    }
                    
                    return cachedCommandConfiguration;
                }
            }

            #region Alert Parameter Menu Items

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSource translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertSource
            {
                get
                {
                    if ((cachedAlertSource == null))
                    {
                        cachedAlertSource =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertSource);
                    }

                    return cachedAlertSource;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertName
            {
                get
                {
                    if ((cachedAlertName == null))
                    {
                        cachedAlertName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertName);
                    }

                    return cachedAlertName;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertDescription
            {
                get
                {
                    if ((cachedAlertDescription == null))
                    {
                        cachedAlertDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertDescription);
                    }

                    return cachedAlertDescription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSeverity translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertSeverity
            {
                get
                {
                    if ((cachedAlertSeverity == null))
                    {
                        cachedAlertSeverity =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertSeverity);
                    }

                    return cachedAlertSeverity;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertPriority translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertPriority
            {
                get
                {
                    if ((cachedAlertPriority == null))
                    {
                        cachedAlertPriority =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertPriority);
                    }

                    return cachedAlertPriority;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertCategory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertCategory
            {
                get
                {
                    if ((cachedAlertCategory == null))
                    {
                        cachedAlertCategory =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertCategory);
                    }

                    return cachedAlertCategory;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertResolutionState translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertResolutionState
            {
                get
                {
                    if ((cachedAlertResolutionState == null))
                    {
                        cachedAlertResolutionState =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertResolutionState);
                    }

                    return cachedAlertResolutionState;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertOwner translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertOwner
            {
                get
                {
                    if ((cachedAlertOwner == null))
                    {
                        cachedAlertOwner =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertOwner);
                    }

                    return cachedAlertOwner;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertResolvedBy translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertResolvedBy
            {
                get
                {
                    if ((cachedAlertResolvedBy == null))
                    {
                        cachedAlertResolvedBy =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertResolvedBy);
                    }

                    return cachedAlertResolvedBy;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertLastModifiedTime translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertLastModifiedTime
            {
                get
                {
                    if ((cachedAlertLastModifiedTime == null))
                    {
                        cachedAlertLastModifiedTime =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertLastModifiedTime);
                    }

                    return cachedAlertLastModifiedTime;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertTimeRaised translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertTimeRaised
            {
                get
                {
                    if ((cachedAlertTimeRaised == null))
                    {
                        cachedAlertTimeRaised =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertTimeRaised);
                    }

                    return cachedAlertTimeRaised;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertTimeResolved translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertTimeResolved
            {
                get
                {
                    if ((cachedAlertTimeResolved == null))
                    {
                        cachedAlertTimeResolved =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertTimeResolved);
                    }

                    return cachedAlertTimeResolved;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertCustomField translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertCustomField
            {
                get
                {
                    if ((cachedAlertCustomField == null))
                    {
                        cachedAlertCustomField =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertCustomField);
                    }

                    return cachedAlertCustomField;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertLastModifiedBy translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertLastModifiedBy
            {
                get
                {
                    if ((cachedAlertLastModifiedBy == null))
                    {
                        cachedAlertLastModifiedBy =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlertLastModifiedBy);
                    }

                    return cachedAlertLastModifiedBy;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebConsoleLink translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WebConsoleLink
            {
                get
                {
                    if ((cachedWebConsoleLink == null))
                    {
                        cachedWebConsoleLink =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWebConsoleLink);
                    }

                    return cachedWebConsoleLink;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField1
            {
                get
                {
                    if ((cachedCustomField1 == null))
                    {
                        cachedCustomField1 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField1);
                    }

                    return cachedCustomField1;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField2
            {
                get
                {
                    if ((cachedCustomField2 == null))
                    {
                        cachedCustomField2 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField2);
                    }

                    return cachedCustomField2;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField3 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField3
            {
                get
                {
                    if ((cachedCustomField3 == null))
                    {
                        cachedCustomField3 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField3);
                    }

                    return cachedCustomField3;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField4 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField4
            {
                get
                {
                    if ((cachedCustomField4 == null))
                    {
                        cachedCustomField4 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField4);
                    }

                    return cachedCustomField4;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField5 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField5
            {
                get
                {
                    if ((cachedCustomField5 == null))
                    {
                        cachedCustomField5 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField5);
                    }

                    return cachedCustomField5;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField6 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField6
            {
                get
                {
                    if ((cachedCustomField6 == null))
                    {
                        cachedCustomField6 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField6);
                    }

                    return cachedCustomField6;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField7 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField7
            {
                get
                {
                    if ((cachedCustomField7 == null))
                    {
                        cachedCustomField7 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField7);
                    }

                    return cachedCustomField7;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField8 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField8
            {
                get
                {
                    if ((cachedCustomField8 == null))
                    {
                        cachedCustomField8 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField8);
                    }

                    return cachedCustomField8;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField9 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField9
            {
                get
                {
                    if ((cachedCustomField9 == null))
                    {
                        cachedCustomField9 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField9);
                    }

                    return cachedCustomField9;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField10 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 19-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField10
            {
                get
                {
                    if ((cachedCustomField10 == null))
                    {
                        cachedCustomField10 =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCustomField10);
                    }

                    return cachedCustomField10;
                }
            }

            #endregion Alert Parameter Menu Items

            #endregion
        }

        #endregion
        
        #region Control ID's

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for CommandAlertParametersButton
            /// </summary>
            public const string CommandAlertParametersButton = "parametersPlaceholer";
            
            /// <summary>
            /// Control ID for DirectoryExampleStaticControl
            /// </summary>
            public const string DirectoryExampleStaticControl = "directoryExampleLabel";
            
            /// <summary>
            /// Control ID for InitialDirectoryTextBox
            /// </summary>
            public const string InitialDirectoryTextBox = "directoryBox";
            
            /// <summary>
            /// Control ID for InitialDirectoryStaticControl
            /// </summary>
            public const string InitialDirectoryStaticControl = "directoryLabel";
            
            /// <summary>
            /// Control ID for ParametersExampleStaticControl
            /// </summary>
            public const string ParametersExampleStaticControl = "parametersExampleLabel";
            
            /// <summary>
            /// Control ID for CommandLineParametersTextBox
            /// </summary>
            public const string CommandLineParametersTextBox = "parametersBox";
            
            /// <summary>
            /// Control ID for CommandLineParametersStaticControl
            /// </summary>
            public const string CommandLineParametersStaticControl = "parametersLabel";
            
            /// <summary>
            /// Control ID for PathExampleStaticControl
            /// </summary>
            public const string PathExampleStaticControl = "pathExampleLabel";
            
            /// <summary>
            /// Control ID for FullPathToFileTextBox
            /// </summary>
            public const string FullPathToFileTextBox = "pathBox";
            
            /// <summary>
            /// Control ID for FullPathToFileStaticControl
            /// </summary>
            public const string FullPathToFileStaticControl = "pathLabel";
            
            /// <summary>
            /// Control ID for CommandConfigurationStaticControl
            /// </summary>
            public const string CommandConfigurationStaticControl = "configurationLabel";
        }

        #endregion
    }
}
