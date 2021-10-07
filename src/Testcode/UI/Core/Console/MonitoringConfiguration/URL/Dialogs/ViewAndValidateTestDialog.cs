// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ViewAndValidateTestDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
// 	This class wraps View and Validate Tests dialog
// </summary>
// <history>
// 	[v-bire] 3/11/2011 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using System;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IViewAndValidateTestDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IViewAndValidateTestDialogControls, for ViewAndValidateTestDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/11/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IViewAndValidateTestDialogControls
    {
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ClearButton
        /// </summary>
        Button ClearButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookForTextBox
        /// </summary>
        TextBox LookForTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RunTestButton
        /// </summary>
        Button RunTestButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ChangeConfigurationButton
        /// </summary>
        Button ChangeConfigurationButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LocationsDataGrid
        /// </summary>
        DataGrid TestListGridView
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This class wraps View and Validate Tests dialog. Click RunTest and Change Configuration button on this dialog 
    /// will bring two new windows up.
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/11/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ViewAndValidateTestDialog : Dialog, IViewAndValidateTestDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to cachedNextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to cachedClearButton of type Button
        /// </summary>
        private Button cachedClearButton;

        /// <summary>
        /// Cache to hold a reference to cachedLookForTextBox of type TextBox
        /// </summary>
        private TextBox cachedLookForTextBox;

        /// <summary>
        /// Cache to hold a reference to cachedRunTestButton of type Button
        /// </summary>
        private Button cachedRunTestButton;

        /// <summary>
        /// Cache to hold a reference to cachedChangeConfigurationButton of type Button
        /// </summary>
        private Button cachedChangeConfigurationButton;

        /// <summary>
        /// Cache to hold a reference to cachedLocationsDataGrid of type DataGrid
        /// </summary>
        private DataGrid cachedLocationsDataGrid;

        /// <summary>
        /// Cache to hold a reference to cachedColumnHeaderTestNameIndex
        /// </summary>
        private int cachedColumnHeaderTestNameIndex = -1;

        /// <summary>
        /// Cache to hold a reference to cachedColumnHeaderURLIndex
        /// </summary>
        private int cachedColumnHeaderURLIndex = -1;

        /// <summary>
        /// Cache to hold a reference to cachedColumnHeaderAgentPool
        /// </summary>
        private int cachedColumnHeaderAgentPoolIndex = -1;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ViewAndValidateTestDialog of type ViewAndValidateTestDialog
        /// </param>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ViewAndValidateTestDialog(MomConsoleApp app) :
            base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IViewAndValidateTestDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IViewAndValidateTestDialogControls Controls
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
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 4/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IViewAndValidateTestDialogControls.NextButton
        {
            get
            {
                if (this.cachedNextButton == null)
                {
                    this.cachedNextButton = new Button(this, ViewAndValidateTestDialog.ControlIDs.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IViewAndValidateTestDialogControls.ClearButton
        {
            get
            {
                if (this.cachedClearButton  == null)
                {
                    this.cachedClearButton = new Button(this, ViewAndValidateTestDialog.ControlIDs.ClearButton);
                }

                return this.cachedClearButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForTextBox control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IViewAndValidateTestDialogControls.LookForTextBox
        {
            get
            {
                if (this.cachedLookForTextBox == null)
                {
                    this.cachedLookForTextBox = new TextBox(this, ViewAndValidateTestDialog.ControlIDs.LookForTextBox);
                }

                return this.cachedLookForTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunTestButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IViewAndValidateTestDialogControls.RunTestButton
        {
            get
            {
                if (this.cachedRunTestButton == null)
                {
                    this.cachedRunTestButton = new Button(this, ViewAndValidateTestDialog.ControlIDs.RunTestButton);
                }

                return this.cachedRunTestButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChangeConfigurationButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IViewAndValidateTestDialogControls.ChangeConfigurationButton
        {
            get
            {
                if (this.cachedChangeConfigurationButton == null)
                {
                    this.cachedChangeConfigurationButton = new Button(this, ViewAndValidateTestDialog.ControlIDs.ChangeConfigurationButton);
                }

                return this.cachedChangeConfigurationButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExternalLocationsDataGrid control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IViewAndValidateTestDialogControls.TestListGridView
        {
            get
            {
                if (this.cachedLocationsDataGrid == null)
                {
                    CoreManager.MomConsole.Waiters.WaitForWindowAppeared(this, new QID(string.Format(";[UIA]AutomationId='{0}'", ViewAndValidateTestDialog.ControlIDs.TestListGridView)), Constants.OneSecond * 10);
                    this.cachedLocationsDataGrid = new DataGrid(this, ViewAndValidateTestDialog.ControlIDs.TestListGridView);
                }

                return this.cachedLocationsDataGrid;
            }
        }
        #endregion

        #region Control Extended Properties
        /// <summary>
        /// Get Column Index of header Test Name
        /// </summary>
        public int ColumnHeaderTestNameIndex
        {
            get
            {
                if (this.cachedColumnHeaderTestNameIndex == -1)
                {
                    this.cachedColumnHeaderTestNameIndex = FindColumnHeaderIndex(Strings.ColumnHeaderTestName);
                }
                return this.cachedColumnHeaderTestNameIndex;
            }
        }

        /// <summary>
        /// Get Column Index of header URL
        /// </summary>
        public int ColumnHeaderURLIndex
        {
            get
            {
                if (this.cachedColumnHeaderURLIndex == -1)
                {
                    this.cachedColumnHeaderURLIndex = FindColumnHeaderIndex(Strings.ColumnHeaderURL);
                }
                return this.cachedColumnHeaderURLIndex;
            }
        }

        /// <summary>
        /// Get Column Index of header Agent/Pool
        /// </summary>
        public int ColumnHeaderAgentPoolIndex
        {
            get
            {
                if (this.cachedColumnHeaderAgentPoolIndex  == -1)
                {
                    this.cachedColumnHeaderAgentPoolIndex = FindColumnHeaderIndex(Strings.ColumnHeaderAgentPool);
                }
                return this.cachedColumnHeaderAgentPoolIndex;
            }
        }

        #endregion

        #region Control Method
        /// <summary>
        /// Find Column Header Index by specified header name
        /// </summary>
        /// <param name="columnHeaderName">Name of the column header</param>
        /// <returns>column index</returns>
        private int FindColumnHeaderIndex(string columnHeaderName)
        {
            if (string.IsNullOrEmpty(columnHeaderName))
            {
                throw new ArgumentNullException(columnHeaderName);
            }

            for (int i=0;i<this.Controls.TestListGridView.ColumnHeaders.Count;i++)
            {
                if (string.Equals(this.Controls.TestListGridView.ColumnHeaders[i].Name, columnHeaderName))
                {
                    return i;
                }
            }

            throw new Exception("Cannot find column header with name: "+columnHeaderName);
        }

        /// <summary>
        /// Get cell value of specified colun index and row index
        /// </summary>
        /// <param name="collndex">column index</param>
        /// <param name="rowIndex">row index</param>
        /// <returns>cell value of type string</returns>
        public string GetCellValue(int colIndex, int rowIndex)
        {
            if (colIndex < 0 || rowIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index should be nonnegative");
            }

            return this.Controls.TestListGridView.Rows[rowIndex].Cells[colIndex].Value;
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ViewAndValidateTestDialog owning the dialog.</param>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
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

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// 	[v-harl] 9/7/2011 Add TestName/URL/AgentPool ResourceString
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TestNameColumnHeader
            /// </summary>
            /// <history>
            /// [v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private const string ResourceTestNameColumnHeader = ";Test name;ManagedString;Microsoft.EnterpriseManagement.UI.SyntheticTransaction.Authoring.resources.dll;Microsoft.EnterpriseManagement.UI.SyntheticTransaction.Authoring.Pages.SingleUrl.SingleUrlResources.en;TestNameColumnHeader";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for URLColumnHeader
            /// </summary>
            /// <history>
            /// [v-harl] 9/7/2011 Created
            /// [v-frma] 9/28/2011 Modified
            /// </history>
            /// -----------------------------------------------------------------------------
            private const string ResourceURLColumnHeader = ";URL;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseApplicationUserControl;columnURL.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AgentPoolColumnHeader
            /// </summary>
            /// <history>
            /// [v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentPoolColumnHeader = ";Agent/Pool;ManagedString;Microsoft.EnterpriseManagement.UI.SyntheticTransaction.Authoring.resources.dll;Microsoft.EnterpriseManagement.UI.SyntheticTransaction.Authoring.Pages.SingleUrl.SingleUrlResources.en;AgentAndPoolColumnHeader";

            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// <history>
            /// [v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Column Header Test Name
            /// </summary>
            /// <history>
            /// [v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cacheTestNameColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Column Header URL
            /// </summary>
            /// <history>
            /// [v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cacheURLColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Column Header Agent/Pool
            /// </summary>
            /// <history>
            /// [v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            private static string cacheAgentPoolColumnHeader;
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if (cachedDialogTitle == null)
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ColumnHeaderTestName translated resource string
            /// </summary>
            /// <history>
            /// 	[v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ColumnHeaderTestName
            {
                get
                {
                    if (cacheTestNameColumnHeader == null)
                    {
                        cacheTestNameColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTestNameColumnHeader);
                    }
                    return cacheTestNameColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ColumnHeaderURL translated resource string
            /// </summary>
            /// <history>
            /// 	[v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ColumnHeaderURL
            {
                get
                {
                    if (cacheURLColumnHeader == null)
                    {
                        cacheURLColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceURLColumnHeader);
                    }
                    return cacheURLColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ColumnHeaderAgentPool translated resource string
            /// </summary>
            /// <history>
            /// 	[v-harl] 9/7/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ColumnHeaderAgentPool
            {
                get
                {
                    if (cacheAgentPoolColumnHeader == null)
                    {
                        cacheAgentPoolColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceAgentPoolColumnHeader);
                    }
                    return cacheAgentPoolColumnHeader;
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
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";

            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string ClearButton = "clearButton";

            /// <summary>
            /// Control ID for LookForTextBox
            /// </summary>
            public const string LookForTextBox = "lookForTextbox";

            /// <summary>
            /// Control ID for RunTestButton
            /// </summary>
            public const string RunTestButton = "runTestButton";

            /// <summary>
            /// Control ID for TestListGridView
            /// </summary>
            public const string TestListGridView = "testListGridView";

            /// <summary>
            /// Control ID for ConfigurationButton
            /// </summary>
            public const string ChangeConfigurationButton = "configurationButton";
        }
        #endregion
    }
}
