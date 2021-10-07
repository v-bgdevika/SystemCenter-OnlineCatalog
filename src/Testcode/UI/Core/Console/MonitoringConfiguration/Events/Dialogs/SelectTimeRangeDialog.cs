// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectTimeRangeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 4/24/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - TimeRangeRadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group TimeRangeRadioGroup
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum TimeRangeRadioGroup
    {
        /// <summary>
        /// SpanMultipleDays = 0
        /// </summary>
        SpanMultipleDays = 0,
        
        /// <summary>
        /// Daily = 1
        /// </summary>
        Daily = 1,
    }
    #endregion
    
    #region Interface Definition - ISelectTimeRangeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectTimeRangeDialogControls, for SelectTimeRangeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectTimeRangeDialogControls
    {
        /// <summary>
        /// Read-only property to access EndDayOfWeekComboBox
        /// </summary>
        ComboBox EndDayOfWeekComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MultipleEndDateTimePicker
        /// </summary>
        DateTimePicker MultipleEndDateTimePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Spinner7
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Spinner Spinner7
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndStaticControl
        /// </summary>
        StaticControl EndStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartDayOfWeekComboBox
        /// </summary>
        ComboBox StartDayOfWeekComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MultipleStartDateTimePicker
        /// </summary>
        DateTimePicker MultipleStartDateTimePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
        /// </summary>
        Spinner SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartStaticControl
        /// </summary>
        StaticControl StartStaticControl
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
        /// Read-only property to access DaysOfWeekListBox
        /// </summary>
        ListBox DaysOfWeekListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AndStaticControl
        /// </summary>
        StaticControl AndStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DailyStartDateTimePicker
        /// </summary>        
        DateTimePicker DailyStartDateTimePicker 
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo
        /// </summary>
        Spinner YouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DailyEndDateTimePicker
        /// </summary>
        DateTimePicker DailyEndDateTimePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Spinner1
        /// </summary>
        Spinner Spinner1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BetweenStaticControl
        /// </summary>
        StaticControl BetweenStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpanMultipleDaysRadioButton
        /// </summary>
        RadioButton SpanMultipleDaysRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DailyRadioButton
        /// </summary>
        RadioButton DailyRadioButton
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
    /// 	[ruhim] 4/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectTimeRangeDialog : Dialog, ISelectTimeRangeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to EndDayOfWeekComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedEndDayOfWeekComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MultipleEndDateTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedMultipleEndDateTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to Spinner7 of type Spinner
        /// </summary>
        private Spinner cachedSpinner7;
        
        /// <summary>
        /// Cache to hold a reference to EndStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEndStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StartDayOfWeekComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedStartDayOfWeekComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MultipleStartDateTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedMultipleStartDateTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro of type Spinner
        /// </summary>
        private Spinner cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro;
        
        /// <summary>
        /// Cache to hold a reference to StartStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStartStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to DaysOfWeekListBox of type ListBox
        /// </summary>
        private ListBox cachedDaysOfWeekListBox;
        
        /// <summary>
        /// Cache to hold a reference to AndStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAndStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DailyStartDateTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedDailyStartDateTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to YouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo of type Spinner
        /// </summary>
        private Spinner cachedYouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo;
        
        /// <summary>
        /// Cache to hold a reference to DailyEndDateTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedDailyEndDateTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to Spinner1 of type Spinner
        /// </summary>
        private Spinner cachedSpinner1;
        
        /// <summary>
        /// Cache to hold a reference to BetweenStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBetweenStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpanMultipleDaysRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSpanMultipleDaysRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DailyRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDailyRadioButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectTimeRangeDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectTimeRangeDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group TimeRangeRadioGroup
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual TimeRangeRadioGroup TimeRangeRadioGroup
        {
            get
            {
                if ((this.Controls.SpanMultipleDaysRadioButton.ButtonState == ButtonState.Checked))
                {
                    return TimeRangeRadioGroup.SpanMultipleDays;
                }
                
                if ((this.Controls.DailyRadioButton.ButtonState == ButtonState.Checked))
                {
                    return TimeRangeRadioGroup.Daily;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == TimeRangeRadioGroup.SpanMultipleDays))
                {
                    this.Controls.SpanMultipleDaysRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == TimeRangeRadioGroup.Daily))
                    {
                        this.Controls.DailyRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ISelectTimeRangeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectTimeRangeDialogControls Controls
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
        ///  Routine to set/get the text in control EndDayOfWeekComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EndDayOfWeekComboBoxText
        {
            get
            {
                return this.Controls.EndDayOfWeekComboBox.Text;
            }
            
            set
            {
                this.Controls.EndDayOfWeekComboBox.SelectByText(value, true);
            }
        }                
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control StartDayOfWeekComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StartDayOfWeekComboBoxText
        {
            get
            {
                return this.Controls.StartDayOfWeekComboBox.Text;
            }
            
            set
            {
                this.Controls.StartDayOfWeekComboBox.SelectByText(value, true);
            }
        }                   
       
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndDayOfWeekComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectTimeRangeDialogControls.EndDayOfWeekComboBox
        {
            get
            {
                if ((this.cachedEndDayOfWeekComboBox == null))
                {
                    this.cachedEndDayOfWeekComboBox = new ComboBox(this, SelectTimeRangeDialog.ControlIDs.EndDayOfWeekComboBox);
                }
                return this.cachedEndDayOfWeekComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MultipleEndDateTimePicker control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISelectTimeRangeDialogControls.MultipleEndDateTimePicker
        {
            get
            {
                if ((this.cachedMultipleEndDateTimePicker == null))
                {
                    this.cachedMultipleEndDateTimePicker = new DateTimePicker(this, SelectTimeRangeDialog.ControlIDs.MultipleEndDateTimePicker);
                }
                return this.cachedMultipleEndDateTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Spinner7 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISelectTimeRangeDialogControls.Spinner7
        {
            get
            {
                if ((this.cachedSpinner7 == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSpinner7 = new Spinner(wndTemp);
                }
                return this.cachedSpinner7;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTimeRangeDialogControls.EndStaticControl
        {
            get
            {
                if ((this.cachedEndStaticControl == null))
                {
                    this.cachedEndStaticControl = new StaticControl(this, SelectTimeRangeDialog.ControlIDs.EndStaticControl);
                }
                return this.cachedEndStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartDayOfWeekComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectTimeRangeDialogControls.StartDayOfWeekComboBox
        {
            get
            {
                if ((this.cachedStartDayOfWeekComboBox == null))
                {
                    this.cachedStartDayOfWeekComboBox = new ComboBox(this, SelectTimeRangeDialog.ControlIDs.StartDayOfWeekComboBox);
                }
                return this.cachedStartDayOfWeekComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MultipleStartDateTimePicker control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISelectTimeRangeDialogControls.MultipleStartDateTimePicker
        {
            get
            {
                if ((this.cachedMultipleStartDateTimePicker == null))
                {
                    this.cachedMultipleStartDateTimePicker = new DateTimePicker(this, SelectTimeRangeDialog.ControlIDs.MultipleStartDateTimePicker);
                }
                return this.cachedMultipleStartDateTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISelectTimeRangeDialogControls.SampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro
        {
            get
            {
                if ((this.cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro = new Spinner(wndTemp);
                }
                return this.cachedSampleOfCorrelationBetweenTheFirstOccurrenceOfAAndTheThirdOccurrenceOfBOnA30SecondsIntervalAndInChro;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTimeRangeDialogControls.StartStaticControl
        {
            get
            {
                if ((this.cachedStartStaticControl == null))
                {
                    this.cachedStartStaticControl = new StaticControl(this, SelectTimeRangeDialog.ControlIDs.StartStaticControl);
                }
                return this.cachedStartStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTimeRangeDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectTimeRangeDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTimeRangeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectTimeRangeDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DaysOfWeekListBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ISelectTimeRangeDialogControls.DaysOfWeekListBox
        {
            get
            {
                if ((this.cachedDaysOfWeekListBox == null))
                {
                    this.cachedDaysOfWeekListBox = new ListBox(this, SelectTimeRangeDialog.ControlIDs.DaysOfWeekListBox);
                }
                return this.cachedDaysOfWeekListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AndStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTimeRangeDialogControls.AndStaticControl
        {
            get
            {
                if ((this.cachedAndStaticControl == null))
                {
                    this.cachedAndStaticControl = new StaticControl(this, SelectTimeRangeDialog.ControlIDs.AndStaticControl);
                }
                return this.cachedAndStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DailyStartDateTimePicker control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISelectTimeRangeDialogControls.DailyStartDateTimePicker
        {
            get
            {
                if ((this.cachedDailyStartDateTimePicker == null))
                {
                    this.cachedDailyStartDateTimePicker = new DateTimePicker(this, SelectTimeRangeDialog.ControlIDs.DailyStartDateTimePicker);
                }
                return this.cachedDailyStartDateTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISelectTimeRangeDialogControls.YouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo
        {
            get
            {
                if ((this.cachedYouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 9); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedYouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo = new Spinner(wndTemp);
                }
                return this.cachedYouCanReferenceEventPropertiesThatAreCommonToAllEventsYouCanAlsoSelectEventSpecificPropertiesInTheFo;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DailyEndDateTimePicker control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISelectTimeRangeDialogControls.DailyEndDateTimePicker
        {
            get
            {
                if ((this.cachedDailyEndDateTimePicker == null))
                {
                    this.cachedDailyEndDateTimePicker = new DateTimePicker(this, SelectTimeRangeDialog.ControlIDs.DailyEndDateTimePicker);
                }
                return this.cachedDailyEndDateTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Spinner1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISelectTimeRangeDialogControls.Spinner1
        {
            get
            {
                if ((this.cachedSpinner1 == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 10); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSpinner1 = new Spinner(wndTemp);
                }
                return this.cachedSpinner1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BetweenStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTimeRangeDialogControls.BetweenStaticControl
        {
            get
            {
                if ((this.cachedBetweenStaticControl == null))
                {
                    this.cachedBetweenStaticControl = new StaticControl(this, SelectTimeRangeDialog.ControlIDs.BetweenStaticControl);
                }
                return this.cachedBetweenStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpanMultipleDaysRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISelectTimeRangeDialogControls.SpanMultipleDaysRadioButton
        {
            get
            {
                if ((this.cachedSpanMultipleDaysRadioButton == null))
                {
                    this.cachedSpanMultipleDaysRadioButton = new RadioButton(this, SelectTimeRangeDialog.ControlIDs.SpanMultipleDaysRadioButton);
                }
                return this.cachedSpanMultipleDaysRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DailyRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISelectTimeRangeDialogControls.DailyRadioButton
        {
            get
            {
                if ((this.cachedDailyRadioButton == null))
                {
                    this.cachedDailyRadioButton = new RadioButton(this, SelectTimeRangeDialog.ControlIDs.DailyRadioButton);
                }
                return this.cachedDailyRadioButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/24/2007 Created
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
        /// 	[ruhim] 4/24/2007 Created
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
        ///  <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

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
        /// 	[ruhim] 4/24/2007 Created
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
            private const string ResourceDialogTitle = 
                ";Select Time Range;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TimeRangeForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  End
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnd = ";&End:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDevices;labelRange" +
                "End.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Start
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStart = ";&Start:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDevices;labelSta" +
                "rt.Text";
            
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
            /// Contains resource string for:  And
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAnd = ";and;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.TimeRangeForm;labelAnd.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Between
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBetween = ";&Between:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.TimeRangeForm;labelBetween.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpanMultipleDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpanMultipleDays = ";Span &multiple days ;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TimeRangeForm;radi" +
                "oButtonMultiDays.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Daily
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDaily = ";&Daily ;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.TimeRangeForm;radioButtonDaily." +
                "Text";
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
            /// Caches the translated resource string for:  End
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Start
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStart;
            
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
            /// Caches the translated resource string for:  And
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAnd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Between
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBetween;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpanMultipleDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpanMultipleDays;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Daily
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDaily;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2007 Created
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
            /// Exposes access to the End translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string End
            {
                get
                {
                    if ((cachedEnd == null))
                    {
                        cachedEnd = CoreManager.MomConsole.GetIntlStr(ResourceEnd);
                    }
                    return cachedEnd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Start translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Start
            {
                get
                {
                    if ((cachedStart == null))
                    {
                        cachedStart = CoreManager.MomConsole.GetIntlStr(ResourceStart);
                    }
                    return cachedStart;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2007 Created
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
            /// 	[ruhim] 4/24/2007 Created
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
            /// Exposes access to the And translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string And
            {
                get
                {
                    if ((cachedAnd == null))
                    {
                        cachedAnd = CoreManager.MomConsole.GetIntlStr(ResourceAnd);
                    }
                    return cachedAnd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Between translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Between
            {
                get
                {
                    if ((cachedBetween == null))
                    {
                        cachedBetween = CoreManager.MomConsole.GetIntlStr(ResourceBetween);
                    }
                    return cachedBetween;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpanMultipleDays translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpanMultipleDays
            {
                get
                {
                    if ((cachedSpanMultipleDays == null))
                    {
                        cachedSpanMultipleDays = CoreManager.MomConsole.GetIntlStr(ResourceSpanMultipleDays);
                    }
                    return cachedSpanMultipleDays;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Daily translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Daily
            {
                get
                {
                    if ((cachedDaily == null))
                    {
                        cachedDaily = CoreManager.MomConsole.GetIntlStr(ResourceDaily);
                    }
                    return cachedDaily;
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
        /// 	[ruhim] 4/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for EndDayOfWeekComboBox
            /// </summary>
            public const string EndDayOfWeekComboBox = "comboBoxEndDayOfWeek";
            
            /// <summary>
            /// Control ID for MultipleEndDateTimePicker
            /// </summary>
            public const string MultipleEndDateTimePicker = "dateTimePickerEnd";
            
            /// <summary>
            /// Control ID for EndStaticControl
            /// </summary>
            public const string EndStaticControl = "labelEnd";
            
            /// <summary>
            /// Control ID for StartDayOfWeekComboBox
            /// </summary>
            public const string StartDayOfWeekComboBox = "comboBoxStartDayOfWeek";
            
            /// <summary>
            /// Control ID for MultipleStartDateTimePicker
            /// </summary>
            public const string MultipleStartDateTimePicker = "dateTimePickerStart";
            
            /// <summary>
            /// Control ID for StartStaticControl
            /// </summary>
            public const string StartStaticControl = "labelStart";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for DaysOfWeekListBox
            /// </summary>
            public const string DaysOfWeekListBox = "checkedListBoxDaysOfWeek";
            
            /// <summary>
            /// Control ID for AndStaticControl
            /// </summary>
            public const string AndStaticControl = "labelAnd";
            
            /// <summary>
            /// Control ID for DailyEndDateTimePicker
            /// </summary>
            public const string DailyEndDateTimePicker = "dateTimePickerTo";
            
            /// <summary>
            /// Control ID for DailyStartDateTimePicker
            /// </summary>
            public const string DailyStartDateTimePicker = "dateTimePickerFrom";
            
            /// <summary>
            /// Control ID for BetweenStaticControl
            /// </summary>
            public const string BetweenStaticControl = "labelBetween";
            
            /// <summary>
            /// Control ID for SpanMultipleDaysRadioButton
            /// </summary>
            public const string SpanMultipleDaysRadioButton = "radioButtonMultiDays";
            
            /// <summary>
            /// Control ID for DailyRadioButton
            /// </summary>
            public const string DailyRadioButton = "radioButtonDaily";
        }
        #endregion
    }
}
