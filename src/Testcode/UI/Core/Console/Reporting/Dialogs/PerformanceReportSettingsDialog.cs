// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceReportSettingsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[starrpar] 1/26/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;

    #region Radio Group Enumeration - Details

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Details
    /// </summary>
    /// <history>
    /// 	[starrpar] 1/26/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Details
    {
        /// <summary>
        /// SpecificInstances = 0
        /// </summary>
        SpecificInstances = 0,
        
        /// <summary>
        /// AllInstances = 1
        /// </summary>
        AllInstances = 1,
    }
    #endregion
    
    #region Interface Definition - IPerformanceReportSettingsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceReportSettingsDialogControls, for PerformanceReportSettingsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[starrpar] 1/26/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceReportSettingsDialogControls
    {
        /// <summary>
        /// Read-only property to access ListPropertyGridView
        /// </summary>
        PropertyGridView ListPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ListStaticControl
        /// </summary>
        StaticControl ListStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NewSeriesButton
        /// </summary>
        Button NewSeriesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NewChartButton
        /// </summary>
        Button NewChartButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ColorComboBox
        /// </summary>
        ComboBox ColorComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ColorStaticControl
        /// </summary>
        StaticControl ColorStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScaleComboBox
        /// </summary>
        ComboBox ScaleComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScaleStaticControl
        /// </summary>
        StaticControl ScaleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StyleComboBox
        /// </summary>
        ComboBox StyleComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StyleStaticControl
        /// </summary>
        StaticControl StyleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChartTitleTextBox
        /// </summary>
        TextBox ChartTitleTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChartTitleStaticControl
        /// </summary>
        StaticControl ChartTitleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsStaticControl
        /// </summary>
        StaticControl ObjectsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsPropertyGridView
        /// </summary>
        PropertyGridView ObjectsPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton2
        /// </summary>
        Button RemoveButton2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddObjectButton
        /// </summary>
        Button AddObjectButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddGroupButton
        /// </summary>
        Button AddGroupButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ListBox4
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ListBox ListBox4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecificInstancesRadioButton
        /// </summary>
        RadioButton SpecificInstancesRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllInstancesRadioButton
        /// </summary>
        RadioButton AllInstancesRadioButton
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
        /// Read-only property to access RuleStaticControl
        /// </summary>
        StaticControl RuleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleTextBox
        /// </summary>
        TextBox RuleTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[starrpar] 1/26/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PerformanceReportSettingsDialog : Dialog, IPerformanceReportSettingsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ListPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedListPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to ListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedListStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to NewSeriesButton of type Button
        /// </summary>
        private Button cachedNewSeriesButton;
        
        /// <summary>
        /// Cache to hold a reference to NewChartButton of type Button
        /// </summary>
        private Button cachedNewChartButton;
        
        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to Button2 of type Button
        /// </summary>
        private Button cachedButton2;
        
        /// <summary>
        /// Cache to hold a reference to Button3 of type Button
        /// </summary>
        private Button cachedButton3;
        
        /// <summary>
        /// Cache to hold a reference to ColorComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedColorComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ColorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedColorStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScaleComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedScaleComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ScaleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScaleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StyleComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedStyleComboBox;
        
        /// <summary>
        /// Cache to hold a reference to StyleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStyleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChartTitleTextBox of type TextBox
        /// </summary>
        private TextBox cachedChartTitleTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ChartTitleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChartTitleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedObjectsPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton2 of type Button
        /// </summary>
        private Button cachedRemoveButton2;
        
        /// <summary>
        /// Cache to hold a reference to AddObjectButton of type Button
        /// </summary>
        private Button cachedAddObjectButton;
        
        /// <summary>
        /// Cache to hold a reference to AddGroupButton of type Button
        /// </summary>
        private Button cachedAddGroupButton;
        
        /// <summary>
        /// Cache to hold a reference to ListBox4 of type ListBox
        /// </summary>
        private ListBox cachedListBox4;
        
        /// <summary>
        /// Cache to hold a reference to SpecificInstancesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSpecificInstancesRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AllInstancesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllInstancesRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to RuleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RuleTextBox of type TextBox
        /// </summary>
        private TextBox cachedRuleTextBox;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceReportSettingsDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceReportSettingsDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Details
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Details Details
        {
            get
            {
                if ((this.Controls.SpecificInstancesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Details.SpecificInstances;
                }
                
                if ((this.Controls.AllInstancesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Details.AllInstances;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == Details.SpecificInstances))
                {
                    this.Controls.SpecificInstancesRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Details.AllInstances))
                    {
                        this.Controls.AllInstancesRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IPerformanceReportSettingsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceReportSettingsDialogControls Controls
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
        ///  Routine to set/get the text in control Color
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ColorText
        {
            get
            {
                return this.Controls.ColorComboBox.Text;
            }
            
            set
            {
                this.Controls.ColorComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Scale
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ScaleText
        {
            get
            {
                return this.Controls.ScaleComboBox.Text;
            }
            
            set
            {
                this.Controls.ScaleComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Style
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StyleText
        {
            get
            {
                return this.Controls.StyleComboBox.Text;
            }
            
            set
            {
                this.Controls.StyleComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ChartTitle
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ChartTitleText
        {
            get
            {
                return this.Controls.ChartTitleTextBox.Text;
            }
            
            set
            {
                this.Controls.ChartTitleTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Rule
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RuleText
        {
            get
            {
                return this.Controls.RuleTextBox.Text;
            }
            
            set
            {
                this.Controls.RuleTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ListPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IPerformanceReportSettingsDialogControls.ListPropertyGridView
        {
            get
            {
                if ((this.cachedListPropertyGridView == null))
                {
                    this.cachedListPropertyGridView = new PropertyGridView(this, PerformanceReportSettingsDialog.ControlIDs.ListPropertyGridView);
                }
                
                return this.cachedListPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ListStaticControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceReportSettingsDialogControls.ListStaticControl
        {
            get
            {
                if ((this.cachedListStaticControl == null))
                {
                    this.cachedListStaticControl = new StaticControl(this, PerformanceReportSettingsDialog.ControlIDs.ListStaticControl);
                }
                
                return this.cachedListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, PerformanceReportSettingsDialog.ControlIDs.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewSeriesButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.NewSeriesButton
        {
            get
            {
                if ((this.cachedNewSeriesButton == null))
                {
                    this.cachedNewSeriesButton = new Button(this, PerformanceReportSettingsDialog.ControlIDs.NewSeriesButton);
                }
                
                return this.cachedNewSeriesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewChartButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.NewChartButton
        {
            get
            {
                if ((this.cachedNewChartButton == null))
                {
                    this.cachedNewChartButton = new Button(this, PerformanceReportSettingsDialog.ControlIDs.NewChartButton);
                }
                
                return this.cachedNewChartButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, PerformanceReportSettingsDialog.ControlIDs.Button0);
                }
                
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, PerformanceReportSettingsDialog.ControlIDs.Button1);
                }
                
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button2 control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.Button2
        {
            get
            {
                if ((this.cachedButton2 == null))
                {
                    this.cachedButton2 = new Button(this, PerformanceReportSettingsDialog.ControlIDs.Button2);
                }
                
                return this.cachedButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button3 control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.Button3
        {
            get
            {
                if ((this.cachedButton3 == null))
                {
                    this.cachedButton3 = new Button(this, PerformanceReportSettingsDialog.ControlIDs.Button3);
                }
                
                return this.cachedButton3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ColorComboBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceReportSettingsDialogControls.ColorComboBox
        {
            get
            {
                if ((this.cachedColorComboBox == null))
                {
                    this.cachedColorComboBox = new ComboBox(this, PerformanceReportSettingsDialog.ControlIDs.ColorComboBox);
                }
                
                return this.cachedColorComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ColorStaticControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceReportSettingsDialogControls.ColorStaticControl
        {
            get
            {
                if ((this.cachedColorStaticControl == null))
                {
                    this.cachedColorStaticControl = new StaticControl(this, PerformanceReportSettingsDialog.ControlIDs.ColorStaticControl);
                }
                
                return this.cachedColorStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScaleComboBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceReportSettingsDialogControls.ScaleComboBox
        {
            get
            {
                if ((this.cachedScaleComboBox == null))
                {
                    this.cachedScaleComboBox = new ComboBox(this, PerformanceReportSettingsDialog.ControlIDs.ScaleComboBox);
                }
                
                return this.cachedScaleComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScaleStaticControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceReportSettingsDialogControls.ScaleStaticControl
        {
            get
            {
                if ((this.cachedScaleStaticControl == null))
                {
                    this.cachedScaleStaticControl = new StaticControl(this, PerformanceReportSettingsDialog.ControlIDs.ScaleStaticControl);
                }
                
                return this.cachedScaleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StyleComboBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceReportSettingsDialogControls.StyleComboBox
        {
            get
            {
                if ((this.cachedStyleComboBox == null))
                {
                    this.cachedStyleComboBox = new ComboBox(this, PerformanceReportSettingsDialog.ControlIDs.StyleComboBox);
                }
                
                return this.cachedStyleComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StyleStaticControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceReportSettingsDialogControls.StyleStaticControl
        {
            get
            {
                if ((this.cachedStyleStaticControl == null))
                {
                    this.cachedStyleStaticControl = new StaticControl(this, PerformanceReportSettingsDialog.ControlIDs.StyleStaticControl);
                }
                
                return this.cachedStyleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChartTitleTextBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceReportSettingsDialogControls.ChartTitleTextBox
        {
            get
            {
                if ((this.cachedChartTitleTextBox == null))
                {
                    this.cachedChartTitleTextBox = new TextBox(this, PerformanceReportSettingsDialog.ControlIDs.ChartTitleTextBox);
                }
                
                return this.cachedChartTitleTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChartTitleStaticControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceReportSettingsDialogControls.ChartTitleStaticControl
        {
            get
            {
                if ((this.cachedChartTitleStaticControl == null))
                {
                    this.cachedChartTitleStaticControl = new StaticControl(this, PerformanceReportSettingsDialog.ControlIDs.ChartTitleStaticControl);
                }
                
                return this.cachedChartTitleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceReportSettingsDialogControls.ObjectsStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedObjectsStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedObjectsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IPerformanceReportSettingsDialogControls.ObjectsPropertyGridView
        {
            get
            {
                // The ID for this control (valueList) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedObjectsPropertyGridView == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedObjectsPropertyGridView = new PropertyGridView(wndTemp);
                }
                
                return this.cachedObjectsPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton2 control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.RemoveButton2
        {
            get
            {
                // The ID for this control (removeButton) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRemoveButton2 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedRemoveButton2 = new Button(wndTemp);
                }
                
                return this.cachedRemoveButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddObjectButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.AddObjectButton
        {
            get
            {
                if ((this.cachedAddObjectButton == null))
                {
                    this.cachedAddObjectButton = new Button(this, PerformanceReportSettingsDialog.ControlIDs.AddObjectButton);
                }
                
                return this.cachedAddObjectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddGroupButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.AddGroupButton
        {
            get
            {
                if ((this.cachedAddGroupButton == null))
                {
                    this.cachedAddGroupButton = new Button(this, PerformanceReportSettingsDialog.ControlIDs.AddGroupButton);
                }
                
                return this.cachedAddGroupButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ListBox4 control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IPerformanceReportSettingsDialogControls.ListBox4
        {
            get
            {
                if ((this.cachedListBox4 == null))
                {
                    this.cachedListBox4 = new ListBox(this, PerformanceReportSettingsDialog.ControlIDs.ListBox4);
                }
                
                return this.cachedListBox4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecificInstancesRadioButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPerformanceReportSettingsDialogControls.SpecificInstancesRadioButton
        {
            get
            {
                if ((this.cachedSpecificInstancesRadioButton == null))
                {
                    this.cachedSpecificInstancesRadioButton = new RadioButton(this, PerformanceReportSettingsDialog.ControlIDs.SpecificInstancesRadioButton);
                }
                
                return this.cachedSpecificInstancesRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllInstancesRadioButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPerformanceReportSettingsDialogControls.AllInstancesRadioButton
        {
            get
            {
                if ((this.cachedAllInstancesRadioButton == null))
                {
                    this.cachedAllInstancesRadioButton = new RadioButton(this, PerformanceReportSettingsDialog.ControlIDs.AllInstancesRadioButton);
                }
                
                return this.cachedAllInstancesRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, PerformanceReportSettingsDialog.ControlIDs.BrowseButton);
                }
                
                return this.cachedBrowseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleStaticControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceReportSettingsDialogControls.RuleStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRuleStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedRuleStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedRuleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTextBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceReportSettingsDialogControls.RuleTextBox
        {
            get
            {
                if ((this.cachedRuleTextBox == null))
                {
                    this.cachedRuleTextBox = new TextBox(this, PerformanceReportSettingsDialog.ControlIDs.RuleTextBox);
                }
                
                return this.cachedRuleTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, PerformanceReportSettingsDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceReportSettingsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerformanceReportSettingsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button NewSeries
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNewSeries()
        {
            this.Controls.NewSeriesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button NewChart
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNewChart()
        {
            this.Controls.NewChartButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button2
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton2()
        {
            this.Controls.Button2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button3
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton3()
        {
            this.Controls.Button3.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove2
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove2()
        {
            this.Controls.RemoveButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddObject
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddObject()
        {
            this.Controls.AddObjectButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddGroup
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddGroup()
        {
            this.Controls.AddGroupButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
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
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
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
        /// 	[starrpar] 1/26/2009 Created
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
            private const string ResourceDialogTitle = ";Settings;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlValueEditorDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  List
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceList = ";List;ManagedString;Corgent.Diagramming.CommandResources.dll;Corgent.Diagramming." +
                "CommandResources.Properties.Resources;Command_ListView";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPD" +
                "ownloadInstallResources;Remove";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NewSeries
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNewSeries = ";New Series;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring" +
                ".ReportPerformanceChartValueList;addButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NewChart
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNewChart = ";New Chart;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring." +
                "ReportPerformanceChartValueList;addChartButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Color
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceColor = ";Color;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.Repo" +
                "rtPerformanceChartValueDetail;colorLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Scale
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScale = ";Scale;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.Repo" +
                "rtPerformanceChartValueDetail;scaleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Style
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStyle = ";Style;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.Repo" +
                "rtPerformanceChartValueDetail;typeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChartTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChartTitle = ";Chart title;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitorin" +
                "g.ReportPerformanceChartValueDetail;chartTitleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Objects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjects = ";Objects;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesigner" +
                "Control;paneTitleHeaderControlObjectPicker.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove2 = ";Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPD" +
                "ownloadInstallResources;Remove";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddObject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddObject = ";Add Object...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitor" +
                "ing.ReportMonitoringObjectGrid;addObjectButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddGroup = ";Add Group...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitori" +
                "ng.ReportMonitoringObjectGrid;AddGroupButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecificInstances
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecificInstances = ";Specific instances;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Mo" +
                "nitoring.ReportPerformanceRuleInstanceSelector;selectedInstancesButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllInstances
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllInstances = ";All instances;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitor" +
                "ing.ReportPerformanceRuleInstanceSelector;allInstancesButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowse = ";Browse...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring." +
                "ReportPerformanceRuleSelector;browseButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRule = ";Rule;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;RuleType";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
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
            /// Caches the translated resource string for:  List
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedList;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NewSeries
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNewSeries;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NewChart
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNewChart;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Color
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedColor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Scale
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScale;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Style
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStyle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChartTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChartTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Objects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddObject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddObject;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecificInstances
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecificInstances;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllInstances
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllInstances;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowse;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Rule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
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
            /// Exposes access to the List translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string List
            {
                get
                {
                    if ((cachedList == null))
                    {
                        cachedList = CoreManager.MomConsole.GetIntlStr(ResourceList);
                    }
                    
                    return cachedList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    
                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewSeries translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NewSeries
            {
                get
                {
                    if ((cachedNewSeries == null))
                    {
                        cachedNewSeries = CoreManager.MomConsole.GetIntlStr(ResourceNewSeries);
                    }
                    
                    return cachedNewSeries;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewChart translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NewChart
            {
                get
                {
                    if ((cachedNewChart == null))
                    {
                        cachedNewChart = CoreManager.MomConsole.GetIntlStr(ResourceNewChart);
                    }
                    
                    return cachedNewChart;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Color translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Color
            {
                get
                {
                    if ((cachedColor == null))
                    {
                        cachedColor = CoreManager.MomConsole.GetIntlStr(ResourceColor);
                    }
                    
                    return cachedColor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Scale translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Scale
            {
                get
                {
                    if ((cachedScale == null))
                    {
                        cachedScale = CoreManager.MomConsole.GetIntlStr(ResourceScale);
                    }
                    
                    return cachedScale;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Style translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Style
            {
                get
                {
                    if ((cachedStyle == null))
                    {
                        cachedStyle = CoreManager.MomConsole.GetIntlStr(ResourceStyle);
                    }
                    
                    return cachedStyle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChartTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChartTitle
            {
                get
                {
                    if ((cachedChartTitle == null))
                    {
                        cachedChartTitle = CoreManager.MomConsole.GetIntlStr(ResourceChartTitle);
                    }
                    
                    return cachedChartTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Objects translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Objects
            {
                get
                {
                    if ((cachedObjects == null))
                    {
                        cachedObjects = CoreManager.MomConsole.GetIntlStr(ResourceObjects);
                    }
                    
                    return cachedObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove2 translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove2
            {
                get
                {
                    if ((cachedRemove2 == null))
                    {
                        cachedRemove2 = CoreManager.MomConsole.GetIntlStr(ResourceRemove2);
                    }
                    
                    return cachedRemove2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddObject translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddObject
            {
                get
                {
                    if ((cachedAddObject == null))
                    {
                        cachedAddObject = CoreManager.MomConsole.GetIntlStr(ResourceAddObject);
                    }
                    
                    return cachedAddObject;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddGroup
            {
                get
                {
                    if ((cachedAddGroup == null))
                    {
                        cachedAddGroup = CoreManager.MomConsole.GetIntlStr(ResourceAddGroup);
                    }
                    
                    return cachedAddGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecificInstances translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecificInstances
            {
                get
                {
                    if ((cachedSpecificInstances == null))
                    {
                        cachedSpecificInstances = CoreManager.MomConsole.GetIntlStr(ResourceSpecificInstances);
                    }
                    
                    return cachedSpecificInstances;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllInstances translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
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
            /// Exposes access to the Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
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
            /// Exposes access to the Rule translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Rule
            {
                get
                {
                    if ((cachedRule == null))
                    {
                        cachedRule = CoreManager.MomConsole.GetIntlStr(ResourceRule);
                    }
                    
                    return cachedRule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ListPropertyGridView
            /// </summary>
            public const string ListPropertyGridView = "valueList";
            
            /// <summary>
            /// Control ID for ListStaticControl
            /// </summary>
            public const string ListStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for NewSeriesButton
            /// </summary>
            public const string NewSeriesButton = "addButton";
            
            /// <summary>
            /// Control ID for NewChartButton
            /// </summary>
            public const string NewChartButton = "addChartButton";
            
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "upButton";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "bottomButton";
            
            /// <summary>
            /// Control ID for Button2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button2 = "topButton";
            
            /// <summary>
            /// Control ID for Button3
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button3 = "downButton";
            
            /// <summary>
            /// Control ID for ColorComboBox
            /// </summary>
            public const string ColorComboBox = "colorSelector";
            
            /// <summary>
            /// Control ID for ColorStaticControl
            /// </summary>
            public const string ColorStaticControl = "colorLabel";
            
            /// <summary>
            /// Control ID for ScaleComboBox
            /// </summary>
            public const string ScaleComboBox = "scaleEditor";
            
            /// <summary>
            /// Control ID for ScaleStaticControl
            /// </summary>
            public const string ScaleStaticControl = "scaleLabel";
            
            /// <summary>
            /// Control ID for StyleComboBox
            /// </summary>
            public const string StyleComboBox = "styleSelector";
            
            /// <summary>
            /// Control ID for StyleStaticControl
            /// </summary>
            public const string StyleStaticControl = "typeLabel";
            
            /// <summary>
            /// Control ID for ChartTitleTextBox
            /// </summary>
            public const string ChartTitleTextBox = "chartTitleEditor";
            
            /// <summary>
            /// Control ID for ChartTitleStaticControl
            /// </summary>
            public const string ChartTitleStaticControl = "chartTitleLabel";
            
            /// <summary>
            /// Control ID for ObjectsStaticControl
            /// </summary>
            public const string ObjectsStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for ObjectsPropertyGridView
            /// </summary>
            public const string ObjectsPropertyGridView = "valueList";
            
            /// <summary>
            /// Control ID for RemoveButton2
            /// </summary>
            public const string RemoveButton2 = "removeButton";
            
            /// <summary>
            /// Control ID for AddObjectButton
            /// </summary>
            public const string AddObjectButton = "addObjectButton";
            
            /// <summary>
            /// Control ID for AddGroupButton
            /// </summary>
            public const string AddGroupButton = "AddGroupButton";
            
            /// <summary>
            /// Control ID for ListBox4
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ListBox4 = "instanceList";
            
            /// <summary>
            /// Control ID for SpecificInstancesRadioButton
            /// </summary>
            public const string SpecificInstancesRadioButton = "selectedInstancesButton";
            
            /// <summary>
            /// Control ID for AllInstancesRadioButton
            /// </summary>
            public const string AllInstancesRadioButton = "allInstancesButton";
            
            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "browseButton";
            
            /// <summary>
            /// Control ID for RuleStaticControl
            /// </summary>
            public const string RuleStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for RuleTextBox
            /// </summary>
            public const string RuleTextBox = "valueEditor";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
        }
        #endregion
    }
}
