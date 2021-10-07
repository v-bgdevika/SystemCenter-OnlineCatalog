// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunAsAccount.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Run As Account Base Class.
// </summary>
// <history>
// 	[ruhim]     19AUG06     Created
//  [sharatja]  22AUG08     Modified test code to support R2 changes
//  [nathd]     29JAN09     Updated code for the addition of the RunAs Account Wizard. 
//                          R2 Improvement #131241.
//  [v-linch]   18JUN09     Added SNMPv3 support and Verify method
//  [v-linch]   26JUN09     Enabled all types in Verify and Update methods
// </history>
// ---------------------------------------------------------------------------
#region Using directives
using System;
using System.ComponentModel;
using System.Globalization;
using System.Collections.Generic;
using Maui.Core;
using Maui.Core.Utilities;
using Maui.Core.WinControls;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.RunAsAccount.Dialogs;
using Infra.Frmwrk;
#endregion


namespace Mom.Test.UI.Core.Console.RunAsAccount
{
    /// <summary>
    /// Class to add general methods for Run As Account 
    /// </summary>
    public class RunAsAccount
    {
        #region Constants

        /// <summary>
        /// Toolbar position of Remove button 
        /// </summary>
        public const int INDEX_BUTTON_REMOVE = 0;

        /// <summary>
        /// Toolbar position of Add button 
        /// </summary>
        public const int INDEX_BUTTON_ADD = 1;

        /// <summary>
        /// What Password dispalys as in Key fields
        /// </summary>
        public const char PASSWORD_CHAR = '*';

        /// <summary>
        /// Path to the Run As Account Node for SelectNode method
        /// </summary>
        public string RunAsAccountPath = NavigationPane.Strings.AdminTreeViewAdministrationRoot
            + Constants.PathDelimiter
            + NavigationPane.Strings.AdminTreeViewRunAsConfiguration
            + Constants.PathDelimiter
            + NavigationPane.Strings.AdminTreeViewRunAsAccounts;

        #endregion

        #region Private Members

        /// <summary>
        /// cachedGeneraProperties
        /// </summary>
        private GeneralProperties cachedGeneraProperties;

        /// <summary>
        /// cachedSNMPv3Properties
        /// </summary>
        private SNMPv3AccountProperties cachedSNMPv3Properties;

        /// <summary>
        /// cachedCommunityProperties
        /// </summary>
        private CommunityAccountProperties cachedCommunityProperties;

        /// <summary>
        /// cachedBinaryProperties
        /// </summary>
        private BinaryAccountProperties cachedBinaryProperties;

        /// <summary>
        /// cachedAccountProperties
        /// </summary>
        private AccountProperties cachedAccountProperties;

        /// <summary>
        /// cachedDistributionProperties
        /// </summary>
        private DistributionProperties cachedDistributionProperties;

        /// <summary>
        /// cachedintroductionDialog
        /// </summary>
        private IntroductionDialog cachedintroductionDialog;

        /// <summary>
        /// cachedgeneralDialog
        /// </summary>
        private GeneralDialog cachedgeneralDialog;

        /// <summary>
        /// cachedwindowsAccountDialog
        /// </summary>
        private WindowsAccountDialog cachedwindowsAccountDialog;

        /// <summary>
        /// cachedbinaryAccountDialog
        /// </summary>
        private BinaryAccountDialog cachedbinaryAccountDialog;

        /// <summary>
        /// cachedcommunityAccountDialog
        /// </summary>
        private CommunityAccountDialog cachedcommunityAccountDialog;

        /// <summary>
        /// cachedsnmpv3AccountDialog
        /// </summary>
        private SNMPv3AccountDialog cachedsnmpv3AccountDialog;

        /// <summary>
        /// cachedCompletionDialog
        /// </summary>
        private CompletionDialog cachedCompletionDialog;

        /// <summary>
        /// cachedAccountUsageDialog
        /// </summary>
        private AccountUsageDialog cachedAccountUsageDialog;

        /// <summary>
        /// cachedComputerPickerDialog
        /// </summary>
        private ComputerPickerDialog cachedComputerPickerDialog;

        /// <summary>
        /// cachedRunAsAccountWizardDistributionPage
        /// </summary>
        private RunAsAccountWizardDistributionPage cachedRunAsAccountWizardDistributionPage;

        /// <summary>
        /// Accounts properties tabs
        /// </summary>
        private TabControlTab cachedGeneralTabControl;
        private TabControlTab cachedAccoutTabControl;
        private TabControlTab cachedDistributionTabControl;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;

        #endregion

        #region Enumerators section

        /// <summary>
        /// Run As Account Type
        /// </summary>
        public enum AccountType
        {
            /// <summary>
            /// Windows
            /// </summary>
            Windows,

            /// <summary>
            /// Basic Authentication
            /// </summary>
            Basic,

            /// <summary>
            /// Simple Authentication
            /// </summary>
            Simple,

            /// <summary>
            /// Digest Authentication
            /// </summary>
            Digest,

            /// <summary>
            /// Binary Authentication
            /// </summary>
            Binary,

            /// <summary>
            /// Community String
            /// </summary>
            Community,

            /// <summary>
            /// Action Account
            /// </summary>
            ActionAccount,

            /// <summary>
            /// SNMPv3 Type
            /// </summary>
            SNMPv3
        }

        /// <summary>
        /// Distribution Security Option
        /// </summary>
        public enum DistributionSecurityOption
        {
            /// <summary>
            /// Default distribution option for RunAs Account
            /// </summary>
            Default,

            /// <summary>
            /// Less-secure distribution option for RunAs Account
            /// </summary>
            LessSecure,

            /// <summary>
            /// More-secure distribution option for RunAs Account
            /// </summary>
            MoreSecure,

            /// <summary>
            /// Distribution option for RunAs Account not specified
            /// </summary>
            NotSpecified,
        }

        /// <summary>
        /// SNMPv3 AuthenticationProtocol Type
        /// </summary>
        public enum SNMPv3APType
        {
            None,

            MD5,

            SHA,
        }

        /// <summary>
        /// SNMPv3 PrivacyProtocol Type
        /// </summary>
        public enum SNMPv3PPType
        {
            None,

            AES,

            DES,
        }

        #endregion	// Enumerators section

        #region Constructor
        /// <summary>
        /// Run As Account Constructor.
        /// </summary>
        public RunAsAccount()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Introduction Dialog        
        /// </summary>
        public IntroductionDialog introductionDialog
        {
            get
            {
                if (this.cachedintroductionDialog == null)
                {
                    this.cachedintroductionDialog = new IntroductionDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Introduction Dialog was successful");
                }
                return this.cachedintroductionDialog;
            }
        }

        /// <summary>
        /// Completion Dialog        
        /// </summary>
        public CompletionDialog completionDialog
        {
            get
            {
                if (this.cachedCompletionDialog == null)
                {
                    this.cachedCompletionDialog = new CompletionDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Completion Dialog was successful");
                }
                return this.cachedCompletionDialog;
            }
        }

        /// <summary>
        /// Account Usage Dialog        
        /// </summary>
        public AccountUsageDialog accountUsageDialog
        {
            get
            {
                if (this.cachedAccountUsageDialog == null)
                {
                    this.cachedAccountUsageDialog = new AccountUsageDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Account Usage Dialog was successful");
                }
                return this.cachedAccountUsageDialog;
            }
        }

        /// <summary>
        /// Computer Picker Dialog
        /// </summary>
        public ComputerPickerDialog computerPickerDialog
        {
            get
            {
                if (this.cachedComputerPickerDialog == null)
                {
                    this.cachedComputerPickerDialog = new ComputerPickerDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Computer Picker Dialog was successful");
                }
                return this.cachedComputerPickerDialog;
            }
        }

        /// <summary>
        /// General Dialog        
        /// </summary>
        public GeneralDialog generalDialog
        {
            get
            {
                if (this.cachedgeneralDialog == null)
                {
                    this.cachedgeneralDialog = new GeneralDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the General Dialog was successful");
                }
                return this.cachedgeneralDialog;
            }
        }

        /// <summary>
        /// Windows Account Dialog
        /// </summary>
        public WindowsAccountDialog windowsAccountDialog
        {
            get
            {
                if (this.cachedwindowsAccountDialog == null)
                {
                    this.cachedwindowsAccountDialog = new WindowsAccountDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Windows Account Dialog was successful");
                }
                return this.cachedwindowsAccountDialog;
            }
        }

        /// <summary>
        /// Binary Account Dialog        
        /// </summary>
        public BinaryAccountDialog binaryAccountDialog
        {
            get
            {
                if (this.cachedbinaryAccountDialog == null)
                {
                    this.cachedbinaryAccountDialog = new BinaryAccountDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Binary Account Dialog was successful");
                }
                return this.cachedbinaryAccountDialog;
            }
        }

        /// <summary>
        /// Community Account Dialog
        /// </summary>
        public CommunityAccountDialog communityAccountDialog
        {
            get
            {
                if (this.cachedcommunityAccountDialog == null)
                {
                    this.cachedcommunityAccountDialog = new CommunityAccountDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Community Account Dialog was successful");
                }
                return this.cachedcommunityAccountDialog;
            }
        }

        /// <summary>
        /// SNMPv3 Account Dialog in Wizard
        /// </summary>
        public SNMPv3AccountDialog snmpv3AccountDialog
        {
            get
            {
                if (this.cachedsnmpv3AccountDialog == null)
                {
                    this.cachedsnmpv3AccountDialog = new SNMPv3AccountDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the SNMPv3 Account Dialog was successful");
                }
                return this.cachedsnmpv3AccountDialog;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GeneralProperties generalProperties
        {
            get
            {
                if (this.cachedGeneraProperties == null)
                {
                    this.cachedGeneraProperties = new GeneralProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the General property dialog was successful");
                }
                return this.cachedGeneraProperties;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AccountProperties accountProperties
        {
            get
            {
                if (this.cachedAccountProperties == null)
                {
                    this.cachedAccountProperties = new AccountProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Account property dialog was successful");
                }
                return this.cachedAccountProperties;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DistributionProperties distributionProperties
        {
            get
            {
                if (this.cachedDistributionProperties == null)
                {
                    this.cachedDistributionProperties = new DistributionProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Distribution property dialog was successful");
                }
                return this.cachedDistributionProperties;
            }
        }

        /// <summary>
        /// RunAs Account Wizard - Distribution Page
        /// </summary>
        public RunAsAccountWizardDistributionPage runAsAccountWizardDistributionPage
        {
            get
            {
                if (this.cachedRunAsAccountWizardDistributionPage == null)
                {
                    this.cachedRunAsAccountWizardDistributionPage = new RunAsAccountWizardDistributionPage(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the RunAs Account Wizard - Distribution Page was successful");
                }
                return this.cachedRunAsAccountWizardDistributionPage;
            }
        }

        /// <summary>
        /// SNMPv3 properties dialog
        /// </summary>
        public SNMPv3AccountProperties snmpv3Properties
        {
            get
            {
                if (this.cachedSNMPv3Properties == null)
                {
                    this.cachedSNMPv3Properties = new SNMPv3AccountProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the SNMPv3 property dialog was successful");
                }
                return this.cachedSNMPv3Properties;
            }
        }

        /// <summary>
        /// Community properties dialog
        /// </summary>
        public CommunityAccountProperties commumityProperties
        {
            get
            {
                if (this.cachedCommunityProperties == null)
                {
                    this.cachedCommunityProperties = new CommunityAccountProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Community property dialog was successful");
                }
                return this.cachedCommunityProperties;
            }
        }

        /// <summary>
        /// Binary properties dialog
        /// </summary>
        public BinaryAccountProperties binaryAccountProperties
        {
            get
            {
                if (this.cachedBinaryProperties == null)
                {
                    this.cachedBinaryProperties = new BinaryAccountProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Binary property dialog was successful");
                }
                return this.cachedBinaryProperties;
            }
        }

        /// <summary>
        /// General Tab
        /// </summary>
        public TabControlTab generalTab
        {
            get
            {
                if (this.cachedGeneralTabControl == null)
                {
                    this.cachedGeneralTabControl = new TabControlTab(this.generalProperties.Controls.Tab0TabControl, RunAsAccount.Strings.GeneralTab);
                    Utilities.LogMessage("Setting Focus on the General Tab was successful");
                }
                return this.cachedGeneralTabControl;
            }
        }

        /// <summary>
        /// Account Tab
        /// </summary>
        public TabControlTab accountTab
        {
            get
            {
                if (this.cachedAccoutTabControl == null)
                {
                    this.cachedAccoutTabControl = new TabControlTab(this.generalProperties.Controls.Tab0TabControl, RunAsAccount.Strings.AccountTab);
                    Utilities.LogMessage("Setting Focus on the Account Tab was successful");
                }
                return this.cachedAccoutTabControl;
            }
        }

        /// <summary>
        /// Distribution Tab
        /// </summary>
        public TabControlTab distributionTab
        {
            get
            {
                if (this.cachedDistributionTabControl == null)
                {
                    this.cachedDistributionTabControl = new TabControlTab(this.generalProperties.Controls.Tab0TabControl, RunAsAccount.Strings.DistributionTab);
                    Utilities.LogMessage("Setting Focus on the Distribution Tab was successful");
                }
                return this.cachedDistributionTabControl;
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Create new Run as Account of type Windows
        /// </summary>        
        /// <param name="displayName">Display Name of Run as Account</param>
        /// <param name="userName">User Name of Run as Account</param>
        /// <param name="password">Password for Run as Account</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [ruhim] 19APR06 - Created        
        /// </history>
        public void Create(string displayName, string userName, string password)
        {
            RunAsAccountParameters parameters = new RunAsAccountParameters();
            parameters.DisplayName = displayName;
            parameters.UserName = userName;
            parameters.Password = password;
            parameters.Type = AccountType.Windows;
            this.Create(parameters);
        }

        /// <summary>
        /// Create new User Role
        /// </summary>
        /// <param name="parameters">RunAsAccountParameters</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [ruhim] 09FEB06 - Created
        ///     [nathd] 29JAN09 - Updated code for the addition of the RunAs Account Wizard. 
        ///                       R2 Improvement #131241. Added the Distribution Security Page.
        /// </history>
        public void Create(RunAsAccountParameters parameters)
        {
            # region Navigate To Run as Account Node and Launch the Create Wizard
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            TreeNode runAsAccountNode = navPane.SelectNode(RunAsAccountPath, NavigationPane.NavigationTreeView.Administration);
            Utilities.LogMessage("RunAsAccount.Create :: Selected Node '" + NavigationPane.Strings.AdminTreeViewRunAsAccounts);
            consoleApp.Waiters.WaitForReady();

            runAsAccountNode.ContextMenu.ExecuteMenuItem(NavigationPane.Strings.ContextMenuCreateRunAsAccount);
            Utilities.LogMessage("RunAsAccount.Create :: Successfully Launched the Create Run As Account Wizard");
            #endregion

            SettingRunasAccountWizard(parameters);
        }

        public void SettingRunasAccountWizard(RunAsAccountParameters parameters)
        {
            #region Navigate through the RunAs Account Wizard

            #region RunAs Account Wizard - Introduction Page
            UIUtilities.SetControlValue(this.introductionDialog.Controls.NextButton); //this.introductionDialog.ClickNext();
            #endregion RunAs Account Wizard - Introduction Page

            #region RunAs Account Wizard - General Properties Page

            //Select the Account Type
            switch (parameters.Type)
            {
                case AccountType.Windows:
                    UIUtilities.SetControlValue(this.generalDialog.Controls.RunAsAccountTypeComboBox, Strings.WindowsAccountType); //this.generalDialog.Controls.RunAsAccountTypeComboBox.SelectByText(Strings.WindowsAccountType);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + Strings.WindowsAccountType);
                    break;

                case AccountType.Simple:
                    UIUtilities.SetControlValue(this.generalDialog.Controls.RunAsAccountTypeComboBox, Strings.SimpleAccountType); //this.generalDialog.Controls.RunAsAccountTypeComboBox.SelectByText(Strings.SimpleAccountType);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + Strings.SimpleAccountType);
                    break;

                case AccountType.Digest:
                    UIUtilities.SetControlValue(this.generalDialog.Controls.RunAsAccountTypeComboBox, Strings.DigestAccountType); //this.generalDialog.Controls.RunAsAccountTypeComboBox.SelectByText(Strings.DigestAccountType);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + Strings.DigestAccountType);
                    break;

                case AccountType.Basic:
                    UIUtilities.SetControlValue(this.generalDialog.Controls.RunAsAccountTypeComboBox, Strings.BasicAccountType); //this.generalDialog.Controls.RunAsAccountTypeComboBox.SelectByText(Strings.BasicAccountType);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + Strings.BasicAccountType);
                    break;

                case AccountType.Binary:
                    UIUtilities.SetControlValue(this.generalDialog.Controls.RunAsAccountTypeComboBox, Strings.BinaryAccountType); //this.generalDialog.Controls.RunAsAccountTypeComboBox.SelectByText(Strings.BinaryAccountType);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + Strings.BinaryAccountType);
                    break;

                case AccountType.Community:
                    UIUtilities.SetControlValue(this.generalDialog.Controls.RunAsAccountTypeComboBox, Strings.CommunityAccountType);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + Strings.CommunityAccountType);
                    break;

                case AccountType.ActionAccount:
                    UIUtilities.SetControlValue(this.generalDialog.Controls.RunAsAccountTypeComboBox, Strings.ActionAccountType); //this.generalDialog.Controls.RunAsAccountTypeComboBox.SelectByText(Strings.ActionAccountType);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + Strings.ActionAccountType);
                    break;

                case AccountType.SNMPv3:
                    UIUtilities.SetControlValue(this.generalDialog.Controls.RunAsAccountTypeComboBox, Strings.SNMPv3Type);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + Strings.SNMPv3Type);
                    break;
                default:
                    break;
            }

            UIUtilities.SetControlValue(this.generalDialog.Controls.DisplayNameTextBox, parameters.DisplayName); //this.generalDialog.DisplayNameText = parameters.DisplayName;
            Utilities.LogMessage("RunAsAccount.Create :: Successfully set display name");
            Utilities.LogMessage("RunAsAccount.Create :: Display Name right after setting is '"
                + this.generalDialog.DisplayNameText + "'");

            //Trying to set the description if its null throws System.ArgumentNullException
            if (parameters.Description != null)
            {
                UIUtilities.SetControlValue(this.generalDialog.Controls.DescriptionTextBox, parameters.Description);//this.generalDialog.DescriptionText = parameters.Description;
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                Utilities.LogMessage("RunAsAccount.Create :: Description right after setting is '"
                    + this.generalDialog.DescriptionText + "'");
            }

            this.generalDialog.ClickNext();

            #endregion RunAs Account Wizard - General Properties Page

            #region RunAs Account Wizard - Credentials Page

            switch (parameters.Type)
            {
                case AccountType.Windows:
                case AccountType.ActionAccount:
                case AccountType.Basic:
                case AccountType.Digest:
                case AccountType.Simple:
                    UIUtilities.SetControlValue (this.windowsAccountDialog.Controls.UserNameTextBox, parameters.UserName);//this.windowsAccountDialog.UserNameText = parameters.UserName;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set User Name " + parameters.UserName);
                    UIUtilities.SetControlValue(this.windowsAccountDialog.Controls.PasswordTextBox, parameters.Password);//this.windowsAccountDialog.PasswordText = parameters.Password;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set Password " + parameters.Password);
                    //Setting the Confirm Password field same as Password
                    UIUtilities.SetControlValue (this.windowsAccountDialog.Controls.ConfirmPasswordTextBox, parameters.Password);//this.windowsAccountDialog.ConfirmPasswordText = parameters.Password;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set Confirm Password field");
                    if (!String.IsNullOrEmpty(parameters.Domain) && parameters.Domain.ToLowerInvariant() != "invalid")
                    {
                        UIUtilities.SetControlValue(this.windowsAccountDialog.Controls.DomainEditComboBox, parameters.Domain);//this.windowsAccountDialog.DomainText = parameters.Domain;
                        Utilities.LogMessage("RunAsAccount.Create :: Successfully set Domain field");
                    }

                    UIUtilities.SetControlValue(this.windowsAccountDialog.Controls.NextButton);//this.windowsAccountDialog.ClickNext();
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully Clicked on Create");
                    break;

                case AccountType.Community:
                    UIUtilities.SetControlValue (this.communityAccountDialog.Controls.CommunityStringTextBox, parameters.CommunityString);//this.communityAccountDialog.CommunityStringText = parameters.CommunityString;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set community string");
                    UIUtilities.SetControlValue(this.windowsAccountDialog.Controls.NextButton);//this.windowsAccountDialog.ClickNext();
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully Clicked on Create");
                    break;

                case AccountType.Binary:
                    UIUtilities.SetControlValue(this.binaryAccountDialog.Controls.BinaryFileTextBox, parameters.BinaryFile);//this.binaryAccountDialog.BinaryFileText = parameters.BinaryFile;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set Binary File " + parameters.BinaryFile);
                    UIUtilities.SetControlValue(this.windowsAccountDialog.Controls.NextButton);//this.windowsAccountDialog.ClickNext();
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully Clicked on Create");
                    break;

                case AccountType.SNMPv3:
                    UIUtilities.SetControlValue(this.snmpv3AccountDialog.Controls.UserNameTextBox, parameters.UserName);//this.snmpv3AccountDialog.UserNameText = parameters.UserName;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set User Name " + parameters.UserName);
                    UIUtilities.SetControlValue (this.snmpv3AccountDialog.Controls.ContextOptionalTextBox, parameters.Context);//this.snmpv3AccountDialog.ContextOptionalText = parameters.Context;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set Context " + parameters.Context);

                    Utilities.LogMessage("RunAsAccount.Create :: Check the controls status");
                    if (this.snmpv3AccountDialog.Controls.ConfirmAuthenticationKeyTextBox.IsEnabled ||
                        this.snmpv3AccountDialog.Controls.AuthenticationKeyTextBox.IsEnabled ||
                        this.snmpv3AccountDialog.Controls.PrivacyProtocolComboBox.IsEnabled ||
                        this.snmpv3AccountDialog.Controls.PrivacyKeyTextBox.IsEnabled ||
                        this.snmpv3AccountDialog.Controls.ConfirmPrivacyKeyTextBox.IsEnabled
                        )
                    {
                        throw new System.ApplicationException("Invalid feilds are enabled.");
                    }

                    UIUtilities.SetControlValue(this.snmpv3AccountDialog.Controls.AuthenticationProtocolComboBox, (int)parameters.AuthenticationProtocol);//this.snmpv3AccountDialog.Controls.AuthenticationProtocolComboBox.SelectByIndex((int)parameters.AuthenticationProtocol);
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set AuthenticationProtocol " + parameters.AuthenticationProtocol);

                    if (parameters.AuthenticationProtocol != SNMPv3APType.None)
                    {
                        #region Check that the AuthenticationKey and AuthenticationKeyConfirm controls are enabled
                        consoleApp.Waiters.WaitForConditionCheckSuccess(delegate()
                        {
                            return this.snmpv3AccountDialog.Controls.AuthenticationKeyTextBox.IsEnabled && this.snmpv3AccountDialog.Controls.ConfirmAuthenticationKeyTextBox.IsEnabled;
                        });
                        #endregion Check that the AuthenticationKey and AuthenticationKeyConfirm controls are enabled

                        UIUtilities.SetControlValue(this.snmpv3AccountDialog.Controls.AuthenticationKeyTextBox, parameters.AuthenticationKey);//this.snmpv3AccountDialog.AuthenticationKeyText = parameters.AuthenticationKey;
                        Utilities.LogMessage("RunAsAccount.Create :: Successfully set AuthenticationKey " + parameters.AuthenticationKey);
                        UIUtilities.SetControlValue(this.snmpv3AccountDialog.Controls.ConfirmAuthenticationKeyTextBox, parameters.AuthenticationKey);//this.snmpv3AccountDialog.ConfirmAuthenticationKeyText = parameters.AuthenticationKey;
                        Utilities.LogMessage("RunAsAccount.Create :: Successfully set ConfirmAuthenticationKey " + parameters.AuthenticationKey);

                        Utilities.LogMessage("RunAsAccount.Create :: Check the controls status");
                        if (this.snmpv3AccountDialog.Controls.PrivacyKeyTextBox.IsEnabled ||
                            this.snmpv3AccountDialog.Controls.ConfirmPrivacyKeyTextBox.IsEnabled
                            )
                        {
                            throw new ApplicationException("Invalid fields are enabled.");
                        }

                        UIUtilities.SetControlValue(this.snmpv3AccountDialog.Controls.PrivacyProtocolComboBox, (int)parameters.PrivacyProtocol);//this.snmpv3AccountDialog.Controls.PrivacyProtocolComboBox.SelectByIndex((int)parameters.PrivacyProtocol);
                        Utilities.LogMessage("RunAsAccount.Create :: Successfully set PrivacyProtocol " + parameters.PrivacyProtocol);

                        if (parameters.PrivacyProtocol != SNMPv3PPType.None)
                        {
                            #region Check that the PrivacyKey and PrivacyKeyConfirm controls are enabled
                            consoleApp.Waiters.WaitForConditionCheckSuccess(delegate() 
                            { 
                                return this.snmpv3AccountDialog.Controls.PrivacyKeyTextBox.IsEnabled && this.snmpv3AccountDialog.Controls.ConfirmPrivacyKeyTextBox.IsEnabled;
                            });
                            #endregion Check that the PrivacyKey and PrivacyKeyConfirm controls are enabled

                            UIUtilities.SetControlValue(this.snmpv3AccountDialog.Controls.PrivacyKeyTextBox, parameters.PrivacyKey);//this.snmpv3AccountDialog.PrivacyKeyText = parameters.PrivacyKey;
                            Utilities.LogMessage("RunAsAccount.Create :: Successfully set PrivacyKey " + parameters.PrivacyKey);
                            UIUtilities.SetControlValue(this.snmpv3AccountDialog.Controls.ConfirmPrivacyKeyTextBox, parameters.PrivacyKey);//this.snmpv3AccountDialog.ConfirmPrivacyKeyText = parameters.PrivacyKey;
                            Utilities.LogMessage("RunAsAccount.Create :: Successfully set ConfirmPrivacyKey " + parameters.PrivacyKey);
                        }
                    }

                    UIUtilities.SetControlValue(this.windowsAccountDialog.Controls.NextButton);//this.windowsAccountDialog.ClickNext();
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully Clicked on Create");
                    break;
            }

            #endregion RunAs Account Wizard - Credentials Page

            #region RunAs Account Wizard - Distribution Security Page

            switch (parameters.DistributionSecurityOption)
            {
                // Set Distribution Security option to less-secure
                case DistributionSecurityOption.LessSecure:
                    this.runAsAccountWizardDistributionPage.DistributionSecurityOption =
                        DistributionSecurityOption.LessSecure;
                    break;

                // Set Distribution Security option to more-secure
                case DistributionSecurityOption.MoreSecure:
                    this.runAsAccountWizardDistributionPage.DistributionSecurityOption =
                        DistributionSecurityOption.MoreSecure;
                    break;

                // if the parameter is not set do nothing
                default:
                    break;
            }

            UIUtilities.SetControlValue(this.runAsAccountWizardDistributionPage.Controls.CreateButton);

            #endregion RunAs Account Wizard - Distribution Security Page

            #region RunAs Account Wizard - Completion Page
            // Workaround until bug 122321 is fixed.
            // the DoNotShowThisPageAgain check box was removed in improvement #131241
            // this.completionDialog.DoNotShowThisPageAgain = false;
            UIUtilities.SetControlValue(this.completionDialog.Controls.CloseButton);

            CoreManager.MomConsole.WaitForDialogClose(this.completionDialog, 60);

            consoleApp.Waiters.WaitForObjectPropertyChangedSafe(CoreManager.MomConsole.MainWindow, "@Extended.IsForeground",PropertyOperator.Equals,true,Constants.OneMinute *2);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout * 2);
            consoleApp.Waiters.WaitForReady();
            Utilities.LogMessage("RunAsAccount.Create:: Successfully completed the wizard");
            #endregion RunAs Account Wizard - Completion Page

            #endregion Navigate through the RunAs Account Wizard
        }

        /// <summary>
        /// Delete a particular RunAsAccount
        /// </summary>
        /// <param name="name">name</param>          
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>         
        /// <history>
        ///     [ruhim] 21APR06 - Created        
        /// </history>
        //<exception cref="Maui.Core.WinControls.DataGrid.Exceptions.WindowNotFoundException">WindowNotFoundException</exception>
        public void Delete(string name)
        {
            //Navigate to the RunAsAccount Node under Administration
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.SelectNode(RunAsAccountPath, NavigationPane.NavigationTreeView.Administration);
            Utilities.LogMessage("RunAsAccount.Delete :: Selected Node '" + NavigationPane.Strings.AdminTreeViewRunAsAccounts);

            consoleApp.Waiters.WaitForReady();

            //107732
            Utilities.LogMessage("RunAsAccount.Delete :: Refresh view pane for bug SM 107732 '");
            CoreManager.MomConsole.ViewPane.Extended.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
            consoleApp.Waiters.WaitForReady();
            CoreManager.MomConsole.SendKeys(KeyboardCodes.F5);
            consoleApp.Waiters.WaitForReady();

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            DataGridViewRow runAsAccountRow = null;
            if (viewGrid != null)
            {
                runAsAccountRow = viewGrid.FindData(name, Strings.ViewColumnNameHeader, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
                if (runAsAccountRow != null)
                {
                    Utilities.LogMessage("RunAsAccount.Delete :: Found the row : " + name);
                    runAsAccountRow.AccessibleObject.Click();
                    Utilities.LogMessage("RunAsAccount.Delete :: Successfully clicked on the row");

                    int attempt = 0;
                    int MaxAttempt = 2;
                    while (attempt <= MaxAttempt)
                    {
                        Menu rowContextMenu = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
                        //rowContextMenu.WaitContextMenuWithTimeOut(Constants.OneSecond * 10);
                        rowContextMenu.ScreenElement.WaitForReady();

                        Utilities.LogMessage("RunAsAccount.Delete :: Constructor for Menu called");
                        rowContextMenu.ExecuteMenuItem(ViewPane.Strings.AdministrationContextMenuDelete);
                        Utilities.LogMessage("RunAsAccount.Delete :: Successfully clicked on the context menu: "
                            + ViewPane.Strings.AdministrationContextMenuDelete);

                        attempt++;

                        try
                        {
                            //select Yes on the delete confirmation dialog
                            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes, Strings.ConfirmDeleteDialogTitle, StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Error);
                            Utilities.LogMessage("RunAsAccount.Delete :: Succesfully deleted the Run as Account");
                            break;
                        }
                        catch (Window.Exceptions.WindowNotFoundException)
                        {
                            Utilities.LogMessage("RunAsAccount.Delete :: Failed to find window: " + Strings.ConfirmDeleteDialogTitle);
                            CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                        }
                    }//while
                }
                else
                {
                    Utilities.LogMessage("RunAsAccount.Delete :: Run as Account row " + name + " not found");
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("Run as Account row not found to be deleted");
                }
            }
            else
            {
                Utilities.LogMessage("RunAsAccount.Delete :: Run as Account View grid not found");
                throw new DataGrid.Exceptions.WindowNotFoundException("Failed to find ViewGrid");
            }
        }

        /// <summary>
        /// Opens the properties dialog for a given run as account
        /// </summary>
        /// <param name="accountName"></param>
        public void OpenPropertiesDialog(string accountName)
        {
            # region Navigate To Run as Accounts Node

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.SelectNode(RunAsAccountPath, NavigationPane.NavigationTreeView.Administration);
            Utilities.LogMessage("RunAsAccount.OpenPropertiesDialog :: Selected Node '" + NavigationPane.Strings.AdminTreeViewRunAsAccounts);

            consoleApp.Waiters.WaitForReady();

            #endregion

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            DataGridViewRow runAsAccountRow = null;
            if (viewGrid != null)
            {
                runAsAccountRow = viewGrid.FindData(accountName, Strings.ViewColumnNameHeader, MomControls.GridControl.SearchStringMatchType.ExactMatch);
                if (runAsAccountRow != null)
                {
                    Utilities.LogMessage(String.Format(CultureInfo.CurrentUICulture, "RunAsAccount.OpenPropertiesDialog :: Found the row : '{0}'", accountName));
                    runAsAccountRow.AccessibleObject.Click();
                    Utilities.LogMessage("RunAsAccount.OpenPropertiesDialog :: Successfully clicked on the row");

                    Menu rowContextMenu = new Menu(ContextMenuAccessMethod.ShiftF10);
                    //rowContextMenu.WaitContextMenuWithTimeOut(Constants.OneSecond * 10);
                    rowContextMenu.ScreenElement.WaitForReady();

                    Utilities.LogMessage("RunAsAccount.OpenPropertiesDialog :: Constructor for Menu called");
                    rowContextMenu.ExecuteMenuItem(ViewPane.Strings.AdministrationContextMenuProperties);
                    Utilities.LogMessage("RunAsAccount.OpenPropertiesDialog :: Successfully clicked on the context menu: "
                        + ViewPane.Strings.AdministrationContextMenuProperties);
                }
                else
                {
                    Utilities.LogMessage(String.Format(CultureInfo.CurrentUICulture, "RunAsAccount.OpenPropertiesDialog :: Run as account row '{0}' not found!", accountName));
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("Run as account row not found to update");
                }
            }
            else
            {
                Utilities.LogMessage("RunAsAccount.OpenPropertiesDialog :: Run as account View grid not found");
                throw new DataGrid.Exceptions.WindowNotFoundException("Failed to find ViewGrid");
            }
        }

        /// <summary>
        /// Removes all distributions for the run as account
        /// </summary>
        /// <param name="accountName"></param>
        public void RemoveDistributionComputers(string accountName)
        {
            this.RemoveDistributionComputers(accountName, null);
        }

        /// <summary>
        /// Removes each computer in COMPUTERS array for a given run as account
        /// </summary>
        /// <param name="accountName">Name of the RunAsAccount</param>
        /// <param name="computers">Array of computers to be removed</param>
        public void RemoveDistributionComputers(string accountName, string[] computers)
        {
            this.OpenPropertiesDialog(accountName);
            Utilities.LogMessage("RemoveDistributionComputers :: Going to distribution tab.");

            TabControlTab distributionTab = new TabControlTab(generalProperties.Controls.Tab0TabControl, Strings.DistributionTab);
            generalProperties.Controls.Tab0TabControl.Tabs[distributionTab.Index].Select();

            try
            {
                Utilities.LogMessage("RemoveDistributionComputers :: Removing computers as requested.");
                if (computers == null)
                {
                    Utilities.LogMessage("RemoveDistributionComputers :: All computers will be removed.");
                    int count = this.distributionProperties.Controls.SelectedComputersListView.Items.Count;
                    if (count != 0)
                    {
                        Utilities.LogMessage(String.Format(CultureInfo.InvariantCulture, "RemoveDistributionComputers :: Removing all {0} computers.", count));
                        this.distributionProperties.Controls.SelectedComputersListView.SelectAll();
                        this.distributionProperties.Controls.ToolStrip1.ToolbarItems[INDEX_BUTTON_REMOVE].Click();
                    }
                }
                else
                {
                    this.distributionProperties.Controls.SelectedComputersListView.MultiSelect(computers);
                    this.distributionProperties.Controls.ToolStrip1.ToolbarItems[INDEX_BUTTON_REMOVE].Click();
                }
                UISynchronization.WaitForUIObjectReady(this.distributionProperties, Constants.DefaultContextMenuTimeout);
                Utilities.LogMessage("RemoveDistributionComputers :: Computers are removed successfully.");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Utilities.TakeScreenshot("RunAsProfile_RemoveDistributionComputers");
                this.distributionProperties.ClickOK();
            }
        }

        /// <summary>
        /// Updates the password for a RunAs account. This method assumes that any parameter
        /// values that are not null/empty/invalid should overwrite the current values. Null or empty
        /// values will be ignored.
        /// </summary>
        /// <param name="accountName">RunAs Account Display Name</param>
        /// <param name="parameters">Account parameters</param>
        public void Update(string accountName, RunAsAccountParameters parameters)
        {
            Utilities.LogMessage("RunAsAccount.Update :: ");

            try
            {
                this.OpenPropertiesDialog(accountName);

                #region General Properties
                if (!String.IsNullOrEmpty(parameters.DisplayName))
                {
                    Utilities.LogMessage("RunAsAccount.Update :: Set Display Name = " + parameters.DisplayName);
                    generalProperties.Controls.Tab0TabControl.Tabs[generalTab.Index].Select();
                    this.generalProperties.DisplayNameText = parameters.DisplayName;
                }

                if (!String.IsNullOrEmpty(parameters.Description))
                {
                    Utilities.LogMessage("RunAsAccount.Update :: Set Description = " + parameters.Description);
                    generalProperties.Controls.Tab0TabControl.Tabs[generalTab.Index].Select();
                    this.generalProperties.DescriptionText = parameters.Description;
                }
                #endregion General Properties

                #region Credentials

                switch (parameters.Type)
                {
                    case AccountType.SNMPv3:
                        generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();

                        if (!String.IsNullOrEmpty(parameters.UserName))
                        {
                            this.snmpv3Properties.UserNameText = parameters.UserName;
                            Utilities.LogMessage("RunAsAccount.Update :: Successfully set User Name " + parameters.UserName);
                        }
                        if (!String.IsNullOrEmpty(parameters.Context))
                        {
                            this.snmpv3Properties.ContextOptionalText = parameters.Context;
                            Utilities.LogMessage("RunAsAccount.Update :: Successfully set Context " + parameters.Context);
                        }

                        //To test controls visibility
                        this.snmpv3Properties.Controls.AuthenticationProtocolComboBox.SelectByIndex((int)SNMPv3APType.None);
                        Utilities.LogMessage("RunAsAccount.Update :: Successfully set AuthenticationProtocol None");

                        Utilities.LogMessage("RunAsAccount.Update :: Check the controls status");
                        if (this.snmpv3Properties.Controls.ConfirmAuthenticationKeyTextBox.IsEnabled ||
                            this.snmpv3Properties.Controls.AuthenticationKeyTextBox.IsEnabled ||
                            this.snmpv3Properties.Controls.PrivacyProtocolComboBox.IsEnabled ||
                            this.snmpv3Properties.Controls.PrivacyKeyTextBox.IsEnabled ||
                            this.snmpv3Properties.Controls.ConfirmPrivacyKeyTextBox.IsEnabled
                            )
                        {
                            throw new ApplicationException("Invalid feilds are enabled.");
                        }

                        this.snmpv3Properties.Controls.AuthenticationProtocolComboBox.SelectByIndex((int)parameters.AuthenticationProtocol);
                        Utilities.LogMessage("RunAsAccount.Update :: Successfully set AuthenticationProtocol " + parameters.AuthenticationProtocol);
                        if (parameters.AuthenticationProtocol != SNMPv3APType.None)
                        {
                            #region Check that the AuthenticationKey and AuthenticationKeyConfirm controls are enabled
                            consoleApp.Waiters.WaitForConditionCheckSuccess(delegate() 
                            {
                                return this.snmpv3Properties.Controls.AuthenticationKeyTextBox.IsEnabled && this.snmpv3Properties.Controls.ConfirmAuthenticationKeyTextBox.IsEnabled;
                            });
                            #endregion Check that the AuthenticationKey and AuthenticationKeyConfirm controls are enabled

                            this.snmpv3Properties.AuthenticationKeyText = parameters.AuthenticationKey;
                            Utilities.LogMessage("RunAsAccount.Update :: Successfully set AuthenticationKey " + parameters.AuthenticationKey);
                            this.snmpv3Properties.ConfirmAuthenticationKeyText = parameters.AuthenticationKey;
                            Utilities.LogMessage("RunAsAccount.Update :: Successfully set ConfirmAuthenticationKey " + parameters.AuthenticationKey);

                            Utilities.LogMessage("RunAsAccount.Update :: Check the controls status");
                            if (this.snmpv3Properties.Controls.PrivacyKeyTextBox.IsEnabled ||
                                this.snmpv3Properties.Controls.ConfirmPrivacyKeyTextBox.IsEnabled
                                )
                            {
                                throw new ApplicationException("Invalid fields are enabled.");
                            }

                            this.snmpv3Properties.Controls.PrivacyProtocolComboBox.SelectByIndex((int)parameters.PrivacyProtocol);
                            Utilities.LogMessage("RunAsAccount.Update :: Successfully set PrivacyProtocol" + parameters.PrivacyProtocol);
                            if (parameters.PrivacyProtocol != SNMPv3PPType.None)
                            {
                                #region Check that the PrivacyKey and PrivacyKeyConfirm controls are enabled
                                consoleApp.Waiters.WaitForConditionCheckSuccess(delegate()
                                {
                                    return this.snmpv3Properties.Controls.PrivacyKeyTextBox.IsEnabled &&this.snmpv3Properties.Controls.ConfirmPrivacyKeyTextBox.IsEnabled;
                                });
                                #endregion Check that the PrivacyKey and PrivacyKeyConfirm controls are enabled

                                this.snmpv3Properties.PrivacyKeyText = parameters.PrivacyKey;
                                Utilities.LogMessage("RunAsAccount.Update :: Successfully set PrivacyKey " + parameters.PrivacyKey);
                                this.snmpv3Properties.ConfirmPrivacyKeyText = parameters.PrivacyKey;
                                Utilities.LogMessage("RunAsAccount.Update :: Successfully set ConfirmPrivacyKey " + parameters.PrivacyKey);
                            }
                        }
                        break;

                    case AccountType.Windows:
                    case AccountType.Basic:
                    case AccountType.Simple:
                    case AccountType.Digest:
                    case AccountType.ActionAccount:
                        if (!String.IsNullOrEmpty(parameters.UserName))
                        {
                            Utilities.LogMessage("RunAsAccount.Update :: Set Username = " + parameters.UserName);
                            generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                            this.accountProperties.UserNameText = parameters.UserName;
                        }

                        if (!String.IsNullOrEmpty(parameters.Password))
                        {
                            Utilities.LogMessage("RunAsAccount.Update :: Set Password = " + parameters.Password);
                            generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                            this.accountProperties.PasswordText = parameters.Password;
                            this.accountProperties.ConfirmPasswordText = parameters.Password;
                        }

                        if (!String.IsNullOrEmpty(parameters.Domain) && parameters.Domain.ToLowerInvariant() != "invalid")
                        {
                            Utilities.LogMessage("RunAsAccount.Update :: Set Domain = " + parameters.Domain);
                            generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                            this.accountProperties.DomainText = parameters.Domain;
                        }
                        break;

                    case AccountType.Community:
                        if (!String.IsNullOrEmpty(parameters.CommunityString) && parameters.CommunityString.ToLowerInvariant() != "invalid")
                        {
                            Utilities.LogMessage("RunAsAccount.Update :: Set Community String = " + parameters.CommunityString);
                            generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                            this.commumityProperties.CommunityStringText = parameters.CommunityString;
                        }
                        break;

                    case AccountType.Binary:
                        if (!String.IsNullOrEmpty(parameters.BinaryFile) && parameters.BinaryFile.ToLowerInvariant() != "invalid")
                        {
                            Utilities.LogMessage("RunAsAccount.Update :: Set BinaryFile = " + parameters.BinaryFile);
                            generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                            this.binaryAccountProperties.ProvideAccountCredentialsText = parameters.BinaryFile;
                        }
                        break;

                    default:
                        throw new System.NotImplementedException(parameters.Type.ToString() + " Type is not supported in Update method.");
                }

                #endregion Credentials

                #region Distribution
                Utilities.LogMessage("RunAsAccount.Update :: Set Distribution Option = " + parameters.DistributionSecurityOption.ToString());

                generalProperties.Controls.Tab0TabControl.Tabs[distributionTab.Index].Select();

                // Distribution Type: More-Secure / Less-Secure
                switch (parameters.DistributionSecurityOption)
                {
                    case DistributionSecurityOption.LessSecure:
                        this.distributionProperties.Controls.LowSecurityRadioButton.Click();
                        break;

                    case DistributionSecurityOption.MoreSecure:
                        this.distributionProperties.Controls.HighSecurityRadioButton.Click();
                        break;

                    case DistributionSecurityOption.Default:
                        this.distributionProperties.Controls.HighSecurityRadioButton.Click();
                        break;

                    case DistributionSecurityOption.NotSpecified:
                        break;

                    default:
                        break;
                }

                // Distribution List
                if (parameters.AddToDistributionList.Count > 0 || parameters.RemoveFromDistributionList.Count > 0)
                {
                    Utilities.LogMessage("RunAsAccount.Update :: Modifying the Distribution List");

                    if (parameters.DistributionSecurityOption.Equals(DistributionSecurityOption.MoreSecure))
                    {
                        if (!this.distributionProperties.Controls.ToolStrip1.ToolbarItems[INDEX_BUTTON_ADD].Enabled
                            || !this.distributionProperties.Controls.SelectedComputersListView.Extended.IsEnabled)
                        {
                            throw new Maui.Core.WinControls.Control.Exceptions.ControlIsDisabledException("A control is disabled when it should be enabled.");
                        }

                        // Add to the Distribution List
                        // If a computer in the AddToDistributionList is *not* found we will skip it and 
                        // continue to add any remaining computer we find in the list.
                        if (parameters.AddToDistributionList.Count > 0)
                        {
                            this.distributionProperties.Controls.ToolStrip1.ToolbarItems[INDEX_BUTTON_ADD].Click();
                            UISynchronization.WaitForUIObjectReady(this.distributionProperties, Constants.DefaultDialogTimeout);

                            // find and add each computer to the distribution list one at a time.
                            foreach (string computer in parameters.AddToDistributionList)
                            {
                                this.computerPickerDialog.Controls.SearchTextBox.SendKeys(computer);
                                this.computerPickerDialog.ClickSearch();
                                UISynchronization.WaitForUIObjectReady(this.computerPickerDialog.Controls.SearchButton, Constants.DefaultContextMenuTimeout);
                                if (this.computerPickerDialog.Controls.AvailableComputersListView.Items.Count > 0)
                                {
                                    this.computerPickerDialog.Controls.AvailableComputersListView.SelectAll();
                                    this.computerPickerDialog.ClickAdd();
                                    UISynchronization.WaitForUIObjectReady(this.computerPickerDialog.Extended.AccessibleObject, Constants.DefaultContextMenuTimeout);
                                }
                                else
                                {
                                    Utilities.LogMessage("RunAsAccount.Update :: WARNING - computer '" + computer +
                                        "' not found and therefore will not be added to the Distribution List!");
                                }
                            }
                            this.computerPickerDialog.ClickOK();
                        }

                        // Remove from the Distribution List
                        if (parameters.RemoveFromDistributionList.Count > 0)
                        {

                        }
                    }
                    else if (parameters.DistributionSecurityOption.Equals(DistributionSecurityOption.LessSecure))
                    {
                        Utilities.LogMessage("RunAsAccount.Update :: Distribution Security Option is " +
                            "'" + parameters.DistributionSecurityOption.ToString() + "' therefore no " +
                            "computers will be added to or removed from the distribution list. Call " +
                            "this method with the More-Secure option.");
                    }
                }
                #endregion Distribution

                // Save changes
                Utilities.LogMessage("RunAsAccount.Update :: Save RunAs Account Changes");
                this.generalProperties.ClickOK();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifies the password for a RunAs account. 
        /// 
        /// No verification for distribution as it has been covered by Mom.Test.UI.RunAsAccounts.VerifyDistribution.
        /// </summary>
        /// <param name="accountName">RunAs Account Display Name</param>
        /// <param name="parameters">Account parameters</param>
        public bool Verify(string accountName, RunAsAccountParameters parameters)
        {
            //Return false if fails to verify
            bool result = true;

            Utilities.LogMessage("RunAsAccount.Verify :: ");

            try
            {
                this.OpenPropertiesDialog(accountName);

                #region General Properties
                if (!String.IsNullOrEmpty(parameters.DisplayName))
                {
                    Utilities.LogMessage("RunAsAccount.Verify :: Set Display Name = " + parameters.DisplayName);
                    generalProperties.Controls.Tab0TabControl.Tabs[generalTab.Index].Select();
                    if (this.generalProperties.DisplayNameText != parameters.DisplayName)
                    {
                        Utilities.LogMessage("RunAsAccount.Verify :: Dispaly name verification failed: " + parameters.DisplayName);
                        result = false;
                    }
                }

                if (!String.IsNullOrEmpty(parameters.Description))
                {
                    Utilities.LogMessage("RunAsAccount.Verify :: Set Description = " + parameters.Description);
                    generalProperties.Controls.Tab0TabControl.Tabs[generalTab.Index].Select();
                    if (this.generalProperties.DescriptionText != parameters.Description)
                    {
                        Utilities.LogMessage("RunAsAccount.Verify :: Description verification failed: " + parameters.Description);
                        result = false;
                    }
                }
                #endregion General Properties

                #region Credentials

                try
                {
                    switch (parameters.Type)
                    {
                        //No checking for controls status as Create & Modify have already covered this. 
                        case AccountType.SNMPv3:
                            generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();

                            if (!String.IsNullOrEmpty(parameters.UserName))
                            {
                                if (this.snmpv3Properties.UserNameText != parameters.UserName)
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: UserNameText verification failed: " + parameters.UserName);
                                    result = false;
                                }
                            }
                            if (!String.IsNullOrEmpty(parameters.Context))
                            {
                                if (this.snmpv3Properties.ContextOptionalText != parameters.Context)
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: Context verification failed: " + parameters.Context);
                                    result = false;
                                }
                            }
                            if (this.snmpv3Properties.Controls.AuthenticationProtocolComboBox.SelectedIndex != (int)parameters.AuthenticationProtocol)
                            {
                                Utilities.LogMessage("RunAsAccount.Verify :: AuthenticationProtocol verification failed: " + parameters.AuthenticationProtocol);
                                result = false;
                            }
                            if (this.snmpv3Properties.Controls.PrivacyProtocolComboBox.SelectedIndex != (int)parameters.PrivacyProtocol)
                            {
                                Utilities.LogMessage("RunAsAccount.Verify :: PrivacyProtocol verification failed: " + parameters.PrivacyProtocol);
                                result = false;
                            }
                            if (!String.IsNullOrEmpty(parameters.AuthenticationKey) && parameters.AuthenticationProtocol != SNMPv3APType.None)
                            {
                                if (!IsPassword(this.snmpv3Properties.AuthenticationKeyText))
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: AuthenticationKey verification failed: " + parameters.AuthenticationKey);
                                    result = false;
                                }
                                if (!IsPassword(this.snmpv3Properties.ConfirmAuthenticationKeyText))
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: ConfirmAuthenticationKey verification failed: " + parameters.AuthenticationKey);
                                    result = false;
                                }
                            }
                            if (!String.IsNullOrEmpty(parameters.PrivacyKey) && parameters.PrivacyProtocol != SNMPv3PPType.None)
                            {
                                if (!IsPassword(this.snmpv3Properties.PrivacyKeyText))
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: PrivacyKey verification failed: " + parameters.PrivacyKey);
                                    result = false;
                                }
                                if (!IsPassword(this.snmpv3Properties.ConfirmPrivacyKeyText))
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: ConfirmPrivacyKeyverification verification failed: " + parameters.PrivacyKey);
                                    result = false;
                                }
                            }
                            break;

                        case AccountType.Windows:
                        case AccountType.Basic:
                        case AccountType.Simple:
                        case AccountType.Digest:
                        case AccountType.ActionAccount:
                            if (!String.IsNullOrEmpty(parameters.UserName))
                            {
                                Utilities.LogMessage("RunAsAccount.Verify :: RunAsAccount.Verify :: Set Username = " + parameters.UserName);
                                generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                                if (this.accountProperties.UserNameText != parameters.UserName)
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: UserName verification failed: " + parameters.UserName);
                                    result = false;
                                }
                            }

                            if (!String.IsNullOrEmpty(parameters.Domain) && parameters.Domain.ToLowerInvariant() != "invalid")
                            {
                                Utilities.LogMessage("RunAsAccount.Verify :: RunAsAccount.Verify :: Set Domain = " + parameters.Domain);
                                generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                                if (this.accountProperties.DomainText != parameters.Domain)
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: Domain verification failed: " + parameters.Domain);
                                    result = false;
                                }
                            }

                            if (!String.IsNullOrEmpty(parameters.Password))
                            {
                                Utilities.LogMessage("RunAsAccount.Verify :: RunAsAccount.Verify :: Set Password = " + parameters.Password);
                                generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                                if (!IsPassword(this.accountProperties.PasswordText))
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: Password verification failed: " + parameters.Password);
                                    result = false;
                                }
                                if (!IsPassword(this.accountProperties.ConfirmPasswordText) && parameters.Password.ToLowerInvariant() != "invalid")
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: ConfirmPassword verification failed: " + parameters.Password);
                                    result = false;
                                }
                            }
                            break;

                        case AccountType.Community:
                            if (!String.IsNullOrEmpty(parameters.CommunityString) && parameters.CommunityString.ToLowerInvariant() != "invalid")
                            {
                                Utilities.LogMessage("RunAsAccount.Verify :: RunAsAccount.Verify :: Set CommunityString = " + parameters.CommunityString);
                                generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();
                                if (!IsPassword(this.commumityProperties.CommunityStringText))
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: CommunityString verification failed: " + parameters.CommunityString);
                                    result = false;
                                }
                            }
                            break;

                        case AccountType.Binary:
                            if (!String.IsNullOrEmpty(parameters.BinaryFile) && parameters.BinaryFile.ToLowerInvariant() != "invalid")
                            {
                                Utilities.LogMessage("RunAsAccount.Verify :: RunAsAccount.Verify :: Set BinaryFile = " + parameters.BinaryFile);
                                generalProperties.Controls.Tab0TabControl.Tabs[accountTab.Index].Select();

                                if (this.binaryAccountProperties.ProvideAccountCredentialsText != Strings.EncryptedBinaryData)
                                {
                                    Utilities.LogMessage("RunAsAccount.Verify :: BinaryFile verification failed: " + parameters.BinaryFile);
                                    result = false;
                                }
                            }
                            break;

                        default:
                            throw new System.NotImplementedException(parameters.Type.ToString() + " Type is not supported in Verify method.");

                    }
                }
                catch (System.NotSupportedException ex)
                {
                    string expectedMessage = "Cannot read the value of a textbox that is a password type textbox";

                    // Maui 2.0 no longer allows access to the Text property on a password control.
                    // We now check the exception message and swallow it on a match, else we
                    // rethrow the exception.
                    if (!ex.Message.Equals(expectedMessage, StringComparison.InvariantCultureIgnoreCase))
                    {
                        throw ex;
                    }

                    Utilities.LogMessage("Maui 2.0 doesn't allow access to the Text property on a password control... swallowing System.NotSupportedException.");
                }
                #endregion Credentials

                #region Distribution
                //covered by Mom.Test.UI.RunAsAccounts.VerifyDistribution
                #endregion Distribution

                // Save changes
                Utilities.LogMessage("RunAsAccount.Verify :: Save RunAs Account Changes");
                this.generalProperties.ClickOK();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check whether the string is in Password-form
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool IsPassword(string s)
        {
            if (String.IsNullOrEmpty(s))
                return false;

            foreach (char c in s)
            {
                if (c != PASSWORD_CHAR)
                    return false;
            }
            return true;
        }

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for User Role
        /// </summary>
        /// <history> 	
        ///   [ruhim]  06Sep05: Created. Added resource strings for user roles 
        ///                     specific views
        ///   [ruhim]  16Jan06: Adding strings to get Current Logged in Users name and Domain.
        ///                     And Deleting all the obsolete strings
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains Resource string for:  Windows in the Account Type drop down 
            /// </summary>            
            private const string ResourceWindowsAccountType =
                ";Windows;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;WindowsAccountText";

            /// <summary>
            /// Contains Resource string for:  Binary Authentication in the Account Type drop down 
            /// </summary>            
            private const string ResourceBinaryAccountType =
                ";Binary Authentication;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;BinaryAccountText";

            /// <summary>
            /// Contains Resource string for:  Simple Authentication in the Account Type drop down 
            /// </summary>            
            private const string ResourceSimpleAccountType =
                ";Simple Authentication;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SimpleAccountText";

            /// <summary>
            /// Contains Resource string for:  Digest Authentication in the Account Type drop down 
            /// </summary>            
            private const string ResourceDigestAccountType =
                ";Digest Authentication;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DigestAccountText";

            /// <summary>
            /// Contains Resource string for:  Basic Authentication in the Account Type drop down 
            /// </summary>            
            private const string ResourceBasicAccountType =
                ";Basic Authentication;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;BasicAccountText";

            /// <summary>
            /// Contains Resource string for:  Community String in the Account Type drop down 
            /// </summary>            
            private const string ResourceCommunityAccountType =
                ";Community String;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CommunityAccountText";

            /// <summary>
            /// Contains Resource string for: Action Account in the Account Type drop down 
            /// </summary> 
            //TODO: Add the resource string for Action Account - couldn't find it
            private const string ResourceActionAccountType =
                ";Action Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ViewColumnActionAccount";

            /// <summary>
            /// Contains Resource string for:  Windows in the SNMPv3 Type drop down 
            /// </summary>            
            private const string ResourceSNMPv3AccountType =
                ";SNMPv3 Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SnmpV3Account";

            /// <summary>
            /// Contains Resource string for:  Dialog Title for Delete Confirmation 
            /// </summary>            
            private const string ResourceConfirmDeleteDialogTitle =
                ";Confirm Run As Account Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountDeleteTitle";

            /// <summary>
            /// Contains Resource string for:  Name Header for the Run As Account View
            /// </summary>            
            private const string ResourceViewColumnNameHeader =
                ";Name;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Name";

            /// <summary>
            /// Contains Resource string for:  Display text in Binary file textbox
            /// </summary>            
            private const string ResourceEncryptedBinaryData =
                ";[Encrypted binary data];ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;EncryptedBinaryData";

            /// <summary>
            /// Contains Resource string for:  General Tab text
            /// </summary>            
            private const string ResourceGeneralTab =
                ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// <summary>
            /// Contains Resource string for:  Account Tab text
            /// </summary>            
            private const string ResourceAccountTab =
                ";Credentials;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AccountsTitle";

            /// <summary>
            /// Contains Resource string for:  Distribution Tab text
            /// </summary>            
            private const string ResourceDistributionTab =
                ";Distribution;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsAccount.RunAsAccountDistributionsPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets the network doamin name associated with the current user
            /// </summary>       
            /// -----------------------------------------------------------------------------
            public static string UserDNSDomain = Environment.UserDomainName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets the User Name of the person who started the cuurent thread
            /// </summary>       
            /// -----------------------------------------------------------------------------
            public static string Username = Environment.UserName;

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Windows in the Account Type drop down
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsAccountType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Binary Authentication in the Account Type drop down
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBinaryAccountType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Simple Authentication in the Account Type drop down
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSimpleAccountType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Digest Authentication in the Account Type drop down
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDigestAccountType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Basic Authentication in the Account Type drop down
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBasicAccountType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Community String in the Account Type drop down
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCommunityAccountType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Action Account in the Account Type drop down
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActionAccountType;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SNMPv3 Type drop down
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSNMPv3Type;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Dialog Title for Delete Confirmation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmDeleteDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name Header for the Run As Account View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewColumnNameHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Display text in Binary file textbox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEncryptedBinaryData;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General Tab text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralTab;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Account Tab text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAccountTab;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Distribution Tab text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDistributionTab;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Windows in the Account Type drop down
            /// </summary>
            /// <history>
            /// 	[ruhim] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsAccountType
            {
                get
                {
                    if ((cachedWindowsAccountType == null))
                    {
                        cachedWindowsAccountType = CoreManager.MomConsole.GetIntlStr(ResourceWindowsAccountType);
                    }

                    return cachedWindowsAccountType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Binary Authentication in the Account Type drop down
            /// </summary>
            /// <history>
            /// 	[ruhim] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BinaryAccountType
            {
                get
                {
                    if ((cachedBinaryAccountType == null))
                    {
                        cachedBinaryAccountType = CoreManager.MomConsole.GetIntlStr(ResourceBinaryAccountType);
                    }

                    return cachedBinaryAccountType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Simple Authentication in the Account Type drop down
            /// </summary>
            /// <history>
            /// 	[ruhim] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SimpleAccountType
            {
                get
                {
                    if ((cachedSimpleAccountType == null))
                    {
                        cachedSimpleAccountType = CoreManager.MomConsole.GetIntlStr(ResourceSimpleAccountType);
                    }

                    return cachedSimpleAccountType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Digest Authentication in the Account Type drop down
            /// </summary>
            /// <history>
            /// 	[ruhim] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DigestAccountType
            {
                get
                {
                    if ((cachedDigestAccountType == null))
                    {
                        cachedDigestAccountType = CoreManager.MomConsole.GetIntlStr(ResourceDigestAccountType);
                    }

                    return cachedDigestAccountType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Basic Authentication in the Account Type drop down
            /// </summary>
            /// <history>
            /// 	[ruhim] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BasicAccountType
            {
                get
                {
                    if ((cachedBasicAccountType == null))
                    {
                        cachedBasicAccountType = CoreManager.MomConsole.GetIntlStr(ResourceBasicAccountType);
                    }

                    return cachedBasicAccountType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Community String in the Account Type drop down
            /// </summary>
            /// <history>
            /// 	[ruhim] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommunityAccountType
            {
                get
                {
                    if ((cachedCommunityAccountType == null))
                    {
                        cachedCommunityAccountType = CoreManager.MomConsole.GetIntlStr(ResourceCommunityAccountType);
                    }

                    return cachedCommunityAccountType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Action Account in the Account Type drop down
            /// </summary>
            /// <history>
            /// 	[ruhim] 01Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ActionAccountType
            {
                get
                {
                    if ((cachedActionAccountType == null))
                    {
                        cachedActionAccountType = CoreManager.MomConsole.GetIntlStr(ResourceActionAccountType);
                    }

                    return cachedActionAccountType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Dialog Title for Delete Confirmation
            /// </summary>
            /// <history>
            /// 	[ruhim] 21APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmDeleteDialogTitle
            {
                get
                {
                    if ((cachedConfirmDeleteDialogTitle == null))
                    {
                        cachedConfirmDeleteDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmDeleteDialogTitle);
                    }
                    return cachedConfirmDeleteDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Name Header for the Run As Account View
            /// </summary>
            /// <history>
            /// 	[ruhim] 21APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewColumnNameHeader
            {
                get
                {
                    if ((cachedViewColumnNameHeader == null))
                    {
                        cachedViewColumnNameHeader = CoreManager.MomConsole.GetIntlStr(ResourceViewColumnNameHeader);
                    }
                    return cachedViewColumnNameHeader;
                }
            }

            /// <summary>
            /// Exposes access to SNMPv3 Type in the Account Type drop down
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17 Created
            /// </history>
            /// </summary>
            public static string SNMPv3Type
            {
                get
                {
                    if ((cachedSNMPv3Type == null))
                    {
                        cachedSNMPv3Type = CoreManager.MomConsole.GetIntlStr(ResourceSNMPv3AccountType);
                    }

                    return cachedSNMPv3Type;
                }
            }

            /// <summary>
            /// Exposes access to Display text in Binary file textbox
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/30 Created
            /// </history>
            /// </summary>
            public static string EncryptedBinaryData
            {
                get
                {
                    if ((cachedEncryptedBinaryData == null))
                    {
                        cachedEncryptedBinaryData = CoreManager.MomConsole.GetIntlStr(ResourceEncryptedBinaryData);
                    }

                    return cachedEncryptedBinaryData;
                }
            }

            /// <summary>
            /// Exposes access to General Tab text
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/30 Created
            /// </history>
            /// </summary>
            public static string GeneralTab
            {
                get
                {
                    if ((cachedGeneralTab == null))
                    {
                        cachedGeneralTab = CoreManager.MomConsole.GetIntlStr(ResourceGeneralTab);
                    }

                    return cachedGeneralTab;
                }
            }

            /// <summary>
            /// Exposes access to Account Tab text
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/30 Created
            /// </history>
            /// </summary>
            public static string AccountTab
            {
                get
                {
                    if ((cachedAccountTab == null))
                    {
                        cachedAccountTab = CoreManager.MomConsole.GetIntlStr(ResourceAccountTab);
                    }

                    return cachedAccountTab;
                }
            }

            /// <summary>
            /// Exposes access to Distribution Tab text
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/30 Created
            /// </history>
            /// </summary>
            public static string DistributionTab
            {
                get
                {
                    if ((cachedDistributionTab == null))
                    {
                        cachedDistributionTab = CoreManager.MomConsole.GetIntlStr(ResourceDistributionTab);
                    }

                    return cachedDistributionTab;
                }
            }

            #endregion
        }
        #endregion

        #region RunAsAccountParameters Class
        /// <summary>
        /// Parameters class for RunAsAccount constructors.
        /// </summary>
        /// <history>
        /// [ruhim] 20APR06 Created
        /// </history>
        public class RunAsAccountParameters
        {
            #region Private Members
            private AccountType cachedType;
            private string cachedDisplayName = null;
            private string cachedDescription = null;
            private string cachedUserName = null;
            private string cachedPassword = null;
            private string cachedDomain = null;
            private string cachedCommunityString = null;
            private string cachedBinaryFile = null;
            private string cachedAuthenticationKey = null;
            private string cachedPrivacyKey = null;
            private string cachedContext = null;

            private DistributionSecurityOption cachedDistributionSecurityOption;
            private SNMPv3APType cachedAuthenticationProtocol;
            private SNMPv3PPType cachedPrivacyProtocol;
            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public RunAsAccountParameters()
            {
                AddToDistributionList = new List<string>();
                RemoveFromDistributionList = new List<string>();
            }
            #endregion

            /// <summary>
            /// List of computers to be added to the RunAs Account Distribution list
            /// </summary>
            public List<string> AddToDistributionList = null;

            /// <summary>
            /// List of computers to be removed from the RunAs Account Distribution list
            /// </summary>
            public List<string> RemoveFromDistributionList = null;

            #region Properties

            /// <summary>
            /// Run as Account Type
            /// </summary>
            public AccountType Type
            {
                get
                {
                    return this.cachedType;
                }

                set
                {
                    this.cachedType = value;
                }
            }

            /// <summary>
            /// Display Name of Run as Account
            /// </summary>
            public string DisplayName
            {
                get
                {
                    return this.cachedDisplayName;
                }

                set
                {
                    this.cachedDisplayName = value;
                }
            }

            /// <summary>
            /// Description of User Role
            /// </summary>
            public string Description
            {
                get
                {
                    return this.cachedDescription;
                }

                set
                {
                    this.cachedDescription = value;
                }
            }

            /// <summary>
            /// User Name of Run as Account
            /// </summary>
            public string UserName
            {
                get
                {
                    return this.cachedUserName;
                }

                set
                {
                    this.cachedUserName = value;
                }
            }

            /// <summary>
            /// Password for the Run as Account
            /// </summary>
            public string Password
            {
                get
                {
                    return this.cachedPassword;
                }

                set
                {
                    this.cachedPassword = value;
                }
            }

            /// <summary>
            /// Binary File for the Run as Account
            /// </summary>
            public string BinaryFile
            {
                get
                {
                    return this.cachedBinaryFile;
                }

                set
                {
                    this.cachedBinaryFile = value;
                }
            }

            /// <summary>
            /// Domain for the Run as Account
            /// </summary>
            public string Domain
            {
                get
                {
                    return this.cachedDomain;
                }

                set
                {
                    this.cachedDomain = value;
                }
            }

            /// <summary>
            /// Community String for the Run as Account
            /// </summary>
            public string CommunityString
            {
                get
                {
                    return this.cachedCommunityString;
                }

                set
                {
                    this.cachedCommunityString = value;
                }
            }

            /// <summary>
            /// Distribution Security Option for the RunAs account
            /// </summary>
            public DistributionSecurityOption DistributionSecurityOption
            {
                get
                {
                    return this.cachedDistributionSecurityOption;
                }

                set
                {
                    this.cachedDistributionSecurityOption = value;
                }
            }

            /// <summary>
            /// AuthenticationProtocol for SNMPv3 Account
            /// </summary>
            public SNMPv3APType AuthenticationProtocol
            {
                get
                {
                    return this.cachedAuthenticationProtocol;
                }

                set
                {
                    this.cachedAuthenticationProtocol = value;
                }
            }

            /// <summary>
            /// PrivacyProtocol for SNMPv3 Account
            /// </summary>
            public SNMPv3PPType PrivacyProtocol
            {
                get
                {
                    return this.cachedPrivacyProtocol;
                }

                set
                {
                    this.cachedPrivacyProtocol = value;
                }
            }

            /// <summary>
            /// AuthenticationKey for SNMPv3 Account
            /// </summary>
            public string AuthenticationKey
            {
                get
                {
                    return this.cachedAuthenticationKey;
                }

                set
                {
                    this.cachedAuthenticationKey = value;
                }
            }

            /// <summary>
            /// PrivacyKey for SNMPv3 Account
            /// </summary>
            public string PrivacyKey
            {
                get
                {
                    return this.cachedPrivacyKey;
                }

                set
                {
                    this.cachedPrivacyKey = value;
                }
            }

            /// <summary>
            /// Context for SNMPv3 Account
            /// </summary>
            public string Context
            {
                get
                {
                    return this.cachedContext;
                }

                set
                {
                    this.cachedContext = value;
                }
            }

            #endregion
        }
        #endregion

    } //end of class UserRole

}//end of namespace