// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AgentManagementTaskStatusWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 07-Feb-06    Created
//  [KellyMor] 27-Feb-06    Updated resource strings
//  [KellyMor] 27-Apr-06    Updated Init method
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAgentManagementTaskStatusWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAgentManagementTaskStatusWindowControls, for AgentManagementTaskStatusWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAgentManagementTaskStatusWindowControls
    {
        /// <summary>
        /// Read-only property to access TargetsListView
        /// </summary>
        ListView TargetsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskOutputStaticControl
        /// </summary>
        StaticControl TaskOutputStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StatusTextBox
        /// </summary>
        TextBox StatusTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunningTasksStaticControl
        /// </summary>
        StaticControl RunningTasksStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAgentManagementTaskStatusWindowControls, for 
    /// AgentManagementTaskStatusWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AgentManagementTaskStatusWindow : Window, IAgentManagementTaskStatusWindowControls
    {
        #region Protected Internal Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        protected internal static Window activeWindow;
        #endregion
        
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TargetsListView of type ListView
        /// </summary>
        private ListView cachedTargetsListView;
        
        /// <summary>
        /// Cache to hold a reference to TaskOutputStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskOutputStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StatusTextBox of type TextBox
        /// </summary>
        private TextBox cachedStatusTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to RunningTasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunningTasksStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of AgentManagementTaskStatusWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AgentManagementTaskStatusWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAgentManagementTaskStatusWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAgentManagementTaskStatusWindowControls Controls
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
        ///  Routine to set/get the text in control ManagementMode
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StatusText
        {
            get
            {
                return this.Controls.StatusTextBox.Text;
            }
            
            set
            {
                this.Controls.StatusTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetsListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAgentManagementTaskStatusWindowControls.TargetsListView
        {
            get
            {
                if ((this.cachedTargetsListView == null))
                {
                    this.cachedTargetsListView = new ListView(this, AgentManagementTaskStatusWindow.ControlIDs.TargetsListView);
                }
                return this.cachedTargetsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskOutputStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentManagementTaskStatusWindowControls.TaskOutputStaticControl
        {
            get
            {
                if ((this.cachedTaskOutputStaticControl == null))
                {
                    this.cachedTaskOutputStaticControl = new StaticControl(this, AgentManagementTaskStatusWindow.ControlIDs.TaskOutputStaticControl);
                }
                return this.cachedTaskOutputStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAgentManagementTaskStatusWindowControls.StatusTextBox
        {
            get
            {
                if ((this.cachedStatusTextBox == null))
                {
                    this.cachedStatusTextBox = new TextBox(this, AgentManagementTaskStatusWindow.ControlIDs.StatusTextBox);
                }
                return this.cachedStatusTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IAgentManagementTaskStatusWindowControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, AgentManagementTaskStatusWindow.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunningTasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentManagementTaskStatusWindowControls.RunningTasksStaticControl
        {
            get
            {
                if ((this.cachedRunningTasksStaticControl == null))
                {
                    this.cachedRunningTasksStaticControl = new StaticControl(this, AgentManagementTaskStatusWindow.ControlIDs.RunningTasksStaticControl);
                }
                return this.cachedRunningTasksStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentManagementTaskStatusWindowControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, AgentManagementTaskStatusWindow.ControlIDs.StaticControl0);
                }
                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentManagementTaskStatusWindowControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, AgentManagementTaskStatusWindow.ControlIDs.CloseButton);
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = new Window(
                    Strings.WindowTitle + "*",
                    StringMatchSyntax.WildCard);

                // wait for the window to report ready
                UISynchronization.WaitForUIObjectReady(
                    tempWindow,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // try again with wildcards in the title
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    Core.Common.Utilities.TakeScreenshot("AgentManagementTaskStatusWindow_Init_" + numberOfTries.ToString());
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.WindowTitle + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //Minimize the foreground window and try again.
                        Core.Common.Utilities.LogMessage("Trying to get foreground window.");
                        tempWindow = new Window(WindowType.Foreground);

                        if (tempWindow != null)
                        {
                            Core.Common.Utilities.LogMessage("Got foreground window, and try to minimize it.");
                            tempWindow.Extended.State = WindowState.Minimize;
                            tempWindow = null;
                        }

                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    Core.Common.Utilities.TakeScreenshot("AgentManagementTaskStatusWindow_Failed");
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.WindowTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowTitle = ";Agent Management Task Status;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" + 
                "AgentTaskStatsCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskOutput
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskOutput = ";&Task Output;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.RunTask.TaskStatusBase;taskOutputLabel.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunningTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunningTasks = ";Running tasks ...;Microsoft.MOM.UI.Components.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;runningProg" +
                "ress";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Cl&ose;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.RunTask.TaskStatusBase;closeButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskScheduled 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskScheduled = ";Queued;ManagedString;Microsoft.MOM.UI.Components.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;taskQueued";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskSucceeded
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskSucceeded = ";Success;ManagedString;Microsoft.MOM.UI.Components.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;taskSucceeded";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskFailed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskFailed = ";Failed;ManagedString;Microsoft.MOM.UI.Components.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;taskFailed";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskOutput
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskOutput;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunningTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunningTasks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskScheduled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskScheduled;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskSucceeded
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskSucceeded;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskFailed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskFailed;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    return cachedWindowTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskOutput translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskOutput
            {
                get
                {
                    if ((cachedTaskOutput == null))
                    {
                        cachedTaskOutput = CoreManager.MomConsole.GetIntlStr(ResourceTaskOutput);
                    }
                    return cachedTaskOutput;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1
            {
                get
                {
                    if ((cachedToolStrip1 == null))
                    {
                        cachedToolStrip1 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1);
                    }
                    return cachedToolStrip1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunningTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunningTasks
            {
                get
                {
                    if ((cachedRunningTasks == null))
                    {
                        cachedRunningTasks = CoreManager.MomConsole.GetIntlStr(ResourceRunningTasks);
                    }
                    return cachedRunningTasks;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
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
            /// Exposes access to the TaskScheduled translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskScheduled
            {
                get
                {
                    if ((cachedTaskScheduled == null))
                    {
                        cachedTaskScheduled = CoreManager.MomConsole.GetIntlStr(ResourceTaskScheduled);
                    }
                    return cachedTaskScheduled;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskSucceeded translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskSucceeded
            {
                get
                {
                    if ((cachedTaskSucceeded == null))
                    {
                        cachedTaskSucceeded = CoreManager.MomConsole.GetIntlStr(ResourceTaskSucceeded);
                    }
                    return cachedTaskSucceeded;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskFailed translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskFailed
            {
                get
                {
                    if ((cachedTaskFailed == null))
                    {
                        cachedTaskFailed = CoreManager.MomConsole.GetIntlStr(ResourceTaskFailed);
                    }
                    return cachedTaskFailed;
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for TargetsListView
            /// </summary>
            public const string TargetsListView = "targetList";
            
            /// <summary>
            /// Control ID for TaskOutputStaticControl
            /// </summary>
            public const string TaskOutputStaticControl = "taskOutputLabel";
            
            /// <summary>
            /// Control ID for StatusTextBox
            /// </summary>
            public const string StatusTextBox = "statusRichTextBox";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip";
            
            /// <summary>
            /// Control ID for RunningTasksStaticControl
            /// </summary>
            public const string RunningTasksStaticControl = "progressLabel";
            
            /// <summary>
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl0 = "progressBar";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";
        }
        #endregion
    }
}
