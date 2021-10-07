// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="Ribbon.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
//  Ribbon Control
// </summary>
// <history>
//  [mbickle] 14OCT09 Created
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Maui.GlobalExceptions;
    #endregion

    #region Interface Definition - IRibbonControl

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRibbonControl
    /// </summary>
    /// <history>
    ///  [mbickle] 14OCT09 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRibbonControl
    {
        /// <summary>
        /// Read-only property to access RibbonTab
        /// </summary>
        Ribbon.RibbonTab RibbonTab
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RibbonGroup
        /// </summary>
        Window RibbonGroup
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApplicationMenu Button.
        /// </summary>
        Button ApplicationMenuButton
        {
            get;
        }
    }
    #endregion

    /// <summary>
    /// Ribbon Control Class for accessing the Office WPF Ribbon Control
    /// </summary>
    public class Ribbon : Window, IRibbonControl
    {
        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// Ribbon Constructor.
        /// </summary>
        /// <param name="window">Ribbon Window.</param>
        /// ------------------------------------------------------------------
        public Ribbon(Window window)
            : base(window)
        {
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Ribbon Constructor.
        /// </summary>
        /// <param name="parent">Parent Window.</param>
        /// <param name="queryId">QueryId.</param>
        /// <remarks>
        /// Uses DefaultConrolTimeout
        /// </remarks>
        /// ------------------------------------------------------------------
        public Ribbon(Window parent, QID queryId)
            : base(parent, queryId, Constants.DefaultControlTimeout)        
        {
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Ribbon Constructor.
        /// </summary>
        /// <param name="parent">Parent Window.</param>
        /// <param name="queryId">QueryId.</param>
        /// <param name="timeout">Timeout</param>
        /// ------------------------------------------------------------------
        public Ribbon(Window parent, QID queryId, int timeout)
            : base(parent, queryId, timeout)
        {
        }
        
        #endregion

        #region Properties
        /// ------------------------------------------------------------------
        /// <summary>
        /// RibbonTab Collection
        /// </summary>
        /// <returns>RibbonTab Collection</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        public RibbonTab.RibbonTabCollection Tabs
        {
            get
            {
                return this.Controls.RibbonTab.Tabs;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Ribbon Group
        /// </summary>
        /// <returns>RibbonGroup</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        public Window SelectedGroup
        {
            get
            {
                return this.Controls.RibbonGroup;
            }
        }
        #endregion

        #region IRibbon Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        ///  [mbickle] 14OCT09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRibbonControl Controls
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
        ///  Exposes access to the RibbonTob control
        /// </summary>
        /// <history>
        ///  [mbickle] 14OCT09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RibbonTab IRibbonControl.RibbonTab
        {
            get
            {
                return new RibbonTab(this, QueryIds.RibbonTab, Constants.DefaultControlTimeout);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RibbonGroup control
        /// </summary>
        /// <history>
        ///  [mbickle] 14OCT09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Window IRibbonControl.RibbonGroup
        {
            get
            {
                return new Window(this, QueryIds.RibbonButtonGroup, Constants.DefaultControlTimeout);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ribbon ApplicationMenu Button control
        /// </summary>
        /// <history>
        ///  [mbickle] 14OCT09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRibbonControl.ApplicationMenuButton
        {
            get
            {
                return new Button(this, QueryIds.RibbonMainMenuToggleButton, Constants.DefaultControlTimeout);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Executes a deep menu path on Ribbon Application Menu. Use a path delimiter from Constants!
        /// </summary>
        /// <param name="menuPath">Path(string) of context menu items with path delimiters</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// <exception cref="System.ArgumentNullExcepgtion">System.ArgumentNullException</exception>
        /// <exception cref="Maui.Core.WinControls.MenuItem.Exceptions.MenuItemNotFoundException">Maui.Core.WinControls.MenuItem.Exceptions.MenuItemNotFoundException</exception>
        /// <history>
        /// [mbickle] 22OCT09 Created
        /// </history>
        /// <remarks>
        /// Only handles MenuItems.  Does not handle other control types that can be in the menu like Buttons.
        /// Won't work until RibbonControl button exposes Text Value 
        /// </remarks>
        public virtual void ExecuteApplicationtMenu(string menuPath, int timeout)
        {
            if (menuPath == null)
            {
                throw new ArgumentNullException("menuPath", "Ribbon.ExecuteApplicationMenu:: menuPath is Null");
            }

            Utilities.LogMessage("Ribbon.ExecuteApplicationMenu:: Menu Path: " + menuPath);
            Utilities.LogMessage("Ribbon.ExecuteApplicationMenu:: Timeout: " + timeout);

            char[] delimiter = Constants.PathDelimiter.ToCharArray();
            Menu menuItem;
            string[] menupath = null;
            int minSleepInterval = 1000;
            int maxSleepInterval = 2000;

            Sleeper sleeper = new Sleeper(timeout, minSleepInterval, maxSleepInterval);

            menupath = menuPath.Split(delimiter);

            // Bring up Application Menu
            this.Controls.ApplicationMenuButton.Click();
            IScreenElement screenElement;

            while (sleeper.IsNotExpired)
            {
                int i = 0;
                try
                {
                    // Look for Popup Window that should be the Application Menu
                    screenElement = CoreManager.MomConsole.MainWindow.ScreenElement.FindByPartialQueryId(2, ";[UIA, VisibleOnly]ClassName = 'Popup' && Role = 'window", null);
                    menuItem = new Menu(screenElement);

                    menuItem.WaitContextMenuWithTimeOut(Constants.DefaultContextMenuTimeout);
                    menuItem.ExecuteMenuItem(menupath[i]);
                    Utilities.LogMessage("Ribbon.ExecuteApplicationMenu:: First click on menu item: " + menupath[i]);

                    for (i = 1; i < menupath.Length; i++)
                    {
                        // Look for next Popup Window starting from previous Menu
                        screenElement = menuItem.ScreenElement.FindByPartialQueryId(2, ";[UIA, VisibleOnly, Distinct]ClassName = 'Popup' && Role = 'window", null);
                        menuItem = new Menu(screenElement);

                        menuItem.WaitContextMenuWithTimeOut(Constants.DefaultContextMenuTimeout);
                        Utilities.LogMessage("Ribbon.ExecuteApplicationMenu:: On menu item: " + menupath[i]);
                        menuItem.ExecuteMenuItem(menupath[i]);
                    }

                    Utilities.LogMessage("Ribbon.ExecuteApplicationMenu:: Menu operation successful.");
                    break;
                }
                catch (Exception x)
                {
                    sleeper.Sleep();
                    if (sleeper.IsExpired)
                    {
                        Utilities.TakeScreenshot("Ribbon.ExecuteApplicationMenu.Failed." + menupath[i]);
                        Utilities.LogMessage("Ribbon.ExecuteApplicationMenu:: Exception: " + x.ToString());
                        throw;
                    }
                }

                Utilities.LogMessage("Ribbon.ExecuteApplicationMenu:: Trying again.");
            }
        }
        #endregion

        #region Query ID's
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///  [mbickle] 14OCT09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RibbonTab query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string QidRibbonTab = ";[UIA]AutomationId=\'tabsScrollViewer\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RibbonButtonGroup query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string QidRibbonButtonGroup = ";[UIA]AutomationId=\'PART_SELECTEDGROUPSHOST\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RibbonSplitButtonMenu query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string QidRibbonSplitButtonMenu = ";[UIA]AutomationId=\'RibbonSplitButtonMenu\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RibbonSplitButtonMenu query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string QidRibbonMainMenuToggleButton = ";[UIA]AutomationId=\'PART_MainToggleButton\'";
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedRibbonTab;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedRibbonButtonGroup;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedRibbonSplitButtonMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedRibbonMainMenuToggleButton;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ribbon Tab qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 14OCT09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID RibbonTab
            {
                get
                {
                    if ((cachedRibbonTab == null))
                    {
                        cachedRibbonTab = new QID(QidRibbonTab);
                    }

                    return cachedRibbonTab;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ribbon Button Group qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 14OCT09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID RibbonButtonGroup
            {
                get
                {
                    if ((cachedRibbonButtonGroup == null))
                    {
                        cachedRibbonButtonGroup = new QID(QidRibbonButtonGroup);
                    }

                    return cachedRibbonButtonGroup;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ribbon SplitButton Menu qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 14OCT09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID RibbonSplitButtonMenu
            {
                get
                {
                    if ((cachedRibbonSplitButtonMenu == null))
                    {
                        cachedRibbonSplitButtonMenu = new QID(QidRibbonSplitButtonMenu);
                    }

                    return cachedRibbonSplitButtonMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ribbon MainMenu Toggle Button qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 14OCT09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID RibbonMainMenuToggleButton
            {
                get
                {
                    if ((cachedRibbonMainMenuToggleButton == null))
                    {
                        cachedRibbonMainMenuToggleButton = new QID(QidRibbonMainMenuToggleButton);
                    }

                    return cachedRibbonMainMenuToggleButton;
                }
            }

            #endregion
        }
        #endregion        

        /// <summary>
        /// RibbonTab Control
        /// </summary>
        public class RibbonTab : Window
        {
            #region Constructor
            /// --------------------------------------------------------------
            /// <summary>
            /// Ribbon Tab Constructor
            /// </summary>
            /// <param name="parent">Parent Window</param>
            /// --------------------------------------------------------------
            public RibbonTab(Window parent) 
                : base(parent)
            {                
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Ribbon Tab Constructor
            /// </summary>
            /// <param name="screenElement">ScreenElement</param>
            /// --------------------------------------------------------------
            public RibbonTab(IScreenElement screenElement)
                : base(screenElement)
            {                
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Ribbon Tab Constructor
            /// </summary>
            /// <param name="parent">Parent Window</param>
            /// <param name="queryId">QueryId</param>
            /// <param name="timeout">timeout</param>
            /// --------------------------------------------------------------
            public RibbonTab(Window parent, QID queryId, int timeout) 
                : base(parent, queryId, timeout)
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// Collection of RibbonTabs
            /// </summary>
            public RibbonTabCollection Tabs
            {
                get
                {
                    return new RibbonTabCollection(this);
                }
            }
            #endregion

            #region RibbonTabCollection Class
            /// ------------------------------------------------------------------
            /// <summary>
            /// RibbonTabCollection Class
            /// </summary>
            /// <history>
            /// [mbickle] 21OCT09 Created
            /// </history>
            /// ------------------------------------------------------------------
            [Serializable()]
            public class RibbonTabCollection : Collection<RibbonTab>
            {
                #region Member Variables
                /// <summary>
                /// NoIndex
                /// </summary>
                private const int NoIndex = -1;
                #endregion

                #region Constructors
                /// --------------------------------------------------------------
                /// <summary>
                /// WunderBarItemCollection Constructor
                /// </summary>
                /// --------------------------------------------------------------
                public RibbonTabCollection()
                    : base()
                {
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// RibbonTabCollection
                /// </summary>
                /// <param name="parent">Window</param>
                /// --------------------------------------------------------------
                public RibbonTabCollection(Window parent)
                    : base(new Collection<RibbonTab>())
                {
                    IScreenElement parentElement;
                    MauiCollection<IScreenElement> childElements;
                    Utilities.LogMessage("RibbonTabCollection: Getting RibbonTab collection.");
                    if (!(parent == null))
                    {
                        // we must be searching RibbonTab
                        parentElement = parent.ScreenElement;

                        childElements = parentElement.FindAllDescendants(-1, ";[UIA, VisibleOnly, FindAll, Distinct]role = 'text'", null);
                        Utilities.LogMessage(string.Format("RibbonTabCollection:: There are {0} Tabs", childElements.Count));
                        try
                        {
                            foreach (IScreenElement childElement in childElements)
                            {
                                this.Add(new RibbonTab(childElement));
                            }
                        }
                        catch (System.InvalidOperationException except)
                        {
                            throw new System.InvalidOperationException(
                                "RibbonTabCollection:: Can not find the RibbonTab Control item.",
                                except);
                        }

                        Utilities.LogMessage("RibbonTabCollection:: Done retrieving collection.");
                    }
                    else
                    {
                        throw new System.ArgumentException(
                            "RibbonTabCollection:: You must provide a valid RibbonTab object as the parent");
                    }
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// RibbonTabCollection Constructor
                /// </summary>
                /// <param name="value">RuleControl[]</param>
                /// --------------------------------------------------------------
                public RibbonTabCollection(RibbonTab[] value)
                    : base()
                {
                    this.AddRange(value);
                }
                #endregion

                #region Properties
                /// --------------------------------------------------------------
                /// <summary>
                /// Returns RibbonTab via Name
                /// </summary>
                /// <param name="name">RibbonTab String to return</param>
                /// <returns>RibbonTab</returns>
                /// <exception cref="WunderBar.Exceptions.WunderBarItemNotFoundException">
                /// WunderBar.Exceptions.WunderBarItemNotFoundException
                /// </exception>
                /// --------------------------------------------------------------
                public RibbonTab this[string name]
                {
                    get
                    {
                        RibbonTab result;
                        result = null;

                        // Loop through list to find specified value
                        foreach (RibbonTab item in Items)
                        {
                            if (item.ScreenElement.Name.Contains(name))
                            {
                                result = item;
                            }
                        }

                        // See if result is still null and if it is, throw an exception.
                        if (result == null)
                        {
                            throw new System.InvalidOperationException(
                                "RibbonTabCollection.RibbonTab:: Could not find RibbonTab: " + name);
                        }
                        else
                        {
                            return result;
                        }
                    }
                }
                #endregion

                #region Methods
                /// --------------------------------------------------------------
                /// <summary>
                /// Copies the elements of an array to the end of the 
                /// RibbonTabCollection 
                /// </summary>
                /// <param name="value">Value</param>
                /// --------------------------------------------------------------
                public void AddRange(RibbonTab[] value)
                {
                    int i = 0;

                    while (i < value.Length)
                    {
                        this.Add(value[i]);
                        i = (i + 1);
                    }
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// Adds contents of another RibbonTabCollection to the end 
                /// of the collection
                /// </summary>
                /// <param name="value">RibbonTabCollection</param>
                /// --------------------------------------------------------------
                public void AddRange(RibbonTabCollection value)
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("value", "RibbonTabCollection.AddRange:: value is null");
                    }

                    int i = 0;

                    while (i < value.Count)
                    {
                        this.Add(value[i]);
                        i = (i + 1);
                    }
                }
                #endregion
            }
            #endregion
        }
    }
}
