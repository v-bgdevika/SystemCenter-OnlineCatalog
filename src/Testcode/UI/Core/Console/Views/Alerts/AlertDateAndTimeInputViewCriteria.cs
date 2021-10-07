// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertDateAndTimeInputViewCriteria.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 3/21/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - WithinRadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group WithinRadioGroup
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum WithinRadioGroup
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
    
    #region Interface Definition - IAlertDateAndTimeInputViewCriteriaControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertDateAndTimeInputViewCriteriaControls, for AlertDateAndTimeInputViewCriteria.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertDateAndTimeInputViewCriteriaControls
    {
        /// <summary>
        /// Read-only property to access ComboBoxTimeUnit
        /// </summary>
        EditComboBox ComboBoxTimeUnit
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextBox10
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox TextBox10
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NumberTextBox
        /// </summary>
        TextBox NumberTextBox
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
        /// Read-only property to access DateBefore
        /// </summary>
        ComboBox DateBefore
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
        /// Read-only property to access DateAfter
        /// </summary>
        ComboBox DateAfter
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
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertDateAndTimeInputViewCriteria : Dialog, IAlertDateAndTimeInputViewCriteriaControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ComboBoxTimeUnit of type EditComboBox
        /// </summary>
        private EditComboBox cachedComboBoxTimeUnit;
        
        /// <summary>
        /// Cache to hold a reference to TextBox10 of type TextBox
        /// </summary>
        private TextBox cachedTextBox10;
        
        /// <summary>
        /// Cache to hold a reference to NumberTextBox of type TextBox
        /// </summary>
        private TextBox cachedNumberTextBox;
        
        /// <summary>
        /// Cache to hold a reference to WithinTheLastRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWithinTheLastRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DateBefore of type ComboBox
        /// </summary>
        private ComboBox cachedDateBefore;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to DateAfter of type ComboBox
        /// </summary>
        private ComboBox cachedDateAfter;
        
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
        /// This is a constructor for multiple date and time input radio buttons selection dialogs.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertDateAndTimeInputViewCriteria of type App
        /// </param>
        /// <param name="windowCaption">Properties dialog title.</param>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertDateAndTimeInputViewCriteria(Mom.Test.UI.Core.Console.MomConsoleApp app, Views.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, UI.Core.Common.Constants.DefaultDialogTimeout);
        }

        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group WithinRadioGroup
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual WithinRadioGroup WithinRadioGroup
        {
            get
            {
                if ((this.Controls.WithinTheLastRadioButton.ButtonState == ButtonState.Checked))
                {
                    return WithinRadioGroup.WithinTheLast;
                }
                
                if ((this.Controls.WithinTheTimeRangeRadioButton.ButtonState == ButtonState.Checked))
                {
                    return WithinRadioGroup.WithinTheTimeRange;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == WithinRadioGroup.WithinTheLast))
                {
                    this.Controls.WithinTheLastRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == WithinRadioGroup.WithinTheTimeRange))
                    {
                        this.Controls.WithinTheTimeRangeRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IAlertDateAndTimeInputViewCriteria Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertDateAndTimeInputViewCriteriaControls Controls
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
        /// 	[lucyra] 3/21/2007 Created
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
        /// 	[lucyra] 3/21/2007 Created
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
        ///  Routine to set/get the text in control ComboBoxTimeUnit
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBoxTimeUnitText
        {
            get
            {
                return this.Controls.ComboBoxTimeUnit.Text;
            }
            
            set
            {
                this.Controls.ComboBoxTimeUnit.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TextBox10
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextBox10Text
        {
            get
            {
                return this.Controls.TextBox10.Text;
            }
            
            set
            {
                this.Controls.TextBox10.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NumberTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NumberTextBoxText
        {
            get
            {
                return this.Controls.NumberTextBox.Text;
            }
            
            set
            {
                this.Controls.NumberTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText
        {
            get
            {
                return this.Controls.DateBefore.Text;
            }
            
            set
            {
                this.Controls.DateBefore.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAccepted2Text
        {
            get
            {
                return this.Controls.DateAfter.Text;
            }
            
            set
            {
                this.Controls.DateAfter.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBoxTimeUnit control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IAlertDateAndTimeInputViewCriteriaControls.ComboBoxTimeUnit
        {
            get
            {
                if ((this.cachedComboBoxTimeUnit == null))
                {
                    this.cachedComboBoxTimeUnit = new EditComboBox(this, AlertDateAndTimeInputViewCriteria.ControlIDs.ComboBoxTimeUnit);
                }
                
                return this.cachedComboBoxTimeUnit;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextBox10 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertDateAndTimeInputViewCriteriaControls.TextBox10
        {
            get
            {
                if ((this.cachedTextBox10 == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTextBox10 = new TextBox(wndTemp);
                }
                
                return this.cachedTextBox10;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumberTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAlertDateAndTimeInputViewCriteriaControls.NumberTextBox
        {
            get
            {
                if ((this.cachedNumberTextBox == null))
                {
                    this.cachedNumberTextBox = new TextBox(this, AlertDateAndTimeInputViewCriteria.ControlIDs.NumberTextBox);
                }
                
                return this.cachedNumberTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithinTheLastRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAlertDateAndTimeInputViewCriteriaControls.WithinTheLastRadioButton
        {
            get
            {
                if ((this.cachedWithinTheLastRadioButton == null))
                {
                    this.cachedWithinTheLastRadioButton = new RadioButton(this, AlertDateAndTimeInputViewCriteria.ControlIDs.WithinTheLastRadioButton);
                }
                
                return this.cachedWithinTheLastRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DateBefore control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertDateAndTimeInputViewCriteriaControls.DateBefore
        {
            get
            {
                if ((this.cachedDateBefore == null))
                {
                    this.cachedDateBefore = new ComboBox(this, AlertDateAndTimeInputViewCriteria.ControlIDs.DateBefore);
                }
                
                return this.cachedDateBefore;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertDateAndTimeInputViewCriteriaControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertDateAndTimeInputViewCriteria.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertDateAndTimeInputViewCriteriaControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertDateAndTimeInputViewCriteria.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DateAfter control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertDateAndTimeInputViewCriteriaControls.DateAfter
        {
            get
            {
                if ((this.cachedDateAfter == null))
                {
                    this.cachedDateAfter = new ComboBox(this, AlertDateAndTimeInputViewCriteria.ControlIDs.DateAfter);
                }
                
                return this.cachedDateAfter;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BeforeCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAlertDateAndTimeInputViewCriteriaControls.BeforeCheckBox
        {
            get
            {
                if ((this.cachedBeforeCheckBox == null))
                {
                    this.cachedBeforeCheckBox = new CheckBox(this, AlertDateAndTimeInputViewCriteria.ControlIDs.BeforeCheckBox);
                }
                
                return this.cachedBeforeCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AfterCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAlertDateAndTimeInputViewCriteriaControls.AfterCheckBox
        {
            get
            {
                if ((this.cachedAfterCheckBox == null))
                {
                    this.cachedAfterCheckBox = new CheckBox(this, AlertDateAndTimeInputViewCriteria.ControlIDs.AfterCheckBox);
                }
                
                return this.cachedAfterCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertDateAndTimeInputViewCriteriaControls.SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl
        {
            get
            {
                if ((this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl == null))
                {
                    this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl = new StaticControl(this, AlertDateAndTimeInputViewCriteria.ControlIDs.SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl);
                }
                
                return this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithinTheTimeRangeRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAlertDateAndTimeInputViewCriteriaControls.WithinTheTimeRangeRadioButton
        {
            get
            {
                if ((this.cachedWithinTheTimeRangeRadioButton == null))
                {
                    this.cachedWithinTheTimeRangeRadioButton = new RadioButton(this, AlertDateAndTimeInputViewCriteria.ControlIDs.WithinTheTimeRangeRadioButton);
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
        /// 	[lucyra] 3/21/2007 Created
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
        /// 	[lucyra] 3/21/2007 Created
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
        /// 	[lucyra] 3/21/2007 Created
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
        /// 	[lucyra] 3/21/2007 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>
        ///  <param name="windowCaption">Window Caption Dialog Title.</param>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, Views.WindowCaptions windowCaption)
        {
            string DialogTitle = Views.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;

            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog,
                    StringMatchSyntax.ExactMatch,
                    app.MainWindow,
                    Timeout);

            }

            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);

                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "AlertTextInputViewCriteriaDialog:: Attempt " +
                            numberOfTries +
                            " of " +
                            MaxTries);

                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertTextInputViewCriteriaDialog:: " +
                        "Failed to find window with title:  '" +
                        DialogTitle +
                        "'");

                    // throw the existing WindowNotFound exception
                    throw ex;

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
        /// 	[lucyra] 3/21/2007 Created
        ///     [a-joelj] 19MAR09 Added resources for Seconds, Minutes, Hours and Days
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
            private const string ResourceDialogTitle = "Date and Time Generated";
            
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Days Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDaysTimerUnit =
                ";Days;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.SchedulerResources;TimeUnitDays";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Hours Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHoursTimerUnit =
                ";Hours;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.SchedulerResources;TimeUnitHours";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Minutes Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinutesTimerUnit =
                ";Minutes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.SchedulerResources;TimeUnitMinutes";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Seconds Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSecondsTimerUnit =
                ";Seconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.SchedulerResources;TimeUnitSeconds";

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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Days Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDaysTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Hours Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHoursTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Minutes Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinutesTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Seconds Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSecondsTimerUnit;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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
            /// 	[lucyra] 3/21/2007 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Days translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 19MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DaysTimerUnit
            {
                get
                {
                    if ((cachedDaysTimerUnit == null))
                    {
                        cachedDaysTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceDaysTimerUnit);
                    }
                    return cachedDaysTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Hours translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 19MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HoursTimerUnit
            {
                get
                {
                    if ((cachedHoursTimerUnit == null))
                    {
                        cachedHoursTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceHoursTimerUnit);
                    }
                    return cachedHoursTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Minutes translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 19MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MinutesTimerUnit
            {
                get
                {
                    if ((cachedMinutesTimerUnit == null))
                    {
                        cachedMinutesTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceMinutesTimerUnit);
                    }
                    return cachedMinutesTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Seconds translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 19MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SecondsTimerUnit
            {
                get
                {
                    if ((cachedSecondsTimerUnit == null))
                    {
                        cachedSecondsTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceSecondsTimerUnit);
                    }
                    return cachedSecondsTimerUnit;
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
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ComboBoxTimeUnit
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBoxTimeUnit = "comboDynamic";
            
            /// <summary>
            /// Control ID for NumberTextBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string NumberTextBox = "textDynamic";
            
            /// <summary>
            /// Control ID for WithinTheLastRadioButton
            /// </summary>
            public const string WithinTheLastRadioButton = "radioDynamic";
            
            /// <summary>
            /// Control ID for DateBefore
            /// </summary>
            public const string DateBefore = "dateBefore";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for DateAfter
            /// </summary>
            public const string DateAfter = "dateAfter";
            
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
