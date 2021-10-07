// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ShowHideViewsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Show or Hide Views Dialog
// </summary>
// <history>
// 	[mbickle] 25FEB06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    #endregion

    #region Interface Definition - IShowHideViewsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IShowHideViewsDialogControls, for ShowHideViewsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 25FEB06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IShowHideViewsDialogControls
    {
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewsListBox
        /// </summary>
        ListBox ViewsListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewsStaticControl
        /// </summary>
        StaticControl ViewsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl
        /// </summary>
        StaticControl SelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Show or Hide Views.
    /// </summary>
    /// <history>
    /// 	[mbickle] 25FEB06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ShowHideViewsDialog : Dialog, IShowHideViewsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to ViewsListBox of type ListBox
        /// </summary>
        private ListBox cachedViewsListBox;
        
        /// <summary>
        /// Cache to hold a reference to ViewsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ShowHideViewsDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ShowHideViewsDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IShowHideViewsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IShowHideViewsDialogControls Controls
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
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IShowHideViewsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ShowHideViewsDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IShowHideViewsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ShowHideViewsDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewsListBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IShowHideViewsDialogControls.ViewsListBox
        {
            get
            {
                if ((this.cachedViewsListBox == null))
                {
                    this.cachedViewsListBox = new ListBox(this, ShowHideViewsDialog.ControlIDs.ViewsListBox);
                }
                return this.cachedViewsListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IShowHideViewsDialogControls.ViewsStaticControl
        {
            get
            {
                if ((this.cachedViewsStaticControl == null))
                {
                    this.cachedViewsStaticControl = new StaticControl(this, ShowHideViewsDialog.ControlIDs.ViewsStaticControl);
                }
                return this.cachedViewsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IShowHideViewsDialogControls.SelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl
        {
            get
            {
                if ((this.cachedSelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl == null))
                {
                    this.cachedSelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl = new StaticControl(this, ShowHideViewsDialog.ControlIDs.SelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl);
                }
                return this.cachedSelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app.MainWindow,
                    Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException)
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
                                app.GetIntlStr(Strings.DialogTitle) + "*",
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
                            "ShowHideViewsDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "ShowHideViewsDialog:: Failed to find window with title:  '" +
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
        /// String Resources
        /// </summary>
        /// <history>
        /// 	[mbickle] 25FEB06 Created
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
            private const string ResourceDialogTitle = ";Show or hide views;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ShowHideDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bU;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViews = ";&Views:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Console.ShowHideDialog;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedTheViewsToShowInTheMonitoringNavigationTree
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedTheViewsToShowInTheMonitoringNavigationTree = ";Selected the views to show in the Monitoring navigation tree.;ManagedString;Micr" +
                "osoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Conso" +
                "le.ShowHideDialog;label1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Show or hide views... 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowHideViewsLink = ";Show or hide views...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Monitoring.MonitoringPageResources;ShowHideFolderText";
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
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViews;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedTheViewsToShowInTheMonitoringNavigationTree
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedTheViewsToShowInTheMonitoringNavigationTree;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowHideViewsLink
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowHideViewsLink;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 25FEB06 Created
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
            /// 	[mbickle] 25FEB06 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 25FEB06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 25FEB06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Views
            {
                get
                {
                    if ((cachedViews == null))
                    {
                        cachedViews = CoreManager.MomConsole.GetIntlStr(ResourceViews);
                    }
                    return cachedViews;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedTheViewsToShowInTheMonitoringNavigationTree translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 25FEB06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedTheViewsToShowInTheMonitoringNavigationTree
            {
                get
                {
                    if ((cachedSelectedTheViewsToShowInTheMonitoringNavigationTree == null))
                    {
                        cachedSelectedTheViewsToShowInTheMonitoringNavigationTree = CoreManager.MomConsole.GetIntlStr(ResourceSelectedTheViewsToShowInTheMonitoringNavigationTree);
                    }
                    return cachedSelectedTheViewsToShowInTheMonitoringNavigationTree;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowHideViewsLink translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 25FEB06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowHideViews
            {
                get
                {
                    if ((cachedShowHideViewsLink == null))
                    {
                        cachedShowHideViewsLink = CoreManager.MomConsole.GetIntlStr(ResourceShowHideViewsLink);
                    }
                    return cachedShowHideViewsLink;
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
        /// 	[mbickle] 25FEB06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for ViewsListBox
            /// </summary>
            public const string ViewsListBox = "folderList";
            
            /// <summary>
            /// Control ID for ViewsStaticControl
            /// </summary>
            public const string ViewsStaticControl = "label2";
            
            /// <summary>
            /// Control ID for SelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl
            /// </summary>
            public const string SelectedTheViewsToShowInTheMonitoringNavigationTreeStaticControl = "label1";
        }
        #endregion
    }
}
