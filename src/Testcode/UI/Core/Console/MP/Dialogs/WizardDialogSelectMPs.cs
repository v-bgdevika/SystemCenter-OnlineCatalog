// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WizardDialogSelectMPs.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[zhihaoq] 8/19/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - IWizardDialogSelectMPsControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWizardDialogSelectMPsControls, for WizardDialogSelectMPs.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 8/19/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWizardDialogSelectMPsControls
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
        /// Read-only property to access InstallButton
        /// </summary>
        Button InstallButton
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
        /// Read-only property to access ManagementPacksSelectedToInstallStaticControl
        /// </summary>
        StaticControl ManagementPacksSelectedToInstallStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectMPsToolbar
        /// </summary>
        Toolbar SelectMPsToolbar
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
        /// Read-only property to access ManagementPacksStatusPropertyGridView
        /// </summary>
        PropertyGridView ManagementPacksStatusPropertyGridView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DetailsStaticControl
        /// </summary>
        StaticControl DetailsStaticControl
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
        /// Read-only property to access StatusTextBox
        /// </summary>
        TextBox StatusTextBox
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
        /// Read-only property to access SelectManagementPacksHeaderLabel
        /// </summary>
        StaticControl SelectManagementPacksHeaderLabel
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
    /// 	[zhihaoq] 8/19/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WizardDialogSelectMPs : Dialog, IWizardDialogSelectMPsControls
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
        /// Cache to hold a reference to InstallButton of type Button
        /// </summary>
        private Button cachedInstallButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to SelectManagementPacksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectManagementPacksStaticControl;

        /// <summary>
        /// Cache to hold a reference to ManagementPacksSelectedToInstallStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPacksSelectedToInstallStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectMPsToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedSelectMPsToolbar;

        /// <summary>
        /// Cache to hold a reference to ManagementPacksSelectedToInstallPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedManagementPacksSelectedToInstallPropertyGridView;

        /// <summary>
        /// Cache to hold a reference to ManagementPacksStatusPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedManagementPacksStatusPropertyGridView;

        /// <summary>
        /// Cache to hold a reference to DetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDetailsStaticControl;

        /// <summary>
        /// Cache to hold a reference to DetailsTextBox of type TextBox
        /// </summary>
        private TextBox cachedDetailsTextBox;

        /// <summary>
        /// Cache to hold a reference to StatusTextBox of type TextBox
        /// </summary>
        private TextBox cachedStatusTextBox;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectManagementPacksHeaderLabel of type StaticControl
        /// </summary>
        private StaticControl cachedSelectManagementPacksHeaderLabel;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WizardDialogSelectMPs of type App
        /// </param>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WizardDialogSelectMPs(ConsoleApp app) :
            base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IWizardDialogSelectMPs Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWizardDialogSelectMPsControls Controls
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
        /// 	[zhihaoq] 8/19/2008 Created
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Details
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[rahsing] 02/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StatusText
        {
            get
            {
                return this.Controls.StatusTextBox.Text;
            }

            set
            {
                this.Controls.StatusTextBox.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogSelectMPsControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, WizardDialogSelectMPs.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogSelectMPsControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WizardDialogSelectMPs.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InstallButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogSelectMPsControls.InstallButton
        {
            get
            {
                if ((this.cachedInstallButton == null))
                {
                    this.cachedInstallButton = new Button(this, WizardDialogSelectMPs.ControlIDs.InstallButton);
                }
                return this.cachedInstallButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWizardDialogSelectMPsControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WizardDialogSelectMPs.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectManagementPacksStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogSelectMPsControls.SelectManagementPacksStaticControl
        {
            get
            {
                if ((this.cachedSelectManagementPacksStaticControl == null))
                {
                    this.cachedSelectManagementPacksStaticControl = new StaticControl(this, WizardDialogSelectMPs.ControlIDs.SelectManagementPacksStaticControl);
                }
                return this.cachedSelectManagementPacksStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPacksSelectedToInstallStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogSelectMPsControls.ManagementPacksSelectedToInstallStaticControl
        {
            get
            {
                if ((this.cachedManagementPacksSelectedToInstallStaticControl == null))
                {
                    this.cachedManagementPacksSelectedToInstallStaticControl = new StaticControl(this, WizardDialogSelectMPs.ControlIDs.ManagementPacksSelectedToInstallStaticControl);
                }
                return this.cachedManagementPacksSelectedToInstallStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectMPsToolbar control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IWizardDialogSelectMPsControls.SelectMPsToolbar
        {
            get
            {
                if ((this.cachedSelectMPsToolbar == null))
                {
                    this.cachedSelectMPsToolbar = new Toolbar(this);
                }
                return this.cachedSelectMPsToolbar;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPacksSelectedToInstallPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IWizardDialogSelectMPsControls.ManagementPacksSelectedToInstallPropertyGridView
        {
            get
            {
                if ((this.cachedManagementPacksSelectedToInstallPropertyGridView == null))
                {
                    this.cachedManagementPacksSelectedToInstallPropertyGridView = new PropertyGridView(this, WizardDialogSelectMPs.ControlIDs.ManagementPacksSelectedToInstallPropertyGridView);
                }
                return this.cachedManagementPacksSelectedToInstallPropertyGridView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPacksStatusPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[rahsing] 02/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IWizardDialogSelectMPsControls.ManagementPacksStatusPropertyGridView
        {
            get
            {
                if ((this.cachedManagementPacksStatusPropertyGridView == null))
                {
                    this.cachedManagementPacksStatusPropertyGridView = new PropertyGridView(this, WizardDialogSelectMPs.ControlIDs.ManagementPacksStatusPropertyGridView);
                }
                return this.cachedManagementPacksStatusPropertyGridView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogSelectMPsControls.DetailsStaticControl
        {
            get
            {
                if ((this.cachedDetailsStaticControl == null))
                {
                    this.cachedDetailsStaticControl = new StaticControl(this, WizardDialogSelectMPs.ControlIDs.DetailsStaticControl);
                }
                return this.cachedDetailsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsTextBox control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWizardDialogSelectMPsControls.DetailsTextBox
        {
            get
            {
                if ((this.cachedDetailsTextBox == null))
                {
                    this.cachedDetailsTextBox = new TextBox(this, WizardDialogSelectMPs.ControlIDs.DetailsTextBox);
                }
                return this.cachedDetailsTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusTextBox control
        /// </summary>
        /// <history>
        /// 	[rahsing] 02/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWizardDialogSelectMPsControls.StatusTextBox
        {
            get
            {
                if ((this.cachedStatusTextBox == null))
                {
                    this.cachedStatusTextBox = new TextBox(this, WizardDialogSelectMPs.ControlIDs.StatusTextBox);
                }
                return this.cachedStatusTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogSelectMPsControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, WizardDialogSelectMPs.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectManagementPacksHeaderLabel control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWizardDialogSelectMPsControls.SelectManagementPacksHeaderLabel
        {
            get
            {
                if ((this.cachedSelectManagementPacksHeaderLabel == null))
                {
                    this.cachedSelectManagementPacksHeaderLabel = new StaticControl(this, WizardDialogSelectMPs.ControlIDs.SelectManagementPacksHeaderLabel);
                }
                return this.cachedSelectManagementPacksHeaderLabel;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
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
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Install
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickInstall()
        {
            this.Controls.InstallButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
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
        /// 	[zhihaoq] 8/19/2008 Created
        ///     [a-joelj] 12/3/2008 Updated ResourceDialogTitle to correct resource string
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
            /// Contains resource string for:  Install
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInstall = ";In&stall;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ImportB" +
                "uttonText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

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
            /// Contains resource string for:  ManagementPacksSelectedToInstall
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPacksSelectedToInstall = ";&Management Packs selected to install;ManagedString;Microsoft.EnterpriseManageme" +
                "nt.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administ" +
                "ration.MPDownloadAndInstall.Wizards.Install.SelectInstallMPsPage;selectedMPsLabe" +
                "l.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectMPsToolbar
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectMPsToolbar = ";toolStrip1;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.Comman" +
                "dNotification;toolStrip.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectMPsToolbarAddFromCatalog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectMPsToolbarAddFromCatalog = ";Add from catalog ...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Wizards.Install.SelectInstallMPsPage;addFromCatalogButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectMPsToolbarAddFromDisk
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectMPsToolbarAddFromDisk = ";Add from disk ...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Wizards.Install.SelectInstallMPsPage;addFromDiskButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectMPsContextMenuRemove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectMPsContextMenuRemove = ";Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPDownloadInstallResources;Remove";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectMPsContextMenuResolve
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectMPsContextMenuResolve = ";Resolve;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPDownloadInstallResources;Resolve";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Details
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDetails = ";De&tails :;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resour" +
                "ces.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownload" +
                "AndInstall.Wizards.Install.SelectInstallMPsPage.en;detailLabel.Text";

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
            /// Contains resource string for:  SelectManagementPacks2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectManagementPacks2 = ";Select Management Packs;ManagedString;Microsoft.EnterpriseManagement.UI.Administ" +
                "ration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownl" +
                "oadAndInstall.Wizards.Install.SelectInstallMPsPage;$this.Title";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Online Catalog Connection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCheckCatalogTitle = ";Online Catalog Connection;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPDownloadInstallResources;CheckCatalogTitle";
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
            /// Caches the translated resource string for:  Install
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInstall;

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
            /// Caches the translated resource string for:  ManagementPacksSelectedToInstall
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPacksSelectedToInstall;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectMPsToolbar
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectMPsToolbar;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectMPsToolbarAddFromCatalog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectMPsToolbarAddFromCatalog;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectMPsToolbarAddFromDisk
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectMPsToolbarAddFromDisk;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectMPsContextMenuRemove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectMPsContextMenuRemove;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectMPsContextMenuResolve
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectMPsContextMenuResolve;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Details
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDetails;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectManagementPacks2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectManagementPacks2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CheckCatalogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCheckCatalogTitle;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
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
            /// 	[zhihaoq] 8/19/2008 Created
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
            /// 	[zhihaoq] 8/19/2008 Created
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
            /// Exposes access to the Install translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Install
            {
                get
                {
                    if ((cachedInstall == null))
                    {
                        cachedInstall = CoreManager.MomConsole.GetIntlStr(ResourceInstall);
                    }
                    return cachedInstall;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
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
            /// Exposes access to the SelectManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
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
            /// Exposes access to the ManagementPacksSelectedToInstall translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPacksSelectedToInstall
            {
                get
                {
                    if ((cachedManagementPacksSelectedToInstall == null))
                    {
                        cachedManagementPacksSelectedToInstall = CoreManager.MomConsole.GetIntlStr(ResourceManagementPacksSelectedToInstall);
                    }
                    return cachedManagementPacksSelectedToInstall;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectMPsToolbar translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectMPsToolbar
            {
                get
                {
                    if ((cachedSelectMPsToolbar == null))
                    {
                        cachedSelectMPsToolbar = CoreManager.MomConsole.GetIntlStr(ResourceSelectMPsToolbar);
                    }
                    return cachedSelectMPsToolbar;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectMPsToolbarAddFromCatalog translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectMPsToolbarAddFromCatalog
            {
                get
                {
                    if ((cachedSelectMPsToolbarAddFromCatalog == null))
                    {
                        cachedSelectMPsToolbarAddFromCatalog = CoreManager.MomConsole.GetIntlStr(ResourceSelectMPsToolbarAddFromCatalog);
                    }

                    return cachedSelectMPsToolbarAddFromCatalog;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectMPsToolbarAddFromDisk translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectMPsToolbarAddFromDisk
            {
                get
                {
                    if ((cachedSelectMPsToolbarAddFromDisk == null))
                    {
                        cachedSelectMPsToolbarAddFromDisk = CoreManager.MomConsole.GetIntlStr(ResourceSelectMPsToolbarAddFromDisk);
                    }

                    return cachedSelectMPsToolbarAddFromDisk;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectMPsContextMenuRemove translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectMPsContextMenuRemove
            {
                get
                {
                    if ((cachedSelectMPsContextMenuRemove == null))
                    {
                        cachedSelectMPsContextMenuRemove = CoreManager.MomConsole.GetIntlStr(ResourceSelectMPsContextMenuRemove);
                    }

                    return cachedSelectMPsContextMenuRemove;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectMPsContextMenuResolve translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectMPsContextMenuResolve
            {
                get
                {
                    if ((cachedSelectMPsContextMenuResolve == null))
                    {
                        cachedSelectMPsContextMenuResolve = CoreManager.MomConsole.GetIntlStr(ResourceSelectMPsContextMenuResolve);
                    }

                    return cachedSelectMPsContextMenuResolve;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Details translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Details
            {
                get
                {
                    if ((cachedDetails == null))
                    {
                        cachedDetails = CoreManager.MomConsole.GetIntlStr(ResourceDetails);
                    }
                    return cachedDetails;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
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
            /// Exposes access to the SelectManagementPacks2 translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 8/19/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectManagementPacks2
            {
                get
                {
                    if ((cachedSelectManagementPacks2 == null))
                    {
                        cachedSelectManagementPacks2 = CoreManager.MomConsole.GetIntlStr(ResourceSelectManagementPacks2);
                    }
                    return cachedSelectManagementPacks2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CheckCatalogTitle translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string CheckCatalogTitle
            {
                get
                {
                    if ((cachedCheckCatalogTitle == null))
                    {
                        cachedCheckCatalogTitle = CoreManager.MomConsole.GetIntlStr(ResourceCheckCatalogTitle);
                    }
                    return cachedCheckCatalogTitle;
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
        /// 	[zhihaoq] 8/19/2008 Created
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
            /// Control ID for InstallButton
            /// </summary>
            public const string InstallButton = "commitButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for SelectManagementPacksStaticControl
            /// </summary>
            public const string SelectManagementPacksStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ManagementPacksSelectedToInstallStaticControl
            /// </summary>
            public const string ManagementPacksSelectedToInstallStaticControl = "selectedMPsLabel";

            /// <summary>
            /// Control ID for SelectMPsToolbar
            /// </summary>
            public const string SelectMPsToolbar = "buttonsToolStrip";

            /// <summary>
            /// Control ID for ManagementPacksSelectedToInstallPropertyGridView
            /// </summary>
            public const string ManagementPacksSelectedToInstallPropertyGridView = "selectedMPGridView";

            /// <summary>
            /// Control ID for ManagementPacksStatusPropertyGridView
            /// </summary>
            public const string ManagementPacksStatusPropertyGridView = "statusGridView";

            /// <summary>
            /// Control ID for DetailsStaticControl
            /// </summary>
            public const string DetailsStaticControl = "detailLabel";

            /// <summary>
            /// Control ID for DetailsTextBox
            /// </summary>
            public const string DetailsTextBox = "detailTextBox";

            /// <summary>
            /// Control ID for StatusTextBox
            /// </summary>
            public const string StatusTextBox = "statusTextBox";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for SelectManagementPacksHeaderLabel
            /// </summary>
            public const string SelectManagementPacksHeaderLabel = "headerLabel";
        }
        #endregion
    }
}
