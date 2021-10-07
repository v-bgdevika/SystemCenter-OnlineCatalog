// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SNMPSettingsProperties.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// [v-bire] 31 DEC 2010 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SNMPMonitor.Dialogs
{
    #region Using directive
    using System;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    #endregion

    #region Interface Definition - ISNMPMonitorPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISNMPMonitorPropertiesDialogControls, for SNMPMonitorPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-bire] 31 DEC 2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISNMPMonitorPropertiesDialogControls
    {
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access TabPagesTabControl
        /// </summary>
        TabControl TabPagesTabControl
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Expose all controls, one customzied control method, SelectTab(string)
    /// </summary>
    /// <history>
    /// 	[v-bire] 31 DEC 2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SNMPMonitorPropertiesDialog : Dialog, ISNMPMonitorPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to TabPagesTabControl of type TabControl
        /// </summary>
        private TabControl cachedTabPagesTabControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SNMPMonitorPropertiesDialog of type App
        /// </param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SNMPMonitorPropertiesDialog(MomConsoleApp app, string monitorName)
            :
                base(app, Init(app, monitorName))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region ISNMPMonitorPropertiesDialogControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISNMPMonitorPropertiesDialogControls Controls
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
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPMonitorPropertiesDialogControls.OKButton
        {
            get
            {
                if (this.cachedOKButton == null)
                {
                    this.cachedOKButton = new Button(this, SNMPMonitorPropertiesDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPMonitorPropertiesDialogControls.ApplyButton
        {
            get
            {
                if (this.cachedApplyButton == null)
                {
                    this.cachedApplyButton = new Button(this, SNMPMonitorPropertiesDialog.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPMonitorPropertiesDialogControls.CancelButton
        {
            get
            {
                if (this.cachedCancelButton == null)
                {
                    this.cachedCancelButton = new Button(this, SNMPMonitorPropertiesDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TabPagesTabControl control
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ISNMPMonitorPropertiesDialogControls.TabPagesTabControl
        {
            get
            {
                if (this.cachedTabPagesTabControl == null)
                {
                    this.cachedTabPagesTabControl = new TabControl(this, SNMPMonitorPropertiesDialog.ControlIDs.TabPagesTabControl);
                }
                return this.cachedTabPagesTabControl;
            }
        }
        #endregion

        #region Control Method

        /// <summary>
        /// Select tab by tab title
        /// </summary>
        /// <param name="tabTitle">tab title</param>
        public void SelectTab(string tabTitle)
        {
            int tabsCount = this.Controls.TabPagesTabControl.Count;
            TabControlTabCollection tabsCollection = this.Controls.TabPagesTabControl.Tabs;
            bool tabFound = false;

            for (int i = 0; i < tabsCount; i++)
            {
                if (string.Equals(tabTitle, tabsCollection[i].Text))
                {
                    tabFound = true;
                    tabsCollection[i].Select();
                    break;
                }
            }

            if (!tabFound)
            {
                throw new Exception("Tab not found with title: " + tabTitle);
            }
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">SNMPMonitorProperties owning the dialog.</param>)
        ///  <param name='monitorName'>monitor name</param>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, string monitorName)
        {
            string dialogTitle = string.Format(Strings.DialogTitle, monitorName);

            Window tempWindow = null;
            int numberOfTries = 0;
            const int MaxTries = 5;

            while (tempWindow == null && numberOfTries < MaxTries)
            {
                try
                {
                    // first try
                    if (numberOfTries == 0)
                    {
                        // Try to locate an existing instance of a dialog
                        tempWindow = new Window(dialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
                    }
                    else
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(new WindowParameters(dialogTitle + "*", StringMatchSyntax.WildCard) { Timeout = Constants.DefaultDialogTimeout });

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                }
                catch (Exceptions.WindowNotFoundException ex)
                {
                    // log the unsuccessful attempt
                    Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                    if (numberOfTries == MaxTries - 1)
                    {
                        Core.Common.Utilities.LogMessage("Failed to find with title: " + dialogTitle);
                        throw ex;
                    }
                }

                numberOfTries++;
            }

            return tempWindow;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Private Members

            /// <summary>
            /// Cache to hold a reference to dialog title of type String
            /// </summary>
            private static string cachedDialogTitle = null;
            #endregion

            #region Constants
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle =
                ";{0} Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;MPObjectFormatString";

            /// <summary>
            ///  No resource string found, hard coded ToDo:Find the proper ResouceId for the resouces below so they are no longer hard-coded.
            /// </summary>
            public const string FirstExpressionTab = "First Expression";

            /// <summary>
            ///  No resource string found, hard coded ToDo:Find the proper ResouceId for the resouces below so they are no longer hard-coded.
            /// </summary>
            public const string SecondExpressionTab = "Second Expression";

            /// <summary>
            ///  No resource string found, hard coded ToDo:Find the proper ResouceId for the resouces below so they are no longer hard-coded.
            /// </summary>
            public const string FirstSnmpProbeTab = "First SnmpProbe";

            /// <summary>
            ///  No resource string found, hard coded ToDo:Find the proper ResouceId for the resouces below so they are no longer hard-coded.
            /// </summary>
            public const string SecondSnmpProbe = "Second SnmpProbe";

            /// <summary>
            ///  No resource string found, hard coded ToDo:Find the proper ResouceId for the resouces below so they are no longer hard-coded.
            /// </summary>
            public const string FirstSnmpTrapProviderTab = "First SnmpTrapProvider";

            /// <summary>
            ///  No resource string found, hard coded ToDo:Find the proper ResouceId for the resouces below so they are no longer hard-coded.
            /// </summary>
            public const string SecondSnmpTrapProviderTab = "Second SnmpTrapProvider";
            #endregion

            #region Properties

            /// <summary>
            /// Read-only property to access DialogTitle
            /// </summary>
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
            #endregion
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-bire] 31 DEC 2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for TabPagesTabControl
            /// </summary>
            public const string TabPagesTabControl = "tabPages";
        }
        #endregion
    }
}