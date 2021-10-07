// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OptionsInSlaAddObjectDialog.cs">
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
    
    #region Interface Definition - IOptionsInSlaAddObjectDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOptionsInSlaAddObjectDialogControls, for OptionsInSlaAddObjectDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 9/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOptionsInSlaAddObjectDialogControls
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
        /// Read-only property to access SearchTimeIntervalEndDateListBox
        /// </summary>
        ListBox SearchTimeIntervalEndDateListBox 
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
        /// Read-only property to access IncludeSLAsFromTheFollowingManagementGroupsStaticControl
        /// </summary>
        StaticControl IncludeSLAsFromTheFollowingManagementGroupsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchTimeIntervalStartDateStaticControl
        /// </summary>
        StaticControl SearchTimeIntervalStartDateStaticControl
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
        /// Read-only property to access SearchTimeIntervalEndDateStaticControl
        /// </summary>
        StaticControl SearchTimeIntervalEndDateStaticControl
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
        /// Read-only property to access SelectedObjectsListView
        /// </summary>
        ListView SelectedObjectsListView
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
        /// Read-only property to access SelectedObjectsListView2
        /// </summary>
        ListView SelectedObjectsListView2
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
    public class OptionsInSlaAddObjectDialog : Dialog, IOptionsInSlaAddObjectDialogControls
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
        /// Cache to hold a reference to SearchTimeIntervalEndDateListBox of type ListBox
        /// </summary>
        private ListBox cachedSearchTimeIntervalEndDateListBox;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAvailableItemsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to IncludeSLAsFromTheFollowingManagementGroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIncludeSLAsFromTheFollowingManagementGroupsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalStartDateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchTimeIntervalStartDateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedAvailableItemsComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalEndDateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchTimeIntervalEndDateStaticControl;
        
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
        /// Cache to hold a reference to SelectedObjectsListView of type ListView
        /// </summary>
        private ListView cachedSelectedObjectsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedObjectsListView2 of type ListView
        /// </summary>
        private ListView cachedSelectedObjectsListView2;
        
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
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OptionsInSlaAddObjectDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OptionsInSlaAddObjectDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IOptionsInSlaAddObjectDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOptionsInSlaAddObjectDialogControls Controls
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
        ///  Routine to set/get the text in control AvailableItems
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
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
        /// 	[sunsingh] 9/5/2008 Created
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
        Button IOptionsInSlaAddObjectDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, OptionsInSlaAddObjectDialog.ControlIDs.CancelButton);
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
        Button IOptionsInSlaAddObjectDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, OptionsInSlaAddObjectDialog.ControlIDs.OKButton);
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
        ComboBox IOptionsInSlaAddObjectDialogControls.ObjectsComboBox
        {
            get
            {
                if ((this.cachedObjectsComboBox == null))
                {
                    this.cachedObjectsComboBox = new ComboBox(this, OptionsInSlaAddObjectDialog.ControlIDs.ObjectsComboBox);
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
        Button IOptionsInSlaAddObjectDialogControls.OptionsButton
        {
            get
            {
                if ((this.cachedOptionsButton == null))
                {
                    this.cachedOptionsButton = new Button(this, OptionsInSlaAddObjectDialog.ControlIDs.OptionsButton);
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
        Button IOptionsInSlaAddObjectDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, OptionsInSlaAddObjectDialog.ControlIDs.SearchButton);
                }
                
                return this.cachedSearchButton;
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
        ListBox IOptionsInSlaAddObjectDialogControls.SearchTimeIntervalEndDateListBox
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
        ///  Exposes access to the AvailableItemsComboBox control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOptionsInSlaAddObjectDialogControls.AvailableItemsComboBox
        {
            get
            {
                if ((this.cachedAvailableItemsComboBox == null))
                {
                    this.cachedAvailableItemsComboBox = new ComboBox(this, OptionsInSlaAddObjectDialog.ControlIDs.AvailableItemsComboBox);
                }
                
                return this.cachedAvailableItemsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeSLAsFromTheFollowingManagementGroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInSlaAddObjectDialogControls.IncludeSLAsFromTheFollowingManagementGroupsStaticControl
        {
            get
            {
                if ((this.cachedIncludeSLAsFromTheFollowingManagementGroupsStaticControl == null))
                {
                    this.cachedIncludeSLAsFromTheFollowingManagementGroupsStaticControl = new StaticControl(this, OptionsInSlaAddObjectDialog.ControlIDs.IncludeSLAsFromTheFollowingManagementGroupsStaticControl);
                }
                
                return this.cachedIncludeSLAsFromTheFollowingManagementGroupsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalStartDateStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInSlaAddObjectDialogControls.SearchTimeIntervalStartDateStaticControl
        {
            get
            {
                if ((this.cachedSearchTimeIntervalStartDateStaticControl == null))
                {
                    this.cachedSearchTimeIntervalStartDateStaticControl = new StaticControl(this, OptionsInSlaAddObjectDialog.ControlIDs.SearchTimeIntervalStartDateStaticControl);
                }
                
                return this.cachedSearchTimeIntervalStartDateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsComboBox2 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOptionsInSlaAddObjectDialogControls.AvailableItemsComboBox2
        {
            get
            {
                if ((this.cachedAvailableItemsComboBox2 == null))
                {
                    this.cachedAvailableItemsComboBox2 = new ComboBox(this, OptionsInSlaAddObjectDialog.ControlIDs.AvailableItemsComboBox2);
                }
                
                return this.cachedAvailableItemsComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalEndDateStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInSlaAddObjectDialogControls.SearchTimeIntervalEndDateStaticControl
        {
            get
            {
                if ((this.cachedSearchTimeIntervalEndDateStaticControl == null))
                {
                    this.cachedSearchTimeIntervalEndDateStaticControl = new StaticControl(this, OptionsInSlaAddObjectDialog.ControlIDs.SearchTimeIntervalEndDateStaticControl);
                }
                
                return this.cachedSearchTimeIntervalEndDateStaticControl;
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
        TextBox IOptionsInSlaAddObjectDialogControls.ObjectsTextBox
        {
            get
            {
                if ((this.cachedObjectsTextBox == null))
                {
                    this.cachedObjectsTextBox = new TextBox(this, OptionsInSlaAddObjectDialog.ControlIDs.ObjectsTextBox);
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
        StaticControl IOptionsInSlaAddObjectDialogControls.TypeNameStaticControl
        {
            get
            {
                if ((this.cachedTypeNameStaticControl == null))
                {
                    this.cachedTypeNameStaticControl = new StaticControl(this, OptionsInSlaAddObjectDialog.ControlIDs.TypeNameStaticControl);
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
        StaticControl IOptionsInSlaAddObjectDialogControls.ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl
        {
            get
            {
                if ((this.cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl == null))
                {
                    this.cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl = new StaticControl(this, OptionsInSlaAddObjectDialog.ControlIDs.ToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl);
                }
                
                return this.cachedToAddSLAsToThisReportSearchForTheSLAAndThenAddThemToTheSelectedSLAsListStaticControl;
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
        ListView IOptionsInSlaAddObjectDialogControls.SelectedObjectsListView
        {
            get
            {
                if ((this.cachedSelectedObjectsListView == null))
                {
                    this.cachedSelectedObjectsListView = new ListView(this, OptionsInSlaAddObjectDialog.ControlIDs.SelectedObjectsListView);
                }
                
                return this.cachedSelectedObjectsListView;
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
        StaticControl IOptionsInSlaAddObjectDialogControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = new StaticControl(this, OptionsInSlaAddObjectDialog.ControlIDs.AvailableItemsStaticControl);
                }
                
                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedObjectsListView2 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 9/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IOptionsInSlaAddObjectDialogControls.SelectedObjectsListView2
        {
            get
            {
                if ((this.cachedSelectedObjectsListView2 == null))
                {
                    this.cachedSelectedObjectsListView2 = new ListView(this, OptionsInSlaAddObjectDialog.ControlIDs.SelectedObjectsListView2);
                }
                
                return this.cachedSelectedObjectsListView2;
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
        Button IOptionsInSlaAddObjectDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, OptionsInSlaAddObjectDialog.ControlIDs.AddButton);
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
        Button IOptionsInSlaAddObjectDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, OptionsInSlaAddObjectDialog.ControlIDs.RemoveButton);
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
        StaticControl IOptionsInSlaAddObjectDialogControls.SelectedObjectsStaticControl
        {
            get
            {
                if ((this.cachedSelectedObjectsStaticControl == null))
                {
                    this.cachedSelectedObjectsStaticControl = new StaticControl(this, OptionsInSlaAddObjectDialog.ControlIDs.SelectedObjectsStaticControl);
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
            private const string ResourceDialogTitle = "Add SLA";
            
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
            private const string ResourceOptions = ";O&ptions <<;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitorin" +
                "g.ReportMonitoringObjectPickerResources;SearchButton_OptionsClosed";
            
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
            /// Contains resource string for:  IncludeSLAsFromTheFollowingManagementGroups
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncludeSLAsFromTheFollowingManagementGroups = "Include SLAs from the following Management Groups:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchTimeIntervalStartDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchTimeIntervalStartDate = ";Search time interval start date:;ManagedString;Microsoft.EnterpriseManagement.UI" +
                ".Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Paramete" +
                "rs.Controls.Monitoring.ReportMonitoringPerformanceRuleSearchCriteria;startDateLa" +
                "bel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchTimeIntervalEndDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchTimeIntervalEndDate = ";Search time interval end date:;ManagedString;Microsoft.EnterpriseManagement.UI.R" +
                "eporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters" +
                ".Controls.Monitoring.ReportMonitoringPerformanceRuleSearchCriteria;endDateLabel." +
                "Text";
            
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
            /// Caches the translated resource string for:  IncludeSLAsFromTheFollowingManagementGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIncludeSLAsFromTheFollowingManagementGroups;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SearchTimeIntervalStartDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchTimeIntervalStartDate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SearchTimeIntervalEndDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchTimeIntervalEndDate;
            
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
            /// Exposes access to the IncludeSLAsFromTheFollowingManagementGroups translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IncludeSLAsFromTheFollowingManagementGroups
            {
                get
                {
                    if ((cachedIncludeSLAsFromTheFollowingManagementGroups == null))
                    {
                        cachedIncludeSLAsFromTheFollowingManagementGroups = CoreManager.MomConsole.GetIntlStr(ResourceIncludeSLAsFromTheFollowingManagementGroups);
                    }
                    
                    return cachedIncludeSLAsFromTheFollowingManagementGroups;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchTimeIntervalStartDate translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchTimeIntervalStartDate
            {
                get
                {
                    if ((cachedSearchTimeIntervalStartDate == null))
                    {
                        cachedSearchTimeIntervalStartDate = CoreManager.MomConsole.GetIntlStr(ResourceSearchTimeIntervalStartDate);
                    }
                    
                    return cachedSearchTimeIntervalStartDate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchTimeIntervalEndDate translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 9/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchTimeIntervalEndDate
            {
                get
                {
                    if ((cachedSearchTimeIntervalEndDate == null))
                    {
                        cachedSearchTimeIntervalEndDate = CoreManager.MomConsole.GetIntlStr(ResourceSearchTimeIntervalEndDate);
                    }
                    
                    return cachedSearchTimeIntervalEndDate;
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
            public const string CancelButton = "cancelButton";
            
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
            /// Control ID for SearchTimeIntervalEndDateListBox
            /// </summary>
            public const string SearchTimeIntervalEndDateListBox = "groupEditor";
            
            /// <summary>
            /// Control ID for AvailableItemsComboBox
            /// </summary>
            public const string AvailableItemsComboBox = "startDateEditor";
            
            /// <summary>
            /// Control ID for IncludeSLAsFromTheFollowingManagementGroupsStaticControl
            /// </summary>
            public const string IncludeSLAsFromTheFollowingManagementGroupsStaticControl = "groupLabel";
            
            /// <summary>
            /// Control ID for SearchTimeIntervalStartDateStaticControl
            /// </summary>
            public const string SearchTimeIntervalStartDateStaticControl = "startDateLabel";
            
            /// <summary>
            /// Control ID for AvailableItemsComboBox2
            /// </summary>
            public const string AvailableItemsComboBox2 = "endDateEditor";
            
            /// <summary>
            /// Control ID for SearchTimeIntervalEndDateStaticControl
            /// </summary>
            public const string SearchTimeIntervalEndDateStaticControl = "endDateLabel";
            
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
            /// Control ID for SelectedObjectsListView
            /// </summary>
            public const string SelectedObjectsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AvailableItemsStaticControl
            /// </summary>
            public const string AvailableItemsStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for SelectedObjectsListView2
            /// </summary>
            public const string SelectedObjectsListView2 = "selectedItemsListview";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for SelectedObjectsStaticControl
            /// </summary>
            public const string SelectedObjectsStaticControl = "selectedObjectsLabel";
        }
        #endregion
    }
}
