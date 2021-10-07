// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunAsProfileWizardIntroductionPage.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
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
    
    #region Interface Definition - IRunAsProfileWizardDistributionPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunAsProfileWizardDistributionPageControls, for RunAsProfileWizardDistributionPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[nathd] 1/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunAsProfileWizardDistributionPageControls
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
        /// Read-only property to access IntroductionStaticControl2
        /// </summary>
        StaticControl IntroductionStaticControl2
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
        /// Read-only property to access ToBeginTheCreateRunAsProfileClickNextStaticControl
        /// </summary>
        StaticControl ToBeginTheCreateRunAsProfileClickNextStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
        /// </summary>
        StaticControl UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
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
    /// 	[nathd] 1/30/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RunAsProfileWizardDistributionPage : Window, IRunAsProfileWizardDistributionPageControls
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
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
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
        /// Cache to hold a reference to IntroductionStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to DoNotShowThisPageAgainCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDoNotShowThisPageAgainCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ToBeginTheCreateRunAsProfileClickNextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToBeginTheCreateRunAsProfileClickNextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet of type StaticControl
        /// </summary>
        private StaticControl cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet;
        
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
        /// Owner of RunAsProfileWizardDistributionPage of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunAsProfileWizardDistributionPage(MomConsoleApp ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRunAsProfileWizardDistributionPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunAsProfileWizardDistributionPageControls Controls
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
        /// 	[nathd] 1/30/2009 Created
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
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsProfileWizardDistributionPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, RunAsProfileWizardDistributionPage.ControlIDs.PreviousButton);
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
        Button IRunAsProfileWizardDistributionPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, RunAsProfileWizardDistributionPage.ControlIDs.NextButton);
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
        Button IRunAsProfileWizardDistributionPageControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, RunAsProfileWizardDistributionPage.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsProfileWizardDistributionPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RunAsProfileWizardDistributionPage.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
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
        StaticControl IRunAsProfileWizardDistributionPageControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, RunAsProfileWizardDistributionPage.ControlIDs.IntroductionStaticControl);
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
        StaticControl IRunAsProfileWizardDistributionPageControls.GeneralStaticControl
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
        StaticControl IRunAsProfileWizardDistributionPageControls.AssociationsStaticControl
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
        StaticControl IRunAsProfileWizardDistributionPageControls.AccountDistributionStaticControl
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
        ///  Exposes access to the IntroductionStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardDistributionPageControls.IntroductionStaticControl2
        {
            get
            {
                if ((this.cachedIntroductionStaticControl2 == null))
                {
                    this.cachedIntroductionStaticControl2 = new StaticControl(this, RunAsProfileWizardDistributionPage.ControlIDs.IntroductionStaticControl2);
                }
                
                return this.cachedIntroductionStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoNotShowThisPageAgainCheckBox control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRunAsProfileWizardDistributionPageControls.DoNotShowThisPageAgainCheckBox
        {
            get
            {
                if ((this.cachedDoNotShowThisPageAgainCheckBox == null))
                {
                    this.cachedDoNotShowThisPageAgainCheckBox = new CheckBox(this, RunAsProfileWizardDistributionPage.ControlIDs.DoNotShowThisPageAgainCheckBox);
                }
                
                return this.cachedDoNotShowThisPageAgainCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToBeginTheCreateRunAsProfileClickNextStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardDistributionPageControls.ToBeginTheCreateRunAsProfileClickNextStaticControl
        {
            get
            {
                if ((this.cachedToBeginTheCreateRunAsProfileClickNextStaticControl == null))
                {
                    this.cachedToBeginTheCreateRunAsProfileClickNextStaticControl = new StaticControl(this, RunAsProfileWizardDistributionPage.ControlIDs.ToBeginTheCreateRunAsProfileClickNextStaticControl);
                }
                
                return this.cachedToBeginTheCreateRunAsProfileClickNextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardDistributionPageControls.UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
        {
            get
            {
                if ((this.cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet == null))
                {
                    this.cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet = new StaticControl(this, RunAsProfileWizardDistributionPage.ControlIDs.UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet);
                }
                
                return this.cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet;
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
        StaticControl IRunAsProfileWizardDistributionPageControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, RunAsProfileWizardDistributionPage.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsProfileWizardDistributionPageControls.IntroductionStaticControl3
        {
            get
            {
                if ((this.cachedIntroductionStaticControl3 == null))
                {
                    this.cachedIntroductionStaticControl3 = new StaticControl(this, RunAsProfileWizardDistributionPage.ControlIDs.IntroductionStaticControl3);
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
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[nathd] 1/30/2009 Created
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
        /// 	[nathd] 1/30/2009 Created
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
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
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
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
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
            /// Contains resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction2 = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Wel" +
                "comeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoNotShowThisPageAgain = ";Do not &show this page again;ManagedString;Microsoft.EnterpriseManagement.UI.Adm" +
                "inistration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Ru" +
                "nAsProfile.ProfileIntroduction;checkBoxShow.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToBeginTheCreateRunAsProfileClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToBeginTheCreateRunAsProfileClickNext = ";To begin the create \'Run As Profile\', click \"Next\";ManagedString;Microsoft.Enter" +
                "priseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Interna" +
                "l.UI.Administration.RunAsProfile.ProfileIntroduction;labelNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet = "Use this wizard to create a Run As Profile and associate it with one or more Run " +
                "As Accounts. If you have not yet created a set of Run As Accounts for the Run As" +
                " Profile, create one before you run this wizard.\r\n\r\nRun As Profiles are used wit" +
                "h Tasks, Rules";
            
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
            /// Contains resource string for:  Introduction3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction3 = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Wel" +
                "comeTitle";
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
            /// Caches the translated resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoNotShowThisPageAgain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToBeginTheCreateRunAsProfileClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToBeginTheCreateRunAsProfileClickNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet;
            
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the Introduction2 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the DoNotShowThisPageAgain translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Exposes access to the ToBeginTheCreateRunAsProfileClickNext translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToBeginTheCreateRunAsProfileClickNext
            {
                get
                {
                    if ((cachedToBeginTheCreateRunAsProfileClickNext == null))
                    {
                        cachedToBeginTheCreateRunAsProfileClickNext = CoreManager.MomConsole.GetIntlStr(ResourceToBeginTheCreateRunAsProfileClickNext);
                    }
                    
                    return cachedToBeginTheCreateRunAsProfileClickNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
            {
                get
                {
                    if ((cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet == null))
                    {
                        cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet = CoreManager.MomConsole.GetIntlStr(ResourceUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet);
                    }
                    
                    return cachedUseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet;
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
            /// Exposes access to the Introduction3 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 1/30/2009 Created
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
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
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
            /// Control ID for IntroductionStaticControl2
            /// </summary>
            public const string IntroductionStaticControl2 = "labelTitle";
            
            /// <summary>
            /// Control ID for DoNotShowThisPageAgainCheckBox
            /// </summary>
            public const string DoNotShowThisPageAgainCheckBox = "checkBoxShow";
            
            /// <summary>
            /// Control ID for ToBeginTheCreateRunAsProfileClickNextStaticControl
            /// </summary>
            public const string ToBeginTheCreateRunAsProfileClickNextStaticControl = "labelNext";
            
            /// <summary>
            /// Control ID for UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet
            /// </summary>
            public const string UseThisWizardToCreateARunAsProfileAndAssociateItWithOneOrMoreRunAsAccountsIfYouHaveNotYetCreatedASet = "labelDescription";
            
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
