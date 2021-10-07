// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RunningProcessesDialog.cs">
//   Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [bretlink] 9/9/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.ProcessMonitor.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - Previous

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Previous
    /// </summary>
    /// <history>
    ///   [bretlink] 9/9/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Previous
    {
        /// <summary>
        /// DurationRadioButton = 0
        /// </summary>
        DurationRadioButton = 0,
        
        /// <summary>
        /// NumInstancesRadioButton = 1
        /// </summary>
        NumInstancesRadioButton = 1,
    }
    #endregion
    
    #region Interface Definition - IRunningProcessesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRunningProcessesDialogControls, for RunningProcessesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [bretlink] 9/9/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRunningProcessesDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DurationUnitNumInstancesComboBox
        /// </summary>
        ComboBox DurationUnitNumInstancesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DurationValNumInstancesComboBox
        /// </summary>
        EditComboBox DurationValNumInstancesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DurationUnitRuntimeComboBox
        /// </summary>
        ComboBox DurationUnitRuntimeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DurationValRuntimeComboBox
        /// </summary>
        EditComboBox DurationValRuntimeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaximumInstancesComboBox
        /// </summary>
        EditComboBox MaximumInstancesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MinimumInstancesComboBox
        /// </summary>
        EditComboBox MinimumInstancesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DurationRadioButton
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        RadioButton DurationRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NumInstancesRadioButton
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        RadioButton NumInstancesRadioButton
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
    ///   [bretlink] 9/9/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class RunningProcessesDialog : Dialog, IRunningProcessesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to DurationUnitNumInstancesComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDurationUnitNumInstancesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DurationValNumInstancesComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedDurationValNumInstancesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DurationUnitRuntimeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDurationUnitRuntimeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DurationValRuntimeComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedDurationValRuntimeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MaximumInstancesComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedMaximumInstancesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MinimumInstancesComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedMinimumInstancesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DurationRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDurationRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to NumInstancesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedNumInstancesRadioButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of RunningProcessesDialog of type App
        /// </param>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RunningProcessesDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Previous
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Previous Previous
        {
            get
            {
                if ((this.Controls.DurationRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Previous.DurationRadioButton;
                }
                
                if ((this.Controls.NumInstancesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Previous.NumInstancesRadioButton;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == Previous.DurationRadioButton))
                {
                    this.Controls.DurationRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Previous.NumInstancesRadioButton))
                    {
                        this.Controls.NumInstancesRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IRunningProcessesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRunningProcessesDialogControls Controls
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
        ///  Routine to set/get the text in control MonitoringType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DurationUnitNumInstancesText
        {
            get
            {
                return this.Controls.DurationUnitNumInstancesComboBox.Text;
            }
            
            set
            {
                this.Controls.DurationUnitNumInstancesComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DurationValNumInstancesText
        {
            get
            {
                return this.Controls.DurationValNumInstancesComboBox.Text;
            }
            
            set
            {
                this.Controls.DurationValNumInstancesComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DurationUnitRuntime
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DurationUnitRuntimeText
        {
            get
            {
                return this.Controls.DurationUnitRuntimeComboBox.Text;
            }
            
            set
            {
                this.Controls.DurationUnitRuntimeComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType4
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DurationValRuntimeText
        {
            get
            {
                return this.Controls.DurationValRuntimeComboBox.Text;
            }
            
            set
            {
                this.Controls.DurationValRuntimeComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType5
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaximumInstancesText
        {
            get
            {
                return this.Controls.MaximumInstancesComboBox.Text;
            }
            
            set
            {
                this.Controls.MaximumInstancesComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType6
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MinimumInstancesText
        {
            get
            {
                return this.Controls.MinimumInstancesComboBox.Text;
            }
            
            set
            {
                this.Controls.MinimumInstancesComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunningProcessesDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, RunningProcessesDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunningProcessesDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, RunningProcessesDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunningProcessesDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, RunningProcessesDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRunningProcessesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RunningProcessesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationUnitNumInstancesComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRunningProcessesDialogControls.DurationUnitNumInstancesComboBox
        {
            get
            {
                if ((this.cachedDurationUnitNumInstancesComboBox == null))
                {
                    this.cachedDurationUnitNumInstancesComboBox = new ComboBox(this, RunningProcessesDialog.ControlIDs.DurationUnitNumInstancesComboBox);
                }
                
                return this.cachedDurationUnitNumInstancesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationValNumInstancesComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunningProcessesDialogControls.DurationValNumInstancesComboBox
        {
            get
            {
                if ((this.cachedDurationValNumInstancesComboBox == null))
                {
                    this.cachedDurationValNumInstancesComboBox = new EditComboBox(this, RunningProcessesDialog.ControlIDs.DurationValNumInstancesComboBox);
                }
                
                return this.cachedDurationValNumInstancesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationUnitRuntimeComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IRunningProcessesDialogControls.DurationUnitRuntimeComboBox
        {
            get
            {
                // The ID for this control (comboBoxUnit) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDurationUnitRuntimeComboBox == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDurationUnitRuntimeComboBox = new ComboBox(wndTemp);
                }
                
                return this.cachedDurationUnitRuntimeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationValRuntimeComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunningProcessesDialogControls.DurationValRuntimeComboBox
        {
            get
            {
                // The ID for this control (numericDropDown) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDurationValRuntimeComboBox == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedDurationValRuntimeComboBox = new EditComboBox(wndTemp);
                }
                
                return this.cachedDurationValRuntimeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumInstancesComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunningProcessesDialogControls.MaximumInstancesComboBox
        {
            get
            {
                if ((this.cachedMaximumInstancesComboBox == null))
                {
                    this.cachedMaximumInstancesComboBox = new EditComboBox(this, RunningProcessesDialog.ControlIDs.MaximumInstancesComboBox);
                }
                
                return this.cachedMaximumInstancesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumInstancesComboBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IRunningProcessesDialogControls.MinimumInstancesComboBox
        {
            get
            {
                if ((this.cachedMinimumInstancesComboBox == null))
                {
                    this.cachedMinimumInstancesComboBox = new EditComboBox(this, RunningProcessesDialog.ControlIDs.MinimumInstancesComboBox);
                }
                
                return this.cachedMinimumInstancesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DurationRadioButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IRunningProcessesDialogControls.DurationRadioButton
        {
            get
            {
                if ((this.cachedDurationRadioButton == null))
                {
                    this.cachedDurationRadioButton = new RadioButton(this, RunningProcessesDialog.ControlIDs.DurationRadioButton);
                }
                
                return this.cachedDurationRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumInstancesRadioButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IRunningProcessesDialogControls.NumInstancesRadioButton
        {
            get
            {
                if ((this.cachedNumInstancesRadioButton == null))
                {
                    this.cachedNumInstancesRadioButton = new RadioButton(this, RunningProcessesDialog.ControlIDs.NumInstancesRadioButton);
                }
                
                return this.cachedNumInstancesRadioButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
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
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 40;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);

                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
                }
            }
            return tempWindow;
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for DurationUnitNumInstancesComboBox
            /// </summary>
            public const string DurationUnitNumInstancesComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for DurationValNumInstancesComboBox
            /// </summary>
            public const string DurationValNumInstancesComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for DurationUnitRuntimeComboBox
            /// </summary>
            public const string DurationUnitRuntimeComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for DurationValRuntimeComboBox
            /// </summary>
            public const string DurationValRuntimeComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for MaximumInstancesComboBox
            /// </summary>
            public const string MaximumInstancesComboBox = "numericUpDownMax";
            
            /// <summary>
            /// Control ID for MinimumInstancesComboBox
            /// </summary>
            public const string MinimumInstancesComboBox = "numericUpDownMin";
            
            /// <summary>
            /// Control ID for DurationRadioButton
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string DurationRadioButton = "radioButtonProcessRunningTime";
            
            /// <summary>
            /// Control ID for NumInstancesRadioButton
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string NumInstancesRadioButton = "radioButtonProcessInstanceCount";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [bretlink] 9/9/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommon" +
                "Resources;TemplateWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    
                    return cachedPrevious;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    
                    return cachedNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    
                    return cachedCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 9/9/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    
                    return cachedCancel;
                }
            }
            #endregion
        }
        #endregion
    }
}
