// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AEMDeployment.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	AEM Deployment Base Class.
// </summary>
// <history>
// 	[lucyra] 13-Apr-06   Created
// </history>
// ---------------------------------------------------------------------------
#region Using directives
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using System.ComponentModel;
using System;
using System.Collections;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.AEM.Dialogs;
using ScCommonTopology = Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
#endregion

namespace Mom.Test.UI.Core.Console.AEM
{
    /// <summary>
    /// Class to add general methods for AEM deployment
    /// </summary>
    public class AEMDeployment
    {
        #region Private Members

        //Wait for a short amount of time
        private int secondsWaiting = 0;
        private const int MaxWait = 60;

        //Wait for the time defined
        private const int definedWait = 5000;

        //String System Drive
        string fSNameSystemDrive;

        /// <summary>
        /// cachedIntroDialog
        /// </summary>
        private IntroDialog cachedIntroDialog;

        /// <summary>
        /// cachedCEIPDialog
        /// </summary>
        private CEIPDialog cachedCEIPDialog;

        /// <summary>
        /// cachedConfigureErrorCollectionDialog
        /// </summary>
        private ConfigureErrorCollectionDialog cachedConfigureErrorCollectionDialog;

        /// <summary>
        /// cachedConfigureErrorForwardingDialog
        /// </summary>
        private ConfigureErrorForwardingDialog cachedConfigureErrorForwardingDialog;

        /// <summary>
        /// cachedCreateFileShareDialog
        /// </summary>
        private CreateFileShareDialog cachedCreateFileShareDialog;

        /// <summary>
        /// cachedDeployConfigurationSettingsDialog
        /// </summary>
        private DeployConfigurationSettingsDialog cachedDeployConfigurationSettingsDialog;

        /// <summary>
        /// cachedTaskStatusDialog
        /// </summary>
        private TaskStatusDialog cachedTaskStatusDialog;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;
        #endregion

        #region Constructor
        /// <summary>
        /// AEM Deployment Constructor.
        /// </summary>
        public AEMDeployment()
        {
            this.consoleApp = CoreManager.MomConsole;
            ScCommonTopology.MachineInfo firstMS = (ScCommonTopology.MachineInfo)ScCommonTopology.TopologyHelper.TestTopology.RootHealthServers[0];
            this.fSNameSystemDrive = firstMS.GetSystemDrive() + "\\";
        }
        #endregion

        #region Properties
        /// <summary>
        /// Intro Dialog
        /// The intro screen of the AEM Deployment wizard.
        /// </summary>
        public IntroDialog introDialog
        {
            get
            {
                if (this.cachedIntroDialog == null)
                {
                    this.cachedIntroDialog = new IntroDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Intro Dialog was successful");
                }
                return this.cachedIntroDialog;
            }
        }

        /// <summary>
        /// CEIP Dialog
        /// The first screen of the AEM Deployment wizard.
        /// </summary>
        public CEIPDialog cEIPDialog
        {
            get
            {
                if (this.cachedCEIPDialog == null)
                {
                    this.cachedCEIPDialog = new CEIPDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the CEIP Dialog was successful");
                }
                return this.cachedCEIPDialog;
            }
        }

        /// <summary>
        /// Configure Error Collection Dialog
        /// The second screen of the AEM Deployment wizard
        /// </summary>
        public ConfigureErrorCollectionDialog configureErrorCollectionDialog
        {
            get
            {
                if (this.cachedConfigureErrorCollectionDialog == null)
                {
                    this.cachedConfigureErrorCollectionDialog = new ConfigureErrorCollectionDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Configure Error Collection Dialog was successful");
                }
                return this.cachedConfigureErrorCollectionDialog;
            }
        }

        /// <summary>
        /// Configure Error Forwarding Dialog
        /// The third screen of the AEM Deployment wizard
        /// </summary>
        public ConfigureErrorForwardingDialog configureErrorForwardingDialog
        {
            get
            {
                if (this.cachedConfigureErrorForwardingDialog == null)
                {
                    this.cachedConfigureErrorForwardingDialog = new ConfigureErrorForwardingDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Configure Error Forwarding Dialog was successful");
                }
                return this.cachedConfigureErrorForwardingDialog;
            }
        }

        /// <summary>
        /// Create File Share Dialog
        /// The fourth screen of the AEM Deployment wizard
        /// </summary>
        public CreateFileShareDialog createFileShareDialog
        {
            get
            {
                if (this.cachedCreateFileShareDialog == null)
                {
                    this.cachedCreateFileShareDialog = new CreateFileShareDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Create File Share Dialog was successful");
                }
                return this.cachedCreateFileShareDialog;
            }
        }

        /// <summary>
        /// Deploy Configuration Settings Dialog
        /// The fifth screen of the AEM Deployment wizard
        /// </summary>
        public DeployConfigurationSettingsDialog deployConfigurationSettingsDialog
        {
            get
            {
                if (this.cachedDeployConfigurationSettingsDialog == null)
                {
                    this.cachedDeployConfigurationSettingsDialog = new DeployConfigurationSettingsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Deploy Configuration Settings Dialog was successful");
                }
                return this.cachedDeployConfigurationSettingsDialog;
            }
        }

        /// <summary>
        /// Task Status Dialog
        /// The finish screen of the AEM Deployment wizard
        /// </summary>
        public TaskStatusDialog taskStatusDialog
        {
            get
            {
                if (this.cachedTaskStatusDialog == null)
                {
                    this.cachedTaskStatusDialog = new TaskStatusDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Task Status Dialog was successful");
                }
                return this.cachedTaskStatusDialog;
            }
        }            

        #endregion

        #region Public Methods

        #region NavigateToManagementServers
        /// <summary>
        /// Method to navigate to the Management Servers under Administration
        /// from anywhere in the MOMconsole
        /// </summary>        
        /// <history>
        ///     [lucyra] 14APR06 - Created        
        /// </history>
        public void NavigateToManagementServers()
        {
            Utilities.LogMessage("AEMDeployment.NavigateToManagementServers:: Navigate to and launch the AEM Deployment wizard under Administration");
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow,
                    Constants.DefaultDialogTimeout);
            Utilities.LogMessage("AEMDeployment.NavigateToManagementServers:: WaitForUIObjectReady returned");
            CoreManager.MomConsole.BringToForeground();
            Utilities.LogMessage("AEMDeployment.NavigateToManagementServers:: BringToForeground returned");
            // Select the Administration view
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Administration);
            Utilities.LogMessage("AEMDeployment.NavigateToManagementServers:: Successfully clicked on Administration Wunderbar");

            Maui.Core.WinControls.TreeNode managementServersNode = navPane.SelectNode(NavigationPane.Strings.AdminTreeViewAdministrationRoot + "\\" + NavigationPane.Strings.AdminTreeViewDeviceManagement + 
                "\\" + NavigationPane.Strings.AdminTreeViewManagementServers, NavigationPane.NavigationTreeView.Administration);

            managementServersNode.Click();
            Utilities.LogMessage("AEMDeployment.NavigateToManagementServers:: Successfully clicked on Management Servers under Administration Treeview");
        }
        #endregion 

        #region DisableAEM
        /// <summary>
        /// Method to disable AEM
        /// </summary>        
        /// <history>
        ///     [lucyra] 14APR06 - Created        
        /// </history>
        public void DisableAEM()
        {
            //Variable that holds cell value
            string cellValue = null;

            //Navigate to Management Servers node under Administration
            NavigateToManagementServers();

            Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            if (viewGrid != null)
            {
                Utilities.LogMessage("AEMDeployment.DisableAEM ::  Clicking in the Grid");
                Maui.Core.WinControls.DataGridViewRow dataGridRow = null;

                //Getting Datagridrow = AEM Mode column
                while (dataGridRow == null && secondsWaiting <= MaxWait)
                {
                    // refresh the view
                    viewGrid.Click();
                    CoreManager.MomConsole.Refresh();
                    dataGridRow = CoreManager.MomConsole.ViewPane.Grid.FindData(Core.Console.AEM.AEMDeployment.Strings.AEMModeEnabled, Core.Console.AEM.AEMDeployment.Strings.AEMModeColumnName);

                    secondsWaiting = secondsWaiting + 2;

                    // sleep for two seconds
                    Maui.Core.Utilities.Sleeper.Delay(2000);
                }
                Utilities.LogMessage("AEMDeployment.EnableAEM ::  Waited for " + secondsWaiting + " seconds for Root Management Server row to be found in the Grid");

                if (dataGridRow == null)
                {
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: Could not find column for Root Mgmt Server. Using first MS instead");
                    if(CoreManager.MomConsole.ViewPane.Grid.Rows.Count > 0) dataGridRow = CoreManager.MomConsole.ViewPane.Grid.Rows[0];
			Utilities.LogMessage("This is the row: " + dataGridRow.ToString() + dataGridRow.Value);
                }
                if (dataGridRow == null)
                {
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: No Management Servers found!");
                }
                else
                {
                    Utilities.LogMessage("AEMDeployment.DisableAEM :: The data grid found source column:" + dataGridRow);
                    int rowPos = dataGridRow.AccessibleObject.Index;
                    Utilities.LogMessage("AEMDeployment.DisableAEM :: ViewGrid found at row " + rowPos);
                    // Get the Index position of the Column of State
                    int colpos = viewGrid.GetColumnTitlePosition(Core.Console.AEM.AEMDeployment.Strings.AEMModeColumnName);
                    Utilities.LogMessage("AEMDeployment.DisableAEM :: Clicking column " + colpos);
                    viewGrid.ClickCell(rowPos, colpos);
                    cellValue = viewGrid.GetCellValue(rowPos, colpos).ToString();
                    Utilities.LogMessage("AEMDeployment.DisableAEM :: :: my cell value is: " + cellValue);

                    Utilities.LogMessage("AEMDeployment.DisableAEM :: Right clicking now");
                    // Selecting Disable from the context menu
                    Maui.Core.WinControls.Menu disableAEMMenuItem = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
                    //disableAEMMenuItem.WaitContextMenuWithTimeOut(definedWait);
                    disableAEMMenuItem.ScreenElement.WaitForReady();
                    Utilities.LogMessage("AEMDeployment.DisableAEM :: Selecting '" + Core.Console.AEM.AEMDeployment.Strings.DisableAEMContextMenu + "' ");
                    disableAEMMenuItem.ExecuteMenuItem(Core.Console.AEM.AEMDeployment.Strings.DisableAEMContextMenu);
                    Utilities.LogMessage("AEMDeployment.DisableAEM :: Successfully clicked on Disable context menu");
                }
            }
            else
            {
                Utilities.LogMessage("AEMDeployment.DisableAEM :: viewGrid not found.");
            }                              

            //confirm Disable AEM
            CoreManager.MomConsole.ConfirmChoiceDialog(true);
            Maui.Core.Utilities.Sleeper.Delay(1000);
        }
        #endregion

        #region EnableAEM
        /// <summary>
        /// Enable AEM with default AEM File Share Name 
        /// </summary>
        /// <history>
        ///     [lucyra] 14Apr06 - Created        
        /// </history>
        public void EnableAEM()
        {
            //string fSName = Mom.Test.UI.Core.Console.AEM.AEMDeployment.DefaultAEMfsName;
            string fSName = fSNameSystemDrive + "AEMFileShare";
            this.EnableAEM(fSName);
        }

        /// <summary>
        /// Enable AEM
        /// </summary>
        /// <param name="fSName">Name of File Share</param>
        /// <history>
        ///     [lucyra] 14Apr06 - Created         
        /// </history>
        public void EnableAEM(string fSName)
        {
            AEMDeploymentParameters parameters = new AEMDeploymentParameters();
            parameters.FSName = fSName;
            this.EnableAEM(parameters);
        }

        /// <summary>
        /// AEM Deployment with Parameters
        /// </summary>
        /// <param name="parameters">AEMDeploymentParameters</param>
        /// <history>
        ///     [lucyra] 14Apr06 - Created        
        ///     [a-joelj]   29JAN09 Fixed Waiters.WaitForButtonEnabled timeout from 60000 to 60
        /// </history>
        public void EnableAEM(AEMDeploymentParameters parameters)
        {
            //Variable that holds cell value
            string cellValue = null;

            #region Launch intro screen of the AEM deployment wizard
            Utilities.LogMessage("AEMDeployment.EnableAEM:: Navigate To Management Servers");
            NavigateToManagementServers();

            //In the grid control select Management Server, r-click -> Enable AEM
            Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            if (viewGrid != null)
            {
                Utilities.LogMessage("AEMDeployment.EnableAEM ::  Clicking in the Grid");
                Maui.Core.WinControls.DataGridViewRow dataGridRow = null;

                //Getting Datagridrow = Root Management Server column
                while (dataGridRow == null && secondsWaiting <= MaxWait)
                {
                    // refresh the view
                    viewGrid.Click();
                    CoreManager.MomConsole.Refresh();
                    dataGridRow = CoreManager.MomConsole.ViewPane.Grid.FindData(Core.Console.AEM.AEMDeployment.Strings.RMSEmulatorValue, Core.Console.AEM.AEMDeployment.Strings.RMSEmulatorColumnName);

                    secondsWaiting = secondsWaiting + 2;

                    // sleep for two seconds
                    Maui.Core.Utilities.Sleeper.Delay(2000);
                }
                Utilities.LogMessage("AEMDeployment.EnableAEM ::  Waited for " + secondsWaiting + " seconds for Root Management Server row to be found in the Grid");

                if (dataGridRow == null)
                {
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: Could not find column for Root Mgmt Server. Using first MS instead");
                    dataGridRow = CoreManager.MomConsole.ViewPane.Grid.FindData(Core.Console.AEM.AEMDeployment.Strings.MSEmulatorValue, Core.Console.AEM.AEMDeployment.Strings.RMSEmulatorColumnName);
                }
                if (dataGridRow == null)
                {
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: No Management Servers found!");
                }
                else
                {
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: The data grid found source column:" + dataGridRow);
                    int rowPos = dataGridRow.AccessibleObject.Index;
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: ViewGrid found");
                    // Get the Index position of the Column of State
                    int colpos = viewGrid.GetColumnTitlePosition(Core.Console.AEM.AEMDeployment.Strings.AEMModeColumnName);
                    viewGrid.ClickCell(rowPos, colpos);
                    cellValue = viewGrid.GetCellValue(rowPos, colpos).ToString();
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: :: my cell value is: " + cellValue);

                    Utilities.LogMessage("AEMDeployment.EnableAEM :: Right clicking now");
                    // Selecting Disable from the context menu
                    Maui.Core.WinControls.Menu enableAEMMenuItem = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
                    //enableAEMMenuItem.WaitContextMenuWithTimeOut(definedWait);
                    enableAEMMenuItem.ScreenElement.WaitForReady();
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: Selecting '" + Core.Console.AEM.AEMDeployment.Strings.EnableAEMContextMenu + "' ");
                    enableAEMMenuItem.ExecuteMenuItem(Core.Console.AEM.AEMDeployment.Strings.EnableAEMContextMenu);
                    Utilities.LogMessage("AEMDeployment.EnableAEM :: Successfully clicked on Enable context menu");
                }
            }
            else
            {
                Utilities.LogMessage("AEMDeployment.EnableAEM :: viewGrid not found.");
            }

            Maui.Core.Utilities.Sleeper.Delay(1000);
            this.introDialog.Extended.SetFocus();
            Utilities.LogMessage("Set focus successfully on 1st screen");
            // check to see if this is the intro page
            try
            {
                // see if the "skip this step" checkbox is visible
                if (this.introDialog.Controls.DoNotShowThisPageAgainCheckBox.Extended.IsVisible == true &&
                    this.introDialog.Controls.DoNotShowThisPageAgainCheckBox.Extended.IsEnabled == true)
                {
                    Core.Common.Utilities.LogMessage("AEMDeployment::EnableAEM::Found Intro page of the wizard...");

                    // set checkbox 'Do not show again'
                    this.introDialog.Controls.DoNotShowThisPageAgainCheckBox.Checked = true;
                    this.introDialog.Controls.DoNotShowThisPageAgainCheckBox.ButtonState = ButtonState.Checked;

                    // click "Next" to clear the welcome screen
                    this.introDialog.ClickNext();
                }
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                Core.Common.Utilities.LogMessage("AEMDeployment::EnableAEM::No Intro page found.");
            }
            #endregion

            #region Navigate through all the screens of the AEM Deployment Wizard

            // 1st tab - do nothing by default
            //modify later to enable CEIP
            this.cEIPDialog.Extended.SetFocus();
            this.cEIPDialog.ClickNext();
            
            //2nd tab - set file share name, leave the rest defaults
            this.configureErrorCollectionDialog.Extended.SetFocus();
            Utilities.LogMessage("AEMDeployment.EnableAEM :: setting File Share name");
            this.configureErrorCollectionDialog.DeploySettingsText = parameters.FSName;
            Maui.Core.Utilities.Sleeper.Delay(1000);
            Utilities.LogMessage("AEMDeployment.EnableAEM :: File Share Name right after setting is '"
                + this.configureErrorCollectionDialog.DeploySettingsText.ToString() + "'");
            this.configureErrorCollectionDialog.ClickNext();

            //3rd tab, leave unchecked, modify to forward data to MS later
            this.configureErrorForwardingDialog.Extended.SetFocus();
            this.configureErrorForwardingDialog.ClickNext();

            //4th tab, leave default Action Account
            this.createFileShareDialog.Extended.SetFocus();
            #region Set action account so that case could be ran at low priv topologies.
            this.createFileShareDialog.Controls.OtherUserAccountWillNotBeSavedRadioButton.Click();
            string domain, userName, password = null;
            string[] temp = Utilities.GetAdministratorUserAndPassword();
            domain = temp[0].Split('\\')[0];
            userName = temp[0].Split('\\')[1];
            password = temp[1];
            this.createFileShareDialog.Controls.UserNameTextBox.Text = userName;
            this.createFileShareDialog.Controls.PasswordTextBox.Text = password;
            this.createFileShareDialog.Controls.DomainEditComboBox.Text = domain; 
            #endregion
            this.createFileShareDialog.ClickNext();

            //5th tab, tast status
            //need to try selecting this, might hit timing issues
            this.taskStatusDialog.Extended.SetFocus();
            
            //wait upto 2 min before clicking Next
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.taskStatusDialog.Controls.NextButton, Constants.OneMinute * 2);
            
            ////wait 1 min before clicking Next
            //Maui.Core.Utilities.Sleeper.Delay(60000);
            this.createFileShareDialog.ClickNext();

            //Finish screen, click Finish
            this.deployConfigurationSettingsDialog.Extended.SetFocus();
            this.deployConfigurationSettingsDialog.ClickFinish();

            //Wait for wizard dialog to close
            CoreManager.MomConsole.WaitForDialogClose(this.deployConfigurationSettingsDialog, 30);
            Utilities.LogMessage("AEMDeployment.EnableAEM :: Successfully completed AEM Deployment!!");

            #endregion
        }
        #endregion //DeployAEM

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource strings for AEM Deployment
        /// </summary>
        /// <history> 	
        ///   [lucyra] 14APR06 - Created 
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

             /// <summary>
            /// Contains Resource string for:  RMSEmulatorValue = "Yes"
            /// </summary>            
            private const string ResourceRMSEmulatorValue =
                ";Yes;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;TextYes";

             /// <summary>
            /// Contains Resource string for:  RMSEmulatorValue = "No"
            /// </summary>            
            private const string ResourceMSEmulatorValue =
                ";No;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;TextNo";

            /// <summary>
            /// Contains Resource string for:  Column Name "RMS Emulator"
            /// </summary>            
            private const string ResourceRMSEmulatorColumnName = ";RMS Emulator;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ViewColumnRMSEmulator";

            /// <summary>
            /// Contains Resource string for:  Column Name "AEM Mode"
            /// </summary>            
            private const string ResourceAEMModeColumnName = ";Client Monitoring Mode;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AemModeViewColumn";

            /// <summary>
            /// Contains Resource string for:  Value of AEM Mode - Enabled
            /// </summary>            
            private const string ResourceAEMModeEnabled = ";Enabled;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;EnabledText";

            /// <summary>
            /// Contains Resource string for:  Value of AEM Mode - Disabled
            /// </summary>            
            private const string ResourceAEMModeDisabled = ";Disabled;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DisabledText";

            /// <summary>
            /// Contains Resource string for:  Context Menu "Enable AEM"
            /// </summary>            
            private const string ResourceEnableAEMContextMenu = ";Configure Client Monitoring;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AEMEnabledMenu";

            /// <summary>
            /// Contains Resource string for:  Context Menu "Disable AEM"
            /// </summary>            
            private const string ResourceDisableAEMContextMenu = ";Disable Client Monitoring;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AEMDisableMenu";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RMS Emulator Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRMSEmulatorValue;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MS Emulator Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMSEmulatorValue;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "RMS Emulator" Column Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRMSEmulatorColumnName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "AEM Mode" Column Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAEMModeColumnName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Enabled" text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAEMModeEnabled;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Disabled" text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAEMModeDisabled; 

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Enable AEM" Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnableAEMContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Disable AEM" Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisableAEMContextMenu;

            #endregion

            #region Properties  

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to RMS Emulator Value
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 - Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RMSEmulatorValue
            {
                get
                {
                    if ((cachedRMSEmulatorValue == null))
                    {
                        cachedRMSEmulatorValue = CoreManager.MomConsole.GetIntlStr(ResourceRMSEmulatorValue);
                    }

                    return cachedRMSEmulatorValue;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MS Emulator Value
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 - Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MSEmulatorValue
            {
                get
                {
                    if ((cachedMSEmulatorValue == null))
                    {
                        cachedMSEmulatorValue = CoreManager.MomConsole.GetIntlStr(ResourceMSEmulatorValue);
                    }

                    return cachedMSEmulatorValue;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to RMS Emulator Column Name
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 - Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RMSEmulatorColumnName
            {
                get
                {
                    if ((cachedRMSEmulatorColumnName == null))
                    {
                        cachedRMSEmulatorColumnName = CoreManager.MomConsole.GetIntlStr(ResourceRMSEmulatorColumnName);
                    }

                    return cachedRMSEmulatorColumnName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to AEM Mode Column Name
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 - Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AEMModeColumnName
            {
                get
                {
                    if ((cachedAEMModeColumnName == null))
                    {
                        cachedAEMModeColumnName = CoreManager.MomConsole.GetIntlStr(ResourceAEMModeColumnName);
                    }

                    return cachedAEMModeColumnName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to (AEM Mode =) Enabled text
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 - Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AEMModeEnabled
            {
                get
                {
                    if ((cachedAEMModeEnabled == null))
                    {
                        cachedAEMModeEnabled = CoreManager.MomConsole.GetIntlStr(ResourceAEMModeEnabled);
                    }

                    return cachedAEMModeEnabled;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to (AEM Mode =) Disabled text
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 - Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AEMModeDisabled
            {
                get
                {
                    if ((cachedAEMModeDisabled == null))
                    {
                        cachedAEMModeDisabled = CoreManager.MomConsole.GetIntlStr(ResourceAEMModeDisabled);
                    }

                    return cachedAEMModeDisabled;
                }
            } 

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Enable AEM Context Menu
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 - Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnableAEMContextMenu
            {
                get
                {
                    if ((cachedEnableAEMContextMenu == null))
                    {
                        cachedEnableAEMContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceEnableAEMContextMenu);
                    }

                    return cachedEnableAEMContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Disable AEM Context Menu
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 - Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisableAEMContextMenu
            {
                get
                {
                    if ((cachedDisableAEMContextMenu == null))
                    {
                        cachedDisableAEMContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceDisableAEMContextMenu);
                    }

                    return cachedDisableAEMContextMenu;
                }
            }

            #endregion
        }
        #endregion

        #region AEMDeploymentParameters Class
        /// <summary>
        /// Parameters class for AEM Deployment constructors.
        /// </summary>
        /// <history>
        /// [lucyra] 14APR06 - Created
        /// </history>
        public class AEMDeploymentParameters
        {
            #region Private Members
            private string cachedFSName = null;

            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public AEMDeploymentParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// File Share Name
            /// </summary>
            public string FSName
            {
                get
                {
                    return this.cachedFSName;
                }

                set
                {
                    this.cachedFSName = value;
                }
            }

            #endregion
        }
        #endregion

    }//end of class AEMDeployment
}//end of namespace




