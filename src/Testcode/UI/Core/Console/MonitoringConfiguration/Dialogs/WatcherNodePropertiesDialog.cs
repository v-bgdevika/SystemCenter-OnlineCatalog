// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WatcherNodePropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/19/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IWatcherNodePropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWatcherNodePropertiesDialogControls, for WatcherNodePropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/19/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWatcherNodePropertiesDialogControls
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
        /// Read-only property to access ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl
        /// </summary>
        StaticControl ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunThisQueryEveryComboBox
        /// </summary>
        ComboBox RunThisQueryEveryComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunThisQueryEveryStaticControl
        /// </summary>
        StaticControl RunThisQueryEveryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WatcherNodeStaticControl
        /// </summary>
        StaticControl WatcherNodeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PortListView
        /// </summary>
        ListView PortListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectOneOrMoreAgentManagedComputersStaticControl
        /// </summary>
        StaticControl SelectOneOrMoreAgentManagedComputersStaticControl
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
    /// 	[faizalk] 4/19/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WatcherNodePropertiesDialog : Dialog, IWatcherNodePropertiesDialogControls
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
        /// Cache to hold a reference to ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox0;
        
        /// <summary>
        /// Cache to hold a reference to RunThisQueryEveryComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedRunThisQueryEveryComboBox;
        
        /// <summary>
        /// Cache to hold a reference to RunThisQueryEveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunThisQueryEveryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WatcherNodeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWatcherNodeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PortListView of type ListView
        /// </summary>
        private ListView cachedPortListView;
        
        /// <summary>
        /// Cache to hold a reference to SelectOneOrMoreAgentManagedComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectOneOrMoreAgentManagedComputersStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of WatcherNodePropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WatcherNodePropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IWatcherNodePropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWatcherNodePropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control ComboBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox0Text
        {
            get
            {
                return this.Controls.ComboBox0.Text;
            }
            
            set
            {
                this.Controls.ComboBox0.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control RunThisQueryEvery
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string RunThisQueryEveryText
        {
            get
            {
                return this.Controls.RunThisQueryEveryComboBox.Text;
            }
            
            set
            {
                this.Controls.RunThisQueryEveryComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWatcherNodePropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, WatcherNodePropertiesDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWatcherNodePropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WatcherNodePropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWatcherNodePropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, WatcherNodePropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IWatcherNodePropertiesDialogControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, WatcherNodePropertiesDialog.ControlIDs.Tab2TabControl);
                }
                
                return this.cachedTab2TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWatcherNodePropertiesDialogControls.ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl
        {
            get
            {
                if ((this.cachedChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl == null))
                {
                    this.cachedChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl = new StaticControl(this, WatcherNodePropertiesDialog.ControlIDs.ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl);
                }
                
                return this.cachedChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWatcherNodePropertiesDialogControls.ComboBox0
        {
            get
            {
                if ((this.cachedComboBox0 == null))
                {
                    this.cachedComboBox0 = new ComboBox(this, WatcherNodePropertiesDialog.ControlIDs.ComboBox0);
                }
                
                return this.cachedComboBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunThisQueryEveryComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWatcherNodePropertiesDialogControls.RunThisQueryEveryComboBox
        {
            get
            {
                if ((this.cachedRunThisQueryEveryComboBox == null))
                {
                    this.cachedRunThisQueryEveryComboBox = new ComboBox(this, WatcherNodePropertiesDialog.ControlIDs.RunThisQueryEveryComboBox);
                }
                
                return this.cachedRunThisQueryEveryComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunThisQueryEveryStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWatcherNodePropertiesDialogControls.RunThisQueryEveryStaticControl
        {
            get
            {
                if ((this.cachedRunThisQueryEveryStaticControl == null))
                {
                    this.cachedRunThisQueryEveryStaticControl = new StaticControl(this, WatcherNodePropertiesDialog.ControlIDs.RunThisQueryEveryStaticControl);
                }
                
                return this.cachedRunThisQueryEveryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WatcherNodeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWatcherNodePropertiesDialogControls.WatcherNodeStaticControl
        {
            get
            {
                if ((this.cachedWatcherNodeStaticControl == null))
                {
                    this.cachedWatcherNodeStaticControl = new StaticControl(this, WatcherNodePropertiesDialog.ControlIDs.WatcherNodeStaticControl);
                }
                
                return this.cachedWatcherNodeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PortListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IWatcherNodePropertiesDialogControls.PortListView
        {
            get
            {
                if ((this.cachedPortListView == null))
                {
                    this.cachedPortListView = new ListView(this, WatcherNodePropertiesDialog.ControlIDs.PortListView);
                }
                
                return this.cachedPortListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectOneOrMoreAgentManagedComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWatcherNodePropertiesDialogControls.SelectOneOrMoreAgentManagedComputersStaticControl
        {
            get
            {
                if ((this.cachedSelectOneOrMoreAgentManagedComputersStaticControl == null))
                {
                    this.cachedSelectOneOrMoreAgentManagedComputersStaticControl = new StaticControl(this, WatcherNodePropertiesDialog.ControlIDs.SelectOneOrMoreAgentManagedComputersStaticControl);
                }
                
                return this.cachedSelectOneOrMoreAgentManagedComputersStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
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
        /// 	[faizalk] 4/19/2007 Created
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
        /// 	[faizalk] 4/19/2007 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
        /// 	[faizalk] 4/19/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            
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
            /// Contains resource string for:  ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations = ";Choose agent managed computers to act as watcher nodes from different locations." +
                ";ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.WatcherNodeChooserControl;labelDescrip" +
                "tion.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunThisQueryEvery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunThisQueryEvery = ";&Run this query every:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WatcherNodeChoos" +
                "erControl;labelInterval.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWatcherNode = ";Watcher node;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.WatcherNodeChooserControl;" +
                "pageSectionLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectOneOrMoreAgentManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectOneOrMoreAgentManagedComputers = ";&Select one or more agent managed computers:;ManagedString;Microsoft.EnterpriseM" +
                "anagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring." +
                "Pages.WatcherNodeChooserControl;selectNodesLabel.Text";
            #endregion
            
            #region Private Members
            
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
            /// Caches the translated resource string for:  ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunThisQueryEvery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunThisQueryEvery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WatcherNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWatcherNode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectOneOrMoreAgentManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectOneOrMoreAgentManagedComputers;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/03/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    return Templates.Strings.PropertiesDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/19/2007 Created
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
            /// 	[faizalk] 4/19/2007 Created
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
            /// 	[faizalk] 4/19/2007 Created
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
            /// 	[faizalk] 4/19/2007 Created
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
            /// Exposes access to the ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/19/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations
            {
                get
                {
                    if ((cachedChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations == null))
                    {
                        cachedChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations = CoreManager.MomConsole.GetIntlStr(ResourceChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations);
                    }
                    
                    return cachedChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocations;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunThisQueryEvery translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/19/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunThisQueryEvery
            {
                get
                {
                    if ((cachedRunThisQueryEvery == null))
                    {
                        cachedRunThisQueryEvery = CoreManager.MomConsole.GetIntlStr(ResourceRunThisQueryEvery);
                    }
                    
                    return cachedRunThisQueryEvery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WatcherNode translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/19/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WatcherNode
            {
                get
                {
                    if ((cachedWatcherNode == null))
                    {
                        cachedWatcherNode = CoreManager.MomConsole.GetIntlStr(ResourceWatcherNode);
                    }
                    
                    return cachedWatcherNode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectOneOrMoreAgentManagedComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/19/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectOneOrMoreAgentManagedComputers
            {
                get
                {
                    if ((cachedSelectOneOrMoreAgentManagedComputers == null))
                    {
                        cachedSelectOneOrMoreAgentManagedComputers = CoreManager.MomConsole.GetIntlStr(ResourceSelectOneOrMoreAgentManagedComputers);
                    }
                    
                    return cachedSelectOneOrMoreAgentManagedComputers;
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
        /// 	[faizalk] 4/19/2007 Created
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
            /// Control ID for ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl
            /// </summary>
            public const string ChooseAgentManagedComputersToActAsWatcherNodesFromDifferentLocationsStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for ComboBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox0 = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for RunThisQueryEveryComboBox
            /// </summary>
            public const string RunThisQueryEveryComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for RunThisQueryEveryStaticControl
            /// </summary>
            public const string RunThisQueryEveryStaticControl = "labelInterval";
            
            /// <summary>
            /// Control ID for WatcherNodeStaticControl
            /// </summary>
            public const string WatcherNodeStaticControl = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for PortListView
            /// </summary>
            public const string PortListView = "agentsListView";
            
            /// <summary>
            /// Control ID for SelectOneOrMoreAgentManagedComputersStaticControl
            /// </summary>
            public const string SelectOneOrMoreAgentManagedComputersStaticControl = "selectNodesLabel";
        }
        #endregion
    }
}
