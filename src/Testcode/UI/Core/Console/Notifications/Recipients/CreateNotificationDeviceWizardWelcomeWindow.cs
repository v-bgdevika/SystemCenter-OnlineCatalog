// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateNotificationDeviceWizardWelcomeWindow.cs">
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
    
    #region Interface Definition - ICreateNotificationDeviceWizardWelcomeWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateNotificationDeviceWizardWelcomeWindowControls, for CreateNotificationDeviceWizardWelcomeWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateNotificationDeviceWizardWelcomeWindowControls
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
        /// Read-only property to access ExcludeSchedulesTextBox
        /// </summary>
        TextBox ExcludeSchedulesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YourAddressForTheSelectedChannelStaticControl
        /// </summary>
        StaticControl YourAddressForTheSelectedChannelStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SchedulesToSendTextBox
        /// </summary>
        TextBox SchedulesToSendTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChannelDescriptionStaticControl
        /// </summary>
        StaticControl ChannelDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SchedulesToSendEditComboBox
        /// </summary>
        EditComboBox SchedulesToSendEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToTextBox
        /// </summary>
        TextBox ToTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotificationChannelStaticControl
        /// </summary>
        StaticControl NotificationChannelStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl
        /// </summary>
        StaticControl SelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl
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
        /// Read-only property to access ChannelStaticControl2
        /// </summary>
        StaticControl ChannelStaticControl2
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
    public class CreateNotificationDeviceWizardWelcomeWindow : Window, ICreateNotificationDeviceWizardWelcomeWindowControls
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
        /// Cache to hold a reference to ExcludeSchedulesTextBox of type TextBox
        /// </summary>
        private TextBox cachedExcludeSchedulesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to YourAddressForTheSelectedChannelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYourAddressForTheSelectedChannelStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SchedulesToSendTextBox of type TextBox
        /// </summary>
        private TextBox cachedSchedulesToSendTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ChannelDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChannelDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SchedulesToSendEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedSchedulesToSendEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ToTextBox of type TextBox
        /// </summary>
        private TextBox cachedToTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NotificationChannelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotificationChannelStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChannelStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedChannelStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of CreateNotificationDeviceWizardWelcomeWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateNotificationDeviceWizardWelcomeWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICreateNotificationDeviceWizardWelcomeWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateNotificationDeviceWizardWelcomeWindowControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ExcludeSchedules
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExcludeSchedulesText
        {
            get
            {
                return this.Controls.ExcludeSchedulesTextBox.Text;
            }
            
            set
            {
                this.Controls.ExcludeSchedulesTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SchedulesToSend
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SchedulesToSendText
        {
            get
            {
                return this.Controls.SchedulesToSendTextBox.Text;
            }
            
            set
            {
                this.Controls.SchedulesToSendTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SchedulesToSend2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SchedulesToSend2Text
        {
            get
            {
                return this.Controls.SchedulesToSendEditComboBox.Text;
            }
            
            set
            {
                this.Controls.SchedulesToSendEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control To
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ToText
        {
            get
            {
                return this.Controls.ToTextBox.Text;
            }
            
            set
            {
                this.Controls.ToTextBox.Text = value;
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
        Button ICreateNotificationDeviceWizardWelcomeWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.PreviousButton);
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
        Button ICreateNotificationDeviceWizardWelcomeWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.NextButton);
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
        Button ICreateNotificationDeviceWizardWelcomeWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.FinishButton);
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
        Button ICreateNotificationDeviceWizardWelcomeWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.CancelButton);
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
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.ChannelStaticControl
        {
            get
            {
                if ((this.cachedChannelStaticControl == null))
                {
                    this.cachedChannelStaticControl = new StaticControl(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.ChannelStaticControl);
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
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.ScheduleStaticControl
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
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.GeneralStaticControl
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
        ///  Exposes access to the ExcludeSchedulesTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationDeviceWizardWelcomeWindowControls.ExcludeSchedulesTextBox
        {
            get
            {
                if ((this.cachedExcludeSchedulesTextBox == null))
                {
                    this.cachedExcludeSchedulesTextBox = new TextBox(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.ExcludeSchedulesTextBox);
                }
                return this.cachedExcludeSchedulesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YourAddressForTheSelectedChannelStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.YourAddressForTheSelectedChannelStaticControl
        {
            get
            {
                if ((this.cachedYourAddressForTheSelectedChannelStaticControl == null))
                {
                    this.cachedYourAddressForTheSelectedChannelStaticControl = new StaticControl(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.YourAddressForTheSelectedChannelStaticControl);
                }
                return this.cachedYourAddressForTheSelectedChannelStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SchedulesToSendTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationDeviceWizardWelcomeWindowControls.SchedulesToSendTextBox
        {
            get
            {
                if ((this.cachedSchedulesToSendTextBox == null))
                {
                    this.cachedSchedulesToSendTextBox = new TextBox(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.SchedulesToSendTextBox);
                }
                return this.cachedSchedulesToSendTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.ChannelDescriptionStaticControl
        {
            get
            {
                if ((this.cachedChannelDescriptionStaticControl == null))
                {
                    this.cachedChannelDescriptionStaticControl = new StaticControl(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.ChannelDescriptionStaticControl);
                }
                return this.cachedChannelDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SchedulesToSendEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ICreateNotificationDeviceWizardWelcomeWindowControls.SchedulesToSendEditComboBox
        {
            get
            {
                if ((this.cachedSchedulesToSendEditComboBox == null))
                {
                    this.cachedSchedulesToSendEditComboBox = new EditComboBox(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.SchedulesToSendEditComboBox);
                }
                return this.cachedSchedulesToSendEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationDeviceWizardWelcomeWindowControls.ToTextBox
        {
            get
            {
                if ((this.cachedToTextBox == null))
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
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedToTextBox = new TextBox(wndTemp);
                }
                return this.cachedToTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotificationChannelStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.NotificationChannelStaticControl
        {
            get
            {
                if ((this.cachedNotificationChannelStaticControl == null))
                {
                    this.cachedNotificationChannelStaticControl = new StaticControl(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.NotificationChannelStaticControl);
                }
                return this.cachedNotificationChannelStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.SelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl
        {
            get
            {
                if ((this.cachedSelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl == null))
                {
                    this.cachedSelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl = new StaticControl(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.SelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl);
                }
                return this.cachedSelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl;
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
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChannelStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationDeviceWizardWelcomeWindowControls.ChannelStaticControl2
        {
            get
            {
                if ((this.cachedChannelStaticControl2 == null))
                {
                    this.cachedChannelStaticControl2 = new StaticControl(this, CreateNotificationDeviceWizardWelcomeWindow.ControlIDs.ChannelStaticControl2);
                }
                return this.cachedChannelStaticControl2;
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
                    StringMatchSyntax.WildCard);
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
            private const string ResourceChannel = ";Channel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.UI.EventView;Channel";
            
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
            /// Contains resource string for:  YourAddressForTheSelectedChannel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYourAddressForTheSelectedChannel = ";Your a&ddress for the selected channel:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceChannelP" +
                "age;addressLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChannelDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChannelDescription = ";Channel description:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceChannelPage;descriptionLabe" +
                "l.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotificationChannel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotificationChannel = ";N&otification channel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceChannelPage;channelLabel.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheNotificationChannelAndEnterYourAddressForThatChannel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheNotificationChannelAndEnterYourAddressForThatChannel = ";Select the notification channel and enter your address for that channel;ManagedS" +
                "tring;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceChannelPage;titleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Channel2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChannel2 = ";Channel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.UI.EventView;Channel";
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
            /// Caches the translated resource string for:  YourAddressForTheSelectedChannel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYourAddressForTheSelectedChannel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChannelDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChannelDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotificationChannel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotificationChannel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheNotificationChannelAndEnterYourAddressForThatChannel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheNotificationChannelAndEnterYourAddressForThatChannel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Channel2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChannel2;
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
            /// Exposes access to the YourAddressForTheSelectedChannel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YourAddressForTheSelectedChannel
            {
                get
                {
                    if ((cachedYourAddressForTheSelectedChannel == null))
                    {
                        cachedYourAddressForTheSelectedChannel = CoreManager.MomConsole.GetIntlStr(ResourceYourAddressForTheSelectedChannel);
                    }
                    return cachedYourAddressForTheSelectedChannel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChannelDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChannelDescription
            {
                get
                {
                    if ((cachedChannelDescription == null))
                    {
                        cachedChannelDescription = CoreManager.MomConsole.GetIntlStr(ResourceChannelDescription);
                    }
                    return cachedChannelDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotificationChannel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotificationChannel
            {
                get
                {
                    if ((cachedNotificationChannel == null))
                    {
                        cachedNotificationChannel = CoreManager.MomConsole.GetIntlStr(ResourceNotificationChannel);
                    }
                    return cachedNotificationChannel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheNotificationChannelAndEnterYourAddressForThatChannel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheNotificationChannelAndEnterYourAddressForThatChannel
            {
                get
                {
                    if ((cachedSelectTheNotificationChannelAndEnterYourAddressForThatChannel == null))
                    {
                        cachedSelectTheNotificationChannelAndEnterYourAddressForThatChannel = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheNotificationChannelAndEnterYourAddressForThatChannel);
                    }
                    return cachedSelectTheNotificationChannelAndEnterYourAddressForThatChannel;
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
            /// Exposes access to the Channel2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Channel2
            {
                get
                {
                    if ((cachedChannel2 == null))
                    {
                        cachedChannel2 = CoreManager.MomConsole.GetIntlStr(ResourceChannel2);
                    }
                    return cachedChannel2;
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
            /// Control ID for ExcludeSchedulesTextBox
            /// </summary>
            public const string ExcludeSchedulesTextBox = "addressBox";
            
            /// <summary>
            /// Control ID for YourAddressForTheSelectedChannelStaticControl
            /// </summary>
            public const string YourAddressForTheSelectedChannelStaticControl = "addressLabel";
            
            /// <summary>
            /// Control ID for SchedulesToSendTextBox
            /// </summary>
            public const string SchedulesToSendTextBox = "descriptionBox";
            
            /// <summary>
            /// Control ID for ChannelDescriptionStaticControl
            /// </summary>
            public const string ChannelDescriptionStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for SchedulesToSendEditComboBox
            /// </summary>
            public const string SchedulesToSendEditComboBox = "channelList";
            
            /// <summary>
            /// Control ID for NotificationChannelStaticControl
            /// </summary>
            public const string NotificationChannelStaticControl = "channelLabel";
            
            /// <summary>
            /// Control ID for SelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl
            /// </summary>
            public const string SelectTheNotificationChannelAndEnterYourAddressForThatChannelStaticControl = "titleLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ChannelStaticControl2
            /// </summary>
            public const string ChannelStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
