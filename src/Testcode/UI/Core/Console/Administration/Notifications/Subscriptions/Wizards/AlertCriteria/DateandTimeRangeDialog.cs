// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DateandTimeRangeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor] 24-SEP-08 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions.Wizards.AlertCriteria
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - DateandTimeRangeOption

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group DateandTimeRangeOption
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum DateandTimeRangeOption
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
    
    #region Interface Definition - IDateandTimeRangeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDateandTimeRangeDialogControls, for DateandTimeRangeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDateandTimeRangeDialogControls
    {
        /// <summary>
        /// Read-only property to access WithinTheLastComboBox
        /// </summary>
        ComboBox WithinTheLastComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WithinTheLastTextBox
        /// </summary>
        TextBox WithinTheLastTextBox
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
        /// Read-only property to access BeforeDateComboBox
        /// </summary>
        ComboBox BeforeDateComboBox
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
        /// Read-only property to access AfterDateComboBox
        /// </summary>
        ComboBox AfterDateComboBox
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
    /// Class to encapsulate dialog functionality for the alert criteria date and 
    /// time range dialog.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 24-SEP-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DateandTimeRangeDialog : Dialog, IDateandTimeRangeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to WithinTheLastComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedWithinTheLastComboBox;
        
        /// <summary>
        /// Cache to hold a reference to WithinTheLastTextBox of type TextBox
        /// </summary>
        private TextBox cachedWithinTheLastTextBox;
        
        /// <summary>
        /// Cache to hold a reference to WithinTheLastRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWithinTheLastRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to BeforeDateComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedBeforeDateComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to AfterDateComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAfterDateComboBox;
        
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
        /// Default constructor.
        /// </summary>
        /// <param name="dialogTitle">Title string for the dialog window.</param>
        /// <param name='app'>
        /// Owner of DateandTimeRangeDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DateandTimeRangeDialog(
            string dialogTitle,
            MomConsoleApp app) : 
                base(app, Init(dialogTitle, app))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group DateandTimeRangeOption
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual DateandTimeRangeOption DateandTimeRangeOption
        {
            get
            {
                if ((this.Controls.WithinTheLastRadioButton.ButtonState == ButtonState.Checked))
                {
                    return DateandTimeRangeOption.WithinTheLast;
                }
                
                if ((this.Controls.WithinTheTimeRangeRadioButton.ButtonState == ButtonState.Checked))
                {
                    return DateandTimeRangeOption.WithinTheTimeRange;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == DateandTimeRangeOption.WithinTheLast))
                {
                    this.Controls.WithinTheLastRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == DateandTimeRangeOption.WithinTheTimeRange))
                    {
                        this.Controls.WithinTheTimeRangeRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IDateandTimeRangeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDateandTimeRangeDialogControls Controls
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        ///  Routine to set/get the text in control SelectTheValuesToShowBasedUponDateAndTimeRanges
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WithinTheLastComboBoxText
        {
            get
            {
                return this.Controls.WithinTheLastComboBox.Text;
            }
            
            set
            {
                this.Controls.WithinTheLastComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SelectTheValuesToShowBasedUponDateAndTimeRanges2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WithinTheLastTextBoxText
        {
            get
            {
                return this.Controls.WithinTheLastTextBox.Text;
            }
            
            set
            {
                this.Controls.WithinTheLastTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SelectTheValuesToShowBasedUponDateAndTimeRanges3
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string BeforeDateComboBoxText
        {
            get
            {
                return this.Controls.BeforeDateComboBox.Text;
            }
            
            set
            {
                this.Controls.BeforeDateComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SelectTheValuesToShowBasedUponDateAndTimeRanges4
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AfterDateComboBoxText
        {
            get
            {
                return this.Controls.AfterDateComboBox.Text;
            }
            
            set
            {
                this.Controls.AfterDateComboBox.SelectByText(value, true);
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithinTheLastComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDateandTimeRangeDialogControls.WithinTheLastComboBox
        {
            get
            {
                if ((this.cachedWithinTheLastComboBox == null))
                {
                    this.cachedWithinTheLastComboBox = new ComboBox(this, DateandTimeRangeDialog.ControlIDs.WithinTheLastComboBox);
                }
                
                return this.cachedWithinTheLastComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithinTheLastTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDateandTimeRangeDialogControls.WithinTheLastTextBox
        {
            get
            {
                if ((this.cachedWithinTheLastTextBox == null))
                {
                    this.cachedWithinTheLastTextBox = new TextBox(this, DateandTimeRangeDialog.ControlIDs.WithinTheLastTextBox);
                }
                
                return this.cachedWithinTheLastTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithinTheLastRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IDateandTimeRangeDialogControls.WithinTheLastRadioButton
        {
            get
            {
                if ((this.cachedWithinTheLastRadioButton == null))
                {
                    this.cachedWithinTheLastRadioButton = new RadioButton(this, DateandTimeRangeDialog.ControlIDs.WithinTheLastRadioButton);
                }
                
                return this.cachedWithinTheLastRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BeforeDateComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDateandTimeRangeDialogControls.BeforeDateComboBox
        {
            get
            {
                if ((this.cachedBeforeDateComboBox == null))
                {
                    this.cachedBeforeDateComboBox = new ComboBox(this, DateandTimeRangeDialog.ControlIDs.BeforeDateComboBox);
                }
                
                return this.cachedBeforeDateComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDateandTimeRangeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DateandTimeRangeDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDateandTimeRangeDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, DateandTimeRangeDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AfterDateComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDateandTimeRangeDialogControls.AfterDateComboBox
        {
            get
            {
                if ((this.cachedAfterDateComboBox == null))
                {
                    this.cachedAfterDateComboBox = new ComboBox(this, DateandTimeRangeDialog.ControlIDs.AfterDateComboBox);
                }
                
                return this.cachedAfterDateComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BeforeCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IDateandTimeRangeDialogControls.BeforeCheckBox
        {
            get
            {
                if ((this.cachedBeforeCheckBox == null))
                {
                    this.cachedBeforeCheckBox = new CheckBox(this, DateandTimeRangeDialog.ControlIDs.BeforeCheckBox);
                }
                
                return this.cachedBeforeCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AfterCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IDateandTimeRangeDialogControls.AfterCheckBox
        {
            get
            {
                if ((this.cachedAfterCheckBox == null))
                {
                    this.cachedAfterCheckBox = new CheckBox(this, DateandTimeRangeDialog.ControlIDs.AfterCheckBox);
                }
                
                return this.cachedAfterCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDateandTimeRangeDialogControls.SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl
        {
            get
            {
                if ((this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl == null))
                {
                    this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl = new StaticControl(this, DateandTimeRangeDialog.ControlIDs.SelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl);
                }
                
                return this.cachedSelectTheValuesToShowBasedUponDateAndTimeRangesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WithinTheTimeRangeRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IDateandTimeRangeDialogControls.WithinTheTimeRangeRadioButton
        {
            get
            {
                if ((this.cachedWithinTheTimeRangeRadioButton == null))
                {
                    this.cachedWithinTheTimeRangeRadioButton = new RadioButton(this, DateandTimeRangeDialog.ControlIDs.WithinTheTimeRangeRadioButton);
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
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
        /// <param name="dialogTitle">Title string for the dialog window.</param>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(
            string dialogTitle, 
            MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        dialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
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
                for (int numberOfTries = 0; 
                    ((null == tempWindow) && (numberOfTries < maxTries)); 
                    numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = 
                            new Window(
                                dialogTitle, 
                                StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow, 
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries +
                            "...");

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find the window with title := '" +
                        dialogTitle);

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-SEP-08 Created
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
            private const string ResourceDateAndTimeGeneratedDialogTitle = 
                ";Date and Time Generated" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";TimeCreatedEditTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLastModifiedTimeDialogTitle =
                ";Last Modified Time" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";LastModifiedTimeTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResolutionStateLastModifiedDialogTitle =
                ";Resolution State Last Modified" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";ResolutionStateLastModifiedTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeResolvedDialogTitle =
                ";Time Resolved" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";TimeResolvedTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeAddedDialogTitle =
                ";Time Added" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource" +
                ";TimeAddedTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithinTheLast
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWithinTheLast =
                ";Within the &last:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.TimeRangeEditDialog" +
                ";radioDynamic.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase" +
                ";buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK =
                ";OK" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.EditDialogBase" +
                ";buttonOK.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Before
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBefore =
                ";&Before" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.TimeRangeEditDialog" +
                ";checkBefore.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  After
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAfter =
                ";&After" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.TimeRangeEditDialog" +
                ";checkAfter.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheValuesToShowBasedUponDateAndTimeRanges
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheValuesToShowBasedUponDateAndTimeRanges =
                ";Select the values to show based upon date and time ranges:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.TimeRangeEditDialog" +
                ";labelHeader.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WithinTheTimeRange
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWithinTheTimeRange =
                ";&Within the time range:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.TimeRangeEditDialog" +
                ";radioRange.Text";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the DateAndTimeGenerated window or dialog 
            /// title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDateAndTimeGeneratedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the LastModifiedTimeDialogTitle window or 
            /// dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLastModifiedTimeDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the ResolutionStateLastModifiedDialogTitle 
            /// window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolutionStateLastModifiedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the TimeResolvedDialogTitle window or dialog 
            /// title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeResolvedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the TimeAddedDialogTitle  window or dialog 
            /// title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeAddedDialogTitle;
            
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
            /// Exposes access to the DateAndTimeGeneratedDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DateAndTimeGeneratedDialogTitle
            {
                get
                {
                    if ((cachedDateAndTimeGeneratedDialogTitle == null))
                    {
                        cachedDateAndTimeGeneratedDialogTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDateAndTimeGeneratedDialogTitle);
                    }

                    return cachedDateAndTimeGeneratedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LastModifiedTimeDialogTitle  translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LastModifiedTimeDialogTitle 
            {
                get
                {
                    if ((cachedLastModifiedTimeDialogTitle == null))
                    {
                        cachedLastModifiedTimeDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceLastModifiedTimeDialogTitle);
                    }

                    return cachedLastModifiedTimeDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResolutionStateLastModifiedDialogTitle  translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResolutionStateLastModifiedDialogTitle 
            {
                get
                {
                    if ((cachedResolutionStateLastModifiedDialogTitle == null))
                    {
                        cachedResolutionStateLastModifiedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceResolutionStateLastModifiedDialogTitle);
                    }

                    return cachedResolutionStateLastModifiedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TimeResolvedDialogTitle  translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeResolvedDialogTitle 
            {
                get
                {
                    if ((cachedTimeResolvedDialogTitle == null))
                    {
                        cachedTimeResolvedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceTimeResolvedDialogTitle);
                    }

                    return cachedTimeResolvedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TimeAddedDialogTitle  translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeAddedDialogTitle 
            {
                get
                {
                    if ((cachedTimeAddedDialogTitle == null))
                    {
                        cachedTimeAddedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceTimeAddedDialogTitle);
                    }

                    return cachedTimeAddedDialogTitle;
                }
            }
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WithinTheLast translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// 	[KellyMor] 24-SEP-08 Created
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
            /// 	[KellyMor] 24-SEP-08 Created
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
        /// 	[KellyMor] 24-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for WithinTheLastComboBox
            /// </summary>
            public const string WithinTheLastComboBox = "comboDynamic";
            
            /// <summary>
            /// Control ID for WithinTheLastTextBox
            /// </summary>
            public const string WithinTheLastTextBox = "textDynamic";
            
            /// <summary>
            /// Control ID for WithinTheLastRadioButton
            /// </summary>
            public const string WithinTheLastRadioButton = "radioDynamic";
            
            /// <summary>
            /// Control ID for BeforeDateComboBox
            /// </summary>
            public const string BeforeDateComboBox = "dateBefore";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for AfterDateComboBox
            /// </summary>
            public const string AfterDateComboBox = "dateAfter";
            
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
