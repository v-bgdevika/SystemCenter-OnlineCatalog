// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SLASLO.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 UI Test Automation
// </project>
// <summary>
// 	SLASLO Base Class and Parameters Class in the Core Library.  
// </summary>
// <history>
// [dialac]    09SEP08     Created
// [dialac] 20MAR09 - Adding work-around for bug #129790. 
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO
{

    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.XPath;
    using System.ComponentModel;
    using System.IO;
    using Microsoft.EnterpriseManagement.Configuration;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs;
    using Mom.Test.UI.Core.Console.Views.HealthConfiguration;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    #endregion

    /// <summary>
    /// Class to add general methods for SLASLO 
    /// </summary>
    /// <history> 	
    ///   [dialac]  09SEP08     Created
    /// </history>
    public class SLASLO
    {

        /// <summary>
        /// Defining my Struct to hold Action and SLOs ID associated witt the action
        /// </summary>
        public struct SLOAction
        {
            /// <summary>
            /// This member represents the slo action: Add/Edit/Remove
            /// </summary>
            public ActionType action;
            /// <summary>
            /// represents the slos associated with the action. 
            /// </summary>
            public string[] slos;
        }

        #region Private Members

        /// <summary>
        /// SLO Dictionary
        /// </summary>
        public System.Collections.Generic.Dictionary<string, SLO> slosDictionary = new Dictionary<string, SLO>();

        /// <summary>
        /// Generate Random String Based of User Local
        /// </summary>
        RandomStrings randomNames = new RandomStrings();

        /// <summary>
        /// ExcludedCharacters array to use on generatedName and generatedAlertViewDes
        /// </summary>
        char[] excludedCharacters = Core.Common.Utilities.ExcludedCharacters();

        /// <summary>
        /// Minimum length for SLO Display Name
        /// </summary>
        private int minNameLength = 1;

        /// <summary>
        /// Maximum length for SLO Display Name
        /// </summary>
        private int maxNameLength = 200;

        # region cached variables for all wizard pages

        /// <summary>
        /// cachedServiceLevelTrackingGeneralDialog
        /// </summary>
        private ServiceLevelTrackingGeneralDialog cachedServiceLevelTrackingGeneralDialog;

        /// <summary>
        /// cachedServiceLevelTrackingObjectsDialog
        /// </summary>
        private ServiceLevelTrackingObjectsDialog cachedServiceLevelTrackingObjectsDialog;
        
        /// <summary>
        /// cachedSelectaClasstoTargetDialog
        /// </summary>
        private SelectaTargetClassDialog cachedSelectaClasstoTargetDialog;
        
        /// <summary>
        /// cachedServiceLevelTrackingSLOsDialog
        /// </summary>
        private ServiceLevelTrackingSLOsDialog cachedServiceLevelTrackingSLOsDialog;

        /// <summary>
        /// cachedServiceLevelObjectiveMonitorStateDialog
        /// </summary>
        private ServiceLevelObjectiveMonitorStateDialog cachedServiceLevelObjectiveMonitorStateDialog;

        /// <summary>
        /// cachedServiceLevelObjectivePerformanceRuleDialog
        /// </summary>
        private ServiceLevelObjectiveCollectionRuleDialog cachedSServiceLevelObjectiveCollectionRuleDialog;
        
        /// <summary>
        /// cachedSLOSelectaTargetTypeDialog
        /// </summary>
        private SLOSelectaTargetTypeDialog cachedSLOSelectaTargetTypeDialog;

        /// <summary>
        /// cachedSelectaRuleDialog
        /// </summary>
        private SelectaRuleDialog cachedSelectaRuleDialog;
        
        /// <summary>
        /// cachedServiceLevelTrackingSummaryDialog
        /// </summary>
        private ServiceLevelTrackingSummaryDialog cachedServiceLevelTrackingSummaryDialog;

        /// <summary>
        /// cachedServiceLevelTrackingSummaryDialog
        /// </summary>
        private ServiceLevelTrackingCompletionDialog cachedServiceLevelTrackingCompletionDialog;

        /// <summary>
        /// cachedSelectanObjectDialog
        /// </summary>
        private SelectanObjectDialog cachedSelectanObjectDialog;

        #endregion //cached variables. 

        #endregion

        #region Constructor
        /// <summary>
        /// SLASLO Class
        /// </summary>
        public SLASLO()
        {

        }
        #endregion

        #region Enumerators section

        //TODO - DIALAC - Change the name (remove the SLA since it used for SLO too)
        /// <summary>
        /// Valid SLA Target Class type
        /// </summary>
        public enum SLATargetClassType
        {
            /// <summary>
            /// Distributed Application
            /// </summary>
            DistApp,

            /// <summary>
            /// Group
            /// </summary>
            Group,

            /// <summary>
            /// Class
            /// </summary>
            Class,

        }

        /// <summary>
        /// Valid SLA Scope type
        /// </summary>
        public enum SLAScopeType
        {
            /// <summary>
            /// All Objects
            /// </summary>
            AllObjects,

            /// <summary>
            /// Group
            /// </summary>
            Group,

            /// <summary>
            /// Instance
            /// </summary>
            Instance,

        }

        /// <summary>
        /// Valid Actions for the SLOs
        /// </summary>
        public enum ActionType
        {
            /// <summary>
            /// Add
            /// </summary>
            Add,

            /// <summary>
            /// Edit
            /// </summary>
            Edit,

            /// <summary>
            /// Remove
            /// </summary>
            Remove,

        }

        /// <summary>
        /// Valid SLO Type
        /// </summary>
        public enum SLOType
        {
            /// <summary>
            /// MonitorState
            /// </summary>
            MonitorState,

            /// <summary>
            /// CollectionRule
            /// </summary>
            CollectionRule,

        }

        /// <summary>
        /// Valid types of aggregation method for Collection Rule type of SLO
        /// </summary>
        public enum AgregationMethod
        {
            /// <summary>
            /// Average
            /// </summary>
            Average,

            /// <summary>
            /// Max
            /// </summary>
            Max,

            /// <summary>
            /// Min
            /// </summary>
            Min,

        }

        /// <summary>
        /// Valid types undesired states for Monitor State type of SLO
        /// </summary>
        public enum UndesiredState
        {
            /// <summary>
            /// Critical
            /// </summary>
            Critical,

            /// <summary>
            /// Unplanned Maintenance
            /// </summary>
            UnplannedMaintenance,

            /// <summary>
            /// Unmonitored 
            /// </summary>
            Unmonitored,
            
            /// <summary>
            /// Monitoring Unavailable
            /// </summary>
            MonitoringUnavailable,

            /// <summary>
            /// Monitor Disabled
            /// </summary>
            MonitorDisabled,

            /// <summary>
            /// Planned Maintenance
            /// </summary>
            PlannedMaintenance,

            /// <summary>
            /// Warning
            /// </summary>
            Warning,

        }

        #endregion	// Enumerators section

        #region Properties
        
        /// <summary>
        /// General Dialog of the Create SLA wizard. 
        /// </summary>
        public ServiceLevelTrackingGeneralDialog SLAGeneralDialog
        {
            get
            {
                if (this.cachedServiceLevelTrackingGeneralDialog == null)
                {
                    this.cachedServiceLevelTrackingGeneralDialog = new ServiceLevelTrackingGeneralDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the SLA General Dialog was successful");
                }

                return this.cachedServiceLevelTrackingGeneralDialog;
            }
        }

        /// <summary>
        /// SLA Objects Type Dialog: Target, Scope and MP
        /// </summary>
        public ServiceLevelTrackingObjectsDialog SLAObjectsDialog
        {
            get
            {
                if (this.cachedServiceLevelTrackingObjectsDialog == null)
                {
                    this.cachedServiceLevelTrackingObjectsDialog = new ServiceLevelTrackingObjectsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the SLA Objects Dialog was successful");
                }

                return this.cachedServiceLevelTrackingObjectsDialog;
            }
        }

        /// <summary>
        /// Select Target Class Dialog
        /// </summary>
        public SelectaTargetClassDialog SelectSLATargetDialog
        {
            get
            {
                if (this.cachedSelectaClasstoTargetDialog == null)
                {
                    this.cachedSelectaClasstoTargetDialog = new SelectaTargetClassDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the SLA Select Target Class Type Dialog was successful");
                }

                return this.cachedSelectaClasstoTargetDialog;
            }
        }

        /// <summary>
        /// The Select an Object (Scope) Dialog
        /// </summary>
        public SelectanObjectDialog SelectScopeDialog
        {
            get
            {
                if (this.cachedSelectanObjectDialog == null)
                {
                    this.cachedSelectanObjectDialog = new SelectanObjectDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on select an Object (Scope) Dialog was successful");
                }

                return this.cachedSelectanObjectDialog;
            }
        }

        /// <summary>
        /// SLOS Dialog
        /// </summary>
        public ServiceLevelTrackingSLOsDialog SLASLOsDialog
        {
            get
            {
                if (this.cachedServiceLevelTrackingSLOsDialog == null)
                {
                    this.cachedServiceLevelTrackingSLOsDialog = new ServiceLevelTrackingSLOsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the SLA Slos Dialog was successful");
                }

                return this.cachedServiceLevelTrackingSLOsDialog;
            }
        }

        /// <summary>
        /// Monitor State SLO Dialog
        /// </summary>
        public ServiceLevelObjectiveMonitorStateDialog MonitorStateSLODialog
        {
            get
            {
                if (this.cachedServiceLevelObjectiveMonitorStateDialog == null)
                {
                    this.cachedServiceLevelObjectiveMonitorStateDialog = new ServiceLevelObjectiveMonitorStateDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Monitor State SLO Dialog was successful");
                }

                return this.cachedServiceLevelObjectiveMonitorStateDialog;
            }
        }

        /// <summary>
        /// Collection Rule SLO Dialog
        /// </summary>
        public ServiceLevelObjectiveCollectionRuleDialog CollectionRuleSLODialog
        {
            get
            {
                if (this.cachedSServiceLevelObjectiveCollectionRuleDialog == null)
                {
                    this.cachedSServiceLevelObjectiveCollectionRuleDialog = new ServiceLevelObjectiveCollectionRuleDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Collection Rule SLO Dialog was successful");
                }

                return this.cachedSServiceLevelObjectiveCollectionRuleDialog;
            }
        }

        /// <summary>
        /// SLO Target Dialog
        /// </summary>
        public SLOSelectaTargetTypeDialog SLOSelectTargetDialog
        {
            get
            {
                if (this.cachedSLOSelectaTargetTypeDialog == null)
                {
                    this.cachedSLOSelectaTargetTypeDialog = new SLOSelectaTargetTypeDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select SLO Target Dialog was successful");
                }

                return this.cachedSLOSelectaTargetTypeDialog;
            }
        }

        /// <summary>
        /// Select a Rule Dialog
        /// </summary>
        public SelectaRuleDialog SLOSelectRuleDialog
        {
            get
            {
                if (this.cachedSelectaRuleDialog == null)
                {
                    this.cachedSelectaRuleDialog = new SelectaRuleDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Rule Dialog was successful");
                }

                return this.cachedSelectaRuleDialog;
            }
        }
                              
        /// <summary>
        /// SLA Summary Dialog
        /// </summary>
        public ServiceLevelTrackingSummaryDialog SLASummaryDialog
        {
            get
            {
                if (this.cachedServiceLevelTrackingSummaryDialog == null)
                {
                    this.cachedServiceLevelTrackingSummaryDialog = new ServiceLevelTrackingSummaryDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the SLA summary Dialog was successful");
                }

                return this.cachedServiceLevelTrackingSummaryDialog;
            }
        }
        
        /// <summary>
        /// The completion Dialog
        /// </summary>
        public ServiceLevelTrackingCompletionDialog SLACompletionDialog
        {
            get
            {
                if (this.cachedServiceLevelTrackingCompletionDialog == null)
                {
                    this.cachedServiceLevelTrackingCompletionDialog = new ServiceLevelTrackingCompletionDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on Completion Dialog was successful");
                }

                return this.cachedServiceLevelTrackingCompletionDialog;
            }
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Set fields in the General page: Name and Description. 
        /// </summary>
        /// <param name="slaName">SLA Name</param>
        /// <param name="slaDescription">SLA Description</param>
        /// <history>
        /// [dialac] 17SEP08 - Created        
        /// </history>
        public void SettingFieldsGeneralPage(string slaName, string slaDescription) 
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            // General Page
            // Trying to set the name -- if its null throws System.ArgumentNullException
            if (null != slaName)
            {
                Sleeper.Delay(5000);
                Core.Console.UIUtilities.SetControlValue(this.SLAGeneralDialog.Controls.NameTextBox, slaName);
                Utilities.LogMessage(currentMethod + ":: Set SLA display name '" +
                    this.SLAGeneralDialog.NameText + "'");
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: SLA Name cannot be null.");
                //CLosing the wizard before throwing a exception. 
                this.SLAGeneralDialog.ClickCancel();
                throw new System.ArgumentNullException("SLA Name cannot be null!");
            }

            if (null != slaDescription)
            {
                Core.Console.UIUtilities.SetControlValue(this.SLAGeneralDialog.Controls.DescriptionOptionalTextBox, slaDescription);
                Utilities.LogMessage(currentMethod + ":: Set SLA description '"
                + this.SLAGeneralDialog.DescriptionOptionalText + "'");
            }

        }

        /// <summary>
        /// Set fields in the SLA Objects page: SLA Target, Scope and MP
        /// </summary>
        /// <param name="param">SLA Parameters Class that contains the SLA info</param>
        /// <history>
        /// [dialac] 17SEP08 - Created   
        /// [dialac] 20MAR09 - Adding work-around for bug #129790. 
        /// </history>
        //TODO: Maybe break down this method when going for each one of the Select Dialog.
        public void SettingFieldsObjectsPage(SLAParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (param == null)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: SLA parameters object is null", currentMethod));
                throw new System.ArgumentNullException("SLA Parameters cannot be null.");
            }

            // Trying to set SLA Target -- if its null throws System.ArgumentNullException (required field). 
            if (null != param.SLATargetName)
            {
                this.SLAObjectsDialog.ClickSelectTargetClass();

                //Filtering the search based on the Target Type and getting the right Resource String.
                string filterType = null;
                Utilities.LogMessage(String.Format(
                    "{0}:: The TargetType is: {1}", currentMethod, param.SLATargetType));
                switch (param.SLATargetType)
                {
                    case SLATargetClassType.DistApp:
                        filterType = Strings.FilterDistApp;
                        break;

                    case SLATargetClassType.Class:
                        filterType = Strings.FilterAll;
                        break;

                    case SLATargetClassType.Group:
                        filterType = Strings.FilterGroup;
                        break;

                    default:
                        Utilities.LogMessage(currentMethod + ":: SLATargetType parameter: '" +
                            param.SLATargetType + "' is invalid");
                        throw new InvalidEnumArgumentException("Invalid Type selected");
                }
                Utilities.LogMessage(String.Format(
                                "{0}:: The Target Type string localized is: {1}", currentMethod, filterType));
                this.SelectSLATargetDialog.SearchResultFilterText = filterType;

                //Setting now the textbox with TargetName
                string resouceTarget = this.GetResourceStringTarget(param.SLATargetName);
                this.SelectSLATargetDialog.LookForText = resouceTarget;
                Utilities.LogMessage(String.Format(
                               "{0}:: The Target Name to look for is: {1}", currentMethod, resouceTarget));
 

                //Verifying if the result in the grid view contains the target 
                if (this.SelectSLATargetDialog.Controls.SummaryListView.Count == 0)
                {
                    Utilities.LogMessage(currentMethod + ":: The SLA Target was not found in the Search");
                    //closing the dialog - before throwing the Exception 
                    this.SelectSLATargetDialog.ClickCancel();
                    throw new ListView.Exceptions.ListViewHasNoItemsException(
                        "When looking for the specified Target the result was empty");
                }


                bool targetFound = false; 
                //Work-around for bug #129790 - The ListView shows empty in the UI, even though 
                //it shows a results counter(at the end of the page) of around 300 items. 
                //Problem: When trying to GetItems for the Collection, sometime we get the exception 
                //ArgumentException => ("index (2) must be >= 0 or less than the number of items in the 
                //ListView (1)") because the listview is empty. 
                //Word_around: Retry a second time to search for target name 
                try
                {
                    targetFound = this.IsItemFoundListViewResult(
                        this.SelectSLATargetDialog.Controls.SummaryListView, resouceTarget);
                }
                catch (System.ArgumentException e)
                {
                    Utilities.LogMessage(String.Format(
                        "{0}:: Most likely we hit bug#129790 where the listView" + 
                        "is showed empty in the UI but there are items to be showed.", currentMethod));
                    Utilities.LogMessage(String.Format( 
                        "{0}:: Exception info: {1}", currentMethod, e.Message));
                    Utilities.LogMessage(String.Format(
                        "{0}:: Searching again to see if the list view is refreshed.", currentMethod));
                    
                    //Hitting clear button 
                    this.SelectSLATargetDialog.ClickClear();
                    Sleeper.Delay(2000);

                    this.SelectSLATargetDialog.LookForText = resouceTarget;
                    Utilities.LogMessage(String.Format(
                        "{0}:: Second time looking for the Target Name '{1}'", 
                        currentMethod,
                        resouceTarget));

                    targetFound = this.IsItemFoundListViewResult(
                        this.SelectSLATargetDialog.Controls.SummaryListView, resouceTarget);
                }

                //Checking to see if the target was found
                if (targetFound == false)
                {
                    Utilities.LogMessage(String.Format(
                                "{0}:: The Target '{1}' was not found in the result list", currentMethod, resouceTarget));
                    //Closing the dialog 
                    this.SelectSLATargetDialog.ClickCancel();
                    throw new ListView.Exceptions.ItemNotFoundException(
                        "Target specified not found in the result list");
                }

                //At this point, we have the target found and selected. Click on OK
                this.SelectSLATargetDialog.ClickOK();

                #region setting Scope

                Utilities.LogMessage(String.Format("{0}:: Selecting the Scope", currentMethod));
                if (param.SLAScopeType == SLAScopeType.AllObjects)
                {
                    //Don't need to do anything but checking to see if 
                    //the ALL Objects radio button is selected by default 
                    if (this.SLAObjectsDialog.RadioGroupScopeType == 
                        RadioGroupScopeType.AllObjectsOfTheTargetedClass)
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: The AllObjects is selected by default.", currentMethod));
                        //TODO DIALAC - REmove this delay
                        Sleeper.Delay(2000);
                    }
                    else
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: The AllObjects is not selected by default", currentMethod));
                        throw new Maui.GlobalExceptions.MauiException(
                            "The AllObjects option for the Scope is not selected by default");
                    }
                }
                else //Group or Object
                {
                    //checking the state of the radio button first
                    if (this.SLAObjectsDialog.RadioGroupScopeType == 
                        RadioGroupScopeType.AllObjectsOfTheTargetedClass)
                    {
                        this.SLAObjectsDialog.RadioGroupScopeType = RadioGroupScopeType.AGroupOrObjectThatContainsObjectsOfTheTargetedClass;
                        Sleeper.Delay(Constants.OneSecond * 2);
                        this.SLAObjectsDialog.ClickSelectScope();
                        //this.SelectScopeDialog.WaitForResponse();
                        //searching ans select the scope in the selectaScope dialog 
                        this.NavigateSelectScope(param.SLAScope);
                    }
                    else
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: The AllObjects is not selected by default", currentMethod));
                        throw new Maui.GlobalExceptions.MauiException(
                            "The AllObjects option for the Scope is not selected by default");
                    }
                }
                

                #endregion

                #region setting MP

                if (null != param.SLADestinationMP &&
                    this.SLAObjectsDialog.Controls.SelectDestinationManagementPackComboBox.IsEnabled == true)
                {
                    //If null - the Default MP is going to be used. 
                    Utilities.LogMessage(String.Format("{0}:: The Destination MP is: {1}", currentMethod, param.SLADestinationMP));
                    this.SLAObjectsDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(param.SLADestinationMP);
                }

                #endregion

            }
            else
            {

                Utilities.LogMessage(String.Format("{0}:: SLA Target is null", currentMethod));
                throw new System.ArgumentNullException("SLA Target cannot be null!");
            }
        }

        #region Verification Methods

        /// <summary>
        /// Verifying if properties in the General page (Name and Description) are correct
        /// </summary>
        /// <param name="param">SLA Parameters Class that contains the SLA info</param>
        /// <history>
        /// [dialac] 29SEP08 - Created        
        /// </history>
        public void VerifyFieldsGeneralPage(SLAParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            bool result = false;

            //Verifying th input parameters
            if (param == null)
            {
                Utilities.LogMessage(String.Format("{0}:: the SLA parameters is null.", currentMethod));
                throw new System.ArgumentNullException("Param is null");
            }

            //Verifying the Name propety
            Utilities.LogMessage(String.Format("{0}:: Verifying SLA NAME property.", currentMethod));
            result = this.VerifySLASLOProperty(this.SLAGeneralDialog.NameText, param.SLAName);
            if (result == false)  
            {
                Utilities.LogMessage(String.Format("{0}:: SLA Name is incorrect.", currentMethod));
                throw new Maui.GlobalExceptions.MauiException("SLA Name is incorrect");
            }
            
            // Name is correct; verifying the Description field. 
            Utilities.LogMessage(String.Format("{0}:: Verifying the SLA Description property", currentMethod));
            //result = this.VerifySLASLOProperty(this.SLAGeneralDialog.DescriptionOptionalText, param.SLADescription);

            //Add retry to work around test bug#562541
            int retryIndex = 0;
            while (retryIndex++ < Constants.DefaultMaxRetry)
            {
                try
                {
                    result = this.VerifySLASLOProperty(this.SLAGeneralDialog.DescriptionOptionalText, param.SLADescription);
                    break;
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("Maui get description textbox failed, initialize the parent dialog again to retry. retryIndex=" + retryIndex);
                    Sleeper.Delay(Constants.OneSecond * 10);
                    this.cachedServiceLevelTrackingGeneralDialog = new ServiceLevelTrackingGeneralDialog(CoreManager.MomConsole);
                    Sleeper.Delay(Constants.OneSecond * 5);
                }
            }

            if (result == false)
            {
                Utilities.LogMessage(String.Format("{0}:: SLA Description is incorrect.", currentMethod));
                throw new Maui.GlobalExceptions.MauiException("SLA Description is incorrect");
            }

        }

        /// <summary>
        /// Verify SLA properties in teh Object page: SLA Target, Scope and MP
        /// </summary>
        /// <param name="param">SLA Parameters Class that contains the SLA info</param>
        /// <history>
        /// [dialac] 30SEP08 - Created        
        /// </history>
        public void VerifyFieldsObjectsPage(SLAParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            bool result = false;

            //Verifying th input parameters
            if (param == null)
            {
                Utilities.LogMessage(String.Format("{0}:: the SLA parameters is null.", currentMethod));
                throw new System.ArgumentNullException("Param is null");
            }

            #region verify SLATarget

            //Verifying the SLA Target propety
            Utilities.LogMessage(String.Format("{0}:: Verifying SLA Target property.", currentMethod));
            string resouceTarget = this.GetResourceStringTarget(param.SLATargetName);
            result = this.VerifySLASLOProperty(this.SLAObjectsDialog.TargetText, resouceTarget);

            if (result == false)
            {
                Utilities.LogMessage(String.Format("{0}:: SLA Target is incorrect.", currentMethod));
                throw new Maui.GlobalExceptions.MauiException("SLA Target is incorrect");
            }

            #endregion

            #region VerifyScope
            // Target is correct; verifying the Scope field. 
            Utilities.LogMessage(String.Format("{0}:: Verifying the SLA Scope property", currentMethod));
            try
            {
                RadioGroupScopeType myType = this.SLAObjectsDialog.RadioGroupScopeType;
            }
            catch (Exception)
            {
                Utilities.LogMessage("Working around on time issues. The scope field was not available in the dialog yet.  - Sleeping to get the Scope - 5s");
                Sleeper.Delay(5000);
            }

            //Verifying if for Singleton Class the Scope button is disabled. 
            if (param.IsSLATargetSingleton)
            {
                if (this.SLAObjectsDialog.Controls.AGroupOrObjectThatContainsObjectsOfTheTargetedClassRadioButton.IsEnabled ||
                    this.SLAObjectsDialog.Controls.AllObjectsOfTheTargetedClassRadioButton.IsEnabled)
                {
                    Utilities.LogMessage(String.Format("{0}:: SLA Scope is enabled for singleton class {1}. It should be disabled", currentMethod, param.SLATargetName));
                    throw new Maui.Core.WinControls.Button.Exceptions.CheckFailedException("The Scope is enabled for Singleton Class.");
                }
            }
            else
            {

                if (param.SLAScopeType == SLAScopeType.AllObjects) //The scope text box should be blank 
                {
                    if (this.SLAObjectsDialog.RadioGroupScopeType == RadioGroupScopeType.AGroupOrObjectThatContainsObjectsOfTheTargetedClass)
                    {
                        Utilities.LogMessage(String.Format("{0}:: SLA Scope is incorrect. The scope should be to ALLOBjects", currentMethod));
                        throw new Maui.GlobalExceptions.MauiException("SLA Scope is incorrect. It should be AllObjects option");
                    }
                }
                else //Scope should be to a Group/Instance
                {
                    if (this.SLAObjectsDialog.RadioGroupScopeType == RadioGroupScopeType.AGroupOrObjectThatContainsObjectsOfTheTargetedClass)
                    {
                        result = this.VerifySLASLOProperty(this.SLAObjectsDialog.ScopeTextBoxText, param.SLAScope);
                        if (result == false)
                        {
                            Utilities.LogMessage(String.Format("{0}:: SLA Scope group or object is incorrect.", currentMethod));
                            throw new Maui.GlobalExceptions.MauiException("SLA Scope is incorrect. The value of the instance of scope field is incorrect");
                        }
                    }
                    else
                    {
                        Utilities.LogMessage(String.Format("{0}:: SLA Scope is incorrect. The scope should be to a Group or Object", currentMethod));
                        throw new Maui.GlobalExceptions.MauiException("SLA Scope is incorrect. The scope should be an GroupInstance and it shows AllObjects");

                    }

                }
            }

            #endregion

            #region verifyMP


            //TODO - DIALAC - NOT ready yet. 
            //// Scope is correct; verifying the MP field. 
            //Utilities.LogMessage(String.Format("{0}:: Verifying the SLA MP property", currentMethod));
            //result = this.VerifySLASLOProperty(this.SLAObjectsDialog.SelectDestinationManagementPackText, param.SLADestinationMP);
            //if (result == false)
            //{
            //    Utilities.LogMessage(String.Format("{0}:: SLA Management Pack Destination is incorrect.", currentMethod));
            //    throw new Maui.GlobalExceptions.MauiException("SLA Management Pack Destination is incorrect");
            //}

            #endregion

        }

        /// <summary>
        /// Verify if the expected value for a given property is correct. 
        /// </summary>
        /// <param name="pageValue">The Value found in the page/wizard</param>
        /// <param name="expectedValue">The Value expected for teh property</param>
        /// <history>
        /// [dialac] 30SEP08 - Created        
        /// </history>
        public bool VerifySLASLOProperty(string pageValue, string expectedValue)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Initializing the output parameter. 
            bool result = false;

            if (pageValue == expectedValue)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The property value is correct: {1}", currentMethod, pageValue));
                result = true;
            }
            else
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The property value is not correct. In the UI: {1}; Expected: {2}", 
                    currentMethod, pageValue, expectedValue));
                result = false;
            }

            return result;
        }

        #endregion

        #region Add/Edit/Remove SLO action methods

        /// <summary>
        /// Add SLO to a SLA during Creation or through Property page. 
        /// The second element in the array passed as param is always null. 
        /// </summary>
        /// <param name="slos">SLO object that contains the SLO info to be created</param>
        /// <history>
        /// [dialac] 24SEP08 - Created        
        /// </history>
        public void AddSLO(SLO[] slos)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //For ADD function, the second element in the array of SLOs is going to be null. 
            //So, assigning the first element to a local variable since we are going to 
            //use only the first element. 
            SLO slo = slos[0];

            if (null == slo)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The SLO to be added is null.", currentMethod));
                throw new System.ArgumentNullException("The SLO to be added shouldn't be null");
            }

            CoreManager.MomConsole.InvokeToolBarButton(
                                 this.SLASLOsDialog.Controls.SloButtonsToolStrip,
                                 Strings.AddToolBarItem);

            //Getting the resource string for the menu item based on the sloType 
            //string menuItem = null;
            Sleeper.Delay(Control.DefaultTimeout * 2);

            Utilities.LogMessage(currentMethod + ":: SLO Type " + slo.SLOType.ToString());
            // Use Mouse.Move and Mouse.Click is not intelligent, but if the UI Layout and DPI settings not change, it always works
            // And in Maui 4.0, we faild to find and instantiate menu or menu items under the toolbar, so we use Mouse.Click instead
            switch (slo.SLOType)
            {
                case SLOType.MonitorState:
                    Mouse.Move(Mouse.X, Mouse.Y + 18);
                    Sleeper.Delay(Control.DefaultTimeout);
                    Mouse.Click(Mouse.X, Mouse.Y);

                    break;

                case SLOType.CollectionRule:
                    Mouse.Move(Mouse.X, Mouse.Y + 38);
                    Sleeper.Delay(Control.DefaultTimeout);
                    Mouse.Click(Mouse.X, Mouse.Y);
                    break;

                default:
                    Utilities.LogMessage(currentMethod + ":: SLO Type : '" +
                        slo.SLOType + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            //Instantiate the right Dialog (monitor State or Collection Rule SLO type)
            switch (slo.SLOType)
            {
                case SLOType.MonitorState:
                    this.MonitorStateSLODialog.WaitForResponse();
                    this.NavigationMonitorStateSLOPage(slo);
                    break;

                case SLOType.CollectionRule:
                    this.CollectionRuleSLODialog.WaitForResponse();
                    this.NavigationCollectionRuleSLOPage(slo);
                    break;

                default:
                    Utilities.LogMessage(currentMethod + ":: Incorrect SLO Type " + slo.SLOType);
                    throw new InvalidEnumArgumentException(currentMethod + ":: Incorrect SLO Type specified");
            }
        }

        

        /// <summary>
        /// Edit SLO during Creation or through Property page. 
        /// The first element in the array is the original SLO. The second element is the new slo. 
        /// </summary>
        /// <param name="slos">SLO objects that contain the SLO info to be created</param>
        /// <history>
        /// [dialac] 25SEP08 - Created        
        /// </history>
        public void EditSLO(SLO[] slos)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //First we need to select the SLO to be added. 
            //In the array passed to the Edit Method, the first element is the one to be edited. 
            //The second element is the configuration of the properties we want to change.

            if (null == slos || slos.Length < 2)
            {
                Utilities.LogMessage(String.Format(
                         "{0}:: The Edit Method was passed without valid parameters. The SLOS are null.", 
                         currentMethod));
                throw new NullReferenceException(
                    "The Edit Method was passed without valid parameters. The SLOS are null.");
            }

            SLO original = slos[0];
            SLO newSlo = slos[1];

            if (null == original || null == newSlo)
            {
                Utilities.LogMessage(String.Format("{0}:: The SLOS can not be null", currentMethod));
                throw new NullReferenceException("The SLOS can not be null");
            }

            //Get the name of the first SLO to look for it in the list view in the UI
            string sloName = original.SLOName;
            Utilities.LogMessage(String.Format(
                      "{0}:: The name of SLO name to be Edited is '{1}'",
                       currentMethod, sloName));

            bool sloFound = IsItemFoundListViewResult(this.SLASLOsDialog.Controls.SLOListView, sloName);
            
            //ListViewItemCollection items = this.SLASLOsDialog.Controls.SLOListView.Items;
            //bool sloFound = false;
            //for (int i = 0; i < items.Count; i++)
            //{
            //    if (items[i].Text == sloName)
            //    {
            //        sloFound = true;
            //        Utilities.LogMessage(currentMethod + ":: SLO found!");
            //        items[i].Select();
            //        break;
            //    }
            //}

            //Checking to see if the slo was found
            if (sloFound == false)
            {
                Utilities.LogMessage(String.Format(
                            "{0}:: The SLO '{1}' was not found in the result list", currentMethod, sloName));
                //Closing the dialog 
                this.SLASLOsDialog.ClickCancel();
                throw new ListView.Exceptions.ItemNotFoundException(
                                          "SLO specified not found in the result list");
            }

            CoreManager.MomConsole.InvokeToolBarButton(
                                this.SLASLOsDialog.Controls.SloButtonsToolStrip,
                                Strings.EditToolBarItem);

            switch (original.SLOType)
            {
                case SLOType.MonitorState:
                    this.MonitorStateSLODialog.WaitForResponse();
                    this.NavigationMonitorStateSLOPage(newSlo);
                    //If the newSLO.SLOName is not null or empty, means that the name of the SLO was updated. 
                    //So we need to make sure the original gets the new name to be used when verifying the SLASLO.
                    if (newSlo.SLOName != null && newSlo.SLOName != string.Empty)
                    {
                        original.SLOName = newSlo.SLOName;
                    }
                    break;

                case SLOType.CollectionRule:
                    this.CollectionRuleSLODialog.WaitForResponse();
                    this.NavigationCollectionRuleSLOPage(newSlo);
                    if (newSlo.SLOName != null && newSlo.SLOName != string.Empty)
                    {
                        original.SLOName = newSlo.SLOName;
                    }
                    break;

                default:
                    Utilities.LogMessage(currentMethod + ":: Incorrect SLO Type " + original.SLOType);
                    throw new InvalidEnumArgumentException(currentMethod + ":: Incorrect SLO Type specified");
            }

        }

        /// <summary>
        /// Remove SLO during Creation or through Property page. 
        /// The second element in the array passed as param is always null. 
        /// </summary>
        /// <param name="slos">SLO objects that contain the SLO info to be deleted</param>
        /// <history>
        /// [dialac] 29SEP08 - Created        
        /// </history>
        public void RemoveSLO(SLO[] slos)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Verifying the input parameters. 
            if (null == slos || slos.Length == 0)
            {
                Utilities.LogMessage(String.Format(
                          "{0}:: The Remove Method was passed withouth valid parameters." + 
                          "The SLO to be removed is null.", 
                          currentMethod));
                throw new NullReferenceException(
                          "The Remove Method was passed withouth valid parameters. The SLO to be deleted is null.");
            }

            SLO removeSlo = slos[0];

            Utilities.LogMessage(String.Format(
                                "{0}:: The name of the slo to be removed is '{1}'.",
                                currentMethod, removeSlo.SLOName));

            bool sloFound = this.IsItemFoundListViewResult(this.SLASLOsDialog.Controls.SLOListView, removeSlo.SLOName);

            //ListViewItemCollection items = this.SLASLOsDialog.Controls.SLOListView.Items;
            //bool sloFound = false;
            //for (int i = 0; i < items.Count; i++)
            //{
            //    if (items[i].Text == removeSlo.SLOName)
            //    {
            //        sloFound = true;
            //        Utilities.LogMessage(currentMethod + ":: SLO found!");
            //        items[i].Select();
            //        break;
            //    }
            //}

            //Checking to see if the target was found
            if (sloFound == false)
            {
                Utilities.LogMessage(String.Format(
                            "{0}:: The SLO '{1}' was not found in the result list", currentMethod, removeSlo.SLOName));
                //Closing the dialog 
                this.SLASLOsDialog.ClickCancel();
                throw new ListView.Exceptions.ItemNotFoundException(
                                          "SLO specified not found in the result list");
            }

            CoreManager.MomConsole.InvokeToolBarButton(
                                this.SLASLOsDialog.Controls.SloButtonsToolStrip,
                                Strings.RemoveToolBarItem);

            //VErifying if the slo was really removed from the list. 
            ListView list = this.SLASLOsDialog.Controls.SLOListView;
            list = this.SLASLOsDialog.Controls.SLOListView;
            ListViewItemCollection items = null;
            try
            {
                items = list.FindAllByText(removeSlo.SLOName);
            }
            catch (Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException)
            {
                Utilities.LogMessage(String.Format(
                           "{0}:: The slo was successfully removed from the ListView", currentMethod));
            }

            if (items.Count > 0)
            {
                Utilities.LogMessage(String.Format(
                              "{0}:: The slo was not removed from list view", currentMethod));
                throw new Maui.GlobalExceptions.MauiException(
                           "Removal of SLO failed. The slo still appears in the list view after it's been removed.");
            }
        }

        #endregion

        /// <summary>
        /// Navigation of Monitor State SLO page. 
        /// This method is called during the Creation and Properties Page. 
        /// </summary>
        /// <param name="slo">SLO Object that contains the SLO info</param>
        /// <history>
        /// [dialac] 24SEP08 - Created        
        /// </history>
        public void NavigationMonitorStateSLOPage(SLO slo)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (null == slo)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The SLO is null.", currentMethod));
                throw new System.ArgumentNullException("The SLO shouldn't be null");
            }

            //Navigating to the Name Field.
            this.NavigateSLONameField(slo.SLOName, SLOType.MonitorState);

            //Setting the Target Class
            this.NavigateSLOTargetField(slo.SLOTargetName, SLOType.MonitorState);

            #region SLOMonitor

            Utilities.LogMessage(String.Format(
                        "{0}:: The slo monitor to be assigned is: {1}", currentMethod, slo.MonitorId));
            
            //If it's null, then we should leave as the default (Availability)
            if (null != slo.MonitorId && slo.MonitorId != String.Empty) 
            {
                this.MonitorStateSLODialog.MonitorText = slo.MonitorId;
                Utilities.LogMessage(String.Format(
                         "{0}:: The slo monitor now is: {1}", 
                         currentMethod, this.MonitorStateSLODialog.MonitorText));
            }

            #endregion

            #region Goal

            Utilities.LogMessage(String.Format(
                "{0}:: The slo goal to be assigned is: {1}", currentMethod, slo.MonitorGoal));
            //If it's null, then we should leave as the default (Availability)from add not update the property if you are calling from Edit.
            if (null != slo.MonitorGoal && slo.MonitorGoal != String.Empty)
            {
                this.MonitorStateSLODialog.ServiceLevelObjectiveGoalText = slo.MonitorGoal;
                Utilities.LogMessage(String.Format(
                                "{0}:: the Goal set in the page is: {1} ", 
                                currentMethod, this.MonitorStateSLODialog.ServiceLevelObjectiveGoalText));
            }

            #endregion
            
            #region Undesired states

            //First getting the list of undesired state from the ENUM 
            Type enumType = typeof(UndesiredState);
            Utilities.LogMessage(currentMethod + ":: Undesired State enum type is: " + enumType.ToString());
            string[] undesiredStatesOptions = Enum.GetNames(enumType);

            //Now I need to check for each state if it's present the slo.undesiredstates array. 
            //If it is there, then we need to check the the checkbox if it's not checked already 
            //If it is not there, then we need to uncheck (if the checkbox is checked)
            for (int i = 0; i < undesiredStatesOptions.Length; i++)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the undesired state option is: {1}", currentMethod, undesiredStatesOptions[i]));

                //checking to see if the undesiredStatesOption was solicited by used (look for it in the slo array of undesired states_
                bool result = IsInSLOUndesiredStateArray(undesiredStatesOptions[i], slo);
                Utilities.LogMessage(String.Format(
                    "{0}:: was the state found in the slo array: {1}", currentMethod, result.ToString()));

                switch (undesiredStatesOptions[i].ToLowerInvariant())
                {
                    case "critical": //Just checking if this is really disabled in the UI. THis is expected. 
                        if (this.MonitorStateSLODialog.Controls.CriticalCheckBox.Checked == false ||
                            this.MonitorStateSLODialog.Controls.CriticalCheckBox.IsEnabled == true)
                        {
                            Utilities.LogMessage(String.Format(
                                "{0}:: The critical state is either not disabled or checked.", currentMethod));
                            throw new Exception("The critical state is either not disabled or checked.");
                        }
                        break;
                    case "unplannedmaintenance":
                        if (result == false) // the checkbox should be unchecked. 
                        {
                            if (this.MonitorStateSLODialog.UnplannedMaintenance == true)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: Uncheking the UnplannedMaintenance option", currentMethod));
                                this.MonitorStateSLODialog.ClickUnplannedMaintenance();
                            }
                            //else - don't do anything. It's already unchecked. 
                        }
                        else //The checkbox should be checked. 
                        {
                            if (this.MonitorStateSLODialog.UnplannedMaintenance == false)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: checking the UnplannedMaintenance option", currentMethod));
                                this.MonitorStateSLODialog.ClickUnplannedMaintenance();
                            }
                            //else - don't do anything. It's already checked.
                        }
                        break;
                    case "unmonitored":
                        if (result == false) // the checkbox should be unchecked. 
                        {
                            if (this.MonitorStateSLODialog.Unmonitored == true)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: Uncheking the Unmonitored option", currentMethod));
                                this.MonitorStateSLODialog.ClickUnmonitored();
                            }
                            //else - don't do anything. It's already unchecked. 
                        }
                        else //The checkbox should be checked. 
                        {
                            if (this.MonitorStateSLODialog.Unmonitored == false)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: checking the Unmonitored option", currentMethod));
                                this.MonitorStateSLODialog.ClickUnmonitored();
                            }
                            //else - don't do anything. It's already checked.
                        }
                        break;
                    case "monitoringunavailable":
                        if (result == false) // the checkbox should be unchecked. 
                        {
                            if (this.MonitorStateSLODialog.MonitoringUnavailable == true)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: Uncheking the MonitoringUnavailable option", currentMethod));
                                this.MonitorStateSLODialog.ClickMonitoringUnavailable();
                            }
                            //else - don't do anything. It's already unchecked. 
                        }
                        else //The checkbox should be checked. 
                        {
                            if (this.MonitorStateSLODialog.MonitoringUnavailable == false)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: checking the MonitoringUnavailable option", currentMethod));
                                this.MonitorStateSLODialog.ClickMonitoringUnavailable();
                            }
                            //else - don't do anything. It's already checked.
                        }
                        break;
                    case "monitordisabled":
                        if (result == false) // the checkbox should be unchecked. 
                        {
                            if (this.MonitorStateSLODialog.MonitorDisabled == true)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: Uncheking the MonitorDisabled option", currentMethod));
                                this.MonitorStateSLODialog.ClickMonitorDisabled();
                            }
                            //else - don't do anything. It's already unchecked. 
                        }
                        else //The checkbox should be checked. 
                        {
                            if (this.MonitorStateSLODialog.MonitorDisabled == false)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: checking the MonitorDisabled option", currentMethod));
                                this.MonitorStateSLODialog.ClickMonitorDisabled();
                            }
                            //else - don't do anything. It's already checked.
                        }
                        break;
                    case "plannedmaintenance":
                        if (result == false) // the checkbox should be unchecked. 
                        {
                            if (this.MonitorStateSLODialog.PlannedMaintenance == true)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: Uncheking the PlannedMaintenance option", currentMethod));
                                this.MonitorStateSLODialog.ClickPlannedMaintenance();
                            }
                            //else - don't do anything. It's already unchecked. 
                        }
                        else //The checkbox should be checked. 
                        {
                            if (this.MonitorStateSLODialog.PlannedMaintenance == false)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: checking the PlannedMaintenance option", currentMethod));
                                this.MonitorStateSLODialog.ClickPlannedMaintenance();
                            }
                            //else - don't do anything. It's already checked.
                        }
                        break;
                    case "warning":
                        if (result == false) // the checkbox should be unchecked. 
                        {
                            if (this.MonitorStateSLODialog.Warning == true)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: Uncheking the Warning option", currentMethod));
                                this.MonitorStateSLODialog.ClickWarning();
                            }
                            //else - don't do anything. It's already unchecked. 
                        }
                        else //The checkbox should be checked. 
                        {
                            if (this.MonitorStateSLODialog.Warning == false)
                            {
                                Utilities.LogMessage(String.Format(
                                    "{0}:: checking the Warning option", currentMethod));
                                this.MonitorStateSLODialog.ClickWarning();
                            }
                            //else - don't do anything. It's already checked.
                        }
                        break;

                    default:
                        Utilities.LogMessage(currentMethod + 
                            ":: Incorrect UndesiredState " + undesiredStatesOptions[i]);
                        throw new InvalidEnumArgumentException(currentMethod + 
                            ":: Incorrect SLO Undesired state specified");
                }
            }
            #endregion

            //Closing the Dialog. 
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(MonitorStateSLODialog.Controls.OKButton, Constants.OneMinute);
            this.MonitorStateSLODialog.ClickOK();
            //Settting to null to make sure the HWND is reset 
            //if I close the dialog and open again with the same wizard.  
            this.cachedServiceLevelObjectiveMonitorStateDialog = null;

        }

        /// <summary>
        /// Navigation of Collection rule SLO page 
        /// </summary>
        /// <param name="slo">SLO that contains the SLO info</param>
        /// <history>
        /// [dialac] 25SEP08 - Created        
        /// </history>
        public void NavigationCollectionRuleSLOPage(SLO slo)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (null == slo)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The SLO is null.", currentMethod));
                throw new System.ArgumentNullException("The SLO shouldn't be null");
            }

            //Navigating to the Name field. 
            this.NavigateSLONameField(slo.SLOName, SLOType.CollectionRule);

            //Naviagating to the SLO Target 
            this.NavigateSLOTargetField(slo.SLOTargetName, SLOType.CollectionRule);

            #region SLORule

            //If the Textbox is null, means that you are navigating in this dialog because you are adding 
            //a slo. Because of that, RuleId can't be null or empty. 
            if (this.CollectionRuleSLODialog.PerformanceCollectionRuleText == null ||
                this.CollectionRuleSLODialog.PerformanceCollectionRuleText == string.Empty) 
            {
                if (null != slo.RuleId && slo.RuleId != string.Empty)
                {
                    //Click on Select Button to select the Rule
                    Utilities.TakeScreenshot(currentMethod+" - before click SELECT button");
                    this.CollectionRuleSLODialog.ClickSelectRule();

                    //Wait 15 seconds to make sure SLOSelectRuleDialog initialize
                    System.Threading.Thread.Sleep(Constants.OneSecond*15);
                    Utilities.LogMessage(currentMethod + ":: Wait 15 seconds to make sure SLOSelectRuleDialog initialize.");
                    Utilities.TakeScreenshot(currentMethod + " - after click SELECT button");

                    string ruleLookForText = this.GetRuleName(slo.RuleId);
                    this.SLOSelectRuleDialog.LookForText = ruleLookForText;

                    //Selecting the Rule from the result list (should have only one in the result)
                    bool ruleFound = this.IsItemFoundListViewResult(this.SLOSelectRuleDialog.Controls.LookForListView, ruleLookForText);

                    //Checking to see if the target was found
                    if (ruleFound == false)
                    {
                        Utilities.LogMessage(String.Format(
                                    "{0}:: The SLO Rule '{1}' was not found in the result list",
                                    currentMethod, ruleLookForText));
                        //Closing the dialog 
                        this.SLOSelectRuleDialog.ClickCancel();
                        throw new ListView.Exceptions.ItemNotFoundException(
                                                  "SLO Rule specified not found in the result list");
                    }

                    this.SLOSelectRuleDialog.ClickOK();
                    this.cachedSelectaRuleDialog = null;
                    this.CollectionRuleSLODialog.WaitForResponse();

                }
                else //If it's null, then throw a exception since this is a required field. 
                {
                    Utilities.LogMessage(String.Format(
                        "{0}:: You need to enter a rule to be associated to the SLO", currentMethod));
                    throw new Maui.GlobalExceptions.MauiException("You need to enter a rule to be associated to the SLO.");
                }
            }

            #endregion

            #region Aggregation Method

            //TIME ISSUE - WORK AROUND - bug # 137130
            //Adding retry logic in case the previous dialog (select Rule) is taking 
            //a little bit longer to close and then the automation would fail to find the 
            //radio button control. 
            int retry = 0;
            int maxRetry = 3;
            bool previousDialogClosed = false;
            while (retry < maxRetry && previousDialogClosed == false)
            {
                try
                {
                    Utilities.LogMessage(String.Format(
                        "{0}:: Aggregation is: {1}", currentMethod, slo.AggregationMethod.ToString()));
                    switch (slo.AggregationMethod)
                    {
                        case AgregationMethod.Average:
                            this.CollectionRuleSLODialog.RadioGroup = AggregationMethodRadioGroup.Average;
                            break;

                        case AgregationMethod.Max:
                            this.CollectionRuleSLODialog.RadioGroup = AggregationMethodRadioGroup.Max;
                            break;

                        case AgregationMethod.Min:
                            this.CollectionRuleSLODialog.RadioGroup = AggregationMethodRadioGroup.Min;
                            break;

                        default:
                            Utilities.LogMessage(currentMethod +
                                ":: Incorrect SLO Aggregation Method " + slo.AggregationMethod);
                            throw new InvalidEnumArgumentException(currentMethod +
                                ":: Incorrect SLO Aggregation Method specified");
                    }

                    previousDialogClosed = true; 
                }
                catch (Maui.Core.Window.Exceptions.InvalidHWndException)
                {
                    retry++;
                    Utilities.LogMessage(String.Format("{0} :: " +
                           "Maybe the previou Selct Rule dialog is still not closed.", currentMethod));
                    Utilities.LogMessage(String.Format("{0} :: " +
                            "Couldn't find the Radio button Control in the attempt #{1} of {2}. Retrying ... ", currentMethod, retry, maxRetry));

                }
                //MAUI ISSUE - WORK AROUND - bug # 497409
                catch (System.OverflowException e)
                {
                    retry++;
                    Utilities.LogMessage(String.Format("{0} :: " +
                           "Maybe Maui get radio button 'Average' failed. Exception:{1}", currentMethod,e.Message));
                    Utilities.LogMessage(String.Format("{0} :: " +
                            "Couldn't find the Radio button Control in the attempt #{1} of {2}. Retrying ... ", currentMethod, retry, maxRetry));
                    Utilities.TakeScreenshot("Get Average Radio Button Retry-"+retry);
                }
            }
            
            #endregion

            #region DesiredObjective

            //If it's null, then we should leave as the default value(Less than)
            if (null != slo.DesiredObjective && slo.DesiredObjective != string.Empty) 
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: DesiredObjective is: {1}", currentMethod, slo.DesiredObjective));
                switch (slo.DesiredObjective.ToLowerInvariant())
                {
                    case "underthreshold":
                        this.CollectionRuleSLODialog.ServiceLevelObjectiveGoalText = Strings.LessThanDesiredObjective;
                        break;

                    case "overthreshold":
                        this.CollectionRuleSLODialog.ServiceLevelObjectiveGoalText = Strings.MoreThanDesiredObjective;
                        break;

                    default:
                        Utilities.LogMessage(currentMethod + 
                            ":: Incorrect SLO Desired Objective" + slo.DesiredObjective);
                        throw new InvalidEnumArgumentException(currentMethod + 
                            ":: Incorrect SLO Desired Objective specified");
                }
            }
            #endregion

            #region Threhold

            if (null != slo.Threshold) //If it's null, then we should leave as the default(50)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: Threhold is: {1}", currentMethod, slo.Threshold));
                this.CollectionRuleSLODialog.GoalTextBoxText = slo.Threshold;
                Utilities.LogMessage(String.Format(
                    "{0}:: Threhold is: {1}", currentMethod, this.CollectionRuleSLODialog.GoalTextBoxText));
            }

            #endregion

            //Closing the Dialog. 
            this.CollectionRuleSLODialog.ClickOK();
            //Settting to null to make sure the HWND is reset if I call this dialog in the same wizard. 
            this.cachedSServiceLevelObjectiveCollectionRuleDialog = null;

        }

        /// <summary>
        /// Verify if the SLASLO properties are set with expected values. 
        /// </summary>
        /// <param name="param">SLA Parameter class containing sla config</param>
        /// <param name="isSCOMConsole">true if this method is called from Operation Manager Console</param> 
        /// <param name="slolist">List of slos that should be contained in the SLA</param> 
        /// <history>
        /// [dialac] 29SEP08 - Created        
        /// </history>
        public void VerifySLASLO(SLAParameters param, bool isSCOMConsole, string[] slolist)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (isSCOMConsole == true) //Calling from Operation Manager Console
            {
                //Selecting the sla in the SLAView
                bool slaFound = this.FindSLAEntryView(param.SLAName);

                if (slaFound == false)
                {
                    Utilities.LogMessage(String.Format(
                        "{0}:: the SLA was not found in the view", currentMethod));
                    throw new Maui.GlobalExceptions.MauiException("the SLA was not found in the view");
                }

                // Selecting Properties option from Action pane once the sla is selected. 
                CoreManager.MomConsole.ActionsPane.ClickLink(Strings.ActionsSLA, Strings.ActionPropertiesSLA);
                Utilities.LogMessage(currentMethod + ":: Successfully Launched the Properties page of SLA");
                this.SLAGeneralDialog.WaitForResponse();

            }

            //Verify properties in the General Page: Name and Description for SLA
            this.VerifyFieldsGeneralPage(param);

            //Navigating to the next page: SLA Object page 
            this.SLAGeneralDialog.ClickNext();
            this.cachedServiceLevelTrackingGeneralDialog = null;
            this.SLAObjectsDialog.WaitForResponse();

            //Setting the properties in the Objects page: SLA Target, Scope and MP
            this.VerifyFieldsObjectsPage(param);

            //Navigating to the next page: SLO page
            this.SLAObjectsDialog.ClickNext();
            this.cachedServiceLevelTrackingObjectsDialog = null;
            this.SLASLOsDialog.WaitForResponse();

            //Verify if the slos in the listview has all the expected SLOs. 
            this.VerifyListSlos(slolist); 

            this.SLASLOsDialog.ClickNext();
            this.cachedServiceLevelTrackingSLOsDialog = null;
            this.SLASummaryDialog.WaitForResponse();
            
            this.SLASummaryDialog.ClickFinish();
            this.cachedServiceLevelTrackingSummaryDialog = null;
            
            //Waiting for the SLA to be saved and only then close the wizard. 
            this.WaitForCompletionDialogReady(1000*60*10); //2 minute of timeout. 

            this.SLACompletionDialog.ClickClose();
            CoreManager.MomConsole.WaitForDialogClose(this.SLACompletionDialog, 60);
            this.cachedServiceLevelTrackingCompletionDialog = null;

        }

        /// <summary>
        /// Creates a SLA and SLOs, getting SLA configuration from SLAParameters class.
        /// </summary>
        /// <param name="param">SLA Parameter class containing sla config</param>
        /// <param name="isFromSCOMConsole">true if the user is launching the wizard from Ops Manager Console. False if it's from Authoring Console</param> 
        /// <param name="sloDataFileName">The name of the xml file which contains the slo definition/information.</param> 
        /// <history>
        /// [dialac] 01OCT08 - Created        
        /// </history>
        public void CreateSLASLO(SLAParameters param, bool isFromSCOMConsole, string sloDataFileName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (param == null)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The sla parameter class with the SLA and SLO information can not be null", currentMethod));
                throw new System.ArgumentNullException("The sla parameter is null");
            }

            if (isFromSCOMConsole == true) //Launching the wizard from Operations Manager Console
            {
                //WA:Service Level Tracking Node
                string SLAPath = NavigationPane.Strings.Authoring
                            + Constants.PathDelimiter
                            + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                            + Constants.PathDelimiter
                            //+ UserRole.UserRoles.Strings.ServiceLevelTracking;
                            + NavigationPane.Strings.MonConfigTreeViewServiceLevelTracking;
                Utilities.LogMessage(currentMethod + ":: SLAPath:" + SLAPath);
                CoreManager.MomConsole.BringToForeground();

                // Select the Monitoring Configuration wunderbar
                NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout * 4); //15*4 => 60 seconds

                // Select Service Level Tracking view
                navPane.SelectNode(SLAPath, NavigationPane.NavigationTreeView.Authoring);

                // Selecting Create (SLA) from Action pane
                CoreManager.MomConsole.ActionsPane.ClickLink(Strings.ActionsSLA, Strings.ActionCreateSLA);
                Utilities.LogMessage(currentMethod + ":: Successfully Clicking in the Create SLA option in the Action Pane");
            }

            //Accessing the pages of the wizard from here. 
            //Authoring Console has a different way of launching the wizard. 
            this.CreateSLASLO(param, sloDataFileName);
        }

        /// <summary>
        /// Creates a SLA and SLOs, getting SLA configuration from SLAParameters class and 
        /// reads SLO configuration from the given XML
        /// </summary>
        /// <param name="param">SLA Parameter class containing sla config</param> 
        /// <param name="sloDataFileName">The name of the xml file which contains the slo definition/information.</param> 
        /// <history>
        /// [dialac] 16SEP08 - Created        
        /// </history>
        public void CreateSLASLO(SLAParameters param, string sloDataFileName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (param == null)
            {
                Utilities.LogMessage(String.Format("{0}:: The sla parameter class with the SLA and SLO information can not be null", currentMethod));
                throw new System.ArgumentNullException("The sla parameter is null");
            }

            //Setting the properties in the General Page: Name and Description only
            this.SettingFieldsGeneralPage(param.SLAName, param.SLADescription);

            //Navigating to the next page: SLA Object page 
            this.SLAGeneralDialog.ClickNext();
            this.cachedServiceLevelTrackingGeneralDialog = null;
            this.SLAObjectsDialog.WaitForResponse();

            //Setting the properties in the Objects page: SLA Target, Scope and MP
            this.SettingFieldsObjectsPage(param);

            //Navigating to the next page: SLO page
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(SLAObjectsDialog.Controls.NextButton, Constants.OneMinute);
            this.SLAObjectsDialog.ClickNext();
            this.cachedServiceLevelTrackingObjectsDialog = null;
            this.SLASLOsDialog.WaitForResponse();

            //Execution the SLO actions (Add/Edit/Remove)
            this.ExecuteActions(param.SLOActionsStruct, sloDataFileName);
            this.SLASLOsDialog.WaitForResponse();

            this.SLASLOsDialog.ClickNext();
            this.cachedServiceLevelTrackingSLOsDialog = null;
            this.SLASummaryDialog.WaitForResponse();

            this.SLASummaryDialog.ClickFinish();
            this.cachedServiceLevelTrackingSummaryDialog = null;

            //Wait for the SLA to be saved before clicking on close button. 
            WaitForCompletionDialogReady(1000*60*10);

            this.SLACompletionDialog.ClickClose();
            CoreManager.MomConsole.WaitForDialogClose(this.SLACompletionDialog, 60);
            this.cachedServiceLevelTrackingCompletionDialog = null;

        }

        /// <summary>
        /// Delete a SLA 
        /// </summary>
        /// <param name="slaName">SLA name</param> 
        /// <history>
        /// [dialac] 30SEP08 - Created        
        /// </history>
        public void DeleteSLA(String slaName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Selecting the sla in the SLAView
            bool slaFound = this.FindSLAEntryView(slaName);

            if (slaFound == false)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the SLA was not found in the view", currentMethod));
                throw new Maui.GlobalExceptions.MauiException("the SLA was not found in the view");
            }

            // Selecting Properties option from Action pane once the sla is selected. 
            CoreManager.MomConsole.ActionsPane.ClickLink(Strings.ActionsSLA, Strings.ActionDeleteSLA);
            Utilities.LogMessage(currentMethod + ":: Successfully clicking on Delete option in the SLA Action Pane");

            try
            {
                //select Yes on the delete confirmation dialog
                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes, 
                    Strings.ConfirmSLADeleteTitle, StringMatchSyntax.ExactMatch, 
                    MomConsoleApp.ActionIfWindowNotFound.Error);
                //Wait until cursor type changes from busy icon
                Utilities.LogMessage(String.Format("{0}:: Succesfully deleted the SLA", currentMethod));
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: Failed to find window {1}", currentMethod, Strings.ConfirmSLADeleteTitle));
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
            }

        }

        /// <summary>
        /// Verify if the SLA was deleted and it doesn't show in the view anymore. 
        /// </summary>
        /// <param name="slaName">SLA name</param> 
        /// <history>
        /// [dialac] 30SEP08 - Created        
        /// </history>
        public void VerifyDeleteSLA(String slaName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            int retry = 0;
            int maxRetry = 5; 

            bool slaFound = true;

            while (slaFound == true && retry < maxRetry)
            {
                //Selecting the sla in the SLAView
                slaFound = this.FindSLAEntryView(slaName);
                Utilities.LogMessage(String.Format(
                        "{0}:: Attempt {1} of {2} looking for deleted SLA in the view. Found? {2}", 
                        currentMethod, retry, maxRetry, slaFound));
                retry++;

            }

            if (slaFound == true)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the SLA was still found in the view after it's been deleted.", currentMethod));
                throw new Maui.GlobalExceptions.MauiException(
                    "the SLA was still found in the view after it's been deleted.");
            }

        }

        /// <summary>
        /// The SLA gets saved when we hit finish but there is still one completion dialog to close 
        /// The process of saving can take some time, we need to wait before hitting the close. 
        /// </summary>
        /// <param name="timeout">Timout in milliseconds</param> 
        /// <history>
        /// [dialac] 15OCT08 - Created        
        /// </history>
        public void WaitForCompletionDialogReady(int timeout)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            int retry = 0;
            bool isbuttonVisible = false;

            Utilities.TakeScreenshot(currentMethod+"_BeforeWait");

            do
            {
                isbuttonVisible = this.SLACompletionDialog.Controls.CloseButton.IsEnabled;
                if (isbuttonVisible == false)
                {
                    Utilities.LogMessage(String.Format(
                        "{0}:: Waiting for SLA be saved to close the button.", currentMethod));
                    Sleeper.Delay(1000);
                }

                retry = retry + 1000;
            }
            while (isbuttonVisible == false && retry <= timeout);

            if (isbuttonVisible == false)
            {
                Utilities.TakeScreenshot(currentMethod + "_AfterWaitFailed"); 
                Utilities.LogMessage(String.Format(
                    "{0}:: The SLA was not saved and the Wizard couldn't be closed" + 
                    "after the timeout of {1} miliseconds", currentMethod, timeout));
                 throw new System.TimeoutException("The SLA was not saved and the Wizard couldn't be closed");

            }

            Utilities.TakeScreenshot(currentMethod + "_AfterWait");

        }

        /// <summary>
        /// Update SLASLO properties 
        /// </summary>
        /// <param name="slaOrigName">original name of the SLA to be found and updated</param>
        /// <param name="param">SLA Parameter class containing sla config</param> 
        /// <param name="updateActions">Actions to be performed in the SLOs </param>
        /// <param name="sloDataFileName">The name of the xml file which contains the slo definition/information.</param> 
        /// <history>
        /// [dialac] 29SEP08 - Created        
        /// </history>
        public void UpdateSLASLO(String slaOrigName, SLAParameters param, SLOAction[] updateActions, string sloDataFileName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Calling the UpdateSLA - which updates only the SLA properties. 
            this.UpdateSLA(slaOrigName, param); 

            //Then calling the updateSLASLO - which updates only the SLO properties. 
            this.UpdateSLASLO(param, updateActions, sloDataFileName);
        }

        /// <summary>
        /// Update SLASLO properties 
        /// </summary>
        /// <param name="param">SLA Parameter class containing sla config</param> 
        /// <param name="updateActions">Array of action to be performed agaisnt SLOs through properties page</param> 
        /// <param name="sloDataFileName">xml file which contains the slo information</param> 
        /// <history>
        /// [dialac] 29SEP08 - Created        
        /// </history>
        public void UpdateSLASLO(SLAParameters param, SLOAction[] updateActions, string sloDataFileName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (updateActions != null)
            {
                Utilities.LogMessage(currentMethod + ":: Updating the SLOs; adding, editing or removing them");
                this.ExecuteActions(updateActions, sloDataFileName);
            }

            this.SLASLOsDialog.ClickNext();
            this.cachedServiceLevelTrackingSLOsDialog = null;
            this.SLASummaryDialog.WaitForResponse();

            this.SLASummaryDialog.ClickFinish();
            this.cachedServiceLevelTrackingSummaryDialog = null;

            //Waiting for the SLA to be saved and only then close the wizard. 
            this.WaitForCompletionDialogReady(120000); //2 minute of timeout. 

            this.SLACompletionDialog.ClickClose();
            CoreManager.MomConsole.WaitForDialogClose(this.SLACompletionDialog, 60);
            this.cachedServiceLevelTrackingCompletionDialog = null;

        }

        /// <summary>
        /// Update SLA properties Only
        /// </summary>
        /// <param name="slaOrigName">Original name of SLA to get it from slaView</param> 
        /// <param name="param">Class which contains the SLA parameters to be modified.</param>
        /// <history>
        /// [dialac] 03OCT08 - Created        
        /// </history>
        public void UpdateSLA(string slaOrigName, SLAParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (slaOrigName == null || slaOrigName == String.Empty)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the SLA name can not be null." + 
                    "We need a name to select the SLA from View and open the properties page", currentMethod));
                throw new System.ArgumentNullException(
                    "the SLA name can not be null");
            }
          
            //Selecting the sla in the SLAView
            bool slaFound = this.FindSLAEntryView(slaOrigName);

            if (slaFound == false)
            {
                Utilities.LogMessage(String.Format("{0}:: the SLA was not found in the view", currentMethod));
                throw new Maui.GlobalExceptions.MauiException("the SLA was not found in the view");
            }

            // Selecting Properties option from Action pane once the sla is selected. 
            CoreManager.MomConsole.ActionsPane.ClickLink(Strings.ActionsSLA, Strings.ActionPropertiesSLA);
            Utilities.LogMessage(currentMethod + ":: Successfully Launched the Properties page of SLA");
            this.SLAGeneralDialog.WaitForResponse();

            if (param.SLAName != null) //If it's null - then we are not going to update. 
            {
                if (param.SLAName == string.Empty) //SPecial case. This can not be updated to EMPTY. 
                {
                    //Updating the parameter to be used when verifying the update. 
                    this.SLAGeneralDialog.NameText = param.SLAName;
                    
                    //Next Button should be disabled. 
                    if (this.SLAGeneralDialog.Controls.NextButton.IsEnabled == true)
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: The SLA name cannot be updated to a Empty String", currentMethod));
                        throw new System.NullReferenceException(String.Format(
                            "{0}:: The SLA name cannot be updated to a Empty String"));
                    }
                    this.SLAGeneralDialog.NameText = slaOrigName; //Putting the name back to the original.
                    Utilities.LogMessage(String.Format(
                        "{0}:: The SLA continues with the same original name because the new name can not be empty", currentMethod));
                }
                else
                {
                    this.SLAGeneralDialog.NameText = param.SLAName;
                    Utilities.LogMessage(String.Format(
                        "{0}:: The new SLA name value is {1}", currentMethod, param.SLAName));
                }
            }

            if (param.SLADescription != null) //If it's null - then we are not going to update. 
            {
                this.SLAGeneralDialog.DescriptionOptionalText = param.SLADescription;
                Utilities.LogMessage(String.Format(
                    "{0}:: The new SLA Description value is {1}", currentMethod, param.SLADescription));
            }

            if (this.SLAGeneralDialog.Controls.NextButton.IsEnabled == false)
            {
                Utilities.LogMessage("***********DIALAC- Debug only (remove)" + "Next is still disabled");
                Sleeper.Delay(5000);
            }
            this.SLAGeneralDialog.ClickNext();
            this.cachedServiceLevelTrackingGeneralDialog = null;
            this.SLAObjectsDialog.WaitForResponse();

            #region ScopeUpdate

            //Getting the original situation of Scope 
            if (this.SLAObjectsDialog.RadioGroupScopeType == RadioGroupScopeType.AllObjectsOfTheTargetedClass)
            {
                // User didn't provide anything in the varmap. Doesn't want to change the scope type 
                // Or user provided the same original type (ALL Objects)
                if (param.SLAScopeType == SLAScopeType.AllObjects)
                {
                    if (param.SLAScope != null && param.SLAScope != String.Empty) // Can not change since the scope type is ALL 
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: Can't change the scope to '{1}', since the the scope is selected to ALLObjects.", 
                            currentMethod, param.SLAScope));
                        throw new Maui.GlobalExceptions.MauiException((String.Format(
                            "{0}:: Can't change the scope to '{1}', since the the scope is selected to ALLObjects.", 
                            currentMethod, param.SLAScope)));
                    }
                    else
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: Nothing was changed. The AllObjects was already selected.", currentMethod));
                    }
                }
                if (param.SLAScopeType != SLAScopeType.AllObjects) //Group or Instance
                {
                    if (param.SLAScope == null || param.SLAScope == String.Empty)
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: You want to scope, so you should provide a scopeName", currentMethod));
                        throw new Maui.GlobalExceptions.MauiException((String.Format(
                            "{0}:: Can't change the scope to '{1}', since the the scope is selected to ALLObjects.", 
                            currentMethod, param.SLAScope)));
                    }
                    else 
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: Click on Select button and selecting the new Scope: {1}", 
                            currentMethod, param.SLAScope ));
                        this.SLAObjectsDialog.RadioGroupScopeType = RadioGroupScopeType.AGroupOrObjectThatContainsObjectsOfTheTargetedClass;
                        this.SLAObjectsDialog.ClickSelectScope();

                        this.NavigateSelectScope(param.SLAScope); 
                       
                    } //end of else - param.Scope is a new Value. 
                }//End of if scope is group or Instance
            }//ENd of if the Original Scope was ALLObjects. 


            //Now if the Original Scope was Specific to Group or Objects. 
            else if (this.SLAObjectsDialog.RadioGroupScopeType == RadioGroupScopeType.AGroupOrObjectThatContainsObjectsOfTheTargetedClass)
            {
                // User didn't provide anything in the varmap. Doesn't want to change the scope type 
                // Or it provided the same type (Group or Object)
                if (param.SLAScopeType != SLAScopeType.AllObjects)
                {
                    if (param.SLAScope != null && param.SLAScope != String.Empty) // Changing the scope to a different one. 
                    {
                        this.NavigateSelectScope(param.SLAScope);  
                    }
                    else
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: Nothing was changed. The Scope is the same.", currentMethod));
                    }
                }
                if (param.SLAScopeType == SLAScopeType.AllObjects) 
                {
                    //User is passing a scope but the scope type is select to AllObjects. 
                    if (param.SLAScope != null && param.SLAScope != String.Empty)
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: If You want to scope by '{1}', so you should select ALLObjects option", 
                            currentMethod, param.SLAScope));
                        throw new Maui.GlobalExceptions.MauiException((String.Format(
                            "{0}:: If You want to scope by '{1}', so you should select ALLObjects option", 
                            currentMethod, param.SLAScope)));
                    }
                    else 
                    {
                        this.SLAObjectsDialog.RadioGroupScopeType = RadioGroupScopeType.AllObjectsOfTheTargetedClass;
                        Utilities.LogMessage(String.Format(
                            "{0}:: Now scope has changed to ALL OBjects. ", currentMethod));
                       
                    } //end of else - param.Scope is null or EMpty. 
                }//End of if scope is All Objects
            }//ENd of if the Original Scope was AGrouporObject. 
          
            #endregion

            //Navigate to the Object Page 
            this.SLAObjectsDialog.ClickNext();
            this.cachedServiceLevelTrackingObjectsDialog = null;
            this.SLASLOsDialog.WaitForResponse();
        }
      
        #endregion

        #region Other Methods
        /// <summary>
        /// Verify if a undesired state option is in the array of undesired states passed with the SLO 
        /// </summary>
        /// <param name="undesiredStatesOption">option of undesired state in the UI</param>
        /// <param name="slo">slo which contains the list of states the user wants to check</param>
        /// <history>
        /// [dialac] 26SEP08 - Created        
        /// </history>
        public bool IsInSLOUndesiredStateArray (string undesiredStatesOption, SLO slo)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Initializating the output parameter
            bool result = false;

            //Checking the INPUT parameters
            if (undesiredStatesOption == null || 
                undesiredStatesOption == String.Empty ||
                slo == null)
            {
                Utilities.LogMessage(String.Format("{0}:: One the parameters is null", currentMethod));
                throw new System.ArgumentNullException("One the parameters is null");
            }

            if (undesiredStatesOption != null && undesiredStatesOption != String.Empty)
            {
                if ((slo != null) && (slo.UndesiredStates != null) && (slo.UndesiredStates.Length != 0))
                {
                    //Going through the list of undesired states in the slo (gotten from xml file)
                    for (int i = 0; i < slo.UndesiredStates.Length; i++)
                    {
                        if (slo.UndesiredStates[i].ToLowerInvariant() == undesiredStatesOption.ToLowerInvariant())
                        {
                            result = true;
                            Utilities.LogMessage(String.Format(
                                   "{0}:: state option {1} found in the slo array ", 
                                   currentMethod, undesiredStatesOption));
                            break;
                        }

                    } //end of FOR loop
                } //end of checking if SLO is valid
            } //end of checking if undesiredStatesOption is valid.

            Utilities.LogMessage (String.Format("{0}:: The result is: {1}", currentMethod, result.ToString()));
            return result; 
        }

        /// <summary>
        /// Verify if a undesired state option is in the array of undesired states passed with the SLO 
        /// </summary>
        /// <param name="listView">List View with the Result collection</param>
        /// <param name="itemName">name of the item we are looking for</param>
        /// <history>
        /// [dialac] 14OCT08 - Created        
        /// </history>
        public bool IsItemFoundListViewResult(ListView listView, string itemName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (listView == null || itemName == null || itemName == String.Empty)
            {
                Utilities.LogMessage(String.Format("{0}:: One the parameters is null", currentMethod));
                throw new System.ArgumentNullException("One the parameters is null");
            }

            ListViewItemCollection items = listView.Items;
            bool itemFound = false;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Text.ToLowerInvariant() == itemName.ToLowerInvariant())
                {
                    itemFound = true;
                    Utilities.LogMessage(currentMethod + ":: Item found!");
                    items[i].Select();
                    break;
                }
            }

            return itemFound;

        }

        /// <summary>
        /// Navigate in the array of actions to be executed and call the appropiate action for each elemet. 
        /// </summary>
        /// <param name="sloActionsStruct">Array that contains the action and SLOIds associate with the action.</param>
        /// /// <param name="xmlInput">xml Data File Name containing the slo config</param>
        /// <history>
        /// [dialac] 23SEP08 - Created        
        /// </history>
        public void ExecuteActions(SLOAction[] sloActionsStruct, string xmlInput)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            // Trying to make sure there is at least one action. -- if its null (or zero) throws System.ArgumentNullException
            if (sloActionsStruct == null || sloActionsStruct.Length == 0) 
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: No actions associated to the SLA. SLA can not be Empty", currentMethod));
                throw new System.ArgumentNullException("No actions associated to the SLA.");
            }

            // Trying to make sure there is a data xml file with the SLO config information
            if (xmlInput == null)
            {
                Utilities.LogMessage(String.Format(
                        "{0}:: You have to provide a xml data file with the SLO Config", currentMethod));
                throw new System.ArgumentNullException("You have to provide a xml data file with the SLO Config");
            }
            
            //Loading the XML file since we need to resolve the SLOIDs to SLO objects navigating through the XML file. 
            XmlDocument xdoc = new XmlDocument();
            XPathNavigator xmlNavigator;
            xdoc.Load(xmlInput);
            xmlNavigator = LoadTestDataXml(xmlInput);

            string[] actionSloIds = new string[2]; //Add and Remove is going to have only one SLO. Edit is going to receive 2 slos as paramenter.
            SLO[] slos = new SLO[2];
            for (int i = 0; i < sloActionsStruct.Length; i++) //1 slo for ADD and Remove and 2 slos for Edit
            {
                Utilities.LogMessage(currentMethod + 
                    ":: Action to be executed is: " + sloActionsStruct[i].action.ToString());

                #region resolve SLOids to SLO Objects

                for (int j = 0; j < sloActionsStruct[i].slos.Length; j++)
                {
                    Utilities.LogMessage(String.Format(
                        "{0} ::SLO ID associated with action {1} is {2}", currentMethod, 
                        sloActionsStruct[i].action.ToString(), sloActionsStruct[i].slos[j]));

                    actionSloIds[j] = sloActionsStruct[i].slos[j];
                    //For ADD and remove, we need just one SLO, so the second element in the array is going to be null
                    //We don't need to call the GetSloObject method, then. 
                    if (actionSloIds[j] != null)
                    {
                        //Look for the slo in the Dicitionary Member
                        if (slosDictionary.ContainsKey(sloActionsStruct[i].slos[j]) == true)
                        {
                            Utilities.LogMessage(String.Format(
                                "{0}:: The SLO is already in the Dictionary", currentMethod));
                            slos[j] = slosDictionary[sloActionsStruct[i].slos[j]];
                        }
                        else //It doesn't exist in the DIctionary. Call GetSLOObject and then add to dictionary.
                        {
                            Utilities.LogMessage(String.Format(
                                "{0}:: Getting the SLO Object from the XML", currentMethod));
                            slos[j] = GetSLOObject(actionSloIds[j], xmlNavigator);
                            Utilities.LogMessage(String.Format(
                                "{0}:: Add the SLO to the Dictionary.", currentMethod));
                            slosDictionary.Add(sloActionsStruct[i].slos[j], slos[j]);
                        }
                    }

                    Utilities.LogMessage("------------------------SLO INFO from XML ---------------- ");
                    Utilities.LogMessage("Name:" + slos[j].SLOName);
                    Utilities.LogMessage("TargetName:" + slos[j].SLOTargetName);
                    Utilities.LogMessage("Type:" + slos[j].SLOType);
                    Utilities.LogMessage("MonitorId:" + slos[j].MonitorId);
                    Utilities.LogMessage("RuleId:" + slos[j].RuleId);
                    Utilities.LogMessage("Goal:" + slos[j].MonitorGoal);
                    if (slos[j].UndesiredStates != null && slos[j].UndesiredStates.Length > 0)
                    {
                        for (int x = 0; x < slos[j].UndesiredStates.Length; x++)
                        {
                            Utilities.LogMessage("Undesired States:" + slos[j].UndesiredStates[x]);
                        }
                    }
                    Utilities.LogMessage("------------------SLO INFO ----------------------");

                }

                #endregion

                #region SLOActions
                ActionType action = sloActionsStruct[i].action;
                switch (action)
                {
                    case ActionType.Add:
                        this.AddSLO(slos);
                        break;

                    case ActionType.Edit:
                        this.EditSLO(slos);
                    break;

                    case ActionType.Remove:
                        this.RemoveSLO(slos); 
                    break;

                    default:
                    Utilities.LogMessage(currentMethod + ":: Incorrect SLO Action " + action.ToString());
                    throw new InvalidEnumArgumentException(currentMethod + ":: Incorrect SLO Action specified");                   
                }

                #endregion
            }

        }

        /// <summary>
        /// This method is used to load the test data XML and returns 
        /// </summary>
        /// <param name="dataFileName">datafilename.xml</param>
        /// <returns>Retruns and XpathNavigator which will be used during automation</returns>
        /// <remarks> The root element for this data file is TestConfiguration</remarks>
        /// <example>
        /// <TestConfiguration>
        ///     <Var/>
        /// </TestConfiguration>
        /// </example>
        /// <history>
        /// [dialac] 19SEP08 - Created        
        /// </history>
        public static XPathNavigator LoadTestDataXml(string dataFileName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (checked((dataFileName == null) || (dataFileName.Length < 1)))
            {
                Utilities.LogMessage(currentMethod + ":: TestData XML file name was not found.");
                throw new FileNotFoundException(currentMethod + 
                    ":: TestData XML file name was not found - " + dataFileName);
            }
            else
            {
                XPathNavigator testDataNavigator;
                XPathDocument testDataXml = new XPathDocument(@dataFileName);

                Utilities.LogMessage(currentMethod + ":: Creating Navigator into test data XML");
                testDataNavigator = testDataXml.CreateNavigator();

                if (!testDataNavigator.HasChildren || !testDataNavigator.MoveToChild(XPathNodeType.Element))
                {
                    throw new XPathException(string.Format(
                        "{0}: Test data navigator does not contain child Elements in {1}"
                        , currentMethod, dataFileName));
                }

                Utilities.LogMessage(currentMethod + ":: Finished creating Navigator into test data XML");
                return testDataNavigator;
            }
        }

        /// <summary>
        /// Navigate in the array of actions to be executed and call the appropiate action for each elemet. 
        /// </summary>
        /// <param name="sloId">Id of the SLO in the xml that I'm going to use to create a SLO Object</param>
        /// /// <param name="xmlNavigator">XML Path Navigator to the xml data file</param>
        /// <history>
        /// [dialac] 23SEP08 - Created        
        /// </history>
        public SLO GetSLOObject(string sloId, XPathNavigator xmlNavigator)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Checking the input parameters
            if (sloId == null || xmlNavigator.IsEmptyElement == true) 
            {
                Utilities.LogMessage(String.Format("{0}:: SLO Id or xmlNavigator is null."));
                throw new System.ArgumentNullException("SLO Id or xmlNavigator is null.");
            }

            //Initializating the output parameters
            SLO slo = new SLO();

            //Navigating to the right node based on the sloid 
            xmlNavigator = xmlNavigator.SelectSingleNode(String.Format(
                        "//TestConfiguration/Var[@recmval='{0}']", sloId));
            Utilities.LogMessage(String.Format(
                        "{0} ::Starting building the SLO Object whose Id is {1}", currentMethod, sloId));

            if (!xmlNavigator.IsEmptyElement)
            {
                if (xmlNavigator.HasChildren)
                {
                    //At this point we have at least one node in the XML file 
                    Utilities.LogMessage(string.Format(
                        "{0} ::The node for the slo was found in the XML ", currentMethod));

                    #region SLOGeneral Config
                    XPathNodeIterator generalIterator = xmlNavigator.SelectSingleNode("GeneralSLOConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(string.Format(
                        "{0} ::General SLO Config element value: {1}", 
                        currentMethod, generalIterator.Current.InnerXml));

                    if (generalIterator == null)
                    {
                        throw new NullReferenceException("Create: Could not Create Iterator for General Config Elements");
                    }
                    else if (checked(generalIterator.Count < 1))
                    {
                        throw new NullReferenceException(string.Format(
                            "Create: No. of General Config Child Elements cannot be of count: {0} must be greater or equal to 1", 
                            generalIterator.Count));
                    }

                    while (generalIterator.MoveNext())
                    {
                        switch (generalIterator.Current.Name)
                        {
                            case "SLOType":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Type specified in xml is: {1}", currentMethod, 
                                    generalIterator.Current.Value));
                                switch (generalIterator.Current.Value.ToLowerInvariant())
                                {
                                    case "monitorstateslo":
                                        slo.SLOType = SLOType.MonitorState;
                                        break;
                                    case "collectionruleslo":
                                        slo.SLOType = SLOType.CollectionRule;
                                        break;
                                    default:
                                        throw new InvalidEnumArgumentException("Invalid Value for SloType");
                                }
                                Utilities.LogMessage(String.Format(
                                    "{0}:: Successfully set the Type of SLO to: {1}", currentMethod, slo.SLOType));
                                break;

                            case "DisplayName":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO DisplayName specified in xml is: {1}", currentMethod, 
                                    generalIterator.Current.Value));
                                switch (generalIterator.Current.Value.ToLowerInvariant())
                                {
                                    case "random":

                                        string displayName = randomNames.CreateRandomString(minNameLength, maxNameLength, excludedCharacters);
                                        Utilities.LogMessage(String.Format("{0}:: RandomString for Name = {1}", currentMethod, displayName));
                                        Utilities.LogMessage(String.Format("{0}:: Name length : {1}", currentMethod, displayName.Length));
                                        slo.SLOName = displayName;
                                        break;

                                    default:
                                        //if user specifies any value other than random use that value as name
                                        slo.SLOName = generalIterator.Current.Value;
                                        break;
                                }
                                Utilities.LogMessage(String.Format(
                                    "{0}:: Successfully set the Name to: {1}", currentMethod, slo.SLOName));
                                break;

                            case "TargetType":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Target Type specified in xml is: {1}", currentMethod, 
                                    generalIterator.Current.Value));
                                string targetType = null;
                                targetType = generalIterator.Current.Value;
                                if (null != targetType)
                                {
                                    switch (generalIterator.Current.Value.ToLowerInvariant())
                                    {
                                        case "distapp":
                                        case "distributtedapplication":
                                            slo.SLOTargetType = SLATargetClassType.DistApp;
                                            break;
                                        case "group":
                                            slo.SLOTargetType = SLATargetClassType.Group;
                                            break;
                                        case "class":
                                            slo.SLOTargetType = SLATargetClassType.Class;
                                            break;
                                    }
                                    Utilities.LogMessage(String.Format(
                                        "{0}:: Successfully set the Target Type of SLO to: {1}", currentMethod, 
                                        slo.SLOTargetType));
                                }
                                break;

                            case "TargetName":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Target Name specified in xml is: {1}", currentMethod, 
                                    generalIterator.Current.Value));
                                string selectedTarget = null;
                                selectedTarget = generalIterator.Current.Value;
                                if (null != selectedTarget)
                                {
                                    slo.SLOTargetName = selectedTarget;
                                    Utilities.LogMessage(String.Format(
                                        "{0}:: Successfully set the Target Name of SLO to: {1}", currentMethod, 
                                        slo.SLOTargetName));
                                }
                                break;
                            default:
                                Utilities.LogMessage(String.Format(
                                    "{0}:: General Config Element specified in xml is: '{1}' is invalid", currentMethod, 
                                    generalIterator.Current.Name));
                                throw new InvalidEnumArgumentException("Invalid Element selected");
                        }
                    }

                    #endregion

                    #region MonitorSLO Config
                    XPathNodeIterator monitorIterator = xmlNavigator.SelectSingleNode("MonitorSLOConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(string.Format(
                        "{0} ::Monitor SLO Config element value: {1}", currentMethod, 
                        monitorIterator.Current.InnerXml));

                    if (monitorIterator == null)
                    {
                        throw new NullReferenceException("Create: Could not Create Iterator for Monitor Config Elements");
                    }
                    else if (checked(monitorIterator.Count < 1))
                    {
                        throw new NullReferenceException(string.Format(
                            "Create: No. of Monitor Config Child Elements cannot be of count: {0} must be " 
                                    + " greater or equal to 1", monitorIterator.Count));
                    }

                    while (monitorIterator.MoveNext())
                    {
                        switch (monitorIterator.Current.Name)
                        {
                            case "MonitorId":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Monitor ID specified in xml is: {1}", currentMethod, 
                                    monitorIterator.Current.Value));
                                string monitorId = null;
                                monitorId = monitorIterator.Current.Value;
                                if (null != monitorId)
                                {
                                    slo.MonitorId = monitorId;
                                    Utilities.LogMessage(String.Format(
                                        "{0}:: Successfully set the MonitorID of SLO to: {1}", currentMethod, slo.MonitorId));
                                }
                                break;
                            case "Goal":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Goal specified in xml is: {1}", currentMethod, 
                                    monitorIterator.Current.Value));
                                string goalSTR = monitorIterator.Current.Value;
                                if (null != goalSTR && goalSTR != string.Empty)
                                {
                                    slo.MonitorGoal = goalSTR;
                                    Utilities.LogMessage(String.Format(
                                        "{0}:: Successfully set the Goal of SLO to: {1}", currentMethod, 
                                        slo.MonitorGoal));
                                }
                                break;
                            case "UndesiredStates":
                                XPathNodeIterator stateIterator = monitorIterator.Current.SelectChildren(XPathNodeType.Element);
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Undesired States specified in xml is: {1}", currentMethod, 
                                    stateIterator.Current.InnerXml));

                                if (stateIterator != null && (stateIterator.Count > 0))
                                {
                                    int i  = 0;
                                    slo.UndesiredStates = new string[stateIterator.Count];
                                    while (stateIterator.MoveNext())
                                    {
                                        if (stateIterator.Current.Name.ToLowerInvariant() == "state")
                                        {
                                            Utilities.LogMessage(String.Format(
                                                "{0}:: The SLO State is: {1}", currentMethod, 
                                                stateIterator.Current.Value));
                                            slo.UndesiredStates[i] = stateIterator.Current.Value;
                                            i++;
                                        }
                                        else
                                        {
                                            Utilities.LogMessage(String.Format(
                                                "{0}:: Invalid Undesired State tag in the xml file"));
                                            throw new InvalidEnumArgumentException("Invalid Undesired State tag in the xml ");
                                        }
                                    } //end of while
                                } //end of "if" for undesiredStates
                                break;
                        }//end of switch
                    }//end of the monitorIterator 

                    #endregion

                    #region PerformanceCOunterSLO Config
                    XPathNodeIterator ruleIterator = xmlNavigator.SelectSingleNode("PerformanceCounterSLOConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(string.Format(
                        "{0} ::Collection Rule SLO Config element value: {1}", currentMethod, 
                         ruleIterator.Current.InnerXml));

                    if (ruleIterator == null)
                    {
                        throw new NullReferenceException(
                            "Create: Could not Create Iterator for Collection Rule Config Elements");
                    }
                    else if (checked(ruleIterator.Count < 1))
                    {
                        throw new NullReferenceException(string.Format(
                            "Create: No. of Collection Rule Config Child Elements cannot be of count: "
                                    + "{0} must be greater or equal to 1", 
                                    ruleIterator.Count));
                    }

                    while (ruleIterator.MoveNext())
                    {
                        switch (ruleIterator.Current.Name)
                        {
                            case "RuleId":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Rule ID specified in xml is: {1}", currentMethod, 
                                    ruleIterator.Current.Value));
                                string ruleId = null;
                                ruleId = ruleIterator.Current.Value;
                                if (null != ruleId)
                                {
                                    slo.RuleId = ruleId;
                                    Utilities.LogMessage(String.Format(
                                        "{0}:: Successfully set the RuleID of SLO to: {1}", currentMethod, 
                                        slo.RuleId));
                                }
                                break;

                            case "PerfCounterAggregationMethod":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Aggregation specified in xml is: {1}", currentMethod, 
                                    ruleIterator.Current.Value));
                                switch (ruleIterator.Current.Value.ToLowerInvariant())
                                {
                                    case "average":
                                        slo.AggregationMethod = AgregationMethod.Average;
                                        break;
                                    case "max":
                                        slo.AggregationMethod = AgregationMethod.Max;
                                        break;
                                    case "min":
                                        slo.AggregationMethod = AgregationMethod.Min;
                                        break;
                                    default:
                                        Utilities.LogMessage(currentMethod + "::No aggregation method was read to the SLO");
                                        break;
                                }
                                Utilities.LogMessage(String.Format
                                    ("{0}:: Successfully set the Aggreagation of SLO to: {1}", currentMethod, 
                                    slo.AggregationMethod));
                                break;

                            case "Threshold":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO Threshold specified in xml is: {1}", currentMethod, 
                                    ruleIterator.Current.Value));
                                string thresholdSTR = ruleIterator.Current.Value;
                                if (null != thresholdSTR && thresholdSTR != string.Empty)
                                {
                                    slo.Threshold = thresholdSTR;
                                    Utilities.LogMessage(String.Format(
                                        "{0}:: Successfully set the Threshold of SLO to: {1}", currentMethod, 
                                        slo.Threshold));
                                }
                                break;

                            case "DesiredObjective":
                                Utilities.LogMessage(String.Format(
                                    "{0}:: SLO DesiredObjective specified in xml is: {1}", currentMethod, 
                                    ruleIterator.Current.Value));
                                string desiredObjective = null;
                                desiredObjective = ruleIterator.Current.Value;
                                if (null != desiredObjective)
                                {
                                    slo.DesiredObjective = desiredObjective;
                                    Utilities.LogMessage(String.Format(
                                        "{0}:: Successfully set the DesiredObjective of SLO to: {1}", 
                                        currentMethod, 
                                        slo.DesiredObjective));
                                }
                                break;
                        }//end of switch
                    }//end of the ruleIterator 

                    #endregion

                }
                else // The xmlNavigatior has no child
                {
                    throw new NullReferenceException ("XmlElement passed as input had no Child Elements, no methods were execute");
                }
            }
            else // the xmlnavigator is empty
            {
                throw new NullReferenceException ("Xmlelement passed as input is Empty no methods execute");
            }

            return slo;
            
        }

        /// <summary>
        /// Try to find and select a SLA in the SlaView. Return false if the sla is not found in the view. 
        /// </summary>
        /// <param name="slaName">SLA Name to be found/selected</param> 
        /// <history>
        /// [dialac] 30SEP08 - Created        
        /// </history>
        public bool FindSLAEntryView(string slaName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");
            string AuthoringPath = NavigationPane.Strings.Authoring;
            //WA: Service Level Tracking Node
            string SLAPath = NavigationPane.Strings.Authoring
                        + Constants.PathDelimiter
                        + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                        + Constants.PathDelimiter
                        //+ UserRole.UserRoles.Strings.ServiceLevelTracking;
                        + NavigationPane.Strings.MonConfigTreeViewServiceLevelTracking;

            //Initializing the output parameter
            bool foundSla = false;

            //Checking the input parameters
            if (slaName == null || slaName == String.Empty)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the SLA Name user passed is null/Empty.", currentMethod));
                throw new System.ArgumentNullException("SLA NAme user passed to be found is null/Empty");
            }

            CoreManager.MomConsole.BringToForeground();

            // Select the Monitoring Configuration wunderbar
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            // Select Service Level Tracking view
            Utilities.LogMessage(String.Format(
                "{0}:: Selecting the SLA Node under Monitoring. ", currentMethod));
            navPane.SelectNode(SLAPath, NavigationPane.NavigationTreeView.Authoring);

            //Getting the reference to the SLA View to verify the View Title. 
            ViewPane slaView = CoreManager.MomConsole.ViewPane;
            Utilities.LogMessage(String.Format("{0}:: The SLAVIew title is: {1} ", currentMethod, slaView.Title));
            //if (slaView.Title != Strings.SLAView)
            if (!slaView.Title.Contains(Strings.SLAView))
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: SLA View name is incorrect. Current: {1}. Expected: {2}", 
                    currentMethod, slaView.Title, Strings.SLAView));
                throw new Maui.GlobalExceptions.MauiException("SLA View name is not correct");
            }

            CoreManager.MomConsole.ViewPane.Find.LookForItem(slaName);
            var rows = CoreManager.MomConsole.ViewPane.Grid.Rows.Where(r => r.AccessibleObject.Index > 0 &&
                                                                       r.Cells[0].GetValue().ToLowerInvariant() == slaName.ToLowerInvariant());

            if (rows == null || rows.Count() == 0)
            {
                foundSla = false;
            }
            else
            {
                foundSla = true;
                rows.First().Click();
            }

            return foundSla;

        }
        
        /// <summary>
        /// Verify if the list of SLOs we have is correct after all the actions performanced during the wizard.  
        /// </summary>
        /// <param name="expectedSlosList">Expected list of slos within the SLA</param>
        /// <history>
        /// [dialac] 23SEP08 - Created        
        /// </history>
        public void VerifyListSlos(string[] expectedSlosList)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            // Since we can't have an EMPTY SLA, we always expected at least one SLO within the SLA. 
            if (expectedSlosList == null || expectedSlosList.Length == 0)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The list of expected slos is empty and the SLA should have at least one SLO.", 
                    currentMethod));
                throw new System.ArgumentNullException("The list of expected slos is empty and the SLA should have at least one SLO");
            }


            ListView slosList = this.SLASLOsDialog.Controls.SLOListView;
            if (slosList == null || slosList.Count == 0)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The list of slos in the UI is empty. Empty SLA Is not supported.", currentMethod));
                throw new System.ArgumentNullException("The list of slos in the UI is empty. Empty SLA Is not supported.");
            }

            //Getting a reference to the List view in the SLO page of the Wizard 
            if (expectedSlosList.Length != slosList.Count)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The number of expected slos is different from the number of slos found in the wizard. Found: {1}; Expected: {2}", 
                    currentMethod, slosList.Count, expectedSlosList.Length));
                throw new Maui.GlobalExceptions.MauiException("The number of expected slos is different from the number of slos found in the wizard.");
            }
            
            SLO expSlo = null; 

            for (int j = 0; j < expectedSlosList.Length; j++)
            {
                //Retrieving the SLO name from the DIctionary; passing the ID, I get the SLO Object.
                if (slosDictionary.ContainsKey(expectedSlosList[j]) == true)
                {
                    expSlo = slosDictionary[expectedSlosList[j]]; //Get the SLO object to access the SLO name
                    if (slosList.Exists(expSlo.SLOName) == true)
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: SLO found. ID: {1}, Name: {2}", currentMethod, 
                            expectedSlosList[j], expSlo.SLOName));
                    }
                    else
                    {
                        Utilities.LogMessage(String.Format(
                            "{0}:: SLO NOT found. ID: {1}, Name: {2}", currentMethod, 
                            expectedSlosList[j], expSlo.SLOName));
                        throw new Maui.GlobalExceptions.MauiException(String.Format(
                            "SLO '{0}' not found in the slo list", expSlo.SLOName));
                    }
                }
                else 
                {
                    Utilities.LogMessage(String.Format(
                        "{0}:: SLO '{1}' NOT found in the Dictionary. Can't not get the name of SLO to look for it in the UI.", 
                        currentMethod, expectedSlosList[j]));
                    throw new Maui.GlobalExceptions.AssertionFailedException("SLO not found in the dictionary. Can't not get the slo name to look for it in the UI");
                }

            } //End of FOR Loop. 

        }
        
        /// <summary>
        /// Navigate to the Select Scope Page 
        /// </summary>
        /// <param name="scopeName">Name of scope to look for and select</param>
        /// <history>
        /// [dialac] 04OCT08 - Created        
        /// </history>
        public void NavigateSelectScope(string scopeName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (scopeName == null || scopeName == String.Empty)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: scope to look for can not be empty", currentMethod));
                throw new System.ArgumentNullException("scope to look for can not be empty");
            }

            //Setting the "Look for" field in the new Dialog. 
            this.SelectScopeDialog.LookForText = scopeName;
            this.SelectScopeDialog.ClickSearch();
            //TODO - Dialac - Remove this. 
            Sleeper.Delay(5000);

            ListView result = null;
            bool foundScope = false;

            int maxRetry = 5; 
            for (int i = 0; i < maxRetry; i++)
            {
                result = this.SelectScopeDialog.Controls.ListView1;
                foreach (ListViewItem item in result.Items)
                {
                    if (item.Text.ToLowerInvariant() == scopeName.ToLowerInvariant())
                    {
                        foundScope = true;
                        Utilities.LogMessage(String.Format("{0}:: Scope was found!", currentMethod));
                        item.Select();
                        break;
                    }
                }
                if (foundScope == true)
                {
                    break;
                }
                Sleeper.Delay(2000); //2 seconds sleep.
            }
            if (foundScope == false)
            {
                Utilities.LogMessage(String.Format("{0}:: Scope was not found", currentMethod));
                this.SelectScopeDialog.ClickCancel();
                throw new ListView.Exceptions.ItemNotFoundException((String.Format("{0}:: Scope '{1}' not found.", currentMethod, scopeName)));
            }

            this.SelectScopeDialog.ClickOK();
            this.cachedSelectanObjectDialog = null;
        }

        /// <summary>
        /// Once in the SLO page, Navigate to the Name field
        /// </summary>
        /// <param name="sloName">Name of Slo to be set/verified</param>
        /// <param name="sloType">Type of SLO: Monitor or Collection Rule.</param>
        /// <history>
        /// [dialac] 04OCT08 - Created        
        /// </history>
        public void NavigateSLONameField(string sloName, SLOType sloType)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");
            
            Utilities.LogMessage(String.Format(
                       "{0}:: The slo name to be assigned is: {1}", currentMethod, sloName));

            string currentName = null;
            if (sloType == SLOType.MonitorState)
            {
                CoreManager.MomConsole.WaitForForegroundDialog(this.MonitorStateSLODialog, 15);
                currentName = this.MonitorStateSLODialog.ServiceLevelObjectiveNameText;
            }
            else
            {
                CoreManager.MomConsole.WaitForForegroundDialog(this.CollectionRuleSLODialog, 15);
                currentName = this.CollectionRuleSLODialog.ServiceLevelObjectiveNameText;
            }
            //If the Textbox is null, means that you are Adding a slo (not editing) 
            //Because of that, SLOName can't be null or empty. 
            if (currentName == null || currentName == String.Empty) //You are in this dialog because you are adding a SLO
            {
                if (sloName == null || sloName == string.Empty)
                {
                    Utilities.LogMessage(String.Format(
                            "{0}:: The Name of SLO can not be null", currentMethod));
                    throw new NullReferenceException("The Name of SLO can not be null");
                }
                if (sloType == SLOType.MonitorState)
                {
                    this.MonitorStateSLODialog.ServiceLevelObjectiveNameText = sloName;
                }
                else
                {
                    this.CollectionRuleSLODialog.ServiceLevelObjectiveNameText = sloName;
                }
            }
            else // You are editing a SLO 
            {
                if (sloName != null && sloName != string.Empty) // In this case you are updating the name of the SLO
                {
                    if (sloType == SLOType.MonitorState)
                    {
                        this.MonitorStateSLODialog.ServiceLevelObjectiveNameText = sloName;
                    }
                    else
                    {
                        this.CollectionRuleSLODialog.ServiceLevelObjectiveNameText = sloName;
                    }
                }
            } //ENd of else where you are editing. 

        } //ENd of Function

        /// <summary>
        /// Once in the SLO page, Navigate to the Target field
        /// </summary>
        /// <param name="sloTarget">Target of Slo to be set/verified</param>
        /// <param name="sloType">Type of SLO: Monitor or Collection Rule.</param>
        /// <history>
        /// [dialac] 04OCT08 - Created        
        /// </history>
        public void NavigateSLOTargetField(string sloTarget, SLOType sloType)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Setting the Target Class 
            Utilities.LogMessage(String.Format(
                         "{0}:: The slo target to be assigned is: {1}",
                         currentMethod, sloTarget));

            //If it's null, then we should leave as the default (same as SLA Target)
            if (null != sloTarget && sloTarget != string.Empty)
            {
                //Click on Select Button to select the Target. 
                if (sloType == SLOType.MonitorState)
                {
                    this.MonitorStateSLODialog.ClickSelect();
                    this.cachedServiceLevelObjectiveMonitorStateDialog = null;
                }
                else
                {
                    this.CollectionRuleSLODialog.ClickSelectClass();
                    this.cachedSServiceLevelObjectiveCollectionRuleDialog = null;
                }

                this.SLOSelectTargetDialog.ServiceLevelObjectiveNameText = sloTarget;

                //Selecting the Target from the result list (should have only one in the result)
                bool targetFound = this.IsItemFoundListViewResult(this.SLOSelectTargetDialog.Controls.TargetListView,
                                                sloTarget);

           
                //Checking to see if the target was found
                if (targetFound == false)
                {
                    Utilities.LogMessage(String.Format(
                                "{0}:: The SLO Target '{1}' was not found in the result list", currentMethod, sloTarget));
                    //Closing the dialog 
                    this.SLOSelectTargetDialog.ClickCancel();
                    throw new ListView.Exceptions.ItemNotFoundException(
                                              "SLO Target specified not found in the result list");
                }

                //TODO - Verify if the OKButton is enable
                this.SLOSelectTargetDialog.ClickOK();
                this.cachedSLOSelectaTargetTypeDialog = null;

            } //END of If - Leave as Default. 

        }

        /// <summary>
        /// Getting the localized name for the target of SLASLO
        /// </summary>
        /// <param name="target">Target of slaslo as in the varmap</param>
        /// <history>
        /// [dialac] 7APR09 - Created        
        /// </history>
        public string GetResourceStringTarget(string target)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            string resourceTarget = null;

            //Setting the Target Class 
            Utilities.LogMessage(String.Format(
                         "{0}:: The target to be used is: {1}",
                         currentMethod, target));


            //If it's null, then we should leave as the default (same as SLA Target)
            if (null != target && target != string.Empty)
            {
                

                switch (target.ToLowerInvariant())
                {
                    case "agent":
                        resourceTarget = Utilities.GetEntityName(SystemMonitoringClass.Agent);
                        break;

                    case "computer":
                        resourceTarget = Utilities.GetEntityName(SystemMonitoringClass.Computer);
                        break;
                    case "windows computer":
                    case "windowscomputer":
                        resourceTarget = Utilities.GetEntityName(SystemMonitoringClass.WindowsComputer);
                        break;
                    case "distributed application":
                        resourceTarget = Utilities.GetEntityName(SystemMonitoringClass.Service);
                        break;
                    default: //In case it's coming from the UI test MP, so we don't need the Resouce String
                        resourceTarget = target;
                        break;

                }
                Utilities.LogMessage(String.Format(
                   "{0}:: The resourse string for the target is: {1}",
                   currentMethod, resourceTarget));

            }
            else
            {
                throw new Maui.GlobalExceptions.MauiException(String.Format(
                        "Target for SLASLO can not be null or empty."));
            }

            return resourceTarget;

        }

        /// <summary>
        /// Getting Rule Name  
        /// </summary>
        /// <param name="rule">Rule ID to get the resource string </param>
        /// <history>
        /// [dialac] 10APR09 - Created        
        /// </history>
        public string GetRuleName(string rule)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            string resourceStringRule = null;

            Utilities.LogMessage(String.Format(
                         "{0}:: The original rule id is: {1}", currentMethod, rule));

            if (rule.Contains("Collect Process") && rule.Contains("% Processor Time"))
            {
                 resourceStringRule = Strings.CollectPercentProcessorTimeRuleName;
            }
            else
            {
                resourceStringRule = rule;
            }


            //switch (rule.ToLowerInvariant())
            //{
            //    case @"Collect Process\% Processor Time":
            //        resourceStringRule = Strings.CollectPercentProcessorTimeRuleName;
            //        break;
            //    default:
            //        resourceStringRule = rule;
            //        break;

            //}

            Utilities.LogMessage(String.Format(
               "{0}:: The resourse string for the rule is: {1}",
               currentMethod, resourceStringRule));

            return resourceStringRule;

        }

        /// <summary>
        /// Parse each of the SLOAction breaking into Action and SLOS to be handle by the action 
        /// into the SLOActionStruct.
        /// Example: User passes Edit(1,3) in the varmap. The method is goint to return a Struct like: 
        /// SLOAction.action = Edit; SLOAction.slo[0] = "1"; SLOAction.slo[1] = "2"
        /// This method uses Regular Expression to match the string format. 
        /// </summary>
        /// <param name="actionsStr">The original Array with Action+SLOIds in one single string like: Edit(1,3)</param>
        public SLOAction[] ParseSLO(string[] actionsStr)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Pattern is: Method ( param1, param2 )
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w+)\s*\(\s*(\w+)(,\s*(\w+))?\s*\)");

            //Creating Results based on the # of actions passed in the varmap. 
            SLOAction[] results = new SLOAction[actionsStr.Length];

            if (actionsStr == null || actionsStr.Length == 0)
            {
                Utilities.LogMessage(currentMethod +
                                    "SLA can not be empty. User has to provide at least one ADD action");
                throw new System.ArgumentException(string.Format(
                    "Failed to get variation parameters from varmap records!"));
            }

            //Getting the matches and groups from the RegExp class for each action
            for (int i = 0; i < actionsStr.Length; i++)
            {
                string method = null;
                string param1 = null;
                string param2 = null;

                System.Text.RegularExpressions.Match match = regex.Match(actionsStr[i]);
                if (match.Success == false)
                {
                    Utilities.LogMessage(currentMethod +
                                       "The actions passed in the varmap are not in a correct Format. " +
                                       "Action passed: " + actionsStr[i]);
                    throw new System.ArgumentException(
                        "The actions passed in the varmap are not in a correct Format"); ;
                }

                //Group[0] = is always the entire pattern.
                //method = m.Groups[1].Captures[0].Value;
                method = match.Groups[1].Value;
                param1 = match.Groups[2].Value;
                //Group[3] is the optional second slo (in case of Edit) with the comman.
                //Example: Edit (1,3) => Group[3].Value is ",3". I neve need the Group[3].
                //Group[4] is going to bring the "3" for Edit Actions. 
                if (match.Groups[4].Length > 0)
                {
                    param2 = match.Groups[4].Value;
                }

                Utilities.LogMessage(currentMethod +
                                "RegExpress result for Method is: " + method);
                Utilities.LogMessage(currentMethod +
                                "RegExpress result for first SLO is: " + param1);
                Utilities.LogMessage(currentMethod +
                                "RegExpress result for second SLO is: " + param2);

                results[i] = new SLASLO.SLOAction();
                switch (method.ToLowerInvariant())
                {
                    case "add":
                        results[i].action = SLASLO.ActionType.Add;
                        break;
                    case "edit":
                        results[i].action = SLASLO.ActionType.Edit;
                        break;
                    case "remove":
                        results[i].action = SLASLO.ActionType.Remove;
                        break;

                    default:
                        throw new System.ArgumentException("Invalid slo action: " + method);
                }

                if (param2 == null)
                {
                    results[i].slos = new string[] { param1 };
                }
                else //Edit action. I need 2 SLOs: The original and the new SLO.
                {
                    results[i].slos = new string[] { param1, param2 };
                }

            }

            return results;

        }
        #endregion

        #region SLAParameters Class
        /// <summary>
        /// Parameters class for SLA constructors.
        /// </summary>
        /// <history>
        /// [dialac] 12SEP08 Created
        /// </history>
        public class SLAParameters
        {
            #region Private Members

            private string cachedSLAName = null;
            private string cachedSLADescription = null;
            private SLATargetClassType cachedSLATargetType = SLATargetClassType.DistApp;
            private string cachedSLATargetName = null;
            private SLAScopeType cachedSLAScopeType = SLAScopeType.AllObjects;
            private string cachedSLAScope = null; 
            private string cachedSLADestinationMP = null;
            //private string[] cachedSLOActions = null;
            private SLOAction[] cachedSLOActionsStruct = null;
            private bool cachedisSLATargetSingleton = false;
            //private string[] cachedSLOAdd = null;

            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public SLAParameters()
            {
            }
            #endregion

            #region Properties
            
            /// <summary>
            /// Display Name of SLA
            /// </summary>
            public string SLAName
            {
                get
                {
                    return this.cachedSLAName;
                }

                set
                {
                    this.cachedSLAName = value;
                }
            }

            /// <summary>
            /// Description for SLA
            /// </summary>
            public string SLADescription
            {
                get
                {
                    return this.cachedSLADescription;
                }

                set
                {
                    this.cachedSLADescription = value;
                }
            }

            /// <summary>
            /// SLA Target Type: Distributed Application, Group or Instance.
            /// </summary>
            public SLATargetClassType SLATargetType
            {
                get
                {
                    return this.cachedSLATargetType;
                }

                set
                {
                    this.cachedSLATargetType = value;
                }
            }

            /// <summary>
            /// SLA Target. The DistAppl, Group or instance name to look for. 
            /// </summary>
            public string SLATargetName
            {
                get
                {
                    return this.cachedSLATargetName;
                }

                set
                {
                    this.cachedSLATargetName = value;
                }
            }

            /// <summary>
            /// SLA Scope Type: AllObjects, Group or Instance.
            /// </summary>
            public SLAScopeType SLAScopeType
            {
                get
                {
                    return this.cachedSLAScopeType;
                }

                set
                {
                    this.cachedSLAScopeType = value;
                }
            }
           
            
            /// <summary>
            /// Scope of SLA: Name of the group or object to scope if this was the scope type selection
            /// </summary>
            public string SLAScope
            {
                get
                {
                    return this.cachedSLAScope;
                }

                set
                {
                    this.cachedSLAScope = value;
                }
            }

            /// <summary>
            /// Destination MP for SLA
            /// </summary>
            public string SLADestinationMP
            {
                get
                {
                    return this.cachedSLADestinationMP;
                }

                set
                {
                    this.cachedSLADestinationMP = value;
                }
            }

            /// <summary>
            /// array of struct that contains info about the actions (Add, Edit, remove) and SLOIDs
            /// </summary>
            public SLOAction[] SLOActionsStruct
            {
                get
                {
                    return this.cachedSLOActionsStruct;
                }

                set
                {
                    this.cachedSLOActionsStruct = value;
                }
            }

            /// <summary>
            /// True if the SLATarget is singleton Class 
            /// </summary>
            public bool IsSLATargetSingleton
            {
                get
                {
                    return this.cachedisSLATargetSingleton;
                }

                set
                {
                    this.cachedisSLATargetSingleton = value;
                }
            }

            ///// <summary>
            ///// List of SLO id to be added
            ///// </summary>
            //public string[] SLOAdd
            //{
            //    get
            //    {
            //        return this.cachedSLOAdd;
            //    }

            //    set
            //    {
            //        this.cachedSLOAdd = value;
            //    }
            //}

            #endregion
        }

        #endregion

        #region SLO Class
        /// <summary>
        /// Class that represents a SLO
        /// </summary>
        /// <history>
        /// [dialac] 23SEP08 Created
        /// </history>
        public class SLO
        {
            #region Private Members

            private string cachedSLOId = null;
            private string cachedSLOName = null;
            private SLOType cachedSLOType = SLOType.MonitorState;
            private SLATargetClassType cachedSLOTargetClass = SLATargetClassType.DistApp;
            private string cachedSLOTargetName = null;
            private string cachedMonitorId = null;
            private string cachedMonitorGoal = null;
            private string[] cachedUndesiredStates = null;
            private string cachedRuleId = null;
            private AgregationMethod cachedPerfCounterAggregationMethod = AgregationMethod.Average;
            private string cachedPerfCounterThreshold = null;
            private string cachedPerfCounterDesiredObjective = null;

            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public SLO()
            {
            }
            #endregion

            #region Properties


            /// <summary>
            /// ID of SLO based on the XML File. We'll use this ID when Editing and Delete SLO within the Wizard. 
            /// </summary>
            public string SLOID
            {
                get
                {
                    return this.cachedSLOId;
                }

                set
                {
                    this.cachedSLOId = value;
                }
            }

            
            /// <summary>
            /// Display Name of SLO
            /// </summary>
            public string SLOName
            {
                get
                {
                    return this.cachedSLOName;
                }

                set
                {
                    this.cachedSLOName = value;
                }
            }

         
            /// <summary>
            /// SLO Type: State Monitor or Collection Rule
            /// </summary>
            public SLOType SLOType
            {
                get
                {
                    return this.cachedSLOType;
                }

                set
                {
                    this.cachedSLOType = value;
                }
            }
            
            /// <summary>
            /// SLO Target Type: Distributed Application, Group or Instance.
            /// </summary>
            public SLATargetClassType SLOTargetType
            {
                get
                {
                    return this.cachedSLOTargetClass;
                }

                set
                {
                    this.cachedSLOTargetClass = value;
                }
            }

            /// <summary>
            /// SLO Target. The DistAppl, Group or instance name to look for. 
            /// </summary>
            public string SLOTargetName
            {
                get
                {
                    return this.cachedSLOTargetName;
                }

                set
                {
                    this.cachedSLOTargetName = value;
                }
            }

            /// <summary>
            /// Monitor Name for the State Monitor SLO
            /// </summary>
            public string MonitorId
            {
                get
                {
                    return this.cachedMonitorId;
                }

                set
                {
                    this.cachedMonitorId = value;
                }
            }
            
            /// <summary>
            /// Monitor Goal
            /// </summary>
            public string MonitorGoal
            {
                get
                {
                    return this.cachedMonitorGoal;
                }

                set
                {
                    this.cachedMonitorGoal = value;
                }
            }

            /// <summary>
            /// List of UndesideredStates
            /// </summary>
            public string[] UndesiredStates
            {
                get
                {
                    return this.cachedUndesiredStates;
                }

                set
                {
                    this.cachedUndesiredStates = value;
                }
            }

            /// <summary>
            /// Rule Name for the Collection Rule SLO Type
            /// </summary>
            public string RuleId
            {
                get
                {
                    return this.cachedRuleId;
                }

                set
                {
                    this.cachedRuleId = value;
                }
            }

            /// <summary>
            /// Aggregation Method: Average, max or min
            /// </summary>
            public AgregationMethod AggregationMethod
            {
                get
                {
                    return this.cachedPerfCounterAggregationMethod;
                }

                set
                {
                    this.cachedPerfCounterAggregationMethod = value;
                }
            }

            /// <summary>
            /// Threshold of the Performance Counter
            /// </summary>
            public string Threshold
            {
                get
                {
                    return this.cachedPerfCounterThreshold;
                }

                set
                {
                    this.cachedPerfCounterThreshold = value;
                }
            }

            /// <summary>
            /// Desired Objective
            /// </summary>
            public string DesiredObjective
            {
                get
                {
                    return this.cachedPerfCounterDesiredObjective;
                }

                set
                {
                    this.cachedPerfCounterDesiredObjective = value;
                }
            }

            #endregion
        }

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for SLASLO
        /// </summary>
        /// <history> 	
        ///   [dialac]  16SEP08: Added resource strings for SLA and SLO
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
            private const string ResourceDialogTitle = @";Service Level Tracking;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateSlaWizard";

            /// <summary>
            /// Contains resource string for the Delete SLA Confirmation dialog title.
            /// </summary>
            private const string ResourceConfirmSLADeleteTitle = @";Confirm Service Level Tracking Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.SlaView.SlaViewResources;ConfirmSlaDelete";

            /// <summary>
            /// Service Level Tracking view node resource string
            /// </summary>
            private const string ResourceSLAView = @";Service Level Tracking;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.SlaView;ViewName";

            /// <summary>
            /// SLA actions pane group resource string.
            /// </summary>
            private const string ResourceActionsSLA = @";Service Level Tracking;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.SlaView.SlaViewResources;SlaTaskGroup";

            /// <summary>
            /// SLA Create action in the Action pane resource string.
            /// </summary>
            private const string ResourceActionCreateSLA = @";&Create;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.SlaView.SlaViewResources;CreateSlaTask";

            /// <summary>
            /// SLA Properties action in the Action pane resource string.
            /// </summary>
            private const string ResourceActionPropertiesSLA = @";Propert&ies;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;PropertiesMenuText";

            /// <summary>
            /// SLA Delete action in the Action pane resource string.
            /// </summary>
            private const string ResourceActionDeleteSLA = @";&Delete;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;DeleteMenuText";

            /// <summary>
            /// Distributed Application Filter resource string.
            /// </summary>
            private const string ResourceDistAppFilter = @";Distributed Application;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaTargetSubControl;searchFilterComboBox.Items";

            /// <summary>
            /// Group Filter otpion resource string.
            /// </summary>
            private const string ResourceGroupFilter = @";Group;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaTargetSubControl;searchFilterComboBox.Items1";

            /// <summary>
            /// All Filter option resource string.
            /// </summary>
            private const string ResourceAllFilter = @";All;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaTargetSubControl;searchFilterComboBox.Items2";

            /// <summary>
            /// Add action tool bar for SLO - Resource String
            /// </summary>
            private const string ResourceAddToolBarItem = @";&Add;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SloListPage;addSloButton.Text";

            /// <summary>
            /// Edit action tool bar for SLO - Resource String
            /// </summary>
            private const string ResourceEditToolBarItem = @";&Edit;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SloListPage;editSloButton.Text";
                
            /// <summary>
            /// Remove action tool bar for SLO - Resource String
            /// </summary>
            private const string ResourceRemoveToolBarItem = @";&Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SloListPage;removeSloButton.Text";
            
            /// <summary>
            /// MonitorStateSLO menu item - Resource String
            /// </summary>
            private const string ResourceMonitorStateSLOMenuItem = @";Monitor state SLO;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SloListPage;avaiToolStripMenuItem.Text";

            /// <summary>
            /// Collection Rule SLO menu item - Resource String
            /// </summary>
            private const string ResourceCollRuleSLOMenuItem = @";Collection rule SLO;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SloListPage;performanceRuleSLOToolStripMenuItem.Text";

            /// <summary>
            /// Less Than Desired Objective - Resource String
            /// </summary>
            private const string ResourceLessThanDesiredObjective = @";Less Than;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaPageResources;PerformanceSloDesiredObjectiveUnderThreshold";

            /// <summary>
            /// Less Than Desired Objective - Resource String
            /// </summary>
            private const string ResourceMoreThanDesiredObjective = @";More Than;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaPageResources;PerformanceSloDesiredObjectiveOverThreshold";

            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.NTService.CollectPercentProcessorTime
            /// </summary>            
            private static Guid CollectPercentProcessorTimeRuleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.CollectPercentProcessorTimeRuleName);


            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.NTService.CollectPercentProcessorTime
            /// </summary>            
            private static Guid OwnProcessNTServiceGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.OwnProcessNTServiceName);


            ///// <summary>
            ///// Create a new rule link resource string
            ///// </summary>
            //private const string ResourceCreateSLALink = ";Create a &Rule;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView.RulesViewResources;CreateRuleTask";

            #endregion //Constants

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// <summary>
            /// Caches the translated resource for the Delete SLA COnfirmation dialog Title
            /// </summary>
            private static string cachedConfirmSLADeleteTitle;

            /// <summary>
            /// Cached reference for Service Level Tracking node.
            /// </summary>
            private static string cachedSLAView;

            /// <summary>
            /// Cached reference for SLA actions group.
            /// </summary>
            private static string cachedActionsSLA;

            /// <summary>
            /// Cached reference for SLA Create action in the actionpane.
            /// </summary>
            private static string cachedActionCreateSLA;

            /// <summary>
            /// Cached reference for SLA Properties action in the actionpane.
            /// </summary>
            private static string cachedActionPropertiesSLA;

            /// <summary>
            /// Cached reference for SLA Delete action in the actionpane.
            /// </summary>
            private static string cachedActionDeleteSLA;
            
            /// <summary>
            /// Cached reference for Distributed Application Filter.
            /// </summary>
            private static string cachedFilterDistrApp;

            /// <summary>
            /// Cached reference for Group Filter.
            /// </summary>
            private static string cachedFilterGroup;

            /// <summary>
            /// Cached reference for All Filter.
            /// </summary>
            private static string cachedFilterAll;

            /// <summary>
            /// Cached reference for ADD Toolbar item.
            /// </summary>
            private static string cachedAddToolbarItem;

            /// <summary>
            /// Cached reference for Edit Toolbar item.
            /// </summary>
            private static string cachedEditToolbarItem;

            /// <summary>
            /// Cached reference for Remove Toolbar item.
            /// </summary>
            private static string cachedRemoveToolbarItem;

            /// <summary>
            /// Cached reference for State Monitor State SLO Menu Item.
            /// </summary>
            private static string cachedMonitorStateSLOMenuItem;

            /// <summary>
            /// Cached reference for State Performance Rule SLO Menu Item.
            /// </summary>
            private static string cachedPerfRuleSLOMenuItem;

            /// <summary>
            /// Cached reference for Less Than Desired Objective
            /// </summary>
            private static string cachedLessThanDesiredObjective;


            /// <summary>
            /// Cached reference for More Than Desired Objective
            /// </summary>
            private static string cachedMoreThanDesiredObjective;

            /// <summary>
            /// Cached reference for CollectPercentProcessorTimeRule Name
            /// </summary>
            private static string cachedCollectPercentProcessorTimeRuleName;

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
            /// Exposes access to the for Confirm SLA Delete Dialog Title translated resource string
            /// </summary>
            public static string ConfirmSLADeleteTitle
            {
                get
                {
                    if ((cachedConfirmSLADeleteTitle == null))
                    {
                        cachedConfirmSLADeleteTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmSLADeleteTitle);
                    }

                    return cachedConfirmSLADeleteTitle;
                }
            }

            /// <summary>
            /// Service Level Tracking view/node resource string
            /// </summary>
            public static string SLAView
            {
                get
                {
                    if ((cachedSLAView == null))
                    {
                        cachedSLAView = CoreManager.MomConsole.GetIntlStr(ResourceSLAView);
                    }

                    return Strings.cachedSLAView;
                }
            }

            /// <summary>
            /// SLA taskstrip group.
            /// </summary>
            public static string ActionsSLA
            {
                get
                {
                    if ((cachedActionsSLA == null))
                    {
                        cachedActionsSLA = CoreManager.MomConsole.GetIntlStr(ResourceActionsSLA);
                    }

                    return cachedActionsSLA;
                }
            }

            /// <summary>
            /// SLA Create Action in the action pane. 
            /// </summary>
            public static string ActionCreateSLA
            {
                get
                {
                    if ((cachedActionCreateSLA == null))
                    {
                        cachedActionCreateSLA = CoreManager.MomConsole.GetIntlStr(ResourceActionCreateSLA);

                        //Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedActionCreateSLA);
                        cachedActionCreateSLA = removeAmp.Replace("&", "");
                        Utilities.LogMessage("cachedActionCreateSLA:: The resource after removing special chars is: " + cachedActionCreateSLA);
                    }

                    return cachedActionCreateSLA;
                }
            }
            
            /// <summary>
            /// SLA Properties Action in the action pane. 
            /// </summary>
            public static string ActionPropertiesSLA
            {
                get
                {
                    if ((cachedActionPropertiesSLA == null))
                    {
                        cachedActionPropertiesSLA = CoreManager.MomConsole.GetIntlStr(ResourceActionPropertiesSLA);

                        //Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedActionPropertiesSLA);
                        cachedActionPropertiesSLA = removeAmp.Replace("&", "");
                        Utilities.LogMessage("ActionPropertiesSLA:: The resource after removing special chars is: " + cachedActionPropertiesSLA);
                    }

                    return cachedActionPropertiesSLA;
                }
            }


            /// <summary>
            /// SLA Delete Action in the action pane. 
            /// </summary>
            public static string ActionDeleteSLA
            {
                get
                {
                    if ((cachedActionDeleteSLA == null))
                    {
                        cachedActionDeleteSLA = CoreManager.MomConsole.GetIntlStr(ResourceActionDeleteSLA);

                        //Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedActionDeleteSLA);
                        cachedActionDeleteSLA = removeAmp.Replace("&", "");
                        Utilities.LogMessage("cachedActionDeleteSLA:: The resource after removing special chars is: " + cachedActionDeleteSLA);
                    }

                    return cachedActionDeleteSLA;
                }
            }
            

            /// <summary>
            /// Distributed Application filter in the SelectTarget dialog. 
            /// </summary>
            public static string FilterDistApp
            {
                get
                {
                    if ((cachedFilterDistrApp == null))
                    {
                        cachedFilterDistrApp = CoreManager.MomConsole.GetIntlStr(ResourceDistAppFilter);
                    }

                    return cachedFilterDistrApp;
                }
            }
            
            /// <summary>
            /// Group filter in the SelectTarget dialog. 
            /// </summary>
            public static string FilterGroup
            {
                get
                {
                    if ((cachedFilterGroup == null))
                    {
                        cachedFilterGroup = CoreManager.MomConsole.GetIntlStr(ResourceGroupFilter);
                    }

                    return cachedFilterGroup;
                }
            }
            
            /// <summary>
            /// All filter in the SelectTarget dialog. 
            /// </summary>
            public static string FilterAll
            {
                get
                {
                    if ((cachedFilterAll == null))
                    {
                        cachedFilterAll = CoreManager.MomConsole.GetIntlStr(ResourceAllFilter);
                    }

                    return cachedFilterAll;
                }
            }

            /// <summary>
            /// Add toolbar Item in the SLos dialog. 
            /// </summary>
            public static string AddToolBarItem
            {
                get
                {
                    if ((cachedAddToolbarItem == null))
                    {
                        cachedAddToolbarItem = CoreManager.MomConsole.GetIntlStr(ResourceAddToolBarItem);

                        //Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedAddToolbarItem);
                        cachedAddToolbarItem = removeAmp.Replace("&", "");
                    }

                    return cachedAddToolbarItem;
                }
            }

            /// <summary>
            /// Edit toolbar Item in the SLos dialog. 
            /// </summary>
            public static string EditToolBarItem
            {
                get
                {
                    if ((cachedEditToolbarItem == null))
                    {
                        cachedEditToolbarItem = CoreManager.MomConsole.GetIntlStr(ResourceEditToolBarItem);

                        //Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedEditToolbarItem);
                        cachedEditToolbarItem = removeAmp.Replace("&", "");
                    }

                    return cachedEditToolbarItem;
                }
            }
            
            /// <summary>
            /// Remove toolbar Item in the SLos dialog. 
            /// </summary>
            public static string RemoveToolBarItem
            {
                get
                {
                    if ((cachedRemoveToolbarItem == null))
                    {
                        cachedRemoveToolbarItem = CoreManager.MomConsole.GetIntlStr(ResourceRemoveToolBarItem);

                        //Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedRemoveToolbarItem);
                        cachedRemoveToolbarItem = removeAmp.Replace("&", "");
                    }

                    return cachedRemoveToolbarItem;
                }
            }

            /// <summary>
            /// Monitor State SLO menu Item in the SLos dialog. 
            /// </summary>
            public static string MonitorStateSLOMenuItem
            {
                get
                {
                    if ((cachedMonitorStateSLOMenuItem == null))
                    {
                        cachedMonitorStateSLOMenuItem = CoreManager.MomConsole.GetIntlStr(ResourceMonitorStateSLOMenuItem);
                    }

                    return cachedMonitorStateSLOMenuItem;
                }
            }

            /// <summary>
            /// Performance Rule SLO menu Item in the SLos dialog. 
            /// </summary>
            public static string PerfRuleSLOMenuItem
            {
                get
                {
                    if ((cachedPerfRuleSLOMenuItem == null))
                    {
                        cachedPerfRuleSLOMenuItem = CoreManager.MomConsole.GetIntlStr(ResourceCollRuleSLOMenuItem);
                    }

                    return cachedPerfRuleSLOMenuItem;
                }
            }

            /// <summary>
            /// Less Than Desired Objective in the Collection Rule dialog. 
            /// </summary>
            public static string LessThanDesiredObjective
            {
                get
                {
                    if ((cachedLessThanDesiredObjective == null))
                    {
                        cachedLessThanDesiredObjective = CoreManager.MomConsole.GetIntlStr(ResourceLessThanDesiredObjective);
                    }

                    return cachedLessThanDesiredObjective;
                }
            }

            /// <summary>
            /// More Than Desired Objective in the Collection Rule dialog. 
            /// </summary>
            public static string MoreThanDesiredObjective
            {
                get
                {
                    if ((cachedMoreThanDesiredObjective == null))
                    {
                        cachedMoreThanDesiredObjective = CoreManager.MomConsole.GetIntlStr(ResourceMoreThanDesiredObjective);
                    }

                    return cachedMoreThanDesiredObjective;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Collect Process\% Processor Time Rule Name (CollectPercentProcessorTime)
            /// </summary>
            /// <history>
            /// 	[dialac] 13APR09: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CollectPercentProcessorTimeRuleName
            {
                get
                {
                    if ((cachedCollectPercentProcessorTimeRuleName == null))
                    {
                        cachedCollectPercentProcessorTimeRuleName = Common.Utilities.GetMonitoringRuleName(
                            SLASLO.Strings.OwnProcessNTServiceGUID.ToString(), 
                            SLASLO.Strings.CollectPercentProcessorTimeRuleGUID.ToString());
                        Utilities.LogMessage("SLASLO.Strings.CollectPercentProcessorTimeRuleName :: the rule name for CollectPercentProcessorTime is:" + cachedCollectPercentProcessorTimeRuleName);
                    }

                    return cachedCollectPercentProcessorTimeRuleName;
                }
            }

         #endregion
        }
        #endregion

    } // end of class SLASLO

} // end of namespace