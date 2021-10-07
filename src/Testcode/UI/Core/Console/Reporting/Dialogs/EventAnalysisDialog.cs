// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EventAnalysisDialog.cs">
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
    
    #region Interface Definition - IEventAnalysisDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEventAnalysisDialogControls, for EventAnalysisDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 7/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEventAnalysisDialogControls
    {
        /// <summary>
        /// Read-only property to access DataAggregationComboBox
        /// </summary>
        ComboBox DataAggregationComboBox
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
        /// Read-only property to access ObjectsStaticControl
        /// </summary>
        StaticControl ObjectsStaticControl
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
        /// Read-only property to access SourceStaticControl
        /// </summary>
        StaticControl SourceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SeverityComboBox
        /// </summary>
        ComboBox SeverityComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TypeStaticControl
        /// </summary>
        StaticControl TypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TypeComboBox
        /// </summary>
        ComboBox TypeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CategoryStaticControl
        /// </summary>
        StaticControl CategoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox
        /// </summary>
        ComboBox ComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventIDStaticControl
        /// </summary>
        StaticControl EventIDStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventIDComboBox
        /// </summary>
        ComboBox EventIDComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CheckBox23
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        CheckBox CheckBox23
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToStatusBar
        /// </summary>
        StatusBar ToStatusBar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Toolbar24
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar24
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox25
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox25
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
    public class EventAnalysisDialog : Dialog, IEventAnalysisDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to DataAggregationComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDataAggregationComboBox;
        
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
        /// Cache to hold a reference to ObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DataAggregationPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataAggregationPropertyGridView;
        
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
        /// Cache to hold a reference to SourceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSourceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SeverityComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSeverityComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTypeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CategoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCategoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox;
        
        /// <summary>
        /// Cache to hold a reference to EventIDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventIDStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EventIDComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedEventIDComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CheckBox23 of type CheckBox
        /// </summary>
        private CheckBox cachedCheckBox23;
        
        /// <summary>
        /// Cache to hold a reference to ToStatusBar of type StatusBar
        /// </summary>
        private StatusBar cachedToStatusBar;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar24 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar24;
        
        /// <summary>
        /// Cache to hold a reference to TextBox25 of type TextBox
        /// </summary>
        private TextBox cachedTextBox25;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of EventAnalysisDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EventAnalysisDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IEventAnalysisDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEventAnalysisDialogControls Controls
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
        ///  Property to handle checkbox CheckBox23
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool CheckBox23
        {
            get
            {
                return this.Controls.CheckBox23.Checked;
            }
            
            set
            {
                this.Controls.CheckBox23.Checked = value;
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
        ///  Routine to set/get the text in control Severity
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SeverityText
        {
            get
            {
                return this.Controls.SeverityComboBox.Text;
            }
            
            set
            {
                this.Controls.SeverityComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Type
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TypeText
        {
            get
            {
                return this.Controls.TypeComboBox.Text;
            }
            
            set
            {
                this.Controls.TypeComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control 
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string Text
        {
            get
            {
                return this.Controls.ComboBox.Text;
            }
            
            set
            {
                this.Controls.ComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EventID
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EventIDText
        {
            get
            {
                return this.Controls.EventIDComboBox.Text;
            }
            
            set
            {
                this.Controls.EventIDComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox25
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox25Text
        {
            get
            {
                return this.Controls.TextBox25.Text;
            }
            
            set
            {
                this.Controls.TextBox25.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventAnalysisDialogControls.DataAggregationComboBox
        {
            get
            {
                if ((this.cachedDataAggregationComboBox == null))
                {
                    this.cachedDataAggregationComboBox = new ComboBox(this, EventAnalysisDialog.ControlIDs.DataAggregationComboBox);
                }
                return this.cachedDataAggregationComboBox;
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
        StaticControl IEventAnalysisDialogControls.TimeZoneStaticControl
        {
            get
            {
                if ((this.cachedTimeZoneStaticControl == null))
                {
                    this.cachedTimeZoneStaticControl = new StaticControl(this, EventAnalysisDialog.ControlIDs.TimeZoneStaticControl);
                }
                return this.cachedTimeZoneStaticControl;
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
        ComboBox IEventAnalysisDialogControls.ToComboBox
        {
            get
            {
                if ((this.cachedToComboBox == null))
                {
                    this.cachedToComboBox = new ComboBox(this, EventAnalysisDialog.ControlIDs.ToComboBox);
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
        Spinner IEventAnalysisDialogControls.ToSpinner
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
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
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventAnalysisDialogControls.FromComboBox
        {
            get
            {
                if ((this.cachedFromComboBox == null))
                {
                    this.cachedFromComboBox = new ComboBox(this, EventAnalysisDialog.ControlIDs.FromComboBox);
                }
                return this.cachedFromComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromSpinner control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IEventAnalysisDialogControls.FromSpinner
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
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
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventAnalysisDialogControls.FromComboBox2
        {
            get
            {
                if ((this.cachedFromComboBox2 == null))
                {
                    this.cachedFromComboBox2 = new ComboBox(this, EventAnalysisDialog.ControlIDs.FromComboBox2);
                }
                return this.cachedFromComboBox2;
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
        ComboBox IEventAnalysisDialogControls.ToComboBox2
        {
            get
            {
                if ((this.cachedToComboBox2 == null))
                {
                    this.cachedToComboBox2 = new ComboBox(this, EventAnalysisDialog.ControlIDs.ToComboBox2);
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
        StaticControl IEventAnalysisDialogControls.FromStaticControl
        {
            get
            {
                if ((this.cachedFromStaticControl == null))
                {
                    this.cachedFromStaticControl = new StaticControl(this, EventAnalysisDialog.ControlIDs.FromStaticControl);
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
        StaticControl IEventAnalysisDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, EventAnalysisDialog.ControlIDs.ToStaticControl);
                }
                return this.cachedToStaticControl;
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
        StaticControl IEventAnalysisDialogControls.ObjectsStaticControl
        {
            get
            {
                if ((this.cachedObjectsStaticControl == null))
                {
                    this.cachedObjectsStaticControl = new StaticControl(this, EventAnalysisDialog.ControlIDs.ObjectsStaticControl);
                }
                return this.cachedObjectsStaticControl;
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
        PropertyGridView IEventAnalysisDialogControls.DataAggregationPropertyGridView
        {
            get
            {
                if ((this.cachedDataAggregationPropertyGridView == null))
                {
                    this.cachedDataAggregationPropertyGridView = new PropertyGridView(this, EventAnalysisDialog.ControlIDs.DataAggregationPropertyGridView);
                }
                return this.cachedDataAggregationPropertyGridView;
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
        Button IEventAnalysisDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, EventAnalysisDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddObjectButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventAnalysisDialogControls.AddObjectButton
        {
            get
            {
                if ((this.cachedAddObjectButton == null))
                {
                    this.cachedAddObjectButton = new Button(this, EventAnalysisDialog.ControlIDs.AddObjectButton);
                }
                return this.cachedAddObjectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddGroupButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventAnalysisDialogControls.AddGroupButton
        {
            get
            {
                if ((this.cachedAddGroupButton == null))
                {
                    this.cachedAddGroupButton = new Button(this, EventAnalysisDialog.ControlIDs.AddGroupButton);
                }
                return this.cachedAddGroupButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SourceStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventAnalysisDialogControls.SourceStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSourceStaticControl == null))
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
                    this.cachedSourceStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSourceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventAnalysisDialogControls.SeverityComboBox
        {
            get
            {
                if ((this.cachedSeverityComboBox == null))
                {
                    this.cachedSeverityComboBox = new ComboBox(this, EventAnalysisDialog.ControlIDs.SeverityComboBox);
                }
                return this.cachedSeverityComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventAnalysisDialogControls.TypeStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTypeStaticControl == null))
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
                    this.cachedTypeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventAnalysisDialogControls.TypeComboBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTypeComboBox == null))
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
                    this.cachedTypeComboBox = new ComboBox(wndTemp);
                }
                return this.cachedTypeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CategoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventAnalysisDialogControls.CategoryStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCategoryStaticControl == null))
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
                    this.cachedCategoryStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedCategoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventAnalysisDialogControls.ComboBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedComboBox == null))
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedComboBox = new ComboBox(wndTemp);
                }
                return this.cachedComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventIDStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventAnalysisDialogControls.EventIDStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventIDStaticControl == null))
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
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedEventIDStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedEventIDStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventIDComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventAnalysisDialogControls.EventIDComboBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventIDComboBox == null))
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
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedEventIDComboBox = new ComboBox(wndTemp);
                }
                return this.cachedEventIDComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CheckBox23 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IEventAnalysisDialogControls.CheckBox23
        {
            get
            {
                if ((this.cachedCheckBox23 == null))
                {
                    this.cachedCheckBox23 = new CheckBox(this, EventAnalysisDialog.ControlIDs.CheckBox23);
                }
                return this.cachedCheckBox23;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToStatusBar control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IEventAnalysisDialogControls.ToStatusBar
        {
            get
            {
                if ((this.cachedToStatusBar == null))
                {
                    this.cachedToStatusBar = new StatusBar(this, EventAnalysisDialog.ControlIDs.ToStatusBar);
                }
                return this.cachedToStatusBar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Toolbar24 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IEventAnalysisDialogControls.Toolbar24
        {
            get
            {
                if ((this.cachedToolbar24 == null))
                {
                    this.cachedToolbar24 = new Toolbar(this, EventAnalysisDialog.ControlIDs.Toolbar24);
                }
                return this.cachedToolbar24;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox25 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventAnalysisDialogControls.TextBox25
        {
            get
            {
                if ((this.cachedTextBox25 == null))
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
                    this.cachedTextBox25 = new TextBox(wndTemp);
                }
                return this.cachedTextBox25;
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
        ///  Routine to click on button AddObject
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
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
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddGroup()
        {
            this.Controls.AddGroupButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CheckBox23
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCheckBox23()
        {
            this.Controls.CheckBox23.Click();
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
            private const string ResourceDialogTitle = "Event Analysis - System Center Operations Manager 2007 - Report - hornet245d";
            
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
            /// Contains resource string for:  Source
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSource = ";Source;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Views.AttributesView.AttributesViewRes" +
                "ources;SourceColumn";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceType = ";Type;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Type";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Category
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCategory = ";Category;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;EventCategory" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventID = ";Event ID;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Common.EventPropertyListResources;Ev" +
                "entDisplayNumber";
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
            /// Caches the translated resource string for:  Source
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSource;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Type
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Category
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCategory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventID;
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
                        throw new Maui.GlobalExceptions.MauiException("Exception in getting Dialog Title for EventAnalysis Dialog! Cannot use ReportDisplayName as it is null!");
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
            /// Exposes access to the AddObject translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
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
            /// 	[a-omkasi] 7/24/2008 Created
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
            /// Exposes access to the Source translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Source
            {
                get
                {
                    if ((cachedSource == null))
                    {
                        cachedSource = CoreManager.MomConsole.GetIntlStr(ResourceSource);
                    }
                    return cachedSource;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Type translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Type
            {
                get
                {
                    if ((cachedType == null))
                    {
                        cachedType = CoreManager.MomConsole.GetIntlStr(ResourceType);
                    }
                    return cachedType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Category translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Category
            {
                get
                {
                    if ((cachedCategory == null))
                    {
                        cachedCategory = CoreManager.MomConsole.GetIntlStr(ResourceCategory);
                    }
                    return cachedCategory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventID translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventID
            {
                get
                {
                    if ((cachedEventID == null))
                    {
                        cachedEventID = CoreManager.MomConsole.GetIntlStr(ResourceEventID);
                    }
                    return cachedEventID;
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
            /// Control ID for DataAggregationComboBox
            /// </summary>
            public const string DataAggregationComboBox = "timeZoneSelector";
            
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
            /// Control ID for ObjectsStaticControl
            /// </summary>
            public const string ObjectsStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for DataAggregationPropertyGridView
            /// </summary>
            public const string DataAggregationPropertyGridView = "valueList";
            
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
            /// Control ID for SourceStaticControl
            /// </summary>
            public const string SourceStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for SeverityComboBox
            /// </summary>
            public const string SeverityComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for TypeStaticControl
            /// </summary>
            public const string TypeStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for TypeComboBox
            /// </summary>
            public const string TypeComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for CategoryStaticControl
            /// </summary>
            public const string CategoryStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for ComboBox
            /// </summary>
            public const string ComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for EventIDStaticControl
            /// </summary>
            public const string EventIDStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for EventIDComboBox
            /// </summary>
            public const string EventIDComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for CheckBox23
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string CheckBox23 = "nullValueBox";
            
            /// <summary>
            /// Control ID for ToStatusBar
            /// </summary>
            public const string ToStatusBar = "consoleStatusBar";
            
            /// <summary>
            /// Control ID for Toolbar24
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Toolbar24 = "toolBar";
        }
        #endregion
    }
}
