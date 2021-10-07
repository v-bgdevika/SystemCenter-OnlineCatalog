// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="UpdateInstancePersonalizationDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   Mom.Test.UI.Core.Console.Personalization
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-lileo] 9/25/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent.Personalization
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup
    /// </summary>
    /// <history>
    ///   [v-lileo] 9/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup
    {
        /// <summary>
        /// Ascending = 0
        /// </summary>
        Ascending = 0,
        
        /// <summary>
        /// Descending = 1
        /// </summary>
        Descending = 1,
    }
    #endregion    
    
    #region Interface Definition - IAlertPersonalizationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IUpdateInstancePersonalizationDialogControls, for UpdateInstancePersonalizationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-lileo] 9/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertPersonalizationDialogControls
    {                
        /// <summary>
        /// Gets read-only property to access ColumnsToDisplayCheckBox
        /// </summary>
        CheckBox ColumnsToDisplayCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ListView0
        /// </summary>
        ListView ColumnsDisplayListView
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SortByButton
        /// </summary>
        Button SortByButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SortByListView
        /// </summary>
        ListView SortByListView
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AscendingRadioButton
        /// </summary>
        RadioButton SortByAscendingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DescendingRadioButton
        /// </summary>
        RadioButton SortByDescendingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MoveUpButton
        /// </summary>
        Button SortByMoveUpButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MoveDownButton
        /// </summary>
        Button SortByMoveDownButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access RemoveButton
        /// </summary>
        Button SortByRemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access GroupByButton
        /// </summary>
        Button GroupByButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access GroupByListView
        /// </summary>
        ListView GroupByListView
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AscendingRadioButton2
        /// </summary>
        RadioButton GroupByAscendingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DescendingRadioButton2
        /// </summary>
        RadioButton GroupByDescendingRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MoveUpButton2
        /// </summary>
        Button GroupByMoveUpButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MoveDownButton2
        /// </summary>
        Button GroupByMoveDownButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access RemoveButton2
        /// </summary>
        Button GroupByRemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MoveUpButton
        /// </summary>
        Button ColumnsDisplayMoveUpButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MoveDownButton
        /// </summary>
        Button ColumnsDisplayMoveDownButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ShowButton
        /// </summary>
        Button ColumnsDisplayShowButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HideButton
        /// </summary>
        Button ColumnsDisplayHideButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access RevertButton
        /// </summary>
        Button RevertButton
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
        /// Gets read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    ///   [v-lileo] 9/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertPersonalizationDialog : Dialog, IAlertPersonalizationDialogControls
    {
        #region Private Member Variables
        
        /// <summary>
        /// Cache to hold a reference to ColumnsToDisplayCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedColumnsToDisplayCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ListView0 of type ListView
        /// </summary>
        private ListView cachedColumnsDisplayListView;
        
        /// <summary>
        /// Cache to hold a reference to SortByButton of type Button
        /// </summary>
        private Button cachedSortByButton;
        
        /// <summary>
        /// Cache to hold a reference to SortByListView of type ListView
        /// </summary>
        private ListView cachedSortByListView;
        
        /// <summary>
        /// Cache to hold a reference to AscendingRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSortByAscendingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DescendingRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSortByDescendingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to MoveUpButton of type Button
        /// </summary>
        private Button cachedSortByMoveUpButton;
        
        /// <summary>
        /// Cache to hold a reference to MoveDownButton of type Button
        /// </summary>
        private Button cachedSortByMoveDownButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedSortByRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to GroupByButton of type Button
        /// </summary>
        private Button cachedGroupByButton;
        
        /// <summary>
        /// Cache to hold a reference to GroupByListView of type ListView
        /// </summary>
        private ListView cachedGroupByListView;
        
        /// <summary>
        /// Cache to hold a reference to AscendingRadioButton2 of type RadioButton
        /// </summary>
        private RadioButton cachedGroupByAscendingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DescendingRadioButton2 of type RadioButton
        /// </summary>
        private RadioButton cachedGroupByDescendingRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to MoveUpButton2 of type Button
        /// </summary>
        private Button cachedGroupByMoveUpButton;
        
        /// <summary>
        /// Cache to hold a reference to MoveDownButton2 of type Button
        /// </summary>
        private Button cachedGroupByMoveDownButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton2 of type Button
        /// </summary>
        private Button cachedGroupByRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to MoveUpButton of type Button
        /// </summary>
        private Button cachedColumnsDisplayMoveUpButton;
        
        /// <summary>
        /// Cache to hold a reference to MoveDownButton of type Button
        /// </summary>
        private Button cachedColumnsDisplayMoveDownButton;
        
        /// <summary>
        /// Cache to hold a reference to ShowButton of type Button
        /// </summary>
        private Button cachedColumnsDisplayShowButton;
        
        /// <summary>
        /// Cache to hold a reference to HideButton of type Button
        /// </summary>
        private Button cachedColumnsDisplayHideButton;
        
        /// <summary>
        /// Cache to hold a reference to RevertButton of type Button
        /// </summary>
        private Button cachedRevertButton;
        
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
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the UpdateInstancePersonalizationDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of UpdateInstancePersonalizationDialog of type App
        /// </param>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertPersonalizationDialog(App app, int timeout, string DialogTitle) :
            base(app, Init(app, timeout, DialogTitle))
        {
            
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets functionality for SortBy Radio group 
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup SortByRadioGroup
        {
            get
            {
                if ((this.Controls.SortByAscendingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup.Ascending;
                }

                if ((this.Controls.SortByDescendingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup.Descending;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup.Ascending))
                {
                    this.Controls.SortByAscendingRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup.Descending))
                    {
                        this.Controls.SortByDescendingRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets functionality for GroupBy Radio Group
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup GroupByRadioGroup
        {
            get
            {
                if ((this.Controls.GroupByAscendingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup.Ascending;
                }

                if ((this.Controls.GroupByDescendingRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup.Descending;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup.Ascending))
                {
                    this.Controls.GroupByAscendingRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup.Descending))
                    {
                        this.Controls.GroupByDescendingRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IUpdateInstancePersonalizationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertPersonalizationDialogControls Controls
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
        ///  Property to handle checkbox ColumnsToDisplay
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ColumnsToDisplay
        {
            get
            {
                return this.Controls.ColumnsToDisplayCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ColumnsToDisplayCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnsToDisplayCheckBox control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAlertPersonalizationDialogControls.ColumnsToDisplayCheckBox
        {
            get
            {
                //if ((this.cachedColumnsToDisplayCheckBox == null))
                //{
                    
                //    this.cachedColumnsToDisplayCheckBox = new CheckBox(this,UpdateInstancePersonalizationDialog.QueryIds.ColumnsToDisplay);
                //}

                return this.cachedColumnsToDisplayCheckBox = new CheckBox(this, AlertPersonalizationDialog.QueryIds.ColumnsToDisplay);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnsDisplayListView control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAlertPersonalizationDialogControls.ColumnsDisplayListView
        {
            get
            {
                if ((this.cachedColumnsDisplayListView == null))
                {
                    //workaround, send End keyboard code to make all columns can be got.
                    ListView listView = null;
                    listView = new ListView(this, AlertPersonalizationDialog.QueryIds.ColumnsDisplayListView);
                    listView.Items[0].Select();
                    Keyboard.SendKeys(KeyboardCodes.End);
                    listView = new ListView(this, AlertPersonalizationDialog.QueryIds.ColumnsDisplayListView);

                    Keyboard.SendKeys(KeyboardCodes.Home);
                    this.cachedColumnsDisplayListView = new ListView(this, AlertPersonalizationDialog.QueryIds.ColumnsDisplayListView);
                }
                return this.cachedColumnsDisplayListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SortByButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.SortByButton
        {
            get
            {
                //if ((this.cachedSortByButton == null))
                //{
                    
                //    this.cachedSortByButton = new Button(this,UpdateInstancePersonalizationDialog.QueryIds.SortByButton);
                //}

                Window sortBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='1'"), Core.Common.Constants.DefaultDialogTimeout);
                this.cachedSortByButton = new Button(sortBy, AlertPersonalizationDialog.QueryIds.SortByButton);
                return this.cachedSortByButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SortByListView control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAlertPersonalizationDialogControls.SortByListView
        {
            get
            {
                //if ((this.cachedSortByListView == null))
                //{
                //    Window sortBy = new Window(new QID(";[UIA]AutomationId='SortColumnsControl'"), Core.Common.Constants.DefaultDialogTimeout);
                //    this.cachedSortByListView = new ListView(sortBy, UpdateInstancePersonalizationDialog.QueryIds.SortByListView);
                //}
                Window sortBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='1'"), Core.Common.Constants.DefaultDialogTimeout);
                this.cachedSortByListView = new ListView(sortBy, AlertPersonalizationDialog.QueryIds.SortByListView);
                return this.cachedSortByListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SortByAscendingRadioButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAlertPersonalizationDialogControls.SortByAscendingRadioButton
        {
            get
            {
                //if ((this.cachedSortByAscendingRadioButton == null))
                //{
                Window sortBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='1'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedSortByAscendingRadioButton = new RadioButton(sortBy, AlertPersonalizationDialog.QueryIds.SortByAscendingRadioButton);
                //}

                return this.cachedSortByAscendingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SortByDescendingRadioButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAlertPersonalizationDialogControls.SortByDescendingRadioButton
        {
            get
            {
                //if ((this.cachedSortByDescendingRadioButton == null))
                //{
                Window sortBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='1'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedSortByDescendingRadioButton = new RadioButton(sortBy, AlertPersonalizationDialog.QueryIds.SortByDescendingRadioButton);
                //}

                return this.cachedSortByDescendingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SortByMoveUpButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.SortByMoveUpButton
        {
            get
            {
                //if ((this.cachedSortByMoveUpButton == null))
                //{
                Window sortBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='1'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedSortByMoveUpButton = new Button(sortBy, AlertPersonalizationDialog.QueryIds.SortByMoveUpButton);
                //}

                return this.cachedSortByMoveUpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SortByMoveDownButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.SortByMoveDownButton
        {
            get
            {
                //if ((this.cachedSortByMoveDownButton == null))
                //{
                Window sortBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='1'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedSortByMoveDownButton = new Button(sortBy, AlertPersonalizationDialog.QueryIds.SortByMoveDownButton);
                //}

                return this.cachedSortByMoveDownButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SortByRemoveButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.SortByRemoveButton
        {
            get
            {
                //if ((this.cachedSortByRemoveButton == null))
                //{
                Window sortBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='1'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedSortByRemoveButton = new Button(sortBy, AlertPersonalizationDialog.QueryIds.SortByRemoveButton);
                //}

                return this.cachedSortByRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupByButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.GroupByButton
        {
            get
            {
                //if ((this.cachedGroupByButton == null))
                //{
                Window groupBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='2'"), Core.Common.Constants.DefaultDialogTimeout);
                this.cachedGroupByButton = new Button(groupBy, AlertPersonalizationDialog.QueryIds.GroupByButton);
                //}
                
                return this.cachedGroupByButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupByListView control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAlertPersonalizationDialogControls.GroupByListView
        {
            get
            {
                //if ((this.cachedGroupByListView == null))
                //{

                Window groupBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='2'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedGroupByListView = new ListView(groupBy, AlertPersonalizationDialog.QueryIds.GroupByListView);
                //}
                
                return this.cachedGroupByListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupByAscendingRadioButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAlertPersonalizationDialogControls.GroupByAscendingRadioButton
        {
            get
            {
                //if ((this.cachedGroupByAscendingRadioButton == null))
                //{

                Window groupBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='2'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedGroupByAscendingRadioButton = new RadioButton(groupBy, AlertPersonalizationDialog.QueryIds.GroupByAscendingRadioButton);
                //}

                return this.cachedGroupByAscendingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupByDescendingRadioButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAlertPersonalizationDialogControls.GroupByDescendingRadioButton
        {
            get
            {
                //if ((this.cachedGroupByDescendingRadioButton == null))
                //{

                Window groupBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='2'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedGroupByDescendingRadioButton = new RadioButton(groupBy, AlertPersonalizationDialog.QueryIds.GroupByDescendingRadioButton);
                //}

                return this.cachedGroupByDescendingRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupByMoveUpButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.GroupByMoveUpButton
        {
            get
            {
                //if ((this.cachedGroupByMoveUpButton == null))
                //{

                Window groupBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='2'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedGroupByMoveUpButton = new Button(groupBy, AlertPersonalizationDialog.QueryIds.GroupByMoveUpButton);
                //}

                return this.cachedGroupByMoveUpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupByMoveDownButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.GroupByMoveDownButton
        {
            get
            {                
                //if ((this.cachedGroupByMoveDownButton == null))
                //{
                Window groupBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='2'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedGroupByMoveDownButton = new Button(groupBy, AlertPersonalizationDialog.QueryIds.GroupByMoveDownButton);
                //}

                return this.cachedGroupByMoveDownButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GroupByRemoveButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.GroupByRemoveButton
        {
            get
            {
                //if ((this.cachedGroupByRemoveButton == null))
                //{
                Window groupBy = new Window(new QID(";[UIA]AutomationId = 'SortGroupControl' && Instance='2'"), Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedGroupByRemoveButton = new Button(groupBy, AlertPersonalizationDialog.QueryIds.GroupByRemoveButton);
                //}

                return this.cachedGroupByRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnsDisplayMoveUpButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.ColumnsDisplayMoveUpButton
        {
            get
            {
                //if ((this.cachedColumnsDisplayMoveUpButton == null))
                //{
                this.cachedColumnsDisplayMoveUpButton = new Button(this, AlertPersonalizationDialog.QueryIds.ColumnsDisplayMoveUpButton);
                //}

                return this.cachedColumnsDisplayMoveUpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnsDisplayMoveDownButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.ColumnsDisplayMoveDownButton
        {
            get
            {
                //if ((this.cachedColumnsDisplayMoveDownButton == null))
                //{
                this.cachedColumnsDisplayMoveDownButton = new Button(this, AlertPersonalizationDialog.QueryIds.ColumnsDisplayMoveDownButton);
                //}

                return this.cachedColumnsDisplayMoveDownButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnsDisplayShowButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.ColumnsDisplayShowButton
        {
            get
            {
                //if ((this.cachedColumnsDisplayShowButton == null))
                //{
                this.cachedColumnsDisplayShowButton = new Button(this, AlertPersonalizationDialog.QueryIds.ColumnsDisplayShowButton);
                //}

                return this.cachedColumnsDisplayShowButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ColumnsDisplayHideButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.ColumnsDisplayHideButton
        {
            get
            {
                //if ((this.cachedColumnsDisplayHideButton == null))
                //{
                this.cachedColumnsDisplayHideButton = new Button(this, AlertPersonalizationDialog.QueryIds.ColumnsDisplayHideButton);
                //}

                return this.cachedColumnsDisplayHideButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the RevertButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.RevertButton
        {
            get
            {
                //if ((this.cachedRevertButton == null))
                //{
                this.cachedRevertButton = new Button(this, new QID(";[UIA]Name = '" + Strings.Revert + "' && Role = 'push button'"));
                //}
                
                return this.cachedRevertButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.PreviousButton
        {
            get
            {
                //if ((this.cachedPreviousButton == null))
                //{
                this.cachedPreviousButton = new Button(this, AlertPersonalizationDialog.QueryIds.PreviousButton);
                //}
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.NextButton
        {
            get
            {
                //if ((this.cachedNextButton == null))
                //{
                this.cachedNextButton = new Button(this, AlertPersonalizationDialog.QueryIds.NextButton);
                //}
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.CreateButton
        {
            get
            {
                //if ((this.cachedCreateButton == null))
                //{
                this.cachedCreateButton = new Button(this, AlertPersonalizationDialog.QueryIds.CreateButton);
                //}
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertPersonalizationDialogControls.CancelButton
        {
            get
            {
                //if ((this.cachedCancelButton == null))
                //{
                this.cachedCancelButton = new Button(this, AlertPersonalizationDialog.QueryIds.CancelButton);
                //}
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ColumnsToDisplay
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickColumnsToDisplay()
        {
            this.Controls.ColumnsToDisplayCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SortBy
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSortBy()
        {
            this.Controls.SortByButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SortByMoveUp
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSortByMoveUp()
        {
            this.Controls.SortByMoveUpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SortByMoveDown
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSortByMoveDown()
        {
            this.Controls.SortByMoveDownButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SortByRemove
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSortByRemove()
        {
            this.Controls.SortByRemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupBy
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupBy()
        {
            this.Controls.GroupByButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupByMoveUp
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupByMoveUp()
        {
            this.Controls.GroupByMoveUpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupByMoveDown
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupByMoveDown()
        {
            this.Controls.GroupByMoveDownButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupByRemove
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupByRemove()
        {
            this.Controls.GroupByRemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ColumnsDisplayMoveUp
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickColumnsDisplayMoveUp()
        {
            this.Controls.ColumnsDisplayMoveUpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ColumnsDisplayMoveDown
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickColumnsDisplayMoveDown()
        {
            this.Controls.ColumnsDisplayMoveDownButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ColumnsDisplayShow
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickColumnsDisplayShow()
        {
            this.Controls.ColumnsDisplayShowButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ColumnsDisplayHide
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickColumnsDisplayHide()
        {
            this.Controls.ColumnsDisplayHideButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Revert
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRevert()
        {
            this.Controls.RevertButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
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
        ///   [v-lileo] 9/25/2010 Created
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
        ///   [asttest] 9/25/2010 Created
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
        ///   [v-lileo] 9/25/2010 Created
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
        /// <param name="app">App owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout, string DialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;

            try
            {
                // Try to locate an existing instance of a dialog
		switch(ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + DialogTitle + "' && Role = 'window'"), timeout);
                        break;
                    case ProductSkuLevel.Web:
                        tempWindow = new Window(new QID(string.Format(ConsoleApp.Strings.WebConsoleDialogTitle, DialogTitle)), timeout);
                        break;
                } 
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
			switch (ProductSku.Sku)
                        {
                            case ProductSkuLevel.Mom:
                                tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + DialogTitle + "' && Role = 'window'"), timeout);
                                break;
                            case ProductSkuLevel.Web:
                                tempWindow = new Window(new QID(string.Format(ConsoleApp.Strings.WebConsoleDialogTitle, DialogTitle)), timeout);
                                break;
                        }

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            timeout);
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
                        "Failed to find window with title:  '" +
                        DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ColumnsToDisplay query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceColumnsToDisplay = ";[UIA]AutomationId='HostedCheckBox'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ListView query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceListView = ";[UIA]AutomationId='AllColumns'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Sort By query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddButton = ";[UIA]AutomationId='addButton'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ListView query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSortGroupByListView = ";[UIA]AutomationId='columnsList'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ListView query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            //private const string ResourceGroupByListView = ";[UIA]AutomationId='GroupColumnsControl'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AscendingRadioButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAscendingRadioButton = ";[UIA]AutomationId='Ascending'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DescendingRadioButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescendingRadioButton = ";[UIA]AutomationId='Descending'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Sort and group MoveUpButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoveUpButton = ";[UIA]AutomationId='MoveUp'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for  MoveDownButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoveDownButton = ";[UIA]AutomationId='MoveDown'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveButton = ";[UIA]AutomationId='Remove'";
            
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Columns Display MoveUpButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            //private const string ResourceColumnsDisplayMoveUpButton = ";[UIA]AutomationId='btnMoveUp'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Columns Display MoveDownButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            //private const string ResourceColumnsDisplayMoveDownButton = ";[UIA]AutomationId='btnMoveDown'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Columns Display ShowButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceColumnsDisplayShowButton = ";[UIA]AutomationId='Show'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Columns Display HideButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceColumnsDisplayHideButton = ";[UIA]AutomationId='Hide'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PreviousButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePreviousButton = ";[UIA]AutomationId='WizardPreviousButton'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NextButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNextButton = ";[UIA]AutomationId='WizardNextButton'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CreateButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateButton = ";[UIA]AutomationId='WizardCloseButton'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId='WizardCancelButton'";
            #endregion
            
            #region Properties
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnsToDisplay resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnsToDisplay
            {
                get
                {
                    return new QID(ResourceColumnsToDisplay);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnsDisplayListView resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnsDisplayListView
            {
                get
                {
                    return new QID(ResourceListView );
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SortByButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SortByButton
            {
                get
                {
                    return new QID(ResourceAddButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupByButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupByButton
            {
                get
                {
                    return new QID(ResourceAddButton);
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SortByListView resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SortByListView
            {
                get
                {
                    return new QID(ResourceSortGroupByListView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SortByAscendingRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SortByAscendingRadioButton
            {
                get
                {
                    return new QID(ResourceAscendingRadioButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SortByDescendingRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SortByDescendingRadioButton
            {
                get
                {
                    return new QID(ResourceDescendingRadioButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SortByMoveUpButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SortByMoveUpButton
            {
                get
                {
                    return new QID(ResourceMoveUpButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SortByMoveDownButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SortByMoveDownButton
            {
                get
                {
                    return new QID(ResourceMoveDownButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SortByRemoveButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SortByRemoveButton
            {
                get
                {
                    return new QID(ResourceRemoveButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupByListView resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupByListView
            {
                get
                {
                    return new QID(ResourceSortGroupByListView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupByAscendingRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupByAscendingRadioButton
            {
                get
                {
                    return new QID(ResourceAscendingRadioButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupByDescendingRadioButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupByDescendingRadioButton
            {
                get
                {
                    return new QID(ResourceDescendingRadioButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupByMoveUpButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupByMoveUpButton
            {
                get
                {
                    return new QID(ResourceMoveUpButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupByMoveDownButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupByMoveDownButton
            {
                get
                {
                    return new QID(ResourceMoveDownButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GroupByRemoveButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID GroupByRemoveButton
            {
                get
                {
                    return new QID(ResourceRemoveButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnsDisplayMoveUpButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnsDisplayMoveUpButton
            {
                get
                {
                    return new QID(ResourceMoveUpButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnsDisplayMoveDownButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnsDisplayMoveDownButton
            {
                get
                {
                    return new QID(ResourceMoveDownButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnsDisplayShowButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnsDisplayShowButton
            {
                get
                {
                    return new QID(ResourceColumnsDisplayShowButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ColumnsDisplayHideButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ColumnsDisplayHideButton
            {
                get
                {
                    return new QID(ResourceColumnsDisplayHideButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
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
            ///   [v-lileo] 9/25/2010 Created
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
            /// Gets access to the CreateButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CreateButton
            {
                get
                {
                    return new QID(ResourceCreateButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 9/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    return new QID(ResourceCancelButton);
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Need Use Resources String.
        /// </summary>
        /// <history>
        ///   [v-lileo] 9/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Update Instance Personalization
            /// </summary>
            public const string PersonalizationDialogTitle = "Personalize";
            
            /// <summary>
            /// Resource string for Configuration
            /// </summary>
            public const string ConfigurationDialogTitle = "Update Configuration";

            /// <summary>
            /// Resource string for Sort by
            /// </summary>
            public const string SortBy = "Sort by";
            
            /// <summary>
            /// Resource string for Group by
            /// </summary>
            public const string GroupBy = "Group by";   
            
            /// <summary>
            /// Resource string for Revert
            /// </summary>
            public const string Revert = "Revert";           
            
        }
        #endregion

        #region enum
        /// <summary>
        /// Types of ConfigrationType
        /// </summary>
        public enum enumPersonalizationModalDialogType
        {
            /// <summary>
            /// 
            /// </summary>
            Configuration,

            /// <summary>
            /// 
            /// </summary>
            Personalization,

        }
        #endregion
    }
}
