// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SubscriptionCriteriaWindow.cs">
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
//  [KellyMor]  08-OCT-08   Added string resource for "Modify..." wizard title
//                          Modified constructor to take a flag indicating which
//                          wizard title to use, i.e. open in edit mode or not.
//  [KellyMor]  20-OCT-08   Updated control ID's and added controls for Class,
//                          Object, and Instance Name search.
//  [KellyMor]  23-OCT-08   Changed SubscriptionCriteriaCheckedListBox from
//                          ListBox to CheckedListBox.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISubscriptionCriteriaWindowControls

    /// ---------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISubscriptionCriteriaWindowControls, for SubscriptionCriteriaWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// ---------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISubscriptionCriteriaWindowControls
    {
        /// <summary>
        /// Read-only property to access SubscriptionCriteriaHeaderStaticControl
        /// </summary>
        StaticControl SubscriptionCriteriaHeaderStaticControl
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
        /// Read-only property to access ConditionsStaticControl
        /// </summary>
        StaticControl ConditionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubscriptionCriteriaCheckedListBox
        /// </summary>
        CheckedListBox SubscriptionCriteriaCheckedListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        /// </summary>
        StaticControl CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotifyOnAllAlertsStaticControl
        /// </summary>
        StaticControl NotifyOnAllAlertsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubscriptionCriteriaWizardHeaderStaticControl
        /// </summary>
        StaticControl SubscriptionCriteriaWizardHeaderStaticControl
        {
            get;
        }

        #region Alert Criteria Static Controls

        /// <summary>
        /// Read-only property to access RaisedByInstanceInSpecificGroupStaticControl
        /// </summary>
        StaticControl RaisedByInstanceInSpecificGroupStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RaisedByInstanceOfASpecificClassStaticControl
        /// </summary>
        StaticControl RaisedByInstanceOfASpecificClassStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CreatedByASpecificRuleOrMonitorStaticControl
        /// </summary>
        StaticControl CreatedByASpecificRuleOrMonitorStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RaisedByAnInstanceWithASpecificNameStaticControl
        /// </summary>
        StaticControl RaisedByAnInstanceWithASpecificNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OfASpecificSeverityStaticControl
        /// </summary>
        StaticControl OfASpecificSeverityStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OfASpecificPriorityStaticControl
        /// </summary>
        StaticControl OfASpecificPriorityStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificResolutionStateStaticControl
        /// </summary>
        StaticControl WithSpecificResolutionStateStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificNameStaticControl
        /// </summary>
        StaticControl WithSpecificNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInDescriptionStaticControl
        /// </summary>
        StaticControl WithSpecificTextInDescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CreatedInSpecificTimePeriodStaticControl
        /// </summary>
        StaticControl CreatedInSpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AssignedToASpecificOwnerStaticControl
        /// </summary>
        StaticControl AssignedToASpecificOwnerStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LastModifiedByASpecificUserStaticControl
        /// </summary>
        StaticControl LastModifiedByASpecificUserStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ModifiedInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl ModifiedInASpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ResolutionStateChangedInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl ResolutionStateChangedInASpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ResolvedInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl ResolvedInASpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ResolvedByASpecificUserStaticControl
        /// </summary>
        StaticControl ResolvedByASpecificUserStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithASpecificTicketIdStaticControl
        /// </summary>
        StaticControl WithASpecificTicketIdStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddedToTheDatabaseInASpecificTimePeriodStaticControl
        /// </summary>
        StaticControl AddedToTheDatabaseInASpecificTimePeriodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FromASpecificSiteStaticControl
        /// </summary>
        StaticControl FromASpecificSiteStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField1StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField1StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField2StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField2StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField3StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField3StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField4StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField4StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField5StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField5StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField6StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField6StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField7StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField7StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField8StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField8StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField9StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField9StaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WithSpecificTextInCustomField10StaticControl
        /// </summary>
        StaticControl WithSpecificTextInCustomField10StaticControl
        {
            get;
        }

        #endregion Alert Criteria Static Controls
    }

    #endregion
    
    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Subscription Criteria step functionality for  
    /// the Notification Subscription Wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class SubscriptionCriteriaWindow : 
        Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, 
        ISubscriptionCriteriaWindowControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SubscriptionCriteriaHeaderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubscriptionCriteriaHeaderStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InstructionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInstructionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConditionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConditionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SubscriptionCriteriaCheckedListBox of type ListBox
        /// </summary>
        private CheckedListBox cachedSubscriptionCriteriaCheckedListBox;
        
        /// <summary>
        /// Cache to hold a reference to CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NotifyOnAllAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotifyOnAllAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SubscriptionCriteriaWizardHeaderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubscriptionCriteriaWizardHeaderStaticControl;

        #region Alert Criteria Static Controls

        /// <summary>
        /// Cache to hold a reference to RaisedByInstanceInSpecificGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRaisedByInstanceInSpecificGroupStaticControl;

        /// <summary>
        /// Cache to hold a reference to RaisedByInstanceOfASpecificClassStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRaisedByInstanceOfASpecificClassStaticControl;

        /// <summary>
        /// Cache to hold a reference to CreatedByASpecificRuleOrMonitorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreatedByASpecificRuleOrMonitorStaticControl;

        /// <summary>
        /// Cache to hold a reference to RaisedByAnInstanceWithASpecificNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRaisedByAnInstanceWithASpecificNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to OfASpecificSeverityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOfASpecificSeverityStaticControl;

        /// <summary>
        /// Cache to hold a reference to OfASpecificPriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOfASpecificPriorityStaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificResolutionStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificResolutionStateStaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to CreatedInSpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreatedInSpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AssignedToASpecificOwnerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAssignedToASpecificOwnerStaticControl;

        /// <summary>
        /// Cache to hold a reference to LastModifiedByASpecificUserStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLastModifiedByASpecificUserStaticControl;

        /// <summary>
        /// Cache to hold a reference to ModifiedInASpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedModifiedInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to ResolutionStateChangedInASpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResolutionStateChangedInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to ResolvedInASpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResolvedInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to ResolvedByASpecificUserStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResolvedByASpecificUserStaticControl;

        /// <summary>
        /// Cache to hold a reference to WithASpecificTicketIdStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithASpecificTicketIdStaticControl;

        /// <summary>
        /// Cache to hold a reference to AddedToTheDatabaseInASpecificTimePeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAddedToTheDatabaseInASpecificTimePeriodStaticControl;

        /// <summary>
        /// Cache to hold a reference to FromASpecificSiteStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFromASpecificSiteStaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField1StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField1StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField2StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField2StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField3StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField3StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField4StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField4StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField5StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField5StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField6StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField6StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField7StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField7StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField8StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField8StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField9StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField9StaticControl;

        /// <summary>
        /// Cache to hold a reference to WithSpecificTextInCustomField10StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWithSpecificTextInCustomField10StaticControl;

        #endregion

        #endregion Private Member Variables

        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of SubscriptionCriteriaWindow of type MomConsoleApp
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
        public SubscriptionCriteriaWindow(MomConsoleApp ownerWindow, bool editExisting)
            : base(ownerWindow, (editExisting ? Strings.ModifyWindowTitle : Strings.WindowTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion

        #region Interface Control Properties

        #region ISubscriptionCriteriaWindow Controls Property

        /// ---------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        public new ISubscriptionCriteriaWindowControls Controls
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

        #region Control Properties

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscriptionCriteriaHeaderStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.SubscriptionCriteriaHeaderStaticControl
        {
            get
            {
                if ((this.cachedSubscriptionCriteriaHeaderStaticControl == null))
                {
                    this.cachedSubscriptionCriteriaHeaderStaticControl = new StaticControl(this, SubscriptionCriteriaWindow.ControlIDs.SubscriptionCriteriaHeaderStaticControl);
                }
                
                return this.cachedSubscriptionCriteriaHeaderStaticControl;
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
        StaticControl ISubscriptionCriteriaWindowControls.InstructionsStaticControl
        {
            get
            {
                if ((this.cachedInstructionsStaticControl == null))
                {
                    this.cachedInstructionsStaticControl = new StaticControl(this, SubscriptionCriteriaWindow.ControlIDs.InstructionsStaticControl);
                }
                
                return this.cachedInstructionsStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConditionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.ConditionsStaticControl
        {
            get
            {
                if ((this.cachedConditionsStaticControl == null))
                {
                    this.cachedConditionsStaticControl = new StaticControl(this, SubscriptionCriteriaWindow.ControlIDs.ConditionsStaticControl);
                }
                
                return this.cachedConditionsStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscriptionCriteriaCheckedListBox 
        /// control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        CheckedListBox ISubscriptionCriteriaWindowControls.SubscriptionCriteriaCheckedListBox
        {
            get
            {
                if ((this.cachedSubscriptionCriteriaCheckedListBox == null))
                {
                    this.cachedSubscriptionCriteriaCheckedListBox =
                        new CheckedListBox(
                            this, 
                            SubscriptionCriteriaWindow.ControlIDs.SubscriptionCriteriaCheckedListBox);
                }
                
                return this.cachedSubscriptionCriteriaCheckedListBox;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
        {
            get
            {
                if ((this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl == null))
                {
                    this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = new StaticControl(this, SubscriptionCriteriaWindow.ControlIDs.CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl);
                }
                
                return this.cachedCriteriaDescriptionClickTheUnderlinedValueToEditStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotifyOnAllAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.NotifyOnAllAlertsStaticControl
        {
            get
            {
                if ((this.cachedNotifyOnAllAlertsStaticControl == null))
                {
                    this.cachedNotifyOnAllAlertsStaticControl = new StaticControl(this, SubscriptionCriteriaWindow.ControlIDs.NotifyOnAllAlertsStaticControl);
                }
                
                return this.cachedNotifyOnAllAlertsStaticControl;
            }
        }

        #region Alert Criteria Static Controls

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubscriptionCriteriaWizardHeaderStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.SubscriptionCriteriaWizardHeaderStaticControl
        {
            get
            {
                if ((this.cachedSubscriptionCriteriaWizardHeaderStaticControl == null))
                {
                    this.cachedSubscriptionCriteriaWizardHeaderStaticControl = new StaticControl(this, SubscriptionCriteriaWindow.ControlIDs.SubscriptionCriteriaWizardHeaderStaticControl);
                }
                
                return this.cachedSubscriptionCriteriaWizardHeaderStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RaisedByInstanceInSpecificGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.RaisedByInstanceInSpecificGroupStaticControl
        {
            get
            {
                if ((this.cachedRaisedByInstanceInSpecificGroupStaticControl == null))
                {
                    this.cachedRaisedByInstanceInSpecificGroupStaticControl = 
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.RaisedByInstanceInSpecificGroupStaticControl);
                }

                return this.cachedRaisedByInstanceInSpecificGroupStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the 
        /// RaisedByInstanceOfASpecificClassStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.RaisedByInstanceOfASpecificClassStaticControl
        {
            get
            {
                if ((this.cachedRaisedByInstanceOfASpecificClassStaticControl == null))
                {
                    this.cachedRaisedByInstanceOfASpecificClassStaticControl =
                        new StaticControl(
                            this, 
                            SubscriptionCriteriaWindow.ControlIDs.RaisedByInstanceOfASpecificClassStaticControl);
                }

                return this.cachedRaisedByInstanceOfASpecificClassStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the 
        /// CreatedByASpecificRuleOrMonitorStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.CreatedByASpecificRuleOrMonitorStaticControl
        {
            get
            {
                if ((this.cachedCreatedByASpecificRuleOrMonitorStaticControl == null))
                {
                    this.cachedCreatedByASpecificRuleOrMonitorStaticControl =
                        new StaticControl(
                            this, 
                            SubscriptionCriteriaWindow.ControlIDs.CreatedByASpecificRuleOrMonitorStaticControl);
                }

                return this.cachedCreatedByASpecificRuleOrMonitorStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the 
        /// RaisedByInstanceInSpecificGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-OCT-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.RaisedByAnInstanceWithASpecificNameStaticControl
        {
            get
            {
                if ((this.cachedRaisedByAnInstanceWithASpecificNameStaticControl == null))
                {
                    this.cachedRaisedByAnInstanceWithASpecificNameStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.RaisedByAnInstanceWithASpecificNameStaticControl);
                }

                return this.cachedRaisedByAnInstanceWithASpecificNameStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OfASpecificSeverityStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.OfASpecificSeverityStaticControl
        {
            get
            {
                if ((this.cachedOfASpecificSeverityStaticControl == null))
                {
                    this.cachedOfASpecificSeverityStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.OfASpecificSeverityStaticControl);
                }

                return this.cachedOfASpecificSeverityStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OfASpecificPriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.OfASpecificPriorityStaticControl
        {
            get
            {
                if ((this.cachedOfASpecificPriorityStaticControl == null))
                {
                    this.cachedOfASpecificPriorityStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.OfASpecificPriorityStaticControl);
                }

                return this.cachedOfASpecificPriorityStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificResolutionStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificResolutionStateStaticControl
        {
            get
            {
                if ((this.cachedWithSpecificResolutionStateStaticControl == null))
                {
                    this.cachedWithSpecificResolutionStateStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificResolutionStateStaticControl);
                }

                return this.cachedWithSpecificResolutionStateStaticControl;
            }
        }
        
        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificNameStaticControl
        {
            get
            {
                if ((this.cachedWithSpecificNameStaticControl == null))
                {
                    this.cachedWithSpecificNameStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificNameStaticControl);
                }

                return this.cachedWithSpecificNameStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInDescriptionStaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInDescriptionStaticControl == null))
                {
                    this.cachedWithSpecificTextInDescriptionStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInDescriptionStaticControl);
                }

                return this.cachedWithSpecificTextInDescriptionStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreatedInSpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.CreatedInSpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedCreatedInSpecificTimePeriodStaticControl == null))
                {
                    this.cachedCreatedInSpecificTimePeriodStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.CreatedInSpecificTimePeriodStaticControl);
                }

                return this.cachedCreatedInSpecificTimePeriodStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AssignedToASpecificOwnerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.AssignedToASpecificOwnerStaticControl
        {
            get
            {
                if ((this.cachedAssignedToASpecificOwnerStaticControl == null))
                {
                    this.cachedAssignedToASpecificOwnerStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.AssignedToASpecificOwnerStaticControl);
                }

                return this.cachedAssignedToASpecificOwnerStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LastModifiedByASpecificUserStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.LastModifiedByASpecificUserStaticControl
        {
            get
            {
                if ((this.cachedLastModifiedByASpecificUserStaticControl == null))
                {
                    this.cachedLastModifiedByASpecificUserStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.LastModifiedByASpecificUserStaticControl);
                }

                return this.cachedLastModifiedByASpecificUserStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ModifiedInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.ModifiedInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedModifiedInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedModifiedInASpecificTimePeriodStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.ModifiedInASpecificTimePeriodStaticControl);
                }

                return this.cachedModifiedInASpecificTimePeriodStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolutionStateChangedInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.ResolutionStateChangedInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedResolutionStateChangedInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedResolutionStateChangedInASpecificTimePeriodStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.ResolutionStateChangedInASpecificTimePeriodStaticControl);
                }

                return this.cachedResolutionStateChangedInASpecificTimePeriodStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolvedInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.ResolvedInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedResolvedInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedResolvedInASpecificTimePeriodStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.ResolvedInASpecificTimePeriodStaticControl);
                }

                return this.cachedResolvedInASpecificTimePeriodStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolvedInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.ResolvedByASpecificUserStaticControl
        {
            get
            {
                if ((this.cachedResolvedByASpecificUserStaticControl == null))
                {
                    this.cachedResolvedByASpecificUserStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.ResolvedByASpecificUserStaticControl);
                }

                return this.cachedResolvedByASpecificUserStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithASpecificTicketIdStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithASpecificTicketIdStaticControl
        {
            get
            {
                if ((this.cachedWithASpecificTicketIdStaticControl == null))
                {
                    this.cachedWithASpecificTicketIdStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithASpecificTicketIdStaticControl);
                }

                return this.cachedWithASpecificTicketIdStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddedToTheDatabaseInASpecificTimePeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.AddedToTheDatabaseInASpecificTimePeriodStaticControl
        {
            get
            {
                if ((this.cachedAddedToTheDatabaseInASpecificTimePeriodStaticControl == null))
                {
                    this.cachedAddedToTheDatabaseInASpecificTimePeriodStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.AddedToTheDatabaseInASpecificTimePeriodStaticControl);
                }

                return this.cachedAddedToTheDatabaseInASpecificTimePeriodStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromASpecificSiteStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.FromASpecificSiteStaticControl
        {
            get
            {
                if ((this.cachedFromASpecificSiteStaticControl == null))
                {
                    this.cachedFromASpecificSiteStaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.FromASpecificSiteStaticControl);
                }

                return this.cachedFromASpecificSiteStaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField1StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField1StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField1StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField1StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField1StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField1StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField2StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField2StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField2StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField2StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField2StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField2StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField3StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField3StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField3StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField3StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField3StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField3StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField4StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField4StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField4StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField4StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField4StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField4StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField5StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField5StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField5StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField5StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField5StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField5StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField6StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField6StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField6StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField6StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField6StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField6StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField7StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField7StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField7StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField7StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField7StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField7StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField8StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField8StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField8StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField8StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField8StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField8StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField9StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField9StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField9StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField9StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField9StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField9StaticControl;
            }
        }

        /// ---------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithSpecificTextInCustomField10StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// ---------------------------------------------------------------
        StaticControl ISubscriptionCriteriaWindowControls.WithSpecificTextInCustomField10StaticControl
        {
            get
            {
                if ((this.cachedWithSpecificTextInCustomField10StaticControl == null))
                {
                    this.cachedWithSpecificTextInCustomField10StaticControl =
                        new StaticControl(
                            this, SubscriptionCriteriaWindow.ControlIDs.WithSpecificTextInCustomField10StaticControl);
                }

                return this.cachedWithSpecificTextInCustomField10StaticControl;
            }
        }

        #endregion Alert Criteria Static Controls

        #endregion Control Properties

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
            /// Contains resource string for:  SubscriptionCriteria
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriptionCriteria =
                ";Subscription Criteria" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionConfigurationPageTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SubscriptionCriteriaHeader 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSubscriptionCriteriaHeader =
                ";Subscription Criteria" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionConfigurationPage" +
                ";headingSectionLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InstructionsStaticControl
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInstructions =
                @";When alerts are generated for the objects that match the criteria specified below, notifications will be sent to specified subscribers." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";NotificationSubscriptionConfigurationPageDescriptionText";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Conditions
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceConditions =
                ";C&onditions" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionConfigurationPage" +
                ";conditionsLabel.Text";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit =
                ";Criteria descri&ption (click the underlined value to edit):" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";Description";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotifyOnAllAlerts
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNotifyOnAllAlerts =
                ";Notify on all alerts" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SubscriptionCriteriaResource" +
                ";CriteriaDescription";
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NavigationLinkSubscriptionCriteria
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceNavigationLinkSubscriptionCriteria =
                ";Subscription Criteria" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SubscriptionConfigurationPage" +
                ";$this.NavigationText";

            #region Alert Criteria Resources

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecificLink
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceSpecificLink =
                ";specific" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";SpecificLink";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InSpecificTimePeriodSpecificLink
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInSpecificTimePeriodLink =
                ";in specific time period" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";TimeCreatedLink";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InASpecificTimePeriodSpecificLink
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceInASpecificTimePeriodLink =
                ";in a specific time period" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";LastModifiedTimeLink";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndText
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAndText =
                ";and" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";And";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  
            /// RaisedByAnyInstanceInASpecificGroup
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceRaisedByAnyInstanceInASpecificGroup =
                ";{0} raised by any instance in a {1} group" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";GroupText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  
            /// RaisedByAnyInstanceInASpecificClass
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceRaisedByAnyInstanceOfASpecificClass =
                ";{0} raised by any instance of a {1} class" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";ClassText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreatedByASpecificRuleOrMonitor
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCreatedByASpecificRuleOrMonitor =
                ";{0} created by {1} rules or monitors (e.g., sources)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionsCriteriaSourceText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  
            /// RaisedByAnInstanceWithASpecificName 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceRaisedByAnInstanceWithASpecificName =
                ";{0} raised by an instance with a {1} name" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";InstanceName";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OfASpecificSeverity
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceOfASpecificSeverity =
                ";{0} of a {1} severity" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";ServerityText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OfASpecificPriority 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceOfASpecificPriority =
                ";{0} of a {1} priority" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";PriorityText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithSpecificResolutionState
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceWithSpecificResolutionState =
                ";{0} with {1} resolution state" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";ResolutionStateText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithASpecificName 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceWithASpecificName =
                ";{0} with a {1} name" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";NameText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithSpecificTextInDescription 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceWithSpecificTextInDescription =
                ";{0} with {1} text in the description" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";DescriptionText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreatedInSpecificTimePeriod
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCreatedInSpecificTimePeriod =
                ";{0} created {1}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";TimeCreatedText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AssignedToSpecificOwner 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAssignedToSpecificOwner =
                ";{0} assigned to a {1} owner" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";AssignedToText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LastModifiedBySpecificUser 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceLastModifiedBySpecificUser =
                ";{0} last modified by a {1} user" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";LastModifiedByText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ModifiedInASpecificTimePeriod 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceModifiedInASpecificTimePeriod =
                ";{0} that was modified {1}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";LastModifiedTimeText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResolutionStateChangedInASpecificTimePeriod 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceResolutionStateChangedInASpecificTimePeriod =
                ";{0} had its resolution state changed {1}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";ResolutionStateLastModifiedText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResolvedInASpecificTimePeriod 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceResolvedInASpecificTimePeriod =
                ";{0} that was resolved {1}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";TimeResolvedText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResolvedBySpecificUser 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceResolvedBySpecificUser =
                ";{0} resolved by {1} user" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";ResolvedByText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithSpecificTicketId 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceWithSpecificTicketId =
                ";{0} with a {1} ticket ID" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";TicketIDText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddedToDatabaseInASpecificTimePeriod 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceAddedToDatabaseInASpecificTimePeriod =
                ";{0} was added to the database {1}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";TimeAddedText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FromSpecificSite 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceFromSpecificSite =
                ";{0} from a {1} site" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";SiteText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithSpecificTextIn 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceWithSpecificTextIn =
                ";{0} with {1} text in {2}" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";CustomFieldText";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField1 
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField1 =
                ";Custom Field1" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom1";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField2
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField2 =
                ";Custom Field2" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom2";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField3
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField3 =
                ";Custom Field3" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom3";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField4
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField4 =
                ";Custom Field4" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom4";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField5
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField5 =
                ";Custom Field5" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom5";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField6
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField6 =
                ";Custom Field6" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom6";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField7
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField7 =
                ";Custom Field7" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom7";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField8
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField8 =
                ";Custom Field8" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom8";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField9
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField9 =
                ";Custom Field9" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom9";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField10
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceCustomField10 =
                ";Custom Field10" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";AlertCustom10";

            #endregion Alert Criteria Resources

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
            /// Caches the translated resource string for:  SubscriptionCriteria
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriptionCriteria;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SubscriptionCriteriaHeader
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSubscriptionCriteriaHeader;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Instructions
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInstructions;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Conditions
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedConditions;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CriteriaDescriptionClickTheUnderlinedValueToEdit
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotifyOnAllAlerts
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNotifyOnAllAlerts;
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NavigationLinkSubscriptionCriteria
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedNavigationLinkSubscriptionCriteria;

            #region Alert Criteria

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecificLink
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedSpecificLink;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InSpecificTimePeriodLink
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInSpecificTimePeriodLink;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InASpecificTimePeriodSpecificLink
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedInASpecificTimePeriodLink;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndText
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAndText;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RaisedByAnyInstanceInASpecificGroup
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedRaisedByAnyInstanceInASpecificGroup;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// RaisedByAnyInstanceInASpecificClass
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedRaisedByAnyInstanceOfASpecificClass;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// CreatedByASpecificRuleOrMonitor
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCreatedByASpecificRuleOrMonitor;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// RaisedByAnInstanceWithASpecificName
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedRaisedByAnInstanceWithASpecificName;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OfASpecificSeverity
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedOfASpecificSeverity;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OfASpecificPriority
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedOfASpecificPriority;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithSpecificResolutionState
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificResolutionState;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithASpecificName
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithASpecificName;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithSpecificTextInDescription
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInDescription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreatedInSpecificTimePeriod
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCreatedInSpecificTimePeriod;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AssignedToSpecificOwner
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAssignedToSpecificOwner;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LastModifiedBySpecificUser
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedLastModifiedBySpecificUser;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ModifiedInASpecificTimePeriod
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedModifiedInASpecificTimePeriod;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResolutionStateChangedInASpecificTimePeriod
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedResolutionStateChangedInASpecificTimePeriod;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResolvedInASpecificTimePeriod
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedResolvedInASpecificTimePeriod;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResolvedBySpecificUser
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedResolvedBySpecificUser;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithSpecificTicketId
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTicketId;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddedToDatabaseInASpecificTimePeriod
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedAddedToDatabaseInASpecificTimePeriod;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FromSpecificSite
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedFromSpecificSite;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithSpecificTextIn
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextIn;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField1;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField2
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField2;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField3
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField3;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField4
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField4;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField5
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField5;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField6
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField6;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField7
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField7;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField8
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField8;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField9
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField9;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField10
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCustomField10;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField1;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField2;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField3;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField4;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField5;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField6;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField7;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField8;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField9;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// WithSpecificTextInCustomField1
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedWithSpecificTextInCustomField10;

            #endregion Alert Criteria

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
            /// Exposes access to the SubscriptionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriptionCriteria
            {
                get
                {
                    if ((cachedSubscriptionCriteria == null))
                    {
                        cachedSubscriptionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceSubscriptionCriteria);
                    }
                    
                    return cachedSubscriptionCriteria;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubscriptionCriteriaHeader translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SubscriptionCriteriaHeader
            {
                get
                {
                    if ((cachedSubscriptionCriteriaHeader == null))
                    {
                        cachedSubscriptionCriteriaHeader = CoreManager.MomConsole.GetIntlStr(ResourceSubscriptionCriteriaHeader);
                    }

                    return cachedSubscriptionCriteriaHeader;
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
            /// Exposes access to the Conditions translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Conditions
            {
                get
                {
                    if ((cachedConditions == null))
                    {
                        cachedConditions = CoreManager.MomConsole.GetIntlStr(ResourceConditions);
                    }
                    
                    return cachedConditions;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CriteriaDescriptionClickTheUnderlinedValueToEdit translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CriteriaDescriptionClickTheUnderlinedValueToEdit
            {
                get
                {
                    if ((cachedCriteriaDescriptionClickTheUnderlinedValueToEdit == null))
                    {
                        cachedCriteriaDescriptionClickTheUnderlinedValueToEdit = CoreManager.MomConsole.GetIntlStr(ResourceCriteriaDescriptionClickTheUnderlinedValueToEdit);
                    }
                    
                    return cachedCriteriaDescriptionClickTheUnderlinedValueToEdit;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotifyOnAllAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NotifyOnAllAlerts
            {
                get
                {
                    if ((cachedNotifyOnAllAlerts == null))
                    {
                        cachedNotifyOnAllAlerts = CoreManager.MomConsole.GetIntlStr(ResourceNotifyOnAllAlerts);
                    }
                    
                    return cachedNotifyOnAllAlerts;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NavigationLinkSubscriptionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NavigationLinkSubscriptionCriteria
            {
                get
                {
                    if ((cachedNavigationLinkSubscriptionCriteria == null))
                    {
                        cachedNavigationLinkSubscriptionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceNavigationLinkSubscriptionCriteria);
                    }
                    
                    return cachedNavigationLinkSubscriptionCriteria;
                }
            }

            #region Alert Criteria

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecificLink translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string SpecificLink
            {
                get
                {
                    if ((cachedSpecificLink == null))
                    {
                        cachedSpecificLink = CoreManager.MomConsole.GetIntlStr(ResourceSpecificLink);
                    }

                    return cachedSpecificLink;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InSpecificTimePeriodLink translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string InSpecificTimePeriodLink
            {
                get
                {
                    if ((cachedInSpecificTimePeriodLink == null))
                    {
                        cachedInSpecificTimePeriodLink = CoreManager.MomConsole.GetIntlStr(ResourceInSpecificTimePeriodLink);
                    }

                    return cachedInSpecificTimePeriodLink;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InASpecificTimePeriodLink translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string InASpecificTimePeriodLink
            {
                get
                {
                    if ((cachedInASpecificTimePeriodLink == null))
                    {
                        cachedInASpecificTimePeriodLink = CoreManager.MomConsole.GetIntlStr(ResourceInASpecificTimePeriodLink);
                    }

                    return cachedInASpecificTimePeriodLink;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AndText translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AndText
            {
                get
                {
                    if ((cachedAndText == null))
                    {
                        cachedAndText = CoreManager.MomConsole.GetIntlStr(ResourceAndText);
                    }

                    return cachedAndText;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RaisedByAnyInstanceInASpecificGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string RaisedByAnyInstanceInASpecificGroup
            {
                get
                {
                    if ((cachedRaisedByAnyInstanceInASpecificGroup == null))
                    {
                        cachedRaisedByAnyInstanceInASpecificGroup = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRaisedByAnyInstanceInASpecificGroup);

                        // get translated "specific" and replace in string
                        cachedRaisedByAnyInstanceInASpecificGroup =
                            cachedRaisedByAnyInstanceInASpecificGroup.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedRaisedByAnyInstanceInASpecificGroup;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RaisedByAnyInstanceOfASpecificClass 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string RaisedByAnyInstanceOfASpecificClass
            {
                get
                {
                    if ((cachedRaisedByAnyInstanceOfASpecificClass == null))
                    {
                        cachedRaisedByAnyInstanceOfASpecificClass = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRaisedByAnyInstanceOfASpecificClass);

                        // get translated "specific" and replace in string
                        cachedRaisedByAnyInstanceOfASpecificClass =
                            cachedRaisedByAnyInstanceOfASpecificClass.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedRaisedByAnyInstanceOfASpecificClass;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreatedByASpecificRuleOrMonitor 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CreatedByASpecificRuleOrMonitor
            {
                get
                {
                    if ((cachedCreatedByASpecificRuleOrMonitor == null))
                    {
                        cachedCreatedByASpecificRuleOrMonitor =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCreatedByASpecificRuleOrMonitor);

                        // get translated "specific" and replace in string
                        cachedCreatedByASpecificRuleOrMonitor =
                            cachedCreatedByASpecificRuleOrMonitor.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedCreatedByASpecificRuleOrMonitor;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RaisedByAnInstanceWithASpecificName 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string RaisedByAnInstanceWithASpecificName
            {
                get
                {
                    if ((cachedRaisedByAnInstanceWithASpecificName == null))
                    {
                        cachedRaisedByAnInstanceWithASpecificName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRaisedByAnInstanceWithASpecificName);

                        // get translated "specific" and replace in string
                        cachedRaisedByAnInstanceWithASpecificName =
                            cachedRaisedByAnInstanceWithASpecificName.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedRaisedByAnInstanceWithASpecificName;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OfASpecificSeverity translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string OfASpecificSeverity
            {
                get
                {
                    if ((cachedOfASpecificSeverity == null))
                    {
                        cachedOfASpecificSeverity = 
                            CoreManager.MomConsole.GetIntlStr(
                            ResourceOfASpecificSeverity);

                        // get translated "specific" and replace in string
                        cachedOfASpecificSeverity =
                            cachedOfASpecificSeverity.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedOfASpecificSeverity;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OfASpecificPriority translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string OfASpecificPriority
            {
                get
                {
                    if ((cachedOfASpecificPriority == null))
                    {
                        cachedOfASpecificPriority = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceOfASpecificPriority);

                        // get translated "specific" and replace in string
                        cachedOfASpecificPriority =
                            cachedOfASpecificPriority.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedOfASpecificPriority;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificResolutionState translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificResolutionState
            {
                get
                {
                    if ((cachedWithSpecificResolutionState == null))
                    {
                        cachedWithSpecificResolutionState = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWithSpecificResolutionState);

                        // get translated "specific" and replace in string
                        cachedWithSpecificResolutionState =
                            cachedWithSpecificResolutionState.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedWithSpecificResolutionState;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithASpecificName translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithASpecificName
            {
                get
                {
                    if ((cachedWithASpecificName == null))
                    {
                        cachedWithASpecificName = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWithASpecificName);

                        // get translated "specific" and replace in string
                        cachedWithASpecificName =
                            cachedWithASpecificName.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedWithASpecificName;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInDescription translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInDescription
            {
                get
                {
                    if ((cachedWithSpecificTextInDescription == null))
                    {
                        cachedWithSpecificTextInDescription = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWithSpecificTextInDescription);

                        // get translated "specific" and replace in string
                        cachedWithSpecificTextInDescription =
                            cachedWithSpecificTextInDescription.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedWithSpecificTextInDescription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreatedInSpecificTimePeriod translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CreatedInSpecificTimePeriod
            {
                get
                {
                    if ((cachedCreatedInSpecificTimePeriod == null))
                    {
                        cachedCreatedInSpecificTimePeriod = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCreatedInSpecificTimePeriod);

                        // get translated "specific" and replace in string
                        cachedCreatedInSpecificTimePeriod =
                            cachedCreatedInSpecificTimePeriod.Replace(
                                "{1}",
                                Strings.InSpecificTimePeriodLink);
                    }

                    return cachedCreatedInSpecificTimePeriod;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AssignedToSpecificOwner translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AssignedToSpecificOwner
            {
                get
                {
                    if ((cachedAssignedToSpecificOwner == null))
                    {
                        cachedAssignedToSpecificOwner = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAssignedToSpecificOwner);

                        // get translated "specific" and replace in string
                        cachedAssignedToSpecificOwner =
                            cachedAssignedToSpecificOwner.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedAssignedToSpecificOwner;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LastModifiedBySpecificUser translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string LastModifiedBySpecificUser
            {
                get
                {
                    if ((cachedLastModifiedBySpecificUser == null))
                    {
                        cachedLastModifiedBySpecificUser = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceLastModifiedBySpecificUser);

                        // get translated "specific" and replace in string
                        cachedLastModifiedBySpecificUser =
                            cachedLastModifiedBySpecificUser.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedLastModifiedBySpecificUser;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ModifiedInASpecificTimePeriod translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ModifiedInASpecificTimePeriod
            {
                get
                {
                    if ((cachedModifiedInASpecificTimePeriod == null))
                    {
                        cachedModifiedInASpecificTimePeriod = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceModifiedInASpecificTimePeriod);

                        // get translated "specific" and replace in string
                        cachedModifiedInASpecificTimePeriod =
                            cachedModifiedInASpecificTimePeriod.Replace(
                                "{1}",
                                Strings.InASpecificTimePeriodLink);
                    }

                    return cachedModifiedInASpecificTimePeriod;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResolutionStateChangedInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ResolutionStateChangedInASpecificTimePeriod
            {
                get
                {
                    if ((cachedResolutionStateChangedInASpecificTimePeriod == null))
                    {
                        cachedResolutionStateChangedInASpecificTimePeriod = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceResolutionStateChangedInASpecificTimePeriod);

                        // get translated "specific" and replace in string
                        cachedResolutionStateChangedInASpecificTimePeriod =
                            cachedResolutionStateChangedInASpecificTimePeriod.Replace(
                                "{1}",
                                Strings.InASpecificTimePeriodLink);
                    }

                    return cachedResolutionStateChangedInASpecificTimePeriod;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResolvedInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ResolvedInASpecificTimePeriod
            {
                get
                {
                    if ((cachedResolvedInASpecificTimePeriod == null))
                    {
                        cachedResolvedInASpecificTimePeriod = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceResolvedInASpecificTimePeriod);

                        // get translated "specific" and replace in string
                        cachedResolvedInASpecificTimePeriod =
                            cachedResolvedInASpecificTimePeriod.Replace(
                                "{1}",
                                Strings.InASpecificTimePeriodLink);
                    }

                    return cachedResolvedInASpecificTimePeriod;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResolvedBySpecificUser translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ResolvedBySpecificUser
            {
                get
                {
                    if ((cachedResolvedBySpecificUser == null))
                    {
                        cachedResolvedBySpecificUser = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceResolvedBySpecificUser);

                        // get translated "specific" and replace in string
                        cachedResolvedBySpecificUser =
                            cachedResolvedBySpecificUser.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedResolvedBySpecificUser;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTicketId translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTicketId
            {
                get
                {
                    if ((cachedWithSpecificTicketId == null))
                    {
                        cachedWithSpecificTicketId = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWithSpecificTicketId);

                        // get translated "specific" and replace in string
                        cachedWithSpecificTicketId =
                            cachedWithSpecificTicketId.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedWithSpecificTicketId;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddedToDatabaseInASpecificTimePeriod translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string AddedToDatabaseInASpecificTimePeriod
            {
                get
                {
                    if ((cachedAddedToDatabaseInASpecificTimePeriod == null))
                    {
                        cachedAddedToDatabaseInASpecificTimePeriod = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAddedToDatabaseInASpecificTimePeriod);

                        // get translated "specific" and replace in string
                        cachedAddedToDatabaseInASpecificTimePeriod =
                            cachedAddedToDatabaseInASpecificTimePeriod.Replace(
                                "{1}",
                                Strings.InASpecificTimePeriodLink);
                    }

                    return cachedAddedToDatabaseInASpecificTimePeriod;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FromSpecificSite translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string FromSpecificSite
            {
                get
                {
                    if ((cachedFromSpecificSite == null))
                    {
                        cachedFromSpecificSite = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceFromSpecificSite);

                        // get translated "specific" and replace in string
                        cachedFromSpecificSite =
                            cachedFromSpecificSite.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedFromSpecificSite;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextIn translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextIn
            {
                get
                {
                    if ((cachedWithSpecificTextIn == null))
                    {
                        cachedWithSpecificTextIn = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceWithSpecificTextIn);

                        // get translated "specific" and replace in string
                        cachedWithSpecificTextIn =
                            cachedWithSpecificTextIn.Replace(
                                "{1}",
                                Strings.SpecificLink);
                    }

                    return cachedWithSpecificTextIn;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField1
            {
                get
                {
                    if ((cachedCustomField1 == null))
                    {
                        cachedCustomField1 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField1);
                    }

                    return cachedCustomField1;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField2
            {
                get
                {
                    if ((cachedCustomField2 == null))
                    {
                        cachedCustomField2 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField2);
                    }

                    return cachedCustomField2;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField3 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField3
            {
                get
                {
                    if ((cachedCustomField3 == null))
                    {
                        cachedCustomField3 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField3);
                    }

                    return cachedCustomField3;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField4 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField4
            {
                get
                {
                    if ((cachedCustomField4 == null))
                    {
                        cachedCustomField4 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField4);
                    }

                    return cachedCustomField4;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField5 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField5
            {
                get
                {
                    if ((cachedCustomField5 == null))
                    {
                        cachedCustomField5 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField5);
                    }

                    return cachedCustomField5;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField6 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField6
            {
                get
                {
                    if ((cachedCustomField6 == null))
                    {
                        cachedCustomField6 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField6);
                    }

                    return cachedCustomField6;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField7 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField7
            {
                get
                {
                    if ((cachedCustomField7 == null))
                    {
                        cachedCustomField7 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField7);
                    }

                    return cachedCustomField7;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField8 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField8
            {
                get
                {
                    if ((cachedCustomField8 == null))
                    {
                        cachedCustomField8 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField8);
                    }

                    return cachedCustomField8;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField9 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField9
            {
                get
                {
                    if ((cachedCustomField9 == null))
                    {
                        cachedCustomField9 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField9);
                    }

                    return cachedCustomField9;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField10 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CustomField10
            {
                get
                {
                    if ((cachedCustomField10 == null))
                    {
                        cachedCustomField10 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField10);
                    }

                    return cachedCustomField10;
                }
            }
            
            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField1 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField1
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField1 == null))
                    {
                        cachedWithSpecificTextInCustomField1 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field1"
                        cachedWithSpecificTextInCustomField1 =
                            cachedWithSpecificTextInCustomField1.Replace(
                                "{2}",
                                Strings.CustomField1);
                    }

                    return cachedWithSpecificTextInCustomField1;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField2 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField2
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField2 == null))
                    {
                        cachedWithSpecificTextInCustomField2 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field2"
                        cachedWithSpecificTextInCustomField2 =
                            cachedWithSpecificTextInCustomField2.Replace(
                                "{2}",
                                Strings.CustomField2);
                    }

                    return cachedWithSpecificTextInCustomField2;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField3 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField3
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField3 == null))
                    {
                        cachedWithSpecificTextInCustomField3 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field3"
                        cachedWithSpecificTextInCustomField3 =
                            cachedWithSpecificTextInCustomField3.Replace(
                                "{2}",
                                Strings.CustomField3);
                    }

                    return cachedWithSpecificTextInCustomField3;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField4 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField4
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField4 == null))
                    {
                        cachedWithSpecificTextInCustomField4 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field4"
                        cachedWithSpecificTextInCustomField4 =
                            cachedWithSpecificTextInCustomField4.Replace(
                                "{2}",
                                Strings.CustomField4);
                    }

                    return cachedWithSpecificTextInCustomField4;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField5 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField5
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField5 == null))
                    {
                        cachedWithSpecificTextInCustomField5 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field5"
                        cachedWithSpecificTextInCustomField5 =
                            cachedWithSpecificTextInCustomField5.Replace(
                                "{2}",
                                Strings.CustomField5);
                    }

                    return cachedWithSpecificTextInCustomField5;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField6 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField6
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField6 == null))
                    {
                        cachedWithSpecificTextInCustomField6 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field6"
                        cachedWithSpecificTextInCustomField6 =
                            cachedWithSpecificTextInCustomField6.Replace(
                                "{2}",
                                Strings.CustomField6);
                    }

                    return cachedWithSpecificTextInCustomField6;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField7 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField7
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField7 == null))
                    {
                        cachedWithSpecificTextInCustomField7 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field7"
                        cachedWithSpecificTextInCustomField7 =
                            cachedWithSpecificTextInCustomField7.Replace(
                                "{2}",
                                Strings.CustomField7);
                    }

                    return cachedWithSpecificTextInCustomField7;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField8 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField8
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField8 == null))
                    {
                        cachedWithSpecificTextInCustomField8 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field8"
                        cachedWithSpecificTextInCustomField8 =
                            cachedWithSpecificTextInCustomField8.Replace(
                                "{2}",
                                Strings.CustomField8);
                    }

                    return cachedWithSpecificTextInCustomField8;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField9 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField9
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField9 == null))
                    {
                        cachedWithSpecificTextInCustomField9 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field9"
                        cachedWithSpecificTextInCustomField9 =
                            cachedWithSpecificTextInCustomField9.Replace(
                                "{2}",
                                Strings.CustomField9);
                    }

                    return cachedWithSpecificTextInCustomField9;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithSpecificTextInCustomField10 translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-OCT-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string WithSpecificTextInCustomField10
            {
                get
                {
                    if ((cachedWithSpecificTextInCustomField10 == null))
                    {
                        cachedWithSpecificTextInCustomField10 =
                            Strings.WithSpecificTextIn;

                        // get translated text for "Custom Field10"
                        cachedWithSpecificTextInCustomField10 =
                            cachedWithSpecificTextInCustomField10.Replace(
                                "{2}",
                                Strings.CustomField10);
                    }

                    return cachedWithSpecificTextInCustomField10;
                }
            }

            #endregion Alert Criteria

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
            /// Control ID for SubscriptionCriteriaHeaderStaticControl
            /// </summary>
            public const string SubscriptionCriteriaHeaderStaticControl = "headingSectionLabel";
            
            /// <summary>
            /// Control ID for InstructionsStaticControl
            /// </summary>
            public const string InstructionsStaticControl = "descriptionText";
            
            /// <summary>
            /// Control ID for ConditionsStaticControl
            /// </summary>
            public const string ConditionsStaticControl = "conditionsLabel";
            
            /// <summary>
            /// Control ID for SubscriptionCriteriaCheckedListBox
            /// </summary>
            public const string SubscriptionCriteriaCheckedListBox = "checkboxes";
            
            /// <summary>
            /// Control ID for CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl
            /// </summary>
            public const string CriteriaDescriptionClickTheUnderlinedValueToEditStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for NotifyOnAllAlertsStaticControl
            /// </summary>
            public const string NotifyOnAllAlertsStaticControl = "labelHeader";
            
            /// <summary>
            /// Control ID for SubscriptionCriteriaWizardHeaderStaticControl
            /// </summary>
            public const string SubscriptionCriteriaWizardHeaderStaticControl = "headerLabel";
            
            #region Alert Criteria Static Control ID's
            
            /// <summary>
            /// Control ID for RaisedByInstanceInSpecificGroupStaticControl
            /// </summary>
            public const string RaisedByInstanceInSpecificGroupStaticControl = "0";

            /// <summary>
            /// Control ID for RaisedByInstanceOfASpecificClassStaticControl
            /// </summary>
            public const string RaisedByInstanceOfASpecificClassStaticControl = "1";

            /// <summary>
            /// Control ID for CreatedByASpecificRuleOrMonitorStaticControl
            /// </summary>
            public const string CreatedByASpecificRuleOrMonitorStaticControl = "2";
            
            /// <summary>
            /// Control ID for RaisedByAnInstanceWithASpecificNameStaticControl
            /// </summary>
            public const string RaisedByAnInstanceWithASpecificNameStaticControl = "3";

            /// <summary>
            /// Control ID for OfASpecificSeverityStaticControl
            /// </summary>
            public const string OfASpecificSeverityStaticControl = "4";

            /// <summary>
            /// Control ID for OfASpecificPriorityStaticControl
            /// </summary>
            public const string OfASpecificPriorityStaticControl = "5";

            /// <summary>
            /// Control ID for WithSpecificResolutionStateStaticControl
            /// </summary>
            public const string WithSpecificResolutionStateStaticControl = "6";

            /// <summary>
            /// Control ID for WithSpecificNameStaticControl
            /// </summary>
            public const string WithSpecificNameStaticControl = "7";

            /// <summary>
            /// Control ID for WithSpecificTextInDescriptionStaticControl
            /// </summary>
            public const string WithSpecificTextInDescriptionStaticControl = "8";

            /// <summary>
            /// Control ID for CreatedInSpecificTimePeriodStaticControl
            /// </summary>
            public const string CreatedInSpecificTimePeriodStaticControl = "9";

            /// <summary>
            /// Control ID for AssignedToASpecificOwnerStaticControl
            /// </summary>
            public const string AssignedToASpecificOwnerStaticControl = "10";

            /// <summary>
            /// Control ID for LastModifiedByASpecificUserStaticControl
            /// </summary>
            public const string LastModifiedByASpecificUserStaticControl = "11";

            /// <summary>
            /// Control ID for ModifiedInASpecificTimePeriodStaticControl
            /// </summary>
            public const string ModifiedInASpecificTimePeriodStaticControl = "12";

            /// <summary>
            /// Control ID for ResolutionStateChangedInASpecificTimePeriodStaticControl
            /// </summary>
            public const string ResolutionStateChangedInASpecificTimePeriodStaticControl = "13";

            /// <summary>
            /// Control ID for ResolvedInASpecificTimePeriodStaticControl
            /// </summary>
            public const string ResolvedInASpecificTimePeriodStaticControl = "14";

            /// <summary>
            /// Control ID for ResolvedByASpecificUserStaticControl
            /// </summary>
            public const string ResolvedByASpecificUserStaticControl = "15";

            /// <summary>
            /// Control ID for WithASpecificTicketIdStaticControl
            /// </summary>
            public const string WithASpecificTicketIdStaticControl = "16";

            /// <summary>
            /// Control ID for AddedToTheDatabaseInASpecificTimePeriodStaticControl
            /// </summary>
            public const string AddedToTheDatabaseInASpecificTimePeriodStaticControl = "17";

            /// <summary>
            /// Control ID for FromASpecificSiteStaticControl
            /// </summary>
            public const string FromASpecificSiteStaticControl = "18";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField1StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField1StaticControl = "19";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField2StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField2StaticControl = "20";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField3StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField3StaticControl = "21";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField4StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField4StaticControl = "22";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField5StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField5StaticControl = "23";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField6StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField6StaticControl = "24";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField7StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField7StaticControl = "25";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField8StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField8StaticControl = "26";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField9StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField9StaticControl = "27";

            /// <summary>
            /// Control ID for WithSpecificTextInCustomField10StaticControl
            /// </summary>
            public const string WithSpecificTextInCustomField10StaticControl = "28";

            #endregion
        }

        #endregion
    }
}
