// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertResolutionStateViewCriteria.cs">
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
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// DisplayOnlyAlertsWithResolutionState = 0
        /// </summary>
        DisplayOnlyAlertsWithResolutionState = 0,
        
        /// <summary>
        /// SelectResolutionStatesToSearchFor = 1
        /// </summary>
        SelectResolutionStatesToSearchFor = 1,
    }
    #endregion
    
    #region Interface Definition - IAlertResolutionStateViewCriteriaControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertResolutionStateViewCriteriaControls, for AlertResolutionStateViewCriteria.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 3/21/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertResolutionStateViewCriteriaControls
    {
        /// <summary>
        /// Read-only property to access ResolutionStatesToSearchForListBox
        /// </summary>
        ListBox ResolutionStatesToSearchForListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClearAllButton
        /// </summary>
        Button ClearAllButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAllButton
        /// </summary>
        Button SelectAllButton
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
        /// Read-only property to access OperatorCombo
        /// </summary>
        ComboBox OperatorCombo
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DisplayOnlyAlertsWithResolutionStateRadioButton
        /// </summary>
        RadioButton DisplayOnlyAlertsWithResolutionStateRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectResolutionStatesToSearchForRadioButton
        /// </summary>
        RadioButton SelectResolutionStatesToSearchForRadioButton
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
        /// Read-only property to access ResolutionStateNumericUpDown
        /// </summary>
        /// <history>
        /// [a-joelj]   28OCT09 Maui 2.0 Required Change: Changed all Control/Property references for 
        ///             ResolutionStateComboBox to ResolutionStateNumericUpDown and changed this control
        ///             from a ComboBox to a NumericUpDown.  
        ///             This approach worked in Maui 1.0 despite using this control incorrectly as a 
        ///             ComboBox, however, Maui 2.0 cannot use ComboBox /properties methods on a NumericUpDown 
        ///             control.  This control is actually a NumericUpDown in the Product.
        /// </history>
        NumericUpDown ResolutionStateNumericUpDown
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
    public class AlertResolutionStateViewCriteria : Dialog, IAlertResolutionStateViewCriteriaControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ResolutionStatesToSearchForListBox of type ListBox
        /// </summary>
        private ListBox cachedResolutionStatesToSearchForListBox;
        
        /// <summary>
        /// Cache to hold a reference to ClearAllButton of type Button
        /// </summary>
        private Button cachedClearAllButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectAllButton of type Button
        /// </summary>
        private Button cachedSelectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to OperatorCombo of type ComboBox
        /// </summary>
        private ComboBox cachedOperatorCombo;
        
        /// <summary>
        /// Cache to hold a reference to DisplayOnlyAlertsWithResolutionStateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDisplayOnlyAlertsWithResolutionStateRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectResolutionStatesToSearchForRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSelectResolutionStatesToSearchForRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ResolutionStateNumericUpDown of type ComboBox
        /// </summary>
        /// <history>
        ///     [a-joelj]   28OCT09 Maui 2.0: Changed from ComboBox to NumericUpDown control
        /// </history>
        private NumericUpDown cachedResolutionStateNumericUpDown;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertResolutionStateViewCriteria of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertResolutionStateViewCriteria(ConsoleApp app) : 
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
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.DisplayOnlyAlertsWithResolutionStateRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.DisplayOnlyAlertsWithResolutionState;
                }
                
                if ((this.Controls.SelectResolutionStatesToSearchForRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.SelectResolutionStatesToSearchFor;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.DisplayOnlyAlertsWithResolutionState))
                {
                    this.Controls.DisplayOnlyAlertsWithResolutionStateRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.SelectResolutionStatesToSearchFor))
                    {
                        this.Controls.SelectResolutionStatesToSearchForRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IAlertResolutionStateViewCriteria Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertResolutionStateViewCriteriaControls Controls
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
        ///  Routine to set/get the text in control OperatorCombo
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string OperatorComboText
        {
            get
            {
                return this.Controls.OperatorCombo.Text;
            }
            
            set
            {
                this.Controls.OperatorCombo.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ResolutionStateNumericUpDown
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        ///     [a-joelj]   28OCT09 Maui 2.0: Changed from ComboBox to NumericUpDown control and
        ///                                   modified how we set this property (won't work with
        ///                                   SelectByText method).
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ResolutionStateNumericUpDownText
        {
            get
            {
                return this.Controls.ResolutionStateNumericUpDown.TextBox.Text;
            }
            
            set
            {
                this.Controls.ResolutionStateNumericUpDown.TextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolutionStatesToSearchForListBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IAlertResolutionStateViewCriteriaControls.ResolutionStatesToSearchForListBox
        {
            get
            {
                if ((this.cachedResolutionStatesToSearchForListBox == null))
                {
                    this.cachedResolutionStatesToSearchForListBox = new ListBox(this, AlertResolutionStateViewCriteria.ControlIDs.ResolutionStatesToSearchForListBox);
                }
                
                return this.cachedResolutionStatesToSearchForListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearAllButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertResolutionStateViewCriteriaControls.ClearAllButton
        {
            get
            {
                if ((this.cachedClearAllButton == null))
                {
                    this.cachedClearAllButton = new Button(this, AlertResolutionStateViewCriteria.ControlIDs.ClearAllButton);
                }
                
                return this.cachedClearAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAllButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertResolutionStateViewCriteriaControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = new Button(this, AlertResolutionStateViewCriteria.ControlIDs.SelectAllButton);
                }
                
                return this.cachedSelectAllButton;
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
        Button IAlertResolutionStateViewCriteriaControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertResolutionStateViewCriteria.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OperatorCombo control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        ///     [a-joelj]   28OCT09 Maui 2.0: Modified to use QID in ComboBox constructor
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertResolutionStateViewCriteriaControls.OperatorCombo
        {
            get
            {
                if ((this.cachedOperatorCombo == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the ComboBox constructor using 'this' and the 
                    // ControlId instead of using a QID is returning the wrong ComboBox or no ComboBox at all. 
                    // Modified to use a QID in the UIA tree for matching with the ComboBox AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId='" + AlertResolutionStateViewCriteria.ControlIDs.OperatorCombo + "'");

                    this.cachedOperatorCombo = new ComboBox(this, queryId, Core.Common.Constants.DefaultContextMenuTimeout);
                }
                
                return this.cachedOperatorCombo;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayOnlyAlertsWithResolutionStateRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAlertResolutionStateViewCriteriaControls.DisplayOnlyAlertsWithResolutionStateRadioButton
        {
            get
            {
                if ((this.cachedDisplayOnlyAlertsWithResolutionStateRadioButton == null))
                {
                    this.cachedDisplayOnlyAlertsWithResolutionStateRadioButton = new RadioButton(this, AlertResolutionStateViewCriteria.ControlIDs.DisplayOnlyAlertsWithResolutionStateRadioButton);
                }
                
                return this.cachedDisplayOnlyAlertsWithResolutionStateRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectResolutionStatesToSearchForRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAlertResolutionStateViewCriteriaControls.SelectResolutionStatesToSearchForRadioButton
        {
            get
            {
                if ((this.cachedSelectResolutionStatesToSearchForRadioButton == null))
                {
                    this.cachedSelectResolutionStatesToSearchForRadioButton = new RadioButton(this, AlertResolutionStateViewCriteria.ControlIDs.SelectResolutionStatesToSearchForRadioButton);
                }
                
                return this.cachedSelectResolutionStatesToSearchForRadioButton;
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
        Button IAlertResolutionStateViewCriteriaControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertResolutionStateViewCriteria.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolutionStateNumericUpDown control
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        ///     [a-joelj]   28OCT09 Maui 2.0: Changed from ComboBox to NumericUpDown control
        /// </history>
        /// -----------------------------------------------------------------------------
        NumericUpDown IAlertResolutionStateViewCriteriaControls.ResolutionStateNumericUpDown
        {
            get
            {
                if ((this.cachedResolutionStateNumericUpDown == null))
                {
                    this.cachedResolutionStateNumericUpDown = new NumericUpDown(this, AlertResolutionStateViewCriteria.ControlIDs.ResolutionStateNumericUpDown);
                }
                
                return this.cachedResolutionStateNumericUpDown;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClearAll
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClearAll()
        {
            this.Controls.ClearAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectAll
        /// </summary>
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectAll()
        {
            this.Controls.SelectAllButton.Click();
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
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 3/21/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
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
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
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
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "AlertResolutionStateViewCriteriaDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "AlertResolutionStateViewCriteriaDialog:: Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw;
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
        ///     [a-joelj]9/27/2009 Added resource strings for Equals, Not Equals, Greater than, Less than, At least
        ///                        and At most
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
            private const string ResourceDialogTitle = ";Resolution State;ManagedString;Microsoft.MOM.UI.Components.dll;"+
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;ResolutionStateTitle";
            //;Resolution State;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource;ResolutionStateEditDialogTitle
            //;Resolution State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;ChangeResolutionState
            //;Resolution State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;ResolutionState
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ClearAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClearAll = ";&Clear All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;butt" +
                "onClearAll.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAll = ";&Select All;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;M" +
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;but" +
                "tonSelectAll.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DisplayOnlyAlertsWithResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDisplayOnlyAlertsWithResolutionState = ";&Display only alerts with Resolution State:;ManagedString;Microsoft.MOM.UI.Commo" +
                "n.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEdi" +
                "tDialog;radioOnly.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectResolutionStatesToSearchFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectResolutionStatesToSearchFor = ";Select &resolution states to search for:;ManagedString;Microsoft.MOM.UI.Common.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDi" +
                "alog;radioSelect.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Equals
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOperatorEquals = 
                ";Equals"+
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog" +
                ";comboOperator.Items";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Not Equals
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOperatorNotEquals = 
                ";Not Equals" +
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog" +
                ";comboOperator.Items1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Less Than
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOperatorLessThan = 
                ";Less Than" +
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog" +
                ";comboOperator.Items2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  At Most
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOperatorAtMost = 
                ";At Most" +
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog" +
                ";comboOperator.Items3";
 
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Greater Than
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOperatorGreaterThan = 
                ";Greater Than" +
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog" +
                ";comboOperator.Items4";
 
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  At Least
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOperatorAtLeast = 
                ";At Least" +
                ";ManagedString;Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.ResolutionStateEditDialog" +
                ";comboOperator.Items5";
            
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
            /// Caches the translated resource string for:  ClearAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClearAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAll
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAll;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DisplayOnlyAlertsWithResolutionState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisplayOnlyAlertsWithResolutionState;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectResolutionStatesToSearchFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectResolutionStatesToSearchFor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Equals
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOperatorEquals;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Not Equals
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOperatorNotEquals;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Less Than
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOperatorLessThan;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  At Most
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOperatorAtMost;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Greater Than
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOperatorGreaterThan;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  At Least
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOperatorAtLeast;

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
            /// Exposes access to the ClearAll translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClearAll
            {
                get
                {
                    if ((cachedClearAll == null))
                    {
                        cachedClearAll = CoreManager.MomConsole.GetIntlStr(ResourceClearAll);
                    }
                    
                    return cachedClearAll;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAll translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectAll
            {
                get
                {
                    if ((cachedSelectAll == null))
                    {
                        cachedSelectAll = CoreManager.MomConsole.GetIntlStr(ResourceSelectAll);
                    }
                    
                    return cachedSelectAll;
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
            /// Exposes access to the DisplayOnlyAlertsWithResolutionState translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayOnlyAlertsWithResolutionState
            {
                get
                {
                    if ((cachedDisplayOnlyAlertsWithResolutionState == null))
                    {
                        cachedDisplayOnlyAlertsWithResolutionState = CoreManager.MomConsole.GetIntlStr(ResourceDisplayOnlyAlertsWithResolutionState);
                    }
                    
                    return cachedDisplayOnlyAlertsWithResolutionState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectResolutionStatesToSearchFor translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 3/21/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectResolutionStatesToSearchFor
            {
                get
                {
                    if ((cachedSelectResolutionStatesToSearchFor == null))
                    {
                        cachedSelectResolutionStatesToSearchFor = CoreManager.MomConsole.GetIntlStr(ResourceSelectResolutionStatesToSearchFor);
                    }
                    
                    return cachedSelectResolutionStatesToSearchFor;
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
            /// Exposes access to the Equals operator translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OperatorEquals
            {
                get
                {
                    if ((cachedOperatorEquals == null))
                    {
                        cachedOperatorEquals = CoreManager.MomConsole.GetIntlStr(ResourceOperatorEquals);
                    }

                    return cachedOperatorEquals;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Not Equals operator translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OperatorNotEquals
            {
                get
                {
                    if ((cachedOperatorNotEquals == null))
                    {
                        cachedOperatorNotEquals = CoreManager.MomConsole.GetIntlStr(ResourceOperatorNotEquals);
                    }

                    return cachedOperatorNotEquals;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Less Than operator translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OperatorLessThan
            {
                get
                {
                    if ((cachedOperatorLessThan == null))
                    {
                        cachedOperatorLessThan = CoreManager.MomConsole.GetIntlStr(ResourceOperatorLessThan);
                    }

                    return cachedOperatorLessThan;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the At Most operator translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OperatorAtMost
            {
                get
                {
                    if ((cachedOperatorAtMost == null))
                    {
                        cachedOperatorAtMost = CoreManager.MomConsole.GetIntlStr(ResourceOperatorAtMost);
                    }

                    return cachedOperatorAtMost;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Greater Than operator translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OperatorGreaterThan
            {
                get
                {
                    if ((cachedOperatorGreaterThan == null))
                    {
                        cachedOperatorGreaterThan = CoreManager.MomConsole.GetIntlStr(ResourceOperatorGreaterThan);
                    }

                    return cachedOperatorGreaterThan;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the At Least operator translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 9/27/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OperatorAtLeast
            {
                get
                {
                    if ((cachedOperatorAtLeast == null))
                    {
                        cachedOperatorAtLeast = CoreManager.MomConsole.GetIntlStr(ResourceOperatorAtLeast);
                    }

                    return cachedOperatorAtLeast;
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
            /// Control ID for ResolutionStatesToSearchForListBox
            /// </summary>
            public const string ResolutionStatesToSearchForListBox = "checkedList";
            
            /// <summary>
            /// Control ID for ClearAllButton
            /// </summary>
            public const string ClearAllButton = "buttonClearAll";
            
            /// <summary>
            /// Control ID for SelectAllButton
            /// </summary>
            public const string SelectAllButton = "buttonSelectAll";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";
            
            /// <summary>
            /// Control ID for OperatorCombo
            /// </summary>
            public const string OperatorCombo = "comboOperator";
            
            /// <summary>
            /// Control ID for DisplayOnlyAlertsWithResolutionStateRadioButton
            /// </summary>
            public const string DisplayOnlyAlertsWithResolutionStateRadioButton = "radioOnly";
            
            /// <summary>
            /// Control ID for SelectResolutionStatesToSearchForRadioButton
            /// </summary>
            public const string SelectResolutionStatesToSearchForRadioButton = "radioSelect";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for ResolutionStateNumericUpDown
            /// </summary>
            /// <history>
            ///     [a-joelj]   28OCT09 Maui 2.0: Changed from ComboBox to NumericUpDown control
            /// </history>
            public const string ResolutionStateNumericUpDown = "stateSpinner";
        }
        #endregion
    }
}
