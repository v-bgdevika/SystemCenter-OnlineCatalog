// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DashboardWizards.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-dayow] 7/30/2010 Created
//   [v-vijia] 1/31/2011 Slipt class DashboardPersonalizationWizard and  DashboardConfigurationWizard to specific files.
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard
{
    using System;
    using System.Linq;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.ResourceLoader;
    using System.Collections.Generic;
    using Mom.Test.UI.Core.Console.MomControls;
    using System.Reflection;

    public class DashboardCreationWizard : DashboardWizardBase
    {
        [Resource(ID = "NewInstanceWizardTitle")]
        private string wizardTitle;

        [Resource(ID = "TemplateColumn")]
        private string templateColumn;

        [Resource(ID = "FolderColumn")]
        private string folderColumn;

        public DashboardCreationWizard()
            : base()
        { }

        protected DashboardCreationWizardEntry WizardEntry
        {
            get;
            set;
        }

        #region Common gages in the wizard

        private Dialogs.TemplatePage cachedTemplatePage = null;
        public Dialogs.TemplatePage TemplatePage
        {
            get
            {
                if (cachedTemplatePage == null)
                {
                    cachedTemplatePage = new Dialogs.TemplatePage(CoreManager.MomConsole, Common.Constants.DefaultDialogTimeout, WizardTitle);
                }
                return cachedTemplatePage;
            }
        }

        private Dialogs.GeneralPropertiesPage cachedGeneralPage = null;
        public Dialogs.GeneralPropertiesPage GeneralPropertiesPage
        {
            get
            {
                if (cachedGeneralPage == null)
                {
                    cachedGeneralPage = new Dialogs.GeneralPropertiesPage(CoreManager.MomConsole, Common.Constants.DefaultDialogTimeout, WizardTitle);
                }
                return cachedGeneralPage;
            }
        }

        private Dialogs.SummaryPage cachedSummaryPage = null;
        public Dialogs.SummaryPage SummaryPage
        {
            get
            {
                if (cachedSummaryPage == null)
                {
                    cachedSummaryPage = new Dialogs.SummaryPage(CoreManager.MomConsole, Common.Constants.DefaultDialogTimeout, WizardTitle);
                }
                return cachedSummaryPage;
            }
        }

        private Dialogs.CompletionPage cachedCompletionPage = null;
        public Dialogs.CompletionPage CompletionPage
        {
            get
            {
                if (cachedCompletionPage == null)
                {
                    cachedCompletionPage = new Dialogs.CompletionPage(CoreManager.MomConsole, Common.Constants.DefaultDialogTimeout, WizardTitle);
                }
                return cachedCompletionPage;
            }
        }
        #endregion
        
        public static DashboardCreationWizard Launch(DashboardCreationWizardEntry entry)
        {
            return Launch(entry, null);
        }

        /// <summary>
        /// It will determine if specific dashboard view exists if this parameter provided, after a weak check (it will not break the code if specific dashboard views does not exists)
        /// It will launch the New Dashboard and Widget Wizard by context menu or by show hide views link (not implemented yet)
        /// </summary>
        /// <param name="entry">The way to launch New Dashboard and Widget Wizard</param>
        /// <param name="contextMenuPath">menu path</param>
        /// <param name="dashboardNameToVerify">optional parameters, if provided, will check if the specific dashboard views loaded in the Monitoring tree view</param>
        /// <returns>DashboardCreationWizard</returns>
        public static DashboardCreationWizard Launch(DashboardCreationWizardEntry entry, string contextMenuPath, string dashboardNameToVerify = "")
        {           

            switch (entry)
            {
                case DashboardCreationWizardEntry.MonitoringContextMenu:
                    Utilities.LogMessage("Select Monitoring node");
                    CoreManager.MomConsole.NavigationPane.SelectNode(NavigationPane.Strings.Monitoring, NavigationPane.NavigationTreeView.Monitoring);

                    // If the third optional parameter is not provided by the client code, the conditional statements will return false, and the code in the blocks won't be executed
                    // so the change has no affect to the client code which didn't provide the third optional parameter
                    // And this change is about to fix bug # 205019
                    if (dashboardNameToVerify != "")
                    {
                        CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate() { return CoreManager.MomConsole.NavigationPane.NodeExists(dashboardNameToVerify); }, Constants.OneMinute);
                    }

                    if (contextMenuPath == null)
                    {
                        contextMenuPath = Views.Strings.NewContextMenu +
                            Common.Constants.PathDelimiter +
                            Views.Strings.DashboardViewContextMenu.Replace("&", String.Empty).Trim();
                    }

                    CoreManager.MomConsole.ExecuteContextMenu(contextMenuPath, true);
                    break;

                case DashboardCreationWizardEntry.ShowHideViewsLink:
                    //TODO;
                    //CoreManager.MomConsole.NavigationPane.ClickNewViewsLink(NavigationPane.NavigationTreeView.Monitoring);
                    //CoreManager.MomConsole.ExecuteContextMenu("Dashboard Instance", false);
                    break;
                case DashboardCreationWizardEntry.WebConsoleLink:

                    TreeNode nodeInfo = CoreManager.MomConsole.NavigationPane.SelectNode(contextMenuPath, NavigationPane.NavigationTreeView.Monitoring);
                    Utilities.LogMessage("Select node '" + nodeInfo.FullPath.ToString() + "' again, make sure it selected...");
                    CoreManager.MomConsole.NavigationPane.SelectNode(contextMenuPath, NavigationPane.NavigationTreeView.Monitoring);

                    CoreManager.MomConsole.Waiters.WaitForReady();

                    Utilities.LogMessage("TaskStrip.ClickLink:: Try to find the link"); 
                    Control linkElement = new Control(CoreManager.MomConsole.MainWindow, new QID(";[UIA]ClassName = 'Hyperlink' && [UIA, VisibleOnly]Name = ~'Create Dashboard View...'"), Constants.DefaultViewLoadTimeout);
                        
                    if (linkElement == null)
                    {
                        throw new Window.Exceptions.WindowNotFoundException("Failed to get the link.");
                    }

                    try
                    {
                        CoreManager.MomConsole.Waiters.WaitForWindowEnabled(linkElement as Window, Constants.OneSecond * 10);
                    }
                    catch(System.TimeoutException)
                    {
                        Utilities.LogMessage("Hit Timeout exception, it is caused by web autorefresh, select node again");
                        CoreManager.MomConsole.NavigationPane.SelectNode(contextMenuPath, NavigationPane.NavigationTreeView.Monitoring);                        
                    }
                    Utilities.LogMessage("TaskStrip.ClickLink:: Try to click the link");
                    linkElement.ScreenElement.LeftButtonClick(-1, -1, true, KeyboardFlags.NoFlag);
                    break;
            }

            DashboardCreationWizard wizard = new DashboardCreationWizard();
            wizard.WizardEntry = entry;
            return wizard;
        }      

        /// <summary>
        /// It will determine if specific dashboard view exists if this parameter provided, after a weak check (it will not break the code if specific dashboard views does not exists)
        /// It will launch the New Dashboard and Widget Wizard by context menu or by show hide views link (not implemented yet)
        /// </summary>
        /// <param name="nodePath">node path to launch the wizard</param>
        /// <param name="contextMenuPath">menu path</param>
        /// <param name="dashboardNameToVerify">optional parameters, if provided, will check if the specific dashboard views loaded in the Monitoring tree view</param>
        /// <returns>DashboardCreationWizard</returns>
        public static DashboardCreationWizard Launch(string nodePath, string contextMenuPath, string dashboardNameToVerify = "")
        {
            string logHeader = MethodBase.GetCurrentMethod().Name + " :: ";
            Utilities.LogMessage(logHeader+"Entering method (...)");

            if (string.IsNullOrEmpty(contextMenuPath))
            {
                throw new ArgumentException("contextMenuPath", "contextMenuPath is null or empty");
            }

            CoreManager.MomConsole.Waiters.WaitForReady();

            Utilities.LogMessage(logHeader + "Select Monitoring node "+nodePath);
            CoreManager.MomConsole.NavigationPane.SelectNode(nodePath, NavigationPane.Strings.Monitoring);
            CoreManager.MomConsole.Waiters.WaitForReady();

            // If the third optional parameter "dashboardNameToVerify" is not provided by the client code, the conditional statements will return false, and the code in the blocks won't be executed
            // so the change has no affect to the client code which didn't provide the third optional parameter
            // And this change is about to fix bug # 205019
            if (dashboardNameToVerify != string.Empty)
            {
                CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate() { return CoreManager.MomConsole.NavigationPane.NodeExists(dashboardNameToVerify); }, Constants.OneMinute);
            }

            CoreManager.MomConsole.ExecuteContextMenu(contextMenuPath, true);

            DashboardCreationWizard wizard = new DashboardCreationWizard();
            return wizard;
        }

        /// <summary>
        /// Methode to set wizard
        /// </summary>
        /// <param name="settings">settings</param>
        public override void SettingWizard(DashboardParams settings)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            Template = settings.Template;
            if (Template != null)
                this.CustomPagesHandler = new CustomPagesHandler(this.Template.SettingWizardCustomPages);

            #region  Template page
            this.TemplatePage.WaitForResponse();
            Common.Utilities.LogMessage(currentMethodName + ":: Template page");

            //fix timing issue in #188421.
            this.TemplatePage.Controls.TemplateDataGrid.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate()
            {
                return this.TemplatePage.Controls.TemplateDataGrid.RowsExtended != null && this.TemplatePage.Controls.TemplateDataGrid.RowsExtended.Count != 0;
            });

            int columnIndexOfTemplate = this.TemplatePage.Controls.TemplateDataGrid.GetColumnIndex(this.TemplateColumn);
            Utilities.LogMessage(currentMethodName + ":: column index Of " + this.TemplateColumn + " is " + columnIndexOfTemplate);
            DataGridRowExtended row = this.TemplatePage.Controls.TemplateDataGrid.RowsExtended.Where(
                r => r.CellsExtended[columnIndexOfTemplate].NameExtended == settings.Template.TemplateLocName).FirstOrDefault();
            try
            {
                if (row != null)
                {
                    Utilities.LogMessage(currentMethodName + ":: Found Template: " + settings.Template.TemplateLocName);
                    row.CellsExtended[0].Select();
                    Common.Utilities.LogMessage(currentMethodName + ":: Test 222");
                    //Bug#221292
                    Sleeper.Delay(Constants.OneSecond * 2);
                    Utilities.TakeScreenshot("SettingTemplatePage");
                }
                else
                {
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException(
                        "Row not found. Template='" + this.Template.TemplateLocName + "'");
                }
            }catch(Exception)
            {
                Common.Utilities.LogMessage(currentMethodName + ":: Click failed hence TAB");
                Keyboard.SendKeys(KeyboardCodes.Alt + KeyboardCodes.Tab);
                if(settings.Template.TemplateLocName.Equals("State Widget"))
                {
                    Sleeper.Delay(Constants.OneSecond * 2);
                    Keyboard.SendKeys(KeyboardCodes.Tab);
                    Sleeper.Delay(Constants.OneSecond * 2);
                    Keyboard.SendKeys(KeyboardCodes.Tab);
                    Sleeper.Delay(Constants.OneSecond * 2);
                    Keyboard.SendKeys(KeyboardCodes.Tab);
                    Sleeper.Delay(Constants.OneSecond * 2);
                    Keyboard.SendKeys(KeyboardCodes.Tab);
                    Sleeper.Delay(Constants.OneSecond * 2);
                    Keyboard.SendKeys(KeyboardCodes.Tab);
                    Sleeper.Delay(Constants.OneSecond * 2);
                    Keyboard.SendKeys(KeyboardCodes.Tab);
                    Sleeper.Delay(Constants.OneSecond * 2);

                }
            }
            //Bug#202946: Sometimes the Next button will not be enable in 2 seconds after the template is selected.
            //Increase the timeout to 5 seconds. If this bug is fixed we may decrease the timeout.
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(TemplatePage.Controls.NextButton, Constants.OneSecond * 5);
            TemplatePage.ClickNext();
            #endregion

            #region  General page
            CoreManager.MomConsole.Waiters.WaitForWindowReady(this.GeneralPropertiesPage, ConsoleConstants.DefaultWaitForReadyTimeout);
            Common.Utilities.LogMessage(currentMethodName + ":: General page");

            Common.Utilities.LogMessage(currentMethodName + ":: Setting Name " + settings.Name);
            // In Maui 4.0, set text for textbox on New Dashboard and Widget Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
            this.GeneralPropertiesPage.Controls.NameTextBox.SendKeys(settings.Name);

            Common.Utilities.LogMessage(currentMethodName + ":: Setting Description " + settings.Description);
            // In Maui 4.0, set text for textbox on New Dashboard and Widget Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
            this.GeneralPropertiesPage.Controls.DescriptionTextBox.SendKeys(settings.Description);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(GeneralPropertiesPage.Controls.NextButton, Constants.OneSecond * 2);
            GeneralPropertiesPage.Controls.NextButton.Click();

            #endregion

            #region  Custom pages
            if (CustomPagesHandler != null)
                CustomPagesHandler(this, settings.CustomPageParams);
            #endregion

            #region  Summary page
            this.SummaryPage.WaitForResponse();
            Common.Utilities.LogMessage(currentMethodName + ":: Summary page");
            //TODO: verify summary info.
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(SummaryPage.Controls.CreateButton, Constants.OneSecond * 2);
            SummaryPage.ClickCreate();
            #endregion

            #region Completion page
            this.CompletionPage.WaitForResponse();

            //Billhodg: Increasing timeout to 2 minutes to fix bug 373846
            CoreManager.MomConsole.Waiters.WaitForObjectPropertyChanged(CompletionPage.Controls.CloseButton, "@IsEnabled", PropertyOperator.Equals, true, 30000 * 4);
            int i = 0;
            while (!CompletionPage.Controls.CloseButton.IsEnabled && i < Constants.DefaultMaxRetry)
            {

                Sleeper.Delay(Constants.TenSeconds);
                i++;
                Utilities.LogMessage("wait for Close Button enable:" + (i * 10).ToString());
                 
            }
            if (i == Constants.DefaultMaxRetry)
            {
                Utilities.LogMessage("Close Button still not enable after:" + (i * 10).ToString());

            } 
            CompletionPage.Controls.CloseButton.Click();
            //CompletionPage.Controls.CloseButton.ScreenElement.LeftButtonClick(-1, -1);
            CoreManager.MomConsole.Waiters.WaitForWindowClose(CompletionPage, Constants.OneSecond * 3);
            #endregion

            #region Wait for close
            CoreManager.MomConsole.Waiters.WaitForReady();
            CoreManager.MomConsole.BringToForeground();
            #endregion
        }

        /// <summary>
        /// This method is for debuging/investigate purpose, please keep this method
        /// </summary>
        /// <param name="activeAcc">ActiveAccessibility represent the UI element want to check</param>
        private static void DumpAllChildren(ActiveAccessibility activeAcc)
        {
            Common.Utilities.LogMessage("activeAcc.ChildCount" + activeAcc.ChildCount);
            Common.Utilities.LogMessage("activeAcc.ChildID" + activeAcc.ChildID);
            Common.Utilities.LogMessage("activeAcc.Description" + activeAcc.Description);
            Common.Utilities.LogMessage("activeAcc.Index" + activeAcc.Index);
            Common.Utilities.LogMessage("activeAcc.IsElement" + activeAcc.IsElement);
            Common.Utilities.LogMessage("activeAcc.KeyboardShortcut" + activeAcc.KeyboardShortcut);
            Common.Utilities.LogMessage("activeAcc.Name:" + activeAcc.Name);
            Common.Utilities.LogMessage("activeAcc.RoleText:" + activeAcc.RoleText);
            Common.Utilities.LogMessage("activeAcc.Role" + activeAcc.Role);
            Common.Utilities.LogMessage("activeAcc.RoleText" + activeAcc.RoleText);
            Common.Utilities.LogMessage("activeAcc.State" + activeAcc.State);
            Common.Utilities.LogMessage("activeAcc.StateText" + activeAcc.StateText);
            Common.Utilities.LogMessage("activeAcc.TotalFound" + activeAcc.TotalFound);
            Common.Utilities.LogMessage("activeAcc.Value" + activeAcc.Value);
            Common.Utilities.LogMessage("activeAcc.Visible" + activeAcc.Visible);
            Common.Utilities.LogMessage("activeAcc.Width" + activeAcc.Width);

            foreach (ActiveAccessibility activeAcc2 in activeAcc.Children)
            {
                DumpAllChildren(activeAcc2);
            }
        }

        public override string WizardTitle
        {
            get 
            { 
                return this.wizardTitle; 
            }
        }

        public string TemplateColumn
        {
            get 
            { 
                return this.templateColumn; 
            }
        }

        public string FolderColumn
        {
            get
            {
                return this.folderColumn;
            }
        }
    }

    public enum DashboardCreationWizardEntry
    {
        MonitoringContextMenu,
        ShowHideViewsLink,
        WebConsoleLink,
    }
}