// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateNotificationSubscriptionWizardAlertCriteriaWindow.cs">
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
    
    #region Interface Definition - ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls, for CreateNotificationSubscriptionWizardAlertCriteriaWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls
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
        /// Read-only property to access ToListBox
        /// </summary>
        ListBox ToListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ANDAnyCheckedAlertResolutionStateStaticControl
        /// </summary>
        StaticControl ANDAnyCheckedAlertResolutionStateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExclusionPeriodsListBox
        /// </summary>
        ListBox ExclusionPeriodsListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ANDAnyCheckedCategoryStaticControl
        /// </summary>
        StaticControl ANDAnyCheckedCategoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludeSchedulesListBox
        /// </summary>
        ListBox ExcludeSchedulesListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ANDAnyCheckedPriorityStaticControl
        /// </summary>
        StaticControl ANDAnyCheckedPriorityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SchedulesToSendListBox
        /// </summary>
        ListBox SchedulesToSendListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertsOfAnyOfCheckedSeverityStaticControl
        /// </summary>
        StaticControl AlertsOfAnyOfCheckedSeverityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl
        /// </summary>
        StaticControl ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotifiesOnAllAlertsStaticControl
        /// </summary>
        StaticControl NotifiesOnAllAlertsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CheckAllStaticControl
        /// </summary>
        StaticControl CheckAllStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl
        /// </summary>
        StaticControl NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl
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
        /// Read-only property to access AlertCriteriaStaticControl2
        /// </summary>
        StaticControl AlertCriteriaStaticControl2
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
    public class CreateNotificationSubscriptionWizardAlertCriteriaWindow : Window, ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls
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
        /// Cache to hold a reference to ToListBox of type ListBox
        /// </summary>
        private ListBox cachedToListBox;
        
        /// <summary>
        /// Cache to hold a reference to ANDAnyCheckedAlertResolutionStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedANDAnyCheckedAlertResolutionStateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExclusionPeriodsListBox of type ListBox
        /// </summary>
        private ListBox cachedExclusionPeriodsListBox;
        
        /// <summary>
        /// Cache to hold a reference to ANDAnyCheckedCategoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedANDAnyCheckedCategoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeSchedulesListBox of type ListBox
        /// </summary>
        private ListBox cachedExcludeSchedulesListBox;
        
        /// <summary>
        /// Cache to hold a reference to ANDAnyCheckedPriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedANDAnyCheckedPriorityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SchedulesToSendListBox of type ListBox
        /// </summary>
        private ListBox cachedSchedulesToSendListBox;
        
        /// <summary>
        /// Cache to hold a reference to AlertsOfAnyOfCheckedSeverityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertsOfAnyOfCheckedSeverityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NotifiesOnAllAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotifiesOnAllAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CheckAllStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCheckAllStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertCriteriaStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAlertCriteriaStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of CreateNotificationSubscriptionWizardAlertCriteriaWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateNotificationSubscriptionWizardAlertCriteriaWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICreateNotificationSubscriptionWizardAlertCriteriaWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls Controls
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
        Button ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.PreviousButton);
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
        Button ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.NextButton);
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
        Button ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.FinishButton);
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
        Button ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.CancelButton);
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.IntroductionStaticControl);
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.UserRoleFilterStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.GroupsStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.ClassesStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.AlertCriteriaStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.AlertAgingStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.FormatsStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.GeneralStaticControl
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
        ///  Exposes access to the ToListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.ToListBox
        {
            get
            {
                if ((this.cachedToListBox == null))
                {
                    this.cachedToListBox = new ListBox(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.ToListBox);
                }
                return this.cachedToListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ANDAnyCheckedAlertResolutionStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.ANDAnyCheckedAlertResolutionStateStaticControl
        {
            get
            {
                if ((this.cachedANDAnyCheckedAlertResolutionStateStaticControl == null))
                {
                    this.cachedANDAnyCheckedAlertResolutionStateStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.ANDAnyCheckedAlertResolutionStateStaticControl);
                }
                return this.cachedANDAnyCheckedAlertResolutionStateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExclusionPeriodsListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.ExclusionPeriodsListBox
        {
            get
            {
                if ((this.cachedExclusionPeriodsListBox == null))
                {
                    this.cachedExclusionPeriodsListBox = new ListBox(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.ExclusionPeriodsListBox);
                }
                return this.cachedExclusionPeriodsListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ANDAnyCheckedCategoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.ANDAnyCheckedCategoryStaticControl
        {
            get
            {
                if ((this.cachedANDAnyCheckedCategoryStaticControl == null))
                {
                    this.cachedANDAnyCheckedCategoryStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.ANDAnyCheckedCategoryStaticControl);
                }
                return this.cachedANDAnyCheckedCategoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeSchedulesListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.ExcludeSchedulesListBox
        {
            get
            {
                if ((this.cachedExcludeSchedulesListBox == null))
                {
                    this.cachedExcludeSchedulesListBox = new ListBox(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.ExcludeSchedulesListBox);
                }
                return this.cachedExcludeSchedulesListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ANDAnyCheckedPriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.ANDAnyCheckedPriorityStaticControl
        {
            get
            {
                if ((this.cachedANDAnyCheckedPriorityStaticControl == null))
                {
                    this.cachedANDAnyCheckedPriorityStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.ANDAnyCheckedPriorityStaticControl);
                }
                return this.cachedANDAnyCheckedPriorityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SchedulesToSendListBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.SchedulesToSendListBox
        {
            get
            {
                if ((this.cachedSchedulesToSendListBox == null))
                {
                    this.cachedSchedulesToSendListBox = new ListBox(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.SchedulesToSendListBox);
                }
                return this.cachedSchedulesToSendListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertsOfAnyOfCheckedSeverityStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.AlertsOfAnyOfCheckedSeverityStaticControl
        {
            get
            {
                if ((this.cachedAlertsOfAnyOfCheckedSeverityStaticControl == null))
                {
                    this.cachedAlertsOfAnyOfCheckedSeverityStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.AlertsOfAnyOfCheckedSeverityStaticControl);
                }
                return this.cachedAlertsOfAnyOfCheckedSeverityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl
        {
            get
            {
                if ((this.cachedItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl == null))
                {
                    this.cachedItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl);
                }
                return this.cachedItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotifiesOnAllAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.NotifiesOnAllAlertsStaticControl
        {
            get
            {
                if ((this.cachedNotifiesOnAllAlertsStaticControl == null))
                {
                    this.cachedNotifiesOnAllAlertsStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.NotifiesOnAllAlertsStaticControl);
                }
                return this.cachedNotifiesOnAllAlertsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CheckAllStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.CheckAllStaticControl
        {
            get
            {
                if ((this.cachedCheckAllStaticControl == null))
                {
                    this.cachedCheckAllStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.CheckAllStaticControl);
                }
                return this.cachedCheckAllStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl
        {
            get
            {
                if ((this.cachedNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl == null))
                {
                    this.cachedNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl);
                }
                return this.cachedNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl;
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
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertCriteriaStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardAlertCriteriaWindowControls.AlertCriteriaStaticControl2
        {
            get
            {
                if ((this.cachedAlertCriteriaStaticControl2 == null))
                {
                    this.cachedAlertCriteriaStaticControl2 = new StaticControl(this, CreateNotificationSubscriptionWizardAlertCriteriaWindow.ControlIDs.AlertCriteriaStaticControl2);
                }
                return this.cachedAlertCriteriaStaticControl2;
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
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;$this.Tab" +
                "Name";
            
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
            /// Contains resource string for:  ANDAnyCheckedAlertResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceANDAnyCheckedAlertResolutionState = ";AND any chec&ked alert resolution state:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionA" +
                "lertCriteriaPage;resolutionStateLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ANDAnyCheckedCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceANDAnyCheckedCategory = ";AND any ch&ecked category:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;categoryLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ANDAnyCheckedPriority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceANDAnyCheckedPriority = ";AN&D any checked priority:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;priorityLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertsOfAnyOfCheckedSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertsOfAnyOfCheckedSeverity = ";A&lerts of any of checked severity:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertC" +
                "riteriaPage;severityLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether = ";Items checked within a list are OR\'d together. The list are AND\'d together.;Mana" +
                "gedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;title2Label.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotifiesOnAllAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotifiesOnAllAlerts = ";notifies on all alerts.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;checkAllLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CheckAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCheckAll = ";Check All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;checkAll.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria = ";Notify on alerts and alert updates that meet these criteria.;ManagedString;" + 
                "Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;titleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertCriteria2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertCriteria2 = ";Alert Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionAlertCriteriaPage;$this.TabName";
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
            /// Caches the translated resource string for:  ANDAnyCheckedAlertResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedANDAnyCheckedAlertResolutionState;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ANDAnyCheckedCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedANDAnyCheckedCategory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ANDAnyCheckedPriority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedANDAnyCheckedPriority;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertsOfAnyOfCheckedSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertsOfAnyOfCheckedSeverity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotifiesOnAllAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotifiesOnAllAlerts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CheckAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCheckAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertCriteria2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertCriteria2;
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
            /// Exposes access to the ANDAnyCheckedAlertResolutionState translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ANDAnyCheckedAlertResolutionState
            {
                get
                {
                    if ((cachedANDAnyCheckedAlertResolutionState == null))
                    {
                        cachedANDAnyCheckedAlertResolutionState = CoreManager.MomConsole.GetIntlStr(ResourceANDAnyCheckedAlertResolutionState);
                    }
                    return cachedANDAnyCheckedAlertResolutionState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ANDAnyCheckedCategory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ANDAnyCheckedCategory
            {
                get
                {
                    if ((cachedANDAnyCheckedCategory == null))
                    {
                        cachedANDAnyCheckedCategory = CoreManager.MomConsole.GetIntlStr(ResourceANDAnyCheckedCategory);
                    }
                    return cachedANDAnyCheckedCategory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ANDAnyCheckedPriority translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ANDAnyCheckedPriority
            {
                get
                {
                    if ((cachedANDAnyCheckedPriority == null))
                    {
                        cachedANDAnyCheckedPriority = CoreManager.MomConsole.GetIntlStr(ResourceANDAnyCheckedPriority);
                    }
                    return cachedANDAnyCheckedPriority;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertsOfAnyOfCheckedSeverity translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertsOfAnyOfCheckedSeverity
            {
                get
                {
                    if ((cachedAlertsOfAnyOfCheckedSeverity == null))
                    {
                        cachedAlertsOfAnyOfCheckedSeverity = CoreManager.MomConsole.GetIntlStr(ResourceAlertsOfAnyOfCheckedSeverity);
                    }
                    return cachedAlertsOfAnyOfCheckedSeverity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether
            {
                get
                {
                    if ((cachedItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether == null))
                    {
                        cachedItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether = CoreManager.MomConsole.GetIntlStr(ResourceItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether);
                    }
                    return cachedItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogether;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotifiesOnAllAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotifiesOnAllAlerts
            {
                get
                {
                    if ((cachedNotifiesOnAllAlerts == null))
                    {
                        cachedNotifiesOnAllAlerts = CoreManager.MomConsole.GetIntlStr(ResourceNotifiesOnAllAlerts);
                    }
                    return cachedNotifiesOnAllAlerts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CheckAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CheckAll
            {
                get
                {
                    if ((cachedCheckAll == null))
                    {
                        cachedCheckAll = CoreManager.MomConsole.GetIntlStr(ResourceCheckAll);
                    }
                    return cachedCheckAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria
            {
                get
                {
                    if ((cachedNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria == null))
                    {
                        cachedNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria = CoreManager.MomConsole.GetIntlStr(ResourceNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria);
                    }
                    return cachedNotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteria;
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
            /// Exposes access to the AlertCriteria2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCriteria2
            {
                get
                {
                    if ((cachedAlertCriteria2 == null))
                    {
                        cachedAlertCriteria2 = CoreManager.MomConsole.GetIntlStr(ResourceAlertCriteria2);
                    }
                    return cachedAlertCriteria2;
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
            /// Control ID for ToListBox
            /// </summary>
            public const string ToListBox = "resolutionStateList";
            
            /// <summary>
            /// Control ID for ANDAnyCheckedAlertResolutionStateStaticControl
            /// </summary>
            public const string ANDAnyCheckedAlertResolutionStateStaticControl = "resolutionStateLabel";
            
            /// <summary>
            /// Control ID for ExclusionPeriodsListBox
            /// </summary>
            public const string ExclusionPeriodsListBox = "categoryList";
            
            /// <summary>
            /// Control ID for ANDAnyCheckedCategoryStaticControl
            /// </summary>
            public const string ANDAnyCheckedCategoryStaticControl = "categoryLabel";
            
            /// <summary>
            /// Control ID for ExcludeSchedulesListBox
            /// </summary>
            public const string ExcludeSchedulesListBox = "priorityList";
            
            /// <summary>
            /// Control ID for ANDAnyCheckedPriorityStaticControl
            /// </summary>
            public const string ANDAnyCheckedPriorityStaticControl = "priorityLabel";
            
            /// <summary>
            /// Control ID for SchedulesToSendListBox
            /// </summary>
            public const string SchedulesToSendListBox = "severityList";
            
            /// <summary>
            /// Control ID for AlertsOfAnyOfCheckedSeverityStaticControl
            /// </summary>
            public const string AlertsOfAnyOfCheckedSeverityStaticControl = "severityLabel";
            
            /// <summary>
            /// Control ID for ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl
            /// </summary>
            public const string ItemsCheckedWithinAListAreORdTogetherTheListAreANDdTogetherStaticControl = "title2Label";
            
            /// <summary>
            /// Control ID for NotifiesOnAllAlertsStaticControl
            /// </summary>
            public const string NotifiesOnAllAlertsStaticControl = "checkAllLabel";
            
            /// <summary>
            /// Control ID for CheckAllStaticControl
            /// </summary>
            public const string CheckAllStaticControl = "checkAll";
            
            /// <summary>
            /// Control ID for NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl
            /// </summary>
            public const string NotifyOnAlertsAndAlertUpdatesThatMeetTheseCriteriaStaticControl = "titleLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for AlertCriteriaStaticControl2
            /// </summary>
            public const string AlertCriteriaStaticControl2 = "headerLabel";
        }
        #endregion
    }
}