// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OverridesDialog.cs">
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
    
    #region Interface Definition - IOverridesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOverridesDialogControls, for OverridesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 7/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOverridesDialogControls
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
        /// Read-only property to access SelectCriteriaStaticControl
        /// </summary>
        StaticControl SelectCriteriaStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromComboBox3
        /// </summary>
        ComboBox FromComboBox3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludeSealedMPOverridesStaticControl
        /// </summary>
        StaticControl ExcludeSealedMPOverridesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsComboBox
        /// </summary>
        ComboBox ObjectsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackStaticControl
        /// </summary>
        StaticControl ManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataAggregationListBox
        /// </summary>
        ListBox DataAggregationListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementGroupStaticControl
        /// </summary>
        StaticControl ManagementGroupStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromComboBox4
        /// </summary>
        ComboBox FromComboBox4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StatusBar35
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StatusBar StatusBar35
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
        /// Read-only property to access TextBox36
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox36
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
    public class OverridesDialog : Dialog, IOverridesDialogControls
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
        /// Cache to hold a reference to SelectCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectCriteriaStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FromComboBox3 of type ComboBox
        /// </summary>
        private ComboBox cachedFromComboBox3;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeSealedMPOverridesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludeSealedMPOverridesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedObjectsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DataAggregationListBox of type ListBox
        /// </summary>
        private ListBox cachedDataAggregationListBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FromComboBox4 of type ComboBox
        /// </summary>
        private ComboBox cachedFromComboBox4;
        
        /// <summary>
        /// Cache to hold a reference to StatusBar35 of type StatusBar
        /// </summary>
        private StatusBar cachedStatusBar35;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedObjectsToolbar;
        
        /// <summary>
        /// Cache to hold a reference to TextBox36 of type TextBox
        /// </summary>
        private TextBox cachedTextBox36;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OverridesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OverridesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IOverridesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOverridesDialogControls Controls
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
        ///  Routine to set/get the text in control From3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string From3Text
        {
            get
            {
                return this.Controls.FromComboBox3.Text;
            }
            
            set
            {
                this.Controls.FromComboBox3.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Objects
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ObjectsText
        {
            get
            {
                return this.Controls.ObjectsComboBox.Text;
            }
            
            set
            {
                this.Controls.ObjectsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control From4
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string From4Text
        {
            get
            {
                return this.Controls.FromComboBox4.Text;
            }
            
            set
            {
                this.Controls.FromComboBox4.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox36
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox36Text
        {
            get
            {
                return this.Controls.TextBox36.Text;
            }
            
            set
            {
                this.Controls.TextBox36.Text = value;
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
        ComboBox IOverridesDialogControls.DataAggregationComboBox
        {
            get
            {
                if ((this.cachedDataAggregationComboBox == null))
                {
                    this.cachedDataAggregationComboBox = new ComboBox(this, OverridesDialog.ControlIDs.DataAggregationComboBox);
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
        StaticControl IOverridesDialogControls.TimeZoneStaticControl
        {
            get
            {
                if ((this.cachedTimeZoneStaticControl == null))
                {
                    this.cachedTimeZoneStaticControl = new StaticControl(this, OverridesDialog.ControlIDs.TimeZoneStaticControl);
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
        ComboBox IOverridesDialogControls.ToComboBox
        {
            get
            {
                if ((this.cachedToComboBox == null))
                {
                    this.cachedToComboBox = new ComboBox(this, OverridesDialog.ControlIDs.ToComboBox);
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
        Spinner IOverridesDialogControls.ToSpinner
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
        ComboBox IOverridesDialogControls.FromComboBox
        {
            get
            {
                if ((this.cachedFromComboBox == null))
                {
                    this.cachedFromComboBox = new ComboBox(this, OverridesDialog.ControlIDs.FromComboBox);
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
        Spinner IOverridesDialogControls.FromSpinner
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
        ComboBox IOverridesDialogControls.FromComboBox2
        {
            get
            {
                if ((this.cachedFromComboBox2 == null))
                {
                    this.cachedFromComboBox2 = new ComboBox(this, OverridesDialog.ControlIDs.FromComboBox2);
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
        ComboBox IOverridesDialogControls.ToComboBox2
        {
            get
            {
                if ((this.cachedToComboBox2 == null))
                {
                    this.cachedToComboBox2 = new ComboBox(this, OverridesDialog.ControlIDs.ToComboBox2);
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
        StaticControl IOverridesDialogControls.FromStaticControl
        {
            get
            {
                if ((this.cachedFromStaticControl == null))
                {
                    this.cachedFromStaticControl = new StaticControl(this, OverridesDialog.ControlIDs.FromStaticControl);
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
        StaticControl IOverridesDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, OverridesDialog.ControlIDs.ToStaticControl);
                }
                return this.cachedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesDialogControls.SelectCriteriaStaticControl
        {
            get
            {
                if ((this.cachedSelectCriteriaStaticControl == null))
                {
                    this.cachedSelectCriteriaStaticControl = new StaticControl(this, OverridesDialog.ControlIDs.SelectCriteriaStaticControl);
                }
                return this.cachedSelectCriteriaStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromComboBox3 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOverridesDialogControls.FromComboBox3
        {
            get
            {
                if ((this.cachedFromComboBox3 == null))
                {
                    this.cachedFromComboBox3 = new ComboBox(this, OverridesDialog.ControlIDs.FromComboBox3);
                }
                return this.cachedFromComboBox3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeSealedMPOverridesStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesDialogControls.ExcludeSealedMPOverridesStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExcludeSealedMPOverridesStaticControl == null))
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
                    this.cachedExcludeSealedMPOverridesStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedExcludeSealedMPOverridesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOverridesDialogControls.ObjectsComboBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedObjectsComboBox == null))
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
                    this.cachedObjectsComboBox = new ComboBox(wndTemp);
                }
                return this.cachedObjectsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesDialogControls.ManagementPackStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedManagementPackStaticControl == null))
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
                    this.cachedManagementPackStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationListBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IOverridesDialogControls.DataAggregationListBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDataAggregationListBox == null))
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
                    this.cachedDataAggregationListBox = new ListBox(wndTemp);
                }
                return this.cachedDataAggregationListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridesDialogControls.ManagementGroupStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedManagementGroupStaticControl == null))
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
                    this.cachedManagementGroupStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedManagementGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromComboBox4 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOverridesDialogControls.FromComboBox4
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedFromComboBox4 == null))
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
                    this.cachedFromComboBox4 = new ComboBox(wndTemp);
                }
                return this.cachedFromComboBox4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusBar35 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IOverridesDialogControls.StatusBar35
        {
            get
            {
                if ((this.cachedStatusBar35 == null))
                {
                    this.cachedStatusBar35 = new StatusBar(this, OverridesDialog.ControlIDs.StatusBar35);
                }
                return this.cachedStatusBar35;
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
        Toolbar IOverridesDialogControls.ObjectsToolbar
        {
            get
            {
                if ((this.cachedObjectsToolbar == null))
                {
                    this.cachedObjectsToolbar = new Toolbar(this, OverridesDialog.ControlIDs.ObjectsToolbar);
                }
                return this.cachedObjectsToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox36 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IOverridesDialogControls.TextBox36
        {
            get
            {
                if ((this.cachedTextBox36 == null))
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
                    this.cachedTextBox36 = new TextBox(wndTemp);
                }
                return this.cachedTextBox36;
            }
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
            private const string ResourceDialogTitle = "Overrides - System Center Operations Manager 2007 - Report - hornet245d";
            
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
            /// Contains resource string for:  SelectCriteria
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectCriteria = "Select Criteria";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludeSealedMPOverrides
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludeSealedMPOverrides = "Exclude sealed MP overrides";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management Pack;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm" +
                ";columnHeaderMP.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementGroup = ";Management Group;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;M" +
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Moni" +
                "toring.ReportMonitoringObjectList;GroupColumn.Text";
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
            /// Caches the translated resource string for:  SelectCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectCriteria;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludeSealedMPOverrides
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludeSealedMPOverrides;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementGroup;
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
                        throw new Maui.GlobalExceptions.MauiException("Exception in getting Dialog Title for Overrides Dialog! Cannot use ReportDisplayName as it is null!");
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
            /// Exposes access to the SelectCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectCriteria
            {
                get
                {
                    if ((cachedSelectCriteria == null))
                    {
                        cachedSelectCriteria = CoreManager.MomConsole.GetIntlStr(ResourceSelectCriteria);
                    }
                    return cachedSelectCriteria;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludeSealedMPOverrides translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludeSealedMPOverrides
            {
                get
                {
                    if ((cachedExcludeSealedMPOverrides == null))
                    {
                        cachedExcludeSealedMPOverrides = CoreManager.MomConsole.GetIntlStr(ResourceExcludeSealedMPOverrides);
                    }
                    return cachedExcludeSealedMPOverrides;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPack
            {
                get
                {
                    if ((cachedManagementPack == null))
                    {
                        cachedManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceManagementPack);
                    }
                    return cachedManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/24/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementGroup
            {
                get
                {
                    if ((cachedManagementGroup == null))
                    {
                        cachedManagementGroup = CoreManager.MomConsole.GetIntlStr(ResourceManagementGroup);
                    }
                    return cachedManagementGroup;
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
            /// Control ID for SelectCriteriaStaticControl
            /// </summary>
            public const string SelectCriteriaStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for FromComboBox3
            /// </summary>
            public const string FromComboBox3 = "valueEditor";
            
            /// <summary>
            /// Control ID for ExcludeSealedMPOverridesStaticControl
            /// </summary>
            public const string ExcludeSealedMPOverridesStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for ObjectsComboBox
            /// </summary>
            public const string ObjectsComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for DataAggregationListBox
            /// </summary>
            public const string DataAggregationListBox = "valueEditor";
            
            /// <summary>
            /// Control ID for ManagementGroupStaticControl
            /// </summary>
            public const string ManagementGroupStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for FromComboBox4
            /// </summary>
            public const string FromComboBox4 = "valueEditor";
            
            /// <summary>
            /// Control ID for StatusBar35
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StatusBar35 = "consoleStatusBar";
            
            /// <summary>
            /// Control ID for ObjectsToolbar
            /// </summary>
            public const string ObjectsToolbar = "toolBar";
        }
        #endregion
    }
}
