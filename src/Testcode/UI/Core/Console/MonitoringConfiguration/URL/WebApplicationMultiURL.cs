// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WebApplicationMultiURL.cs">
// 	Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Web Application Monitor Class for new UI on improvement branch 175851
// </summary>
// <history>
// 	[v-bire]   11APR11     Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL
{
    #region Using directives

    using System;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.Administration;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs;
    using Mom.Test.UI.Core.Console.MP.Dialogs;

    #endregion

    /// <summary>
    /// Class to add general methods for Web Application Monitor/Template
    /// </summary>
    /// <history> 	
    ///   [faizalk]  Created
    /// </history>
    public class WebApplicationMultiURL
    {
        #region Private Constants

        #endregion

        #region Private Members

        /// <summary>
        /// cachedComponentTypeDialog
        /// </summary>
        private SelectComponentTypeDialog cachedComponentTypeDialog;

        /// <summary>
        /// cachedgeneralPropertiesTemplateDialog
        /// </summary>
        private GeneralPropertiesDialog cachedgeneralPropertiesTemplateDialog;

        /// <summary>
        /// cachedWhatToMonitorDialog
        /// </summary>
        private WhatToMonitorDialog cachedWhatToMonitorDialog;

        /// <summary>
        /// cachedWhereToMonitorFromDialog
        /// </summary>
        private WhereToMonitorFromDialog cachedWhereToMonitorFromDialog;

        /// <summary>
        /// cachedViewAndValidateTestDialog
        /// </summary>
        private ViewAndValidateTestDialog cachedViewAndValidateTestDialog;

        /// <summary>
        /// cachedSummaryDialog
        /// </summary>
        private SummaryDialog cachedSummaryDialog;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;

        #region Enumerators section

        /// <summary>
        /// Valid Protocols
        /// </summary>
        public enum UrlProtocol
        {
            /// <summary>
            /// Http
            /// </summary>
            Http,

            /// <summary>
            /// Https
            /// </summary>
            Https,
        }

        /// <summary>
        /// Insert extracted parameters types
        /// </summary>
        public enum ExtractType
        {
            /// <summary>
            /// Insert extracted parameters 
            /// in HTTP Url
            /// </summary>
            RequestUrl,

            /// <summary>
            /// Insert extracted parameters 
            /// in Request Header
            /// </summary>
            RequestHeader,
        }

        #endregion	// Enumerators section

        #endregion

        #region Constructor
        /// <summary>
        /// URL
        /// </summary>
        public WebApplicationMultiURL()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Select Component Type Dialog
        /// The first screen of the Create Component wizard.
        /// </summary>
        public SelectComponentTypeDialog SelectComponentTypeDialog
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
        /// The Second screen of the Create Component wizard.
        /// </summary>
        public GeneralPropertiesDialog GeneralPropertiesDialog
        {
            get
            {
                if (this.cachedgeneralPropertiesTemplateDialog == null)
                {
                    this.cachedgeneralPropertiesTemplateDialog = new GeneralPropertiesDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitoringTemplateWizard);
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }

                return this.cachedgeneralPropertiesTemplateDialog;
            }
        }

        /// <summary>
        /// What to Monitor Dialog
        /// The third screen of the Create Component wizard.
        /// </summary>
        public WhatToMonitorDialog WhatToMonitorDialog
        {
            get
            {
                if (this.cachedWhatToMonitorDialog == null)
                {
                    this.cachedWhatToMonitorDialog = new WhatToMonitorDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the What to Monitor Dialog was successful");
                }

                return this.cachedWhatToMonitorDialog;
            }
        }

        /// <summary>
        /// Where to Monitor From Dialog
        /// </summary>
        public WhereToMonitorFromDialog WhereToMonitorFromDialog
        {
            get
            {
                if (this.cachedWhereToMonitorFromDialog == null)
                {
                    this.cachedWhereToMonitorFromDialog = new WhereToMonitorFromDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Where to Monitor From Dialog was successful");
                }

                return this.cachedWhereToMonitorFromDialog;
            }
        }

        /// <summary>
        /// View and Validate Tests Dialog
        /// </summary>
        public ViewAndValidateTestDialog ViewAndValidateTestDialog
        {
            get
            {
                if (this.cachedViewAndValidateTestDialog == null)
                {
                    this.cachedViewAndValidateTestDialog = new ViewAndValidateTestDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the View and Validate Test Dialog was successful");
                }

                return this.cachedViewAndValidateTestDialog;
            }
        }

        /// <summary>
        /// Summary Dialog
        /// </summary>
        public SummaryDialog SummaryDialog
        {
            get
            {
                if (this.cachedSummaryDialog == null)
                {
                    this.cachedSummaryDialog = new SummaryDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Summary Dialog was successful");
                }

                return this.cachedSummaryDialog;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create a new Web Application Monitor component
        /// </summary>
        /// <param name="parameters">WebApplicationMonitorParameters</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-bire] 11APR11 - Created   
        /// </history>
        public void CreateComponent(WebApplicationParameters parameters)
        {
            Utilities.LogMessage("WebApplication.CreateComponent:: Launch Create Component Wizard");

            #region Navigate to Web Application Wizard

            // Get Reference to Actions Pane. And select the wizard from the actions pane.
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            actionsPane.ClickLink(
                NavigationPane.WunderBarButton.MonitoringConfiguration,
                monitoredComponentsPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents,
                Templates.Strings.LaunchComponentWizardTask);

            Utilities.LogMessage("WebApplication.CreateComponent:: Selected "
                + Templates.Strings.LaunchComponentWizardTask);

            #endregion

            // Navigate through all the screens of the Wizard

            #region Component Type Dialog

            // Based on the Type parameter; Select the component Type 
            string typeSelected = SelectComponentTypeDialog.Strings.WebApplicationAvailabilityMonitoringTemplate;

            Maui.Core.WinControls.TreeNode myNode = null;
            myNode = this.SelectComponentTypeDialog.Controls.SelectComponentTypeTreeView.Find(typeSelected);
            Utilities.LogMessage("WebApplication.CreateComponent:: Found component type '" + typeSelected + "'");

            myNode.Select();
            Utilities.LogMessage("WebApplication.CreateComponent:: Successfully selected component type '" +
                typeSelected + "'");
            myNode.Click();
            UISynchronization.WaitForProcessReady(this.SelectComponentTypeDialog);
            this.SelectComponentTypeDialog.WaitForResponse();


            SelectComponentTypeDialog.ScreenElement.WaitForReady();

            if (!consoleApp.Waiters.WaitForWizardNavigationItemCount(this.SelectComponentTypeDialog, 5, Constants.OneMinute /2))
            {
                Utilities.LogMessage("WebApplication.CreateComponent:: NavigationItemCount not expected value");
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.SelectComponentTypeDialog.Controls.NextButton, Constants.OneSecond * 5);

            Utilities.LogMessage("WebApplication.CreateComponent:: Successfully clicked on component type");

            this.SelectComponentTypeDialog.WaitForResponse();

            Utilities.LogMessage("Click Next (Go to General)");
            this.SelectComponentTypeDialog.ClickNext();

            #endregion

            #region General Properties Dialog

            this.GeneralPropertiesDialog.WaitForResponse();

            // Enter the General Properties
            // Trying to set the name -- if its null throws System.ArgumentNullException
            if (!string.IsNullOrEmpty(parameters.Name))
            {
                this.GeneralPropertiesDialog.NameText = parameters.Name;
                Utilities.LogMessage("WebApplication.CreateComponent:: Set display name '" + this.GeneralPropertiesDialog.NameText);
            }
            else
            {
                throw new System.ArgumentNullException("WebApplicationParameters.Name cannot be null!");
            }

            if (null != parameters.Description)
            {
                this.GeneralPropertiesDialog.DescriptionText = parameters.Description;
                Utilities.LogMessage("WebApplication.CreateComponent:: Set description '" + this.GeneralPropertiesDialog.DescriptionText);
            }

            if (!string.IsNullOrEmpty(parameters.DestinationMP))
            {
                try
                {
                    int index = this.GeneralPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.GetIndexByText(parameters.DestinationMP, true);
                    Utilities.LogMessage("Index of item: "+parameters.DestinationMP +" is: "+index+", select item by index");
                    this.GeneralPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.SelectByIndex(index);
                }
                catch (ComboBox.Exceptions.TextNotFoundException)
                {
                    Utilities.LogMessage("Create new mp since the specified MP not exists on the UI");
                    #region Create new MP
                    Utilities.LogMessage("Click New button on General");
                    this.GeneralPropertiesDialog.ClickNew();

                    CreateManagementPackGenPropDialog createMPDialog = new CreateManagementPackGenPropDialog(CoreManager.MomConsole);

                    Utilities.LogMessage("Set new mp name: "+parameters.DestinationMP);
                    createMPDialog.Controls.TextBox1.Text = parameters.DestinationMP;

                    Utilities.LogMessage("Wait for Next button enabled in 2 seconds");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(createMPDialog.Controls.NextButton, Constants.OneSecond * 2);
                    Utilities.LogMessage("Click Next button (Go to Knowledge)");
                    createMPDialog.ClickNext();

                    CreateManagementPackKnowledgeDialog knowledgeDialog = new CreateManagementPackKnowledgeDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Click Create button");
                    knowledgeDialog.ClickCreate();
                    //Extend wait time for window close,use default dialog timeout 15 seconds,bug #385286
                    Utilities.LogMessage(string.Format("Wait for window closed in {0} seconds",Constants.DefaultDialogTimeout));
                    CoreManager.MomConsole.Waiters.WaitForWindowClose(knowledgeDialog, Constants.DefaultDialogTimeout);

                    // ToDo: Verify the new mp created 1) it appears in the drop down list 2) it appears in Management Packs view
                    #endregion
                }
            }
           

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.GeneralPropertiesDialog.Controls.NextButton, Constants.OneSecond * 5);

            this.GeneralPropertiesDialog.WaitForResponse();

            Utilities.LogMessage("Click Next (Got to What to Monitor)");
            int retry = 0;
            while (this.GeneralPropertiesDialog.IsEnableForNextButton() && retry < 5)
            {
                if (retry > 0)
                {
                    Utilities.LogMessage("Retry click Next (Got to What to Monitor) for " + retry.ToString());
                }
                this.GeneralPropertiesDialog.ClickNext();
                Sleeper.Delay(Constants.OneSecond * 3);
                retry++;
            }

            #endregion

            #region What to Monitor Dialog

            this.WhatToMonitorDialog.WaitForResponse();

            for (int i = 0; i < parameters.URLNames.Length; i++)
            {
                Utilities.LogMessage("Add URL Name: " + parameters.URLNames[i] + " URL: " + parameters.URLs[i] + " at row index: " + i);
                this.WhatToMonitorDialog.AddURL(parameters.URLNames[i], parameters.URLs[i], i);
            }

            this.WhatToMonitorDialog.WaitForResponse();

            Utilities.LogMessage("Click Next (Go to Where to Monitor From)");
            this.WhatToMonitorDialog.Controls.NextButton.Click();

            #endregion

            #region Where to Monitor From Dialog

            this.WhereToMonitorFromDialog.WaitForResponse();

            if (string.Equals(parameters.InternalLocationAgent.ToLowerInvariant(), "all"))
            {
                Utilities.LogMessage("Add all Internal locations agent");
                Utilities.LogMessage("Wait for Add button enabled");
                consoleApp.Waiters.WaitForObjectPropertyChanged(this.WhereToMonitorFromDialog.Controls.InternalLocationsAddButton, "@IsEnabled", PropertyOperator.Equals, true);
                Utilities.LogMessage("Click Add button");
                this.WhereToMonitorFromDialog.Controls.InternalLocationsAddButton.Click();
                
                // ToDo: Remove the hard code of Select internal locations
                PickerDialogBase pickerDialogBase = new PickerDialogBase(CoreManager.MomConsole, "Select internal locations");
                // ToDo: There's 1 important thing to do here: Check if the default search for item is Internal Location - Agent
                // This requires a code update in PickerDialogBase since the control id of the combobox is different with the current one
                Utilities.LogMessage("Click Search button on Select internal locations");
                pickerDialogBase.ClickSearch();
                CoreManager.MomConsole.Waiters.WaitForObjectPropertyChangedSafe(pickerDialogBase.Controls.AvailableItemsListView, "@Count", PropertyOperator.GreaterThan, 0, Constants.OneMinute);
                Utilities.LogMessage("Select all internal locations appeared in the list");
                pickerDialogBase.Controls.AvailableItemsListView.SelectAll();
                Utilities.LogMessage("Click Add button on Select internal locations");
                pickerDialogBase.ClickAdd();
                Utilities.LogMessage("Click OK button on Select internal locations");
                pickerDialogBase.ClickOK();
            }

            Utilities.LogMessage("Click Next (Go to View and Validate Tests)");
            this.WhereToMonitorFromDialog.Controls.NextButton.Click();

            #endregion

            #region View and Validate Tests dialog

            this.ViewAndValidateTestDialog.WaitForResponse();

            // Verify if the Test Name / URL / Agent/Pool is matched with the value we specified in previous steps
            // ToDo: Find a way to check if Agent/Pool matched with the value set in previous step
            // Weak check, no abort/fail/exceptions here
            Utilities.LogMessage("Verify if specified value exists in Test List Grid View");
            for (int i = 0; i < parameters.URLNames.Length; i++)
            {
                // Compare Test Name
                //[v-frma] 9/28/2011 use hard code to work around the resource string issue
                string uiTestName = this.ViewAndValidateTestDialog.GetCellValue(0, i);
                //string uiTestName = this.ViewAndValidateTestDialog.GetCellValue(this.ViewAndValidateTestDialog.ColumnHeaderTestNameIndex, i);
                Utilities.LogMessage("Test Name on UI: " + uiTestName);
                // ToDo: nathd on 04/14/2011 10:46:24: Should we fail here? Don't hold your check-in on this, but lets discuss more. 
                Utilities.LogMessage("Expected Test Name: " + parameters.URLNames[i]);

                // Compare URL 
                string uiURL = this.ViewAndValidateTestDialog.GetCellValue(this.ViewAndValidateTestDialog.ColumnHeaderURLIndex, i);
                Utilities.LogMessage("URL on UI: " + uiURL);
                Utilities.LogMessage("Expected URL: " + parameters.URLs[i]);
            }

            Utilities.LogMessage("Click Next (Go to Summary)");
            this.ViewAndValidateTestDialog.Controls.NextButton.Click();

            #endregion

            #region  Summary Dialog

            this.SummaryDialog.WaitForResponse();

            // Verify all the settings in Summary Dialog
            // ToDo: Find a way to verify all possible settings value

            // Verify Name
            Utilities.LogMessage("Expected name: "+parameters.Name);
            Utilities.LogMessage("Actual name shows on Summary dialog: "+this.SummaryDialog.SummarySettings[SummaryDialog.Strings.Name]);

            // Verify Management Pack
            Utilities.LogMessage("Expected management pack: "+parameters.DestinationMP);
            Utilities.LogMessage("Actual management pack shows on Summary dialog: "+this.SummaryDialog.SummarySettings [SummaryDialog.Strings.ManagementPack]);

            Utilities.LogMessage("Click Create");
            this.SummaryDialog.Controls.CreateButton.Click();

            #endregion

            // putting a short delay for the wizard to complete
            Sleeper.Delay(Constants.OneSecond);
            Utilities.LogMessage("WebApplication.CreateComponent:: Successfully completed Component Creation!!");
        }

        #endregion

        #region Private Methods
        #endregion

        #region WebApplicationParameters Class

        /// <summary>
        /// Parameters class for WebApplicationMultiURL constructors.
        /// </summary>
        /// <history>
        /// [v-bire] 11APR11 Created
        /// </history>
        public class WebApplicationParameters
        {
            #region Private Members
            // General
            private string cachedName = null;
            private string cachedDescription = null;
            private string cachedDestinationMP = null;

            // What to Monitor
            private string[] cachedURLNames = null;
            private string[] cachedURLs = null;

            // Where to Monitor From
            private string cachedInternalLocationAgent = null;

            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public WebApplicationParameters()
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// Display Name of Port
            /// </summary>
            public string Name
            {
                get
                {
                    return this.cachedName;
                }

                set
                {
                    this.cachedName = value;
                }
            }

            /// <summary>
            /// Description for Component
            /// </summary>
            public string Description
            {
                get
                {
                    return this.cachedDescription;
                }

                set
                {
                    this.cachedDescription = value;
                }
            }

            /// <summary>
            /// Destination MP for Component
            /// </summary>
            public string DestinationMP
            {
                get
                {
                    return this.cachedDestinationMP;
                }

                set
                {
                    this.cachedDestinationMP = value;
                }
            }

            /// <summary>
            /// An array to contains the name of the URL
            /// </summary>
            public string[] URLNames
            {
                get
                {
                    return this.cachedURLNames;
                }

                set
                {
                    this.cachedURLNames = value;
                }
            }

            /// <summary>
            /// An array to contains the URL
            /// </summary>
            public string[] URLs
            {
                get
                {
                    return this.cachedURLs;
                }

                set
                {
                    this.cachedURLs = value;
                }
            }

            /// <summary>
            /// Internal Locations Agent
            /// </summary>
            public string InternalLocationAgent
            {
                get
                {
                    return this.cachedInternalLocationAgent;
                }

                set
                {
                    this.cachedInternalLocationAgent = value;
                }
            }
            #endregion
        }
        #endregion
    }
}