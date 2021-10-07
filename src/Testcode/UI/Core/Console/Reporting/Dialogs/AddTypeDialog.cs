// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddTypeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[a-omkasi] 8/4/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAddTypeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddTypeDialogControls, for AddTypeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 8/4/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddTypeDialogControls
    {
        /// <summary>
        /// Read-only property to access AvailableItemsListView
        /// </summary>
        ListView AvailableItemsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableItemsStaticControl
        /// </summary>
        StaticControl AvailableItemsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedObjectsListView
        /// </summary>
        ListView SelectedObjectsListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedObjectsStaticControl
        /// </summary>
        StaticControl SelectedObjectsStaticControl
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
        /// Read-only property to access TypeNameComboBox
        /// </summary>
        ComboBox TypeNameComboBox
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
        /// Read-only property to access TypeNameTextBox
        /// </summary>
        TextBox TypeNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TypeNameStaticControl
        /// </summary>
        StaticControl TypeNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl
        /// </summary>
        StaticControl ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl
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
    /// 	[a-omkasi] 8/4/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddTypeDialog : Dialog, IAddTypeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to AvailableItemsListView of type ListView
        /// </summary>
        private ListView cachedAvailableItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedObjectsListView of type ListView
        /// </summary>
        private ListView cachedSelectedObjectsListView;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectedObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to TypeNameComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTypeNameComboBox;
        
        /// <summary>
        /// Cache to hold a reference to OptionsButton of type Button
        /// </summary>
        private Button cachedOptionsButton;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to TypeNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedTypeNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TypeNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTypeNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddTypeDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddTypeDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddTypeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddTypeDialogControls Controls
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
        ///  Routine to set/get the text in control TypeName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TypeNameText
        {
            get
            {
                return this.Controls.TypeNameComboBox.Text;
            }
            
            set
            {
                this.Controls.TypeNameComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TypeName2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TypeName2Text
        {
            get
            {
                return this.Controls.TypeNameTextBox.Text;
            }
            
            set
            {
                this.Controls.TypeNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsListView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAddTypeDialogControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + AddTypeDialog.ControlIDs.AvailableItemsListView + "'"));
                }
                
                return this.cachedAvailableItemsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddTypeDialogControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = new StaticControl(this, AddTypeDialog.ControlIDs.AvailableItemsStaticControl);
                }
                
                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedObjectsListView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAddTypeDialogControls.SelectedObjectsListView
        {
            get
            {
                if ((this.cachedSelectedObjectsListView == null))
                {
                    this.cachedSelectedObjectsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + AddTypeDialog.ControlIDs.SelectedObjectsListView + "'"));
                }
                
                return this.cachedSelectedObjectsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddTypeDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, AddTypeDialog.ControlIDs.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddTypeDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, AddTypeDialog.ControlIDs.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddTypeDialogControls.SelectedObjectsStaticControl
        {
            get
            {
                if ((this.cachedSelectedObjectsStaticControl == null))
                {
                    this.cachedSelectedObjectsStaticControl = new StaticControl(this, AddTypeDialog.ControlIDs.SelectedObjectsStaticControl);
                }
                
                return this.cachedSelectedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddTypeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddTypeDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddTypeDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddTypeDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeNameComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddTypeDialogControls.TypeNameComboBox
        {
            get
            {
                if ((this.cachedTypeNameComboBox == null))
                {
                    this.cachedTypeNameComboBox = new ComboBox(this, AddTypeDialog.ControlIDs.TypeNameComboBox);
                }
                
                return this.cachedTypeNameComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptionsButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddTypeDialogControls.OptionsButton
        {
            get
            {
                if ((this.cachedOptionsButton == null))
                {
                    this.cachedOptionsButton = new Button(this, AddTypeDialog.ControlIDs.OptionsButton);
                }
                
                return this.cachedOptionsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddTypeDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, AddTypeDialog.ControlIDs.SearchButton);
                }
                
                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeNameTextBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddTypeDialogControls.TypeNameTextBox
        {
            get
            {
                if ((this.cachedTypeNameTextBox == null))
                {
                    this.cachedTypeNameTextBox = new TextBox(this, AddTypeDialog.ControlIDs.TypeNameTextBox);
                }
                
                return this.cachedTypeNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddTypeDialogControls.TypeNameStaticControl
        {
            get
            {
                if ((this.cachedTypeNameStaticControl == null))
                {
                    this.cachedTypeNameStaticControl = new StaticControl(this, AddTypeDialog.ControlIDs.TypeNameStaticControl);
                }
                
                return this.cachedTypeNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddTypeDialogControls.ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl
        {
            get
            {
                if ((this.cachedToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl == null))
                {
                    this.cachedToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl = new StaticControl(this, AddTypeDialog.ControlIDs.ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl);
                }
                
                return this.cachedToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
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
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Options
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
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
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[a-omkasi] 8/4/2008 Created
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
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);
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
        /// 	[a-omkasi] 8/4/2008 Created
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
            private const string ResourceDialogTitle = ";Add Type;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringObjectTypePickerDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems = ";Available items;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Controls.ChooserControl;availableObjects.CaptionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";&Add;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSchedul" +
                "ePage;periods.AddButtonText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";&Remove;ManagedString;Corgent.Diagramming.CommandResources.dll;Corgent.Diagrammi" +
                "ng.CommandResources.Properties.Resources;Command_Remove";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedObjects = ";Selected &objects;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Controls.ChooserControl;selectedObjects.CaptionText";
            
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
            /// Contains resource string for:  Options
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOptions = ";Options >>;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring" +
                ".ReportMonitoringObjectPickerResources;SearchButton_OptionsOpened";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";Search;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.Rep" +
                "ortMonitoringObjectSearchCriteria;searchButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TypeName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTypeName = ";Type Name:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring" +
                ".ReportMonitoringSearchTypesCriteria;nameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList = @";To add types to this report, search for the types and then add them to the 'Selected types' list.;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringSearchTypesCriteria;searchHelpLabel.Text";
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
            /// Caches the translated resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAvailableItems;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedObjects;
            
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
            /// Caches the translated resource string for:  TypeName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTypeName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
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
            /// Exposes access to the AvailableItems translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
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
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    
                    return cachedAdd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    
                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedObjects
            {
                get
                {
                    if ((cachedSelectedObjects == null))
                    {
                        cachedSelectedObjects = CoreManager.MomConsole.GetIntlStr(ResourceSelectedObjects);
                    }
                    
                    return cachedSelectedObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
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
            /// 	[a-omkasi] 8/4/2008 Created
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
            /// Exposes access to the Options translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
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
            /// 	[a-omkasi] 8/4/2008 Created
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
            /// Exposes access to the TypeName translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TypeName
            {
                get
                {
                    if ((cachedTypeName == null))
                    {
                        cachedTypeName = CoreManager.MomConsole.GetIntlStr(ResourceTypeName);
                    }
                    
                    return cachedTypeName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList
            {
                get
                {
                    if ((cachedToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList == null))
                    {
                        cachedToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList = CoreManager.MomConsole.GetIntlStr(ResourceToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList);
                    }
                    
                    return cachedToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesList;
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
        /// 	[a-omkasi] 8/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for AvailableItemsListView
            /// </summary>
            public const string AvailableItemsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AvailableItemsStaticControl
            /// </summary>
            public const string AvailableItemsStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for SelectedObjectsListView
            /// </summary>
            public const string SelectedObjectsListView = "selectedItemsListview";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for SelectedObjectsStaticControl
            /// </summary>
            public const string SelectedObjectsStaticControl = "selectedObjectsLabel";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for TypeNameComboBox
            /// </summary>
            public const string TypeNameComboBox = "patternComboBox";
            
            /// <summary>
            /// Control ID for OptionsButton
            /// </summary>
            public const string OptionsButton = "optionsButton";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for TypeNameTextBox
            /// </summary>
            public const string TypeNameTextBox = "nameEditor";
            
            /// <summary>
            /// Control ID for TypeNameStaticControl
            /// </summary>
            public const string TypeNameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl
            /// </summary>
            public const string ToAddTypesToThisReportSearchForTheTypesAndThenAddThemToTheSelectedTypesListStaticControl = "searchHelpLabel";
        }
        #endregion
    }
}
