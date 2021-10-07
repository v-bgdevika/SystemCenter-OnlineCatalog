// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WhatToMonitorDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
// 	This class wraps What to Monitor dialog
// </summary>
// <history>
// 	[v-bire] 3/11/2011 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Dialogs;

    #region Interface Definition - IWhatToMonitorDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWhatToMonitorDialogControls, for WhatToMonitorDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/11/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWhatToMonitorDialogControls
    {
         /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access URLDataGrid
        /// </summary>
        DataGrid URLDataGrid
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This dialog wraps the What to monitor dialog, this dialog contains a Add, Remove button, and a DataGrid of the URL
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/11/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WhatToMonitorDialog : Dialog, IWhatToMonitorDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;

        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;

        /// <summary>
        /// Cache to hold a reference to URLDataGrid of type DataGrid
        /// </summary>
        private DataGrid cachedURLDataGrid;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WhatToMonitorDialog of type WhatToMonitorDialog
        /// </param>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WhatToMonitorDialog(MomConsoleApp app) :
            base(app, Init(app))
        {
        }
        #endregion

        #region IWhatToMonitorDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWhatToMonitorDialogControls Controls
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
        Button IWhatToMonitorDialogControls.NextButton
        {
            get
            {
                if (this.cachedNextButton == null)
                {
                    this.cachedNextButton = new Button(this, WhatToMonitorDialog.ControlIDs.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWhatToMonitorDialogControls.RemoveButton
        {
            get
            {
                if (this.cachedRemoveButton == null)
                {
                    this.cachedRemoveButton = new Button(this, WhatToMonitorDialog.ControlIDs.RemoveButton);
                }

                return this.cachedRemoveButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWhatToMonitorDialogControls.AddButton
        {
            get
            {
                if (this.cachedAddButton == null)
                {
                    this.cachedAddButton = new Button(this, WhatToMonitorDialog.ControlIDs.AddButton);
                }

                return this.cachedAddButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the URLDataGrid control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IWhatToMonitorDialogControls.URLDataGrid
        {
            get
            {
                if (this.cachedURLDataGrid == null)
                {
                    this.cachedURLDataGrid = new DataGrid(this, WhatToMonitorDialog.ControlIDs.URLDataGrid);
                }

                return this.cachedURLDataGrid;
            }
        }
        #endregion

        #region Control Extended Properties

        /// <summary>
        /// Get column index of Name
        /// </summary>
        public int URLDataGridColumnIndexName
        {
            get
            {
                // Why we start from 1 add sub 1 at last?
                // because the first column is a row label, it is not used in our case
                for (int i = 1; i < this.Controls.URLDataGrid.ColumnHeaders.Count; i++)
                {
                    if (string.Equals(this.Controls.URLDataGrid.ColumnHeaders[i].Name, Strings.URLDataGridColumnTitleName))
                    {
                        return i-1;
                    }
                }

                throw new Exception("Cannot find column index of name: " + Strings.URLDataGridColumnTitleName);
            }
        }

        /// <summary>
        /// Get column index of URL
        /// </summary>
        public int URLDataGridColumnIndexURL
        {
            get
            {
                // Why we start from 1 add sub 1 at last?
                // because the first column is a row label, it is not used in our case
                for (int i = 1; i < this.Controls.URLDataGrid.ColumnHeaders.Count; i++)
                {
                    if (string.Equals(this.Controls.URLDataGrid.ColumnHeaders[i].Name, Strings.URLDataGridColumnTitleURL))
                    {
                        return i-1;
                    }
                }

                throw new Exception("Cannot find column index of name: " + Strings.URLDataGridColumnTitleURL);
            }
        }
        #endregion

        #region Control Method

        /// <summary>
        /// Type name and url directly in the row with index rowIndex
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="url">url</param>
        /// <param name="rowIndex">row index</param>
        public void AddURL(string name, string url, int rowIndex)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();
            string methodName = mb.ReflectedType.ToString() + "." + mb.Name;
            Utilities.LogMessage("Enter "+ methodName);

            int colIndexName = URLDataGridColumnIndexName;
            Utilities.LogMessage("Column index of name is: "+colIndexName);
            int colIndexURL = URLDataGridColumnIndexURL;
            Utilities.LogMessage("Column index of url is: "+colIndexURL);

            // get name cell
            DataGridCell nameCell = this.Controls.URLDataGrid.Rows[rowIndex].Cells[colIndexName];
            Utilities.LogMessage("Click cell Name");
            nameCell.AccessibleObject.Click();
            Utilities.LogMessage("Set cell Name value as: "+name);
            Keyboard.SendKeys(name);

            // get url cell
            DataGridCell urlCell = this.Controls.URLDataGrid.Rows[rowIndex].Cells[colIndexURL];
            Utilities.LogMessage("Click cell URL");
            urlCell.AccessibleObject.Click();
            Utilities.LogMessage("Set cell URL value as: "+url);
            Keyboard.SendKeys(url);

            Utilities.LogMessage("Exit " + methodName);
        }

        /// <summary>
        /// Add multi url by importing them from .csv files
        /// </summary>
        /// <param name="fileName">.csv file name, full path</param>
        public void AddURL(string fileName)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();
            string methodName = mb.ReflectedType.ToString() + "." + mb.Name;
            Utilities.LogMessage("Enter " + methodName);

            Utilities.LogMessage("Click Add button to bring up the Open File dialog");
            this.Controls.AddButton.Click();
            OpenDialog openDialog = new OpenDialog(CoreManager.MomConsole);
            Utilities.LogMessage("Set file name: "+fileName);
            openDialog.FileNameText = fileName;
            Utilities.LogMessage("Click Open button");
            openDialog.ClickOpen();
            Utilities.LogMessage("Wait 5 seconds for dialog close");
            CoreManager.MomConsole.WaitForDialogClose(openDialog, 5);

            Utilities.LogMessage("Exit " + methodName);
        }

        /// <summary>
        /// Remove url by specified url
        /// </summary>
        /// <param name="url">url</param>
        public void RemoveURLByURL(string url)
        {
            RemoveURL(url, URLDataGridColumnIndexURL);
        }

        /// <summary>
        /// Remove url by specified name
        /// </summary>
        /// <param name="name">name</param>
        public void RemoveURLByName(string name)
        {
            RemoveURL(name, URLDataGridColumnIndexName);
        }

        /// <summary>
        /// Remove url by the text in the specified column index
        /// </summary>
        /// <param name="match">search string</param>
        /// <param name="colIndex">column index, in which column to search the string</param>
        public void RemoveURL(string match, int colIndex)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();
            string methodName = mb.ReflectedType.ToString() + "." + mb.Name;
            Utilities.LogMessage("Enter " + methodName);

            if (string.IsNullOrEmpty(match))
            {
                throw new ArgumentNullException("match");
            }

            int rowsCount = this.Controls.URLDataGrid.Rows.Count;
            Utilities.LogMessage("Rows count in URLDataGrid is: " + rowsCount);

            if (rowsCount == 0)
            {
                throw new Exception("Rows count in URLDataGrid is zero.");
            }

            Utilities.LogMessage("Column index: " + colIndex);

            foreach (DataGridRow row in this.Controls.URLDataGrid.Rows)
            {
                if (string.Equals(row.Cells[colIndex].Name, match))
                {
                    Utilities.LogMessage("Select the row whose cell text is: " + match);
                    row.Select();
                    Utilities.LogMessage("Wait " + Timeout + " ms for remove button enabled");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.Controls.RemoveButton, Timeout);
                    Utilities.LogMessage("Click Remove button");
                    this.Controls.RemoveButton.Click();
                    Utilities.LogMessage("Now the rows count is: " + this.Controls.URLDataGrid.Rows.Count);
                    break;
                }
            }

            Utilities.LogMessage("Exit " + methodName);
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">WhatToMonitorDialog owning the dialog.</param>
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";

            /// <summary>
            /// ToDo: Find the resource string
            /// </summary>
            public const string URLDataGridColumnTitleName = "Name";

            /// <summary>
            /// ToDo: Find the resource string
            /// </summary>
            public const string URLDataGridColumnTitleURL = "URL";
            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

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
            public const string RemoveButton = "deleteButton";

            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "importButton";

            /// <summary>
            /// Control ID for URLDataGrid
            /// </summary>
            public const string URLDataGrid = "gridView";
        }
        #endregion
    }
}
