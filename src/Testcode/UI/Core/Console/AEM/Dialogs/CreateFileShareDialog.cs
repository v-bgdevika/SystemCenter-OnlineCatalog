// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateFileShareDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	AEM Deployment Dialog - 4rd screen
// </summary>
// <history>
// 	[lucyra] 4/13/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.AEM.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - RadioGroupTab4

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroupTab4
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroupTab4
    {
        /// <summary>
        /// OtherUserAccountWillNotBeSaved = 0
        /// </summary>
        OtherUserAccountWillNotBeSaved = 0,
        
        /// <summary>
        /// ExistingUserAccount = 1
        /// </summary>
        ExistingUserAccount = 1,
    }
    #endregion
    
    #region Interface Definition - ICreateFileShareDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateFileShareDialogControls, for CreateFileShareDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateFileShareDialogControls
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
        /// Read-only property to access CEIPForwardingStaticControl
        /// </summary>
        StaticControl CEIPForwardingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorCollectionStaticControl
        /// </summary>
        StaticControl ErrorCollectionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorForwardingStaticControl
        /// </summary>
        StaticControl ErrorForwardingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateFileShareStaticControl
        /// </summary>
        StaticControl CreateFileShareStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskStatusStaticControl
        /// </summary>
        StaticControl TaskStatusStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DeploySettingsStaticControl
        /// </summary>
        StaticControl DeploySettingsStaticControl
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
        /// Read-only property to access ComboBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OtherUserAccountWillNotBeSavedRadioButton
        /// </summary>
        RadioButton OtherUserAccountWillNotBeSavedRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExistingUserAccountRadioButton
        /// </summary>
        RadioButton ExistingUserAccountRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide
        /// </summary>
        StaticControl ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskCredentialsStaticControl
        /// </summary>
        StaticControl TaskCredentialsStaticControl
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
        /// Read-only property to access CreateFileShareStaticControl2
        /// </summary>
        StaticControl CreateFileShareStaticControl2
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
    /// 	[lucyra] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateFileShareDialog : Dialog, ICreateFileShareDialogControls
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
        /// Cache to hold a reference to CEIPForwardingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCEIPForwardingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ErrorCollectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedErrorCollectionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ErrorForwardingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedErrorForwardingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateFileShareStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreateFileShareStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TaskStatusStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskStatusStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DeploySettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDeploySettingsStaticControl;
        
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
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox0;
        
        /// <summary>
        /// Cache to hold a reference to OtherUserAccountWillNotBeSavedRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedOtherUserAccountWillNotBeSavedRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ExistingUserAccountRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedExistingUserAccountRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide of type StaticControl
        /// </summary>
        private StaticControl cachedThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide;
        
        /// <summary>
        /// Cache to hold a reference to TaskCredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskCredentialsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateFileShareStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedCreateFileShareStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateFileShareDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateFileShareDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroupTab4
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroupTab4 RadioGroupTab4
        {
            get
            {
                if ((this.Controls.OtherUserAccountWillNotBeSavedRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTab4.OtherUserAccountWillNotBeSaved;
                }
                
                if ((this.Controls.ExistingUserAccountRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTab4.ExistingUserAccount;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroupTab4.OtherUserAccountWillNotBeSaved))
                {
                    this.Controls.OtherUserAccountWillNotBeSavedRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroupTab4.ExistingUserAccount))
                    {
                        this.Controls.ExistingUserAccountRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICreateFileShareDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateFileShareDialogControls Controls
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
        ///  Routine to set/get the text in control UserName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
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
        ///  Routine to set/get the text in control Password
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
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
        /// 	[lucyra] 4/13/2006 Created
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
        /// 	[lucyra] 4/13/2006 Created
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox0Text
        {
            get
            {
                return this.Controls.ComboBox0.Text;
            }
            
            set
            {
                this.Controls.ComboBox0.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateFileShareDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateFileShareDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateFileShareDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateFileShareDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateFileShareDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateFileShareDialog.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateFileShareDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateFileShareDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, CreateFileShareDialog.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CEIPForwardingStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.CEIPForwardingStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCEIPForwardingStaticControl == null))
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
                    this.cachedCEIPForwardingStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedCEIPForwardingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.ErrorCollectionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedErrorCollectionStaticControl == null))
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
                    this.cachedErrorCollectionStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedErrorCollectionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorForwardingStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.ErrorForwardingStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedErrorForwardingStaticControl == null))
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
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedErrorForwardingStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedErrorForwardingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateFileShareStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.CreateFileShareStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCreateFileShareStaticControl == null))
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
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedCreateFileShareStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedCreateFileShareStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskStatusStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.TaskStatusStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTaskStatusStaticControl == null))
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
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTaskStatusStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedTaskStatusStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeploySettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.DeploySettingsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDeploySettingsStaticControl == null))
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
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDeploySettingsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedDeploySettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, CreateFileShareDialog.ControlIDs.UserNameStaticControl);
                }
                return this.cachedUserNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateFileShareDialogControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, CreateFileShareDialog.ControlIDs.UserNameTextBox);
                }
                return this.cachedUserNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.PasswordStaticControl
        {
            get
            {
                if ((this.cachedPasswordStaticControl == null))
                {
                    this.cachedPasswordStaticControl = new StaticControl(this, CreateFileShareDialog.ControlIDs.PasswordStaticControl);
                }
                return this.cachedPasswordStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateFileShareDialogControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, CreateFileShareDialog.ControlIDs.PasswordTextBox);
                }
                return this.cachedPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, CreateFileShareDialog.ControlIDs.DomainStaticControl);
                }
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainEditComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ICreateFileShareDialogControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, CreateFileShareDialog.ControlIDs.DomainEditComboBox);
                }
                return this.cachedDomainEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateFileShareDialogControls.DomainTextBox
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
                    for (i = 0; (i <= 4); i = (i + 1))
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
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateFileShareDialogControls.ComboBox0
        {
            get
            {
                if ((this.cachedComboBox0 == null))
                {
                    this.cachedComboBox0 = new ComboBox(this, CreateFileShareDialog.ControlIDs.ComboBox0);
                }
                return this.cachedComboBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OtherUserAccountWillNotBeSavedRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateFileShareDialogControls.OtherUserAccountWillNotBeSavedRadioButton
        {
            get
            {
                if ((this.cachedOtherUserAccountWillNotBeSavedRadioButton == null))
                {
                    this.cachedOtherUserAccountWillNotBeSavedRadioButton = new RadioButton(this, CreateFileShareDialog.ControlIDs.OtherUserAccountWillNotBeSavedRadioButton);
                }
                return this.cachedOtherUserAccountWillNotBeSavedRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExistingUserAccountRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateFileShareDialogControls.ExistingUserAccountRadioButton
        {
            get
            {
                if ((this.cachedExistingUserAccountRadioButton == null))
                {
                    this.cachedExistingUserAccountRadioButton = new RadioButton(this, CreateFileShareDialog.ControlIDs.ExistingUserAccountRadioButton);
                }
                return this.cachedExistingUserAccountRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide
        {
            get
            {
                if ((this.cachedThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide == null))
                {
                    this.cachedThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide = new StaticControl(this, CreateFileShareDialog.ControlIDs.ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide);
                }
                return this.cachedThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskCredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.TaskCredentialsStaticControl
        {
            get
            {
                if ((this.cachedTaskCredentialsStaticControl == null))
                {
                    this.cachedTaskCredentialsStaticControl = new StaticControl(this, CreateFileShareDialog.ControlIDs.TaskCredentialsStaticControl);
                }
                return this.cachedTaskCredentialsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateFileShareDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateFileShareStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateFileShareDialogControls.CreateFileShareStaticControl2
        {
            get
            {
                if ((this.cachedCreateFileShareStaticControl2 == null))
                {
                    this.cachedCreateFileShareStaticControl2 = new StaticControl(this, CreateFileShareDialog.ControlIDs.CreateFileShareStaticControl2);
                }
                return this.cachedCreateFileShareStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
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
        /// 	[lucyra] 4/13/2006 Created
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
        /// 	[lucyra] 4/13/2006 Created
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
        /// 	[lucyra] 4/13/2006 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
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
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

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
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

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
        /// 	[lucyra] 4/13/2006 Created
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
            private const string ResourceDialogTitle = ";Client Monitoring Configuration Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ClientMonitoringWizardCaption";
            
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
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
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
            /// Contains resource string for:  CEIPForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCEIPForwarding = ";CEIP Forwarding;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_CEIPForwardin" +
                "gNavigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ErrorCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorCollection = ";Error Collection;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.AdminResources;CM_ErrorCollect" +
                "ionNavigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ErrorForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorForwarding = ";Error Forwarding;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.AdminResources;CM_ErrorForward" +
                "ingNavigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateFileShare
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateFileShare = ";Create File Share;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_CreateFileS" +
                "hareNavigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskStatus = ";Task Status;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;TaskStatus" +
                "EditDialogTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DeploySettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDeploySettings = ";Deploy Settings;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_DeployConfigN" +
                "avigationTitle";
            
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
            private const string ResourceDomain = ";Do&main:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.Administration.ConnectionAccount;userAccount.DomainCaption" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OtherUserAccountWillNotBeSaved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOtherUserAccountWillNotBeSaved = ";&Other user account (will not be saved):;ManagedString;Microsoft.MOM.UI.Console." +
                "exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Client" +
                "Monitoring.CreateFileShare;radioButtonNew.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExistingUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExistingUserAccount = ";&Existing user account:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.Create" +
                "FileShare;radioButtonExisting.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide = @";This wizard will now attempt to create a file share on the directory you indicated on the previous dialog. Please provide an account which has permissions to create file shares on the Management Server you selected;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CreateFileShare;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskCredentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskCredentials = ";Task Credentials;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.ClientMonitoring.CreateFileSha" +
                "re;labelTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateFileShare2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateFileShare2 = ";Create File Share;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_CreateFileS" +
                "hareNavigationTitle";
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
            /// Caches the translated resource string for:  CEIPForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCEIPForwarding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ErrorCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorCollection;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ErrorForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorForwarding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateFileShare
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateFileShare;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskStatus;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DeploySettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDeploySettings;
            
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
            /// Caches the translated resource string for:  OtherUserAccountWillNotBeSaved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOtherUserAccountWillNotBeSaved;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExistingUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExistingUserAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskCredentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskCredentials;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateFileShare2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateFileShare2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// Exposes access to the CEIPForwarding translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CEIPForwarding
            {
                get
                {
                    if ((cachedCEIPForwarding == null))
                    {
                        cachedCEIPForwarding = CoreManager.MomConsole.GetIntlStr(ResourceCEIPForwarding);
                    }
                    return cachedCEIPForwarding;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorCollection translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorCollection
            {
                get
                {
                    if ((cachedErrorCollection == null))
                    {
                        cachedErrorCollection = CoreManager.MomConsole.GetIntlStr(ResourceErrorCollection);
                    }
                    return cachedErrorCollection;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorForwarding translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorForwarding
            {
                get
                {
                    if ((cachedErrorForwarding == null))
                    {
                        cachedErrorForwarding = CoreManager.MomConsole.GetIntlStr(ResourceErrorForwarding);
                    }
                    return cachedErrorForwarding;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateFileShare translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateFileShare
            {
                get
                {
                    if ((cachedCreateFileShare == null))
                    {
                        cachedCreateFileShare = CoreManager.MomConsole.GetIntlStr(ResourceCreateFileShare);
                    }
                    return cachedCreateFileShare;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskStatus translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskStatus
            {
                get
                {
                    if ((cachedTaskStatus == null))
                    {
                        cachedTaskStatus = CoreManager.MomConsole.GetIntlStr(ResourceTaskStatus);
                    }
                    return cachedTaskStatus;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DeploySettings translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeploySettings
            {
                get
                {
                    if ((cachedDeploySettings == null))
                    {
                        cachedDeploySettings = CoreManager.MomConsole.GetIntlStr(ResourceDeploySettings);
                    }
                    return cachedDeploySettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UserName translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// Exposes access to the OtherUserAccountWillNotBeSaved translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OtherUserAccountWillNotBeSaved
            {
                get
                {
                    if ((cachedOtherUserAccountWillNotBeSaved == null))
                    {
                        cachedOtherUserAccountWillNotBeSaved = CoreManager.MomConsole.GetIntlStr(ResourceOtherUserAccountWillNotBeSaved);
                    }
                    return cachedOtherUserAccountWillNotBeSaved;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExistingUserAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExistingUserAccount
            {
                get
                {
                    if ((cachedExistingUserAccount == null))
                    {
                        cachedExistingUserAccount = CoreManager.MomConsole.GetIntlStr(ResourceExistingUserAccount);
                    }
                    return cachedExistingUserAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide
            {
                get
                {
                    if ((cachedThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide == null))
                    {
                        cachedThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide = CoreManager.MomConsole.GetIntlStr(ResourceThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide);
                    }
                    return cachedThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskCredentials translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskCredentials
            {
                get
                {
                    if ((cachedTaskCredentials == null))
                    {
                        cachedTaskCredentials = CoreManager.MomConsole.GetIntlStr(ResourceTaskCredentials);
                    }
                    return cachedTaskCredentials;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
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
            /// Exposes access to the CreateFileShare2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateFileShare2
            {
                get
                {
                    if ((cachedCreateFileShare2 == null))
                    {
                        cachedCreateFileShare2 = CoreManager.MomConsole.GetIntlStr(ResourceCreateFileShare2);
                    }
                    return cachedCreateFileShare2;
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
        /// 	[lucyra] 4/13/2006 Created
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
            /// Control ID for CEIPForwardingStaticControl
            /// </summary>
            public const string CEIPForwardingStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ErrorCollectionStaticControl
            /// </summary>
            public const string ErrorCollectionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ErrorForwardingStaticControl
            /// </summary>
            public const string ErrorForwardingStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CreateFileShareStaticControl
            /// </summary>
            public const string CreateFileShareStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for TaskStatusStaticControl
            /// </summary>
            public const string TaskStatusStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DeploySettingsStaticControl
            /// </summary>
            public const string DeploySettingsStaticControl = "textLinkLabel";
            
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
            /// Control ID for ComboBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox0 = "comboBoxExistingAccounts";
            
            /// <summary>
            /// Control ID for OtherUserAccountWillNotBeSavedRadioButton
            /// </summary>
            public const string OtherUserAccountWillNotBeSavedRadioButton = "radioButtonNew";
            
            /// <summary>
            /// Control ID for ExistingUserAccountRadioButton
            /// </summary>
            public const string ExistingUserAccountRadioButton = "radioButtonExisting";
            
            /// <summary>
            /// Control ID for ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide
            /// </summary>
            public const string ThisWizardWillNowAttemptToCreateAFileShareOnTheDirectoryYouIndicatedOnThePreviousDialogPleaseProvide = "labelDescription";
            
            /// <summary>
            /// Control ID for TaskCredentialsStaticControl
            /// </summary>
            public const string TaskCredentialsStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for CreateFileShareStaticControl2
            /// </summary>
            public const string CreateFileShareStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
