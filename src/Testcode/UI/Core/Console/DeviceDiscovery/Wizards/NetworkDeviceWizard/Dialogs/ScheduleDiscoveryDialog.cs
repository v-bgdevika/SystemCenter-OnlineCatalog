// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ScheduleDiscoveryDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [dialac] 4/18/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IScheduleDiscoveryDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IScheduleDiscoveryDialogControls, for ScheduleDiscoveryDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [dialac] 4/18/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IScheduleDiscoveryDialogControls
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
        /// Gets read-only property to access DiscoverButton
        /// </summary>
        Button DiscoverButton
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
        /// Gets read-only property to access RunOnAFixedScheduleComboBox
        /// </summary>
        ComboBox RunOnAFixedScheduleComboBox
        {
            get;
        }

        
        /*//RunImmediately Checkbox has been removed in CTP1. See #178563.
        /// <summary>
        /// Gets read-only property to access RunImmediatelyWhenDiscoveryIsCreatedCheckBox
        /// </summary>
        CheckBox RunImmediatelyWhenDiscoveryIsCreatedCheckBox
        {
            get;
        }
        */

        /// <summary>
        /// Gets read-only property to access RunOnAFixedScheduleComboBox2
        /// </summary>
        ComboBox RunOnAFixedScheduleComboBox2
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
    ///   [dialac] 4/18/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class ScheduleDiscoveryDialog : Dialog, IScheduleDiscoveryDialogControls
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
        /// Cache to hold a reference to DiscoverButton of type Button
        /// </summary>
        private Button cachedDiscoverButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to RunOnAFixedScheduleComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedRunOnAFixedScheduleComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RunImmediatelyWhenDiscoveryIsCreatedCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedRunImmediatelyWhenDiscoveryIsCreatedCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to RunOnAFixedScheduleComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedRunOnAFixedScheduleComboBox2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the ScheduleDiscoveryDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of ScheduleDiscoveryDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ScheduleDiscoveryDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IScheduleDiscoveryDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IScheduleDiscoveryDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        /*//RunImmediately Checkbox has been removed in CTP1. See #178563.
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox RunImmediatelyWhenDiscoveryIsCreated
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool RunImmediatelyWhenDiscoveryIsCreated
        {
            get
            {
                return this.Controls.RunImmediatelyWhenDiscoveryIsCreatedCheckBox.Checked;
            }
            
            set
            {
                this.Controls.RunImmediatelyWhenDiscoveryIsCreatedCheckBox.Checked = value;
            }
        }

        #endregion
      */

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control RunOnAFixedSchedule
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RunOnAFixedScheduleText
        {
            get
            {
                return this.Controls.RunOnAFixedScheduleComboBox.Text;
            }
            
            set
            {
                this.Controls.RunOnAFixedScheduleComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control RunOnAFixedSchedule2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RunOnAFixedSchedule2Text
        {
            get
            {
                return this.Controls.RunOnAFixedScheduleComboBox2.Text;
            }
            
            set
            {
                this.Controls.RunOnAFixedScheduleComboBox2.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDiscoveryDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ScheduleDiscoveryDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDiscoveryDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ScheduleDiscoveryDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DiscoverButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDiscoveryDialogControls.DiscoverButton
        {
            get
            {
                if ((this.cachedDiscoverButton == null))
                {
                    this.cachedDiscoverButton = new Button(this, ScheduleDiscoveryDialog.ControlIDs.DiscoverButton);
                }
                
                return this.cachedDiscoverButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDiscoveryDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ScheduleDiscoveryDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the RunOnAFixedScheduleComboBox control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IScheduleDiscoveryDialogControls.RunOnAFixedScheduleComboBox
        {
            get
            {
                if ((this.cachedRunOnAFixedScheduleComboBox == null))
                {
                    this.cachedRunOnAFixedScheduleComboBox = new ComboBox(this, ScheduleDiscoveryDialog.ControlIDs.RunOnAFixedScheduleComboBox);
                }
                
                return this.cachedRunOnAFixedScheduleComboBox;
            }
        }

        /*//RunImmediately Checkbox has been removed in CTP1. See #178563.
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the RunImmediatelyWhenDiscoveryIsCreatedCheckBox control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IScheduleDiscoveryDialogControls.RunImmediatelyWhenDiscoveryIsCreatedCheckBox
        {
            get
            {
                if ((this.cachedRunImmediatelyWhenDiscoveryIsCreatedCheckBox == null))
                {
                    this.cachedRunImmediatelyWhenDiscoveryIsCreatedCheckBox = new CheckBox(this, ScheduleDiscoveryDialog.ControlIDs.RunImmediatelyWhenDiscoveryIsCreatedCheckBox);
                }
                
                return this.cachedRunImmediatelyWhenDiscoveryIsCreatedCheckBox;
            }
        }

        */

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the RunOnAFixedScheduleComboBox2 control
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IScheduleDiscoveryDialogControls.RunOnAFixedScheduleComboBox2
        {
            get
            {
                if ((this.cachedRunOnAFixedScheduleComboBox2 == null))
                {
                    this.cachedRunOnAFixedScheduleComboBox2 = new ComboBox(this, ScheduleDiscoveryDialog.ControlIDs.RunOnAFixedScheduleComboBox2);
                }
                
                return this.cachedRunOnAFixedScheduleComboBox2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
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
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Discover
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDiscover()
        {
            this.Controls.DiscoverButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }


        /* //RunImmediately Checkbox has been removed in CTP1. See #178563.
           /// <summary>
           ///  Routine to click on button RunImmediatelyWhenDiscoveryIsCreated
           /// </summary>
           /// <history>
           ///   [dialac] 4/18/2010 Created
           /// </history>
           /// -----------------------------------------------------------------------------
           public virtual void ClickRunImmediatelyWhenDiscoveryIsCreated()
           {
               this.Controls.RunImmediatelyWhenDiscoveryIsCreatedCheckBox.Click();
           }*/

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [dialac] 4/18/2010 Created
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
        ///   [dialac] 4/18/2010 Created
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
            /// Control ID for DiscoverButton
            /// </summary>
            public const string DiscoverButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for RunOnAFixedScheduleComboBox
            /// </summary>
            public const string RunOnAFixedScheduleComboBox = "intervalPeriodPicker";

            ////RunImmediately Checkbox has been removed in CTP1. See #178563.
            /// <summary>
            /// Control ID for RunImmediatelyWhenDiscoveryIsCreatedCheckBox
            /// </summary>
           // public const string RunImmediatelyWhenDiscoveryIsCreatedCheckBox = "runNowOption";
            
            /// <summary>
            /// Control ID for RunOnAFixedScheduleComboBox2
            /// </summary>
            public const string RunOnAFixedScheduleComboBox2 = "intervalPicker";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [dialac] 4/18/2010 Created
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
            /// Contains resource string for:  Discover
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryText
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;DiscoverActionText
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;DiscoveryText
            /// ;Discover;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.AdminResources;DiscoverActionText
            /// ;Discover;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.AdminResources;DiscoveryText
            /// </remark>
            private const string ResourceDiscover = ";&Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resourc" +
                "es.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResour" +
                "ces;DiscoverActionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPDownloadInstallResources;Cancel
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
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;c" +
                "ancelBtn.Text";
            
         /*   /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunImmediatelyWhenDiscoveryIsCreated
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunImmediatelyWhenDiscoveryIsCreated = ";Run immediately when discovery is created;ManagedString;Microsoft.EnterpriseMana" +
                "gement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Intern" +
                "al.UI.Administration.NetworkDiscovery.Schedule;runNowOption.Text";
          */
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
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
            ///   [dialac] 4/18/2010 Created
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
            ///   [dialac] 4/18/2010 Created
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
            /// Gets access to the Discover translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Discover
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDiscover);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                }
            }

            
           /* /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the RunImmediatelyWhenDiscoveryIsCreated translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunImmediatelyWhenDiscoveryIsCreated
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceRunImmediatelyWhenDiscoveryIsCreated);
                }
            }*/
            #endregion
        }
        #endregion
    }
}
