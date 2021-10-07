// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TuneAlertsView.cs">
// 	Copyright (c) Microsoft Corporation 2016
// </copyright>
// <summary>
//  Tune Alerts View 
// </summary>
// <history>
// 	[satim] 18/02/2016 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Mom.Test.UI.Core;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Dialogs;
    using Mom.Test.UI.Core.Console.MP.Dialogs;
    using Mom.Test.UI.Core.Console.Overrides;
    using Mom.Test.UI.Core.Console.Overrides.Dialogs;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Infra.Frmwrk;
    using System;
    using Core.Console.MomControls;

    #region Interface Definition - ITuneAlertsViewControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITuneAlertsViewControls, for TuneAlertsView.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITuneAlertsViewControls
    {
        GridControl Grid1
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    ///     Dialog for Tune alerts view sources window
    /// </summary>
    /// <history>
    /// </history>
    /// -----------------------------------------------------------------------------
    class TuneAlertsView : Dialog, ITuneAlertsViewControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        /// <summary>
        /// Parameter used by Verify override disable
        /// </summary>
        private const string OverrideParameter = "Enabled";

        /// <summary>
        /// Parameter Value used by Verify override disable
        /// </summary>
        private const string OverrideParameterValue = "False";

        /// <summary>
        /// Parameter Value used by Sleeper
        /// </summary>
        private const int Seconds = 20000;

        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to dataGridView1 of type Grid1
        /// </summary>
        private GridControl cachedGrid1;

        /// <summary>
        /// Cache to hold a reference to dataGridView1 of type overrideProperties
        /// </summary>
        private Core.Console.Overrides.Dialogs.OverrideProperties cachedoverrideProperties;

        /// <summary>
        /// Overrides class 
        /// </summary>
        private Core.Console.Overrides.Overrides overrideHelper = new Core.Console.Overrides.Overrides();

        #endregion

        #region Constructors

        /// ------------------------------------------------------------------
        /// <summary>
        /// Tune Alerts View Constructor
        /// </summary>
        /// <param name="app">App</param>
        /// ------------------------------------------------------------------
        public TuneAlertsView(Maui.Core.App app) :
            base(app, Init(app))
        {

        }

        #endregion

        #region ITuneAlertsView Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITuneAlertsViewControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        #region Text Field Properties
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Grid1
        /// </summary>
        /// -----------------------------------------------------------------------------
        public virtual GridControl Grid1Value
        {
            get
            {
                return this.Controls.Grid1;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control overrideProperties
        /// </summary>
        /// -----------------------------------------------------------------------------
        public OverrideProperties overrideProperties
        {
            get
            {
                if (this.cachedoverrideProperties == null)
                {
                    this.cachedoverrideProperties = new OverrideProperties(CoreManager.MomConsole);
                }
                return this.cachedoverrideProperties;
            }
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Grid1 control
        /// </summary>
        /// -----------------------------------------------------------------------------
        GridControl ITuneAlertsViewControls.Grid1
        {
            get
            {
                if ((this.cachedGrid1 == null))
                {
                    this.cachedGrid1 = new GridControl(this, TuneAlertsView.ControlIDs.Grid1);
                }
                return this.cachedGrid1;
            }
        }
        #region public methods

        /// <summary>
        /// This method selects a alerts view and clicks on the view sources details.
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="tempWindow">Window</param>
        /// <param name="TunealertsParams">TunealertsParameters</param>
        public bool clickOverrideSources(Maui.Core.Window tempWindow, TuneAlertsParameters TunealertsParam)
        {
            bool status = false;
            int MaxTries = 6;
            Utilities.LogMessage("clickOverrideSources:: start");
           
            ViewPane tempViewPane = new ViewPane(tempWindow);
            if (tempViewPane == null)
            {
                Utilities.LogMessage("clickOverrideSources:: Could not get control of View pane.");
                return status;
            }

            int alertCount = tempViewPane.Grid.Rows.Count;
            if (alertCount == 0)
            {
                while (MaxTries > 0)
                {
                    MaxTries--;
                    Sleeper.Delay(20000);
                    alertCount = tempViewPane.Grid.Rows.Count;
                    if (alertCount != 0) break;
                }
                if (alertCount == 0)
                {
                    Utilities.LogMessage("clickOverrideSources:: Could not find any Alerts.");
                    return status;
                }
            }

            //choose the first alert by default.
            //TODO: need to use params to input alert name and select it.
            tempViewPane.Grid.Rows[1].AccessibleObject.Click();
            Utilities.TakeScreenshot("Tune alerts window AlertsSelected");
            ActionsPane alertActionsPane = new ActionsPane(tempWindow);
            if (alertActionsPane == null)
            {
                Utilities.LogMessage("clickOverrideSources:: Could not get control of Actions pane.");
                return status;
            }
            
            //Click on the view source details action.
            alertActionsPane.ClickLink(Strings.ActionsPaneTuneAlertActions,
                                            Strings.ContextViewSourceDetail);

            Utilities.TakeScreenshot("View sources dialog");
            MP.Dialogs.TuneAlertsViewSourcesDialog viewSources = new MP.Dialogs.TuneAlertsViewSourcesDialog(CoreManager.MomConsole);
            if (viewSources == null)
            {
                Utilities.LogMessage("clickOverrideSources:: Could not create TuneAlertsViewSourcesDialog class.");
                return status;
            }

            viewSources.ScreenElement.WaitForReady();
            viewSources.Extended.SetFocus();
            if(!viewSources.overrideSources(TunealertsParam))
            {
                Utilities.LogMessage("clickOverrideSources :: OverrideSouces not successful");
                return status;
            }
            if (!Overrideschange(TunealertsParam))
            {
                Utilities.LogMessage("clickOverrideSources :: Overridechange not successful");
                return status;
            }
            viewSources.Extended.SetFocus();
            //Sleep for 20 seconds to wait for viewsources window to focus.
            Sleeper.Delay(Seconds);
            viewSources.ClickCloseButton();
            //Sleep for 20 seconds to wait for viewsources window to close.
            Sleeper.Delay(Seconds);
            //Click on the view source details action again for verification.
            tempWindow.Extended.SetFocus();
            tempViewPane.Grid.Rows[1].AccessibleObject.Click();
            alertActionsPane.ClickLink(Strings.ActionsPaneTuneAlertActions,
                                            Strings.ContextViewSourceDetail);
            if (TunealertsParam.OverrideOrDisable.Equals(TuneAlertsViewSourcesDialog.Strings.Disable))
            {
                if (!verifyOverridesDisable(TunealertsParam))
                {
                    Utilities.LogMessage("clickOverrideSources :: OverrideDiable not successful");
                    tempWindow.Extended.SetFocus();
                    ClickTitleBarClose();
                    return status;
                }
            }
            else
            {
                if (!verifyOverridesChange(TunealertsParam))
                {
                    Utilities.LogMessage("clickOverrideSources :: Overridechange not successful");
                    tempWindow.Extended.SetFocus();
                    ClickTitleBarClose();
                    return status;
                }  
            }
            tempWindow.Extended.SetFocus();
            ClickTitleBarClose();
            return true;
        }

        /// <summary>
        /// This method selects a management pack after setting min alert count to 1.
        /// Then clicks on the Tune Alerts action and calls the overridesouces function.
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="TunealertsParameters">Tunelertsparam Object</param>
        private bool Overrideschange(TuneAlertsParameters TunealertsParam)
        {
            bool status = false;
            //for Disable overrides, directly click the Ok button.
            if (!TunealertsParam.OverrideOrDisable.Equals(TuneAlertsViewSourcesDialog.Strings.Disable))
            {
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                Core.Console.MomControls.GridControl overridesGrid = new Core.Console.MomControls.GridControl(overrideProperties,
                    Core.Console.Overrides.Dialogs.OverrideProperties.ControlIDs.DataGridView1);
                if (overridesGrid == null)
                {
                    Utilities.LogMessage("Overrideschange:: Could not control of Grid view.");
                    return status;
                }
                Utilities.TakeScreenshot("OverrideProperties");
                int rowPos, colPos = -1;

                rowPos = overridesGrid.FindData(TunealertsParam.OverrideParameter, MomControls.GridControl.SearchStringMatchType.ExactMatch).AccessibleObject.Index;
                colPos = overridesGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideHeader);
                Utilities.LogMessage("Overrideschange:: Row Position for Parameter: "
                    + TunealertsParam.OverrideParameter + " is: " + rowPos);

                Maui.Core.WinControls.DataGridViewCheckBoxCell overrideCheckBox =
                    new Maui.Core.WinControls.DataGridViewCheckBoxCell(overridesGrid.Rows[rowPos].Cells[colPos].AccessibleObject);
                if (overrideCheckBox == null)
                {
                    Utilities.LogMessage("Overrideschange:: Could not control of checkbox.");
                    return status;
                }
                Utilities.LogMessage("Overrideschange:: Column Position for Header: "
                    + Core.Console.Overrides.Overrides.Strings.OverrideHeader + " is: " + colPos);
                // Check the checkbox for the parameter to be overridden
                if (overrideCheckBox.AccessibleObject.Value != Strings.chkBoxEnabled)
                {
                    overrideCheckBox.AccessibleObject.Click();
                }
                colPos = overridesGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSettingHeader);

                overridesGrid.SetCellValue(rowPos, colPos, TunealertsParam.OverrideParameterValue, DataGridViewCellType.ComboBox);
                Utilities.LogMessage("Overrideschange:: Parameter: " + TunealertsParam.OverrideParameter +
                                        " is set to value: " + TunealertsParam.OverrideParameterValue);

                ComboBox managementPackComboBox = new ComboBox(overrideProperties,
                    Core.Console.Overrides.Dialogs.OverrideProperties.ControlIDs.SelectDestinationManagementPackComboBox);
                if (managementPackComboBox == null)
                {
                    Utilities.LogMessage("Overrideschange:: Could not control of combobox.");
                    return status;
                }

                if (managementPackComboBox.IsEnabled)
                {
                    managementPackComboBox.ClickDropDown();
                    managementPackComboBox.SelectByText(TunealertsParam.ComboMPName);
                }
            }
            //CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
            overrideProperties.ScreenElement.WaitForReady();
            overrideProperties.ClickOK();
            //Sleep for 20 seconds to wait for overrideProperties window to close.
            Sleeper.Delay(Seconds);
            return true;
        }

        /// <summary>
        /// This method verifies whether overridechange method successfully changed the override parameter.
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="TunealertsParameters">Tunelertsparam Object</param>
        private bool verifyOverridesChange(TuneAlertsParameters TunealertsParam)
        {
            bool status = false;
            MP.Dialogs.TuneAlertsViewSourcesDialog viewSources = new MP.Dialogs.TuneAlertsViewSourcesDialog(CoreManager.MomConsole);
            if (viewSources == null)
            {
                Utilities.LogMessage("verifyOverridesChange:: Could not create TuneAlertsViewSourcesDialog class.");
                return status;
            }
            viewSources.ScreenElement.WaitForReady();
            viewSources.Extended.SetFocus();

            if (!viewSources.overrideSources(TunealertsParam))
            {
                Utilities.LogMessage("verifyOverridesChange :: OverrideSources not successful");
                return status;
            }

            OverrideProperties verifyoverrideProperties = new OverrideProperties(CoreManager.MomConsole);
            if (verifyoverrideProperties == null)
            {
                Utilities.LogMessage("verifyOverridesChange:: Could not create OverrideProperties Dialog.");
                return status;
            }

            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
            Core.Console.MomControls.GridControl overridesGrid = new Core.Console.MomControls.GridControl(verifyoverrideProperties,
                Core.Console.Overrides.Dialogs.OverrideProperties.ControlIDs.DataGridView1);
            if (overridesGrid == null)
            {
                Utilities.LogMessage("verifyOverridesChange:: Could not control of Grid view.");
                return status;
            }

            int rowPos, colPos = -1;
            rowPos = overridesGrid.FindData(TunealertsParam.OverrideParameter, MomControls.GridControl.SearchStringMatchType.ExactMatch).AccessibleObject.Index;
            colPos = overridesGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSettingHeader);
            
            Utilities.LogMessage("verifyOverridesChange:: Row Position for Parameter: "
                + TunealertsParam.OverrideParameter + " is: " + rowPos);
            Utilities.LogMessage("verifyOverridesChange:: Column Position for Parameter: "
                + TunealertsParam.OverrideParameter + " is: " + colPos);
            if (string.Compare(overridesGrid.GetCellValue(rowPos, colPos), TunealertsParam.OverrideParameterValue, true) == 0)
            {
                Utilities.LogMessage("verifyOverridesChange :: edit Override was successful");
                status = true;
            }
            else
            {
                Utilities.LogMessage("verifyOverridesChange :: edit Override value: " + overridesGrid.GetCellValue(rowPos, colPos) +
                    " didnot match with: " + TunealertsParam.OverrideParameterValue);
            }
            Utilities.TakeScreenshot("VerifyOverrideProperties");
            verifyoverrideProperties.ClickOK();
            //Sleep for 20 seconds to wait for overrideProperties window to close.
            Sleeper.Delay(Seconds);
            viewSources.ScreenElement.WaitForReady();
            viewSources.Extended.SetFocus();
            viewSources.ClickCloseButton();
            //Sleep for 20 seconds to wait for viewsources window to close.
            Sleeper.Delay(Seconds);
            return status;
        }

        /// <summary>
        /// This method verifies whether overridechange method successfully disabled the override.
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="TunealertsParameters">Tunelertsparam Object</param>
        private bool verifyOverridesDisable(TuneAlertsParameters TunealertsParam)
        {
            bool status = false;
            
            MP.Dialogs.TuneAlertsViewSourcesDialog viewSources = new MP.Dialogs.TuneAlertsViewSourcesDialog(CoreManager.MomConsole);
            if (viewSources == null)
            {
                Utilities.LogMessage("verifyOverridesDisable:: Could not create TuneAlertsViewSourcesDialog class.");
                return status;
            }
            viewSources.ScreenElement.WaitForReady();
            viewSources.Extended.SetFocus();

            //change the Parameters for verifying if Disable was successful.
            TunealertsParam.OverrideOrDisable = TuneAlertsViewSourcesDialog.Strings.Override;
            TunealertsParam.OverrideParameter = TuneAlertsView.OverrideParameter;
            TunealertsParam.OverrideParameterValue = TuneAlertsView.OverrideParameterValue;

            if (!viewSources.overrideSources(TunealertsParam))
            {
                Utilities.LogMessage("verifyOverridesDisable :: OverrideSources not successful");
                return status;
            }

            OverrideProperties verifyoverrideProperties = new OverrideProperties(CoreManager.MomConsole);
            if (verifyoverrideProperties == null)
            {
                Utilities.LogMessage("verifyOverridesDisable:: Could not create OverrideProperties Dialog.");
                return status;
            }

            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
            Core.Console.MomControls.GridControl overridesGrid = new Core.Console.MomControls.GridControl(verifyoverrideProperties,
                Core.Console.Overrides.Dialogs.OverrideProperties.ControlIDs.DataGridView1);
            if (overridesGrid == null)
            {
                Utilities.LogMessage("verifyOverridesDisable:: Could not control of Grid view.");
                return status;
            }

            int rowPos, colPos = -1;
            rowPos = overridesGrid.FindData(TunealertsParam.OverrideParameter, MomControls.GridControl.SearchStringMatchType.ExactMatch).AccessibleObject.Index;
            colPos = overridesGrid.GetColumnTitlePosition(Core.Console.Overrides.Overrides.Strings.OverrideSettingHeader);

            Utilities.LogMessage("verifyOverridesDisable:: Row Position for Parameter: "
                + TunealertsParam.OverrideParameter + " is: " + rowPos);
            Utilities.LogMessage("verifyOverridesDisable:: Column Position for Parameter: "
                + TunealertsParam.OverrideParameter + " is: " + colPos);
            if (string.Compare(overridesGrid.GetCellValue(rowPos, colPos), TunealertsParam.OverrideParameterValue, true) == 0)
            {
                Utilities.LogMessage("verifyOverridesDisable :: edit Override was successful");
                status = true;
            }
            else
            {
                Utilities.LogMessage("verifyOverridesDisable :: Override value: " + overridesGrid.GetCellValue(rowPos, colPos) +
                    " didnot match with: " + TunealertsParam.OverrideParameterValue);
            }
            Utilities.TakeScreenshot("VerifyOverrideDisable");
            verifyoverrideProperties.ClickOK();
            //Sleep for 20 seconds to wait for overrideProperties window to close.
            Sleeper.Delay(Seconds);
            viewSources.ScreenElement.WaitForReady();
            viewSources.Extended.SetFocus();
            viewSources.ClickCloseButton();
            //Sleep for 20 seconds to wait for viewsources window to close.
            Sleeper.Delay(Seconds);
            return status;
        }
   
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click TitleBar close button
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private void ClickTitleBarClose()
        {
            try
            {
                this.AccessibleObject.Window.ClickTitleBarClose();
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);
                CoreManager.MomConsole.MainWindow.WaitForResponse();
                Utilities.TakeScreenshot("Tune Alerts window closed");
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException)
            {
                Utilities.LogMessage("Invalid HWnd was hit, but should be ok");
            }
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
                tempWindow = new Window(WindowType.Foreground);
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tune Alerts.
            /// </summary>
            /// <history>
            ///		[satim]  06FEB16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextViewSourceDetail =
                ";View or Override Sources;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.views.TuneAlertsView;ViewSorceDetail";
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Create a new group in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneTuneAlertActions =
                ";ActionGroupText;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.views.TuneAlertsView;ActionGroupText";

            /// <summary>
            /// Resource string for Tune Alerts Title
            /// </summary>
            private const string ResourceDialogTitle = ";TuneAlertsView;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneAlertsView;$this.Text";


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGrid1 = ";Grid;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneAlertsView;Grid";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// string for ChkBoxEnabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string chkBoxEnabled = "True";
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
            /// Caches the translated resource string for:  Grid1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGrid1;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextViewSourceDetail
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextViewSourceDetail;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ActionsPaneTuneAlertActions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActionsPaneTuneAlertActions;

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
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Grid1
            {
                get
                {
                    if ((cachedGrid1 == null))
                    {
                        cachedGrid1 = CoreManager.MomConsole.GetIntlStr(ResourceGrid1);
                    }
                    return cachedGrid1;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextViewSourceDetail translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextViewSourceDetail
            {
                get
                {
                    if ((cachedContextViewSourceDetail == null))
                    {
                        cachedContextViewSourceDetail = CoreManager.MomConsole.GetIntlStr(ResourceContextViewSourceDetail);
                    }

                    return cachedContextViewSourceDetail;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ActionsPaneTuneAlertActions in the actions pane translated resource string
            /// </summary>
            /// <history>
            ///     [satim] 27/02/2016 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneTuneAlertActions
            {
                get
                {
                    if ((cachedActionsPaneTuneAlertActions == null))
                    {
                        cachedActionsPaneTuneAlertActions = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneTuneAlertActions);
                    }

                    return cachedActionsPaneTuneAlertActions;
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
            /// Control ID for data grid view
            /// </summary>
            public const string Grid1 = "Grid";

            /// <summary>
            /// Control ID for DataGridView1
            /// </summary>
            public const string DataGridView1 = "overridesDataGridView";
        }
        #endregion
    }
}
