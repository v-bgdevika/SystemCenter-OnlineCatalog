// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConsoleApp.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  Base Console Application Class.  Should only inhert from.
// </project>
// <summary>
//  Base ConsoleApp Class.
// </summary>
// <history>
//  [mbickle]  11JUL05: Created
//  [KellyMor] 22JUL05 Added method to handle unhandled exceptions.
//  [mbickle]  08AUG05 Added WaitForStatusReady and WaitForStatusText methods.
//  [KellyMor] 22AUG05 Added string resources for System "Yes" and "No" 
//                     buttons
//  [KellyMor] 07SEP05 Added support for SOM Diagram
//  [KellyMor] 08SEP05 Addes support for ViewToolbar
//  [KellyMor] 09SEP05 Moved SomDiagram from ConsoleApp to ViewPane
//                     Changed ViewToolbar properties to return ViewToolbar instead of
//                     Toolbar.
//  [barryw]   11SEP05 Added GetWizardDialog to help reduce duplicate code in
//                     dialog classes.
//  [KellyMor] 12SEP05 Modified check for unhandled exceptions to also look
//                     for Watson crash/debug dialog and dismiss it.
//  [mbickle]  13SEP05 Added call in UpdateParameters to Turn off the DrWatson UI.
//  [KellyMor] 17SEP05 Added catch blocks for invalid window handle
//  [kellymor] 19SEP05 Added call to close Maui TextLog trace log
//  [kellymor] 23SEP05 Added support for Diagram and Alert view toolbars
//  [KellyMor] 17NOV05 Modified dialog title check to use SkuExe
//                     per code review
//  [ruhim]    21NOV05 Added SelectListViewItems to select a particular ListView Item
//                     from a specified Column Position  
//  [faizalk]  27MAR06 Change TaskPane to ActionsPane 
//  [faizalk]  22MAY06 Increase Quit timeout from 1 minute to 2 minutes to prevent BVT failures
//  [kellymor] 13APR07 Modified DiagramViewToolBar property to use new reference each time
//  [kellymor] 26SEP07 Modified resource strings for Yes/No to common string for all OS and
//                     platforms:  WinXP/Win2K3 (32 & 64 bit), Vista/Longhorn (32 & 64 bit)
//  [ruhim]    01JAN08 Modified resource string for OK to common string for all OS and
//                     platforms:  WinXP/Win2K3 (32 & 64 bit), Vista/Longhorn (32 & 64 bit)
//  [nathd]    08JUL08 Created a new SelectListViewItems method that takes an additional parameter. 
//                     The additional parameter is a bool that determines whether the method does 
//                     an exact match or substring match. The original SelectListViewItems method
//                     now calls the new method to do a substring match.
//  [a-omkasi] 16JUL08 Added an Overloaded method for SelectListViewItem which takes additional parameters
//                     to customize the Selection process.
//  [a-omkasi] 16JUL08 Added an new method GetMatchingListViewItemsCount to get an integer count of the 
//                     number of ListView items which Match the search string.
//  [v-waltli] 09APR09 Added Manual Agent Install dialog buttons string definitions
//  [v-waltli] 17JUL09 Updated searching confirm dialog title with wildcard match 
//                     added clicking title bar to close the dialog if the dialog is still foreground
//                     and reduced wait for dialog to close time from 60 seconds to 15 seconds
//                     in method CancelDialogWindow
//                     Added new method CloseChildDialogWindows to close all child dialog windows in Mom Console
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Reflection;
    using Maui.Core;
    using Maui.Core.Resources; //not foubnd
    using Maui.Core.Utilities; //not foubnd
    using Maui.Core.WinControls; //not foubnd
    using Maui.GlobalExceptions; //not foubnd
    using Microsoft.EnterpriseManagement.Test.FrmwrkCommon;
    using Microsoft.EnterpriseManagement.Test.ScCommon;
    using Mom.Test.UI.Core.Common;
    using ResourceManager;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;
    #endregion

    #region Interface Definition - IConsoleAppControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConsoleAppControls, for ConsoleApp.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 13JUL05 Created
    ///     [kellymor]23SEP05 Added interface properties for Alert and Diagram view
    ///                       Toolbars
    ///     [a-joelj] 28DEC09 Added interface properties for the common Find/Scope/Actions ToolbarItems
    ///                       contained in the ConsoleToolBarCommandBar in every space
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConsoleAppControls
    {
        /// <summary>
        /// Read-only property to access Toolbar
        /// </summary>
        Toolbar Toolbar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConsoleToolBarCommandBar
        /// </summary>
        Toolbar ConsoleToolBarCommandBar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConsoleToolBarItemFind ToolbarItem
        /// </summary>
        ToolbarItem ConsoleToolBarItemFind
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConsoleToolBarItemScope ToolbarItem
        /// </summary>
        ToolbarItem ConsoleToolBarItemScope
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ConsoleToolBarItemActions ToolbarItem
        /// </summary>
        ToolbarItem ConsoleToolBarItemActions
        {
            get;
        }

        /// <summary>
        /// Read-only property to access StatusBar
        /// </summary>
        MomControls.ConsoleStatusBar StatusBar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NavigationPane
        /// </summary>
        NavigationPane NavigationPane
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ActionsPane
        /// </summary>
        ActionsPane ActionsPane
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DetailPane
        /// </summary>
       DetailPane DetailPane
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewPane
        /// </summary>
      ViewPane ViewPane
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Diagram View Toolbar
        /// </summary>
        MomControls.ViewToolbar ViewToolbar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Diagram View Toolbar
        /// </summary>
        MomControls.IDiagramViewToolbar DiagramViewToolbar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Alert View Toolbar
        /// </summary>
        MomControls.IAlertViewToolbar AlertViewToolbar
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Base class for common functionality between Desktop, Web and SharePoint consoles
    /// </summary>
    /// <history>
    /// 	[mbickle]  09MAR05 Created
    ///		[KellyMor] 22JUL05 Added method to handle unhandled exceptions.
    ///		[KellyMor] 22AUG05 Added string resources for System "Yes" and "No" 
    ///						   buttons
    ///     [KellyMor] 07SEP05 Added support for SOM Diagram
    ///     [KellyMor] 08SEP05 Added support for ViewToolbar
    ///     [KellyMor] 09SEP05 Moved SomDiagram from ConsoleApp to ViewPane
    ///                        Changed ViewToolbar properties to return ViewToolbar instead of
    ///                        Toolbar.
    ///     [KellyMor] 12SEP05 Modified check for unhandled exceptions to also look
    ///                        for Watson crash/debug dialog and dismiss it.
    ///     [KellyMor] 17SEP05 Added catch blocks for invalid window handle
    ///     [kellymor] 19SEP05 Added call to close Maui TextLog trace log
    ///     [a-joelj]  28DEC09 Added new private member variables, public properties and Click routines for
    ///                        the common Find/Scope/Actions ToolbarItems (ConsoleToolBarItemFind, 
    ///                        ConsoleToolBarItemScope and ConsoleToolBarItemActions)
    ///     [billhodg] 21MAY10 Added Browser support
    /// </history>
    /// -----------------------------------------------------------------------------
    public abstract class ConsoleApp : App, IConsoleAppControls
    {

        #region Public Enumerator Section
        /// <summary>
        /// StringMatchAt- Enumerator for search string matching position
        /// <history>
        ///     [a-omkasi] 25AUG08 Created
        /// </history>
        /// </summary>
        public enum StringMatchAt
        {
            /// <summary>
            /// Begins With -- When the target string begins with search string
            /// </summary>
            BeginsWith,

            /// <summary>
            /// Ends With -- When the target string ends with the search string
            /// </summary>
            EndsWith,

            /// <summary>
            /// Contains -- When the target string contins search string
            /// </summary>
            Constains,

            /// <summary>
            /// ExactMatch -- When the target string equals the search string
            /// </summary>
            ExactMatch
        }
        #endregion

        #region Public Constants

        /// <summary>
        /// Loop duration in approximate seconds used by 
        /// wait for a control to be enabled methods.
        /// </summary>
        //public const int FiveSeconds = 5;

        /// <summary>
        /// Loop duration in approximate seconds used by 
        /// wait for a window to be enabled methods.
        /// TODO: Consider Moving this Waiters class
        /// </summary>
        //public const int TenSeconds = 10;

        #endregion
        
        #region Protected Internal Variables

        //// <summary>
        //// Cache to hold a reference to the active window of type Maui.Core.Window
        //// </summary>
        ////protected internal static Window activeWindow;

        #endregion

        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        /// <summary>
        /// StatusBarText Timeout Value: 60Seconds
        /// </summary>
        private const int StatusTimeout = 60000;
        
        /// <summary>
        /// Loop delay in milliseconds used by 
        /// wait for a control to be enabled methods.
        /// </summary>
        private const int DelayOneSecond = 1000;

        #endregion

        #region Private Member Variables
        /// <summary>
        /// Cached Url to the IIS server for the web console
        /// </summary>
        private static string webServerUrl = null;

        /// <summary>
        /// Resource Cache Hashtable.  
        /// Holds all Resources extracted, for faster look up.
        /// </summary>
        private Hashtable resourceCache = new Hashtable();

        /// <summary>
        /// Cache to hold a reference to Toolbar of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar;

        /// <summary>
        /// Cache to hold a reference to ConsoleToolBarCommandBar of type Toolbar
        /// </summary>
        private Toolbar cachedConsoleToolBarCommandBar;

        /// <summary>
        /// Cache to hold a reference to ConsoleToolBarItemFind of type ToolbarItem
        /// </summary>
        private ToolbarItem cachedConsoleToolBarItemFind;

        /// <summary>
        /// Cache to hold a reference to ConsoleToolBarItemScope of type ToolbarItem
        /// </summary>
        private ToolbarItem cachedConsoleToolBarItemScope;

        /// <summary>
        /// Cache to hold a reference to ConsoleToolBarItemActions of type ToolbarItem
        /// </summary>
        private ToolbarItem cachedConsoleToolBarItemActions;

        /// <summary>
        /// Cache to hold a reference to StatusBar of type StatusBar
        /// </summary>
        private MomControls.ConsoleStatusBar cachedStatusBar;

        /// <summary>
        /// Cache to hold a reference to view toolbar
        /// </summary>
        private MomControls.ViewToolbar cachedViewToolbar;

        /// <summary>
        /// Waiters
        /// </summary>
        private Waiters waiters;

        /// <summary>
        /// Holds the current File Name to get a resource from.
        /// used in AssemblyResolveCallback to determine directory
        /// to search.
        /// </summary>
        private string resourceFileNamePath = string.Empty;

        /// <summary>
        /// If we are looking at a web or SharePoint console we cache the web browser session
        /// </summary>
        private Browser cachedBrowser;
        #endregion

        #region Constructors

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of Console
        /// </summary>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 03AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public ConsoleApp()
            : base(Init())
        {
            
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of Console with Command Line arguments
        /// </summary>
        /// <param name="arguments">Arguments to pass to EXE</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 03AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public ConsoleApp(string arguments)
            : base(Init(arguments))
        {
             
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of Console with Command Line arguments
        /// </summary>
        /// <param name="parameters">Application start parameters</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 03AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public ConsoleApp(ConsoleAppParameters parameters)
            : base(Init(parameters))
        {
            
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Attach to running UI via passing ProcessId
        /// </summary>
        /// <param name="procId">Process Id of UI</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 09MAR05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public ConsoleApp(int procId) : base(procId)
        {
            
        }
        #endregion

        #region Enums

        /// <summary>
        /// Buttons on a pop-up dialog
        /// </summary>
        public enum ButtonCaption : int
        {
            /// <summary>
            /// Ok button
            /// </summary>
            OK,

            /// <summary>
            /// Cancel button
            /// </summary>
            Cancel,

            /// <summary>
            /// Yes button
            /// </summary>
            Yes,

            /// <summary>
            /// No button
            /// </summary>
            No,
            /// <summary>
            /// Approve button
            /// </summary>
            Approve,

            /// <summary>
            /// Reject button
            /// </summary>
            Reject
        }

        /// <summary>
        /// Actions to take when a window is not found,
        /// used for the conditional presence of pop-up
        /// dialogs.
        /// </summary>
        public enum ActionIfWindowNotFound
        {
            /// <summary>
            /// Ignore the result of the search.
            /// </summary>
            Ignore,

            /// <summary>
            /// Throw the exception for a window not found.
            /// </summary>
            Error
        }

        #endregion // Enums

        #region Properties

        #region Public static properties section

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Path to the UI Console
        /// web and sharepoint paths return null
        /// </summary>
        /// <returns>Path to ConsoleExe</returns>
        /// <history>
        ///     [mbickle] 13JUL05: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static string ConsolePath
        {
            get
            {
                string path = null;
                if (ProductSkuLevel.Mom == ProductSku.Sku)
                {
                    path = Utilities.MomPathConsole + ProductSku.SkuExe;
                }
                //web and sharepoint paths return null
                return path;
            }
        }

        /// <summary>
        /// Returns the URL of the first IIS web client host that is found in the test topology
        /// throws a WebException if no IIS server could be found with the web client
        /// </summary>
        public static string WebServerUrl
        {
            get
            {
                return Utilities.GetWebConsoleURL();
            }
        }
        #endregion

        #region Public non-static properties section

        /// ------------------------------------------------------------------
        /// <summary>
        /// Actions Pane
        /// </summary>
        /// ------------------------------------------------------------------
        public ActionsPane ActionsPane
        {
            get
            {
                return new ActionsPane(this);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// NavigationPane Pane
        /// [v-dayow]    05JAN10   Changed to fix #163476.
        /// </summary>
        /// ------------------------------------------------------------------
        public NavigationPane NavigationPane
        {
            get
            {
                NavigationPane nav = null;
                int maxRetry = 5;
                int loop = 0;
                while ((nav == null) && (loop++ < maxRetry))
                {
                    try
                    {
                        nav = new NavigationPane(this);
                    }

                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                    }

                    catch (System.ArgumentOutOfRangeException)
                    {
                        Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                    }
                }
                return nav;

            }

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// View Pane
        /// </summary>
        /// ------------------------------------------------------------------
        public ViewPane ViewPane
        {
            get
            {
                return new ViewPane(this);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Detail Pane
        /// </summary>
        /// ------------------------------------------------------------------
        public DetailPane DetailPane
        {
            get
            {
                return new DetailPane(this);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Access to Waiter Methods
        /// </summary>
        /// ------------------------------------------------------------------
        public Waiters Waiters
        {
            get
            {
                if (null == this.waiters)
                {
                    this.waiters = new Waiters();
                }

                return this.waiters;
            }
        }

        /// <summary>
        /// Get the browser associated with the current application
        /// </summary>
        public Browser Browser
        {
            get
            {
                if (cachedBrowser == null)
                {
                    cachedBrowser = new Browser();
                    cachedBrowser.Find(((App)this), cachedBrowser.PageLoadWaitTime);
                }
                return cachedBrowser;
            }
            set 
            { 
                cachedBrowser = value; 
            }
        }
        #endregion

        #endregion

        #region IConsoleApp Controls Property

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this app. window
        /// </summary>
        /// <value>An interface that groups all of the app. window's control properties together</value>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public virtual IConsoleAppControls Controls
        {
            get
            {
                return this;
            }
        }
        
        #endregion

        #region Control Properties section

        #region Public non-static properties section

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the View Toolbar
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.ViewToolbar ViewToolbar
        {
            get
            {
                //if ((this.cachedViewToolbar == null))
                //{
                    this.cachedViewToolbar =
                        new MomControls.ViewToolbar(this);
                //}

                return this.cachedViewToolbar;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Diagram View Toolbar
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.IDiagramViewToolbar DiagramViewToolbar
        {
            get
            {
                //if ((this.cachedViewToolbar == null))
                //{
                    this.cachedViewToolbar =
                        new MomControls.ViewToolbar(this);
                //}

                return (MomControls.IDiagramViewToolbar)this.cachedViewToolbar;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Alert View Toolbar
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.IAlertViewToolbar AlertViewToolbar
        {
            get
            {
                //if ((this.cachedViewToolbar == null))
                //{
                    this.cachedViewToolbar =
                        new MomControls.ViewToolbar(this);
                //}

                return (MomControls.IAlertViewToolbar)this.cachedViewToolbar;
            }
        }

        #endregion

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Toolbar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        Toolbar IConsoleAppControls.Toolbar
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                    return null;

                if ((this.cachedToolbar == null))
                {
                    this.cachedToolbar = new MomControls.MainToolbar(this);                    
                }

                return this.cachedToolbar;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConsoleToolBarCommandBar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        Toolbar IConsoleAppControls.ConsoleToolBarCommandBar
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                    return null;

                if ((this.cachedConsoleToolBarCommandBar == null))
                {
                    //QID toolbarQid = new QID(";[UIA] Name='" + Strings.ConsoleToolBarCommandBar + "'");

                    QID toolbarQid = new QID(";[UIA, VisibleOnly] Role = 'tool bar'&& Instance = '2'");
                    Window windowTemp = new Window(toolbarQid, Mom.Test.UI.Core.Common.Constants.DefaultViewLoadTimeout);
                    //Window windowTemp = new Window(Strings.ConsoleToolBarCommandBar, StringMatchSyntax.ExactMatch);
                    this.cachedConsoleToolBarCommandBar = new Toolbar(windowTemp);
                }

                return this.cachedConsoleToolBarCommandBar;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConsoleToolBarItemFind ToolbarItem control
        /// </summary>
        /// <history>
        ///     [a-joelj]   28DEC09 Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IConsoleAppControls.ConsoleToolBarItemFind
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                    return null;

                if ((this.cachedConsoleToolBarItemFind == null))
                {
                    this.cachedConsoleToolBarItemFind = 
                       new ToolbarItem(
                            this.Controls.ConsoleToolBarCommandBar, 
                            ConsoleApp.Strings.ConsoleToolBarItemFind);
                }

                return this.cachedConsoleToolBarItemFind;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConsoleToolBarItemScope ToolbarItem control
        /// </summary>
        /// <history>
        ///     [a-joelj]   28DEC09 Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IConsoleAppControls.ConsoleToolBarItemScope
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                    return null;

                if ((this.cachedConsoleToolBarItemScope == null))
                {
                    this.cachedConsoleToolBarItemScope = 
                        new ToolbarItem(
                            this.Controls.ConsoleToolBarCommandBar, 
                            ConsoleApp.Strings.ConsoleToolBarItemScope);
                }

                return this.cachedConsoleToolBarItemScope;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConsoleToolBarItemActions ToolbarItem control
        /// </summary>
        /// <history>
        ///     [a-joelj]   28DEC09 Created
        /// </history>
        /// ------------------------------------------------------------------
        ToolbarItem IConsoleAppControls.ConsoleToolBarItemActions
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                    return null;

                if ((this.cachedConsoleToolBarItemActions == null))
                {
                    this.cachedConsoleToolBarItemActions = 
                        new ToolbarItem(
                            this.Controls.ConsoleToolBarCommandBar, 
                            ConsoleApp.Strings.ConsoleToolBarItemActions);
                }

                return this.cachedConsoleToolBarItemActions;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusBar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        MomControls.ConsoleStatusBar IConsoleAppControls.StatusBar
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                    return null;

                if ((this.cachedStatusBar == null))
                {
                    this.cachedStatusBar = new MomControls.ConsoleStatusBar(this);
                }

                return this.cachedStatusBar;
            }
        }

        #endregion

        #region Public Static Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Sets registry key necessary to display the UITest MP by default 
        /// in the Monitoring space.  This is needed by all MOM Monitoring 
        /// space UI Tests.
        /// </summary>
        /// <history>
        ///     [mbickle] 25FEB06 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void SetUITestMPVisible()
        {
            if (ProductSku.Sku != ProductSkuLevel.Mom) return;

            string regKeyPath;
            string navigationPath = @"Console\Navigation\NavigationFolderPreferences\";
            string momRegKeyPath = Constants.MomHKCURegistryPath + "\\" + Constants.MomVersion + "\\" + navigationPath;
            string mpname = String.Concat(Constants.UITestMPGuid, "!", Constants.UITestViewFolder);
            ////"e89a0934-f1fe-ca83-bfa7-438df623800d!UITest";

            Microsoft.Win32.RegistryKey regKey = null;

            regKeyPath = momRegKeyPath + Utilities.ManagementGroupName + "\\" + mpname;

            Utilities.LogMessage("ConsoleApp.SetUITestMPVisible:: Setting UITest MP to be visible:" + regKeyPath);

            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPath, true);
            if (regKey == null)
            {
                Utilities.LogMessage("ConsoleApp.SetUITestMPVisible:: Creating regKeyPath: " + regKeyPath);
                regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(regKeyPath);
            }

            if (regKey != null)
            {
                Utilities.LogMessage("ConsoleApp.SetUITestMPVisible:: Setting KeyValues");
                regKey.SetValue("Display Name", "UITest", Microsoft.Win32.RegistryValueKind.String);
                regKey.SetValue("IsVisible", 1, Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Resets the Console to Default Settings.  
        /// Deletes: HKCU\Software\Microsoft\Microsoft Operations Manager\3.0 if MOM
        /// Deletes: HKCU\Software\Microsoft\Microsoft System Center Essentials\1.0 if SCE
        /// </summary>
        /// <history>
        /// [mbickle] 06AUG05 Created
        /// [mbickle] 02MAR06 Moved from Common.Utilities to ConsoleApp.
        ///                   Added support to handle SCE/MOM Skus
        /// </history>
        /// ------------------------------------------------------------------
        public static void ResetConsoleSettings()
        {
            string regKeyPath;
            string regSubKey;
            Microsoft.Win32.RegistryKey regKey = null;

            if (ProductSku.Sku != ProductSkuLevel.Mom)
                return;

            Utilities.LogMessage("ConsoleApp.ResetConsoleSettings:: Resetting Console to Default settings.");

            
                    regKeyPath = Constants.MomHKCURegistryPath;
                    regSubKey = Constants.MomVersion;
                  

            // Checks to see if we can access RegKeyPath and if so, delete it.
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPath, true);
            if (regKey != null)
            {
                Utilities.LogMessage("ConsoleApp.ResetConsoleSettings:: Deleting RegKey: " + regKeyPath + "\\" + regSubKey);
                try
                {
                    regKey.DeleteSubKeyTree(regSubKey);
                }
                catch (System.ArgumentException)
                {
                    Utilities.LogMessage("ConsoleApp.ResetConsoleSettings:: No key to delete, already deleted");
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Resets the Console to Default Settings.  
        /// Deletes: HKCU\regKeyPath\regSubKey
        /// </summary>
        /// <param name="regKeyPath">HKCU Registry Path</param>
        /// <param name="regSubKey">SubKey to delete.</param>
        /// <history>
        /// [v-kayu] 18Nov09 added
        /// </history>
        /// <example>
        /// // Deletes Operations Manager v3.0 HKCU key.
        /// ResetConsoleSettings("Software\Microsoft\Microsoft Operations Manager", "3.0") 
        /// </example>
        /// ------------------------------------------------------------------
        public static void ResetConsoleSettings(string regKeyPath, string regSubKey)
        {
            if (ProductSku.Sku != ProductSkuLevel.Mom)
                return;

            Microsoft.Win32.RegistryKey regKey = null;

            Utilities.LogMessage("ConsoleApp.ResetConsoleSettings:: Resetting Console to Default settings.");

            // Checks to see if we can access RegKeyPath and if so, delete it.
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPath, true);
            if (regKey != null)
            {
               
                Utilities.LogMessage("ConsoleApp.ResetConsoleSettings:: Deleting RegKey: " + regKeyPath + "\\" + regSubKey);
                try
                {
                    regKey.DeleteSubKeyTree(regSubKey);
                }
                catch (System.ArgumentException)
                {
                    Utilities.LogMessage("ConsoleApp.ResetConsoleSettings:: No key to delete, already deleted");
                }
            }
        }
        
#endregion

        #region Public Methods
        #region Message Box Helper Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to answer a confirmation dialog by clicking "Yes" or "No".
        /// </summary>
        /// <param name="confirm">A boolean indicating "Yes" or "No"</param>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Can't find dialog window or button
        /// </exception>
        /// <history>
        ///     [KellyMor] 01AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public void ConfirmChoiceDialog(bool confirm)
        {
            this.ConfirmChoiceDialog(confirm, "*");            
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to answer a confirmation dialog by clicking "Yes" or "No" on
        /// the dialog specified by the title string.
        /// </summary>
        /// <param name="confirm">A boolean indicating "Yes" or "No"</param>
        /// <param name="dialogTitle">Title string for the dialog window</param>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Can't find dialog window or button
        /// </exception>
        /// <history>
        ///     [KellyMor]  01AUG05 Created
        ///     [KellyMor]  17NOV05 Removed finaly block per code review
        ///                         Updated logging to conform to standard
        ///     [nathd]     25SEP09 Maui 2.0: Window constructor behavior change... if the caller passes in a Null or Empty
        /// 	                    dialogTitle we overwrite it with a wildcard character '*' to give the caller the expected
        /// 	                    behavior when doing a WildCardMatch. See comment below for more details.
        /// </history>
        /// ------------------------------------------------------------------
        public void ConfirmChoiceDialog(bool confirm, string dialogTitle)
        {
            Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: Looking for dialog with title:  '" + dialogTitle + "'");

            Maui.Core.Window dialogWindow = null;

            // [nathd] - Maui 2.0: Looks like the Window constructor behaves differently in Maui 2.0 than in 1.0...
            // In Maui 2.0, if the dialogTitle passed in is an empty string then you will not get a match *unless*
            // the dialog title is really an empty string. In Maui 1.0, if the dialogTitle was an empty string and 
            // the caller passed in the StringMatchSyntax.WildCard for dialog/caption match Maui would match any 
            // dialog title. The new behavior is the correct behavior. Our work-around: We now test to see if the 
            // dialogTitle is empty and if so we set it to "*".
            if (String.IsNullOrEmpty(dialogTitle))
            {
                Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: dialogTitle provided by the caller is Null or Empty...");
                Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: Setting the dialogTitle to '*'");
                dialogTitle = "*";
            }

            try
            {
                Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: Creating a window to handle the dialog...");

                // get the dialog window
                dialogWindow = new Maui.Core.Window(
                    dialogTitle,
                    Maui.Core.Utilities.StringMatchSyntax.WildCard,
                    WindowClassNames.Dialog,
                    Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                    this,
                    2000);
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Core.Common.Utilities.LogMessage(
                    "ConfirmChoiceDialog :: Not found on first attempt, trying again...");

                // set loop values
                int attempts = 0;
                int maxAttempts = 5;

                // wait and look for the window 
                while (dialogWindow == null && attempts < maxAttempts)
                {
                    attempts++;
                    try
                    {
                        dialogWindow =
                            new Maui.Core.Window(
                                dialogTitle,
                                StringMatchSyntax.WildCard);

                        if (String.IsNullOrEmpty(dialogWindow.Caption))
                        {
                            Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: Get wrong window, reset it to null and will try again ");
                            dialogWindow = null;

                            // delay for three seconds before trying again.
                            Maui.Core.Utilities.Sleeper.Delay(
                                Core.Common.Constants.OneSecond * 3);
                        }
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Core.Common.Utilities.LogMessage(
                            "ConfirmChoiceDialog :: Attempt " +
                            attempts +
                            " of " +
                            maxAttempts);

                        // delay for three seconds before trying again.
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond * 3);
                    }
                }

                if (dialogWindow == null)
                {
                    throw;
                }
            }

            // check to see if we found the window
            if (dialogWindow != null)
            {
                // create the corresponding button and click it
                Maui.Core.WinControls.Button button = null;
                string caption = null;

                if (confirm == true)
                {
                    // use the "Yes" button
                    caption = Core.Console.ConsoleApp.Strings.SystemYesButton;
                    Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: Looking for a 'Yes' button with caption:  '" + caption);
                }
                else
                {
                    // use the "No" button
                    caption = Core.Console.ConsoleApp.Strings.SystemNoButton;
                    Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: Looking for a 'No' button with caption:  '" + caption);
                }

                Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: Creating a button on window:  '" + dialogWindow.Caption + "'");

                int retry = 0;
                while (retry < 5 )
                {
                    try
                    {
                        // create button
                        button = new Maui.Core.WinControls.Button(
                                    dialogWindow,
                                    caption,
                                    Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                                    Maui.Core.WindowClassNames.Button,
                                    Maui.Core.Utilities.StringMatchSyntax.ExactMatch);                        
                        break;
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        retry++;
                        Core.Common.Utilities.LogMessage("ConfirmChoiceButton :: Not found on " + retry.ToString() + " attempt, trying again...");
                        Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                    }
                }
                if (button != null)
                {
                    // Click button
                    button.Click();
                }
                else
                {
                    throw new Maui.Core.Window.Exceptions.WindowNotFoundException("Failed to find button with title '" + (confirm ? "Yes" : "No") + "'");
                }
            }
            else
            {
                throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                    "Failed to find dialog with title '" + dialogTitle + "'");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to search for and answer a message dialog by clicking "OK".
        /// </summary>
        /// <param name="buttonCaption">OK, Cancel, Yes button caption.</param>
        /// <param name="dialogTitle">Title string for the dialog window</param>
        /// <param name="dialogTitleMatchSyntax">Matching method including for retries, e.g., Exact match (recommended)</param>
        /// <param name="action">What action to take if the dialog is not found, e.g., Ignore.</param>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">Can't find dialog window or button</exception>
        /// <history>
        /// 	[barryw]    21JAN06 Added support for 'No' button.
        /// 	[v-waltli]  09APR09 Added support for Manual Agent Install dialog buttons
        /// 	                    If button not found by calss name as ExactMatch, then find again by class name as WildCard
        /// 	[nathd]     25SEP09 Maui 2.0: Window constructor behavior change... if the caller passes in a Null or Empty
        /// 	                    dialogTitle we overwrite it with a wildcard character '*' to give the caller the expected
        /// 	                    behavior when doing a WildCardMatch. See comment below for more details.
        /// </history>
        /// ------------------------------------------------------------------
        public void ConfirmChoiceDialog(
            ButtonCaption buttonCaption,
            string dialogTitle,
            StringMatchSyntax dialogTitleMatchSyntax,
            MomConsoleApp.ActionIfWindowNotFound action)
        {
            // Timeout value to wait for dialog.
            int timeout = 5000;            

            Utilities.LogMessage("ConfirmChoiceDialog :: " +
                "Looking for dialog with title:  '" + dialogTitle + "'");

            switch (dialogTitleMatchSyntax)
            {
                case StringMatchSyntax.ExactMatch:
                    Utilities.LogMessage("ConfirmChoiceDialog :: " +
                    "Searching using an exact match on the title");
                    break;
                case StringMatchSyntax.RegularExpression:
                    Utilities.LogMessage("ConfirmChoiceDialog :: " +
                        "Searching using a regular expression on the title");
                    break;
                case StringMatchSyntax.WildCard:
                    Utilities.LogMessage("ConfirmChoiceDialog :: " +
                    "Searching using a wildcard match on the title");
                    // [nathd] - Maui 2.0: Looks like the Window constructor behaves differently in Maui 2.0 than in 1.0...
                    // In Maui 2.0, if the dialogTitle passed in is an empty string then you will not get a match *unless*
                    // the dialog title is really an empty string. In Maui 1.0, if the dialogTitle was an empty string and 
                    // the caller passed in the StringMatchSyntax.WildCard for dialog/caption match Maui would match any 
                    // dialog title. The new behavior is the correct behavior. Our work-around: We now test to see if the 
                    // dialogTitle is empty and if so we set it to "*".
                    if (String.IsNullOrEmpty(dialogTitle))
                    {
                        Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: dialogTitle provided by the caller is Null or Empty...");
                        Core.Common.Utilities.LogMessage("ConfirmChoiceDialog :: Setting the dialogTitle to '*'");
                        dialogTitle = "*";
                    }
                    break;
                default:
                    Utilities.LogMessage("ConfirmChoiceDialog :: " +
                        "Searching using an unknown type of match on the title");
                    break;
            }

            Window dialogWindow = null;
            try
            {
                Utilities.LogMessage("ConfirmChoiceDialog :: Creating a window to handle the dialog...");

                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        // get the dialog window
                        dialogWindow = new Maui.Core.Window(
                            dialogTitle,
                            dialogTitleMatchSyntax,
                            WindowClassNames.Dialog,
                            StringMatchSyntax.ExactMatch,
                            this,
                            timeout);   
                        break;
                    case ProductSkuLevel.Web:
                        QID dialogTitleQID = new QID(String.Format(ConsoleApp.Strings.WebConsoleDialogTitle, dialogTitle));
                        dialogWindow = new Window(dialogTitleQID, timeout);
                        break;
                    default:
                        break;
                }   
                      
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("ConfirmChoiceDialog :: " +
                    "Not found on first attempt, trying again...");
                
                // set loop values
                int attempts = 0;
                int maxAttempts = 5;

                // wait and look for the window 
                while (dialogWindow == null && attempts < maxAttempts)
                {
                    attempts++;
                    try
                    {
                        // get the dialog window
                        dialogWindow =
                             new Maui.Core.Window(
                                 dialogTitle,
                                 dialogTitleMatchSyntax);                   
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("ConfirmChoiceDialog :: " +
                            "Attempt " + attempts + " of " + maxAttempts);
                    }
                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                }
            }
            finally
            {
                // check to see if we found the window
                if (dialogWindow != null)
                {
                    // create the corresponding button and click it
                    Maui.Core.WinControls.Button button = null;
                    string caption = null;

                    switch (buttonCaption)
                    {
                        case ButtonCaption.OK:
                            {
                                // use the "OK" button
                                caption = ConsoleApp.Strings.SystemOKButton;
                                Utilities.LogMessage("ConfirmChoiceDialog :: " +
                                    "Looking for a 'OK' button with caption:  '" + caption);
                                try
                                {
                                    switch (ProductSku.Sku)
                                    {
                                        case ProductSkuLevel.Mom:
                                            button = new Maui.Core.WinControls.Button(
                                                           dialogWindow,
                                                           caption,
                                                           StringMatchSyntax.ExactMatch,
                                                           WindowClassNames.Button,
                                                           StringMatchSyntax.ExactMatch);
                                            break;
                                        case ProductSkuLevel.Web:
                                            button = new Button(dialogWindow, new QID(";[UIA]Name=\'" + caption + "\' && ClassName = 'Button'"), Constants.DefaultDialogTimeout);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                catch 
                                {
                                    // If button caption not localized , we use "OK" as caption
                                    caption = "OK";  
                                }
                                dialogWindow.SendKeys(KeyboardCodes.Tab);

                                break;
                            }

                        case ButtonCaption.Yes:
                            {
                                // use the "Yes" button
                                caption = ConsoleApp.Strings.SystemYesButton;
                                Utilities.LogMessage("ConfirmChoiceDialog :: " +
                                    "Looking for a 'Yes' button with caption:  '" + caption);
                                break;
                            }

                        case ButtonCaption.No:
                            {
                                // use the "No" button
                                caption = ConsoleApp.Strings.SystemNoButton;
                                Utilities.LogMessage("ConfirmChoiceDialog :: " +
                                    "Looking for a 'No' button with caption:  '" + caption);
                                break;
                            }

                        case ButtonCaption.Cancel:
                            {
                                // use the "Cancel" button  
                                caption = ConsoleApp.Strings.CancelButton;
                                Utilities.LogMessage("ConfirmChoiceDialog :: " +
                                    "Looking for a 'Cancel' button with caption:  '" + caption);
                                break;
                            }

                        case ButtonCaption.Approve:
                            {
                                // use the "Approve" button
                                caption = ConsoleApp.Strings.ApproveButton;
                                Utilities.LogMessage("ConfirmChoiceDialog :: " +
                                    "Looking for a 'Approve' button with caption:  '" + caption);
                                break;
                            }

                        case ButtonCaption.Reject:
                            {
                                // use the "ManualAgentInstallReject" button
                                caption = ConsoleApp.Strings.RejectButton;
                                Utilities.LogMessage("ConfirmChoiceDialog :: " +
                                    "Looking for a 'Reject' button with caption:  '" + caption);
                                break;
                            }

                        default:
                            {
                                throw new NotImplementedException();
                            }
                    }

                    Utilities.LogMessage("ConfirmChoiceDialog :: " +
                        "Creating a button on window" + dialogWindow.Caption + "'");

                    // create and click the button
                    try
                    {
                        try
                        {
                            switch (ProductSku.Sku)
                            {
                                case ProductSkuLevel.Mom:
                                    button = new Maui.Core.WinControls.Button(
                                                   dialogWindow,
                                                   caption,
                                                   StringMatchSyntax.ExactMatch,
                                                   WindowClassNames.Button,
                                                   StringMatchSyntax.ExactMatch);
                                    break;
                                case ProductSkuLevel.Web:
                                    button = new Button(dialogWindow, new QID(";[UIA]Name=\'" + caption + "\' && ClassName = 'Button'"), Constants.DefaultDialogTimeout);                                    
                                    break;
                                default:
                                    break;
                            }   
                        }
                        catch (Window.Exceptions.WindowNotFoundException)
                        {
                            // If didn't find the button, try find again with class name match as wildcard
                            if (button == null)
                            {
                                Utilities.LogMessage("ConfirmChoiceDialog :: Did not find a conditional dialog with button class '" + WindowClassNames.Button + "'");
                                Utilities.LogMessage("ConfirmChoiceDialog :: Creating a button with class name match as wildcard on window '" + dialogWindow.Caption + "'");

                                button = new Maui.Core.WinControls.Button(
                                            dialogWindow,
                                            caption,
                                            StringMatchSyntax.ExactMatch,
                                            WindowClassNames.Button,
                                            StringMatchSyntax.WildCard);
                                
                            }
                        }

                        // wait until button is ready
                        UISynchronization.WaitForUIObjectReady(
                            button.Extended.AccessibleObject,
                            Constants.DefaultDialogTimeout);

                        Utilities.LogMessage("ConfirmChoiceDialog :: " +
                            "Button ready to click.");

                        button.Click();
                        Utilities.LogMessage("ConfirmChoiceDialog :: " +
                            "Clicked the button on window.");
                    }
                    catch (Exception ex)
                    {
                        if (ActionIfWindowNotFound.Error == action)
                        {
                            throw;
                        }
                        else
                        {
                            Utilities.LogMessage("ConfirmChoiceDialog :: " +
                                "ConfirmChoiceDialog :: " +
                                "Did not find a conditional dialog with title '" + dialogTitle + "'");

                            dialogWindow.SendKeys(KeyboardCodes.Enter);
                        }
                    }

                }
                else
                {
                    if (ActionIfWindowNotFound.Error == action)
                    {
                        throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                            "ConfirmChoiceDialog :: " +
                            "Failed to find dialog with title '" + dialogTitle + "'");
                    }
                    else
                    {
                        Utilities.LogMessage("ConfirmChoiceDialog :: " +
                            "ConfirmChoiceDialog :: " +
                            "Did not find a conditional dialog with title '" + dialogTitle + "'");
                    }
                }
            }
        }

        #endregion // Message Box Helper Methods

        /// <summary>
        /// Bring console to foreground
        /// </summary>
        /// <history>
        /// [v-vijia] 27JUN11 Created   
        /// </history>
        /// <remarks>
        /// This method is to work around Maui.Core.Window.Exceptions.CannotSetActiveException is thrown 
        /// when calling Maui.Core.App.BringToForeground(). This exectipion is found in more than one test area.
        /// From the screen shots, console has been brought to foreground when CannotSetActiveException exception is thrown, so just ignore it.
        /// </remarks>
        public override void BringToForeground()
        {
            //Bug#226625
            this.MinimizeCommandLineWindow();

            try
            {
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        base.BringToForeground();
                        break;
                    case ProductSkuLevel.Web:
                        if (this.Browser!=null && this.Browser.Application !=null)
                        {
                            int retries = 0;
                            while (!this.Browser.Application.MainWindow.Extended.IsForeground && retries < Constants.DefaultMaxRetry)
                            {
                                Utilities.TakeScreenshot("BringWebConsoleToForeground_Before");
                                this.Browser.Application.BringToForeground();
                                Sleeper.Delay(Constants.OneSecond * 2);
                                Utilities.TakeScreenshot("BringWebConsoleToForeground_After");

                                retries++;
                            }
                        }
                        break;
                }
            }
            catch (Maui.Core.Window.Exceptions.CannotSetActiveException e)
            {
                Utilities.LogMessage("ConsoleApp.BringToForeground:: Found exception: " + e + ", ignore it.");
                Utilities.TakeScreenshot("ConsoleApp.BringToForeground");
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException e2)
            {
                Utilities.LogMessage("ConsoleApp.BringToForeground:: Found exception: " + e2 + ", ignore it.");
                Utilities.TakeScreenshot("ConsoleApp.BringToForeground");
            }
            catch (Maui.Core.Window.Exceptions.UnknownActiveWinException e3)
            {
                Utilities.LogMessage("ConsoleApp.BringToForeground:: Found exception: " + e3 + ", ignore it.");
                Utilities.TakeScreenshot("ConsoleApp.BringToForeground");
            }
        }

        /// <summary>
        /// Minimize Command line Window
        /// </summary>
        /// <history>
        /// [v-vijia] 26Sep11 Created   
        /// </history>
        public void MinimizeCommandLineWindow()
        {
            try
            {
                // Look for Command Line Window
                Window cmdWindow = new Window(new QID(";[UIA]ClassName='ConsoleWindowClass'"), Constants.OneSecond * 3);

                // Minimize Command Line Window when it is foreground
                if (cmdWindow.Extended.IsForeground)
                {
                    Utilities.TakeScreenshot("MinimizeCommandLineWindow.CommandLineWindow");

                    Window minimizeButton = new Window(cmdWindow, new QID(";[UIA]AutomationId='Minimize'"), Constants.OneSecond * 3);
                    minimizeButton.ScreenElement.LeftButtonClick(-1, -1);
                    Sleeper.Delay(Constants.OneSecond);
                    Utilities.TakeScreenshot("MinimizeCommandLineWindow.CommandLineWindowMinimized");
                }
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                // Swallow
            }
            catch (Exception e)
            {
                // Swallow the exception and print it.
                Utilities.LogMessage("MinimizeCommandLineWindow.CommandLineWindow:: Exception:" + e);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the Caption text of a Static Control
        /// Used to get the Pane Title text (ViewPane, DetailPane, NavPane)
        /// </summary>
        /// <param name="control">StaticControl Reference</param>
        /// <returns>String</returns>
        /// <history>
        /// [mbickle] 18NOV05 Created        
        /// </history>
        /// ------------------------------------------------------------------
        public string GetStaticControlCaption(StaticControl control)
        {
            string paneTitle = null;
            int count = 0;
            int maxCount = 5;

            Utilities.LogMessage("ConsoleApp.GetStaticControlCaption:: WaitForUIObjectReady...");
            control.ScreenElement.WaitForReady();

            Utilities.LogMessage("ConsoleApp.GetStaticControlCaption:: Get Title Caption.");

            // Was getting random InvalidHWndExceptions so will do a try/catch and retry
            // up to maxCount to get a valid string caption.
            while (paneTitle == null && count <= maxCount)
            {
                try
                {
                    paneTitle = control.Caption;
                }
                catch (Window.Exceptions.InvalidHWndException)
                {
                    Utilities.LogMessage("ConsoleApp.GetStaticControlCaption:: Received InvalidHWndException, going to try again.");
                }

                count++;
            }

            if (paneTitle != null)
            {
                Utilities.LogMessage("ConsoleApp.GetStaticControlCaption:: Caption:= '" + paneTitle + "'");
            }
            else
            {
                Utilities.LogMessage("ConsoleApp.GetStaticControlCaption:: Caption:= 'null'");
            }

            return paneTitle;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Overrides Maui.Core.App.GetIntlStr to use ResourceManager directly
        /// to allow use of AssemblyResolveCallback to resolve BAML dependency 
        /// load issues.
        /// </summary>
        /// <param name="resourceId">Resource Id</param>
        /// <returns>Extracted Resource</returns>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <history>
        /// [mbickle] 14NOV05 Created
        /// [mbickle] 10NOV09 Rewrote to use ResourceManager directly to be able to use 
        ///                   AssemblyResolveCallback to handle BAML dependency load issues.
        /// [mbickle] 19NOV09 Added check for Chinese languages to reset ResourceManager's 
        ///                   CultureInfoId to look in the correct directories for resources.
        /// </history>
        /// TODO: make work with Browser resources
        /// ------------------------------------------------------------------
        public override string GetIntlStr(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new System.ArgumentNullException(resourceId, "ConsoleApp.GetIntlStr:: ResourceId, should not be Null or Empty.");
            }
            
            ResourceExtractor resourceExtractor = new ResourceExtractor();

            // Need to do this because ResourceManager is using CurrentCulture 
            // which is zh-TW/zh-CN and expects the resource.dll's to reside in
            // those directories and we use zh-CHT and zh-CHS, so have to reset 
            // the CultureInfoId appropriately.
            if (this.CultureInfo.TwoLetterISOLanguageName == "zh")
            {
                resourceExtractor.CultureInfoId = new System.Globalization.CultureInfo(this.CultureInfo.Parent.Name);
            }
            else
            {
                resourceExtractor.CultureInfoId = new System.Globalization.CultureInfo(this.CultureInfo.LCID);
            }

            resourceExtractor.TargetAppUILanguageId = this.CultureInfo.LCID;
            resourceExtractor.ResFilesDirectories = this.ResourceManager.PathCache.ToString();

            string resourceString = resourceId;

            // check if we have this resource in the cache and return it, if it's there, otherwise begin search.
            string lowerResourceId = resourceId.ToLower(System.Globalization.CultureInfo.InvariantCulture);
            object cachedString = this.resourceCache[lowerResourceId];
            if (null != cachedString)
            {
                resourceString = cachedString.ToString();
            }
            else
            {
                // String not cached, so we have to go searching for it.
                string[] tokens = resourceId.Split(resourceId[0]);
                char token = resourceId[0];

                try
                {
                    // Should be at least 4 tokens in a valid ResourceId.
                    if (tokens.Length < 4)
                    {
                        throw new Maui.Core.Resources.ResourceManager.Exceptions.InvalidResourceIdFormatException("ConsoleApp.GetIntlStr:: ResourceId should contain at least 4 tokens delimited by the first character in the string. ResourceId: " + resourceId);
                    }

                    // Look up the full path of the file being scanned.
                    this.resourceFileNamePath = this.ResourceManager.PathCache[tokens[3].ToLower(System.Globalization.CultureInfo.InvariantCulture)];

                    Utilities.LogMessage(String.Format("ConsoleApp.ResourceManagermPathCache = {0}", this.ResourceManager.PathCache.ToString()));

                    if (!String.IsNullOrEmpty(this.resourceFileNamePath))
                    {
                        // Set the 3rd Token (file name) in the ResourceId to the full path to resource file.
                        tokens[3] = this.resourceFileNamePath;

                        // Debug - ResourceFileNamePath
                        Utilities.LogMessage(String.Format("ResourceFileNamePath = {0}", this.resourceFileNamePath));

                        // Stripping off the file name and just getting the path to start our search.
                        int index = this.resourceFileNamePath.LastIndexOf("\\");
                        string searchPath = this.resourceFileNamePath.Substring(0, index);
                        resourceExtractor.RootResourceDirectory = searchPath;

                        // Debug - ResourceExtractor.RootResourceDirectory
                        Utilities.LogMessage(String.Format("ResourceExtractor.RootResourceDirectory = {0}", searchPath));
                    }
                    else
                    {
                        throw new App.Exceptions.ResourceFileNotFoundException("ConsoleApp.GetIntlStr:: Failed to find File: " + tokens[3]);
                    }

                    // Rebuild the ResourceId with the Full Path to the File.
                    string fullPathResourceId = string.Join(token.ToString(), tokens);

                    // Trim any extra delimiters from the end - should work for all resources.
                    fullPathResourceId = fullPathResourceId.TrimEnd(token);

                    // Extract the ressource.
                    resourceString = resourceExtractor.ExtractResourceString(fullPathResourceId);

                    // Remove any trailing null in the resource string.
                    if (!String.IsNullOrEmpty(resourceString))
                    {
                        resourceString = StringHelper.StripTrailingNull(resourceString);
                    }

                    // put the string in the cache, for future lookups.
                    this.resourceCache[lowerResourceId] = resourceString;

                    Utilities.LogMessage("ConsoleApp.GetInstStr:: Extracted Resource: " + resourceString);
                }
                catch (Maui.Core.Resources.ResourceManager.Exceptions.InvalidResourceIdFormatException ex)
                {
                    Utilities.LogMessage("ConsoleApp.GetIntlStr:: Exception: " + ex);
                    Utilities.LogMessage("ConsoleApp.GetIntlStr:: Hard-coded string needs to be replaced: " + resourceId);
                }
                catch (App.Exceptions.ResourceFileNotFoundException ex)
                {
                    Utilities.LogMessage("ConsoleApp.GetIntlStr:: Exception: " + ex);
                    Utilities.LogMessage("ConsoleApp.GetIntlStr:: Hard-coded string needs to be replaced: " + resourceId);
                }
            }

            return resourceString;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Invokes Refresh action on the element. 
        /// Default is to do an F5
        /// </summary>
        /// <history>
        /// [mbickle] 3/10/2005 Created
        /// [mbickle] 11OCT05 Changed to use F5 instead of Menu View\Refresh
        /// </history>
        /// ------------------------------------------------------------------
        public void Refresh()
        {
            if (ProductSku.Sku == ProductSkuLevel.Mom)
                this.Refresh(CommandMethod.Keyboard);
            else
                this.Browser.Refresh();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///     Invokes Refresh action on the element.
        /// </summary>
        /// <param name="method">How to invoke the action.</param>
        /// <history>
        ///     [mbickle] 3/10/2005 Created
        /// </history>
        /// ------------------------------------------------------------------
        public void Refresh(CommandMethod method)
        {
            int timeout = 60000;

            Commands.ViewRefresh.Execute(this, method);
            UISynchronization.WaitForUIObjectReady(this.MainWindow, timeout);
            UISynchronization.WaitForProcessReady(this.MainWindow, timeout);
            this.Waiters.WaitForStatusReady(timeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Closes Console via File\Exit Command
        /// </summary>
        /// <history>
        /// [mbickle] 02AUG05: Created
        /// </history>
        /// ------------------------------------------------------------------
        public override void Quit()
        {
            if (ProductSku.Sku == ProductSkuLevel.Mom)
            {
                this.Quit(CommandMethod.Default, Constants.OneMinute * 2);
            }
            else
            {
                this.Browser.Quit();
                CoreManager.MomConsole = null;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Closes Console via File\Exit Command
        /// </summary>
        /// <history>
        /// [starrpar] 23Jun10 Overriding SCUI ConsoleFramework functionality here to add a 
        ///                    process Kill step if needed, as was previously in this method
        /// [nathd]    29JUN09 Removing override as we no longer derive from SCUI.
        /// </history>
        /// ------------------------------------------------------------------
        public void Quit(int timeout)
        {
            this.Quit(CommandMethod.Default, timeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Closes Console via File\Exit Command
        /// </summary>
        /// <history>
        /// [starrpar] 23Jun10 Overriding SCUI ConsoleFramework functionality here to add a 
        ///                    process Kill step if needed, as was previously in this method
        /// [nathd]    29JUN09 Removing override as we no longer derive from SCUI.
        /// </history>
        /// ------------------------------------------------------------------
        public void Quit(CommandMethod method)
        {
            this.Quit(method, Constants.OneMinute * 2);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Closes Console
        /// </summary>
        /// <param name="method">How to invoke the action.</param>
        /// <exception cref="Maui.Core.App.Exceptions.CantQuitAppException">
        /// Maui.Core.App.Exceptions.CantQuitAppException
        /// </exception>
        /// <history>
        /// [mbickle]  02AUG05: Created
        /// [mbickle]  10SEP05: Killing UI Process if normal close failes.
        /// [kellymor] 19SEP05: Added call to close Maui TextLog trace log
        /// [v-yoz]    16APRIL09: Added SendKey Alt+F4 when call menu File/Exit failed
        /// [starrpar] 23Jun10 Overriding SCUI ConsoleFramework functionality here to add a 
        ///                    process Kill step if needed, as was previously in this method
        /// [nathd]    29JUN10: Merged SCUI version of Quit(method, timeout) into our ConsoleApp
        ///                     class. Necessary because Maui's app class doesn't have a 
        ///                     Quit method that accepts these params.
        /// </history>
        /// ------------------------------------------------------------------
        public void Quit(CommandMethod method, int timeout)
        {
            Utilities.LogMessage(String.Format("ConsoleApp.Quit:: timeout: {0}", timeout));
            try
            {
                if (this != null)
                {
                    // Attempt to bring console to foreground.
                    this.MainWindow.ScreenElement.BringUp();

                    // Lets make sure the console is settled enough to try and quit.
                    this.Waiters.WaitForReady(timeout);

                    // Work around for 188865
                    try
                    {
                        NavigationPane navPane = new NavigationPane(CoreManager.MomConsole);
                        navPane.Extended.Click();
                    }
                    catch (System.InvalidOperationException)
                    {
                        Utilities.LogMessage("ConsoleApp.Quit:: Not found NavigationPane, ingore It");
                    }
                    Utilities.LogMessage("ConsoleApp.Quit:: Executing FileExit Command");

                    // Bug#204943: bring console to foreground again.
                    //CoreManager.MomConsole.WaitForStatusReady();
                    CoreManager.MomConsole.waiters.WaitForReady();
                    CoreManager.MomConsole.BringToForeground();

                    CoreManager.MomConsole.MainWindow.Extended.ClickTitle();
                    int maxRetry = 3;
                    int retry = 0;
                    while (retry < maxRetry && this.IsRunning)
                    {
                        try
                        {
                            // Use File\Exit Command item to close console.
                            Commands.FileExit.Execute(this, method);
                        }
                        catch (Mom.Test.UI.Core.Console.Command.Exceptions.MenuItemNotEnabledException)
                        {
                            //Close console with keyboardShortcut 'Alt + F4'
                            Utilities.LogMessage("ConsoleApp.Quit:: Close console with keyboardShortcut 'Alt + F4'.");
                            CoreManager.MomConsole.SendKeys(Commands.FileExit.KeyboardShortcut);
                        }
                        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                        {
                            //Close console with keyboardShortcut 'Alt + F4'
                            Utilities.LogMessage("ConsoleApp.Quit:: Close console with keyboardShortcut 'Alt + F4'..");
                            CoreManager.MomConsole.SendKeys(Commands.FileExit.KeyboardShortcut);
                        }
                        catch (Exception e)
                        {
                            Utilities.LogMessage("ConsoleApp.Quit:: " + e.ToString());

                            Utilities.LogMessage("ConsoleApp.Quit:: Close console with keyboardShortcut 'Alt + F4'...");
                            CoreManager.MomConsole.SendKeys(Commands.FileExit.KeyboardShortcut);
                        }

                        Sleeper sleeper = new Sleeper(timeout);

                        Utilities.LogMessage("ConsoleApp.Quit:: Waiting for console to close");

                        // Wait for Console to Close.
                        while (this.IsRunning && sleeper.IsNotExpired)
                        {
                            sleeper.Sleep();
                        }

                        if (this.IsRunning)
                        {
                            Utilities.LogMessage("ConsoleApp.Quit:: Console still running after : " + timeout.ToString());
                            retry++;
                            Utilities.TakeScreenshot("Console close fail retry " + retry);
                            Utilities.LogMessage("ConsoleApp.Quit:: Console not close by File\\Exit or Alt+F4, retry " + retry);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (this.IsRunning)
                    {
                        Utilities.LogMessage("ConsoleApp.Quit:: Console failed close by File\\Exit or Alt+F4 after retry : " + maxRetry);
                        Utilities.LogMessage("ConsoleApp.Quit:: Checking for DrWatson and then will create a Debug Dump");

                        // Lets try and Quit the console.
                        this.ConsoleQuitCleanUp(String.Empty);

                        //Utilities.LogMessage("ConsoleApp.Quit: Closing app timed out. Consider using KillProcess instead of Quit.", true);
                        //throw new Exceptions.CantQuitAppException("ConsoleApp.Quit: Closing app timed out. Consider using KillProcess instead of Quit.");
                    }

                    Utilities.LogMessage("ConsoleApp.Quit:: Console Closed.");
                }
            }
            catch (Exceptions.CantQuitAppException)
            {
                throw;
            }
            catch (MauiException me)
            {
                this.ConsoleQuitCleanUp(me.ToString());

                //throw new Exceptions.CantQuitAppException("ConsoleApp.Quit: Closing app failed, had to kill process.");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                this.ConsoleQuitCleanUp(ex.ToString());

                //throw new Exceptions.CantQuitAppException("ConsoleApp.Quit: Closing app failed, had to kill process.");
            }
            catch (System.InvalidOperationException ioex)
            {
                this.ConsoleQuitCleanUp(ioex.ToString());

                //throw new Exceptions.CantQuitAppException("ConsoleApp.Quit: Closing app failed, had to kill process.");
            }
            finally
            {
                // One last check.
                if (this.IsRunning)
                {
                    Utilities.LogMessage("ConsoleApp.Quit:: Still running in Finally, will try one last time.");
                    this.ConsoleQuitCleanUp(String.Empty);                        
                }

                // Done with RPF
                try
                {
                    // The FinishPlayBack call should no longer be necessary with the latest Maui version.
                    //RPF.FinishPlayBack();
                }
                catch (Exception e)
                {
                    Utilities.LogMessage("ConsoleApp.Quit:: RPF.FinishPlayBack Failed: " + e);
                }

                // Close the Maui TextLog
                Utilities.CloseMauiLog();

                //CoreManager.MomConsole = null;
            }

            //try
            //{
            //    base.Quit(method, timeout);
            //}
            //catch (MauiException me)
            //{
            //    Utilities.LogMessage("ConsoleApp.Quit:: Maui Exception thrown when closing console, now killing process: " + me, true);
            //    this.Kill();
            //}
            //finally
            //{
            //    // Close the Maui TextLog
            //    Utilities.CloseMauiLog();
            //}

            /*
            int quitTimeout = 120000;  //120 seconds

            Utilities.LogMessage("ConsoleApp.Quit::");
            try
            {
                if (this != null)
                {
                    // Lets make sure the console is settled enough to try and quit.
                    UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, quitTimeout);
                    UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, quitTimeout);
                    this.Waiters.WaitForStatusReady(quitTimeout);                    

                    try
                    {
                        Utilities.LogMessage("ConsoleApp.Quit:: Executing FileExit Command");
                        Utilities.TakeScreenshot("Executing_FileExit_Command");
                        // Use File\Exit Command item to close console.
                        Commands.FileExit.Execute(this, method);
                    }
                    catch(Maui.Core.WinControls.MenuItem.Exceptions.MenuItemNotFoundException)
                    {
                        Utilities.LogMessage("ConsoleApp.Quit:: Executing FileExit Command Failed, Send Key 'Alt + F4' to close Console");
                        // If call Menu File/Exit failed, will send key Alt + F4 to try close console
                        SendKeys(KeyboardCodes.Alt + KeyboardCodes.F4);
                    }

                    Sleeper sleeper = new Sleeper(quitTimeout);

                    Utilities.LogMessage("ConsoleApp.Quit:: Waiting for console to close");

                    // Wait for Console to Close.
                    while (this.IsRunning && sleeper.IsNotExpired)
                    {
                        sleeper.Sleep();
                    }

                    if (this.IsRunning)
                    {
                        Utilities.LogMessage("ConsoleApp.Quit:: Still Running");
                        Utilities.TakeScreenshot("Still_Running");
                        // Checks to see if DW20.exe is running and waits if it is.
                        Utilities.WaitForDrWatson();

                        // Creates a debug dump of the UI Process and kills the UI.
                        Utilities.CreateProcessDump(ProductSku.SkuExe, false);

                        // Wait for Console to Close.
                        while (this.IsRunning)
                        {
                            Sleeper.Delay(1000);
                        }

                        // Kill UI Process
                        //this.Kill();
                        Utilities.LogMessage("ConsoleApp.Quit: Closing app timed out. Consider using KillProcess instead of Quit.", true);
                        throw new Exceptions.CantQuitAppException("ConsoleApp.Quit: Closing app timed out. Consider using KillProcess instead of Quit.");
                    }

                    Utilities.LogMessage("ConsoleApp.Quit:: Console Closed.");
                }
            }
            catch (Exceptions.CantQuitAppException)
            {
                throw;
            }
            catch (MauiException me)
            {
                Utilities.LogMessage("ConsoleApp.Quit:: Threw Exception in closing, now killing process: " + me, true);

                // Checks to see if DW20.exe is running and waits if it is.
                Utilities.WaitForDrWatson();

                // Creates a debug dump of the UI Process and kills the UI.
                Utilities.CreateProcessDump(ProductSku.SkuExe, false);

                // Wait for Console to Close.
                while (this.IsRunning)
                {
                    Sleeper.Delay(1000);
                }

                // Kill UI Process
                // this.Kill();
                throw new Exceptions.CantQuitAppException("ConsoleApp.Quit: Closing app failed, had to kill process.");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                Utilities.LogMessage("ConsoleApp.Quit:: Threw COMException in closing, now killing process: " + ex, true);

                // Checks to see if DW20.exe is running and waits if it is.
                Utilities.WaitForDrWatson();

                // Creates a debug dump of the UI Process and kills the UI.
                Utilities.CreateProcessDump(ProductSku.SkuExe, false);

                // Wait for Console to Close.
                while (this.IsRunning)
                {
                    Sleeper.Delay(1000);
                }

                // Kill UI Process
                // this.Kill();
                throw new Exceptions.CantQuitAppException("ConsoleApp.Quit: Closing app failed, had to kill process.");
            }
            finally
            {
                // Close the Maui TextLog
                Utilities.CloseMauiLog();

                // Turn back on showing of DW UI
                // Utilities.ShowDrWatsonUI(true);
            }
            */
        }

        /// <summary>
        /// Override the Resource Search Paths.
        /// Web Console Only... we no-op for Desktop...
        /// This is necessary as the search path is automatically set to the path containing the executable for the App.
        /// This works for the desktop console, but not the web console. Short-term will we look up all resources in the 
        /// Console folder (containing the desktop exe)... long-term we will need to pull the Silverlight Xap file, 
        /// extract all binaries to some location and add this location to the search path. 
        /// </summary>
        protected override void SetResourceSearchPaths()
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            // Get Desktop Console InstallPath. We are assuming that the console is always installed on 
            // the machine where UI automation (web and desktop) is executing.
            string desktopConsolePath = Registry.GetValue(
                RegistryHive.Win32LocalMachine,
                Mom.Test.UI.Core.Common.Constants.SetupRegistryPathConsole,
                Mom.Test.UI.Core.Common.Constants.InstallDirectoryRegistryKey);
            Utilities.LogMessage(String.Format("{0} :: Console InstallPath = {1}", currentMethodName, desktopConsolePath));

            // Web Console Only
            if (ProductSku.Sku == ProductSkuLevel.Web)
            {
                string webConsolePath = null;

                // Get the Web Console InstallPath
                webConsolePath = Utilities.GetWebConsoleInstallPath(Utilities.WebConsoleWebServerName);
                Utilities.LogMessage(String.Format("{0} :: Web Console InstallPath = {1}", currentMethodName, webConsolePath));

                // Fix up the Web Console Install Path to be in UNC format
                webConsolePath = String.Format(@"\\{0}\{1}", Utilities.WebConsoleWebServerName, webConsolePath);
                webConsolePath = Regex.Replace(webConsolePath, ":", "$");

                // Update ResourceManager.PathCache.DefaultPath
                Utilities.LogMessage(String.Format("{0} :: Original PathCache = {1}", currentMethodName, this.ResourceManager.PathCache.DefaultPath));
                this.ResourceManager.PathCache.DefaultPath = String.Format("{0};{1};{2}", 
                    this.ResourceManager.PathCache.DefaultPath, 
                    webConsolePath, 
                    desktopConsolePath);
                Utilities.LogMessage(String.Format("{0} :: Updated PathCache = {1}", currentMethodName, this.ResourceManager.PathCache.DefaultPath));
            }
            else if(ProductSku.Sku == ProductSkuLevel.Mom)
            {

                // Update ResourceManager.PathCache.DefaultPath
                Utilities.LogMessage(String.Format("{0} :: Original PathCache = {1}", currentMethodName, this.ResourceManager.PathCache.DefaultPath));
                this.ResourceManager.PathCache.DefaultPath = String.Format("{0};{1}",
                    desktopConsolePath,
                    this.ResourceManager.PathCache.DefaultPath);
                Utilities.LogMessage(String.Format("{0} :: Updated PathCache = {1}", currentMethodName, this.ResourceManager.PathCache.DefaultPath));
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Common CleanUp Code when Console can't quit normally.
        /// </summary>
        /// <param name="exception">Exception text</param>
        /// <history>
        /// [mbickle] 16JUL08 Created
        /// [nathd]   29JUN10 Merged from SCUI code base.
        /// </history>
        /// ------------------------------------------------------------------
        private void ConsoleQuitCleanUp(string exception)
        {
            Utilities.LogMessage(String.Format("ConsoleApp.ConsoleQuitCleanup:: Threw Exception in closing, now killing process: {0}", exception), true);
            Utilities.TakeScreenshot("ConsoleQuitCleanUp");

            // Checks to see if DW20.exe is running and waits if it is.
            Utilities.WaitForDrWatson();           

            // Check if Console is still not Closed, if so create dump file and kill the process
            if (this.IsRunning)
            {
                // Creates a debug dump of the UI Process and kills the UI.
                Utilities.CreateProcessDump(System.Diagnostics.Process.GetProcessById(this.Process.Id).ProcessName + ".exe", false);

                Utilities.LogMessage("ConsoleApp.ConsoleQuitCleanUp:: this.Running = true... killing process...");
                this.Kill();

                Utilities.LogMessage("ConsoleApp.Quit: Closing app timed out. KillProcess instead of Quit.", true);
                throw new Exceptions.CantQuitAppException("ConsoleApp.Quit: Closing app timed out. KillProcess instead of Quit.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to check for an unhandled exceptions dialog.  The dialog
        /// window will have the same title as the parent application that
        /// caused the exception.  The method will log the exception message
        /// and stack trace to the default logger in the Utilities class.
        /// The method will then either quit the application or continue 
        /// execution based on the value of the parameter passed by the caller.
        /// </summary>
        /// <param name="continueRunning">
        /// A boolean parameter used to indicate if the "Continue" button 
        /// should be clicked to continue program execution
        /// </param>
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
        ///		[KellyMor] 22JUL05: Created method
        ///							Disabled ClickDetails due to AA issue
        ///     [KellyMor] 12SEP05: Added section to check for Watson debug
        ///     [KellyMor] 17SEP05: Added catch blocks for invalid window handle
        ///     [mbickle] 18SEP05: Added Try/Catch to finally clause for HWnd invalid.
        ///     [KellyMor] 17NOV05: Modified dialog title check to use SkuExe
        ///                         per code review
        ///     [mbickle] 29APR06: Made this method call CheckForExceptionErrorDialog()
        ///                        and commented out the rest of the code.
        /// </history>
        /// ------------------------------------------------------------------
        public virtual bool CheckForUnhandledException(bool continueRunning)
        {
            // set the default return value for the method
            bool returnValue = false;

            returnValue = this.CheckForExceptionErrorDialog();

            #region Check for Crash/Debug Dialog

            ////Maui.Core.Window crashDebug = null;

            ////// look for the dialog
            ////try
            ////{
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Looking for crash/debug dialog...");

            ////    // create a new instance of the dialog
            ////    crashDebug = new Maui.Core.Window(WindowType.Foreground);
            ////    UISynchronization.WaitForUIObjectReady(crashDebug);
            ////}
            ////catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            ////{
            ////    // log message, no unhandled exceptions dialog was found
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: No crash/debug dialog found on first attempt.");

            ////    // wait for crash debug
            ////    int attempts = 0;
            ////    int maxAttempts = 2;
            ////    while (null == crashDebug && attempts < maxAttempts)
            ////    {
            ////        attempts++;
            ////        try
            ////        {
            ////            crashDebug = new Maui.Core.Window(WindowType.Foreground);
            ////            Maui.Core.Utilities.Sleeper.Delay(2000);
            ////        }
            ////        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            ////        {
            ////            Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Attempt " + attempts + " of " + maxAttempts);
            ////        }
            ////    }
            ////}
            ////catch (Maui.Core.Window.Exceptions.InvalidHWndException invalidHandle)
            ////{
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Window handle is invalid.\n\r" + invalidHandle.Message + "\n\r" + invalidHandle.StackTrace);
            ////}
            ////catch (Maui.GlobalExceptions.TimedOutException timedOut)
            ////{
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Window timed out waiting for response.\n\r" + timedOut.Message + "\n\r" + timedOut.StackTrace);
            ////}
            ////finally
            ////{
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Finally");

            ////    // did we find a crash/debug window?
            ////    if (null != crashDebug)
            ////    {
            ////        Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: crashDebug != null");

            ////        // check for matching the correct title
            ////        try
            ////        {
            ////            if (crashDebug.Caption.CompareTo(ProductSku.SkuExe) == 0)
            ////            {
            ////                Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Found crash/debug window!  Closing...");

            ////                // dismiss the dialog
            ////                crashDebug.ClickTitleBarClose();

            ////                // set the return value
            ////                returnValue = true;
            ////            }
            ////            else
            ////            {
            ////                Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Window title found:  '" + crashDebug.Caption + "'");
            ////            }
            ////        }
            ////        catch (Maui.Core.Window.Exceptions.InvalidHWndException invalidHandle)
            ////        {
            ////            Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Window handle is invalid.\n\r" + invalidHandle.Message + "\n\r" + invalidHandle.StackTrace);
            ////        }
            ////    }
            ////    else
            ////    {
            ////        Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: No crash/debug dialog found.");
            ////    }
            ////}

            #endregion // Check for Crash/Debug Dialog

            #region Check for Unhandled Exceptions Dialog

            //// initialize the unhandled exceptions dialog reference
            ////Mom.Test.UI.Core.Console.Dialogs.UnhandledExceptionsDialog exceptionDialog = null;

            ////// look for the dialog
            ////try
            ////{
            ////    // create a new instance of the dialog
            ////    exceptionDialog = new Mom.Test.UI.Core.Console.Dialogs.UnhandledExceptionsDialog(this);
            ////    UISynchronization.WaitForUIObjectReady(exceptionDialog);

            ////    // set the return value
            ////    returnValue = true;

            ////    // log the text of the error message
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: " + exceptionDialog.Controls.UnhandledExceptionHasOccurred.Text);

            ////    // log the text of the stack trace
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: " + exceptionDialog.StackTraceTextBoxText);

            ////    // if the program should continue running...
            ////    if (continueRunning == true)
            ////    {
            ////        Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Continuing program execution...");

            ////        // click the "Continue" button
            ////        exceptionDialog.ClickContinue();
            ////    }
            ////    else
            ////    {
            ////        Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Quitting program execution...");

            ////        // click the "Quit" button
            ////        exceptionDialog.ClickQuit();
            ////    }
            ////}
            ////catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            ////{
            ////    // log message, no unhandled exceptions dialog was found
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: No unhandled exceptions dialog found.");
            ////}
            ////catch (Maui.Core.Window.Exceptions.InvalidHWndException invalidHandle)
            ////{
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Window handle is invalid.\n\r" + invalidHandle.Message + "\n\r" + invalidHandle.StackTrace);
            ////}
            ////catch (Maui.GlobalExceptions.TimedOutException timedOut)
            ////{
            ////    Utilities.LogMessage("ConsoleApp.CheckForUnhandledException:: Window timed out waiting for response.\n\r" + timedOut.Message + "\n\r" + timedOut.StackTrace);
            ////}

            #endregion // Check for Unhandled Exceptions Dialog

            // return true, found and handled dialog; or false, no dialog found
            return returnValue;
        }

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
        ///		[mbickle] 29APR06: Created
        /// </history>
        /// ------------------------------------------------------------------
        public virtual bool CheckForExceptionErrorDialog()
        {
            // set the default return value for the method
            bool returnValue = false;
            Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: ");

            #region Check for Exceptions Dialog

            // initialize the unhandled exceptions dialog reference
            Mom.Test.UI.Core.Console.Dialogs.ExceptionErrorDialog exceptionDialog = null;

            // look for the dialog
            try
            {
                // create a new instance of the dialog
                exceptionDialog = new Mom.Test.UI.Core.Console.Dialogs.ExceptionErrorDialog(this);

                if (exceptionDialog != null)
                {
                    exceptionDialog.Extended.SetFocus();
                    UISynchronization.WaitForUIObjectReady(exceptionDialog);

                    // set the return value
                    returnValue = true;

                    // log the text of the error message
                    Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: ErrorMessage: \n\r" + exceptionDialog.ErrorMessageText);
                    
                    ////if (String.Compare(Dialogs.ExceptionErrorDialog.Strings.DetailsClosed, exceptionDialog.Controls.DetailsButton.Caption) == 0)
                    ////{
                        // Details is closed, lets open it.
                    exceptionDialog.ClickDetails();

                    try
                    {
                        // log the text of the stack trace
                        Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Details: \n\r" + exceptionDialog.DetailsText);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Failed to get Details.");
                    }
                    
                    ////}

                    Utilities.TakeScreenshot("ConsoleApp.CheckForExceptionErrorDialog.Found");

                    // click the "Close" button
                    exceptionDialog.ClickClose();
                }
            }
            catch (System.AccessViolationException)
            {
                // log message, no unhandled exceptions dialog was found
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Attempted to read or write protected memory, No exceptions dialog found.");
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException e)
            {
                // log message, no unhandled exceptions dialog was found
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: No exceptions dialog found.");
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: " + e.Message);
                
                if (null != exceptionDialog)
                {
                    Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: exceptionDialog object is NOT NULL!");
                    Utilities.LogMessage(String.Format("ConsoleApp.CheckForExceptionErrorDialog:: exceptionDialog.Caption",exceptionDialog.Caption));
                }
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException invalidHandle)
            {
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Window handle is invalid.\n\r" + invalidHandle.Message + "\n\r" + invalidHandle.StackTrace);
            }
            catch (Maui.GlobalExceptions.TimedOutException timedOut)
            {
                Utilities.LogMessage("ConsoleApp.CheckForExceptionErrorDialog:: Window timed out waiting for response.\n\r" + timedOut.Message + "\n\r" + timedOut.StackTrace);
            }

            #endregion // Check for Exceptions Dialog

            // return true, found and handled dialog; or false, no dialog found
            return returnValue;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Cancel the Dialog Window, via sending "ESC".
        /// Handles Yes/No confirmation dialog popup via clicking Yes, if found.
        /// </summary>
        /// <param name="dialogWindow">Window</param>
        /// <history>
        /// [mbickle] 29APR06: Created
        /// [v-waltli] 17JUL09: Updated searching confirm dialog title with wildcard match
        ///                     Added clicking title bar to close the dialog if the dialog is still foreground
        ///                     Reduced wait for dialog to close time from 60 seconds to 15 seconds
        /// </history>
        /// ------------------------------------------------------------------
        public virtual void CancelDialogWindow(Window dialogWindow)
        {
            try
            {
                Utilities.LogMessage("ConsoleApp.CancelDialogWindow:: ");

                if (dialogWindow != null)
                {
                    // Set focus to dialog.
                    dialogWindow.Extended.SetFocus();

                    // Close the dialog
                    Utilities.LogMessage("ConsoleApp.CancelDialogWindow:: Sending ESC to close dialog.");
                    Keyboard.SendKeys(KeyboardCodes.Esc);

                    //// Save an image of the screen for diagnostic information.
                    ////Utilities.TakeScreenshot("ConsoleApp.CancelDialogWindow");

                    Utilities.LogMessage("ConsoleApp.CancelDialogWindow:: Handle any Confirmation Dialogs.");
                    
                    // Respond Yes to the confirmation dialog
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Yes,
                        "",
                        StringMatchSyntax.WildCard,
                        MomConsoleApp.ActionIfWindowNotFound.Ignore);

                    // Check if dialog window is still foreground
                    if (dialogWindow.Extended.IsForeground)
                    {
                        // Click title bar to close the dialog
                        Utilities.LogMessage("ConsoleApp.CancelDialogWindow:: Clicking title bar to close the dialog");
                        dialogWindow.ClickTitleBarClose();

                        Utilities.LogMessage("ConsoleApp.CancelDialogWindow:: Handle any Confirmation Dialogs.");

                        // Respond Yes to the confirmation dialog
                        CoreManager.MomConsole.ConfirmChoiceDialog(
                            MomConsoleApp.ButtonCaption.Yes,
                            "",
                            StringMatchSyntax.WildCard,
                            MomConsoleApp.ActionIfWindowNotFound.Ignore);

                        //Respond OK to the Confirmation Dialog
                        CoreManager.MomConsole.ConfirmChoiceDialog(
                            MomConsoleApp.ButtonCaption.OK,
                            "",
                            StringMatchSyntax.WildCard,
                            MomConsoleApp.ActionIfWindowNotFound.Ignore);
                    }
                    else
                    {
                        Utilities.LogMessage("ConsoleApp.CancelDialogWindow:: The dialog is closed successfully");
                    }

                    Utilities.LogMessage("ConsoleApp.CancelDialogWindow:: Waiting for Dialog to close.");
                    this.WaitForDialogClose(dialogWindow, 15);

                    //// Save an image of the screen for diagnostic information.
                    ////Utilities.TakeScreenshot("ConsoleApp.CancelDialogWindow");
                }
            }
            catch
            {
                ////Utilities.LogMessage("ConsoleApp.CloseWizardDialog:: " + "ignoring errors in this method.");
            }
            finally
            {
                // Set dialog to null to prevent later error handling from trying to access the dialog.
                dialogWindow = null;
            }
        }

        /// <summary>
        /// Close all child dialog windows in Mom Consle and bring Mom Console to foreground
        /// If the foreground window is child window of Mom Console then close the window
        /// If the foreground window is not window of Mom Console then ignore the window and try to bring Mom Console to foreground
        /// </summary>
        /// <returns>True if Mom Console is foreground in the end</returns>
        /// <history>                
        /// [v-waltli] 17JUL09  Created  
        /// </history>
        public bool CloseChildDialogWindows()
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethodName + "...");

            return this.CloseChildDialogWindows(3);
        }

        /// <summary>
        /// Close all child dialog windows in Mom Consle and bring Mom Console to foreground
        /// If the foreground window is child window of Mom Console then close the window
        /// If the foreground window is not window of Mom Console then ignore the window and try to bring Mom Console to foreground
        /// </summary>
        /// <param name="maxCount">Max Count to close open dialogs</param>
        /// <returns>True if Mom Console is foreground in the end</returns>
        /// <history>                
        /// [v-waltli] 17JUL09  Created  
        /// [v-dayow] 31MAR10 Close assert dialog if have.
        /// </history>
        public bool CloseChildDialogWindows(int maxCount)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethodName + "...");

            #region Ignore assert window if have.
            bool foundAssertDialog = false;
            Dialogs.AssertDialog assertWin = null;
            try
            {
                assertWin = new Mom.Test.UI.Core.Console.Dialogs.AssertDialog(CoreManager.MomConsole);
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage(currentMethodName + ":: Not found assert dialog.");
            }
            if (assertWin != null)
            {
                foundAssertDialog = true;
                Utilities.LogMessage(currentMethodName + ":: Warning! Found assert dialog.  Error Message: " + assertWin.Controls.ErrorMessageLable.Text);
                Utilities.TakeScreenshot("CloseChildDialogWindows.FoundAssertWindow");
                assertWin.ClickIgnore();
                CoreManager.MomConsole.WaitForDialogClose(assertWin, 2);
                Utilities.LogMessage(currentMethodName + ":: Assert dialog closed.");
            }
            #endregion

            #region Loop to close all child dialog windows

            int retry = 0;
            // Loop to close all child dialog windows if Mom Console is not foreground
            // If the foreground window is child window of Mom Console then close all child windows
            // If the foreground window is not window of Mom Console then ignore the window and try to bring Mom Console to foreground
            // if Mom Console is foreground then break loop
            // If Mom Console is foreground or retry reaches max count then break loop too
            while ((!CoreManager.MomConsole.MainWindow.Extended.IsForeground) && (retry++ <= maxCount))
            {
                Utilities.LogMessage(currentMethodName + ":: Current retry: " + retry);

                Utilities.LogMessage(currentMethodName + ":: Capturing current Foreground window");

                Window tempWindow = null;
                try
                {
                    tempWindow = new Window(WindowType.Foreground);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
                {
                    //Maui4.0: 
                    Utilities.LogMessage(currentMethodName + ":: no child window now := " + ex.ToString());
                    continue;
                }  

                Utilities.LogMessage(currentMethodName + ":: Captured current Foreground window with caption: " + tempWindow.Caption);

                // Check if the foreground window is a window of Mom Console process and has title bar
                // fix for bug #188345 - get wrong foreground window
                // Because the tempWindow may be a Component of Mom console(such as Navigation tree), so need to check if it has title bar
                // The child dialogs of Mom console have title bar, but the components of Mom console don't have title bar.
                if (tempWindow.Extended.ProcID == CoreManager.MomConsole.Process.Id && tempWindow.Extended.HasTitlebar)
                {
                    Utilities.LogMessage(currentMethodName + ":: Current Foreground window is a window of Mom Console process");

                    try
                    {
                        // Owner window of the current window
                        Window ownerWindow = tempWindow.Extended.Owner;

                        #region Loop to close all child dialog windows of Mom Console

                        // Check if current window is neither null nor Mom Consle window, then it must be a child dialog window
                        while (tempWindow != null && tempWindow.Extended.HWnd != CoreManager.MomConsole.MainWindow.Extended.HWnd)
                        {
                            // This window is a child dialog window of Mom Console, so close this window
                            Utilities.LogMessage(currentMethodName + ":: Closing child dialog window with caption: " + tempWindow.Caption);

                            CoreManager.MomConsole.CancelDialogWindow(tempWindow);

                            // Capture owner window
                            if (ownerWindow == null ||
                                (ownerWindow != null && !ownerWindow.ScreenElement.IsValid))
                                break;
                            tempWindow = ownerWindow;
                            ownerWindow = tempWindow.Extended.Owner;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        //Maui4.0: RecordPlaybackFramework.Exceptions.RPFException is thrown at PendingNetworkDevice var1.1.1.
                        //There is no reference for class RecordPlaybackFramework.Exceptions.RPFException. 
                        //So use System.Exception to catch.
                        Utilities.LogMessage(currentMethodName + ":: Found exception when cancel dialog window " + ex.ToString());
                    }

                    #endregion // Loop to close all child dialog windows of Mom Console
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + ":: Current Foreground window is not a window of Mom Console process, ignore it.");

                    // Bring Mom Console to the foreground
                    try
                    {
                        Utilities.LogMessage(currentMethodName + ":: Bringing Mom Console to the foreground");
                        CoreManager.MomConsole.BringToForeground();

                        Utilities.LogMessage(currentMethodName + ":: Waitting for Mom Console status ready");
                        Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
                    }
                    catch (Maui.GlobalExceptions.MauiException)
                    {
                        Utilities.LogMessage(currentMethodName + ":: Failed to bring Console to Foreground.");
                    }
                }
            }

            #endregion // Loop to close all child dialog windows

            // Bring Mom Console to the foreground
            try
            {
                Utilities.LogMessage(currentMethodName + ":: Bringing Mom Console to the foreground");
                CoreManager.MomConsole.BringToForeground();

                Utilities.LogMessage(currentMethodName + ":: Waitting for Mom Console status ready");
                Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
            }
            catch (Maui.GlobalExceptions.MauiException)
            {
                Utilities.LogMessage(currentMethodName + ":: Failed to bring Console to Foreground.");
            }

            if (foundAssertDialog) //throw this exception after colsing all child dialog so that it will not block other test cases.
                throw new UnexpectedDialogFoundException("Assert debug dialog was found when closing all child dialog windows. It has been closed yet. Please see log and screenshot for details.");

            // Return if Mom Console is foreground
            return CoreManager.MomConsole.MainWindow.Extended.IsForeground;
        }

        /// <summary>
        /// support two consoles translation on a machine
        /// </summary>
        /// <param name="mainWindow">connected Momconsole</param>
        public void SetMainWindow(Window mainWindow)
        {
            this.GetType().BaseType.BaseType.GetField("m_mainWindow", BindingFlags.NonPublic | BindingFlags.Instance).SetValue((App)this, mainWindow);     
        }



        /// ------------------------------------------------------------------
        /// <summary>
        /// Waits for the screen element to be visible.
        /// </summary>
        /// <param name="button">Screen element to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.</param>
        ///  [v-dayow] 12APR10 Created
        ///  TODO: Move to Waiters
        /// ------------------------------------------------------------------
        public void WaitForScreenElementVisible(
            IScreenElement screenElement,
            int timeOutSeconds)
        {
            int loop = 0;
            while (loop <= timeOutSeconds)
            {
                Sleeper.Delay(DelayOneSecond);
                loop++;

                if (screenElement.IsVisible)
                {
                    Utilities.LogMessage("WaitForScreenElementVisible: " +
                        screenElement.Name + " is visible after " +
                        loop.ToString() + " seconds.");

                    break;
                }
            }
            if (!screenElement.IsVisible)
            {
                throw new System.TimeoutException("Wait for '" + screenElement.Name + "' timed out at " + loop.ToString() + " seconds.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Waits for the screen element to be enabled.
        /// </summary>
        /// <param name="button">Screen element to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.</param>
        ///  [v-dayow] 12APR10 Created
        /// ------------------------------------------------------------------
        public void WaitForScreenElementEnable(
            IScreenElement screenElement,
            int timeOutSeconds)
        {
            int loop = 0;
            while (loop <= timeOutSeconds)
            {
                Sleeper.Delay(DelayOneSecond);
                loop++;

                if (screenElement.IsEnabled)
                {
                    Utilities.LogMessage("WaitForScreenElementEnable: " +
                        screenElement.Name + " is enabled after " +
                        loop.ToString() + " seconds.");

                    break;
                }
            }
            if (!screenElement.IsEnabled)
            {
                throw new System.TimeoutException("Wait for '" + screenElement.Name + "' timed out at " + loop.ToString() + " seconds.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Waits for the screen element to be disabled.
        /// </summary>
        /// <param name="button">Screen element to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.</param>
        ///  [v-dayow] 12APR10 Created
        ///  TODO: Move to Waiters
        /// ------------------------------------------------------------------
        public void WaitForScreenElementDisable(
            IScreenElement screenElement,
            int timeOutSeconds)
        {
            int loop = 0;
            while (loop <= timeOutSeconds)
            {
                Sleeper.Delay(DelayOneSecond);
                loop++;

                if (!screenElement.IsEnabled)
                {
                    Utilities.LogMessage("WaitForScreenElementDisable: " +
                        screenElement.Name + " is disabled after " +
                        loop.ToString() + " seconds.");

                    break;
                }
            }
            if (screenElement.IsEnabled)
            {
                throw new System.TimeoutException("Wait for '" + screenElement.Name + "' timed out at " + loop.ToString() + " seconds.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Waits for the specifed button to be enabled.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// button becoming enabled.</remarks>
        /// <param name="button">Button object to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.</param>
        /// ------------------------------------------------------------------
        //[Obsolete("call Waiters WaitForButtonEnabled")]
        //public void WaitForEnabledButton(
        //    Maui.Core.WinControls.Button button,
        //    int timeOutSeconds)
        //{
        //    // The API here we call takes millisec, so we need to convert the param to millisec
        //    this.Waiters.WaitForButtonEnabled(button, timeOutSeconds * Constants.OneSecond);
        //}

        /// ------------------------------------------------------------------
        /// <summary>
        /// Waits for the specifed button to be disabled.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// button becoming disabled.</remarks>
        /// <param name="button">Button object to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.</param>
        /// <history>
        /// [v-liqluo] 08MAR10 Created
        /// </history>
        /// TODO: Move to Waiters
        /// ------------------------------------------------------------------
        public void WaitForDisabledButton(
            Maui.Core.WinControls.Button button,
            int timeOutSeconds)
        {
            // Wait for installation process to complete
            int loop = 0;
            while (loop <= timeOutSeconds)
            {
                Sleeper.Delay(DelayOneSecond);
                loop++;

                if (!button.IsEnabled)
                {
                    Utilities.LogMessage("ConsoleApp.WaitForDisabledButton: " +
                        button.Caption + " button was disabled after " +
                        loop.ToString() + " seconds.");

                    // Control is disabled end the wait
                    break;
                }
            }

            // If the control is not disabled after the maximum
            //  number of tries, throw an exception.
            if (button.IsEnabled)
            {
                throw new System.TimeoutException("Timed out before button was" +
                    " disabled after " + loop.ToString() + " seconds.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait for Wizard Navigation Item Count to have at least the number specified.
        /// </summary>
        /// <param name="wizardDialog">Wizard Dialog Window</param>
        /// <param name="navigationItemCount">Number of Navigation Items to wait for.</param>
        /// <param name="timeout">Timeout value in milliseconds to wait.</param>
        /// <returns>true/false</returns>
        /// <history>
        /// [mbickle] 18JUL07 Created
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("use Waiters ConsoleApp.Waiter WaitForWizardNavigationItemCount(Window wizardDialog, int navigationItemCount, int timeout) ")]
        public bool WaitForWizardNavigationItemCount(Window wizardDialog, int navigationItemCount, int timeout)
        {
            return this.Waiters.WaitForWizardNavigationItemCount(wizardDialog, navigationItemCount, timeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait for Dialog to close/not be visible.
        /// TODO: Roll this code into Waiters.WaitforWindowClose
        /// </summary>
        /// <param name="dialogWindow">Window</param>
        /// <param name="secondstowait">Number of Seconds to wait</param>
        /// <returns>True/False</returns>
        /// <history>
        /// [mbickle] 26MAR06 Created
        /// [a-joelj] 06OCT09 Added check to see if dialogWindow is null before waiting for dialog to close
        /// [v-dayow] 28DEC09 Add catch statement for System.InvalidOperationException.
        /// </history>
        /// TODO: Move to Waiters
        /// ------------------------------------------------------------------
        public bool WaitForDialogClose(Window dialogWindow, int secondstowait)
        {
            // Check if dialogWindow is already null before waiting
            if (dialogWindow == null)
            {
                Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Dialog is null and closed, no need to wait");
                return true;
            }

            Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Waiting for Dialog to go away");
            DateTime startTime = DateTime.Now;
            bool dialogClosed = false;

            try
            {
                //dialogWindow.ScreenElement.WaitForGone(Constants.OneSecond * secondstowait, Constants.OneSecond);
                dialogWindow.WaitForInvisible(Constants.OneSecond * secondstowait);
                Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Dialog closed.");
                dialogClosed = true;
            }
            catch (System.AccessViolationException)
            {
                //This exception will occur when the dialog we checked had been closed before
                //invoking WaitForGone()
                Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Got System.AccessViolationException, the Dialog should be closed.");
                dialogClosed = true;
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException)
            {
                dialogClosed = true;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                dialogClosed = true;
            }
            catch (InvalidOperationException ex)
            {
                Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Got InvalidOperationException: " + ex.Message);

                //WaitForGone will throw InvalidOperationException when timeout.   #171836
                //WaitForGone will throw InvalidOperationException if dialog already closed before calling the method.
                if (!dialogWindow.ScreenElement.IsValid)
                {
                    dialogClosed = true;
                }
                else
                {
                    while (!dialogClosed && Convert.ToInt32(Utilities.ElapsedTime(startTime).TotalSeconds) <= secondstowait)
                    {
                        try
                        {
                            if (!dialogWindow.Extended.IsVisible)
                            {
                                dialogClosed = true;
                                Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Dialog is not visible as expected, dialog closed");
                            }
                        }
                        catch (Window.Exceptions.WindowNotFoundException)
                        {
                            dialogClosed = true;
                           Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Catch WindowNotFoundException as expected, dialog closed");
                        }
                        catch (Window.Exceptions.InvalidHWndException)
                        {
                            dialogClosed = true;
                            Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Catch InvalidHWndException as expected, dialog closed");
                        }
                        Sleeper.Delay(Constants.OneSecond);
                    }

                    if (!dialogClosed && Convert.ToInt32(Utilities.ElapsedTime(startTime).TotalSeconds) > secondstowait)
                    {
                        throw new TimeoutException("Dialog not closed in " + secondstowait + " seconds");
                    }
                }
            }
            finally
            {
                Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Elapsed Time:= " + Utilities.ElapsedTime(startTime));

                if (!dialogClosed)
                {
                    Utilities.LogMessage("ConsoleApp.WaitForDialogClose:: Failed to Close Dialog.");
                    Utilities.TakeScreenshot("ConsoleApp.WaitForDialogClose");
                }
            }

            return dialogClosed;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait For StatusBar Ready Message.
        /// Default Timeout: StatusTimeout
        /// </summary>
        /// <returns>(True/False) Found message on status bar</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("use Waiter Methods")]
        public bool WaitForStatusReady()
        {
            return this.WaitForStatusReady(StatusTimeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait For StatusBar Ready Message w/Timeout
        /// </summary>
        /// <param name="timeout">Timout in milliseconds</param>
        /// <returns>(True/False) Found message on status bar</returns>
        /// ------------------------------------------------------------------
        [Obsolete ("use Waiter Methods")]
        public bool WaitForStatusReady(int timeout)
        {
            int retry = 0;
            int panelCount = 0;
            DateTime startTime = DateTime.Now;

            bool ready = false;
            ready = this.WaitForStatusText(
                MomControls.ConsoleStatusBar.Strings.Ready, 
                timeout);
                        
            // Lets check the Panel Count and see if the Status Indicator is still processing.
            // If we find more than 1 Panel then usually means the status indicator is doing something
            // so we'll attempt to wait up to the timeout value.
            do
            {
                try
                {
                    panelCount = CoreManager.MomConsole.Controls.StatusBar.Panels.Count;
                    //// Utilities.LogMessage("ConsoleApp.WaitForWindowIdle:: PanelCount: " + panelCount.ToString());
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Utilities.LogMessage("ConsoleApp.WaitForStatusReady:: ArgumentOutOfRangeException");
                    panelCount = 2;  // Do this so we try one more time.
                }

                if (panelCount > 1)
                {
                    Sleeper.Delay(1000);
                }

                retry = retry + 1000;
            }
            while (panelCount > 1 && retry <= timeout);

            if (panelCount > 1)
            {
                Utilities.LogMessage("ConsoleApp.WaitForStatusReady:: UI still doing something after max wait.");
                Utilities.LogMessage("ConsoleApp.WaitForStatusReady:: panelCount: " + panelCount.ToString());
                Utilities.TakeScreenshot("ConsoleApp.WaitForStatusReady");
                ready = false;
            }
            
            Utilities.LogMessage("ConsoleApp.WaitForStatusReady:: Ready = " + ready.ToString());
            Utilities.LogMessage("ConsoleApp.WaitForStatusReady:: Elapsed Time: " + Utilities.ElapsedTime(startTime));

            return ready;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait For Status Text to appear.
        /// Default Timeout: StatusTimeout
        /// </summary>
        /// <param name="statusMessage">Status Message to Look for.</param>
        /// <returns>(True/False) Found message on status bar</returns>
        /// <history>
        /// </history>
        /// 
        /// ------------------------------------------------------------------
        [Obsolete("use Waiter WaitForStatusText(string statusMessage) ")]
        public bool WaitForStatusText(string statusMessage)
        {
                return this.WaitForStatusText(statusMessage,StatusTimeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Wait For Status Text to appear w/Timeout.
        /// </summary>
        /// <param name="statusMessage">Status Message to look for</param>
        /// <param name="timeout">Timout</param>
        /// <returns>(True/False) Found message on status bar</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("use consoleApp.Waiter WaitForStatusText(string statusMessage, int timeout) ")]
        public bool WaitForStatusText(string statusMessage, int timeout)
        {
            if (ProductSku.Sku != ProductSkuLevel.Mom)
                return true;
            else
                return this.Waiters.WaitForStatusText(statusMessage, timeout);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Waits for the specified window to be enabled.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// window becoming enabled.</remarks>
        /// <param name="window">window to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.
        /// TODO: Move to Waiters class
        /// </param>
        /// -------------------------------------------------------------------
        public void WaitForEnabledDialog(
            Window window,
            int timeOutSeconds)
        {
            Utilities.LogMessage("WaitForEnabledDialog(...)");            // Wait for installation process to complete
            int loop = 0;
            while (loop <= timeOutSeconds)
            {
                if (window.IsEnabled == true)
                {
                    Utilities.LogMessage("WaitForEnabledDialog: " +
                        window.Caption + " object was enabled after " +
                        loop.ToString() + " seconds.");

                    // Control is enabled end the wait
                    break;
                }

                Sleeper.Delay(DelayOneSecond);
                loop++;
            }

            // If the control is not enabled after the maximum
            //  number of tries, throw an exception.
            if (window.IsEnabled == false)
            {
                throw new System.TimeoutException("WaitForEnabledDialog :: " +
                    "Timed out before object was" +
                    " enabled after " + loop.ToString() + " seconds.");
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Waits for the specified window to have focus.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// window having focus.</remarks>
        /// <param name="window">window to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.
        /// </param>
        /// -------------------------------------------------------------------
        [Obsolete("use Waiters WaitForWindowFocus(Window window,int timeOutSeconds)")]
        public void WaitForFocusDialog(
            Window window,
            int timeOutSeconds)
        {
            this.Waiters.WaitForWindowFocus(window, timeOutSeconds);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Waits for the specified window to be in the foreground.
        /// </summary>
        /// <remarks>This function is useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// window appearing in the foreground.</remarks>
        /// <param name="window">window to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.
        /// /// TODO: Move to Waiters class
        /// </param>
        /// -------------------------------------------------------------------
        public void WaitForForegroundDialog(
            Window window,
            int timeOutSeconds)
        {
            Utilities.LogMessage("WaitForForegroundDialog(...)");
            int loop = 0;
            while (loop <= timeOutSeconds)
            {
                if (window.Extended.IsForeground == true)
                {
                    Utilities.LogMessage("WaitForForegroundDialog: " +
                        window.Caption + " object was in foreground after " +
                        loop.ToString() + " seconds.");

                    // Object is in the foreground, end the wait
                    break;
                }

                Utilities.LogMessage("WaitForForegroundDialog: " +
                    window.Caption + " object was NOT in foreground after " +
                    loop.ToString() + " seconds.");
                Sleeper.Delay(DelayOneSecond);
                loop++;
            }

            // If the control is not enabled after the maximum
            //  number of tries, throw an exception.
            if (window.Extended.IsForeground == false)
            {
                throw new System.TimeoutException("WaitForForegroundDialog :: " +
                    "Timed out before object was" +
                    " in the foreground after " + loop.ToString() + " seconds.");
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Waits for the specified window to be the top most window. A 
        /// top-level form is a window that has no parent form, or whose parent
        /// form is the desktop window. Top-level windows are typically used
        /// as the main form in an application.
        /// </summary>
        /// <remarks>This function may be useful when the completion
        /// of an operation, e.g., and install, is signaled by the
        /// window appearing at the top.</remarks>
        /// <param name="window">window to wait for.</param>
        /// <param name="timeOutSeconds">Maximum number of seconds to wait.
        /// TODO: Move to Waiters class
        /// </param>
        /// -------------------------------------------------------------------
        public void WaitForTopMostDialog(
            Window window,
            int timeOutSeconds)
        {
            Utilities.LogMessage("WaitForTopMostDialog(...)");
            int loop = 0;
            while (loop <= timeOutSeconds)
            {
                if (window.Extended.IsTopMost == true)
                {
                    Utilities.LogMessage("WaitForTopMostDialog: " +
                        window.Caption + " object was top-most after " +
                        loop.ToString() + " seconds.");

                    // Object is in top, end the wait
                    break;
                }

                Utilities.LogMessage("WaitForTopMostDialog: " +
                    window.Caption + " object was NOT top-most after " +
                    loop.ToString() + " seconds.");
                Sleeper.Delay(DelayOneSecond);
                loop++;
            }

            // If the control is not top after the maximum
            //  number of tries, throw an exception.
            if (window.Extended.IsTopMost == false)
            {
                throw new System.TimeoutException("WaitForTopMostDialog :: " +
                    "Timed out before object was" +
                    " top window after " + loop.ToString() + " seconds.");
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// WaitForWindowIdle
        /// </summary>
        /// <param name="windowToWaitForIdle">Window to wait for to be Idle</param>
        /// <param name="timeout">Timeout to wait in milliseconds</param>
        /// <returns>true/false</returns>
        /// <history>
        /// [mbickle] 18JUL06 Created
        /// </history>
        /// -------------------------------------------------------------------
        [Obsolete("call Waiters.WaitForWindowReady")]
        public bool WaitForWindowIdle(Window windowToWaitForIdle, int timeout)
        {
            this.Waiters.WaitForWindowReady(windowToWaitForIdle, timeout);
            return true;
        }

        #region GetWizardDialog

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function is designed to search for a Wizard dialog window.
        /// </summary>
        /// <param name="dialogTitle">Dialog Title</param>
        /// <param name="timeout">Timeout</param>
        /// <returns>A window of class name WindowClassNames.WinForms10Window8
        /// </returns>
        /// </history>
        /// -------------------------------------------------------------------
        public Window GetWizardDialog(
            string dialogTitle,
            int timeout)
        {
            bool foreground = false;
            bool enabled = false;
            Window tempWindow = this.GetWizardDialog(dialogTitle, timeout, foreground, enabled);
            return tempWindow;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function is designed to search for a Wizard dialog window,
        /// and wait for it to be enabled.
        /// </summary>
        /// <param name="dialogTitle">Dialog Title</param>
        /// <param name="timeout">Timeout</param>
        /// <param name="enabled">Wait for dialog to be enabled</param>
        /// <returns>A window of class name WindowClassNames.WinForms10Window8
        /// </returns>
        /// </history>
        /// -------------------------------------------------------------------
        public Window GetWizardDialog(
            string dialogTitle,
            int timeout,
            bool enabled)
        {
            bool foreground = false;
            Window tempWindow = this.GetWizardDialog(dialogTitle, timeout, enabled, foreground);
            return tempWindow;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function is designed to search for a Wizard dialog window,
        /// and wait for it to be in the foreground and enabled.
        /// </summary>
        /// <param name="dialogTitle">Dialog Title</param>
        /// <param name="timeout">Timeout</param>
        /// <param name="enabled">Wait for dialog to be enabled</param>
        /// <param name="foreground">Wait for dialog to be in the Foreground</param>
        /// <returns>A window of class name WindowClassNames.WinForms10Window8
        /// </returns>
        /// -------------------------------------------------------------------
        public Window GetWizardDialog(
            string dialogTitle,
            int timeout,
            bool enabled,
            bool foreground)
        {
            Common.Utilities.LogMessage("Console.GetWizardDialog(...)");

            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    dialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    this,
                    timeout);
                Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                    "found dialog - " + dialogTitle +
                    " using exact match on caption only.");
            }
            catch (Dialog.Exceptions.WindowNotFoundException)
            {
                tempWindow = null;
                int numberOfTries = 0;
                int maxTries = 5;
                while (tempWindow == null && numberOfTries < maxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcard
                        tempWindow = new Window(
                            dialogTitle + "*",
                            StringMatchSyntax.WildCard,
                            WindowClassNames.WinForms10Window8,
                            StringMatchSyntax.WildCard,
                            this,
                            timeout);
                        Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                            "found window - " + dialogTitle + "*" +
                            " using wildcard match on caption only.");

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            timeout);
                    }
                    catch (Dialog.Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt(s)
                        Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                            "Unable to find dialog - " + dialogTitle);
                    }
                }

                // check for success
                if (tempWindow != null)
                {
                    if (foreground)
                    {
                        this.Waiters.WaitForWindowForeground(tempWindow,Constants.DefaultDialogTimeout);
                    }

                    if (enabled)
                    {
                        this.Waiters.WaitForWindowEnabled(tempWindow, Constants.DefaultDialogTimeout);
                    }
                }
                else
                {
                    // log the failure
                    Common.Utilities.LogMessage("Console.GetWizardDialog: " +
                        "Unable to find dialog - " + dialogTitle +
                        " after " + numberOfTries.ToString() + " tries.");

                    // throw the first existing WindowNotFound exception
                    throw;
                }
            }

            return tempWindow;
        }
       
        #endregion	// GetWizardDialog

        #region ListView Methods

       /* /// <summary>
        /// Method to find and select a particular ListView Item 
        /// from a specified Column Position. Returns True if the search item is found.
        /// This method does a contains (substring) match and not an exact match.
        /// </summary>
        /// <param name="searchData">Text to look for in the ListView</param>
        /// <param name="columnPosition">Column Position where to search in the ListView</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <returns>Flag indicating if items were found</returns>
        /// <history>
        /// 	[ruhim] 21NOV05 Created
        /// </history>
        [Obsolete("calls into base class SelectListViewItemMethod(string searchData, int columnPosition, Maui.Core.WinControls.ListView listView)")]
         public bool SelectListViewItems(string searchData, int columnPosition, Maui.Core.WinControls.ListView listView)
        {
            Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Looking for '" + searchData
                + "' in list view '" + listView.Caption + "'" + " at Column Position : " +
                columnPosition);

            return SelectListViewItems(searchData, columnPosition, listView, false);
        }*/

        
        /// <summary>
        /// Method to find and select a particular ListView Item 
        /// from a specified Column Position. Returns True if the search item is found.
        /// This method will do an exact match or substring match depending on the exactMatch 
        /// parameter value.
        /// </summary>
        /// <param name="searchData">Text to look for in the ListView</param>
        /// <param name="columnPosition">Column Position where to search in the ListView</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <param name="exactMatch">Whether the match should be exact or not</param>
        /// <returns>Flag indicating if items were found</returns>
        /// <history>
        /// 	[nathd] 08JUL08 Created. 
        /// </history>
        public bool SelectListViewItems(string searchData, int columnPosition, Maui.Core.WinControls.ListView listView, bool exactMatch)
        {
            Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Looking for '" + searchData
                + "' in list view '" + listView.Caption + "'" + " at Column Position : " +
                columnPosition);

            Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Exact Match Enabled: " + exactMatch);

            // flag to indicate if objects were found
            bool foundObjects = false;

            Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: List view has "
                + listView.Count + " items");

            // step through the collection of listview items

            if (columnPosition == 0)
            {
                foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                {
                    // if the current item has text that starts with the search text
                    if (currentItem.Text != null)
                    {
                        Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Comparing '" + searchData.ToLowerInvariant() + "'" + " against item:  '"
                            + currentItem.Text.ToLowerInvariant() + "'");


                        if (exactMatch == true)
                        {
                            if (currentItem.Text.ToLowerInvariant().Equals(searchData.ToLowerInvariant()))
                            {
                                Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Exact match found: '" + currentItem.Text.ToLowerInvariant() + "'");
                                currentItem.EnsureVisible();
                                // If the expected item is not the first item in list, scroll down one line to make sure the item's completely visible
                                if (currentItem.Index > 0)
                                {
                                    listView.VerticalScrollBar.LineDown();
                                }
                                currentItem.Select();
                                Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: ListView item '" + currentItem.Text.ToLowerInvariant() + "' selected.");
                                foundObjects = true;
                                break;
                            }
                        }
                        else
                        {
                            if (currentItem.Text.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                            {
                                Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Contains match found: '" + currentItem.Text.ToLowerInvariant() + "'");
                                currentItem.EnsureVisible();
                                // If the expected item is not the first item in list, scroll down one line to make sure the item's completely visible
                                if (currentItem.Index > 0)
                                {
                                    listView.VerticalScrollBar.LineDown();
                                }
                                currentItem.Select();
                                Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: ListView item '" + currentItem.Text.ToLowerInvariant() + "' selected.");
                                foundObjects = true;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                {
                    // if the current item has text that starts with the search text
                    if (currentItem.Text != null)
                    {
                        Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Comparing '" + searchData.ToLowerInvariant() + "'" + " against item:  '"
                            + currentItem.Text.ToLowerInvariant() + "'");

                        if (exactMatch == true)
                        {
                            if (currentItem.Text.ToLowerInvariant().Equals(searchData.ToLowerInvariant()))
                            {
                                Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Exact match found: '" + currentItem.Text.ToLowerInvariant() + "'");
                                currentItem.EnsureVisible();
                                // If the expected item is not the first item in list, scroll down one line to make sure the item's completely visible
                                if (currentItem.Row > 0)
                                {
                                    listView.VerticalScrollBar.LineDown();
                                }
                                currentItem.Select();
                                Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: ListView item '" + currentItem.Text.ToLowerInvariant() + "' selected.");
                                foundObjects = true;
                                break;
                            }
                        }
                        else
                        {
                            if (currentItem.Text.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                            {
                                Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Contains match found: '" + currentItem.Text.ToLowerInvariant() + "'");
                                currentItem.EnsureVisible();
                                // If the expected item is not the first item in list, scroll down one line to make sure the item's completely visible
                                if (currentItem.Row > 0)
                                {
                                    listView.VerticalScrollBar.LineDown();
                                }
                                currentItem.Select();
                                Common.Utilities.LogMessage("ConsoleApp.SelectListViewItems:: ListView item '" + currentItem.Text.ToLowerInvariant() + "' selected.");
                                foundObjects = true;
                                break;
                            }
                        }
                    }
                } // foreach listview item
            }

            if (foundObjects == false)
            {
                Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item not Found!!!");
            }

            return foundObjects;
        }

        /// <summary>
        /// Method to find and select all ListView Items 
        /// from a specified Column Position. Returns True if atleast one search item is found.   
        /// </summary>
        /// <param name="searchData">Text with which the List item starts with</param>
        /// <param name="stringMatchAt" example="BeginsWith">The position where the search string is present.Valid
        /// values are: BeginsWith or Contains or EndsWith</param>
        /// <param name="columnPosition">Column Position where to search in the ListView</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <returns>Flag indicating if items were found</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <history>
        /// 	[a-omkasi] 16JUL08 Created
        ///     [a-omkasi] 25AUG08 Edited the signature to have a enum StringMatchAt insterd of String.
        /// </history>
        /// TODO: Too many overloads for this method. They all do almost the same thing. Need to eliminate the unnecessary ones.
        public bool SelectListViewItems(string searchData, StringMatchAt stringMatchAt, int columnPosition, Maui.Core.WinControls.ListView listView)
        {
            Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Looking for '" + searchData
                + "' in list view '" + listView.Caption + "'" + " at Column Position : " +
                columnPosition);

            // flag to indicate if objects were found
            bool foundObjects = false;

            Utilities.LogMessage("ConsoleApp.SelectListViewItems:: List view has "
                + listView.Count + " items");

            // step through the collection of listview items

            if (columnPosition == 0)
            {
                switch (stringMatchAt)
                {
                    case StringMatchAt.BeginsWith:
                        foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item:  '"
                                    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().StartsWith(searchData.ToLowerInvariant()))
                                {
                                    // select the item with the control key to preserve other selections
                                    currentItem.Select(KeyboardFlags.ControlFlag);
                                    foundObjects = true;
                                }
                            }
                        }//foreach ListView Item
                        break;

                    case StringMatchAt.Constains:
                        foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item:  '"
                                    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                                {
                                    // select the item with the control key to preserve other selections
                                    currentItem.Select(KeyboardFlags.ControlFlag);
                                    // set the flag
                                    foundObjects = true;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    case StringMatchAt.EndsWith:
                        foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item:  '"
                                    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().EndsWith(searchData.ToLowerInvariant()))
                                {
                                    // select the item with the control key to preserve other selections
                                    currentItem.Select(KeyboardFlags.ControlFlag);
                                    // set the flag
                                    foundObjects = true;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    case StringMatchAt.ExactMatch:
                        foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item:  '"
                                    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Equals(searchData.ToLowerInvariant()))
                                {
                                    // select the item with the control key to preserve other selections
                                    currentItem.Select(KeyboardFlags.ControlFlag);
                                    // set the flag
                                    foundObjects = true;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    default:
                        Utilities.LogMessage("<<Exception:: Invalid input for stringMatchAt in ConsoleApp.SelectListViewItems>> " + stringMatchAt.ToString());
                        throw new ArgumentException("Invalid string input for stringMatchAt in ConsoleApp.SelectListViewItems! >>"
                            + "'" + stringMatchAt.ToString() + "'");
                }// Switch
            }// if position =0
            else
            {
                // for all other column positions
                switch (stringMatchAt)
                {
                    case StringMatchAt.BeginsWith:
                        foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                //Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item:  '"
                                //    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().StartsWith(searchData.ToLowerInvariant()))
                                {
                                    // select the item with the control key to preserve other selections
                                    currentItem.ParentListViewItem.Select(KeyboardFlags.ControlFlag);
                                    // set the flag
                                    foundObjects = true;
                                }
                            }
                        }//foreach ListView Item
                        break;

                    case StringMatchAt.Constains:
                        foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                //Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item:  '"
                                //    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                                {
                                    // select the item with the control key to preserve other selections
                                    currentItem.ParentListViewItem.Select(KeyboardFlags.ControlFlag);
                                    // set the flag
                                    foundObjects = true;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    case StringMatchAt.EndsWith:
                        foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                //Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item:  '"
                                //    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().EndsWith(searchData.ToLowerInvariant()))
                                {
                                    // select the item with the control key to preserve other selections
                                    currentItem.ParentListViewItem.Select(KeyboardFlags.ControlFlag);
                                    // set the flag
                                    foundObjects = true;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    case StringMatchAt.ExactMatch:
                        foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                //Utilities.LogMessage("ConsoleApp.SelectListViewItems:: Matching item:  '"
                                //    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Equals(searchData.ToLowerInvariant()))
                                {
                                    // select the item with the control key to preserve other selections
                                    currentItem.ParentListViewItem.Select(KeyboardFlags.ControlFlag);
                                    // set the flag
                                    foundObjects = true;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    default:
                        Utilities.LogMessage("<<Exception>> Invalid input for stringMatchAt string in ConsoleApp.SelectListViewItems>> " + stringMatchAt.ToString());
                        throw new ArgumentException("Invalid input passed for stringMatchAt in ConsoleApp.SelectListViewItems! >>"
                            + stringMatchAt.ToString());
                }// Switch
            } // else for all other column positions

            if (foundObjects == false)
            {
                Utilities.LogMessage("ConsoleApp.SelectListViewItems:: No Matching item Found!!!");
            }

            return foundObjects;
        }


        /// <summary>
        /// Method to find row of a particular ListView Item 
        /// from a specified Column Position. Returns row index if the search item is found.
        /// This method does a contains (substring) match and not an exact match.
        /// </summary>
        /// <param name="searchData">Text to look for in the ListView</param>
        /// <param name="columnPosition">Column Position where to search in the ListView</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <returns>Flag indicating if items were found</returns>
        /// <history>
        /// 	[starrpar] 09FEB09 Created
        /// </history>
        public int GetListViewItemRowId(string searchData, int columnPosition, Maui.Core.WinControls.ListView listView)
        {
            Common.Utilities.LogMessage("ConsoleApp.GetListViewItemRowId:: Looking for '" + searchData
                + "' in list view '" + listView.Caption + "'" + " at Column Position : " +
                columnPosition);

            return GetListViewItemRowId(searchData, columnPosition, listView, false);
        }


        /// <summary>
        /// Method to find, but NOT select, a particular ListView Item 
        /// from a specified Column Position. Returns rowId if the search item is found, or -1 if not.
        /// This method will do an exact match or substring match depending on the exactMatch 
        /// parameter value.
        /// </summary>
        /// <param name="searchData">Text to look for in the ListView</param>
        /// <param name="columnPosition">Column Position where to search in the ListView</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <param name="exactMatch">Whether the match should be exact or not</param>
        /// <returns>int indicating row if item found in ListView</returns>
        /// <history>
        /// 	[starrpar] 09FEB09 Created. 
        /// </history>
        public int GetListViewItemRowId(string searchData, int columnPosition, Maui.Core.WinControls.ListView listView, bool exactMatch)
        {
            Utilities.LogMessage("ConsoleApp.GetListViewItemRowId :: Looking for '" + searchData
                + "' in list view '" + listView.Caption + "'" + " at Column Position : " +
                columnPosition);

            Utilities.LogMessage("ConsoleApp.GetListViewItemRowId :: Exact Match Enabled: " + exactMatch);

            int rtnVal = -1;
            if (!this.SelectListViewItems(searchData, columnPosition, listView, exactMatch))
            {
                Utilities.LogMessage("ConsoleApp.GetListViewItemRowId :: Value: " + searchData + " in column: " + columnPosition + " in listview: " + listView + " was not found");
            }
            else
            {
                rtnVal = listView.SelectedIndex;
                Utilities.LogMessage("ConsoleApp.GetListViewItemRowId :: Value: " + searchData + " in column: " + columnPosition + " in listview: " + listView + " found");
                Utilities.LogMessage("ConsoleApp.GetListViewItemRowId :: RowId: " + rtnVal);
            }

            return rtnVal;
        }

        
        /// <summary>
        /// Method to verify if a particular ListView Item exists on a given row of the ListView
        /// from a specified Column Position. Returns True if the search item is found on the given row.
        /// This method does a contains (substring) match and not an exact match.
        /// </summary>
        /// <param name="searchData">Text to look for in the ListView</param>
        /// <param name="columnPosition">Column Position where to search in the ListView</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <param name="rowId">reference to the row in the ListView on which the value is expected</param>
        /// <returns>Flag indicating if items were found</returns>
        /// <history>
        /// 	[starrpar] 09FEB09 Created
        /// </history>
        public bool VerifyListViewItemByRow(string searchData, int columnPosition, Maui.Core.WinControls.ListView listView, int rowId)
        {
            Common.Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Looking for '" + searchData
                + "' in list view '" + listView.Caption + "'" + " at Column Position : " +
                columnPosition + " in row: " + rowId);

            return VerifyListViewItemByRow(searchData, columnPosition, listView, rowId, false);
        }


        /// <summary>
        /// Method to verify if a particular ListView Item exists on a given row of the ListView
        /// from a specified Column Position. Returns True if the search item is found on the given row.
        /// This method will do an exact match or substring match depending on the exactMatch 
        /// parameter value.
        /// </summary>
        /// <param name="searchData">Text to look for in the ListView</param>
        /// <param name="columnPosition">Column Position where to search in the ListView</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <param name="rowId">reference to the row in the ListView on which the value is expected</param>
        /// <param name="exactMatch">Whether the match should be exact or not</param>
        /// <returns>bool if item found in ListView on given row</returns>
        /// <history>
        /// 	[starrpar] 09FEB09 Created. 
        /// </history>
        public bool VerifyListViewItemByRow(string searchData, int columnPosition, Maui.Core.WinControls.ListView listView, int rowId, bool exactMatch)
        {
            Common.Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Looking for '" + searchData
                + "' in list view '" + listView.Caption + "'" + " at Column Position : " +
                columnPosition + " in row: " + rowId);

            Common.Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Exact Match Enabled: " + exactMatch);

            Common.Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: List view has " + listView.Count + " items");

            // flag to indicate if objects were found
            bool foundObjects = false;
            //return rowId value if found - else return -1
            int index = 0;

            // step through the collection of listview items

            if (columnPosition == 0)
            {
                foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                {
                    // if the current item has text that starts with the search text
                    if (currentItem.Text != null)
                    {
                        if (exactMatch == true)
                        {
                            if (index <rowId)
                            {
                                index++;
                                continue;
                            }
                            else
                            {
                                Common.Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Comparing item:  '"
                                    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Equals(searchData.ToLowerInvariant()))
                                {
                                    // get the Index of the item
                                    index = currentItem.Index;
                                    foundObjects = true;
                                    Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Matching item found: " + currentItem.Text.ToString());
                                    break;
                                }
                                else
                                {
                                    Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Expected row does not have a match for: " + searchData +
                                        ", value found at row: " + index + " is: " + currentItem.Text.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (index < rowId)
                            {
                                index++;
                                continue;
                            }
                            else
                            {
                                if (currentItem.Text.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                                {
                                    // get the Index of the item
                                    index = currentItem.Index;
                                    foundObjects = true;
                                    Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Matching item found: " + currentItem.Text.ToString());
                                    break;
                                }
                                else
                                {
                                    Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Expected row does not have a match for: " + searchData +
                                        ", value found at row: " + index + " is: " + currentItem.Text.ToString());
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                {
                    // if the current item has text that starts with the search text
                    if (currentItem.Text != null)
                    {
                        if (exactMatch == true)
                        {
                            if (index < rowId)
                            {
                                index++;
                                continue;
                            }
                            else
                            {
                                Common.Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Comparing item:  '"
                                    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Equals(searchData.ToLowerInvariant()))
                                {
                                    // get the rowId of the item
                                    index = currentItem.Row;
                                    foundObjects = true;
                                    Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Matching item found: " + currentItem.Text.ToString());
                                    break;
                                }
                                else
                                {
                                    Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Expected row does not have a match for: " + searchData +
                                        ", value found at row: " + index + " is: " + currentItem.Text.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (index < rowId)
                            {
                                index++;
                                continue;
                            }
                            else
                            {
                                if (currentItem.Text.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                                {
                                    // get the rowId of the item
                                    index = currentItem.Row;
                                    foundObjects = true;
                                    Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Matching item found: " + currentItem.Text.ToString());
                                    break;
                                }
                                else
                                {
                                    Utilities.LogMessage("ConsoleApp.VerifyListViewItemByRow:: Expected row does not have a match for: " + searchData +
                                        ", value found at row: " + index + " is: " + currentItem.Text.ToString());
                                }
                            }
                        }
                    }
                } // foreach listview item
            }

            return foundObjects;
        }


        /// <summary>
        /// Method to get the count of the ListView items which match the given search string, 
        /// from a specified Column Position. Returns a integer cout of items selected.   
        /// </summary>
        /// <param name="searchData">Text with which the List item starts with</param>
        /// <param name="stringMatchAt" example="BeginsWith">The position where the search string is present.Valid
        /// values are: BeginsWith or Contains or EndsWith or ExactMatch</param>
        /// <param name="columnPosition">Column Position where to search in the ListView</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <returns>Flag indicating if items were found</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <history>
        /// 	[a-omkasi] 16JUL08 Created
        ///     [a-omkasi] 25AUG08 Edited the signature to have a enum StringMatchAt insterd of String.
        /// </history>
        public int GetMatchingListViewItemsCount(string searchData, StringMatchAt stringMatchAt, int columnPosition, Maui.Core.WinControls.ListView listView)
        {
            Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: Looking for '" + searchData
                + "' in list view '" + listView.Caption + "'" + " at Column Position : " +
                columnPosition);

            // flag to indicate if objects were found
            int noOfItems = 0;

            Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: List view has "
                + listView.Count + " items in total.");

            // step through the collection of listview items

            if (columnPosition == 0)
            {
                switch (stringMatchAt)
                {
                    case StringMatchAt.BeginsWith:
                        foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                                //Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: Matching item:  '"
                                //    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().StartsWith(searchData.ToLowerInvariant()))
                                {
                                    // Item found. Add the count.
                                    noOfItems++;
                                }
                            }
                        }//foreach ListView Item
                        break;

                    case StringMatchAt.Constains:
                        foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                               // Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: Matching item:  '"
                               //     + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                                {
                                    // Item found. Add the count.
                                    noOfItems++;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    case StringMatchAt.EndsWith:
                        foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                               // Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: Matching item:  '"
                               //    + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().EndsWith(searchData.ToLowerInvariant()))
                                {
                                    // Item found. Add the count.
                                    noOfItems++;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    case StringMatchAt.ExactMatch:
                        foreach (Maui.Core.WinControls.ListViewItem currentItem in listView.Items)
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                               // Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: Matching item:  '"
                               //     + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Equals(searchData.ToLowerInvariant()))
                                {
                                    // Item found. Add the count.
                                    noOfItems++;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    default:
                        Utilities.LogMessage("<<Exception:: Invalid StringMatchAt in ConsoleApp.GetMatchingListViewItemsCount>> " + stringMatchAt.ToString());
                        throw new ArgumentException("Invalid string input for stringMatchAt in ConsoleApp.GetMatchingListViewItemsCount! >>"
                            + "'" + stringMatchAt.ToString() + "'");
                }// Switch
            }// if position =0
            else
            {
                // for all other column positions
                switch (stringMatchAt)
                {
                    case StringMatchAt.BeginsWith:
                        foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                              //  Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: Matching item:  '"
                              //      + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().StartsWith(searchData.ToLowerInvariant()))
                                {
                                    // Item found. Add the count.
                                    noOfItems++;
                                }
                            }
                        }//foreach ListView Item
                        break;

                    case StringMatchAt.Constains:
                        foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                               // Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount :: Matching item:  '"
                               //     + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                                {
                                    // Item found. Add the count.
                                    noOfItems++;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    case StringMatchAt.EndsWith:
                        foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                               // Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: Matching item:  '"
                               //     + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().EndsWith(searchData.ToLowerInvariant()))
                                {
                                    // Item found. Add the count.
                                    noOfItems++;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    case StringMatchAt.ExactMatch:
                        foreach (Maui.Core.WinControls.ListViewSubItem currentItem in listView.get_SubItems(columnPosition))
                        {
                            // if the current item has text that starts with the search text
                            if (currentItem.Text != null)
                            {
                               // Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount:: Matching item:  '"
                               //     + currentItem.Text.ToLowerInvariant() + "'");

                                if (currentItem.Text.ToLowerInvariant().Equals(searchData.ToLowerInvariant()))
                                {
                                    // Item found. Add the count.
                                    noOfItems++;
                                }
                            }
                        }//foreach ListView Item
                        break;
                    default:
                        Utilities.LogMessage("<<Exception>> Invalid input for stringMatchAt in ConsoleApp.SelectListViewItems>> " + stringMatchAt.ToString());
                        throw new ArgumentException("Invalid input string passed for stringMatchAt in ConsoleApp.SelectListViewItems! >>"
                            + stringMatchAt.ToString());
                }// Switch
            } // else for all other column positions

            if (noOfItems==0)
            {
                Utilities.LogMessage("ConsoleApp.GetMatchingListViewItemsCount :: No Matching item Found!!!");
            }
            
            return noOfItems;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// GeListViewtColumnPosition
        /// Returns the 1 based index of the column in the view based on the column name
        /// </summary>
        /// <param name="columnName">Column Name</param>
        /// <param name="listView">reference to the ListView control to search</param>
        /// <returns>1 based index of column</returns>
        /// <history>
        /// [mbickle] 24JUL06 Created        
        /// </history>
        /// ------------------------------------------------------------------
        public int GeListViewtColumnPosition(string columnName, Maui.Core.WinControls.ListView listView)
        {
            int columnCount = 0;
            int columnNamePosition = -1; // Does not exist.

            HeaderItemCollection columnHeaders = listView.Columns;

            // Get the Count of Columns.
            columnCount = columnHeaders.Count;
            Utilities.LogMessage("ConsoleApp.GeListViewtColumnPosition:: Column Header Count: " +
                columnCount.ToString());
            Utilities.LogMessage("ConsoleApp.GeListViewtColumnPosition:: Looking for Column Header: " 
                + columnName);

            for (int i = 0; i < columnCount; i++)
            {
                Utilities.LogMessage("ConsoleApp.GeListViewtColumnPosition:: Current Column Header: " +
                    columnHeaders[i].Text);
                Utilities.LogMessage("ConsoleApp.GeListViewtColumnPosition:: Current index is: " + i + " " + columnHeaders[i].Index);
                
                // Checks if ColumnHeader Name is what we are looking for.
                // Will only find first instance, so if there is a dupe it won't find it.
                if (String.Compare(columnHeaders[i].Text, columnName, true) == 0)
                {
                    columnNamePosition = columnHeaders[i].Index;    
                    ////TODO: uncomment this break before checkin
                    ////break; // break out of for loop if found.
                }
            }

            Utilities.LogMessage("ConsoleApp.GeListViewtColumnPosition:: This column name is in position : " +
                columnNamePosition.ToString());

            return columnNamePosition;
        }

        #endregion

        #region Toolbar Methods section

        /// <summary>
        /// This method is designed to click the toolbar button 
        /// whoose name is specified if the button is enabled. 
        /// </summary>
        /// <param name="toolBar">The toolbar.</param>
        /// <param name="buttonName">The name of the button.</param>
        /// <returns>The button clicked</returns>
        /// <exception cref="ArgumentOutOfRangeException">No matching button name</exception>
        /// <exception cref="ArgumentNullException">Unable to access the toolbar</exception>
        /// <exception cref="NullReferenceException">Unable to access buttons on the toolbar</exception>
        /// <exception cref="ArgumentException">Button specified is not enabled</exception>
        /// <history>
        /// [a-joelj]   09OCT09 Maui 2.0 Required change: Using toolBar.AccessibleObject or button.AccessibleObject to 
        ///                     get a control property now returns a NullReferenceException in Maui 2.0.
        ///                     Updated all instances of control.AccessibleObject to use Control.ScreenElement.WaitForReady()
        ///                     and Control.ScreenElement.Name in order to avoid NullReference.
        /// </history>
        public ToolbarItem InvokeToolBarButton(
            Toolbar toolBar,
            string buttonName)
        {
            Utilities.LogMessage("InvokeToolBarButton(...)");

            if (null == toolBar)
            {
                throw new ArgumentNullException("InvokeToolBarButton :" +
                    "Unable to access the toolbar");
            }

            ToolbarItem tmpButton = null;

            // Maui 2.0 Required Change: Use ScreenElement.WaitForReady
            // Wait for the tool strip to be ready
            toolBar.ScreenElement.WaitForReady();

            //UISynchronization.WaitForUIObjectReady(
            //    toolBar.AccessibleObject,
            //    Constants.DefaultDialogTimeout);
            
            Utilities.LogMessage("InvokeToolBarButton :" +
                "tool strip is ready.");

            Utilities.LogMessage("InvokeToolBarButton :" +
                "Invoking a button on the tool strip.");

            // Get the instances
            ToolbarItemCollection buttons =
                toolBar.get_ToolbarItems(true);
            if (null == buttons)
            {
                throw new NullReferenceException("InvokeToolBarButton :" +
                    "Unable to access the buttons on the toolbar");
            }

            #region match button caption

            bool matched = false;
            Utilities.LogMessage("InvokeToolBarButton:: " +
                "Looking for match to button caption: " + buttonName);
            foreach (ToolbarItem button in buttons)
            {
                // Maui 2.0 Required Change: Use button.ScreenElement.Name in multiple places to
                //                           safely access button name without NullRef
                Utilities.LogMessage("InvokeToolBarButton:: " +
                    "button name: " + button.ScreenElement.Name);

                // Maui 2.0 Required Change: Use button.KeyboardShortcut
                Utilities.LogMessage("InvokeToolBarButton:: " +
                    "button shortcut: " + button.KeyboardShortcut);

                // Do button name comparison after removing the shortcut character. 
                if (button.ScreenElement.Name == buttonName.Replace("&", ""))
                {
                    if (button.Enabled)
                    {
                        matched = true;
                        Utilities.LogMessage("InvokeToolBarButton:: " +
                            "Clicking tool bar button: " + button.ScreenElement.Name);
                        
                        // Click the ToolBar button
                        button.Click();

                        Utilities.LogMessage("InvokeToolBarButton:: " +
                            "Clicked tool bar button: " + button.ScreenElement.Name);

                        // Found the button, save a reference to it and stop looking.
                        tmpButton = button;
                        break;
                    }
                    else
                    {
                          Utilities.LogMessage("InvokeToolBarButton:: " +
                            button.ScreenElement.Name +
                            " is not Enabled.");
                    }
                }
                else
                {
                    Utilities.LogMessage("InvokeToolBarButton:: " +
                        "No match for button name: " +
                        buttonName.Replace("&", ""));
                }
            }   // foreach

            if (matched == false)
            {
                throw new ArgumentOutOfRangeException("buttonName", "No matching button name for: " + buttonName);
            }

            #endregion  //  match button caption

            return tmpButton;
        }
        
        #endregion

        public virtual void ExecuteWindowMenuItem(Window window, params string[] menupath)
        {
            QID queryId = new QID(";[UIA]AutomationId=\'" + "menuStrip" + "\'");

            ExecuteWindowMenuItem(window, queryId, menupath);
        }

        /// <summary>
        /// Executes an arbitrarily deep menu path on a Maui Window (not an Application).
        /// </summary>
        /// <param name="window">a Maui Window (not an Application)</param>
        /// <param name="menupath">an arbitrarily deep menu path (of comma-delimited strings)</param>
        /// <example>
        /// Taken from Edit() method in DistibutedAppCollection.cs
        /// 
        /// MomConsoleApp app = CoreManager.MomConsole;
        /// DesignSurface designSurface = new DesignSurface(app);
        /// app.ExecuteWindowMenuItem(designSurface, Strings.MenuBarFileOption, Strings.FileMenuPropertiesOption);
        /// </example>
        public virtual void ExecuteWindowMenuItem(Window window, QID queryId, params string[] menupath)
        {
            int maxTries = 3;
            int tries = 0;
            while (tries < maxTries)
            {
                Utilities.LogMessage("Executing " + String.Join("|", menupath));
                int i = 0;
                try
                {
                    Menu menu = new Menu(window, queryId, Constants.DefaultContextMenuTimeout);
                    
                    //execute first level (i=0)
                    menu.ScreenElement.WaitForReady();
                    menu.ExecuteMenuItem(menupath[i]);

                    if (menupath.Length > 1)
                    {
                        MenuItem menuitem = new MenuItem(menu, menupath[1]);

                        Utilities.LogMessage("ConsoleApp.ExecuteWindowMenuItem :: On menu item: " + menupath[1]);
                        menuitem.ScreenElement.WaitForReady();
                        menuitem.Execute();
                        MenuItem submenuitem = menuitem;

                        for (i = 2; i < menupath.Length; i++)
                        {
                            submenuitem = new MenuItem(submenuitem, menupath[i]);
                            Utilities.LogMessage("ConsoleApp.ExecuteWindowMenuItem :: On menu item: " + menupath[i]);
                            submenuitem.ScreenElement.WaitForReady();
                            submenuitem.Execute();
                        }

                        Utilities.LogMessage("Menu operation successful.");
                        break;
                    }
                }
                catch (Exception x)
                {
                    tries++;
                    Utilities.TakeScreenshot("Failed to execute menu item " + menupath[i]);
                    Utilities.LogMessage(x.ToString());
                }
            }
        }

        /// <summary>
        /// Executes a deep menu path on an Application. Use a path delimiter from Constants!
        /// </summary>
        /// <param name="contextMenuPath">Path(string) of context menu items with path delimiters</param>
        /// <param name="shiftF10">Boolean Shift+F10, if false the item has to be selected</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="Maui.Core.WinControls.MenuItem.Exceptions.MenuItemNotFoundException">Maui.Core.WinControls.MenuItem.Exceptions.MenuItemNotFoundException</exception>
        public virtual void ExecuteContextMenu(string contextMenuPath, bool shiftF10)
        {
            this.ExecuteContextMenu(contextMenuPath, shiftF10, Constants.DefaultContextMenuTimeout);
        }

        /// <summary>
        /// Method to Execute menu item for statewidget.
        /// </summary>
        /// <param name="contextMenuPath">Path(string) of context menu items with path delimiters</param>

        public virtual void ExecuteDashboardContextMenu(string contextMenuPath)
        {
            this.ExecuteDashboardContextMenu(contextMenuPath, false); 
        }

        /// <summary>
        /// Method to Execute menu item for dashboard.
        /// </summary>
        /// <param name="contextMenuPath">Path(string) of context menu items with path delimiters</param>
        public virtual void ExecuteDashboardContextMenu(string contextMenuPath, bool sendKey)
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    contextMenuPath = contextMenuPath.Replace(" ", "");
                    this.ExecuteContextMenu(contextMenuPath, sendKey, Constants.DefaultContextMenuTimeout);
                    break;
                case ProductSkuLevel.Web:
                    contextMenuPath = contextMenuPath.Replace(" ", "_");
                    IScreenElement menuItem = this.MainWindow.ScreenElement.FindByPartialQueryId(string.Format(";[UIA, VisibleOnly]Name = '_{0}'", contextMenuPath), null);
                    menuItem.LeftButtonClick(-1, -1);
                    break;
                default:
                    throw new System.InvalidOperationException("ExecuteDashboardContextMenu:: Invalid Product Sku");
            }
        }

        /// <summary>
        /// Executes a deep menu path on an Application. Use a path delimiter from Constants!
        /// </summary>
        /// <param name="contextMenuPath">Path(string) of context menu items with path delimiters</param>
        /// <param name="shiftF10">Boolean Shift+F10, if false the item has to be selected</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="Maui.Core.WinControls.MenuItem.Exceptions.MenuItemNotFoundException">Maui.Core.WinControls.MenuItem.Exceptions.MenuItemNotFoundException</exception>
        /// <history>
        /// [mbickle] 18MAR09 - added new overload to accept timeout value and replace hardcoded retry count.
        /// </history>
        public virtual void ExecuteContextMenu(string contextMenuPath, bool shiftF10, int timeout)
        {
            // Validate taht contextmenupath parameter isn't null.
            if (contextMenuPath == null)
            {
                throw new ArgumentNullException("contextMenuPath", "ConsoleApp:ExecuteContextMenu:: contextmenupath is Null");
            }

            Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: Menu Path: " + contextMenuPath);
            Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: Use shiftF10: " + shiftF10.ToString());
            Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: Timeout: " + timeout.ToString());

            char[] delimiter = Constants.PathDelimiter.ToCharArray();
            Menu menuItem;
            string[] menupath = null;
            Sleeper sleeper = new Sleeper(timeout, 1000, 2000);

            menupath = contextMenuPath.Split(delimiter);

            while (sleeper.IsNotExpired)
            {
                int i = 0;
                try
                {
                    if (shiftF10)
                    {
                        Utilities.TakeScreenshot("after ShiftF10...");
                        menuItem = new Menu(ContextMenuAccessMethod.ShiftF10);
                        Utilities.TakeScreenshot("after ShiftF10...");
                    }
                    else
                    {
                        menuItem = new Menu(this.MainWindow, QueryIds.MenuContext, Constants.DefaultContextMenuTimeout);
                    }
                    Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: Found menu");

                    menuItem.ScreenElement.WaitForReady();
                    MenuItem submenuitem = new MenuItem(menuItem, menupath[0]);
                    Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: Found menu item");
                    submenuitem.ScreenElement.WaitForReady();
                    Utilities.TakeScreenshot("Before click...");
                    submenuitem.ScreenElement.LeftButtonClick(-1, -1);
                    Utilities.TakeScreenshot("after click...");
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                    Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: First click on menu item: " + menupath[i]);

                    // we must new menuitem by using its parent menu
                    if (menupath.Length > 1)
                    {
                        for (i = 1; i < menupath.Length; i++)
                        {
                            submenuitem = new MenuItem(submenuitem, menupath[i]);
                            Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: On menu item: " + menupath[i]);
                            submenuitem.ScreenElement.WaitForReady();
                            submenuitem.ScreenElement.LeftButtonClick(-1, -1);
                            Sleeper.Delay(Core.Common.Constants.OneSecond);
                        }
                    }
                    
                    Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: Menu operation successful.");
                    break;
                }
                catch (Exception x)
                {
                    Utilities.TakeScreenshot("Failed to execute menu item " + menupath[i]);
                    Utilities.LogMessage("ConsoleApp.ExecuteContextMenu:: Exception: " + x.ToString());

                                    sleeper.Sleep();
                    if (sleeper.IsExpired)
                    {
                        throw;
                    }
                }

                Utilities.LogMessage("ConsoleApp.ExecuteContextMenu :: Trying again.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Expand the TreePath 
        /// </summary>
        /// <param name="nodePath">Full path to Node</param>
        /// <param name="treeView">TreeView name</param>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException"></exception>
        /// <returns>TreeNode</returns>
        /// <history>
        /// [mbickle] 28SEP05 Using StringBuilder now.
        /// [mbickle] 12OCT05 Modified so if can't find node reset index and try again from the top.
        ///                   This was done because sometimes the nodes take a moment to become expandable.
        /// [mbickle] 22JUN06 Copied from NavPane class and made public so it can be used in other places.
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete ("Use TreeView class directly")]
        public TreeNode ExpandTreePath(string nodePath, MomControls.TreeView treeView)
       // public TreeNode ExpandTreePath(string nodePath, TreeView treeView)
        {
            Utilities.LogMessage("ConsoleApp.ExpandTreePath::");
            return treeView.ExpandTreePath(nodePath);
            /*TreeNode treeNode = null;
            char[] delimiter = Constants.PathDelimiter.ToCharArray();
            StringBuilder nodes = new StringBuilder();
            string[] treeNodes = null;

            Utilities.LogMessage("ConsoleApp.ExpandTreePath:: Split Path");
            treeNodes = nodePath.Split(delimiter);

            int retry = 0;
            int maxRetry = 5;
            int nodeFindRetry = 0;

            // Loop through the nodePath and expand the nodes
            for (int index = 0; index < treeNodes.Length; index++)
            {
                treeNode = null;
                nodes.Append(treeNodes[index]);
                Utilities.LogMessage("ConsoleApp.ExpandTreePath:: Path: " + nodes);

                retry = 0;

                // Attempting to get NodeByPath and setting treeNode
                while (treeNode == null && retry < maxRetry)
                {
                    try
                    {
                        // If node has a PathDelimiter we'll use GetNodeByPath
                        if (nodes.ToString().Contains(Constants.PathDelimiter))
                        {
                            Utilities.LogMessage("ConsoleApp.ExpandTreePath:: GetNodeByPath: " + nodes);
                            treeNode = treeView.GetNodeByPath(nodes.ToString(), Constants.PathDelimiter, 1, false);
                        }
                        else
                        {
                            // No PathDelimiter in Node so using basic Find.
                            Utilities.LogMessage("ConsoleApp.ExpandTreePath:: Find node: " + nodes);
                            treeNode = treeView.Find(nodes.ToString(), 1, false);
                        }
                    }
                    catch (TreeNode.Exceptions.InvalidFullPathException ex)
                    {
                        // Only Log if hit maxRetry to cut down on noise.
                        if (retry == maxRetry)
                        {
                            Utilities.TakeScreenshot("ConsoleApp_ExpandTreePath_InvalidFullPathException");
                            Utilities.LogMessage("ConsoleApp.ExpandTreePath:: TreeNode.Exceptions.InvalidFullpathException: " + ex);
                            Utilities.LogMessage("ConsoleApp.ExpandTreePath:: retry: " + retry.ToString());
                        }

                        Sleeper.Delay(1000);
                    }
                    catch (TreeNode.Exceptions.NodeNotFoundException ex)
                    {
                        // Only Log if hit maxRetry to cut down on noise.
                        if (retry == maxRetry)
                        {
                            Utilities.TakeScreenshot("ConsoleApp_ExpandTreePath_NodeNotFoundException");
                            Utilities.LogMessage("ConsoleApp.ExpandTreePath:: TreeNode.Exceptions.NodeNotFoundException: " + ex);
                            Utilities.LogMessage("ConsoleApp.ExpandTreePath:: retry: " + retry.ToString());
                        }

                        Sleeper.Delay(1000);
                    }

                    retry++;
                }

                // Check to make sure TreeNode isn't null
                if (treeNode == null && nodeFindRetry <= maxRetry)
                {
                    // Tree Node is null, so increment retry count and try again.
                    nodeFindRetry++;

                    // Reset Index
                    index = -1;

                    // Clear what was already added.
                    nodes.Remove(0, nodes.Length);

                    if (nodeFindRetry == maxRetry)
                    {
                        Utilities.LogMessage("ConsoleApp.ExandTreePath:: Node not found, hit max retry");
                        Utilities.TakeScreenshot("ConsoleApp_NodeNotFound");
                    }
                }
                else
                {
                    if (treeNode == null)
                    {
                        throw new TreeNode.Exceptions.NodeNotFoundException("ConsoleApp.ExpandTreePath:: treeNode was null after max nodeFindRetry");
                    }

                    Utilities.LogMessage("ConsoleApp.ExpandTreePath:: Expand TreeNode.");
                    bool expanded = false;
                    retry = 0;

                    // Retry logic as sometimes we get a ChildNotFoundException here 
                    // when trying to expand tree node.
                    while (!expanded && retry < maxRetry)
                    {
                        try
                        {
                            if (treeNode.IsExpandable)
                            {
                                Utilities.LogMessage("Navigation.ExpandTreePath: Expanding TreeNode");
                                treeNode.Expand(true);
                                UISynchronization.WaitForUIObjectReady(treeNode.AccessibleObject, Constants.DefaultDialogTimeout);

                                if (treeNode.Expanded)
                                {
                                    Utilities.LogMessage("Navigation.ExpandTreePath: TreeNode Expanded");
                                    expanded = true;
                                }
                            }
                            else
                            {
                                expanded = true;
                            }
                        }
                        catch (Maui.Core.ActiveAccessibility.Exceptions.ChildNotFoundException ex)
                        {
                            // Only Log if hit maxRetry to cut down on noise.
                            if (retry == maxRetry)
                            {
                                Utilities.TakeScreenshot("ConsoleApp_ExpandTree_ChildNotFoundException");
                                Utilities.LogMessage("ConsoleApp.ExpandTreePath:: ActiveAccessibility.Exception.ChildNotFound: " + ex);
                            }
                        }

                        Sleeper.Delay(1000);
                        Utilities.LogMessage("ConsoleApp.ExpandTreePath:: Expand Node retry: " + retry.ToString());
                        retry++;
                    }

                    Utilities.LogMessage("ConsoleApp.ExpandTreePath:: Wait for UI to settle.");
                    this.WaitForWindowIdle(treeView.Extended.AccessibleObject.Window, 30000);
                    nodes.Append(Constants.PathDelimiter);
                }
            }

            // Check to make sure TreeNode isn't null
            if (treeNode == null)
            {
                Utilities.TakeScreenshot("ConsoleApp_NodeNotFound");
                throw new TreeNode.Exceptions.NodeNotFoundException("ConsoleApp.ExpandTreePath:: Failed to find Node: " + nodePath);
            }

            return treeNode;*/
        }

        /// <summary>
        /// Waits until the current mouse cursor type changes from the specified one. Max wait is 2 mins
        /// </summary>
        /// <param name="cursorType">cursorType that you want to wait on</param> 
        /// <param name="maxWaitSeconds">Maximum time in seconds to wait for the cursor state to change</param>
        /// <history>
        ///     [ruhim] 10Jul06 - Created          
        /// </history>
        [Obsolete("use Waiters ConsoleApp WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType cursorType, int timeout)")]
        public void WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType cursorType, int maxWaitSeconds)
        {
            this.Waiters.WaitUntilCursorType(cursorType, maxWaitSeconds);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on ToolbarItem ConsoleToolBarItemFind
        /// </summary>
        /// <history>
        /// 	[a-joelj]   28DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConsoleToolBarItemFind()
        {
            this.Controls.ConsoleToolBarItemFind.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on ToolbarItem ConsoleToolBarItemScope
        /// </summary>
        /// <history>
        /// 	[a-joelj]   28DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConsoleToolBarItemScope()
        {
            this.Controls.ConsoleToolBarItemScope.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on ToolbarItem ConsoleToolBarItemActions
        /// </summary>
        /// <history>
        /// 	[a-joelj]   28DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickConsoleToolBarItemActions()
        {
            this.Controls.ConsoleToolBarItemActions.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// This method checks if findbar is visible in ViewPane,
        /// If it is not present, click Find button in toolbar
        /// Make sure findbar is shown, then can find specific row(s) by setting lookfor text box
        /// </summary>        
        /// ------------------------------------------------------------------
        /// <history>
        /// 	[v-juli]   8June10 Created
        /// </history>
        public static void CheckAndMakeFindbarVisible()
        {
            //Add retry logic to make sure FindBar is available in UI. 
            int retryFind = 10;
            for (int i = 0; i < retryFind; i++)
            {
                try
                {
                    if (CoreManager.MomConsole.ViewPane.Find.Controls.FindNowButton.Extended.IsVisible)
                    {
                        //clear first to get to the original state
                        CoreManager.MomConsole.ViewPane.Find.Controls.ClearButton.Click();
                        CoreManager.MomConsole.Waiters.WaitForStatusReady();
                        Utilities.LogMessage("CheckAndMakeFindbarVisible:: FindNowButton is visible after " + i + " seconds.");
                        break;
                    }
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
                {                    
                    Core.Common.Utilities.LogMessage("CheckAndMakeFindbarVisible:: Findbar does not display in UI, click Find Button in tool bar to make it show.");
                    Core.Common.Utilities.LogMessage("CheckAndMakeFindbarVisible:: Click Find Button in ToolBar...");

                    CoreManager.MomConsole.ClickConsoleToolBarItemFind();
                    //this.ClickConsoleToolBarItemFind();
                    Utilities.LogMessage("CheckAndMakeFindbarVisible:: Sleep one second to wait FindNowButton Ready.");
                    Sleeper.Delay(Core.Common.Constants.OneSecond);

                    if (++i == retryFind) 
                        throw ex;
                }
            }
            
        }

        #endregion

        #region Private Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Delegate for ResourceManager.ResourceExtract/ResourceFetcher()
        /// Handles issue when can't resolve assembly dependency with BAML
        /// resource extraction.
        /// </summary>
        /// <remarks>
        /// Assuming the dependency file is located in a directory below the 
        /// the file being searched, based off .NET probing rules.  So we get 
        /// the path to the file being searched and scan all files/directories 
        /// below it for the dependent file if necessary.  
        /// 
        /// If the dependent file is located in the same place as the file 
        /// being searched or is in the GAC there's no problem, and this is 
        /// ignored.
        /// </remarks>
        /// <param name="assemblyName">Assembly Name</param>
        /// <param name="searchPattern">Search Pattern</param>
        /// <param name="searchOption">Search Option</param>
        /// <returns>Search Path</returns>
        /// ------------------------------------------------------------------
        private string AssemblyResolveCallback(string assemblyName, ref string searchPattern, ref System.IO.SearchOption searchOption)
        {
            //// Utilities.LogMessage("ConsoleApp.AssemblyResolveCallback:: assemblyName:: {0}", assemblyName);

            // Get get the file name and ignore all the other stuff (version#, etc.)
            string assemblyFileName = assemblyName.Split(',')[0];
            string searchPath = string.Empty;

            searchPattern = assemblyFileName + ".*";
            searchOption = System.IO.SearchOption.AllDirectories;

            // Stripping off the file name and just getting the path to start our search.
            int index = this.resourceFileNamePath.LastIndexOf("\\");
            searchPath = this.resourceFileNamePath.Substring(0, index);

            //// Utilities.LogMessage("AssemblyResolveCallback:: searchPath:: {0} ", searchPath);
            return searchPath;
        }

        /// <summary>
        /// Multiple Init overloads are used so that each consoleapp constructor will call into the same init method
        /// The init method is used to run startup code before starting the application
        /// </summary>
        /// <returns>updated parameters ready for the App base class</returns>
        /// <history>
        /// [billhodg] 25APR10 created
        /// </history>
        private static ConsoleAppParameters Init()
        {
            return Init(new ConsoleAppParameters());
        }

        /// <summary>
        /// Multiple Init overloads are used so that each consoleapp constructor will call into the same init method
        /// The init method is used to run startup code before starting the application 
        /// </summary>
        /// <param name="arguments">a string that can be converted to the AppParameters</param>
        /// <returns>updated parameters ready for the App base class</returns>
        /// <history>
        /// [billhodg] 25APR10 created
        /// </history>
        private static ConsoleAppParameters Init(string arguments)
        {
            return Init(new ConsoleAppParameters(arguments));
        }

        /// <summary>
        /// The init method is used to run startup code before starting the application
        /// In the case of the Browser, this is where we launch it. We then pass the procid on
        /// to the app class.        
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>updated parameters ready for the App base class</returns>
        /// <history>
        /// [billhodg] 25APR10 created
        /// </history>
        private static ConsoleAppParameters Init(ConsoleAppParameters parameters)
        {
            Utilities.LogMessage("ConsoleApp.Init");

            // Disable the Dr. Watson UI from popping up.
            Utilities.ShowDrWatsonUI(false);


            if (parameters.SkuLevel != ProductSkuLevel.Mom)
            {
                //we have different url to navigate to for Sku.Web and Sku.SharePoint
                string url = null;
                switch (parameters.SkuLevel)
                {
                    case ProductSkuLevel.Web:
                        url = WebServerUrl;
                        break;

                    case ProductSkuLevel.SharePoint:
                        SharePoint.MomWebPart omWebPart = new SharePoint.MomWebPart();
                        url = omWebPart.SharePointUrl;
                        break;
                }
                Utilities.LogMessage("Launching Browser for url = " + url);               

                // Kill all instances of IE... 
                // We do not currently support multiple instances of IE running with our 
                // UI automation. When there are multiple instances of IE running on the box
                // we will fail to get a handle to IE. There are multiple test areas (WebPageView
                // and MP) that launch IE so that proxy settings take effect, but they do not 
                // always kill IE (timing issues it appears...). Therefore we are going to 
                // forcefully kill all instances of iexplore.exe.
                System.Diagnostics.Process[] ieProcesses = System.Diagnostics.Process.GetProcessesByName("iexplore");

                if (ieProcesses.Length > 0)
                {
                    Utilities.LogMessage(String.Format("ConsoleApp.Init :: Found {0} iexplore.exe processes", ieProcesses.Length));

                    foreach (System.Diagnostics.Process process in ieProcesses)
                    {
                        // Check to make sure the process is still running.
                        if (process.HasExited == false)
                        {
                            Utilities.LogMessage(String.Format("ConsoleApp.Init :: Killing iexplore.exe process {0}", process.Id));
                            process.Kill();
                        }
                        else
                        {
                            Utilities.LogMessage(String.Format("ConsoleApp.Init :: iexplore.exe process {0} is no longer running", process.Id));
                        }
                    }
                }
                
                // Launch the Browser
                parameters.ProcId = 0;
                Browser browser = new Browser(parameters.BrowserType);

                // Web Console Configuration
                WebConsoleConfigurationManager webConsoleCfgMgr = WebConsoleConfigurationManager.Instance;
                webConsoleCfgMgr.SetAutoSignOutInterval(0);   // Disable Auto Signout
                webConsoleCfgMgr.SetAutoSignIn(parameters.AutoSignIn); // Enable/Disable AutoSignIn

                //to check if we need to attach to an existing browser instance
                if (parameters.FindExistingConsoleRunning)
                {
                    try
                    {
                        Utilities.LogMessage("Trying to find existing instance of browser, timeout 10 seconds.");
                        browser.Find(url, Constants.OneSecond*10);
                    }
                    catch
                    {
                        Utilities.LogMessage("No existing browser instance found, launching a new instance.");
                        browser.Launch(url, parameters.SkuLevel);
                    }
                }
                else
                {
                    browser.Launch(url, parameters.SkuLevel);
                }
                browser.WaitForReady(browser.PageLoadWaitTime * 3);// Increase wait time due to IE performance

                // TODO: This method needs to be replaced with something more robust. We have a global non-ui element that 
                // provides console status (ready, busy). This status indicator needs to be encapsulated somewhere.
                //VerifyConsoleStartup(browser.Application.MainWindow, ConsoleConstants.DefaultAppStartupTimeout);

                //set the parameters so that App will refer to the Browser
                parameters.ProcId = browser.Application.Process.Id;

                if (parameters.ProcId == 0)
                {
                    throw new InvalidOperationException("Browser process could not be found");
                }

                Utilities.LogMessage("Browser launched, Process Id = " + parameters.ProcId.ToString());
            }

            return UpdateParameters(parameters);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Corrects application parameters structure for base App constructor.
        /// </summary>
        /// <param name="parameters">ConsoleAppParameters</param>
        /// <returns>Parameters</returns>
        /// <history>
        ///	[mbickle] 03AUG05 Created
        /// [mbickle] 13SEP05 Added call to Turn off the DrWatson UI.
        /// [billhodg] 25APR10 moved init code out to init function
        /// </history>
        /// ------------------------------------------------------------------
        private static ConsoleAppParameters UpdateParameters(ConsoleAppParameters parameters)
        {
            Utilities.LogMessage("ConsoleApp.UpdateParameters:: ");

            try
            {
                parameters.Timeout = Constants.DefaultAppStartupTimeout;

                //Added to get handle to splash screen
                if (parameters.PreMainWindowDialogHandler == null && parameters.SkuLevel == ProductSkuLevel.Mom)
                {
                    parameters.PreMainWindowDialogHandler = new AppDialogHandler(SplashScreenHandler);
                }

                if (parameters.CustomLaunchHandler == null && parameters.SkuLevel == ProductSkuLevel.Mom)
                {
                    parameters.CustomLaunchHandler = new AppLaunchHandler(RunAsDifferentUserHandler);
                }

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.ErrorCode == 1247)
                {
                    Utilities.LogMessage("ConsoleApp.UpdateParameters:: RPF already Initialized: ErrorCode: " + ex.ErrorCode);
                }
                else
                {
                    throw;
                }
            }

            return parameters;
        }

        #endregion

        /// ------------------------------------------------------------------
        /// <summary>
        /// Spalsh Screen Handler To wait for Splash Screen to go away
        /// </summary>
        /// <history>
        ///     [sunsingh] 31March 2010: Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void SplashScreenHandler(App app, AppParameters appParams)
        {
            try
            {
                Utilities.LogMessage("SplashSCreenHandler.Start");

                // Setting appParams.Timeout to 2 minute
                //appParams.Timeout = Constants.OneMinute * 2;

                //// probably should wrap this in a try/catch in case the SplashScreen
                //// has already gone away or something.  
                //Window splashScreen = new Window(new QID(";ClassName = 'SplashScreen'"), (Constants.DefaultDialogTimeout * 8));

                //try
                //{
                //    splashScreen.ScreenElement.WaitForGone(appParams.Timeout, 1);
                //    Utilities.LogMessage("SplashSCreenHandler.Done");
                //    return;
                //}
                //catch (System.InvalidOperationException invalidOperationException)
                //{
                //    Utilities.TakeScreenshot("Splash Screen System.invalidOperationException");
                //    Utilities.LogMessage("Splash Screen Invalid Operation Exception" + invalidOperationException);
                //}

                //int retry = 0;
                //int maxTries = 60;
                //while ((splashScreen != null) && (retry < maxTries))
                //{
                //    retry++;
                //    Utilities.LogMessage("SplashScreenHandler :: Waiting for splash screen gone, retry " + retry);
                //    Sleeper.Delay(Constants.OneSecond);

                //    splashScreen = new Window(new QID(";ClassName = 'SplashScreen'"), Constants.DefaultDialogTimeout);
                //}

                Utilities.LogMessage("SplashSCreenHandler.Done");

            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("SplashSCreenHandler:: Doesn't find SplashSCreen");
                Utilities.TakeScreenshot("Splash Screen Maui.Core.Window.Exceptions.WindowNotFoundException");
            }
        }

        /// <summary>
        /// Launch product (for the desktop console only) as another user if specified environment variable exists
        /// </summary>
        /// <param name="app">App</param>
        /// <param name="appParams">app parameters</param>
        /// <returns>0 means no operation, and product not launched, otherwise returns the process id of the product instance</returns>
        public static int RunAsDifferentUserHandler(App app, AppParameters appParams)
        {
            string logHeader = MethodBase.GetCurrentMethod().Name + " :: ";

            string runAsUser = Environment.GetEnvironmentVariable("RunAsUser");
            string password = Environment.GetEnvironmentVariable("Password");


            if (!string.IsNullOrEmpty(runAsUser) && !string.IsNullOrEmpty(password))
            {
                Utilities.LogMessage(logHeader + string.Format("Found run as user info, runasuser:{0}, password:{1}", runAsUser, password));

                #region get domain name and user name from runAsUser
                string domainName = string.Empty;
                string userName = string.Empty;
                string[] userInfo = runAsUser.Split('@', '\\'); // 2 format: 1) domain\username 2) username@domain
                bool isCompatibleFormat = runAsUser.IndexOf('@') != -1;   // to determine the user accont format
                if (userInfo.Length == 2)    // contains domain name and user name
                {
                    domainName = isCompatibleFormat ? userInfo[1] : userInfo[0];
                    userName = isCompatibleFormat ? userInfo[0] : userInfo[1];
                }
                else if (userInfo.Length == 1)  // assume only has user name
                {
                    domainName = Environment.MachineName;
                    userName = userInfo[0];
                }
                else
                {
                    throw new ArgumentException("runAsUser", @"invalid format, should be 1) domain\username 2) username@domain 3) username");
                }

                Utilities.LogMessage(logHeader + string.Format("domain:{0}, username:{1}", domainName, userName));

                if (string.Equals(Environment.UserName, userName, StringComparison.CurrentCultureIgnoreCase))
                {
                    Utilities.LogMessage("Run as user name equals current logon user name, ignore it.");
                    return 0;
                }
                #endregion

                System.Security.SecureString securePassword = new System.Security.SecureString();
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }

                Utilities.LogMessage(logHeader + "Launch product as specified user account");

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = appParams.ExePath;
                process.StartInfo.Arguments = appParams.Arguments;
                process.StartInfo.WorkingDirectory = Directory.GetParent(appParams.ExePath).FullName;
                process.StartInfo.Domain = domainName;
                process.StartInfo.UserName = userName;
                process.StartInfo.Password = securePassword;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.LoadUserProfile = true;
                process.Start();

                if (appParams.PreMainWindowDialogHandler != null)
                {
                    appParams.PreMainWindowDialogHandler(app, appParams);
                }

                Utilities.LogMessage(logHeader + "Product launched successfully, the process id is " + process.Id);
                return process.Id;
            }
            else
            {
                Utilities.LogMessage(logHeader + string.Format("runasuser:{0}", string.IsNullOrEmpty (runAsUser) ? "<null>" : runAsUser));
                Utilities.LogMessage(logHeader + string.Format("password:{0}", string.IsNullOrEmpty(password) ? "<null>" : password));
            }

            return 0;
        }

        /// <summary>
        /// Verifies that the console controls are displayed and ready for use
        /// This was created becuase there's a long wait before the web console is ready for use
        /// even after the IE thinks the page is loaded. The best way to deal with this is to ask the console
        /// if it's ready. The console, in turn, would ask the controls if they are ready.
        /// </summary>
        /// <param name="parentWindow">the console window. This is required because CoreManager may not be set yet</param>
        /// <param name="timeout">timeout in ms. DefaultWaitForReadyTimeout is a good value here</param>
        private static void VerifyConsoleStartup(Window parentWindow, int timeout)
        {
           
            if (ProductSkuLevel.Mom == ProductSku.Sku)
            {
                // do nothing here for now
            }
            else //web/sharepoint
            {
                //TODO: change this to ask wunderbar if it's loaded after the wunderbar code supports the WebConsole

                //try to find the web console navigation pane menu item scroll viewer, this can make sure web console wunder bar is displayed
                try
                {
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Web:
                            Window webConsoleNaviPane = new Window(parentWindow, MomControls.WunderBar.QueryIds.WebConsoleNaviPane, Constants.DefaultAppStartupTimeout);
                            break;
                        case ProductSkuLevel.SharePoint:
                            //we don't know which view will be configured in the webpart, do nothing here
                            break;
                    }
                    //Window webConsoleNaviPane = new Window(parentWindow, MomControls.WunderBar.QueryIds.WebConsoleNaviPane, Constants.DefaultAppStartupTimeout);
                }
                catch
                {
                    throw new Window.Exceptions.WindowNotFoundException("Web console is not completely loaded");
                }
            }

        }

        #region Strings Class

        /// ------------------------------------------------------------------
        /// <summary>
        /// Updated string definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle]   13JUL05 Created
        /// 	[v-waltli]  09APR09 Added Manual Agent Install dialog buttons string definitions
        /// 	[a-joelj]   28DEC09 Added resource strings to get localized names for the common
        /// 	                    Find/Scope/Actions ToolbarItems contained in the ConsoleToolBarCommandBar
        /// 	                    panel
        /// 	[v-vijia]   14JUN11 Added resource string to get Remove Widget Confirmation dialog title translated. 
        /// </history>
        /// ------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the WebConsole dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWebConsoleDialogTitle = 
                ";[UIA]Name => 'Operations Manager Web Console' && Role = 'window';Role = 'pane' && ClassName = 'Frame Tab';Name => 'Operations Manager Web Console' && Role = 'pane';Role = 'pane' && ClassName = 'Shell DocObject View';Name => 'Operations Manager Web Console' && Role = 'pane';Name = \'{0}\' && Role = 'window'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = 
                ";System Center Operations Manager 2012" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.Monitoring.Console.exe" +
                ";Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources" +
                ";ProductTitle";

            /// <summary>
            /// Contains resource string for Remove Widget Confirmation dialog title
            /// </summary>
            private const string ResourceRemoveWidgetConfirmationDialogTitle = 
                ";Remove Widget Confirmation" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.Monitoring.Components.dll" +
                ";Microsoft.EnterpriseManagement.Monitoring.Components.UnitComponents.Layout.LayoutResources" +
                ";GridLayoutClearCaption";

            /// <summary>
            /// Contains resource string for Remove Column Confirmation dialog title
            /// </summary>
            private const string ResourceRemoveColumnConfirmationDialogTitle = 
                ";Remove Column Confirmation" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.Monitoring.Components.dll" +
                ";Microsoft.EnterpriseManagement.Monitoring.Components.UnitComponents.Layout.LayoutResources" +
                ";FlowLayoutDeleteCaption";

            /// <summary>
            /// Contains resource string for a SQL Connection dialog title.
            /// </summary>
            ////Todo: Replace with resource permanent id.
            private const string ResourceSQLDialogTitle = "SQL Connection Error";

            /// <summary>
            /// Contains resource string for a Word dialog title. Used to close the 
            /// AutoRecovery dialog.
            /// </summary>
            ////Todo: Replace with resource permanent id.
            private const string ResourceWordDialogTitle = "Microsoft Office Word";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FindButtonText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFindButtonText = 
                ";Fi&nd" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources" +
                ";FindButtonText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConsoleToolBarCommandBar
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceConsoleToolBarCommandBar = "ConsoleToolBarCommandBar";

            /// <summary>
            /// Contains resource string for:  Find ToolbarItem caption in ConsoleToolBarCommandBar.
            /// </summary>
            private const string ResourceConsoleToolBarItemFind = 
                ";Fi&nd;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources;" +
                "FindButtonText";

            /// <summary>
            /// Contains resource string for:  Scope ToolbarItem caption in ConsoleToolBarCommandBar.
            /// </summary>
            private const string ResourceConsoleToolBarItemScope =
                ";Sco&pe;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource;" +
                "ShowHideMonitoringScopeCommand_Text";

            /// <summary>
            /// Contains resource string for:  Actions ToolbarItem caption in ConsoleToolBarCommandBar.
            /// </summary>
            private const string ResourceConsoleToolBarItemActions =
                ";Actions;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;" +
                "Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;" +
                "ShowHideActionsPaneText";

            /// <summary>
            /// Contains resource string for:  Monitoring Configuration Filter Panel.
            /// </summary>
            private const string ResourceMonitoringConfigurationFilterPanel =
                ";filterPanel;ManagedString;Microsoft.MOM.UI.Console.exe;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Console." +
                "WunderBarPages.Monitoring.MonitoringPage;filterPanel.Text";

            /// <summary>
            /// Contains resource string for:  SystemYesButton
            /// </summary>
            private const string ResourceSystemYesButtonMom = ";&Yes;Win32DialogItemString;shell32.dll;1009;261";
            private const string ResourceSystemYesButtonWeb = ";Yes;ManagedString;Microsoft.EnterpriseManagement.Presentation.Controls.dll;Microsoft.EnterpriseManagement.Presentation.Controls.Resources.ControlsResources;RecursionLevelStringForNeg1";
            /// <summary>
            /// Contains resource string for:  SystemNoButton
            /// </summary>
            private const string ResourceSystemNoButton = ";&No;Win32DialogItemString;shell32.dll;1009;2";

            /// <summary>
            /// Contains resource string for:  SystemOKButton
            /// </summary>
            private const string ResourceSystemOKButton = ";OK;Win32DialogItemString;shell32.dll;1003;1";

            /// <summary>
            /// Contains resource string for:  SystemCancelButton
            /// </summary>
            private const string ResourceSystemCancelButton = ";Cancel;Win32DialogItemString;shell32.dll;1003;2";

            /// <summary>
            /// Contains resource string for:  CancelButton
            /// </summary>
            private const string ResourceCancelButton = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.UpdateAgentWarningForm;cancelButton.Text";

            /// <summary>
            /// Contains resource string for:  ApproveButton
            /// </summary>
            private const string ResourceApproveButton = ";&Approve;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Approve" +
                "MenuText";

            /// <summary>
            /// Contains resource string for:  RejectButton
            /// </summary>
            private const string ResourceRejectButton = ";&Reject;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RejectMe" +
                "nuText";

            /// <summary>
            /// Contains resource string for:  CancelWizardDialogTitle
            /// </summary>
            private const string ResourceCancelWizardDialogTitle = 
                ";Operations Manager" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.WizardFramework.dll" +
                ";Microsoft.EnterpriseManagement.UI.WizardFramework.Resources" +
                ";CancelWizardDialogCaption";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the WebConsole dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebConsoleDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Remove Widget Confirmation dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemoveWidgetConfirmationDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Remove Column Confirmation dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemoveColumnConfirmationDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Cancel Wizard Dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancelWizardDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the SQL Connection dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSQLDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Word dialog title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWordDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for FindButtonText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFindButtonText;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConsoleToolBarCommandBar
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleToolBarCommandBar;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConsoleToolBarItemFind
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleToolBarItemFind;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConsoleToolBarItemScope
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleToolBarItemScope;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConsoleToolBarItemActions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleToolBarItemActions;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SystemYesButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSystemYesButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SystemNoButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSystemNoButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SystemOKButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSystemOKButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SystemCancelButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSystemCancelButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CancelButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancelButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApproveButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApproveButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RejectButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRejectButton;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebConsoleDialogTitle translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string WebConsoleDialogTitle
            {
                get
                {
                    if ((cachedWebConsoleDialogTitle == null))
                    {
                        cachedWebConsoleDialogTitle = ResourceWebConsoleDialogTitle;
                    }

                    return cachedWebConsoleDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13JUL05 Created
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
            /// Exposes access to the Remove Widget Confirmation dialog title translated resource string
            /// </summary>
            /// <history>
            /// 	[v-vijia] 14JUN11 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemoveWidgetConfirmationDialogTitle
            {
                get
                {
                    if ((cachedRemoveWidgetConfirmationDialogTitle == null))
                    {
                        cachedRemoveWidgetConfirmationDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceRemoveWidgetConfirmationDialogTitle);
                    }

                    return cachedRemoveWidgetConfirmationDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove Widget Column dialog title translated resource string
            /// </summary>
            /// <history>
            /// 	[v-vijia] 14JUN11 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemoveWidgetColumnDialogTitle
            {
                get
                {
                    if ((cachedRemoveColumnConfirmationDialogTitle == null))
                    {
                        cachedRemoveColumnConfirmationDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceRemoveColumnConfirmationDialogTitle);
                    }

                    return cachedRemoveColumnConfirmationDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel Wizard Dialog title translated resource string
            /// </summary>
            /// <history>
            /// 	[v-vijia] 15Sep11 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CancelWizardDialogTitle
            {
                get
                {
                    if ((cachedCancelWizardDialogTitle == null))
                    {
                        cachedCancelWizardDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceCancelWizardDialogTitle);
                    }

                    return cachedCancelWizardDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SQLDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 09SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SQLDialogTitle
            {
                get
                {
                    if ((cachedSQLDialogTitle == null))
                    {
                        cachedSQLDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceSQLDialogTitle);
                    }

                    return cachedSQLDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WordDialogTitle translated resource string
            /// </summary>
            /// <remarks>Created using 'Resource public property' snippet</remarks>
            /// <history>
            /// 	[barryw] 19DEC05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WordDialogTitle
            {
                get
                {
                    if ((cachedWordDialogTitle == null))
                    {
                        cachedWordDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceWordDialogTitle);
                    }

                    return cachedWordDialogTitle;
                }
            }

            /// <summary>
            /// FindButtonText
            /// </summary>
            public static string FindButtonText
            {
                get
                {
                    if ((cachedFindButtonText == null))
                    {
                        cachedFindButtonText = CoreManager.MomConsole.GetIntlStr(ResourceFindButtonText);
                    }

                    return cachedFindButtonText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConsoleToolBarCommandBar translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleToolBarCommandBar
            {
                get
                {
                    if ((cachedConsoleToolBarCommandBar == null))
                    {
                        cachedConsoleToolBarCommandBar = CoreManager.MomConsole.GetIntlStr(ResourceConsoleToolBarCommandBar);
                    }

                    return cachedConsoleToolBarCommandBar;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConsoleToolBarItemFind translated resource string
            /// </summary>
            /// <history>
            ///     [a-joelj]   28DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleToolBarItemFind
            {
                get
                {
                    if ((cachedConsoleToolBarItemFind == null))
                    {
                        // Returns the localized "Find" ToolbarItem caption without an accelerator key
                        cachedConsoleToolBarItemFind = Utilities.RemoveAcceleratorKeys(CoreManager.MomConsole.GetIntlStr(ResourceConsoleToolBarItemFind));
                    }

                    return cachedConsoleToolBarItemFind;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConsoleToolBarItemScope translated resource string
            /// </summary>
            /// <history>
            ///     [a-joelj]   28DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleToolBarItemScope
            {
                get
                {
                    if ((cachedConsoleToolBarItemScope == null))
                    {
                        // Returns the localized "Scope" ToolbarItem caption without an accelerator key
                        cachedConsoleToolBarItemScope = Utilities.RemoveAcceleratorKeys(CoreManager.MomConsole.GetIntlStr(ResourceConsoleToolBarItemScope));
                    }

                    return cachedConsoleToolBarItemScope;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConsoleToolBarItemActions translated resource string
            /// </summary>
            /// <history>
            ///     [a-joelj]   28DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleToolBarItemActions
            {
                get
                {
                    if ((cachedConsoleToolBarItemActions == null))
                    {
                        // Returns the localized "Actions" ToolbarItem caption without an accelerator key
                        cachedConsoleToolBarItemActions = Utilities.RemoveAcceleratorKeys(CoreManager.MomConsole.GetIntlStr(ResourceConsoleToolBarItemActions));
                    }

                    return cachedConsoleToolBarItemActions;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SystemYesButton translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 18AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SystemYesButton
            {
                get
                {
                    if ((cachedSystemYesButton == null))
                    {
                        switch (ProductSku.Sku)
                        {
                            case ProductSkuLevel.Mom:
                                cachedSystemYesButton = CoreManager.MomConsole.GetIntlStr(ResourceSystemYesButtonMom);
                                break;
                            case ProductSkuLevel.Web:
                                cachedSystemYesButton = CoreManager.MomConsole.GetIntlStr(ResourceSystemYesButtonWeb);
                                break;
                        }
                    }

                    return cachedSystemYesButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SystemCancelButton translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 14SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SystemCancelButton
            {
                get
                {
                    if ((cachedSystemCancelButton == null))
                    {
                        cachedSystemCancelButton = CoreManager.MomConsole.GetIntlStr(ResourceSystemCancelButton);
                    }

                    return cachedSystemCancelButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CancelButton translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 26MAY10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CancelButton
            {
                get
                {
                    if ((cachedCancelButton == null))
                    {
                        cachedCancelButton = CoreManager.MomConsole.GetIntlStr(ResourceCancelButton);
                    }

                    return cachedCancelButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SystemNoButton translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 18AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SystemNoButton
            {
                get
                {
                    if ((cachedSystemNoButton == null))
                    {
                        cachedSystemNoButton = CoreManager.MomConsole.GetIntlStr(ResourceSystemNoButton);
                    }

                    return cachedSystemNoButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SystemOKButton translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 18AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SystemOKButton
            {
                get
                {
                    if ((cachedSystemOKButton == null))
                    {
                        cachedSystemOKButton = CoreManager.MomConsole.GetIntlStr(ResourceSystemOKButton);
                    }

                    return cachedSystemOKButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApproveButton translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 09APR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApproveButton
            {
                get
                {
                    if ((cachedApproveButton == null))
                    {
                        cachedApproveButton = CoreManager.MomConsole.GetIntlStr(ResourceApproveButton);
                    }

                    return cachedApproveButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RejectButton translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 09APR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RejectButton
            {
                get
                {
                    if ((cachedRejectButton == null))
                    {
                        cachedRejectButton = CoreManager.MomConsole.GetIntlStr(ResourceRejectButton);
                    }

                    return cachedRejectButton;
                }
            }

            #endregion
        }
        #endregion

        #region Control ID's Class

        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Toolbar
            /// </summary>
            public const string Toolbar = "header";

            /// <summary>
            /// Control ID for StatusBar3
            /// </summary>
            public const string StatusBar = "consoleStatusBar";
        }
        #endregion

        #region QID's Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-juli] 5/12/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            /// <summary>
            /// Contains resource string for Menu query id
            /// </summary>
            private const string ResourceDropDown = ";[UIA]AccessibleName=\'DropDown\'";           

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Menu resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/2/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MenuContext
            {
                get
                {
                    return new QID(ResourceDropDown);
                }
            }

            /// <summary>
            /// Gets Sub Menu qid string
            /// </summary>
            /// <param name="menueString">sub menu string in UI</param>
            /// <returns></returns>
            public static QID GetSubMenu(string menueString)
            {
                return new QID(";[UIA]AccessibleName = \'" + menueString + "DropDown\'");
            }
        }
        #endregion 
    }
}
