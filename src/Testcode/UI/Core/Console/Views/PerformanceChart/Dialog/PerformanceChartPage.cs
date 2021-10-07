// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceChartPage.cs">
//   Copyright (c) Microsoft Corporation 2011
// </copyright>
// <project>
//   Performance widget
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-kantao] 1/12/2011 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.PerformanceChart
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IPersonalizeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceChartPageControls, for PersonalizeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-kantao] 1/13/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceChartPageControls
    {
        /// <summary>
        /// Gets read-only property to access ShowTheLegendCheckBox
        /// </summary>
        CheckBox ShowTheLegendCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ShowThe_legendListView
        /// </summary>
        ListView ShowThe_legendListView
        {
            get;
        }
                
        /// <summary>
        /// Gets read-only property to access UpButton
        /// </summary>
        Button UpButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DownButton
        /// </summary>
        Button DownButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AutomaticCheckBox
        /// </summary>
        CheckBox AutomaticCheckBox
        {
            get;
        }
        
       
        
        /// <summary>
        /// Gets read-only property to access IncrementButton
        /// </summary>
        Button IncrementButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DecrementButton
        /// </summary>
        Button DecrementButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access IncrementButtonInMin
        /// </summary>
        Button IncrementButtonInMin
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
        /// Gets read-only property to access MaxTextBox
        /// </summary>
        TextBox MaxTextBox
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access MinTextBox
        /// </summary>
        TextBox MinTextBox
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
    ///    [v-kantao] 1/13/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class PerformanceChartPage : Dialog, IPerformanceChartPageControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ShowTheLegendCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedShowTheLegendCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ShowThe_legendListView of type ListView
        /// </summary>
        private ListView cachedShowThe_legendListView;
        
        
        /// <summary>
        /// Cache to hold a reference to UpButton of type Button
        /// </summary>
        private Button cachedUpButton;
        
        /// <summary>
        /// Cache to hold a reference to DownButton of type Button
        /// </summary>
        private Button cachedDownButton;
        
        /// <summary>
        /// Cache to hold a reference to AutomaticCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAutomaticCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MaximumStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMaximumStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IncrementButton of type Button
        /// </summary>
        private Button cachedIncrementButton;

        /// <summary>
        /// Cache to hold a reference to IncrementButtonInMi of type Button
        /// </summary>
        private Button cachedIncrementButtonInMin;

        /// <summary>
        /// Cache to hold a reference to DecrementButton of type Button
        /// </summary>
        private Button cachedDecrementButton;
        
        /// <summary>
        /// Cache to hold a reference to MinimumStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMinimumStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IncrementButton2 of type Button
        /// </summary>
        private Button cachedIncrementButton2;
        
        /// <summary>
        /// Cache to hold a reference to DecrementButton2 of type Button
        /// </summary>
        private Button cachedDecrementButton2;
        
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
        /// Initializes a new instance of the PersonalizeDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of PersonalizeDialog of type App
        /// </param>
        /// <history>
        ///   [asttest] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceChartPage(App app, int timeout, string dialogTitle) :
            base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IPersonalizeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [asttest] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceChartPageControls Controls
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
        ///  Property to handle checkbox ShowTheLegend
        /// </summary>
        /// <history>
        ///   [asttest] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ShowTheLegend
        {
            get
            {
                return this.Controls.ShowTheLegendCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ShowTheLegendCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Automatic
        /// </summary>
        /// <history>
        ///   [asttest] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Automatic
        {
            get
            {
                return this.Controls.AutomaticCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AutomaticCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ShowTheLegendCheckBox control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceChartPageControls.ShowTheLegendCheckBox
        {
            get
            {
                if ((this.cachedShowTheLegendCheckBox == null))
                {
                    this.cachedShowTheLegendCheckBox = new CheckBox(this, PerformanceChartPage.QueryIds.ShowTheLegendCheckBox);
                }
                
                return this.cachedShowTheLegendCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ShowThe_legendListView control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IPerformanceChartPageControls.ShowThe_legendListView
        {
            get
            {
                if ((this.cachedShowThe_legendListView == null))
                {
                    this.cachedShowThe_legendListView = new ListView(this, PerformanceChartPage.QueryIds.ShowThe_legendListView);
                }
                
                return this.cachedShowThe_legendListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the UpButton control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.UpButton
        {
            get
            {
                if ((this.cachedUpButton == null))
                {
                    this.cachedUpButton = new Button(this, PerformanceChartPage.QueryIds.UpButton);
                }
                
                return this.cachedUpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DownButton control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.DownButton
        {
            get
            {
                if ((this.cachedDownButton == null))
                {
                    this.cachedDownButton = new Button(this, PerformanceChartPage.QueryIds.DownButton);
                }
                
                return this.cachedDownButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AutomaticCheckBox control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceChartPageControls.AutomaticCheckBox
        {
            get
            {
                if ((this.cachedAutomaticCheckBox == null))
                {
                    
                    this.cachedAutomaticCheckBox = new CheckBox(this, PerformanceChartPage.QueryIds.AutomaticCheckBox);
                }
                
                return this.cachedAutomaticCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the IncrementButtonInMin control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.IncrementButtonInMin
        {
            get
            {
                if ((this.cachedIncrementButtonInMin == null))
                {
                    Window min = new Window(this, PerformanceChartPage.QueryIds.min, 5000);

                    this.cachedIncrementButtonInMin = new Button(min, PerformanceChartPage.QueryIds.IncrementButton);
                }

                return this.cachedIncrementButtonInMin;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the IncrementButton control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.IncrementButton
        {
            get
            {
                if ((this.cachedIncrementButton == null))
                {
                    Window max = new Window(this, PerformanceChartPage.QueryIds.max, 5000);
         
                    this.cachedIncrementButton = new Button(max, PerformanceChartPage.QueryIds.IncrementButton);
                }
                
                return this.cachedIncrementButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DecrementButton control
        /// </summary>
        /// <history>
        ///   [asttest] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.DecrementButton
        {
            get
            {
                if ((this.cachedDecrementButton == null))
                {
                    Window max = new Window(this, PerformanceChartPage.QueryIds.max, 5000);
                    this.cachedDecrementButton = new Button(this, PerformanceChartPage.QueryIds.DecrementButton);
                }
                
                return this.cachedDecrementButton;
            }
        }
        
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, PerformanceChartPage.QueryIds.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, PerformanceChartPage.QueryIds.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the FinishButton control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, PerformanceChartPage.QueryIds.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceChartPageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerformanceChartPage.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MaxTextBox control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceChartPageControls.MaxTextBox
        {
            get
            {
                //Get parent first
                StaticControl maximumAxisLimit = new StaticControl(this, PerformanceChartPage.QueryIds.max);

                return new TextBox(maximumAxisLimit, PerformanceChartPage.QueryIds.MaximumTextBox);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MinTextBox control
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPerformanceChartPageControls.MinTextBox
        {
            get
            {
                //Get parent first
                StaticControl minimumAxisLimit = new StaticControl(this, PerformanceChartPage.QueryIds.min);

                return new TextBox(minimumAxisLimit, PerformanceChartPage.QueryIds.MinimumTextBox);
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ShowTheLegend
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickShowTheLegend()
        {
            this.Controls.ShowTheLegendCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Up
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUp()
        {
            this.Controls.UpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Down
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDown()
        {
            this.Controls.DownButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Automatic
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAutomatic()
        {
            this.Controls.AutomaticCheckBox.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Increment
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickIncrementInMin()
        {
            this.Controls.IncrementButtonInMin.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Increment
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickIncrement()
        {
            this.Controls.IncrementButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Decrement
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDecrement()
        {
            this.Controls.DecrementButton.Click();
        }
      
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
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
        ///   [v-kantao] 1/13/2011 Created
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
        ///   [v-kantao] 1/13/2011 Created
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
        ///   [v-kantao] 1/13/2011 Created
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
        /// <history>
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app,int timeOut,string DialogTitle)
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
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ShowTheLegendCheckBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowTheLegendCheckBox = ";[UIA]AutomationId=\'HostedCheckBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ShowThe_legendListView query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowThe_legendListView = ";[UIA]AutomationId=\'AllColumns\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for UpButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUpButton = ";[UIA]AutomationId=\'MoveUp\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DownButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDownButton = ";[UIA]AutomationId=\'MoveDown\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AutomaticCheckBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomaticCheckBox = ";[UIA]AutomationId=\'AutomaticAxisLimits\'";


            private const string ResourceMax = ";[UIA]AutomationId=\'MaximumAxisLimit\'";


            private const string ResourceMin = ";[UIA]AutomationId=\'MinimumAxisLimit\'";

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
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinimumTextBox = ";[UIA]AutomationId='valueText'";


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for CancelButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMaximumTextBox = ";[UIA]AutomationId='valueText'";

            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowTheLegendCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowTheLegendCheckBox
            {
                get
                {
                    return new QID(ResourceShowTheLegendCheckBox);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowTheLegendCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MinimumTextBox
            {
                get
                {
                    return new QID(ResourceMinimumTextBox);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowTheLegendCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MaximumTextBox
            {
                get
                {
                    return new QID(ResourceMaximumTextBox);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ShowThe_legendListView resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ShowThe_legendListView
            {
                get
                {
                    return new QID(ResourceShowThe_legendListView);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the UpButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID UpButton
            {
                get
                {
                    return new QID(ResourceUpButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DownButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DownButton
            {
                get
                {
                    return new QID(ResourceDownButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AutomaticCheckBox resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AutomaticCheckBox
            {
                get
                {
                    return new QID(ResourceAutomaticCheckBox);
                }
            }

            public static QID max
            {
                get
                {
                    return new QID(ResourceMax);
                }
            }

            public static QID min
            {
                get
                {
                    return new QID(ResourceMin);
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the IncrementButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
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
            ///   [asttest] 1/13/2011 Created
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
            /// Gets access to the IncrementButton2 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID IncrementButton2
            {
                get
                {
                    return new QID(ResourceIncrementButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DecrementButton2 resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DecrementButton2
            {
                get
                {
                    return new QID(ResourceDecrementButton);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the PreviousButton resource qid string
            /// </summary>
            /// <history>
            ///   [asttest] 1/13/2011 Created
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
            ///   [asttest] 1/13/2011 Created
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
            ///   [asttest] 1/13/2011 Created
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
            ///   [asttest] 1/13/2011 Created
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
        ///   [v-kantao] 1/13/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {            
            /// <summary>
            /// Resource string for Show the legend
            /// </summary>
            public const string ShowTheLegend = "Show the legend";
            
            
            
            /// <summary>
            /// Resource string for Up
            /// </summary>
            public const string Up = "Up";
            
            /// <summary>
            /// Resource string for Down
            /// </summary>
            public const string Down = "Down";
            
       
           
            /// <summary>
            /// Resource string for Revert
            /// </summary>
            public const string Revert = "Revert";
            
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
