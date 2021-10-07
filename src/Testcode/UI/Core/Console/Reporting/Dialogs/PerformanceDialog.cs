// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[a-omkasi] 7/24/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IPerformanceDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceDialogControls, for PerformanceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 7/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceDialogControls
    {
        /// <summary>
        /// Read-only property to access DataAggregationStaticControl
        /// </summary>
        StaticControl DataAggregationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromComboBox
        /// </summary>
        ComboBox FromComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataAggregationPropertyGridView
        /// </summary>
        PropertyGridView DataAggregationPropertyGridView
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
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChangeButton
        /// </summary>
        Button ChangeButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button37
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button37
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button38
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button38
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button39
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button39
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button40
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button40
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _800AMTo500PMMonTueWedThuFriStaticControl
        /// </summary>
        StaticControl _800AMTo500PMMonTueWedThuFriStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseBusinessHoursCheckBox
        /// </summary>
        CheckBox UseBusinessHoursCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BusinessHoursButton
        /// </summary>
        Button BusinessHoursButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromComboBox2
        /// </summary>
        ComboBox FromComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeZoneStaticControl
        /// </summary>
        StaticControl TimeZoneStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataAggregationComboBox
        /// </summary>
        ComboBox DataAggregationComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataAggregationSpinner
        /// </summary>
        Spinner DataAggregationSpinner
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToComboBox
        /// </summary>
        ComboBox ToComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToSpinner
        /// </summary>
        Spinner ToSpinner
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToComboBox2
        /// </summary>
        ComboBox ToComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromStaticControl
        /// </summary>
        StaticControl FromStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToStaticControl
        /// </summary>
        StaticControl ToStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HistogramStaticControl
        /// </summary>
        StaticControl HistogramStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeZoneComboBox
        /// </summary>
        ComboBox TimeZoneComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _3DChartStaticControl
        /// </summary>
        StaticControl _3DChartStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StatusBar41
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StatusBar StatusBar41
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsToolbar
        /// </summary>
        Toolbar ObjectsToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox42
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox42
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
    /// 	[a-omkasi] 7/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PerformanceDialog : Dialog, IPerformanceDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to DataAggregationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDataAggregationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FromComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedFromComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DataAggregationPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataAggregationPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to ChangeButton of type Button
        /// </summary>
        private Button cachedChangeButton;
        
        /// <summary>
        /// Cache to hold a reference to Button37 of type Button
        /// </summary>
        private Button cachedButton37;
        
        /// <summary>
        /// Cache to hold a reference to Button38 of type Button
        /// </summary>
        private Button cachedButton38;
        
        /// <summary>
        /// Cache to hold a reference to Button39 of type Button
        /// </summary>
        private Button cachedButton39;
        
        /// <summary>
        /// Cache to hold a reference to Button40 of type Button
        /// </summary>
        private Button cachedButton40;
        
        /// <summary>
        /// Cache to hold a reference to _800AMTo500PMMonTueWedThuFriStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_800AMTo500PMMonTueWedThuFriStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseBusinessHoursCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUseBusinessHoursCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to BusinessHoursButton of type Button
        /// </summary>
        private Button cachedBusinessHoursButton;
        
        /// <summary>
        /// Cache to hold a reference to FromComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedFromComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to TimeZoneStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTimeZoneStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DataAggregationComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDataAggregationComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DataAggregationSpinner of type Spinner
        /// </summary>
        private Spinner cachedDataAggregationSpinner;
        
        /// <summary>
        /// Cache to hold a reference to ToComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedToComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ToSpinner of type Spinner
        /// </summary>
        private Spinner cachedToSpinner;
        
        /// <summary>
        /// Cache to hold a reference to ToComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedToComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to FromStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFromStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HistogramStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHistogramStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TimeZoneComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimeZoneComboBox;
        
        /// <summary>
        /// Cache to hold a reference to _3DChartStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_3DChartStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StatusBar41 of type StatusBar
        /// </summary>
        private StatusBar cachedStatusBar41;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedObjectsToolbar;
        
        /// <summary>
        /// Cache to hold a reference to TextBox42 of type TextBox
        /// </summary>
        private TextBox cachedTextBox42;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IPerformanceDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceDialogControls Controls
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
        ///  Property to handle checkbox UseBusinessHours
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UseBusinessHours
        {
            get
            {
                return this.Controls.UseBusinessHoursCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UseBusinessHoursCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control From
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FromText
        {
            get
            {
                return this.Controls.FromComboBox.Text;
            }
            
            set
            {
                this.Controls.FromComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control From2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string From2Text
        {
            get
            {
                return this.Controls.FromComboBox2.Text;
            }
            
            set
            {
                this.Controls.FromComboBox2.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DataAggregation
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DataAggregationText
        {
            get
            {
                return this.Controls.DataAggregationComboBox.Text;
            }
            
            set
            {
                this.Controls.DataAggregationComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control To
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ToText
        {
            get
            {
                return this.Controls.ToComboBox.Text;
            }
            
            set
            {
                this.Controls.ToComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control To2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string To2Text
        {
            get
            {
                return this.Controls.ToComboBox2.Text;
            }
            
            set
            {
                this.Controls.ToComboBox2.SelectByText(value, true);
            }
        }
        
       
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TimeZone
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeZoneText
        {
            get
            {
                return this.Controls.TimeZoneComboBox.Text;
            }
            
            set
            {
                this.Controls.TimeZoneComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox42
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox42Text
        {
            get
            {
                return this.Controls.TextBox42.Text;
            }
            
            set
            {
                this.Controls.TextBox42.Text = value;
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceDialogControls.DataAggregationStaticControl
        {
            get
            {
                if ((this.cachedDataAggregationStaticControl == null))
                {
                    this.cachedDataAggregationStaticControl = new StaticControl(this, PerformanceDialog.ControlIDs.DataAggregationStaticControl);
                }
                return this.cachedDataAggregationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDialogControls.FromComboBox
        {
            get
            {
                if ((this.cachedFromComboBox == null))
                {
                    this.cachedFromComboBox = new ComboBox(this, PerformanceDialog.ControlIDs.FromComboBox);
                }
                return this.cachedFromComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IPerformanceDialogControls.DataAggregationPropertyGridView
        {
            get
            {
                if ((this.cachedDataAggregationPropertyGridView == null))
                {
                    this.cachedDataAggregationPropertyGridView = new PropertyGridView(this, PerformanceDialog.ControlIDs.DataAggregationPropertyGridView);
                }
                return this.cachedDataAggregationPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceDialogControls.ObjectsStaticControl
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedObjectsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, PerformanceDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChangeButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDialogControls.ChangeButton
        {
            get
            {
                if ((this.cachedChangeButton == null))
                {
                    this.cachedChangeButton = new Button(this, PerformanceDialog.ControlIDs.ChangeButton);
                }
                return this.cachedChangeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button37 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDialogControls.Button37
        {
            get
            {
                if ((this.cachedButton37 == null))
                {
                    this.cachedButton37 = new Button(this, PerformanceDialog.ControlIDs.Button37);
                }
                return this.cachedButton37;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button38 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDialogControls.Button38
        {
            get
            {
                if ((this.cachedButton38 == null))
                {
                    this.cachedButton38 = new Button(this, PerformanceDialog.ControlIDs.Button38);
                }
                return this.cachedButton38;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button39 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDialogControls.Button39
        {
            get
            {
                if ((this.cachedButton39 == null))
                {
                    this.cachedButton39 = new Button(this, PerformanceDialog.ControlIDs.Button39);
                }
                return this.cachedButton39;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button40 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDialogControls.Button40
        {
            get
            {
                if ((this.cachedButton40 == null))
                {
                    this.cachedButton40 = new Button(this, PerformanceDialog.ControlIDs.Button40);
                }
                return this.cachedButton40;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _800AMTo500PMMonTueWedThuFriStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceDialogControls._800AMTo500PMMonTueWedThuFriStaticControl
        {
            get
            {
                if ((this.cached_800AMTo500PMMonTueWedThuFriStaticControl == null))
                {
                    this.cached_800AMTo500PMMonTueWedThuFriStaticControl = new StaticControl(this, PerformanceDialog.ControlIDs._800AMTo500PMMonTueWedThuFriStaticControl);
                }
                return this.cached_800AMTo500PMMonTueWedThuFriStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseBusinessHoursCheckBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceDialogControls.UseBusinessHoursCheckBox
        {
            get
            {
                if ((this.cachedUseBusinessHoursCheckBox == null))
                {
                    this.cachedUseBusinessHoursCheckBox = new CheckBox(this, PerformanceDialog.ControlIDs.UseBusinessHoursCheckBox);
                }
                return this.cachedUseBusinessHoursCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessHoursButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDialogControls.BusinessHoursButton
        {
            get
            {
                if ((this.cachedBusinessHoursButton == null))
                {
                    this.cachedBusinessHoursButton = new Button(this, PerformanceDialog.ControlIDs.BusinessHoursButton);
                }
                return this.cachedBusinessHoursButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromComboBox2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDialogControls.FromComboBox2
        {
            get
            {
                if ((this.cachedFromComboBox2 == null))
                {
                    this.cachedFromComboBox2 = new ComboBox(this, PerformanceDialog.ControlIDs.FromComboBox2);
                }
                return this.cachedFromComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceDialogControls.TimeZoneStaticControl
        {
            get
            {
                if ((this.cachedTimeZoneStaticControl == null))
                {
                    this.cachedTimeZoneStaticControl = new StaticControl(this, PerformanceDialog.ControlIDs.TimeZoneStaticControl);
                }
                return this.cachedTimeZoneStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDialogControls.DataAggregationComboBox
        {
            get
            {
                if ((this.cachedDataAggregationComboBox == null))
                {
                    this.cachedDataAggregationComboBox = new ComboBox(this, PerformanceDialog.ControlIDs.DataAggregationComboBox);
                }
                return this.cachedDataAggregationComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationSpinner control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IPerformanceDialogControls.DataAggregationSpinner
        {
            get
            {
                if ((this.cachedDataAggregationSpinner == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDataAggregationSpinner = new Spinner(wndTemp);
                }
                return this.cachedDataAggregationSpinner;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDialogControls.ToComboBox
        {
            get
            {
                if ((this.cachedToComboBox == null))
                {
                    this.cachedToComboBox = new ComboBox(this, PerformanceDialog.ControlIDs.ToComboBox);
                }
                return this.cachedToComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToSpinner control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IPerformanceDialogControls.ToSpinner
        {
            get
            {
                if ((this.cachedToSpinner == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedToSpinner = new Spinner(wndTemp);
                }
                return this.cachedToSpinner;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToComboBox2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDialogControls.ToComboBox2
        {
            get
            {
                if ((this.cachedToComboBox2 == null))
                {
                    this.cachedToComboBox2 = new ComboBox(this, PerformanceDialog.ControlIDs.ToComboBox2);
                }
                return this.cachedToComboBox2;
            }
        }
        
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceDialogControls.FromStaticControl
        {
            get
            {
                if ((this.cachedFromStaticControl == null))
                {
                    this.cachedFromStaticControl = new StaticControl(this, PerformanceDialog.ControlIDs.FromStaticControl);
                }
                return this.cachedFromStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, PerformanceDialog.ControlIDs.ToStaticControl);
                }
                return this.cachedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HistogramStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceDialogControls.HistogramStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedHistogramStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedHistogramStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedHistogramStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDialogControls.TimeZoneComboBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTimeZoneComboBox == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedTimeZoneComboBox = new ComboBox(wndTemp);
                }
                return this.cachedTimeZoneComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _3DChartStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceDialogControls._3DChartStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cached_3DChartStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cached_3DChartStaticControl = new StaticControl(wndTemp);
                }
                return this.cached_3DChartStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusBar41 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IPerformanceDialogControls.StatusBar41
        {
            get
            {
                if ((this.cachedStatusBar41 == null))
                {
                    this.cachedStatusBar41 = new StatusBar(this, PerformanceDialog.ControlIDs.StatusBar41);
                }
                return this.cachedStatusBar41;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsToolbar control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IPerformanceDialogControls.ObjectsToolbar
        {
            get
            {
                if ((this.cachedObjectsToolbar == null))
                {
                    this.cachedObjectsToolbar = new Toolbar(this);
                }
                return this.cachedObjectsToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox42 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceDialogControls.TextBox42
        {
            get
            {
                if ((this.cachedTextBox42 == null))
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
                    this.cachedTextBox42 = new TextBox(wndTemp);
                }
                return this.cachedTextBox42;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Change
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickChange()
        {
            this.Controls.ChangeButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button37
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton37()
        {
            this.Controls.Button37.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button38
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton38()
        {
            this.Controls.Button38.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button39
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton39()
        {
            this.Controls.Button39.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button40
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton40()
        {
            this.Controls.Button40.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UseBusinessHours
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUseBusinessHours()
        {
            this.Controls.UseBusinessHoursCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button BusinessHours
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBusinessHours()
        {
            this.Controls.BusinessHoursButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);

                if (tempWindow != null)
                {
                    Utilities.LogMessage("PerformanceDialog.Init :: Trying to get change button.");
                    Button changeButton = new Button(tempWindow, ControlIDs.ChangeButton);
                    Utilities.LogMessage("PerformanceDialog.Init :: Get change button finished.");
                    if (changeButton == null || !changeButton.IsEnabled)
                    {
                        Utilities.LogMessage("PerformanceDialog.Init :: Change button is null or disabled.");
                        throw new Window.Exceptions.WindowNotFoundException("Change button is not available, will retry.");
                    }
                }
            }
            catch (Exceptions.WindowNotFoundException )
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 15;

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

                        if (tempWindow != null)
                        {
                            Utilities.LogMessage("PerformanceDialog.Init :: Trying to get change button.");
                            Button changeButton = new Button(tempWindow, ControlIDs.ChangeButton);
                            Utilities.LogMessage("PerformanceDialog.Init :: Get change button finished.");
                            if (changeButton == null || !changeButton.IsEnabled)
                            {
                                tempWindow = null;
                                Utilities.LogMessage("PerformanceDialog.Init :: Change button is null or disabled.");
                                throw new Window.Exceptions.WindowNotFoundException("Change button is not available, will retry.");
                            }
                        }
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("PerformanceDialog.Init :: Attempt " + (numberOfTries + 1) + " of " + maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
            }
            return tempWindow;
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Method to run a report. it clicks run button on toolbar
        /// </summary>        
        /// <history>
        ///     [v-liqluo] 8/25/2009 Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public bool RunReport()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage("Click Run report" + currentMethod);

            PerformanceDialog PerformanceDialog = new PerformanceDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(PerformanceDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(PerformanceDialog, Constants.OneSecond * 60);
            Utilities.LogMessage("Created object of PerformanceDialog" + currentMethod);

            CoreManager.MomConsole.InvokeToolBarButton(PerformanceDialog.Controls.ObjectsToolbar, Strings.RunMenu);

            UISynchronization.WaitForProcessReady(PerformanceDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(PerformanceDialog, Constants.OneSecond * 60);

            Utilities.LogMessage("Run Report finished successfully : " + currentMethod);
            return true;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
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
            private const string ResourceDialogTitle = ";{2} - {0} - Report - {1};ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Reporting.ReportFormResources;ApplicationTitleTextFormat";
            
             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataAggregation
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataAggregation = "Data Aggregation";
            
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
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.CommandNot" +
                "ification;removeButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Change
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChange = ";Change...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlOb" +
                "jectGrid;editButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _800AMTo500PMMonTueWedThuFri
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_800AMTo500PMMonTueWedThuFri = "8:00 AM to 5:00 PM\r\nMon, Tue, Wed, Thu, Fri";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseBusinessHours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseBusinessHours = ";Use business hours;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Re" +
                "lativeDateTimeBusinessPicker;businessHoursSelector.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BusinessHours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBusinessHours = ";Business hours...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Rel" +
                "ativeDateTimeBusinessPicker;configureBusinessHoursButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TimeZone
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeZone = ";Time Zone;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.TimeZonePic" +
                "ker;timeZoneLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  From
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFrom = ";From;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.RelativeDateTime" +
                "Picker;startDateLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTo = ";To;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.RelativeDateTimePi" +
                "cker;endDateLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Histogram
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceHistogram = "Histogram";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _3DChart
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_3DChart = "3D Chart";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Run
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunMenu = ";Run;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ReportForm;runToolStripButton.Text";
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
            /// Caches the translated resource string for:  DataAggregation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataAggregation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Objects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Change
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChange;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _800AMTo500PMMonTueWedThuFri
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_800AMTo500PMMonTueWedThuFri;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseBusinessHours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseBusinessHours;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BusinessHours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBusinessHours;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TimeZone
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeZone;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  From
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFrom;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Histogram
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHistogram;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _3DChart
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_3DChart;

            /// <summary>
            ///  Catches the translated resource string for: Run
            /// </summary>
            private static string cachedRunMenu;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
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

                    Mom.Test.UI.Core.Common.Utilities.LogMessage("cachedDialogTitle is " + cachedDialogTitle);
                    StringBuilder newDialogTitle = new StringBuilder(cachedDialogTitle);

                    // Check if ReportDisplayName is not null
                    if (Reporting.ReportDisplayName == null)
                    {
                        throw new Maui.GlobalExceptions.MauiException("Exception in getting Dialog Title for Performance Dialog! Cannot use ReportDisplayName as it is null!");
                    }

                    // Replace {2} with the report name: Performance
                    newDialogTitle.Replace("{2}", Reporting.ReportDisplayName);
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Remove 2 cachedDialogTitle is " + newDialogTitle);

                    // Replace {0} with System Center Reporting Manager, or *
                    newDialogTitle.Replace("{0}", "*");
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Remove 0 cachedDialogTitle is " + newDialogTitle);

                    // Replace {1} with the name of the MOM Management Group, or *
                    newDialogTitle.Replace("{1}", "*");
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Remove 1 cachedDialogTitle is " + newDialogTitle);

                    cachedDialogTitle = newDialogTitle.ToString();
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("cachedDialogTitle is " + cachedDialogTitle);
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataAggregation translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataAggregation
            {
                get
                {
                    if ((cachedDataAggregation == null))
                    {
                        cachedDataAggregation = CoreManager.MomConsole.GetIntlStr(ResourceDataAggregation);
                    }
                    return cachedDataAggregation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Objects translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
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
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
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
            /// Exposes access to the Change translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Change
            {
                get
                {
                    if ((cachedChange == null))
                    {
                        cachedChange = CoreManager.MomConsole.GetIntlStr(ResourceChange);
                    }
                    return cachedChange;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _800AMTo500PMMonTueWedThuFri translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _800AMTo500PMMonTueWedThuFri
            {
                get
                {
                    if ((cached_800AMTo500PMMonTueWedThuFri == null))
                    {
                        cached_800AMTo500PMMonTueWedThuFri = CoreManager.MomConsole.GetIntlStr(Resource_800AMTo500PMMonTueWedThuFri);
                    }
                    return cached_800AMTo500PMMonTueWedThuFri;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseBusinessHours translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseBusinessHours
            {
                get
                {
                    if ((cachedUseBusinessHours == null))
                    {
                        cachedUseBusinessHours = CoreManager.MomConsole.GetIntlStr(ResourceUseBusinessHours);
                    }
                    return cachedUseBusinessHours;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BusinessHours translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BusinessHours
            {
                get
                {
                    if ((cachedBusinessHours == null))
                    {
                        cachedBusinessHours = CoreManager.MomConsole.GetIntlStr(ResourceBusinessHours);
                    }
                    return cachedBusinessHours;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TimeZone translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeZone
            {
                get
                {
                    if ((cachedTimeZone == null))
                    {
                        cachedTimeZone = CoreManager.MomConsole.GetIntlStr(ResourceTimeZone);
                    }
                    return cachedTimeZone;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the From translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string From
            {
                get
                {
                    if ((cachedFrom == null))
                    {
                        cachedFrom = CoreManager.MomConsole.GetIntlStr(ResourceFrom);
                    }
                    return cachedFrom;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the To translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string To
            {
                get
                {
                    if ((cachedTo == null))
                    {
                        cachedTo = CoreManager.MomConsole.GetIntlStr(ResourceTo);
                    }
                    return cachedTo;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Histogram translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Histogram
            {
                get
                {
                    if ((cachedHistogram == null))
                    {
                        cachedHistogram = CoreManager.MomConsole.GetIntlStr(ResourceHistogram);
                    }
                    return cachedHistogram;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _3DChart translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _3DChart
            {
                get
                {
                    if ((cached_3DChart == null))
                    {
                        cached_3DChart = CoreManager.MomConsole.GetIntlStr(Resource_3DChart);
                    }
                    return cached_3DChart;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunMenu
            {
                get
                {
                    if ((cachedRunMenu == null))
                    {
                        cachedRunMenu = CoreManager.MomConsole.GetIntlStr(ResourceRunMenu);
                    }

                    return cachedRunMenu;
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
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for DataAggregationStaticControl
            /// </summary>
            public const string DataAggregationStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for FromComboBox
            /// </summary>
            public const string FromComboBox = "startTimeEditor";
            
            /// <summary>
            /// Control ID for DataAggregationPropertyGridView
            /// </summary>
            public const string DataAggregationPropertyGridView = "valueList";
            
            /// <summary>
            /// Control ID for ObjectsStaticControl
            /// </summary>
            public const string ObjectsStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for ChangeButton
            /// </summary>
            public const string ChangeButton = "editButton";
            
            /// <summary>
            /// Control ID for Button37
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button37 = "upButton";
            
            /// <summary>
            /// Control ID for Button38
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button38 = "bottomButton";
            
            /// <summary>
            /// Control ID for Button39
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button39 = "topButton";
            
            /// <summary>
            /// Control ID for Button40
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button40 = "downButton";
            
            /// <summary>
            /// Control ID for _800AMTo500PMMonTueWedThuFriStaticControl
            /// </summary>
            public const string _800AMTo500PMMonTueWedThuFriStaticControl = "businessHoursLabel";
            
            /// <summary>
            /// Control ID for UseBusinessHoursCheckBox
            /// </summary>
            public const string UseBusinessHoursCheckBox = "businessHoursSelector";
            
            /// <summary>
            /// Control ID for BusinessHoursButton
            /// </summary>
            public const string BusinessHoursButton = "configureBusinessHoursButton";
            
            /// <summary>
            /// Control ID for FromComboBox2
            /// </summary>
            public const string FromComboBox2 = "startDateEditor";
            
            /// <summary>
            /// Control ID for TimeZoneStaticControl
            /// </summary>
            public const string TimeZoneStaticControl = "timeZoneLabel";
            
            /// <summary>
            /// Control ID for DataAggregationComboBox
            /// </summary>
            public const string DataAggregationComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for ToComboBox
            /// </summary>
            public const string ToComboBox = "endTimeEditor";
            
            /// <summary>
            /// Control ID for ToComboBox2
            /// </summary>
            public const string ToComboBox2 = "endDateEditor";
            

            
            /// <summary>
            /// Control ID for FromStaticControl
            /// </summary>
            public const string FromStaticControl = "startDateLabel";
            
            /// <summary>
            /// Control ID for ToStaticControl
            /// </summary>
            public const string ToStaticControl = "endDateLabel";
            
            /// <summary>
            /// Control ID for HistogramStaticControl
            /// </summary>
            public const string HistogramStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for TimeZoneComboBox
            /// </summary>
            public const string TimeZoneComboBox = "timeZoneSelector";
            
            /// <summary>
            /// Control ID for _3DChartStaticControl
            /// </summary>
            public const string _3DChartStaticControl = "nameLabel";
          
            /// <summary>
            /// Control ID for StatusBar41
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StatusBar41 = "consoleStatusBar";
            
            /// <summary>
            /// Control ID for ObjectsToolbar
            /// </summary>
            public const string ObjectsToolbar = "toolBar";

        }
        #endregion
    }
}
