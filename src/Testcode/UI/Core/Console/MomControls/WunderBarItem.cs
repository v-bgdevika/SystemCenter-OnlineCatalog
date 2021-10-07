// ---------------------------------------------------------------------------
// <copyright company="Microsoft" file="WunderBarItem.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
//  WunderBarItem class.
// </summary>
// <history>
//  [mbickle] 07AUG08 Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Collections;
    using System.Runtime.Serialization;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;
    using Mom.Test.UI.Core.Common;
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// WunderBarItem Class
    /// </summary>
    /// <history>
    /// [mbickle] 09AUG05 Created
    /// </history>
    /// ------------------------------------------------------------------
    public class WunderBarItem
    {
        #region Member Variables

        /// <summary>
        /// NoIndex
        /// </summary>
        private const int NoIndex = -1;

        /// <summary>
        /// WunderBar ScreenElement
        /// </summary>
        private IScreenElement wunderBarScreenElement;

        /// <summary>
        /// WunderBar
        /// </summary>
        private WunderBar wunderBar;
        #endregion

        #region Constructor
        /// --------------------------------------------------------------
        /// <summary>
        /// WunderBarItem
        /// </summary>
        /// <param name="parentWunderBar">WunderBar</param>
        /// <param name="itemIndex">Item Index</param>
        /// --------------------------------------------------------------
        public WunderBarItem(WunderBar parentWunderBar, int itemIndex)
        {
            this.Init(parentWunderBar, itemIndex, null, null);
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// WunderBarItem
        /// </summary>
        /// <param name="parentWunderBar">WunderBar</param>
        /// <param name="itemName">Item Name</param>
        /// --------------------------------------------------------------
        public WunderBarItem(WunderBar parentWunderBar, string itemName)
        {
            this.Init(parentWunderBar, NoIndex, itemName, null);
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// WunderBarItem
        /// </summary>
        /// <param name="parentWunderBar">WunderBar</param>
        /// <param name="screenElement">Screen Element</param>
        /// --------------------------------------------------------------
        public WunderBarItem(WunderBar parentWunderBar, IScreenElement screenElement)
        {
            this.Init(parentWunderBar, NoIndex, null, screenElement);
        }
        #endregion

        #region Properties
        /// --------------------------------------------------------------
        /// <summary>
        /// Owner WunderBar for this item.
        /// </summary>
        /// --------------------------------------------------------------
        public WunderBar ParentWunderBar
        {
            get
            {
                return this.wunderBar;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// WunderBar Item Text
        /// </summary>
        /// --------------------------------------------------------------
        public string Text
        {
            get
            {
                return this.ScreenElement.Name;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Value
        /// </summary>
        /// --------------------------------------------------------------
        public string Value
        {
            get
            {
                return this.ScreenElement.Value;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// ScreenElement
        /// </summary>
        /// --------------------------------------------------------------
        public IScreenElement ScreenElement
        {
            get
            {
                return this.wunderBarScreenElement;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Top Coords
        /// </summary>
        /// --------------------------------------------------------------
        public int Top
        {
            get
            {
                return this.ScreenElement.GetBoundingRectangle().Y;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Bottom Coords
        /// </summary>
        /// --------------------------------------------------------------
        public int Bottom
        {
            get
            {
                return this.ScreenElement.GetBoundingRectangle().Y + this.ScreenElement.GetBoundingRectangle().Height;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Right Coords
        /// </summary>
        /// --------------------------------------------------------------
        public int Right
        {
            get
            {
                return this.ScreenElement.GetBoundingRectangle().X + this.ScreenElement.GetBoundingRectangle().Width;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Left Coords
        /// </summary>
        /// --------------------------------------------------------------
        public int Left
        {
            get
            {
                return this.ScreenElement.GetBoundingRectangle().X;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Control Width 
        /// </summary>
        /// --------------------------------------------------------------
        public int Width
        {
            get
            {
                return this.ScreenElement.GetBoundingRectangle().Width;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Control Height
        /// </summary>
        /// --------------------------------------------------------------
        public int Height
        {
            get
            {
                return this.ScreenElement.GetBoundingRectangle().Height;
            }
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Returns the 0 based index for a given WunderBarItem.
        /// </summary>
        /// <exception cref="WunderBar.Exceptions.WunderBarItemNotFoundException">
        /// WunderBar.Exceptions.WunderBarItemNotFoundException
        /// </exception>
        /// --------------------------------------------------------------
        public int Index
        {
            get
            {
                IScreenElement parentElement;
                int tempIndex = 0;

                parentElement = this.wunderBar.ScreenElement;
                foreach (IScreenElement childElement in parentElement.FindAllDescendants(-1, WunderBar.QueryIds.Buttons.ToString(), null))
                {
                    if (this.wunderBarScreenElement.Equals(childElement))
                    {
                        return tempIndex;
                    }
                    else
                    {
                        tempIndex += 1;
                    }
                }

                throw new System.InvalidOperationException("Could not find matching WunderBar item retrieving WunderBarItem.Index property");
            }
        }
        #endregion

        #region Public Methods
        /// --------------------------------------------------------------
        /// <summary>
        /// Single Click - LeftButton
        /// </summary>
        /// --------------------------------------------------------------
        public void Click()
        {
            this.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Click w/ClickType - LeftButton
        /// </summary>
        /// <param name="clickType">MouseClickType</param>
        /// --------------------------------------------------------------
        public void Click(MouseClickType clickType)
        {
            this.Click(clickType, MouseFlags.LeftButton);
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Single Click w/Button
        /// </summary>
        /// <param name="button">MouseFlags button</param>
        /// --------------------------------------------------------------
        public void Click(MouseFlags button)
        {
            this.Click(MouseClickType.SingleClick, button);
        }

        /// --------------------------------------------------------------
        /// <summary>
        /// Mouse Click
        /// </summary>
        /// <param name="clickType">MouseClickType</param>
        /// <param name="button">MouseFlags</param>
        /// --------------------------------------------------------------
        public void Click(MouseClickType clickType, MouseFlags button)
        {
            Mouse.Click(clickType, button, this.Left + (this.Width / 2), this.Top + (this.Height / 2));

            this.ScreenElement.WaitForReady();
        }

        #endregion

        #region Private Methods
        /// --------------------------------------------------------------
        /// <summary>
        /// Initialize the WunderBarItem Control
        /// </summary>
        /// <param name="parentWunderBar">WunderBar</param>
        /// <param name="itemIndex">Item Index</param>
        /// <param name="itemName">Item Name</param>
        /// <param name="screenElement">ScreenElement</param>
        /// <exception cref="WunderBar.Exceptions.WunderBarItemNotFoundException">
        /// WunderBar.Exceptions.WunderBarItemNotFoundException</exception>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// --------------------------------------------------------------
        private void Init(
            WunderBar parentWunderBar,
            int itemIndex,
            string itemName,
            IScreenElement screenElement)
        {
            IScreenElement parentElement;
            int searchIndex;
            MauiCollection<IScreenElement> screenElementCollection;
            bool visibleOnly = true;

            if (!(parentWunderBar == null))
            {
                this.wunderBar = parentWunderBar;
                if (!(screenElement == null))
                {
                    // we have a known ScreenElement object and WunderBar
                    this.wunderBarScreenElement = screenElement;
                }
                else
                {
                    // we must be searching WunderBarItem
                    parentElement = parentWunderBar.ScreenElement;
                    try
                    {
                        if (itemIndex > -1)
                        {
                            screenElementCollection = parentElement.FindAllDescendants(-1, WunderBar.QueryIds.Buttons.ToString(), null);

                            searchIndex = itemIndex;
                            foreach (IScreenElement childElement in screenElementCollection)
                            {
                                // make sure we're the correct visible state, we are not 0-height or 0 width
                                if (searchIndex == 0)
                                {
                                    // found it
                                    this.wunderBarScreenElement = childElement;
                                    return;
                                }
                                else
                                {
                                    // we just skipped over one valid WunderBar item
                                    searchIndex = (searchIndex - 1);
                                }
                            }

                            throw new WunderBar.Exceptions.WunderBarItemNotFoundException(
                                "WunderBarItem.Init:: Could not find item as index " + itemIndex +
                                " in the set of MSAA children");
                        }
                        else
                        {
                            // we are searching by name
                            if (visibleOnly)
                            {
                                screenElementCollection = parentElement.FindAllDescendants(-1, WunderBar.QueryIds.Buttons.ToString(), null);

                                if (!(screenElementCollection == null && screenElementCollection.Count > 0))
                                {
                                    this.wunderBarScreenElement = screenElementCollection[0];
                                }
                                else
                                {
                                    throw new WunderBar.Exceptions.WunderBarItemNotFoundException(
                                        "WunderBarItem.Init:: Could not find item by name " + itemName +
                                        " in the visibleOnly set");
                                }
                            }
                            else
                            {
                                screenElementCollection = parentElement.FindAllDescendants(-1, WunderBar.QueryIds.Buttons.ToString(), null);

                                if (!(screenElementCollection == null) && (screenElementCollection.Count > 0))
                                {
                                    this.wunderBarScreenElement = screenElementCollection[0];
                                }
                                else
                                {
                                    throw new WunderBar.Exceptions.WunderBarItemNotFoundException(
                                        "WunderBarItem.Init:: Could not find item by name " + itemName +
                                        " in the overall set");
                                }
                            }
                        }
                    }
                    catch (System.InvalidOperationException except)
                    {
                        throw new WunderBar.Exceptions.WunderBarItemNotFoundException(
                            "WunderBarItem.Init:: Can not find the WunderBar item",
                            except);
                    }
                }
            }
            else
            {
                throw new System.ArgumentException(
                    "WunderBarItem.Init:: You must provide a valid WunderBar object as the parent");
            }
        }
        #endregion

        #region WunderBarItemCollection Class
        /// ------------------------------------------------------------------
        /// <summary>
        /// WunderBarItemCollection Class
        /// </summary>
        /// <history>
        /// [mbickle] 09AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        [Serializable()]
        public class WunderBarItemCollection : Collection<WunderBarItem>
        {
            #region Constructors
            /// --------------------------------------------------------------
            /// <summary>
            /// WunderBarItemCollection Constructor
            /// </summary>
            /// --------------------------------------------------------------
            public WunderBarItemCollection()
                : base()
            {
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// WunderBarCollection Constructor
            /// </summary>
            /// <param name="value">WunderBarItem[]</param>
            /// --------------------------------------------------------------
            public WunderBarItemCollection(WunderBarItem[] value)
                : base()
            {
                this.AddRange(value);
            }
            #endregion

            #region Properties
            /// --------------------------------------------------------------
            /// <summary>
            /// Returns WunderBarItem via Name
            /// </summary>
            /// <param name="name">TaskItem String to return</param>
            /// <returns>WunderBarItem</returns>
            /// <exception cref="WunderBar.Exceptions.WunderBarItemNotFoundException">
            /// WunderBar.Exceptions.WunderBarItemNotFoundException
            /// </exception>
            /// --------------------------------------------------------------
            public WunderBarItem this[string name]
            {
                get
                {
                    WunderBarItem result;
                    result = null;

                    // Loop through list to find specified value
                    foreach (WunderBarItem item in Items)
                    {
                        if (item.Text.Contains(name))
                        {
                            result = item;
                        }
                    }

                    // See if result is still null and if it is, throw an exception.
                    if (result == null)
                    {
                        throw new System.InvalidOperationException(
                            "WunderBarItemCollection.WunderBarItem:: Could not find WunderBarItem: " + name);
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            #endregion

            #region Methods
            /// <summary>
            /// Contains
            /// </summary>
            /// <param name="value">String value to find in WunderBarItems Collection</param>
            /// <returns>True or False</returns>
            public bool Contains(string value)
            {
                bool contains = false;

                foreach (WunderBarItem item in this.Items)
                {
                    if (item.Text.Contains(value))
                    {
                        contains = true;
                        break;
                    }
                }

                return contains;
            }
            
            /// --------------------------------------------------------------
            /// <summary>
            /// Copies the elements of an array to the end of the 
            /// WunderBarItemCollection 
            /// </summary>
            /// <param name="value">Value</param>
            /// --------------------------------------------------------------
            public void AddRange(WunderBarItem[] value)
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
            /// Adds contents of another WunderBarItemCollection to the end 
            /// of the collection
            /// </summary>
            /// <param name="value">WunderBarItemCollection</param>
            /// --------------------------------------------------------------
            public void AddRange(WunderBarItemCollection value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "WunderBar.AddRange:: value is null");
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
