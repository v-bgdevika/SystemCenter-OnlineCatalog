// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunAsProfile.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Run As Account Base Class.
// </summary>
// <history>
// 	[ruhim] 19-Aug-06   Created
//     [ruhim] 08-Sep-06   Increasing the wait time after deletion to a max of 4 mins 
//                      from 2 mins to fix BVT failure seen on SCE
//  [sharatja] 22-Aug-08 Modified test code to support R2 changes
// </history>
// ---------------------------------------------------------------------------
#region Using directives
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using Maui.Core;
using Maui.Core.Utilities;
using Maui.Core.WinControls;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.Dialogs;
using Mom.Test.UI.Core.Console.MomControls;
using Mom.Test.UI.Core.Console.RunAsProfile.Dialogs;
using System.Collections.Generic;
#endregion

namespace Mom.Test.UI.Core.Console.RunAsProfile
{
    /// <summary>
    /// Class to add general methods for Run As Account 
    /// </summary>
    public class RunAsProfile
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
        /// Index of NAME column in the selected targets grid control
        /// </summary>
        public static int INDEX_COLUMN_NAME = 0;

        /// <summary>
        /// Index of ACCOUNT column in the selected targets grid control
        /// </summary>
        public static int INDEX_COLUMN_ACCOUNT = 1;

        /// <summary>
        /// Index of GENERAL tab in the run as profile property dialog
        /// </summary>
        public static int INDEX_TAB_GENERAL = 0;

        /// <summary>
        /// Index of ASSOCIATIONS tab in the run as profile property dialog
        /// </summary>
        public static int INDEX_TAB_ASSOCIATIONS = 1;
                
        /// <summary>
        /// Path to the Run As Profile Node for SelectNode method
        /// </summary>
        public string RunAsProfilePath = NavigationPane.Strings.AdminTreeViewAdministrationRoot
            + Constants.PathDelimiter
            + NavigationPane.Strings.AdminTreeViewRunAsConfiguration
            + Constants.PathDelimiter
            + NavigationPane.Strings.AdminTreeViewRunAsProfiles;

        /// <summary>
        /// Max Retry times
        /// </summary>
        public int maxRetry = 10;

        #endregion

        #region Private Members
        /// <summary>
        /// cachedgeneralProperties
        /// </summary>
        private GeneralProperties cachedgeneralProperties;

        /// <summary>
        /// cachedGroupSearchDialog
        /// </summary>
        private GroupSearchDialog cachedGroupSearchDialog;

        /// <summary>
        /// cachedObjectSearchDialog
        /// </summary>
        private SingleObjectSearchDialog cachedObjectSearchDialog;

        /// <summary>
        /// cachedClassSearchDialog
        /// </summary>
        private ClassSearchDialog cachedClassSearchDialog;

        /// <summary>
        /// cachedAddAlternateRunAsAccount
        /// </summary>
        private AddAlternateRunAsAccount cachedAddAlternateRunAsAccount;

        /// <summary>
        /// cachedRunAsAccountsProperties
        /// </summary>
        private RunAsAccountsProperties cachedRunAsAccountsProperties;

        /// <summary>
        /// cachedAssociationsProperties
        /// </summary>
        private AssociationsProperties cachedAssociationsProperties;

        /// <summary>
        /// cachedRunAsProfileWizardCompletionPage
        /// </summary>
        private RunAsProfileWizardCompletionPage cachedRunAsProfileWizardCompletionPage;

        /// <summary>
        /// cachedAddARunAsAccountDialog
        /// </summary>
        private AddARunAsAccountDialog cachedAddARunAsAccountDialog;

        /// <summary>
        /// cachedIntroductionDialog
        /// </summary>
        private IntroductionDialog cachedIntroductionDialog;

        /// <summary>
        /// cachedGeneralDialog
        /// </summary>
        private GeneralDialog cachedGeneralDialog;

        /// <summary>
        /// cachedRunasAccountsDialog
        /// </summary>
        private RunasAccountsDialog cachedRunasAccountsDialog;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;
        
        #endregion

        #region Constructor
        /// <summary>
        /// Run As Profile Constructor.
        /// </summary>
        public RunAsProfile()
        {
            this.consoleApp = CoreManager.MomConsole;            
        }
        #endregion

        #region Properties

        /// <summary>
        /// General Properties        
        /// </summary>
        public GeneralProperties generalProperties
        {
            get
            {
                if (this.cachedgeneralProperties == null)
                {
                    this.cachedgeneralProperties = new GeneralProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }
                return this.cachedgeneralProperties;
            }
        }

        /// <summary>
        /// Association Properties        
        /// </summary>
        public AssociationsProperties associationsProperties
        {
            get
            {
                if (this.cachedAssociationsProperties == null)
                {
                    this.cachedAssociationsProperties = new AssociationsProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Associations Properties Dialog was successful");
                }
                return this.cachedAssociationsProperties;
            }
        }

        /// <summary>
        /// RunAs Profile Wizard - Completion Page
        /// </summary>
        public RunAsProfileWizardCompletionPage runAsProfileWizardCompletionPage
        {
            get
            {
                if (this.cachedRunAsProfileWizardCompletionPage == null)
                {
                    this.cachedRunAsProfileWizardCompletionPage = new RunAsProfileWizardCompletionPage(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the 'RunAs Profile Wizard - Completion Page' was successful");
                }
                return this.cachedRunAsProfileWizardCompletionPage;
            }
        }


        /// <summary>
        /// Association Properties        
        /// </summary>
        public AddARunAsAccountDialog addARunAsAccountDialog
        {
            get
            {
                if (this.cachedAddARunAsAccountDialog == null)
                {
                    this.cachedAddARunAsAccountDialog = new AddARunAsAccountDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Add a RunAs Account Dialog was successful");
                }
                return this.cachedAddARunAsAccountDialog;
            }
        }

        /// <summary>
        /// Select Group Dialog      
        /// </summary>
        public GroupSearchDialog GroupSearchDialog
        {
            get
            {
                if (this.cachedGroupSearchDialog == null)
                {
                    this.cachedGroupSearchDialog = new GroupSearchDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Group Dialog was successful");
                }
                return this.cachedGroupSearchDialog;
            }
        }

        /// <summary>
        /// Select Object Dialog      
        /// </summary>
        public SingleObjectSearchDialog ObjectSearchDialog
        {
            get
            {
                if (this.cachedObjectSearchDialog == null)
                {                    
                    this.cachedObjectSearchDialog = new SingleObjectSearchDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Object Dialog was successful");
                }
                return this.cachedObjectSearchDialog;
            }
        }

        /// <summary>
        /// Select Class Dialog      
        /// </summary>
        public ClassSearchDialog ClassSearchDialog
        {
            get
            {
                if (this.cachedClassSearchDialog == null)
                {
                    this.cachedClassSearchDialog = new ClassSearchDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Class Dialog was successful");
                }
                return this.cachedClassSearchDialog;
            }
        }

        /// <summary>
        /// Add Alternate Run As Account Dialog
        /// </summary>
        public AddAlternateRunAsAccount addAlternateRunAsAccount
        {
            get
            {
                if (this.cachedAddAlternateRunAsAccount == null)
                {
                    this.cachedAddAlternateRunAsAccount = new AddAlternateRunAsAccount(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Add Alternate Run As Account Dialog was successful");
                }
                return this.cachedAddAlternateRunAsAccount;
            }
        }

        /// <summary>
        /// Run As Accounts Properties         
        /// </summary>
        public RunAsAccountsProperties runAsAccountsProperties
        {
            get
            {
                if (this.cachedRunAsAccountsProperties == null)
                {
                    this.cachedRunAsAccountsProperties = new RunAsAccountsProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Run As Accounts Properties was successful");
                }
                return this.cachedRunAsAccountsProperties;
            }
        }

        /// <summary>
        /// Introduction Dialog in the wizard        
        /// </summary>
        public IntroductionDialog introductionDialog
        {
            get
            {
                if (this.cachedIntroductionDialog == null)
                {
                    this.cachedIntroductionDialog = new IntroductionDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Introduction Dialog was successful");
                }
                return this.cachedIntroductionDialog;
            }
        }

        /// <summary>
        /// General Dialog of the Wizard
        /// </summary>
        public GeneralDialog generalDialog
        {
            get
            {
                if (this.cachedGeneralDialog == null)
                {
                    this.cachedGeneralDialog = new GeneralDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the General Dialog was successful");
                }
                return this.cachedGeneralDialog;
            }
        }

        /// <summary>
        /// Run as Accounts Dialog of the Wizard      
        /// </summary>
        public RunasAccountsDialog runasAccountsDialog
        {
            get
            {
                if (this.cachedRunasAccountsDialog == null)
                {
                    this.cachedRunasAccountsDialog = new RunasAccountsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Run as Accounts Dialog was successful");
                }
                return this.cachedRunasAccountsDialog;
            }
        }
        
        #endregion

        /// <summary>
        /// Update Run as Profile with a Run as Account aand Target Computer pair
        /// </summary>
        /// <param name="name">Name of Run as Profile in the viewpane</param>
        /// <param name="targetComputerAccountPair">Hashtable to store Run As Account and Target Computer pairs</param>
        /// <param name="parameter">Parameter to specify whether to do an Add, Edit or Delete</param>
        public void Update(string name, Hashtable targetComputerAccountPair, UpdateParameter parameter)
        {
            RunAsProfileParameters parameters = new RunAsProfileParameters();
            parameters.SearchName = name;
            parameters.TargetComputerAccountPairs = targetComputerAccountPair;
            this.Update(parameters, parameter);
        }

        /// <summary>
        /// Update Run as Profile Property
        /// </summary>
        /// <param name="parameters">RunAsProfileParameters</param>
        /// <param name="parameter">Parameter to specify whether to do an Add, Edit or Delete</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>         
        /// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ListViewHasNoItemsException">ListViewHasNoItemsException</exception>         
        /// <history>
        ///     [ruhim] 09FEB06 - Created
        ///     [nathd] 29JAN09 - Added support for R2 RC improvement #131241. Added ability to use this 
        ///                       method to add, modify or delete RunAs accounts within a profile depending
        ///                       on the UpdateParameter paramter.
        /// </history>
        public void Update(RunAsProfileParameters parameters, UpdateParameter parameter)
        {
            LaunchRunAsProfileWizard(parameters.SearchName);

            #region Update: RunAs Profile Wizard - Introduction Page

            //TODO: Add logic to check the "DoNotShowAgain" checkbox.
            UIUtilities.SetControlValue(this.generalDialog.Controls.NextButton); //this.introductionDialog.ClickNext();

            #endregion Update: RunAs Profile Wizard - Introduction Page


            #region Update: RunAs Profile Wizard - General Properties

            if (parameters.DisplayName != null)
            {
                Utilities.LogMessage("RunAsProfile.Update :: Old Display Name : " + this.generalProperties.DisplayNameText);
                UIUtilities.SetControlValue(this.generalDialog.Controls.DisplayNameTextBox,parameters.DisplayName); // this.generalProperties.DisplayNameText = parameters.DisplayName;
                Utilities.LogMessage("RunAsProfile.Update :: Updated Display Name : " + this.generalProperties.DisplayNameText);
            }

            if (parameters.Description != null)
            {
                Utilities.LogMessage("RunAsProfile.Update :: Old Description : " + this.generalProperties.DescriptionText);
                UIUtilities.SetControlValue(this.generalDialog.Controls.DescriptionTextBox, parameters.Description); // this.generalProperties.DescriptionText = parameters.Description;
                Utilities.LogMessage("RunAsProfile.Update :: Updated Description : " + this.generalProperties.DescriptionText);
            }

            this.generalProperties.ClickNext();

            #endregion Update: RunAs Profile Wizard - General Properties


            #region Update: RunAs Profile Wizard - RunAs Accounts

            int index = 0;

            foreach (RunAsProfileParameters.AccountAssociationInfo account in parameters.accountInfoList)
            {
                switch (parameter)
                {
                    case UpdateParameter.Add:
                        this.AddARunAsAccount(account.AccountName, account.TargetName, account.TargetType);
                        break;

                    case UpdateParameter.Delete:
                        switch (account.AccountName)
                        {
                            // Wildcard means we should remove all RunAs accounts.
                            case "*":
                                this.DeleteAllRunAsAccounts();
                                break;

                            default:
                                this.DeleteARunAsAccount(account.AccountName, account.TargetName, account.TargetType);
                                break;
                        }
                        break;

                    case UpdateParameter.Edit:
                        RunAsProfileParameters.AccountAssociationInfo newAccount =
                            parameters.newAccountInfoList[index];
                        this.EditARunAsAccount(account.AccountName,
                            account.TargetName,
                            account.TargetType,
                            newAccount.TargetName,
                            newAccount.TargetType);
                        break;

                    default:
                        throw new Maui.GlobalExceptions.InvalidEnumValueException("Unknown Value: " + parameter);
                }

                ++index; // increment the index used to get the new account info
            }

            Utilities.LogMessage("RunAsProfile.Create :: Click Save Buttion.");

            // Click Create
            UIUtilities.SetControlValue(this.associationsProperties.Controls.CreateButton);

            try
            {
                // TODO: Add code to verify that the spinney image and progress text is displayed.
                consoleApp.Waiters.WaitForObjectPropertyChanged(this.runAsProfileWizardCompletionPage.Controls.CloseButton, "@Caption", Constants.OneMinute);
                Utilities.LogMessage("RunAsProfile.Create :: Successfully created a new run as profile.");

                #endregion Update: RunAs Profile Wizard - RunAs Accounts

                #region Update: RunAs Profile Wizard - Completion Page

            }
            catch (Exception ex)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMinutes(1));
            }
            finally
            {
                UIUtilities.SetControlValue(this.runAsProfileWizardCompletionPage.Controls.CloseButton);
            }
            

            #endregion Update: RunAs Profile Wizard - Completion Page
        }

        /// <summary>
        /// Create a new Run as Profile (v3 R2 and later)
        /// </summary>
        /// <param name="parameters">RunAsProfileParameters</param>
        /// <history>
        ///     [sharatja] 08Aug08 - Created        
        /// </history>
        /// <exception cref="ArgumentNullException">Thrown when any of the required values in RunAsProfileParameters is NULL or EMPTY</exception>
        public void Create(RunAsProfileParameters parameters)
        {
            LaunchRunAsProfileWizard();

            #region RunAs Profile Wizard - Introduction Page
            // TODO: Add logic to check the "DoNotShowAgain" checkbox.
            // Add check to make sure the Intro page is actally displayed.
            UIUtilities.SetControlValue(this.introductionDialog.Controls.NextButton);//this.introductionDialog.ClickNext();

            #endregion

            #region RunAs Profile Wizard - General Properties Page

            if (!String.IsNullOrEmpty(parameters.DisplayName))
            {
                Utilities.LogMessage("RunAsProfile.Create :: Display Name to be set is: " + parameters.DisplayName);
                UIUtilities.SetControlValue(this.generalProperties.Controls.DisplayNameTextBox, parameters.DisplayName);//this.generalProperties.DisplayNameText = parameters.DisplayName;
                Utilities.LogMessage("RunAsProfile.Create :: Display Name is set to : " + this.generalProperties.DisplayNameText);
            }
            else
            {
                Utilities.LogMessage("RunAsProfile.Create :: Display Name is a required fielsd it cannot be Null");
                throw new ArgumentNullException("Display Name is Null");
            }

            if (parameters.Description != null)
            {
                Utilities.LogMessage("RunAsProfile.Create :: Description to be set is : " + parameters.Description);
                UIUtilities.SetControlValue(this.generalProperties.Controls.DescriptionTextBox, parameters.Description);//this.generalProperties.DescriptionText = parameters.Description;
                Utilities.LogMessage("RunAsProfile.Create :: Set Description to : " + this.generalProperties.DescriptionText);
            }

            if (parameters.DestinationMP != null)
            {
                Utilities.LogMessage("RunAsProfile.Create :: Destination MP to be set is : " + parameters.DestinationMP);
                UIUtilities.SetControlValue(this.generalProperties.Controls.SelectDestinationManagementPackComboBox, parameters.DestinationMP); //this.generalProperties.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.DestinationMP);
                Utilities.LogMessage("RunAsProfile.Create :: Successfully Set Destination MP");
            }

            //Not removing the Class parameter incase the UI design is changed again
            if (parameters.Class != null)
            {
                Utilities.LogMessage("RunAsProfile.Create :: New Class to be selected is : " + parameters.Class);
                Utilities.LogMessage("RunAsProfile.Create :: Selecting class is not supported anymore from UI hence ignoring this parameter");
            }

            Utilities.LogMessage("RunAsProfile.Create :: Clicking on Next button");
            UIUtilities.SetControlValue(this.generalProperties.Controls.NextButton);//this.generalProperties.ClickNext();

            #endregion RunAs Profile Wizard - General Properties Page

            #region RunAs Profile Wizard - RunAs Accounts Page

            // Add the RunAs account 
            // parameters.TargetComputerAccountPairs
            //  Key = target
            //  Value = account name
            foreach (string target in parameters.TargetComputerAccountPairs.Keys)
            {
                this.AddARunAsAccount(parameters.TargetComputerAccountPairs[target].ToString(),
                    target,
                    parameters.TargetType);
            }

            // Click Create
            UIUtilities.SetControlValue(this.associationsProperties.Controls.CreateButton);
            consoleApp.Waiters.WaitForObjectPropertyChanged(this.runAsProfileWizardCompletionPage.Controls.CloseButton, "@Caption", PropertyOperator.Equals, "Close",Constants.OneMinute * 2);
            // TODO: Add code to verify that the spinney image and progress text is displayed.                      

            Utilities.LogMessage("RunAsProfile.Create :: Successfully created a new run as profile.");

            #endregion RunAs Profile Wizard - RunAs Accounts Page

            #region RunAs Profile Wizard - Completion Page

            UIUtilities.SetControlValue(this.runAsProfileWizardCompletionPage.Controls.CloseButton);//this.runAsProfileWizardCompletionPage.ClickClose();

            #endregion RunAs Profile Wizard - Completion Page
        }

        /// <summary>
        /// Delete a particular RunAsProfile
        /// </summary>
        /// <param name="name">name</param>          
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>         
        /// <history>
        ///     [ruhim] 21APR06 - Created        
        /// </history>
        //<exception cref="Maui.Core.WinControls.DataGrid.Exceptions.WindowNotFoundException">WindowNotFoundException</exception>
        public void Delete(string name)
        {
            //Navigate to the RunAsProfile Node under Administration
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.SelectNode(RunAsProfilePath, NavigationPane.NavigationTreeView.Administration);
            Utilities.LogMessage("RunAsProfile.Delete :: Selected Node '" + NavigationPane.Strings.AdminTreeViewRunAsProfiles);

            consoleApp.Waiters.WaitForReady();

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            DataGridViewRow runAsProfileRow = null;
            if (viewGrid != null)
            {
                runAsProfileRow = viewGrid.FindData(name, Strings.ViewColumnNameHeader, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
                if (runAsProfileRow != null)
                {
                    Utilities.LogMessage("RunAsProfile.Delete :: Found the row : " + name);
                    viewGrid.ScrollToRow(runAsProfileRow.AccessibleObject.Index);
                    runAsProfileRow.AccessibleObject.Click();
                    Utilities.LogMessage("RunAsProfile.Delete :: Successfully clicked on the row");

                    Menu rowContextMenu = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
                    rowContextMenu.ScreenElement.WaitForReady();

                    Utilities.LogMessage("RunAsProfile.Delete :: Constructor for Menu called");
                    rowContextMenu.ExecuteMenuItem(ViewPane.Strings.AdministrationContextMenuDelete);
                    Utilities.LogMessage("RunAsProfile.Delete :: Successfully clicked on the context menu: "
                        + ViewPane.Strings.AdministrationContextMenuDelete);
                }
                else
                {
                    Utilities.LogMessage("RunAsProfile.Delete :: Run as Profile row " + name + " not found");
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("Run as Profile row not found to be deleted");
                }
            }
            else
            {
                Utilities.LogMessage("RunAsProfile.Delete :: Run as Profile View grid not found");
                throw new DataGrid.Exceptions.WindowNotFoundException("Failed to find ViewGrid");
            }

            //select Yes on the delete confirmation dialog
            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes, Strings.ConfirmDeleteDialogTitle, StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);
            Utilities.LogMessage("RunAsProfile.Delete :: Succesfully deleted the Run as Account");
            consoleApp.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
            //Adding this method to fix a timing issue with hour glass showing up 
            //after deletion and all other wait loops failed to wait enough
            consoleApp.Waiters.WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType.Wait, 240);
            Sleeper.Delay(Core.Common.Constants.OneSecond);
        }

        /// <summary>
        /// Opens the properties dialog for a given run as profile
        /// </summary>
        public void OpenPropertiesDialog(string profileName)
        {
            Utilities.LogMessage("RunAsProfile.OpenPropertiesDialog :: Opening properties dialog for profile with display name - " + profileName);

            # region Navigate To Run as Profiles Node

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            TreeNode runAsProfileNode = navPane.SelectNode(RunAsProfilePath, NavigationPane.NavigationTreeView.Administration);
            Utilities.LogMessage("RunAsProfile.OpenPropertiesDialog :: Selected Node '" + NavigationPane.Strings.AdminTreeViewRunAsProfiles);

            consoleApp.Waiters.WaitForReady();

            #endregion

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            DataGridViewRow runAsProfileRow = null;
            if (viewGrid != null)
            {
                runAsProfileRow = viewGrid.FindData(profileName, Strings.ViewColumnNameHeader, MomControls.GridControl.SearchStringMatchType.ExactMatch);
                if (runAsProfileRow != null)
                {
                    Utilities.LogMessage(String.Format(CultureInfo.CurrentUICulture, "RunAsProfile.OpenPropertiesDialog :: Found the row : '{0}'", profileName));
                    viewGrid.ScrollToRow(runAsProfileRow.AccessibleObject.Index);
                    runAsProfileRow.AccessibleObject.Click();
                    Utilities.LogMessage("RunAsProfile.OpenPropertiesDialog :: Successfully clicked on the row");

                    Menu rowContextMenu = new Menu(ContextMenuAccessMethod.ShiftF10);
                    rowContextMenu.ScreenElement.WaitForReady();

                    Utilities.LogMessage("RunAsProfile.OpenPropertiesDialog :: Constructor for Menu called");
                    rowContextMenu.ExecuteMenuItem(ViewPane.Strings.AdministrationContextMenuProperties);
                    Utilities.LogMessage("RunAsProfile.OpenPropertiesDialog :: Successfully clicked on the context menu: "
                        + ViewPane.Strings.AdministrationContextMenuProperties);
                }
                else
                {
                    Utilities.LogMessage(String.Format(CultureInfo.CurrentUICulture, "RunAsProfile.OpenPropertiesDialog :: Run as Profile row '{0}' not found!", profileName));
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("Run as Profile row not found!");
                }
            }
            else
            {
                Utilities.LogMessage("RunAsProfile.OpenPropertiesDialog :: Run as Profile View grid not found");
                throw new DataGrid.Exceptions.WindowNotFoundException("Failed to find ViewGrid");
            }
        }

        /// <summary>
        /// Launches the RunAs Profile Wizard for a new profile.
        /// </summary>
        public void LaunchRunAsProfileWizard()
        {
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            TreeNode runAsProfileNode = navPane.SelectNode(RunAsProfilePath, NavigationPane.NavigationTreeView.Administration);
            Utilities.LogMessage("LaunchRunAsProfileWizard :: Selected Node '" + NavigationPane.Strings.AdminTreeViewRunAsProfiles);

            consoleApp.Waiters.WaitForReady();

            Utilities.LogMessage(String.Format(CultureInfo.CurrentCulture, "LaunchRunAsProfileWizard :: Clicking on the context menu: '{0}'", Strings.CreateRunAsProfileContextMenu));
            runAsProfileNode.ContextMenu.ExecuteMenuItem(Strings.CreateRunAsProfileContextMenu);
            Utilities.LogMessage(String.Format(CultureInfo.CurrentCulture, "LaunchRunAsProfileWizard :: Successfully clicked on the context menu: '{0}'", Strings.CreateRunAsProfileContextMenu));
        }

        /// <summary>
        /// Launches the RunAs Profile Wizard for an existing profile.
        /// </summary>
        /// <param name="profileName"></param>
        public void LaunchRunAsProfileWizard(string profileName)
        {
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.SelectNode(RunAsProfilePath, NavigationPane.NavigationTreeView.Administration);
            Utilities.LogMessage("RunAsProfile.LaunchRunAsProfileWizard :: Selected Node '" + NavigationPane.Strings.AdminTreeViewRunAsProfiles);

            consoleApp.Waiters.WaitForReady();

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            DataGridViewRow runAsProfileRow = null;
            if (viewGrid != null)
            {
                // Added some retry to make sure we can find updated profile SM# 164121
                consoleApp.Waiters.WaitForConditionCheckSuccess(delegate()
                {
                    //Refresh the datagrid after rename it, then the new profile name will be reflected.
                    viewGrid.Extended.SetFocus();
                    viewGrid.SendKeys(KeyboardCodes.F5);

                    return (runAsProfileRow=viewGrid.FindData(profileName, Strings.ViewColumnNameHeader, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch)) != null;
                });

                int retrySelectCount = 0;
            SelectRunAsProfileRow:
                viewGrid.ScrollToRow(runAsProfileRow.AccessibleObject.Index);
                runAsProfileRow.AccessibleObject.Click();

                // Added some retry if we did not actually click the correct cell SM# 162949
                int retrySelect = 0;
                while (!runAsProfileRow.AccessibleObject.Selected && retrySelect < 3)
                {
                    // Wait 5 seconds and try to Click the correct cell again
                    Sleeper.Delay(Constants.DefaultContextMenuTimeout);
                    viewGrid.ScrollToRow(runAsProfileRow.AccessibleObject.Index);
                    runAsProfileRow.AccessibleObject.Click();
                    retrySelect++;
                }

                if (runAsProfileRow.AccessibleObject.Selected)
                {
                    Utilities.LogMessage("RunAsProfile.LaunchRunAsProfileWizard :: Successfully clicked on the row");
                }
                else
                {
                    Utilities.LogMessage("RunAsProfile.LaunchRunAsProfileWizard :: We did not successfully click on the Correct row!");
                    Utilities.TakeScreenshot("RunAsProfileNotClicked");

                    // In this condition, the row may be masked by the horizontal scroll bar, below is the workaround fix
                    if (runAsProfileRow.AccessibleObject.Index < viewGrid.Rows.Count)
                    {
                        Utilities.LogMessage("Scroll to row which after the row "+profileName);
                        viewGrid.ScrollToRow(runAsProfileRow.AccessibleObject.Index + 1);
                        // Suppose the row should be visible now
                        Utilities.TakeScreenshot("IsRunAsProfileVisibleNow");
                        runAsProfileRow.AccessibleObject.Click();
                    }

                    if (!runAsProfileRow.AccessibleObject.Selected)
                    {
                        Utilities.LogMessage("Run as profile "+profileName +" still not visible after the workaround fix");
                        Utilities.LogMessage("RunAsProfileStillNotVisible");
                        throw new DataGrid.Exceptions.DataGridRowNotFoundException("Fail to click on the Correct row!");
                    }
                }
                viewGrid.ScreenElement.WaitForReady();

                Menu rowContextMenu = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
                rowContextMenu.ScreenElement.WaitForReady();
                Utilities.LogMessage("RunAsProfile.LaunchRunAsProfileWizard :: Constructor for Menu called");

                if (!new MenuItem(rowContextMenu, ViewPane.Strings.AdministrationContextMenuProperties).Enabled)
                {
                    if (retrySelectCount++ == Constants.DefaultMaxRetry)
                    {
                        Utilities.TakeScreenshot("MenuItemStillDisabledAfterRetrySelectRunAsProfileRow");
                        throw new Exception("Tried " + retrySelect + " times to reselect runas profile row "+profileName+", but menu item " + ViewPane.Strings.AdministrationContextMenuProperties + " is still disabled");
                    }
                    goto SelectRunAsProfileRow;
                }

                rowContextMenu.ExecuteMenuItem(ViewPane.Strings.AdministrationContextMenuProperties);
                Utilities.LogMessage("RunAsProfile.LaunchRunAsProfileWizard :: Successfully clicked on the context menu: "
                    + ViewPane.Strings.AdministrationContextMenuProperties);
            }
            else
            {
                Utilities.LogMessage("RunAsProfile.LaunchRunAsProfileWizard :: Run as Profile View grid not found");
                throw new DataGrid.Exceptions.WindowNotFoundException("Failed to find ViewGrid");
            }
        }

        /// <summary>
        /// Opens the picker dialog based on the target type for a given profile.
        /// Assumes that the property dialog for the run as profile is already open.
        /// </summary>
        /// <param name="type"></param>
        public void OpenPickerDialog(TargetType type)
        {
            // TODO: remove this code once we are sure it is no longer need post improvement #131241.
            //this.generalProperties.Controls.Tab0TabControl.Tabs[INDEX_TAB_ASSOCIATIONS].Select();
            //UISynchronization.WaitForUIObjectReady(this.associationsProperties, Constants.DefaultDialogTimeout);
            this.addARunAsAccountDialog.Controls.ASelectedClassGroupOrObjectRadioButton.Click();
            this.addARunAsAccountDialog.Controls.SelectButton.Click();
            UISynchronization.WaitForUIObjectReady(this.associationsProperties, Constants.DefaultDialogTimeout);

            string sResName = String.Empty;

            switch (type)
            {
                case TargetType.Group:
                    sResName = Strings.GroupMenuItem;
                    break;
                case TargetType.Object:
                    sResName = Strings.ObjectMenuItem;
                    break;
                case TargetType.Class:
                default:
                    sResName = Strings.ClassMenuItem;
                    break;
            }

            // Add re-try logic to fix the timing issue of System.ArgumentOutOfRangeException when clicking the toolbar. 
            
            Menu toolbarContextMenu = new Menu(Constants.DefaultContextMenuTimeout);
            toolbarContextMenu.ExecuteMenuItem(sResName);
            Utilities.LogMessage("OpenPickerDialog :: Clicked Context Menu '" + sResName + "'");
        }

        /// <summary>
        /// Add a RunAs account to a RunAs profile
        /// </summary>
        /// <param name="accountName">RunAs account name</param>
        /// <param name="targetName">RunAs account target name</param>
        /// <param name="type">target type</param>
        public void AddARunAsAccount(string accountName, string targetName, TargetType type)
        {
            AddEditDeleteARunAsAccount(accountName,
                targetName,
                type,
                null,
                TargetType.Default,
                "Add");
        }

        /// <summary>
        /// Edit a RunAs account to a RunAs profile
        /// </summary>
        /// <param name="accountName">RunAs account name</param>
        /// <param name="targetName">RunAs account target name</param>
        /// <param name="type">target type</param>
        /// <param name="newTargetName">New RunAs account name</param>
        /// <param name="newType">New target type</param>
        public void EditARunAsAccount(string accountName, 
            string targetName, 
            TargetType type, 
            string newTargetName, 
            TargetType newType)
        {
            AddEditDeleteARunAsAccount(accountName,
                targetName,
                type,
                newTargetName,
                newType,
                "Edit");
        }

        /// <summary>
        /// Deletes a RunAs account from a RunAs profile
        /// </summary>
        /// <param name="accountName">RunAs account name</param>
        /// <param name="targetName">RunAs account target name</param>
        /// <param name="type">target type</param>
        public void DeleteARunAsAccount(string accountName, string targetName, TargetType type)
        {
            AddEditDeleteARunAsAccount(accountName,
                targetName,
                type,
                null,
                TargetType.Default,
                "Delete");
        }

        /// <summary>
        /// Deletes all RunAs accounts from a RunAs profile
        /// </summary>
        public void DeleteAllRunAsAccounts()
        {
            // Passing a wildcard character '*' when calling with the 'Delete' option
            // will delete all RunAs accounts in the profile. Since we are deleting all
            // accounts the only the accountName (*) and the delete operation are used
            // all other parameters are ignored.
            AddEditDeleteARunAsAccount("*",
                null,
                TargetType.Default,
                null,
                TargetType.Default,
                "Delete");
        }

        /// <summary>
        /// Deletes all RunAs accounts from a RunAs profile
        /// </summary>
        public bool VerifyDeleteRunAsAccounts(RunAsProfileParameters parameters)
        {            
            bool deleteFlag =true;

            LaunchRunAsProfileWizard(parameters.SearchName);
            //Do nothing on the Introduction Dialog
            IntroductionDialog introductionDialog= new IntroductionDialog(CoreManager.MomConsole);

            UIUtilities.SetControlValue(introductionDialog.Controls.NextButton); //introductionDialog.ClickNext();

            //Do nothing on the General Properties Dialog
            GeneralProperties generalProperties = new GeneralProperties(CoreManager.MomConsole);

            UIUtilities.SetControlValue(generalProperties.Controls.NextButton); //generalProperties.ClickNext();

            //Verify the accounts are deleted on the RunAsAccount Dialog
            RunasAccountsDialog runasAccountsDialog = new RunasAccountsDialog(CoreManager.MomConsole);
            
            AssociationsProperties assciationsProperties = new AssociationsProperties(CoreManager.MomConsole);

            //verify the accounts are deleted
            foreach (RunAsProfileParameters.AccountAssociationInfo account in parameters.accountInfoList)
            {
                ListViewItem item = associationsProperties.FindRunAsAccount(account.AccountName, account.TargetName, account.TargetType);
                if (item != null)
                {
                    deleteFlag = false; 
                    break;
                }                                   
            }

            CoreManager.MomConsole.CancelDialogWindow(runasAccountsDialog);
            Sleeper.Delay(Core.Common.Constants.OneSecond);

            return deleteFlag;
        }

        /// <summary>
        /// Adds a RunAs account and targets this account for a RunAs profile.
        /// Assumes the following: 
        ///     RunAs Profile Wizard is open and the RunAs Accounts page is selected.
        ///     
        ///     Note: Passing a wildcard character '*' when calling with the 'Delete' option
        ///     will delete all RunAs accounts in the profile.
        /// </summary>
        /// <param name="accountName">RunAs account name</param>
        /// <param name="targetName">Target name</param>
        /// <param name="targetType">Target type</param>
        /// <param name="newTargetName">New Target name</param>
        /// <param name="newTargetType">New Target type</param>
        /// <param name="operation">Add, Edit, Delete</param>
        private void AddEditDeleteARunAsAccount(string accountName,
            string targetName,
            TargetType targetType,
            string newTargetName,
            TargetType newTargetType,
            string operation)
        {
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            string toolbarItemText = String.Empty;
            TargetType targetTypeToAdd = TargetType.Default;
            string targetNameToAdd = String.Empty;

            try
            {
                Utilities.LogMessage(methodName + " :: " + operation + " RunAs Account '" + accountName + "'");

                switch (operation)
                {
                    case "Add":
                        this.associationsProperties.ClickToolbarItem(Utilities.RemoveAcceleratorKeys(Strings.AddButton));
                        this.addARunAsAccountDialog.Controls.AccountDistributionComboBox.SelectByText(accountName, true);
                        targetNameToAdd = targetName;
                        targetTypeToAdd = targetType;
                        break;

                    case "Edit":
                        this.associationsProperties.SelectRunAsAccount(accountName,
                            targetName,
                            targetType);
                        this.associationsProperties.ClickToolbarItem(Utilities.RemoveAcceleratorKeys(Strings.EditButton));
                        targetNameToAdd = targetName;
                        targetTypeToAdd = targetType;
                        break;

                    case "Delete":                        
                            switch (accountName)
                            {
                                case "*":
                                    // below debug info added for fixing bug # 209223
                                    //remove all accounts
                                    Utilities.TakeScreenshot("SelectAllRunAsAccounts_before");
                                    Utilities.LogMessage(methodName+":: Select all run as accounts");
                                    this.associationsProperties.SelectAllRunAsAccounts();
                                    Utilities.TakeScreenshot("SelectAllRunAsAccounts_after");

                                    Utilities.LogMessage(methodName+":: Click remove button on tool bar");
                                    this.associationsProperties.ClickToolbarItem(Utilities.RemoveAcceleratorKeys(Strings.RemoveButton));
                                    Utilities.TakeScreenshot("ClickToolbarItem_RemoveButtonClicked");
                                        
                                    //Wait for all accounts are removed     
                                    consoleApp.Waiters.WaitForObjectPropertyChangedSafe(this.associationsProperties.Controls.RunAsAccountsListView,"@Count", PropertyOperator.Equals, 0);

                                    Utilities.TakeScreenshot("AllAccountsAreRemovedVerified");

                                    break;                                                                       

                                default:    
                                    //remove account
                                    this.associationsProperties.SelectRunAsAccount(accountName, targetName, targetType);
                                    this.associationsProperties.ClickToolbarItem(Utilities.RemoveAcceleratorKeys(Strings.RemoveButton));

                                    //Wait for account is removed
                                    consoleApp.Waiters.WaitForConditionCheckSuccess(delegate() { return this.associationsProperties.FindRunAsAccount(accountName, targetName, targetType) == null; });
      
                                    break;                         
                            }                     
                        return;

                    default:
                        throw new Maui.GlobalExceptions.InvalidEnumValueException("Unknown operation: " + operation);
                }

                // Add or Edit Only: Select Target Scope
                switch (targetTypeToAdd)
                {   
                    case TargetType.Class:
                        #region Select Class
                        
                        this.addARunAsAccountDialog.Controls.ASelectedClassGroupOrObjectRadioButton.ButtonState =
                            ButtonState.Checked;
                        
                        this.OpenPickerDialog(TargetType.Class);
                        this.ClassSearchDialog.Controls.GeneralPropertiesTextBox.Text = targetName;
                        this.ClassSearchDialog.ClickSearch();

                        UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout * 2);
                        consoleApp.Waiters.WaitForReady();
                        ClassSearchDialog.ScreenElement.WaitForReady();
                        ListViewItemCollection classes = this.ClassSearchDialog.Controls.AvailableItemsListView.Items;

                        foreach (ListViewItem myClass in classes)
                        {
                            Utilities.LogMessage(methodName + " :: found class: name '" + myClass.Text +
                                "' management pack '" + myClass.SubItems[0].Text + "'");

                            // match on class name
                            if (myClass.Text.Equals(targetName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                myClass.Select();
                            }
                        }

                        consoleApp.Waiters.WaitForObjectPropertyChanged(this.ClassSearchDialog.Controls.OKButton, "@IsEnabled", PropertyOperator.Equals,true);
                        this.ClassSearchDialog.ClickOK();
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addARunAsAccountDialog.Controls.OKButton,Constants.OneMinute);
                        this.addARunAsAccountDialog.ClickOK();
                        break;
                        
                        #endregion Select Class

                    case TargetType.Group:
                        #region Select Group

                        UIUtilities.SetControlValue(this.addARunAsAccountDialog.Controls.ASelectedClassGroupOrObjectRadioButton,true);
                          
                        this.OpenPickerDialog(TargetType.Group);
                        this.GroupSearchDialog.Controls.TextFilterTextBox.Text = targetName;
                        Utilities.LogMessage(methodName + " :: Start Search...");
                        this.GroupSearchDialog.ClickSearch();

                        Utilities.LogMessage(methodName + " :: Wait for Search completed..");

                        UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout * 2);
                        consoleApp.Waiters.WaitForReady();
                        GroupSearchDialog.ScreenElement.WaitForReady();

                        consoleApp.Waiters.WaitForButtonEnabled(this.GroupSearchDialog.Controls.SearchButton, Constants.DefaultDialogTimeout * 2);

                        ListViewItemCollection groups = this.GroupSearchDialog.Controls.GroupsListView.Items;

                        foreach (ListViewItem myGroup in groups)
                        {
                            Utilities.LogMessage(methodName + " :: found group: name '" + myGroup.Text +
                                "' management pack '" + myGroup.SubItems[0].Text + "'");

                            // match on group name
                            if (myGroup.Text.Equals(targetName, StringComparison.InvariantCultureIgnoreCase))
                            {                                
                                myGroup.Select();                                                              
                            }
                        }

                        consoleApp.Waiters.WaitForButtonEnabled(this.GroupSearchDialog.Controls.OKButton, Constants.DefaultDialogTimeout * 2);

                        consoleApp.Waiters.WaitForObjectPropertyChanged(this.GroupSearchDialog.Controls.OKButton, "@IsEnabled", PropertyOperator.Equals, true);
                        this.GroupSearchDialog.ClickOK();

                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addARunAsAccountDialog.Controls.OKButton, Constants.OneMinute);
                        addARunAsAccountDialog.ScreenElement.WaitForReady();
                        this.addARunAsAccountDialog.ClickOK();
                        break;

                        #endregion Select Group

                    case TargetType.Object:
                        #region Select Object

                        this.addARunAsAccountDialog.Controls.ASelectedClassGroupOrObjectRadioButton.ButtonState =
                            ButtonState.Checked;
                        // Select Object
                        this.OpenPickerDialog(TargetType.Object);
                        this.ObjectSearchDialog.FilterByText = targetName;
                        this.ObjectSearchDialog.ClickSearch();

                        UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout * 2);
                        consoleApp.Waiters.WaitForReady();

                        ListViewItemCollection objects = this.ObjectSearchDialog.Controls.AvailableItemsListView.Items;

                        foreach (ListViewItem myObject in objects)
                        {
                            Utilities.LogMessage(methodName + " :: found object: name '" + myObject.Text +
                                "' management pack '" + myObject.SubItems[0].Text + "'");

                            // match on object name
                            if (myObject.Text.Equals(targetName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                myObject.Select();
                            }
                        }
                        Utilities.LogMessage(methodName + " ::Click Add...");
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                        this.ObjectSearchDialog.Controls.AddButton,
                        Core.Common.Constants.DefaultDialogTimeout);
                        this.ObjectSearchDialog.ClickAdd();
                        // Make sure the UI is ready
                        this.ObjectSearchDialog.ScreenElement.WaitForReady();

                        consoleApp.Waiters.WaitForObjectPropertyChanged(this.ObjectSearchDialog.Controls.OKButton, "@IsEnabled", PropertyOperator.Equals,true);
                        this.ObjectSearchDialog.ClickOK();

                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addARunAsAccountDialog.Controls.OKButton, Constants.OneMinute);
                        this.addARunAsAccountDialog.ClickOK();
                        break;

                        #endregion Select Object

                    case TargetType.All:
                        this.addARunAsAccountDialog.Controls.AllObjectsManagedByThisRunAsProfileRadioButton.ButtonState =
                            ButtonState.Checked;
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addARunAsAccountDialog.Controls.OKButton, Constants.OneMinute);
                        this.addARunAsAccountDialog.ClickOK();
                        break;

                    // Else do not select an option as the default should be selected.
                    default:
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addARunAsAccountDialog.Controls.OKButton, Constants.OneMinute);
                        this.addARunAsAccountDialog.ClickOK();
                        break;
                }
            }
            catch (Maui.Core.WinControls.ComboBox.Exceptions.TextNotFoundException)
            {
                throw new Maui.Core.WinControls.ComboBox.Exceptions.TextNotFoundException("RunAs account '" + 
                    accountName + "' not found");
            }
        }

        /// <summary>
        /// Adds test targets of a given target type.
        /// Assumes that the appropriate picker dialog is open and the search has already been performed.
        /// </summary>
        /// <param name="type"></param>
        public void AddTestTarget(TargetType type)
        {
            switch (type)
            {
                case TargetType.Group:
                    /*
                    if (this.GroupSearchDialog.Controls.GroupsListView.Items.Count == 0)
                    {
                        throw new Maui.GlobalExceptions.MauiException("No results were returned for the given filter.");
                    }
                    ListViewItemCollection = this.GroupSearchDialog.Controls.GroupsListView.FindAllByText("targetName");
                    this.GroupSearchDialog.Controls.GroupsListView.FindAllByText .AvailableItemsListView.MultiSelect(new int[] { 0 });
                    this.GroupSearchDialog.ClickAdd();
                    UISynchronization.WaitForUIObjectReady(this.GroupSearchDialog.Controls.SelectedItemsListView, Constants.DefaultContextMenuTimeout);
                    this.GroupSearchDialog.ClickOK();*/
                    break;
                case TargetType.Object:
                    /*
                    if (this.ObjectSearchDialog.Controls.AvailableItemsListView.Items.Count == 0)
                    {
                        throw new Maui.GlobalExceptions.MauiException("No results were returned for the given filter.");
                    }

                    this.ObjectSearchDialog.Controls.AvailableItemsListView.MultiSelect(new int[] { 0 });
                    this.ObjectSearchDialog.ClickAdd();
                    UISynchronization.WaitForUIObjectReady(this.ObjectSearchDialog.Controls.SelectedItemsListView, Constants.DefaultContextMenuTimeout);
                    this.ObjectSearchDialog.ClickOK();*/
                    break;
                case TargetType.Class:
                    /*
                    if (this.ClassSearchDialog.Controls.AvailableItemsListView.Items.Count == 0)
                    {
                        throw new Maui.GlobalExceptions.MauiException("No results were returned for the given filter.");
                    }

                    this.ClassSearchDialog.Controls.AvailableItemsListView.MultiSelect(new int[] { 0 });
                    this.ClassSearchDialog.ClickAdd();
                    UISynchronization.WaitForUIObjectReady(this.ClassSearchDialog.Controls.SelectedItemsListView, Constants.DefaultContextMenuTimeout);
                    this.ClassSearchDialog.ClickOK();*/
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Performs search based on the target type
        /// </summary>
        /// <param name="type"></param>
        public void PerformSearch(TargetType type)
        {
            this.PerformSearch(type, String.Empty, String.Empty);
        }

        /// <summary>
        /// Performs search based on the target type and keyword filter
        /// </summary>
        /// <param name="type"></param>
        /// <param name="keywordFilter"></param>
        public void PerformSearch(TargetType type, string keywordFilter)
        {
            this.PerformSearch(type, keywordFilter, String.Empty);
        }

        /// <summary>
        /// Performs search based on the target type, keyword and combo box filters
        /// </summary>
        /// <param name="type">Target type of type TARGETTYPE</param>
        /// <param name="keywordFilter">String representing a keyword for filter</param>
        /// <param name="comboBoxFilter">String representing a filter for the combobox on the picker dialog</param>
        public void PerformSearch(TargetType type, string keywordFilter, string comboBoxFilter)
        {
            string logHeader = System.Reflection.MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader);
            Utilities.LogMessage(logHeader + String.Format(CultureInfo.InvariantCulture, "Type - '{0}'", type.ToString()));
            Utilities.LogMessage(logHeader + String.Format(CultureInfo.InvariantCulture, "Keyword - '{0}'", keywordFilter));
            Utilities.LogMessage(logHeader + String.Format(CultureInfo.InvariantCulture, "ComboBoxFilter - '{0}'", comboBoxFilter));

            try
            {
                switch (type)
                {
                    case TargetType.Group:
                        if (String.IsNullOrEmpty(comboBoxFilter))
                        {
                            this.GroupSearchDialog.Controls.MPFilterComboBox.SelectByText(Core.Console.Dialogs.ObjectSearchDialog.Strings.MPAny);
                            Utilities.LogMessage(logHeader + "Setting the MP Filter ComboBox to (Any).");
                        }
                        else
                        {
                            this.GroupSearchDialog.Controls.MPFilterComboBox.SelectByText(comboBoxFilter);
                        }

                        this.GroupSearchDialog.Controls.TextFilterTextBox.Extended.SetFocus();

                        if (!String.IsNullOrEmpty(this.GroupSearchDialog.Controls.TextFilterTextBox.Text))
                        {
                            this.GroupSearchDialog.Controls.TextFilterTextBox.Text = String.Empty;
                        }

                        if (!String.IsNullOrEmpty(keywordFilter))
                        {
                            this.GroupSearchDialog.Controls.TextFilterTextBox.SendKeys(keywordFilter);
                        }

                        this.GroupSearchDialog.ClickSearch();
                        Sleeper.Delay(Constants.DefaultDialogTimeout);
                        UISynchronization.WaitForUIObjectReady(this.GroupSearchDialog.Controls.GroupsListView, Constants.DefaultDialogTimeout * 2);

                        //Wait 'Search' button visible to make sure search is finished
                        consoleApp.Waiters.WaitForObjectPropertyChangedSafe(this.GroupSearchDialog.Controls.SearchButton, "@IsVisible", PropertyOperator.Equals, true);
                        
                        break;

                    case TargetType.Object:
                        if (String.IsNullOrEmpty(comboBoxFilter))
                        {
                            Utilities.LogMessage("RunAsProfile.PerformSearch :: Object Search Dialog: " + 
                                "Setting the Look For control to (Any)");
                            this.ObjectSearchDialog.Controls.LookForComboBox.SelectByText(
                                Core.Console.Dialogs.ObjectSearchDialog.Strings.MPAny);
                        }
                        else
                        {
                            this.ObjectSearchDialog.Controls.LookForComboBox.SelectByText(comboBoxFilter);
                        }

                        this.ObjectSearchDialog.Controls.FilterByTextBox.Extended.SetFocus();

                        if (!String.IsNullOrEmpty(this.ObjectSearchDialog.Controls.FilterByTextBox.Text))
                        {
                            this.ObjectSearchDialog.Controls.FilterByTextBox.SendKeys(String.Empty);
                        }

                        if (!String.IsNullOrEmpty(keywordFilter))
                        {
                            this.ObjectSearchDialog.Controls.FilterByTextBox.SendKeys(keywordFilter);
                        }

                        this.ObjectSearchDialog.ClickSearch();
                        Sleeper.Delay(Constants.DefaultDialogTimeout);
                        UISynchronization.WaitForUIObjectReady(this.ObjectSearchDialog.Controls.AvailableItemsListView, Constants.DefaultDialogTimeout * 2);

                        //Wait 'Search' button visible to make sure search is finished 
                        consoleApp.Waiters.WaitForObjectPropertyChangedSafe(this.ObjectSearchDialog.Controls.SearchButton, "@IsVisible", PropertyOperator.Equals, true);
                        consoleApp.Waiters.WaitForObjectPropertyChangedSafe(this.ObjectSearchDialog.Controls.AvailableItemsListView, "@Items.Count", PropertyOperator.GreaterThan, 0);
                                 
                        break;

                    case TargetType.Class:
                    default:
                        if (String.IsNullOrEmpty(comboBoxFilter))
                        {
                            this.ClassSearchDialog.Controls.CompletionComboBox.SelectByText(Core.Console.Dialogs.ObjectSearchDialog.Strings.MPAny);;
                            Utilities.LogMessage(logHeader + "Setting the MP Filter ComboBox to (Any).");
                        }
                        else
                        {
                            this.ClassSearchDialog.Controls.CompletionComboBox.SelectByText(comboBoxFilter);
                        }

                        this.ClassSearchDialog.Controls.GeneralPropertiesTextBox.Extended.SetFocus();

                        if (!String.IsNullOrEmpty(this.ClassSearchDialog.Controls.GeneralPropertiesTextBox.Text))
                        {
                            this.ClassSearchDialog.Controls.GeneralPropertiesTextBox.Text = String.Empty;
                        }

                        if (!String.IsNullOrEmpty(keywordFilter))
                        {
                            this.ClassSearchDialog.Controls.GeneralPropertiesTextBox.SendKeys(keywordFilter);
                        }

                        this.ClassSearchDialog.ClickSearch();
                        Sleeper.Delay(Constants.DefaultDialogTimeout);
                        UISynchronization.WaitForUIObjectReady(this.ClassSearchDialog.Controls.AvailableItemsListView, Constants.DefaultDialogTimeout * 2);
                       
                        //Wait 'Search' button visible to make sure search is finished
                        consoleApp.Waiters.WaitForObjectPropertyChangedSafe(this.ClassSearchDialog.Controls.SearchButton, "@IsVisible", PropertyOperator.Equals,true);
                       
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Utilities.TakeScreenshot("PerformSearch_" + type.ToString());
                Utilities.LogMessage(logHeader + "- END");
            }

            // Wait for the items to be loaded into the available items list view
            Sleeper.Delay(Constants.DefaultContextMenuTimeout);
        }

        /// <summary>
        /// Removes all the targets for a given run as profile
        /// </summary>
        /// <param name="displayName">Name of the RunAsProfile</param>
        public void RemoveAssociationTargets(string displayName)
        {
            this.RemoveAssociationTargets(displayName, null);
        }

        /// <summary>
        /// Removes each test target in the TARGETNAMES collection for a given run as profile
        /// </summary>
        /// <param name="displayName">Name of the RunAsProfile</param>
        /// <param name="targetNames">Collection of target names to be removed</param>
        public void RemoveAssociationTargets(string displayName, Collection<string> targetNames)
        {
            // Open the property dialog for the given profile
            this.OpenPropertiesDialog(displayName);

            // Goto the associations tab
            this.generalProperties.Controls.Tab0TabControl.Tabs[INDEX_TAB_ASSOCIATIONS].Select();
            UISynchronization.WaitForUIObjectReady(this.associationsProperties, Constants.DefaultDialogTimeout);

            // Click on the toolstrip containing the ADD and REMOVE buttons
            this.associationsProperties.Controls.ToolStrip1.AccessibleObject.Click();

            try
            {
                MomControls.GridControl gc = new MomControls.GridControl(this.associationsProperties, AssociationsProperties.ControlIDs.SelectedTargetsPropertyGridView);
                // If the TARGETNAMES collectoin is NULL, we assume that we want to delete all targets
                if (targetNames == null)
                {
                    Utilities.LogMessage("RemoveAssociationTargets :: Removing all targets.");

                    // Added to fix automation timing issue in 128678. 
                    gc.Extended.SetFocus();
                    gc.SendKeys(KeyboardCodes.Alt + "a");
                    this.associationsProperties.Controls.ToolStrip1.ToolbarItems[INDEX_BUTTON_REMOVE].Click();
                    UISynchronization.WaitForUIObjectReady(gc.Extended.AccessibleObject, Constants.DefaultContextMenuTimeout);

                    int rowCount = gc.Rows.Count;
                    int count = 1;

                    // The row where we can see the column names is a part of the ROWS collection
                    while (count < rowCount)
                    {
                        // Make sure the grid is set to focus. Bug fix of 128068. 
                        // Hit again automation timing issue in 128678, that the remove button click didn't delete the row. 
                        gc.Extended.SetFocus();
                        this.associationsProperties.Controls.ToolStrip1.ToolbarItems[INDEX_BUTTON_REMOVE].Click();
                        UISynchronization.WaitForUIObjectReady(gc.Extended.AccessibleObject, Constants.DefaultContextMenuTimeout);
                        count++;
                    }
                    Utilities.LogMessage("RemoveAssociationTargets :: All previously added targets are removed successfully.");
                }
                else
                {
                    foreach (string target in targetNames)
                    {
                        DataGridViewRow viewRow = gc.FindData(target, INDEX_COLUMN_NAME, GridControl.SearchStringMatchType.ExactMatch);
                        if (viewRow != null)
                        {
                            Utilities.LogMessage(String.Format(CultureInfo.InvariantCulture, "RemoveAssociationTargets :: Removing target {0}.", target));

                            // Target to be deleted exists in the grid control.
                            // Since we cant get the index of that item directly from grid control,
                            // we need to loop through all the items and match the item based on
                            // the NAME column. Once found, we have the index and hence we can scroll
                            // to that index and delete the target by clicking on the REMOVE button.
                            int count = 1;
                            while (count < gc.Rows.Count)
                            {
                                if (String.Equals(target, gc.Rows[count].Cells[INDEX_COLUMN_NAME].GetValue(), StringComparison.CurrentCultureIgnoreCase))
                                {
                                    gc.ScrollToRow(count);
                                    this.associationsProperties.Controls.ToolStrip1.ToolbarItems[INDEX_BUTTON_REMOVE].Click();
                                    break;
                                }
                                count++;
                            }
                        }
                        else
                        {
                            // Target to be deleted is not found
                            Utilities.LogMessage(String.Format(CultureInfo.InvariantCulture, "RemoveAssociationTargets :: Target {0} not found!.", target));
                            throw new DataGrid.Exceptions.DataGridRowNotFoundException(String.Format(CultureInfo.InvariantCulture, "Target '{0}' not found!.", target));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Utilities.TakeScreenshot("RunAsProfileUI_RemoveTestTargets");
                this.associationsProperties.ClickOK();

                Utilities.LogMessage("RemoveAssociationTargets :: Waiting on the property dialog to close.");
                CoreManager.MomConsole.WaitForDialogClose(this.associationsProperties, Constants.DefaultDialogTimeout / Constants.OneSecond);

                // Wait for the confirmation dialog to appear and click NO
                consoleApp.Waiters.WaitForReady();
            }
        }

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Run As Profile
        /// </summary>
        /// <history> 	
        ///   [ruhim]  26Apr06: Created. Added resource strings for Run as Profile 
        ///                     specific views       
        ///   [a-joelj] 03MAR09: Added resources for Add, Edit and Remove buttons for RAP Associations tab and corrected
        ///                      hard coded Group, Object and Class resources.
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants            
            
            /// <summary>
            /// Contains Resource string for:  Dialog Title for Delete Confirmation 
            /// </summary>            
            private const string ResourceConfirmDeleteDialogTitle =
                ";Confirm Run As Profile Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsProfileDeleteTitle";

            /// <summary>
            /// Contains Resource string for:  Dialog Title for Delete Confirmation 
            /// </summary>            
            private const string ResourceNoResultDialogTitle =
                ";No Results;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.AsyncSearchDialog.AsyncSearchResources;NoResultsTitle";

            /// <summary>
            /// Contains Resource string for:  Name Header for the Run As Account View
            /// </summary>            
            private const string ResourceViewColumnNameHeader =
                ";Name;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Name";
            
            /// <summary>
            /// Contains Resource string for:  Create Run As Profile Context Menu
            /// </summary>            
            private const string ResourceCreateRunAsProfileContextMenu =
                ";Create Run As &Profile..." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";CreateRunAsProfileMenu";

            /// <summary>
            /// Contains Resource string for:  Create Run As Profile Context Menu
            /// </summary>            
            private const string ResourceCompletion =
                ";Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsProfileDistributionPage";
            
            /// <summary>
            /// Contains Resource string for:  Select... when selecting a RunAsAccount in the 
            /// RunAsProfile Wizard Associations tab 
            /// </summary>            
            private const string ResourceRunAsAssociationSelectText = 
                ";Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAssociationSelectText";

            private const string ResourceGroupMenuItem =
                ";&Group...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AddAccountDialog;groupToolStripMenuItem.Text";

            private const string ResourceObjectMenuItem =
                ";&Object...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AddAccountDialog;objectToolStripMenuItem.Text";

            private const string ResourceClassMenuItem =
                ";C&lass...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AddAccountDialog;classToolStripMenuItem.Text";

            private const string ResourceGroupText =
                ";Group;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GroupText";

            private const string ResourceClassText =
                ";Class;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ClassText";

            private const string ResourceObjectText =
                ";Object;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ObjectText";

            /// <summary>
            /// Contains Resource string for: Add... button on Associations page
            /// </summary>   
            private const string ResourceAddButton =
                ";A&dd...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileAssociationsPage;addButton.Text";

            /// <summary>
            /// Contains Resource string for: Edit... button on Associations page
            /// </summary>  
            private const string ResourceEditButton =
                ";&Edit...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileAssociationsPage;editButton.Text";

            /// <summary>
            /// Contains Resource string for: Remove button on Associations page
            /// </summary>  
            private const string ResourceRemoveButton =
                ";&Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfileAssociationsPage;removeButton.Text";

            /// <summary>
            /// Contains the Resource ID for the Product Title
            /// </summary>
            private const string ResourceProductTitle = ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";

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
            /// Caches the translated resource string for:  Create Run As Profile Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateRunAsProfileContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Completion
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCompletion;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Group Menu item in associations tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResourceGroupMenuItem;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Object Menu item in associations tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResourceObjectMenuItem;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Class Menu item in associations tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResourceClassMenuItem;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Group text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResourceGroupText;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Object Text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResourceObjectText;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Class Text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResourceClassText;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add... button in associations tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit... button in associations tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove button in associations tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemoveButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Title for No Results dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoResultsDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select...
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsAssociationSelectText;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Systems Center Operations Manager R2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProductTitle;

            #endregion

            #region Properties 

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Group Menu Item in the Add a RunAs Account dialog
            /// </summary>
            /// <history>
            /// 	[nathd] 29JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupMenuItem
            {
                get
                {
                    if (cachedResourceGroupMenuItem == null)
                    {
                        cachedResourceGroupMenuItem = CoreManager.MomConsole.GetIntlStr(ResourceGroupMenuItem);
                    }
                    return cachedResourceGroupMenuItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Object Menu Item in the Add a RunAs Account dialog
            /// </summary>
            /// <history>
            /// 	[nathd] 29JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectMenuItem
            {
                get
                {
                    if (cachedResourceObjectMenuItem == null)
                    {
                        cachedResourceObjectMenuItem = CoreManager.MomConsole.GetIntlStr(ResourceObjectMenuItem);
                    }
                    return cachedResourceObjectMenuItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Class Menu Item in the Add a RunAs Account dialog
            /// </summary>
            /// <history>
            /// 	[nathd] 29JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClassMenuItem
            {
                get
                {
                    if (cachedResourceClassMenuItem == null)
                    {
                        cachedResourceClassMenuItem = CoreManager.MomConsole.GetIntlStr(ResourceClassMenuItem);
                    }
                    return cachedResourceClassMenuItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Group Text in the RunAs Profile Wizard
            /// </summary>
            /// <history>
            /// 	[nathd] 11MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupText
            {
                get
                {
                    if (cachedResourceGroupText == null)
                    {
                        cachedResourceGroupText = CoreManager.MomConsole.GetIntlStr(ResourceGroupText);
                    }
                    return cachedResourceGroupText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Object Text in the RunAs Profile Wizard
            /// </summary>
            /// <history>
            /// 	[nathd] 11MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectText
            {
                get
                {
                    if (cachedResourceObjectText == null)
                    {
                        cachedResourceObjectText = CoreManager.MomConsole.GetIntlStr(ResourceObjectText);
                    }
                    return cachedResourceObjectText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Class Text in the RunAs Profile Wizard
            /// </summary>
            /// <history>
            /// 	[nathd] 11MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClassText
            {
                get
                {
                    if (cachedResourceClassText == null)
                    {
                        cachedResourceClassText = CoreManager.MomConsole.GetIntlStr(ResourceClassText);
                    }
                    return cachedResourceClassText;
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
            /// Exposes access to Dialog Title for No Results dialog
            /// </summary>
            /// <history>
            /// 	[sharatja] 02SEP08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoResultsDialogTitle
            {
                get
                {
                    if ((cachedNoResultsDialogTitle == null))
                    {
                        cachedNoResultsDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceNoResultDialogTitle);
                    }
                    return cachedNoResultsDialogTitle;
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Create Run As Profile Context Menu
            /// </summary>
            /// <history>
            /// 	[ruhim] 30Oct06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateRunAsProfileContextMenu
            {
                get
                {
                    if ((cachedCreateRunAsProfileContextMenu == null))
                    {
                        cachedCreateRunAsProfileContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceCreateRunAsProfileContextMenu);
                    }
                    return cachedCreateRunAsProfileContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Lable Title Completion
            /// </summary>
            /// <history>
            /// 	[v-juli] 09Apr10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Completion
            {
                get
                {
                    if ((cachedCompletion == null))
                    {
                        cachedCompletion = CoreManager.MomConsole.GetIntlStr(ResourceCompletion);
                    }
                    return cachedCompletion;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Select...
            /// </summary>
            /// <history>
            /// 	[nathd] 27Jan09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsAssociationSelectText
            {
                get
                {
                    if ((cachedRunAsAssociationSelectText == null))
                    {
                        cachedRunAsAssociationSelectText = CoreManager.MomConsole.GetIntlStr(ResourceRunAsAssociationSelectText);
                    }
                    return cachedRunAsAssociationSelectText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Systems Center Operations Manager R2
            /// </summary>
            /// <history>
            /// 	[nathd] 27Jan09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProductTitle
            {
                get
                {
                    if ((cachedProductTitle == null))
                    {
                        cachedProductTitle = CoreManager.MomConsole.GetIntlStr(ResourceProductTitle);
                    }
                    return cachedProductTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Add... button in associations tab
            /// </summary>
            /// <history>
            /// 	[a-joelj] 03MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddButton
            {
                get
                {
                    if ((cachedAddButton == null))
                    {
                        cachedAddButton = CoreManager.MomConsole.GetIntlStr(ResourceAddButton);
                    }
                    return cachedAddButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Edit... button in associations tab
            /// </summary>
            /// <history>
            /// 	[a-joelj] 03MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EditButton
            {
                get
                {
                    if ((cachedEditButton == null))
                    {
                        cachedEditButton = CoreManager.MomConsole.GetIntlStr(ResourceEditButton);
                    }
                    return cachedEditButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Remove button in associations tab
            /// </summary>
            /// <history>
            /// 	[a-joelj] 03MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemoveButton
            {
                get
                {
                    if ((cachedRemoveButton == null))
                    {
                        cachedRemoveButton = CoreManager.MomConsole.GetIntlStr(ResourceRemoveButton);
                    }
                    return cachedRemoveButton;
                }
            }

            
            #endregion
        }
        #endregion        

        #region RunAsProfileParameters Class
        /// <summary>
        /// Parameters class for RunAsProfile constructors.
        /// </summary>
        /// <history>
        /// [ruhim] 25APR06 Created
        /// [nathd] 29JAN09 Added additional parameters to support RunAs Improvement #131241 (RC milestone)
        /// </history>
        public class RunAsProfileParameters
        {
            /// <summary>
            /// accountInfoList will contain account info for Adding and Deleting a RunAs Account 
            /// within a RunAs profile.
            /// </summary>
            public List<AccountAssociationInfo> accountInfoList = null;
            
            /// <summary>
            /// newAccountInfoList will contain account info for Editing a RunAs account within
            /// a RunAs profile. Pair the original account info in accountInfoList with
            /// new account info in the newAccountInfoList.
            /// </summary>
            public List<AccountAssociationInfo> newAccountInfoList = null;

            #region Private Members

            #region Account Association Info
            /// <summary>
            /// Class to encapsulate RunAs Account assocations within a RunAs Profile
            /// </summary>
            public class AccountAssociationInfo
            {
                private string cachedTargetName = null;
                private string cachedAccountName = null;
                private TargetType cachedTargetType = TargetType.Default;

                /// <summary>
                /// Default Constructor
                /// </summary>
                public AccountAssociationInfo()
                {
                }

                /// <summary>
                /// Constructor
                /// </summary>
                /// <param name="targetName">Target Name</param>
                /// <param name="accountName">RunAs Account Name</param>
                /// <param name="targetType">Target Type: Group/Class/Object</param>
                public AccountAssociationInfo(string targetName, string accountName, TargetType targetType)
                {
                    this.TargetName = targetName;
                    this.AccountName = accountName;
                    this.TargetType = targetType;
                }

                /// <summary>
                /// Name of the target where target is a Group/Class/Object
                /// </summary>
                public string TargetName
                {
                    get
                    {
                        return cachedTargetName;
                    }

                    set
                    {
                        cachedTargetName = value;
                    }
                }

                /// <summary>
                /// RunAs Account Name
                /// </summary>
                public string AccountName
                {
                    get
                    {
                        return cachedAccountName;
                    }

                    set
                    {
                        cachedAccountName = value;
                    }
                }

                /// <summary>
                /// Target Type: Group/Class/Object
                /// </summary>
                public TargetType TargetType
                {
                    get
                    {
                        return cachedTargetType;
                    }

                    set
                    {
                        cachedTargetType = value;
                    }
                }
            }

            #endregion Account Association Info

            private string cachedSearchName = null;
            private string cachedDisplayName = null;
            private string cachedDescription = null;
            private string cachedClass = null;
            //Defining Hashtable to store Runas Account and Health service pairs
            private Hashtable cachedTargetComputerAccountPairs = new Hashtable();
            private string cachedDestinationMP = null;
            private TargetType cachedTargetType;
           
            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public RunAsProfileParameters()
            {
                accountInfoList = new List<AccountAssociationInfo>();
                newAccountInfoList = new List<AccountAssociationInfo>();
            }
            #endregion

            #region Properties

            /// <summary>
            /// Name of Run as Profile as seen in the View Pane
            /// </summary>
            public string SearchName
            {
                get
                {
                    return this.cachedSearchName;
                }

                set
                {
                    this.cachedSearchName = value;
                }
            }

            /// <summary>
            /// Display Name of Run as Profile
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
            /// Description of Profile
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
            /// Associated Class for Run as Profile
            /// </summary>
            public string Class
            {
                get
                {
                    return this.cachedClass;
                }

                set
                {
                    this.cachedClass = value;
                }
            }

            /// <summary>
            /// Hashtable to store Run as Account and Target Computer pairs
            /// </summary>
            public Hashtable TargetComputerAccountPairs 
            {
                get
                {
                    return this.cachedTargetComputerAccountPairs;
                }

                set
                {
                    this.cachedTargetComputerAccountPairs.Add(value, value);
                }
            }

            /// <summary>
            /// Destination Management Pack
            /// </summary>
            public string DestinationMP
            {
                get
                {
                    return this.cachedDestinationMP;
                }

                set
                {
                    this.cachedDestinationMP = value;
                }
            }

            /// <summary>
            /// Target Type
            /// </summary>
            public TargetType TargetType
            {
                get
                {
                    return this.cachedTargetType;
                }

                set
                {
                    this.cachedTargetType = value;
                }
            }

            #endregion
        }

        #endregion

    } //end of class RunAsProfile

    /// <summary>
    /// Enumeration of target type denoting a Group, Object or a Class.
    /// This represents several types of targets that a run as profile can be targetted to.
    /// As of SP1, we were only able to target the profile to a HealthService.
    /// </summary>
    public enum TargetType
    {
        /// <summary>
        /// 
        /// </summary>
        Default,
        /// <summary>
        /// 
        /// </summary>
        Group,
        /// <summary>
        /// 
        /// </summary>
        Object,
        /// <summary>
        /// 
        /// </summary>
        Class,
        /// <summary>
        /// 
        /// </summary>
        All
    }

    /// <summary>
    /// Used when calling RunAsProfile.Update
    /// </summary>
    public enum UpdateParameter
    {
        /// <summary>
        /// 
        /// </summary>
        Add,
        /// <summary>
        /// 
        /// </summary>
        Edit,
        /// <summary>
        /// 
        /// </summary>
        Delete
    }
}//end of namespace