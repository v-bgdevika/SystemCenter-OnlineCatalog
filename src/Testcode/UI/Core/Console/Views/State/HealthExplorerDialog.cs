// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="HealthExplorerDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Console
// </project>
// <summary>
// 	Health Explorer
// </summary>
// <history>
// 	[mbickle] 20APR06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.State
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;

    #endregion

    #region Interface Definition - IHealthExplorerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IHealthExplorerDialogControls, for HealthExplorerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 20APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHealthExplorerDialogControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HealthMonitorsForStaticControl
        /// </summary>
        StaticControl HealthMonitorsForStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HealthMonitorsForTreeView
        /// </summary>
        TreeView HealthMonitorsForTreeView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MainTabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl MainTabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Grid
        /// </summary>
        PropertyGridView Grid
        {
            get;
        }

        /// <summary>
        /// Read-only property to access HtmlDoc
        /// </summary>
        HtmlDocument HtmlDoc
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StateChangeEventContextStaticControl
        /// </summary>
        StaticControl StateChangeEventContextStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MainToolbar
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar MainToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Overrides
        /// </summary>
        Toolbar Overrides
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
    /// 	[mbickle] 20APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class HealthExplorerDialog : Dialog, IHealthExplorerDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 5000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to HealthMonitorsForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHealthMonitorsForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HealthMonitorsForTreeView of type TreeView
        /// </summary>
        private TreeView cachedHealthMonitorsForTreeView;
        
        /// <summary>
        /// Cache to hold a reference to MainTabControl of type TabControl
        /// </summary>
        private TabControl cachedMainTabControl;
        
        /// <summary>
        /// Cache to hold a reference to Grid of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedGrid;
        
        /// <summary>
        /// Cache to hold a reference to HtmlDoc of type HtmlDocument
        /// </summary>
        private HtmlDocument cachedHtmlDoc;
        
        /// <summary>
        /// Cache to hold a reference to StateChangeEventContextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStateChangeEventContextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MainToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedMainToolbar;
        
        /// <summary>
        /// Cache to hold a reference to Overrides of type Toolbar
        /// </summary>
        private Toolbar cachedOverrides;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of HealthExplorerDialog of type App
        /// </param>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public HealthExplorerDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IHealthExplorerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IHealthExplorerDialogControls Controls
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
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHealthExplorerDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, HealthExplorerDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HealthMonitorsForStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthExplorerDialogControls.HealthMonitorsForStaticControl
        {
            get
            {
                if ((this.cachedHealthMonitorsForStaticControl == null))
                {
                    this.cachedHealthMonitorsForStaticControl = new StaticControl(this, HealthExplorerDialog.ControlIDs.HealthMonitorsForStaticControl);
                }
                return this.cachedHealthMonitorsForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HealthMonitorsForTreeView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IHealthExplorerDialogControls.HealthMonitorsForTreeView
        {
            get
            {
                if ((this.cachedHealthMonitorsForTreeView == null))
                {
                    this.cachedHealthMonitorsForTreeView = new TreeView(this, "*", StringMatchSyntax.WildCard, WindowClassNames.WinFormsTreeView, StringMatchSyntax.WildCard);
                }
                return this.cachedHealthMonitorsForTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MainTabControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IHealthExplorerDialogControls.MainTabControl
        {
            get
            {
                if ((this.cachedMainTabControl == null))
                {
                    this.cachedMainTabControl = new TabControl(this, HealthExplorerDialog.ControlIDs.MainTabControl);
                }
                return this.cachedMainTabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Grid control
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IHealthExplorerDialogControls.Grid
        {
            get
            {
                if ((this.cachedGrid == null))
                {
                    this.cachedGrid = new PropertyGridView(this, HealthExplorerDialog.ControlIDs.Grid);
                }
                return this.cachedGrid;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HtmlDoc control
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        HtmlDocument IHealthExplorerDialogControls.HtmlDoc
        {
            get
            {
                if ((this.cachedHtmlDoc == null))
                {
                    Window wndTemp = this;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild.Extended.NextSibling;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild.Extended.NextSibling;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild.Extended.NextSibling;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    //wndTemp = wndTemp.Extended.FirstChild;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedHtmlDoc = new HtmlDocument(wndTemp);
                }
                return this.cachedHtmlDoc;


            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StateChangeEventContextStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthExplorerDialogControls.StateChangeEventContextStaticControl
        {
            get
            {
                if ((this.cachedStateChangeEventContextStaticControl == null))
                {
                    this.cachedStateChangeEventContextStaticControl = new StaticControl(this, HealthExplorerDialog.ControlIDs.StateChangeEventContextStaticControl);
                }
                return this.cachedStateChangeEventContextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MainToolbar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IHealthExplorerDialogControls.MainToolbar
        {
            get
            {
                if ((this.cachedMainToolbar == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedMainToolbar = new Toolbar(wndTemp);
                }
                return this.cachedMainToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Overrides control
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IHealthExplorerDialogControls.Overrides
        {
            get
            {
                if ((this.cachedOverrides == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedOverrides = new Toolbar(wndTemp);
                }
                return this.cachedOverrides;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[mbickle] 20APR06 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.WildCard,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 20;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "HealthExplorerDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "HealthExplorerDialog:: Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw;
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
        /// 	[mbickle] 20APR06 Created
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
            private const string ResourceDialogTitle = ";Health Explorer for {0};ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;HealthExplorerTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Close;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.DateEnterDropDo" +
                "wn;closeButton.ToolTipText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HealthMonitorsForSingleUrlTemplatePerspective
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthMonitorsForSingleUrlTemplatePerspective = "Health monitors for SingleUrlTemplatePerspective";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Grid
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGrid = ";Grid;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Internal.UI.Authoring.Pages.OperationalStatesMappingP" +
                "age;statesGridView.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StateChangeEventContext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStateChangeEventContext = ";State change event context;ManagedString;Microsoft.MOM.UI.Components.dll;Microso" +
                "ft.EnterpriseManagement.Mom.UI.MonitorState;eventContextLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Overrides
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOverrides = ";Overrides;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.Monitoring.Commands.CommandResources;Overrides";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Health Explorer context menu for Alerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthExplorerContextMenu = ";&Health Explorer;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;ShowHealthExplorerText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Reset Health context menu on Health Explorer dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResetHealthContextMenu = ";R&eset Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;ResetHealthText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Recalculate Health context menu on Health Explorer dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRecalculateHealthContextMenu = ";&Recalculate Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;RecalcHealthText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Refresh context menu on Health Explorer dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRefreshHealtheContextMenu = ";Refresh;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;RefreshText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  View Alerts context menu on Health Explorer dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAlertsContextMenu = ";View Alerts for {0}...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;HELaunchAlertFormat";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Reset Health Confirm dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResetHealthDialogTitle = ";Reset Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;ResetHealthTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Recalculate Health Confirm dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRecalculateHealthDialogTitle = ";Recalculate Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;RecalcHealthTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Knowledge Tab Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKnowledgeTabName = ";Knowledge;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitorState;knowledgeTabPage.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  State Change Event Tab Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStateChangeEventTabName = ";State Change Events;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitorState;stateChangeTabPage.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Confirm Action Dialog Title name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmActionDialogTitle = ";Confirm Action;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;HealthExplorerConfirmActionCaption";
            
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
            /// Caches the translated resource string for:  HealthMonitorsForSingleUrlTemplatePerspective
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthMonitorsForSingleUrlTemplatePerspective;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Grid
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGrid;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StateChangeEventContext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStateChangeEventContext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Overrides
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverrides;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Health Explorer Context Menu for Alerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthExplorerContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Reset Health context menu on Health Explorer dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResetHealthContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Recalculate Health context menu on Health Explorer dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecalculateHealthContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Refresh context menu on Health Explorer dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRefreshContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Alerts context menu on Health Explorer dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAlertsContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Reset Health Confirm dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResetHealthDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Recalculate Health Confirm dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecalculateHealtheDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Knowledge Tab Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKnowlegeTabName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  State Event Change Tab Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStateEventChangeTabName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Confirm Aciton dialog title name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmActionDialogTitle;
            
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 20APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle).Replace("{0}", "*").Trim();
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 20APR06 Created
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
            /// Exposes access to the HealthMonitorsForSingleUrlTemplatePerspective translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 20APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthMonitorsForSingleUrlTemplatePerspective
            {
                get
                {
                    if ((cachedHealthMonitorsForSingleUrlTemplatePerspective == null))
                    {
                        cachedHealthMonitorsForSingleUrlTemplatePerspective = CoreManager.MomConsole.GetIntlStr(ResourceHealthMonitorsForSingleUrlTemplatePerspective);
                    }
                    return cachedHealthMonitorsForSingleUrlTemplatePerspective;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 20APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Grid translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 20APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Grid
            {
                get
                {
                    if ((cachedGrid == null))
                    {
                        cachedGrid = CoreManager.MomConsole.GetIntlStr(ResourceGrid);
                    }
                    return cachedGrid;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StateChangeEventContext translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 20APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateChangeEventContext
            {
                get
                {
                    if ((cachedStateChangeEventContext == null))
                    {
                        cachedStateChangeEventContext = CoreManager.MomConsole.GetIntlStr(ResourceStateChangeEventContext);
                    }
                    return cachedStateChangeEventContext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Overrides translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 20APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Overrides
            {
                get
                {
                    if ((cachedOverrides == null))
                    {
                        cachedOverrides = CoreManager.MomConsole.GetIntlStr(ResourceOverrides);
                    }
                    return cachedOverrides;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HealthExplorerContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 17MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthExplorerContextMenu
            {
                get
                {
                    if (cachedHealthExplorerContextMenu == null)
                    {
                        cachedHealthExplorerContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceHealthExplorerContextMenu);
                    }
                    return cachedHealthExplorerContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResetHealth context menu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 18MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResetHealthContextMenu
            {
                get
                {
                    if (cachedResetHealthContextMenu == null)
                    {
                        cachedResetHealthContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceResetHealthContextMenu);
                    }
                    return cachedResetHealthContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RecalculateHealth context menu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 18MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecaculateHealtheContextMenu
            {
                get
                {
                    if (cachedRecalculateHealthContextMenu == null)
                    {
                        cachedRecalculateHealthContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceRecalculateHealthContextMenu);
                    }
                    return cachedRecalculateHealthContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Refresh context menu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 18MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RefreshHealthContextMenu
            {
                get
                {
                    if (cachedRefreshContextMenu == null)
                    {
                        cachedRefreshContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceRefreshHealtheContextMenu);
                    }
                    return cachedRefreshContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Alerts context menu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 18MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAlertsContextMenu
            {
                get
                {
                    if ((cachedViewAlertsContextMenu == null))
                    {
                        cachedViewAlertsContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceViewAlertsContextMenu).Replace("{0}...", "*").Trim();
                    }
                    return cachedViewAlertsContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Reset Health Confirm dialog title translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 18MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResetHealthDialogTitle
            {
                get
                {
                    if (cachedResetHealthDialogTitle == null)
                    {
                        cachedResetHealthDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceResetHealthDialogTitle);
                    }
                    return cachedResetHealthDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Recalculate Health Confirm dialog title translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 18MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecalculateHealthDialogTitle
            {
                get
                {
                    if (cachedRecalculateHealtheDialogTitle == null)
                    {
                        cachedRecalculateHealtheDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceRecalculateHealthDialogTitle);
                    }
                    return cachedRecalculateHealtheDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the State Event Change Tab Name translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 23Mar09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateEventChangeTabName
            {
                get
                {
                    if ((cachedStateEventChangeTabName == null))
                    {
                        cachedStateEventChangeTabName = CoreManager.MomConsole.GetIntlStr(ResourceStateChangeEventTabName);
                    }
                    return cachedStateEventChangeTabName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Knowledge Tab Name translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 23Mar09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string KnowledgeTabName
            {
                get
                {
                    if ((cachedKnowlegeTabName == null))
                    {
                        cachedKnowlegeTabName = CoreManager.MomConsole.GetIntlStr(ResourceKnowledgeTabName);
                    }
                    return cachedKnowlegeTabName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Confirm Action dialog title name translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 27Mar09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmActionDialogTitle
            {
                get
                {
                    if ((cachedConfirmActionDialogTitle == null))
                    {
                        cachedConfirmActionDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmActionDialogTitle);
                    }
                    return cachedConfirmActionDialogTitle;
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
        /// 	[mbickle] 20APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";
            
            /// <summary>
            /// Control ID for HealthMonitorsForStaticControl
            /// </summary>
            public const string HealthMonitorsForStaticControl = "monitorTreeLabel";
            
            /// <summary>
            /// Control ID for HealthMonitorsForTreeView
            /// </summary>
            public const string HealthMonitorsForTreeView = "monitorTreeView";
            
            /// <summary>
            /// Control ID for MainTabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string MainTabControl = "mainTabControl";
            
            /// <summary>
            /// Control ID for Grid
            /// </summary>
            public const string Grid = "gridControl";
            
            /// <summary>
            /// Control ID for StateChangeEventContextStaticControl
            /// </summary>
            public const string StateChangeEventContextStaticControl = "eventContextLabel";

            /// <summary>
            /// Control ID for NoButton
            /// </summary>
            public const string NoButton = "noButton";

            /// <summary>
            /// Control ID for YesButton
            /// </summary>
            public const string YesButton = "yesButton";

            /// <summary>
            /// Control ID for YesButton on Confirm Action dialog
            /// </summary>
            public const int YesButtonInteger = 6;

            /// <summary>
            /// Control ID for NoButton on Confirm Action dialog
            /// </summary>
            public const int NoButtonInteger = 7;

            /// <summary>
            /// Control ID for DataGrid on Overrides Summary dialog
            /// </summary>
            public const string DataGridOverrides = "listView";

        }
        #endregion
    }
}
