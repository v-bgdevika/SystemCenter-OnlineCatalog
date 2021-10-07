// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="FailedLaunchWordErrorDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge
// </project>
// <summary>
// 	Error dialog when failed to launch Microsoft word.
// </summary>
// <history>
// 	[v-dayow] 2010/3/26 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    #region Interface Definition - IFailedLaunchWordErrorDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IFailedLaunchWordErrorDialogControls, for FailedLaunchWordErrorDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-dayow] 2010/3/26 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFailedLaunchWordErrorDialogControls
    {
        /// <summary>
        /// Gets read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ErrorMessageLable
        /// </summary>
        StaticControl ErrorMessageLable
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Error dialog when failed to launch Microsoft word.
    /// </summary>
    /// <history>
    ///   [v-dayow] 2010/3/26 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class FailedLaunchWordErrorDialog : Dialog, IFailedLaunchWordErrorDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to ErrorMessageLable of type StaticControl
        /// </summary>
        private StaticControl errorMessageLable;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the FailedLaunchWordErrorDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of FailedLaunchWordErrorDialog of type App
        /// </param>
        /// <history>
        ///   [v-dayow] 2010/3/26 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public FailedLaunchWordErrorDialog(App app, int timeout) :
            base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IFailedLaunchWordErrorDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-dayow] 2010/3/26 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IFailedLaunchWordErrorDialogControls Controls
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
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 2010/3/26 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IFailedLaunchWordErrorDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, FailedLaunchWordErrorDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ErrorMessageLable control
        /// </summary>
        /// <history>
        ///   [v-dayow] 2010/3/26 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IFailedLaunchWordErrorDialogControls.ErrorMessageLable
        {
            get
            {
                if ((this.errorMessageLable == null))
                {
                    this.errorMessageLable = new StaticControl(this, FailedLaunchWordErrorDialog.ControlIDs.ErrorMessageLable);
                }

                return this.errorMessageLable;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        ///   [v-dayow] 2010/3/26 Created
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
        /// <param name="app">App owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-dayow] 2010/3/26 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app, timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // TODO:  Add any specific logic here to handle the case when the
                // dialog is not found in the specified timeout.
                // otherwise rethrow the exception.
                throw;
            }

            return tempWindow;
        }

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [v-dayow] 2010/3/26 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const int OKButton = 2;

            /// <summary>
            /// Control ID for ErrorMessageLable
            /// </summary>
            public const int ErrorMessageLable = 65535;
        }
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <history>
        ///   [v-dayow] 2010/3/26 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Resource string for System Center Operations Manager 2007 R2
            /// </summary>
            private const string ResourceDialogTitle = ";System Center Operations Manager 2007 R2;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomConsoleResources;ProductTitle";

            /// <summary>
            /// Resource string for OK
            /// </summary>
            private const string ResourceOK = ";OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase.resources;buttonOK.Text";

            /// <summary>
            /// Resource string for Failed to launch Microsoft Word. Please make sure Microsoft Word is installed. Here is the error message:
            ///Could not load file or assembly 'Microsoft.Office.Interop.Word, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c' or one of its 
            /// </summary>
            private const string ResourceErrorMessage = ";Failed to launch Microsoft Word. Please make sure Microsoft Word is installed. Here is the error message:{0};ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Knowledge.KnowledgeResources;FailedToLaunchWord";
            #endregion

            #region Private members
            private static string cachedDialogTitle;

            private static string cachedOK;

            private static string cachedErrorMessage;
            #endregion

            #region Properties
            public static string DialogTitle
            {
                get
                {
                    if (cachedDialogTitle == null)
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    return cachedDialogTitle;
                }
            }

            public static string OK
            {
                get
                {
                    if (cachedOK == null)
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    return cachedOK;
                }
            }

            public static string ErrorMessage
            {
                get
                {
                    if (cachedErrorMessage == null)
                        cachedErrorMessage = CoreManager.MomConsole.GetIntlStr(ResourceErrorMessage);
                    return cachedErrorMessage;
                }
            }
            #endregion
        }
        #endregion
    }
}
