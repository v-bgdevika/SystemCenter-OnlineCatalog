// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="UpdateInstanceConfigurationTimeRangeDialog.cs">
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

    #region Interface Definition - IUpdateInstanceConfigurationTimeRangePageControls

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
    public interface IUpdateInstanceConfigurationTimeRangePageControls
    {

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
        /// Gets read-only property to access TimeComboBox
        /// </summary>
        ComboBox TimeComboBox
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
    ///    [v-kantao] 1/16/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class UpdateInstanceConfigurationTimeRangePage : Dialog, IUpdateInstanceConfigurationTimeRangePageControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to IncrementButton of type Button
        /// </summary>
        private Button cachedIncrementButton;

        /// <summary>
        /// Cache to hold a reference to DecrementButton of type Button
        /// </summary>
        private Button cachedDecrementButton;

        /// <summary>
        /// Cache to hold a reference to TimeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimeComboBox;
        
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
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public UpdateInstanceConfigurationTimeRangePage(App app, int timeout, string dialogTitle) :
            base(app, Init(app, timeout, dialogTitle))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IUpdateInstanceConfigurationPage Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///    [v-kantao] 1/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IUpdateInstanceConfigurationTimeRangePageControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control _22
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///    [v-kantao] 1/28/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string Timetext
        {
            get
            {
                return this.Controls.TimeComboBox.Text;
            }

            set
            {
                this.Controls.TimeComboBox.SelectByText(value, true);
            }
        }

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the IncrementButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/28/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationTimeRangePageControls.IncrementButton
        {
            get
            {
                if ((this.cachedIncrementButton == null))
                {
                    this.cachedIncrementButton = new Button(this, UpdateInstanceConfigurationTimeRangePage.QueryIds.IncrementButton);
                }

                return this.cachedIncrementButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DecrementButton control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/28/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUpdateInstanceConfigurationTimeRangePageControls.DecrementButton
        {
            get
            {
                if ((this.cachedDecrementButton == null))
                {
                    this.cachedDecrementButton = new Button(this, UpdateInstanceConfigurationTimeRangePage.QueryIds.DecrementButton);
                }

                return this.cachedDecrementButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TimeComboBox control
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/28/2011 Created
        /// </history>
        /// <remarks>
        ///  TODO: This control (TimeComboBox) does not have a valid ID.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        ComboBox IUpdateInstanceConfigurationTimeRangePageControls.TimeComboBox
        {
            get
            {
                if ((this.cachedTimeComboBox == null))
                {


                    this.cachedTimeComboBox = new ComboBox(this, new QID(";[UIA]ClassName='ComboBox'"));
                }

                return this.cachedTimeComboBox;
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
        Button IUpdateInstanceConfigurationTimeRangePageControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, UpdateInstanceConfigurationTimeRangePage.QueryIds.PreviousButton);
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
        Button IUpdateInstanceConfigurationTimeRangePageControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, UpdateInstanceConfigurationTimeRangePage.QueryIds.NextButton);
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
        Button IUpdateInstanceConfigurationTimeRangePageControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, UpdateInstanceConfigurationTimeRangePage.QueryIds.FinishButton);
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
        Button IUpdateInstanceConfigurationTimeRangePageControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, UpdateInstanceConfigurationTimeRangePage.QueryIds.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Increment
        /// </summary>
        /// <history>
        ///    [v-kantao] 1/28/2011 Created
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
        ///    [v-kantao] 1/28/2011 Created
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
