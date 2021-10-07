// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TimeRangeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 5/31/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Performance.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    #endregion

    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum TimeRangeRadioGroup
    {
        /// <summary>
        /// SelectATimeRange = 0
        /// </summary>
        SelectATimeRange = 0,
        
        /// <summary>
        /// SpecificStartAndEndTimes = 1
        /// </summary>
        SpecificStartAndEndTimes = 1,
    }
    #endregion
    
    #region Interface Definition - ITimeRangeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITimeRangeDialogControls, for TimeRangeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITimeRangeDialogControls
    {
        /// <summary>
        /// Read-only property to access InThePast1DaysStaticControl
        /// </summary>
        StaticControl InThePast1DaysStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
        /// Read-only property to access AndBeforeStaticControl
        /// </summary>
        StaticControl AndBeforeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SinceStaticControl
        /// </summary>
        StaticControl SinceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InTheLastStaticControl
        /// </summary>
        StaticControl InTheLastStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DynamicUnitsComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox DynamicUnitsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access 1
        /// </summary>
        TextBox DynamicUnitTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndTimeDateTimePicker
        /// </summary>
        DateTimePicker EndTimeDateTimePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartTimeDateTimePicker
        /// </summary>
        DateTimePicker StartTimeDateTimePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectATimeRangeRadioButton
        /// </summary>
        RadioButton SelectATimeRangeRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecificStartAndEndTimesRadioButton
        /// </summary>
        RadioButton SpecificStartAndEndTimesRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PreviewStaticControl
        /// </summary>
        StaticControl PreviewStaticControl
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
    /// 	[mbickle] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TimeRangeDialog : Dialog, ITimeRangeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to InThePast1DaysStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInThePast1DaysStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to AndBeforeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndBeforeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SinceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSinceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InTheLastStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedInTheLastStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DynamicUnitsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDynamicUnitsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to 1 of type ComboBox
        /// </summary>
        private TextBox cachedDynamicUnitTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EndTimeDateTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedEndTimeDateTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to StartTimeDateTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedStartTimeDateTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to SelectATimeRangeRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSelectATimeRangeRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SpecificStartAndEndTimesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSpecificStartAndEndTimesRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to PreviewStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPreviewStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TimeRangeDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TimeRangeDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual TimeRangeRadioGroup TimeRangeRadioGroup
        {
            get
            {
                if ((this.Controls.SelectATimeRangeRadioButton.ButtonState == ButtonState.Checked))
                {
                    return TimeRangeRadioGroup.SelectATimeRange;
                }
                
                if ((this.Controls.SpecificStartAndEndTimesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return TimeRangeRadioGroup.SpecificStartAndEndTimes;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == TimeRangeRadioGroup.SelectATimeRange))
                {
                    this.Controls.SelectATimeRangeRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == TimeRangeRadioGroup.SpecificStartAndEndTimes))
                    {
                        this.Controls.SpecificStartAndEndTimesRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ITimeRangeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITimeRangeDialogControls Controls
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
        ///  Routine to set/get the text in control DynamicUnitsComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DynamicUnitsComboBoxText
        {
            get
            {
                return this.Controls.DynamicUnitsComboBox.Text;
            }
            
            set
            {
                this.Controls.DynamicUnitsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control 1
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DynamicUnitTextBoxText
        {
            get
            {
                return this.Controls.DynamicUnitTextBox.Text;
            }
            
            set
            {
                this.Controls.DynamicUnitTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AndBefore
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EndTimeDateTimePickerText
        {
            get
            {
                return this.Controls.EndTimeDateTimePicker.DateTimeString;
            }
            
            set
            {
                this.Controls.EndTimeDateTimePicker.DateTimeString = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control StartTimeDateTimePicker
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StartTimeDateTimePickerText
        {
            get
            {
                return this.Controls.StartTimeDateTimePicker.DateTimeString;
            }
            
            set
            {
                this.Controls.StartTimeDateTimePicker.DateTimeString = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InThePast1DaysStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimeRangeDialogControls.InThePast1DaysStaticControl
        {
            get
            {
                if ((this.cachedInThePast1DaysStaticControl == null))
                {
                    this.cachedInThePast1DaysStaticControl = new StaticControl(this, TimeRangeDialog.ControlIDs.InThePast1DaysStaticControl);
                }
                
                return this.cachedInThePast1DaysStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITimeRangeDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, TimeRangeDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITimeRangeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TimeRangeDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndBeforeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimeRangeDialogControls.AndBeforeStaticControl
        {
            get
            {
                if ((this.cachedAndBeforeStaticControl == null))
                {
                    this.cachedAndBeforeStaticControl = new StaticControl(this, TimeRangeDialog.ControlIDs.AndBeforeStaticControl);
                }
                
                return this.cachedAndBeforeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SinceStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimeRangeDialogControls.SinceStaticControl
        {
            get
            {
                if ((this.cachedSinceStaticControl == null))
                {
                    this.cachedSinceStaticControl = new StaticControl(this, TimeRangeDialog.ControlIDs.SinceStaticControl);
                }
                
                return this.cachedSinceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InTheLastStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimeRangeDialogControls.InTheLastStaticControl
        {
            get
            {
                if ((this.cachedInTheLastStaticControl == null))
                {
                    this.cachedInTheLastStaticControl = new StaticControl(this, TimeRangeDialog.ControlIDs.InTheLastStaticControl);
                }
                
                return this.cachedInTheLastStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DynamicUnitsComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ITimeRangeDialogControls.DynamicUnitsComboBox
        {
            get
            {
                if ((this.cachedDynamicUnitsComboBox == null))
                {
                    this.cachedDynamicUnitsComboBox = new ComboBox(this, TimeRangeDialog.ControlIDs.DynamicUnitsComboBox);
                }
                
                return this.cachedDynamicUnitsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the 1 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITimeRangeDialogControls.DynamicUnitTextBox
        {
            get
            {
                if ((this.cachedDynamicUnitTextBox == null))
                {
                    this.cachedDynamicUnitTextBox = new TextBox(this, TimeRangeDialog.ControlIDs.DynamicUnitTextBox);
                }
                
                return this.cachedDynamicUnitTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndTimeDateTimePicker control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ITimeRangeDialogControls.EndTimeDateTimePicker
        {
            get
            {
                if ((this.cachedEndTimeDateTimePicker == null))
                {
                    this.cachedEndTimeDateTimePicker = new DateTimePicker(this, TimeRangeDialog.ControlIDs.EndTimeDateTimePicker);
                }
                
                return this.cachedEndTimeDateTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartTimeDateTimePicker control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ITimeRangeDialogControls.StartTimeDateTimePicker
        {
            get
            {
                if ((this.cachedStartTimeDateTimePicker == null))
                {
                    this.cachedStartTimeDateTimePicker = new DateTimePicker(this, TimeRangeDialog.ControlIDs.StartTimeDateTimePicker);
                }
                
                return this.cachedStartTimeDateTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectATimeRangeRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITimeRangeDialogControls.SelectATimeRangeRadioButton
        {
            get
            {
                if ((this.cachedSelectATimeRangeRadioButton == null))
                {
                    this.cachedSelectATimeRangeRadioButton = new RadioButton(this, TimeRangeDialog.ControlIDs.SelectATimeRangeRadioButton);
                }
                
                return this.cachedSelectATimeRangeRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecificStartAndEndTimesRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITimeRangeDialogControls.SpecificStartAndEndTimesRadioButton
        {
            get
            {
                if ((this.cachedSpecificStartAndEndTimesRadioButton == null))
                {
                    this.cachedSpecificStartAndEndTimesRadioButton = new RadioButton(this, TimeRangeDialog.ControlIDs.SpecificStartAndEndTimesRadioButton);
                }
                
                return this.cachedSpecificStartAndEndTimesRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviewStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimeRangeDialogControls.PreviewStaticControl
        {
            get
            {
                if ((this.cachedPreviewStaticControl == null))
                {
                    this.cachedPreviewStaticControl = new StaticControl(this, TimeRangeDialog.ControlIDs.PreviewStaticControl);
                }
                
                return this.cachedPreviewStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
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

                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
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
            private const string ResourceDialogTitle = ";Time Range;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceTimePicker;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Days
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDays = ";Days;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceTimePicker;dynamicUnits.Items2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHours = ";Hours;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceTimePicker;dynamicUnits.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinutes = ";Minutes;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceTimePicker;dynamicUnits.Items";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AndBefore
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAndBefore = ";and Before;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.UI.PerformanceTimePicker;beforeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Since
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSince = ";Since;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManageme" +
                "nt.Mom.UI.PerformanceTimePicker;sinceLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  InTheLast
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInTheLast = ";In the last;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.UI.PerformanceTimePicker;dynamicRangeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectATimeRange
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectATimeRange = ";Select a time &range;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.UI.PerformanceTimePicker;dynamicRadioButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecificStartAndEndTimes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecificStartAndEndTimes = ";Specific start and end &times:;ManagedString;Microsoft.MOM.UI.Components.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.UI.PerformanceTimePicker;staticRadioButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Preview
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePreview = ";Preview:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.UI.PerformanceTimePicker;previewLabel.Text";
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
            /// Caches the translated resource Days
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDays;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated cached Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHours;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated cached Minutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinutes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AndBefore
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAndBefore;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Since
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSince;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InTheLast
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInTheLast;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectATimeRange
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectATimeRange;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecificStartAndEndTimes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecificStartAndEndTimes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Preview
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPreview;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
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
            /// Exposes access to the Days translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Days
            {
                get
                {
                    if ((cachedDays == null))
                    {
                        cachedDays = CoreManager.MomConsole.GetIntlStr(ResourceDays);
                    }
                    
                    return cachedDays;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Hours translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Hours
            {
                get
                {
                    if ((cachedHours == null))
                    {
                        cachedHours = CoreManager.MomConsole.GetIntlStr(ResourceHours);
                    }

                    return cachedHours;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Minutes translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Minutes
            {
                get
                {
                    if ((cachedMinutes == null))
                    {
                        cachedMinutes = CoreManager.MomConsole.GetIntlStr(ResourceMinutes);
                    }

                    return cachedMinutes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
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
            /// Exposes access to the AndBefore translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AndBefore
            {
                get
                {
                    if ((cachedAndBefore == null))
                    {
                        cachedAndBefore = CoreManager.MomConsole.GetIntlStr(ResourceAndBefore);
                    }
                    
                    return cachedAndBefore;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Since translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Since
            {
                get
                {
                    if ((cachedSince == null))
                    {
                        cachedSince = CoreManager.MomConsole.GetIntlStr(ResourceSince);
                    }
                    
                    return cachedSince;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InTheLast translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InTheLast
            {
                get
                {
                    if ((cachedInTheLast == null))
                    {
                        cachedInTheLast = CoreManager.MomConsole.GetIntlStr(ResourceInTheLast);
                    }
                    
                    return cachedInTheLast;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectATimeRange translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectATimeRange
            {
                get
                {
                    if ((cachedSelectATimeRange == null))
                    {
                        cachedSelectATimeRange = CoreManager.MomConsole.GetIntlStr(ResourceSelectATimeRange);
                    }
                    
                    return cachedSelectATimeRange;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecificStartAndEndTimes translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecificStartAndEndTimes
            {
                get
                {
                    if ((cachedSpecificStartAndEndTimes == null))
                    {
                        cachedSpecificStartAndEndTimes = CoreManager.MomConsole.GetIntlStr(ResourceSpecificStartAndEndTimes);
                    }
                    
                    return cachedSpecificStartAndEndTimes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Preview translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Preview
            {
                get
                {
                    if ((cachedPreview == null))
                    {
                        cachedPreview = CoreManager.MomConsole.GetIntlStr(ResourcePreview);
                    }
                    
                    return cachedPreview;
                }
            }
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mbickle] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for InThePast1DaysStaticControl
            /// </summary>
            public const string InThePast1DaysStaticControl = "previewContentLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for AndBeforeStaticControl
            /// </summary>
            public const string AndBeforeStaticControl = "beforeLabel";
            
            /// <summary>
            /// Control ID for SinceStaticControl
            /// </summary>
            public const string SinceStaticControl = "sinceLabel";
            
            /// <summary>
            /// Control ID for InTheLastStaticControl
            /// </summary>
            public const string InTheLastStaticControl = "dynamicRangeLabel";
            
            /// <summary>
            /// Control ID for DynamicUnitsComboBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string DynamicUnitsComboBox = "dynamicUnits";
            
            /// <summary>
            /// Control ID for DynamicUnitTextBox
            /// </summary>
            public const string DynamicUnitTextBox = "dynamicUpDown";
            
            /// <summary>
            /// Control ID for EndTimeDateTimePicker
            /// </summary>
            public const string EndTimeDateTimePicker = "endTimePicker";
            
            /// <summary>
            /// Control ID for StartTimeDateTimePicker
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StartTimeDateTimePicker = "startTimePicker";
            
            /// <summary>
            /// Control ID for SelectATimeRangeRadioButton
            /// </summary>
            public const string SelectATimeRangeRadioButton = "dynamicRadioButton";
            
            /// <summary>
            /// Control ID for SpecificStartAndEndTimesRadioButton
            /// </summary>
            public const string SpecificStartAndEndTimesRadioButton = "staticRadioButton";
            
            /// <summary>
            /// Control ID for PreviewStaticControl
            /// </summary>
            public const string PreviewStaticControl = "previewLabel";
        }
        #endregion
    }
}
