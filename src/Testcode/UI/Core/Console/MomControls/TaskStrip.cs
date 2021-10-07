// ---------------------------------------------------------------------------
// <copyright company="Microsoft" file="TaskStrip.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
//  TaskStrip Window base class.
// </summary>
// <history>
//  [mbickle] 11AUG05 Created
//  [mbickle] 08AUG08 Converted ActiveAccessibility to ScreenElement
//                    Fixed to work against Wpf and WinForms.
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
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Maui.GlobalExceptions;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interfaces
    /// <summary>
    /// Console TaskStrip Interface.
    /// </summary>
    public interface ITaskStrip
    {
        /// <summary>
        /// Gets TaskStripItems property.
        /// </summary>
        TaskStrip.TaskStripItemCollection TaskStripItems
        {
            get;
        }
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// TaskStrip Control Class for accessing the TaskStrips.
    /// </summary>
    /// <history>
    ///  [mbickle] 11AUG05 Created
    /// </history>
    /// ------------------------------------------------------------------
    public class TaskStrip : Control, ITaskStrip
    {
        #region Member Variables
        #endregion

        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// TaskStrip Class.
        /// </summary>
        /// <param name="taskPane">TaskPane Window.</param>
        /// ------------------------------------------------------------------
        public TaskStrip(Window taskPane)
            : base(taskPane)
        {
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Task Strip Class.
        /// </summary>
        /// <param name="taskPane">TaskPane Window.</param>
        /// <param name="caption">Caption of TaskStrip.</param>
        /// <remarks>
        /// This does a wildcard search for the Caption specified.
        /// </remarks>
        /// ------------------------------------------------------------------
        public TaskStrip(Window taskPane, string caption)
            // Escape character in parameter caption, the issue found on loc os + loc build, e.g. FR, caption may be Mod¨¨les de packs d'administration, and the ' in it need escaped
            : base(taskPane, new QID(";[UIA, VisibleOnly]Name = ~'" + caption.Replace("'", "''") + "' && Role = 'grouping'"), Constants.DefaultViewLoadTimeout)
        {
            
        }

        #endregion

        #region "Properties"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets TaskStripItems Object.
        /// </summary>
        /// <returns>TaskStripItemCollection</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        public TaskStripItemCollection TaskStripItems
        {
            get
            {
                return this.GetTaskStripItems();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets a value indicating whether TaskStrip Window Collapsed.
        /// </summary>
        /// ------------------------------------------------------------------
        public bool IsCollapsed
        {
            get
            {
                if (this.ScreenElement.State.Contains(MsaaResources.Strings.Collapsed))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets a value indicating whether TaskStrip Window Expanded.
        /// </summary>
        /// ------------------------------------------------------------------
        public bool IsExpanded
        {
            get
            {
                if (this.ScreenElement.State.Contains(MsaaResources.Strings.Expanded))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region Public Static Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// IsTaskSTripItemCountable, see if we should count the AA Object.
        /// </summary>
        /// <param name="taskStripAAObject">ActiveAccessiblity Object.</param>
        /// <returns>True or False.</returns>
        /// ------------------------------------------------------------------
        public static bool IsTaskStripItemCountable(ActiveAccessibility taskStripAAObject)
        {
            return IsTaskStripItemCountable(taskStripAAObject, true);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// IsTaskStripItemCountable, see if we should count the AA Object.
        /// </summary>
        /// <param name="taskStripAAObject">ActiveAccessiblity Object.</param>
        /// <param name="visibleOnly">Visible Only (T/F).</param>
        /// <returns>True or False.</returns>
        /// ------------------------------------------------------------------
        public static bool IsTaskStripItemCountable(ActiveAccessibility taskStripAAObject, bool visibleOnly)
        {
            if (taskStripAAObject == null)
            {
                throw new ArgumentNullException("taskStripAAObject", "TaskStrip.IsTaskStripItemCountable:: taskStripAAObject is null");
            }

            return (visibleOnly && taskStripAAObject.Visible &&
                taskStripAAObject.Height > 0 && taskStripAAObject.Width > 0) ||
                (visibleOnly = false);
        }
        #endregion

        #region Public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Clicks the TaskStrip Header.
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickHeader()
        {
            Utilities.LogMessage("TaskStrip.Collapse:: Product Sku: " + ProductSku.Sku);
            Utilities.LogMessage("TaskStrip.Collapse:: IsExpanded: " + this.IsExpanded.ToString());

            if (this.IsExpanded)
            {
                // It's different based on Desktop/Web console.
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        this.ScreenElement.FindByPartialQueryId(";[UIA]Role = 'push button'", null).RightButtonClick(-1, -1);
                        break;
                    case ProductSkuLevel.Web:
                        this.ScreenElement.FindByPartialQueryId(";[UIA]Role = 'push button'", null).LeftButtonClick(-1, -1);
                        break;
                    default:
                        throw new System.InvalidOperationException("TaskStrip.ClickLink:: Unexpected Product Sku: " + ProductSku.Sku);
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// ClickLink
        /// </summary>
        /// <param name="link">Link to click</param>
        /// <param name="button">MouseFlags button</param>
        /// <history>
        /// [mbickle] 13OCT08 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickLink(string link, MouseFlags button)
        {
            Control linkElement = null;

            Utilities.LogMessage("TaskStrip.ClickLink:: Link: " + link);
            Utilities.LogMessage("TaskStrip.ClickLink:: Button: " + button.ToString());
            Utilities.LogMessage("TaskStrip.ClickLink:: Product Sku: " + ProductSku.Sku);

            int retry = 0;
            int maxRetry = 5;
            while (retry < maxRetry)
            {
                try
                {
                    // Search for Link, it's different based on Desktop/Web console.
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            // Escape character in parameter link, the issue found on loc os + loc build, e.g. FR, caption may be Assistant Ajout &d'analyse, and the ' in it need escaped
                            linkElement = new Control(this, new QID(";[UIA, VisibleOnly]Name = ~'" + link.Replace("'", "''") + "' && Role = 'text'"), Constants.DefaultViewLoadTimeout);
                            break;
                        case ProductSkuLevel.Web:
                            linkElement = new Control(this, new QID(";[UIA, VisibleOnly]Name = ~'" + link + "' && Role = 'push button'"), Constants.DefaultViewLoadTimeout);
                            break;
                        default:
                            throw new System.InvalidOperationException("TaskStrip.ClickLink:: Unexpected Product Sku: " + ProductSku.Sku);
                    }

                    if (linkElement == null)
                    {
                        throw new Window.Exceptions.WindowNotFoundException("Failed to get the link :" + link + " in the Tasks pane.");
                    }

                    CoreManager.MomConsole.Waiters.WaitForWindowEnabled(linkElement as Window, Constants.OneSecond * 60);

                    // Click the Link based on MouseFlag
                    switch (button)
                    {
                        case MouseFlags.RightButton:
                            linkElement.ScreenElement.RightButtonClick(-1, -1, true, KeyboardFlags.NoFlag);
                            break;
                        case MouseFlags.LeftButton:
                            linkElement.ScreenElement.LeftButtonClick(-1, -1, true, KeyboardFlags.NoFlag);
                            break;
                        default:
                            linkElement.ScreenElement.LeftButtonClick(-1, -1, true, KeyboardFlags.NoFlag);
                            break;
                    }

                    break;
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("TaskStrip.ClickLink:: Failed to get the link :" + link + ", will try again later");
                    Sleeper.Delay(Constants.DefaultDialogTimeout);

                    retry++;
                    if (retry == maxRetry)
                        throw;
                }
                catch (System.InvalidOperationException)
                {
                    Utilities.LogMessage("TaskStrip.ClickLink:: Failed to click the link :" + link + ", will try again later");
                    Sleeper.Delay(Constants.DefaultDialogTimeout);

                    retry++;
                    if (retry == maxRetry)
                        throw;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the TaskStripItems.
        /// </summary>
        /// <returns>TaskStripItems Collection.</returns>
        /// <history>
        /// </history>
        /// ------------------------------------------------------------------
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "TODO")]
        public TaskStripItemCollection GetTaskStripItems()
        {
            MauiCollection<IScreenElement> screenElements;
            TaskStripItemCollection taskStripItems = new TaskStripItemCollection();

            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    screenElements = RPFSupport.RPF.FindAllScreenElements(this.ScreenElement, QueryIds.WPFLinks.ToString(), null, -1);
                    break;
                case ProductSkuLevel.Web:
                    screenElements = RPFSupport.RPF.FindAllScreenElements(this.ScreenElement, QueryIds.SilverLightLinks.ToString(), null, -1);
                    break;
                default:
                    throw new System.InvalidOperationException("TaskStrip.GetTaskStripItems:: Unexpected Product Sku: " + ProductSku.Sku);
            }

            foreach (IScreenElement childElement in screenElements)
            {
                Utilities.LogMessage("TaskStrip.GetTaskStripItems.Name: " + childElement.Name);

                // make sure we're not a separator
                if ((String.Compare(childElement.Role, MsaaRole.Separator.ToString(), StringComparison.OrdinalIgnoreCase)) != 0)
                {
                    taskStripItems.Add(new TaskStripItem(this, childElement));
                }
            }

            return taskStripItems;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Collapses the TaskStripWindow if Expanded.
        /// </summary>
        /// <history>
        /// [mbickle] 05MAY09: Switched from doing LeftButtonClick() on TaskStrip to
        ///                    using UIA's Toggle to try and eliminate odd timing issues.
        /// </history>
        /// ------------------------------------------------------------------
        public void Collapse()
        {
            Utilities.LogMessage("TaskStrip.Collapse:: Product Sku: " + ProductSku.Sku);
            Utilities.LogMessage("TaskStrip.Collapse:: IsExpanded: " + this.IsExpanded.ToString());

            if (this.IsExpanded)
            {
                // It's different based on Desktop/Web console.
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        UIASupport element = new UIASupport((System.Windows.Automation.AutomationElement)this.ScreenElement.FindByPartialQueryId(";[UIA]Role = 'push button'", null).AutomationElement);
                        element.ToggleState = System.Windows.Automation.ToggleState.Off;
                        break;
                    case ProductSkuLevel.Web:
                        this.ScreenElement.FindByPartialQueryId(";[UIA]Role = 'push button'", null).LeftButtonClick(-1, -1);
                        break;
                    default:
                        throw new System.InvalidOperationException("TaskStrip.ClickLink:: Unexpected Product Sku: " + ProductSku.Sku);
                }

                this.ScreenElement.WaitForReady();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Expands the TaskStripWindow if Collapsed.
        /// </summary>
        /// <history>
        /// [mbickle] 05MAY09: Switched from doing LeftButtonClick() on TaskStrip to
        ///                    using UIA's Toggle to try and eliminate odd timing issues.
        /// </history>
        /// ------------------------------------------------------------------
        public void Expand()
        {
            Utilities.LogMessage("TaskStrip.Expand:: Product Sku: " + ProductSku.Sku);
            Utilities.LogMessage("TaskStrip.Expand:: IsExpanded: " + this.IsExpanded.ToString());

            if (this.IsCollapsed)
            {
                // It's different based on Desktop/Web console.
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        UIASupport.Toggle((System.Windows.Automation.AutomationElement)this.ScreenElement.FindByPartialQueryId(";[UIA]Role = 'push button'", null).AutomationElement, System.Windows.Automation.ToggleState.On);
                        break;
                    case ProductSkuLevel.Web:
                        this.ScreenElement.FindByPartialQueryId(";[UIA]Role = 'push button'", null).LeftButtonClick(-1, -1);
                        break;
                    default:
                        throw new System.InvalidOperationException("TaskStrip.ClickLink:: Unexpected Product Sku: " + ProductSku.Sku);
                }

                this.ScreenElement.WaitForReady();
            }
        }
        #endregion

        #region ControlID's
        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///  [mbickle] 11AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static class ControlIDs
        {
            /// <summary>
            /// Control ID for MyWorkspace.
            /// </summary>
            public const string MyWorkspace = "taskStripFavorites";

            /// <summary>
            /// Control ID for Tasks.
            /// </summary>
            public const string Tasks = "taskStripItemTasks";

            /// <summary>
            /// Control ID for Related Tasks.
            /// </summary>
            public const string RelatedTasks = "taskStripRelatedTasks";
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all QueryIds
        /// </summary>
        /// <history>
        /// [mbickle] 08AUG08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants
            /// <summary>
            /// Resource for finding all MSAA Links
            /// </summary>
            private const string ResourceWinFormLinks = ";[MSAA, FindAll]Role = 'link'";

            /// <summary>
            /// Resource for finding all UIA Links
            /// </summary>
            private const string ResourceWPFLinks = ";[UIA, FindAll]Role = 'text' && AutomationId='taskItemText'";

            /// <summary>
            /// Resource for finding all SilverLight Links
            /// </summary>
            private const string ResourceSilverLightLinks = ";[UIA, FindAll]Role = 'text' && AutomationId='txtNormal'";
            #endregion

            #region Private members
            /// <summary>
            /// Cached WinForm Links
            /// </summary>
            private static QID cachedWinFormLinks;

            /// <summary>
            /// Cached WPF Links
            /// </summary>
            private static QID cachedWPFLinks;

            /// <summary>
            /// Cached SilverLight Links
            /// </summary>
            private static QID cachedSilverLightLinks;
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WinForm Links qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 8/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID WinFormLinks
            {
                get
                {
                    if ((cachedWinFormLinks == null))
                    {
                        cachedWinFormLinks = new QID(ResourceWinFormLinks);
                    }

                    return cachedWinFormLinks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WPF Links qid string
            /// </summary>
            /// <history>
            ///  [mbickle] 8/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID WPFLinks
            {
                get
                {
                    if ((cachedWPFLinks == null))
                    {
                        cachedWPFLinks = new QID(ResourceWPFLinks);
                    }

                    return cachedWPFLinks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SilverLight Links qid string
            /// </summary>
            /// <history>
            ///  [v-raienl] 24/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SilverLightLinks
            {
                get
                {
                    if ((cachedSilverLightLinks == null))
                    {
                        cachedSilverLightLinks = new QID(ResourceSilverLightLinks);
                    }

                    return cachedSilverLightLinks;
                }
            }
            #endregion
        }
        #endregion

        #region Exceptions
        /// ------------------------------------------------------------------
        /// <summary>
        /// TaskStrip Exceptions.
        /// </summary>
        /// <history>
        /// [mbickle] 11AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static new class Exceptions
        {
            /// --------------------------------------------------------------
            /// <summary>
            /// TaskStripNotFoundException Class.
            /// </summary>
            /// --------------------------------------------------------------
            [Serializable()]
            public class TaskStripNotFoundException : MauiException
            {
                /// --------------------------------------------------------------
                /// <summary>
                /// Task Strip Not Found Exception.
                /// </summary>
                /// --------------------------------------------------------------
                public TaskStripNotFoundException()
                    : base()
                {
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// Task Strip Not Found Exception.
                /// </summary>
                /// <param name="message">Exception Message.</param>
                /// --------------------------------------------------------------
                public TaskStripNotFoundException(string message)
                    : base(message)
                {
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// Task Strip Not Found Exception.
                /// </summary>
                /// <param name="message">Exception Message.</param>
                /// <param name="innerException">Inner Exception.</param>
                /// --------------------------------------------------------------
                public TaskStripNotFoundException(string message, Exception innerException)
                    : base(message, innerException)
                {
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// Task Strip Not Found Exception.
                /// </summary>
                /// <param name="info">Serialization Info.</param>
                /// <param name="context">Streaming Context.</param>
                /// --------------------------------------------------------------
                protected TaskStripNotFoundException(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Task Strip Item Not Found Exception.
            /// </summary>
            /// --------------------------------------------------------------
            [Serializable()]
            public class TaskStripItemNotFoundException : MauiException
            {
                /// --------------------------------------------------------------
                /// <summary>
                /// Task Strip Item Not Found Exception.
                /// </summary>
                /// --------------------------------------------------------------
                public TaskStripItemNotFoundException()
                    : base()
                {
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// Task Strip Item Not FoundException.
                /// </summary>
                /// <param name="message">Exception Message.</param>
                /// --------------------------------------------------------------
                public TaskStripItemNotFoundException(string message)
                    : base(message)
                {
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// Task Strip Item Not Found Exception.
                /// </summary>
                /// <param name="message">Exception Message.</param>
                /// <param name="innerException">Inner Exception.</param>
                /// --------------------------------------------------------------
                public TaskStripItemNotFoundException(string message, Exception innerException)
                    : base(message, innerException)
                {
                }

                /// --------------------------------------------------------------
                /// <summary>
                /// Task Strip Item Not Found Exception.
                /// </summary>
                /// <param name="info">Serialization Info.</param>
                /// <param name="context">Streaming Context.</param>
                /// --------------------------------------------------------------
                protected TaskStripItemNotFoundException(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
        }
        #endregion

        #region TaskStripItem Class
        /// --------------------------------------------------------------
        /// <summary>
        /// Task Strip Item.
        /// </summary>
        /// <history>
        /// [mbickle] 11AUG05 Created
        /// </history>
        /// --------------------------------------------------------------
        public class TaskStripItem
        {
            #region Member Variables
            /// <summary>
            /// No Index = -1.
            /// </summary>
            private const int NoIndex = -1;

            /// <summary>
            /// Task Strip ScreenElement.
            /// </summary>
            private IScreenElement taskStripScreenElement;

            /// <summary>
            /// Task Strip.
            /// </summary>
            private TaskStrip taskStrip;
            #endregion

            #region Constructor
            /// --------------------------------------------------------------
            /// <summary>
            /// Task Strip Item.
            /// </summary>
            /// <param name="parentTaskStrip">Parent Task Strip.</param>
            /// <param name="itemIndex">Item Index.</param>
            /// --------------------------------------------------------------
            public TaskStripItem(TaskStrip parentTaskStrip, int itemIndex)
            {
                this.Init(parentTaskStrip, itemIndex, null, null);
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Task Strip Item.
            /// </summary>
            /// <param name="parentTaskStrip">Parent Task Strip.</param>
            /// <param name="itemName">Task Strip.</param>
            /// --------------------------------------------------------------
            public TaskStripItem(TaskStrip parentTaskStrip, string itemName)
            {
                this.Init(parentTaskStrip, NoIndex, itemName, null);
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Task Strip Item.
            /// </summary>
            /// <param name="parentTaskStrip">Parent Task Strip.</param>
            /// <param name="screenElement">Screen Element</param>
            /// --------------------------------------------------------------
            public TaskStripItem(TaskStrip parentTaskStrip, IScreenElement screenElement)
            {
                this.Init(parentTaskStrip, NoIndex, null, screenElement);
            }
            #endregion

            #region Properties
            /// --------------------------------------------------------------
            /// <summary>
            /// Gets Owner TaskStrip for this item.
            /// </summary>
            /// --------------------------------------------------------------
            public TaskStrip ParentTaskStrip
            {
                get
                {
                    return this.taskStrip;
                }
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Gets Task Item Text. 
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
            /// Gets Task Item Value.
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
            /// Gets AccessibleObject.
            /// </summary>
            /// --------------------------------------------------------------
            public IScreenElement ScreenElement
            {
                get
                {
                    return this.taskStripScreenElement;
                }
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Gets Top Coords.
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
            /// Gets Bottom Coords.
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
            /// Gets Right Coords.
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
            /// Gets Left Coords.
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
            /// Gets Control Width .
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
            /// Gets Control Height.
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
            /// Gets the 0 based index for a given ToolStripItem.
            /// </summary>
            /// <exception cref="TaskStrip.Exceptions.TaskStripItemNotFoundException">
            /// TaskStrip.Exceptions.TaskStripItemNotFoundException
            /// </exception>
            /// --------------------------------------------------------------
            public int Index
            {
                get
                {
                    IScreenElement parentElement;
                    int tempIndex = 0;
                    parentElement = this.taskStrip.ScreenElement;
                    MauiCollection<IScreenElement> childElements;

                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            childElements = RPFSupport.RPF.FindAllScreenElements(parentElement, QueryIds.WPFLinks.ToString(), null, -1);
                            break;
                        case ProductSkuLevel.Web:
                            childElements = RPFSupport.RPF.FindAllScreenElements(parentElement, QueryIds.SilverLightLinks.ToString(), null, -1);
                            break;
                        default:
                            throw new System.InvalidOperationException("TaskStripItem.Index:: Unexpected Product Sku: " + ProductSku.Sku);
                    }

                    foreach (IScreenElement childElement in childElements)
                    {
                        ////if (TaskStrip.IsTaskStripItemCountable(childElement))
                        ////{
                        if (this.taskStripScreenElement.Equals(childElement))
                        {
                            return tempIndex;
                        }
                        else
                        {
                            tempIndex += 1;
                        }
                        ////}
                    }

                    throw new TaskStrip.Exceptions.TaskStripItemNotFoundException(
                        "TaskStripItem.Index:: Could not find matching TaskStrip item retrieving TaskStripItem.Index property");
                }
            }
            #endregion

            #region Public Methods
            /// --------------------------------------------------------------
            /// <summary>
            /// Single Click - LeftButton.
            /// </summary>
            /// --------------------------------------------------------------
            public void Click()
            {
                this.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Click w/ClickType - LeftButton.
            /// </summary>
            /// <param name="clickType">Mouse Click Type.</param>
            /// --------------------------------------------------------------
            public void Click(MouseClickType clickType)
            {
                this.Click(clickType, MouseFlags.LeftButton);
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Single Click w/Button.
            /// </summary>
            /// <param name="button">MouseFlags button.</param>
            /// --------------------------------------------------------------
            public void Click(MouseFlags button)
            {
                this.Click(MouseClickType.SingleClick, button);
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Mouse Click.
            /// </summary>
            /// <param name="clickType">Mouse Click Type.</param>
            /// <param name="button">Mouse Flags.</param>
            /// --------------------------------------------------------------
            public void Click(MouseClickType clickType, MouseFlags button)
            {
                Mouse.Click(clickType, button, this.Left + (this.Width / 2), this.Top + (this.Height / 2));

                this.ParentTaskStrip.ScreenElement.WaitForReady();
            }

            #endregion

            #region Private Methods
            /// --------------------------------------------------------------
            /// <summary>
            /// Initialize the TaskStripItem.
            /// </summary>
            /// <param name="parentTaskStrip">Parent Task Strip.</param>
            /// <param name="itemIndex">Item Index.</param>
            /// <param name="itemName">Item Name.</param>
            /// <param name="screenElement">Screen Element</param>
            /// <exception cref="TaskStrip.Exceptions.TaskStripItemNotFoundException">
            /// TaskStrip.Exceptions.TaskStripItemNotFoundException
            /// </exception>
            /// <exception cref="System.ArgumentException">
            /// System.ArgumentException
            /// </exception>
            /// --------------------------------------------------------------
            private void Init(TaskStrip parentTaskStrip, int itemIndex, string itemName, IScreenElement screenElement)
            {
                IScreenElement parentElement;
                int searchIndex;
                MauiCollection<IScreenElement> childElements;
                bool visibleOnly = true;

                if (!(parentTaskStrip == null))
                {
                    this.taskStrip = parentTaskStrip;
                    if (!(screenElement == null))
                    {
                        // we have a known object and a TaskStrip
                        this.taskStripScreenElement = screenElement;
                    }
                    else
                    {
                        // we must be searching TaskStripItem
                        parentElement = parentTaskStrip.ScreenElement;

                        switch (ProductSku.Sku)
                        {
                            case ProductSkuLevel.Mom:
                                childElements = RPFSupport.RPF.FindAllScreenElements(parentElement, QueryIds.WPFLinks.ToString(), null, -1);
                                break;
                            case ProductSkuLevel.Web:
                                childElements = RPFSupport.RPF.FindAllScreenElements(parentElement, QueryIds.SilverLightLinks.ToString(), null, -1);
                                break;
                            default:
                                throw new System.InvalidOperationException("TaskStripItem.Index:: Unexpected Product Sku: " + ProductSku.Sku);
                        }

                        try
                        {
                            if ((itemIndex > -1))
                            {
                                searchIndex = itemIndex;
                                foreach (IScreenElement childElement in childElements)
                                {
                                    // decide whether to include separators or not
                                    if ((String.Compare(childElement.Role, MsaaRole.Separator.ToString(), StringComparison.OrdinalIgnoreCase)) != 0)
                                    {
                                        if ((searchIndex == 0))
                                        {
                                            // found it
                                            this.taskStripScreenElement = childElement;
                                            return;
                                        }
                                        else
                                        {
                                            // we just skipped over one valid TaskStrip item
                                            searchIndex = (searchIndex - 1);
                                        }
                                    }
                                }

                                throw new TaskStrip.Exceptions.TaskStripItemNotFoundException(
                                    "TaskStripItem.Init:: Could not find item as index " + itemIndex +
                                    " in the set of MSAA children");
                            }
                            else
                            {
                                // we are searching by name
                                if (visibleOnly)
                                {
                                    if ((!(childElements == null) && (childElements.Count > 0)))
                                    {
                                        this.taskStripScreenElement = childElements[0];
                                    }
                                    else
                                    {
                                        throw new TaskStrip.Exceptions.TaskStripItemNotFoundException(
                                            "TaskStripItem.Init:: Could not find item by name " + itemName +
                                            " in the visibleOnly set");
                                    }
                                }
                                else
                                {
                                    if ((!(childElements == null) && (childElements.Count > 0)))
                                    {
                                        this.taskStripScreenElement = childElements[0];
                                    }
                                    else
                                    {
                                        throw new TaskStrip.Exceptions.TaskStripItemNotFoundException(
                                            "TaskStripItem.Init:: Could not find item by name " + itemName +
                                            " in the overall set");
                                    }
                                }
                            }
                        }
                        catch (ActiveAccessibility.Exceptions.ChildNotFoundException except)
                        {
                            throw new TaskStrip.Exceptions.TaskStripItemNotFoundException(
                                "TaskStripItem.Init:: Can not find the TaskStrip item",
                                except);
                        }
                    }
                }
                else
                {
                    throw new System.ArgumentException(
                        "TaskStripItem.Init:: You must provide a valid TaskStrip object as the parent");
                }
            }
            #endregion
        }
        #endregion

        #region TaskStripItemCollection Class
        /// ------------------------------------------------------------------
        /// <summary>
        /// Task Strip Item Collection Class.
        /// </summary>
        /// <history>
        /// [mbickle] 11AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        [Serializable()]
        public class TaskStripItemCollection : Collection<TaskStripItem>
        {
            #region Constructors
            /// --------------------------------------------------------------
            /// <summary>
            /// Task Strip Item Collection Constructor.
            /// </summary>
            /// --------------------------------------------------------------
            public TaskStripItemCollection()
                : base()
            {
            }

            /// --------------------------------------------------------------
            /// <summary>
            /// Task Strip Collection Constructor.
            /// </summary>
            /// <param name="value">TaskStripItem[] value.</param>
            /// --------------------------------------------------------------
            public TaskStripItemCollection(TaskStripItem[] value)
                : base()
            {
                this.AddRange(value);
            }
            #endregion

            #region Properties
            /// --------------------------------------------------------------
            /// <summary>
            /// Returns TaskStripItem via Name.
            /// </summary>
            /// <param name="name">TaskItem String to return.</param>
            /// <returns>Task Strip Item.</returns>
            /// <exception cref="TaskStrip.Exceptions.TaskStripItemNotFoundException">
            /// TaskStrip.Exceptions.TaskStripItemNotFoundException
            /// </exception>
            /// --------------------------------------------------------------
            public TaskStripItem this[string name]
            {
                get
                {
                    TaskStripItem result;
                    result = null;

                    // Loop through list to find specified value
                    foreach (TaskStripItem item in Items)
                    {
                        if (item.Text == name)
                        {
                            result = item;
                        }
                    }

                    // See if result is still null and if it is, throw an exception.
                    if (result == null)
                    {
                        throw new System.InvalidOperationException(
                            "TaskStripItemCollection.this:: Could not find TaskStripItem: " + name);
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
            /// TaskStripItemCollection.
            /// </summary>
            /// <param name="value">Task Strip Item Value.</param>
            /// --------------------------------------------------------------
            public void AddRange(TaskStripItem[] value)
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
            /// Adds contents of another TaskStripItemCollection to the end 
            /// of the collection.
            /// </summary>
            /// <param name="value">Task Strip Item Collection.</param>
            /// --------------------------------------------------------------
            public void AddRange(TaskStripItemCollection value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "TaskStrip.AddRange:: value is null");
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