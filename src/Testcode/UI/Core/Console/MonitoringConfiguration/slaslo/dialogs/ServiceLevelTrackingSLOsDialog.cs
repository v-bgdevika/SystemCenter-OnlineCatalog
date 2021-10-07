// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceLevelTrackingSLOsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy class that represents the SLOs Dialog in the SLA Wizard 
// </project>
// <summary>
// 	Proxy class that represents the SLOs Dialog in the SLA Wizard 
// </summary>
// <history>
// 	[dialac] 9/25/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IServiceLevelTrackingSLOsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceLevelTrackingSLOsDialogControls, for ServiceLevelTrackingSLOsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 9/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceLevelTrackingSLOsDialogControls
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
        StaticControl ServiceLevelObjectivesLinkStaticControl
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
        /// Read-only property to access SLOListView
        /// </summary>
        ListView SLOListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SloButtonsToolStrip
        /// </summary>
        Toolbar SloButtonsToolStrip
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
        /// Read-only property to access ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT
        /// </summary>
        StaticControl ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectivesHeaderStaticControl
        /// </summary>
        StaticControl ServiceLevelObjectivesHeaderStaticControl
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
    /// 	[dialac] 9/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServiceLevelTrackingSLOsDialog : Dialog, IServiceLevelTrackingSLOsDialogControls
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
        private StaticControl cachedServiceLevelObjectivesLinkStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SLOListView of type ListView
        /// </summary>
        private ListView cachedSLOListView;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl1 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl1;
        
        /// <summary>
        /// Cache to hold a reference to SloButtonsToolStrip of type Toolbar
        /// </summary>
        private Toolbar cachedSloButtonsToolStrip;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectivesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectivesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectivesHeaderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectivesHeaderStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceLevelTrackingSLOsDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceLevelTrackingSLOsDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IServiceLevelTrackingSLOsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceLevelTrackingSLOsDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingSLOsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ServiceLevelTrackingSLOsDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingSLOsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ServiceLevelTrackingSLOsDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingSLOsDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ServiceLevelTrackingSLOsDialog.ControlIDs.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingSLOsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServiceLevelTrackingSLOsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSLOsDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, ServiceLevelTrackingSLOsDialog.ControlIDs.GeneralStaticControl);
                }
                
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsToTrackStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSLOsDialogControls.ObjectsToTrackStaticControl
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
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSLOsDialogControls.ServiceLevelObjectivesLinkStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedServiceLevelObjectivesLinkStaticControl == null))
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
                    this.cachedServiceLevelObjectivesLinkStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedServiceLevelObjectivesLinkStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSLOsDialogControls.SummaryStaticControl
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
        ///  Exposes access to the SLOListView control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IServiceLevelTrackingSLOsDialogControls.SLOListView
        {
            get
            {
                if ((this.cachedSLOListView == null))
                {
                    this.cachedSLOListView = new ListView(this, new QID(";[UIA]AutomationId ='" + ServiceLevelTrackingSLOsDialog.ControlIDs.SLOListView + "'"));
                }
                
                return this.cachedSLOListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl1 control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSLOsDialogControls.StaticControl1
        {
            get
            {
                if ((this.cachedStaticControl1 == null))
                {
                    this.cachedStaticControl1 = new StaticControl(this, ServiceLevelTrackingSLOsDialog.ControlIDs.StaticControl1);
                }
                
                return this.cachedStaticControl1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SloButtonsToolStrip control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IServiceLevelTrackingSLOsDialogControls.SloButtonsToolStrip
        {
            get
            {
                if ((this.cachedSloButtonsToolStrip == null))
                {
                    this.cachedSloButtonsToolStrip = new Toolbar(this, ServiceLevelTrackingSLOsDialog.ControlIDs.SloButtonsToolStrip);
                }
                
                return this.cachedSloButtonsToolStrip;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectivesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSLOsDialogControls.ServiceLevelObjectivesStaticControl
        {
            get
            {
                if ((this.cachedServiceLevelObjectivesStaticControl == null))
                {
                    this.cachedServiceLevelObjectivesStaticControl = new StaticControl(this, ServiceLevelTrackingSLOsDialog.ControlIDs.ServiceLevelObjectivesStaticControl);
                }
                
                return this.cachedServiceLevelObjectivesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSLOsDialogControls.ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT
        {
            get
            {
                if ((this.cachedServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT == null))
                {
                    this.cachedServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT = new StaticControl(this, ServiceLevelTrackingSLOsDialog.ControlIDs.ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT);
                }
                
                return this.cachedServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectivesHeaderStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingSLOsDialogControls.ServiceLevelObjectivesHeaderStaticControl
        {
            get
            {
                if ((this.cachedServiceLevelObjectivesHeaderStaticControl == null))
                {
                    this.cachedServiceLevelObjectivesHeaderStaticControl = new StaticControl(this, ServiceLevelTrackingSLOsDialog.ControlIDs.ServiceLevelObjectivesHeaderStaticControl);
                }
                
                return this.cachedServiceLevelObjectivesHeaderStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
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
        /// 	[dialac] 9/25/2008 Created
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
        /// 	[dialac] 9/25/2008 Created
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
        /// 	[dialac] 9/25/2008 Created
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
        /// 	[dialac] 9/25/2008 Created
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
        /// 	[dialac] 9/25/2008 Created
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
            private const string ResourceServiceLevelObjectivesLink = ";Service Level Objectives;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
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
            /// Contains resource string for:  SloButtonsToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSloButtonsToolStrip = ";sloButtonsToolStrip;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SloListPage;>>s" +
                "loButtonsToolStrip.Name";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectivesList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectivesList = ";Service level objectives:;ManagedString;Microsoft.EnterpriseManagement.UI.Author" +
                "ing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SloListPa" +
                "ge;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT = @";Service level objectives (SLO) defines the performance thresholds or the states that you want to track for the selected targeted class, objects, or group.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SloListPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectivesHeader
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectivesHeader = ";Service Level Objectives;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaPageRes" +
                "ources;SloListPageTitle";
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
            /// Caches the translated resource string for:  ServiceLevelObjectivesLink
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectivesLink;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SloButtonsToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSloButtonsToolStrip;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectives
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectives;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectivesHeader
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectivesHeader;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
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
            /// 	[dialac] 9/25/2008 Created
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
            /// 	[dialac] 9/25/2008 Created
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
            /// 	[dialac] 9/25/2008 Created
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
            /// 	[dialac] 9/25/2008 Created
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
            /// 	[dialac] 9/25/2008 Created
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
            /// 	[dialac] 9/25/2008 Created
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
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectivesLink
            {
                get
                {
                    if ((cachedServiceLevelObjectivesLink == null))
                    {
                        cachedServiceLevelObjectivesLink = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectivesLink);
                    }

                    return cachedServiceLevelObjectivesLink;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
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
            /// Exposes access to the SloButtonsToolStrip translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SloButtonsToolStrip
            {
                get
                {
                    if ((cachedSloButtonsToolStrip == null))
                    {
                        cachedSloButtonsToolStrip = CoreManager.MomConsole.GetIntlStr(ResourceSloButtonsToolStrip);
                    }
                    
                    return cachedSloButtonsToolStrip;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceLevelObjectives translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectives
            {
                get
                {
                    if ((cachedServiceLevelObjectives == null))
                    {
                        cachedServiceLevelObjectives = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectivesList);
                    }
                    
                    return cachedServiceLevelObjectives;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT
            {
                get
                {
                    if ((cachedServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT == null))
                    {
                        cachedServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT);
                    }
                    
                    return cachedServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceLevelObjectives3 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectivesHeader
            {
                get
                {
                    if ((cachedServiceLevelObjectivesHeader == null))
                    {
                        cachedServiceLevelObjectivesHeader = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectivesHeader);
                    }

                    return cachedServiceLevelObjectivesHeader;
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
        /// 	[dialac] 9/25/2008 Created
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
            public const string ServiceLevelObjectivesLinkStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SLOListView
            /// </summary>
            public const string SLOListView = "sloList";
            
            /// <summary>
            /// Control ID for StaticControl1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl1 = "label3";
            
            /// <summary>
            /// Control ID for SloButtonsToolStrip
            /// </summary>
            public const string SloButtonsToolStrip = "sloButtonsToolStrip";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectivesStaticControl
            /// </summary>
            public const string ServiceLevelObjectivesStaticControl = "label2";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT
            /// </summary>
            public const string ServiceLevelObjectivesSLODefinesThePerformanceThresholdsOrTheStatesThatYouWantToTrackForTheSelectedT = "label1";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectivesHeaderStaticControl
            /// </summary>
            public const string ServiceLevelObjectivesHeaderStaticControl = "headerLabel";
        }
        #endregion
    }
}
