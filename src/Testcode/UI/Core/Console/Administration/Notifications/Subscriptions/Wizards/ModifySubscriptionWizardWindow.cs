// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ModifySubscriptionWizardWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor] 28-OCT-08 Created
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IModifySubscriptionWizardWindowControls

    /// ---------------------------------------------------------------
    /// <summary>
    /// Interface definition, IModifySubscriptionWizardWindowControls, 
    /// for ModifySubscriptionWizardWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 28-OCT-08 Created
    /// </history>
    /// ---------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IModifySubscriptionWizardWindowControls
    {
        /// <summary>
        /// Read-only property to access SubscriptionInfoStaticControl
        /// </summary>
        StaticControl SubscriptionInfoStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableItemsListView
        /// </summary>
        ListView AvailableItemsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableItemsStaticControl
        /// </summary>
        StaticControl AvailableItemsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClearButton
        /// </summary>
        Button ClearButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FindNowButton
        /// </summary>
        Button FindNowButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CriteriaTextBox
        /// </summary>
        TextBox CriteriaTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertNameStaticControl
        /// </summary>
        StaticControl AlertNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertNameTitleStaticControl
        /// </summary>
        StaticControl AlertNameTitleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DirectionsStaticControl
        /// </summary>
        StaticControl DirectionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HeaderStaticControl
        /// </summary>
        StaticControl HeaderStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the modify subscription
    /// wizard page.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 28-OCT-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class ModifySubscriptionWizardWindow :
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, 
        IModifySubscriptionWizardWindowControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SubscriptionInfoStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubscriptionInfoStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsListView of type ListView
        /// </summary>
        private ListView cachedAvailableItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;
        
        /// <summary>
        /// Cache to hold a reference to FindNowButton of type Button
        /// </summary>
        private Button cachedFindNowButton;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CriteriaTextBox of type TextBox
        /// </summary>
        private TextBox cachedCriteriaTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AlertNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertNameTitleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertNameTitleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DirectionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDirectionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HeaderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHeaderStaticControl;

        #endregion
        
        #region Constructors

        /// ---------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of ModifySubscriptionWizardWindow of type 
        /// MomConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public ModifySubscriptionWizardWindow(
            MomConsoleApp ownerWindow) : 
                base(ownerWindow, Strings.WindowTitle)
        {
            // Add Constructor logic here. 
        }

        #endregion

        #region Interface Control Properties

        #region IModifySubscriptionWizardWindow Controls Property

        /// ---------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new IModifySubscriptionWizardWindowControls Controls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IConsoleWizardBase Controls Property

        /// ---------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for the base class of the 
        /// dialog.
        /// </summary>
        /// <value>
        /// An interface that groups all of the base class dialog's control 
        /// properties together.
        /// </value>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public Mom.Test.UI.Core.Console.Administration.IConsoleWizardBase BaseControls
        {
            get
            {
                return base.Controls;
            }
        }

        #endregion

        #endregion Interface Control Properties

        #region Text Field Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Criteria
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual string CriteriaText
        {
            get
            {
                return this.Controls.CriteriaTextBox.Text;
            }
            
            set
            {
                this.Controls.CriteriaTextBox.Text = value;
            }
        }

        #endregion
        
        #region Control Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscriptionInfoStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IModifySubscriptionWizardWindowControls.SubscriptionInfoStaticControl
        {
            get
            {
                if ((this.cachedSubscriptionInfoStaticControl == null))
                {
                    this.cachedSubscriptionInfoStaticControl = 
                        new StaticControl(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.SubscriptionInfoStaticControl);
                }
                
                return this.cachedSubscriptionInfoStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        ListView IModifySubscriptionWizardWindowControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = 
                        new ListView(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.AvailableItemsListView);
                }
                
                return this.cachedAvailableItemsListView;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IModifySubscriptionWizardWindowControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = 
                        new StaticControl(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.AvailableItemsStaticControl);
                }
                
                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        Button IModifySubscriptionWizardWindowControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = 
                        new Button(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.ClearButton);
                }
                
                return this.cachedClearButton;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FindNowButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        Button IModifySubscriptionWizardWindowControls.FindNowButton
        {
            get
            {
                if ((this.cachedFindNowButton == null))
                {
                    this.cachedFindNowButton = 
                        new Button(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.FindNowButton);
                }
                
                return this.cachedFindNowButton;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IModifySubscriptionWizardWindowControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = 
                        new StaticControl(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.LookForStaticControl);
                }
                
                return this.cachedLookForStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        TextBox IModifySubscriptionWizardWindowControls.CriteriaTextBox
        {
            get
            {
                if ((this.cachedCriteriaTextBox == null))
                {
                    this.cachedCriteriaTextBox = 
                        new TextBox(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.CriteriaTextBox);
                }
                
                return this.cachedCriteriaTextBox;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IModifySubscriptionWizardWindowControls.AlertNameStaticControl
        {
            get
            {
                if ((this.cachedAlertNameStaticControl == null))
                {
                    this.cachedAlertNameStaticControl = 
                        new StaticControl(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.AlertNameStaticControl);
                }
                
                return this.cachedAlertNameStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertNameTitleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IModifySubscriptionWizardWindowControls.AlertNameTitleStaticControl
        {
            get
            {
                if ((this.cachedAlertNameTitleStaticControl == null))
                {
                    this.cachedAlertNameTitleStaticControl = 
                        new StaticControl(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.AlertNameTitleStaticControl);
                }
                
                return this.cachedAlertNameTitleStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DirectionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IModifySubscriptionWizardWindowControls.DirectionsStaticControl
        {
            get
            {
                if ((this.cachedDirectionsStaticControl == null))
                {
                    this.cachedDirectionsStaticControl = new StaticControl(this, ModifySubscriptionWizardWindow.ControlIDs.DirectionsStaticControl);
                }
                
                return this.cachedDirectionsStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeaderStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IModifySubscriptionWizardWindowControls.HeaderStaticControl
        {
            get
            {
                if ((this.cachedHeaderStaticControl == null))
                {
                    this.cachedHeaderStaticControl = 
                        new StaticControl(
                            this, 
                            ModifySubscriptionWizardWindow.ControlIDs.HeaderStaticControl);
                }
                
                return this.cachedHeaderStaticControl;
            }
        }

        #endregion
        
        #region Click Methods

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button FindNow
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual void ClickFindNow()
        {
            this.Controls.FindNowButton.Click();
        }

        #endregion
        
        #region Strings Class

        /// -------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-OCT-08 Created
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
                ";Modify Notification Subscription Wizard" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionWizardTitleEdit";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Subscription
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscription =
                ";&Subscription" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ChooseSubscriptionPage" +
                ";availableObjectsControl.CaptionText";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceClear =
                ";&Clear" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FindBar" +
                ";clearButton.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FindNow
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceFindNow =
                ";&Find Now" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FindBar" +
                ";findButton.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LookFor
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceLookFor =
                ";&Look for:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.FindBar" +
                ";lookForLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NameOfAlert
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNameOfAlert =
                ";Name of alert:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ChooseSubscriptionPage" +
                ";alertNameTitleLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DirectionsStaticControl
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDirections =
                ";Select the notification subscription to which you want to add notifications from this alert.  You can select a subscription regardless of the subscription status; however, you will not receive notifications unless the subscription is enabled." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ChooseSubscriptionPage" +
                ";directionsLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Header
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceHeader =
                ";Select Subscription" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ChooseSubscriptionPageTitle";

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
            /// Caches the translated resource string for:  Subscription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscription;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedClear;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FindNow
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedFindNow;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedLookFor;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NameOfAlert
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNameOfAlert;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DirectionsStaticControl
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDirections;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Header
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedHeader;

            #endregion
            
            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWindowTitle);
                    }
                    
                    return cachedWindowTitle;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subscription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Subscription
            {
                get
                {
                    if ((cachedSubscription == null))
                    {
                        cachedSubscription = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscription);
                    }
                    
                    return cachedSubscription;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Clear
            {
                get
                {
                    if ((cachedClear == null))
                    {
                        cachedClear = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceClear);
                    }
                    
                    return cachedClear;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FindNow translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string FindNow
            {
                get
                {
                    if ((cachedFindNow == null))
                    {
                        cachedFindNow = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceFindNow);
                    }
                    
                    return cachedFindNow;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string LookFor
            {
                get
                {
                    if ((cachedLookFor == null))
                    {
                        cachedLookFor = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceLookFor);
                    }
                    
                    return cachedLookFor;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NameOfAlert translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NameOfAlert
            {
                get
                {
                    if ((cachedNameOfAlert == null))
                    {
                        cachedNameOfAlert = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNameOfAlert);
                    }
                    
                    return cachedNameOfAlert;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DirectionsStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Directions
            {
                get
                {
                    if ((cachedDirections == null))
                    {
                        cachedDirections = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDirections);
                    }
                    
                    return cachedDirections;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Header translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Header
            {
                get
                {
                    if ((cachedHeader == null))
                    {
                        cachedHeader = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceHeader);
                    }
                    
                    return cachedHeader;
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
        /// 	[KellyMor] 28-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new class ControlIDs
        {            
            /// <summary>
            /// Control ID for SubscriptionInfoStaticControl
            /// </summary>
            public const string SubscriptionInfoStaticControl = "subscriptionInfoLabel";
            
            /// <summary>
            /// Control ID for AvailableItemsListView
            /// </summary>
            public const string AvailableItemsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AvailableItemsStaticControl
            /// </summary>
            public const string AvailableItemsStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearButton";
            
            /// <summary>
            /// Control ID for FindNowButton
            /// </summary>
            public const string FindNowButton = "findButton";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "lookForLabel";
            
            /// <summary>
            /// Control ID for CriteriaTextBox
            /// </summary>
            public const string CriteriaTextBox = "lookForTextbox";
            
            /// <summary>
            /// Control ID for AlertNameStaticControl
            /// </summary>
            public const string AlertNameStaticControl = "alertNameLabel";
            
            /// <summary>
            /// Control ID for AlertNameTitleStaticControl
            /// </summary>
            public const string AlertNameTitleStaticControl = "alertNameTitleLabel";
            
            /// <summary>
            /// Control ID for DirectionsStaticControl
            /// </summary>
            public const string DirectionsStaticControl = "directionsLabel";
            
            /// <summary>
            /// Control ID for HeaderStaticControl
            /// </summary>
            public const string HeaderStaticControl = "headerLabel";
        }

        #endregion
    }
}
