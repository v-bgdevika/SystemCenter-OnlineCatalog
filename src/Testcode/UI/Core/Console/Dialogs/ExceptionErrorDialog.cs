// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="ExceptionErrorDialog.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
//  Exception Error Dialog
// </summary>
// <history>
//  [mbickle] 29APR06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interface Definition - IExceptionErrorDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IExceptionErrorDialogControls, for ExceptionErrorDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///  [mbickle] 29APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IExceptionErrorDialogControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DetailsText
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox DetailsText
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DetailsLink
        /// </summary>
        Window DetailsLink
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DetailsLink
        /// </summary>
        Window HideDetailsLink
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ErrorMessageText
        /// </summary>
        StaticControl ErrorMessageText
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorTitle
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl ErrorTitle
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CopyToClipboard
        /// </summary>
        Window CopyToClipboard
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
    ///  [mbickle] 29APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ExceptionErrorDialog : Dialog, IExceptionErrorDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to DetailsText of type DetailsText
        /// </summary>
        private TextBox cachedDetailsText;
        
        /// <summary>
        /// Cache to hold a reference to DetailsLink of type Button
        /// </summary>
        private Window cachedDetailsLink;

        /// <summary>
        /// Cache to hold a reference to DetailsLink of type Button
        /// </summary>
        private Window cachedHideDetailsLink;

        /// <summary>
        /// Cache to hold a reference to ErrorMessageText of type ErrorMessageText
        /// </summary>
        private StaticControl cachedErrorMessageText;
        
        /// <summary>
        /// Cache to hold a reference to ErrorTitle of type StaticControl
        /// </summary>
        private StaticControl cachedErrorTitle;

        /// <summary>
        /// Cache to hold a reference to CopyToClipboard
        /// </summary>
        private Window cachedCopyToClipboard;
        #endregion
        
        #region Constructors
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ExceptionErrorDialog of type ConsoleApp
        /// </param>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ExceptionErrorDialog(ConsoleApp app) : 
                base(app, Init())
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ExceptionErrorDialog of type ConsoleApp
        /// </param>
        /// <param name="dialogTitle">Title of the Dialog</param>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ExceptionErrorDialog(ConsoleApp app, string dialogTitle) :
            base(app, Init(dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IExceptionErrorDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IExceptionErrorDialogControls Controls
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
        ///  Routine to set/get the text in control DetailsText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DetailsText
        {
            get
            {
                return this.Controls.DetailsText.Text;
            }
            
            set
            {
                this.Controls.DetailsText.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control 
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ErrorMessageText
        {
            get
            {
                return this.Controls.ErrorMessageText.Text;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IExceptionErrorDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, ExceptionErrorDialog.QueryIds.CloseButton);
                }

                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsText control
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IExceptionErrorDialogControls.DetailsText
        {
            get
            {
                if (this.ScreenElement.FrameworkId.Equals("WPF"))
                {
                    this.cachedDetailsText = new TextBox(this, ExceptionErrorDialog.QueryIds.DetailsText);
                }
                else
                {
                    this.cachedDetailsText = new TextBox(this, ExceptionErrorDialog.ControlIDs.DetailsText);
                }

                return this.cachedDetailsText;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsLink control
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Window IExceptionErrorDialogControls.DetailsLink
        {
            get
            {
                this.cachedDetailsLink = new Window(this, ExceptionErrorDialog.QueryIds.ShowDetailsLabel, 5000);

                return this.cachedDetailsLink;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsLink control
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Window IExceptionErrorDialogControls.HideDetailsLink
        {
            get
            {
                this.cachedHideDetailsLink = new Window(this, ExceptionErrorDialog.QueryIds.HideDetailsLabel, 5000);

                return this.cachedHideDetailsLink;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorMessageText control
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExceptionErrorDialogControls.ErrorMessageText
        {
            get
            {
                if (this.ScreenElement.FrameworkId.Equals("WPF"))
                {
                    RPFSupport.RPF.SetSearchTimeout(5000);
                    IScreenElement se = this.ScreenElement.FindByPartialQueryId(ExceptionErrorDialog.QueryIds.ResourceErrorMessageText, null);
                    RPFSupport.RPF.SetSearchTimeout(180000);
                    ////this.cachedErrorMessageText = new StaticControl(this, ExceptionErrorDialog.QueryIds.ErrorMessageText, Timeout);
                    this.cachedErrorMessageText = new StaticControl(new Window(se));
                }
                else
                {
                    this.cachedErrorMessageText = new StaticControl(this, ExceptionErrorDialog.ControlIDs.ErrorMessageText);
                    if (this.cachedErrorMessageText == null)
                    {
                        this.cachedErrorMessageText = new StaticControl(this, ExceptionErrorDialog.ControlIDs.ErrorMessageText);
                    }
                }

                return this.cachedErrorMessageText;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorTitle control
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IExceptionErrorDialogControls.ErrorTitle
        {
            get
            {
                if (this.ScreenElement.FrameworkId.Equals("WPF"))
                {
                    RPFSupport.RPF.SetSearchTimeout(5000);
                    IScreenElement se = this.ScreenElement.FindByPartialQueryId(ExceptionErrorDialog.QueryIds.ResourceErrorTitle, null);
                    RPFSupport.RPF.SetSearchTimeout(180000);
                    ////this.cachedErrorMessageText = new StaticControl(this, ExceptionErrorDialog.QueryIds.ErrorMessageText, Timeout);
                    this.cachedErrorMessageText = new StaticControl(new Window(se));
                }
                else
                {
                    this.cachedErrorTitle = new StaticControl(this, ExceptionErrorDialog.ControlIDs.ErrorTitle);
                }

                return this.cachedErrorTitle;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CopyToClipboard control
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Window IExceptionErrorDialogControls.CopyToClipboard
        {
            get
            {
                if ((this.cachedCopyToClipboard == null))
                {
                    this.cachedCopyToClipboard = new Window(this, ExceptionErrorDialog.QueryIds.CopyToClipboard, 5000);
                }

                return this.cachedCopyToClipboard;
            }
        }
        #endregion

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to check for the exceptions dialog that the UI pops up to catch
        /// SDK Exceptions.  
        /// The method will log the exception message
        /// and stack trace to the default logger in the Utilities class.
        /// The method will then close the dialog.
        /// </summary>
        /// <returns>
        /// A boolean indicating whether or not an unhandled exceptions
        /// dialog was found and handled.
        /// </returns>
        /// <exception cref="Maui.GlobalExceptions.MauiException">
        /// Since this method uses Maui to manipulate the dialog, it can
        /// throw any of the exceptions defined in the Maui class libraries.
        /// All of those exceptions derive from the base class, MauiException.
        /// </exception>
        /// <history>
        /// [mbickle] 29APR06: Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool CheckForExceptionErrorDialog()
        {
            return CheckForExceptionErrorDialog("*", true);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to check for the exceptions dialog that the UI pops up to catch
        /// SDK Exceptions.  
        /// The method will log the exception message
        /// and stack trace to the default logger in the Utilities class.
        /// The method will then close the dialog.
        /// </summary>
        /// <param name="dialogTitle">Dialog Title</param>
        /// <returns>
        /// A boolean indicating whether or not an unhandled exceptions
        /// dialog was found and handled.
        /// </returns>
        /// <exception cref="Maui.GlobalExceptions.MauiException">
        /// Since this method uses Maui to manipulate the dialog, it can
        /// throw any of the exceptions defined in the Maui class libraries.
        /// All of those exceptions derive from the base class, MauiException.
        /// </exception>
        /// <history>
        /// [mbickle] 29APR06: Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool CheckForExceptionErrorDialog(string dialogTitle)
        {
            return CheckForExceptionErrorDialog(dialogTitle, true);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to check for the exceptions dialog that the UI pops up to catch
        /// SDK Exceptions.  
        /// The method will log the exception message
        /// and stack trace to the default logger in the Utilities class.
        /// The method will then close the dialog.
        /// </summary>
        /// <param name="dialogTitle">Dialog Title</param>
        /// <param name="dismiss">Dismiss Dialog if found: True/False</param>
        /// <returns>
        /// A boolean indicating whether or not an unhandled exceptions
        /// dialog was found and handled.
        /// </returns>
        /// <exception cref="Maui.GlobalExceptions.MauiException">
        /// Since this method uses Maui to manipulate the dialog, it can
        /// throw any of the exceptions defined in the Maui class libraries.
        /// All of those exceptions derive from the base class, MauiException.
        /// </exception>
        /// <history>
        /// [mbickle] 29APR06: Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool CheckForExceptionErrorDialog(string dialogTitle, bool dismiss)
        {
            if (string.IsNullOrEmpty(dialogTitle))
            {
                // Set dialogTitle to wildcard if Null/Empty
                dialogTitle = "*";
            }

            // set the default return value for the method
            bool returnValue = false;
            Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: " + dialogTitle);

            #region Check for Exceptions Dialog

            // initialize the unhandled exceptions dialog reference
            Dialogs.ExceptionErrorDialog exceptionDialog = null;

            // look for the dialog
            try
            {
                // create a new instance of the dialog
                exceptionDialog = new ExceptionErrorDialog(CoreManager.MomConsole, dialogTitle);

                if (exceptionDialog != null)
                {
                    exceptionDialog.Extended.SetFocus();
                    exceptionDialog.ScreenElement.WaitForReady();

                    // set the return value
                    returnValue = true;

                    // log the text of the error message
                    Utilities.LogMessage(string.Format("ConsoleApp.CheckForExceptionErrorDialog:: ErrorMessage: \n\r {0}", exceptionDialog.ErrorMessageText));

                    // Details is closed, lets open it.
                    exceptionDialog.ClickDetails();

                    try
                    {
                        // log the text of the stack trace
                        Utilities.LogMessage(string.Format("ConsoleApp.CheckForExceptionErrorDialog:: Details: \n\r {0}", exceptionDialog.DetailsText));
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
                    {
                        Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Failed to get Details." + ex);
                    }

                    Utilities.TakeScreenshot("ConsoleApp.CheckForExceptionErrorDialog.Found");

                    if (dismiss)
                    {
                        Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Closing Dialog");

                        // click the "Close" button
                        exceptionDialog.ClickClose();
                    }
                    else
                    {
                        Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Not Closing Dialog");
                    }
                }
            }
            catch (System.InvalidOperationException)
            {
                // log message, no unhandled exceptions dialog was found
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: No exceptions dialog found.");
                returnValue = false;
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                // log message, no unhandled exceptions dialog was found
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: No exceptions dialog found.");
                returnValue = false;
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException invalidHandle)
            {
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Window handle is invalid.\n\r" + invalidHandle.Message + "\n\r" + invalidHandle.StackTrace);
                returnValue = false;
            }
            catch (Maui.GlobalExceptions.TimedOutException timedOut)
            {
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Window timed out waiting for response.\n\r" + timedOut.Message + "\n\r" + timedOut.StackTrace);
                returnValue = false;
            }

            #endregion // Check for Exceptions Dialog

            // return true, found and handled dialog; or false, no dialog found
            return returnValue;
        }

        #region Click Methods
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Details
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDetails()
        {
            this.Controls.DetailsLink.ScreenElement.LeftButtonClick(-1, -1);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Details
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHideDetails()
        {
            this.Controls.HideDetailsLink.ScreenElement.LeftButtonClick(-1, -1);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on CopyTOClipboard
        /// </summary>
        /// <history>
        ///  [mbickle] 27MAR09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCopyToClipboard()
        {
            this.Controls.CopyToClipboard.ScreenElement.LeftButtonClick(-1, -1);
        }
        #endregion

        #region Private Methods
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init()
        {
            return Init(Strings.DialogTitle);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="dialogTitle">Dialog Title</param>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;

            try
            {
                    Utilities.LogMessage(string.Format("ExceptionErrorDialog.Init:: app != null, looking for '{0}' ErrorDialog", dialogTitle));

                // Try to locate an existing instance of a dialog
                RPFSupport.RPF.SetSearchTimeout(5000);
                tempWindow = new Window(
                       dialogTitle,
                       StringMatchSyntax.ExactMatch,
                       WindowClassNames.WinForms10Window8,
                       StringMatchSyntax.ExactMatch,
                       CoreManager.MomConsole.MainWindow,
                       5000);
                //tempWindow = new Window(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId='ErrorDialog'"), 5000);
                RPFSupport.RPF.SetSearchTimeout(180000);

                Utilities.LogMessage("ExceptionErrorDialog.Init:: ");
            }            
            catch (System.Exception)
            {
                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Utilities.LogMessage(
                        "ExceptionErrorDialog.Init:: Failed to find window with title:  '" +
                        dialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw;
                }
            }

            return tempWindow;
        }
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings
        /// </summary>
        /// <history>
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Close;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ErrorDialog;closeButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Details opened 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDetailsOpened = ";Details <<;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ErrorDialogResources;DetailsOpennedText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Details closed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDetailsClosed = ";Details >>;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ErrorDialogResources;DetailsClosedText";
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
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Details opened
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDetailsOpened;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Details closed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDetailsClosed;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 29APR06 Created
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
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
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
            /// Exposes access to the Details opened translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DetailsOpened
            {
                get
                {
                    if ((cachedDetailsOpened == null))
                    {
                        cachedDetailsOpened = CoreManager.MomConsole.GetIntlStr(ResourceDetailsOpened);
                    }

                    return cachedDetailsOpened;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Details closed translated resource string
            /// </summary>
            /// <history>
            ///  [mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DetailsClosed
            {
                get
                {
                    if ((cachedDetailsClosed == null))
                    {
                        cachedDetailsClosed = CoreManager.MomConsole.GetIntlStr(ResourceDetailsClosed);
                    }

                    return cachedDetailsClosed;
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
        ///  [mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";
            
            /// <summary>
            /// Control ID for DetailsText
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string DetailsText = "detailText";
            
            /// <summary>
            /// Control ID for DetailsButton
            /// </summary>
            public const string DetailsButton = "detailButton";
            
            /// <summary>
            /// Control ID for ErrorMessageText
            /// </summary>
            public const string ErrorMessageText = "errorMessage";
            
            /// <summary>
            /// Control ID for ErrorTitle
            /// </summary>
            public const string ErrorTitle = "errorTitle";

            /// <summary>
            /// Control ID for HideDetailsLabel
            /// </summary>
            public const string HideDetailsLabel = "hideDetailsLabel";

            /// <summary>
            /// Control ID for ShowDetailsLabel
            /// </summary>
            public const string ShowDetailsLabel = "showDetailsLabel";

            /// <summary>
            /// Control ID for ShowDetailsLabel
            /// </summary>
            public const string CopyToClipboard = "copyDetailsLinkLabel";
        }
        #endregion

        #region QueryIDs
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all Query ID's.
        /// </summary>
        /// <history>
        ///  [mbickle] 23MAR09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string ResourceCloseButton = ";[UIA, VisibleOnly]AutomationId = 'closeButton' && Role='push button'";

            /// <summary>
            /// Control ID for DetailsText
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ResourceDetailsText = ";[UIA, VisibleOnly]AutomationId = 'detailsText'";

            /// <summary>
            /// Control ID for DetailsButton
            /// </summary>
            public const string ResourceDetailsButton = ";[UIA, VisibleOnly]AutomationId = 'detailButton'";

            /// <summary>
            /// Control ID for ErrorMessageText
            /// </summary>
            public const string ResourceErrorMessageText = ";[UIA, VisibleOnly]AutomationId = 'errorMessage' && Role='text'";

            /// <summary>
            /// Control ID for ErrorTitle
            /// </summary>
            public const string ResourceErrorTitle = ";[UIA, VisibleOnly]AutomationId = 'errorTitle'";

            /// <summary>
            /// Control ID for HideDetailsLabel
            /// </summary>
            public const string ResourceHideDetailsLabel = ";[UIA, VisibleOnly]AutomationId = 'hideDetailsLabel'";

            /// <summary>
            /// Control ID for ShowDetailsLabel
            /// </summary>
            public const string ResourceShowDetailsLabel = ";[UIA, VisibleOnly]AutomationId = 'showDetailsLabel';Role='link'";

            /// <summary>
            /// Control ID for CopyToClipboard
            /// </summary>
            public const string ResourceCopyToClipboard = ";[UIA, VisibleOnly]AutomationId = 'copyToClipboard' | 'copyDetailsLinkLabel'";

            #endregion

            #region Private Members
            /// <summary>
            /// Close Button
            /// </summary>
            private static QID cachedCloseButton;

            /// <summary>
            /// Details Text
            /// </summary>
            private static QID cachedDetailsText;

            /// <summary>
            /// Details Button
            /// </summary>
            private static QID cachedDetailsButton;

            /// <summary>
            /// Error Message Text
            /// </summary>
            private static QID cachedErrorMessageText;

            /// <summary>
            /// Error Title
            /// </summary>
            private static QID cachedErrorTitle;

            /// <summary>
            /// Hide Details Label
            /// </summary>
            private static QID cachedHideDetailsLabel;

            /// <summary>
            /// Show Details Label
            /// </summary>
            private static QID cachedShowDetailsLabel;

            /// <summary>
            /// Copy To Clipboard
            /// </summary>
            private static QID cachedCopyToClipboard;
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CloseButton
            /// </summary>
            /// <history>
            ///  [mbickle] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CloseButton
            {
                get
                {
                    if (cachedCloseButton == null)
                    {
                        cachedCloseButton = new QID(ResourceCloseButton);
                    }

                    return cachedCloseButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DetailsText
            /// </summary>
            /// <history>
            ///  [mbickle] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DetailsText
            {
                get
                {
                    if (cachedDetailsText == null)
                    {
                        cachedDetailsText = new QID(ResourceDetailsText);
                    }

                    return cachedDetailsText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DetailsButton
            /// </summary>
            /// <history>
            ///  [mbickle] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DetailsButton
            {
                get
                {
                    if (cachedDetailsButton == null)
                    {
                        cachedDetailsButton = new QID(ResourceDetailsButton);
                    }

                    return cachedDetailsButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorMessageText
            /// </summary>
            /// <history>
            ///  [mbickle] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ErrorMessageText
            {
                get
                {
                    if (cachedErrorMessageText == null)
                    {
                        cachedErrorMessageText = new QID(ResourceErrorMessageText);
                    }

                    return cachedErrorMessageText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorTitle
            /// </summary>
            /// <history>
            ///  [mbickle] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ErrorTitle
            {
                get
                {
                    if (cachedErrorTitle == null)
                    {
                        cachedErrorTitle = new QID(ResourceErrorTitle);
                    }

                    return cachedErrorTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HideDetailsLabel
            /// </summary>
            /// <history>
            ///  [mbickle] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID HideDetailsLabel
            {
                get
                {
                    if (cachedHideDetailsLabel == null)
                    {
                        cachedHideDetailsLabel = new QID(ResourceHideDetailsLabel);
                    }

                    return cachedHideDetailsLabel;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowDetailsLabel
            /// </summary>
            /// <history>
            ///  [mbickle] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowDetailsLabel
            {
                get
                {
                    if (cachedShowDetailsLabel == null)
                    {
                        cachedShowDetailsLabel = new QID(ResourceShowDetailsLabel);
                    }

                    return cachedShowDetailsLabel;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CopyToClipboard
            /// </summary>
            /// <history>
            ///  [mbickle] 23MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CopyToClipboard
            {
                get
                {
                    if (cachedCopyToClipboard == null)
                    {
                        cachedCopyToClipboard = new QID(ResourceCopyToClipboard);
                    }

                    return cachedCopyToClipboard;
                }
            }
            #endregion
        }
        #endregion
    }
}
