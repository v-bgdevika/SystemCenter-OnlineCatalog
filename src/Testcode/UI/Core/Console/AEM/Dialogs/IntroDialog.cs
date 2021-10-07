// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="IntroDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	AEM Deployment Dialog - intro screen
// </summary>
// <history>
// 	[lucyra] 4/13/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.AEM.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IIntroDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IIntroDialogControls, for IntroDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IIntroDialogControls
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
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access IntroductionStaticControl
        /// </summary>
        StaticControl IntroductionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CEIPForwardingStaticControl
        /// </summary>
        StaticControl CEIPForwardingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorCollectionStaticControl
        /// </summary>
        StaticControl ErrorCollectionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorForwardingStaticControl
        /// </summary>
        StaticControl ErrorForwardingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateFileShareStaticControl
        /// </summary>
        StaticControl CreateFileShareStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskStatusStaticControl
        /// </summary>
        StaticControl TaskStatusStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DeploySettingsStaticControl
        /// </summary>
        StaticControl DeploySettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe
        /// </summary>
        StaticControl ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThisWizardWillHelpYouToStaticControl
        /// </summary>
        StaticControl ThisWizardWillHelpYouToStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntroductionStaticControl2
        /// </summary>
        StaticControl IntroductionStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DoNotShowThisPageAgainCheckBox
        /// </summary>
        CheckBox DoNotShowThisPageAgainCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToBeginTheConfigurationProcessClickNextStaticControl
        /// </summary>
        StaticControl ToBeginTheConfigurationProcessClickNextStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr
        /// </summary>
        StaticControl ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr
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
        /// Read-only property to access IntroductionStaticControl3
        /// </summary>
        StaticControl IntroductionStaticControl3
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
    /// 	[lucyra] 4/13/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class IntroDialog : Dialog, IIntroDialogControls
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
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CEIPForwardingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCEIPForwardingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ErrorCollectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedErrorCollectionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ErrorForwardingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedErrorForwardingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateFileShareStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreateFileShareStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TaskStatusStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskStatusStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DeploySettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDeploySettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe;
        
        /// <summary>
        /// Cache to hold a reference to ThisWizardWillHelpYouToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThisWizardWillHelpYouToStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to DoNotShowThisPageAgainCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDoNotShowThisPageAgainCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ToBeginTheConfigurationProcessClickNextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToBeginTheConfigurationProcessClickNextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr of type StaticControl
        /// </summary>
        private StaticControl cachedThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntroductionStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl3;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of IntroDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public IntroDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IIntroDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IIntroDialogControls Controls
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
        ///  Property to handle checkbox DoNotShowThisPageAgain
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool DoNotShowThisPageAgain
        {
            get
            {
                return this.Controls.DoNotShowThisPageAgainCheckBox.Checked;
            }
            
            set
            {
                this.Controls.DoNotShowThisPageAgainCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIntroDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, IntroDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIntroDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, IntroDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIntroDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, IntroDialog.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IIntroDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, IntroDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, IntroDialog.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CEIPForwardingStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.CEIPForwardingStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCEIPForwardingStaticControl == null))
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
                    this.cachedCEIPForwardingStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedCEIPForwardingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.ErrorCollectionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedErrorCollectionStaticControl == null))
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
                    this.cachedErrorCollectionStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedErrorCollectionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorForwardingStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.ErrorForwardingStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedErrorForwardingStaticControl == null))
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
                    this.cachedErrorForwardingStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedErrorForwardingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateFileShareStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.CreateFileShareStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCreateFileShareStaticControl == null))
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
                    this.cachedCreateFileShareStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedCreateFileShareStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskStatusStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.TaskStatusStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTaskStatusStaticControl == null))
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
                    this.cachedTaskStatusStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedTaskStatusStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeploySettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.DeploySettingsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDeploySettingsStaticControl == null))
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
                    this.cachedDeploySettingsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedDeploySettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe
        {
            get
            {
                if ((this.cachedConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe == null))
                {
                    this.cachedConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe = new StaticControl(this, IntroDialog.ControlIDs.ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe);
                }
                return this.cachedConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisWizardWillHelpYouToStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.ThisWizardWillHelpYouToStaticControl
        {
            get
            {
                if ((this.cachedThisWizardWillHelpYouToStaticControl == null))
                {
                    this.cachedThisWizardWillHelpYouToStaticControl = new StaticControl(this, IntroDialog.ControlIDs.ThisWizardWillHelpYouToStaticControl);
                }
                return this.cachedThisWizardWillHelpYouToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.IntroductionStaticControl2
        {
            get
            {
                if ((this.cachedIntroductionStaticControl2 == null))
                {
                    this.cachedIntroductionStaticControl2 = new StaticControl(this, IntroDialog.ControlIDs.IntroductionStaticControl2);
                }
                return this.cachedIntroductionStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoNotShowThisPageAgainCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IIntroDialogControls.DoNotShowThisPageAgainCheckBox
        {
            get
            {
                if ((this.cachedDoNotShowThisPageAgainCheckBox == null))
                {
                    this.cachedDoNotShowThisPageAgainCheckBox = new CheckBox(this, IntroDialog.ControlIDs.DoNotShowThisPageAgainCheckBox);
                }
                return this.cachedDoNotShowThisPageAgainCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToBeginTheConfigurationProcessClickNextStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.ToBeginTheConfigurationProcessClickNextStaticControl
        {
            get
            {
                if ((this.cachedToBeginTheConfigurationProcessClickNextStaticControl == null))
                {
                    this.cachedToBeginTheConfigurationProcessClickNextStaticControl = new StaticControl(this, IntroDialog.ControlIDs.ToBeginTheConfigurationProcessClickNextStaticControl);
                }
                return this.cachedToBeginTheConfigurationProcessClickNextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr
        {
            get
            {
                if ((this.cachedThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr == null))
                {
                    this.cachedThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr = new StaticControl(this, IntroDialog.ControlIDs.ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr);
                }
                return this.cachedThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, IntroDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IIntroDialogControls.IntroductionStaticControl3
        {
            get
            {
                if ((this.cachedIntroductionStaticControl3 == null))
                {
                    this.cachedIntroductionStaticControl3 = new StaticControl(this, IntroDialog.ControlIDs.IntroductionStaticControl3);
                }
                return this.cachedIntroductionStaticControl3;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
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
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DoNotShowThisPageAgain
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDoNotShowThisPageAgain()
        {
            this.Controls.DoNotShowThisPageAgainCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 4/13/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
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
                                Strings.DialogTitle + "*",
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
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

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
        /// 	[lucyra] 4/13/2006 Created
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
            private const string ResourceDialogTitle = ";Client Monitoring Configuration Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ClientMonitoringWizardCaption";
            
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
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CEIPForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCEIPForwarding = ";CEIP Forwarding;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_CEIPForwardin" +
                "gNavigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ErrorCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorCollection = ";Error Collection;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.AdminResources;CM_ErrorCollect" +
                "ionNavigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ErrorForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorForwarding = ";Error Forwarding;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.AdminResources;CM_ErrorForward" +
                "ingNavigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateFileShare
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateFileShare = ";Create File Share;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_CreateFileS" +
                "hareNavigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskStatus = ";Task Status;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;TaskStatus" +
                "EditDialogTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DeploySettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDeploySettings = ";Deploy Settings;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_DeployConfigN" +
                "avigationTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe = @";- Configure where errors are sent

- Specify transmission settings

- Configure end-user error crash behavior

- Configure where Customer Experience Improvement Program (CEIP) data is sent
;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CMIntroduction;labelDescription1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThisWizardWillHelpYouTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisWizardWillHelpYouTo = ";This wizard will help you to:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring." +
                "CMIntroduction;labelDescriptionTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction2 = ";Introduction;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoNotShowThisPageAgain = ";Do not &show this page again;ManagedString;Microsoft.MOM.UI.Components.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAs.ProfileIntroducti" +
                "on;checkBoxShow.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToBeginTheConfigurationProcessClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToBeginTheConfigurationProcessClickNext = ";To begin the configuration process, click \"Next\";ManagedString;Microsoft.MOM.UI." +
                "Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administratio" +
                "n.ClientMonitoring.CMIntroduction;labelNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr = @";This wizard will guide you through the process of configuring machines in your organization to report application errors generated by the Watson client to your Management Server.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CMIntroduction;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction3 = ";Introduction;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";
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
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CEIPForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCEIPForwarding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ErrorCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorCollection;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ErrorForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorForwarding;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateFileShare
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateFileShare;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskStatus;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DeploySettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDeploySettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThisWizardWillHelpYouTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisWizardWillHelpYouTo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DoNotShowThisPageAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoNotShowThisPageAgain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToBeginTheConfigurationProcessClickNext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToBeginTheConfigurationProcessClickNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Introduction3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction3;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// 	[lucyra] 4/13/2006 Created
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
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }
                    return cachedFinish;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
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
            /// Exposes access to the Introduction translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction
            {
                get
                {
                    if ((cachedIntroduction == null))
                    {
                        cachedIntroduction = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction);
                    }
                    return cachedIntroduction;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CEIPForwarding translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CEIPForwarding
            {
                get
                {
                    if ((cachedCEIPForwarding == null))
                    {
                        cachedCEIPForwarding = CoreManager.MomConsole.GetIntlStr(ResourceCEIPForwarding);
                    }
                    return cachedCEIPForwarding;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorCollection translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorCollection
            {
                get
                {
                    if ((cachedErrorCollection == null))
                    {
                        cachedErrorCollection = CoreManager.MomConsole.GetIntlStr(ResourceErrorCollection);
                    }
                    return cachedErrorCollection;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorForwarding translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorForwarding
            {
                get
                {
                    if ((cachedErrorForwarding == null))
                    {
                        cachedErrorForwarding = CoreManager.MomConsole.GetIntlStr(ResourceErrorForwarding);
                    }
                    return cachedErrorForwarding;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateFileShare translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateFileShare
            {
                get
                {
                    if ((cachedCreateFileShare == null))
                    {
                        cachedCreateFileShare = CoreManager.MomConsole.GetIntlStr(ResourceCreateFileShare);
                    }
                    return cachedCreateFileShare;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskStatus translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskStatus
            {
                get
                {
                    if ((cachedTaskStatus == null))
                    {
                        cachedTaskStatus = CoreManager.MomConsole.GetIntlStr(ResourceTaskStatus);
                    }
                    return cachedTaskStatus;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DeploySettings translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeploySettings
            {
                get
                {
                    if ((cachedDeploySettings == null))
                    {
                        cachedDeploySettings = CoreManager.MomConsole.GetIntlStr(ResourceDeploySettings);
                    }
                    return cachedDeploySettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe
            {
                get
                {
                    if ((cachedConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe == null))
                    {
                        cachedConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe = CoreManager.MomConsole.GetIntlStr(ResourceConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe);
                    }
                    return cachedConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThisWizardWillHelpYouTo translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisWizardWillHelpYouTo
            {
                get
                {
                    if ((cachedThisWizardWillHelpYouTo == null))
                    {
                        cachedThisWizardWillHelpYouTo = CoreManager.MomConsole.GetIntlStr(ResourceThisWizardWillHelpYouTo);
                    }
                    return cachedThisWizardWillHelpYouTo;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Introduction2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction2
            {
                get
                {
                    if ((cachedIntroduction2 == null))
                    {
                        cachedIntroduction2 = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction2);
                    }
                    return cachedIntroduction2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DoNotShowThisPageAgain translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DoNotShowThisPageAgain
            {
                get
                {
                    if ((cachedDoNotShowThisPageAgain == null))
                    {
                        cachedDoNotShowThisPageAgain = CoreManager.MomConsole.GetIntlStr(ResourceDoNotShowThisPageAgain);
                    }
                    return cachedDoNotShowThisPageAgain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToBeginTheConfigurationProcessClickNext translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToBeginTheConfigurationProcessClickNext
            {
                get
                {
                    if ((cachedToBeginTheConfigurationProcessClickNext == null))
                    {
                        cachedToBeginTheConfigurationProcessClickNext = CoreManager.MomConsole.GetIntlStr(ResourceToBeginTheConfigurationProcessClickNext);
                    }
                    return cachedToBeginTheConfigurationProcessClickNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr
            {
                get
                {
                    if ((cachedThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr == null))
                    {
                        cachedThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr = CoreManager.MomConsole.GetIntlStr(ResourceThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr);
                    }
                    return cachedThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
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
            /// Exposes access to the Introduction3 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/13/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction3
            {
                get
                {
                    if ((cachedIntroduction3 == null))
                    {
                        cachedIntroduction3 = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction3);
                    }
                    return cachedIntroduction3;
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
        /// 	[lucyra] 4/13/2006 Created
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
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl
            /// </summary>
            public const string IntroductionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CEIPForwardingStaticControl
            /// </summary>
            public const string CEIPForwardingStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ErrorCollectionStaticControl
            /// </summary>
            public const string ErrorCollectionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ErrorForwardingStaticControl
            /// </summary>
            public const string ErrorForwardingStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CreateFileShareStaticControl
            /// </summary>
            public const string CreateFileShareStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for TaskStatusStaticControl
            /// </summary>
            public const string TaskStatusStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DeploySettingsStaticControl
            /// </summary>
            public const string DeploySettingsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe
            /// </summary>
            public const string ConfigureWhereErrorsAreSentSpecifyTransmissionSettingsConfigureEndUserErrorCrashBehaviorConfigureWhe = "labelDescription1";
            
            /// <summary>
            /// Control ID for ThisWizardWillHelpYouToStaticControl
            /// </summary>
            public const string ThisWizardWillHelpYouToStaticControl = "labelDescriptionTitle";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl2
            /// </summary>
            public const string IntroductionStaticControl2 = "labelTitle";
            
            /// <summary>
            /// Control ID for DoNotShowThisPageAgainCheckBox
            /// </summary>
            public const string DoNotShowThisPageAgainCheckBox = "checkBoxShow";
            
            /// <summary>
            /// Control ID for ToBeginTheConfigurationProcessClickNextStaticControl
            /// </summary>
            public const string ToBeginTheConfigurationProcessClickNextStaticControl = "labelNext";
            
            /// <summary>
            /// Control ID for ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr
            /// </summary>
            public const string ThisWizardWillGuideYouThroughTheProcessOfConfiguringMachinesInYourOrganizationToReportApplicationErr = "labelTitle1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for IntroductionStaticControl3
            /// </summary>
            public const string IntroductionStaticControl3 = "headerLabel";
        }
        #endregion
    }
}
