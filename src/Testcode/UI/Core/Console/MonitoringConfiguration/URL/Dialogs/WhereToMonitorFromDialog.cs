// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WhereToMonitorFromDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
//  This dialog wraps Where to Monitor From dialog
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


    #region Interface Definition - IWhereToMonitorFromDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWhereToMonitorFromDialogControls, for WhereToMonitorFromDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/11/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWhereToMonitorFromDialogControls
    {
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access InternalLocationsAddButton
        /// </summary>
        Button InternalLocationsAddButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access InternalLocationsRemoveButton
        /// </summary>
        Button InternalLocationsRemoveButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access InternalLocationsDataGrid
        /// </summary>
        DataGrid InternalLocationsDataGrid
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This class wraps Where to Monitor From dialog, this dialog contains couple of  Add, Remove buttons, and a DataGrid, they grouped by different pane
    /// One called External locations, the other called Internal Locations.
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/11/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WhereToMonitorFromDialog : Dialog, IWhereToMonitorFromDialogControls
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
        /// Cache to hold a reference to cachedInternalLocationsRemoveButton of type Button
        /// </summary>
        private Button cachedInternalLocationsRemoveButton;

        /// <summary>
        /// Cache to hold a reference to cachedInternalLocationsAddButton of type Button
        /// </summary>
        private Button cachedInternalLocationsAddButton;

        /// <summary>
        /// Cache to hold a reference to cachedInternalLocationsDataGrid of type DataGrid
        /// </summary>
        private DataGrid cachedInternalLocationsDataGrid;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WhereToMonitorFromDialog of type WhereToMonitorFromDialog
        /// </param>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WhereToMonitorFromDialog(MomConsoleApp app) :
            base(app, Init(app))
        {
        }
        #endregion

        #region IWhereToMonitorFromDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWhereToMonitorFromDialogControls Controls
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
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWhereToMonitorFromDialogControls.NextButton
        {
            get
            {
                if (this.cachedNextButton == null)
                {
                    this.cachedNextButton = new Button(this, WhereToMonitorFromDialog.ControlIDs.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InternalLocationsRemoveButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWhereToMonitorFromDialogControls.InternalLocationsRemoveButton
        {
            get
            {
                if (this.cachedInternalLocationsRemoveButton == null)
                {
                    this.cachedInternalLocationsRemoveButton = new Button(this, WhereToMonitorFromDialog.ControlIDs.RemoveButton);
                }

                return this.cachedInternalLocationsRemoveButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InternalLocationsAddButton control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWhereToMonitorFromDialogControls.InternalLocationsAddButton
        {
            get
            {
                if (this.cachedInternalLocationsAddButton == null)
                {
                    this.cachedInternalLocationsAddButton = new Button(this, WhereToMonitorFromDialog.ControlIDs.AddButton);
                }

                return this.cachedInternalLocationsAddButton;
            }
        }

       
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InternalLocationsDataGrid control
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IWhereToMonitorFromDialogControls.InternalLocationsDataGrid
        {
            get
            {
                if (this.cachedInternalLocationsDataGrid == null)
                {
                    this.cachedInternalLocationsDataGrid = new DataGrid(this, WhereToMonitorFromDialog.ControlIDs.LocationsDataGrid);
                }

                return this.cachedInternalLocationsDataGrid;
            }
        }
        #endregion

        #region Control Extended Properties
        #endregion

        #region Control Method

        /// <summary>
        /// Get external locations pane
        /// </summary>
        /// <returns>window which represents the pane</returns>
        private Window GetExternalLocationsPane()
        {
            string queryId = string.Format(";[FindAll, UIA, VisibleOnly] Role = 'pane' && Name = '{0}'", ControlIDs.ExternalLocationsPaneName);

            MauiCollection<IScreenElement> mauis = this.ScreenElement.FindAllDescendants(-1, queryId, null);

            if (mauis == null || mauis.Count == 0)
            {
                throw new RegularExpression.Exceptions.MatchNotFoundException("Cannot find pane with qid: " + queryId);
            }

            foreach (IScreenElement element in mauis)
            {
                if (string.Equals(element.Parent.Name, ControlIDs.ExternalLocationsPaneName))
                {
                    return new Window(element);
                }
            }

            throw new RegularExpression.Exceptions.MatchNotFoundException("Cannot find pane whose parent name is: " + ControlIDs.ExternalLocationsPaneName);
        }

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">WhereToMonitorFromDialog owning the dialog.</param>
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
                        // log the unsuccessful attempt

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
            public const string AddButton = "addButton";

            /// <summary>
            /// Control ID for URLDataGrid
            /// </summary>
            public const string LocationsDataGrid = "gridView";

            /// <summary>
            /// Control Name for External Locations Pane
            /// </summary>
            internal const string ExternalLocationsPaneName = "Internal locations are always displayed. You can also monitor from external locations by signing up for the Outside In service.";
        }
        #endregion
    }
}
