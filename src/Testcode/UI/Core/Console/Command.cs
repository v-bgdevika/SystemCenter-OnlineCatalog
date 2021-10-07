// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Command.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	OM10 UI Test Automation
// </project>
// <summary>
// 	Merge code from SystemCenter.Test.UI.Core.ConsoleFramework.
//  Command class, implemented to work around MAUI issues not handling WPF MenuBar.
// </summary>
// <history>
// [v-raienl]    24JUN10     Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Maui.GlobalExceptions;
    using Mom.Test.UI.Core.Common;
    #endregion

    /// ----------------------------------------------------------------------
    /// <summary>
    /// Command Class
    /// </summary>
    /// ----------------------------------------------------------------------
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class Command : Maui.Core.Command
    {
        #region Private Members
        /// <summary>
        /// Context Menu Path
        /// </summary>
        private string contextMenuPath = null;

        /// <summary>
        /// Main Menu Path
        /// </summary>
        private string mainMenuPath = null;

        /// <summary>
        /// Keyboard Shortcut
        /// </summary>
        private string keyboardShortcut = null;

        /// <summary>
        /// Keyboard Shortcut2
        /// </summary>
        private string keyboardShortcut2 = null;

        /// <summary>
        /// Toolbar Path
        /// </summary>
        private string toolbarPath = null;

        /// <summary>
        /// Direct Call Info
        /// </summary>
        private string directCallInfo = null;

        /// <summary>
        /// Direct Call Info2
        /// </summary>
        private string directCallInfo2 = null;

        ////public const char Delimiter = '|';
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Command()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainMenuPath">Path to command in the main menu or null.</param>
        public Command(string mainMenuPath) :
            base(mainMenuPath)
        {
            this.mainMenuPath = mainMenuPath;
            this.contextMenuPath = null;
            this.keyboardShortcut = null;
            this.toolbarPath = null;
            this.directCallInfo = null;
            this.directCallInfo2 = null;
            this.keyboardShortcut2 = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainMenuPath">Path to command in the main menu or null.</param>
        /// <param name="contextMenuPath">Path to command in the context menu or null</param>
        public Command(string mainMenuPath, string contextMenuPath) :
            base(mainMenuPath, contextMenuPath)
        {
            this.mainMenuPath = mainMenuPath;
            this.contextMenuPath = contextMenuPath;
            this.keyboardShortcut = null;
            this.toolbarPath = null;
            this.directCallInfo = null;
            this.directCallInfo2 = null;
            this.keyboardShortcut2 = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainMenuPath">Path to command in the main menu or null.</param>
        /// <param name="contextMenuPath">Path to command in the context menu or null</param>
        /// <param name="keyboardShortcut">Keyboard shortcut for command or null</param>
        public Command(string mainMenuPath, string contextMenuPath, string keyboardShortcut) :
            base(mainMenuPath, contextMenuPath, keyboardShortcut)
        {
            this.mainMenuPath = mainMenuPath;
            this.contextMenuPath = contextMenuPath;
            this.keyboardShortcut = keyboardShortcut;
            this.toolbarPath = null;
            this.directCallInfo = null;
            this.directCallInfo2 = null;
            this.keyboardShortcut2 = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainMenuPath">Path to command in the main menu or null.</param>
        /// <param name="contextMenuPath">Path to command in the context menu or null</param>
        /// <param name="keyboardShortcut">Keyboard shortcut for command or null</param>
        /// <param name="toolbarPath">Path to command in the toolbar or null</param>
        public Command(string mainMenuPath, string contextMenuPath, string keyboardShortcut, string toolbarPath) :
            base(mainMenuPath, contextMenuPath, keyboardShortcut, toolbarPath)
        {
            this.mainMenuPath = mainMenuPath;
            this.contextMenuPath = contextMenuPath;
            this.keyboardShortcut = keyboardShortcut;
            this.toolbarPath = toolbarPath;
            this.directCallInfo = null;
            this.directCallInfo2 = null;
            this.keyboardShortcut2 = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainMenuPath">Path to command in the main menu or null.</param>
        /// <param name="contextMenuPath">Path to command in the context menu or null</param>
        /// <param name="keyboardShortcut">Keyboard shortcut for command or null</param>
        /// <param name="toolbarPath">Path to command in the toolbar or null</param>
        /// <param name="directCallInfo">Information to direct call to application's object model</param>
        public Command(string mainMenuPath, string contextMenuPath, string keyboardShortcut, string toolbarPath, string directCallInfo) :
            base(mainMenuPath, contextMenuPath, keyboardShortcut, toolbarPath, directCallInfo)
        {
            this.mainMenuPath = mainMenuPath;
            this.contextMenuPath = contextMenuPath;
            this.keyboardShortcut = keyboardShortcut;
            this.toolbarPath = toolbarPath;
            this.directCallInfo = directCallInfo;
            this.directCallInfo2 = null;
            this.keyboardShortcut2 = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainMenuPath">Path to command in the main menu or null.</param>
        /// <param name="contextMenuPath">Path to command in the context menu or null</param>
        /// <param name="keyboardShortcut">Keyboard shortcut for command or null</param>
        /// <param name="toolbarPath">Path to command in the toolbar or null</param>
        /// <param name="directCallInfo">Information to direct call to application's object model</param>
        /// <param name="directCallInfo2">Information to direct call to application's object model.</param>
        /// <param name="keyboardShortcut2">Secondary keyboard shortcut.</param>
        public Command(string mainMenuPath, string contextMenuPath, string keyboardShortcut, string toolbarPath, string directCallInfo, string directCallInfo2, string keyboardShortcut2) :
            base(mainMenuPath, contextMenuPath, keyboardShortcut, toolbarPath, directCallInfo, directCallInfo2, keyboardShortcut2)
        {
            this.mainMenuPath = mainMenuPath;
            this.contextMenuPath = contextMenuPath;
            this.keyboardShortcut = keyboardShortcut;
            this.toolbarPath = toolbarPath;
            this.directCallInfo = directCallInfo;
            this.directCallInfo2 = directCallInfo2;
            this.keyboardShortcut2 = keyboardShortcut2;

            Utilities.LogMessage("m_mainMenuPath = " + this.MainMenuPath);
        }

        /// <summary>
        /// Constructs a command by copying all the information from another command.
        /// </summary>
        /// <param name="command">command to copy information from</param>
        public Command(Command command)
        {
            this.mainMenuPath = command.MainMenuPath;
            this.contextMenuPath = command.ContextMenuPath;
            this.keyboardShortcut = command.KeyboardShortcut;
            this.toolbarPath = command.ToolbarPath;
            this.directCallInfo = command.DirectCallInfo;
            this.directCallInfo2 = command.DirectCallInfo2;
            this.keyboardShortcut2 = command.KeyboardShortcut2;

            Utilities.LogMessage("mainMenuPath = " + this.MainMenuPath);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Path to Main Menu
        /// </summary>
        public new string MainMenuPath
        {
            get
            {
                return this.mainMenuPath;
            }

            set
            {
                this.mainMenuPath = value;
            }
        }

        /// <summary>
        /// Path to Context Menu
        /// </summary>
        public new string ContextMenuPath
        {
            get
            {
                return this.contextMenuPath;
            }

            set
            {
                this.contextMenuPath = value;
            }
        }

        /// <summary>
        /// Keyboard Shortcut
        /// </summary>
        public new string KeyboardShortcut
        {
            get
            {
                return this.keyboardShortcut;
            }

            set
            {
                this.keyboardShortcut = value;
            }
        }

        /// <summary>
        /// Keyboard Shortcut2
        /// </summary>
        public new string KeyboardShortcut2
        {
            get
            {
                return this.keyboardShortcut2;
            }

            set
            {
                this.keyboardShortcut2 = value;
            }
        }

        /// <summary>
        /// Toolbar Path
        /// </summary>
        public new string ToolbarPath
        {
            get
            {
                return this.toolbarPath;
            }

            set
            {
                this.toolbarPath = value;
            }
        }

        /// <summary>
        /// Direct Call Info
        /// </summary>
        public new string DirectCallInfo
        {
            get
            {
                return this.directCallInfo;
            }

            set
            {
                this.directCallInfo = value;
            }
        }

        /// <summary>
        /// Direct Call Info2
        /// </summary>
        public new string DirectCallInfo2
        {
            get
            {
                return this.directCallInfo2;
            }

            set
            {
                this.directCallInfo2 = value;
            }
        }
        #endregion

        /// <summary>
        /// Gets toolbar item for this command.
        /// </summary>
        /// <param name="app">Application from which to get an item.</param>
        /// <returns>ToolbarItem</returns>
        public new virtual ToolbarItem GetToolbarItem(App app)
        {
            if ((this.ToolbarPath == null))
            {
                throw new NotSupportedException(("Toolbar command method is not supported by this command "
                                + "this.GetType().Name"
                                + "."
                                + "\r\n" + "Check that ToolbarPath is specified in Command constructor or attribute declaration."));
            }

            Toolbar toolbar;
            string itemName;
            if ((this.ToolbarPath.IndexOf(Delimiter) < 0))
            {
                toolbar = new Toolbar(app);
                itemName = this.ToolbarPath;
            }
            else
            {
                toolbar = new Toolbar(app, app.GetIntlStr(this.ToolbarPath.Split(Delimiter)[0]));
                itemName = this.ToolbarPath.Split(Delimiter)[1];
            }

            return toolbar[app.GetIntlStr(itemName)];
        }

        #region State Methods
        /// <summary>
        /// Returns true if specified command method is supported by this command.
        /// </summary>
        /// <param name="method">Command method.</param>
        /// <returns>True if method is supported and false otherwise</returns>
        public new bool IsSupported(CommandMethod method)
        {
            // No Default method - does not make sense in case of IsSupported.
            if ((method == CommandMethod.Default))
            {
                throw new ArgumentException("Default command method is not supported by IsSupported function.");
            }

            bool commandMethod = false;

            switch (method)
            {
                case CommandMethod.ContextMenu:
                    commandMethod = !(this.ContextMenuPath == null);
                    break;
                case CommandMethod.ContextMenuHotKey:
                    commandMethod = !(this.ContextMenuPath == null);
                    break;
                case CommandMethod.ContextMenuShift10:
                    commandMethod = !(this.ContextMenuPath == null);
                    break;
                case CommandMethod.ContextMenuSpecialKey:
                    commandMethod = !(this.ContextMenuPath == null);
                    break;
                case CommandMethod.MainMenu:
                    commandMethod = !(this.MainMenuPath == null);
                    break;
                case CommandMethod.MainMenuHotKey:
                    commandMethod = !(this.MainMenuPath == null);
                    break;
                case CommandMethod.Toolbar:
                    commandMethod = !(this.ToolbarPath == null);
                    break;
                case CommandMethod.Keyboard:
                    commandMethod = !(this.KeyboardShortcut == null);
                    break;
                case CommandMethod.Keyboard2:
                    commandMethod = !(this.KeyboardShortcut2 == null);
                    break;
                case CommandMethod.DirectCall:
                    commandMethod = !(this.DirectCallInfo == null);
                    break;
                case CommandMethod.DirectCall2:
                    commandMethod = !(this.DirectCallInfo2 == null);
                    break;
                default:
                    commandMethod = false;
                    break;
            }

            return commandMethod;
        }

        /// <summary>
        /// Returns true if command is enabled via default command method.
        /// </summary>
        /// <param name="app">Application</param>
        /// <returns>True if command is enabled and false otherwise.</returns>
        public new bool IsEnabled(App app)
        {
            return this.IsEnabled(null, app, CommandMethod.Default);
        }

        /// <summary>
        /// Returns true if command is enabled via default command method.
        /// </summary>
        /// <param name="app">Application</param>
        /// <param name="method">Command method.</param>
        /// <returns>True if command is enabled and false otherwise.</returns>
        public new bool IsEnabled(App app, CommandMethod method)
        {
            return this.IsEnabled(null, app, method);
        }

        /// <summary>
        /// Returns true if command is enabled via default command method.
        /// </summary>
        /// <param name="target">UI element on which to check.</param>
        /// <returns>True if command is enabled and false otherwise.</returns>
        public new bool IsEnabled(ICommandTarget target)
        {
            return this.IsEnabled(target, target.App, CommandMethod.Default);
        }

        /// <summary>
        /// Returns true if command is enabled via default command method.
        /// </summary>
        /// <param name="target">UI element on which to check.</param>
        /// <param name="method">Command method.</param>
        /// <returns>True if command is enabled and false otherwise.</returns>
        public new bool IsEnabled(ICommandTarget target, CommandMethod method)
        {
            return this.IsEnabled(target, target.App, method);
        }

        /// <summary>
        /// Determines wheater the given command is available in the UI using the given method.
        /// </summary>
        /// <param name="app">Application which owns the element.</param>
        /// <returns>True if command is available regradless of enabled state. False otherwise.</returns>
        public new bool IsAvailable(App app)
        {
            return this.IsAvailable(null, app, CommandMethod.Default);
        }

        /// <summary>
        /// Determines wheater the given command is available in the UI using the given method.
        /// </summary>
        /// <param name="app">Application which owns the element.</param>
        /// <param name="method">Command method to use.</param>
        /// <returns>True if command is available regradless of enabled state. False otherwise.</returns>
        public new bool IsAvailable(App app, CommandMethod method)
        {
            return this.IsAvailable(null, app, method);
        }

        /// <summary>
        /// Determines wheater the given command is available in the UI using the given method.
        /// </summary>
        /// <param name="target">UI element to check.</param>
        /// <returns>True if command is available regradless of enabled state. False otherwise.</returns>
        public new bool IsAvailable(ICommandTarget target)
        {
            return this.IsAvailable(target, target.App, CommandMethod.Default);
        }

        /// <summary>
        /// Determines wheater the given command is available in the UI using the given method.
        /// </summary>
        /// <param name="target">UI element to check.</param>
        /// <param name="method">Command method to use.</param>
        /// <returns>True if command is available regradless of enabled state. False otherwise.</returns>
        public new bool IsAvailable(ICommandTarget target, CommandMethod method)
        {
            return this.IsAvailable(target, target.App, method);
        }

        /// <summary>
        /// Determines wheater the given command is available in the UI using the given method.
        /// </summary>
        /// <param name="target">UI element to check.</param>
        /// <param name="app">Application which owns the element.</param>
        /// <param name="method">Command method to use.</param>
        /// <returns>True if command is available regradless of enabled state. False otherwise.</returns>
        public new bool IsAvailable(ICommandTarget target, App app, CommandMethod method)
        {
            this.PrepareTarget(target, app, ref method);
            if ((method == CommandMethod.Toolbar))
            {
                try
                {
                    this.GetToolbarItem(app);
                    return true;
                }
                catch (Toolbar.Exceptions.ToolbarItemNotFoundException)
                {
                    return false;
                }
            }
            else
            {
                if (((method == CommandMethod.ContextMenu)
                            || ((method == CommandMethod.ContextMenuHotKey)
                            || ((method == CommandMethod.ContextMenuShift10)
                            || (method == CommandMethod.ContextMenuSpecialKey)))))
                {
                    try
                    {
                        this.IsMenuEnabled(target.ContextMenu, app, this.ContextMenuPath);
                        return true;
                    }
                    catch (Menu.Exceptions.ItemNotFoundException)
                    {
                        return false;
                    }
                    catch (MenuItem.Exceptions.MenuItemNotFoundException)
                    {
                        return false;
                    }
                    catch (Exceptions.MenuItemNotVisibleException)
                    {
                        return false;
                    }
                }
                else
                {
                    if (((method == CommandMethod.MainMenu)
                                || (method == CommandMethod.MainMenuHotKey)))
                    {
                        try
                        {
                            this.IsMenuEnabled(app.Menu, app, this.MainMenuPath);
                            return true;
                        }
                        catch (Menu.Exceptions.ItemNotFoundException)
                        {
                            return false;
                        }
                        catch (MenuItem.Exceptions.MenuItemNotFoundException)
                        {
                            return false;
                        }
                        catch (Exceptions.MenuItemNotVisibleException)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        throw new NotSupportedException(("Command method "
                                        + (method.ToString()
                                        + (" is not supported by this command "
                                        + (this.GetType().Name
                                        + (" or not supported by IsAvailable function."
                                        + ("\r\n" + "Make sure that enough information was passed to Command constructor or attribute "
                                        + "declaration.")))))));
                    }
                }
            }
        }

        #endregion

        #region Execution Methods
        /// <summary>
        /// Invokes specified commmand in the application.
        /// </summary>
        /// <param name="app">Application where to invoke the command.</param>
        public new void Execute(App app)
        {
            this.Execute(null, app, CommandMethod.Default);
        }

        /// <summary>
        /// Invokes specified commmand in the application.
        /// </summary>
        /// <param name="app">Application where to invoke the command.</param>
        /// <param name="method">How to invoke the command.</param>
        public new void Execute(App app, CommandMethod method)
        {
            this.Execute(null, app, method);
        }

        /// <summary>
        /// Invokes specified commmand in the application.
        /// </summary>
        /// <param name="target">UI target on which to invoke the command.</param>
        public new void Execute(ICommandTarget target)
        {
            this.Execute(target, target.App, CommandMethod.Default);
        }

        /// <summary>
        /// Invokes specified commmand in the application.
        /// </summary>
        /// <param name="target">UI target on which to invoke the command.</param>
        /// <param name="method">How to invoke the command.</param>
        public new void Execute(ICommandTarget target, CommandMethod method)
        {
            this.Execute(target, target.App, method);
        }

        /// <summary>
        /// Invokes specified commmand in the application.
        /// </summary>
        /// <param name="target">UI target on which to invoke the command.</param>
        /// <param name="app">Application where to invoke the command.</param>
        /// <param name="method">How to invoke the command.</param>
        protected new virtual void Execute(ICommandTarget target, App app, CommandMethod method)
        {
            Utilities.LogMessage("Command.Execute:: app.MainWindow.ScreenElement.FrameworkId: " + app.MainWindow.ScreenElement.FrameworkId);

            // run the command
            if (app.MainWindow.ScreenElement.FrameworkId == "WinForm")
            {
                // target/method preparation
                Utilities.LogMessage("Command.Execute:: WinForm");
                base.Execute(target, app, method);
            }
            else
            {
                this.PrepareTarget(target, app, ref method);
                this.RunCommand(target, app, method);

                // wait for response if possible
                if (!(target == null))
                {
                    Window wnd;

                    // if target window is invalid, we don't want get exception
                    try
                    {
                        wnd = target.TargetWindow;
                        if (wnd.Extended.IsValid)
                        {
                            wnd.WaitForResponse();
                            if (wnd.IsEnabled)
                            {
                                UISynchronization.WaitForUIObjectReady(wnd);
                            }
                        }
                    }
                    catch (Window.Exceptions.InvalidHWndException)
                    {
                        wnd = null;
                    }
                }

                if ((app.IsRunning
                            && (!(app.MainWindow == null)
                            && app.MainWindow.Extended.IsValid)))
                {
                    try
                    {
                        app.MainWindow.WaitForResponse();
                        if (app.MainWindow.Extended.IsEnabled)
                        {
                            UISynchronization.WaitForUIObjectReady(app.MainWindow);
                        }
                    }
                    catch (Window.Exceptions.InvalidHWndException)
                    {
                        //// ignore this as window might still go away...
                    }
                }
            }
        }

        /// <summary>
        /// Runs specified command on a command target.
        /// </summary>
        /// <param name="target">UI target on which to invoke the command.</param>
        /// <param name="app">Application which owns the target.</param>
        /// <param name="method">How to invoke the command.</param>
        protected new virtual void RunCommand(ICommandTarget target, App app, CommandMethod method)
        {
            Menu appMenu = null;

            switch (method)
            {
                case CommandMethod.ContextMenu:
                    this.ExecuteMenu(target.ContextMenu, app, this.ContextMenuPath);
                    break;
                case CommandMethod.ContextMenuHotKey:
                    this.ExecuteHotKey(new Menu(ContextMenuAccessMethod.ShiftF10), app, method);
                    break;
                case CommandMethod.ContextMenuShift10:
                    this.ExecuteMenu(new Menu(ContextMenuAccessMethod.ShiftF10), app, this.ContextMenuPath);
                    break;
                case CommandMethod.ContextMenuSpecialKey:
                    this.ExecuteMenu(new Menu(ContextMenuAccessMethod.KeyboardKey), app, this.ContextMenuPath);
                    break;
                case CommandMethod.MainMenu:
                    appMenu = new Menu(app.MainWindow, new QID(";[UIA, VisibleOnly]ClassName = 'Menu' && AutomationId = 'PART_Menu'"), 5000);
                    this.ExecuteMenu(appMenu, app, this.MainMenuPath);
                    break;
                case CommandMethod.MainMenuHotKey:
                    appMenu = new Menu(app.MainWindow, new QID(";[UIA, VisibleOnly]ClassName = 'Menu' && AutomationId = 'PART_Menu'"), 5000);
                    this.ExecuteHotKey(appMenu, app, method);
                    break;
                case CommandMethod.Toolbar:
                    ToolbarItem item = this.GetToolbarItem(app);
                    if (!item.Enabled)
                    {
                        throw new Exceptions.ToolbarItemNotEnabledException(("Toolbar item "
                                        + (item.Text
                                        + (" is not enabled while executing command "
                                        + (this.GetType().Name + ".")))));
                    }

                    this.GetToolbarItem(app).Click();
                    break;
                case CommandMethod.Keyboard:
                    Keyboard.SendKeys(this.KeyboardShortcut);
                    break;
                case CommandMethod.Keyboard2:
                    Keyboard.SendKeys(this.KeyboardShortcut2);
                    break;
                default:
                    throw new NotSupportedException(("Command method "
                                    + (method.ToString()
                                    + (" is not supported by command "
                                    + (this.GetType().Name
                                    + ("."
                                    + ("\r\n" + "Make sure that enough information is passed to Command constructor or attribute d"
                                    + "eclaration.")))))));
            }
        }
        #endregion

        #region Private
        /// <summary>
        /// Returns true if command is enabled via specified command method.
        /// </summary>
        /// <param name="target">UI element on which to check.</param>
        /// <param name="app">Application which owns the element.</param>
        /// <param name="method">Command method to use.</param>
        /// <returns>True if command is enabled and false otherwise</returns>
        private bool IsEnabled(ICommandTarget target, App app, CommandMethod method)
        {
            this.PrepareTarget(target, app, ref method);
            Menu appMenu = null;

            bool enabled = false;

            switch (method)
            {
                case CommandMethod.ContextMenu:
                    enabled = this.IsMenuEnabled(target.ContextMenu, app, this.ContextMenuPath);
                    break;
                case CommandMethod.ContextMenuHotKey:
                    enabled = this.IsMenuEnabled(new Menu(ContextMenuAccessMethod.ShiftF10), app, this.ContextMenuPath);
                    break;
                case CommandMethod.ContextMenuShift10:
                    enabled = this.IsMenuEnabled(new Menu(ContextMenuAccessMethod.ShiftF10), app, this.ContextMenuPath);
                    break;
                case CommandMethod.ContextMenuSpecialKey:
                    enabled = this.IsMenuEnabled(new Menu(ContextMenuAccessMethod.KeyboardKey), app, this.ContextMenuPath);
                    break;
                case CommandMethod.MainMenu:
                    appMenu = new Menu(app.MainWindow, new QID(";[UIA, VisibleOnly]ClassName = 'Menu' && AutomationId = 'PART_Menu'"), 5000);
                    enabled = this.IsMenuEnabled(appMenu, app, this.MainMenuPath);
                    break;
                case CommandMethod.MainMenuHotKey:
                    appMenu = new Menu(app.MainWindow, new QID(";[UIA, VisibleOnly]ClassName = 'Menu' && AutomationId = 'PART_Menu'"), 5000);
                    enabled = this.IsMenuEnabled(appMenu, app, this.MainMenuPath);
                    break;
                case CommandMethod.Toolbar:
                    enabled = this.GetToolbarItem(app).Enabled;
                    break;
                default:
                    throw new NotSupportedException(("Command method "
                                    + (method.ToString()
                                    + (" is not supported by this command "
                                    + (this.GetType().Name
                                    + (" or not supported by IsEnabled function."
                                    + ("\r\n" + "Make sure that enough information was passed to Command constructor or attribute "
                                    + "declaration.")))))));
            }

            return enabled;
        }

        #region Helper methods
        /// <summary>
        /// Selects menu item and verifies that the item is enabled before clicking on it.
        /// </summary>
        /// <param name="item">Item to select</param>
        private void SelectMenuItem(MenuItem item)
        {
            Utilities.LogMessage("SelectMenuItem::");

            // wait for item to be enabled
            Sleeper sleeper = new Sleeper(5000);
            while ((sleeper.IsNotExpired
                        && !item.Enabled))
            {
                sleeper.Sleep();
            }

            // check if it's finally enabled
            if (!item.Enabled)
            {
                if (!item.AccessibleObject.Visible)
                {
                    throw new Exceptions.MenuItemNotVisibleException(("Menu item "
                                    + (item.Text
                                    + (" is not visible."
                                    + ("\r\n"
                                    + ("This error was encountered while handling command "
                                    + (this.GetType().Name
                                    + (" using menu or context menu command method."
                                    + ("\r\n" + "If this is a timing issue, try to wait for previous operation to complete before "
                                    + "invoking the command.")))))))));
                }
                else
                {
                    throw new Exceptions.MenuItemNotEnabledException(("Menu item "
                                    + (item.Text
                                    + (" is not enabled."
                                    + ("\r\n"
                                    + ("This error was encountered while handling command "
                                    + (this.GetType().Name
                                    + (" using menu or context menu command method."
                                    + ("\r\n" + "If this is a timing issue, try to wait for previous operation to complete before "
                                    + "invoking the command.")))))))));
                }
            }

            // click it!
            Mouse.Click(item.AccessibleObject.X + (item.AccessibleObject.Width / 2), item.AccessibleObject.Y + (item.AccessibleObject.Height / 2));
        }

        /// <summary>
        /// Selects menu item and verifies that item is enabled before clicking on it.
        /// </summary>
        /// <param name="item">Item to select.</param>
        private void SelectMenuItem(IScreenElement item)
        {
            Utilities.LogMessage("SelectMenuItem::");

            // click it!
            item.LeftButtonClick(-1, -1);
        }

        /// <summary>
        /// Returns menu item by ScreenElement
        /// </summary>
        /// <param name="menu">Containing menu</param>
        /// <param name="itemName">Item name.</param>
        /// <returns>ScreenElement</returns>
        private IScreenElement GetMenuItem(Window menu, string itemName)
        {
            Utilities.LogMessage("Command.GetMenuItem:: menu.FrameworkId: " + menu.ScreenElement.FrameworkId);
            string fixedItemName = this.RemoveAcceleratorKey(itemName);

            Utilities.LogMessage("GetMenuItem.ScreenElement");
            MauiCollection<IScreenElement> children;
            ////IScreenElement element = RPFSupport.RPF.FindElement(new QID(";[UIA, VisibleOnly] ClassName = 'Menu' | 'Popup'", null, 2), null, -1, 5000, true);
            children = menu.ScreenElement.FindAllDescendants(2, ";[FindAll, UIA, VisibleOnly]Role='menu item'", null);

            foreach (IScreenElement child in children)
            {
                Utilities.LogMessage("Command.GetMenuItem:: Child.Name: '" + child.Name + "'");
                if ((child.Name == itemName) || (fixedItemName == this.RemoveAcceleratorKey(child.Name)))
                {
                    //// && String.Compare(child.State, MsaaStates.Invisible.ToString()) == 0))
                    Utilities.LogMessage("Command.GetMenuItem:: returning MenuItem(menu, child.Name)");
                    return child;
                }
            }

            return menu.ScreenElement;
        }

        /// <summary>
        /// Returns menu item by name.
        /// </summary>
        /// <param name="menu">Containing menu.</param>
        /// <param name="itemName">Item name.</param>
        /// <returns>MenuItem</returns>
        private MenuItem GetMenuItem(Menu menu, string itemName)
        {
            Utilities.LogMessage("Command.GetMenuItem:: menu.FrameworkId: " + menu.Parent.ScreenElement.FrameworkId);
            string fixedItemName = this.RemoveAcceleratorKey(itemName);

            Utilities.LogMessage("GetMenuItem.MenuItem");
            MauiCollection<IScreenElement> children;
            IScreenElement element = RPFSupport.RPF.FindElement(new QID(";[UIA, VisibleOnly] ClassName = 'Menu' | 'Popup'", null, 2), null, -1, 5000, true);
            children = element.FindAllDescendants(2, ";[FindAll, UIA, Distinct, VisibleOnly]Role='menu item'", null);

            foreach (IScreenElement child in children)
            {
                Utilities.LogMessage("Command.GetMenuItem:: Child.Name: '" + child.Name + "'");
                if ((child.Name == itemName) || (fixedItemName == this.RemoveAcceleratorKey(child.Name)))
                {
                    //// && String.Compare(child.State, MsaaStates.Invisible.ToString()) == 0))
                    Utilities.LogMessage("Command.GetMenuItem:: returning MenuItem(menu, child.Name)");
                    return new MenuItem(menu, child.Name);
                }
            }

            return menu[itemName];
        }

        /// <summary>
        /// Removes the AcceleratorKey (on localized builds) from the itemName parameter.
        /// This could be at the end of the item or in the middle prior to the "..."
        /// </summary>
        /// <param name="itemName">String to remove the trailing Accelerator Key</param>
        /// <returns>itemName with the AcceleratorKey removed</returns>
        private string RemoveAcceleratorKey(string itemName)
        {
            string itemNameWithoutAcceleratorKey = itemName;
            if (!(itemName == null))
            {
                System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("\\(\\w{1}\\)");
                itemNameWithoutAcceleratorKey = rgx.Replace(itemName, String.Empty);
            }

            return itemNameWithoutAcceleratorKey;
        }

        /// <summary>
        /// Checks weather specified menu item is enabled.
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <param name="app">Application</param>
        /// <param name="path">Menu Path</param>
        /// <returns>True or False</returns>
        private bool IsMenuEnabled(Menu menu, App app, string path)
        {
            string[] pathItems = path.Split(Delimiter);
            bool result = false;
            int openMenuCount = 0;
            if ((menu.AccessibleObject.Role == (int)MsaaRole.MenuPopup))
            {
                openMenuCount = (openMenuCount + 1);
            }

            try
            {
                for (int i = 0; (i <= (pathItems.Length - 1)); i = (i + 1))
                {
                    if ((i == (pathItems.Length - 1)))
                    {
                        MenuItem item = this.GetMenuItem(menu, app.GetIntlStr(pathItems[i]).Replace("&", String.Empty));
                        if (((item == null) || !item.AccessibleObject.Visible))
                        {
                            throw new MenuItem.Exceptions.MenuItemNotFoundException(("Menu item "
                                            + (item.Text + " wasn\'t found amoung visible set of items (it\'s invisible).")));
                        }

                        result = item.Enabled;
                    }
                    else
                    {
                        this.SelectMenuItem(this.GetMenuItem(menu, app.GetIntlStr(pathItems[i]).Replace("&", String.Empty)));
                        this.WaitForMenu(menu);
                        menu = new Menu(5000);
                        openMenuCount = (openMenuCount + 1);
                    }
                }
            }
            finally
            {
                for (int i = 1; (i <= openMenuCount); i = (i + 1))
                {
                    Keyboard.SendKeys("{ESC}");
                }
            }

            return result;
        }

        /// <summary>
        /// Waits for menu UI to be ready.
        /// </summary>
        /// <param name="menu">Menu</param>
        private void WaitForMenu(Menu menu)
        {
            try
            {
                menu.Parent.ScreenElement.WaitForReady();
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("Command.WaitForMenu:: Exception: " + ex);
            }
        }

        /// <summary>
        /// Executes specified path from a menu.
        /// </summary>
        /// <param name="menu">Start menu.</param>
        /// <param name="app">Application which owns the menu.</param>
        /// <param name="path">Menu path to execute.</param>
        private void ExecuteMenu(Menu menu, App app, string path)
        {
            string[] pathItems = path.Split(Delimiter);
            Utilities.LogMessage("Command.ExecuteMenu:: ");

            this.SelectMenuItem(this.GetMenuItem(menu, app.GetIntlStr(pathItems[0]).Replace("&", String.Empty)));
            if ((pathItems.Length > 1))
            {
                // wait for the menu to open before submenus are accessed
                ////this.WaitForMenu(menu);
                menu.Parent.ScreenElement.WaitForReady();
            }

            Utilities.LogMessage("Command.ExecuteMenu:: menu.FrameworkId: " + menu.Parent.ScreenElement.FrameworkId);

            Window popupWindow = null;
            for (int i = 1; (i <= (pathItems.Length - 1)); i = (i + 1))
            {
                Utilities.LogMessage("ExecuteMenu.PopupMenu");
                if (popupWindow == null)
                {
                    Utilities.LogMessage("ExecuteMenu.PopupWindow == null");
                    System.Threading.Thread.Sleep(1000 * 60 * 5);
                    popupWindow = new Window(new QID(";[UIA, VisibleOnly]ClassName = 'Popup' && Role = 'window'"), 5000);
                }
                else
                {
                    Utilities.LogMessage("ExecuteMenu.PopupWindow != null");
                    popupWindow = new Window(popupWindow, new QID(";[UIA, Distinct, VisibleOnly]ClassName = 'Popup' && Role = 'window'"), 5000);
                }

                Utilities.LogMessage("ExecuteMenu.WaitForReady...");
                popupWindow.ScreenElement.WaitForReady();

                ////menu = new Menu(pw);
                ////}

                Utilities.LogMessage("ExecuteMenu.SelectMenuItem: " + app.GetIntlStr(pathItems[i]));
                this.SelectMenuItem(this.GetMenuItem(popupWindow, app.GetIntlStr(pathItems[i]).Replace("&", String.Empty)));
                if ((i < (pathItems.Length - 1)))
                {
                    this.WaitForMenu(menu);
                }
            }
        }

        /// <summary>
        /// Executes specified path from a menu using hot-key combination.
        /// </summary>
        /// <param name="menu">Start menu.</param>
        /// <param name="app">Application which owns the menu.</param>
        /// <param name="method">Method used to execute command.  This should be either ContextMenuHotKey or MainMenuHotKey</param>
        private void ExecuteHotKey(Menu menu, App app, CommandMethod method)
        {
            try
            {
                string path;
                switch (method)
                {
                    case CommandMethod.ContextMenuHotKey:
                        path = this.ContextMenuPath;
                        break;
                    case CommandMethod.MainMenuHotKey:
                        Keyboard.PressKey(Keyboard.VKeys.VK_LMENU);
                        path = this.MainMenuPath;
                        break;
                    default:
                        throw new ArgumentException(("Command.ExecuteHotKey method aurgument can only be called with ContextMenuHotKey "
                            + "or MainMenuHotKey. "
                            + ("\r\n"
                            + (" It has instead been called with method: " + method.ToString()))));
                }

                string[] pathItems = path.Split(Delimiter);
                for (int i = 0; (i
                            <= (pathItems.Length - 1)); i = (i + 1))
                {
                    string pathItem = app.GetIntlStr(pathItems[i]);
                    string key;
                    if ((pathItem.IndexOf("&") >= 0))
                    {
                        key = pathItem.Substring((pathItem.IndexOf("&") + 1), 1);
                    }
                    else
                    {
                        MenuItem menuItem = this.GetMenuItem(menu, pathItem);
                        key = menuItem.AccessibleObject.KeyboardShortcut;
                        if ((key.StartsWith("Alt+")
                                    && (key.Length == 5)))
                        {
                            key = key.Substring(4);
                        }
                    }

                    if (((key == null)
                                || (key.Length != 1)))
                    {
                        throw new NotSupportedException(("Hot-key is not supported by command"));
                        ////"
                        ////+ (this.GetType().Name
                        ////+ ("."
                        ////+ ("\r\n" + "The problem is that command menu path does not contain accelerator key in item ")))), (""
                        ////+ (pathItem + "")), ".");
                    }

                    key = key.ToLower(CultureInfo.InvariantCulture);
                    Keyboard.PressKey(key);
                    Keyboard.ReleaseKey(key);
                    if ((i
                                < (pathItems.Length - 1)))
                    {
                        menu = new Menu(5000);
                    }
                }
            }
            finally
            {
                if ((method == CommandMethod.MainMenuHotKey))
                {
                    Keyboard.ReleaseKey(Keyboard.VKeys.VK_LMENU);
                }
            }
        }

        /// <summary>
        /// Prepares target application and UI element for command invocation.
        /// </summary>
        /// <param name="target">Target UI element.</param>
        /// <param name="app">Application which owns the element.</param>
        /// <param name="method">Command method to prepare for.</param>
        private void PrepareTarget(ICommandTarget target, App app, ref CommandMethod method)
        {
            // check that target is valid, if required
            if (((target == null)
                        && ((method == CommandMethod.ContextMenu)
                        || (method == CommandMethod.ContextMenuHotKey))))
            {
                throw new ArgumentException("Command methods ContextMenu and ContextMenuHotKey require a command target ot be not null.", "target");
            }

            Utilities.LogMessage("CommandMethod: " + method.ToString());
            Utilities.LogMessage("MainMenuPath: " + this.MainMenuPath);

            // handle Default command method 
            if ((method == CommandMethod.Default))
            {
                if ((!(target == null) && !(this.ContextMenuPath == null)))
                {
                    method = CommandMethod.ContextMenu;
                }
                else
                {
                    if (!(this.MainMenuPath == null))
                    {
                        Utilities.LogMessage("MainMenuPath != null");
                        method = CommandMethod.MainMenu;
                    }
                    else
                    {
                        if (!(this.ToolbarPath == null))
                        {
                            method = CommandMethod.Toolbar;
                        }
                        else
                        {
                            if (!(this.KeyboardShortcut == null))
                            {
                                method = CommandMethod.Keyboard;
                            }
                            else
                            {
                                if (!(this.KeyboardShortcut2 == null))
                                {
                                    method = CommandMethod.Keyboard2;
                                }
                                else
                                {
                                    if (!(this.DirectCallInfo == null))
                                    {
                                        method = CommandMethod.DirectCall;
                                    }
                                    else
                                    {
                                        if (!(this.DirectCallInfo2 == null))
                                        {
                                            method = CommandMethod.DirectCall2;
                                        }
                                        else
                                        {
                                            throw new ArgumentException("Can\'t use default method for this command, because of insufficient configuration " +
                                                "of the CommandDescriptor.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Utilities.LogMessage("method: " + method.ToString());

            // application on top!
            app.BringToForeground();

            // perform selection, if required
            if ((!(target == null) && (method != CommandMethod.ContextMenu)))
            {
                target.Select();
            }

            // check that command method is supported
            if (!this.IsSupported(method))
            {
                throw new NotSupportedException((method.ToString() + " command method is not supported by this command."));
            }
        }
        #endregion

        #endregion

        #region Exceptions
        /// <summary>
        /// Exceptions Class
        /// </summary>
        public new class Exceptions
        {
            /// <summary>
            /// MenuItemNotEnabledException
            /// </summary>
            [Serializable()]
            public class MenuItemNotEnabledException : MauiException
            {
                /// <summary>
                /// MenuItemNotEnabledException
                /// </summary>
                /// <param name="message">Message</param>
                public MenuItemNotEnabledException(string message) :
                    base(message)
                {
                }

                /// <summary>
                /// MenuItemNotEnabledException
                /// </summary>
                /// <param name="message">Message</param>
                /// <param name="innerException">Inner Exception</param>
                public MenuItemNotEnabledException(string message, Exception innerException) :
                    base(message, innerException)
                {
                }

                /// <summary>
                /// MenuItemNotEnabledException
                /// </summary>
                /// <param name="info">Information</param>
                /// <param name="context">Context</param>
                protected MenuItemNotEnabledException(SerializationInfo info, StreamingContext context) :
                    base(info, context)
                {
                }
            }

            /// <summary>
            /// MenuItemNotVisibleException
            /// </summary>
            [Serializable()]
            public class MenuItemNotVisibleException : MauiException
            {
                /// <summary>
                /// MenuItemNotVisibleException
                /// </summary>
                /// <param name="message">Message</param>
                public MenuItemNotVisibleException(string message) :
                    base(message)
                {
                }

                /// <summary>
                /// MenuItemNotVisibleException
                /// </summary>
                /// <param name="message">Message</param>
                /// <param name="innerException">Inner Exception</param>
                public MenuItemNotVisibleException(string message, Exception innerException) :
                    base(message, innerException)
                {
                }

                /// <summary>
                /// MenuItemNotVisibleException
                /// </summary>
                /// <param name="info">Information</param>
                /// <param name="context">Context</param>
                protected MenuItemNotVisibleException(SerializationInfo info, StreamingContext context) :
                    base(info, context)
                {
                }
            }

            /// <summary>
            /// ToolbarItemNotEnabledException
            /// </summary>
            [Serializable()]
            public class ToolbarItemNotEnabledException : MauiException
            {
                /// <summary>
                /// ToolbarItemNotEnabledException
                /// </summary>
                /// <param name="message">Message</param>
                public ToolbarItemNotEnabledException(string message) :
                    base(message)
                {
                }

                /// <summary>
                /// ToolbarItemNotEnabledException
                /// </summary>
                /// <param name="message">Message</param>
                /// <param name="innerException">Inner Exception</param>
                public ToolbarItemNotEnabledException(string message, Exception innerException) :
                    base(message, innerException)
                {
                }

                /// <summary>
                /// ToolbarItemNotEnabledException
                /// </summary>
                /// <param name="info">Information</param>
                /// <param name="context">Context</param>
                protected ToolbarItemNotEnabledException(SerializationInfo info, StreamingContext context) :
                    base(info, context)
                {
                }
            }
        }
        #endregion
    }
}
