// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ThresholdSettingsDialog.cs">
//   Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Threshold Settings Dialog for WMI Performance Counter monitor
// </summary>
// <history>
//   [v-cheli] 12/24/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IThresholdSettingsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IThresholdSettingsDialogControls, for ThresholdSettingsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-cheli] 12/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IThresholdSettingsDialogControls
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
        /// Read-only property to access NumberOfSamples
        /// </summary>
        TextBox NumberOfSamples
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThresholdValue
        /// </summary>
        TextBox ThresholdValue
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Value
        /// </summary>
        ComboBox Value
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold
        /// </summary>
        TextBox SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PercentageCheckBox
        /// </summary>
        CheckBox PercentageCheckBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access HighValueOfThreshold
        /// </summary>
        TextBox HighValueOfThreshold
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LowValueOfThreshold
        /// </summary>
        TextBox LowValueOfThreshold
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
    ///   [v-cheli] 12/24/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class ThresholdSettingsDialog : Dialog, IThresholdSettingsDialogControls
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
        /// Cache to hold a reference to NumberOfSamples of type TextBox
        /// </summary>
        private TextBox cachedNumberOfSamples;
        
        /// <summary>
        /// Cache to hold a reference to ThresholdValue of type TextBox
        /// </summary>
        private TextBox cachedThresholdValue;

        /// <summary>
        /// Cache to hold a reference to Value of type ComboBox
        /// </summary>
        private ComboBox cachedValue;

        /// <summary>
        /// Cache to hold a reference to SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold of type TextBox
        /// </summary>
        private TextBox cachedSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold;

        /// <summary>
        /// Cache to hold a reference to PercentageCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedPercentageCheckBox;

        /// <summary>
        /// Cache to hold a reference to HighValueOfThreshold of type TextBox
        /// </summary>
        private TextBox cachedHighValueOfThreshold;

        /// <summary>
        /// Cache to hold a reference to LowValueOfThreshold of type TextBox
        /// </summary>
        private TextBox cachedLowValueOfThreshold; 
        
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ThresholdSettingsDialog of type Maui.Core.App
        /// </param>
        ///  <param name='windowCaption'>Dialog Title </param>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ThresholdSettingsDialog(Maui.Core.App app, MonitoringConfiguration.WindowCaptions windowCaption) :
            base(app, Init(app, windowCaption))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IThresholdSettingsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IThresholdSettingsDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Text Field Proerties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ThresholdValue
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-cheli] 24DEC08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ThresholdValueText
        {
            get
            {
                return this.Controls.ThresholdValue.Text;
            }
            set
            {
                this.Controls.ThresholdValue.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NumberOfSamples
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-cheli] 24DEC08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NumberOfSamplesText
        {
            get
            {
                return this.Controls.NumberOfSamples.Text;
            }
            set
            {
                this.Controls.NumberOfSamples.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control HighValueOfThreshold
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-cheli] 24DEC08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HighValueOfThresholdText
        {
            get
            {
                return this.Controls.HighValueOfThreshold.Text;
            }
            set
            {
                this.Controls.HighValueOfThreshold.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LowValueOfThreshold
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-cheli] 24DEC08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LowValueOfThresholdText
        {
            get
            {
                return this.Controls.LowValueOfThreshold.Text;
            }
            set
            {
                this.Controls.LowValueOfThreshold.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-cheli] 24DEC08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheNumberOfSamplesUsedToCompareWithTheThresholdText
        {
            get
            {
                return this.Controls.SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold.Text;
            }
            set
            {
                this.Controls.SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IThresholdSettingsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ThresholdSettingsDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IThresholdSettingsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ThresholdSettingsDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IThresholdSettingsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ThresholdSettingsDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IThresholdSettingsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ThresholdSettingsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumberOfSamples control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IThresholdSettingsDialogControls.NumberOfSamples
        {
            get
            {
                if ((this.cachedNumberOfSamples == null))
                {
                    this.cachedNumberOfSamples = new TextBox(this, ThresholdSettingsDialog.ControlIDs.NumberOfSamples);
                }
                
                return this.cachedNumberOfSamples;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThresholdValue control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IThresholdSettingsDialogControls.ThresholdValue
        {
            get
            {
                if ((this.cachedThresholdValue == null))
                {
                    this.cachedThresholdValue = new TextBox(this, ThresholdSettingsDialog.ControlIDs.ThresholdValue);
                }
                
                return this.cachedThresholdValue;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Value control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IThresholdSettingsDialogControls.Value
        {
            get
            {
                if ((this.cachedValue == null))
                {
                    this.cachedValue = new ComboBox(this, ThresholdSettingsDialog.ControlIDs.Value);
                }

                return this.cachedValue;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IThresholdSettingsDialogControls.SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold
        {
            get
            {
                if ((this.cachedSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold == null))
                {
                    this.cachedSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold = new TextBox(this, ThresholdSettingsDialog.ControlIDs.SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold);
                }

                return this.cachedSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PercentageCheckBox control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IThresholdSettingsDialogControls.PercentageCheckBox
        {
            get
            {
                if ((this.cachedPercentageCheckBox == null))
                {
                    this.cachedPercentageCheckBox = new CheckBox(this, ThresholdSettingsDialog.ControlIDs.PercentageCheckBox);
                }

                return this.cachedPercentageCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighValueOfThreshold control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IThresholdSettingsDialogControls.HighValueOfThreshold
        {
            get
            {
                if ((this.cachedHighValueOfThreshold == null))
                {
                    this.cachedHighValueOfThreshold = new TextBox(this, ThresholdSettingsDialog.ControlIDs.HighValueOfThreshold);
                }

                return this.cachedHighValueOfThreshold;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowValueOfThreshold control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IThresholdSettingsDialogControls.LowValueOfThreshold
        {
            get
            {
                if ((this.cachedLowValueOfThreshold == null))
                {
                    this.cachedLowValueOfThreshold = new TextBox(this, ThresholdSettingsDialog.ControlIDs.LowValueOfThreshold);
                }

                return this.cachedLowValueOfThreshold;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
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
        ///   [v-cheli] 12/24/2008 Created
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
        ///   [v-cheli] 12/24/2008 Created
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
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Percentage
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPercentage()
        {
            this.Controls.PercentageCheckBox.Click();
        }

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">Maui.Core.App owning the dialog.</param>
        ///  <param name='windowCaption'>Dialog Title </param>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app, MonitoringConfiguration.WindowCaptions windowCaption)
        {
            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(DialogTitle, StringMatchSyntax.WildCard);

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
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
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
            /// Control ID for NumberOfSamples
            /// </summary>
            public const string NumberOfSamples = "numSamplesUpDown";
            
            /// <summary>
            /// Control ID for ThresholdValue
            /// </summary>
            public const string ThresholdValue = "thresholdNumericUpDown";

            /// <summary>
            /// Control ID for Value
            /// </summary>
            public const string Value = "operatorComboBox";

            /// <summary>
            /// Control ID for SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold
            /// </summary>
            public const string SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold = "thresholdUpDown";

            /// <summary>
            /// Control ID for PercentageCheckBox
            /// </summary>
            public const string PercentageCheckBox = "percentageCheckBox";

            /// <summary>
            /// Control ID for HighValueOfThreshold
            /// </summary>
            public const string HighValueOfThreshold = "thresholdUpDown2";

            /// <summary>
            /// Control ID for LowValueOfThreshold
            /// </summary>
            public const string LowValueOfThreshold = "thresholdUpDown1";
            
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/24/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Create a unit monitor
            /// </summary>
            public const string ResourceDialogTitle = ";Create a unit monitor;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKReso" +
                "urces;CreateMonitorWizard";
            
            /// <summary>
            /// Resource string for Previous
            /// </summary>
            public const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// <summary>
            /// Resource string for Next >
            /// </summary>
            public const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// <summary>
            /// Resource string for Create
            /// </summary>
            public const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// <summary>
            /// Resource string for Number of samples:
            /// </summary>
            public const string ResourceNumberOfSamples = ";Number of samples;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ThresholdPage;pageSectionLabel2.Text";
            
            /// <summary>
            /// Resource string for Threshold value:
            /// </summary>
            public const string ResourceThresholdValue = ";Threshold &value:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ThresholdPage;thresholdValueLabel.Text";

            /// <summary>
            /// Resource string for Value
            /// </summary>
            public const string ResourceValue = ";Value;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerformanceMapper.PerformanceMapperPageResource;ValueTitleText";

            /// <summary>
            /// Resource string for Specify the number of samples used to compare with the threshold.
            /// </summary>
            public const string ResourceSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold = ";Specify the number of samples used to compare with the threshold.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ThresholdComparisionPage;label4.Text";

            /// <summary>
            /// Resource string for Percentage
            /// </summary>
            public const string ResourcePercentage = ";Percentage;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;AlgorithmPercentage";

            /// <summary>
            /// Resource string for High value of threshold:
            /// </summary>
            public const string ResourceHighValueOfThreshold = ";Hi&gh value of threshold:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DoubleThresholdPage;label2.Text";

            /// <summary>
            /// Resource string for Low value of threshold
            /// </summary>
            public const string ResourceLowValueOfThreshold = ";Low &value of threshold;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DoubleThresholdPage;label3.Text";

            /// <summary>
            /// Resource string for less than or equals
            /// </summary>
            public const string ResourceLessThanOrEquals = ";less than or equals;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Threshold.ThresholdResources;LessThanOrEqual";

            /// <summary>
            /// Resource string for greater than or equals
            /// </summary>
            public const string ResourceGreaterThanOrEquals = ";greater than or equals;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Threshold.ThresholdResources;GreaterThanOrEqual";

            /// <summary>
            /// Resource string for greater than
            /// </summary>
            public const string ResourceGreaterThan = ";greater than;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Threshold.ThresholdResources;GreaterThan";

            /// <summary>
            /// Resource string for less than
            /// </summary>
            public const string ResourceLessThan = ";less than;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Threshold.ThresholdResources;LessThan";
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
            /// Caches the translated Resource string for Number of samples:
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNumberOfSamples;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Threshold value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThresholdValue;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedValue;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Specify the number of samples used to compare with the threshold.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Percentage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPercentage;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  High value of threshold
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHighValueOfThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Low value of threshold
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLowValueOfThreshold;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  greater than
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGreaterThan;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  less than
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLessThan;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  greater than or equals
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGreaterThanOrEquals;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  less than or equals
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLessThanOrEquals;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 04Feb09 Created
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
            /// 	[v-cheli] 04Feb09 Created
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
            /// 	[v-cheli] 04Feb09 Created
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
            /// 	[v-cheli] 04Feb09 Created
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
            /// 	[v-cheli] 04Feb09 Created
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
            /// Exposes access to the Number of samples translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 04Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NumberOfSamples
            {
                get
                {
                    if ((cachedNumberOfSamples == null))
                    {
                        cachedNumberOfSamples = CoreManager.MomConsole.GetIntlStr(ResourceNumberOfSamples);
                    }

                    return cachedNumberOfSamples;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Threshold value translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 04Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThresholdValue
            {
                get
                {
                    if ((cachedThresholdValue == null))
                    {
                        cachedThresholdValue = CoreManager.MomConsole.GetIntlStr(ResourceThresholdValue);
                    }

                    return cachedThresholdValue;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Value translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 04Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Value
            {
                get
                {
                    if ((cachedValue == null))
                    {
                        cachedValue = CoreManager.MomConsole.GetIntlStr(ResourceValue);
                    }

                    return cachedValue;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Specify the number of samples used to compare with the threshold translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 04Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold
            {
                get
                {
                    if ((cachedSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold == null))
                    {
                        cachedSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold = 
                            CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold);
                    }

                    return cachedSpecifyTheNumberOfSamplesUsedToCompareWithTheThreshold;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Percentage translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 04Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Percentage
            {
                get
                {
                    if ((cachedPercentage == null))
                    {
                        cachedPercentage = CoreManager.MomConsole.GetIntlStr(ResourcePercentage);
                    }

                    return cachedPercentage;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the High value of threshold translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 04Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HighValueOfThreshold
            {
                get
                {
                    if ((cachedHighValueOfThreshold == null))
                    {
                        cachedHighValueOfThreshold = CoreManager.MomConsole.GetIntlStr(ResourceHighValueOfThreshold);
                    }

                    return cachedHighValueOfThreshold;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Low value of threshold translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 04Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LowValueOfThreshold
            {
                get
                {
                    if ((cachedLowValueOfThreshold == null))
                    {
                        cachedLowValueOfThreshold = CoreManager.MomConsole.GetIntlStr(ResourceLowValueOfThreshold);
                    }

                    return cachedLowValueOfThreshold;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GreaterThan
            {
                get
                {
                    if ((cachedGreaterThan == null))
                    {
                        cachedGreaterThan = CoreManager.MomConsole.GetIntlStr(ResourceGreaterThan);
                    }

                    return cachedGreaterThan;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LessThan
            {
                get
                {
                    if ((cachedLessThan == null))
                    {
                        cachedLessThan = CoreManager.MomConsole.GetIntlStr(ResourceLessThan);
                    }

                    return cachedLessThan;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GreaterThanOrEquals
            {
                get
                {
                    if ((cachedGreaterThanOrEquals == null))
                    {
                        cachedGreaterThanOrEquals = CoreManager.MomConsole.GetIntlStr(ResourceGreaterThanOrEquals);
                    }

                    return cachedGreaterThanOrEquals;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LessThanOrEquals
            {
                get
                {
                    if ((cachedLessThanOrEquals == null))
                    {
                        cachedLessThanOrEquals = CoreManager.MomConsole.GetIntlStr(ResourceLessThanOrEquals);
                    }

                    return cachedLessThanOrEquals;
                }
            }

            #endregion

        }
        #endregion
    }
}
