// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TargetAndPortPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 4/25/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Port.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ITargetAndPortPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITargetAndPortPropertiesDialogControls, for TargetAndPortPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 4/25/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITargetAndPortPropertiesDialogControls
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
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConnectionStringTextBox
        /// </summary>
        TextBox ConnectionStringTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PortStaticControl
        /// </summary>
        StaticControl PortStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestProcessedSuccessfullyStaticControl
        /// </summary>
        StaticControl RequestProcessedSuccessfullyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryListView
        /// </summary>
        ListView SummaryListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TestButton
        /// </summary>
        Button TestButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitoringTypeTextBox
        /// </summary>
        TextBox MonitoringTypeTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IPAddressOrDeviceNameStaticControl
        /// </summary>
        StaticControl IPAddressOrDeviceNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl
        /// </summary>
        StaticControl EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl
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
    /// 	[faizalk] 4/25/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TargetAndPortPropertiesDialog : Dialog, ITargetAndPortPropertiesDialogControls
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
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to ConnectionStringTextBox of type TextBox
        /// </summary>
        private TextBox cachedConnectionStringTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PortStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPortStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRequestProcessedSuccessfullyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryListView of type ListView
        /// </summary>
        private ListView cachedSummaryListView;
        
        /// <summary>
        /// Cache to hold a reference to TestButton of type Button
        /// </summary>
        private Button cachedTestButton;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringTypeTextBox of type TextBox
        /// </summary>
        private TextBox cachedMonitoringTypeTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IPAddressOrDeviceNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIPAddressOrDeviceNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterTheIPAddressAndPortThatYouWantToMonitorStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TargetAndPortPropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TargetAndPortPropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ITargetAndPortPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITargetAndPortPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control ConnectionString
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConnectionStringText
        {
            get
            {
                return this.Controls.ConnectionStringTextBox.Text;
            }
            
            set
            {
                this.Controls.ConnectionStringTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MonitoringTypeText
        {
            get
            {
                return this.Controls.MonitoringTypeTextBox.Text;
            }
            
            set
            {
                this.Controls.MonitoringTypeTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetAndPortPropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, TargetAndPortPropertiesDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetAndPortPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TargetAndPortPropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetAndPortPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, TargetAndPortPropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ITargetAndPortPropertiesDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, TargetAndPortPropertiesDialog.ControlIDs.Tab1TabControl);
                }
                
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectionStringTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITargetAndPortPropertiesDialogControls.ConnectionStringTextBox
        {
            get
            {
                if ((this.cachedConnectionStringTextBox == null))
                {
                    this.cachedConnectionStringTextBox = new TextBox(this, TargetAndPortPropertiesDialog.ControlIDs.ConnectionStringTextBox);
                }
                
                return this.cachedConnectionStringTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PortStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITargetAndPortPropertiesDialogControls.PortStaticControl
        {
            get
            {
                if ((this.cachedPortStaticControl == null))
                {
                    this.cachedPortStaticControl = new StaticControl(this, TargetAndPortPropertiesDialog.ControlIDs.PortStaticControl);
                }
                
                return this.cachedPortStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestProcessedSuccessfullyStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITargetAndPortPropertiesDialogControls.RequestProcessedSuccessfullyStaticControl
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyStaticControl == null))
                {
                    this.cachedRequestProcessedSuccessfullyStaticControl = new StaticControl(this, TargetAndPortPropertiesDialog.ControlIDs.RequestProcessedSuccessfullyStaticControl);
                }
                
                return this.cachedRequestProcessedSuccessfullyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ITargetAndPortPropertiesDialogControls.SummaryListView
        {
            get
            {
                if ((this.cachedSummaryListView == null))
                {
                    this.cachedSummaryListView = new ListView(this, TargetAndPortPropertiesDialog.ControlIDs.SummaryListView);
                }
                
                return this.cachedSummaryListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TestButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITargetAndPortPropertiesDialogControls.TestButton
        {
            get
            {
                if ((this.cachedTestButton == null))
                {
                    this.cachedTestButton = new Button(this, TargetAndPortPropertiesDialog.ControlIDs.TestButton);
                }
                
                return this.cachedTestButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITargetAndPortPropertiesDialogControls.MonitoringTypeTextBox
        {
            get
            {
                if ((this.cachedMonitoringTypeTextBox == null))
                {
                    this.cachedMonitoringTypeTextBox = new TextBox(this, TargetAndPortPropertiesDialog.ControlIDs.MonitoringTypeTextBox);
                }
                
                return this.cachedMonitoringTypeTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IPAddressOrDeviceNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITargetAndPortPropertiesDialogControls.IPAddressOrDeviceNameStaticControl
        {
            get
            {
                if ((this.cachedIPAddressOrDeviceNameStaticControl == null))
                {
                    this.cachedIPAddressOrDeviceNameStaticControl = new StaticControl(this, TargetAndPortPropertiesDialog.ControlIDs.IPAddressOrDeviceNameStaticControl);
                }
                
                return this.cachedIPAddressOrDeviceNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITargetAndPortPropertiesDialogControls.EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl
        {
            get
            {
                if ((this.cachedEnterTheIPAddressAndPortThatYouWantToMonitorStaticControl == null))
                {
                    this.cachedEnterTheIPAddressAndPortThatYouWantToMonitorStaticControl = new StaticControl(this, TargetAndPortPropertiesDialog.ControlIDs.EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl);
                }
                
                return this.cachedEnterTheIPAddressAndPortThatYouWantToMonitorStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
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
        /// 	[faizalk] 4/25/2007 Created
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
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Test
        /// </summary>
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTest()
        {
            this.Controls.TestButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 4/25/2007 Created
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
        /// 	[faizalk] 4/25/2007 Created
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
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Port
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePort = ";P&ort:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.ServerNameAndPortPage;labelPort." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRequestProcessedSuccessfully = ";Request processed successfully;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "uthoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TCPPortC" +
                "heckTemplate.TCPPortCheckTemplateResource;StatusSuccess";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTest = ";&Test;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.ChooseURLPage;buttonTest.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IPAddressOrDeviceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIPAddressOrDeviceName = ";&IP address or device name:;ManagedString;Microsoft.EnterpriseManagement.UI.Auth" +
                "oring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServerNameA" +
                "ndPortPage;labelIPAddress.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterTheIPAddressAndPortThatYouWantToMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterTheIPAddressAndPortThatYouWantToMonitor = ";Enter the IP address and port that you want to monitor;ManagedString;Microsoft.E" +
                "nterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI." +
                "Authoring.Pages.ServerNameAndPortPage;pageSectionLabel.Text";
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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Port
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPort;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRequestProcessedSuccessfully;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTest;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IPAddressOrDeviceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIPAddressOrDeviceName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterTheIPAddressAndPortThatYouWantToMonitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterTheIPAddressAndPortThatYouWantToMonitor;
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
            /// 	[faizalk] 4/25/2007 Created
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
            /// 	[faizalk] 4/25/2007 Created
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
            /// 	[faizalk] 4/25/2007 Created
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/25/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Port translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/25/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Port
            {
                get
                {
                    if ((cachedPort == null))
                    {
                        cachedPort = CoreManager.MomConsole.GetIntlStr(ResourcePort);
                    }
                    
                    return cachedPort;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RequestProcessedSuccessfully translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/25/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RequestProcessedSuccessfully
            {
                get
                {
                    if ((cachedRequestProcessedSuccessfully == null))
                    {
                        cachedRequestProcessedSuccessfully = CoreManager.MomConsole.GetIntlStr(ResourceRequestProcessedSuccessfully);
                    }
                    
                    return cachedRequestProcessedSuccessfully;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Test translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/25/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Test
            {
                get
                {
                    if ((cachedTest == null))
                    {
                        cachedTest = CoreManager.MomConsole.GetIntlStr(ResourceTest);
                    }
                    
                    return cachedTest;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IPAddressOrDeviceName translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/25/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IPAddressOrDeviceName
            {
                get
                {
                    if ((cachedIPAddressOrDeviceName == null))
                    {
                        cachedIPAddressOrDeviceName = CoreManager.MomConsole.GetIntlStr(ResourceIPAddressOrDeviceName);
                    }
                    
                    return cachedIPAddressOrDeviceName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterTheIPAddressAndPortThatYouWantToMonitor translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 4/25/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterTheIPAddressAndPortThatYouWantToMonitor
            {
                get
                {
                    if ((cachedEnterTheIPAddressAndPortThatYouWantToMonitor == null))
                    {
                        cachedEnterTheIPAddressAndPortThatYouWantToMonitor = CoreManager.MomConsole.GetIntlStr(ResourceEnterTheIPAddressAndPortThatYouWantToMonitor);
                    }
                    
                    return cachedEnterTheIPAddressAndPortThatYouWantToMonitor;
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
        /// 	[faizalk] 4/25/2007 Created
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for ConnectionStringTextBox
            /// </summary>
            public const string ConnectionStringTextBox = "textBoxPort";
            
            /// <summary>
            /// Control ID for PortStaticControl
            /// </summary>
            public const string PortStaticControl = "labelPort";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyStaticControl
            /// </summary>
            public const string RequestProcessedSuccessfullyStaticControl = "labelStatus";
            
            /// <summary>
            /// Control ID for SummaryListView
            /// </summary>
            public const string SummaryListView = "listView";
            
            /// <summary>
            /// Control ID for TestButton
            /// </summary>
            public const string TestButton = "buttonTest";
            
            /// <summary>
            /// Control ID for MonitoringTypeTextBox
            /// </summary>
            public const string MonitoringTypeTextBox = "textBoxServerName";
            
            /// <summary>
            /// Control ID for IPAddressOrDeviceNameStaticControl
            /// </summary>
            public const string IPAddressOrDeviceNameStaticControl = "labelIPAddress";
            
            /// <summary>
            /// Control ID for EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl
            /// </summary>
            public const string EnterTheIPAddressAndPortThatYouWantToMonitorStaticControl = "pageSectionLabel";
        }
        #endregion
    }
}
