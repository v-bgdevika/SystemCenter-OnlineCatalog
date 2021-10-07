// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceLevelObjectiveMonitorStateDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 9/27/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IServiceLevelObjectiveMonitorStateDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceLevelObjectiveMonitorStateDialogControls, for ServiceLevelObjectiveMonitorStateDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 9/27/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceLevelObjectiveMonitorStateDialogControls
    {
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
        /// Read-only property to access CriticalCheckBox
        /// </summary>
        CheckBox CriticalCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UnplannedMaintenanceCheckBox
        /// </summary>
        CheckBox UnplannedMaintenanceCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UnmonitoredCheckBox
        /// </summary>
        CheckBox UnmonitoredCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorDisabledCheckBox
        /// </summary>
        CheckBox MonitorDisabledCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PlannedMaintenanceCheckBox
        /// </summary>
        CheckBox PlannedMaintenanceCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitoringUnavailableCheckBox
        /// </summary>
        CheckBox MonitoringUnavailableCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningCheckBox
        /// </summary>
        CheckBox WarningCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl
        /// </summary>
        StaticControl SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectiveGoalComboBox
        /// </summary>
        EditComboBox ServiceLevelObjectiveGoalComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectiveGoalStaticControl
        /// </summary>
        StaticControl ServiceLevelObjectiveGoalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorComboBox
        /// </summary>
        ComboBox MonitorComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorStaticControl
        /// </summary>
        StaticControl MonitorStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectButton
        /// </summary>
        Button SelectButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetedClassTextBox
        /// </summary>
        TextBox TargetedClassTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetedClassStaticControl
        /// </summary>
        StaticControl TargetedClassStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectiveNameTextBox
        /// </summary>
        TextBox ServiceLevelObjectiveNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectiveNameStaticControl
        /// </summary>
        StaticControl ServiceLevelObjectiveNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl
        /// </summary>
        StaticControl EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl
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
    /// 	[dialac] 9/27/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServiceLevelObjectiveMonitorStateDialog : Dialog, IServiceLevelObjectiveMonitorStateDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to CriticalCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedCriticalCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to UnplannedMaintenanceCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUnplannedMaintenanceCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to UnmonitoredCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUnmonitoredCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MonitorDisabledCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMonitorDisabledCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to PlannedMaintenanceCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedPlannedMaintenanceCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringUnavailableCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMonitoringUnavailableCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to WarningCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedWarningCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectiveGoalComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedServiceLevelObjectiveGoalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectiveGoalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectiveGoalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitorComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMonitorComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MonitorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectButton of type Button
        /// </summary>
        private Button cachedSelectButton;
        
        /// <summary>
        /// Cache to hold a reference to TargetedClassTextBox of type TextBox
        /// </summary>
        private TextBox cachedTargetedClassTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TargetedClassStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTargetedClassStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectiveNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceLevelObjectiveNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectiveNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectiveNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceLevelObjectiveMonitorStateDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceLevelObjectiveMonitorStateDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IServiceLevelObjectiveMonitorStateDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceLevelObjectiveMonitorStateDialogControls Controls
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
        ///  Property to handle checkbox Critical
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Critical
        {
            get
            {
                return this.Controls.CriticalCheckBox.Checked;
            }
            
            set
            {
                this.Controls.CriticalCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox UnplannedMaintenance
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UnplannedMaintenance
        {
            get
            {
                return this.Controls.UnplannedMaintenanceCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UnplannedMaintenanceCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Unmonitored
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Unmonitored
        {
            get
            {
                return this.Controls.UnmonitoredCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UnmonitoredCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox MonitorDisabled
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MonitorDisabled
        {
            get
            {
                return this.Controls.MonitorDisabledCheckBox.Checked;
            }
            
            set
            {
                this.Controls.MonitorDisabledCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox PlannedMaintenance
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool PlannedMaintenance
        {
            get
            {
                return this.Controls.PlannedMaintenanceCheckBox.Checked;
            }
            
            set
            {
                this.Controls.PlannedMaintenanceCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox MonitoringUnavailable
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool MonitoringUnavailable
        {
            get
            {
                return this.Controls.MonitoringUnavailableCheckBox.Checked;
            }
            
            set
            {
                this.Controls.MonitoringUnavailableCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Warning
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Warning
        {
            get
            {
                return this.Controls.WarningCheckBox.Checked;
            }
            
            set
            {
                this.Controls.WarningCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ServiceLevelObjectiveGoal
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceLevelObjectiveGoalText
        {
            get
            {
                return this.Controls.ServiceLevelObjectiveGoalComboBox.Text;
            }
            
            set
            {
                this.Controls.ServiceLevelObjectiveGoalComboBox.Text = value; 
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Monitor
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MonitorText
        {
            get
            {
                return this.Controls.MonitorComboBox.Text;
            }
            
            set
            {
                // If the value isn't already set, then we'll set it.
                if (string.Compare(this.Controls.MonitorComboBox.Text, value) != 0)
                {
                    this.Controls.MonitorComboBox.Click();
                    Sleeper.Delay(5000);

                    Core.Common.Utilities.LogMessage("MonitorText:: Find DropDown Window");
                    Window windowTemp = new Window(WindowType.Active).Extended.AccessibleObject.FindChild("DropDown").Window;

                    Core.Common.Utilities.LogMessage("MonitorText:: Found DropDown Window");

                    TreeView monitorTree = new TreeView(
                        windowTemp,
                        "*",
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinFormsTreeView,
                        StringMatchSyntax.WildCard);

                    Core.Common.Utilities.LogMessage("MonitorText:: RootNode: " + monitorTree.Root.Text);
                    //CoreManager.MomConsole.ExpandTreePath(value, monitorTree).Click();
                    int retry = 0; 
                    int maxRetry = 3;
                    while (retry < maxRetry)
                    {
                        try
                        {
                            TreeNode node = monitorTree.Find(value, 1, false, SearchMode.DepthFirst, true);
                            node.Click();
                            Core.Common.Utilities.LogMessage("**********DIALAC found the node");
                            break;
                        }

                        catch (TreeNode.Exceptions.NodeNotFoundException)
                        {
                            retry++;
                            Core.Common.Utilities.LogMessage("**********DIALAC Got the exception " + retry.ToString());
                        }
                    }
                }
                //this.Controls.MonitorComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TargetedClass
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TargetedClassText
        {
            get
            {
                return this.Controls.TargetedClassTextBox.Text;
            }
            
            set
            {
                this.Controls.TargetedClassTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ServiceLevelObjectiveName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceLevelObjectiveNameText
        {
            get
            {
                return this.Controls.ServiceLevelObjectiveNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ServiceLevelObjectiveNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelObjectiveMonitorStateDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelObjectiveMonitorStateDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriticalCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServiceLevelObjectiveMonitorStateDialogControls.CriticalCheckBox
        {
            get
            {
                if ((this.cachedCriticalCheckBox == null))
                {
                    this.cachedCriticalCheckBox = new CheckBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.CriticalCheckBox);
                }
                
                return this.cachedCriticalCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UnplannedMaintenanceCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServiceLevelObjectiveMonitorStateDialogControls.UnplannedMaintenanceCheckBox
        {
            get
            {
                if ((this.cachedUnplannedMaintenanceCheckBox == null))
                {
                    this.cachedUnplannedMaintenanceCheckBox = new CheckBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.UnplannedMaintenanceCheckBox);
                }
                
                return this.cachedUnplannedMaintenanceCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UnmonitoredCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServiceLevelObjectiveMonitorStateDialogControls.UnmonitoredCheckBox
        {
            get
            {
                if ((this.cachedUnmonitoredCheckBox == null))
                {
                    this.cachedUnmonitoredCheckBox = new CheckBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.UnmonitoredCheckBox);
                }
                
                return this.cachedUnmonitoredCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorDisabledCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServiceLevelObjectiveMonitorStateDialogControls.MonitorDisabledCheckBox
        {
            get
            {
                if ((this.cachedMonitorDisabledCheckBox == null))
                {
                    this.cachedMonitorDisabledCheckBox = new CheckBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.MonitorDisabledCheckBox);
                }
                
                return this.cachedMonitorDisabledCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PlannedMaintenanceCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServiceLevelObjectiveMonitorStateDialogControls.PlannedMaintenanceCheckBox
        {
            get
            {
                if ((this.cachedPlannedMaintenanceCheckBox == null))
                {
                    this.cachedPlannedMaintenanceCheckBox = new CheckBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.PlannedMaintenanceCheckBox);
                }
                
                return this.cachedPlannedMaintenanceCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringUnavailableCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServiceLevelObjectiveMonitorStateDialogControls.MonitoringUnavailableCheckBox
        {
            get
            {
                if ((this.cachedMonitoringUnavailableCheckBox == null))
                {
                    this.cachedMonitoringUnavailableCheckBox = new CheckBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.MonitoringUnavailableCheckBox);
                }
                
                return this.cachedMonitoringUnavailableCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WarningCheckBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IServiceLevelObjectiveMonitorStateDialogControls.WarningCheckBox
        {
            get
            {
                if ((this.cachedWarningCheckBox == null))
                {
                    this.cachedWarningCheckBox = new CheckBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.WarningCheckBox);
                }
                
                return this.cachedWarningCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveMonitorStateDialogControls.SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl == null))
                {
                    this.cachedSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl = new StaticControl(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl);
                }
                
                return this.cachedSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectiveGoalComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IServiceLevelObjectiveMonitorStateDialogControls.ServiceLevelObjectiveGoalComboBox
        {
            get
            {
                if ((this.cachedServiceLevelObjectiveGoalComboBox == null))
                {
                    this.cachedServiceLevelObjectiveGoalComboBox = new EditComboBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.ServiceLevelObjectiveGoalComboBox);
                }
                
                return this.cachedServiceLevelObjectiveGoalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectiveGoalStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveMonitorStateDialogControls.ServiceLevelObjectiveGoalStaticControl
        {
            get
            {
                if ((this.cachedServiceLevelObjectiveGoalStaticControl == null))
                {
                    this.cachedServiceLevelObjectiveGoalStaticControl = new StaticControl(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.ServiceLevelObjectiveGoalStaticControl);
                }
                
                return this.cachedServiceLevelObjectiveGoalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IServiceLevelObjectiveMonitorStateDialogControls.MonitorComboBox
        {
            get
            {
                this.cachedMonitorComboBox = new ComboBox
                    (this, "*", StringMatchSyntax.WildCard, 
                    WindowClassNames.WinFormsComboBox, StringMatchSyntax.WildCard);
                //if ((this.cachedMonitorComboBox == null))
                //{

                //    Window wndTemp = this;

                //    // Required to navigate to control
                //    wndTemp = wndTemp.Extended.FirstChild;
                //    int i;
                //    for (i = 0; (i <= 11); i = (i + 1))
                //    {
                //        wndTemp = wndTemp.Extended.NextSibling;
                //    }

                //    this.cachedMonitorComboBox = new ComboBox(wndTemp);
                //}
                
                return this.cachedMonitorComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveMonitorStateDialogControls.MonitorStaticControl
        {
            get
            {
                if ((this.cachedMonitorStaticControl == null))
                {
                    this.cachedMonitorStaticControl = new StaticControl(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.MonitorStaticControl);
                }
                
                return this.cachedMonitorStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelObjectiveMonitorStateDialogControls.SelectButton
        {
            get
            {
                if ((this.cachedSelectButton == null))
                {
                    this.cachedSelectButton = new Button(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.SelectButton);
                }
                
                return this.cachedSelectButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetedClassTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelObjectiveMonitorStateDialogControls.TargetedClassTextBox
        {
            get
            {
                if ((this.cachedTargetedClassTextBox == null))
                {
                    this.cachedTargetedClassTextBox = new TextBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.TargetedClassTextBox);
                }
                
                return this.cachedTargetedClassTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetedClassStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveMonitorStateDialogControls.TargetedClassStaticControl
        {
            get
            {
                if ((this.cachedTargetedClassStaticControl == null))
                {
                    this.cachedTargetedClassStaticControl = new StaticControl(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.TargetedClassStaticControl);
                }
                
                return this.cachedTargetedClassStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectiveNameTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelObjectiveMonitorStateDialogControls.ServiceLevelObjectiveNameTextBox
        {
            get
            {
                if ((this.cachedServiceLevelObjectiveNameTextBox == null))
                {
                    this.cachedServiceLevelObjectiveNameTextBox = new TextBox(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.ServiceLevelObjectiveNameTextBox);
                }
                
                return this.cachedServiceLevelObjectiveNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectiveNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveMonitorStateDialogControls.ServiceLevelObjectiveNameStaticControl
        {
            get
            {
                if ((this.cachedServiceLevelObjectiveNameStaticControl == null))
                {
                    this.cachedServiceLevelObjectiveNameStaticControl = new StaticControl(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.ServiceLevelObjectiveNameStaticControl);
                }
                
                return this.cachedServiceLevelObjectiveNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveMonitorStateDialogControls.EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl
        {
            get
            {
                if ((this.cachedEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl == null))
                {
                    this.cachedEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl = new StaticControl(this, ServiceLevelObjectiveMonitorStateDialog.ControlIDs.EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl);
                }
                
                return this.cachedEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
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
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Critical
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCritical()
        {
            this.Controls.CriticalCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button UnplannedMaintenance
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUnplannedMaintenance()
        {
            this.Controls.UnplannedMaintenanceCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Unmonitored
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUnmonitored()
        {
            this.Controls.UnmonitoredCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MonitorDisabled
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMonitorDisabled()
        {
            this.Controls.MonitorDisabledCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button PlannedMaintenance
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPlannedMaintenance()
        {
            this.Controls.PlannedMaintenanceCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MonitoringUnavailable
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMonitoringUnavailable()
        {
            this.Controls.MonitoringUnavailableCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Warning
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickWarning()
        {
            this.Controls.WarningCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select
        /// </summary>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelect()
        {
            this.Controls.SelectButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 9/27/2008 Created
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
        /// 	[dialac] 9/27/2008 Created
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
            private const string ResourceDialogTitle = @";Service Level Objective (Monitor State);ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Critical
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCritical = ";Critical;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.Notificat" +
                "ionResource;Error";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UnplannedMaintenance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUnplannedMaintenance = ";&Unplanned maintenance;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDi" +
                "alog;unplannedMaintenanceMark.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Unmonitored
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUnmonitored = ";U&nmonitored;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;unmon" +
                "itoredMark.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorDisabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorDisabled = ";Monitor &disabled;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;" +
                "monitorDisabledMark.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PlannedMaintenance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlannedMaintenance = ";&Planned maintenance;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDial" +
                "og;plannedMaintenanceMark.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitoringUnavailable
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringUnavailable = ";M&onitoring unavailable;ManagedString;Microsoft.EnterpriseManagement.UI.Authorin" +
                "g.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloD" +
                "ialog;monitoringUnavailableMark.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Warning
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWarning = ";&Warning;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;warningMa" +
                "rk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective = ";Specify the states you want to be counted as downtime in this objective:;Managed" +
                "String;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;statesLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectiveGoal
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectiveGoal = ";Service level objective &goal (%):;ManagedString;Microsoft.EnterpriseManagement." +
                "UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla." +
                "MonitorSloDialog;goalLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitor = ";&Monitor:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;monitorL" +
                "abel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelect = ";&Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;browseBut" +
                "ton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetedClass = ";&Targeted class;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;ta" +
                "rgetLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectiveName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectiveName = ";&Service level objective name:;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "uthoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.Moni" +
                "torSloDialog;sloNameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack = ";Enter a name for the SLO and then set the desired thresholds or states to track." +
                ";ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;nameSectionTitle." +
                "Text";
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
            /// Caches the translated resource string for:  Critical
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCritical;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UnplannedMaintenance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUnplannedMaintenance;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Unmonitored
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUnmonitored;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorDisabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorDisabled;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PlannedMaintenance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlannedMaintenance;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitoringUnavailable
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringUnavailable;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Warning
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWarning;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectiveGoal
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectiveGoal;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelect;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetedClass;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectiveName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectiveName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
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
            /// 	[dialac] 9/27/2008 Created
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
            /// Exposes access to the Critical translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Critical
            {
                get
                {
                    if ((cachedCritical == null))
                    {
                        cachedCritical = CoreManager.MomConsole.GetIntlStr(ResourceCritical);
                    }
                    
                    return cachedCritical;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UnplannedMaintenance translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UnplannedMaintenance
            {
                get
                {
                    if ((cachedUnplannedMaintenance == null))
                    {
                        cachedUnplannedMaintenance = CoreManager.MomConsole.GetIntlStr(ResourceUnplannedMaintenance);
                    }
                    
                    return cachedUnplannedMaintenance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Unmonitored translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Unmonitored
            {
                get
                {
                    if ((cachedUnmonitored == null))
                    {
                        cachedUnmonitored = CoreManager.MomConsole.GetIntlStr(ResourceUnmonitored);
                    }
                    
                    return cachedUnmonitored;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitorDisabled translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorDisabled
            {
                get
                {
                    if ((cachedMonitorDisabled == null))
                    {
                        cachedMonitorDisabled = CoreManager.MomConsole.GetIntlStr(ResourceMonitorDisabled);
                    }
                    
                    return cachedMonitorDisabled;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PlannedMaintenance translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PlannedMaintenance
            {
                get
                {
                    if ((cachedPlannedMaintenance == null))
                    {
                        cachedPlannedMaintenance = CoreManager.MomConsole.GetIntlStr(ResourcePlannedMaintenance);
                    }
                    
                    return cachedPlannedMaintenance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitoringUnavailable translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringUnavailable
            {
                get
                {
                    if ((cachedMonitoringUnavailable == null))
                    {
                        cachedMonitoringUnavailable = CoreManager.MomConsole.GetIntlStr(ResourceMonitoringUnavailable);
                    }
                    
                    return cachedMonitoringUnavailable;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Warning translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Warning
            {
                get
                {
                    if ((cachedWarning == null))
                    {
                        cachedWarning = CoreManager.MomConsole.GetIntlStr(ResourceWarning);
                    }
                    
                    return cachedWarning;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective
            {
                get
                {
                    if ((cachedSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective == null))
                    {
                        cachedSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective);
                    }
                    
                    return cachedSpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjective;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceLevelObjectiveGoal translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectiveGoal
            {
                get
                {
                    if ((cachedServiceLevelObjectiveGoal == null))
                    {
                        cachedServiceLevelObjectiveGoal = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectiveGoal);
                    }
                    
                    return cachedServiceLevelObjectiveGoal;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitor translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Monitor
            {
                get
                {
                    if ((cachedMonitor == null))
                    {
                        cachedMonitor = CoreManager.MomConsole.GetIntlStr(ResourceMonitor);
                    }
                    
                    return cachedMonitor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Select
            {
                get
                {
                    if ((cachedSelect == null))
                    {
                        cachedSelect = CoreManager.MomConsole.GetIntlStr(ResourceSelect);
                    }
                    
                    return cachedSelect;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TargetedClass translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetedClass
            {
                get
                {
                    if ((cachedTargetedClass == null))
                    {
                        cachedTargetedClass = CoreManager.MomConsole.GetIntlStr(ResourceTargetedClass);
                    }
                    
                    return cachedTargetedClass;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceLevelObjectiveName translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectiveName
            {
                get
                {
                    if ((cachedServiceLevelObjectiveName == null))
                    {
                        cachedServiceLevelObjectiveName = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectiveName);
                    }
                    
                    return cachedServiceLevelObjectiveName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/27/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack
            {
                get
                {
                    if ((cachedEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack == null))
                    {
                        cachedEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack = CoreManager.MomConsole.GetIntlStr(ResourceEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack);
                    }
                    
                    return cachedEnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrack;
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
        /// 	[dialac] 9/27/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for CriticalCheckBox
            /// </summary>
            public const string CriticalCheckBox = "criticalMark";
            
            /// <summary>
            /// Control ID for UnplannedMaintenanceCheckBox
            /// </summary>
            public const string UnplannedMaintenanceCheckBox = "unplannedMaintenanceMark";
            
            /// <summary>
            /// Control ID for UnmonitoredCheckBox
            /// </summary>
            public const string UnmonitoredCheckBox = "unmonitoredMark";
            
            /// <summary>
            /// Control ID for MonitorDisabledCheckBox
            /// </summary>
            public const string MonitorDisabledCheckBox = "monitorDisabledMark";
            
            /// <summary>
            /// Control ID for PlannedMaintenanceCheckBox
            /// </summary>
            public const string PlannedMaintenanceCheckBox = "plannedMaintenanceMark";
            
            /// <summary>
            /// Control ID for MonitoringUnavailableCheckBox
            /// </summary>
            public const string MonitoringUnavailableCheckBox = "monitoringUnavailableMark";
            
            /// <summary>
            /// Control ID for WarningCheckBox
            /// </summary>
            public const string WarningCheckBox = "warningMark";
            
            /// <summary>
            /// Control ID for SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl
            /// </summary>
            public const string SpecifyTheStatesYouWantToBeCountedAsDowntimeInThisObjectiveStaticControl = "statesLabel";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectiveGoalComboBox
            /// </summary>
            public const string ServiceLevelObjectiveGoalComboBox = "goalUpDown";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectiveGoalStaticControl
            /// </summary>
            public const string ServiceLevelObjectiveGoalStaticControl = "goalLabel";
            
            /// <summary>
            /// Control ID for MonitorStaticControl
            /// </summary>
            public const string MonitorStaticControl = "monitorLabel";
            
            /// <summary>
            /// Control ID for SelectButton
            /// </summary>
            public const string SelectButton = "browseButton";
            
            /// <summary>
            /// Control ID for TargetedClassTextBox
            /// </summary>
            public const string TargetedClassTextBox = "targetBox";
            
            /// <summary>
            /// Control ID for TargetedClassStaticControl
            /// </summary>
            public const string TargetedClassStaticControl = "targetLabel";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectiveNameTextBox
            /// </summary>
            public const string ServiceLevelObjectiveNameTextBox = "sloName";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectiveNameStaticControl
            /// </summary>
            public const string ServiceLevelObjectiveNameStaticControl = "sloNameLabel";
            
            /// <summary>
            /// Control ID for EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl
            /// </summary>
            public const string EnterANameForTheSLOAndThenSetTheDesiredThresholdsOrStatesToTrackStaticControl = "nameSectionTitle";
        }
        #endregion
    }
}
