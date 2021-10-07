// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TaskStatusDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 12/6/2005 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ITaskStatusDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITaskStatusDialogControls, for TaskStatusDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 12/6/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITaskStatusDialogControls
    {
        /// <summary>
        /// Read-only property to access AreYouSureYouWantToRunThisTaskListView
        /// </summary>
        ListView AreYouSureYouWantToRunThisTaskListView
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
        /// Read-only property to access TaskOutputTextBox
        /// </summary>
        TextBox TaskOutputTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access the HtmlTaskOutput
        /// </summary>
        HtmlDocument HtmlTaskOutput
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
        /// Read-only property to access CopyTextToolbarItem
        /// </summary>
        ToolbarItem CopyTextToolbarItem
                    
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CopyHTMLToolbarItem
        /// </summary>
        ToolbarItem CopyHTMLToolbarItem
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AllTasksCompletedStaticControl
        /// </summary>
        StaticControl AllTasksCompletedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl1
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
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[faizalk] 12/6/2005 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TaskStatusDialog : Dialog, ITaskStatusDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to AreYouSureYouWantToRunThisTaskListView of type ListView
        /// </summary>
        private ListView cachedAreYouSureYouWantToRunThisTaskListView;
        
        /// <summary>
        /// Cache to hold a reference to TaskOutputStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskOutputStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TaskOutputTextBox of type TextBox
        /// </summary>
        private TextBox cachedTaskOutputTextBox;
        
        /// <summary>
        /// Cach to hold a reference to HtmlTAskOutput of type HtmlDocument
        /// </summary>
        private HtmlDocument cachedHtmlTaskOutput;

        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to Copy Text Toolbar item
        /// </summary>
        private ToolbarItem cachedCopyTextToolbarItem;

        /// <summary>
        /// Cahe to hold a reference to Copy HTML Toolbar item
        /// </summary>
        private ToolbarItem cachedCopyHTMLToolbarItem;

        /// <summary>
        /// Cache to hold a reference to AllTasksCompletedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAllTasksCompletedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl1 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl1;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;

        /// <summary>
        /// Enumeration of task status dialog button indicies
        /// </summary>
        private enum taskStatusDialogButtons
        {
            copyHTMLButton = 0,
            copyTextButton
        }

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TaskStatusDialog of type MomConsole
        /// </param>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TaskStatusDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ITaskStatusDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITaskStatusDialogControls Controls
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
        ///  Routine to set/get the text in control TaskOutput
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TaskOutputText
        {
            get
            {
                return this.Controls.TaskOutputTextBox.Text;
            }
            
            set
            {
                this.Controls.TaskOutputTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AreYouSureYouWantToRunThisTaskListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ITaskStatusDialogControls.AreYouSureYouWantToRunThisTaskListView
        {
            get
            {
                if ((this.cachedAreYouSureYouWantToRunThisTaskListView == null))
                {
                    this.cachedAreYouSureYouWantToRunThisTaskListView = new ListView(this, TaskStatusDialog.ControlIDs.AreYouSureYouWantToRunThisTaskListView);
                }
                return this.cachedAreYouSureYouWantToRunThisTaskListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskOutputStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusDialogControls.TaskOutputStaticControl
        {
            get
            {
                if ((this.cachedTaskOutputStaticControl == null))
                {
                    this.cachedTaskOutputStaticControl = new StaticControl(this, TaskStatusDialog.ControlIDs.TaskOutputStaticControl);
                }
                return this.cachedTaskOutputStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskOutputTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskStatusDialogControls.TaskOutputTextBox
        {
            get
            {
                if ((this.cachedTaskOutputTextBox == null))
                {
                    this.cachedTaskOutputTextBox = new TextBox(this, TaskStatusDialog.ControlIDs.TaskOutputTextBox);
                }
                return this.cachedTaskOutputTextBox;
            }
        }
        
        /// <summary>
        /// Exposes access to the Internet Explorer Taskoutput html control
        /// <history>
        ///     [jefftow] 19DEC07 Created
        /// </history>
        /// </summary>
        HtmlDocument ITaskStatusDialogControls.HtmlTaskOutput
        {
            get
            {
                if ((this.cachedHtmlTaskOutput == null))
                {
                    Window wndTemp = new Window(
                        "",
                        StringMatchSyntax.WildCard,
                        WindowClassNames.InternetExplorerServer,
                        StringMatchSyntax.ExactMatch,
                        this.AccessibleObject.Window,
                        30000);
                    
                    this.cachedHtmlTaskOutput = new HtmlDocument(wndTemp);
                }
                return this.cachedHtmlTaskOutput;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ITaskStatusDialogControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, TaskStatusDialog.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }
        
        /// <summary>
        /// Exposes access to the Copy Text toolbar item
        /// </summary>
        /// <history>
        ///     [jefftow] 18DEC07 Created
        /// </history>
        ToolbarItem ITaskStatusDialogControls.CopyTextToolbarItem
        {
            get
            {
                if ((this.cachedCopyTextToolbarItem == null))
                {
                    this.cachedCopyTextToolbarItem = this.Controls.ToolStrip1.ToolbarItems[(int)taskStatusDialogButtons.copyTextButton];
                }
                return this.cachedCopyTextToolbarItem;
            }
        }

        /// <summary>
        /// Exposes access to the Copy HTML toolbar item
        /// <history>
        ///     [jefftow] 18DEC07 Created
        /// </history>
        /// </summary>
        ToolbarItem ITaskStatusDialogControls.CopyHTMLToolbarItem
        {
            get
            {
                if ((this.cachedCopyHTMLToolbarItem == null))
                {
                    this.cachedCopyHTMLToolbarItem = this.Controls.ToolStrip1.ToolbarItems[(int)taskStatusDialogButtons.copyHTMLButton];
                }
                return this.cachedCopyHTMLToolbarItem;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllTasksCompletedStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusDialogControls.AllTasksCompletedStaticControl
        {
            get
            {
                if ((this.cachedAllTasksCompletedStaticControl == null))
                {
                    this.cachedAllTasksCompletedStaticControl = new StaticControl(this, TaskStatusDialog.ControlIDs.AllTasksCompletedStaticControl);
                }
                return this.cachedAllTasksCompletedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl1 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITaskStatusDialogControls.StaticControl1
        {
            get
            {
                if ((this.cachedStaticControl1 == null))
                {
                    this.cachedStaticControl1 = new StaticControl(this, TaskStatusDialog.ControlIDs.StaticControl1);
                }
                return this.cachedStaticControl1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskStatusDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, TaskStatusDialog.ControlIDs.CloseButton);
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
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }

        /// <summary>
        /// Routine to click the HTML Copy button
        /// <history>
        ///     [jefftow] 18DEC07 Created
        /// </history>
        /// </summary>
        public virtual void ClickHTMLCopy()
        {
            this.Controls.CopyHTMLToolbarItem.Click();
        }

        /// <summary>
        /// Routine to click the TEXT Copy button
        /// <history>
        ///     [jefftow] 18DEC07 Created
        /// </history>
        /// </summary>
        public virtual void ClickTextCopy()
        {
            this.Controls.CopyTextToolbarItem.Click();
        }

        #endregion
        
        /// <summary>
        /// Routine to retrive the HTML Text from the task status dialog box output
        /// <history>
        ///     [jefftow] 18DEC07 Created
        /// </history>
        /// </summary>
        /// <returns></returns>
        public virtual string GetHTML()
        {
            Maui.Core.Clipboard.Clear();
            this.ClickHTMLCopy();
            return Maui.Core.Clipboard.Text;
        }

        /// <summary>
        /// Routine to retrive the Text from the task status dialog box task output
        /// </summary>
        /// <returns></returns>
        public virtual string GetText()
        {
            Maui.Core.Clipboard.Clear();
            this.ClickTextCopy();
            return Maui.Core.Clipboard.Text;
        }

       

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsole owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException)
            {
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8, //WindowClassNames.Dialog,
                                StringMatchSyntax.WildCard, //StringMatchSyntax.ExactMatch,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

                    // throw the existing WindowNotFound exception
                    throw;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
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
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Task Status - ;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;taskStatusTitlePrefix";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskOutput
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskOutput = ";&Task Output;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.RunTask.TaskStatusBase;taskOutputLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllTasksCompleted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllTasksCompleted = ";All tasks completed.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;tasksCompleted";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Cl&ose;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.RunTask.TaskStatusBase;closeButton.Text";
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
            /// Caches the translated resource string for:  AllTasksCompleted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllTasksCompleted;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 12/6/2005 Created
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
            /// Exposes access to the TaskOutput translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 12/6/2005 Created
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
            /// 	[faizalk] 12/6/2005 Created
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
            /// Exposes access to the AllTasksCompleted translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 12/6/2005 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllTasksCompleted
            {
                get
                {
                    if ((cachedAllTasksCompleted == null))
                    {
                        cachedAllTasksCompleted = CoreManager.MomConsole.GetIntlStr(ResourceAllTasksCompleted);
                    }
                    return cachedAllTasksCompleted;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 12/6/2005 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[faizalk] 12/6/2005 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for AreYouSureYouWantToRunThisTaskListView
            /// </summary>
            public const string AreYouSureYouWantToRunThisTaskListView = "targetList";
            
            /// <summary>
            /// Control ID for TaskOutputStaticControl
            /// </summary>
            public const string TaskOutputStaticControl = "taskOutputLabel";
            
            /// <summary>
            /// Control ID for TaskOutputTextBox
            /// </summary>
            //public const string TaskOutputTextBox = "statusRichTextBox";
            public const string TaskOutputTextBox = "outputBrowser";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// <history>
            ///     [jefftow] 18DEC07 - changed from "toolStrip to toolStrip1"
            /// </history>
            /// </summary>
            public const string ToolStrip1 = "toolStrip1";
            
            /// <summary>
            /// Control ID for AllTasksCompletedStaticControl
            /// </summary>
            public const string AllTasksCompletedStaticControl = "progressLabel";
            
            /// <summary>
            /// Control ID for StaticControl1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl1 = "progressBar";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";
        }
        #endregion
    }
}
