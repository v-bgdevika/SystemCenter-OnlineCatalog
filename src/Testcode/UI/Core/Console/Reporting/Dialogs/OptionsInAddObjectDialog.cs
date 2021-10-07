               // -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OptionsInAddObjectDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[a-omkasi] 8/5/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Reporting.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IOptionsInAddObjectDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOptionsInAddObjectDialogControls, for OptionsInAddObjectDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[a-omkasi] 8/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOptionsInAddObjectDialogControls
    {
        /// <summary>
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IncludeObjectsFromTheFollowingTypesStaticControl
        /// </summary>
        StaticControl IncludeObjectsFromTheFollowingTypesStaticControl
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
        /// Read-only property to access SelectedObjectsListView
        /// </summary>
        ListView SelectedObjectsListView
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
        /// Read-only property to access SearchTimeIntervalStartDateStaticControl
        /// </summary>
        StaticControl SearchTimeIntervalStartDateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IncludeObjectsFromTheFollowingManagementGroupsStaticControl
        /// </summary>
        StaticControl IncludeObjectsFromTheFollowingManagementGroupsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TypeNameListBox
        /// </summary>
        ListBox TypeNameListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchTimeIntervalStartDateComboBox
        /// </summary>
        ComboBox SearchTimeIntervalStartDateComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchTimeIntervalEndDateComboBox
        /// </summary>
        ComboBox SearchTimeIntervalEndDateComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchTimeIntervalEndDateStaticControl
        /// </summary>
        StaticControl SearchTimeIntervalEndDateStaticControl
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
    /// 	[a-omkasi] 8/5/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class OptionsInAddObjectDialog : Dialog, IOptionsInAddObjectDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to IncludeObjectsFromTheFollowingTypesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIncludeObjectsFromTheFollowingTypesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectedObjectsListView of type ListView
        /// </summary>
        private ListView cachedSelectedObjectsListView;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalStartDateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchTimeIntervalStartDateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IncludeObjectsFromTheFollowingManagementGroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIncludeObjectsFromTheFollowingManagementGroupsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TypeNameListBox of type ListBox
        /// </summary>
        private ListBox cachedTypeNameListBox;
        
        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalStartDateComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSearchTimeIntervalStartDateComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalEndDateComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSearchTimeIntervalEndDateComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SearchTimeIntervalEndDateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchTimeIntervalEndDateStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OptionsInAddObjectDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OptionsInAddObjectDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IOptionsInAddObjectDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOptionsInAddObjectDialogControls Controls
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
        ///  Routine to set/get the text in control SearchTimeIntervalStartDate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchTimeIntervalStartDateText
        {
            get
            {
                return this.Controls.SearchTimeIntervalStartDateComboBox.Text;
            }
            
            set
            {
                this.Controls.SearchTimeIntervalStartDateComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SearchTimeIntervalEndDate
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchTimeIntervalEndDateText
        {
            get
            {
                return this.Controls.SearchTimeIntervalEndDateComboBox.Text;
            }
            
            set
            {
                this.Controls.SearchTimeIntervalEndDateComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddObjectDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, OptionsInAddObjectDialog.ControlIDs.RemoveButton);
                }
                
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeObjectsFromTheFollowingTypesStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddObjectDialogControls.IncludeObjectsFromTheFollowingTypesStaticControl
        {
            get
            {
                if ((this.cachedIncludeObjectsFromTheFollowingTypesStaticControl == null))
                {
                    this.cachedIncludeObjectsFromTheFollowingTypesStaticControl = new StaticControl(this, OptionsInAddObjectDialog.ControlIDs.IncludeObjectsFromTheFollowingTypesStaticControl);
                }
                
                return this.cachedIncludeObjectsFromTheFollowingTypesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddObjectDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, OptionsInAddObjectDialog.ControlIDs.AddButton);
                }
                
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedObjectsListView control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IOptionsInAddObjectDialogControls.SelectedObjectsListView
        {
            get
            {
                if ((this.cachedSelectedObjectsListView == null))
                {
                    this.cachedSelectedObjectsListView = new ListView(this, OptionsInAddObjectDialog.ControlIDs.SelectedObjectsListView);
                }
                
                return this.cachedSelectedObjectsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddObjectDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, OptionsInAddObjectDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOptionsInAddObjectDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, OptionsInAddObjectDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalStartDateStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddObjectDialogControls.SearchTimeIntervalStartDateStaticControl
        {
            get
            {
                if ((this.cachedSearchTimeIntervalStartDateStaticControl == null))
                {
                    this.cachedSearchTimeIntervalStartDateStaticControl = new StaticControl(this, OptionsInAddObjectDialog.ControlIDs.SearchTimeIntervalStartDateStaticControl);
                }
                
                return this.cachedSearchTimeIntervalStartDateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IncludeObjectsFromTheFollowingManagementGroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddObjectDialogControls.IncludeObjectsFromTheFollowingManagementGroupsStaticControl
        {
            get
            {
                if ((this.cachedIncludeObjectsFromTheFollowingManagementGroupsStaticControl == null))
                {
                    this.cachedIncludeObjectsFromTheFollowingManagementGroupsStaticControl = new StaticControl(this, OptionsInAddObjectDialog.ControlIDs.IncludeObjectsFromTheFollowingManagementGroupsStaticControl);
                }
                
                return this.cachedIncludeObjectsFromTheFollowingManagementGroupsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeNameListBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IOptionsInAddObjectDialogControls.TypeNameListBox
        {
            get
            {
                if ((this.cachedTypeNameListBox == null))
                {
                    this.cachedTypeNameListBox = new ListBox(this, OptionsInAddObjectDialog.ControlIDs.TypeNameListBox);
                }
                
                return this.cachedTypeNameListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalStartDateComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOptionsInAddObjectDialogControls.SearchTimeIntervalStartDateComboBox
        {
            get
            {
                if ((this.cachedSearchTimeIntervalStartDateComboBox == null))
                {
                    this.cachedSearchTimeIntervalStartDateComboBox = new ComboBox(this, OptionsInAddObjectDialog.ControlIDs.SearchTimeIntervalStartDateComboBox);
                }
                
                return this.cachedSearchTimeIntervalStartDateComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalEndDateComboBox control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOptionsInAddObjectDialogControls.SearchTimeIntervalEndDateComboBox
        {
            get
            {
                if ((this.cachedSearchTimeIntervalEndDateComboBox == null))
                {
                    this.cachedSearchTimeIntervalEndDateComboBox = new ComboBox(this, OptionsInAddObjectDialog.ControlIDs.SearchTimeIntervalEndDateComboBox);
                }
                
                return this.cachedSearchTimeIntervalEndDateComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTimeIntervalEndDateStaticControl control
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptionsInAddObjectDialogControls.SearchTimeIntervalEndDateStaticControl
        {
            get
            {
                if ((this.cachedSearchTimeIntervalEndDateStaticControl == null))
                {
                    this.cachedSearchTimeIntervalEndDateStaticControl = new StaticControl(this, OptionsInAddObjectDialog.ControlIDs.SearchTimeIntervalEndDateStaticControl);
                }
                
                return this.cachedSearchTimeIntervalEndDateStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
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
        /// 	[a-omkasi] 8/5/2008 Created
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
        /// 	[a-omkasi] 8/5/2008 Created
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
                
                //// check for success
                //if ((null == tempWindow))
                //{
                //    // log the failure

                //    // rethrow the original exception
                //    throw windowNotFound;
                //}
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 8/5/2008 Created
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
            private const string ResourceDialogTitle = ";Options;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringOptionDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.CommandNot" +
                "ification;removeButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IncludeObjectsFromTheFollowingTypes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncludeObjectsFromTheFollowingTypes = "Include Objects from the following types:";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";Add;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.Report" +
                "MonitoringTypeDisplayOption;AddTypes.Text";
            
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
            /// Contains resource string for:  SearchTimeIntervalStartDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchTimeIntervalStartDate = ";Search time interval start date:;ManagedString;Microsoft.EnterpriseManagement.UI" +
                ".Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Paramete" +
                "rs.Controls.Monitoring.ReportMonitoringObjectSearchCriteria;startDateLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IncludeObjectsFromTheFollowingManagementGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIncludeObjectsFromTheFollowingManagementGroups = @";Include objects from the following Management Groups:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringObjectSearchCriteria;groupLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchTimeIntervalEndDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchTimeIntervalEndDate = ";Search time interval end date:;ManagedString;Microsoft.EnterpriseManagement.UI.R" +
                "eporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters" +
                ".Controls.Monitoring.ReportMonitoringObjectSearchCriteria;endDateLabel.Text";
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
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IncludeObjectsFromTheFollowingTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIncludeObjectsFromTheFollowingTypes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
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
            /// Caches the translated resource string for:  SearchTimeIntervalStartDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchTimeIntervalStartDate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IncludeObjectsFromTheFollowingManagementGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIncludeObjectsFromTheFollowingManagementGroups;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SearchTimeIntervalEndDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchTimeIntervalEndDate;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/5/2008 Created
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
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/5/2008 Created
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
            /// Exposes access to the IncludeObjectsFromTheFollowingTypes translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IncludeObjectsFromTheFollowingTypes
            {
                get
                {
                    if ((cachedIncludeObjectsFromTheFollowingTypes == null))
                    {
                        cachedIncludeObjectsFromTheFollowingTypes = CoreManager.MomConsole.GetIntlStr(ResourceIncludeObjectsFromTheFollowingTypes);
                    }
                    
                    return cachedIncludeObjectsFromTheFollowingTypes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/5/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/5/2008 Created
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
            /// 	[a-omkasi] 8/5/2008 Created
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
            /// Exposes access to the SearchTimeIntervalStartDate translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchTimeIntervalStartDate
            {
                get
                {
                    if ((cachedSearchTimeIntervalStartDate == null))
                    {
                        cachedSearchTimeIntervalStartDate = CoreManager.MomConsole.GetIntlStr(ResourceSearchTimeIntervalStartDate);
                    }
                    
                    return cachedSearchTimeIntervalStartDate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IncludeObjectsFromTheFollowingManagementGroups translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IncludeObjectsFromTheFollowingManagementGroups
            {
                get
                {
                    if ((cachedIncludeObjectsFromTheFollowingManagementGroups == null))
                    {
                        cachedIncludeObjectsFromTheFollowingManagementGroups = CoreManager.MomConsole.GetIntlStr(ResourceIncludeObjectsFromTheFollowingManagementGroups);
                    }
                    
                    return cachedIncludeObjectsFromTheFollowingManagementGroups;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchTimeIntervalEndDate translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 8/5/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchTimeIntervalEndDate
            {
                get
                {
                    if ((cachedSearchTimeIntervalEndDate == null))
                    {
                        cachedSearchTimeIntervalEndDate = CoreManager.MomConsole.GetIntlStr(ResourceSearchTimeIntervalEndDate);
                    }
                    
                    return cachedSearchTimeIntervalEndDate;
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
        /// 	[a-omkasi] 8/5/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "RemoveTypes";
            
            /// <summary>
            /// Control ID for IncludeObjectsFromTheFollowingTypesStaticControl
            /// </summary>
            public const string IncludeObjectsFromTheFollowingTypesStaticControl = "typeLabel";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "AddTypes";
            
            /// <summary>
            /// Control ID for SelectedObjectsListView
            /// </summary>
            public const string SelectedObjectsListView = "typeDisplayView";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "OK_Options";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "Cancel_Options";
            
            /// <summary>
            /// Control ID for SearchTimeIntervalStartDateStaticControl
            /// </summary>
            public const string SearchTimeIntervalStartDateStaticControl = "startDateLabel";
            
            /// <summary>
            /// Control ID for IncludeObjectsFromTheFollowingManagementGroupsStaticControl
            /// </summary>
            public const string IncludeObjectsFromTheFollowingManagementGroupsStaticControl = "groupLabel";
            
            /// <summary>
            /// Control ID for TypeNameListBox
            /// </summary>
            public const string TypeNameListBox = "groupEditor";
            
            /// <summary>
            /// Control ID for SearchTimeIntervalStartDateComboBox
            /// </summary>
            public const string SearchTimeIntervalStartDateComboBox = "startDateEditor";
            
            /// <summary>
            /// Control ID for SearchTimeIntervalEndDateComboBox
            /// </summary>
            public const string SearchTimeIntervalEndDateComboBox = "endDateEditor";
            
            /// <summary>
            /// Control ID for SearchTimeIntervalEndDateStaticControl
            /// </summary>
            public const string SearchTimeIntervalEndDateStaticControl = "endDateLabel";
        }
        #endregion
    }
}