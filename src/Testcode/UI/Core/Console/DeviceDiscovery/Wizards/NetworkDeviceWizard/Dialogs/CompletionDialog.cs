// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CompletionDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [dialac] 5/01/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - ICompletionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICompletionDialogControls, for CompletionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [dialac] 5/01/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICompletionDialogControls
    {
        /// <summary>
        /// Gets read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access RunNowOptionCheckBox
        /// </summary>
        CheckBox RunNowOptionCheckBox
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
    ///   [dialac] 5/01/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class CompletionDialog : Dialog, ICompletionDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to RunNowOptionCheckBox of type TextBox
        /// </summary>
        private CheckBox cachedRunNowOptionCheckBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the CompletionDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of CompletionDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CompletionDialog(Mom.Test.UI.Core.Console.MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICompletionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICompletionDialogControls Controls
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
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICompletionDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CompletionDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICompletionDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CompletionDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CloseButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICompletionDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, CompletionDialog.ControlIDs.CloseButton);
                }
                
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICompletionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CompletionDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the RunNowOptionCheckBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 7/18/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ICompletionDialogControls.RunNowOptionCheckBox
        {
            get
            {
                if ((this.cachedRunNowOptionCheckBox == null))
                {
                    int maxRetry = 2;
                    for (int i = 0; i < maxRetry; i++)
                    {
                        try
                        {
                            this.cachedRunNowOptionCheckBox = new CheckBox(this, CompletionDialog.QueryIds.RunNowOptionCheckBox);
                            break;
                        }
                        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                        {
                            Core.Common.Utilities.LogMessage(
                                    "Attempt " + (i + 1) + " of " + maxRetry);
                        }
                    }
                }

                return this.cachedRunNowOptionCheckBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, timeout);
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
                        UISynchronization.WaitForUIObjectReady(tempWindow, timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);


                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(timeout);
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
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";            
        }

        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for LookForTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunNowOptionCheckBox = ";[UIA]AutomationId=\'runNowOption\'";
            #endregion
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the RunNowOptionCheckBox resource qid string
            /// </summary>           
            /// -----------------------------------------------------------------------------
            public static QID RunNowOptionCheckBox
            {
                get
                {
                    return new QID(ResourceRunNowOptionCheckBox);
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
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
            private const string ResourceDialogTitle = ";Computer and Device Management Wizard;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "DiscoveryWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = "< &Previous";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = "&Next >";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";&Close;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CloseText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = "Cancel";
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if (GeneralDialog.CurrentWizardTitle != null)
                        return GeneralDialog.CurrentWizardTitle;
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Next translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceNext);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Close translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceClose);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                }
            }
            #endregion
        }
        #endregion
    }
}
