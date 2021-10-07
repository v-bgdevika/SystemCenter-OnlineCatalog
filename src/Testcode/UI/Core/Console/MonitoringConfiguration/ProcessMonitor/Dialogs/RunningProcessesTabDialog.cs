// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunningProcessesTabDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-brucec] 4/28/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.ProcessMonitor.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    #region Interface Definition - IRunningProcessesPageDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunningProcessesPageDialogControls, for RunningProcessesTabDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-brucec] 4/28/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunningProcessesPageDialogControls
    {
        /// <summary>
        /// Gets read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Gets read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DurationUnitNumInstancesComboBox
        /// </summary>
        ComboBox DurationUnitNumInstancesComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DurationValNumInstancesComboBox
        /// </summary>
        EditComboBox DurationValNumInstancesComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DurationUnitRuntimeComboBox
        /// </summary>
        ComboBox DurationUnitRuntimeComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DurationValRuntimeComboBox
        /// </summary>
        EditComboBox DurationValRuntimeComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MaximumInstancesComboBox
        /// </summary>
        EditComboBox MaximumInstancesComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MinimumInstancesComboBox
        /// </summary>
        EditComboBox MinimumInstancesComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DurationRadioButton
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        RadioButton DurationRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NumInstancesRadioButton
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        RadioButton NumInstancesRadioButton
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
    ///   [v-brucec] 4/28/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class RunningProcessesTabDialog : Dialog, IRunningProcessesPageDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;

        /// <summary>
        /// Cache to hold a reference to DurationUnitNumInstancesComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDurationUnitNumInstancesComboBox;

        /// <summary>
        /// Cache to hold a reference to DurationValNumInstancesComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedDurationValNumInstancesComboBox;

        /// <summary>
        /// Cache to hold a reference to DurationUnitRuntimeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDurationUnitRuntimeComboBox;

        /// <summary>
        /// Cache to hold a reference to DurationValRuntimeComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedDurationValRuntimeComboBox;

        /// <summary>
        /// Cache to hold a reference to MaximumInstancesComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedMaximumInstancesComboBox;

        /// <summary>
        /// Cache to hold a reference to MinimumInstancesComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedMinimumInstancesComboBox;

        /// <summary>
        /// Cache to hold a reference to DurationRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDurationRadioButton;

        /// <summary>
        /// Cache to hold a reference to NumInstancesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedNumInstancesRadioButton;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the RunningProcessesTabDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of RunningProcessesTabDialog of type App
        /// </param>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunningProcessesTabDialog(App app) :
            base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Previous Previous
        {
            get
            {
                if ((this.Controls.DurationRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Previous.DurationRadioButton;
                }

                if ((this.Controls.NumInstancesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Previous.NumInstancesRadioButton;
                }

                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == Previous.DurationRadioButton))
                {
                    this.Controls.DurationRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Previous.NumInstancesRadioButton))
                    {
                        this.Controls.NumInstancesRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region IRunningProcessesTabDialogControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunningProcessesPageDialogControls Controls
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
        ///  Routine to set/get the text in control MonitoringType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DurationUnitNumInstancesText
        {
            get
            {
                return this.Controls.DurationUnitNumInstancesComboBox.Text;
            }

            set
            {
                this.Controls.DurationUnitNumInstancesComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DurationValNumInstancesText
        {
            get
            {
                return this.Controls.DurationValNumInstancesComboBox.Text;
            }

            set
            {
                this.Controls.DurationValNumInstancesComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DurationUnitRuntime
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DurationUnitRuntimeText
        {
            get
            {
                return this.Controls.DurationUnitRuntimeComboBox.Text;
            }

            set
            {
                this.Controls.DurationUnitRuntimeComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType4
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DurationValRuntimeText
        {
            get
            {
                return this.Controls.DurationValRuntimeComboBox.Text;
            }

            set
            {
                this.Controls.DurationValRuntimeComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType5
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaximumInstancesText
        {
            get
            {
                return this.Controls.MaximumInstancesComboBox.Text;
            }

            set
            {
                this.Controls.MaximumInstancesComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType6
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MinimumInstancesText
        {
            get
            {
                return this.Controls.MinimumInstancesComboBox.Text;
            }

            set
            {
                this.Controls.MinimumInstancesComboBox.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ApplyButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunningProcessesPageDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, RunningProcessesTabDialog.ControlIDs.ApplyButton);
                }

                return this.cachedApplyButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunningProcessesPageDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RunningProcessesTabDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunningProcessesPageDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, RunningProcessesTabDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Tab2TabControl control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRunningProcessesPageDialogControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, RunningProcessesTabDialog.ControlIDs.Tab2TabControl);
                }

                return this.cachedTab2TabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationUnitNumInstancesComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRunningProcessesPageDialogControls.DurationUnitNumInstancesComboBox
        {
            get
            {
                if ((this.cachedDurationUnitNumInstancesComboBox == null))
                {
                    this.cachedDurationUnitNumInstancesComboBox = new ComboBox(this, RunningProcessesDialog.ControlIDs.DurationUnitNumInstancesComboBox);
                }

                return this.cachedDurationUnitNumInstancesComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationValNumInstancesComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunningProcessesPageDialogControls.DurationValNumInstancesComboBox
        {
            get
            {
                if ((this.cachedDurationValNumInstancesComboBox == null))
                {
                    this.cachedDurationValNumInstancesComboBox = new EditComboBox(this, RunningProcessesDialog.ControlIDs.DurationValNumInstancesComboBox);
                }

                return this.cachedDurationValNumInstancesComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationUnitRuntimeComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRunningProcessesPageDialogControls.DurationUnitRuntimeComboBox
        {
            get
            {
                // The ID for this control (comboBoxUnit) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDurationUnitRuntimeComboBox == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDurationUnitRuntimeComboBox = new ComboBox(wndTemp);
                }

                return this.cachedDurationUnitRuntimeComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationValRuntimeComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunningProcessesPageDialogControls.DurationValRuntimeComboBox
        {
            get
            {
                // The ID for this control (numericDropDown) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDurationValRuntimeComboBox == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedDurationValRuntimeComboBox = new EditComboBox(wndTemp);
                }

                return this.cachedDurationValRuntimeComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumInstancesComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunningProcessesPageDialogControls.MaximumInstancesComboBox
        {
            get
            {
                if ((this.cachedMaximumInstancesComboBox == null))
                {
                    this.cachedMaximumInstancesComboBox = new EditComboBox(this, RunningProcessesDialog.ControlIDs.MaximumInstancesComboBox);
                }

                return this.cachedMaximumInstancesComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumInstancesComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunningProcessesPageDialogControls.MinimumInstancesComboBox
        {
            get
            {
                if ((this.cachedMinimumInstancesComboBox == null))
                {
                    this.cachedMinimumInstancesComboBox = new EditComboBox(this, RunningProcessesDialog.ControlIDs.MinimumInstancesComboBox);
                }

                return this.cachedMinimumInstancesComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationRadioButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IRunningProcessesPageDialogControls.DurationRadioButton
        {
            get
            {
                if ((this.cachedDurationRadioButton == null))
                {
                    this.cachedDurationRadioButton = new RadioButton(this, RunningProcessesDialog.ControlIDs.DurationRadioButton);
                }

                return this.cachedDurationRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumInstancesRadioButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IRunningProcessesPageDialogControls.NumInstancesRadioButton
        {
            get
            {
                if ((this.cachedNumInstancesRadioButton == null))
                {
                    this.cachedNumInstancesRadioButton = new RadioButton(this, RunningProcessesDialog.ControlIDs.NumInstancesRadioButton);
                }

                return this.cachedNumInstancesRadioButton;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 40;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);

                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
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
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabPages";

            /// <summary>
            /// Control ID for DurationUnitNumInstancesComboBox
            /// </summary>
            public const string DurationUnitNumInstancesComboBox = "comboBoxUnit";

            /// <summary>
            /// Control ID for DurationValNumInstancesComboBox
            /// </summary>
            public const string DurationValNumInstancesComboBox = "numericDropDown";

            /// <summary>
            /// Control ID for DurationUnitRuntimeComboBox
            /// </summary>
            public const string DurationUnitRuntimeComboBox = "comboBoxUnit";

            /// <summary>
            /// Control ID for DurationValRuntimeComboBox
            /// </summary>
            public const string DurationValRuntimeComboBox = "numericDropDown";

            /// <summary>
            /// Control ID for MaximumInstancesComboBox
            /// </summary>
            public const string MaximumInstancesComboBox = "numericUpDownMax";

            /// <summary>
            /// Control ID for MinimumInstancesComboBox
            /// </summary>
            public const string MinimumInstancesComboBox = "numericUpDownMin";

            /// <summary>
            /// Control ID for DurationRadioButton
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string DurationRadioButton = "radioButtonProcessRunningTime";

            /// <summary>
            /// Control ID for NumInstancesRadioButton
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string NumInstancesRadioButton = "radioButtonProcessInstanceCount";
        }
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Private Members

            private static string cachedDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-brucec] 4/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = Templates.Strings.PropertiesDialogTitle;
                    }

                    return cachedDialogTitle;
                }
            }
            #endregion
        }
        #endregion
    }
}
