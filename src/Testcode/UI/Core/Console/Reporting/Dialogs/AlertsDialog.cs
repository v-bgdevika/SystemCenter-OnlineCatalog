// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[a-omkasi] 7/17/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System.Text;
    
    #region Interface Definition - IAlertsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertsDialogControls, for AlertsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 7/17/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertsDialogControls
    {
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
        /// Read-only property to access ObjectsStaticControl
        /// </summary>
        StaticControl ObjectsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeZonePropertyGridView
        /// </summary>
        PropertyGridView TimeZonePropertyGridView
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
        /// Read-only property to access SeverityStaticControl
        /// </summary>
        StaticControl SeverityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SeverityListBox
        /// </summary>
        ListBox SeverityListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PriorityStaticControl
        /// </summary>
        StaticControl PriorityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PriorityListBox
        /// </summary>
        ListBox PriorityListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StatusBar0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StatusBar StatusBar0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Toolbar1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox2
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
    /// 	[a-omkasi] 7/17/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertsDialog : Dialog, IAlertsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 5000;
        #endregion
        
        #region Private Member Variables

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
        /// Cache to hold a reference to ObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TimeZonePropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedTimeZonePropertyGridView;
        
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
        /// Cache to hold a reference to SeverityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSeverityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SeverityListBox of type ListBox
        /// </summary>
        private ListBox cachedSeverityListBox;
        
        /// <summary>
        /// Cache to hold a reference to PriorityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPriorityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PriorityListBox of type ListBox
        /// </summary>
        private ListBox cachedPriorityListBox;
        
        /// <summary>
        /// Cache to hold a reference to StatusBar0 of type StatusBar
        /// </summary>
        private StatusBar cachedStatusBar0;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar1;
        
        /// <summary>
        /// Cache to hold a reference to TextBox2 of type TextBox
        /// </summary>
        private TextBox cachedTextBox2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertsDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertsDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertsDialogControls Controls
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
        ///  Routine to set/get the text in control TimeZone
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
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
        /// 	[a-omkasi] 7/17/2008 Created
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
        /// 	[a-omkasi] 7/17/2008 Created
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
        /// 	[a-omkasi] 7/17/2008 Created
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
        /// 	[a-omkasi] 7/17/2008 Created
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
        ///  Routine to set/get the text in control TextBox2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox2Text
        {
            get
            {
                return this.Controls.TextBox2.Text;
            }
            
            set
            {
                this.Controls.TextBox2.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertsDialogControls.TimeZoneComboBox
        {
            get
            {
                if ((this.cachedTimeZoneComboBox == null))
                {
                    this.cachedTimeZoneComboBox = new ComboBox(this, AlertsDialog.ControlIDs.TimeZoneComboBox);
                }
                return this.cachedTimeZoneComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsDialogControls.TimeZoneStaticControl
        {
            get
            {
                if ((this.cachedTimeZoneStaticControl == null))
                {
                    this.cachedTimeZoneStaticControl = new StaticControl(this, AlertsDialog.ControlIDs.TimeZoneStaticControl);
                }
                return this.cachedTimeZoneStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertsDialogControls.ToComboBox
        {
            get
            {
                if ((this.cachedToComboBox == null))
                {
                    this.cachedToComboBox = new ComboBox(this, AlertsDialog.ControlIDs.ToComboBox);
                }
                return this.cachedToComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToSpinner control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IAlertsDialogControls.ToSpinner
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
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertsDialogControls.FromComboBox
        {
            get
            {
                if ((this.cachedFromComboBox == null))
                {
                    this.cachedFromComboBox = new ComboBox(this, AlertsDialog.ControlIDs.FromComboBox);
                }
                return this.cachedFromComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromSpinner control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IAlertsDialogControls.FromSpinner
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
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertsDialogControls.FromComboBox2
        {
            get
            {
                if ((this.cachedFromComboBox2 == null))
                {
                    this.cachedFromComboBox2 = new ComboBox(this, AlertsDialog.ControlIDs.FromComboBox2);
                }
                return this.cachedFromComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToComboBox2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertsDialogControls.ToComboBox2
        {
            get
            {
                if ((this.cachedToComboBox2 == null))
                {
                    this.cachedToComboBox2 = new ComboBox(this, AlertsDialog.ControlIDs.ToComboBox2);
                }
                return this.cachedToComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsDialogControls.FromStaticControl
        {
            get
            {
                if ((this.cachedFromStaticControl == null))
                {
                    this.cachedFromStaticControl = new StaticControl(this, AlertsDialog.ControlIDs.FromStaticControl);
                }
                return this.cachedFromStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, AlertsDialog.ControlIDs.ToStaticControl);
                }
                return this.cachedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsDialogControls.ObjectsStaticControl
        {
            get
            {
                if ((this.cachedObjectsStaticControl == null))
                {
                    this.cachedObjectsStaticControl = new StaticControl(this, AlertsDialog.ControlIDs.ObjectsStaticControl);
                }
                return this.cachedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZonePropertyGridView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IAlertsDialogControls.TimeZonePropertyGridView
        {
            get
            {
                if ((this.cachedTimeZonePropertyGridView == null))
                {
                    this.cachedTimeZonePropertyGridView = new PropertyGridView(this, AlertsDialog.ControlIDs.TimeZonePropertyGridView);
                }
                return this.cachedTimeZonePropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, AlertsDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddObjectButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsDialogControls.AddObjectButton
        {
            get
            {
                if ((this.cachedAddObjectButton == null))
                {
                    this.cachedAddObjectButton = new Button(this, AlertsDialog.ControlIDs.AddObjectButton);
                }
                return this.cachedAddObjectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddGroupButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsDialogControls.AddGroupButton
        {
            get
            {
                if ((this.cachedAddGroupButton == null))
                {
                    this.cachedAddGroupButton = new Button(this, AlertsDialog.ControlIDs.AddGroupButton);
                }
                return this.cachedAddGroupButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsDialogControls.SeverityStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSeverityStaticControl == null))
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
                    this.cachedSeverityStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSeverityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityListBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAlertsDialogControls.SeverityListBox
        {
            get
            {
                if ((this.cachedSeverityListBox == null))
                {
                    this.cachedSeverityListBox = new ListBox(this, AlertsDialog.ControlIDs.SeverityListBox);
                }
                return this.cachedSeverityListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsDialogControls.PriorityStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedPriorityStaticControl == null))
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
                    this.cachedPriorityStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedPriorityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PriorityListBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAlertsDialogControls.PriorityListBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedPriorityListBox == null))
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
                    this.cachedPriorityListBox = new ListBox(wndTemp);
                }
                return this.cachedPriorityListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusBar0 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IAlertsDialogControls.StatusBar0
        {
            get
            {
                if ((this.cachedStatusBar0 == null))
                {
                    this.cachedStatusBar0 = new StatusBar(this, AlertsDialog.ControlIDs.StatusBar0);
                }
                return this.cachedStatusBar0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Toolbar1 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IAlertsDialogControls.Toolbar1
        {
            get
            {
                if ((this.cachedToolbar1 == null))
                {
                    this.cachedToolbar1 = new Toolbar(this, AlertsDialog.ControlIDs.Toolbar1);
                }
                return this.cachedToolbar1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox2 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsDialogControls.TextBox2
        {
            get
            {
                if ((this.cachedTextBox2 == null))
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
                    this.cachedTextBox2 = new TextBox(wndTemp);
                }
                return this.cachedTextBox2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
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
        /// 	[a-omkasi] 7/17/2008 Created
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
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddGroup()
        {
            this.Controls.AddGroupButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException )
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 20;

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
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Reporting.Dialogs.AlertsDialog :: Attempt " + numberOfTries + " of " + maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                    catch (Maui.GlobalExceptions.TimedOutException)
                    {
                        // Log a TimedOutException
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Reporting.Dialogs.AlertsDialog :: Absorbing TimedOutException-"+numberOfTries+"! The Alerts Dialog window is taking too long to render.");
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
        /// 	[a-omkasi] 7/17/2008 Created
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
            /// Contains resource string for:  Severity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeverity = ";Severity;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;AlertSeverity" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Priority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePriority = ";Priority;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;AlertPriority" +
                "";
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
            /// Caches the translated resource string for:  Severity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeverity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Priority
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPriority;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/17/2008 Created
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
                    // Replace {2} with the report name: Alerts

                    // Check if ReportDisplayName is not null
                    if (Reporting.ReportDisplayName == null)
                    {
                        throw new Maui.GlobalExceptions.MauiException("Exception in getting Dialog Title for Alerts Dialog! Cannot use ReportDisplayName as it is null!");
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
            /// 	[a-omkasi] 7/17/2008 Created
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
            /// 	[a-omkasi] 7/17/2008 Created
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
            /// 	[a-omkasi] 7/17/2008 Created
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
            /// 	[a-omkasi] 7/17/2008 Created
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
            /// 	[a-omkasi] 7/17/2008 Created
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
            /// 	[a-omkasi] 7/17/2008 Created
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
            /// 	[a-omkasi] 7/17/2008 Created
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
            /// Exposes access to the Severity translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/17/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Severity
            {
                get
                {
                    if ((cachedSeverity == null))
                    {
                        cachedSeverity = CoreManager.MomConsole.GetIntlStr(ResourceSeverity);
                    }
                    return cachedSeverity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Priority translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/17/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Priority
            {
                get
                {
                    if ((cachedPriority == null))
                    {
                        cachedPriority = CoreManager.MomConsole.GetIntlStr(ResourcePriority);
                    }
                    return cachedPriority;
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
        /// 	[a-omkasi] 7/17/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
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
            /// Control ID for ObjectsStaticControl
            /// </summary>
            public const string ObjectsStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for TimeZonePropertyGridView
            /// </summary>
            public const string TimeZonePropertyGridView = "valueList";
            
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
            /// Control ID for SeverityStaticControl
            /// </summary>
            public const string SeverityStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for SeverityListBox
            /// </summary>
            public const string SeverityListBox = "valueEditor";
            
            /// <summary>
            /// Control ID for PriorityStaticControl
            /// </summary>
            public const string PriorityStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for PriorityListBox
            /// </summary>
            public const string PriorityListBox = "valueEditor";
            
            /// <summary>
            /// Control ID for StatusBar0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StatusBar0 = "consoleStatusBar";
            
            /// <summary>
            /// Control ID for Toolbar1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Toolbar1 = "toolBar";
        }
        #endregion
    }
}
