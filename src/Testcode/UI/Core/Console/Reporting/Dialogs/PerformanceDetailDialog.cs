// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceDetailDialog.cs">
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
    
    #region Interface Definition - IPerformanceDetailDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceDetailDialogControls, for PerformanceDetailDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 7/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceDetailDialogControls
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
        /// Read-only property to access Button43
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button43
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button44
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button44
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button45
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button45
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button46
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button46
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
        /// Read-only property to access DataAggregationComboBox2
        /// </summary>
        ComboBox DataAggregationComboBox2
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
        /// Read-only property to access TimeZoneStatusBar
        /// </summary>
        StatusBar TimeZoneStatusBar
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
        /// Read-only property to access TextBox47
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox47
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
    public class PerformanceDetailDialog : Dialog, IPerformanceDetailDialogControls
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
        /// Cache to hold a reference to Button43 of type Button
        /// </summary>
        private Button cachedButton43;
        
        /// <summary>
        /// Cache to hold a reference to Button44 of type Button
        /// </summary>
        private Button cachedButton44;
        
        /// <summary>
        /// Cache to hold a reference to Button45 of type Button
        /// </summary>
        private Button cachedButton45;
        
        /// <summary>
        /// Cache to hold a reference to Button46 of type Button
        /// </summary>
        private Button cachedButton46;
        
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
        /// Cache to hold a reference to DataAggregationComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedDataAggregationComboBox2;
        
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
        /// Cache to hold a reference to TimeZoneStatusBar of type StatusBar
        /// </summary>
        private StatusBar cachedTimeZoneStatusBar;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedObjectsToolbar;
        
        /// <summary>
        /// Cache to hold a reference to TextBox47 of type TextBox
        /// </summary>
        private TextBox cachedTextBox47;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceDetailDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceDetailDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IPerformanceDetailDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceDetailDialogControls Controls
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
        ///  Routine to set/get the text in control DataAggregation2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DataAggregation2Text
        {
            get
            {
                return this.Controls.DataAggregationComboBox2.Text;
            }
            
            set
            {
                this.Controls.DataAggregationComboBox2.SelectByText(value, true);
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
        ///  Routine to set/get the text in control TextBox47
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox47Text
        {
            get
            {
                return this.Controls.TextBox47.Text;
            }
            
            set
            {
                this.Controls.TextBox47.Text = value;
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
        StaticControl IPerformanceDetailDialogControls.DataAggregationStaticControl
        {
            get
            {
                if ((this.cachedDataAggregationStaticControl == null))
                {
                    this.cachedDataAggregationStaticControl = new StaticControl(this, PerformanceDetailDialog.ControlIDs.DataAggregationStaticControl);
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
        ComboBox IPerformanceDetailDialogControls.FromComboBox
        {
            get
            {
                if ((this.cachedFromComboBox == null))
                {
                    this.cachedFromComboBox = new ComboBox(this, PerformanceDetailDialog.ControlIDs.FromComboBox);
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
        PropertyGridView IPerformanceDetailDialogControls.DataAggregationPropertyGridView
        {
            get
            {
                if ((this.cachedDataAggregationPropertyGridView == null))
                {
                    this.cachedDataAggregationPropertyGridView = new PropertyGridView(this, PerformanceDetailDialog.ControlIDs.DataAggregationPropertyGridView);
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
        StaticControl IPerformanceDetailDialogControls.ObjectsStaticControl
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
        Button IPerformanceDetailDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, PerformanceDetailDialog.ControlIDs.RemoveButton);
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
        Button IPerformanceDetailDialogControls.ChangeButton
        {
            get
            {
                if ((this.cachedChangeButton == null))
                {
                    this.cachedChangeButton = new Button(this, PerformanceDetailDialog.ControlIDs.ChangeButton);
                }
                return this.cachedChangeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button43 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDetailDialogControls.Button43
        {
            get
            {
                if ((this.cachedButton43 == null))
                {
                    this.cachedButton43 = new Button(this, PerformanceDetailDialog.ControlIDs.Button43);
                }
                return this.cachedButton43;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button44 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDetailDialogControls.Button44
        {
            get
            {
                if ((this.cachedButton44 == null))
                {
                    this.cachedButton44 = new Button(this, PerformanceDetailDialog.ControlIDs.Button44);
                }
                return this.cachedButton44;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button45 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDetailDialogControls.Button45
        {
            get
            {
                if ((this.cachedButton45 == null))
                {
                    this.cachedButton45 = new Button(this, PerformanceDetailDialog.ControlIDs.Button45);
                }
                return this.cachedButton45;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button46 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDetailDialogControls.Button46
        {
            get
            {
                if ((this.cachedButton46 == null))
                {
                    this.cachedButton46 = new Button(this, PerformanceDetailDialog.ControlIDs.Button46);
                }
                return this.cachedButton46;
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
        StaticControl IPerformanceDetailDialogControls._800AMTo500PMMonTueWedThuFriStaticControl
        {
            get
            {
                if ((this.cached_800AMTo500PMMonTueWedThuFriStaticControl == null))
                {
                    this.cached_800AMTo500PMMonTueWedThuFriStaticControl = new StaticControl(this, PerformanceDetailDialog.ControlIDs._800AMTo500PMMonTueWedThuFriStaticControl);
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
        CheckBox IPerformanceDetailDialogControls.UseBusinessHoursCheckBox
        {
            get
            {
                if ((this.cachedUseBusinessHoursCheckBox == null))
                {
                    this.cachedUseBusinessHoursCheckBox = new CheckBox(this, PerformanceDetailDialog.ControlIDs.UseBusinessHoursCheckBox);
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
        Button IPerformanceDetailDialogControls.BusinessHoursButton
        {
            get
            {
                if ((this.cachedBusinessHoursButton == null))
                {
                    this.cachedBusinessHoursButton = new Button(this, PerformanceDetailDialog.ControlIDs.BusinessHoursButton);
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
        ComboBox IPerformanceDetailDialogControls.FromComboBox2
        {
            get
            {
                if ((this.cachedFromComboBox2 == null))
                {
                    this.cachedFromComboBox2 = new ComboBox(this, PerformanceDetailDialog.ControlIDs.FromComboBox2);
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
        StaticControl IPerformanceDetailDialogControls.TimeZoneStaticControl
        {
            get
            {
                if ((this.cachedTimeZoneStaticControl == null))
                {
                    this.cachedTimeZoneStaticControl = new StaticControl(this, PerformanceDetailDialog.ControlIDs.TimeZoneStaticControl);
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
        ComboBox IPerformanceDetailDialogControls.DataAggregationComboBox
        {
            get
            {
                if ((this.cachedDataAggregationComboBox == null))
                {
                    this.cachedDataAggregationComboBox = new ComboBox(this, PerformanceDetailDialog.ControlIDs.DataAggregationComboBox);
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
        Spinner IPerformanceDetailDialogControls.DataAggregationSpinner
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
        ComboBox IPerformanceDetailDialogControls.ToComboBox
        {
            get
            {
                if ((this.cachedToComboBox == null))
                {
                    this.cachedToComboBox = new ComboBox(this, PerformanceDetailDialog.ControlIDs.ToComboBox);
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
        Spinner IPerformanceDetailDialogControls.ToSpinner
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
        ComboBox IPerformanceDetailDialogControls.ToComboBox2
        {
            get
            {
                if ((this.cachedToComboBox2 == null))
                {
                    this.cachedToComboBox2 = new ComboBox(this, PerformanceDetailDialog.ControlIDs.ToComboBox2);
                }
                return this.cachedToComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationComboBox2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDetailDialogControls.DataAggregationComboBox2
        {
            get
            {
                if ((this.cachedDataAggregationComboBox2 == null))
                {
                    this.cachedDataAggregationComboBox2 = new ComboBox(this, PerformanceDetailDialog.ControlIDs.DataAggregationComboBox2);
                }
                return this.cachedDataAggregationComboBox2;
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
        StaticControl IPerformanceDetailDialogControls.FromStaticControl
        {
            get
            {
                if ((this.cachedFromStaticControl == null))
                {
                    this.cachedFromStaticControl = new StaticControl(this, PerformanceDetailDialog.ControlIDs.FromStaticControl);
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
        StaticControl IPerformanceDetailDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, PerformanceDetailDialog.ControlIDs.ToStaticControl);
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
        StaticControl IPerformanceDetailDialogControls.HistogramStaticControl
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
        ComboBox IPerformanceDetailDialogControls.TimeZoneComboBox
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
        ///  Exposes access to the TimeZoneStatusBar control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IPerformanceDetailDialogControls.TimeZoneStatusBar
        {
            get
            {
                if ((this.cachedTimeZoneStatusBar == null))
                {
                    this.cachedTimeZoneStatusBar = new StatusBar(this, PerformanceDetailDialog.ControlIDs.TimeZoneStatusBar);
                }
                return this.cachedTimeZoneStatusBar;
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
        Toolbar IPerformanceDetailDialogControls.ObjectsToolbar
        {
            get
            {
                if ((this.cachedObjectsToolbar == null))
                {
                    this.cachedObjectsToolbar = new Toolbar(this, PerformanceDetailDialog.ControlIDs.ObjectsToolbar);
                }
                return this.cachedObjectsToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox47 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceDetailDialogControls.TextBox47
        {
            get
            {
                if ((this.cachedTextBox47 == null))
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
                    this.cachedTextBox47 = new TextBox(wndTemp);
                }
                return this.cachedTextBox47;
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
        ///  Routine to click on button Button43
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton43()
        {
            this.Controls.Button43.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button44
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton44()
        {
            this.Controls.Button44.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button45
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton45()
        {
            this.Controls.Button45.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button46
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton46()
        {
            this.Controls.Button46.Click();
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
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                //// check for success
                //if ((null == tempWindow))
                //{
                //    // log the failure

                //    // rethrow the original exception
                //    throw windowNotFound;
                //}
            }
            return tempWindow;
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
            private const string ResourceDialogTitle = "Performance Detail - System Center Operations Manager 2007 - Report - hornet245d";
            
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
                    // Replace {2} with the report name: Availability

                    // Check if ReportDisplayName is not null
                    if (Reporting.ReportDisplayName == null)
                    {
                        throw new Maui.GlobalExceptions.MauiException("Exception in getting Dialog Title for PerformanceDetail Dialog! Cannot use ReportDisplayName as it is null!");
                    }

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
            public const string FromComboBox = "valueEditor";
            
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
            /// Control ID for Button43
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button43 = "upButton";
            
            /// <summary>
            /// Control ID for Button44
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button44 = "bottomButton";
            
            /// <summary>
            /// Control ID for Button45
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button45 = "topButton";
            
            /// <summary>
            /// Control ID for Button46
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button46 = "downButton";
            
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
            public const string FromComboBox2 = "timeZoneSelector";
            
            /// <summary>
            /// Control ID for TimeZoneStaticControl
            /// </summary>
            public const string TimeZoneStaticControl = "timeZoneLabel";
            
            /// <summary>
            /// Control ID for DataAggregationComboBox
            /// </summary>
            public const string DataAggregationComboBox = "endTimeEditor";
            
            /// <summary>
            /// Control ID for ToComboBox
            /// </summary>
            public const string ToComboBox = "startTimeEditor";
            
            /// <summary>
            /// Control ID for ToComboBox2
            /// </summary>
            public const string ToComboBox2 = "startDateEditor";
            
            /// <summary>
            /// Control ID for DataAggregationComboBox2
            /// </summary>
            public const string DataAggregationComboBox2 = "endDateEditor";
            
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
            public const string TimeZoneComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for TimeZoneStatusBar
            /// </summary>
            public const string TimeZoneStatusBar = "consoleStatusBar";
            
            /// <summary>
            /// Control ID for ObjectsToolbar
            /// </summary>
            public const string ObjectsToolbar = "toolBar";
        }
        #endregion
    }
}
