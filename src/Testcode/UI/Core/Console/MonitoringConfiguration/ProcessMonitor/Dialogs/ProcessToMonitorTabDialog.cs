// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ProcessToMonitorTabDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-brucec] 4/28/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.ProcessMonitor.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    #region Interface Definition - IProcessToMonitorTabDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IProcessToMonitorTabDialogControls, for ProcessToMonitorTabDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-brucec] 4/28/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IProcessToMonitorTabDialogControls
    {
        /// <summary>
        /// Gets read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Gets read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }

        /// <summary>
        /// Gets read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
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
    ///   [v-brucec] 4/28/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class ProcessToMonitorTabDialog : Dialog, IProcessToMonitorTabDialogControls
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
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;

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
        /// Initializes a new instance of the ProcessToMonitorTabDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of ProcessToMonitorTabDialog of type App
        /// </param>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ProcessToMonitorTabDialog(App app) :
            base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
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

        #region ITargetGroupAndProcessPageDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IProcessToMonitorTabDialogControls Controls
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
        ///  Gets or sets the text in control Duration
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
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
        ///  Gets or sets the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
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
        ///  Gets access to the ApplyButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IProcessToMonitorTabDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, ProcessToMonitorTabDialog.ControlIDs.ApplyButton);
                }

                return this.cachedApplyButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IProcessToMonitorTabDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ProcessToMonitorTabDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IProcessToMonitorTabDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ProcessToMonitorTabDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the Tab1TabControl control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IProcessToMonitorTabDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, ProcessToMonitorTabDialog.ControlIDs.Tab1TabControl);
                }

                return this.cachedTab1TabControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupSearchButton control
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IProcessToMonitorTabDialogControls.GroupSearchButton
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
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IProcessToMonitorTabDialogControls.GroupNameTextBox
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
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IProcessToMonitorTabDialogControls.ProcessMonitorRadioButton
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
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IProcessToMonitorTabDialogControls.UnwantedProcessRadioButton
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
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IProcessToMonitorTabDialogControls.ProcessSearchButton
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
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IProcessToMonitorTabDialogControls.ProcessNameTextBox
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
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
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
        ///   [v-brucec] 4/28/2010 Created
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
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button GroupSearch
        /// </summary>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
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
        ///   [v-brucec] 4/28/2010 Created
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
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-brucec] 4/28/2010 Created
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
        ///   [v-brucec] 4/28/2010 Created
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";

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
        ///   [v-brucec] 4/28/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Private Members

            private static string cachedDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-brucec] 4/28/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = Templates.Strings.PropertiesDialogTitle;
                    }

                    return cachedDialogTitle;
                }
            }
            #endregion
        }
        #endregion
    }
}
