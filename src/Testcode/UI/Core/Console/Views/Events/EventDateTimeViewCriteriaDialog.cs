// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="EventDateTimeViewCriteriaDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 08/11/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Events
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[lucyra] 08/11/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// WithinTheLast = 0
        /// </summary>
        WithinTheLast = 0,
        
        /// <summary>
        /// WithinTheTimeRange = 1
        /// </summary>
        WithinTheTimeRange = 1,
    }
    #endregion
    
    #region Interface Definition - IEventDateTimeViewCriteriaDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IEventDateTimeViewCriteriaDialogControls, for EventDateTimeViewCriteriaDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 08/11/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEventDateTimeViewCriteriaDialogControls
    {
        /// <summary>
        /// Read-only property to access ComboBox1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WithinTheLastRadioButton
        /// </summary>
        RadioButton WithinTheLastRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterASemiColonDelimitedListOfNumbersComboBox
        /// </summary>
        ComboBox EnterASemiColonDelimitedListOfNumbersComboBox
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
        /// Read-only property to access EnterASemiColonDelimitedListOfNumbersComboBox2
        /// </summary>
        ComboBox EnterASemiColonDelimitedListOfNumbersComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BeforeCheckBox
        /// </summary>
        CheckBox BeforeCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AfterCheckBox
        /// </summary>
        CheckBox AfterCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl
        /// </summary>
        StaticControl SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WithinTheTimeRangeRadioButton
        /// </summary>
        RadioButton WithinTheTimeRangeRadioButton
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
    /// 	[lucyra] 08/11/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class EventDateTimeViewCriteriaDialog : Dialog, IEventDateTimeViewCriteriaDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ComboBox1 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox1;
        
        /// <summary>
        /// Cache to hold a reference to TextBox2 of type TextBox
        /// </summary>
        private TextBox cachedTextBox2;
        
        /// <summary>
        /// Cache to hold a reference to WithinTheLastRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWithinTheLastRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to EnterASemiColonDelimitedListOfNumbersComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedEnterASemiColonDelimitedListOfNumbersComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to EnterASemiColonDelimitedListOfNumbersComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedEnterASemiColonDelimitedListOfNumbersComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to BeforeCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedBeforeCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to AfterCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAfterCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WithinTheTimeRangeRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWithinTheTimeRangeRadioButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of EventDateTimeViewCriteriaDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EventDateTimeViewCriteriaDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.WithinTheLastRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.WithinTheLast;
                }
                
                if ((this.Controls.WithinTheTimeRangeRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.WithinTheTimeRange;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.WithinTheLast))
                {
                    this.Controls.WithinTheLastRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.WithinTheTimeRange))
                    {
                        this.Controls.WithinTheTimeRangeRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IEventDateTimeViewCriteriaDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IEventDateTimeViewCriteriaDialogControls Controls
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
        ///  Property to handle checkbox Before
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Before
        {
            get
            {
                return this.Controls.BeforeCheckBox.Checked;
            }
            
            set
            {
                this.Controls.BeforeCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox After
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool After
        {
            get
            {
                return this.Controls.AfterCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AfterCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox1
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox1Text
        {
            get
            {
                return this.Controls.ComboBox1.Text;
            }
            
            set
            {
                this.Controls.ComboBox1.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox2Text
        {
            get
            {
                return this.Controls.TextBox2.Text;
            }
            
            set
            {
                this.Controls.TextBox2.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EnterASemiColonDelimitedListOfNumbers
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EnterASemiColonDelimitedListOfNumbersText
        {
            get
            {
                return this.Controls.EnterASemiColonDelimitedListOfNumbersComboBox.Text;
            }
            
            set
            {
                this.Controls.EnterASemiColonDelimitedListOfNumbersComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EnterASemiColonDelimitedListOfNumbers2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EnterASemiColonDelimitedListOfNumbers2Text
        {
            get
            {
                return this.Controls.EnterASemiColonDelimitedListOfNumbersComboBox2.Text;
            }
            
            set
            {
                this.Controls.EnterASemiColonDelimitedListOfNumbersComboBox2.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox1 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventDateTimeViewCriteriaDialogControls.ComboBox1
        {
            get
            {
                if ((this.cachedComboBox1 == null))
                {
                    this.cachedComboBox1 = new ComboBox(this, EventDateTimeViewCriteriaDialog.ControlIDs.ComboBox1);
                }
                
                return this.cachedComboBox1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IEventDateTimeViewCriteriaDialogControls.TextBox2
        {
            get
            {
                if ((this.cachedTextBox2 == null))
                {
                    this.cachedTextBox2 = new TextBox(this, EventDateTimeViewCriteriaDialog.ControlIDs.TextBox2);
                }
                
                return this.cachedTextBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithinTheLastRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IEventDateTimeViewCriteriaDialogControls.WithinTheLastRadioButton
        {
            get
            {
                if ((this.cachedWithinTheLastRadioButton == null))
                {
                    this.cachedWithinTheLastRadioButton = new RadioButton(this, EventDateTimeViewCriteriaDialog.ControlIDs.WithinTheLastRadioButton);
                }
                
                return this.cachedWithinTheLastRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterASemiColonDelimitedListOfNumbersComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventDateTimeViewCriteriaDialogControls.EnterASemiColonDelimitedListOfNumbersComboBox
        {
            get
            {
                if ((this.cachedEnterASemiColonDelimitedListOfNumbersComboBox == null))
                {
                    this.cachedEnterASemiColonDelimitedListOfNumbersComboBox = new ComboBox(this, EventDateTimeViewCriteriaDialog.ControlIDs.EnterASemiColonDelimitedListOfNumbersComboBox);
                }
                
                return this.cachedEnterASemiColonDelimitedListOfNumbersComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventDateTimeViewCriteriaDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, EventDateTimeViewCriteriaDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IEventDateTimeViewCriteriaDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, EventDateTimeViewCriteriaDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterASemiColonDelimitedListOfNumbersComboBox2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IEventDateTimeViewCriteriaDialogControls.EnterASemiColonDelimitedListOfNumbersComboBox2
        {
            get
            {
                if ((this.cachedEnterASemiColonDelimitedListOfNumbersComboBox2 == null))
                {
                    this.cachedEnterASemiColonDelimitedListOfNumbersComboBox2 = new ComboBox(this, EventDateTimeViewCriteriaDialog.ControlIDs.EnterASemiColonDelimitedListOfNumbersComboBox2);
                }
                
                return this.cachedEnterASemiColonDelimitedListOfNumbersComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BeforeCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IEventDateTimeViewCriteriaDialogControls.BeforeCheckBox
        {
            get
            {
                if ((this.cachedBeforeCheckBox == null))
                {
                    this.cachedBeforeCheckBox = new CheckBox(this, EventDateTimeViewCriteriaDialog.ControlIDs.BeforeCheckBox);
                }
                
                return this.cachedBeforeCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AfterCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IEventDateTimeViewCriteriaDialogControls.AfterCheckBox
        {
            get
            {
                if ((this.cachedAfterCheckBox == null))
                {
                    this.cachedAfterCheckBox = new CheckBox(this, EventDateTimeViewCriteriaDialog.ControlIDs.AfterCheckBox);
                }
                
                return this.cachedAfterCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IEventDateTimeViewCriteriaDialogControls.SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl
        {
            get
            {
                if ((this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl == null))
                {
                    this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl = new StaticControl(this, EventDateTimeViewCriteriaDialog.ControlIDs.SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl);
                }
                
                return this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithinTheTimeRangeRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IEventDateTimeViewCriteriaDialogControls.WithinTheTimeRangeRadioButton
        {
            get
            {
                if ((this.cachedWithinTheTimeRangeRadioButton == null))
                {
                    this.cachedWithinTheTimeRangeRadioButton = new RadioButton(this, EventDateTimeViewCriteriaDialog.ControlIDs.WithinTheTimeRangeRadioButton);
                }
                
                return this.cachedWithinTheTimeRangeRadioButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
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
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Before
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBefore()
        {
            this.Controls.BeforeCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button After
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAfter()
        {
            this.Controls.AfterCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.WildCard, 
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard, 
                    app.MainWindow, 
                    Timeout);
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
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

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
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[lucyra] 08/11/2007 Created
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
            private const string ResourceDialogTitle = "Date and Time generated";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithinTheLast
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWithinTheLast = ";Within the &last:;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Controls.TimeRangeEditDialog;radioDynamic.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Before
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBefore = ";&Before;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.Controls.TimeRangeEditDialog;checkBefore.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  After
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAfter = ";&After;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.Controls.TimeRangeEditDialog;checkAfter.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheValuesToShowBasedUponDateAndTimeRanges
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheValuesToShowBasedUponDateAndTimeRanges = ";Select the values to show based upon date and time ranges:;ManagedString;Microso" +
                "ft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.Tim" +
                "eRangeEditDialog;labelHeader.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithinTheTimeRange
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWithinTheTimeRange = ";&Within the time range:;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.Internal.UI.Controls.TimeRangeEditDialog;radioRange.Text";
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
            /// Caches the translated resource string for:  WithinTheLast
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithinTheLast;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Before
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBefore;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  After
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAfter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheValuesToShowBasedUponDateAndTimeRanges
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheValuesToShowBasedUponDateAndTimeRanges;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithinTheTimeRange
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithinTheTimeRange;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
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
            /// Exposes access to the WithinTheLast translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithinTheLast
            {
                get
                {
                    if ((cachedWithinTheLast == null))
                    {
                        cachedWithinTheLast = CoreManager.MomConsole.GetIntlStr(ResourceWithinTheLast);
                    }
                    
                    return cachedWithinTheLast;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
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
            /// Exposes access to the Before translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Before
            {
                get
                {
                    if ((cachedBefore == null))
                    {
                        cachedBefore = CoreManager.MomConsole.GetIntlStr(ResourceBefore);
                    }
                    
                    return cachedBefore;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the After translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string After
            {
                get
                {
                    if ((cachedAfter == null))
                    {
                        cachedAfter = CoreManager.MomConsole.GetIntlStr(ResourceAfter);
                    }
                    
                    return cachedAfter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectTheValuesToShowBasedUponDateAndTimeRanges translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheValuesToShowBasedUponDateAndTimeRanges
            {
                get
                {
                    if ((cachedSelectTheValuesToShowBasedUponDateAndTimeRanges == null))
                    {
                        cachedSelectTheValuesToShowBasedUponDateAndTimeRanges = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheValuesToShowBasedUponDateAndTimeRanges);
                    }
                    
                    return cachedSelectTheValuesToShowBasedUponDateAndTimeRanges;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithinTheTimeRange translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 08/11/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithinTheTimeRange
            {
                get
                {
                    if ((cachedWithinTheTimeRange == null))
                    {
                        cachedWithinTheTimeRange = CoreManager.MomConsole.GetIntlStr(ResourceWithinTheTimeRange);
                    }
                    
                    return cachedWithinTheTimeRange;
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
        /// 	[lucyra] 08/11/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ComboBox1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox1 = "comboDynamic";
            
            /// <summary>
            /// Control ID for TextBox2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TextBox2 = "textDynamic";
            
            /// <summary>
            /// Control ID for WithinTheLastRadioButton
            /// </summary>
            public const string WithinTheLastRadioButton = "radioDynamic";
            
            /// <summary>
            /// Control ID for EnterASemiColonDelimitedListOfNumbersComboBox
            /// </summary>
            public const string EnterASemiColonDelimitedListOfNumbersComboBox = "dateBefore";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for EnterASemiColonDelimitedListOfNumbersComboBox2
            /// </summary>
            public const string EnterASemiColonDelimitedListOfNumbersComboBox2 = "dateAfter";
            
            /// <summary>
            /// Control ID for BeforeCheckBox
            /// </summary>
            public const string BeforeCheckBox = "checkBefore";
            
            /// <summary>
            /// Control ID for AfterCheckBox
            /// </summary>
            public const string AfterCheckBox = "checkAfter";
            
            /// <summary>
            /// Control ID for SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl
            /// </summary>
            public const string SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl = "labelHeader";
            
            /// <summary>
            /// Control ID for WithinTheTimeRangeRadioButton
            /// </summary>
            public const string WithinTheTimeRangeRadioButton = "radioRange";
        }
        #endregion
    }
}
