// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectTasksDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 7/24/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISelectTasksDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectTasksDialogControls, for SelectTasksDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectTasksDialogControls
    {
        /// <summary>
        /// Read-only property to access TasksStaticControl
        /// </summary>
        StaticControl TasksStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetDescriptionTextBox
        /// </summary>
        TextBox TargetDescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TaskDescriptionStaticControl
        /// </summary>
        StaticControl TaskDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TasksListView
        /// </summary>
        ListView TasksListView
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
        /// Read-only property to access _0TasksSelected5TasksHaveImplicitPermissionsStaticControl
        /// </summary>
        StaticControl _0TasksSelected5TasksHaveImplicitPermissionsStaticControl
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
        /// Read-only property to access GroupScopeTextBox
        /// </summary>
        TextBox GroupScopeTextBox
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
        /// Read-only property to access ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl
        /// </summary>
        StaticControl ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl
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
    /// 	[ruhim] 7/24/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectTasksDialog : Dialog, ISelectTasksDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTasksStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TargetDescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedTargetDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TaskDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TasksListView of type ListView
        /// </summary>
        private ListView cachedTasksListView;
        
        /// <summary>
        /// Cache to hold a reference to ClearButton of type Button
        /// </summary>
        private Button cachedClearButton;
        
        /// <summary>
        /// Cache to hold a reference to _0TasksSelected5TasksHaveImplicitPermissionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_0TasksSelected5TasksHaveImplicitPermissionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClearAllButton of type Button
        /// </summary>
        private Button cachedClearAllButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectAllButton of type Button
        /// </summary>
        private Button cachedSelectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to GroupScopeTextBox of type TextBox
        /// </summary>
        private TextBox cachedGroupScopeTextBox;
        
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
        /// Cache to hold a reference to ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectTasksDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectTasksDialog(MomConsoleApp app,enumTaskType taskType) : 
                base(app, Init(app,taskType))
        {
            Core.Common.Utilities.LogMessage("SelectTasksDialog:: Sucessfully found the dialog");  
        }
        #endregion
        
        #region ISelectTasksDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectTasksDialogControls Controls
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
        ///  Routine to set/get the text in control TargetDescription
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TargetDescriptionText
        {
            get
            {
                return this.Controls.TargetDescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.TargetDescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control GroupScope
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GroupScopeText
        {
            get
            {
                return this.Controls.GroupScopeTextBox.Text;
            }
            
            set
            {
                this.Controls.GroupScopeTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTasksDialogControls.TasksStaticControl
        {
            get
            {
                if ((this.cachedTasksStaticControl == null))
                {
                    this.cachedTasksStaticControl = new StaticControl(this, SelectTasksDialog.ControlIDs.TasksStaticControl);
                }
                return this.cachedTasksStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetDescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectTasksDialogControls.TargetDescriptionTextBox
        {
            get
            {
                if ((this.cachedTargetDescriptionTextBox == null))
                {
                    this.cachedTargetDescriptionTextBox = new TextBox(this, SelectTasksDialog.ControlIDs.TargetDescriptionTextBox);
                }
                return this.cachedTargetDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTasksDialogControls.TaskDescriptionStaticControl
        {
            get
            {
                if ((this.cachedTaskDescriptionStaticControl == null))
                {
                    this.cachedTaskDescriptionStaticControl = new StaticControl(this, SelectTasksDialog.ControlIDs.TaskDescriptionStaticControl);
                }
                return this.cachedTaskDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TasksListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectTasksDialogControls.TasksListView
        {
            get
            {
                if ((this.cachedTasksListView == null))
                {
                    this.cachedTasksListView = new ListView(this, SelectTasksDialog.ControlIDs.TasksListView);
                }
                return this.cachedTasksListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTasksDialogControls.ClearButton
        {
            get
            {
                if ((this.cachedClearButton == null))
                {
                    this.cachedClearButton = new Button(this, SelectTasksDialog.ControlIDs.ClearButton);
                }
                return this.cachedClearButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _0TasksSelected5TasksHaveImplicitPermissionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTasksDialogControls._0TasksSelected5TasksHaveImplicitPermissionsStaticControl
        {
            get
            {
                if ((this.cached_0TasksSelected5TasksHaveImplicitPermissionsStaticControl == null))
                {
                    this.cached_0TasksSelected5TasksHaveImplicitPermissionsStaticControl = new StaticControl(this, SelectTasksDialog.ControlIDs._0TasksSelected5TasksHaveImplicitPermissionsStaticControl);
                }
                return this.cached_0TasksSelected5TasksHaveImplicitPermissionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClearAllButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTasksDialogControls.ClearAllButton
        {
            get
            {
                if ((this.cachedClearAllButton == null))
                {
                    this.cachedClearAllButton = new Button(this, SelectTasksDialog.ControlIDs.ClearAllButton);
                }
                return this.cachedClearAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAllButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTasksDialogControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = new Button(this, SelectTasksDialog.ControlIDs.SelectAllButton);
                }
                return this.cachedSelectAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupScopeTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectTasksDialogControls.GroupScopeTextBox
        {
            get
            {
                if ((this.cachedGroupScopeTextBox == null))
                {
                    this.cachedGroupScopeTextBox = new TextBox(this, SelectTasksDialog.ControlIDs.GroupScopeTextBox);
                }
                return this.cachedGroupScopeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTasksDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, SelectTasksDialog.ControlIDs.LookForStaticControl);
                }
                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        ///     [a-joelj]   28OCT09 Maui 2.0: Modified to use QID in Button constructor
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTasksDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the Button constructor using 'this' and the 
                    // ControlId instead of using a QID is returning the wrong Button or no Button at all. 
                    // Modified to use a QID in the UIA tree for matching with the Button AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId='" + SelectTasksDialog.ControlIDs.OKButton + "' && Role='push button'");

                    this.cachedOKButton = new Button(this, queryId, Common.Constants.DefaultContextMenuTimeout);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectTasksDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectTasksDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectTasksDialogControls.ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl
        {
            get
            {
                if ((this.cachedToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl == null))
                {
                    this.cachedToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl = new StaticControl(this, SelectTasksDialog.ControlIDs.ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl);
                }
                return this.cachedToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Clear
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
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
        /// 	[ruhim] 7/24/2006 Created
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
        /// 	[ruhim] 7/24/2006 Created
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
        /// 	[ruhim] 7/24/2006 Created
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
        /// 	[ruhim] 7/24/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app,enumTaskType taskType)
        {
            // First check if the dialog is already up.
            string dialogTitle = null;

            switch (taskType)
            {
                case enumTaskType.Tasks:
                    dialogTitle = Strings.TasksDialogTitle;
                    break;
                case enumTaskType.DrilDownDashboards:
                    dialogTitle = Strings.SelectDashboardDialogTitle;
                    break;
            }
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    dialogTitle,
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
                               "*" +
                                // [a-joelj] - Maui 2.0: After upgrading to Maui 2.0 automation
                                // was no longer able to get the Select Tasks dialog by
                                // title. I modified the call to the Window constructor to 
                                // include a wildcard at the beginning of the dialog title. 
                                // Possible titles for this dialog are such that a wildcard 
                                // needs to be prepended and appended to the dialog title. 
                                app.GetIntlStr(dialogTitle) + "*",
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
                        dialogTitle + "'");

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
        /// 	[ruhim] 7/24/2006 Created
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
            private const string ResourceTasksDialogTitle =
                ";Select Tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTasks = ";&Tasks:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;labelTa" +
                "sks.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TaskDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskDescription = ";Task &description:;ManagedString;Microsoft.EnterpriseManagement.UI.Administratio" +
                "n.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksF" +
                "orm;labelTargetDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClear = ";Clear;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;buttonCle" +
                "ar.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  _0TasksSelected5TasksHaveImplicitPermissions
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string Resource_0TasksSelected5TasksHaveImplicitPermissions = "0 Tasks selected, 5 Tasks have implicit permissions";
            
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
            /// Contains resource string for:  ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask = ";To add a task, place a check mark in the box next to the name of the desired tas" +
                "k.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;labelTitle.T" +
                "ext";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Target Column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTasksColumnHeader =
                    ";Task;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksForm;columnHeaderTask.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Dashboards Column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDashboardsColumnHeader = 
                    ";Dashboards;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.UserRole.SelectAuxDashboardTasksForm;columnHeaderTask.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Dashboard Column Header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDashboardColumnHeader =
                    ";Dashboard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ViewScope;columnHeaderTask.Text";
            /// <summary>
            /// Contains resource string for:  DrillDownDashboards Tab page title
            /// </summary>
            private const string ResourceTaskPaneTabPageTitle = ";Task Pane;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ViewScope;tabPage2.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDashboardsDialogTitle = 
                    ";Select Dashboards;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.UserRole.SelectAuxDashboardTasksForm;$this.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasksDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectDashboardsDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TaskDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clear
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClear;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  _0TasksSelected5TasksHaveImplicitPermissions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_0TasksSelected5TasksHaveImplicitPermissions;
            
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
            /// Caches the translated resource string for:  ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TasksColumnHeader
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasksColumnHeader;

            /// <summary>
            /// Caches the tanslated resource string for: Drill Down Dashboard Column Header
            /// </summary>
            private static string cachedDashboardColumnHeader;

            /// <summary>
            /// Caches the tanslated resource string for: Drill Down Dashboards Column Header
            /// </summary>
            private static string cachedDashboardsColumnHeader;
            /// <summary>
            /// Caches the tanslated resource string for: Drill Down Dashboard Column Header
            /// </summary>
            private static string cachedTaskPaneTabPage;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TasksDialogTitle
            {
                get
                {
                    if ((cachedTasksDialogTitle == null))
                    {
                        cachedTasksDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceTasksDialogTitle);
                    }
                    return cachedTasksDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-lileo] 5/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectDashboardDialogTitle
            {
                get
                {
                    if ((cachedSelectDashboardsDialogTitle == null))
                    {
                        cachedSelectDashboardsDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDashboardsDialogTitle);
                    }
                    return cachedSelectDashboardsDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tasks translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tasks
            {
                get
                {
                    if ((cachedTasks == null))
                    {
                        cachedTasks = CoreManager.MomConsole.GetIntlStr(ResourceTasks);
                    }
                    return cachedTasks;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskDescription
            {
                get
                {
                    if ((cachedTaskDescription == null))
                    {
                        cachedTaskDescription = CoreManager.MomConsole.GetIntlStr(ResourceTaskDescription);
                    }
                    return cachedTaskDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clear translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/24/2006 Created
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
            /// Exposes access to the _0TasksSelected5TasksHaveImplicitPermissions translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _0TasksSelected5TasksHaveImplicitPermissions
            {
                get
                {
                    if ((cached_0TasksSelected5TasksHaveImplicitPermissions == null))
                    {
                        cached_0TasksSelected5TasksHaveImplicitPermissions = CoreManager.MomConsole.GetIntlStr(Resource_0TasksSelected5TasksHaveImplicitPermissions);
                    }
                    return cached_0TasksSelected5TasksHaveImplicitPermissions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ClearAll translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/24/2006 Created
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
            /// 	[ruhim] 7/24/2006 Created
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
            /// 	[ruhim] 7/24/2006 Created
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
            /// 	[ruhim] 7/24/2006 Created
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
            /// 	[ruhim] 7/24/2006 Created
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
            /// Exposes access to the ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/24/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask
            {
                get
                {
                    if ((cachedToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask == null))
                    {
                        cachedToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask = CoreManager.MomConsole.GetIntlStr(ResourceToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask);
                    }
                    return cachedToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTask;
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
            public static string TasksColumnHeader
            {
                get
                {
                    if ((cachedTasksColumnHeader == null))
                    {
                        cachedTasksColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTasksColumnHeader);
                    }
                    return cachedTasksColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DrillDownDashboard Column Header translated resource string
            /// </summary>
            /// <history>
            /// 	[v-lileo] 5/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DashboardColumnHeader
            {
                get
                {
                    if ((cachedDashboardColumnHeader == null))
                    {
                        cachedDashboardColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceDashboardColumnHeader);
                    }
                    return cachedDashboardColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Dashboards Column Header translated resource string
            /// </summary>
            /// <history>
            /// 	[v-lileo] 5/30/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DashboardsColumnHeader
            {
                get
                {
                    if (cachedDashboardsColumnHeader == null)
                    {
                       cachedDashboardsColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceDashboardsColumnHeader);
                    }
                    return cachedDashboardsColumnHeader;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DrillDownDashboards tab translated resource string
            /// </summary>
            /// <history>
            /// 	[v-lileo] 5/12/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskPaneTabPage
            {
                get
                {
                    if (cachedTaskPaneTabPage == null)
                    {
                        cachedTaskPaneTabPage = CoreManager.MomConsole.GetIntlStr(ResourceTaskPaneTabPageTitle);
                    }
                    return cachedTaskPaneTabPage;
                }
            }
            #endregion
        }
        #endregion
       
        public enum enumTaskType
        {
            /// <summary>
            /// 
            /// </summary>
            Tasks,

            /// <summary>
            /// 
            /// </summary>
            DrilDownDashboards,

        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for TasksStaticControl
            /// </summary>
            public const string TasksStaticControl = "labelTasks";
            
            /// <summary>
            /// Control ID for TargetDescriptionTextBox
            /// </summary>
            public const string TargetDescriptionTextBox = "textBoxDescription";
            
            /// <summary>
            /// Control ID for TaskDescriptionStaticControl
            /// </summary>
            public const string TaskDescriptionStaticControl = "labelTargetDescription";
            
            /// <summary>
            /// Control ID for TasksListView
            /// </summary>
            public const string TasksListView = "sortingListViewTasks";
            
            /// <summary>
            /// Control ID for ClearButton
            /// </summary>
            public const string ClearButton = "buttonClear";
            
            /// <summary>
            /// Control ID for _0TasksSelected5TasksHaveImplicitPermissionsStaticControl
            /// </summary>
            public const string _0TasksSelected5TasksHaveImplicitPermissionsStaticControl = "labelSelectedItems";
            
            /// <summary>
            /// Control ID for ClearAllButton
            /// </summary>
            public const string ClearAllButton = "buttonClearAll";
            
            /// <summary>
            /// Control ID for SelectAllButton
            /// </summary>
            public const string SelectAllButton = "buttonSelectAll";
            
            /// <summary>
            /// Control ID for GroupScopeTextBox
            /// </summary>
            public const string GroupScopeTextBox = "textBoxSearch";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "lookForLabel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl
            /// </summary>
            public const string ToAddATaskPlaceACheckMarkInTheBoxNextToTheNameOfTheDesiredTaskStaticControl = "labelTitle";
        }
        #endregion
    }
}
