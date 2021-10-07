// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ScopeMPObjectsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 Test UI Automation
// </project>
// <summary>
// 	MOMv3 Test UI Automation
// </summary>
// <history>
// 	[ruhim] 7/21/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - RadioGroupTargets

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroupTargets
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroupTargets
    {
        /// <summary>
        /// ViewAllTargets = 0
        /// </summary>
        ViewAllTargets = 0,
        
        /// <summary>
        /// ViewCommonTargets = 1
        /// </summary>
        ViewCommonTargets = 1,
    }
    #endregion
    
    #region Interface Definition - IScopeMPObjectsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IScopeMPObjectsDialogControls, for ScopeMPObjectsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IScopeMPObjectsDialogControls
    {
        /// <summary>
        /// Read-only property to access ViewAllTargetsRadioButton
        /// </summary>
        RadioButton ViewAllTargetsRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewCommonTargetsRadioButton
        /// </summary>
        RadioButton ViewCommonTargetsRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClearButton
        /// </summary>
        Button ClearButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _117TotalTargets28Visible0SelectedStaticControl
        /// </summary>
        StaticControl _117TotalTargets28Visible0SelectedStaticControl
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
        /// Read-only property to access SearchTextBox
        /// </summary>
        TextBox SearchTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TypeListView
        /// </summary>
        ListView TypeListView
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
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
        /// </summary>
        StaticControl SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
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
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ScopeMPObjectsDialog : Dialog, IScopeMPObjectsDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ViewAllTargetsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedViewAllTargetsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ViewCommonTargetsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedViewCommonTargetsRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;
        
        /// <summary>
        /// Cache to hold a reference to _117TotalTargets28Visible0SelectedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_117TotalTargets28Visible0SelectedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClearAllButton of type Button
        /// </summary>
        private Button cachedClearAllButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectAllButton of type Button
        /// </summary>
        private Button cachedSelectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to SearchTextBox of type TextBox
        /// </summary>
        private TextBox cachedSearchTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TypeListView of type ListView
        /// </summary>
        private ListView cachedTypeListView;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT of type StaticControl
        /// </summary>
        private StaticControl cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ScopeMPObjectsDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ScopeMPObjectsDialog(MomConsoleApp app)
            : 
                base(app, Init(app))
        {
            Core.Common.Utilities.LogMessage("ScopeMPObjectsDialog:: Sucessfully found the dialog"); 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroupTargets
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroupTargets RadioGroupTargets
        {
            get
            {
                if ((this.Controls.ViewAllTargetsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTargets.ViewAllTargets;
                }
                
                if ((this.Controls.ViewCommonTargetsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTargets.ViewCommonTargets;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroupTargets.ViewAllTargets))
                {
                    this.Controls.ViewAllTargetsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroupTargets.ViewCommonTargets))
                    {
                        this.Controls.ViewCommonTargetsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IScopeMPObjectsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IScopeMPObjectsDialogControls Controls
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
        ///  Routine to set/get the text in control General
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GeneralText
        {
            get
            {
                return this.Controls.SearchTextBox.Text;
            }
            
            set
            {
                this.Controls.SearchTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewAllTargetsRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IScopeMPObjectsDialogControls.ViewAllTargetsRadioButton
        {
            get
            {
                if ((this.cachedViewAllTargetsRadioButton == null))
                {
                    this.cachedViewAllTargetsRadioButton = new RadioButton(this, ScopeMPObjectsDialog.ControlIDs.ViewAllTargetsRadioButton);
                }
                return this.cachedViewAllTargetsRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewCommonTargetsRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IScopeMPObjectsDialogControls.ViewCommonTargetsRadioButton
        {
            get
            {
                if ((this.cachedViewCommonTargetsRadioButton == null))
                {
                    this.cachedViewCommonTargetsRadioButton = new RadioButton(this, ScopeMPObjectsDialog.ControlIDs.ViewCommonTargetsRadioButton);
                }
                return this.cachedViewCommonTargetsRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScopeMPObjectsDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, ScopeMPObjectsDialog.ControlIDs.ClearButton);
                }
                return this.cachedClearButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _117TotalTargets28Visible0SelectedStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScopeMPObjectsDialogControls._117TotalTargets28Visible0SelectedStaticControl
        {
            get
            {
                if ((this.cached_117TotalTargets28Visible0SelectedStaticControl == null))
                {
                    this.cached_117TotalTargets28Visible0SelectedStaticControl = new StaticControl(this, ScopeMPObjectsDialog.ControlIDs._117TotalTargets28Visible0SelectedStaticControl);
                }
                return this.cached_117TotalTargets28Visible0SelectedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearAllButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScopeMPObjectsDialogControls.ClearAllButton
        {
            get
            {
                if ((this.cachedClearAllButton == null))
                {
                    this.cachedClearAllButton = new Button(this, ScopeMPObjectsDialog.ControlIDs.ClearAllButton);
                }
                return this.cachedClearAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAllButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScopeMPObjectsDialogControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = new Button(this, ScopeMPObjectsDialog.ControlIDs.SelectAllButton);
                }
                return this.cachedSelectAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IScopeMPObjectsDialogControls.SearchTextBox
        {
            get
            {
                if ((this.cachedSearchTextBox == null))
                {
                    this.cachedSearchTextBox = new TextBox(this, ScopeMPObjectsDialog.ControlIDs.SearchTextBox);
                }
                return this.cachedSearchTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScopeMPObjectsDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, ScopeMPObjectsDialog.ControlIDs.LookForStaticControl);
                }
                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        ///     [a-joelj]   28OCT09 Maui 2.0: Modified to use QID in ListView constructor
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IScopeMPObjectsDialogControls.TypeListView
        {
            get
            {
                if ((this.cachedTypeListView == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the ListView constructor using 'this' and the 
                    // ControlId instead of using a QID is returning the wrong ListView or no ListView at all. 
                    // Modified to use a QID in the UIA tree for matching with the ListView AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId='" + ScopeMPObjectsDialog.ControlIDs.TypeListView + "'");

                    this.cachedTypeListView = new ListView(this, queryId, Common.Constants.DefaultContextMenuTimeout);
                }
                return this.cachedTypeListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScopeMPObjectsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ScopeMPObjectsDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScopeMPObjectsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ScopeMPObjectsDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScopeMPObjectsDialogControls.SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
        {
            get
            {
                if ((this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT == null))
                {
                    this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = new StaticControl(this, ScopeMPObjectsDialog.ControlIDs.SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT);
                }
                return this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClearAll
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
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
        /// 	[ruhim] 7/21/2006 Created
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
        /// 	[ruhim] 7/21/2006 Created
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
        /// 	[ruhim] 7/21/2006 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog,
                    StringMatchSyntax.ExactMatch,
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
                                app.GetIntlStr(Strings.DialogTitle) + "*",
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
                            "BrowseForFolderDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "BrowseForFolderDialog:: Failed to find window with title:  '" +
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
        /// 	[ruhim] 7/21/2006 Created
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
                ";Scope Management Pack Objects;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewAllTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewAllTargets = ";View &all targets;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;allTargetsRBt" +
                "n.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewCommonTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewCommonTargets = ";View c&ommon targets;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;commonTarg" +
                "etsRBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClear = ";Cl&ear;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.AlertSuppressionForm;clearBtn.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _117TotalTargets28Visible0Selected
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_117TotalTargets28Visible0Selected = "117 total Targets, 28 visible, 0 selected";
            
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
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor = ";&Look for:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;look" +
                "ForLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = @";Select the target you want to use from the list below. You can also use the ""Look for:"" field below to filter down to a specific target or sort the targets by Management Pack.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;infoLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Target Column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetColumnHeader = 
                    ";Target;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MonitoringConfigScopeChooser;targetHeader.Text";

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
            /// Caches the translated resource string for:  ViewAllTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewAllTargets;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ViewCommonTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewCommonTargets;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClear;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _117TotalTargets28Visible0Selected
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_117TotalTargets28Visible0Selected;
            
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
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookFor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TargetColumnHeader
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetColumnHeader;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the ViewAllTargets translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewAllTargets
            {
                get
                {
                    if ((cachedViewAllTargets == null))
                    {
                        cachedViewAllTargets = CoreManager.MomConsole.GetIntlStr(ResourceViewAllTargets);
                    }
                    return cachedViewAllTargets;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ViewCommonTargets translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewCommonTargets
            {
                get
                {
                    if ((cachedViewCommonTargets == null))
                    {
                        cachedViewCommonTargets = CoreManager.MomConsole.GetIntlStr(ResourceViewCommonTargets);
                    }
                    return cachedViewCommonTargets;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Clear
            {
                get
                {
                    if ((cachedClear == null))
                    {
                        cachedClear = CoreManager.MomConsole.GetIntlStr(ResourceClear);
                    }
                    return cachedClear;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the _117TotalTargets28Visible0Selected translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _117TotalTargets28Visible0Selected
            {
                get
                {
                    if ((cached_117TotalTargets28Visible0Selected == null))
                    {
                        cached_117TotalTargets28Visible0Selected = CoreManager.MomConsole.GetIntlStr(Resource_117TotalTargets28Visible0Selected);
                    }
                    return cached_117TotalTargets28Visible0Selected;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClearAll translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LookFor
            {
                get
                {
                    if ((cachedLookFor == null))
                    {
                        cachedLookFor = CoreManager.MomConsole.GetIntlStr(ResourceLookFor);
                    }
                    return cachedLookFor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            {
                get
                {
                    if ((cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT == null))
                    {
                        cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = CoreManager.MomConsole.GetIntlStr(ResourceSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT);
                    }
                    return cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Target Column Header translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/23/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetColumnHeader
            {
                get
                {
                    if ((cachedTargetColumnHeader == null))
                    {
                        cachedTargetColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTargetColumnHeader);
                    }
                    return cachedTargetColumnHeader;
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
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ViewAllTargetsRadioButton
            /// </summary>
            public const string ViewAllTargetsRadioButton = "allTargetsRBtn";
            
            /// <summary>
            /// Control ID for ViewCommonTargetsRadioButton
            /// </summary>
            public const string ViewCommonTargetsRadioButton = "commonTargetsRBtn";
            
            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearSearchButton";
            
            /// <summary>
            /// Control ID for _117TotalTargets28Visible0SelectedStaticControl
            /// </summary>
            public const string _117TotalTargets28Visible0SelectedStaticControl = "selectedItemsLabel";
            
            /// <summary>
            /// Control ID for ClearAllButton
            /// </summary>
            public const string ClearAllButton = "clearAllButton";
            
            /// <summary>
            /// Control ID for SelectAllButton
            /// </summary>
            public const string SelectAllButton = "selectAllButton";
            
            /// <summary>
            /// Control ID for SearchTextBox
            /// </summary>
            public const string SearchTextBox = "searchTextBox";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "lookForLabel";
            
            /// <summary>
            /// Control ID for TypeListView
            /// </summary>
            public const string TypeListView = "typeListView";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
            /// </summary>
            public const string SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = "infoLabel";
        }
        #endregion
    }
}
