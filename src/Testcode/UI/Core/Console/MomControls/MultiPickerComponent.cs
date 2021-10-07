// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Window.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   System Center Console Framework
// </project>
// <summary>
//   MultiPicker Compoment Controls
// </summary>
// <history>
//   [v-lileo] 11/25/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using System.Collections.Generic;
    using Mom.Test.UI.Core.Common;

    #endregion

    #region Interface Definition - IMultiPickerComponentControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMultiPickerComponentControls, for Window.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-lileo] 11/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMultiPickerComponentControls
    {
        /// <summary>
        /// Gets read-only property to access MultiObjectPickerComponentStaticControl
        /// </summary>
        StaticControl MultiObjectPickerComponentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MultiPickerComponentAddButtonButton
        /// </summary>
        Button MultiPickerComponentAddButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access MultiPickerComponentRemoveButtonButton
        /// </summary>
        Button MultiPickerComponentRemoveButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AddDataGrid
        /// </summary>
        DataGridControl DataGrid
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class for MultiPicker Component
    /// </summary>
    /// <history>
    ///   [v-lileo] 11/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class MultiPickerComponent: Control, IMultiPickerComponentControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
                
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to MultiObjectPickerComponentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMultiObjectPickerComponentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MultiPickerComponentAddButtonButton of type Button
        /// </summary>
        private Button cachedMultiPickerComponentAddButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to MultiPickerComponentRemoveButtonButton of type Button
        /// </summary>
        private Button cachedMultiPickerComponentRemoveButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to AddDataGrid of type DataGrid
        /// </summary>
        private DataGridControl cachedAddDataGrid;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Window class.
        /// </summary>
        /// <param name='app'>App owning the window.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MultiPickerComponent(Window knownWindow, int timeOut) :
            base(Init(knownWindow, timeOut))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IMultiPickerComponent Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the MultiPickerComponent's control properties together</value>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMultiPickerComponentControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MultiObjectPickerComponentStaticControl control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMultiPickerComponentControls.MultiObjectPickerComponentStaticControl
        {
            get
            {
                if ((this.cachedMultiObjectPickerComponentStaticControl == null))
                {
                    this.cachedMultiObjectPickerComponentStaticControl = new StaticControl(this, MultiPickerComponent.QueryIds.MultiObjectPickerComponentStaticControl);
                }
                
                return this.cachedMultiObjectPickerComponentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MultiPickerComponentAddButtonButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiPickerComponentControls.MultiPickerComponentAddButtonButton
        {
            get
            {
                if ((this.cachedMultiPickerComponentAddButtonButton == null))
                {
                    this.cachedMultiPickerComponentAddButtonButton = new Button(this, MultiPickerComponent.QueryIds.MultiPickerComponentAddButtonButton);
                }
                
                return this.cachedMultiPickerComponentAddButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MultiPickerComponentRemoveButtonButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMultiPickerComponentControls.MultiPickerComponentRemoveButtonButton
        {
            get
            {
                if ((this.cachedMultiPickerComponentRemoveButtonButton == null))
                {
                    this.cachedMultiPickerComponentRemoveButtonButton = new Button(this, MultiPickerComponent.QueryIds.MultiPickerComponentRemoveButtonButton);
                }
                
                return this.cachedMultiPickerComponentRemoveButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AddDataGrid control
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGridControl IMultiPickerComponentControls.DataGrid
        {
            get
            {
                if ((this.cachedAddDataGrid == null))
                {
                    this.cachedAddDataGrid = new DataGridControl(this, MultiPickerComponent.QueryIds.DataGrid);
                }
                
                return this.cachedAddDataGrid;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MultiPickerComponentAddButton
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMultiPickerComponentAddButton()
        {
            this.Controls.MultiPickerComponentAddButtonButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MultiPickerComponentRemoveButton
        /// </summary>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMultiPickerComponentRemoveButton()
        {
            this.Controls.MultiPickerComponentRemoveButtonButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="app">app owning the window.</param>
        ///  <param name="timeOut">timeOut.</param>
        /// <history>
        ///   [v-lileo] 11/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Window knownWindow, int timeOut)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = new Window(knownWindow, new QID(";[UIA, VisibleOnly]ClassName = '" + Strings.MultiPickerComponentTitle + "'"), timeOut);
            }
            catch (Exceptions.WindowNotFoundException )
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
                        tempWindow = new Window(knownWindow, new QID(";[UIA, VisibleOnly]ClassName = '" + Strings.MultiPickerComponentTitle + "'"), timeOut);
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

        /// <summary>
        /// Method for remove item from multi picker component view
        /// </summary>
        /// <param name="Properties">Dictionary<string, List<string>> type for Properties</param>
        public void RemoveItemFromMultiPickerComponentView(Dictionary<string, List<string>> Properties)
        {
            if (Properties!= null)
            {
                Utilities.LogMessage("RemoveItemFromMultiPickerComponetView:: select one or multi-items in available items view");
                List<int> rowIndex = this.Controls.DataGrid.GetRowIndex(Properties);
                               
                foreach (int selectRow in rowIndex)
                {
                    if (selectRow != null && selectRow != -1)
                    {
                        this.ScreenElement.EnsureVisible();

                        if (selectRow > 0)
                        {
                            //this.Controls.DataGrid.RowsExtended[selectRow].ScreenElement.LeftButtonClick(-1, -1, true, KeyboardFlags.ControlFlag);
                            //Use ctrl+a to select the row in the grid, since leftbutton is not worked well
                            this.Controls.DataGrid.SendKeys(KeyboardCodes.Ctrl + "a");
                            Sleeper.Delay(1000);
                        }
                        else
                        {
                            
                            //this.Controls.DataGrid.RowsExtended[selectRow].ScreenElement.LeftButtonClick(-1, -1);
                            this.Controls.DataGrid.SendKeys(KeyboardCodes.Ctrl + "a");
                            Sleeper.Delay(1000);
                        }     
                    }
                }
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.Controls.MultiPickerComponentRemoveButtonButton, Constants.TenSeconds);
                this.ClickMultiPickerComponentRemoveButton();
                Sleeper.Delay(1000);
            }
        }

        /// <summary>
        /// Verify item added to mulit picker component view
        /// </summary>
        /// <param name="Properties">Dictionary<string, List<string>> Properties</param>
        /// <returns>true or false</returns>
        public bool VerifyItemAddedToMultiPickerComponentView(Dictionary<string, List<string>> Properties)
        {
            Utilities.LogMessage("VerifyItemAddedToMultiPickerComponetView::...");
            bool result = false;
            if (Properties != null)
            {
                Utilities.LogMessage("VerifyItemAddedToMultiPickerComponetView:: Get the added Items index in MultiPickerComponentView");
                List<int> rowIndex = this.Controls.DataGrid.GetRowIndex(Properties);
                foreach (int addedRow in rowIndex)
                {
                    if (addedRow != -1)
                    {
                        Utilities.LogMessage("VerifyItemAddedToMultiPickerComponentView:: The item found, continue verify next item");
                        result = true;
                    }
                    else
                    {

                        Utilities.LogMessage("VerifyItemAddedToMultiPickerComponentView:: The item not found, return false");
                        return false;
                    }
                }
            }
            else
            {

                Utilities.LogMessage("VerifyItemAddedToMultiPickerComponetView:: The Properties is null, return false");
                return false;
            }

            return result;
        }

        /// <summary>
        /// Verify item remove from multi Picker component view
        /// </summary>
        /// <param name="Properties"></param>
        /// <returns></returns>
        public bool VerifyItemRemovedFromMultiPickerComponentView(Dictionary<string, List<string>> Properties)
        {

            Utilities.LogMessage("VerifyItemRemovedFromMultiPickerComponentView::... ");
            bool result = false;
            if (Properties != null)
            {
                Utilities.LogMessage("VerifyItemRemovedFromMultiPickerComponentView:: Try to get all Removed items index in Selected Items View, should return -1");
                List<int> rowIndex = this.Controls.DataGrid.GetRowIndex(Properties);
                if (rowIndex.Count==0)
                {
                    Utilities.LogMessage("VerifyItemRemovedFromMultiPickerComponentView:: Data Grid view don't have any row,the items remove, return ture");
                    return true;
                }
                foreach (int removedRow in rowIndex)
                {
                    if (removedRow != -1)
                    {
                        Utilities.LogMessage("VerifyItemRemovedFromMultiPickerComponentView:: The item found, removed item failed, return false");
                        return false;
                    }
                    else
                    {

                        Utilities.LogMessage("VerifyItemRemovedFromMultiPickerComponentView:: not found the item, removed item successful");
                        result = true;
                    }
                }
            }
            else
            {

                Utilities.LogMessage("VerifyItemRemovedFromMultiPickerComponentView:: The Properties is null, return false");
                return false;
            }

            return result;
        }

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
            /// Contains resource string for MultiObjectPickerComponentStaticControl query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMultiObjectPickerComponentStaticControl = ";[UIA]AutomationId=\'MultiPickerComponentTitle\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MultiPickerComponentAddButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMultiPickerComponentAddButtonButton = ";[UIA]AutomationId=\'MultiPickerComponentAddButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MultiPickerComponentRemoveButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMultiPickerComponentRemoveButtonButton = ";[UIA]AutomationId=\'MultiPickerComponentRemoveButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the MultiObjectPickerComponentStaticControl resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MultiObjectPickerComponentStaticControl
            {
                get
                {
                    return new QID(ResourceMultiObjectPickerComponentStaticControl);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the MultiPickerComponentAddButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MultiPickerComponentAddButtonButton
            {
                get
                {
                    return new QID(ResourceMultiPickerComponentAddButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the MultiPickerComponentRemoveButtonButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 11/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MultiPickerComponentRemoveButtonButton
            {
                get
                {
                    return new QID(ResourceMultiPickerComponentRemoveButtonButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DataGrid resource qid string
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
            /// Resource string for 
            /// </summary>
            public const string MultiPickerComponentTitle = "MultiPickerComponent";
            
            /// <summary>
            /// Resource string for Multi Object Picker Component :
            /// </summary>
            public const string MultiObjectPickerComponent = "Multi Object Picker Component :";
        }
        #endregion
    }
}
