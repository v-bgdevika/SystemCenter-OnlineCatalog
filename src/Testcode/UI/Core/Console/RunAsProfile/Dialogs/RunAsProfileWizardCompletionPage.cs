// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunAsProfileWizardCompletionPage.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	RunAs Wizard Completion Page.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[nathd] 1/30/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsProfile
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IRunAsProfileWizardCompletionPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunAsProfileWizardCompletionPageControls, for RunAsProfileWizardCompletionPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[nathd] 1/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunAsProfileWizardCompletionPageControls
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
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
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
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AssociationsStaticControl
        /// </summary>
        StaticControl AssociationsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AccountDistributionStaticControl
        /// </summary>
        StaticControl AccountDistributionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MoreAboutRunAsAccountDistributionStaticControl
        /// </summary>
        StaticControl MoreAboutRunAsAccountDistributionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MoreSecureRunAsAccountsStaticControl
        /// </summary>
        StaticControl MoreSecureRunAsAccountsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MoreSecureRunAsAccountsPropertyGridView
        /// </summary>
        PropertyGridView MoreSecureRunAsAccountsPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR
        /// </summary>
        StaticControl ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouHaveSuccessfullyCreatedANewRunAsProfileStaticControl
        /// </summary>
        StaticControl YouHaveSuccessfullyCreatedANewRunAsProfileStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AssociationsStaticControl2
        /// </summary>
        StaticControl AssociationsStaticControl2
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
        /// Read-only property to access AccountDistributionStaticControl2
        /// </summary>
        StaticControl AccountDistributionStaticControl2
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
    /// 	[nathd] 1/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RunAsProfileWizardCompletionPage : Window, IRunAsProfileWizardCompletionPageControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        // Cache to hold a reference to the active window of type Maui.Core.Window
        // private static Window activeWindow;
        
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
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AssociationsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAssociationsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AccountDistributionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAccountDistributionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MoreAboutRunAsAccountDistributionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMoreAboutRunAsAccountDistributionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MoreSecureRunAsAccountsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMoreSecureRunAsAccountsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MoreSecureRunAsAccountsPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedMoreSecureRunAsAccountsPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR of type StaticControl
        /// </summary>
        private StaticControl cachedToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR;
        
        /// <summary>
        /// Cache to hold a reference to YouHaveSuccessfullyCreatedANewRunAsProfileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouHaveSuccessfullyCreatedANewRunAsProfileStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AssociationsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAssociationsStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AccountDistributionStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAccountDistributionStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of RunAsProfileWizardCompletionPage of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunAsProfileWizardCompletionPage(MomConsoleApp ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRunAsProfileWizardCompletionPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunAsProfileWizardCompletionPageControls Controls
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
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsProfileWizardCompletionPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, RunAsProfileWizardCompletionPage.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsProfileWizardCompletionPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, RunAsProfileWizardCompletionPage.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsProfileWizardCompletionPageControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, RunAsProfileWizardCompletionPage.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsProfileWizardCompletionPageControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, RunAsProfileWizardCompletionPage.ControlIDs.CloseButton);
                }
                
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, RunAsProfileWizardCompletionPage.ControlIDs.IntroductionStaticControl);
                }
                
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.GeneralStaticControl
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AssociationsStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.AssociationsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAssociationsStaticControl == null))
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
                    this.cachedAssociationsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedAssociationsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AccountDistributionStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.AccountDistributionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAccountDistributionStaticControl == null))
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
                    this.cachedAccountDistributionStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedAccountDistributionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreAboutRunAsAccountDistributionStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.MoreAboutRunAsAccountDistributionStaticControl
        {
            get
            {
                if ((this.cachedMoreAboutRunAsAccountDistributionStaticControl == null))
                {
                    this.cachedMoreAboutRunAsAccountDistributionStaticControl = new StaticControl(this, RunAsProfileWizardCompletionPage.ControlIDs.MoreAboutRunAsAccountDistributionStaticControl);
                }
                
                return this.cachedMoreAboutRunAsAccountDistributionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreSecureRunAsAccountsStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.MoreSecureRunAsAccountsStaticControl
        {
            get
            {
                if ((this.cachedMoreSecureRunAsAccountsStaticControl == null))
                {
                    this.cachedMoreSecureRunAsAccountsStaticControl = new StaticControl(this, RunAsProfileWizardCompletionPage.ControlIDs.MoreSecureRunAsAccountsStaticControl);
                }
                
                return this.cachedMoreSecureRunAsAccountsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreSecureRunAsAccountsPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IRunAsProfileWizardCompletionPageControls.MoreSecureRunAsAccountsPropertyGridView
        {
            get
            {
                if ((this.cachedMoreSecureRunAsAccountsPropertyGridView == null))
                {
                    this.cachedMoreSecureRunAsAccountsPropertyGridView = new PropertyGridView(this, RunAsProfileWizardCompletionPage.ControlIDs.MoreSecureRunAsAccountsPropertyGridView);
                }
                
                return this.cachedMoreSecureRunAsAccountsPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR
        {
            get
            {
                if ((this.cachedToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR == null))
                {
                    this.cachedToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR = new StaticControl(this, RunAsProfileWizardCompletionPage.ControlIDs.ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR);
                }
                
                return this.cachedToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouHaveSuccessfullyCreatedANewRunAsProfileStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.YouHaveSuccessfullyCreatedANewRunAsProfileStaticControl
        {
            get
            {
                if ((this.cachedYouHaveSuccessfullyCreatedANewRunAsProfileStaticControl == null))
                {
                    this.cachedYouHaveSuccessfullyCreatedANewRunAsProfileStaticControl = new StaticControl(this, RunAsProfileWizardCompletionPage.ControlIDs.YouHaveSuccessfullyCreatedANewRunAsProfileStaticControl);
                }
                
                return this.cachedYouHaveSuccessfullyCreatedANewRunAsProfileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AssociationsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.AssociationsStaticControl2
        {
            get
            {
                if ((this.cachedAssociationsStaticControl2 == null))
                {
                    this.cachedAssociationsStaticControl2 = new StaticControl(this, RunAsProfileWizardCompletionPage.ControlIDs.AssociationsStaticControl2);
                }
                
                return this.cachedAssociationsStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, RunAsProfileWizardCompletionPage.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AccountDistributionStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardCompletionPageControls.AccountDistributionStaticControl2
        {
            get
            {
                if ((this.cachedAccountDistributionStaticControl2 == null))
                {
                    this.cachedAccountDistributionStaticControl2 = new StaticControl(this, RunAsProfileWizardCompletionPage.ControlIDs.AccountDistributionStaticControl2);
                }
                
                return this.cachedAccountDistributionStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
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
        /// 	[nathd] 1/30/2009 Created
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
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="ownerWindow">MomConsoleApp class instance that owns this window.</param>)
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(MomConsoleApp ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = new Window(Strings.WindowTitle, StringMatchSyntax.WildCard, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, ownerWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.WindowTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

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
        /// 	[nathd] 1/30/2009 Created
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
            private const string ResourceWindowTitle = ";Run As Profile Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsProfileWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";&Create;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateTe" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Close;ManagedString;Corgent.Diagramming.Toolbox.dll;Corgent.Diagramming.Toolbox." +
                "Properties.Resources;Close";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Wel" +
                "comeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Associations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAssociations = ";Associations;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Run" +
                "AsProfileAssociationsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AccountDistribution
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAccountDistribution = ";Account Distribution;ManagedString;Microsoft.EnterpriseManagement.UI.Administrat" +
                "ion.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResou" +
                "rces;RunAsProfileDistributionPage";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MoreAboutRunAsAccountDistribution
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoreAboutRunAsAccountDistribution = ";More about Run As account distribution;ManagedString;Microsoft.EnterpriseManagem" +
                "ent.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Adminis" +
                "tration.RunAsProfile.RunAsProfileDistributionPage;linkLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MoreSecureRunAsAccounts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoreSecureRunAsAccounts = ";More secure Run As accounts:;ManagedString;Microsoft.EnterpriseManagement.UI.Adm" +
                "inistration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Ru" +
                "nAsProfile.RunAsProfileDistributionPage;label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR = @";To ensure successful monitoring, you must update the distribution of all more-secure Run As accounts specified in this Run As profile, listed below.  Click a Run As account to update its distribution.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileDistributionPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouHaveSuccessfullyCreatedANewRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouHaveSuccessfullyCreatedANewRunAsProfile = ";You have successfully created a new Run As profile.;ManagedString;Microsoft.Ente" +
                "rpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Intern" +
                "al.UI.Administration.RunAsProfile.RunAsProfileDistributionPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Associations2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAssociations2 = ";Associations;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Run" +
                "AsProfileAssociationsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;HelpSubFold" +
                "erName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AccountDistribution2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAccountDistribution2 = ";Account Distribution;ManagedString;Microsoft.EnterpriseManagement.UI.Administrat" +
                "ion.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResou" +
                "rces;RunAsProfileDistributionPage";
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
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Associations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAssociations;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AccountDistribution
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAccountDistribution;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MoreAboutRunAsAccountDistribution
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreAboutRunAsAccountDistribution;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MoreSecureRunAsAccounts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreSecureRunAsAccounts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouHaveSuccessfullyCreatedANewRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouHaveSuccessfullyCreatedANewRunAsProfile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Associations2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAssociations2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AccountDistribution2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAccountDistribution2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// 	[nathd] 1/30/2009 Created
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
            /// 	[nathd] 1/30/2009 Created
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
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    if ((cachedClose == null))
                    {
                        cachedClose = CoreManager.MomConsole.GetIntlStr(ResourceClose);
                    }
                    
                    return cachedClose;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Introduction translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the Associations translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Associations
            {
                get
                {
                    if ((cachedAssociations == null))
                    {
                        cachedAssociations = CoreManager.MomConsole.GetIntlStr(ResourceAssociations);
                    }
                    
                    return cachedAssociations;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AccountDistribution translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AccountDistribution
            {
                get
                {
                    if ((cachedAccountDistribution == null))
                    {
                        cachedAccountDistribution = CoreManager.MomConsole.GetIntlStr(ResourceAccountDistribution);
                    }
                    
                    return cachedAccountDistribution;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MoreAboutRunAsAccountDistribution translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreAboutRunAsAccountDistribution
            {
                get
                {
                    if ((cachedMoreAboutRunAsAccountDistribution == null))
                    {
                        cachedMoreAboutRunAsAccountDistribution = CoreManager.MomConsole.GetIntlStr(ResourceMoreAboutRunAsAccountDistribution);
                    }
                    
                    return cachedMoreAboutRunAsAccountDistribution;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MoreSecureRunAsAccounts translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreSecureRunAsAccounts
            {
                get
                {
                    if ((cachedMoreSecureRunAsAccounts == null))
                    {
                        cachedMoreSecureRunAsAccounts = CoreManager.MomConsole.GetIntlStr(ResourceMoreSecureRunAsAccounts);
                    }
                    
                    return cachedMoreSecureRunAsAccounts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR
            {
                get
                {
                    if ((cachedToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR == null))
                    {
                        cachedToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR = CoreManager.MomConsole.GetIntlStr(ResourceToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR);
                    }
                    
                    return cachedToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouHaveSuccessfullyCreatedANewRunAsProfile translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouHaveSuccessfullyCreatedANewRunAsProfile
            {
                get
                {
                    if ((cachedYouHaveSuccessfullyCreatedANewRunAsProfile == null))
                    {
                        cachedYouHaveSuccessfullyCreatedANewRunAsProfile = CoreManager.MomConsole.GetIntlStr(ResourceYouHaveSuccessfullyCreatedANewRunAsProfile);
                    }
                    
                    return cachedYouHaveSuccessfullyCreatedANewRunAsProfile;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Associations2 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Associations2
            {
                get
                {
                    if ((cachedAssociations2 == null))
                    {
                        cachedAssociations2 = CoreManager.MomConsole.GetIntlStr(ResourceAssociations2);
                    }
                    
                    return cachedAssociations2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the AccountDistribution2 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AccountDistribution2
            {
                get
                {
                    if ((cachedAccountDistribution2 == null))
                    {
                        cachedAccountDistribution2 = CoreManager.MomConsole.GetIntlStr(ResourceAccountDistribution2);
                    }
                    
                    return cachedAccountDistribution2;
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
        /// 	[nathd] 1/30/2009 Created
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
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "cancelButton";

            /// <summary>
            /// Control ID for IntroductionStaticControl
            /// </summary>
            public const string IntroductionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AssociationsStaticControl
            /// </summary>
            public const string AssociationsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AccountDistributionStaticControl
            /// </summary>
            public const string AccountDistributionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for MoreAboutRunAsAccountDistributionStaticControl
            /// </summary>
            public const string MoreAboutRunAsAccountDistributionStaticControl = "linkLabel1";
            
            /// <summary>
            /// Control ID for MoreSecureRunAsAccountsStaticControl
            /// </summary>
            public const string MoreSecureRunAsAccountsStaticControl = "label3";
            
            /// <summary>
            /// Control ID for MoreSecureRunAsAccountsPropertyGridView
            /// </summary>
            public const string MoreSecureRunAsAccountsPropertyGridView = "accountsGrid";
            
            /// <summary>
            /// Control ID for ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR
            /// </summary>
            public const string ToEnsureSuccessfulMonitoringYouMustUpdateTheDistributionOfAllMoreSecureRunAsAccountsSpecifiedInThisR = "label2";
            
            /// <summary>
            /// Control ID for YouHaveSuccessfullyCreatedANewRunAsProfileStaticControl
            /// </summary>
            public const string YouHaveSuccessfullyCreatedANewRunAsProfileStaticControl = "label1";
            
            /// <summary>
            /// Control ID for AssociationsStaticControl2
            /// </summary>
            public const string AssociationsStaticControl2 = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for AccountDistributionStaticControl2
            /// </summary>
            public const string AccountDistributionStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
