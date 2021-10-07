// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TemplatePerformanceChart.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   Performance widget
// </project>
// <summary>
//   class PerformanceChart
// </summary>
// <history>
//   [v-kantao] 2/22/2011 Created
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
    using MomCommon = Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Views.PerformanceChart;
    using System.Xml.Linq;
    using MomConsole = Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.ResourceLoader;
    using System.Linq;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using System.IO;
    using System.Reflection;
    public class PerformanceChart : ITemplate
    {

        [Resource(ID = "PerformanceWidget")]
        private string templateLocName;

        public bool CreationFlag = false;

        public string TemplateLocName
        {
            get { return this.templateLocName; }
        }

        public PerformanceChart()
        {
            Mom.Test.UI.Core.Common.SDKConnectionManager.Init(((MachineInfo)MomCommon.Topology.MomServersInfo[0]).MachineName);
            Mom.Test.UI.Core.ResourceLoader.ResourceLoader.Connection = Mom.Test.UI.Core.Common.Utilities.ConnectToManagementServer(((MachineInfo)MomCommon.Topology.MomServersInfo[0]).MachineName);
            var assembly = Assembly.GetExecutingAssembly();
            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.PerformanceChartResource.xml"));
            XDocument dashboardWizardDocument = XDocument.Load(stream);
            XElement EmbemdedAlertComponentResource = ResourceLoader.GetSection("PerformanceChartComponent", dashboardWizardDocument);
            ResourceLoader.LoadResources(this, EmbemdedAlertComponentResource);
        }


        private void UpdateChartColumns(PerformanceChartPage ChartPage, List<string> DisplayColumnsName)
        {
            MomCommon.Utilities.LogMessage("UpdateChartColumns::");
            if (DisplayColumnsName.Count < 1)
            {
                MomCommon.Utilities.LogMessage("0:: At least have one columns to display");
                throw new Exception("UpdateChartColumns:: At least have one columns to display");
            }
            if (DisplayColumnsName.Count > ChartPage.Controls.ShowThe_legendListView.Items.Count)
            {
                MomCommon.Utilities.LogMessage("UpdateChartColumns:: DisplayColumnsName count is not greater than Columns Display List View items ");
                throw new Exception("UpdateChartColumns:: DisplayColumnsName count is not greater than Columns Display List View items");
            }
            for (int i = 0; i < DisplayColumnsName.Count; i++)
            {
                bool ItemFound = false;
                foreach (ListViewItem item in ChartPage.Controls.ShowThe_legendListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                    if (listItem[0].Name == DisplayColumnsName[i])
                    {
                        MomCommon.Utilities.LogMessage("UpdateChartColumns: Found the column " + DisplayColumnsName[i]);
                        ItemFound = true;
                        if (item.Checked)
                        {
                            MomCommon.Utilities.LogMessage("UpdateChartColumns:: the Column Name: " + DisplayColumnsName[i] + " has been selected, Ignore it");
                        }
                        else
                        {
                            MomCommon.Utilities.LogMessage("UpdateChartColumns:: Selecting the Column name: " + DisplayColumnsName[i]);
                            item.Checked = true;
                            if (item.Checked)
                            {
                                MomCommon.Utilities.LogMessage("UpdateChartColumns:: Selected the Column name: " + DisplayColumnsName[i]);
                                MomCommon.Utilities.TakeScreenshot("UpdateChartColumns");
                            }
                            else
                            {
                                MomCommon.Utilities.LogMessage("UpdateChartColumns:: Selected columns is not selected, select again");
                                item.Checked = true;
                            }

                        }
                    }
                    else
                    {
                        // Hide the Invalid column from Display view
                        if (item.Checked && !DisplayColumnsName.Contains(listItem[0].Name) && (listItem[0].IsVisible))
                        {
                            MomCommon.Utilities.LogMessage("UpdateDisplayColumns:: Hide the Invalid column: " + listItem[0].Name + " from Display view");
                            item.Checked = false;
                        }
                    }
                }
                if (ItemFound == false)
                {
                    MomCommon.Utilities.LogMessage("UpdateDisplayColumns:: Columns Display list view does not contain " + DisplayColumnsName[i].ToString());
                    throw new Exception("UpdateDisplayColumns:: Columns Display list view does not contain " + DisplayColumnsName[i].ToString());
                }
            }
        }

        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {

            MomCommon.Utilities.LogMessage("SettingWizardCustomPages ");
            if (pageParams == null || wizard == null)
                return;

            CustomPagesParams parmas = (CustomPagesParams)pageParams;

            if (wizard is DashboardCreationWizard)
            {
                CreationFlag = true;
                MomCommon.Utilities.LogMessage("SettingWizardCustomPages::DashboardCreationWizard");
                // Proceed to the Scope setting Page
                this.ScopeSettingPage(wizard, parmas);
                // Proceed to the Setting counters Page
                this.CounterSettingPage(wizard, parmas);
                //Proceed to the time range page
                this.TimeRangeSettingPage(wizard, parmas);
                // Proceed to the Personalization Page
                this.PersonalizationWizardProcess(wizard, parmas);
            }

            if (wizard is DashboardConfigurationWizard)
            {
                CreationFlag = false;
                MomCommon.Utilities.LogMessage("SettingWizardCustomPages::DashboardConfigurationWizard");
                this.ScopeSettingPage(wizard, parmas);
                this.CounterSettingPage(wizard, parmas);
                this.TimeRangeSettingPage(wizard, parmas);
                this.PersonalizationWizardProcess(wizard, parmas);

            }
            if (wizard is DashboardPersonalizationWizard)
            {
                CreationFlag = false;
                this.PersonalizationWizardProcess(wizard, parmas);
            }
        }


        public void CounterSettingPage(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            MomCommon.Utilities.LogMessage("CounterSettingPage");

            // Load rescource for "Performance Counter";
            string ColumnName = parmas.PerformanceColumnResource;
            MomCommon.Utilities.LogMessage("CounterSettingPage:: Loaded resource is " + ColumnName);
            Mom.Test.UI.Core.Console.Views.PerformanceChart.UpdateInstanceConfigurationScopeAndCounterPage ConfigurationPage = new Core.Console.Views.PerformanceChart.UpdateInstanceConfigurationScopeAndCounterPage(
              CoreManager.MomConsole, MomCommon.Constants.DefaultDialogTimeout, wizard.WizardTitle);
            ConfigurationPage.WaitForResponse();
            ConfigurationPage.ClickMultiPickerComponentAddButton();
            Sleeper.Delay(MomCommon.Constants.OneSecond);

            Mom.Test.UI.Core.Console.Views.PerformanceChart.PerformanceCountersPage PerformanceCountersPage = null;
            int retry = 0;
            while (PerformanceCountersPage == null && retry < 5)
            {
                try
                {
                    PerformanceCountersPage = new Core.Console.Views.PerformanceChart.PerformanceCountersPage(
                    CoreManager.MomConsole, MomCommon.Constants.DefaultDialogTimeout, wizard.WizardTitle);
                }
                catch
                {
                    MomCommon.Utilities.LogMessage("New PerformanceCounterPage fail, retry time " + retry);
                    Sleeper.Delay(2000);
                    retry++;
                }

            }
            CoreManager.MomConsole.Waiters.WaitForStatusReady(MomCommon.Constants.DefaultDialogTimeout);
            MomCommon.Utilities.LogMessage("CounterSettingPage::SetSingleCounter");
            SetSingleCounter(PerformanceCountersPage, parmas.defaultObject.ToString(), parmas.defaultCounter.ToString(), parmas.defaultInstance.ToString(), ColumnName);

            MomCommon.Utilities.LogMessage("CounterSettingPage::SetSingleCounter");
            SetSingleCounter(PerformanceCountersPage, parmas.Object.ToString(), parmas.Counter.ToString(), parmas.Instance.ToString(), ColumnName);
            PerformanceCountersPage.Click_Ok();
            ConfigurationPage.ClickNext();
        }

        public void TimeRangeSettingPage(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            MomCommon.Utilities.LogMessage("TimeRangeSettingPage");
            Mom.Test.UI.Core.Console.Views.PerformanceChart.UpdateInstanceConfigurationTimeRangePage _TimeRangePage = new Core.Console.Views.PerformanceChart.UpdateInstanceConfigurationTimeRangePage(
                CoreManager.MomConsole,
               MomCommon.Constants.DefaultDialogTimeout,
                wizard.WizardTitle);
            _TimeRangePage.WaitForResponse();
            // Setting time range
            if (parmas.Time != null)
            {
                // Test could not use the followng code to select in the product
                // ScopePage.Controls.TimeComboBox.SelectByText(parmas.Time.ToString());
                _TimeRangePage.Controls.TimeComboBox.SelectByIndex(0);
                int temp = 24;
                while (temp >= parmas.TimeValue)
                {
                    _TimeRangePage.ClickDecrement();
                    temp--;
                }
                _TimeRangePage.ClickIncrement();
            }
            Sleeper.Delay(MomCommon.Constants.OneSecond);
            _TimeRangePage.WaitForResponse();
            _TimeRangePage.ClickNext();
        }

        private void SetSingleCounter(Mom.Test.UI.Core.Console.Views.PerformanceChart.PerformanceCountersPage page, string objects, string counter, string instance, string columnName)
        {

            MomCommon.Utilities.LogMessage("SetSingleCounter");
            MomConsole.MomControls.MultiPickerControl multiPickerControlView = new MomConsole.MomControls.MultiPickerControl(page);
            List<string> Counters = new List<string>();

            Dictionary<string, List<string>> Properties = new Dictionary<string, List<string>>();
            if (instance.ToString() == "SelectALL")
            {
                // Change to select all instance to work around crash bug 198463
                page.Controls.ObjectComboBox.SelectByText(objects.ToString());
                page.Controls.CounterComboBox.SelectByText(counter);
                MomCommon.Utilities.LogMessage("SetSingleCounter::Setting All Instance");

                multiPickerControlView.AddItemsToSelectedView(Properties, true);
            }
            else if (counter.ToString() == "None")
            {
                MomCommon.Utilities.LogMessage("SetSingleCounter:: Use only one counter");
            }
            else
            {
                MomCommon.Utilities.LogMessage("SetSingleCounter:: Setting counter");
                Counters.Add(counter);
                page.Controls.ObjectComboBox.SelectByText(objects);
                page.Controls.CounterComboBox.SelectByText(counter);
                page.Controls.InstanceComboBox.SelectByText(instance);
                Properties.Add(columnName, Counters);
                multiPickerControlView.AddItemsToSelectedView(Properties, false);
                Sleeper.Delay(MomCommon.Constants.OneSecond);
                Properties.Clear();

            }

        }

        public void ScopeSettingPage(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            MomCommon.Utilities.LogMessage("ScopeSettingPage");
            Mom.Test.UI.Core.Console.Views.PerformanceChart.UpdateInstanceConfigurationScopeAndCounterPage ScopePage = new Core.Console.Views.PerformanceChart.UpdateInstanceConfigurationScopeAndCounterPage(
                CoreManager.MomConsole,
               MomCommon.Constants.DefaultDialogTimeout,
                wizard.WizardTitle);
            ScopePage.WaitForResponse();
            MomCommon.Utilities.LogMessage("ScopeSettingPage:: Setting Scope");
            MomConsole.MomControls.SingleObjectPicker SingleObjectPickerView = new MomConsole.MomControls.SingleObjectPicker(ScopePage);

            string ColumnName = parmas.NameColumnResource;
            MomCommon.Utilities.LogMessage("ScopeSettingPage:: Loaded resource is " + ColumnName);

            string items = parmas.PropertiesScope.ToString();
            Dictionary<string, string> Objects = new Dictionary<string, string>();
            string Filter = parmas.PropertiesScope.ToString();
            Objects.Add(ColumnName, items);
            MomCommon.Utilities.LogMessage("ScopeSettingPage:: Seting Scope");
            MomConsole.MomControls.PickerControlModalDialog.enumPickerControlModalDialogType LuanchDialogType = MomControls.PickerControlModalDialog.enumPickerControlModalDialogType.SingleObjectPicker;
            SingleObjectPickerView.AddItemToSinglePickerComponentView(Objects, LuanchDialogType, true, Filter);
            Sleeper.Delay(MomCommon.Constants.OneSecond);
            ScopePage.WaitForResponse();
            //ScopePage.ClickNext();
        }

        public void PersonalizationWizardProcess(DashboardWizardBase wizard, CustomPagesParams parmas, bool checkShowShowTheLegend)
        {
            MomCommon.Utilities.LogMessage("PersonalizationWizardProcess");
            Mom.Test.UI.Core.Console.Views.PerformanceChart.PerformanceChartPage ChartPage = new Core.Console.Views.PerformanceChart.PerformanceChartPage(
                CoreManager.MomConsole,
                MomCommon.Constants.DefaultDialogTimeout,
                wizard.WizardTitle);

            ChartPage.WaitForResponse();

            // handle the differnt UI logic for confgiuration
            if (CreationFlag && checkShowShowTheLegend)
            {
                if (!ChartPage.Controls.ShowTheLegendCheckBox.Checked)
                {
                    ChartPage.ClickShowTheLegend();
                    MomCommon.Utilities.LogMessage("PersonalizationWizardProcess::Show The Legend in The View");
                }
                MomCommon.Utilities.LogMessage("Check box status:" + ChartPage.Controls.ShowTheLegendCheckBox.Checked.ToString());
            }

            if (parmas.PropertiesShowLegend != null)
            {
                MomCommon.Utilities.LogMessage("PersonalizationWizardProcess::Setting Legend");
                MomCommon.Utilities.LogMessage("PersonalizationWizardProcess::Count num =" + parmas.PropertiesShowLegend.Count.ToString());
                this.UpdateChartColumns(ChartPage, parmas.PropertiesShowLegend);

            }

            if (parmas.Automatic == "False")
            {
                if (ChartPage.Controls.AutomaticCheckBox.Checked)
                {
                    ChartPage.ClickAutomatic();
                }
                int temp = 100;
                while (temp < int.Parse(parmas.Max))
                {
                    ChartPage.ClickIncrement();
                    Sleeper.Delay(MomCommon.Constants.OneSecond);
                    temp++;
                }
                temp = 0;
                while (temp < int.Parse(parmas.Min))
                {
                    ChartPage.ClickIncrementInMin();
                    Sleeper.Delay(MomCommon.Constants.OneSecond);
                    temp++;
                }
            }

            if (CreationFlag)
            {
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
      ChartPage.Controls.NextButton,
      2000);
                ChartPage.ClickNext();
            }
            else
            {

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                ChartPage.Controls.FinishButton,
                2000);
                ChartPage.ClickFinish();
                MomCommon.Utilities.TakeScreenshot("Finish page");
                MomCommon.Utilities.LogMessage("Finish personlization");
            }
        }

        public void PersonalizationWizardProcess(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            PersonalizationWizardProcess(wizard, parmas, true);
        }

        public bool VerifyCustomSettings(Maui.Core.Window parentWindow, ICustomPageParams pageParams)
        {
            throw new NotImplementedException();
        }



        public struct CustomPagesParams : ICustomPageParams
        {
            public string name;
            public string description;
            public List<string> PropertiesShowLegend;
            public string PropertiesScope;
            public string defaultObject;
            public string defaultCounter;
            public string defaultInstance;
            public string Object;
            public string Counter;
            public string Instance;
            public string Time;
            public int TimeValue;
            public string Automatic;
            public string Max;
            public string Min;
            public string NameColumnResource;
            public string PerformanceColumnResource;
        }
    }
}