// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunTaskDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 9/14/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks
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
    /// 	[faizalk] 9/14/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// Other = 0
        /// </summary>
        Other = 0,
        
        /// <summary>
        /// UseThePredefinedRunAsAccount = 1
        /// </summary>
        UseThePredefinedRunAsAccount = 1,
    }
    #endregion
    
    #region Interface Definition - IRunTaskDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunTaskDialogControls, for RunTaskDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 9/14/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunTaskDialogControls
    {
        /// <summary>
        /// Read-only property to access RunTheTaskOnTheseTargetsStaticControl
        /// </summary>
        StaticControl RunTheTaskOnTheseTargetsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunTheTaskOnTheseTargetsListView
        /// </summary>
        ListView RunTheTaskOnTheseTargetsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskParametersListView
        /// </summary>
        ListView TaskParametersListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskParametersStaticControl
        /// </summary>
        StaticControl TaskParametersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OverrideButton
        /// </summary>
        Button OverrideButton
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
        /// Read-only property to access TaskConfirmationStaticControl
        /// </summary>
        StaticControl TaskConfirmationStaticControl
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
        /// Read-only property to access DomainStaticControl
        /// </summary>
        StaticControl DomainStaticControl
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
        /// Read-only property to access PasswordStaticControl
        /// </summary>
        StaticControl PasswordStaticControl
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
        /// Read-only property to access UserNameStaticControl
        /// </summary>
        StaticControl UserNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OtherRadioButton
        /// </summary>
        RadioButton OtherRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseThePredefinedRunAsAccountRadioButton
        /// </summary>
        RadioButton UseThePredefinedRunAsAccountRadioButton
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
        /// Read-only property to access RunButton
        /// </summary>
        Button RunButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DontPromptWhenRunningThisTaskInTheFutureCheckBox
        /// </summary>
        CheckBox DontPromptWhenRunningThisTaskInTheFutureCheckBox
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
    /// 	[faizalk] 9/14/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RunTaskDialog : Dialog, IRunTaskDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to RunTheTaskOnTheseTargetsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunTheTaskOnTheseTargetsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunTheTaskOnTheseTargetsListView of type ListView
        /// </summary>
        private ListView cachedRunTheTaskOnTheseTargetsListView;
        
        /// <summary>
        /// Cache to hold a reference to TaskParametersListView of type ListView
        /// </summary>
        private ListView cachedTaskParametersListView;
        
        /// <summary>
        /// Cache to hold a reference to TaskParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskParametersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OverrideButton of type Button
        /// </summary>
        private Button cachedOverrideButton;
        
        /// <summary>
        /// Cache to hold a reference to TaskCredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskCredentialsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TaskConfirmationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskConfirmationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DomainEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedDomainEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainTextBox of type TextBox
        /// </summary>
        private TextBox cachedDomainTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PasswordTextBox of type TextBox
        /// </summary>
        private TextBox cachedPasswordTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PasswordStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPasswordStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedUserNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to UserNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUserNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OtherRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedOtherRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseThePredefinedRunAsAccountRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseThePredefinedRunAsAccountRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to RunButton of type Button
        /// </summary>
        private Button cachedRunButton;
        
        /// <summary>
        /// Cache to hold a reference to DontPromptWhenRunningThisTaskInTheFutureCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDontPromptWhenRunningThisTaskInTheFutureCheckBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RunTaskDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunTaskDialog(ConsoleApp app) : 
                base(app, Init(app))
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
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.OtherRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.Other;
                }
                
                if ((this.Controls.UseThePredefinedRunAsAccountRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.UseThePredefinedRunAsAccount;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.Other))
                {
                    this.Controls.OtherRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.UseThePredefinedRunAsAccount))
                    {
                        this.Controls.UseThePredefinedRunAsAccountRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IRunTaskDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunTaskDialogControls Controls
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
        ///  Property to handle checkbox DontPromptWhenRunningThisTaskInTheFuture
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool DontPromptWhenRunningThisTaskInTheFuture
        {
            get
            {
                return this.Controls.DontPromptWhenRunningThisTaskInTheFutureCheckBox.Checked;
            }
            
            set
            {
                this.Controls.DontPromptWhenRunningThisTaskInTheFutureCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Domain
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
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
        /// 	[faizalk] 9/14/2006 Created
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
        ///  Routine to set/get the text in control Password
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
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
        ///  Routine to set/get the text in control UserName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
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
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunTheTaskOnTheseTargetsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunTaskDialogControls.RunTheTaskOnTheseTargetsStaticControl
        {
            get
            {
                if ((this.cachedRunTheTaskOnTheseTargetsStaticControl == null))
                {
                    this.cachedRunTheTaskOnTheseTargetsStaticControl = new StaticControl(this, RunTaskDialog.ControlIDs.RunTheTaskOnTheseTargetsStaticControl);
                }
                
                return this.cachedRunTheTaskOnTheseTargetsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunTheTaskOnTheseTargetsListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IRunTaskDialogControls.RunTheTaskOnTheseTargetsListView
        {
            get
            {
                if ((this.cachedRunTheTaskOnTheseTargetsListView == null))
                {
                    this.cachedRunTheTaskOnTheseTargetsListView = new ListView(this, RunTaskDialog.ControlIDs.RunTheTaskOnTheseTargetsListView);
                }
                
                return this.cachedRunTheTaskOnTheseTargetsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskParametersListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IRunTaskDialogControls.TaskParametersListView
        {
            get
            {
                if ((this.cachedTaskParametersListView == null))
                {
                    this.cachedTaskParametersListView = new ListView(this, RunTaskDialog.ControlIDs.TaskParametersListView);
                }
                
                return this.cachedTaskParametersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunTaskDialogControls.TaskParametersStaticControl
        {
            get
            {
                if ((this.cachedTaskParametersStaticControl == null))
                {
                    this.cachedTaskParametersStaticControl = new StaticControl(this, RunTaskDialog.ControlIDs.TaskParametersStaticControl);
                }
                
                return this.cachedTaskParametersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OverrideButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunTaskDialogControls.OverrideButton
        {
            get
            {
                if ((this.cachedOverrideButton == null))
                {
                    this.cachedOverrideButton = new Button(this, RunTaskDialog.ControlIDs.OverrideButton);
                }
                
                return this.cachedOverrideButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskCredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunTaskDialogControls.TaskCredentialsStaticControl
        {
            get
            {
                if ((this.cachedTaskCredentialsStaticControl == null))
                {
                    this.cachedTaskCredentialsStaticControl = new StaticControl(this, RunTaskDialog.ControlIDs.TaskCredentialsStaticControl);
                }
                
                return this.cachedTaskCredentialsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskConfirmationStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunTaskDialogControls.TaskConfirmationStaticControl
        {
            get
            {
                if ((this.cachedTaskConfirmationStaticControl == null))
                {
                    this.cachedTaskConfirmationStaticControl = new StaticControl(this, RunTaskDialog.ControlIDs.TaskConfirmationStaticControl);
                }
                
                return this.cachedTaskConfirmationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainEditComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunTaskDialogControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, RunTaskDialog.ControlIDs.DomainEditComboBox);
                }
                
                return this.cachedDomainEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRunTaskDialogControls.DomainTextBox
        {
            get
            {
                if ((this.cachedDomainTextBox == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
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
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunTaskDialogControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, RunTaskDialog.ControlIDs.DomainStaticControl);
                }
                
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRunTaskDialogControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, RunTaskDialog.ControlIDs.PasswordTextBox);
                }
                
                return this.cachedPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunTaskDialogControls.PasswordStaticControl
        {
            get
            {
                if ((this.cachedPasswordStaticControl == null))
                {
                    this.cachedPasswordStaticControl = new StaticControl(this, RunTaskDialog.ControlIDs.PasswordStaticControl);
                }
                
                return this.cachedPasswordStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRunTaskDialogControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, RunTaskDialog.ControlIDs.UserNameTextBox);
                }
                
                return this.cachedUserNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunTaskDialogControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, RunTaskDialog.ControlIDs.UserNameStaticControl);
                }
                
                return this.cachedUserNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OtherRadioButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IRunTaskDialogControls.OtherRadioButton
        {
            get
            {
                if ((this.cachedOtherRadioButton == null))
                {
                    this.cachedOtherRadioButton = new RadioButton(this, RunTaskDialog.ControlIDs.OtherRadioButton);
                }
                
                return this.cachedOtherRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseThePredefinedRunAsAccountRadioButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IRunTaskDialogControls.UseThePredefinedRunAsAccountRadioButton
        {
            get
            {
                if ((this.cachedUseThePredefinedRunAsAccountRadioButton == null))
                {
                    this.cachedUseThePredefinedRunAsAccountRadioButton = new RadioButton(this, RunTaskDialog.ControlIDs.UseThePredefinedRunAsAccountRadioButton);
                }
                
                return this.cachedUseThePredefinedRunAsAccountRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunTaskDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RunTaskDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunTaskDialogControls.RunButton
        {
            get
            {
                if ((this.cachedRunButton == null))
                {
                    this.cachedRunButton = new Button(this, RunTaskDialog.ControlIDs.RunButton);
                }
                
                return this.cachedRunButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DontPromptWhenRunningThisTaskInTheFutureCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRunTaskDialogControls.DontPromptWhenRunningThisTaskInTheFutureCheckBox
        {
            get
            {
                if ((this.cachedDontPromptWhenRunningThisTaskInTheFutureCheckBox == null))
                {
                    this.cachedDontPromptWhenRunningThisTaskInTheFutureCheckBox = new CheckBox(this, RunTaskDialog.ControlIDs.DontPromptWhenRunningThisTaskInTheFutureCheckBox);
                }
                
                return this.cachedDontPromptWhenRunningThisTaskInTheFutureCheckBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Override
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOverride()
        {
            this.Controls.OverrideButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Run
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRun()
        {
            this.Controls.RunButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DontPromptWhenRunningThisTaskInTheFuture
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDontPromptWhenRunningThisTaskInTheFuture()
        {
            this.Controls.DontPromptWhenRunningThisTaskInTheFutureCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle + "*", StringMatchSyntax.WildCard, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                         Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);
                         
                         // wait for a moment before trying again
                         Maui.Core.Utilities.Sleeper.Delay(Timeout);
                     }
                 }
                 
                 // check for success
                 if (tempWindow == null)
                 {
                     // log the failure
                     Core.Common.Utilities.LogMessage("Failed to find window " + Strings.DialogTitle);
                 
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
        /// 	[faizalk] 9/14/2006 Created
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
            private const string ResourceDialogTitle = ";Run Task - ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;runTaskTitlePrefix";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunTheTaskOnTheseTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunTheTaskOnTheseTargets = ";Run the &task on these targets;ManagedString;Microsoft.MOM.UI.Components.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskDialog;targetsLabel.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskParameters = ";T&ask Parameters;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.RunTask.RunTaskDialog;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Override
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOverride = ";&Override;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.RunTask.RunTaskDialog;overrideButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskCredentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskCredentials = ";Task credentials;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.RunTask.RunTaskDialog;credentialsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskConfirmation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskConfirmation = ";Task confirmation;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.RunTask.RunTaskDialog;confirmationLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDomain = ";&Domain : ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.RunTask.RunTaskDialog;domainLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Password
            /// </summary>
            /// -----------------------------------------------------------------------------
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UserName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserName = ";&User name : ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.RunTask.RunTaskDialog;userNameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Other
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOther = ";Oth&er : ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.RunTask.RunTaskDialog;otherAccountRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseThePredefinedRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseThePredefinedRunAsAccount = ";U&se the predefined Run As Account;ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskDialog;runAsAccou" +
                "ntRadio.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Run
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRun = ";&Run;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.Internal.UI.RunTask.RunTaskDialog;runButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DontPromptWhenRunningThisTaskInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDontPromptWhenRunningThisTaskInTheFuture = ";Don\'t pro&mpt when running this task in the future;ManagedString;Microsoft.MOM.U" +
                "I.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskD" +
                "ialog;promptCheckbox.Text";
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
            /// Caches the translated resource string for:  RunTheTaskOnTheseTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunTheTaskOnTheseTargets;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Override
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverride;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskCredentials
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskCredentials;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskConfirmation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskConfirmation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Password
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPassword;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UserName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Other
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOther;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseThePredefinedRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseThePredefinedRunAsAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Run
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRun;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DontPromptWhenRunningThisTaskInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDontPromptWhenRunningThisTaskInTheFuture;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
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
            /// Exposes access to the RunTheTaskOnTheseTargets translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunTheTaskOnTheseTargets
            {
                get
                {
                    if ((cachedRunTheTaskOnTheseTargets == null))
                    {
                        cachedRunTheTaskOnTheseTargets = CoreManager.MomConsole.GetIntlStr(ResourceRunTheTaskOnTheseTargets);
                    }
                    
                    return cachedRunTheTaskOnTheseTargets;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskParameters translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskParameters
            {
                get
                {
                    if ((cachedTaskParameters == null))
                    {
                        cachedTaskParameters = CoreManager.MomConsole.GetIntlStr(ResourceTaskParameters);
                    }
                    
                    return cachedTaskParameters;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Override translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Override
            {
                get
                {
                    if ((cachedOverride == null))
                    {
                        cachedOverride = CoreManager.MomConsole.GetIntlStr(ResourceOverride);
                    }
                    
                    return cachedOverride;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskCredentials translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
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
            /// Exposes access to the TaskConfirmation translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskConfirmation
            {
                get
                {
                    if ((cachedTaskConfirmation == null))
                    {
                        cachedTaskConfirmation = CoreManager.MomConsole.GetIntlStr(ResourceTaskConfirmation);
                    }
                    
                    return cachedTaskConfirmation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Domain translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
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
            /// Exposes access to the Password translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
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
            /// Exposes access to the UserName translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
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
            /// Exposes access to the Other translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Other
            {
                get
                {
                    if ((cachedOther == null))
                    {
                        cachedOther = CoreManager.MomConsole.GetIntlStr(ResourceOther);
                    }
                    
                    return cachedOther;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseThePredefinedRunAsAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseThePredefinedRunAsAccount
            {
                get
                {
                    if ((cachedUseThePredefinedRunAsAccount == null))
                    {
                        cachedUseThePredefinedRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceUseThePredefinedRunAsAccount);
                    }
                    
                    return cachedUseThePredefinedRunAsAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
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
            /// Exposes access to the Run translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Run
            {
                get
                {
                    if ((cachedRun == null))
                    {
                        cachedRun = CoreManager.MomConsole.GetIntlStr(ResourceRun);
                    }
                    
                    return cachedRun;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DontPromptWhenRunningThisTaskInTheFuture translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/14/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DontPromptWhenRunningThisTaskInTheFuture
            {
                get
                {
                    if ((cachedDontPromptWhenRunningThisTaskInTheFuture == null))
                    {
                        cachedDontPromptWhenRunningThisTaskInTheFuture = CoreManager.MomConsole.GetIntlStr(ResourceDontPromptWhenRunningThisTaskInTheFuture);
                    }
                    
                    return cachedDontPromptWhenRunningThisTaskInTheFuture;
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
        /// 	[faizalk] 9/14/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for RunTheTaskOnTheseTargetsStaticControl
            /// </summary>
            public const string RunTheTaskOnTheseTargetsStaticControl = "targetsLabel";
            
            /// <summary>
            /// Control ID for RunTheTaskOnTheseTargetsListView
            /// </summary>
            public const string RunTheTaskOnTheseTargetsListView = "targetsList";
            
            /// <summary>
            /// Control ID for TaskParametersListView
            /// </summary>
            public const string TaskParametersListView = "parametersList";
            
            /// <summary>
            /// Control ID for TaskParametersStaticControl
            /// </summary>
            public const string TaskParametersStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for OverrideButton
            /// </summary>
            public const string OverrideButton = "overrideButton";
            
            /// <summary>
            /// Control ID for TaskCredentialsStaticControl
            /// </summary>
            public const string TaskCredentialsStaticControl = "credentialsLabel";
            
            /// <summary>
            /// Control ID for TaskConfirmationStaticControl
            /// </summary>
            public const string TaskConfirmationStaticControl = "confirmationLabel1";
            
            /// <summary>
            /// Control ID for DomainEditComboBox
            /// </summary>
            public const string DomainEditComboBox = "domainComboBox";
            
            /// <summary>
            /// Control ID for DomainStaticControl
            /// </summary>
            public const string DomainStaticControl = "domainLabel";
            
            /// <summary>
            /// Control ID for PasswordTextBox
            /// </summary>
            public const string PasswordTextBox = "passwordTextBox";
            
            /// <summary>
            /// Control ID for PasswordStaticControl
            /// </summary>
            public const string PasswordStaticControl = "passwordLabel";
            
            /// <summary>
            /// Control ID for UserNameTextBox
            /// </summary>
            public const string UserNameTextBox = "userNameTextBox";
            
            /// <summary>
            /// Control ID for UserNameStaticControl
            /// </summary>
            public const string UserNameStaticControl = "userNameLabel";
            
            /// <summary>
            /// Control ID for OtherRadioButton
            /// </summary>
            public const string OtherRadioButton = "otherAccountRadio";
            
            /// <summary>
            /// Control ID for UseThePredefinedRunAsAccountRadioButton
            /// </summary>
            public const string UseThePredefinedRunAsAccountRadioButton = "runAsAccountRadio";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for RunButton
            /// </summary>
            public const string RunButton = "runButton";
            
            /// <summary>
            /// Control ID for DontPromptWhenRunningThisTaskInTheFutureCheckBox
            /// </summary>
            public const string DontPromptWhenRunningThisTaskInTheFutureCheckBox = "promptCheckbox";
        }
        #endregion
    }
}
