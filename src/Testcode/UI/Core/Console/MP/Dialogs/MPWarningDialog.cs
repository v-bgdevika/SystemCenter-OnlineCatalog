// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MPWarningDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[zhihaoq] 10/18/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IMPWarningDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMPWarningDialogControls, for MPWarningDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 10/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMPWarningDialogControls
    {
        /// <summary>
        /// Read-only property to access MissingDependentManagementPacksPropertyGridView
        /// </summary>
        PropertyGridView MissingDependentManagementPacksPropertyGridView
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
        /// Read-only property to access ResolveButton
        /// </summary>
        Button ResolveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli
        /// </summary>
        StaticControl SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningResolveManagementPackDependenciesStaticControl
        /// </summary>
        StaticControl WarningResolveManagementPackDependenciesStaticControl
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
    /// 	[zhihaoq] 10/18/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MPWarningDialog : Dialog, IMPWarningDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to MissingDependentManagementPacksPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedMissingDependentManagementPacksPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ResolveButton of type Button
        /// </summary>
        private Button cachedResolveButton;
        
        /// <summary>
        /// Cache to hold a reference to SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli of type StaticControl
        /// </summary>
        private StaticControl cachedSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli;
        
        /// <summary>
        /// Cache to hold a reference to WarningResolveManagementPackDependenciesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWarningResolveManagementPackDependenciesStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of MPWarningDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MPWarningDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IMPWarningDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMPWarningDialogControls Controls
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
        ///  Exposes access to the MissingDependentManagementPacksPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IMPWarningDialogControls.MissingDependentManagementPacksPropertyGridView
        {
            get
            {
                if ((this.cachedMissingDependentManagementPacksPropertyGridView == null))
                {
                    this.cachedMissingDependentManagementPacksPropertyGridView = new PropertyGridView(this, MPWarningDialog.ControlIDs.MissingDependentManagementPacksPropertyGridView);
                }
                return this.cachedMissingDependentManagementPacksPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMPWarningDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MPWarningDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolveButton control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMPWarningDialogControls.ResolveButton
        {
            get
            {
                if ((this.cachedResolveButton == null))
                {
                    this.cachedResolveButton = new Button(this, MPWarningDialog.ControlIDs.ResolveButton);
                }
                return this.cachedResolveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPWarningDialogControls.SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli
        {
            get
            {
                if ((this.cachedSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli == null))
                {
                    this.cachedSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli = new StaticControl(this, MPWarningDialog.ControlIDs.SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli);
                }
                return this.cachedSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WarningResolveManagementPackDependenciesStaticControl control
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMPWarningDialogControls.WarningResolveManagementPackDependenciesStaticControl
        {
            get
            {
                if ((this.cachedWarningResolveManagementPackDependenciesStaticControl == null))
                {
                    this.cachedWarningResolveManagementPackDependenciesStaticControl = new StaticControl(this, MPWarningDialog.ControlIDs.WarningResolveManagementPackDependenciesStaticControl);
                }
                return this.cachedWarningResolveManagementPackDependenciesStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Resolve
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickResolve()
        {
            this.Controls.ResolveButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[zhihaoq] 10/18/2008 Created
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
        /// 	[zhihaoq] 10/18/2008 Created
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
            /// <history>
            ///  [sunsingh] 1/27/2009 Updated ResourceDialogTitle to correct resource string
            /// </history>
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Dependency Warning;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.ResolveDependentsDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Resolve
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResolve = ";&Resolve;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.D" +
                "ialogs.ResolveDependentsDialog;resolveButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli = "SQL Server 2000 (Discovery) depends on management packs that are not imported but" +
                " are available in the online catalog.  Click Resolve to add the dependent manage" +
                "ment packs to the Import list.";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WarningResolveManagementPackDependencies
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWarningResolveManagementPackDependencies = ";Warning : Resolve management pack dependencies;ManagedString;Microsoft.Enterpris" +
                "eManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI" +
                ".Administration.MPDownloadAndInstall.Dialogs.ResolveDependentsDialog;titleLabel." +
                "Text";
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
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Resolve
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolve;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WarningResolveManagementPackDependencies
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWarningResolveManagementPackDependencies;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
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
            /// Exposes access to the Resolve translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Resolve
            {
                get
                {
                    if ((cachedResolve == null))
                    {
                        cachedResolve = CoreManager.MomConsole.GetIntlStr(ResourceResolve);
                    }
                    return cachedResolve;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli
            {
                get
                {
                    if ((cachedSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli == null))
                    {
                        cachedSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli = CoreManager.MomConsole.GetIntlStr(ResourceSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli);
                    }
                    return cachedSQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WarningResolveManagementPackDependencies translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 10/18/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WarningResolveManagementPackDependencies
            {
                get
                {
                    if ((cachedWarningResolveManagementPackDependencies == null))
                    {
                        cachedWarningResolveManagementPackDependencies = CoreManager.MomConsole.GetIntlStr(ResourceWarningResolveManagementPackDependencies);
                    }
                    return cachedWarningResolveManagementPackDependencies;
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
        /// 	[zhihaoq] 10/18/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for MissingDependentManagementPacksPropertyGridView
            /// </summary>
            public const string MissingDependentManagementPacksPropertyGridView = "resolveMPGridView";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for ResolveButton
            /// </summary>
            public const string ResolveButton = "resolveButton";
            
            /// <summary>
            /// Control ID for SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli
            /// </summary>
            public const string SQLServer2000DiscoveryDependsOnManagementPacksThatAreNotImportedButAreAvailableInTheOnlineCatalogCli = "infoLabel";
            
            /// <summary>
            /// Control ID for WarningResolveManagementPackDependenciesStaticControl
            /// </summary>
            public const string WarningResolveManagementPackDependenciesStaticControl = "titleLabel";
        }
        #endregion
    }
}
