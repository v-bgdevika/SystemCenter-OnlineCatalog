// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddNotificationRecipientWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor] 24-SEP-08 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
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
    /// 	[KellyMor] 24-SEP-08 Created
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
        /// Read-only property to access DescriptionListBox
        /// </summary>
        ListBox DescriptionListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotificationRecipientsStaticControl
        /// </summary>
        StaticControl NotificationRecipientsStaticControl
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
    /// Class to encapsulate the Add Notification Recipient dialog functionality.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddNotificationRecipientWindow : Dialog, IAddNotificationRecipientWindowControls
    {
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
        /// Cache to hold a reference to DescriptionListBox of type ListBox
        /// </summary>
        private ListBox cachedDescriptionListBox;
        
        /// <summary>
        /// Cache to hold a reference to NotificationRecipientsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotificationRecipientsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddNotificationRecipientWindow of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddNotificationRecipientWindow(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region IAddNotificationRecipientWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        ///  Exposes access to the DescriptionListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAddNotificationRecipientWindowControls.DescriptionListBox
        {
            get
            {
                if ((this.cachedDescriptionListBox == null))
                {
                    this.cachedDescriptionListBox = new ListBox(this, AddNotificationRecipientWindow.ControlIDs.DescriptionListBox);
                }
                
                return this.cachedDescriptionListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotificationRecipientsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddNotificationRecipientWindowControls.NotificationRecipientsStaticControl
        {
            get
            {
                if ((this.cachedNotificationRecipientsStaticControl == null))
                {
                    this.cachedNotificationRecipientsStaticControl = new StaticControl(this, AddNotificationRecipientWindow.ControlIDs.NotificationRecipientsStaticControl);
                }
                
                return this.cachedNotificationRecipientsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        Strings.DialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; 
                    ((null == tempWindow) && (numberOfTries < maxTries)); 
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = 
                            new Window(
                                Strings.DialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries +
                            "...");

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find the window with title := '" +
                        Strings.DialogTitle);

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = 
                ";Add Notification Recipient" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.AddRecipientForm" +
                ";$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK =
                ";OK" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.AddRecipientForm" +
                ";ok.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.AddRecipientForm" +
                ";cancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotificationRecipients
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotificationRecipients =
                ";Notification &Recipients:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.AddRecipientForm" +
                ";recipientsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CheckTheRecipientsToAddThemToTheNotificationSubscription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCheckTheRecipientsToAddThemToTheNotificationSubscription =
                ";Check the recipients to add them to the notification subscription." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.AddRecipientForm" +
                ";titlelabel.Text";

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
            /// Caches the translated resource string for:  NotificationRecipients
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotificationRecipients;
            
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
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// Exposes access to the NotificationRecipients translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotificationRecipients
            {
                get
                {
                    if ((cachedNotificationRecipients == null))
                    {
                        cachedNotificationRecipients = CoreManager.MomConsole.GetIntlStr(ResourceNotificationRecipients);
                    }
                    
                    return cachedNotificationRecipients;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CheckTheRecipientsToAddThemToTheNotificationSubscription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
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
            /// Control ID for DescriptionListBox
            /// </summary>
            public const string DescriptionListBox = "recipientsList";
            
            /// <summary>
            /// Control ID for NotificationRecipientsStaticControl
            /// </summary>
            public const string NotificationRecipientsStaticControl = "recipientsLabel";
            
            /// <summary>
            /// Control ID for CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl
            /// </summary>
            public const string CheckTheRecipientsToAddThemToTheNotificationSubscriptionStaticControl = "titlelabel";
        }
        #endregion
    }
}
