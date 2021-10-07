// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddSLAObjectDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sunsingh] 9/5/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAddSLAObjectDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddSLAObjectDialogControls, for AddSLAObjectDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 9/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddSLAObjectDialogControls
    {
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
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
        /// Read-only property to access ObjectsComboBox
        /// </summary>
        ComboBox ObjectsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OptionsButton
        /// </summary>
        Button OptionsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchButton
        /// </summary>
        Button SearchButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectsTextBox
        /// </summary>
        TextBox ObjectsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TypeNameStaticControl
        /// </summary>
        StaticControl TypeNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl
        /// </summary>
        StaticControl ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableItemsListView
        /// </summary>
        ListView AvailableItemsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableItemsStaticControl
        /// </summary>
        StaticControl AvailableItemsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedObjectsListView
        /// </summary>
        ListView SelectedObjectsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedObjectsStaticControl
        /// </summary>
        StaticControl SelectedObjectsStaticControl
        {
            get;
        }
        /// <summary>
        /// Read-only property to access SearchTimeIntervalEndDateListBox
        /// </summary>
        ListBox SearchTimeIntervalEndDateListBox
        {
            get;
        }
        /// <summary>
        /// property to access SlaintervalEndDate
        /// </summary>
        ComboBox SlaintervalEndDate
        {
            get;
        }
        /// <summary>
        /// property to access SlaintervalStartDate
        /// </summary>
        ComboBox SlaintervalStartDate
        {
            get;
        }

        /// <summary>
        /// property to access SlaintervalStartDatePicker
        /// </summary>
        DateTimePicker SlaintervalStartDatePicker 
        {
            get;
            
        }
        /// <summary>
        /// property to access SlaintervalEndDatePicker
        /// </summary>
        DateTimePicker SlaintervalEndDatePicker 
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
    /// 	[sunsingh] 9/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddSLAObjectDialog : Dialog, IAddSLAObjectDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedObjectsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to OptionsButton of type Button
        /// </summary>
        private Button cachedOptionsButton;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to ObjectsTextBox of type TextBox
        /// </summary>
        private TextBox cachedObjectsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TypeNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTypeNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsListView of type ListView
        /// </summary>
        private ListView cachedAvailableItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedObjectsListView of type ListView
        /// </summary>
        private ListView cachedSelectedObjectsListView;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectedObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedObjectsStaticControl;
        /// <summary>
        /// Cache to hold a reference to cachedSlaintervalStartDate of type ComboBox
        /// </summary>
        private ComboBox cachedSlaintervalStartDate;
        /// <summary>
        /// Cache to hold a reference to cachedSlaintervalEndDate of type ComboBox
        /// </summary>
        private ComboBox cachedSlaintervalEndDate;

        /// <summary>
        /// Cache to hold a reference to SelectedObjectsStaticControl of type ListBox
        /// </summary>
        private ListBox cachedSearchTimeIntervalEndDateListBox;

        /// <summary>
        /// Cache to hold a reference to SlaintervalStartDatePicker of type DateTimePicker
        /// </summary>
        private DateTimePicker cachedSlaintervalStartDatePicker;
        /// <summary>
        /// Cache to hold a reference to cachedSlaintervalEndDatePicker of type DateTimePicker
        /// </summary>
        private DateTimePicker cachedSlaintervalEndDatePicker;


        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddSLAObjectDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddSLAObjectDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddSLAObjectDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddSLAObjectDialogControls Controls
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
        ///  Exposes access to the SlaintervalStartDate control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddSLAObjectDialogControls.SlaintervalStartDate
        {
           get
            {
                if ((this.cachedSlaintervalStartDate == null))
                {

                    this.cachedSlaintervalStartDate = new ComboBox(this, AddSLAObjectDialog.ControlIDs.SlaintervalStartDate);
                }

                return this.cachedSlaintervalStartDate;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartDate picker control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker IAddSLAObjectDialogControls.SlaintervalStartDatePicker
        {
            get
            {
                if ((this.cachedSlaintervalStartDatePicker == null))
                {

                    this.cachedSlaintervalStartDatePicker = new DateTimePicker(this, AddSLAObjectDialog.ControlIDs.SlaintervalStartDate);
                }

                return this.cachedSlaintervalStartDatePicker;
            }           
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndDate picker control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker IAddSLAObjectDialogControls.SlaintervalEndDatePicker
        {
            get
            {
                if ((this.cachedSlaintervalEndDatePicker == null))
                {

                    this.cachedSlaintervalEndDatePicker = new DateTimePicker(this, AddSLAObjectDialog.ControlIDs.SlaintervalEndDate);
                }

                return this.cachedSlaintervalEndDatePicker;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Objects
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SlaintervalStartDateText
        {
            get
            {
                return this.Controls.SlaintervalStartDate.Text;
            }

            set
            {
                this.Controls.SlaintervalStartDate.SelectByText(value, true);
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AvailableItems2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddSLAObjectDialogControls.SlaintervalEndDate
        {
            get
            {
                if ((this.cachedSlaintervalEndDate == null))
                {
                    this.cachedSlaintervalEndDate = new ComboBox(this, ControlIDs.SlaintervalEndDate);
                }

                return this.cachedSlaintervalEndDate;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Objects
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SlaintervalEndDateText
        {
            get
            {
                return this.Controls.SlaintervalEndDate.Text;
            }

            set
            {
                this.Controls.SlaintervalEndDate.SelectByText(value, true);
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalEndDateListBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAddSLAObjectDialogControls.SearchTimeIntervalEndDateListBox
        {
            get
            {
                if ((this.cachedSearchTimeIntervalEndDateListBox == null))
                {
                    this.cachedSearchTimeIntervalEndDateListBox = new ListBox(this, OptionsInSlaAddObjectDialog.ControlIDs.SearchTimeIntervalEndDateListBox);
                }

                return this.cachedSearchTimeIntervalEndDateListBox;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Objects
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ObjectsText
        {
            get
            {
                return this.Controls.ObjectsComboBox.Text;
            }
            
            set
            {
                this.Controls.ObjectsComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Objects2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string Objects2Text
        {
            get
            {
                return this.Controls.ObjectsTextBox.Text;
            }
            
            set
            {
                this.Controls.ObjectsTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddSLAObjectDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddSLAObjectDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddSLAObjectDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddSLAObjectDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddSLAObjectDialogControls.ObjectsComboBox
        {
            get
            {
                if ((this.cachedObjectsComboBox == null))
                {
                    this.cachedObjectsComboBox = new ComboBox(this, AddSLAObjectDialog.ControlIDs.ObjectsComboBox);
                }
                
                return this.cachedObjectsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptionsButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddSLAObjectDialogControls.OptionsButton
        {
            get
            {
                if ((this.cachedOptionsButton == null))
                {
                    this.cachedOptionsButton = new Button(this, AddSLAObjectDialog.ControlIDs.OptionsButton);
                }
                
                return this.cachedOptionsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddSLAObjectDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, AddSLAObjectDialog.ControlIDs.SearchButton);
                }
                
                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectsTextBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddSLAObjectDialogControls.ObjectsTextBox
        {
            get
            {
                if ((this.cachedObjectsTextBox == null))
                {
                    this.cachedObjectsTextBox = new TextBox(this, AddSLAObjectDialog.ControlIDs.ObjectsTextBox);
                }
                
                return this.cachedObjectsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddSLAObjectDialogControls.TypeNameStaticControl
        {
            get
            {
                if ((this.cachedTypeNameStaticControl == null))
                {
                    this.cachedTypeNameStaticControl = new StaticControl(this, AddSLAObjectDialog.ControlIDs.TypeNameStaticControl);
                }
                
                return this.cachedTypeNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddSLAObjectDialogControls.ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl
        {
            get
            {
                if ((this.cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl == null))
                {
                    this.cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl = new StaticControl(this, AddSLAObjectDialog.ControlIDs.ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl);
                }
                
                return this.cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsListView control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAddSLAObjectDialogControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + AddSLAObjectDialog.ControlIDs.AvailableItemsListView + "'"));
                }
                
                return this.cachedAvailableItemsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddSLAObjectDialogControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = new StaticControl(this, AddSLAObjectDialog.ControlIDs.AvailableItemsStaticControl);
                }
                
                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedObjectsListView control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAddSLAObjectDialogControls.SelectedObjectsListView
        {
            get
            {
                if ((this.cachedSelectedObjectsListView == null))
                {
                    this.cachedSelectedObjectsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + AddSLAObjectDialog.ControlIDs.SelectedObjectsListView + "'"));
                }
                
                return this.cachedSelectedObjectsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddSLAObjectDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, AddSLAObjectDialog.ControlIDs.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddSLAObjectDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, AddSLAObjectDialog.ControlIDs.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddSLAObjectDialogControls.SelectedObjectsStaticControl
        {
            get
            {
                if ((this.cachedSelectedObjectsStaticControl == null))
                {
                    this.cachedSelectedObjectsStaticControl = new StaticControl(this, AddSLAObjectDialog.ControlIDs.SelectedObjectsStaticControl);
                }
                
                return this.cachedSelectedObjectsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
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
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Options
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOptions()
        {
            this.Controls.OptionsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
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
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

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
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
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
            private const string ResourceDialogTitle = ";Add Service Levels;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringSLAPickerDialog;$this.Text";
                //";Create Group Wizard - Object Selection;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringTypePickerDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Options
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOptions = ";O&ptions >>;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitorin" +
                "g.ReportMonitoringObjectPickerResources;SearchButton_OptionsOpened";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";&Search;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.GroupSearchCriteria;searchButto" +
                "n.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TypeName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTypeName = ";Type Name:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring" +
                ".ReportMonitoringSearchTypesCriteria;nameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList = "To add SLAs to this report, search for the SLA and then add them to the \'Selected" +
                " SLAs\' list.";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems = ";Available items;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Controls.ChooserControl;availableObjects.CaptionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";&Add;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSchedul" +
                "ePage;periods.AddButtonText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";&Remove;ManagedString;Corgent.Diagramming.CommandResources.dll;Corgent.Diagrammi" +
                "ng.CommandResources.Properties.Resources;Command_Remove";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedObjects = ";Selected &objects;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Controls.ChooserControl;selectedObjects.CaptionText";
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
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Options
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOptions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TypeName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTypeName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAvailableItems;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedObjects;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
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
            /// Exposes access to the Options translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Options
            {
                get
                {
                    if ((cachedOptions == null))
                    {
                        cachedOptions = CoreManager.MomConsole.GetIntlStr(ResourceOptions);
                    }
                    
                    return cachedOptions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Search
            {
                get
                {
                    if ((cachedSearch == null))
                    {
                        cachedSearch = CoreManager.MomConsole.GetIntlStr(ResourceSearch);
                    }
                    
                    return cachedSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TypeName translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TypeName
            {
                get
                {
                    if ((cachedTypeName == null))
                    {
                        cachedTypeName = CoreManager.MomConsole.GetIntlStr(ResourceTypeName);
                    }
                    
                    return cachedTypeName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList
            {
                get
                {
                    if ((cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList == null))
                    {
                        cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList = CoreManager.MomConsole.GetIntlStr(ResourceToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList);
                    }
                    
                    return cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AvailableItems translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AvailableItems
            {
                get
                {
                    if ((cachedAvailableItems == null))
                    {
                        cachedAvailableItems = CoreManager.MomConsole.GetIntlStr(ResourceAvailableItems);
                    }
                    
                    return cachedAvailableItems;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    
                    return cachedAdd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
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
            /// Exposes access to the SelectedObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedObjects
            {
                get
                {
                    if ((cachedSelectedObjects == null))
                    {
                        cachedSelectedObjects = CoreManager.MomConsole.GetIntlStr(ResourceSelectedObjects);
                    }
                    
                    return cachedSelectedObjects;
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
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for ObjectsComboBox
            /// </summary>
            public const string ObjectsComboBox = "patternComboBox";
            
            /// <summary>
            /// Control ID for OptionsButton
            /// </summary>
            public const string OptionsButton = "optionsButton";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for ObjectsTextBox
            /// </summary>
            public const string ObjectsTextBox = "nameEditor";
            
            /// <summary>
            /// Control ID for TypeNameStaticControl
            /// </summary>
            public const string TypeNameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl
            /// </summary>
            public const string ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl = "searchHelpLabel";
            
            /// <summary>
            /// Control ID for AvailableItemsListView
            /// </summary>
            public const string AvailableItemsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AvailableItemsStaticControl
            /// </summary>
            public const string AvailableItemsStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for SelectedObjectsListView
            /// </summary>
            public const string SelectedObjectsListView = "selectedItemsListview";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>c
            /// Control ID for SelectedObjectsStaticControl
            /// </summary>
            public const string SelectedObjectsStaticControl = "selectedObjectsLabel";
            /// <summary>
            /// Control ID for SearchTimeIntervalEndDateListBox
            /// </summary>
            public const string SearchTimeIntervalEndDateListBox = "groupEditor";

            /// <summary>
            /// Control ID for SlaintervalStartDate
            /// </summary>
            public const string SlaintervalStartDate = "startDateEditor";

            /// <summary>
            /// Control ID for SlaintervalEndDate
            /// </summary>
            public const string SlaintervalEndDate = "endDateEditor";
            
        }
        #endregion
    }
}
