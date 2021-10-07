// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateNotificationSubscriptionWizardClassesWindow.cs">
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
    
    #region Radio Group Enumeration - ClassesOption

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group ClassesOption
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum ClassesOption
    {
        /// <summary>
        /// OnlyClassesExplicitlyAdded = 0
        /// </summary>
        OnlyClassesExplicitlyAdded = 0,
        
        /// <summary>
        /// AllClassesAreAutomaticallyApproved = 1
        /// </summary>
        AllClassesAreAutomaticallyApproved = 1,
    }
    #endregion
    
    #region Interface Definition - ICreateNotificationSubscriptionWizardClassesWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateNotificationSubscriptionWizardClassesWindowControls, for CreateNotificationSubscriptionWizardClassesWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateNotificationSubscriptionWizardClassesWindowControls
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
        /// Read-only property to access OnlyClassesExplicitlyAddedRadioButton
        /// </summary>
        RadioButton OnlyClassesExplicitlyAddedRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllClassesAreAutomaticallyApprovedRadioButton
        /// </summary>
        RadioButton AllClassesAreAutomaticallyApprovedRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl
        /// </summary>
        StaticControl NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OnEachCheckedWeekdayTextBox
        /// </summary>
        TextBox OnEachCheckedWeekdayTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClassNameMustContainThisStringOptionalStaticControl
        /// </summary>
        StaticControl ClassNameMustContainThisStringOptionalStaticControl
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
        /// Read-only property to access AvailableClassesStaticControl
        /// </summary>
        StaticControl AvailableClassesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ApprovedClassesListView
        /// </summary>
        ListView ApprovedClassesListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveAllButton
        /// </summary>
        Button RemoveAllButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ApprovedClassesStaticControl
        /// </summary>
        StaticControl ApprovedClassesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddAllButton
        /// </summary>
        Button AddAllButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchButton
        /// </summary>
        Button SearchButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchForClassesInManagementPacksStaticControl
        /// </summary>
        StaticControl SearchForClassesInManagementPacksStaticControl
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
        /// Read-only property to access ClassesStaticControl2
        /// </summary>
        StaticControl ClassesStaticControl2
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
    public class CreateNotificationSubscriptionWizardClassesWindow : Window, ICreateNotificationSubscriptionWizardClassesWindowControls
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
        /// Cache to hold a reference to OnlyClassesExplicitlyAddedRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedOnlyClassesExplicitlyAddedRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AllClassesAreAutomaticallyApprovedRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllClassesAreAutomaticallyApprovedRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OnEachCheckedWeekdayTextBox of type TextBox
        /// </summary>
        private TextBox cachedOnEachCheckedWeekdayTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ClassNameMustContainThisStringOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedClassNameMustContainThisStringOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeSchedulesListView of type ListView
        /// </summary>
        private ListView cachedExcludeSchedulesListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableClassesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableClassesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to ApprovedClassesListView of type ListView
        /// </summary>
        private ListView cachedApprovedClassesListView;
        
        /// <summary>
        /// Cache to hold a reference to RemoveAllButton of type Button
        /// </summary>
        private Button cachedRemoveAllButton;
        
        /// <summary>
        /// Cache to hold a reference to ApprovedClassesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApprovedClassesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AddAllButton of type Button
        /// </summary>
        private Button cachedAddAllButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to SearchForClassesInManagementPacksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchForClassesInManagementPacksStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClassesStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedClassesStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of CreateNotificationSubscriptionWizardClassesWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateNotificationSubscriptionWizardClassesWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group ClassesOption
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ClassesOption ClassesOption
        {
            get
            {
                if ((this.Controls.OnlyClassesExplicitlyAddedRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ClassesOption.OnlyClassesExplicitlyAdded;
                }
                
                if ((this.Controls.AllClassesAreAutomaticallyApprovedRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ClassesOption.AllClassesAreAutomaticallyApproved;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == ClassesOption.OnlyClassesExplicitlyAdded))
                {
                    this.Controls.OnlyClassesExplicitlyAddedRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == ClassesOption.AllClassesAreAutomaticallyApproved))
                    {
                        this.Controls.AllClassesAreAutomaticallyApprovedRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICreateNotificationSubscriptionWizardClassesWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateNotificationSubscriptionWizardClassesWindowControls Controls
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
        ///  Routine to set/get the text in control OnEachCheckedWeekday
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string OnEachCheckedWeekdayText
        {
            get
            {
                return this.Controls.OnEachCheckedWeekdayTextBox.Text;
            }
            
            set
            {
                this.Controls.OnEachCheckedWeekdayTextBox.Text = value;
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
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.PreviousButton);
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
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.NextButton);
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
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.FinishButton);
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
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.CancelButton);
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.IntroductionStaticControl);
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.UserRoleFilterStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.GroupsStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.ClassesStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.AlertCriteriaStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.AlertAgingStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.FormatsStaticControl
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.GeneralStaticControl
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
        ///  Exposes access to the OnlyClassesExplicitlyAddedRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardClassesWindowControls.OnlyClassesExplicitlyAddedRadioButton
        {
            get
            {
                if ((this.cachedOnlyClassesExplicitlyAddedRadioButton == null))
                {
                    this.cachedOnlyClassesExplicitlyAddedRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.OnlyClassesExplicitlyAddedRadioButton);
                }
                return this.cachedOnlyClassesExplicitlyAddedRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllClassesAreAutomaticallyApprovedRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateNotificationSubscriptionWizardClassesWindowControls.AllClassesAreAutomaticallyApprovedRadioButton
        {
            get
            {
                if ((this.cachedAllClassesAreAutomaticallyApprovedRadioButton == null))
                {
                    this.cachedAllClassesAreAutomaticallyApprovedRadioButton = new RadioButton(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.AllClassesAreAutomaticallyApprovedRadioButton);
                }
                return this.cachedAllClassesAreAutomaticallyApprovedRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl
        {
            get
            {
                if ((this.cachedNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl == null))
                {
                    this.cachedNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl);
                }
                return this.cachedNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OnEachCheckedWeekdayTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNotificationSubscriptionWizardClassesWindowControls.OnEachCheckedWeekdayTextBox
        {
            get
            {
                if ((this.cachedOnEachCheckedWeekdayTextBox == null))
                {
                    this.cachedOnEachCheckedWeekdayTextBox = new TextBox(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.OnEachCheckedWeekdayTextBox);
                }
                return this.cachedOnEachCheckedWeekdayTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClassNameMustContainThisStringOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.ClassNameMustContainThisStringOptionalStaticControl
        {
            get
            {
                if ((this.cachedClassNameMustContainThisStringOptionalStaticControl == null))
                {
                    this.cachedClassNameMustContainThisStringOptionalStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.ClassNameMustContainThisStringOptionalStaticControl);
                }
                return this.cachedClassNameMustContainThisStringOptionalStaticControl;
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
        ListView ICreateNotificationSubscriptionWizardClassesWindowControls.ExcludeSchedulesListView
        {
            get
            {
                if ((this.cachedExcludeSchedulesListView == null))
                {
                    this.cachedExcludeSchedulesListView = new ListView(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.ExcludeSchedulesListView);
                }
                return this.cachedExcludeSchedulesListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableClassesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.AvailableClassesStaticControl
        {
            get
            {
                if ((this.cachedAvailableClassesStaticControl == null))
                {
                    this.cachedAvailableClassesStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.AvailableClassesStaticControl);
                }
                return this.cachedAvailableClassesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.AddButton);
                }
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApprovedClassesListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ICreateNotificationSubscriptionWizardClassesWindowControls.ApprovedClassesListView
        {
            get
            {
                if ((this.cachedApprovedClassesListView == null))
                {
                    this.cachedApprovedClassesListView = new ListView(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.ApprovedClassesListView);
                }
                return this.cachedApprovedClassesListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.RemoveAllButton
        {
            get
            {
                if ((this.cachedRemoveAllButton == null))
                {
                    this.cachedRemoveAllButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.RemoveAllButton);
                }
                return this.cachedRemoveAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApprovedClassesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.ApprovedClassesStaticControl
        {
            get
            {
                if ((this.cachedApprovedClassesStaticControl == null))
                {
                    this.cachedApprovedClassesStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.ApprovedClassesStaticControl);
                }
                return this.cachedApprovedClassesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddAllButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.AddAllButton
        {
            get
            {
                if ((this.cachedAddAllButton == null))
                {
                    this.cachedAddAllButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.AddAllButton);
                }
                return this.cachedAddAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateNotificationSubscriptionWizardClassesWindowControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.SearchButton);
                }
                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchForClassesInManagementPacksStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.SearchForClassesInManagementPacksStaticControl
        {
            get
            {
                if ((this.cachedSearchForClassesInManagementPacksStaticControl == null))
                {
                    this.cachedSearchForClassesInManagementPacksStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.SearchForClassesInManagementPacksStaticControl);
                }
                return this.cachedSearchForClassesInManagementPacksStaticControl;
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
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClassesStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNotificationSubscriptionWizardClassesWindowControls.ClassesStaticControl2
        {
            get
            {
                if ((this.cachedClassesStaticControl2 == null))
                {
                    this.cachedClassesStaticControl2 = new StaticControl(this, CreateNotificationSubscriptionWizardClassesWindow.ControlIDs.ClassesStaticControl2);
                }
                return this.cachedClassesStaticControl2;
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
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RemoveAll
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemoveAll()
        {
            this.Controls.RemoveAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddAll
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddAll()
        {
            this.Controls.AddAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
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
            /// Contains resource string for:  OnlyClassesExplicitlyAdded
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOnlyClassesExplicitlyAdded = ";&Only classes explicitly added to the Approved classes grid are approved;" +
                "ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;customList.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllClassesAreAutomaticallyApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllClassesAreAutomaticallyApproved = ";A&ll classes are automatically approved, including clases in Management Packs im" +
                "ported in the future;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;allClasse" +
                "s.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses = ";Notify on alerts and alert updates from objects of approved classes.;ManagedStri" +
                "ng;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;titleLable.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClassNameMustContainThisStringOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClassNameMustContainThisStringOptional = ";Class name m&ust contain this string (optional):;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;objectPicker.ContainsCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableClasses = ";A&vailable classes:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;objectPicker.AvailableCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";A&dd >;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ObjectPicker;buttonAdd.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RemoveAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveAll = ";<< Re&move All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ObjectPicker;buttonRemoveAll.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApprovedClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApprovedClasses = ";App&roved classes:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;objectPicke" +
                "r.ApprovedCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddAll = ";&Add All >>;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ObjectPicker;buttonAddAll.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";< &Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ObjectPicker;buttonRemove.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";&Search;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ObjectPicker;buttonSearch.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchForClassesInManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchForClassesInManagementPacks = ";S&earch for classes in management packs:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;objectPicker.SearchCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Classes2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClasses2 = ";Classes;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.SubscriptionClassesPage;$this.TabName";
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
            /// Caches the translated resource string for:  OnlyClassesExplicitlyAdded
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOnlyClassesExplicitlyAdded;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllClassesAreAutomaticallyApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllClassesAreAutomaticallyApproved;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClassNameMustContainThisStringOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClassNameMustContainThisStringOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AvailableClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAvailableClasses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RemoveAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemoveAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApprovedClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApprovedClasses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SearchForClassesInManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchForClassesInManagementPacks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Classes2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClasses2;
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
            /// Exposes access to the OnlyClassesExplicitlyAdded translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OnlyClassesExplicitlyAdded
            {
                get
                {
                    if ((cachedOnlyClassesExplicitlyAdded == null))
                    {
                        cachedOnlyClassesExplicitlyAdded = CoreManager.MomConsole.GetIntlStr(ResourceOnlyClassesExplicitlyAdded);
                    }
                    return cachedOnlyClassesExplicitlyAdded;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllClassesAreAutomaticallyApproved translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllClassesAreAutomaticallyApproved
            {
                get
                {
                    if ((cachedAllClassesAreAutomaticallyApproved == null))
                    {
                        cachedAllClassesAreAutomaticallyApproved = CoreManager.MomConsole.GetIntlStr(ResourceAllClassesAreAutomaticallyApproved);
                    }
                    return cachedAllClassesAreAutomaticallyApproved;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses
            {
                get
                {
                    if ((cachedNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses == null))
                    {
                        cachedNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses = CoreManager.MomConsole.GetIntlStr(ResourceNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses);
                    }
                    return cachedNotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClasses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClassNameMustContainThisStringOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClassNameMustContainThisStringOptional
            {
                get
                {
                    if ((cachedClassNameMustContainThisStringOptional == null))
                    {
                        cachedClassNameMustContainThisStringOptional = CoreManager.MomConsole.GetIntlStr(ResourceClassNameMustContainThisStringOptional);
                    }
                    return cachedClassNameMustContainThisStringOptional;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AvailableClasses translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AvailableClasses
            {
                get
                {
                    if ((cachedAvailableClasses == null))
                    {
                        cachedAvailableClasses = CoreManager.MomConsole.GetIntlStr(ResourceAvailableClasses);
                    }
                    return cachedAvailableClasses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    return cachedAdd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RemoveAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemoveAll
            {
                get
                {
                    if ((cachedRemoveAll == null))
                    {
                        cachedRemoveAll = CoreManager.MomConsole.GetIntlStr(ResourceRemoveAll);
                    }
                    return cachedRemoveAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApprovedClasses translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApprovedClasses
            {
                get
                {
                    if ((cachedApprovedClasses == null))
                    {
                        cachedApprovedClasses = CoreManager.MomConsole.GetIntlStr(ResourceApprovedClasses);
                    }
                    return cachedApprovedClasses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddAll translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddAll
            {
                get
                {
                    if ((cachedAddAll == null))
                    {
                        cachedAddAll = CoreManager.MomConsole.GetIntlStr(ResourceAddAll);
                    }
                    return cachedAddAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Search
            {
                get
                {
                    if ((cachedSearch == null))
                    {
                        cachedSearch = CoreManager.MomConsole.GetIntlStr(ResourceSearch);
                    }
                    return cachedSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchForClassesInManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchForClassesInManagementPacks
            {
                get
                {
                    if ((cachedSearchForClassesInManagementPacks == null))
                    {
                        cachedSearchForClassesInManagementPacks = CoreManager.MomConsole.GetIntlStr(ResourceSearchForClassesInManagementPacks);
                    }
                    return cachedSearchForClassesInManagementPacks;
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
            /// Exposes access to the Classes2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Classes2
            {
                get
                {
                    if ((cachedClasses2 == null))
                    {
                        cachedClasses2 = CoreManager.MomConsole.GetIntlStr(ResourceClasses2);
                    }
                    return cachedClasses2;
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
            /// Control ID for OnlyClassesExplicitlyAddedRadioButton
            /// </summary>
            public const string OnlyClassesExplicitlyAddedRadioButton = "customList";
            
            /// <summary>
            /// Control ID for AllClassesAreAutomaticallyApprovedRadioButton
            /// </summary>
            public const string AllClassesAreAutomaticallyApprovedRadioButton = "allClasses";
            
            /// <summary>
            /// Control ID for NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl
            /// </summary>
            public const string NotifyOnAlertsAndAlertUpdatesFromObjectsOfApprovedClassesStaticControl = "titleLable";
            
            /// <summary>
            /// Control ID for OnEachCheckedWeekdayTextBox
            /// </summary>
            public const string OnEachCheckedWeekdayTextBox = "textBoxContains";
            
            /// <summary>
            /// Control ID for ClassNameMustContainThisStringOptionalStaticControl
            /// </summary>
            public const string ClassNameMustContainThisStringOptionalStaticControl = "labelContains";
            
            /// <summary>
            /// Control ID for ExcludeSchedulesListView
            /// </summary>
            public const string ExcludeSchedulesListView = "listViewAvailable";
            
            /// <summary>
            /// Control ID for AvailableClassesStaticControl
            /// </summary>
            public const string AvailableClassesStaticControl = "labelAvailable";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "buttonAdd";
            
            /// <summary>
            /// Control ID for ApprovedClassesListView
            /// </summary>
            public const string ApprovedClassesListView = "listViewApproved";
            
            /// <summary>
            /// Control ID for RemoveAllButton
            /// </summary>
            public const string RemoveAllButton = "buttonRemoveAll";
            
            /// <summary>
            /// Control ID for ApprovedClassesStaticControl
            /// </summary>
            public const string ApprovedClassesStaticControl = "labelApproved";
            
            /// <summary>
            /// Control ID for AddAllButton
            /// </summary>
            public const string AddAllButton = "buttonAddAll";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "buttonRemove";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "buttonSearch";
            
            /// <summary>
            /// Control ID for SearchForClassesInManagementPacksStaticControl
            /// </summary>
            public const string SearchForClassesInManagementPacksStaticControl = "labelSearch";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ClassesStaticControl2
            /// </summary>
            public const string ClassesStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
