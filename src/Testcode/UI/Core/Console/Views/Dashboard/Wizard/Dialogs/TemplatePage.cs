// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TemplatePage.cs">
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
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - ITemplatePageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITemplatePageControls, for TemplatePage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-dayow] 7/30/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITemplatePageControls
    {
        /// <summary>
        /// Gets read-only property to access OrientationPane
        /// </summary>
        ListView OrientationPane
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access TemplateDataGrid
        /// </summary>
        MomControls.DataGridControl TemplateDataGrid
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
        /// Gets read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
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
    public partial class TemplatePage : Dialog, ITemplatePageControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OrientationPane of type ListView
        /// </summary>
        private ListView cachedOrientationPane;

        /// <summary>
        /// Cache to hold a reference to TemplateDataGrid of type DataGrid
        /// </summary>
        private MomControls.DataGridControl cachedTemplateDataGrid;

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to ProgressBar of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressBar;

        /// <summary>
        /// Cache to hold a reference to dialog tile
        /// </summary>
        private static string cacheddialogTitle;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the TemplatePage class.
        /// </summary>
        /// <param name='app'>
        /// Owner of TemplatePage of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TemplatePage(MomConsoleApp app, int timeout, string dialogTitle) :
            base(app, Init(timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ITemplatePage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITemplatePageControls Controls
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
        ListView ITemplatePageControls.OrientationPane
        {
            get
            {
                if ((this.cachedOrientationPane == null))
                {
                    this.cachedOrientationPane = new ListView(this, TemplatePage.QueryIds.OrientationPane);
                }

                return this.cachedOrientationPane;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TemplateDataGrid control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        MomControls.DataGridControl ITemplatePageControls.TemplateDataGrid
        {
            get
            {
                if ((this.cachedTemplateDataGrid == null))
                {
                    this.cachedTemplateDataGrid = new MomControls.DataGridControl(this, TemplatePage.QueryIds.TemplateDataGrid);
                }

                return this.cachedTemplateDataGrid;
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
        Button ITemplatePageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, TemplatePage.QueryIds.PreviousButton);
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
        Button ITemplatePageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, TemplatePage.QueryIds.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITemplatePageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, TemplatePage.QueryIds.FinishButton);
                }

                return this.cachedFinishButton;
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
        Button ITemplatePageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TemplatePage.QueryIds.CancelButton);
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
        ProgressBar ITemplatePageControls.ProgressBar
        {
            get
            {
                if ((this.cachedProgressBar == null))
                {
                    this.cachedProgressBar = new ProgressBar(this, TemplatePage.QueryIds.ProgressBar);
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
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
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
        private static Window Init(int timeout, string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
           
            try
            {
                tempWindow = new Window(CompletionPage.InitDialogTitleQID(dialogTitle), timeout);                 
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                int maxRetries = Constants.DefaultMaxRetry;
                int retries = 0;
                while (tempWindow == null && retries < maxRetries)
                {
                    retries++;
                    try
                    {
                        tempWindow = new Window(CompletionPage.InitDialogTitleQID(dialogTitle), timeout);                 
                        
                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for windows search
                        Sleeper.Delay(timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + retries
                            + " of "
                            + maxRetries
                            + "...");
                    }
                }

                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                             "Init function could not find or bring up the window"
                              + "with a title of '" + dialogTitle
                              + "'.\n\n" + ex.Message);
                }
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
            /// Contains resource string for TemplateDataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTemplateDataGrid = ";[UIA]AutomationId='InnerDataGrid'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TemplateDataGridWeb query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTemplateDataGridWeb = ";[UIA]AutomationId='silverlightDataGrid'";

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
            /// Gets access to the TemplateDataGrid resource qid string
            /// </summary>
            /// <history>
            ///   [v-dayow] 7/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TemplateDataGrid
            {
                get
                {
                    QID templateDataGrid;
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            templateDataGrid = new QID(ResourceTemplateDataGrid);
                            break;
                        case ProductSkuLevel.Web:
                            templateDataGrid = new QID(ResourceTemplateDataGridWeb);
                            break;
                        default:
                            templateDataGrid = new QID(ResourceTemplateDataGrid);
                            break;
                    }
                    return templateDataGrid;                    
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
            /// Gets access to the FinishButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-dayow] 7/30/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FinishButton
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
            /// Resource string for Next
            /// </summary>
            public const string Finish = "Next";

            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = "Cancel";
        }
        #endregion
    }
}
