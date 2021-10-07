// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfigureErrorCollectionDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	AEM Deployment Dialog - 2nd screen
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

    #region Interface Definition - IConfigureErrorCollectionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfigureErrorCollectionDialogControls, for ConfigureErrorCollectionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfigureErrorCollectionDialogControls
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
        /// Read-only property to access ReadThePrivacyStatementTextBox
        /// </summary>
        TextBox ReadThePrivacyStatementTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OrganizationNameStaticControl
        /// </summary>
        StaticControl OrganizationNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OrganizationalNameToUseStaticControl
        /// </summary>
        StaticControl OrganizationalNameToUseStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc
        /// </summary>
        StaticControl YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc
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
        /// Read-only property to access UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        /// </summary>
        TextBox UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
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
        /// Read-only property to access SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl
        /// </summary>
        StaticControl SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox
        /// </summary>
        CheckBox CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl
        /// </summary>
        StaticControl NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DeploySettingsTextBox
        /// </summary>
        TextBox DeploySettingsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FileSharePathExampleCErrorDataStaticControl
        /// </summary>
        StaticControl FileSharePathExampleCErrorDataStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyErrorCollectionSettingsStaticControl
        /// </summary>
        StaticControl SpecifyErrorCollectionSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon
        /// </summary>
        StaticControl SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon
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
        /// Read-only property to access ConfigureErrorCollectionStaticControl
        /// </summary>
        StaticControl ConfigureErrorCollectionStaticControl
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
    public class ConfigureErrorCollectionDialog : Dialog, IConfigureErrorCollectionDialogControls
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
        /// Cache to hold a reference to ReadThePrivacyStatementTextBox of type TextBox
        /// </summary>
        private TextBox cachedReadThePrivacyStatementTextBox;
        
        /// <summary>
        /// Cache to hold a reference to OrganizationNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOrganizationNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OrganizationalNameToUseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOrganizationalNameToUseStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc;
        
        /// <summary>
        /// Cache to hold a reference to NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseSecureSocketsLayerSSLProtocolCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUseSecureSocketsLayerSSLProtocolCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn of type TextBox
        /// </summary>
        private TextBox cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn;
        
        /// <summary>
        /// Cache to hold a reference to PortStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPortStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedCollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DeploySettingsTextBox of type TextBox
        /// </summary>
        private TextBox cachedDeploySettingsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to FileSharePathExampleCErrorDataStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFileSharePathExampleCErrorDataStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyErrorCollectionSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyErrorCollectionSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureErrorCollectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureErrorCollectionStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfigureErrorCollectionDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfigureErrorCollectionDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IConfigureErrorCollectionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfigureErrorCollectionDialogControls Controls
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox CollectApplicationErrorsFromWindowsVistaOrLaterComputers
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool CollectApplicationErrorsFromWindowsVistaOrLaterComputers
        {
            get
            {
                return this.Controls.CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox.Checked;
            }
            
            set
            {
                this.Controls.CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ReadThePrivacyStatement
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ReadThePrivacyStatementText
        {
            get
            {
                return this.Controls.ReadThePrivacyStatementTextBox.Text;
            }
            
            set
            {
                this.Controls.ReadThePrivacyStatementTextBox.Text = value;
            }
        }
        
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DeploySettings
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DeploySettingsText
        {
            get
            {
                return this.Controls.DeploySettingsTextBox.Text;
            }
            
            set
            {
                this.Controls.DeploySettingsTextBox.Text = value;
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
        Button IConfigureErrorCollectionDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ConfigureErrorCollectionDialog.ControlIDs.PreviousButton);
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
        Button IConfigureErrorCollectionDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ConfigureErrorCollectionDialog.ControlIDs.NextButton);
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
        Button IConfigureErrorCollectionDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ConfigureErrorCollectionDialog.ControlIDs.FinishButton);
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
        Button IConfigureErrorCollectionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConfigureErrorCollectionDialog.ControlIDs.CancelButton);
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
        StaticControl IConfigureErrorCollectionDialogControls.CEIPForwardingStaticControl
        {
            get
            {
                if ((this.cachedCEIPForwardingStaticControl == null))
                {
                    this.cachedCEIPForwardingStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.CEIPForwardingStaticControl);
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
        StaticControl IConfigureErrorCollectionDialogControls.ErrorCollectionStaticControl
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
        StaticControl IConfigureErrorCollectionDialogControls.ErrorForwardingStaticControl
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
        StaticControl IConfigureErrorCollectionDialogControls.CreateFileShareStaticControl
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
        StaticControl IConfigureErrorCollectionDialogControls.TaskStatusStaticControl
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
        StaticControl IConfigureErrorCollectionDialogControls.DeploySettingsStaticControl
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
        ///  Exposes access to the ReadThePrivacyStatementTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConfigureErrorCollectionDialogControls.ReadThePrivacyStatementTextBox
        {
            get
            {
                if ((this.cachedReadThePrivacyStatementTextBox == null))
                {
                    this.cachedReadThePrivacyStatementTextBox = new TextBox(this, ConfigureErrorCollectionDialog.ControlIDs.ReadThePrivacyStatementTextBox);
                }
                return this.cachedReadThePrivacyStatementTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OrganizationNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.OrganizationNameStaticControl
        {
            get
            {
                if ((this.cachedOrganizationNameStaticControl == null))
                {
                    this.cachedOrganizationNameStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.OrganizationNameStaticControl);
                }
                return this.cachedOrganizationNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OrganizationalNameToUseStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.OrganizationalNameToUseStaticControl
        {
            get
            {
                if ((this.cachedOrganizationalNameToUseStaticControl == null))
                {
                    this.cachedOrganizationalNameToUseStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.OrganizationalNameToUseStaticControl);
                }
                return this.cachedOrganizationalNameToUseStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc
        {
            get
            {
                if ((this.cachedYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc == null))
                {
                    this.cachedYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc);
                }
                return this.cachedYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc;
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
        StaticControl IConfigureErrorCollectionDialogControls.NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl
        {
            get
            {
                if ((this.cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl == null))
                {
                    this.cachedNoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl);
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
        CheckBox IConfigureErrorCollectionDialogControls.UseSecureSocketsLayerSSLProtocolCheckBox
        {
            get
            {
                if ((this.cachedUseSecureSocketsLayerSSLProtocolCheckBox == null))
                {
                    this.cachedUseSecureSocketsLayerSSLProtocolCheckBox = new CheckBox(this, ConfigureErrorCollectionDialog.ControlIDs.UseSecureSocketsLayerSSLProtocolCheckBox);
                }
                return this.cachedUseSecureSocketsLayerSSLProtocolCheckBox;
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
        TextBox IConfigureErrorCollectionDialogControls.UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
        {
            get
            {
                if ((this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn == null))
                {
                    this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn = new TextBox(this, ConfigureErrorCollectionDialog.ControlIDs.UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn);
                }
                return this.cachedUsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn;
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
        StaticControl IConfigureErrorCollectionDialogControls.PortStaticControl
        {
            get
            {
                if ((this.cachedPortStaticControl == null))
                {
                    this.cachedPortStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.PortStaticControl);
                }
                return this.cachedPortStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl == null))
                {
                    this.cachedSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl);
                }
                return this.cachedSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IConfigureErrorCollectionDialogControls.CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox
        {
            get
            {
                if ((this.cachedCollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox == null))
                {
                    this.cachedCollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox = new CheckBox(this, ConfigureErrorCollectionDialog.ControlIDs.CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox);
                }
                return this.cachedCollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl
        {
            get
            {
                if ((this.cachedNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl == null))
                {
                    this.cachedNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl);
                }
                return this.cachedNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeploySettingsTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConfigureErrorCollectionDialogControls.DeploySettingsTextBox
        {
            get
            {
                if ((this.cachedDeploySettingsTextBox == null))
                {
                    this.cachedDeploySettingsTextBox = new TextBox(this, ConfigureErrorCollectionDialog.ControlIDs.DeploySettingsTextBox);
                }
                return this.cachedDeploySettingsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FileSharePathExampleCErrorDataStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.FileSharePathExampleCErrorDataStaticControl
        {
            get
            {
                if ((this.cachedFileSharePathExampleCErrorDataStaticControl == null))
                {
                    this.cachedFileSharePathExampleCErrorDataStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.FileSharePathExampleCErrorDataStaticControl);
                }
                return this.cachedFileSharePathExampleCErrorDataStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyErrorCollectionSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.SpecifyErrorCollectionSettingsStaticControl
        {
            get
            {
                if ((this.cachedSpecifyErrorCollectionSettingsStaticControl == null))
                {
                    this.cachedSpecifyErrorCollectionSettingsStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.SpecifyErrorCollectionSettingsStaticControl);
                }
                return this.cachedSpecifyErrorCollectionSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon
        {
            get
            {
                if ((this.cachedSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon == null))
                {
                    this.cachedSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon);
                }
                return this.cachedSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon;
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
        StaticControl IConfigureErrorCollectionDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureErrorCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorCollectionDialogControls.ConfigureErrorCollectionStaticControl
        {
            get
            {
                if ((this.cachedConfigureErrorCollectionStaticControl == null))
                {
                    this.cachedConfigureErrorCollectionStaticControl = new StaticControl(this, ConfigureErrorCollectionDialog.ControlIDs.ConfigureErrorCollectionStaticControl);
                }
                return this.cachedConfigureErrorCollectionStaticControl;
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CollectApplicationErrorsFromWindowsVistaOrLaterComputers
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCollectApplicationErrorsFromWindowsVistaOrLaterComputers()
        {
            this.Controls.CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox.Click();
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
            /// Contains resource string for:  OrganizationName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrganizationName = ";Organization name:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.ErrorCollec" +
                "tion;labelCompanyName.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OrganizationalNameToUse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrganizationalNameToUse = ";Organizational Name to Use;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.Err" +
                "orCollection;labelTitle2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc = @";You can specify a name to use in place of 'Microsoft' when an error occurs. Users will then know that errors are being sent locally in your organization.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.ErrorCollection;labelSubTitle2.Text";
            
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
            /// Contains resource string for:  Port
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePort = ";Port:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Internal.UI.Authoring.Pages.HttpUrlConnectionPage;labelPort.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors = ";Specify the Management Server port number to use when clients submit errors.;Man" +
                "agedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Inter" +
                "nal.UI.Console.Administration.ClientMonitoring.ErrorCollection;labelPortDesc.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CollectApplicationErrorsFromWindowsVistaOrLaterComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCollectApplicationErrorsFromWindowsVistaOrLaterComputers = ";Collect application errors from Windows Vista or later computers;ManagedString;M" +
                "icrosoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Conso" +
                "le.Administration.ClientMonitoring.ErrorCollection;checkBoxVistaAndLater.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace = @";Note: the file share path must be on a NTFS partition with at least 2GB of free space.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.ErrorCollection;labelFileSharePathDesc.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FileSharePathExampleCErrorData
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFileSharePathExampleCErrorData = ";File Share Path (Example: C:\\ErrorData):;ManagedString;Microsoft.MOM.UI.Console." +
                "exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Client" +
                "Monitoring.ErrorCollection;labelFileSharePath.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyErrorCollectionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyErrorCollectionSettings = ";Specify error collection settings;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitor" +
                "ing.ErrorCollection;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports = @";Specify a local directory on the Management Server which will be used as a file share to collect error reports:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.ErrorCollection;labelSubTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureErrorCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureErrorCollection = ";Configure Error Collection;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_Er" +
                "rorCollectionTitle";
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
            /// Caches the translated resource string for:  OrganizationName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOrganizationName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OrganizationalNameToUse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOrganizationalNameToUse;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc;
            
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
            /// Caches the translated resource string for:  Port
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPort;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CollectApplicationErrorsFromWindowsVistaOrLaterComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCollectApplicationErrorsFromWindowsVistaOrLaterComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FileSharePathExampleCErrorData
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFileSharePathExampleCErrorData;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyErrorCollectionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyErrorCollectionSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureErrorCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureErrorCollection;
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
            /// Exposes access to the OrganizationName translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OrganizationName
            {
                get
                {
                    if ((cachedOrganizationName == null))
                    {
                        cachedOrganizationName = CoreManager.MomConsole.GetIntlStr(ResourceOrganizationName);
                    }
                    return cachedOrganizationName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OrganizationalNameToUse translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OrganizationalNameToUse
            {
                get
                {
                    if ((cachedOrganizationalNameToUse == null))
                    {
                        cachedOrganizationalNameToUse = CoreManager.MomConsole.GetIntlStr(ResourceOrganizationalNameToUse);
                    }
                    return cachedOrganizationalNameToUse;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc
            {
                get
                {
                    if ((cachedYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc == null))
                    {
                        cachedYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc = CoreManager.MomConsole.GetIntlStr(ResourceYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc);
                    }
                    return cachedYouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc;
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
            /// Exposes access to the SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors
            {
                get
                {
                    if ((cachedSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors == null))
                    {
                        cachedSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors);
                    }
                    return cachedSpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrors;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CollectApplicationErrorsFromWindowsVistaOrLaterComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CollectApplicationErrorsFromWindowsVistaOrLaterComputers
            {
                get
                {
                    if ((cachedCollectApplicationErrorsFromWindowsVistaOrLaterComputers == null))
                    {
                        cachedCollectApplicationErrorsFromWindowsVistaOrLaterComputers = CoreManager.MomConsole.GetIntlStr(ResourceCollectApplicationErrorsFromWindowsVistaOrLaterComputers);
                    }
                    return cachedCollectApplicationErrorsFromWindowsVistaOrLaterComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace
            {
                get
                {
                    if ((cachedNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace == null))
                    {
                        cachedNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace = CoreManager.MomConsole.GetIntlStr(ResourceNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace);
                    }
                    return cachedNoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpace;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FileSharePathExampleCErrorData translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FileSharePathExampleCErrorData
            {
                get
                {
                    if ((cachedFileSharePathExampleCErrorData == null))
                    {
                        cachedFileSharePathExampleCErrorData = CoreManager.MomConsole.GetIntlStr(ResourceFileSharePathExampleCErrorData);
                    }
                    return cachedFileSharePathExampleCErrorData;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyErrorCollectionSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyErrorCollectionSettings
            {
                get
                {
                    if ((cachedSpecifyErrorCollectionSettings == null))
                    {
                        cachedSpecifyErrorCollectionSettings = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyErrorCollectionSettings);
                    }
                    return cachedSpecifyErrorCollectionSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports
            {
                get
                {
                    if ((cachedSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports == null))
                    {
                        cachedSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports);
                    }
                    return cachedSpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReports;
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
            /// Exposes access to the ConfigureErrorCollection translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureErrorCollection
            {
                get
                {
                    if ((cachedConfigureErrorCollection == null))
                    {
                        cachedConfigureErrorCollection = CoreManager.MomConsole.GetIntlStr(ResourceConfigureErrorCollection);
                    }
                    return cachedConfigureErrorCollection;
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
            /// Control ID for ReadThePrivacyStatementTextBox
            /// </summary>
            public const string ReadThePrivacyStatementTextBox = "textBoxCompanyName";
            
            /// <summary>
            /// Control ID for OrganizationNameStaticControl
            /// </summary>
            public const string OrganizationNameStaticControl = "labelCompanyName";
            
            /// <summary>
            /// Control ID for OrganizationalNameToUseStaticControl
            /// </summary>
            public const string OrganizationalNameToUseStaticControl = "labelTitle2";
            
            /// <summary>
            /// Control ID for YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc
            /// </summary>
            public const string YouCanSpecifyANameToUseInPlaceOfMicrosoftWhenAnErrorOccursUsersWillThenKnowThatErrorsAreBeingSentLoc = "labelSubTitle2";
            
            /// <summary>
            /// Control ID for NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl
            /// </summary>
            public const string NoteIfYouSelectTheSSLOptionACertificateNeedsToBeInstalledOnTheManagementServerStaticControl = "labelSslInfo";
            
            /// <summary>
            /// Control ID for UseSecureSocketsLayerSSLProtocolCheckBox
            /// </summary>
            public const string UseSecureSocketsLayerSSLProtocolCheckBox = "checkBoxUseSsl";
            
            /// <summary>
            /// Control ID for UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn
            /// </summary>
            public const string UsersInYourOrganizationMayAlreadyBeParticipatingInCEIPYouCanUseAManagementServerToCentrallyCollectAn = "textBoxPort";
            
            /// <summary>
            /// Control ID for PortStaticControl
            /// </summary>
            public const string PortStaticControl = "labelPort";
            
            /// <summary>
            /// Control ID for SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl
            /// </summary>
            public const string SpecifyTheManagementServerPortNumberToUseWhenClientsSubmitErrorsStaticControl = "labelPortDesc";
            
            /// <summary>
            /// Control ID for CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox
            /// </summary>
            public const string CollectApplicationErrorsFromWindowsVistaOrLaterComputersCheckBox = "checkBoxVistaAndLater";
            
            /// <summary>
            /// Control ID for NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl
            /// </summary>
            public const string NoteTheFileSharePathMustBeOnANTFSPartitionWithAtLeast2GBOfFreeSpaceStaticControl = "labelFileSharePathDesc";
            
            /// <summary>
            /// Control ID for DeploySettingsTextBox
            /// </summary>
            public const string DeploySettingsTextBox = "textBoxFileSharePath";
            
            /// <summary>
            /// Control ID for FileSharePathExampleCErrorDataStaticControl
            /// </summary>
            public const string FileSharePathExampleCErrorDataStaticControl = "labelFileSharePath";
            
            /// <summary>
            /// Control ID for SpecifyErrorCollectionSettingsStaticControl
            /// </summary>
            public const string SpecifyErrorCollectionSettingsStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon
            /// </summary>
            public const string SpecifyALocalDirectoryOnTheManagementServerWhichWillBeUsedAsAFileShareToCollectErrorReportsStaticCon = "labelSubTitle1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureErrorCollectionStaticControl
            /// </summary>
            public const string ConfigureErrorCollectionStaticControl = "headerLabel";
        }
        #endregion
    }
}
