// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="NotificationSubscriptionsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[v-yoz] 8/18/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - INotificationSubscriptionsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, INotificationSubscriptionsDialogControls, for NotificationSubscriptionsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-yoz] 8/18/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface INotificationSubscriptionsDialogControls
    {
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YourPersonalNotificationSubscriptionsStaticControl
        /// </summary>
        StaticControl YourPersonalNotificationSubscriptionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YourPersonalNotificationSubscriptionsListBox
        /// </summary>
        ListBox YourPersonalNotificationSubscriptionsListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[v-yoz] 8/18/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class NotificationSubscriptionsDialog : Dialog, INotificationSubscriptionsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to YourPersonalNotificationSubscriptionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYourPersonalNotificationSubscriptionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YourPersonalNotificationSubscriptionsListBox of type ListBox
        /// </summary>
        private ListBox cachedYourPersonalNotificationSubscriptionsListBox;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of NotificationSubscriptionsDialog of type App
        /// </param>
        /// <history>
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public NotificationSubscriptionsDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region INotificationSubscriptionsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual INotificationSubscriptionsDialogControls Controls
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
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar INotificationSubscriptionsDialogControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, NotificationSubscriptionsDialog.ControlIDs.ToolStrip1);
                }
                
                return this.cachedToolStrip1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YourPersonalNotificationSubscriptionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl INotificationSubscriptionsDialogControls.YourPersonalNotificationSubscriptionsStaticControl
        {
            get
            {
                if ((this.cachedYourPersonalNotificationSubscriptionsStaticControl == null))
                {
                    this.cachedYourPersonalNotificationSubscriptionsStaticControl = new StaticControl(this, NotificationSubscriptionsDialog.ControlIDs.YourPersonalNotificationSubscriptionsStaticControl);
                }
                
                return this.cachedYourPersonalNotificationSubscriptionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YourPersonalNotificationSubscriptionsListBox control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox INotificationSubscriptionsDialogControls.YourPersonalNotificationSubscriptionsListBox
        {
            get
            {
                if ((this.cachedYourPersonalNotificationSubscriptionsListBox == null))
                {
                    this.cachedYourPersonalNotificationSubscriptionsListBox = new ListBox(this, NotificationSubscriptionsDialog.ControlIDs.YourPersonalNotificationSubscriptionsListBox);
                }
                
                return this.cachedYourPersonalNotificationSubscriptionsListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button INotificationSubscriptionsDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, NotificationSubscriptionsDialog.ControlIDs.CloseButton);
                }
                
                return this.cachedCloseButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
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
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

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
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Resource string for Notification Subscriptions
            /// </summary>
            public const string ResourceDialogTitle =
                ";Notification Subscriptions;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionsForm;$this.Text";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-yoz] 8/18/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }

                    return cachedDialogTitle;
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
        /// 	[v-yoz] 8/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip";
            
            /// <summary>
            /// Control ID for YourPersonalNotificationSubscriptionsStaticControl
            /// </summary>
            public const string YourPersonalNotificationSubscriptionsStaticControl = "label";
            
            /// <summary>
            /// Control ID for YourPersonalNotificationSubscriptionsListBox
            /// </summary>
            public const string YourPersonalNotificationSubscriptionsListBox = "listBox";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "okButton";
        }
        #endregion
    }
}
