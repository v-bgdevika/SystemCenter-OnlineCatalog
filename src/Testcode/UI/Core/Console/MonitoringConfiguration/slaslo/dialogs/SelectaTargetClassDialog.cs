// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectaTargetClassDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy class that represents the Select a Target Dialog during SLA wizard
// </project>
// <summary>
// 	Proxy class that represents the Select a Target Dialog during SLA wizard
// </summary>
// <history>
// 	[dialac] 10/6/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISelectaTargetClassDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectaTargetClassDialogControls, for SelectaTargetClassDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 10/6/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectaTargetClassDialogControls
    {
        /// <summary>
        /// Read-only property to access SummaryListView
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ListView SummaryListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchResultFilterComboBox
        /// </summary>
        ComboBox SearchResultFilterComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchResultFilterStaticControl
        /// </summary>
        StaticControl SearchResultFilterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
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
        /// Read-only property to access _8TotalTargets8Visible0SelectedStaticControl
        /// </summary>
        StaticControl _8TotalTargets8Visible0SelectedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LookForTextBox
        /// </summary>
        TextBox LookForTextBox
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
    /// 	[dialac] 10/6/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectaTargetClassDialog : Dialog, ISelectaTargetClassDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SummaryListView of type ListView
        /// </summary>
        private ListView cachedListView0;
        
        /// <summary>
        /// Cache to hold a reference to SearchResultFilterComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSearchResultFilterComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SearchResultFilterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchResultFilterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;
        
        /// <summary>
        /// Cache to hold a reference to _8TotalTargets8Visible0SelectedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_8TotalTargets8Visible0SelectedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LookForTextBox of type TextBox
        /// </summary>
        private TextBox cachedLookForTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
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
        /// Owner of SelectaTargetClassDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectaTargetClassDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISelectaTargetClassDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectaTargetClassDialogControls Controls
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
        ///  Routine to set/get the text in control SearchResultFilter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchResultFilterText
        {
            get
            {
                return this.Controls.SearchResultFilterComboBox.Text;
            }
            
            set
            {
                this.Controls.SearchResultFilterComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control LookFor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LookForText
        {
            get
            {
                return this.Controls.LookForTextBox.Text;
            }
            
            set
            {
                this.Controls.LookForTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryListView control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectaTargetClassDialogControls.SummaryListView
        {
            get
            {
                if ((this.cachedListView0 == null))
                {
                    this.cachedListView0 = new ListView(this, new QID(";[UIA]AutomationId ='" + SelectaTargetClassDialog.ControlIDs.SummaryListView + "'"));
                }
                
                return this.cachedListView0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchResultFilterComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectaTargetClassDialogControls.SearchResultFilterComboBox
        {
            get
            {
                if ((this.cachedSearchResultFilterComboBox == null))
                {
                    this.cachedSearchResultFilterComboBox = new ComboBox(this, SelectaTargetClassDialog.ControlIDs.SearchResultFilterComboBox);
                }
                
                return this.cachedSearchResultFilterComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchResultFilterStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectaTargetClassDialogControls.SearchResultFilterStaticControl
        {
            get
            {
                if ((this.cachedSearchResultFilterStaticControl == null))
                {
                    this.cachedSearchResultFilterStaticControl = new StaticControl(this, SelectaTargetClassDialog.ControlIDs.SearchResultFilterStaticControl);
                }
                
                return this.cachedSearchResultFilterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectaTargetClassDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, SelectaTargetClassDialog.ControlIDs.HelpButton);
                }
                
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectaTargetClassDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, SelectaTargetClassDialog.ControlIDs.ClearButton);
                }
                
                return this.cachedClearButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _8TotalTargets8Visible0SelectedStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectaTargetClassDialogControls._8TotalTargets8Visible0SelectedStaticControl
        {
            get
            {
                if ((this.cached_8TotalTargets8Visible0SelectedStaticControl == null))
                {
                    this.cached_8TotalTargets8Visible0SelectedStaticControl = new StaticControl(this, SelectaTargetClassDialog.ControlIDs._8TotalTargets8Visible0SelectedStaticControl);
                }
                
                return this.cached_8TotalTargets8Visible0SelectedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectaTargetClassDialogControls.LookForTextBox
        {
            get
            {
                if ((this.cachedLookForTextBox == null))
                {
                    this.cachedLookForTextBox = new TextBox(this, SelectaTargetClassDialog.ControlIDs.LookForTextBox);
                }
                
                return this.cachedLookForTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectaTargetClassDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, SelectaTargetClassDialog.ControlIDs.LookForStaticControl);
                }
                
                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectaTargetClassDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectaTargetClassDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectaTargetClassDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectaTargetClassDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT control
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectaTargetClassDialogControls.SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT
        {
            get
            {
                if ((this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT == null))
                {
                    this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT = new StaticControl(this, SelectaTargetClassDialog.ControlIDs.SelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT);
                }
                
                return this.cachedSelectTheTargetYouWantToUseFromTheListBelowYouCanAlsoUseTheLookForFieldBelowToFilterDownToASpecificT;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClear()
        {
            this.Controls.ClearButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
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
        /// 	[dialac] 10/6/2008 Created
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
        /// 	[dialac] 10/6/2008 Created
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
        /// 	[dialac] 10/6/2008 Created
        ///     [a-joelj] 23DEC08  Added correct resource string for ResourceDialogTitle
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
            private const string ResourceDialogTitle = 
                ";Select a Target Class;ManagedString;" + 
                "Microsoft.EnterpriseManagement.UI.Authoring.dll;" + 
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.SlaPageResources;TargetChooserTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchResultFilter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchResultFilter = ";Search result filter:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SlaTargetSubContr" +
                "ol;filterLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";&Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEd" +
                "itorForm;helpToolStripMenuItem.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClear = ";Cl&ear;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.AdvancedAlertSuppressionForm;cle" +
                "arBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _8TotalTargets8Visible0Selected
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_8TotalTargets8Visible0Selected = "8 total Targets, 8 visible, 0 selected";
            // TODO: Should replace with ";{0} total Targets, {1} visible, {2} selected;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MonitoringConfigScopeSelectedFormat";

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
            /// Caches the translated resource string for:  SearchResultFilter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchResultFilter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClear;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _8TotalTargets8Visible0Selected
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_8TotalTargets8Visible0Selected;
            
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
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/6/2008 Created
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
            /// Exposes access to the SearchResultFilter translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/6/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchResultFilter
            {
                get
                {
                    if ((cachedSearchResultFilter == null))
                    {
                        cachedSearchResultFilter = CoreManager.MomConsole.GetIntlStr(ResourceSearchResultFilter);
                    }
                    
                    return cachedSearchResultFilter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/6/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/6/2008 Created
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
            /// Exposes access to the _8TotalTargets8Visible0Selected translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/6/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _8TotalTargets8Visible0Selected
            {
                get
                {
                    if ((cached_8TotalTargets8Visible0Selected == null))
                    {
                        cached_8TotalTargets8Visible0Selected = CoreManager.MomConsole.GetIntlStr(Resource_8TotalTargets8Visible0Selected);
                    }
                    
                    return cached_8TotalTargets8Visible0Selected;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 10/6/2008 Created
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
            /// 	[dialac] 10/6/2008 Created
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
            /// 	[dialac] 10/6/2008 Created
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
            /// 	[dialac] 10/6/2008 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[dialac] 10/6/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SummaryListView
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string SummaryListView = "typeListView";
            
            /// <summary>
            /// Control ID for SearchResultFilterComboBox
            /// </summary>
            public const string SearchResultFilterComboBox = "searchFilterComboBox";
            
            /// <summary>
            /// Control ID for SearchResultFilterStaticControl
            /// </summary>
            public const string SearchResultFilterStaticControl = "filterLabel";
            
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "helpBtn";
            
            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "clearSearchButton";
            
            /// <summary>
            /// Control ID for _8TotalTargets8Visible0SelectedStaticControl
            /// </summary>
            public const string _8TotalTargets8Visible0SelectedStaticControl = "selectedItemsLabel";
            
            /// <summary>
            /// Control ID for LookForTextBox
            /// </summary>
            public const string LookForTextBox = "searchTextBox";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "lookForLabel";
            
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
