// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ScopingPage.cs">
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

    #region Interface Definition - IScopingPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IScopingPageControls, for ScopingPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-dayow] 7/30/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IScopingPageControls
    {
        /// <summary>
        /// Gets read-only property to access OrientationPane
        /// </summary>
        ListView OrientationPane
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access MessageValueTextBox
        /// </summary>
        TextBox MessageValueTextBox
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access Part1TextBox
        /// </summary>
        TextBox Part1TextBox
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access Part2TextBox
        /// </summary>
        TextBox Part2TextBox
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
    public partial class ScopingPage : Dialog, IScopingPageControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OrientationPane of type ListView
        /// </summary>
        private ListView cachedOrientationPane;

        /// <summary>
        /// Cache to hold a reference to MessageValueTextBox of type TextBox
        /// </summary>
        private TextBox cachedMessageValueTextBox;

        /// <summary>
        /// Cache to hold a reference to Part1TextBox of type TextBox
        /// </summary>
        private TextBox cachedPart1TextBox;

        /// <summary>
        /// Cache to hold a reference to Part2TextBox of type TextBox
        /// </summary>
        private TextBox cachedPart2TextBox;

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
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the ScopingPage class.
        /// </summary>
        /// <param name='app'>
        /// Owner of ScopingPage of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ScopingPage(MomConsoleApp app, int timeout, string dialogTitle) :
            base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IScopingPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IScopingPageControls Controls
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
        ///  Gets or sets the text in control MessageValue
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MessageValueText
        {
            get
            {
                return this.Controls.MessageValueTextBox.Text;
            }

            set
            {
                this.Controls.MessageValueTextBox.SendKeys (value);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control Part1
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string Part1Text
        {
            get
            {
                return this.Controls.Part1TextBox.Text;
            }

            set
            {
                // In Maui 4.0, set text for textbox on New Dashboard and Widget Wizard dialog will throw textobx cannot be found exception, use SendKeys instead
                this.Controls.Part1TextBox.SendKeys(value);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control Part2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string Part2Text
        {
            get
            {
                return this.Controls.Part2TextBox.Text;
            }

            set
            {
                this.Controls.Part2TextBox.SendKeys( value);
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
        ListView IScopingPageControls.OrientationPane
        {
            get
            {
                if ((this.cachedOrientationPane == null))
                {
                    this.cachedOrientationPane = new ListView(this, ScopingPage.QueryIds.OrientationPane);
                }

                return this.cachedOrientationPane;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MessageValueTextBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (MessageValueTextBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        TextBox IScopingPageControls.MessageValueTextBox
        {
            get
            {
                if ((this.cachedMessageValueTextBox == null))
                {
                    this.cachedMessageValueTextBox = new TextBox(this, ScopingPage.QueryIds.MessageValueTextBox);
                }

                return this.cachedMessageValueTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Part1TextBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (Part1TextBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        TextBox IScopingPageControls.Part1TextBox
        {
            get
            {
                if ((this.cachedPart1TextBox == null))
                {
                    this.cachedPart1TextBox = new TextBox(this, ScopingPage.QueryIds.Part1TextBox);
                }

                return this.cachedPart1TextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Part2TextBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 7/30/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (Part2TextBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        TextBox IScopingPageControls.Part2TextBox
        {
            get
            {
                if ((this.cachedPart2TextBox == null))
                {
                    this.cachedPart2TextBox = new TextBox(this, ScopingPage.QueryIds.Part2TextBox);
                }

                return this.cachedPart2TextBox;
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
        Button IScopingPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ScopingPage.QueryIds.PreviousButton);
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
        Button IScopingPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ScopingPage.QueryIds.NextButton);
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
        Button IScopingPageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ScopingPage.QueryIds.FinishButton);
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
        Button IScopingPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ScopingPage.QueryIds.CancelButton);
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
        ProgressBar IScopingPageControls.ProgressBar
        {
            get
            {
                if ((this.cachedProgressBar == null))
                {
                    this.cachedProgressBar = new ProgressBar(this, ScopingPage.QueryIds.ProgressBar);
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
        private static Window Init(MomConsoleApp app, int timeout, string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(CompletionPage.InitDialogTitleQID(dialogTitle), timeout);                 
            }
            catch (Exceptions.WindowNotFoundException)
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

            private const string ResourceMessageValueTextBox = ";[UIA]Role='editable text' && Instance='1'";

            private const string ResourcePart1TextBox = ";[UIA]Role='editable text' && Instance='2'";

            private const string ResourcePart2TextBox = ";[UIA]Role='editable text' && Instance='3'";

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

            public static QID MessageValueTextBox
            {
                get
                {
                    return new QID(ResourceMessageValueTextBox);
                }
            }

            public static QID Part1TextBox
            {
                get
                {
                    return new QID(ResourcePart1TextBox);
                }
            }

            public static QID Part2TextBox
            {
                get
                {
                    return new QID(ResourcePart2TextBox);
                }
            }

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
            /// Resource string for Finish
            /// </summary>
            public const string Finish = "Finish";

            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = "Cancel";
        }
        #endregion
    }
}
