// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WMIPerformanceDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	Mom.Test.UI.Core.Console.CollectionRules.Dialogs
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[barryw] 25-Jul-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IWMIPerformanceDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWMIPerformanceDialogControls, for WMIPerformanceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryw] 25-Jul-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWMIPerformanceDialogControls
    {
        /// <summary>
        /// Read-only property to access NoteEnterOnePropertyNamePerLineStaticControl
        /// </summary>
        StaticControl NoteEnterOnePropertyNamePerLineStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SecondsStaticControl
        /// </summary>
        StaticControl SecondsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClickNextToContinueComboBox
        /// </summary>
        ComboBox ClickNextToContinueComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FrequencyStaticControl
        /// </summary>
        StaticControl FrequencyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox
        /// </summary>
        TextBox NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PropertyListStaticControl
        /// </summary>
        StaticControl PropertyListStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QueryStaticControl
        /// </summary>
        StaticControl QueryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex
        /// </summary>
        TextBox SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NamespaceStaticControl
        /// </summary>
        StaticControl NamespaceStaticControl
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
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BackButton
        /// </summary>
        Button BackButton
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
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WMIDataSourceConfigurationStaticControl
        /// </summary>
        StaticControl WMIDataSourceConfigurationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl
        /// </summary>
        StaticControl YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl
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
    /// 	[barryw] 25-Jul-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WMIPerformanceDialog : Dialog, IWMIPerformanceDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NoteEnterOnePropertyNamePerLineStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteEnterOnePropertyNamePerLineStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClickNextToContinueComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedClickNextToContinueComboBox;
        
        /// <summary>
        /// Cache to hold a reference to FrequencyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFrequencyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox of type TextBox
        /// </summary>
        private TextBox cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PropertyListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPropertyListStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to QueryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedQueryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex of type TextBox
        /// </summary>
        private TextBox cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex;
        
        /// <summary>
        /// Cache to hold a reference to NamespaceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNamespaceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to BackButton of type Button
        /// </summary>
        private Button cachedBackButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to WMIDataSourceConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWMIDataSourceConfigurationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WMIPerformanceDialog of type Mom.Test.UI.Core.Console.MomConsoleApp
        /// </param>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WMIPerformanceDialog(Mom.Test.UI.Core.Console.MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IWMIPerformanceDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWMIPerformanceDialogControls Controls
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
        ///  Routine to set/get the text in control ClickNextToContinue
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ClickNextToContinueText
        {
            get
            {
                return this.Controls.ClickNextToContinueComboBox.Text;
            }
            
            set
            {
                this.Controls.ClickNextToContinueComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadText
        {
            get
            {
                return this.Controls.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox.Text;
            }
            
            set
            {
                this.Controls.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsText
        {
            get
            {
                return this.Controls.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex.Text;
            }
            
            set
            {
                this.Controls.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteEnterOnePropertyNamePerLineStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIPerformanceDialogControls.NoteEnterOnePropertyNamePerLineStaticControl
        {
            get
            {
                if ((this.cachedNoteEnterOnePropertyNamePerLineStaticControl == null))
                {
                    this.cachedNoteEnterOnePropertyNamePerLineStaticControl = new StaticControl(this, WMIPerformanceDialog.ControlIDs.NoteEnterOnePropertyNamePerLineStaticControl);
                }
                return this.cachedNoteEnterOnePropertyNamePerLineStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIPerformanceDialogControls.SecondsStaticControl
        {
            get
            {
                if ((this.cachedSecondsStaticControl == null))
                {
                    this.cachedSecondsStaticControl = new StaticControl(this, WMIPerformanceDialog.ControlIDs.SecondsStaticControl);
                }
                return this.cachedSecondsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClickNextToContinueComboBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWMIPerformanceDialogControls.ClickNextToContinueComboBox
        {
            get
            {
                if ((this.cachedClickNextToContinueComboBox == null))
                {
                    this.cachedClickNextToContinueComboBox = new ComboBox(this, WMIPerformanceDialog.ControlIDs.ClickNextToContinueComboBox);
                }
                return this.cachedClickNextToContinueComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FrequencyStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIPerformanceDialogControls.FrequencyStaticControl
        {
            get
            {
                if ((this.cachedFrequencyStaticControl == null))
                {
                    this.cachedFrequencyStaticControl = new StaticControl(this, WMIPerformanceDialog.ControlIDs.FrequencyStaticControl);
                }
                return this.cachedFrequencyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWMIPerformanceDialogControls.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox
        {
            get
            {
                if ((this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox == null))
                {
                    this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox = new TextBox(this, WMIPerformanceDialog.ControlIDs.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox);
                }
                return this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertyListStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIPerformanceDialogControls.PropertyListStaticControl
        {
            get
            {
                if ((this.cachedPropertyListStaticControl == null))
                {
                    this.cachedPropertyListStaticControl = new StaticControl(this, WMIPerformanceDialog.ControlIDs.PropertyListStaticControl);
                }
                return this.cachedPropertyListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWMIPerformanceDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, WMIPerformanceDialog.ControlIDs.DescriptionTextBox);
                }
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIPerformanceDialogControls.QueryStaticControl
        {
            get
            {
                if ((this.cachedQueryStaticControl == null))
                {
                    this.cachedQueryStaticControl = new StaticControl(this, WMIPerformanceDialog.ControlIDs.QueryStaticControl);
                }
                return this.cachedQueryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWMIPerformanceDialogControls.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex
        {
            get
            {
                if ((this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex == null))
                {
                    this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex = new TextBox(this, WMIPerformanceDialog.ControlIDs.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex);
                }
                return this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NamespaceStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIPerformanceDialogControls.NamespaceStaticControl
        {
            get
            {
                if ((this.cachedNamespaceStaticControl == null))
                {
                    this.cachedNamespaceStaticControl = new StaticControl(this, WMIPerformanceDialog.ControlIDs.NamespaceStaticControl);
                }
                return this.cachedNamespaceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIPerformanceDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, WMIPerformanceDialog.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIPerformanceDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, WMIPerformanceDialog.ControlIDs.HelpButton);
                }
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BackButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIPerformanceDialogControls.BackButton
        {
            get
            {
                if ((this.cachedBackButton == null))
                {
                    this.cachedBackButton = new Button(this, WMIPerformanceDialog.ControlIDs.BackButton);
                }
                return this.cachedBackButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIPerformanceDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WMIPerformanceDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWMIPerformanceDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WMIPerformanceDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WMIDataSourceConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIPerformanceDialogControls.WMIDataSourceConfigurationStaticControl
        {
            get
            {
                if ((this.cachedWMIDataSourceConfigurationStaticControl == null))
                {
                    this.cachedWMIDataSourceConfigurationStaticControl = new StaticControl(this, WMIPerformanceDialog.ControlIDs.WMIDataSourceConfigurationStaticControl);
                }
                return this.cachedWMIDataSourceConfigurationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWMIPerformanceDialogControls.YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl
        {
            get
            {
                if ((this.cachedYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl == null))
                {
                    this.cachedYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl = new StaticControl(this, WMIPerformanceDialog.ControlIDs.YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl);
                }
                return this.cachedYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Back
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBack()
        {
            this.Controls.BackButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Mom.Test.UI.Core.Console.MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app)
        {
            Common.Utilities.LogMessage("Init(...)");
            Window tempWindow = app.GetWizardDialog(
                Strings.DialogTitle,
                Timeout);

            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Create Rule Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Wizards.Common.WizardResources;CreateRuleWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteEnterOnePropertyNamePerLine
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteEnterOnePropertyNamePerLine = ";Note: Enter one property name per line.;ManagedString;Microsoft.MOM.UI.Component" +
                "s.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;noteL" +
                "abel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeconds = ";seconds;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.Pages.DiscoveryIntervalPage;secondsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Frequency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFrequency = ";&Frequency:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Internal.UI.Authoring.Pages.WMIDataSource;frequencyLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PropertyList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePropertyList = ";&Property list:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.WMIDataSource;propListLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Query
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceQuery = ";&Query:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.Pages.WMIDataSource;queryLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Namespace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNamespace = ";Na&mespace:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Internal.UI.Authoring.Pages.WMIDataSource;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";&Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.M" +
                "om.Internal.UI.PageFrameworks.WizardFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Back
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBack = ";< &Back;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonBack.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WMIDataSourceConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWMIDataSourceConfiguration = ";WMI Data Source Configuration;ManagedString;Microsoft.MOM.UI.Components.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;$this.Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList = ";You can specify WMI namespace, how often to run the query and the property list." +
                ";ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement." +
                "Internal.UI.Authoring.Pages.WMIDataSource;$this.Subtitle";
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
            /// Caches the translated resource string for:  NoteEnterOnePropertyNamePerLine
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteEnterOnePropertyNamePerLine;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Frequency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFrequency;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PropertyList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPropertyList;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Query
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedQuery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Namespace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNamespace;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Back
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WMIDataSourceConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIDataSourceConfiguration;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
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
            /// Exposes access to the NoteEnterOnePropertyNamePerLine translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteEnterOnePropertyNamePerLine
            {
                get
                {
                    if ((cachedNoteEnterOnePropertyNamePerLine == null))
                    {
                        cachedNoteEnterOnePropertyNamePerLine = CoreManager.MomConsole.GetIntlStr(ResourceNoteEnterOnePropertyNamePerLine);
                    }
                    return cachedNoteEnterOnePropertyNamePerLine;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Seconds translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Seconds
            {
                get
                {
                    if ((cachedSeconds == null))
                    {
                        cachedSeconds = CoreManager.MomConsole.GetIntlStr(ResourceSeconds);
                    }
                    return cachedSeconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Frequency translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Frequency
            {
                get
                {
                    if ((cachedFrequency == null))
                    {
                        cachedFrequency = CoreManager.MomConsole.GetIntlStr(ResourceFrequency);
                    }
                    return cachedFrequency;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PropertyList translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PropertyList
            {
                get
                {
                    if ((cachedPropertyList == null))
                    {
                        cachedPropertyList = CoreManager.MomConsole.GetIntlStr(ResourcePropertyList);
                    }
                    return cachedPropertyList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Query translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Query
            {
                get
                {
                    if ((cachedQuery == null))
                    {
                        cachedQuery = CoreManager.MomConsole.GetIntlStr(ResourceQuery);
                    }
                    return cachedQuery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Namespace translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Namespace
            {
                get
                {
                    if ((cachedNamespace == null))
                    {
                        cachedNamespace = CoreManager.MomConsole.GetIntlStr(ResourceNamespace);
                    }
                    return cachedNamespace;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
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
            /// Exposes access to the Back translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Back
            {
                get
                {
                    if ((cachedBack == null))
                    {
                        cachedBack = CoreManager.MomConsole.GetIntlStr(ResourceBack);
                    }
                    return cachedBack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
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
            /// Exposes access to the WMIDataSourceConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIDataSourceConfiguration
            {
                get
                {
                    if ((cachedWMIDataSourceConfiguration == null))
                    {
                        cachedWMIDataSourceConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceWMIDataSourceConfiguration);
                    }
                    return cachedWMIDataSourceConfiguration;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList
            {
                get
                {
                    if ((cachedYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList == null))
                    {
                        cachedYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList = CoreManager.MomConsole.GetIntlStr(ResourceYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList);
                    }
                    return cachedYouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyList;
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
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NoteEnterOnePropertyNamePerLineStaticControl
            /// </summary>
            public const string NoteEnterOnePropertyNamePerLineStaticControl = "noteLabel";
            
            /// <summary>
            /// Control ID for SecondsStaticControl
            /// </summary>
            public const string SecondsStaticControl = "secondsLabel";
            
            /// <summary>
            /// Control ID for ClickNextToContinueComboBox
            /// </summary>
            public const string ClickNextToContinueComboBox = "frequencyUpDown";
            
            /// <summary>
            /// Control ID for FrequencyStaticControl
            /// </summary>
            public const string FrequencyStaticControl = "frequencyLabel";
            
            /// <summary>
            /// Control ID for NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox
            /// </summary>
            public const string NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox = "propertyListTextBox";
            
            /// <summary>
            /// Control ID for PropertyListStaticControl
            /// </summary>
            public const string PropertyListStaticControl = "propListLabel";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "queryTextBox";
            
            /// <summary>
            /// Control ID for QueryStaticControl
            /// </summary>
            public const string QueryStaticControl = "queryLabel";
            
            /// <summary>
            /// Control ID for SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex
            /// </summary>
            public const string SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex = "nameSpaceTextBox";
            
            /// <summary>
            /// Control ID for NamespaceStaticControl
            /// </summary>
            public const string NamespaceStaticControl = "label1";
            
            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "buttonFinish";
            
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "buttonHelp";
            
            /// <summary>
            /// Control ID for BackButton
            /// </summary>
            public const string BackButton = "buttonBack";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "buttonNext";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for WMIDataSourceConfigurationStaticControl
            /// </summary>
            public const string WMIDataSourceConfigurationStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl
            /// </summary>
            public const string YouCanSpecifyWMINamespaceHowOftenToRunTheQueryAndThePropertyListStaticControl = "labelSubtitle";
        }
        #endregion
    }
}
