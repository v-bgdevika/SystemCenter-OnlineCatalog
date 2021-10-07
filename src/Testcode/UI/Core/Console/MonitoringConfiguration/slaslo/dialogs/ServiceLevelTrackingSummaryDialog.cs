// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceLevelTrackingSummaryDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy Class that represents the Summary dialog in the SLA Wizard.
// </project>
// <summary>
// 	Proxy Class that represents the Summary dialog in the SLA Wizard.
// </summary>
// <history>
// 	[dialac] 9/12/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IServiceLevelTrackingSummaryDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceLevelTrackingSummaryDialogControls, for ServiceLevelTrackingSummaryDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 9/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceLevelTrackingSummaryDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsToTrackStaticControl
        /// </summary>
        StaticControl ObjectsToTrackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectivesStaticControl
        /// </summary>
        StaticControl ServiceLevelObjectivesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl
        /// </summary>
        StaticControl SummaryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl
        /// </summary>
        StaticControl ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectivesTextBox
        /// </summary>
        TextBox ServiceLevelObjectivesTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl
        /// </summary>
        StaticControl ConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryHeaderLabelStaticControl
        /// </summary>
        StaticControl SummaryHeaderLabelStaticControl
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
    /// 	[dialac] 9/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServiceLevelTrackingSummaryDialog : Dialog, IServiceLevelTrackingSummaryDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsToTrackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsToTrackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectivesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectivesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectivesTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceLevelObjectivesTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryHeaderLabelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryHeaderLabelStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceLevelTrackingSummaryDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceLevelTrackingSummaryDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            //UISynchronization.WaitForUIObjectReady(this, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IServiceLevelTrackingSummaryDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceLevelTrackingSummaryDialogControls Controls
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
        ///  Routine to set/get the text in control ServiceLevelObjectives
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceLevelObjectivesText
        {
            get
            {
                return this.Controls.ServiceLevelObjectivesTextBox.Text;
            }
            
            set
            {
                this.Controls.ServiceLevelObjectivesTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingSummaryDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ServiceLevelTrackingSummaryDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingSummaryDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ServiceLevelTrackingSummaryDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingSummaryDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ServiceLevelTrackingSummaryDialog.ControlIDs.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingSummaryDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServiceLevelTrackingSummaryDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSummaryDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, ServiceLevelTrackingSummaryDialog.ControlIDs.GeneralStaticControl);
                }
                
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsToTrackStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSummaryDialogControls.ObjectsToTrackStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedObjectsToTrackStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedObjectsToTrackStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedObjectsToTrackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectivesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSummaryDialogControls.ServiceLevelObjectivesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedServiceLevelObjectivesStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedServiceLevelObjectivesStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedServiceLevelObjectivesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSummaryDialogControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSummaryStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedSummaryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSummaryDialogControls.ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl
        {
            get
            {
                if ((this.cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl == null))
                {
                    this.cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl = new StaticControl(this, ServiceLevelTrackingSummaryDialog.ControlIDs.ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl);
                }
                
                return this.cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectivesTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelTrackingSummaryDialogControls.ServiceLevelObjectivesTextBox
        {
            get
            {
                if ((this.cachedServiceLevelObjectivesTextBox == null))
                {
                    this.cachedServiceLevelObjectivesTextBox = new TextBox(this, ServiceLevelTrackingSummaryDialog.ControlIDs.ServiceLevelObjectivesTextBox);
                }
                
                return this.cachedServiceLevelObjectivesTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSummaryDialogControls.ConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl
        {
            get
            {
                if ((this.cachedConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl == null))
                {
                    this.cachedConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl = new StaticControl(this, ServiceLevelTrackingSummaryDialog.ControlIDs.ConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl);
                }
                
                return this.cachedConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSummaryDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ServiceLevelTrackingSummaryDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryHeaderLabelStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSummaryDialogControls.SummaryHeaderLabelStaticControl
        {
            get
            {
                if ((this.cachedSummaryHeaderLabelStaticControl == null))
                {
                    this.cachedSummaryHeaderLabelStaticControl = new StaticControl(this, ServiceLevelTrackingSummaryDialog.ControlIDs.SummaryHeaderLabelStaticControl);
                }
                
                return this.cachedSummaryHeaderLabelStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
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
        /// 	[dialac] 9/12/2008 Created
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
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

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
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = @";Service Level Tracking;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateSlaWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;FinishTe" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectsToTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectsToTrack = ";Objects to Track;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaPageResources;T" +
                "rackTargetPageTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectives
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectives = ";Service Level Objectives;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaPageRes" +
                "ources;SloListPageTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryT" +
                "itle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate = ";To change settings, click Previous. The create SLA tracking, click Create.;Manag" +
                "edString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.Sla.SlaSummaryPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfirmYourSettingsForTrackingThisServiceLevelAgreement
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmYourSettingsForTrackingThisServiceLevelAgreement = ";Confirm your settings for tracking this service level agreement.;ManagedString;M" +
                "icrosoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.In" +
                "ternal.UI.Authoring.Pages.Sla.SlaSummaryPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;HelpSubFold" +
                "erName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SummaryHeaderLabel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderLabelSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryT" +
                "itle";
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
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ObjectsToTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectsToTrack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectives
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectives;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfirmYourSettingsForTrackingThisServiceLevelAgreement
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmYourSettingsForTrackingThisServiceLevelAgreement;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SummaryHeaderLabel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummaryHeaderLabel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
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
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
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
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }
                    
                    return cachedFinish;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
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
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    
                    return cachedGeneral;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ObjectsToTrack translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectsToTrack
            {
                get
                {
                    if ((cachedObjectsToTrack == null))
                    {
                        cachedObjectsToTrack = CoreManager.MomConsole.GetIntlStr(ResourceObjectsToTrack);
                    }
                    
                    return cachedObjectsToTrack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceLevelObjectives translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectives
            {
                get
                {
                    if ((cachedServiceLevelObjectives == null))
                    {
                        cachedServiceLevelObjectives = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectives);
                    }
                    
                    return cachedServiceLevelObjectives;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    
                    return cachedSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate
            {
                get
                {
                    if ((cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate == null))
                    {
                        cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate = CoreManager.MomConsole.GetIntlStr(ResourceToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate);
                    }
                    
                    return cachedToChangeSettingsClickPreviousTheCreateSLATrackingClickCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfirmYourSettingsForTrackingThisServiceLevelAgreement translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmYourSettingsForTrackingThisServiceLevelAgreement
            {
                get
                {
                    if ((cachedConfirmYourSettingsForTrackingThisServiceLevelAgreement == null))
                    {
                        cachedConfirmYourSettingsForTrackingThisServiceLevelAgreement = CoreManager.MomConsole.GetIntlStr(ResourceConfirmYourSettingsForTrackingThisServiceLevelAgreement);
                    }
                    
                    return cachedConfirmYourSettingsForTrackingThisServiceLevelAgreement;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SummaryHeaderLabel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SummaryHeaderLabel
            {
                get
                {
                    if ((cachedSummaryHeaderLabel == null))
                    {
                        cachedSummaryHeaderLabel = CoreManager.MomConsole.GetIntlStr(ResourceHeaderLabelSummary);
                    }
                    
                    return cachedSummaryHeaderLabel;
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
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ObjectsToTrackStaticControl
            /// </summary>
            public const string ObjectsToTrackStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectivesStaticControl
            /// </summary>
            public const string ServiceLevelObjectivesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl
            /// </summary>
            public const string ToChangeSettingsClickPreviousTheCreateSLATrackingClickCreateStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectivesTextBox
            /// </summary>
            public const string ServiceLevelObjectivesTextBox = "summaryDescription";
            
            /// <summary>
            /// Control ID for ConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl
            /// </summary>
            public const string ConfirmYourSettingsForTrackingThisServiceLevelAgreementStaticControl = "label1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryHeaderLabelStaticControl
            /// </summary>
            public const string SummaryHeaderLabelStaticControl = "headerLabel";
        }
        #endregion
    }
}
