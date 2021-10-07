//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MonitoringConfiguration.cs">
//     Copyright ?Microsoft 2005
// </copyright>
// <project>
//     Mom.Test.UI.Core.Console
// </project>
// <summary>
//     This class is designed to contain functions to help the automation of
//     Monitoring Configuration space.
// </summary>
// <history>
//      [barryw] 30NOV05    Created
//      [ruhim]  18Jan06    Added Windows Caption for 
//                          Template(Monitor an Application wizard)   
//      [ruhim]  09Apr06    Added Windows Caption for Aggregate Monitor Wizard
//      [faizalk]27Apr06    Added resource strings for SynTx template wizards
//      [visnara]04May08    Added methods to support/test UI Workflow analyzer APIs for alert generating monitors/rules
// </history>
//  -----------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration
{
    #region Using directives

    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Configuration;
    using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Maui.Core;
    using Maui.Core.Utilities;

    #endregion

    /// -------------------------------------------------------------------
    /// <summary>
    /// This class is designed to contain functions to help the 
    /// automation of Monitoring Configuration space.
    /// </summary>
    /// -------------------------------------------------------------------
    public class MonitoringConfiguration
    {
        #region Constructors section

        /// -------------------------------------------------------------------
        /// <summary>
        /// Constructor.
        /// </summary>
        /// -------------------------------------------------------------------
        public MonitoringConfiguration()
        {
            // This prevents the creation of a default constructor
        }
        #endregion

        #region Enumerators section

        /// <summary>
        /// Types of window captions.
        /// </summary>
        public enum WindowCaptions
        {
            /// <summary>
            /// Monitor wizard dialog's window caption.
            /// </summary>
            MonitorWizard,

            /// <summary>
            /// Aggregate Monitor wizard dialog's window caption.
            /// </summary>
            AggregateMonitorWizard,

            /// <summary>
            /// Dependency Monitor wizard dialog's window caption.
            /// </summary>
            DependencyMonitorWizard,

            /// <summary>
            /// Collection Rules wizard dialog's window caption.
            /// </summary>
            RulesWizard,

            /// <summary>
            /// Template wizard dialog's window caption.
            /// </summary>
            MonitoringTemplateWizard,

            /// <summary>
            /// Monitor Properties dialog's window caption.
            /// </summary>
            MonitorProperties,

            /// <summary>
            /// Collection Rules dialog's window caption.
            /// </summary>
            RulesProperties
        }

        

        #endregion	// Enumerators section

        #region Mcf public static methods section (functions that could not be moved to ...\Common.Mcf.cs yet due to referencing Strings class)

        ////Todo: Consider encapsulating 'Mcf' methods and values that apply 
        ////      specific dialogs with the applicable dialog in a 'Mcf' subclass 
        ////      for ease of discoverability and maintenance.

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method is designed to retrieve the localized grid column name
        /// for the specified test data cross-reference name.
        /// </summary>
        /// <param name="name">Grid column Name cross-reference name in varmap.</param>
        /// <returns>Localized grid column name</returns>
        /// -------------------------------------------------------------------
        public static string GetGridColumnName(string name)
        {
            Utilities.LogMessage("MonitoringConfiguration.Mcf.GetGridColumnName(...)");

            // Retrieve the localized value.
            bool isLocalized = true;
            string columnName = null;
            switch (name)
            {
                case Mcf.Values.PropertyColumnName:
                    {
                        columnName = BuildExpressionDialog.Strings.GridPropertyColumn;
                        break;
                    }

                case Mcf.Values.OperatorColumnName:
                    {
                        columnName = BuildExpressionDialog.Strings.GridOperatorColumn;
                        break;
                    }

                case Mcf.Values.ValueColumnName:
                    {
                        columnName = BuildExpressionDialog.Strings.GridValueColumn;
                        break;
                    }

                default:
                    {
                        Utilities.LogMessage(
                            "MonitoringConfiguration.Mcf.GetGridColumnName:: " +
                            "Unknown column name, " +
                            "this may be by design, or a constant " +
                            "needs to be added to this function, " +
                            "returning xref name unchanged: [" + columnName + "]");
                        isLocalized = false;
                        columnName = name;
                        break;
                    }
            }

            if (isLocalized)
            {
                Utilities.LogMessage(
                "MonitoringConfiguration.Mcf.GetGridColumnName:: " +
                "Returning localized column name: [" + columnName + "]");
            }

            return columnName;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method is designed to retrieve the localized operator 
        /// expression for the specified test data cross-reference expression, 
        /// e.g., 'Equals', 'Contains', etc..
        /// </summary>
        /// <param name="operatorValue">Operator value cross-reference expression in varmap.</param>
        /// <returns>Localized operator expression</returns>
        /// -------------------------------------------------------------------
        public static string GetOperatorValue(string operatorValue)
        {
            Utilities.LogMessage("MonitoringConfiguration.Mcf.GetOperatorValue(...)");

            // Retrieve the localized operator expression.
            bool isLocalized = true;
            string tempOperatorValue = null;
            switch (operatorValue)
            {
                case Mcf.Values.Equality:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.Equality;
                        break;
                    }

                case Mcf.Values.NotEquals:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.NotEquals;
                        break;
                    }

                case Mcf.Values.GreaterThan:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.GreaterThan;
                        break;
                    }

                case Mcf.Values.GreaterThanOrEqualTo:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.GreaterThanOrEqualTo;
                        break;
                    }

                case Mcf.Values.LessThan:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.LessThan;
                        break;
                    }

                case Mcf.Values.LessThanOrEqualTo:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.LessThanOrEqualTo;
                        break;
                    }

                case Mcf.Values.Contains:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.Contains;
                        break;
                    }

                case Mcf.Values.NotContains:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.NotContains;
                        break;
                    }

                case Mcf.Values.MatchesWildcard:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.MatchesWildcard;
                        break;
                    }

                case Mcf.Values.NotMatchesWildcard:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.NotMatchesWildcard;
                        break;
                    }

                case Mcf.Values.MatchesRegularExpression:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.MatchesRegularExpression;
                        break;
                    }

                case Mcf.Values.NotMatchesRegularExpression:
                    {
                        tempOperatorValue = BuildExpressionDialog.Strings.NotMatchesRegularExpression;
                        break;
                    }

                default:
                    {
                        Utilities.LogMessage(
                            "MonitoringConfiguration.Mcf.GetOperatorValue:: " +
                            "Unknown operator expression, " +
                            "a constant for localized tests may " +
                            "need to be added to this function, " +
                            "returning xref expression unchanged: [" + operatorValue + "]");
                        isLocalized = false;
                        tempOperatorValue = operatorValue;
                        break;
                    }
            }

            if (isLocalized)
            {
                Utilities.LogMessage(
                    "MonitoringConfiguration.Mcf.GetOperatorValue:: " +
                    "Returning localized operator expression: [" + tempOperatorValue + "]");
            }

            return tempOperatorValue;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method is designed to retrieve the localized event property name
        /// for the specified test data cross-reference name.
        /// </summary>
        /// <param name="name">Event Property Name cross-reference name in varmap.</param>
        /// <returns>Localized event property name</returns>
        /// -------------------------------------------------------------------
        public static string GetEventPropertyName(string name)
        {
            Utilities.LogMessage("MonitoringConfiguration.Mcf.GetEventPropertyName(...)");

            // Retrieve the localized event property name.
            bool isLocalized = true;
            string eventPropertyName = null;
            switch (name)
            {
                case Mcf.Values.EventGuid:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.EventGuid;
                        break;
                    }

                case Mcf.Values.Description:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.Description;
                        break;
                    }

                case Mcf.Values.EventNumber:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.EventNumber;
                        break;
                    }

                case Mcf.Values.EventPublisherName:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.EventPublisherName;
                        break;
                    }

                case Mcf.Values.EventCategory:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.EventCategory;
                        break;
                    }

                case Mcf.Values.EventLevel:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.EventLevel;
                        break;
                    }

                case Mcf.Values.FullEventNumber:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.FullEventNumber;
                        break;
                    }

                case Mcf.Values.LoggingComputer:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.LoggingComputer;
                        break;
                    }

                case Mcf.Values.LognameChannel:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.LognameChannel;
                        break;
                    }

                case Mcf.Values.PublisherGuid:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.PublisherGuid;
                        break;
                    }

                case Mcf.Values.User:
                    {
                        eventPropertyName = BuildExpressionDialog.Strings.User;
                        break;
                    }

                default:
                    {
                        Utilities.LogMessage(
                            "MonitoringConfiguration.Mcf.GetEventPropertyName:: " +
                            "Unknown event property name, " +
                            "this may be by design, or a constant " +
                            "needs to be added to this function, " +
                            "returning xref name unchanged: [" + eventPropertyName + "]");
                        isLocalized = false;
                        eventPropertyName = name;
                        break;
                    }
            }

            if (isLocalized)
            {
                Utilities.LogMessage(
                "MonitoringConfiguration.Mcf.GetEventPropertyName:: " +
                "Returning actual event property name: [" + eventPropertyName + "]");
            }

            return eventPropertyName;
        }

        #endregion  // Mcf public static methods section

        #region Public static methods section

        /// <summary>
        /// This funstion is designed to return the localised dialog caption for a Wizard
        /// or properties dialog.
        /// </summary>
        /// <param name="caption">Dialog captions</param>
        /// <returns>localised window caption text</returns>
        public static string GetWindowCaption(MonitoringConfiguration.WindowCaptions caption)
        {
            Utilities.LogMessage("MonitoringConfiguration.GetWindowCaption(..)");
            string dialogTitle = null;
            switch (caption)
            {
                case MonitoringConfiguration.WindowCaptions.MonitorWizard:
                    dialogTitle = Monitors.Strings.DialogTitle;
                    break;
                case MonitoringConfiguration.WindowCaptions.AggregateMonitorWizard:
                    dialogTitle = Aggregate.Aggregate.Strings.DialogTitle;
                    break;
                case MonitoringConfiguration.WindowCaptions.DependencyMonitorWizard:
                    dialogTitle = Dependency.Dependency.Strings.DialogTitle;
                    break;
                case MonitoringConfiguration.WindowCaptions.RulesWizard:
                    dialogTitle = Rules.Strings.DialogTitle;
                    break;
                case MonitoringConfiguration.WindowCaptions.MonitoringTemplateWizard:
                    dialogTitle = Templates.Strings.DialogTitle;
                    break;
                case MonitoringConfiguration.WindowCaptions.MonitorProperties:
                    throw new NotImplementedException(
                        "Rules.GetWindowCaption:: " +
                        "Monitor Properties dialog title resource not created yet");
                ////Todo: break;
                case MonitoringConfiguration.WindowCaptions.RulesProperties:
                    throw new NotImplementedException(
                        "Rules.GetWindowCaption:: " +
                        "Rule Properties dialog title resource not created yet");
                ////Todo: break;
                default:
                    throw new NotSupportedException(
                        "Rules.GetWindowCaption:: " +
                        "This window caption type is not supported: " + caption);
            }

            return dialogTitle;
        }

        /// <summary>
        /// Function to fetch properties for a DataType from Test data store
        /// </summary>
        /// <param name="dataTypeName">DataType Name</param>
        /// <param name="props">Properties collection</param>
        /// <param name="recursive">true or false</param>
        /// <returns>none</returns>
        public static void GetDataTypePropsFromTestStore(string dataTypeName, ref ArrayList props, bool recursive)
        {
            Utilities.LogMessage("GetDataTypePropsFromTestStore for DataTypeID='" + dataTypeName + "'");
            XPathDocument xmlDoc = new XPathDocument(@"..\Common\DataTypes.xml");
            String xpathExpr = @"/DataTypes/DataType[@name='"+ dataTypeName + "']/Properties/Property";
            XPathNavigator nav = xmlDoc.CreateNavigator();
            XPathNodeIterator nodeiter = nav.Select(xpathExpr);
           
            while (nodeiter.MoveNext())
            {
                Utilities.LogMessage("GetDataTypePropsFromTestStore:: Adding property '" + nodeiter.Current.GetAttribute("name","") + "'");
                props.Add(nodeiter.Current.GetAttribute("name",""));
                if (recursive)
                {
                string typeName = nodeiter.Current.GetAttribute("type","");
                
                    if (typeName != null && typeName.Length > 0)
                    {
                        Utilities.LogMessage("Recursively getting properties for DatType '" + typeName + "'" );
                        GetDataTypePropsFromTestStore(typeName, ref props, true);
                    }
                }
            }
        }

        /// <summary>
        /// Function to Verify Monitor Workflow and alert properties
        /// </summary>
        /// <param name="monitorTypeID">Monitor Type ID</param>
        /// <param name="mp">MP Name containing the Monitor Type definition</param>
        /// <returns>True/False</returns>
        public static bool VerifyMonitor (String monitorTypeID, string mp)
        {
            Utilities.LogMessage("Verify Monitor :: MonitorTypeID='" + monitorTypeID + "' mp='" + mp + "'");
            ArrayList testProperties = Monitors.GetMonitorDataTypePropsFromTestStore(monitorTypeID,true);
            ArrayList prodProperties = new ArrayList();

            Utilities.LogMessage ( " Num. Properties from test store : " + testProperties.Count);
            Utilities.LogMessage(" \n Test property List :");
            foreach (string s in testProperties)
                Utilities.LogMessage("\n" + s);
            
            //Get properties from product store
            ManagementGroup managementGroup = Utilities.ConnectToManagementServer();
            ManagementPack momManagementPack =
                managementGroup.ManagementPacks.GetManagementPack(IdUtil.GetMPIdAsGuid(mp, 
                    ManagementPackConstants.MomManagementPackPublicKeyToken, null));
            Utilities.LogMessage("MP GUID: " + XmlConvert.ToString((IdUtil.GetMPIdAsGuid(mp,
                    ManagementPackConstants.MomManagementPackPublicKeyToken, null))));
            Utilities.LogMessage("MP Name: " + momManagementPack.Name);

            ManagementPack uiTestMP = managementGroup.ManagementPacks.GetManagementPack(
                Mom.Test.UI.Core.Common.IdUtil.GetMPIdAsGuid(ManagementPackConstants.UITestMPName, null, null));

            ManagementPackUnitMonitor monitor = new ManagementPackUnitMonitor(
                uiTestMP, 
               "a.b.c.d", ManagementPackAccessibility.Public);
            ManagementPackUnitMonitorType unitMonitorType;

            unitMonitorType = managementGroup.Monitoring.GetUnitMonitorType(IdUtil.GetMPObjectIdAsGuid(
                mp, ManagementPackConstants.MomManagementPackPublicKeyToken, monitorTypeID));

            monitor.TypeID = unitMonitorType; 
            
            OfflineWorkflowAnalyzer offlineWFA = new OfflineWorkflowAnalyzer(null);
            ReadOnlyCollection<IDataTypeDefinition> dataTypeDef = offlineWFA.GetDataTypeDefinition(monitor);


            uiTestMP.RejectChanges();

            Utilities.LogMessage ("VerifyMonitor :: # items in DataDypeDefinition collection returned by workflowanalyzer = " + dataTypeDef.Count);

            foreach (IDataTypeDefinition idtd in dataTypeDef)
            {
               
                Utilities.LogMessage ("VerifyMonitor :: Extracting Properties from Product Store for : '" + idtd.Name + "'");
                foreach (IDataTypeProperty prop in idtd.Properties)
                {
                    ExtractDataTypePropertiesFromProductStore(prop, ref prodProperties, true);
                }
            }
            
            Utilities.LogMessage ( " \n Num. Properties from product store : " + prodProperties.Count);
            Utilities.LogMessage(" \n Product property List : \n");
            foreach (string s in prodProperties)
                Utilities.LogMessage("\n" + s);
            
            return VerifyPropertyList(prodProperties, testProperties);
        }


        /// <summary>
        /// Function to Verify rule Workflow and alert properties
        /// </summary>
        /// <param name="ruleID">Rule ID</param>
        /// <param name="mp">MP Name containing the rule</param>
        /// <returns>True/False</returns>
        public static bool VerifyRule(String ruleID, string mp)
        {
            Utilities.LogMessage("Verify Rule :: ruleID='" + ruleID + "' mp='" + mp + "'");
            ArrayList testProperties = Rules.GetRuleDataTypePropsFromTestStore(ruleID, true);
            ArrayList prodProperties = new ArrayList();

          
            Utilities.LogMessage(" Num. Properties from test store : " + testProperties.Count);
            Utilities.LogMessage(" \n Test property List :");
            foreach (string s in testProperties)
                Utilities.LogMessage("\n" + s);

            //Get properties from product store
            ManagementGroup managementGroup = Utilities.ConnectToManagementServer();


            ManagementPack uiRulesTestMP = managementGroup.ManagementPacks.GetManagementPack(
                Mom.Test.UI.Core.Common.IdUtil.GetMPIdAsGuid(mp, null, null));
            ManagementPackRule rule = uiRulesTestMP.GetRule(ruleID);

           
            OfflineWorkflowAnalyzer offlineWFA = new OfflineWorkflowAnalyzer(null);
            ReadOnlyCollection<IDataTypeDefinition> dataTypeDef = offlineWFA.GetDataTypeDefinition(rule);

            
            Utilities.LogMessage("VerifyRule :: # items in DataDypeDefinition collection returned by workflowanalyzer = " + dataTypeDef.Count);

            foreach (IDataTypeDefinition idtd in dataTypeDef)
            {

                Utilities.LogMessage("VerifyRule :: Extracting Properties from Product Store for : '" + idtd.Name + "'");
                foreach (IDataTypeProperty prop in idtd.Properties)
                {
                    ExtractDataTypePropertiesFromProductStore(prop, ref prodProperties, true);
                }
            }

            Utilities.LogMessage(" \n Num. Properties from product store : " + prodProperties.Count);
            Utilities.LogMessage(" \n Product property List : \n");
            foreach (string s in prodProperties)
                Utilities.LogMessage("\n" + s);

            return VerifyPropertyList(prodProperties, testProperties);
        }

        /// <summary>
        /// Function to fetch properties for a DataType from Product data store
        /// </summary>
        /// <param name="idtp">Object implementing IDataTypeProperty interface</param>
        /// <param name="properties">Properties collection</param>
        /// <param name="recursive">true or false</param>
        /// <returns>none</returns>
        public static void ExtractDataTypePropertiesFromProductStore(IDataTypeProperty idtp, ref ArrayList properties, bool recursive)
        {
            Utilities.LogMessage ("ExtractDataTypePropertiesFromProductStore :: Property '" + idtp.Name + "'");
            //foreach (IDataTypeProperty idtp in idtd.Properties)
            //{
                Utilities.LogMessage("PropertyName: '" + idtp.Name + "' PropertyType: '" + idtp.PropertyType + "'");
                Utilities.LogMessage("Properties.Count (# Child) : '" + idtp.Properties.Count + "'");
                Utilities.LogMessage("ExtractDataTypePropertiesFromProductStore:: Adding property '" + idtp.Name + "'");
                
                properties.Add(idtp.Name);
              
                if (idtp.Properties.Count > 0)
                {
                    Utilities.LogMessage("ExtractDataTypePropertiesFromProductStore :: Property '" + idtp.Name + "' is DataType. Recursively fetching " +                                 "props. for the same...");
                    foreach (IDataTypeProperty icdtp in idtp.Properties)
                    {
                        ExtractDataTypePropertiesFromProductStore(icdtp, ref properties, true);
                        
                    }
                }
            //}
        }

        /// <summary>
        /// Function to compare two lists
        /// </summary>
        /// <param name="list1">prodlist</param>
        /// <param name="list2">testlist</param>
        /// <returns>true or false</returns>
        public static bool VerifyPropertyList(ArrayList list1, ArrayList list2)
        {
            if (list1.Count != list2.Count)
            {
                Utilities.LogMessage("VerifyPropertyList:: Property count doesn't match");
                return false;
            }
            else
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    Utilities.LogMessage("VerifyPropertyList:: Comparing...'" + ((string)list1[i]) + "' and '" + ((string)list2[i]) + "'");
                    if (((string)list1[i]).Trim().ToUpperInvariant().CompareTo(((string)list2[i]).Trim().ToUpperInvariant()) != 0)
                    {
                        //change this hardcoing to array.....
                        if (( ((string)list1[i]).Trim().ToUpperInvariant().StartsWith("PARAM")) || 
                            ( ((string)list1[i]).Trim().ToUpperInvariant().StartsWith("PROPERTY")) || 
                            ( ((string)list1[i]).Trim().ToUpperInvariant().StartsWith("COLLECTION")) ||
                            ( ((string)list1[i]).Trim().ToUpperInvariant().StartsWith("SNMPVARBIND")))
                        {
                            if (((string)list1[i]).Trim().ToUpperInvariant().StartsWith(((string)list2[i]).Trim().ToUpperInvariant()) != true)
                            {
                                Utilities.LogMessage("NO MATCH for param/property/collection/snmpvarbinds as well...");
                                return false;
                            }
                        }
                        else
                        {
                            Utilities.LogMessage("NO MATCH");
                            return false;
                        }
                    }
                    else
                    {
                        Utilities.LogMessage("MATCH");
                    }
                }

                return true;

            }
        }
        
        #endregion	// Public static methods section


        #region Public non-static methods section

        /// <summary>
        /// Provides access to an open instance of the Create Rule
        /// Wizard events filter dialog.
        /// </summary>
        /// <returns>Create Rule Wizard events filter dialog.</returns>
        public GeneralPropertiesDialog GetCompletingCreationDialog()
        {
            Utilities.LogMessage("MonitoringConfiguration.GetCompletingCreationDialog(...)");

            // Access the Create Group rules Wizard dialog.
            GeneralPropertiesDialog nameDialog = null;

            // Open the rules Dialog
            try
            {
                nameDialog = new GeneralPropertiesDialog(
                    CoreManager.MomConsole,
                    MonitoringConfiguration.WindowCaptions.RulesWizard);

                // wait until application is ready
                UISynchronization.WaitForUIObjectReady(
                    nameDialog,
                    Constants.DefaultDialogTimeout);
                Utilities.LogMessage("MonitoringConfiguration.GetCompletingCreationDialog:: " +
                    "CreateRuleWizardNameDialog Opened");

                // Make sure Dialog is in Foreground.
                nameDialog.Extended.SetFocus();
                Utilities.LogMessage("MonitoringConfiguration.GetCompletingCreationDialog:: Focus set to " +
                    "CreateRuleWizardNameDialog");

                return nameDialog;
            }
            catch
            {
                if (nameDialog != null)
                {
                    // On a failure try to close the dialog.
                    ////Todo: enhance to try different ways of closing the dialog.
                    //        e.g., nameDialog.SendKeys(KeyboardCodes.Esc);
                    // Click the cancel button
                    nameDialog.ClickCancel();
                    Utilities.LogMessage("MonitoringConfiguration.GetCompletingCreationDialog:: " +
                        "Clicked the cancel button on the Create Rule Wizard Name dialog.");

                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("GetCompletingCreationDialog_Confirmation");

                    // Respond Yes to the confirmation dialog
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Yes,
                        MomConsoleApp.Strings.DialogTitle,
                        StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Error);

                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("GetCompletingCreationDialog_ClearedForMomConsole");
                }

                throw;
            }
        }

        #endregion  // Methods section

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings class to provide localized resource strings.
        /// </summary>
        /// <history>
        ///      [barryw] 12/13/2005 14:01:44 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            #region Resource constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Wizard dialog titles: ResourceDialogTitle.
            /// This is maintained here for a group of Wizard dialogs since the title should
            /// be the same for all the dialogs.
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            [Obsolete("Use MonitoringConfiguration\\Monitors\\Monitors.Strings class.")]
            private const string ResourceDialogTitle = ";Create Monitor Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Wizards.Common.WizardResources;CreateMonitorWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: DialogTitleMonitorProperties.
            /// </summary>
            /// <remarks>Created using 'Resource private string' snippet</remarks>
            /// -----------------------------------------------------------------------------
            ////Todo:Mark the old Strings.DialogTitle in monitors as obsolete.
            ////Todo:Create a snippet to generate the Obsolete statement.
            private const string ResourceDialogTitleMonitorProperties = ";Monitor Properties - [{0}];ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Wizards.Common.WizardResources;MonitorPropertiesFormatString";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunThisQueryEverySeconds = ";Seconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunThisQueryEveryMinutes = ";Minutes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunThisQueryEveryHours = ";Hours;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Days
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunThisQueryEveryDays = ";Days;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDistributedAppEdit = ";Edit;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ServicesView.ServicesResources;ServiceEditTask";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Severity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeverity =
                ";Severity;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;AlertSeverity";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Priority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePriority =
                ";Priority;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;AlertPriority";

            #endregion

            #endregion  // Constants

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// <summary>
            /// Cache to hold a reference to DialogTitleMonitorProperties
            /// </summary>
            /// <remarks>Created using 'Resource value cache' snippet</remarks>
            private static string cachedDialogTitleMonitorProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunThisQueryEverySeconds;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunThisQueryEveryMinutes;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunThisQueryEveryHours;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for days
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunThisQueryEveryDays;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDistributedAppEdit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Severity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeverity;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Priority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPriority;

            #endregion  // Private Members

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///      [barryw] 12/13/2005 14:01:44 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            [Obsolete("Use MonitoringConfiguration\\Monitors\\Monitors.Strings class.")]
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitleMonitorProperties translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 13DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitleMonitorProperties
            {
                get
                {
                    if ((cachedDialogTitleMonitorProperties == null))
                    {
                        cachedDialogTitleMonitorProperties = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitleMonitorProperties);
                    }

                    return cachedDialogTitleMonitorProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Seconds translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunThisQueryEverySeconds
            {
                get
                {
                    if ((cachedRunThisQueryEverySeconds == null))
                    {
                        cachedRunThisQueryEverySeconds = CoreManager.MomConsole.GetIntlStr(ResourceRunThisQueryEverySeconds);
                    }

                    return cachedRunThisQueryEverySeconds;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Minutes translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunThisQueryEveryMinutes
            {
                get
                {
                    if ((cachedRunThisQueryEveryMinutes == null))
                    {
                        cachedRunThisQueryEveryMinutes = CoreManager.MomConsole.GetIntlStr(ResourceRunThisQueryEveryMinutes);
                    }

                    return cachedRunThisQueryEveryMinutes;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Hours translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunThisQueryEveryHours
            {
                get
                {
                    if ((cachedRunThisQueryEveryHours == null))
                    {
                        cachedRunThisQueryEveryHours = CoreManager.MomConsole.GetIntlStr(ResourceRunThisQueryEveryHours);
                    }

                    return cachedRunThisQueryEveryHours;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Days translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunThisQueryEveryDays
            {
                get
                {
                    if ((cachedRunThisQueryEveryDays == null))
                    {
                        cachedRunThisQueryEveryDays = CoreManager.MomConsole.GetIntlStr(ResourceRunThisQueryEveryDays);
                    }

                    return cachedRunThisQueryEveryDays;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DistributedAppEdit
            {
                get
                {
                    if ((cachedDistributedAppEdit == null))
                    {
                        cachedDistributedAppEdit = CoreManager.MomConsole.GetIntlStr(ResourceDistributedAppEdit);
                    }

                    return cachedDistributedAppEdit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Severity translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 20FEB09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Severity
            {
                get
                {
                    if ((cachedSeverity == null))
                    {
                        cachedSeverity = CoreManager.MomConsole.GetIntlStr(ResourceSeverity);
                    }
                    return cachedSeverity;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Priority translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 20FEB09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Priority
            {
                get
                {
                    if ((cachedPriority == null))
                    {
                        cachedPriority = CoreManager.MomConsole.GetIntlStr(ResourcePriority);
                    }
                    return cachedPriority;
                }
            }

            #endregion // Properties
        }
        #endregion  // Strings Class
    }
}
