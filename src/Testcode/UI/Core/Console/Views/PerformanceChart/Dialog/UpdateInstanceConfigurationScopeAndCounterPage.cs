// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="IUpdateInstanceConfigurationScopeAndCounterPageControls.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//    [v-kantao] 1/16/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.PerformanceChart
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IUpdateInstanceConfigurationScopeAndCounterPageControls

    
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IUpdateInstanceConfigurationDialogControls, for UpdateInstanceConfigurationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///    [v-kantao] 1/16/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IUpdateInstanceConfigurationScopeAndCounterPageControls
    {
        /// <summary>
        /// Gets read-only property to access Button
        /// </summary>
        Button Button
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ClearButton
        /// </summary>
        Button ClearButton
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
        /// Gets read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        DataGrid AddDataGrid
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
    ///    [v-kantao] 1/16/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class UpdateInstanceConfigurationScopeAndCounterPage : Dialog, IUpdateInstanceConfigurationScopeAndCounterPageControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Button of type Button
        /// </summary>
        private Button cachedButton;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;
        
        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

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
        private DataGrid cachedAddDataGrid;
        
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the UpdateInstanceConfigurationDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of UpdateInstanceConfigurationDialog of type App
        /// </param>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public UpdateInstanceConfigurationScopeAndCounterPage(App app, int timeout, string dialogTitle) :
              base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
         
        #endregion

        #region IUpdateInstanceConfigurationScopePageControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IUpdateInstanceConfigurationScopeAndCounterPageControls Controls
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
        ///  Gets access to the Button control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationScopeAndCounterPageControls.Button
        {
            get
            {
                if ((this.cachedButton == null))
                {
                    this.cachedButton = new Button(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.Button);
                }
                
                return this.cachedButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ClearButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationScopeAndCounterPageControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.ClearButton);
                }
                
                return this.cachedClearButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationScopeAndCounterPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationScopeAndCounterPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationScopeAndCounterPageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationScopeAndCounterPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }

        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MultiPickerComponentAddButtonButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationScopeAndCounterPageControls.MultiPickerComponentAddButtonButton
        {
            get
            {
                if ((this.cachedMultiPickerComponentAddButtonButton == null))
                {
                    this.cachedMultiPickerComponentAddButtonButton = new Button(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.MultiPickerComponentAddButtonButton);
                }
                
                return this.cachedMultiPickerComponentAddButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MultiPickerComponentRemoveButtonButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationScopeAndCounterPageControls.MultiPickerComponentRemoveButtonButton
        {
            get
            {
                if ((this.cachedMultiPickerComponentRemoveButtonButton == null))
                {
                    this.cachedMultiPickerComponentRemoveButtonButton = new Button(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.MultiPickerComponentRemoveButtonButton);
                }
                
                return this.cachedMultiPickerComponentRemoveButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AddDataGrid control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IUpdateInstanceConfigurationScopeAndCounterPageControls.AddDataGrid
        {
            get
            {
                if ((this.cachedAddDataGrid == null))
                {
                    this.cachedAddDataGrid = new DataGrid(this, UpdateInstanceConfigurationScopeAndCounterPage.QueryIds.AddDataGrid);
                }
                
                return this.cachedAddDataGrid;
            }
        }
        
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis0
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis0()
        {
            this.Controls.Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
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
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
                
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MultiPickerComponentAddButton
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
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
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMultiPickerComponentRemoveButton()
        {
            this.Controls.MultiPickerComponentRemoveButtonButton.Click();
        }
        
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeOut, string DialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(new QID(";[UIA]Name = '" + DialogTitle + "' && Role = 'window'"), timeOut);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
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
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

             /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for IncrementButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncrementButton = ";[UIA]AutomationId=\'upButton\'";


            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DecrementButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDecrementButton = ";[UIA]AutomationId=\'downButton\'";
     
            
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceButton = ";[UIA]AutomationId=\'SinglePickerComponentLauncherButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ClearButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClearButton = ";[UIA]AutomationId=\'SinglePickerComponentClearButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PreviousButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePreviousButton = ";[UIA]AutomationId=\'WizardPreviousButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NextButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNextButton = ";[UIA]AutomationId=\'WizardNextButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FinishButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinishButton = ";[UIA]AutomationId=\'WizardCloseButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelButton = ";[UIA]AutomationId=\'WizardCancelButton\'";

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
            /// Contains resource string for AddDataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddDataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
            #endregion
            
            #region Properties


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the IncrementButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/28/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID IncrementButton
            {
                get
                {
                    return new QID(ResourceIncrementButton);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DecrementButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/28/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DecrementButton
            {
                get
                {
                    return new QID(ResourceDecrementButton);
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Button resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Button
            {
                get
                {
                    return new QID(ResourceButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ClearButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ClearButton
            {
                get
                {
                    return new QID(ResourceClearButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
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
            ///    [v-kantao] 1/16/2011 Created
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
            /// Gets access to the FinishButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID FinishButton
            {
                get
                {
                    return new QID(ResourceFinishButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CancelButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CancelButton
            {
                get
                {
                    return new QID(ResourceCancelButton);
                }
            }

                            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the MultiPickerComponentAddButtonButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
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
            ///    [v-kantao] 1/16/2011 Created
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
            /// Gets access to the AddDataGrid resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AddDataGrid
            {
                get
                {
                    return new QID(ResourceAddDataGrid);
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
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Update Configuration
            /// </summary>
            public const string DialogTitle = "Update Configuration";
            
            /// <summary>
            /// Resource string for ...
            /// </summary>
            public const string Ellipsis0 = "...";
            
            /// <summary>
            /// Resource string for Clear
            /// </summary>
            public const string Clear = "Clear";
            
            /// <summary>
            /// Resource string for < Previous
            /// </summary>
            public const string Previous = "< Previous";
            
            /// <summary>
            /// Resource string for Next >
            /// </summary>
            public const string Next = "Next >";
            
            /// <summary>
            /// Resource string for Finish
            /// </summary>
            public const string Finish = "Finish";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            public const string Cancel = "Cancel";
        }
        #endregion
    }
}
