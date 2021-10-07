// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="NotificationRecipientPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor]  06-Apr-06   Created
//  [KellyMor]  19-Apr-06   Updated Init method
//  [KellyMor]  20-Apr-06   Added click method for tab control
//  [KellyMor]  07-Jun-06   Updated resource assembly for new Admin assembly
//  [KellyMor]  08-Jun-06   Updated resource assembly namespace
//  [KellyMor]  18-Jan-07   Modified constructors to reduce window search time
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Notifications.Recipients
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - Tab0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Tab0
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Tab0
    {
        /// <summary>
        /// OnlySendNotificationDuringTheSpecifiedTimes = 0
        /// </summary>
        OnlySendNotificationDuringTheSpecifiedTimes = 0,
        
        /// <summary>
        /// AlwaysSendNotifications = 1
        /// </summary>
        AlwaysSendNotifications = 1,
    }
    #endregion
    
    #region Interface Definition - INotificationRecipientPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, INotificationRecipientPropertiesDialogControls, for NotificationRecipientPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface INotificationRecipientPropertiesDialogControls
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
        /// Read-only property to access OnlySendNotificationDuringTheSpecifiedTimesRadioButton
        /// </summary>
        RadioButton OnlySendNotificationDuringTheSpecifiedTimesRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlwaysSendNotificationsRadioButton
        /// </summary>
        RadioButton AlwaysSendNotificationsRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis0Button
        /// </summary>
        Button Ellipsis0Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IncludeToolStrip
        /// </summary>
        Toolbar IncludeToolStrip
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludeSchedulesListView
        /// </summary>
        ListView ExcludeSchedulesListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludeSchedulesStaticControl
        /// </summary>
        StaticControl ExcludeSchedulesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludeToolStrip
        /// </summary>
        Toolbar ExcludeToolStrip
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SchedulesToSendListView
        /// </summary>
        ListView SchedulesToSendListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SchedulesToSendStaticControl
        /// </summary>
        StaticControl SchedulesToSendStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotificationRecipientDisplayNameTextBox
        /// </summary>
        TextBox NotificationRecipientDisplayNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotificationRecipientDisplayNameStaticControl
        /// </summary>
        StaticControl NotificationRecipientDisplayNameStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Notification Recipient properties dialog
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class NotificationRecipientPropertiesDialog : Dialog, INotificationRecipientPropertiesDialogControls
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
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to OnlySendNotificationDuringTheSpecifiedTimesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedOnlySendNotificationDuringTheSpecifiedTimesRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AlwaysSendNotificationsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAlwaysSendNotificationsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis0Button of type Button
        /// </summary>
        private Button cachedEllipsis0Button;
        
        /// <summary>
        /// Cache to hold a reference to IncludeToolStrip of type Toolbar
        /// </summary>
        private Toolbar cachedIncludeToolStrip;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeSchedulesListView of type ListView
        /// </summary>
        private ListView cachedExcludeSchedulesListView;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeSchedulesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludeSchedulesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeToolStrip of type Toolbar
        /// </summary>
        private Toolbar cachedExcludeToolStrip;
        
        /// <summary>
        /// Cache to hold a reference to SchedulesToSendListView of type ListView
        /// </summary>
        private ListView cachedSchedulesToSendListView;
        
        /// <summary>
        /// Cache to hold a reference to SchedulesToSendStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSchedulesToSendStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NotificationRecipientDisplayNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNotificationRecipientDisplayNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NotificationRecipientDisplayNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotificationRecipientDisplayNameStaticControl;

        /// <summary>
        /// Cached reference to a tab on a tab control
        /// </summary>
        private TabControlTab cachedGeneralTab;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of NotificationRecipientPropertiesDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public NotificationRecipientPropertiesDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Tab0
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Tab0 Tab0
        {
            get
            {
                if ((this.Controls.OnlySendNotificationDuringTheSpecifiedTimesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab0.OnlySendNotificationDuringTheSpecifiedTimes;
                }
                
                if ((this.Controls.AlwaysSendNotificationsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab0.AlwaysSendNotifications;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == Tab0.OnlySendNotificationDuringTheSpecifiedTimes))
                {
                    this.Controls.OnlySendNotificationDuringTheSpecifiedTimesRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Tab0.AlwaysSendNotifications))
                    {
                        this.Controls.AlwaysSendNotificationsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region INotificationRecipientPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual INotificationRecipientPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control NotificationRecipientDisplayName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NotificationRecipientDisplayNameText
        {
            get
            {
                return this.Controls.NotificationRecipientDisplayNameTextBox.Text;
            }
            
            set
            {
                this.Controls.NotificationRecipientDisplayNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button INotificationRecipientPropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, NotificationRecipientPropertiesDialog.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button INotificationRecipientPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, NotificationRecipientPropertiesDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button INotificationRecipientPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, NotificationRecipientPropertiesDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl INotificationRecipientPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, NotificationRecipientPropertiesDialog.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OnlySendNotificationDuringTheSpecifiedTimesRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton INotificationRecipientPropertiesDialogControls.OnlySendNotificationDuringTheSpecifiedTimesRadioButton
        {
            get
            {
                if ((this.cachedOnlySendNotificationDuringTheSpecifiedTimesRadioButton == null))
                {
                    this.cachedOnlySendNotificationDuringTheSpecifiedTimesRadioButton = new RadioButton(this, NotificationRecipientPropertiesDialog.ControlIDs.OnlySendNotificationDuringTheSpecifiedTimesRadioButton);
                }
                return this.cachedOnlySendNotificationDuringTheSpecifiedTimesRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlwaysSendNotificationsRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton INotificationRecipientPropertiesDialogControls.AlwaysSendNotificationsRadioButton
        {
            get
            {
                if ((this.cachedAlwaysSendNotificationsRadioButton == null))
                {
                    this.cachedAlwaysSendNotificationsRadioButton = new RadioButton(this, NotificationRecipientPropertiesDialog.ControlIDs.AlwaysSendNotificationsRadioButton);
                }
                return this.cachedAlwaysSendNotificationsRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis0Button control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button INotificationRecipientPropertiesDialogControls.Ellipsis0Button
        {
            get
            {
                if ((this.cachedEllipsis0Button == null))
                {
                    this.cachedEllipsis0Button = new Button(this, NotificationRecipientPropertiesDialog.ControlIDs.Ellipsis0Button);
                }
                return this.cachedEllipsis0Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeToolStrip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar INotificationRecipientPropertiesDialogControls.IncludeToolStrip
        {
            get
            {
                if ((this.cachedIncludeToolStrip == null))
                {
                    this.cachedIncludeToolStrip = new Toolbar(this);
                }
                return this.cachedIncludeToolStrip;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeSchedulesListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView INotificationRecipientPropertiesDialogControls.ExcludeSchedulesListView
        {
            get
            {
                if ((this.cachedExcludeSchedulesListView == null))
                {
                    this.cachedExcludeSchedulesListView = new ListView(this, NotificationRecipientPropertiesDialog.ControlIDs.ExcludeSchedulesListView);
                }
                return this.cachedExcludeSchedulesListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeSchedulesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl INotificationRecipientPropertiesDialogControls.ExcludeSchedulesStaticControl
        {
            get
            {
                if ((this.cachedExcludeSchedulesStaticControl == null))
                {
                    this.cachedExcludeSchedulesStaticControl = new StaticControl(this, NotificationRecipientPropertiesDialog.ControlIDs.ExcludeSchedulesStaticControl);
                }
                return this.cachedExcludeSchedulesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeToolStrip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar INotificationRecipientPropertiesDialogControls.ExcludeToolStrip
        {
            get
            {
                // The ID for this control (toolStrip) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExcludeToolStrip == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedExcludeToolStrip = new Toolbar(wndTemp);
                }
                return this.cachedExcludeToolStrip;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SchedulesToSendListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView INotificationRecipientPropertiesDialogControls.SchedulesToSendListView
        {
            get
            {
                // The ID for this control (listView) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSchedulesToSendListView == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedSchedulesToSendListView = new ListView(wndTemp);
                }
                return this.cachedSchedulesToSendListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SchedulesToSendStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl INotificationRecipientPropertiesDialogControls.SchedulesToSendStaticControl
        {
            get
            {
                // The ID for this control (label) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSchedulesToSendStaticControl == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedSchedulesToSendStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSchedulesToSendStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotificationRecipientDisplayNameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox INotificationRecipientPropertiesDialogControls.NotificationRecipientDisplayNameTextBox
        {
            get
            {
                if ((this.cachedNotificationRecipientDisplayNameTextBox == null))
                {
                    this.cachedNotificationRecipientDisplayNameTextBox = new TextBox(this, NotificationRecipientPropertiesDialog.ControlIDs.NotificationRecipientDisplayNameTextBox);
                }
                return this.cachedNotificationRecipientDisplayNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotificationRecipientDisplayNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl INotificationRecipientPropertiesDialogControls.NotificationRecipientDisplayNameStaticControl
        {
            get
            {
                if ((this.cachedNotificationRecipientDisplayNameStaticControl == null))
                {
                    this.cachedNotificationRecipientDisplayNameStaticControl = new StaticControl(this, NotificationRecipientPropertiesDialog.ControlIDs.NotificationRecipientDisplayNameStaticControl);
                }
                return this.cachedNotificationRecipientDisplayNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis0
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis0()
        {
            this.Controls.Ellipsis0Button.Click();
        }

        /// <summary>
        /// Method to click on the "General" tab of the dialog
        /// </summary>
        public virtual void ClickGeneralTab()
        {
            if (null == this.cachedGeneralTab)
            {
                this.cachedGeneralTab = new TabControlTab(this.Controls.Tab0TabControl, Strings.Tab0);
            }
            this.cachedGeneralTab.Click();
        }

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
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
                const int MaxTries = 5;
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
                        Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage("Failed to find Recipient properties dialog!");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
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
            private const string ResourceDialogTitle = ";Notification Recipient Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource;RecipientPropertiesTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
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
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientGeneralPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OnlySendNotificationDuringTheSpecifiedTimes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOnlySendNotificationDuringTheSpecifiedTimes = ";Only send notification during the specified times:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSchedulePage;scheduleOn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlwaysSendNotifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlwaysSendNotifications = ";Always send notifications;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSchedulePage;scheduleOff.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis0 = ";...;ManagedString;DundasWinChart.dll;DC01.bK;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IncludeToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncludeToolStrip = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludeSchedules
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludeSchedules = "Exclude schedules:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludeToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludeToolStrip = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SchedulesToSend
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSchedulesToSend = "Schedules to send:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotificationRecipientDisplayName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotificationRecipientDisplayName = ";Notification recipient &display name:;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientGeneralPage;nameLabel.Text";
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
            /// Caches the translated resource string for:  OnlySendNotificationDuringTheSpecifiedTimes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOnlySendNotificationDuringTheSpecifiedTimes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlwaysSendNotifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlwaysSendNotifications;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IncludeToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIncludeToolStrip;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludeSchedules
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludeSchedules;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IncludeToolStrip_2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludeToolStrip;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SchedulesToSend
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSchedulesToSend;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotificationRecipientDisplayName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotificationRecipientDisplayName;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// Exposes access to the OnlySendNotificationDuringTheSpecifiedTimes translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OnlySendNotificationDuringTheSpecifiedTimes
            {
                get
                {
                    if ((cachedOnlySendNotificationDuringTheSpecifiedTimes == null))
                    {
                        cachedOnlySendNotificationDuringTheSpecifiedTimes = CoreManager.MomConsole.GetIntlStr(ResourceOnlySendNotificationDuringTheSpecifiedTimes);
                    }
                    return cachedOnlySendNotificationDuringTheSpecifiedTimes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlwaysSendNotifications translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlwaysSendNotifications
            {
                get
                {
                    if ((cachedAlwaysSendNotifications == null))
                    {
                        cachedAlwaysSendNotifications = CoreManager.MomConsole.GetIntlStr(ResourceAlwaysSendNotifications);
                    }
                    return cachedAlwaysSendNotifications;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis0 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis0
            {
                get
                {
                    if ((cachedEllipsis0 == null))
                    {
                        cachedEllipsis0 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis0);
                    }
                    return cachedEllipsis0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IncludeToolStrip translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IncludeToolStrip
            {
                get
                {
                    if ((cachedIncludeToolStrip == null))
                    {
                        cachedIncludeToolStrip = CoreManager.MomConsole.GetIntlStr(ResourceIncludeToolStrip);
                    }
                    return cachedIncludeToolStrip;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludeSchedules translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludeSchedules
            {
                get
                {
                    if ((cachedExcludeSchedules == null))
                    {
                        cachedExcludeSchedules = CoreManager.MomConsole.GetIntlStr(ResourceExcludeSchedules);
                    }
                    return cachedExcludeSchedules;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludeToolStrip translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludeToolStrip
            {
                get
                {
                    if ((cachedExcludeToolStrip == null))
                    {
                        cachedExcludeToolStrip = CoreManager.MomConsole.GetIntlStr(ResourceExcludeToolStrip);
                    }
                    return cachedExcludeToolStrip;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SchedulesToSend translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SchedulesToSend
            {
                get
                {
                    if ((cachedSchedulesToSend == null))
                    {
                        cachedSchedulesToSend = CoreManager.MomConsole.GetIntlStr(ResourceSchedulesToSend);
                    }
                    return cachedSchedulesToSend;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotificationRecipientDisplayName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotificationRecipientDisplayName
            {
                get
                {
                    if ((cachedNotificationRecipientDisplayName == null))
                    {
                        cachedNotificationRecipientDisplayName = CoreManager.MomConsole.GetIntlStr(ResourceNotificationRecipientDisplayName);
                    }
                    return cachedNotificationRecipientDisplayName;
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
        /// 	[KellyMor] 4/6/2006 Created
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
            /// Control ID for OnlySendNotificationDuringTheSpecifiedTimesRadioButton
            /// </summary>
            public const string OnlySendNotificationDuringTheSpecifiedTimesRadioButton = "scheduleOn";
            
            /// <summary>
            /// Control ID for AlwaysSendNotificationsRadioButton
            /// </summary>
            public const string AlwaysSendNotificationsRadioButton = "scheduleOff";
            
            /// <summary>
            /// Control ID for Ellipsis0Button
            /// </summary>
            public const string Ellipsis0Button = "browseButton";
            
            /// <summary>
            /// Control ID for IncludeToolStrip
            /// </summary>
            public const string IncludeToolStrip = "toolStrip";
            
            /// <summary>
            /// Control ID for ExcludeSchedulesListView
            /// </summary>
            public const string ExcludeSchedulesListView = "listView";
            
            /// <summary>
            /// Control ID for ExcludeSchedulesStaticControl
            /// </summary>
            public const string ExcludeSchedulesStaticControl = "label";
            
            /// <summary>
            /// Control ID for ExcludeToolStrip
            /// </summary>
            public const string ExcludeToolStrip = "toolStrip";
            
            /// <summary>
            /// Control ID for SchedulesToSendListView
            /// </summary>
            public const string SchedulesToSendListView = "listView";
            
            /// <summary>
            /// Control ID for SchedulesToSendStaticControl
            /// </summary>
            public const string SchedulesToSendStaticControl = "label";
            
            /// <summary>
            /// Control ID for NotificationRecipientDisplayNameTextBox
            /// </summary>
            public const string NotificationRecipientDisplayNameTextBox = "nameBox";
            
            /// <summary>
            /// Control ID for NotificationRecipientDisplayNameStaticControl
            /// </summary>
            public const string NotificationRecipientDisplayNameStaticControl = "nameLabel";
        }
        #endregion
    }
}
