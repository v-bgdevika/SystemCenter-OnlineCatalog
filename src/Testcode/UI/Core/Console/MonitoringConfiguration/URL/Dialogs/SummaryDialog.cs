// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SummaryDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
// 	This class wraps Summary dialog
// </summary>
// <history>
// 	[v-bire] 3/18/2011 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;


    #region Interface Definition - ISummaryDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISummaryDialogControls, for SummaryDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/18/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISummaryDialogControls
    {
        /// <summary>
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SummaryDataGrid
        /// </summary>
        DataGrid SummaryDataGrid
        {
            get;
        }


        /// <summary>
        /// Read-only property to access SummaryDataGrid
        /// </summary>
        ListView SummaryListView
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This class wraps Summary dialog. This dialog contains the summary info
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/18/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SummaryDialog : Dialog, ISummaryDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables
        /// <summary>
        /// Cache to hold a reference to cachedCreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;

        /// <summary>
        /// Cache to hold a reference to SummaryDataGrid of type DataGrid
        /// </summary>
        private DataGrid cachedSummaryDataGrid;

        /// <summary>
        /// Cache to hold a reference to SummaryListView of type ListView
        /// </summary>
        private ListView cachedSummaryListView;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SummaryDialog of type SummaryDialog
        /// </param>
        /// <history>
        /// 	[v-bire] 3/18/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SummaryDialog(MomConsoleApp app) :
            base(app, Init(app))
        {
        }
        #endregion

        #region ISummaryDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-bire] 3/18/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISummaryDialogControls Controls
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
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/18/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryDialogControls.CreateButton
        {
            get
            {
                if (this.cachedCreateButton == null)
                {
                    this.cachedCreateButton = new Button(this, SummaryDialog.ControlIDs.CreateButton);
                }

                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryDataGrid control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/18/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid ISummaryDialogControls.SummaryDataGrid
        {
            get
            {
                if (this.cachedSummaryDataGrid == null)
                {
                    this.cachedSummaryDataGrid = new DataGrid(this, SummaryDialog.ControlIDs.ListView);
                }

                return this.cachedSummaryDataGrid;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryDataGrid control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/18/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISummaryDialogControls.SummaryListView
        {
            get
            {
                if (this.cachedSummaryListView == null)
                {
                    this.cachedSummaryListView = new ListView(this, SummaryDialog.ControlIDs.ListView);
                }

                return this.cachedSummaryListView;
            }
        }
        #endregion

        #region Control Extended Properties

        public Dictionary<string, string> SummarySettings
        {
            get
            {
                Dictionary<string, string> dictSettings = new Dictionary<string, string>();

                foreach (ListViewItem item in this.Controls.SummaryListView.Items)
                {
                    if (dictSettings.ContainsKey(item.Text))
                    {
                        Utilities.LogMessage("item: " + item.Text + " is already exists, add to the existing one");
                        dictSettings[item.Text] += "\r\n" + item.SubItems[0].Text;
                    }
                    else
                    {
                        dictSettings.Add(item.Text, item.SubItems[0].Text);
                    }

                    Utilities.LogMessage("item.Text: " + item.Text);
                    Utilities.LogMessage("item.SubItems[0].Text" + dictSettings[item.Text]);
                }

                //foreach (DataGridRow row in this.Controls.SummaryDataGrid.Rows)
                //{
                //    // Is it safe we assume the first column is for Name, and the second column is for Value ??
                //    Utilities.LogMessage("Add Key: "+row.Cells[0].Value +" Value: "+row.Cells[1].Value);
                //    dictSettings.Add(row.Cells[0].Value, row.Cells[1].Value);
                //}

                return dictSettings;
            }
        }

        #endregion

        #region Control Method

         

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">SummaryDialog owning the dialog.</param>
        /// <history>
        /// 	[v-bire] 3/18/2011 Created
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
        /// 	[v-bire] 3/18/2011 Created
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

            // Key value presented on the Summary listview
            // ToDo: nathd on 04/14/2011 10:46:24: We should retrieve the proper resource by id. After the improvement RIs into main you can fix these issues.
            public static string Name = "Name:";
            public static string ManagementPack = "Management Pack:";
            public static string TestSummary = "Test summary:";
            public static string TestSummaryRequest = "The following summarizes the configuration that is specified to monitor this template."; 

            #endregion
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/18/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";

            /// <summary>
            /// Control ID for ListView
            /// </summary>
            public const string ListView = "listView";
        }
        #endregion
    }
}
