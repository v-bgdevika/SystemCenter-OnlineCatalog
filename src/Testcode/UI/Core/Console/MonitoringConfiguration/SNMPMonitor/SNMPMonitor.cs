// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SNMPSettingsProperties.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// [v-bire] 31 DEC 2010 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SNMPMonitor
{
    #region Using directives
    using System;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Microsoft.EnterpriseManagement.Configuration;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.SNMPMonitor.Dialogs;
    using Mom.Test.UI.Core.Console.Views.HealthConfiguration;
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Provide utility method for SNMP monitor
    /// </summary>
    /// <history>
    /// 	[v-bire] 31 DEC 2010 Created
    /// 	[v-vijia] 24 MAR 2011 Edited
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SNMPMonitor
    {
        #region Private Members

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;

        /// <summary>
        /// Monitor type
        /// </summary>
        private SnmpMonitorType monitorType = SnmpMonitorType.Probe;
        #endregion

        #region Constructor

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SNMPMonitor()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        #region Public methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Add SNMP Monitor
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// 	[v-vijia] 24 MAR 2011 Edited
        /// </history>
        /// -----------------------------------------------------------------------------
        public void AddSNMPMonitor(Parameters parameters)
        {
            #region Navigate to a parent monitor and Launch Unit Monitor wizard
            Monitors monitor = new Monitors();
            monitor.LaunchCreateUnitMonitorWizard(parameters.MonitorTarget, parameters.ParentMonitor);
            #endregion

            #region Navigate through the wizard screens

            // Monitor Type
            InitMonitorType(parameters.MonitorType);
            switch (this.monitorType)
            {
                case SnmpMonitorType.Trap:
                    Utilities.LogMessage("AddSNMPMonitor:: Trap");
                    monitor.SelectMonitorType(Monitors.Strings.MonitorTypeFolderSNMPTrapSimpleGUID,
                        MonitorTypeDialog.Strings.SNMPTrapMonitorName );
                    break;

                case SnmpMonitorType.Probe:
                    Utilities.LogMessage("AddSNMPMonitor:: Probe");
                    monitor.SelectMonitorType(Monitors.Strings.MonitorTypeFolderSNMPProbeSimpleGUID,
                        MonitorTypeDialog.Strings.SNMPProbeMonitorName);
                    break;
            }

            //Create an instance of the first screen of the monitor wizard
            MonitorTypeDialog myMonitorWizard =
                new MonitorTypeDialog(CoreManager.MomConsole);
            myMonitorWizard.Controls.SelectDestinationManagementPackComboBox.SelectByText(Core.Common.Constants.UITestMPDisplayName);

            Utilities.LogMessage("Click Next");
            myMonitorWizard.ClickNext();

            // General
            MonitorGeneralPropertiesDialog generalPropertyDialog = new MonitorGeneralPropertiesDialog(this.consoleApp);
            Utilities.LogMessage("Setting the name to: '" + parameters.MonitorName);
            generalPropertyDialog.NameText = parameters.MonitorName;

            Utilities.LogMessage("Setting the description to: '" + parameters.Description);
            generalPropertyDialog.DescriptionOptionalText = parameters.Description;
            SNMPMonitor.SetCheckBoxState(generalPropertyDialog.Controls.MonitorIsEnabledCheckBox, parameters.MonitorEnabled);

            Utilities.LogMessage("Click Next");
            generalPropertyDialog.ClickNext();

            // First Snmp Provider
            SnmpProviderDialog snmpProviderDialog = new SnmpProviderDialog(this.consoleApp, monitorType, parameters.IsBackCompatMode);
            AddObjectIdentifier(snmpProviderDialog, parameters, 0);
            snmpProviderDialog.SetAllTrapsCheckBoxState(parameters.AllTraps);

            Utilities.LogMessage("Click Next");
            snmpProviderDialog.ClickNext();

            // First Build Expression
            SnmpBuildExpressionDialog snmpBuildExpressionDialog = new SnmpBuildExpressionDialog(this.consoleApp);
            AddSnmpBuildExpression(snmpBuildExpressionDialog, parameters);

            Utilities.LogMessage("Click Next");
            snmpBuildExpressionDialog.ClickNext();

            // Second Snmp Provider
            snmpProviderDialog = new SnmpProviderDialog(this.consoleApp, monitorType, parameters.IsBackCompatMode);
            AddObjectIdentifier(snmpProviderDialog, parameters, 0);
            snmpProviderDialog.SetAllTrapsCheckBoxState(parameters.AllTraps);

            Utilities.LogMessage("Click Next");
            snmpProviderDialog.ClickNext();

            // Second Build Expression
            snmpBuildExpressionDialog = new SnmpBuildExpressionDialog(this.consoleApp);
            AddSnmpBuildExpression(snmpBuildExpressionDialog, parameters);

            Utilities.LogMessage("Click Next");
            snmpBuildExpressionDialog.ClickNext();

            // Configure Health
            ConfigureHealthDialog configureHealthDialog = new ConfigureHealthDialog(this.consoleApp);

            SetHealthState(configureHealthDialog, parameters.FirstHealthState, TrapOrProbeRaised.First);
            SetHealthState(configureHealthDialog, parameters.SecondHealthState, TrapOrProbeRaised.Second);

            Utilities.LogMessage("Click Next");
            configureHealthDialog.ClickNext();

            // Configure Alerts
            ConfigureAlertsDialog configureAlertsDialog = new ConfigureAlertsDialog(this.consoleApp, MonitoringConfiguration.WindowCaptions.MonitorWizard);
            SNMPMonitor.SetCheckBoxState(configureAlertsDialog.Controls.GenerateAlertsCheckBox, parameters.GenerateAlert);

            Utilities.LogMessage("Click Create");
            configureAlertsDialog.ClickCreate();
            #endregion
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Edit SNMP Monitor
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public void EditSNMPMonitor(Parameters parameters)
        {
            // workaround to fix selection will be lost after pane refresh
            // It will be select monitor again if execute menu item failed. failed means the menu item is disabled
            Monitors monitor = new Monitors();
            monitor.LaunchMonitorPropertiesDialog(parameters.MonitorTarget, parameters.MonitorName);

            InitMonitorType(parameters.MonitorType);
            SNMPMonitorPropertiesDialog propertiesDialog = new SNMPMonitorPropertiesDialog(CoreManager.MomConsole, parameters.MonitorName);
            switch (parameters.TabTitleToEdit)
            {
                case SNMPMonitorPropertiesDialog.Strings.FirstExpressionTab:
                case SNMPMonitorPropertiesDialog.Strings.SecondExpressionTab:
                    EditExpressionTab(propertiesDialog, parameters);
                    break;

                case SNMPMonitorPropertiesDialog.Strings.FirstSnmpProbeTab:
                case SNMPMonitorPropertiesDialog.Strings.FirstSnmpTrapProviderTab:
                    EditSnmpProviderTab(propertiesDialog, parameters);
                    break;

                default:
                    throw new Exception("Unknown tab title to edit: " + parameters.TabTitleToEdit);
            }

            Utilities.LogMessage("Click OK button to save the change");
            propertiesDialog.Controls.OKButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Verify Edit SNMP Monitor
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// 	[v-vijia] 24 MAR 2011 Edited
        /// </history>
        /// -----------------------------------------------------------------------------
        public void VerifyEditSNMPMonitor(Parameters parameters)
        {
            Monitors monitor = new Monitors();
            monitor.LaunchMonitorPropertiesDialog(parameters.MonitorTarget, parameters.MonitorName);

            bool isExpected = true;

            SNMPMonitorPropertiesDialog propertiesDialog = new SNMPMonitorPropertiesDialog(CoreManager.MomConsole, parameters.MonitorName);
            switch (parameters.TabTitleToEdit)
            {
                case SNMPMonitorPropertiesDialog.Strings.FirstExpressionTab:
                case SNMPMonitorPropertiesDialog.Strings.SecondExpressionTab:
                    isExpected = CheckExpressionTab(propertiesDialog, parameters);
                    break;

                case SNMPMonitorPropertiesDialog.Strings.FirstSnmpProbeTab:
                case SNMPMonitorPropertiesDialog.Strings.FirstSnmpTrapProviderTab:
                    isExpected = CheckSnmpProviderTab(propertiesDialog, parameters);
                    break;

                default:
                    throw new Exception("Unknown tab title to edit: " + parameters.TabTitleToEdit);
            }

            Utilities.LogMessage("Click OK button to close the properties dialog");
            propertiesDialog.Controls.OKButton.Click();

            if (!isExpected)
            {
                throw new Exception("Verify edit snmp monitor failed");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Delete SNMP Monitor
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public void DeleteSNMPMonitor(Parameters parameters)
        {
            Monitors monitor = new Monitors();
            Utilities.LogMessage("Delete " + parameters.MonitorName + " from target " + parameters.MonitorTarget);
            monitor.Delete(parameters.MonitorTarget, parameters.MonitorName);
            Sleeper.Delay(10000); // ToDo: Write a method to verify if deleted
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Import management pack 
        /// </summary>
        /// <param name="mpFile">mp file name</param>
        /// <param name="mpName">mp name</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static void ImportManagementPack(string mpFile, string mpName)
        {
            if (!Utilities.ManagementPackExists(mpName))
            {
                Utilities.LogMessage("Importing MP: " + mpName);

                // Import the UI Test MP
                Utilities.ImportManagementPack(mpFile);
                Sleeper.Delay(10000); // A little sleeper to give system time to discover a little.
            }
            else
            {
                Utilities.LogMessage("No need to Import the " + mpName + "; already exits");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Uninstall management pack 
        /// </summary>
        /// <param name="mpName">mp name</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static void UninstallManagementPack(string mpName)
        {
            if (Utilities.ManagementPackExists(mpName))
            {
                Utilities.LogMessage("Management pack " + mpName + " was found, delete it");
                Utilities.UninstallManagementPack(mpName);
                Utilities.VerifyManagementPackDeleted(mpName);
            }
            else
            {
                Utilities.LogMessage("Management pack " + mpName + " does not exist");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Set check box state to specified state
        /// </summary>
        /// <param name="checkbox">check box</param>
        /// <param name="state">expected state</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static void SetCheckBoxState(CheckBox checkbox, bool state)
        {
            if (null == checkbox)
            {
                throw new ArgumentNullException("checkbox");
            }

            if (state ^ checkbox.Checked)
            {
                Utilities.LogMessage("Current checkbox state is: " + checkbox.Checked);
                Utilities.LogMessage("Set the checkbox state to: " + state);
                checkbox.Checked = state;
            }
        }
        #endregion

        #region Utility Method

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Add SNMP Build Expression
        /// </summary>
        /// <param name="dialog">An instance of SnmpBuildExpressionDialog</param>
        /// <param name="parameters">SNMP Parameters</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private void AddSnmpBuildExpression(SnmpBuildExpressionDialog dialog, Parameters parameters)
        {
            Utilities.LogMessage("Click Insert button");
            //dialog.ClickInsert();
            CoreManager.MomConsole.InvokeToolBarButton(dialog.Controls.FormulaToolStrip, SnmpBuildExpressionDialog.Strings.FormulaToolStripInsert);
            //Tab so the focus moves to the Expression
            Keyboard.SendKeys(KeyboardCodes.Tab);
            Keyboard.SendKeys(KeyboardCodes.Enter);
            
            Utilities.LogMessage("Set Parameter Name to: " + parameters.ParameterName);
            dialog.Controls.FormulaGrid.SetCellValue(dialog.Controls.FormulaGrid.Rows[1].Cells[0], parameters.ParameterName);

            Utilities.LogMessage("Set Parameter Operator to: " + parameters.ParameterOperator);
            dialog.Controls.FormulaGrid.SetCellOption(dialog.Controls.FormulaGrid.Rows[1].Cells[1], parameters.ParameterOperator);

            Utilities.LogMessage("Set Parameter Value to: " + parameters.ParameterValue);
            dialog.Controls.FormulaGrid.SetCellValue(dialog.Controls.FormulaGrid.Rows[1].Cells[2], parameters.ParameterValue);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Add Object Identifier
        /// </summary>
        /// <param name="dialog">An instance of SnmpProviderDialog</param>
        /// <param name="parameters">SNMP Parameters</param>
        /// <param name="rowPos">row position</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private void AddObjectIdentifier(SnmpProviderDialog dialog, Parameters parameters, int rowPos)
        {
            Utilities.LogMessage("Setting the object identifier to: " + parameters.ObjectIdentifier);
            dialog.AddObjectIdentifier(parameters.ObjectIdentifier, rowPos);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Set HealthState specified by event raised
        /// </summary>
        /// <param name="dialog">An instance of ConfigureHealthDialog</param>
        /// <param name="healthState">Health State</param>
        /// <param name="whichEvent">value of FirstEventRaised, SecondEventRaised</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private void SetHealthState(ConfigureHealthDialog dialog, string healthState, TrapOrProbeRaised whichRaised)
        {
            string uiHealthState = dialog.GetHealthState(whichRaised);
            if (!string.Equals(healthState, uiHealthState))
            {
                Utilities.LogMessage("Current first health state: " + uiHealthState);
                Utilities.LogMessage("Set first health state to: " + healthState);
                dialog.SetHealthState(healthState, whichRaised);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Select monitor
        /// </summary>
        /// <param name="name">monitor name</param>
        /// <param name="target">monitor target</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private void SelectMonitor(string target, string name)
        {
            Monitors monitor = new Monitors();
            Utilities.LogMessage("Select " + name + " from target " + target);
            monitor.SelectTargetMonitor(target, name);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Edit Expression Tab
        /// </summary>
        /// <param name="parameters">SNMP Parameters</param>
        /// <param name="propertiesDialog">An instance of SNMPMonitorPropertiesDialog</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private void EditExpressionTab(SNMPMonitorPropertiesDialog propertiesDialog, Parameters parameters)
        {
            int maxRetry = Constants.DefaultMaxRetry;

            Utilities.LogMessage("Select tab: " + parameters.TabTitleToEdit);
            propertiesDialog.SelectTab(parameters.TabTitleToEdit);

            SnmpBuildExpressionDialog buildExpressionDialog = new SnmpBuildExpressionDialog(this.consoleApp, propertiesDialog.Controls.TabPagesTabControl.SelectedTab.AccessibleObject.Window);

            Utilities.LogMessage("Set Parameter Name to: " + parameters.NewParameterName);

            for (int i = 0; i < maxRetry; i++)
            {
                try
                {
                    buildExpressionDialog.Controls.FormulaGrid.ClickCell(1,0);//try to avoid setting value failed.
                    buildExpressionDialog.Controls.FormulaGrid.SetCellValue(buildExpressionDialog.Controls.FormulaGrid.Rows[1].Cells[0], parameters.NewParameterName);
                    break;
                }
                catch (Exception exp)
                {
                    Core.Common.Utilities.LogMessage("Set cell value Exception: " + exp.Message);
                    Core.Common.Utilities.LogMessage("Attempt " + (i + 1) + " of " + maxRetry);
                    Core.Common.Utilities.TakeScreenshot("Set Parameter Name Exception"+(i+1));

                    //Click value cell and then back to click parameter name cell, in order to work around test bug #454448
                    buildExpressionDialog.Controls.FormulaGrid.ClickCell(1, 2);
                    buildExpressionDialog.Controls.FormulaGrid.ClickCell(1, 0);
                    Sleeper.Delay(5000); //wait 5 second for next retry

                    if ((i + 1) == maxRetry)
                    {
                        Core.Common.Utilities.LogMessage("Set Parameter Name has reached max retry times, but this operate still failed. ");
                        throw new Exception("Set Parameter Name Failed.");
                    }
                }
            }

            Utilities.LogMessage("Set Parameter Operator to: " + parameters.NewParameterOperator);
            for (int i = 0; i < maxRetry; i++)
            {
                try
                {
                    buildExpressionDialog.Controls.FormulaGrid.SetCellOption(buildExpressionDialog.Controls.FormulaGrid.Rows[1].Cells[1], parameters.NewParameterOperator);
                    break;
                }
                catch (Exception exp)
                {
                    propertiesDialog.Extended.ClickTitle(); //Change the focus
                    Core.Common.Utilities.LogMessage("Exception: " + exp.Message);
                    Core.Common.Utilities.LogMessage("Attempt " + (i + 1) + " of " + maxRetry);
                }
            }
            
            Utilities.LogMessage("Set Parameter Value to: " + parameters.NewParameterValue);
            for (int i = 0; i < maxRetry; i++)
            {
                try
                {
                    buildExpressionDialog.Controls.FormulaGrid.SetCellValue(buildExpressionDialog.Controls.FormulaGrid.Rows[1].Cells[2], parameters.NewParameterValue);
                    break;
                }
                catch (Exception exp)
                {
                    propertiesDialog.Extended.ClickTitle(); //Change the focus
                    Core.Common.Utilities.LogMessage("Exception: " + exp.Message);
                    Core.Common.Utilities.LogMessage("Attempt " + (i + 1) + " of " + maxRetry);
                }
            }
           
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Check Expression Tab
        /// </summary>
        /// <remarks>boolean value to indicate if check success</remarks>
        /// <param name="parameters">SNMP Parameters</param>
        /// <param name="propertiesDialog">An instance of SNMPMonitorPropertiesDialog</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private bool CheckExpressionTab(SNMPMonitorPropertiesDialog propertiesDialog, Parameters parameters)
        {
            bool result = true;

            Utilities.LogMessage("Select tab: " + parameters.TabTitleToEdit);
            propertiesDialog.SelectTab(parameters.TabTitleToEdit);

            SnmpBuildExpressionDialog buildExpressionDialog = new SnmpBuildExpressionDialog(this.consoleApp, propertiesDialog.Controls.TabPagesTabControl.SelectedTab.AccessibleObject.Window);
            Utilities.LogMessage("Verify Parameter Name");
            result &= CheckCellValue(buildExpressionDialog.Controls.FormulaGrid.Rows[1].Cells[0], parameters.NewParameterName);
            Utilities.LogMessage("Result=" + result);

            Utilities.LogMessage("Verify Parameter Operator");
            result &= CheckCellOption(buildExpressionDialog.Controls.FormulaGrid.Rows[1].Cells[1], parameters.NewParameterOperator);
            Utilities.LogMessage("Result=" + result);

            Utilities.LogMessage("Set Parameter Value to: " + parameters.NewParameterValue);
            result &= CheckCellValue(buildExpressionDialog.Controls.FormulaGrid.Rows[1].Cells[2], parameters.NewParameterValue);
            Utilities.LogMessage("Result=" + result);
            return result;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Edit Snmp Provider Tab
        /// </summary>
        /// <param name="parameters">SNMP Parameters</param>
        /// <param name="propertiesDialog">An instance of SNMPMonitorPropertiesDialog</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private void EditSnmpProviderTab(SNMPMonitorPropertiesDialog propertiesDialog, Parameters parameters)
        {
            Utilities.LogMessage("Select tab: " + parameters.TabTitleToEdit);
            propertiesDialog.SelectTab(parameters.TabTitleToEdit);

            SnmpProviderDialog snmpProviderDialog = new SnmpProviderDialog(this.consoleApp, propertiesDialog.Controls.TabPagesTabControl.SelectedTab.AccessibleObject.Window, monitorType, parameters.IsBackCompatMode);
            snmpProviderDialog.SetCustomCommunityString(parameters.NewCustomCommunityString);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Check Snmp Provider Tab
        /// </summary>
        /// <returns>boolean value to indicate if the check success</returns>
        /// <param name="parameters">SNMP Parameters</param>
        /// <param name="propertiesDialog">An instance of SNMPMonitorPropertiesDialog</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private bool CheckSnmpProviderTab(SNMPMonitorPropertiesDialog propertiesDialog, Parameters parameters)
        {
            bool result = true;

            Utilities.LogMessage("Select tab: " + parameters.TabTitleToEdit);
            propertiesDialog.SelectTab(parameters.TabTitleToEdit);

            SnmpProviderDialog snmpProviderDialog = new SnmpProviderDialog(this.consoleApp, propertiesDialog.Controls.TabPagesTabControl.SelectedTab.AccessibleObject.Window, monitorType, parameters.IsBackCompatMode);

            if (snmpProviderDialog.MonitorType != SnmpMonitorType.Trap)
            {
                Utilities.LogMessage("Monitor type is " + snmpProviderDialog.MonitorType + ", and should not access community string textbox");
                result &= true;
            }
            else
            {
                result &= CheckTextBoxValue(snmpProviderDialog.Controls.CommunityStringTextBox, parameters.NewCustomCommunityString);
            }

            return result;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Check if data grid cell value matches expected value
        /// </summary>
        /// <param name="targetCell">data grid cell</param>
        /// <param name="expectedText">expected text</param>
        /// <returns>boolean value to indicate if check success</returns>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static bool CheckCellValue(DataGridViewCell targetCell, string expectedText)
        {
            targetCell.AccessibleObject.Click();
            Utilities.LogMessage("UI value: " + targetCell.GetValue() + " Expected value: " + expectedText);
            return string.Equals(targetCell.GetValue(), expectedText);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Check if data grid cell value matches expected option
        /// </summary>
        /// <param name="targetCell">data grid cell</param>
        /// <param name="expectedOption">expected option</param>
        /// <returns>boolean value to indicate if check success</returns>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static bool CheckCellOption(DataGridViewCell targetCell, string expectedOption)
        {
            Utilities.LogMessage("UI option: " + targetCell.GetValue() + " Expected option: " + expectedOption);
            return string.Equals(targetCell.GetValue(), expectedOption);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Check if text box value matches expected value
        /// </summary>
        /// <param name="textbox">text box</param>
        /// <param name="expectedText">expected text</param>
        /// <returns>boolean value to indicate if check success</returns>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static bool CheckTextBoxValue(TextBox textbox, string expectedText)
        {
            if (textbox.IsPasswordType)
            {
                Win32Window window = new Win32Window(textbox.ScreenElement.HWnd);
                window.SendMessage(0x00CC, 0, 0);// #define EM_SETPASSWORDCHAR      0x00CC
            }

            Utilities.LogMessage("UI value: " + textbox.Text + " Expected value: " + expectedText);
            return string.Equals(textbox.Text, expectedText);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Initialize monitor type variable
        /// </summary>
        /// <param name="monitorType">monitor type</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private void InitMonitorType(string monitorType)
        {
            if (string.Equals(monitorType, "Trap"))
            {
                this.monitorType = SnmpMonitorType.Trap;
            }
            else if (string.Equals(monitorType, "Probe"))
            {
                this.monitorType = SnmpMonitorType.Probe;
            }
            else
            {
                throw new Exception("Unknown monitor type " + monitorType);
            }
        }
        #endregion

        #region SNMPParameters Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// All parameters related with SNMP monitro.
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Parameters
        {
            #region Constructors

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// TODO: Add a description for your constructor.
            /// </summary>
            /// <history>
            /// 	[v-bire] 31 DEC 2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public Parameters()
            {
                this.MonitorEnabled = true;
                this.IsBackCompatMode = false;
            }
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter AllTraps
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public bool AllTraps
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter MonitorTarget
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string MonitorTarget
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter ParentMonitor
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string ParentMonitor
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter MonitorName
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string MonitorName
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter Description
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string Description
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter DestinationMP
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string DestinationMP
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter MonitorEnabled
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public bool MonitorEnabled
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter MonitorType
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string MonitorType
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter GenerateAlert
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public bool GenerateAlert
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter AutoResolveAlert
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public bool AutoResolveAlert
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter Frequency
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public int Frequency
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter Unit
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string Unit
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter ObjectIdentifier
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string ObjectIdentifier
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter ParameterOperator
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string ParameterOperator
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter ParameterName
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string ParameterName
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter ParameterValue
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string ParameterValue
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter FirstHealthState
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string FirstHealthState
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter SecondHealthState
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string SecondHealthState
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter TabTitleToEdit
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string TabTitleToEdit
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter NewParameterName
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string NewParameterName
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter NewParameterOperator
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string NewParameterOperator
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter NewParameterValue
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string NewParameterValue
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter NewCustomCommunityString
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public string NewCustomCommunityString
            {
                get;
                set;
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Property to get parameter IsBackCompatMode
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public bool IsBackCompatMode
            {
                get;
                set;
            }
            #endregion
        }
        #endregion
    }
}
