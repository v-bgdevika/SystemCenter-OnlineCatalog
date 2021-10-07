// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TopNPerformanceTimeRangeAndResultsPage.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-vijia] 8/11/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.TopNPerformanceWidget.Dialog
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    #region Interface Definition - ITopNPerformanceTimeRangeAndResultsPageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITopNPerformanceTimeRangeAndResultsPageControls, for TopNPerformanceTimeRangeAndResultsPage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-vijia] 8/11/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITopNPerformanceTimeRangeAndResultsPageControls
    {
        /// <summary>
        /// Gets read-only property to access LastTextBox
        /// </summary>
        TextBox LastTextBox
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access TimeRangeComboBox
        /// </summary>
        ComboBox TimeRangeComboBox
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access MaximumResultsToShowTextBox
        /// </summary>
        TextBox MaximumResultsToShowTextBox
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
        /// Gets read-only property to access ShowTopResultsRadioButton
        /// </summary>
        RadioButton ShowTopResultsRadioButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ShowBottomResultsRadioButton
        /// </summary>
        RadioButton ShowBottomResultsRadioButton
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
    ///   [v-vijia] 8/11/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class TopNPerformanceTimeRangeAndResultsPage : Dialog, ITopNPerformanceTimeRangeAndResultsPageControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to LastTextBox of type TextBox
        /// </summary>
        private TextBox cachedLastTextBox;

        /// <summary>
        /// Cache to hold a reference to TimeRangeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimeRangeComboBox;

        /// <summary>
        /// Cache to hold a reference to MaximumResultsToShowTextBox of type TextBox
        /// </summary>
        private TextBox cachedMaximumResultsToShowTextBox;

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
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the TopNPerformanceTimeRangeAndResultsPage class.
        /// </summary>
        /// <param name='app'>
        /// Owner of TopNPerformanceTimeRangeAndResultsPage of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TopNPerformanceTimeRangeAndResultsPage(MomConsoleApp app, int timeout, string dialogTitle) :
            base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ITopNPerformanceTimeRangeAndResultsPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITopNPerformanceTimeRangeAndResultsPageControls Controls
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
        ///  Gets or sets the text in control Last
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LastText
        {
            get
            {
                return this.Controls.LastTextBox.Text;
            }

            set
            {
                //this.Controls.LastTextBox.ScreenElement.DoubleClick(-1, -1);
                this.Controls.LastTextBox.SetValueWithPaste(value);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control TimeRange
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeRangeText
        {
            get
            {
                return this.Controls.TimeRangeComboBox.Text;
            }

            set
            {
                this.Controls.TimeRangeComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control MaximumResultsToShow
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaximumResultsToShowText
        {
            get
            {
                return this.Controls.MaximumResultsToShowTextBox.Text;
            }

            set
            {
                this.Controls.MaximumResultsToShowTextBox.ScreenElement.DoubleClick(-1, -1);
                this.Controls.MaximumResultsToShowTextBox.ScreenElement.SendKeys(value);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the LastTextBox control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITopNPerformanceTimeRangeAndResultsPageControls.LastTextBox
        {
            get
            {
                if ((this.cachedLastTextBox == null))
                {
                    //Get parent first
                    StaticControl numericUpDown = new StaticControl(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.NumericUPDown);
                    //Get text box from parent
                    this.cachedLastTextBox = new TextBox(numericUpDown, TopNPerformanceTimeRangeAndResultsPage.QueryIds.LastTextBox);
                }

                return this.cachedLastTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TimeRangeComboBox control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (TimeRangeComboBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        ComboBox ITopNPerformanceTimeRangeAndResultsPageControls.TimeRangeComboBox
        {
            get
            {
                if ((this.cachedTimeRangeComboBox == null))
                {
                    this.cachedTimeRangeComboBox = new ComboBox(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.TimeComboBox);
                }

                return this.cachedTimeRangeComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MaximumResultsToShowTextBox control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (valueText) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        TextBox ITopNPerformanceTimeRangeAndResultsPageControls.MaximumResultsToShowTextBox
        {
            get
            {
                if ((this.cachedMaximumResultsToShowTextBox == null))
                {
                    this.cachedMaximumResultsToShowTextBox = new TextBox(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.MaximumResultsToShowTextBox);
                }

                return this.cachedMaximumResultsToShowTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceTimeRangeAndResultsPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.PreviousButton);
                }

                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceTimeRangeAndResultsPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.NextButton);
                }

                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceTimeRangeAndResultsPageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.FinishButton);
                }

                return this.cachedFinishButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITopNPerformanceTimeRangeAndResultsPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ShowTopResultsRadioButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITopNPerformanceTimeRangeAndResultsPageControls.ShowTopResultsRadioButton
        {
            get
            {
                return new RadioButton(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.ShowTopResultsRadioButton);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ShowBottomResultsRadioButton control
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITopNPerformanceTimeRangeAndResultsPageControls.ShowBottomResultsRadioButton
        {
            get
            {
                return new RadioButton(this, TopNPerformanceTimeRangeAndResultsPage.QueryIds.ShowBottomResultsRadioButton);
            }
        }

        #endregion

        #region Radio Button Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control ShowTopResults/ShowBottomResults
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ShowTopResults
        {
            get
            {
                if (this.Controls.ShowTopResultsRadioButton.ButtonState == ButtonState.Checked)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            set
            {
                if (value)
                {
                    this.Controls.ShowTopResultsRadioButton.Click();
                }
                else
                {
                    this.Controls.ShowBottomResultsRadioButton.Click();
                }
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-vijia] 8/11/2011 Created
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
        ///   [v-vijia] 8/11/2011 Created
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
        ///   [v-vijia] 8/11/2011 Created
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
        ///   [v-vijia] 8/11/2011 Created
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
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout, string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + dialogTitle + "' && Role = 'window'"), timeout);   
            }
            catch (Exceptions.WindowNotFoundException)
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
                        tempWindow = new Window(dialogTitle, StringMatchSyntax.WildCard);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(timeout);
                    }
                }

                // check for success
                if ((null == tempWindow))
                {
                    throw;
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
        ///   [v-vijia] 8/11/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// <summary>
            /// Contains resource string for NumericUpDown time value control query id
            /// </summary>
            private const string ResourceNumericUpDown = ";[UIA]AutomationId='timeValueControl'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for LastTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLastTextBox = ";[UIA]AutomationId='valueText'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MaximumResultsToShowTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMaximumResultsToShowTextBox = ";[UIA]AutomationId=\'valueText\' && instance = 2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TimeComboBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeComboBox = ";[UIA]ClassName=\'ComboBox\'";


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PreviousButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePreviousButton = ";[UIA]AutomationId=\'WizardPreviousButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NextButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNextButton = ";[UIA]AutomationId=\'WizardNextButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FinishButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinishButton = ";[UIA]AutomationId=\'WizardCloseButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'WizardCancelButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ShowTopResultsRadioButton query id
            /// TOOD: needs load resource string for the name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowTopResultsRadioButton = ";[UIA]ClassName='RadioButton' && Name = 'Show top results'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ShowBottomResultsRadioButton query id
            /// TOOD: needs load resource string for the name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowBottomResultsRadioButton = ";[UIA]ClassName='RadioButton' && Name = 'Show bottom results'";
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the NumericUPDown time value control resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NumericUPDown
            {
                get
                {
                    return new QID(ResourceNumericUpDown);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the LastTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID LastTextBox
            {
                get
                {
                    return new QID(ResourceLastTextBox);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the MaximumResultsToShowTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MaximumResultsToShowTextBox
            {
                get
                {
                    return new QID(ResourceMaximumResultsToShowTextBox);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the MaximumResultsToShowTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TimeComboBox
            {
                get
                {
                    return new QID(ResourceTimeComboBox);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
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
            ///   [v-vijia] 8/11/2011 Created
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
            ///   [v-vijia] 8/11/2011 Created
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
            ///   [v-vijia] 8/11/2011 Created
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
            /// Gets access to the ResourceShowTopResultsRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowTopResultsRadioButton
            {
                get
                {
                    return new QID(ResourceShowTopResultsRadioButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowBottomResultsRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowBottomResultsRadioButton
            {
                get
                {
                    return new QID(ResourceShowBottomResultsRadioButton);
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
        ///   [v-vijia] 8/11/2011 Created
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
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = "New Instance Wizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = "< Previous";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = "Next >";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = "Finish";

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
            ///   [v-vijia] 8/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
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
            ///   [v-vijia] 8/11/2011 Created
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
            /// Gets access to the Finish translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [v-vijia] 8/11/2011 Created
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
