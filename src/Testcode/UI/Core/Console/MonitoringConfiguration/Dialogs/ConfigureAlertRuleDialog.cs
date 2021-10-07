// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfigureAlertRuleDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 6/9/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IConfigureAlertRuleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfigureAlertRuleDialogControls, for ConfigureAlertRuleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 6/9/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfigureAlertRuleDialogControls
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
        /// Read-only property to access RuleTypeStaticControl
        /// </summary>
        StaticControl RuleTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WMIConfigurationStaticControl
        /// </summary>
        StaticControl WMIConfigurationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAlertsStaticControl
        /// </summary>
        StaticControl ConfigureAlertsStaticControl
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
        
        /// <summary>
        /// Read-only property to access PriorityComboBox
        /// </summary>
        ComboBox PriorityComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PriorityStaticControl
        /// </summary>
        StaticControl PriorityStaticControl
        {
            get;
        }
        
        ///// <summary>
        ///// Read-only property to access [NotUsed]ComboBox
        ///// </summary>
        //ComboBox [NotUsed]ComboBox
        //{
        //    get;
        //}
        
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
        /// Read-only property to access AlertDescriptionFlyOutButton
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button AlertDescriptionFlyOutButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponsesTextBox
        /// </summary>
        TextBox ResponsesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAlertsTextBox
        /// </summary>
        TextBox ConfigureAlertsTextBox
        {
            get;
        }
        
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
        
        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAlertsStaticControl2
        /// </summary>
        StaticControl ConfigureAlertsStaticControl2
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
    /// 	[dialac] 6/9/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfigureAlertRuleDialog : Dialog, IConfigureAlertRuleDialogControls
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
        /// Cache to hold a reference to RuleTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WMIConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWMIConfigurationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertSuppressionButton of type Button
        /// </summary>
        private Button cachedAlertSuppressionButton;
        
        /// <summary>
        /// Cache to hold a reference to PriorityComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPriorityComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPriorityStaticControl;
        
        ///// <summary>
        ///// Cache to hold a reference to [NotUsed]ComboBox of type ComboBox
        ///// </summary>
        //private ComboBox cached[NotUsed]ComboBox;
        
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
        /// Cache to hold a reference to AlertDescriptionFlyOutButton of type Button
        /// </summary>
        private Button cachedAlertDescriptionFlyOutButton;
        
        /// <summary>
        /// Cache to hold a reference to ResponsesTextBox of type TextBox
        /// </summary>
        private TextBox cachedResponsesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsTextBox of type TextBox
        /// </summary>
        private TextBox cachedConfigureAlertsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AlertDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfigureAlertRuleDialog of type MomConsoleApp
        /// </param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfigureAlertRuleDialog(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Common.Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IConfigureAlertRuleDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfigureAlertRuleDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Priority
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PriorityText
        {
            get
            {
                return this.Controls.PriorityComboBox.Text;
            }
            
            set
            {
                this.Controls.PriorityComboBox.SelectByText(value, true);
            }
        }
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Routine to set/get the text in control [NotUsed]
        ///// </summary>
        ///// <value>TODO: specify the value</value>
        ///// <history>
        ///// 	[dialac] 6/9/2008 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //public virtual string [NotUsed]Text
        //{
        //    get
        //    {
        //        return this.Controls.[NotUsed]ComboBox.Text;
        //    }
            
        //    set
        //    {
        //        this.Controls.[NotUsed]ComboBox.SelectByText(value, true);
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Responses
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ResponsesText
        {
            get
            {
                return this.Controls.ResponsesTextBox.Text;
            }
            
            set
            {
                this.Controls.ResponsesTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ConfigureAlerts
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConfigureAlertsText
        {
            get
            {
                return this.Controls.ConfigureAlertsTextBox.Text;
            }
            
            set
            {
                this.Controls.ConfigureAlertsTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertRuleDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ConfigureAlertRuleDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertRuleDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ConfigureAlertRuleDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertRuleDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ConfigureAlertRuleDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertRuleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConfigureAlertRuleDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, ConfigureAlertRuleDialog.ControlIDs.RuleTypeStaticControl);
                }
                
                return this.cachedRuleTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WMIConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.WMIConfigurationStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedWMIConfigurationStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedWMIConfigurationStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedWMIConfigurationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureAlertsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedConfigureAlertsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertSuppressionButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertRuleDialogControls.AlertSuppressionButton
        {
            get
            {
                if ((this.cachedAlertSuppressionButton == null))
                {
                    this.cachedAlertSuppressionButton = new Button(this, ConfigureAlertRuleDialog.ControlIDs.AlertSuppressionButton);
                }
                
                return this.cachedAlertSuppressionButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IConfigureAlertRuleDialogControls.PriorityComboBox
        {
            get
            {
                if ((this.cachedPriorityComboBox == null))
                {
                    this.cachedPriorityComboBox = new ComboBox(this, ConfigureAlertRuleDialog.ControlIDs.PriorityComboBox);
                }
                
                return this.cachedPriorityComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.PriorityStaticControl
        {
            get
            {
                if ((this.cachedPriorityStaticControl == null))
                {
                    this.cachedPriorityStaticControl = new StaticControl(this, ConfigureAlertRuleDialog.ControlIDs.PriorityStaticControl);
                }
                
                return this.cachedPriorityStaticControl;
            }
        }
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Exposes access to the [NotUsed]ComboBox control
        ///// </summary>
        ///// <history>
        ///// 	[dialac] 6/9/2008 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //ComboBox IConfigureAlertRuleDialogControls.[NotUsed]ComboBox
        //{
        //    get
        //    {
        //        if ((this.cached[NotUsed]ComboBox == null))
        //        {
        //            this.cached[NotUsed]ComboBox = new ComboBox(this, ConfigureAlertRuleDialog.ControlIDs.[NotUsed]ComboBox);
        //        }
                
        //        return this.cached[NotUsed]ComboBox;
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.SeverityStaticControl
        {
            get
            {
                if ((this.cachedSeverityStaticControl == null))
                {
                    this.cachedSeverityStaticControl = new StaticControl(this, ConfigureAlertRuleDialog.ControlIDs.SeverityStaticControl);
                }
                
                return this.cachedSeverityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl == null))
                {
                    this.cachedSpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl = new StaticControl(this, ConfigureAlertRuleDialog.ControlIDs.SpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl);
                }
                
                return this.cachedSpecifyTheInformationThatWillBeGeneratedByTheAlertStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomAlertFieldsButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertRuleDialogControls.CustomAlertFieldsButton
        {
            get
            {
                if ((this.cachedCustomAlertFieldsButton == null))
                {
                    this.cachedCustomAlertFieldsButton = new Button(this, ConfigureAlertRuleDialog.ControlIDs.CustomAlertFieldsButton);
                }
                
                return this.cachedCustomAlertFieldsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionFlyOutButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertRuleDialogControls.AlertDescriptionFlyOutButton
        {
            get
            {
                if ((this.cachedAlertDescriptionFlyOutButton == null))
                {
                    this.cachedAlertDescriptionFlyOutButton = new Button(this, ConfigureAlertRuleDialog.ControlIDs.AlertDescriptionFlyOutButton);
                }
                
                return this.cachedAlertDescriptionFlyOutButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponsesTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConfigureAlertRuleDialogControls.ResponsesTextBox
        {
            get
            {
                if ((this.cachedResponsesTextBox == null))
                {
                    this.cachedResponsesTextBox = new TextBox(this, ConfigureAlertRuleDialog.ControlIDs.ResponsesTextBox);
                }
                
                return this.cachedResponsesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConfigureAlertRuleDialogControls.ConfigureAlertsTextBox
        {
            get
            {
                if ((this.cachedConfigureAlertsTextBox == null))
                {
                    this.cachedConfigureAlertsTextBox = new TextBox(this, ConfigureAlertRuleDialog.ControlIDs.ConfigureAlertsTextBox);
                }
                
                return this.cachedConfigureAlertsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.AlertDescriptionStaticControl
        {
            get
            {
                if ((this.cachedAlertDescriptionStaticControl == null))
                {
                    this.cachedAlertDescriptionStaticControl = new StaticControl(this, ConfigureAlertRuleDialog.ControlIDs.AlertDescriptionStaticControl);
                }
                
                return this.cachedAlertDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.AlertNameStaticControl
        {
            get
            {
                if ((this.cachedAlertNameStaticControl == null))
                {
                    this.cachedAlertNameStaticControl = new StaticControl(this, ConfigureAlertRuleDialog.ControlIDs.AlertNameStaticControl);
                }
                
                return this.cachedAlertNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ConfigureAlertRuleDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertRuleDialogControls.ConfigureAlertsStaticControl2
        {
            get
            {
                if ((this.cachedConfigureAlertsStaticControl2 == null))
                {
                    this.cachedConfigureAlertsStaticControl2 = new StaticControl(this, ConfigureAlertRuleDialog.ControlIDs.ConfigureAlertsStaticControl2);
                }
                
                return this.cachedConfigureAlertsStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
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
        /// 	[dialac] 6/9/2008 Created
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
        /// 	[dialac] 6/9/2008 Created
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
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AlertSuppression
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
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
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCustomAlertFields()
        {
            this.Controls.CustomAlertFieldsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AlertDescriptionFlyOutButton
        /// </summary>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAlertDescriptionFlyOutButton()
        {
            this.Controls.AlertDescriptionFlyOutButton.Click();
        }
        #endregion
        
       
        //private static Window Init(MomConsoleApp app)
        //{
        //    // First check if the dialog is already up.
        //    Window tempWindow = null;
        //    try
        //    {
        //        // Try to locate an existing instance of a dialog
        //        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
        //    }
        //    catch (Exceptions.WindowNotFoundException windowNotFound)
        //    {
        //        // Reset the window reference
        //        tempWindow = null;

        //        // Maximum number of tries to find window
        //        int maxTries = 5;

        //        // Try several more times to find the window
        //        for (int numberOfTries = 0; ((null == tempWindow) 
        //                    && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
        //        {
        //            try
        //            {
        //                // Try to locate an existing instance of the window
        //                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

        //                // Wait for the window to become ready
        //                UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
        //            }
        //            catch (Exceptions.WindowNotFoundException )
        //            {
        //                // log the unsuccessful attempt

        //                // wait for a moment before trying again
        //                Maui.Core.Utilities.Sleeper.Delay(Timeout);
        //            }
        //        }
                
        //        // check for success
        //        if ((null == tempWindow))
        //        {
        //            // log the failure

        //            // rethrow the original exception
        //            throw windowNotFound;
        //        }
        //    }
            
        //    return tempWindow;
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[dialac] 6/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
        {
            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
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
                                DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[dialac] 6/9/2008 Created
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
            private const string ResourceDialogTitle = "Create Rule Wizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleType = ";Rule Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseRuleTypePage;$this.Navi" +
                "gationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WMIConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWMIConfiguration = ";WMI Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;$this.T" +
                "abName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$th" +
                "is.NavigationText";
            
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;HelpSubFold" +
                "erName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts2 = ";Configure Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$th" +
                "is.NavigationText";
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
            /// Caches the translated resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WMIConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIConfiguration;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;
            
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// Exposes access to the RuleType translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleType
            {
                get
                {
                    if ((cachedRuleType == null))
                    {
                        cachedRuleType = CoreManager.MomConsole.GetIntlStr(ResourceRuleType);
                    }
                    
                    return cachedRuleType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    
                    return cachedGeneral;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMIConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIConfiguration
            {
                get
                {
                    if ((cachedWMIConfiguration == null))
                    {
                        cachedWMIConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceWMIConfiguration);
                    }
                    
                    return cachedWMIConfiguration;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAlerts
            {
                get
                {
                    if ((cachedConfigureAlerts == null))
                    {
                        cachedConfigureAlerts = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAlerts);
                    }
                    
                    return cachedConfigureAlerts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSuppression translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            /// 	[dialac] 6/9/2008 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/9/2008 Created
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
            /// Exposes access to the ConfigureAlerts2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAlerts2
            {
                get
                {
                    if ((cachedConfigureAlerts2 == null))
                    {
                        cachedConfigureAlerts2 = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAlerts2);
                    }
                    
                    return cachedConfigureAlerts2;
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
        /// 	[dialac] 6/9/2008 Created
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
            /// Control ID for RuleTypeStaticControl
            /// </summary>
            public const string RuleTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for WMIConfigurationStaticControl
            /// </summary>
            public const string WMIConfigurationStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AlertSuppressionButton
            /// </summary>
            public const string AlertSuppressionButton = "suppressionBtn";
            
            /// <summary>
            /// Control ID for PriorityComboBox
            /// </summary>
            public const string PriorityComboBox = "priorityCombobox";
            
            /// <summary>
            /// Control ID for PriorityStaticControl
            /// </summary>
            public const string PriorityStaticControl = "priorityLabel";
            
            ///// <summary>
            ///// Control ID for [NotUsed]ComboBox
            ///// </summary>
            //public const string [NotUsed]ComboBox = "severityCombobox";
            
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
            /// Control ID for AlertDescriptionFlyOutButton
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string AlertDescriptionFlyOutButton = "alertDescriptionFlyoutButton";
            
            /// <summary>
            /// Control ID for ResponsesTextBox
            /// </summary>
            public const string ResponsesTextBox = "alertDescriptionTextbox";
            
            /// <summary>
            /// Control ID for ConfigureAlertsTextBox
            /// </summary>
            public const string ConfigureAlertsTextBox = "alertNameTextbox";
            
            /// <summary>
            /// Control ID for AlertDescriptionStaticControl
            /// </summary>
            public const string AlertDescriptionStaticControl = "alertDescriptionLabel";
            
            /// <summary>
            /// Control ID for AlertNameStaticControl
            /// </summary>
            public const string AlertNameStaticControl = "alertNameLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl2
            /// </summary>
            public const string ConfigureAlertsStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
