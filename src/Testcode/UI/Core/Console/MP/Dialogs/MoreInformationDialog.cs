// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MoreInformationDialog.cs">
// 	Copyright (c) Microsoft Corporation 2015
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  More Information Dialog
// </summary>
// <history>
// 	[rahsing] 12/12/2015 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - IMoreInformationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMoreInformationDialogControls, for MoreInformationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[rahsing] 12/12/2015 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMoreInformationDialogControls
    {
        /// <summary>
        /// Read-only property to access MoreInformationTextBoxControl
        /// </summary>
        TextBox MoreInformationTextBoxControl
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
        /// Read-only property to access CopyButton
        /// </summary>
        Button CopyButton
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
    /// 	[rahsing] 12/12/2015 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    class MoreInformationDialog : Dialog, IMoreInformationDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to MoreInformationTextBox of type TextBox
        /// </summary>
        private TextBox cachedMoreInformationTextBoxControl;       //TODO : Need to change to GridView after implementation of MoreInformationUI

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;

        /// <summary>
        /// Cache to hold a reference to CopyButton of type Button
        /// </summary>
        private Button cachedCopyButton;

        #endregion

        #region Constructors

        /// ------------------------------------------------------------------
        /// <summary>
        /// More Information Dialog
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// ------------------------------------------------------------------
        public MoreInformationDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IMoreInformationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[rahsing] 12/12/2015 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMoreInformationDialogControls Controls
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
        ///  Exposes access to the MoreInformationTextBoxControl control
        /// </summary>
        /// <history>
        /// 	[rahsing] 12/12/2015 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMoreInformationDialogControls.MoreInformationTextBoxControl
        {
            get
            {
                if ((this.cachedMoreInformationTextBoxControl == null))
                {
                    this.cachedMoreInformationTextBoxControl = new TextBox(this, MoreInformationDialog.ControlIDs.MoreInformationTextBoxControl);
                }
                return this.cachedMoreInformationTextBoxControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[rahsing] 12/12/2015 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMoreInformationDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, MoreInformationDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CopyButton control
        /// </summary>
        /// <history>
        /// 	[rahsing] 12/12/2015 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMoreInformationDialogControls.CopyButton
        {
            get
            {
                if ((this.cachedCopyButton == null))
                {
                    this.cachedCopyButton = new Button(this, MoreInformationDialog.ControlIDs.CopyButton);
                }
                return this.cachedCopyButton;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[rahsing] 12/12/2015 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Copy
        /// </summary>
        /// <history>
        /// 	[rahsing] 12/12/2015 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCopy()
        {
            this.Controls.CopyButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[rahsing] 12/12/2015 Created
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
        ///   [rahsing] 12/12/2015 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for More Information Dialog Title
            /// </summary>
            //TOD : Need to Change the Tile for More Information UI
            private const string ResourceDialogTitle = ";More Information;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MoreInformationDialog;$this.Text";


            /// <summary>
            /// Resource string for More Information Dialog Title
            /// </summary>
            //TOD : Need to Change the Tile for More Information UI
            private const string ResourceMoreInformationTextBox = ";More Information;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MoreInformationGridView;$this.Text";

            /// <summary>
            /// Resource string for Close
            /// </summary>
            private const string ResourceClose = ";Close;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MoreInformationDialog;$this.Text";

            /// <summary>
            /// Resource string for Copy
            /// </summary>
            private const string ResourceCopy = ";Copy;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MoreInformationDialog;copyButton.Text";


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
            /// Caches the translated resource the text box of window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreInformationTextBox;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Copy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCopy;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 12/12/2015 Created
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
            /// Exposes access to the MoreInformationTextBox translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 12/12/2015 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreInformationTextBox
            {
                get
                {
                    if ((cachedMoreInformationTextBox == null))
                    {
                        cachedMoreInformationTextBox = CoreManager.MomConsole.GetIntlStr(ResourceMoreInformationTextBox);
                    }
                    return cachedMoreInformationTextBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 12/12/2015 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CloseButton
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
            /// Exposes access to the Copy translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 12/12/2015 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CopyButton
            {
                get
                {
                    if ((cachedCopy == null))
                    {
                        cachedCopy = CoreManager.MomConsole.GetIntlStr(ResourceCopy);
                    }
                    return cachedCopy;
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
        /// 	[rahsing] 12/12/2015 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for DialogTitleControl
            /// </summary>
     //       public const string DialogTitleControl = "DialogTitle";

            /// <summary>
            /// Control ID for MoreInformationTextBoxControl
            /// </summary>
            public const string MoreInformationTextBoxControl = "moreInformationTextBox";

            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";

            /// <summary>
            /// Control ID for CopyButton
            /// </summary>
            public const string CopyButton = "copyButton";
        }
        #endregion
    }
}
