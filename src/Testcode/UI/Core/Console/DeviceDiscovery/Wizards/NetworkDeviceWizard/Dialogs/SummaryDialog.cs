// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SummaryDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [dialac] 5/24/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    //using Maui.Core.HtmlControls;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    //using Maui.InternetExplorer;
    
    #region Interface Definition - ISummaryDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISummaryDialogControls, for SummaryDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [dialac] 5/24/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISummaryDialogControls
    {
        /// <summary>
        /// Gets read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access FinishButton
        /// </summary>
        Button FinishButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HTMLDoc
        /// </summary>
        //HTMLDocument HTMLDoc
        //{
        //    get;
        //}
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    ///   [dialac] 5/24/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class SummaryDialog : Dialog, ISummaryDialogControls
    {
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
        /// Cache to hold a reference to HTMLDoc of type HTMLDocument
        /// </summary>
        //private HTMLDocument cachedHTMLDoc;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the SummaryDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of SummaryDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [dialac] 5/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SummaryDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISummaryDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [dialac] 5/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISummaryDialogControls Controls
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
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SummaryDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SummaryDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, SummaryDialog.ControlIDs.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SummaryDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HTMLDoc control
        /// </summary>
        /// <history>
        ///   [dialac] 5/24/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (HTMLDoc) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        //HTMLDocument ISummaryDialogControls.HTMLDoc
        //{
        //    get
        //    {
        //        if ((this.cachedHTMLDoc == null))
        //        {
        //            Window wndTemp = this;
                                         
        //            // Required to navigate to control
        //            wndTemp = wndTemp.Extended.FirstChild;
        //            int i;
        //            for (i = 0; (i <= 2); i = (i + 1))
        //            {
        //                wndTemp = wndTemp.Extended.NextSibling;
        //            }
                    
        //            wndTemp = wndTemp.Extended.FirstChild;
        //            wndTemp = wndTemp.Extended.FirstChild;
        //            wndTemp = wndTemp.Extended.FirstChild;
        //            wndTemp = wndTemp.Extended.FirstChild;
        //            wndTemp = wndTemp.Extended.FirstChild;
        //            wndTemp = wndTemp.Extended.FirstChild;
        //            this.cachedHTMLDoc = new HTMLDocument(wndTemp);
        //        }
                
        //        return this.cachedHTMLDoc;
        //    }
        //}
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [dialac] 5/24/2010 Created
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
        ///   [dialac] 5/24/2010 Created
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
        ///   [dialac] 5/24/2010 Created
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
        ///   [dialac] 5/24/2010 Created
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
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [dialac] 5/24/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, timeout);
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
                        UISynchronization.WaitForUIObjectReady(tempWindow, timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);


                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(timeout);
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
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [dialac] 5/24/2010 Created
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
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [dialac] 5/24/2010 Created
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
            private const string ResourceDialogTitle = ";Computer and Device Management Wizard;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "DiscoveryWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Res" +
                "ources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en" +
                ";previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resourc" +
                "es.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en;nex" +
                "tButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Finish;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;FinishText
            /// ;Finish;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en;commitButton.Text
            /// ;Finish;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.AdminResources;FinishText
            /// </remark>
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResource" +
                "s;FinishText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.CatalogConnectionDialog;closeButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.EulaDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCatalogDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPErrorDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.ResolveDependentsDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.UpdateAgentWarningForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.CredentialForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDiscovery.AddDeviceDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDiscovery.AddFilterDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDiscovery.AdvancedDiscoverySettingsDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AdvancedAlertSuppressionForm;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertSuppressionForm;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;cnlbtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RawXmlEditor;cancelbtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NewNameDialog;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventConsolidationPropertiesForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.GenericConsolidationPropertiesForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AdvancedOptionsForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventLogSelectorForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventPropertyForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EditRegistryProbeDialog;idBtnCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExcludedDaysForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TimeRangeForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServiceBrowserForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConnectionStringBuilder;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;btnCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ParametersDialog;btnCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.FormulaDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExtendedTypeForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.CreateWebApplicationform;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.OpenServiceForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceComponentForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceComponentPropertiesForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServicePropertiesForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ChooseSCIMonitorForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework.en;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.BusinessHoursForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportColumnFilterDialog;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlValueEditorDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringOptionDialog;Cancel_Options.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Favorites.FavoriteReportWizard;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Publish.PublishReportWizard;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportExportForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportFindForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportZoomForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.ColumnPickerDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.ObjectFetcherDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.MaintenanceModeDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringClassChooser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringObjectChooser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.GroupServiceChooser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources;CancelText
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.AemStatePropertyDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.AemDataCollectionDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.AemCollectRegistryDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.AemCollectWmiQueryDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.UrlViewAuthoringDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.DashboardViewAuthoringDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.SelectViewDialog;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceTimePicker;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceScalePicker;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceViewPropertiesDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.UI.HealthExplorerInfoDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.TaskOverridesDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Overrides.OverridesDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverrideDescriptionForm;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SavedSearchForm;cancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.NewFolderDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ShowHideDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialog;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.CreateFolderDialog;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.DeleteShortcutConfirmDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.NewFolderDlg;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources;CancelText
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.AddRecipientForm;cancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SmtpServerForm;cancel.Text
            /// ;Cancel;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.DiscoveryCriteriaForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Authoring.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Authoring.Common.ServerBrowserForm;btnCancel.Text
            /// ;Cancel;ManagedString;RootWebConsole.resources.dll;resources.webresource;Dlg_cancel_btn
            /// ;Cancel;ManagedString;AjaxControlToolkit.dll;AjaxControlToolkit.ScriptResources.ScriptResources;RTE_Cancel
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;cancelButton.Text
            /// ;Cancel;ManagedString;RootWebConsole.dll;resources.webresource;Dlg_cancel_btn
            /// ;Cancel;ManagedString;MobileWebConsole.resources.dll;resources.webresource;Dlg_cancel_btn
            /// </remark>
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndI" +
                "nstall.MPDownloadInstallResources;Cancel";
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/24/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if (GeneralDialog.CurrentWizardTitle != null)
                        return GeneralDialog.CurrentWizardTitle;
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/24/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Next translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/24/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceNext);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Finish translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/24/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/24/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                }
            }
            #endregion
        }
        #endregion
    }
}
