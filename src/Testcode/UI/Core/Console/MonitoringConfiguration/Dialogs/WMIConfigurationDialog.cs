// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WMIConfigurationDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[barryli] 21JUN07 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IWMIConfigurationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWMIConfigurationDialogControls, for WMIConfigurationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryli] 21JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWMIConfigurationDialogControls
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
        /// Read-only property to access SpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl
        /// </summary>
        StaticControl SpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WMINamespaceStaticControl
        /// </summary>
        StaticControl WMINamespaceStaticControl
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
        /// Read-only property to access QueryStaticControl
        /// </summary>
        StaticControl QueryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectIdentifierPropertiesTextBox
        /// </summary>
        TextBox ObjectIdentifierPropertiesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PollIntervalStaticControl
        /// </summary>
        StaticControl PollIntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalStaticControl
        /// </summary>
        StaticControl IntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalComboBox
        /// </summary>
        TextBox IntervalComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FrequencyComboBox
        /// </summary>
        TextBox FrequencyComboBox
        {
            get;
        }
        /// <summary>
        /// Read-only property to access SecondsStaticControl
        /// </summary>
        StaticControl SecondsStaticControl
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
        /// Read-only property to access WMIConfigurationStaticControl2
        /// </summary>
        StaticControl WMIConfigurationStaticControl2
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
    /// 	[barryli] 21JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WMIConfigurationDialog : Dialog, IWMIConfigurationDialogControls
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
        /// Cache to hold a reference to SpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WMINamespaceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWMINamespaceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsTextBox of type TextBox
        /// </summary>
        private TextBox cachedConfigureAlertsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to QueryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedQueryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectIdentifierPropertiesTextBox of type TextBox
        /// </summary>
        private TextBox cachedObjectIdentifierPropertiesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PollIntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPollIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntervalComboBox of type ComboBox
        /// </summary>
        private TextBox cachedIntervalComboBox;

        /// <summary>
        /// Cache to hold a reference to FrequencyComboBox of type ComboBox
        /// </summary>
        private TextBox cachedFrequencyComboBox;

        /// <summary>
        /// Cache to hold a reference to SecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WMIConfigurationStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedWMIConfigurationStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WMIConfigurationDialog of type WMIConfigurationDialog
        /// <param name='windowCaption'>Dialog Title </param>
        /// </param>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WMIConfigurationDialog(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IWMIConfigurationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWMIConfigurationDialogControls Controls
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
        ///  Routine to set/get the text in control ConfigureAlerts
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameSpaceText
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ObjectIdentifierProperties
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WMIQueryText
        {
            get
            {
                return this.Controls.ObjectIdentifierPropertiesTextBox.Text;
            }
            
            set
            {
                this.Controls.ObjectIdentifierPropertiesTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Interval
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IntervalText
        {
            get
            {
                return this.Controls.IntervalComboBox.Text;
            }
            
            set
            {
                //this.Controls.IntervalComboBox.SelectByText(value, true);
                this.Controls.IntervalComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Frequency
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-cheli] 24DEC08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FrequencyText
        {
            get
            {
                return this.Controls.FrequencyComboBox.Text;
            }

            set
            {
                this.Controls.FrequencyComboBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIConfigurationDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, WMIConfigurationDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIConfigurationDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WMIConfigurationDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIConfigurationDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, WMIConfigurationDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIConfigurationDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WMIConfigurationDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, WMIConfigurationDialog.ControlIDs.RuleTypeStaticControl);
                }
                
                return this.cachedRuleTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.GeneralStaticControl
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
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.WMIConfigurationStaticControl
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
        ///  Exposes access to the SpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.SpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl
        {
            get
            {
                if ((this.cachedSpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl == null))
                {
                    this.cachedSpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl = new StaticControl(this, WMIConfigurationDialog.ControlIDs.SpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl);
                }
                
                return this.cachedSpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WMINamespaceStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.WMINamespaceStaticControl
        {
            get
            {
                if ((this.cachedWMINamespaceStaticControl == null))
                {
                    this.cachedWMINamespaceStaticControl = new StaticControl(this, WMIConfigurationDialog.ControlIDs.WMINamespaceStaticControl);
                }
                
                return this.cachedWMINamespaceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWMIConfigurationDialogControls.ConfigureAlertsTextBox
        {
            get
            {
                if ((this.cachedConfigureAlertsTextBox == null))
                {
                    this.cachedConfigureAlertsTextBox = new TextBox(this, WMIConfigurationDialog.ControlIDs.ConfigureAlertsTextBox);
                }
                
                return this.cachedConfigureAlertsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.QueryStaticControl
        {
            get
            {
                if ((this.cachedQueryStaticControl == null))
                {
                    this.cachedQueryStaticControl = new StaticControl(this, WMIConfigurationDialog.ControlIDs.QueryStaticControl);
                }
                
                return this.cachedQueryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectIdentifierPropertiesTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWMIConfigurationDialogControls.ObjectIdentifierPropertiesTextBox
        {
            get
            {
                if ((this.cachedObjectIdentifierPropertiesTextBox == null))
                {
                    this.cachedObjectIdentifierPropertiesTextBox = new TextBox(this, WMIConfigurationDialog.ControlIDs.ObjectIdentifierPropertiesTextBox);
                }
                
                return this.cachedObjectIdentifierPropertiesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PollIntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.PollIntervalStaticControl
        {
            get
            {
                if ((this.cachedPollIntervalStaticControl == null))
                {
                    this.cachedPollIntervalStaticControl = new StaticControl(this, WMIConfigurationDialog.ControlIDs.PollIntervalStaticControl);
                }
                
                return this.cachedPollIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.IntervalStaticControl
        {
            get
            {
                if ((this.cachedIntervalStaticControl == null))
                {
                    this.cachedIntervalStaticControl = new StaticControl(this, WMIConfigurationDialog.ControlIDs.IntervalStaticControl);
                }
                
                return this.cachedIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalComboBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWMIConfigurationDialogControls.IntervalComboBox
        {
            get
            {
                if ((this.cachedIntervalComboBox == null))
                {
                    this.cachedIntervalComboBox = new TextBox(this, WMIConfigurationDialog.ControlIDs.IntervalComboBox);
                }
                
                return this.cachedIntervalComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FrequencyComboBox control
        /// </summary>
        /// <history>
        /// 	[v-cheli] 24DEC08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWMIConfigurationDialogControls.FrequencyComboBox
        {
            get
            {
                if ((this.cachedFrequencyComboBox== null))
                {
                    this.cachedFrequencyComboBox = new TextBox(this, WMIConfigurationDialog.ControlIDs.FrequencyComboBox);
                }

                return this.cachedFrequencyComboBox;
            }
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.SecondsStaticControl
        {
            get
            {
                if ((this.cachedSecondsStaticControl == null))
                {
                    this.cachedSecondsStaticControl = new StaticControl(this, WMIConfigurationDialog.ControlIDs.SecondsStaticControl);
                }
                
                return this.cachedSecondsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, WMIConfigurationDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WMIConfigurationStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIConfigurationDialogControls.WMIConfigurationStaticControl2
        {
            get
            {
                if ((this.cachedWMIConfigurationStaticControl2 == null))
                {
                    this.cachedWMIConfigurationStaticControl2 = new StaticControl(this, WMIConfigurationDialog.ControlIDs.WMIConfigurationStaticControl2);
                }
                
                return this.cachedWMIConfigurationStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
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
        /// 	[barryli] 21JUN07 Created
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
        /// 	[barryli] 21JUN07 Created
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
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">WMIConfigurationDialog owning the dialog.</param>)
        ///  <param name='windowCaption'>Dialog Title </param>
        /// <history>
        /// 	[barryli] 21JUN07 Created
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
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // Reset the window reference
                tempWindow = null;
                int numberOfTries = 0;
                // Maximum number of tries to find window
                int maxTries = 5;

                while (tempWindow == null && numberOfTries < maxTries)
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
                            "Attempt " + numberOfTries + " of " + maxTries);
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
        /// 	[barryli] 21JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Create Rule Wizard
            /// </summary>
            // Create Rule Wizard
            public const string DialogTitle = ";Create Rule Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResourc" +
                "es;CreateRuleWizard";
            
            /// <summary>
            /// Resource string for Previous
            /// </summary>
            // < &Previous
            public const string Previous = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// <summary>
            /// Resource string for Next 
            /// </summary>
            // Next 
            public const string Next = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// <summary>
            /// Resource string for Create
            /// </summary>
            // Create
            public const string Create = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            // Cancel
            public const string Cancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// <summary>
            /// Resource string for Rule Type
            /// </summary>
            // Rule Type
            public const string RuleType = ";Rule Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseRuleTypePage;$this.Navi" +
                "gationText";
            
            /// <summary>
            /// Resource string for General
            /// </summary>
            // General
            public const string General = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";
            
            /// <summary>
            /// Resource string for WMI Configuration
            /// </summary>
            // WMI Configuration
            public const string WMIConfiguration = ";WMI Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;$this.T" +
                "abName";
            
            /// <summary>
            /// Resource string for Specify WMI namespace and how often to poll for query results
            /// </summary>
            // Specify WMI namespace and how often to poll for query results
            public const string SpecifyWMINamespaceAndHowOftenToPollForQueryResults = ";Specify WMI namespace and how often to poll for query results;ManagedString;Micr" +
                "osoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Inter" +
                "nal.UI.Authoring.Pages.WMIEventDataSource;pageSectionLabel2.Text";
            
            /// <summary>
            /// Resource string for WMI Namespace:
            /// </summary>
            // WMI Na&mespace:
            public const string WMINamespace = ";WMI Na&mespace:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;NameSpace" +
                "Label.Text";
            
            /// <summary>
            /// Resource string for Query:
            /// </summary>
            // &Query:
            public const string Query = ";&Query:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;queryLabel.Text";
            
            /// <summary>
            /// Resource string for Poll Interval
            /// </summary>
            // Poll Interval
            public const string PollInterval = ";Poll Interval;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIEventDataSource;pollIn" +
                "tervalLabel.Text";
            
            /// <summary>
            /// Resource string for Interval:
            /// </summary>
            // &Interval:
            public const string Interval = ";&Interval:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorConditionPage;la" +
                "belInterval.Text";
            
            /// <summary>
            /// Resource string for seconds
            /// </summary>
            // seconds
            public const string Seconds = ";seconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.DiscoveryIntervalPage;secondsLa" +
                "bel.Text";
            
            /// <summary>
            /// Resource string for Help
            /// </summary>
            // Help
            public const string Help = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;HelpSubFold" +
                "erName";
            
            /// <summary>
            /// Resource string for WMI Configuration
            /// </summary>
            // WMI Configuration
            public const string WMIConfiguration2 = ";WMI Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;$this.T" +
                "abName";
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[barryli] 21JUN07 Created
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
            /// Control ID for SpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl
            /// </summary>
            public const string SpecifyWMINamespaceAndHowOftenToPollForQueryResultsStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for WMINamespaceStaticControl
            /// </summary>
            public const string WMINamespaceStaticControl = "NameSpaceLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsTextBox
            /// </summary>
            public const string ConfigureAlertsTextBox = "nameSpaceTextBox";
            
            /// <summary>
            /// Control ID for QueryStaticControl
            /// </summary>
            public const string QueryStaticControl = "queryLabel";
            
            /// <summary>
            /// Control ID for ObjectIdentifierPropertiesTextBox
            /// </summary>
            public const string ObjectIdentifierPropertiesTextBox = "queryTextBox";
            
            /// <summary>
            /// Control ID for PollIntervalStaticControl
            /// </summary>
            public const string PollIntervalStaticControl = "pollIntervalLabel";
            
            /// <summary>
            /// Control ID for IntervalStaticControl
            /// </summary>
            public const string IntervalStaticControl = "frequencyLabel";
            
            /// <summary>
            /// Control ID for IntervalComboBox
            /// </summary>
            public const string IntervalComboBox = "pollIntervalUpDown";

            /// <summary>
            /// Control ID for frequencyComboBox
            /// </summary>
            public const string FrequencyComboBox = "frequencyUpDown";
            
            /// <summary>
            /// Control ID for SecondsStaticControl
            /// </summary>
            public const string SecondsStaticControl = "secondsLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for WMIConfigurationStaticControl2
            /// </summary>
            public const string WMIConfigurationStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
