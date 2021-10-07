// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddGroupDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[a-omkasi] 7/29/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    
    #region Interface Definition - IAddGroupDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddGroupDialogControls, for AddGroupDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 7/29/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddGroupDialogControls
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
        /// Read-only property to access StaticControl0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FilterOptionsHaveBeenAppliedStaticControl
        /// </summary>
        StaticControl FilterOptionsHaveBeenAppliedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupNameComboBox
        /// </summary>
        ComboBox GroupNameComboBox
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
        /// Read-only property to access ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox
        /// </summary>
        TextBox ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox
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
        /// Read-only property to access GroupNameStaticControl
        /// </summary>
        StaticControl GroupNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl
        /// </summary>
        StaticControl ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 7/29/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddGroupDialog : Dialog, IAddGroupDialogControls
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
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to FilterOptionsHaveBeenAppliedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilterOptionsHaveBeenAppliedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GroupNameComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedGroupNameComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox of type TextBox
        /// </summary>
        private TextBox cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox;
        
        /// <summary>
        /// Cache to hold a reference to OptionsButton of type Button
        /// </summary>
        private Button cachedOptionsButton;
        
        /// <summary>
        /// Cache to hold a reference to GroupNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGroupNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
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
        /// Owner of AddGroupDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddGroupDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddGroupDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddGroupDialogControls Controls
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
        ///  Routine to set/get the text in control GroupName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GroupNameText
        {
            get
            {
                return this.Controls.GroupNameComboBox.Text;
            }
            
            set
            {
                this.Controls.GroupNameComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListText
        {
            get
            {
                return this.Controls.ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox.Text;
            }
            
            set
            {
                this.Controls.ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsListView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAddGroupDialogControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + AddGroupDialog.ControlIDs.AvailableItemsListView + "'"));
                }
                
                return this.cachedAvailableItemsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddGroupDialogControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = new StaticControl(this, AddGroupDialog.ControlIDs.AvailableItemsStaticControl);
                }
                
                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedObjectsListView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAddGroupDialogControls.SelectedObjectsListView
        {
            get
            {
                if ((this.cachedSelectedObjectsListView == null))
                {
                    this.cachedSelectedObjectsListView = new ListView(this, new QID(";[UIA]AutomationId ='" + AddGroupDialog.ControlIDs.SelectedObjectsListView + "'"));
                }
                
                return this.cachedSelectedObjectsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddGroupDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, AddGroupDialog.ControlIDs.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddGroupDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, AddGroupDialog.ControlIDs.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddGroupDialogControls.SelectedObjectsStaticControl
        {
            get
            {
                if ((this.cachedSelectedObjectsStaticControl == null))
                {
                    this.cachedSelectedObjectsStaticControl = new StaticControl(this, AddGroupDialog.ControlIDs.SelectedObjectsStaticControl);
                }
                
                return this.cachedSelectedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddGroupDialogControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, AddGroupDialog.ControlIDs.StaticControl0);
                }
                
                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterOptionsHaveBeenAppliedStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddGroupDialogControls.FilterOptionsHaveBeenAppliedStaticControl
        {
            get
            {
                if ((this.cachedFilterOptionsHaveBeenAppliedStaticControl == null))
                {
                    this.cachedFilterOptionsHaveBeenAppliedStaticControl = new StaticControl(this, AddGroupDialog.ControlIDs.FilterOptionsHaveBeenAppliedStaticControl);
                }
                
                return this.cachedFilterOptionsHaveBeenAppliedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupNameComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddGroupDialogControls.GroupNameComboBox
        {
            get
            {
                if ((this.cachedGroupNameComboBox == null))
                {
                    this.cachedGroupNameComboBox = new ComboBox(this, AddGroupDialog.ControlIDs.GroupNameComboBox);
                }
                
                return this.cachedGroupNameComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddGroupDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, AddGroupDialog.ControlIDs.SearchButton);
                }
                
                return this.cachedSearchButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddGroupDialogControls.ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox
        {
            get
            {
                if ((this.cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox == null))
                {
                    this.cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox = new TextBox(this, AddGroupDialog.ControlIDs.ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox);
                }
                
                return this.cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptionsButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddGroupDialogControls.OptionsButton
        {
            get
            {
                if ((this.cachedOptionsButton == null))
                {
                    this.cachedOptionsButton = new Button(this, AddGroupDialog.ControlIDs.OptionsButton);
                }
                
                return this.cachedOptionsButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddGroupDialogControls.GroupNameStaticControl
        {
            get
            {
                if ((this.cachedGroupNameStaticControl == null))
                {
                    this.cachedGroupNameStaticControl = new StaticControl(this, AddGroupDialog.ControlIDs.GroupNameStaticControl);
                }
                
                return this.cachedGroupNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddGroupDialogControls.ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl
        {
            get
            {
                if ((this.cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl == null))
                {
                    this.cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl = new StaticControl(this, AddGroupDialog.ControlIDs.ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl);
                }
                
                return this.cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddGroupDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddGroupDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddGroupDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddGroupDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
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
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Options
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOptions()
        {
            this.Controls.OptionsButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
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
        /// 	[a-omkasi] 7/29/2008 Created
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
        /// 	[a-omkasi] 7/29/2008 Created
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
            catch (Exceptions.WindowNotFoundException )
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 15;

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
                
             /*   // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
                }
              * */
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
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
            private const string ResourceDialogTitle = ";Add Group;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringGroupPickerDialog;$this.Text";
            
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
            /// Contains resource string for:  FilterOptionsHaveBeenApplied
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterOptionsHaveBeenApplied = ";Filter Options have been applied;ManagedString;Microsoft.EnterpriseManagement.UI" +
                ".Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Paramete" +
                "rs.Controls.Monitoring.ReportMonitoringSearchCriteria;filterInformationLabel.Tex" +
                "t";
            
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
            /// Contains resource string for:  Options
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOptions = ";Options;ManagedString;Corgent.Toolbox.Core.dll;Corgent.Toolbox.Core.Properties.R" +
                "esources;Options";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GroupName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupName = ";Group Name:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitorin" +
                "g.ReportMonitoringSearchGroupCriteria;nameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList = @";To add groups to this report, search for the groups, then add them to the 'selected groups' list;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringSearchGroupCriteria;searchHelpLabel.Text";
            
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
            /// Caches the translated resource string for:  FilterOptionsHaveBeenApplied
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterOptionsHaveBeenApplied;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Options
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOptions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GroupName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList;
            
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
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/29/2008 Created
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
            /// 	[a-omkasi] 7/29/2008 Created
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
            /// 	[a-omkasi] 7/29/2008 Created
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
            /// 	[a-omkasi] 7/29/2008 Created
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
            /// 	[a-omkasi] 7/29/2008 Created
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
            /// Exposes access to the FilterOptionsHaveBeenApplied translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/29/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterOptionsHaveBeenApplied
            {
                get
                {
                    if ((cachedFilterOptionsHaveBeenApplied == null))
                    {
                        cachedFilterOptionsHaveBeenApplied = CoreManager.MomConsole.GetIntlStr(ResourceFilterOptionsHaveBeenApplied);
                    }
                    
                    return cachedFilterOptionsHaveBeenApplied;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/29/2008 Created
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
            /// Exposes access to the Options translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/29/2008 Created
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
            /// Exposes access to the GroupName translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/29/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupName
            {
                get
                {
                    if ((cachedGroupName == null))
                    {
                        cachedGroupName = CoreManager.MomConsole.GetIntlStr(ResourceGroupName);
                    }
                    
                    return cachedGroupName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/29/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList
            {
                get
                {
                    if ((cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList == null))
                    {
                        cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList = CoreManager.MomConsole.GetIntlStr(ResourceToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList);
                    }
                    
                    return cachedToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 7/29/2008 Created
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
            /// 	[a-omkasi] 7/29/2008 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 7/29/2008 Created
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
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl0 = "filterInformation";
            
            /// <summary>
            /// Control ID for FilterOptionsHaveBeenAppliedStaticControl
            /// </summary>
            public const string FilterOptionsHaveBeenAppliedStaticControl = "filterInformationLabel";
            
            /// <summary>
            /// Control ID for GroupNameComboBox
            /// </summary>
            public const string GroupNameComboBox = "patternComboBox";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox
            /// </summary>
            public const string ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListTextBox = "nameEditor";
            
            /// <summary>
            /// Control ID for OptionsButton
            /// </summary>
            public const string OptionsButton = "optionsButton";
            
            /// <summary>
            /// Control ID for GroupNameStaticControl
            /// </summary>
            public const string GroupNameStaticControl = "nameLabel";
            
            /// <summary>
            /// Control ID for ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl
            /// </summary>
            public const string ToAddGroupsToThisReportSearchForTheGroupsThenAddThemToTheSelectedGroupsListStaticControl = "searchHelpLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
        }
        #endregion
    }
}
