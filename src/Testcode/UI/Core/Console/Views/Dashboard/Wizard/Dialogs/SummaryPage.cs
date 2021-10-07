// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SummaryPage.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-dayow] 7/30/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - ISummaryPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISummaryPageControls, for SummaryPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-dayow] 7/30/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISummaryPageControls
    {
        /// <summary>
        /// Gets read-only property to access OrientationPane
        /// </summary>
        ListView OrientationPane
        {
            get;
        }
        
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
        /// Gets read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Gets read-only property to access ProgressBar
        /// </summary>
        ProgressBar ProgressBar
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
    ///   [v-dayow] 7/30/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class SummaryPage : Dialog, ISummaryPageControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OrientationPane of type ListView
        /// </summary>
        private ListView cachedOrientationPane;
        
        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ProgressBar of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressBar;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the SummaryPage class.
        /// </summary>
        /// <param name='app'>
        /// Owner of SummaryPage of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SummaryPage(MomConsoleApp app, int timeout, string dialogTitle) :
            base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISummaryPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISummaryPageControls Controls
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
        ///  Gets access to the OrientationPane control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISummaryPageControls.OrientationPane
        {
            get
            {
                if ((this.cachedOrientationPane == null))
                {
                    this.cachedOrientationPane = new ListView(this, SummaryPage.QueryIds.OrientationPane);
                }
                
                return this.cachedOrientationPane;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SummaryPage.QueryIds.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SummaryPage.QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryPageControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SummaryPage.QueryIds.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISummaryPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SummaryPage.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressBar control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ProgressBar ISummaryPageControls.ProgressBar
        {
            get
            {
                if ((this.cachedProgressBar == null))
                {
                    this.cachedProgressBar = new ProgressBar(this, SummaryPage.QueryIds.ProgressBar);
                }
                
                return this.cachedProgressBar;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
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
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
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
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout, string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(CompletionPage.InitDialogTitleQID(dialogTitle), timeout);                 
            }
            catch (Exceptions.WindowNotFoundException )
            {
                // TODO:  Add any specific logic here to handle the case when the
                // dialog is not found in the specified timeout.
                // otherwise rethrow the exception.
                throw;
            }
            
            return tempWindow;
        }
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for OrientationPane query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrientationPane = ";[UIA]AutomationId='OrientationListBox'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PreviousButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePreviousButton = ";[UIA]AutomationId='WizardPreviousButton'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NextButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNextButton = ";[UIA]AutomationId='WizardNextButton'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FinishButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinishButton = ";[UIA]AutomationId='WizardCloseButton'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId='WizardCancelButton'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ProgressBar query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProgressBar = ";[UIA]AutomationId='progressBar1'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OrientationPane resource qid string
            /// </summary>
            /// <history>
            ///   [v-dayow] 7/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OrientationPane
            {
                get
                {
                    return new QID(ResourceOrientationPane);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-dayow] 7/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PreviousButton
            {
                get
                {
                    return new QID(ResourcePreviousButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NextButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-dayow] 7/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NextButton
            {
                get
                {
                    return new QID(ResourceNextButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CreateButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-dayow] 7/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CreateButton
            {
                get
                {
                    return new QID(ResourceFinishButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-dayow] 7/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    return new QID(ResourceCancelButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ProgressBar resource qid string
            /// </summary>
            /// <history>
            ///   [v-dayow] 7/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar
            {
                get
                {
                    return new QID(ResourceProgressBar);
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
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Configuration Properties
            /// </summary>
            public const string DialogTitle = "Configuration Properties";
            
            /// <summary>
            /// Resource string for OrientationPane
            /// </summary>
            public const string OrientationPane = "OrientationPane";
            
            /// <summary>
            /// Resource string for < Previous
            /// </summary>
            public const string Previous = "< Previous";
            
            /// <summary>
            /// Resource string for Next >
            /// </summary>
            public const string Next = "Next >";
            
            /// <summary>
            /// Resource string for Create
            /// </summary>
            public const string Create = "Create";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = "Cancel";
        }
        #endregion
    }
}
