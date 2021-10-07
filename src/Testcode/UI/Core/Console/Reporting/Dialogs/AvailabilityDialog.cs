// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AvailabilityDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[a-omkasi] 7/7/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System.Text;
    using Mom.Test.UI.Core.Console.Reporting;
    
    #region Interface Definition - IAvailabilityDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAvailabilityDialogControls, for AvailabilityDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 7/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAvailabilityDialogControls
    {
        /// <summary>
        /// Read-only property to access DataAggregationStaticControl
        /// </summary>
        StaticControl DataAggregationStaticControl
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
        /// Read-only property to access ObjectsStaticControl
        /// </summary>
        StaticControl ObjectsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _800AMTo500PMMonTueWedThuFriPropertyGridView
        /// </summary>
        PropertyGridView _800AMTo500PMMonTueWedThuFriPropertyGridView
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
        /// Read-only property to access DownTimeStaticControl
        /// </summary>
        StaticControl DownTimeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DownTimeListBox
        /// </summary>
        ListBox DownTimeListBox
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
        /// Read-only property to access TimeZoneComboBox
        /// </summary>
        ComboBox TimeZoneComboBox
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
        /// Read-only property to access FromComboBox
        /// </summary>
        ComboBox FromComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromSpinner
        /// </summary>
        Spinner FromSpinner
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
        /// Read-only property to access _800AMTo500PMMonTueWedThuFriStatusBar
        /// </summary>
        StatusBar _800AMTo500PMMonTueWedThuFriStatusBar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Toolbar2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox3
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
    /// 	[a-omkasi] 7/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AvailabilityDialog : Dialog, IAvailabilityDialogControls
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
        /// Cache to hold a reference to DataAggregationComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDataAggregationComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to _800AMTo500PMMonTueWedThuFriPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cached_800AMTo500PMMonTueWedThuFriPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to AddObjectButton of type Button
        /// </summary>
        private Button cachedAddObjectButton;
        
        /// <summary>
        /// Cache to hold a reference to AddGroupButton of type Button
        /// </summary>
        private Button cachedAddGroupButton;
        
        /// <summary>
        /// Cache to hold a reference to DownTimeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDownTimeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DownTimeListBox of type ListBox
        /// </summary>
        private ListBox cachedDownTimeListBox;
        
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
        /// Cache to hold a reference to TimeZoneComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimeZoneComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TimeZoneStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTimeZoneStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedToComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ToSpinner of type Spinner
        /// </summary>
        private Spinner cachedToSpinner;
        
        /// <summary>
        /// Cache to hold a reference to FromComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedFromComboBox;
        
        /// <summary>
        /// Cache to hold a reference to FromSpinner of type Spinner
        /// </summary>
        private Spinner cachedFromSpinner;
        
        /// <summary>
        /// Cache to hold a reference to FromComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedFromComboBox2;
        
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
        /// Cache to hold a reference to _800AMTo500PMMonTueWedThuFriStatusBar of type StatusBar
        /// </summary>
        private StatusBar cached_800AMTo500PMMonTueWedThuFriStatusBar;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar2 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar2;
        
        /// <summary>
        /// Cache to hold a reference to TextBox3 of type TextBox
        /// </summary>
        private TextBox cachedTextBox3;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AvailabilityDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AvailabilityDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAvailabilityDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAvailabilityDialogControls Controls
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
        /// 	[a-omkasi] 7/7/2008 Created
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
        ///  Routine to set/get the text in control DataAggregation
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
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
        ///  Routine to set/get the text in control TimeZone
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
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
        ///  Routine to set/get the text in control To
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
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
        ///  Routine to set/get the text in control From
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
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
        /// 	[a-omkasi] 7/7/2008 Created
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
        ///  Routine to set/get the text in control To2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
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
        ///  Routine to set/get the text in control TextBox3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox3Text
        {
            get
            {
                return this.Controls.TextBox3.Text;
            }
            
            set
            {
                this.Controls.TextBox3.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAvailabilityDialogControls.DataAggregationStaticControl
        {
            get
            {
                if ((this.cachedDataAggregationStaticControl == null))
                {
                    this.cachedDataAggregationStaticControl = new StaticControl(this, AvailabilityDialog.ControlIDs.DataAggregationStaticControl);
                }
                
                return this.cachedDataAggregationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAvailabilityDialogControls.DataAggregationComboBox
        {
            get
            {
                if ((this.cachedDataAggregationComboBox == null))
                {
                    this.cachedDataAggregationComboBox = new ComboBox(this, AvailabilityDialog.ControlIDs.DataAggregationComboBox);
                }
                
                return this.cachedDataAggregationComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAvailabilityDialogControls.ObjectsStaticControl
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
                    this.cachedObjectsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _800AMTo500PMMonTueWedThuFriPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IAvailabilityDialogControls._800AMTo500PMMonTueWedThuFriPropertyGridView
        {
            get
            {
                if ((this.cached_800AMTo500PMMonTueWedThuFriPropertyGridView == null))
                {
                    this.cached_800AMTo500PMMonTueWedThuFriPropertyGridView = new PropertyGridView(this, AvailabilityDialog.ControlIDs._800AMTo500PMMonTueWedThuFriPropertyGridView);
                }
                
                return this.cached_800AMTo500PMMonTueWedThuFriPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAvailabilityDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, AvailabilityDialog.ControlIDs.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddObjectButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAvailabilityDialogControls.AddObjectButton
        {
            get
            {
                if ((this.cachedAddObjectButton == null))
                {
                    this.cachedAddObjectButton = new Button(this, AvailabilityDialog.ControlIDs.AddObjectButton);
                }
                
                return this.cachedAddObjectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddGroupButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAvailabilityDialogControls.AddGroupButton
        {
            get
            {
                if ((this.cachedAddGroupButton == null))
                {
                    this.cachedAddGroupButton = new Button(this, AvailabilityDialog.ControlIDs.AddGroupButton);
                }
                
                return this.cachedAddGroupButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DownTimeStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAvailabilityDialogControls.DownTimeStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDownTimeStaticControl == null))
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
                    this.cachedDownTimeStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDownTimeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DownTimeListBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAvailabilityDialogControls.DownTimeListBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDownTimeListBox == null))
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedDownTimeListBox = new ListBox(wndTemp);
                }
                
                return this.cachedDownTimeListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _800AMTo500PMMonTueWedThuFriStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAvailabilityDialogControls._800AMTo500PMMonTueWedThuFriStaticControl
        {
            get
            {
                if ((this.cached_800AMTo500PMMonTueWedThuFriStaticControl == null))
                {
                    this.cached_800AMTo500PMMonTueWedThuFriStaticControl = new StaticControl(this, AvailabilityDialog.ControlIDs._800AMTo500PMMonTueWedThuFriStaticControl);
                }
                
                return this.cached_800AMTo500PMMonTueWedThuFriStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseBusinessHoursCheckBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAvailabilityDialogControls.UseBusinessHoursCheckBox
        {
            get
            {
                if ((this.cachedUseBusinessHoursCheckBox == null))
                {
                    this.cachedUseBusinessHoursCheckBox = new CheckBox(this, AvailabilityDialog.ControlIDs.UseBusinessHoursCheckBox);
                }
                
                return this.cachedUseBusinessHoursCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessHoursButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAvailabilityDialogControls.BusinessHoursButton
        {
            get
            {
                if ((this.cachedBusinessHoursButton == null))
                {
                    this.cachedBusinessHoursButton = new Button(this, AvailabilityDialog.ControlIDs.BusinessHoursButton);
                }
                
                return this.cachedBusinessHoursButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAvailabilityDialogControls.TimeZoneComboBox
        {
            get
            {
                if ((this.cachedTimeZoneComboBox == null))
                {
                    this.cachedTimeZoneComboBox = new ComboBox(this, AvailabilityDialog.ControlIDs.TimeZoneComboBox);
                }
                
                return this.cachedTimeZoneComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAvailabilityDialogControls.TimeZoneStaticControl
        {
            get
            {
                if ((this.cachedTimeZoneStaticControl == null))
                {
                    this.cachedTimeZoneStaticControl = new StaticControl(this, AvailabilityDialog.ControlIDs.TimeZoneStaticControl);
                }
                
                return this.cachedTimeZoneStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAvailabilityDialogControls.ToComboBox
        {
            get
            {
                if ((this.cachedToComboBox == null))
                {
                    this.cachedToComboBox = new ComboBox(this, AvailabilityDialog.ControlIDs.ToComboBox);
                }
                
                return this.cachedToComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToSpinner control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IAvailabilityDialogControls.ToSpinner
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
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
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
        ///  Exposes access to the FromComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAvailabilityDialogControls.FromComboBox
        {
            get
            {
                if ((this.cachedFromComboBox == null))
                {
                    this.cachedFromComboBox = new ComboBox(this, AvailabilityDialog.ControlIDs.FromComboBox);
                }
                
                return this.cachedFromComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromSpinner control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IAvailabilityDialogControls.FromSpinner
        {
            get
            {
                if ((this.cachedFromSpinner == null))
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
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedFromSpinner = new Spinner(wndTemp);
                }
                
                return this.cachedFromSpinner;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromComboBox2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAvailabilityDialogControls.FromComboBox2
        {
            get
            {
                if ((this.cachedFromComboBox2 == null))
                {
                    this.cachedFromComboBox2 = new ComboBox(this, AvailabilityDialog.ControlIDs.FromComboBox2);
                }
                
                return this.cachedFromComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToComboBox2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAvailabilityDialogControls.ToComboBox2
        {
            get
            {
                if ((this.cachedToComboBox2 == null))
                {
                    this.cachedToComboBox2 = new ComboBox(this, AvailabilityDialog.ControlIDs.ToComboBox2);
                }
                
                return this.cachedToComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAvailabilityDialogControls.FromStaticControl
        {
            get
            {
                if ((this.cachedFromStaticControl == null))
                {
                    this.cachedFromStaticControl = new StaticControl(this, AvailabilityDialog.ControlIDs.FromStaticControl);
                }
                
                return this.cachedFromStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAvailabilityDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, AvailabilityDialog.ControlIDs.ToStaticControl);
                }
                
                return this.cachedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _800AMTo500PMMonTueWedThuFriStatusBar control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IAvailabilityDialogControls._800AMTo500PMMonTueWedThuFriStatusBar
        {
            get
            {
                if ((this.cached_800AMTo500PMMonTueWedThuFriStatusBar == null))
                {
                    this.cached_800AMTo500PMMonTueWedThuFriStatusBar = new StatusBar(this, AvailabilityDialog.ControlIDs._800AMTo500PMMonTueWedThuFriStatusBar);
                }
                
                return this.cached_800AMTo500PMMonTueWedThuFriStatusBar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Toolbar2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IAvailabilityDialogControls.Toolbar2
        {
            get
            {
                if ((this.cachedToolbar2 == null))
                {
                    this.cachedToolbar2 = new Toolbar(this, AvailabilityDialog.ControlIDs.Toolbar2);
                }
                
                return this.cachedToolbar2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox3 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAvailabilityDialogControls.TextBox3
        {
            get
            {
                if ((this.cachedTextBox3 == null))
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
                    this.cachedTextBox3 = new TextBox(wndTemp);
                }
                
                return this.cachedTextBox3;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddObject
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
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
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddGroup()
        {
            this.Controls.AddGroupButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UseBusinessHours
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
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
        /// 	[a-omkasi] 7/7/2008 Created
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
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
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
                    catch (Exceptions.WindowNotFoundException )
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
        /// 	[a-omkasi] 7/7/2008 Created
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
            /// Contains resource string for:  DownTime
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDownTime = "Down Time";
            
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
            /// Caches the translated resource string for:  DownTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDownTime;
            
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
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/7/2008 Created
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
                        throw new Maui.GlobalExceptions.MauiException("Exception in getting Dialog Title for Availability Dialog! Cannot use ReportDisplayName as it is null!");
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// Exposes access to the AddObject translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// Exposes access to the DownTime translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DownTime
            {
                get
                {
                    if ((cachedDownTime == null))
                    {
                        cachedDownTime = CoreManager.MomConsole.GetIntlStr(ResourceDownTime);
                    }
                    
                    return cachedDownTime;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _800AMTo500PMMonTueWedThuFri translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            /// 	[a-omkasi] 7/7/2008 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for DataAggregationStaticControl
            /// </summary>
            public const string DataAggregationStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for DataAggregationComboBox
            /// </summary>
            public const string DataAggregationComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for ObjectsStaticControl
            /// </summary>
            public const string ObjectsStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for _800AMTo500PMMonTueWedThuFriPropertyGridView
            /// </summary>
            public const string _800AMTo500PMMonTueWedThuFriPropertyGridView = "valueList";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for AddObjectButton
            /// </summary>
            public const string AddObjectButton = "addObjectButton";
            
            /// <summary>
            /// Control ID for AddGroupButton
            /// </summary>
            public const string AddGroupButton = "AddGroupButton";
            
            /// <summary>
            /// Control ID for DownTimeStaticControl
            /// </summary>
            public const string DownTimeStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for DownTimeListBox
            /// </summary>
            public const string DownTimeListBox = "valueEditor";
            
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
            /// Control ID for TimeZoneComboBox
            /// </summary>
            public const string TimeZoneComboBox = "timeZoneSelector";
            
            /// <summary>
            /// Control ID for TimeZoneStaticControl
            /// </summary>
            public const string TimeZoneStaticControl = "timeZoneLabel";
            
            /// <summary>
            /// Control ID for ToComboBox
            /// </summary>
            public const string ToComboBox = "endTimeEditor";
            
            /// <summary>
            /// Control ID for FromComboBox
            /// </summary>
            public const string FromComboBox = "startTimeEditor";
            
            /// <summary>
            /// Control ID for FromComboBox2
            /// </summary>
            public const string FromComboBox2 = "startDateEditor";
            
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
            /// Control ID for _800AMTo500PMMonTueWedThuFriStatusBar
            /// </summary>
            public const string _800AMTo500PMMonTueWedThuFriStatusBar = "consoleStatusBar";
            
            /// <summary>
            /// Control ID for Toolbar2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Toolbar2 = "toolBar";
        }
        #endregion
    }
}
