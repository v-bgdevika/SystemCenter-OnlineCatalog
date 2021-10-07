// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfigurationTabRulePropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 6/1/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IConfigurationTabRulePropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfigurationTabRulePropertiesDialogControls, for ConfigurationTabRulePropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 6/1/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfigurationTabRulePropertiesDialogControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditButton
        /// </summary>
        Button EditButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponsesStaticControl
        /// </summary>
        StaticControl ResponsesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataSourcesStaticControl
        /// </summary>
        StaticControl DataSourcesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleConfigurationStaticControl
        /// </summary>
        StaticControl RuleConfigurationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditButton2
        /// </summary>
        Button EditButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponsesPropertyGridView
        /// </summary>
        PropertyGridView ResponsesPropertyGridView
        {
            get;
        }
        
        ///// <summary>
        ///// Read-only property to access [NotUsed]StaticControl
        ///// </summary>
        //StaticControl [NotUsed]StaticControl
        //{
        //    get;
        //}
        
        /// <summary>
        /// Read-only property to access ConditionStaticControl
        /// </summary>
        StaticControl ConditionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TestPropertyGridView
        /// </summary>
        PropertyGridView TestPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        /// </summary>
        StaticControl ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
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
    /// 	[dialac] 6/1/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfigurationTabRulePropertiesDialog : Dialog, IConfigurationTabRulePropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to EditButton of type Button
        /// </summary>
        private Button cachedEditButton;
        
        /// <summary>
        /// Cache to hold a reference to ResponsesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResponsesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DataSourcesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDataSourcesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RuleConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleConfigurationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to EditButton2 of type Button
        /// </summary>
        private Button cachedEditButton2;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to ResponsesPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedResponsesPropertyGridView;
        
        ///// <summary>
        ///// Cache to hold a reference to [NotUsed]StaticControl of type StaticControl
        ///// </summary>
        //private StaticControl cached[NotUsed]StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConditionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConditionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TestPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedTestPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp of type StaticControl
        /// </summary>
        private StaticControl cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfigurationTabRulePropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfigurationTabRulePropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IConfigurationTabRulePropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfigurationTabRulePropertiesDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigurationTabRulePropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, ConfigurationTabRulePropertiesDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigurationTabRulePropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConfigurationTabRulePropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigurationTabRulePropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ConfigurationTabRulePropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IConfigurationTabRulePropertiesDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, ConfigurationTabRulePropertiesDialog.ControlIDs.Tab1TabControl);
                }
                
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigurationTabRulePropertiesDialogControls.EditButton
        {
            get
            {
                if ((this.cachedEditButton == null))
                {
                    this.cachedEditButton = new Button(this, ConfigurationTabRulePropertiesDialog.ControlIDs.EditButton);
                }
                
                return this.cachedEditButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponsesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigurationTabRulePropertiesDialogControls.ResponsesStaticControl
        {
            get
            {
                if ((this.cachedResponsesStaticControl == null))
                {
                    this.cachedResponsesStaticControl = new StaticControl(this, ConfigurationTabRulePropertiesDialog.ControlIDs.ResponsesStaticControl);
                }
                
                return this.cachedResponsesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataSourcesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigurationTabRulePropertiesDialogControls.DataSourcesStaticControl
        {
            get
            {
                if ((this.cachedDataSourcesStaticControl == null))
                {
                    this.cachedDataSourcesStaticControl = new StaticControl(this, ConfigurationTabRulePropertiesDialog.ControlIDs.DataSourcesStaticControl);
                }
                
                return this.cachedDataSourcesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigurationTabRulePropertiesDialogControls.RuleConfigurationStaticControl
        {
            get
            {
                if ((this.cachedRuleConfigurationStaticControl == null))
                {
                    this.cachedRuleConfigurationStaticControl = new StaticControl(this, ConfigurationTabRulePropertiesDialog.ControlIDs.RuleConfigurationStaticControl);
                }
                
                return this.cachedRuleConfigurationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigurationTabRulePropertiesDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, ConfigurationTabRulePropertiesDialog.ControlIDs.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditButton2 control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigurationTabRulePropertiesDialogControls.EditButton2
        {
            get
            {
                if ((this.cachedEditButton2 == null))
                {
                    this.cachedEditButton2 = new Button(this, ConfigurationTabRulePropertiesDialog.ControlIDs.EditButton2);
                }
                
                return this.cachedEditButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigurationTabRulePropertiesDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, ConfigurationTabRulePropertiesDialog.ControlIDs.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponsesPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IConfigurationTabRulePropertiesDialogControls.ResponsesPropertyGridView
        {
            get
            {
                if ((this.cachedResponsesPropertyGridView == null))
                {
                    this.cachedResponsesPropertyGridView = new PropertyGridView(this, ConfigurationTabRulePropertiesDialog.ControlIDs.ResponsesPropertyGridView);
                }
                
                return this.cachedResponsesPropertyGridView;
            }
        }
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Exposes access to the [NotUsed]StaticControl control
        ///// </summary>
        ///// <history>
        ///// 	[dialac] 6/1/2008 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //StaticControl IConfigurationTabRulePropertiesDialogControls.[NotUsed]StaticControl
        //{
        //    get
        //    {
        //        if ((this.cached[NotUsed]StaticControl == null))
        //        {
        //            this.cached[NotUsed]StaticControl = new StaticControl(this, ConfigurationTabRulePropertiesDialog.ControlIDs.[NotUsed]StaticControl);
        //        }
                
        //        return this.cached[NotUsed]StaticControl;
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConditionStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigurationTabRulePropertiesDialogControls.ConditionStaticControl
        {
            get
            {
                if ((this.cachedConditionStaticControl == null))
                {
                    this.cachedConditionStaticControl = new StaticControl(this, ConfigurationTabRulePropertiesDialog.ControlIDs.ConditionStaticControl);
                }
                
                return this.cachedConditionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TestPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IConfigurationTabRulePropertiesDialogControls.TestPropertyGridView
        {
            get
            {
                if ((this.cachedTestPropertyGridView == null))
                {
                    this.cachedTestPropertyGridView = new PropertyGridView(this, ConfigurationTabRulePropertiesDialog.ControlIDs.TestPropertyGridView);
                }
                
                return this.cachedTestPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigurationTabRulePropertiesDialogControls.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        {
            get
            {
                if ((this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp == null))
                {
                    this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp = new StaticControl(this, ConfigurationTabRulePropertiesDialog.ControlIDs.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp);
                }
                
                return this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Edit
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.EditButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Edit2
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit2()
        {
            this.Controls.EditButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                //tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
                tempWindow = new Window(Strings.DialogTitle,
         StringMatchSyntax.ExactMatch,
                           WindowClassNames.Dialog,
                           StringMatchSyntax.ExactMatch,
                           app.MainWindow,
                     Timeout);

                    //new Window(Strings.DialogTitle + "*", StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
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
        /// 	[dialac] 6/1/2008 Created
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
            //private const string ResourceDialogTitle = "WMIRule1 Properties";
            //public const string ResourceDialogTitle = ";Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;MPObjectFormatString";
            private const string ResourceDialogTitle = ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEdit = ";&Edit...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.EmailNot" +
                "ification;edit.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Responses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResponses = ";Res&ponses:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;responsesLa" +
                "bel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataSources
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataSources = ";Data &sources:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;dsLabel." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleConfiguration = ";Rule configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;page" +
                "SectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";Re&move;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSche" +
                "dulePage;exclusionPeriods.RemoveButtonText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Edit2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEdit2 = ";E&dit...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;editButton.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";&Add...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDial" +
                "og;menuAdd.Text";
            
            ///// -----------------------------------------------------------------------------
            ///// <summary>
            ///// Contains resource string for:  [NotUsed]
            ///// </summary>
            ///// -----------------------------------------------------------------------------
            //private const string Resource[NotUsed] = ";[Not used];ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
            //    "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;C" +
            //    "onditionNotUsed";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Condition
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCondition = ";Condition:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;conditionLab" +
                "el.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp = @";A rule contains one or more data sources, an optional condition and one or more responses. You can add new responses and apply the 'run as' profiles to be used when the rule is run.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;modifyLabel.Text";
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
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Responses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResponses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DataSources
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataSources;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RuleConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleConfiguration;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEdit2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            ///// -----------------------------------------------------------------------------
            ///// <summary>
            ///// Caches the translated resource string for:  [NotUsed]
            ///// </summary>
            ///// -----------------------------------------------------------------------------
            //private static string cached[NotUsed];
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Condition
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCondition;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Edit
            {
                get
                {
                    if ((cachedEdit == null))
                    {
                        cachedEdit = CoreManager.MomConsole.GetIntlStr(ResourceEdit);
                    }
                    
                    return cachedEdit;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Responses translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Responses
            {
                get
                {
                    if ((cachedResponses == null))
                    {
                        cachedResponses = CoreManager.MomConsole.GetIntlStr(ResourceResponses);
                    }
                    
                    return cachedResponses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataSources translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataSources
            {
                get
                {
                    if ((cachedDataSources == null))
                    {
                        cachedDataSources = CoreManager.MomConsole.GetIntlStr(ResourceDataSources);
                    }
                    
                    return cachedDataSources;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RuleConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleConfiguration
            {
                get
                {
                    if ((cachedRuleConfiguration == null))
                    {
                        cachedRuleConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceRuleConfiguration);
                    }
                    
                    return cachedRuleConfiguration;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    
                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Edit2
            {
                get
                {
                    if ((cachedEdit2 == null))
                    {
                        cachedEdit2 = CoreManager.MomConsole.GetIntlStr(ResourceEdit2);
                    }
                    
                    return cachedEdit2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    
                    return cachedAdd;
                }
            }
            
            ///// -----------------------------------------------------------------------------
            ///// <summary>
            ///// Exposes access to the [NotUsed] translated resource string
            ///// </summary>
            ///// <history>
            ///// 	[dialac] 6/1/2008 Created
            ///// </history>
            ///// -----------------------------------------------------------------------------
            //public static string [NotUsed]
            //{
            //    get
            //    {
            //        if ((cached[NotUsed] == null))
            //        {
            //            cached[NotUsed] = CoreManger.MomConsole.GetIntlStr(Resource[NotUsed]);
            //        }
                    
            //        return cached[NotUsed];
            //    }
            //}
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Condition translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Condition
            {
                get
                {
                    if ((cachedCondition == null))
                    {
                        cachedCondition = CoreManager.MomConsole.GetIntlStr(ResourceCondition);
                    }
                    
                    return cachedCondition;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
            {
                get
                {
                    if ((cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp == null))
                    {
                        cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp = CoreManager.MomConsole.GetIntlStr(ResourceARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp);
                    }
                    
                    return cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp;
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
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for EditButton
            /// </summary>
            public const string EditButton = "editDsBtn";
            
            /// <summary>
            /// Control ID for ResponsesStaticControl
            /// </summary>
            public const string ResponsesStaticControl = "responsesLabel";
            
            /// <summary>
            /// Control ID for DataSourcesStaticControl
            /// </summary>
            public const string DataSourcesStaticControl = "dsLabel";
            
            /// <summary>
            /// Control ID for RuleConfigurationStaticControl
            /// </summary>
            public const string RuleConfigurationStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for EditButton2
            /// </summary>
            public const string EditButton2 = "editButton";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addNewResponseBtn";
            
            /// <summary>
            /// Control ID for ResponsesPropertyGridView
            /// </summary>
            public const string ResponsesPropertyGridView = "rsdataGridView";
            
            ///// <summary>
            ///// Control ID for [NotUsed]StaticControl
            ///// </summary>
           // public const string [NotUsed]StaticControl = "conditionTextLabel";
            
            /// <summary>
            /// Control ID for ConditionStaticControl
            /// </summary>
            public const string ConditionStaticControl = "conditionLabel";
            
            /// <summary>
            /// Control ID for TestPropertyGridView
            /// </summary>
            public const string TestPropertyGridView = "dsDataGridView";
            
            /// <summary>
            /// Control ID for ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
            /// </summary>
            public const string ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp = "modifyLabel";
        }
        #endregion
    }
}
