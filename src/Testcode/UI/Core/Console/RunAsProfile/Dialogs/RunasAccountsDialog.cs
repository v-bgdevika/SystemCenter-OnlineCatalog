// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunasAccountsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 10/30/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsProfile.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IRunasAccountsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunasAccountsDialogControls, for RunasAccountsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 10/30/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunasAccountsDialogControls
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
        /// Read-only property to access RunAsAccountsStaticControl
        /// </summary>
        StaticControl RunAsAccountsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToBeginTheCreateRunAsProfileClickNextListView
        /// </summary>
        ListView ToBeginTheCreateRunAsProfileClickNextListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunAsAccountsStaticControl2
        /// </summary>
        StaticControl RunAsAccountsStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheRunAsAccountsForThisRunAsProfileStaticControl
        /// </summary>
        StaticControl SelectTheRunAsAccountsForThisRunAsProfileStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlternateRunAsAccountsToolbar
        /// </summary>
        Toolbar AlternateRunAsAccountsToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi
        /// </summary>
        StaticControl SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi
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
        /// Read-only property to access RunAsAccountsStaticControl3
        /// </summary>
        StaticControl RunAsAccountsStaticControl3
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
    /// 	[ruhim] 10/30/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RunasAccountsDialog : Dialog, IRunasAccountsDialogControls
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
        /// Cache to hold a reference to RunAsAccountsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunAsAccountsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToBeginTheCreateRunAsProfileClickNextListView of type ListView
        /// </summary>
        private ListView cachedToBeginTheCreateRunAsProfileClickNextListView;
        
        /// <summary>
        /// Cache to hold a reference to RunAsAccountsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedRunAsAccountsStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheRunAsAccountsForThisRunAsProfileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheRunAsAccountsForThisRunAsProfileStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlternateRunAsAccountsToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedAlternateRunAsAccountsToolbar;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunAsAccountsStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedRunAsAccountsStaticControl3;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RunasAccountsDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunasAccountsDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IRunasAccountsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunasAccountsDialogControls Controls
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
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunasAccountsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, RunasAccountsDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunasAccountsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, RunasAccountsDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunasAccountsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, RunasAccountsDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunasAccountsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RunasAccountsDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunasAccountsDialogControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, RunasAccountsDialog.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunasAccountsDialogControls.GeneralStaticControl
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
        ///  Exposes access to the RunAsAccountsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunasAccountsDialogControls.RunAsAccountsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRunAsAccountsStaticControl == null))
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
                    this.cachedRunAsAccountsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedRunAsAccountsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToBeginTheCreateRunAsProfileClickNextListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IRunasAccountsDialogControls.ToBeginTheCreateRunAsProfileClickNextListView
        {
            get
            {
                if ((this.cachedToBeginTheCreateRunAsProfileClickNextListView == null))
                {
                    this.cachedToBeginTheCreateRunAsProfileClickNextListView = new ListView(this, RunasAccountsDialog.ControlIDs.ToBeginTheCreateRunAsProfileClickNextListView);
                }
                return this.cachedToBeginTheCreateRunAsProfileClickNextListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsAccountsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunasAccountsDialogControls.RunAsAccountsStaticControl2
        {
            get
            {
                if ((this.cachedRunAsAccountsStaticControl2 == null))
                {
                    this.cachedRunAsAccountsStaticControl2 = new StaticControl(this, RunasAccountsDialog.ControlIDs.RunAsAccountsStaticControl2);
                }
                return this.cachedRunAsAccountsStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheRunAsAccountsForThisRunAsProfileStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunasAccountsDialogControls.SelectTheRunAsAccountsForThisRunAsProfileStaticControl
        {
            get
            {
                if ((this.cachedSelectTheRunAsAccountsForThisRunAsProfileStaticControl == null))
                {
                    this.cachedSelectTheRunAsAccountsForThisRunAsProfileStaticControl = new StaticControl(this, RunasAccountsDialog.ControlIDs.SelectTheRunAsAccountsForThisRunAsProfileStaticControl);
                }
                return this.cachedSelectTheRunAsAccountsForThisRunAsProfileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlternateRunAsAccountsToolbar control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IRunasAccountsDialogControls.AlternateRunAsAccountsToolbar
        {
            get
            {
                if ((this.cachedAlternateRunAsAccountsToolbar == null))
                {
                    this.cachedAlternateRunAsAccountsToolbar = new Toolbar(this/*, RunasAccountsDialog.ControlIDs.AlternateRunAsAccountsToolbar*/);
                }
                return this.cachedAlternateRunAsAccountsToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunasAccountsDialogControls.SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi
        {
            get
            {
                if ((this.cachedSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi == null))
                {
                    this.cachedSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi = new StaticControl(this, RunasAccountsDialog.ControlIDs.SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi);
                }
                return this.cachedSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunasAccountsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, RunasAccountsDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsAccountsStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunasAccountsDialogControls.RunAsAccountsStaticControl3
        {
            get
            {
                if ((this.cachedRunAsAccountsStaticControl3 == null))
                {
                    this.cachedRunAsAccountsStaticControl3 = new StaticControl(this, RunasAccountsDialog.ControlIDs.RunAsAccountsStaticControl3);
                }
                return this.cachedRunAsAccountsStaticControl3;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
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
        /// 	[ruhim] 10/30/2006 Created
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
        /// 	[ruhim] 10/30/2006 Created
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
        /// 	[ruhim] 10/30/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 10/30/2006 Created
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
        /// 	[ruhim] 10/30/2006 Created
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
                ";Create Run As Profile Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsProfileWizardCaption";
            
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
            /// Contains resource string for:  RunAsAccounts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAsAccounts = ";Run As Accounts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "AdminTreeViewLevel2RunAsAccounts";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunAsAccounts2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAsAccounts2 = ";&Run As Accounts:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile." +
                "ProfileAccounts;labelAlertnateAccounts.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheRunAsAccountsForThisRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheRunAsAccountsForThisRunAsProfile = ";Select the Run As Accounts for this Run As Profile:;ManagedString;Microsoft.Ente" +
                "rpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Intern" +
                "al.UI.Administration.RunAsProfile.ProfileAccounts;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi = @";Specify the Run As Account that will be used for a particular target computer. Any target computer not specified in the list will use the Agent Action Account as its Run As Account.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.ProfileAccounts;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDialog;" +
                "helpButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunAsAccounts3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAsAccounts3 = ";Run As Accounts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "AdminTreeViewLevel2RunAsAccounts";
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
            /// Caches the translated resource string for:  RunAsAccounts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsAccounts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunAsAccounts2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsAccounts2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheRunAsAccountsForThisRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheRunAsAccountsForThisRunAsProfile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunAsAccounts3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsAccounts3;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 10/30/2006 Created
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
            /// 	[ruhim] 10/30/2006 Created
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
            /// 	[ruhim] 10/30/2006 Created
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
            /// 	[ruhim] 10/30/2006 Created
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
            /// 	[ruhim] 10/30/2006 Created
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
            /// 	[ruhim] 10/30/2006 Created
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
            /// 	[ruhim] 10/30/2006 Created
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
            /// Exposes access to the RunAsAccounts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 10/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsAccounts
            {
                get
                {
                    if ((cachedRunAsAccounts == null))
                    {
                        cachedRunAsAccounts = CoreManager.MomConsole.GetIntlStr(ResourceRunAsAccounts);
                    }
                    return cachedRunAsAccounts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunAsAccounts2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 10/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsAccounts2
            {
                get
                {
                    if ((cachedRunAsAccounts2 == null))
                    {
                        cachedRunAsAccounts2 = CoreManager.MomConsole.GetIntlStr(ResourceRunAsAccounts2);
                    }
                    return cachedRunAsAccounts2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheRunAsAccountsForThisRunAsProfile translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 10/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheRunAsAccountsForThisRunAsProfile
            {
                get
                {
                    if ((cachedSelectTheRunAsAccountsForThisRunAsProfile == null))
                    {
                        cachedSelectTheRunAsAccountsForThisRunAsProfile = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheRunAsAccountsForThisRunAsProfile);
                    }
                    return cachedSelectTheRunAsAccountsForThisRunAsProfile;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 10/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi
            {
                get
                {
                    if ((cachedSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi == null))
                    {
                        cachedSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi);
                    }
                    return cachedSpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 10/30/2006 Created
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
            /// Exposes access to the RunAsAccounts3 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 10/30/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsAccounts3
            {
                get
                {
                    if ((cachedRunAsAccounts3 == null))
                    {
                        cachedRunAsAccounts3 = CoreManager.MomConsole.GetIntlStr(ResourceRunAsAccounts3);
                    }
                    return cachedRunAsAccounts3;
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
        /// 	[ruhim] 10/30/2006 Created
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
            /// Control ID for RunAsAccountsStaticControl
            /// </summary>
            public const string RunAsAccountsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ToBeginTheCreateRunAsProfileClickNextListView
            /// </summary>
            public const string ToBeginTheCreateRunAsProfileClickNextListView = "sortingListViewAccounts";
            
            /// <summary>
            /// Control ID for RunAsAccountsStaticControl2
            /// </summary>
            public const string RunAsAccountsStaticControl2 = "labelAlertnateAccounts";
            
            /// <summary>
            /// Control ID for SelectTheRunAsAccountsForThisRunAsProfileStaticControl
            /// </summary>
            public const string SelectTheRunAsAccountsForThisRunAsProfileStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for AlternateRunAsAccountsToolbar
            /// </summary>
            public const string AlternateRunAsAccountsToolbar = "toolStripNewEditDelete";
            
            /// <summary>
            /// Control ID for SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi
            /// </summary>
            public const string SpecifyTheRunAsAccountThatWillBeUsedForAParticularTargetComputerAnyTargetComputerNotSpecifiedInTheLi = "labelDescription";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for RunAsAccountsStaticControl3
            /// </summary>
            public const string RunAsAccountsStaticControl3 = "headerLabel";
        }
        #endregion
    }
}
