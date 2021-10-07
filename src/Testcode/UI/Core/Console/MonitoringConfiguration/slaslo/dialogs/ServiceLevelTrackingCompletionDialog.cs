// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceLevelTrackingCompletionDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy Class that represents the Completion Dialog in the SLA Wizard
// </project>
// <summary>
// 	Proxy Class that represents the Completion Dialog in the SLA Wizard
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
    
    #region Interface Definition - IServiceLevelTrackingCompletionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceLevelTrackingCompletionDialogControls, for ServiceLevelTrackingCompletionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 9/12/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceLevelTrackingCompletionDialogControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
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
        /// Read-only property to access ToFinishThisWizardClickCloseStaticControl
        /// </summary>
        StaticControl ToFinishThisWizardClickCloseStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl
        /// </summary>
        StaticControl YouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheServiceLevelAgreementTrackingWizardHasCompletedStaticControl
        /// </summary>
        StaticControl TheServiceLevelAgreementTrackingWizardHasCompletedStaticControl
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
        /// Read-only property to access CompletionStaticControl
        /// </summary>
        StaticControl CompletionStaticControl
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
    public class ServiceLevelTrackingCompletionDialog : Dialog, IServiceLevelTrackingCompletionDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
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
        /// Cache to hold a reference to ToFinishThisWizardClickCloseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToFinishThisWizardClickCloseStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TheServiceLevelAgreementTrackingWizardHasCompletedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheServiceLevelAgreementTrackingWizardHasCompletedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CompletionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCompletionStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceLevelTrackingCompletionDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceLevelTrackingCompletionDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            //UISynchronization.WaitForUIObjectReady(this, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IServiceLevelTrackingCompletionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceLevelTrackingCompletionDialogControls Controls
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
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelTrackingCompletionDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    QID qid = new QID(";[UIA]AutomationId ='"+ ServiceLevelTrackingCompletionDialog.ControlIDs.CloseButton+"' && Name ='"+Strings.Close+"'");
                    this.cachedCloseButton = new Button(this, qid, 3000);
                }
                
                return this.cachedCloseButton;
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
        StaticControl IServiceLevelTrackingCompletionDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, ServiceLevelTrackingCompletionDialog.ControlIDs.GeneralStaticControl);
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
        StaticControl IServiceLevelTrackingCompletionDialogControls.ObjectsToTrackStaticControl
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
        StaticControl IServiceLevelTrackingCompletionDialogControls.ServiceLevelObjectivesStaticControl
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
        StaticControl IServiceLevelTrackingCompletionDialogControls.SummaryStaticControl
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
        ///  Exposes access to the ToFinishThisWizardClickCloseStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingCompletionDialogControls.ToFinishThisWizardClickCloseStaticControl
        {
            get
            {
                if ((this.cachedToFinishThisWizardClickCloseStaticControl == null))
                {
                    this.cachedToFinishThisWizardClickCloseStaticControl = new StaticControl(this, ServiceLevelTrackingCompletionDialog.ControlIDs.ToFinishThisWizardClickCloseStaticControl);
                }
                
                return this.cachedToFinishThisWizardClickCloseStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingCompletionDialogControls.YouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl
        {
            get
            {
                if ((this.cachedYouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl == null))
                {
                    this.cachedYouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl = new StaticControl(this, ServiceLevelTrackingCompletionDialog.ControlIDs.YouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl);
                }
                
                return this.cachedYouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheServiceLevelAgreementTrackingWizardHasCompletedStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingCompletionDialogControls.TheServiceLevelAgreementTrackingWizardHasCompletedStaticControl
        {
            get
            {
                if ((this.cachedTheServiceLevelAgreementTrackingWizardHasCompletedStaticControl == null))
                {
                    this.cachedTheServiceLevelAgreementTrackingWizardHasCompletedStaticControl = new StaticControl(this, ServiceLevelTrackingCompletionDialog.ControlIDs.TheServiceLevelAgreementTrackingWizardHasCompletedStaticControl);
                }
                
                return this.cachedTheServiceLevelAgreementTrackingWizardHasCompletedStaticControl;
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
        StaticControl IServiceLevelTrackingCompletionDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ServiceLevelTrackingCompletionDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompletionStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelTrackingCompletionDialogControls.CompletionStaticControl
        {
            get
            {
                if ((this.cachedCompletionStaticControl == null))
                {
                    this.cachedCompletionStaticControl = new StaticControl(this, ServiceLevelTrackingCompletionDialog.ControlIDs.CompletionStaticControl);
                }
                
                return this.cachedCompletionStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[dialac] 9/12/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
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
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Close;ManagedString;Corgent.Diagramming.Toolbox.dll;Corgent.Diagramming.Toolbox." +
                "Properties.Resources;Close";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiscoveryGeneralPage;$this.T" +
                "abName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ObjectsToTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectsToTrack = ";Objects to Track;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOL" +
                "D;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaPageResources;Tr" +
                "ackTargetPageTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectives
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectives = ";Service Level Objectives;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dllOLD;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SloListPage" +
                ";Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.SummaryPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToFinishThisWizardClickClose
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToFinishThisWizardClickClose = ";To finish this wizard click Close.;ManagedString;Microsoft.EnterpriseManagement." +
                "UI.Authoring.dllOLD;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.S" +
                "laCompletionPage;label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouHaveSuccessfullyCreatedServiceLevelAgreementApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouHaveSuccessfullyCreatedServiceLevelAgreementApplication = ";You have successfully created Service Level Agreement Application.;ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microsoft.EnterpriseManageme" +
                "nt.Internal.UI.Authoring.Pages.SlaCompletionPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheServiceLevelAgreementTrackingWizardHasCompleted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheServiceLevelAgreementTrackingWizardHasCompleted = ";The Service Level Agreement Tracking Wizard has completed.;ManagedString;Microso" +
                "ft.EnterpriseManagement.UI.Authoring.dllOLD;Microsoft.EnterpriseManagement.Inter" +
                "nal.UI.Authoring.Pages.SlaCompletionPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Completion
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCompletion = ";Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dllOLD;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaPageResources;Completi" +
                "onPageTitle";

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
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
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
            /// Caches the translated resource string for:  ToFinishThisWizardClickClose
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToFinishThisWizardClickClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouHaveSuccessfullyCreatedServiceLevelAgreementApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouHaveSuccessfullyCreatedServiceLevelAgreementApplication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheServiceLevelAgreementTrackingWizardHasCompleted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheServiceLevelAgreementTrackingWizardHasCompleted;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Completion
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCompletion;
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
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    if ((cachedClose == null))
                    {
                        cachedClose = CoreManager.MomConsole.GetIntlStr(ResourceClose);
                    }
                    
                    return cachedClose;
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
            /// Exposes access to the ToFinishThisWizardClickClose translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToFinishThisWizardClickClose
            {
                get
                {
                    if ((cachedToFinishThisWizardClickClose == null))
                    {
                        cachedToFinishThisWizardClickClose = CoreManager.MomConsole.GetIntlStr(ResourceToFinishThisWizardClickClose);
                    }
                    
                    return cachedToFinishThisWizardClickClose;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouHaveSuccessfullyCreatedServiceLevelAgreementApplication translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouHaveSuccessfullyCreatedServiceLevelAgreementApplication
            {
                get
                {
                    if ((cachedYouHaveSuccessfullyCreatedServiceLevelAgreementApplication == null))
                    {
                        cachedYouHaveSuccessfullyCreatedServiceLevelAgreementApplication = CoreManager.MomConsole.GetIntlStr(ResourceYouHaveSuccessfullyCreatedServiceLevelAgreementApplication);
                    }
                    
                    return cachedYouHaveSuccessfullyCreatedServiceLevelAgreementApplication;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheServiceLevelAgreementTrackingWizardHasCompleted translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheServiceLevelAgreementTrackingWizardHasCompleted
            {
                get
                {
                    if ((cachedTheServiceLevelAgreementTrackingWizardHasCompleted == null))
                    {
                        cachedTheServiceLevelAgreementTrackingWizardHasCompleted = CoreManager.MomConsole.GetIntlStr(ResourceTheServiceLevelAgreementTrackingWizardHasCompleted);
                    }
                    
                    return cachedTheServiceLevelAgreementTrackingWizardHasCompleted;
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
            /// Exposes access to the Completion translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/12/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Completion
            {
                get
                {
                    if ((cachedCompletion == null))
                    {
                        cachedCompletion = CoreManager.MomConsole.GetIntlStr(ResourceCompletion);
                    }
                    
                    return cachedCompletion;
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
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "cancelButton";
            
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
            /// Control ID for ToFinishThisWizardClickCloseStaticControl
            /// </summary>
            public const string ToFinishThisWizardClickCloseStaticControl = "label3";
            
            /// <summary>
            /// Control ID for YouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl
            /// </summary>
            public const string YouHaveSuccessfullyCreatedServiceLevelAgreementApplicationStaticControl = "label2";
            
            /// <summary>
            /// Control ID for TheServiceLevelAgreementTrackingWizardHasCompletedStaticControl
            /// </summary>
            public const string TheServiceLevelAgreementTrackingWizardHasCompletedStaticControl = "label1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for CompletionStaticControl
            /// </summary>
            public const string CompletionStaticControl = "headerLabel";
        }
        #endregion
    }
}
