// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AlertsGlobalSettingsAlertResolutionDialog.cs">
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
    
    #region Interface Definition - IAlertsGlobalSettingsAlertResolutionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAlertsGlobalSettingsAlertResolutionDialogControls, for AlertsGlobalSettingsAlertResolutionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 9/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAlertsGlobalSettingsAlertResolutionDialogControls
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
        /// Read-only property to access Tab0TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab0TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertResolutionStateSettingsStaticControl
        /// </summary>
        StaticControl AlertResolutionStateSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolstripNewEditDelete
        /// </summary>
        Toolbar ToolstripNewEditDelete
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResolutionStatesList
        /// </summary>
        ListView ResolutionStatesList
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa
        /// </summary>
        StaticControl AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa
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
    public class AlertsGlobalSettingsAlertResolutionDialog : Dialog, IAlertsGlobalSettingsAlertResolutionDialogControls
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
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to AlertResolutionStateSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertResolutionStateSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToolstripNewEditDelete of type Toolbar
        /// </summary>
        private Toolbar cachedToolstripNewEditDelete;
        
        /// <summary>
        /// Cache to hold a reference to ResolutionStatesList of type ListView
        /// </summary>
        private ListView cachedResolutionStatesList;
        
        /// <summary>
        /// Cache to hold a reference to AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa of type StaticControl
        /// </summary>
        private StaticControl cachedAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AlertsGlobalSettingsAlertResolutionDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AlertsGlobalSettingsAlertResolutionDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAlertsGlobalSettingsAlertResolutionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAlertsGlobalSettingsAlertResolutionDialogControls Controls
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAlertsGlobalSettingsAlertResolutionDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.ApplyButton);
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
        Button IAlertsGlobalSettingsAlertResolutionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.CancelButton);
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
        Button IAlertsGlobalSettingsAlertResolutionDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAlertsGlobalSettingsAlertResolutionDialogControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertResolutionStateSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsAlertResolutionDialogControls.AlertResolutionStateSettingsStaticControl
        {
            get
            {
                if ((this.cachedAlertResolutionStateSettingsStaticControl == null))
                {
                    this.cachedAlertResolutionStateSettingsStaticControl = new StaticControl(this, AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.AlertResolutionStateSettingsStaticControl);
                }
                
                return this.cachedAlertResolutionStateSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolstripNewEditDelete control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        ///     [a-joelj]   28OCT09 Maui 2.0: Modified to use QID in ToolBar constructor
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IAlertsGlobalSettingsAlertResolutionDialogControls.ToolstripNewEditDelete
        {
            get
            {
                if ((this.cachedToolstripNewEditDelete == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the ToolBar constructor using 'this' and the 
                    // ControlId instead of using a QID is returning the wrong ToolBar or no ToolBar at all. 
                    // Modified to use a QID in the UIA tree for matching with the ToolBar AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId='" + AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.ToolstripNewEditDelete + "'");

                    this.cachedToolstripNewEditDelete = new Toolbar(this, queryId, Common.Constants.DefaultContextMenuTimeout);//, AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.ToolstripNewEditDelete*/);
                }
                
                return this.cachedToolstripNewEditDelete;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResolutionStatesList control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAlertsGlobalSettingsAlertResolutionDialogControls.ResolutionStatesList
        {
            get
            {
                if ((this.cachedResolutionStatesList == null))
                {
                    this.cachedResolutionStatesList = new ListView(this, AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.ResolutionStatesList);
                }
                
                return this.cachedResolutionStatesList;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa control
        /// </summary>
        /// <history>
        /// 	[lucyra] 9/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAlertsGlobalSettingsAlertResolutionDialogControls.AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa
        {
            get
            {
                if ((this.cachedAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa == null))
                {
                    this.cachedAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa = new StaticControl(this, AlertsGlobalSettingsAlertResolutionDialog.ControlIDs.AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa);
                }
                
                return this.cachedAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa;
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
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertResolutionStateSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertResolutionStateSettings = ";Alert Resolution State Settings:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolutionStates;labelTitle1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa = "Alert resolution states allow you to classify alerts into various states, and to " +
                "define the behavior associated with each state to fit your business environment." +
                " Listed are the default alert states, which you can modify, delete or add, excep" +
                "t for the \'New";
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertResolutionStateSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolutionStateSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa;
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
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
            /// Exposes access to the AlertResolutionStateSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertResolutionStateSettings
            {
                get
                {
                    if ((cachedAlertResolutionStateSettings == null))
                    {
                        cachedAlertResolutionStateSettings = CoreManager.MomConsole.GetIntlStr(ResourceAlertResolutionStateSettings);
                    }
                    
                    return cachedAlertResolutionStateSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 9/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa
            {
                get
                {
                    if ((cachedAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa == null))
                    {
                        cachedAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa = CoreManager.MomConsole.GetIntlStr(ResourceAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa);
                    }
                    
                    return cachedAlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa;
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
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for AlertResolutionStateSettingsStaticControl
            /// </summary>
            public const string AlertResolutionStateSettingsStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for ToolstripNewEditDelete
            /// </summary>
            public const string ToolstripNewEditDelete = "toolStripNewEditDelete";
            
            /// <summary>
            /// Control ID for ResolutionStatesList
            /// </summary>
            public const string ResolutionStatesList = "listViewStates";
            
            /// <summary>
            /// Control ID for AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa
            /// </summary>
            public const string AlertResolutionStatesAllowYouToClassifyAlertsIntoVariousStatesAndToDefineTheBehaviorAssociatedWithEa = "labelDescription";
        }
        #endregion
    }
}
