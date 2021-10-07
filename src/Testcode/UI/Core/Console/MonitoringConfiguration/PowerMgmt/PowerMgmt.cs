// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SLASLO.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 UI Test Automation
// </project>
// <summary>
// 	PowerMgmt Base Class and Parameters Class in the Core Library.  
// </summary>
// <history>
// 	[dialac]    22JAN09     Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.PowerMgmt
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.XPath;
    using System.ComponentModel;
    using System.IO;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.Dialogs;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.PowerMgmt.Dialogs;
    //using Mom.Test.UI.Core.Console.Views.HealthConfiguration;
    #endregion

    /// <summary>
    /// Class to add general methods for PowerManagement 
    /// </summary>
    /// <history> 	
    ///   [dialac]  22Jan09    Created
    /// </history>
    public class PowerMgmt
    {

        #region Private Members

        /// <summary>
        /// Generate Random String Based of User Local
        /// </summary>
        RandomStrings randomNames = new RandomStrings();

        /// <summary>
        /// ExcludedCharacters array to use on generatedName and generatedAlertViewDes
        /// </summary>
        char[] excludedCharacters = Core.Common.Utilities.ExcludedCharacters();

        /// <summary>
        /// Constant to zero string
        /// </summary>
        private const string zeroString = "";


        //Go to Monitored component node in navigation pane
        string powerConsumptionPath = NavigationPane.Strings.MonitoringConfiguration
            + "\\"
            + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents
            + "\\"
            + SelectComponentTypeDialog.Strings.PowerConsumptionTemplate;


        # region cached variables for all wizard pages

        /// <summary>
        /// cachedComponentTypeDialog
        /// </summary>
        private SelectComponentTypeDialog cachedComponentTypeDialog;
        
        /// <summary>
        /// cachedgeneralPropertiesTemplateDialog
        /// </summary>
        private GeneralPropertiesWizardDialog cachedgeneralPropertiesTemplateDialog;

        /// <summary>
        /// cachedpowerDomainSettingsDialog
        /// </summary>
        private PowerDomainSettingsDialog cachedpowerDomainSettingsDialog;

        /// <summary>
        /// cachedDevicesDialog
        /// </summary>
        private DevicesDialog cachedDevicesDialog;
        
        /// <summary>
        /// cachedsummaryDialog
        /// </summary>
        private SummaryDialog cachedsummaryDialog;

        #endregion //cached variables. 

        #endregion

        #region Constructor
        /// <summary>
        /// Power Management Class
        /// </summary>
        public PowerMgmt()
        {
            
        }
        #endregion

        #region Enumerators section

        /// <summary>
        /// Power Domain - power budget type 
        /// </summary>
        public enum PDPowerBudgetType
        {
            /// <summary>
            /// PercentValue
            /// </summary>
            Percent,

            /// <summary>
            /// AbsoluteValue
            /// </summary>
            Absolute,

        }
        #endregion

        #region Properties 
        /// <summary>
        /// Select Component Type Dialog
        /// </summary>
        public SelectComponentTypeDialog componentTypeDialog
        {
            get
            {
                if (this.cachedComponentTypeDialog == null)
                {
                    this.cachedComponentTypeDialog = new SelectComponentTypeDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Component Type Dialog was successful");
                }

                return this.cachedComponentTypeDialog;
            }
        }


        /// <summary>
        /// General Properties Dialog
        /// </summary>
        public GeneralPropertiesWizardDialog generalPropertiesTemplateDialog
        {
            get
            {
                if (this.cachedgeneralPropertiesTemplateDialog == null)
                {
                    this.cachedgeneralPropertiesTemplateDialog = new GeneralPropertiesWizardDialog(
                        CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }

                return this.cachedgeneralPropertiesTemplateDialog;
            }
        }


        /// <summary>
        /// Power Domain Setting Dialog
        /// </summary>
        public PowerDomainSettingsDialog powerDomainSettingsDialog
        {
            get
            {
                if (this.cachedpowerDomainSettingsDialog == null)
                {
                    this.cachedpowerDomainSettingsDialog = new PowerDomainSettingsDialog(
                        CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Power Domain settings Dialog was successful");
                }

                return this.cachedpowerDomainSettingsDialog;
            }
        }


        /// <summary>
        /// Power Domain - Devices Dialog
        /// </summary>
        public DevicesDialog devicesDialog
        {
            get
            {
                if (this.cachedDevicesDialog == null)
                {
                    this.cachedDevicesDialog = new DevicesDialog(
                        CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Devices Dialog was successful");
                }

                return this.cachedDevicesDialog;
            }
        }


        /// <summary>
        /// Power Domain - Summary Dialog
        /// </summary>
        public SummaryDialog summaryDialog
        {
            get
            {
                if (this.cachedsummaryDialog == null)
                {
                    this.cachedsummaryDialog = new SummaryDialog(
                        CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Summary Dialog was successful");
                }

                return this.cachedsummaryDialog;
            }
        }


        #endregion
        
        #region Public Methods

        /// <summary>
        /// Creates a Power Domain based on the parameters info passed through the 
        /// PowerMgmtParameter instance
        /// </summary>
        /// <param name="param">PowerMgmt Parameter class containing power domain config</param> 
        /// <history>
        /// [dialac] 24jan01 - Created        
        /// </history>
        public void CreatePowerDomain(PowerMgmtParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

                     
            if (null == param)
            {
                Utilities.LogMessage(String.Format(
                        "{0}:: The powerMgmt parameter class with the powerDomain information can not be null", 
                            currentMethod));
                throw new System.ArgumentNullException("The powerMgmt parameter is null");
            }

            #region Launch Power Mgmt Wizard 

            // Get Reference to Actions Pane. And select the wizard from the actions pane.
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;

            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;

            actionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration,
                monitoredComponentsPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents,
                Templates.Strings.LaunchComponentWizardTask);

            Utilities.LogMessage(currentMethod + ":: Selected "
                + Templates.Strings.LaunchComponentWizardTask);

            // Based on the Type parameter; Select the component Type 
            string typeSelected = SelectComponentTypeDialog.Strings.PowerConsumptionTemplate;
      
            Maui.Core.WinControls.TreeNode myNode = null;
            myNode = this.componentTypeDialog.Controls.SelectComponentTypeTreeView.Find(typeSelected);
            Utilities.LogMessage(currentMethod + ":: Found component type '" + typeSelected + "'");

            myNode.Select();
            Utilities.LogMessage(currentMethod + ":: Successfully selected component type '" +
                typeSelected + "'");
            myNode.Click();
            this.componentTypeDialog.WaitForResponse();

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.componentTypeDialog.Controls.NextButton, Constants.OneMinute);
            Utilities.LogMessage(currentMethod + ": Successfully clicked on component type");

            this.componentTypeDialog.ClickNext();
            //this.componentTypeDialog.WaitForResponse();
            //this.cachedComponentTypeDialog = null;
            this.generalPropertiesTemplateDialog.WaitForResponse();

            #endregion
            
            //Setting the properties in the General Page: Name, Description and MP
            this.SettingFieldsGeneralPage(param.PowerDomainName, param.PowerDomainDescription, param.PowerDomainDestinationMP);
            Sleeper.Delay(1000);
            //Navigating to the next page: Power Domain Settings
            this.generalPropertiesTemplateDialog.ClickNext();
            this.cachedgeneralPropertiesTemplateDialog = null;
            this.powerDomainSettingsDialog.WaitForResponse();

            //Setting the Power Domain Properties: maxCapacity and budget value. 
            this.SettingPowerDomainPage(param.PowerDomainMaxCapacity, param.PowerBudgetType, param.PowerDomainBudgetValue);
            Sleeper.Delay(1000);
            //Navigating to the next page: Device Page
            this.powerDomainSettingsDialog.ClickNext();
            this.cachedComponentTypeDialog = null;
            this.devicesDialog.WaitForResponse();

            //Setting the group and power consumption for unmanageable devices
            this.SettingDevicesPage(param.PowerDomainGroup, param.PowerConsumptionUnmanageableDevices);
            Sleeper.Delay(1000);
            //Navigating to the next page: Summary page
            this.devicesDialog.ClickNext();
            this.cachedDevicesDialog = null;
            this.summaryDialog.WaitForResponse(); 

            //Getting the Information from Summary Page
            ListView summaryInfo = this.summaryDialog.Controls.SummaryListView;
            //TODO - dialac - Verify the Summary Info. 
            //this.VerifySummaryPageInfo(param, summaryInfo); 
            

            //Clicking finish in the wizard. 
            this.summaryDialog.ClickCreate();
            //this.cachedsummaryDialog = null;
            this.summaryDialog.WaitForResponse();

            //Waiting until 1 minute for the wizard to finish. 
            bool isWizardFinished = CoreManager.MomConsole.WaitForDialogClose(this.summaryDialog, 60);
            if (isWizardFinished == false)
            {
                Utilities.LogMessage(currentMethod + ":: Failed to finish the Wizard after 1 minute");
                throw new Maui.GlobalExceptions.TimedOutException("Power Domain template wizard failed to finish after 1 minute"); 
            }

        }


        /// <summary>
        /// Try to find and select a Power Domain in the View pane. 
        /// Return false if the powerDomain is not found in the view. 
        /// </summary>
        /// <param name="powerDomainName">PowerDomain Name to be found/selected</param> 
        /// <history>
        /// [dialac] 26JAN09 - Created        
        /// </history>
        public bool PowerDomainExists(string powerDomainName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");
            Utilities.LogMessage(String.Format("{0}:: Looking for Power Domain '{1}'", 
                        currentMethod, powerDomainName));

            bool result; 

            Templates templates = new Templates();
            if (templates.ComponentExists(Templates.ComponentType.PowerConsumption, powerDomainName))
            {
                Utilities.LogMessage(String.Format("{0}:: Found '{1} in Monitored Components view", 
                            currentMethod, powerDomainName));
                result = true;  
            } 
            else
            {
                Utilities.LogMessage(String.Format("{0}:: Failed to find '{1}' in Monitored Components view",
                        currentMethod, powerDomainName));
                result = false; 
                //TODO - Dialac - Remove this. 
                //throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException("Failed to find " + parameters.Name + " in Monitored Components view");
            }

            return result;
          
        }
        
        /// <summary>
        /// Delete a PowerDomain 
        /// </summary>
        /// <param name="powerDomainName">PowerDomain name</param> 
        /// <history>
        /// [dialac] 27JAN09 - Created        
        /// </history>
        public void DeletePowerDomain(String powerDomainName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            bool powerDomainFound = false;
            powerDomainFound = this.LookForPowerDomainView(powerDomainName);

            if (powerDomainFound == false)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the PowerDomain was not found in the view", currentMethod));
                throw new ListView.Exceptions.ItemNotFoundException("the PowerDomain was not found in the view");
            }

           
            // Selecting Delete option from Action pane once the powerDomain is selected. 
            CoreManager.MomConsole.ActionsPane.ClickLink(
                NavigationPane.WunderBarButton.MonitoringConfiguration,
                powerConsumptionPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents,
                Strings.ActionDeleteTemplate);

            Utilities.LogMessage(currentMethod +
                ":: Successfully clicking on Delete option in the Action Pane");

            try
            {
                //select Yes on the delete confirmation dialog
                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes,
                    Templates.Strings.DeleteMonitoringDialogTitle, StringMatchSyntax.ExactMatch,
                    MomConsoleApp.ActionIfWindowNotFound.Error);
                //Wait until cursor type changes from busy icon
                Utilities.LogMessage(String.Format("{0}:: Succesfully call the Delete action for the PowerDomain", currentMethod));
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: Failed to find window {1}", currentMethod, Templates.Strings.DeleteMonitoringDialogTitle));
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                throw new Window.Exceptions.WindowNotFoundException(currentMethod +
                    "::Couldn't find the Deletion Confirmation Dialog for the PowerDomain");
            }

        }
        /// <summary>
        /// Verify if the PowerDomain was deleted and it doesn't show in the view anymore. 
        /// </summary>
        /// <param name="powerDomainName">PowerDomain name</param> 
        /// <history>
        /// [dialac] 27JAN09 - Created        
        /// </history>
        public void VerifyDeletedPowerDomain(String powerDomainName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            int retry = 0;
            int maxRetry = 5;

            bool powerDomainFound = true;

            Utilities.LogMessage(String.Format("{0} ::Looking for powerDomain '{1}'. It shouldn't be found.", 
                                currentMethod, powerDomainName));


            while (powerDomainFound == true && retry < maxRetry)
            {
                //Selecting the powerDOmain in the View
                powerDomainFound = this.LookForPowerDomainView(powerDomainName);
                Utilities.LogMessage(String.Format(
                        "{0}:: Attempt {1} of {2} looking for deleted powerDomain in the view. Found? {2}",
                        currentMethod, retry, maxRetry, powerDomainFound));
                retry++;

            }

            if (powerDomainFound == true)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the PowerDomain was still found in the view after it's been deleted.", currentMethod));
                throw new Maui.GlobalExceptions.MauiException(
                    "the PowerDomain was still found in the view after it's been deleted.");
            }

        }
        

        #endregion

        #region Private Methods

        /// <summary>
        /// Set fields in the General page: Name, Description and MP
        /// </summary>
        /// <param name="powerDomainName">power domain Name</param>
        /// <param name="powerDomainDescription">power domain Description</param>
        /// <param name="powerDomainMP">power domain Description</param>
        /// <history>
        /// [dialac] 24jan09 - Created        
        /// </history>
        private void SettingFieldsGeneralPage(string powerDomainName, string powerDomainDescription, string powerDomainMP)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            // General Page
            // Trying to set the name -- if its null throws System.ArgumentNullException
            if (null != powerDomainName)
            {
                //Sleeper.Delay(5000);
                this.generalPropertiesTemplateDialog.PowerDomainNameText = powerDomainName;
                Utilities.LogMessage(currentMethod + ":: Set Power Domain display name '" +
                    this.generalPropertiesTemplateDialog.PowerDomainNameText + "'");
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Power Domain Name cannot be null.");
                //CLosing the wizard before throwing a exception. 
                this.generalPropertiesTemplateDialog.ClickCancel();
                throw new System.ArgumentNullException("Power Domain Name cannot be null!");
            }

            if (null != powerDomainDescription)
            {
                this.generalPropertiesTemplateDialog.DescriptionText = powerDomainDescription;
                Utilities.LogMessage(currentMethod + ":: Set Power Domain description '"
                + this.generalPropertiesTemplateDialog.DescriptionText + "'");
            }

            if (null != powerDomainMP)
            {
                //If null - the Default MP is going to be used.
                Utilities.LogMessage(String.Format("{0}:: The Destination MP is: {1}",
                    currentMethod, powerDomainMP));
                this.generalPropertiesTemplateDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(powerDomainMP);
                Utilities.LogMessage(currentMethod + ":: Set Power Domain MP '"
                    + this.generalPropertiesTemplateDialog.SelectDestinationManagementPackText + "'");
            }


        }


        /// <summary>
        /// Set properties for the PowerDomain: MaxCapacity and Budget
        /// </summary>
        /// <param name="maxCapacity">power domain Max Capacity</param>
        /// <param name="budgetValueType">Budget Type: Percent or Absolute value</param>
        /// <param name="budgetValue">power domain Budget</param>
        /// <history>
        /// [dialac] 24jan09 - Created        
        /// </history>
        private void SettingPowerDomainPage(string maxCapacity, PDPowerBudgetType budgetValueType, string budgetValue)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (maxCapacity == zeroString || budgetValue == zeroString)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: max capacity or budget can't be ZERO", currentMethod));
                throw new System.ArgumentNullException("Power Domain Max Capacity or Budget can not be ZERO");
            }

            #region Checking some default field values in this page
            //TODO dialac - Add verification if the Power Domain Name appears in the page as ready-only

            //Checking if MaxCapacity has zero and NEXT button disabled. 
            if (this.powerDomainSettingsDialog.MaximumCapacityText == zeroString)
            {
                //if the maxCapacityText is different from zero, means that I'm opening this page from Properties CxtMenu
                //And some values is setup for it. 

                //The check that I can make here is to make sure the NEXT button is disabled. 
                if (this.powerDomainSettingsDialog.Controls.NextButton.IsEnabled == true)
                {
                    Utilities.LogMessage(String.Format(
                        "{0}:: NEXT button should be disabled when maxCapacity is ZERO", currentMethod));
                    //TODO - dialac - Is there a more specific exception???
                    throw new Maui.GlobalExceptions.MauiException("NEXT button should be disabled when maxCapacity is ZERO");
                }

            }

            //Checking the Budget type Default option
            if (this.powerDomainSettingsDialog.RadioPowerBudget ==
                       RadioPowerBudget.PercentOfTotalPowerCapacity)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The Percent value option is selected by default.", currentMethod));
                //TODO DIALAC - REmove this delay
                Sleeper.Delay(2000);
            }
            else
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The Percent value option is selected by default.", currentMethod));
                throw new Maui.GlobalExceptions.MauiException(
                    "The Percent value option for Budget is NOT selected by default.");
            }
            #endregion

            //Setting the MaxCapacity 
            Utilities.LogMessage(String.Format("{0}:: Setting the Max Capacity", currentMethod));
            //string maxCapacityString = maxCapacity.ToString();
            Utilities.LogMessage (String.Format ("{0}:: The max Capacity to be set is: {1}", currentMethod, maxCapacity));
            this.powerDomainSettingsDialog.MaximumCapacityText = maxCapacity;

            //Setting the Budget
            Utilities.LogMessage(String.Format("{0}:: Setting the Budget to type {1} and value {2}", 
                        currentMethod,
                        budgetValueType, 
                        budgetValue));
            if (budgetValueType == PDPowerBudgetType.Percent)
            {
                if (this.powerDomainSettingsDialog.RadioPowerBudget == RadioPowerBudget.KW)
                {
                    this.powerDomainSettingsDialog.RadioPowerBudget = RadioPowerBudget.PercentOfTotalPowerCapacity;
                }
                this.powerDomainSettingsDialog.PercentBudgetText = budgetValue;

                 Utilities.LogMessage(String.Format("{0}:: The value for budget setup in the page is: {1}", 
                        currentMethod,
                        this.powerDomainSettingsDialog.PercentBudgetText));
            }
            else if (budgetValueType == PDPowerBudgetType.Absolute)
            {
                if (this.powerDomainSettingsDialog.RadioPowerBudget == RadioPowerBudget.PercentOfTotalPowerCapacity)
                {
                    this.powerDomainSettingsDialog.RadioPowerBudget = RadioPowerBudget.KW;
                }
                this.powerDomainSettingsDialog.AbsoluteBudgetText = budgetValue;

                 Utilities.LogMessage(String.Format("{0}:: The value for budget setup in the page is: {1}", 
                        currentMethod,
                        this.powerDomainSettingsDialog.AbsoluteBudgetText));
            }
        }
        
        /// <summary>
        /// Set Device group and power consumption for unmanageable devices
        /// </summary>
        /// <param name="groupName">Device Group name</param>
        /// <param name="powerConsumption">Optional power Consumption</param>
        /// <history>
        /// [dialac] 24jan09 - Created        
        /// </history>
        private void SettingDevicesPage(string groupName, string powerConsumption)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (null == groupName)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: Device Group Name is null", currentMethod));
                throw new System.ArgumentNullException("Device group for the Power Domain cannot be null.");
            }

            Utilities.LogMessage(String.Format("{0}:: The Group name is: {1}", currentMethod, groupName));

            this.devicesDialog.ClickDevicesGroup();

            #region Group Search Dialog Box

            GroupSearchDialog groupSearchPage = new GroupSearchDialog(CoreManager.MomConsole);

            //TODO - dialac - add support to the filter criteria in this page. 
            //if (parameters.filters != null)
            //    groupSearchPage.TextFilterText = parameters.filters;

            //if (parameters.MPFilter != null)
            //    groupSearchPage.MPFilterText = parameters.MPFilter;

            groupSearchPage.ClickSearch();

            ListViewItemCollection groupToSelect;
            int retries = 0;
            int maxRetries = 20;

            //Workaround on possibly time issue if we have a big number of groups to load. Max wait=> 60 seconds. 
            while (groupSearchPage.Controls.GroupsListView.Count == 0 && retries < maxRetries)
            {
                retries++;
                Utilities.LogMessage(currentMethod + ":: Waiting for Group List to populate.");
                Utilities.LogMessage(currentMethod + ":: Attempt " + retries + " of " + maxRetries);
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
            }

            retries = 0;
            maxRetries = 5;

            bool foundGroup = false;
            groupSearchPage.Controls.GroupsListView.WaitForResponse();
            while (retries < maxRetries && foundGroup == false)
            {
                groupToSelect = groupSearchPage.Controls.GroupsListView.FindAllByText(groupName);
                if (groupToSelect.Count > 0)
                {
                    //Always get the first found item based in the groupName. 
                   //groupToSelect[0].Click();
                    groupToSelect[0].Select();               //Don't use listviewitem.click() to select a listviewitem.  see bug #163609.
                    foundGroup = true;
                }
                retries++;
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
            }
            if (foundGroup == false)
            {
                Utilities.LogMessage(currentMethod + ":: Failed to find " + groupName + " in the groups list.");
                groupSearchPage.ClickCancel();
                throw new ListView.Exceptions.ItemNotFoundException("Failed to find " + groupName + " in the groups list.");
            }
            Utilities.LogMessage(currentMethod + ":: Trying To Click OK in the Group Search Dialog");

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(groupSearchPage.Controls.OKButton);
            groupSearchPage.ClickOK();
            Utilities.LogMessage(currentMethod + ":: OK Clicked");
            CoreManager.MomConsole.WaitForDialogClose(groupSearchPage, Constants.DefaultDialogTimeout);
            #endregion

            //Setting the Additional Power Consumption if for unmanageable devices.
            if (powerConsumption != zeroString)
            {
                Utilities.LogMessage(String.Format("{0}:: setting the powerConsumption to {1}",
                        currentMethod, powerConsumption));
                this.devicesDialog.UnmonitoredPowerText = powerConsumption;
                Utilities.LogMessage(String.Format("{0}:: the value in the page now is",
                        currentMethod, this.devicesDialog.UnmonitoredPowerText));
            }
         
        }

        /// <summary>
        /// Check the information in the summary page 
        /// </summary>
        /// <param name="param">information used to create the power Domain</param>
        /// <param name="summaryInfo">Information gotten from the Summary page</param>
        /// <history>
        /// [dialac] 27JAN09 - Created        
        /// </history>
        private void VerifySummaryPageInfo(PowerMgmtParameters param, ListView summaryInfo)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (null == param)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: Power Domain param is null", currentMethod));
                throw new System.ArgumentNullException("Power Domain Parameters cannot be null.");
            }

            if (null == summaryInfo)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The summary info in the page is null", currentMethod));
                throw new System.ArgumentNullException("The summary info in the page cannot be null.");
            }

            Utilities.LogMessage("Debugg - DIALAC *******-> Summary count = " + summaryInfo.Count);
            Utilities.LogMessage("Debugg - DIALAC *******-> Summary ItemsCount = " + summaryInfo.Items.Count);

            for (int i = 0; i < summaryInfo.Items.Count; i++)
            {
                Utilities.LogMessage("Debugg - DIALAC *******-> Summary ItemTExt = " + summaryInfo.Items[i].Text);
                Utilities.LogMessage("Debugg - DIALAC *******-> Summary ItemColumnTExt = " + summaryInfo.Columns[0].Text);
                Utilities.LogMessage("Debugg - DIALAC *******-> Summary ItemColumnTExt = " + summaryInfo.Exists("Power domain name"));
            }

            Utilities.LogMessage("Debugg - DIALAC *******-> Summary Column = " + summaryInfo.Columns.Count);
            //Utilities.LogMessage("Debugg - DIALAC *******-> Summary count = " + summaryInfo.Count); 

        }

        /// <summary>
        /// Look for a PowerDomain in the View
        /// </summary>
        /// <param name="powerDomainName">PowerDomain name</param> 
        /// <history>
        /// [dialac] 27JAN09 - Created        
        /// </history>
        private bool LookForPowerDomainView(String powerDomainName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            Maui.Core.WinControls.DataGridViewRow powerDomainRow = null;
            bool powerDomainFound = false;

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            int maxTries = 0;
            //# retry attempts
            while (maxTries < 2)
            {
                navPane.SelectNode(this.powerConsumptionPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                Utilities.LogMessage(currentMethod + ":: Selected Node Power Consumption in Navigation Pane");
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                try
                {
                    powerDomainRow = CoreManager.MomConsole.ViewPane.Grid.FindData(
                                powerDomainName,
                                Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
                }
                catch (NullReferenceException)
                {
                    //catch array nullreferenceexception when datagrid row count changed to zero in FindData method
                    Utilities.LogMessage(string.Format("{0}::FindData got a nullReferenceException when find data,refrash and try again",currentMethod));
                }
                catch (Exception ex)
                {
                    Utilities.LogMessage(string.Format("{0}::FindData got an exception in ViewPane.grid", currentMethod));
                    ex = new Exception("an error occur in grid FindData");
                    throw ex;
                }
                if (powerDomainRow != null)
                {
                    powerDomainFound = true;
                    Utilities.LogMessage(String.Format(
                    "{0}:: the PowerDomain was found in the view", currentMethod));
                    //Selecting the row - powerDomain found
                    powerDomainRow.AccessibleObject.Click();
                    break;
                }
                CoreManager.MomConsole.Refresh();
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                maxTries++;
            }

            if (powerDomainFound == false)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the PowerDomain was not found in the view", currentMethod));
                //throw new ListView.Exceptions.ItemNotFoundException("the PowerDomain was not found in the view");
            }

            return powerDomainFound;
        }
     

        #endregion
        
        #region PowerMgmtParameters Class
        /// <summary>
        /// Parameters class for PowerMgmt constructors.
        /// </summary>
        /// <history>
        /// [dialac] 24jan09 Created
        /// </history>
        public class PowerMgmtParameters
        {
            #region Private Members

            private string cachedPowerDomainName = null;
            private string cachedPowerDomainDescription = null;
            private string cachedPDDestinationMP = null;
            private string cachedPDMaxCapacity = zeroString;
            private PDPowerBudgetType cachedPowerBudgetType = PDPowerBudgetType.Absolute;
            private string cachedPowerBudgetValue = zeroString;
            private string cachedPowerDomainGroup = null;
            private string cachedPowerConsumptionUnmanageableDevices = zeroString;

            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public PowerMgmtParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Display Name of Power Domain
            /// </summary>
            public string PowerDomainName
            {
                get
                {
                    return this.cachedPowerDomainName;
                }

                set
                {
                    this.cachedPowerDomainName = value;
                }
            }

            /// <summary>
            /// Description for Power Domain
            /// </summary>
            public string PowerDomainDescription
            {
                get
                {
                    return this.cachedPowerDomainDescription;
                }

                set
                {
                    this.cachedPowerDomainDescription = value;
                }
            }

            /// <summary>
            /// Destination MP for Power Domain
            /// </summary>
            public string PowerDomainDestinationMP
            {
                get
                {
                    return this.cachedPDDestinationMP;
                }

                set
                {
                    this.cachedPDDestinationMP = value;
                }
            }

            /// <summary>
            /// Power Domain Max Capacity
            /// </summary>
            public string PowerDomainMaxCapacity
            {
                get
                {
                    return this.cachedPDMaxCapacity;
                }

                set
                {
                    this.cachedPDMaxCapacity = value;
                }
            }

            /// <summary>
            /// Power Domain Budget Value Type: Percent or Absolute.
            /// </summary>
            public PDPowerBudgetType PowerBudgetType
            {
                get
                {
                    return this.cachedPowerBudgetType;
                }

                set
                {
                    this.cachedPowerBudgetType = value;
                }
            }

            /// <summary>
            /// Power Domain BudgetValue. 
            /// </summary>
            public string PowerDomainBudgetValue
            {
                get
                {
                    return this.cachedPowerBudgetValue;
                }

                set
                {
                    this.cachedPowerBudgetValue = value;
                }
            }

            /// <summary>
            /// Power Domain Group 
            /// </summary>
            public string PowerDomainGroup
            {
                get
                {
                    return this.cachedPowerDomainGroup;
                }

                set
                {
                    this.cachedPowerDomainGroup = value;
                }
            }

            /// <summary>
            /// Power Consumption for unmanageable devices in the Power Domain
            /// </summary>
            public string PowerConsumptionUnmanageableDevices
            {
                get
                {
                    return this.cachedPowerConsumptionUnmanageableDevices;
                }

                set
                {
                    this.cachedPowerConsumptionUnmanageableDevices = value;
                }
            }

            #endregion
        } // End of Parameters Class

        #endregion

        
    }//end of powerMgmt class 

    #region Strings Class
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Method to return translated resource string for PowerManagement
    /// </summary>
    /// <history> 	
    ///   [dialac]  24jan09: Added resource strings for PowerManagement Wizard
    /// </history>
    /// -----------------------------------------------------------------------------
    public class Strings
    {
        #region Constants

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string for the wizard dialog title.
        /// </summary>
        /// -----------------------------------------------------------------------------
        /// TODO - DIALAC - Get correct resource String. This is a copy and paste from SLA. 
        private const string ResourceDialogTitle = @";Power Consumption;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
            ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateSlaWizard";


        /// <summary>
        /// Template Delete action in the Action pane resource string.
        /// </summary>
        private const string ResourceActionDeleteTemplate = @";&Delete;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;DeleteMenuText";



        #endregion //Constants

        #region Private Members

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource the window or dialog title
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedDialogTitle;


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource for Delete option in Action Menu for the template.
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedActionDeleteTemplate;

        #endregion

        #region Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the DialogTitle translated resource string
        /// </summary>
        public static string DialogTitle
        {
            get
            {
                if ((cachedDialogTitle == null))
                {
                    cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                }
                return cachedDialogTitle;
            }
        }


        /// <summary>
        /// Template Delete Action in the action pane. 
        /// </summary>
        public static string ActionDeleteTemplate
        {
            get
            {
                if ((cachedActionDeleteTemplate == null))
                {
                    cachedActionDeleteTemplate = CoreManager.MomConsole.GetIntlStr(ResourceActionDeleteTemplate);

                    //Remove Ampersand from this string for Actions Pane
                    string removeAmp = String.Copy(cachedActionDeleteTemplate);
                    cachedActionDeleteTemplate = removeAmp.Replace("&", "");
                }

                return cachedActionDeleteTemplate;
            }
        }

        #endregion
    }
    #endregion

} //end of namespace 