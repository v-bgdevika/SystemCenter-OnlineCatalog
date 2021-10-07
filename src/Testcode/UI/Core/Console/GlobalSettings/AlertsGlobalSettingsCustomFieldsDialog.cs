// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertsGlobalSettingsCustomFieldsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 9/21/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAlertsGlobalSettingsCustomFieldsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertsGlobalSettingsCustomFieldsDialogControls, for AlertsGlobalSettingsCustomFieldsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 9/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertsGlobalSettingsCustomFieldsDialogControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField5TextBox
        /// </summary>
        TextBox CustomField5TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField5StaticControl
        /// </summary>
        StaticControl CustomField5StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField9TextBox
        /// </summary>
        TextBox CustomField9TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField9StaticControl
        /// </summary>
        StaticControl CustomField9StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField4TextBox
        /// </summary>
        TextBox CustomField4TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField4StaticControl
        /// </summary>
        StaticControl CustomField4StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField8TextBox
        /// </summary>
        TextBox CustomField8TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField8StaticControl
        /// </summary>
        StaticControl CustomField8StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField3TextBox
        /// </summary>
        TextBox CustomField3TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField3StaticControl
        /// </summary>
        StaticControl CustomField3StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField7TextBox
        /// </summary>
        TextBox CustomField7TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField7StaticControl
        /// </summary>
        StaticControl CustomField7StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField2TextBox
        /// </summary>
        TextBox CustomField2TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField2StaticControl
        /// </summary>
        StaticControl CustomField2StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField1TextBox
        /// </summary>
        TextBox CustomField1TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField6StaticControl
        /// </summary>
        StaticControl CustomField6StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField6TextBox
        /// </summary>
        TextBox CustomField6TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField1StaticControl
        /// </summary>
        StaticControl CustomField1StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField10TextBox
        /// </summary>
        TextBox CustomField10TextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomField10StaticControl
        /// </summary>
        StaticControl CustomField10StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomAlertFieldSettingsStaticControl
        /// </summary>
        StaticControl CustomAlertFieldSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic
        /// </summary>
        StaticControl CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic
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
    /// 	[lucyra] 9/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertsGlobalSettingsCustomFieldsDialog : Dialog, IAlertsGlobalSettingsCustomFieldsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField5TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField5TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField5StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField5StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField9TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField9TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField9StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField9StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField4TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField4TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField4StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField4StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField8TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField8TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField8StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField8StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField3TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField3TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField3StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField3StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField7TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField7TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField7StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField7StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField2TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField2TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField2StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField2StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField1TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField1TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField6StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField6StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField6TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField6TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField1StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField1StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomField10TextBox of type TextBox
        /// </summary>
        private TextBox cachedCustomField10TextBox;
        
        /// <summary>
        /// Cache to hold a reference to CustomField10StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomField10StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomAlertFieldSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCustomAlertFieldSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic of type StaticControl
        /// </summary>
        private StaticControl cachedCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertsGlobalSettingsCustomFieldsDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertsGlobalSettingsCustomFieldsDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertsGlobalSettingsCustomFieldsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertsGlobalSettingsCustomFieldsDialogControls Controls
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
        ///  Routine to set/get the text in control CustomField5
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField5Text
        {
            get
            {
                return this.Controls.CustomField5TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField5TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField9
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField9Text
        {
            get
            {
                return this.Controls.CustomField9TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField9TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField4
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField4Text
        {
            get
            {
                return this.Controls.CustomField4TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField4TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField8
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField8Text
        {
            get
            {
                return this.Controls.CustomField8TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField8TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField3Text
        {
            get
            {
                return this.Controls.CustomField3TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField3TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField7
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField7Text
        {
            get
            {
                return this.Controls.CustomField7TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField7TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField2Text
        {
            get
            {
                return this.Controls.CustomField2TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField2TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField1TextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField1TextBoxText
        {
            get
            {
                return this.Controls.CustomField1TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField1TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField6TextBox2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField6TextBox2Text
        {
            get
            {
                return this.Controls.CustomField6TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField6TextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CustomField10
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CustomField10Text
        {
            get
            {
                return this.Controls.CustomField10TextBox.Text;
            }
            
            set
            {
                this.Controls.CustomField10TextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsCustomFieldsDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsCustomFieldsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsCustomFieldsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertsGlobalSettingsCustomFieldsDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.Tab1TabControl);
                }
                
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField5TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField5TextBox
        {
            get
            {
                if ((this.cachedCustomField5TextBox == null))
                {
                    this.cachedCustomField5TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField5TextBox);
                }
                
                return this.cachedCustomField5TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField5StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField5StaticControl
        {
            get
            {
                if ((this.cachedCustomField5StaticControl == null))
                {
                    this.cachedCustomField5StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField5StaticControl);
                }
                
                return this.cachedCustomField5StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField9TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField9TextBox
        {
            get
            {
                if ((this.cachedCustomField9TextBox == null))
                {
                    this.cachedCustomField9TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField9TextBox);
                }
                
                return this.cachedCustomField9TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField9StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField9StaticControl
        {
            get
            {
                if ((this.cachedCustomField9StaticControl == null))
                {
                    this.cachedCustomField9StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField9StaticControl);
                }
                
                return this.cachedCustomField9StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField4TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField4TextBox
        {
            get
            {
                if ((this.cachedCustomField4TextBox == null))
                {
                    this.cachedCustomField4TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField4TextBox);
                }
                
                return this.cachedCustomField4TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField4StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField4StaticControl
        {
            get
            {
                if ((this.cachedCustomField4StaticControl == null))
                {
                    this.cachedCustomField4StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField4StaticControl);
                }
                
                return this.cachedCustomField4StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField8TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField8TextBox
        {
            get
            {
                if ((this.cachedCustomField8TextBox == null))
                {
                    this.cachedCustomField8TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField8TextBox);
                }
                
                return this.cachedCustomField8TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField8StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField8StaticControl
        {
            get
            {
                if ((this.cachedCustomField8StaticControl == null))
                {
                    this.cachedCustomField8StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField8StaticControl);
                }
                
                return this.cachedCustomField8StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField3TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField3TextBox
        {
            get
            {
                if ((this.cachedCustomField3TextBox == null))
                {
                    this.cachedCustomField3TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField3TextBox);
                }
                
                return this.cachedCustomField3TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField3StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField3StaticControl
        {
            get
            {
                if ((this.cachedCustomField3StaticControl == null))
                {
                    this.cachedCustomField3StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField3StaticControl);
                }
                
                return this.cachedCustomField3StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField7TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField7TextBox
        {
            get
            {
                if ((this.cachedCustomField7TextBox == null))
                {
                    this.cachedCustomField7TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField7TextBox);
                }
                
                return this.cachedCustomField7TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField7StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField7StaticControl
        {
            get
            {
                if ((this.cachedCustomField7StaticControl == null))
                {
                    this.cachedCustomField7StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField7StaticControl);
                }
                
                return this.cachedCustomField7StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField2TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField2TextBox
        {
            get
            {
                if ((this.cachedCustomField2TextBox == null))
                {
                    this.cachedCustomField2TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField2TextBox);
                }
                
                return this.cachedCustomField2TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField2StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField2StaticControl
        {
            get
            {
                if ((this.cachedCustomField2StaticControl == null))
                {
                    this.cachedCustomField2StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField2StaticControl);
                }
                
                return this.cachedCustomField2StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField1TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField1TextBox
        {
            get
            {
                if ((this.cachedCustomField1TextBox == null))
                {
                    this.cachedCustomField1TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField1TextBox);
                }
                
                return this.cachedCustomField1TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField6StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField6StaticControl
        {
            get
            {
                if ((this.cachedCustomField6StaticControl == null))
                {
                    this.cachedCustomField6StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField6StaticControl);
                }
                
                return this.cachedCustomField6StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField6TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField6TextBox
        {
            get
            {
                if ((this.cachedCustomField6TextBox == null))
                {
                    this.cachedCustomField6TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField6TextBox);
                }
                
                return this.cachedCustomField6TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField1StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField1StaticControl
        {
            get
            {
                if ((this.cachedCustomField1StaticControl == null))
                {
                    this.cachedCustomField1StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField1StaticControl);
                }
                
                return this.cachedCustomField1StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField10TextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField10TextBox
        {
            get
            {
                if ((this.cachedCustomField10TextBox == null))
                {
                    this.cachedCustomField10TextBox = new TextBox(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField10TextBox);
                }
                
                return this.cachedCustomField10TextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomField10StaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomField10StaticControl
        {
            get
            {
                if ((this.cachedCustomField10StaticControl == null))
                {
                    this.cachedCustomField10StaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomField10StaticControl);
                }
                
                return this.cachedCustomField10StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomAlertFieldSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomAlertFieldSettingsStaticControl
        {
            get
            {
                if ((this.cachedCustomAlertFieldSettingsStaticControl == null))
                {
                    this.cachedCustomAlertFieldSettingsStaticControl = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomAlertFieldSettingsStaticControl);
                }
                
                return this.cachedCustomAlertFieldSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsCustomFieldsDialogControls.CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic
        {
            get
            {
                if ((this.cachedCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic == null))
                {
                    this.cachedCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic = new StaticControl(this, AlertsGlobalSettingsCustomFieldsDialog.ControlIDs.CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic);
                }
                
                return this.cachedCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                Common.Utilities.LogMessage(
                    "Looking for window with title:  '" +
                    Strings.DialogTitle +
                    "'");

                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 10;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Common.Utilities.LogMessage("Failed to find Global Settings - Alerts dialog window!");

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
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix on MOM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogMomTitlePrefix = ";Global Management Group Settings -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix on SCE
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogSceTitlePrefix = ";Global Management Settings -;ManagedString;Microsoft.EnterpriseManagement.SCE.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.AdministrationSpace.AdminResources;GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitleSuffix = ";Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SettingsResources;GroupAlerts";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField5 = ";Custom field &5:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label11.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField9
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField9 = ";Custom field &9:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label8.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField4 = ";Custom field &4:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label9.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField8 = ";Custom field &8:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label6.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField3 = ";Custom field &3:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label7.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField7
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField7 = ";Custom field &7:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label4.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField2 = ";Custom field &2:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label5.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField6 = ";Custom field &6:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField1 = ";Custom field &1:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomField10
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomField10 = ";Custom field &1&0:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.GroupSettings.CustomFields;labelC10.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomAlertFieldSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomAlertFieldSettings = ";Custom Alert Field Settings:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.GroupSettings.CustomFields;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic = "Custom alert fields are used in advanced monitoring scenarios to collect addition" +
                "al information about a problem which can be useful in troubleshooting. Add custo" +
                "m alerts in the text fields. You can have up to 10 custom alerts fields (limit 2" +
                "55 characters ";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitlePrefix;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitleSuffix;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField5;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField9
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField9;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField4;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField8
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField8;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField7
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField7;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField6;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomField10
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField10;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomAlertFieldSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomAlertFieldSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            ///     [lucyra] 10/31/2006 Updated to support SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitlePrefix == null) || (cachedDialogTitleSuffix == null))
                    {
                        //if (ProductSku.Sku == ProductSkuLevel.Mom)
                        cachedDialogTitlePrefix = CoreManager.MomConsole.GetIntlStr(ResourceDialogMomTitlePrefix);

                        cachedDialogTitleSuffix = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitleSuffix);
                    }
                    return (cachedDialogTitlePrefix + " " + cachedDialogTitleSuffix);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField5 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField5
            {
                get
                {
                    if ((cachedCustomField5 == null))
                    {
                        cachedCustomField5 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField5);
                    }
                    
                    return cachedCustomField5;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField9 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField9
            {
                get
                {
                    if ((cachedCustomField9 == null))
                    {
                        cachedCustomField9 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField9);
                    }
                    
                    return cachedCustomField9;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField4 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField4
            {
                get
                {
                    if ((cachedCustomField4 == null))
                    {
                        cachedCustomField4 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField4);
                    }
                    
                    return cachedCustomField4;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField8 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField8
            {
                get
                {
                    if ((cachedCustomField8 == null))
                    {
                        cachedCustomField8 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField8);
                    }
                    
                    return cachedCustomField8;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField3 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField3
            {
                get
                {
                    if ((cachedCustomField3 == null))
                    {
                        cachedCustomField3 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField3);
                    }
                    
                    return cachedCustomField3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField7 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField7
            {
                get
                {
                    if ((cachedCustomField7 == null))
                    {
                        cachedCustomField7 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField7);
                    }
                    
                    return cachedCustomField7;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField2
            {
                get
                {
                    if ((cachedCustomField2 == null))
                    {
                        cachedCustomField2 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField2);
                    }
                    
                    return cachedCustomField2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField6 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField6
            {
                get
                {
                    if ((cachedCustomField6 == null))
                    {
                        cachedCustomField6 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField6);
                    }
                    
                    return cachedCustomField6;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField1 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField1
            {
                get
                {
                    if ((cachedCustomField1 == null))
                    {
                        cachedCustomField1 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField1);
                    }
                    
                    return cachedCustomField1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomField10 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField10
            {
                get
                {
                    if ((cachedCustomField10 == null))
                    {
                        cachedCustomField10 = CoreManager.MomConsole.GetIntlStr(ResourceCustomField10);
                    }
                    
                    return cachedCustomField10;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomAlertFieldSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomAlertFieldSettings
            {
                get
                {
                    if ((cachedCustomAlertFieldSettings == null))
                    {
                        cachedCustomAlertFieldSettings = CoreManager.MomConsole.GetIntlStr(ResourceCustomAlertFieldSettings);
                    }
                    
                    return cachedCustomAlertFieldSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic
            {
                get
                {
                    if ((cachedCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic == null))
                    {
                        cachedCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic = CoreManager.MomConsole.GetIntlStr(ResourceCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic);
                    }
                    
                    return cachedCustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic;
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
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for CustomField5TextBox
            /// </summary>
            public const string CustomField5TextBox = "textBoxC5";
            
            /// <summary>
            /// Control ID for CustomField5StaticControl
            /// </summary>
            public const string CustomField5StaticControl = "labelC5";
            
            /// <summary>
            /// Control ID for CustomField9TextBox
            /// </summary>
            public const string CustomField9TextBox = "textBoxC9";
            
            /// <summary>
            /// Control ID for CustomField9StaticControl
            /// </summary>
            public const string CustomField9StaticControl = "labelC9";
            
            /// <summary>
            /// Control ID for CustomField4TextBox
            /// </summary>
            public const string CustomField4TextBox = "textBoxC4";
            
            /// <summary>
            /// Control ID for CustomField4StaticControl
            /// </summary>
            public const string CustomField4StaticControl = "labelC4";
            
            /// <summary>
            /// Control ID for CustomField8TextBox
            /// </summary>
            public const string CustomField8TextBox = "textBoxC8";
            
            /// <summary>
            /// Control ID for CustomField8StaticControl
            /// </summary>
            public const string CustomField8StaticControl = "labelC8";
            
            /// <summary>
            /// Control ID for CustomField3TextBox
            /// </summary>
            public const string CustomField3TextBox = "textBoxC3";
            
            /// <summary>
            /// Control ID for CustomField3StaticControl
            /// </summary>
            public const string CustomField3StaticControl = "labelC3";
            
            /// <summary>
            /// Control ID for CustomField7TextBox
            /// </summary>
            public const string CustomField7TextBox = "textBoxC7";
            
            /// <summary>
            /// Control ID for CustomField7StaticControl
            /// </summary>
            public const string CustomField7StaticControl = "labelC7";
            
            /// <summary>
            /// Control ID for CustomField2TextBox
            /// </summary>
            public const string CustomField2TextBox = "textBoxC2";
            
            /// <summary>
            /// Control ID for CustomField2StaticControl
            /// </summary>
            public const string CustomField2StaticControl = "labelC2";
            
            /// <summary>
            /// Control ID for CustomField6TextBox
            /// </summary>
            public const string CustomField6TextBox = "textBoxC6";
            
            /// <summary>
            /// Control ID for CustomField6StaticControl
            /// </summary>
            public const string CustomField6StaticControl = "labelC6";
            
            /// <summary>
            /// Control ID for CustomField1TextBox
            /// </summary>
            public const string CustomField1TextBox = "textBoxC1";
            
            /// <summary>
            /// Control ID for CustomField1StaticControl
            /// </summary>
            public const string CustomField1StaticControl = "labelC1";
            
            /// <summary>
            /// Control ID for CustomField10TextBox
            /// </summary>
            public const string CustomField10TextBox = "textBoxC10";
            
            /// <summary>
            /// Control ID for CustomField10StaticControl
            /// </summary>
            public const string CustomField10StaticControl = "labelC10";
            
            /// <summary>
            /// Control ID for CustomAlertFieldSettingsStaticControl
            /// </summary>
            public const string CustomAlertFieldSettingsStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic
            /// </summary>
            public const string CustomAlertFieldsAreUsedInAdvancedMonitoringScenariosToCollectAdditionalInformationAboutAProblemWhic = "labelDescription";
        }
        #endregion
    }
}
