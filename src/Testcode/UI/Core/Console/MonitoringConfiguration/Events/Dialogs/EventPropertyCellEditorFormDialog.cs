// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EventPropertyCellEditorFormDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Event Property Cell Editor Form Dialog which is popped-up from 
//  the Build Expression Dialog which used in several rules and monitor Wizards. 
// </summary>
// <remarks>
// This class was hand crafted, since it is not present when the UIClassMaker tool
// is run.
// </remarks>
// <history>
// 	[barryw] 28NOV05 Created
//  [ruhim]  16April07 Updated dialog title   
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    #region Using directives

    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;

    #endregion

    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[barryw] 28NOV05 Created.
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup
    {
        /// <summary>
        /// Use Event Property = 0
        /// </summary>
        UseEventProperty = 0,

        /// <summary>
        /// Use Event Parameter = 1
        /// </summary>
        UseEventParameter = 1,
    }

    #endregion

    #region Interface Definition - IEventPropertyCellEditorFormDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IBuildExpressionDialogControls, for BuildExpressionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryw] 28NOV05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEventPropertyCellEditorFormDialogControls
    {
        /// <summary>
        /// Read-only property to access ManagementPackComboBox
        /// </summary>
        ComboBox EventPropertiesComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access UseEventPropertyRadioButton
        /// </summary>
        RadioButton UseEventPropertyRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access UseEventParameterRadioButton
        /// </summary>
        RadioButton UseEventParameterRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Parameter Number text box.
        /// </summary>
        TextBox ParameterNumberTextBox
        {
            get;
        }

    }

    #endregion

    #region EventPropertyCellEditorFormDialog Class

    /// <summary>
    /// This class is designed to encapsulate the functions of
    /// the Event Property Editor form.
    /// </summary>
    public class EventPropertyCellEditorFormDialog : Dialog, IEventPropertyCellEditorFormDialogControls
    {
        #region Member variables section

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Cache to hold a reference to EventPropertiesComboBox of type Combox.
        /// </summary>
        /// -----------------------------------------------------------------------------
        private ComboBox cachedEventPropertiesComboBox;

        /// <summary>
        /// Cache to hold a reference to UseEventPropertyRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseEventPropertyRadioButton;

        /// <summary>
        /// Cache to hold a reference to UseEventParameterRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedUseEventParameterRadioButton;

        /// <summary>
        /// Cache to hold a reference to ParameterNumber of type TextBox
        /// </summary>
        private TextBox cachedParameterNumberTextBox;

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <param name="app">Reference to the MOM console</param>
        /// <history>
        /// 	[barryw] 28NOV05 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        public EventPropertyCellEditorFormDialog(Mom.Test.UI.Core.Console.MomConsoleApp app)
            : base(app, Init())
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup
        /// </summary>
        /// <history>
        /// 	[barryw] 22-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup RadioGroup
        {
            get
            {
                if ((this.Controls.UseEventPropertyRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup.UseEventProperty;
                }

                if ((this.Controls.UseEventParameterRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup.UseEventParameter;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == RadioGroup.UseEventProperty))
                {
                    this.Controls.UseEventPropertyRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup.UseEventParameter))
                    {
                        this.Controls.UseEventParameterRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region IEventPropertyCellEditorFormDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryw] 28NOV05 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEventPropertyCellEditorFormDialogControls Controls
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
        ///  Routine to set/get the text in control EventPropertiesComboBox
        /// </summary>
        /// <value>Event property name</value>
        /// <history>
        /// 	[barryw] 28NOV05 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EventPropertiesText
        {
            get
            {
                return this.Controls.EventPropertiesComboBox.Text;
            }

            set
            {
                this.Controls.EventPropertiesComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ParameterNumber
        /// </summary>
        /// <value>Event parameter number</value>
        /// <history>
        /// 	[barryw] 28NOV05 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ParameterNumberText
        {
            get
            {
                return this.Controls.ParameterNumberTextBox.Text;
            }

            set
            {
                this.Controls.ParameterNumberTextBox.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventPropertiesComboBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 28NOV05 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventPropertyCellEditorFormDialogControls.EventPropertiesComboBox
        {
            get
            {
                if ((this.cachedEventPropertiesComboBox == null))
                {
                    this.cachedEventPropertiesComboBox =
                        new ComboBox(this, EventPropertyCellEditorFormDialog.ControlIDs.EventPropertiesComboBox);
                }
                return this.cachedEventPropertiesComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseEventPropertyRadioButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 28NOV05 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IEventPropertyCellEditorFormDialogControls.UseEventPropertyRadioButton
        {
            get
            {
                if ((this.cachedUseEventPropertyRadioButton == null))
                {
                    this.cachedUseEventPropertyRadioButton = new RadioButton(this, EventPropertyCellEditorFormDialog.ControlIDs.UseEventPropertyRadioButton);
                }
                return this.cachedUseEventPropertyRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseEventParameterRadioButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 28NOV05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IEventPropertyCellEditorFormDialogControls.UseEventParameterRadioButton
        {
            get
            {
                if ((this.cachedUseEventParameterRadioButton == null))
                {
                    this.cachedUseEventParameterRadioButton = new RadioButton(this, EventPropertyCellEditorFormDialog.ControlIDs.UseEventParameterRadioButton);
                }
                return this.cachedUseEventParameterRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParameterNumberTextBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 28NOV05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventPropertyCellEditorFormDialogControls.ParameterNumberTextBox
        {
            get
            {
                if ((this.cachedParameterNumberTextBox == null))
                {
                    this.cachedParameterNumberTextBox = 
                        new TextBox(
                        this, 
                        EventPropertyCellEditorFormDialog.ControlIDs.ParameterNumberTextBox);
                }
                return this.cachedParameterNumberTextBox;
            }
        }

        #endregion

        #region Click Methods

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <history>
        /// 	[barryw] 28NOV05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init()
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of the dialog
                tempWindow = new Window(
                    Strings.DialogTitle + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 5;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '" +
                    Strings.DialogTitle + "*'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);

                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Constants.DefaultDialogTimeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        // sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Constants.DefaultDialogTimeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt " +
                            numberOfTries +
                            " of " +
                            MAXTRIES +
                            "...");
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window" +
                        "with a title of '" + Strings.DialogTitle +
                        "*'.\n\n" + ex.Message);
                }
            }
            return tempWindow;
        }

    #endregion  // EventPropertyCellEditorFormDialog Class

        #region Strings Class

        /// -----------------------------------------------------------------------------        
        /// <history>
        /// 	[ruhim] 13-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------            
            private const string ResourceDialogTitle =
                ";Select an Event Property;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventPropertyForm;$this.Text";
                //@";EventPropertyCellEditorForm;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventPropertyForm;$this.Text";
            
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 28NOV05 Created.
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

            #endregion
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[barryw] 28NOV05 Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for EventPropertiesComboBox
            /// </summary>
            public const string EventPropertiesComboBox = "eventPropListCBox";
            /// <summary>
            /// Control ID for UseEventPropertyRadioButton
            /// </summary>
            public const string UseEventPropertyRadioButton = "Use known event property:";

            /// <summary>
            /// Control ID for UseEventParameterRadioButton
            /// </summary>
            public const string UseEventParameterRadioButton = "Use event data parameters:";
        
            /// <summary>
            /// Control ID for ParameterNumberTextBox
            /// </summary>
            public const string ParameterNumberTextBox = "Parameter Number:";

        }

        #endregion

        #region Boundaries

        /// <summary>
        /// Field boundary sizes
        /// </summary>
        public class Boundaries
        {
            #region Constants section

            /// <summary>
            /// Minimum length of SomeField
            /// </summary>
            ////Todo: Add real fields and sizes 
            public const int MinLengthSomeField = 1;

            /// <summary>
            /// Maximum length of name
            /// </summary>
            public const int MaxLengthSomeField = 150;

            #endregion
        }
        #endregion
    }
}
