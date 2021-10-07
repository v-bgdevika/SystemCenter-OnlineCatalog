// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceReportSelectruleDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[starrpar] 1/26/2009 Created
//  [v-liqluo] 3/8/2010  Edited, change interface and class name for better code reuse.
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - ISelectRuleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceReportSelectruleDialogControls, for PerformanceReportSelectruleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[starrpar] 1/26/2009 Created
    /// 	[v-liqluo] 3/8/2010  Edited, change interface name from 
    /// 	           IPerformanceReportSelectruleDialogControls to ISelectRuleDialogControls
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectRuleDialogControls
    {
        /// <summary>
        /// Read-only property to access TabSelectControl
        /// </summary>
        TabControl TabSelectControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackDropdownLabel
        /// </summary>
        StaticControl ManagementPackDropdownLabel
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackDropdownComboBox
        /// </summary>
        EditComboBox ManagementPackDropdownComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackNameTextBox
        /// </summary>
        TextBox ManagementPackNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RuleNameLabel
        /// </summary>
        StaticControl RuleNameLabel
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PatternComboBox
        /// </summary>
        ComboBox PatternComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TextMatchTextBox
        /// </summary>
        TextBox TextMatchTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CounterLabel
        /// </summary>
        StaticControl CounterLabel
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CounterComboBox
        /// </summary>
        ComboBox CounterComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PerformanceObjectLabel
        /// </summary>
        StaticControl PerformanceObjectLabel
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PerformanceObjectComboBox
        /// </summary>
        ComboBox PerformanceObjectComboBox
        {
            get;
        }
                
        /// <summary>
        /// Read-only property to access OptionsButton
        /// </summary>
        Button OptionsButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchButton
        /// </summary>
        Button SearchButton
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
        /// Read-only property to access AvailableItemsListView
        /// </summary>
        ListView AvailableItemsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableItemsLabel
        /// </summary>
        StaticControl AvailableItemsLabel
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[starrpar] 1/26/2009 Created
    /// 	[v-liqluo] 3/8/2010 Edit, change Class name from 
    /// 	           PerformanceReportSelectruleDialog to SelectRuleDialog
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectRuleDialog : Dialog, ISelectRuleDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TabSelectControl of type TabControl
        /// </summary>
        private TabControl cachedTabSelectControl;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackDropdownLabel of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackDropdownLabel;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackDropdownComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedManagementPackDropdownComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedManagementPackNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to RuleNameLabel of type StaticControl
        /// </summary>
        private StaticControl cachedRuleNameLabel;
        
        /// <summary>
        /// Cache to hold a reference to PatternComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPatternComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TextMatchTextBox of type TextBox
        /// </summary>
        private TextBox cachedTextMatchTextBox;


        /// <summary>
        /// Cache to hold a reference to CounterLabel of type StaticControl
        /// </summary>
        private StaticControl cachedCounterLabel;

        /// <summary>
        /// Cache to hold a reference to CounterComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedCounterComboBox;

        /// <summary>
        /// Cache to hold a reference to PerformanceObjectLabel of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceObjectLabel;

        /// <summary>
        /// Cache to hold a reference to PerformanceObjectComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPerformanceObjectComboBox;
        
        /// <summary>
        /// Cache to hold a reference to OptionsButton of type Button
        /// </summary>
        private Button cachedOptionsButton;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsListView of type ListView
        /// </summary>
        private ListView cachedAvailableItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsLabel of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsLabel;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceReportSelectruleDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectRuleDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion

        #region ISelectRuleDialogControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectRuleDialogControls Controls
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
        ///  Routine to set/get the text in control ManagementPackName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementPackNameText
        {
            get
            {
                return this.Controls.ManagementPackDropdownComboBox.Text;
            }
            
            set
            {
                this.Controls.ManagementPackDropdownComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ManagementPackName2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementPackName2Text
        {
            get
            {
                return this.Controls.ManagementPackNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ManagementPackNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control List
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PatternText
        {
            get
            {
                return this.Controls.PatternComboBox.Text;
            }
            
            set
            {
                this.Controls.PatternComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control List2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TextMatchText
        {
            get
            {
                return this.Controls.TextMatchTextBox.Text;
            }
            
            set
            {
                this.Controls.TextMatchTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Counter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CounterText
        {
            get
            {
                return this.Controls.CounterComboBox.Text;
            }

            set
            {
                this.Controls.CounterComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PerformanceObject
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[starrpar] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PerformanceObjectText
        {
            get
            {
                return this.Controls.PerformanceObjectComboBox.Text;
            }

            set
            {
                this.Controls.PerformanceObjectComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TabSelectControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ISelectRuleDialogControls.TabSelectControl
        {
            get
            {
                if ((this.cachedTabSelectControl == null))
                {
                    this.cachedTabSelectControl = new TabControl(this, SelectRuleDialog.ControlIDs.TabSelectControl);
                }

                return this.cachedTabSelectControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackDropdownLabel control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectRuleDialogControls.ManagementPackDropdownLabel
        {
            get
            {
                if ((this.cachedManagementPackDropdownLabel == null))
                {
                    this.cachedManagementPackDropdownLabel = new StaticControl(this, SelectRuleDialog.ControlIDs.ManagementPackDropdownLabel);
                }

                return this.cachedManagementPackDropdownLabel;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackDropdownComboBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox ISelectRuleDialogControls.ManagementPackDropdownComboBox
        {
            get
            {
                if ((this.cachedManagementPackDropdownComboBox == null))
                {
                    this.cachedManagementPackDropdownComboBox = new EditComboBox(this, SelectRuleDialog.ControlIDs.ManagementPackDropdownComboBox);
                }

                return this.cachedManagementPackDropdownComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackNameTextBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectRuleDialogControls.ManagementPackNameTextBox
        {
            get
            {
                if ((this.cachedManagementPackNameTextBox == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedManagementPackNameTextBox = new TextBox(wndTemp);
                }
                
                return this.cachedManagementPackNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleNameLabel control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectRuleDialogControls.RuleNameLabel
        {
            get
            {
                if ((this.cachedRuleNameLabel == null))
                {
                    this.cachedRuleNameLabel = new StaticControl(this, SelectRuleDialog.ControlIDs.RuleNameLabel);
                }

                return this.cachedRuleNameLabel;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PatternComboBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectRuleDialogControls.PatternComboBox
        {
            get
            {
                if ((this.cachedPatternComboBox == null))
                {
                    this.cachedPatternComboBox = new ComboBox(this, SelectRuleDialog.ControlIDs.PatternComboBox);
                }

                return this.cachedPatternComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TextMatchTextBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectRuleDialogControls.TextMatchTextBox
        {
            get
            {
                if ((this.cachedTextMatchTextBox == null))
                {
                    this.cachedTextMatchTextBox = new TextBox(this, SelectRuleDialog.ControlIDs.TextMatchTextBox);
                }

                return this.cachedTextMatchTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CounterLabel control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectRuleDialogControls.CounterLabel
        {
            get
            {
                if ((this.cachedCounterLabel == null))
                {
                    this.cachedCounterLabel = new StaticControl(this, SelectRuleDialog.ControlIDs.CounterLabel);
                }

                return this.cachedCounterLabel;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CounterComboBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectRuleDialogControls.CounterComboBox
        {
            get
            {
                if ((this.cachedCounterComboBox == null))
                {
                    this.cachedCounterComboBox = new ComboBox(this, SelectRuleDialog.ControlIDs.CounterComboBox);
                }

                return this.cachedCounterComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceObjectLabel control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectRuleDialogControls.PerformanceObjectLabel
        {
            get
            {
                if ((this.cachedPerformanceObjectLabel == null))
                {
                    this.cachedPerformanceObjectLabel = new StaticControl(this, SelectRuleDialog.ControlIDs.PerformanceObjectLabel);
                }

                return this.cachedPerformanceObjectLabel;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceObjectComboBox control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/30/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectRuleDialogControls.PerformanceObjectComboBox
        {
            get
            {
                if ((this.cachedPerformanceObjectComboBox == null))
                {
                    this.cachedPerformanceObjectComboBox = new ComboBox(this, SelectRuleDialog.ControlIDs.PerformanceObjectComboBox);
                }

                return this.cachedPerformanceObjectComboBox;
            }
        }
                
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptionsButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectRuleDialogControls.OptionsButton
        {
            get
            {
                if ((this.cachedOptionsButton == null))
                {
                    this.cachedOptionsButton = new Button(this, SelectRuleDialog.ControlIDs.OptionsButton);
                }
                
                return this.cachedOptionsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectRuleDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, SelectRuleDialog.ControlIDs.SearchButton);
                }
                
                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectRuleDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectRuleDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ColorListView control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectRuleDialogControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + SelectRuleDialog.ControlIDs.AvailableItemsListView + "'"));
                }

                return this.cachedAvailableItemsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectRuleDialogControls.AvailableItemsLabel
        {
            get
            {
                if ((this.cachedAvailableItemsLabel == null))
                {
                    this.cachedAvailableItemsLabel = new StaticControl(this, SelectRuleDialog.ControlIDs.AvailableItemsLabel);
                }

                return this.cachedAvailableItemsLabel;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectRuleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectRuleDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Options
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOptions()
        {
            this.Controls.OptionsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
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
        /// 	[starrpar] 1/26/2009 Created
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
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
        /// 	[starrpar] 1/26/2009 Created
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
            private const string ResourceDialogTitle = ";Select rule;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringPerformanceRulePickerDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Counter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCounter = ";&Counter:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.PerformanceMapperPage;lblCoun" +
                "ter.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceObject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceObject = ";&Performance object:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.d" +
                "ll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls." +
                "Monitoring.ReportMonitoringPerformanceRuleSearchCriteria;objectLabel.Text";
                        
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPackName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPackName = ";&Management pack name:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Control" +
                "s.Monitoring.ReportMonitoringPerformanceRuleSearchCriteria;MPLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleName = ";&Rule name:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitorin" +
                "g.ReportMonitoringPerformanceRuleSearchCriteria;nameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Options
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOptions = ";O&ptions >>;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitorin" +
                "g.ReportMonitoringObjectPickerResources;SearchButton_OptionsOpened";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";&Search;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Di" +
                "alogs.MPCatalogDialog;searchButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems = ";Available items;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Controls.SimpleChooserDialog;mainChooserControl.Caption" +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CounterName column name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCounterColumnName = ";Counter;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportPerformanceObjectPickerResources;SearchColumn_CounterName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MP column name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPackColumnName = ";Management Pack;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportPerformanceObjectPickerResources;SearchColumn_ManagementPackName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleName column name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleNameColumnName = ";Name;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportPerformanceObjectPickerResources;SearchColumn_RuleName";

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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Counter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCounter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PerformanceObject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceObject;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPackName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPackName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RuleName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Options
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOptions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAvailableItems;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Counter column name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCounterColumnName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack column name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPackColumnName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RuleName column name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleNameColumnName;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }

                    return cachedTab1;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Counter translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Counter
            {
                get
                {
                    if ((cachedCounter == null))
                    {
                        cachedCounter = CoreManager.MomConsole.GetIntlStr(ResourceCounter);
                    }

                    return cachedCounter;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PerformanceObject translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceObject
            {
                get
                {
                    if ((cachedPerformanceObject == null))
                    {
                        cachedPerformanceObject = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceObject);
                    }

                    return cachedPerformanceObject;
                }
            }
                        
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPackName translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPackName
            {
                get
                {
                    if ((cachedManagementPackName == null))
                    {
                        cachedManagementPackName = CoreManager.MomConsole.GetIntlStr(ResourceManagementPackName);
                    }
                    
                    return cachedManagementPackName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RuleName translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleName
            {
                get
                {
                    if ((cachedRuleName == null))
                    {
                        cachedRuleName = CoreManager.MomConsole.GetIntlStr(ResourceRuleName);
                    }
                    
                    return cachedRuleName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Options translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Options
            {
                get
                {
                    if ((cachedOptions == null))
                    {
                        cachedOptions = CoreManager.MomConsole.GetIntlStr(ResourceOptions);
                    }
                    
                    return cachedOptions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Search
            {
                get
                {
                    if ((cachedSearch == null))
                    {
                        cachedSearch = CoreManager.MomConsole.GetIntlStr(ResourceSearch);
                    }
                    
                    return cachedSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
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
            /// Exposes access to the AvailableItems translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AvailableItems
            {
                get
                {
                    if ((cachedAvailableItems == null))
                    {
                        cachedAvailableItems = CoreManager.MomConsole.GetIntlStr(ResourceAvailableItems);
                    }
                    
                    return cachedAvailableItems;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/26/2009 Created
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
            /// Exposes access to the Counter Column Name translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CounterColumnName
            {
                get
                {
                    if ((cachedCounterColumnName == null))
                    {
                        cachedCounterColumnName = CoreManager.MomConsole.GetIntlStr(ResourceCounterColumnName);
                    }

                    return cachedCounterColumnName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack Column Name translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPackColumnName
            {
                get
                {
                    if ((cachedManagementPackColumnName == null))
                    {
                        cachedManagementPackColumnName = CoreManager.MomConsole.GetIntlStr(ResourceManagementPackColumnName);
                    }

                    return cachedManagementPackColumnName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RuleName Column Name translated resource string
            /// </summary>
            /// <history>
            /// 	[starrpar] 1/30/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleNameColumnName
            {
                get
                {
                    if ((cachedRuleNameColumnName == null))
                    {
                        cachedRuleNameColumnName = CoreManager.MomConsole.GetIntlStr(ResourceRuleNameColumnName);
                    }

                    return cachedRuleNameColumnName;
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
        /// 	[starrpar] 1/26/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for TabSelectControl
            /// </summary>
            public const string TabSelectControl = "searchTypeSelector";
            
            /// <summary>
            /// Control ID for ManagementPackDropdownLabel
            /// </summary>
            public const string ManagementPackDropdownLabel = "MPLabel";
            
            /// <summary>
            /// Control ID for ManagementPackDropdownComboBox
            /// </summary>
            public const string ManagementPackDropdownComboBox = "MPDropDown";
            
            /// <summary>
            /// Control ID for RuleNameLabel
            /// </summary>
            public const string RuleNameLabel = "nameLabel";
            
            /// <summary>
            /// Control ID for PatternComboBox
            /// </summary>
            public const string PatternComboBox = "patternComboBox";
            
            /// <summary>
            /// Control ID for TextMatchTextBox
            /// </summary>
            public const string TextMatchTextBox = "nameEditor";

            /// <summary>
            /// Control ID for CounterLabel
            /// </summary>
            public const string CounterLabel = "label2";

            /// <summary>
            /// Control ID for CounterComboBox
            /// </summary>
            public const string CounterComboBox = "counterComboBox";

            /// <summary>
            /// Control ID for PerformanceObjectLabel
            /// </summary>
            public const string PerformanceObjectLabel = "objectLabel";

            /// <summary>
            /// Control ID for PerformanceObjectComboBox
            /// </summary>
            public const string PerformanceObjectComboBox = "objectComboBox";

            /// <summary>
            /// Control ID for OptionsButton
            /// </summary>
            public const string OptionsButton = "optionsButton";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOK";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for AvailableItemsListView
            /// </summary>
            public const string AvailableItemsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AvailableItemsLabel
            /// </summary>
            public const string AvailableItemsLabel = "availableItemsLabel";
        }
        #endregion
    }
}
