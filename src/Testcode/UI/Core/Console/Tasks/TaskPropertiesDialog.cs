// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TaskPropertiesDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-eachu] 08DEC09 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Tasks
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ITaskPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITaskPropertiesDialogControls, for TaskPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-eachu] 08DEC09 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITaskPropertiesDialogControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectButton
        /// </summary>
        Button SelectButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskTargetTextBox
        /// </summary>
        TextBox TaskTargetTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskDescriptionTextBox
        /// </summary>
        TextBox TaskDescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskNameTextBox
        /// </summary>
        TextBox TaskNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DisplayOutputWhenThisTaskIsRunCheckBox
        /// </summary>
        CheckBox DisplayOutputWhenThisTaskIsRunCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WorkingDirectoryTextBox
        /// </summary>
        TextBox WorkingDirectoryTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskParameterTextBox
        /// </summary>
        TextBox TaskParameterTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskApplicationTextBox
        /// </summary>
        TextBox TaskApplicationTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DefaultManagementPackComboBox
        /// </summary>
        NumericUpDown DefaultManagementPackComboBox
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
    ///   [v-eachu] 08DEC09 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class TaskPropertiesDialog : Dialog, ITaskPropertiesDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectButton of type Button
        /// </summary>
        private Button cachedSelectButton;
        
        /// <summary>
        /// Cache to hold a reference to TaskTargetTextBox of type TextBox
        /// </summary>
        private TextBox cachedTaskTargetTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TaskDescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedTaskDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TaskNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedTaskNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to DisplayOutputWhenThisTaskIsRunCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedDisplayOutputWhenThisTaskIsRunCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to WorkingDirectoryTextBox of type TextBox
        /// </summary>
        private TextBox cachedWorkingDirectoryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TaskParameterTextBox of type TextBox
        /// </summary>
        private TextBox cachedTaskParameterTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TaskApplicationTextBox of type TextBox
        /// </summary>
        private TextBox cachedTaskApplicationTextBox;

        /// <summary>
        /// Cache to hold a reference to DefaultManagementPackComboBox of type NumericUpDown
        /// </summary>
        private NumericUpDown cachedDefaultManagementPackComboBox;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TaskPropertiesDialog of type ConsoleApp
        /// </param>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TaskPropertiesDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ITaskPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITaskPropertiesDialogControls Controls
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
        ///  Property to handle checkbox DisplayOutputWhenThisTaskIsRun
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool DisplayOutputWhenThisTaskIsRun
        {
            get
            {
                return this.Controls.DisplayOutputWhenThisTaskIsRunCheckBox.Checked;
            }
            
            set
            {
                this.Controls.DisplayOutputWhenThisTaskIsRunCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TaskTargetTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TaskTargetText
        {
            get
            {
                return this.Controls.TaskTargetTextBox.Text;
            }
            
            set
            {
                this.Controls.TaskTargetTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TaskDescriptionTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TaskDescriptionText
        {
            get
            {
                return this.Controls.TaskDescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.TaskDescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TaskNameTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TaskNameText
        {
            get
            {
                return this.Controls.TaskNameTextBox.Text;
            }
            
            set
            {
                this.Controls.TaskNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WorkingDirectoryTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WorkingDirectoryText
        {
            get
            {
                return this.Controls.WorkingDirectoryTextBox.Text;
            }
            
            set
            {
                this.Controls.WorkingDirectoryTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TaskParameterTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TaskParameterText
        {
            get
            {
                return this.Controls.TaskParameterTextBox.Text;
            }
            
            set
            {
                this.Controls.TaskParameterTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TaskApplicationTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TaskApplicationText
        {
            get
            {
                return this.Controls.TaskApplicationTextBox.Text;
            }
            
            set
            {
                this.Controls.TaskApplicationTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TimeOutText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 12/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeOutText
        {
            get
            {
                return this.Controls.DefaultManagementPackComboBox.TextBox.Text;
            }

            set
            {
                this.Controls.DefaultManagementPackComboBox.TextBox.Text = value;
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskPropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, TaskPropertiesDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TaskPropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, TaskPropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ITaskPropertiesDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, TaskPropertiesDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskPropertiesDialogControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, TaskPropertiesDialog.ControlIDs.SelectButton);
                }
                
                return this.cachedSelectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskTargetTextBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskPropertiesDialogControls.TaskTargetTextBox
        {
            get
            {
                if ((this.cachedTaskTargetTextBox == null))
                {
                    this.cachedTaskTargetTextBox = new TextBox(this, TaskPropertiesDialog.ControlIDs.TaskTargetTextBox);
                }

                return this.cachedTaskTargetTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskDescriptionTextBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskPropertiesDialogControls.TaskDescriptionTextBox
        {
            get
            {
                if ((this.cachedTaskDescriptionTextBox == null))
                {
                    this.cachedTaskDescriptionTextBox = new TextBox(this, TaskPropertiesDialog.ControlIDs.TaskDescriptionTextBox);
                }

                return this.cachedTaskDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskNameTextBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskPropertiesDialogControls.TaskNameTextBox
        {
            get
            {
                if ((this.cachedTaskNameTextBox == null))
                {
                    this.cachedTaskNameTextBox = new TextBox(this, TaskPropertiesDialog.ControlIDs.TaskNameTextBox);
                }

                return this.cachedTaskNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskPropertiesDialogControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, TaskPropertiesDialog.ControlIDs.BrowseButton);
                }
                
                return this.cachedBrowseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITaskPropertiesDialogControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, TaskPropertiesDialog.ControlIDs.Button0);
                }
                
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayOutputWhenThisTaskIsRunCheckBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ITaskPropertiesDialogControls.DisplayOutputWhenThisTaskIsRunCheckBox
        {
            get
            {
                if ((this.cachedDisplayOutputWhenThisTaskIsRunCheckBox == null))
                {
                    this.cachedDisplayOutputWhenThisTaskIsRunCheckBox = new CheckBox(this, TaskPropertiesDialog.ControlIDs.DisplayOutputWhenThisTaskIsRunCheckBox);
                }
                
                return this.cachedDisplayOutputWhenThisTaskIsRunCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WorkingDirectoryTextBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskPropertiesDialogControls.WorkingDirectoryTextBox
        {
            get
            {
                if ((this.cachedWorkingDirectoryTextBox == null))
                {
                    this.cachedWorkingDirectoryTextBox = new TextBox(this, TaskPropertiesDialog.ControlIDs.WorkingDirectoryTextBox);
                }

                return this.cachedWorkingDirectoryTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskParameterTextBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskPropertiesDialogControls.TaskParameterTextBox
        {
            get
            {
                if ((this.cachedTaskParameterTextBox == null))
                {
                    this.cachedTaskParameterTextBox = new TextBox(this, TaskPropertiesDialog.ControlIDs.TaskParameterTextBox);
                }

                return this.cachedTaskParameterTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskApplicationTextBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITaskPropertiesDialogControls.TaskApplicationTextBox
        {
            get
            {
                if ((this.cachedTaskApplicationTextBox == null))
                {
                    this.cachedTaskApplicationTextBox = new TextBox(this, TaskPropertiesDialog.ControlIDs.TaskApplicationTextBox);
                }

                return this.cachedTaskApplicationTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DefaultManagementPackComboBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 12/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        NumericUpDown ITaskPropertiesDialogControls.DefaultManagementPackComboBox
        {
            get
            {
                if ((this.cachedDefaultManagementPackComboBox == null))
                {
                    this.cachedDefaultManagementPackComboBox = new NumericUpDown(this, TaskPropertiesDialog.ControlIDs.DefaultManagementPackComboBox);
                }

                return this.cachedDefaultManagementPackComboBox;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelect()
        {
            this.Controls.SelectButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DisplayOutputWhenThisTaskIsRun
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDisplayOutputWhenThisTaskIsRun()
        {
            this.Controls.DisplayOutputWhenThisTaskIsRunCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ConsoleApp owning the dialog.</param>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
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
                    throw windowNotFound;
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
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for SelectButton
            /// </summary>
            public const string SelectButton = "browseButton";
            
            /// <summary>
            /// Control ID for TaskTargetTextBox
            /// </summary>
            public const string TaskTargetTextBox = "targetBox";
            
            /// <summary>
            /// Control ID for TaskDescriptionTextBox
            /// </summary>
            public const string TaskDescriptionTextBox = "descriptionTextbox";
            
            /// <summary>
            /// Control ID for TaskNameTextBox
            /// </summary>
            public const string TaskNameTextBox = "nameTextbox";
            
            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "browse";
            
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "placeHolder";
            
            /// <summary>
            /// Control ID for DisplayOutputWhenThisTaskIsRunCheckBox
            /// </summary>
            public const string DisplayOutputWhenThisTaskIsRunCheckBox = "displayOutput";
            
            /// <summary>
            /// Control ID for WorkingDirectoryTextBox
            /// </summary>
            public const string WorkingDirectoryTextBox = "idTextBoxWorkingDirectory";
            
            /// <summary>
            /// Control ID for TaskParameterTextBox
            /// </summary>
            public const string TaskParameterTextBox = "parametersBox";
            
            /// <summary>
            /// Control ID for TaskApplicationTextBox
            /// </summary>
            public const string TaskApplicationTextBox = "applicationBox";

            /// <summary>
            /// Control ID for DefaultManagementPackComboBox
            /// </summary>
            public const string DefaultManagementPackComboBox = "iDNumericUpDown";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-eachu] 08DEC09 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Resource string for cc Properties
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string ResourceDialogTitle = ";{0} Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;MPObjectFormatString";
            
            /// <summary>
            /// Resource string for Apply
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.PropertyDialogForm;buttonApply.Text
            /// ;Apply;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationEditorForm;buttonStatusApply.Text
            /// ;Apply;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationPropertiesForm;buttonApply.Text
            /// ;Apply;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RequestPropertiesForm;buttonApply.Text
            /// ;Apply;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework;applyButton.Text
            /// ;Apply;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;applyButton.Text
            /// ;Apply;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Overrides.OverridesDialog;applyButton.Text
            /// </remark>
            public const string ResourceApply = ";&Apply;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resource" +
                "s.dll;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework.en;applyBut" +
                "ton.Text";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en;cancelButton.Text
            /// ;Cancel;ManagedString;AjaxControlToolkit.dll;AjaxControlToolkit.ScriptResources.ScriptResources;RTE_Cancel
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;cancelButton.Text
            /// ;Cancel;ManagedString;RootWebConsole.dll;resources.webresource;Dlg_cancel_btn
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;cancelButton.Text
            /// ;Cancel;ManagedString;MobileWebConsole.dll;resources.webresource;Dlg_cancel_btn
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;cancelButton.Text
            /// ;Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.TranslucentColorPicker;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPDownloadInstallResources;Cancel
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.CatalogConnectionDialog;closeButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.EulaDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCatalogDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPErrorDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.ResolveDependentsDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.UpdateAgentWarningForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.CredentialForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AdvancedAlertSuppressionForm;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertSuppressionForm;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;cnlbtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RawXmlEditor;cancelbtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NewNameDialog;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventConsolidationPropertiesForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.GenericConsolidationPropertiesForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AdvancedOptionsForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventLogSelectorForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventPropertyForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EditRegistryProbeDialog;idBtnCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExcludedDaysForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TimeRangeForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServiceBrowserForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConnectionStringBuilder;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;btnCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ParametersDialog;btnCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.FormulaDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExtendedTypeForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.CreateWebApplicationform;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.OpenServiceForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceComponentForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceComponentPropertiesForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServicePropertiesForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ChooseSCIMonitorForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.BusinessHoursForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportColumnFilterDialog;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlValueEditorDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringOptionDialog;Cancel_Options.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Favorites.FavoriteReportWizard;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Publish.PublishReportWizard;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportExportForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportFindForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportZoomForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ConnectionDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.ColumnPickerDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.ObjectFetcherDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MaintenanceModeDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringClassChooser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringObjectChooser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.GroupServiceChooser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewAuthoringDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources;CancelText
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemStatePropertyDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemDataCollectionDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemCollectRegistryDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemCollectWmiQueryDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.UrlViewAuthoringDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.DashboardViewAuthoringDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.SelectViewDialog;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceTimePicker;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceScalePicker;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceViewPropertiesDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.HealthExplorerInfoDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.RunTaskDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.RunTask.TaskOverridesDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Overrides.OverridesDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverrideDescriptionForm;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SavedSearchForm;cancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.NewFolderDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ShowHideDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialog;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.CreateFolderDialog;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.DeleteShortcutConfirmDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.NewFolderDlg;cancelBtn.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources;CancelText
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.AddRecipientForm;cancel.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SmtpServerForm;cancel.Text
            /// ;Cancel;ManagedString;Microsoft.ReportViewer.Winforms.dll;Microsoft.Reporting.WinForms.ExportDialog;cancelButton.Text
            /// ;Cancel;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.DiscoveryCriteriaForm;buttonCancel.Text
            /// ;Cancel;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Authoring.dll;Microsoft.SystemCenter.CrossPlatform.UI.Authoring.Common.ServerBrowserForm;btnCancel.Text
            /// </remark>
            public const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resource" +
                "s.dll;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework.en;cancelBu" +
                "tton.Text";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;OK;ManagedString;AjaxControlToolkit.dll;AjaxControlToolkit.ScriptResources.ScriptResources;RTE_OK
            /// ;OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonOK.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonOK.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonOK.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonOK.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonOK.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonOK.Text
            /// ;OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.TranslucentColorPicker;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs.MPCategoryPropertiesDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.CredentialForm;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AdvancedAlertSuppressionForm;okBtn.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertSuppressionForm;okBtn.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CustomAlertFieldsForm;okbtn.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RawXmlEditor;okbtn.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NewNameDialog;okBtn.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventConsolidationPropertiesForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.GenericConsolidationPropertiesForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AdvancedOptionsForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventLogSelectorForm;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventPropertyForm;okbutton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EditRegistryProbeDialog;idBtnOK.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExcludedDaysForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TimeRangeForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServiceBrowserForm;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConnectionStringBuilder;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MappingValueDialog;btnAccept.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ParametersDialog;btnAccept.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.FormulaDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExtendedTypeForm;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.CreateWebApplicationform;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.RunNowResultForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.FullResultsForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.OpenServiceForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.CreateServiceComponentForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ReplaceDisplayedNavPaneItemsForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceComponentPropertiesForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServicePropertiesForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ChooseSCIMonitorForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.HelpAboutForm;closeButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportColumnFilterDialog;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportXmlValueEditorDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringOptionDialog;OK_Options.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Favorites.FavoriteReportWizard;okBtn.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Wizards.Publish.PublishReportWizard;okBtn.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportFindForm;okButton.Text
            /// ;OK;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportZoomForm;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase;buttonOK.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog;buttonOK.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.ColumnPickerDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.InstancePropertiesDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MaintenanceModeDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringClassChooser;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringObjectChooser;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.GroupServiceChooser;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemStatePropertyDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemDataCollectionDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemCollectFileDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemCollectRegistryDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AemCollectWmiQueryDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.UrlViewAuthoringDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.DashboardViewAuthoringDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.SelectViewDialog;okbutton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceTimePicker;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceScalePicker;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceViewPropertiesDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Overrides.OverridesDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverrideDescriptionForm;okBtn.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SavedSearchForm;ok.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.NewFolderDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ShowHideDialog;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialog;okBtn.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.CreateFolderDialog;okBtn.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.NewFolderDlg;okBtn.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.AddRecipientForm;ok.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource;OKButtonText
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm;okButton.Text
            /// ;OK;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.SmtpServerForm;ok.Text
            /// ;OK;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.DiscoveryCriteriaForm;buttonOk.Text
            /// ;OK;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Authoring.dll;Microsoft.SystemCenter.CrossPlatform.UI.Authoring.Common.ServerBrowserForm;btnOk.Text
            /// </remark>
            public const string ResourceOK = ";OK;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resources.dl" +
                "l;Microsoft.EnterpriseManagement.ConsoleFramework.SheetFramework.en;okButton.Tex" +
                "t";
            
            /// <summary>
            /// Resource string for Tab0
            /// </summary>
            /// TODO: UIClassMaker could not find the resource for this string.  Find it and replace literal created by tool.
            public const string ResourceTab0 = "Tab0";
            
            /// <summary>
            /// Resource string for Select...
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RuleGeneralPage;browseButton.Text
            /// ;Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TaskGeneralPage;browseButton.Text
            /// ;Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Exchange2007.MailflowSourceServerPage;buttonSelect.Text
            /// ;Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterDataSource;browseButton.Text
            /// ;Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DiagnosticGeneralPage;browseButton.Text
            /// ;Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaTrackTargetPage;browseButton.Text
            /// ;Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;browseButton.Text
            /// ;Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.PerformanceSloDialog;browseButton.Text
            /// </remark>
            public const string ResourceSelect = ";&Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;browseBut" +
                "ton.Text";
            
            /// <summary>
            /// Resource string for Browse...
            /// </summary>
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Browse...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsoleTaskCommandPage;browse.Text
            /// </remark>
            public const string ResourceBrowse = ";Bro&wse...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsAccount.BinaryA" +
                "ccount;buttonBrowse.Text";
            
            /// <summary>
            /// Resource string for Display output when this task is run
            /// </summary>
            public const string ResourceDisplayOutputWhenThisTaskIsRun = ";Display o&utput when this task is run;ManagedString;Microsoft.EnterpriseManageme" +
                "nt.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.C" +
                "onsoleTaskCommandPage;displayOutput.Text";
            
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
            /// Caches the translated resource string for: Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelect;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowse;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: DisplayOutputWhenThisTaskIsRun
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisplayOutputWhenThisTaskIsRun;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 08DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = "*" + CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle).Replace("{0}", "") + "*";//CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 08DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 08DEC09 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to OK translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 08DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 08DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab0
            {
                get
                {
                    if ((cachedTab0 == null))
                    {
                        cachedTab0 = CoreManager.MomConsole.GetIntlStr(ResourceTab0);
                    }
                    return cachedTab0;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Select translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 08DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Select
            {
                get
                {
                    if ((cachedSelect == null))
                    {
                        cachedSelect = CoreManager.MomConsole.GetIntlStr(ResourceSelect);
                    }
                    return cachedSelect;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 08DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Browse
            {
                get
                {
                    if ((cachedBrowse == null))
                    {
                        cachedBrowse = CoreManager.MomConsole.GetIntlStr(ResourceBrowse);
                    }
                    return cachedBrowse;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 08DEC09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayOutputWhenThisTaskIsRun
            {
                get
                {
                    if ((cachedDisplayOutputWhenThisTaskIsRun == null))
                    {
                        cachedDisplayOutputWhenThisTaskIsRun = CoreManager.MomConsole.GetIntlStr(ResourceDisplayOutputWhenThisTaskIsRun);
                    }
                    return cachedDisplayOutputWhenThisTaskIsRun;
                }
            }

            #endregion
        }
        #endregion
    }
}
