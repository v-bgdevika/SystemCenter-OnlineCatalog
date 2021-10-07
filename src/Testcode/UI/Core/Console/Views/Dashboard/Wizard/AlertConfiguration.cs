// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Template.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   class TemplateA
// </summary>
// <history>
//   [v-vijia] 1/31/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.Dialogs;
    using System.Linq;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using MomAlertComponent = Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent;
    using System.Reflection;

    public class AlertConfiguration : ITemplate
    {
        public void SettingAlertCriteriaPage(List<string> AlertCriteriaList, ListView AlertCriteriaListView)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            if (AlertCriteriaList != null)
            {
                Utilities.LogMessage(currentMethod + ":: Updating alert Criterial setting...");
                if (AlertCriteriaList.Count > AlertCriteriaListView.Items.Count)
                {
                    Utilities.LogMessage(currentMethod + ":: AlertCriteriaList.cout out of AlertCriteriaListView.Items.Count");
                    throw new Exception(currentMethod + ":: AlertCriteriaList.cout out of AlertCriteriaListView.Items.Count");
                }
                for (int i = 0; i < AlertCriteriaList.Count; i++)
                {
                    foreach (ListViewItem item in AlertCriteriaListView.Items)
                    {
                        MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                        if (listItem[0].Name == AlertCriteriaList[i])
                        {
                            item.Checked = true;
                        }
                        else
                        {
                            if (item.Checked && !AlertCriteriaList.Contains(listItem[0].Name))
                            {
                                item.Checked = false;
                            }
                        }
                    }
                }
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Uncheck all item");
                foreach (ListViewItem item in AlertCriteriaListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                    if (item.Checked)
                    {
                        item.Checked = false;
                    }
                }
            }
        }

        private bool VerifyAlertCriteriaPageUpdated(List<string> AlertCriteriaList, ListView AlertCriteriaListView)
        {
            bool result = false;
            if (AlertCriteriaList != null && AlertCriteriaList.Count > 0)
            {
                for (int i = 0; i < AlertCriteriaList.Count; i++)
                {
                    foreach (ListViewItem item in AlertCriteriaListView.Items)
                    {
                        MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                        if (listItem[0].Name == AlertCriteriaList[i] && item.Checked)
                        {
                            result = true;
                        }
                        else
                        {
                            if (item.Checked && !AlertCriteriaList.Contains(listItem[0].Name))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (ListViewItem item in AlertCriteriaListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                    if (item.Checked)
                    {
                        return false;
                    }
                }
                return true;
            }
            return result;
        }


        public void UpdateDashboarPersonalization(CustomPagesParams parmas, DashboardWizardBase wizard)
        {
            MomAlertComponent.Personalization.Personalization Personzalization = new MomAlertComponent.Personalization.Personalization(wizard.WizardTitle);

            #region Setting Display
            if (parmas.Display != null || parmas.ShowAllColumnsToDisplay)
            {
                Personzalization.UpdateDisplayColumns(parmas.Display, parmas.DisplayIndex, parmas.ShowAllColumnsToDisplay);
            }
            #endregion

            #region Setting Sort by
            if (parmas.NeedUpdateSortyBy)
            {
                Personzalization.UpdateSortByColumns(parmas.sortColumnsName, parmas.ColumnsSortIndex, parmas.SortType);
            }
            #endregion

            #region Setting Group by
            if (parmas.NeedUpdateGroupBy)
            {
                Personzalization.UpdateGroupByColumns(parmas.GroupColumnsName, parmas.ColumnsGroupIndex, parmas.GroupType);
            }
            #endregion
            // workarround due to bug, finish button is not getting enabled unless display strings are changed.
            if (wizard is DashboardCreationWizard)
            {
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(Personzalization.updatePersonalizationDialog.Controls.NextButton, Constants.OneMinute);
                Personzalization.updatePersonalizationDialog.ClickNext();
            }
            else
            {
                try
                {
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(Personzalization.updatePersonalizationDialog.Controls.CreateButton, Constants.OneMinute);
                    Personzalization.updatePersonalizationDialog.ClickCreate();
                }
                catch (Exception e)
                {
                    Utilities.LogMessage(" Finish button is not enabled."); // workarround for the bug
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(Personzalization.updatePersonalizationDialog.Controls.CancelButton, Constants.OneMinute);
                    Personzalization.updatePersonalizationDialog.ClickCancel();
                    CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.OK,
                                           ConsoleApp.Strings.CancelWizardDialogTitle,
                                           StringMatchSyntax.WildCard,
                                           MomConsoleApp.ActionIfWindowNotFound.Ignore);

                }
            }
        }

        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            if (pageParams == null || wizard == null)
                return;
            CustomPagesParams parmas = (CustomPagesParams)pageParams;
            if (wizard is DashboardConfigurationWizard)
            {
                #region Setting ScopePage
                Utilities.LogMessage(currentMethod + ":: Setting Scope Page...");
                MomAlertComponent.Configuration.AlertObjectPickerScopePage scopePage = new MomAlertComponent.Configuration.AlertObjectPickerScopePage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);
                if (parmas.ScopeTarget != null)
                {
                    SingleObjectPicker singleObjectPicker = new SingleObjectPicker(scopePage);
                    singleObjectPicker.AddItemToSinglePickerComponentView(parmas.ScopeTarget, MomControls.PickerControlModalDialog.enumPickerControlModalDialogType.SingleObjectPicker, false, parmas.ScopeTarget[parmas.ScopeTarget.Keys.First()]);
                }
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(scopePage.Controls.NextButton, Constants.OneMinute);
                scopePage.ClickNext();
                #endregion

                #region Setting CriteriaPage
                Utilities.LogMessage(currentMethod + ":: Setting Criteria Page...");
                MomAlertComponent.Configuration.AlertCriteriaPage AlertCriteriaPage = new MomAlertComponent.Configuration.AlertCriteriaPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);
                this.SettingAlertCriteriaPage(parmas.Severity, AlertCriteriaPage.Controls.SeverityListView);
                this.SettingAlertCriteriaPage(parmas.Priority, AlertCriteriaPage.Controls.PriorityListView);
                this.SettingAlertCriteriaPage(parmas.ResolutionState, AlertCriteriaPage.Controls.ResolutionStateListView);

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(AlertCriteriaPage.Controls.NextButton, Constants.OneMinute);
                AlertCriteriaPage.ClickNext();
                #endregion

                #region Setting Display Page
                Utilities.LogMessage(currentMethod + ":: Updating Display Page...");
                this.UpdateDashboarPersonalization(parmas, wizard);

                #endregion
            }
            if (wizard is DashboardPersonalizationWizard)
            {
                Utilities.LogMessage(currentMethod + ":: Updating DashboarPersonalization...");
                this.UpdateDashboarPersonalization(parmas, wizard);
            }
            if (wizard is DashboardCreationWizard)
            {
                #region Setting ScopePage
                Utilities.LogMessage(currentMethod + ":: Setting Scope Page...");

                MomAlertComponent.Configuration.AlertObjectPickerScopePage scopePage = new MomAlertComponent.Configuration.AlertObjectPickerScopePage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);
                if (parmas.ScopeTarget != null)
                {
                    SingleObjectPicker singleObjectPicker = new SingleObjectPicker(scopePage);
                    singleObjectPicker.AddItemToSinglePickerComponentView(parmas.ScopeTarget, MomControls.PickerControlModalDialog.enumPickerControlModalDialogType.SingleObjectPicker, false, parmas.ScopeTarget[parmas.ScopeTarget.Keys.First()]);
                }
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(scopePage.Controls.NextButton, Constants.OneMinute);
                scopePage.ClickNext();
                #endregion

                #region Setting CriteriaPage
                Utilities.LogMessage(currentMethod + ":: Setting Criteria Page...");
                MomAlertComponent.Configuration.AlertCriteriaPage AlertCriteriaPage = new MomAlertComponent.Configuration.AlertCriteriaPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);
                this.SettingAlertCriteriaPage(parmas.Severity, AlertCriteriaPage.Controls.SeverityListView);
                this.SettingAlertCriteriaPage(parmas.Priority, AlertCriteriaPage.Controls.PriorityListView);
                this.SettingAlertCriteriaPage(parmas.ResolutionState, AlertCriteriaPage.Controls.ResolutionStateListView);

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(AlertCriteriaPage.Controls.NextButton, Constants.OneMinute);
                AlertCriteriaPage.ClickNext();
                #endregion

                #region Setting Display Page
                Utilities.LogMessage(currentMethod + ":: Updating Display Page...");
                this.UpdateDashboarPersonalization(parmas, wizard);

                #endregion
            }

        }

        public bool VerifyCustomSettings(Window parentWindow, ICustomPageParams pageParams)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            bool result = false;
            if (parentWindow == null || pageParams == null)
                throw new System.ArgumentNullException();

            CustomPagesParams param = (CustomPagesParams)pageParams;

            DashboardConfigurationWizard wizard = new DashboardConfigurationWizard();
            CoreManager.MomConsole.Waiters.WaitForReady();

            #region Verify General Properties

            Utilities.LogMessage(currentMethod + ":: Verifying GeneralPropertiesPage updates...");
            GeneralPropertiesPage GeneralPropertiesPage = new Dialogs.GeneralPropertiesPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);
            
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(GeneralPropertiesPage.Controls.NextButton, Constants.OneMinute);
            if (GeneralPropertiesPage.NameText == param.Name || GeneralPropertiesPage.DescriptionText == param.Description)
            {
                Utilities.LogMessage(currentMethod + ":: Verified GeneralPropertiesPage");
                result = true;
                GeneralPropertiesPage.ClickNext();
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Failed Verified GeneralPropertiesPage");
                Utilities.TakeScreenshot(currentMethod + "_Failed Verified GeneralPropertiesPage");
                return false;
            }

            #endregion

            #region Verify AlertScopePage updated

            Utilities.LogMessage(currentMethod + ":: Verifying AlertScopePage updates...");
            MomAlertComponent.Configuration.AlertObjectPickerScopePage scopePage = new MomAlertComponent.Configuration.AlertObjectPickerScopePage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);
            
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(scopePage.Controls.NextButton, Constants.OneMinute);
            //Add while loop to wait for selection text loadding completed, bug#204908
            int reTry=0;
            int maxTry=Constants.DefaultMaxRetry*2;
            while (reTry <= maxTry)
            {
                if (param.ScopeTarget == null)
                {
                    Utilities.LogMessage(currentMethod + ":: verified AlertScopePage");
                    result = true;
                    scopePage.ClickNext();
                    break;
                }
                else
                {
                    if (scopePage.AlertSinglePickerComponent.Controls.SinglePickerComponentSelectionText.Text == param.ScopeTarget[param.ScopeTarget.Keys.First()])
                    {
                        Utilities.LogMessage(currentMethod + ":: verified AlertScopePage");
                        result = true;
                        scopePage.ClickNext();
                        break;
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethod + ":: ScopPage value not match expected value, wait for one second and retry again. Retry time " + reTry + " of " + maxTry);
                        Sleeper.Delay(Constants.OneSecond*2);
                        reTry++;
                    }
                }
            }
            if (reTry > maxTry)
            {
                Utilities.LogMessage(currentMethod + ":: Failed verified AlertScopePage Page");
                Utilities.TakeScreenshot(currentMethod + "_Failed verified AlertScopePage Page");
                return false;
            }

            #endregion

            #region Verify Alert Creitria Page

            Utilities.LogMessage(currentMethod + ":: Verifying Criteria Page updated...");
            MomAlertComponent.Configuration.AlertCriteriaPage AlertCriteriaPage = new MomAlertComponent.Configuration.AlertCriteriaPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(AlertCriteriaPage.Controls.NextButton, Constants.OneMinute);
            if (this.VerifyAlertCriteriaPageUpdated(param.Severity, AlertCriteriaPage.Controls.SeverityListView) &&
                this.VerifyAlertCriteriaPageUpdated(param.Priority, AlertCriteriaPage.Controls.PriorityListView) &&
                this.VerifyAlertCriteriaPageUpdated(param.ResolutionState, AlertCriteriaPage.Controls.ResolutionStateListView))
            {
                Utilities.LogMessage(currentMethod + ":: verified Criteria Page");
                result = true;
                AlertCriteriaPage.ClickNext();
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Failed veirified Criteria Page");
                return false;
            }

            #endregion

            #region Verify Display Page Update
            Utilities.LogMessage(currentMethod + ":: Verifying Personalization Page updated...");
            MomAlertComponent.Personalization.Personalization Personzalization = new MomAlertComponent.Personalization.Personalization(MomAlertComponent.Personalization.AlertPersonalizationDialog.Strings.ConfigurationDialogTitle);

            #region Verify Display Setting
            if (param.Display != null || param.ShowAllColumnsToDisplay)
            {
                result = Personzalization.VerifyColumnsDisplaySettings(param.Display, param.DisplayIndex, param.ShowAllColumnsToDisplay);
                if (!result)
                {
                    return result;
                }
            }
            #endregion

            #region Verify Sort By Setting
            if (param.NeedUpdateSortyBy)
            {
                result = Personzalization.VerifyColumnsSortBySettings(param.sortColumnsName, param.ColumnsSortIndex, param.SortType);
                if (!result)
                {
                    return result;
                }
            }
            #endregion

            #region Verify Group By Setting
            if (param.NeedUpdateGroupBy)
            {
                result = Personzalization.VerifyColumnsGroupBySettings(param.GroupColumnsName, param.ColumnsGroupIndex, param.GroupType);
                if (!result)
                {
                    return result;
                }
            }
            #endregion

            //Personzalization.updatePersonalizationDialog.ClickCreate();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(Personzalization.updatePersonalizationDialog.Controls.CancelButton, Constants.OneMinute);
            Personzalization.updatePersonalizationDialog.ClickCancel();
            CoreManager.MomConsole.ConfirmChoiceDialog(
                       MomConsoleApp.ButtonCaption.OK,
                       ConsoleApp.Strings.CancelWizardDialogTitle,
                       StringMatchSyntax.WildCard,
                       MomConsoleApp.ActionIfWindowNotFound.Ignore);

            #endregion

            return result;
        }

        public string TemplateLocName
        {
            get { return "Alert Widget"; }
        }
        public struct CustomPagesParams : ICustomPageParams
        {
            public string Name;
            public string Description;
            public Dictionary<string, string> ScopeTarget;
            public List<string> Severity;
            public List<string> Priority;
            public List<string> ResolutionState;
            public List<string> Display;
            public List<int> DisplayIndex;
            public bool ShowAllColumnsToDisplay;
            public bool NeedUpdateSortyBy;
            public List<string> sortColumnsName;
            public List<int> ColumnsSortIndex;
            public List<string> SortType;
            public bool NeedUpdateGroupBy;
            public List<string> GroupColumnsName;
            public List<int> ColumnsGroupIndex;
            public List<string> GroupType;
        }
    }
}