// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="LoginDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [nathd] 8/28/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Linq;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - AuthRadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group AuthRadioGroup
    /// </summary>
    /// <history>
    ///   [nathd] 8/28/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum AuthRadioGroup
    {
        /// <summary>
        /// WindowsAuth = 0
        /// </summary>
        WindowsAuth = 0,
        
        /// <summary>
        /// NetworkAuth = 1
        /// </summary>
        NetworkAuth = 1,
    }
    #endregion
    
    #region Interface Definition - ILoginDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ILoginDialogControls, for LoginDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [nathd] 8/28/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ILoginDialogControls
    {
        /// <summary>
        /// Gets read-only property to access WelcomeUsernameStaticControl
        /// </summary>
        StaticControl WelcomeUsernameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SignOutLinkLabel
        /// </summary>
        LinkLabel SignOutLinkLabel
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to the SignOutButton
        /// </summary>
        Button SignOutButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to the SignOutButton
        /// </summary>
        ProgressBar ProgressBar
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access SignInStaticControl
        /// </summary>
        StaticControl SignInStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access WindowsAuthRadioButton
        /// </summary>
        RadioButton WindowsAuthRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NetworkAuthRadioButton
        /// </summary>
        RadioButton NetworkAuthRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access UsernameTextBox
        /// </summary>
        /// <remark>
        /// </remark>
        TextBox UsernameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PasswordTextBox
        /// </summary>
        /// <remark>
        /// </remark>
        TextBox PasswordTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SignInButton
        /// </summary>
        Button SignInButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SignInErrorTextStaticControl
        /// </summary>
        StaticControl SignInErrorTextStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ShowErrorDetailLinkLabel
        /// </summary>
        LinkLabel ShowErrorDetailLinkLabel
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
    ///   [nathd] 8/28/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class LoginDialog : Window, ILoginDialogControls
    {
        #region Private Static Members

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        private static Window activeWindow;
        
        /// <summary>
        /// Cache to hold a reference to a XDocument with a loaded Xml file
        /// </summary>
        private static XDocument cachedXmlDocument;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to WelcomeUsernameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWelcomeUsernameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SignOutLinkLabel of type LinkLabel
        /// </summary>
        private LinkLabel cachedSignOutLinkLabel;
        
        /// <summary>
        /// Cache to hold a reference to SignInStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSignInStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WindowsAuthRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWindowsAuthRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to NetworkAuthRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedNetworkAuthRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to UsernameTextBox of type TextBox
        /// </summary>
        private TextBox cachedUsernameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PasswordTextBox of type TextBox
        /// </summary>
        private TextBox cachedPasswordTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SignInButton of type Button
        /// </summary>
        private Button cachedSignInButton;

        /// <summary>
        /// Cache to hold a reference to SignOutButton of type Button
        /// </summary>
        private Button cachedSignOutButton;

        /// <summary>
        /// Cache to hold a reference to SignInErrorTextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSignInErrorTextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ShowErrorDetailLinkLabel of type LinkLabel
        /// </summary>
        private LinkLabel cachedShowErrorDetailLinkLabel;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the LoginDialog class.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of LoginDialog of type App
        /// </param>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public LoginDialog(Window ownerWindow, int timeout) : 
                base(Init(ownerWindow, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Properties
        /// <summary>
        /// Property used to determine whether the LoginDialog is visible.
        /// </summary>
        public new bool IsVisible
        {
            get 
            {
                // If we have a handle and the following controls are visible the login dialog must be visible.
                if (this.Controls.UsernameTextBox.IsVisible && this.Controls.PasswordTextBox.IsVisible && this.Controls.SignInButton.IsVisible)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion Properties

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets functionality for radio group AuthRadioGroup
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual AuthRadioGroup AuthRadioGroup
        {
            get
            {
                if ((this.Controls.WindowsAuthRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AuthRadioGroup.WindowsAuth;
                }
                
                if ((this.Controls.NetworkAuthRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AuthRadioGroup.NetworkAuth;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == AuthRadioGroup.WindowsAuth))
                {
                    this.Controls.WindowsAuthRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == AuthRadioGroup.NetworkAuth))
                    {
                        this.Controls.NetworkAuthRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ILoginDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ILoginDialogControls Controls
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
        ///  Gets or sets the text in control UsernameTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UsernameTextBoxText
        {
            get
            {
                return this.Controls.UsernameTextBox.Text;
            }
            
            set
            {
                this.Controls.UsernameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control PasswordTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PasswordTextBoxText
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
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the WelcomeUsernameStaticControl control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (WelcomeUsernameStaticControl) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl ILoginDialogControls.WelcomeUsernameStaticControl
        {
            get
            {
                if ((this.cachedWelcomeUsernameStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedWelcomeUsernameStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedWelcomeUsernameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SignOutLinkLabel control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (SignOutLinkLabel) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        LinkLabel ILoginDialogControls.SignOutLinkLabel
        {
            get
            {
                if ((this.cachedSignOutLinkLabel == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedSignOutLinkLabel = new LinkLabel(wndTemp);
                }
                
                return this.cachedSignOutLinkLabel;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SignInStaticControl control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (SignInStaticControl) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl ILoginDialogControls.SignInStaticControl
        {
            get
            {
                if ((this.cachedSignInStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedSignInStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedSignInStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the WindowsAuthRadioButton control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ILoginDialogControls.WindowsAuthRadioButton
        {
            get
            {
                if ((this.cachedWindowsAuthRadioButton == null))
                {
                    this.cachedWindowsAuthRadioButton = new RadioButton(this, LoginDialog.QueryIds.WindowsAuthRadioButton);
                }
                
                return this.cachedWindowsAuthRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NetworkAuthRadioButton control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ILoginDialogControls.NetworkAuthRadioButton
        {
            get
            {
                if ((this.cachedNetworkAuthRadioButton == null))
                {
                    this.cachedNetworkAuthRadioButton = new RadioButton(this, LoginDialog.QueryIds.NetworkAuthRadioButton);
                }
                
                return this.cachedNetworkAuthRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the UsernameTextBox control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ILoginDialogControls.UsernameTextBox
        {
            get
            {
                if ((this.cachedUsernameTextBox == null))
                {
                    this.cachedUsernameTextBox = new TextBox(this, LoginDialog.QueryIds.UsernameTextBox,Constants.DefaultDialogTimeout);
                }
                
                return this.cachedUsernameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PasswordTextBox control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ILoginDialogControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, LoginDialog.QueryIds.PasswordTextBox,Constants.DefaultDialogTimeout);
                }
                
                return this.cachedPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SignInButton control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ILoginDialogControls.SignInButton
        {
            get
            {
                if ((this.cachedSignInButton == null))
                {
                    this.cachedSignInButton = new Button(this, LoginDialog.QueryIds.SignInButton, Constants.DefaultDialogTimeout);   
                }
                
                return this.cachedSignInButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SignOutButton control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ILoginDialogControls.SignOutButton
        {
            get
            {
                if ((this.cachedSignOutButton == null))
                {
                    this.cachedSignOutButton = new Button(this, LoginDialog.QueryIds.SignOutButton);
                }

                return this.cachedSignOutButton;
            }
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressBar control.
        ///  TODO: This really needs to be moved to Core.Console.MomControls
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ProgressBar ILoginDialogControls.ProgressBar
        {
            get
            {
                // We do not cache this control as the IsVisible property wasn't
                // being updated on the cached version.
                return new ProgressBar(this, LoginDialog.QueryIds.ProgressBar);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SignInErrorTextStaticControl control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILoginDialogControls.SignInErrorTextStaticControl
        {
            get
            {
                if ((this.cachedSignInErrorTextStaticControl == null))
                {
                    this.cachedSignInErrorTextStaticControl = new StaticControl(this, LoginDialog.QueryIds.SignInErrorTextStaticControl);
                }
                
                return this.cachedSignInErrorTextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ShowErrorDetailLinkLabel control
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        LinkLabel ILoginDialogControls.ShowErrorDetailLinkLabel
        {
            get
            {
                if ((this.cachedShowErrorDetailLinkLabel == null))
                {
                    this.cachedShowErrorDetailLinkLabel = new LinkLabel(this, LoginDialog.QueryIds.ShowErrorDetailLinkLabel);
                }
                
                return this.cachedShowErrorDetailLinkLabel;
            }
        }
        #endregion
        
        #region Private Static Properties

        /// -----------------------------------------------------------
        /// <summary>
        /// Gets the path to the apps Xml on this system
        /// </summary>
        /// <remarks>TODO: Add code to get the right path.</remarks>
        /// <returns>the path to the Apps Xml file.</returns>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------
        private static string XmlPath
        {
            get
            {
                // TODO: Build the path below from the mcf level.
                return @"..\Common\Resources\LoginDialog.resources.xml";
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the loaded XDocument
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static XDocument XmlDocument
        {
            get
            {
                if ((cachedXmlDocument == null))
                {
                    string xmlFile = LoginDialog.XmlPath;
                    LoginDialog.cachedXmlDocument = XDocument.Load(xmlFile);
                }
                
                return LoginDialog.cachedXmlDocument;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SignIn
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSignIn()
        {
            this.Controls.SignInButton.Click();
            this.WaitForSignInToComplete(Common.Constants.DefaultDialogTimeout * 4);     // Wait for up to 1 min.
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SignOut
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSignOut()
        {
            this.Controls.SignOutButton.Click();
            this.WaitForSignInToComplete(Common.Constants.DefaultDialogTimeout * 4);     // Wait for up to 1 min.
        }
        #endregion
      
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A reference to the Window</returns>
        ///  <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Window ownerWindow, int timeout)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window. Current takes ~5 - 7 secs to get a handle to this control.
                tempWindow = new Window(ownerWindow, new QID(";[UIA]Name = '" + Strings.WindowTitle + "'"), timeout);                         
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // TODO:  Add any specific logic here to handle the case when the
                // window is not found in the specified timeout.
                // otherwise rethrow the exception.
                throw;
            }
            
            return tempWindow;
        }

        /// <summary>
        /// Wait for login to the console to complete.
        /// </summary>
        /// <param name="secondsToWait">Max Wait Time</param>
        public void WaitForSignInToComplete(int maxSecondsToWait)
        {
            int waited = maxSecondsToWait;
            string logMessageHeader = "LoginDialog.WaitForSignInToComplete :: ";

            Utilities.LogMessage(logMessageHeader);

            // Sleep for 1 second. I really hate to sleep here, but there 
            // are instances where we've click the signin button, the
            // progressbar is being drawn, but the IsVisible property is still
            // false.
            Sleeper.Delay(Constants.OneSecond);

            // Wait for the login to complete.
            while(this.Controls.ProgressBar != null && this.Controls.ProgressBar.IsVisible && maxSecondsToWait > 0)
            {
                Utilities.LogMessage(logMessageHeader + "ProgressBar.IsVisible = " + this.Controls.ProgressBar.IsVisible.ToString());
                Utilities.LogMessage(logMessageHeader + "ProgressBar.IsEnabled = " + this.Controls.ProgressBar.IsEnabled.ToString());
                Sleeper.Delay(Constants.OneSecond);
                maxSecondsToWait -= 1;
            }

            Utilities.LogMessage(logMessageHeader + "SignIn Complete.");
            Utilities.LogMessage(logMessageHeader + "ProgressBar.IsVisible = " + this.Controls.ProgressBar.IsVisible.ToString());
            Utilities.LogMessage(logMessageHeader + "ProgressBar.IsEnabled = " + this.Controls.ProgressBar.IsEnabled.ToString());

            if (maxSecondsToWait <= 0)
            {
                throw new System.TimeoutException("Login did not complete in " + waited.ToString() + " seconds.");
            }
        }

        /// <summary>
        /// Wait for login to the console to complete.
        /// </summary>
        /// <param name="secondsToWait">Max Wait Time</param>
        public void WaitForSignOutToComplete(int maxSecondsToWait)
        {
            int waited = maxSecondsToWait;
            string logMessageHeader = "LoginDialog.WaitForSignOutToComplete :: ";

            Utilities.LogMessage(logMessageHeader);

            // Sleep for 1 second so that we don't run into timing issues trying
            // to get a handle to the progress bar control... it is only there for 500ms 
            Utilities.LogMessage(logMessageHeader + "Sleeping for 1 second");
            Sleeper.Delay(Constants.OneSecond);

            // Wait for the redirect to default.aspx at signout to happen.
            Utilities.LogMessage(logMessageHeader + "Waiting for the redirect and loading of default.aspx...");

            // Browser.WaitForReady expects milliseconds and DefaultSignOutTimeout is in seconds.
            CoreManager.MomConsole.Browser.WaitForReady(Constants.DefaultSignOutTimeout * 1000);
            Utilities.LogMessage(logMessageHeader + "Browser is ready.");

            try
            {
                // Wait for the logout to complete.
                while (this.Controls.ProgressBar != null && this.Controls.ProgressBar.IsVisible && maxSecondsToWait > 0)
                {
                    Utilities.LogMessage(logMessageHeader + "ProgressBar.IsVisible = " + this.Controls.ProgressBar.IsVisible.ToString());
                    Utilities.LogMessage(logMessageHeader + "ProgressBar.IsEnabled = " + this.Controls.ProgressBar.IsEnabled.ToString());
                    Sleeper.Delay(Constants.OneSecond);
                    maxSecondsToWait -= 1;
                }

                Utilities.LogMessage(logMessageHeader + "SignOut Complete.");
                Utilities.LogMessage(logMessageHeader + "ProgressBar.IsVisible = " + this.Controls.ProgressBar.IsVisible.ToString());
                Utilities.LogMessage(logMessageHeader + "ProgressBar.IsEnabled = " + this.Controls.ProgressBar.IsEnabled.ToString());

                CoreManager.MomConsole.Browser.WaitForReady(Constants.DefaultDialogTimeout * 4);
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException)
            {
                // If a InvalidHWndException is thrown while waiting for signout it is 
                // because the AppDomain has been killed on signout... log message and return.
                Utilities.LogMessage(logMessageHeader + "Hit a InvalidHwdExeception while waiting for signout to complete... assuming this is because the AppDomain was killed on signout... moving on...");
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                // If a WindowNotFoundException is thrown while waiting for signout it is 
                // because the AppDomain has been killed on signout... log message and return.
                Utilities.LogMessage(logMessageHeader + "Hit a WindowNotFoundException while waiting for signout to complete... assuming this is because the AppDomain was killed on signout... moving on...");
            }
            catch (System.InvalidCastException)
            {
                // If an InvalidCastException is thrown while waiting for signout it is 
                // because the AppDomain has been killed on signout... log message and return.
                Utilities.LogMessage(logMessageHeader + "Hit an InvalidCastException while waiting for signout to complete... assuming this is because the AppDomain was killed on signout... moving on...");
            }

            if (maxSecondsToWait <= 0)
            {
                throw new System.TimeoutException("Logout did not complete in " + waited.ToString() + " seconds.");
            }
        }

        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the WindowsAuthRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID WindowsAuthRadioButton
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("WindowsAuthRadioButton") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NetworkAuthRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NetworkAuthRadioButton
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("NetworkAuthRadioButton") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the UsernameTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID UsernameTextBox
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("UsernameTextBox") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PasswordTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PasswordTextBox
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("PasswordTextBox") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SignInButton resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SignInButton
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("SignInButton") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SignOutButton resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SignOutButton
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("SignOutButton") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ProgressBar resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("ProgressBar") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SignInErrorTextStaticControl resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SignInErrorTextStaticControl
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("SignInErrorTextStaticControl") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowErrorDetailLinkLabel resource qid string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowErrorDetailLinkLabel
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("Control") where c.Attribute("Name").Value.Equals("ShowErrorDetailLinkLabel") select (string)c.Attribute("QueryId");
                    return new QID(obj.First());
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [nathd] 8/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    switch(ProductSku.Sku)
                    {
                        case ProductSkuLevel.Web:
                        default:
                            var obj = from c in LoginDialog.XmlDocument.Descendants("String") where c.Attribute("Name").Value.Equals("WindowTitleWeb") select (string)c.Attribute("Value");
                            return (string)obj.First();

                        case ProductSkuLevel.Mom:
                            //obj = from c in LoginDialog.XmlDocument.Descendants("String") where c.Attribute("Name").Value.Equals("WindowTitleDesktop") select (string)c.Attribute("Value");
                            //return (string)obj.First();
                            throw new System.NotImplementedException("WindowTitle not implemented for the Desktop Console LoginDialog");
                    }
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the WelcomeREDMONDnathd translated resource string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WelcomeREDMONDnathd
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("String") where c.Attribute("Name").Value.Equals("WelcomeREDMONDnathd") select (string)c.Attribute("Value");
                    return (string)obj.First();
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SignOut translated resource string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SignOut
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("String") where c.Attribute("Name").Value.Equals("SignOut") select (string)c.Attribute("Value");
                    return (string)obj.First();
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SignIn translated resource string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SignIn
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("String") where c.Attribute("Name").Value.Equals("SignIn") select (string)c.Attribute("Value");
                    return (string)obj.First();
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the WindowsAuth translated resource string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsAuth
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("String") where c.Attribute("Name").Value.Equals("WindowsAuth") select (string)c.Attribute("Value");
                    return (string)obj.First();
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NetworkAuth translated resource string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NetworkAuth
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("String") where c.Attribute("Name").Value.Equals("NetworkAuth") select (string)c.Attribute("Value");
                    return (string)obj.First();
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowErrorDetail translated resource string
            /// </summary>
            /// <history>
            ///   [nathd] 8/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowErrorDetail
            {
                get
                {
                    var obj = from c in LoginDialog.XmlDocument.Descendants("String") where c.Attribute("Name").Value.Equals("ShowErrorDetail") select (string)c.Attribute("Value");
                    return (string)obj.First();
                }
            }
            #endregion
        }
        #endregion
    }
}
