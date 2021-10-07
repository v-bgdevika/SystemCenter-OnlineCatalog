// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SettingsSummaryDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 3/27/2006 Created
//  [faizalk] 4/17/2006 update to use resource string
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISettingsSummaryDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISettingsSummaryDialogControls, for SettingsSummaryDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 3/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISettingsSummaryDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComponentTypeStaticControl
        /// </summary>
        StaticControl ComponentTypeStaticControl
        {
            get;
        }
                
        /// <summary>
        /// Read-only property to access ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox
        /// </summary>
        CheckBox ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl2
        /// </summary>
        StaticControl SummaryStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackDetailsListView
        /// </summary>
        ListView ManagementPackDetailsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl
        /// </summary>
        StaticControl TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl3
        /// </summary>
        StaticControl SummaryStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WebApplicationMonitoringSettingsSummaryStaticControl
        /// </summary>
        StaticControl WebApplicationMonitoringSettingsSummaryStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[faizalk] 3/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SettingsSummaryDialog : Dialog, ISettingsSummaryDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ComponentTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComponentTypeStaticControl;
                
        /// <summary>
        /// Cache to hold a reference to ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackDetailsListView of type ListView
        /// </summary>
        private ListView cachedManagementPackDetailsListView;
        
        /// <summary>
        /// Cache to hold a reference to TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WebApplicationMonitoringSettingsSummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWebApplicationMonitoringSettingsSummaryStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SettingsSummaryDialog of type Mom.Test.UI.Core.Console.MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SettingsSummaryDialog(Mom.Test.UI.Core.Console.MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISettingsSummaryDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISettingsSummaryDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses
        {
            get
            {
                return this.Controls.ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISettingsSummaryDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SettingsSummaryDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISettingsSummaryDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SettingsSummaryDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISettingsSummaryDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SettingsSummaryDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISettingsSummaryDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SettingsSummaryDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComponentTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.ComponentTypeStaticControl
        {
            get
            {
                if ((this.cachedComponentTypeStaticControl == null))
                {
                    this.cachedComponentTypeStaticControl = new StaticControl(this, SettingsSummaryDialog.ControlIDs.ComponentTypeStaticControl);
                }
                return this.cachedComponentTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISettingsSummaryDialogControls.ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox
        {
            get
            {
                if ((this.cachedConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox == null))
                {
                    this.cachedConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox = new CheckBox(this, SettingsSummaryDialog.ControlIDs.ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox);
                }
                return this.cachedConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.SummaryStaticControl2
        {
            get
            {
                if ((this.cachedSummaryStaticControl2 == null))
                {
                    this.cachedSummaryStaticControl2 = new StaticControl(this, SettingsSummaryDialog.ControlIDs.SummaryStaticControl2);
                }
                return this.cachedSummaryStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackDetailsListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISettingsSummaryDialogControls.ManagementPackDetailsListView
        {
            get
            {
                if ((this.cachedManagementPackDetailsListView == null))
                {
                    this.cachedManagementPackDetailsListView = new ListView(this, SettingsSummaryDialog.ControlIDs.ManagementPackDetailsListView);
                }
                return this.cachedManagementPackDetailsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl
        {
            get
            {
                if ((this.cachedTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl == null))
                {
                    this.cachedTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl = new StaticControl(this, SettingsSummaryDialog.ControlIDs.TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl);
                }
                return this.cachedTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.SummaryStaticControl3
        {
            get
            {
                if ((this.cachedSummaryStaticControl3 == null))
                {
                    this.cachedSummaryStaticControl3 = new StaticControl(this, SettingsSummaryDialog.ControlIDs.SummaryStaticControl3);
                }
                return this.cachedSummaryStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, SettingsSummaryDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WebApplicationMonitoringSettingsSummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISettingsSummaryDialogControls.WebApplicationMonitoringSettingsSummaryStaticControl
        {
            get
            {
                if ((this.cachedWebApplicationMonitoringSettingsSummaryStaticControl == null))
                {
                    this.cachedWebApplicationMonitoringSettingsSummaryStaticControl = new StaticControl(this, SettingsSummaryDialog.ControlIDs.WebApplicationMonitoringSettingsSummaryStaticControl);
                }
                return this.cachedWebApplicationMonitoringSettingsSummaryStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses()
        {
            this.Controls.ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Mom.Test.UI.Core.Console.MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException)
            {
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                app.GetIntlStr(Strings.DialogTitle) + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

                    // throw the existing WindowNotFound exception
                    throw;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.Common.PageCommonResources;CommitButtonText" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComponentType = ";Component Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.TemplateListPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WebAddress
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebAddress = "Web Address";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWatcherNode = ";Watcher Node;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.MonitorAppWizard.ChooseWatcherNodesPage;$this." +
                "NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;SummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses = ";&Configure Advanced Monitoring or Record a browser session after the wizard clos" +
                "es.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement" +
                ".Internal.UI.Authoring.PagesURLTemplatePage.SummaryPage;checkBoxLaunchAdva" +
                "nced.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary2 = ";&Summary:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.PagesURLTemplatePage.SummaryPage;labelSummary" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL = ";The following summarizes the input data required to begin monitoring this URL.;M" +
                "anagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement." +
                "Internal.UI.Authoring.Pages.URLTemplatePage.SummaryPage;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary3 = ";Summary;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;SummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WebApplicationMonitoringSettingsSummary
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebApplicationMonitoringSettingsSummary = "Web Application Monitoring Settings Summary";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComponentType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComponentType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WebAddress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebAddress;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWatcherNode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WebApplicationMonitoringSettingsSummary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebApplicationMonitoringSettingsSummary;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    return cachedPrevious;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    return cachedNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    return cachedCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComponentType translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComponentType
            {
                get
                {
                    if ((cachedComponentType == null))
                    {
                        cachedComponentType = CoreManager.MomConsole.GetIntlStr(ResourceComponentType);
                    }
                    return cachedComponentType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties
            {
                get
                {
                    if ((cachedGeneralProperties == null))
                    {
                        cachedGeneralProperties = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties);
                    }
                    return cachedGeneralProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebAddress translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebAddress
            {
                get
                {
                    if ((cachedWebAddress == null))
                    {
                        cachedWebAddress = CoreManager.MomConsole.GetIntlStr(ResourceWebAddress);
                    }
                    return cachedWebAddress;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WatcherNode translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WatcherNode
            {
                get
                {
                    if ((cachedWatcherNode == null))
                    {
                        cachedWatcherNode = CoreManager.MomConsole.GetIntlStr(ResourceWatcherNode);
                    }
                    return cachedWatcherNode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    return cachedSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses
            {
                get
                {
                    if ((cachedConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses == null))
                    {
                        cachedConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses);
                    }
                    return cachedConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary2
            {
                get
                {
                    if ((cachedSummary2 == null))
                    {
                        cachedSummary2 = CoreManager.MomConsole.GetIntlStr(ResourceSummary2);
                    }
                    return cachedSummary2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL
            {
                get
                {
                    if ((cachedTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL == null))
                    {
                        cachedTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL = CoreManager.MomConsole.GetIntlStr(ResourceTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL);
                    }
                    return cachedTheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURL;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary3 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary3
            {
                get
                {
                    if ((cachedSummary3 == null))
                    {
                        cachedSummary3 = CoreManager.MomConsole.GetIntlStr(ResourceSummary3);
                    }
                    return cachedSummary3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebApplicationMonitoringSettingsSummary translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebApplicationMonitoringSettingsSummary
            {
                get
                {
                    if ((cachedWebApplicationMonitoringSettingsSummary == null))
                    {
                        cachedWebApplicationMonitoringSettingsSummary = CoreManager.MomConsole.GetIntlStr(ResourceWebApplicationMonitoringSettingsSummary);
                    }
                    return cachedWebApplicationMonitoringSettingsSummary;
                }
            }
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for ComponentTypeStaticControl
            /// </summary>
            public const string ComponentTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WebAddressStaticControl
            /// </summary>
            public const string WebAddressStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WatcherNodeStaticControl
            /// </summary>
            public const string WatcherNodeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox
            /// </summary>
            public const string ConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardClosesCheckBox = "checkBoxLaunchAdvanced";
            
            /// <summary>
            /// Control ID for SummaryStaticControl2
            /// </summary>
            public const string SummaryStaticControl2 = "labelSummary";
            
            /// <summary>
            /// Control ID for ManagementPackDetailsListView
            /// </summary>
            public const string ManagementPackDetailsListView = "listView";
            
            /// <summary>
            /// Control ID for TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl
            /// </summary>
            public const string TheFollowingSummarizesTheInputDataRequiredToBeginMonitoringThisURLStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for SummaryStaticControl3
            /// </summary>
            public const string SummaryStaticControl3 = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for WebApplicationMonitoringSettingsSummaryStaticControl
            /// </summary>
            public const string WebApplicationMonitoringSettingsSummaryStaticControl = "headerLabel";
        }
        #endregion
    }
}
