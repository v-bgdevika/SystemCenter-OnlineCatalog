// ---------------------------------------------------------------------------
// <copyright company="Microsoft" file="WunderBar.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
//  WunderBar base class.
// </summary>
// <history>
//  [mbickle] 09AUG05 Created
//  [mbickle] 14AUG05 Added WunderBarItems, WunderBarCollections and Exception Classes.
//                    Renamed private methods, refactored some code.
//  [mbickle] 07AUG08 Converted ActiveAccessibility over to ScreenElement for UIA support.
//                    Split out WunderBarItem/Collection Classes.
//                    Added QueryIds
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interfaces
    /// <summary>
    /// Console WunderBar Interface
    /// </summary>
    public interface IWunderBar
    {
        /// <summary>
        /// Wunderbar Count
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Click Button
        /// </summary>
        /// <param name="wunderBarButton">Wunderbar Button</param>
        void ClickButton(string wunderBarButton);

        ///// <summary>
        ///// Is Wunderbar Item Countable
        ///// </summary>
        ///// <param name="wunderBarAAObject">AA Object</param>
        ///// <param name="visibleOnly">Visible Only</param>
        ///// <returns>True/False</returns>
        ////bool IsWunderBarItemCountable(Maui.Core.ActiveAccessibility wunderBarAAObject, bool visibleOnly);

        ///// <summary>
        ///// Is Wunderbar Item Countable
        ///// </summary>
        ///// <param name="wunderBarAAObject">AA Object</param>
        ///// <returns>True/False</returns>
        ////bool IsWunderBarItemCountable(Maui.Core.ActiveAccessibility wunderBarAAObject);
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// WunderBar Control Class for accessing the WunderBar buttons.
    /// </summary>
    /// <history>
    ///  [mbickle] 09AUG05 Created
    /// </history>
    /// ------------------------------------------------------------------
    public class WunderBar : Control, IWunderBar
    {
        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// WunderBar Constructor
        /// 
        /// This version of the constructor is needed for the web console
        /// as the NavigationPane control is not a parent to the Wunderbar
        /// control.
        /// </summary>
        /// ------------------------------------------------------------------
        public WunderBar()
            : base(CoreManager.MomConsole.MainWindow, MomControls.WunderBar.QueryIds.WunderBar, 5000)
        {
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// WunderBar Constructor
        /// </summary>
        /// <param name="navigationPane">NavigationPane</param>
        /// ------------------------------------------------------------------
        public WunderBar(NavigationPane navigationPane)
            : base(navigationPane)
        {
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// WunderBar Constructor 
        /// </summary>
        /// <param name="navPane">NavigationPane window</param>
        /// <param name="winFormsID">WinForms Id</param>
        /// ------------------------------------------------------------------
        public WunderBar(NavigationPane navPane, string winFormsID)
            : base(navPane, winFormsID)
        {
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// WunderBar Constructor 
        /// </summary>
        /// <param name="navPane">NavigationPane window</param>
        /// <param name="queryId">QID</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// ------------------------------------------------------------------
        public WunderBar(NavigationPane navPane, QID queryId, int timeout)
            : base(navPane, queryId, timeout)
        {
        }

        #endregion

        #region "Properties"
        /// ------------------------------------------------------------------
        /// <summary>
        /// WunderBarItems Collection Items
        /// </summary>
        /// <returns>WunderBarItemCollection</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        public WunderBarItem.WunderBarItemCollection WunderBarItems
        {
            get
            {
                return this.GetWunderBarItems();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Button Count
        /// </summary>
        /// <history>
        ///  [mbickle] 10AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public int Count
        {
            get
            {
                return this.WunderBarItems.Count;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Splitter
        /// </summary>
        /// <returns>WunderBarItemCollection</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        public IScreenElement Splitter
        {
            get
            {
                IScreenElement splitter = null;

                switch (this.ScreenElement.FrameworkId)
                {
                    case "WPF":
                        splitter = this.ScreenElement.FindByPartialQueryId(";[UIA]AutomationId = 'Splitter'", null);
                        break;
                    case "WinForm":
                        splitter = this.ScreenElement.FindByPartialQueryId(QueryIds.Splitter.ToString(), null);
                        break;
                }

                return splitter;
            }
        }
        #endregion

        #region Public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// ClickButton
        /// </summary>
        /// <param name="wunderBarButton">WunderBar Button Name</param>
        /// ------------------------------------------------------------------
        public void ClickButton(string wunderBarButton)
        {
            IScreenElement button;

            button = this.GetWunderBarButton(wunderBarButton);
            button.LeftButtonClick(-1, -1);
            this.ScreenElement.WaitForReady();
        }
        #endregion

        #region Private Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the WunderBarItems
        /// </summary>
        /// <returns>WunderBarItems Collection</returns>
        /// <history>
        /// [mbickle] 09AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        private WunderBarItem.WunderBarItemCollection GetWunderBarItems()
        {
            WunderBarItem.WunderBarItemCollection wunderBarItems = new WunderBarItem.WunderBarItemCollection();
            MauiCollection<IScreenElement> screenElements = this.ScreenElement.FindAllDescendants(-1, WunderBar.QueryIds.Buttons.ToString(), null);

            // Looping through the wunderBarButtonNames and adding
            // them to a collection to get the count.  
            foreach (IScreenElement button in screenElements)
            {
                if (button != null)
                {
                    // Adding button to collection
                    wunderBarItems.Add(new WunderBarItem(this, button));
                }
            }

            return wunderBarItems;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// GetWunderBarButton - Find the currently active button to select.
        /// </summary>
        /// <param name="buttonName">Name of Button</param>
        /// <returns>AA Button Reference</returns>
        /// <exception cref="Exceptions.WunderBarItemNotFoundException">
        /// Exceptions.WunderBarItemNotFoundException
        /// </exception>
        /// ------------------------------------------------------------------
        private IScreenElement GetWunderBarButton(string buttonName)
        {
            IScreenElement button = null;

            Utilities.LogMessage(
                "WunderBar.GetWunderBarButton:: Looking for Button: " + buttonName);
            int retry = 0;
            int maxRetry = 5;

            while (retry < maxRetry)
            {
                try
                {
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            button = this.ScreenElement.FindByPartialQueryId(";[UIA, VisibleOnly]Name = ~'" + buttonName + "*' && Role = 'push button'", null);
                            break;

                        case ProductSkuLevel.Web:
                            button = this.ScreenElement.FindByPartialQueryId(";[UIA, VisibleOnly]Name = ~'" + buttonName + "*'", null);
                            break;

                        default:
                            break;
                    }

                    //break while loop if get the wunderbar button without exceptions.
                    break;
                }
                catch (System.InvalidOperationException)
                {
                    Utilities.LogMessage("WunderBar.GetWunderBarButton:: Failed to get the Wunderbar button :" + buttonName + ", will try again later");
                    Utilities.LogMessage("WunderBar.GetWunderBarButton:: " + this.ScreenElement.Value);
                    Sleeper.Delay(Constants.OneSecond * 3);
                }

                retry++;

            }


            // Check to make sure Button is valid
            if (button != null)
            {
                return button;
            }
            else
            {
                MauiCollection<IScreenElement> buttonCollection = this.ScreenElement.FindAllDescendants(-1, ";[FindAll,UIA, VisibleOnly]AutomationId ='PART_Button'", null);
                foreach (IScreenElement _button in buttonCollection)
                {
                    Utilities.LogMessage("Button name:: " + _button.Name);
                    Utilities.LogMessage("Button role:: " + _button.Role);

                    if (_button.Name.ToLower().Contains(buttonName.ToLower()))
                    {
                        button = _button;
                        break;
                    }
                }
                if (button == null)
                {
                    throw new Exceptions.WunderBarItemNotFoundException(
                        "WunderBar.GetWunderBarButton:: Could not find button in collection");
                }
                else
                {
                    return button;
                }
            }
        }
        #endregion

        #region Exceptions
        /// ------------------------------------------------------------------
        /// <summary>
        /// WunderBar Exceptions Class
        /// </summary>
        /// <history>
        /// [mbickle] 09AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static new class Exceptions
        {
            /// --------------------------------------------------------------
            /// <summary>
            /// WunderBarNotFoundException Class.
            /// </summary>
            /// --------------------------------------------------------------
            [Serializable()]
            public class WunderBarNotFoundException : MauiException
            {
                /// ----------------------------------------------------------
                /// <summary>
                /// WunderBarNotFoundException
                /// </summary>
                /// ----------------------------------------------------------
                public WunderBarNotFoundException()
                    : base()
                {
                }

                /// ----------------------------------------------------------
                /// <summary>
                /// WunderBarNotFoundException
                /// </summary>
                /// <param name="message">Message</param>
                /// ----------------------------------------------------------
                public WunderBarNotFoundException(string message)
                    : base(message)
                {
                }

                /// ----------------------------------------------------------
                /// <summary>
                /// WunderBarNotFoundException
                /// </summary>
                /// <param name="message">Message</param>
                /// <param name="innerException">Inner Exception</param>
                /// ----------------------------------------------------------
                public WunderBarNotFoundException(string message, Exception innerException)
                    : base(message, innerException)
                {
                }

                /// <summary>
                /// WunderBarNotFoundException
                /// </summary>
                /// <param name="info">SerializationInfo</param>
                /// <param name="context">StreamingContext</param>
                protected WunderBarNotFoundException(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }

            /// ----------------------------------------------------------
            /// <summary>
            /// WunderBarItemNotFound Exception 
            /// </summary>
            /// ----------------------------------------------------------
            [Serializable()]
            public class WunderBarItemNotFoundException : MauiException
            {
                /// ----------------------------------------------------------
                /// <summary>
                /// WunderBarItemNotFoundException
                /// </summary>
                /// ----------------------------------------------------------
                public WunderBarItemNotFoundException()
                    : base()
                {
                }

                /// ----------------------------------------------------------
                /// <summary>
                /// WunderBarItemNotFoundException
                /// </summary>
                /// <param name="message">Message</param>
                /// ----------------------------------------------------------
                public WunderBarItemNotFoundException(string message)
                    : base(message)
                {
                }

                /// ----------------------------------------------------------
                /// <summary>
                /// WunderBarItemNotFoundException
                /// </summary>
                /// <param name="message">Message</param>
                /// <param name="innerException">Inner Exception</param>
                /// ----------------------------------------------------------
                public WunderBarItemNotFoundException(string message, Exception innerException)
                    : base(message, innerException)
                {
                }

                /// ----------------------------------------------------------
                /// <summary>
                /// WunderBarItemNotFoundException
                /// </summary>
                /// <param name="info">SerializationInfo</param>
                /// <param name="context">StreamingContext</param>
                /// ----------------------------------------------------------
                protected WunderBarItemNotFoundException(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
        }
        #endregion

        #region Query ID's
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///  [mbickle] 6/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants
            /// --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DeskTop Wunderbar query id
            /// </summary>
            /// --------------------------------------------------------------
            private const string ResourceWunderBarDeskTop = ";[UIA]Name = 'NavigationPanel'";

            /// --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Console Wunderbar query id
            /// </summary>
            /// --------------------------------------------------------------
            private const string ResourceWunderBarWeb = ";[UIA]AutomationId = 'WorkspaceSelector'";
            // Role wasn't working for us here... removing...
            //private const string ResourceWunderBarWeb = ";[UIA]AutomationId = 'WorkspaceSelector' && Role = 'list item'";

            /// --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Splitter query id
            /// </summary>
            /// --------------------------------------------------------------
            private const string ResourceSplitter = ";[UIA]Name =>'WunderbarViewSplitter'";

            /// <summary>
            /// Buttons.
            /// </summary>
            private const string ResourceButtons = ";[UIA, FindAll, VisibleOnly]Name = ~'*Button'";

            /// <summary>
            /// Contains resource string for web console navigation pane menu item scroll viewer query id
            /// </summary>
            private const string ResourceWebConsoleNaviPane = ";[UIA]AutomationId = 'MainNavigationTree'";
            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedWunderBar;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedSplitter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedButtons;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedWebConsoleNaviPane;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WunderBar resource qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID WunderBar
            {
                get
                {
                    if ((cachedWunderBar == null))
                    {
                        switch (ProductSku.Sku)
                        {
                            case ProductSkuLevel.Mom:
                                cachedWunderBar = new QID(ResourceWunderBarDeskTop);
                                break;
                            case ProductSkuLevel.Web:
                                cachedWunderBar = new QID(ResourceWunderBarWeb);
                                break;
                        }
                    }

                    return cachedWunderBar;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Splitter translated resource qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Splitter
            {
                get
                {
                    if ((cachedSplitter == null))
                    {
                        cachedSplitter = new QID(ResourceSplitter);
                    }

                    return cachedSplitter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Buttons qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 6/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Buttons
            {
                get
                {
                    if ((cachedButtons == null))
                    {
                        cachedButtons = new QID(ResourceButtons);
                    }

                    return cachedButtons;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Web Console navigation pane qid string
            /// </summary>
            /// <history>
            ///  [v-raienl] 8/12/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID WebConsoleNaviPane
            {
                get
                {
                    if ((cachedWebConsoleNaviPane == null))
                    {
                        cachedWebConsoleNaviPane = new QID(ResourceWebConsoleNaviPane);
                    }

                    return cachedWebConsoleNaviPane;
                }
            }
            #endregion
        }
        #endregion
    }
}