// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CriteriaPage.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-lileo] 1/6/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent.Configuration
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IUpdateInstanceConfigurationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IUpdateInstanceConfigurationDialogControls, for UpdateInstanceConfigurationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-lileo] 1/6/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertCriteriaPageControls
    {
        /// <summary>
        /// Gets read-only property to access SeverityCheckBox
        /// </summary>
        CheckBox SeverityCheckBox
        {
            get;
        }


        /// <summary>
        /// Gets read-only property to access SeverityListView
        /// </summary>
        ListView SeverityListView
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PriorityCheckBox
        /// </summary>
        CheckBox PriorityCheckBox
        {
            get;
        }
        /// <summary>
        /// Gets read-only property to access PriorityListView
        /// </summary>
        ListView PriorityListView
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ResolutionStateCheckBox
        /// </summary>
        CheckBox ResolutionStateCheckBox
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access ResolutionStateListView
        /// </summary>
        ListView ResolutionStateListView
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    ///   [v-lileo] 1/6/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class AlertCriteriaPage : Dialog, IAlertCriteriaPageControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SeverityCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedSeverityCheckBox;

        /// <summary>
        /// Cache to hold a reference to ListView0 of type ListView
        /// </summary>
        private ListView cachedSeverityListView;
        
        /// <summary>
        /// Cache to hold a reference to PriorityCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedPriorityCheckBox;

        /// <summary>
        /// Cache to hold a reference to ListView0 of type ListView
        /// </summary>
        private ListView cachedPriorityListView;

        /// <summary>
        /// Cache to hold a reference to ResolutionStateCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedResolutionStateCheckBox;

        /// <summary>
        /// Cache to hold a reference to ListView0 of type ListView
        /// </summary>
        private ListView cachedResolutionStateListView;

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
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertCriteriaPage(App app, int timeout,string DialogTitle) : 
                base(app, Init(app, timeout,DialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region ICriteriaPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertCriteriaPageControls Controls
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
        ///  Property to handle checkbox Severity
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Severity
        {
            get
            {
                return this.Controls.SeverityCheckBox.Checked;
            }
            
            set
            {
                this.Controls.SeverityCheckBox.Checked = value;
            }
        }
                
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Priority
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Priority
        {
            get
            {
                return this.Controls.PriorityCheckBox.Checked;
            }
            
            set
            {
                this.Controls.PriorityCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ResolutionState
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ResolutionState
        {
            get
            {
                return this.Controls.ResolutionStateCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ResolutionStateCheckBox.Checked = value;
            }
        }
        
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SeverityCheckBox control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAlertCriteriaPageControls.SeverityCheckBox
        {
            get
            {
                if ((this.cachedSeverityCheckBox == null))
                {
                    this.cachedSeverityCheckBox = new CheckBox(this, AlertCriteriaPage.QueryIds.SeverityCheckBox);
                }
                
                return this.cachedSeverityCheckBox;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CriticalCheckBox control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAlertCriteriaPageControls.SeverityListView
        {
            get
            {
                if ((this.cachedSeverityListView == null))
                {
                    this.cachedSeverityListView = new ListView(this, AlertCriteriaPage.QueryIds.SeverityListView);
                }

                return this.cachedSeverityListView;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PriorityCheckBox control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAlertCriteriaPageControls.PriorityCheckBox
        {
            get
            {
                if ((this.cachedPriorityCheckBox == null))
                {
                    this.cachedPriorityCheckBox = new CheckBox(this, AlertCriteriaPage.QueryIds.PriorityCheckBox);
                }
                
                return this.cachedPriorityCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HighCheckBox control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAlertCriteriaPageControls.PriorityListView
        {
            get
            {
                if ((this.cachedPriorityListView == null))
                {
                    this.cachedPriorityListView = new ListView(this,AlertCriteriaPage.QueryIds.PriorityListView);
                }
                
                return this.cachedPriorityListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ResolutionStateCheckBox control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAlertCriteriaPageControls.ResolutionStateCheckBox
        {
            get
            {
                if ((this.cachedResolutionStateCheckBox == null))
                {
                    this.cachedResolutionStateCheckBox = new CheckBox(this, AlertCriteriaPage.QueryIds.ResolutionStateCheckBox);
                }
                
                return this.cachedResolutionStateCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the New0CheckBox control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAlertCriteriaPageControls.ResolutionStateListView
        {
            get
            {
                if ((this.cachedResolutionStateListView == null))
                {
                    this.cachedResolutionStateListView = new ListView(this,AlertCriteriaPage.QueryIds.ResolutionStateListView);
                }
                
                return this.cachedResolutionStateListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertCriteriaPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AlertCriteriaPage.QueryIds.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertCriteriaPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AlertCriteriaPage.QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertCriteriaPageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, AlertCriteriaPage.QueryIds.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertCriteriaPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertCriteriaPage.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Severity
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSeverity()
        {
            this.Controls.SeverityCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Priority
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPriority()
        {
            this.Controls.PriorityCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ResolutionState
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickResolutionState()
        {
            this.Controls.ResolutionStateCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
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
        ///   [v-lileo] 1/6/2011 Created
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
        ///   [v-lileo] 1/6/2011 Created
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
        ///   [v-lileo] 1/6/2011 Created
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
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout,string DialogTitle)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
		switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + DialogTitle + "' && Role = 'window'"), timeout);
                        break;
                    case ProductSkuLevel.Web:
                        tempWindow = new Window(new QID(string.Format(ConsoleApp.Strings.WebConsoleDialogTitle, DialogTitle)), timeout);
                        break;
                }
            }
            catch (Exceptions.WindowNotFoundException )
            {
                // TODO:  Add any specific logic here to handle the case when the
                // dialog is not found in the specified timeout.
                // otherwise rethrow the exception.
                throw;
            }
            
            return tempWindow;
        }
        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SeverityCheckBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeverityCheckBox = ";[UIA]AutomationId=\'SeverityCheckBox\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ListView0 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeverityListView = ";[UIA]AutomationId=\'SeverityList\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PriorityCheckBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePriorityCheckBox = ";[UIA]AutomationId=\'PriorityCheckBox\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ListView0 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePriorityListView = ";[UIA]AutomationId=\'PriorityList\'";            
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ResolutionStateCheckBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResolutionStateCheckBox = ";[UIA]AutomationId=\'ResolutionStateCheckBox\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ListView3 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResolutionStateListView = ";[UIA]AutomationId=\'ResolutionStateList\'";
            
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

            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the SeverityCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SeverityCheckBox
            {
                get
                {
                    return new QID(ResourceSeverityCheckBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ListView0 resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SeverityListView
            {
                get
                {
                    return new QID(ResourceSeverityListView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PriorityCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PriorityCheckBox
            {
                get
                {
                    return new QID(ResourcePriorityCheckBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ListView1 resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PriorityListView
            {
                get
                {
                    return new QID(ResourcePriorityListView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ResolutionStateCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ResolutionStateCheckBox
            {
                get
                {
                    return new QID(ResourceResolutionStateCheckBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ListView3 resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 1/6/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ResolutionStateListView
            {
                get
                {
                    return new QID(ResourceResolutionStateListView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-lileo] 1/6/2011 Created
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
            ///   [v-lileo] 1/6/2011 Created
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
            ///   [v-lileo] 1/6/2011 Created
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
            ///   [v-lileo] 1/6/2011 Created
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
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-lileo] 1/6/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Update Configuration
            /// </summary>
            public const string DialogTitle = "Update Configuration";
            
            /// <summary>
            /// Resource string for Severity
            /// </summary>
            public const string Severity = "Severity";
            
            /// <summary>
            /// Resource string for Critical
            /// </summary>
            public const string Critical = "Critical";
            
            /// <summary>
            /// Resource string for Warning
            /// </summary>
            public const string Warning = "Warning";
            
            /// <summary>
            /// Resource string for Information
            /// </summary>
            public const string Information = "Information";
            
            /// <summary>
            /// Resource string for Priority
            /// </summary>
            public const string Priority = "Priority";
            
            /// <summary>
            /// Resource string for High
            /// </summary>
            public const string High = "High";
            
            /// <summary>
            /// Resource string for Medium
            /// </summary>
            public const string Medium = "Medium";
            
            /// <summary>
            /// Resource string for Low
            /// </summary>
            public const string Low = "Low";
            
            /// <summary>
            /// Resource string for Resolution State
            /// </summary>
            public const string ResolutionState = "Resolution State";
            
            /// <summary>
            /// Resource string for New (0)
            /// </summary>
            public const string New0 = "New (0)";
            
            /// <summary>
            /// Resource string for Closed (255)
            /// </summary>
            public const string Closed255 = "Closed (255)";
            
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
