// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MultiPickerControl.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   System Center Console Framework
// </project>
// <summary>
//   MultiPickerControl Controls
// </summary>
// <history>
//   [v-lileo] 11/25/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System.ComponentModel;
    using System.Linq;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
    using System.Collections.Generic;
    using dataAccess = Microsoft.EnterpriseManagement.Presentation.DataAccess;
    #endregion

    #region Interface Definition - IMultiPickerControlControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMultiPickerControlControls, for Window.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-lileo] 11/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMultiPickerControlControls
    {
        /// <summary>
        /// Gets read-only property to access AvailableItemsButton
        /// </summary>
        Button AvailableItemsButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access DataGridInAvailableItemsView
        /// </summary>
        DataGridControl DataGridInAvailableItemsView
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access SelectedItemsButton
        /// </summary>
        Button SelectedItemsButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access DataGridInSelectedItemsView
        /// </summary>
        DataGridControl DataGridInSelectedItemsView
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ErrorLink
        /// </summary>
        Button ErrorLink
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ProgressIndicator
        /// </summary>
        ProgressBar ProgressIndicator
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access SelectAll button
        /// </summary>
        Button SelectAll
        {
            get;
        }
    }
    #endregion

        
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add window functionality description here.
    /// </summary>
    /// <history>
    ///   [v-lileo] 11/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MultiPickerControl:IMultiPickerControlControls
    {       
        #region Private Member Variables

        private Window Content = null;

        private Window cachedAvailableItemsView;

        /// <summary>
        /// Cache to hold a reference to AvailableItems9Button of type Button
        /// </summary>
        private Button cachedAvailableItemsButton;
        
        /// <summary>
        /// Cache to hold a reference to DataGridInAvailableItemsView of type DataGridControl
        /// </summary>
        private DataGridControl cachedDataGridInAvailableItemsView;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;

        /// <summary>
        /// Cache to hold a reference to selectedItemsView of type window
        /// </summary>
        private Window cachedselectedItemsView;

        /// <summary>
        /// Cache to hold a reference to SelectedItemsButton of type Button
        /// </summary>
        private Button cachedSelectedItemsButton;
        
        /// <summary>
        /// Cache to hold a reference to DataGridInSelectedItemsView of type DataGridControl
        /// </summary>
        private DataGridControl cachedDataGridInSelectedItemsView;

        /// <summary>
        /// Cache to hold a reference to ErrorLink of type button
        /// </summary>
        private Button cachedErrorLinkButton;

        /// <summary>
        /// Cache to hold a reference to ProgressIndicator of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressIndicator;

        /// <summary>
        /// Cache to hold a reference to ProgressIndicator of type ProgressBar
        /// </summary>
        private Button cachedSelectAllButton;

        #endregion

        public FilterControl filter;

        #region Constructors
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Window class.
        /// </summary>
        /// <param name='app'> </param>
        /// <param name='timeOut'> </param>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MultiPickerControl(Window KnownWindow)
        {           
            Content = KnownWindow;
        }

        #endregion

        #region IMultiPickerControl Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMultiPickerControlControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Public Control Properties
        
        /// <summary>
        /// Filter Control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupandObjectFilterControl Filter
        {
            get
            {
                return new GroupandObjectFilterControl(this.Content);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AvailableItemsButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiPickerControlControls.AvailableItemsButton
        {
            get
            {
                if ((this.cachedAvailableItemsButton == null))
                {
                    //Window AvailableItemsView = new Window(this.Content, MultiPickerControl.QueryIds.AvailableItemsView, Constants.DefaultDialogTimeout);
                    //this.cachedAvailableItemsButton = new Button(AvailableItemsView, MultiPickerControl.QueryIds.ItemsButton);
                    this.cachedAvailableItemsButton = new Button(this.Content,MultiPickerControl.QueryIds.AvailableItemsView);
                }
                return this.cachedAvailableItemsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DataGridInAvailableItemsView control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGridControl IMultiPickerControlControls.DataGridInAvailableItemsView
        {
            get
            {
                if ((this.cachedDataGridInAvailableItemsView == null))
                {
                    //Window AvailableItemsView = new Window(this.Content, MultiPickerControl.QueryIds.AvailableItemsView, Constants.DefaultDialogTimeout);
                    Window AvailableItemsSCOMDataGrid = new Window(this.Content, new QID(";[UIA]AutomationId='SCOMDataGrid' && Instance = '1'"), Constants.DefaultDialogTimeout);
                    this.cachedDataGridInAvailableItemsView = new DataGridControl(AvailableItemsSCOMDataGrid, MultiPickerControl.QueryIds.DataGrid);
                }
                
                return this.cachedDataGridInAvailableItemsView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AddButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiPickerControlControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this.Content, MultiPickerControl.QueryIds.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the RemoveButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiPickerControlControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this.Content, MultiPickerControl.QueryIds.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SelectedItemsButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiPickerControlControls.SelectedItemsButton
        {
            get
            {
                if ((this.cachedSelectedItemsButton == null))
                {
                    Window selectedItemsView = new Window(this.Content, MultiPickerControl.QueryIds.SelectedItemsView,Constants.DefaultDialogTimeout);
                    this.cachedSelectedItemsButton = new Button(selectedItemsView, MultiPickerControl.QueryIds.ItemsButton);
                }
                
                return this.cachedSelectedItemsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DataGridInSelectedItemsView control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGridControl IMultiPickerControlControls.DataGridInSelectedItemsView
        {
            get
            {
                if ((this.cachedDataGridInSelectedItemsView == null))
                {
                    Window selectedItemsSCOMDataGrid = new Window(this.Content, new QID(";[UIA]AutomationId='SCOMDataGrid' && Instance = '2'"), Constants.DefaultDialogTimeout);
                    this.cachedDataGridInSelectedItemsView = new DataGridControl(selectedItemsSCOMDataGrid, MultiPickerControl.QueryIds.DataGrid);
                }
                
                return this.cachedDataGridInSelectedItemsView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ErrorLink button
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/03/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiPickerControlControls.ErrorLink
        {
            get
            {
                if (this.cachedErrorLinkButton == null)
                {
                    //TODO: Need Get right QID
                    this.cachedErrorLinkButton = new Button(this.Content, MultiPickerControl.QueryIds.ErrorLink);
                }
                return this.cachedErrorLinkButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressIndicator ProgressBar
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/03/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ProgressBar IMultiPickerControlControls.ProgressIndicator
        {
            get
            {
                if (this.cachedProgressIndicator == null)
                {
                    this.cachedProgressIndicator = new ProgressBar(this.Content,MultiPickerControl.QueryIds.ProgressBar);
                }
                return this.cachedProgressIndicator;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Select All button
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/03/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiPickerControlControls.SelectAll
        {
            get
            {
                if (this.cachedSelectAllButton == null)
                {
                    this.cachedSelectAllButton = new Button(this.Content, MultiPickerControl.QueryIds.SelectAll);
                }
                return this.cachedSelectAllButton;
            }
        }
        #endregion
        
        #region Public Methods
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Routine to click on button ErrorLinkButton
        /// </summary>
        /// <history>
        ///   [v-lileo] 12/03/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickErrorLinkButton()
        {
            this.Controls.ErrorLink.Click();
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AvailableItemsButton
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAvailableItemsButton()
        {
            this.Controls.AvailableItemsButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddButton()
        {
            this.Controls.AddButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemoveButton()
        {
            this.Controls.RemoveButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectedItems4
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectedItemsButton()
        {
            this.Controls.SelectedItemsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Selected All
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelecteAllButton()
        {
            this.Controls.SelectAll.Click();
        }

        public void Filtercontrol(string FilterText)
        {
            filter = new FilterControl(this.Content);
            if (this.filter.FilterTextBox.IsVisible)
            {
               CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(
                    delegate()
                    {
                        if (this.filter.FilterTextBox.Text != FilterText)
                        {
                            this.filter.FilterTextBox.Text = string.Empty;
                            this.filter.FilterTextBox.SetValueWithPaste(FilterText);
                            Utilities.TakeScreenshot("MultiPickerControl.Filtercontrol");
                            Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond * 2);
                        }

                       return this.filter.FilterTextBox.Text == FilterText;
                    },

                    Mom.Test.UI.Core.Common.Constants.OneMinute);
            }
        }

        /// <summary>
        /// Method for add item to selected view from available item view
        /// </summary>
        /// <param name="Properties">Dictionary<string,List<string>> Properties</param>
        /// <param name="selectAll">bool </param>
        public void AddItemsToSelectedView(Dictionary<string,List<string>> Properties,bool selectAll)
        {
            if (selectAll == true)
            {
                Utilities.LogMessage("AddItemsToSelectedView:: select all items in available items view");
                this.Controls.DataGridInAvailableItemsView.RowsExtended[0].ScreenElement.LeftButtonClick(-1, -1);
                Keyboard.SendKeys(Core.Common.KeyboardCodes.Ctrl + "a");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.Controls.AddButton, Constants.TenSeconds);
                this.ClickAddButton();
            }
            else if (Properties != null)
            {                
                Utilities.LogMessage("AddItemsToSelectedView:: select one or multi-items in available items view");
                List<int> rowIndex = this.Controls.DataGridInAvailableItemsView.GetRowIndex(Properties);
                foreach (int selectRow in rowIndex)
                {
                    if (selectRow != -1) 
                    {
                        if (selectRow != 0) // first row will be selected as default ,we changed 1 to 0 ,0 should be the first row
                        {
                            int retry = 0;
                            while (retry < Constants.DefaultMaxRetry) //we will retry to click item if failed first time
                            {
                                try
                                {
                                    this.Controls.DataGridInAvailableItemsView.RowsExtended[selectRow].ScreenElement.EnsureVisible();
                                    this.Controls.DataGridInAvailableItemsView.RowsExtended[selectRow].ScreenElement.LeftButtonClick(-1, -1);
                                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.Controls.AddButton, Constants.TenSeconds);
                                    break;
                                }
                                catch
                                {
                                    retry++;
                                    Sleeper.Delay(Constants.OneSecond);
                                    if (retry >= Constants.DefaultMaxRetry)
                                    {
                                        throw;
                                    }

                                }
                            }
                        }

                        this.ClickAddButton();
                        Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond);
                    }
                }

                Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond);                
            }
        }

        /// <summary>
        /// Method for verify item added to selected view
        /// </summary>
        /// <param name="Properties">Dictionary<string, List<string>> Properties</param>
        /// <returns>true or false</returns>
        public bool VerifyItemAddedToSelectedView(Dictionary<string, List<string>> Properties)
        {
            Utilities.LogMessage("VerifyItemAddedToSelectedView::... ");
            bool result = false;
            if (Properties != null)
            {
                Utilities.LogMessage("VerifyItemAddedToSelectedView:: Get all added items index in Selected Items View");
                List<int> rowIndex = this.Controls.DataGridInSelectedItemsView.GetRowIndex(Properties);
                foreach (int addedRow in rowIndex)
                {
                    if (addedRow != -1)
                    {
                        Utilities.LogMessage("VerifyItemAddedToSelectedView:: The item found, continue verify next item");
                        result = true;
                    }
                    else
                    {

                        Utilities.LogMessage("VerifyItemAddedToSelectedView:: The item not found, return false");
                        return false;
                    }
                }
            }
            else
            {

                Utilities.LogMessage("VerifyItemAddedToSelectedView:: The Properties is null, return false");
                return false;
            }

            return result;
        }

        /// <summary>
        /// Method for remove item(s) in selected view
        /// </summary>
        /// <param name="Properties">Dictionary<string, List<string>> Properties</param>
        /// <param name="removeAll">bool removeAll</param>
        public void RemoveItemsInSelectedView(Dictionary<string, List<string>> Properties, bool removeAll)
        {
            if (removeAll == true)
            {
                Utilities.LogMessage("RemoveItemsInSelectedView:: select all items in Selected items view");
                this.Controls.DataGridInSelectedItemsView.RowsExtended[0].Select();
                Keyboard.SendKeys(Core.Common.KeyboardCodes.Ctrl + "a");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.Controls.RemoveButton, Constants.TenSeconds);
                this.ClickRemoveButton();
            }
            else if(Properties!=null)
            {
                Utilities.LogMessage("RemoveItemsInSelectedView:: select one or multi-items in Selected items view");
                List<int> rowIndex = this.Controls.DataGridInSelectedItemsView.GetRowIndex(Properties);
                foreach (int selectRow in rowIndex)
                {
                    if (selectRow != null && selectRow != -1)
                    {
                        this.Controls.DataGridInSelectedItemsView.ScreenElement.EnsureVisible();
                        this.Controls.DataGridInSelectedItemsView.RowsExtended[selectRow].ScreenElement.LeftButtonClick(-1, -1, true, KeyboardFlags.ControlFlag);
                        Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond);
                    }
                }
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.Controls.RemoveButton, Constants.TenSeconds);
                this.ClickRemoveButton();
                Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond);
            }
        }

        /// <summary>
        /// Method for verify item removed from selected view
        /// </summary>
        /// <param name="Properties">Dictionary<string, List<string>> Properties</param>
        /// <returns>True or false</returns>
        public bool VerifyItemRemovedFromSelecteView(Dictionary<string, List<string>> Properties)
        {

            Utilities.LogMessage("VerifyItemRemovedFromSelecteView::... ");
            bool result = false;
            if (Properties != null)
            {
                Utilities.LogMessage("VerifyItemRemovedFromSelecteView:: Try to get all Removed items index in Selected Items View, should return -1");
                List<int> rowIndex = this.Controls.DataGridInSelectedItemsView.GetRowIndex(Properties);
                if (rowIndex.Count==0)
                {
                    Utilities.LogMessage("VerifyItemRemovedFromSelecteView:: Data Grid view don't have any row,the items remove, return ture");
                    return true;
                }
                foreach (int removedRow in rowIndex)
                {
                    if (removedRow != -1)
                    {
                        Utilities.LogMessage("VerifyItemRemovedFromSelecteView:: The item found, removed item failed, return false");
                        return false;
                    }
                    else
                    {

                        Utilities.LogMessage("VerifyItemRemovedFromSelecteView:: not found the item, the item removed");
                        result = true;
                    }
                }
            }
            else
            {

                Utilities.LogMessage("VerifyItemRemovedFromSelecteView:: The Properties is null, return false");
                return false;
            }

            return result;
        }
        #endregion
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AvailableItems9Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItemsView = ";[UIA]AutomationId=\'MultiPickerAvailableItemsExpander\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AvailableItems9Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedItemsView = ";[UIA]AutomationId=\'MultiPickerSelectedItemsExpander\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SCOMDataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSCOMDataGrid = ";[UIA]AutomationId=\'SCOMDataGrid\'";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AvailableItems9Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceItemsButton = ";[UIA]AutomationId=\'HeaderSite\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DataGrid1 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AddButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddButton = ";[UIA]AutomationId=\'MultiPickerAddButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveButton = ";[UIA]AutomationId=\'MultiPickerRemoveButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorLinkButton = ";[UIA]AutomationId=\'isErrorHourGlassIsBusyLinkControl\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProgressBar = ";[UIA]AutomationId=\'isErrorLineIsBusyProgressBarControl\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RemoveButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAllButton = ";[UIA]AutomationId=\'SelectAll\'";
            
            #endregion
            
            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AvailableItemsView resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AvailableItemsView
            {
                get
                {
                    return new QID(ResourceAvailableItemsView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectedItemsView resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectedItemsView
            {
                get
                {
                    return new QID(ResourceSelectedItemsView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ResourceItemsButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ItemsButton
            {
                get
                {
                    return new QID(ResourceItemsButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DataGrid1 resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DataGrid
            {
                get
                {
                    return new QID(ResourceDataGrid);
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SCOMDataGrid resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SCOMDataGrid
            {
                get
                {
                    return new QID(ResourceSCOMDataGrid);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AddButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AddButton
            {
                get
                {
                    return new QID(ResourceAddButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the RemoveButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID RemoveButton
            {
                get
                {
                    return new QID(ResourceRemoveButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Error link resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ErrorLink
            {
                get
                {
                    return new QID(ResourceErrorLinkButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Progress bar resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar
            {
                get
                {
                    return new QID(ResourceProgressBar);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SelectAll button resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectAll
            {
                get
                {
                    return new QID(ResourceSelectAllButton);
                }
            }
            
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for MultiPickerControlTitle
            /// </summary>
            public const string MultiPickerControlTitle = "MultiPickerControl";
        }
        #endregion
    }
}
