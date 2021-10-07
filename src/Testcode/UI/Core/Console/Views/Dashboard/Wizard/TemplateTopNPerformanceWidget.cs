// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Template.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   Top N widgets
// </project>
// <summary>
//   class TemplateTopNAlertWidget
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
    using System.Linq;
    using System.Reflection;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.Dialogs;
    using MomAlertComponent = Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent;
    using Mom.Test.UI.Core.Console.Views.PerformanceChart;
    using Mom.Test.UI.Core.Console.Views.TopNPerformanceWidget.Dialog;

    public class TemplateTopNPerformanceWidget : ITemplate
    {
        #region Private Members

        #endregion

        #region Constructor

        public TemplateTopNPerformanceWidget()
        {
            //TODO: Load resource strings from MP
        }

        #endregion

        #region Public methods

        public bool VerifyCustomSettings(Maui.Core.Window parentWindow, ICustomPageParams pageParams)
        {
            Utilities.LogMessage("VerifyCustomSettings(...)");
            CustomPagesParams param = (CustomPagesParams)pageParams;

            if (param.VerifyConfiguration)
            {
                DashboardConfigurationWizard wizard = new DashboardConfigurationWizard();

                this.NavigateToCustomPage(wizard, param);

                this.VeryfyScopeAndCountersPage(wizard, param);

                this.VerifyTimeRangeAndResults(wizard, param);

                this.VerifyDisplayPage(wizard, param);
            }
            else if (param.VerifyPersonalization)
            {
                DashboardPersonalizationWizard wizard = new DashboardPersonalizationWizard();

                this.VerifyDisplayPage(wizard, param);
            }
            else
            {
                throw new System.InvalidOperationException("Only configruation wizard and personalization wizard can be verified");
            }

            return true;
        }

        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            Utilities.LogMessage("SettingWizardCustomPages(...)");
            CustomPagesParams parmas = (CustomPagesParams)pageParams;

            if (wizard is DashboardCreationWizard || wizard is DashboardConfigurationWizard)
            {
                this.SettingScopeAndCounterPage(wizard, parmas);

                this.SettingTimeRangeAndResultsPage(wizard, parmas);

                this.SettingDisplayPage(wizard, parmas);
            }
            else if (wizard is DashboardPersonalizationWizard)
            {
                this.SettingDisplayPage(wizard, parmas);
            }
        }

        #endregion

        #region Private methods

        private void SettingScopeAndCounterPage(DashboardWizardBase wizard, CustomPagesParams pageParams)
        {
            Utilities.LogMessage("SettingScopeAndCounterPage (...)");
            TopNPerformanceScopeAndCountersPage scopePage = new TopNPerformanceScopeAndCountersPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);

            Utilities.LogMessage("Select a group or object...");
            this.SettingGroupOrObjectPage(scopePage, pageParams);

            Utilities.LogMessage("Select a performance counter...");
            //add retry to click LauncherButton
            int i = 0;
            while (i < 5)
            {
                try
                {
                    scopePage.ClickPerformanceCounterLauncherButton();
                    Sleeper.Delay(Constants.OneSecond * 3);
                    Mom.Test.UI.Core.Console.Views.PerformanceChart.PerformanceCountersPage performanceCountersPage = new Core.Console.Views.PerformanceChart.PerformanceCountersPage(
                    CoreManager.MomConsole, Constants.DefaultDialogTimeout, "Select a performance counter (Object/ Counter/ Instance)");
                    if (performanceCountersPage.IsEnabled)
                    {
                        Utilities.LogMessage("PerformanceCounterpage is popup");
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(performanceCountersPage, Constants.OneSecond * 15);
                        break;
                    }                   
                }
                catch (Exception e)
                {
                    Utilities.LogMessage("Fail to click LauncherButton " +e.ToString());
                }
                i++;
                Utilities.LogMessage("PerformanceCounterpage is not popup, retry time = " + i);
            }
            this.SettingPerformanceCounterPage(pageParams);

            Utilities.LogMessage("Click next...");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(scopePage.Controls.NextButton, Constants.OneSecond * 3);
            scopePage.ClickNext();
        }

        private void SettingDisplayPage(DashboardWizardBase wizard, CustomPagesParams pageParams)
        {
            Utilities.LogMessage("SettingDisplayPage (...)");
            PerformanceChart performanceChart = new PerformanceChart();
            // Convert the params
            PerformanceChart.CustomPagesParams pcParams = new PerformanceChart.CustomPagesParams();
            pcParams.Automatic = pageParams.Automatic;
            pcParams.Max = pageParams.Max;
            pcParams.Min = pageParams.Min;
            pcParams.PropertiesShowLegend = pageParams.PropertiesShowLegend;
            if (wizard is DashboardCreationWizard)
            {
                performanceChart.CreationFlag = true;
            }
            else
            {
                performanceChart.CreationFlag = false;
            }
            performanceChart.PersonalizationWizardProcess(wizard, pcParams, false);
        }

        private void SettingTimeRangeAndResultsPage(DashboardWizardBase wizard, CustomPagesParams pageParams)
        {
            Utilities.LogMessage("SettingTimeRangeAndResultsPage (...)");
            TopNPerformanceTimeRangeAndResultsPage timeRangeAndResultPage = new TopNPerformanceTimeRangeAndResultsPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);

            Utilities.LogMessage("Set Time range ...");
            timeRangeAndResultPage.LastText = pageParams.TimeRangeValue.ToString();

            Utilities.LogMessage("Set Time combo box ...");
            int itemIndex = -1;
            switch (pageParams.Time.ToLowerInvariant())
            {
                case "hours":
                    itemIndex = 0;
                    break;
                case "days":
                    itemIndex = 1;
                    break;
                default:
                    throw new System.IndexOutOfRangeException("No such time range.");
            }
            Utilities.LogMessage("Set Time combo box:: Select index " + itemIndex + " ...");
            timeRangeAndResultPage.Controls.TimeRangeComboBox.SelectByIndex(itemIndex);
            //TODO: No accessbility to select the item by text.
            //timeRangeAndResultPage.TimeRangeText = pageParams.Time;

            //Order by
            Utilities.LogMessage("Set order by ...");
            timeRangeAndResultPage.ShowTopResults = pageParams.OrderByAsc;

            //Sort value
            Utilities.LogMessage("Set Sort value ...");

            Utilities.LogMessage("Maximum result to show ...");
            timeRangeAndResultPage.MaximumResultsToShowText = pageParams.MaximumResults.ToString();

            Utilities.LogMessage("Click Next");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(timeRangeAndResultPage.Controls.NextButton, Constants.OneSecond * 3);
            timeRangeAndResultPage.ClickNext();
        }

        private void SettingGroupOrObjectPage(TopNPerformanceScopeAndCountersPage scopePage, CustomPagesParams pageParams)
        {
            Utilities.LogMessage("SettingGroupOrObjectPage (...)");
            if (pageParams.ScopeTarget != null)
            {
                SingleObjectPicker singleObjectPicker = new SingleObjectPicker(scopePage);
                singleObjectPicker.AddItemToSinglePickerComponentView(pageParams.ScopeTarget, MomControls.PickerControlModalDialog.enumPickerControlModalDialogType.SingleObjectPicker, false, pageParams.ScopeTarget[pageParams.ScopeTarget.Keys.First()], scopePage.Controls.GroupOrObjectLauncherButton);
            }
        }

        private void SettingPerformanceCounterPage(CustomPagesParams pageParams)
        {
            Utilities.LogMessage("SettingPerformanceCounterPage (...)");
            //TODO: The dialog title "Select a Performance counter (Object/ Counter /Instance)" is hard coded. Needs to load it from MP in the future.
            Mom.Test.UI.Core.Console.Views.PerformanceChart.PerformanceCountersPage performanceCountersPage = new Core.Console.Views.PerformanceChart.PerformanceCountersPage(
            CoreManager.MomConsole, Constants.DefaultDialogTimeout, "Select a performance counter (Object/ Counter/ Instance)");
            performanceCountersPage.ScreenElement.WaitForReady();
            Utilities.LogMessage("Select Object ...");
            CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate() { return performanceCountersPage.Controls.ObjectComboBox.Count > 0; });
            //performanceCountersPage.Controls.ObjectComboBox.SelectByText(pageParams.Object);
            //Utilities.LogMessage("Select Counter ...");
            //performanceCountersPage.Controls.CounterComboBox.SelectByText(pageParams.Counter);
            //Utilities.LogMessage("Select Instance ... ");
            //performanceCountersPage.Controls.InstanceComboBox.SelectByText(pageParams.Instance);

            //Use downArrow from keyboard, because the old method is not support on Win8 Client machine
            bool SelectOjbect = true;
            while (SelectOjbect)
            {
                try
                {
                    int itemCount = 100;
                    int j = 0;
                    while (!performanceCountersPage.Controls.ObjectComboBox.Text.ToLowerInvariant().Equals(pageParams.Object.ToLowerInvariant()) && j < itemCount)
                    {
                        Utilities.LogMessage("Select Object =" + performanceCountersPage.Controls.ObjectComboBox.Text);
                        performanceCountersPage.Controls.ObjectComboBox.ScreenElement.SendKeys(KeyboardCodes.DownArrow);
                        j++;
                        Sleeper.Delay(1000);
                    }
                    while (!performanceCountersPage.Controls.CounterComboBox.Text.ToLowerInvariant().Equals(pageParams.Counter.ToLowerInvariant()) && j < itemCount)
                    {
                        Utilities.LogMessage("Select Counter ...");
                        performanceCountersPage.Controls.CounterComboBox.ScreenElement.SendKeys(KeyboardCodes.DownArrow);
                        j++;
                        Sleeper.Delay(1000);
                    }
                    while (!performanceCountersPage.Controls.InstanceComboBox.Text.ToLowerInvariant().Equals(pageParams.Instance.ToLowerInvariant()) && j < itemCount)
                    {
                        Utilities.LogMessage("Select Counter ...");
                        performanceCountersPage.Controls.InstanceComboBox.ScreenElement.SendKeys(KeyboardCodes.DownArrow);
                        j++;
                        Sleeper.Delay(1000);
                    }
                    if(performanceCountersPage.Controls.ObjectComboBox.Text.ToLowerInvariant().Equals(pageParams.Object.ToLowerInvariant()) &&
                       performanceCountersPage.Controls.CounterComboBox.Text.ToLowerInvariant().Equals(pageParams.Counter.ToLowerInvariant())&&
                       performanceCountersPage.Controls.InstanceComboBox.Text.ToLowerInvariant().Equals(pageParams.Instance.ToLowerInvariant()))
                    {
                         SelectOjbect = false;
                    }
                   
                }
                catch (Exception e)
                {
                    Utilities.LogMessage("Setting Performance Counter failed " + e);
                }
                finally
                {
                    Utilities.TakeScreenshot("SettingPerformanceCounterPage");
                }
               
            }           
            Utilities.LogMessage("Select Available Item ...");
            //TODO: Not sure which columns will be used to select the available item, currently use all of the 3 columns
            MultiPickerControl multiPickerControlView = new MultiPickerControl(performanceCountersPage);
            DataGridRowExtended availableItem = multiPickerControlView.Controls.DataGridInAvailableItemsView.RowsExtended.FirstOrDefault(
                                                                  r => r.CellsExtended[0].NameExtended == pageParams.Object &&
                                                                       r.CellsExtended[1].NameExtended == pageParams.Counter &&
                                                                       r.CellsExtended[2].NameExtended == pageParams.Instance);
            if (availableItem == null)
            {
                throw new Maui.Core.Window.Exceptions.WindowNotFoundException("Failed to find the available item");
            }
            else
            {
                Utilities.LogMessage("Select available item ... ");
                availableItem.Select();
            }

            Utilities.LogMessage("Click OK button ...");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(performanceCountersPage.Controls._OkButton, Constants.OneSecond * 3);
            performanceCountersPage.Click_Ok();
        }

        private void NavigateToCustomPage(DashboardWizardBase wizard, CustomPagesParams param)
        {
            GeneralPropertiesPage generalPropertiesPage = new Dialogs.GeneralPropertiesPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(generalPropertiesPage.Controls.NextButton, Constants.OneMinute);
            generalPropertiesPage.ClickNext();
        }

        private void VeryfyScopeAndCountersPage(DashboardWizardBase wizard, CustomPagesParams param)
        {
            TopNPerformanceScopeAndCountersPage scopeAndCountersPage = new TopNPerformanceScopeAndCountersPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);

            if (scopeAndCountersPage.GroupOrObjectText != param.ScopeTarget.First().Value ||
                scopeAndCountersPage.PerformanceCounterText != string.Format("{0} / {1} / {2}", param.Object, param.Counter, param.Instance)
                )
            {
                Utilities.LogMessage("VerifyCustomSettings:: Failed Verified TopNPerformanceScopeAndCountersPage");
                Utilities.TakeScreenshot("VerifyCustomSettings_Failed Verified TopNPerformanceScopeAndCountersPage");
                throw new Exception("VerifyCustomSettings:: Failed Verified TopNPerformanceScopeAndCountersPage");
            }

            Utilities.LogMessage("VerifyCustomSettings:: VerifyCustomSettings:: Verified TopNPerformanceScopeAndCountersPage");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(scopeAndCountersPage.Controls.NextButton, Constants.OneMinute);
            scopeAndCountersPage.ClickNext();
        }

        private void VerifyTimeRangeAndResults(DashboardWizardBase wizard, CustomPagesParams param)
        {
            TopNPerformanceTimeRangeAndResultsPage timeRangeAndResultPage = new TopNPerformanceTimeRangeAndResultsPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);

            bool orderByAsc = false;
            if (timeRangeAndResultPage.Controls.ShowTopResultsRadioButton.ButtonState == ButtonState.Checked)
            {
                orderByAsc = true;
            }

            if (timeRangeAndResultPage.LastText != param.TimeRangeValue.ToString() ||
                //timeRangeAndResultPage.Controls.TimeRangeComboBox.Text != param.Time ||
                orderByAsc != param.OrderByAsc ||
                timeRangeAndResultPage.Controls.MaximumResultsToShowTextBox.Text != param.MaximumResults.ToString())
            {
                Utilities.LogMessage("VerifyCustomSettings:: Failed Verified TopNPerformanceTimeRangeAndResultsPage");
                Utilities.TakeScreenshot("VerifyCustomSettings_Failed Verified TopNPerformanceTimeRangeAndResultsPage");
                throw new Exception("VerifyCustomSettings:: Failed Verified TopNPerformanceTimeRangeAndResultsPage");
            }

            Utilities.LogMessage("VerifyCustomSettings:: VerifyCustomSettings:: Verified TopNPerformanceScopeAndCountersPage");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(timeRangeAndResultPage.Controls.NextButton, Constants.OneMinute);
            timeRangeAndResultPage.ClickNext();
        }

        private void VerifyDisplayPage(DashboardWizardBase wizard, CustomPagesParams param)
        {
            PerformanceChartPage displayPage = new PerformanceChartPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);

            //Verify columns to dispaly
            foreach (var item in displayPage.Controls.ShowThe_legendListView.Items)
            {
                MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                if (param.PropertiesShowLegend.Contains(listItem[0].Name) && !item.Checked)
                {
                    Utilities.LogMessage(string.Format("VerifyCustomSettings:: Failed Verified DisplayPage. item:'{0}' is not checked", listItem[0].Name));
                    Utilities.TakeScreenshot("VerifyCustomSettings_Failed Verified DisplayPage");
                    throw new Exception("VerifyCustomSettings:: Failed Verified DisplayPage");
                }
                if (!param.PropertiesShowLegend.Contains(listItem[0].Name) && item.Checked)
                {
                    Utilities.LogMessage(string.Format("VerifyCustomSettings:: Failed Verified DisplayPage. item:'{0}' is checked", listItem[0].Name));
                    Utilities.TakeScreenshot("VerifyCustomSettings_Failed Verified DisplayPage");
                    throw new Exception("VerifyCustomSettings:: Failed Verified DisplayPage");
                }
            }

            //Verify Automatic
            Utilities.LogMessage("displayPage.Controls.AutomaticCheckBox.Checked:" + displayPage.Controls.AutomaticCheckBox.Checked);
            Utilities.LogMessage("param.Automatic:" + param.Automatic);
            if (displayPage.Controls.AutomaticCheckBox.Checked != bool.Parse(param.Automatic))
            {
                Utilities.LogMessage("VerifyCustomSettings:: Failed Verified DisplayPage. Automatic check box is not as expected");
                Utilities.TakeScreenshot("VerifyCustomSettings_Failed Verified DisplayPage");
                throw new Exception("VerifyCustomSettings:: Failed Verified DisplayPage. Automatic check box is not as expected");
            }

            //Verify Max and Min
            Utilities.LogMessage("displayPage.Controls.MaxTextBox.Text:" + displayPage.Controls.MaxTextBox.Text);
            Utilities.LogMessage("displayPage.Controls.MinTextBox.Text:" + displayPage.Controls.MinTextBox.Text);
            if (!displayPage.Controls.AutomaticCheckBox.Checked &&
                (displayPage.Controls.MaxTextBox.Text != param.Max.ToString() ||
                 displayPage.Controls.MinTextBox.Text != param.Min.ToString()))
            {
                Utilities.LogMessage("VerifyCustomSettings:: Failed Verified DisplayPage. Max or Min are not as expected");
                Utilities.TakeScreenshot("VerifyCustomSettings_Failed Verified DisplayPage");
                throw new Exception("VerifyCustomSettings:: Failed Verified DisplayPage. Max or Min are not as expected");
            }

            Utilities.LogMessage("VerifyCustomSettings:: VerifyCustomSettings:: Verified DisplayPage");

            //Close the wizard
            displayPage.ClickCancel();
            CoreManager.MomConsole.ConfirmChoiceDialog(
                             MomConsoleApp.ButtonCaption.OK,
                             DashboardWizardBase.Strings.CancelWizardTitle,
                             StringMatchSyntax.ExactMatch,
                             MomConsoleApp.ActionIfWindowNotFound.Error);
        }

        #endregion

        public string TemplateLocName { get { return "Objects by Performance"; } }

        public struct CustomPagesParams : ICustomPageParams
        {
            public string ShowMembers;
            public Dictionary<string, string> ScopeTarget;
            public string Object;
            public string Counter;
            public string Instance;

            public int TimeRangeValue;
            public string Time;
            public bool OrderByAsc;
            public string SortValue;
            public int MaximumResults;

            public List<string> PropertiesShowLegend;
            public string Automatic;
            public string Max;
            public string Min;

            public bool VerifyConfiguration;
            public bool VerifyPersonalization;
        }
    }
}
