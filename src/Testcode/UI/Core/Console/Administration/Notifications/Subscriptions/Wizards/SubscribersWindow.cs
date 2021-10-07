// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SubscribersWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  24-SEP-08   Created
//  [KellyMor]  04-SEP-08   Added toolstrip click methods
//  [KellyMor]  08-OCT-08   Added string resource for "Modify..." wizard title
//                          Modified constructor to take a flag indicating which
//                          wizard title to use, i.e. open in edit mode or not.
//  [KellyMor]  09-OCT-08   Modified ClickChoose and ClickEdit methods to use
//                          new Toobar indeces.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISubscribersWindowControls

    /// ---------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISubscribersWindowControls, for SubscribersWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// ---------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISubscribersWindowControls
    {
        /// <summary>
        /// Read-only property to access SubscribersPageStaticControl
        /// </summary>
        StaticControl SubscribersPageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubscribersListView
        /// </summary>
        ListView SubscribersListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedSubscribersStaticControl
        /// </summary>
        StaticControl SelectedSubscribersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InstructionsStaticControl
        /// </summary>
        StaticControl InstructionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl
        /// </summary>
        StaticControl SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl
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
        /// Read-only property to access SubscribersStaticControl3
        /// </summary>
        StaticControl SubscribersStaticControl3
        {
            get;
        }
    }

    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Subscribers step functionality in the 
    /// Notification Subscription wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class SubscribersWindow : 
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, 
        ISubscribersWindowControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SubscribersPageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubscribersPageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SubscribersListView of type ListView
        /// </summary>
        private ListView cachedSubscribersListView;
        
        /// <summary>
        /// Cache to hold a reference to SelectedSubscribersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedSubscribersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InstructionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInstructionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private ToolStrip cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to SubscribersStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedSubscribersStaticControl3;

        #endregion
        
        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of SubscribersWindow of type MomConsoleApp
        /// </param>
        /// <param name="editExisting">
        /// Flag indicating if this wizard window is displaying a new 
        /// subscription or opening an existing one in edit mode.
        /// </param>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        ///     [KellyMor] 08-OCT-08 Added parameter to determine if the wizard
        ///                          is open in new or edit mode.
        /// </history>
        /// -------------------------------------------------------------------
        public SubscribersWindow(MomConsoleApp ownerWindow, bool editExisting)
            : base(ownerWindow, (editExisting ? Strings.ModifyWindowTitle : Strings.WindowTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion

        #region Interface Control Properties

        #region ISubscribersWindow Controls Property

        /// ---------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new ISubscribersWindowControls Controls
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
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public Mom.Test.UI.Core.Console.Administration.IConsoleWizardBase BaseControls
        {
            get
            {
                return base.Controls;
            }
        }

        #endregion IConsoleWizardBase Controls Property

        #endregion Interface Control Properties
        
        #region Control Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscribersPageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscribersWindowControls.SubscribersPageStaticControl
        {
            get
            {
                if ((this.cachedSubscribersPageStaticControl == null))
                {
                    this.cachedSubscribersPageStaticControl = new StaticControl(this, SubscribersWindow.ControlIDs.SubscribersPageStaticControl);
                }
                
                return this.cachedSubscribersPageStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscribersListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        ListView ISubscribersWindowControls.SubscribersListView
        {
            get
            {
                if ((this.cachedSubscribersListView == null))
                {
                    this.cachedSubscribersListView = new ListView(this, new QID(";[UIA]AutomationId ='" + SubscribersWindow.ControlIDs.SubscribersListView + "'"));
                }
                
                return this.cachedSubscribersListView;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedSubscribersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscribersWindowControls.SelectedSubscribersStaticControl
        {
            get
            {
                if ((this.cachedSelectedSubscribersStaticControl == null))
                {
                    this.cachedSelectedSubscribersStaticControl = new StaticControl(this, SubscribersWindow.ControlIDs.SelectedSubscribersStaticControl);
                }
                
                return this.cachedSelectedSubscribersStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InstructionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscribersWindowControls.InstructionsStaticControl
        {
            get
            {
                if ((this.cachedInstructionsStaticControl == null))
                {
                    this.cachedInstructionsStaticControl = new StaticControl(this, SubscribersWindow.ControlIDs.InstructionsStaticControl);
                }
                
                return this.cachedInstructionsStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscribersWindowControls.SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl == null))
                {
                    this.cachedSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl = new StaticControl(this, SubscribersWindow.ControlIDs.SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl);
                }
                
                return this.cachedSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        ToolStrip ISubscribersWindowControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new ToolStrip(this);
                }
                
                return this.cachedToolStrip1;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscribersStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscribersWindowControls.SubscribersStaticControl3
        {
            get
            {
                if ((this.cachedSubscribersStaticControl3 == null))
                {
                    this.cachedSubscribersStaticControl3 = new StaticControl(this, SubscribersWindow.ControlIDs.SubscribersStaticControl3);
                }
                
                return this.cachedSubscribersStaticControl3;
            }
        }

        #endregion

        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "New" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.ToolStrip1.ToolStripItems[0].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Choose" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickChoose()
        {
            this.Controls.ToolStrip1.ToolStripItems[2].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Edit" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-OCT-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.ToolStrip1.ToolStripItems[1].Click();
        }

        #endregion

        #region Strings Class

        /// -------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
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
            private const string ResourceWindowTitle =
                ";Notification Subscription Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceModifyWindowTitle =
                ";Modify Notification Subscription Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionWizardTitleEdit";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Subscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscribers =
                ";Subscribers" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSubscriberPage" +
                ";$this.TabName";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedSubscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSelectedSubscribers =
                ";Selected subscribers:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSubscriberPage" +
                ";subscribersList.CaptionText";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToDefineNewSubscribersClickNewToAddSubscribersWhoAreAlreadyDefinedClickAdd
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstructions = 
                ";To define new subscribers, click New.  To add subscribers who are already defined, click Add." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSubscriberPage" +
                ";toDefineSubscribersLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription =
                ";Specify the subscribers to be notified by this notification subscription." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSubscriberPage" +
                ";specifySubscribersLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceToolStrip1 =
                ";toolStrip1" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSubscriberPage" +
                ";>>toolStrip1.Name";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NavigationLinkSubscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkSubscribers =
                ";Subscribers" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionSubscriberPage" +
                ";$this.NavigationText";

            #endregion
            
            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWindowTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedModifyWindowTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Subscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscribers;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedSubscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSelectedSubscribers;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToDefineNewSubscribersClickNewToAddSubscribersWhoAreAlreadyDefinedClickAdd
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstructions;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedToolStrip1;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NavigationLinkSubscribers
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkSubscribers;

            #endregion
            
            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
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

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ModifyWindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ModifyWindowTitle
            {
                get
                {
                    if ((cachedModifyWindowTitle == null))
                    {
                        cachedModifyWindowTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceModifyWindowTitle);
                    }

                    return cachedModifyWindowTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subscribers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Subscribers
            {
                get
                {
                    if ((cachedSubscribers == null))
                    {
                        cachedSubscribers = CoreManager.MomConsole.GetIntlStr(ResourceSubscribers);
                    }
                    
                    return cachedSubscribers;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedSubscribers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SelectedSubscribers
            {
                get
                {
                    if ((cachedSelectedSubscribers == null))
                    {
                        cachedSelectedSubscribers = CoreManager.MomConsole.GetIntlStr(ResourceSelectedSubscribers);
                    }
                    
                    return cachedSelectedSubscribers;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instructions translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Instructions
            {
                get
                {
                    if ((cachedInstructions == null))
                    {
                        cachedInstructions = CoreManager.MomConsole.GetIntlStr(ResourceInstructions);
                    }
                    
                    return cachedInstructions;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription
            {
                get
                {
                    if ((cachedSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription == null))
                    {
                        cachedSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription);
                    }
                    
                    return cachedSpecifyTheSubscribersToBeNotifiedByThisNotificationSubscription;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
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
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NavigationLinkSubscribers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkSubscribers
            {
                get
                {
                    if ((cachedNavigationLinkSubscribers == null))
                    {
                        cachedNavigationLinkSubscribers = CoreManager.MomConsole.GetIntlStr(ResourceNavigationLinkSubscribers);
                    }
                    
                    return cachedNavigationLinkSubscribers;
                }
            }

            #endregion
        }

        #endregion
        
        #region Control ID's

        /// ---------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for SubscribersPageStaticControl
            /// </summary>
            public const string SubscribersPageStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for SubscribersListView
            /// </summary>
            public const string SubscribersListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for SelectedSubscribersStaticControl
            /// </summary>
            public const string SelectedSubscribersStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for InstructionsStaticControl
            /// </summary>
            public const string InstructionsStaticControl = "toDefineSubscribersLabel";
            
            /// <summary>
            /// Control ID for SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl
            /// </summary>
            public const string SpecifyTheSubscribersToBeNotifiedByThisNotificationSubscriptionStaticControl = "specifySubscribersLabel";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip1";
            
            /// <summary>
            /// Control ID for SubscribersStaticControl3
            /// </summary>
            public const string SubscribersStaticControl3 = "headerLabel";
        }

        #endregion
    }
}
