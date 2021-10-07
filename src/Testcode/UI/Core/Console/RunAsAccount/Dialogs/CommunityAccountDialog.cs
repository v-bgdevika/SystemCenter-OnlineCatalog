// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CommunityAccountDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 Project
// </project>
// <summary>
// 	MOMv3 Project
// </summary>
// <history>
// 	[ruhim] 4/19/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - ICommunityAccountDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICommunityAccountDialogControls, for CommunityAccountDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/19/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICommunityAccountDialogControls
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
        /// Read-only property to access CommunityStringStaticControl
        /// </summary>
        StaticControl CommunityStringStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CommunityStringTextBox
        /// </summary>
        TextBox CommunityStringTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl
        /// </summary>
        StaticControl ConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CommunityStringRunAsAccountStaticControl
        /// </summary>
        StaticControl CommunityStringRunAsAccountStaticControl
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
        /// Read-only property to access AccountStaticControl2
        /// </summary>
        StaticControl AccountStaticControl2
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
    /// 	[ruhim] 4/19/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CommunityAccountDialog : Dialog, ICommunityAccountDialogControls
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
        /// Cache to hold a reference to CommunityStringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommunityStringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CommunityStringTextBox of type TextBox
        /// </summary>
        private TextBox cachedCommunityStringTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CommunityStringRunAsAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommunityStringRunAsAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AccountStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAccountStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CommunityAccountDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CommunityAccountDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region ICommunityAccountDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICommunityAccountDialogControls Controls
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
        ///  Routine to set/get the text in control CommunityString
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CommunityStringText
        {
            get
            {
                return this.Controls.CommunityStringTextBox.Text;
            }
            
            set
            {
                this.Controls.CommunityStringTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICommunityAccountDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CommunityAccountDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICommunityAccountDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CommunityAccountDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICommunityAccountDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, CommunityAccountDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICommunityAccountDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CommunityAccountDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountDialogControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, CommunityAccountDialog.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountDialogControls.GeneralStaticControl
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
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountDialogControls.AccountStaticControl
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
        ///  Exposes access to the CommunityStringStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountDialogControls.CommunityStringStaticControl
        {
            get
            {
                if ((this.cachedCommunityStringStaticControl == null))
                {
                    this.cachedCommunityStringStaticControl = new StaticControl(this, CommunityAccountDialog.ControlIDs.CommunityStringStaticControl);
                }
                return this.cachedCommunityStringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommunityStringTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICommunityAccountDialogControls.CommunityStringTextBox
        {
            get
            {
                if ((this.cachedCommunityStringTextBox == null))
                {
                    this.cachedCommunityStringTextBox = new TextBox(this, CommunityAccountDialog.ControlIDs.CommunityStringTextBox);
                }
                return this.cachedCommunityStringTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountDialogControls.ConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl
        {
            get
            {
                if ((this.cachedConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl == null))
                {
                    this.cachedConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl = new StaticControl(this, CommunityAccountDialog.ControlIDs.ConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl);
                }
                return this.cachedConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommunityStringRunAsAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountDialogControls.CommunityStringRunAsAccountStaticControl
        {
            get
            {
                if ((this.cachedCommunityStringRunAsAccountStaticControl == null))
                {
                    this.cachedCommunityStringRunAsAccountStaticControl = new StaticControl(this, CommunityAccountDialog.ControlIDs.CommunityStringRunAsAccountStaticControl);
                }
                return this.cachedCommunityStringRunAsAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CommunityAccountDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AccountStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICommunityAccountDialogControls.AccountStaticControl2
        {
            get
            {
                if ((this.cachedAccountStaticControl2 == null))
                {
                    this.cachedAccountStaticControl2 = new StaticControl(this, CommunityAccountDialog.ControlIDs.AccountStaticControl2);
                }
                return this.cachedAccountStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/19/2006 Created
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
        /// 	[ruhim] 4/19/2006 Created
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
        /// 	[ruhim] 4/19/2006 Created
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
        /// 	[ruhim] 4/19/2006 Created
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
        /// 	[ruhim] 4/19/2006 Created
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
        /// 	[ruhim] 4/19/2006 Created
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
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.T" +
                "ext";
            
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
            /// Contains resource string for:  CommunityString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCommunityString = ";Co&mmunity string:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Administration.RunAs.CommunityAccount;labelCommu" +
                "nity.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureTheRequiredFieldsForTheCommunityStringAccountType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureTheRequiredFieldsForTheCommunityStringAccountType = ";Configure the required fields for the Community String account type.;ManagedStri" +
                "ng;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.U" +
                "I.Administration.RunAs.CommunityAccount;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CommunityStringRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCommunityStringRunAsAccount = ";Community String Run As Account;ManagedString;Microsoft.MOM.UI.Components.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAs.CommunityAccou" +
                "nt;labelTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Account2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAccount2 = ";Account;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;AccountsTitle";
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
            /// Caches the translated resource string for:  CommunityString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCommunityString;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureTheRequiredFieldsForTheCommunityStringAccountType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureTheRequiredFieldsForTheCommunityStringAccountType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CommunityStringRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCommunityStringRunAsAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Account2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAccount2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/19/2006 Created
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
            /// 	[ruhim] 4/19/2006 Created
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
            /// 	[ruhim] 4/19/2006 Created
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
            /// 	[ruhim] 4/19/2006 Created
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
            /// 	[ruhim] 4/19/2006 Created
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
            /// 	[ruhim] 4/19/2006 Created
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
            /// 	[ruhim] 4/19/2006 Created
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
            /// 	[ruhim] 4/19/2006 Created
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
            /// Exposes access to the CommunityString translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/19/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommunityString
            {
                get
                {
                    if ((cachedCommunityString == null))
                    {
                        cachedCommunityString = CoreManager.MomConsole.GetIntlStr(ResourceCommunityString);
                    }
                    return cachedCommunityString;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureTheRequiredFieldsForTheCommunityStringAccountType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/19/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureTheRequiredFieldsForTheCommunityStringAccountType
            {
                get
                {
                    if ((cachedConfigureTheRequiredFieldsForTheCommunityStringAccountType == null))
                    {
                        cachedConfigureTheRequiredFieldsForTheCommunityStringAccountType = CoreManager.MomConsole.GetIntlStr(ResourceConfigureTheRequiredFieldsForTheCommunityStringAccountType);
                    }
                    return cachedConfigureTheRequiredFieldsForTheCommunityStringAccountType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CommunityStringRunAsAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/19/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommunityStringRunAsAccount
            {
                get
                {
                    if ((cachedCommunityStringRunAsAccount == null))
                    {
                        cachedCommunityStringRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceCommunityStringRunAsAccount);
                    }
                    return cachedCommunityStringRunAsAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/19/2006 Created
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
            /// Exposes access to the Account2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/19/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Account2
            {
                get
                {
                    if ((cachedAccount2 == null))
                    {
                        cachedAccount2 = CoreManager.MomConsole.GetIntlStr(ResourceAccount2);
                    }
                    return cachedAccount2;
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
        /// 	[ruhim] 4/19/2006 Created
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
            /// Control ID for CommunityStringStaticControl
            /// </summary>
            public const string CommunityStringStaticControl = "labelCommunity";
            
            /// <summary>
            /// Control ID for CommunityStringTextBox
            /// </summary>
            public const string CommunityStringTextBox = "textBoxCommunity";
            
            /// <summary>
            /// Control ID for ConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl
            /// </summary>
            public const string ConfigureTheRequiredFieldsForTheCommunityStringAccountTypeStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for CommunityStringRunAsAccountStaticControl
            /// </summary>
            public const string CommunityStringRunAsAccountStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for AccountStaticControl2
            /// </summary>
            public const string AccountStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
