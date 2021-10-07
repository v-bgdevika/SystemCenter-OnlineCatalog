// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateNotificationSubscriptionWizardFormatsWindow.cs">
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
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Notifications.Subscriptions
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
        /// UseThisCustomEncoding = 0
        /// </summary>
        UseThisCustomEncoding = 0,
        
        /// <summary>
        /// UseTheDefaultEncoding = 1
        /// </summary>
        UseTheDefaultEncoding = 1,
    }
    #endregion
    
    #region Radio Group Enumeration - UseThisCustomEmailFormat

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group UseThisCustomEmailFormat
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum UseThisCustomEmailFormat
    {
        /// <summary>
        /// UseTheDefaultEmailFormat = 0
        /// </summary>
        UseTheDefaultEmailFormat = 0,
        
        /// <summary>
        /// UseThisCustomEmailFormat = 1
        /// </summary>
        UseThisCustomEmailFormat = 1,
    }
    #endregion
    
    #region Radio Group Enumeration - IMFormat

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group IMFormat
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum IMFormat
    {
        /// <summary>
        /// UseTheDefaultIMFormat = 0
        /// </summary>
        UseTheDefaultIMFormat = 0,
        
        /// <summary>
        /// UseThisCustomlIMFormat = 1
        /// </summary>
        UseThisCustomlIMFormat = 1,
    }
    #endregion
    
    #region Radio Group Enumeration - SMSFormat

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group SMSFormat
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum SMSFormat
    {
        /// <summary>
        /// UseTheDefaultSMSFormat = 0
        /// </summary>
        UseTheDefaultSMSFormat = 0,
        
        /// <summary>
        /// UseThisCustomSMSFormat = 1
        /// </summary>
        UseThisCustomSMSFormat = 1,
    }
    #endregion
    
    #region Interface Definition - ICreateNotificationSubscriptionWizardFormatsWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateNotificationSubscriptionWizardFormatsWindowControls, for CreateNotificationSubscriptionWizardFormatsWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateNotificationSubscriptionWizardFormatsWindowControls
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
        /// Read-only property to access IntroductionStaticControl
        /// </summary>
        StaticControl IntroductionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserRoleFilterStaticControl
        /// </summary>
        StaticControl UserRoleFilterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupsStaticControl
        /// </summary>
        StaticControl GroupsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClassesStaticControl
        /// </summary>
        StaticControl ClassesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertCriteriaStaticControl
        /// </summary>
        StaticControl AlertCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertAgingStaticControl
        /// </summary>
        StaticControl AlertAgingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FormatsStaticControl
        /// </summary>
        StaticControl FormatsStaticControl
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
        /// Read-only property to access PlaceholderButton
        /// </summary>
        Button PlaceholderButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PlaceholderButton2
        /// </summary>
        Button PlaceholderButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PlaceholderButton3
        /// </summary>
        Button PlaceholderButton3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PlaceholderButton4
        /// </summary>
        Button PlaceholderButton4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubjectTextBox
        /// </summary>
        TextBox SubjectTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubjectStaticControl
        /// </summary>
        StaticControl SubjectStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SMSFormatStaticControl
        /// </summary>
        StaticControl SMSFormatStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ANDAnyCheckedCategoryTextBox
        /// </summary>
        TextBox ANDAnyCheckedCategoryTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MessageStaticControl
        /// </summary>
        StaticControl MessageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YourAddressForTheSelectedChannelTextBox
        /// </summary>
        TextBox YourAddressForTheSelectedChannelTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MessageStaticControl2
        /// </summary>
        StaticControl MessageStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox
        /// </summary>
        TextBox RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubjectStaticControl2
        /// </summary>
        StaticControl SubjectStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IMFormatStaticControl
        /// </summary>
        StaticControl IMFormatStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EmailFormatStaticControl
        /// </summary>
        StaticControl EmailFormatStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToEditComboBox
        /// </summary>
        EditComboBox ToEditComboBox
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
        /// Read-only property to access NotificationChannelTextBox
        /// </summary>
        TextBox NotificationChannelTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseThisCustomEncodingRadioButton
        /// </summary>
        RadioButton UseThisCustomEncodingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseTheDefaultEncodingRadioButton
        /// </summary>
        RadioButton UseTheDefaultEncodingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EncodingStaticControl
        /// </summary>
        StaticControl EncodingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureTheFormatsForNotificationsStaticControl
        /// </summary>
        StaticControl ConfigureTheFormatsForNotificationsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseTheDefaultEmailFormatRadioButton
        /// </summary>
        RadioButton UseTheDefaultEmailFormatRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseThisCustomEmailFormatRadioButton
        /// </summary>
        RadioButton UseThisCustomEmailFormatRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseTheDefaultIMFormatRadioButton
        /// </summary>
        RadioButton UseTheDefaultIMFormatRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseThisCustomlIMFormatRadioButton
        /// </summary>
        RadioButton UseThisCustomlIMFormatRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseTheDefaultSMSFormatRadioButton
        /// </summary>
        RadioButton UseTheDefaultSMSFormatRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseThisCustomSMSFormatRadioButton
        /// </summary>
        RadioButton UseThisCustomSMSFormatRadioButton
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
        /// Read-only property to access FormatsStaticControl2
        /// </summary>
        StaticControl FormatsStaticControl2
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Create Notification Subscription wizard
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateNotificationSubscriptionWizardFormatsWindow : Window, ICreateNotificationSubscriptionWizardFormatsWindowControls
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
        /// Cache to hold a reference to IntroductionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserRoleFilterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUserRoleFilterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGroupsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClassesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedClassesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertAgingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertAgingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FormatsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFormatsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PlaceholderButton of type Button
        /// </summary>
        private Button cachedPlaceholderButton;
        
        /// <summary>
        /// Cache to hold a reference to PlaceholderButton2 of type Button
        /// </summary>
        private Button cachedPlaceholderButton2;
        
        /// <summary>
        /// Cache to hold a reference to PlaceholderButton3 of type Button
        /// </summary>
        private Button cachedPlaceholderButton3;
        
        /// <summary>
        /// Cache to hold a reference to PlaceholderButton4 of type Button
        /// </summary>
        private Button cachedPlaceholderButton4;
        
        /// <summary>
        /// Cache to hold a reference to SubjectTextBox of type TextBox
        /// </summary>
        private TextBox cachedSubjectTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SubjectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubjectStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SMSFormatStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSMSFormatStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ANDAnyCheckedCategoryTextBox of type TextBox
        /// </summary>
        private TextBox cachedANDAnyCheckedCategoryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to MessageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMessageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YourAddressForTheSelectedChannelTextBox of type TextBox
        /// </summary>
        private TextBox cachedYourAddressForTheSelectedChannelTextBox;
        
        /// <summary>
        /// Cache to hold a reference to MessageStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedMessageStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox of type TextBox
        /// </summary>
        private TextBox cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SubjectStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedSubjectStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to IMFormatStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIMFormatStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EmailFormatStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEmailFormatStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedToEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ToTextBox of type TextBox
        /// </summary>
        private TextBox cachedToTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NotificationChannelTextBox of type TextBox
        /// </summary>
        private TextBox cachedNotificationChannelTextBox;
        
        /// <summary>
        /// Cache to hold a reference to UseThisCustomEncodingRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseThisCustomEncodingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseTheDefaultEncodingRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseTheDefaultEncodingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to EncodingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEncodingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureTheFormatsForNotificationsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureTheFormatsForNotificationsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseTheDefaultEmailFormatRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseTheDefaultEmailFormatRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseThisCustomEmailFormatRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseThisCustomEmailFormatRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseTheDefaultIMFormatRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseTheDefaultIMFormatRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseThisCustomlIMFormatRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseThisCustomlIMFormatRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseTheDefaultSMSFormatRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseTheDefaultSMSFormatRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseThisCustomSMSFormatRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseThisCustomSMSFormatRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FormatsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedFormatsStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of CreateNotificationSubscriptionWizardFormatsWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateNotificationSubscriptionWizardFormatsWindow(App ownerWindow) : 
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
                if ((this.Controls.UseThisCustomEncodingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.UseThisCustomEncoding;
                }
                
                if ((this.Controls.UseTheDefaultEncodingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.UseTheDefaultEncoding;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.UseThisCustomEncoding))
                {
                    this.Controls.UseThisCustomEncodingRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.UseTheDefaultEncoding))
                    {
                        this.Controls.UseTheDefaultEncodingRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group UseThisCustomEmailFormat
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual UseThisCustomEmailFormat UseThisCustomEmailFormat
        {
            get
            {
                if ((this.Controls.UseTheDefaultEmailFormatRadioButton.ButtonState == ButtonState.Checked))
                {
                    return UseThisCustomEmailFormat.UseTheDefaultEmailFormat;
                }
                
                if ((this.Controls.UseThisCustomEmailFormatRadioButton.ButtonState == ButtonState.Checked))
                {
                    return UseThisCustomEmailFormat.UseThisCustomEmailFormat;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == UseThisCustomEmailFormat.UseTheDefaultEmailFormat))
                {
                    this.Controls.UseTheDefaultEmailFormatRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == UseThisCustomEmailFormat.UseThisCustomEmailFormat))
                    {
                        this.Controls.UseThisCustomEmailFormatRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group IMFormat
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMFormat IMFormat
        {
            get
            {
                if ((this.Controls.UseTheDefaultIMFormatRadioButton.ButtonState == ButtonState.Checked))
                {
                    return IMFormat.UseTheDefaultIMFormat;
                }
                
                if ((this.Controls.UseThisCustomlIMFormatRadioButton.ButtonState == ButtonState.Checked))
                {
                    return IMFormat.UseThisCustomlIMFormat;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == IMFormat.UseTheDefaultIMFormat))
                {
                    this.Controls.UseTheDefaultIMFormatRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == IMFormat.UseThisCustomlIMFormat))
                    {
                        this.Controls.UseThisCustomlIMFormatRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group SMSFormat
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual SMSFormat SMSFormat
        {
            get
            {
                if ((this.Controls.UseTheDefaultSMSFormatRadioButton.ButtonState == ButtonState.Checked))
                {
                    return SMSFormat.UseTheDefaultSMSFormat;
                }
                
                if ((this.Controls.UseThisCustomSMSFormatRadioButton.ButtonState == ButtonState.Checked))
                {
                    return SMSFormat.UseThisCustomSMSFormat;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == SMSFormat.UseTheDefaultSMSFormat))
                {
                    this.Controls.UseTheDefaultSMSFormatRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == SMSFormat.UseThisCustomSMSFormat))
                    {
                        this.Controls.UseThisCustomSMSFormatRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICreateNotificationSubscriptionWizardFormatsWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateNotificationSubscriptionWizardFormatsWindowControls Controls
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
        ///  Routine to set/get the text in control Subject
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SubjectText
        {
            get
            {
                return this.Controls.SubjectTextBox.Text;
            }
            
            set
            {
                this.Controls.SubjectTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ANDAnyCheckedCategory
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ANDAnyCheckedCategoryText
        {
            get
            {
                return this.Controls.ANDAnyCheckedCategoryTextBox.Text;
            }
            
            set
            {
                this.Controls.ANDAnyCheckedCategoryTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control YourAddressForTheSelectedChannel
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string YourAddressForTheSelectedChannelText
        {
            get
            {
                return this.Controls.YourAddressForTheSelectedChannelTextBox.Text;
            }
            
            set
            {
                this.Controls.YourAddressForTheSelectedChannelTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageText
        {
            get
            {
                return this.Controls.RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox.Text;
            }
            
            set
            {
                this.Controls.RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox.Text = value;
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
                return this.Controls.ToEditComboBox.Text;
            }
            
            set
            {
                this.Controls.ToEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control To2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string To2Text
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NotificationChannel
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NotificationChannelText
        {
            get
            {
                return this.Controls.NotificationChannelTextBox.Text;
            }
            
            set
            {
                this.Controls.NotificationChannelTextBox.Text = value;
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
        Button ICreateNotificationSubscriptionWizardFormatsWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.PreviousButton);
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
        Button ICreateNotificationSubscriptionWizardFormatsWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.NextButton);
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
        Button ICreateNotificationSubscriptionWizardFormatsWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.FinishButton);
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
        Button ICreateNotificationSubscriptionWizardFormatsWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserRoleFilterStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.UserRoleFilterStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedUserRoleFilterStaticControl == null))
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
                    this.cachedUserRoleFilterStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedUserRoleFilterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.GroupsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGroupsStaticControl == null))
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
                    this.cachedGroupsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGroupsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClassesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.ClassesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedClassesStaticControl == null))
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
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedClassesStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedClassesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.AlertCriteriaStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAlertCriteriaStaticControl == null))
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
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedAlertCriteriaStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAlertCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertAgingStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.AlertAgingStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAlertAgingStaticControl == null))
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
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedAlertAgingStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAlertAgingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormatsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.FormatsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedFormatsStaticControl == null))
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
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedFormatsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedFormatsStaticControl;
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
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.GeneralStaticControl
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
                    for (i = 0; (i <= 6); i = (i + 1))
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
        ///  Exposes access to the PlaceholderButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardFormatsWindowControls.PlaceholderButton
        {
            get
            {
                if ((this.cachedPlaceholderButton == null))
                {
                    this.cachedPlaceholderButton = new Button(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.PlaceholderButton);
                }
                return this.cachedPlaceholderButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PlaceholderButton2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardFormatsWindowControls.PlaceholderButton2
        {
            get
            {
                if ((this.cachedPlaceholderButton2 == null))
                {
                    this.cachedPlaceholderButton2 = new Button(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.PlaceholderButton2);
                }
                return this.cachedPlaceholderButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PlaceholderButton3 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardFormatsWindowControls.PlaceholderButton3
        {
            get
            {
                if ((this.cachedPlaceholderButton3 == null))
                {
                    this.cachedPlaceholderButton3 = new Button(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.PlaceholderButton3);
                }
                return this.cachedPlaceholderButton3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PlaceholderButton4 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardFormatsWindowControls.PlaceholderButton4
        {
            get
            {
                if ((this.cachedPlaceholderButton4 == null))
                {
                    this.cachedPlaceholderButton4 = new Button(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.PlaceholderButton4);
                }
                return this.cachedPlaceholderButton4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubjectTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationSubscriptionWizardFormatsWindowControls.SubjectTextBox
        {
            get
            {
                if ((this.cachedSubjectTextBox == null))
                {
                    this.cachedSubjectTextBox = new TextBox(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.SubjectTextBox);
                }
                return this.cachedSubjectTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubjectStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.SubjectStaticControl
        {
            get
            {
                if ((this.cachedSubjectStaticControl == null))
                {
                    this.cachedSubjectStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.SubjectStaticControl);
                }
                return this.cachedSubjectStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SMSFormatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.SMSFormatStaticControl
        {
            get
            {
                if ((this.cachedSMSFormatStaticControl == null))
                {
                    this.cachedSMSFormatStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.SMSFormatStaticControl);
                }
                return this.cachedSMSFormatStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ANDAnyCheckedCategoryTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationSubscriptionWizardFormatsWindowControls.ANDAnyCheckedCategoryTextBox
        {
            get
            {
                if ((this.cachedANDAnyCheckedCategoryTextBox == null))
                {
                    this.cachedANDAnyCheckedCategoryTextBox = new TextBox(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.ANDAnyCheckedCategoryTextBox);
                }
                return this.cachedANDAnyCheckedCategoryTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MessageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.MessageStaticControl
        {
            get
            {
                if ((this.cachedMessageStaticControl == null))
                {
                    this.cachedMessageStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.MessageStaticControl);
                }
                return this.cachedMessageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YourAddressForTheSelectedChannelTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationSubscriptionWizardFormatsWindowControls.YourAddressForTheSelectedChannelTextBox
        {
            get
            {
                if ((this.cachedYourAddressForTheSelectedChannelTextBox == null))
                {
                    this.cachedYourAddressForTheSelectedChannelTextBox = new TextBox(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.YourAddressForTheSelectedChannelTextBox);
                }
                return this.cachedYourAddressForTheSelectedChannelTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MessageStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.MessageStaticControl2
        {
            get
            {
                if ((this.cachedMessageStaticControl2 == null))
                {
                    this.cachedMessageStaticControl2 = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.MessageStaticControl2);
                }
                return this.cachedMessageStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationSubscriptionWizardFormatsWindowControls.RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox
        {
            get
            {
                if ((this.cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox == null))
                {
                    this.cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox = new TextBox(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox);
                }
                return this.cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubjectStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.SubjectStaticControl2
        {
            get
            {
                if ((this.cachedSubjectStaticControl2 == null))
                {
                    this.cachedSubjectStaticControl2 = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.SubjectStaticControl2);
                }
                return this.cachedSubjectStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IMFormatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.IMFormatStaticControl
        {
            get
            {
                if ((this.cachedIMFormatStaticControl == null))
                {
                    this.cachedIMFormatStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.IMFormatStaticControl);
                }
                return this.cachedIMFormatStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EmailFormatStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.EmailFormatStaticControl
        {
            get
            {
                if ((this.cachedEmailFormatStaticControl == null))
                {
                    this.cachedEmailFormatStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.EmailFormatStaticControl);
                }
                return this.cachedEmailFormatStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ICreateNotificationSubscriptionWizardFormatsWindowControls.ToEditComboBox
        {
            get
            {
                if ((this.cachedToEditComboBox == null))
                {
                    this.cachedToEditComboBox = new EditComboBox(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.ToEditComboBox);
                }
                return this.cachedToEditComboBox;
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
        TextBox ICreateNotificationSubscriptionWizardFormatsWindowControls.ToTextBox
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
                    for (i = 0; (i <= 14); i = (i + 1))
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
        ///  Exposes access to the NotificationChannelTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationSubscriptionWizardFormatsWindowControls.NotificationChannelTextBox
        {
            get
            {
                if ((this.cachedNotificationChannelTextBox == null))
                {
                    this.cachedNotificationChannelTextBox = new TextBox(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.NotificationChannelTextBox);
                }
                return this.cachedNotificationChannelTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseThisCustomEncodingRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardFormatsWindowControls.UseThisCustomEncodingRadioButton
        {
            get
            {
                if ((this.cachedUseThisCustomEncodingRadioButton == null))
                {
                    this.cachedUseThisCustomEncodingRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.UseThisCustomEncodingRadioButton);
                }
                return this.cachedUseThisCustomEncodingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseTheDefaultEncodingRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardFormatsWindowControls.UseTheDefaultEncodingRadioButton
        {
            get
            {
                if ((this.cachedUseTheDefaultEncodingRadioButton == null))
                {
                    this.cachedUseTheDefaultEncodingRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.UseTheDefaultEncodingRadioButton);
                }
                return this.cachedUseTheDefaultEncodingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EncodingStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.EncodingStaticControl
        {
            get
            {
                if ((this.cachedEncodingStaticControl == null))
                {
                    this.cachedEncodingStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.EncodingStaticControl);
                }
                return this.cachedEncodingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureTheFormatsForNotificationsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.ConfigureTheFormatsForNotificationsStaticControl
        {
            get
            {
                if ((this.cachedConfigureTheFormatsForNotificationsStaticControl == null))
                {
                    this.cachedConfigureTheFormatsForNotificationsStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.ConfigureTheFormatsForNotificationsStaticControl);
                }
                return this.cachedConfigureTheFormatsForNotificationsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseTheDefaultEmailFormatRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardFormatsWindowControls.UseTheDefaultEmailFormatRadioButton
        {
            get
            {
                if ((this.cachedUseTheDefaultEmailFormatRadioButton == null))
                {
                    this.cachedUseTheDefaultEmailFormatRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.UseTheDefaultEmailFormatRadioButton);
                }
                return this.cachedUseTheDefaultEmailFormatRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseThisCustomEmailFormatRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardFormatsWindowControls.UseThisCustomEmailFormatRadioButton
        {
            get
            {
                if ((this.cachedUseThisCustomEmailFormatRadioButton == null))
                {
                    this.cachedUseThisCustomEmailFormatRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.UseThisCustomEmailFormatRadioButton);
                }
                return this.cachedUseThisCustomEmailFormatRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseTheDefaultIMFormatRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardFormatsWindowControls.UseTheDefaultIMFormatRadioButton
        {
            get
            {
                if ((this.cachedUseTheDefaultIMFormatRadioButton == null))
                {
                    this.cachedUseTheDefaultIMFormatRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.UseTheDefaultIMFormatRadioButton);
                }
                return this.cachedUseTheDefaultIMFormatRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseThisCustomlIMFormatRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardFormatsWindowControls.UseThisCustomlIMFormatRadioButton
        {
            get
            {
                if ((this.cachedUseThisCustomlIMFormatRadioButton == null))
                {
                    this.cachedUseThisCustomlIMFormatRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.UseThisCustomlIMFormatRadioButton);
                }
                return this.cachedUseThisCustomlIMFormatRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseTheDefaultSMSFormatRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardFormatsWindowControls.UseTheDefaultSMSFormatRadioButton
        {
            get
            {
                if ((this.cachedUseTheDefaultSMSFormatRadioButton == null))
                {
                    this.cachedUseTheDefaultSMSFormatRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.UseTheDefaultSMSFormatRadioButton);
                }
                return this.cachedUseTheDefaultSMSFormatRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseThisCustomSMSFormatRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardFormatsWindowControls.UseThisCustomSMSFormatRadioButton
        {
            get
            {
                if ((this.cachedUseThisCustomSMSFormatRadioButton == null))
                {
                    this.cachedUseThisCustomSMSFormatRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.UseThisCustomSMSFormatRadioButton);
                }
                return this.cachedUseThisCustomSMSFormatRadioButton;
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
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormatsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardFormatsWindowControls.FormatsStaticControl2
        {
            get
            {
                if ((this.cachedFormatsStaticControl2 == null))
                {
                    this.cachedFormatsStaticControl2 = new StaticControl(this, CreateNotificationSubscriptionWizardFormatsWindow.ControlIDs.FormatsStaticControl2);
                }
                return this.cachedFormatsStaticControl2;
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Placeholder
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPlaceholder()
        {
            this.Controls.PlaceholderButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Placeholder2
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPlaceholder2()
        {
            this.Controls.PlaceholderButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Placeholder3
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPlaceholder3()
        {
            this.Controls.PlaceholderButton3.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Placeholder4
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPlaceholder4()
        {
            this.Controls.PlaceholderButton4.Click();
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
                    Core.Common.Utilities.LogMessage("Failed to find the General step of wizard!");
                 
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
            private const string ResourceWindowTitle = ";Create Notification Subscription Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource;SubscriptionWizardTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UserRoleFilter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserRoleFilter = ";User Role Filter;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionUserRolePage;$this.TabNam" +
                "e";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Groups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroups = ";Groups;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources;GroupsViewName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Classes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClasses = ";Classes;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertCriteria = ";Alert Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertAging
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertAging = ";Alert Aging;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertAgingPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Formats
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormats = ";Formats;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Placeholder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlaceholder = ";Placeholder;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;emailSubjectPlaceholder.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Placeholder2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlaceholder2 = ";Placeholder;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;emailSubjectPlaceholder.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Placeholder3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlaceholder3 = ";Placeholder;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;emailSubjectPlaceholder.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Placeholder4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlaceholder4 = ";Placeholder;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;emailSubjectPlaceholder.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Subject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSubject = ";Su&bject:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;smsSubjectLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SMSFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSMSFormat = ";SMS format:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;smsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Message
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMessage = ";Me&ssage:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;imMessageLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Message2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMessage2 = ";&Message:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;emailMessageLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Subject2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSubject2 = ";S&ubject:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;emailSubjectLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IMFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIMFormat = ";IM format;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;imLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EmailFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEmailFormat = ";Email format:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;emailLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseThisCustomEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseThisCustomEncoding = ";Use this custom encoding;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;customEncoding.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseTheDefaultEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseTheDefaultEncoding = ";Use the default encoding;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;defaultEncoding.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEncoding = ";Encoding:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ImNotification;encodingLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureTheFormatsForNotifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureTheFormatsForNotifications = ";Configure the formats for notifications;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;titleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseTheDefaultEmailFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseTheDefaultEmailFormat = ";Use the default email format;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;defaultEmail.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseThisCustomEmailFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseThisCustomEmailFormat = ";Use this custom email format;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;customEmail.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseTheDefaultIMFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseTheDefaultIMFormat = ";Use the default IM format;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;defaultIMFormat.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseThisCustomlIMFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseThisCustomlIMFormat = ";Use this customl IM format;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;customIMFormat.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseTheDefaultSMSFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseTheDefaultSMSFormat = ";Use the default SMS format;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;defaultSMSFormat.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseThisCustomSMSFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseThisCustomSMSFormat = ";Use this custom SMS format;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;customSMSFormat.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Formats2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormats2 = ";Formats;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionFormatsPage;$this.TabName";
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
            /// Caches the translated resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UserRoleFilter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserRoleFilter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Groups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroups;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Classes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClasses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertAging
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertAging;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Formats
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFormats;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Placeholder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlaceholder;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Placeholder2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlaceholder2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Placeholder3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlaceholder3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Placeholder4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlaceholder4;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Subject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubject;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SMSFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSMSFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Message
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMessage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Message2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMessage2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Subject2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubject2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IMFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIMFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EmailFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEmailFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseThisCustomEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseThisCustomEncoding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseTheDefaultEncoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseTheDefaultEncoding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Encoding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEncoding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureTheFormatsForNotifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureTheFormatsForNotifications;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseTheDefaultEmailFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseTheDefaultEmailFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseThisCustomEmailFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseThisCustomEmailFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseTheDefaultIMFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseTheDefaultIMFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseThisCustomlIMFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseThisCustomlIMFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseTheDefaultSMSFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseTheDefaultSMSFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseThisCustomSMSFormat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseThisCustomSMSFormat;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Formats2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFormats2;
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
            /// Exposes access to the Introduction translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction
            {
                get
                {
                    if ((cachedIntroduction == null))
                    {
                        cachedIntroduction = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction);
                    }
                    return cachedIntroduction;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UserRoleFilter translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserRoleFilter
            {
                get
                {
                    if ((cachedUserRoleFilter == null))
                    {
                        cachedUserRoleFilter = CoreManager.MomConsole.GetIntlStr(ResourceUserRoleFilter);
                    }
                    return cachedUserRoleFilter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Groups translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Groups
            {
                get
                {
                    if ((cachedGroups == null))
                    {
                        cachedGroups = CoreManager.MomConsole.GetIntlStr(ResourceGroups);
                    }
                    return cachedGroups;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Classes translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Classes
            {
                get
                {
                    if ((cachedClasses == null))
                    {
                        cachedClasses = CoreManager.MomConsole.GetIntlStr(ResourceClasses);
                    }
                    return cachedClasses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCriteria
            {
                get
                {
                    if ((cachedAlertCriteria == null))
                    {
                        cachedAlertCriteria = CoreManager.MomConsole.GetIntlStr(ResourceAlertCriteria);
                    }
                    return cachedAlertCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertAging translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Formats translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Formats
            {
                get
                {
                    if ((cachedFormats == null))
                    {
                        cachedFormats = CoreManager.MomConsole.GetIntlStr(ResourceFormats);
                    }
                    return cachedFormats;
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
            /// Exposes access to the Placeholder translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Placeholder
            {
                get
                {
                    if ((cachedPlaceholder == null))
                    {
                        cachedPlaceholder = CoreManager.MomConsole.GetIntlStr(ResourcePlaceholder);
                    }
                    return cachedPlaceholder;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Placeholder2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Placeholder2
            {
                get
                {
                    if ((cachedPlaceholder2 == null))
                    {
                        cachedPlaceholder2 = CoreManager.MomConsole.GetIntlStr(ResourcePlaceholder2);
                    }
                    return cachedPlaceholder2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Placeholder3 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Placeholder3
            {
                get
                {
                    if ((cachedPlaceholder3 == null))
                    {
                        cachedPlaceholder3 = CoreManager.MomConsole.GetIntlStr(ResourcePlaceholder3);
                    }
                    return cachedPlaceholder3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Placeholder4 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Placeholder4
            {
                get
                {
                    if ((cachedPlaceholder4 == null))
                    {
                        cachedPlaceholder4 = CoreManager.MomConsole.GetIntlStr(ResourcePlaceholder4);
                    }
                    return cachedPlaceholder4;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subject translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Subject
            {
                get
                {
                    if ((cachedSubject == null))
                    {
                        cachedSubject = CoreManager.MomConsole.GetIntlStr(ResourceSubject);
                    }
                    return cachedSubject;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SMSFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SMSFormat
            {
                get
                {
                    if ((cachedSMSFormat == null))
                    {
                        cachedSMSFormat = CoreManager.MomConsole.GetIntlStr(ResourceSMSFormat);
                    }
                    return cachedSMSFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Message translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Message
            {
                get
                {
                    if ((cachedMessage == null))
                    {
                        cachedMessage = CoreManager.MomConsole.GetIntlStr(ResourceMessage);
                    }
                    return cachedMessage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Message2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Message2
            {
                get
                {
                    if ((cachedMessage2 == null))
                    {
                        cachedMessage2 = CoreManager.MomConsole.GetIntlStr(ResourceMessage2);
                    }
                    return cachedMessage2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subject2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Subject2
            {
                get
                {
                    if ((cachedSubject2 == null))
                    {
                        cachedSubject2 = CoreManager.MomConsole.GetIntlStr(ResourceSubject2);
                    }
                    return cachedSubject2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IMFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IMFormat
            {
                get
                {
                    if ((cachedIMFormat == null))
                    {
                        cachedIMFormat = CoreManager.MomConsole.GetIntlStr(ResourceIMFormat);
                    }
                    return cachedIMFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EmailFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EmailFormat
            {
                get
                {
                    if ((cachedEmailFormat == null))
                    {
                        cachedEmailFormat = CoreManager.MomConsole.GetIntlStr(ResourceEmailFormat);
                    }
                    return cachedEmailFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseThisCustomEncoding translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseThisCustomEncoding
            {
                get
                {
                    if ((cachedUseThisCustomEncoding == null))
                    {
                        cachedUseThisCustomEncoding = CoreManager.MomConsole.GetIntlStr(ResourceUseThisCustomEncoding);
                    }
                    return cachedUseThisCustomEncoding;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseTheDefaultEncoding translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseTheDefaultEncoding
            {
                get
                {
                    if ((cachedUseTheDefaultEncoding == null))
                    {
                        cachedUseTheDefaultEncoding = CoreManager.MomConsole.GetIntlStr(ResourceUseTheDefaultEncoding);
                    }
                    return cachedUseTheDefaultEncoding;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Encoding translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Encoding
            {
                get
                {
                    if ((cachedEncoding == null))
                    {
                        cachedEncoding = CoreManager.MomConsole.GetIntlStr(ResourceEncoding);
                    }
                    return cachedEncoding;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureTheFormatsForNotifications translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureTheFormatsForNotifications
            {
                get
                {
                    if ((cachedConfigureTheFormatsForNotifications == null))
                    {
                        cachedConfigureTheFormatsForNotifications = CoreManager.MomConsole.GetIntlStr(ResourceConfigureTheFormatsForNotifications);
                    }
                    return cachedConfigureTheFormatsForNotifications;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseTheDefaultEmailFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseTheDefaultEmailFormat
            {
                get
                {
                    if ((cachedUseTheDefaultEmailFormat == null))
                    {
                        cachedUseTheDefaultEmailFormat = CoreManager.MomConsole.GetIntlStr(ResourceUseTheDefaultEmailFormat);
                    }
                    return cachedUseTheDefaultEmailFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseThisCustomEmailFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseThisCustomEmailFormat
            {
                get
                {
                    if ((cachedUseThisCustomEmailFormat == null))
                    {
                        cachedUseThisCustomEmailFormat = CoreManager.MomConsole.GetIntlStr(ResourceUseThisCustomEmailFormat);
                    }
                    return cachedUseThisCustomEmailFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseTheDefaultIMFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseTheDefaultIMFormat
            {
                get
                {
                    if ((cachedUseTheDefaultIMFormat == null))
                    {
                        cachedUseTheDefaultIMFormat = CoreManager.MomConsole.GetIntlStr(ResourceUseTheDefaultIMFormat);
                    }
                    return cachedUseTheDefaultIMFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseThisCustomlIMFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseThisCustomlIMFormat
            {
                get
                {
                    if ((cachedUseThisCustomlIMFormat == null))
                    {
                        cachedUseThisCustomlIMFormat = CoreManager.MomConsole.GetIntlStr(ResourceUseThisCustomlIMFormat);
                    }
                    return cachedUseThisCustomlIMFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseTheDefaultSMSFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseTheDefaultSMSFormat
            {
                get
                {
                    if ((cachedUseTheDefaultSMSFormat == null))
                    {
                        cachedUseTheDefaultSMSFormat = CoreManager.MomConsole.GetIntlStr(ResourceUseTheDefaultSMSFormat);
                    }
                    return cachedUseTheDefaultSMSFormat;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseThisCustomSMSFormat translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseThisCustomSMSFormat
            {
                get
                {
                    if ((cachedUseThisCustomSMSFormat == null))
                    {
                        cachedUseThisCustomSMSFormat = CoreManager.MomConsole.GetIntlStr(ResourceUseThisCustomSMSFormat);
                    }
                    return cachedUseThisCustomSMSFormat;
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
            /// Exposes access to the Formats2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Formats2
            {
                get
                {
                    if ((cachedFormats2 == null))
                    {
                        cachedFormats2 = CoreManager.MomConsole.GetIntlStr(ResourceFormats2);
                    }
                    return cachedFormats2;
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
            /// Control ID for IntroductionStaticControl
            /// </summary>
            public const string IntroductionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for UserRoleFilterStaticControl
            /// </summary>
            public const string UserRoleFilterStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GroupsStaticControl
            /// </summary>
            public const string GroupsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ClassesStaticControl
            /// </summary>
            public const string ClassesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AlertCriteriaStaticControl
            /// </summary>
            public const string AlertCriteriaStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AlertAgingStaticControl
            /// </summary>
            public const string AlertAgingStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for FormatsStaticControl
            /// </summary>
            public const string FormatsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PlaceholderButton
            /// </summary>
            public const string PlaceholderButton = "smsSubjectPlaceholder";
            
            /// <summary>
            /// Control ID for PlaceholderButton2
            /// </summary>
            public const string PlaceholderButton2 = "imMessagePlaceholder";
            
            /// <summary>
            /// Control ID for PlaceholderButton3
            /// </summary>
            public const string PlaceholderButton3 = "emailMessagePlaceholder";
            
            /// <summary>
            /// Control ID for PlaceholderButton4
            /// </summary>
            public const string PlaceholderButton4 = "emailSubjectPlaceholder";
            
            /// <summary>
            /// Control ID for SubjectTextBox
            /// </summary>
            public const string SubjectTextBox = "smsSubjectBox";
            
            /// <summary>
            /// Control ID for SubjectStaticControl
            /// </summary>
            public const string SubjectStaticControl = "smsSubjectLabel";
            
            /// <summary>
            /// Control ID for SMSFormatStaticControl
            /// </summary>
            public const string SMSFormatStaticControl = "smsLabel";
            
            /// <summary>
            /// Control ID for ANDAnyCheckedCategoryTextBox
            /// </summary>
            public const string ANDAnyCheckedCategoryTextBox = "imMessageBox";
            
            /// <summary>
            /// Control ID for MessageStaticControl
            /// </summary>
            public const string MessageStaticControl = "imMessageLabel";
            
            /// <summary>
            /// Control ID for YourAddressForTheSelectedChannelTextBox
            /// </summary>
            public const string YourAddressForTheSelectedChannelTextBox = "emailMessageBox";
            
            /// <summary>
            /// Control ID for MessageStaticControl2
            /// </summary>
            public const string MessageStaticControl2 = "emailMessageLabel";
            
            /// <summary>
            /// Control ID for RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox
            /// </summary>
            public const string RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageTextBox = "emailSubjectBox";
            
            /// <summary>
            /// Control ID for SubjectStaticControl2
            /// </summary>
            public const string SubjectStaticControl2 = "emailSubjectLabel";
            
            /// <summary>
            /// Control ID for IMFormatStaticControl
            /// </summary>
            public const string IMFormatStaticControl = "imLabel";
            
            /// <summary>
            /// Control ID for EmailFormatStaticControl
            /// </summary>
            public const string EmailFormatStaticControl = "emailLabel";
            
            /// <summary>
            /// Control ID for ToEditComboBox
            /// </summary>
            public const string ToEditComboBox = "encodingList";
            
            /// <summary>
            /// Control ID for NotificationChannelTextBox
            /// </summary>
            public const string NotificationChannelTextBox = "defaultEncodingBox";
            
            /// <summary>
            /// Control ID for UseThisCustomEncodingRadioButton
            /// </summary>
            public const string UseThisCustomEncodingRadioButton = "customEncoding";
            
            /// <summary>
            /// Control ID for UseTheDefaultEncodingRadioButton
            /// </summary>
            public const string UseTheDefaultEncodingRadioButton = "defaultEncoding";
            
            /// <summary>
            /// Control ID for EncodingStaticControl
            /// </summary>
            public const string EncodingStaticControl = "encodingLabel";
            
            /// <summary>
            /// Control ID for ConfigureTheFormatsForNotificationsStaticControl
            /// </summary>
            public const string ConfigureTheFormatsForNotificationsStaticControl = "titleLabel";
            
            /// <summary>
            /// Control ID for UseTheDefaultEmailFormatRadioButton
            /// </summary>
            public const string UseTheDefaultEmailFormatRadioButton = "defaultEmail";
            
            /// <summary>
            /// Control ID for UseThisCustomEmailFormatRadioButton
            /// </summary>
            public const string UseThisCustomEmailFormatRadioButton = "customEmail";
            
            /// <summary>
            /// Control ID for UseTheDefaultIMFormatRadioButton
            /// </summary>
            public const string UseTheDefaultIMFormatRadioButton = "defaultIMFormat";
            
            /// <summary>
            /// Control ID for UseThisCustomlIMFormatRadioButton
            /// </summary>
            public const string UseThisCustomlIMFormatRadioButton = "customIMFormat";
            
            /// <summary>
            /// Control ID for UseTheDefaultSMSFormatRadioButton
            /// </summary>
            public const string UseTheDefaultSMSFormatRadioButton = "defaultSMSFormat";
            
            /// <summary>
            /// Control ID for UseThisCustomSMSFormatRadioButton
            /// </summary>
            public const string UseThisCustomSMSFormatRadioButton = "customSMSFormat";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for FormatsStaticControl2
            /// </summary>
            public const string FormatsStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
