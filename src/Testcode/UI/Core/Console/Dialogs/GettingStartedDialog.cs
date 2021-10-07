// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GettingStartedDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	Getting Started Dialog
// </project>
// <summary>
// 	Getting Started Dialog...
// </summary>
// <history>
// 	[mbickle] 7/12/2005 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using System.ComponentModel;
    #endregion

    #region Interface Definition - IGettingStartedDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGettingStartedDialogControls, for GettingStartedDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 7/12/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGettingStartedDialogControls
    {
        /// <summary>
        /// Read-only property to access GettingStartedStaticControl
        /// </summary>
        StaticControl GettingStartedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfiguringTheMicrosoftOperationsManagerV3StaticControl
        /// </summary>
        StaticControl ConfiguringTheMicrosoftOperationsManagerV3StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl
        /// </summary>
        StaticControl SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheManagementPacksYouWantedToImportStaticControl
        /// </summary>
        StaticControl SelectTheManagementPacksYouWantedToImportStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MigrateComputersAndSettingsFromOperationsManager2005StaticControl
        /// </summary>
        StaticControl MigrateComputersAndSettingsFromOperationsManager2005StaticControl
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
        
        /// <summary>
        /// Read-only property to access RunDiscoveryWizardAndInstallAgentsStaticControl
        /// </summary>
        StaticControl RunDiscoveryWizardAndInstallAgentsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MigrateFromMOM2005StaticControl
        /// </summary>
        StaticControl MigrateFromMOM2005StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DoNotShowThisScreenAgainCheckBox
        /// </summary>
        CheckBox DoNotShowThisScreenAgainCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[mbickle] 7/12/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class GettingStartedDialog : Dialog, IGettingStartedDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to GettingStartedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGettingStartedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfiguringTheMicrosoftOperationsManagerV3StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfiguringTheMicrosoftOperationsManagerV3StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheManagementPacksYouWantedToImportStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheManagementPacksYouWantedToImportStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MigrateComputersAndSettingsFromOperationsManager2005StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMigrateComputersAndSettingsFromOperationsManager2005StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ImportManagementPacksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedImportManagementPacksStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunDiscoveryWizardAndInstallAgentsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunDiscoveryWizardAndInstallAgentsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MigrateFromMOM2005StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMigrateFromMOM2005StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DoNotShowThisScreenAgainCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDoNotShowThisScreenAgainCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GettingStartedDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GettingStartedDialog(ConsoleApp app)
            : base(app, Init(app))
        {
        }
        #endregion
        
        #region IGettingStartedDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGettingStartedDialogControls Controls
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
        ///  Property to handle checkbox DoNotShowThisScreenAgain
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool DoNotShowThisScreenAgain
        {
            get
            {
                return this.Controls.DoNotShowThisScreenAgainCheckBox.Checked;
            }
            
            set
            {
                this.Controls.DoNotShowThisScreenAgainCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GettingStartedStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGettingStartedDialogControls.GettingStartedStaticControl
        {
            get
            {
                if ((this.cachedGettingStartedStaticControl == null))
                {
                    this.cachedGettingStartedStaticControl = new StaticControl(this, GettingStartedDialog.ControlIDs.GettingStartedStaticControl);
                }
                return this.cachedGettingStartedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfiguringTheMicrosoftOperationsManagerV3StaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGettingStartedDialogControls.ConfiguringTheMicrosoftOperationsManagerV3StaticControl
        {
            get
            {
                if ((this.cachedConfiguringTheMicrosoftOperationsManagerV3StaticControl == null))
                {
                    this.cachedConfiguringTheMicrosoftOperationsManagerV3StaticControl = new StaticControl(this, GettingStartedDialog.ControlIDs.ConfiguringTheMicrosoftOperationsManagerV3StaticControl);
                }
                return this.cachedConfiguringTheMicrosoftOperationsManagerV3StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGettingStartedDialogControls.SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl
        {
            get
            {
                if ((this.cachedSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl == null))
                {
                    this.cachedSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl = new StaticControl(this, GettingStartedDialog.ControlIDs.SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl);
                }
                return this.cachedSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheManagementPacksYouWantedToImportStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGettingStartedDialogControls.SelectTheManagementPacksYouWantedToImportStaticControl
        {
            get
            {
                if ((this.cachedSelectTheManagementPacksYouWantedToImportStaticControl == null))
                {
                    this.cachedSelectTheManagementPacksYouWantedToImportStaticControl = new StaticControl(this, GettingStartedDialog.ControlIDs.SelectTheManagementPacksYouWantedToImportStaticControl);
                }
                return this.cachedSelectTheManagementPacksYouWantedToImportStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MigrateComputersAndSettingsFromOperationsManager2005StaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGettingStartedDialogControls.MigrateComputersAndSettingsFromOperationsManager2005StaticControl
        {
            get
            {
                if ((this.cachedMigrateComputersAndSettingsFromOperationsManager2005StaticControl == null))
                {
                    this.cachedMigrateComputersAndSettingsFromOperationsManager2005StaticControl = new StaticControl(this, GettingStartedDialog.ControlIDs.MigrateComputersAndSettingsFromOperationsManager2005StaticControl);
                }
                return this.cachedMigrateComputersAndSettingsFromOperationsManager2005StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ImportManagementPacksStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGettingStartedDialogControls.ImportManagementPacksStaticControl
        {
            get
            {
                if ((this.cachedImportManagementPacksStaticControl == null))
                {
                    this.cachedImportManagementPacksStaticControl = new StaticControl(this, GettingStartedDialog.ControlIDs.ImportManagementPacksStaticControl);
                }
                return this.cachedImportManagementPacksStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunDiscoveryWizardAndInstallAgentsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGettingStartedDialogControls.RunDiscoveryWizardAndInstallAgentsStaticControl
        {
            get
            {
                if ((this.cachedRunDiscoveryWizardAndInstallAgentsStaticControl == null))
                {
                    this.cachedRunDiscoveryWizardAndInstallAgentsStaticControl = new StaticControl(this, GettingStartedDialog.ControlIDs.RunDiscoveryWizardAndInstallAgentsStaticControl);
                }
                return this.cachedRunDiscoveryWizardAndInstallAgentsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MigrateFromMOM2005StaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGettingStartedDialogControls.MigrateFromMOM2005StaticControl
        {
            get
            {
                if ((this.cachedMigrateFromMOM2005StaticControl == null))
                {
                    this.cachedMigrateFromMOM2005StaticControl = new StaticControl(this, GettingStartedDialog.ControlIDs.MigrateFromMOM2005StaticControl);
                }
                return this.cachedMigrateFromMOM2005StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DoNotShowThisScreenAgainCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IGettingStartedDialogControls.DoNotShowThisScreenAgainCheckBox
        {
            get
            {
                if ((this.cachedDoNotShowThisScreenAgainCheckBox == null))
                {
                    this.cachedDoNotShowThisScreenAgainCheckBox = new CheckBox(this, GettingStartedDialog.ControlIDs.DoNotShowThisScreenAgainCheckBox);
                }
                return this.cachedDoNotShowThisScreenAgainCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGettingStartedDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, GettingStartedDialog.ControlIDs.HelpButton);
                }
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGettingStartedDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, GettingStartedDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        #endregion

        /// -------------------------------------------------------------------
        /// <summary>
        /// Checks if the Dialog Exists
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// <returns>true or false</returns>
        /// <history>
        ///     [mbickle] 22JUL05 Created
        /// </history>
        /// -------------------------------------------------------------------
        public static bool Exists(ConsoleApp app)
        {
            try
            {
                Window tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
                if (tempWindow != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                return false;
            }
        }

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DoNotShowThisScreenAgain
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDoNotShowThisScreenAgain()
        {
            this.Controls.DoNotShowThisScreenAgainCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
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
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                Utilities.LogMessage("GettingStartedDialog.Init:: Looking for GettingStartedDialog");
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
                Utilities.LogMessage("GettingStartedDialog.Init:: Found GettingStartedDialog");
            }
            catch (Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("GettingStartedDialog.Init:: GettingStartedDialog not found!");
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
                // tempWindow = null;
                // int numberOfTries = 0;
                // const int MaxTries = 5;
                // while (tempWindow == null && numberOfTries < MaxTries)
                // {
                //     numberOfTries++;
                //     try
                //     {
                //         // look for the window again using wildcards
                //         tempWindow =
                //             new Window(
                //                 app.GetIntlStr(Strings.DialogTitle) + "*",
                //                 StringMatchSyntax.WildCard,
                //                 WindowClassNames.Dialog,
                //                 StringMatchSyntax.ExactMatch,
                //                 app,
                //                 Timeout);
                // 
                //         // wait for the window to report ready
                //         UISynchronization.WaitForUIObjectReady(
                //             tempWindow,
                //             Timeout);
                //     }
                //     catch (Exceptions.WindowNotFoundException)
                //     {
                //         // log the unsuccessful attempt
                //     }
                // }
                // 
                // // check for success
                // if (tempWindow == null)
                // {
                //     // log the failure
                // 
                //     // throw the existing WindowNotFound exception
                //     throw;
                // }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
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
            private const string ResourceDialogTitle = ";Getting Started;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Console.OOBE.GettingStarted;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GettingStarted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGettingStarted = ";Getting Started;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Console.OOBE.GettingStarted;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfiguringTheMicrosoftOperationsManagerV3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfiguringTheMicrosoftOperationsManagerV3 = ";Configuring the Microsoft Operations Manager v3.;ManagedString;Microsoft.MOM.UI." +
                "Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.OOBE.GettingS" +
                "tarted;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM = ";Spicify a query criteria to discover computers and network devices that you woul" +
                "d like to manage by MOM.;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Console.OOBE.GettingStarted;labelDiscovery.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheManagementPacksYouWantedToImport
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheManagementPacksYouWantedToImport = ";Select the management packs you wanted to import.;ManagedString;Microsoft.MOM.UI" +
                ".Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.OOBE.Getting" +
                "Started;labelImportMPS.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MigrateComputersAndSettingsFromOperationsManager2005
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMigrateComputersAndSettingsFromOperationsManager2005 = ";Migrate computers and settings from Operations Manager 2005.;ManagedString;Micro" +
                "soft.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.O" +
                "OBE.GettingStarted;labelMigrate.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ImportManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceImportManagementPacks = ";Import Management Packs;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.Ent" +
                "erpriseManagement.Mom.Internal.UI.Console.OOBE.GettingStarted;linkLabelImportMPS" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunDiscoveryWizardAndInstallAgents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunDiscoveryWizardAndInstallAgents = ";Run Discovery Wizard and Install Agents;ManagedString;Microsoft.MOM.UI.Console.e" +
                "xe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.OOBE.GettingStarted;li" +
                "nkLabelDiscovery.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MigrateFromMOM2005
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMigrateFromMOM2005 = ";Migrate from MOM 2005;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Console.OOBE.GettingStarted;linkLabelMigrate.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DoNotShowThisScreenAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoNotShowThisScreenAgain = ";Do not show this screen again;ManagedString;Microsoft.MOM.UI.Console.exe;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Console.OOBE.GettingStarted;checkBoxDono" +
                "tShow.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Close;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.Internal.UI.Administration.TaskProgress;closeButton.Text";
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
            /// Caches the translated resource string for:  GettingStarted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGettingStarted;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfiguringTheMicrosoftOperationsManagerV3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfiguringTheMicrosoftOperationsManagerV3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheManagementPacksYouWantedToImport
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheManagementPacksYouWantedToImport;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MigrateComputersAndSettingsFromOperationsManager2005
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMigrateComputersAndSettingsFromOperationsManager2005;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ImportManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedImportManagementPacks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunDiscoveryWizardAndInstallAgents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunDiscoveryWizardAndInstallAgents;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MigrateFromMOM2005
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMigrateFromMOM2005;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DoNotShowThisScreenAgain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoNotShowThisScreenAgain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
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
            /// Exposes access to the GettingStarted translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GettingStarted
            {
                get
                {
                    if ((cachedGettingStarted == null))
                    {
                        cachedGettingStarted = CoreManager.MomConsole.GetIntlStr(ResourceGettingStarted);
                    }
                    return cachedGettingStarted;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfiguringTheMicrosoftOperationsManagerV3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfiguringTheMicrosoftOperationsManagerV3
            {
                get
                {
                    if ((cachedConfiguringTheMicrosoftOperationsManagerV3 == null))
                    {
                        cachedConfiguringTheMicrosoftOperationsManagerV3 = CoreManager.MomConsole.GetIntlStr(ResourceConfiguringTheMicrosoftOperationsManagerV3);
                    }
                    return cachedConfiguringTheMicrosoftOperationsManagerV3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM
            {
                get
                {
                    if ((cachedSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM == null))
                    {
                        cachedSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM = CoreManager.MomConsole.GetIntlStr(ResourceSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM);
                    }
                    return cachedSpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOM;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheManagementPacksYouWantedToImport translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheManagementPacksYouWantedToImport
            {
                get
                {
                    if ((cachedSelectTheManagementPacksYouWantedToImport == null))
                    {
                        cachedSelectTheManagementPacksYouWantedToImport = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheManagementPacksYouWantedToImport);
                    }
                    return cachedSelectTheManagementPacksYouWantedToImport;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MigrateComputersAndSettingsFromOperationsManager2005 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MigrateComputersAndSettingsFromOperationsManager2005
            {
                get
                {
                    if ((cachedMigrateComputersAndSettingsFromOperationsManager2005 == null))
                    {
                        cachedMigrateComputersAndSettingsFromOperationsManager2005 = CoreManager.MomConsole.GetIntlStr(ResourceMigrateComputersAndSettingsFromOperationsManager2005);
                    }
                    return cachedMigrateComputersAndSettingsFromOperationsManager2005;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ImportManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunDiscoveryWizardAndInstallAgents translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunDiscoveryWizardAndInstallAgents
            {
                get
                {
                    if ((cachedRunDiscoveryWizardAndInstallAgents == null))
                    {
                        cachedRunDiscoveryWizardAndInstallAgents = CoreManager.MomConsole.GetIntlStr(ResourceRunDiscoveryWizardAndInstallAgents);
                    }
                    return cachedRunDiscoveryWizardAndInstallAgents;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MigrateFromMOM2005 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MigrateFromMOM2005
            {
                get
                {
                    if ((cachedMigrateFromMOM2005 == null))
                    {
                        cachedMigrateFromMOM2005 = CoreManager.MomConsole.GetIntlStr(ResourceMigrateFromMOM2005);
                    }
                    return cachedMigrateFromMOM2005;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DoNotShowThisScreenAgain translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DoNotShowThisScreenAgain
            {
                get
                {
                    if ((cachedDoNotShowThisScreenAgain == null))
                    {
                        cachedDoNotShowThisScreenAgain = CoreManager.MomConsole.GetIntlStr(ResourceDoNotShowThisScreenAgain);
                    }
                    return cachedDoNotShowThisScreenAgain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
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
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 7/12/2005 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mbickle] 7/12/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for GettingStartedStaticControl
            /// </summary>
            public const string GettingStartedStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for ConfiguringTheMicrosoftOperationsManagerV3StaticControl
            /// </summary>
            public const string ConfiguringTheMicrosoftOperationsManagerV3StaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl
            /// </summary>
            public const string SpicifyAQueryCriteriaToDiscoverComputersAndNetworkDevicesThatYouWouldLikeToManageByMOMStaticControl = "labelDiscovery";
            
            /// <summary>
            /// Control ID for SelectTheManagementPacksYouWantedToImportStaticControl
            /// </summary>
            public const string SelectTheManagementPacksYouWantedToImportStaticControl = "labelImportMPS";
            
            /// <summary>
            /// Control ID for MigrateComputersAndSettingsFromOperationsManager2005StaticControl
            /// </summary>
            public const string MigrateComputersAndSettingsFromOperationsManager2005StaticControl = "labelMigrate";
            
            /// <summary>
            /// Control ID for ImportManagementPacksStaticControl
            /// </summary>
            public const string ImportManagementPacksStaticControl = "linkLabelImportMPS";
            
            /// <summary>
            /// Control ID for RunDiscoveryWizardAndInstallAgentsStaticControl
            /// </summary>
            public const string RunDiscoveryWizardAndInstallAgentsStaticControl = "linkLabelDiscovery";
            
            /// <summary>
            /// Control ID for MigrateFromMOM2005StaticControl
            /// </summary>
            public const string MigrateFromMOM2005StaticControl = "linkLabelMigrate";
            
            /// <summary>
            /// Control ID for DoNotShowThisScreenAgainCheckBox
            /// </summary>
            public const string DoNotShowThisScreenAgainCheckBox = "checkBoxDonotShow";
            
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "buttonHelp";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "buttonClose";
        }
        #endregion
    }
}
