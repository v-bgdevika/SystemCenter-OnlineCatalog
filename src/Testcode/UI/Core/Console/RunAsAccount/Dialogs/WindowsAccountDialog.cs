// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WindowsAccountDialog.cs">
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
    
    #region Interface Definition - IWindowsAccountDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWindowsAccountDialogControls, for WindowsAccountDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/18/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWindowsAccountDialogControls
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
        /// Read-only property to access ConfirmPasswordStaticControl
        /// </summary>
        StaticControl ConfirmPasswordStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfirmPasswordTextBox
        /// </summary>
        TextBox ConfirmPasswordTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserNameStaticControl
        /// </summary>
        StaticControl UserNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserNameTextBox
        /// </summary>
        TextBox UserNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PasswordStaticControl
        /// </summary>
        StaticControl PasswordStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PasswordTextBox
        /// </summary>
        TextBox PasswordTextBox
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
        /// Read-only property to access DomainEditComboBox
        /// </summary>
        EditComboBox DomainEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DomainTextBox
        /// </summary>
        TextBox DomainTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WindowsRunAsAccountStaticControl
        /// </summary>
        StaticControl WindowsRunAsAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl
        /// </summary>
        StaticControl ConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl
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
    /// 	[ruhim] 4/18/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WindowsAccountDialog : Dialog, IWindowsAccountDialogControls
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
        /// Cache to hold a reference to ConfirmPasswordStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfirmPasswordStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfirmPasswordTextBox of type TextBox
        /// </summary>
        private TextBox cachedConfirmPasswordTextBox;
        
        /// <summary>
        /// Cache to hold a reference to UserNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUserNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedUserNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PasswordStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPasswordStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PasswordTextBox of type TextBox
        /// </summary>
        private TextBox cachedPasswordTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DomainEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedDomainEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainTextBox of type TextBox
        /// </summary>
        private TextBox cachedDomainTextBox;
        
        /// <summary>
        /// Cache to hold a reference to WindowsRunAsAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWindowsRunAsAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl;
        
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
        /// Owner of WindowsAccountDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WindowsAccountDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IWindowsAccountDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWindowsAccountDialogControls Controls
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
        ///  Routine to set/get the text in control Description
        /// </summary>        
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConfirmPasswordText
        {
            get
            {
                return this.Controls.ConfirmPasswordTextBox.Text;
            }
            
            set
            {
                this.Controls.ConfirmPasswordTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AParticularSetOfRunAsAccountsMayBeUsedByOneOrMoreRunAsProfiles
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UserNameText
        {
            get
            {
                return this.Controls.UserNameTextBox.Text;
            }
            
            set
            {
                this.Controls.UserNameTextBox.Text = value;
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
        public virtual string PasswordText
        {
            get
            {
                return this.Controls.PasswordTextBox.Text;
            }
            
            set
            {
                this.Controls.PasswordTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Domain
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DomainText
        {
            get
            {
                return this.Controls.DomainEditComboBox.Text;
            }
            
            set
            {
                this.Controls.DomainEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Domain2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string Domain2Text
        {
            get
            {
                return this.Controls.DomainTextBox.Text;
            }
            
            set
            {
                this.Controls.DomainTextBox.Text = value;
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
        Button IWindowsAccountDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, WindowsAccountDialog.ControlIDs.PreviousButton);
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
        Button IWindowsAccountDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WindowsAccountDialog.ControlIDs.NextButton);
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
        Button IWindowsAccountDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, WindowsAccountDialog.ControlIDs.CreateButton);
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
        Button IWindowsAccountDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WindowsAccountDialog.ControlIDs.CancelButton);
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
        StaticControl IWindowsAccountDialogControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, WindowsAccountDialog.ControlIDs.IntroductionStaticControl);
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
        StaticControl IWindowsAccountDialogControls.GeneralStaticControl
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
        StaticControl IWindowsAccountDialogControls.AccountStaticControl
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
        ///  Exposes access to the ConfirmPasswordStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsAccountDialogControls.ConfirmPasswordStaticControl
        {
            get
            {
                if ((this.cachedConfirmPasswordStaticControl == null))
                {
                    this.cachedConfirmPasswordStaticControl = new StaticControl(this, WindowsAccountDialog.ControlIDs.ConfirmPasswordStaticControl);
                }
                return this.cachedConfirmPasswordStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfirmPasswordTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWindowsAccountDialogControls.ConfirmPasswordTextBox
        {
            get
            {
                if ((this.cachedConfirmPasswordTextBox == null))
                {
                    this.cachedConfirmPasswordTextBox = new TextBox(this, WindowsAccountDialog.ControlIDs.ConfirmPasswordTextBox);
                }
                return this.cachedConfirmPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsAccountDialogControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, WindowsAccountDialog.ControlIDs.UserNameStaticControl);
                }
                return this.cachedUserNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWindowsAccountDialogControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, WindowsAccountDialog.ControlIDs.UserNameTextBox);
                }
                return this.cachedUserNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsAccountDialogControls.PasswordStaticControl
        {
            get
            {
                if ((this.cachedPasswordStaticControl == null))
                {
                    this.cachedPasswordStaticControl = new StaticControl(this, WindowsAccountDialog.ControlIDs.PasswordStaticControl);
                }
                return this.cachedPasswordStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWindowsAccountDialogControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, WindowsAccountDialog.ControlIDs.PasswordTextBox);
                }
                return this.cachedPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsAccountDialogControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, WindowsAccountDialog.ControlIDs.DomainStaticControl);
                }
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainEditComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IWindowsAccountDialogControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, WindowsAccountDialog.ControlIDs.DomainEditComboBox);
                }
                return this.cachedDomainEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWindowsAccountDialogControls.DomainTextBox
        {
            get
            {
                if ((this.cachedDomainTextBox == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 6); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDomainTextBox = new TextBox(wndTemp);
                }
                return this.cachedDomainTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WindowsRunAsAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsAccountDialogControls.WindowsRunAsAccountStaticControl
        {
            get
            {
                if ((this.cachedWindowsRunAsAccountStaticControl == null))
                {
                    this.cachedWindowsRunAsAccountStaticControl = new StaticControl(this, WindowsAccountDialog.ControlIDs.WindowsRunAsAccountStaticControl);
                }
                return this.cachedWindowsRunAsAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsAccountDialogControls.ConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl
        {
            get
            {
                if ((this.cachedConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl == null))
                {
                    this.cachedConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl = new StaticControl(this, WindowsAccountDialog.ControlIDs.ConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl);
                }
                return this.cachedConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl;
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
        StaticControl IWindowsAccountDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, WindowsAccountDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AccountStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/18/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsAccountDialogControls.AccountStaticControl2
        {
            get
            {
                if ((this.cachedAccountStaticControl2 == null))
                {
                    this.cachedAccountStaticControl2 = new StaticControl(this, WindowsAccountDialog.ControlIDs.AccountStaticControl2);
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
            /// Contains resource string for:  ConfirmPassword
            /// </summary>
            /// -----------------------------------------------------------------------------
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UserName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserName = ";&User name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Administration.RunAs.WindowsAccount;userAccount.UserCap" +
                "tion";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Password
            /// </summary>
            /// -----------------------------------------------------------------------------

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDomain = ";&Domain:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.Administration.RunAs.WindowsAccount;userAccount.DomainCapt" +
                "ion";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WindowsRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowsRunAsAccount = ";Windows Run As Account;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Administration.RunAs.WindowsAccount;labelTit" +
                "le.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureTheRequiredFieldsForTheWindowsAccountType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureTheRequiredFieldsForTheWindowsAccountType = ";Configure the required fields for the Windows account type.;ManagedString;Micros" +
                "oft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Adminis" +
                "tration.RunAs.WindowsAccount;labelTitle1.Text";
            
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
            /// Caches the translated resource string for:  ConfirmPassword
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmPassword;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UserName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Password
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPassword;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WindowsRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsRunAsAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureTheRequiredFieldsForTheWindowsAccountType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureTheRequiredFieldsForTheWindowsAccountType;
            
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
            /// Exposes access to the ConfirmPassword translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmPassword
            {
                get
                {
                    if ((cachedConfirmPassword == null))
                    {
                        cachedConfirmPassword = CoreManager.MomConsole.GetIntlStr(ResourceConfirmPassword);
                    }
                    return cachedConfirmPassword;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UserName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserName
            {
                get
                {
                    if ((cachedUserName == null))
                    {
                        cachedUserName = CoreManager.MomConsole.GetIntlStr(ResourceUserName);
                    }
                    return cachedUserName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Password translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Password
            {
                get
                {
                    if ((cachedPassword == null))
                    {
                        cachedPassword = CoreManager.MomConsole.GetIntlStr(ResourcePassword);
                    }
                    return cachedPassword;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Domain translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
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
            /// Exposes access to the WindowsRunAsAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsRunAsAccount
            {
                get
                {
                    if ((cachedWindowsRunAsAccount == null))
                    {
                        cachedWindowsRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceWindowsRunAsAccount);
                    }
                    return cachedWindowsRunAsAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureTheRequiredFieldsForTheWindowsAccountType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureTheRequiredFieldsForTheWindowsAccountType
            {
                get
                {
                    if ((cachedConfigureTheRequiredFieldsForTheWindowsAccountType == null))
                    {
                        cachedConfigureTheRequiredFieldsForTheWindowsAccountType = CoreManager.MomConsole.GetIntlStr(ResourceConfigureTheRequiredFieldsForTheWindowsAccountType);
                    }
                    return cachedConfigureTheRequiredFieldsForTheWindowsAccountType;
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
            /// Exposes access to the Account2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/18/2006 Created
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
            /// Control ID for ConfirmPasswordStaticControl
            /// </summary>
            public const string ConfirmPasswordStaticControl = "labelConfirmPassword";
            
            /// <summary>
            /// Control ID for ConfirmPasswordTextBox
            /// </summary>
            public const string ConfirmPasswordTextBox = "textBoxConfirmPassword";
            
            /// <summary>
            /// Control ID for UserNameStaticControl
            /// </summary>
            public const string UserNameStaticControl = "labelUser";
            
            /// <summary>
            /// Control ID for UserNameTextBox
            /// </summary>
            public const string UserNameTextBox = "textBoxUserName";
            
            /// <summary>
            /// Control ID for PasswordStaticControl
            /// </summary>
            public const string PasswordStaticControl = "labelPassword";
            
            /// <summary>
            /// Control ID for PasswordTextBox
            /// </summary>
            public const string PasswordTextBox = "textBoxPassword";
            
            /// <summary>
            /// Control ID for DomainStaticControl
            /// </summary>
            public const string DomainStaticControl = "labelDomain";
            
            /// <summary>
            /// Control ID for DomainEditComboBox
            /// </summary>
            public const string DomainEditComboBox = "comboBoxDomain";
            
            /// <summary>
            /// Control ID for WindowsRunAsAccountStaticControl
            /// </summary>
            public const string WindowsRunAsAccountStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for ConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl
            /// </summary>
            public const string ConfigureTheRequiredFieldsForTheWindowsAccountTypeStaticControl = "labelTitle1";
            
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
