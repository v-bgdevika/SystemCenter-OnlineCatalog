// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiagnosticAndRecoveryTaskGeneralDialog.cs">
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
    
    #region Interface Definition - IDiagnosticAndRecoveryTaskGeneralDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiagnosticAndRecoveryTaskGeneralDialogControls, for DiagnosticAndRecoveryTaskGeneralDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 7/30/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiagnosticAndRecoveryTaskGeneralDialogControls
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
        /// Read-only property to access MonitorTargetComboBox
        /// </summary>
        ComboBox MonitorTargetComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl
        /// </summary>
        StaticControl SelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl
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
        /// Read-only property to access ManagementPackTextBox
        /// </summary>
        TextBox ManagementPackTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiagnosticTargetStaticControl
        /// </summary>
        StaticControl DiagnosticTargetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterDiagnosticTaskNameDescriptionAndTargetStaticControl
        /// </summary>
        StaticControl EnterDiagnosticTaskNameDescriptionAndTargetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunDiagnosticAutomaticallyCheckBox
        /// </summary>
        CheckBox RunDiagnosticAutomaticallyCheckBox
        {
            get;
        }


        /// <summary>
        /// Read-only property to access RecalculateMonitorStateAfterRecoveryFinishesCheckBox
        /// </summary>
        CheckBox RecalculateMonitorStateAfterRecoveryFinishesCheckBox
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
        /// Read-only property to access SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox
        /// </summary>
        TextBox SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiagnosticNameStaticControl
        /// </summary>
        StaticControl DiagnosticNameStaticControl
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
        /// Read-only property to access DiagnosticTaskNameAndDescriptionStaticControl
        /// </summary>
        StaticControl DiagnosticTaskNameAndDescriptionStaticControl
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
    /// 	[sunsingh] 7/30/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DiagnosticAndRecoveryTaskGeneralDialog : Dialog, IDiagnosticAndRecoveryTaskGeneralDialogControls
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
        /// Cache to hold a reference to MonitorTargetComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMonitorTargetComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl;
        
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
        /// Cache to hold a reference to ManagementPackTextBox of type TextBox
        /// </summary>
        private TextBox cachedManagementPackTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DiagnosticTargetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiagnosticTargetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterDiagnosticTaskNameDescriptionAndTargetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterDiagnosticTaskNameDescriptionAndTargetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunDiagnosticAutomaticallyCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedRunDiagnosticAutomaticallyCheckBox;

        /// <summary>
        /// Cache to hold a reference to RecalculateMonitorStateAfterRecoveryFinishesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedRecalculateMonitorStateAfterRecoveryFinishesCheckBox;
        

        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionOptionalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox of type TextBox
        /// </summary>
        private TextBox cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DiagnosticNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiagnosticNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiagnosticTaskNameAndDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiagnosticTaskNameAndDescriptionStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DiagnosticAndRecoveryTaskGeneralDialog of type MomConsoleApp
        /// </param>
        /// <param name='ConfigurationType'> </param>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiagnosticAndRecoveryTaskGeneralDialog(MomConsoleApp app, DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType ConfigurationType) : 
                base(app, Init(app, ConfigurationType))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDiagnosticAndRecoveryTaskGeneralDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiagnosticAndRecoveryTaskGeneralDialogControls Controls
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
        ///  Property to handle checkbox RunDiagnosticAutomatically
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool RunDiagnosticAutomatically
        {
            get
            {
                return this.Controls.RunDiagnosticAutomaticallyCheckBox.Checked;
            }
            
            set
            {
                this.Controls.RunDiagnosticAutomaticallyCheckBox.Checked = value;
            }
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox RecalculateMonitorStateAfterRecoveryFinishes
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool RecalculateMonitorStateAfterRecoveryFinishes
        {
            get
            {
                return this.Controls.RecalculateMonitorStateAfterRecoveryFinishesCheckBox.Checked;
            }

            set
            {
                this.Controls.RecalculateMonitorStateAfterRecoveryFinishesCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitorTarget
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MonitorTargetText
        {
            get
            {
                return this.Controls.MonitorTargetComboBox.Text;
            }
            
            set
            {
                this.Controls.MonitorTargetComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementPackText
        {
            get
            {
                return this.Controls.ManagementPackTextBox.Text;
            }
            
            set
            {
                this.Controls.ManagementPackTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DescriptionOptional
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
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
        ///  Routine to set/get the text in control SpecifyTheNameAndDescriptionForTheMonitorYouAreCreating
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingText
        {
            get
            {
                return this.Controls.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox.Text;
            }
            
            set
            {
                this.Controls.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskGeneralDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskGeneralDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskGeneralDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskGeneralDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagnosticTaskTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.DiagnosticTaskTypeStaticControl
        {
            get
            {
                if ((this.cachedDiagnosticTaskTypeStaticControl == null))
                {
                    this.cachedDiagnosticTaskTypeStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.DiagnosticTaskTypeStaticControl);
                }
                
                return this.cachedDiagnosticTaskTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.GeneralStaticControl
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
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.CommandLineStaticControl
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
        ///  Exposes access to the MonitorTargetComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiagnosticAndRecoveryTaskGeneralDialogControls.MonitorTargetComboBox
        {
            get
            {
                if ((this.cachedMonitorTargetComboBox == null))
                {
                    this.cachedMonitorTargetComboBox = new ComboBox(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.MonitorTargetComboBox);
                }
                
                return this.cachedMonitorTargetComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.SelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl
        {
            get
            {
                if ((this.cachedSelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl == null))
                {
                    this.cachedSelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.SelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl);
                }
                
                return this.cachedSelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.DefaultManagementPackStaticControl
        {
            get
            {
                if ((this.cachedDefaultManagementPackStaticControl == null))
                {
                    this.cachedDefaultManagementPackStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.DefaultManagementPackStaticControl);
                }
                
                return this.cachedDefaultManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.ManagementPackStaticControl);
                }
                
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskGeneralDialogControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.SelectButton);
                }
                
                return this.cachedSelectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackTextBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagnosticAndRecoveryTaskGeneralDialogControls.ManagementPackTextBox
        {
            get
            {
                if ((this.cachedManagementPackTextBox == null))
                {
                    this.cachedManagementPackTextBox = new TextBox(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.ManagementPackTextBox);
                }
                
                return this.cachedManagementPackTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagnosticTargetStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.DiagnosticTargetStaticControl
        {
            get
            {
                if ((this.cachedDiagnosticTargetStaticControl == null))
                {
                    this.cachedDiagnosticTargetStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.DiagnosticTargetStaticControl);
                }
                
                return this.cachedDiagnosticTargetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterDiagnosticTaskNameDescriptionAndTargetStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.EnterDiagnosticTaskNameDescriptionAndTargetStaticControl
        {
            get
            {
                if ((this.cachedEnterDiagnosticTaskNameDescriptionAndTargetStaticControl == null))
                {
                    this.cachedEnterDiagnosticTaskNameDescriptionAndTargetStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.EnterDiagnosticTaskNameDescriptionAndTargetStaticControl);
                }
                
                return this.cachedEnterDiagnosticTaskNameDescriptionAndTargetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunDiagnosticAutomaticallyCheckBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IDiagnosticAndRecoveryTaskGeneralDialogControls.RunDiagnosticAutomaticallyCheckBox
        {
            get
            {
                if ((this.cachedRunDiagnosticAutomaticallyCheckBox == null))
                {
                    this.cachedRunDiagnosticAutomaticallyCheckBox = new CheckBox(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.RunDiagnosticAutomaticallyCheckBox);
                }
                
                return this.cachedRunDiagnosticAutomaticallyCheckBox;
            }
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RecalculateMonitorStateAfterRecoveryFinishesCheckBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IDiagnosticAndRecoveryTaskGeneralDialogControls.RecalculateMonitorStateAfterRecoveryFinishesCheckBox
        {
            get
            {
                if ((this.cachedRecalculateMonitorStateAfterRecoveryFinishesCheckBox == null))
                {
                    this.cachedRecalculateMonitorStateAfterRecoveryFinishesCheckBox = new CheckBox(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.RecalculateMonitorStateAfterRecoveryFinishesCheckBox);
                }

                return this.cachedRecalculateMonitorStateAfterRecoveryFinishesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagnosticAndRecoveryTaskGeneralDialogControls.DescriptionOptionalTextBox
        {
            get
            {
                if ((this.cachedDescriptionOptionalTextBox == null))
                {
                    this.cachedDescriptionOptionalTextBox = new TextBox(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.DescriptionOptionalTextBox);
                }
                
                return this.cachedDescriptionOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.DescriptionOptionalStaticControl
        {
            get
            {
                if ((this.cachedDescriptionOptionalStaticControl == null))
                {
                    this.cachedDescriptionOptionalStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.DescriptionOptionalStaticControl);
                }
                
                return this.cachedDescriptionOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagnosticAndRecoveryTaskGeneralDialogControls.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox
        {
            get
            {
                if ((this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox == null))
                {
                    this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox = new TextBox(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox);
                }
                
                return this.cachedSpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagnosticNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.DiagnosticNameStaticControl
        {
            get
            {
                if ((this.cachedDiagnosticNameStaticControl == null))
                {
                    this.cachedDiagnosticNameStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.DiagnosticNameStaticControl);
                }
                
                return this.cachedDiagnosticNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagnosticTaskNameAndDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskGeneralDialogControls.DiagnosticTaskNameAndDescriptionStaticControl
        {
            get
            {
                if ((this.cachedDiagnosticTaskNameAndDescriptionStaticControl == null))
                {
                    this.cachedDiagnosticTaskNameAndDescriptionStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskGeneralDialog.ControlIDs.DiagnosticTaskNameAndDescriptionStaticControl);
                }
                
                return this.cachedDiagnosticTaskNameAndDescriptionStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
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
        /// 	[sunsingh] 7/30/2008 Created
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
        /// 	[sunsingh] 7/30/2008 Created
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
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelect()
        {
            this.Controls.SelectButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RunDiagnosticAutomatically
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRunDiagnosticAutomatically()
        {
            this.Controls.RunDiagnosticAutomaticallyCheckBox.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button RecalculateMonitorStateAfterRecoveryFinishes
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRecalculateMonitorStateAfterRecoveryFinishes()
        {
            this.Controls.RecalculateMonitorStateAfterRecoveryFinishesCheckBox.Click();
        }
        
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
                    dialogTitle = Strings.diagnosticDialogTitle;
                    break;
                case DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery:
                    dialogTitle = Strings.recoveryDialogTitle;
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
        /// 	[sunsingh] 7/30/2008 Created
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
            /// Contains resource string for:  SelectTheHealthStateForWhichThisDiagnosticWillRunFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheHealthStateForWhichThisDiagnosticWillRunFor = ";Select the &health state for which this diagnostic will run for:;ManagedString;M" +
                "icrosoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.In" +
                "ternal.UI.Authoring.Pages.DiagnosticGeneralPage;healthStateLabel.Text";
            
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
            /// Contains resource string for:  DiagnosticTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticTarget = ";Diagnostic tar&get:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagnosticGeneralPa" +
                "ge;targetLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterDiagnosticTaskNameDescriptionAndTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterDiagnosticTaskNameDescriptionAndTarget = ";Enter diagnostic task name, description and target;ManagedString;Microsoft.Enter" +
                "priseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Auth" +
                "oring.Pages.DiagnosticGeneralPage;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunDiagnosticAutomatically
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunDiagnosticAutomatically = ";Run diagn&ostic automatically;ManagedString;Microsoft.EnterpriseManagement.UI.Au" +
                "thoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Diagnosti" +
                "cGeneralPage;enabledCheckbox.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RecalculateMonitorStateAfterRecoveryFinishes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRecalculateMonitorStateAfterRecoveryFinishes = ";Rec&alculate monitor state after recovery finishes;ManagedString;Microsoft.Enter" +
                "priseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Auth" +
                "oring.Pages.RecoveryGeneralPage;resetMonitorCheckBox.Text";
            
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
            /// Contains resource string for:  DiagnosticName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticName = ";Diagnostic na&me:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagnosticGeneralPage" +
                ";nameLabel.Text";
            
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
            /// Contains resource string for:  DiagnosticTaskNameAndDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticTaskNameAndDescription = ";Diagnostic Task Name and Description;ManagedString;Microsoft.EnterpriseManagemen" +
                "t.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Di" +
                "agnosticGeneralPage;$this.HeaderText";
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
            /// Caches the translated resource string for:  SelectTheHealthStateForWhichThisDiagnosticWillRunFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheHealthStateForWhichThisDiagnosticWillRunFor;
            
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
            /// Caches the translated resource string for:  DiagnosticTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterDiagnosticTaskNameDescriptionAndTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterDiagnosticTaskNameDescriptionAndTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunDiagnosticAutomatically
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunDiagnosticAutomatically;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DescriptionOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescriptionOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiagnosticName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiagnosticTaskNameAndDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticTaskNameAndDescription;
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
            public static string diagnosticDialogTitle
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
            public static string recoveryDialogTitle
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// Exposes access to the SelectTheHealthStateForWhichThisDiagnosticWillRunFor translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheHealthStateForWhichThisDiagnosticWillRunFor
            {
                get
                {
                    if ((cachedSelectTheHealthStateForWhichThisDiagnosticWillRunFor == null))
                    {
                        cachedSelectTheHealthStateForWhichThisDiagnosticWillRunFor = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheHealthStateForWhichThisDiagnosticWillRunFor);
                    }
                    
                    return cachedSelectTheHealthStateForWhichThisDiagnosticWillRunFor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// 	[sunsingh] 7/30/2008 Created
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
            /// Exposes access to the DiagnosticTarget translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticTarget
            {
                get
                {
                    if ((cachedDiagnosticTarget == null))
                    {
                        cachedDiagnosticTarget = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticTarget);
                    }
                    
                    return cachedDiagnosticTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterDiagnosticTaskNameDescriptionAndTarget translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterDiagnosticTaskNameDescriptionAndTarget
            {
                get
                {
                    if ((cachedEnterDiagnosticTaskNameDescriptionAndTarget == null))
                    {
                        cachedEnterDiagnosticTaskNameDescriptionAndTarget = CoreManager.MomConsole.GetIntlStr(ResourceEnterDiagnosticTaskNameDescriptionAndTarget);
                    }
                    
                    return cachedEnterDiagnosticTaskNameDescriptionAndTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunDiagnosticAutomatically translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunDiagnosticAutomatically
            {
                get
                {
                    if ((cachedRunDiagnosticAutomatically == null))
                    {
                        cachedRunDiagnosticAutomatically = CoreManager.MomConsole.GetIntlStr(ResourceRunDiagnosticAutomatically);
                    }
                    
                    return cachedRunDiagnosticAutomatically;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DescriptionOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
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
            /// Exposes access to the DiagnosticName translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticName
            {
                get
                {
                    if ((cachedDiagnosticName == null))
                    {
                        cachedDiagnosticName = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticName);
                    }
                    
                    return cachedDiagnosticName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
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
            /// Exposes access to the DiagnosticTaskNameAndDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticTaskNameAndDescription
            {
                get
                {
                    if ((cachedDiagnosticTaskNameAndDescription == null))
                    {
                        cachedDiagnosticTaskNameAndDescription = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticTaskNameAndDescription);
                    }
                    
                    return cachedDiagnosticTaskNameAndDescription;
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
        /// 	[sunsingh] 7/30/2008 Created
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
            /// Control ID for MonitorTargetComboBox
            /// </summary>
            public const string MonitorTargetComboBox = "healthStateComboBox";
            
            /// <summary>
            /// Control ID for SelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl
            /// </summary>
            public const string SelectTheHealthStateForWhichThisDiagnosticWillRunForStaticControl = "healthStateLabel";
            
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
            /// Control ID for ManagementPackTextBox
            /// </summary>
            public const string ManagementPackTextBox = "targetBox";
            
            /// <summary>
            /// Control ID for DiagnosticTargetStaticControl
            /// </summary>
            public const string DiagnosticTargetStaticControl = "targetLabel";
            
            /// <summary>
            /// Control ID for EnterDiagnosticTaskNameDescriptionAndTargetStaticControl
            /// </summary>
            public const string EnterDiagnosticTaskNameDescriptionAndTargetStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for RunDiagnosticAutomaticallyCheckBox
            /// </summary>
            public const string RunDiagnosticAutomaticallyCheckBox = "enabledCheckbox";

            /// <summary>
            /// Control ID for RecalculateMonitorStateAfterRecoveryFinishesCheckBox
            /// </summary>
            public const string RecalculateMonitorStateAfterRecoveryFinishesCheckBox = "resetMonitorCheckBox";


            /// <summary>
            /// Control ID for DescriptionOptionalTextBox
            /// </summary>
            public const string DescriptionOptionalTextBox = "descriptionTextbox";
            
            /// <summary>
            /// Control ID for DescriptionOptionalStaticControl
            /// </summary>
            public const string DescriptionOptionalStaticControl = "descriptionLabel";
            
            /// <summary>
            /// Control ID for SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox
            /// </summary>
            public const string SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingTextBox = "nameTextbox";
            
            /// <summary>
            /// Control ID for DiagnosticNameStaticControl
            /// </summary>
            public const string DiagnosticNameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for DiagnosticTaskNameAndDescriptionStaticControl
            /// </summary>
            public const string DiagnosticTaskNameAndDescriptionStaticControl = "headerLabel";
        }
        #endregion
    }
}
