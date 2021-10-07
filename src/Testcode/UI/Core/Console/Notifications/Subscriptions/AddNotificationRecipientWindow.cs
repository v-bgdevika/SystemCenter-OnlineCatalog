// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddNotificationRecipientWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor] 4/6/2006 Created
//  [KellyMor] 4/25/2006 Updated Init method
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 08-Jun-06    Updated resource assembly namespace
//  [KellyMor] 03-Jul-06    Increased number of retries in Init to 10.
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Notifications.Subscriptions
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAddNotificationRecipientWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddNotificationRecipientWindowControls, for AddNotificationRecipientWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddNotificationRecipientWindowControls
    {
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
        /// Read-only property to access RecipientsListBox
        /// </summary>
        ListBox RecipientsListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MOMv3NotificationRecipientsStaticControl
        /// </summary>
        StaticControl MOMv3NotificationRecipientsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl
        /// </summary>
        StaticControl CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Add Notification Recipient
    /// window.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddNotificationRecipientWindow : Window, IAddNotificationRecipientWindowControls
    {
        #region Protected Internal Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        protected internal static Window activeWindow;
        #endregion
        
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to RecipientsListBox of type ListBox
        /// </summary>
        private ListBox cachedRecipientsListBox;
        
        /// <summary>
        /// Cache to hold a reference to MOMv3NotificationRecipientsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMOMv3NotificationRecipientsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of AddNotificationRecipientWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddNotificationRecipientWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddNotificationRecipientWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddNotificationRecipientWindowControls Controls
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
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddNotificationRecipientWindowControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddNotificationRecipientWindow.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
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
        Button IAddNotificationRecipientWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddNotificationRecipientWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RecipientsListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAddNotificationRecipientWindowControls.RecipientsListBox
        {
            get
            {
                if ((this.cachedRecipientsListBox == null))
                {
                    this.cachedRecipientsListBox = new ListBox(this, AddNotificationRecipientWindow.ControlIDs.RecipientsListBox);
                }
                return this.cachedRecipientsListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MOMv3NotificationRecipientsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddNotificationRecipientWindowControls.MOMv3NotificationRecipientsStaticControl
        {
            get
            {
                if ((this.cachedMOMv3NotificationRecipientsStaticControl == null))
                {
                    this.cachedMOMv3NotificationRecipientsStaticControl = new StaticControl(this, AddNotificationRecipientWindow.ControlIDs.MOMv3NotificationRecipientsStaticControl);
                }
                return this.cachedMOMv3NotificationRecipientsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddNotificationRecipientWindowControls.CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl
        {
            get
            {
                if ((this.cachedCheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl == null))
                {
                    this.cachedCheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl = new StaticControl(this, AddNotificationRecipientWindow.ControlIDs.CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl);
                }
                return this.cachedCheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

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
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = new Window(
                    Strings.WindowTitle, 
                    StringMatchSyntax.WildCard, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    ownerWindow, 
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
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
                                Strings.WindowTitle + "*",
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
                    Core.Common.Utilities.LogMessage("Failed to find the window!");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource String definitions.
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
            private const string ResourceWindowTitle = ";Add Notification Recipient;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.AddRecipientForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MOMv3NotificationRecipients
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMOMv3NotificationRecipients = ";MOMv3 Notification Recipients:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.AddRecipientForm;recipientsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CheckTheRecipientsToAddThemToTheNotificationSubscription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCheckTheRecipientsToAddThemToTheNotificationSubscription = ";Check the recipients to add them to the notification subscription.;ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.AddRecipientForm;titlelabel.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MOMv3NotificationRecipients
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMOMv3NotificationRecipients;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CheckTheRecipientsToAddThemToTheNotificationSubscription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCheckTheRecipientsToAddThemToTheNotificationSubscription;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    return cachedWindowTitle;
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
            /// Exposes access to the MOMv3NotificationRecipients translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MOMv3NotificationRecipients
            {
                get
                {
                    if ((cachedMOMv3NotificationRecipients == null))
                    {
                        cachedMOMv3NotificationRecipients = CoreManager.MomConsole.GetIntlStr(ResourceMOMv3NotificationRecipients);
                    }
                    return cachedMOMv3NotificationRecipients;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CheckTheRecipientsToAddThemToTheNotificationSubscription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CheckTheRecipientsToAddThemToTheNotificationSubscription
            {
                get
                {
                    if ((cachedCheckTheRecipientsToAddThemToTheNotificationSubscription == null))
                    {
                        cachedCheckTheRecipientsToAddThemToTheNotificationSubscription = CoreManager.MomConsole.GetIntlStr(ResourceCheckTheRecipientsToAddThemToTheNotificationSubscription);
                    }
                    return cachedCheckTheRecipientsToAddThemToTheNotificationSubscription;
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
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "ok";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancel";
            
            /// <summary>
            /// Control ID for RecipientsListBox
            /// </summary>
            public const string RecipientsListBox = "recipientsList";
            
            /// <summary>
            /// Control ID for MOMv3NotificationRecipientsStaticControl
            /// </summary>
            public const string MOMv3NotificationRecipientsStaticControl = "recipientsLabel";
            
            /// <summary>
            /// Control ID for CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl
            /// </summary>
            public const string CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl = "titlelabel";
        }
        #endregion
    }
}
