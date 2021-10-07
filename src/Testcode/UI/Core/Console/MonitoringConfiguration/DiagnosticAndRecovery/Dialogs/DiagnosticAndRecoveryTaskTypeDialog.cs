// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiagnosticAndRecoveryTaskTypeDialog.cs">
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
    using Microsoft.EnterpriseManagement.Mom.Internal;
    using System;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IDiagnosticAndRecoveryTaskTypeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiagnosticAndRecoveryTaskTypeDialogControls, for DiagnosticAndRecoveryTaskTypeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 7/30/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiagnosticAndRecoveryTaskTypeDialogControls
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
        /// Read-only property to access NewButton
        /// </summary>
        Button NewButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParentMonitorComboBox
        /// </summary>
        ComboBox ParentMonitorComboBox
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
        /// Read-only property to access SelectDestinationManagementPackStaticControl
        /// </summary>
        StaticControl SelectDestinationManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheTypeOfDiagnosticTaskToCreateStaticControl
        /// </summary>
        StaticControl SelectTheTypeOfDiagnosticTaskToCreateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorTargetTreeView
        /// </summary>
        TreeView MonitorTargetTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AdditionalSettingsTreeView for recovery
        /// </summary>
        TreeView AdditionalSettingsTreeView
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
        /// Read-only property to access SelectDiagnosticTaskTypeStaticControl
        /// </summary>
        StaticControl SelectDiagnosticTaskTypeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectDestinationManagementPackComboBox
        /// </summary>
        ComboBox SelectDestinationManagementPackComboBox
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
    public class DiagnosticAndRecoveryTaskTypeDialog : Dialog, IDiagnosticAndRecoveryTaskTypeDialogControls
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
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;
        
        /// <summary>
        /// Cache to hold a reference to ParentMonitorComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedParentMonitorComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectDestinationManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheTypeOfDiagnosticTaskToCreateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheTypeOfDiagnosticTaskToCreateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitorTargetTreeView of type TreeView
        /// </summary>
        private TreeView cachedMonitorTargetTreeView;

        /// <summary>
        /// Cache to hold a reference to MonitorTargetTreeView of type TreeView
        /// </summary>
        private TreeView cachedAdditionalSettingsTreeView;
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectDiagnosticTaskTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectDiagnosticTaskTypeStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectDestinationManagementPackComboBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DiagnosticAndRecoveryTaskTypeDialog of type MomConsoleApp
        /// </param>
        /// <param name='ConfigurationType'> </param>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiagnosticAndRecoveryTaskTypeDialog(MomConsoleApp app, DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType ConfigurationType)
            :
                base(app, Init(app, ConfigurationType))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDiagnosticAndRecoveryTaskTypeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiagnosticAndRecoveryTaskTypeDialogControls Controls
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
        ///  Routine to set/get the text in control ParentMonitor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ParentMonitorText
        {
            get
            {
                return this.Controls.ParentMonitorComboBox.Text;
            }
            
            set
            {
                this.Controls.ParentMonitorComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SelectDestinationManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectDestinationManagementPackText
        {
            get
            {
                return this.Controls.SelectDestinationManagementPackComboBox.Text;
            }
            
            set
            {
                this.Controls.SelectDestinationManagementPackComboBox.SelectByText(value, true);
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
        Button IDiagnosticAndRecoveryTaskTypeDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.PreviousButton);
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
        Button IDiagnosticAndRecoveryTaskTypeDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.NextButton);
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
        Button IDiagnosticAndRecoveryTaskTypeDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.CreateButton);
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
        Button IDiagnosticAndRecoveryTaskTypeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.CancelButton);
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
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.DiagnosticTaskTypeStaticControl
        {
            get
            {
                if ((this.cachedDiagnosticTaskTypeStaticControl == null))
                {
                    this.cachedDiagnosticTaskTypeStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.DiagnosticTaskTypeStaticControl);
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
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.GeneralStaticControl
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
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.CommandLineStaticControl
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
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagnosticAndRecoveryTaskTypeDialogControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.NewButton);
                }
                
                return this.cachedNewButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParentMonitorComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiagnosticAndRecoveryTaskTypeDialogControls.ParentMonitorComboBox
        {
            get
            {
                if ((this.cachedParentMonitorComboBox == null))
                {
                    this.cachedParentMonitorComboBox = new ComboBox(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.ParentMonitorComboBox);
                }
                
                return this.cachedParentMonitorComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiagnosticAndRecoveryTaskTypeDialogControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackComboBox == null))
                {
                    this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.SelectDestinationManagementPackComboBox);
                }
                return this.cachedSelectDestinationManagementPackComboBox;
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
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.ManagementPackStaticControl);
                }
                
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.SelectDestinationManagementPackStaticControl
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackStaticControl == null))
                {
                    this.cachedSelectDestinationManagementPackStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.SelectDestinationManagementPackStaticControl);
                }
                
                return this.cachedSelectDestinationManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTypeOfDiagnosticTaskToCreateStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.SelectTheTypeOfDiagnosticTaskToCreateStaticControl
        {
            get
            {
                // The ID for this control (pageSectionLabel1) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSelectTheTypeOfDiagnosticTaskToCreateStaticControl == null))
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedSelectTheTypeOfDiagnosticTaskToCreateStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedSelectTheTypeOfDiagnosticTaskToCreateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.DescriptionStaticControl);
                }
                
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTargetTreeView control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IDiagnosticAndRecoveryTaskTypeDialogControls.MonitorTargetTreeView
        {
            get
            {
                if ((this.cachedMonitorTargetTreeView == null))
                {
                    this.cachedMonitorTargetTreeView = new TreeView(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.MonitorTargetTreeView);
                }
                
                return this.cachedMonitorTargetTreeView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdditionalSettingsTreeView control
        /// </summary>
        /// <history>
        /// 	[asttest] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IDiagnosticAndRecoveryTaskTypeDialogControls.AdditionalSettingsTreeView
        {
            get
            {
                if ((this.cachedAdditionalSettingsTreeView == null))
                {
                    this.cachedAdditionalSettingsTreeView = new TreeView(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.AdditionalSettingsTreeView);
                }
                return this.cachedAdditionalSettingsTreeView;
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
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDiagnosticTaskTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiagnosticAndRecoveryTaskTypeDialogControls.SelectDiagnosticTaskTypeStaticControl
        {
            get
            {
                if ((this.cachedSelectDiagnosticTaskTypeStaticControl == null))
                {
                    this.cachedSelectDiagnosticTaskTypeStaticControl = new StaticControl(this, DiagnosticAndRecoveryTaskTypeDialog.ControlIDs.SelectDiagnosticTaskTypeStaticControl);
                }
                
                return this.cachedSelectDiagnosticTaskTypeStaticControl;
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
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
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
        private static Window Init(MomConsoleApp app,DiagnosticAndRecovery.DiagnosticAndRecoveryParameters.enumConfigrationType ConfigurationType)
        {
            
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
            //First check if the dialog is already up.
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
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                dialogTitle + "*",
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
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
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
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.ConsoleCommandLineTask
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDRunCommandTask = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.RunCommand);
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Microsoft.SystemCenter.TaskTemplates.ScriptTask 
            /// </summary>   
            /// -----------------------------------------------------------------------------
           
            private static Guid GUIDScriptTask = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.RunScript);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticDialogTitle = ";Create Diagnostic Task Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateDiagnosticTaskWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
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
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";N&ew...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.RunAsProfi" +
                "leComboBoxControl;buttonProfile.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management pack;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Controls.ManagementPackComboBoxControl;pageSectionL" +
                "abel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectDestinationManagementPack = ";&Select destination management pack:;ManagedString;Microsoft.MOM.UI.Components.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ManagementPackComboBo" +
                "xControl;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheTypeOfDiagnosticTaskToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheTypeOfDiagnosticTaskToCreate = ";Select the type of diagnostic task to create;ManagedString;Microsoft.EnterpriseM" +
                "anagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring." +
                "Pages.ChooseDiagnosticPage;pageSectionLabel1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";Description:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AdminNodeDetailView;descrip" +
                "tionLabel.Text";
            
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
            /// Contains resource string for:  SelectDiagnosticTaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectDiagnosticTaskType = ";Select Diagnostic Task Type;ManagedString;Microsoft.EnterpriseManagement.UI.Auth" +
                "oring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseDiagn" +
                "osticPage;$this.HeaderText";
            #endregion
            
            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.ScriptTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedScriptTask;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the display name string for: Microsoft.SystemCenter.TaskTemplates.ConsoleCommandLineTask
            /// </summary>
            /// <history>
            /// 	[faizalk] 13FEB07: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedRunCommandTask;

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
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectDestinationManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheTypeOfDiagnosticTaskToCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheTypeOfDiagnosticTaskToCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectDiagnosticTaskType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectDiagnosticTaskType;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiagnosticDialogTitle translated resource string
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
            /// Exposes access to display name string for: 
            /// </summary>
            /// <history>
            /// 	[sunsingh] 29Aug08: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScriptTask
            {
                get
                {
                    if ((cachedScriptTask == null))
                    {
                        cachedScriptTask = Common.Utilities.GetManagementPackModuleTypeName(GUIDScriptTask);
                    }

                    return cachedScriptTask;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: 
            /// </summary>
            /// <history>
            /// 	[sunsingh] 29Aug08: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunCommandTask
            {
                get
                {
                    if ((cachedRunCommandTask == null))
                    {
                        cachedRunCommandTask = Common.Utilities.GetManagementPackModuleTypeName(GUIDRunCommandTask);
                    }

                    return cachedRunCommandTask;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiagnosticDialogTitle translated resource string
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
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string New
            {
                get
                {
                    if ((cachedNew == null))
                    {
                        cachedNew = CoreManager.MomConsole.GetIntlStr(ResourceNew);
                    }
                    
                    return cachedNew;
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
            /// Exposes access to the SelectDestinationManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectDestinationManagementPack
            {
                get
                {
                    if ((cachedSelectDestinationManagementPack == null))
                    {
                        cachedSelectDestinationManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceSelectDestinationManagementPack);
                    }
                    
                    return cachedSelectDestinationManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheTypeOfDiagnosticTaskToCreate translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheTypeOfDiagnosticTaskToCreate
            {
                get
                {
                    if ((cachedSelectTheTypeOfDiagnosticTaskToCreate == null))
                    {
                        cachedSelectTheTypeOfDiagnosticTaskToCreate = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheTypeOfDiagnosticTaskToCreate);
                    }
                    
                    return cachedSelectTheTypeOfDiagnosticTaskToCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    
                    return cachedDescription;
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
            /// Exposes access to the SelectDiagnosticTaskType translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 7/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectDiagnosticTaskType
            {
                get
                {
                    if ((cachedSelectDiagnosticTaskType == null))
                    {
                        cachedSelectDiagnosticTaskType = CoreManager.MomConsole.GetIntlStr(ResourceSelectDiagnosticTaskType);
                    }
                    
                    return cachedSelectDiagnosticTaskType;
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
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newmpButton";
            
            /// <summary>
            /// Control ID for ParentMonitorComboBox
            /// </summary>
            public const string ParentMonitorComboBox = "comboBoxMp";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for SelectDestinationManagementPackStaticControl
            /// </summary>
            public const string SelectDestinationManagementPackStaticControl = "label1";
            
            /// <summary>
            /// Control ID for SelectTheTypeOfDiagnosticTaskToCreateStaticControl
            /// </summary>
            public const string SelectTheTypeOfDiagnosticTaskToCreateStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "descLabel";
            
            /// <summary>
            /// Control ID for MonitorTargetTreeView
            /// </summary>
            public const string MonitorTargetTreeView = "diagnosticTypesTreeView";

            /// <summary>
            /// Control ID for AdditionalSettingsTreeView
            /// </summary>
            public const string AdditionalSettingsTreeView = "recoveryTypesTreeView";
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SelectDiagnosticTaskTypeStaticControl
            /// </summary>
            public const string SelectDiagnosticTaskTypeStaticControl = "headerLabel";

            /// <summary>
            /// Control ID for SelectDestinationManagementPackComboBox
            /// </summary>
            public const string SelectDestinationManagementPackComboBox = "comboBoxMp";

        }
        #endregion
    }
}
