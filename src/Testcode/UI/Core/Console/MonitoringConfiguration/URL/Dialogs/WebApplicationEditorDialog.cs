// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WebApplicationEditorDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 5/1/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IWebApplicationEditorDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWebApplicationEditorDialogControls, for WebApplicationEditorDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 5/1/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWebApplicationEditorDialogControls
    {
        /// <summary>
        /// Read-only property to access PropertyGridView
        /// </summary>
        PropertyGridView PropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitoringBrowserSessionsStaticControl
        /// </summary>
        StaticControl MonitoringBrowserSessionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl
        /// </summary>
        StaticControl GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl
        /// </summary>
        StaticControl GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl
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
        /// Read-only property to access ResponseTimeCheckBox
        /// </summary>
        CheckBox ResponseTimeCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HttpStatusCodeCheckBox
        /// </summary>
        CheckBox HttpStatusCodeCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox
        /// </summary>
        CheckBox StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanVerifyTheCriteriaByClickingVerifyComboBox
        /// </summary>
        ComboBox YouCanVerifyTheCriteriaByClickingVerifyComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox
        /// </summary>
        CheckBox GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox
        /// </summary>
        TextBox GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox
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
        /// Read-only property to access ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox
        /// </summary>
        TextBox ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WebApplicationLoadedSuccessfullyComboBox
        /// </summary>
        ComboBox WebApplicationLoadedSuccessfullyComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox
        /// </summary>
        ComboBox ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WebApplicationLoadedSuccessfullyTextBox
        /// </summary>
        TextBox WebApplicationLoadedSuccessfullyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContentMatchCheckBox
        /// </summary>
        CheckBox ContentMatchCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MillisecondsStaticControl
        /// </summary>
        StaticControl MillisecondsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HttptsetStaticControl
        /// </summary>
        StaticControl HttptsetStaticControl
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
        /// Read-only property to access ResponseTimeCheckBox2
        /// </summary>
        CheckBox ResponseTimeCheckBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HttpStatusCodeCheckBox2
        /// </summary>
        CheckBox HttpStatusCodeCheckBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox
        /// </summary>
        CheckBox StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox
        /// </summary>
        ComboBox GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox
        /// </summary>
        CheckBox GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox
        /// </summary>
        TextBox GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button4
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox6
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox6
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox7
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox7
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox8
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox8
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox9
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox9
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContentMatchCheckBox2
        /// </summary>
        CheckBox ContentMatchCheckBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MillisecondsStaticControl2
        /// </summary>
        StaticControl MillisecondsStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl
        /// </summary>
        StaticControl ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanVerifyTheCriteriaByClickingVerifyStaticControl
        /// </summary>
        StaticControl YouCanVerifyTheCriteriaByClickingVerifyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access VerifyButton
        /// </summary>
        Button VerifyButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiscardChangesButton
        /// </summary>
        Button DiscardChangesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WebApplicationLoadedSuccessfullyStaticControl
        /// </summary>
        StaticControl WebApplicationLoadedSuccessfullyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl5
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl5
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ActionsStaticControl
        /// </summary>
        StaticControl ActionsStaticControl
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
    /// 	[faizalk] 5/1/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WebApplicationEditorDialog : Dialog, IWebApplicationEditorDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringBrowserSessionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitoringBrowserSessionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to ResponseTimeCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedResponseTimeCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to HttpStatusCodeCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedHttpStatusCodeCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to YouCanVerifyTheCriteriaByClickingVerifyComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedYouCanVerifyTheCriteriaByClickingVerifyComboBox;
        
        /// <summary>
        /// Cache to hold a reference to GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedGenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox of type TextBox
        /// </summary>
        private TextBox cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox;
        
        /// <summary>
        /// Cache to hold a reference to Button2 of type Button
        /// </summary>
        private Button cachedButton2;
        
        /// <summary>
        /// Cache to hold a reference to ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox of type TextBox
        /// </summary>
        private TextBox cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to WebApplicationLoadedSuccessfullyComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedWebApplicationLoadedSuccessfullyComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to WebApplicationLoadedSuccessfullyTextBox of type TextBox
        /// </summary>
        private TextBox cachedWebApplicationLoadedSuccessfullyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ContentMatchCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedContentMatchCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MillisecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMillisecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HttptsetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHttptsetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button3 of type Button
        /// </summary>
        private Button cachedButton3;
        
        /// <summary>
        /// Cache to hold a reference to ResponseTimeCheckBox2 of type CheckBox
        /// </summary>
        private CheckBox cachedResponseTimeCheckBox2;
        
        /// <summary>
        /// Cache to hold a reference to HttpStatusCodeCheckBox2 of type CheckBox
        /// </summary>
        private CheckBox cachedHttpStatusCodeCheckBox2;
        
        /// <summary>
        /// Cache to hold a reference to StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox;
        
        /// <summary>
        /// Cache to hold a reference to GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedGenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox of type TextBox
        /// </summary>
        private TextBox cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox;
        
        /// <summary>
        /// Cache to hold a reference to Button4 of type Button
        /// </summary>
        private Button cachedButton4;
        
        /// <summary>
        /// Cache to hold a reference to TextBox6 of type TextBox
        /// </summary>
        private TextBox cachedTextBox6;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox7 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox7;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox8 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox8;
        
        /// <summary>
        /// Cache to hold a reference to TextBox9 of type TextBox
        /// </summary>
        private TextBox cachedTextBox9;
        
        /// <summary>
        /// Cache to hold a reference to ContentMatchCheckBox2 of type CheckBox
        /// </summary>
        private CheckBox cachedContentMatchCheckBox2;
        
        /// <summary>
        /// Cache to hold a reference to MillisecondsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedMillisecondsStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanVerifyTheCriteriaByClickingVerifyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanVerifyTheCriteriaByClickingVerifyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to VerifyButton of type Button
        /// </summary>
        private Button cachedVerifyButton;
        
        /// <summary>
        /// Cache to hold a reference to DiscardChangesButton of type Button
        /// </summary>
        private Button cachedDiscardChangesButton;
        
        /// <summary>
        /// Cache to hold a reference to WebApplicationLoadedSuccessfullyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWebApplicationLoadedSuccessfullyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl5 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl5;
        
        /// <summary>
        /// Cache to hold a reference to ActionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedActionsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WebApplicationEditorDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WebApplicationEditorDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IWebApplicationEditorDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWebApplicationEditorDialogControls Controls
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
        ///  Property to handle checkbox ResponseTime
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ResponseTime
        {
            get
            {
                return this.Controls.ResponseTimeCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ResponseTimeCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox HttpStatusCode
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool HttpStatusCode
        {
            get
            {
                return this.Controls.HttpStatusCodeCheckBox.Checked;
            }
            
            set
            {
                this.Controls.HttpStatusCodeCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet
        {
            get
            {
                return this.Controls.StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox.Checked;
            }
            
            set
            {
                this.Controls.StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox GenerateAnAlertIfAnyWarningCriteriaIsMet
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool GenerateAnAlertIfAnyWarningCriteriaIsMet
        {
            get
            {
                return this.Controls.GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox.Checked;
            }
            
            set
            {
                this.Controls.GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ContentMatch
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ContentMatch
        {
            get
            {
                return this.Controls.ContentMatchCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ContentMatchCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ResponseTime2
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ResponseTime2
        {
            get
            {
                return this.Controls.ResponseTimeCheckBox2.Checked;
            }
            
            set
            {
                this.Controls.ResponseTimeCheckBox2.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox HttpStatusCode2
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool HttpStatusCode2
        {
            get
            {
                return this.Controls.HttpStatusCodeCheckBox2.Checked;
            }
            
            set
            {
                this.Controls.HttpStatusCodeCheckBox2.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet
        {
            get
            {
                return this.Controls.StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox.Checked;
            }
            
            set
            {
                this.Controls.StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox GenerateAnAlertIfAnyErrorCriteriaIsMet
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool GenerateAnAlertIfAnyErrorCriteriaIsMet
        {
            get
            {
                return this.Controls.GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox.Checked;
            }
            
            set
            {
                this.Controls.GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ContentMatch2
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ContentMatch2
        {
            get
            {
                return this.Controls.ContentMatchCheckBox2.Checked;
            }
            
            set
            {
                this.Controls.ContentMatchCheckBox2.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control YouCanVerifyTheCriteriaByClickingVerify
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string YouCanVerifyTheCriteriaByClickingVerifyText
        {
            get
            {
                return this.Controls.YouCanVerifyTheCriteriaByClickingVerifyComboBox.Text;
            }
            
            set
            {
                this.Controls.YouCanVerifyTheCriteriaByClickingVerifyComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetText
        {
            get
            {
                return this.Controls.GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox.Text;
            }
            
            set
            {
                this.Controls.GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesText
        {
            get
            {
                return this.Controls.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox.Text;
            }
            
            set
            {
                this.Controls.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WebApplicationLoadedSuccessfully
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WebApplicationLoadedSuccessfullyText
        {
            get
            {
                return this.Controls.WebApplicationLoadedSuccessfullyComboBox.Text;
            }
            
            set
            {
                this.Controls.WebApplicationLoadedSuccessfullyComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges2Text
        {
            get
            {
                return this.Controls.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox.Text;
            }
            
            set
            {
                this.Controls.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WebApplicationLoadedSuccessfully2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WebApplicationLoadedSuccessfully2Text
        {
            get
            {
                return this.Controls.WebApplicationLoadedSuccessfullyTextBox.Text;
            }
            
            set
            {
                this.Controls.WebApplicationLoadedSuccessfullyTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetText
        {
            get
            {
                return this.Controls.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox.Text;
            }
            
            set
            {
                this.Controls.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet2Text
        {
            get
            {
                return this.Controls.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox.Text;
            }
            
            set
            {
                this.Controls.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox6
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox6Text
        {
            get
            {
                return this.Controls.TextBox6.Text;
            }
            
            set
            {
                this.Controls.TextBox6.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox7
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox7Text
        {
            get
            {
                return this.Controls.ComboBox7.Text;
            }
            
            set
            {
                this.Controls.ComboBox7.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox8
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox8Text
        {
            get
            {
                return this.Controls.ComboBox8.Text;
            }
            
            set
            {
                this.Controls.ComboBox8.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox9
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox9Text
        {
            get
            {
                return this.Controls.TextBox9.Text;
            }
            
            set
            {
                this.Controls.TextBox9.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertyGridView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IWebApplicationEditorDialogControls.PropertyGridView
        {
            get
            {
                if ((this.cachedPropertyGridView == null))
                {
                    this.cachedPropertyGridView = new PropertyGridView(this, WebApplicationEditorDialog.ControlIDs.PropertyGridView);
                }
                return this.cachedPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.StaticControl0);
                }
                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringBrowserSessionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.MonitoringBrowserSessionsStaticControl
        {
            get
            {
                if ((this.cachedMonitoringBrowserSessionsStaticControl == null))
                {
                    this.cachedMonitoringBrowserSessionsStaticControl = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.MonitoringBrowserSessionsStaticControl);
                }
                return this.cachedMonitoringBrowserSessionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl
        {
            get
            {
                if ((this.cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl == null))
                {
                    this.cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl);
                }
                return this.cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl
        {
            get
            {
                if ((this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl == null))
                {
                    this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl);
                }
                return this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWebApplicationEditorDialogControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, WebApplicationEditorDialog.ControlIDs.Button1);
                }
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseTimeCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.ResponseTimeCheckBox
        {
            get
            {
                if ((this.cachedResponseTimeCheckBox == null))
                {
                    this.cachedResponseTimeCheckBox = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.ResponseTimeCheckBox);
                }
                return this.cachedResponseTimeCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HttpStatusCodeCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.HttpStatusCodeCheckBox
        {
            get
            {
                if ((this.cachedHttpStatusCodeCheckBox == null))
                {
                    this.cachedHttpStatusCodeCheckBox = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.HttpStatusCodeCheckBox);
                }
                return this.cachedHttpStatusCodeCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox
        {
            get
            {
                if ((this.cachedStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox == null))
                {
                    this.cachedStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox);
                }
                return this.cachedStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanVerifyTheCriteriaByClickingVerifyComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWebApplicationEditorDialogControls.YouCanVerifyTheCriteriaByClickingVerifyComboBox
        {
            get
            {
                if ((this.cachedYouCanVerifyTheCriteriaByClickingVerifyComboBox == null))
                {
                    this.cachedYouCanVerifyTheCriteriaByClickingVerifyComboBox = new ComboBox(this, WebApplicationEditorDialog.ControlIDs.YouCanVerifyTheCriteriaByClickingVerifyComboBox);
                }
                return this.cachedYouCanVerifyTheCriteriaByClickingVerifyComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox
        {
            get
            {
                if ((this.cachedGenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox == null))
                {
                    this.cachedGenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox);
                }
                return this.cachedGenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWebApplicationEditorDialogControls.GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox
        {
            get
            {
                if ((this.cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox == null))
                {
                    this.cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox = new TextBox(this, WebApplicationEditorDialog.ControlIDs.GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox);
                }
                return this.cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWebApplicationEditorDialogControls.Button2
        {
            get
            {
                if ((this.cachedButton2 == null))
                {
                    this.cachedButton2 = new Button(this, WebApplicationEditorDialog.ControlIDs.Button2);
                }
                return this.cachedButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWebApplicationEditorDialogControls.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox
        {
            get
            {
                if ((this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox == null))
                {
                    this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox = new TextBox(this, WebApplicationEditorDialog.ControlIDs.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox);
                }
                return this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WebApplicationLoadedSuccessfullyComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWebApplicationEditorDialogControls.WebApplicationLoadedSuccessfullyComboBox
        {
            get
            {
                if ((this.cachedWebApplicationLoadedSuccessfullyComboBox == null))
                {
                    this.cachedWebApplicationLoadedSuccessfullyComboBox = new ComboBox(this, WebApplicationEditorDialog.ControlIDs.WebApplicationLoadedSuccessfullyComboBox);
                }
                return this.cachedWebApplicationLoadedSuccessfullyComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWebApplicationEditorDialogControls.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox
        {
            get
            {
                if ((this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox == null))
                {
                    this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox = new ComboBox(this, WebApplicationEditorDialog.ControlIDs.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox);
                }
                return this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WebApplicationLoadedSuccessfullyTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWebApplicationEditorDialogControls.WebApplicationLoadedSuccessfullyTextBox
        {
            get
            {
                if ((this.cachedWebApplicationLoadedSuccessfullyTextBox == null))
                {
                    this.cachedWebApplicationLoadedSuccessfullyTextBox = new TextBox(this, WebApplicationEditorDialog.ControlIDs.WebApplicationLoadedSuccessfullyTextBox);
                }
                return this.cachedWebApplicationLoadedSuccessfullyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContentMatchCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.ContentMatchCheckBox
        {
            get
            {
                if ((this.cachedContentMatchCheckBox == null))
                {
                    this.cachedContentMatchCheckBox = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.ContentMatchCheckBox);
                }
                return this.cachedContentMatchCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MillisecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.MillisecondsStaticControl
        {
            get
            {
                if ((this.cachedMillisecondsStaticControl == null))
                {
                    this.cachedMillisecondsStaticControl = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.MillisecondsStaticControl);
                }
                return this.cachedMillisecondsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HttptsetStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.HttptsetStaticControl
        {
            get
            {
                if ((this.cachedHttptsetStaticControl == null))
                {
                    this.cachedHttptsetStaticControl = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.HttptsetStaticControl);
                }
                return this.cachedHttptsetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button3 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWebApplicationEditorDialogControls.Button3
        {
            get
            {
                if ((this.cachedButton3 == null))
                {
                    this.cachedButton3 = new Button(this, WebApplicationEditorDialog.ControlIDs.Button3);
                }
                return this.cachedButton3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseTimeCheckBox2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.ResponseTimeCheckBox2
        {
            get
            {
                if ((this.cachedResponseTimeCheckBox2 == null))
                {
                    this.cachedResponseTimeCheckBox2 = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.ResponseTimeCheckBox2);
                }
                return this.cachedResponseTimeCheckBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HttpStatusCodeCheckBox2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.HttpStatusCodeCheckBox2
        {
            get
            {
                if ((this.cachedHttpStatusCodeCheckBox2 == null))
                {
                    this.cachedHttpStatusCodeCheckBox2 = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.HttpStatusCodeCheckBox2);
                }
                return this.cachedHttpStatusCodeCheckBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox
        {
            get
            {
                if ((this.cachedStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox == null))
                {
                    this.cachedStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox);
                }
                return this.cachedStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWebApplicationEditorDialogControls.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox
        {
            get
            {
                if ((this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox == null))
                {
                    this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox = new ComboBox(this, WebApplicationEditorDialog.ControlIDs.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox);
                }
                return this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox
        {
            get
            {
                if ((this.cachedGenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox == null))
                {
                    this.cachedGenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox);
                }
                return this.cachedGenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWebApplicationEditorDialogControls.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox
        {
            get
            {
                if ((this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox == null))
                {
                    this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox = new TextBox(this, WebApplicationEditorDialog.ControlIDs.GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox);
                }
                return this.cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button4 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWebApplicationEditorDialogControls.Button4
        {
            get
            {
                if ((this.cachedButton4 == null))
                {
                    this.cachedButton4 = new Button(this, WebApplicationEditorDialog.ControlIDs.Button4);
                }
                return this.cachedButton4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox6 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWebApplicationEditorDialogControls.TextBox6
        {
            get
            {
                if ((this.cachedTextBox6 == null))
                {
                    this.cachedTextBox6 = new TextBox(this, WebApplicationEditorDialog.ControlIDs.TextBox6);
                }
                return this.cachedTextBox6;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox7 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWebApplicationEditorDialogControls.ComboBox7
        {
            get
            {
                if ((this.cachedComboBox7 == null))
                {
                    this.cachedComboBox7 = new ComboBox(this, WebApplicationEditorDialog.ControlIDs.ComboBox7);
                }
                return this.cachedComboBox7;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox8 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWebApplicationEditorDialogControls.ComboBox8
        {
            get
            {
                if ((this.cachedComboBox8 == null))
                {
                    this.cachedComboBox8 = new ComboBox(this, WebApplicationEditorDialog.ControlIDs.ComboBox8);
                }
                return this.cachedComboBox8;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox9 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWebApplicationEditorDialogControls.TextBox9
        {
            get
            {
                if ((this.cachedTextBox9 == null))
                {
                    this.cachedTextBox9 = new TextBox(this, WebApplicationEditorDialog.ControlIDs.TextBox9);
                }
                return this.cachedTextBox9;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContentMatchCheckBox2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWebApplicationEditorDialogControls.ContentMatchCheckBox2
        {
            get
            {
                if ((this.cachedContentMatchCheckBox2 == null))
                {
                    this.cachedContentMatchCheckBox2 = new CheckBox(this, WebApplicationEditorDialog.ControlIDs.ContentMatchCheckBox2);
                }
                return this.cachedContentMatchCheckBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MillisecondsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.MillisecondsStaticControl2
        {
            get
            {
                if ((this.cachedMillisecondsStaticControl2 == null))
                {
                    this.cachedMillisecondsStaticControl2 = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.MillisecondsStaticControl2);
                }
                return this.cachedMillisecondsStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl
        {
            get
            {
                if ((this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl == null))
                {
                    this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl);
                }
                return this.cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanVerifyTheCriteriaByClickingVerifyStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.YouCanVerifyTheCriteriaByClickingVerifyStaticControl
        {
            get
            {
                if ((this.cachedYouCanVerifyTheCriteriaByClickingVerifyStaticControl == null))
                {
                    this.cachedYouCanVerifyTheCriteriaByClickingVerifyStaticControl = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.YouCanVerifyTheCriteriaByClickingVerifyStaticControl);
                }
                return this.cachedYouCanVerifyTheCriteriaByClickingVerifyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VerifyButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWebApplicationEditorDialogControls.VerifyButton
        {
            get
            {
                if ((this.cachedVerifyButton == null))
                {
                    this.cachedVerifyButton = new Button(this, WebApplicationEditorDialog.ControlIDs.VerifyButton);
                }
                return this.cachedVerifyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscardChangesButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWebApplicationEditorDialogControls.DiscardChangesButton
        {
            get
            {
                if ((this.cachedDiscardChangesButton == null))
                {
                    this.cachedDiscardChangesButton = new Button(this, WebApplicationEditorDialog.ControlIDs.DiscardChangesButton);
                }
                return this.cachedDiscardChangesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WebApplicationLoadedSuccessfullyStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.WebApplicationLoadedSuccessfullyStaticControl
        {
            get
            {
                if ((this.cachedWebApplicationLoadedSuccessfullyStaticControl == null))
                {
                    this.cachedWebApplicationLoadedSuccessfullyStaticControl = new StaticControl(this, WebApplicationEditorDialog.ControlIDs.WebApplicationLoadedSuccessfullyStaticControl);
                }
                return this.cachedWebApplicationLoadedSuccessfullyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWebApplicationEditorDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, WebApplicationEditorDialog.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl5 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.StaticControl5
        {
            get
            {
                // The ID for this control (rightLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedStaticControl5 == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedStaticControl5 = new StaticControl(wndTemp);
                }
                return this.cachedStaticControl5;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ActionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWebApplicationEditorDialogControls.ActionsStaticControl
        {
            get
            {
                // The ID for this control (leftLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedActionsStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedActionsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedActionsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ResponseTime
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickResponseTime()
        {
            this.Controls.ResponseTimeCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button HttpStatusCode
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHttpStatusCode()
        {
            this.Controls.HttpStatusCodeCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet()
        {
            this.Controls.StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GenerateAnAlertIfAnyWarningCriteriaIsMet
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGenerateAnAlertIfAnyWarningCriteriaIsMet()
        {
            this.Controls.GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button2
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton2()
        {
            this.Controls.Button2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ContentMatch
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickContentMatch()
        {
            this.Controls.ContentMatchCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button3
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton3()
        {
            this.Controls.Button3.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ResponseTime2
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickResponseTime2()
        {
            this.Controls.ResponseTimeCheckBox2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button HttpStatusCode2
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHttpStatusCode2()
        {
            this.Controls.HttpStatusCodeCheckBox2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet()
        {
            this.Controls.StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GenerateAnAlertIfAnyErrorCriteriaIsMet
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGenerateAnAlertIfAnyErrorCriteriaIsMet()
        {
            this.Controls.GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button4
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton4()
        {
            this.Controls.Button4.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ContentMatch2
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickContentMatch2()
        {
            this.Controls.ContentMatchCheckBox2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Verify
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickVerify()
        {
            this.Controls.VerifyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DiscardChanges
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDiscardChanges()
        {
            this.Controls.DiscardChangesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }        
            catch (Exceptions.WindowNotFoundException)
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
                                 app.GetIntlStr(Strings.DialogTitle) + "*",
                                 StringMatchSyntax.WildCard,
                                 WindowClassNames.WinForms10Window8,
                                 StringMatchSyntax.WildCard,
                                 app,
                                 Timeout);
                 
                         // wait for the window to report ready
                         UISynchronization.WaitForUIObjectReady(
                             tempWindow,
                             Timeout);
                     }
                     catch (Exceptions.WindowNotFoundException)
                     {
                         // log the unsuccessful attempt
                     }
                 }
                 
                 // check for success
                 if (tempWindow == null)
                 {
                     // log the failure
                 
                     // throw the existing WindowNotFound exception
                     throw;
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
        /// 	[faizalk] 5/1/2006 Created
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
            private const string ResourceDialogTitle = ";Web Application Editor;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResources;WebApplicationEditor";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitoringBrowserSessions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringBrowserSessions = ";Monitoring browser sessions;ManagedString;Microsoft.MOM.UI.Components.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.WebApp" +
                ".WebApplicationEditorForm;paneTitleHeaderControlMonitoring.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet = @";Generate &warning monitoring health status when the criteria bellow is met:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;labelGenerateWarningR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet = @";Generate &error  monitoring health status when the criteria bellow is met:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;labelGenerateErrorR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResponseTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResponseTime = ";Response Time:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.WebApp.WebApplicati" +
                "onEditorForm;checkBoxErrorResponseTimeR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HttpStatusCode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHttpStatusCode = ";Http Status Code:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.WebApp.WebApplic" +
                "ationEditorForm;checkBoxWarningHTTPR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet = @";      Stop processing the subsequent requests if any warning criteria is met.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;checkBoxWarningStopRequestR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GenerateAnAlertIfAnyWarningCriteriaIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGenerateAnAlertIfAnyWarningCriteriaIsMet = ";Generate an alert if any warning criteria is met.;ManagedString;Microsoft.MOM.UI" +
                ".Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages" +
                "s.WebApplicationEditor.WebApplicationEditorForm;checkBoxWarningGenerateAlertR.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ContentMatch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContentMatch = ";Content Match:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.WebApp.WebApplicati" +
                "onEditorForm;checkBoxWarningContentMatchR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Milliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMilliseconds = ";Milliseconds;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.WebApp.WebApplication" +
                "EditorForm;labelErrorResponseTime.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Httptset
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceHttptset = "http://tset";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResponseTime2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResponseTime2 = ";Response Time:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.WebApp.WebApplicati" +
                "onEditorForm;checkBoxErrorResponseTimeR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HttpStatusCode2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHttpStatusCode2 = ";Http Status Code:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.WebApp.WebApplic" +
                "ationEditorForm;checkBoxWarningHTTPR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet = @";      Stop processing the subsequent requests any error criteria is met.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;checkBoxErrorStopRequestR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GenerateAnAlertIfAnyErrorCriteriaIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGenerateAnAlertIfAnyErrorCriteriaIsMet = ";Generate an alert if any error criteria is met.;ManagedString;Microsoft.MOM.UI.C" +
                "omponents.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages." +
                "WebApplicationEditor.WebApplicationEditorForm;checkBoxErrorGenerateAlertR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ContentMatch2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContentMatch2 = ";Content Match:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.WebApp.WebApplicati" +
                "onEditorForm;checkBoxWarningContentMatchR.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Milliseconds2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMilliseconds2 = ";Milliseconds;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.WebApp.WebApplication" +
                "EditorForm;labelErrorResponseTime.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges = @";To discard your changes and edit another request, click Discard Changes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;labelRequestStatusSecondLine.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanVerifyTheCriteriaByClickingVerify
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanVerifyTheCriteriaByClickingVerify = ";You can verify the criteria by clicking Verify;ManagedString;Microsoft.MOM.UI." +
                "Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages" +
                ".WebApplicationEditor.WebApplicationEditorForm;labelRequestStatusFirstLine.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Verify
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceVerify = ";&Verify;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.WebApp.WebApplicationEdito" +
                "rForm;buttonValidateStore.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscardChanges
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscardChanges = ";Discard &Changes;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.WebApp.WebApplica" +
                "tionEditorForm;buttonCancelEditing.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WebApplicationLoadedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebApplicationLoadedSuccessfully =";Web application loaded successfully!"+
                ";ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;"
                + "Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResources;LoadWebApplicationSucceeded";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;DC01.bQ;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Actions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceActions = ";Actions;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;AdminViewGroup";
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
            /// Caches the translated resource string for:  MonitoringBrowserSessions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringBrowserSessions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResponseTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResponseTime;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HttpStatusCode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHttpStatusCode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GenerateAnAlertIfAnyWarningCriteriaIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGenerateAnAlertIfAnyWarningCriteriaIsMet;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContentMatch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContentMatch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Milliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMilliseconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Httptset
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHttptset;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResponseTime2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResponseTime2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HttpStatusCode2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHttpStatusCode2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GenerateAnAlertIfAnyErrorCriteriaIsMet
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGenerateAnAlertIfAnyErrorCriteriaIsMet;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContentMatch2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContentMatch2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Milliseconds2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMilliseconds2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanVerifyTheCriteriaByClickingVerify
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanVerifyTheCriteriaByClickingVerify;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Verify
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedVerify;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscardChanges
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscardChanges;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WebApplicationLoadedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebApplicationLoadedSuccessfully;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Actions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActions;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
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
            /// Exposes access to the MonitoringBrowserSessions translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringBrowserSessions
            {
                get
                {
                    if ((cachedMonitoringBrowserSessions == null))
                    {
                        cachedMonitoringBrowserSessions = CoreManager.MomConsole.GetIntlStr(ResourceMonitoringBrowserSessions);
                    }
                    return cachedMonitoringBrowserSessions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet
            {
                get
                {
                    if ((cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet == null))
                    {
                        cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet = CoreManager.MomConsole.GetIntlStr(ResourceGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet);
                    }
                    return cachedGenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMet;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet
            {
                get
                {
                    if ((cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet == null))
                    {
                        cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet = CoreManager.MomConsole.GetIntlStr(ResourceGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet);
                    }
                    return cachedGenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMet;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResponseTime translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResponseTime
            {
                get
                {
                    if ((cachedResponseTime == null))
                    {
                        cachedResponseTime = CoreManager.MomConsole.GetIntlStr(ResourceResponseTime);
                    }
                    return cachedResponseTime;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HttpStatusCode translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HttpStatusCode
            {
                get
                {
                    if ((cachedHttpStatusCode == null))
                    {
                        cachedHttpStatusCode = CoreManager.MomConsole.GetIntlStr(ResourceHttpStatusCode);
                    }
                    return cachedHttpStatusCode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet
            {
                get
                {
                    if ((cachedStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet == null))
                    {
                        cachedStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet = CoreManager.MomConsole.GetIntlStr(ResourceStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet);
                    }
                    return cachedStopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMet;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GenerateAnAlertIfAnyWarningCriteriaIsMet translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GenerateAnAlertIfAnyWarningCriteriaIsMet
            {
                get
                {
                    if ((cachedGenerateAnAlertIfAnyWarningCriteriaIsMet == null))
                    {
                        cachedGenerateAnAlertIfAnyWarningCriteriaIsMet = CoreManager.MomConsole.GetIntlStr(ResourceGenerateAnAlertIfAnyWarningCriteriaIsMet);
                    }
                    return cachedGenerateAnAlertIfAnyWarningCriteriaIsMet;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContentMatch translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContentMatch
            {
                get
                {
                    if ((cachedContentMatch == null))
                    {
                        cachedContentMatch = CoreManager.MomConsole.GetIntlStr(ResourceContentMatch);
                    }
                    return cachedContentMatch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Milliseconds translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Milliseconds
            {
                get
                {
                    if ((cachedMilliseconds == null))
                    {
                        cachedMilliseconds = CoreManager.MomConsole.GetIntlStr(ResourceMilliseconds);
                    }
                    return cachedMilliseconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Httptset translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Httptset
            {
                get
                {
                    if ((cachedHttptset == null))
                    {
                        cachedHttptset = CoreManager.MomConsole.GetIntlStr(ResourceHttptset);
                    }
                    return cachedHttptset;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResponseTime2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResponseTime2
            {
                get
                {
                    if ((cachedResponseTime2 == null))
                    {
                        cachedResponseTime2 = CoreManager.MomConsole.GetIntlStr(ResourceResponseTime2);
                    }
                    return cachedResponseTime2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HttpStatusCode2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HttpStatusCode2
            {
                get
                {
                    if ((cachedHttpStatusCode2 == null))
                    {
                        cachedHttpStatusCode2 = CoreManager.MomConsole.GetIntlStr(ResourceHttpStatusCode2);
                    }
                    return cachedHttpStatusCode2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet
            {
                get
                {
                    if ((cachedStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet == null))
                    {
                        cachedStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet = CoreManager.MomConsole.GetIntlStr(ResourceStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet);
                    }
                    return cachedStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GenerateAnAlertIfAnyErrorCriteriaIsMet translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GenerateAnAlertIfAnyErrorCriteriaIsMet
            {
                get
                {
                    if ((cachedGenerateAnAlertIfAnyErrorCriteriaIsMet == null))
                    {
                        cachedGenerateAnAlertIfAnyErrorCriteriaIsMet = CoreManager.MomConsole.GetIntlStr(ResourceGenerateAnAlertIfAnyErrorCriteriaIsMet);
                    }
                    return cachedGenerateAnAlertIfAnyErrorCriteriaIsMet;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContentMatch2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContentMatch2
            {
                get
                {
                    if ((cachedContentMatch2 == null))
                    {
                        cachedContentMatch2 = CoreManager.MomConsole.GetIntlStr(ResourceContentMatch2);
                    }
                    return cachedContentMatch2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Milliseconds2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Milliseconds2
            {
                get
                {
                    if ((cachedMilliseconds2 == null))
                    {
                        cachedMilliseconds2 = CoreManager.MomConsole.GetIntlStr(ResourceMilliseconds2);
                    }
                    return cachedMilliseconds2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges
            {
                get
                {
                    if ((cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges == null))
                    {
                        cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges = CoreManager.MomConsole.GetIntlStr(ResourceToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges);
                    }
                    return cachedToDiscardYourChangesAndEditAnotherRequestClickDiscardChanges;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanVerifyTheCriteriaByClickingVerify translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanVerifyTheCriteriaByClickingVerify
            {
                get
                {
                    if ((cachedYouCanVerifyTheCriteriaByClickingVerify == null))
                    {
                        cachedYouCanVerifyTheCriteriaByClickingVerify = CoreManager.MomConsole.GetIntlStr(ResourceYouCanVerifyTheCriteriaByClickingVerify);
                    }
                    return cachedYouCanVerifyTheCriteriaByClickingVerify;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Verify translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Verify
            {
                get
                {
                    if ((cachedVerify == null))
                    {
                        cachedVerify = CoreManager.MomConsole.GetIntlStr(ResourceVerify);
                    }
                    return cachedVerify;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiscardChanges translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscardChanges
            {
                get
                {
                    if ((cachedDiscardChanges == null))
                    {
                        cachedDiscardChanges = CoreManager.MomConsole.GetIntlStr(ResourceDiscardChanges);
                    }
                    return cachedDiscardChanges;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebApplicationLoadedSuccessfully translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebApplicationLoadedSuccessfully
            {
                get
                {
                    if ((cachedWebApplicationLoadedSuccessfully == null))
                    {
                        cachedWebApplicationLoadedSuccessfully = CoreManager.MomConsole.GetIntlStr(ResourceWebApplicationLoadedSuccessfully);
                    }
                    return cachedWebApplicationLoadedSuccessfully;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
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
            /// Exposes access to the Actions translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/1/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Actions
            {
                get
                {
                    if ((cachedActions == null))
                    {
                        cachedActions = CoreManager.MomConsole.GetIntlStr(ResourceActions);
                    }
                    return cachedActions;
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
        /// 	[faizalk] 5/1/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PropertyGridView
            /// </summary>
            public const string PropertyGridView = "gridControl";
            
            /// <summary>
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl0 = "rightLabel";
            
            /// <summary>
            /// Control ID for MonitoringBrowserSessionsStaticControl
            /// </summary>
            public const string MonitoringBrowserSessionsStaticControl = "leftLabel";
            
            /// <summary>
            /// Control ID for GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl
            /// </summary>
            public const string GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl = "labelGenerateWarningR";
            
            /// <summary>
            /// Control ID for GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl
            /// </summary>
            public const string GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetStaticControl = "labelGenerateErrorR";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "buttonWarningContentMatchR";
            
            /// <summary>
            /// Control ID for ResponseTimeCheckBox
            /// </summary>
            public const string ResponseTimeCheckBox = "checkBoxWarningResponseTimeR";
            
            /// <summary>
            /// Control ID for HttpStatusCodeCheckBox
            /// </summary>
            public const string HttpStatusCodeCheckBox = "checkBoxWarningHTTPR";
            
            /// <summary>
            /// Control ID for StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox
            /// </summary>
            public const string StopProcessingTheSubsequentRequestsIfAnyWarningCriteriaIsMetCheckBox = "checkBoxWarningStopRequestR";
            
            /// <summary>
            /// Control ID for YouCanVerifyTheCriteriaByClickingVerifyComboBox
            /// </summary>
            public const string YouCanVerifyTheCriteriaByClickingVerifyComboBox = "comboBoxWarningHTTPR";
            
            /// <summary>
            /// Control ID for GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox
            /// </summary>
            public const string GenerateAnAlertIfAnyWarningCriteriaIsMetCheckBox = "checkBoxWarningGenerateAlertR";
            
            /// <summary>
            /// Control ID for GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox
            /// </summary>
            public const string GenerateWarningMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox = "textBoxWarningHTTPR";
            
            /// <summary>
            /// Control ID for Button2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button2 = "buttonWarningHTTPR";
            
            /// <summary>
            /// Control ID for ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox
            /// </summary>
            public const string ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesTextBox = "textBoxWarningContentMatchR";
            
            /// <summary>
            /// Control ID for WebApplicationLoadedSuccessfullyComboBox
            /// </summary>
            public const string WebApplicationLoadedSuccessfullyComboBox = "comboBoxWarningResponseTimeR";
            
            /// <summary>
            /// Control ID for ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox
            /// </summary>
            public const string ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesComboBox = "comboBoxWarningContentMatchR";
            
            /// <summary>
            /// Control ID for WebApplicationLoadedSuccessfullyTextBox
            /// </summary>
            public const string WebApplicationLoadedSuccessfullyTextBox = "textBoxWarningResponseTimeR";
            
            /// <summary>
            /// Control ID for ContentMatchCheckBox
            /// </summary>
            public const string ContentMatchCheckBox = "checkBoxWarningContentMatchR";
            
            /// <summary>
            /// Control ID for MillisecondsStaticControl
            /// </summary>
            public const string MillisecondsStaticControl = "labelWarningResponseTimeR";
            
            /// <summary>
            /// Control ID for HttptsetStaticControl
            /// </summary>
            public const string HttptsetStaticControl = "labelSelectionDetailR";
            
            /// <summary>
            /// Control ID for Button3
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button3 = "buttonErrorContentMatchR";
            
            /// <summary>
            /// Control ID for ResponseTimeCheckBox2
            /// </summary>
            public const string ResponseTimeCheckBox2 = "checkBoxErrorResponseTimeR";
            
            /// <summary>
            /// Control ID for HttpStatusCodeCheckBox2
            /// </summary>
            public const string HttpStatusCodeCheckBox2 = "checkBoxErrorHTTPR";
            
            /// <summary>
            /// Control ID for StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox
            /// </summary>
            public const string StopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMetCheckBox = "checkBoxErrorStopRequestR";
            
            /// <summary>
            /// Control ID for GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox
            /// </summary>
            public const string GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetComboBox = "comboBoxErrorHTTPR";
            
            /// <summary>
            /// Control ID for GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox
            /// </summary>
            public const string GenerateAnAlertIfAnyErrorCriteriaIsMetCheckBox = "checkBoxErrorGenerateAlertR";
            
            /// <summary>
            /// Control ID for GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox
            /// </summary>
            public const string GenerateErrorMonitoringHealthStatusWhenTheCriteriaBellowIsMetTextBox = "textBoxErrorHTTPR";
            
            /// <summary>
            /// Control ID for Button4
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button4 = "buttonErrorHTTPR";
            
            /// <summary>
            /// Control ID for TextBox6
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox6 = "textBoxErrorContentMatchR";
            
            /// <summary>
            /// Control ID for ComboBox7
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox7 = "comboBoxErrorResponseTimeR";
            
            /// <summary>
            /// Control ID for ComboBox8
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox8 = "comboBoxErrorContentMatchR";
            
            /// <summary>
            /// Control ID for TextBox9
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox9 = "textBoxErrorResponseTimeR";
            
            /// <summary>
            /// Control ID for ContentMatchCheckBox2
            /// </summary>
            public const string ContentMatchCheckBox2 = "checkBoxErrorContentMatchR";
            
            /// <summary>
            /// Control ID for MillisecondsStaticControl2
            /// </summary>
            public const string MillisecondsStaticControl2 = "labelErrorResponseTime";
            
            /// <summary>
            /// Control ID for ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl
            /// </summary>
            public const string ToDiscardYourChangesAndEditAnotherRequestClickDiscardChangesStaticControl = "labelRequestStatusSecondLine";
            
            /// <summary>
            /// Control ID for YouCanVerifyTheCriteriaByClickingVerifyStaticControl
            /// </summary>
            public const string YouCanVerifyTheCriteriaByClickingVerifyStaticControl = "labelRequestStatusFirstLine";
            
            /// <summary>
            /// Control ID for VerifyButton
            /// </summary>
            public const string VerifyButton = "buttonValidateStore";
            
            /// <summary>
            /// Control ID for DiscardChangesButton
            /// </summary>
            public const string DiscardChangesButton = "buttonCancelEditing";
            
            /// <summary>
            /// Control ID for WebApplicationLoadedSuccessfullyStaticControl
            /// </summary>
            public const string WebApplicationLoadedSuccessfullyStaticControl = "labelStatus";
            
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "buttonStatusApply";
            
            /// <summary>
            /// Control ID for StaticControl5
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl5 = "rightLabel";
            
            /// <summary>
            /// Control ID for ActionsStaticControl
            /// </summary>
            public const string ActionsStaticControl = "leftLabel";
        }
        #endregion
    }
}
