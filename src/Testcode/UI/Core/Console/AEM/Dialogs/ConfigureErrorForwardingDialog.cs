// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfigureErrorForwardingDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	AEM Deployment Dialog - 3rd screen
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
   
    #region Radio Group Enumeration - RadioGroupTab3

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroupTab3
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroupTab3
    {
        /// <summary>
        /// DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile = 0
        /// </summary>
        DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile = 0,
        
        /// <summary>
        /// BasicOnlyTheErrorSignature = 1
        /// </summary>
        BasicOnlyTheErrorSignature = 1,
    }
    #endregion
    
    #region Interface Definition - IConfigureErrorForwardingDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfigureErrorForwardingDialogControls, for ConfigureErrorForwardingDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 4/12/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfigureErrorForwardingDialogControls
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
        /// Read-only property to access DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton
        /// </summary>
        RadioButton DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BasicOnlyTheErrorSignatureRadioButton
        /// </summary>
        RadioButton BasicOnlyTheErrorSignatureRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl
        /// </summary>
        StaticControl DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox
        /// </summary>
        CheckBox AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox
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
        /// Read-only property to access YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport
        /// </summary>
        StaticControl YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport
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
        /// Read-only property to access ConfigureErrorForwardingStaticControl
        /// </summary>
        StaticControl ConfigureErrorForwardingStaticControl
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
    public class ConfigureErrorForwardingDialog : Dialog, IConfigureErrorForwardingDialogControls
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
        /// Cache to hold a reference to DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to BasicOnlyTheErrorSignatureRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBasicOnlyTheErrorSignatureRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyErrorCollectionSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyErrorCollectionSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureErrorForwardingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureErrorForwardingStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfigureErrorForwardingDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfigureErrorForwardingDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroupTab3
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroupTab3 RadioGroupTab3
        {
            get
            {
                if ((this.Controls.DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTab3.DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile;
                }
                
                if ((this.Controls.BasicOnlyTheErrorSignatureRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTab3.BasicOnlyTheErrorSignature;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroupTab3.DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile))
                {
                    this.Controls.DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroupTab3.BasicOnlyTheErrorSignature))
                    {
                        this.Controls.BasicOnlyTheErrorSignatureRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IConfigureErrorForwardingDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfigureErrorForwardingDialogControls Controls
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
        ///  Property to handle checkbox AutomaticallyForwardAllCollectedErrorsToMicrosoft
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool AutomaticallyForwardAllCollectedErrorsToMicrosoft
        {
            get
            {
                return this.Controls.AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox.Checked = value;
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
        Button IConfigureErrorForwardingDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ConfigureErrorForwardingDialog.ControlIDs.PreviousButton);
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
        Button IConfigureErrorForwardingDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ConfigureErrorForwardingDialog.ControlIDs.NextButton);
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
        Button IConfigureErrorForwardingDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ConfigureErrorForwardingDialog.ControlIDs.FinishButton);
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
        Button IConfigureErrorForwardingDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConfigureErrorForwardingDialog.ControlIDs.CancelButton);
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
        StaticControl IConfigureErrorForwardingDialogControls.CEIPForwardingStaticControl
        {
            get
            {
                if ((this.cachedCEIPForwardingStaticControl == null))
                {
                    this.cachedCEIPForwardingStaticControl = new StaticControl(this, ConfigureErrorForwardingDialog.ControlIDs.CEIPForwardingStaticControl);
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
        StaticControl IConfigureErrorForwardingDialogControls.ErrorCollectionStaticControl
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
        StaticControl IConfigureErrorForwardingDialogControls.ErrorForwardingStaticControl
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
        StaticControl IConfigureErrorForwardingDialogControls.CreateFileShareStaticControl
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
        StaticControl IConfigureErrorForwardingDialogControls.TaskStatusStaticControl
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
        StaticControl IConfigureErrorForwardingDialogControls.DeploySettingsStaticControl
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
        StaticControl IConfigureErrorForwardingDialogControls.ReadThePrivacyStatementStaticControl
        {
            get
            {
                if ((this.cachedReadThePrivacyStatementStaticControl == null))
                {
                    this.cachedReadThePrivacyStatementStaticControl = new StaticControl(this, ConfigureErrorForwardingDialog.ControlIDs.ReadThePrivacyStatementStaticControl);
                }
                return this.cachedReadThePrivacyStatementStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IConfigureErrorForwardingDialogControls.DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton
        {
            get
            {
                if ((this.cachedDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton == null))
                {
                    this.cachedDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton = new RadioButton(this, ConfigureErrorForwardingDialog.ControlIDs.DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton);
                }
                return this.cachedDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BasicOnlyTheErrorSignatureRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IConfigureErrorForwardingDialogControls.BasicOnlyTheErrorSignatureRadioButton
        {
            get
            {
                if ((this.cachedBasicOnlyTheErrorSignatureRadioButton == null))
                {
                    this.cachedBasicOnlyTheErrorSignatureRadioButton = new RadioButton(this, ConfigureErrorForwardingDialog.ControlIDs.BasicOnlyTheErrorSignatureRadioButton);
                }
                return this.cachedBasicOnlyTheErrorSignatureRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorForwardingDialogControls.DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl
        {
            get
            {
                if ((this.cachedDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl == null))
                {
                    this.cachedDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl = new StaticControl(this, ConfigureErrorForwardingDialog.ControlIDs.DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl);
                }
                return this.cachedDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IConfigureErrorForwardingDialogControls.AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox
        {
            get
            {
                if ((this.cachedAutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox == null))
                {
                    this.cachedAutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox = new CheckBox(this, ConfigureErrorForwardingDialog.ControlIDs.AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox);
                }
                return this.cachedAutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox;
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
        StaticControl IConfigureErrorForwardingDialogControls.SpecifyErrorCollectionSettingsStaticControl
        {
            get
            {
                if ((this.cachedSpecifyErrorCollectionSettingsStaticControl == null))
                {
                    this.cachedSpecifyErrorCollectionSettingsStaticControl = new StaticControl(this, ConfigureErrorForwardingDialog.ControlIDs.SpecifyErrorCollectionSettingsStaticControl);
                }
                return this.cachedSpecifyErrorCollectionSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorForwardingDialogControls.YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport
        {
            get
            {
                if ((this.cachedYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport == null))
                {
                    this.cachedYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport = new StaticControl(this, ConfigureErrorForwardingDialog.ControlIDs.YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport);
                }
                return this.cachedYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport;
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
        StaticControl IConfigureErrorForwardingDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ConfigureErrorForwardingDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureErrorForwardingStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfigureErrorForwardingDialogControls.ConfigureErrorForwardingStaticControl
        {
            get
            {
                if ((this.cachedConfigureErrorForwardingStaticControl == null))
                {
                    this.cachedConfigureErrorForwardingStaticControl = new StaticControl(this, ConfigureErrorForwardingDialog.ControlIDs.ConfigureErrorForwardingStaticControl);
                }
                return this.cachedConfigureErrorForwardingStaticControl;
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
        ///  Routine to click on button AutomaticallyForwardAllCollectedErrorsToMicrosoft
        /// </summary>
        /// <history>
        /// 	[lucyra] 4/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAutomaticallyForwardAllCollectedErrorsToMicrosoft()
        {
            this.Controls.AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox.Click();
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
            /// Contains resource string for:  DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile = ";Detailed (includes additional information requested by Microsoft in a data file)" +
                ";ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.I" +
                "nternal.UI.Console.Administration.ClientMonitoring.ErrorForwarding;radioButtonDe" +
                "tailed.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BasicOnlyTheErrorSignature
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBasicOnlyTheErrorSignature = ";Basic (only the error signature);ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitori" +
                "ng.ErrorForwarding;radioButtonBasic.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft = ";Do you want to forward detailed or basic error reports to Microsoft?;ManagedStri" +
                "ng;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.C" +
                "onsole.Administration.ClientMonitoring.ErrorForwarding;labelTransmissionDesc.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutomaticallyForwardAllCollectedErrorsToMicrosoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomaticallyForwardAllCollectedErrorsToMicrosoft = ";Automatically forward all collected errors to Microsoft. ;ManagedString;Microsof" +
                "t.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Admi" +
                "nistration.ClientMonitoring.ErrorForwarding;checkBoxTransmission.Text";
            
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
            /// Contains resource string for:  YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport = "You can optionally forward the collected error reports to Microsoft automatically" +
                ". Microsoft uses these error reports to improve its products. If a solution is a" +
                "vailable when you transmit an error report to Microsoft, a link to it will be do" +
                "wnloaded. Then";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureErrorForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureErrorForwarding = ";Configure Error Forwarding;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;CM_Er" +
                "rorForwardingTitle";
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
            /// Caches the translated resource string for:  DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BasicOnlyTheErrorSignature
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBasicOnlyTheErrorSignature;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutomaticallyForwardAllCollectedErrorsToMicrosoft
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutomaticallyForwardAllCollectedErrorsToMicrosoft;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyErrorCollectionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyErrorCollectionSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureErrorForwarding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureErrorForwarding;
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
            /// Exposes access to the DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile
            {
                get
                {
                    if ((cachedDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile == null))
                    {
                        cachedDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile = CoreManager.MomConsole.GetIntlStr(ResourceDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile);
                    }
                    return cachedDetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFile;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BasicOnlyTheErrorSignature translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BasicOnlyTheErrorSignature
            {
                get
                {
                    if ((cachedBasicOnlyTheErrorSignature == null))
                    {
                        cachedBasicOnlyTheErrorSignature = CoreManager.MomConsole.GetIntlStr(ResourceBasicOnlyTheErrorSignature);
                    }
                    return cachedBasicOnlyTheErrorSignature;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft
            {
                get
                {
                    if ((cachedDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft == null))
                    {
                        cachedDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft = CoreManager.MomConsole.GetIntlStr(ResourceDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft);
                    }
                    return cachedDoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoft;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutomaticallyForwardAllCollectedErrorsToMicrosoft translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutomaticallyForwardAllCollectedErrorsToMicrosoft
            {
                get
                {
                    if ((cachedAutomaticallyForwardAllCollectedErrorsToMicrosoft == null))
                    {
                        cachedAutomaticallyForwardAllCollectedErrorsToMicrosoft = CoreManager.MomConsole.GetIntlStr(ResourceAutomaticallyForwardAllCollectedErrorsToMicrosoft);
                    }
                    return cachedAutomaticallyForwardAllCollectedErrorsToMicrosoft;
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
            /// Exposes access to the YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport
            {
                get
                {
                    if ((cachedYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport == null))
                    {
                        cachedYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport = CoreManager.MomConsole.GetIntlStr(ResourceYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport);
                    }
                    return cachedYouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport;
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
            /// Exposes access to the ConfigureErrorForwarding translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 4/12/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureErrorForwarding
            {
                get
                {
                    if ((cachedConfigureErrorForwarding == null))
                    {
                        cachedConfigureErrorForwarding = CoreManager.MomConsole.GetIntlStr(ResourceConfigureErrorForwarding);
                    }
                    return cachedConfigureErrorForwarding;
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
            /// Control ID for DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton
            /// </summary>
            public const string DetailedIncludesAdditionalInformationRequestedByMicrosoftInADataFileRadioButton = "radioButtonDetailed";
            
            /// <summary>
            /// Control ID for BasicOnlyTheErrorSignatureRadioButton
            /// </summary>
            public const string BasicOnlyTheErrorSignatureRadioButton = "radioButtonBasic";
            
            /// <summary>
            /// Control ID for DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl
            /// </summary>
            public const string DoYouWantToForwardDetailedOrBasicErrorReportsToMicrosoftStaticControl = "labelTransmissionDesc";
            
            /// <summary>
            /// Control ID for AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox
            /// </summary>
            public const string AutomaticallyForwardAllCollectedErrorsToMicrosoftCheckBox = "checkBoxTransmission";
            
            /// <summary>
            /// Control ID for SpecifyErrorCollectionSettingsStaticControl
            /// </summary>
            public const string SpecifyErrorCollectionSettingsStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport
            /// </summary>
            public const string YouCanOptionallyForwardTheCollectedErrorReportsToMicrosoftAutomaticallyMicrosoftUsesTheseErrorReport = "labelSubTitle1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureErrorForwardingStaticControl
            /// </summary>
            public const string ConfigureErrorForwardingStaticControl = "headerLabel";
        }
        #endregion
    }
}
