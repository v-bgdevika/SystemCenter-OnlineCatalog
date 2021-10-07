// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ShortMessageServiceNotificationDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor] 4/5/2006 Created
//  [KellyMor]  18-Apr-06   Fixed issue with Init method finding dialog window
//  [KellyMor]  07-Jun-06   Updated resource assembly for new Admin assembly
//  [KellyMor]  12-Jun-06   Fixed issue with dialog title prefix changing from MOM to SCE
//  [KellyMor]  26-Jun-06   Increase number of retries from 5 to 10 in Init method
//  [KellyMor]  19-Feb-08   Modified controls interface names to more appropriate names
//                          Fixed StyleCop violations
//  [KellyMor]  21-Feb-08   Added resource string for the "Default" encoding option.  This
//                          is the only one of the notification dialogs that uses one.
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IShortMessageServiceNotificationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IShortMessageServiceNotificationDialogControls, for ShortMessageServiceNotificationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IShortMessageServiceNotificationDialogControls
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
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
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
        /// Read-only property to access EncodingEditComboBox
        /// </summary>
        EditComboBox EncodingEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EncodingTextBox
        /// </summary>
        TextBox EncodingTextBox
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
        /// Read-only property to access MessageTextBox
        /// </summary>
        TextBox MessageTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SMSMessageStaticControl
        /// </summary>
        StaticControl SMSMessageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DefaultShortMessageServiceNotificationFormatStaticControl
        /// </summary>
        StaticControl DefaultShortMessageServiceNotificationFormatStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnableShortMessageServiceNotificationsCheckBox
        /// </summary>
        CheckBox EnableShortMessageServiceNotificationsCheckBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the SMS Notification tab of the Notifiations dialog
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ShortMessageServiceNotificationDialog : Dialog, IShortMessageServiceNotificationDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
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
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;
        
        /// <summary>
        /// Cache to hold a reference to PlaceholderButton of type Button
        /// </summary>
        private Button cachedPlaceholderButton;
        
        /// <summary>
        /// Cache to hold a reference to EncodingEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedEncodingEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to EncodingTextBox of type TextBox
        /// </summary>
        private TextBox cachedEncodingTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EncodingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEncodingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MessageTextBox of type TextBox
        /// </summary>
        private TextBox cachedMessageTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SMSMessageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSMSMessageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DefaultShortMessageServiceNotificationFormatStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefaultShortMessageServiceNotificationFormatStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnableShortMessageServiceNotificationsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnableShortMessageServiceNotificationsCheckBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ShortMessageServiceNotificationDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ShortMessageServiceNotificationDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IShortMessageServiceNotificationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IShortMessageServiceNotificationDialogControls Controls
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
        ///  Property to handle checkbox EnableShortMessageServiceNotifications
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool EnableShortMessageServiceNotifications
        {
            get
            {
                return this.Controls.EnableShortMessageServiceNotificationsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.EnableShortMessageServiceNotificationsCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Minutes
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EncodingComboBoxText
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Minutes2
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
                return this.Controls.EncodingTextBox.Text;
            }
            
            set
            {
                this.Controls.EncodingTextBox.Text = value;
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
        public virtual string MessageText
        {
            get
            {
                return this.Controls.MessageTextBox.Text;
            }
            
            set
            {
                this.Controls.MessageTextBox.Text = value;
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
        Button IShortMessageServiceNotificationDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, ShortMessageServiceNotificationDialog.ControlIDs.ApplyButton);
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
        Button IShortMessageServiceNotificationDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ShortMessageServiceNotificationDialog.ControlIDs.CancelButton);
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
        Button IShortMessageServiceNotificationDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ShortMessageServiceNotificationDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IShortMessageServiceNotificationDialogControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, ShortMessageServiceNotificationDialog.ControlIDs.Tab2TabControl);
                }

                return this.cachedTab2TabControl;
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
        Button IShortMessageServiceNotificationDialogControls.PlaceholderButton
        {
            get
            {
                if ((this.cachedPlaceholderButton == null))
                {
                    this.cachedPlaceholderButton = new Button(this, ShortMessageServiceNotificationDialog.ControlIDs.PlaceholderButton);
                }

                return this.cachedPlaceholderButton;
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
        EditComboBox IShortMessageServiceNotificationDialogControls.EncodingEditComboBox
        {
            get
            {
                if ((this.cachedEncodingEditComboBox == null))
                {
                    this.cachedEncodingEditComboBox = new EditComboBox(this, ShortMessageServiceNotificationDialog.ControlIDs.EncodingEditComboBox);
                }

                return this.cachedEncodingEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EncodingTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IShortMessageServiceNotificationDialogControls.EncodingTextBox
        {
            get
            {
                if ((this.cachedEncodingTextBox == null))
                {
                    Window wndTemp = this.AccessibleObject.Window;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedEncodingTextBox = new TextBox(wndTemp);
                }

                return this.cachedEncodingTextBox;
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
        StaticControl IShortMessageServiceNotificationDialogControls.EncodingStaticControl
        {
            get
            {
                if ((this.cachedEncodingStaticControl == null))
                {
                    this.cachedEncodingStaticControl = new StaticControl(this, ShortMessageServiceNotificationDialog.ControlIDs.EncodingStaticControl);
                }

                return this.cachedEncodingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MessageTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IShortMessageServiceNotificationDialogControls.MessageTextBox
        {
            get
            {
                if ((this.cachedMessageTextBox == null))
                {
                    this.cachedMessageTextBox = new TextBox(this, ShortMessageServiceNotificationDialog.ControlIDs.MessageTextBox);
                }

                return this.cachedMessageTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SMSMessageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IShortMessageServiceNotificationDialogControls.SMSMessageStaticControl
        {
            get
            {
                if ((this.cachedSMSMessageStaticControl == null))
                {
                    this.cachedSMSMessageStaticControl = new StaticControl(this, ShortMessageServiceNotificationDialog.ControlIDs.SMSMessageStaticControl);
                }

                return this.cachedSMSMessageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultShortMessageServiceNotificationFormatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IShortMessageServiceNotificationDialogControls.DefaultShortMessageServiceNotificationFormatStaticControl
        {
            get
            {
                if ((this.cachedDefaultShortMessageServiceNotificationFormatStaticControl == null))
                {
                    this.cachedDefaultShortMessageServiceNotificationFormatStaticControl = new StaticControl(this, ShortMessageServiceNotificationDialog.ControlIDs.DefaultShortMessageServiceNotificationFormatStaticControl);
                }

                return this.cachedDefaultShortMessageServiceNotificationFormatStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnableShortMessageServiceNotificationsCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IShortMessageServiceNotificationDialogControls.EnableShortMessageServiceNotificationsCheckBox
        {
            get
            {
                if ((this.cachedEnableShortMessageServiceNotificationsCheckBox == null))
                {
                    this.cachedEnableShortMessageServiceNotificationsCheckBox = new CheckBox(this, ShortMessageServiceNotificationDialog.ControlIDs.EnableShortMessageServiceNotificationsCheckBox);
                }

                return this.cachedEnableShortMessageServiceNotificationsCheckBox;
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
        ///  Routine to click on button EnableShortMessageServiceNotifications
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEnableShortMessageServiceNotifications()
        {
            this.Controls.EnableShortMessageServiceNotificationsCheckBox.Click();
        }
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
                    app,
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
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);
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
            /// Contains resource string for the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogMomTitlePrefix =
                ";Global Management Group Settings -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix on SCE
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogSceTitlePrefix =
                ";Global Management Settings -" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.SCE.UI.Console.exe" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.AdministrationSpace.AdminResources" +
                ";GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitleSuffix =
                ";Notification" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SettingsResources" +
                ";GroupNotification";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply =
                ";&Apply" +
                ";ManagedString" +
                ";DundasWinChart.dll" +
                ";DC01.bQ" +
                ";buttonApply.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm" +
                ";buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK =
                ";OK" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm" +
                ";buttonOK.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SmsTab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSmsTab =
                ";Short Message Service" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SmsNotification" +
                ";$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Placeholder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlaceholder =
                ";P&laceholder" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNotification" +
                ";messagePlaceholder.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEncoding =
                ";Encoding:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";encodingLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SMSMessage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSMSMessage =
                ";SMS &message:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SmsNotification" +
                ";messageLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultShortMessageServiceNotificationFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultShortMessageServiceNotificationFormat =
                ";Default short message service notification format:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SmsNotification" +
                ";defaultLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnableShortMessageServiceNotifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnableShortMessageServiceNotifications =
                ";Ena&ble short message service notifications" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SmsNotification" +
                ";enabled.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultEncoding = 
                ";Default" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource" +
                ";SmsEncodingDefault";

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
            /// Caches the translated resource string for:  SmsTab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSmsTab;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Placeholder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlaceholder;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEncoding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SMSMessage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSMSMessage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefaultShortMessageServiceNotificationFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultShortMessageServiceNotificationFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnableShortMessageServiceNotifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnableShortMessageServiceNotifications;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefaultEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultEncoding;
  
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
            /// Exposes access to the SmsTab translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SmsTab
            {
                get
                {
                    if ((cachedSmsTab == null))
                    {
                        cachedSmsTab = CoreManager.MomConsole.GetIntlStr(ResourceSmsTab);
                    }

                    return cachedSmsTab;
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
            /// Exposes access to the SMSMessage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SMSMessage
            {
                get
                {
                    if ((cachedSMSMessage == null))
                    {
                        cachedSMSMessage = CoreManager.MomConsole.GetIntlStr(ResourceSMSMessage);
                    }

                    return cachedSMSMessage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultShortMessageServiceNotificationFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultShortMessageServiceNotificationFormat
            {
                get
                {
                    if ((cachedDefaultShortMessageServiceNotificationFormat == null))
                    {
                        cachedDefaultShortMessageServiceNotificationFormat = CoreManager.MomConsole.GetIntlStr(ResourceDefaultShortMessageServiceNotificationFormat);
                    }

                    return cachedDefaultShortMessageServiceNotificationFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnableShortMessageServiceNotifications translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnableShortMessageServiceNotifications
            {
                get
                {
                    if ((cachedEnableShortMessageServiceNotifications == null))
                    {
                        cachedEnableShortMessageServiceNotifications = CoreManager.MomConsole.GetIntlStr(ResourceEnableShortMessageServiceNotifications);
                    }

                    return cachedEnableShortMessageServiceNotifications;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultEncoding translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultEncoding
            {
                get
                {
                    if ((cachedDefaultEncoding == null))
                    {
                        cachedDefaultEncoding = CoreManager.MomConsole.GetIntlStr(ResourceDefaultEncoding);
                    }

                    return cachedDefaultEncoding;
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
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for PlaceholderButton
            /// </summary>
            public const string PlaceholderButton = "messagePlaceholder";
            
            /// <summary>
            /// Control ID for EncodingEditComboBox
            /// </summary>
            public const string EncodingEditComboBox = "encodings";
            
            /// <summary>
            /// Control ID for EncodingStaticControl
            /// </summary>
            public const string EncodingStaticControl = "encodingLabel";
            
            /// <summary>
            /// Control ID for MessageTextBox
            /// </summary>
            public const string MessageTextBox = "messageBox";
            
            /// <summary>
            /// Control ID for SMSMessageStaticControl
            /// </summary>
            public const string SMSMessageStaticControl = "messageLabel";
            
            /// <summary>
            /// Control ID for DefaultShortMessageServiceNotificationFormatStaticControl
            /// </summary>
            public const string DefaultShortMessageServiceNotificationFormatStaticControl = "defaultLabel";
            
            /// <summary>
            /// Control ID for EnableShortMessageServiceNotificationsCheckBox
            /// </summary>
            public const string EnableShortMessageServiceNotificationsCheckBox = "enabled";
        }
        #endregion
    }
}
