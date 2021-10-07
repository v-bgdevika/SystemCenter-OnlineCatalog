// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WizardDialogImportMPs.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[zhihaoq] 10/2/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IWizardDialogImportMPsControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWizardDialogImportMPsControls, for WizardDialogImportMPs.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 10/2/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWizardDialogImportMPsControls
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
        /// Read-only property to access StopButton
        /// </summary>
        Button StopButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
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
        /// Read-only property to access SelectManagementPacksStaticControl
        /// </summary>
        StaticControl SelectManagementPacksStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DetailsTextBox
        /// </summary>
        TextBox DetailsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPacksSelectedToInstallPropertyGridView
        /// </summary>
        PropertyGridView ManagementPacksSelectedToInstallPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl
        /// </summary>
        StaticControl DownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl
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
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ImportManagementPacksStaticControl
        /// </summary>
        StaticControl ImportManagementPacksStaticControl
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
    /// 	[zhihaoq] 10/2/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WizardDialogImportMPs : Dialog, IWizardDialogImportMPsControls
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
        /// Cache to hold a reference to StopButton of type Button
        /// </summary>
        private Button cachedStopButton;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectManagementPacksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectManagementPacksStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DetailsTextBox of type TextBox
        /// </summary>
        private TextBox cachedDetailsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPacksSelectedToInstallPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedManagementPacksSelectedToInstallPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to DownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ImportManagementPacksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedImportManagementPacksStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WizardDialogImportMPs of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WizardDialogImportMPs(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IWizardDialogImportMPs Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWizardDialogImportMPsControls Controls
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
        ///  Routine to set/get the text in control Details
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DetailsText
        {
            get
            {
                return this.Controls.DetailsTextBox.Text;
            }
            
            set
            {
                this.Controls.DetailsTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogImportMPsControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, WizardDialogImportMPs.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogImportMPsControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WizardDialogImportMPs.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StopButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// 	[v-vijia] 18/4/2011 Edited
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogImportMPsControls.StopButton
        {
            get
            {
                if ((this.cachedStopButton == null))
                {
                    //Bug#206729
                    this.cachedStopButton = new Button(this, new QID(";[UIA]Name='" + ControlIDs.StopButtonName + "'"));
                }
                return this.cachedStopButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// 	[v-vijia] 19/7/2011 Edited
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogImportMPsControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    QID qid = new QID(string.Format(";[UIA]Name = '{0}' && AutomationId = '{1}'",
                                 Strings.Close,
                                 ControlIDs.CancelCloseButtonAutomationId));

                    this.cachedCloseButton = new Button(this, qid, Mom.Test.UI.Core.Common.Constants.OneSecond * 3);
                }
                return this.cachedCloseButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[v-vijia] 19/7/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogImportMPsControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    QID qid = new QID(string.Format(";[UIA]Name = '{0}' && AutomationId = '{1}'",
                                 Strings.Cancel,
                                 ControlIDs.CancelCloseButtonAutomationId));

                    this.cachedCancelButton = new Button(this, qid, Mom.Test.UI.Core.Common.Constants.OneSecond * 3);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectManagementPacksStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogImportMPsControls.SelectManagementPacksStaticControl
        {
            get
            {
                if ((this.cachedSelectManagementPacksStaticControl == null))
                {
                    this.cachedSelectManagementPacksStaticControl = new StaticControl(this, WizardDialogImportMPs.ControlIDs.SelectManagementPacksStaticControl);
                }
                return this.cachedSelectManagementPacksStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsTextBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWizardDialogImportMPsControls.DetailsTextBox
        {
            get
            {
                if ((this.cachedDetailsTextBox == null))
                {
                    this.cachedDetailsTextBox = new TextBox(this, WizardDialogImportMPs.ControlIDs.DetailsTextBox);
                }
                return this.cachedDetailsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPacksSelectedToInstallPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IWizardDialogImportMPsControls.ManagementPacksSelectedToInstallPropertyGridView
        {
            get
            {
                if ((this.cachedManagementPacksSelectedToInstallPropertyGridView == null))
                {
                    this.cachedManagementPacksSelectedToInstallPropertyGridView = new PropertyGridView(this, WizardDialogImportMPs.ControlIDs.ManagementPacksSelectedToInstallPropertyGridView);
                }
                return this.cachedManagementPacksSelectedToInstallPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogImportMPsControls.DownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl
        {
            get
            {
                if ((this.cachedDownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl == null))
                {
                    this.cachedDownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl = new StaticControl(this, WizardDialogImportMPs.ControlIDs.DownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl);
                }
                return this.cachedDownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogImportMPsControls.SummaryStaticControl
        {
            get
            {
                if ((this.cachedSummaryStaticControl == null))
                {
                    this.cachedSummaryStaticControl = new StaticControl(this, WizardDialogImportMPs.ControlIDs.SummaryStaticControl);
                }
                return this.cachedSummaryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogImportMPsControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, WizardDialogImportMPs.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ImportManagementPacksStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogImportMPsControls.ImportManagementPacksStaticControl
        {
            get
            {
                if ((this.cachedImportManagementPacksStaticControl == null))
                {
                    this.cachedImportManagementPacksStaticControl = new StaticControl(this, WizardDialogImportMPs.ControlIDs.ImportManagementPacksStaticControl);
                }
                return this.cachedImportManagementPacksStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
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
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Stop
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickStop()
        {
            this.Controls.StopButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[zhihaoq] 10/2/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
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
                                StringMatchSyntax.WildCard
                                );

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt" + numberOfTries + " of " + MaxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title: '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
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
        /// 	[zhihaoq] 10/2/2008 Created
        ///     [a-joelj] 12/11/2008 Updated ResourceDialogTitle to correct resource string
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Import Management Packs;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;MPInstallWizardTitle";
            
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
            /// Contains resource string for:  Stop
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStop = ";&Stop;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPDo" +
                "wnloadInstallResources;StopProgress";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Cl&ose;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPD" +
                "ownloadInstallResources;Close";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDialog;cancelButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectManagementPacks = ";Select Management Packs;ManagedString;Microsoft.EnterpriseManagement.UI.Administ" +
                "ration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownl" +
                "oadAndInstall.Wizards.Install.SelectInstallMPsPage;$this.Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DownloadingAndInstallingManagementPacksYouHaveSelectedToImport
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDownloadingAndInstallingManagementPacksYouHaveSelectedToImport = @";&Downloading and installing Management Packs you have selected to import;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Wizards.Common.StatusPage;infoLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";&Summary : ;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resou" +
                "rces.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloa" +
                "dAndInstall.Wizards.Common.StatusPage.en;summaryLabel.Text";
            
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
            /// Contains resource string for:  ImportManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceImportManagementPacks = ";Import Management Packs;ManagedString;Microsoft.EnterpriseManagement.UI.Administ" +
                "ration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminRe" +
                "sources;MPInstallWizardTitle";
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
            /// Caches the translated resource string for:  Stop
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStop;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectManagementPacks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DownloadingAndInstallingManagementPacksYouHaveSelectedToImport
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDownloadingAndInstallingManagementPacksYouHaveSelectedToImport;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ImportManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedImportManagementPacks;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/2/2008 Created
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
            /// 	[zhihaoq] 10/2/2008 Created
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
            /// 	[zhihaoq] 10/2/2008 Created
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
            /// Exposes access to the Stop translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/2/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Stop
            {
                get
                {
                    if ((cachedStop == null))
                    {
                        cachedStop = CoreManager.MomConsole.GetIntlStr(ResourceStop);
                    }
                    return cachedStop;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/2/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    if ((cachedClose == null))
                    {
                        cachedClose = Mom.Test.UI.Core.Common.Utilities.RemoveAcceleratorKeys(CoreManager.MomConsole.GetIntlStr(ResourceClose));
                    }
                    return cachedClose;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[v-vijia] 19/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = Mom.Test.UI.Core.Common.Utilities.RemoveAcceleratorKeys(CoreManager.MomConsole.GetIntlStr(ResourceCancel));
                    }
                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/2/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectManagementPacks
            {
                get
                {
                    if ((cachedSelectManagementPacks == null))
                    {
                        cachedSelectManagementPacks = CoreManager.MomConsole.GetIntlStr(ResourceSelectManagementPacks);
                    }
                    return cachedSelectManagementPacks;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DownloadingAndInstallingManagementPacksYouHaveSelectedToImport translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/2/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DownloadingAndInstallingManagementPacksYouHaveSelectedToImport
            {
                get
                {
                    if ((cachedDownloadingAndInstallingManagementPacksYouHaveSelectedToImport == null))
                    {
                        cachedDownloadingAndInstallingManagementPacksYouHaveSelectedToImport = CoreManager.MomConsole.GetIntlStr(ResourceDownloadingAndInstallingManagementPacksYouHaveSelectedToImport);
                    }
                    return cachedDownloadingAndInstallingManagementPacksYouHaveSelectedToImport;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/2/2008 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/2/2008 Created
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
            /// Exposes access to the ImportManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/2/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ImportManagementPacks
            {
                get
                {
                    if ((cachedImportManagementPacks == null))
                    {
                        cachedImportManagementPacks = CoreManager.MomConsole.GetIntlStr(ResourceImportManagementPacks);
                    }
                    return cachedImportManagementPacks;
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
        /// 	[zhihaoq] 10/2/2008 Created
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
            /// AutomationID for CloseButton and CancelButton
            /// </summary>
            public const string CancelCloseButtonAutomationId = "cancelButton";

            /// <summary>
            /// Control ID for StopButton
            /// </summary>
            public const string StopButtonName = "Stop";

            /// <summary>
            /// Control ID for SelectManagementPacksStaticControl
            /// </summary>
            public const string SelectManagementPacksStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DetailsTextBox
            /// </summary>
            public const string DetailsTextBox = "statusTextBox";
            
            /// <summary>
            /// Control ID for ManagementPacksSelectedToInstallPropertyGridView
            /// </summary>
            public const string ManagementPacksSelectedToInstallPropertyGridView = "statusGridView";
            
            /// <summary>
            /// Control ID for DownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl
            /// </summary>
            public const string DownloadingAndInstallingManagementPacksYouHaveSelectedToImportStaticControl = "infoLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "summaryLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ImportManagementPacksStaticControl
            /// </summary>
            public const string ImportManagementPacksStaticControl = "headerLabel";
        }
        #endregion
    }
}
