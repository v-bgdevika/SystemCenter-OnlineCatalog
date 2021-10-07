// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CEIPDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	AEM Deployment Dialog - 1st screen
// </summary>
// <history>
// 	[lucyra] 4/12/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.AEM.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - RadioGroupTab1

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroupTab1
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroupTab1
    {
        /// <summary>
        /// YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft = 0
        /// </summary>
        YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft = 0,
        
        /// <summary>
        /// NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft = 1
        /// </summary>
        NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft = 1,
    }
    #endregion
    
    #region Interface Definition - ICEIPDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICEIPDialogControls, for CEIPDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICEIPDialogControls
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
        /// Read-only property to access ReadThePrivacyStatementStaticControl
        /// </summary>
        StaticControl ReadThePrivacyStatementStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TellMeMoreAboutTheProgramStaticControl
        /// </summary>
        StaticControl TellMeMoreAboutTheProgramStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        /// </summary>
        StaticControl UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PortTextBox
        /// </summary>
        TextBox PortTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PortStaticControl
        /// </summary>
        StaticControl PortStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl
        /// </summary>
        StaticControl NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseSecureSocketsLayerSSLProtocolCheckBox
        /// </summary>
        CheckBox UseSecureSocketsLayerSSLProtocolCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton
        /// </summary>
        RadioButton YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton
        /// </summary>
        RadioButton NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DoYouWantToHelpMicrosoftImproveItsProductsStaticControl
        /// </summary>
        StaticControl DoYouWantToHelpMicrosoftImproveItsProductsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis
        /// </summary>
        StaticControl ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis
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
        /// Read-only property to access CustomerExperienceImprovementProgramStaticControl
        /// </summary>
        StaticControl CustomerExperienceImprovementProgramStaticControl
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
    /// 	[lucyra] 4/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CEIPDialog : Dialog, ICEIPDialogControls
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
        /// Cache to hold a reference to ReadThePrivacyStatementStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedReadThePrivacyStatementStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TellMeMoreAboutTheProgramStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTellMeMoreAboutTheProgramStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn of type StaticControl
        /// </summary>
        private StaticControl cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn;
        
        /// <summary>
        /// Cache to hold a reference to PortTextBox of type TextBox
        /// </summary>
        private TextBox cachedPortTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PortStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPortStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseSecureSocketsLayerSSLProtocolCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUseSecureSocketsLayerSSLProtocolCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DoYouWantToHelpMicrosoftImproveItsProductsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDoYouWantToHelpMicrosoftImproveItsProductsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis of type StaticControl
        /// </summary>
        private StaticControl cachedManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomerExperienceImprovementProgramStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomerExperienceImprovementProgramStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CEIPDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CEIPDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroupTab1
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroupTab1 RadioGroupTab1
        {
            get
            {
                if ((this.Controls.YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTab1.YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft;
                }
                
                if ((this.Controls.NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTab1.NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroupTab1.YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft))
                {
                    this.Controls.YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroupTab1.NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft))
                    {
                        this.Controls.NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICEIPDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICEIPDialogControls Controls
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
        ///  Property to handle checkbox UseSecureSocketsLayerSSLProtocol
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UseSecureSocketsLayerSSLProtocol
        {
            get
            {
                return this.Controls.UseSecureSocketsLayerSSLProtocolCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UseSecureSocketsLayerSSLProtocolCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Port
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PortText
        {
            get
            {
                return this.Controls.PortTextBox.Text;
            }
            
            set
            {
                this.Controls.PortTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICEIPDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CEIPDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICEIPDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CEIPDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICEIPDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CEIPDialog.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICEIPDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CEIPDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CEIPForwardingStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.CEIPForwardingStaticControl
        {
            get
            {
                if ((this.cachedCEIPForwardingStaticControl == null))
                {
                    this.cachedCEIPForwardingStaticControl = new StaticControl(this, CEIPDialog.ControlIDs.CEIPForwardingStaticControl);
                }
                return this.cachedCEIPForwardingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.ErrorCollectionStaticControl
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
                    wndTemp = wndTemp.Extended.NextSibling;
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
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.ErrorForwardingStaticControl
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
                    for (i = 0; (i <= 1); i = (i + 1))
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
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.CreateFileShareStaticControl
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
                    for (i = 0; (i <= 2); i = (i + 1))
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
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.TaskStatusStaticControl
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
                    for (i = 0; (i <= 3); i = (i + 1))
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
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.DeploySettingsStaticControl
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
                    for (i = 0; (i <= 4); i = (i + 1))
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
        ///  Exposes access to the ReadThePrivacyStatementStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.ReadThePrivacyStatementStaticControl
        {
            get
            {
                if ((this.cachedReadThePrivacyStatementStaticControl == null))
                {
                    this.cachedReadThePrivacyStatementStaticControl = new StaticControl(this, CEIPDialog.ControlIDs.ReadThePrivacyStatementStaticControl);
                }
                return this.cachedReadThePrivacyStatementStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TellMeMoreAboutTheProgramStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.TellMeMoreAboutTheProgramStaticControl
        {
            get
            {
                if ((this.cachedTellMeMoreAboutTheProgramStaticControl == null))
                {
                    this.cachedTellMeMoreAboutTheProgramStaticControl = new StaticControl(this, CEIPDialog.ControlIDs.TellMeMoreAboutTheProgramStaticControl);
                }
                return this.cachedTellMeMoreAboutTheProgramStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        {
            get
            {
                if ((this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn == null))
                {
                    this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn = new StaticControl(this, CEIPDialog.ControlIDs.UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn);
                }
                return this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PortTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICEIPDialogControls.PortTextBox
        {
            get
            {
                if ((this.cachedPortTextBox == null))
                {
                    this.cachedPortTextBox = new TextBox(this, CEIPDialog.ControlIDs.PortTextBox);
                }
                return this.cachedPortTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PortStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.PortStaticControl
        {
            get
            {
                if ((this.cachedPortStaticControl == null))
                {
                    this.cachedPortStaticControl = new StaticControl(this, CEIPDialog.ControlIDs.PortStaticControl);
                }
                return this.cachedPortStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl
        {
            get
            {
                if ((this.cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl == null))
                {
                    this.cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl = new StaticControl(this, CEIPDialog.ControlIDs.NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl);
                }
                return this.cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseSecureSocketsLayerSSLProtocolCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ICEIPDialogControls.UseSecureSocketsLayerSSLProtocolCheckBox
        {
            get
            {
                if ((this.cachedUseSecureSocketsLayerSSLProtocolCheckBox == null))
                {
                    this.cachedUseSecureSocketsLayerSSLProtocolCheckBox = new CheckBox(this, CEIPDialog.ControlIDs.UseSecureSocketsLayerSSLProtocolCheckBox);
                }
                return this.cachedUseSecureSocketsLayerSSLProtocolCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICEIPDialogControls.YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton
        {
            get
            {
                if ((this.cachedYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton == null))
                {
                    this.cachedYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton = new RadioButton(this, CEIPDialog.ControlIDs.YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton);
                }
                return this.cachedYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICEIPDialogControls.NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton
        {
            get
            {
                if ((this.cachedNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton == null))
                {
                    this.cachedNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton = new RadioButton(this, CEIPDialog.ControlIDs.NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton);
                }
                return this.cachedNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoYouWantToHelpMicrosoftImproveItsProductsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.DoYouWantToHelpMicrosoftImproveItsProductsStaticControl
        {
            get
            {
                if ((this.cachedDoYouWantToHelpMicrosoftImproveItsProductsStaticControl == null))
                {
                    this.cachedDoYouWantToHelpMicrosoftImproveItsProductsStaticControl = new StaticControl(this, CEIPDialog.ControlIDs.DoYouWantToHelpMicrosoftImproveItsProductsStaticControl);
                }
                return this.cachedDoYouWantToHelpMicrosoftImproveItsProductsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis
        {
            get
            {
                if ((this.cachedManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis == null))
                {
                    this.cachedManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis = new StaticControl(this, CEIPDialog.ControlIDs.ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis);
                }
                return this.cachedManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CEIPDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomerExperienceImprovementProgramStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICEIPDialogControls.CustomerExperienceImprovementProgramStaticControl
        {
            get
            {
                if ((this.cachedCustomerExperienceImprovementProgramStaticControl == null))
                {
                    this.cachedCustomerExperienceImprovementProgramStaticControl = new StaticControl(this, CEIPDialog.ControlIDs.CustomerExperienceImprovementProgramStaticControl);
                }
                return this.cachedCustomerExperienceImprovementProgramStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
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
        /// 	[lucyra] 4/12/2006 Created
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
        /// 	[lucyra] 4/12/2006 Created
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
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UseSecureSocketsLayerSSLProtocol
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUseSecureSocketsLayerSSLProtocol()
        {
            this.Controls.UseSecureSocketsLayerSSLProtocolCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
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
        /// 	[lucyra] 4/12/2006 Created
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
            /// Contains resource string for:  ReadThePrivacyStatement
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceReadThePrivacyStatement = ";Read the privacy statement;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CEI" +
                "PForwarding;linkLabelPrivacy.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TellMeMoreAboutTheProgram
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTellMeMoreAboutTheProgram = ";Tell me more about the program.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitorin" +
                "g.CEIPForwarding;linkLabelProgramInfo.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn = "Users in your organization may already be participating in CEIP. You can use a Ma" +
                "nagement Server to centrally collect and forward their CEIP data to Microsoft. I" +
                "f you choose to centrally collect the data, you will need to deploy an Administr" +
                "ative Template";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Port
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePort = ";Port:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Internal.UI.Authoring.Pages.HttpUrlConnectionPage;labelPort.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer = @";Note: If you select the SSL option, a certificate needs to be installed on the Management Server.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CEIPForwarding;labelSslInfo.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseSecureSocketsLayerSSLProtocol
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseSecureSocketsLayerSSLProtocol = ";Use Secure Sockets Layer (SSL) protocol;ManagedString;Microsoft.MOM.UI.Console.e" +
                "xe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientM" +
                "onitoring.CEIPForwarding;checkBoxUseSsl.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft = @";Yes, use this Management Server to centrally collect and forward CEIP data to Microsoft.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CEIPForwarding;radioButtonYesSqm.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft = @";No, if the computers in my environment are collecting CEIP data, send it directly to Microsoft.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CEIPForwarding;radioButtonNoSqm.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoYouWantToHelpMicrosoftImproveItsProducts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoYouWantToHelpMicrosoftImproveItsProducts = ";Do you want to help Microsoft improve its products?;ManagedString;Microsoft.MOM." +
                "UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administra" +
                "tion.ClientMonitoring.CEIPForwarding;labelTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis = @";Many Microsoft applications allow users to opt in to the Microsoft Customer Experience Improvement Program (CEIP). This program collects data about how Microsoft applications are used to help Microsoft identify which features to improve. ;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CEIPForwarding;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomerExperienceImprovementProgram
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomerExperienceImprovementProgram = ";Customer Experience Improvement Program;ManagedString;Microsoft.MOM.UI.Console.e" +
                "xe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminRe" +
                "sources;CM_CEIPForwardingTitle";
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
            /// Caches the translated resource string for:  ReadThePrivacyStatement
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReadThePrivacyStatement;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TellMeMoreAboutTheProgram
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTellMeMoreAboutTheProgram;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Port
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPort;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseSecureSocketsLayerSSLProtocol
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseSecureSocketsLayerSSLProtocol;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DoYouWantToHelpMicrosoftImproveItsProducts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoYouWantToHelpMicrosoftImproveItsProducts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomerExperienceImprovementProgram
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomerExperienceImprovementProgram;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// Exposes access to the CEIPForwarding translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// 	[lucyra] 4/12/2006 Created
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
            /// Exposes access to the ReadThePrivacyStatement translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReadThePrivacyStatement
            {
                get
                {
                    if ((cachedReadThePrivacyStatement == null))
                    {
                        cachedReadThePrivacyStatement = CoreManager.MomConsole.GetIntlStr(ResourceReadThePrivacyStatement);
                    }
                    return cachedReadThePrivacyStatement;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TellMeMoreAboutTheProgram translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TellMeMoreAboutTheProgram
            {
                get
                {
                    if ((cachedTellMeMoreAboutTheProgram == null))
                    {
                        cachedTellMeMoreAboutTheProgram = CoreManager.MomConsole.GetIntlStr(ResourceTellMeMoreAboutTheProgram);
                    }
                    return cachedTellMeMoreAboutTheProgram;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
            {
                get
                {
                    if ((cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn == null))
                    {
                        cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn = CoreManager.MomConsole.GetIntlStr(ResourceUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn);
                    }
                    return cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Port translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Port
            {
                get
                {
                    if ((cachedPort == null))
                    {
                        cachedPort = CoreManager.MomConsole.GetIntlStr(ResourcePort);
                    }
                    return cachedPort;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer
            {
                get
                {
                    if ((cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer == null))
                    {
                        cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer = CoreManager.MomConsole.GetIntlStr(ResourceNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer);
                    }
                    return cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseSecureSocketsLayerSSLProtocol translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseSecureSocketsLayerSSLProtocol
            {
                get
                {
                    if ((cachedUseSecureSocketsLayerSSLProtocol == null))
                    {
                        cachedUseSecureSocketsLayerSSLProtocol = CoreManager.MomConsole.GetIntlStr(ResourceUseSecureSocketsLayerSSLProtocol);
                    }
                    return cachedUseSecureSocketsLayerSSLProtocol;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft
            {
                get
                {
                    if ((cachedYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft == null))
                    {
                        cachedYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft = CoreManager.MomConsole.GetIntlStr(ResourceYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft);
                    }
                    return cachedYesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoft;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft
            {
                get
                {
                    if ((cachedNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft == null))
                    {
                        cachedNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft = CoreManager.MomConsole.GetIntlStr(ResourceNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft);
                    }
                    return cachedNoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoft;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DoYouWantToHelpMicrosoftImproveItsProducts translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DoYouWantToHelpMicrosoftImproveItsProducts
            {
                get
                {
                    if ((cachedDoYouWantToHelpMicrosoftImproveItsProducts == null))
                    {
                        cachedDoYouWantToHelpMicrosoftImproveItsProducts = CoreManager.MomConsole.GetIntlStr(ResourceDoYouWantToHelpMicrosoftImproveItsProducts);
                    }
                    return cachedDoYouWantToHelpMicrosoftImproveItsProducts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis
            {
                get
                {
                    if ((cachedManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis == null))
                    {
                        cachedManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis = CoreManager.MomConsole.GetIntlStr(ResourceManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis);
                    }
                    return cachedManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
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
            /// Exposes access to the CustomerExperienceImprovementProgram translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomerExperienceImprovementProgram
            {
                get
                {
                    if ((cachedCustomerExperienceImprovementProgram == null))
                    {
                        cachedCustomerExperienceImprovementProgram = CoreManager.MomConsole.GetIntlStr(ResourceCustomerExperienceImprovementProgram);
                    }
                    return cachedCustomerExperienceImprovementProgram;
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
        /// 	[lucyra] 4/12/2006 Created
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
            /// Control ID for ReadThePrivacyStatementStaticControl
            /// </summary>
            public const string ReadThePrivacyStatementStaticControl = "linkLabelPrivacy";
            
            /// <summary>
            /// Control ID for TellMeMoreAboutTheProgramStaticControl
            /// </summary>
            public const string TellMeMoreAboutTheProgramStaticControl = "linkLabelProgramInfo";
            
            /// <summary>
            /// Control ID for UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
            /// </summary>
            public const string UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn = "labelTitle2";
            
            /// <summary>
            /// Control ID for PortTextBox
            /// </summary>
            public const string PortTextBox = "textBoxPort";
            
            /// <summary>
            /// Control ID for PortStaticControl
            /// </summary>
            public const string PortStaticControl = "labelPort";
            
            /// <summary>
            /// Control ID for NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl
            /// </summary>
            public const string NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl = "labelSslInfo";
            
            /// <summary>
            /// Control ID for UseSecureSocketsLayerSSLProtocolCheckBox
            /// </summary>
            public const string UseSecureSocketsLayerSSLProtocolCheckBox = "checkBoxUseSsl";
            
            /// <summary>
            /// Control ID for YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton
            /// </summary>
            public const string YesUseThisManagementServerToCentrallyCollectAndForwardCEIPDataToMicrosoftRadioButton = "radioButtonYesSqm";
            
            /// <summary>
            /// Control ID for NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton
            /// </summary>
            public const string NoIfTheComputersInMyEnvironmentAreCollectingCEIPDataSendItDirectlyToMicrosoftRadioButton = "radioButtonNoSqm";
            
            /// <summary>
            /// Control ID for DoYouWantToHelpMicrosoftImproveItsProductsStaticControl
            /// </summary>
            public const string DoYouWantToHelpMicrosoftImproveItsProductsStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis
            /// </summary>
            public const string ManyMicrosoftApplicationsAllowUsersToOptInToTheMicrosoftCustomerExperienceImprovementProgramCEIPThis = "labelTitle1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for CustomerExperienceImprovementProgramStaticControl
            /// </summary>
            public const string CustomerExperienceImprovementProgramStaticControl = "headerLabel";
        }
        #endregion
    }
}
