// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TargetGroupAndProcessDialog.cs">
//   Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [bretlink] 2008/09/29 Created
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
    /// Enum for radio group ButtonEnum
    /// </summary>
    /// <history>
    ///   [bretlink] 2008/09/29 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum ButtonEnum
    {
        /// <summary>
        /// ProcessMonitor = 0
        /// </summary>
        ProcessMonitor = 0,
        
        /// <summary>
        /// UnwantedProcess = 1
        /// </summary>
        UnwantedProcess = 1,
        
    }
    #endregion
    
    #region Interface Definition - ITargetGroupAndProcessDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITargetGroupAndProcessDialogControls, for TargetGroupAndProcessDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [bretlink] 2008/09/29 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITargetGroupAndProcessDialogControls
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
        /// Read-only property to access GroupSearchButton
        /// </summary>
        Button GroupSearchButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupNameTextBox
        /// </summary>
        TextBox GroupNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProcessMonitorRadioButton
        /// </summary>
        RadioButton ProcessMonitorRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UnwantedProcessRadioButton
        /// </summary>
        RadioButton UnwantedProcessRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProcessSearchButton
        /// </summary>
        Button ProcessSearchButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProcessNameTextBox
        /// </summary>
        TextBox ProcessNameTextBox
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
    ///   [bretlink] 2008/09/29 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class TargetGroupAndProcessDialog : Dialog, ITargetGroupAndProcessDialogControls
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
        /// Cache to hold a reference to Ellipsis0Button of type Button
        /// </summary>
        private Button cachedGroupSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringTypeTextBox of type TextBox
        /// </summary>
        private TextBox cachedGroupNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to MonitorAProcessAndCollectDataRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedProcessMonitorRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AlertOnAnUnwantedProcessRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUnwantedProcessRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis1Button of type Button
        /// </summary>
        private Button cachedProcessSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringTypeTextBox2 of type TextBox
        /// </summary>
        private TextBox cachedProcessNameTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TargetGroupAndProcessDialog of type App
        /// </param>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TargetGroupAndProcessDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group ButtonEnum
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ButtonEnum ButtonEnum
        {
            get
            {
                if ((this.Controls.ProcessMonitorRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ButtonEnum.ProcessMonitor;
                }
                
                if ((this.Controls.UnwantedProcessRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ButtonEnum.UnwantedProcess;
                }                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == ButtonEnum.ProcessMonitor))
                {
                    this.Controls.ProcessMonitorRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == ButtonEnum.UnwantedProcess))
                    {
                        this.Controls.UnwantedProcessRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ITargetGroupAndProcessDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITargetGroupAndProcessDialogControls Controls
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
        ///  Routine to set/get the text in control GroupName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GroupNameText
        {
            get
            {
                return this.Controls.GroupNameTextBox.Text;
            }
            
            set
            {
                this.Controls.GroupNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ProcessName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ProcessNameText
        {
            get
            {
                return this.Controls.ProcessNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ProcessNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndProcessDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, TargetGroupAndProcessDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndProcessDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, TargetGroupAndProcessDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndProcessDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, TargetGroupAndProcessDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndProcessDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TargetGroupAndProcessDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupSearchButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndProcessDialogControls.GroupSearchButton
        {
            get
            {
                if ((this.cachedGroupSearchButton == null))
                {
                    this.cachedGroupSearchButton = new Button(this, TargetGroupAndProcessDialog.ControlIDs.GroupSearchButton);
                }
                
                return this.cachedGroupSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupNameTextBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITargetGroupAndProcessDialogControls.GroupNameTextBox
        {
            get
            {
                if ((this.cachedGroupNameTextBox == null))
                {
                    this.cachedGroupNameTextBox = new TextBox(this, TargetGroupAndProcessDialog.ControlIDs.GroupNameTextBox);
                }
                
                return this.cachedGroupNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProcessMonitorRadioButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITargetGroupAndProcessDialogControls.ProcessMonitorRadioButton
        {
            get
            {
                if ((this.cachedProcessMonitorRadioButton == null))
                {
                    this.cachedProcessMonitorRadioButton = new RadioButton(this, TargetGroupAndProcessDialog.ControlIDs.ProcessMonitorRadioButton);
                }
                
                return this.cachedProcessMonitorRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UnwantedProcessRadioButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITargetGroupAndProcessDialogControls.UnwantedProcessRadioButton
        {
            get
            {
                if ((this.cachedUnwantedProcessRadioButton == null))
                {
                    this.cachedUnwantedProcessRadioButton = new RadioButton(this, TargetGroupAndProcessDialog.ControlIDs.UnwantedProcessRadioButton);
                }
                
                return this.cachedUnwantedProcessRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProcessSearchButton control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetGroupAndProcessDialogControls.ProcessSearchButton
        {
            get
            {
                if ((this.cachedProcessSearchButton == null))
                {
                    this.cachedProcessSearchButton = new Button(this, TargetGroupAndProcessDialog.ControlIDs.ProcessSearchButton);
                }
                
                return this.cachedProcessSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProcessNameTextBox control
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITargetGroupAndProcessDialogControls.ProcessNameTextBox
        {
            get
            {
                if ((this.cachedProcessNameTextBox == null))
                {
                    this.cachedProcessNameTextBox = new TextBox(this, TargetGroupAndProcessDialog.ControlIDs.ProcessNameTextBox);
                }
                
                return this.cachedProcessNameTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
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
        ///   [bretlink] 2008/09/29 Created
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
        ///   [bretlink] 2008/09/29 Created
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
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupSearch
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickGroupSearch()
        {
            this.Controls.GroupSearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ProcessSearch
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickProcessSearch()
        {
            this.Controls.ProcessSearchButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
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
                const int MAXTRIES = 20;
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
        ///   [bretlink] 2008/09/29 Created
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
            /// Control ID for GroupSearchButton
            /// </summary>
            public const string GroupSearchButton = "buttonSelectGroup";
            
            /// <summary>
            /// Control ID for GroupNameTextBox
            /// </summary>
            public const string GroupNameTextBox = "textboxGroupName";
            
            /// <summary>
            /// Control ID for ProcessMonitorRadioButton
            /// </summary>
            public const string ProcessMonitorRadioButton = "radioButtonMonitorAProcess";
            
            /// <summary>
            /// Control ID for UnwantedProcessRadioButton
            /// </summary>
            public const string UnwantedProcessRadioButton = "radioButtonDetectUnwantedProcess";
            
            /// <summary>
            /// Control ID for ProcessSearchButton
            /// </summary>
            public const string ProcessSearchButton = "buttonSelectProcess";
            
            /// <summary>
            /// Control ID for ProcessNameTextBox
            /// </summary>
            public const string ProcessNameTextBox = "textBoxProcessName";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [bretlink] 2008/09/29 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GroupSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupSearch = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProcessMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProcessMonitor = ";&Monitor a process and collect data;ManagedString;Microsoft.EnterpriseManagement" +
                ".UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Tar" +
                "getGroupAndProcessPage;radioButtonMonitorAProcess.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UnwantedProcess
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUnwantedProcess = ";&Alert on an unwanted process;ManagedString;Microsoft.EnterpriseManagement.UI.Au" +
                "thoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TargetGro" +
                "upAndProcessPage;radioButtonDetectUnwantedProcess.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProcessSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProcessSearch = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GroupSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProcessMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProcessMonitor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UnwantedProcess
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUnwantedProcess;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProcessSearch
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProcessSearch;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 2008/09/29 Created
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
            ///   [bretlink] 2008/09/29 Created
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
            ///   [bretlink] 2008/09/29 Created
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
            ///   [bretlink] 2008/09/29 Created
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
            ///   [bretlink] 2008/09/29 Created
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
            /// Exposes access to the GroupSearch translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 2008/09/29 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupSearch
            {
                get
                {
                    if ((cachedGroupSearch == null))
                    {
                        cachedGroupSearch = CoreManager.MomConsole.GetIntlStr(ResourceGroupSearch);
                    }
                    
                    return cachedGroupSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProcessMonitor translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 2008/09/29 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProcessMonitor
            {
                get
                {
                    if ((cachedProcessMonitor == null))
                    {
                        cachedProcessMonitor = CoreManager.MomConsole.GetIntlStr(ResourceProcessMonitor);
                    }
                    
                    return cachedProcessMonitor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UnwantedProcess translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 2008/09/29 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UnwantedProcess
            {
                get
                {
                    if ((cachedUnwantedProcess == null))
                    {
                        cachedUnwantedProcess = CoreManager.MomConsole.GetIntlStr(ResourceUnwantedProcess);
                    }
                    
                    return cachedUnwantedProcess;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProcessSearch translated resource string
            /// </summary>
            /// <history>
            ///   [bretlink] 2008/09/29 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProcessSearch
            {
                get
                {
                    if ((cachedProcessSearch == null))
                    {
                        cachedProcessSearch = CoreManager.MomConsole.GetIntlStr(ResourceProcessSearch);
                    }
                    
                    return cachedProcessSearch;
                }
            }
            #endregion
        }
        #endregion
    }
}
