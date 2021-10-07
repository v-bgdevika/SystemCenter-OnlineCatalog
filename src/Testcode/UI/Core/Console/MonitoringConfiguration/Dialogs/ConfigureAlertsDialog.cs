// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfigureAlertsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 Console
// </project>
// <summary>
// 	Monitor Wizard Configure Alerts Page.
// </summary>
// <history>
// 	[ruhim] 4/13/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common; 

    #region Interface Definition - IConfigureAlertsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfigureAlertsDialogControls, for ConfigureAlertsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfigureAlertsDialogControls
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
        /// Read-only property to access MonitorTypeStaticControl
        /// </summary>
        StaticControl MonitorTypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EventLogTypeStaticControl
        /// </summary>
        StaticControl EventLogTypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access BuildEventExpressionStaticControl
        /// </summary>
        StaticControl BuildEventExpressionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConfigureHealthStaticControl
        /// </summary>
        StaticControl ConfigureHealthStaticControl
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
        /// Read-only property to access KnowledgeStaticControl
        /// </summary>
        StaticControl KnowledgeStaticControl
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

        /// <summary>
        /// Read-only property to access AlertDescriptionTextBox
        /// </summary>
        TextBox AlertDescriptionTextBox
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
        /// Read-only property to access SeverityComboBox
        /// </summary>
        ComboBox SeverityComboBox
        {
            get;
        }


        /// <summary>
        /// Read-only property to access AlertDescriptionButton
        /// </summary>
        Button AlertDescriptionButton
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
    /// 	[ruhim] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfigureAlertsDialog : Dialog, IConfigureAlertsDialogControls
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
        /// Cache to hold a reference to MonitorTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to EventLogTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventLogTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to BuildEventExpressionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildEventExpressionStaticControl;

        /// <summary>
        /// Cache to hold a reference to ConfigureHealthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthStaticControl;

        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;

        /// <summary>
        /// Cache to hold a reference to KnowledgeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKnowledgeStaticControl;

        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;

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

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl2;

        /// <summary>
        /// Cache to hold a reference to AlertDescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedAlertDescriptionTextBox;

        /// <summary>
        /// Cache to hold a reference to AlertNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedAlertNameTextBox;

        /// <summary>
        /// Cache to hold a reference to SeverityComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSeverityComboBox;

        /// <summary>
        /// Cache to hold a reference to AlertDescriptionButton of type Button
        /// </summary>
        private Button cachedAlertDescriptionButton;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfigureAlertsDialog of type App
        /// </param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfigureAlertsDialog(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region IConfigureAlertsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfigureAlertsDialogControls Controls
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
        ///  Property to handle checkbox GenerateAlerts
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool GenerateAlerts
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
        /// 	[ruhim] 4/13/2006 Created
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
        ///  Routine to set/get the text in control Priority
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AlertDescription
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ASTTEST] 10/11/2006 Created
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
        ///  Routine to set/get the text in control AlertName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ASTTEST] 10/11/2006 Created
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
        /// 	[ASTTEST] 10/11/2006 Created
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
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ConfigureAlertsDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ConfigureAlertsDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ConfigureAlertsDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConfigureAlertsDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, ConfigureAlertsDialog.ControlIDs.MonitorTypeStaticControl);
                }
                return this.cachedMonitorTypeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLogTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.EventLogTypeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventLogTypeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedEventLogTypeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedEventLogTypeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildEventExpressionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.BuildEventExpressionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedBuildEventExpressionStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedBuildEventExpressionStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedBuildEventExpressionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.ConfigureHealthStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureHealthStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedConfigureHealthStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureHealthStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
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
        ///  Exposes access to the KnowledgeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.KnowledgeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedKnowledgeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedKnowledgeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedKnowledgeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.AlertPropertiesStaticControl
        {
            get
            {
                if ((this.cachedAlertPropertiesStaticControl == null))
                {
                    this.cachedAlertPropertiesStaticControl = new StaticControl(this, ConfigureAlertsDialog.ControlIDs.AlertPropertiesStaticControl);
                }
                return this.cachedAlertPropertiesStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.AlertSettingsStaticControl
        {
            get
            {
                if ((this.cachedAlertSettingsStaticControl == null))
                {
                    this.cachedAlertSettingsStaticControl = new StaticControl(this, ConfigureAlertsDialog.ControlIDs.AlertSettingsStaticControl);
                }
                return this.cachedAlertSettingsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateAlertsCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IConfigureAlertsDialogControls.GenerateAlertsCheckBox
        {
            get
            {
                if ((this.cachedGenerateAlertsCheckBox == null))
                {
                    this.cachedGenerateAlertsCheckBox = new CheckBox(this, ConfigureAlertsDialog.ControlIDs.GenerateAlertsCheckBox);
                }
                return this.cachedGenerateAlertsCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IConfigureAlertsDialogControls.PriorityComboBox
        {
            get
            {
                if ((this.cachedPriorityComboBox == null))
                {
                    this.cachedPriorityComboBox = new ComboBox(this, ConfigureAlertsDialog.ControlIDs.PriorityComboBox);
                }
                return this.cachedPriorityComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomaticallyResolveAlertCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IConfigureAlertsDialogControls.AutomaticallyResolveAlertCheckBox
        {
            get
            {
                if ((this.cachedAutomaticallyResolveAlertCheckBox == null))
                {
                    this.cachedAutomaticallyResolveAlertCheckBox = new CheckBox(this, ConfigureAlertsDialog.ControlIDs.AutomaticallyResolveAlertCheckBox);
                }
                return this.cachedAutomaticallyResolveAlertCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateAnAlertWhenComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IConfigureAlertsDialogControls.GenerateAnAlertWhenComboBox
        {
            get
            {
                if ((this.cachedGenerateAnAlertWhenComboBox == null))
                {
                    this.cachedGenerateAnAlertWhenComboBox = new ComboBox(this, ConfigureAlertsDialog.ControlIDs.GenerateAnAlertWhenComboBox);
                }
                return this.cachedGenerateAnAlertWhenComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.PriorityStaticControl
        {
            get
            {
                if ((this.cachedPriorityStaticControl == null))
                {
                    this.cachedPriorityStaticControl = new StaticControl(this, ConfigureAlertsDialog.ControlIDs.PriorityStaticControl);
                }
                return this.cachedPriorityStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateAnAlertWhenStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.GenerateAnAlertWhenStaticControl
        {
            get
            {
                if ((this.cachedGenerateAnAlertWhenStaticControl == null))
                {
                    this.cachedGenerateAnAlertWhenStaticControl = new StaticControl(this, ConfigureAlertsDialog.ControlIDs.GenerateAnAlertWhenStaticControl);
                }
                return this.cachedGenerateAnAlertWhenStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ConfigureAlertsDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureAlertsDialogControls.ConfigureAlertsStaticControl2
        {
            get
            {
                if ((this.cachedConfigureAlertsStaticControl2 == null))
                {
                    this.cachedConfigureAlertsStaticControl2 = new StaticControl(this, ConfigureAlertsDialog.ControlIDs.ConfigureAlertsStaticControl2);
                }
                return this.cachedConfigureAlertsStaticControl2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ASTTEST] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConfigureAlertsDialogControls.AlertDescriptionTextBox
        {
            get
            {
                if ((this.cachedAlertDescriptionTextBox == null))
                {
                    this.cachedAlertDescriptionTextBox = new TextBox(this, ConfigureAlertsDialog.ControlIDs.AlertDescriptionTextBox);
                }

                return this.cachedAlertDescriptionTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ASTTEST] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConfigureAlertsDialogControls.AlertNameTextBox
        {
            get
            {
                if ((this.cachedAlertNameTextBox == null))
                {
                    this.cachedAlertNameTextBox = new TextBox(this, ConfigureAlertsDialog.ControlIDs.AlertNameTextBox);
                }

                return this.cachedAlertNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityComboBox control
        /// </summary>
        /// <history>
        /// 	[ASTTEST] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IConfigureAlertsDialogControls.SeverityComboBox
        {
            get
            {
                if ((this.cachedSeverityComboBox == null))
                {
                    this.cachedSeverityComboBox = new ComboBox(this, ConfigureAlertsDialog.ControlIDs.SeverityComboBox);
                }

                return this.cachedSeverityComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionButton control
        /// </summary>
        /// <history>
        /// 	[ASTTEST] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfigureAlertsDialogControls.AlertDescriptionButton
        {
            get
            {
                if ((this.cachedAlertDescriptionButton == null))
                {
                    this.cachedAlertDescriptionButton = new Button(this, ConfigureAlertsDialog.ControlIDs.AlertDescriptionButton);
                }

                return this.cachedAlertDescriptionButton;
            }
        }        
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GenerateAlerts
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAutomaticallyResolveAlert()
        {
            this.Controls.AutomaticallyResolveAlertCheckBox.Click();
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AlertDescriptionButton
        /// </summary>
        /// <history>
        /// 	[ASTTEST] 10/11/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAlertDescriptionButton()
        {
            this.Controls.AlertDescriptionButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>
        /// <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
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
        /// <history>
        /// 	[ruhim] 4/13/2006 Created
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
            private const string ResourceDialogTitle = "Create Monitor Wizard";

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
            /// Contains resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorType = ";Monitor Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventLogType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventLogType = ";Event Log Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildEventExpression = ";Build Event Expression;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ExpressionEvaluatorCondition;$this.N" +
                "avigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealth = ";Configure Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappi" +
                "ngPage;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKnowledge = ";Knowledge;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.ProductKnowledgePage;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertProperties = ";Alert properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;pageSectionLabel2.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSettings = ";Alert settings;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.AlertConfiguration;pageSectionLabel1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GenerateAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGenerateAlerts = ";&Generate alerts for this monitor;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;genera" +
                "teAlertCheckBox.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutomaticallyResolveAlert
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomaticallyResolveAlert = ";Automatically resolve the alert when the monitor returns to a healthy state;Mana" +
                "gedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Int" +
                "ernal.UI.Authoring.Pages.AlertConfiguration;autoResolveCheckbox.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Priority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePriority = ";&Priority:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.AlertConfiguration;priorityLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GenerateAnAlertWhen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGenerateAnAlertWhen = ";Generate an alert &when:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;generateAlertLa" +
                "bel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts2 = ";Configure Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.NavigationText";
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
            /// Caches the translated resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventLogType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventLogType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildEventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildEventExpression;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureHealth;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKnowledge;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;

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
            /// Caches the translated resource string for:  GenerateAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGenerateAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutomaticallyResolveAlert
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutomaticallyResolveAlert;

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
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the MonitorType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorType
            {
                get
                {
                    if ((cachedMonitorType == null))
                    {
                        cachedMonitorType = CoreManager.MomConsole.GetIntlStr(ResourceMonitorType);
                    }
                    return cachedMonitorType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventLogType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventLogType
            {
                get
                {
                    if ((cachedEventLogType == null))
                    {
                        cachedEventLogType = CoreManager.MomConsole.GetIntlStr(ResourceEventLogType);
                    }
                    return cachedEventLogType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BuildEventExpression translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildEventExpression
            {
                get
                {
                    if ((cachedBuildEventExpression == null))
                    {
                        cachedBuildEventExpression = CoreManager.MomConsole.GetIntlStr(ResourceBuildEventExpression);
                    }
                    return cachedBuildEventExpression;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureHealth translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureHealth
            {
                get
                {
                    if ((cachedConfigureHealth == null))
                    {
                        cachedConfigureHealth = CoreManager.MomConsole.GetIntlStr(ResourceConfigureHealth);
                    }
                    return cachedConfigureHealth;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the Knowledge translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Knowledge
            {
                get
                {
                    if ((cachedKnowledge == null))
                    {
                        cachedKnowledge = CoreManager.MomConsole.GetIntlStr(ResourceKnowledge);
                    }
                    return cachedKnowledge;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the AlertProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
            /// Exposes access to the GenerateAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GenerateAlerts
            {
                get
                {
                    if ((cachedGenerateAlerts == null))
                    {
                        cachedGenerateAlerts = CoreManager.MomConsole.GetIntlStr(ResourceGenerateAlerts);
                    }
                    return cachedGenerateAlerts;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutomaticallyResolveAlert translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutomaticallyResolveAlert
            {
                get
                {
                    if ((cachedAutomaticallyResolveAlert == null))
                    {
                        cachedAutomaticallyResolveAlert = CoreManager.MomConsole.GetIntlStr(ResourceAutomaticallyResolveAlert);
                    }
                    return cachedAutomaticallyResolveAlert;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Priority translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/13/2006 Created
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
            /// 	[ruhim] 4/13/2006 Created
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
        /// 	[ruhim] 4/13/2006 Created
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
            /// Control ID for MonitorTypeStaticControl
            /// </summary>
            public const string MonitorTypeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for EventLogTypeStaticControl
            /// </summary>
            public const string EventLogTypeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for BuildEventExpressionStaticControl
            /// </summary>
            public const string BuildEventExpressionStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ConfigureHealthStaticControl
            /// </summary>
            public const string ConfigureHealthStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for KnowledgeStaticControl
            /// </summary>
            public const string KnowledgeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";

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

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl2
            /// </summary>
            public const string ConfigureAlertsStaticControl2 = "headerLabel";

            /// <summary>
            /// Control ID for AlertDescriptionTextBox
            /// </summary>
            public const string AlertDescriptionTextBox = "descriptionTextBox";

            /// <summary>
            /// Control ID for AlertNameTextBox
            /// </summary>
            public const string AlertNameTextBox = "nameTextbox";

            /// <summary>
            /// Control ID for SeverityComboBox
            /// </summary>
            public const string SeverityComboBox = "severityComboBox";

            /// <summary>
            /// Control ID for AlertDescriptionButton
            /// </summary>
            public const string AlertDescriptionButton = "flyoutBtn";
            
        }
        #endregion
    }
}
