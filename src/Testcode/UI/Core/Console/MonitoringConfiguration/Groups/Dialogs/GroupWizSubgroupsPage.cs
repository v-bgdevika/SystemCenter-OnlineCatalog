// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GroupWizSubgroupsPage.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[HainingW] 3/9/2006 Created
// 	[HainingW] 3/24/2006 Fixed Resource string and add a second constructor which takes title string
// 	[HainingW] 4/07/2006 Renamed some control variables
//  [KellyMor] 12-Jun-08 Fixed missing delay bug in retry loop catch block 
//                       in Init method
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Groups.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IGroupWizSubgroupsPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGroupWizSubgroupsPageControls, for GroupWizSubgroupsPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[HainingW] 3/9/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGroupWizSubgroupsPageControls
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
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExplicitMembersStaticControl
        /// </summary>
        StaticControl ExplicitMembersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DynamicMembersStaticControl
        /// </summary>
        StaticControl DynamicMembersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubgroupsStaticControl
        /// </summary>
        StaticControl SubgroupsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludedMembersStaticControl
        /// </summary>
        StaticControl ExcludedMembersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubgroupsListView
        /// </summary>
        ListView SubgroupsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SubgroupsInThisGroupStaticControl
        /// </summary>
        StaticControl SubgroupsInThisGroupStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddRemoveSubgroupsButton
        /// </summary>
        Button AddRemoveSubgroupsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseSubgroupsToAddToThisGroupStaticControl
        /// </summary>
        StaticControl ChooseSubgroupsToAddToThisGroupStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddSubgroupsOptionalStaticControl
        /// </summary>
        StaticControl AddSubgroupsOptionalStaticControl
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
        /// Read-only property to access ChooseOptionalSubgroupsStaticControl
        /// </summary>
        StaticControl ChooseOptionalSubgroupsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
    }

    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Subgroups" page of the Create Group Wizard.
    /// </summary>
    /// <history>
    /// 	[HainingW] 3/9/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class GroupWizSubgroupsPage : Dialog, IGroupWizSubgroupsPageControls
    {
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
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExplicitMembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExplicitMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DynamicMembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDynamicMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SubgroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubgroupsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludedMembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludedMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SubgroupsListView of type ListView
        /// </summary>
        private ListView cachedSubgroupsListView;
        
        /// <summary>
        /// Cache to hold a reference to SubgroupsInThisGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSubgroupsInThisGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AddRemoveSubgroupsButton of type Button
        /// </summary>
        private Button cachedAddRemoveSubgroupsButton;
        
        /// <summary>
        /// Cache to hold a reference to ChooseSubgroupsToAddToThisGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseSubgroupsToAddToThisGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AddSubgroupsOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAddSubgroupsOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChooseOptionalSubgroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseOptionalSubgroupsStaticControl;

        /// <summary>
        /// Cache to hold a reference to OKButton
        /// </summary>
        private Button cachedOKButton;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with no dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of GroupWizSubgroupsPage of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupWizSubgroupsPage(MomConsoleApp app)
            : base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of GroupWizSubgroupsPage of type MomConsoleApp
        /// </param>
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupWizSubgroupsPage(MomConsoleApp app, string title)
            : base(app, Init(app, title))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        #endregion
        
        #region IGroupWizSubgroupsPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGroupWizSubgroupsPageControls Controls
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
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizSubgroupsPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, GroupWizSubgroupsPage.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizSubgroupsPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GroupWizSubgroupsPage.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizSubgroupsPageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, GroupWizSubgroupsPage.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizSubgroupsPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GroupWizSubgroupsPage.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, GroupWizSubgroupsPage.ControlIDs.GeneralPropertiesStaticControl);
                }
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExplicitMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.ExplicitMembersStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExplicitMembersStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedExplicitMembersStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedExplicitMembersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DynamicMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.DynamicMembersStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDynamicMembersStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedDynamicMembersStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedDynamicMembersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubgroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.SubgroupsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSubgroupsStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedSubgroupsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSubgroupsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludedMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.ExcludedMembersStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExcludedMembersStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedExcludedMembersStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedExcludedMembersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubgroupsListView control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IGroupWizSubgroupsPageControls.SubgroupsListView
        {
            get
            {
                if ((this.cachedSubgroupsListView == null))
                {
                    this.cachedSubgroupsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + GroupWizSubgroupsPage.ControlIDs.SubgroupsListView + "'"));
                }
                return this.cachedSubgroupsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SubgroupsInThisGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.SubgroupsInThisGroupStaticControl
        {
            get
            {
                if ((this.cachedSubgroupsInThisGroupStaticControl == null))
                {
                    this.cachedSubgroupsInThisGroupStaticControl = new StaticControl(this, GroupWizSubgroupsPage.ControlIDs.SubgroupsInThisGroupStaticControl);
                }
                return this.cachedSubgroupsInThisGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddRemoveSubgroupsButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizSubgroupsPageControls.AddRemoveSubgroupsButton
        {
            get
            {
                if ((this.cachedAddRemoveSubgroupsButton == null))
                {
                    this.cachedAddRemoveSubgroupsButton = new Button(this, GroupWizSubgroupsPage.ControlIDs.AddRemoveSubgroupsButton);
                }
                return this.cachedAddRemoveSubgroupsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseSubgroupsToAddToThisGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.ChooseSubgroupsToAddToThisGroupStaticControl
        {
            get
            {
                if ((this.cachedChooseSubgroupsToAddToThisGroupStaticControl == null))
                {
                    this.cachedChooseSubgroupsToAddToThisGroupStaticControl = new StaticControl(this, GroupWizSubgroupsPage.ControlIDs.ChooseSubgroupsToAddToThisGroupStaticControl);
                }
                return this.cachedChooseSubgroupsToAddToThisGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddSubgroupsOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.AddSubgroupsOptionalStaticControl
        {
            get
            {
                if ((this.cachedAddSubgroupsOptionalStaticControl == null))
                {
                    this.cachedAddSubgroupsOptionalStaticControl = new StaticControl(this, GroupWizSubgroupsPage.ControlIDs.AddSubgroupsOptionalStaticControl);
                }
                return this.cachedAddSubgroupsOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, GroupWizSubgroupsPage.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseOptionalSubgroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupWizSubgroupsPageControls.ChooseOptionalSubgroupsStaticControl
        {
            get
            {
                if ((this.cachedChooseOptionalSubgroupsStaticControl == null))
                {
                    this.cachedChooseOptionalSubgroupsStaticControl = new StaticControl(this, GroupWizSubgroupsPage.ControlIDs.ChooseOptionalSubgroupsStaticControl);
                }
                return this.cachedChooseOptionalSubgroupsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-cheli] 12/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupWizSubgroupsPageControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, GroupWizSubgroupsPage.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
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
        /// 	[HainingW] 3/9/2006 Created
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
        /// 	[HainingW] 3/9/2006 Created
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
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddRemoveSubgroups
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddRemoveSubgroups()
        {
            this.Controls.AddRemoveSubgroupsButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[v-cheli] 12/16/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[HainingW] 3/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            Utilities.LogMessage("GroupWizSubgroupsPage :: Init(app)");
            Window tempWindow = Init(app, Strings.DialogTitle);
            return tempWindow;
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, string title)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            Utilities.LogMessage("GroupWizSubgroupsPage :: Init(app, title)");

            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(title,
                                        StringMatchSyntax.ExactMatch,
                                        WindowClassNames.WinForms10Window8,
                                        StringMatchSyntax.WildCard,
                                        app.MainWindow,
                                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
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
                        tempWindow = new Window(title + "*", StringMatchSyntax.WildCard);
                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // Check for success
                if (tempWindow == null)
                {
                    // Log the failure
                    Utilities.LogMessage("Failed to find window with title:  '" + title + "'");
                    // Throw the existing WindowNotFound exception
                    throw;
                }
            }

            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/9/2006 Created
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
            //private const string ResourceDialogTitle = ";Create Group Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CreateGroupWizard";
            private const string ResourceDialogTitle = ";Create Group Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Group.GroupResources;CreateGroupWizardCaption";
            
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
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExplicitMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExplicitMembers = ";Explicit Members;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.InstancesPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DynamicMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDynamicMembers = ";Dynamic Members;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.MembershipFormulaPage;$this.Navigatio" +
                "nText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Subgroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSubgroups = ";Subgroups;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.SubgroupsPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludedMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludedMembers = ";Excluded Members;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.ExcludedMembersPage;$this.Navigation" +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SubgroupsInThisGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSubgroupsInThisGroup = ";Subgroups in this group:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.SubgroupsPage;formulaLabel.T" +
                "ext";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddRemoveSubgroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddRemoveSubgroups = ";Add/Remove Subgroups...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SubgroupsPage;addRemoveRulesButton.Text";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseSubgroupsToAddToThisGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseSubgroupsToAddToThisGroup = ";Choose subgroups to add to this group.;ManagedString;Microsoft.MOM.UI.Components" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Group.SubgroupsPage;" +
                "sectionDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddSubgroupsOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddSubgroupsOptional = ";Add  Subgroups (optional);ManagedString;Microsoft.MOM.UI.Components.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.SubgroupsPage;pageSectionLa" +
                "bel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseOptionalSubgroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseOptionalSubgroups = ";Choose Optional Subgroups;ManagedString;Microsoft.MOM.UI.Components.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.SubgroupsPage;$this.HeaderT" +
                "ext";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
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
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExplicitMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExplicitMembers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DynamicMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDynamicMembers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Subgroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubgroups;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludedMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludedMembers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SubgroupsInThisGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubgroupsInThisGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddRemoveSubgroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddRemoveSubgroups;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseSubgroupsToAddToThisGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseSubgroupsToAddToThisGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddSubgroupsOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddSubgroupsOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseOptionalSubgroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseOptionalSubgroups;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// 	[HainingW] 3/9/2006 Created
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
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties
            {
                get
                {
                    if ((cachedGeneralProperties == null))
                    {
                        cachedGeneralProperties = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties);
                    }
                    return cachedGeneralProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExplicitMembers translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExplicitMembers
            {
                get
                {
                    if ((cachedExplicitMembers == null))
                    {
                        cachedExplicitMembers = CoreManager.MomConsole.GetIntlStr(ResourceExplicitMembers);
                    }
                    return cachedExplicitMembers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DynamicMembers translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DynamicMembers
            {
                get
                {
                    if ((cachedDynamicMembers == null))
                    {
                        cachedDynamicMembers = CoreManager.MomConsole.GetIntlStr(ResourceDynamicMembers);
                    }
                    return cachedDynamicMembers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subgroups translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Subgroups
            {
                get
                {
                    if ((cachedSubgroups == null))
                    {
                        cachedSubgroups = CoreManager.MomConsole.GetIntlStr(ResourceSubgroups);
                    }
                    return cachedSubgroups;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludedMembers translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludedMembers
            {
                get
                {
                    if ((cachedExcludedMembers == null))
                    {
                        cachedExcludedMembers = CoreManager.MomConsole.GetIntlStr(ResourceExcludedMembers);
                    }
                    return cachedExcludedMembers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubgroupsInThisGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SubgroupsInThisGroup
            {
                get
                {
                    if ((cachedSubgroupsInThisGroup == null))
                    {
                        cachedSubgroupsInThisGroup = CoreManager.MomConsole.GetIntlStr(ResourceSubgroupsInThisGroup);
                    }
                    return cachedSubgroupsInThisGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddRemoveSubgroups translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddRemoveSubgroups
            {
                get
                {
                    if ((cachedAddRemoveSubgroups == null))
                    {
                        cachedAddRemoveSubgroups = CoreManager.MomConsole.GetIntlStr(ResourceAddRemoveSubgroups);
                    }
                    return cachedAddRemoveSubgroups;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseSubgroupsToAddToThisGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseSubgroupsToAddToThisGroup
            {
                get
                {
                    if ((cachedChooseSubgroupsToAddToThisGroup == null))
                    {
                        cachedChooseSubgroupsToAddToThisGroup = CoreManager.MomConsole.GetIntlStr(ResourceChooseSubgroupsToAddToThisGroup);
                    }
                    return cachedChooseSubgroupsToAddToThisGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddSubgroupsOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddSubgroupsOptional
            {
                get
                {
                    if ((cachedAddSubgroupsOptional == null))
                    {
                        cachedAddSubgroupsOptional = CoreManager.MomConsole.GetIntlStr(ResourceAddSubgroupsOptional);
                    }
                    return cachedAddSubgroupsOptional;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
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
            /// Exposes access to the ChooseOptionalSubgroups translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseOptionalSubgroups
            {
                get
                {
                    if ((cachedChooseOptionalSubgroups == null))
                    {
                        cachedChooseOptionalSubgroups = CoreManager.MomConsole.GetIntlStr(ResourceChooseOptionalSubgroups);
                    }
                    return cachedChooseOptionalSubgroups;
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
        /// 	[HainingW] 3/9/2006 Created
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
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExplicitMembersStaticControl
            /// </summary>
            public const string ExplicitMembersStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DynamicMembersStaticControl
            /// </summary>
            public const string DynamicMembersStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SubgroupsStaticControl
            /// </summary>
            public const string SubgroupsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExcludedMembersStaticControl
            /// </summary>
            public const string ExcludedMembersStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SubgroupsListView
            /// </summary>
            public const string SubgroupsListView = "subgroupList";
            
            /// <summary>
            /// Control ID for SubgroupsInThisGroupStaticControl
            /// </summary>
            public const string SubgroupsInThisGroupStaticControl = "formulaLabel";
            
            /// <summary>
            /// Control ID for AddRemoveSubgroupsButton
            /// </summary>
            public const string AddRemoveSubgroupsButton = "addRemoveRulesButton";
            
            /// <summary>
            /// Control ID for ChooseSubgroupsToAddToThisGroupStaticControl
            /// </summary>
            public const string ChooseSubgroupsToAddToThisGroupStaticControl = "sectionDescription";
            
            /// <summary>
            /// Control ID for AddSubgroupsOptionalStaticControl
            /// </summary>
            public const string AddSubgroupsOptionalStaticControl = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ChooseOptionalSubgroupsStaticControl
            /// </summary>
            public const string ChooseOptionalSubgroupsStaticControl = "headerLabel";

            /// <summary>
            /// Control ID for OK Button
            /// </summary>
            public const string OKButton = "okButton";
        }
        #endregion
    }
}
