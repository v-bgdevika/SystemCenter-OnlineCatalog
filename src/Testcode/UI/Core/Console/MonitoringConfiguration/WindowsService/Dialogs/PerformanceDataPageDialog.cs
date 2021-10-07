// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceDataPageDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Performance Data Tab Page of Windows Service Template Properties.
// </summary>
// <history>
//   [v-brucec] 11/20/2009 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    using System.Globalization;
    
    #region Interface Definition - IPerformanceDataPageDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceDataPageDialogControls, for PerformanceDataPageDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-brucec] 11/20/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceDataPageDialogControls
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
        /// Gets read-only property to access TabControlCollection
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl TabControlCollection
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NumSamplesComboBox
        /// </summary>
        EditComboBox NumSamplesComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NumBytesComboBox
        /// </summary>
        EditComboBox NumBytesComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PercentProcTimeComboBox
        /// </summary>
        EditComboBox PercentProcTimeComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access IntervalUnitComboBox
        /// </summary>
        ComboBox IntervalUnitComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access IntervalThresholdComboBox
        /// </summary>
        EditComboBox IntervalThresholdComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PrivateBytesAlertThresholdMBCheckBox
        /// </summary>
        CheckBox PrivateBytesThresholdCheckBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ProcessorTimeAlertThresholdPercentCheckBox
        /// </summary>
        CheckBox ProcessorTimeThresholdCheckBox
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
    ///   [v-brucec] 11/20/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class PerformanceDataPageDialog : Dialog, IPerformanceDataPageDialogControls
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
        /// Cache to hold a reference to TabControlCollection of type TabControl
        /// </summary>
        private TabControl cachedTabControlCollection;

        /// <summary>
        /// Cache to hold a reference to NumSamplesComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedNumSamplesComboBox;

        /// <summary>
        /// Cache to hold a reference to NumBytesComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedNumBytesComboBox;

        /// <summary>
        /// Cache to hold a reference to PercentProcTimeComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedPercentProcTimeComboBox;

        /// <summary>
        /// Cache to hold a reference to IntervalUnitComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedIntervalUnitComboBox;

        /// <summary>
        /// Cache to hold a reference to IntervalThresholdComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedIntervalThresholdComboBox;

        /// <summary>
        /// Cache to hold a reference to PrivateBytesAlertThresholdMBCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedPrivateBytesThresholdCheckBox;

        /// <summary>
        /// Cache to hold a reference to ProcessorTimeAlertThresholdPercentCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedProcessorTimeThresholdCheckBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the PerformanceDataPageDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceDataPageDialog of type App
        /// </param>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceDataPageDialog(App app) :
            base(app, Init(app))
        {

        }
        #endregion
        
        #region IPerformanceDataPageDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceDataPageDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        public virtual bool PrivateBytesThreshold
        {
            get
            {
                return this.Controls.PrivateBytesThresholdCheckBox.Checked;
            }

            set
            {
                this.Controls.PrivateBytesThresholdCheckBox.Checked = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ProcessorTimeAlertThresholdPercent
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ProcessorTimeThreshold
        {
            get
            {
                return this.Controls.ProcessorTimeThresholdCheckBox.Checked;
            }

            set
            {
                this.Controls.ProcessorTimeThresholdCheckBox.Checked = value;
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
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NumSamplesText
        {
            get
            {
                return this.Controls.NumSamplesComboBox.Text;
            }

            set
            {
                this.Controls.NumSamplesComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NumBytes
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NumBytesText
        {
            get
            {
                return this.Controls.NumBytesComboBox.Text;
            }

            set
            {
                this.Controls.NumBytesComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PercentProcTime
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PercentProcTimeText
        {
            get
            {
                return this.Controls.PercentProcTimeComboBox.Text;
            }

            set
            {
                this.Controls.PercentProcTimeComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IntervalUnit
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IntervalUnitText
        {
            get
            {
                return this.Controls.IntervalUnitComboBox.Text;
            }

            set
            {
                this.Controls.IntervalUnitComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IntervalThreshold
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IntervalThresholdText
        {
            get
            {
                return this.Controls.IntervalThresholdComboBox.Text;
            }

            set
            {
                this.Controls.IntervalThresholdComboBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ApplyButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDataPageDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, PerformanceDataPageDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDataPageDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerformanceDataPageDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDataPageDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, PerformanceDataPageDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TabControlCollection control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IPerformanceDataPageDialogControls.TabControlCollection
        {
            get
            {
                if ((this.cachedTabControlCollection == null))
                {
                    this.cachedTabControlCollection = new TabControl(this, PerformanceDataPageDialog.ControlIDs.TabControlCollection);
                }

                return this.cachedTabControlCollection;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumSamplesComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceDataPageDialogControls.NumSamplesComboBox
        {
            get
            {
                if ((this.cachedNumSamplesComboBox == null))
                {
                    this.cachedNumSamplesComboBox = new EditComboBox(this, PerformanceDataPageDialog.ControlIDs.NumSamplesComboBox);
                }

                return this.cachedNumSamplesComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumBytesComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceDataPageDialogControls.NumBytesComboBox
        {
            get
            {
                if ((this.cachedNumBytesComboBox == null))
                {
                    this.cachedNumBytesComboBox = new EditComboBox(this, PerformanceDataPageDialog.ControlIDs.NumBytesComboBox);
                }

                return this.cachedNumBytesComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PercentProcTimeComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceDataPageDialogControls.PercentProcTimeComboBox
        {
            get
            {
                if ((this.cachedPercentProcTimeComboBox == null))
                {
                    this.cachedPercentProcTimeComboBox = new EditComboBox(this, PerformanceDataPageDialog.ControlIDs.PercentProcTimeComboBox);
                }

                return this.cachedPercentProcTimeComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalUnitComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDataPageDialogControls.IntervalUnitComboBox
        {
            get
            {
                if ((this.cachedIntervalUnitComboBox == null))
                {
                    this.cachedIntervalUnitComboBox = new ComboBox(this, PerformanceDataPageDialog.ControlIDs.IntervalUnitComboBox);
                }

                return this.cachedIntervalUnitComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalThresholdComboBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceDataPageDialogControls.IntervalThresholdComboBox
        {
            get
            {
                if ((this.cachedIntervalThresholdComboBox == null))
                {
                    this.cachedIntervalThresholdComboBox = new EditComboBox(this, PerformanceDataPageDialog.ControlIDs.IntervalThresholdComboBox);
                }

                return this.cachedIntervalThresholdComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PrivateBytesAlertThresholdMBCheckBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceDataPageDialogControls.PrivateBytesThresholdCheckBox
        {
            get
            {
                if ((this.cachedPrivateBytesThresholdCheckBox == null))
                {
                    this.cachedPrivateBytesThresholdCheckBox = new CheckBox(this, PerformanceDataPageDialog.ControlIDs.PrivateBytesThresholdCheckBox);
                }

                return this.cachedPrivateBytesThresholdCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProcessorTimeAlertThresholdPercentCheckBox control
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceDataPageDialogControls.ProcessorTimeThresholdCheckBox
        {
            get
            {
                if ((this.cachedProcessorTimeThresholdCheckBox == null))
                {
                    this.cachedProcessorTimeThresholdCheckBox = new CheckBox(this, PerformanceDataPageDialog.ControlIDs.ProcessorTimeThresholdCheckBox);
                }

                return this.cachedProcessorTimeThresholdCheckBox;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PrivateBytesAlertThresholdMB
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrivateBytesThreshold()
        {
            this.Controls.PrivateBytesThresholdCheckBox.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ProcessorTimeAlertThresholdPercent
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickProcessorTimeThreshold()
        {
            this.Controls.ProcessorTimeThresholdCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
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
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("PerformanceDataPageDialog.Init :: Attempt "
                            + numberOfTries
                            + " of "
                            + maxTries
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
        ///   [v-brucec] 11/20/2009 Created
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
            /// Control ID for TabControlCollection
            /// </summary>
            public const string TabControlCollection = "tabPages";

            /// <summary>
            /// Control ID for NumSamplesComboBox
            /// </summary>
            public const string NumSamplesComboBox = "numericUpDownSampleCount";

            /// <summary>
            /// Control ID for NumBytesComboBox
            /// </summary>
            public const string NumBytesComboBox = "numericUpDownMemoryThreshold";

            /// <summary>
            /// Control ID for PercentProcTimeComboBox
            /// </summary>
            public const string PercentProcTimeComboBox = "numericUpDownProcessorThreshold";

            /// <summary>
            /// Control ID for IntervalUnitComboBox
            /// </summary>
            public const string IntervalUnitComboBox = "comboBoxUnit";

            /// <summary>
            /// Control ID for IntervalThresholdComboBox
            /// </summary>
            public const string IntervalThresholdComboBox = "numericDropDown";

            /// <summary>
            /// Control ID for PrivateBytesAlertThresholdMBCheckBox
            /// </summary>
            public const string PrivateBytesThresholdCheckBox = "checkBoxMemoryUsage";

            /// <summary>
            /// Control ID for ProcessorTimeAlertThresholdPercentCheckBox
            /// </summary>
            public const string ProcessorTimeThresholdCheckBox = "checkBoxProcessorTime";
        }
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-brucec] 11/20/2009 Created
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
            ///   [v-brucec] 11/20/2009 Created
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