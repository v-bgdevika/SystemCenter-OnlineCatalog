// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TuneManagementPackFilterDataDialog.cs">
// 	Copyright (c) Microsoft Corporation 2016
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  Tune Management Packs Filter Data 
// </summary>
// <history>
// 	[satim] 27/02/2016 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - ITuneManagementPackFilterDataDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITuneManagementPackFilterDataDialogControls, for TuneManagementPackFilterDataDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[satim] 27/02/2016 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITuneManagementPackFilterDataDialogControls
    {
        /// <summary>
        /// property to access takeMinimumAlertCountControl
        /// </summary>
        NumericUpDown takeMinimumAlertCountControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access OkButton
        /// </summary>
        Button buttonOK
        {
            get;
        }

    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Tune Management Pack Filter Data
    /// </summary>
    /// <history>
    /// 	[satim] 27/02/2016 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    class TuneManagementPackFilterDataDialog : Dialog, ITuneManagementPackFilterDataDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to takeMinimumAlertCountControl of type TextBox
        /// </summary>
        private NumericUpDown cachedtakeMinimumAlertCountControl;       

        /// <summary>
        /// Cache to hold a reference to buttonOK of type Button
        /// </summary>
        private Button cachedbuttonOK;

        #endregion

        #region Constructors

        /// ------------------------------------------------------------------
        /// <summary>
        /// Tune Management Pack Filter Data Dialog
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// ------------------------------------------------------------------
        public TuneManagementPackFilterDataDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            
        }
        #endregion

        #region ITuneManagementPackFilterDataDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITuneManagementPackFilterDataDialogControls Controls
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
        ///  Routine to set/get the text in control takeMinimumAlertCountControl
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual int takeMinimumAlertCountValue
        {
            get
            {
                return this.Controls.takeMinimumAlertCountControl.Value;
            }

            set
            {
                this.Controls.takeMinimumAlertCountControl.Value = value; 
            }
        }
        #endregion
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the takeMinimumAlertCountControl control
        /// </summary>
        /// <history>
        /// 	takeMinimumAlertCountControl
        /// </history>
        /// -----------------------------------------------------------------------------
        NumericUpDown ITuneManagementPackFilterDataDialogControls.takeMinimumAlertCountControl
        {
            get
            {
                if ((this.cachedtakeMinimumAlertCountControl == null))
                {
                    this.cachedtakeMinimumAlertCountControl = new NumericUpDown(this, TuneManagementPackFilterDataDialog.ControlIDs.takeMinimumAlertCountControl);
                }
                return this.cachedtakeMinimumAlertCountControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OkButton control
        /// </summary>
        /// <history>
        /// 	takeMinimumAlertCountControl
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITuneManagementPackFilterDataDialogControls.buttonOK
        {
            get
            {
                if ((this.cachedbuttonOK == null))
                {
                    this.cachedbuttonOK = new Button(this, TuneManagementPackFilterDataDialog.ControlIDs.buttonOK);
                }
                return this.cachedbuttonOK;
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[satim] 27/02/2016 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOk()
        {
            this.Controls.buttonOK.Click();
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
            /// Resource string for Tune Management Pack filter data Dialog Title
            /// </summary>
            private const string ResourceDialogTitle = ";TuneManagementPackFilterData;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneManagementPackFilterData;$this.Text";


            /// <summary>
            /// Resource string for takeMinimumAlertCountTextBox Title
            /// </summary>
            private const string ResourcetakeMinimumAlertCountTextBox = ";takeMinimumAlertCount;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneManagementPackFilterData;$this.Text";

            /// <summary>
            /// Resource string for Ok
            /// </summary>
            private const string ResourceOk = ";buttonOk;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Views.TuneManagementPackFilterData;$this.Text";

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
            /// Caches the translated resource takeMinimumAlertCountTextBox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedtakeMinimumAlertCountTextBox;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource button OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedbuttonOK;

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
            /// Exposes access to the takeMinimumAlertCountTextBox translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string takeMinimumAlertCountTextBox
            {
                get
                {
                    if ((cachedtakeMinimumAlertCountTextBox == null))
                    {
                        cachedtakeMinimumAlertCountTextBox = CoreManager.MomConsole.GetIntlStr(ResourcetakeMinimumAlertCountTextBox);
                    }
                    return cachedtakeMinimumAlertCountTextBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ok translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 27/02/2016 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string buttonOK
            {
                get
                {
                    if ((cachedbuttonOK == null))
                    {
                        cachedbuttonOK = CoreManager.MomConsole.GetIntlStr(ResourceOk);
                    }
                    return cachedbuttonOK;
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
            /// Control ID for takeMinimumAlertCountControl
            /// </summary>
            public const string takeMinimumAlertCountControl = "takeMinimumAlertCount";

            /// <summary>
            /// Control ID for OkButton
            /// </summary>
            public const string buttonOK = "buttonOK";
        }
        #endregion
    }
}
