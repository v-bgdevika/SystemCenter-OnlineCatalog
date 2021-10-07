// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ManagementServerPropertiesWindow.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  MOMv3 Test UI Automation
// </summary>
// <history>
//  [KellyMor] 28-Aug-05    Created
//  [KellyMor] 28-Sep-05    Updated resource string for window title
//  [KellyMor] 16-Feb-05    Updated resource string for Window title again
//  [KellyMor] 27-Feb-06    Updated resource strings
//  [KellyMor] 02-Mar-06    Updated resource string for Window title yet again
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 24-Jul-06    Added new constructor logic to take a server name for the title
//                          Updated Init method to use new serverName argument
//                          Updated Strings class to use new ServerName property in title
//                          Added click interface and methods for OK, Cancel, and Apply
//  [KellyMor] 24-Oct-07    Updated control interfaces, control ID's, and string resources
//                          Added click methods for toolstip:  New, Edit, Delete
//  [KellyMor] 30-Oct-07    Added overloaded constructor to take an overrideWindowTitle flag
//                          Modified Init() method to take an overrideWindowTitle flag and
//                          compute which title to use:  "%ManagementServer% - Properties"
//                          OR "Configure Active Directory (AD) Integration".
//                          Added string resource for "Configure Active Directory (AD) Integration"
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.DeviceDiscovery
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IManagementServerPropertiesWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IManagementServerPropertiesWindowControls, for ManagementServerPropertiesWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IManagementServerPropertiesWindowControls
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
        /// Read-only property to access ManagementServerComboBox
        /// </summary>
        ComboBox ManagementServerComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementServerStaticControl
        /// </summary>
        StaticControl ManagementServerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutoAgentAssignmentDescriptionStaticControl
        /// </summary>
        StaticControl AutoAgentAssignmentDescriptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutoAgentAssignmentStaticControl
        /// </summary>
        StaticControl AutoAgentAssignmentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NewEditDeleteToolStrip
        /// </summary>
        ToolStrip NewEditDeleteToolStrip
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentAssignmentRulesListView
        /// </summary>
        ListView AgentAssignmentRulesListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DialogDescriptionStaticControl
        /// </summary>
        StaticControl DialogDescriptionStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add window functionality description here.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 10/24/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ManagementServerPropertiesWindow : Window, IManagementServerPropertiesWindowControls
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
        /// Cache to hold a reference to ManagementServerComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedManagementServerComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutoAgentAssignmentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAutoAgentAssignmentDescriptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutoAgentAssignmentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAutoAgentAssignmentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NewEditDeleteToolStrip of type ToolStrip
        /// </summary>
        private ToolStrip cachedNewEditDeleteToolStrip;
        
        /// <summary>
        /// Cache to hold a reference to AgentAssignmentRulesListView of type ListView
        /// </summary>
        private ListView cachedAgentAssignmentRulesListView;
        
        /// <summary>
        /// Cache to hold a reference to DialogDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDialogDescriptionStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of ManagementServerPropertiesWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ManagementServerPropertiesWindow(App ownerWindow) :
                base(Init(ownerWindow, string.Empty, false))
        {
            // TODO: Add Constructor logic here. 
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor that takes the owner window and the name of the server that will
        /// be used in the title string for the window.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of ManagementServerPropertiesWindow of type Maui.Core.App
        /// </param>
        /// <param name="serverName">
        /// Name of the management server whose properties will be displayed.  The name
        /// is also used in the window title string.
        /// </param>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ManagementServerPropertiesWindow(Maui.Core.App ownerWindow, string serverName)
            :
                base(Init(ownerWindow, serverName, false))
        {
            // TODO: Add Constructor logic here. 
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor that takes the owner window and the name of the server that will
        /// be used in the title string for the window.
        /// </summary>
        /// <param name="ownerWindow">
        /// Owner of ManagementServerPropertiesWindow of type Maui.Core.App
        /// </param>
        /// <param name="windowTitle">
        /// Name of the management server whose properties will be displayed.  The name
        /// is also used in the window title string.
        /// </param>
        /// <param name="overrideWindowTitle">
        /// Flag to indicate of the window title string provided should be used instead
        /// of any local, resource string.
        /// </param>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ManagementServerPropertiesWindow(Maui.Core.App ownerWindow, string windowTitle, bool overrideWindowTitle)
            :
                base(Init(ownerWindow, windowTitle, overrideWindowTitle))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region IManagementServerPropertiesWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IManagementServerPropertiesWindowControls Controls
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
        ///  Routine to set/get the text in control ManagementServer
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementServerText
        {
            get
            {
                return this.Controls.ManagementServerComboBox.Text;
            }
            
            set
            {
                this.Controls.ManagementServerComboBox.SelectByText(value, true);
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IManagementServerPropertiesWindowControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, ManagementServerPropertiesWindow.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IManagementServerPropertiesWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ManagementServerPropertiesWindow.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IManagementServerPropertiesWindowControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ManagementServerPropertiesWindow.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IManagementServerPropertiesWindowControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, ManagementServerPropertiesWindow.ControlIDs.Tab0TabControl);
                }
                
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementServerComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IManagementServerPropertiesWindowControls.ManagementServerComboBox
        {
            get
            {
                if ((this.cachedManagementServerComboBox == null))
                {
                    this.cachedManagementServerComboBox = new ComboBox(this, ManagementServerPropertiesWindow.ControlIDs.ManagementServerComboBox);
                }
                
                return this.cachedManagementServerComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IManagementServerPropertiesWindowControls.ManagementServerStaticControl
        {
            get
            {
                if ((this.cachedManagementServerStaticControl == null))
                {
                    this.cachedManagementServerStaticControl = new StaticControl(this, ManagementServerPropertiesWindow.ControlIDs.ManagementServerStaticControl);
                }
                
                return this.cachedManagementServerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoAgentAssignmentDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IManagementServerPropertiesWindowControls.AutoAgentAssignmentDescriptionStaticControl
        {
            get
            {
                if ((this.cachedAutoAgentAssignmentDescriptionStaticControl == null))
                {
                    this.cachedAutoAgentAssignmentDescriptionStaticControl = new StaticControl(this, ManagementServerPropertiesWindow.ControlIDs.AutoAgentAssignmentDescriptionStaticControl);
                }
                
                return this.cachedAutoAgentAssignmentDescriptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoAgentAssignmentStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IManagementServerPropertiesWindowControls.AutoAgentAssignmentStaticControl
        {
            get
            {
                if ((this.cachedAutoAgentAssignmentStaticControl == null))
                {
                    this.cachedAutoAgentAssignmentStaticControl = new StaticControl(this, ManagementServerPropertiesWindow.ControlIDs.AutoAgentAssignmentStaticControl);
                }
                
                return this.cachedAutoAgentAssignmentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewEditDeleteToolStrip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ToolStrip IManagementServerPropertiesWindowControls.NewEditDeleteToolStrip
        {
            get
            {
                if ((this.cachedNewEditDeleteToolStrip == null))
                {
                    this.cachedNewEditDeleteToolStrip = 
                        new ToolStrip(this);
                }
                
                return this.cachedNewEditDeleteToolStrip;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentAssignmentRulesListView control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IManagementServerPropertiesWindowControls.AgentAssignmentRulesListView
        {
            get
            {
                if ((this.cachedAgentAssignmentRulesListView == null))
                {
                    this.cachedAgentAssignmentRulesListView = new ListView(this, ManagementServerPropertiesWindow.ControlIDs.AgentAssignmentRulesListView);
                }
                
                return this.cachedAgentAssignmentRulesListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DialogDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IManagementServerPropertiesWindowControls.DialogDescriptionStaticControl
        {
            get
            {
                if ((this.cachedDialogDescriptionStaticControl == null))
                {
                    this.cachedDialogDescriptionStaticControl = new StaticControl(this, ManagementServerPropertiesWindow.ControlIDs.DialogDescriptionStaticControl);
                }
                
                return this.cachedDialogDescriptionStaticControl;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
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
        /// 	[KellyMor] 10/24/2007 Created
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
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Add" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.NewEditDeleteToolStrip.ToolStripItems[0].Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Edit" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.NewEditDeleteToolStrip.ToolStripItems[1].Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to click the "Delete" button on the tool strip control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 10/24/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDelete()
        {
            this.Controls.NewEditDeleteToolStrip.ToolStripItems[2].Click();
        }

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        /// <param name="ownerWindow">
        /// Maui.Core.App class instance that owns this window.
        /// </param>
        /// <param name="serverName">
        /// Name of the management server whose properties will be displayed.  The name
        /// is also used in the window title string.
        /// </param>
        /// <param name="overrideWindowTitle">
        /// Flag to indicate of the window title string provided should be used instead
        /// of any local, resource string.
        /// </param>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(Maui.Core.App ownerWindow, string serverName, bool overrideWindowTitle)
        {
            #region Compute the Window Title

            // create a placeholder for the window title
            string windowTitle = null;

            // if no server name is given...
            if (serverName.Equals(string.Empty))
            {
                // use the current computer name
                //serverName =
                //    System.Environment.ExpandEnvironmentVariables("%computername%") +
                //    "." +
                //    System.Environment.ExpandEnvironmentVariables("%userdnsdomain%");
                Core.Common.Utilities.GetServerNameFqdn(System.Environment.ExpandEnvironmentVariables("%computername%"));

                // set the server name
                Strings.ServerName = serverName;

                // set the window title
                windowTitle = Strings.WindowTitle;
            }
            else
            {
                // a string was passed, use it to override window title?
                if (true == overrideWindowTitle)
                {
                    // override the window title and use this string instead
                    windowTitle = serverName;
                }
                else
                {
                    // use this string with the existing window title string
                    Strings.ServerName = serverName;

                    // set the window title
                    windowTitle = Strings.WindowTitle;
                }
            }

            #endregion

            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = 
                    new Window(
                    windowTitle, 
                    StringMatchSyntax.WildCard, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    ownerWindow, 
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
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
                                windowTitle + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        windowTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }

            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Updated definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
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
            private const string ResourceWindowTitle = 
                ";{0} - Management Server Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ServerPropertiesTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = 
                ";&Apply" + 
                ";ManagedString" + 
                ";DundasWinChart.dll" + 
                ";Dundas.Charting.WinControl.PropertyDialog.PropertyDialogForm" +
                ";buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = 
                ";Cancel" + 
                ";ManagedString" + 
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" + 
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm" + 
                ";buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = 
                ";OK" + 
                ";ManagedString" + 
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" + 
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm" + 
                ";buttonOK.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementServer = 
                ";&Management Server:" + 
                ";ManagedString" + 
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" + 
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ClientMonitoring.CMManagementServer" +
                ";labelDescriptionTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoAgentAssignmentDescriptionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoAgentAssignmentDescriptionStaticControl = @";Click 'Add' to specify agent assignment setting for a new domain or choose existing domain’s assignment setting and click 'Edit'.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AgentManagement;labelDescription2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoAgentAssignment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoAgentAssignment = ";Auto Agent Assignment:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.Internal.UI.Console.Administration.AgentManagement;labelTit" +
                "le1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DialogDescriptionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogDescriptionStaticControl = @";Add or modify agent assignment settings in Active Directory. The settings specifies which agent managed computers will be monitored by this management server.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AgentManagement;labelDescription.Text";

            private const string ResourceConfigureAdIntegrationRules = 
                ";Configure Active Directory (AD) Integration;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ConfigureActiveDirectory";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains the name of the server to display
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string serverName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;
            
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
            /// Caches the translated resource string for:  ManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementServer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutoAgentAssignmentDescriptionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoAgentAssignmentDescriptionStaticControl;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutoAgentAssignment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoAgentAssignment;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DialogDescriptionStaticControl
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogDescriptionStaticControl;

            private static string cachedConfigureAdIntegrationRules;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the server name
            /// </summary>
            /// <history>
            /// 	[KellyMor] 24-Jul-06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServerName
            {
                get
                {
                    return Strings.serverName;
                }

                set
                {
                    //Strings.serverName = value;
                    Strings.serverName = Common.Utilities.GetServerNameFqdn(value);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        // format the window title string
                        cachedWindowTitle = 
                            string.Format(
                                CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle), 
                                serverName);
                    }

                    return cachedWindowTitle;
                }
            }
                      
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// 	[KellyMor] 10/24/2007 Created
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
            /// Exposes access to the ManagementServer translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementServer
            {
                get
                {
                    if ((cachedManagementServer == null))
                    {
                        cachedManagementServer = CoreManager.MomConsole.GetIntlStr(ResourceManagementServer);
                    }
                    
                    return cachedManagementServer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutoAgentAssignmentDescriptionStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoAgentAssignmentDescriptionStaticControl
            {
                get
                {
                    if ((cachedAutoAgentAssignmentDescriptionStaticControl == null))
                    {
                        cachedAutoAgentAssignmentDescriptionStaticControl = CoreManager.MomConsole.GetIntlStr(ResourceAutoAgentAssignmentDescriptionStaticControl);
                    }
                    
                    return cachedAutoAgentAssignmentDescriptionStaticControl;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutoAgentAssignment translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoAgentAssignment
            {
                get
                {
                    if ((cachedAutoAgentAssignment == null))
                    {
                        cachedAutoAgentAssignment = CoreManager.MomConsole.GetIntlStr(ResourceAutoAgentAssignment);
                    }
                    
                    return cachedAutoAgentAssignment;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogDescriptionStaticControl translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/24/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogDescriptionStaticControl
            {
                get
                {
                    if ((cachedDialogDescriptionStaticControl == null))
                    {
                        cachedDialogDescriptionStaticControl = CoreManager.MomConsole.GetIntlStr(ResourceDialogDescriptionStaticControl);
                    }
                    
                    return cachedDialogDescriptionStaticControl;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAdIntegrationRules translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 10/30/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAdIntegrationRules
            {
                get
                {
                    if (null == cachedConfigureAdIntegrationRules)
                    {
                        cachedConfigureAdIntegrationRules =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceConfigureAdIntegrationRules);
                    }

                    return cachedConfigureAdIntegrationRules;
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
        /// 	[KellyMor] 10/24/2007 Created
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
            /// Control ID for ManagementServerComboBox
            /// </summary>
            public const string ManagementServerComboBox = "comboBoxServer";
            
            /// <summary>
            /// Control ID for ManagementServerStaticControl
            /// </summary>
            public const string ManagementServerStaticControl = "labelServer";
            
            /// <summary>
            /// Control ID for AutoAgentAssignmentDescriptionStaticControl
            /// </summary>
            public const string AutoAgentAssignmentDescriptionStaticControl = "labelDescription2";
            
            /// <summary>
            /// Control ID for AutoAgentAssignmentStaticControl
            /// </summary>
            public const string AutoAgentAssignmentStaticControl = "labelTitle1";
            
            /// <summary>
            /// Control ID for NewEditDeleteToolStrip
            /// </summary>
            public const string NewEditDeleteToolStrip = "toolStripNewEditDelete";
            
            /// <summary>
            /// Control ID for AgentAssignmentRulesListView
            /// </summary>
            public const string AgentAssignmentRulesListView = "listViewQueries";
            
            /// <summary>
            /// Control ID for DialogDescriptionStaticControl
            /// </summary>
            public const string DialogDescriptionStaticControl = "labelDescription";
        }

        #endregion
    }
}
