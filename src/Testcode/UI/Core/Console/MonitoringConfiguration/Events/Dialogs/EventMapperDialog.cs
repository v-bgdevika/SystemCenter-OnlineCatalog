// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EventMapperDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[barryli] 20JUN07 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    #endregion
    
    #region Interface Definition - IEventMapperDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEventMapperDialogControls, for EventMapperDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryli] 20JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEventMapperDialogControls
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
        /// Read-only property to access ScheduleStaticControl
        /// </summary>
        StaticControl ScheduleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScriptStaticControl
        /// </summary>
        StaticControl ScriptStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventMapperStaticControl
        /// </summary>
        StaticControl EventMapperStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis0Button
        /// </summary>
        Button Ellipsis0Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis1Button
        /// </summary>
        Button Ellipsis1Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis2Button
        /// </summary>
        Button Ellipsis2Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis3Button
        /// </summary>
        Button Ellipsis3Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis4Button
        /// </summary>
        Button Ellipsis4Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParametersButton
        /// </summary>
        Button ParametersButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventLevelComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox EventLevelComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CategoryTextBox
        /// </summary>
        TextBox CategoryTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventID
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox EventID
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventLogTextBox
        /// </summary>
        TextBox EventLogTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventSourceTextBox
        /// </summary>
        TextBox EventSourceTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComputerTextBox
        /// </summary>
        TextBox ComputerTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie
        /// </summary>
        StaticControl ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LevelStaticControl
        /// </summary>
        StaticControl LevelStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CategoryStaticControl
        /// </summary>
        StaticControl CategoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventIDStaticControl
        /// </summary>
        StaticControl EventIDStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventLogStaticControl
        /// </summary>
        StaticControl EventLogStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventSourceStaticControl
        /// </summary>
        StaticControl EventSourceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComputerStaticControl
        /// </summary>
        StaticControl ComputerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterEventMappingInformationStaticControl
        /// </summary>
        StaticControl EnterEventMappingInformationStaticControl
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
        /// Read-only property to access ScheduleStaticControl2
        /// </summary>
        StaticControl ScheduleStaticControl2
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
    /// 	[barryli] 20JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class EventMapperDialog : Dialog, IEventMapperDialogControls
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
        /// Cache to hold a reference to ScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScriptStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScriptStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EventMapperStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventMapperStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis0Button of type Button
        /// </summary>
        private Button cachedEllipsis0Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis1Button of type Button
        /// </summary>
        private Button cachedEllipsis1Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis2Button of type Button
        /// </summary>
        private Button cachedEllipsis2Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis3Button of type Button
        /// </summary>
        private Button cachedEllipsis3Button;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis4Button of type Button
        /// </summary>
        private Button cachedEllipsis4Button;
        
        /// <summary>
        /// Cache to hold a reference to ParametersButton of type Button
        /// </summary>
        private Button cachedParametersButton;
        
        /// <summary>
        /// Cache to hold a reference to EventLevelComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedEventLevelComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CategoryTextBox of type TextBox
        /// </summary>
        private TextBox cachedCategoryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EventID of type TextBox
        /// </summary>
        private TextBox cachedEventID;
        
        /// <summary>
        /// Cache to hold a reference to EventLogTextBox of type TextBox
        /// </summary>
        private TextBox cachedEventLogTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EventSourceTextBox of type TextBox
        /// </summary>
        private TextBox cachedEventSourceTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ComputerTextBox of type TextBox
        /// </summary>
        private TextBox cachedComputerTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie of type StaticControl
        /// </summary>
        private StaticControl cachedClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie;
        
        /// <summary>
        /// Cache to hold a reference to LevelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLevelStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CategoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCategoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EventIDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventIDStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EventLogStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventLogStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EventSourceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventSourceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComputerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterEventMappingInformationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterEventMappingInformationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScheduleStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedScheduleStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of EventMapperDialog of type EventMapperDialog
        /// </param>
        /// <param name='windowCaption'>windows caption</param>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EventMapperDialog(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
           :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IEventMapperDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEventMapperDialogControls Controls
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
        ///  Routine to set/get the text in control EventLevelComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EventLevelComboBoxText
        {
            get
            {
                return this.Controls.EventLevelComboBox.Text;
            }
            
            set
            {
                this.Controls.EventLevelComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Category
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CategoryText
        {
            get
            {
                return this.Controls.CategoryTextBox.Text;
            }
            
            set
            {
                this.Controls.CategoryTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EventID
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EventIDText
        {
            get
            {
                return this.Controls.EventID.Text;
            }
            
            set
            {
                this.Controls.EventID.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EventLog
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EventLogText
        {
            get
            {
                return this.Controls.EventLogTextBox.Text;
            }
            
            set
            {
                this.Controls.EventLogTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EventSource
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EventSourceText
        {
            get
            {
                return this.Controls.EventSourceTextBox.Text;
            }
            
            set
            {
                this.Controls.EventSourceTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Computer
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComputerText
        {
            get
            {
                return this.Controls.ComputerTextBox.Text;
            }
            
            set
            {
                this.Controls.ComputerTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, EventMapperDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, EventMapperDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, EventMapperDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EventMapperDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.RuleTypeStaticControl);
                }
                
                return this.cachedRuleTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.GeneralStaticControl
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
        ///  Exposes access to the ScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.ScheduleStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedScheduleStaticControl == null))
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
                    this.cachedScheduleStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.ScriptStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedScriptStaticControl == null))
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
                    this.cachedScriptStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedScriptStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventMapperStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.EventMapperStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventMapperStaticControl == null))
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
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedEventMapperStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedEventMapperStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis0Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.Ellipsis0Button
        {
            get
            {
                if ((this.cachedEllipsis0Button == null))
                {
                    this.cachedEllipsis0Button = new Button(this, EventMapperDialog.ControlIDs.Ellipsis0Button);
                }
                
                return this.cachedEllipsis0Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis1Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.Ellipsis1Button
        {
            get
            {
                if ((this.cachedEllipsis1Button == null))
                {
                    this.cachedEllipsis1Button = new Button(this, EventMapperDialog.ControlIDs.Ellipsis1Button);
                }
                
                return this.cachedEllipsis1Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis2Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.Ellipsis2Button
        {
            get
            {
                if ((this.cachedEllipsis2Button == null))
                {
                    this.cachedEllipsis2Button = new Button(this, EventMapperDialog.ControlIDs.Ellipsis2Button);
                }
                
                return this.cachedEllipsis2Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis3Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.Ellipsis3Button
        {
            get
            {
                if ((this.cachedEllipsis3Button == null))
                {
                    this.cachedEllipsis3Button = new Button(this, EventMapperDialog.ControlIDs.Ellipsis3Button);
                }
                
                return this.cachedEllipsis3Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis4Button control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.Ellipsis4Button
        {
            get
            {
                if ((this.cachedEllipsis4Button == null))
                {
                    this.cachedEllipsis4Button = new Button(this, EventMapperDialog.ControlIDs.Ellipsis4Button);
                }
                
                return this.cachedEllipsis4Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventMapperDialogControls.ParametersButton
        {
            get
            {
                if ((this.cachedParametersButton == null))
                {
                    this.cachedParametersButton = new Button(this, EventMapperDialog.ControlIDs.ParametersButton);
                }
                
                return this.cachedParametersButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLevelComboBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventMapperDialogControls.EventLevelComboBox
        {
            get
            {
                if ((this.cachedEventLevelComboBox == null))
                {
                    this.cachedEventLevelComboBox = new ComboBox(this, EventMapperDialog.ControlIDs.EventLevelComboBox);
                }
                
                return this.cachedEventLevelComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CategoryTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventMapperDialogControls.CategoryTextBox
        {
            get
            {
                if ((this.cachedCategoryTextBox == null))
                {
                    this.cachedCategoryTextBox = new TextBox(this, EventMapperDialog.ControlIDs.CategoryTextBox);
                }
                
                return this.cachedCategoryTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventID control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventMapperDialogControls.EventID
        {
            get
            {
                if ((this.cachedEventID == null))
                {
                    this.cachedEventID = new TextBox(this, EventMapperDialog.ControlIDs.EventID);
                }
                
                return this.cachedEventID;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLogTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventMapperDialogControls.EventLogTextBox
        {
            get
            {
                if ((this.cachedEventLogTextBox == null))
                {
                    this.cachedEventLogTextBox = new TextBox(this, EventMapperDialog.ControlIDs.EventLogTextBox);
                }
                
                return this.cachedEventLogTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventSourceTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventMapperDialogControls.EventSourceTextBox
        {
            get
            {
                if ((this.cachedEventSourceTextBox == null))
                {
                    this.cachedEventSourceTextBox = new TextBox(this, EventMapperDialog.ControlIDs.EventSourceTextBox);
                }
                
                return this.cachedEventSourceTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerTextBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventMapperDialogControls.ComputerTextBox
        {
            get
            {
                if ((this.cachedComputerTextBox == null))
                {
                    this.cachedComputerTextBox = new TextBox(this, EventMapperDialog.ControlIDs.ComputerTextBox);
                }
                
                return this.cachedComputerTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie
        {
            get
            {
                if ((this.cachedClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie == null))
                {
                    this.cachedClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie = new StaticControl(this, EventMapperDialog.ControlIDs.ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie);
                }
                
                return this.cachedClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LevelStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.LevelStaticControl
        {
            get
            {
                if ((this.cachedLevelStaticControl == null))
                {
                    this.cachedLevelStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.LevelStaticControl);
                }
                
                return this.cachedLevelStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CategoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.CategoryStaticControl
        {
            get
            {
                if ((this.cachedCategoryStaticControl == null))
                {
                    this.cachedCategoryStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.CategoryStaticControl);
                }
                
                return this.cachedCategoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventIDStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.EventIDStaticControl
        {
            get
            {
                if ((this.cachedEventIDStaticControl == null))
                {
                    this.cachedEventIDStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.EventIDStaticControl);
                }
                
                return this.cachedEventIDStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLogStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.EventLogStaticControl
        {
            get
            {
                if ((this.cachedEventLogStaticControl == null))
                {
                    this.cachedEventLogStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.EventLogStaticControl);
                }
                
                return this.cachedEventLogStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventSourceStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.EventSourceStaticControl
        {
            get
            {
                if ((this.cachedEventSourceStaticControl == null))
                {
                    this.cachedEventSourceStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.EventSourceStaticControl);
                }
                
                return this.cachedEventSourceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.ComputerStaticControl
        {
            get
            {
                if ((this.cachedComputerStaticControl == null))
                {
                    this.cachedComputerStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.ComputerStaticControl);
                }
                
                return this.cachedComputerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterEventMappingInformationStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.EnterEventMappingInformationStaticControl
        {
            get
            {
                if ((this.cachedEnterEventMappingInformationStaticControl == null))
                {
                    this.cachedEnterEventMappingInformationStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.EnterEventMappingInformationStaticControl);
                }
                
                return this.cachedEnterEventMappingInformationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, EventMapperDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScheduleStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventMapperDialogControls.ScheduleStaticControl2
        {
            get
            {
                if ((this.cachedScheduleStaticControl2 == null))
                {
                    this.cachedScheduleStaticControl2 = new StaticControl(this, EventMapperDialog.ControlIDs.ScheduleStaticControl2);
                }
                
                return this.cachedScheduleStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
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
        /// 	[barryli] 20JUN07 Created
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
        /// 	[barryli] 20JUN07 Created
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
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis0
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis0()
        {
            this.Controls.Ellipsis0Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis1
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis1()
        {
            this.Controls.Ellipsis1Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis2
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis2()
        {
            this.Controls.Ellipsis2Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis3
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis3()
        {
            this.Controls.Ellipsis3Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis4
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis4()
        {
            this.Controls.Ellipsis4Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Parameters
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickParameters()
        {
            this.Controls.ParametersButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">owning the dialog.</param>)
        ///  <param name="windowCaption">window caption</param>)
        /// <history>
        /// 	[barryli] 20JUN07 Created
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
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                if ((null == tempWindow))
                {
                    // log the failure
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + DialogTitle + "'");
                    // rethrow the original exception
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
        /// 	[barryli] 20JUN07 Created
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
            /// Contains resource string for:  Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSchedule = ";Schedule;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSch" +
                "edulePage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Script
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScript = ";Script;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Propert" +
                "ies.Resources;ScriptName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventMapper
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventMapper = "Event Mapper";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis0 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis1 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis2 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis3 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis4 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParameters = ";&Parameters...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventMapperPage;btnParam" +
                "eters.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie = @";Click on the ""Parameters..."" button to change the parameters created in the event from the input data or the target properties.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventMapperPage;lblChangeParameters.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Level
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLevel = ";&Level:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.EventMapperPage;lblEventLevel.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Category
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCategory = ";Cate&gory:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventMapperPage;lblEventCate" +
                "gory.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventID = ";Event &ID:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventMapperPage;lblEventNumb" +
                "er.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventLog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventLog = ";&Event log:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventMapperPage;lblChannel." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventSource = ";Event &source:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventMapperPage;lblPubli" +
                "sherName.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Computer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputer = ";&Computer:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventMapperPage;lblLoggingCo" +
                "mputer.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterEventMappingInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterEventMappingInformation = ";Enter event mapping information;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventMa" +
                "pperPage;pageSectionLabel1.Text";
            
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
            /// Contains resource string for:  Schedule2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSchedule2 = ";Schedule;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSch" +
                "edulePage;$this.TabName";
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
            /// Caches the translated resource string for:  Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Script
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScript;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventMapper
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventMapper;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis4;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Level
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLevel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Category
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCategory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventID;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventLog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventLog;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventSource;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Computer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterEventMappingInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterEventMappingInformation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Schedule2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSchedule2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
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
            /// 	[barryli] 20JUN07 Created
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
            /// 	[barryli] 20JUN07 Created
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
            /// 	[barryli] 20JUN07 Created
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
            /// 	[barryli] 20JUN07 Created
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
            /// 	[barryli] 20JUN07 Created
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
            /// 	[barryli] 20JUN07 Created
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
            /// Exposes access to the Schedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Schedule
            {
                get
                {
                    if ((cachedSchedule == null))
                    {
                        cachedSchedule = CoreManager.MomConsole.GetIntlStr(ResourceSchedule);
                    }
                    
                    return cachedSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Script translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Script
            {
                get
                {
                    if ((cachedScript == null))
                    {
                        cachedScript = CoreManager.MomConsole.GetIntlStr(ResourceScript);
                    }
                    
                    return cachedScript;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventMapper translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventMapper
            {
                get
                {
                    if ((cachedEventMapper == null))
                    {
                        cachedEventMapper = CoreManager.MomConsole.GetIntlStr(ResourceEventMapper);
                    }
                    
                    return cachedEventMapper;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis0 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis0
            {
                get
                {
                    if ((cachedEllipsis0 == null))
                    {
                        cachedEllipsis0 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis0);
                    }
                    
                    return cachedEllipsis0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis1 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis1
            {
                get
                {
                    if ((cachedEllipsis1 == null))
                    {
                        cachedEllipsis1 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis1);
                    }
                    
                    return cachedEllipsis1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis2 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis2
            {
                get
                {
                    if ((cachedEllipsis2 == null))
                    {
                        cachedEllipsis2 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis2);
                    }
                    
                    return cachedEllipsis2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis3 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis3
            {
                get
                {
                    if ((cachedEllipsis3 == null))
                    {
                        cachedEllipsis3 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis3);
                    }
                    
                    return cachedEllipsis3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis4 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis4
            {
                get
                {
                    if ((cachedEllipsis4 == null))
                    {
                        cachedEllipsis4 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis4);
                    }
                    
                    return cachedEllipsis4;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Parameters translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Parameters
            {
                get
                {
                    if ((cachedParameters == null))
                    {
                        cachedParameters = CoreManager.MomConsole.GetIntlStr(ResourceParameters);
                    }
                    
                    return cachedParameters;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie
            {
                get
                {
                    if ((cachedClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie == null))
                    {
                        cachedClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie = CoreManager.MomConsole.GetIntlStr(ResourceClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie);
                    }
                    
                    return cachedClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Level translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Level
            {
                get
                {
                    if ((cachedLevel == null))
                    {
                        cachedLevel = CoreManager.MomConsole.GetIntlStr(ResourceLevel);
                    }
                    
                    return cachedLevel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Category translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Category
            {
                get
                {
                    if ((cachedCategory == null))
                    {
                        cachedCategory = CoreManager.MomConsole.GetIntlStr(ResourceCategory);
                    }
                    
                    return cachedCategory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventID translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventID
            {
                get
                {
                    if ((cachedEventID == null))
                    {
                        cachedEventID = CoreManager.MomConsole.GetIntlStr(ResourceEventID);
                    }
                    
                    return cachedEventID;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventLog translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventLog
            {
                get
                {
                    if ((cachedEventLog == null))
                    {
                        cachedEventLog = CoreManager.MomConsole.GetIntlStr(ResourceEventLog);
                    }
                    
                    return cachedEventLog;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventSource translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventSource
            {
                get
                {
                    if ((cachedEventSource == null))
                    {
                        cachedEventSource = CoreManager.MomConsole.GetIntlStr(ResourceEventSource);
                    }
                    
                    return cachedEventSource;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Computer translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Computer
            {
                get
                {
                    if ((cachedComputer == null))
                    {
                        cachedComputer = CoreManager.MomConsole.GetIntlStr(ResourceComputer);
                    }
                    
                    return cachedComputer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterEventMappingInformation translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterEventMappingInformation
            {
                get
                {
                    if ((cachedEnterEventMappingInformation == null))
                    {
                        cachedEnterEventMappingInformation = CoreManager.MomConsole.GetIntlStr(ResourceEnterEventMappingInformation);
                    }
                    
                    return cachedEnterEventMappingInformation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
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
            /// Exposes access to the Schedule2 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Schedule2
            {
                get
                {
                    if ((cachedSchedule2 == null))
                    {
                        cachedSchedule2 = CoreManager.MomConsole.GetIntlStr(ResourceSchedule2);
                    }
                    
                    return cachedSchedule2;
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
        /// 	[barryli] 20JUN07 Created
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
            /// Control ID for ScheduleStaticControl
            /// </summary>
            public const string ScheduleStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ScriptStaticControl
            /// </summary>
            public const string ScriptStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for EventMapperStaticControl
            /// </summary>
            public const string EventMapperStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for Ellipsis0Button
            /// </summary>
            public const string Ellipsis0Button = "btnEventCategoryBrowse";
            
            /// <summary>
            /// Control ID for Ellipsis1Button
            /// </summary>
            public const string Ellipsis1Button = "btnEventNumberBrowse";
            
            /// <summary>
            /// Control ID for Ellipsis2Button
            /// </summary>
            public const string Ellipsis2Button = "btnChannelBrowse";
            
            /// <summary>
            /// Control ID for Ellipsis3Button
            /// </summary>
            public const string Ellipsis3Button = "btnPublisherNameBrowse";
            
            /// <summary>
            /// Control ID for Ellipsis4Button
            /// </summary>
            public const string Ellipsis4Button = "btnLoggingComputerBrowse";
            
            /// <summary>
            /// Control ID for ParametersButton
            /// </summary>
            public const string ParametersButton = "btnParameters";
            
            /// <summary>
            /// Control ID for EventLevelComboBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string EventLevelComboBox = "cboEventLevel";
            
            /// <summary>
            /// Control ID for CategoryTextBox
            /// </summary>
            public const string CategoryTextBox = "txtEventCategory";
            
            /// <summary>
            /// Control ID for EventID
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string EventID = "txtEventNumber";
            
            /// <summary>
            /// Control ID for EventLogTextBox
            /// </summary>
            public const string EventLogTextBox = "txtChannel";
            
            /// <summary>
            /// Control ID for EventSourceTextBox
            /// </summary>
            public const string EventSourceTextBox = "txtPublisherName";
            
            /// <summary>
            /// Control ID for ComputerTextBox
            /// </summary>
            public const string ComputerTextBox = "txtLoggingComputer";
            
            /// <summary>
            /// Control ID for ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie
            /// </summary>
            public const string ClickOnTheParametersButtonToChangeTheParametersCreatedInTheEventFromTheInputDataOrTheTargetPropertie = "lblChangeParameters";
            
            /// <summary>
            /// Control ID for LevelStaticControl
            /// </summary>
            public const string LevelStaticControl = "lblEventLevel";
            
            /// <summary>
            /// Control ID for CategoryStaticControl
            /// </summary>
            public const string CategoryStaticControl = "lblEventCategory";
            
            /// <summary>
            /// Control ID for EventIDStaticControl
            /// </summary>
            public const string EventIDStaticControl = "lblEventNumber";
            
            /// <summary>
            /// Control ID for EventLogStaticControl
            /// </summary>
            public const string EventLogStaticControl = "lblChannel";
            
            /// <summary>
            /// Control ID for EventSourceStaticControl
            /// </summary>
            public const string EventSourceStaticControl = "lblPublisherName";
            
            /// <summary>
            /// Control ID for ComputerStaticControl
            /// </summary>
            public const string ComputerStaticControl = "lblLoggingComputer";
            
            /// <summary>
            /// Control ID for EnterEventMappingInformationStaticControl
            /// </summary>
            public const string EnterEventMappingInformationStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ScheduleStaticControl2
            /// </summary>
            public const string ScheduleStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
