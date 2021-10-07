// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MonitorDependencyDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 Project
// </project>
// <summary>
// 	MOMv3 Project
// </summary>
// <history>
// 	[ruhim] 4/7/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dependency.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IMonitorDependencyDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMonitorDependencyDialogControls, for MonitorDependencyDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMonitorDependencyDialogControls
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
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorDependencyStaticControl
        /// </summary>
        StaticControl MonitorDependencyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HealthRollupPolicyStaticControl
        /// </summary>
        StaticControl HealthRollupPolicyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAlertsStaticControl
        /// </summary>
        StaticControl ConfigureAlertsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KnowledgeStaticControl
        /// </summary>
        StaticControl KnowledgeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl
        /// </summary>
        StaticControl SelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RelTypeRollupTreeView
        /// </summary>
        TreeView RelTypeRollupTreeView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorDependencyStaticControl2
        /// </summary>
        StaticControl MonitorDependencyStaticControl2
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
        /// Read-only property to access ConfigureMonitorDependencyStaticControl
        /// </summary>
        StaticControl ConfigureMonitorDependencyStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Configure Monitor Dependency Dialog" of the 
    /// Create a new dependency rollup monitor wizard
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MonitorDependencyDialog : Dialog, IMonitorDependencyDialogControls
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
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitorDependencyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorDependencyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HealthRollupPolicyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHealthRollupPolicyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KnowledgeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKnowledgeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RelTypeRollupTreeView of type TreeView
        /// </summary>
        private TreeView cachedRelTypeRollupTreeView;
        
        /// <summary>
        /// Cache to hold a reference to MonitorDependencyStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorDependencyStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureMonitorDependencyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureMonitorDependencyStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of MonitorDependencyDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MonitorDependencyDialog(ConsoleApp app)
            : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);  
        }
        #endregion
        
        #region IMonitorDependencyDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMonitorDependencyDialogControls Controls
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
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorDependencyDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, MonitorDependencyDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorDependencyDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, MonitorDependencyDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorDependencyDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, MonitorDependencyDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMonitorDependencyDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MonitorDependencyDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, MonitorDependencyDialog.ControlIDs.GeneralPropertiesStaticControl);
                }
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorDependencyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.MonitorDependencyStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedMonitorDependencyStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedMonitorDependencyStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedMonitorDependencyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HealthRollupPolicyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.HealthRollupPolicyStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedHealthRollupPolicyStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedHealthRollupPolicyStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedHealthRollupPolicyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedConfigureAlertsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureAlertsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KnowledgeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.KnowledgeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedKnowledgeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedKnowledgeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedKnowledgeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.SelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl
        {
            get
            {
                if ((this.cachedSelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl == null))
                {
                    this.cachedSelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl = new StaticControl(this, MonitorDependencyDialog.ControlIDs.SelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl);
                }
                return this.cachedSelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RelTypeRollupTreeView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IMonitorDependencyDialogControls.RelTypeRollupTreeView
        {
            get
            {
                if ((this.cachedRelTypeRollupTreeView == null))
                {
                    this.cachedRelTypeRollupTreeView = new TreeView(this, MonitorDependencyDialog.ControlIDs.RelTypeRollupTreeView);
                }
                return this.cachedRelTypeRollupTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorDependencyStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.MonitorDependencyStaticControl2
        {
            get
            {
                if ((this.cachedMonitorDependencyStaticControl2 == null))
                {
                    this.cachedMonitorDependencyStaticControl2 = new StaticControl(this, MonitorDependencyDialog.ControlIDs.MonitorDependencyStaticControl2);
                }
                return this.cachedMonitorDependencyStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, MonitorDependencyDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureMonitorDependencyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMonitorDependencyDialogControls.ConfigureMonitorDependencyStaticControl
        {
            get
            {
                if ((this.cachedConfigureMonitorDependencyStaticControl == null))
                {
                    this.cachedConfigureMonitorDependencyStaticControl = new StaticControl(this, MonitorDependencyDialog.ControlIDs.ConfigureMonitorDependencyStaticControl);
                }
                return this.cachedConfigureMonitorDependencyStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
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
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
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
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
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
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[ruhim] 4/7/2006 Created
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
            private const string ResourceDialogTitle =
                ";Create a new dependency monitor;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorTypes.MonitorTypeResources;CreateDependencyMonitorWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.Common.PageCommonResources;CommitButtonText" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorDependency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorDependency = ";Monitor Dependency;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.EditDependencyPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HealthRollupPolicy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthRollupPolicy = ";Health Rollup Policy;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.AggregateRollupPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKnowledge = ";Knowledge;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.ProductKnowledgePage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAMonitorToDependOnFromTheFollowingRelatedClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAMonitorToDependOnFromTheFollowingRelatedClasses = ";Select a monitor to &depend on from the following related classes:;ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI." +
                "Authoring.Pages.EditDependencyPage;selectMonitorLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorDependency2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorDependency2 = ";Monitor Dependency;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.EditDependencyPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureMonitorDependency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureMonitorDependency = ";Configure Monitor Dependency;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.EditDependencyPage;$this.Heade" +
                "rText";
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
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorDependency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorDependency;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HealthRollupPolicy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthRollupPolicy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKnowledge;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAMonitorToDependOnFromTheFollowingRelatedClasses
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAMonitorToDependOnFromTheFollowingRelatedClasses;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorDependency2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorDependency2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureMonitorDependency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureMonitorDependency;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// 	[ruhim] 4/7/2006 Created
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
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    return cachedCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties
            {
                get
                {
                    if ((cachedGeneralProperties == null))
                    {
                        cachedGeneralProperties = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties);
                    }
                    return cachedGeneralProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitorDependency translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorDependency
            {
                get
                {
                    if ((cachedMonitorDependency == null))
                    {
                        cachedMonitorDependency = CoreManager.MomConsole.GetIntlStr(ResourceMonitorDependency);
                    }
                    return cachedMonitorDependency;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HealthRollupPolicy translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthRollupPolicy
            {
                get
                {
                    if ((cachedHealthRollupPolicy == null))
                    {
                        cachedHealthRollupPolicy = CoreManager.MomConsole.GetIntlStr(ResourceHealthRollupPolicy);
                    }
                    return cachedHealthRollupPolicy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAlerts
            {
                get
                {
                    if ((cachedConfigureAlerts == null))
                    {
                        cachedConfigureAlerts = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAlerts);
                    }
                    return cachedConfigureAlerts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Knowledge translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Knowledge
            {
                get
                {
                    if ((cachedKnowledge == null))
                    {
                        cachedKnowledge = CoreManager.MomConsole.GetIntlStr(ResourceKnowledge);
                    }
                    return cachedKnowledge;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAMonitorToDependOnFromTheFollowingRelatedClasses translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectAMonitorToDependOnFromTheFollowingRelatedClasses
            {
                get
                {
                    if ((cachedSelectAMonitorToDependOnFromTheFollowingRelatedClasses == null))
                    {
                        cachedSelectAMonitorToDependOnFromTheFollowingRelatedClasses = CoreManager.MomConsole.GetIntlStr(ResourceSelectAMonitorToDependOnFromTheFollowingRelatedClasses);
                    }
                    return cachedSelectAMonitorToDependOnFromTheFollowingRelatedClasses;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitorDependency2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorDependency2
            {
                get
                {
                    if ((cachedMonitorDependency2 == null))
                    {
                        cachedMonitorDependency2 = CoreManager.MomConsole.GetIntlStr(ResourceMonitorDependency2);
                    }
                    return cachedMonitorDependency2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the ConfigureMonitorDependency translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureMonitorDependency
            {
                get
                {
                    if ((cachedConfigureMonitorDependency == null))
                    {
                        cachedConfigureMonitorDependency = CoreManager.MomConsole.GetIntlStr(ResourceConfigureMonitorDependency);
                    }
                    return cachedConfigureMonitorDependency;
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
        /// 	[ruhim] 4/7/2006 Created
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
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for MonitorDependencyStaticControl
            /// </summary>
            public const string MonitorDependencyStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for HealthRollupPolicyStaticControl
            /// </summary>
            public const string HealthRollupPolicyStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for KnowledgeStaticControl
            /// </summary>
            public const string KnowledgeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl
            /// </summary>
            public const string SelectAMonitorToDependOnFromTheFollowingRelatedClassesStaticControl = "selectMonitorLabel";
            
            /// <summary>
            /// Control ID for RelTypeRollupTreeView
            /// </summary>
            public const string RelTypeRollupTreeView = "relTypeMonitorTree";
            
            /// <summary>
            /// Control ID for MonitorDependencyStaticControl2
            /// </summary>
            public const string MonitorDependencyStaticControl2 = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureMonitorDependencyStaticControl
            /// </summary>
            public const string ConfigureMonitorDependencyStaticControl = "headerLabel";
        }
        #endregion
    }
}
