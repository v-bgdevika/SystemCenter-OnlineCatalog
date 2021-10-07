// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceDataDialog.cs">
//   Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [bretlink] 9/9/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    using System;
    
    #region Interface Definition - IPerformanceDataDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceDataDialogControls, for PerformanceDataDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [bretlink] 9/9/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceDataDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
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
    ///   [bretlink] 9/9/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class PerformanceDataDialog : Dialog, IPerformanceDataDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
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
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
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
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceDataDialog of type App
        /// </param>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceDataDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IPerformanceDataDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceDataDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox PrivateBytesAlertThresholdMB
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
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
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
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
                this.Controls.NumSamplesComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NumBytes
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
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
                this.Controls.NumBytesComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PercentProcTime
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
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
                this.Controls.PercentProcTimeComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IntervalUnit
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
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
                this.Controls.IntervalThresholdComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDataDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, PerformanceDataDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDataDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, PerformanceDataDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDataDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, PerformanceDataDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceDataDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerformanceDataDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumSamplesComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceDataDialogControls.NumSamplesComboBox
        {
            get
            {
                if ((this.cachedNumSamplesComboBox == null))
                {
                    this.cachedNumSamplesComboBox = new EditComboBox(this, PerformanceDataDialog.ControlIDs.NumSamplesComboBox);
                }
                
                return this.cachedNumSamplesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumBytesComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceDataDialogControls.NumBytesComboBox
        {
            get
            {
                if ((this.cachedNumBytesComboBox == null))
                {
                    this.cachedNumBytesComboBox = new EditComboBox(this, PerformanceDataDialog.ControlIDs.NumBytesComboBox);
                }
                
                return this.cachedNumBytesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PercentProcTimeComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceDataDialogControls.PercentProcTimeComboBox
        {
            get
            {
                if ((this.cachedPercentProcTimeComboBox == null))
                {
                    this.cachedPercentProcTimeComboBox = new EditComboBox(this, PerformanceDataDialog.ControlIDs.PercentProcTimeComboBox);
                }
                
                return this.cachedPercentProcTimeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalUnitComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceDataDialogControls.IntervalUnitComboBox
        {
            get
            {
                if ((this.cachedIntervalUnitComboBox == null))
                {
                    this.cachedIntervalUnitComboBox = new ComboBox(this, PerformanceDataDialog.ControlIDs.IntervalUnitComboBox);
                }
                
                return this.cachedIntervalUnitComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalThresholdComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceDataDialogControls.IntervalThresholdComboBox
        {
            get
            {
                if ((this.cachedIntervalThresholdComboBox == null))
                {
                    this.cachedIntervalThresholdComboBox = new EditComboBox(this, PerformanceDataDialog.ControlIDs.IntervalThresholdComboBox);
                }
                
                return this.cachedIntervalThresholdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PrivateBytesAlertThresholdMBCheckBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceDataDialogControls.PrivateBytesThresholdCheckBox
        {
            get
            {
                if ((this.cachedPrivateBytesThresholdCheckBox == null))
                {
                    this.cachedPrivateBytesThresholdCheckBox = new CheckBox(this, PerformanceDataDialog.ControlIDs.PrivateBytesThresholdCheckBox);
                }
                
                return this.cachedPrivateBytesThresholdCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProcessorTimeAlertThresholdPercentCheckBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceDataDialogControls.ProcessorTimeThresholdCheckBox
        {
            get
            {
                if ((this.cachedProcessorTimeThresholdCheckBox == null))
                {
                    this.cachedProcessorTimeThresholdCheckBox = new CheckBox(this, PerformanceDataDialog.ControlIDs.ProcessorTimeThresholdCheckBox);
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
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PrivateBytesAlertThresholdMB
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
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
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
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
        ///   [bretlink] 9/9/2008 Created
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommon" +
                "Resources;TemplateWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PrivateBytesThreshold
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrivateBytesThreshold = @";G&enerate an alert if the RAM uage rises above the specified percentage;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerformanceDataCollectionAndDetectionPage;checkBoxMemoryUsage.Text";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProcessorTimeThreshold
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceProcessorTimeThreshold = @";&Generate an alert if the CPU usage rises above the specified percentage;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerformanceDataCollectionAndDetectionPage;checkBoxProcessorTime.Text";

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
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PrivateBytesThreshold
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrivateBytesThreshold;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProcessorTimeAlertThresholdPercent
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProcessorTimeThreshold;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    
                    return cachedPrevious;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    
                    return cachedNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    
                    return cachedCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    
                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PrivateBytesAlertThresholdMB translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PrivateBytesThreshold
            {
                get
                {
                    if ((cachedPrivateBytesThreshold == null))
                    {
                        cachedPrivateBytesThreshold = CoreManager.MomConsole.GetIntlStr(ResourcePrivateBytesThreshold);
                    }
                    
                    return cachedPrivateBytesThreshold;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProcessorTimeAlertThresholdPercent translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProcessorTimeThreshold
            {
                get
                {
                    if ((cachedProcessorTimeThreshold == null))
                    {
                        cachedProcessorTimeThreshold = CoreManager.MomConsole.GetIntlStr(ResourceProcessorTimeThreshold);
                    }
                    
                    return cachedProcessorTimeThreshold;
                }
            }
            #endregion
        }
        #endregion
    }
}
