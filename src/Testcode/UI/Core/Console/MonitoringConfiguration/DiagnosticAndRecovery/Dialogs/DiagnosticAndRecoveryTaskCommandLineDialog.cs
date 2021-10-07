// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiagnosticAndRecoveryTaskCommandLineDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sunsingh] 7/30/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.DiagnosticAndRecovery.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IDiagnosticAndRecoveryTaskCommandLineDialog

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiagnosticAndRecoveryTaskCommandLineDialog, for DiagnosticAndRecoveryTaskCommandLineDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[asttest] 8/3/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiagnosticAndRecoveryTaskCommandLineDialog
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
        /// Read-only property to access CommandLineStaticControl
        /// </summary>
        StaticControl CommandLineStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdditionalSettingsStaticControl
        /// </summary>
        StaticControl AdditionalSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyCommandLineExecutionSettingsStaticControl
        /// </summary>
        StaticControl SpecifyCommandLineExecutionSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WorkingDirectoryTextBox
        /// </summary>
        TextBox WorkingDirectoryTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WorkingDirectoryStaticControl
        /// </summary>
        StaticControl WorkingDirectoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SecStaticControl
        /// </summary>
        StaticControl SecStaticControl
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
        /// Read-only property to access TimeoutComboBox
        /// </summary>
        ComboBox TimeoutComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParametersTextBox
        /// </summary>
        TextBox ParametersTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParametersStaticControl
        /// </summary>
        StaticControl ParametersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExampleCwindowssystem32pingexeStaticControl
        /// </summary>
        StaticControl ExampleCwindowssystem32pingexeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FullPathToFileTextBox
        /// </summary>
        TextBox FullPathToFileTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FullPathToFileStaticControl
        /// </summary>
        StaticControl FullPathToFileStaticControl
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
        /// Read-only property to access ConfigureCommandLineExecutionSettingsStaticControl
        /// </summary>
        StaticControl ConfigureCommandLineExecutionSettingsStaticControl
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
    /// 	[asttest] 8/3/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DiagnosticAndRecoveryTaskCommandLineDialog : Dialog, IDiagnosticAndRecoveryTaskCommandLineDialog
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
        /// Cache to hold a reference to CommandLineStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommandLineStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to AdditionalSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdditionalSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyCommandLineExecutionSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyCommandLineExecutionSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WorkingDirectoryTextBox of type TextBox
        /// </summary>
        private TextBox cachedWorkingDirectoryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to WorkingDirectoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWorkingDirectoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SecStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSecStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TimeoutStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTimeoutStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TimeoutComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimeoutComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ParametersTextBox of type TextBox
        /// </summary>
        private TextBox cachedParametersTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParametersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExampleCwindowssystem32pingexeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExampleCwindowssystem32pingexeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FullPathToFileTextBox of type TextBox
        /// </summary>
        private TextBox cachedFullPathToFileTextBox;
        
        /// <summary>
        /// Cache to hold a reference to FullPathToFileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFullPathToFileStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureCommandLineExecutionSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureCommandLineExecutionSettingsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DiagnosticAndRecoveryTaskCommandLineDialog of type MomConsoleApp
        /// </param>
        /// <param name='ConfigurationType'> </param>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiagnosticAndRecoveryTaskCommandLineDialog(MomConsoleApp app, DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType ConfigurationType)
            :
                base(app, Init(app, ConfigurationType))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDiagnosticAndRecoveryTaskCommandLineDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiagnosticAndRecoveryTaskCommandLineDialog Controls
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
        ///  Routine to set/get the text in control WorkingDirectory
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WorkingDirectoryText
        {
            get
            {
                return this.Controls.WorkingDirectoryTextBox.Text;
            }
            
            set
            {
                this.Controls.WorkingDirectoryTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Timeout
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
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
        ///  Routine to set/get the text in control Parameters
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ParametersText
        {
            get
            {
                return this.Controls.ParametersTextBox.Text;
            }
            
            set
            {
                this.Controls.ParametersTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FullPathToFile
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FullPathToFileText
        {
            get
            {
                return this.Controls.FullPathToFileTextBox.Text;
            }
            
            set
            {
                this.Controls.FullPathToFileTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskCommandLineDialog.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskCommandLineDialog.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskCommandLineDialog.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskCommandLineDialog.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagnosticTaskTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.DiagnosticTaskTypeStaticControl
        {
            get
            {
                if ((this.cachedDiagnosticTaskTypeStaticControl == null))
                {
                    this.cachedDiagnosticTaskTypeStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.DiagnosticTaskTypeStaticControl);
                }
                return this.cachedDiagnosticTaskTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.GeneralStaticControl
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
        ///  Exposes access to the CommandLineStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.CommandLineStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCommandLineStaticControl == null))
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
                    this.cachedCommandLineStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedCommandLineStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskCommandLineDialog.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.Button0);
                }
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdditionalSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.AdditionalSettingsStaticControl
        {
            get
            {
                if ((this.cachedAdditionalSettingsStaticControl == null))
                {
                    this.cachedAdditionalSettingsStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.AdditionalSettingsStaticControl);
                }
                return this.cachedAdditionalSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyCommandLineExecutionSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.SpecifyCommandLineExecutionSettingsStaticControl
        {
            get
            {
                if ((this.cachedSpecifyCommandLineExecutionSettingsStaticControl == null))
                {
                    this.cachedSpecifyCommandLineExecutionSettingsStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.SpecifyCommandLineExecutionSettingsStaticControl);
                }
                return this.cachedSpecifyCommandLineExecutionSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WorkingDirectoryTextBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagnosticAndRecoveryTaskCommandLineDialog.WorkingDirectoryTextBox
        {
            get
            {
                if ((this.cachedWorkingDirectoryTextBox == null))
                {
                    this.cachedWorkingDirectoryTextBox = new TextBox(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.WorkingDirectoryTextBox);
                }
                return this.cachedWorkingDirectoryTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WorkingDirectoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.WorkingDirectoryStaticControl
        {
            get
            {
                if ((this.cachedWorkingDirectoryStaticControl == null))
                {
                    this.cachedWorkingDirectoryStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.WorkingDirectoryStaticControl);
                }
                return this.cachedWorkingDirectoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SecStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.SecStaticControl
        {
            get
            {
                if ((this.cachedSecStaticControl == null))
                {
                    this.cachedSecStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.SecStaticControl);
                }
                return this.cachedSecStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeoutStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.TimeoutStaticControl
        {
            get
            {
                if ((this.cachedTimeoutStaticControl == null))
                {
                    this.cachedTimeoutStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.TimeoutStaticControl);
                }
                return this.cachedTimeoutStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeoutComboBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiagnosticAndRecoveryTaskCommandLineDialog.TimeoutComboBox
        {
            get
            {
                if ((this.cachedTimeoutComboBox == null))
                {
                    this.cachedTimeoutComboBox = new ComboBox(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.TimeoutComboBox);
                }
                return this.cachedTimeoutComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersTextBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagnosticAndRecoveryTaskCommandLineDialog.ParametersTextBox
        {
            get
            {
                if ((this.cachedParametersTextBox == null))
                {
                    this.cachedParametersTextBox = new TextBox(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.ParametersTextBox);
                }
                return this.cachedParametersTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.ParametersStaticControl
        {
            get
            {
                if ((this.cachedParametersStaticControl == null))
                {
                    this.cachedParametersStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.ParametersStaticControl);
                }
                return this.cachedParametersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExampleCwindowssystem32pingexeStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.ExampleCwindowssystem32pingexeStaticControl
        {
            get
            {
                if ((this.cachedExampleCwindowssystem32pingexeStaticControl == null))
                {
                    this.cachedExampleCwindowssystem32pingexeStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.ExampleCwindowssystem32pingexeStaticControl);
                }
                return this.cachedExampleCwindowssystem32pingexeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FullPathToFileTextBox control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagnosticAndRecoveryTaskCommandLineDialog.FullPathToFileTextBox
        {
            get
            {
                if ((this.cachedFullPathToFileTextBox == null))
                {
                    this.cachedFullPathToFileTextBox = new TextBox(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.FullPathToFileTextBox);
                }
                return this.cachedFullPathToFileTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FullPathToFileStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.FullPathToFileStaticControl
        {
            get
            {
                if ((this.cachedFullPathToFileStaticControl == null))
                {
                    this.cachedFullPathToFileStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.FullPathToFileStaticControl);
                }
                return this.cachedFullPathToFileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureCommandLineExecutionSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskCommandLineDialog.ConfigureCommandLineExecutionSettingsStaticControl
        {
            get
            {
                if ((this.cachedConfigureCommandLineExecutionSettingsStaticControl == null))
                {
                    this.cachedConfigureCommandLineExecutionSettingsStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskCommandLineDialog.ControlIDs.ConfigureCommandLineExecutionSettingsStaticControl);
                }
                return this.cachedConfigureCommandLineExecutionSettingsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
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
        /// 	[asttest] 8/3/2008 Created
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
        /// 	[asttest] 8/3/2008 Created
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
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        /// 	[asttest] 8/3/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }
        #endregion
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <param name='ConfigurationType'> </param>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
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
        /// 	[asttest] 8/3/2008 Created
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
            /// Contains resource string for:  CommandLine
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCommandLine = ";Command Line;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionPage;$th" +
                "is.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdditionalSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdditionalSettings = ";Additional settings;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionP" +
                "age;pageSectionLabel2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyCommandLineExecutionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyCommandLineExecutionSettings = ";Specify command line execution settings;ManagedString;Microsoft.EnterpriseManage" +
                "ment.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages" +
                ".CommandWriteActionPage;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WorkingDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWorkingDirectory = ";&Working directory:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionP" +
                "age;labelWorkingDirectory.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Sec
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSec = ";sec;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionPage;idLabelSecon" +
                "ds.Text";
            
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
            /// Contains resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParameters = ";&Parameters:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionPage;idL" +
                "abelParameters.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExampleCwindowssystem32pingexe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExampleCwindowssystem32pingexe = ";Example c:\\windows\\system32\\ping.exe;ManagedString;Microsoft.EnterpriseManagemen" +
                "t.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Co" +
                "mmandWriteActionPage;idLabelExample.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FullPathToFile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFullPathToFile = ";&Full path to file:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CommandWriteActionP" +
                "age;idLabelFullPath.Text";
            
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
            /// Contains resource string for:  ConfigureCommandLineExecutionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureCommandLineExecutionSettings = ";Configure Command Line Execution Settings;ManagedString;Microsoft.EnterpriseMana" +
                "gement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pag" +
                "es.CommandWriteActionPage;$this.HeaderText";
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
            /// Caches the translated resource string for:  CommandLine
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCommandLine;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdditionalSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdditionalSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyCommandLineExecutionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyCommandLineExecutionSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WorkingDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWorkingDirectory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Sec
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSec;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Timeout
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeout;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Parameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExampleCwindowssystem32pingexe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExampleCwindowssystem32pingexe;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FullPathToFile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFullPathToFile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureCommandLineExecutionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureCommandLineExecutionSettings;
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
            /// 	[asttest] 8/3/2008 Created
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
            /// 	[asttest] 8/3/2008 Created
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
            /// 	[asttest] 8/3/2008 Created
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
            /// 	[asttest] 8/3/2008 Created
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
            /// 	[asttest] 8/3/2008 Created
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
            /// 	[asttest] 8/3/2008 Created
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
            /// Exposes access to the CommandLine translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommandLine
            {
                get
                {
                    if ((cachedCommandLine == null))
                    {
                        cachedCommandLine = CoreManager.MomConsole.GetIntlStr(ResourceCommandLine);
                    }
                    return cachedCommandLine;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdditionalSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdditionalSettings
            {
                get
                {
                    if ((cachedAdditionalSettings == null))
                    {
                        cachedAdditionalSettings = CoreManager.MomConsole.GetIntlStr(ResourceAdditionalSettings);
                    }
                    return cachedAdditionalSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyCommandLineExecutionSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyCommandLineExecutionSettings
            {
                get
                {
                    if ((cachedSpecifyCommandLineExecutionSettings == null))
                    {
                        cachedSpecifyCommandLineExecutionSettings = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyCommandLineExecutionSettings);
                    }
                    return cachedSpecifyCommandLineExecutionSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WorkingDirectory translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WorkingDirectory
            {
                get
                {
                    if ((cachedWorkingDirectory == null))
                    {
                        cachedWorkingDirectory = CoreManager.MomConsole.GetIntlStr(ResourceWorkingDirectory);
                    }
                    return cachedWorkingDirectory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Sec translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Sec
            {
                get
                {
                    if ((cachedSec == null))
                    {
                        cachedSec = CoreManager.MomConsole.GetIntlStr(ResourceSec);
                    }
                    return cachedSec;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Timeout translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
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
            /// Exposes access to the Parameters translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
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
            /// Exposes access to the ExampleCwindowssystem32pingexe translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExampleCwindowssystem32pingexe
            {
                get
                {
                    if ((cachedExampleCwindowssystem32pingexe == null))
                    {
                        cachedExampleCwindowssystem32pingexe = CoreManager.MomConsole.GetIntlStr(ResourceExampleCwindowssystem32pingexe);
                    }
                    return cachedExampleCwindowssystem32pingexe;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FullPathToFile translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FullPathToFile
            {
                get
                {
                    if ((cachedFullPathToFile == null))
                    {
                        cachedFullPathToFile = CoreManager.MomConsole.GetIntlStr(ResourceFullPathToFile);
                    }
                    return cachedFullPathToFile;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
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
            /// Exposes access to the ConfigureCommandLineExecutionSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[asttest] 8/3/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureCommandLineExecutionSettings
            {
                get
                {
                    if ((cachedConfigureCommandLineExecutionSettings == null))
                    {
                        cachedConfigureCommandLineExecutionSettings = CoreManager.MomConsole.GetIntlStr(ResourceConfigureCommandLineExecutionSettings);
                    }
                    return cachedConfigureCommandLineExecutionSettings;
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
        /// 	[asttest] 8/3/2008 Created
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
            /// Control ID for CommandLineStaticControl
            /// </summary>
            public const string CommandLineStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "paramPropertySelectorBtn";
            
            /// <summary>
            /// Control ID for AdditionalSettingsStaticControl
            /// </summary>
            public const string AdditionalSettingsStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for SpecifyCommandLineExecutionSettingsStaticControl
            /// </summary>
            public const string SpecifyCommandLineExecutionSettingsStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for WorkingDirectoryTextBox
            /// </summary>
            public const string WorkingDirectoryTextBox = "idTextBoxWorkingDirectory";
            
            /// <summary>
            /// Control ID for WorkingDirectoryStaticControl
            /// </summary>
            public const string WorkingDirectoryStaticControl = "labelWorkingDirectory";
            
            /// <summary>
            /// Control ID for SecStaticControl
            /// </summary>
            public const string SecStaticControl = "idLabelSeconds";
            
            /// <summary>
            /// Control ID for TimeoutStaticControl
            /// </summary>
            public const string TimeoutStaticControl = "idLabelTimeout";
            
            /// <summary>
            /// Control ID for TimeoutComboBox
            /// </summary>
            public const string TimeoutComboBox = "iDNumericUpDown";
            
            /// <summary>
            /// Control ID for ParametersTextBox
            /// </summary>
            public const string ParametersTextBox = "idTextBoxParameters";
            
            /// <summary>
            /// Control ID for ParametersStaticControl
            /// </summary>
            public const string ParametersStaticControl = "idLabelParameters";
            
            /// <summary>
            /// Control ID for ExampleCwindowssystem32pingexeStaticControl
            /// </summary>
            public const string ExampleCwindowssystem32pingexeStaticControl = "idLabelExample";
            
            /// <summary>
            /// Control ID for FullPathToFileTextBox
            /// </summary>
            public const string FullPathToFileTextBox = "idTextBoxPath";
            
            /// <summary>
            /// Control ID for FullPathToFileStaticControl
            /// </summary>
            public const string FullPathToFileStaticControl = "idLabelFullPath";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureCommandLineExecutionSettingsStaticControl
            /// </summary>
            public const string ConfigureCommandLineExecutionSettingsStaticControl = "headerLabel";
        }
        #endregion
    }
}

