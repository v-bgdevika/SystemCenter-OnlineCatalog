// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateNotificationSubscriptionWizardAlertAgingWindow.cs">
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
    
    #region Radio Group Enumeration - AlertAgingOption

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group AlertAgingOption
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum AlertAgingOption
    {
        /// <summary>
        /// UseAlertAging = 0
        /// </summary>
        UseAlertAging = 0,
        
        /// <summary>
        /// DoNotNotifyOnAlertAging = 1
        /// </summary>
        DoNotNotifyOnAlertAging = 1,
    }
    #endregion
    
    #region Interface Definition - ICreateNotificationSubscriptionWizardAlertAgingWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateNotificationSubscriptionWizardAlertAgingWindowControls, for CreateNotificationSubscriptionWizardAlertAgingWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateNotificationSubscriptionWizardAlertAgingWindowControls
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
        /// Read-only property to access AvailableClassesTextBox
        /// </summary>
        TextBox AvailableClassesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ForLongerThanThisPeriodInMinutesStaticControl
        /// </summary>
        StaticControl ForLongerThanThisPeriodInMinutesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl
        /// </summary>
        StaticControl RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl
        /// </summary>
        StaticControl NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseAlertAgingRadioButton
        /// </summary>
        RadioButton UseAlertAgingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DoNotNotifyOnAlertAgingRadioButton
        /// </summary>
        RadioButton DoNotNotifyOnAlertAgingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertAgingNotificationOptionsStaticControl
        /// </summary>
        StaticControl AlertAgingNotificationOptionsStaticControl
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
        /// Read-only property to access AlertAgingStaticControl2
        /// </summary>
        StaticControl AlertAgingStaticControl2
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
    public class CreateNotificationSubscriptionWizardAlertAgingWindow : Window, ICreateNotificationSubscriptionWizardAlertAgingWindowControls
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
        /// Cache to hold a reference to AvailableClassesTextBox of type TextBox
        /// </summary>
        private TextBox cachedAvailableClassesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ForLongerThanThisPeriodInMinutesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedForLongerThanThisPeriodInMinutesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseAlertAgingRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseAlertAgingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DoNotNotifyOnAlertAgingRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDoNotNotifyOnAlertAgingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AlertAgingNotificationOptionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertAgingNotificationOptionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertAgingStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAlertAgingStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of CreateNotificationSubscriptionWizardAlertAgingWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateNotificationSubscriptionWizardAlertAgingWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group AlertAgingOption
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual AlertAgingOption AlertAgingOption
        {
            get
            {
                if ((this.Controls.UseAlertAgingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AlertAgingOption.UseAlertAging;
                }
                
                if ((this.Controls.DoNotNotifyOnAlertAgingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AlertAgingOption.DoNotNotifyOnAlertAging;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == AlertAgingOption.UseAlertAging))
                {
                    this.Controls.UseAlertAgingRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == AlertAgingOption.DoNotNotifyOnAlertAging))
                    {
                        this.Controls.DoNotNotifyOnAlertAgingRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICreateNotificationSubscriptionWizardAlertAgingWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateNotificationSubscriptionWizardAlertAgingWindowControls Controls
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
        ///  Routine to set/get the text in control AvailableClasses
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AvailableClassesText
        {
            get
            {
                return this.Controls.AvailableClassesTextBox.Text;
            }
            
            set
            {
                this.Controls.AvailableClassesTextBox.Text = value;
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
        Button ICreateNotificationSubscriptionWizardAlertAgingWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.PreviousButton);
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
        Button ICreateNotificationSubscriptionWizardAlertAgingWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.NextButton);
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
        Button ICreateNotificationSubscriptionWizardAlertAgingWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.FinishButton);
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
        Button ICreateNotificationSubscriptionWizardAlertAgingWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.CancelButton);
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.IntroductionStaticControl);
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.UserRoleFilterStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.GroupsStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.ClassesStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.AlertCriteriaStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.AlertAgingStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.FormatsStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.GeneralStaticControl
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
        ///  Exposes access to the AvailableClassesTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationSubscriptionWizardAlertAgingWindowControls.AvailableClassesTextBox
        {
            get
            {
                if ((this.cachedAvailableClassesTextBox == null))
                {
                    this.cachedAvailableClassesTextBox = new TextBox(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.AvailableClassesTextBox);
                }
                return this.cachedAvailableClassesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ForLongerThanThisPeriodInMinutesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.ForLongerThanThisPeriodInMinutesStaticControl
        {
            get
            {
                if ((this.cachedForLongerThanThisPeriodInMinutesStaticControl == null))
                {
                    this.cachedForLongerThanThisPeriodInMinutesStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.ForLongerThanThisPeriodInMinutesStaticControl);
                }
                return this.cachedForLongerThanThisPeriodInMinutesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl
        {
            get
            {
                if ((this.cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl == null))
                {
                    this.cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl);
                }
                return this.cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl
        {
            get
            {
                if ((this.cachedNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl == null))
                {
                    this.cachedNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl);
                }
                return this.cachedNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseAlertAgingRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardAlertAgingWindowControls.UseAlertAgingRadioButton
        {
            get
            {
                if ((this.cachedUseAlertAgingRadioButton == null))
                {
                    this.cachedUseAlertAgingRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.UseAlertAgingRadioButton);
                }
                return this.cachedUseAlertAgingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoNotNotifyOnAlertAgingRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardAlertAgingWindowControls.DoNotNotifyOnAlertAgingRadioButton
        {
            get
            {
                if ((this.cachedDoNotNotifyOnAlertAgingRadioButton == null))
                {
                    this.cachedDoNotNotifyOnAlertAgingRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.DoNotNotifyOnAlertAgingRadioButton);
                }
                return this.cachedDoNotNotifyOnAlertAgingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertAgingNotificationOptionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.AlertAgingNotificationOptionsStaticControl
        {
            get
            {
                if ((this.cachedAlertAgingNotificationOptionsStaticControl == null))
                {
                    this.cachedAlertAgingNotificationOptionsStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.AlertAgingNotificationOptionsStaticControl);
                }
                return this.cachedAlertAgingNotificationOptionsStaticControl;
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
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertAgingStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertAgingWindowControls.AlertAgingStaticControl2
        {
            get
            {
                if ((this.cachedAlertAgingStaticControl2 == null))
                {
                    this.cachedAlertAgingStaticControl2 = new StaticControl(this, CreateNotificationSubscriptionWizardAlertAgingWindow.ControlIDs.AlertAgingStaticControl2);
                }
                return this.cachedAlertAgingStaticControl2;
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
                    Core.Common.Utilities.LogMessage("Failed to find the window!");

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
            /// Contains resource string for:  ForLongerThanThisPeriodInMinutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceForLongerThanThisPeriodInMinutes = ";for longer than this period (in minutes):;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.Subscription" +
                "AlertAgingPage;periodLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage = ";remains in any alert resolution state checked on the Alert Criteria page;Managed" +
                "String;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertAgingPage;description2Label.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria = ";Notify when an alert that meets all other subscription criteria ;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertAgingPage;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseAlertAging
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseAlertAging = ";&Use alert aging as a notification criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertAgingPage;agingOn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoNotNotifyOnAlertAging
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoNotNotifyOnAlertAging = ";&Do not notify on alert aging;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertAgingPage;agingOff.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertAgingNotificationOptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertAgingNotificationOptions = ";Alert aging notification options:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertAgingPage;titleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertAging2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertAging2 = ";Alert Aging;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertAgingPage;$this.TabName";
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
            /// Caches the translated resource string for:  ForLongerThanThisPeriodInMinutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedForLongerThanThisPeriodInMinutes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseAlertAging
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseAlertAging;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DoNotNotifyOnAlertAging
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoNotNotifyOnAlertAging;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertAgingNotificationOptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertAgingNotificationOptions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertAging2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertAging2;
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
            /// Exposes access to the ForLongerThanThisPeriodInMinutes translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ForLongerThanThisPeriodInMinutes
            {
                get
                {
                    if ((cachedForLongerThanThisPeriodInMinutes == null))
                    {
                        cachedForLongerThanThisPeriodInMinutes = CoreManager.MomConsole.GetIntlStr(ResourceForLongerThanThisPeriodInMinutes);
                    }
                    return cachedForLongerThanThisPeriodInMinutes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage
            {
                get
                {
                    if ((cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage == null))
                    {
                        cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage = CoreManager.MomConsole.GetIntlStr(ResourceRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage);
                    }
                    return cachedRemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria
            {
                get
                {
                    if ((cachedNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria == null))
                    {
                        cachedNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria);
                    }
                    return cachedNotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseAlertAging translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseAlertAging
            {
                get
                {
                    if ((cachedUseAlertAging == null))
                    {
                        cachedUseAlertAging = CoreManager.MomConsole.GetIntlStr(ResourceUseAlertAging);
                    }
                    return cachedUseAlertAging;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DoNotNotifyOnAlertAging translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DoNotNotifyOnAlertAging
            {
                get
                {
                    if ((cachedDoNotNotifyOnAlertAging == null))
                    {
                        cachedDoNotNotifyOnAlertAging = CoreManager.MomConsole.GetIntlStr(ResourceDoNotNotifyOnAlertAging);
                    }
                    return cachedDoNotNotifyOnAlertAging;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertAgingNotificationOptions translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertAgingNotificationOptions
            {
                get
                {
                    if ((cachedAlertAgingNotificationOptions == null))
                    {
                        cachedAlertAgingNotificationOptions = CoreManager.MomConsole.GetIntlStr(ResourceAlertAgingNotificationOptions);
                    }
                    return cachedAlertAgingNotificationOptions;
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
            /// Exposes access to the AlertAging2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertAging2
            {
                get
                {
                    if ((cachedAlertAging2 == null))
                    {
                        cachedAlertAging2 = CoreManager.MomConsole.GetIntlStr(ResourceAlertAging2);
                    }
                    return cachedAlertAging2;
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
            /// Control ID for AvailableClassesTextBox
            /// </summary>
            public const string AvailableClassesTextBox = "numberBox";
            
            /// <summary>
            /// Control ID for ForLongerThanThisPeriodInMinutesStaticControl
            /// </summary>
            public const string ForLongerThanThisPeriodInMinutesStaticControl = "periodLabel";
            
            /// <summary>
            /// Control ID for RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl
            /// </summary>
            public const string RemainsInAnyAlertResolutionStateCheckedOnTheAlertCriteriaPageStaticControl = "description2Label";
            
            /// <summary>
            /// Control ID for NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl
            /// </summary>
            public const string NotifyWhenAnAlertThatMeetsAllOtherSubscriptionCriteriaStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for UseAlertAgingRadioButton
            /// </summary>
            public const string UseAlertAgingRadioButton = "agingOn";
            
            /// <summary>
            /// Control ID for DoNotNotifyOnAlertAgingRadioButton
            /// </summary>
            public const string DoNotNotifyOnAlertAgingRadioButton = "agingOff";
            
            /// <summary>
            /// Control ID for AlertAgingNotificationOptionsStaticControl
            /// </summary>
            public const string AlertAgingNotificationOptionsStaticControl = "titleLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for AlertAgingStaticControl2
            /// </summary>
            public const string AlertAgingStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
