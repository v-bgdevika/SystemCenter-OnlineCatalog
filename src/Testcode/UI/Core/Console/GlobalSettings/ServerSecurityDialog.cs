// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServerSecurityDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor]  24-Apr-06   Created
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 12-Jun-06    Fixed issue with dialog title prefix changing from MOM to SCE
//  [v-waltli] 10-Apr-09    Added new window title resource string for Mom because original is not available
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - ManualAgentOptions

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group ManualAgentOptions
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum ManualAgentOptions
    {
        /// <summary>
        /// AcceptNewManualAgentInstallations = 0
        /// </summary>
        AcceptNewManualAgentInstallations = 0,
        
        /// <summary>
        /// RejectNewManualAgentInstallations = 1
        /// </summary>
        RejectNewManualAgentInstallations = 1,
    }
    #endregion
    
    #region Interface Definition - IServerSecurityDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServerSecurityDialogControls, for ServerSecurityDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServerSecurityDialogControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AcceptNewManualAgentInstallationsRadioButton
        /// </summary>
        RadioButton AcceptNewManualAgentInstallationsRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RejectNewManualAgentInstallationsRadioButton
        /// </summary>
        RadioButton RejectNewManualAgentInstallationsRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManualAgentInstallsStaticControl
        /// </summary>
        StaticControl ManualAgentInstallsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutoApproveNewManuallyInstalledAgentsCheckBox
        /// </summary>
        CheckBox AutoApproveNewManuallyInstalledAgentsCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl
        /// </summary>
        StaticControl ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Global Settings->Server->Security dialog
    /// </summary>
    /// <history>
    /// [KellyMor]  24-Apr-06   Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServerSecurityDialog : Window, IServerSecurityDialogControls
    {
        #region Protected Internal Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        protected internal static Window activeWindow;
        #endregion
        
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to AcceptNewManualAgentInstallationsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAcceptNewManualAgentInstallationsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to RejectNewManualAgentInstallationsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedRejectNewManualAgentInstallationsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ManualAgentInstallsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManualAgentInstallsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutoApproveNewManuallyInstalledAgentsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAutoApproveNewManuallyInstalledAgentsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of ServerSecurityDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServerSecurityDialog(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group ManualAgentOptions
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ManualAgentOptions ManualAgentOptions
        {
            get
            {
                if ((this.Controls.AcceptNewManualAgentInstallationsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ManualAgentOptions.AcceptNewManualAgentInstallations;
                }
                
                if ((this.Controls.RejectNewManualAgentInstallationsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ManualAgentOptions.RejectNewManualAgentInstallations;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == ManualAgentOptions.AcceptNewManualAgentInstallations))
                {
                    this.Controls.AcceptNewManualAgentInstallationsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == ManualAgentOptions.RejectNewManualAgentInstallations))
                    {
                        this.Controls.RejectNewManualAgentInstallationsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IServerSecurityDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServerSecurityDialogControls Controls
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
        ///  Property to handle checkbox AutoApproveNewManuallyInstalledAgents
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool AutoApproveNewManuallyInstalledAgents
        {
            get
            {
                return this.Controls.AutoApproveNewManuallyInstalledAgentsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AutoApproveNewManuallyInstalledAgentsCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServerSecurityDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, ServerSecurityDialog.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServerSecurityDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServerSecurityDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServerSecurityDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ServerSecurityDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IServerSecurityDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, ServerSecurityDialog.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AcceptNewManualAgentInstallationsRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IServerSecurityDialogControls.AcceptNewManualAgentInstallationsRadioButton
        {
            get
            {
                if ((this.cachedAcceptNewManualAgentInstallationsRadioButton == null))
                {
                    this.cachedAcceptNewManualAgentInstallationsRadioButton = new RadioButton(this, ServerSecurityDialog.ControlIDs.AcceptNewManualAgentInstallationsRadioButton);
                }
                return this.cachedAcceptNewManualAgentInstallationsRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RejectNewManualAgentInstallationsRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IServerSecurityDialogControls.RejectNewManualAgentInstallationsRadioButton
        {
            get
            {
                if ((this.cachedRejectNewManualAgentInstallationsRadioButton == null))
                {
                    this.cachedRejectNewManualAgentInstallationsRadioButton = new RadioButton(this, ServerSecurityDialog.ControlIDs.RejectNewManualAgentInstallationsRadioButton);
                }
                return this.cachedRejectNewManualAgentInstallationsRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManualAgentInstallsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServerSecurityDialogControls.ManualAgentInstallsStaticControl
        {
            get
            {
                if ((this.cachedManualAgentInstallsStaticControl == null))
                {
                    this.cachedManualAgentInstallsStaticControl = new StaticControl(this, ServerSecurityDialog.ControlIDs.ManualAgentInstallsStaticControl);
                }
                return this.cachedManualAgentInstallsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoApproveNewManuallyInstalledAgentsCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServerSecurityDialogControls.AutoApproveNewManuallyInstalledAgentsCheckBox
        {
            get
            {
                if ((this.cachedAutoApproveNewManuallyInstalledAgentsCheckBox == null))
                {
                    this.cachedAutoApproveNewManuallyInstalledAgentsCheckBox = new CheckBox(this, ServerSecurityDialog.ControlIDs.AutoApproveNewManuallyInstalledAgentsCheckBox);
                }
                return this.cachedAutoApproveNewManuallyInstalledAgentsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServerSecurityDialogControls.ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl
        {
            get
            {
                if ((this.cachedToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl == null))
                {
                    this.cachedToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl = new StaticControl(this, ServerSecurityDialog.ControlIDs.ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl);
                }
                return this.cachedToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
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
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AutoApproveNewManuallyInstalledAgents
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAutoApproveNewManuallyInstalledAgents()
        {
            this.Controls.AutoApproveNewManuallyInstalledAgentsCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// [KellyMor]  24-Apr-06   Created
        /// [v-waltli]  4/10/2009   Added new window title since original is not available
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                try
                {
                    // Try to locate an existing instance of a window
                    tempWindow = new Window(
                        Strings.WindowTitle,
                        StringMatchSyntax.ExactMatch);
                }
                catch (Exceptions.WindowNotFoundException)
                {
                    // Try to find with new window title
                    tempWindow = new Window(
                        Strings.NewWindowTitle,
                        StringMatchSyntax.ExactMatch);
                }
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
                        try
                        {
                            // look for the window again using wildcards
                            tempWindow =
                                new Window(
                                    Strings.WindowTitle + "*",
                                    StringMatchSyntax.WildCard);
                        }
                        catch (Exceptions.WindowNotFoundException)
                        {
                            // Try to find with new window title
                            tempWindow =
                                new Window(
                                    Strings.NewWindowTitle + "*",
                                    StringMatchSyntax.WildCard);
                        }

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Common.Utilities.LogMessage("Failed to find the Server Security settings window!");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/24/2006 Created
        /// 	[v-waltli] 4/10/2009 Added new window title resource string for Mom since original resource string is not available
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowMomTitlePrefix = ";Global Management Group Settings -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GroupSettingsTitle";

            /// <summary>
            /// Contains new resource string for the window or dialog title prefix
            /// </summary>
            private const string ResourceWindowMomTitleNewPrefix = ";Global Management Server Settings -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ServerSettingsTitle";

            /// <summary>
            /// Contains new resource string for the window or dialog title sufix
            /// </summary>
            private const string ResourceWindowMomTitleNewSuffix = ";Security;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SettingsResources;ServerSecurity";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix on SCE
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowSceTitlePrefix = ";Global Management Settings -;ManagedString;Microsoft.EnterpriseManagement.SCE.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.AdministrationSpace.AdminResources;GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowTitleSuffix = ";Security;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ServerSettings.Security;>>$this.Name";
             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;DC01.bQ;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;buttonOK.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AcceptNewManualAgentInstallations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAcceptNewManualAgentInstallations = ";A&ccept new manual agent installations;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ServerSetting" +
                "s.Security;radioButtonAccept.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RejectNewManualAgentInstallations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRejectNewManualAgentInstallations = ";&Reject new manual agent installations;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ServerSetting" +
                "s.Security;radioButtonReject.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManualAgentInstalls
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManualAgentInstalls = ";Manual Agent Installs:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Administration.ServerSettings.Security;label" +
                "Title.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoApproveNewManuallyInstalledAgents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoApproveNewManuallyInstalledAgents = ";A&uto-approve new manually installed agents;ManagedString;Microsoft.MOM.UI.Compo" +
                "nents.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ServerSe" +
                "ttings.Security;checkBoxAutoApproveNew.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected = ";To increase security, specify that manual agent installations are rejected.;Mana" +
                "gedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Int" +
                "ernal.UI.Administration.ServerSettings.Security;labelDescription.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitlePrefix;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the new translated resource the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitleNewPrefix;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitleSuffix;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the new translated resource the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitleNewSuffix;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AcceptNewManualAgentInstallations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAcceptNewManualAgentInstallations;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RejectNewManualAgentInstallations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRejectNewManualAgentInstallations;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManualAgentInstalls
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManualAgentInstalls;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutoApproveNewManuallyInstalledAgents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoApproveNewManuallyInstalledAgents;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitlePrefix == null) || (cachedWindowTitleSuffix == null))
                    {
                        //if (ProductSkuLevel.Mom == ProductSku.Sku)
                        cachedWindowTitlePrefix = CoreManager.MomConsole.GetIntlStr(ResourceWindowMomTitlePrefix);
                       
                        cachedWindowTitleSuffix = CoreManager.MomConsole.GetIntlStr(ResourceWindowMomTitleNewSuffix);
                    }
                    return (cachedWindowTitlePrefix + " " + cachedWindowTitleSuffix);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the new WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 4/10/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NewWindowTitle
            {
                get
                {
                    if ((cachedWindowTitleNewPrefix == null) || (cachedWindowTitleNewSuffix == null))
                    {
                        cachedWindowTitleNewPrefix = CoreManager.MomConsole.GetIntlStr(ResourceWindowMomTitleNewPrefix);
                        cachedWindowTitleNewSuffix = CoreManager.MomConsole.GetIntlStr(ResourceWindowMomTitleNewSuffix);
                    }
                    return (cachedWindowTitleNewPrefix + " " + cachedWindowTitleNewSuffix);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    return cachedTab0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AcceptNewManualAgentInstallations translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AcceptNewManualAgentInstallations
            {
                get
                {
                    if ((cachedAcceptNewManualAgentInstallations == null))
                    {
                        cachedAcceptNewManualAgentInstallations = CoreManager.MomConsole.GetIntlStr(ResourceAcceptNewManualAgentInstallations);
                    }
                    return cachedAcceptNewManualAgentInstallations;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RejectNewManualAgentInstallations translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RejectNewManualAgentInstallations
            {
                get
                {
                    if ((cachedRejectNewManualAgentInstallations == null))
                    {
                        cachedRejectNewManualAgentInstallations = CoreManager.MomConsole.GetIntlStr(ResourceRejectNewManualAgentInstallations);
                    }
                    return cachedRejectNewManualAgentInstallations;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManualAgentInstalls translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManualAgentInstalls
            {
                get
                {
                    if ((cachedManualAgentInstalls == null))
                    {
                        cachedManualAgentInstalls = CoreManager.MomConsole.GetIntlStr(ResourceManualAgentInstalls);
                    }
                    return cachedManualAgentInstalls;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutoApproveNewManuallyInstalledAgents translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoApproveNewManuallyInstalledAgents
            {
                get
                {
                    if ((cachedAutoApproveNewManuallyInstalledAgents == null))
                    {
                        cachedAutoApproveNewManuallyInstalledAgents = CoreManager.MomConsole.GetIntlStr(ResourceAutoApproveNewManuallyInstalledAgents);
                    }
                    return cachedAutoApproveNewManuallyInstalledAgents;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected
            {
                get
                {
                    if ((cachedToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected == null))
                    {
                        cachedToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected = CoreManager.MomConsole.GetIntlStr(ResourceToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected);
                    }
                    return cachedToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejected;
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
        /// 	[KellyMor] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for AcceptNewManualAgentInstallationsRadioButton
            /// </summary>
            public const string AcceptNewManualAgentInstallationsRadioButton = "radioButtonAccept";
            
            /// <summary>
            /// Control ID for RejectNewManualAgentInstallationsRadioButton
            /// </summary>
            public const string RejectNewManualAgentInstallationsRadioButton = "radioButtonReject";
            
            /// <summary>
            /// Control ID for ManualAgentInstallsStaticControl
            /// </summary>
            public const string ManualAgentInstallsStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for AutoApproveNewManuallyInstalledAgentsCheckBox
            /// </summary>
            public const string AutoApproveNewManuallyInstalledAgentsCheckBox = "checkBoxAutoApproveNew";
            
            /// <summary>
            /// Control ID for ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl
            /// </summary>
            public const string ToIncreaseSecuritySpecifyThatManualAgentInstallationsAreRejectedStaticControl = "labelDescription";
        }
        #endregion
    }
}
