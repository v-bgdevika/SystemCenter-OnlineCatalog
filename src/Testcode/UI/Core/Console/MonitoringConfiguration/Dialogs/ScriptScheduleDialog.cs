// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ScriptScheduleDialog.cs">
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

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    #endregion
    
    #region Interface Definition - IScriptScheduleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IScriptScheduleDialogControls, for ScriptScheduleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryli] 20JUN07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IScriptScheduleDialogControls
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
        /// Read-only property to access RunEveryStaticControl
        /// </summary>
        StaticControl RunEveryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureYourScheduleStaticControl
        /// </summary>
        StaticControl ConfigureYourScheduleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Spinner1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Spinner Spinner1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SynchronizeAtCheckBox
        /// </summary>
        CheckBox SynchronizeAtCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScriptComboBox
        /// </summary>
        ComboBox ScriptComboBox
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
    public class ScriptScheduleDialog : Dialog, IScriptScheduleDialogControls
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
        /// Cache to hold a reference to RunEveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunEveryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureYourScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureYourScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox0;
        
        /// <summary>
        /// Cache to hold a reference to Spinner1 of type Spinner
        /// </summary>
        private Spinner cachedSpinner1;
        
        /// <summary>
        /// Cache to hold a reference to SynchronizeAtCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedSynchronizeAtCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to ScriptComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedScriptComboBox;
        
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
        /// Owner of ScriptSCheduleDialog of type ScriptSCheduleDialog
        /// </param>
        /// <param name='windowCaption'>windows caption</param>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ScriptScheduleDialog(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
           :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IScriptScheduleDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IScriptScheduleDialogControls Controls
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
        ///  Property to handle checkbox SynchronizeAt
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool SynchronizeAt
        {
            get
            {
                return this.Controls.SynchronizeAtCheckBox.Checked;
            }
            
            set
            {
                this.Controls.SynchronizeAtCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox0Text
        {
            get
            {
                return this.Controls.ComboBox0.Text;
            }
            
            set
            {
                this.Controls.ComboBox0.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox2Text
        {
            get
            {
                return this.Controls.ComboBox2.Text;
            }
            
            set
            {
                this.Controls.ComboBox2.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Script
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ScriptText
        {
            get
            {
                return this.Controls.ScriptComboBox.Text;
            }
            
            set
            {
                this.Controls.ScriptComboBox.SelectByText(value, true);
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
        Button IScriptScheduleDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ScriptScheduleDialog.ControlIDs.PreviousButton);
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
        Button IScriptScheduleDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ScriptScheduleDialog.ControlIDs.NextButton);
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
        Button IScriptScheduleDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ScriptScheduleDialog.ControlIDs.CreateButton);
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
        Button IScriptScheduleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ScriptScheduleDialog.ControlIDs.CancelButton);
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
        StaticControl IScriptScheduleDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, ScriptScheduleDialog.ControlIDs.RuleTypeStaticControl);
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
        StaticControl IScriptScheduleDialogControls.GeneralStaticControl
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
        StaticControl IScriptScheduleDialogControls.ScheduleStaticControl
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
        StaticControl IScriptScheduleDialogControls.ScriptStaticControl
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
        StaticControl IScriptScheduleDialogControls.EventMapperStaticControl
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
        ///  Exposes access to the RunEveryStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptScheduleDialogControls.RunEveryStaticControl
        {
            get
            {
                if ((this.cachedRunEveryStaticControl == null))
                {
                    this.cachedRunEveryStaticControl = new StaticControl(this, ScriptScheduleDialog.ControlIDs.RunEveryStaticControl);
                }
                
                return this.cachedRunEveryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureYourScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScriptScheduleDialogControls.ConfigureYourScheduleStaticControl
        {
            get
            {
                if ((this.cachedConfigureYourScheduleStaticControl == null))
                {
                    this.cachedConfigureYourScheduleStaticControl = new StaticControl(this, ScriptScheduleDialog.ControlIDs.ConfigureYourScheduleStaticControl);
                }
                
                return this.cachedConfigureYourScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IScriptScheduleDialogControls.ComboBox0
        {
            get
            {
                if ((this.cachedComboBox0 == null))
                {
                    this.cachedComboBox0 = new ComboBox(this, ScriptScheduleDialog.ControlIDs.ComboBox0);
                }
                
                return this.cachedComboBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Spinner1 control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IScriptScheduleDialogControls.Spinner1
        {
            get
            {
                if ((this.cachedSpinner1 == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSpinner1 = new Spinner(wndTemp);
                }
                
                return this.cachedSpinner1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SynchronizeAtCheckBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IScriptScheduleDialogControls.SynchronizeAtCheckBox
        {
            get
            {
                if ((this.cachedSynchronizeAtCheckBox == null))
                {
                    this.cachedSynchronizeAtCheckBox = new CheckBox(this, ScriptScheduleDialog.ControlIDs.SynchronizeAtCheckBox);
                }
                
                return this.cachedSynchronizeAtCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox2 control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IScriptScheduleDialogControls.ComboBox2
        {
            get
            {
                if ((this.cachedComboBox2 == null))
                {
                    this.cachedComboBox2 = new ComboBox(this, ScriptScheduleDialog.ControlIDs.ComboBox2);
                }
                
                return this.cachedComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptComboBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IScriptScheduleDialogControls.ScriptComboBox
        {
            get
            {
                if ((this.cachedScriptComboBox == null))
                {
                    this.cachedScriptComboBox = new ComboBox(this, ScriptScheduleDialog.ControlIDs.ScriptComboBox);
                }
                
                return this.cachedScriptComboBox;
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
        StaticControl IScriptScheduleDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ScriptScheduleDialog.ControlIDs.HelpStaticControl);
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
        StaticControl IScriptScheduleDialogControls.ScheduleStaticControl2
        {
            get
            {
                if ((this.cachedScheduleStaticControl2 == null))
                {
                    this.cachedScheduleStaticControl2 = new StaticControl(this, ScriptScheduleDialog.ControlIDs.ScheduleStaticControl2);
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
        ///  Routine to click on button SynchronizeAt
        /// </summary>
        /// <history>
        /// 	[barryli] 20JUN07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSynchronizeAt()
        {
            this.Controls.SynchronizeAtCheckBox.Click();
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
            /// Contains resource string for:  RunEvery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunEvery = ";Run every:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.SimpleSchedulerPage;lblRunEv" +
                "ery.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureYourSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureYourSchedule = ";Configure your schedule;ManagedString;Microsoft.EnterpriseManagement.UI.Authorin" +
                "g.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SimpleScheduler" +
                "Page;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SynchronizeAt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSynchronizeAt = ";S&ynchronize at:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SimpleRecurringControl" +
                ";checkBoxSync.Text";
            
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
            /// Caches the translated resource string for:  RunEvery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunEvery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureYourSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureYourSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SynchronizeAt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSynchronizeAt;
            
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
            /// Exposes access to the RunEvery translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunEvery
            {
                get
                {
                    if ((cachedRunEvery == null))
                    {
                        cachedRunEvery = CoreManager.MomConsole.GetIntlStr(ResourceRunEvery);
                    }
                    
                    return cachedRunEvery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureYourSchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureYourSchedule
            {
                get
                {
                    if ((cachedConfigureYourSchedule == null))
                    {
                        cachedConfigureYourSchedule = CoreManager.MomConsole.GetIntlStr(ResourceConfigureYourSchedule);
                    }
                    
                    return cachedConfigureYourSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SynchronizeAt translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 20JUN07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SynchronizeAt
            {
                get
                {
                    if ((cachedSynchronizeAt == null))
                    {
                        cachedSynchronizeAt = CoreManager.MomConsole.GetIntlStr(ResourceSynchronizeAt);
                    }
                    
                    return cachedSynchronizeAt;
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
            /// Control ID for RunEveryStaticControl
            /// </summary>
            public const string RunEveryStaticControl = "lblRunEvery";
            
            /// <summary>
            /// Control ID for ConfigureYourScheduleStaticControl
            /// </summary>
            public const string ConfigureYourScheduleStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for ComboBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox0 = "dateTimePickerHour";
            
            /// <summary>
            /// Control ID for SynchronizeAtCheckBox
            /// </summary>
            public const string SynchronizeAtCheckBox = "checkBoxSync";
            
            /// <summary>
            /// Control ID for ComboBox2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox2 = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for ScriptComboBox
            /// </summary>
            public const string ScriptComboBox = "numericUpDownInterval";
            
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
