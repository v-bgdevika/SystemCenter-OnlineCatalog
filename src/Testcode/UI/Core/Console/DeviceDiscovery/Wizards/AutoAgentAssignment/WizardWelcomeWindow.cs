// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WizardWelcomeWindow.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 10/24/2007 Created
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.AutoAgentAssignment
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IWizardWelcomeWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWizardWelcomeWindowControls, for WizardWelcomeWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWizardWelcomeWindowControls
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
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Read-only property to access DomainStaticControl
        /// </summary>
        StaticControl DomainStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InclusionCriteriaStaticControl
        /// </summary>
        StaticControl InclusionCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExclusionCriteriaStaticControl
        /// </summary>
        StaticControl ExclusionCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentFailoverStaticControl
        /// </summary>
        StaticControl AgentFailoverStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan
        /// </summary>
        StaticControl NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManageAgentFailoverStaticControl
        /// </summary>
        StaticControl ManageAgentFailoverStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntroductionStaticControl2
        /// </summary>
        StaticControl IntroductionStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludeSpecificComputersStaticControl
        /// </summary>
        StaticControl ExcludeSpecificComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyCriteriaForInclusionOfComputersStaticControl
        /// </summary>
        StaticControl SpecifyCriteriaForInclusionOfComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyADomainStaticControl
        /// </summary>
        StaticControl SpecifyADomainStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThereAreFourStepsToCompletingThisWizardStaticControl
        /// </summary>
        StaticControl ThereAreFourStepsToCompletingThisWizardStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DoNotShowThisPageAgainCheckBox
        /// </summary>
        CheckBox DoNotShowThisPageAgainCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToBeginTheDiscoveryProcessClickNextStaticControl
        /// </summary>
        StaticControl ToBeginTheDiscoveryProcessClickNextStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt
        /// </summary>
        StaticControl ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt
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
        /// Read-only property to access IntroductionStaticControl3
        /// </summary>
        StaticControl IntroductionStaticControl3
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add window functionality description here.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WizardWelcomeWindow : Window, IWizardWelcomeWindowControls
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
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InclusionCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInclusionCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExclusionCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExclusionCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgentFailoverStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgentFailoverStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan of type StaticControl
        /// </summary>
        private StaticControl cachedNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan;
        
        /// <summary>
        /// Cache to hold a reference to ManageAgentFailoverStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManageAgentFailoverStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeSpecificComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludeSpecificComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyCriteriaForInclusionOfComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyCriteriaForInclusionOfComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyADomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyADomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThereAreFourStepsToCompletingThisWizardStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThereAreFourStepsToCompletingThisWizardStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DoNotShowThisPageAgainCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDoNotShowThisPageAgainCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ToBeginTheDiscoveryProcessClickNextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToBeginTheDiscoveryProcessClickNextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt of type StaticControl
        /// </summary>
        private StaticControl cachedThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl3;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of WizardWelcomeWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WizardWelcomeWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IWizardWelcomeWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWizardWelcomeWindowControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox DoNotShowThisPageAgain
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool DoNotShowThisPageAgain
        {
            get
            {
                return this.Controls.DoNotShowThisPageAgainCheckBox.Checked;
            }
            
            set
            {
                this.Controls.DoNotShowThisPageAgainCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardWelcomeWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, WizardWelcomeWindow.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardWelcomeWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WizardWelcomeWindow.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardWelcomeWindowControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, WizardWelcomeWindow.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardWelcomeWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WizardWelcomeWindow.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, WizardWelcomeWindow.ControlIDs.IntroductionStaticControl);
                }
                
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.DomainStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDomainStaticControl == null))
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
                    this.cachedDomainStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InclusionCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.InclusionCriteriaStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedInclusionCriteriaStaticControl == null))
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
                    this.cachedInclusionCriteriaStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedInclusionCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExclusionCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.ExclusionCriteriaStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExclusionCriteriaStaticControl == null))
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
                    this.cachedExclusionCriteriaStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedExclusionCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentFailoverStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.AgentFailoverStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAgentFailoverStaticControl == null))
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
                    this.cachedAgentFailoverStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedAgentFailoverStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan
        {
            get
            {
                if ((this.cachedNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan == null))
                {
                    this.cachedNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan = new StaticControl(this, WizardWelcomeWindow.ControlIDs.NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan);
                }
                
                return this.cachedNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManageAgentFailoverStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.ManageAgentFailoverStaticControl
        {
            get
            {
                if ((this.cachedManageAgentFailoverStaticControl == null))
                {
                    this.cachedManageAgentFailoverStaticControl = new StaticControl(this, WizardWelcomeWindow.ControlIDs.ManageAgentFailoverStaticControl);
                }
                
                return this.cachedManageAgentFailoverStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.IntroductionStaticControl2
        {
            get
            {
                if ((this.cachedIntroductionStaticControl2 == null))
                {
                    this.cachedIntroductionStaticControl2 = new StaticControl(this, WizardWelcomeWindow.ControlIDs.IntroductionStaticControl2);
                }
                
                return this.cachedIntroductionStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeSpecificComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.ExcludeSpecificComputersStaticControl
        {
            get
            {
                if ((this.cachedExcludeSpecificComputersStaticControl == null))
                {
                    this.cachedExcludeSpecificComputersStaticControl = new StaticControl(this, WizardWelcomeWindow.ControlIDs.ExcludeSpecificComputersStaticControl);
                }
                
                return this.cachedExcludeSpecificComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyCriteriaForInclusionOfComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.SpecifyCriteriaForInclusionOfComputersStaticControl
        {
            get
            {
                if ((this.cachedSpecifyCriteriaForInclusionOfComputersStaticControl == null))
                {
                    this.cachedSpecifyCriteriaForInclusionOfComputersStaticControl = new StaticControl(this, WizardWelcomeWindow.ControlIDs.SpecifyCriteriaForInclusionOfComputersStaticControl);
                }
                
                return this.cachedSpecifyCriteriaForInclusionOfComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyADomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.SpecifyADomainStaticControl
        {
            get
            {
                if ((this.cachedSpecifyADomainStaticControl == null))
                {
                    this.cachedSpecifyADomainStaticControl = new StaticControl(this, WizardWelcomeWindow.ControlIDs.SpecifyADomainStaticControl);
                }
                
                return this.cachedSpecifyADomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThereAreFourStepsToCompletingThisWizardStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.ThereAreFourStepsToCompletingThisWizardStaticControl
        {
            get
            {
                if ((this.cachedThereAreFourStepsToCompletingThisWizardStaticControl == null))
                {
                    this.cachedThereAreFourStepsToCompletingThisWizardStaticControl = new StaticControl(this, WizardWelcomeWindow.ControlIDs.ThereAreFourStepsToCompletingThisWizardStaticControl);
                }
                
                return this.cachedThereAreFourStepsToCompletingThisWizardStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoNotShowThisPageAgainCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWizardWelcomeWindowControls.DoNotShowThisPageAgainCheckBox
        {
            get
            {
                if ((this.cachedDoNotShowThisPageAgainCheckBox == null))
                {
                    this.cachedDoNotShowThisPageAgainCheckBox = new CheckBox(this, WizardWelcomeWindow.ControlIDs.DoNotShowThisPageAgainCheckBox);
                }
                
                return this.cachedDoNotShowThisPageAgainCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToBeginTheDiscoveryProcessClickNextStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.ToBeginTheDiscoveryProcessClickNextStaticControl
        {
            get
            {
                if ((this.cachedToBeginTheDiscoveryProcessClickNextStaticControl == null))
                {
                    this.cachedToBeginTheDiscoveryProcessClickNextStaticControl = new StaticControl(this, WizardWelcomeWindow.ControlIDs.ToBeginTheDiscoveryProcessClickNextStaticControl);
                }
                
                return this.cachedToBeginTheDiscoveryProcessClickNextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt
        {
            get
            {
                if ((this.cachedThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt == null))
                {
                    this.cachedThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt = new StaticControl(this, WizardWelcomeWindow.ControlIDs.ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt);
                }
                
                return this.cachedThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, WizardWelcomeWindow.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardWelcomeWindowControls.IntroductionStaticControl3
        {
            get
            {
                if ((this.cachedIntroductionStaticControl3 == null))
                {
                    this.cachedIntroductionStaticControl3 = new StaticControl(this, WizardWelcomeWindow.ControlIDs.IntroductionStaticControl3);
                }
                
                return this.cachedIntroductionStaticControl3;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
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
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DoNotShowThisPageAgain
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDoNotShowThisPageAgain()
        {
            this.Controls.DoNotShowThisPageAgainCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        /// <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow =
                    new Window(
                        Strings.WindowTitle,
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinForms10Window8,
                        StringMatchSyntax.ExactMatch,
                        ownerWindow,
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0;
                    ((null == tempWindow) && (numberOfTries < maxTries));
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.WindowTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title := '" +
                        Strings.WindowTitle +
                        "'");

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }

            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowTitle =
                ";Agent Assignment and Failover Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ADIntegrationWizardCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious =
                ";< &Previous" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";previousButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext =
                ";&Next >" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel" +
                ";nextButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate =
                ";&Create;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework" +
                ";buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp =
                ";Help" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework" +
                ";buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction =
                ";Introduction" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";WelcomeTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDomain =
                ";Domain" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ViewColumnDomain";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInclusionCriteria =
                ";Inclusion Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;InclusionRuleTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExclusionCriteria =
                ";Exclusion Criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ExclusionRuleTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentFailover =
                ";Agent Failover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AgentFailoverTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan = @";Note: The MOMADAdmin.exe command line tool must be run by a domain administrator before running this wizard. This tool can be found in the System Center Operations Manager 2007 direcotry, or on the CD in the 'Support Tools' directory.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ADRuleIntroduction;linkLabelNote.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManageAgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManageAgentFailover =
                ";- Manage agent failover" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ADRuleIntroduction" +
                ";labelTitle6.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction2 =
                ";Introduction" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";WelcomeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludeSpecificComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludeSpecificComputers =
                ";- Exclude specific computers" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ADRuleIntroduction" +
                ";labelTitle5.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyCriteriaForInclusionOfComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyCriteriaForInclusionOfComputers =
                ";- Specify criteria for inclusion of computers" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ADRuleIntroduction" +
                ";labelTitle4.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyADomain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyADomain =
                ";- Specify a domain" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ADRuleIntroduction" +
                ";labelTitle3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThereAreFourStepsToCompletingThisWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThereAreFourStepsToCompletingThisWizard =
                ";There are four steps to completing this wizard:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ADRuleIntroduction" +
                ";labelTitle2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoNotShowThisPageAgain =
                ";Do not &show this page again" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ADRuleIntroduction" +
                ";checkBoxShow.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToBeginTheDiscoveryProcessClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToBeginTheDiscoveryProcessClickNext =
                ";To begin the Discovery process, click \"Next\"" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryWelcome" +
                ";labelNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory = @";This wizard will guide you through the process of assigning agents to this management server using Active Directory.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ADIntegration.ADRuleIntroduction;labelTitle1.Text";
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction3 =
                ";Introduction" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";WelcomeTitle";

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
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;
            
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
            /// Caches the translated resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInclusionCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExclusionCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExclusionCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentFailover;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManageAgentFailover
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManageAgentFailover;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludeSpecificComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludeSpecificComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyCriteriaForInclusionOfComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyCriteriaForInclusionOfComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyADomain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyADomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThereAreFourStepsToCompletingThisWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThereAreFourStepsToCompletingThisWizard;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoNotShowThisPageAgain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToBeginTheDiscoveryProcessClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToBeginTheDiscoveryProcessClickNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction3;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    
                    return cachedCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the Domain translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Domain
            {
                get
                {
                    if ((cachedDomain == null))
                    {
                        cachedDomain = CoreManager.MomConsole.GetIntlStr(ResourceDomain);
                    }
                    
                    return cachedDomain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InclusionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InclusionCriteria
            {
                get
                {
                    if ((cachedInclusionCriteria == null))
                    {
                        cachedInclusionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceInclusionCriteria);
                    }
                    
                    return cachedInclusionCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExclusionCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExclusionCriteria
            {
                get
                {
                    if ((cachedExclusionCriteria == null))
                    {
                        cachedExclusionCriteria = CoreManager.MomConsole.GetIntlStr(ResourceExclusionCriteria);
                    }
                    
                    return cachedExclusionCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AgentFailover translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentFailover
            {
                get
                {
                    if ((cachedAgentFailover == null))
                    {
                        cachedAgentFailover = CoreManager.MomConsole.GetIntlStr(ResourceAgentFailover);
                    }
                    
                    return cachedAgentFailover;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan
            {
                get
                {
                    if ((cachedNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan == null))
                    {
                        cachedNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan = CoreManager.MomConsole.GetIntlStr(ResourceNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan);
                    }
                    
                    return cachedNoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManageAgentFailover translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManageAgentFailover
            {
                get
                {
                    if ((cachedManageAgentFailover == null))
                    {
                        cachedManageAgentFailover = CoreManager.MomConsole.GetIntlStr(ResourceManageAgentFailover);
                    }
                    
                    return cachedManageAgentFailover;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Introduction2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction2
            {
                get
                {
                    if ((cachedIntroduction2 == null))
                    {
                        cachedIntroduction2 = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction2);
                    }
                    
                    return cachedIntroduction2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludeSpecificComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludeSpecificComputers
            {
                get
                {
                    if ((cachedExcludeSpecificComputers == null))
                    {
                        cachedExcludeSpecificComputers = CoreManager.MomConsole.GetIntlStr(ResourceExcludeSpecificComputers);
                    }
                    
                    return cachedExcludeSpecificComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyCriteriaForInclusionOfComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyCriteriaForInclusionOfComputers
            {
                get
                {
                    if ((cachedSpecifyCriteriaForInclusionOfComputers == null))
                    {
                        cachedSpecifyCriteriaForInclusionOfComputers = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyCriteriaForInclusionOfComputers);
                    }
                    
                    return cachedSpecifyCriteriaForInclusionOfComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyADomain translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyADomain
            {
                get
                {
                    if ((cachedSpecifyADomain == null))
                    {
                        cachedSpecifyADomain = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyADomain);
                    }
                    
                    return cachedSpecifyADomain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThereAreFourStepsToCompletingThisWizard translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThereAreFourStepsToCompletingThisWizard
            {
                get
                {
                    if ((cachedThereAreFourStepsToCompletingThisWizard == null))
                    {
                        cachedThereAreFourStepsToCompletingThisWizard = CoreManager.MomConsole.GetIntlStr(ResourceThereAreFourStepsToCompletingThisWizard);
                    }
                    
                    return cachedThereAreFourStepsToCompletingThisWizard;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DoNotShowThisPageAgain translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DoNotShowThisPageAgain
            {
                get
                {
                    if ((cachedDoNotShowThisPageAgain == null))
                    {
                        cachedDoNotShowThisPageAgain = CoreManager.MomConsole.GetIntlStr(ResourceDoNotShowThisPageAgain);
                    }
                    
                    return cachedDoNotShowThisPageAgain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToBeginTheDiscoveryProcessClickNext translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToBeginTheDiscoveryProcessClickNext
            {
                get
                {
                    if ((cachedToBeginTheDiscoveryProcessClickNext == null))
                    {
                        cachedToBeginTheDiscoveryProcessClickNext = CoreManager.MomConsole.GetIntlStr(ResourceToBeginTheDiscoveryProcessClickNext);
                    }
                    
                    return cachedToBeginTheDiscoveryProcessClickNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory
            {
                get
                {
                    if ((cachedThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory == null))
                    {
                        cachedThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory = CoreManager.MomConsole.GetIntlStr(ResourceThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory);
                    }
                    
                    return cachedThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the Introduction3 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction3
            {
                get
                {
                    if ((cachedIntroduction3 == null))
                    {
                        cachedIntroduction3 = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction3);
                    }
                    
                    return cachedIntroduction3;
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
        /// 	[KellyMor] 10/24/2007 Created
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
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl
            /// </summary>
            public const string IntroductionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DomainStaticControl
            /// </summary>
            public const string DomainStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for InclusionCriteriaStaticControl
            /// </summary>
            public const string InclusionCriteriaStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExclusionCriteriaStaticControl
            /// </summary>
            public const string ExclusionCriteriaStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AgentFailoverStaticControl
            /// </summary>
            public const string AgentFailoverStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan
            /// </summary>
            public const string NoteTheMOMADAdminexeCommandLineToolMustBeRunByADomainAdministratorBeforeRunningThisWizardThisToolCan = "linkLabelNote";
            
            /// <summary>
            /// Control ID for ManageAgentFailoverStaticControl
            /// </summary>
            public const string ManageAgentFailoverStaticControl = "labelTitle6";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl2
            /// </summary>
            public const string IntroductionStaticControl2 = "labelTitle";
            
            /// <summary>
            /// Control ID for ExcludeSpecificComputersStaticControl
            /// </summary>
            public const string ExcludeSpecificComputersStaticControl = "labelTitle5";
            
            /// <summary>
            /// Control ID for SpecifyCriteriaForInclusionOfComputersStaticControl
            /// </summary>
            public const string SpecifyCriteriaForInclusionOfComputersStaticControl = "labelTitle4";
            
            /// <summary>
            /// Control ID for SpecifyADomainStaticControl
            /// </summary>
            public const string SpecifyADomainStaticControl = "labelTitle3";
            
            /// <summary>
            /// Control ID for ThereAreFourStepsToCompletingThisWizardStaticControl
            /// </summary>
            public const string ThereAreFourStepsToCompletingThisWizardStaticControl = "labelTitle2";
            
            /// <summary>
            /// Control ID for DoNotShowThisPageAgainCheckBox
            /// </summary>
            public const string DoNotShowThisPageAgainCheckBox = "checkBoxShow";
            
            /// <summary>
            /// Control ID for ToBeginTheDiscoveryProcessClickNextStaticControl
            /// </summary>
            public const string ToBeginTheDiscoveryProcessClickNextStaticControl = "labelNext";
            
            /// <summary>
            /// Control ID for ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt
            /// </summary>
            public const string ThisWizardWillGuideYouThroughTheProcessOfAssigningAgentsToThisManagementServerUsingActiveDirectorySt = "labelTitle1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl3
            /// </summary>
            public const string IntroductionStaticControl3 = "headerLabel";
        }
        #endregion
    }
}
