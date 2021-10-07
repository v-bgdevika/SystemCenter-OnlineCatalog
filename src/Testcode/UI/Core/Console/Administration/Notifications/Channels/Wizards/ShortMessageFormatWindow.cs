// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ShortMessageFormatWindow.cs">
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
//  [KellyMor]  22-AUG-08   Updated resource strings
//  [KellyMor]  25-AUG-08   Added resource strings for encoding options
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

    #region Interface Definition - IShortMessageFormatWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IShortMessageFormatWindow, for 
    /// ShortMessageFormatWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 12-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IShortMessageFormatWindow
    {
        /// <summary>
        /// Read-only property to access DefaultShortMessageFormatStaticControl
        /// </summary>
        StaticControl DefaultShortMessageFormatStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MessageBodyStaticControl
        /// </summary>
        StaticControl MessageBodyStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MessageBodyTextBox
        /// </summary>
        TextBox MessageBodyTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MessageBodyAlertParametersButton
        /// </summary>
        Button MessageBodyAlertParametersButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EncodingStaticControl
        /// </summary>
        StaticControl EncodingStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EncodingEditComboBox
        /// </summary>
        EditComboBox EncodingEditComboBox
        {
            get;
        }
    }

    #endregion Interface Definition - IShortMessageFormatWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Short Message Format page of the Short
    /// Message Channel Wizard.
    /// </summary>
    /// <history>
    ///     [KellyMor] 12-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class ShortMessageFormatWindow : Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, IShortMessageFormatWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members

        /// <summary>
        /// Cache to hold a reference to DefaultShortMessageFormatStaticControl 
        /// of type StaticControl
        /// </summary>
        private StaticControl cachedDefaultShortMessageFormatStaticControl;

        /// <summary>
        /// Cache to hold a reference to MessageBodyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMessageBodyStaticControl;

        /// <summary>
        /// Cache to hold a reference to MessageBodyTextBox of type TextBox
        /// </summary>
        private TextBox cachedMessageBodyTextBox;

        /// <summary>
        /// Cache to hold a reference to MessageBodyAlertParametersButton of 
        /// type Button
        /// </summary>
        private Button cachedMessageBodyAlertParametersButton;

        /// <summary>
        /// Cache to hold a reference to EncodingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEncodingStaticControl;

        /// <summary>
        /// Cache to hold a reference to EncodingComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedEncodingEditComboBox;

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
        ///     [KellyMor] 12-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------
        public ShortMessageFormatWindow(ConsoleApp app)
            : base(app, Strings.DialogTitle)
        {
            // Add constructor logic
        }

        #endregion Constructors

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
        public new IShortMessageFormatWindow Controls
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MessageBody
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MessageBodyText
        {
            get
            {
                return this.Controls.MessageBodyTextBox.Text;
            }

            set
            {
                this.Controls.MessageBodyTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EmailMessage
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EncodingText
        {
            get
            {
                return this.Controls.EncodingEditComboBox.Text;
            }

            set
            {
                this.Controls.EncodingEditComboBox.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultShortMessageFormatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IShortMessageFormatWindow.DefaultShortMessageFormatStaticControl
        {
            get
            {
                if ((this.cachedDefaultShortMessageFormatStaticControl == null))
                {
                    this.cachedDefaultShortMessageFormatStaticControl =
                        new StaticControl(
                            this,
                            ShortMessageFormatWindow.ControlIDs.DefaultShortMessageFormatStaticControl);
                }

                return this.cachedMessageBodyStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MessageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IShortMessageFormatWindow.MessageBodyStaticControl
        {
            get
            {
                if ((this.cachedMessageBodyStaticControl == null))
                {
                    this.cachedMessageBodyStaticControl =
                        new StaticControl(
                            this,
                            ShortMessageFormatWindow.ControlIDs.MessageBodyStaticControl);
                }

                return this.cachedMessageBodyStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MessageBodyTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IShortMessageFormatWindow.MessageBodyTextBox
        {
            get
            {
                if ((this.cachedMessageBodyTextBox == null))
                {
                    this.cachedMessageBodyTextBox =
                        new TextBox(
                            this,
                            ShortMessageFormatWindow.ControlIDs.MessageBodyTextBox);
                }

                return this.cachedMessageBodyTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MessageBodyAlertParametersButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IShortMessageFormatWindow.MessageBodyAlertParametersButton
        {
            get
            {
                if ((this.cachedMessageBodyAlertParametersButton == null))
                {
                    this.cachedMessageBodyAlertParametersButton =
                        new Button(
                            this,
                            ShortMessageFormatWindow.ControlIDs.MessageBodyAlertParametersButton);
                }

                return this.cachedMessageBodyAlertParametersButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EncodingStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IShortMessageFormatWindow.EncodingStaticControl
        {
            get
            {
                if ((this.cachedEncodingStaticControl == null))
                {
                    this.cachedEncodingStaticControl =
                        new StaticControl(
                            this,
                            ShortMessageFormatWindow.ControlIDs.EncodingStaticControl);
                }

                return this.cachedEncodingStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EncodingEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IShortMessageFormatWindow.EncodingEditComboBox
        {
            get
            {
                if ((this.cachedEncodingEditComboBox == null))
                {
                    this.cachedEncodingEditComboBox =
                        new EditComboBox(
                            this,
                            ShortMessageFormatWindow.ControlIDs.EncodingEditComboBox);
                }

                return this.cachedEncodingEditComboBox;
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MessageBodyAlertParameters
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMessageBodyAlertParameters()
        {
            this.Controls.MessageBodyAlertParametersButton.Click();
        }

        #endregion Click Methods

        #region Strings

        /// -------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
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
                ";SMS Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SmsChannelWizardTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultShortMessageFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultShortMessageFormat =
                ";Default text message (SMS) notification format." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMSChannelSettingsPage" +
                ";defaultLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MessageBody
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMessageBody =
                ";&Text message:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMSChannelSettingsPage" +
                ";messageLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MessageBodyAlertParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMessageBodyAlertParameters =
                ";P&laceholder" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.GroupSettings.EmailNotification" +
                ";messagePlaceholder.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEncoding =
                ";En&coding:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMSChannelSettingsPage" +
                ";encodingLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultEncoding =
                ";Default" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SmsEncodingDefault";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UnicodeEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUnicodeEncoding =
                ";Unicode" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SmsEncodingUnicode";

            #endregion

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// DefaultShortMessageFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultShortMessageFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MessageBody
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMessageBody;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// MessageBodyAlertParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMessageBodyAlertParameters;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEncoding;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefaultEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultEncoding;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UnicodeEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUnicodeEncoding;

            #endregion Private Members

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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultShortMessageFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultShortMessageFormat
            {
                get
                {
                    if ((cachedDefaultShortMessageFormat == null))
                    {
                        cachedDefaultShortMessageFormat = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultShortMessageFormat);
                    }

                    return cachedDefaultShortMessageFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MessageBody translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MessageBody
            {
                get
                {
                    if ((cachedMessageBody == null))
                    {
                        cachedMessageBody = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceMessageBody);
                    }

                    return cachedMessageBody;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MessageBodyAlertParameters translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MessageBodyAlertParameters
            {
                get
                {
                    if ((cachedMessageBodyAlertParameters == null))
                    {
                        cachedMessageBodyAlertParameters = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceMessageBodyAlertParameters);
                    }

                    return cachedMessageBodyAlertParameters;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Encoding translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Encoding
            {
                get
                {
                    if ((cachedEncoding == null))
                    {
                        cachedEncoding = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEncoding);
                    }

                    return cachedEncoding;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultEncoding translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultEncoding
            {
                get
                {
                    if ((cachedDefaultEncoding == null))
                    {
                        cachedDefaultEncoding =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultEncoding);
                    }

                    return cachedDefaultEncoding;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UnicodeEncoding translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UnicodeEncoding
            {
                get
                {
                    if ((cachedUnicodeEncoding == null))
                    {
                        cachedUnicodeEncoding =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceUnicodeEncoding);
                    }

                    return cachedUnicodeEncoding;
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
        /// 	[KellyMor] 12-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for 
            /// DefaultShortMessageFormatStaticControl
            /// </summary>
            public const string DefaultShortMessageFormatStaticControl = 
                "defaultLabel";

            /// <summary>
            /// Control ID for MessageBodyStaticControl
            /// </summary>
            public const string MessageBodyStaticControl = "messageLabel";

            /// <summary>
            /// Control ID for MessageBodyTextBox
            /// </summary>
            public const string MessageBodyTextBox = "messageBox";

            /// <summary>
            /// Control ID for MessageBodyAlertParametersButton
            /// </summary>
            public const string MessageBodyAlertParametersButton =
                "messagePlaceholder";

            /// <summary>
            /// Control ID for EncodingStaticControl
            /// </summary>
            public const string EncodingStaticControl = "encodingLabel";

            /// <summary>
            /// Control ID for EncodingEditComboBox
            /// </summary>
            public const string EncodingEditComboBox = "encodings";
        }

        #endregion Control ID's
    }
}
