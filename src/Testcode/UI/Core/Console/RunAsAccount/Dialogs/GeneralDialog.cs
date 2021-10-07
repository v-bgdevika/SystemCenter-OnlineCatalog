// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GeneralDialog.cs">
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
    
    #region Interface Definition - IGeneralDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGeneralDialogControls, for GeneralDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/18/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGeneralDialogControls
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
        /// Read-only property to access RunAsAccountTypeComboBox
        /// </summary>
        ComboBox RunAsAccountTypeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DisplayNameTextBox
        /// </summary>
        TextBox DisplayNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DisplayNameStaticControl
        /// </summary>
        StaticControl DisplayNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunAsAccountTypeStaticControl
        /// </summary>
        StaticControl RunAsAccountTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralStaticControl2
        /// </summary>
        StaticControl GeneralStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl
        /// </summary>
        StaticControl SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl
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
        /// Read-only property to access GeneralStaticControl3
        /// </summary>
        StaticControl GeneralStaticControl3
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
    public class GeneralDialog : Dialog, IGeneralDialogControls
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
        /// Cache to hold a reference to RunAsAccountTypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedRunAsAccountTypeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DisplayNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedDisplayNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DisplayNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDisplayNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunAsAccountTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunAsAccountTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl3;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GeneralDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GeneralDialog(ConsoleApp app)
            : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);  
        }
        #endregion
        
        #region IGeneralDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGeneralDialogControls Controls
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
        ///  Routine to set/get the text in control AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfilesText
        {
            get
            {
                return this.Controls.RunAsAccountTypeComboBox.Text;
            }
            
            set
            {
                this.Controls.RunAsAccountTypeComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DisplayName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DisplayNameText
        {
            get
            {
                return this.Controls.DisplayNameTextBox.Text;
            }
            
            set
            {
                this.Controls.DisplayNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
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
        Button IGeneralDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, GeneralDialog.ControlIDs.PreviousButton);
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
        Button IGeneralDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GeneralDialog.ControlIDs.NextButton);
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
        Button IGeneralDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, GeneralDialog.ControlIDs.CreateButton);
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
        Button IGeneralDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GeneralDialog.ControlIDs.CancelButton);
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
        StaticControl IGeneralDialogControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.IntroductionStaticControl);
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
        StaticControl IGeneralDialogControls.GeneralStaticControl
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
        StaticControl IGeneralDialogControls.AccountStaticControl
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
        ///  Exposes access to the RunAsAccountTypeComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IGeneralDialogControls.RunAsAccountTypeComboBox
        {
            get
            {
                if ((this.cachedRunAsAccountTypeComboBox == null))
                {
                    this.cachedRunAsAccountTypeComboBox = new ComboBox(this, GeneralDialog.ControlIDs.RunAsAccountTypeComboBox);
                }
                return this.cachedRunAsAccountTypeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralDialogControls.DisplayNameTextBox
        {
            get
            {
                if ((this.cachedDisplayNameTextBox == null))
                {
                    this.cachedDisplayNameTextBox = new TextBox(this, GeneralDialog.ControlIDs.DisplayNameTextBox);
                }
                return this.cachedDisplayNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGeneralDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, GeneralDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.DisplayNameStaticControl
        {
            get
            {
                if ((this.cachedDisplayNameStaticControl == null))
                {
                    this.cachedDisplayNameStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.DisplayNameStaticControl);
                }
                return this.cachedDisplayNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsAccountTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.RunAsAccountTypeStaticControl
        {
            get
            {
                if ((this.cachedRunAsAccountTypeStaticControl == null))
                {
                    this.cachedRunAsAccountTypeStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.RunAsAccountTypeStaticControl);
                }
                return this.cachedRunAsAccountTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.GeneralStaticControl2
        {
            get
            {
                if ((this.cachedGeneralStaticControl2 == null))
                {
                    this.cachedGeneralStaticControl2 = new StaticControl(this, GeneralDialog.ControlIDs.GeneralStaticControl2);
                }
                return this.cachedGeneralStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl == null))
                {
                    this.cachedSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl);
                }
                return this.cachedSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl;
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
        StaticControl IGeneralDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGeneralDialogControls.GeneralStaticControl3
        {
            get
            {
                if ((this.cachedGeneralStaticControl3 == null))
                {
                    this.cachedGeneralStaticControl3 = new StaticControl(this, GeneralDialog.ControlIDs.GeneralStaticControl3);
                }
                return this.cachedGeneralStaticControl3;
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
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";D&escription:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Administration.RunAs.ProfileGeneral;labelDescription." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DisplayName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDisplayName = ";&Display name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Administration.RunAs.ProfileGeneral;labelName.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunAsAccountType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAsAccountType = ";&Run As Account type:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Administration.RunAs.AccountGeneral;labelType" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral2 = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional = ";Select the Run As Account type, provide a display name, and description (optiona" +
                "l).;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.Administration.RunAs.AccountGeneral;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral3 = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
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
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DisplayName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisplayName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunAsAccountType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsAccountType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral3;
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
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    return cachedDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DisplayName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayName
            {
                get
                {
                    if ((cachedDisplayName == null))
                    {
                        cachedDisplayName = CoreManager.MomConsole.GetIntlStr(ResourceDisplayName);
                    }
                    return cachedDisplayName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunAsAccountType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsAccountType
            {
                get
                {
                    if ((cachedRunAsAccountType == null))
                    {
                        cachedRunAsAccountType = CoreManager.MomConsole.GetIntlStr(ResourceRunAsAccountType);
                    }
                    return cachedRunAsAccountType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General2
            {
                get
                {
                    if ((cachedGeneral2 == null))
                    {
                        cachedGeneral2 = CoreManager.MomConsole.GetIntlStr(ResourceGeneral2);
                    }
                    return cachedGeneral2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional
            {
                get
                {
                    if ((cachedSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional == null))
                    {
                        cachedSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional);
                    }
                    return cachedSelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptional;
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
            /// Exposes access to the General3 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General3
            {
                get
                {
                    if ((cachedGeneral3 == null))
                    {
                        cachedGeneral3 = CoreManager.MomConsole.GetIntlStr(ResourceGeneral3);
                    }
                    return cachedGeneral3;
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
            /// Control ID for RunAsAccountTypeComboBox
            /// </summary>
            public const string RunAsAccountTypeComboBox = "comboBoxType";
            
            /// <summary>
            /// Control ID for DisplayNameTextBox
            /// </summary>
            public const string DisplayNameTextBox = "textBoxName";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "textBoxDescription";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for DisplayNameStaticControl
            /// </summary>
            public const string DisplayNameStaticControl = "labelName";
            
            /// <summary>
            /// Control ID for RunAsAccountTypeStaticControl
            /// </summary>
            public const string RunAsAccountTypeStaticControl = "labelType";
            
            /// <summary>
            /// Control ID for GeneralStaticControl2
            /// </summary>
            public const string GeneralStaticControl2 = "labelTitle";
            
            /// <summary>
            /// Control ID for SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl
            /// </summary>
            public const string SelectTheRunAsAccountTypeProvideADisplayNameAndDescriptionOptionalStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl3
            /// </summary>
            public const string GeneralStaticControl3 = "headerLabel";
        }
        #endregion
    }
}
