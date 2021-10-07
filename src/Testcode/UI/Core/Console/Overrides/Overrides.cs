// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Overrides.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Overrides Helper Base Class.
// </summary>
// <history>
// 	[ruhim] 07-Sep-06   Created
//  [nathd] 01Aug08     Added support for the Overrides Summary View
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
using Mom.Test.UI.Core.Console.Overrides.Dialogs;
using Microsoft.EnterpriseManagement.Mom.Internal;
#endregion


namespace Mom.Test.UI.Core.Console.Overrides
{
    /// <summary>
    /// Class to add general methods for Overrides 
    /// </summary>
    public class Overrides
    {
        #region Constants
        /// <summary>
        /// Name for Test.UI.Overrides.Management.Pack
        /// </summary>
        public const string OverridesTestMPName = "Test.UI.Overrides.Management.Pack";

        /// <summary>
        /// RuleName for Test Performance Rule Test.UI.Overrides.Management.Pack
        /// </summary>
        public const string TestPerformanceRuleName = "MomUIGeneratedRule3d78cebf17984d779904a99c12d49d7d";

        /// <summary>
        /// Diagnostic ID for Test Diagnostic 'Reset Windows Update Auth' in UI Test Overrides MP
        /// </summary>
        public const string TestDiagnosticId = "MomUIGenaratedDiagnostic1ceb6d859ebb48c59bfdee7d9134447c";

        /// <summary>
        /// Recovery ID for Test Recovery 'Start Windows Update Service' in UI Test Overrides MP
        /// </summary>
        public const string TestRecoveryId = "MomUIGenaratedRecovery0b59e285908e4fb9b1462f77c694279c";

        /// <summary>
        /// Rule ID for Test Rule 'Test NT Event Log Rule' in UI Test Overrides MP
        /// </summary>
        public const string TestRuleId = "MomUIGeneratedRulebe8558a746004059810cb3cf569583b9";

        /// <summary>
        ///  One Second in MilliSeconds
        /// </summary>
        public const int OneSecondInMilliSeconds = 1000;

        /// <summary>
        ///  Disable objects
        /// </summary>
        public const string Disable = "Disable";

        #endregion

        #region Private Members

        /// <summary>
        /// cachedOverrideProperties
        /// </summary>
        private OverrideProperties cachedOverrideProperties;  
        
        /// <summary>
        /// cachedSelectObjectDialog
        /// </summary>
        private Core.Console.Dialogs.SelectObjectDialog cachedSelectObjectDialog;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;
        
        #endregion

        #region Enumerators section

        /// <summary>
        /// Overrides Type
        /// </summary>
        public enum OverrideType
        {
            /// <summary>
            /// ForCurrentInstance - For the object
            /// </summary>
            ForCurrentInstance,

            /// <summary>
            /// ForCurrentTypeFormat - For all objects of type
            /// </summary>
            ForCurrentTypeFormat,

            /// <summary>
            /// ForSelectedGroup - For a group
            /// </summary>
            ForSelectedGroup,

            /// <summary>
            /// ForSelectedInstanceFormat - For a specific object of type
            /// </summary>
            ForSelectedInstanceFormat,

            /// <summary>
            /// ForOtherClass - For all objects of another type
            /// </summary>
            ForOtherClass,  
        }

        /// <summary>
        ///  Override Target Type
        /// </summary>
        public enum OverrideTargetType
        {
            /// <summary>
            ///  Override targeting a rule
            /// </summary>
            Rule,

            /// <summary>
            ///  Override targeting a monitor
            /// </summary>
            Monitor,

            /// <summary>
            ///  Override targeting a diagnostic task
            /// </summary>
            Diagnostics,

            /// <summary>
            ///  Override targeting a recovery task
            /// </summary>
            Recovery,

            /// <summary>
            ///  Override targeting a discovery
            /// </summary>
            Discovery,
        }

        /// <summary>
        ///  Overrides Summary View Type
        /// </summary>
        public enum OverrideSummaryViewType
        {
            /// <summary>
            ///  My Workspace
            /// </summary>
            MyWorkspace,

            /// <summary>
            ///  Authoring
            /// </summary>
            Authoring
        }

        /// <summary>
        /// Overrides Value
        /// </summary>
        public enum OverrideValue
        {
            /// <summary>
            /// Effective value set as Preferred Value
            /// </summary>
            PreferredValue,

            /// <summary>
            /// Effective value set as Enforced Value
            /// </summary>
            EnforcedValue,
        }

        #endregion	// Enumerators section

        #region Constructor
        /// <summary>
        /// Overrides Constructor.
        /// </summary>
        public Overrides()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Override Properties Dialog        
        /// </summary>
        public OverrideProperties overrideProperties
        {
            get
            {
                if (this.cachedOverrideProperties == null)
                {
                    this.cachedOverrideProperties = new OverrideProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Override Properties Dialog was successful");
                }
                return this.cachedOverrideProperties;
            }
        }

        /// <summary>
        /// Select Object Dialog        
        /// </summary>
        public Core.Console.Dialogs.SelectObjectDialog selectObjectDialog
        {
            get
            {
                //Need to fetch the dialog everytime or else set it to null after dismissing
                // the dialog everytime other InvalidHwd excetpion gets thrown
                
                this.cachedSelectObjectDialog = new Core.Console.Dialogs.SelectObjectDialog(CoreManager.MomConsole);
                Utilities.LogMessage("Setting Focus on the Select Object Dialog was successful");            
                return this.cachedSelectObjectDialog;
            }
        }        

        #endregion

        #region Public Methods

        /// <summary>
        /// Launch Overrides Property Dialog. Before calling this method it is necessary to  
        /// select the specific view and a specific row from the results pane from where
        /// you want the overrides dialog to be launched
        /// </summary>
        /// <param name="type">OverrideType</param>
        /// <param name="targetType">OverrideTargetType</param>
        /// <param name="targetName">Name of either a recover or a discovery</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [ruhim] 18Sep06 - Created
        ///     [nathd] 01Aug08 - Added support to override a Diagnostic or Recovery task
        /// </history>
        public void LaunchOverridesPropertyDialog(OverrideType type, OverrideTargetType targetType, string targetName, string overridesOrDisable)
        {
            # region Launch the Overrides Property Dialog

            //Maui4.0:[v-vijia] Click overrides link in action pane and then execute context menu.
            //It is hard to execute context menu in gird view.
            string actionPaneNode = string.Empty;
            string viewTitle = CoreManager.MomConsole.ViewPane.Title;
            if (viewTitle.Contains(Core.Console.Views.Views.Strings.RulesView))
            {
                actionPaneNode = Core.Console.Overrides.Overrides.Strings.RuleObject;
            }
            else if (viewTitle.Contains(Core.Console.Views.Views.Strings.AlertView))
            {
                actionPaneNode = Mom.Test.UI.Core.Console.Views.Alerts.AlertsView.Strings.AlertActions;
            }
            else if (viewTitle.Contains(Core.Console.Views.Views.Strings.ObjectDiscoveriesView))
            {
                actionPaneNode = Core.Console.Overrides.Overrides.Strings.DiscoveryObject;
            }
            else
            {
                actionPaneNode = Core.Console.Overrides.Overrides.Strings.MonitorObject;
            }

            try
            {
                CoreManager.MomConsole.ActionsPane.ClickLink(actionPaneNode, Overrides.Strings.OverridesButton);
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                //Maui4.0:[v-vijia] Click action pane link in the new launched window. Work around for override process monitor
                Utilities.LogMessage("Overrides.LaunchOverridesPropertyDialog:: Try to click action pane link again.");
                Window newWindow = new Window(ConsoleApp.Strings.DialogTitle, StringMatchSyntax.WildCard);
                ActionsPane actionPane = new ActionsPane(newWindow);
                actionPane.ClickLink(actionPaneNode, Overrides.Strings.OverridesButton);
            }
            

            string menuPath = string.Empty;

            string flyoutOption = null;
            switch (type)
            {
                case OverrideType.ForCurrentInstance:
                    flyoutOption = Overrides.Strings.FlyoutForCurrentInstance;
                    break;
                case OverrideType.ForCurrentTypeFormat:
                    flyoutOption = Overrides.Strings.FlyoutForCurrentTypeFormat;
                    break;
                case OverrideType.ForOtherClass:
                    flyoutOption = Overrides.Strings.FlyoutForOtherClass;
                    break;
                case OverrideType.ForSelectedGroup:
                    flyoutOption = Overrides.Strings.FlyoutForSelectedGroup;
                    break;
                case OverrideType.ForSelectedInstanceFormat:
                    flyoutOption = Overrides.Strings.FlyoutForSelectedInstanceFormat;
                    break;
                default:
                    Utilities.LogMessage("Overrides.LaunchOverridesPropertyDialog:: Override Type: " + type.ToString());
                    throw new InvalidEnumArgumentException("Overrides.LaunchOverridesPropertyDialog :: Invalid Override Type passed");
            }

            // Executing Override 
            switch (targetType)
            {
                case OverrideTargetType.Rule:
                case OverrideTargetType.Monitor:
                case OverrideTargetType.Discovery:
                default:
                    //disable the rule/monitor/discovery
                    if (overridesOrDisable == Disable)
                    {
                        menuPath = Overrides.Strings.FlyoutMenuDisable;
                    }
                    //Override the rule/monitor/discovery
                    else
                    {
                        menuPath = Overrides.Strings.FlyoutMenuOverride;
                    }
                    break;
                case OverrideTargetType.Recovery:
                    menuPath = Overrides.Strings.FlyoutMenuOverrideRecovery;

                    // Select recovery by name
                    if (targetName != null)
                    {
                        menuPath = menuPath + Core.Common.Constants.PathDelimiter + targetName;
                    }
                    else
                    {
                        throw new Exception("Overrides.LaunchOverridesPropertyDialog:: Override Target Type is " + targetType.ToString()
                            + "No Override Target Name provided.");
                    }
                    break;
                case OverrideTargetType.Diagnostics:
                    menuPath = Overrides.Strings.FlyoutMenuOverrideDiagnostic;
                    // Select a diagnostic by name
                    if (targetName != null)
                    {

                        menuPath = menuPath + Core.Common.Constants.PathDelimiter + targetName;
                    }
                    else
                    {
                        throw new Exception("Overrides.LaunchOverridesPropertyDialog:: Override Target Type is " + targetType.ToString()
                            + "No Override Target Name provided.");
                    }
                    break;
                /*default:
                    throw new InvalidEnumArgumentException("Overrides.LaunchOverridesPropertyDialog :: Invalid Override Target Type passed");*/
            }

            //Execute context menu
            menuPath = menuPath + Core.Common.Constants.PathDelimiter + flyoutOption;
            menuPath = menuPath.Replace("&", "");
            menuPath = menuPath.Replace("*", "");
            Utilities.LogMessage("Overrides.LaunchOverridesPropertyDialog:: menuPath: " + menuPath);
            char[] delimiter = Core.Common.Constants.PathDelimiter.ToCharArray();
            string[] path = menuPath.Split(delimiter);

            Menu menu = null;
            int maxRetry = 3;
            for (int i = 0; i < maxRetry; i++)
            {
                try
                {
                    Sleeper.Delay(Constants.OneSecond * 2);
                    menu = new Menu();
                    break;
                }
                catch (Exception)
                {
                    Core.Common.Utilities.LogMessage(
                        "Attempt " + (i + 1) + " of " + maxRetry); 
                }
            }

            foreach (string item in path)
            {
                foreach (MenuItem menuItem in menu.MenuItems)
                {
                    if (menuItem.Text.Contains(item))
                    {
                        Utilities.LogMessage("executing menu item:" + menuItem.Text);
                        menuItem.Execute();
                        break;
                    }
                }
            }

            Utilities.LogMessage("Overrides.LaunchOverridesPropertyDialog:: Successfully Launched the Overrides Property Dialog");
            #endregion
        }

        /// <summary>
        /// Launch Overrides Property Dialog. Before calling this method it is necessary to  
        /// select the specific view and a specific row from the results pane from where
        /// you want the overrides dialog to be launched
        /// </summary>
        /// <param name="type">OverrideType</param>
        /// <param name="targetType">OverrideTargetType</param>
        /// <param name="targetName">Name of either a recover or a discovery</param>
        /// <param name="overridePath">String indicating Name of the Group, Instance or Class</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [ruhim] 18Sep06 - Created
        ///     [nathd] 01Aug08 - Added support 
        /// </history>
        public void LaunchOverridesPropertyDialog(OverrideType type, OverrideTargetType targetType, string targetName, string overridePath, string overridesOrDisable)
        {
            LaunchOverridesPropertyDialog(type, targetType, targetName, overridesOrDisable);

            switch (type)
            {
                case OverrideType.ForSelectedInstanceFormat:
                case OverrideType.ForSelectedGroup:
                    int targetHeaderColPos = -1;
                    targetHeaderColPos = consoleApp.GeListViewtColumnPosition(Core.Console.Dialogs.SelectObjectDialog.Strings.DisplayNameHeader, this.selectObjectDialog.Controls.MatchingObjectsListView);

                    int retry = 0;
                    int maxTries = 10;
                    while (retry < maxTries)
                    {
                        if (this.selectObjectDialog.Controls.MatchingObjectsListView.Count > 0)
                        {
                            Utilities.LogMessage("Overrides.LaunchOverridesPropertyDialog:: Found " + this.selectObjectDialog.Controls.MatchingObjectsListView.Count
                                + " instances in Select Object dialog.");
                            break;
                        }
                        else
                        {
                            retry++;
                            Utilities.LogMessage("Overrides.LaunchOverridesPropertyDialog:: No instances found, retry " + retry + " of " + maxTries);
                            Sleeper.Delay(Constants.OneSecond);
                        }
                    }

                    CoreManager.MomConsole.SelectListViewItems(overridePath, targetHeaderColPos, this.selectObjectDialog.Controls.MatchingObjectsListView,false);
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.selectObjectDialog.Controls.OKButton, Constants.DefaultDialogTimeout);
                    this.selectObjectDialog.ClickOK();
                    Utilities.LogMessage("Overrides.LaunchOverridesPropertyDialog:: Successfully selected a group");
                    break;
            }
        }

        /// <summary>
        /// Add new Overrides. Before calling this method it is necessary to select 
        /// the specific view and a specific row from the results pane from where
        /// you want the overrides dialog to be launched
        /// </summary>
        /// <param name="parameters">OverridesParameters</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [ruhim] 11Sep06 - Created
        ///     [nathd] 28JUL09 - Added support for overridable parameter 'frequency (seconds)'
        ///     [v-lileo] 29Jan10 -Edit overridable parameter 'Threshold ','frequency (seconds)','TimeoutSeconds'and 'Tolerance' resource strings
        /// </history>
        public bool AddOverrides(OverridesParameters parameters)
        {
            //flag used to verify checkbox is selected and Enable value is false
            bool flagOverrides = true;
            int retryIndex = 0;
            MomControls.GridControl OverridesGrid = null;
            while (retryIndex++ < Constants.DefaultMaxRetry)
            {
                try
                {
                    # region Launch the Overrides Property Dialog
                    switch (parameters.OverridePath)
                    {
                        case null:
                            LaunchOverridesPropertyDialog(parameters.Type, parameters.OverrideTargetType, parameters.OverrideTarget, parameters.OverrideOrDisable);
                            break;
                        default:
                            LaunchOverridesPropertyDialog(parameters.Type, parameters.OverrideTargetType, parameters.OverrideTarget, parameters.OverridePath, parameters.OverrideOrDisable);
                            break;
                    }

                    #endregion

                    #region Set Override

                    OverridesGrid = new MomControls.GridControl(overrideProperties,
                        OverrideProperties.ControlIDs.DataGridView1);
                    Utilities.LogMessage("Overrides.AddOverrides:: Succesfully found Overrides Grid View");
                    break;
                }
                catch(Maui.Core.Window.Exceptions.WindowNotFoundException e)
                {
                    Utilities.TakeScreenshot("AddOverrides-WindowNotFoundException-retry-"+retryIndex);
                    Utilities.LogMessage("Overrides.AddOverrides:: WindowNotFoundException,retry=" + retryIndex + "");
                    if (retryIndex == Constants.DefaultMaxRetry)
                    {
                        Utilities.LogMessage("Overrides.AddOverrides:: WindowNotFoundException reach max retry.");
                        throw e;
                    }
                    else
                    {
                        CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                        Utilities.TakeScreenshot("AddOverrides-WindowNotFoundException-after-ESC" + retryIndex);
                    }
                }
            }

            int rowPos, colPos = -1;

            foreach (string parameterName in parameters.ParameterValuePairs.Keys)
            {
                rowPos = OverridesGrid.FindData(parameterName, MomControls.GridControl.SearchStringMatchType.ExactMatch).AccessibleObject.Index;
                colPos = OverridesGrid.GetColumnTitlePosition(Overrides.Strings.OverrideHeader);
                Utilities.LogMessage("Overrides.AddOverrides:: Row Position for Parameter: " 
                    + parameterName + " is: " + rowPos);
                Utilities.LogMessage("Overrides.AddOverrides:: Column Position for Header: "
                    + Overrides.Strings.OverrideHeader + " is: " + colPos);

                //OverridesGrid.Rows[rowPos].Cells[colPos].Click();
                DataGridViewCheckBoxCell overrideCheckBox = new DataGridViewCheckBoxCell(OverridesGrid.Rows[rowPos].Cells[colPos].AccessibleObject);

                if (overrideCheckBox.AccessibleObject.Value != "True")
                {
                    if (parameters.OverrideOrDisable == Disable)
                    {
                        flagOverrides = false;
                        Utilities.LogMessage("Overrides.AddOverrides::Checkbox is not selected for launching Overrides from disable... ");
                        return flagOverrides;
                    }
                    //overrideCheckBox.AccessibleObject.Click();
                    OverridesGrid.Rows[rowPos].Cells[colPos].AccessibleObject.DoDefaultAction();
                    Utilities.LogMessage("Overrides.AddOverrides:: Clicked on the Checkbox");
                }
                else
                {
                    Utilities.LogMessage("Overrides.AddOverrides:: Override already enabled for this parameter hence CheckBox not checked again");
                }

                colPos = OverridesGrid.GetColumnTitlePosition(Overrides.Strings.OverrideSettingHeader);
                Utilities.LogMessage("Overrides.AddOverrides:: Column Position for Header: "
                    + Overrides.Strings.OverrideSettingHeader + " is: " + colPos);
  
                switch(parameters.OverrideOrDisable)
                {
                    case Disable:
                        {
                            if (parameters.ParameterValuePairs[parameterName].ToString() !=
                                OverridesGrid.Rows[rowPos].Cells[colPos].AccessibleObject.Value)
                            {
                                flagOverrides = false;
                                Utilities.LogMessage("Overrides.AddOverrides::Enable is not disabled for launching Overrides from disable... ");
                                return flagOverrides;                
                            }
                            break;
                        }
                    default:
                        {

                            // Work around for 228291 because the MicrosoftSQLServer2008DiscoveryMPName is not imported by default
                            string intervalSec = "";
                            if(Utilities.ManagementPackExists(ManagementPackConstants.MicrosoftSQLServer2008DiscoveryMPName))
                            {
                                intervalSec = Strings.IntervalSec.ToLowerInvariant();
                            }
                            
                            if (parameterName.ToLowerInvariant() == Strings.Tolerance.ToLowerInvariant() || parameterName.ToLowerInvariant() == Strings.TimeoutSecondsFromMP.ToLowerInvariant()
                                || parameterName.ToLowerInvariant() == Strings.FrequencySeconds.ToLowerInvariant() || parameterName.ToLowerInvariant() == Strings.Threshold.ToLowerInvariant()
                                || parameterName.ToLowerInvariant() == intervalSec)
                            {
                                OverridesGrid.SetCellValue(rowPos, colPos, parameters.ParameterValuePairs[parameterName].ToString(), DataGridViewCellType.Other);
                            }
                            else
                            {
                                OverridesGrid.SetCellValue(rowPos, colPos, parameters.ParameterValuePairs[parameterName].ToString(), DataGridViewCellType.ComboBox);
                            }

                            Utilities.LogMessage("Overrides.AddOverrides:: parameter '" + parameterName + "' overridden to value '"
                                + parameters.ParameterValuePairs[parameterName].ToString() + "'");
                            break;
                        }           
                }
            }

            if (string.IsNullOrEmpty(parameters.OverrideManagementPack))
            {
                parameters.OverrideManagementPack = Core.Console.ConsoleConstants.DefaultManagementPackName;
            }

            //Select destination management pack
            if (this.overrideProperties.Controls.SelectDestinationManagementPackComboBox.IsEnabled)
            {
                this.overrideProperties.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.OverrideManagementPack);
            }

            Utilities.TakeScreenshot("AddOverrides");

            //Save the Property Page
            Sleeper.Delay(Constants.OneSecond);
            int retrycount =0;
            while (retrycount < Core.Common.Constants.DefaultMaxRetry && this.overrideProperties.Controls.ApplyButton.IsEnabled)
            {
                this.overrideProperties.ClickApply();
                this.overrideProperties.ScreenElement.WaitForReady();
                Sleeper.Delay(Constants.OneSecond * 3);
                retrycount++;
            }

            Utilities.LogMessage("Overrides.AddOverrides:: Overrides Property Saved");

            this.overrideProperties.ClickOK();
            Utilities.LogMessage("Overrides.AddOverrides:: Overrides Property page dismissed");

            //After clicking OK wait for the property page to go away
            CoreManager.MomConsole.WaitForDialogClose(this.overrideProperties, Constants.OneSecond * 60 / Constants.OneSecond);

            int retry = 0;
            int maxcount = 120;
            while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
            {
                Utilities.LogMessage("Overrides.AddOverrides:: MainWindow not Foreground, lets wait a moment.");
                Sleeper.Delay(Constants.OneSecond);
                retry++;
            }

            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout * 2);
            consoleApp.Waiters.WaitForStatusReady();

            Utilities.LogMessage("Overrides.AddOverrides:: Successfully closed the property dialog after updating");
                             
            #endregion
            return flagOverrides;
        }

        /// <summary>
        ///  Finds an override in the Override Summary View and selects it
        /// </summary>
        /// <param name="parameters">override parameters</param>
        /// <param name="overridesViewPath">path to the Overrides view</param>
        /// <param name="viewType">override view type</param>
        /// <returns>
        ///  True if the override is found and selected, False otherwise
        /// </returns>
        /// <history>
        /// </history>
        public bool FindOverride(OverridesParameters parameters, string overridesViewPath, OverrideSummaryViewType viewType)
        {
            #region Local Variables
            int overrideTargetColumnIndex;
            int contextColumnIndex;
            int overrideMPColumnIndex;
            int parameterColumnIndex;
            int overrideValueColumnIndex;
            int scopeColumnIndex;
            int enforcedColumnIndex;
            int overrideTargetTypeColumnIndex;
            int maxTries = 6;

            string currentOverrideTarget;
            string currentOverrideContext;
            string currentOverrideManagementPack;
            string currentOverrideParameter;
            string currentOverrideValue;
            string currentOverrideScope;
            string currentOverrideEnforced;
            string currentOverrideTargetType;

            string parameterName = null;
            string parameterValue = null;
            string overrideTargetType = null;
            bool overrideFound = false;
            bool disabledGrouping = false;
            #endregion // Local Variables

            #region Fetch the correct override target type resource
            switch (parameters.OverrideTargetType)
            {
                case OverrideTargetType.Diagnostics:
                    overrideTargetType = Strings.DiagnosticsObject;
                    break;

                case OverrideTargetType.Discovery:
                    overrideTargetType = Strings.DiscoveryObject;
                    break;
        
                case OverrideTargetType.Monitor:
                    overrideTargetType = Strings.MonitorObject;
                    break;

                case OverrideTargetType.Recovery:
                    overrideTargetType = Strings.RecoveryObject;
                    break;

                case OverrideTargetType.Rule:
                    overrideTargetType = Strings.RuleObject;
                    break;

                default:
                    Utilities.LogMessage("Overrides.FindOverride :: Invalid OverrideTargetType '" + parameters.OverrideTargetType + "'");
                    return false;
            }
            #endregion Fetch the correct override target type resource

            #region Navigate to Overrides Summary View
            // Navigate to Authoring. Work-around for product bug 92508
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            switch (viewType)
            {
                case OverrideSummaryViewType.Authoring:
                    if (parameters.OverrideTargetType.Equals(OverrideTargetType.Discovery))
                    {
                        // Navigate to Monitoring
                        navPane.SelectNode(NavigationPane.Strings.Monitoring, NavigationPane.NavigationTreeView.Monitoring);
                        CoreManager.MomConsole.Waiters.WaitForReady();
                    }
                    // Navigate to Authoring->Overrides
                    navPane.SelectNode(NavigationPane.Strings.Authoring, NavigationPane.NavigationTreeView.MonitoringConfiguration);

                    consoleApp.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, 60 * OneSecondInMilliSeconds);

                    Utilities.LogMessage("Overrides.FindOverride :: Navigate to Overrides Summary View: " + overridesViewPath);
                    navPane.SelectNode(overridesViewPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                    break;

                case OverrideSummaryViewType.MyWorkspace:
                    // Navigate to My Workspace->Favorite Views->View Name
                    navPane.SelectNode(NavigationPane.Strings.MyWorkspace, NavigationPane.NavigationTreeView.MyWorkspace);

                    consoleApp.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, OneSecondInMilliSeconds * 60);

                    Utilities.LogMessage("Overrides.FindOverride :: Navigate to Overrides Summary View: " + overridesViewPath);
                    navPane.SelectNode(overridesViewPath, NavigationPane.NavigationTreeView.MyWorkspace);
                    break;

                default:
                    throw new Maui.GlobalExceptions.InvalidEnumValueException("Overrides.FindOverride :: Invalid type: " + viewType.ToString());
            }

            // Wait for Window to be ready

            consoleApp.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, OneSecondInMilliSeconds * 60);


            // TODO: Verify that we have the Overrides View (by getting the title)!!!
            // For both Authoring and My Workspace
            #endregion // Navigate to Overrides Summary View

            // Disable grouping
            if (disabledGrouping == false)
            {
                DisableGroupingAndSelectAllColumns();
            }

            // retry logic
            for (int numberOfTries = 0; (false == overrideFound && numberOfTries < maxTries); ++numberOfTries)
            {
                // If we've retried at least maxTries/2 times, broaden Scoping by Override Context and try again.
                if (numberOfTries >= maxTries / 2)
                {
                    try
                    {
                        //For var1.1.3, parameters.OverrideContext is machine name, not correct target
                        if (parameters.OverrideTargetScope == null || parameters.OverrideTargetScope.Equals(string.Empty))
                        {
                            parameters.OverrideTargetScope = parameters.OverrideContext;
                        }
                        // Add Scope by override context
                        CoreManager.MomConsole.ViewPane.ChangeConsoleScope(
                            new ViewPane.TargetType[] { new ViewPane.TargetType(parameters.OverrideTargetScope, null, true) },
                            true,
                            5);
                    } 
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        // Change Scope link not found, therefore Scoping has been disabled.
                        Utilities.LogMessage("Overrides.FindOverride :: Change Scope link not found, therefore Scoping has been disabled.");
                        break;
                    }
                }

                // Narrow View by Override Target
                CoreManager.MomConsole.ViewPane.Find.LookForItem(parameters.OverrideTarget);
                Utilities.LogMessage("Overrides.FindOverride :: LookForItem: " + parameters.OverrideTarget);

                // Refresh the View
                Keyboard.SendKeys(KeyboardCodes.F5);

                // Wait for Window to be ready

                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                // Disable grouping
                if (disabledGrouping == false)
                {
                    DisableGroupingAndSelectAllColumns();
                }

                // Get grid control
                Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

                #region Get Column Title Positions
                overrideTargetColumnIndex = viewGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSummaryOverrideTarget);
                contextColumnIndex = viewGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSummaryContext);
                overrideMPColumnIndex = viewGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSummaryOverrideManagementPack);
                parameterColumnIndex = viewGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSummaryParameter);
                overrideValueColumnIndex = viewGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSummaryOverrideValue);
                scopeColumnIndex = viewGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSummaryScope);
                enforcedColumnIndex = viewGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSummaryEnforced);
                overrideTargetTypeColumnIndex = viewGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSummaryOverrideTargetType);
                #endregion // Get Column Title Positions

                #region Find Override
                if (viewGrid != null)
                {
                    for (int i = 1; i < viewGrid.Rows.Count; i++)
                    {
                        #region Get Override values
                        currentOverrideTarget = viewGrid.GetCellText(i, overrideTargetColumnIndex);
                        currentOverrideContext = viewGrid.GetCellText(i, contextColumnIndex);
                        currentOverrideManagementPack = viewGrid.GetCellText(i, overrideMPColumnIndex);
                        currentOverrideParameter = viewGrid.GetCellText(i, parameterColumnIndex);
                        currentOverrideValue = viewGrid.GetCellText(i, overrideValueColumnIndex);
                        currentOverrideScope = viewGrid.GetCellText(i, scopeColumnIndex);
                        currentOverrideEnforced = viewGrid.GetCellText(i, enforcedColumnIndex);
                        currentOverrideTargetType = viewGrid.GetCellText(i, overrideTargetTypeColumnIndex);

                        // There will only be a single parameter/value pair 
                        foreach (string parameter in parameters.ParameterValuePairs.Keys)
                        {
                            parameterName = parameter;
                            parameterValue = parameters.ParameterValuePairs[parameterName].ToString();
                        }

                        Utilities.LogMessage("Overrides.FindOverride :: comparing " + currentOverrideTarget + " to " + parameters.OverrideTarget);
                        Utilities.LogMessage("Overrides.FindOverride :: comparing " + currentOverrideContext + " to " + parameters.OverrideContext);
                        Utilities.LogMessage("Overrides.FindOverride :: comparing " + currentOverrideManagementPack + " to " + parameters.OverrideManagementPack);
                        Utilities.LogMessage("Overrides.FindOverride :: comparing " + currentOverrideParameter + " to " + parameterName);
                        Utilities.LogMessage("Overrides.FindOverride :: comparing " + currentOverrideValue + " to " + parameterValue);
                        Utilities.LogMessage("Overrides.FindOverride :: comparing " + currentOverrideScope + " to " + parameters.OverrideScope);
                        Utilities.LogMessage("Overrides.FindOverride :: comparing " + currentOverrideEnforced + " to " + parameters.OverrideEnforced);
                        Utilities.LogMessage("Overrides.FindOverride :: comparing " + currentOverrideTargetType + " to " + overrideTargetType);
                        #endregion

                        if (currentOverrideTarget.Equals(parameters.OverrideTarget, StringComparison.InvariantCultureIgnoreCase) &&
                            currentOverrideContext.Equals(parameters.OverrideContext, StringComparison.InvariantCultureIgnoreCase) &&
                            currentOverrideManagementPack.Equals(parameters.OverrideManagementPack, StringComparison.InvariantCultureIgnoreCase) &&
                            currentOverrideParameter.Equals(parameterName, StringComparison.InvariantCultureIgnoreCase) &&
                            currentOverrideValue.Equals(parameterValue, StringComparison.InvariantCultureIgnoreCase) &&
                            currentOverrideScope.Equals(parameters.OverrideScope, StringComparison.InvariantCultureIgnoreCase) &&
                            currentOverrideEnforced.Equals(parameters.OverrideEnforced, StringComparison.InvariantCultureIgnoreCase) &&
                            currentOverrideTargetType.Equals(overrideTargetType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            // Select the override by click
                            viewGrid.ClickCell(i, overrideTargetColumnIndex);

                            //Try to work around for product bug:#428146
                            viewGrid.Click();

                            // Override Found!
                            overrideFound = true;

                            Utilities.LogMessage("Overrides.FindOverride :: Override for target " + parameters.OverrideTarget + " found");
                            Utilities.LogMessage("Overrides.FindOverride :: " +
                                Core.Console.Overrides.Overrides.Strings.OverrideSummaryContext + ": " +
                                currentOverrideContext);
                            Utilities.LogMessage("Overrides.FindOverride :: " +
                                Core.Console.Overrides.Overrides.Strings.OverrideSummaryOverrideManagementPack + ": " +
                                currentOverrideManagementPack);
                            Utilities.LogMessage("Overrides.FindOverride :: " +
                                Core.Console.Overrides.Overrides.Strings.OverrideSummaryParameter + ": " +
                                currentOverrideParameter);
                            Utilities.LogMessage("Overrides.FindOverride :: " +
                                Core.Console.Overrides.Overrides.Strings.OverrideSummaryOverrideValue + ": " +
                                currentOverrideValue);
                            Utilities.LogMessage("Overrides.FindOverride :: " +
                                Core.Console.Overrides.Overrides.Strings.OverrideSummaryScope + ": " +
                                currentOverrideScope);
                            Utilities.LogMessage("Overrides.FindOverride :: " +
                                Core.Console.Overrides.Overrides.Strings.OverrideSummaryEnforced + ": " +
                                currentOverrideEnforced);
                            Utilities.LogMessage("Overrides.FindOverride :: " +
                                Core.Console.Overrides.Overrides.Strings.OverrideSummaryOverrideTargetType + ": " +
                                currentOverrideTargetType);
                            break;
                        }
                    }
                }
            } // end retry logic

            #endregion // Find Override

            return overrideFound;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">override parameters</param>
        /// <param name="overridesViewPath">path to overrides view</param>
        /// <param name="viewType">overrides view type</param>
        /// <history>
        /// </history>
        public void EditOverride(OverridesParameters parameters, string overridesViewPath, OverrideSummaryViewType viewType)
        {
            Utilities.LogMessage("Overrides.EditOverride ::");

            #region Find Override
            // Find override we want to edit
            if (FindOverride(parameters, overridesViewPath, viewType) == false)
            {
                Utilities.LogMessage("Overrides.EditOverride:: Override for target " + parameters.OverrideTarget + " not found");
                throw new Maui.GlobalExceptions.MauiException("Override for target " + parameters.OverrideTarget + " not found");
            }

            Utilities.LogMessage("Overrides.EditOverride:: Override for target " + parameters.OverrideTarget + " found");
            #endregion // Find Override

            #region Launch Override Properties dialog
            // Launch the Override Properties dialog
            // TODO: Get the Properties resource string
            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            try
            {
                taskPane.ClickLink(Core.Console.Overrides.Overrides.Strings.OverrideActionsPaneHeader,
                    Utilities.RemoveAcceleratorKeys(Core.Console.Views.Views.Strings.PropertiesContextMenu));
            }
            catch (Exception)
            {
                Keyboard.SendKeys("+{TAB}");
            }
            finally
            {
                taskPane.ClickLink(Core.Console.Overrides.Overrides.Strings.OverrideActionsPaneHeader,
                    Utilities.RemoveAcceleratorKeys(Core.Console.Views.Views.Strings.PropertiesContextMenu));
            }
            Utilities.LogMessage("Overrides.EditOverride:: Launched Override Properties dialog for target " + parameters.OverrideTarget);

            // Verify the Override Properties dialog is visible
            Core.Console.MomControls.GridControl OverridesGrid = new Core.Console.MomControls.GridControl(overrideProperties,
                Core.Console.Overrides.Dialogs.OverrideProperties.ControlIDs.DataGridView1);
            Utilities.LogMessage("Overrides.EditOverride:: Succesfully found Overrides Grid View");
            #endregion // Launch Override Properties dialog

            #region Edit Override
            // Edit the Override
            int rowPos, colPos = -1;

            rowPos = OverridesGrid.FindData(parameters.OverrideEditParameter, MomControls.GridControl.SearchStringMatchType.ExactMatch).AccessibleObject.Index;
            colPos = OverridesGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideHeader);
            Utilities.LogMessage("Overrides.EditOverride:: Row Position for Parameter: "
                + parameters.OverrideEditParameter + " is: " + rowPos);
            Utilities.LogMessage("Overrides.EditOverride:: Column Position for Header: "
                + Core.Console.Overrides.Overrides.Strings.OverrideHeader + " is: " + colPos);

            Maui.Core.WinControls.DataGridViewCheckBoxCell overrideCheckBox = 
                new Maui.Core.WinControls.DataGridViewCheckBoxCell(OverridesGrid.Rows[rowPos].Cells[colPos].AccessibleObject);

            // Check the checkbox for the parameter to be overridden
            if (overrideCheckBox.AccessibleObject.Value != "True")
            {
                overrideCheckBox.AccessibleObject.Click();
                Utilities.LogMessage("Overrides.EditOverride:: Checking Override Checkbox for parameter '" + parameters.OverrideEditParameter + "'");
            }
            else
            {
                Utilities.LogMessage("Overrides.EditOverride:: Override Checkbox for parameter '" + parameters.OverrideEditParameter + "' already checked");
            }

            colPos = OverridesGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSettingHeader);
            Utilities.LogMessage("Overrides.EditOverride:: Column Position for Header: "
                + Core.Console.Overrides.Overrides.Strings.OverrideSettingHeader + " is: " + colPos);

            // Override the parameter with the value specified
            // TODO: Add support for the following types:
            //  DataGridViewCellType.TextBox 
            //  DataGridViewCellType.NumericalSelection (don't actually know what this control is, but we need to support it!!
            Utilities.LogMessage("Overrides.EditOverride:: Setting Override parameter '" + parameters.OverrideEditParameter + "' to " + parameters.OverrideEditValue);
            OverridesGrid.SetCellValue(rowPos, colPos, parameters.OverrideEditValue.ToString(), DataGridViewCellType.ComboBox);
            Utilities.LogMessage("Overrides.EditOverride:: Set Override parameter '" + parameters.OverrideEditParameter + "' to " + parameters.OverrideEditValue);
            // Click OK to save the new override
            this.overrideProperties.ClickOK();
            #endregion // Edit Override
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">override parameters</param>
        /// <param name="overridesViewPath">path to overrides view</param>
        /// <param name="viewType">overrides view type</param>
        /// <history>
        /// </history>
        public void DeleteOverride(OverridesParameters parameters, string overridesViewPath, OverrideSummaryViewType viewType)
        {
            Utilities.LogMessage("Overrides.DeleteOverride::");

            // Find override we want to delete. FindOverride will navigate to view defined in overridesSummaryPath.
            if (FindOverride(parameters, overridesViewPath, viewType) == false)
            {
                Utilities.LogMessage("Overrides.DeleteOverride:: Override for target " + parameters.OverrideTarget + " not found");
                throw new Maui.GlobalExceptions.MauiException("Override for target " + parameters.OverrideTarget + " not found");
            }

            Utilities.LogMessage("Overrides.DeleteOverride:: Override for target " + parameters.OverrideTarget + " found");

            // Delete the override by clicking on the Actions pane link
            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            taskPane.ClickLink(Core.Console.Overrides.Overrides.Strings.OverrideActionsPaneHeader,
                Utilities.RemoveAcceleratorKeys(Core.Console.Views.Views.Strings.DeleteContextMenu));

            Utilities.LogMessage("Overrides.DeleteOverride:: Delete override for target " + parameters.OverrideTarget);

            // Confirm Override Delete
            CoreManager.MomConsole.ConfirmChoiceDialog(true);

            // Wait for Window to be ready
            // TODO: replace 60000 with appropriate constants
            consoleApp.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, OneSecondInMilliSeconds * 60);
        }

        /// <summary>
        /// Launch the override target properties dialog
        /// </summary>
        /// <param name="parameters">override parameters</param>
        /// <param name="overridesViewPath">path to the overrides view</param>
        /// <param name="viewType">overrides view type</param>
        /// <history>
        /// </history>
        public void LaunchTargetPropertiesDialog(OverridesParameters parameters, string overridesViewPath, OverrideSummaryViewType viewType)
        {
            // Find override
            if (FindOverride(parameters, overridesViewPath, viewType) == false)
            {
                Utilities.LogMessage("Overrides.LaunchTargetPropertiesDialog:: Override for target " + parameters.OverrideTarget + " not found");
                throw new Maui.GlobalExceptions.MauiException("Override for target " + parameters.OverrideTarget + " not found");
            }

            Utilities.LogMessage("Overrides.LaunchTargetPropertiesDialog:: Override for target " + parameters.OverrideTarget + " found");

            // Launch the Override Target Properties dialog
            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            taskPane.ClickLink(Core.Console.Overrides.Overrides.Strings.OverrideActionsPaneHeader,
                Core.Console.Overrides.Overrides.Strings.OverrideSummaryOverrideTargetProperties);

            Utilities.LogMessage("Overrides.LaunchTargetPropertiesDialog:: Launch Override Target Properties dialog for override with target " + parameters.OverrideTarget);

            // Wait for Window to be ready

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

        }

        /// <summary>
        ///  Create an Overrides Summary View in My Workspace
        /// </summary>
        /// <param name="name">view name</param>
        /// <param name="description">view description</param>
        /// <param name="folderName">My Workspace folder name</param>
        /// <history>
        /// </history>
        public void CreateMyWorkspaceOverridesSummaryView(string name, string description, string folderName)
        {
            Utilities.LogMessage("Overrides.CreateMyWorkspaceOverridesSummaryView::");
            switch (name)
            {
                case null:
                    throw new Maui.GlobalExceptions.MauiException("Overrides.CreateMyWorkspaceOverridesSummaryView:: name of view to create is null!");
                default:
                    break;
            }

            switch (folderName)
            {
                case null:
                    throw new Maui.GlobalExceptions.MauiException("Overrides.CreateMyWorkspaceOverridesSummaryView:: folder name to create view in is null!");
                default:
                    break;
            }

            Core.Console.Views.Views overridesView = new Core.Console.Views.Views();
            overridesView.Create(Mom.Test.UI.Core.Console.Views.ViewType.OverridesSummaryView, name, description, folderName);
        }

        /// <summary>
        ///  Disable grouping in Overrides View via Personalize.
        /// </summary>
        public void DisableGroupingAndSelectAllColumns()
        {
            Utilities.LogMessage("Overrides.DisableGrouping::");

            // Switch focus to the View Pane. Work-around for SrvMgmt #124284
            CoreManager.MomConsole.ViewPane.Controls.ViewPaneTitleStaticControl.Click();

            // Launch the Override Target Properties dialog
            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            taskPane.ClickLink(Core.Console.Overrides.Overrides.Strings.OverrideActionsPaneHeader,
                Utilities.RemoveAcceleratorKeys(Core.Console.Views.Dialogs.PersonalizeViewDialog.Strings.ContextMenuPersonalizeView));

            // Get the dialog
            Core.Console.Views.Dialogs.PersonalizeViewDialog personalizeDialog =
                new Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog(this.consoleApp);

            // Set grouping to None
            if (!personalizeDialog.Controls.GroupBy1ComboBox.Text.Equals(Core.Console.Views.Views.PersonalizeView.Strings.ColumnComboNone))
            {
                // Disable grouping
                Utilities.LogMessage("Overrides.DisableGrouping:: Disabling grouping");
                personalizeDialog.Controls.GroupBy1ComboBox.ClickDropDown();
                personalizeDialog.Controls.GroupBy1ComboBox.SelectByText(Core.Console.Views.Views.PersonalizeView.Strings.ColumnComboNone);
                Utilities.LogMessage("Overrides.DisableGrouping:: Grouping disabled");
            }

            Utilities.LogMessage("Overrides.DisableGrouping:: Select all columns to display");
            personalizeDialog.SelectAllColumnsToDisplay();

            // Grouping is already disabled
            Utilities.LogMessage("Overrides.DisableGrouping:: Click Ok button to close Personalize Dialog");
            personalizeDialog.ClickOK();

            // Wait for dialog to close
            Utilities.LogMessage("Overrides.DisableGrouping:: Wait for dialog close in one minute");
            CoreManager.MomConsole.WaitForDialogClose(personalizeDialog, Constants.OneMinute);
        }
        
            #endregion


        #region Private Methods
        
        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Overrides
        /// </summary>
        /// <history> 	
        ///   [ruhim]  07Sep06: Created. Added resource strings for Overrides 
        ///                       
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains Resource string for: Overrides button
            /// </summary>            
            private const string ResourceOverridesButton =
                ";O&verrides;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;Overrides";
                        
            /// <summary>
            /// Contains Resource string for: Parameter Name Column Header on Overrides Property dialog
            /// </summary>            
            private const string ResourceParameterNameHeader =
                ";Parameter Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;OverrideName";

            /// <summary>
            /// Contains Resource string for: Override Setting Column Header on Overrides Property dialog
            /// </summary>            
            private const string ResourceOverrideSettingHeader =
                ";Override Value;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;LocalOverrideValueColumn";
            //    ";Override Setting;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;OverrideValueColumn";
            
            /// <summary>
            /// Contains Resource string for: Override Column Header on Overrides Property dialog
            /// </summary>            
            private const string ResourceOverrideHeader =
                ";Override;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;OverrideColumn";
            
            /// <summary>
            /// Contains Resource string for: Parameter Enabled on Overrides Property dialog
            /// </summary>            
            private const string ResourceEnabledParameter =
                ";Enabled;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;Enabled";

            /// <summary>
            /// Contains Resource string for: Parameter Rollup Algorithm on Overrides Property dialog
            /// </summary>            
            private const string ResourceRollupAlgorithmParameter =
                ";Rollup Algorithm;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;Algorithm";

            /// <summary>
            /// Contains Resource string for: Parameter Generates Alert on Overrides Property dialog
            /// </summary>            
            private const string ResourceGeneratesAlertParameter =
                ";Generates Alert;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;GenerateAlert";

            /// <summary>
            /// Contains Resource string for: Parameter Auto-Resolve Alert on Overrides Property dialog
            /// </summary>            
            private const string ResourceAutoResolveAlertParameter =
                ";Auto-Resolve Alert;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;AutoResolve";

            /// <summary>
            /// Contains Resource string for: Parameter Alert Priority on Overrides Property dialog
            /// </summary>            
            private const string ResourceAlertPriorityParameter =
                ";Alert Priority;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;AlertPriority";

            /// <summary>
            /// Contains Resource string for: Parameter Alert On State on Overrides Property dialog
            /// </summary>            
            private const string ResourceAlertOnStateParameter =
                ";Alert On State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;AlertState";

            /// <summary>
            /// Contains Resource string for: Override Setting Value: True
            /// </summary>            
            private const string ResourceValueTrue =                
                 ";True;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;True";

            /// <summary>
            /// Contains Resource string for: Override Setting Value: False
            /// </summary>            
            private const string ResourceValueFalse =
                ";False;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;False";

            /// <summary>
            /// Contains Resource string for: Override Parameter: TimeoutSeconds
            /// </summary>            
            private const string ResourceTimeoutSeconds =
                ";&Timeout (in seconds):;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionPage;idLabelTimeout.Text";

            /// <summary>
            /// Contains GUID for: Test Performance Rule in Test.UI.Overrides.Management.Pack
            /// </summary>            
            public static Guid TestPerformanceRuleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(OverridesTestMPName, null, TestPerformanceRuleName);

            /// <summary>
            /// Contains GUID for: Overridable parameter: Tolerance in System.Performance.Library MP
            /// </summary>            
            public static Guid OverridableParameterToleranceGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ModuleTypeLinkedOptimizedDataProviderName, ManagementPackConstants.OverridableParameterToleranceName);

            /// <summary>
            /// Contains GUID for: Overridable parameter: Severity in System.Health.Library MP
            /// </summary>            
            public static Guid OverridableParameterSeverityGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemHealthLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemHealthGenerateAlert, ManagementPackConstants.OverridableParameterSeverityName);

            /// <summary>
            /// Contains GUID for: Overridable parameter: Priority in System.Health.Library MP
            /// </summary>            
            public static Guid OverridableParameterPriorityGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemHealthLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemHealthGenerateAlert, ManagementPackConstants.OverridableParameterPriorityName);

            /// <summary>
            /// Contains GUID for: Test Diagnostic Task in Test.UI.Overrides.Management.Pack
            /// </summary>
            public static Guid TestDiagnosticGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(OverridesTestMPName, null, TestDiagnosticId);

            /// <summary>
            /// Contains GUID for: Test Recovery Task in Test.UI.Overrides.Management.Pack
            /// </summary>
            public static Guid TestRecoveryGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(OverridesTestMPName, null, TestRecoveryId);

            /// <summary>
            /// Contains GUID for: Test Rule Task in Test.UI.Overrides.Management.Pack
            /// </summary>
            public static Guid TestRuleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(OverridesTestMPName, null, TestRuleId);

            /// <summary>
            /// Contains GUID for: Overrideable parameter 'Timeout Seconds' 
            /// for the System.CommandExecuter module in the System.Library MP
            /// </summary>
            public static Guid SystemCommandExecuterOverrideableParameterTimeoutSecondsGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemCommandExecuter, ManagementPackConstants.OverrideableParameterTimeoutSecondsName);

            /// <summary>
            /// Contains GUID for: Overrideable parameter 'Timeout Seconds' 
            /// for the System.CommandExecuterProbe module in the System.Library MP
            /// </summary>
            public static Guid SystemCommandExecuterProbeOverrideableParameterTimeoutSecondsGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemCommandExecuterProbe, ManagementPackConstants.OverrideableParameterTimeoutSecondsName);

            /// <summary>
            /// Contains GUID string for: Microsoft.SystemCenter.Process.SimpleThreshold.ErrorOnTooHigh monitor type
            /// </summary>
            public static Guid SystemCenterProcessSimpleThresholdErrorOnTooHighGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterProcessMonitoringLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, SystemCenterProcessSimpleThresholdErrorOnTooHigh);
            
            /// <summary>
            /// Contains GUID for: "Threshold" Overridableparameter in Microsoft.SystemCenter.Process.SimpleThreshold.ErrorOnTooHigh
            /// </summary>
            public static Guid ThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemCenterProcessMonitoringLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken,SystemCenterProcessSimpleThresholdErrorOnTooHigh, MonitortypeStateThreshold);

            /// <summary>
            /// Contains GUID string for: Microsoft.SystemCenter.OpsMgrDBPercentFreeSpaceMonitorType monitor type
            /// </summary>
            public static Guid SystemCenterOpsMgrDBPercentFreeSpaceMonitorTypeGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenter2007MPName, ManagementPackConstants.MomManagementPackPublicKeyToken, SystemCenterOpsMgrDBPercentFreeSpaceMonitorType);

            /// <summary>
            /// Contains GUID for: "IntervalSeconds" Overridableparameter in  Microsoft.SystemCenterOpsMgrDBPercentFreeSpaceMonitorType
            /// </summary>
            public static Guid IntervalSecondsGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemCenter2007MPName, ManagementPackConstants.MomManagementPackPublicKeyToken, SystemCenterOpsMgrDBPercentFreeSpaceMonitorType, IntervalSeconds);

            /// <summary>
            /// Contains GUID for: "Interval (sec)" Overridableparameter in  Microsoft.SystemCenterOpsMgrDBPercentFreeSpaceMonitorType
            /// </summary>
            public static Guid IntervalSecGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftSQLServer2008DiscoveryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, SQLServer2008DBDiscovery, IntervalSeconds);

            /// <summary>
            ///  Contains ID for: "Timeout Seconds" in MoniotorType Overridableparameter Table
            /// </summary>
            public static Guid TimeoutSecondsGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemCenter2007MPName, ManagementPackConstants.MomManagementPackPublicKeyToken, SystemCenterOpsMgrDBPercentFreeSpaceProvider, ManagementPackConstants.OverrideableParameterTimeoutSecondsName);
            
            /// <summary>
            /// Contains System Name for: Microsoft.SystemCenter.Process.SimpleThreshold.ErrorOnTooHigh
            /// </summary>
            public const string SystemCenterProcessSimpleThresholdErrorOnTooHigh = "Microsoft.SystemCenter.Process.SimpleThreshold.ErrorOnTooHigh";
            
            /// <summary>
            /// Contains ID for: "Threshold" in MoniotorType Overridableparameter Table
            /// </summary>
            public const string MonitortypeStateThreshold = "Threshold";

            /// <summary>
            ///  Contains System Name for: Microsoft.SystemCenterOpsMgrDBPercentFreeSpaceMonitorType
            /// </summary>
            public const string SystemCenterOpsMgrDBPercentFreeSpaceMonitorType = "Microsoft.SystemCenter.OpsMgrDBPercentFreeSpaceMonitorType";
           
            /// <summary>
            /// Contains System Name for: Microsoft.SystemCenter.OpsMgrDBPercentFreeSpaceProvider
            /// </summary>
            public const string SystemCenterOpsMgrDBPercentFreeSpaceProvider ="Microsoft.SystemCenter.OpsMgrDBPercentFreeSpaceProvider";

            /// <summary>
            /// Contains System Name for: Microsoft.SQLServer.2008.DBEngineDiscovery
            /// </summary>
            public const string SQLServer2008DBDiscovery = "Microsoft.SQLServer.2008.DBDiscovery";

            /// <summary>
            /// Contains ID for: IntervalSeconds
            /// </summary>
            public const string IntervalSeconds = "IntervalSeconds";

            #region Override Flyout Menu Resources

            /// <summary>
            /// Contains Resource string for: Flyout Menu Override the Rule/Monitor
            /// </summary>            
            private const string ResourceFlyoutMenuOverride =
                ";&Override the {0};ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;OverrideCommandTextFormat";

            /// <summary>
            ///  Contains Resource string for: Flyout Menu Override Diagnostic
            /// </summary>
            private const string ResourceFlyoutMenuOverrideDiagnostic =
                ";Override Diag&nostic;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;OverrideDiagnosticGroup";

            /// <summary>
            ///  Contains Resource string for: Flyout Menu Override Recovery
            /// </summary>
            private const string ResourceFlyoutMenuOverrideRecovery =
                ";Override Recover&y;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;OverrideRecoveryGroup";

            /// <summary>
            /// Contains Resource string for: Flyout Menu Disable the Rule/Monitor
            /// </summary>            
            private const string ResourceFlyoutMenuDisable =
                ";&Disable the {0};ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;OverrideDisableCommandTextFormat";

            /// <summary>
            /// Contains Resource string for: Flyout Menu "For the object:"
            /// </summary>            
            private const string ResourceFlyoutForCurrentInstance  =
                ";F&or the object: {0};ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;ForCurrentInstance";

            /// <summary>
            /// Contains Resource string for: Flyout Menu For all objects of type
            /// </summary>            
            private const string ResourceFlyoutForCurrentTypeFormat =
                ";For all objects of &class: {0};ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;ForCurrentTypeFormat";

            /// <summary>
            /// Contains Resource string for: Flyout Menu For a group
            /// </summary>            
            private const string ResourceFlyoutForSelectedGroup =
                ";For a &group...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;ForSelectedGroup";

            /// <summary>
            /// Contains Resource string for: Flyout Menu For a specific object of type:
            /// </summary>            
            private const string ResourceFlyoutForSelectedInstanceFormat =
                ";&For a specific object of class: {0};ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;ForSelectedInstanceFormat";

            /// <summary>
            /// Contains Resource string for: Flyout Menu For all objects of another type
            /// </summary>            
            private const string ResourceFlyoutForOtherClass =
                ";For all objects of a&nother class...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;ForOtherClass";

            /// <summary>
            /// Contains Resource string for: Flyout Menu For Summary
            /// </summary>            
            private const string ResourceSummaryContextMenu =
                ";S&ummary;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;SummaryCommand";
            
            #endregion //Override Flyout Menu Resources

            #region Override Summary View Resources

            /// <summary>
            ///  Contains Resource string for: Override Summary View title
            /// </summary>
            private const string ResourceOverrideSummaryTitle = "";

            /// <summary>
            ///  Contains Resource string for: Override Target column
            /// </summary>
            private const string ResourceOverrideSummaryOverrideTarget = 
                ";Override Target;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;OverrideTargetColumn";

            /// <summary>
            ///  Contains Resource string for: Context column
            /// </summary>
            private const string ResourceOverrideSummaryContext =
                ";Context;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;ContextColumn";

            /// <summary>
            ///  Contains Resource string for: Override Management Pack column
            /// </summary>
            private const string ResourceOverrideSummaryOverrideManagementPack =
                ";Override Management Pack;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;OverrideManagementPackColumn";

            /// <summary>
            ///  Contains Resource string for: Parameter column
            /// </summary>
            private const string ResourceOverrideSummaryParameter =
                ";Parameter;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;ParameterColumn";

            /// <summary>
            ///  Contains Resource string for: Default Value column
            /// </summary>
            private const string ResourceOverrideSummaryDefaultValue =
                ";Default Value;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;DefaultValueColumn";

            /// <summary>
            ///  Contains Resource string for: Override Value column
            /// </summary>
            private const string ResourceOverrideSummaryOverrideValue =
                ";Override Value;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;LocalOverrideValueColumn";

            /// <summary>
            ///  Contains Resource string for: Scope column
            /// </summary>
            private const string ResourceOverrideSummaryScope =
                ";Scope;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;ScopeColumn";

            /// <summary>
            ///  Contains Resource string for: Override Target Type column
            /// </summary>
            private const string ResourceOverrideSummaryOverrideTargetType =
                //";Category;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;OverrideTargetTypeColumn";
                ";Management Pack Object Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;OverrideTargetTypeColumn";

            /// <summary>
            ///  Contains Resource string for: Enforced column
            /// </summary>
            private const string ResourceOverrideSummaryEnforced =
                ";Enforced;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;EnforcedColumn";

            /// <summary>
            ///  Contains Resource string for: Target column
            /// </summary>
            private const string ResourceOverrideSummaryTarget =
                ";Target;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;TargetColumn";

            /// <summary>
            ///  Contains Resource string for: Target Management Pack column
            /// </summary>
            private const string ResourceOverrideSummaryTargetManagementPack =
                ";Target Management Pack;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;TargetManagementPackColumn";

            /// <summary>
            ///  Contains Resource string for: Override Target Management Pack column
            /// </summary>
            private const string ResourceOverrideSummaryOverrideTargetManagementPack =
                ";Override Target Management Pack;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;OverrideTargetManagementPackColumn";

            /// <summary>
            ///  Contains Resource string for: Created column
            /// </summary>
            private const string ResourceOverrideSummaryCreated =
                ";Created;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;CreatedDateColumn";

            /// <summary>
            ///  Contains Resource string for: Actions Pane Override header
            /// </summary>
            private const string ResourceOverrideActionsPaneHeader =
                ";Override;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;OverrideTaskGroup";

            /// <summary>
            ///  Contains Resource string for: Actions Pane link Override Target Properties
            /// </summary>
            private const string ResourceOverrideSummaryOverrideTargetProperties =
                ";Override Target Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;ShowOverrideTargetProperties";

            /// <summary>
            ///  Contains Resource string for: Actions Pane link Delete
            /// </summary>
            private const string ResourceOverrideSummaryDeleteOverride =
                ";Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;DeleteOverride";

            /// <summary>
            /// Contains Resource string for: Rule Object in the Overrides view
            /// </summary>
            private const string ResourceRuleObject = ";Rule;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;RuleObject";

            /// <summary>
            /// Contains Resource string for: Monitor Object in the Overrides view
            /// </summary>
            private const string ResourceMonitorObject = ";Monitor;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;MonitorObject";

            /// <summary>
            /// Contains Resource string for: Diagnostics Object in the Overrides view
            /// </summary>
            private const string ResourceDiagnosticsObject = ";Diagnostic;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;DiagnosticsObject";

            /// <summary>
            /// Contains Resource string for: Discovery Object in the Overrides view
            /// </summary>
            private const string ResourceDiscoveryObject = ";Object Discovery;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;DiscoveryObject";

            /// <summary>
            /// Contains Resource string for: Recovery Object in the Overrides view
            /// </summary>
            private const string ResourceRecoveryObject = ";Recovery;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;RecoveryObject";

            /// <summary>
            /// Contains Resource string for: Overrides Summary Dialog Title
            /// </summary>
            private const string ResourceOverridesSummaryDialogTitle =
                ";Overrides Summary;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Overrides.OverridesSummary;$this.Text";
           
            /// <summary>
            /// Contains Resource string for: Overrides Summary Name Header
            /// </summary>
            private const string ResourceOverridesSummaryNameHeader =
                ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Overrides.OverridesSummary;nameHeader.Text";

            #endregion // Override Summary View Resources

            #region General Resources

            //ObjectScope
            /// <summary>
            ///  Contains Resource string for: Object scope column
            /// </summary>
            private const string ResourceObjectScope =
                ";Object;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;ObjectContext";

            /// <summary>
            ///  Contains Resource string for: Class scope column
            /// </summary>
            private const string ResourceClassScope =
                ";Class;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverridesView.OverridesViewResources;ContextTargetColumn";

            /// <summary>
            ///  Contains Resource string for: Group scope column
            /// </summary>
            private const string ResourceGroupScope =
                ";Group;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;GroupContext";

            #endregion

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Overrides button
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverridesButton;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: OverridesWindowCaption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverridesWindowCaption;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Parameter Name Column Header on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParameterNameHeader;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Override Setting Column Header on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverrideSettingHeader;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Override Column Header on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverrideHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Parameter Enabled on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnabledParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Parameter Rollup Algorithm on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRollupAlgorithmParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Parameter Generates Alert on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneratesAlertParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Parameter Auto-Resolve Alert on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoResolveAlertParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Parameter Alert Priority on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPriorityParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Parameter Alert On State on Overrides Property dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertOnStateParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Override Setting Value: True
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedValueTrue;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Override Setting Value: False
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedValueFalse;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Override Parameter: Timeout Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeoutSeconds;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Threshold" Overridableparameter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThreshold;

            /// <summary>
            /// Caches the translated resource string for: "Tolerance" Overridableparameter
            /// </summary>
            private static string cachedTolerance;

            /// <summary>
            /// Caches the translated resource string for: "Frequency (Seconds)" Overridableparameter
            /// </summary>
            private static string cachedFrequencySeconds;

            /// <summary>
            /// Caches the translated resource string for: "Interval (sec)" Overridableparameter
            /// </summary>
            private static string cachedIntervalSeconds;

            /// <summary>
            /// Caches the translated resource string for: "Timeout Seconds" Overridableparameter
            /// </summary>
            private static string cachedTimeoutSecondsFromMP;
            #region Override Flyout Menu 

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Flyout Menu Override the Rule/Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFlyoutMenuOverride;

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Caches the translated resource string for: Flyout Menu Override Diagnostic
            /// </summary>
            /// /// -----------------------------------------------------------------------------
            private static string cachedFlyoutMenuOverrideDiagnostic;

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Caches the translated resource string for: Flyout Menu Override Recovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFlyoutMenuOverrideRecovery;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Flyout Menu Disable the Rule/Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFlyoutMenuDisable;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Flyout Menu "For the object:"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFlyoutForCurrentInstance ;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Flyout Menu For all objects of type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFlyoutForCurrentTypeFormat;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Flyout Menu For a group
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFlyoutForSelectedGroup;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Flyout Menu For a specific object of type:
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFlyoutForSelectedInstanceFormat;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Flyout Menu For all objects of another type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFlyoutForOtherClass;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Flyout Menu For Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummaryContextMenu;

            #endregion //Override Flyout Menu

            #region Override Summary View 

            /// <summary>
            ///  Caches the translated resource string for: Override Summary View title
            /// </summary>
            private static string cachedOverrideSummaryTitle;

            /// <summary>
            ///  Caches the translated resource string for: Override Target column
            /// </summary>
            private static string cachedOverrideSummaryOverrideTarget;

            /// <summary>
            ///  Caches the translated resource string for: Context column
            /// </summary>
            private static string cachedOverrideSummaryContext;

            /// <summary>
            ///  Caches the translated resource string for: Override Management Pack column
            /// </summary>
            private static string cachedOverrideSummaryOverrideManagementPack;

            /// <summary>
            ///  Caches the translated resource string for: Parameter column
            /// </summary>
            private static string cachedOverrideSummaryParameter;

            /// <summary>
            ///  Caches the translated resource string for: Default Value column
            /// </summary>
            private static string cachedOverrideSummaryDefaultValue;

            /// <summary>
            ///  Caches the translated resource string for: Override Value column
            /// </summary>
            private static string cachedOverrideSummaryOverrideValue;

            /// <summary>
            ///  Caches the translated resource string for: Scope column
            /// </summary>
            private static string cachedOverrideSummaryScope;

            /// <summary>
            ///  Caches the translated resource string for: Override Target Type column
            /// </summary>
            private static string cachedOverrideSummaryOverrideTargetType;

            /// <summary>
            ///  Caches the translated resource string for: Enforced column
            /// </summary>
            private static string cachedOverrideSummaryEnforced;

            /// <summary>
            ///  Caches the translated resource string for: Target column
            /// </summary>
            private static string cachedOverrideSummaryTarget;

            /// <summary>
            ///  Caches the translated resource string for: Target Management Pack column
            /// </summary>
            private static string cachedOverrideSummaryTargetManagementPack;

            /// <summary>
            ///  Caches the translated resource string for: Override Target Management Pack column
            /// </summary>
            private static string cachedOverrideSummaryOverrideTargetManagementPack;

            /// <summary>
            ///  Caches the translated resource string for: Created column
            /// </summary>
            private static string cachedOverrideSummaryCreated;

            /// <summary>
            ///  Caches the translated resource string for: Actions Pane Override header
            /// </summary>
            private static string cachedOverrideActionsPaneHeader;

            /// <summary>
            ///  Caches the translated resource string for: Override Target Properties
            /// </summary>
            private static string cachedOverrideSummaryOverrideTargetProperties;

            /// <summary>
            ///  Caches the translated resource string for: Delete
            /// </summary>
            private static string cachedOverrideSummaryDeleteOverride;

            /// <summary>
            ///  Caches the translated resource string for: Rule
            /// </summary>
            private static string cachedRuleObject;

            /// <summary>
            ///  Caches the translated resource string for: Monitor
            /// </summary>
            private static string cachedMonitorObject;

            /// <summary>
            ///  Caches the translated resource string for: Diagnostics
            /// </summary>
            private static string cachedDiagnosticsObject;

            /// <summary>
            ///  Caches the translated resource string for: Discovery
            /// </summary>
            private static string cachedDiscoveryObject;

            /// <summary>
            ///  Caches the translated resource string for: Recovery
            /// </summary>
            private static string cachedRecoveryObject;

            /// <summary>
            ///  Caches the translated resource string for: Overrides Summary Dialog Title
            /// </summary>
            private static string cachedOverridesSummaryDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Overrides Summary Name Header
            /// </summary>
            private static string cachedOverridesSummaryNameHeader;

            #endregion // Override Summary View

            #region General Resources

            /// <summary>
            ///  Caches the translated resource string for: Object scope column
            /// </summary>
            private static string cachedObjectScope;

            /// <summary>
            ///  Caches the translated resource string for: Class scope column
            /// </summary>
            private static string cachedClassScope;

            /// <summary>
            ///  Caches the translated resource string for: Group scope column
            /// </summary>
            private static string cachedGroupScope;

            #endregion

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to OverridesWindowCaption
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OverridesWindowCaption
            {
                get
                {
                    if ((cachedOverridesWindowCaption == null))
                    {
                        cachedOverridesWindowCaption = CoreManager.MomConsole.GetIntlStr(ResourceOverridesButton);
                    }
                    return cachedOverridesWindowCaption;                    
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Overrides button
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OverridesButton
            {
                get
                {
                    if ((cachedOverridesButton == null))
                    {
                        cachedOverridesButton = CoreManager.MomConsole.GetIntlStr(ResourceOverridesButton);
                    }                                                         
                   return (cachedOverridesButton.Replace("&","")); 
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Parameter Name Column Header on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ParameterNameHeader
            {
                get
                {
                    if ((cachedParameterNameHeader == null))
                    {
                        cachedParameterNameHeader = CoreManager.MomConsole.GetIntlStr(ResourceParameterNameHeader);
                    }

                    return cachedParameterNameHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Setting Column Header on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OverrideSettingHeader
            {
                get
                {
                    if ((cachedOverrideSettingHeader == null))
                    {
                        cachedOverrideSettingHeader = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSettingHeader);
                    }

                    return cachedOverrideSettingHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Column Header on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OverrideHeader
            {
                get
                {
                    if ((cachedOverrideHeader == null))
                    {
                        cachedOverrideHeader = CoreManager.MomConsole.GetIntlStr(ResourceOverrideHeader);
                    }

                    return cachedOverrideHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Parameter Enabled on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnabledParameter
            {
                get
                {
                    if ((cachedEnabledParameter == null))
                    {
                        cachedEnabledParameter = CoreManager.MomConsole.GetIntlStr(ResourceEnabledParameter);
                    }

                    return cachedEnabledParameter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Parameter Rollup Algorithm on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RollupAlgorithmParameter
            {
                get
                {
                    if ((cachedRollupAlgorithmParameter == null))
                    {
                        cachedRollupAlgorithmParameter = CoreManager.MomConsole.GetIntlStr(ResourceRollupAlgorithmParameter);
                    }

                    return cachedRollupAlgorithmParameter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Parameter Generates Alert on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneratesAlertParameter
            {
                get
                {
                    if ((cachedGeneratesAlertParameter == null))
                    {
                        cachedGeneratesAlertParameter = CoreManager.MomConsole.GetIntlStr(ResourceGeneratesAlertParameter);
                    }

                    return cachedGeneratesAlertParameter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Parameter Auto-Resolve Alert on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoResolveAlertParameter
            {
                get
                {
                    if ((cachedAutoResolveAlertParameter == null))
                    {
                        cachedAutoResolveAlertParameter = CoreManager.MomConsole.GetIntlStr(ResourceAutoResolveAlertParameter);
                    }

                    return cachedAutoResolveAlertParameter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Parameter Alert Priority on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertPriorityParameter
            {
                get
                {
                    if ((cachedAlertPriorityParameter == null))
                    {
                        cachedAlertPriorityParameter = CoreManager.MomConsole.GetIntlStr(ResourceAlertPriorityParameter);
                    }

                    return cachedAlertPriorityParameter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Parameter Alert On State Parameter on Overrides Property dialog
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertOnStateParameter
            {
                get
                {
                    if ((cachedAlertOnStateParameter == null))
                    {
                        cachedAlertOnStateParameter = CoreManager.MomConsole.GetIntlStr(ResourceAlertOnStateParameter);
                    }

                    return cachedAlertOnStateParameter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Setting Value: True
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ValueTrue
            {
                get
                {
                    if ((cachedValueTrue == null))
                    {
                        cachedValueTrue = CoreManager.MomConsole.GetIntlStr(ResourceValueTrue);
                    }

                    return cachedValueTrue;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Setting Value: False
            /// </summary>
            /// <history>
            /// 	[ruhim] 15Feb07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ValueFalse
            {
                get
                {
                    if ((cachedValueFalse == null))
                    {
                        cachedValueFalse = CoreManager.MomConsole.GetIntlStr(ResourceValueFalse);
                    }

                    return cachedValueFalse;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Target Type: Rule
            /// </summary>
            /// <history>
            /// 	[nathd] 26Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleObject
            {
                get
                {
                    if ((cachedRuleObject == null))
                    {
                        cachedRuleObject = CoreManager.MomConsole.GetIntlStr(ResourceRuleObject);
                    }

                    return cachedRuleObject;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Target Type: Monitor
            /// </summary>
            /// <history>
            /// 	[nathd] 26Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorObject
            {
                get
                {
                    if ((cachedMonitorObject == null))
                    {
                        cachedMonitorObject = CoreManager.MomConsole.GetIntlStr(ResourceMonitorObject);
                    }

                    return cachedMonitorObject;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Target Type: Diagnostics
            /// </summary>
            /// <history>
            /// 	[nathd] 26Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticsObject
            {
                get
                {
                    if ((cachedDiagnosticsObject == null))
                    {
                        cachedDiagnosticsObject = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticsObject);
                    }

                    return cachedDiagnosticsObject;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Target Type: Discovery
            /// </summary>
            /// <history>
            /// 	[nathd] 26Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryObject
            {
                get
                {
                    if ((cachedDiscoveryObject == null))
                    {
                        cachedDiscoveryObject = CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryObject);
                    }

                    return cachedDiscoveryObject;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Target Type: Recovery
            /// </summary>
            /// <history>
            /// 	[nathd] 26Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecoveryObject
            {
                get
                {
                    if ((cachedRecoveryObject == null))
                    {
                        cachedRecoveryObject = CoreManager.MomConsole.GetIntlStr(ResourceRecoveryObject);
                    }

                    return cachedRecoveryObject;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Override Parameter: Timeout Seconds
            /// </summary>
            /// <history>
            /// 	[nathd] 12Apr09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeoutSeconds
            {
                get
                {
                    if ((cachedTimeoutSeconds == null))
                    {
                        cachedTimeoutSeconds = CoreManager.MomConsole.GetIntlStr(ResourceTimeoutSeconds);
                    }

                    return cachedTimeoutSeconds;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Threshold" Overridableparameter translated resource string,
            /// Get "Threshold " resource string from Microsoft.SystemCenter.ProcessMonitoring.Library MP
            /// </summary>        
            /// -----------------------------------------------------------------------------
            public static string Threshold
            {
                get
                {
                    if ((cachedThreshold == null))
                    {
                        cachedThreshold = Utilities.GetMonitorOverrideableParameterName(SystemCenterProcessSimpleThresholdErrorOnTooHighGUID, ThresholdGuid);
                    }

                    return cachedThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Tolerance" Overridableparameter translated resource string,
            /// Get "Tolerance " resource string from Test.UI.Overrides.Management.Pack MP
            /// </summary>        
            /// -----------------------------------------------------------------------------
            public static string Tolerance
            {
                get
                {
                    if ((cachedTolerance == null))
                    {
                        cachedTolerance = Utilities.GetMonitorDataSourceModuleTypeOverrideParameterName(ManagementPackConstants.GUIDSystemPerformanceLibraryMP, ManagementPackConstants.ModuleTypeLinkedOptimizedDataProviderName, OverridableParameterToleranceGUID);
                    }
                    return cachedTolerance;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Frequency (Seconds£©" Overridableparameter translated resource string,
            /// Get "Frequency (Seconds£© " resource string from Microsoft.SystemCenter.2007 MP
            /// </summary>        
            /// -----------------------------------------------------------------------------
            public static string FrequencySeconds
            {
                get
                {
                    if ((cachedFrequencySeconds == null))
                    {
                        cachedFrequencySeconds = Utilities.GetMonitorOverrideableParameterName(SystemCenterOpsMgrDBPercentFreeSpaceMonitorTypeGuid, IntervalSecondsGUID);
                    }
                    return cachedFrequencySeconds;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Interval (sec)" Overridableparameter translated resource string,
            /// Get "Interval (sec)" resource string from "Microsoft.SQLServer.2008.Discovery"  MP
            /// </summary>        
            /// -----------------------------------------------------------------------------
            public static string IntervalSec
            {
                get
                {
                    if ((cachedIntervalSeconds == null))
                    {
                        cachedIntervalSeconds = Utilities.GetMonitorDataSourceModuleTypeOverrideParameterName(ManagementPackConstants.GUIDMicrosoftSQLServer2008DiscoveryMP, SQLServer2008DBDiscovery, IntervalSecGUID);
                    }
                    return cachedIntervalSeconds;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "TimeoutSeconds" Overridableparameter translated resource string,
            /// Get "TimeoutSeconds " resource string from Microsoft.SystemCenter.2007 MP
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string TimeoutSecondsFromMP
            {
                get
                {
                    if ((cachedTimeoutSecondsFromMP == null))
                    {
                        cachedTimeoutSecondsFromMP = Utilities.GetMonitorDataSourceModuleTypeOverrideParameterName(ManagementPackConstants.GUIDSystemCenter2007MP, SystemCenterOpsMgrDBPercentFreeSpaceProvider, TimeoutSecondsGUID);                       
                    }
                    return cachedTimeoutSecondsFromMP;
                }
            }

            #region Override Flyout Menu

            /// ------------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Flyout Menu Override the Rule/Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutMenuOverride
            {
                get
                {
                    if ((cachedFlyoutMenuOverride == null))
                    {
                        cachedFlyoutMenuOverride = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutMenuOverride);
                    }
                    
                    //The original logic below failed on German becasue the translated string started with {0}
                    //Instead of ending with it
                    //int index = cachedFlyoutMenuOverride.IndexOf("{0}");
                    ////Adding a * in the end so that ExecuteContextMenu does a wildcard match
                    //return (cachedFlyoutMenuOverride.Remove(index) + "*"); 


                    // Hack to work around PS issues (SrvMgmt #121971)
                    int index = cachedFlyoutMenuOverride.IndexOf("{0}");

                    // Remove "{0}" if it is the first or last character in the resource string
                    if (index == 0 || index == cachedFlyoutMenuOverride.Length - 1)
                    {
                        return ("*" + cachedFlyoutMenuOverride.Replace("{0}", "") + "*");
                    }
                    // Remove "{0}" and all characters after the "{0}"
                    else
                    {
                        return ("*" + cachedFlyoutMenuOverride.Remove(index, cachedFlyoutMenuOverride.Length - index) + "*");
                    }
                }
            }

            /// ------------------------------------------------------------------------------
            /// <summary>
            ///  Exposes access to Flyout Menu Override Diagnostic
            /// </summary>
            /// <history>
            /// 	[nathd] 04Sep08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutMenuOverrideDiagnostic
            {
                get
                {
                    if ((cachedFlyoutMenuOverrideDiagnostic == null))
                    {
                        cachedFlyoutMenuOverrideDiagnostic = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutMenuOverrideDiagnostic);
                    }

                    return cachedFlyoutMenuOverrideDiagnostic;
                }
            }

            /// ------------------------------------------------------------------------------
            /// <summary>
            ///  Exposes access to Flyout Menu Override Recovery
            /// </summary>
            /// <history>
            /// 	[nathd] 04Sep08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutMenuOverrideRecovery
            {
                get
                {
                    if ((cachedFlyoutMenuOverrideRecovery == null))
                    {
                        cachedFlyoutMenuOverrideRecovery = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutMenuOverrideRecovery);
                    }

                    return cachedFlyoutMenuOverrideRecovery;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Flyout Menu Disable the Rule/Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutMenuDisable
            {
                get
                {
                    if ((cachedFlyoutMenuDisable == null))
                    {
                        cachedFlyoutMenuDisable = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutMenuDisable);
                    }
                    
                    int index = cachedFlyoutMenuDisable.IndexOf("{0}");
                    //Adding a * in the end so that ExecuteContextMenu does a wildcard match
                    return (cachedFlyoutMenuDisable.Remove(index) + "*");                    
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Flyout Menu "For the object:"
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutForCurrentInstance 
            {
                get
                {
                    if ((cachedFlyoutForCurrentInstance  == null))
                    {
                        cachedFlyoutForCurrentInstance  = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutForCurrentInstance );
                    }

                    int index = cachedFlyoutForCurrentInstance .IndexOf("{0}");
                    //Adding a * in the end so that ExecuteContextMenu does a wildcard match
                    return (cachedFlyoutForCurrentInstance.Remove(index) + "*");
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Flyout Menu For all objects of type
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutForCurrentTypeFormat
            {
                get
                {
                    if ((cachedFlyoutForCurrentTypeFormat == null))
                    {
                        cachedFlyoutForCurrentTypeFormat = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutForCurrentTypeFormat);
                    }

                    // Detect if we are fetching a Japanese/Chinese resource
                    // Hack to select the correct flyout option if we are using a JA/ZH machine
                    if ((System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ja" &&
                        cachedFlyoutForCurrentTypeFormat.Contains("(")) ||
                        (System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "zh" &&
                        cachedFlyoutForCurrentTypeFormat.Contains("(")))
                    {
                        // Get the index of the first parenthese to get access key string (eg "(&F)")
                        int index = cachedFlyoutForCurrentTypeFormat.IndexOf('(');
                        // This format will only be at the end of the JA/ZH resource string

                        return ("*" + cachedFlyoutForCurrentTypeFormat.Substring(index, 4));

                    }
                    else  // If this is any other Language machine
                    {
                        int index = cachedFlyoutForCurrentTypeFormat.IndexOf("{0}");
                        //Adding a * in the end so that ExecuteContextMenu does a wildcard match
                        return (cachedFlyoutForCurrentTypeFormat.Remove(index) + "*");
                        //return (cachedFlyoutForSelectedInstanceFormat);
                    }
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Flyout Menu For a group
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutForSelectedGroup
            {
                get
                {
                    if ((cachedFlyoutForSelectedGroup == null))
                    {
                        cachedFlyoutForSelectedGroup = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutForSelectedGroup);
                    }

                    return (cachedFlyoutForSelectedGroup);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Flyout Menu For a specific object of type:
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Sep06 Created
            ///     [a-joelj] 20FEB09 Added Hack to select the correct flyout option if we are using a JA machine
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutForSelectedInstanceFormat
            {
                get
                {
                    if ((cachedFlyoutForSelectedInstanceFormat == null))
                    {
                        cachedFlyoutForSelectedInstanceFormat = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutForSelectedInstanceFormat);
                    }

                    // Detect if we are fetching a Japanese/Chinese resource
                    // Hack to select the correct flyout option if we are using a JA/ZH machine
                    if ((System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ja" &&
                        cachedFlyoutForSelectedInstanceFormat.Contains("(")) || 
                        (System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "zh" &&
                        cachedFlyoutForSelectedInstanceFormat.Contains("(")))
                    {
                        // Get the index of the first parenthese to get access key string (eg "(&F)")
                        int index = cachedFlyoutForSelectedInstanceFormat.IndexOf('(');
                        // This format will only be at the end of the JA/ZH resource string

                        return ("*" + cachedFlyoutForSelectedInstanceFormat.Substring(index, 4));

                    }
                    else  // If this is any other Language machine
                    {
                        int index = cachedFlyoutForSelectedInstanceFormat.IndexOf("{0}");
                        //Adding a * in the end so that ExecuteContextMenu does a wildcard match
                        return (cachedFlyoutForSelectedInstanceFormat.Remove(index) + "*");
                        //return (cachedFlyoutForSelectedInstanceFormat);
                    }
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Flyout Menu For all objects of another type
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Sep06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FlyoutForOtherClass
            {
                get
                {
                    if ((cachedFlyoutForOtherClass == null))
                    {
                        cachedFlyoutForOtherClass = CoreManager.MomConsole.GetIntlStr(ResourceFlyoutForOtherClass);
                    }
                    return (cachedFlyoutForOtherClass);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Flyout Menu For Summary
            /// </summary>
            /// <history>
            /// 	[v-cheli] 20Mar09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SummaryContextMenu
            {
                get
                {
                    if (cachedSummaryContextMenu == null)
                    {
                        cachedSummaryContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceSummaryContextMenu);
                    }
                    return cachedSummaryContextMenu;
                }
                
            }
            #endregion //Override Flyout Menu

            #region Override Summary View

            /// <summary>
            ///  Exposes access to Overrides Summary View - Title
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryTitle
            {
                get
                {
                    if ((cachedOverrideSummaryTitle == null))
                    {
                        cachedOverrideSummaryTitle = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryTitle);
                    }
                    return (cachedOverrideSummaryTitle);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Override Target
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryOverrideTarget
            {
                get
                {
                    if ((cachedOverrideSummaryOverrideTarget == null))
                    {
                        cachedOverrideSummaryOverrideTarget = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryOverrideTarget);
                    }
                    return (cachedOverrideSummaryOverrideTarget);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Context
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryContext
            {
                get
                {
                    if ((cachedOverrideSummaryContext == null))
                    {
                        cachedOverrideSummaryContext = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryContext);
                    }
                    return (cachedOverrideSummaryContext);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Override Management Pack
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryOverrideManagementPack
            {
                get
                {
                    if ((cachedOverrideSummaryOverrideManagementPack == null))
                    {
                        cachedOverrideSummaryOverrideManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryOverrideManagementPack);
                    }
                    return (cachedOverrideSummaryOverrideManagementPack);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Parameter
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryParameter
            {
                get
                {
                    if ((cachedOverrideSummaryParameter == null))
                    {
                        cachedOverrideSummaryParameter = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryParameter);
                    }
                    return (cachedOverrideSummaryParameter);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Default Value
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryDefaultValue
            {
                get
                {
                    if ((cachedOverrideSummaryDefaultValue == null))
                    {
                        cachedOverrideSummaryDefaultValue = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryDefaultValue);
                    }
                    return (cachedOverrideSummaryDefaultValue);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Override Value
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryOverrideValue
            {
                get
                {
                    if ((cachedOverrideSummaryOverrideValue == null))
                    {
                        cachedOverrideSummaryOverrideValue = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryOverrideValue);
                    }
                    return (cachedOverrideSummaryOverrideValue);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Scope
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryScope
            {
                get
                {
                    if ((cachedOverrideSummaryScope == null))
                    {
                        cachedOverrideSummaryScope = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryScope);
                    }
                    return (cachedOverrideSummaryScope);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Override Target Type
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryOverrideTargetType
            {
                get
                {
                    if ((cachedOverrideSummaryOverrideTargetType == null))
                    {
                        cachedOverrideSummaryOverrideTargetType = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryOverrideTargetType);
                    }
                    return (cachedOverrideSummaryOverrideTargetType);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Enforced
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryEnforced
            {
                get
                {
                    if ((cachedOverrideSummaryEnforced == null))
                    {
                        cachedOverrideSummaryEnforced = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryEnforced);
                    }
                    return (cachedOverrideSummaryEnforced);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Target
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryTarget
            {
                get
                {
                    if ((cachedOverrideSummaryTarget == null))
                    {
                        cachedOverrideSummaryTarget = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryTarget);
                    }
                    return (cachedOverrideSummaryTarget);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Target Management Pack
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryTargetManagementPack
            {
                get
                {
                    if ((cachedOverrideSummaryTargetManagementPack == null))
                    {
                        cachedOverrideSummaryTargetManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryTargetManagementPack);
                    }
                    return (cachedOverrideSummaryTargetManagementPack);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View - Override Target Management Pack
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryOverrideTargetManagementPack
            {
                get
                {
                    if ((cachedOverrideSummaryOverrideTargetManagementPack == null))
                    {
                        cachedOverrideSummaryOverrideTargetManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryOverrideTargetManagementPack);
                    }
                    return (cachedOverrideSummaryOverrideTargetManagementPack);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View Override - Created
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryCreated
            {
                get
                {
                    if ((cachedOverrideSummaryCreated == null))
                    {
                        cachedOverrideSummaryCreated = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryCreated);
                    }
                    return (cachedOverrideSummaryCreated);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View Actions Pane header - Override
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideActionsPaneHeader
            {
                get
                {
                    if ((cachedOverrideActionsPaneHeader == null))
                    {
                        cachedOverrideActionsPaneHeader = CoreManager.MomConsole.GetIntlStr(ResourceOverrideActionsPaneHeader);
                    }
                    return (cachedOverrideActionsPaneHeader);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View Actions Pane link - Override Target Properties
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryOverrideTargetProperties
            {
                get
                {
                    if ((cachedOverrideSummaryOverrideTargetProperties == null))
                    {
                        cachedOverrideSummaryOverrideTargetProperties = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryOverrideTargetProperties);
                    }
                    return (cachedOverrideSummaryOverrideTargetProperties);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary View Actions Pane link - Delete
            /// </summary>
            /// <history>
            ///     [nathd] 26Aug08 Created
            /// </history>
            public static string OverrideSummaryDeleteOverride
            {
                get
                {
                    if ((cachedOverrideSummaryDeleteOverride == null))
                    {
                        cachedOverrideSummaryDeleteOverride = CoreManager.MomConsole.GetIntlStr(ResourceOverrideSummaryDeleteOverride);
                    }
                    return (cachedOverrideSummaryDeleteOverride);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary Dialog - Title
            /// </summary>
            /// <history>
            ///     [v-cheli] 23Mar09 Created
            /// </history>
            public static string OverrideSummaryDialogTitle
            {
                get
                {
                    if ((cachedOverridesSummaryDialogTitle == null))
                    {
                        cachedOverridesSummaryDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceOverridesSummaryDialogTitle);
                    }
                    return (cachedOverridesSummaryDialogTitle);
                }
            }

            /// <summary>
            ///  Exposes access to Overrides Summary Name Header
            /// </summary>
            /// <history>
            ///     [v-cheli] 02April09 Created
            /// </history>
            public static string OverridesSummaryNameHeader
            {
                get
                {
                    if (cachedOverridesSummaryNameHeader == null)
                    {
                        cachedOverridesSummaryNameHeader = CoreManager.MomConsole.GetIntlStr(ResourceOverridesSummaryNameHeader);
                    }
                    return cachedOverridesSummaryNameHeader;
                }
            }
            #endregion // Override Summary View

            #region General Resources

            /// <summary>
            ///  Exposes access to Object scope column translated resource
            /// </summary>
            /// <history>
            ///     [a-joelj] 20FEB09 Created
            /// </history>
            public static string ObjectScope
            {
                get
                {
                    if ((cachedObjectScope == null))
                    {
                        cachedObjectScope = CoreManager.MomConsole.GetIntlStr(ResourceObjectScope);
                    }
                    return (cachedObjectScope);
                }
            }

            /// <summary>
            ///  Exposes access to Class scope column translated resource
            /// </summary>
            /// <history>
            ///     [a-joelj] 20FEB09 Created
            /// </history>
            public static string ClassScope
            {
                get
                {
                    if ((cachedClassScope == null))
                    {
                        cachedClassScope = CoreManager.MomConsole.GetIntlStr(ResourceClassScope);
                    }
                    return (cachedClassScope);
                }
            }

            /// <summary>
            ///  Exposes access to Group scope column translated resource
            /// </summary>
            /// <history>
            ///     [a-joelj] 20FEB09 Created
            /// </history>
            public static string GroupScope
            {
                get
                {
                    if ((cachedGroupScope == null))
                    {
                        cachedGroupScope = CoreManager.MomConsole.GetIntlStr(ResourceGroupScope);
                    }
                    return (cachedGroupScope);
                }
            }

            #endregion

            #endregion
        }
        #endregion        

        #region OverridesParameters Class
        /// <summary>
        /// Parameters class for Overrides constructors.
        /// </summary>
        /// <history>
        /// [ruhim] 20APR06 Created
        /// </history>
        public class OverridesParameters
        {
            #region Private Members

            private bool cachedOverrideApplied = true;

            //Defining Hashtable to store Parameter Name and Override Setting pairs
            private Hashtable cachedParameterValuePairs = new Hashtable();

            private OverrideType cachedType;

            private string cachedOverridePath;

            #region Specifically for the Overrides View
            private string cachedOverrideTarget;

            private string cachedOverrideContext;

            private string cachedOverrideManagementPack;

            private string cachedOverrideScope;

            private string cachedOverrideEnforced;

            private OverrideTargetType cachedOverrideTargetType;

            private string cachedOverrideTargetManagementPack;

            private string cachedOverrideEditParameter;

            private string cachedOverrideEditValue;

            private string cachedOverrideEditEnforced;

            private string cachedOverrideTargetScope;

            private string cachedOverrideOrDisable;

            #endregion // Specifically for the Overrides View

            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public OverridesParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Bool indicating whether an override is applied or not
            /// </summary>
            public bool OverrideApplied
            {
                get
                {
                    return this.cachedOverrideApplied;
                }

                set
                {
                    this.cachedOverrideApplied = value;
                }
            }

            /// <summary>
            /// Hashtable to store Parameter Name and Override Setting pairs
            /// </summary>
            public Hashtable ParameterValuePairs
            {
                get
                {
                    return this.cachedParameterValuePairs;
                }

                set
                {
                    this.cachedParameterValuePairs.Add(value, value);
                }
            }

            /// <summary>
            /// Override Type
            /// </summary>
            public OverrideType Type
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
            /// Name of the Group, Instance or Class depending on the override Type selected
            /// </summary>
            public string OverridePath
            {
                get
                {
                    return this.cachedOverridePath;
                }

                set
                {
                    this.cachedOverridePath = value;
                }
            }

            /// <summary>
            ///  Name of the Override Target
            /// </summary>
            public string OverrideTarget
            {
                get
                {
                    return this.cachedOverrideTarget;
                }

                set
                {
                    this.cachedOverrideTarget = value;
                }
            }

            /// <summary>
            ///  Override Context
            /// </summary>
            public string OverrideContext
            {
                get
                {
                    return this.cachedOverrideContext;
                }

                set
                {
                    this.cachedOverrideContext = value;
                }
            }

            /// <summary>
            ///  Override Management Pack
            /// </summary>
            public string OverrideManagementPack
            {
                get
                {
                    return this.cachedOverrideManagementPack;
                }

                set
                {
                    this.cachedOverrideManagementPack = value;
                }
            }

            /// <summary>
            ///  Override Scope
            /// </summary>
            public string OverrideScope
            {
                get
                {
                    return this.cachedOverrideScope;
                }

                set
                {
                    this.cachedOverrideScope = value;
                }
            }

            /// <summary>
            ///  Override Enforced value
            /// </summary>
            public string OverrideEnforced
            {
                get
                {
                    return this.cachedOverrideEnforced;
                }

                set
                {
                    this.cachedOverrideEnforced = value;
                }
            }

            /// <summary>
            ///  Override Target Type
            /// </summary>
            public OverrideTargetType OverrideTargetType
            {
                get
                {
                    return this.cachedOverrideTargetType;
                }

                set
                {
                    this.cachedOverrideTargetType = value;
                }
            }

            /// <summary>
            ///  Override Target Management Pack
            /// </summary>
            public string OverrideTargetManagementPack
            {
                get
                {
                    return this.cachedOverrideTargetManagementPack;
                }

                set
                {
                    this.cachedOverrideTargetManagementPack = value;
                }
            }

            /// <summary>
            ///  Override Parameter - will be used to edit an override in Overrides View
            /// </summary>
            public string OverrideEditParameter
            {
                get
                {
                    return this.cachedOverrideEditParameter;
                }

                set
                {
                    this.cachedOverrideEditParameter = value;
                }
            }

            /// <summary>
            ///  Override Value - will be used to edit an override in Overrides View
            /// </summary>
            public string OverrideEditValue
            {
                get
                {
                    return this.cachedOverrideEditValue;
                }

                set
                {
                    this.cachedOverrideEditValue = value;
                }
            }

            /// <summary>
            ///  Override Parameter Enforced - will be used to edit an override in Overrides View
            /// </summary>
            public string OverrideEditEnforced
            {
                get
                {
                    return this.cachedOverrideEditEnforced;
                }

                set
                {
                    this.cachedOverrideEditEnforced = value;
                }
            }

            /// <summary>
            ///  Override Parameter target scope - will be used to change target scope
            /// </summary>
            public string OverrideTargetScope
            {
                get
                {
                    return this.cachedOverrideTargetScope;
                }

                set
                {
                    this.cachedOverrideTargetScope = value;
                }
            }

            /// <summary>
            ///  Override Parameter Override or Disable - will be used to launch overrides dialog
            /// </summary>
            public string OverrideOrDisable
            {
                get
                {
                    return this.cachedOverrideOrDisable;
                }

                set
                {
                    this.cachedOverrideOrDisable = value;
                }
            }

            #endregion
        }
        #endregion

    } //end of class Overrides

}//end of namespace