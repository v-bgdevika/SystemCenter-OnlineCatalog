// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertPropertiesRuleDialog.cs">
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
    
    #region Interface Definition - IAlertPropertiesRuleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertPropertiesRuleDialogControls, for AlertPropertiesRuleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 6/1/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertPropertiesRuleDialogControls
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
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertSuppressionButton
        /// </summary>
        Button AlertSuppressionButton
        {
            get;
        }

        ///// <summary>
        ///// Read-only property to access ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        ///// </summary>
        //ComboBox ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        //{
        //    get;
        //}
        
        /// <summary>
        /// Read-only property to access PriorityStaticControl
        /// </summary>
        StaticControl PriorityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SeverityComboBox
        /// </summary>
        ComboBox SeverityComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SeverityStaticControl
        /// </summary>
        StaticControl SeverityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl
        /// </summary>
        StaticControl SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomAlertFieldsButton
        /// </summary>
        Button CustomAlertFieldsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleCategoryTextBox
        /// </summary>
        TextBox RuleCategoryTextBox
        {
            get;
        }
        
        ///// <summary>
        ///// Read-only property to access ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        ///// </summary>
        //TextBox ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        //{
        //    get;
        //}
        
        /// <summary>
        /// Read-only property to access AlertDescriptionStaticControl
        /// </summary>
        StaticControl AlertDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertNameStaticControl
        /// </summary>
        StaticControl AlertNameStaticControl
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
    public class AlertPropertiesRuleDialog : Dialog, IAlertPropertiesRuleDialogControls
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
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertSuppressionButton of type Button
        /// </summary>
        private Button cachedAlertSuppressionButton;
        
        ///// <summary>
        ///// Cache to hold a reference to ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp of type ComboBox
        ///// </summary>
        //private ComboBox cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp;
        
        /// <summary>
        /// Cache to hold a reference to PriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPriorityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SeverityComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSeverityComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SeverityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSeverityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomAlertFieldsButton of type Button
        /// </summary>
        private Button cachedCustomAlertFieldsButton;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to RuleCategoryTextBox of type TextBox
        /// </summary>
        private TextBox cachedRuleCategoryTextBox;
        
        ///// <summary>
        ///// Cache to hold a reference to ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp of type TextBox
        ///// </summary>
       // private TextBox cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp;
        
        /// <summary>
        /// Cache to hold a reference to AlertDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertNameStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertPropertiesRuleDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertPropertiesRuleDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertPropertiesRuleDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertPropertiesRuleDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Routine to set/get the text in control ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        ///// </summary>
        ///// <value>TODO: specify the value</value>
        ///// <history>
        ///// 	[dialac] 6/1/2008 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //public virtual string ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndAppText
        //{
        //    get
        //    {
        //        return this.Controls.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp.Text;
        //    }
            
        //    set
        //    {
        //        this.Controls.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp.SelectByText(value, true);
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Severity
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SeverityText
        {
            get
            {
                return this.Controls.SeverityComboBox.Text;
            }
            
            set
            {
                this.Controls.SeverityComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RuleCategory
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RuleCategoryText
        {
            get
            {
                return this.Controls.RuleCategoryTextBox.Text;
            }
            
            set
            {
                this.Controls.RuleCategoryTextBox.Text = value;
            }
        }
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Routine to set/get the text in control ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp2
        ///// </summary>
        ///// <value>TODO: specify the value</value>
        ///// <history>
        ///// 	[dialac] 6/1/2008 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //public virtual string ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp2Text
        //{
        //    get
        //    {
        //        return this.Controls.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp.Text;
        //    }
            
        //    set
        //    {
        //        this.Controls.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp.Text = value;
        //    }
        //}
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
        Button IAlertPropertiesRuleDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertPropertiesRuleDialog.ControlIDs.ApplyButton);
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
        Button IAlertPropertiesRuleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertPropertiesRuleDialog.ControlIDs.CancelButton);
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
        Button IAlertPropertiesRuleDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertPropertiesRuleDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertPropertiesRuleDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, AlertPropertiesRuleDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertSuppressionButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesRuleDialogControls.AlertSuppressionButton
        {
            get
            {
                if ((this.cachedAlertSuppressionButton == null))
                {
                    this.cachedAlertSuppressionButton = new Button(this, AlertPropertiesRuleDialog.ControlIDs.AlertSuppressionButton);
                }
                
                return this.cachedAlertSuppressionButton;
            }
        }
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Exposes access to the ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp control
        ///// </summary>
        ///// <history>
        ///// 	[dialac] 6/1/2008 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //ComboBox IAlertPropertiesRuleDialogControls.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        //{
        //    get
        //    {
        //        if ((this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp == null))
        //        {
        //            this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp = new ComboBox(this, AlertPropertiesRuleDialog.ControlIDs.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp);
        //        }
                
        //        return this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp;
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesRuleDialogControls.PriorityStaticControl
        {
            get
            {
                if ((this.cachedPriorityStaticControl == null))
                {
                    this.cachedPriorityStaticControl = new StaticControl(this, AlertPropertiesRuleDialog.ControlIDs.PriorityStaticControl);
                }
                
                return this.cachedPriorityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertPropertiesRuleDialogControls.SeverityComboBox
        {
            get
            {
                if ((this.cachedSeverityComboBox == null))
                {
                    this.cachedSeverityComboBox = new ComboBox(this, AlertPropertiesRuleDialog.ControlIDs.SeverityComboBox);
                }
                
                return this.cachedSeverityComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesRuleDialogControls.SeverityStaticControl
        {
            get
            {
                if ((this.cachedSeverityStaticControl == null))
                {
                    this.cachedSeverityStaticControl = new StaticControl(this, AlertPropertiesRuleDialog.ControlIDs.SeverityStaticControl);
                }
                
                return this.cachedSeverityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesRuleDialogControls.SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl == null))
                {
                    this.cachedSpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl = new StaticControl(this, AlertPropertiesRuleDialog.ControlIDs.SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl);
                }
                
                return this.cachedSpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomAlertFieldsButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesRuleDialogControls.CustomAlertFieldsButton
        {
            get
            {
                if ((this.cachedCustomAlertFieldsButton == null))
                {
                    this.cachedCustomAlertFieldsButton = new Button(this, AlertPropertiesRuleDialog.ControlIDs.CustomAlertFieldsButton);
                }
                
                return this.cachedCustomAlertFieldsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesRuleDialogControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, AlertPropertiesRuleDialog.ControlIDs.Button1);
                }
                
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleCategoryTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesRuleDialogControls.RuleCategoryTextBox
        {
            get
            {
                if ((this.cachedRuleCategoryTextBox == null))
                {
                    this.cachedRuleCategoryTextBox = new TextBox(this, AlertPropertiesRuleDialog.ControlIDs.RuleCategoryTextBox);
                }
                
                return this.cachedRuleCategoryTextBox;
            }
        }
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Exposes access to the ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp control
        ///// </summary>
        ///// <history>
        ///// 	[dialac] 6/1/2008 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //TextBox IAlertPropertiesRuleDialogControls.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
        //{
        //    get
        //    {
        //        if ((this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp == null))
        //        {
        //            this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp = new TextBox(this, AlertPropertiesRuleDialog.ControlIDs.ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp);
        //        }
                
        //        return this.cachedARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp;
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesRuleDialogControls.AlertDescriptionStaticControl
        {
            get
            {
                if ((this.cachedAlertDescriptionStaticControl == null))
                {
                    this.cachedAlertDescriptionStaticControl = new StaticControl(this, AlertPropertiesRuleDialog.ControlIDs.AlertDescriptionStaticControl);
                }
                
                return this.cachedAlertDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesRuleDialogControls.AlertNameStaticControl
        {
            get
            {
                if ((this.cachedAlertNameStaticControl == null))
                {
                    this.cachedAlertNameStaticControl = new StaticControl(this, AlertPropertiesRuleDialog.ControlIDs.AlertNameStaticControl);
                }
                
                return this.cachedAlertNameStaticControl;
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
        ///  Routine to click on button AlertSuppression
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAlertSuppression()
        {
            this.Controls.AlertSuppressionButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CustomAlertFields
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCustomAlertFields()
        {
            this.Controls.CustomAlertFieldsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
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
            //private const string ResourceDialogTitle = "Alert - Properties";
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
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSuppression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSuppression = ";Alert s&uppression...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertingModulePag" +
                "e;suppressionBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Priority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePriority = ";Pri&ority:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;priorityL" +
                "abel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Severity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeverity = ";Se&verity:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertingModulePage;severityL" +
                "abel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheInformationThatWillBeGeneratedByTheAlert
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheInformationThatWillBeGeneratedByTheAlert = ";Specify the information that will be generated by the alert;ManagedString;Micros" +
                "oft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Interna" +
                "l.UI.Authoring.Pages.AlertingModulePage;pageSectionLabel2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomAlertFields
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomAlertFields = ";Custom alert &fields...;ManagedString;Microsoft.EnterpriseManagement.UI.Authorin" +
                "g.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertingModuleP" +
                "age;customAlertFieldsButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertDescription = ";Alert &description:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;" +
                "alertDescLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertName = ";Alert na&me:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;alertNa" +
                "meLabel.Text";
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertSuppression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSuppression;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Priority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPriority;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Severity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeverity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheInformationThatWillBeGeneratedByTheAlert
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheInformationThatWillBeGeneratedByTheAlert;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomAlertFields
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomAlertFields;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertName;
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    
                    return cachedTab0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSuppression translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSuppression
            {
                get
                {
                    if ((cachedAlertSuppression == null))
                    {
                        cachedAlertSuppression = CoreManager.MomConsole.GetIntlStr(ResourceAlertSuppression);
                    }
                    
                    return cachedAlertSuppression;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Priority translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Severity translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
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
            /// Exposes access to the SpecifyTheInformationThatWillBeGeneratedByTheAlert translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheInformationThatWillBeGeneratedByTheAlert
            {
                get
                {
                    if ((cachedSpecifyTheInformationThatWillBeGeneratedByTheAlert == null))
                    {
                        cachedSpecifyTheInformationThatWillBeGeneratedByTheAlert = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheInformationThatWillBeGeneratedByTheAlert);
                    }
                    
                    return cachedSpecifyTheInformationThatWillBeGeneratedByTheAlert;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomAlertFields translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomAlertFields
            {
                get
                {
                    if ((cachedCustomAlertFields == null))
                    {
                        cachedCustomAlertFields = CoreManager.MomConsole.GetIntlStr(ResourceCustomAlertFields);
                    }
                    
                    return cachedCustomAlertFields;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertDescription
            {
                get
                {
                    if ((cachedAlertDescription == null))
                    {
                        cachedAlertDescription = CoreManager.MomConsole.GetIntlStr(ResourceAlertDescription);
                    }
                    
                    return cachedAlertDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertName translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertName
            {
                get
                {
                    if ((cachedAlertName == null))
                    {
                        cachedAlertName = CoreManager.MomConsole.GetIntlStr(ResourceAlertName);
                    }
                    
                    return cachedAlertName;
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
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for AlertSuppressionButton
            /// </summary>
            public const string AlertSuppressionButton = "suppressionBtn";
            
            ///// <summary>
            ///// Control ID for ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
            ///// </summary>
            //public const string ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp = "priorityCombobox";
            
            /// <summary>
            /// Control ID for PriorityStaticControl
            /// </summary>
            public const string PriorityStaticControl = "priorityLabel";
            
            /// <summary>
            /// Control ID for SeverityComboBox
            /// </summary>
            public const string SeverityComboBox = "severityCombobox";
            
            /// <summary>
            /// Control ID for SeverityStaticControl
            /// </summary>
            public const string SeverityStaticControl = "severityLabel";
            
            /// <summary>
            /// Control ID for SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl
            /// </summary>
            public const string SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for CustomAlertFieldsButton
            /// </summary>
            public const string CustomAlertFieldsButton = "customAlertFieldsButton";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "alertDescriptionFlyoutButton";
            
            /// <summary>
            /// Control ID for RuleCategoryTextBox
            /// </summary>
            public const string RuleCategoryTextBox = "alertDescriptionTextbox";
            
            ///// <summary>
            ///// Control ID for ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp
            ///// </summary>
            //public const string ARuleContainsOneOrMoreDataSourcesAnOptionalConditionAndOneOrMoreResponsesYouCanAddNewResponsesAndApp = "alertNameTextbox";
            
            /// <summary>
            /// Control ID for AlertDescriptionStaticControl
            /// </summary>
            public const string AlertDescriptionStaticControl = "alertDescriptionLabel";
            
            /// <summary>
            /// Control ID for AlertNameStaticControl
            /// </summary>
            public const string AlertNameStaticControl = "alertNameLabel";
        }
        #endregion
    }
}
