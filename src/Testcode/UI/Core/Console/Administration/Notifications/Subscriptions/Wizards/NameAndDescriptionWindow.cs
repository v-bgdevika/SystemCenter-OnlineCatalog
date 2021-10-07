// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="NameAndDescriptionWindow.cs">
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
//  [KellyMor] 08-OCT-08 Added string resource for "Modify..." wizard title
//                       Modified constructor to take a flag indicating which
//                       wizard title to use, i.e. open in edit mode or not.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - INameAndDescriptionWindowControls

    /// ---------------------------------------------------------------
    /// <summary>
    /// Interface definition, INameAndDescriptionWindowControls, for NameAndDescriptionWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// ---------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface INameAndDescriptionWindowControls
    {
        /// <summary>
        /// Read-only property to access InstructionsStaticControl
        /// </summary>
        StaticControl InstructionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubscriptionNameTextBox
        /// </summary>
        TextBox SubscriptionNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubscriptionNameStaticControl
        /// </summary>
        StaticControl SubscriptionNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateNotificationSubscriptionStaticControl
        /// </summary>
        StaticControl CreateNotificationSubscriptionStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Name and Description step functionality for the 
    /// Notification Subscription Wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class NameAndDescriptionWindow : 
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, 
        INameAndDescriptionWindowControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
                
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to InstructionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInstructionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SubscriptionNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedSubscriptionNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SubscriptionNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubscriptionNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateNotificationSubscriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreateNotificationSubscriptionStaticControl;

        #endregion
        
        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of NameAndDescriptionWindow of type MomConsoleApp
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
        public NameAndDescriptionWindow(MomConsoleApp ownerWindow, bool editExisting) : 
                base(ownerWindow, (editExisting ? Strings.ModifyWindowTitle : Strings.WindowTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion

        #region Interface Control Properties

        #region INameAndDescriptionWindow Controls Property

        /// ---------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new INameAndDescriptionWindowControls Controls
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

        #region Text Field Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Subscribers
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual string SubscriptionNameText
        {
            get
            {
                return this.Controls.SubscriptionNameTextBox.Text;
            }
            
            set
            {
                this.Controls.SubscriptionNameTextBox.Text = value;
            }
        }

        #endregion
        
        #region Control Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InstructionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl INameAndDescriptionWindowControls.InstructionsStaticControl
        {
            get
            {
                if ((this.cachedInstructionsStaticControl == null))
                {
                    this.cachedInstructionsStaticControl = new StaticControl(this, NameAndDescriptionWindow.ControlIDs.InstructionsStaticControl);
                }
                
                return this.cachedInstructionsStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        TextBox INameAndDescriptionWindowControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, NameAndDescriptionWindow.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl INameAndDescriptionWindowControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, NameAndDescriptionWindow.ControlIDs.DescriptionStaticControl);
                }
                
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscriptionNameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        TextBox INameAndDescriptionWindowControls.SubscriptionNameTextBox
        {
            get
            {
                if ((this.cachedSubscriptionNameTextBox == null))
                {
                    this.cachedSubscriptionNameTextBox = new TextBox(this, NameAndDescriptionWindow.ControlIDs.SubscriptionNameTextBox);
                }
                
                return this.cachedSubscriptionNameTextBox;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscriptionNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl INameAndDescriptionWindowControls.SubscriptionNameStaticControl
        {
            get
            {
                if ((this.cachedSubscriptionNameStaticControl == null))
                {
                    this.cachedSubscriptionNameStaticControl = new StaticControl(this, NameAndDescriptionWindow.ControlIDs.SubscriptionNameStaticControl);
                }
                
                return this.cachedSubscriptionNameStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateNotificationSubscriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl INameAndDescriptionWindowControls.CreateNotificationSubscriptionStaticControl
        {
            get
            {
                if ((this.cachedCreateNotificationSubscriptionStaticControl == null))
                {
                    this.cachedCreateNotificationSubscriptionStaticControl = new StaticControl(this, NameAndDescriptionWindow.ControlIDs.CreateNotificationSubscriptionStaticControl);
                }
                
                return this.cachedCreateNotificationSubscriptionStaticControl;
            }
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
            /// Contains resource string for:  Instructions
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstructions =
                ";Provide a name and description for this subscription, and add the recipients." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionGeneralPage" +
                ";titleLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDescription =
                ";&Description:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionGeneralPage" +
                ";descriptionLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SubscriptionName
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriptionName =
                ";&Subscription name:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionGeneralPage" +
                ";nameLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateNotificationSubscription
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCreateNotificationSubscription =
                ";Create Notification Subscription" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionGeneralPageTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NavigationLinkDescription
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkDescription =
                ";Description" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionGeneralPage" +
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
            /// Caches the translated resource string for:  Instructions
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstructions;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDescription;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SubscriptionName
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriptionName;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateNotificationSubscription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCreateNotificationSubscription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NavigationLinkDescription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkDescription;
            
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
            /// Exposes access to the Description2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    
                    return cachedDescription;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriptionName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriptionName
            {
                get
                {
                    if ((cachedSubscriptionName == null))
                    {
                        cachedSubscriptionName = CoreManager.MomConsole.GetIntlStr(ResourceSubscriptionName);
                    }
                    
                    return cachedSubscriptionName;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateNotificationSubscription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CreateNotificationSubscription
            {
                get
                {
                    if ((cachedCreateNotificationSubscription == null))
                    {
                        cachedCreateNotificationSubscription = CoreManager.MomConsole.GetIntlStr(ResourceCreateNotificationSubscription);
                    }
                    
                    return cachedCreateNotificationSubscription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NavigationLinkDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkDescription
            {
                get
                {
                    if ((cachedNavigationLinkDescription == null))
                    {
                        cachedNavigationLinkDescription = CoreManager.MomConsole.GetIntlStr(ResourceNavigationLinkDescription);
                    }

                    return cachedNavigationLinkDescription;
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
            /// Control ID for InstructionsStaticControl
            /// </summary>
            public const string InstructionsStaticControl = "titleLabel";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionBox";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for SubscriptionNameTextBox
            /// </summary>
            public const string SubscriptionNameTextBox = "nameBox";
            
            /// <summary>
            /// Control ID for SubscriptionNameStaticControl
            /// </summary>
            public const string SubscriptionNameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for CreateNotificationSubscriptionStaticControl
            /// </summary>
            public const string CreateNotificationSubscriptionStaticControl = "headerLabel";
        }
        #endregion
    }
}
