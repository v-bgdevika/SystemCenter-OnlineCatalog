// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="UnhandledExceptionsDialog.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MomConsoleApp Unhandled Exceptions Dialog
// </project>
// <summary>
//  Create a dialog to encapsulate the unhandled exceptions dialog for the MOMv3 UI.
// </summary>
// <history>
//  [KellyMor] 20-Jul-05 Created
//  [KellyMor] 21-Jul-05 Updated Init method attempts to find window and added logging statements
//                       Updated resource strings class
//  [KellyMor] 22-Jul-05 Changed constructor and Init method signatures 
//                       to take a Maui.Core.App.
//                       Renamed from TextBox0Text to StackTraceTextBoxText
//                       Modified Init method's first attempt to find window 
//                       to use app.MainWindow.Caption string
//                       Disabled 'Details' button due to inability to get 
//                       a control reference
//  [KellyMor] 31-Aug-05 Added code to check for valid parent, parent window
//                       and parent window handle to catch window closing
//                       during this Window's initialization.
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    #region Using directives

    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using System.ComponentModel;
    using System;

    #endregion // Using directives

    #region Interface Definition - IUnhandledExceptionsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IUnhandledExceptionsDialogControls, for UnhandledExceptionsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 20-Jul-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IUnhandledExceptionsDialogControls
    {
        /// <summary>
        /// Read-only property to access UnhandledExceptionHasOccurred
        /// </summary>
        StaticControl UnhandledExceptionHasOccurred
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DetailsButton
        /// </summary>
        Button DetailsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContinueButton
        /// </summary>
        Button ContinueButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QuitButton
        /// </summary>
        Button QuitButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StackTraceTextBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox StackTraceTextBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the unhandled exceptions dialog for the MOMv3 UI.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 20-Jul-05 Created
    ///		[KellyMor] 21-Jul-05 Updated Init method attempts to find window
    ///							 Added logging statements to Init method
    ///		[KellyMor] 22-Jul-05 Changed constructor and Init method signatures 
    ///							 to take a Maui.Core.App.
    ///							 Renamed from TextBox0Text to StackTraceTextBoxText
    ///							 Modified Init method's first attempt to find window 
    ///							 to use app.MainWindow.Caption string
    ///							 Disabled 'Details' button due to inability to get 
    ///							 a control reference
    ///     [KellyMor] 31-Aug-05 Added code to check for valid parent, parent window
    ///                          and parent window handle to catch window closing
    ///                          during this Window's initialization.
    /// </history>
    /// -----------------------------------------------------------------------------
    public class UnhandledExceptionsDialog : Dialog, IUnhandledExceptionsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to UnhandledExceptionHasOccurred of type StaticControl
        /// </summary>
        private StaticControl cachedUnhandledExceptionHasOccurred;
        
        /// <summary>
        /// Cache to hold a reference to DetailsButton of type Button
        /// </summary>
        private Button cachedDetailsButton;
        
        /// <summary>
        /// Cache to hold a reference to ContinueButton of type Button
        /// </summary>
        private Button cachedContinueButton;
        
        /// <summary>
        /// Cache to hold a reference to QuitButton of type Button
        /// </summary>
        private Button cachedQuitButton;
        
        /// <summary>
        /// Cache to hold a reference to StackTraceTextBox of type TextBox
        /// </summary>
        private TextBox cachedStackTraceTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor, requires a reference to the parent application.
        /// </summary>
        /// <param name='app'>
        /// Owner of UnhandledExceptionsDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        ///		[KellyMor] 22-Jul-05 Changed method signature to take a Maui.Core.App
        /// </history>
        /// -----------------------------------------------------------------------------
        public UnhandledExceptionsDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // Default Constructor - no logic required here. 
        }
        #endregion
        
        #region IUnhandledExceptionsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IUnhandledExceptionsDialogControls Controls
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
        ///  Routine to set/get the text in control StackTraceTextBox
        /// </summary>
        /// <value>None.  This is a read-only text field.</value>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        ///		[KellyMor] 22-Jul-05 Renamed from TextBox0Text to StackTraceTextBoxText
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StackTraceTextBoxText
        {
            get
            {
                return this.Controls.StackTraceTextBox.Text;
            }
            
            //set
            //{
            //    this.Controls.StackTraceTextBox.Text = value;
            //}
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UnhandledExceptionHasOccurred control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IUnhandledExceptionsDialogControls.UnhandledExceptionHasOccurred
        {
            get
            {
                if ((this.cachedUnhandledExceptionHasOccurred == null))
                {
                    Window wndTemp = this; // this.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedUnhandledExceptionHasOccurred = new StaticControl(wndTemp);
                }
                return this.cachedUnhandledExceptionHasOccurred;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        ///		[KellyMor] 22-Jul-05 Modified Button constructor to search parent window
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUnhandledExceptionsDialogControls.DetailsButton
        {
            get
            {
                if ((this.cachedDetailsButton == null))
                {
                    Window wndTemp = this; // this.MainWindow;
                    
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.NextSibling;
 
                    this.cachedDetailsButton = new Button(wndTemp);
                }
                return this.cachedDetailsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContinueButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUnhandledExceptionsDialogControls.ContinueButton
        {
            get
            {
                if ((this.cachedContinueButton == null))
                {
                    Window wndTemp = this; // this.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedContinueButton = new Button(wndTemp);
                }
                return this.cachedContinueButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QuitButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUnhandledExceptionsDialogControls.QuitButton
        {
            get
            {
                if ((this.cachedQuitButton == null))
                {
                    Window wndTemp = this; // this.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedQuitButton = new Button(wndTemp);
                }
                return this.cachedQuitButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StackTraceTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IUnhandledExceptionsDialogControls.StackTraceTextBox
        {
            get
            {
                if ((this.cachedStackTraceTextBox == null))
                {
                    Window wndTemp = this; // this.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedStackTraceTextBox = new TextBox(wndTemp);
                }
                return this.cachedStackTraceTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Details
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        ///		[KellyMor] 22-Jul-05 Disabled due to inability to get a control reference
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDetails()
        {
            // this.Controls.DetailsButton.Click();
            // parse the keyboard shortcut from the resource string
            // send a keyboard shortcut
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Continue
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickContinue()
        {
            this.Controls.ContinueButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Quit
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickQuit()
        {
            this.Controls.QuitButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Mom.Test.UI.Core.Console.MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        ///		[KellyMor] 21-Jul-05 Updated Init method attempts to find window
        ///							 Added logging statements
        ///		[KellyMor] 22-Jul-05 Changed method signature to take a Maui.Core.App
        ///							 Modified first attempt to find window to use app.MainWindow.Caption string
        ///     [KellyMor] 31-Aug-05 Added code to check for valid parent, parent window
        ///                          and parent window handle to catch window closing
        ///                          during this Window's initialization.
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // reference to the window
            Window tempWindow = null;

            // if the parent app is not null and it's handle is not null...
            if (null != app 
                && null != app.MainWindow
                && null != app.MainWindow.Extended.HWnd)
            {
                try
                {
                    // log the initial attempt
                    Utilities.LogMessage("UnhandledExceptionsDialog :: Looking for window with title:  '" + app.MainWindow.Caption + "'");

                    // Try to locate an existing instance of a dialog
                    tempWindow = new Window(
                        app.MainWindow.Caption,
                        StringMatchSyntax.ExactMatch);

                    // check to see if it found the parent window instead, can happen with identical titles
                    if (tempWindow.Extended.HWnd == app.MainWindow.Extended.HWnd)
                    {
                        // if we did, throw a WindowNotFoundException and try again
                        throw new Exceptions.WindowNotFoundException("Found parent window, NOT unhandled exceptions dialog!");
                    }
                }
                catch (Exceptions.WindowNotFoundException ex)
                {
                    // log message about failure of first attempt
                    Utilities.LogMessage("UnhandledExceptionsDialog :: Window not found on first attempt, widening search paramters...");

                    // log message on start of search attempts
                    Utilities.LogMessage("UnhandledExceptionsDialog :: Looking for window matching title:  '" + app.GetIntlStr(Strings.DialogTitle) + "*'");

                    // initialize loop variables
                    tempWindow = null;
                    int numberOfTries = 0;
                    const int MaxTries = 5;

                    // while the window reference is null and we haven't exceeded the maximum number of attempts...
                    while (tempWindow == null && numberOfTries < MaxTries)
                    {
                        // increment the number of search attempts
                        numberOfTries++;
                        try
                        {
                            // look for the window again using wildcards
                            tempWindow =
                                new Window(
                                    app.GetIntlStr(Strings.DialogTitle) + "*",
                                    StringMatchSyntax.WildCard);

                            // wait for the window to report ready
                            UISynchronization.WaitForUIObjectReady(
                                tempWindow,
                                Timeout);
                        }
                        catch (Exceptions.WindowNotFoundException)
                        {
                            Utilities.LogMessage("UnhandledExceptionsDialog :: Attempt:  " + numberOfTries + " of " + MaxTries);
                        }
                    }

                    // check for success
                    if (tempWindow == null)
                    {
                        // log the failure
                        Utilities.LogMessage("UnhandledExceptionsDialog :: " + ex.Message);

                        // throw the existing WindowNotFound exception
                        throw;
                    }
                    //\ check to see if this is also the parent window
                    else if (tempWindow.Extended.HWnd == app.MainWindow.Extended.HWnd)
                    {
                        // throw the existing WindowNotFound exception
                        throw;
                    }
                }

                // return the window
                return tempWindow;
            }
            else
            {
                /* throw an ArgumentNullException
                 * if app is null, add text for it
                 * else check if the MainWindow handle is null, add text for it
                 * else add text for the window handle value
                 */
                throw new System.ArgumentNullException("Application reference or window handle are null:  " +
                    (null == app ? "App := NULL" : (null == app.MainWindow ? "App.MainWindow == NULL" : "Window handle:  " + app.MainWindow.Extended.HWnd)));
            }
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resources strings class.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 20-Jul-05 Created
        ///		[KellyMor] 21-Jul-05 Updated resource strings
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
            /// <history>
            ///		[KellyMor] 21-Jul-05 This is essentially what we're using in the parent app
            ///							 When the parent app is updated, this will be updated
            /// </history>
            /// -----------------------------------------------------------------------------
            [Obsolete("Don't use ResourceDialogTitle, use ConsoleApp.Strings.DIalogTitle instead", true)]
            private const string ResourceDialogTitle = "Microsoft Operations Manager 2005*";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UnhandledExceptionHasOccurredText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUnhandledExceptionHasOccurredText = ";Unhandled exception has occurred in your application. If you click Continue, the application will ignore this error and attempt to continue. If you click Quit, the application will close immediately.\r\n{0}.;ManagedString;system.windows.forms.dll;System.Windows.Forms;ExDlgErrorText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Details
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDetails = ";&Details;ManagedString;system.windows.forms.dll;System.Windows.Forms;ExDlgShowDetails";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Continue
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContinue = ";&Continue;ManagedString;system.windows.forms.dll;System.Windows.Forms;ExDlgContinue";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Quit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceQuit = ";&Quit;ManagedString;system.windows.forms.dll;System.Windows.Forms;ExDlgQuit"; // "&Quit";
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
            /// Caches the translated resource string for:  UnhandledExceptionHasOccurredText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUnhandledExceptionHasOccurredText;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Details
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Continue
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContinue;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Quit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedQuit;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = ConsoleApp.Strings.DialogTitle;
                    }
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UnhandledExceptionHasOccurredText translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UnhandledExceptionHasOccurredText
            {
                get
                {
                    if ((cachedUnhandledExceptionHasOccurredText == null))
                    {
                        cachedUnhandledExceptionHasOccurredText = CoreManager.MomConsole.GetIntlStr(ResourceUnhandledExceptionHasOccurredText);
                    }
                    return cachedUnhandledExceptionHasOccurredText;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Details translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Details
            {
                get
                {
                    if ((cachedDetails == null))
                    {
                        cachedDetails = CoreManager.MomConsole.GetIntlStr(ResourceDetails);
                    }
                    return cachedDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Continue translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Continue
            {
                get
                {
                    if ((cachedContinue == null))
                    {
                        cachedContinue = CoreManager.MomConsole.GetIntlStr(ResourceContinue);
                    }
                    return cachedContinue;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Quit translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 20-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Quit
            {
                get
                {
                    if ((cachedQuit == null))
                    {
                        cachedQuit = CoreManager.MomConsole.GetIntlStr(ResourceQuit);
                    }
                    return cachedQuit;
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
        /// 	[KellyMor] 20-Jul-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            // no control IDs, form is unmanaged C/C++
        }
        #endregion
    }

    #region Interface Definition - ISystemCenterErrorDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISystemCenterErrorDialogControls, for SystemCenterErrorDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-lileo] 1/24/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISystemCenterErrorDialogControls
    {
        /// <summary>
        /// Gets read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
    }
    #endregion

    public partial class SystemCenterErrorDialog : Dialog, ISystemCenterErrorDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the SystemCenterErrorDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of SystemCenterErrorDialog of type App
        /// </param>
        /// <history>
        ///   [v-lileo] 1/24/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SystemCenterErrorDialog(App app, int timeout) :
            base(app, Init(app, timeout))
        {
        }
        #endregion

        #region ISystemCenterErrorDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-lileo] 1/24/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISystemCenterErrorDialogControls Controls
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
        ///  Gets access to the CloseButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/24/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISystemCenterErrorDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, SystemCenterErrorDialog.QueryIds.CloseButton);
                }

                return this.cachedCloseButton;
            }
        }

        #endregion

        #region Click Methods
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/24/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
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
        ///   [v-lileo] 1/24/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(new QID(";[UIA]AutomationId='_window' && Role = 'window'"), timeout);
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

        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [asttest] 1/24/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCloseButton = ";[UIA]Name = 'Close' && Role = 'push button'";

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CloseButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/24/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CloseButton
            {
                get
                {
                    return new QID(ResourceCloseButton);
                }
            }
            #endregion
        }
        #endregion
    }
}
