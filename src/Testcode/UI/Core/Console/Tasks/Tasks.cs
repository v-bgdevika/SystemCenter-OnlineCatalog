// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Tasks.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Tasks Base Class.
// </summary>
// <history>
// 	[faizalk] 19OCT05 Created
//  [faizalk] 22MAR06 Update CreateTask methods
//  [faizalk] 27MAR06 Change TaskPane to ActionsPane
//  [faizalk] 17APR06 Update to use all Task Parameters, new Launch Task overload
//  [faizalk] 27APR06 Use WinformsID instead of resource string
//  [faizalk] 01MAY06 Add support for Console Tasks, Script Tasks
//  [mbickle] 18JUL06 Added Find to  Task Verification method to speed things up.
//  [jefftow] 20JUL07 Fixed DeleteTask to handle Deletion of tasks, added more logging to Launch Task to help troubleshoot
//  [jefftow] 17JAN08 Added Personalization methods, Functionality to run tasks with overrides, Ability to verify the output of tasks
//  [v-eachu] 09DEC09 Added Update Task Properties and Verify Update Results
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Tasks
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System.Text;
    using System;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using Mom.Test.UI.Core.Console.Tasks.Wizards;
    using Mom.Test.UI.Core.Console.Views;
    using Mom.Test.UI.Core.Console.Dialogs;
    using System.Collections.Generic;               // Used in Personalize, to store equivalent strings
    using System.Collections;

    #endregion

    /// <summary>
    /// Create and launch tasks
    /// </summary>
    public class Tasks
    {
        #region Private Members
        /// <summary>
        /// Timeout constant
        /// </summary>
        private const int Timeout = 6000;

        /// <summary>
        /// cachedSelectTaskType
        /// </summary>
        private SelectTaskType cachedSelectTaskType;

        /// <summary>
        /// cachedTaskNameDialog
        /// </summary>
        private TaskNameDialog cachedTaskNameDialog;

        /// <summary>
        /// cachedCommandTaskConfiguration
        /// </summary> 
        private CommandTaskConfiguration cachedCommandTaskConfiguration;

        /// <summary>
        /// Stores the timeout parameter to be used when overriding tasks
        /// </summary>
        private string overrideTimeout;

        /// <summary>
        /// Stores the orverride arguments parameter
        /// </summary>
        private string overrideArguments;

        /// <summary>
        /// Stores the User name to be used when run agent tasks
        /// </summary>
        private string agentUserName;

        /// <summary>
        /// Stores the agent User password
        /// </summary>
        private string agentUserPassword;

        /// <summary>
        /// Flag to verify task output, set by VerifyTaskOutput method
        /// </summary>
        private bool verifyTaskOutput = false;

        /// <summary>
        /// The string passed in via MCF parameter, used to verify the output of a run task
        /// </summary>
        private string taskOutputString;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;
        #endregion

        #region Constructor
        /// <summary>
        /// Tasks Constructor.
        /// </summary>
        public Tasks()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        #region Enumerations section
        /// <summary>
        /// Types of Command Line task
        /// </summary>
        public enum CommandLineTaskType
        {
            /// <summary>
            /// Secure Command Line 
            /// </summary>
            SecureCommandLine,

            /// <summary>
            /// Windows Command Line
            /// </summary>
            WindowsCommandLine,
        }

        /// <summary>
        /// Types of Timeout units
        /// </summary>
        public enum TimeoutUnit
        {
            /// <summary>
            /// Seconds
            /// </summary>
            Seconds,

            /// <summary>
            /// Minutes
            /// </summary>
            Minutes,

            /// <summary>
            /// Hours
            /// </summary>
            Hours,

            /// <summary>
            /// Days
            /// </summary>
            Days,
        }

        /// <summary>
        /// Types of Scripts
        /// </summary>
        public enum ScriptType
        {
            /// <summary>
            /// VB Script
            /// </summary>
            VB_Script,

            /// <summary>
            /// J Script
            /// </summary>
            J_Script,
        }

        /// <summary>
        /// Types of Tasks
        /// </summary>
        public enum TaskType
        {
            /// <summary>
            /// Console Task
            /// </summary>
            ConsoleTask,

            /// <summary>
            /// Agent Task
            /// </summary>
            AgentTask,
        }

        #endregion //Enumerations section

        #region Properties

        /// <summary>
        /// SelectTaskType
        /// </summary>
        public SelectTaskType selectTaskType
        {
            get
            {
                if (this.cachedSelectTaskType == null)
                {
                    this.cachedSelectTaskType = new SelectTaskType(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting focus on SelectTaskType Dialog successful");
                }

                return this.cachedSelectTaskType;
            }
        }

        /// <summary>
        /// TaskNameDialog
        /// </summary>
        public TaskNameDialog taskNameDialog
        {
            get
            {
                if (this.cachedTaskNameDialog == null)
                {
                    this.cachedTaskNameDialog = new TaskNameDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting focus on TaskNameDialog successful");
                }

                return this.cachedTaskNameDialog;
            }
        }

        /// <summary>
        /// CommandTaskConfiguration
        /// </summary>
        public CommandTaskConfiguration commandTaskConfiguration
        {
            get
            {
                if (this.cachedCommandTaskConfiguration == null)
                {
                    this.cachedCommandTaskConfiguration = new CommandTaskConfiguration(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting focus on CommandTaskConfiguration Dialog successful");
                }

                return this.cachedCommandTaskConfiguration;
            }
        }

        #endregion

        #region Public Methods
        #region Create Tasks

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to create a Windows command line task.
        /// </summary>
        /// <param name="managementPack">Name of management pack to create the task in</param>
        /// <param name="managedEntity">Name of managed entity to target task at</param>
        /// <param name="windowsCommand">Windows command text</param>
        /// <param name="taskName">"Name you would like to assign to this task"</param>
        /// <param name="description">"Description you would like to assign to this task"</param>
        /// ------------------------------------------------------------------
        [Obsolete("Use CreateCommandTask(TaskParameters)")]
        public void CreateCommandTask(string managementPack, string managedEntity, string windowsCommand, string taskName, string description)
        {
            this.CreateCommandTask(managementPack, managedEntity, null, windowsCommand, null, null, false, taskName, description, true);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to create a secure command line task.
        /// </summary>
        /// <param name="managementPack">Name of management pack to create the task in</param>
        /// <param name="managedEntity">Name of managed entity to target task at</param>
        /// <param name="secureCommand">secure command text</param>
        /// <param name="parameters">"secure command parameters"</param>
        /// <param name="taskName">"Name you would like to assign to this task"</param>
        /// <param name="description">"Description you would like to assign to this task"</param>
        /// ------------------------------------------------------------------
        [Obsolete("Use CreateCommandTask(TaskParameters)")]
        public void CreateCommandTask(string managementPack, string managedEntity, string secureCommand, string parameters, string taskName, string description)
        {
            this.CreateCommandTask(managementPack, managedEntity, null, secureCommand, parameters, null, false, taskName, description, true);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to create any command line task.
        /// </summary>
        /// <param name="managementPack">Name of management pack to create the task in</param>
        /// <param name="managedEntity">Name of managed entity to target task at</param>
        /// <param name="workingDirectory">"Directory to execute command from
        /// Use null if you want to leave field blank."</param>
        /// <param name="command">command text</param>
        /// <param name="parameters">"command parameters 
        /// Use null if you want a windows command, else you will get a secure command."</param>
        /// <param name="timeout">"timeout in seconds
        /// Use null if you want to leave default value."</param>
        /// <param name="displayOutput">"True if you want to run task synchronously and display output"</param>
        /// <param name="taskName">"Name you would like to assign to this task"</param>
        /// <param name="description">"Description you would like to assign to this task"</param>
        /// <param name="enabled">"True if task should be enabled"</param>
        /// 
        /// ------------------------------------------------------------------
        /*
         * FOR SOME REASON COREXT CANNOT RESOLVE THIS EXCEPTION TAG
         * /// <exception cref="Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException">
         * /// "Thrown if textboxes are disabled"
         * /// </exception>*/
        [Obsolete("Use CreateCommandTask(TaskParameters)")]
        public void CreateCommandTask(string managementPack, string managedEntity, string workingDirectory, string command, string parameters, string timeout, bool displayOutput, string taskName, string description, bool enabled)
        {
            Utilities.LogMessage("CreateCommandTask...");

            #region Navigate to Create Task Wizard
            // Navigate to monitoring configuration space of the MOM Console and select node
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            Maui.Core.WinControls.TreeNode managementPackNode = navPane.SelectNode(managementPack + "\\" + managedEntity, NavigationPane.NavigationTreeView.MonitoringConfiguration);
            Utilities.LogMessage("Successfully selected " + managementPack + "\\" + managedEntity);

            managementPackNode.Click();
            managementPackNode.Click(MouseClickType.SingleClick, MouseFlags.RightButton);

            // Get context menu
            Maui.Core.WinControls.Menu contextMenu = new Maui.Core.WinControls.Menu();
            contextMenu.ScreenElement.WaitForReady();
            Utilities.LogMessage("Selecting context menu item:  'Create Task Wizard'");

            // Click the "Create Task Wizard" menu item
            contextMenu.ExecuteMenuItem("Create Task Wizard...");

            // Find the "Create Task Wizard" dialog 
            Utilities.LogMessage("Locate task window...");
            Core.Console.Tasks.Wizards.SelectTaskType selectTask = new Core.Console.Tasks.Wizards.SelectTaskType(CoreManager.MomConsole);

            // By default Command Task type is selected so just click next
            Utilities.LogMessage("ClickNext...");
            selectTask.WaitForResponse();
            selectTask.ClickNext();

            // Find command configuration window 
            Core.Common.Utilities.LogMessage("Locate config window...");
            Core.Console.Tasks.Wizards.CommandTaskConfiguration commandConfiguration = new Core.Console.Tasks.Wizards.CommandTaskConfiguration(CoreManager.MomConsole);
            commandConfiguration.WaitForResponse();
            #endregion

            #region Enter Working Directory
            if (workingDirectory != null)
            {
                if (commandConfiguration.Controls.WorkingDirectoryStaticControl.IsEnabled.Equals(false))
                {
                    throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Working Directory text box is disabled");
                }

                commandConfiguration.Controls.WorkingDirectoryStaticControl.Click();

                // Enter working directory
                commandConfiguration.Controls.WorkingDirectoryStaticControl.SendKeys(workingDirectory);
            }
            #endregion

            // Populate fields based on task type
            #region Populate Configuration Fields

            // If parameters argument is not null then we are using secure command line task
            if (parameters != null)
            {
                // Secure command line task
                // Enter parameters
                commandConfiguration.Controls.ParametersTextBox.Click();
                if (commandConfiguration.Controls.ParametersTextBox.IsEnabled.Equals(false))
                {
                    throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Parameters Text Box is disabled");
                }

                commandConfiguration.Controls.ParametersTextBox.SendKeys(parameters);

                // Enter secure command path
                if (command != null)
                {
                    if (commandConfiguration.Controls.FullPathToFileTextBox.IsEnabled.Equals(false))
                    {
                        Utilities.TakeScreenshot("FullPathToFileTextBox is disabled");
                        throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Secure Command Line Full Path to File Text Box is disabled");
                    }

                    commandConfiguration.Controls.FullPathToFileTextBox.Click();

                    // Enter full path
                    commandConfiguration.Controls.FullPathToFileStaticControl.SendKeys(command);
                }
            } // Else using windows command line interpreter
            else
            {
                // Enter windows command line
                if (commandConfiguration.Controls.FullPathToFileStaticControl.IsEnabled.Equals(false))
                {
                    throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Secure Command Line Full Path to File Text Box is disabled");
                }

                commandConfiguration.Controls.FullPathToFileStaticControl.Click();

                // Enter full path
                // [jefftow] 21JAN08 - Changed to system path tests were failing in certain environments becuase cmd.exe is not in path
                commandConfiguration.Controls.FullPathToFileStaticControl.SendKeys("{%}systemroot{%}\\system32\\cmd.exe");

                if (command != null)
                {
                    if (commandConfiguration.Controls.ParametersTextBox.IsEnabled.Equals(false))
                    {
                        throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Windows Command Line Text Box is disabled");
                    }

                    commandConfiguration.Controls.ParametersTextBox.Click();

                    // Enter command line
                    commandConfiguration.Controls.ParametersTextBox.SendKeys("/c " + command);
                }
            }

            #endregion

            Core.Common.Utilities.LogMessage("ClickNext...");
            commandConfiguration.ClickNext();

            #region Enter Name and Description
            // Find complete task window
            Core.Console.Tasks.Wizards.TaskNameDialog taskNameDialog = new Core.Console.Tasks.Wizards.TaskNameDialog(CoreManager.MomConsole);

            // Enter name
            if (taskNameDialog.Controls.TaskNameTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Description Text Box is disabled");
            }

            taskNameDialog.Controls.TaskNameTextBox.SendKeys(taskName);

            // Enter description
            if (taskNameDialog.Controls.DescriptionOptionalTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Description Text Box is disabled");
            }

            taskNameDialog.Controls.DescriptionOptionalTextBox.SendKeys(description);

            #endregion // Enter Name and Description

            // Finish wizard
            taskNameDialog.ClickNext();
        } // End CreateCommandTask function

        /// <summary>
        ///  Create a new Command Line Task
        /// </summary>
        /// <param name="parameters">Create command line task parameters</param>
        /// <history>
        ///     [faizalk]   16MAR06 - Created
        ///     [faizalk]   27MAR06 - Change TaskPane to ActionsPane
        /// </history>
        public void CreateCommandTask(CommandTaskParameters parameters)
        {
            Utilities.LogMessage("CreateCommandTask...");

            #region Navigate to Create Task Wizard
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string createTaskPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                + Constants.PathDelimiter
                + Core.Console.Views.Views.Strings.TasksView;
            actionsPane.ClickLink(
               NavigationPane.WunderBarButton.MonitoringConfiguration,
               createTaskPath,
               ActionsPane.Strings.ActionsPaneTask,
               ActionsPane.Strings.ActionsPaneCreateANewTask);

            // Find the "Create Task Wizard" dialog 
            Utilities.LogMessage("CreateCommandTask:: Locate task window...");
            Core.Console.Tasks.Wizards.SelectTaskType selectTask = new Core.Console.Tasks.Wizards.SelectTaskType(CoreManager.MomConsole);
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    if (!selectTask.IsVisible)
                    {
                        Sleeper.Delay(3000);
                        actionsPane.ClickLink(
                           NavigationPane.WunderBarButton.MonitoringConfiguration,
                           createTaskPath,
                           ActionsPane.Strings.ActionsPaneTask,
                           ActionsPane.Strings.ActionsPaneCreateANewTask);
                        selectTask = new Core.Console.Tasks.Wizards.SelectTaskType(CoreManager.MomConsole);
                        Utilities.LogMessage("retry to click Creat New Task link times" + i.ToString());
                    }
                    else
                    {
                        break;
                    }
                }
                catch(Exception ex)
                {
                    Utilities.LogMessage(ex.ToString()); 
                }

                }
            
            TreeNode agentTasksFolderNode = selectTask.Controls.SelectTheTypeOfTaskToCreateTreeView.Find(SelectTaskType.Strings.AgentTasksFolder);
            TreeNode node = agentTasksFolderNode.Find(SelectTaskType.Strings.AgentCommandLineTask);
            node.Select();
            node.Click();
            selectTask.WaitForResponse();

            // Set Destination MP
            selectTask.SelectDestinationManagementPackText = parameters.DestinationMP;

            // By default Command Task type is selected so just click next
            Utilities.LogMessage("CreateCommandTask:: ClickNext...");

            // wait for 3 seconds for Next Button enable
            Sleeper.Delay(3000);
            selectTask.ClickNext();
            #endregion

            #region Enter Name and Description
            // Find complete task window
            Core.Console.Tasks.Wizards.TaskNameDialog taskNameDialog = new Core.Console.Tasks.Wizards.TaskNameDialog(CoreManager.MomConsole);
            taskNameDialog.WaitForResponse();

            // Enter name
            if (taskNameDialog.Controls.TaskNameTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Name Text Box is disabled");
            }

            taskNameDialog.Controls.TaskNameTextBox.SendKeys(parameters.Name);

            // Enter description
            if (taskNameDialog.Controls.DescriptionOptionalTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Description Text Box is disabled");
            }

            if (parameters.Description != null)
            {
                taskNameDialog.Controls.DescriptionOptionalTextBox.SendKeys(parameters.Description);
            }
            #endregion // Enter name and description

            #region Select Target

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(taskNameDialog.Controls.SelectButton, Constants.OneSecond * 5);
            taskNameDialog.ClickSelect();

            Core.Console.MonitoringConfiguration.Dialogs.SelectTargetTypeDialog selectTargetType = new Core.Console.MonitoringConfiguration.Dialogs.SelectTargetTypeDialog(CoreManager.MomConsole);

            if (!String.IsNullOrEmpty(parameters.TargetEntity))
            {
                selectTargetType.WaitForResponse();
                selectTargetType.Controls.ViewAllTargetsRadioButton.Click();
                selectTargetType.Controls.ListView0.WaitForResponse();
                Sleeper.Delay(Constants.OneSecond * 5);

                string[] selection = new string[1];
                selection[0] = parameters.TargetEntity;

                // look for TargetEntity first to save the search time
                selectTargetType.LookForText = selection[0];
                selectTargetType.WaitForResponse();

                int tries = 0;
                int maxTries = 5;

                // Change while loop to do / while as per bug 86178
                do
                {
                    selectTargetType.Controls.ListView0.MultiSelect(selection);
                    Sleeper.Delay(Constants.OneSecond);
                    tries++;
                }
                while (!selectTargetType.Controls.OKButton.IsEnabled && tries < maxTries);
            }

            // else we will just target at Entity
            // [jefftow] 21JAN08 - Added some better logging here so we can get a better picture of how the task is setup
            Utilities.TakeScreenshot("CreateCommandTask - Select Target");
            Utilities.LogMessage("CreateCommandTask:: Selecting ok on Select Target");
            selectTargetType.ClickOK();

            Utilities.TakeScreenshot("CreateCommandTask - Select General Properties");
            Utilities.LogMessage("CreateCommandTask:: Select next on general properties");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(taskNameDialog.Controls.NextButton, Constants.OneMinute);
            taskNameDialog.ClickNext();

            #endregion // Select Target

            #region Configure Task

            // find command configuration window 
            Core.Common.Utilities.LogMessage("CreateCommandTask:: Locate config window...");
            Core.Console.Tasks.Wizards.CommandTaskConfiguration commandConfiguration = new Core.Console.Tasks.Wizards.CommandTaskConfiguration(CoreManager.MomConsole);

            // populate fields based on task type
            #region Populate Configuration Fields

            // make sure textboxes are enabled
            if (commandConfiguration.Controls.FullPathToFileStaticControl.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Secure Command Line Full Path to File Text Box is disabled");
            }

            if (commandConfiguration.Controls.ParametersTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Parameters Text Box is disabled");
            }

            switch (parameters.Type)
            {
                case CommandLineTaskType.SecureCommandLine:
                    // enter secure command path
                    if (parameters.Command != null)
                    {
                        commandConfiguration.Controls.FullPathToFileTextBox.Click();

                        // enter full path
                        commandConfiguration.Controls.FullPathToFileTextBox.SendKeys(parameters.Command);
                    }

                    // enter parameters
                    if (parameters.Parameters != null)
                    {
                        commandConfiguration.Controls.ParametersTextBox.Click();
                        commandConfiguration.Controls.ParametersTextBox.SendKeys(parameters.Parameters);
                    }

                    break;

                case CommandLineTaskType.WindowsCommandLine:
                    // using windows command line interpreter
                    commandConfiguration.Controls.FullPathToFileTextBox.Click();

                    // enter full path
                    // TODO: this should be taken out of here and made as a Parameter
                    // [jefftow] 21JAN08 - Changed to system path tests were failing in certain environments becuase cmd.exe is not in path
                    commandConfiguration.Controls.FullPathToFileTextBox.SendKeys("{%}systemroot{%}\\system32\\cmd.exe");

                    if (parameters.Command != null)
                    {
                        commandConfiguration.Controls.ParametersTextBox.Click();

                        // enter command line
                        commandConfiguration.Controls.ParametersTextBox.SendKeys("/c " + parameters.Command);
                    }

                    break;

                default:
                    Utilities.LogMessage("CreateCommandTask:: Type parameter: '" + parameters.Type + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type '" + parameters.Type + "' selected");
            }
            #endregion // populate fields based on task type

            #region Enter Working Directory
            if (commandConfiguration.Controls.WorkingDirectoryTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Working Directory text box is disabled");
            }

            if (parameters.WorkingDirectory != null)
            {
                commandConfiguration.Controls.WorkingDirectoryTextBox.Click();

                // enter working directory
                commandConfiguration.Controls.WorkingDirectoryTextBox.SendKeys(parameters.WorkingDirectory);
            }
            #endregion // Enter working directory

            #endregion // Configure task

            #region Check Enabled controls

            if (commandConfiguration.Controls.NextButton.IsEnabled)
            {
                throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Next button is enabled but should be disabled");
            }

            if (!commandConfiguration.Controls.PreviousButton.IsEnabled)
            {
                throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Previous button is disabled");
            }

            if (!commandConfiguration.Controls.CancelButton.IsEnabled)
            {
                throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Cancel button is disabled");
            }

            if (!commandConfiguration.Controls.CreateButton.IsEnabled)
            {
                throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Create button is disabled");
            }

            #endregion // Check enabled controls

            #region Finish wizard

            // Finish wizard
            Core.Common.Utilities.LogMessage("CreateCommandTask:: ClickCreate...");
            Core.Common.Utilities.TakeScreenshot("Clicking ClickCreate");
            commandConfiguration.ClickCreate();

            Utilities.LogMessage("CreateCommandTask:: Wait for dialog to close...");

            commandConfiguration.ScreenElement.WaitForGone(Constants.OneMinute, 6);            


            int retry = 0;
            int maxcount = 120;
            while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
            {
                Utilities.LogMessage("CreateCommandTask:: MainWindow not Foreground, lets wait a moment.");
                Sleeper.Delay(1000);
                retry++;
            }

            Utilities.LogMessage("CreateCommandTask:: Wait for console ready...");

            Utilities.TakeScreenshot("before WaitForStatusReady");

            consoleApp.Waiters.WaitForStatusReady(Constants.OneMinute);

            Utilities.TakeScreenshot("after WaitForStatusReady");


            Utilities.LogMessage("CreateCommandTask:: exiting function");

            #endregion // Finish wizard

            this.VerifyTaskCreated(createTaskPath, parameters.Name);
        } // end CreateCommandTask function

        /// <summary>
        ///  Create a new Console Command Line Task
        /// </summary>
        /// <param name="parameters">Console task parameters</param>
        /// <history>
        ///     [v-yoz]     21JULY09 - Created
        /// </history>
        public void CreateConsoleTask(ConsoleTaskParameters parameters)
        {
            CreateConsoleTask(parameters, SelectTaskType.Strings.ConsoleCommandLineTask);
        }

        /// <summary>
        ///  Create a new Console Command Line Task
        /// </summary>
        /// <param name="parameters">Console task parameters</param>
        /// <param name="taskType">Console Task type</param>
        /// <history>
        ///     [faizalk]   27APR06 - Created
        ///     [v-yoz]     21JULY09 - Updated
        /// </history>
        public void CreateConsoleTask(ConsoleTaskParameters parameters, string taskType)
        {
            Utilities.LogMessage("CreateConsoleTask...");

            #region Navigate to Create Task Wizard
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string createTaskPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                + Constants.PathDelimiter
                + Core.Console.Views.Views.Strings.TasksView;
            actionsPane.ClickLink(
                NavigationPane.WunderBarButton.MonitoringConfiguration,
                createTaskPath,
                ActionsPane.Strings.ActionsPaneTask,
                ActionsPane.Strings.ActionsPaneCreateANewTask);

            // find the "Create Task Wizard" dialog 
            Utilities.LogMessage("CreateConsoleTask:: Locate task window...");
            Core.Console.Tasks.Wizards.SelectTaskType selectTask = new Core.Console.Tasks.Wizards.SelectTaskType(CoreManager.MomConsole);

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    if (!selectTask.IsVisible)
                    {
                        Sleeper.Delay(3000);
                        actionsPane.ClickLink(
                           NavigationPane.WunderBarButton.MonitoringConfiguration,
                           createTaskPath,
                           ActionsPane.Strings.ActionsPaneTask,
                           ActionsPane.Strings.ActionsPaneCreateANewTask);
                        selectTask = new Core.Console.Tasks.Wizards.SelectTaskType(CoreManager.MomConsole);
                        Utilities.LogMessage("retry to click Creat New Task link times" + i.ToString());
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Utilities.LogMessage(ex.ToString());
                }

            }

            TreeNode consoleTasksFolderNode = selectTask.Controls.SelectTheTypeOfTaskToCreateTreeView.Find(SelectTaskType.Strings.ConsoleTasksFolder);
            TreeNode node = consoleTasksFolderNode.Find(taskType);
            node.Select();
            node.Click();
            selectTask.WaitForResponse();

            // Set Destination MP
            selectTask.SelectDestinationManagementPackText = parameters.DestinationMP;

            // by default Command Task type is selected so just click next
            Utilities.TakeScreenshot("CreateConsoleTask - Task Type");
            Utilities.LogMessage("CreateConsoleTask:: ClickNext...");
            selectTask.ClickNext();
            #endregion

            #region Enter Name and Description
            // find complete task window
            Core.Console.Tasks.Wizards.TaskNameDialog taskNameDialog = new Core.Console.Tasks.Wizards.TaskNameDialog(CoreManager.MomConsole);
            taskNameDialog.WaitForResponse();

            // enter name
            if (taskNameDialog.Controls.TaskNameTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Name Text Box is disabled");
            }

            taskNameDialog.Controls.TaskNameTextBox.SendKeys(parameters.Name);

            // enter description
            if (taskNameDialog.Controls.DescriptionOptionalTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Description Text Box is disabled");
            }

            if (parameters.Description != null)
            {
                taskNameDialog.Controls.DescriptionOptionalTextBox.SendKeys(parameters.Description);
            }
            #endregion // Enter name and description

            #region Select Target

            if (taskType == SelectTaskType.Strings.ConsoleCommandLineTask)
            {
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(taskNameDialog.Controls.SelectButton, Constants.OneSecond * 5);

                taskNameDialog.ClickSelect();

                Core.Console.MonitoringConfiguration.Dialogs.SelectTargetTypeDialog selectTargetType = new Core.Console.MonitoringConfiguration.Dialogs.SelectTargetTypeDialog(CoreManager.MomConsole);

                if (!String.IsNullOrEmpty(parameters.TargetEntity))
                {
                    selectTargetType.WaitForResponse();
                    selectTargetType.Controls.ViewAllTargetsRadioButton.Click();
                    selectTargetType.Controls.ListView0.WaitForResponse();
                    Sleeper.Delay(Constants.OneSecond * 5);

                    string[] selection = new string[1];
                    selection[0] = parameters.TargetEntity;

                    // look for TargetEntity first to save the search time
                    selectTargetType.LookForText = selection[0];
                    selectTargetType.WaitForResponse();

                    int tries = 0;
                    int maxTries = 5;

                    // change while loop to do/while as per bug 86178
                    do
                    {
                        selectTargetType.Controls.ListView0.MultiSelect(selection);
                        Sleeper.Delay(Constants.OneSecond);
                        tries++;
                    }
                    while (!selectTargetType.Controls.OKButton.IsEnabled && tries < maxTries);
                }

                // else we will just target at Entity
                // [jefftow] 21JAN08 - Added some better logging here so we can get a better picture of how the task is setup
                Utilities.TakeScreenshot("CreateConsoleTask - Select Target");
                Utilities.LogMessage("CreateConsoleTask:: Selecting ok on Select Target");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectTargetType.Controls.OKButton, Constants.OneMinute);
                selectTargetType.ClickOK();
            }

            Utilities.TakeScreenshot("CreateConsoleTask - Select General Properties");
            Utilities.LogMessage("CreateConsoleTask:: Select next on general properties");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(taskNameDialog.Controls.NextButton, Constants.OneMinute);
            taskNameDialog.ClickNext();

            #endregion // Select Target

            #region Configure Task
            // find command configuration window 
            Core.Common.Utilities.LogMessage("CreateConsoleTask:: Locate config window...");
            Core.Console.Tasks.Wizards.ConsoleTaskConfiguration commandConfiguration = new Core.Console.Tasks.Wizards.ConsoleTaskConfiguration(CoreManager.MomConsole);

            // populate fields 

            // make sure textboxes are enabled
            if (commandConfiguration.Controls.ProviderTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Application Text Box is disabled");
            }

            if (commandConfiguration.Controls.RequestProcessedSuccessfullyTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Parameters Text Box is disabled");
            }

            if (commandConfiguration.Controls.TotalResponseTimeMillisecondsTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Directory Text Box is disabled");
            }

            // enter Application
            if (parameters.Application != null)
            {
                commandConfiguration.Controls.ProviderTextBox.Click();

                // enter full path
                commandConfiguration.Controls.ProviderTextBox.SendKeys(parameters.Application);
            }

            // enter parameters
            if (parameters.Parameters != null)
            {
                commandConfiguration.Controls.RequestProcessedSuccessfullyTextBox.Click();

                commandConfiguration.Controls.RequestProcessedSuccessfullyTextBox.SendKeys(parameters.Parameters);
            }

            if (parameters.WorkingDirectory != null)
            {
                commandConfiguration.Controls.TotalResponseTimeMillisecondsTextBox.Click();

                // enter working directory
                commandConfiguration.Controls.TotalResponseTimeMillisecondsTextBox.SendKeys(parameters.WorkingDirectory);
            }

            #region Enable or Disable Display Output Checkbox
            if (parameters.DisplayOutput)
            {
                if (commandConfiguration.Controls.DisplayOutputCheckBox.Checked.Equals(false))
                {
                    commandConfiguration.Controls.DisplayOutputCheckBox.Click();
                }
            }
            else
            {
                if (commandConfiguration.Controls.DisplayOutputCheckBox.Checked.Equals(true))
                {
                    commandConfiguration.Controls.DisplayOutputCheckBox.Click();
                }
            }
            #endregion // Enable or Disable Display Output Checkbox

            #endregion // Configure task

            #region Check Enabled controls

            if (commandConfiguration.Controls.NextButton.IsEnabled)
            {
                throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Next button is enabled but should be disabled");
            }

            if (!commandConfiguration.Controls.PreviousButton.IsEnabled)
            {
                throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Previous button is disabled");
            }

            if (!commandConfiguration.Controls.CancelButton.IsEnabled)
            {
                throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Cancel button is disabled");
            }

            if (!commandConfiguration.Controls.CreateButton.IsEnabled)
            {
                throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Create button is disabled");
            }

            #endregion // Check enabled controls

            #region Finish wizard

            // Finish wizard
            Core.Common.Utilities.LogMessage("CreateConsoleTask:: ClickCreate...");
            commandConfiguration.ClickCreate();

            Utilities.LogMessage("CreateConsoleTask:: Wait for dialog to close...");

            commandConfiguration.ScreenElement.WaitForGone(Constants.OneMinute * 2, 6);            

            int retry = 0;
            int maxcount = 120;
            while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
            {
                Utilities.LogMessage("CreateConsoleTask:: MainWindow not Foreground, lets wait a moment.");
                Sleeper.Delay(1000);
                retry++;
            }

            Utilities.LogMessage("CreateConsoleTask:: Wait for console ready...");

            Utilities.TakeScreenshot("before WaitForStatusReady");

            consoleApp.Waiters.WaitForStatusReady(Constants.OneMinute);

            Utilities.TakeScreenshot("after WaitForStatusReady");


            Utilities.LogMessage("CreateConsoleTask:: exiting function");

            #endregion // Finish wizard

            this.VerifyTaskCreated(createTaskPath, parameters.Name);
        } // end CreateCommandTask function

        /// <summary>
        ///  Create a new Script Task
        /// </summary>
        /// <param name="parameters">Script task parameters</param>
        /// <history>
        ///     [faizalk]   30APR06 - Created
        /// </history>
        public void CreateScriptTask(ScriptTaskParameters parameters)
        {
            Utilities.LogMessage("CreateScriptTask...");

            #region Navigate to Create Task Wizard
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string createTaskPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                + Constants.PathDelimiter
                + Core.Console.Views.Views.Strings.TasksView;

            actionsPane.ClickLink(
                NavigationPane.WunderBarButton.MonitoringConfiguration,
                createTaskPath,
                ActionsPane.Strings.ActionsPaneTask,
                ActionsPane.Strings.ActionsPaneCreateANewTask);

            // find the "Create Task Wizard" dialog 
            Utilities.LogMessage("CreateScriptTask:: Locate task window...");
            Core.Console.Tasks.Wizards.SelectTaskType selectTask = new Core.Console.Tasks.Wizards.SelectTaskType(CoreManager.MomConsole);
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    if (!selectTask.IsVisible)
                    {
                        Sleeper.Delay(3000);
                        actionsPane.ClickLink(
                           NavigationPane.WunderBarButton.MonitoringConfiguration,
                           createTaskPath,
                           ActionsPane.Strings.ActionsPaneTask,
                           ActionsPane.Strings.ActionsPaneCreateANewTask);
                        selectTask = new Core.Console.Tasks.Wizards.SelectTaskType(CoreManager.MomConsole);
                        Utilities.LogMessage("retry to click Creat New Task link times" + i.ToString());
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Utilities.LogMessage(ex.ToString());
                }

            }

            TreeNode agentTasksFolderNode = selectTask.Controls.SelectTheTypeOfTaskToCreateTreeView.Find(SelectTaskType.Strings.AgentTasksFolder);
            TreeNode node = agentTasksFolderNode.Find(SelectTaskType.Strings.ScriptTask);
            node.Select();
            node.Click();
            selectTask.WaitForResponse();

            // Set Destination MP
            selectTask.SelectDestinationManagementPackText = parameters.DestinationMP;

            // by default Command Task type is selected so just click next
            Utilities.LogMessage("CreateScriptTask:: ClickNext...");
            selectTask.ClickNext();
            #endregion

            #region Enter Name and Description
            // find complete task window
            Core.Console.Tasks.Wizards.TaskNameDialog taskNameDialog = new Core.Console.Tasks.Wizards.TaskNameDialog(CoreManager.MomConsole);
            taskNameDialog.WaitForResponse();

            // enter name
            if (taskNameDialog.Controls.TaskNameTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Name Text Box is disabled");
            }

            taskNameDialog.Controls.TaskNameTextBox.SendKeys(parameters.Name);

            // enter description
            if (taskNameDialog.Controls.DescriptionOptionalTextBox.IsEnabled.Equals(false))
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Description Text Box is disabled");
            }

            if (parameters.Description != null)
            {
                taskNameDialog.Controls.DescriptionOptionalTextBox.SendKeys(parameters.Description);
            }
            #endregion // Enter name and description

            #region Select Target

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(taskNameDialog.Controls.SelectButton, Constants.OneSecond * 5);

            taskNameDialog.ClickSelect();

            Core.Console.MonitoringConfiguration.Dialogs.SelectTargetTypeDialog selectTargetType = new Core.Console.MonitoringConfiguration.Dialogs.SelectTargetTypeDialog(CoreManager.MomConsole);

            if (!String.IsNullOrEmpty(parameters.TargetEntity))
            {
                selectTargetType.WaitForResponse();
                selectTargetType.Controls.ViewAllTargetsRadioButton.Click();
                selectTargetType.Controls.ListView0.WaitForResponse();
                Sleeper.Delay(Constants.OneSecond*5);

                string[] selection = new string[1];
                selection[0] = parameters.TargetEntity;

                // look for TargetEntity first to save the search time
                selectTargetType.LookForText = selection[0];
                selectTargetType.WaitForResponse();

                int tries = 0;
                int maxTries = 5;

                // change while loop to do/while as per bug 86178
                do
                {
                    selectTargetType.Controls.ListView0.MultiSelect(selection);
                    Sleeper.Delay(Constants.OneSecond);
                    tries++;
                }
                while (!selectTargetType.Controls.OKButton.IsEnabled && tries < maxTries);
            }

            // else we will just target at Entity
            // [jefftow] 21JAN08 - Added some better logging here so we can get a better picture of how the task is setup
            Utilities.TakeScreenshot("CreateScriptTask - Select Target");
            Utilities.LogMessage("CreateScriptTask:: Selecting ok on Select Target");
            selectTargetType.ClickOK();

            Utilities.TakeScreenshot("CreateScriptTask - Select General Properties");
            Utilities.LogMessage("CreateScriptTask:: Select next on general properties");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(taskNameDialog.Controls.NextButton, Constants.OneMinute);
            taskNameDialog.ClickNext();

            #endregion // Select Target

            #region Configure Script
            // find command configuration window 
            Core.Common.Utilities.LogMessage("CreateScriptTask:: Locate config window...");
            Core.Console.Tasks.Wizards.ScriptTaskConfiguration scriptConfiguration = new Core.Console.Tasks.Wizards.ScriptTaskConfiguration(CoreManager.MomConsole);

            scriptConfiguration.Controls.FileNameTextBox.SendKeys(parameters.ScriptName);

            //scriptConfiguration.Controls.TimeoutComboBox.SendKeys(parameters.Timeout);
            scriptConfiguration.Controls.TimeoutComboBox.Text = parameters.Timeout;

            Core.Common.Utilities.LogMessage("CreateScriptTask:: Timeout :=" + scriptConfiguration.Controls.TimeoutComboBox.Text);

            // Select the time units 
            string timeUnit = null;
            switch (parameters.TimeoutUnit)
            {
                case TimeoutUnit.Seconds:
                    timeUnit = MonitoringConfiguration.MonitoringConfiguration.Strings.RunThisQueryEverySeconds;
                    break;

                case TimeoutUnit.Minutes:
                    timeUnit = MonitoringConfiguration.MonitoringConfiguration.Strings.RunThisQueryEveryMinutes;
                    break;

                case TimeoutUnit.Hours:
                    timeUnit = MonitoringConfiguration.MonitoringConfiguration.Strings.RunThisQueryEveryHours;
                    break;

                case TimeoutUnit.Days:
                    timeUnit = MonitoringConfiguration.MonitoringConfiguration.Strings.RunThisQueryEveryDays;
                    break;

                default:
                    Utilities.LogMessage("CreateScriptTask:: TimeoutUnit parameter: '" +
                        parameters.TimeoutUnit + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            scriptConfiguration.Controls.ExampleMyScriptvbsComboBox.SelectByText(timeUnit);

            if (parameters.UseEditor)
            {
                // TODO: use editor after unblocked by Bug 68281
                scriptConfiguration.Controls.ScriptTextBox.WaitForResponse();
                scriptConfiguration.Controls.ScriptTextBox.Click();
                //scriptConfiguration.Controls.ScriptTextBox.SendKeys(parameters.ScriptText);
                //Some charactors cannot be inputed by using Sendkey, ex."(" so change it.
                scriptConfiguration.ScriptText = parameters.ScriptText;
            }
            else
            {
                scriptConfiguration.Controls.ScriptTextBox.WaitForResponse();
                scriptConfiguration.Controls.ScriptTextBox.Click();
                //scriptConfiguration.Controls.ScriptTextBox.SendKeys(parameters.ScriptText);
                //Some charactors cannot be inputed by using Sendkey, ex."(" so change it.
                scriptConfiguration.ScriptText = parameters.ScriptText;
            }

            if (!String.IsNullOrEmpty(parameters.Parameters))
            {
                // TODO: use parameters editor after unblocked by Bug 68282
            }

            #endregion //Configure script

            #region Finish wizard

            // Finish wizard
            Core.Common.Utilities.LogMessage("CreateScriptTask:: ClickCreate...");
            scriptConfiguration.ClickCreate();

            Utilities.LogMessage("CreateScriptTask:: Wait for dialog to close...");

            scriptConfiguration.ScreenElement.WaitForGone(Constants.OneMinute, 6);            

            int retry = 0;
            int maxcount = 120;
            while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
            {
                Utilities.LogMessage("CreateScriptTask:: MainWindow not Foreground, lets wait a moment.");
                Sleeper.Delay(1000);
                retry++;
            }

            Utilities.LogMessage("CreateScriptTask:: Wait for console ready...");

            Utilities.TakeScreenshot("before WaitForStatusReady");

            consoleApp.Waiters.WaitForStatusReady(Constants.OneMinute);

            Utilities.TakeScreenshot("after WaitForStatusReady");

            Utilities.LogMessage("CreateScriptTask:: exiting function");

            #endregion // Finish wizard

            this.VerifyTaskCreated(createTaskPath, parameters.Name);
        } // end CreateCommandTask function

        #endregion // Create Tasks

        #region Launch Tasks
        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to launch tasks from Actions Pane
        /// </summary>
        /// <param name="treeNodePath">Node to navigate to in Monitoring space</param>
        /// <param name="actionsPaneNode">"Name of view to select"</param>
        /// <param name="taskName">"Name of task to launch"</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">
        /// if task row is not found
        /// </exception>
        /// <exception cref="Core.Console.MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException">
        /// task does not exist for discoveredInventoryNode</exception>
        /// ------------------------------------------------------------------
        public void LaunchTask(string treeNodePath, string actionsPaneNode, string taskName)
        {
            Utilities.LogMessage("Tasks.LaunchTask...");

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            // click Monitoring wunderbar button
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);

            // Select managedEntity 
            // navPane.SelectNode(discoveredInventoryNode, NavigationPane.NavigationTreeView.Monitoring);
            // Utilities.LogMessage("ActionsPane.LaunchTask:: Successfully clicked node: " + discoveredInventoryNode);

            /*string taskPath = NavigationPane.Strings.Monitoring
                + "\\" + "UITest"
                + "Performance";*/

            this.consoleApp.ActionsPane.ClickLink(NavigationPane.WunderBarButton.Monitoring, treeNodePath, actionsPaneNode, taskName);
            Utilities.LogMessage("ActionsPane.LaunchTask:: Successfully clicked task: " + taskName);

            this.RunTaskWizard();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to launch tasks from Actions Pane
        /// </summary>
        /// <param name="space">Space to navigate to</param>
        /// <param name="treeNodePath">Node to navigate to in space</param>
        /// <param name="searchItem">Item to search for in the view</param>
        /// <param name="searchColumnIndex">Column index to search for viewCellItem</param>
        /// <param name="actionsPaneSectionControlId">"Name of view to select"</param>
        /// <param name="taskName">"Name of task to launch"</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">
        /// if task row is not found
        /// </exception>
        /// <exception cref="Core.Console.MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException">
        /// task does not exist for discoveredInventoryNode</exception>
        /// ------------------------------------------------------------------
        public string LaunchTask(Core.Console.NavigationPane.WunderBarButton space, string treeNodePath, string searchItem, int searchColumnIndex, string actionsPaneSectionControlId, string taskName)
        {
            Utilities.LogMessage("Tasks.LaunchTask...");
            Utilities.LogMessage("LaunchTask:: taskPath: " + searchItem);

            NavigationPane.NavigationTreeView treeView;
            string taskOutput = null;

            switch (space)
            {
                case NavigationPane.WunderBarButton.Monitoring:
                    treeView = NavigationPane.NavigationTreeView.Monitoring;
                    break;

                case NavigationPane.WunderBarButton.MonitoringConfiguration:
                    treeView = NavigationPane.NavigationTreeView.MonitoringConfiguration;
                    break;

                case NavigationPane.WunderBarButton.Administration:
                    treeView = NavigationPane.NavigationTreeView.Administration;
                    break;

                case NavigationPane.WunderBarButton.MyWorkspace:
                    treeView = NavigationPane.NavigationTreeView.MyWorkspace;
                    break;

                default:
                    throw new InvalidEnumArgumentException("WunderBarButton enum: '" + space + "' not recognized");
            }

            //Bring console to foreground
            Utilities.TakeScreenshot("before bring to foreground");
            // workaround for bug 485853, add retry to bring MOM console to foreground . Decrease single wait time from 1 minute to 10 secs , decrease max wait time from 1 minute to 50 secs
            int i = 0;
            while (i < Constants.DefaultMaxRetry)
            {
                i++;
                try
                {
                    CoreManager.MomConsole.BringToForeground();
                    CoreManager.MomConsole.Waiters.WaitForWindowForeground(CoreManager.MomConsole.MainWindow, Constants.TenSeconds);
                }
                catch
                {
                    continue;
                }
            }
            Utilities.TakeScreenshot("after bring to foreground");

            //Select view in nav pane
            CoreManager.MomConsole.NavigationPane.SelectNode(treeNodePath, treeView);

            //Search for item in Find bar
            CoreManager.MomConsole.ViewPane.Find.LookForItem(searchItem);

            if (searchColumnIndex != -1)
            {
                //Look for item in grid view
                DataGridViewRow row = null;
                CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(
                    delegate
                    {
                        row = CoreManager.MomConsole.ViewPane.Grid.FindData(searchItem, searchColumnIndex);
                        Sleeper.Delay(Constants.OneSecond);
                        return row != null;
                    },
                    Constants.OneMinute);

                if (row != null)
                {
                    //Select item
                    CoreManager.MomConsole.ViewPane.Grid.ClickCell(row.AccessibleObject.Index, 0);
                }
                else
                {
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("Tasks.VerifyTaskCreated:: Failed to find created Task: " + taskName);
                }
                
            }
            else
            {
                // Select all instance in the view
                if (CoreManager.MomConsole.ViewPane.Grid.Rows.Count < 1)
                {
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("Tasks.VerifyTaskCreated:: the grid view is empty.");
                }
                Utilities.LogMessage("LaunchTask:: Select all instance in the view");
                CoreManager.MomConsole.ViewPane.Grid.Rows[0].Click();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(KeyboardCodes.Ctrl + KeyboardCodes.Shift + KeyboardCodes.End);
                Sleeper.Delay(Constants.OneSecond * 2);//Sleeper 2 second wait for action Pane response, bug#185226
            }

            Utilities.LogMessage("ActionsPane.LaunchTask:: Get ActionsPane node.");
            TaskStrip taskStrip = new TaskStrip(CoreManager.MomConsole.ActionsPane, actionsPaneSectionControlId);

            // after click link, if run task window not opeded, try again
            int maxTry = 5;
            int countTry = 0;
            bool skipWhile = false;
            while (countTry < maxTry && !skipWhile)
            {
                try
                {
                    try
                    {
                        this.consoleApp.ActionsPane.ClickLink(actionsPaneSectionControlId, taskName, MouseFlags.LeftButton);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        //Bug#182926
                        Utilities.LogMessage("ActionsPane.LaunchTask:: The task link not found, Try click again");
                        //this.consoleApp.ActionsPane.ClickLink(actionsPaneSectionControlId, taskName, MouseFlags.LeftButton);
                        Command Tasks = new Command(ActionsPane.Strings.ActionsPaneTasks + "|" + actionsPaneSectionControlId + "|" + taskName, null, null, null);
                        Tasks.Execute(this.consoleApp, CommandMethod.Default);

                    }
                    catch (System.InvalidOperationException)
                    {
                        //Bug#182926
                        Utilities.LogMessage("ActionsPane.LaunchTask:: Invalid Operation Exception, Try click again");
                        //this.consoleApp.ActionsPane.ClickLink(actionsPaneSectionControlId, taskName, MouseFlags.LeftButton);
                        Command Tasks = new Command(ActionsPane.Strings.ActionsPaneTasks + "|" + actionsPaneSectionControlId + "|" + taskName, null, null, null);
                        Tasks.Execute(this.consoleApp, CommandMethod.Default);

                    }
                    finally
                    {
                        Utilities.TakeScreenshot("ActionsPane.LaunchTask-ClickTaskLink");
                    }
                    // RunTaskWizard returns if it was a Console Task
                    // or Agent task that ran.  Only agent tasks have
                    // their history recorded in the Task Status View
                    // and can be verified as such.
                    /*if (this.RunTaskWizard())
                    {
                        this.VerifyTaskRan(taskName);
                    }*/
                    Utilities.TakeScreenshot("BeforeRunTaskWizard");

                    taskOutput = this.RunTaskWizard();

                    skipWhile = true;
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("LaunchTask:: failed to open run task window after click link, will try again.");
                    countTry++;
                    Sleeper.Delay(Constants.OneSecond);
                }
            }
            //Bring MomConsole window to foreground, bug#217801
            if (!CoreManager.MomConsole.MainWindow.Extended.IsForeground)
            {
                CoreManager.MomConsole.BringToForeground();
            }

            if (CoreManager.MomConsole.ViewPane.Find.Controls.ClearButton.IsEnabled)
            {
                CoreManager.MomConsole.ViewPane.Find.ClickClear();
            }

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

            return taskOutput;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to launch tasks from Actions Pane
        /// </summary>
        /// <param name="space">Space to navigate to</param>
        /// <param name="treeNodePath">Node to navigate to in space</param>
        /// <param name="searchItem1">Item1 to search for in the view</param>
        /// <param name="searchColumn1">Column1 to search for viewCellItem</param>
        /// <param name="searchItem2">Item2 to search for in the view</param>
        /// <param name="searchColumn2">Column2 to search for viewCellItem</param>       
        /// <param name="actionsPaneSectionControlId">"Name of view to select"</param>
        /// <param name="taskName">"Name of task to launch"</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">
        /// if task row is not found
        /// </exception>
        /// <exception cref="Core.Console.MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException">
        /// task does not exist for discoveredInventoryNode</exception>
        /// ------------------------------------------------------------------
        public void LaunchTask(Core.Console.NavigationPane.WunderBarButton space, string treeNodePath, string searchItem1, string searchColumn1, string searchItem2, string searchColumn2, string actionsPaneSectionControlId, string taskName)
        {
            Utilities.LogMessage("Tasks.LaunchTask...");
            Utilities.LogMessage("LaunchTask:: search items: " + searchItem1 + ", " + searchItem2);

            NavigationPane.NavigationTreeView treeView;
            ViewPane viewPane = CoreManager.MomConsole.ViewPane;

            switch (space)
            {
                case NavigationPane.WunderBarButton.Monitoring:
                    treeView = NavigationPane.NavigationTreeView.Monitoring;
                    break;

                case NavigationPane.WunderBarButton.MonitoringConfiguration:
                    treeView = NavigationPane.NavigationTreeView.MonitoringConfiguration;
                    break;

                case NavigationPane.WunderBarButton.Administration:
                    treeView = NavigationPane.NavigationTreeView.Administration;
                    break;

                case NavigationPane.WunderBarButton.MyWorkspace:
                    treeView = NavigationPane.NavigationTreeView.MyWorkspace;
                    break;

                default:
                    throw new InvalidEnumArgumentException("WunderBarButton enum: '" + space + "' not recognized");
            }

            CoreManager.MomConsole.BringToForeground();
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(space);

            consoleApp.Waiters.WaitForStatusReady(Constants.OneMinute);
            Utilities.TakeScreenshot("Brought up space " + space.ToString());

            // search the View
            Core.Console.MomControls.GridControl viewGrid = null;
            DataGridViewRow row = null;
            int retry = 0;
            int maxcount = 10;
            while (viewGrid == null && retry <= maxcount)
            {
                try
                {
                    // Select view
                    navPane.SelectNode(treeNodePath, treeView);
                    Utilities.TakeScreenshot("After selecting node path" + treeNodePath.Replace(@"\", "_"));
                    viewGrid = CoreManager.MomConsole.ViewPane.Grid;

                    int retryFind = 0;
                    int maxretry = 10;

                    while ((String.Compare(viewPane.Find.LookForText, searchItem1) != 0) && retryFind <= maxretry)
                    {
                        viewPane.Find.ClickClear();

                        CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();                       
                        Sleeper.Delay(Constants.OneSecond);
                        viewPane.Find.LookForText = searchItem1;
                        retryFind++;
                    }                    

                    viewPane.Find.ClickFindNow();

                    Utilities.TakeScreenshot("After clicking find now on " + searchItem1);

                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                    viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                    row = viewGrid.FindInstanceRow(searchColumn1, searchColumn2, searchItem1, searchItem2, 2);
                    if (row == null)
                    {
                        // We'll try again
                        viewGrid = null;
                        Utilities.LogMessage("Could not find '" + searchItem1 + "' and '" + searchItem2 + "' so retrying...");
                    }

                    /* adding this logic because sometimes viewGrid re-renders after Find
                     * so row we searched for may not be the same row now displayed
                     * Bug 80372*/
                    DataGridViewRow rowConfirm = viewGrid.Rows[row.AccessibleObject.Index];
                    Utilities.LogMessage("Comparing found row: '" + row.Value + "' with current row: '" + rowConfirm.Value + "'");
                    if (String.Compare(row.Value, rowConfirm.Value) != 0)
                    {
                        // need to retry again because row may have rendered again
                        viewGrid = null;
                        Utilities.LogMessage("Rows do not match so retrying...");
                    }
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("Tasks.LaunchTask:: Failed to get reference to ViewPane.Grid, lets navigate and try again.");
                    Utilities.TakeScreenshot("Tasks.LaunchTask_GridView_NotFound");
                }
                catch (System.NullReferenceException)
                {
                    Utilities.LogMessage("Tasks.LaunchTask:: Got a null reference, lets try again.");
                    Utilities.TakeScreenshot("Tasks.LaunchTask_NullException");
                }

                retry++;

                if (row != null)
                {
                    viewGrid.ClickCell(row.AccessibleObject.Index, 0);
                }
                else
                {
                    // bug 93305 - throwing an exception here breaks the retry logic so just log and continue
                    Utilities.LogMessage("Tasks.VerifyTaskCreated:: Failed to find row with task: " + taskName);
                }
            } //end of while loop. loop closed due to fix for russian localization build for null string
                Utilities.LogMessage("ActionsPane.LaunchTask:: Get ActionsPane node.");
                TaskStrip taskStrip = new TaskStrip(CoreManager.MomConsole.ActionsPane, actionsPaneSectionControlId);

                // Click the Link
                taskStrip.Expand();
                Utilities.LogMessage("ActionsPane.LaunchTask:: Executing Task: " + taskName);
                int retries = 0;
                int maxRetries = 10;
                bool taskClicked = false;

                // bug 81020 -- adding retry logic
                while (taskClicked == false && retries < maxRetries)
                {
                    try
                    {
                        taskStrip.TaskStripItems[taskName].Click();
                        Utilities.LogMessage("ActionsPane.LaunchTask:: Successfully clicked task: " + taskName);
                        taskClicked = true;
                    }
                    catch (MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException tsife)
                    {
                        Utilities.LogMessage("ActionsPane.LaunchTask:: TaskStripItemNotFoundException thrown... " + tsife.StackTrace);
                        Sleeper.Delay(Constants.OneSecond);
                    }
                    catch (System.ArgumentException ae)
                    {
                        Utilities.LogMessage("ActionsPane.LaunchTask:: ArgumentException thrown... " + ae.StackTrace);
                        Sleeper.Delay(Constants.OneSecond);
                    }
                    finally
                    {
                        retries++;
                        Utilities.LogMessage("ActionsPane.LaunchTask:: try " + retries + " of " + maxRetries + " to click task");
                    }
                }

                if (!taskClicked) // task not found in Actions Pane
                {
                    /* adding this logic because sometimes viewGrid reloads and forget index
                     * so row we searched for may not be the same row now highlighted..
                     * Bug 86605*/
                    viewGrid = null; // forces retry
                    Utilities.LogMessage("Failed to find task '" + taskName + "' in Actions Pane ");
                }
           // } while loop ---null string localization

            this.RunTaskWizard();

            if (viewPane.Find.Controls.ClearButton.IsEnabled)
            {
                viewPane.Find.ClickClear();
            }

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

        } // LaunchTask

        /// <summary>
        /// PersonalizeTaskView class
        /// </summary>
        public void PersonalizeTaskView()
        {
            Utilities.LogMessage("Personalize Task View...");

            // Create the object for storing the custom "personalized" settings
            Views.PersonalizeViewDialogSettings personalizeViewTaskSettings = new Views.PersonalizeViewDialogSettings();

            #region Personalization Settings

            // Choose the columns that will be displayed in the view
            personalizeViewTaskSettings.AddDisplayColumn(Strings.ColumnStatus);
            personalizeViewTaskSettings.AddDisplayColumn(Strings.ColumnTaskName);
            personalizeViewTaskSettings.AddDisplayColumn(Strings.ColumnCategory);
            personalizeViewTaskSettings.AddDisplayColumn(Strings.ColumnLastModifiedTime);
            personalizeViewTaskSettings.AddDisplayColumn(Strings.ColumnStartTime);
            personalizeViewTaskSettings.AddDisplayColumn(Strings.ColumnTaskTarget);
            personalizeViewTaskSettings.AddDisplayColumn(Strings.ColumnSubmitedBy);

            // Desginate the columns that are "Sortable"
            personalizeViewTaskSettings.AddSortableColumn(Strings.ColumnStartTime);
            personalizeViewTaskSettings.AddSortableColumn(Strings.ColumnStatus);
            personalizeViewTaskSettings.AddSortableColumn(Strings.ColumnSubmitedBy);
            personalizeViewTaskSettings.AddSortableColumn(Strings.ColumnTaskName);
            personalizeViewTaskSettings.AddSortableColumn(Strings.ColumnTaskTarget);

            // Set the Sort and Group personalized settings
            // personalizeViewTaskSettings.SetSortColumnsBy(Strings.ColumnStartTime, ButtonState.Checked, ButtonState.UnChecked);
            personalizeViewTaskSettings.SetSortColumnsBy(Strings.ColumnStartTime, Views.PersonalizeViewDialogSettings.SortType.Ascending);
            personalizeViewTaskSettings.SetFirstGroupBy(Strings.ColumnSubmitedBy, Views.PersonalizeViewDialogSettings.SortType.Descending);
            personalizeViewTaskSettings.SetSecondGroupBy(Strings.ColumnStatus, Views.PersonalizeViewDialogSettings.SortType.Descending);
            personalizeViewTaskSettings.SetThirdGroupBy(Strings.ColumnTaskTarget, Views.PersonalizeViewDialogSettings.SortType.Descending);

            #endregion

            // Navigate to TaskStatus view, and apply the personalization with the above settings
            Views.PersonalizeView personalView = new Views.PersonalizeView(personalizeViewTaskSettings, Views.Strings.TaskStatusView);

            #region PersonalizationTests

            // Check the grouping is functioning
            personalView.CheckGrouping();

            // Check the column headers are matching what was selected in personal view
            personalView.CheckColumnHeaders();

            // Check all the "sortable" columns, are sorting properly
            personalView.CheckColumnSorting();

            #endregion
        }

        /// <summary>
        /// Modifier method to set the task override parameters
        /// </summary>
        /// <param name="timeout">Timeout override parameter</param>
        /// <param name="arguments">Arguments override parameter</param>
        public void SetTaskOverrides(string timeout, string arguments)
        {
            Utilities.LogMessage("SetTaskOverrides:: timeout [" + timeout + "] arguments[" + arguments + "]");

            // Core.Console.Tasks.OverrideTaskParametersDialog overrideTaskDialog = new Core.Console.Tasks.OverrideTaskParametersDialog(CoreManager.MomConsole);
            this.overrideTimeout = timeout;
            this.overrideArguments = arguments;
        }

        /// <summary>
        /// Modifier method to set the agent task user information
        /// </summary>
        /// <param name="userName">User name parameter</param>
        /// <param name="password">Password parameter</param>
        public void SetTaskUserInfo(string userName, string password)
        {
            Utilities.LogMessage("SetTaskUserInfo:: User name [" + userName + "] password[" + password + "]");

            // Core.Console.Tasks.OverrideTaskParametersDialog overrideTaskDialog = new Core.Console.Tasks.OverrideTaskParametersDialog(CoreManager.MomConsole);
            this.agentUserName = userName;
            this.agentUserPassword = password;
        }

        /// <summary>
        /// Method to to set the output string used to verify task output
        /// </summary>
        /// <param name="outputSearchStr">Output string to search output displayed</param>
        public void VerifyTaskOutput(string outputSearchStr)
        {
            this.verifyTaskOutput = true;
            this.taskOutputString = outputSearchStr;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to run tasks using domain admin account
        /// </summary>
        /// <param name="domainAdminAccount">domain admin account</param>
        /// <returns></returns>
        /// ------------------------------------------------------------------
        public string RunTaskWizard(string domainAdminAccount)
        {
            Utilities.LogMessage("RunTaskWizard:: trying to get domain admin account's password");
            string password = Mom.Test.Infrastructure.PasswordManager.GetPassword(domainAdminAccount);
            return this.RunTaskWizard(domainAdminAccount, password);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to run tasks using domain account and password
        /// </summary>
        /// <param name="domainAdminAccount">domain admin account</param>
        /// <param name="password">password of domain admin account</param>
        /// <returns></returns>
        /// ------------------------------------------------------------------
        public string RunTaskWizard(string domainAdminAccount,string password)
        {
            this.SetTaskUserInfo(domainAdminAccount, password);
            return this.RunTaskWizard();
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to run tasks after they have been clicked from task pane or product knowledge, handles the Run Task dialog box
        /// </summary>
        /// ------------------------------------------------------------------
        public string RunTaskWizard()
        {
            Utilities.LogMessage("RunTaskWizard...");

            string taskOutput = null;

            // Set wait loop parameters
            int timeWaited = 0;

            int MaxTimeWaited = 240; //increasing the timeout from 120s to 240s first and file a new performance bug about it , will low down it when this perf issue be fixed.

            // Rows of the DataGridView that contain the timeout / argument textbox
            const int OverrideTimeoutRow = 1;
            const int OverrideArgumentRow = 2;

            // Column of the value field used to set timeout / argument textbox
            const int OverrideValueColumn = 3;

            try
            {
                // Try console task window
                Utilities.LogMessage("RunTaskWizard:: Creating Run Console Task Dialog");
                Core.Console.Tasks.RunConsoleTaskDialog runConsoleTaskDialog = new Core.Console.Tasks.RunConsoleTaskDialog(CoreManager.MomConsole);

                // Wait for task to complete
                Utilities.TakeScreenshot("RunTaskWizard - waiting for task to complete");
                Utilities.LogMessage("RunTaskWizard:: waiting for task to complete...");

                // Set wait loop parameters
                timeWaited = 0;

                // Wait for the test to finish
                while (runConsoleTaskDialog.Controls.TheTaskWasCompletedStaticControl.Text.Equals(Strings.ConsoleTaskCompleted) == false
                    && timeWaited < MaxTimeWaited)
                {
                    // Wait a second and try again
                    timeWaited = timeWaited + 1;
                    Sleeper.Delay(Constants.OneSecond);
                }

                taskOutput = runConsoleTaskDialog.OutputText;

                Utilities.TakeScreenshot("RunTaskWizard - Task completed task running dialog box should be gone");
                Utilities.LogMessage("RunTaskWizard:: waited " + timeWaited + " seconds for test to complete.");
                runConsoleTaskDialog.ClickClose();
            }

            // Must of not been a task running dialog box, but rather a run task dialog
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                //try
                //{
                Utilities.LogMessage("RunTaskWizard:: Creating Run Task Dialog");
                Core.Console.Tasks.RunTaskDialog runTaskDialog = new Core.Console.Tasks.RunTaskDialog(CoreManager.MomConsole);

                // If we have overrides, set them in the overrides dialog box then close it
                if ((this.overrideTimeout != null) || (this.overrideArguments != null))
                {
                    Utilities.LogMessage("RunTaskWizard:: There are task overrides... Clicking Override button");
                    runTaskDialog.ClickOverride();
                    Core.Console.Tasks.OverrideTaskParametersDialog overrideTaskDialog = new Core.Console.Tasks.OverrideTaskParametersDialog(CoreManager.MomConsole);                    
                    overrideTaskDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("RunTaskWizard:: overrideTaskDialog.caption = " + overrideTaskDialog.Caption);
                    GridControl overrideGrid = new Core.Console.MomControls.GridControl(
                        overrideTaskDialog,
                        Mom.Test.UI.Core.Console.Tasks.OverrideTaskParametersDialog.ControlIDs.OverrideTheTaskParametersWithTheNewValuesPropertyGridView);
                    overrideGrid.SetCellValue(OverrideTimeoutRow, OverrideValueColumn, this.overrideTimeout, DataGridViewCellType.TextBox);
                    overrideGrid.SetCellValue(OverrideArgumentRow, OverrideValueColumn, this.overrideArguments, DataGridViewCellType.TextBox);
                    Utilities.LogMessage("RunTaskWizard:: Set Task overrides Timeout: " + this.overrideTimeout + " Arguments: " + this.overrideArguments);
                    Utilities.TakeScreenshot("RunTaskWizard - Set task overrides");
                    overrideTaskDialog.ClickOverride();
                }
                else
                {
                    Utilities.LogMessage("RunTaskWizard:: There are no task overrides... Skipping the task override dialog box");
                }

                // Set User name and password
                if ((this.agentUserName != null) || (this.agentUserPassword != null))
                {
                    runTaskDialog.RadioGroup0 = RadioGroup0.Other;

                    runTaskDialog.UserNameText = this.agentUserName;
                    Utilities.LogMessage("RunTaskWizard:: Set User name := " +
                        runTaskDialog.UserNameText);
                    runTaskDialog.PasswordText = this.agentUserPassword;                    
                    Utilities.LogMessage("RunTaskWizard:: Set Password := " +                       
                        this.agentUserPassword);//runTaskDialog.PasswordText); In MAUI2.0, don't surpport get text from a password edit controller.
                }
                else
                {
                    Utilities.LogMessage("RunTaskWizard:: There are no task credential... Skipping the task credential type in data");
                }
                // Click Run Task Button
                runTaskDialog.ClickRun();

                // Get Task Status Dialog
                Core.Console.Tasks.TaskStatusDialog taskStatusDialog = new Core.Console.Tasks.TaskStatusDialog(CoreManager.MomConsole);
                taskStatusDialog.ScreenElement.WaitForReady();

                // Wait for task to complete
                Utilities.TakeScreenshot("RunTaskWizard - Running task - task status window");
                Utilities.LogMessage("RunTaskWizard:: waiting for task to complete...");

                // Set wait loop parameters
                timeWaited = 0;

                // Wait for the test to finish
                while (taskStatusDialog.Controls.AllTasksCompletedStaticControl.Text.Equals(Strings.AgentTaskCompleted) == false
                    && taskStatusDialog.Controls.AllTasksCompletedStaticControl.Text.Equals(Strings.AgentTaskFailedToRun) == false
                    && taskStatusDialog.Controls.AllTasksCompletedStaticControl.Text.Equals
(Strings.AgentTaskFailedToSubmit) == false
                    && timeWaited < MaxTimeWaited)
                {
                    Utilities.LogMessage("RunTaskWizard:: time waited for task to complete: " + timeWaited + " task status " + taskStatusDialog.Controls.AllTasksCompletedStaticControl.Text);

                    // Wait a second and try again
                    timeWaited = timeWaited + 1;
                    Sleeper.Delay(Constants.OneSecond);
                }

                Utilities.LogMessage("RunTaskWizard:: waited " + timeWaited + " seconds for task to complete.");

                // [jefftow] 17DEC07  - Added missing logic to throw a Exception when the task doesn't complete successfully
                if (timeWaited >= MaxTimeWaited)
                {
                    Utilities.TakeScreenshot("RunTaskWizard - Task failed to complete");
                    throw new Exception("Task failed to complete in " + MaxTimeWaited + " seconds");
                }

                Utilities.TakeScreenshot("RunTaskWizard - Task Completed - task status dialog");

                // [jefftow] 17DEC07 - Added functionality to verify the output
                // Verify task output from the html output
                if (this.verifyTaskOutput)
                {
                    HtmlDocument knowledgeDocument = taskStatusDialog.Controls.HtmlTaskOutput;
                    if (knowledgeDocument.Document2.body.innerText.Contains(this.taskOutputString))
                    {
                        Utilities.LogMessage("RunTaskWizard:: Task output matched");
                    }
                    else
                    {
                        Utilities.TakeScreenshot("RunTaskWizard - task output does not match expected output string");
                        throw new Exception("Task output is not matching MCF parameters " + this.taskOutputString);
                    }
                }
                
                // loop to get running task results of all agent instance 
                for (int i = 0; i < taskStatusDialog.Controls.AreYouSureYouWantToRunThisTaskListView.Items.Count; i++)
                {
                    //Click every task target
                    if (i == 0)
                    {
                        taskStatusDialog.Controls.AreYouSureYouWantToRunThisTaskListView.Items[i].Click();
                    }
                    else
                    {
                        Keyboard.SendKeys(KeyboardCodes.DownArrow);
                    }

                    Sleeper.Delay(Constants.OneSecond);

                    //Append all task output to return string.
                    taskOutput = taskOutput + taskStatusDialog.GetText();
                }

                //Utilities.LogMessage("RunTaskWizard:: TaskOutputHTML : " + taskStatusDialog.GetHTML());
                Utilities.LogMessage("RunTaskWizard:: TaskOutputText : " + taskOutput);
                Utilities.LogMessage("RunTaskWizard:: Task Completed successfully");

                // Click Close button
                taskStatusDialog.ClickClose();
                //}


                // return true; 

            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            

            return taskOutput;
           
        } // RunTaskWizard method

        /// <summary>
        /// Overloaded method to run tasks after they have been clicked from task pane or product knowledge, handles the Run Task dialog box
        /// </summary>
        /// <param name="taskType">Task type for Console Task or Agent Task</param>
        /// <returns>Task output</returns>
        public string RunTaskWizard(TaskType taskType)
        {
            Utilities.LogMessage("RunTaskWizard...");

            string taskOutput = null;

            // Set wait loop parameters
            int timeWaited = 0;
            int MaxTimeWaited = 90; //increasing the timeout from 60 to 90 secs. TODO make MaxTimeWaited a parameter to this method

            // Rows of the DataGridView that contain the timeout / argument textbox
            int OverrideTimeoutRow = 1;
            int OverrideArgumentRow = 2;

            // Column of the value field used to set timeout / argument textbox
            int OverrideValueColumn = 3;

            try
            {
                switch (taskType)
                {
                    case TaskType.ConsoleTask:
                        {
                            // Try console task window
                            Utilities.LogMessage("RunTaskWizard:: Creating Run Console Task Dialog");
                            Core.Console.Tasks.RunConsoleTaskDialog runConsoleTaskDialog = new Core.Console.Tasks.RunConsoleTaskDialog(CoreManager.MomConsole);

                            // Wait for task to complete
                            Utilities.TakeScreenshot("RunTaskWizard - waiting for task to complete");
                            
                            // Wait for the test to finish
                            while (!runConsoleTaskDialog.Controls.TheTaskWasCompletedStaticControl.Text.Equals(Strings.ConsoleTaskCompleted)
                                && timeWaited < MaxTimeWaited)
                            {
                                // Wait a second and try again
                                timeWaited = timeWaited + 1;
                                Sleeper.Delay(1000);
                            }

                            taskOutput = runConsoleTaskDialog.OutputText;

                            Utilities.TakeScreenshot("RunTaskWizard - Task completed task running dialog box should be gone");
                            Utilities.LogMessage("RunTaskWizard:: waited " + timeWaited + " seconds for test to complete.");
                            runConsoleTaskDialog.ClickClose();
                            break;
                        }

                    case TaskType.AgentTask:
                        {
                            Utilities.LogMessage("RunTaskWizard:: Creating Run Task Dialog");
                            Core.Console.Tasks.RunTaskDialog runTaskDialog = new Core.Console.Tasks.RunTaskDialog(CoreManager.MomConsole);

                            // If we have overrides, set them in the overrides dialog box then close it
                            if ((this.overrideTimeout != null) || (this.overrideArguments != null))
                            {
                                Utilities.LogMessage("RunTaskWizard:: There are task overrides... Clicking Override button");
                                runTaskDialog.ClickOverride();
                                Core.Console.Tasks.OverrideTaskParametersDialog overrideTaskDialog = new Core.Console.Tasks.OverrideTaskParametersDialog(CoreManager.MomConsole);
                                overrideTaskDialog.ScreenElement.WaitForReady();
                                Utilities.LogMessage("RunTaskWizard:: overrideTaskDialog.caption = " + overrideTaskDialog.Caption);
                                GridControl overrideGrid = new Core.Console.MomControls.GridControl(
                                    overrideTaskDialog,
                                    Mom.Test.UI.Core.Console.Tasks.OverrideTaskParametersDialog.ControlIDs.OverrideTheTaskParametersWithTheNewValuesPropertyGridView);
                                overrideGrid.SetCellValue(OverrideTimeoutRow, OverrideValueColumn, this.overrideTimeout, DataGridViewCellType.TextBox);
                                overrideGrid.SetCellValue(OverrideArgumentRow, OverrideValueColumn, this.overrideArguments, DataGridViewCellType.TextBox);
                                Utilities.LogMessage("RunTaskWizard:: Set Task overrides Timeout: " + this.overrideTimeout + " Arguments: " + this.overrideArguments);
                                Utilities.TakeScreenshot("RunTaskWizard - Set task overrides");
                                overrideTaskDialog.ClickOverride();
                            }
                            else
                            {
                                Utilities.LogMessage("RunTaskWizard:: There are no task overrides... Skipping the task override dialog box");
                            }

                            // Set User name and password
                            if ((this.agentUserName != null) && (this.agentUserPassword != null))
                            {
                                runTaskDialog.RadioGroup0 = RadioGroup0.Other;

                                runTaskDialog.UserNameText = this.agentUserName;
                                Utilities.LogMessage("RunTaskWizard:: Set User name := " +
                                    runTaskDialog.UserNameText);
                                runTaskDialog.PasswordText = this.agentUserPassword;
                                Utilities.LogMessage("RunTaskWizard:: Set Password := " +
                                    this.agentUserPassword);//runTaskDialog.PasswordText); In MAUI2.0, don't surpport get text from a password edit controller.
                            }
                            else
                            {
                                Utilities.LogMessage("RunTaskWizard:: There are no task credential... Skipping the task credential type in data");
                            }
                            // Click Run Task Button
                            runTaskDialog.ClickRun();

                            // Get Task Status Dialog
                            Core.Console.Tasks.TaskStatusDialog taskStatusDialog = new Core.Console.Tasks.TaskStatusDialog(CoreManager.MomConsole);
                            taskStatusDialog.ScreenElement.WaitForReady();
                            
                            // Wait for task to complete
                            Utilities.TakeScreenshot("RunTaskWizard - Running task - task status window");
                            Utilities.LogMessage("RunTaskWizard:: waiting for task to complete...");

                            // Set wait loop parameters
                            timeWaited = 0;

                            // Wait for the test to finish
                            while (!taskStatusDialog.Controls.AllTasksCompletedStaticControl.Text.Equals(Strings.AgentTaskCompleted)
                                && !taskStatusDialog.Controls.AllTasksCompletedStaticControl.Text.Equals(Strings.AgentTaskFailedToRun)
                                && timeWaited < MaxTimeWaited)
                            {
                                Utilities.LogMessage("RunTaskWizard:: time waited for task to complete: " + timeWaited + " task status " + taskStatusDialog.Controls.AllTasksCompletedStaticControl.Text);

                                // Wait a second and try again
                                timeWaited = timeWaited + 1;
                                Sleeper.Delay(1000);
                            }

                            Utilities.LogMessage("RunTaskWizard:: waited " + timeWaited + " seconds for task to complete.");

                            // Added missing logic to throw a Exception when the task doesn't complete successfully
                            if (timeWaited >= MaxTimeWaited)
                            {
                                Utilities.TakeScreenshot("RunTaskWizard - Task failed to complete");
                                throw new Exception("Task failed to complete in " + MaxTimeWaited + " seconds");
                            }

                            Utilities.TakeScreenshot("RunTaskWizard - Task Completed - task status dialog");

                            // Verify task output from the html output
                            if (this.verifyTaskOutput)
                            {
                                HtmlDocument knowledgeDocument = taskStatusDialog.Controls.HtmlTaskOutput;
                                if (knowledgeDocument.Document2.body.innerText.Contains(this.taskOutputString))
                                {
                                    Utilities.LogMessage("RunTaskWizard:: Task output matched");
                                }
                                else
                                {
                                    Utilities.TakeScreenshot("RunTaskWizard - task output does not match expected output string");
                                    throw new Exception("Task output is not matching MCF parameters " + this.taskOutputString);
                                }
                            }

                            // loop to get running task results of all agent instance 
                            for (int i = 0; i < taskStatusDialog.Controls.AreYouSureYouWantToRunThisTaskListView.Items.Count; i++)
                            {
                                //Click every task target
                                taskStatusDialog.Controls.AreYouSureYouWantToRunThisTaskListView.Items[i].Click();

                                Sleeper.Delay(Constants.OneSecond);

                                //Append all task output to return string.
                                taskOutput = taskOutput + taskStatusDialog.GetText();
                            }

                            Utilities.LogMessage("RunTaskWizard:: TaskOutputHTML : " + taskStatusDialog.GetHTML());
                            Utilities.LogMessage("RunTaskWizard:: TaskOutputText : " + taskStatusDialog.GetText());
                            Utilities.LogMessage("RunTaskWizard:: Task Completed successfully");

                            // Click Close button
                            taskStatusDialog.ClickClose();
                            break;
                        }

                    default:
                        {
                            throw new Exception("RunTaskWizard:: Not a valid task type, fail to run task!");
                        }
                }
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return taskOutput;
        }

        #endregion //Launch Tasks

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a task.
        /// </summary>
        /// <param name="managementPackObj">Name of management pack object to delete the task from</param>
        /// <param name="taskName">"Name of task to delete"</param>
        /// <history>
        ///     [jefftow] 15AUG07 - Fixed this method so it now can be used to delete tasks
        ///                       - Removed managedEntity parameter.. There is no way to scope down to just a single managed entity now
        ///                         because tasks will have unique names we don't have to worry.
        /// </history>
        /// ------------------------------------------------------------------
        public void DeleteTask(string managementPackObj, string taskName)
        {
            Utilities.LogMessage("DeleteTask...");

            Core.Common.Utilities.LogMessage("Tasks.DeleteTask :: MP: " + managementPackObj);
            Core.Common.Utilities.LogMessage("Tasks.DeleteTask :: Name of the Task to Delete: " + taskName);

            // Navigate to monitoring configuration (now Authoring) space of the MOM Console, and click on the MP
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.SelectNode(
                NavigationPane.Strings.Authoring +
                Constants.PathDelimiter +
                NavigationPane.Strings.MonConfigTreeViewManagementPackObjects +
                Constants.PathDelimiter +
                managementPackObj,
                NavigationPane.NavigationTreeView.Authoring);

            Utilities.LogMessage("Tasks.DeleteTask :: Successfully clicked on Authoring\\Management Pack Objects\\" + managementPackObj);
            Utilities.TakeScreenshot("Successfully clicked on Management Pack Object");

            // Filter down the grid control using the findbar to hunt for the specific task
            MomControls.FindBar findBar = CoreManager.MomConsole.ViewPane.Find;

            // Make sure we have a findbar and that it is visible 
            if ((findBar != null) && findBar.IsVisible)
            {
                findBar.LookForItem(taskName);
            }
            else
            {
                Utilities.LogMessage("DeleteTask:: No find bar was found");
            }

            // Wait for the Grid control to be updated before attempting to find the data in the Grid.
            // CoreManager.MomConsole.ViewPane.WaitForResponse();

            consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Timeout);


            // Find created task in grid
            Maui.Core.WinControls.DataGridViewRow taskRow = CoreManager.MomConsole.ViewPane.Grid.FindData(taskName, 0, GridControl.SearchStringMatchType.ExactMatch);

            // Wait for response before attempting to open the context menu

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

            if (taskRow == null)
            {
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException("Task:\"" + taskName + "\" not found in Task View");
            }

            if (!taskRow.Cells[0].GetValue().Equals(taskName))
            {
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException("Task Name:\"" + taskName + "\" not found in Task View column");
            }

            // Task was found.. right click and open a context menu to delete this task
            else
            {
                Utilities.LogMessage("Tasks.DeleteTask:: Successfully returned from FindDataInRowGrid");
                Utilities.TakeScreenshot("Found task to Delete");
                Utilities.LogMessage("Tasks.DeleteTask:: Right click and open context menu");
                // add new method to click cell , workarround for bug 377107
                //CoreManager.MomConsole.ViewPane.Grid.ClickCell(taskRow.AccessibleObject.Index, 0, MouseClickType.SingleClick, MouseFlags.LeftButton);
                int Retry = 0;
                int Maxretry = CoreManager.MomConsole.ViewPane.Grid.Rows.Count / 10;
                while (Retry < Maxretry && !taskRow.Cells[0].AccessibleObject.Selected)
                {
                    Retry++;
                    try
                    {
                        CoreManager.MomConsole.ViewPane.Grid.ClickCell(taskRow.AccessibleObject.Index, 0);
                    }
                    catch (Exception ex)
                    {
                        Core.Common.Utilities.LogMessage(
                            "Try to click task fail:: Attempt " + Retry + " of " + Maxretry);
                        if (Retry == Maxretry)
                        {
                            Core.Common.Utilities.LogMessage(ex.ToString());
                        }
                    }
                }
                Utilities.TakeScreenshot("select task");
            }

            CoreManager.MomConsole.ActionsPane.ClickLink(ActionsPane.Strings.ActionsPaneTask, ActionsPane.Strings.ActionsPaneDeleteGroup);

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

            consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Timeout);

            // Answer yes to the "Confirm Task Delete" dialog box
            Utilities.LogMessage("Tasks.DeleteTask:: Looking for task delete dialog box with title : " + Strings.ConfirmTaskDelete);

            // LOG what the resource string is coming back as
            String tmpResString = ";Confirm Task Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.TasksView.TasksViewResources;ConfirmTaskDelete";
            Utilities.LogMessage("Using resource string : " + tmpResString);
            Utilities.LogMessage("GetIntlStr returns :" + CoreManager.MomConsole.GetIntlStr(tmpResString));

            // [jefftow] 11OCT07 NOTE ... For some reason the below statement was returning the ENGLISH version of the string, because
            //                            the OS culture was getting set from JP to EN when running the JP build... 
            //                            So I replaced with * there should only be one confirmation dialog box up..

            // CoreManager.MomConsole.ConfirmChoiceDialog(true, Strings.ConfirmTaskDelete);
            CoreManager.MomConsole.ConfirmChoiceDialog(true, "*");
            Utilities.LogMessage("Tasks.DeleteTask:: Answer Yes to confirm task deletion");

            // Clear the find bar filter if we have a findbar and it is visible
            if ((findBar != null) && findBar.IsVisible)
            {
                findBar.ClickClear();
            }

            Utilities.LogMessage("DeleteTask:: After Deletion of task: " + taskName);
            Utilities.TakeScreenshot("After deletion of task");
        }

        /// <summary>
        /// Search for task under MP task, return true if found false otherwise
        /// </summary>
        /// <param name="managementPackObj">Management pack object</param>
        /// <param name="taskName">String of the task to search for</param>
        /// <returns>True if the task is found False otherwise</returns>
        public bool SearchForTask(string managementPackObj, string taskName)
        {
            Utilities.LogMessage("SearchForTask...");
            Utilities.LogMessage("SearchForTask:: Task: " + taskName + " under MP: " + managementPackObj);

            // Navigate to monitoring configuration (now Authoring) space of the MOM Console
            // Click on Management Pack
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.SelectNode(
                NavigationPane.Strings.Authoring +
                Constants.PathDelimiter +
                NavigationPane.Strings.MonConfigTreeViewManagementPackObjects +
                Constants.PathDelimiter +
                managementPackObj,
                NavigationPane.NavigationTreeView.Authoring);

            Utilities.LogMessage("Tasks.SearchForTask :: Successfully clicked on Authoring\\Management Pack Objects\\" + managementPackObj);

            // Filter down the grid using the findbar to hunt for the specific task
            MomControls.FindBar findBar = CoreManager.MomConsole.ViewPane.Find;

            // Make sure the findBar is visible and that we have a non null findbar to work with
            if ((findBar != null) && findBar.IsVisible)
            {
                findBar.LookForItem(taskName);
                Utilities.LogMessage("SearchForTask:: Input task into findbar to filter grid control");
                Utilities.TakeScreenshot("SearchForTask after inputing task to filter in find bar");
            }
            else
            {
                Utilities.LogMessage("SearchForTask:: Problem with findbar");
            }


            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

            consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Timeout);

            Utilities.LogMessage("SearchForTask:: After ClickFindNow and WaitForResponse()");
            Utilities.TakeScreenshot("Make sure grid control is narrowed down by Look For String");
            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
            // Find created task in grid
            Maui.Core.WinControls.DataGridViewRow taskRow = CoreManager.MomConsole.ViewPane.Grid.FindData(taskName, 0, GridControl.SearchStringMatchType.ContainsMatch);

            // Clear the search parameters on the console
            if ((findBar != null) && findBar.IsVisible)
            {
                findBar.ClickClear();
            }

            if (taskRow != null)
            {
                Utilities.LogMessage("Tasks.SearchForTask:: Task: " + taskName + " was found");
                return true;
            }
            else
            {
                Utilities.LogMessage("Tasks.SearchForTask:: Task: " + taskName + " was not found");
                return false;
            }
        }

        /// <summary>
        /// Update Task Properties
        /// </summary>
        /// <param name="taskName">Task Name</param>
        /// <param name="fieldTomodify">Field to Modify</param>
        /// <param name="modifyValue">Modify Value</param>
        /// <returns>Task Name for Which We Updated Its Properties</returns>
        /// <history>
        ///		[v-eachu] 09DEC09 Created
        /// </history>
        public string UpdateTaskProperties(string taskName, string[] fieldTomodify, string[] modifyValue)
        {
            Core.Common.Utilities.LogMessage("UpdateTaskProperties:: start ...");

            string createTaskPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                + Constants.PathDelimiter
                + Core.Console.Views.Views.Strings.TasksView;

            CoreManager.MomConsole.BringToForeground();
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            Utilities.LogMessage("UpdateTaskProperties:: " + "MOM console is in the foreground.");


            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

            // Search the View
            Core.Console.MomControls.GridControl taskGrid = null;
            DataGridViewRow row = null;

            // Select Tasks view
            int maxAttempts = 3;
            int attempts = 0;

            // Retry logic: Attempting to search the view pane grid for the task
            while (attempts < maxAttempts && row == null)
            {
                attempts++;
                if (attempts > 1)
                {
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                    taskGrid.SendKeys(Core.Common.KeyboardCodes.F5);
                }

                Utilities.LogMessage("UpdateTaskProperties:: Attempt " + attempts + " searching the view for the task " + taskName);

                //Click Authoring space first, and then click the task node. This is to make sure the "Find Now" in view pane is always visisble. 
                navPane.SelectNode(NavigationPane.Strings.MonitoringConfiguration, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                navPane.SelectNode(createTaskPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                taskGrid = CoreManager.MomConsole.ViewPane.Grid;

                CoreManager.MomConsole.ViewPane.Find.LookForItem(taskName);
                row = taskGrid.FindData(taskName, 0, GridControl.SearchStringMatchType.ExactMatch);
            }

            // If there is no row, we didn't find the task log and throw an exception
            if (row == null)
            {
                CoreManager.MomConsole.ViewPane.Find.ClickClear();
                throw new DataGrid.Exceptions.DataGridRowNotFoundException("UpdateTaskProperties:: Failed to find created Task: " + taskName);
            }
            else
            {
                Maui.Core.WinControls.Menu contextMenu = null;
                bool needRetry = true;
                int tries = 0;
                int maxTries = 5;
                while (tries < maxTries && needRetry)
                {
                    tries++;
                    Utilities.LogMessage("UpdateTaskProperties:: Attempt " + tries);
                    try
                    {
                        taskGrid.ClickCell(row.AccessibleObject.Index, 0, MouseClickType.SingleClick, MouseFlags.RightButton);

                        contextMenu = new Maui.Core.WinControls.Menu();
                        contextMenu.ScreenElement.WaitForReady();
                        needRetry = false;
                    }
                    catch (Maui.Core.WinControls.Menu.Exceptions.ItemNotFoundException ex)
                    {
                        Utilities.LogMessage("UpdateTaskProperties:: Caught ItemNotFoundException: " + ex.Message);

                        //send esc key to cancel context menu in case it shows up after catching this exception
                        CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                        Sleeper.Delay(Constants.OneSecond);
                    }
                }

                Utilities.LogMessage("UpdateTaskProperties:: Selecting context menu item:  'Properties'");

                contextMenu.ExecuteMenuItem(ViewPane.Strings.AdministrationContextMenuProperties);

                Core.Console.Tasks.TaskPropertiesDialog taskPropertiesDialog = new Core.Console.Tasks.TaskPropertiesDialog(CoreManager.MomConsole);
                TabControlTab taskPropertiesDialogTab = null;
                
                taskPropertiesDialog.WaitForResponse();
                for (int i = 0; i < fieldTomodify.Length;i++ )
                {
                    switch (fieldTomodify[i].ToLowerInvariant())
                    {
                        case "targettype":
                            Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + " was read only, cannot update it");
                            break;

                        case "description":
                            taskPropertiesDialog.TaskDescriptionText = modifyValue[i];
                            Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + "has updated to " + modifyValue[i]);
                            break;

                        case "application":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();
                            taskPropertiesDialog.TaskApplicationText = modifyValue[i];
                            Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + "has updated to " + modifyValue[i]);
                            break;

                        case "name":
                            taskPropertiesDialog.TaskNameText = modifyValue[i];
                            taskName = modifyValue[i];
                            Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + "has updated to " + modifyValue[i]);
                            break;

                        case "parameter":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();
                            taskPropertiesDialog.TaskApplicationText = modifyValue[i];
                            Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + "has updated to " + modifyValue[i]);
                            break;

                        case "workingdirectory":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();
                            taskPropertiesDialog.WorkingDirectoryText = modifyValue[i];
                            Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + "has updated to " + modifyValue[i]);
                            break;

                        case "timeout":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();
                            taskPropertiesDialog.TimeOutText = modifyValue[i];
                            Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + "has updated to " + modifyValue[i]);
                            break;

                        case "displayoutput":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();

                            if (modifyValue[i].Equals("true"))
                            {
                                if (taskPropertiesDialog.Controls.DisplayOutputWhenThisTaskIsRunCheckBox.Checked.Equals(false))
                                {
                                    taskPropertiesDialog.Controls.DisplayOutputWhenThisTaskIsRunCheckBox.Click();
                                }
                                Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + "has updated to checked");
                            }
                            else
                            {
                                if (taskPropertiesDialog.Controls.DisplayOutputWhenThisTaskIsRunCheckBox.Checked.Equals(true))
                                {
                                    taskPropertiesDialog.Controls.DisplayOutputWhenThisTaskIsRunCheckBox.Click();
                                }
                                Utilities.LogMessage("UpdateTaskProperties:: " + fieldTomodify[i] + "has updated to unchecked");
                            }
                            break;

                        default:
                            Utilities.LogMessage("UpdateTaskProperties:: No Update");
                            break;
                    }
                }


                taskPropertiesDialog.ClickOK();
                consoleApp.WaitForDialogClose(taskPropertiesDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultViewLoadTimeout);
                CoreManager.MomConsole.ViewPane.Find.ClickClear();

                Utilities.LogMessage("UpdateTaskProperties:: Update Task Properties Successfully");
                return taskName;
            }
        }

        /// <summary>
        /// Verify if Task Properties Got Updated 
        /// </summary>
        /// <param name="taskName">Task Name</param>
        /// <param name="fieldTomodify">Field to Modify</param>
        /// <param name="expectedValue">Expected Value</param>
        /// <returns>return true if updated value equals expected value, else return false</returns>
        /// <history>
        ///		[v-eachu] 09DEC09 Created
        /// </history>
        public bool VerifyUpdateTaskProperties(string taskName, string[] fieldTomodify, string[] expectedValue)
        {
            Core.Common.Utilities.LogMessage("VerifyUpdateTaskProperties:: start ...");

            string createTaskPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                + Constants.PathDelimiter
                + Core.Console.Views.Views.Strings.TasksView;
            string updatedValue = null;
            bool verifyResult = false;
            CoreManager.MomConsole.BringToForeground();
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            Utilities.LogMessage("VerifyUpdateTaskProperties:: " + "MOM console is in the foreground.");


            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();


            // Search the View
            Core.Console.MomControls.GridControl taskGrid = null;
            DataGridViewRow row = null;

            // Select Tasks view
            int maxAttempts = 3;
            int attempts = 0;

            // Retry logic: Attempting to search the view pane grid for the task
            while (attempts < maxAttempts && row == null)
            {
                attempts++;
                if (attempts > 1)
                {
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                    taskGrid.SendKeys(Core.Common.KeyboardCodes.F5);
                }

                Utilities.LogMessage("VerifyUpdateTaskProperties:: Attempt " + attempts + " searching the view for the task " + taskName);

                //Click Authoring space first, and then click the task node. This is to make sure the "Find Now" in view pane is always visisble. 
                navPane.SelectNode(NavigationPane.Strings.MonitoringConfiguration, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                navPane.SelectNode(createTaskPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                taskGrid = CoreManager.MomConsole.ViewPane.Grid;

                CoreManager.MomConsole.ViewPane.Find.LookForItem(taskName);
                row = taskGrid.FindData(taskName, 0, GridControl.SearchStringMatchType.ExactMatch);
            }

            // If there is no row, we didn't find the task log and throw an exception
            if (row == null)
            {
                CoreManager.MomConsole.ViewPane.Find.ClickClear();
                throw new DataGrid.Exceptions.DataGridRowNotFoundException("VerifyUpdateTaskProperties:: Failed to find created Task: " + taskName);
            }
            else
            {
                Maui.Core.WinControls.Menu contextMenu = null;
                bool needRetry = true;
                int tries = 0;
                int maxTries = 5;
                while (tries < maxTries && needRetry)
                {
                    tries++;
                    Utilities.LogMessage("VerifyUpdateTaskProperties:: Attempt " + tries);
                    try
                    {
                        taskGrid.ClickCell(row.AccessibleObject.Index, 0, MouseClickType.SingleClick, MouseFlags.RightButton);
                        Utilities.LogMessage("wait for 3 seconds for context menu");
                        //sleep 3 seconds , workarround for bug 373919 which caused by .net4.5
                        Sleeper.Delay(3000);
                        contextMenu = new Maui.Core.WinControls.Menu();
                        contextMenu.ScreenElement.WaitForReady();

                        Utilities.LogMessage("VerifyUpdateTaskProperties:: Selecting context menu item:  'Properties'");
                        contextMenu.ExecuteMenuItem(ViewPane.Strings.AdministrationContextMenuProperties);

                        needRetry = false;
                    }
                    catch (Maui.Core.WinControls.Menu.Exceptions.ItemNotFoundException ex)
                    {
                        Utilities.LogMessage("VerifyUpdateTaskProperties:: Caught ItemNotFoundException: " + ex.Message);

                        //send esc key to cancel context menu in case it shows up after catching this exception
                        CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                        Sleeper.Delay(Constants.OneSecond);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException e)
                    {
                        Utilities.LogMessage("VerifyUpdateTaskProperties:: Caught ItemNotFoundException: " + e.Message);

                        //send esc key to cancel context menu in case it shows up after catching this exception
                        CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                        Sleeper.Delay(Constants.OneSecond);
                    }
                }

                Core.Console.Tasks.TaskPropertiesDialog taskPropertiesDialog = new Core.Console.Tasks.TaskPropertiesDialog(CoreManager.MomConsole);
                TabControlTab taskPropertiesDialogTab = null;
                
                taskPropertiesDialog.WaitForResponse();
                for (int i = 0; i < fieldTomodify.Length; i++)
                {
                    switch (fieldTomodify[i].ToLowerInvariant())
                    {
                        case "targettype":
                            if (taskPropertiesDialog.Controls.SelectButton.IsEnabled)
                            {
                                Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            }
                            else
                            {
                                updatedValue = taskPropertiesDialog.TaskTargetText;
                                Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            }

                            break;

                        case "description":
                            updatedValue = taskPropertiesDialog.TaskDescriptionText;
                            Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            break;

                        case "application":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();
                            updatedValue = taskPropertiesDialog.TaskApplicationText;
                            Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            break;

                        case "name":
                            updatedValue = taskPropertiesDialog.TaskNameText;
                            Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            break;

                        case "parameter":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();
                            updatedValue = taskPropertiesDialog.TaskApplicationText;
                            Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            break;

                        case "workingdirectory":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();
                            updatedValue = taskPropertiesDialog.WorkingDirectoryText;
                            Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            break;

                        case "timeout":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();
                            updatedValue = taskPropertiesDialog.TimeOutText;
                            Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            break;

                        case "displayoutput":
                            taskPropertiesDialogTab = new TabControlTab(taskPropertiesDialog.Controls.Tab0TabControl, Core.Console.Tasks.Wizards.TaskNameDialog.Strings.CommandLine);
                            taskPropertiesDialog.Controls.Tab0TabControl.Tabs[taskPropertiesDialogTab.Index].Click();

                            if (taskPropertiesDialog.Controls.DisplayOutputWhenThisTaskIsRunCheckBox.Checked.Equals(false))
                            {
                                updatedValue = "false";
                            }
                            else
                            {
                                updatedValue = "true";
                            }

                            Utilities.LogMessage("VerifyUpdateTaskProperties:: updatedValue: " + updatedValue);
                            break;

                        default:
                            Utilities.LogMessage("VerifyUpdateTaskProperties:: No Verify");
                            break;
                    }
                    if (!updatedValue.Equals(expectedValue[i]))
                    {
                        Utilities.LogMessage("VerifyUpdateTaskProperties:: Verify Update Task Properties Failed");
                        Utilities.LogMessage("VerifyUpdateTaskProperties:: Expected Value: " + expectedValue[i]);
                        Utilities.LogMessage("VerifyUpdateTaskProperties:: Updated Value: " + updatedValue);
                        verifyResult = false;
                        break;
                    }
                    else
                    {
                        Utilities.LogMessage("VerifyUpdateTaskProperties:: expectedValue: " + expectedValue[i] + " equal updatedValue: " + updatedValue);
                        verifyResult = true;
                        continue;
                    }
                }

                taskPropertiesDialog.ClickOK();
                consoleApp.WaitForDialogClose(taskPropertiesDialog, Constants.OneMinute / Constants.OneSecond);
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Timeout);
            }

            CoreManager.MomConsole.ViewPane.Find.ClickClear();

            return verifyResult;
        }
        #endregion

        /// <summary>
        /// Task parameters structure.
        /// </summary>
        /// <param name="parameters">TaskParameters</param>
        /// <returns>Parameters</returns>
        /// <history>
        ///		[faizal] 19OCT05 Created
        /// </history>
        private static CommandTaskParameters UpdateParameters(CommandTaskParameters parameters)
        {
            Utilities.LogMessage("Task.UpdateParameters:: ");
            return parameters;
        }

        #region Private Methods
        // NOTE: This method isn't used anywhere
        /// <summary>
        /// Helper Compare method, that compares two ArrayLists containing string objects
        /// </summary>
        /// <param name="first">first ArrayList containing String objects to compare</param>
        /// <param name="second">second ArrayList containing String objects to compare</param>
        /// <returns>boolean True if both ArrayList contain the same Strings, false otherwise</returns>
        private bool CompareArrayList(ArrayList first, ArrayList second)
        {
            // Have to make sure the list is sorted for the binary search to function
            first.Sort();
            second.Sort();

            // Check that the headers visible, match the selections made in the Columns to Display
            foreach (string strCompare in first)
            {
                int index = second.BinarySearch(strCompare);
                if (index >= 0)
                {
                    second.RemoveAt(index);
                }
                else
                {
                    // Problem the columns are not matching the users selections
                    return false;
                }
            }

            if (second.Count != 0)
            {
                // Problem the columns are not matching the users selections
                return false;
            }

            return true;
        }

        #region Verify Task Created
        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to verify that the created tasks exists in the Tasks View
        /// </summary>
        /// <param name="taskPath">path to look for task</param>
        /// <param name="taskName">Name of task to look for</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">
        /// if task row is not found
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException">
        /// if task cell is not found or does not match</exception>
        /// ------------------------------------------------------------------
        private void VerifyTaskCreated(string taskPath, string taskName)
        {
            Core.Common.Utilities.LogMessage("VerifyTaskCreated...");

            // if the MOM console is the top window all went well
            if (CoreManager.MomConsole.MainWindow.Extended.IsForeground)
            {
                NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
                Utilities.LogMessage("Tasks.VerifyTaskCreated :: " + "MOM console is in the foreground.");
                Utilities.TakeScreenshot("Tasks.VerifyTaskCreated_MomConsolePresent");
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();


                // Search the View
                Core.Console.MomControls.GridControl taskGrid = null;
                DataGridViewRow row = null;

                // Select Tasks view
                int maxAttempts = 3;
                int attempts = 0;

                // Retry logic: Attempting to search the view pane grid for the task
                while (attempts < maxAttempts && row == null)
                {
                    attempts++;
                    if (attempts > 1)
                    {
                        Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                        taskGrid.SendKeys(Core.Common.KeyboardCodes.F5);
                    }

                    Utilities.TakeScreenshot("Tasks.VerifyTaskCreated Attempt " + attempts);
                    Utilities.LogMessage("Tasks.VerifyTaskCreated :: Attempt " + attempts + " searching the view for the task " + taskName);

                    //Click Authoring space first, and then click the task node. This is to make sure the "Find Now" in view pane is always visisble. 
                    navPane.SelectNode(NavigationPane.Strings.MonitoringConfiguration, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                    navPane.SelectNode(taskPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);

                    UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 30000);
                    UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 30000);
                    
                    taskGrid = CoreManager.MomConsole.ViewPane.Grid;
                    
                    //Record the original Grid rows count before clicking FindNow button
                    int originalGridRowCount = taskGrid.Rows.Count;
                    int maxTries = 10;
                    // Use FindBar to reduce searching.
                    CoreManager.MomConsole.ViewPane.Find.LookForItem(taskName);
                    for (int i = 0; i < maxTries; i++)
                    {
                        if (originalGridRowCount == taskGrid.Rows.Count)
                        {
                            Utilities.LogMessage("Tasks.VerifyTaskCreated :: Grid rows count not changed, count is " + taskGrid.Rows.Count +
                                "Wait one second and check again.");
                            Sleeper.Delay(Constants.OneSecond);
                        }
                        else
                        {
                            Utilities.LogMessage("Tasks.VerifyTaskCreated :: Grid rows count changed, count is " + taskGrid.Rows.Count);
                            break;
                        }
                    }

                    row = taskGrid.FindData(taskName, 0, GridControl.SearchStringMatchType.ExactMatch);
                }

                // If there is no row, we didn't find the task log and throw an exception
                if (row == null)
                {
                    CoreManager.MomConsole.ViewPane.Find.ClickClear();
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("Tasks.VerifyTaskCreated:: Failed to find created Task: " + taskName);
                }
                else
                {
                    int maxRetry = 2;
                    for (int i = 0; i < maxRetry; i++)
                    {
                        try
                        {
                            taskGrid.ClickCell(row.AccessibleObject.Index, 0);
                            break;
                        }
                        catch (Exception)
                        {
                            Core.Common.Utilities.LogMessage(
                                "Tasks.VerifyTaskCreated:: Attempt " + (i + 1) + " of " + maxRetry);
                        }
                    }
                    CoreManager.MomConsole.ViewPane.Find.ClickClear();
                }
            }

            // TODO: later use something like this to open properties dialog
            // CoreManager.MomConsole.ViewPane.Grid.Click(MouseClickType.SingleClick, MouseFlags.RightButton);
            // right now the properties dialog is not completely implemented yet so we'll hold off for now
        }
        #endregion //Verify Task Created

        #region Verify Task Ran
        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to verify that the launched task ran in the Task Status View
        /// </summary>
        /// <param name="taskName">Name of task to look for</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">
        /// if task row is not found
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException">
        /// if task cell is not found or does not match</exception>
        /// ------------------------------------------------------------------
        private void VerifyTaskRan(string taskName)
        {
            Core.Common.Utilities.LogMessage("VerifyTaskRan...");

            // if the MOM console is the top window all went well
            if (CoreManager.MomConsole.MainWindow.Extended.IsForeground)
            {
                NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
                Utilities.LogMessage("Tasks.VerifyTaskRan :: " + "MOM console is in the foreground.");
                Utilities.TakeScreenshot("Tasks.VerifyTaskRan_MomConsolePresent");
                Utilities.LogMessage("Tasks.VerifyTaskRan :: " + "searching the view for the Task");

                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                Core.Console.MomControls.GridControl taskGrid = null;
                DataGridViewRow row = null;
                int retry = 0;
                int maxcount = 1000;

                // Retry logic, searching view for the task
                while (taskGrid == null && retry <= maxcount)
                {
                    try
                    {
                        string taskStatusPath = NavigationPane.Strings.Monitoring
                            + Constants.PathDelimiter
                            + Constants.UITestViewFolder
                            + Constants.PathDelimiter
                            + Core.Console.Views.Views.Strings.TaskStatusView;

                        // Select Tasks view
                        navPane.SelectNode(taskStatusPath, NavigationPane.NavigationTreeView.Monitoring);
                        taskGrid = CoreManager.MomConsole.ViewPane.Grid;
                        row = taskGrid.FindData(taskName, 1);
                        if (row == null)
                        {
                            // We'll try again
                            taskGrid = null;
                        }
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Tasks.VerifyTaskCreated:: Failed to get reference to ViewPane.Grid, lets navigate and try again.");
                        Utilities.TakeScreenshot("Tasks.VerifyTaskCreated_GridView_NotFound");
                    }
                    catch (System.NullReferenceException)
                    {
                        Utilities.LogMessage("Tasks.VerifyTaskCreated:: Got a null reference, lets try again.");
                        Utilities.TakeScreenshot("Tasks.VerifyTaskCreated_NullExpection");
                    }

                    retry++;
                }

                if (row != null)
                {
                    taskGrid.ClickCell(row.AccessibleObject.Index, 0);
                }
                else
                {
                    throw new DataGrid.Exceptions.DataGridRowNotFoundException("Tasks.VerifyTaskCreated:: Failed to find created Task: " + taskName);
                }
            }

            // TODO: later use something like this to open properties dialog
            // CoreManager.MomConsole.ViewPane.Grid.Click(MouseClickType.SingleClick, MouseFlags.RightButton);
        }
        #endregion //Verify Task Ran

        #endregion

        #region Strings
        /// <summary>
        /// Strings Class
        /// </summary>
        public class Strings
        {
            #region Constants
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for agent task failed to submit
            /// <history>
            /// [v-tfeng] 24NOV11 add this
            /// </history>
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentTaskFailedToSubmit = ";Failed to submit tasks.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;submitFailed";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for agent task completed
            /// <history>
            /// [jefftow] 17DEC07 updated this, the success string was either incorrect or changed in recent builds
            /// </history>
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentTaskCompleted = ";The task completed successfully.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;successOutput";

            // private const string ResourceAgentTaskCompleted = ";All tasks completed.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;tasksCompleted";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for agent task failed to run
            /// <history>
            /// [v-yoz] 23JULY09 Added
            /// </history>
            /// </summary>
            private const string ResourceAgentTaskFailedToRun = ";The task failed to run.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;failedOutput";            

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the console task completed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConsoleTaskCompleted = ";The task was completed.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;consoleTaskCompleted";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Confirm Task Delete" dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmTaskDelete = ";Confirm Task Delete;ManagedString;Microsoft.EnterpCriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.TasksView.TasksViewResources;ConfirmTaskDelete";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for task timeout to run
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskNoOutputAvailable = ";No output available.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;noOutput";


            #region TaskView Columns Resource Strings

            /// <summary>
            /// Contains the resource string for the column "Task Name" in the Task Status view
            /// </summary>
            //private const string ResourceColumnTaskName = ";Task Name;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTaskName";
            private const string ResourceColumnTaskName = ";Task Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTaskName";

            /// <summary>
            /// Contains the resource string for the column "Status" in the Task Status view
            /// </summary>
            //private const string ResourceColumnStatus = ";Status;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnStatus";
            private const string ResourceColumnStatus = ";Status;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnStatus";


            /// <summary>
            /// Contains the resource string for the column "Category" in the Task Status view
            /// </summary>
            private const string ResourceColumnCategory = ";Category;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnCategory";

            /// <summary>
            /// Contains the resource string for the column "Start Time" in the Task Status view
            /// </summary>
            //private const string ResourceColumnStartTime = ";Start Time;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnStartTime";
            private const string ResourceColumnStartTime = ";Start Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnStartTime";


            /// <summary>
            /// Contains the resource string for the column "Task Target" in the Task Status view
            /// </summary>
            private const string ResourceColumnTaskTarget = ";Task Target;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTargetID";

            /// <summary>
            /// Contains the resource string for the column "Submited By" in the Task Status view
            /// </summary>
            private const string ResourceColumnSubmitedBy = ";Submitted By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnSubmittedBy";

            /// <summary>
            /// Contains the resource string for the column "Schedule Time" in the Task Status view
            /// </summary>
            private const string ResourceColumnScheduleTime = ";Schedule Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnScheduleTime";

            /// <summary>
            /// Contains the resource string for the column "Run As" in the Task Status view
            /// </summary>
            private const string ResourceColumnRunAs = ";Run As;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnRunAs";

            /// <summary>
            /// Contains the resource string for the column "Run Location" in the Task Status view
            /// </summary>
            private const string ResourceColumnRunLocation = ";Run Location;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnRunLocation";

            /// <summary>
            /// Contains the resource string for the column "Task Target Class" in the Task Status view
            /// </summary>
            private const string ResourceColumnTaskTargetClass = ";Task Target Class;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTargetedType";

            /// <summary>
            /// Contains the resource string for the column "Task Description" in the Task Status view
            /// </summary>
            private const string ResourceColumnTaskDescription = ";Task Description;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTaskDescription";

            /// <summary>
            /// Contains the resource string for the column "Completed Time" in the Task Status view
            /// </summary>
            private const string ResourceColumnCompletedTime = ";Completed Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTimeFinished";

            /// <summary>
            /// Contains the resource string for the column "Last Modified Time" in the Task Status view
            /// </summary>
            private const string ResourceColumnLastModifiedTime = ";Last Modified Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnLastModified";

            private const string ResourceStateActionsPane = ";Navigation;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.ComponentResources;NavigationTasksTaskGroupDisplayName";

            #endregion

            #region Action pane task resource strings
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Alert Tasks" in Action Pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertTasksActionPane = ";Alert Tasks;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.ComponentResources;AlertTasksGroupDisplayName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Event Tasks" in Action Pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventTasksActionPane = ";Event Tasks;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.ComponentResources;EventTasksGroupDisplayName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Tasks" in Action Pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTasksActionPane = ";{0} Tasks;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Components.dll;Microsoft.EnterpriseManagement.Monitoring.Components.ComponentResources;EntityTasksGroupDisplayNameFormat";

            #endregion

            #region Alert/Event Command line task parameter Resource string

            /// <summary>
            /// Contains the resource string for the parameter "Time Raised" in the Task Properties
            /// </summary>
            private const string ResourceTimeRaisedParameter = ";Time Raised;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;AlertTimeRaised";

            /// <summary>
            /// Contains the resource string for the parameter "Number" in the Task Properties
            /// </summary>
            private const string ResourceNumberParameter = ";Number;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;EventNumber";

            /// <summary>
            /// Contains the resource string for the parameter "Resolution State" in the Task Properties
            /// </summary>
            private const string ResourceResolutionStateParameter = ";Resolution State;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;AlertResolutionState";

            #endregion

            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the status label
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentTaskFailedToSubmit; 

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the status label
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentTaskCompleted;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the status label
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentTaskFailedToRun;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the status label
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConsoleTaskCompleted;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for the confirm task delete dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResourceConfirmTaskDelete;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the status label
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResourceTaskNoOutputAvailable;

            #region cached Column Name Resource strings

            /// <summary>
            /// Contains the cached resource string for the column "Task Name" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnTaskName;

            /// <summary>
            /// Contains the cached resource string for the column "Status" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnStatus;

            /// <summary>
            /// Contains the cached resource string for the column "Category" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnCategory;

            /// <summary>
            /// Contains the cached resource string for the column "Start Time" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnStartTime;

            /// <summary>
            /// Contains the cached resource string for the column "Task Target" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnTaskTarget;

            /// <summary>
            /// Contains the cached resource string for the column "Submited By" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnSubmitedBy;

            /// <summary>
            /// Contains the cached resource string for the column "Schedule Time" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnScheduleTime;

            /// <summary>
            /// Contains the cached resource string for the column "Run As" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnRunAs;

            /// <summary>
            /// Contains the cached resource string for the column "Run Location" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnRunLocation;

            /// <summary>
            /// Contains the cached resource string for the column "Task Target Class" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnTaskTargetClass;

            /// <summary>
            /// Contains the cached resource string for the column "Task Description" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnTaskDescription;

            /// <summary>
            /// Contains the cached resource string for the column "Completed Time" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnCompletedTime;

            /// <summary>
            /// Contains the cached resource string for the column "Last Modified Time" in the Task Status view
            /// </summary>
            private static string cachedResourceColumnLastModifiedTime;

            private static string cachedResourceResourceStateActionsPane;

            #endregion

            #region cached Action pane task resource strings
            /// <summary>
            /// Caches the translated resource string for "Alert Tasks" in Action Pane
            /// </summary>
            private static string cachedResourceAlertTasksActionPane;

            /// <summary>
            /// Caches the translated resource string for "Event Tasks" in Action Pane
            /// </summary>
            private static string cachedResourceEventTasksActionPane;

            /// <summary>
            /// Caches the translated resource string for "Tasks" in Action Pane
            /// </summary>
            private static string cachedResourceTasksActionPane;

            #endregion

            #region cached Alert/Event Command line task parameter Resource string
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Time Raised
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeRaisedParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Number
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNumberParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Resolution State
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolutionStateParameter;

            #endregion
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the status label resource string
            /// </summary>
            /// <history>
            /// 	[v-tfeng] 24NOV11 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentTaskFailedToSubmit
            {
                get 
                {
                    if (cachedAgentTaskFailedToSubmit == null)
                    {
                        cachedAgentTaskFailedToSubmit = CoreManager.MomConsole.GetIntlStr(ResourceAgentTaskFailedToSubmit);
                    }

                    return cachedAgentTaskFailedToSubmit;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the status label resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 28APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentTaskCompleted
            {
                get
                {
                    if ((cachedAgentTaskCompleted == null))
                    {
                        cachedAgentTaskCompleted = CoreManager.MomConsole.GetIntlStr(ResourceAgentTaskCompleted);
                    }

                    return cachedAgentTaskCompleted;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the status label resource string
            /// </summary>
            /// <history>
            /// 	[v-yoz] 23JULY09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentTaskFailedToRun
            {
                get
                {
                    if ((cachedAgentTaskFailedToRun == null))
                    {
                        cachedAgentTaskFailedToRun = CoreManager.MomConsole.GetIntlStr(ResourceAgentTaskFailedToRun);
                    }

                    return cachedAgentTaskFailedToRun;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the status label resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 28APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsoleTaskCompleted
            {
                get
                {
                    if ((cachedConsoleTaskCompleted == null))
                    {
                        cachedConsoleTaskCompleted = CoreManager.MomConsole.GetIntlStr(ResourceConsoleTaskCompleted);
                    }

                    return cachedConsoleTaskCompleted;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Confirm Task Delete dialog title resource string
            /// </summary>
            /// <history>
            /// 	[jefftow] 10NOV07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmTaskDelete
            {
                get
                {
                    if ((cachedResourceConfirmTaskDelete == null))
                    {
                        cachedResourceConfirmTaskDelete = CoreManager.MomConsole.GetIntlStr(ResourceConfirmTaskDelete);
                    }

                    return cachedResourceConfirmTaskDelete;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Task timeout output : no output available
            /// </summary>
            /// <history>
            /// 	[v-yoz] 11AUG09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskNoOutputAvailable
            {
                get
                {
                    if ((cachedResourceTaskNoOutputAvailable == null))
                    {
                        cachedResourceTaskNoOutputAvailable = CoreManager.MomConsole.GetIntlStr(ResourceTaskNoOutputAvailable);
                    }

                    return cachedResourceTaskNoOutputAvailable;
                }
            }

            #region Task View Column Properties

            /// <summary>
            /// Exposes access to the Column "Task Name" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnTaskName
            {
                get
                {
                    if ((cachedResourceColumnTaskName == null))
                    {
                        cachedResourceColumnTaskName = CoreManager.MomConsole.GetIntlStr(ResourceColumnTaskName);
                    }

                    return cachedResourceColumnTaskName;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Status" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnStatus
            {
                get
                {
                    if (cachedResourceColumnStatus == null)
                    {
                        cachedResourceColumnStatus = CoreManager.MomConsole.GetIntlStr(ResourceColumnStatus);
                    }

                    return cachedResourceColumnStatus;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Category" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnCategory
            {
                get
                {
                    if ((cachedResourceColumnCategory == null))
                    {
                        cachedResourceColumnCategory = CoreManager.MomConsole.GetIntlStr(ResourceColumnCategory);
                    }

                    return cachedResourceColumnCategory;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Start Time" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnStartTime
            {
                get
                {
                    if ((cachedResourceColumnStartTime == null))
                    {
                        cachedResourceColumnStartTime = CoreManager.MomConsole.GetIntlStr(ResourceColumnStartTime);
                    }

                    return cachedResourceColumnStartTime;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Task Target" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnTaskTarget
            {
                get
                {
                    if ((cachedResourceColumnTaskTarget == null))
                    {
                        cachedResourceColumnTaskTarget = CoreManager.MomConsole.GetIntlStr(ResourceColumnTaskTarget);
                    }

                    return cachedResourceColumnTaskTarget;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Submited By" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnSubmitedBy
            {
                get
                {
                    if ((cachedResourceColumnSubmitedBy == null))
                    {
                        cachedResourceColumnSubmitedBy = CoreManager.MomConsole.GetIntlStr(ResourceColumnSubmitedBy);
                    }

                    return cachedResourceColumnSubmitedBy;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Schedule Time" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnScheduleTime
            {
                get
                {
                    if ((cachedResourceColumnScheduleTime == null))
                    {
                        cachedResourceColumnScheduleTime = CoreManager.MomConsole.GetIntlStr(ResourceColumnScheduleTime);
                    }

                    return cachedResourceColumnScheduleTime;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Run As" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnRunAs
            {
                get
                {
                    if ((cachedResourceColumnRunAs == null))
                    {
                        cachedResourceColumnRunAs = CoreManager.MomConsole.GetIntlStr(ResourceColumnRunAs);
                    }

                    return cachedResourceColumnRunAs;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Run Location" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnRunLocation
            {
                get
                {
                    if ((cachedResourceColumnRunLocation == null))
                    {
                        cachedResourceColumnRunLocation = CoreManager.MomConsole.GetIntlStr(ResourceColumnRunLocation);
                    }

                    return cachedResourceColumnRunLocation;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Target Class" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnTaskTargetClass
            {
                get
                {
                    if ((cachedResourceColumnTaskTargetClass == null))
                    {
                        cachedResourceColumnTaskTargetClass = CoreManager.MomConsole.GetIntlStr(ResourceColumnTaskTargetClass);
                    }

                    return cachedResourceColumnTaskTargetClass;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Task Description" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnTaskDescription
            {
                get
                {
                    if ((cachedResourceColumnTaskDescription == null))
                    {
                        cachedResourceColumnTaskDescription = CoreManager.MomConsole.GetIntlStr(ResourceColumnTaskDescription);
                    }

                    return cachedResourceColumnTaskDescription;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Completed Time" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnCompletedTime
            {
                get
                {
                    if ((cachedResourceColumnCompletedTime == null))
                    {
                        cachedResourceColumnCompletedTime = CoreManager.MomConsole.GetIntlStr(ResourceColumnCompletedTime);
                    }

                    return cachedResourceColumnCompletedTime;
                }
            }

            /// <summary>
            /// Exposes access to the Column "Modified Time" resource string
            /// </summary>
            /// <history>
            ///     [jefftow] 10NOV07 Created
            /// </history>
            public static string ColumnLastModifiedTime
            {
                get
                {
                    if ((cachedResourceColumnLastModifiedTime == null))
                    {
                        cachedResourceColumnLastModifiedTime = CoreManager.MomConsole.GetIntlStr(ResourceColumnLastModifiedTime);
                    }

                    return cachedResourceColumnLastModifiedTime;
                }
            }

            public static string NavigationActionsPane
            {
                get
                {
                    if (cachedResourceResourceStateActionsPane==null)
                    {
                        cachedResourceResourceStateActionsPane = CoreManager.MomConsole.GetIntlStr(ResourceStateActionsPane);
                    }
                    return cachedResourceResourceStateActionsPane;
                }
            }
            #endregion

            #region Action pane task resource string properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Alert Tasks resource string in the action pane
            /// </summary>
            /// <history>
            /// 	[v-yoz] 22JULY09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertTasksActionPane
            {
                get
                {
                    if ((cachedResourceAlertTasksActionPane == null))
                    {
                        cachedResourceAlertTasksActionPane = CoreManager.MomConsole.GetIntlStr(ResourceAlertTasksActionPane);
                    }

                    return cachedResourceAlertTasksActionPane;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Event Tasks resource string in the action pane
            /// </summary>
            /// <history>
            /// 	[v-yoz] 22JULY09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventTasksActionPane
            {
                get
                {
                    if ((cachedResourceEventTasksActionPane == null))
                    {
                        cachedResourceEventTasksActionPane = CoreManager.MomConsole.GetIntlStr(ResourceEventTasksActionPane);
                    }

                    return cachedResourceEventTasksActionPane;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Tasks resource string in the action pane
            /// </summary>
            /// <history>
            /// 	[v-yoz] 22JULY09 Created
            ///     [a-joelj] 25AUG09 Fixed Tasks resource string
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TasksActionPane
            {
                get
                {
                    if ((cachedResourceTasksActionPane == null))
                    {
                        cachedResourceTasksActionPane = CoreManager.MomConsole.GetIntlStr(ResourceTasksActionPane);
                    }

                    // Remove Argument from this string for Actions Pane
                    string removeArg = String.Copy(cachedResourceTasksActionPane);
                    cachedResourceTasksActionPane = removeArg.Replace("{0} ", "");

                    return cachedResourceTasksActionPane;
                }
            }
            #endregion

            #region Alert/Event Command line task parameter Resource string properties

            /// <summary>
            /// Exposes access to the parameter "Time Raised" resource string
            /// </summary>
            /// <history>
            ///     [v-yoz] 07AUG09 Created
            /// </history>
            public static string TimeRaisedParameter
            {
                get
                {
                    if ((cachedTimeRaisedParameter == null))
                    {
                        cachedTimeRaisedParameter = CoreManager.MomConsole.GetIntlStr(ResourceTimeRaisedParameter);
                    }

                    return cachedTimeRaisedParameter;
                }
            }

            /// <summary>
            /// Exposes access to the parameter "Number" resource string
            /// </summary>
            /// <history>
            ///     [v-yoz] 07AUG09 Created
            /// </history>
            public static string NumberParameter
            {
                get
                {
                    if ((cachedNumberParameter == null))
                    {
                        cachedNumberParameter = CoreManager.MomConsole.GetIntlStr(ResourceNumberParameter);
                    }

                    return cachedNumberParameter;
                }
            }

            /// <summary>
            /// Exposes access to the parameter "Resolution State" resource string
            /// </summary>
            /// <history>
            ///     [v-yoz] 07AUG09 Created
            /// </history>
            public static string ResolutionStateParameter
            {
                get
                {
                    if ((cachedResolutionStateParameter == null))
                    {
                        cachedResolutionStateParameter = CoreManager.MomConsole.GetIntlStr(ResourceResolutionStateParameter);
                    }

                    return cachedResolutionStateParameter;
                }
            }
            #endregion

            #endregion
        }
        #endregion

        #region CommandTaskParameters Class
        /// <summary>
        /// Parameters class for CreateTask constructors.
        /// </summary>
        /// <history>
        /// [faizalk] 19OCT05 Created
        /// [faizalk] 16MAR06 Updated to use
        /// </history>
        public class CommandTaskParameters
        {
            #region Private Members
            /// <summary>
            /// Cached Destination MP for tasks
            /// </summary>
            private string cachedDestinationMP;

            /// <summary>
            /// Cached name of task to create
            /// </summary>
            private string cachedName = null;

            /// <summary>
            /// Cached task description
            /// </summary>
            private string cachedDescription = null;

            /// <summary>
            /// Cached task target entity
            /// </summary>
            private string cachedTargetEntity = null;

            /// <summary>
            /// Cache enabled
            /// </summary>
            private bool cachedEnabled = true;

            /// <summary>
            /// Command line task type
            /// </summary>
            private Tasks.CommandLineTaskType cachedType;

            /// <summary>
            /// Cache command
            /// </summary>
            private string cachedCommand = null;

            /// <summary>
            /// Cached parameters
            /// </summary>
            private string cachedParameters = null;

            /// <summary>
            /// Cached working directory
            /// </summary>
            private string cachedWorkingDirectory = null;

            /// <summary>
            /// Cached Display output
            /// </summary>
            private bool cachedDisplayOutput = false;

            /// <summary>
            /// Cached timeout
            /// </summary>
            private string cachedTimeout = null;
            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor
            /// </summary>
            public CommandTaskParameters()
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// Destination MP for Task
            /// </summary>
            public string DestinationMP
            {
                get
                {
                    return this.cachedDestinationMP;
                }

                set
                {
                    this.cachedDestinationMP = value;
                }
            }

            /// <summary>
            /// Name of Task to create
            /// </summary>
            public string Name
            {
                get
                {
                    return this.cachedName;
                }

                set
                {
                    this.cachedName = value;
                }
            }

            /// <summary>
            /// Description of Task to create
            /// </summary>
            public string Description
            {
                get
                {
                    return this.cachedDescription;
                }

                set
                {
                    this.cachedDescription = value;
                }
            }

            /// <summary>
            /// Target Entity of Task to create
            /// </summary>
            public string TargetEntity
            {
                get
                {
                    return this.cachedTargetEntity;
                }

                set
                {
                    this.cachedTargetEntity = value;
                }
            }

            /// <summary>
            /// Enabled/Disabled Task to create
            /// </summary>
            public bool Enabled
            {
                get
                {
                    return this.cachedEnabled;
                }

                set
                {
                    this.cachedEnabled = value;
                }
            }

            /// <summary>
            /// CommandLine Task Type to create
            /// </summary>
            public Tasks.CommandLineTaskType Type
            {
                get
                {
                    return this.cachedType;
                }

                set
                {
                    this.cachedType = value;
                }
            }

            /// <summary>
            /// Command of Task to create
            /// </summary>
            public string Command
            {
                get
                {
                    return this.cachedCommand;
                }

                set
                {
                    this.cachedCommand = value;
                }
            }

            /// <summary>
            /// Parameters of Task to create
            /// </summary>
            public string Parameters
            {
                get
                {
                    return this.cachedParameters;
                }

                set
                {
                    this.cachedParameters = value;
                }
            }

            /// <summary>
            /// Working Directory of Task to create
            /// </summary>
            public string WorkingDirectory
            {
                get
                {
                    return this.cachedWorkingDirectory;
                }

                set
                {
                    this.cachedWorkingDirectory = value;
                }
            }

            /// <summary>
            /// Whether to display output
            /// </summary>
            public bool DisplayOutput
            {
                get
                {
                    return this.cachedDisplayOutput;
                }

                set
                {
                    this.cachedDisplayOutput = value;
                }
            }

            /// <summary>
            /// Timeout of Task to create
            /// </summary>
            public string Timeout
            {
                get
                {
                    return this.cachedTimeout;
                }

                set
                {
                    this.cachedTimeout = value;
                }
            }

            #endregion
        }
        #endregion

        #region ConsoleTaskParameters Class
        /// <summary>
        /// Parameters class for CreateConsoleTask constructors.
        /// </summary>
        /// <history>
        /// [faizalk] 27APR06 Created
        /// </history>
        public class ConsoleTaskParameters
        {
            #region Private Members

            /// <summary>
            /// Cached Destination MP
            /// </summary>
            private string cachedDestinationMP;

            /// <summary>
            /// Cached name
            /// </summary>
            private string cachedName = null;

            /// <summary>
            /// Cached Description
            /// </summary>
            private string cachedDescription = null;

            /// <summary>
            /// Cached target entity
            /// </summary>
            private string cachedTargetEntity = null;

            /// <summary>
            /// Cache enabled
            /// </summary>
            private bool cachedEnabled = true;

            /// <summary>
            /// Cached Application
            /// </summary>
            private string cachedApplication = null;

            /// <summary>
            /// Cached parameters
            /// </summary>
            private string cachedParameters = null;

            /// <summary>
            /// Cached working directory
            /// </summary>
            private string cachedWorkingDirectory = null;

            /// <summary>
            /// Cached display output
            /// </summary>
            private bool cachedDisplayOutput = false;
            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor
            /// </summary>
            public ConsoleTaskParameters()
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// Destination MP for Task
            /// </summary>
            public string DestinationMP
            {
                get
                {
                    return this.cachedDestinationMP;
                }

                set
                {
                    this.cachedDestinationMP = value;
                }
            }

            /// <summary>
            /// Name of Task to create
            /// </summary>
            public string Name
            {
                get
                {
                    return this.cachedName;
                }

                set
                {
                    this.cachedName = value;
                }
            }

            /// <summary>
            /// Description of Task to create
            /// </summary>
            public string Description
            {
                get
                {
                    return this.cachedDescription;
                }

                set
                {
                    this.cachedDescription = value;
                }
            }

            /// <summary>
            /// Target Entity of Task to create
            /// </summary>
            public string TargetEntity
            {
                get
                {
                    return this.cachedTargetEntity;
                }

                set
                {
                    this.cachedTargetEntity = value;
                }
            }

            /// <summary>
            /// Enabled/Disabled Task to create
            /// </summary>
            public bool Enabled
            {
                get
                {
                    return this.cachedEnabled;
                }

                set
                {
                    this.cachedEnabled = value;
                }
            }

            /// <summary>
            /// Application Task to create
            /// </summary>
            public string Application
            {
                get
                {
                    return this.cachedApplication;
                }

                set
                {
                    this.cachedApplication = value;
                }
            }

            /// <summary>
            /// Parameters to create
            /// </summary>
            public string Parameters
            {
                get
                {
                    return this.cachedParameters;
                }

                set
                {
                    this.cachedParameters = value;
                }
            }

            /// <summary>
            /// Working Directory to create
            /// </summary>
            public string WorkingDirectory
            {
                get
                {
                    return this.cachedWorkingDirectory;
                }

                set
                {
                    this.cachedWorkingDirectory = value;
                }
            }

            /// <summary>
            /// Whether to Display Output
            /// </summary>
            public bool DisplayOutput
            {
                get
                {
                    return this.cachedDisplayOutput;
                }

                set
                {
                    this.cachedDisplayOutput = value;
                }
            }
            #endregion
        }
        #endregion

        #region ScriptTaskParameters Class
        /// <summary>
        /// Parameters class for ScriptTask constructors.
        /// </summary>
        /// <history>
        /// [faizalk] 29APR06 Created
        /// </history>
        public class ScriptTaskParameters
        {
            #region Private Members

            /// <summary>
            /// Cached destination MP
            /// </summary>
            private string cachedDestinationMP;

            /// <summary>
            /// Cached Name
            /// </summary>
            private string cachedName = null;

            /// <summary>
            /// Cached Description
            /// </summary>
            private string cachedDescription = null;

            /// <summary>
            /// Cached target entity
            /// </summary>
            private string cachedTargetEntity = null;

            /// <summary>
            /// Cached enabled
            /// </summary>
            private bool cachedEnabled = true;

            /// <summary>
            ///  Cached script name
            /// </summary>
            private string cachedScriptName = null;

            /// <summary>
            /// Cached script timeout
            /// </summary>
            private string cachedTimeout = null;

            /// <summary>
            /// cached timeout unit
            /// </summary>
            private Tasks.TimeoutUnit cachedTimeoutUnit;

            /// <summary>
            /// Cached script text
            /// </summary>
            private string cachedScriptText = null;

            /// <summary>
            /// Cached scripyt type
            /// </summary>
            private Tasks.ScriptType cachedScriptType;

            /// <summary>
            /// Cached use editor
            /// </summary>
            private bool cachedUseEditor = false;

            /// <summary>
            /// Cached parameters
            /// </summary>
            private string cachedParameters = null;

            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor
            /// </summary>
            public ScriptTaskParameters()
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// Destination MP for Task
            /// </summary>
            public string DestinationMP
            {
                get
                {
                    return this.cachedDestinationMP;
                }

                set
                {
                    this.cachedDestinationMP = value;
                }
            }

            /// <summary>
            /// Name of Task to create
            /// </summary>
            public string Name
            {
                get
                {
                    return this.cachedName;
                }

                set
                {
                    this.cachedName = value;
                }
            }

            /// <summary>
            /// Description of Task to create
            /// </summary>
            public string Description
            {
                get
                {
                    return this.cachedDescription;
                }

                set
                {
                    this.cachedDescription = value;
                }
            }

            /// <summary>
            /// Target Entity of Task to create
            /// </summary>
            public string TargetEntity
            {
                get
                {
                    return this.cachedTargetEntity;
                }

                set
                {
                    this.cachedTargetEntity = value;
                }
            }

            /// <summary>
            /// Enabled/Disabled Task to create
            /// </summary>
            public bool Enabled
            {
                get
                {
                    return this.cachedEnabled;
                }

                set
                {
                    this.cachedEnabled = value;
                }
            }

            /// <summary>
            /// Name of Task to create
            /// </summary>
            public string ScriptName
            {
                get
                {
                    return this.cachedScriptName;
                }

                set
                {
                    this.cachedScriptName = value;
                }
            }

            /// <summary>
            /// Timeout of Task to create
            /// </summary>
            public string Timeout
            {
                get
                {
                    return this.cachedTimeout;
                }

                set
                {
                    this.cachedTimeout = value;
                }
            }

            /// <summary>
            /// Task Timeout Unit
            /// </summary>
            public Tasks.TimeoutUnit TimeoutUnit
            {
                get
                {
                    return this.cachedTimeoutUnit;
                }

                set
                {
                    this.cachedTimeoutUnit = value;
                }
            }

            /// <summary>
            /// Script of Task to create
            /// </summary>
            public string ScriptText
            {
                get
                {
                    return this.cachedScriptText;
                }

                set
                {
                    this.cachedScriptText = value;
                }
            }

            /// <summary>
            /// Type of Script Task to create
            /// </summary>
            public Tasks.ScriptType ScriptType
            {
                get
                {
                    return this.cachedScriptType;
                }

                set
                {
                    this.cachedScriptType = value;
                }
            }

            /// <summary>
            /// Enabled/Disabled Task to create
            /// </summary>
            public bool UseEditor
            {
                get
                {
                    return this.cachedUseEditor;
                }

                set
                {
                    this.cachedUseEditor = value;
                }
            }

            /// <summary>
            /// Parameters of Task to create
            /// </summary>
            public string Parameters
            {
                get
                {
                    return this.cachedParameters;
                }

                set
                {
                    this.cachedParameters = value;
                }
            }

            #endregion
        }
        #endregion
    } // end Tasks class
} // end namespace