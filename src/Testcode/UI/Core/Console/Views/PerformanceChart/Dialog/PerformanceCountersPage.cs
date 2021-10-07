// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Performancecounterspage.cs">
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
    
    #region Interface Definition - IPerformancecounterspageControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformancecounterspageControls, for Performancecounterspage.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///    [v-kantao] 1/16/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceCountersPageControls
    {
        /// <summary>
        /// Gets read-only property to access ObjectComboBox
        /// </summary>
        ComboBox ObjectComboBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CounterComboBox
        /// </summary>
        ComboBox CounterComboBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access InstanceComboBox
        /// </summary>
        ComboBox InstanceComboBox
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
        /// Gets read-only property to access AvailableItems0DataGrid
        /// </summary>
        DataGrid AvailableItems0DataGrid
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
        /// Gets read-only property to access SelectedItems0DataGrid
        /// </summary>
        DataGrid SelectedItems0DataGrid
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access _OkButton
        /// </summary>
        Button _OkButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access _CancelButton
        /// </summary>
        Button _CancelButton
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
    public partial class PerformanceCountersPage : Dialog, IPerformanceCountersPageControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ObjectComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedObjectComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CounterComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedCounterComboBox;
        
        /// <summary>
        /// Cache to hold a reference to InstanceComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedInstanceComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ErrorButtonButton of type Button
        /// </summary>
        private Button cachedErrorButtonButton;
        
        /// <summary>
        /// Cache to hold a reference to ProgressBar1 of type ProgressBar
        /// </summary>
        private ProgressBar cachedProgressBar1;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItems0DataGrid of type DataGrid
        /// </summary>
        private DataGrid cachedAvailableItems0DataGrid;
        
        /// <summary>
        /// Cache to hold a reference to A_ddButton of type Button
        /// </summary>
        private Button cachedA_ddButton;
        
        /// <summary>
        /// Cache to hold a reference to _RemoveButton of type Button
        /// </summary>
        private Button cached_RemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectedItems0DataGrid of type DataGrid
        /// </summary>
        private DataGrid cachedSelectedItems0DataGrid;
        
        /// <summary>
        /// Cache to hold a reference to _OkButton of type Button
        /// </summary>
        private Button cached_OkButton;
        
        /// <summary>
        /// Cache to hold a reference to _CancelButton of type Button
        /// </summary>
        private Button cached_CancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the Performancecounterspage class.
        /// </summary>
        /// <param name='app'>
        /// Owner of Performancecounterspage of type App
        /// </param>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceCountersPage(App app, int timeout, string dialogTitle) :
            base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IPerformancecounterspage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceCountersPageControls Controls
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
        ///  Gets or sets the text in control SearchForThePerformanceCountersThatYouWantToShow
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchForThePerformanceCountersThatYouWantToShowText
        {
            get
            {
                return this.Controls.ObjectComboBox.Text;
            }
            
            set
            {
                this.Controls.ObjectComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control Counter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CounterText
        {
            get
            {
                return this.Controls.CounterComboBox.Text;
            }
            
            set
            {
                this.Controls.CounterComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control Instance
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string InstanceText
        {
            get
            {
                return this.Controls.InstanceComboBox.Text;
            }
            
            set
            {
                this.Controls.InstanceComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ObjectComboBox control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceCountersPageControls.ObjectComboBox
        {
            get
            {
                if ((this.cachedObjectComboBox == null))
                {
                    this.cachedObjectComboBox = new ComboBox(this, PerformanceCountersPage.QueryIds.ObjectComboBox);
                }
                
                return this.cachedObjectComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CounterComboBox control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceCountersPageControls.CounterComboBox
        {
            get
            {
                if ((this.cachedCounterComboBox == null))
                {
                    this.cachedCounterComboBox = new ComboBox(this, PerformanceCountersPage.QueryIds.CounterComboBox);
                }
                
                return this.cachedCounterComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the InstanceComboBox control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceCountersPageControls.InstanceComboBox
        {
            get
            {
                if ((this.cachedInstanceComboBox == null))
                {
                    this.cachedInstanceComboBox = new ComboBox(this, PerformanceCountersPage.QueryIds.InstanceComboBox);
                }
                
                return this.cachedInstanceComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ErrorButtonButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCountersPageControls.ErrorButtonButton
        {
            get
            {
                if ((this.cachedErrorButtonButton == null))
                {
                    this.cachedErrorButtonButton = new Button(this, PerformanceCountersPage.QueryIds.ErrorButtonButton);
                }
                
                return this.cachedErrorButtonButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ProgressBar1 control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ProgressBar IPerformanceCountersPageControls.ProgressBar1
        {
            get
            {
                if ((this.cachedProgressBar1 == null))
                {
                    this.cachedProgressBar1 = new ProgressBar(this, PerformanceCountersPage.QueryIds.ProgressBar1);
                }
                
                return this.cachedProgressBar1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AvailableItems0DataGrid control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGrid IPerformanceCountersPageControls.AvailableItems0DataGrid
        {
            get
            {
                if ((this.cachedAvailableItems0DataGrid == null))
                {
                    this.cachedAvailableItems0DataGrid = new DataGrid(this, PerformanceCountersPage.QueryIds.AvailableItems0DataGrid);
                }
                
                return this.cachedAvailableItems0DataGrid;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the A_ddButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCountersPageControls.A_ddButton
        {
            get
            {
                if ((this.cachedA_ddButton == null))
                {
                    this.cachedA_ddButton = new Button(this, PerformanceCountersPage.QueryIds.A_ddButton);
                }
                
                return this.cachedA_ddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the _RemoveButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCountersPageControls._RemoveButton
        {
            get
            {
                if ((this.cached_RemoveButton == null))
                {
                    this.cached_RemoveButton = new Button(this, PerformanceCountersPage.QueryIds._RemoveButton);
                }
                
                return this.cached_RemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SelectedItems0DataGrid control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (InnerDataGrid) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        DataGrid IPerformanceCountersPageControls.SelectedItems0DataGrid
        {
            get
            {
                // TODO: The ID for this control (InnerDataGrid) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedSelectedItems0DataGrid == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 9); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSelectedItems0DataGrid = new DataGrid(wndTemp);
                }
                
                return this.cachedSelectedItems0DataGrid;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the _OkButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCountersPageControls._OkButton
        {
            get
            {
                if ((this.cached_OkButton == null))
                {
                    this.cached_OkButton = new Button(this, PerformanceCountersPage.QueryIds._OkButton);
                }
                
                return this.cached_OkButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the _CancelButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCountersPageControls._CancelButton
        {
            get
            {
                if ((this.cached_CancelButton == null))
                {
                    this.cached_CancelButton = new Button(this, PerformanceCountersPage.QueryIds._CancelButton);
                }
                
                return this.cached_CancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ErrorButton
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
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
        ///    [v-kantao] 1/16/2011 Created
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
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void Click_Remove()
        {
            this.Controls._RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button _Ok
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void Click_Ok()
        {
            this.Controls._OkButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button _Cancel
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void Click_Cancel()
        {
            this.Controls._CancelButton.Click();
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
            /// Contains resource string for ObjectComboBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectComboBox = ";[UIA]AutomationId=\'ObjectSelector\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CounterComboBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCounterComboBox = ";[UIA]AutomationId=\'CounterSelector\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for InstanceComboBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInstanceComboBox = ";[UIA]AutomationId=\'InstanceSelector\'";
            
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
            /// Contains resource string for AvailableItems0DataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems0DataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
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
            /// Contains resource string for SelectedItems0DataGrid query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedItems0DataGrid = ";[UIA]AutomationId=\'InnerDataGrid\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for _OkButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_OkButton = ";[UIA]AutomationId=\'OkButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for _CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_CancelButton = ";[UIA]AutomationId=\'CancelButton\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ObjectComboBox resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ObjectComboBox
            {
                get
                {
                    return new QID(ResourceObjectComboBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the CounterComboBox resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID CounterComboBox
            {
                get
                {
                    return new QID(ResourceCounterComboBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the InstanceComboBox resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID InstanceComboBox
            {
                get
                {
                    return new QID(ResourceInstanceComboBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ErrorButtonButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
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
            ///    [v-kantao] 1/16/2011 Created
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
            /// Gets access to the AvailableItems0DataGrid resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AvailableItems0DataGrid
            {
                get
                {
                    return new QID(ResourceAvailableItems0DataGrid);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the A_ddButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
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
            ///    [v-kantao] 1/16/2011 Created
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
            /// Gets access to the SelectedItems0DataGrid resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectedItems0DataGrid
            {
                get
                {
                    return new QID(ResourceSelectedItems0DataGrid);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the _OkButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID _OkButton
            {
                get
                {
                    return new QID(Resource_OkButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the _CancelButton resource qid string
            /// </summary>
            /// <history>
            ///    [v-kantao] 1/16/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID _CancelButton
            {
                get
                {
                    return new QID(Resource_CancelButton);
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
            /// Resource string for Add the performance counters that you want to show in the chart.
            /// </summary>
            public const string DialogTitle = "Add the performance counters that you want to show in the chart.";
            
            /// <summary>
            /// Resource string for A_dd
            /// </summary>
            public const string A_dd = "A_dd";
            
            /// <summary>
            /// Resource string for _Remove
            /// </summary>
            public const string _Remove = "_Remove";
            
            /// <summary>
            /// Resource string for _Ok
            /// </summary>
            public const string _Ok = "_Ok";
            
            /// <summary>
            /// Resource string for _Cancel
            /// </summary>
            public const string _Cancel = "_Cancel";
        }
        #endregion
    }
}
