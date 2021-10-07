// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MultiObjectPicker.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-juli] 5/23/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.StateWidget
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;

    #region Radio Group Enumeration - RadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup
    /// </summary>
    /// <history>
    ///   [v-juli] 5/23/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup
    {
        /// <summary>
        /// ShowOnly_groupsSelectingAGroupCausesItesMembersToBeDisplayed = 0
        /// </summary>
        ShowOnly_groupsSelectingAGroupCausesItesMembersToBeDisplayed = 0,
        
        /// <summary>
        /// ShowAll_objectsAndGroupsSelectingAGroupDoesNotCauseItsMembersToBeDisplayed = 1
        /// </summary>
        ShowAll_objectsAndGroupsSelectingAGroupDoesNotCauseItsMembersToBeDisplayed = 1,
    }
    #endregion
    
    #region Interface Definition - IMultiObjectPickerControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMultiObjectPickerControls, for MultiObjectPicker.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-juli] 5/23/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMultiObjectPickerControls
    {
        /// <summary>
        /// Gets read-only property to access ShowOnlyGroups
        /// </summary>
        RadioButton ShowOnlyGroups
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ShowAllObjects
        /// </summary>
        RadioButton ShowAllObjects
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ShowAllObjectsAndGroupsTextBox
        /// </summary>
        TextBox ShowAllObjectsAndGroupsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SCOMFilterControlSearchButtonButton
        /// </summary>
        Button SCOMFilterControlSearchButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SCOMFilterControlCloseButtonButton
        /// </summary>
        Button SCOMFilterControlCloseButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HeaderSiteButton
        /// </summary>
        Button HeaderSiteButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ErrorButtonButton
        /// </summary>
        Button ErrorButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ProgressBar1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ProgressBar ProgressBar1
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AvailableItemsDataGrid
        /// </summary>
        DataGridControl AvailableItemsDataGrid
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access A_ddButton
        /// </summary>
        Button A_ddButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access _RemoveButton
        /// </summary>
        Button _RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HeaderSiteButton2
        /// </summary>
        Button HeaderSiteButton2
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SelectedItemsDataGrid
        /// </summary>
        DataGridControl SelectedItemsDataGrid
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access OkButton
        /// </summary>
        Button OkButton
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
    ///   [v-juli] 5/23/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class MultiObjectPicker : Dialog, IMultiObjectPickerControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ShowOnlyGroups of type RadioButton
        /// </summary>
        private RadioButton cachedShowOnlyGroups;
        
        /// <summary>
        /// Cache to hold a reference to ShowAllObjects of type RadioButton
        /// </summary>
        private RadioButton cachedShowAllObjects;
        
        /// <summary>
        /// Cache to hold a reference to ShowAllObjectsAndGroupsTextBox of type TextBox
        /// </summary>
        private TextBox cachedShowAllObjectsAndGroupsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SCOMFilterControlSearchButtonButton of type Button
        /// </summary>
        private Button cachedSCOMFilterControlSearchButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to SCOMFilterControlCloseButtonButton of type Button
        /// </summary>
        private Button cachedSCOMFilterControlCloseButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to HeaderSiteButton of type Button
        /// </summary>
        private Button cachedHeaderSiteButton;
        
        /// <summary>
        /// Cache to hold a reference to ErrorButtonButton of type Button
        /// </summary>
        private Button cachedErrorButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to ProgressBar1 of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressBar1;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsDataGrid of type DataGrid
        /// </summary>
        private DataGridControl cachedAvailableItemsDataGrid;
        
        /// <summary>
        /// Cache to hold a reference to A_ddButton of type Button
        /// </summary>
        private Button cachedA_ddButton;
        
        /// <summary>
        /// Cache to hold a reference to _RemoveButton of type Button
        /// </summary>
        private Button cached_RemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to HeaderSiteButton2 of type Button
        /// </summary>
        private Button cachedHeaderSiteButton2;
        
        /// <summary>
        /// Cache to hold a reference to SelectedItemsDataGrid of type DataGrid
        /// </summary>
        private DataGridControl cachedSelectedItemsDataGrid;
        
        /// <summary>
        /// Cache to hold a reference to OkButton of type Button
        /// </summary>
        private Button cachedOkButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the MultiObjectPicker class.
        /// </summary>
        /// <param name='app'>
        /// Owner of MultiObjectPicker of type StateWidget
        /// </param>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MultiObjectPicker(App app, int timeout, string dialogTitle) :
            base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets functionality for radio group RadioGroup
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup RadioGroup
        {
            get
            {
                if ((this.Controls.ShowOnlyGroups.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup.ShowOnly_groupsSelectingAGroupCausesItesMembersToBeDisplayed;
                }
                
                if ((this.Controls.ShowAllObjects.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup.ShowAll_objectsAndGroupsSelectingAGroupDoesNotCauseItsMembersToBeDisplayed;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup.ShowOnly_groupsSelectingAGroupCausesItesMembersToBeDisplayed))
                {
                    this.Controls.ShowOnlyGroups.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup.ShowAll_objectsAndGroupsSelectingAGroupDoesNotCauseItsMembersToBeDisplayed))
                    {
                        this.Controls.ShowAllObjects.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IMultiObjectPicker Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMultiObjectPickerControls Controls
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
        ///  Gets or sets the text in control ShowAllObjectsAndGroupsText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ShowAllObjectsAndGroupsText
        {
            get
            {
                return this.Controls.ShowAllObjectsAndGroupsTextBox.Text;
            }
            
            set
            {
                this.Controls.ShowAllObjectsAndGroupsTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ShowOnlyGroups control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IMultiObjectPickerControls.ShowOnlyGroups
        {
            get
            {
                if ((this.cachedShowOnlyGroups == null))
                {
                    this.cachedShowOnlyGroups = new RadioButton(this, MultiObjectPicker.QueryIds.ShowOnlyGroups);
                }
                
                return this.cachedShowOnlyGroups;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ShowAllObjects control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IMultiObjectPickerControls.ShowAllObjects
        {
            get
            {
                if ((this.cachedShowAllObjects == null))
                {
                    this.cachedShowAllObjects = new RadioButton(this, MultiObjectPicker.QueryIds.ShowAllObjects);
                }
                
                return this.cachedShowAllObjects;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ShowAllObjectsAndGroupsTextBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMultiObjectPickerControls.ShowAllObjectsAndGroupsTextBox
        {
            get
            {
                if ((this.cachedShowAllObjectsAndGroupsTextBox == null))
                {
                    this.cachedShowAllObjectsAndGroupsTextBox = new TextBox(this, MultiObjectPicker.QueryIds.ShowAllObjectsAndGroupsTextBox);
                }
                
                return this.cachedShowAllObjectsAndGroupsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SCOMFilterControlSearchButtonButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls.SCOMFilterControlSearchButtonButton
        {
            get
            {
                if ((this.cachedSCOMFilterControlSearchButtonButton == null))
                {
                    this.cachedSCOMFilterControlSearchButtonButton = new Button(this, MultiObjectPicker.QueryIds.SCOMFilterControlSearchButtonButton);
                }
                
                return this.cachedSCOMFilterControlSearchButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SCOMFilterControlCloseButtonButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls.SCOMFilterControlCloseButtonButton
        {
            get
            {
                if ((this.cachedSCOMFilterControlCloseButtonButton == null))
                {
                    this.cachedSCOMFilterControlCloseButtonButton = new Button(this, MultiObjectPicker.QueryIds.SCOMFilterControlCloseButtonButton);
                }
                
                return this.cachedSCOMFilterControlCloseButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HeaderSiteButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls.HeaderSiteButton
        {
            get
            {
                if ((this.cachedHeaderSiteButton == null))
                {
                    this.cachedHeaderSiteButton = new Button(this, MultiObjectPicker.QueryIds.HeaderSiteButton);
                }
                
                return this.cachedHeaderSiteButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ErrorButtonButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls.ErrorButtonButton
        {
            get
            {
                if ((this.cachedErrorButtonButton == null))
                {
                    this.cachedErrorButtonButton = new Button(this, MultiObjectPicker.QueryIds.ErrorButtonButton);
                }
                
                return this.cachedErrorButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressBar1 control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ProgressBar IMultiObjectPickerControls.ProgressBar1
        {
            get
            {
                if ((this.cachedProgressBar1 == null))
                {
                    this.cachedProgressBar1 = new ProgressBar(this, MultiObjectPicker.QueryIds.ProgressBar1);
                }
                
                return this.cachedProgressBar1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AvailableItemsDataGrid control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGridControl IMultiObjectPickerControls.AvailableItemsDataGrid
        {
            get
            {
                if ((this.cachedAvailableItemsDataGrid == null))
                {                    
                    Window AvailableItemsSCOMDataGrid = new Window(this, new QID(";[UIA]AutomationId='SCOMDataGrid' && Instance = '1'"), Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedAvailableItemsDataGrid = new DataGridControl(AvailableItemsSCOMDataGrid, MultiPickerControl.QueryIds.DataGrid);
              
                }
                
                return this.cachedAvailableItemsDataGrid;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the A_ddButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls.A_ddButton
        {
            get
            {
                if ((this.cachedA_ddButton == null))
                {
                    this.cachedA_ddButton = new Button(this, MultiObjectPicker.QueryIds.A_ddButton);
                }
                
                return this.cachedA_ddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the _RemoveButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls._RemoveButton
        {
            get
            {
                if ((this.cached_RemoveButton == null))
                {
                    this.cached_RemoveButton = new Button(this, MultiObjectPicker.QueryIds._RemoveButton);
                }
                
                return this.cached_RemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HeaderSiteButton2 control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (HeaderSite) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls.HeaderSiteButton2
        {
            get
            {
                // TODO: The ID for this control (HeaderSite) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedHeaderSiteButton2 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 7); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedHeaderSiteButton2 = new Button(wndTemp);
                }
                
                return this.cachedHeaderSiteButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SelectedItemsDataGrid control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (InnerDataGrid) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        DataGridControl IMultiObjectPickerControls.SelectedItemsDataGrid
        {
            get
            {                
                if ((this.cachedSelectedItemsDataGrid == null))
                {                   
                    Window selectedItemsSCOMDataGrid = new Window(this, new QID(";[UIA]AutomationId='SCOMDataGrid' && Instance = '2'"), Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout);
                    this.cachedSelectedItemsDataGrid = new DataGridControl(selectedItemsSCOMDataGrid, MultiPickerControl.QueryIds.DataGrid);
            
                }
                
                return this.cachedSelectedItemsDataGrid;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OkButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls.OkButton
        {
            get
            {
                if ((this.cachedOkButton == null))
                {
                    this.cachedOkButton = new Button(this, MultiObjectPicker.QueryIds.OkButton);
                }
                
                return this.cachedOkButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiObjectPickerControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MultiObjectPicker.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SCOMFilterControlSearchButton
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSCOMFilterControlSearchButton()
        {
            this.Controls.SCOMFilterControlSearchButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SCOMFilterControlCloseButton
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSCOMFilterControlCloseButton()
        {
            this.Controls.SCOMFilterControlCloseButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button HeaderSite
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHeaderSite()
        {
            this.Controls.HeaderSiteButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ErrorButton
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickErrorButton()
        {
            this.Controls.ErrorButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button A_dd
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickA_dd()
        {
            this.Controls.A_ddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button _Remove
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void Click_Remove()
        {
            this.Controls._RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button HeaderSite2
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHeaderSite2()
        {
            this.Controls.HeaderSiteButton2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ok
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOk()
        {
            this.Controls.OkButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
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
        /// <param name="app">StateWidget owning the dialog.</param>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout, string dialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.MainWindow, new QID(";[UIA, VisibleOnly]Name = '" + dialogTitle + "' && Role = 'window'"), Timeout);
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
                        tempWindow = new Window(dialogTitle, StringMatchSyntax.WildCard);
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
                    throw;
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
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ShowOnlyGroups query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowOnlyGroups = ";[UIA]AutomationId=\'groupsRadioButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ShowAllObjects query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowAllObjects = ";[UIA]AutomationId=\'groupsAndObjectsRadioButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ShowAllObjectsAndGroupsTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowAllObjectsAndGroupsTextBox = ";[UIA]AutomationId=\'SCOMWatermarkTextBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SCOMFilterControlSearchButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSCOMFilterControlSearchButtonButton = ";[UIA]AutomationId=\'SCOMFilterControlSearchButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SCOMFilterControlCloseButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSCOMFilterControlCloseButtonButton = ";[UIA]AutomationId=\'SCOMFilterControlCloseButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for HeaderSiteButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderSiteButton = ";[UIA]AutomationId=\'HeaderSite\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ErrorButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorButtonButton = ";[UIA]AutomationId=\'errorButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ProgressBar1 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProgressBar1 = ";[UIA]AutomationId=\'progressBar\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AvailableItemsDataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItemsDataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for A_ddButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceA_ddButton = ";[UIA]AutomationId=\'MultiPickerAddButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for _RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_RemoveButton = ";[UIA]AutomationId=\'MultiPickerRemoveButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for HeaderSiteButton2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderSiteButton2 = ";[UIA]AutomationId=\'HeaderSite\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SelectedItemsDataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedItemsDataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for OkButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOkButton = ";[UIA]AutomationId=\'OkButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'CancelButton\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowOnlyGroups resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowOnlyGroups
            {
                get
                {
                    return new QID(ResourceShowOnlyGroups);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowAllObjects resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowAllObjects
            {
                get
                {
                    return new QID(ResourceShowAllObjects);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowAllObjectsAndGroupsTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowAllObjectsAndGroupsTextBox
            {
                get
                {
                    return new QID(ResourceShowAllObjectsAndGroupsTextBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SCOMFilterControlSearchButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SCOMFilterControlSearchButtonButton
            {
                get
                {
                    return new QID(ResourceSCOMFilterControlSearchButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SCOMFilterControlCloseButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SCOMFilterControlCloseButtonButton
            {
                get
                {
                    return new QID(ResourceSCOMFilterControlCloseButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the HeaderSiteButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID HeaderSiteButton
            {
                get
                {
                    return new QID(ResourceHeaderSiteButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ErrorButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ErrorButtonButton
            {
                get
                {
                    return new QID(ResourceErrorButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ProgressBar1 resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar1
            {
                get
                {
                    return new QID(ResourceProgressBar1);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AvailableItemsDataGrid resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AvailableItemsDataGrid
            {
                get
                {
                    return new QID(ResourceAvailableItemsDataGrid);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the A_ddButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID A_ddButton
            {
                get
                {
                    return new QID(ResourceA_ddButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the _RemoveButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID _RemoveButton
            {
                get
                {
                    return new QID(Resource_RemoveButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the HeaderSiteButton2 resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID HeaderSiteButton2
            {
                get
                {
                    return new QID(ResourceHeaderSiteButton2);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectedItemsDataGrid resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectedItemsDataGrid
            {
                get
                {
                    return new QID(ResourceSelectedItemsDataGrid);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OkButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OkButton
            {
                get
                {
                    return new QID(ResourceOkButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
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
        
    }
}
