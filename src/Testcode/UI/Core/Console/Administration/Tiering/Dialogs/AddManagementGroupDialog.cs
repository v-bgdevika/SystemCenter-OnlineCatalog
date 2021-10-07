// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddManagementGroupDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 Sp2.
// </project>
// <summary>
// 	MOMv3 Sp2 test automation
// </summary>
// <history>
// 	[KellyMor]  09-Apr-08   Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Tiering
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
    /// 	[KellyMor] 09-Apr-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// OtherUserAccount = 0
        /// </summary>
        OtherUserAccount = 0,
        
        /// <summary>
        /// UseSDKServiceAccount = 1
        /// </summary>
        UseSDKServiceAccount = 1,
    }
    #endregion
    
    #region Interface Definition - IAddManagementGroupDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddManagementGroupDialogControls, for AddManagementGroupDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 09-Apr-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddManagementGroupDialogControls
    {
        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
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
        /// Read-only property to access OtherUserAccountRadioButton
        /// </summary>
        RadioButton OtherUserAccountRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseSDKServiceAccountRadioButton
        /// </summary>
        RadioButton UseSDKServiceAccountRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FqdnOfRemoteRootManagementServerStaticControl
        /// </summary>
        StaticControl FqdnOfRemoteRootManagementServerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RootManagementServerTextBox
        /// </summary>
        TextBox RootManagementServerTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RootManagementServerStaticControl
        /// </summary>
        StaticControl RootManagementServerStaticControl
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
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementGroupNameTextBox
        /// </summary>
        TextBox ManagementGroupNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementGroupNameStaticControl
        /// </summary>
        StaticControl ManagementGroupNameStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality for the "Add Management Group"
    /// dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 09-Apr-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddManagementGroupDialog : Dialog, IAddManagementGroupDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
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
        /// Cache to hold a reference to OtherUserAccountRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedOtherUserAccountRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UseSDKServiceAccountRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseSDKServiceAccountRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to FqdnOfRemoteRootManagementServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFqdnOfRemoteRootManagementServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RootManagementServerTextBox of type TextBox
        /// </summary>
        private TextBox cachedRootManagementServerTextBox;
        
        /// <summary>
        /// Cache to hold a reference to RootManagementServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRootManagementServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to ManagementGroupNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedManagementGroupNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementGroupNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementGroupNameStaticControl;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddManagementGroupDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddManagementGroupDialog(ConsoleApp app) : 
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
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.OtherUserAccountRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.OtherUserAccount;
                }
                
                if ((this.Controls.UseSDKServiceAccountRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.UseSDKServiceAccount;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.OtherUserAccount))
                {
                    this.Controls.OtherUserAccountRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.UseSDKServiceAccount))
                    {
                        this.Controls.UseSDKServiceAccountRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IAddManagementGroupDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddManagementGroupDialogControls Controls
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
        /// 	[KellyMor] 09-Apr-08 Created
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
        /// 	[KellyMor] 09-Apr-08 Created
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
        /// 	[KellyMor] 09-Apr-08 Created
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
        /// 	[KellyMor] 09-Apr-08 Created
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
        ///  Routine to set/get the text in control RootManagementServer
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RootManagementServerText
        {
            get
            {
                return this.Controls.RootManagementServerTextBox.Text;
            }
            
            set
            {
                this.Controls.RootManagementServerTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ManagementGroupName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementGroupNameText
        {
            get
            {
                return this.Controls.ManagementGroupNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ManagementGroupNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddManagementGroupDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, AddManagementGroupDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddManagementGroupDialogControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, AddManagementGroupDialog.ControlIDs.UserNameStaticControl);
                }
                
                return this.cachedUserNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddManagementGroupDialogControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, AddManagementGroupDialog.ControlIDs.UserNameTextBox);
                }
                
                return this.cachedUserNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddManagementGroupDialogControls.PasswordStaticControl
        {
            get
            {
                if ((this.cachedPasswordStaticControl == null))
                {
                    this.cachedPasswordStaticControl = new StaticControl(this, AddManagementGroupDialog.ControlIDs.PasswordStaticControl);
                }
                
                return this.cachedPasswordStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddManagementGroupDialogControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, AddManagementGroupDialog.ControlIDs.PasswordTextBox);
                }
                
                return this.cachedPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddManagementGroupDialogControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, AddManagementGroupDialog.ControlIDs.DomainStaticControl);
                }
                
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IAddManagementGroupDialogControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, AddManagementGroupDialog.ControlIDs.DomainEditComboBox);
                }
                
                return this.cachedDomainEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddManagementGroupDialogControls.DomainTextBox
        {
            get
            {
                if ((this.cachedDomainTextBox == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
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
        ///  Exposes access to the OtherUserAccountRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAddManagementGroupDialogControls.OtherUserAccountRadioButton
        {
            get
            {
                if ((this.cachedOtherUserAccountRadioButton == null))
                {
                    this.cachedOtherUserAccountRadioButton = new RadioButton(this, AddManagementGroupDialog.ControlIDs.OtherUserAccountRadioButton);
                }
                
                return this.cachedOtherUserAccountRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseSDKServiceAccountRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAddManagementGroupDialogControls.UseSDKServiceAccountRadioButton
        {
            get
            {
                if ((this.cachedUseSDKServiceAccountRadioButton == null))
                {
                    this.cachedUseSDKServiceAccountRadioButton = new RadioButton(this, AddManagementGroupDialog.ControlIDs.UseSDKServiceAccountRadioButton);
                }
                
                return this.cachedUseSDKServiceAccountRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FqdnOfRemoteRootManagementServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddManagementGroupDialogControls.FqdnOfRemoteRootManagementServerStaticControl
        {
            get
            {
                if ((this.cachedFqdnOfRemoteRootManagementServerStaticControl == null))
                {
                    this.cachedFqdnOfRemoteRootManagementServerStaticControl = new StaticControl(this, AddManagementGroupDialog.ControlIDs.FqdnOfRemoteRootManagementServerStaticControl);
                }
                
                return this.cachedFqdnOfRemoteRootManagementServerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RootManagementServerTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddManagementGroupDialogControls.RootManagementServerTextBox
        {
            get
            {
                if ((this.cachedRootManagementServerTextBox == null))
                {
                    this.cachedRootManagementServerTextBox = new TextBox(this, AddManagementGroupDialog.ControlIDs.RootManagementServerTextBox);
                }
                
                return this.cachedRootManagementServerTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RootManagementServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddManagementGroupDialogControls.RootManagementServerStaticControl
        {
            get
            {
                if ((this.cachedRootManagementServerStaticControl == null))
                {
                    this.cachedRootManagementServerStaticControl = new StaticControl(this, AddManagementGroupDialog.ControlIDs.RootManagementServerStaticControl);
                }
                
                return this.cachedRootManagementServerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddManagementGroupDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddManagementGroupDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddManagementGroupDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, AddManagementGroupDialog.ControlIDs.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementGroupNameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddManagementGroupDialogControls.ManagementGroupNameTextBox
        {
            get
            {
                if ((this.cachedManagementGroupNameTextBox == null))
                {
                    this.cachedManagementGroupNameTextBox = new TextBox(this, AddManagementGroupDialog.ControlIDs.ManagementGroupNameTextBox);
                }
                
                return this.cachedManagementGroupNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementGroupNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddManagementGroupDialogControls.ManagementGroupNameStaticControl
        {
            get
            {
                if ((this.cachedManagementGroupNameStaticControl == null))
                {
                    this.cachedManagementGroupNameStaticControl = new StaticControl(this, AddManagementGroupDialog.ControlIDs.ManagementGroupNameStaticControl);
                }
                
                return this.cachedManagementGroupNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        Strings.DialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; 
                    ((null == tempWindow) && (numberOfTries < maxTries)); 
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = 
                            new Window(
                                Strings.DialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
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
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions
        /// </summary>
        /// <history>
        /// 	[KellyMor] 09-Apr-08 Created
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
                ";Add Management Group" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = 
                ";Help" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";linkLabelHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UserName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserName =
                ";&User name:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";userAccount.UserCaption";
            
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
            private const string ResourceDomain =
                ";Domai&n:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";userAccount.DomainCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OtherUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOtherUserAccount =
                ";&Other user account" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";radioButtonOtherAccount.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseSDKServiceAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseSDKServiceAccount =
                ";U&se SDK service account" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";radioButtonServiceAccount.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FqdnOfRemoteRootManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFqdnOfRemoteRootManagementServer =
                @";The fully qualified domain name (FQDN) of the Root Management Server of the other Management Group." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";labelServerNote.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RootManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRootManagementServer =
                ";&Root Management Server:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";labelServer.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";buttonCancel" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";>>buttonCancel.Name";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd =
                ";&Add" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";buttonOK.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementGroupName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementGroupName =
                ";&Management Group name:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm" +
                ";labelGroup.Text";

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
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
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
            /// Caches the translated resource string for:  OtherUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOtherUserAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseSDKServiceAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseSDKServiceAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FqdnOfRemoteRootManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFqdnOfRemoteRootManagementServer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RootManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRootManagementServer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementGroupName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementGroupName;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = 
                            CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
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
            /// Exposes access to the UserName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
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
            /// 	[KellyMor] 09-Apr-08 Created
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
            /// 	[KellyMor] 09-Apr-08 Created
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
            /// Exposes access to the OtherUserAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OtherUserAccount
            {
                get
                {
                    if ((cachedOtherUserAccount == null))
                    {
                        cachedOtherUserAccount = CoreManager.MomConsole.GetIntlStr(ResourceOtherUserAccount);
                    }
                    
                    return cachedOtherUserAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseSDKServiceAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseSDKServiceAccount
            {
                get
                {
                    if ((cachedUseSDKServiceAccount == null))
                    {
                        cachedUseSDKServiceAccount = CoreManager.MomConsole.GetIntlStr(ResourceUseSDKServiceAccount);
                    }
                    
                    return cachedUseSDKServiceAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FqdnOfRemoteRootManagementServer translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FqdnOfRemoteRootManagementServer
            {
                get
                {
                    if ((cachedFqdnOfRemoteRootManagementServer == null))
                    {
                        cachedFqdnOfRemoteRootManagementServer = CoreManager.MomConsole.GetIntlStr(ResourceFqdnOfRemoteRootManagementServer);
                    }
                    
                    return cachedFqdnOfRemoteRootManagementServer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RootManagementServer translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RootManagementServer
            {
                get
                {
                    if ((cachedRootManagementServer == null))
                    {
                        cachedRootManagementServer = CoreManager.MomConsole.GetIntlStr(ResourceRootManagementServer);
                    }
                    
                    return cachedRootManagementServer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
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
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    
                    return cachedAdd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementGroupName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09-Apr-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementGroupName
            {
                get
                {
                    if ((cachedManagementGroupName == null))
                    {
                        cachedManagementGroupName = CoreManager.MomConsole.GetIntlStr(ResourceManagementGroupName);
                    }
                    
                    return cachedManagementGroupName;
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
        /// 	[KellyMor] 09-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "linkLabelHelp";
            
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
            /// Control ID for OtherUserAccountRadioButton
            /// </summary>
            public const string OtherUserAccountRadioButton = "radioButtonOtherAccount";
            
            /// <summary>
            /// Control ID for UseSDKServiceAccountRadioButton
            /// </summary>
            public const string UseSDKServiceAccountRadioButton = "radioButtonServiceAccount";
            
            /// <summary>
            /// Control ID for FqdnOfRemoteRootManagementServerStaticControl
            /// </summary>
            public const string FqdnOfRemoteRootManagementServerStaticControl = "labelServerNote";
            
            /// <summary>
            /// Control ID for RootManagementServerTextBox
            /// </summary>
            public const string RootManagementServerTextBox = "textBoxServer";
            
            /// <summary>
            /// Control ID for RootManagementServerStaticControl
            /// </summary>
            public const string RootManagementServerStaticControl = "labelServer";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "okButton";
            
            /// <summary>
            /// Control ID for ManagementGroupNameTextBox
            /// </summary>
            public const string ManagementGroupNameTextBox = "textBoxGroup";
            
            /// <summary>
            /// Control ID for ManagementGroupNameStaticControl
            /// </summary>
            public const string ManagementGroupNameStaticControl = "labelGroup";
        }
        #endregion
    }
}
