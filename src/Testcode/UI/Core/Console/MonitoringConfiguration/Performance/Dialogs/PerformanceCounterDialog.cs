// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceCounterDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 3/25/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interface Definition - IPerformanceCounterDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceCounterDialogControls, for PerformanceCounterDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 3/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceCounterDialogControls
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
        /// Read-only property to access RuleTypeStaticControl
        /// </summary>
        StaticControl RuleTypeStaticControl
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
        /// Read-only property to access PerformanceCounterStaticControl
        /// </summary>
        StaticControl PerformanceCounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OptimizedCollectionStaticControl
        /// </summary>
        StaticControl OptimizedCollectionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComputerNameAndIntervalStaticControl
        /// </summary>
        StaticControl ComputerNameAndIntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyThePerformanceCounterStaticControl
        /// </summary>
        StaticControl SpecifyThePerformanceCounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalUnitsComboBox
        /// </summary>
        ComboBox IntervalUnitsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalComboBox
        /// </summary>
        TextBox IntervalComboBox
        {
            get;
        }

        ///// <summary>
        ///// Read-only property to access IntervalComboBox
        ///// </summary>
        //ComboBox IntervalComboBox
        //{
        //    get;
        //}
        /// <summary>
        /// Read-only property to access IntervalStaticControl
        /// </summary>
        StaticControl IntervalStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
        {
            get;
        }
        
        ///// <summary>
        ///// Read-only property to access IntervalUnitsStaticControl
        ///// </summary>
        //StaticControl IntervalUnitsStaticControl
        //{
        //    get;
        //}
        
        /// <summary>
        /// Read-only property to access NameChevronButton
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button NameChevronButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }
        
        ///// <summary>
        ///// Read-only property to access IntervalStaticControl
        ///// </summary>
        //StaticControl IntervalStaticControl
        //{
        //    get;
        //}
        
        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl
        /// </summary>
        StaticControl WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CounterTextBox
        /// </summary>
        TextBox CounterTextBox
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
        /// Read-only property to access IncludeAllInstancesForTheSelectedCounterCheckBox
        /// </summary>
        CheckBox IncludeAllInstancesForTheSelectedCounterCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InstanceTextBox
        /// </summary>
        TextBox InstanceTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectTextBox
        /// </summary>
        TextBox ObjectTextBox
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
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceObjectCounterAndInstanceStaticControl
        /// </summary>
        StaticControl PerformanceObjectCounterAndInstanceStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access STTrestrictedfrequenciesIntervalCtrlComboBox
        /// </summary>
        ComboBox STTrestrictedfrequenciesIntervalCtrlComboBox
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
    /// 	[mbickle] 3/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PerformanceCounterDialog : Dialog, IPerformanceCounterDialogControls
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
        /// Cache to hold a reference to RuleTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceCounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OptimizedCollectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOptimizedCollectionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComputerNameAndIntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerNameAndIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyThePerformanceCounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyThePerformanceCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IntervalUnitsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedIntervalUnitsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to IntervalComboBox of type ComboBox
        /// </summary>
        private TextBox cachedIntervalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        
        ///// <summary>
        ///// Cache to hold a reference to IntervalUnitsStaticControl of type StaticControl
        ///// </summary>
        //private StaticControl cachedIntervalUnitsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameChevronButton of type Button
        /// </summary>
        private Button cachedNameChevronButton;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        ///// <summary>
        ///// Cache to hold a reference to IntervalStaticControl of type StaticControl
        ///// </summary>
        //private StaticControl cachedIntervalStaticControl;


        ///// <summary>
        ///// Cache to hold a reference to IntervalComboBox of type ComboBox
        ///// </summary>
        //private ComboBox cachedIntervalComboBox;

        /// <summary>
        /// Cache to hold a reference to IntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CounterTextBox of type TextBox
        /// </summary>
        private TextBox cachedCounterTextBox;
        
        /// <summary>
        /// Cache to hold a reference to CounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IncludeAllInstancesForTheSelectedCounterCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedIncludeAllInstancesForTheSelectedCounterCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to InstanceTextBox of type TextBox
        /// </summary>
        private TextBox cachedInstanceTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ObjectTextBox of type TextBox
        /// </summary>
        private TextBox cachedObjectTextBox;
        
        /// <summary>
        /// Cache to hold a reference to InstanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInstanceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceObjectCounterAndInstanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceObjectCounterAndInstanceStaticControl;

        /// <summary>
        /// Cache to hold a reference to STTrestrictedfrequenciesIntervalCtrlComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSTTrestrictedfrequenciesIntervalCtrlComboBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceCounterDialog of type MomConsoleApp
        /// </param>
        /// <param name="windowCaption">MonitoringConfiguration.WindowCaptions</param>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceCounterDialog(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IPerformanceCounterDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceCounterDialogControls Controls
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
        ///  Property to handle checkbox IncludeAllInstancesForTheSelectedCounter
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool IncludeAllInstancesForTheSelectedCounter
        {
            get
            {
                return this.Controls.IncludeAllInstancesForTheSelectedCounterCheckBox.Checked;
            }
            
            set
            {
                this.Controls.IncludeAllInstancesForTheSelectedCounterCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control STTrestrictedfrequenciesIntervalCtrl
        /// </summary>
        /// <history>
        ///   [v-dayow] 23NOV09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string STTrestrictedfrequenciesIntervalCtrlText
        {
            get
            {
                return this.Controls.STTrestrictedfrequenciesIntervalCtrlComboBox.Text;
            }

            set
            {
                this.Controls.STTrestrictedfrequenciesIntervalCtrlComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IntervalUnits
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IntervalUnitsText
        {
            get
            {
                return this.Controls.IntervalUnitsComboBox.Text;
            }
           
            set
            {
                this.Controls.IntervalUnitsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Interval
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IntervalText
        {
            get
            {
                return this.Controls.IntervalComboBox.Text;
            }
          
            set
            {
                this.Controls.IntervalComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Counter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CounterText
        {
            get
            {
                return this.Controls.CounterTextBox.Text;
            }
            
            set
            {
                this.Controls.CounterTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Instance
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string InstanceText
        {
            get
            {
                return this.Controls.InstanceTextBox.Text;
            }
            
            set
            {
                this.Controls.InstanceTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ObjectName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ObjectText
        {
            get
            {
                return this.Controls.ObjectTextBox.Text;
            }
            
            set
            {
                this.Controls.ObjectTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCounterDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, PerformanceCounterDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCounterDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, PerformanceCounterDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCounterDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, PerformanceCounterDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCounterDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerformanceCounterDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.RuleTypeStaticControl);
                }
                return this.cachedRuleTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.GeneralStaticControl
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
        ///  Exposes access to the PerformanceCounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.PerformanceCounterStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedPerformanceCounterStaticControl == null))
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
                    this.cachedPerformanceCounterStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedPerformanceCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptimizedCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.OptimizedCollectionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedOptimizedCollectionStaticControl == null))
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
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedOptimizedCollectionStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedOptimizedCollectionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerNameAndIntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.ComputerNameAndIntervalStaticControl
        {
            get
            {
                if ((this.cachedComputerNameAndIntervalStaticControl == null))
                {
                    this.cachedComputerNameAndIntervalStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.ComputerNameAndIntervalStaticControl);
                }
                return this.cachedComputerNameAndIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyThePerformanceCounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.SpecifyThePerformanceCounterStaticControl
        {
            get
            {
                if ((this.cachedSpecifyThePerformanceCounterStaticControl == null))
                {
                    this.cachedSpecifyThePerformanceCounterStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.SpecifyThePerformanceCounterStaticControl);
                }
                return this.cachedSpecifyThePerformanceCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalUnitsComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceCounterDialogControls.IntervalUnitsComboBox
        {
            get
            {
                if ((this.cachedIntervalUnitsComboBox == null))
                {
                    this.cachedIntervalUnitsComboBox = new ComboBox(this, PerformanceCounterDialog.ControlIDs.IntervalUnitsComboBox);
                }
                return this.cachedIntervalUnitsComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 11/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.IntervalStaticControl
        {
            get
            {
                if ((this.cachedIntervalStaticControl == null))
                {
                    this.cachedIntervalStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.IntervalStaticControl);
                }

                return this.cachedIntervalStaticControl;
            }
        }

        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Exposes access to the IntervalComboBox control
        ///// </summary>
        ///// <history>
        ///// 	[dialac] 11/21/2006 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //ComboBox IPerformanceCounterDialogControls.IntervalComboBox
        //{
        //    get
        //    {
        //        if ((this.cachedIntervalComboBox == null))
        //        {
        //            this.cachedIntervalComboBox = new ComboBox(this, PerformanceCounterDialog.ControlIDs.IntervalComboBox);
        //        }
	//
        //        return this.cachedIntervalComboBox;
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceCounterDialogControls.IntervalComboBox
        {
            get
            {
                if ((this.cachedIntervalComboBox == null))
                {
                    this.cachedIntervalComboBox = new TextBox(this, PerformanceCounterDialog.ControlIDs.IntervalComboBox);
                }
                return this.cachedIntervalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Exposes access to the IntervalUnitsStaticControl control
        ///// </summary>
        ///// <history>
        ///// 	[mbickle] 3/25/2006 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //StaticControl IPerformanceCounterDialogControls.IntervalUnitsStaticControl
        //{
        //    get
        //    {
        //        if ((this.cachedIntervalUnitsStaticControl == null))
        //        {
        //            this.cachedIntervalUnitsStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.IntervalUnitsStaticControl);
        //        }
        //        return this.cachedIntervalUnitsStaticControl;
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameChevronButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCounterDialogControls.NameChevronButton
        {
            get
            {
                if ((this.cachedNameChevronButton == null))
                {
                    this.cachedNameChevronButton = new Button(this, PerformanceCounterDialog.ControlIDs.NameChevronButton);
                }
                return this.cachedNameChevronButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceCounterDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, PerformanceCounterDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        ///// -----------------------------------------------------------------------------
        ///// <summary>
        /////  Exposes access to the IntervalStaticControl control
        ///// </summary>
        ///// <history>
        ///// 	[mbickle] 3/25/2006 Created
        ///// </history>
        ///// -----------------------------------------------------------------------------
        //StaticControl IPerformanceCounterDialogControls.IntervalStaticControl
        //{
        //    get
        //    {
        //        if ((this.cachedIntervalStaticControl == null))
        //        {
        //            this.cachedIntervalStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.IntervalStaticControl);
        //        }
        //        return this.cachedIntervalStaticControl;
        //    }
        //}
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCounterDialogControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, PerformanceCounterDialog.ControlIDs.BrowseButton);
                }
                return this.cachedBrowseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl
        {
            get
            {
                if ((this.cachedWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl == null))
                {
                    this.cachedWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl);
                }
                return this.cachedWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CounterTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceCounterDialogControls.CounterTextBox
        {
            get
            {
                if ((this.cachedCounterTextBox == null))
                {
                    this.cachedCounterTextBox = new TextBox(this, PerformanceCounterDialog.ControlIDs.CounterTextBox);
                }
                return this.cachedCounterTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.CounterStaticControl
        {
            get
            {
                if ((this.cachedCounterStaticControl == null))
                {
                    this.cachedCounterStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.CounterStaticControl);
                }
                return this.cachedCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeAllInstancesForTheSelectedCounterCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceCounterDialogControls.IncludeAllInstancesForTheSelectedCounterCheckBox
        {
            get
            {
                if ((this.cachedIncludeAllInstancesForTheSelectedCounterCheckBox == null))
                {
                    this.cachedIncludeAllInstancesForTheSelectedCounterCheckBox = new CheckBox(this, PerformanceCounterDialog.ControlIDs.IncludeAllInstancesForTheSelectedCounterCheckBox);
                }
                return this.cachedIncludeAllInstancesForTheSelectedCounterCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InstanceTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceCounterDialogControls.InstanceTextBox
        {
            get
            {
                if ((this.cachedInstanceTextBox == null))
                {
                    this.cachedInstanceTextBox = new TextBox(this, PerformanceCounterDialog.ControlIDs.InstanceTextBox);
                }
                return this.cachedInstanceTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceCounterDialogControls.ObjectTextBox
        {
            get
            {
                if ((this.cachedObjectTextBox == null))
                {
                    this.cachedObjectTextBox = new TextBox(this, PerformanceCounterDialog.ControlIDs.ObjectTextBox);
                }
                return this.cachedObjectTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InstanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.InstanceStaticControl
        {
            get
            {
                if ((this.cachedInstanceStaticControl == null))
                {
                    this.cachedInstanceStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.InstanceStaticControl);
                }
                return this.cachedInstanceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.ObjectStaticControl
        {
            get
            {
                if ((this.cachedObjectStaticControl == null))
                {
                    this.cachedObjectStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.ObjectStaticControl);
                }
                return this.cachedObjectStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceObjectCounterAndInstanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCounterDialogControls.PerformanceObjectCounterAndInstanceStaticControl
        {
            get
            {
                if ((this.cachedPerformanceObjectCounterAndInstanceStaticControl == null))
                {
                    this.cachedPerformanceObjectCounterAndInstanceStaticControl = new StaticControl(this, PerformanceCounterDialog.ControlIDs.PerformanceObjectCounterAndInstanceStaticControl);
                }
                return this.cachedPerformanceObjectCounterAndInstanceStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the STTrestrictedfrequenciesIntervalCtrlComboBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 2009/11/23 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceCounterDialogControls.STTrestrictedfrequenciesIntervalCtrlComboBox
        {
            get
            {
                if ((this.cachedSTTrestrictedfrequenciesIntervalCtrlComboBox == null))
                {
                    this.cachedSTTrestrictedfrequenciesIntervalCtrlComboBox = new ComboBox(this, PerformanceCounterDialog.ControlIDs.STTrestrictedfrequenciesIntervalCtrlComboBox);
                }

                return this.cachedSTTrestrictedfrequenciesIntervalCtrlComboBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
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
        /// 	[mbickle] 3/25/2006 Created
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
        /// 	[mbickle] 3/25/2006 Created
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
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button NameChevronButton
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNameChevronButton()
        {
            this.Controls.NameChevronButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button IncludeAllInstancesForTheSelectedCounter
        /// </summary>
        /// <history>
        /// 	[mbickle] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickIncludeAllInstancesForTheSelectedCounter()
        {
            this.Controls.IncludeAllInstancesForTheSelectedCounterCheckBox.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <param name="windowCaption">dialog title</param>
        /// <history>
        /// 	[ruhim] 3/12/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
        {
            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                DialogTitle + "*", StringMatchSyntax.WildCard);

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
                        "Failed to find window with title:  '" + DialogTitle + "'");

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
        /// 	[mbickle] 3/25/2006 Created
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
            private const string ResourceDialogTitle = "Create Rule Wizard";

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
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.Common.PageCommonResources;CommitButtonText" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleType = ";Rule Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.ChooseRuleTypePage;$this.NavigationText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceCounter = ";Performance Counter;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.HttpUrlPerformanceCounterProviderPage;$" +
                "this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OptimizedCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOptimizedCollection = ";Optimized Collection;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.PagesOptimizedCollection.Localized" +
                "Strings;Title";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComputerNameAndInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputerNameAndInterval = ";Computer name and interval;ManagedString;Microsoft.MOM.UI.Components.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;pageSectio" +
                "nLabel2.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyThePerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyThePerformanceCounter = ";Specify the performance counter;ManagedString;Microsoft.MOM.UI.Components.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;pageS" +
                "ectionLabel1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.NameAndDescriptionPage;nameLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IntervalUnits
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntervalUnits = ";Use empty name to use the agent computer. Click browse button to use runtime sub" +
                "stitution.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.PerfCounterDataSource;substituteLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Interval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInterval = ";Inter&val:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.PerfCounterDataSource;intervalLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowse = ";Browse...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.PerfCounterDataSource;browseButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation = ";Wildcard characters * and ? are supported for advanced scenarios. Click help for" +
                " more information.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;exampleLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Counter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCounter = ";Co&unter:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.PerfCounterDataSource;counterLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IncludeAllInstancesForTheSelectedCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncludeAllInstancesForTheSelectedCounter = ";Inclu&de all instances for the selected counter;ManagedString;Microsoft.MOM.UI.C" +
                "omponents.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounter" +
                "DataSource;allInstancesCheckbox.Text";

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
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceObjectCounterAndInstance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceObjectCounterAndInstance = ";Performance Object, Counter and Instance;ManagedString;Microsoft.MOM.UI.Componen" +
                "ts.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSou" +
                "rce;$this.HeaderText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Days
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDays = ";Days;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeconds = ";Seconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHours = ";Hours;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinutes = ";Minutes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.IntervalUnitControl;comboBoxUnit.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  1 minute
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource1Minute = ";1 minute;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;STTrestrictedfrequenciesIntervalCtrl.Items";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  5 minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource5Minutes = ";5 minutes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;STTrestrictedfrequenciesIntervalCtrl.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  15 minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource15Minutes = ";15 minutes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;STTrestrictedfrequenciesIntervalCtrl.Items2";

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
            /// Caches the translated resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleType;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceCounter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OptimizedCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOptimizedCollection;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComputerNameAndInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputerNameAndInterval;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyThePerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyThePerformanceCounter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IntervalUnits
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntervalUnits;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Interval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInterval;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowse;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Counter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCounter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IncludeAllInstancesForTheSelectedCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIncludeAllInstancesForTheSelectedCounter;

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
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PerformanceObjectCounterAndInstance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceObjectCounterAndInstance;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeconds;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinutes;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHours;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Days
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDays;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  1 minute
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached1Minute;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  5 minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached5Minutes;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  15 minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached15Minutes;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
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
            /// 	[mbickle] 3/25/2006 Created
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
            /// 	[mbickle] 3/25/2006 Created
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
            /// 	[mbickle] 3/25/2006 Created
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
            /// 	[mbickle] 3/25/2006 Created
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
            /// Exposes access to the RuleType translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleType
            {
                get
                {
                    if ((cachedRuleType == null))
                    {
                        cachedRuleType = CoreManager.MomConsole.GetIntlStr(ResourceRuleType);
                    }
                    return cachedRuleType;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
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
            /// Exposes access to the PerformanceCounter translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
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
            /// Exposes access to the OptimizedCollection translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OptimizedCollection
            {
                get
                {
                    if ((cachedOptimizedCollection == null))
                    {
                        cachedOptimizedCollection = CoreManager.MomConsole.GetIntlStr(ResourceOptimizedCollection);
                    }
                    return cachedOptimizedCollection;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComputerNameAndInterval translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComputerNameAndInterval
            {
                get
                {
                    if ((cachedComputerNameAndInterval == null))
                    {
                        cachedComputerNameAndInterval = CoreManager.MomConsole.GetIntlStr(ResourceComputerNameAndInterval);
                    }
                    return cachedComputerNameAndInterval;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyThePerformanceCounter translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyThePerformanceCounter
            {
                get
                {
                    if ((cachedSpecifyThePerformanceCounter == null))
                    {
                        cachedSpecifyThePerformanceCounter = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyThePerformanceCounter);
                    }
                    return cachedSpecifyThePerformanceCounter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    return cachedName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IntervalUnits translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IntervalUnits
            {
                get
                {
                    if ((cachedIntervalUnits == null))
                    {
                        cachedIntervalUnits = CoreManager.MomConsole.GetIntlStr(ResourceIntervalUnits);
                    }
                    return cachedIntervalUnits;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Interval translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
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
            /// Exposes access to the Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
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
            /// Exposes access to the WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation
            {
                get
                {
                    if ((cachedWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation == null))
                    {
                        cachedWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation = CoreManager.MomConsole.GetIntlStr(ResourceWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation);
                    }
                    return cachedWildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformation;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Counter translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
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
            /// Exposes access to the IncludeAllInstancesForTheSelectedCounter translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IncludeAllInstancesForTheSelectedCounter
            {
                get
                {
                    if ((cachedIncludeAllInstancesForTheSelectedCounter == null))
                    {
                        cachedIncludeAllInstancesForTheSelectedCounter = CoreManager.MomConsole.GetIntlStr(ResourceIncludeAllInstancesForTheSelectedCounter);
                    }
                    return cachedIncludeAllInstancesForTheSelectedCounter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instance translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
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
            /// 	[mbickle] 3/25/2006 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
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
            /// Exposes access to the PerformanceObjectCounterAndInstance translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceObjectCounterAndInstance
            {
                get
                {
                    if ((cachedPerformanceObjectCounterAndInstance == null))
                    {
                        cachedPerformanceObjectCounterAndInstance = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceObjectCounterAndInstance);
                    }
                    return cachedPerformanceObjectCounterAndInstance;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
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
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Minutes
            {
                get
                {
                    if ((cachedMinutes == null))
                    {
                        cachedMinutes = CoreManager.MomConsole.GetIntlStr(ResourceMinutes);
                    }
                    return cachedMinutes;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Hours
            {
                get
                {
                    if ((cachedHours == null))
                    {
                        cachedHours = CoreManager.MomConsole.GetIntlStr(ResourceHours);
                    }
                    return cachedHours;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Days
            {
                get
                {
                    if ((cachedDays == null))
                    {
                        cachedDays = CoreManager.MomConsole.GetIntlStr(ResourceDays);
                    }
                    return cachedDays;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OneMinute
            {
                get
                {
                    if ((cached1Minute == null))
                    {
                        cached1Minute = CoreManager.MomConsole.GetIntlStr(Resource1Minute);
                    }
                    return cached1Minute;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FiveMinutes
            {
                get
                {
                    if ((cached5Minutes == null))
                    {
                        cached5Minutes = CoreManager.MomConsole.GetIntlStr(Resource5Minutes);
                    }
                    return cached5Minutes;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FifteenMinutes
            {
                get
                {
                    if ((cached15Minutes == null))
                    {
                        cached15Minutes = CoreManager.MomConsole.GetIntlStr(Resource15Minutes);
                    }
                    return cached15Minutes;
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
        /// 	[mbickle] 3/25/2006 Created
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
            /// Control ID for RuleTypeStaticControl
            /// </summary>
            public const string RuleTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceCounterStaticControl
            /// </summary>
            public const string PerformanceCounterStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for OptimizedCollectionStaticControl
            /// </summary>
            public const string OptimizedCollectionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ComputerNameAndIntervalStaticControl
            /// </summary>
            public const string ComputerNameAndIntervalStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for SpecifyThePerformanceCounterStaticControl
            /// </summary>
            public const string SpecifyThePerformanceCounterStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for IntervalUnitsComboBox
            /// </summary>
            public const string IntervalUnitsComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for IntervalComboBox
            /// </summary>
            public const string IntervalComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for IntervalUnitsStaticControl
            /// </summary>
            public const string IntervalUnitsStaticControl = "substituteLabel";
            
            /// <summary>
            /// Control ID for NameChevronButton
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string NameChevronButton = "hostTypesButton";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "computerNameTextBox";
            
            /// <summary>
            /// Control ID for IntervalStaticControl
            /// </summary>
            public const string IntervalStaticControl = "intervalLabel";
            
            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "browseButton";
            
            /// <summary>
            /// Control ID for WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl
            /// </summary>
            public const string WildcardCharactersAndAreSupportedForAdvancedScenariosClickHelpForMoreInformationStaticControl = "exampleLabel";
            
            /// <summary>
            /// Control ID for CounterTextBox
            /// </summary>
            public const string CounterTextBox = "counterTextbox";
            
            /// <summary>
            /// Control ID for CounterStaticControl
            /// </summary>
            public const string CounterStaticControl = "counterLabel";
            
            /// <summary>
            /// Control ID for IncludeAllInstancesForTheSelectedCounterCheckBox
            /// </summary>
            public const string IncludeAllInstancesForTheSelectedCounterCheckBox = "allInstancesCheckbox";
            
            /// <summary>
            /// Control ID for InstanceTextBox
            /// </summary>
            public const string InstanceTextBox = "instanceTextbox";
            
            /// <summary>
            /// Control ID for ObjectTextBox
            /// </summary>
            public const string ObjectTextBox = "objectTextbox";
            
            /// <summary>
            /// Control ID for InstanceStaticControl
            /// </summary>
            public const string InstanceStaticControl = "instancesLabel";
            
            /// <summary>
            /// Control ID for ObjectStaticControl
            /// </summary>
            public const string ObjectStaticControl = "objectLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceObjectCounterAndInstanceStaticControl
            /// </summary>
            public const string PerformanceObjectCounterAndInstanceStaticControl = "headerLabel";

            /// <summary>
            /// Control ID for STTrestrictedfrequenciesIntervalCtrlComboBox
            /// </summary>
            public const string STTrestrictedfrequenciesIntervalCtrlComboBox = "STTrestrictedfrequenciesIntervalCtrl";
        }
        #endregion
    }
}
