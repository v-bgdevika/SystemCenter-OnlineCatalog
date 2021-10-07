// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SlmReportParameterControlDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sunsingh] 9/8/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System.Text;
    using System;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement.Mom.Internal;


    #region Interface Definition - ISlmReportParameterControlDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISlmReportParameterControlDialogControls, for SlmReportParameterControlDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 9/8/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISlmReportParameterControlDialogControls
    {
        /// <summary>
        /// Read-only property to access DataAggregationStaticControl
        /// </summary>
        StaticControl DataAggregationStaticControl
        {
            get;
        }
        /// <summary>
        /// Read-only property to access ReportGeneratingStaticControl
        /// </summary>
        StaticControl ReportGeneratingStaticControl
        {
            get;
        }        
        /// <summary>
        /// Read-only property to access TimeZoneComboBox
        /// </summary>
        ComboBox TimeZoneComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddSLAButton
        /// </summary>
        Button AddSLAButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsStaticControl
        /// </summary>
        StaticControl ObjectsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedSlaGridView
        /// </summary>
        PropertyGridView SelectedSlaGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveSLAButton
        /// </summary>
        Button RemoveSLAButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DownTimeStaticControl
        /// </summary>
        StaticControl DownTimeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdditionalTimeIntervalsListBox
        /// </summary>
        CheckedListBox AdditionalTimeIntervalsListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _BusinessWeekDayStaticControl
        /// </summary>
        StaticControl _BusinessWeekDayStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseBusinessHoursCheckBox
        /// </summary>
        CheckBox UseBusinessHoursCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BusinessHoursButton
        /// </summary>
        Button BusinessHoursButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BusinessWeekDayComboBox
        /// </summary>
        ComboBox BusinessWeekDayComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeZoneStaticControl
        /// </summary>
        StaticControl TimeZoneStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableItemsComboBox 
        /// </summary>
        ComboBox AvailableItemsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToSpinner
        /// </summary>
        Spinner ToSpinner
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableItemsComboBox2
        /// </summary>
        ComboBox AvailableItemsComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchTimeIntervalEndDateSpinner
        /// </summary>
        Spinner SearchTimeIntervalEndDateSpinner
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SLAReportStartDateComboBox
        /// </summary>
        ComboBox SLAReportStartDateComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BusinessWeekDayComboBox2
        /// </summary>
        ComboBox BusinessWeekDayComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FromStaticControl
        /// </summary>
        StaticControl FromStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToStaticControl
        /// </summary>
        StaticControl ToStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BusinessWeekDayStatusBar
        /// </summary>
        StatusBar BusinessWeekDayStatusBar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Toolbar1
        /// </summary>
        Toolbar Toolbar1
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MainMenu
        /// </summary>
        Toolbar MainMenu
        {
            get;
        }

        
        /// <summary>
        /// Read-only property to access SearchTimeIntervalStartDateTextBox
        /// </summary>
        TextBox SearchTimeIntervalStartDateTextBox
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
    /// 	[sunsingh] 9/8/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SlmReportParameterControlDialog : Dialog, ISlmReportParameterControlDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to DataAggregationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDataAggregationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ReportGeneratingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedReportGeneratingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TimeZoneComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimeZoneComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AddSLAButton of type Button
        /// </summary>
        private Button cachedAddSLAButton;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedSlaGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedSelectedSlaGridView;
        
        /// <summary>
        /// Cache to hold a reference to RemoveSLAButton of type Button
        /// </summary>
        private Button cachedRemoveSLAButton;
        
        /// <summary>
        /// Cache to hold a reference to DownTimeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDownTimeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdditionalTimeIntervalsListBox of type ListBox
        /// </summary>
        private CheckedListBox cachedAdditionalTimeIntervalsListBox;
        
        /// <summary>
        /// Cache to hold a reference to _BusinessWeekDayStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_BusinessWeekDayStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseBusinessHoursCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUseBusinessHoursCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to BusinessHoursButton of type Button
        /// </summary>
        private Button cachedBusinessHoursButton;
        
        /// <summary>
        /// Cache to hold a reference to BusinessWeekDayComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedBusinessWeekDayComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TimeZoneStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTimeZoneStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAvailableItemsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ToSpinner of type Spinner
        /// </summary>
        private Spinner cachedToSpinner;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedAvailableItemsComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalEndDateSpinner of type Spinner
        /// </summary>
        private Spinner cachedSearchTimeIntervalEndDateSpinner;
        
        /// <summary>
        /// Cache to hold a reference to SLAReportStartDateComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSLAReportStartDateComboBox;
        
        /// <summary>
        /// Cache to hold a reference to BusinessWeekDayComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedBusinessWeekDayComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to FromStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFromStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BusinessWeekDayStatusBar of type StatusBar
        /// </summary>
        private StatusBar cachedBusinessWeekDayStatusBar;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar1;
        /// <summary>
        /// Cache to hold a reference to cachedMainMenu of type Toolbar
        /// </summary>
        private Toolbar cachedMainMenu;
        
        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalStartDateTextBox of type TextBox
        /// </summary>
        private TextBox cachedSearchTimeIntervalStartDateTextBox;
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  RT.Interval.ReportDuration
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedReportTimeIntervalReportDuration;
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  RT.Interval.LastMonth
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedReportTimeIntervalLastMonth;
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  SLA Summary report
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedSLAReportDisplayString;
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  RT.Interval.LastWeek
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedReportTimeIntervalLastWeek;
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  RT.Interval.LastQuarter
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedReportTimeIntervalLastQuarter;

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Caches the translated resource string for:  SLM reporting
        /// </summary>
        /// -----------------------------------------------------------------------------
        private static string cachedSlmReportingMPDisplayName;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SlmReportParameterControlDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SlmReportParameterControlDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISlmReportParameterControlDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISlmReportParameterControlDialogControls Controls
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
        ///  Property to handle checkbox UseBusinessHours
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UseBusinessHours
        {
            get
            {
                return this.Controls.UseBusinessHoursCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UseBusinessHoursCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// </summary>
        /// <history>
        /// 	[sunsingh] 7/30/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MomControls.GridControl GetDataGrid()
        {

            string gridResorceId = null;
            gridResorceId = ControlIDs.SelectedSlaGridView;
       
            return new MomControls.GridControl(
                   this,
                   gridResorceId);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TimeZone
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeZoneText
        {
            get
            {
                return this.Controls.TimeZoneComboBox.Text;
            }
            
            set
            {
                this.Controls.TimeZoneComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control BusinessWeekDay
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string BusinessWeekDayText
        {
            get
            {
                return this.Controls.BusinessWeekDayComboBox.Text;
            }
            
            set
            {
                this.Controls.BusinessWeekDayComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AvailableItems
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AvailableItemsText
        {
            get
            {
                return this.Controls.AvailableItemsComboBox.Text;
            }
            
            set
            {
                this.Controls.AvailableItemsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AvailableItems2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AvailableItems2Text
        {
            get
            {
                return this.Controls.AvailableItemsComboBox2.Text;
            }
            
            set
            {
                this.Controls.AvailableItemsComboBox2.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TimeZone2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SLAReportStartDateText
        {
            get
            {
                return this.Controls.SLAReportStartDateComboBox.Text;
            }
            
            set
            {
                this.Controls.SLAReportStartDateComboBox.SelectByText(value,false);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control BusinessWeekDay2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string BusinessWeekDay2Text
        {
            get
            {
                return this.Controls.BusinessWeekDayComboBox2.Text;
            }
            
            set
            {
                this.Controls.BusinessWeekDayComboBox2.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SearchTimeIntervalStartDate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchTimeIntervalStartDateText
        {
            get
            {
                return this.Controls.SearchTimeIntervalStartDateTextBox.Text;
            }
            
            set
            {
                this.Controls.SearchTimeIntervalStartDateTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataAggregationStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISlmReportParameterControlDialogControls.DataAggregationStaticControl
        {
            get
            {
                if ((this.cachedDataAggregationStaticControl == null))
                {
                    this.cachedDataAggregationStaticControl = new StaticControl(this, SlmReportParameterControlDialog.ControlIDs.DataAggregationStaticControl);
                }
                
                return this.cachedDataAggregationStaticControl;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReportGeneratingStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISlmReportParameterControlDialogControls.ReportGeneratingStaticControl
        {
            get
            {
                if ((this.cachedReportGeneratingStaticControl == null))
                {
                    this.cachedReportGeneratingStaticControl = new StaticControl(this, SlmReportParameterControlDialog.ControlIDs.ReportGeneratingStaticControl);
                }

                return this.cachedReportGeneratingStaticControl;
            }
        }        
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISlmReportParameterControlDialogControls.TimeZoneComboBox
        {
            get
            {
                if ((this.cachedTimeZoneComboBox == null))
                {
                    this.cachedTimeZoneComboBox = new ComboBox(this, SlmReportParameterControlDialog.ControlIDs.TimeZoneComboBox);
                }
                
                return this.cachedTimeZoneComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddSLAButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISlmReportParameterControlDialogControls.AddSLAButton
        {
            get
            {
                if ((this.cachedAddSLAButton == null))
                {
                    this.cachedAddSLAButton = new Button(this, SlmReportParameterControlDialog.ControlIDs.AddSLAButton);
                }
                
                return this.cachedAddSLAButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISlmReportParameterControlDialogControls.ObjectsStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedObjectsStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedObjectsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedSlaGridView control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView ISlmReportParameterControlDialogControls.SelectedSlaGridView
        {
            get
            {
                if ((this.cachedSelectedSlaGridView == null))
                {
                    this.cachedSelectedSlaGridView = new PropertyGridView(this, SlmReportParameterControlDialog.ControlIDs.SelectedSlaGridView);
                }
                
                return this.cachedSelectedSlaGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveSLAButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISlmReportParameterControlDialogControls.RemoveSLAButton
        {
            get
            {
                if ((this.cachedRemoveSLAButton == null))
                {
                    this.cachedRemoveSLAButton = new Button(this, SlmReportParameterControlDialog.ControlIDs.RemoveSLAButton);
                }
                
                return this.cachedRemoveSLAButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DownTimeStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISlmReportParameterControlDialogControls.DownTimeStaticControl
        {
            get
            {
                // The ID for this control (nameLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDownTimeStaticControl == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDownTimeStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDownTimeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdditionalTimeIntervalsListBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckedListBox ISlmReportParameterControlDialogControls.AdditionalTimeIntervalsListBox
        {
            get
            {
                // The ID for this control (valueEditor) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAdditionalTimeIntervalsListBox == null))
                {
                    Window wndTemp = this;
                                       
                    //// Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                  
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;

                    //[v-yoz] 17NOV09, MAUI2.0 using QID to new CheckedListBox
                    QID queryId = new QID(";[UIA]AutomationId='" + SlmReportParameterControlDialog.ControlIDs.AdditionalTimeIntervalsListBox + "'");

                    this.cachedAdditionalTimeIntervalsListBox = new CheckedListBox(wndTemp, queryId);
                }

                return this.cachedAdditionalTimeIntervalsListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _BusinessWeekDayStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISlmReportParameterControlDialogControls._BusinessWeekDayStaticControl
        {
            get
            {
                if ((this.cached_BusinessWeekDayStaticControl == null))
                {
                    this.cached_BusinessWeekDayStaticControl = new StaticControl(this, SlmReportParameterControlDialog.ControlIDs._BusinessWeekDayStaticControl);
                }
                
                return this.cached_BusinessWeekDayStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseBusinessHoursCheckBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISlmReportParameterControlDialogControls.UseBusinessHoursCheckBox
        {
            get
            {
                if ((this.cachedUseBusinessHoursCheckBox == null))
                {
                    this.cachedUseBusinessHoursCheckBox = new CheckBox(this, SlmReportParameterControlDialog.ControlIDs.UseBusinessHoursCheckBox);
                }
                
                return this.cachedUseBusinessHoursCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessHoursButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISlmReportParameterControlDialogControls.BusinessHoursButton
        {
            get
            {
                if ((this.cachedBusinessHoursButton == null))
                {
                    this.cachedBusinessHoursButton = new Button(this, SlmReportParameterControlDialog.ControlIDs.BusinessHoursButton);
                }
                
                return this.cachedBusinessHoursButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessWeekDayComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISlmReportParameterControlDialogControls.BusinessWeekDayComboBox
        {
            get
            {
                if ((this.cachedBusinessWeekDayComboBox == null))
                {
                    this.cachedBusinessWeekDayComboBox = new ComboBox(this, SlmReportParameterControlDialog.ControlIDs.BusinessWeekDayComboBox);
                }
                
                return this.cachedBusinessWeekDayComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISlmReportParameterControlDialogControls.TimeZoneStaticControl
        {
            get
            {
                if ((this.cachedTimeZoneStaticControl == null))
                {
                    this.cachedTimeZoneStaticControl = new StaticControl(this, SlmReportParameterControlDialog.ControlIDs.TimeZoneStaticControl);
                }
                
                return this.cachedTimeZoneStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISlmReportParameterControlDialogControls.AvailableItemsComboBox
        {
            get
            {
                if ((this.cachedAvailableItemsComboBox == null))
                {
                    this.cachedAvailableItemsComboBox = new ComboBox(this, SlmReportParameterControlDialog.ControlIDs.AvailableItemsComboBox);
                }
                
                return this.cachedAvailableItemsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToSpinner control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISlmReportParameterControlDialogControls.ToSpinner
        {
            get
            {
                if ((this.cachedToSpinner == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedToSpinner = new Spinner(wndTemp);
                }
                
                return this.cachedToSpinner;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsComboBox2 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISlmReportParameterControlDialogControls.AvailableItemsComboBox2
        {
            get
            {
                if ((this.cachedAvailableItemsComboBox2 == null))
                {
                    this.cachedAvailableItemsComboBox2 = new ComboBox(this, SlmReportParameterControlDialog.ControlIDs.AvailableItemsComboBox2);
                }
                
                return this.cachedAvailableItemsComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalEndDateSpinner control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISlmReportParameterControlDialogControls.SearchTimeIntervalEndDateSpinner
        {
            get
            {
                if ((this.cachedSearchTimeIntervalEndDateSpinner == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSearchTimeIntervalEndDateSpinner = new Spinner(wndTemp);
                }
                
                return this.cachedSearchTimeIntervalEndDateSpinner;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SLAReportStartDateComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISlmReportParameterControlDialogControls.SLAReportStartDateComboBox
        {
            get
            {
                if ((this.cachedSLAReportStartDateComboBox == null))
                {
                    this.cachedSLAReportStartDateComboBox = new ComboBox(this, SlmReportParameterControlDialog.ControlIDs.SLAReportStartDateComboBox);
                }
                
                return this.cachedSLAReportStartDateComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessWeekDayComboBox2 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISlmReportParameterControlDialogControls.BusinessWeekDayComboBox2
        {
            get
            {
                if ((this.cachedBusinessWeekDayComboBox2 == null))
                {
                    this.cachedBusinessWeekDayComboBox2 = new ComboBox(this, SlmReportParameterControlDialog.ControlIDs.BusinessWeekDayComboBox2);
                }
                
                return this.cachedBusinessWeekDayComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FromStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISlmReportParameterControlDialogControls.FromStaticControl
        {
            get
            {
                if ((this.cachedFromStaticControl == null))
                {
                    this.cachedFromStaticControl = new StaticControl(this, SlmReportParameterControlDialog.ControlIDs.FromStaticControl);
                }
                
                return this.cachedFromStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISlmReportParameterControlDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, SlmReportParameterControlDialog.ControlIDs.ToStaticControl);
                }
                
                return this.cachedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessWeekDayStatusBar control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar ISlmReportParameterControlDialogControls.BusinessWeekDayStatusBar
        {
            get
            {
                if ((this.cachedBusinessWeekDayStatusBar == null))
                {
                    this.cachedBusinessWeekDayStatusBar = new StatusBar(this, SlmReportParameterControlDialog.ControlIDs.BusinessWeekDayStatusBar);
                }
                
                return this.cachedBusinessWeekDayStatusBar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Toolbar1 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
         Toolbar ISlmReportParameterControlDialogControls.Toolbar1
        {
            get
            {
                if ((this.cachedToolbar1 == null))
                {
                    this.cachedToolbar1 = new Toolbar(this);
                }
                
                return this.cachedToolbar1;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MainMenu control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ISlmReportParameterControlDialogControls.MainMenu
        {
            get
            {
                if ((this.cachedMainMenu == null))
                {
                    this.cachedMainMenu = new Toolbar(this);
                }

                return this.cachedMainMenu;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalStartDateTextBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISlmReportParameterControlDialogControls.SearchTimeIntervalStartDateTextBox
        {
            get
            {
                if ((this.cachedSearchTimeIntervalStartDateTextBox == null))
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
                    this.cachedSearchTimeIntervalStartDateTextBox = new TextBox(wndTemp);
                }
                
                return this.cachedSearchTimeIntervalStartDateTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddSLA
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddSLA()
        {
            this.Controls.AddSLAButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSLARemove()
        {
            this.Controls.RemoveSLAButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UseBusinessHours
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUseBusinessHours()
        {
            this.Controls.UseBusinessHoursCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button BusinessHours
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBusinessHours()
        {
            this.Controls.BusinessHoursButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard, WindowClassNames.Dialog, StringMatchSyntax.WildCard, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 20;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow)
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Reporting.Dialogs.AlertsDialog :: Attempt " + numberOfTries + " of " + maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                    catch (Maui.GlobalExceptions.TimedOutException)
                    {
                        // Log a TimedOutException
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Reporting.Dialogs.AlertsDialog :: Absorbing TimedOutException-" + numberOfTries + "! The Alerts Dialog window is taking too long to render.");
                    }
                }

                //// check for success
                //if ((null == tempWindow))
                //{
                //    // log the failure

                //    // rethrow the original exception
                //    throw windowNotFound;
                //}
            }

            return tempWindow;
        }


        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: SLA summary report 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDSLASummaryReport = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterOperationsManagerDataWarehouseSLAMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceLevelAgreementSummaryReport);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: Lastmonth 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDLastMonth = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemCenterOperationsManagerDataWarehouseSLAMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceLevelAgreementSummaryReport, ManagementPackConstants.ReportTimeIntervalLastMonth);
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: ReportDuration 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDReportDuration = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemCenterOperationsManagerDataWarehouseSLAMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceLevelAgreementSummaryReport, ManagementPackConstants.ReportTimeIntervalReportDuration);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: LastQuarter 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDLastQuarter = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemCenterOperationsManagerDataWarehouseSLAMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceLevelAgreementSummaryReport, ManagementPackConstants.ReportTimeIntervalLastQuarter);

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: LastWeek 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDLastWeek = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemCenterOperationsManagerDataWarehouseSLAMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.ServiceLevelAgreementSummaryReport, ManagementPackConstants.ReportTimeIntervalLastWeek);
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains GUID for: SlmReportingMPDisplayName 
            /// </summary>   
            /// -----------------------------------------------------------------------------
            private static Guid GUIDSlmReportingMPDisplayName = Mom.Test.UI.Core.Common.IdUtil.GetMPIdAsGuid(ManagementPackConstants.SystemCenterOperationsManagerDataWarehouseSLAMPName, ManagementPackConstants.MomManagementPackPublicKeyToken,null); //TODO verify null as version

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";{2} - {0} - Report - {1};ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Reporting.ReportFormResources;ApplicationTitleTextFormat";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataAggregation
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataAggregation = "Data Aggregation";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddSLA
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddSLA = ";Add SLA...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring" +
                ".ReportMonitoringSLAGrid;AddSLAButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Objects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjects = ";Objects;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesigner" +
                "Control;paneTitleHeaderControlObjectPicker.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.CommandNot" +
                "ification;RemoveSLAButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DownTime
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDownTime = "Down Time";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _BusinessWeekDay
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_BusinessWeekDay = "8:00 AM to 5:00 PM\r\nMon, Tue, Wed, Thu, Fri";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseBusinessHours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseBusinessHours = ";Use business hours;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Re" +
                "lativeDateTimeBusinessPicker;businessHoursSelector.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BusinessHours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBusinessHours = ";Business hours...;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Rel" +
                "ativeDateTimeBusinessPicker;configureBusinessHoursButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TimeZone
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeZone = ";Time Zone;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.TimeZonePic" +
                "ker;timeZoneLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  From
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFrom = ";From;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.RelativeDateTime" +
                "Picker;startDateLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTo = ";To;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.RelativeDateTimePi" +
                "cker;endDateLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Report StartDate yesterday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDateTimeYesterday = ";Yesterday;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.RelativeDateResources;DateMenuText_Yesterday";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: ServiceLevel column in available list view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelAggrement = ";Service Level Agreement;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringObjectPickerResources;SLAColumnName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: ServiceLevel column in available list view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMenuBarViewOption = ";View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchCommands;View";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: ServiceLevel column in available list view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewMenuParameterOption = ";Parameters;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Schedule.ReportSubscriptionParametersPage;$this.TabName";

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
            /// Caches the translated resource string for:  DataAggregation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataAggregation;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddSLA
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddSLA;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Objects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DownTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDownTime;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _BusinessWeekDay
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_BusinessWeekDay;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseBusinessHours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseBusinessHours;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BusinessHours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBusinessHours;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TimeZone
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeZone;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  From
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFrom;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTo;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DateTimeYesterday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDateTimeYesterday;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelAggrementColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelAggrementColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MenuBarViewOption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMenuBarViewOption;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewMenuParameterOption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewMenuParameterOption;

            
            #endregion
            
            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for SLAReportDisplayString
            /// </summary>
            /// <history>
            /// 	[sunsingh] 29Aug08: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SLAReportDisplayString
            {
                get
                {

                    if ((cachedSLAReportDisplayString == null))
                    {
                        cachedSLAReportDisplayString = Common.Utilities.GetReportDisplayName(Strings.GUIDSLASummaryReport);
                    }

                    return cachedSLAReportDisplayString;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for:RT.Interval.ReportDuration 
            /// </summary>
            /// <history>
            /// 	[sunsingh] 29Aug08: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReportTimeIntervalReportDuration
            {
                get
                {
                    Utilities.LogMessage("Getting ReportTimeIntervalReportDuration");
                    if ((cachedReportTimeIntervalReportDuration == null))
                    {

                        cachedReportTimeIntervalReportDuration = Common.Utilities.GetMonitoringReportStringFromGuid(Strings.GUIDSLASummaryReport, Strings.GUIDReportDuration);
                    }
                    Utilities.LogMessage("GUID ReportTimeIntervalReportDution" + cachedReportTimeIntervalReportDuration);
                    return cachedReportTimeIntervalReportDuration;
                }
            }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to display name string for:RT.Interval.LastMonth 
        /// </summary>
        /// <history>
        /// 	[sunsingh] 29Aug08: Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string ReportTimeIntervalLastMonth
        {
            get
            {
                Utilities.LogMessage("Getting ReportTimeIntervalLastMonth");
                if ((cachedReportTimeIntervalLastMonth == null))
                {

                    cachedReportTimeIntervalLastMonth = Common.Utilities.GetMonitoringReportStringFromGuid(Strings.GUIDSLASummaryReport,Strings.GUIDLastMonth);
                }
                Utilities.LogMessage("GUID ReportTimeIntervalLastMonth" + cachedReportTimeIntervalLastMonth);
                return cachedReportTimeIntervalLastMonth;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to display name RT.Interval.LastQuarter
        /// </summary>
        /// <history>
        /// 	[sunsingh] 29Aug08: Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string ReportTimeIntervalLastQuarter
        {
            get
            {
                if ((cachedReportTimeIntervalLastQuarter == null))
                {
                    cachedReportTimeIntervalLastQuarter = Common.Utilities.GetMonitoringReportStringFromGuid(Strings.GUIDSLASummaryReport, Strings.GUIDLastQuarter);
                    
                }

                return cachedReportTimeIntervalLastQuarter;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to display name string for:RT.Interval.LastWeek
        /// </summary>
        /// <history>
        /// 	[sunsingh] 29Aug08: Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string ReportTimeIntervalLastWeek
        {
            get
            {
                if ((cachedReportTimeIntervalLastWeek == null))
                {
                    cachedReportTimeIntervalLastWeek = Common.Utilities.GetMonitoringReportStringFromGuid(Strings.GUIDSLASummaryReport, Strings.GUIDLastWeek);
                }

                return cachedReportTimeIntervalLastWeek;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to display name string for: Managementpack
        /// </summary>
        /// <history>
        /// 	[sunsingh] 29Aug08: Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string SlmReportingMPDisplayName
        {
            get
            {
                if ((cachedSlmReportingMPDisplayName == null))
                {
                    cachedSlmReportingMPDisplayName = Common.Utilities.GetManagementPackName(Strings.GUIDSlmReportingMPDisplayName);
                }

                return cachedSlmReportingMPDisplayName;
            }
        }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
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
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("cachedDialogTitle is " + cachedDialogTitle);
                    StringBuilder newDialogTitle = new StringBuilder(cachedDialogTitle);
                    // Replace {2} with the report name: Alerts

                    // Check if ReportDisplayName is not null
                    if (Reporting.ReportDisplayName == null)
                    {
                        throw new Maui.GlobalExceptions.MauiException("Exception in getting Dialog Title for Alerts Dialog! Cannot use ReportDisplayName as it is null!");
                    }

                    newDialogTitle.Replace("{2}", Reporting.ReportDisplayName);
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Remove 2 cachedDialogTitle is " + newDialogTitle);

                    // Replace {0} with System Center Reporting Manager, or *
                    newDialogTitle.Replace("{0}", "*");
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Remove 0 cachedDialogTitle is " + newDialogTitle);

                    // Replace {1} with the name of the MOM Management Group, or *
                    newDialogTitle.Replace("{1}", "*");
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("Remove 1 cachedDialogTitle is " + newDialogTitle);

                    cachedDialogTitle = newDialogTitle.ToString();
                    Mom.Test.UI.Core.Common.Utilities.LogMessage("cachedDialogTitle is " + cachedDialogTitle);
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataAggregation translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataAggregation
            {
                get
                {
                    if ((cachedDataAggregation == null))
                    {
                        cachedDataAggregation = CoreManager.MomConsole.GetIntlStr(ResourceDataAggregation);
                    }
                    
                    return cachedDataAggregation;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddSLA translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddSLA
            {
                get
                {
                    if ((cachedAddSLA == null))
                    {
                        cachedAddSLA = CoreManager.MomConsole.GetIntlStr(ResourceAddSLA);
                    }
                    
                    return cachedAddSLA;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Objects translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Objects
            {
                get
                {
                    if ((cachedObjects == null))
                    {
                        cachedObjects = CoreManager.MomConsole.GetIntlStr(ResourceObjects);
                    }
                    
                    return cachedObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    
                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DownTime translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DownTime
            {
                get
                {
                    if ((cachedDownTime == null))
                    {
                        cachedDownTime = CoreManager.MomConsole.GetIntlStr(ResourceDownTime);
                    }
                    
                    return cachedDownTime;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _BusinessWeekDay translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _BusinessWeekDay
            {
                get
                {
                    if ((cached_BusinessWeekDay == null))
                    {
                        cached_BusinessWeekDay = CoreManager.MomConsole.GetIntlStr(Resource_BusinessWeekDay);
                    }
                    
                    return cached_BusinessWeekDay;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseBusinessHours translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseBusinessHours
            {
                get
                {
                    if ((cachedUseBusinessHours == null))
                    {
                        cachedUseBusinessHours = CoreManager.MomConsole.GetIntlStr(ResourceUseBusinessHours);
                    }
                    
                    return cachedUseBusinessHours;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BusinessHours translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BusinessHours
            {
                get
                {
                    if ((cachedBusinessHours == null))
                    {
                        cachedBusinessHours = CoreManager.MomConsole.GetIntlStr(ResourceBusinessHours);
                    }
                    
                    return cachedBusinessHours;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TimeZone translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeZone
            {
                get
                {
                    if ((cachedTimeZone == null))
                    {
                        cachedTimeZone = CoreManager.MomConsole.GetIntlStr(ResourceTimeZone);
                    }
                    
                    return cachedTimeZone;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the From translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string From
            {
                get
                {
                    if ((cachedFrom == null))
                    {
                        cachedFrom = CoreManager.MomConsole.GetIntlStr(ResourceFrom);
                    }
                    
                    return cachedFrom;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the To translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string To
            {
                get
                {
                    if ((cachedTo == null))
                    {
                        cachedTo = CoreManager.MomConsole.GetIntlStr(ResourceTo);
                    }
                    
                    return cachedTo;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the To translated resource string for yesterday
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DateTimeYesterday
            {
                get
                {
                    if ((cachedDateTimeYesterday == null))
                    {
                        cachedDateTimeYesterday = CoreManager.MomConsole.GetIntlStr(ResourceDateTimeYesterday);
                    }

                    return cachedDateTimeYesterday;
                }
            }
            
            
                /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the To translated resource string for ServiceLevelAggrementColumn
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/8/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelAggrementColumn
            {
                get
                {
                    if ((cachedServiceLevelAggrementColumn == null))
                    {
                        cachedServiceLevelAggrementColumn = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelAggrement);
                    }

                    return cachedServiceLevelAggrementColumn;
                }
            }

            /// <summary>
            /// Service Designer Design Surface Menubar's View option
            /// </summary>
            public static string MenuBarViewOption
            {
                get
                {
                    if ((Strings.cachedMenuBarViewOption == null))
                    {
                        cachedMenuBarViewOption = CoreManager.MomConsole.GetIntlStr(
                            ResourceMenuBarViewOption);
                    }
                    return Strings.cachedMenuBarViewOption;
                }
                set { Strings.cachedMenuBarViewOption = value; }
            }
            /// <summary>
            /// Service Designer View menu Save option
            /// </summary>
            
            
            public static string ViewMenuParameterOption
            {
                get
                {
                    if ((Strings.cachedViewMenuParameterOption == null))
                    {
                        cachedViewMenuParameterOption = CoreManager.MomConsole.GetIntlStr(
                            ResourceViewMenuParameterOption);
                    }
                    return Strings.cachedViewMenuParameterOption;
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
        /// 	[sunsingh] 9/8/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for DataAggregationStaticControl
            /// </summary>
            public const string DataAggregationStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for TimeZoneComboBox
            /// </summary>
            public const string TimeZoneComboBox = "valueEditor";
            
            /// <summary>
            /// Control ID for AddSLAButton
            /// </summary>
            public const string AddSLAButton = "AddSLAButton";
            
            /// <summary>
            /// Control ID for ObjectsStaticControl
            /// </summary>
            public const string ObjectsStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for SelectedSlaGridView
            /// </summary>
            public const string SelectedSlaGridView = "valueList";            
            
            /// <summary>
            /// Control ID for RemoveSLAButton
            /// </summary>
            public const string RemoveSLAButton = "removeButton";
            
            /// <summary>
            /// Control ID for DownTimeStaticControl
            /// </summary>
            public const string DownTimeStaticControl = "nameLabel";

            /// <summary>
            /// Control ID for ReportGeneratingStaticControl
            /// </summary>
            public const string ReportGeneratingStaticControl = "LblGeneratingReport";
            /// <summary>
            /// Control ID for AdditionalTimeIntervalsListBox
            /// </summary>
            public const string AdditionalTimeIntervalsListBox = "valueEditor";
            
            /// <summary>
            /// Control ID for _BusinessWeekDayStaticControl
            /// </summary>
            public const string _BusinessWeekDayStaticControl = "businessHoursLabel";
            
            /// <summary>
            /// Control ID for UseBusinessHoursCheckBox
            /// </summary>
            public const string UseBusinessHoursCheckBox = "businessHoursSelector";
            
            /// <summary>
            /// Control ID for BusinessHoursButton
            /// </summary>
            public const string BusinessHoursButton = "configureBusinessHoursButton";
            
            /// <summary>
            /// Control ID for BusinessWeekDayComboBox
            /// </summary>
            public const string BusinessWeekDayComboBox = "timeZoneSelector";
            
            /// <summary>
            /// Control ID for TimeZoneStaticControl
            /// </summary>
            public const string TimeZoneStaticControl = "timeZoneLabel";
            
            /// <summary>
            /// Control ID for AvailableItemsComboBox
            /// </summary>
            public const string AvailableItemsComboBox = "endTimeEditor";
            
            /// <summary>
            /// Control ID for AvailableItemsComboBox2
            /// </summary>
            public const string AvailableItemsComboBox2 = "startTimeEditor";
            
            /// <summary>
            /// Control ID for SLAReportStartDateComboBox
            /// </summary>
            public const string SLAReportStartDateComboBox = "startDateEditor";
            
            /// <summary>
            /// Control ID for BusinessWeekDayComboBox2
            /// </summary>
            public const string BusinessWeekDayComboBox2 = "endDateEditor";
            
            /// <summary>
            /// Control ID for FromStaticControl
            /// </summary>
            public const string FromStaticControl = "startDateLabel";
            
            /// <summary>
            /// Control ID for ToStaticControl
            /// </summary>
            public const string ToStaticControl = "endDateLabel";
            
            /// <summary>
            /// Control ID for BusinessWeekDayStatusBar
            /// </summary>
            public const string BusinessWeekDayStatusBar = "consoleStatusBar";
            
            /// <summary>
            /// Control ID for Toolbar1
            /// </summary>
            public const string Toolbar1 = "toolBar";
            /// <summary>
            /// Control ID for MainMenu
            /// </summary>
            public const string MainMenu = "Menu Bar";
        }
        #endregion
    }
}
