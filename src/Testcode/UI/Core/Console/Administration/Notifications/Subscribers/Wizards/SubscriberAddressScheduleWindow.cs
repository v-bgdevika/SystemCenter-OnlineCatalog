// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SubscriberAddressScheduleWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  22-AUG-08   Created
//  [KellyMor]  27-AUG-08   Added click methods for schedules list toolbar
//  [KellyMor]  12-SEP-08   Updated control ID's and resource strings.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Radio Group Enumeration - DeliveryAddressScheduleOption

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group DeliveryAddressScheduleOption
    /// </summary>
    /// <history>
    /// 	[KellyMor] 22-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum DeliveryAddressScheduleOption
    {
        /// <summary>
        /// AlwaysSend = 0
        /// </summary>
        AlwaysSend = 0,

        /// <summary>
        /// SendDuringSpecifiedTimes = 1
        /// </summary>
        SendDuringSpecifiedTimes = 1,
    }
    #endregion

    #region Interface Definition - ISubscriberAddressScheduleWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISubscriberAddressScheduleWindow, for 
    /// SubscriberAddressScheduleWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 22-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISubscriberAddressScheduleWindow
    {
        /// <summary>
        /// Read-only property to access AlwaysSendRadioButton
        /// </summary>
        RadioButton AlwaysSendRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SendDuringSpecifiedTimesRadioButton
        /// </summary>
        RadioButton SendDuringSpecifiedTimesRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SchedulesListToolStrip
        /// </summary>
        ToolStrip SchedulesListToolStrip
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SchedulesListView
        /// </summary>
        ListView SchedulesListView
        {
            get;
        }
    }

    #endregion Interface Definition - ISubscriberAddressScheduleWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Notification Calendar
    /// step in the Subscriber Wizard.  
    /// </summary>
    /// <history>
    ///     [KellyMor] 22-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class SubscriberAddressScheduleWindow :
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase,
        ISubscriberAddressScheduleWindow
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members

        /// <summary>
        /// Cache to hold a reference to AlwaysSendRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAlwaysSendRadioButton;

        /// <summary>
        /// Cache to hold a reference to SendDuringSpecifiedTimesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSendDuringSpecifiedTimesRadioButton;

        /// <summary>
        /// Cache to hold a reference to SchedulesListToolStrip of type ToolStrip
        /// </summary>
        private ToolStrip cachedSchedulesListToolStrip;

        /// <summary>
        /// Cache to hold a reference to SchedulesListView of type ListView
        /// </summary>
        private ListView cachedSchedulesListView;

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Owner of ConsoleWizardBase of type ConsoleApp
        /// </param>
        /// <history>
        ///     [KellyMor] 22-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------
        public SubscriberAddressScheduleWindow(ConsoleApp app)
            : base(app, Strings.SubscriberAddressWizardTitle)
        {
            // Add constructor logic
        }

        #endregion Constructors

        #region Interface Control Properties

        #region ISubscriberAddressScheduleWindow Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new ISubscriberAddressScheduleWindow Controls
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
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public Mom.Test.UI.Core.Console.Administration.IConsoleWizardBase BaseControls
        {
            get
            {
                return base.Controls;
            }
        }

        #endregion

        #endregion

        #region Radio Group Properties

        /// -------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group DeliveryAddressScheduleOption
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual DeliveryAddressScheduleOption DeliveryAddressScheduleOption
        {
            get
            {
                if ((this.Controls.AlwaysSendRadioButton.ButtonState == ButtonState.Checked))
                {
                    return DeliveryAddressScheduleOption.AlwaysSend;
                }

                if ((this.Controls.SendDuringSpecifiedTimesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return DeliveryAddressScheduleOption.SendDuringSpecifiedTimes;
                }

                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == DeliveryAddressScheduleOption.AlwaysSend))
                {
                    this.Controls.AlwaysSendRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == DeliveryAddressScheduleOption.SendDuringSpecifiedTimes))
                    {
                        this.Controls.SendDuringSpecifiedTimesRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }

        #endregion

        #region Control Properties

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlwaysSendRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        RadioButton ISubscriberAddressScheduleWindow.AlwaysSendRadioButton
        {
            get
            {
                if ((this.cachedAlwaysSendRadioButton == null))
                {
                    this.cachedAlwaysSendRadioButton =
                        new RadioButton(
                            this,
                            SubscriberAddressScheduleWindow.ControlIDs.AlwaysSendRadioButton);
                }

                return this.cachedAlwaysSendRadioButton;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SendDuringSpecifiedTimesRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        RadioButton ISubscriberAddressScheduleWindow.SendDuringSpecifiedTimesRadioButton
        {
            get
            {
                if ((this.cachedSendDuringSpecifiedTimesRadioButton == null))
                {
                    this.cachedSendDuringSpecifiedTimesRadioButton =
                        new RadioButton(
                            this, SubscriberAddressScheduleWindow.ControlIDs.SendDuringSpecifiedTimesRadioButton);
                }

                return this.cachedSendDuringSpecifiedTimesRadioButton;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SchedulesListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ListView ISubscriberAddressScheduleWindow.SchedulesListView
        {
            get
            {
                if ((this.cachedSchedulesListView == null))
                {
                    this.cachedSchedulesListView =
                        new ListView(
                            this,
                            SubscriberAddressScheduleWindow.ControlIDs.SchedulesListView);
                }

                return this.cachedSchedulesListView;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SchedulesListToolStrip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        ToolStrip ISubscriberAddressScheduleWindow.SchedulesListToolStrip
        {
            get
            {
                if ((this.cachedSchedulesListToolStrip == null))
                {
                    this.cachedSchedulesListToolStrip = new ToolStrip(this);
                }

                return this.cachedSchedulesListToolStrip;
            }
        }

        #endregion

        #region Click Methods

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Add" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 27-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.SchedulesListToolStrip.ToolStripItems[0].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Edit" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 27-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.SchedulesListToolStrip.ToolStripItems[1].Click();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Remove" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 27-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.SchedulesListToolStrip.ToolStripItems[2].Click();
        }

        #endregion

        #region Strings

        /// -------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 22-AUG-08 Created
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
            private const string ResourceSubscriberAddressWizardTitle =
                ";Subscriber Address" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";DeviceWizardTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the AlwaysSend label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAlwaysSend =
                ";A&lways send notifications" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceSchedulePage" +
                ";scheduleOff.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the SendDuringSpecifiedTimes label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSendDuringSpecifiedTimes =
                ";&Only send notification during the specified times:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceSchedulePage" +
                ";scheduleOn.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the NotifyDuringTheseTimes label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNotifyDuringTheseTimes =
                ";&Only send notification during the specified times:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceSchedulePage" +
                ";scheduleOn.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Instruction label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstructions =
                ";Set the schedule for receiving notifications at this subscriber address." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceSchedulePage" +
                ";titleLabel.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAddToolStripItem =
                ";&Add" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceSchedulePage" +
                ";periods.AddButtonText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EditToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceEditToolStripItem =
                ";&Edit" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceSchedulePage" +
                ";periods.EditButtonText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemoveToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceRemoveToolStripItem =
                ";&Remove" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceSchedulePage" +
                ";periods.RemoveButtonText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Schedule 
            /// navigation link label
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkSchedule =
                ";Schedule" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.DeviceSchedulePage" +
                ";$this.NavigationText";

            #endregion Constants

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Subscriber Address wizard 
            /// window title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriberAddressWizardTitle;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource AlwaysSend
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAlwaysSend;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource SendDuringSpecifiedTimes
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSendDuringSpecifiedTimes;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource NotifyDuringTheseTimes
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNotifyDuringTheseTimes;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAddToolStripItem;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EditToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedEditToolStripItem;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RemoveToolStripItem
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedRemoveToolStripItem;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Instructions 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstructions;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the 
            /// NavigationLinkSchedule link label
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkSchedule;

            #endregion

            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriberAddressWizardTitle translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 13-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriberAddressWizardTitle
            {
                get
                {
                    if ((cachedSubscriberAddressWizardTitle == null))
                    {
                        cachedSubscriberAddressWizardTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSubscriberAddressWizardTitle);
                    }

                    return cachedSubscriberAddressWizardTitle;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlwaysSend 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AlwaysSend
            {
                get
                {
                    if ((cachedAlwaysSend == null))
                    {
                        cachedAlwaysSend =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAlwaysSend);
                    }

                    return cachedAlwaysSend;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SendDuringSpecifiedTimes 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SendDuringSpecifiedTimes
            {
                get
                {
                    if ((cachedSendDuringSpecifiedTimes == null))
                    {
                        cachedSendDuringSpecifiedTimes =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSendDuringSpecifiedTimes);
                    }

                    return cachedSendDuringSpecifiedTimes;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotifyDuringTheseTimes 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NotifyDuringTheseTimes
            {
                get
                {
                    if ((cachedNotifyDuringTheseTimes == null))
                    {
                        cachedNotifyDuringTheseTimes =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNotifyDuringTheseTimes);
                    }

                    return cachedNotifyDuringTheseTimes;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AddToolStripItem
            {
                get
                {
                    if ((cachedAddToolStripItem == null))
                    {
                        cachedAddToolStripItem =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAddToolStripItem);
                    }

                    return cachedAddToolStripItem;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EditToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string EditToolStripItem
            {
                get
                {
                    if ((cachedEditToolStripItem == null))
                    {
                        cachedEditToolStripItem =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEditToolStripItem);
                    }

                    return cachedEditToolStripItem;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RemoveToolStripItem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string RemoveToolStripItem
            {
                get
                {
                    if ((cachedRemoveToolStripItem == null))
                    {
                        cachedRemoveToolStripItem =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRemoveToolStripItem);
                    }

                    return cachedRemoveToolStripItem;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instructions 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Instructions
            {
                get
                {
                    if ((cachedInstructions == null))
                    {
                        cachedInstructions =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceInstructions);
                    }

                    return cachedInstructions;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NavigationLinkSchedule
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 22-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkSchedule
            {
                get
                {
                    if ((cachedNavigationLinkSchedule == null))
                    {
                        cachedNavigationLinkSchedule =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNavigationLinkSchedule);
                    }

                    return cachedNavigationLinkSchedule;
                }
            }

            #endregion Properties
        }

        #endregion Strings

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for SchedulesListToolStrip
            /// </summary>
            public const string SchedulesListToolStrip = "toolStrip";

            /// <summary>
            /// Control ID for SchedulesListView
            /// </summary>
            public const string SchedulesListView = "listView";

            /// <summary>
            /// Control ID for AlwaysSendRadioButton
            /// </summary>
            public const string AlwaysSendRadioButton = "scheduleOff";

            /// <summary>
            /// Control ID for SendDuringSpecifiedTimesRadioButton
            /// </summary>
            public const string SendDuringSpecifiedTimesRadioButton = "scheduleOn";
        }
        #endregion
    }
}
