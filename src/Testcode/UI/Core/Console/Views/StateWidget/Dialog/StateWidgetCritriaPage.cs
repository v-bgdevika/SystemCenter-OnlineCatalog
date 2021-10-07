// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="StateWidget.cs">
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
        
    #region Interface Definition - IStateWidgetControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IStateWidgetControls, for StateWidget.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-juli] 5/23/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IStateWidgetControls
    {
        /// <summary>
        /// Gets read-only property to access HealthStatesCheckBox
        /// </summary>
        CheckBox HealthStatesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HealthStatesListView
        /// </summary>
        ListView HealthStatesListView
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HealthyCheckBox
        /// </summary>
        CheckBox HealthyCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access WarningCheckBox
        /// </summary>
        CheckBox WarningCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CriticalCheckBox
        /// </summary>
        CheckBox CriticalCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NotMonitoredCheckBox
        /// </summary>
        CheckBox NotMonitoredCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DisplayOnlyObjectsInMaintenanceModeCheckBox
        /// </summary>
        CheckBox DisplayOnlyObjectsInMaintenanceModeCheckBox
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
        /// Gets read-only property to access OrientationPane
        /// </summary>
        ListView OrientationPane
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add app.window functionality description here.
    /// </summary>
    /// <history>
    ///   [v-juli] 5/23/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class StateWidgetCritriaPage : Dialog, IStateWidgetControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        
        #endregion
        
        #region Private Static Members

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        private static Window activeWindow;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to HealthStatesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedHealthStatesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to HealthStatesListView of type ListView
        /// </summary>
        private ListView cachedHealthStatesListView;
        
        /// <summary>
        /// Cache to hold a reference to HealthyCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedHealthyCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to WarningCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedWarningCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to CriticalCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedCriticalCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to NotMonitoredCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedNotMonitoredCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to DisplayOnlyObjectsInMaintenanceModeCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDisplayOnlyObjectsInMaintenanceModeCheckBox;
        
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
        /// Cache to hold a reference to OrientationPane of type ListView
        /// </summary>
        private ListView cachedOrientationPane;

        Dashboard.Wizard.StateWidget statewidget = new Dashboard.Wizard.StateWidget();
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the StateWidget class.
        /// </summary>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public StateWidgetCritriaPage(App app, int timeout, string DialogTitle) :
            base(app, Init(app, timeout, DialogTitle))
        {
           
        }
        #endregion        

        
        #region IStateWidget Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this app.window
        /// </summary>
        /// <value>An interface that groups all of the app.window's control properties together</value>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IStateWidgetControls Controls
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
        ///  Property to handle checkbox DisplayObjectsOnlyInTheSpecifiedHealthStates
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool DisplayObjectsOnlyInTheSpecifiedHealthStates
        {
            get
            {
                return this.Controls.HealthStatesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.HealthStatesCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Healthy
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Healthy
        {
            get
            {
                return this.Controls.HealthyCheckBox.Checked;
            }
            
            set
            {
                this.Controls.HealthyCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Warning
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Warning
        {
            get
            {
                return this.Controls.WarningCheckBox.Checked;
            }
            
            set
            {
                this.Controls.WarningCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Critical
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Critical
        {
            get
            {
                return this.Controls.CriticalCheckBox.Checked;
            }
            
            set
            {
                this.Controls.CriticalCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox NotMonitored
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool NotMonitored
        {
            get
            {
                return this.Controls.NotMonitoredCheckBox.Checked;
            }
            
            set
            {
                this.Controls.NotMonitoredCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox DisplayOnlyObjectsInMaintenanceMode
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool DisplayOnlyObjectsInMaintenanceMode
        {
            get
            {
                return this.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.Checked;
            }
            
            set
            {
                this.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HealthStatesCheckBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IStateWidgetControls.HealthStatesCheckBox
        {
            get
            {
                if ((this.cachedHealthStatesCheckBox == null))
                {
                    this.cachedHealthStatesCheckBox = new CheckBox(this, QueryIds.HealthStatesCheckBox);
                }
                
                return this.cachedHealthStatesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HealthStatesListView control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IStateWidgetControls.HealthStatesListView
        {
            get
            {
                if ((this.cachedHealthStatesListView == null))
                {
                    this.cachedHealthStatesListView = new ListView(this, QueryIds.HealthStatesListView);
                }
                
                return this.cachedHealthStatesListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HealthyCheckBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (HealthyCheckBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        CheckBox IStateWidgetControls.HealthyCheckBox
        {
            get
            {
                if ((this.cachedHealthyCheckBox == null))
                {
                    this.cachedHealthyCheckBox = new CheckBox(this, new QID(";[UIA]Name = '" + statewidget.healthyCheckbox + "' && Role = 'check box'"));
                }
                
                return this.cachedHealthyCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the WarningCheckBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (WarningCheckBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        CheckBox IStateWidgetControls.WarningCheckBox
        {
            get
            {
                if ((this.cachedWarningCheckBox == null))
                {                    
                    this.cachedWarningCheckBox = new CheckBox(this, new QID(";[UIA]Name = '" + statewidget.warningCheckbox + "' && Role = 'check box'"));
                }
                
                return this.cachedWarningCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CriticalCheckBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (CriticalCheckBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        CheckBox IStateWidgetControls.CriticalCheckBox
        {
            get
            {
                if ((this.cachedCriticalCheckBox == null))
                {
                    this.cachedCriticalCheckBox = new CheckBox(this, new QID(";[UIA]Name = '" + statewidget.criticalCheckbox + "' && Role = 'check box'"));
                }
                
                return this.cachedCriticalCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NotMonitoredCheckBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (NotMonitoredCheckBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        CheckBox IStateWidgetControls.NotMonitoredCheckBox
        {
            get
            {                
                if ((this.cachedNotMonitoredCheckBox == null))
                {
                    this.cachedNotMonitoredCheckBox = new CheckBox(this, new QID(";[UIA]Name = '" + statewidget.notMonitoredCheckbox + "' && Role = 'check box'"));
                }
                
                return this.cachedNotMonitoredCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DisplayOnlyObjectsInMaintenanceModeCheckBox control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (checkBox) is used multiple times in this app.window.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        CheckBox IStateWidgetControls.DisplayOnlyObjectsInMaintenanceModeCheckBox
        {
            get
            {              
                if ((this.cachedDisplayOnlyObjectsInMaintenanceModeCheckBox == null))
                {
                    this.cachedDisplayOnlyObjectsInMaintenanceModeCheckBox = new CheckBox(this, new QID(";[UIA]Name = '" + statewidget.displayOnlyMaintnanceModeLeble + "' && Role = 'check box'"));
                }

                return this.cachedDisplayOnlyObjectsInMaintenanceModeCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, QueryIds.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IStateWidgetControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, QueryIds.FinishButton);
                }
                
                return this.cachedFinishButton;
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
        Button IStateWidgetControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OrientationPane control
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IStateWidgetControls.OrientationPane
        {
            get
            {
                if ((this.cachedOrientationPane == null))
                {
                    this.cachedOrientationPane = new ListView(this, QueryIds.OrientationPane);
                }
                
                return this.cachedOrientationPane;
            }
        }
        #endregion       
        
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DisplayObjectsOnlyInTheSpecifiedHealthStates
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDisplayObjectsOnlyInTheSpecifiedHealthStates()
        {
            this.Controls.HealthStatesCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Healthy
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHealthy()
        {
            this.Controls.HealthyCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Warning
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickWarning()
        {
            this.Controls.WarningCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Critical
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCritical()
        {
            this.Controls.CriticalCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button NotMonitored
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNotMonitored()
        {
            this.Controls.NotMonitoredCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DisplayOnlyObjectsInMaintenanceMode
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDisplayOnlyObjectsInMaintenanceMode()
        {
            this.Controls.DisplayOnlyObjectsInMaintenanceModeCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-juli] 5/23/2011 Created
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
        ///   [v-juli] 5/23/2011 Created
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
        ///   [v-juli] 5/23/2011 Created
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
        /// <param name="app">App owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
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
                tempWindow = new Window(new QID(";[VisibleOnly]Name = '" + DialogTitle + "' && Role = 'window'"), timeout);                
                
            }
            catch (Maui.Core.Dialog.Exceptions.WindowNotFoundException)
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
                    catch (Exceptions.WindowNotFoundException)
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
            /// Contains resource string for HealthStatesCheckBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDisplayObjectsOnlyInTheSpecifiedHealthStatesCheckBox = ";[UIA]AutomationId=\'checkBox\' && Instance = 1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for HealthStatesListView query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDisplayObjectsOnlyInTheSpecified_healthStatesListView = ";[UIA]AutomationId=\'ListBox\'";
                              
           
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
            /// Contains resource string for OrientationPane query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOrientationPane = ";[UIA]AutomationId=\'OrientationListBox\'";
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the HealthStatesCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID HealthStatesCheckBox
            {
                get
                {
                    return new QID(ResourceDisplayObjectsOnlyInTheSpecifiedHealthStatesCheckBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the HealthStatesListView resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID HealthStatesListView
            {
                get
                {
                    return new QID(ResourceDisplayObjectsOnlyInTheSpecified_healthStatesListView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
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
            ///   [v-juli] 5/23/2011 Created
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
            ///   [v-juli] 5/23/2011 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the OrientationPane resource qid string
            /// </summary>
            /// <history>
            ///   [v-juli] 5/23/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID OrientationPane
            {
                get
                {
                    return new QID(ResourceOrientationPane);
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
        ///   [v-juli] 5/23/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        //public class Strings
        //{           
        //    /// <summary>
        //    /// Resource string for Healthy
        //    /// </summary>
        //    public const string Healthy = ";Healthy;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;StateGreen";
            
        //    /// <summary>
        //    /// Resource string for Warning
        //    /// </summary>
        //    public const string Warning = ";Warning;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Warning";
            
        //    /// <summary>
        //    /// Resource string for Critical
        //    /// </summary>
        //    public const string Critical = ";Critical;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;SeverityError";
            
        //    /// <summary>
        //    /// Resource string for Not Monitored
        //    /// </summary>
        //    public const string NotMonitored = ";Not Monitored;ManagedString;Microsoft.EnterpriseManagement.Presentation.Controls.resources.dll;Microsoft.EnterpriseManagement.Presentation.Controls.Resources.ControlsResources.en;HealthStateUnknown";
                        
        //}
        #endregion
    }
}
