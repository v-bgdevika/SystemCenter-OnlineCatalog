//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Rules.cs">
//     Copyright ?Microsoft 2005
// </copyright>
// <project>
//  MOMv3 UI Console
// </project>
// <summary>
//     This class contains helper functions for automation of the 
//     configuration of Rules. 
// </summary>
// <history>
//      [mbickle] 20MAR06 Created
//      [barryli] 26FEB07 Add SDK calls to retrieve MP Guid 
//      [barryli] 12JUN07 Add public method to retrieve localized rule type display string
//      [a-joelj] 20FEB09 Add public method SelectTargetRule() to search through Rules view and find a target 
//                        and select a rule in that target. Also added new resources for Rules View "Name" and "Type"
// </history>
//  -----------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration
{
    #region Using directives

    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs;
    using Microsoft.EnterpriseManagement.Configuration;
    #endregion

    /// <summary>
    /// Class to assist test automation related to Rules.
    /// </summary>
    public class Rules
    {

        string rulesPath = NavigationPane.Strings.MonitoringConfiguration
           + Constants.PathDelimiter
           + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
           + Constants.PathDelimiter
           + Core.Console.Views.Views.Strings.RulesView;
        
        // /// <summary>
      //  /// GUID for Microsoft.SystemCenter.RuleTemplates.MP
      //  /// </summary>
      //  /// 
       // public static Guid RuleTemplatesMPGuid = Microsoft.EnterpriseManagement.Mom.Internal.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterRuleTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.NTEventRuleName);

        #region  Constructors section

        /// <summary>
        /// Constructor for Rules class.
        /// </summary>
        public Rules()
        {
            // This prevents the creation of a default constructor
        }

        #endregion   
     
        #region Public methods

        /// <summary>
        /// Method to retrieve the Rule Type display string 
        /// for a given rule type id, 
        /// the returned display string is the localized rule string user see on UI 
        /// </summary>
        /// <param name="ruleTypeID">rule type ID</param>                              
        /// <returns>Rule Type Name</returns>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [barryli] 12JUN07 - Created        
        /// </history>
        // <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.WindowNotFoundException">WindowNotFoundException</exception> 
        public string GetRuleTypeName(string ruleTypeID)
        {
            Guid RuleTemplatesMPGuid;
                   
            RuleTemplatesMPGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterRuleTemplatesMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ruleTypeID);

            return Utilities.GetMonitoringTemplateName(RuleTemplatesMPGuid);
        }

        /// <summary>
        /// Method to retrieve the Rule Type ID 
        /// for a given rule type name. Rule type name is defined in varmap in english;
        /// rule type id is rule template ID in MP 
        /// </summary>
        /// <param name="targetTypeName">rule type defined in vapmap</param>                              
        /// <returns>Rule Type ID</returns>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [barryli] 12JUN07 - Created        
        /// </history>
        // <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.WindowNotFoundException">WindowNotFoundException</exception> 
        public string GetRuleTypeID(string targetTypeName)
        {
            string RuleTypeID;
            switch (targetTypeName.ToLowerInvariant())
            {
                case "~windowsevents~":
                    RuleTypeID = ManagementPackConstants.NTEventRuleName;
                    break;
                case "~windowsalertevents~":
                    RuleTypeID = ManagementPackConstants.NTEventAlertRuleName;
                    break;
                case "~csvlogevents~":
                    RuleTypeID = ManagementPackConstants.GenericCSVLogRuleName;
                    break;
                case "~logevents~":
                    RuleTypeID = ManagementPackConstants.GenericLogRuleName;
                    break;
                case "~csvlogalertevents~":
                    RuleTypeID = ManagementPackConstants.GenericCSVLogAlertRuleName;
                    break;
                case "~logalertevents~":
                    RuleTypeID = ManagementPackConstants.GenericLogAlertRuleName;
                    break;
                case "~snmptrapalertevents~":
                    RuleTypeID = ManagementPackConstants.SnmpTrapAlertRuleName;
                    break;
                case "~snmptrapevents~":
                    RuleTypeID = ManagementPackConstants.SnmpTrapEventRuleName;
                    break;
                case "~snmppollevents~":
                    RuleTypeID = ManagementPackConstants.SnmpEventRuleName;
                    break;
                case "~snmpperformance~":
                    RuleTypeID = ManagementPackConstants.SnmpPerformanceRuleName;
                    break;
                case "~wmievents~":
                    RuleTypeID = ManagementPackConstants.WMIEventRuleName;
                    break;
                case "~wmialertevents~":
                    RuleTypeID = ManagementPackConstants.WMIEventAlertRuleName;
                    break;
                case "~wmiperformance~":
                    RuleTypeID = ManagementPackConstants.WMIPerformanceRuleName;
                    break;
                case "~scriptperformance~":
                    RuleTypeID = ManagementPackConstants.ScriptPerformanceRuleName;
                    break;
                case "~scriptevents~":
                    RuleTypeID = ManagementPackConstants.ScriptEventRuleName;
                    break;
                case "~syslogalertevents~":
                    RuleTypeID = ManagementPackConstants.SyslogAlertRuleName;
                    break;
                case "~syslogevents~":
                    RuleTypeID = ManagementPackConstants.SyslogRuleName;
                    break;
                case "~windowsperformance~":
                    RuleTypeID = ManagementPackConstants.WindowsPerformanceRuleName;
                    break;
                case "~timedscript~":
                    RuleTypeID = ManagementPackConstants.TimedScriptRuleName;
                    break;
                case "~timedcommand~":
                    RuleTypeID = ManagementPackConstants.TimedCommandRuleName;
                    break; 
                default:
                    Utilities.LogMessage("Rule type name from varmap is : " + targetTypeName);
                    throw new ApplicationException("Failed to get valid rule type from varmap records!");
            }

            return RuleTypeID;
        }

        /// <summary>
        /// Method to select a particular Rule row in the Rules view
        /// for a specified Target only. It will select the first matching Rule row and return its row index
        /// </summary>
        /// <param name="targetName">Class where the rule is targeted</param>                
        /// <param name="ruleName">rule name that you want to select</param>                
        /// <returns>Row index</returns>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [a-joelj]   20FEB09 Created        
        /// </history>
        // <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.WindowNotFoundException">WindowNotFoundException</exception> 
        public int SelectTargetRule(string targetName, string ruleName)
        {
            #region Navigate to Rules View

            Utilities.LogMessage("NavigateToRulesView(...)");
            CoreManager.MomConsole.BringToForeground();

            // Select the Monitoring Configuration wunderbar
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

            // Select the Rules node
            navPane.SelectNode(rulesPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

            // Get reference to the Grid
            Core.Console.MomControls.GridControl viewGrid = null;
            int retry = 0;
            int maxcount = 10;

            while (viewGrid == null && retry <= maxcount)
            {
                try
                {
                    // Bug#203060: Sometimes rule doesn't disappear from Rules view after executing deletion operation for more than 1.5 minutes.             
                    // It might be due to the Rules view doesn't refresh. Refresh Rules view here, since this method is used to verify if the rule is deleted. 
                    CoreManager.MomConsole.ViewPane.Grid.SendKeys(KeyboardCodes.F5);

                    // Try to get the GridControl reference
                    viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("Rules.SelectTargetRule:: Failed to get reference to ViewPane.Grid, lets navigate and try again.");
                    Utilities.TakeScreenshot("Rules.SelectTargetRule_GridView_NotFound");
                    Sleeper.Delay(Constants.OneSecond); // Wait 1 second before trying to get GridControl again
                }
                catch (System.NullReferenceException)
                {
                    Utilities.LogMessage("Rules.SelectTargetRule:: Got a null reference, lets try again.");
                    Utilities.TakeScreenshot("Rules.SelectTargetRule_NullExpection");
                    Sleeper.Delay(Constants.OneSecond); // Wait 1 second before trying to get GridControl again
                }
                retry++;
            }
            //Select Rules under Management Pack Objects               
            Utilities.LogMessage("Rules.SelectTargetRule:: Successfully selected Rules View Grid under Authoring space");

            #endregion

            // Declaring variables for target and rule row indexes                 
            int rowposRule = -1;
            rowposRule = SelectTargetRule(viewGrid, targetName, ruleName);

            return rowposRule;
        }

        /// <summary>
        /// Method to select a particular Rule row in the specified GridView
        /// for a specifed Target only. It will select the first matching Rule row and return its row index
        /// </summary>
        /// <param name="viewGrid">Reference to the Grid Control</param>                
        /// <param name="targetName">Class where the rule is targeted</param>                
        /// <param name="ruleName">rule name that you want to select</param>                
        /// <returns>Row index</returns>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [a-joelj]   20FEB09 Created
        /// </history>
        public int SelectTargetRule(Core.Console.MomControls.GridControl viewGrid, string targetName, string ruleName)
        {
            // Declaring variables for target and rule row indexes 
            int rowposTarget = -1;
            int rowposRule = -1;
            if (viewGrid != null)
            {
                Utilities.LogMessage("Rules.SelectTargetRule:: ViewGrid Found - Now Look up the Target '" + targetName + "'");
                
                int colpos = -1;
                Maui.Core.WinControls.DataGridViewRowCollection myRows = null;
                int rowCount = 0;
                string cellValue = null;
                
                // Retry variables
                int retry = 0;
                int maxcount = 10;
                bool foundValidRef = false;

                // Find reference to grid control
                while (foundValidRef == false && retry <= maxcount)
                {
                    try
                    {
                        // Get the Index position of the Column of 'Name'
                        colpos = viewGrid.GetColumnTitlePosition(Core.Console.MonitoringConfiguration.Rules.Strings.RulesViewNameColumn);
                        
                        //Cache the rows to address timing issue
                        myRows = viewGrid.Rows;
                        rowCount = myRows.Count;
                        cellValue = null;

                        Utilities.TakeScreenshot("RulesSelectTargetRule");
                        Utilities.LogMessage("Rules.SelectTargetRule:: Number of grid rows:  " + rowCount);
                        Utilities.LogMessage("Rules.SelectTargetRule:: Column Position for Name header:  " + colpos);
                        Utilities.LogMessage("Rules.SelectTargetRule:: Resetting grid scroll window to top...");
                        viewGrid.Click();
                        viewGrid.SendKeys(KeyboardCodes.Ctrl + "(" + KeyboardCodes.Home + ")");
                        foundValidRef = true;
                        Utilities.LogMessage("Rules.SelectTargetRule:: should not throw InvalidHWndException after this");
                    }
                    catch (Maui.Core.Window.Exceptions.InvalidHWndException)
                    {
                        CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);
                        viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                        Utilities.LogMessage("Rules.SelectTargetRule:: Failed to get valid reference to ViewGrid, lets navigate and try again.");
                        Utilities.TakeScreenshot("Rules.SelectTargetRule_ViewGrid_HWndInvalid");
                    }
                    retry++;
                }

                #region Find the target row

                // iterate through each row

                //NOTE: Due to Maui ListView Get_item call rowIndex =0 and 
                //rowIndex = rowCount. Both throw ArgumentOutOfRange Exception
                //hence using this method the last row in the grid cannot be accessed
                for (int rowIndex = 1; rowIndex < rowCount; rowIndex++)
                {

                    #region Perform Text Matching
                    cellValue = myRows[rowIndex].Cells[colpos].GetValue(); 
                    
                    Utilities.LogMessage("Rules.SelectTargetRule:: Current cellvalue : " + cellValue);
                    if (cellValue.Contains(targetName) == true)
                    {
                        rowposTarget = rowIndex;
                        Utilities.LogMessage("Rules.SelectTargetRule:: Target found at row index " + rowposTarget);

                        // Click the 2nd Cell.  Seems the only way to get the correct AA State out of the grid.
                        myRows[rowIndex].Cells[1].AccessibleObject.Click();

                        Utilities.LogMessage("Rules.SelectTargetRule:: rowIndex.StateText: " + myRows[rowIndex].AccessibleObject.StateText);
                        if (myRows[rowIndex].AccessibleObject.StateText.Contains(MsaaResources.Strings.Collapsed.ToLowerInvariant()))
                        {
                            Utilities.LogMessage("Rules.SelectTargetRule:: Expand Row");
                            myRows[rowIndex].AccessibleObject.DoDefaultAction();
                        }
                        break;
                    }
                    else
                    {
                        // move the highlight to the next row
                        viewGrid.SendKeys(KeyboardCodes.DownArrow);
                    }
                    #endregion // Perform Text Matching

                    //If the rows are collapsed initially we get incorrect row count
                    if (rowIndex == (rowCount - 1))
                    {
                        Utilities.LogMessage("Rules.SelectTargetRule:: Hit the last row count - Lets get the row count once more");
                        Utilities.LogMessage("Rules.SelectTargetRule:: Original row count: " + rowCount.ToString());
                        if (rowCount != viewGrid.Rows.Count)
                        {
                            rowCount = viewGrid.Rows.Count;
                            myRows = viewGrid.Rows;
                        }
                        Utilities.LogMessage("Rules.SelectTargetRule:: New row count: " + rowCount.ToString());
                    }
                }

                #region Find Rule row
                cellValue = null;
                //Once the target row is found find the rule
                if (rowposTarget != -1)
                {
                    //This is only if the target is the last target in the rules view
                    if (rowposTarget == (rowCount - 1))
                    {
                        Utilities.LogMessage("Rules.SelectTargetRule:: Hit the last row count - Lets get the row count once more");
                        Utilities.LogMessage("Rules.SelectTargetRule:: Original row count: " + rowCount.ToString());
                        if (rowCount != viewGrid.Rows.Count)
                        {
                            rowCount = viewGrid.Rows.Count;
                            myRows = viewGrid.Rows;
                        }
                        Utilities.LogMessage("Rules.SelectTargetRule:: New row count: " + rowCount.ToString());
                    }

                    // Look for the rule only under this specific target
                    while (rowposTarget <= rowCount)
                    {
                        #region Make Row And Cell Visible
                        Utilities.LogMessage("Rules.SelectTargetRule:: rowposTarget.StateText: " + myRows[rowposTarget].AccessibleObject.StateText);
                        if (myRows[rowposTarget].AccessibleObject.StateText.Contains(MsaaResources.Strings.Collapsed.ToLowerInvariant()))
                        {
                            Utilities.LogMessage("Rules.SelectTargetRule:: Expand Row");
                            myRows[rowposTarget].AccessibleObject.DoDefaultAction();
                        }
                        #endregion // Make Row And Cell Visible

                        //Go to the row   
                        cellValue = myRows[rowposTarget].Cells[colpos].GetValue();
                        Utilities.LogMessage("Rules.SelectTargetRule:: Current cellvalue : " + cellValue);

                        if (string.Compare(cellValue, ruleName) == 0)
                        {
                            rowposRule = rowposTarget;
                            Utilities.LogMessage("Rules.SelectTargetRule:: Monitor found at row index " + rowposRule);
                            try
                            {
                                viewGrid.ClickCell(rowposRule, colpos);
                            }
                            catch(Exception clickEx)
                            {
                                Utilities.LogMessage("Rules.SelectTargetRule::Click cell hit exception"+clickEx.Message);
                                Utilities.TakeScreenshot("Exception caught When SelectTargetRule");

                                //Send Esc to workaround test bug #516348
                                Utilities.LogMessage("Send Esc to workaround test bug #516348");
                                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);

                                throw new DataGridView.Exceptions.DataGridViewRowNotFoundException(clickEx.Message);
                            }
                            break;
                        }
                        else
                        {
                            // move the highlight to the next row
                            viewGrid.SendKeys(KeyboardCodes.DownArrow);
                        }

                        rowposTarget++;

                        //If the rows are collapsed initially we get incorrect row count
                        if (rowposTarget == (rowCount))
                        {
                            Utilities.LogMessage("Rules.SelectTargetRule:: Hit the last row count - Lets get the row count once more");
                            Utilities.LogMessage("Rules.SelectTargetRule:: Original row count: " + rowCount.ToString());
                            if (rowCount != viewGrid.Rows.Count)
                            {
                                rowCount = viewGrid.Rows.Count;
                                myRows = viewGrid.Rows;
                            }
                            Utilities.LogMessage("Rules.SelectTargetRule:: New row count: " + rowCount.ToString());
                        }
                    }

                    if ((rowposRule == -1) || cellValue.Contains(Strings.RulesViewTypeInheritedFromColumn))
                    {
                        Utilities.LogMessage("Rules.SelectTargetRule:: Rule '"
                            + ruleName
                            + "' not found under target "
                            + targetName);
                        throw new DataGridView.Exceptions.DataGridViewRowNotFoundException("Rule not found under the specified Target!!");
                    }
                #endregion
                }
                else
                {
                    Utilities.LogMessage("Rules.SelectTargetRule:: Monitor Target '" +
                    targetName + "' not found");
                    throw new DataGridView.Exceptions.DataGridViewRowNotFoundException("Target specified for the rule not found!!");
                }
                #endregion
            }
            else
            {
                Utilities.LogMessage("Rules.SelectTargetRule:: Rules ViewGrid not found.");
                throw new DataGridView.Exceptions.WindowNotFoundException("Rules ViewGrid not found");
            }

            viewGrid = null;
            return rowposRule;
        }

        /// <summary>
        /// Returns boolean indicating whether a particular Rule for a specified Target
        /// is found in the Rules view or not
        /// </summary>
        /// <param name="targetName">Class where the rule is targetted</param>
        /// <param name="ruleName">Rule Name</param>
        /// <returns>if the specified rule exist</returns>
        /// <history>
        ///    [v-kayu] 09JAN10 Created
        /// </history>
        public bool TargetRuleExists(string targetName, string ruleName)
        {
            bool foundRule = false;
            //if SelectTargetRule method does not throw an exception and return a row index value
            // greater than -1 then the target rule is found
            try
            {
                if (this.SelectTargetRule(targetName, ruleName) > -1)
                {
                    foundRule = true;
                }
            }
            catch (DataGridView.Exceptions.DataGridViewRowNotFoundException)
            {
                Utilities.LogMessage("Rules.TargetRuleExist:: Caught exception DataGridViewRowNotFoundException here rule not found");
            }
            return foundRule;
        }

        /// <summary>
        /// Delete a specific rule
        /// </summary>
        /// <param name="targetName">Class where the rule is targetted</param>
        /// <param name="ruleName">Rule name</param>
        /// <history>
        ///    [v-kayu] 09JAN10 - Created
        /// </history>
        public void DeleteTargetRule(string targetName, string ruleName)
        { 
            //Navigate and select the specific Rule under Rules view
            try
            {
                SelectTargetRule(targetName, ruleName);
            }
            catch (Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException)
            {
                Utilities.LogMessage("Rules.DeleteTargetRule:: Failed to find target Rule - DataGridViewRowNotFoundException thrown - Retry ");
                //change scope and try to find again
                CoreManager.MomConsole.ViewPane.ChangeConsoleScope(new ViewPane.TargetType[] { new ViewPane.TargetType(targetName, targetName, true) }, true, 3);

                SelectTargetRule(targetName, ruleName);
            }

            //Click Delete menu on EditMenu
            Utilities.LogMessage("Rules.DeleteTargetRule:: Execute Delete menu on EditMenu");
            Commands.EditDelete.Execute(CoreManager.MomConsole, CommandMethod.Default);
            Utilities.LogMessage("Rules.DeleteTargetRule:: Successfully Execute Delete menu on Edit Menu");

            int attempt = 0;
            int MaxAttempt = 2;
            while (attempt <= MaxAttempt)
            {
                Utilities.LogMessage("Rules.DeleteTargetRule:: Attempt: " + attempt);
                attempt++;
                try
                {
                    //select Yes on the delete confirmation dialog
                    CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes, Strings.ConfirmRuleDeleteTitle, StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Error);
                    Utilities.TakeScreenshot("ClickOKToConfirmDelete");
                    //Wait until cursor type changes from busy icon
                    CoreManager.MomConsole.Waiters.WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType.Wait, 240);
                    Utilities.LogMessage("Rules.DeleteTargetRule:: Succesfully deleted the Rule");
                    CoreManager.MomConsole.Waiters.WaitForReady();
                    Utilities.TakeScreenshot("SuccessfulDelete");
                    break;
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("Rules.DeleteTargetRule:: Failed to find window: " + Strings.ConfirmRuleDeleteTitle);
                    CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                }
            }//while
        }

        /// <summary>
        /// Function to fetch rule alert WA datatype properties from test store
        /// </summary>
        /// <param name="ruleID">ruleID</param>
        /// <param name="recursive">true or false</param>
        /// <returns>Arraylist of properties</returns>
        public static ArrayList GetRuleDataTypePropsFromTestStore(string ruleID, bool recursive)
        {

            Utilities.LogMessage("GetRuleDataTypePropsFromTestStore :: ruleName='" + ruleID + "'");
            XPathDocument xmlDoc = new XPathDocument(@"..\common\Rules.xml");
            String xpathExpr = @"/Rules/Rule[@ID='" + ruleID + "']/DataTypes/*";
            XPathNavigator nav = xmlDoc.CreateNavigator();
            XPathNodeIterator nodeiter = nav.Select(xpathExpr);
            ArrayList testProperties = new ArrayList();


            string typeName, subTypeName;
            while (nodeiter.MoveNext())
            {
                switch (nodeiter.Current.Name.ToUpperInvariant())
                {
                    case "DATATYPE":
                        Utilities.LogMessage("Current Node is a Datatype. Getting propertied for the DataType '" +
                            nodeiter.Current.GetAttribute("type", "") + "'");
                        typeName = nodeiter.Current.GetAttribute("type", "");
                        MonitoringConfiguration.GetDataTypePropsFromTestStore(typeName, ref testProperties, recursive);
                        break;
                    case "PROPERTY":
                        Utilities.LogMessage("Current Node is a Property. Adding property '" + nodeiter.Current.GetAttribute("name", "") + "'");
                        testProperties.Add(nodeiter.Current.GetAttribute("name", ""));

                        typeName = nodeiter.Current.GetAttribute("type", "");

                        if (typeName != null && typeName.Length > 0)
                        {
                            Utilities.LogMessage("Expanding 'type' for property '" + typeName + "' ...");
                            MonitoringConfiguration.GetDataTypePropsFromTestStore(typeName, ref testProperties, recursive);

                        }

                        subTypeName = nodeiter.Current.GetAttribute("subtype", "");

                        if (subTypeName != null && subTypeName.Length > 0)
                        {
                            Utilities.LogMessage("Expanding 'subtype' for property '" + subTypeName + "' ...");
                            MonitoringConfiguration.GetDataTypePropsFromTestStore(subTypeName, ref testProperties, recursive);
                        }
                        break;
                    default:
                        break;
                }
            }
            return testProperties;
        }

         #endregion

        #region Strings
        /// <summary>
        /// Strings Class
        /// </summary>
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Create rule Wizard resource string
            /// </summary>
            private const string ResourceDialogTitle = ";Create Rule Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateRuleWizard";

            /// <summary>
            /// Rules view node resource string
            /// </summary>
            private const string ResourceRulesView = ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";

            /// <summary>
            /// Rules actions pane group resource string.
            /// </summary>
            private const string ResourceActionsRule = ";Rule;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView.RulesViewResources;RuleTaskGroup";

            /// <summary>
            /// Create a new rule link resource string
            /// </summary>
            private const string ResourceCreateANewRuleLink = ";Create a &Rule;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView.RulesViewResources;CreateRuleTask";
                
                // Old Resource ";Create a new rule;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView.RulesViewResources;CreateRuleTask";
            
            /// <summary>
            /// Properties link resource string
            /// </summary>
            private const string ResourcePropertiesRuleLink = ";Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView.RulesViewResources;PropertiesTask";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Confirm Rule Delete Dialog Title
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmRuleDeleteTitle =
                        ";Confirm Rule Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView.RulesViewResources;ConfirmRuleDelete";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alerting Tab Title on Monitor Property Page
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigurationTabTitle =
                ";Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;$this.TabName";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Rules View Name column
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceRulesViewNameColumn =
                ";Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView;NameColumn";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Type inherited from column header in Rules view
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceRulesViewTypeInheritedFromColumn =
            ";Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView.RulesViewResources;ContextTargetColumn";

            #endregion

            #region Private Members
            /// <summary>
            /// Cached reference for DialogTitle
            /// </summary>
            private static string cachedDialogTitle;

            /// <summary>
            /// Cached reference for Rules.
            /// </summary>
            private static string cachedRulesView;

            /// <summary>
            /// Cached reference for Rule actions pane group.
            /// </summary>
            private static string cachedActionsRule;

            /// <summary>
            /// Cached reference for Create a new rule Link.
            /// </summary>
            private static string cachedCreateANewRuleLink;

            /// <summary>
            /// Cached reference for Properties rule Link.
            /// </summary>
            private static string cachedPropertiesRuleLink;

            /// <summary>
            /// Cached reference for Configuration tab in Rules properties page.
            /// </summary>
            private static string cachedConfigurationTabTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for for Confirm Rule Delete Dialog Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmRuleDeleteTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Rules View Name Column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRulesViewNameColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Type inherited from column header in Rules view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRulesViewTypeInheritedFromColumn;  

            #endregion

            #region Properties
            /// <summary>
            /// Dialog Title for Create Rule Wizard
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
            /// Rules view/node resource string
            /// </summary>
            public static string RulesView
            {
                get
                {
                    if ((cachedRulesView == null))
                    {
                        cachedRulesView = CoreManager.MomConsole.GetIntlStr(ResourceRulesView);
                    }

                    return cachedRulesView;
                }
            }

            /// <summary>
            /// Rule taskstrip group.
            /// </summary>
            public static string ActionsRule
            {
                get
                {
                    if ((cachedActionsRule == null))
                    {
                        cachedActionsRule = CoreManager.MomConsole.GetIntlStr(ResourceActionsRule);
                    }

                    return cachedActionsRule;
                }
            }

            /// <summary>
            /// Create a new rule Link
            /// 
            /// [a-joelj] 07AUG08 Added code to remove ampersand when clicking Actions Pane option
            /// 
            /// </summary>
            public static string CreateANewRuleLink
            {
                get
                {
                    if ((cachedCreateANewRuleLink == null))
                    {
                        cachedCreateANewRuleLink = CoreManager.MomConsole.GetIntlStr(ResourceCreateANewRuleLink);

                        //Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedCreateANewRuleLink);
                        cachedCreateANewRuleLink = removeAmp.Replace("&", "");
                    }

                    return cachedCreateANewRuleLink;
                }
            }

            /// <summary>
            /// Create a Properties Link
            /// </summary>
            public static string PropertiesRuleLink
            {
                get
                {
                    if ((cachedPropertiesRuleLink == null))
                    {
                        cachedPropertiesRuleLink = CoreManager.MomConsole.GetIntlStr(ResourcePropertiesRuleLink);
                    }

                    return cachedPropertiesRuleLink;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Configuration Tab Title on Rules Property Page translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 01jun08 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigurationTabTitle
            {
                get
                {
                    if ((cachedConfigurationTabTitle == null))
                    {
                        cachedConfigurationTabTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfigurationTabTitle);
                    }
                    return cachedConfigurationTabTitle;
                }
            }
                      

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the for Confirm Rule Delete Dialog Title translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03Oct06 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmRuleDeleteTitle
            {
                get
                {
                    if ((cachedConfirmRuleDeleteTitle == null))
                    {
                        cachedConfirmRuleDeleteTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmRuleDeleteTitle);
                    }
                    return cachedConfirmRuleDeleteTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Rules View Name Column translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 19FEB09 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RulesViewNameColumn
            {
                get
                {
                    if ((cachedRulesViewNameColumn == null))
                    {
                        cachedRulesViewNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceRulesViewNameColumn);
                    }
                    return cachedRulesViewNameColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Type inherited from column header in Rules view
            /// </summary>
            /// <history>
            /// 	[a-joelj] 19FEB09 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RulesViewTypeInheritedFromColumn
            {
                get
                {
                    if ((cachedRulesViewTypeInheritedFromColumn == null))
                    {
                        cachedRulesViewTypeInheritedFromColumn = CoreManager.MomConsole.GetIntlStr(ResourceRulesViewTypeInheritedFromColumn);
                    }
                    return cachedRulesViewTypeInheritedFromColumn;
                }
            }
            #endregion
        }
        #endregion
    }
}
