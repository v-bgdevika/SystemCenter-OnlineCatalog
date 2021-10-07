// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="NotificationRecipientDevicePropertiesDialog.cs">
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
//                          Fixed misspelling in generated code
//  [KellyMor]  21-Apr-06   Fixed issue in Init method
//                          Added click methods for toolstip buttons
//                          Added resources strings for toolstrip buttons
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
    
    #region Interface Definition - INotificationRecipientDevicePropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, INotificationRecipientDevicePropertiesDialogControls, for NotificationRecipientDevicePropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface INotificationRecipientDevicePropertiesDialogControls
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
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DevicesListView
        /// </summary>
        ListView DevicesListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotificationDevicesStaticControl
        /// </summary>
        StaticControl NotificationDevicesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EachNotificationDeviceMayHaveASeparateScheduleStaticControl
        /// </summary>
        StaticControl EachNotificationDeviceMayHaveASeparateScheduleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl
        /// </summary>
        StaticControl NotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl
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
    public class NotificationRecipientDevicePropertiesDialog : Dialog, INotificationRecipientDevicePropertiesDialogControls
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
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to DevicesListView of type ListView
        /// </summary>
        private ListView cachedDevicesListView;
        
        /// <summary>
        /// Cache to hold a reference to NotificationDevicesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotificationDevicesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EachNotificationDeviceMayHaveASeparateScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEachNotificationDeviceMayHaveASeparateScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl;

        /// <summary>
        /// Cached reference to the Notification Devices tab
        /// </summary>
        private TabControlTab cachedNotificationDevicesTab;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of NotificationRecipientDevicePropertiesDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public NotificationRecipientDevicePropertiesDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region INotificationRecipientDevicePropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual INotificationRecipientDevicePropertiesDialogControls Controls
        {
            get
            {
                return this;
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
        Button INotificationRecipientDevicePropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, NotificationRecipientDevicePropertiesDialog.ControlIDs.ApplyButton);
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
        Button INotificationRecipientDevicePropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, NotificationRecipientDevicePropertiesDialog.ControlIDs.CancelButton);
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
        Button INotificationRecipientDevicePropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, NotificationRecipientDevicePropertiesDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl INotificationRecipientDevicePropertiesDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, NotificationRecipientDevicePropertiesDialog.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar INotificationRecipientDevicePropertiesDialogControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this);
                }
                return this.cachedToolStrip1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DevicesListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView INotificationRecipientDevicePropertiesDialogControls.DevicesListView
        {
            get
            {
                if ((this.cachedDevicesListView == null))
                {
                    this.cachedDevicesListView = new ListView(this, NotificationRecipientDevicePropertiesDialog.ControlIDs.DevicesListView);
                }
                return this.cachedDevicesListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotificationDevicesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl INotificationRecipientDevicePropertiesDialogControls.NotificationDevicesStaticControl
        {
            get
            {
                if ((this.cachedNotificationDevicesStaticControl == null))
                {
                    this.cachedNotificationDevicesStaticControl = new StaticControl(this, NotificationRecipientDevicePropertiesDialog.ControlIDs.NotificationDevicesStaticControl);
                }
                return this.cachedNotificationDevicesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EachNotificationDeviceMayHaveASeparateScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl INotificationRecipientDevicePropertiesDialogControls.EachNotificationDeviceMayHaveASeparateScheduleStaticControl
        {
            get
            {
                if ((this.cachedEachNotificationDeviceMayHaveASeparateScheduleStaticControl == null))
                {
                    this.cachedEachNotificationDeviceMayHaveASeparateScheduleStaticControl = new StaticControl(this, NotificationRecipientDevicePropertiesDialog.ControlIDs.EachNotificationDeviceMayHaveASeparateScheduleStaticControl);
                }
                return this.cachedEachNotificationDeviceMayHaveASeparateScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl INotificationRecipientDevicePropertiesDialogControls.NotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl
        {
            get
            {
                if ((this.cachedNotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl == null))
                {
                    this.cachedNotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl = new StaticControl(this, NotificationRecipientDevicePropertiesDialog.ControlIDs.NotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl);
                }
                return this.cachedNotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl;
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
        ///  Routine to click on button Add on the ToolStrip
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            // get the hot-key from the resource string
            Core.Common.Utilities.LogMessage("Getting hot-key for:  '" + Strings.AddToolStripItem + "'");
            string hotKey = Strings.AddToolStripItem.Substring((Strings.AddToolStripItem.IndexOf("&") + 1), 1);
            string hotKeySequence = "%(" + hotKey + ")";

            // send the hot-key to the dialog
            Core.Common.Utilities.LogMessage("Sending hot-key:  '" + hotKey + "'");
            this.Controls.ToolStrip1.AccessibleObject.Window.SendKeys(hotKeySequence);
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
            // get the hot-key from the resource string
            Core.Common.Utilities.LogMessage("Getting hot-key for:  '" + Strings.EditToolStripItem + "'");
            string hotKey = Strings.EditToolStripItem.Substring((Strings.EditToolStripItem.IndexOf("&") + 1), 1);
            string hotKeySequence = "%(" + hotKey + ")";

            // send the hot-key to the dialog
            Core.Common.Utilities.LogMessage("Sending hot-key:  '" + hotKey + "'");
            this.Controls.ToolStrip1.AccessibleObject.Window.SendKeys(hotKeySequence);
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
            // get the hot-key from the resource string
            Core.Common.Utilities.LogMessage("Getting hot-key for:  '" + Strings.RemoveToolStripItem + "'");
            string hotKey = Strings.RemoveToolStripItem.Substring((Strings.RemoveToolStripItem.IndexOf("&") + 1), 1);
            string hotKeySequence = "%(" + hotKey + ")";

            // send the hot-key to the dialog
            Core.Common.Utilities.LogMessage("Sending hot-key:  '" + hotKey + "'");
            this.Controls.ToolStrip1.AccessibleObject.Window.SendKeys(hotKeySequence);
        }

        /// <summary>
        /// Method to click on the "Notification Devices" tab
        /// </summary>
        public virtual void ClickNotificationDevicesTab()
        {
            if (null == this.cachedNotificationDevicesTab)
            {
                this.cachedNotificationDevicesTab = new TabControlTab(this.Controls.Tab1TabControl, Strings.Tab1);
            }
            this.cachedNotificationDevicesTab.Click();
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
                    Core.Common.Utilities.LogMessage("Failed to find Schedule dialog!");

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
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = ";Notification Devices;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientDevicePage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotificationDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotificationDevices = ";Notification devices:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientDevicePage;deviceListLa" +
                "bel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EachNotificationDeviceMayHaveASeparateSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEachNotificationDeviceMayHaveASeparateSchedule = ";Each notification device may have a separate schedule.;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientDevicePage;title2Label.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotificationsAreReceivedFromTheDevicesConfiguredOnThisPage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotificationsAreReceivedFromTheDevicesConfiguredOnThisPage = ";Notifications are received from the devices configured on this page.;ManagedStri" +
                "ng;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientDevicePage;titleLabel.Text";


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddToolStripItem = ";&Add;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientDevicePage;addButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EditToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEditToolStripItem = ";&Edit;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" + 
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientDevicePage;editButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemoveToolStripItem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveToolStripItem = ";Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.RecipientDevicePage;removeButton.Text";

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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotificationDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotificationDevices;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EachNotificationDeviceMayHaveASeparateSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEachNotificationDeviceMayHaveASeparateSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotificationsAreReceivedFromTheDevicesConfiguredOnThisPage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotificationsAreReceivedFromTheDevicesConfiguredOnThisPage;

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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
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
            /// Exposes access to the NotificationDevices translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotificationDevices
            {
                get
                {
                    if ((cachedNotificationDevices == null))
                    {
                        cachedNotificationDevices = CoreManager.MomConsole.GetIntlStr(ResourceNotificationDevices);
                    }
                    return cachedNotificationDevices;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EachNotificationDeviceMayHaveASeparateSchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EachNotificationDeviceMayHaveASeparateSchedule
            {
                get
                {
                    if ((cachedEachNotificationDeviceMayHaveASeparateSchedule == null))
                    {
                        cachedEachNotificationDeviceMayHaveASeparateSchedule = CoreManager.MomConsole.GetIntlStr(ResourceEachNotificationDeviceMayHaveASeparateSchedule);
                    }
                    return cachedEachNotificationDeviceMayHaveASeparateSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotificationsAreReceivedFromTheDevicesConfiguredOnThisPage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotificationsAreReceivedFromTheDevicesConfiguredOnThisPage
            {
                get
                {
                    if ((cachedNotificationsAreReceivedFromTheDevicesConfiguredOnThisPage == null))
                    {
                        cachedNotificationsAreReceivedFromTheDevicesConfiguredOnThisPage = CoreManager.MomConsole.GetIntlStr(ResourceNotificationsAreReceivedFromTheDevicesConfiguredOnThisPage);
                    }
                    return cachedNotificationsAreReceivedFromTheDevicesConfiguredOnThisPage;
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip";
            
            /// <summary>
            /// Control ID for DevicesListView
            /// </summary>
            public const string DevicesListView = "deviceList";
            
            /// <summary>
            /// Control ID for NotificationDevicesStaticControl
            /// </summary>
            public const string NotificationDevicesStaticControl = "deviceListLabel";
            
            /// <summary>
            /// Control ID for EachNotificationDeviceMayHaveASeparateScheduleStaticControl
            /// </summary>
            public const string EachNotificationDeviceMayHaveASeparateScheduleStaticControl = "title2Label";
            
            /// <summary>
            /// Control ID for NotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl
            /// </summary>
            public const string NotificationsAreReceivedFromTheDevicesConfiguredOnThisPageStaticControl = "titleLabel";
        }
        #endregion
    }
}
