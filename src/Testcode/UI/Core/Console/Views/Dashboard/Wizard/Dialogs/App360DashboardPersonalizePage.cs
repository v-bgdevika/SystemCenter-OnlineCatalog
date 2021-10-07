namespace Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.Dialogs
{
    using System;
    using System.ComponentModel;
    using System.Text;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;

    public class App360DashboardPersonalizePage : Dialog
    {
        #region Private Members
        /// <summary>
        /// The timeout used for initializing controls
        /// </summary>
        private const int TIME_OUT = 5000;

        /// <summary>
        /// Cache to hold a reference to TimeOffset value textbox
        /// </summary>
        private TextBox cachedTimeValueText;

        /// <summary>
        /// Cache to hold a reference to increment button for TimeOffset
        /// </summary>
        private Button cachedIncrementButton;

        /// <summary>
        /// Cache to hold a reference to decrement button for TimeOffset
        /// </summary>
        private Button cachedDecrementButton;

        /// <summary>
        /// Cache to hold a reference to TimeOffset type combo box
        /// </summary>
        private ComboBox cachedTimeOffsetTypeComboBox;

        /// <summary>
        /// Cache to hold a reference to Finish button
        /// </summary>
        private Button cachedFinishButton;

        /// <summary>
        /// Cache to hold a reference to Cancel button
        /// </summary>
        private Button cachedCancelButton;

        #endregion

        #region Constructors

        public App360DashboardPersonalizePage(MomConsoleApp app, int timeout, string dialogTitle)
            : base(app, Init(app, timeout, dialogTitle))
        {
        }

        #endregion

        #region Control Properties
        /// <summary>
        /// Get access to the TimeValue textbox
        /// </summary>
        public TextBox TimeValueText
        {
            get
            {
                if (this.cachedTimeValueText == null)
                {
                    this.cachedTimeValueText = new TextBox(this, new QID(";[UIA]AutomationId = 'valueText'"), TIME_OUT);
                }
                return this.cachedTimeValueText;
            }
        }

        /// <summary>
        /// Get access to the increment button
        /// </summary>
        public Button IncrementButton
        {
            get
            {
                if (this.cachedIncrementButton == null)
                {
                    this.cachedIncrementButton = new Button(this, new QID(";[UIA]AutomationId = 'upButton'"), TIME_OUT);
                }
                return this.cachedIncrementButton;
            }
        }

        /// <summary>
        /// Get access to the decrement button
        /// </summary>
        public Button DecrementButton
        {
            get
            {
                if (this.cachedDecrementButton == null)
                {
                    this.cachedDecrementButton = new Button(this, new QID(";[UIA]AutomationId = 'downButton'"), TIME_OUT);
                }
                return this.cachedDecrementButton;
            }
        }

        /// <summary>
        /// Get access to the TimeOffset type combo box
        /// </summary>
        public ComboBox TimeOffsetTypeComboBox
        {
            get
            {
                if (this.cachedTimeOffsetTypeComboBox == null)
                {
                    this.cachedTimeOffsetTypeComboBox = new ComboBox(this, new QID(";[UIA]ClassName = 'ComboBox'"), TIME_OUT);
                }
                return this.cachedTimeOffsetTypeComboBox;
            }
        }

        /// <summary>
        /// Get access to the Finish button
        /// </summary>
        public Button FinishButton
        {
            get
            {
                if (this.cachedFinishButton == null)
                {
                    this.cachedFinishButton = new Button(this, new QID(";[UIA]AutomationId = 'WizardCloseButton'"), TIME_OUT);
                }
                return this.cachedFinishButton;
            }
        }

        /// <summary>
        /// Get access to the Cancel button
        /// </summary>
        public Button CancelButton
        {
            get
            {
                if (this.cachedCancelButton == null)
                {
                    this.cachedCancelButton = new Button(this, new QID(";[UIA]AutomationId = 'WizardCancelButton'"), TIME_OUT);
                }
                return this.cachedCancelButton;
            }
        }

        #endregion

        #region Text Field Properties
        /// <summary>
        /// Get or set the value for TimeOffset
        /// </summary>
        public int TimeOffset
        {
            get
            {
                return Convert.ToInt32(this.TimeValueText.Text.Trim());
            }
            set
            {
                this.TimeValueText.Text = value.ToString();
            }
        }

        /// <summary>
        /// Get or set index of the type for TimeOffset
        /// </summary>
        public int TimeOffsetTypeIndex
        {
            get
            {
                return this.TimeOffsetTypeComboBox.SelectedIndex;
            }
            set
            {
                this.TimeOffsetTypeComboBox.SelectByIndex(value);
            }
        }

        #endregion

        #region Click Methods
        /// <summary>
        /// Click on Finish button
        /// </summary>
        public void ClickFinish()
        {
            this.FinishButton.Click();
        }

        /// <summary>
        /// Click on Cancel button
        /// </summary>
        public void ClickCancel()
        {
            this.CancelButton.Click();
        }

        #endregion

        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <param name="app">MomConsoleApp owning the dialog</param>
        /// <param name="timeOut">timeout</param>
        /// <param name="DialogTitle">title of the dialog</param>
        /// <returns>A reference to the dialog's Window</returns>
        private static Window Init(App app, int timeOut, string DialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(new QID(";[UIA]Name = '" + DialogTitle + "' && Role = 'window'"), timeOut);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Utilities.LogMessage("Failed to find window with title: " + DialogTitle);

                    // rethrow the original exception
                    throw;
                }
            }

            return tempWindow;
        }
    }
}
