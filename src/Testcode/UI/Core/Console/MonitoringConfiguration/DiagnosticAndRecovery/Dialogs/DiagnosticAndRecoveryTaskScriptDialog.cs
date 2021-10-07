// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiagnosticAndRecoveryTaskScriptDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[asttest] 8/4/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.DiagnosticAndRecovery.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IDiagnosticAndRecoveryTaskScriptDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiagnosticAndRecoveryTaskScriptDialogControls, for DiagnosticAndRecoveryTaskScriptDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[asttest] 8/4/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiagnosticAndRecoveryTaskScriptDialogControls
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
        /// Read-only property to access DiagnosticTaskTypeStaticControl
        /// </summary>
        StaticControl DiagnosticTaskTypeStaticControl
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
        /// Read-only property to access SpecifyScriptDetailsStaticControl
        /// </summary>
        StaticControl SpecifyScriptDetailsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl
        /// </summary>
        StaticControl ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExampleMyScriptvbsStaticControl
        /// </summary>
        StaticControl ExampleMyScriptvbsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExampleMyScriptvbsComboBox
        /// </summary>
        ComboBox ExampleMyScriptvbsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeoutComboBox
        /// </summary>
        ComboBox TimeoutComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterScriptInformationStaticControl
        /// </summary>
        StaticControl EnterScriptInformationStaticControl
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
        /// Read-only property to access EditInFullScreenButton
        /// </summary>
        Button EditInFullScreenButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdditionalSettingsTextBox
        /// </summary>
        TextBox AdditionalSettingsTextBox
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
        /// Read-only property to access TimeoutStaticControl
        /// </summary>
        StaticControl TimeoutStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FileNameTextBox
        /// </summary>
        TextBox FileNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FileNameStaticControl
        /// </summary>
        StaticControl FileNameStaticControl
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
        /// Read-only property to access ScriptStaticControl2
        /// </summary>
        StaticControl ScriptStaticControl2
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
    /// 	[asttest] 8/4/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DiagnosticAndRecoveryTaskScriptDialog : Dialog, IDiagnosticAndRecoveryTaskScriptDialogControls
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
        /// Cache to hold a reference to DiagnosticTaskTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiagnosticTaskTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyScriptDetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyScriptDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedClickTheParametersButtonToSpecifyTheScriptParametersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExampleMyScriptvbsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExampleMyScriptvbsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExampleMyScriptvbsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedExampleMyScriptvbsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TimeoutComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimeoutComboBox;
        
        /// <summary>
        /// Cache to hold a reference to EnterScriptInformationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterScriptInformationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ParametersButton of type Button
        /// </summary>
        private Button cachedParametersButton;
        
        /// <summary>
        /// Cache to hold a reference to EditInFullScreenButton of type Button
        /// </summary>
        private Button cachedEditInFullScreenButton;
        
        /// <summary>
        /// Cache to hold a reference to AdditionalSettingsTextBox of type TextBox
        /// </summary>
        private TextBox cachedAdditionalSettingsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ScriptStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScriptStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TimeoutStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTimeoutStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FileNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedFileNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to FileNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFileNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScriptStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedScriptStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DiagnosticAndRecoveryTaskScriptDialog of type MomConsole App
        /// </param>
        /// <param name='ConfigurationType'> </param>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiagnosticAndRecoveryTaskScriptDialog(MomConsoleApp app, DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType ConfigurationType)
            : 
                base(app, Init(app, ConfigurationType))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDiagnosticAndRecoveryTaskScriptDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiagnosticAndRecoveryTaskScriptDialogControls Controls
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
        ///  Routine to set/get the text in control ExampleMyScriptvbs
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExampleMyScriptvbsText
        {
            get
            {
                return this.Controls.ExampleMyScriptvbsComboBox.Text;
            }
            
            set
            {
                this.Controls.ExampleMyScriptvbsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Timeout
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeoutText
        {
            get
            {
                return this.Controls.TimeoutComboBox.Text;
            }
            
            set
            {
                this.Controls.TimeoutComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AdditionalSettings
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AdditionalSettingsText
        {
            get
            {
                return this.Controls.AdditionalSettingsTextBox.Text;
            }
            
            set
            {
                this.Controls.AdditionalSettingsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FileName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FileNameText
        {
            get
            {
                return this.Controls.FileNameTextBox.Text;
            }
            
            set
            {
                this.Controls.FileNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskScriptDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskScriptDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskScriptDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskScriptDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagnosticTaskTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.DiagnosticTaskTypeStaticControl
        {
            get
            {
                if ((this.cachedDiagnosticTaskTypeStaticControl == null))
                {
                    this.cachedDiagnosticTaskTypeStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.DiagnosticTaskTypeStaticControl);
                }
                return this.cachedDiagnosticTaskTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.GeneralStaticControl
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
        ///  Exposes access to the SpecifyScriptDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.SpecifyScriptDetailsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSpecifyScriptDetailsStaticControl == null))
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
                    this.cachedSpecifyScriptDetailsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSpecifyScriptDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl
        {
            get
            {
                if ((this.cachedClickTheParametersButtonToSpecifyTheScriptParametersStaticControl == null))
                {
                    this.cachedClickTheParametersButtonToSpecifyTheScriptParametersStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl);
                }
                return this.cachedClickTheParametersButtonToSpecifyTheScriptParametersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExampleMyScriptvbsStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.ExampleMyScriptvbsStaticControl
        {
            get
            {
                if ((this.cachedExampleMyScriptvbsStaticControl == null))
                {
                    this.cachedExampleMyScriptvbsStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.ExampleMyScriptvbsStaticControl);
                }
                return this.cachedExampleMyScriptvbsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExampleMyScriptvbsComboBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiagnosticAndRecoveryTaskScriptDialogControls.ExampleMyScriptvbsComboBox
        {
            get
            {
                if ((this.cachedExampleMyScriptvbsComboBox == null))
                {
                    this.cachedExampleMyScriptvbsComboBox = new ComboBox(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.ExampleMyScriptvbsComboBox);
                }
                return this.cachedExampleMyScriptvbsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeoutComboBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiagnosticAndRecoveryTaskScriptDialogControls.TimeoutComboBox
        {
            get
            {
                if ((this.cachedTimeoutComboBox == null))
                {
                    this.cachedTimeoutComboBox = new ComboBox(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.TimeoutComboBox);
                }
                return this.cachedTimeoutComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterScriptInformationStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.EnterScriptInformationStaticControl
        {
            get
            {
                if ((this.cachedEnterScriptInformationStaticControl == null))
                {
                    this.cachedEnterScriptInformationStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.EnterScriptInformationStaticControl);
                }
                return this.cachedEnterScriptInformationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskScriptDialogControls.ParametersButton
        {
            get
            {
                if ((this.cachedParametersButton == null))
                {
                    this.cachedParametersButton = new Button(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.ParametersButton);
                }
                return this.cachedParametersButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditInFullScreenButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskScriptDialogControls.EditInFullScreenButton
        {
            get
            {
                if ((this.cachedEditInFullScreenButton == null))
                {
                    this.cachedEditInFullScreenButton = new Button(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.EditInFullScreenButton);
                }
                return this.cachedEditInFullScreenButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdditionalSettingsTextBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagnosticAndRecoveryTaskScriptDialogControls.AdditionalSettingsTextBox
        {
            get
            {
                if ((this.cachedAdditionalSettingsTextBox == null))
                {
                    this.cachedAdditionalSettingsTextBox = new TextBox(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.AdditionalSettingsTextBox);
                }
                return this.cachedAdditionalSettingsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.ScriptStaticControl
        {
            get
            {
                if ((this.cachedScriptStaticControl == null))
                {
                    this.cachedScriptStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.ScriptStaticControl);
                }
                return this.cachedScriptStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeoutStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.TimeoutStaticControl
        {
            get
            {
                if ((this.cachedTimeoutStaticControl == null))
                {
                    this.cachedTimeoutStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.TimeoutStaticControl);
                }
                return this.cachedTimeoutStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameTextBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagnosticAndRecoveryTaskScriptDialogControls.FileNameTextBox
        {
            get
            {
                if ((this.cachedFileNameTextBox == null))
                {
                    this.cachedFileNameTextBox = new TextBox(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.FileNameTextBox);
                }
                return this.cachedFileNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.FileNameStaticControl
        {
            get
            {
                if ((this.cachedFileNameStaticControl == null))
                {
                    this.cachedFileNameStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.FileNameStaticControl);
                }
                return this.cachedFileNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskScriptDialogControls.ScriptStaticControl2
        {
            get
            {
                if ((this.cachedScriptStaticControl2 == null))
                {
                    this.cachedScriptStaticControl2 = new StaticControl(this, DiagnosticAndRecoveryTaskScriptDialog.ControlIDs.ScriptStaticControl2);
                }
                return this.cachedScriptStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
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
        /// 	[asttest] 8/4/2008 Created
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
        /// 	[asttest] 8/4/2008 Created
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
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Parameters
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickParameters()
        {
            this.Controls.ParametersButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EditInFullScreen
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEditInFullScreen()
        {
            this.Controls.EditInFullScreenButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsole App owning the dialog.</param>
        /// <param name='ConfigurationType'> </param>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType ConfigurationType)
        {
            // First check if the dialog is already up.
            //Chooose appropiate dialog title depending on type
            string dialogTitle = null;
            // First check if the dialog is already up.

            switch (ConfigurationType)
            {
                case DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType.Diagonostic:
                    dialogTitle = Strings.DiagnosticDialogTitle;
                    break;
                case DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery:
                    dialogTitle = Strings.RecoveryDialogTitle;
                    break;
            }
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    dialogTitle,
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
                const int MaxTries = 15;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                app.GetIntlStr(dialogTitle) + "*",
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
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                       dialogTitle + "'");

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
        /// 	[asttest] 8/4/2008 Created
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
            /// <history>
            ///  [sunsingh] 1/27/2009 Updated ResourceDialogTitle to correct resource string
            /// </history>
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticDialogTitle = ";Create Diagnostic Task Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateDiagnosticTaskWizard";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// <history>
            ///  [sunsingh] 1/27/2009 Updated ResourceDialogTitle to correct resource string
            /// </history>
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceRecoveryDialogTitle = ";Create Recovery Task Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateRecoveryTaskWizard";
                        
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
            /// Contains resource string for:  DiagnosticTaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticTaskType = ";Diagnostic Task Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseDiagnosticPa" +
                "ge;$this.NavigationText";
            
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
            /// Contains resource string for:  SpecifyScriptDetails
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyScriptDetails = "Specify Script Details";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClickTheParametersButtonToSpecifyTheScriptParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClickTheParametersButtonToSpecifyTheScriptParameters = ";Click the \"Parameters...\" button to specify the script parameters.;ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement." +
                "Internal.UI.Authoring.Pages.ScriptPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExampleMyScriptvbs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExampleMyScriptvbs = ";Example:  MyScript.vbs;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;idLab" +
                "elExample.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterScriptInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterScriptInformation = ";Enter script information;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;pag" +
                "eSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParameters = ";P&arameters...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;btnParameters" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EditInFullScreen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEditInFullScreen = ";&Edit in full screen...;ManagedString;Microsoft.EnterpriseManagement.UI.Authorin" +
                "g.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;btnE" +
                "dit.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Script
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScript = ";&Script:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;lblScript.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Timeout
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeout = ";&Timeout:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionPage;idLabe" +
                "lTimeout.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FileName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFileName = ";File &Name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.ScriptPage;lblName.Text";
            
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
            /// Contains resource string for:  Script2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScript2 = ";Script;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Propert" +
                "ies.Resources;ScriptName";
            #endregion
            
            #region Private Members


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecoveryDialogTitle;

            
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
            /// Caches the translated resource string for:  DiagnosticTaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticTaskType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyScriptDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyScriptDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClickTheParametersButtonToSpecifyTheScriptParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClickTheParametersButtonToSpecifyTheScriptParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExampleMyScriptvbs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExampleMyScriptvbs;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterScriptInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterScriptInformation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EditInFullScreen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditInFullScreen;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Script
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScript;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Timeout
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeout;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FileName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFileName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Script2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScript2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticDialogTitle
            {
                get
                {
                    if ((cachedDiagnosticDialogTitle == null))
                    {
                        cachedDiagnosticDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticDialogTitle);
                    }

                    return cachedDiagnosticDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecoveryDialogTitle
            {
                get
                {
                    if ((cachedRecoveryDialogTitle == null))
                    {
                        cachedRecoveryDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceRecoveryDialogTitle);
                    }

                    return cachedRecoveryDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
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
            /// 	[asttest] 8/4/2008 Created
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
            /// 	[asttest] 8/4/2008 Created
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
            /// 	[asttest] 8/4/2008 Created
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
            /// Exposes access to the DiagnosticTaskType translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticTaskType
            {
                get
                {
                    if ((cachedDiagnosticTaskType == null))
                    {
                        cachedDiagnosticTaskType = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticTaskType);
                    }
                    return cachedDiagnosticTaskType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
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
            /// Exposes access to the SpecifyScriptDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyScriptDetails
            {
                get
                {
                    if ((cachedSpecifyScriptDetails == null))
                    {
                        cachedSpecifyScriptDetails = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyScriptDetails);
                    }
                    return cachedSpecifyScriptDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClickTheParametersButtonToSpecifyTheScriptParameters translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClickTheParametersButtonToSpecifyTheScriptParameters
            {
                get
                {
                    if ((cachedClickTheParametersButtonToSpecifyTheScriptParameters == null))
                    {
                        cachedClickTheParametersButtonToSpecifyTheScriptParameters = CoreManager.MomConsole.GetIntlStr(ResourceClickTheParametersButtonToSpecifyTheScriptParameters);
                    }
                    return cachedClickTheParametersButtonToSpecifyTheScriptParameters;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExampleMyScriptvbs translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExampleMyScriptvbs
            {
                get
                {
                    if ((cachedExampleMyScriptvbs == null))
                    {
                        cachedExampleMyScriptvbs = CoreManager.MomConsole.GetIntlStr(ResourceExampleMyScriptvbs);
                    }
                    return cachedExampleMyScriptvbs;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterScriptInformation translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterScriptInformation
            {
                get
                {
                    if ((cachedEnterScriptInformation == null))
                    {
                        cachedEnterScriptInformation = CoreManager.MomConsole.GetIntlStr(ResourceEnterScriptInformation);
                    }
                    return cachedEnterScriptInformation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Parameters translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
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
            /// Exposes access to the EditInFullScreen translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EditInFullScreen
            {
                get
                {
                    if ((cachedEditInFullScreen == null))
                    {
                        cachedEditInFullScreen = CoreManager.MomConsole.GetIntlStr(ResourceEditInFullScreen);
                    }
                    return cachedEditInFullScreen;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Script translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
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
            /// Exposes access to the Timeout translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Timeout
            {
                get
                {
                    if ((cachedTimeout == null))
                    {
                        cachedTimeout = CoreManager.MomConsole.GetIntlStr(ResourceTimeout);
                    }
                    return cachedTimeout;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FileName translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FileName
            {
                get
                {
                    if ((cachedFileName == null))
                    {
                        cachedFileName = CoreManager.MomConsole.GetIntlStr(ResourceFileName);
                    }
                    return cachedFileName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
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
            /// Exposes access to the Script2 translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Script2
            {
                get
                {
                    if ((cachedScript2 == null))
                    {
                        cachedScript2 = CoreManager.MomConsole.GetIntlStr(ResourceScript2);
                    }
                    return cachedScript2;
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
        /// 	[asttest] 8/4/2008 Created
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
            /// Control ID for DiagnosticTaskTypeStaticControl
            /// </summary>
            public const string DiagnosticTaskTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SpecifyScriptDetailsStaticControl
            /// </summary>
            public const string SpecifyScriptDetailsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl
            /// </summary>
            public const string ClickTheParametersButtonToSpecifyTheScriptParametersStaticControl = "label1";
            
            /// <summary>
            /// Control ID for ExampleMyScriptvbsStaticControl
            /// </summary>
            public const string ExampleMyScriptvbsStaticControl = "idLabelExample";
            
            /// <summary>
            /// Control ID for ExampleMyScriptvbsComboBox
            /// </summary>
            public const string ExampleMyScriptvbsComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for TimeoutComboBox
            /// </summary>
            public const string TimeoutComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for EnterScriptInformationStaticControl
            /// </summary>
            public const string EnterScriptInformationStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for ParametersButton
            /// </summary>
            public const string ParametersButton = "btnParameters";
            
            /// <summary>
            /// Control ID for EditInFullScreenButton
            /// </summary>
            public const string EditInFullScreenButton = "btnEdit";
            
            /// <summary>
            /// Control ID for AdditionalSettingsTextBox
            /// </summary>
            public const string AdditionalSettingsTextBox = "scriptSyntaxBox";
            
            /// <summary>
            /// Control ID for ScriptStaticControl
            /// </summary>
            public const string ScriptStaticControl = "lblScript";
            
            /// <summary>
            /// Control ID for TimeoutStaticControl
            /// </summary>
            public const string TimeoutStaticControl = "lblTimeout";
            
            /// <summary>
            /// Control ID for FileNameTextBox
            /// </summary>
            public const string FileNameTextBox = "txtName";
            
            /// <summary>
            /// Control ID for FileNameStaticControl
            /// </summary>
            public const string FileNameStaticControl = "lblName";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ScriptStaticControl2
            /// </summary>
            public const string ScriptStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
