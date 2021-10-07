// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AssertDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 2/5/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAssertDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAssertDialogControls, for AssertDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 2/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAssertDialogControls
    {
        /// <summary>
        /// Read-only property to access AbortButton
        /// </summary>
        Button AbortButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RetryButton
        /// </summary>
        Button RetryButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IgnoreButton
        /// </summary>
        Button IgnoreButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorMessageLable
        /// </summary>
        StaticControl ErrorMessageLable
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
    /// 	[faizalk] 2/5/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AssertDialog : Dialog, IAssertDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 1000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to AbortButton of type Button
        /// </summary>
        private Button cachedAbortButton;
        
        /// <summary>
        /// Cache to hold a reference to RetryButton of type Button
        /// </summary>
        private Button cachedRetryButton;
        
        /// <summary>
        /// Cache to hold a reference to IgnoreButton of type Button
        /// </summary>
        private Button cachedIgnoreButton;
        
        /// <summary>
        /// Cache to hold a reference to ErrorMessageLable of type StaticControl
        /// </summary>
        private StaticControl ErrorMessageLable;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AssertDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AssertDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAssertDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAssertDialogControls Controls
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
        ///  Exposes access to the AbortButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAssertDialogControls.AbortButton
        {
            get
            {
                if ((this.cachedAbortButton == null))
                {
                    this.cachedAbortButton = new Button(this, AssertDialog.ControlIDs.AbortButton);
                }
                
                return this.cachedAbortButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RetryButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAssertDialogControls.RetryButton
        {
            get
            {
                if ((this.cachedRetryButton == null))
                {
                    this.cachedRetryButton = new Button(this, AssertDialog.ControlIDs.RetryButton);
                }
                
                return this.cachedRetryButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IgnoreButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAssertDialogControls.IgnoreButton
        {
            get
            {
                if ((this.cachedIgnoreButton == null))
                {
                    this.cachedIgnoreButton = new Button(this, AssertDialog.ControlIDs.IgnoreButton);
                }
                
                return this.cachedIgnoreButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EitherSpecifyAllSortIndexOrNoneAtQueryCacheBaseGetSortColumnsCollection1FieldsAtQueryCache2InitQuery control
        /// </summary>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAssertDialogControls.ErrorMessageLable
        {
            get
            {
                if ((this.ErrorMessageLable == null))
                {
                    this.ErrorMessageLable = new StaticControl(this, AssertDialog.ControlIDs.ErrorMessageLable);
                }
                
                return this.ErrorMessageLable;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Abort
        /// </summary>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAbort()
        {
            this.Controls.AbortButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Retry
        /// </summary>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRetry()
        {
            this.Controls.RetryButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ignore
        /// </summary>
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickIgnore()
        {
            this.Controls.IgnoreButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 2/5/2007 Created
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
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
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
        /// 	[faizalk] 2/5/2007 Created
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
            private const string ResourceDialogTitle = ";Assertion Failed: Abort=Quit, Retry=Debug, Ignore=Continue;ManagedString;System.dll;System;DebugAssertTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Abort
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAbort = "&Abort";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Retry
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceRetry = "&Retry";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ignore
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceIgnore = "&Ignore";
            
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
            /// Caches the translated resource string for:  Abort
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAbort;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Retry
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRetry;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ignore
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIgnore;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EitherSpecifyAllSortIndexOrNoneAtQueryCacheBaseGetSortColumnsCollection1FieldsAtQueryCache2InitQuery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEitherSpecifyAllSortIndexOrNoneAtQueryCacheBaseGetSortColumnsCollection1FieldsAtQueryCache2InitQuery;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 2/5/2007 Created
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
            /// Exposes access to the Abort translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 2/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Abort
            {
                get
                {
                    if ((cachedAbort == null))
                    {
                        cachedAbort = CoreManager.MomConsole.GetIntlStr(ResourceAbort);
                    }
                    
                    return cachedAbort;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Retry translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 2/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Retry
            {
                get
                {
                    if ((cachedRetry == null))
                    {
                        cachedRetry = CoreManager.MomConsole.GetIntlStr(ResourceRetry);
                    }
                    
                    return cachedRetry;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ignore translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 2/5/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ignore
            {
                get
                {
                    if ((cachedIgnore == null))
                    {
                        cachedIgnore = CoreManager.MomConsole.GetIntlStr(ResourceIgnore);
                    }
                    
                    return cachedIgnore;
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
        /// 	[faizalk] 2/5/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for AbortButton
            /// </summary>
            public const int AbortButton = 3;
            
            /// <summary>
            /// Control ID for RetryButton
            /// </summary>
            public const int RetryButton = 4;
            
            /// <summary>
            /// Control ID for IgnoreButton
            /// </summary>
            public const int IgnoreButton = 5;
            
            /// <summary>
            /// Control ID for ErrorMessageLable
            /// </summary>
            public const int ErrorMessageLable = 65535;
        }
        #endregion
    }
}
