// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateNotificationDeviceWizardScheduleWindow.cs">
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
//  [KellyMor]  21-Apr-06   Fixed issue in Init method
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
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
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
    
    #region Interface Definition - ICreateNotificationDeviceWizardScheduleWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateNotificationDeviceWizardScheduleWindowControls, for CreateNotificationDeviceWizardScheduleWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateNotificationDeviceWizardScheduleWindowControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access ChannelStaticControl
        /// </summary>
        StaticControl ChannelStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScheduleStaticControl
        /// </summary>
        StaticControl ScheduleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
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
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExclusionPeriodsListView
        /// </summary>
        ListView ExclusionPeriodsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExclusionPeriodsStaticControl
        /// </summary>
        StaticControl ExclusionPeriodsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStrip1_2
        /// </summary>
        Toolbar ToolStrip1_2
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
        /// Read-only property to access ScheduledPeriodsStaticControl
        /// </summary>
        StaticControl ScheduledPeriodsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl
        /// </summary>
        StaticControl SetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScheduleStaticControl2
        /// </summary>
        StaticControl ScheduleStaticControl2
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Create Notification Device wizard
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateNotificationDeviceWizardScheduleWindow : Window, ICreateNotificationDeviceWizardScheduleWindowControls
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
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ChannelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChannelStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OnlySendNotificationDuringTheSpecifiedTimesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedOnlySendNotificationDuringTheSpecifiedTimesRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AlwaysSendNotificationsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAlwaysSendNotificationsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to ExclusionPeriodsListView of type ListView
        /// </summary>
        private ListView cachedExclusionPeriodsListView;
        
        /// <summary>
        /// Cache to hold a reference to ExclusionPeriodsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExclusionPeriodsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1_2 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1_2;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeSchedulesListView of type ListView
        /// </summary>
        private ListView cachedExcludeSchedulesListView;
        
        /// <summary>
        /// Cache to hold a reference to ScheduledPeriodsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScheduledPeriodsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScheduleStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedScheduleStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of CreateNotificationDeviceWizardScheduleWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateNotificationDeviceWizardScheduleWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.OnlySendNotificationDuringTheSpecifiedTimesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.OnlySendNotificationDuringTheSpecifiedTimes;
                }
                
                if ((this.Controls.AlwaysSendNotificationsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.AlwaysSendNotifications;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.OnlySendNotificationDuringTheSpecifiedTimes))
                {
                    this.Controls.OnlySendNotificationDuringTheSpecifiedTimesRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.AlwaysSendNotifications))
                    {
                        this.Controls.AlwaysSendNotificationsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICreateNotificationDeviceWizardScheduleWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateNotificationDeviceWizardScheduleWindowControls Controls
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
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationDeviceWizardScheduleWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationDeviceWizardScheduleWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationDeviceWizardScheduleWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
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
        Button ICreateNotificationDeviceWizardScheduleWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardScheduleWindowControls.ChannelStaticControl
        {
            get
            {
                if ((this.cachedChannelStaticControl == null))
                {
                    this.cachedChannelStaticControl = new StaticControl(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.ChannelStaticControl);
                }
                return this.cachedChannelStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardScheduleWindowControls.ScheduleStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedScheduleStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedScheduleStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardScheduleWindowControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
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
        RadioButton ICreateNotificationDeviceWizardScheduleWindowControls.OnlySendNotificationDuringTheSpecifiedTimesRadioButton
        {
            get
            {
                if ((this.cachedOnlySendNotificationDuringTheSpecifiedTimesRadioButton == null))
                {
                    this.cachedOnlySendNotificationDuringTheSpecifiedTimesRadioButton = new RadioButton(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.OnlySendNotificationDuringTheSpecifiedTimesRadioButton);
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
        RadioButton ICreateNotificationDeviceWizardScheduleWindowControls.AlwaysSendNotificationsRadioButton
        {
            get
            {
                if ((this.cachedAlwaysSendNotificationsRadioButton == null))
                {
                    this.cachedAlwaysSendNotificationsRadioButton = new RadioButton(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.AlwaysSendNotificationsRadioButton);
                }
                return this.cachedAlwaysSendNotificationsRadioButton;
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
        Toolbar ICreateNotificationDeviceWizardScheduleWindowControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExclusionPeriodsListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ICreateNotificationDeviceWizardScheduleWindowControls.ExclusionPeriodsListView
        {
            get
            {
                if ((this.cachedExclusionPeriodsListView == null))
                {
                    this.cachedExclusionPeriodsListView = new ListView(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.ExclusionPeriodsListView);
                }
                return this.cachedExclusionPeriodsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExclusionPeriodsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardScheduleWindowControls.ExclusionPeriodsStaticControl
        {
            get
            {
                if ((this.cachedExclusionPeriodsStaticControl == null))
                {
                    this.cachedExclusionPeriodsStaticControl = new StaticControl(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.ExclusionPeriodsStaticControl);
                }
                return this.cachedExclusionPeriodsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1_2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ICreateNotificationDeviceWizardScheduleWindowControls.ToolStrip1_2
        {
            get
            {
                // The ID for this control (toolStrip) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedToolStrip1_2 == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedToolStrip1_2 = new Toolbar(wndTemp);
                }
                return this.cachedToolStrip1_2;
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
        ListView ICreateNotificationDeviceWizardScheduleWindowControls.ExcludeSchedulesListView
        {
            get
            {
                // The ID for this control (listView) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExcludeSchedulesListView == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedExcludeSchedulesListView = new ListView(wndTemp);
                }
                return this.cachedExcludeSchedulesListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScheduledPeriodsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardScheduleWindowControls.ScheduledPeriodsStaticControl
        {
            get
            {
                // The ID for this control (label) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedScheduledPeriodsStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedScheduledPeriodsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedScheduledPeriodsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardScheduleWindowControls.SetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl
        {
            get
            {
                if ((this.cachedSetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl == null))
                {
                    this.cachedSetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl = new StaticControl(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.SetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl);
                }
                return this.cachedSetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardScheduleWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScheduleStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardScheduleWindowControls.ScheduleStaticControl2
        {
            get
            {
                if ((this.cachedScheduleStaticControl2 == null))
                {
                    this.cachedScheduleStaticControl2 = new StaticControl(this, CreateNotificationDeviceWizardScheduleWindow.ControlIDs.ScheduleStaticControl2);
                }
                return this.cachedScheduleStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
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
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.ExactMatch,
                    ownerWindow.MainWindow,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                Common.Utilities.LogMessage(
                    "Looking for window with title:  '" +
                    Strings.WindowTitle +
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
                    Core.Common.Utilities.LogMessage("Failed to find window with title:  '" + Strings.WindowTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow.Extended.HWnd;
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
            private const string ResourceWindowTitle = ";Create Notification Device Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource;DeviceWizardTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Channel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChannel = ";Channel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.UI.EventView;Channel";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSchedule = ";Schedule;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SchedulerPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OnlySendNotificationDuringTheSpecifiedTimes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOnlySendNotificationDuringTheSpecifiedTimes = ";Only send notification during the specified times:;" + 
                "ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
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
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExclusionPeriods
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceExclusionPeriods = "E&xclusion periods:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1_2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1_2 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ScheduledPeriods
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceScheduledPeriods = "&Scheduled periods:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SetTheScheduleForReceivingNotificationsFromThisNotificationDevice
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSetTheScheduleForReceivingNotificationsFromThisNotificationDevice = ";Set the schedule for receiving notifications from this notification device.;" +
                "ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSchedulePage;titleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Schedule2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSchedule2 = ";Schedule;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SchedulerPage;$this.TabName";
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
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Channel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChannel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
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
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExclusionPeriods
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExclusionPeriods;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1_2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1_2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ScheduledPeriods
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScheduledPeriods;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SetTheScheduleForReceivingNotificationsFromThisNotificationDevice
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSetTheScheduleForReceivingNotificationsFromThisNotificationDevice;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Schedule2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSchedule2;
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    return cachedPrevious;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    return cachedNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }
                    return cachedFinish;
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
            /// Exposes access to the Channel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Channel
            {
                get
                {
                    if ((cachedChannel == null))
                    {
                        cachedChannel = CoreManager.MomConsole.GetIntlStr(ResourceChannel);
                    }
                    return cachedChannel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Schedule translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Schedule
            {
                get
                {
                    if ((cachedSchedule == null))
                    {
                        cachedSchedule = CoreManager.MomConsole.GetIntlStr(ResourceSchedule);
                    }
                    return cachedSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    return cachedGeneral;
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
            /// Exposes access to the ExclusionPeriods translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExclusionPeriods
            {
                get
                {
                    if ((cachedExclusionPeriods == null))
                    {
                        cachedExclusionPeriods = CoreManager.MomConsole.GetIntlStr(ResourceExclusionPeriods);
                    }
                    return cachedExclusionPeriods;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1_2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1_2
            {
                get
                {
                    if ((cachedToolStrip1_2 == null))
                    {
                        cachedToolStrip1_2 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1_2);
                    }
                    return cachedToolStrip1_2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ScheduledPeriods translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScheduledPeriods
            {
                get
                {
                    if ((cachedScheduledPeriods == null))
                    {
                        cachedScheduledPeriods = CoreManager.MomConsole.GetIntlStr(ResourceScheduledPeriods);
                    }
                    return cachedScheduledPeriods;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SetTheScheduleForReceivingNotificationsFromThisNotificationDevice translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SetTheScheduleForReceivingNotificationsFromThisNotificationDevice
            {
                get
                {
                    if ((cachedSetTheScheduleForReceivingNotificationsFromThisNotificationDevice == null))
                    {
                        cachedSetTheScheduleForReceivingNotificationsFromThisNotificationDevice = CoreManager.MomConsole.GetIntlStr(ResourceSetTheScheduleForReceivingNotificationsFromThisNotificationDevice);
                    }
                    return cachedSetTheScheduleForReceivingNotificationsFromThisNotificationDevice;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Schedule2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Schedule2
            {
                get
                {
                    if ((cachedSchedule2 == null))
                    {
                        cachedSchedule2 = CoreManager.MomConsole.GetIntlStr(ResourceSchedule2);
                    }
                    return cachedSchedule2;
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
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for ChannelStaticControl
            /// </summary>
            public const string ChannelStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ScheduleStaticControl
            /// </summary>
            public const string ScheduleStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for OnlySendNotificationDuringTheSpecifiedTimesRadioButton
            /// </summary>
            public const string OnlySendNotificationDuringTheSpecifiedTimesRadioButton = "scheduleOn";
            
            /// <summary>
            /// Control ID for AlwaysSendNotificationsRadioButton
            /// </summary>
            public const string AlwaysSendNotificationsRadioButton = "scheduleOff";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip";
            
            /// <summary>
            /// Control ID for ExclusionPeriodsListView
            /// </summary>
            public const string ExclusionPeriodsListView = "listView";
            
            /// <summary>
            /// Control ID for ExclusionPeriodsStaticControl
            /// </summary>
            public const string ExclusionPeriodsStaticControl = "label";
            
            /// <summary>
            /// Control ID for ToolStrip1_2
            /// </summary>
            public const string ToolStrip1_2 = "toolStrip";
            
            /// <summary>
            /// Control ID for ExcludeSchedulesListView
            /// </summary>
            public const string ExcludeSchedulesListView = "listView";
            
            /// <summary>
            /// Control ID for ScheduledPeriodsStaticControl
            /// </summary>
            public const string ScheduledPeriodsStaticControl = "label";
            
            /// <summary>
            /// Control ID for SetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl
            /// </summary>
            public const string SetTheScheduleForReceivingNotificationsFromThisNotificationDeviceStaticControl = "titleLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ScheduleStaticControl2
            /// </summary>
            public const string ScheduleStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
