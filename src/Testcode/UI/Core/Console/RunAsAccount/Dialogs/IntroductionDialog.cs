// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="IntroductionDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 Project
// </project>
// <summary>
// 	MOMv3 Project
// </summary>
// <history>
// 	[ruhim] 4/18/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IIntroductionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IIntroductionDialogControls, for IntroductionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/18/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IIntroductionDialogControls
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
        /// Read-only property to access AccountStaticControl
        /// </summary>
        StaticControl AccountStaticControl
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
        /// Read-only property to access AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl
        /// </summary>
        StaticControl AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl
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
        /// Read-only property to access ToBeginTheCreateRunAsAccountsClickNextStaticControl
        /// </summary>
        StaticControl ToBeginTheCreateRunAsAccountsClickNextStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM
        /// </summary>
        StaticControl RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM
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
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/18/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class IntroductionDialog : Dialog, IIntroductionDialogControls
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
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DoNotShowThisPageAgainCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDoNotShowThisPageAgainCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ToBeginTheCreateRunAsAccountsClickNextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToBeginTheCreateRunAsAccountsClickNextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM of type StaticControl
        /// </summary>
        private StaticControl cachedRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM;
        
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
        /// <param name='app'>
        /// Owner of IntroductionDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public IntroductionDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IIntroductionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IIntroductionDialogControls Controls
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
        /// 	[ruhim] 4/18/2006 Created
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
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIntroductionDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, IntroductionDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIntroductionDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, IntroductionDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIntroductionDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, IntroductionDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIntroductionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, IntroductionDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, IntroductionDialog.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
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
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.AccountStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAccountStaticControl == null))
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
                    this.cachedAccountStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.IntroductionStaticControl2
        {
            get
            {
                if ((this.cachedIntroductionStaticControl2 == null))
                {
                    this.cachedIntroductionStaticControl2 = new StaticControl(this, IntroductionDialog.ControlIDs.IntroductionStaticControl2);
                }
                return this.cachedIntroductionStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl
        {
            get
            {
                if ((this.cachedAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl == null))
                {
                    this.cachedAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl = new StaticControl(this, IntroductionDialog.ControlIDs.AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl);
                }
                return this.cachedAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoNotShowThisPageAgainCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IIntroductionDialogControls.DoNotShowThisPageAgainCheckBox
        {
            get
            {
                if ((this.cachedDoNotShowThisPageAgainCheckBox == null))
                {
                    this.cachedDoNotShowThisPageAgainCheckBox = new CheckBox(this, IntroductionDialog.ControlIDs.DoNotShowThisPageAgainCheckBox);
                }
                return this.cachedDoNotShowThisPageAgainCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToBeginTheCreateRunAsAccountsClickNextStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.ToBeginTheCreateRunAsAccountsClickNextStaticControl
        {
            get
            {
                if ((this.cachedToBeginTheCreateRunAsAccountsClickNextStaticControl == null))
                {
                    this.cachedToBeginTheCreateRunAsAccountsClickNextStaticControl = new StaticControl(this, IntroductionDialog.ControlIDs.ToBeginTheCreateRunAsAccountsClickNextStaticControl);
                }
                return this.cachedToBeginTheCreateRunAsAccountsClickNextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM
        {
            get
            {
                if ((this.cachedRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM == null))
                {
                    this.cachedRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM = new StaticControl(this, IntroductionDialog.ControlIDs.RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM);
                }
                return this.cachedRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, IntroductionDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroductionDialogControls.IntroductionStaticControl3
        {
            get
            {
                if ((this.cachedIntroductionStaticControl3 == null))
                {
                    this.cachedIntroductionStaticControl3 = new StaticControl(this, IntroductionDialog.ControlIDs.IntroductionStaticControl3);
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
        /// 	[ruhim] 4/18/2006 Created
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
        /// 	[ruhim] 4/18/2006 Created
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
        /// 	[ruhim] 4/18/2006 Created
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
        /// 	[ruhim] 4/18/2006 Created
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
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDoNotShowThisPageAgain()
        {
            this.Controls.DoNotShowThisPageAgainCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

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
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[ruhim] 4/18/2006 Created
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
            private const string ResourceDialogTitle =
                ";Create Run As Account Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountWizardCaption";
                        
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
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";&Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;CreateText";
            
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
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Account
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAccount = ";Account;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;AccountsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction2 = ";Introduction;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles = ";A particular set of Run As Accounts may be used by one or more Run As Profiles.;" +
                "ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom" +
                ".Internal.UI.Administration.RunAs.AccountIntroduction;labelTitle2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoNotShowThisPageAgain = ";Do not &show this page again;ManagedString;Microsoft.MOM.UI.Components.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAs.ProfileIntroducti" +
                "on;checkBoxShow.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToBeginTheCreateRunAsAccountsClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToBeginTheCreateRunAsAccountsClickNext = ";To begin the create \'Run As Accounts\', click \"Next\";ManagedString;Microsoft.MOM." +
                "UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration." +
                "RunAs.AccountIntroduction;labelNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM = @";Run As Accounts are named sets of credentials that are presented by Run As Profiles for authentication when executing monitors, rules, or tasks.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAs.AccountIntroduction;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction3 = ";Introduction;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";
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
            /// Caches the translated resource string for:  Account
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoNotShowThisPageAgain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToBeginTheCreateRunAsAccountsClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToBeginTheCreateRunAsAccountsClickNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM;
            
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
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
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
            /// 	[ruhim] 4/18/2006 Created
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
            /// 	[ruhim] 4/18/2006 Created
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
            /// 	[ruhim] 4/18/2006 Created
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
            /// 	[ruhim] 4/18/2006 Created
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
            /// 	[ruhim] 4/18/2006 Created
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
            /// 	[ruhim] 4/18/2006 Created
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
            /// Exposes access to the Account translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Account
            {
                get
                {
                    if ((cachedAccount == null))
                    {
                        cachedAccount = CoreManager.MomConsole.GetIntlStr(ResourceAccount);
                    }
                    return cachedAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Introduction2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
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
            /// Exposes access to the AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles
            {
                get
                {
                    if ((cachedAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles == null))
                    {
                        cachedAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles = CoreManager.MomConsole.GetIntlStr(ResourceAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles);
                    }
                    return cachedAParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DoNotShowThisPageAgain translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
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
            /// Exposes access to the ToBeginTheCreateRunAsAccountsClickNext translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToBeginTheCreateRunAsAccountsClickNext
            {
                get
                {
                    if ((cachedToBeginTheCreateRunAsAccountsClickNext == null))
                    {
                        cachedToBeginTheCreateRunAsAccountsClickNext = CoreManager.MomConsole.GetIntlStr(ResourceToBeginTheCreateRunAsAccountsClickNext);
                    }
                    return cachedToBeginTheCreateRunAsAccountsClickNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM
            {
                get
                {
                    if ((cachedRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM == null))
                    {
                        cachedRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM = CoreManager.MomConsole.GetIntlStr(ResourceRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM);
                    }
                    return cachedRunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
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
            /// 	[ruhim] 4/18/2006 Created
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
        /// 	[ruhim] 4/18/2006 Created
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
            /// Control ID for AccountStaticControl
            /// </summary>
            public const string AccountStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl2
            /// </summary>
            public const string IntroductionStaticControl2 = "labelTitle";
            
            /// <summary>
            /// Control ID for AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl
            /// </summary>
            public const string AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesStaticControl = "labelTitle2";
            
            /// <summary>
            /// Control ID for DoNotShowThisPageAgainCheckBox
            /// </summary>
            public const string DoNotShowThisPageAgainCheckBox = "checkBoxShow";
            
            /// <summary>
            /// Control ID for ToBeginTheCreateRunAsAccountsClickNextStaticControl
            /// </summary>
            public const string ToBeginTheCreateRunAsAccountsClickNextStaticControl = "labelNext";
            
            /// <summary>
            /// Control ID for RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM
            /// </summary>
            public const string RunAsAccountsAreNamedSetsOfCredentialsThatArePresentedByRunAsProfilesForAuthenticationWhenExecutingM = "labelTitle1";
            
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
