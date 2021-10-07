// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunAsAccountsProperties.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 4/24/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsProfile.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IRunAsAccountsPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunAsAccountsPropertiesControls, for RunAsAccountsProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunAsAccountsPropertiesControls
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
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlternateRunAsAccountsStaticControl
        /// </summary>
        StaticControl AlternateRunAsAccountsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DisplayNameComboBox
        /// </summary>
        ComboBox DisplayNameComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DefaultRunAsAccountStaticControl
        /// </summary>
        StaticControl DefaultRunAsAccountStaticControl
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
        /// Read-only property to access AssociatedClassListView
        /// </summary>
        ListView AssociatedClassListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl
        /// </summary>
        StaticControl ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl
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
    /// 	[ruhim] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RunAsAccountsProperties : Dialog, IRunAsAccountsPropertiesControls
    {
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
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to AlternateRunAsAccountsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlternateRunAsAccountsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DisplayNameComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDisplayNameComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DefaultRunAsAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefaultRunAsAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheRunAsAccountsForThisRunAsProfileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheRunAsAccountsForThisRunAsProfileStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlternateRunAsAccountsToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedAlternateRunAsAccountsToolbar;
        
        /// <summary>
        /// Cache to hold a reference to AssociatedClassListView of type ListView
        /// </summary>
        private ListView cachedAssociatedClassListView;
        
        /// <summary>
        /// Cache to hold a reference to ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl of type StaticControl
        /// </summary>
        private StaticControl cachedToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RunAsAccountsProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunAsAccountsProperties(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IRunAsAccountsProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunAsAccountsPropertiesControls Controls
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
        ///  Routine to set/get the text in control DisplayName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DisplayNameText
        {
            get
            {
                return this.Controls.DisplayNameComboBox.Text;
            }
            
            set
            {
                this.Controls.DisplayNameComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsAccountsPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, RunAsAccountsProperties.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsAccountsPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RunAsAccountsProperties.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunAsAccountsPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RunAsAccountsProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRunAsAccountsPropertiesControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, RunAsAccountsProperties.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlternateRunAsAccountsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountsPropertiesControls.AlternateRunAsAccountsStaticControl
        {
            get
            {
                if ((this.cachedAlternateRunAsAccountsStaticControl == null))
                {
                    this.cachedAlternateRunAsAccountsStaticControl = new StaticControl(this, RunAsAccountsProperties.ControlIDs.AlternateRunAsAccountsStaticControl);
                }
                return this.cachedAlternateRunAsAccountsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayNameComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRunAsAccountsPropertiesControls.DisplayNameComboBox
        {
            get
            {
                if ((this.cachedDisplayNameComboBox == null))
                {
                    this.cachedDisplayNameComboBox = new ComboBox(this, RunAsAccountsProperties.ControlIDs.DisplayNameComboBox);
                }
                return this.cachedDisplayNameComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultRunAsAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountsPropertiesControls.DefaultRunAsAccountStaticControl
        {
            get
            {
                if ((this.cachedDefaultRunAsAccountStaticControl == null))
                {
                    this.cachedDefaultRunAsAccountStaticControl = new StaticControl(this, RunAsAccountsProperties.ControlIDs.DefaultRunAsAccountStaticControl);
                }
                return this.cachedDefaultRunAsAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheRunAsAccountsForThisRunAsProfileStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountsPropertiesControls.SelectTheRunAsAccountsForThisRunAsProfileStaticControl
        {
            get
            {
                if ((this.cachedSelectTheRunAsAccountsForThisRunAsProfileStaticControl == null))
                {
                    this.cachedSelectTheRunAsAccountsForThisRunAsProfileStaticControl = new StaticControl(this, RunAsAccountsProperties.ControlIDs.SelectTheRunAsAccountsForThisRunAsProfileStaticControl);
                }
                return this.cachedSelectTheRunAsAccountsForThisRunAsProfileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlternateRunAsAccountsToolbar control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IRunAsAccountsPropertiesControls.AlternateRunAsAccountsToolbar
        {
            get
            {
                if ((this.cachedAlternateRunAsAccountsToolbar == null))
                {
                    this.cachedAlternateRunAsAccountsToolbar = new Toolbar(this/*, RunAsAccountsProperties.ControlIDs.AlternateRunAsAccountsToolbar*/);
                }
                return this.cachedAlternateRunAsAccountsToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AssociatedClassListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IRunAsAccountsPropertiesControls.AssociatedClassListView
        {
            get
            {
                if ((this.cachedAssociatedClassListView == null))
                {
                    this.cachedAssociatedClassListView = new ListView(this, RunAsAccountsProperties.ControlIDs.AssociatedClassListView);
                }
                return this.cachedAssociatedClassListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunAsAccountsPropertiesControls.ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl
        {
            get
            {
                if ((this.cachedToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl == null))
                {
                    this.cachedToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl = new StaticControl(this, RunAsAccountsProperties.ControlIDs.ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl);
                }
                return this.cachedToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
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
        /// 	[ruhim] 4/24/2006 Created
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
        /// 	[ruhim] 4/24/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 7;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;

                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);
                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
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
        /// 	[ruhim] 4/24/2006 Created
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
                ";Run As Profile Properties -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsProfilePropertiesCaption";
            
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
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlternateRunAsAccounts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlternateRunAsAccounts = ";&Alternate Run As Accounts:;ManagedString;Microsoft.MOM.UI.Components.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAs.ProfileAccounts;la" +
                "belAlertnateAccounts.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultRunAsAccount = ";&Default Run As Account:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Mom.Internal.UI.Administration.RunAs.ProfileAccounts;label" +
                "Account.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheRunAsAccountsForThisRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheRunAsAccountsForThisRunAsProfile = ";Select the Run As Accounts  for this Run As Profile:;ManagedString;Microsoft.MOM" +
                ".UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration" +
                ".RunAs.ProfileAccounts;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl = @";To have specific Operations Manager Agents present different credentials for this Run As Profile, add entries to the alternate Run As Accounts list.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAs.ProfileAccounts;labelDescription.Text";
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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlternateRunAsAccounts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlternateRunAsAccounts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefaultRunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultRunAsAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheRunAsAccountsForThisRunAsProfile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheRunAsAccountsForThisRunAsProfile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
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
            /// 	[ruhim] 4/24/2006 Created
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
            /// 	[ruhim] 4/24/2006 Created
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlternateRunAsAccounts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlternateRunAsAccounts
            {
                get
                {
                    if ((cachedAlternateRunAsAccounts == null))
                    {
                        cachedAlternateRunAsAccounts = CoreManager.MomConsole.GetIntlStr(ResourceAlternateRunAsAccounts);
                    }
                    return cachedAlternateRunAsAccounts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultRunAsAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultRunAsAccount
            {
                get
                {
                    if ((cachedDefaultRunAsAccount == null))
                    {
                        cachedDefaultRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceDefaultRunAsAccount);
                    }
                    return cachedDefaultRunAsAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheRunAsAccountsForThisRunAsProfile translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
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
            /// Exposes access to the ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl
            {
                get
                {
                    if ((cachedToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl == null))
                    {
                        cachedToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl = CoreManager.MomConsole.GetIntlStr(ResourceToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl);
                    }
                    return cachedToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl;
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
        /// 	[ruhim] 4/24/2006 Created
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for AlternateRunAsAccountsStaticControl
            /// </summary>
            public const string AlternateRunAsAccountsStaticControl = "labelAlertnateAccounts";
            
            /// <summary>
            /// Control ID for DisplayNameComboBox
            /// </summary>
            public const string DisplayNameComboBox = "comboBoxAccounts";
            
            /// <summary>
            /// Control ID for DefaultRunAsAccountStaticControl
            /// </summary>
            public const string DefaultRunAsAccountStaticControl = "labelAccount";
            
            /// <summary>
            /// Control ID for SelectTheRunAsAccountsForThisRunAsProfileStaticControl
            /// </summary>
            public const string SelectTheRunAsAccountsForThisRunAsProfileStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for AlternateRunAsAccountsToolbar
            /// </summary>
            public const string AlternateRunAsAccountsToolbar = "toolStripNewEditDelete";
            
            /// <summary>
            /// Control ID for AssociatedClassListView
            /// </summary>
            public const string AssociatedClassListView = "sortingListViewAccounts";
            
            /// <summary>
            /// Control ID for ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl
            /// </summary>
            public const string ToHaveSpecificOperationsManagerAgentsPresentDifferentCredentialsForThisRunAsProfileAddEntriesToTheAl = "labelDescription";
        }
        #endregion
    }
}
