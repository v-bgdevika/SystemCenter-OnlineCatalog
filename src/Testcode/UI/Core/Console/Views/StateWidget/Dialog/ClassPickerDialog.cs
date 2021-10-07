// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ClassPickerDialog.cs">
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
    using Mom.Test.UI.Core.Console.MomControls;
    
    #region Interface Definition - IClassPickerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IClassPickerDialogControls, for ClassPickerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-juli] 5/23/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IClassPickerDialogControls
    {
        /// <summary>
        /// Gets read-only property to access LookForTextBox
        /// </summary>
        TextBox LookForTextBox
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
        /// Gets read-only property to access ErrorButtonButton
        /// </summary>
        Button ErrorButtonButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ProgressBar0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ProgressBar ProgressBar0
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
    public partial class ClassPickerDialog : Dialog, IClassPickerDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to LookForTextBox of type TextBox
        /// </summary>
        private TextBox cachedLookForTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SCOMFilterControlSearchButtonButton of type Button
        /// </summary>
        private Button cachedSCOMFilterControlSearchButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to SCOMFilterControlCloseButtonButton of type Button
        /// </summary>
        private Button cachedSCOMFilterControlCloseButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to ErrorButtonButton of type Button
        /// </summary>
        private Button cachedErrorButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to ProgressBar0 of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressBar0;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsDataGrid of type DataGrid
        /// </summary>
        private DataGridControl cachedAvailableItemsDataGrid;
        
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
        /// Initializes a new instance of the ClassPickerDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of ClassPickerDialog of type StateWidget
        /// </param>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ClassPickerDialog(App app, int timeout, string DialogTitle) :
            base(app, Init(app, timeout, DialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IClassPickerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IClassPickerDialogControls Controls
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
        ///  Gets or sets the text in control LookFor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LookForText
        {
            get
            {
                return this.Controls.LookForTextBox.Text;
            }
            
            set
            {
                this.Controls.LookForTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the LookForTextBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IClassPickerDialogControls.LookForTextBox
        {
            get
            {
                if ((this.cachedLookForTextBox == null))
                {
                    this.cachedLookForTextBox = new TextBox(this, ClassPickerDialog.QueryIds.LookForTextBox);
                }
                
                return this.cachedLookForTextBox;
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
        Button IClassPickerDialogControls.SCOMFilterControlSearchButtonButton
        {
            get
            {
                if ((this.cachedSCOMFilterControlSearchButtonButton == null))
                {
                    this.cachedSCOMFilterControlSearchButtonButton = new Button(this, ClassPickerDialog.QueryIds.SCOMFilterControlSearchButtonButton);
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
        Button IClassPickerDialogControls.SCOMFilterControlCloseButtonButton
        {
            get
            {
                if ((this.cachedSCOMFilterControlCloseButtonButton == null))
                {
                    this.cachedSCOMFilterControlCloseButtonButton = new Button(this, ClassPickerDialog.QueryIds.SCOMFilterControlCloseButtonButton);
                }
                
                return this.cachedSCOMFilterControlCloseButtonButton;
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
        Button IClassPickerDialogControls.ErrorButtonButton
        {
            get
            {
                if ((this.cachedErrorButtonButton == null))
                {
                    this.cachedErrorButtonButton = new Button(this, ClassPickerDialog.QueryIds.ErrorButtonButton);
                }
                
                return this.cachedErrorButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressBar0 control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ProgressBar IClassPickerDialogControls.ProgressBar0
        {
            get
            {
                if ((this.cachedProgressBar0 == null))
                {
                    this.cachedProgressBar0 = new ProgressBar(this, ClassPickerDialog.QueryIds.ProgressBar0);
                }
                
                return this.cachedProgressBar0;
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
        DataGridControl IClassPickerDialogControls.AvailableItemsDataGrid
        {
            get
            {
                if ((this.cachedAvailableItemsDataGrid == null))
                {
                    this.cachedAvailableItemsDataGrid = new DataGridControl(this, ClassPickerDialog.QueryIds.AvailableItemsDataGrid);
                }
                
                return this.cachedAvailableItemsDataGrid;
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
        Button IClassPickerDialogControls.OkButton
        {
            get
            {
                if ((this.cachedOkButton == null))
                {
                    this.cachedOkButton = new Button(this, ClassPickerDialog.QueryIds.OkButton);
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
        Button IClassPickerDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ClassPickerDialog.QueryIds.CancelButton);
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
        private static Window Init(App app, int timeout, string DialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.MainWindow, new QID(";[UIA, VisibleOnly]Name = '" + DialogTitle + "' && Role = 'window'"), Timeout);
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
                        tempWindow = new Window(DialogTitle, StringMatchSyntax.WildCard);
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
            /// Contains resource string for LookForTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookForTextBox = ";[UIA]AutomationId=\'SCOMWatermarkTextBox\'";
            
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
            /// Contains resource string for ErrorButtonButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorButtonButton = ";[UIA]AutomationId=\'errorButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ProgressBar0 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProgressBar0 = ";[UIA]AutomationId=\'progressBar\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AvailableItemsDataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItemsDataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
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
            /// Gets access to the LookForTextBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID LookForTextBox
            {
                get
                {
                    return new QID(ResourceLookForTextBox);
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
            /// Gets access to the ProgressBar0 resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ProgressBar0
            {
                get
                {
                    return new QID(ResourceProgressBar0);
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
