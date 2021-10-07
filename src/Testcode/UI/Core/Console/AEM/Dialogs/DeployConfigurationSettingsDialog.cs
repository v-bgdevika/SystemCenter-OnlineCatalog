// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DeployConfigurationSettingsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	AEM Deployment Dialog - 5th screen
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
    
    #region Interface Definition - IDeployConfigurationSettingsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDeployConfigurationSettingsDialogControls, for DeployConfigurationSettingsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDeployConfigurationSettingsDialogControls
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
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        /// </summary>
        TextBox UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl
        /// </summary>
        StaticControl ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClickFinishToConfigureClientMonitoringStaticControl
        /// </summary>
        StaticControl ClickFinishToConfigureClientMonitoringStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RedirectComputersToTheManagementServerStaticControl
        /// </summary>
        StaticControl RedirectComputersToTheManagementServerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo
        /// </summary>
        StaticControl AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo
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
        /// Read-only property to access DeployConfigurationSettingsStaticControl
        /// </summary>
        StaticControl DeployConfigurationSettingsStaticControl
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
    public class DeployConfigurationSettingsDialog : Dialog, IDeployConfigurationSettingsDialogControls
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
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn of type TextBox
        /// </summary>
        private TextBox cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn;
        
        /// <summary>
        /// Cache to hold a reference to ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClickFinishToConfigureClientMonitoringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedClickFinishToConfigureClientMonitoringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RedirectComputersToTheManagementServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRedirectComputersToTheManagementServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo of type StaticControl
        /// </summary>
        private StaticControl cachedAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DeployConfigurationSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDeployConfigurationSettingsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DeployConfigurationSettingsDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DeployConfigurationSettingsDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IDeployConfigurationSettingsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDeployConfigurationSettingsDialogControls Controls
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
        ///  Routine to set/get the text in control UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAnText
        {
            get
            {
                return this.Controls.UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn.Text;
            }
            
            set
            {
                this.Controls.UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn.Text = value;
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
        Button IDeployConfigurationSettingsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DeployConfigurationSettingsDialog.ControlIDs.PreviousButton);
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
        Button IDeployConfigurationSettingsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DeployConfigurationSettingsDialog.ControlIDs.NextButton);
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
        Button IDeployConfigurationSettingsDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, DeployConfigurationSettingsDialog.ControlIDs.FinishButton);
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
        Button IDeployConfigurationSettingsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DeployConfigurationSettingsDialog.ControlIDs.CancelButton);
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
        StaticControl IDeployConfigurationSettingsDialogControls.CEIPForwardingStaticControl
        {
            get
            {
                if ((this.cachedCEIPForwardingStaticControl == null))
                {
                    this.cachedCEIPForwardingStaticControl = new StaticControl(this, DeployConfigurationSettingsDialog.ControlIDs.CEIPForwardingStaticControl);
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
        StaticControl IDeployConfigurationSettingsDialogControls.ErrorCollectionStaticControl
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
        StaticControl IDeployConfigurationSettingsDialogControls.ErrorForwardingStaticControl
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
        StaticControl IDeployConfigurationSettingsDialogControls.CreateFileShareStaticControl
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
        StaticControl IDeployConfigurationSettingsDialogControls.TaskStatusStaticControl
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
        StaticControl IDeployConfigurationSettingsDialogControls.DeploySettingsStaticControl
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
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDeployConfigurationSettingsDialogControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, DeployConfigurationSettingsDialog.ControlIDs.BrowseButton);
                }
                return this.cachedBrowseButton;
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
        TextBox IDeployConfigurationSettingsDialogControls.UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        {
            get
            {
                if ((this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn == null))
                {
                    this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn = new TextBox(this, DeployConfigurationSettingsDialog.ControlIDs.UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn);
                }
                return this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDeployConfigurationSettingsDialogControls.ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl
        {
            get
            {
                if ((this.cachedChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl == null))
                {
                    this.cachedChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl = new StaticControl(this, DeployConfigurationSettingsDialog.ControlIDs.ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl);
                }
                return this.cachedChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClickFinishToConfigureClientMonitoringStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDeployConfigurationSettingsDialogControls.ClickFinishToConfigureClientMonitoringStaticControl
        {
            get
            {
                if ((this.cachedClickFinishToConfigureClientMonitoringStaticControl == null))
                {
                    this.cachedClickFinishToConfigureClientMonitoringStaticControl = new StaticControl(this, DeployConfigurationSettingsDialog.ControlIDs.ClickFinishToConfigureClientMonitoringStaticControl);
                }
                return this.cachedClickFinishToConfigureClientMonitoringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RedirectComputersToTheManagementServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDeployConfigurationSettingsDialogControls.RedirectComputersToTheManagementServerStaticControl
        {
            get
            {
                if ((this.cachedRedirectComputersToTheManagementServerStaticControl == null))
                {
                    this.cachedRedirectComputersToTheManagementServerStaticControl = new StaticControl(this, DeployConfigurationSettingsDialog.ControlIDs.RedirectComputersToTheManagementServerStaticControl);
                }
                return this.cachedRedirectComputersToTheManagementServerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDeployConfigurationSettingsDialogControls.AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo
        {
            get
            {
                if ((this.cachedAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo == null))
                {
                    this.cachedAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo = new StaticControl(this, DeployConfigurationSettingsDialog.ControlIDs.AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo);
                }
                return this.cachedAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo;
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
        StaticControl IDeployConfigurationSettingsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DeployConfigurationSettingsDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeployConfigurationSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDeployConfigurationSettingsDialogControls.DeployConfigurationSettingsStaticControl
        {
            get
            {
                if ((this.cachedDeployConfigurationSettingsStaticControl == null))
                {
                    this.cachedDeployConfigurationSettingsStaticControl = new StaticControl(this, DeployConfigurationSettingsDialog.ControlIDs.DeployConfigurationSettingsStaticControl);
                }
                return this.cachedDeployConfigurationSettingsStaticControl;
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
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();
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
            /// Contains resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowse = ";Browse...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.PerfCounterDataSource;browseButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile = ";Choose a location where you want to save the Administrative Template file:;Manag" +
                "edString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Interna" +
                "l.UI.Console.Administration.ClientMonitoring.DeployConfig;labelAdmLocation.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClickFinishToConfigureClientMonitoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClickFinishToConfigureClientMonitoring = ";Click Finish to configure client monitoring.;ManagedString;Microsoft.MOM.UI.Cons" +
                "ole.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Cl" +
                "ientMonitoring.DeployConfig;labelPrivacy.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RedirectComputersToTheManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRedirectComputersToTheManagementServer = ";Redirect computers to the Management Server;ManagedString;Microsoft.MOM.UI.Conso" +
                "le.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Cli" +
                "entMonitoring.DeployConfig;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo = "All of the configuration options you have made will be saved into an Administrati" +
                "ve Template (.adm) file at the location you specify. To make the computers in yo" +
                "ur organization use these configuration settings, you will need to deploy this A" +
                "dministrative ";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DeployConfigurationSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDeployConfigurationSettings = ";Deploy Configuration Settings;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;CM" +
                "_DeployConfigTitle";
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
            /// Caches the translated resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowse;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ClickFinishToConfigureClientMonitoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClickFinishToConfigureClientMonitoring;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RedirectComputersToTheManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRedirectComputersToTheManagementServer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DeployConfigurationSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDeployConfigurationSettings;
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
            /// Exposes access to the Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Browse
            {
                get
                {
                    if ((cachedBrowse == null))
                    {
                        cachedBrowse = CoreManager.MomConsole.GetIntlStr(ResourceBrowse);
                    }
                    return cachedBrowse;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile
            {
                get
                {
                    if ((cachedChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile == null))
                    {
                        cachedChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile = CoreManager.MomConsole.GetIntlStr(ResourceChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile);
                    }
                    return cachedChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFile;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClickFinishToConfigureClientMonitoring translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClickFinishToConfigureClientMonitoring
            {
                get
                {
                    if ((cachedClickFinishToConfigureClientMonitoring == null))
                    {
                        cachedClickFinishToConfigureClientMonitoring = CoreManager.MomConsole.GetIntlStr(ResourceClickFinishToConfigureClientMonitoring);
                    }
                    return cachedClickFinishToConfigureClientMonitoring;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RedirectComputersToTheManagementServer translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RedirectComputersToTheManagementServer
            {
                get
                {
                    if ((cachedRedirectComputersToTheManagementServer == null))
                    {
                        cachedRedirectComputersToTheManagementServer = CoreManager.MomConsole.GetIntlStr(ResourceRedirectComputersToTheManagementServer);
                    }
                    return cachedRedirectComputersToTheManagementServer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo
            {
                get
                {
                    if ((cachedAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo == null))
                    {
                        cachedAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo = CoreManager.MomConsole.GetIntlStr(ResourceAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo);
                    }
                    return cachedAllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo;
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
            /// Exposes access to the DeployConfigurationSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeployConfigurationSettings
            {
                get
                {
                    if ((cachedDeployConfigurationSettings == null))
                    {
                        cachedDeployConfigurationSettings = CoreManager.MomConsole.GetIntlStr(ResourceDeployConfigurationSettings);
                    }
                    return cachedDeployConfigurationSettings;
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
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "buttonBrowse";
            
            /// <summary>
            /// Control ID for UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
            /// </summary>
            public const string UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn = "textBoxAdmLocation";
            
            /// <summary>
            /// Control ID for ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl
            /// </summary>
            public const string ChooseALocationWhereYouWantToSaveTheAdministrativeTemplateFileStaticControl = "labelAdmLocation";
            
            /// <summary>
            /// Control ID for ClickFinishToConfigureClientMonitoringStaticControl
            /// </summary>
            public const string ClickFinishToConfigureClientMonitoringStaticControl = "labelPrivacy";
            
            /// <summary>
            /// Control ID for RedirectComputersToTheManagementServerStaticControl
            /// </summary>
            public const string RedirectComputersToTheManagementServerStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo
            /// </summary>
            public const string AllOfTheConfigurationOptionsYouHaveMadeWillBeSavedIntoAnAdministrativeTemplateAdmFileAtTheLocationYo = "labelSubTitle1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for DeployConfigurationSettingsStaticControl
            /// </summary>
            public const string DeployConfigurationSettingsStaticControl = "headerLabel";
        }
        #endregion
    }
}
