// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunAsAccountWizardDistributionPage.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[nathd] 2/6/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount
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
    /// 	[nathd] 2/6/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum DistributionSecurityOptionRadioGroup
    {
        /// <summary>
        /// MoreSecure = 0
        /// </summary>
        MoreSecure = 0,
        
        /// <summary>
        /// LessSecure = 1
        /// </summary>
        LessSecure = 1,
    }
    #endregion
    
    #region Interface Definition - IRunAsAccountWizardDistributionPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunAsAccountWizardDistributionPageControls, for RunAsAccountWizardDistributionPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[nathd] 2/6/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunAsAccountWizardDistributionPageControls
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
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CredentialsStaticControl
        /// </summary>
        StaticControl CredentialsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributionSecurityStaticControl
        /// </summary>
        StaticControl DistributionSecurityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CompletionStaticControl
        /// </summary>
        StaticControl CompletionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MoreAboutDistributionOfCredentialsStaticControl
        /// </summary>
        StaticControl MoreAboutDistributionOfCredentialsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro
        /// </summary>
        StaticControl CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MoreSecureRadioButton
        /// </summary>
        RadioButton MoreSecureRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LessSecureRadioButton
        /// </summary>
        RadioButton LessSecureRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributionSecurityOptionStaticControl
        /// </summary>
        StaticControl DistributionSecurityOptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributionSecurityOptionTextStaticControl
        /// </summary>
        StaticControl DistributionSecurityOptionTextStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectADistributionSecurityOptionStaticControl
        /// </summary>
        StaticControl SelectADistributionSecurityOptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributionSecurityStaticControl2
        /// </summary>
        StaticControl DistributionSecurityStaticControl2
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
    /// 	[nathd] 2/6/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RunAsAccountWizardDistributionPage : Window, IRunAsAccountWizardDistributionPageControls
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
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCredentialsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DistributionSecurityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDistributionSecurityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CompletionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCompletionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MoreAboutDistributionOfCredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMoreAboutDistributionOfCredentialsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro of type StaticControl
        /// </summary>
        private StaticControl cachedCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro;
        
        /// <summary>
        /// Cache to hold a reference to MoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributedRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedMoreSecureRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to LessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputersRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedLessSecureRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DistributionSecurityOptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDistributionSecurityOptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DistributionSecurityOptionTextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDistributionSecurityOptionTextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectADistributionSecurityOptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectADistributionSecurityOptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DistributionSecurityStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedDistributionSecurityStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of RunAsAccountWizardDistributionPage of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunAsAccountWizardDistributionPage(MomConsoleApp ownerWindow) : 
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
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RunAsAccount.DistributionSecurityOption DistributionSecurityOption
        {
            get
            {
                if ((this.Controls.MoreSecureRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RunAsAccount.DistributionSecurityOption.MoreSecure;
                }
                
                if ((this.Controls.LessSecureRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RunAsAccount.DistributionSecurityOption.LessSecure;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RunAsAccount.DistributionSecurityOption.MoreSecure))
                {
                    this.Controls.MoreSecureRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value ==  RunAsAccount.DistributionSecurityOption.MoreSecure))
                    {
                        this.Controls.LessSecureRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IRunAsAccountWizardDistributionPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunAsAccountWizardDistributionPageControls Controls
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
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsAccountWizardDistributionPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, RunAsAccountWizardDistributionPage.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsAccountWizardDistributionPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, RunAsAccountWizardDistributionPage.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsAccountWizardDistributionPageControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, RunAsAccountWizardDistributionPage.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsAccountWizardDistributionPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RunAsAccountWizardDistributionPage.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, RunAsAccountWizardDistributionPage.ControlIDs.IntroductionStaticControl);
                }
                
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.GeneralPropertiesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralPropertiesStaticControl == null))
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
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.CredentialsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCredentialsStaticControl == null))
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
                    this.cachedCredentialsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedCredentialsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributionSecurityStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.DistributionSecurityStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDistributionSecurityStaticControl == null))
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
                    this.cachedDistributionSecurityStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDistributionSecurityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompletionStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.CompletionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCompletionStaticControl == null))
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
                    this.cachedCompletionStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedCompletionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreAboutDistributionOfCredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.MoreAboutDistributionOfCredentialsStaticControl
        {
            get
            {
                if ((this.cachedMoreAboutDistributionOfCredentialsStaticControl == null))
                {
                    this.cachedMoreAboutDistributionOfCredentialsStaticControl = new StaticControl(this, RunAsAccountWizardDistributionPage.ControlIDs.MoreAboutDistributionOfCredentialsStaticControl);
                }
                
                return this.cachedMoreAboutDistributionOfCredentialsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro
        {
            get
            {
                if ((this.cachedCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro == null))
                {
                    this.cachedCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro = new StaticControl(this, RunAsAccountWizardDistributionPage.ControlIDs.CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro);
                }
                
                return this.cachedCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreSecureRadioButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IRunAsAccountWizardDistributionPageControls.MoreSecureRadioButton
        {
            get
            {
                if ((this.cachedMoreSecureRadioButton == null))
                {
                    this.cachedMoreSecureRadioButton = new RadioButton(this, RunAsAccountWizardDistributionPage.ControlIDs.MoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributedRadioButton);
                }

                return this.cachedMoreSecureRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LessSecureRadioButton control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IRunAsAccountWizardDistributionPageControls.LessSecureRadioButton
        {
            get
            {
                if ((this.cachedLessSecureRadioButton == null))
                {
                    this.cachedLessSecureRadioButton = new RadioButton(this, RunAsAccountWizardDistributionPage.ControlIDs.LessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputersRadioButton);
                }

                return this.cachedLessSecureRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributionSecurityOptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.DistributionSecurityOptionStaticControl
        {
            get
            {
                if ((this.cachedDistributionSecurityOptionStaticControl == null))
                {
                    this.cachedDistributionSecurityOptionStaticControl = new StaticControl(this, RunAsAccountWizardDistributionPage.ControlIDs.SelectADistributionSecurityOptionForThisRunAsAccountStaticControl);
                }

                return this.cachedDistributionSecurityOptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributionSecurityOptionTextStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.DistributionSecurityOptionTextStaticControl
        {
            get
            {
                if ((this.cachedDistributionSecurityOptionTextStaticControl == null))
                {
                    this.cachedDistributionSecurityOptionTextStaticControl = new StaticControl(this, RunAsAccountWizardDistributionPage.ControlIDs.TheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer);
                }

                return this.cachedDistributionSecurityOptionTextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectADistributionSecurityOptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.SelectADistributionSecurityOptionStaticControl
        {
            get
            {
                if ((this.cachedSelectADistributionSecurityOptionStaticControl == null))
                {
                    this.cachedSelectADistributionSecurityOptionStaticControl = new StaticControl(this, RunAsAccountWizardDistributionPage.ControlIDs.SelectADistributionSecurityOptionStaticControl);
                }
                
                return this.cachedSelectADistributionSecurityOptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributionSecurityStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountWizardDistributionPageControls.DistributionSecurityStaticControl2
        {
            get
            {
                if ((this.cachedDistributionSecurityStaticControl2 == null))
                {
                    this.cachedDistributionSecurityStaticControl2 = new StaticControl(this, RunAsAccountWizardDistributionPage.ControlIDs.DistributionSecurityStaticControl2);
                }
                
                return this.cachedDistributionSecurityStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[nathd] 2/6/2009 Created
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
        /// 	[nathd] 2/6/2009 Created
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
        /// 	[nathd] 2/6/2009 Created
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
        /// 	[nathd] 2/6/2009 Created
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
        ///  <param name="ownerWindow">MomConsoleApp class instance that owns this window.</param>)
        /// <history>
        /// 	[nathd] 2/6/2009 Created
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
        /// 	[nathd] 2/6/2009 Created
        ///     [a-joelj]   16MAR09 Corrected hardcoded WindowTitle resource
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
            private const string ResourceWindowTitle = 
                ";Create Run As Account Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountWizardCaption";
            
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
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administratio" +
                "n.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResourc" +
                "es;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Credentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCredentials = ";Credentials;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;M" +
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Acco" +
                "untsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DistributionSecurity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDistributionSecurity = ";Distribution Security;ManagedString;Microsoft.EnterpriseManagement.UI.Administra" +
                "tion.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminReso" +
                "urces;RunAsAccountDistributionSecurityTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Completion
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCompletion = ";Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAs" +
                "ProfileDistributionPage";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MoreAboutDistributionOfCredentials
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoreAboutDistributionOfCredentials = "More about distribution of credentials";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials = @";Caution: Administrators of all recipient computers will be able to access the Run As account credentials.
;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsAccount.RunAsAccountDistributionsPage;warningLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed = @";&More secure - I want to manually select the computers to which the credentials will be distributed;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsAccount.RunAsAccountDistributionsPage;selectedChoice.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceLessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers = "&Less secure - I want the credentials to be distributed automatically to all mana" +
                "ged computers";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectADistributionSecurityOptionForThisRunAsAccount
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectADistributionSecurityOptionForThisRunAsAccount = "Select a distribution security option for this Run As account:\r\n";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer = "The credentials for this Run As account must be distributed to the agent-managed " +
                "computers or management servers to perform the monitoring operations that are as" +
                "sociated with a Run As profile.  Distribution cannot occur until the Run As acco" +
                "unt is added t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectADistributionSecurityOption
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectADistributionSecurityOption = "Select a distribution security option\r\n";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DistributionSecurity2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDistributionSecurity2 = ";Distribution Security;ManagedString;Microsoft.EnterpriseManagement.UI.Administra" +
                "tion.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminReso" +
                "urces;RunAsAccountDistributionSecurityTitle";
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
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Credentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCredentials;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DistributionSecurity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDistributionSecurity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Completion
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCompletion;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MoreAboutDistributionOfCredentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreAboutDistributionOfCredentials;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectADistributionSecurityOptionForThisRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectADistributionSecurityOptionForThisRunAsAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectADistributionSecurityOption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectADistributionSecurityOption;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DistributionSecurity2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDistributionSecurity2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
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
            /// 	[nathd] 2/6/2009 Created
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
            /// 	[nathd] 2/6/2009 Created
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
            /// 	[nathd] 2/6/2009 Created
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
            /// 	[nathd] 2/6/2009 Created
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
            /// 	[nathd] 2/6/2009 Created
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
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
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
            /// Exposes access to the Credentials translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Credentials
            {
                get
                {
                    if ((cachedCredentials == null))
                    {
                        cachedCredentials = CoreManager.MomConsole.GetIntlStr(ResourceCredentials);
                    }
                    
                    return cachedCredentials;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DistributionSecurity translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DistributionSecurity
            {
                get
                {
                    if ((cachedDistributionSecurity == null))
                    {
                        cachedDistributionSecurity = CoreManager.MomConsole.GetIntlStr(ResourceDistributionSecurity);
                    }
                    
                    return cachedDistributionSecurity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Completion translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Completion
            {
                get
                {
                    if ((cachedCompletion == null))
                    {
                        cachedCompletion = CoreManager.MomConsole.GetIntlStr(ResourceCompletion);
                    }
                    
                    return cachedCompletion;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MoreAboutDistributionOfCredentials translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreAboutDistributionOfCredentials
            {
                get
                {
                    if ((cachedMoreAboutDistributionOfCredentials == null))
                    {
                        cachedMoreAboutDistributionOfCredentials = CoreManager.MomConsole.GetIntlStr(ResourceMoreAboutDistributionOfCredentials);
                    }
                    
                    return cachedMoreAboutDistributionOfCredentials;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials
            {
                get
                {
                    if ((cachedCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials == null))
                    {
                        cachedCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials = CoreManager.MomConsole.GetIntlStr(ResourceCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials);
                    }
                    
                    return cachedCautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentials;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed
            {
                get
                {
                    if ((cachedMoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed == null))
                    {
                        cachedMoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed = CoreManager.MomConsole.GetIntlStr(ResourceMoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed);
                    }
                    
                    return cachedMoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributed;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers
            {
                get
                {
                    if ((cachedLessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers == null))
                    {
                        cachedLessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers = CoreManager.MomConsole.GetIntlStr(ResourceLessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers);
                    }
                    
                    return cachedLessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectADistributionSecurityOptionForThisRunAsAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectADistributionSecurityOptionForThisRunAsAccount
            {
                get
                {
                    if ((cachedSelectADistributionSecurityOptionForThisRunAsAccount == null))
                    {
                        cachedSelectADistributionSecurityOptionForThisRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceSelectADistributionSecurityOptionForThisRunAsAccount);
                    }
                    
                    return cachedSelectADistributionSecurityOptionForThisRunAsAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer
            {
                get
                {
                    if ((cachedTheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer == null))
                    {
                        cachedTheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer = CoreManager.MomConsole.GetIntlStr(ResourceTheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer);
                    }
                    
                    return cachedTheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectADistributionSecurityOption translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectADistributionSecurityOption
            {
                get
                {
                    if ((cachedSelectADistributionSecurityOption == null))
                    {
                        cachedSelectADistributionSecurityOption = CoreManager.MomConsole.GetIntlStr(ResourceSelectADistributionSecurityOption);
                    }
                    
                    return cachedSelectADistributionSecurityOption;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DistributionSecurity2 translated resource string
            /// </summary>
            /// <history>
            /// 	[nathd] 2/6/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DistributionSecurity2
            {
                get
                {
                    if ((cachedDistributionSecurity2 == null))
                    {
                        cachedDistributionSecurity2 = CoreManager.MomConsole.GetIntlStr(ResourceDistributionSecurity2);
                    }
                    
                    return cachedDistributionSecurity2;
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
        /// 	[nathd] 2/6/2009 Created
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
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CredentialsStaticControl
            /// </summary>
            public const string CredentialsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DistributionSecurityStaticControl
            /// </summary>
            public const string DistributionSecurityStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CompletionStaticControl
            /// </summary>
            public const string CompletionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for MoreAboutDistributionOfCredentialsStaticControl
            /// </summary>
            public const string MoreAboutDistributionOfCredentialsStaticControl = "linkLabel1";
            
            /// <summary>
            /// Control ID for CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro
            /// </summary>
            public const string CautionAdministratorsOfAllRecipientComputersWillBeAbleToAccessTheRunAsAccountCredentialsStaticContro = "warningLabel";
            
            /// <summary>
            /// Control ID for MoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributedRadioButton
            /// </summary>
            public const string MoreSecureIWantToManuallySelectTheComputersToWhichTheCredentialsWillBeDistributedRadioButton = "highSecurityOption";
            
            /// <summary>
            /// Control ID for LessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputersRadioButton
            /// </summary>
            public const string LessSecureIWantTheCredentialsToBeDistributedAutomaticallyToAllManagedComputersRadioButton = "lowSecurityOption";
            
            /// <summary>
            /// Control ID for SelectADistributionSecurityOptionForThisRunAsAccountStaticControl
            /// </summary>
            public const string SelectADistributionSecurityOptionForThisRunAsAccountStaticControl = "label2";
            
            /// <summary>
            /// Control ID for TheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer
            /// </summary>
            public const string TheCredentialsForThisRunAsAccountMustBeDistributedToTheAgentManagedComputersOrManagementServersToPer = "label1";
            
            /// <summary>
            /// Control ID for SelectADistributionSecurityOptionStaticControl
            /// </summary>
            public const string SelectADistributionSecurityOptionStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for DistributionSecurityStaticControl2
            /// </summary>
            public const string DistributionSecurityStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
