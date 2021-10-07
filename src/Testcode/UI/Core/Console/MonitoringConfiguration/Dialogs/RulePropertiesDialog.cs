// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RulePropertiesDialog.cs">
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
    
    #region Interface Definition - IRulePropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRulePropertiesDialogControls, for RulePropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 6/1/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRulePropertiesDialogControls
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
        /// Read-only property to access DefaultManagementPackComboBox
        /// </summary>
        ComboBox DefaultManagementPackComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleCategoryStaticControl
        /// </summary>
        StaticControl RuleCategoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DefaultManagementPackStaticControl
        /// </summary>
        StaticControl DefaultManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackStaticControl
        /// </summary>
        StaticControl ManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectButton
        /// </summary>
        Button SelectButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleTargetTextBox
        /// </summary>
        TextBox RuleTargetTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleTargetStaticControl
        /// </summary>
        StaticControl RuleTargetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectRuleNameDescriptionAndTargetStaticControl
        /// </summary>
        StaticControl SelectRuleNameDescriptionAndTargetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleIsEnabledCheckBox
        /// </summary>
        CheckBox RuleIsEnabledCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionOptionalTextBox
        /// </summary>
        TextBox DescriptionOptionalTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionOptionalStaticControl
        /// </summary>
        StaticControl DescriptionOptionalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleNameTextBox
        /// </summary>
        TextBox RuleNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleNameStaticControl
        /// </summary>
        StaticControl RuleNameStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Edit button in Properties dialog->Configuration tab
        /// </summary>
        Button EditDSButton
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
    public class RulePropertiesDialog : Dialog, IRulePropertiesDialogControls
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
        /// Cache to hold a reference to DefaultManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDefaultManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RuleCategoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleCategoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DefaultManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefaultManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectButton of type Button
        /// </summary>
        private Button cachedSelectButton;
        
        /// <summary>
        /// Cache to hold a reference to RuleTargetTextBox of type TextBox
        /// </summary>
        private TextBox cachedRuleTargetTextBox;
        
        /// <summary>
        /// Cache to hold a reference to RuleTargetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleTargetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectRuleNameDescriptionAndTargetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectRuleNameDescriptionAndTargetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RuleIsEnabledCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedRuleIsEnabledCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionOptionalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RuleNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedRuleNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to RuleNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleNameStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RulePropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RulePropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRulePropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRulePropertiesDialogControls Controls
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
        ///  Property to handle checkbox RuleIsEnabled
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool RuleIsEnabled
        {
            get
            {
                return this.Controls.RuleIsEnabledCheckBox.Checked;
            }
            
            set
            {
                this.Controls.RuleIsEnabledCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DefaultManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DefaultManagementPackText
        {
            get
            {
                return this.Controls.DefaultManagementPackComboBox.Text;
            }
            
            set
            {
                this.Controls.DefaultManagementPackComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RuleTarget
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RuleTargetText
        {
            get
            {
                return this.Controls.RuleTargetTextBox.Text;
            }
            
            set
            {
                this.Controls.RuleTargetTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DescriptionOptional
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionOptionalText
        {
            get
            {
                return this.Controls.DescriptionOptionalTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionOptionalTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RuleName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RuleNameText
        {
            get
            {
                return this.Controls.RuleNameTextBox.Text;
            }
            
            set
            {
                this.Controls.RuleNameTextBox.Text = value;
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
        Button IRulePropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, RulePropertiesDialog.ControlIDs.ApplyButton);
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
        Button IRulePropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RulePropertiesDialog.ControlIDs.CancelButton);
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
        Button IRulePropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RulePropertiesDialog.ControlIDs.OKButton);
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
        TabControl IRulePropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, RulePropertiesDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRulePropertiesDialogControls.DefaultManagementPackComboBox
        {
            get
            {
                if ((this.cachedDefaultManagementPackComboBox == null))
                {
                    this.cachedDefaultManagementPackComboBox = new ComboBox(this, RulePropertiesDialog.ControlIDs.DefaultManagementPackComboBox);
                }
                
                return this.cachedDefaultManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleCategoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRulePropertiesDialogControls.RuleCategoryStaticControl
        {
            get
            {
                if ((this.cachedRuleCategoryStaticControl == null))
                {
                    this.cachedRuleCategoryStaticControl = new StaticControl(this, RulePropertiesDialog.ControlIDs.RuleCategoryStaticControl);
                }
                
                return this.cachedRuleCategoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRulePropertiesDialogControls.DefaultManagementPackStaticControl
        {
            get
            {
                if ((this.cachedDefaultManagementPackStaticControl == null))
                {
                    this.cachedDefaultManagementPackStaticControl = new StaticControl(this, RulePropertiesDialog.ControlIDs.DefaultManagementPackStaticControl);
                }
                
                return this.cachedDefaultManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRulePropertiesDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, RulePropertiesDialog.ControlIDs.ManagementPackStaticControl);
                }
                
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRulePropertiesDialogControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, RulePropertiesDialog.ControlIDs.SelectButton);
                }
                
                return this.cachedSelectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTargetTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRulePropertiesDialogControls.RuleTargetTextBox
        {
            get
            {
                if ((this.cachedRuleTargetTextBox == null))
                {
                    this.cachedRuleTargetTextBox = new TextBox(this, RulePropertiesDialog.ControlIDs.RuleTargetTextBox);
                }
                
                return this.cachedRuleTargetTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTargetStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRulePropertiesDialogControls.RuleTargetStaticControl
        {
            get
            {
                if ((this.cachedRuleTargetStaticControl == null))
                {
                    this.cachedRuleTargetStaticControl = new StaticControl(this, RulePropertiesDialog.ControlIDs.RuleTargetStaticControl);
                }
                
                return this.cachedRuleTargetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectRuleNameDescriptionAndTargetStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRulePropertiesDialogControls.SelectRuleNameDescriptionAndTargetStaticControl
        {
            get
            {
                if ((this.cachedSelectRuleNameDescriptionAndTargetStaticControl == null))
                {
                    this.cachedSelectRuleNameDescriptionAndTargetStaticControl = new StaticControl(this, RulePropertiesDialog.ControlIDs.SelectRuleNameDescriptionAndTargetStaticControl);
                }
                
                return this.cachedSelectRuleNameDescriptionAndTargetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleIsEnabledCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IRulePropertiesDialogControls.RuleIsEnabledCheckBox
        {
            get
            {
                if ((this.cachedRuleIsEnabledCheckBox == null))
                {
                    this.cachedRuleIsEnabledCheckBox = new CheckBox(this, RulePropertiesDialog.ControlIDs.RuleIsEnabledCheckBox);
                }
                
                return this.cachedRuleIsEnabledCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRulePropertiesDialogControls.DescriptionOptionalTextBox
        {
            get
            {
                if ((this.cachedDescriptionOptionalTextBox == null))
                {
                    this.cachedDescriptionOptionalTextBox = new TextBox(this, RulePropertiesDialog.ControlIDs.DescriptionOptionalTextBox);
                }
                
                return this.cachedDescriptionOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRulePropertiesDialogControls.DescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedDescriptionOptionalStaticControl == null))
                {
                    this.cachedDescriptionOptionalStaticControl = new StaticControl(this, RulePropertiesDialog.ControlIDs.DescriptionOptionalStaticControl);
                }
                
                return this.cachedDescriptionOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleNameTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRulePropertiesDialogControls.RuleNameTextBox
        {
            get
            {
                if ((this.cachedRuleNameTextBox == null))
                {
                    this.cachedRuleNameTextBox = new TextBox(this, RulePropertiesDialog.ControlIDs.RuleNameTextBox);
                }
                
                return this.cachedRuleNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRulePropertiesDialogControls.RuleNameStaticControl
        {
            get
            {
                if ((this.cachedRuleNameStaticControl == null))
                {
                    this.cachedRuleNameStaticControl = new StaticControl(this, RulePropertiesDialog.ControlIDs.RuleNameStaticControl);
                }
                
                return this.cachedRuleNameStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditDSButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 5/17/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRulePropertiesDialogControls.EditDSButton
        {
            get
            {
                return new Button(this, new QID(@";[UIA, VisibleOnly]AutomationId='" + ControlIDs.EditDSButton + "'"), Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout);
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
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelect()
        {
            this.Controls.SelectButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RuleIsEnabled
        /// </summary>
        /// <history>
        /// 	[dialac] 6/1/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRuleIsEnabled()
        {
            this.Controls.RuleIsEnabledCheckBox.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on Edit button
        /// </summary>
        /// <history>
        /// 	[v-vijia] 5/17/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEditDSButton()
        {
            this.Controls.EditDSButton.Click();
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
                int maxTries = 10;

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
            //private const string ResourceDialogTitle = "WMIRUle Properties";
            //public const string ResourceDialogTitle = ";{0} Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;MPObjectFormatString";
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
            /// Contains resource string for:  RuleCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleCategory = ";Rule Category:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleGeneralPage;ruleCate" +
                "goryLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultManagementPack = ";Default Management Pack;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.Internal.UI.Common.MPHelper;DefaultManagementPackFriendlyNa" +
                "me";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management Pack:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiscoveryGeneralPage;m" +
                "plabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelect = ";&Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;browseBut" +
                "ton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleTarget = ";Rule tar&get:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleGeneralPage;targetLab" +
                "el.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectRuleNameDescriptionAndTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectRuleNameDescriptionAndTarget = ";Select rule name, description and target;ManagedString;Microsoft.EnterpriseManag" +
                "ement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Page" +
                "s.RuleGeneralPage;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleIsEnabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleIsEnabled = ";Rule is &enabled;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleGeneralPage;enable" +
                "dCheckbox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescriptionOptional = ";Des&cription (Optional):;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiscoveryGener" +
                "alPage;descriptionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleName = ";Rule na&me:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleGeneralPage;nameLabel.T" +
                "ext";
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
            /// Caches the translated resource string for:  RuleCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleCategory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DefaultManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelect;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RuleTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectRuleNameDescriptionAndTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectRuleNameDescriptionAndTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RuleIsEnabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleIsEnabled;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescriptionOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RuleName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleName;
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
            /// Exposes access to the RuleCategory translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleCategory
            {
                get
                {
                    if ((cachedRuleCategory == null))
                    {
                        cachedRuleCategory = CoreManager.MomConsole.GetIntlStr(ResourceRuleCategory);
                    }
                    
                    return cachedRuleCategory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultManagementPack
            {
                get
                {
                    if ((cachedDefaultManagementPack == null))
                    {
                        cachedDefaultManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceDefaultManagementPack);
                    }
                    
                    return cachedDefaultManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPack
            {
                get
                {
                    if ((cachedManagementPack == null))
                    {
                        cachedManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceManagementPack);
                    }
                    
                    return cachedManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Select
            {
                get
                {
                    if ((cachedSelect == null))
                    {
                        cachedSelect = CoreManager.MomConsole.GetIntlStr(ResourceSelect);
                    }
                    
                    return cachedSelect;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RuleTarget translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleTarget
            {
                get
                {
                    if ((cachedRuleTarget == null))
                    {
                        cachedRuleTarget = CoreManager.MomConsole.GetIntlStr(ResourceRuleTarget);
                    }
                    
                    return cachedRuleTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectRuleNameDescriptionAndTarget translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectRuleNameDescriptionAndTarget
            {
                get
                {
                    if ((cachedSelectRuleNameDescriptionAndTarget == null))
                    {
                        cachedSelectRuleNameDescriptionAndTarget = CoreManager.MomConsole.GetIntlStr(ResourceSelectRuleNameDescriptionAndTarget);
                    }
                    
                    return cachedSelectRuleNameDescriptionAndTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RuleIsEnabled translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleIsEnabled
            {
                get
                {
                    if ((cachedRuleIsEnabled == null))
                    {
                        cachedRuleIsEnabled = CoreManager.MomConsole.GetIntlStr(ResourceRuleIsEnabled);
                    }
                    
                    return cachedRuleIsEnabled;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DescriptionOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DescriptionOptional
            {
                get
                {
                    if ((cachedDescriptionOptional == null))
                    {
                        cachedDescriptionOptional = CoreManager.MomConsole.GetIntlStr(ResourceDescriptionOptional);
                    }
                    
                    return cachedDescriptionOptional;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RuleName translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/1/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleName
            {
                get
                {
                    if ((cachedRuleName == null))
                    {
                        cachedRuleName = CoreManager.MomConsole.GetIntlStr(ResourceRuleName);
                    }
                    
                    return cachedRuleName;
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
            /// Control ID for DefaultManagementPackComboBox
            /// </summary>
            public const string DefaultManagementPackComboBox = "ruleCategoryComboBox";
            
            /// <summary>
            /// Control ID for RuleCategoryStaticControl
            /// </summary>
            public const string RuleCategoryStaticControl = "ruleCategoryLabel";
            
            /// <summary>
            /// Control ID for DefaultManagementPackStaticControl
            /// </summary>
            public const string DefaultManagementPackStaticControl = "mpvalueLabel";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "mplabel";
            
            /// <summary>
            /// Control ID for SelectButton
            /// </summary>
            public const string SelectButton = "browseButton";
            
            /// <summary>
            /// Control ID for RuleTargetTextBox
            /// </summary>
            public const string RuleTargetTextBox = "targetBox";
            
            /// <summary>
            /// Control ID for RuleTargetStaticControl
            /// </summary>
            public const string RuleTargetStaticControl = "targetLabel";
            
            /// <summary>
            /// Control ID for SelectRuleNameDescriptionAndTargetStaticControl
            /// </summary>
            public const string SelectRuleNameDescriptionAndTargetStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for RuleIsEnabledCheckBox
            /// </summary>
            public const string RuleIsEnabledCheckBox = "enabledCheckbox";
            
            /// <summary>
            /// Control ID for DescriptionOptionalTextBox
            /// </summary>
            public const string DescriptionOptionalTextBox = "descriptionTextbox";
            
            /// <summary>
            /// Control ID for DescriptionOptionalStaticControl
            /// </summary>
            public const string DescriptionOptionalStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for RuleNameTextBox
            /// </summary>
            public const string RuleNameTextBox = "nameTextbox";
            
            /// <summary>
            /// Control ID for RuleNameStaticControl
            /// </summary>
            public const string RuleNameStaticControl = "nameLabel";

            /// <summary>
            /// Automation ID for Edit button in Properties dialog->Configuration tab
            /// </summary>
            public const string EditDSButton = "editDsBtn";
        }
        #endregion
    }
}
