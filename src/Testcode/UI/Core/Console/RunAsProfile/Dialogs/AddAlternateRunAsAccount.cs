// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddAlternateRunAsAccount.cs">
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
    
    #region Interface Definition - IAddAlternateRunAsAccountControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddAlternateRunAsAccountControls, for AddAlternateRunAsAccount.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddAlternateRunAsAccountControls
    {
        /// <summary>
        /// Read-only property to access SearchTextBox
        /// </summary>
        TextBox SearchTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MatchingComputersListView
        /// </summary>
        ListView MatchingComputersListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl
        /// </summary>
        StaticControl EnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MatchingComputersStaticControl
        /// </summary>
        StaticControl MatchingComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectRunAsAccountComboBox
        /// </summary>
        ComboBox SelectRunAsAccountComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunAsAccountStaticControl
        /// </summary>
        StaticControl RunAsAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
        /// </summary>
        StaticControl SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
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
    public class AddAlternateRunAsAccount : Dialog, IAddAlternateRunAsAccountControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SearchTextBox of type TextBox
        /// </summary>
        private TextBox cachedSearchTextBox;
        
        /// <summary>
        /// Cache to hold a reference to MatchingComputersListView of type ListView
        /// </summary>
        private ListView cachedMatchingComputersListView;
        
        /// <summary>
        /// Cache to hold a reference to EnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MatchingComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMatchingComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectRunAsAccountComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectRunAsAccountComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RunAsAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunAsAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddAlternateRunAsAccount of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddAlternateRunAsAccount(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IAddAlternateRunAsAccount Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddAlternateRunAsAccountControls Controls
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
        ///  Routine to set/get the text in control SearchTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchTextBoxText
        {
            get
            {
                return this.Controls.SearchTextBox.Text;
            }
            
            set
            {
                this.Controls.SearchTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SelectRunAsAccount
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectRunAsAccountText
        {
            get
            {
                return this.Controls.SelectRunAsAccountComboBox.Text;
            }
            
            set
            {
                this.Controls.SelectRunAsAccountComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddAlternateRunAsAccountControls.SearchTextBox
        {
            get
            {
                if ((this.cachedSearchTextBox == null))
                {
                    this.cachedSearchTextBox = new TextBox(this, AddAlternateRunAsAccount.ControlIDs.SearchTextBox);
                }
                return this.cachedSearchTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MatchingComputersListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAddAlternateRunAsAccountControls.MatchingComputersListView
        {
            get
            {
                if ((this.cachedMatchingComputersListView == null))
                {
                    this.cachedMatchingComputersListView = new ListView(this, AddAlternateRunAsAccount.ControlIDs.MatchingComputersListView);
                }
                return this.cachedMatchingComputersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddAlternateRunAsAccountControls.EnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl
        {
            get
            {
                if ((this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl == null))
                {
                    this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl = new StaticControl(this, AddAlternateRunAsAccount.ControlIDs.EnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl);
                }
                return this.cachedEnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MatchingComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddAlternateRunAsAccountControls.MatchingComputersStaticControl
        {
            get
            {
                if ((this.cachedMatchingComputersStaticControl == null))
                {
                    this.cachedMatchingComputersStaticControl = new StaticControl(this, AddAlternateRunAsAccount.ControlIDs.MatchingComputersStaticControl);
                }
                return this.cachedMatchingComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectRunAsAccountComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddAlternateRunAsAccountControls.SelectRunAsAccountComboBox
        {
            get
            {
                if ((this.cachedSelectRunAsAccountComboBox == null))
                {
                    this.cachedSelectRunAsAccountComboBox = new ComboBox(this, AddAlternateRunAsAccount.ControlIDs.SelectRunAsAccountComboBox);
                }
                return this.cachedSelectRunAsAccountComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddAlternateRunAsAccountControls.RunAsAccountStaticControl
        {
            get
            {
                if ((this.cachedRunAsAccountStaticControl == null))
                {
                    this.cachedRunAsAccountStaticControl = new StaticControl(this, AddAlternateRunAsAccount.ControlIDs.RunAsAccountStaticControl);
                }
                return this.cachedRunAsAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddAlternateRunAsAccountControls.SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
        {
            get
            {
                if ((this.cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire == null))
                {
                    this.cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire = new StaticControl(this, AddAlternateRunAsAccount.ControlIDs.SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire);
                }
                return this.cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire;
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
        Button IAddAlternateRunAsAccountControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddAlternateRunAsAccount.ControlIDs.CancelButton);
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
        Button IAddAlternateRunAsAccountControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddAlternateRunAsAccount.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        #endregion
        
        #region Click Methods

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
                ";Add Alternate Run As Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.AlternateAccount;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterYourSearchTextBelowThisSearchesBothNameAndDomain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterYourSearchTextBelowThisSearchesBothNameAndDomain = ";Enter your search text below. This searches both name and domain.;ManagedString;" +
                "Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.A" +
                "dministration.RunAs.AlternateAccount;labelSearch.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MatchingComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMatchingComputers = ";&Matching Computers;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.Internal.UI.Administration.RunAs.AlternateAccount;labelComp" +
                "uters.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAsAccount = ";&Run As Account:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Administration.RunAs.AlternateAccount;labelAccount" +
                "s.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire = @";Select the Run As Account to be used in context and then select the target computer where alternate accounts are required.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAs.AlternateAccount;labelTitle1.Text";
            
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
            /// Caches the translated resource string for:  EnterYourSearchTextBelowThisSearchesBothNameAndDomain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterYourSearchTextBelowThisSearchesBothNameAndDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MatchingComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMatchingComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire;
            
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
            /// Exposes access to the EnterYourSearchTextBelowThisSearchesBothNameAndDomain translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterYourSearchTextBelowThisSearchesBothNameAndDomain
            {
                get
                {
                    if ((cachedEnterYourSearchTextBelowThisSearchesBothNameAndDomain == null))
                    {
                        cachedEnterYourSearchTextBelowThisSearchesBothNameAndDomain = CoreManager.MomConsole.GetIntlStr(ResourceEnterYourSearchTextBelowThisSearchesBothNameAndDomain);
                    }
                    return cachedEnterYourSearchTextBelowThisSearchesBothNameAndDomain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MatchingComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MatchingComputers
            {
                get
                {
                    if ((cachedMatchingComputers == null))
                    {
                        cachedMatchingComputers = CoreManager.MomConsole.GetIntlStr(ResourceMatchingComputers);
                    }
                    return cachedMatchingComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunAsAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsAccount
            {
                get
                {
                    if ((cachedRunAsAccount == null))
                    {
                        cachedRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceRunAsAccount);
                    }
                    return cachedRunAsAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
            {
                get
                {
                    if ((cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire == null))
                    {
                        cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire);
                    }
                    return cachedSelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire;
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
            /// Control ID for SearchTextBox
            /// </summary>
            public const string SearchTextBox = "textBoxSearch";
            
            /// <summary>
            /// Control ID for MatchingComputersListView
            /// </summary>
            public const string MatchingComputersListView = "listViewComputers";
            
            /// <summary>
            /// Control ID for EnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl
            /// </summary>
            public const string EnterYourSearchTextBelowThisSearchesBothNameAndDomainStaticControl = "labelSearch";
            
            /// <summary>
            /// Control ID for MatchingComputersStaticControl
            /// </summary>
            public const string MatchingComputersStaticControl = "labelComputers";
            
            /// <summary>
            /// Control ID for SelectRunAsAccountComboBox
            /// </summary>
            public const string SelectRunAsAccountComboBox = "comboBoxAccounts";
            
            /// <summary>
            /// Control ID for RunAsAccountStaticControl
            /// </summary>
            public const string RunAsAccountStaticControl = "labelAccounts";
            
            /// <summary>
            /// Control ID for SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire
            /// </summary>
            public const string SelectTheRunAsAccountToBeUsedInContextAndThenSelectTheTargetComputerWhereAlternateAccountsAreRequire = "labelTitle1";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
        }
        #endregion
    }
}
