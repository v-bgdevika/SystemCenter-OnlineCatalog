// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="InstantMessageNotificationDialog.cs">
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
//  [KellyMor]  12-Feb-08   Renamed some control interfaces, methods and properties
//                          Added strings for combobox elements:  Protocol Options, and
//                          Authentication Methods.
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IInstantMessageNotificationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IInstantMessageNotificationDialogControls, for InstantMessageNotificationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IInstantMessageNotificationDialogControls
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
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AuthenticationMethodEditComboBox
        /// </summary>
        EditComboBox AuthenticationMethodEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AuthenticationMethodTextBox
        /// </summary>
        TextBox AuthenticationMethodTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AuthenticationMethodStaticControl
        /// </summary>
        StaticControl AuthenticationMethodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProtocolOptionsComboBox
        /// </summary>
        EditComboBox ProtocolOptionsComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ProtocolOptionStaticControl
        /// </summary>
        StaticControl ProtocolOptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProtocolOptionTextBox
        /// </summary>
        TextBox PortTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IMPortStaticControl
        /// </summary>
        StaticControl IMPortStaticControl
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
        /// Read-only property to access ReturnAdressStaticControl
        /// </summary>
        StaticControl ReturnAdressStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IMServerTextBox
        /// </summary>
        TextBox IMServerTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IMServerStaticControl
        /// </summary>
        StaticControl IMServerStaticControl
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
        /// Read-only property to access IMMessageStaticControl
        /// </summary>
        StaticControl IMMessageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DefaultInstantMessagingNotificationFormatStaticControl
        /// </summary>
        StaticControl DefaultInstantMessagingNotificationFormatStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnableInstantMessagingNotificationsCheckBox
        /// </summary>
        CheckBox EnableInstantMessagingNotificationsCheckBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the IM Notification tab of the Notifiations dialog
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class InstantMessageNotificationDialog : Dialog, IInstantMessageNotificationDialogControls
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
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationMethodEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedAuthenticationMethodEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationMethodTextBox of type TextBox
        /// </summary>
        private TextBox cachedAuthenticationMethodTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAuthenticationMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProtocolOptionsComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedProtocolOptionsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ProtocolOptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProtocolOptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProtocolOptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedPortTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IMPortStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIMPortStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ReturnAddressTextBox of type TextBox
        /// </summary>
        private TextBox cachedReturnAddressTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ReturnAdressStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedReturnAdressStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IMServerTextBox of type TextBox
        /// </summary>
        private TextBox cachedIMServerTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IMServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIMServerStaticControl;
        
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
        private TextBox cachedEmailMessageTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EncodingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEncodingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MessageTextBox of type TextBox
        /// </summary>
        private TextBox cachedMessageTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IMMessageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIMMessageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DefaultInstantMessagingNotificationFormatStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefaultInstantMessagingNotificationFormatStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnableInstantMessagingNotificationsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnableInstantMessagingNotificationsCheckBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of InstantMessageNotificationDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public InstantMessageNotificationDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IInstantMessageNotificationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IInstantMessageNotificationDialogControls Controls
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
        ///  Property to handle checkbox EnableInstantMessagingNotifications
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool EnableInstantMessagingNotifications
        {
            get
            {
                return this.Controls.EnableInstantMessagingNotificationsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.EnableInstantMessagingNotificationsCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AuthenticationMethod
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AuthenticationMethodText
        {
            get
            {
                return this.Controls.AuthenticationMethodEditComboBox.Text;
            }
            
            set
            {
                this.Controls.AuthenticationMethodEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AuthenticationMethod2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AuthenticationMethodTextBoxText
        {
            get
            {
                return this.Controls.AuthenticationMethodTextBox.Text;
            }
            
            set
            {
                this.Controls.AuthenticationMethodTextBox.Text = value;
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
        public virtual string ProtocolOptionsText
        {
            get
            {
                return this.Controls.ProtocolOptionsComboBox.Text;
            }
            
            set
            {
                this.Controls.ProtocolOptionsComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ProtocolOptionTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PortTextBoxText
        {
            get
            {
                return this.Controls.PortTextBox.Text;
            }
            
            set
            {
                this.Controls.PortTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ReturnAdress
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SMTPServers
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IMServerText
        {
            get
            {
                return this.Controls.IMServerTextBox.Text;
            }
            
            set
            {
                this.Controls.IMServerTextBox.Text = value;
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EmailMessage2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EncodingTextBoxText
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
        ///  Routine to set/get the text in control EmailSubject
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
        Button IInstantMessageNotificationDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, InstantMessageNotificationDialog.ControlIDs.ApplyButton);
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
        Button IInstantMessageNotificationDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, InstantMessageNotificationDialog.ControlIDs.CancelButton);
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
        Button IInstantMessageNotificationDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, InstantMessageNotificationDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IInstantMessageNotificationDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, InstantMessageNotificationDialog.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationMethodEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IInstantMessageNotificationDialogControls.AuthenticationMethodEditComboBox
        {
            get
            {
                if ((this.cachedAuthenticationMethodEditComboBox == null))
                {
                    this.cachedAuthenticationMethodEditComboBox = new EditComboBox(this, InstantMessageNotificationDialog.ControlIDs.AuthenticationMethodEditComboBox);
                }
                return this.cachedAuthenticationMethodEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationMethodTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IInstantMessageNotificationDialogControls.AuthenticationMethodTextBox
        {
            get
            {
                if ((this.cachedAuthenticationMethodTextBox == null))
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedAuthenticationMethodTextBox = new TextBox(wndTemp);
                }
                return this.cachedAuthenticationMethodTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageNotificationDialogControls.AuthenticationMethodStaticControl
        {
            get
            {
                if ((this.cachedAuthenticationMethodStaticControl == null))
                {
                    this.cachedAuthenticationMethodStaticControl = new StaticControl(this, InstantMessageNotificationDialog.ControlIDs.AuthenticationMethodStaticControl);
                }
                return this.cachedAuthenticationMethodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProtocolOptionsComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IInstantMessageNotificationDialogControls.ProtocolOptionsComboBox
        {
            get
            {
                if ((this.cachedProtocolOptionsComboBox == null))
                {
                    this.cachedProtocolOptionsComboBox = new EditComboBox(this, InstantMessageNotificationDialog.ControlIDs.ProtocolOptionsComboBox);
                }
                return this.cachedProtocolOptionsComboBox;
            }
        }
         
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProtocolOptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageNotificationDialogControls.ProtocolOptionStaticControl
        {
            get
            {
                if ((this.cachedProtocolOptionStaticControl == null))
                {
                    this.cachedProtocolOptionStaticControl = new StaticControl(this, InstantMessageNotificationDialog.ControlIDs.ProtocolOptionStaticControl);
                }
                return this.cachedProtocolOptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProtocolOptionTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IInstantMessageNotificationDialogControls.PortTextBox
        {
            get
            {
                if ((this.cachedPortTextBox == null))
                {
                    this.cachedPortTextBox = new TextBox(this, InstantMessageNotificationDialog.ControlIDs.PortTextBox);
                }
                return this.cachedPortTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IMPortStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageNotificationDialogControls.IMPortStaticControl
        {
            get
            {
                if ((this.cachedIMPortStaticControl == null))
                {
                    this.cachedIMPortStaticControl = new StaticControl(this, InstantMessageNotificationDialog.ControlIDs.IMPortStaticControl);
                }
                return this.cachedIMPortStaticControl;
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
        TextBox IInstantMessageNotificationDialogControls.ReturnAddressTextBox
        {
            get
            {
                if ((this.cachedReturnAddressTextBox == null))
                {
                    this.cachedReturnAddressTextBox = new TextBox(this, InstantMessageNotificationDialog.ControlIDs.ReturnAddressTextBox);
                }
                return this.cachedReturnAddressTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReturnAdressStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageNotificationDialogControls.ReturnAdressStaticControl
        {
            get
            {
                if ((this.cachedReturnAdressStaticControl == null))
                {
                    this.cachedReturnAdressStaticControl = new StaticControl(this, InstantMessageNotificationDialog.ControlIDs.ReturnAdressStaticControl);
                }
                return this.cachedReturnAdressStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IMServerTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IInstantMessageNotificationDialogControls.IMServerTextBox
        {
            get
            {
                if ((this.cachedIMServerTextBox == null))
                {
                    this.cachedIMServerTextBox = new TextBox(this, InstantMessageNotificationDialog.ControlIDs.IMServerTextBox);
                }
                return this.cachedIMServerTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IMServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageNotificationDialogControls.IMServerStaticControl
        {
            get
            {
                if ((this.cachedIMServerStaticControl == null))
                {
                    this.cachedIMServerStaticControl = new StaticControl(this, InstantMessageNotificationDialog.ControlIDs.IMServerStaticControl);
                }
                return this.cachedIMServerStaticControl;
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
        Button IInstantMessageNotificationDialogControls.PlaceholderButton
        {
            get
            {
                if ((this.cachedPlaceholderButton == null))
                {
                    this.cachedPlaceholderButton = new Button(this, InstantMessageNotificationDialog.ControlIDs.PlaceholderButton);
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
        EditComboBox IInstantMessageNotificationDialogControls.EncodingEditComboBox
        {
            get
            {
                if ((this.cachedEncodingEditComboBox == null))
                {
                    this.cachedEncodingEditComboBox = new EditComboBox(this, InstantMessageNotificationDialog.ControlIDs.EncodingEditComboBox);
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
        TextBox IInstantMessageNotificationDialogControls.EncodingTextBox
        {
            get
            {
                if ((this.cachedEmailMessageTextBox == null))
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 10); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedEmailMessageTextBox = new TextBox(wndTemp);
                }
                return this.cachedEmailMessageTextBox;
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
        StaticControl IInstantMessageNotificationDialogControls.EncodingStaticControl
        {
            get
            {
                if ((this.cachedEncodingStaticControl == null))
                {
                    this.cachedEncodingStaticControl = new StaticControl(this, InstantMessageNotificationDialog.ControlIDs.EncodingStaticControl);
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
        TextBox IInstantMessageNotificationDialogControls.MessageTextBox
        {
            get
            {
                if ((this.cachedMessageTextBox == null))
                {
                    this.cachedMessageTextBox = new TextBox(this, InstantMessageNotificationDialog.ControlIDs.MessageTextBox);
                }
                return this.cachedMessageTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IMMessageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageNotificationDialogControls.IMMessageStaticControl
        {
            get
            {
                if ((this.cachedIMMessageStaticControl == null))
                {
                    this.cachedIMMessageStaticControl = new StaticControl(this, InstantMessageNotificationDialog.ControlIDs.IMMessageStaticControl);
                }
                return this.cachedIMMessageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultInstantMessagingNotificationFormatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageNotificationDialogControls.DefaultInstantMessagingNotificationFormatStaticControl
        {
            get
            {
                if ((this.cachedDefaultInstantMessagingNotificationFormatStaticControl == null))
                {
                    this.cachedDefaultInstantMessagingNotificationFormatStaticControl = new StaticControl(this, InstantMessageNotificationDialog.ControlIDs.DefaultInstantMessagingNotificationFormatStaticControl);
                }
                return this.cachedDefaultInstantMessagingNotificationFormatStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnableInstantMessagingNotificationsCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IInstantMessageNotificationDialogControls.EnableInstantMessagingNotificationsCheckBox
        {
            get
            {
                if ((this.cachedEnableInstantMessagingNotificationsCheckBox == null))
                {
                    this.cachedEnableInstantMessagingNotificationsCheckBox = new CheckBox(this, InstantMessageNotificationDialog.ControlIDs.EnableInstantMessagingNotificationsCheckBox);
                }
                return this.cachedEnableInstantMessagingNotificationsCheckBox;
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
        ///  Routine to click on button EnableInstantMessagingNotifications
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEnableInstantMessagingNotifications()
        {
            this.Controls.EnableInstantMessagingNotificationsCheckBox.Click();
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
                    Common.Utilities.LogMessage(
                        "Failed to find the Instant Messaging notification dialog window!");

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
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceInstantMessageTab = 
                ";Instant Messaging" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthenticationMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthenticationMethod =
                ";A&uthentication method:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";authenticationLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProtocolOption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProtocolOption =
                ";Pr&otocol option:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";protocolLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IMPort
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIMPort =
                ";&IM port:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";portLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ReturnAdress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceReturnAdress =
                ";&Return adress:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";returnAddressLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IMServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIMServer =
                ";IM &server:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";serverLabel.Text";
            
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
            /// Contains resource string for:  IMMessage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIMMessage =
                ";I&M message:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";messageLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultInstantMessagingNotificationFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultInstantMessagingNotificationFormat =
                ";Default instant messaging notification format:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";defaultLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnableInstantMessagingNotifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnableInstantMessagingNotifications =
                ";Ena&ble instant messaging notifications" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification" +
                ";enabled.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthenticationNtlm
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthenticationNtlm = 
                ";NTLM" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource" +
                ";NtlmProtocol";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthenticationKerberos
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthenticationKerberos =
                ";Kerberos" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource" +
                ";KerberosProtocol";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProtocolTcp
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProtocolTcp =
                ";TCP" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource" +
                ";TcpProtocol";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProtocolTls
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProtocolTls =
                ";TLS" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource" +
                ";TlsProtocol";

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
            /// Caches the translated resource string for:  cachedInstantMessageTab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInstantMessageTab;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthenticationMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthenticationMethod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProtocolOption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProtocolOption;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IMPort
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIMPort;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ReturnAdress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReturnAdress;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IMServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIMServer;
            
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
            /// Caches the translated resource string for:  IMMessage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIMMessage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefaultInstantMessagingNotificationFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultInstantMessagingNotificationFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnableInstantMessagingNotifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnableInstantMessagingNotifications;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthenticationNtlm
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthenticationNtlm;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthenticationKerberos
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthenticationKerberos;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProtocolTcp
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProtocolTcp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProtocolTls
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProtocolTls;

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
            /// Exposes access to the InstantMessageTab translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InstantMessageTab
            {
                get
                {
                    if ((cachedInstantMessageTab == null))
                    {
                        cachedInstantMessageTab = CoreManager.MomConsole.GetIntlStr(ResourceInstantMessageTab);
                    }
                    return cachedInstantMessageTab;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthenticationMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthenticationMethod
            {
                get
                {
                    if ((cachedAuthenticationMethod == null))
                    {
                        cachedAuthenticationMethod = CoreManager.MomConsole.GetIntlStr(ResourceAuthenticationMethod);
                    }
                    return cachedAuthenticationMethod;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProtocolOption translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProtocolOption
            {
                get
                {
                    if ((cachedProtocolOption == null))
                    {
                        cachedProtocolOption = CoreManager.MomConsole.GetIntlStr(ResourceProtocolOption);
                    }
                    return cachedProtocolOption;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IMPort translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IMPort
            {
                get
                {
                    if ((cachedIMPort == null))
                    {
                        cachedIMPort = CoreManager.MomConsole.GetIntlStr(ResourceIMPort);
                    }
                    return cachedIMPort;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ReturnAdress translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReturnAdress
            {
                get
                {
                    if ((cachedReturnAdress == null))
                    {
                        cachedReturnAdress = CoreManager.MomConsole.GetIntlStr(ResourceReturnAdress);
                    }
                    return cachedReturnAdress;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IMServer translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IMServer
            {
                get
                {
                    if ((cachedIMServer == null))
                    {
                        cachedIMServer = CoreManager.MomConsole.GetIntlStr(ResourceIMServer);
                    }
                    return cachedIMServer;
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
            /// Exposes access to the IMMessage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IMMessage
            {
                get
                {
                    if ((cachedIMMessage == null))
                    {
                        cachedIMMessage = CoreManager.MomConsole.GetIntlStr(ResourceIMMessage);
                    }
                    return cachedIMMessage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultInstantMessagingNotificationFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultInstantMessagingNotificationFormat
            {
                get
                {
                    if ((cachedDefaultInstantMessagingNotificationFormat == null))
                    {
                        cachedDefaultInstantMessagingNotificationFormat = CoreManager.MomConsole.GetIntlStr(ResourceDefaultInstantMessagingNotificationFormat);
                    }
                    return cachedDefaultInstantMessagingNotificationFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnableInstantMessagingNotifications translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnableInstantMessagingNotifications
            {
                get
                {
                    if ((cachedEnableInstantMessagingNotifications == null))
                    {
                        cachedEnableInstantMessagingNotifications = CoreManager.MomConsole.GetIntlStr(ResourceEnableInstantMessagingNotifications);
                    }
                    return cachedEnableInstantMessagingNotifications;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthenticationNtlm translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthenticationNtlm
            {
                get
                {
                    if ((cachedAuthenticationNtlm == null))
                    {
                        cachedAuthenticationNtlm = CoreManager.MomConsole.GetIntlStr(ResourceAuthenticationNtlm);
                    }
                    return cachedAuthenticationNtlm;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthenticationKerberos translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthenticationKerberos
            {
                get
                {
                    if ((cachedAuthenticationKerberos == null))
                    {
                        cachedAuthenticationKerberos = CoreManager.MomConsole.GetIntlStr(ResourceAuthenticationKerberos);
                    }
                    return cachedAuthenticationKerberos;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProtocolTcp translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProtocolTcp
            {
                get
                {
                    if ((cachedProtocolTcp == null))
                    {
                        cachedProtocolTcp = CoreManager.MomConsole.GetIntlStr(ResourceProtocolTcp);
                    }
                    return cachedProtocolTcp;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProtocolTls translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProtocolTls
            {
                get
                {
                    if ((cachedProtocolTls == null))
                    {
                        cachedProtocolTls = CoreManager.MomConsole.GetIntlStr(ResourceProtocolTls);
                    }
                    return cachedProtocolTls;
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for AuthenticationMethodEditComboBox
            /// </summary>
            public const string AuthenticationMethodEditComboBox = "authenticationBox";
            
            /// <summary>
            /// Control ID for AuthenticationMethodStaticControl
            /// </summary>
            public const string AuthenticationMethodStaticControl = "authenticationLabel";
            
            /// <summary>
            /// Control ID for ProtocolOptionsComboBox
            /// </summary>
            public const string ProtocolOptionsComboBox = "protocolList";
            
            /// <summary>
            /// Control ID for ProtocolOptionStaticControl
            /// </summary>
            public const string ProtocolOptionStaticControl = "protocolLabel";
            
            /// <summary>
            /// Control ID for ProtocolOptionTextBox
            /// </summary>
            public const string PortTextBox = "portBox";
            
            /// <summary>
            /// Control ID for IMPortStaticControl
            /// </summary>
            public const string IMPortStaticControl = "portLabel";
            
            /// <summary>
            /// Control ID for ReturnAddressTextBox
            /// </summary>
            public const string ReturnAddressTextBox = "returnAddressBox";
            
            /// <summary>
            /// Control ID for ReturnAdressStaticControl
            /// </summary>
            public const string ReturnAdressStaticControl = "returnAddressLabel";
            
            /// <summary>
            /// Control ID for IMServerTextBox
            /// </summary>
            public const string IMServerTextBox = "serverBox";
            
            /// <summary>
            /// Control ID for IMServerStaticControl
            /// </summary>
            public const string IMServerStaticControl = "serverLabel";
            
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
            /// Control ID for IMMessageStaticControl
            /// </summary>
            public const string IMMessageStaticControl = "messageLabel";
            
            /// <summary>
            /// Control ID for DefaultInstantMessagingNotificationFormatStaticControl
            /// </summary>
            public const string DefaultInstantMessagingNotificationFormatStaticControl = "defaultLabel";
            
            /// <summary>
            /// Control ID for EnableInstantMessagingNotificationsCheckBox
            /// </summary>
            public const string EnableInstantMessagingNotificationsCheckBox = "enabled";
        }
        #endregion
    }
}
