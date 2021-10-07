// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WelcomeWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 Test UI Automation
// </summary>
// <history>
// 	[KellyMor] 03-Feb-06    Created
//  [KellyMor] 27-Feb-06    Updated resource strings
//  [KellyMor] 27-Apr-06    Updated Init method
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 22-Jun-06    Increased number of retries in Init to 10 from 5 for PS builds
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IWelcomeWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWelcomeWindowControls, for WelcomeWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWelcomeWindowControls
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
        /// Read-only property to access AutoOrAdvancedStaticControl
        /// </summary>
        StaticControl AutoOrAdvancedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdministratorAccountStaticControl
        /// </summary>
        StaticControl AdministratorAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunningDiscoveryStaticControl
        /// </summary>
        StaticControl RunningDiscoveryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectObjectsToManageStaticControl
        /// </summary>
        StaticControl SelectObjectsToManageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl
        /// </summary>
        StaticControl SummaryStaticControl
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
        /// Read-only property to access ConfigureAgentInstallationForComputersStaticControl
        /// </summary>
        StaticControl ConfigureAgentInstallationForComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectWhichDiscoveredObjectsYouWantToManageStaticControl
        /// </summary>
        StaticControl SelectWhichDiscoveredObjectsYouWantToManageStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiscoverComputersOrNetworkDevicesStaticControl
        /// </summary>
        StaticControl DiscoverComputersOrNetworkDevicesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThereAreThreeStepsToCompletingThisWizardStaticControl
        /// </summary>
        StaticControl ThereAreThreeStepsToCompletingThisWizardStaticControl
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
        /// Read-only property to access ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput
        /// </summary>
        StaticControl ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput
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
    /// Class to encapsulate the functionality of the Welcome/Introduction step of
    /// the Computer and Device Management Wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WelcomeWindow : Window, IWelcomeWindowControls
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
        /// Cache to hold a reference to AutoOrAdvancedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAutoOrAdvancedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdministratorAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdministratorAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunningDiscoveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunningDiscoveryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectObjectsToManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectObjectsToManageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAgentInstallationForComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAgentInstallationForComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectWhichDiscoveredObjectsYouWantToManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectWhichDiscoveredObjectsYouWantToManageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoverComputersOrNetworkDevicesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoverComputersOrNetworkDevicesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThereAreThreeStepsToCompletingThisWizardStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThereAreThreeStepsToCompletingThisWizardStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DoNotShowThisPageAgainCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDoNotShowThisPageAgainCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ToBeginTheDiscoveryProcessClickNextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToBeginTheDiscoveryProcessClickNextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput of type StaticControl
        /// </summary>
        private StaticControl cachedThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput;
        
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
        /// Default constructor
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of WelcomeWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WelcomeWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        { 
        }
        #endregion
        
        #region IWelcomeWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWelcomeWindowControls Controls
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
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWelcomeWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, WelcomeWindow.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWelcomeWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WelcomeWindow.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWelcomeWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, WelcomeWindow.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWelcomeWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WelcomeWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, WelcomeWindow.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoOrAdvancedStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.AutoOrAdvancedStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAutoOrAdvancedStaticControl == null))
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
                    this.cachedAutoOrAdvancedStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAutoOrAdvancedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdministratorAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.AdministratorAccountStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAdministratorAccountStaticControl == null))
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
                    this.cachedAdministratorAccountStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAdministratorAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunningDiscoveryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.RunningDiscoveryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRunningDiscoveryStaticControl == null))
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
                    this.cachedRunningDiscoveryStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedRunningDiscoveryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectObjectsToManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.SelectObjectsToManageStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSelectObjectsToManageStaticControl == null))
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
                    this.cachedSelectObjectsToManageStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSelectObjectsToManageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryStaticControl == null))
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
                    this.cachedSummaryStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSummaryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.IntroductionStaticControl2
        {
            get
            {
                if ((this.cachedIntroductionStaticControl2 == null))
                {
                    this.cachedIntroductionStaticControl2 = new StaticControl(this, WelcomeWindow.ControlIDs.IntroductionStaticControl2);
                }
                return this.cachedIntroductionStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAgentInstallationForComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.ConfigureAgentInstallationForComputersStaticControl
        {
            get
            {
                if ((this.cachedConfigureAgentInstallationForComputersStaticControl == null))
                {
                    this.cachedConfigureAgentInstallationForComputersStaticControl = new StaticControl(this, WelcomeWindow.ControlIDs.ConfigureAgentInstallationForComputersStaticControl);
                }
                return this.cachedConfigureAgentInstallationForComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectWhichDiscoveredObjectsYouWantToManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.SelectWhichDiscoveredObjectsYouWantToManageStaticControl
        {
            get
            {
                if ((this.cachedSelectWhichDiscoveredObjectsYouWantToManageStaticControl == null))
                {
                    this.cachedSelectWhichDiscoveredObjectsYouWantToManageStaticControl = new StaticControl(this, WelcomeWindow.ControlIDs.SelectWhichDiscoveredObjectsYouWantToManageStaticControl);
                }
                return this.cachedSelectWhichDiscoveredObjectsYouWantToManageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoverComputersOrNetworkDevicesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.DiscoverComputersOrNetworkDevicesStaticControl
        {
            get
            {
                if ((this.cachedDiscoverComputersOrNetworkDevicesStaticControl == null))
                {
                    this.cachedDiscoverComputersOrNetworkDevicesStaticControl = new StaticControl(this, WelcomeWindow.ControlIDs.DiscoverComputersOrNetworkDevicesStaticControl);
                }
                return this.cachedDiscoverComputersOrNetworkDevicesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThereAreThreeStepsToCompletingThisWizardStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.ThereAreThreeStepsToCompletingThisWizardStaticControl
        {
            get
            {
                if ((this.cachedThereAreThreeStepsToCompletingThisWizardStaticControl == null))
                {
                    this.cachedThereAreThreeStepsToCompletingThisWizardStaticControl = new StaticControl(this, WelcomeWindow.ControlIDs.ThereAreThreeStepsToCompletingThisWizardStaticControl);
                }
                return this.cachedThereAreThreeStepsToCompletingThisWizardStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoNotShowThisPageAgainCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWelcomeWindowControls.DoNotShowThisPageAgainCheckBox
        {
            get
            {
                if ((this.cachedDoNotShowThisPageAgainCheckBox == null))
                {
                    this.cachedDoNotShowThisPageAgainCheckBox = new CheckBox(this, WelcomeWindow.ControlIDs.DoNotShowThisPageAgainCheckBox);
                }
                return this.cachedDoNotShowThisPageAgainCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToBeginTheDiscoveryProcessClickNextStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.ToBeginTheDiscoveryProcessClickNextStaticControl
        {
            get
            {
                if ((this.cachedToBeginTheDiscoveryProcessClickNextStaticControl == null))
                {
                    this.cachedToBeginTheDiscoveryProcessClickNextStaticControl = new StaticControl(this, WelcomeWindow.ControlIDs.ToBeginTheDiscoveryProcessClickNextStaticControl);
                }
                return this.cachedToBeginTheDiscoveryProcessClickNextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput
        {
            get
            {
                if ((this.cachedThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput == null))
                {
                    this.cachedThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput = new StaticControl(this, WelcomeWindow.ControlIDs.ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput);
                }
                return this.cachedThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, WelcomeWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWelcomeWindowControls.IntroductionStaticControl3
        {
            get
            {
                if ((this.cachedIntroductionStaticControl3 == null))
                {
                    this.cachedIntroductionStaticControl3 = new StaticControl(this, WelcomeWindow.ControlIDs.IntroductionStaticControl3);
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
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
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
                    Strings.WindowTitle + "*",
                    StringMatchSyntax.WildCard);
            }            
            catch (Exceptions.WindowNotFoundException ex)
            {
                // try again with wildcards in the title
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 10;
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
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.WindowTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
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
            private const string ResourceWindowTitle = ";Computer and Device Management Wizard;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" + 
                "DiscoveryWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButto" +
                "n.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitl" +
                "e";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoOrAdvanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoOrAdvanced = ";Auto or Advanced?;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources.en;Discov" +
                "eryModeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministratorAccount = ";Administrator Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Co" +
                "nnectionAccountTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunningDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunningDiscovery = ";Running Discovery...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Dis" +
                "coveryProgressTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectObjectsToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectObjectsToManage = ";Select Objects to Manage;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";DiscoveryResultsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Administration.AdminResources.en;SummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction2 = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitl" +
                "e";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAgentInstallationForComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAgentInstallationForComputers = ";- Configure agent installation for computers;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administrati" +
                "on.DiscoveryWelcome;labelTitle5.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectWhichDiscoveredObjectsYouWantToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectWhichDiscoveredObjectsYouWantToManage = ";- Select which discovered objects you want to manage;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Admi" +
                "nistration.DiscoveryWelcome;labelTitle4.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoverComputersOrNetworkDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoverComputersOrNetworkDevices = ";- Discover computers or network devices;ManagedString;Microsoft.MOM.UI.Components.resources.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Di" +
                "scoveryWelcome.en;labelTitle3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThereAreThreeStepsToCompletingThisWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThereAreThreeStepsToCompletingThisWizard = ";There are three steps to completing this wizard:;ManagedString;Microsoft.MOM.UI.Components.resources.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administ" +
                "ration.DiscoveryWelcome.en;labelTitle2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoNotShowThisPageAgain = ";Do not &show this page again;ManagedString;Microsoft.MOM.UI.Components.resources.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryWelc" +
                "ome.en;checkBoxShow.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToBeginTheDiscoveryProcessClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToBeginTheDiscoveryProcessClickNext = ";To begin the Discovery process, click \"Next\";ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administrati" +
                "on.DiscoveryWelcome;labelNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput = @";This wizard will guide you through the process of discovering your network, and installing management agents on computers.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryWelcome;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction3 = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitl" +
                "e";
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
            /// Caches the translated resource string for:  AutoOrAdvanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoOrAdvanced;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunningDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunningDiscovery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectObjectsToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectObjectsToManage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAgentInstallationForComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAgentInstallationForComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectWhichDiscoveredObjectsYouWantToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectWhichDiscoveredObjectsYouWantToManage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoverComputersOrNetworkDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoverComputersOrNetworkDevices;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThereAreThreeStepsToCompletingThisWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThereAreThreeStepsToCompletingThisWizard;
            
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
            /// Caches the translated resource string for:  ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput;
            
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the AutoOrAdvanced translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoOrAdvanced
            {
                get
                {
                    if ((cachedAutoOrAdvanced == null))
                    {
                        cachedAutoOrAdvanced = CoreManager.MomConsole.GetIntlStr(ResourceAutoOrAdvanced);
                    }
                    return cachedAutoOrAdvanced;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministratorAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministratorAccount
            {
                get
                {
                    if ((cachedAdministratorAccount == null))
                    {
                        cachedAdministratorAccount = CoreManager.MomConsole.GetIntlStr(ResourceAdministratorAccount);
                    }
                    return cachedAdministratorAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunningDiscovery translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunningDiscovery
            {
                get
                {
                    if ((cachedRunningDiscovery == null))
                    {
                        cachedRunningDiscovery = CoreManager.MomConsole.GetIntlStr(ResourceRunningDiscovery);
                    }
                    return cachedRunningDiscovery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectObjectsToManage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectObjectsToManage
            {
                get
                {
                    if ((cachedSelectObjectsToManage == null))
                    {
                        cachedSelectObjectsToManage = CoreManager.MomConsole.GetIntlStr(ResourceSelectObjectsToManage);
                    }
                    return cachedSelectObjectsToManage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    return cachedSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Introduction2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the ConfigureAgentInstallationForComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAgentInstallationForComputers
            {
                get
                {
                    if ((cachedConfigureAgentInstallationForComputers == null))
                    {
                        cachedConfigureAgentInstallationForComputers = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAgentInstallationForComputers);
                    }
                    return cachedConfigureAgentInstallationForComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectWhichDiscoveredObjectsYouWantToManage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectWhichDiscoveredObjectsYouWantToManage
            {
                get
                {
                    if ((cachedSelectWhichDiscoveredObjectsYouWantToManage == null))
                    {
                        cachedSelectWhichDiscoveredObjectsYouWantToManage = CoreManager.MomConsole.GetIntlStr(ResourceSelectWhichDiscoveredObjectsYouWantToManage);
                    }
                    return cachedSelectWhichDiscoveredObjectsYouWantToManage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiscoverComputersOrNetworkDevices translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoverComputersOrNetworkDevices
            {
                get
                {
                    if ((cachedDiscoverComputersOrNetworkDevices == null))
                    {
                        cachedDiscoverComputersOrNetworkDevices = CoreManager.MomConsole.GetIntlStr(ResourceDiscoverComputersOrNetworkDevices);
                    }
                    return cachedDiscoverComputersOrNetworkDevices;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThereAreThreeStepsToCompletingThisWizard translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThereAreThreeStepsToCompletingThisWizard
            {
                get
                {
                    if ((cachedThereAreThreeStepsToCompletingThisWizard == null))
                    {
                        cachedThereAreThreeStepsToCompletingThisWizard = CoreManager.MomConsole.GetIntlStr(ResourceThereAreThreeStepsToCompletingThisWizard);
                    }
                    return cachedThereAreThreeStepsToCompletingThisWizard;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DoNotShowThisPageAgain translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput
            {
                get
                {
                    if ((cachedThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput == null))
                    {
                        cachedThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput = CoreManager.MomConsole.GetIntlStr(ResourceThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput);
                    }
                    return cachedThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
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
            /// Control ID for AutoOrAdvancedStaticControl
            /// </summary>
            public const string AutoOrAdvancedStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AdministratorAccountStaticControl
            /// </summary>
            public const string AdministratorAccountStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for RunningDiscoveryStaticControl
            /// </summary>
            public const string RunningDiscoveryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SelectObjectsToManageStaticControl
            /// </summary>
            public const string SelectObjectsToManageStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl2
            /// </summary>
            public const string IntroductionStaticControl2 = "labelTitle";
            
            /// <summary>
            /// Control ID for ConfigureAgentInstallationForComputersStaticControl
            /// </summary>
            public const string ConfigureAgentInstallationForComputersStaticControl = "labelTitle5";
            
            /// <summary>
            /// Control ID for SelectWhichDiscoveredObjectsYouWantToManageStaticControl
            /// </summary>
            public const string SelectWhichDiscoveredObjectsYouWantToManageStaticControl = "labelTitle4";
            
            /// <summary>
            /// Control ID for DiscoverComputersOrNetworkDevicesStaticControl
            /// </summary>
            public const string DiscoverComputersOrNetworkDevicesStaticControl = "labelTitle3";
            
            /// <summary>
            /// Control ID for ThereAreThreeStepsToCompletingThisWizardStaticControl
            /// </summary>
            public const string ThereAreThreeStepsToCompletingThisWizardStaticControl = "labelTitle2";
            
            /// <summary>
            /// Control ID for DoNotShowThisPageAgainCheckBox
            /// </summary>
            public const string DoNotShowThisPageAgainCheckBox = "checkBoxShow";
            
            /// <summary>
            /// Control ID for ToBeginTheDiscoveryProcessClickNextStaticControl
            /// </summary>
            public const string ToBeginTheDiscoveryProcessClickNextStaticControl = "labelNext";
            
            /// <summary>
            /// Control ID for ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput
            /// </summary>
            public const string ThisWizardWillGuideYouThroughTheProcessOfDiscoveringYourNetworkAndInstallingManagementAgentsOnComput = "labelTitle1";
            
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
