// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EmailFormatWindow.cs">
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
//  [KellyMor]  18-AUG-08   Updated Email and IM wizard title resources.
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

    #region Interface Definition - IEmailSettingsWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEmailFormatWindow, for EmailFormatWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEmailFormatWindow
    {
        /// <summary>
        /// Read-only property to access DefaultEmailNotificationFormatStaticControl
        /// </summary>
        StaticControl DefaultEmailNotificationFormatStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SubjectStaticControl
        /// </summary>
        StaticControl SubjectStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SubjectTextBox
        /// </summary>
        TextBox SubjectTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SubjectAlertParametersButton
        /// </summary>
        Button SubjectAlertParametersButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access to OverrideSubjectEncodingCheckBox
        /// </summary>
        CheckBox OverrideSubjectEncodingCheckBox
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
        /// Read-only property to access ImportanceLevelStaticControl
        /// </summary>
        StaticControl ImportanceLevelStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ImportanceLevelComboBox
        /// </summary>
        ComboBox ImportanceLevelComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access IsHtmlBody
        /// </summary>
        CheckBox IsHtmlBody
        {
            get;
            set;
        }

        /// <summary>
        /// Read-only property to access EncodingStaticControl
        /// </summary>
        StaticControl EncodingStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EncodingComboBox
        /// </summary>
        ComboBox EncodingComboBox
        {
            get;
        }

        /// <summary>
        ///  Exposes access to the CopyButton control
        /// </summary>
        Button CopyButton
        {
            get;
        }

        /// <summary>
        ///  Exposes access to the PasteButton control
        /// </summary>
        Button PasteButton
        {
            get;
        }

        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        Button NextButton
        {
            get;
        }

        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        Button FinishButton
        {
            get;
        }

        /// <summary>
        ///  Exposes access to the PreviewButton control
        /// </summary>
        Button PreviewButton
        {
            get;
        }
        /// <summary>
        ///  Exposes access to the MenuButton control
        /// </summary>
        Button MenuButton
        {
            get;
        }
    }

    #endregion Interface Definition - IEmailSettingsWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Email Format page of the Email Channel
    /// Wizard.
    /// </summary>
    /// <history>
    ///     [KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class EmailFormatWindow : Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, IEmailFormatWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members

        /// <summary>
        /// Cache to hold a reference to DefaultEmailNotificationFormatStaticControl
        /// of type StaticControl
        /// </summary>
        private StaticControl cachedDefaultEmailNotificationFormatStaticControl;

        /// <summary>
        /// Cache to hold a reference to SubjectStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedSubjectStaticControl;

        /// <summary>
        /// Cache to hold a reference to SubjectTextBox of type TextBox
        /// </summary>
        private TextBox cachedSubjectTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SubjectAlertParametersButton of type 
        /// Button
        /// </summary>
        private Button cachedSubjectAlertParametersButton;

        /// <summary>
        /// Cache to hold a reference to OverrideSubjectEncodingCheckBox of 
        /// type CheckBox
        /// </summary>
        private CheckBox cachedOverrideSubjectEncodingCheckBox;

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
        /// Cache to hold a reference to ImportanceLevelStaticControl of type 
        /// StaticControl
        /// </summary>
        private StaticControl cachedImportanceLevelStaticControl;

        /// <summary>
        /// Cache to hold a reference to ImportanceLevelComboBox of type 
        /// ComboBox
        /// </summary>
        private ComboBox cachedImportanceLevelComboBox;

        /// <summary>
        /// Cache to hold a reference to EncodingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEncodingStaticControl;

        /// <summary>
        /// Cache to hold a reference to EncodingComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedEncodingComboBox;

        /// <summary>
        /// Cache to hold a reference to IsHtmlBody of type Checkbox
        /// </summary>
        private CheckBox cachedIsHtmlBody;

        /// <summary>
        /// Cache to hold a reference to copy button of type button
        /// </summary>
        private Button cachedCopyButton;

        /// <summary>
        /// Cache to hold a reference to paste button of type button
        /// </summary>
        private Button cachedpasteButton;

        /// <summary>
        /// Cache to hold a reference to next button of type button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to Finish button of type button
        /// </summary>
        private Button cachedFinishButton;

        /// <summary>
        /// Cache to hold a reference to Preview button of type button
        /// </summary>
        private Button cachedPreviewButton;

        /// <summary>
        /// Cache to hold a reference to Menu button of type button
        /// </summary>
        private Button cachedMenuButton;

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
        public EmailFormatWindow(ConsoleApp app)
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
        public new IEmailFormatWindow Controls
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

        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox OverrideSubjectEncoding
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool OverrideSubjectEncoding
        {
            get
            {
                return this.Controls.OverrideSubjectEncodingCheckBox.Checked;
            }

            set
            {
                this.Controls.OverrideSubjectEncodingCheckBox.Checked = value;
            }
        }

        #endregion

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Subject
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SubjectText
        {
            get
            {
                return this.Controls.SubjectTextBox.Text;
            }

            set
            {
                this.Controls.SubjectTextBox.Text = value;
            }
        }

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
        ///  Routine to set/get the text in control Encoding
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
                return this.Controls.EncodingComboBox.Text;
            }

            set
            {
                this.Controls.EncodingComboBox.SelectByText(value, true);
            }
        }
        
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultEmailNotificationFormatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailFormatWindow.DefaultEmailNotificationFormatStaticControl
        {
            get
            {
                if ((this.cachedDefaultEmailNotificationFormatStaticControl == null))
                {
                    this.cachedDefaultEmailNotificationFormatStaticControl = 
                        new StaticControl(
                            this,
                            EmailFormatWindow.ControlIDs.DefaultEmailNotificationFormatStaticControl);
                }

                return this.cachedDefaultEmailNotificationFormatStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubjectStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailFormatWindow.SubjectStaticControl
        {
            get
            {
                if ((this.cachedSubjectStaticControl == null))
                {
                    this.cachedSubjectStaticControl = 
                        new StaticControl(
                            this,
                            EmailFormatWindow.ControlIDs.SubjectStaticControl);
                }

                return this.cachedSubjectStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubjectTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEmailFormatWindow.SubjectTextBox
        {
            get
            {
                if ((this.cachedSubjectTextBox == null))
                {
                    this.cachedSubjectTextBox = 
                        new TextBox(
                            this,
                            EmailFormatWindow.ControlIDs.SubjectTextBox);
                }

                return this.cachedSubjectTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubjectAlertParametersButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEmailFormatWindow.SubjectAlertParametersButton
        {
            get
            {
                if ((this.cachedSubjectAlertParametersButton == null))
                {
                    this.cachedSubjectAlertParametersButton = 
                        new Button(
                            this,
                            EmailFormatWindow.ControlIDs.SubjectAlertParametersButton);
                }

                return this.cachedSubjectAlertParametersButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OverrideSubjectEncodingCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IEmailFormatWindow.OverrideSubjectEncodingCheckBox
        {
            get
            {
                if ((this.cachedOverrideSubjectEncodingCheckBox == null))
                {
                    this.cachedOverrideSubjectEncodingCheckBox = 
                        new CheckBox(
                            this,
                            EmailFormatWindow.ControlIDs.OverrideSubjectEncodingCheckBox);
                }

                return this.cachedOverrideSubjectEncodingCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EmailMessageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailFormatWindow.MessageBodyStaticControl
        {
            get
            {
                if ((this.cachedMessageBodyStaticControl == null))
                {
                    this.cachedMessageBodyStaticControl = 
                        new StaticControl(
                            this,
                            EmailFormatWindow.ControlIDs.MessageBodyStaticControl);
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
        TextBox IEmailFormatWindow.MessageBodyTextBox
        {
            get
            {
                if ((this.cachedMessageBodyTextBox == null))
                {
                    this.cachedMessageBodyTextBox = 
                        new TextBox(
                            this,
                            EmailFormatWindow.ControlIDs.MessageBodyTextBox);
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
        Button IEmailFormatWindow.MessageBodyAlertParametersButton
        {
            get
            {
                if ((this.cachedMessageBodyAlertParametersButton == null))
                {
                    this.cachedMessageBodyAlertParametersButton = 
                        new Button(
                            this, 
                            EmailFormatWindow.ControlIDs.MessageBodyAlertParametersButton);
                }

                return this.cachedMessageBodyAlertParametersButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ImportanceLevelStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailFormatWindow.ImportanceLevelStaticControl
        {
            get
            {
                if ((this.cachedImportanceLevelStaticControl == null))
                {
                    this.cachedImportanceLevelStaticControl =
                        new StaticControl(
                            this,
                            EmailFormatWindow.ControlIDs.ImportanceLevelStaticControl);
                }

                return this.cachedImportanceLevelStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ImportanceLevelComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEmailFormatWindow.ImportanceLevelComboBox
        {
            get
            {
                if ((this.cachedImportanceLevelComboBox == null))
                {
                    this.cachedImportanceLevelComboBox =
                        new ComboBox(
                            this,
                            EmailFormatWindow.ControlIDs.ImportanceLevelComboBox);
                }

                return this.cachedImportanceLevelComboBox;
            }
        }

        /// <summary>
        ///  Exposes access to the IsHtmlBody control
        /// </summary>
        CheckBox IEmailFormatWindow.IsHtmlBody
        {
            get
            {
                if ((this.cachedIsHtmlBody == null))
                {
                    this.cachedIsHtmlBody =
                        new CheckBox(
                            this,
                            EmailFormatWindow.ControlIDs.IsHtmlBody);
                }

                return this.cachedIsHtmlBody;
            }
            set
            {
                if ((this.cachedIsHtmlBody == null))
                {
                    this.cachedIsHtmlBody =
                        new CheckBox(
                            this,
                            EmailFormatWindow.ControlIDs.IsHtmlBody);
                }

                this.cachedIsHtmlBody.Checked = value.Checked;

            }
        }

        /// <summary>
        ///  Exposes access to the CopyButton control
        /// </summary>
        Button IEmailFormatWindow.CopyButton
        {
            get
            {
                if ((this.cachedCopyButton == null))
                {
                    this.cachedCopyButton =
                        new Button(
                            this,
                            EmailFormatWindow.ControlIDs.CopyButton);
                }

                return this.cachedCopyButton;
            }
        }

        /// <summary>
        ///  Exposes access to the PasteButton control
        /// </summary>
        Button IEmailFormatWindow.PasteButton
        {
            get
            {
                if ((this.cachedpasteButton == null))
                {
                    this.cachedpasteButton =
                        new Button(
                            this,
                            EmailFormatWindow.ControlIDs.pasteButton);
                }

                return this.cachedpasteButton;
            }
        }

        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        Button IEmailFormatWindow.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton =
                        new Button(
                            this,
                            EmailFormatWindow.ControlIDs.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        Button IEmailFormatWindow.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton =
                        new Button(
                            this,
                            EmailFormatWindow.ControlIDs.FinishButton);
                }

                return this.cachedFinishButton;
            }
        }

        /// <summary>
        ///  Exposes access to the PreviewButton control
        /// </summary>
        Button IEmailFormatWindow.PreviewButton
        {
            get
            {
                if ((this.cachedPreviewButton == null))
                {
                    this.cachedPreviewButton =
                        new Button(
                            this,
                            EmailFormatWindow.ControlIDs.PreviewButton);
                }

                return this.cachedPreviewButton;
            }
        }

        /// <summary>
        ///  Exposes access to the MenuButton control
        /// </summary>
        Button IEmailFormatWindow.MenuButton
        {
            get
            {
                if ((this.cachedMenuButton == null))
                {
                    this.cachedMenuButton =
                        new Button(
                            this,
                            EmailFormatWindow.ControlIDs.MenuButton);
                }

                return this.cachedMenuButton;
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
        StaticControl IEmailFormatWindow.EncodingStaticControl
        {
            get
            {
                if ((this.cachedEncodingStaticControl == null))
                {
                    this.cachedEncodingStaticControl = 
                        new StaticControl(
                            this,
                            EmailFormatWindow.ControlIDs.EncodingStaticControl);
                }

                return this.cachedEncodingStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EncodingComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEmailFormatWindow.EncodingComboBox
        {
            get
            {
                if ((this.cachedEncodingComboBox == null))
                {
                    this.cachedEncodingComboBox = 
                        new ComboBox(
                            this,
                            EmailFormatWindow.ControlIDs.EncodingComboBox);
                }

                return this.cachedEncodingComboBox;
            }
        }
        
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SubjectAlertParameters
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSubjectAlertParameters()
        {
            this.Controls.SubjectAlertParametersButton.Click();
        }

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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OverrideSubjectEncoding
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOverrideSubjectEncoding()
        {
            this.Controls.OverrideSubjectEncodingCheckBox.Click();
        }

        #endregion Click Methods

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
            /// Contains resource string for the default email notification
            /// format
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDefaultEmailNotificationFormat =
                ";Default e-mail notification format:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelFormatPage" +
                ";formatLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Subject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSubject =
                ";E-mail s&ubject:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelFormatPage" +
                ";subjectLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SubjectAlertParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSubjectAlertParameters = 
                ";subjectPlaceholder" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelFormatPage" +
                ";>>subjectPlaceholder.Name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OverrideSubjectEncoding 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOverrideSubjectEncoding =
                ";&Generate subject line with no encoding (use if notification e-mails contain malformed subject lines)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelFormatPage" +
                ";noSubjectEncodingCheckBox.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MessageBody
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMessageBody =
                ";E-&mail message:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelFormatPage" +
                ";messageLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MessageBodyAlertParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMessageBodyAlertParameters =
                ";messagePlaceholder" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelFormatPage" +
                ";>>messagePlaceholder.Name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Importance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceImportance =
                ";&Importance" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelFormatPage" +
                ";label1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Importance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHighImportance =
                ";High" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";EmailImportanceHigh";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Importance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMediumImportance =
                ";Normal" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";EmailImportanceNormal";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Importance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLowImportance =
                ";Low" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";EmailImportanceLow";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEncoding =
                ";En&coding:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SMTPChannelFormatPage" +
                ";encodingLabel.Text";

            #endregion Constants

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefaultEmailNotificationFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultEmailNotificationFormat;
          
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Subject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubject;
  
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SubjectAlertParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubjectAlertParameters;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OverrideSubjectEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverrideSubjectEncoding;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MessageBody
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMessageBody;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MessageBodyAlertParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMessageBodyAlertParameters;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Importance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedImportance;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HighImportance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHighImportance;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MediumImportance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMediumImportance;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LowImportance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLowImportance;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEncoding;

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
            /// Exposes access to the DefaultEmailNotificationFormat translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DefaultEmailNotificationFormat
            {
                get
                {
                    if ((cachedDefaultEmailNotificationFormat == null))
                    {
                        cachedDefaultEmailNotificationFormat =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDefaultEmailNotificationFormat);
                    }

                    return cachedDefaultEmailNotificationFormat;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subject translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Subject
            {
                get
                {
                    if ((cachedSubject == null))
                    {
                        cachedSubject =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubject);
                    }

                    return cachedSubject;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubjectAlertParameters translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubjectAlertParameters
            {
                get
                {
                    if ((cachedSubjectAlertParameters == null))
                    {
                        cachedSubjectAlertParameters =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubjectAlertParameters);
                    }

                    return cachedSubjectAlertParameters;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OverrideSubjectEncoding translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string OverrideSubjectEncoding
            {
                get
                {
                    if ((cachedOverrideSubjectEncoding == null))
                    {
                        cachedOverrideSubjectEncoding =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceOverrideSubjectEncoding);
                    }

                    return cachedOverrideSubjectEncoding;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MessageBody translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
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

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MessageBodyAlertParameters translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
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

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Importance translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Importance
            {
                get
                {
                    if ((cachedImportance == null))
                    {
                        cachedImportance =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceImportance);
                    }

                    return cachedImportance;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HighImportance translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string HighImportance
            {
                get
                {
                    if ((cachedHighImportance == null))
                    {
                        cachedHighImportance =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceHighImportance);
                    }

                    return cachedHighImportance;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MediumImportance translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string MediumImportance
            {
                get
                {
                    if ((cachedMediumImportance == null))
                    {
                        cachedMediumImportance =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceMediumImportance);
                    }

                    return cachedMediumImportance;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LowImportance translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string LowImportance
            {
                get
                {
                    if ((cachedLowImportance == null))
                    {
                        cachedLowImportance =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceLowImportance);
                    }

                    return cachedLowImportance;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Encoding translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
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
            /// Control ID for paste button
            /// </summary>
            public const string pasteButton = "pasteButton";

            /// <summary>
            /// Control ID for copy button
            /// </summary>
            public const string CopyButton = "copyButton";

            /// <summary>
            /// Control ID for next button
            /// </summary>
            public const string NextButton = "nextButton";

            /// <summary>
            /// Control ID for Finish button
            /// </summary>
            public const string FinishButton = "commitButton";

            /// <summary>
            /// Control ID for Finish button
            /// </summary>
            public const string PreviewButton = "previewhtml";

            /// <summary>
            /// Control ID for Finish button
            /// </summary>
            public const string MenuButton = "messagePlaceholder";


            /// <summary>
            /// Control ID for IsHtmlBody
            /// </summary>
            public const string IsHtmlBody = "isHtmlBody";

            /// <summary>
            /// Control ID for DefaultEmailNotificationFormatStaticControl
            /// </summary>
            public const string DefaultEmailNotificationFormatStaticControl = 
                "formatLabel";

            /// <summary>
            /// Control ID for SubjectStaticControl
            /// </summary>
            public const string SubjectStaticControl = "subjectLabel";

            /// <summary>
            /// Control ID for SubjectTextBox
            /// </summary>
            public const string SubjectTextBox = "subject";

            /// <summary>
            /// Control ID for SubjectAlertParametersButton
            /// </summary>
            public const string SubjectAlertParametersButton = 
                "subjectPlaceholder";

            /// <summary>
            /// Control ID for OverrideSubjectEncodingCheckBox
            /// </summary>
            public const string OverrideSubjectEncodingCheckBox = 
                "noSubjectEncodingCheckBox";

            /// <summary>
            /// Control ID for MessageBodyStaticControl
            /// </summary>
            public const string MessageBodyStaticControl = "messageLabel";

            /// <summary>
            /// Control ID for MessageBodyTextBox
            /// </summary>
            public const string MessageBodyTextBox = "message";

            /// <summary>
            /// Control ID for MessageBodyAlertParametersButton
            /// </summary>
            public const string MessageBodyAlertParametersButton = 
                "messagePlaceholder";

            /// <summary>
            /// Control ID for ImportanceLevelStaticControl
            /// </summary>
            public const string ImportanceLevelStaticControl = 
                "label1";

            /// <summary>
            /// Control ID for ImportanceLevelComboBox
            /// </summary>
            public const string ImportanceLevelComboBox = "importantComboBox";

            /// <summary>
            /// Control ID for EncodingStaticControl
            /// </summary>
            public const string EncodingStaticControl = "encodingLabel";

            /// <summary>
            /// Control ID for EncodingComboBox
            /// </summary>
            public const string EncodingComboBox = "encodings";
        }

        #endregion Control ID's
    }
}
