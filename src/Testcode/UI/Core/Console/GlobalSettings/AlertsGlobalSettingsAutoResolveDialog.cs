// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertsGlobalSettingsAutoResolveDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 9/21/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAlertsGlobalSettingsAutoResolveDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertsGlobalSettingsAutoResolveDialogControls, for AlertsGlobalSettingsAutoResolveDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 9/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertsGlobalSettingsAutoResolveDialogControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DaysStaticControl
        /// </summary>
        StaticControl DaysStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DaysStaticControl2
        /// </summary>
        StaticControl DaysStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutoResolveAlertSettingsStaticControl
        /// </summary>
        StaticControl AutoResolveAlertSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NumericUpDownHealthy
        /// </summary>
        ComboBox NumericUpDownHealthy
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NumericUpDownNew
        /// </summary>
        ComboBox NumericUpDownNew
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl
        /// </summary>
        StaticControl ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl
        /// </summary>
        StaticControl ResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso
        /// </summary>
        StaticControl AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso
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
    /// 	[lucyra] 9/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AlertsGlobalSettingsAutoResolveDialog : Dialog, IAlertsGlobalSettingsAutoResolveDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;
        
        /// <summary>
        /// Cache to hold a reference to DaysStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDaysStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DaysStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedDaysStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to AutoResolveAlertSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAutoResolveAlertSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NumericUpDownHealthy of type ComboBox
        /// </summary>
        private ComboBox cachedNumericUpDownHealthy;
        
        /// <summary>
        /// Cache to hold a reference to NumericUpDownNew of type ComboBox
        /// </summary>
        private ComboBox cachedNumericUpDownNew;
        
        /// <summary>
        /// Cache to hold a reference to ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso of type StaticControl
        /// </summary>
        private StaticControl cachedAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertsGlobalSettingsAutoResolveDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertsGlobalSettingsAutoResolveDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertsGlobalSettingsAutoResolveDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertsGlobalSettingsAutoResolveDialogControls Controls
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
        ///  Routine to set/get the text in control ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterText
        {
            get
            {
                return this.Controls.NumericUpDownHealthy.Text;
            }
            
            set
            {
                this.Controls.NumericUpDownHealthy.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NumericUpDownNew
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NumericUpDownNewText
        {
            get
            {
                return this.Controls.NumericUpDownNew.Text;
            }
            
            set
            {
                this.Controls.NumericUpDownNew.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsAutoResolveDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsAutoResolveDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsAutoResolveDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertsGlobalSettingsAutoResolveDialogControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.Tab2TabControl);
                }
                
                return this.cachedTab2TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DaysStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsAutoResolveDialogControls.DaysStaticControl
        {
            get
            {
                if ((this.cachedDaysStaticControl == null))
                {
                    this.cachedDaysStaticControl = new StaticControl(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.DaysStaticControl);
                }
                
                return this.cachedDaysStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DaysStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsAutoResolveDialogControls.DaysStaticControl2
        {
            get
            {
                if ((this.cachedDaysStaticControl2 == null))
                {
                    this.cachedDaysStaticControl2 = new StaticControl(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.DaysStaticControl2);
                }
                
                return this.cachedDaysStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoResolveAlertSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsAutoResolveDialogControls.AutoResolveAlertSettingsStaticControl
        {
            get
            {
                if ((this.cachedAutoResolveAlertSettingsStaticControl == null))
                {
                    this.cachedAutoResolveAlertSettingsStaticControl = new StaticControl(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.AutoResolveAlertSettingsStaticControl);
                }
                
                return this.cachedAutoResolveAlertSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumericUpDownHealthy control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertsGlobalSettingsAutoResolveDialogControls.NumericUpDownHealthy
        {
            get
            {
                if ((this.cachedNumericUpDownHealthy == null))
                {
                    this.cachedNumericUpDownHealthy = new ComboBox(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.NumericUpDownHealthy);
                }
                
                return this.cachedNumericUpDownHealthy;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumericUpDownNew control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAlertsGlobalSettingsAutoResolveDialogControls.NumericUpDownNew
        {
            get
            {
                if ((this.cachedNumericUpDownNew == null))
                {
                    this.cachedNumericUpDownNew = new ComboBox(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.NumericUpDownNew);
                }
                
                return this.cachedNumericUpDownNew;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsAutoResolveDialogControls.ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl
        {
            get
            {
                if ((this.cachedResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl == null))
                {
                    this.cachedResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl = new StaticControl(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl);
                }
                
                return this.cachedResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsAutoResolveDialogControls.ResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl
        {
            get
            {
                if ((this.cachedResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl == null))
                {
                    this.cachedResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl = new StaticControl(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.ResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl);
                }
                
                return this.cachedResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsAutoResolveDialogControls.AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso
        {
            get
            {
                if ((this.cachedAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso == null))
                {
                    this.cachedAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso = new StaticControl(this, AlertsGlobalSettingsAutoResolveDialog.ControlIDs.AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso);
                }
                
                return this.cachedAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
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
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
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
                    StringMatchSyntax.ExactMatch);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                Common.Utilities.LogMessage(
                    "Looking for window with title:  '" +
                    Strings.DialogTitle +
                    "'");

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
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Common.Utilities.LogMessage("Failed to find Global Settings - Alerts dialog window!");

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
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix on MOM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogMomTitlePrefix = ";Global Management Group Settings -;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title prefix on SCE
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogSceTitlePrefix = ";Global Management Settings -;ManagedString;Microsoft.EnterpriseManagement.SCE.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.AdministrationSpace.AdminResources;GroupSettingsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitleSuffix = ";Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SettingsResources;GroupAlerts";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
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
            /// Contains resource string for:  Tab2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab2 = "Tab2";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Days
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDays = ";Days;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WeeklyScheduleControl;DaysColumn.HeaderText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Days2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDays2 = ";Days;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WeeklyScheduleControl;DaysColumn.HeaderText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoResolveAlertSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoResolveAlertSettings = ";Auto-Resolve Alert Settings:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolveAlerts;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter = ";Resolve all active alerts when the alert source is &healthy after:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolveAlerts;labelHealthy.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResolveAllActiveAlertsInTheNewResolutionStateAfter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResolveAllActiveAlertsInTheNewResolutionStateAfter = ";Re&solve all active alerts in the new resolution state after:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolveAlerts;labelNew.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso = @";After a period of time, active alerts which are no longer relevant can be automatically resolved. Once an alert is in a resolved state the alert can be groomed out of the MOM database.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolveAlerts;labelDescription.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title prefix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitlePrefix;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title suffix
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitleSuffix;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
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
            /// Caches the translated resource string for:  Tab2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Days
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDays;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Days2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDays2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutoResolveAlertSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoResolveAlertSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResolveAllActiveAlertsInTheNewResolutionStateAfter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolveAllActiveAlertsInTheNewResolutionStateAfter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            ///     [lucyra] 10/31/2006 Updated to support SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitlePrefix == null) || (cachedDialogTitleSuffix == null))
                    {
                        //if (ProductSku.Sku == ProductSkuLevel.Mom)
                        cachedDialogTitlePrefix = CoreManager.MomConsole.GetIntlStr(ResourceDialogMomTitlePrefix);
                        cachedDialogTitleSuffix = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitleSuffix);
                    }
                    return (cachedDialogTitlePrefix + " " + cachedDialogTitleSuffix);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
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
            /// 	[lucyra] 9/21/2006 Created
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
            /// Exposes access to the Tab2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab2
            {
                get
                {
                    if ((cachedTab2 == null))
                    {
                        cachedTab2 = CoreManager.MomConsole.GetIntlStr(ResourceTab2);
                    }
                    
                    return cachedTab2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Days translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Days
            {
                get
                {
                    if ((cachedDays == null))
                    {
                        cachedDays = CoreManager.MomConsole.GetIntlStr(ResourceDays);
                    }
                    
                    return cachedDays;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Days2 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Days2
            {
                get
                {
                    if ((cachedDays2 == null))
                    {
                        cachedDays2 = CoreManager.MomConsole.GetIntlStr(ResourceDays2);
                    }
                    
                    return cachedDays2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutoResolveAlertSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoResolveAlertSettings
            {
                get
                {
                    if ((cachedAutoResolveAlertSettings == null))
                    {
                        cachedAutoResolveAlertSettings = CoreManager.MomConsole.GetIntlStr(ResourceAutoResolveAlertSettings);
                    }
                    
                    return cachedAutoResolveAlertSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter
            {
                get
                {
                    if ((cachedResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter == null))
                    {
                        cachedResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter = CoreManager.MomConsole.GetIntlStr(ResourceResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter);
                    }
                    
                    return cachedResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResolveAllActiveAlertsInTheNewResolutionStateAfter translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResolveAllActiveAlertsInTheNewResolutionStateAfter
            {
                get
                {
                    if ((cachedResolveAllActiveAlertsInTheNewResolutionStateAfter == null))
                    {
                        cachedResolveAllActiveAlertsInTheNewResolutionStateAfter = CoreManager.MomConsole.GetIntlStr(ResourceResolveAllActiveAlertsInTheNewResolutionStateAfter);
                    }
                    
                    return cachedResolveAllActiveAlertsInTheNewResolutionStateAfter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso
            {
                get
                {
                    if ((cachedAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso == null))
                    {
                        cachedAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso = CoreManager.MomConsole.GetIntlStr(ResourceAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso);
                    }
                    
                    return cachedAfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso;
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
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for DaysStaticControl
            /// </summary>
            public const string DaysStaticControl = "labelDays2";
            
            /// <summary>
            /// Control ID for DaysStaticControl2
            /// </summary>
            public const string DaysStaticControl2 = "labelDays1";
            
            /// <summary>
            /// Control ID for AutoResolveAlertSettingsStaticControl
            /// </summary>
            public const string AutoResolveAlertSettingsStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for NumericUpDownHealthy
            /// </summary>
            public const string NumericUpDownHealthy = "numericUpDownHealthy";
            
            /// <summary>
            /// Control ID for NumericUpDownNew
            /// </summary>
            public const string NumericUpDownNew = "numericUpDownNew";
            
            /// <summary>
            /// Control ID for ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl
            /// </summary>
            public const string ResolveAllActiveAlertsWhenTheAlertSourceIsHealthyAfterStaticControl = "labelHealthy";
            
            /// <summary>
            /// Control ID for ResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl
            /// </summary>
            public const string ResolveAllActiveAlertsInTheNewResolutionStateAfterStaticControl = "labelNew";
            
            /// <summary>
            /// Control ID for AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso
            /// </summary>
            public const string AfterAPeriodOfTimeActiveAlertsWhichAreNoLongerRelevantCanBeAutomaticallyResolvedOnceAnAlertIsInAReso = "labelDescription";
        }
        #endregion
    }
}
