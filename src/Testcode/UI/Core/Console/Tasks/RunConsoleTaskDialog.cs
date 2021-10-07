// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunConsoleTaskDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/28/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IRunConsoleTaskDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunConsoleTaskDialogControls, for RunConsoleTaskDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/28/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunConsoleTaskDialogControls
    {
        /// <summary>
        /// Read-only property to access OutputStaticControl
        /// </summary>
        StaticControl OutputStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheTaskWasCompletedStaticControl
        /// </summary>
        StaticControl TheTaskWasCompletedStaticControl
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
        
        /// <summary>
        /// Read-only property to access OutputTextBox
        /// </summary>
        TextBox OutputTextBox
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
    /// 	[faizalk] 4/28/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RunConsoleTaskDialog : Dialog, IRunConsoleTaskDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OutputStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOutputStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TheTaskWasCompletedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheTaskWasCompletedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to OutputTextBox of type TextBox
        /// </summary>
        private TextBox cachedOutputTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RunConsoleTaskDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunConsoleTaskDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRunConsoleTaskDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunConsoleTaskDialogControls Controls
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
        ///  Routine to set/get the text in control Output
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string OutputText
        {
            get
            {
                return this.Controls.OutputTextBox.Text;
            }
            
            set
            {
                this.Controls.OutputTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OutputStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunConsoleTaskDialogControls.OutputStaticControl
        {
            get
            {
                if ((this.cachedOutputStaticControl == null))
                {
                    this.cachedOutputStaticControl = new StaticControl(this, RunConsoleTaskDialog.ControlIDs.OutputStaticControl);
                }
                return this.cachedOutputStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheTaskWasCompletedStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRunConsoleTaskDialogControls.TheTaskWasCompletedStaticControl
        {
            get
            {
                if ((this.cachedTheTaskWasCompletedStaticControl == null))
                {
                    this.cachedTheTaskWasCompletedStaticControl = new StaticControl(this, RunConsoleTaskDialog.ControlIDs.TheTaskWasCompletedStaticControl);
                }
                return this.cachedTheTaskWasCompletedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunConsoleTaskDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, RunConsoleTaskDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OutputTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IRunConsoleTaskDialogControls.OutputTextBox
        {
            get
            {
                if ((this.cachedOutputTextBox == null))
                {
                    this.cachedOutputTextBox = new TextBox(this, RunConsoleTaskDialog.ControlIDs.OutputTextBox);
                }
                return this.cachedOutputTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
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
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
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
        /// 	[faizalk] 4/28/2006 Created
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
            private const string ResourceDialogTitle = ";Console Task Output;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.ConsoleTaskOutput;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Output
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOutput = ";Ou&tput:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.RunTask.ConsoleTaskOutput;labelOutput.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheTaskWasCompleted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheTaskWasCompleted = ";The task was completed.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskResources;consoleTaskComplet" +
                "ed";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";&Close;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.Subscriptio" +
                "nsForm;okButton.Text";
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
            /// Caches the translated resource string for:  Output
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOutput;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheTaskWasCompleted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheTaskWasCompleted;
            
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
            /// 	[faizalk] 4/28/2006 Created
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
            /// Exposes access to the Output translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/28/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Output
            {
                get
                {
                    if ((cachedOutput == null))
                    {
                        cachedOutput = CoreManager.MomConsole.GetIntlStr(ResourceOutput);
                    }
                    return cachedOutput;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheTaskWasCompleted translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/28/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheTaskWasCompleted
            {
                get
                {
                    if ((cachedTheTaskWasCompleted == null))
                    {
                        cachedTheTaskWasCompleted = CoreManager.MomConsole.GetIntlStr(ResourceTheTaskWasCompleted);
                    }
                    return cachedTheTaskWasCompleted;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/28/2006 Created
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
        /// 	[faizalk] 4/28/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OutputStaticControl
            /// </summary>
            public const string OutputStaticControl = "labelOutput";
            
            /// <summary>
            /// Control ID for TheTaskWasCompletedStaticControl
            /// </summary>
            public const string TheTaskWasCompletedStaticControl = "labelStatus";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OutputTextBox
            /// </summary>
            public const string OutputTextBox = "outputBox";
        }
        #endregion
    }
}
