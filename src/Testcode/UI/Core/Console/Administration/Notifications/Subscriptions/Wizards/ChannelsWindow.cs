// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ChannelsWindow.cs">
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
//  [KellyMor]  06-OCT-08   Added toolbar Click methods.
//  [KellyMor]  08-OCT-08   Changed ChannelsGridView from PropertyGridView to 
//                          DataGridView.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - AlertAgingOption

    /// ---------------------------------------------------------------
    /// <summary>
    /// Enum for radio group AlertAgingOption
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// ---------------------------------------------------------------
    public enum AlertAgingOption
    {
        /// <summary>
        /// DelaySendingNotificationIfConditionsRemainUnchangedForLongerThanInMinutes = 0
        /// </summary>
        DelaySendingNotificationIfConditionsRemainUnchangedForLongerThanInMinutes = 0,
        
        /// <summary>
        /// SendNotificationNow = 1
        /// </summary>
        SendNotificationNow = 1,
    }
    #endregion
    
    #region Interface Definition - IChannelsWindowControls

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IChannelsWindowControls, for ChannelsWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IChannelsWindowControls
    {
        /// <summary>
        /// Read-only property to access AlertAgingStaticControl
        /// </summary>
        StaticControl AlertAgingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertAgeLimitTextBox
        /// </summary>
        TextBox AlertAgeLimitTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DelaySendingNotificationRadioButton
        /// </summary>
        RadioButton DelaySendingNotificationRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SendNotificationNowRadioButton
        /// </summary>
        RadioButton SendNotificationNowRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChannelsGridView
        /// </summary>
        DataGridView ChannelsGridView
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
        /// Read-only property to access ChannelsStaticControl2
        /// </summary>
        StaticControl ChannelsStaticControl2
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
    }

    #endregion

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Channels step functionality in the Notification
    /// Subscription wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class ChannelsWindow : 
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, 
        IChannelsWindowControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to AlertAgingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertAgingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertAgeLimitTextBox of type TextBox
        /// </summary>
        private TextBox cachedAlertAgeLimitTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DelaySendingNotificationRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDelaySendingNotificationRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SendNotificationNowRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSendNotificationNowRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ChannelsGridView of type DataGridView
        /// </summary>
        private DataGridView cachedChannelsGridView;
        
        /// <summary>
        /// Cache to hold a reference to InstructionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInstructionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChannelsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedChannelsStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type ToolStrip
        /// </summary>
        private ToolStrip cachedToolStrip1;
        
        #endregion
        
        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of ChannelsWindow of type MomConsoleApp
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
        public ChannelsWindow(MomConsoleApp ownerWindow, bool editExisting)
            : base(ownerWindow, (editExisting ? Strings.ModifyWindowTitle : Strings.WindowTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region Radio Group Properties

        /// ---------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group AlertAgingOption
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual AlertAgingOption AlertAgingOption
        {
            get
            {
                if ((this.Controls.DelaySendingNotificationRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AlertAgingOption.DelaySendingNotificationIfConditionsRemainUnchangedForLongerThanInMinutes;
                }
                
                if ((this.Controls.SendNotificationNowRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AlertAgingOption.SendNotificationNow;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == AlertAgingOption.DelaySendingNotificationIfConditionsRemainUnchangedForLongerThanInMinutes))
                {
                    this.Controls.DelaySendingNotificationRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == AlertAgingOption.SendNotificationNow))
                    {
                        this.Controls.SendNotificationNowRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region Interface Control Properties

        #region IChannelsWindow Controls Property

        /// ---------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new IChannelsWindowControls Controls
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
        ///  Routine to set/get the text in control CriteriaDescriptionClickTheUnderlinedValueToEdit
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public virtual string AlertAgeLimitText
        {
            get
            {
                return this.Controls.AlertAgeLimitTextBox.Text;
            }
            
            set
            {
                this.Controls.AlertAgeLimitTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertAgingStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IChannelsWindowControls.AlertAgingStaticControl
        {
            get
            {
                if ((this.cachedAlertAgingStaticControl == null))
                {
                    this.cachedAlertAgingStaticControl = new StaticControl(this, ChannelsWindow.ControlIDs.AlertAgingStaticControl);
                }
                
                return this.cachedAlertAgingStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertAgeLimitTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        TextBox IChannelsWindowControls.AlertAgeLimitTextBox
        {
            get
            {
                if ((this.cachedAlertAgeLimitTextBox == null))
                {
                    this.cachedAlertAgeLimitTextBox = new TextBox(this, ChannelsWindow.ControlIDs.AlertAgeLimitTextBox);
                }
                
                return this.cachedAlertAgeLimitTextBox;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DelaySendingNotificationRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        RadioButton IChannelsWindowControls.DelaySendingNotificationRadioButton
        {
            get
            {
                if ((this.cachedDelaySendingNotificationRadioButton == null))
                {
                    this.cachedDelaySendingNotificationRadioButton = new RadioButton(this, ChannelsWindow.ControlIDs.DelaySendingNotificationRadioButton);
                }
                
                return this.cachedDelaySendingNotificationRadioButton;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SendNotificationNowRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        RadioButton IChannelsWindowControls.SendNotificationNowRadioButton
        {
            get
            {
                if ((this.cachedSendNotificationNowRadioButton == null))
                {
                    this.cachedSendNotificationNowRadioButton = new RadioButton(this, ChannelsWindow.ControlIDs.SendNotificationNowRadioButton);
                }
                
                return this.cachedSendNotificationNowRadioButton;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelsGridView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        DataGridView IChannelsWindowControls.ChannelsGridView
        {
            get
            {
                if ((this.cachedChannelsGridView == null))
                {
                    this.cachedChannelsGridView = new DataGridView(this, ChannelsWindow.ControlIDs.ChannelsGridView);
                }
                
                return this.cachedChannelsGridView;
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
        StaticControl IChannelsWindowControls.InstructionsStaticControl
        {
            get
            {
                if ((this.cachedInstructionsStaticControl == null))
                {
                    this.cachedInstructionsStaticControl = new StaticControl(this, ChannelsWindow.ControlIDs.InstructionsStaticControl);
                }
                
                return this.cachedInstructionsStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl IChannelsWindowControls.ChannelsStaticControl2
        {
            get
            {
                if ((this.cachedChannelsStaticControl2 == null))
                {
                    this.cachedChannelsStaticControl2 = new StaticControl(this, ChannelsWindow.ControlIDs.ChannelsStaticControl2);
                }
                
                return this.cachedChannelsStaticControl2;
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
        ToolStrip IChannelsWindowControls.ToolStrip1
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
        
        #endregion

        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "New" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 06-OCT-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.ToolStrip1.ToolStripItems[0].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Edit" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 06-OCT-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.ToolStrip1.ToolStripItems[1].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Choose" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 06-OCT-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickChoose()
        {
            this.Controls.ToolStrip1.ToolStripItems[2].Click();
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
            /// Contains resource string for:  AlertAging
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAlertAging = 
                ";Alert aging:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionFormatPage" +
                ";alertAgingSectionLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DelaySendingNotificationIfConditionsRemainUnchangedForLongerThanInMinutes
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDelaySendingNotification = 
                ";Delay sending notification if conditions remain unchanged for longer than (in minutes):" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionFormatPage" +
                ";agingDelayRadio.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SendNotificationNow
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSendNotificationNow =
                ";Send notification now" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionFormatPage" +
                ";sendNotificationNowRadio.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Instructions
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstructions =
                ";You can set the channels for notifications generated by this subscription.  Currently the following channels are specified:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionFormatPage" +
                ";headerLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Channels2
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkChannels =
                ";Channels" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionFormatPage" +
                ";$this.NavigationText";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceToolStrip1 =
                ";toolStrip1" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionFormatPage" +
                ";>>toolStrip1.Name";

            #endregion
            
            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WindowTitle
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
            /// Caches the translated resource string for:  AlertAging
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAlertAging;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DelaySendingNotificationIfConditionsRemainUnchangedForLongerThanInMinutes
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDelaySendingNotification;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SendNotificationNow
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSendNotificationNow;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Instructions
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstructions;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Channels2
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkChannels;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedToolStrip1;
            
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
            /// Exposes access to the AlertAging translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlertAging
            {
                get
                {
                    if ((cachedAlertAging == null))
                    {
                        cachedAlertAging = CoreManager.MomConsole.GetIntlStr(ResourceAlertAging);
                    }
                    
                    return cachedAlertAging;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DelaySendingNotification translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DelaySendingNotification
            {
                get
                {
                    if ((cachedDelaySendingNotification == null))
                    {
                        cachedDelaySendingNotification = CoreManager.MomConsole.GetIntlStr(ResourceDelaySendingNotification);
                    }
                    
                    return cachedDelaySendingNotification;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SendNotificationNow translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SendNotificationNow
            {
                get
                {
                    if ((cachedSendNotificationNow == null))
                    {
                        cachedSendNotificationNow = CoreManager.MomConsole.GetIntlStr(ResourceSendNotificationNow);
                    }
                    
                    return cachedSendNotificationNow;
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
            /// Exposes access to the NavigationLinkChannels translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkChannels
            {
                get
                {
                    if ((cachedNavigationLinkChannels == null))
                    {
                        cachedNavigationLinkChannels = CoreManager.MomConsole.GetIntlStr(ResourceNavigationLinkChannels);
                    }
                    
                    return cachedNavigationLinkChannels;
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
            /// Control ID for AlertAgingStaticControl
            /// </summary>
            public const string AlertAgingStaticControl = "alertAgingSectionLabel";
            
            /// <summary>
            /// Control ID for AlertAgeLimitTextBox
            /// </summary>
            public const string AlertAgeLimitTextBox = "agingLengthTextBox";
            
            /// <summary>
            /// Control ID for DelaySendingNotificationRadioButton
            /// </summary>
            public const string DelaySendingNotificationRadioButton = "agingDelayRadio";
            
            /// <summary>
            /// Control ID for SendNotificationNowRadioButton
            /// </summary>
            public const string SendNotificationNowRadioButton = "sendNotificationNowRadio";
            
            /// <summary>
            /// Control ID for ChannelsGridView
            /// </summary>
            public const string ChannelsGridView = "channelsGrid";
            
            /// <summary>
            /// Control ID for InstructionsStaticControl
            /// </summary>
            public const string InstructionsStaticControl = "headerLabel";
            
            /// <summary>
            /// Control ID for ChannelsStaticControl2
            /// </summary>
            public const string ChannelsStaticControl2 = "formatLabel";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip1";
            
            /// <summary>
            /// Control ID for ChannelsStaticControl3
            /// </summary>
            public const string ChannelsStaticControl3 = "headerLabel";
        }

        #endregion
    }
}
