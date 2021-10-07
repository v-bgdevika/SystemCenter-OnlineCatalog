// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TuneAlertsViewSourcesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2016
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  Tune Alert View Sources  
// </summary>
// <history>
// 	[satim] 27/02/2016 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Mom.Test.UI.Core;
    using Mom.Test.UI.Core.Common;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Console;
    using System.ComponentModel;

    #region Interface Definition - ITuneAlertsViewSourcesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITuneAlertsViewSourcesDialogControls, for TuneAlertsViewSourcesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// [satim] 27/02/2016 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITuneAlertsViewSourcesDialogControls
    {
        /// <summary>
        /// Read-only property to access OverrideButton
        /// </summary>
        Button OverrideButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DisableButton
        /// </summary>
        Button DisableButton
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

        /// <summary>
        /// Read-only property to access dataGridView
        /// </summary>
        DataGridView DataGridView1
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    ///     TuneAlertsViewSourcesDialog class
    /// </summary>
    /// <history>
    ///     [satim] 27/02/2016 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    class TuneAlertsViewSourcesDialog : Dialog, ITuneAlertsViewSourcesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OverrideButton of type Button
        /// </summary>
        private Button cachedOverrideButton;

        /// <summary>
        /// Cache to hold a reference to DisableButton of type Button
        /// </summary>
        private Button cachedDisableButton;

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;

        /// <summary>
        /// Cache to hold a reference to dataGridView1 of type DataGridView
        /// </summary>
        private DataGridView cachedDataGridView1;

        #endregion

        #region Constructors

        /// ------------------------------------------------------------------
        /// <summary>
        /// Tune Alerts View Sources Console
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// ------------------------------------------------------------------
        public TuneAlertsViewSourcesDialog(Maui.Core.App app) :
            base(app, Init(app))
        {
            
        }
        #endregion

        #region ITuneAlertsViewSourcesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITuneAlertsViewSourcesDialogControls Controls
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
        ///  Exposes access to the Override Button control
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITuneAlertsViewSourcesDialogControls.OverrideButton
        {
            get
            {
                if ((this.cachedOverrideButton == null))
                {
                    this.cachedOverrideButton = new Button(this, TuneAlertsViewSourcesDialog.ControlIDs.OverrideButton);
                }
                return this.cachedOverrideButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Disable Button control
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITuneAlertsViewSourcesDialogControls.DisableButton
        {
            get
            {
                if ((this.cachedDisableButton == null))
                {
                    this.cachedDisableButton = new Button(this, TuneAlertsViewSourcesDialog.ControlIDs.DisableButton);
                }
                return this.cachedDisableButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Close Button control
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITuneAlertsViewSourcesDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, TuneAlertsViewSourcesDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGridView ITuneAlertsViewSourcesDialogControls.DataGridView1
        {
            get
            {
                if ((this.cachedDataGridView1 == null))
                {
                    this.cachedDataGridView1 = new DataGridView(this, TuneAlertsViewSourcesDialog.ControlIDs.DataGridView1);
                }
                return this.cachedDataGridView1;
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on Override button
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOverrideButton()
        {
            this.Controls.OverrideButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on Disable button
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDisableButton()
        {
            this.Controls.DisableButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on Close button
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCloseButton()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion

        #region public methods
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  This clicks on the first source and clicks on the override or Disable button based on param passed.
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool overrideSources(TuneAlertsParameters TunealertsParam)
        {
            bool status = false;
            if(this.Controls.DataGridView1 == null)
            {
                Utilities.LogMessage("overrideSources:: Could not control of Grid view.");
                return status;            
            }
            int sourcesCount = this.Controls.DataGridView1.Rows.Count;
            if (sourcesCount == 0)
            {
                Utilities.LogMessage("overrideSources:: Could not find any sources.");
                return status;
            }

            //TODO: get sources name from the parameters.
            this.Controls.DataGridView1.Rows[1].AccessibleObject.Click();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(ConsoleConstants.DefaultDialogTimeout);
            if (TunealertsParam.OverrideOrDisable.Equals(Strings.Disable))
            {
                //TunealertsParam.OverrideParameter = "Enabled";
                //TunealertsParam.OverrideParameterValue = "False";
                ClickDisableButton();
            }
            else
            {
                ClickOverrideButton();
            }
            return true;
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                         "Attempt " + numberOfTries + " of " + MaxTries);
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }

            return tempWindow;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings
        /// </summary>
        /// <history>
        ///   [satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Tune Alert sources Dialog Title
            /// </summary>            
            private const string ResourceDialogTitle = ";TuneAlertsViewSources;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneAlertsViewSources;$this.Text";

            /// <summary>
            /// Resource string for override
            /// </summary>
            private const string ResourceOverrideButton = ";overrideBtn;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneAlertsViewSources;$this.Text";

            /// <summary>
            /// Resource string for disable
            /// </summary>
            private const string ResourceDisableButton = ";disableBtn;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneAlertsViewSources;$this.Text";

            /// <summary>
            /// Resource string for close
            /// </summary>
            private const string ResourceCloseButton = ";closeBtn;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneAlertsViewSources;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGridView1 = ";Grid;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneAlertsView;Grid";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// string for Disable
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string Disable = "Disable";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// string for Override
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string Override = "Override";
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
            /// Caches the translated resource minimum Alert Count Text box
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedtakeMinimumAlertCountTextBox;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource button Override
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverrideButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource button Disable
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisableButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource button Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCloseButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataGridView1;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
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
            /// Exposes access to the Override translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OverrideButton
            {
                get
                {
                    if ((cachedOverrideButton == null))
                    {
                        cachedOverrideButton = CoreManager.MomConsole.GetIntlStr(ResourceOverrideButton);
                    }
                    return cachedOverrideButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Disable translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisableButton
            {
                get
                {
                    if ((cachedDisableButton == null))
                    {
                        cachedDisableButton = CoreManager.MomConsole.GetIntlStr(ResourceDisableButton);
                    }
                    return cachedDisableButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CloseButton
            {
                get
                {
                    if ((cachedCloseButton == null))
                    {
                        cachedCloseButton = CoreManager.MomConsole.GetIntlStr(ResourceCloseButton);
                    }
                    return cachedCloseButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataGridView1
            {
                get
                {
                    if ((cachedDataGridView1 == null))
                    {
                        cachedDataGridView1 = CoreManager.MomConsole.GetIntlStr(ResourceDataGridView1);
                    }
                    return cachedDataGridView1;
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
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            
            /// <summary>
            /// Control ID for Override Button
            /// </summary>
            public const string OverrideButton = "overrideBtn";
            
            /// <summary>
            /// Control ID for Disable Button
            /// </summary>
            public const string DisableButton = "disableBtn";

            /// <summary>
            /// Control ID for Close Button
            /// </summary>
            public const string CloseButton = "closeBtn";

            /// <summary>
            /// Control ID for data grid view
            /// </summary>
            public const string DataGridView1 = "dataGridView";


        }
        #endregion
    }
}
