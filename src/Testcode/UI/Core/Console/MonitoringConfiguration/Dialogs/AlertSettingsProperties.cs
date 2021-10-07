// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertSettingsProperties.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Alert Settings property page (Monitors)
// </summary>
// <history>
// 	[ruhim] 6/5/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common; 
    
    #region Interface Definition - IAlertSettingsPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertSettingsPropertiesControls, for AlertSettingsProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 6/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertSettingsPropertiesControls
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
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
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
        /// Read-only property to access AlertDescriptionTextBox
        /// </summary>
        TextBox AlertDescriptionTextBox
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
        /// Read-only property to access AlertNameTextBox
        /// </summary>
        TextBox AlertNameTextBox
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
        /// Read-only property to access AlertPropertiesStaticControl
        /// </summary>
        StaticControl AlertPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertSettingsStaticControl
        /// </summary>
        StaticControl AlertSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateAlertsCheckBox
        /// </summary>
        CheckBox GenerateAlertsCheckBox
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
        /// Read-only property to access AutomaticallyResolveAlertCheckBox
        /// </summary>
        CheckBox AutomaticallyResolveAlertCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateAnAlertWhenComboBox
        /// </summary>
        ComboBox GenerateAnAlertWhenComboBox
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
        
        /// <summary>
        /// Read-only property to access GenerateAnAlertWhenStaticControl
        /// </summary>
        StaticControl GenerateAnAlertWhenStaticControl
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
    /// 	[ruhim] 6/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertSettingsProperties : Dialog, IAlertSettingsPropertiesControls
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
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to AlertDescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedAlertDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AlertDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedAlertNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AlertNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SeverityComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSeverityComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SeverityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSeverityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GenerateAlertsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedGenerateAlertsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to PriorityComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPriorityComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AutomaticallyResolveAlertCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAutomaticallyResolveAlertCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to GenerateAnAlertWhenComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedGenerateAnAlertWhenComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPriorityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GenerateAnAlertWhenStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGenerateAnAlertWhenStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertSettingsProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertSettingsProperties(Maui.Core.App app)
            :
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IAlertSettingsProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertSettingsPropertiesControls Controls
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
        ///  Property to handle checkbox GenerateAlertsForThisMonitor
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool GenerateAlertsCheckBox
        {
            get
            {
                return this.Controls.GenerateAlertsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.GenerateAlertsCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox AutomaticallyResolveAlert
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool AutomaticallyResolveAlert
        {
            get
            {
                return this.Controls.AutomaticallyResolveAlertCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AutomaticallyResolveAlertCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Members
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AlertDescriptionText
        {
            get
            {
                return this.Controls.AlertDescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.AlertDescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TheHealthStateIsDeterminedBy
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AlertNameText
        {
            get
            {
                return this.Controls.AlertNameTextBox.Text;
            }
            
            set
            {
                this.Controls.AlertNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Severity
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
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
        ///  Routine to set/get the text in control Priority
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GenerateAnAlertWhen
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GenerateAnAlertWhenText
        {
            get
            {
                return this.Controls.GenerateAnAlertWhenComboBox.Text;
            }
            
            set
            {
                this.Controls.GenerateAnAlertWhenComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertSettingsPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertSettingsProperties.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertSettingsPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertSettingsProperties.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertSettingsPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertSettingsProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertSettingsPropertiesControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, AlertSettingsProperties.ControlIDs.Tab2TabControl);
                }
                return this.cachedTab2TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertSettingsPropertiesControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, AlertSettingsProperties.ControlIDs.Button1);
                }
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        ///     [a-joelj]   28OCT09 Maui 2.0: Modified to use QID in TextBox constructor
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertSettingsPropertiesControls.AlertDescriptionTextBox
        {
            get
            {
                if ((this.cachedAlertDescriptionTextBox == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the TextBox constructor using 'this' and the 
                    // ControlId instead of using a QID is returning the wrong TextBox or no TextBox at all. 
                    // Modified to use a QID in the UIA tree for matching with the TextBox AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId='" + AlertSettingsProperties.ControlIDs.AlertDescriptionTextBox + "'");

                    this.cachedAlertDescriptionTextBox = new TextBox(this, queryId, Common.Constants.DefaultContextMenuTimeout);
                }
                return this.cachedAlertDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertSettingsPropertiesControls.AlertDescriptionStaticControl
        {
            get
            {
                if ((this.cachedAlertDescriptionStaticControl == null))
                {
                    this.cachedAlertDescriptionStaticControl = new StaticControl(this, AlertSettingsProperties.ControlIDs.AlertDescriptionStaticControl);
                }
                return this.cachedAlertDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertSettingsPropertiesControls.AlertNameTextBox
        {
            get
            {
                if ((this.cachedAlertNameTextBox == null))
                {
                    this.cachedAlertNameTextBox = new TextBox(this, AlertSettingsProperties.ControlIDs.AlertNameTextBox);
                }
                return this.cachedAlertNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertSettingsPropertiesControls.AlertNameStaticControl
        {
            get
            {
                if ((this.cachedAlertNameStaticControl == null))
                {
                    this.cachedAlertNameStaticControl = new StaticControl(this, AlertSettingsProperties.ControlIDs.AlertNameStaticControl);
                }
                return this.cachedAlertNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertSettingsPropertiesControls.SeverityComboBox
        {
            get
            {
                if ((this.cachedSeverityComboBox == null))
                {
                    this.cachedSeverityComboBox = new ComboBox(this, AlertSettingsProperties.ControlIDs.SeverityComboBox);
                }
                return this.cachedSeverityComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertSettingsPropertiesControls.SeverityStaticControl
        {
            get
            {
                if ((this.cachedSeverityStaticControl == null))
                {
                    this.cachedSeverityStaticControl = new StaticControl(this, AlertSettingsProperties.ControlIDs.SeverityStaticControl);
                }
                return this.cachedSeverityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertSettingsPropertiesControls.AlertPropertiesStaticControl
        {
            get
            {
                if ((this.cachedAlertPropertiesStaticControl == null))
                {
                    this.cachedAlertPropertiesStaticControl = new StaticControl(this, AlertSettingsProperties.ControlIDs.AlertPropertiesStaticControl);
                }
                return this.cachedAlertPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertSettingsPropertiesControls.AlertSettingsStaticControl
        {
            get
            {
                if ((this.cachedAlertSettingsStaticControl == null))
                {
                    this.cachedAlertSettingsStaticControl = new StaticControl(this, AlertSettingsProperties.ControlIDs.AlertSettingsStaticControl);
                }
                return this.cachedAlertSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateAlertsCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAlertSettingsPropertiesControls.GenerateAlertsCheckBox
        {
            get
            {
                if ((this.cachedGenerateAlertsCheckBox == null))
                {
                    this.cachedGenerateAlertsCheckBox = new CheckBox(this, AlertSettingsProperties.ControlIDs.GenerateAlertsCheckBox);
                }
                return this.cachedGenerateAlertsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertSettingsPropertiesControls.PriorityComboBox
        {
            get
            {
                if ((this.cachedPriorityComboBox == null))
                {
                    this.cachedPriorityComboBox = new ComboBox(this, AlertSettingsProperties.ControlIDs.PriorityComboBox);
                }
                return this.cachedPriorityComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomaticallyResolveAlertCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAlertSettingsPropertiesControls.AutomaticallyResolveAlertCheckBox
        {
            get
            {
                if ((this.cachedAutomaticallyResolveAlertCheckBox == null))
                {
                    this.cachedAutomaticallyResolveAlertCheckBox = new CheckBox(this, AlertSettingsProperties.ControlIDs.AutomaticallyResolveAlertCheckBox);
                }
                return this.cachedAutomaticallyResolveAlertCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateAnAlertWhenComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertSettingsPropertiesControls.GenerateAnAlertWhenComboBox
        {
            get
            {
                if ((this.cachedGenerateAnAlertWhenComboBox == null))
                {
                    this.cachedGenerateAnAlertWhenComboBox = new ComboBox(this, AlertSettingsProperties.ControlIDs.GenerateAnAlertWhenComboBox);
                }
                return this.cachedGenerateAnAlertWhenComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertSettingsPropertiesControls.PriorityStaticControl
        {
            get
            {
                if ((this.cachedPriorityStaticControl == null))
                {
                    this.cachedPriorityStaticControl = new StaticControl(this, AlertSettingsProperties.ControlIDs.PriorityStaticControl);
                }
                return this.cachedPriorityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateAnAlertWhenStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertSettingsPropertiesControls.GenerateAnAlertWhenStaticControl
        {
            get
            {
                if ((this.cachedGenerateAnAlertWhenStaticControl == null))
                {
                    this.cachedGenerateAnAlertWhenStaticControl = new StaticControl(this, AlertSettingsProperties.ControlIDs.GenerateAnAlertWhenStaticControl);
                }
                return this.cachedGenerateAnAlertWhenStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
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
        /// 	[ruhim] 6/5/2007 Created
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
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GenerateAlerts
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGenerateAlerts()
        {
            this.Controls.GenerateAlertsCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AutomaticallyResolveAlert
        /// </summary>
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAutomaticallyResolveAlert()
        {
            this.Controls.AutomaticallyResolveAlertCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 10;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);

                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);

                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }

                }

                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
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
        /// 	[ruhim] 6/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle =
                ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Tab title Alerting
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertingTabTitle =
                ";Alerting;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;TabTitle";

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
            /// Contains resource string for:  Tab2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab2 = "Tab2";
            
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
            /// Contains resource string for:  Severity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeverity = ";&Severity:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;severityL" +
                "abel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertProperties = ";Alert properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;pag" +
                "eSectionLabel2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSettings = ";Alert settings;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;pageS" +
                "ectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GenerateAlertsForThisMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGenerateAlertsForThisMonitor = ";&Generate alerts for this monitor;ManagedString;Microsoft.EnterpriseManagement.U" +
                "I.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alert" +
                "Configuration;generateAlertCheckBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState = ";A&utomatically resolve the alert when the monitor returns to a healthy state;Man" +
                "agedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.AlertConfiguration;autoResolveCheckbox.Tex" +
                "t";
            
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
            /// Contains resource string for:  GenerateAnAlertWhen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGenerateAnAlertWhen = ";Generate an alert &when:;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfigura" +
                "tion;generateAlertLabel.Text";
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
            /// Caches the translated resource the Tab title Alerting
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertingTabTitle;
            
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
            /// Caches the translated resource string for:  Tab2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab2;
            
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
            /// Caches the translated resource string for:  Severity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeverity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GenerateAlertsForThisMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGenerateAlertsForThisMonitor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Priority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPriority;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GenerateAnAlertWhen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGenerateAnAlertWhen;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
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
            /// Exposes access to the Tab title Alerting translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertingTabTitle
            {
                get
                {
                    if ((cachedAlertingTabTitle == null))
                    {
                        cachedAlertingTabTitle = CoreManager.MomConsole.GetIntlStr(ResourceAlertingTabTitle);
                    }
                    return cachedAlertingTabTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
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
            /// 	[ruhim] 6/5/2007 Created
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
            /// 	[ruhim] 6/5/2007 Created
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
            /// Exposes access to the Tab2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab2
            {
                get
                {
                    if ((cachedTab2 == null))
                    {
                        cachedTab2 = CoreManager.MomConsole.GetIntlStr(ResourceTab2);
                    }
                    return cachedTab2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
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
            /// 	[ruhim] 6/5/2007 Created
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
            /// Exposes access to the Severity translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
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
            /// Exposes access to the AlertProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertProperties
            {
                get
                {
                    if ((cachedAlertProperties == null))
                    {
                        cachedAlertProperties = CoreManager.MomConsole.GetIntlStr(ResourceAlertProperties);
                    }
                    return cachedAlertProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSettings
            {
                get
                {
                    if ((cachedAlertSettings == null))
                    {
                        cachedAlertSettings = CoreManager.MomConsole.GetIntlStr(ResourceAlertSettings);
                    }
                    return cachedAlertSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GenerateAlertsForThisMonitor translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GenerateAlertsForThisMonitor
            {
                get
                {
                    if ((cachedGenerateAlertsForThisMonitor == null))
                    {
                        cachedGenerateAlertsForThisMonitor = CoreManager.MomConsole.GetIntlStr(ResourceGenerateAlertsForThisMonitor);
                    }
                    return cachedGenerateAlertsForThisMonitor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState
            {
                get
                {
                    if ((cachedAutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState == null))
                    {
                        cachedAutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState = CoreManager.MomConsole.GetIntlStr(ResourceAutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState);
                    }
                    return cachedAutomaticallyResolveTheAlertWhenTheMonitorReturnsToAHealthyState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Priority translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
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
            /// Exposes access to the GenerateAnAlertWhen translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 6/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GenerateAnAlertWhen
            {
                get
                {
                    if ((cachedGenerateAnAlertWhen == null))
                    {
                        cachedGenerateAnAlertWhen = CoreManager.MomConsole.GetIntlStr(ResourceGenerateAnAlertWhen);
                    }
                    return cachedGenerateAnAlertWhen;
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
        /// 	[ruhim] 6/5/2007 Created
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
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "flyoutBtn";
            
            /// <summary>
            /// Control ID for AlertDescriptionTextBox
            /// </summary>
            public const string AlertDescriptionTextBox = "descriptionTextBox";
            
            /// <summary>
            /// Control ID for AlertDescriptionStaticControl
            /// </summary>
            public const string AlertDescriptionStaticControl = "alertDescLabel";
            
            /// <summary>
            /// Control ID for AlertNameTextBox
            /// </summary>
            public const string AlertNameTextBox = "nameTextbox";
            
            /// <summary>
            /// Control ID for AlertNameStaticControl
            /// </summary>
            public const string AlertNameStaticControl = "alertNameLabel";
            
            /// <summary>
            /// Control ID for SeverityComboBox
            /// </summary>
            public const string SeverityComboBox = "severityComboBox";
            
            /// <summary>
            /// Control ID for SeverityStaticControl
            /// </summary>
            public const string SeverityStaticControl = "severityLabel";
            
            /// <summary>
            /// Control ID for AlertPropertiesStaticControl
            /// </summary>
            public const string AlertPropertiesStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for AlertSettingsStaticControl
            /// </summary>
            public const string AlertSettingsStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for GenerateAlertsCheckBox
            /// </summary>
            public const string GenerateAlertsCheckBox = "generateAlertCheckBox";
            
            /// <summary>
            /// Control ID for PriorityComboBox
            /// </summary>
            public const string PriorityComboBox = "priorityCombobox";
            
            /// <summary>
            /// Control ID for AutomaticallyResolveAlertCheckBox
            /// </summary>
            public const string AutomaticallyResolveAlertCheckBox = "autoResolveCheckbox";
            
            /// <summary>
            /// Control ID for GenerateAnAlertWhenComboBox
            /// </summary>
            public const string GenerateAnAlertWhenComboBox = "generateAlertCombobox";
            
            /// <summary>
            /// Control ID for PriorityStaticControl
            /// </summary>
            public const string PriorityStaticControl = "priorityLabel";
            
            /// <summary>
            /// Control ID for GenerateAnAlertWhenStaticControl
            /// </summary>
            public const string GenerateAnAlertWhenStaticControl = "generateAlertLabel";
        }
        #endregion
    }
}
