// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertPropertiesGeneralDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 9/20/2006 Created
//  [Ruhim]  26May08   Adding TextBox Control for AlertDescription    
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAlertPropertiesGeneralDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertPropertiesGeneralDialogControls, for AlertPropertiesGeneralDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 9/20/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertPropertiesGeneralDialogControls
    {
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
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
        
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralTabControl
        /// </summary>
        TabControl GeneralTabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RepeatCountContentStaticControl
        /// </summary>
        StaticControl RepeatCountContentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RepeatCountStaticControl
        /// </summary>
        StaticControl RepeatCountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TicketID
        /// </summary>
        TextBox TicketID
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AlertDescription Text
        /// </summary>
        TextBox AlertDescriptionText
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TicketIDStaticControl
        /// </summary>
        StaticControl TicketIDStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OwnerContentTextBox
        /// </summary>
        TextBox OwnerContentTextBox
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
        /// Read-only property to access ResolutionStateCombo
        /// </summary>
        ComboBox ResolutionStateCombo
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OwnerStaticControl
        /// </summary>
        StaticControl OwnerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertStatusStaticControl
        /// </summary>
        StaticControl AlertStatusStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertDescriptionStaticControl
        /// </summary>
        StaticControl AlertDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KeyDetailsStaticControl
        /// </summary>
        StaticControl KeyDetailsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgeContentStaticControl
        /// </summary>
        StaticControl AgeContentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SeverityContentStaticControl
        /// </summary>
        StaticControl SeverityContentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SourceContentStaticControl
        /// </summary>
        StaticControl SourceContentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgeStaticControl
        /// </summary>
        StaticControl AgeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertSeverityStaticControl
        /// </summary>
        StaticControl AlertSeverityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertSourceStaticControl
        /// </summary>
        StaticControl AlertSourceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceRunningStateStaticControl
        /// </summary>
        StaticControl ServiceRunningStateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertDescription
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl AlertDescription
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertStatusContent
        /// </summary>
        StaticControl AlertStatusContent
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
    /// 	[lucyra] 9/20/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertPropertiesGeneralDialog : Dialog, IAlertPropertiesGeneralDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 1;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to GeneralTabControl of type TabControl
        /// </summary>
        private TabControl cachedGeneralTabControl;
        
        /// <summary>
        /// Cache to hold a reference to RepeatCountContentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRepeatCountContentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RepeatCountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRepeatCountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TicketID of type TextBox
        /// </summary>
        private TextBox cachedTicketID;

        /// <summary>
        /// Cache to hold a reference to AlertDescription Text of type TextBox
        /// </summary>
        private TextBox cachedAlertDescriptionText;
        
        /// <summary>
        /// Cache to hold a reference to TicketIDStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTicketIDStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OwnerContentTextBox of type TextBox
        /// </summary>
        private TextBox cachedOwnerContentTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ChangeButton of type Button
        /// </summary>
        private Button cachedChangeButton;
        
        /// <summary>
        /// Cache to hold a reference to ResolutionStateCombo of type ComboBox
        /// </summary>
        private ComboBox cachedResolutionStateCombo;
        
        /// <summary>
        /// Cache to hold a reference to OwnerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOwnerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertStatusStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertStatusStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KeyDetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKeyDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgeContentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgeContentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SeverityContentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSeverityContentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SourceContentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSourceContentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertSeverityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertSeverityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertSourceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertSourceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceRunningStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceRunningStateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertDescription of type StaticControl
        /// </summary>
        private StaticControl cachedAlertDescription;
        
        /// <summary>
        /// Cache to hold a reference to AlertStatusContent of type StaticControl
        /// </summary>
        private StaticControl cachedAlertStatusContent;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertPropertiesGeneralDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertPropertiesGeneralDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertPropertiesGeneralDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertPropertiesGeneralDialogControls Controls
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
        ///  Routine to set/get the text in control TicketID
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TicketIDText
        {
            get
            {
                return this.Controls.TicketID.Text;
            }
            
            set
            {
                this.Controls.TicketID.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AlertDescriptionText
        /// </summary>
        /// <value>AlertDescription Text</value>
        /// <history>
        /// 	[ruhim] 26May08 Created
        /// 	[v-vijia] 26Sep11 Edited
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AlertDescriptionText
        {
            get
            {
                //Bug#227057
                return this.Controls.AlertDescriptionText.ScreenElement.Name;
            }

            set
            {
                this.Controls.AlertDescriptionText.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control OwnerContent
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string OwnerContentText
        {
            get
            {
                return this.Controls.OwnerContentTextBox.Text;
            }
            
            set
            {
                this.Controls.OwnerContentTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ResolutionStateCombo
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ResolutionStateComboText
        {
            get
            {
                return this.Controls.ResolutionStateCombo.Text;
            }
            
            set
            {
                this.Controls.ResolutionStateCombo.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesGeneralDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AlertPropertiesGeneralDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesGeneralDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AlertPropertiesGeneralDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesGeneralDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertPropertiesGeneralDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesGeneralDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertPropertiesGeneralDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesGeneralDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertPropertiesGeneralDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralTabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertPropertiesGeneralDialogControls.GeneralTabControl
        {
            get
            {
                if ((this.cachedGeneralTabControl == null))
                {
                    this.cachedGeneralTabControl = new TabControl(this, AlertPropertiesGeneralDialog.ControlIDs.GeneralTabControl);
                }
                
                return this.cachedGeneralTabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RepeatCountContentStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.RepeatCountContentStaticControl
        {
            get
            {
                if ((this.cachedRepeatCountContentStaticControl == null))
                {
                    this.cachedRepeatCountContentStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.RepeatCountContentStaticControl);
                }
                
                return this.cachedRepeatCountContentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RepeatCountStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.RepeatCountStaticControl
        {
            get
            {
                if ((this.cachedRepeatCountStaticControl == null))
                {
                    this.cachedRepeatCountStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.RepeatCountStaticControl);
                }
                
                return this.cachedRepeatCountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TicketID control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesGeneralDialogControls.TicketID
        {
            get
            {
                if ((this.cachedTicketID == null))
                {
                    CoreManager.MomConsole.Waiters.WaitForWindowAppeared(this,new QID(";[UIA]AutomationId='"+AlertPropertiesGeneralDialog.ControlIDs.TicketID+"'"),Core.Common.Constants.OneSecond * 10);
                    this.cachedTicketID = new TextBox(this, AlertPropertiesGeneralDialog.ControlIDs.TicketID);
                }
                
                return this.cachedTicketID;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionText control
        /// </summary>
        /// <history>
        /// 	[ruhim] 26May08 Created
        /// 	[v-vijia] 26Sep11 Edited
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesGeneralDialogControls.AlertDescriptionText
        {
            get
            {
                if ((this.cachedAlertDescriptionText == null))
                {
                    //Bug#227057
                    QID queryId = new QID(";[UIA]AutomationId='"+AlertPropertiesGeneralDialog.ControlIDs.AlertDescription+"';Role = 'editable text'");
                    this.cachedAlertDescriptionText = new TextBox(this, queryId, 5000);
                }

                return this.cachedAlertDescriptionText;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TicketIDStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.TicketIDStaticControl
        {
            get
            {
                if ((this.cachedTicketIDStaticControl == null))
                {
                    this.cachedTicketIDStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.TicketIDStaticControl);
                }
                
                return this.cachedTicketIDStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OwnerContentTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertPropertiesGeneralDialogControls.OwnerContentTextBox
        {
            get
            {
                if ((this.cachedOwnerContentTextBox == null))
                {
                    this.cachedOwnerContentTextBox = new TextBox(this, AlertPropertiesGeneralDialog.ControlIDs.OwnerContentTextBox);
                }
                
                return this.cachedOwnerContentTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChangeButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPropertiesGeneralDialogControls.ChangeButton
        {
            get
            {
                if ((this.cachedChangeButton == null))
                {
                    this.cachedChangeButton = new Button(this, AlertPropertiesGeneralDialog.ControlIDs.ChangeButton);
                }
                
                return this.cachedChangeButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolutionStateCombo control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertPropertiesGeneralDialogControls.ResolutionStateCombo
        {
            get
            {
                if ((this.cachedResolutionStateCombo == null))
                {
                    this.cachedResolutionStateCombo = new ComboBox(this, AlertPropertiesGeneralDialog.ControlIDs.ResolutionStateCombo);
                }
                
                return this.cachedResolutionStateCombo;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OwnerStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.OwnerStaticControl
        {
            get
            {
                if ((this.cachedOwnerStaticControl == null))
                {
                    this.cachedOwnerStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.OwnerStaticControl);
                }
                
                return this.cachedOwnerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertStatusStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.AlertStatusStaticControl
        {
            get
            {
                if ((this.cachedAlertStatusStaticControl == null))
                {
                    this.cachedAlertStatusStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.AlertStatusStaticControl);
                }
                
                return this.cachedAlertStatusStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.AlertDescriptionStaticControl
        {
            get
            {
                if ((this.cachedAlertDescriptionStaticControl == null))
                {
                    this.cachedAlertDescriptionStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.AlertDescriptionStaticControl);
                }
                
                return this.cachedAlertDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KeyDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.KeyDetailsStaticControl
        {
            get
            {
                if ((this.cachedKeyDetailsStaticControl == null))
                {
                    this.cachedKeyDetailsStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.KeyDetailsStaticControl);
                }
                
                return this.cachedKeyDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgeContentStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.AgeContentStaticControl
        {
            get
            {
                if ((this.cachedAgeContentStaticControl == null))
                {
                    this.cachedAgeContentStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.AgeContentStaticControl);
                }
                
                return this.cachedAgeContentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SeverityContentStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.SeverityContentStaticControl
        {
            get
            {
                if ((this.cachedSeverityContentStaticControl == null))
                {
                    this.cachedSeverityContentStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.SeverityContentStaticControl);
                }
                
                return this.cachedSeverityContentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SourceContentStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.SourceContentStaticControl
        {
            get
            {
                if ((this.cachedSourceContentStaticControl == null))
                {
                    this.cachedSourceContentStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.SourceContentStaticControl);
                }
                
                return this.cachedSourceContentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgeStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.AgeStaticControl
        {
            get
            {
                if ((this.cachedAgeStaticControl == null))
                {
                    this.cachedAgeStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.AgeStaticControl);
                }
                
                return this.cachedAgeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertSeverityStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.AlertSeverityStaticControl
        {
            get
            {
                if ((this.cachedAlertSeverityStaticControl == null))
                {
                    this.cachedAlertSeverityStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.AlertSeverityStaticControl);
                }
                
                return this.cachedAlertSeverityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertSourceStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.AlertSourceStaticControl
        {
            get
            {
                if ((this.cachedAlertSourceStaticControl == null))
                {
                    this.cachedAlertSourceStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.AlertSourceStaticControl);
                }
                
                return this.cachedAlertSourceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceRunningStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.ServiceRunningStateStaticControl
        {
            get
            {
                if ((this.cachedServiceRunningStateStaticControl == null))
                {
                    this.cachedServiceRunningStateStaticControl = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.ServiceRunningStateStaticControl);
                }
                
                return this.cachedServiceRunningStateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertDescription control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.AlertDescription
        {
            get
            {
                if ((this.cachedAlertDescription == null))
                {
                    this.cachedAlertDescription = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.AlertDescription);
                }
                
                return this.cachedAlertDescription;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertStatusContent control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertPropertiesGeneralDialogControls.AlertStatusContent
        {
            get
            {
                if ((this.cachedAlertStatusContent == null))
                {
                    this.cachedAlertStatusContent = new StaticControl(this, AlertPropertiesGeneralDialog.ControlIDs.AlertStatusContent);
                }
                
                return this.cachedAlertStatusContent;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
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
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Change
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickChange()
        {
            this.Controls.ChangeButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 9/20/2006 Created
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
                    StringMatchSyntax.WildCard,
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
                                Strings.DialogTitle + "*",
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
                        Core.Common.Utilities.LogMessage(
                            "AlertPropertiesGeneralDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertPropertiesGeneralDialog:: Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

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
        /// 	[lucyra] 9/20/2006 Created
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
            private const string ResourceDialogTitle = ";Alert Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.UI.AlertPropertyDialog;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";&Previous;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.AlertPropertyDialog;prevButton.Text";
            
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RepeatCountContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRepeatCountContent = ";0;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Pro" +
                "pertyDialogForm;>>tabPageChart.ZOrder";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RepeatCount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRepeatCount = ";Repeat Count:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.UI.AlertPropertyDialog;repeatLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TicketID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTicketID = ";Ticket ID:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.UI.AlertPropertyDialog;ticketIDLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Change
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChange = ";&Change...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.UI.AlertPropertyDialog;changeOwnerButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Owner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOwner = ";Owner:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.UI.AlertPropertyDialog;ownerLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertStatus = ";Alert Status:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.UI.AlertPropertyDialog;alertStatusSectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertDescription = ";Alert Description:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Mom.UI.AlertPropertyDialog;alertDescriptionSectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  KeyDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKeyDetails = ";Key Details:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.UI.AlertPropertyDialog;keyDetailsSectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AgeContent
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgeContent = "1 Day, 4 Minutes";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SeverityContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeverityContent = ";Critical;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.Internal.UI.Cache.AlertTranslator;Error";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SourceContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSourceContent = "Spooler";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Age
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAge = ";Age:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagemen" +
                "t.Mom.UI.AlertPropertyDialog;ageHeaderLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSeverity = ";Alert severity;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.UI.AlertPropertyDialog;severityHeaderLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSource = ";Alert source:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.UI.AlertPropertyDialog;sourceHeaderLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceRunningState
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceRunningState = "Service Running State";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertStatusContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertStatusContent = @";Once you have identified the problem and taken corrective action, you can select 'Closed' which will remove the Alert from the system once changes are committed.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;statusInfoLabel.Text";
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
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RepeatCountContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRepeatCountContent;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RepeatCount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRepeatCount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TicketID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTicketID;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Change
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChange;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Owner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOwner;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertStatus
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertStatus;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  KeyDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKeyDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AgeContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgeContent;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SeverityContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeverityContent;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SourceContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSourceContent;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Age
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAge;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertSeverity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSeverity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertSource
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSource;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceRunningState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceRunningState;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertStatusContent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertStatusContent;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    
                    return cachedTab0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RepeatCountContent translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RepeatCountContent
            {
                get
                {
                    if ((cachedRepeatCountContent == null))
                    {
                        cachedRepeatCountContent = CoreManager.MomConsole.GetIntlStr(ResourceRepeatCountContent);
                    }
                    
                    return cachedRepeatCountContent;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RepeatCount translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RepeatCount
            {
                get
                {
                    if ((cachedRepeatCount == null))
                    {
                        cachedRepeatCount = CoreManager.MomConsole.GetIntlStr(ResourceRepeatCount);
                    }
                    
                    return cachedRepeatCount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TicketID translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TicketID
            {
                get
                {
                    if ((cachedTicketID == null))
                    {
                        cachedTicketID = CoreManager.MomConsole.GetIntlStr(ResourceTicketID);
                    }
                    
                    return cachedTicketID;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Change translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
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
            /// Exposes access to the Owner translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Owner
            {
                get
                {
                    if ((cachedOwner == null))
                    {
                        cachedOwner = CoreManager.MomConsole.GetIntlStr(ResourceOwner);
                    }
                    
                    return cachedOwner;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertStatus translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertStatus
            {
                get
                {
                    if ((cachedAlertStatus == null))
                    {
                        cachedAlertStatus = CoreManager.MomConsole.GetIntlStr(ResourceAlertStatus);
                    }
                    
                    return cachedAlertStatus;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertDescription
            {
                get
                {
                    if ((cachedAlertDescription == null))
                    {
                        cachedAlertDescription = CoreManager.MomConsole.GetIntlStr(ResourceAlertDescription);
                    }
                    
                    return cachedAlertDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the KeyDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string KeyDetails
            {
                get
                {
                    if ((cachedKeyDetails == null))
                    {
                        cachedKeyDetails = CoreManager.MomConsole.GetIntlStr(ResourceKeyDetails);
                    }
                    
                    return cachedKeyDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AgeContent translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgeContent
            {
                get
                {
                    if ((cachedAgeContent == null))
                    {
                        cachedAgeContent = CoreManager.MomConsole.GetIntlStr(ResourceAgeContent);
                    }
                    
                    return cachedAgeContent;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SeverityContent translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SeverityContent
            {
                get
                {
                    if ((cachedSeverityContent == null))
                    {
                        cachedSeverityContent = CoreManager.MomConsole.GetIntlStr(ResourceSeverityContent);
                    }
                    
                    return cachedSeverityContent;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SourceContent translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SourceContent
            {
                get
                {
                    if ((cachedSourceContent == null))
                    {
                        cachedSourceContent = CoreManager.MomConsole.GetIntlStr(ResourceSourceContent);
                    }
                    
                    return cachedSourceContent;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Age translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Age
            {
                get
                {
                    if ((cachedAge == null))
                    {
                        cachedAge = CoreManager.MomConsole.GetIntlStr(ResourceAge);
                    }
                    
                    return cachedAge;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSeverity translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSeverity
            {
                get
                {
                    if ((cachedAlertSeverity == null))
                    {
                        cachedAlertSeverity = CoreManager.MomConsole.GetIntlStr(ResourceAlertSeverity);
                    }
                    
                    return cachedAlertSeverity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertSource translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSource
            {
                get
                {
                    if ((cachedAlertSource == null))
                    {
                        cachedAlertSource = CoreManager.MomConsole.GetIntlStr(ResourceAlertSource);
                    }
                    
                    return cachedAlertSource;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceRunningState translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceRunningState
            {
                get
                {
                    if ((cachedServiceRunningState == null))
                    {
                        cachedServiceRunningState = CoreManager.MomConsole.GetIntlStr(ResourceServiceRunningState);
                    }
                    
                    return cachedServiceRunningState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertStatusContent translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/20/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertStatusContent
            {
                get
                {
                    if ((cachedAlertStatusContent == null))
                    {
                        cachedAlertStatusContent = CoreManager.MomConsole.GetIntlStr(ResourceAlertStatusContent);
                    }
                    
                    return cachedAlertStatusContent;
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
        /// 	[lucyra] 9/20/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "prevButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for GeneralTabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string GeneralTabControl = "mainTabControl";
            
            /// <summary>
            /// Control ID for RepeatCountContentStaticControl
            /// </summary>
            public const string RepeatCountContentStaticControl = "repeatContentLabel";
            
            /// <summary>
            /// Control ID for RepeatCountStaticControl
            /// </summary>
            public const string RepeatCountStaticControl = "repeatLabel";
            
            /// <summary>
            /// Control ID for TicketID
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TicketID = "ticketIDTextbox";
            
            /// <summary>
            /// Control ID for TicketIDStaticControl
            /// </summary>
            public const string TicketIDStaticControl = "ticketIDLabel";
            
            /// <summary>
            /// Control ID for OwnerContentTextBox
            /// </summary>
            public const string OwnerContentTextBox = "ownerTextbox";
            
            /// <summary>
            /// Control ID for ChangeButton
            /// </summary>
            public const string ChangeButton = "changeOwnerButton";
            
            /// <summary>
            /// Control ID for ResolutionStateCombo
            /// </summary>
            public const string ResolutionStateCombo = "resolutionStateCombo";
            
            /// <summary>
            /// Control ID for OwnerStaticControl
            /// </summary>
            public const string OwnerStaticControl = "ownerLabel";
            
            /// <summary>
            /// Control ID for AlertStatusStaticControl
            /// </summary>
            public const string AlertStatusStaticControl = "alertStatusSectionLabel";
            
            /// <summary>
            /// Control ID for AlertDescriptionStaticControl
            /// </summary>
            public const string AlertDescriptionStaticControl = "alertDescriptionSectionLabel";
            
            /// <summary>
            /// Control ID for KeyDetailsStaticControl
            /// </summary>
            public const string KeyDetailsStaticControl = "keyDetailsSectionLabel";
            
            /// <summary>
            /// Control ID for AgeContentStaticControl
            /// </summary>
            public const string AgeContentStaticControl = "ageContentLabel";
            
            /// <summary>
            /// Control ID for SeverityContentStaticControl
            /// </summary>
            public const string SeverityContentStaticControl = "severityContentLabel";
            
            /// <summary>
            /// Control ID for SourceContentStaticControl
            /// </summary>
            public const string SourceContentStaticControl = "sourceContentLabel";
            
            /// <summary>
            /// Control ID for AgeStaticControl
            /// </summary>
            public const string AgeStaticControl = "ageHeaderLabel";
            
            /// <summary>
            /// Control ID for AlertSeverityStaticControl
            /// </summary>
            public const string AlertSeverityStaticControl = "severityHeaderLabel";
            
            /// <summary>
            /// Control ID for AlertSourceStaticControl
            /// </summary>
            public const string AlertSourceStaticControl = "sourceHeaderLabel";
            
            /// <summary>
            /// Control ID for ServiceRunningStateStaticControl
            /// </summary>
            public const string ServiceRunningStateStaticControl = "titleLabel";
            
            /// <summary>
            /// Control ID for AlertDescription
            /// </summary>
            public const string AlertDescription = "alertDescriptionLabel";
            
            /// <summary>
            /// Control ID for AlertStatusContent
            /// </summary>
            public const string AlertStatusContent = "statusInfoLabel";
        }
        #endregion
    }
}
