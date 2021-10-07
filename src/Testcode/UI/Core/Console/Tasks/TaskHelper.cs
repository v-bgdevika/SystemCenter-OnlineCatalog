using System;
using System.Collections.Generic;
using System.Text;
using Maui.Core.WinControls;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;

namespace Mom.Test.UI.Core.Console.Tasks
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Task helper class
    /// </summary>
    /// <history>
    /// 	[v-jinlil] 22July2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TaskHelper
    {
        #region Private Members
        private LaunchType launchTaskType;
        private string actionPaneID = string.Empty;
        private string contextMenuID = string.Empty;
        #endregion

        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// Task Helper Constructor.
        /// </summary>
        /// <param name="QID">actionPanelID</param>
        /// ------------------------------------------------------------------
        public TaskHelper(string actionPaneID)
        {
            this.actionPaneID = actionPaneID;
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Task Helper Constructor.
        /// </summary>
        /// <param name="LaunchType">launchType</param>
        /// <param name="contextID">contextMenuID/ActionPaneID</param>
        /// ------------------------------------------------------------------
        public TaskHelper(LaunchType launchType, string ID)
        {
            launchTaskType = launchType;
            switch (launchType)
            {
                case LaunchType.ActionPane:
                    this.actionPaneID = ID;
                    break;

                case LaunchType.RightClick:
                case LaunchType.ShiftF10:
                    this.contextMenuID = ID;
                    break;

                default:
                    break;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Task Helper Constructor.
        /// </summary>
        /// <param name="QID">actionpaneID</param>
        /// <param name="contextID">ContextMenuID</param>
        /// ------------------------------------------------------------------
        public TaskHelper(string actionPaneID,string contextMenuID)
        {
            this.contextMenuID = contextMenuID;
            this.actionPaneID = actionPaneID;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Task Helper Constructor.
        /// </summary>
        /// <param name="QID">actionpaneID</param>
        /// <param name="contextID">contextMenuID</param>
        /// <param name="contextID">viewPaneID</param>
        /// ------------------------------------------------------------------
        public TaskHelper(string actionPanelID, string contextMenuID, string viewPaneID)
        {
            //The View pane buttons are new to the Configuration/Personalization improvement 
            //and are not in the product yet. This functionality can be added later.   
        }
        #endregion

        #region Enumerations section
        /// <summary>
        /// Types of Launch Task
        /// </summary>
        public enum LaunchType
        {
            /// <summary>
            /// Shift-F10
            /// </summary>
            ShiftF10,

            /// <summary>
            /// Right Click
            /// </summary>
            RightClick,

            /// <summary>
            /// Action Pane
            /// </summary>
            ActionPane
        }
        #endregion

        #region Properties

        /// <summary>
        /// LaunchFromContextMenu
        /// </summary>
        public string ContextMenuID
        {
            get
            {
                return contextMenuID;
            }
            set
            {
                contextMenuID = value;
            }
        }

        /// <summary>
        /// LaunchFromActionPane
        /// </summary>
        public string ActionPaneID
        {
            get
            {
                return actionPaneID;
            }
            set
            {
                actionPaneID = value;
            }
        }
        #endregion

        #region public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        ///Launch Task randomly
        /// </summary>
        /// <history>
        ///     [v-jinlil] 23July2010 created
        /// </history>
        /// ------------------------------------------------------------------
        public void LaunchTask()
        {
            //will launch from action pane
            if (LaunchType.ActionPane.Equals(launchTaskType) || (string.Empty.Equals(this.contextMenuID)))
            {
                launchTaskType = LaunchType.ActionPane;
                LaunchTask(launchTaskType);
                return;
            }

            if (string.Empty.Equals(this.actionPaneID))
            {
                launchTaskType = LaunchType.ShiftF10;
                LaunchTask(launchTaskType);
                return;
            }

            // create a random number generator
            Random ra = new Random(Core.Common.Utilities.Seed);
            
            //random to launch task
            int typeCount = Enum.GetNames(Type.GetType("LaunchType")).Length;
            int launchTypeID = ra.Next(1,typeCount);

            switch (launchTypeID)
            {
                case 1:   
                    launchTaskType = LaunchType.ActionPane;
                    break;

                case 2:
                    launchTaskType = LaunchType.ShiftF10;
                    break;

                case 3:
                    launchTaskType = LaunchType.RightClick;
                    break;

                default:
                    break;
            }

            LaunchTask(launchTaskType);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///Launch Task
        /// </summary>
        /// <history>
        ///     [v-jinlil] 23July2010 created
        /// </history>
        /// ------------------------------------------------------------------
        public void LaunchTask(LaunchType launchType)
        {
            if (string.Empty.Equals(this.actionPaneID) && string.Empty.Equals(this.contextMenuID))
            {
                throw new NullReferenceException("There must be an actionPaneID or contextMenuID");
            }

            Menu contextMenu = null;
            switch (launchType)
            {
                //Launch task from action pane
                case LaunchType.ActionPane:
                    Console.ActionsPane actionPane = Core.Console.CoreManager.MomConsole.ActionsPane;
                    actionPane.ClickTaskLink(this.actionPaneID);
                   
                    break;
                
                //launch task from context menu by right click
                case LaunchType.RightClick:
                    contextMenu = new Menu();
                    contextMenu.WaitContextMenuWithTimeOut(Core.Common.Constants.OneMinute);
                    contextMenu.ExecuteMenuItem(this.contextMenuID); 
                    break;

                //launch task from context menu by shift F10
                case LaunchType.ShiftF10:
                    contextMenu = new Menu(ContextMenuAccessMethod.ShiftF10);
                    contextMenu.WaitContextMenuWithTimeOut(Core.Common.Constants.OneMinute);
                    contextMenu.ExecuteMenuItem(this.contextMenuID);
                    break;

                default:
                    break;
            }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Exists action pane
        /// </summary>
        /// <returns>exists or not exists</returns>
        /// <history>
        ///     [v-jinlil] 23July2010 created
        /// </history>
        /// ------------------------------------------------------------------
        public bool ExistsActionPane(Console.ActionsPane actionPane)
        {
            bool existActionPane = false;

            if (actionPane != null)
            {
                existActionPane = true;  
            }

            return existActionPane;
        }


        /// ------------------------------------------------------------------
        /// <summary>
        ///Enabled action pane
        /// </summary>
        /// <returns>enabled or disabled</returns>
        /// <history>
        ///     [v-jinlil] 23July2010 created
        /// </history>
        /// ------------------------------------------------------------------
        public bool EnabledActionPane(Console.ActionsPane actionPane)
        {
            bool enabledActionPane = false;

            if (actionPane.IsEnabled)
            {
                enabledActionPane = true;
            }
            return enabledActionPane;
        }

        #endregion
    }
}