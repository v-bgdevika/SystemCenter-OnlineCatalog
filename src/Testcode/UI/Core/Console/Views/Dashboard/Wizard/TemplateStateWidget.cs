// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TemplateStateWidget.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   State widget
// </project>
// <summary>
//   class StateWidget
// </summary>
// <history>
//   [v-juli] 5/17/2011 Created
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
    using Mom.Test.UI.Core.Console.Views.StateWidget;
    using System.Xml.Linq;
    using MomConsole = Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.ResourceLoader;
    using System.Linq;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using MomAlertComponent = Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent;
    using System.IO;
    using System.Reflection;

    public class StateWidget : ITemplate
    {

        [Resource(ID = "StateWidget")]
        private string templateLocName;

        [Resource(ID = "TileNewInstance")]
        private string tileNewInstance;
               
        [Resource(ID = "TitleSelectAClass")]
        private string titleSelectAClass;

        [Resource(ID = "TitleAddGroupsOrObjects")]
        private string titleAddGroupsOrObjects;

        [Resource(ID = "DisplayName")]
        private string displayName;
        public string displayNameColumn;

        [Resource(ID = "DisplayOnlyMaintnanceMode")]
        private string displayOnlyMaintnanceMode;
        public string displayOnlyMaintnanceModeLeble;

        [Resource(ID = "Healthy")]
        private string healthy;
        public string healthyCheckbox;

        [Resource(ID = "Warning")]
        private string warning;
        public string warningCheckbox;

        [Resource(ID = "Critical")]
        private string critical;
        public string criticalCheckbox;

        [Resource(ID = "NotMonitored")]
        private string notMonitored;
        public string notMonitoredCheckbox;
        
                
        public bool CreationFlag = false;
        
        public string TemplateLocName
        {
           get { return this.templateLocName; }           
        }

        public StateWidget()
        {
            Mom.Test.UI.Core.Common.SDKConnectionManager.Init(((MachineInfo)MomCommon.Topology.MomServersInfo[0]).MachineName);
            Mom.Test.UI.Core.ResourceLoader.ResourceLoader.Connection = Mom.Test.UI.Core.Common.Utilities.ConnectToManagementServer(((MachineInfo)MomCommon.Topology.MomServersInfo[0]).MachineName);
            var assembly = Assembly.GetExecutingAssembly();
            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetResource.xml"));
            //var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.StateWidgetResource.xml"));
            XDocument dashboardWizardDocument = XDocument.Load(stream);
            XElement EmbemdedStateComponentResource = ResourceLoader.GetSection("StateWidgetComponent", dashboardWizardDocument);            
            ResourceLoader.LoadResources(this, EmbemdedStateComponentResource);           
            
            displayNameColumn = displayName;
            displayOnlyMaintnanceModeLeble = displayOnlyMaintnanceMode;
            healthyCheckbox = healthy;
            warningCheckbox = warning;
            criticalCheckbox = critical;
            notMonitoredCheckbox = notMonitored;                       
        }
        
        /// <summary>
        /// Setting State Widget pages
        /// </summary>
        /// <param name="wizard">state wizard</param>
        /// <param name="pageParams">state cutom parameters</param>
        public void SettingWizardCustomPages(DashboardWizardBase wizard, ICustomPageParams pageParams)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            MomCommon.Utilities.LogMessage(currentMethod + "...");
                       
            if (pageParams == null || wizard == null)
                return;

            CustomPagesParams parmas = (CustomPagesParams)pageParams;

            if (wizard is DashboardCreationWizard)
            {
                CreationFlag = true;
                MomCommon.Utilities.LogMessage(currentMethod + " ::DashboardCreationWizard");
                                
                this.SettingScopePage(wizard, parmas);                              

                this.SettingClassPage(wizard, parmas);

                this.SettingCriteriaPage(wizard, parmas);

                this.SettingPersonalizationPage(wizard, parmas); 
            }

            if (wizard is DashboardConfigurationWizard)
            {
                CreationFlag = false;
                MomCommon.Utilities.LogMessage(currentMethod + " ::DashboardConfigurationWizard");
               
                this.SettingScopePage(wizard, parmas);                

                this.SettingClassPage(wizard, parmas);

                this.SettingCriteriaPage(wizard, parmas);

                this.SettingPersonalizationPage(wizard, parmas); 
            }
            if (wizard is DashboardPersonalizationWizard)
            {
                CreationFlag = false;
                this.SettingPersonalizationPage(wizard, parmas);  
            }
        }

        /// <summary>
        /// Setting single class picker
        /// </summary>
        /// <param name="wizard">state wizard</param>
        /// <param name="parmas">state cutom parameters</param>
        public void SettingClassPage(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            MomCommon.Utilities.LogMessage(currentMethod + "...");
            
              Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetScopePage ScopePage = new Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetScopePage(
                  CoreManager.MomConsole, MomCommon.Constants.DefaultDialogTimeout, wizard.WizardTitle);
                ScopePage.WaitForResponse();

                if (parmas.Class != null && parmas.Class != Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetScopePage.Strings.ObjectClass)
                {
                    string ColumnName = parmas.ColumnDisplayName;
                    MomCommon.Utilities.LogMessage(currentMethod + " :: Loaded resource is " + ColumnName);

                    string items = parmas.Class.ToString();
                    Dictionary<string, string> Objects = new Dictionary<string, string>();
                    string Filter = parmas.Class.ToString();
                    Objects.Add(ColumnName, items);

                    ScopePage.ClickClassPickerComponentAddButton();
                    Sleeper.Delay(MomCommon.Constants.OneSecond);

                    //Add a Single Class
                    AddSingleClassItem(Objects, true, Filter);
                    CoreManager.MomConsole.Waiters.WaitForReady();                   
                }
                else
                {
                    MomCommon.Utilities.LogMessage(currentMethod + " :: Click reset button. ");
                    ScopePage.ClickReset();
                }
        
            ScopePage.ClickNext();              
        }

        /// <summary>
        /// Add single class item in class picker
        /// </summary>
        /// <param name="Properties">class</param>
        /// <param name="FilterOption">whether use filter or not</param>
        /// <param name="FilterString">filter string</param>
        public void AddSingleClassItem(Dictionary<string, string> Properties, bool FilterOption, string FilterString)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            MomCommon.Utilities.LogMessage(currentMethod + "...");

            Mom.Test.UI.Core.Console.Views.StateWidget.ClassPickerDialog ClassPickerPage = new Mom.Test.UI.Core.Console.Views.StateWidget.ClassPickerDialog(
                      CoreManager.MomConsole, MomCommon.Constants.DefaultDialogTimeout, this.titleSelectAClass);
            ClassPickerPage.WaitForResponse();

            if (FilterOption)
            {
                ClassPickerPage.Controls.LookForTextBox.SetValueWithPaste(FilterString); 
            }

            int reTry = 0;
            int maxtry = 10;
            while (reTry < maxtry)
            {
                if (ClassPickerPage.Controls.AvailableItemsDataGrid.RowsExtended.Count != 0)
                {
                    MomCommon.Utilities.LogMessage(currentMethod + " :: AvailableItemsDataGrid loaded");
                    break;
                }
                else
                {
                    MomCommon.Utilities.LogMessage(currentMethod + " :: AvailableItemsDataGrid on loading, wait for one second and retry again");
                    Sleeper.Delay(MomCommon.Constants.OneSecond);
                    reTry++;
                }
            }

            if (Properties != null)
            {
                MomCommon.Utilities.LogMessage(currentMethod + "SelectItem:: select items in available items view");                
                MomCommon.Utilities.LogMessage(currentMethod + "Row count is " + ClassPickerPage.Controls.AvailableItemsDataGrid.RowsExtended.Count);
                int selectRow = ClassPickerPage.Controls.AvailableItemsDataGrid.GetRowIndex(Properties);
                Sleeper.Delay(1000);
                if (selectRow != null && selectRow != -1)
                {
                    ClassPickerPage.Controls.AvailableItemsDataGrid.ScreenElement.EnsureVisible();
                    ClassPickerPage.Controls.AvailableItemsDataGrid.RowsExtended[selectRow].Select();
                    Sleeper.Delay(1000);
                }
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(ClassPickerPage.Controls.OkButton, MomCommon.Constants.OneMinute);
            ClassPickerPage.ClickOk();
            CoreManager.MomConsole.WaitForDialogClose(ClassPickerPage, MomCommon.Constants.DefaultDialogTimeout);            
        }

        /// <summary>
        /// Setting state widget criteria page
        /// </summary>
        /// <param name="wizard">state wizard</param>
        /// <param name="parmas">state cutom parameters</param>
        public void SettingCriteriaPage(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            MomCommon.Utilities.LogMessage(currentMethod + "...");    

            Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetCritriaPage StateCriteriaPage = new Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetCritriaPage(
                CoreManager.MomConsole,
                MomCommon.Constants.DefaultDialogTimeout,
                wizard.WizardTitle);
            MomCommon.Utilities.LogMessage(currentMethod + ":: Updating State Criterial setting...");
            if (null != parmas.Criteria)            {
               
                if (parmas.Criteria.Contains("All"))
                {
                    MomCommon.Utilities.LogMessage(currentMethod + ":: All criteria will be shown ");
                    if (StateCriteriaPage.Controls.HealthStatesCheckBox.Checked == true)
                    {
                        StateCriteriaPage.Controls.HealthStatesCheckBox.Checked = false;
                    }                
                }
                else
                {
                    MomCommon.Utilities.LogMessage(currentMethod + ":: Updating specific State Criterial setting...");
                    StateCriteriaPage.Controls.HealthStatesCheckBox.Checked = true;

                    foreach (var criteria in parmas.Criteria)
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: parmas.Criteria..." + criteria);
                    }

                    foreach (ListViewItem item in StateCriteriaPage.Controls.HealthStatesListView.Items)
                    {
                        MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                        
                        if (parmas.Criteria.Contains(listItem[0].Name))
                        {
                            MomCommon.Utilities.LogMessage(currentMethod + ":: item.Checked...");
                            item.Checked = true;                        
                        }
                        else
                        {
                            if (item.Checked && !parmas.Criteria.Contains(listItem[0].Name))
                            {
                                item.Checked = false;                            
                            }
                        }
                    }                
                }
            }

            if (parmas.ShowOnlyMaintenanceMode != null)
            {
                if (parmas.ShowOnlyMaintenanceMode && StateCriteriaPage.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.Checked == false)
                {
                    MomCommon.Utilities.LogMessage(currentMethod + ":: Set DisplayOnlyObjectsInMaintenanceModeCheckBox to be checked...");
                    StateCriteriaPage.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.Checked = true;
                }
                else if (StateCriteriaPage.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.Checked == true)
                {
                    MomCommon.Utilities.LogMessage(currentMethod + ":: Set DisplayOnlyObjectsInMaintenanceModeCheckBox to be unchecked...");
                    StateCriteriaPage.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.Checked = false;
                }
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(StateCriteriaPage.Controls.NextButton, MomCommon.Constants.OneMinute);
            StateCriteriaPage.ClickNext();
            
        }

        /// <summary>
        /// Setting state scope page
        /// </summary>
        /// <param name="wizard">state wizard</param>
        /// <param name="parmas">state cutom parameters</param>
        public void SettingScopePage(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            MomCommon.Utilities.LogMessage(currentMethod + "...");
                       
            Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetScopePage ScopePage = new Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetScopePage(
                CoreManager.MomConsole,
               MomCommon.Constants.DefaultDialogTimeout,
                wizard.WizardTitle);
            ScopePage.WaitForResponse();
            MomCommon.Utilities.LogMessage(currentMethod + " :: Setting Scope");

            if (CreationFlag)
            {                
                if (parmas.ScopeTarget != null)
                {
                    ScopePage.ClickMultiPickerComponentAddButton();
                    Sleeper.Delay(MomCommon.Constants.OneSecond * 2);

                    MomCommon.Utilities.LogMessage(currentMethod + " :: Add Groups");
                    AddingMultiGroupsOrObjects(wizard, parmas);

                    ScopePage.WaitForResponse(); 
                }
                else
                {
                    MomCommon.Utilities.LogMessage(currentMethod + " :: No Groups or Objects need to set.");
                }
            }
            else
            {                
                if (ScopePage.Controls.GroupsAndObjectsDataGrid.RowsExtended.Count > 0)
                {
                    MomCommon.Utilities.LogMessage(currentMethod + " :: Remove groups or objects added before.");

                    ScopePage.Controls.GroupsAndObjectsDataGrid.RowsExtended[0].ScreenElement.LeftButtonClick(-1, -1);                    
                    ScopePage.Controls.GroupsAndObjectsDataGrid.ScreenElement.SendKeys(MomCommon.KeyboardCodes.Ctrl + "a");

                    ScopePage.ClickMultiPickerComponentRemoveButton();
                    ScopePage.WaitForResponse();
                }

                if (parmas.ScopeTarget != null)
                {
                    ScopePage.ClickMultiPickerComponentAddButton();
                    Sleeper.Delay(MomCommon.Constants.OneSecond * 2);

                    AddingMultiGroupsOrObjects(wizard, parmas);
                    ScopePage.WaitForResponse();
                }
                else
                {
                    MomCommon.Utilities.LogMessage(currentMethod + " :: No Groups or Objects need to set.");
                }
            }                   
                 
        }

        /// <summary>
        /// Add multi-objects in object picker
        /// </summary>
        /// <param name="wizard">state wizard</param>
        /// <param name="parmas">state cutom parameters</param>
        public void AddingMultiGroupsOrObjects(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            MomCommon.Utilities.LogMessage(currentMethod + "...");

            StateWidget statewidget = new StateWidget();

            Mom.Test.UI.Core.Console.Views.StateWidget.MultiObjectPicker MultiObjectPickerDialog = new MultiObjectPicker(
                CoreManager.MomConsole,
                MomCommon.Constants.DefaultDialogTimeout,
                this.titleAddGroupsOrObjects);
            MomConsole.MomControls.MultiPickerControl multiPickerControlView = new MomConsole.MomControls.MultiPickerControl(MultiObjectPickerDialog);
            Dictionary<string, List<string>> Properties = new Dictionary<string, List<string>>();

            Properties = parmas.ScopeTarget;

            foreach (string groupObject in Properties[statewidget.displayNameColumn])
            {                
                if (parmas.ShowMembers == "Yes")
                {
                    MomCommon.Utilities.LogMessage(currentMethod + " :: Add groups will cause its members to show");
                    MultiObjectPickerDialog.Controls.ShowOnlyGroups.ButtonState = ButtonState.Checked;
                                       
                    MultiObjectPickerDialog.Controls.ShowAllObjectsAndGroupsTextBox.SetValueWithPaste(groupObject);
                    CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate() { return MultiObjectPickerDialog.Controls.AvailableItemsDataGrid.RowsExtended.Count != 0; });
                    multiPickerControlView.AddItemsToSelectedView(Properties, false);
                    Sleeper.Delay(MomCommon.Constants.OneSecond);
                }
                else
                {
                    MomCommon.Utilities.LogMessage(currentMethod + " :: Add groups will not cause its members to show");
                    MultiObjectPickerDialog.Controls.ShowAllObjects.ButtonState = ButtonState.Checked;
                    MultiObjectPickerDialog.Controls.ShowAllObjectsAndGroupsTextBox.SetValueWithPaste(groupObject);
                    MultiObjectPickerDialog.ClickSCOMFilterControlSearchButton();

                    CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate() { return MultiObjectPickerDialog.Controls.AvailableItemsDataGrid.RowsExtended.Count != 0;});
                   
                    multiPickerControlView.AddItemsToSelectedView(Properties, false);
                    Sleeper.Delay(MomCommon.Constants.OneSecond);
                }                
            }
                        
            MultiObjectPickerDialog.ClickOk();            
        }

        /// <summary>
        /// Reuse method in AlertView Widget to set personalization page
        /// </summary>
        /// <param name="wizard">state wizard</param>
        /// <param name="parmas">state cutom parameters</param>
        public void SettingPersonalizationPage(DashboardWizardBase wizard, CustomPagesParams parmas)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            MomCommon.Utilities.LogMessage(currentMethod + "..."); 
            
            //Reuse Personalization page method in Alert Widget
            AlertConfiguration alerconfig = new AlertConfiguration();
            AlertConfiguration.CustomPagesParams alertparams = new AlertConfiguration.CustomPagesParams();
            alertparams.Display = parmas.DisplayColumn;
            alertparams.DisplayIndex = parmas.DisplayIndex;
            alertparams.ShowAllColumnsToDisplay = parmas.ShowAllColumnsToDisplay;
            alertparams.NeedUpdateSortyBy = parmas.NeedUpdateSortyBy;
            alertparams.sortColumnsName = parmas.sortColumnsName;
            alertparams.ColumnsSortIndex = parmas.ColumnsSortIndex;
            alertparams.SortType = parmas.SortType;
            alertparams.NeedUpdateGroupBy = parmas.NeedUpdateGroupBy;
            alertparams.GroupColumnsName = parmas.GroupColumnsName;
            alertparams.ColumnsGroupIndex = parmas.ColumnsGroupIndex;
            alertparams.GroupType = parmas.GroupType;

            alerconfig.UpdateDashboarPersonalization(alertparams, wizard);
        }

        /// <summary>
        /// Implement Verify Custom Settings in state widget
        /// </summary>
        /// <param name="parentWindow">parentWindow</param>
        /// <param name="pageParams">pageParams</param>
        /// <returns></returns>
        public bool VerifyCustomSettings(Maui.Core.Window parentWindow, ICustomPageParams pageParams)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            bool result = false;
            if (parentWindow == null || pageParams == null)
                throw new System.ArgumentNullException();

            StateWidget statewidget = new StateWidget();
            
            CustomPagesParams param = (CustomPagesParams)pageParams;

            DashboardConfigurationWizard wizard = new DashboardConfigurationWizard();
            CoreManager.MomConsole.Waiters.WaitForReady();

            #region Verify General Properties

            MomCommon.Utilities.LogMessage(currentMethod + ":: Verifying GeneralPropertiesPage updates...");
            GeneralPropertiesPage GeneralPropertiesPage = new Dialogs.GeneralPropertiesPage(CoreManager.MomConsole, MomCommon.Constants.DefaultDialogTimeout, wizard.WizardTitle);

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(GeneralPropertiesPage.Controls.NextButton, MomCommon.Constants.OneMinute);

            MomCommon.Utilities.LogMessage(currentMethod + "::GeneralPropertiesPage.NameText " + GeneralPropertiesPage.NameText);
            MomCommon.Utilities.LogMessage(currentMethod + "::param.Name " + param.Name);
            MomCommon.Utilities.LogMessage(currentMethod + "::GeneralPropertiesPage.DescriptionText " + GeneralPropertiesPage.DescriptionText);
            MomCommon.Utilities.LogMessage(currentMethod + "::param.Description " + param.Description);

            if (GeneralPropertiesPage.NameText == param.Name || GeneralPropertiesPage.DescriptionText == param.Description)
            {
                MomCommon.Utilities.LogMessage(currentMethod + ":: Verified GeneralPropertiesPage");
                result = true;
                GeneralPropertiesPage.ClickNext();
            }
            else
            {
                MomCommon.Utilities.LogMessage(currentMethod + ":: Failed Verified GeneralPropertiesPage");
                MomCommon.Utilities.TakeScreenshot(currentMethod);
                result = false;
            }

            #endregion     
      
            #region Verify ScopePage updated

            MomCommon.Utilities.LogMessage(currentMethod + ":: Verifying ScopePage updates...");
            Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetScopePage scopePage = new StateWidgetScopePage(CoreManager.MomConsole, MomCommon.Constants.DefaultDialogTimeout, wizard.WizardTitle);

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(scopePage.Controls.NextButton, MomCommon.Constants.OneMinute);
           
            if (param.ScopeTarget == null)
            {
                if (scopePage.Controls.GroupsAndObjectsDataGrid.RowsExtended.Count > 1)
                {
                    MomCommon.Utilities.LogMessage(currentMethod + ":: Failed to set Groups and objects.");
                    return false;
                }
                else
                {
                    MomCommon.Utilities.LogMessage(currentMethod + ":: verified ScopePage");
                    result = true;                    
                }                    
                   
            }
            else
            {
                if (scopePage.Controls.GroupsAndObjectsDataGrid.RowsExtended.Count != param.ScopeTarget[param.ScopeTarget.Keys.First()].Count)
                {
                    MomCommon.Utilities.LogMessage(currentMethod + ":: Failed to set Groups and objects, expceted groups number: " +
                        param.ScopeTarget[param.ScopeTarget.Keys.First()].Count + 
                        ", actrual numbers: " +
                        scopePage.Controls.GroupsAndObjectsDataGrid.RowsExtended.Count);

                    return false;
                }                

                foreach (var row in scopePage.Controls.GroupsAndObjectsDataGrid.Rows)
                {
                    var aa = RPFSupport.RPF.FindAllScreenElements(row.Cells[statewidget.displayNameColumn].ScreenElement,
                  ";[UIA,FindAll]AutomationId='SCOMDataGridCellContentControl'",
                  null,
                  1);

                    if (aa.Count == 0)
                        throw new Window.Exceptions.WindowNotFoundException("Cannot find cell content control with AutomationId.");                                       
                    
                    if (!param.ScopeTarget[param.ScopeTarget.Keys.First()].Equals(aa[0].Name))
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: Failed to set Groups and objects.");
                        return false;
                    }
                    else
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: verified ScopePage");
                        result = true;
                    }
                }              
                       
             }

            //Verify Class set
            if (param.Class != null)
            {
                if (param.Class != scopePage.Controls.AllClassesStaticControl.ScreenElement.Name.ToString())
                {
                    //Workaroud localize bug 235158
                    scopePage.ClickReset();
                    if (param.Class != scopePage.Controls.AllClassesStaticControl.ScreenElement.Name.ToString())
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: Failed to set Class, expected : " +
                        param.Class +
                        ", actrual : " +
                        scopePage.Controls.AllClassesStaticControl.ScreenElement.Name.ToString());

                        return false;
                    }
                    else
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: Successfully to set Class, expected : " +
                        param.Class +
                        ", actrual : " +
                        scopePage.Controls.AllClassesStaticControl.ScreenElement.Name.ToString());
                        scopePage.ClickNext();
                    }

                    
                }
                else
                {
                    MomCommon.Utilities.LogMessage(currentMethod + ":: verified ScopePage");
                    result = true;
                    scopePage.ClickNext();
                }
            }
            else
            {
                scopePage.ClickNext();
            }            
           
            #endregion

            #region Verify Creitria Page

            MomCommon.Utilities.LogMessage(currentMethod + ":: Verifying Criteria Page updated...");
            Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetCritriaPage CriteriaPage = new StateWidgetCritriaPage(CoreManager.MomConsole, MomCommon.Constants.DefaultDialogTimeout, wizard.WizardTitle);

            if (null != param.Criteria)
            {
                if (param.Criteria.Contains("All"))
                {
                    if (CriteriaPage.Controls.HealthStatesCheckBox.ButtonState == ButtonState.UnChecked)
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: verified Criteria Page with HealthStatesCheckBox");
                        result = true;
                    }
                    else
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: Failed veirified Criteria Page");
                        return false;
                    }
                }
                else
                {
                    foreach (ListViewItem item in CriteriaPage.Controls.HealthStatesListView.Items)
                    {
                        MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                        if (param.Criteria.Contains(listItem[0].Name))
                        {
                            if (!item.Checked)
                            {
                                MomCommon.Utilities.LogMessage(currentMethod + ":: Failed veirified Criteria Page with List check box");
                                return false;
                            }
                        }
                        else
                        {
                            if (item.Checked)
                            {
                                MomCommon.Utilities.LogMessage(currentMethod + ":: Failed veirified Criteria Page List check box");
                                return false;
                            }
                        }
                    }

                    MomCommon.Utilities.LogMessage(currentMethod + ":: verified Criteria Page");
                    result = true;

                }
            }            

            if (param.ShowOnlyMaintenanceMode != null)
            {
                if(param.ShowOnlyMaintenanceMode == true)
                {
                    if (CriteriaPage.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.ButtonState != ButtonState.Checked)
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: Failed veirified Criteria Page with ShowOnlyMaintenanceMode");
                        return false;
                    }                    
                }    
                else 
                {
                    if (CriteriaPage.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.ButtonState != ButtonState.UnChecked)
                    {
                        MomCommon.Utilities.LogMessage(currentMethod + ":: Failed veirified Criteria Page with ShowOnlyMaintenanceMode");
                        return false;
                    }                    
                }
                MomCommon.Utilities.LogMessage(currentMethod + ":: verified Criteria Page");
                result = true;  
            }

            CriteriaPage.ClickNext();

            #endregion

            #region Verify Display Page Update
            MomCommon.Utilities.LogMessage(currentMethod + ":: Verifying Personalization Page updated...");
            MomAlertComponent.Personalization.Personalization Personzalization = new MomAlertComponent.Personalization.Personalization(MomAlertComponent.Personalization.AlertPersonalizationDialog.Strings.ConfigurationDialogTitle);
                        
            if (param.DisplayColumn != null)
            {
                result = Personzalization.VerifyColumnsDisplaySettings(param.DisplayColumn, param.DisplayIndex, param.ShowAllColumnsToDisplay);
                if (!result)
                {
                    return result;
                }
            }           
                       
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(Personzalization.updatePersonalizationDialog.Controls.CancelButton, MomCommon.Constants.OneMinute);
            Personzalization.updatePersonalizationDialog.ClickCancel();
            CoreManager.MomConsole.ConfirmChoiceDialog(
           MomConsoleApp.ButtonCaption.OK,
           ConsoleApp.Strings.CancelWizardDialogTitle,
           StringMatchSyntax.WildCard,
           MomConsoleApp.ActionIfWindowNotFound.Ignore);

            #endregion

            return result;
        }
       

        public struct CustomPagesParams : ICustomPageParams
        {
            public string Name;
            public string Description;            
            public string ColumnDisplayName;
            public Dictionary<string, List<string>> ScopeTarget;
            public string ShowMembers;
            public string Class;
            public List<string> Criteria;
            public bool ShowOnlyMaintenanceMode;
            public bool ShowAllColumnsToDisplay;
            public List<int> DisplayIndex;
            public List<string> DisplayColumn; 
                       
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