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
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.Dialogs;
    using System.Linq;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using MomAlertComponent = Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent;
    using System.Reflection;
    using Mom.Test.UI.Core.Console.Views.TopNAlertWidget.Dialog;

    public class TemplateTopNAlertWidget : ITemplate
    {
        #region Private Members

        #endregion

        #region Constructor

        public TemplateTopNAlertWidget()
        {
            //TODO: Load resource strings from MP
        }

        #endregion

        #region public methods

        public bool VerifyCustomSettings(Maui.Core.Window parentWindow, ICustomPageParams pageParams)
        {
            throw new NotImplementedException();
        }

        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            CustomPagesParams parmas = (CustomPagesParams)pageParams;

            if (wizard is DashboardCreationWizard)
            {
                this.SettingScopePage(wizard, parmas);

                this.SettingCriteriaPage(wizard, parmas);

                this.SettingDisplayPage(wizard, parmas);
            }
            else if (wizard is DashboardConfigurationWizard)
            {
                throw new NotImplementedException();
            }
            else if (wizard is DashboardPersonalizationWizard)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Private methods

        private void SettingScopePage(DashboardWizardBase wizard, CustomPagesParams pageParams)
        {
            TopNAlertScopePage scopePage = new TopNAlertScopePage();

            #region Select a group or object

            if (pageParams.ScopeTarget != null)
            {
                Button launchScopePageButton = null;
                //SingleObjectPicker singleObjectPicker = new SingleObjectPicker(scopePage);
                //singleObjectPicker.AddItemToSinglePickerComponentView(pageParams.ScopeTarget, MomControls.PickerControlModalDialog.enumPickerControlModalDialogType.SingleObjectPicker, false, pageParams.ScopeTarget[pageParams.ScopeTarget.Keys.First()], launchScopePageButton);
            }

            #endregion

            #region Slect a class to scope the members of the specified group

            Button launchClassPageButon = null;
            launchClassPageButon.Click();
            //Convert params
            TemplateTopNPerformanceWidget.CustomPagesParams topNPerfParams = new TemplateTopNPerformanceWidget.CustomPagesParams();
            topNPerfParams.ScopeTarget = pageParams.ScopeTarget;

            #endregion

            //Click Next
        }

        private void SettingCriteriaPage(DashboardWizardBase wizard, CustomPagesParams pageParams)
        {
            MomAlertComponent.Configuration.AlertCriteriaPage AlertCriteriaPage = new MomAlertComponent.Configuration.AlertCriteriaPage(CoreManager.MomConsole, Constants.DefaultDialogTimeout, wizard.WizardTitle);
            AlertConfiguration alertWidgetTemplate = new AlertConfiguration();

            alertWidgetTemplate.SettingAlertCriteriaPage(pageParams.Severity, AlertCriteriaPage.Controls.SeverityListView);
            alertWidgetTemplate.SettingAlertCriteriaPage(pageParams.Priority, AlertCriteriaPage.Controls.PriorityListView);
            alertWidgetTemplate.SettingAlertCriteriaPage(pageParams.ResolutionState, AlertCriteriaPage.Controls.ResolutionStateListView);

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(AlertCriteriaPage.Controls.NextButton, Constants.OneMinute);
            AlertCriteriaPage.ClickNext();
        }

        private void SettingDisplayPage(DashboardWizardBase wizard, CustomPagesParams pageParams)
        {
            //Set Maximun Results to show

            //Set Columns to display
            PerformanceChart performanceChart = new PerformanceChart();
            // Convert the params
            PerformanceChart.CustomPagesParams pcParams = new PerformanceChart.CustomPagesParams();
            pcParams.PropertiesShowLegend = pageParams.PropertiesShowLegend;
            pcParams.Automatic = "True";
            performanceChart.PersonalizationWizardProcess(wizard, pcParams);
        }

        #endregion

        public string TemplateLocName { 
            //TODO: Load resource string from MP
            get { return "Objects by Number of Alerts"; } 
        }

        public struct CustomPagesParams : ICustomPageParams
        {
            /*
            public string Name;
            public string Description;
            */
            public Dictionary<string, string> ScopeTarget;
            public string Class;
            public string ColumnDisplayName;

            public List<string> Severity;
            public List<string> Priority;
            public List<string> ResolutionState;

            public List<string> PropertiesShowLegend;
            public int MaximumResults;
        }
    }
}

