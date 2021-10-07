// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EmailNotificationDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor]  05-Apr-06   Created
//  [KellyMor]  17-Apr-06   Added click method for "Add" toolstrip button
//  [KellyMor]  18-Apr-06   Updated ToolStrip control property
//                          Updated click methods for toolstrip items
//                          Fixed issue with Init method finding dialog window
//  [KellyMor]  20-Apr-06   Fixed a bug in the init method
//  [KellyMor]  07-Jun-06   Updated resource assembly for new Admin assembly
//  [KellyMor]  12-Jun-06   Fixed issue with dialog title prefix changing from MOM to SCE
//  [KellyMor]  26-Jun-06   Increase number of retries from 5 to 10 in Init method
//  [KellyMor]  18-Jan-07   Modified constructors to reduce window search time
//                          Modified ToolStrip1 control property constructor
//                          Modified ToolStrip ClickX methods
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IEmailNotificationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEmailNotificationDialogControls, for EmailNotificationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEmailNotificationDialogControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PlaceholderButton
        /// </summary>
        Button PlaceholderButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PlaceholderButton2
        /// </summary>
        Button PlaceholderButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        ToolStrip ToolStrip1
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
        /// Read-only property to access EncodingStaticControl
        /// </summary>
        StaticControl EncodingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EmailMessageTextBox
        /// </summary>
        TextBox EmailMessageTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EmailMessageStaticControl
        /// </summary>
        StaticControl EmailMessageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EmailSubjectTextBox
        /// </summary>
        TextBox EmailSubjectTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EmailSubjectStaticControl
        /// </summary>
        StaticControl EmailSubjectStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DefaultEmailNotificationFormatStaticControl
        /// </summary>
        StaticControl DefaultEmailNotificationFormatStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MinutesStaticControl
        /// </summary>
        StaticControl MinutesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RetryPrimaryAfterComboBox
        /// </summary>
        ComboBox RetryPrimaryAfterComboBox
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
        /// Read-only property to access ReturnAddressTextBox
        /// </summary>
        TextBox ReturnAddressTextBox
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
        /// Read-only property to access ServersListView
        /// </summary>
        ListView ServersListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SMTPServersStaticControl
        /// </summary>
        StaticControl SMTPServersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnableEmailNotificationCheckBox
        /// </summary>
        CheckBox EnableEmailNotificationCheckBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Email Notification tab of the Notifiations dialog
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class EmailNotificationDialog : Dialog, IEmailNotificationDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 5000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to PlaceholderButton of type Button
        /// </summary>
        private Button cachedPlaceholderButton;
        
        /// <summary>
        /// Cache to hold a reference to PlaceholderButton2 of type Button
        /// </summary>
        private Button cachedPlaceholderButton2;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type ToolStrip
        /// </summary>
        private ToolStrip cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to EncodingComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedEncodingComboBox;
        
        /// <summary>
        /// Cache to hold a reference to EncodingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEncodingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EmailMessageTextBox of type TextBox
        /// </summary>
        private TextBox cachedEmailMessageTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EmailMessageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEmailMessageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EmailSubjectTextBox of type TextBox
        /// </summary>
        private TextBox cachedEmailSubjectTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EmailSubjectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEmailSubjectStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DefaultEmailNotificationFormatStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefaultEmailNotificationFormatStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MinutesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMinutesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RetryPrimaryAfterComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedRetryPrimaryAfterComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RetryPrimaryAfterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRetryPrimaryAfterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ReturnAddressTextBox of type TextBox
        /// </summary>
        private TextBox cachedReturnAddressTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ReturnAddressStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedReturnAddressStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServersListView of type ListView
        /// </summary>
        private ListView cachedServersListView;
        
        /// <summary>
        /// Cache to hold a reference to SMTPServersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSMTPServersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnableEmailNotificationCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnableEmailNotificationCheckBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of EmailNotificationDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EmailNotificationDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IEmailNotificationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEmailNotificationDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox EnableEmailNotification
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool EnableEmailNotification
        {
            get
            {
                return this.Controls.EnableEmailNotificationCheckBox.Checked;
            }
            
            set
            {
                this.Controls.EnableEmailNotificationCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Encoding2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EmailMessageText
        {
            get
            {
                return this.Controls.EmailMessageTextBox.Text;
            }
            
            set
            {
                this.Controls.EmailMessageTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EmailSubject
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EmailSubjectText
        {
            get
            {
                return this.Controls.EmailSubjectTextBox.Text;
            }
            
            set
            {
                this.Controls.EmailSubjectTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RetryPrimaryAfter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RetryPrimaryAfterText
        {
            get
            {
                return this.Controls.RetryPrimaryAfterComboBox.Text;
            }
            
            set
            {
                this.Controls.RetryPrimaryAfterComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ReturnAddress
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
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
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEmailNotificationDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, EmailNotificationDialog.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEmailNotificationDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EmailNotificationDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEmailNotificationDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, EmailNotificationDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IEmailNotificationDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, EmailNotificationDialog.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PlaceholderButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEmailNotificationDialogControls.PlaceholderButton
        {
            get
            {
                if ((this.cachedPlaceholderButton == null))
                {
                    this.cachedPlaceholderButton = new Button(this, EmailNotificationDialog.ControlIDs.PlaceholderButton);
                }
                return this.cachedPlaceholderButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PlaceholderButton2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEmailNotificationDialogControls.PlaceholderButton2
        {
            get
            {
                if ((this.cachedPlaceholderButton2 == null))
                {
                    this.cachedPlaceholderButton2 = new Button(this, EmailNotificationDialog.ControlIDs.PlaceholderButton2);
                }
                return this.cachedPlaceholderButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ToolStrip IEmailNotificationDialogControls.ToolStrip1
        {
            get
            {
                //Window window = new Control(this, ControlIDs.SmtpServersPanel); // panel4
                //Core.Common.Utilities.LogMessage("Accessible object name:  '" + window.Extended.AccessibleObject.Name + "'");
                //Core.Common.Utilities.LogMessage("Accessible object role:  '" + window.Extended.AccessibleObject.Role + "'");
                //Core.Common.Utilities.LogMessage("Accessible object role text:  '" + window.Extended.AccessibleObject.RoleText + "'");

                //window = window.Extended.FirstChild;
                //Core.Common.Utilities.LogMessage("Accessible object name:  '" + window.Extended.AccessibleObject.Name + "'");
                //Core.Common.Utilities.LogMessage("Accessible object role:  '" + window.Extended.AccessibleObject.Role + "'");
                //Core.Common.Utilities.LogMessage("Accessible object role text:  '" + window.Extended.AccessibleObject.RoleText + "'");
                
                //this.cachedToolStrip1 = new ToolStrip(window, ControlIDs.ToolStrip1);

                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new ToolStrip(this); //, EmailNotificationDialog.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
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
        ComboBox IEmailNotificationDialogControls.EncodingComboBox
        {
            get
            {
                if ((this.cachedEncodingComboBox == null))
                {
                    this.cachedEncodingComboBox = new ComboBox(this, EmailNotificationDialog.ControlIDs.EncodingComboBox);
                }
                return this.cachedEncodingComboBox;
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
        StaticControl IEmailNotificationDialogControls.EncodingStaticControl
        {
            get
            {
                if ((this.cachedEncodingStaticControl == null))
                {
                    this.cachedEncodingStaticControl = new StaticControl(this, EmailNotificationDialog.ControlIDs.EncodingStaticControl);
                }
                return this.cachedEncodingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EmailMessageTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEmailNotificationDialogControls.EmailMessageTextBox
        {
            get
            {
                if ((this.cachedEmailMessageTextBox == null))
                {
                    this.cachedEmailMessageTextBox = new TextBox(this, EmailNotificationDialog.ControlIDs.EmailMessageTextBox);
                }
                return this.cachedEmailMessageTextBox;
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
        StaticControl IEmailNotificationDialogControls.EmailMessageStaticControl
        {
            get
            {
                if ((this.cachedEmailMessageStaticControl == null))
                {
                    this.cachedEmailMessageStaticControl = new StaticControl(this, EmailNotificationDialog.ControlIDs.EmailMessageStaticControl);
                }
                return this.cachedEmailMessageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EmailSubjectTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEmailNotificationDialogControls.EmailSubjectTextBox
        {
            get
            {
                if ((this.cachedEmailSubjectTextBox == null))
                {
                    this.cachedEmailSubjectTextBox = new TextBox(this, EmailNotificationDialog.ControlIDs.EmailSubjectTextBox);
                }
                return this.cachedEmailSubjectTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EmailSubjectStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailNotificationDialogControls.EmailSubjectStaticControl
        {
            get
            {
                if ((this.cachedEmailSubjectStaticControl == null))
                {
                    this.cachedEmailSubjectStaticControl = new StaticControl(this, EmailNotificationDialog.ControlIDs.EmailSubjectStaticControl);
                }
                return this.cachedEmailSubjectStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultEmailNotificationFormatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailNotificationDialogControls.DefaultEmailNotificationFormatStaticControl
        {
            get
            {
                if ((this.cachedDefaultEmailNotificationFormatStaticControl == null))
                {
                    this.cachedDefaultEmailNotificationFormatStaticControl = new StaticControl(this, EmailNotificationDialog.ControlIDs.DefaultEmailNotificationFormatStaticControl);
                }
                return this.cachedDefaultEmailNotificationFormatStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinutesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailNotificationDialogControls.MinutesStaticControl
        {
            get
            {
                if ((this.cachedMinutesStaticControl == null))
                {
                    this.cachedMinutesStaticControl = new StaticControl(this, EmailNotificationDialog.ControlIDs.MinutesStaticControl);
                }
                return this.cachedMinutesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RetryPrimaryAfterComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEmailNotificationDialogControls.RetryPrimaryAfterComboBox
        {
            get
            {
                if ((this.cachedRetryPrimaryAfterComboBox == null))
                {
                    this.cachedRetryPrimaryAfterComboBox = new ComboBox(this, EmailNotificationDialog.ControlIDs.RetryPrimaryAfterComboBox);
                }
                return this.cachedRetryPrimaryAfterComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RetryPrimaryAfterStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailNotificationDialogControls.RetryPrimaryAfterStaticControl
        {
            get
            {
                if ((this.cachedRetryPrimaryAfterStaticControl == null))
                {
                    this.cachedRetryPrimaryAfterStaticControl = new StaticControl(this, EmailNotificationDialog.ControlIDs.RetryPrimaryAfterStaticControl);
                }
                return this.cachedRetryPrimaryAfterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReturnAddressTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEmailNotificationDialogControls.ReturnAddressTextBox
        {
            get
            {
                if ((this.cachedReturnAddressTextBox == null))
                {
                    this.cachedReturnAddressTextBox = new TextBox(this, EmailNotificationDialog.ControlIDs.ReturnAddressTextBox);
                }
                return this.cachedReturnAddressTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReturnAddressStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailNotificationDialogControls.ReturnAddressStaticControl
        {
            get
            {
                if ((this.cachedReturnAddressStaticControl == null))
                {
                    this.cachedReturnAddressStaticControl = new StaticControl(this, EmailNotificationDialog.ControlIDs.ReturnAddressStaticControl);
                }
                return this.cachedReturnAddressStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServersListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IEmailNotificationDialogControls.ServersListView
        {
            get
            {
                if ((this.cachedServersListView == null))
                {
                    this.cachedServersListView = new ListView(this, EmailNotificationDialog.ControlIDs.ServersListView);
                }
                return this.cachedServersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SMTPServersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEmailNotificationDialogControls.SMTPServersStaticControl
        {
            get
            {
                if ((this.cachedSMTPServersStaticControl == null))
                {
                    this.cachedSMTPServersStaticControl = new StaticControl(this, EmailNotificationDialog.ControlIDs.SMTPServersStaticControl);
                }
                return this.cachedSMTPServersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnableEmailNotificationCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IEmailNotificationDialogControls.EnableEmailNotificationCheckBox
        {
            get
            {
                if ((this.cachedEnableEmailNotificationCheckBox == null))
                {
                    this.cachedEnableEmailNotificationCheckBox = new CheckBox(this, EmailNotificationDialog.ControlIDs.EnableEmailNotificationCheckBox);
                }
                return this.cachedEnableEmailNotificationCheckBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Placeholder
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPlaceholder()
        {
            this.Controls.PlaceholderButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Placeholder2
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPlaceholder2()
        {
            this.Controls.PlaceholderButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EnableEmailNotification
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEnableEmailNotification()
        {
            this.Controls.EnableEmailNotificationCheckBox.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Add" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/17/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            //// force the focus on to the dialog
            //this.SetFocus();

            //// get the hot-key from the resource string
            //Core.Common.Utilities.LogMessage("Getting hot-key for:  '" + Strings.AddToolStripItem + "'");
            //string hotKey = Strings.AddToolStripItem.Substring((Strings.AddToolStripItem.IndexOf("&") + 1), 1);
            //string hotKeySequence = "%(" + hotKey + ")";

            //// send the hot-key to the dialog
            //Core.Common.Utilities.LogMessage("Sending hot-key:  '" + hotKey + "'");
            //Core.Common.Utilities.LogMessage("Using hot-key squence:  '" + hotKeySequence + "'");
            //this.SendKeys(hotKeySequence);

            this.Controls.ToolStrip1.ToolStripItems[0].Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Edit" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/17/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            //// get the hot-key from the resource string
            //Core.Common.Utilities.LogMessage("Getting hot-key for:  '" + Strings.EditToolStripItem + "'");
            //string hotKey = Strings.EditToolStripItem.Substring((Strings.EditToolStripItem.IndexOf("&") + 1), 1);
            //string hotKeySequence = "%(" + hotKey + ")";

            //// send the hot-key to the dialog
            //Core.Common.Utilities.LogMessage("Sending hot-key:  '" + hotKey + "'");
            //this.SendKeys(hotKeySequence);

            this.Controls.ToolStrip1.ToolStripItems[1].Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Remove" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/17/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            //// get the hot-key from the resource string
            //Core.Common.Utilities.LogMessage("Getting hot-key for:  '" + Strings.RemoveToolStripItem + "'");
            //string hotKey = Strings.RemoveToolStripItem.Substring((Strings.RemoveToolStripItem.IndexOf("&") + 1), 1);
            //string hotKeySequence = "%(" + hotKey + ")";

            //// send the hot-key to the dialog
            //Core.Common.Utilities.LogMessage("Sending hot-key:  '" + hotKey + "'");
            //this.SendKeys(hotKeySequence);

            this.Controls.ToolStrip1.ToolStripItems[2].Click();
        }

        // TODO:  "Move Up", and "Move Down" buttons

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, 
                    Timeout);
            }            
            catch (Exceptions.WindowNotFoundException ex)
            {
                Common.Utilities.LogMessage(
                    "Looking for window with title:  '" +
                    Strings.DialogTitle +
                    "'");

                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 10;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Common.Utilities.LogMessage("Failed to find the Add SMTP Server dialog window!");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// String definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix on MOM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogMomTitlePrefix = ";Global Management Group Settings -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix on SCE
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogSceTitlePrefix = ";Global Management Settings -;ManagedString;Microsoft.EnterpriseManagement.SCE.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.AdministrationSpace.AdminResources;GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitleSuffix = ";Notification;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SettingsResources;GroupNotification";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// <remarks>TODO:  Find common resource for Apply</remarks>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;DC01.bQ;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;buttonOK.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Placeholder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlaceholder = ";P&laceholder;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;message" +
                "Placeholder.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Placeholder2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlaceholder2 = ";&Placeholder;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;subject" +
                "Placeholder.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEncoding = ";En&coding:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;encodingL" +
                "abel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EmailMessage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEmailMessage = ";E&mail message:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;mess" +
                "ageLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EmailSubject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEmailSubject = ";Email s&ubject:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;subj" +
                "ectLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultEmailNotificationFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultEmailNotificationFormat = ";Default email notification format:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.Ema" +
                "ilNotification;formatLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinutes = ";minutes;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;minutesLabel" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RetryPrimaryAfter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRetryPrimaryAfter = ";Retry primary a&fter:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotificatio" +
                "n;retryLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ReturnAddress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceReturnAddress = ";Re&turn address:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;ret" +
                "urnAddressLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SMTPServers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSMTPServers = ";&SMTP servers:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;serve" +
                "rsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnableEmailNotification
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnableEmailNotification = ";Ena&ble email notification;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotifi" +
                "cation;enabled.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddToolStripItem = ";A&dd...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;add.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EditToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEditToolStripItem = ";&Edit...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;edit.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemoveToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveToolStripItem = ";Remo&ve;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification;remove.Text";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitlePrefix;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitleSuffix;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Placeholder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlaceholder;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Placeholder2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlaceholder2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEncoding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EmailMessage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEmailMessage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EmailSubject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEmailSubject;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefaultEmailNotificationFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultEmailNotificationFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinutes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RetryPrimaryAfter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRetryPrimaryAfter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ReturnAddress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReturnAddress;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SMTPServers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSMTPServers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnableEmailNotification
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnableEmailNotification;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddToolStripItem;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EditToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditToolStripItem;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RemoveToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemoveToolStripItem;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitlePrefix == null) || (cachedDialogTitleSuffix == null))
                    {
                        //if (ProductSku.Sku == ProductSkuLevel.Mom)
                        cachedDialogTitlePrefix = CoreManager.MomConsole.GetIntlStr(ResourceDialogMomTitlePrefix);
                        cachedDialogTitleSuffix = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitleSuffix);
                    }
                    return (cachedDialogTitlePrefix + " " + cachedDialogTitleSuffix);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    return cachedTab0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Placeholder translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Placeholder
            {
                get
                {
                    if ((cachedPlaceholder == null))
                    {
                        cachedPlaceholder = CoreManager.MomConsole.GetIntlStr(ResourcePlaceholder);
                    }
                    return cachedPlaceholder;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Placeholder2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Placeholder2
            {
                get
                {
                    if ((cachedPlaceholder2 == null))
                    {
                        cachedPlaceholder2 = CoreManager.MomConsole.GetIntlStr(ResourcePlaceholder2);
                    }
                    return cachedPlaceholder2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1
            {
                get
                {
                    if ((cachedToolStrip1 == null))
                    {
                        cachedToolStrip1 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1);
                    }
                    return cachedToolStrip1;
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
                        cachedEncoding = CoreManager.MomConsole.GetIntlStr(ResourceEncoding);
                    }
                    return cachedEncoding;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EmailMessage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EmailMessage
            {
                get
                {
                    if ((cachedEmailMessage == null))
                    {
                        cachedEmailMessage = CoreManager.MomConsole.GetIntlStr(ResourceEmailMessage);
                    }
                    return cachedEmailMessage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EmailSubject translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EmailSubject
            {
                get
                {
                    if ((cachedEmailSubject == null))
                    {
                        cachedEmailSubject = CoreManager.MomConsole.GetIntlStr(ResourceEmailSubject);
                    }
                    return cachedEmailSubject;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultEmailNotificationFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultEmailNotificationFormat
            {
                get
                {
                    if ((cachedDefaultEmailNotificationFormat == null))
                    {
                        cachedDefaultEmailNotificationFormat = CoreManager.MomConsole.GetIntlStr(ResourceDefaultEmailNotificationFormat);
                    }
                    return cachedDefaultEmailNotificationFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Minutes translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Minutes
            {
                get
                {
                    if ((cachedMinutes == null))
                    {
                        cachedMinutes = CoreManager.MomConsole.GetIntlStr(ResourceMinutes);
                    }
                    return cachedMinutes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RetryPrimaryAfter translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RetryPrimaryAfter
            {
                get
                {
                    if ((cachedRetryPrimaryAfter == null))
                    {
                        cachedRetryPrimaryAfter = CoreManager.MomConsole.GetIntlStr(ResourceRetryPrimaryAfter);
                    }
                    return cachedRetryPrimaryAfter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ReturnAddress translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReturnAddress
            {
                get
                {
                    if ((cachedReturnAddress == null))
                    {
                        cachedReturnAddress = CoreManager.MomConsole.GetIntlStr(ResourceReturnAddress);
                    }
                    return cachedReturnAddress;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SMTPServers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SMTPServers
            {
                get
                {
                    if ((cachedSMTPServers == null))
                    {
                        cachedSMTPServers = CoreManager.MomConsole.GetIntlStr(ResourceSMTPServers);
                    }
                    return cachedSMTPServers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnableEmailNotification translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnableEmailNotification
            {
                get
                {
                    if ((cachedEnableEmailNotification == null))
                    {
                        cachedEnableEmailNotification = CoreManager.MomConsole.GetIntlStr(ResourceEnableEmailNotification);
                    }
                    return cachedEnableEmailNotification;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddToolStripItem
            {
                get
                {
                    if ((cachedAddToolStripItem == null))
                    {
                        cachedAddToolStripItem = CoreManager.MomConsole.GetIntlStr(ResourceAddToolStripItem);
                    }
                    return cachedAddToolStripItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EditToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EditToolStripItem
            {
                get
                {
                    if ((cachedEditToolStripItem == null))
                    {
                        cachedEditToolStripItem = CoreManager.MomConsole.GetIntlStr(ResourceEditToolStripItem);
                    }
                    return cachedEditToolStripItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RemoveToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemoveToolStripItem
            {
                get
                {
                    if ((cachedRemoveToolStripItem == null))
                    {
                        cachedRemoveToolStripItem = CoreManager.MomConsole.GetIntlStr(ResourceRemoveToolStripItem);
                    }
                    return cachedRemoveToolStripItem;
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
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for PlaceholderButton
            /// </summary>
            public const string PlaceholderButton = "messagePlaceholder";
            
            /// <summary>
            /// Control ID for PlaceholderButton2
            /// </summary>
            public const string PlaceholderButton2 = "subjectPlaceholder";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip";
            
            /// <summary>
            /// Control ID for EncodingComboBox
            /// </summary>
            public const string EncodingComboBox = "encodings";
            
            /// <summary>
            /// Control ID for EncodingStaticControl
            /// </summary>
            public const string EncodingStaticControl = "encodingLabel";
            
            /// <summary>
            /// Control ID for EmailMessageTextBox
            /// </summary>
            public const string EmailMessageTextBox = "message";
            
            /// <summary>
            /// Control ID for EmailMessageStaticControl
            /// </summary>
            public const string EmailMessageStaticControl = "messageLabel";
            
            /// <summary>
            /// Control ID for EmailSubjectTextBox
            /// </summary>
            public const string EmailSubjectTextBox = "subject";
            
            /// <summary>
            /// Control ID for EmailSubjectStaticControl
            /// </summary>
            public const string EmailSubjectStaticControl = "subjectLabel";
            
            /// <summary>
            /// Control ID for DefaultEmailNotificationFormatStaticControl
            /// </summary>
            public const string DefaultEmailNotificationFormatStaticControl = "formatLabel";
            
            /// <summary>
            /// Control ID for MinutesStaticControl
            /// </summary>
            public const string MinutesStaticControl = "minutesLabel";
            
            /// <summary>
            /// Control ID for RetryPrimaryAfterComboBox
            /// </summary>
            public const string RetryPrimaryAfterComboBox = "retryMinutes";
            
            /// <summary>
            /// Control ID for RetryPrimaryAfterStaticControl
            /// </summary>
            public const string RetryPrimaryAfterStaticControl = "retryLabel";
            
            /// <summary>
            /// Control ID for ReturnAddressTextBox
            /// </summary>
            public const string ReturnAddressTextBox = "returnAddress";
            
            /// <summary>
            /// Control ID for ReturnAddressStaticControl
            /// </summary>
            public const string ReturnAddressStaticControl = "returnAddressLabel";
            
            /// <summary>
            /// Control ID for ServersListView
            /// </summary>
            public const string ServersListView = "servers";
            
            /// <summary>
            /// Control ID for SMTPServersStaticControl
            /// </summary>
            public const string SMTPServersStaticControl = "serversLabel";
            
            /// <summary>
            /// Control ID for EnableEmailNotificationCheckBox
            /// </summary>
            public const string EnableEmailNotificationCheckBox = "enabled";

            /// <summary>
            /// Control ID for panel4
            /// </summary>
            public const string SmtpServersPanel = "panel4";
        }
        #endregion
    }
}
