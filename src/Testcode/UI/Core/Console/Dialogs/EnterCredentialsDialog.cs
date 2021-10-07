// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EnterCredentialsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	MOMv3 Sp2.
// </project>
// <summary>
// 	MOMv3 Sp2 test automation
// </summary>
// <history>
// 	[v-yoz] 6/29/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IEnterCredentialsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEnterCredentialsDialogControls, for EnterCredentialsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-yoz] 6/29/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEnterCredentialsDialogControls
    {
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[v-yoz] 6/29/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class EnterCredentialsDialog : Dialog, IEnterCredentialsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
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
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of EnterCredentialsDialog of type App
        /// </param>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EnterCredentialsDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IEnterCredentialsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEnterCredentialsDialogControls Controls
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
        /// 	[v-yoz] 6/29/2009 Created
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
        /// 	[v-yoz] 6/29/2009 Created
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
        /// 	[v-yoz] 6/29/2009 Created
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
        /// 	[v-yoz] 6/29/2009 Created
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
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterCredentialsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EnterCredentialsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEnterCredentialsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, EnterCredentialsDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterCredentialsDialogControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, EnterCredentialsDialog.ControlIDs.UserNameStaticControl);
                }
                
                return this.cachedUserNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameTextBox control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEnterCredentialsDialogControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, EnterCredentialsDialog.ControlIDs.UserNameTextBox);
                }
                
                return this.cachedUserNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterCredentialsDialogControls.PasswordStaticControl
        {
            get
            {
                if ((this.cachedPasswordStaticControl == null))
                {
                    this.cachedPasswordStaticControl = new StaticControl(this, EnterCredentialsDialog.ControlIDs.PasswordStaticControl);
                }
                
                return this.cachedPasswordStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordTextBox control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEnterCredentialsDialogControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, EnterCredentialsDialog.ControlIDs.PasswordTextBox);
                }
                
                return this.cachedPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEnterCredentialsDialogControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, EnterCredentialsDialog.ControlIDs.DomainStaticControl);
                }
                
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainEditComboBox control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IEnterCredentialsDialogControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, EnterCredentialsDialog.ControlIDs.DomainEditComboBox);
                }
                
                return this.cachedDomainEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainTextBox control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEnterCredentialsDialogControls.DomainTextBox
        {
            get
            {
                if ((this.cachedDomainTextBox == null))
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
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
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
                    catch (Exceptions.WindowNotFoundException)
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
        /// Strings Class
        /// </summary>
        /// <history>
        /// 	[v-yoz] 6/29/2009 Created
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
                ";Enter Credentials;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.CredentialForm;$this.Text";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

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
                            Core.Console.CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }

                    return cachedDialogTitle;
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
        /// 	[v-yoz] 6/29/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
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
        }
        #endregion
    }
}
