// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WindowsPerformanceDialog.cs">
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
    
    #region Interface Definition - IWindowsPerformanceDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWindowsPerformanceDialogControls, for WindowsPerformanceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryw] 25-Jul-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWindowsPerformanceDialogControls
    {
        /// <summary>
        /// Read-only property to access IntervalStaticControl
        /// </summary>
        StaticControl IntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button5
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button5
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
        /// Read-only property to access WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic
        /// </summary>
        StaticControl WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic
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
        /// Read-only property to access CounterStaticControl
        /// </summary>
        StaticControl CounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllInstancesCheckBox
        /// </summary>
        CheckBox AllInstancesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2
        /// </summary>
        TextBox NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2
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
        /// Read-only property to access InstanceStaticControl
        /// </summary>
        StaticControl InstanceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectStaticControl
        /// </summary>
        StaticControl ObjectStaticControl
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
        /// Read-only property to access PerformanceCounterStaticControl
        /// </summary>
        StaticControl PerformanceCounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC
        /// </summary>
        StaticControl YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC
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
    public class WindowsPerformanceDialog : Dialog, IWindowsPerformanceDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to IntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button5 of type Button
        /// </summary>
        private Button cachedButton5;
        
        /// <summary>
        /// Cache to hold a reference to SecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClickNextToContinueComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedClickNextToContinueComboBox;
        
        /// <summary>
        /// Cache to hold a reference to WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic of type StaticControl
        /// </summary>
        private StaticControl cachedWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic;
        
        /// <summary>
        /// Cache to hold a reference to NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox of type TextBox
        /// </summary>
        private TextBox cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox;
        
        /// <summary>
        /// Cache to hold a reference to CounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AllInstancesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAllInstancesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2 of type TextBox
        /// </summary>
        private TextBox cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex of type TextBox
        /// </summary>
        private TextBox cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex;
        
        /// <summary>
        /// Cache to hold a reference to InstanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInstanceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectStaticControl;
        
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
        /// Cache to hold a reference to PerformanceCounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WindowsPerformanceDialog of type Mom.Test.UI.Core.Console.MomConsoleApp
        /// </param>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WindowsPerformanceDialog(Mom.Test.UI.Core.Console.MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IWindowsPerformanceDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWindowsPerformanceDialogControls Controls
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
        ///  Property to handle checkbox AllInstances
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool AllInstances
        {
            get
            {
                return this.Controls.AllInstancesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AllInstancesCheckBox.Checked = value;
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
        ///  Routine to set/get the text in control NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead2Text
        {
            get
            {
                return this.Controls.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2.Text;
            }
            
            set
            {
                this.Controls.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2.Text = value;
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
        ///  Exposes access to the IntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsPerformanceDialogControls.IntervalStaticControl
        {
            get
            {
                if ((this.cachedIntervalStaticControl == null))
                {
                    this.cachedIntervalStaticControl = new StaticControl(this, WindowsPerformanceDialog.ControlIDs.IntervalStaticControl);
                }
                return this.cachedIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button5 control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWindowsPerformanceDialogControls.Button5
        {
            get
            {
                if ((this.cachedButton5 == null))
                {
                    this.cachedButton5 = new Button(this, WindowsPerformanceDialog.ControlIDs.Button5);
                }
                return this.cachedButton5;
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
        StaticControl IWindowsPerformanceDialogControls.SecondsStaticControl
        {
            get
            {
                if ((this.cachedSecondsStaticControl == null))
                {
                    this.cachedSecondsStaticControl = new StaticControl(this, WindowsPerformanceDialog.ControlIDs.SecondsStaticControl);
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
        ComboBox IWindowsPerformanceDialogControls.ClickNextToContinueComboBox
        {
            get
            {
                if ((this.cachedClickNextToContinueComboBox == null))
                {
                    this.cachedClickNextToContinueComboBox = new ComboBox(this, WindowsPerformanceDialog.ControlIDs.ClickNextToContinueComboBox);
                }
                return this.cachedClickNextToContinueComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsPerformanceDialogControls.WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic
        {
            get
            {
                if ((this.cachedWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic == null))
                {
                    this.cachedWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic = new StaticControl(this, WindowsPerformanceDialog.ControlIDs.WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic);
                }
                return this.cachedWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic;
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
        TextBox IWindowsPerformanceDialogControls.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox
        {
            get
            {
                if ((this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox == null))
                {
                    this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox = new TextBox(this, WindowsPerformanceDialog.ControlIDs.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox);
                }
                return this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsPerformanceDialogControls.CounterStaticControl
        {
            get
            {
                if ((this.cachedCounterStaticControl == null))
                {
                    this.cachedCounterStaticControl = new StaticControl(this, WindowsPerformanceDialog.ControlIDs.CounterStaticControl);
                }
                return this.cachedCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllInstancesCheckBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWindowsPerformanceDialogControls.AllInstancesCheckBox
        {
            get
            {
                if ((this.cachedAllInstancesCheckBox == null))
                {
                    this.cachedAllInstancesCheckBox = new CheckBox(this, WindowsPerformanceDialog.ControlIDs.AllInstancesCheckBox);
                }
                return this.cachedAllInstancesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2 control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWindowsPerformanceDialogControls.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2
        {
            get
            {
                if ((this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2 == null))
                {
                    this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2 = new TextBox(this, WindowsPerformanceDialog.ControlIDs.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2);
                }
                return this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2;
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
        TextBox IWindowsPerformanceDialogControls.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex
        {
            get
            {
                if ((this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex == null))
                {
                    this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex = new TextBox(this, WindowsPerformanceDialog.ControlIDs.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex);
                }
                return this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InstanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsPerformanceDialogControls.InstanceStaticControl
        {
            get
            {
                if ((this.cachedInstanceStaticControl == null))
                {
                    this.cachedInstanceStaticControl = new StaticControl(this, WindowsPerformanceDialog.ControlIDs.InstanceStaticControl);
                }
                return this.cachedInstanceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsPerformanceDialogControls.ObjectStaticControl
        {
            get
            {
                if ((this.cachedObjectStaticControl == null))
                {
                    this.cachedObjectStaticControl = new StaticControl(this, WindowsPerformanceDialog.ControlIDs.ObjectStaticControl);
                }
                return this.cachedObjectStaticControl;
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
        Button IWindowsPerformanceDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, WindowsPerformanceDialog.ControlIDs.FinishButton);
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
        Button IWindowsPerformanceDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, WindowsPerformanceDialog.ControlIDs.HelpButton);
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
        Button IWindowsPerformanceDialogControls.BackButton
        {
            get
            {
                if ((this.cachedBackButton == null))
                {
                    this.cachedBackButton = new Button(this, WindowsPerformanceDialog.ControlIDs.BackButton);
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
        Button IWindowsPerformanceDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WindowsPerformanceDialog.ControlIDs.NextButton);
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
        Button IWindowsPerformanceDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WindowsPerformanceDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceCounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsPerformanceDialogControls.PerformanceCounterStaticControl
        {
            get
            {
                if ((this.cachedPerformanceCounterStaticControl == null))
                {
                    this.cachedPerformanceCounterStaticControl = new StaticControl(this, WindowsPerformanceDialog.ControlIDs.PerformanceCounterStaticControl);
                }
                return this.cachedPerformanceCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC control
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsPerformanceDialogControls.YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC
        {
            get
            {
                if ((this.cachedYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC == null))
                {
                    this.cachedYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC = new StaticControl(this, WindowsPerformanceDialog.ControlIDs.YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC);
                }
                return this.cachedYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button5
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton5()
        {
            this.Controls.Button5.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AllInstances
        /// </summary>
        /// <history>
        /// 	[barryw] 25-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAllInstances()
        {
            this.Controls.AllInstancesCheckBox.Click();
        }
        
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
            /// Contains resource string for:  Interval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInterval = ";Inter&val:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.PerfCounterDataSource;intervalLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeconds = ";S&econds;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.Pages.PerfCounterDataSource;secondsLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation = ";Wildcard characters * and ? are supported for advanced scenarios. See product do" +
                "cumentation for more information.;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;exa" +
                "mpleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Counter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCounter = ";Co&unter:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.PerfCounterDataSource;counterLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllInstances
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllInstances = ";A&ll instances;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;allInstancesCheckbox.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Instance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInstance = ";Ins&tance:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.PerfCounterDataSource;instancesLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Object
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObject = ";&Object:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.Pages.PerfCounterBrowser;objectLabel.Text";
            
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
            /// Contains resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceCounter = ";Performance Counter;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects = ";You can enter performance counter information or browse to a computer to view re" +
                "gistered performance objects. ;ManagedString;Microsoft.MOM.UI.Components.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;$this." +
                "Subtitle";
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
            /// Caches the translated resource string for:  Interval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInterval;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Counter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCounter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllInstances
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllInstances;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Instance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInstance;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Object
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObject;
            
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
            /// Caches the translated resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceCounter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects;
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
            /// Exposes access to the Interval translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Interval
            {
                get
                {
                    if ((cachedInterval == null))
                    {
                        cachedInterval = CoreManager.MomConsole.GetIntlStr(ResourceInterval);
                    }
                    return cachedInterval;
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
            /// Exposes access to the WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation
            {
                get
                {
                    if ((cachedWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation == null))
                    {
                        cachedWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation = CoreManager.MomConsole.GetIntlStr(ResourceWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation);
                    }
                    return cachedWildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Counter translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Counter
            {
                get
                {
                    if ((cachedCounter == null))
                    {
                        cachedCounter = CoreManager.MomConsole.GetIntlStr(ResourceCounter);
                    }
                    return cachedCounter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllInstances translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllInstances
            {
                get
                {
                    if ((cachedAllInstances == null))
                    {
                        cachedAllInstances = CoreManager.MomConsole.GetIntlStr(ResourceAllInstances);
                    }
                    return cachedAllInstances;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instance translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Instance
            {
                get
                {
                    if ((cachedInstance == null))
                    {
                        cachedInstance = CoreManager.MomConsole.GetIntlStr(ResourceInstance);
                    }
                    return cachedInstance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Object translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Object
            {
                get
                {
                    if ((cachedObject == null))
                    {
                        cachedObject = CoreManager.MomConsole.GetIntlStr(ResourceObject);
                    }
                    return cachedObject;
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
            /// Exposes access to the PerformanceCounter translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceCounter
            {
                get
                {
                    if ((cachedPerformanceCounter == null))
                    {
                        cachedPerformanceCounter = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceCounter);
                    }
                    return cachedPerformanceCounter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects
            {
                get
                {
                    if ((cachedYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects == null))
                    {
                        cachedYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects = CoreManager.MomConsole.GetIntlStr(ResourceYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects);
                    }
                    return cachedYouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjects;
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
            /// Control ID for IntervalStaticControl
            /// </summary>
            public const string IntervalStaticControl = "intervalLabel";
            
            /// <summary>
            /// Control ID for Button5
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button5 = "browseButton";
            
            /// <summary>
            /// Control ID for SecondsStaticControl
            /// </summary>
            public const string SecondsStaticControl = "secondsLabel";
            
            /// <summary>
            /// Control ID for ClickNextToContinueComboBox
            /// </summary>
            public const string ClickNextToContinueComboBox = "numericUpDown";
            
            /// <summary>
            /// Control ID for WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic
            /// </summary>
            public const string WildcardCharactersAndAreSupportedForAdvancedScenariosSeeProductDocumentationForMoreInformationStatic = "exampleLabel";
            
            /// <summary>
            /// Control ID for NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox
            /// </summary>
            public const string NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox = "counterTextbox";
            
            /// <summary>
            /// Control ID for CounterStaticControl
            /// </summary>
            public const string CounterStaticControl = "counterLabel";
            
            /// <summary>
            /// Control ID for AllInstancesCheckBox
            /// </summary>
            public const string AllInstancesCheckBox = "allInstancesCheckbox";
            
            /// <summary>
            /// Control ID for NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2
            /// </summary>
            public const string NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadTextBox2 = "instanceTextbox";
            
            /// <summary>
            /// Control ID for SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex
            /// </summary>
            public const string SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsTex = "objectTextbox";
            
            /// <summary>
            /// Control ID for InstanceStaticControl
            /// </summary>
            public const string InstanceStaticControl = "instancesLabel";
            
            /// <summary>
            /// Control ID for ObjectStaticControl
            /// </summary>
            public const string ObjectStaticControl = "objectLabel";
            
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
            /// Control ID for PerformanceCounterStaticControl
            /// </summary>
            public const string PerformanceCounterStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC
            /// </summary>
            public const string YouCanEnterPerformanceCounterInformationOrBrowseToAComputerToViewRegisteredPerformanceObjectsStaticC = "labelSubtitle";
        }
        #endregion
    }
}
