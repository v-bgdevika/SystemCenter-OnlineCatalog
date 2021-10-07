// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OverrideProperties.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Overrides Property Dialog
// </summary>
// <history>
// 	[ruhim] 9/7/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Overrides.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IOverridePropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOverridePropertiesControls, for OverrideProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 9/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOverridePropertiesControls
    {
        /// <summary>
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
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
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access SelectDestinationManagementPackComboBox
        /// </summary>
        ComboBox SelectDestinationManagementPackComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DetailsStaticControl
        /// </summary>
        StaticControl DetailsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OverrideControlledParametersStaticControl
        /// </summary>
        StaticControl OverrideControlledParametersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ShowMonitorPropertiesButton
        /// </summary>
        Button ShowMonitorPropertiesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataGridView1
        /// </summary>
        PropertyGridView DataGridView1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TypeHealthServiceStaticControl
        /// </summary>
        StaticControl TypeHealthServiceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OverridesTargetStaticControl
        /// </summary>
        StaticControl OverridesTargetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditStaticControl
        /// </summary>
        StaticControl EditStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionStaticControl
        /// </summary>
        StaticControl DescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnabledStaticControl
        /// </summary>
        StaticControl EnabledStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StateCollectionStaticControl
        /// </summary>
        StaticControl StateCollectionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AuditCollectionAvailabilityStaticControl
        /// </summary>
        StaticControl AuditCollectionAvailabilityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CategoryStaticControl
        /// </summary>
        StaticControl CategoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorNameStaticControl
        /// </summary>
        StaticControl MonitorNameStaticControl
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
    /// 	[ruhim] 9/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class OverrideProperties : Dialog, IOverridePropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to DetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OverrideControlledParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOverrideControlledParametersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ShowMonitorPropertiesButton of type Button
        /// </summary>
        private Button cachedShowMonitorPropertiesButton;
        
        /// <summary>
        /// Cache to hold a reference to DataGridView1 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataGridView1;
        
        /// <summary>
        /// Cache to hold a reference to TypeHealthServiceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTypeHealthServiceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OverridesTargetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOverridesTargetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EditStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEditStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnabledStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnabledStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StateCollectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStateCollectionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AuditCollectionAvailabilityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAuditCollectionAvailabilityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CategoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCategoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitorNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorNameStaticControl;

        /// <summary>
        /// Cache to hold a reference to SelectDestinationManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectDestinationManagementPackComboBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OverrideProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OverrideProperties(ConsoleApp app)
            : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IOverrideProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOverridePropertiesControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridePropertiesControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, OverrideProperties.ControlIDs.HelpButton);
                }
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridePropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, OverrideProperties.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridePropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, OverrideProperties.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridePropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, OverrideProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectDestinationManagementPackComboBox control
        /// </summary>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IOverridePropertiesControls.SelectDestinationManagementPackComboBox
        {
            get
            {
                if ((this.cachedSelectDestinationManagementPackComboBox == null))
                {
                    this.cachedSelectDestinationManagementPackComboBox = new ComboBox(this, OverrideProperties.ControlIDs.SelectDestinationManagementPackComboBox);
                }
                return this.cachedSelectDestinationManagementPackComboBox;
            }
        }
       
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.DetailsStaticControl
        {
            get
            {
                if ((this.cachedDetailsStaticControl == null))
                {
                    this.cachedDetailsStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.DetailsStaticControl);
                }
                return this.cachedDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OverrideControlledParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.OverrideControlledParametersStaticControl
        {
            get
            {
                if ((this.cachedOverrideControlledParametersStaticControl == null))
                {
                    this.cachedOverrideControlledParametersStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.OverrideControlledParametersStaticControl);
                }
                return this.cachedOverrideControlledParametersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowMonitorPropertiesButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IOverridePropertiesControls.ShowMonitorPropertiesButton
        {
            get
            {
                if ((this.cachedShowMonitorPropertiesButton == null))
                {
                    this.cachedShowMonitorPropertiesButton = new Button(this, OverrideProperties.ControlIDs.ShowMonitorPropertiesButton);
                }
                return this.cachedShowMonitorPropertiesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IOverridePropertiesControls.DataGridView1
        {
            get
            {
                if ((this.cachedDataGridView1 == null))
                {
                    this.cachedDataGridView1 = new PropertyGridView(this, OverrideProperties.ControlIDs.DataGridView1);
                }
                return this.cachedDataGridView1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TypeHealthServiceStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.TypeHealthServiceStaticControl
        {
            get
            {
                if ((this.cachedTypeHealthServiceStaticControl == null))
                {
                    this.cachedTypeHealthServiceStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.TypeHealthServiceStaticControl);
                }
                return this.cachedTypeHealthServiceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OverridesTargetStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.OverridesTargetStaticControl
        {
            get
            {
                if ((this.cachedOverridesTargetStaticControl == null))
                {
                    this.cachedOverridesTargetStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.OverridesTargetStaticControl);
                }
                return this.cachedOverridesTargetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.EditStaticControl
        {
            get
            {
                if ((this.cachedEditStaticControl == null))
                {
                    this.cachedEditStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.EditStaticControl);
                }
                return this.cachedEditStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.DescriptionStaticControl
        {
            get
            {
                if ((this.cachedDescriptionStaticControl == null))
                {
                    this.cachedDescriptionStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.DescriptionStaticControl);
                }
                return this.cachedDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnabledStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.EnabledStaticControl
        {
            get
            {
                if ((this.cachedEnabledStaticControl == null))
                {
                    this.cachedEnabledStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.EnabledStaticControl);
                }
                return this.cachedEnabledStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StateCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.StateCollectionStaticControl
        {
            get
            {
                if ((this.cachedStateCollectionStaticControl == null))
                {
                    this.cachedStateCollectionStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.StateCollectionStaticControl);
                }
                return this.cachedStateCollectionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuditCollectionAvailabilityStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.AuditCollectionAvailabilityStaticControl
        {
            get
            {
                if ((this.cachedAuditCollectionAvailabilityStaticControl == null))
                {
                    this.cachedAuditCollectionAvailabilityStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.AuditCollectionAvailabilityStaticControl);
                }
                return this.cachedAuditCollectionAvailabilityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CategoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.CategoryStaticControl
        {
            get
            {
                if ((this.cachedCategoryStaticControl == null))
                {
                    this.cachedCategoryStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.CategoryStaticControl);
                }
                return this.cachedCategoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOverridePropertiesControls.MonitorNameStaticControl
        {
            get
            {
                if ((this.cachedMonitorNameStaticControl == null))
                {
                    this.cachedMonitorNameStaticControl = new StaticControl(this, OverrideProperties.ControlIDs.MonitorNameStaticControl);
                }
                return this.cachedMonitorNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ShowMonitorProperties
        /// </summary>
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickShowMonitorProperties()
        {
            this.Controls.ShowMonitorPropertiesButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 10;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[ruhim] 9/7/2006 Created
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
                ";Override Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Overrides.OverridesDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";&Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelHelpForm;buttonHe" +
                "lp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Details
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDetails = ";Details:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Details" +
                "ViewName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OverrideControlledParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOverrideControlledParameters = ";&Override-controlled parameters:;ManagedString;Microsoft.MOM.UI.Components.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Overrides.OverridesControl;paramsText." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ShowMonitorProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceShowMonitorProperties = ";&Show monitor properties...;ManagedString;Microsoft.MOM.UI.Components.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources;ShowMonito" +
                "rProperties";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGridView1 = ";dataGridView1;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappingP" +
                "age;statesGridView.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TypeHealthService
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTypeHealthService = "Type: Health Service";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OverridesTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOverridesTarget = ";Overrides target:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Overrides.OverridesControl;valueTypeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEdit = ";E&dit...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;editButton.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDescription = ";Description;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;M" +
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;View" +
                "ColumnDescription";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Enabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnabled = ";Enabled;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.Lob.LobTemplateResource;Enabled" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StateCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStateCollection = ";State Collection;ManagedString;Microsoft.EnterpriseManagement.UI.Administration." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.N" +
                "otificationResource;StateCollection";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuditCollectionAvailability
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuditCollectionAvailability = "Audit Collection Availability";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Category
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCategory = ";Category:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Overrides.OverridesControl;categoryLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorName = ";Monitor name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Internal.UI.Overrides.OverridesControl;objectNameLabel.Text";
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
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Details
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OverrideControlledParameters
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverrideControlledParameters;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ShowMonitorProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowMonitorProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataGridView1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TypeHealthService
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTypeHealthService;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OverridesTarget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOverridesTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Description
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDescription;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Enabled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnabled;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StateCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStateCollection;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuditCollectionAvailability
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuditCollectionAvailability;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Category
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCategory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorName;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
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
            /// Exposes access to the Details translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Details
            {
                get
                {
                    if ((cachedDetails == null))
                    {
                        cachedDetails = CoreManager.MomConsole.GetIntlStr(ResourceDetails);
                    }
                    return cachedDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OverrideControlledParameters translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OverrideControlledParameters
            {
                get
                {
                    if ((cachedOverrideControlledParameters == null))
                    {
                        cachedOverrideControlledParameters = CoreManager.MomConsole.GetIntlStr(ResourceOverrideControlledParameters);
                    }
                    return cachedOverrideControlledParameters;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowMonitorProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowMonitorProperties
            {
                get
                {
                    if ((cachedShowMonitorProperties == null))
                    {
                        cachedShowMonitorProperties = CoreManager.MomConsole.GetIntlStr(ResourceShowMonitorProperties);
                    }
                    return cachedShowMonitorProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataGridView1
            {
                get
                {
                    if ((cachedDataGridView1 == null))
                    {
                        cachedDataGridView1 = CoreManager.MomConsole.GetIntlStr(ResourceDataGridView1);
                    }
                    return cachedDataGridView1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TypeHealthService translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TypeHealthService
            {
                get
                {
                    if ((cachedTypeHealthService == null))
                    {
                        cachedTypeHealthService = CoreManager.MomConsole.GetIntlStr(ResourceTypeHealthService);
                    }
                    return cachedTypeHealthService;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OverridesTarget translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OverridesTarget
            {
                get
                {
                    if ((cachedOverridesTarget == null))
                    {
                        cachedOverridesTarget = CoreManager.MomConsole.GetIntlStr(ResourceOverridesTarget);
                    }
                    return cachedOverridesTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Edit
            {
                get
                {
                    if ((cachedEdit == null))
                    {
                        cachedEdit = CoreManager.MomConsole.GetIntlStr(ResourceEdit);
                    }
                    return cachedEdit;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Description translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Description
            {
                get
                {
                    if ((cachedDescription == null))
                    {
                        cachedDescription = CoreManager.MomConsole.GetIntlStr(ResourceDescription);
                    }
                    return cachedDescription;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Enabled translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Enabled
            {
                get
                {
                    if ((cachedEnabled == null))
                    {
                        cachedEnabled = CoreManager.MomConsole.GetIntlStr(ResourceEnabled);
                    }
                    return cachedEnabled;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StateCollection translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateCollection
            {
                get
                {
                    if ((cachedStateCollection == null))
                    {
                        cachedStateCollection = CoreManager.MomConsole.GetIntlStr(ResourceStateCollection);
                    }
                    return cachedStateCollection;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuditCollectionAvailability translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuditCollectionAvailability
            {
                get
                {
                    if ((cachedAuditCollectionAvailability == null))
                    {
                        cachedAuditCollectionAvailability = CoreManager.MomConsole.GetIntlStr(ResourceAuditCollectionAvailability);
                    }
                    return cachedAuditCollectionAvailability;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Category translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Category
            {
                get
                {
                    if ((cachedCategory == null))
                    {
                        cachedCategory = CoreManager.MomConsole.GetIntlStr(ResourceCategory);
                    }
                    return cachedCategory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitorName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 9/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorName
            {
                get
                {
                    if ((cachedMonitorName == null))
                    {
                        cachedMonitorName = CoreManager.MomConsole.GetIntlStr(ResourceMonitorName);
                    }
                    return cachedMonitorName;
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
        /// 	[ruhim] 9/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "helpBtn";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for SelectDestinationManagementPackComboBox
            /// </summary>
            public const string SelectDestinationManagementPackComboBox = "comboBoxMp";

            /// <summary>
            /// Control ID for DetailsStaticControl
            /// </summary>
            public const string DetailsStaticControl = "detailsLabel";
            
            /// <summary>
            /// Control ID for OverrideControlledParametersStaticControl
            /// </summary>
            public const string OverrideControlledParametersStaticControl = "paramsText";
            
            /// <summary>
            /// Control ID for ShowMonitorPropertiesButton
            /// </summary>
            public const string ShowMonitorPropertiesButton = "showPropertiesBtn";
            
            /// <summary>
            /// Control ID for DataGridView1
            /// </summary>
            public const string DataGridView1 = "overridesDataGridView";
            
            /// <summary>
            /// Control ID for TypeHealthServiceStaticControl
            /// </summary>
            public const string TypeHealthServiceStaticControl = "targetTextLabel";
            
            /// <summary>
            /// Control ID for OverridesTargetStaticControl
            /// </summary>
            public const string OverridesTargetStaticControl = "valueTypeLabel";
            
            /// <summary>
            /// Control ID for EditStaticControl
            /// </summary>
            public const string EditStaticControl = "editDescLabel";
            
            /// <summary>
            /// Control ID for DescriptionStaticControl
            /// </summary>
            public const string DescriptionStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for EnabledStaticControl
            /// </summary>
            public const string EnabledStaticControl = "paramNameLabel";
            
            /// <summary>
            /// Control ID for StateCollectionStaticControl
            /// </summary>
            public const string StateCollectionStaticControl = "categoryTextLabel";
            
            /// <summary>
            /// Control ID for AuditCollectionAvailabilityStaticControl
            /// </summary>
            public const string AuditCollectionAvailabilityStaticControl = "objectTextLabel";
            
            /// <summary>
            /// Control ID for CategoryStaticControl
            /// </summary>
            public const string CategoryStaticControl = "categoryLabel";
            
            /// <summary>
            /// Control ID for MonitorNameStaticControl
            /// </summary>
            public const string MonitorNameStaticControl = "objectNameLabel";
        }
        #endregion
    }
}
