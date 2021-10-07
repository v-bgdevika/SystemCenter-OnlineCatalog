// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Attributes.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Attributes helper utils
// </summary>
// <history>
// 	[visnara] 7/27/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Attributes
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Text;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.MomControls;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Attributes.Wizards;
    
   

    #endregion

    #region enums

    /// <summary>
    /// Attribute type - enumeration
    /// </summary>
    /// <history>
    ///		[visnara] 27JUL06 Created
    /// </history>
    public enum AttributeType
    {
        /// <summary>
        /// Registry based
        /// </summary>
        Registry,

        /// <summary>
        /// Windows Management Instrumentation based
        /// </summary>
        WMI
    }

    /// <summary>
    /// Registry type - enumeration
    /// </summary>
    /// <history>
    ///		[visnara] 27JUL06 Created
    /// </history>
    public enum RegistryType
    {
        /// <summary>
        /// Key
        /// </summary>
        Key,

        /// <summary>
        /// Value
        /// </summary>
        Value
    }

    /// <summary>
    /// Registry value data type - enumeration
    /// </summary>
    /// <history>
    ///		[visnara] 27JUL06 Created
    /// </history>
    public enum RegistryValueDataType
    {
        /// <summary>
        /// Bool
        /// </summary>
        Bool,

        /// <summary>
        /// Float
        /// </summary>
        Float,

        /// <summary>
        /// Int
        /// </summary>
        Int,

        /// <summary>
        /// String
        /// </summary>
        String
    }

    #endregion

    #region AttributeParameters Class

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Attribute parameters class
    /// </summary>
    /// <history>
    /// 	[visnara] 6/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AttributeParameters
    {
        #region private members

        /// <summary>
        /// Attribute Type 
        /// </summary>
        private AttributeType attribType;

        /// <summary>
        /// Attribute Name
        /// </summary>
        private string attribName = null;

         /// <summary>
        /// Attribute Description
        /// </summary>
        private string attribDesc = null;

        /// <summary>
        /// Attribute Target Class
        /// </summary>
        private string attribTargetClassDisplayString = null;

        /// <summary>
        /// Attribute MP
        /// </summary>
        private string attribMPDisplayString = null;

        /// <summary>
        /// Registry Path under HKEY_LOCAL_MACHINE (or) WMI Name space from and including root
        /// </summary>
        private string regPathOrWMINameSpace = null;

        /// <summary>
        /// WMI Query
        /// </summary>
        private string wmiQuery = null;

        /// <summary>
        /// Registry Type
        /// </summary>
        private RegistryType regKeyOrValue;

        /// <summary>
        /// WMI Property Name
        /// </summary>
        private String wmiPropertyName = null;

        /// <summary>
        /// Registry Value Data Type - effective only if regKeyOrValue = RegistryType.Value
        /// </summary>
        private RegistryValueDataType regValueDataType;

        #endregion private members

        #region constructor

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public AttributeParameters()
        {
        }

        #endregion

        #region properties

        /// <summary>
        /// Attribute Type 
        /// </summary>
        public AttributeType AttribType
        {
            get
            {
                return this.attribType;
            }

            set
            {
                this.attribType = value;
            }
        }

        /// <summary>
        /// Attribute Name
        /// </summary>
        public string AttribName
        {
            get
            {
                return this.attribName;
            }

            set
            {
                this.attribName = value;
            }
        }

        /// <summary>
        /// Attribute Description
        /// </summary>
        public string AttribDesc
        {
            get
            {
                return this.attribDesc;
            }

            set
            {
                this.attribDesc = value;
            }
        }

        /// <summary>
        /// Attribute Target Class
        /// </summary>
        public string AttribTargetClassDisplayString
        {
            get
            {
                return this.attribTargetClassDisplayString;
            }

            set
            {
                this.attribTargetClassDisplayString = value;
            }
        }

        /// <summary>
        /// Attribute MP
        /// </summary>
        public string AttribMPDisplayString
        {
            get
            {
                return this.attribMPDisplayString;
            }

            set
            {
                this.attribMPDisplayString = value;
            }
        }

        /// <summary>
        /// Registry Path under HKEY_LOCAL_MACHINE (or) WMI Name space from and including root
        /// </summary>
        public string RegPathOrWMINameSpace
        {
            get
            {
                return this.regPathOrWMINameSpace;
            }

            set
            {
                this.regPathOrWMINameSpace = value;
            }
        }

        /// <summary>
        /// WMI Query
        /// </summary>
        public string WMIQuery
        {
            get
            {
                return this.wmiQuery;
            }

            set
            {
                this.wmiQuery = value;
            }
        }


        /// <summary>
        /// Registry Type
        /// </summary>
        public RegistryType RegKeyOrValue
        {
            get
            {
                return this.regKeyOrValue;
            }

            set
            {
                this.regKeyOrValue = value;
            }
        }

        /// <summary>
        /// WMI Property Name
        /// </summary>
        public string WMIPropertyName
        {
            get
            {
                return this.wmiPropertyName;
            }

            set
            {
                this.wmiPropertyName = value;
            }
        }

         /// <summary>
        /// Registry Value Data Type
        /// </summary>
        public RegistryValueDataType RegValueDataType
        {
            get
            {
                return this.regValueDataType;
            }

            set
            {
                this.regValueDataType = value;
            }
        }
        #endregion
    }

    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Attributes helper class
    /// </summary>
    /// <history>
    /// 	[visnara] 7/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class Attributes
    {
        #region private members

        /// <summary>
        /// cache to hold a reference to CreateAttributeWizardGeneralProperties dialog
        /// </summary>
        private CreateAttributeWizardGeneralProperties cachedCreateAttributeWizardGeneralProperties;

        /// <summary>
        /// cache to hold a reference to CreateAttributeWizardDiscoveryMethod dialog
        /// </summary>
        private CreateAttributeWizardDiscoveryMethod cachedCreateAttributeWizardDiscoveryMethod;

        /// <summary>
        /// cache to hold a reference to CreateAttributeWizardRegProbeConfig dialog
        /// </summary>
        private CreateAttributeWizardRegProbeConfig cachedCreateAttributeWizardRegProbeConfig;

        /// <summary>
        /// cache to hold a reference to CreateAttributeWizardWMIConfig dialog
        /// </summary>
        private CreateAttributeWizardWMIConfig cachedCreateAttributeWizardWMIConfig;

        /// <summary>
        /// cache to hold a reference to AttributeTargetSelectclassDialog
        /// </summary>
        private AttributeTargetSelectclassDialog cachedAttributeTargetSelectclassDialog;

        /// <summary>
        /// cache to hold a reference to CommonTargetSelectclassDialog
        /// </summary>
        private Dialogs.SelectTargetTypeDialog cachedCommonTargetSelectclassDialog;


        /// <summary>
        /// reference to ConsoleApp
        /// </summary>
        private ConsoleApp consoleApp;

        /// <summary>
        /// timeout value for dialog UIs to become ready 
        /// </summary>
        private int timeout = 5000;

        #endregion

        #region constructor

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// default constructor
        /// </summary>
        /// <history>
        /// 	[visnara] 27JUL06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Attributes()
        {
            this.consoleApp = CoreManager.MomConsole;
        }

        #endregion

        #region properties

        /// <summary>
        /// CreateAttributeWizardGeneralProperties dialog
        /// </summary>
        /// <history>
        ///		[visnara] 27JUL06 Created
        /// </history>
        public CreateAttributeWizardGeneralProperties CreateAttributeWizardGeneralPropertiesDialog
        {
            get
            {
                if (this.cachedCreateAttributeWizardGeneralProperties == null)
                {
                    this.cachedCreateAttributeWizardGeneralProperties = new CreateAttributeWizardGeneralProperties(CoreManager.MomConsole);
                }

                return this.cachedCreateAttributeWizardGeneralProperties;
            }
        }

        /// <summary>
        /// CreateAttributeWizardDiscoveryMethod dialog
        /// </summary>
        /// <history>
        ///		[visnara] 27JUL06 Created
        /// </history>
        public CreateAttributeWizardDiscoveryMethod CreateAttributeWizardDiscoveryMethodDialog
        {
            get
            {
                if (this.cachedCreateAttributeWizardDiscoveryMethod == null)
                {
                    this.cachedCreateAttributeWizardDiscoveryMethod = new CreateAttributeWizardDiscoveryMethod(CoreManager.MomConsole);
                }

                return this.cachedCreateAttributeWizardDiscoveryMethod;
            }
        }

        /// <summary>
        /// CreateAttributeWizardRegProbeConfig dialog
        /// </summary>
        /// <history>
        ///		[visnara] 27JUN06 Created
        /// </history>
        public CreateAttributeWizardRegProbeConfig CreateAttributeWizardRegProbeConfigDialog
        {
            get
            {
                if (this.cachedCreateAttributeWizardRegProbeConfig == null)
                {
                    this.cachedCreateAttributeWizardRegProbeConfig = new CreateAttributeWizardRegProbeConfig(CoreManager.MomConsole);
                }

                return this.cachedCreateAttributeWizardRegProbeConfig;
            }
        }

        /// <summary>
        /// CreateAttributeWizardWMIConfig dialog
        /// </summary>
        /// <history>
        ///		[visnara] 27JUN06 Created
        /// </history>
        public CreateAttributeWizardWMIConfig CreateAttributeWizardWMIConfigDialog
        {
            get
            {
                if (this.cachedCreateAttributeWizardWMIConfig == null)
                {
                    this.cachedCreateAttributeWizardWMIConfig = new CreateAttributeWizardWMIConfig(CoreManager.MomConsole);
                    UISynchronization.WaitForUIObjectReady(this.cachedCreateAttributeWizardWMIConfig, this.timeout);
                    this.cachedCreateAttributeWizardWMIConfig.Extended.SetFocus();
                }

                return this.cachedCreateAttributeWizardWMIConfig;
            }
        }

        /// <summary>
        /// AttributeTargetSelectclassDialog
        /// </summary>
        /// <history>
        ///		[visnara] 27JUN06 Created
        /// </history>
        public AttributeTargetSelectclassDialog AttributeTargetSelectclassDialogWindow
        {
            get
            {
                if (this.cachedAttributeTargetSelectclassDialog == null)
                {
                    this.cachedAttributeTargetSelectclassDialog = new AttributeTargetSelectclassDialog(CoreManager.MomConsole);
                    UISynchronization.WaitForUIObjectReady(this.cachedAttributeTargetSelectclassDialog, this.timeout);
                    this.cachedAttributeTargetSelectclassDialog.Extended.SetFocus();
                }

                return this.cachedAttributeTargetSelectclassDialog;
            }
        }

        /// <summary>
        /// CommonTargetSelectclassDialog
        /// </summary>
        /// <history>
        ///		[visnara] 12SEP06 Created
        /// </history>
        public Dialogs.SelectTargetTypeDialog CommonTargetSelectclassDialogWindow
        {
            get
            {
                if (this.cachedCommonTargetSelectclassDialog == null)
                {
                    this.cachedCommonTargetSelectclassDialog = new Dialogs.SelectTargetTypeDialog(CoreManager.MomConsole);
                }

                return this.cachedCommonTargetSelectclassDialog;
            }
        }


        #endregion

        #region private methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigate to Attributes/Object Discovery node in Authoring space
        /// <param name="attributeNode">True=Attributes Node, False= O.D Node</param>
        /// </summary>
        /// ------------------------------------------------------------------
        private void NavigateToAttributesNode(bool attributeNode)
        {
            ////TODO add this resource to navpane
            //string attributesNode = ";Attributes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.AttributesView.AttributesViewResources;ViewName";
            string node = attributeNode == true ? Core.Console.Views.Views.Strings.AttributesView : Core.Console.Views.Views.Strings.ObjectDiscoveriesView;
            Utilities.LogMessage("NavigateToAttributesNode :: Node = " + node);
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Authoring);
            
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 30000);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 30000);
            consoleApp.Waiters.WaitForStatusReady(30000);
            consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow,60000);
            
            navPane.SelectNode(
              NavigationPane.Strings.Authoring + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects +
              Constants.PathDelimiter + node, //NavigationPane.Strings.MonConfigTreeViewAttributes,
              NavigationPane.NavigationTreeView.Authoring);

         
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 30000);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 30000);
            consoleApp.Waiters.WaitForStatusReady(30000);
            consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);
            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
            //CoreManager.MomConsole.ViewPane.ChangeScopeStaticControl.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
          

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigate to MP Objects node in Authoring space
        /// </summary>
        /// ------------------------------------------------------------------
        private void NavigateToMPObjectsNode()
        {
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Authoring);
            consoleApp.Waiters.WaitForStatusReady(60000);
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 30000);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 30000);
           
            navPane.SelectNode(
              NavigationPane.Strings.Authoring + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects,
              NavigationPane.NavigationTreeView.Authoring);
            consoleApp.Waiters.WaitForStatusReady(30000);
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 30000);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 30000);
             CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Launches attribute creation wizard by launching 'Create a new attribute...' from context menu
        /// </summary>
        /// ------------------------------------------------------------------
        private void LaunchCreateAttributeWizard()
        {
            bool foundContextMenu = false;
            int retry = 6;
            int attempt = 0;
            try
            {
                Utilities.LogMessage("LaunchCreateAttributeWizard :: Navigating to attributes node");
                //this.NavigateToMPObjectsNode();
                // Navigate to Monitoring
                CoreManager.MomConsole.NavigationPane.SelectNode(NavigationPane.Strings.Monitoring, NavigationPane.NavigationTreeView.Monitoring);
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                this.NavigateToAttributesNode(true);
               
            }
            catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException)
            {
                Utilities.LogMessage("LaunchCreateAttributeWizard :: Unable to find attributes node in navpane");
                throw;
            }
            try
            {
                ViewPane attributesViewPane = CoreManager.MomConsole.ViewPane;
                Mom.Test.UI.Core.Console.MomControls.GridControl attributesGrid = attributesViewPane.Grid;
                /*Utilities.LogMessage("LaunchCreateAttributeWizard :: clicking attributes view grid");
                attributesGrid.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);*/

                while (false == foundContextMenu && attempt < retry)
                {
                    try
                    {

                        attributesGrid.Rows[0].AccessibleObject.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        attributesGrid.ScreenElement.WaitForReady();
                        CoreManager.MomConsole.Waiters.WaitForStatusReady(60000);

                        Utilities.LogMessage("LaunchCreateAttributeWizard  :: right clicking view to launch attribute creation wizard");
                        
                        ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
                        string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                            + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                            + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewAttributes;
                        actionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration,
                            monitoredComponentsPath,
                            ActionsPane.Strings.Attribute,
                            ActionsPane.Strings.CreateaNewAttribute);

                        CoreManager.MomConsole.Waiters.WaitForWindowForeground(CreateAttributeWizardGeneralPropertiesDialog, Constants.OneMinute);
                        Utilities.TakeScreenshot("Lauch Create Attribute Wizard");

                        foundContextMenu = true;
                    }
                    catch
                    {
                        //// log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "LaunchCreateAttributeWizard :: Attempt " + attempt + " of " + retry);
                        attempt++;
                        CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                        Sleeper.Delay(this.timeout);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigates thru Attribute creation wizard, to create an attribute
        /// </summary>
        /// <param name="attribParams">Attribute Parameters</param>
        /// ------------------------------------------------------------------
        private void NavigateThruCreateWizard(AttributeParameters attribParams)
        {
            //// Step-1 General properties
            Utilities.LogMessage("NavigateThruCreateWizard - step:1 :: '" + attribParams.AttribName + "'");
            
            this.CreateAttributeWizardGeneralPropertiesDialog.ScreenElement.WaitForReady();
            this.CreateAttributeWizardGeneralPropertiesDialog.Extended.SetFocus();

            ////Name
            Utilities.LogMessage("NavigateThruCreateWizard - step:1 typing attribute name '" + attribParams.AttribName + "'");
            this.CreateAttributeWizardGeneralPropertiesDialog.NameText = attribParams.AttribName;

            ////Description
            Utilities.LogMessage("NavigateThruCreateWizard - step:1 typing attribute description '" + attribParams.AttribDesc + "'");
            this.CreateAttributeWizardGeneralPropertiesDialog.DescriptionText = attribParams.AttribDesc;
            ////click next
            this.CreateAttributeWizardGeneralPropertiesDialog.ClickNext();

            //// Step-2 Discovery Method
            Utilities.LogMessage("NavigateThruCreateWizard - step:2 :: '" + attribParams.AttribName + "'");
            
            this.CreateAttributeWizardDiscoveryMethodDialog.ScreenElement.WaitForReady();
            this.CreateAttributeWizardDiscoveryMethodDialog.Extended.SetFocus();

            ////Pick a Discovery Type
            Utilities.LogMessage("NavigateThruCreateWizard - step:2 Picking a discovery/attribute type");
            switch (attribParams.AttribType)
            {
                case AttributeType.Registry:
                    this.CreateAttributeWizardDiscoveryMethodDialog.DiscoveryTypeText = Strings.AttributeTypeRegistry;
                    break;
                case AttributeType.WMI:
                    this.CreateAttributeWizardDiscoveryMethodDialog.DiscoveryTypeText = Strings.AttributeTypeWMIQuery;
                    break;
            }
            
            this.CreateAttributeWizardDiscoveryMethodDialog.ScreenElement.WaitForReady();
            this.CreateAttributeWizardDiscoveryMethodDialog.Extended.SetFocus();

            ////Select Target
            Utilities.LogMessage("NavigateThruCreateWizard - step:2 Selecting a target '" + attribParams.AttribTargetClassDisplayString + "'");
            this.CreateAttributeWizardDiscoveryMethodDialog.ClickBrowse();
            CoreManager.MomConsole.Waiters.WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType.Wait, 60000);
            this.CommonTargetSelectclassDialogWindow.ScreenElement.WaitForReady();
            /*this.AttributeTargetSelectclassDialogWindow.Extended.SetFocus();
            this.AttributeTargetSelectclassDialogWindow.WaitForResponse();
            UISynchronization.WaitForProcessReady(this.AttributeTargetSelectclassDialogWindow, 30000);
            UISynchronization.WaitForUIObjectReady(this.AttributeTargetSelectclassDialogWindow, 30000);*/

            this.CommonTargetSelectclassDialogWindow.Extended.SetFocus();

            this.CommonTargetSelectclassDialogWindow.LookForText = attribParams.AttribTargetClassDisplayString;
            this.CommonTargetSelectclassDialogWindow.Controls.ListView0.ScreenElement.WaitForReady();
            foreach (ListViewItem item in this.CommonTargetSelectclassDialogWindow.Controls.ListView0.Items)
            {
                if (item.Text.StartsWith(attribParams.AttribTargetClassDisplayString, StringComparison.InvariantCultureIgnoreCase))
                {
                    Utilities.LogMessage("Class found in target grid: '" + attribParams.AttribTargetClassDisplayString + "'");
                    item.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                    break;
                }

            }

            Utilities.LogMessage("Selected Target: '" + attribParams.AttribTargetClassDisplayString + "'");
            
            ////Press OK after selecting Target
            Utilities.LogMessage("NavigateThruCreateWizard - step:2 Pressing OK after selecting a target '" + attribParams.AttribName + "'");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.CommonTargetSelectclassDialogWindow.Controls.OKButton);
            this.CommonTargetSelectclassDialogWindow.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(this.CommonTargetSelectclassDialogWindow, Constants.OneMinute / Constants.OneSecond);

            this.CreateAttributeWizardDiscoveryMethodDialog.ScreenElement.WaitForReady();
            this.CreateAttributeWizardDiscoveryMethodDialog.Extended.SetFocus();

            ////Select MP
            this.CreateAttributeWizardDiscoveryMethodDialog.ManagementPackText = attribParams.AttribMPDisplayString;
            Utilities.LogMessage("Selected MP: '" + attribParams.AttribMPDisplayString + "'");
            this.CreateAttributeWizardDiscoveryMethodDialog.ScreenElement.WaitForReady();

            Utilities.LogMessage("Click Next...:: ");
            this.CreateAttributeWizardDiscoveryMethodDialog.Extended.SetFocus();

            ////click next
            this.CreateAttributeWizardDiscoveryMethodDialog.Controls.NextButton.ScreenElement.WaitForReady();
            this.CreateAttributeWizardDiscoveryMethodDialog.Controls.NextButton.Extended.SetFocus();
            this.CreateAttributeWizardDiscoveryMethodDialog.ClickNext();

            //// Step-3 Discovery Method
            Utilities.LogMessage("NavigateThruCreateWizard - step:3 :: '" + attribParams.AttribName + "'");

            switch (attribParams.AttribType)
            {
                case AttributeType.Registry:
                    this.CreateAttributeWizardRegProbeConfigDialog.ScreenElement.WaitForReady();
                    this.CreateAttributeWizardRegProbeConfigDialog.Extended.SetFocus();
                    switch (attribParams.RegKeyOrValue)
                    {
                        case RegistryType.Key:
                            Utilities.LogMessage("Selecting Registry type as Key");
                            //select Key radio button
                            this.CreateAttributeWizardRegProbeConfigDialog.Controls.KeyRadioButton.Click();
                            this.CreateAttributeWizardRegProbeConfigDialog.ScreenElement.WaitForReady();
                            //if key autoset datatype as "Check if exists"
                            this.CreateAttributeWizardRegProbeConfigDialog.AttributeTypeText = Strings.RegistryValueDataTypeCheckIfExists;
                            break;
                        case RegistryType.Value:
                            Utilities.LogMessage("Selecting Registry type as Value");
                            //select Value radio button
                            this.CreateAttributeWizardRegProbeConfigDialog.Controls.ValueRadioButton.Click();
                            this.CreateAttributeWizardRegProbeConfigDialog.ScreenElement.WaitForReady();
                            ////Type attribute path
                            ////Utilities.LogMessage("NavigateThruCreateWizard - step:3 typing Registry path under HKLM '" + attribParams.RegPathOrWMINameSpace + "'");
                            ////this.CreateAttributeWizardRegProbeConfigDialog.HKEY_LOCAL_MACHINEText = attribParams.RegPathOrWMINameSpace;
                            //Pick attribute data type
                            switch (attribParams.RegValueDataType)
                            {
                                case RegistryValueDataType.Bool:
                                    Utilities.LogMessage("Selecting Data type as Bool");
                                    this.CreateAttributeWizardRegProbeConfigDialog.AttributeTypeText = Strings.RegistryValueDataTypeBool;
                                    break;
                                case RegistryValueDataType.Float:
                                    Utilities.LogMessage("Selecting Data type as Float");
                                    this.CreateAttributeWizardRegProbeConfigDialog.AttributeTypeText = Strings.RegistryValueDataTypeFloat;
                                    break;
                                case RegistryValueDataType.Int:
                                    Utilities.LogMessage("Selecting Data type as Int");
                                    this.CreateAttributeWizardRegProbeConfigDialog.AttributeTypeText = Strings.RegistryValueDataTypeInt;
                                    break;
                                case RegistryValueDataType.String:
                                    Utilities.LogMessage("Selecting Data type as String");
                                    this.CreateAttributeWizardRegProbeConfigDialog.AttributeTypeText = Strings.RegistryValueDataTypeString;
                                    break;
                            }
                            break;
                    }
                    this.CreateAttributeWizardRegProbeConfigDialog.ScreenElement.WaitForReady();
                    ////Type attribute path
                    Utilities.LogMessage("NavigateThruCreateWizard - step:3 typing Registry path under HKLM '" + attribParams.RegPathOrWMINameSpace + "'");
                    this.CreateAttributeWizardRegProbeConfigDialog.HKEY_LOCAL_MACHINEText = attribParams.RegPathOrWMINameSpace;
                    this.CreateAttributeWizardRegProbeConfigDialog.ScreenElement.WaitForReady();
                    this.CreateAttributeWizardRegProbeConfigDialog.ClickFinish();
                    CoreManager.MomConsole.WaitForDialogClose(this.CreateAttributeWizardRegProbeConfigDialog, Constants.OneMinute / Constants.OneSecond);
                    break;
                case AttributeType.WMI:
                    this.CreateAttributeWizardWMIConfigDialog.ScreenElement.WaitForReady();
                    this.CreateAttributeWizardWMIConfigDialog.Extended.SetFocus();
                    ////WMI Name Space
                    Utilities.LogMessage("NavigateThruCreateWizard - step:3 typing WMI Name space '" + attribParams.RegPathOrWMINameSpace + "'");
                    this.CreateAttributeWizardWMIConfigDialog.NameText = attribParams.RegPathOrWMINameSpace;
                    this.CreateAttributeWizardWMIConfigDialog.ScreenElement.WaitForReady();

                    ////WMI Query
                    Utilities.LogMessage("NavigateThruCreateWizard - step:3 typing WMI Query '" + attribParams.WMIQuery + "'");
                    this.CreateAttributeWizardWMIConfigDialog.WMIQueryText = attribParams.WMIQuery;
                    this.CreateAttributeWizardWMIConfigDialog.ScreenElement.WaitForReady();

                    ////WMI Property Name
                    Utilities.LogMessage("NavigateThruCreateWizard - step:3 typing WMI Property Name '" + attribParams.WMIQuery + "'");
                    this.CreateAttributeWizardWMIConfigDialog.PropertyNameText = attribParams.WMIPropertyName;
                    this.CreateAttributeWizardWMIConfigDialog.ScreenElement.WaitForReady();
                    this.CreateAttributeWizardWMIConfigDialog.ClickFinish();
                    CoreManager.MomConsole.WaitForDialogClose(this.CreateAttributeWizardWMIConfigDialog, Constants.OneMinute / Constants.OneSecond);
                    break;
            }

            CoreManager.MomConsole.Waiters.WaitForStatusReady(60000);
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 60000);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 60000);
             CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();

        }

        #endregion 

        #region public methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Launches Attribute creation wizard, navigates thru the wizard to create an attribute
        /// </summary>
        /// <param name="attribParameters">Attribute Parameters</param>
        /// ------------------------------------------------------------------
        public void CreateAttribute(AttributeParameters attribParameters)
        {
            ////Launch Create Wizard
            Utilities.LogMessage("CreateAttribute");
            this.LaunchCreateAttributeWizard();

            this.NavigateThruCreateWizard(attribParameters);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Verifies existence of an attribute
        /// </summary>
        /// <param name="attParam">Attribute Parameters</param>
        /// <param name="objectDiscovery">true = verify Object Discovery; false = verify attribute</param>
        /// <returns>True/False</returns>
        /// ------------------------------------------------------------------
        public bool VerifyCreatedAttribute(AttributeParameters attParam, bool objectDiscovery)
        {
            int retry = 0;
            int maxTries = 10;
            bool found = false;
            DataGridViewRow resultTop = null;

            CoreManager.MomConsole.Waiters.WaitForReady();

            if (!objectDiscovery)
                this.NavigateToAttributesNode(true);
            else
                this.NavigateToAttributesNode(false);

            CoreManager.MomConsole.ViewPane.ChangeConsoleScope(new ViewPane.TargetType[] { new ViewPane.TargetType(attParam.AttribTargetClassDisplayString, attParam.AttribMPDisplayString, true) },
                false, 10);

            CoreManager.MomConsole.Waiters.WaitForObjectPropertyChangedSafe(CoreManager.MomConsole.ViewPane.Grid.Rows, "@Count", Constants.OneMinute * 2);
            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();

            CoreManager.MomConsole.ViewPane.Extended.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
            CoreManager.MomConsole.SendKeys(KeyboardCodes.F5);

            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();

            //Record the original row count of CoreManager.MomConsole.ViewPane.Grid.
            int originalGridRowCount = CoreManager.MomConsole.ViewPane.Grid.Rows.Count;
            #region Find the attribute by "Look for" bar
            try
            {
                if (CoreManager.MomConsole.ViewPane.Find.Controls.FindNowButton.Extended.IsEnabled)
                {
                    Core.Common.Utilities.LogMessage("VerifyCreatedAttribute :: Findbar displays in UI, set Look for Text");
                    CoreManager.MomConsole.ViewPane.Find.LookForText = attParam.AttribName;
                    CoreManager.MomConsole.ViewPane.Find.ClickFindNow();
                }
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {                
                Core.Common.Utilities.LogMessage("VerifyCreatedAttribute :: Findbar does not display in UI, click Find Button to make it show.");

                //Workaround here for bug#172988
                this.NavigateToAttributesNode(false);

                Core.Common.Utilities.LogMessage("VerifyCreatedAttribute :: Click Find Button in ToolBar...");
                Maui.Core.WinControls.Button findButton =
                    new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA]Name = \'" + Strings.FindButtonText + "\' && Role = 'push button'"), 6000);
                findButton.Click();

                CoreManager.MomConsole.Waiters.WaitForReady();

                // Navigate to Monitoring
                CoreManager.MomConsole.NavigationPane.SelectNode(NavigationPane.Strings.Monitoring, NavigationPane.NavigationTreeView.Monitoring);
                CoreManager.MomConsole.Waiters.WaitForReady();

                this.NavigateToAttributesNode(true);

                CoreManager.MomConsole.Waiters.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.ViewPane.Grid, Constants.OneMinute);

                try
                {
                    if (CoreManager.MomConsole.ViewPane.Find.Controls.FindNowButton.Extended.IsEnabled)
                    {
                        Core.Common.Utilities.LogMessage("VerifyCreatedAttribute :: Set Look for Text");
                        CoreManager.MomConsole.ViewPane.Find.LookForText = attParam.AttribName;
                        CoreManager.MomConsole.ViewPane.Find.ClickFindNow();

                        CoreManager.MomConsole.Waiters.WaitForReady();
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.ViewPane.Grid, Constants.OneMinute);
                    }
                }
                catch(Window.Exceptions.WindowNotFoundException ex)
                {
                    Core.Common.Utilities.LogMessage("VerifyCreatedAttribute :: Findbar still not displays in UI.");
                    throw ex;
                }
            }
            #endregion

            CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.ViewPane.Grid, Constants.OneMinute * 5);

            //Wait find action finished in five seconds
            for (int i = 0; i < maxTries; i++)
            {
                if (originalGridRowCount == CoreManager.MomConsole.ViewPane.Grid.Rows.Count)
                {
                    Core.Common.Utilities.LogMessage("VerifyCreatedAttribute :: Grid.Rows.Count is" +
                        CoreManager.MomConsole.ViewPane.Grid.Rows.Count +
                        ", Not changed, Sleep one second and retry");
                    Sleeper.Delay(Constants.OneSecond);
                }
                else
                {
                    Core.Common.Utilities.LogMessage("VerifyCreatedAttribute :: Find operation finished, Found " +
                        CoreManager.MomConsole.ViewPane.Grid.Rows.Count+ 
                        " Records");
                    break;
                }
            }
            
            if (!objectDiscovery)
                Core.Common.Utilities.LogMessage("VerifyCreatedAttribute :: Find '" + attParam.AttribName + "'");
            else
                Core.Common.Utilities.LogMessage("VerifyCreatedDiscovery :: Find '" + attParam.AttribName + "'");

            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute * 2);
                  
            //attributeGrid = new GridControl(CoreManager.MomConsole.MainWindow, GridControl.ControlIDs.ViewPaneGrid);
            //resultTop = attributeGrid.FindData(attParam.AttribName, Strings.AttributesViewNameColumn, GridControl.SearchStringMatchType.ExactMatch);
       
            while ((resultTop == null) && (retry <= maxTries))
            {
                if (!objectDiscovery)
                    Utilities.TakeScreenshot("FindAttribute_Attempt_" + retry);
                else
                    Utilities.TakeScreenshot("FindDiscovery_Attempt_" + retry);

                CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
                //For some reason Find on name col. *doesn't* work
                //resultTop = attributeGrid.FindData(attParam.AttribName, Strings.AttributesViewNameColumn);
                resultTop = CoreManager.MomConsole.ViewPane.Grid.FindData(attParam.AttribName, 0);

                //fix #192640: the created Attributes doesn't present in the View pane 
                if (resultTop == null)
                {
                    //No need to LookForItem for the last retry
                    if (retry < maxTries)
                    {
                        Core.Common.Utilities.LogMessage(
                       "VerifyCreatedAttribute :: Wait three seconds and Click clear button and re-find the Attribute");
                        Sleeper.Delay(Constants.OneSecond * 3);
                        //Find.LookForItem() will click Clear button first and then fill the LookForText and click FindNow button
                        CoreManager.MomConsole.ViewPane.Find.LookForItem(attParam.AttribName);
                    }
                }
                else
                {
                    Core.Common.Utilities.LogMessage(
                        "VerifyCreatedAttribute :: found the created Attribute:" + attParam.AttribName);
                    break;
                }

                //// log unsuccessful attempt
                if (!objectDiscovery)
                    Core.Common.Utilities.LogMessage(
                        "VerifyCreatedAttribute :: Attempt " + retry + " of " + maxTries);
                else
                    Core.Common.Utilities.LogMessage(
                        "VerifyCreatedDiscovery :: Attempt " + retry + " of " + maxTries);
                retry++;
            }
           

            if (resultTop == null)
            {
                if (!objectDiscovery)
                {
                    Utilities.LogMessage("VerifyCreatedAttribute :: Unable to find '" + attParam.AttribName + "'");
                    Utilities.TakeScreenshot("VerifyCreatedAttribute_failure");
                }
                else
                {
                    Utilities.LogMessage("VerifyCreatedDiscovery :: Unable to find '" + attParam.AttribName + "'");
                    Utilities.TakeScreenshot("VerifyCreatedDiscovery_failure");
                }
            }
            
            else
            {
                if (!objectDiscovery)
                    Utilities.LogMessage("VerifyCreatedAttribute :: Found '" + attParam.AttribName + "'");
                else
                    Utilities.LogMessage("VerifyCreatedDiscovery :: Found '" + attParam.AttribName + "'");
                found = true;
            }

            return found;
        }

      
        #endregion

        #region strings
        /// <summary>
        /// Strings
        /// </summary>
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Create a new attribute... context menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuCreateAttribute = ";Cre&ate a new attribute...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.AttributesView.AttributesViewResources;CreateAttributeContextMenu";
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AttributeTypeWMIQuery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAttributeTypeWMIQuery = ";WMI Query;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Attribute.AttributeWizardResources;WmiDiscovery";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AttributeTypeRegistry
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAttributeTypeRegistry = ";Registry;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Attribute.AttributeWizardResources;RegistryDiscovery";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RegistryValueDataTypeBool
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRegistryValueDataTypeBool = ";Bool;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbe.RegistryProbeStrings;valueBool";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RegistryValueDataTypeString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRegistryValueDataTypeString = ";String;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbe.RegistryProbeStrings;valueString";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RegistryValueDataTypeInt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRegistryValueDataTypeInt = ";Int;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbe.RegistryProbeStrings;valueInt";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RegistryValueDataTypeFloat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRegistryValueDataTypeFloat = ";Float;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbe.RegistryProbeStrings;valueFloat";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for RegistryValueDataTypeCheckIfExists
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRegistryValueDataTypeCheckIfExists = ";Check if exists;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbe.RegistryProbeStrings;valueCheck";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for FindButtonText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFindButtonText = ";Fi&nd;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources;FindButtonText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AttributesViewNameColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAttributesViewNameColumn = "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AttributesViewInheritedFromColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAttributesViewInheritedFromColumn = "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AttributesViewDiscoveryTypeColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAttributesViewDiscoveryTypeColumn = "";


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AttributesViewMPColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAttributesViewMPColumn = "";



            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for Create a new attribute... context menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuCreateAttribute;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for AttributeTypeWMIQuery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAttributeTypeWMIQuery;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for AttributeTypeRegistry
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAttributeTypeRegistry;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for RegistryValueDataTypeBool
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRegistryValueDataTypeBool;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for RegistryValueDataTypeString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRegistryValueDataTypeString;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for RegistryValueDataTypeInt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRegistryValueDataTypeInt;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for RegistryValueDataTypeFloat
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRegistryValueDataTypeFloat;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for FindButtonText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFindButtonText;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for RegistryValueDataTypeCheckIfExists
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRegistryValueDataTypeCheckIfExists;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for AttributesViewNameColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAttributesViewNameColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for AttributesViewInheritedFromColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAttributesViewInheritedFromColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for AttributesViewDiscoveryTypeColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAttributesViewDiscoveryTypeColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains cached resource string for AttributesViewMPColumn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAttributesViewMPColumn;



            #endregion

            #region properties

            /// <summary>
            /// Create a new attribute... context menu
            /// </summary>
            public static string ContextMenuCreateAttribute
            {
                get
                {
                    if ((cachedContextMenuCreateAttribute == null))
                    {
                        cachedContextMenuCreateAttribute = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuCreateAttribute);
                    }

                    return cachedContextMenuCreateAttribute;
                }
            }

            /// <summary>
            /// AttributeTypeWMIQuery
            /// </summary>
            public static string AttributeTypeWMIQuery
            {
                get
                {
                    if ((cachedAttributeTypeWMIQuery == null))
                    {
                        cachedAttributeTypeWMIQuery = CoreManager.MomConsole.GetIntlStr(ResourceAttributeTypeWMIQuery);
                    }

                    return cachedAttributeTypeWMIQuery;
                }
            }

            /// <summary>
            /// AttributeTypeRegistry
            /// </summary>
            public static string AttributeTypeRegistry
            {
                get
                {
                    if ((cachedAttributeTypeRegistry == null))
                    {
                        cachedAttributeTypeRegistry = CoreManager.MomConsole.GetIntlStr(ResourceAttributeTypeRegistry);
                    }

                    return cachedAttributeTypeRegistry;
                }
            }

            /// <summary>
            /// RegistryValueDataTypeBool
            /// </summary>
            public static string RegistryValueDataTypeBool
            {
                get
                {
                    if ((cachedRegistryValueDataTypeBool == null))
                    {
                        cachedRegistryValueDataTypeBool = CoreManager.MomConsole.GetIntlStr(ResourceRegistryValueDataTypeBool);
                    }

                    return cachedRegistryValueDataTypeBool;
                }
            }

            /// <summary>
            /// RegistryValueDataTypeString
            /// </summary>
            public static string RegistryValueDataTypeString
            {
                get
                {
                    if ((cachedRegistryValueDataTypeString == null))
                    {
                        cachedRegistryValueDataTypeString = CoreManager.MomConsole.GetIntlStr(ResourceRegistryValueDataTypeString);
                    }

                    return cachedRegistryValueDataTypeString;
                }
            }

            /// <summary>
            /// RegistryValueDataTypeInt
            /// </summary>
            public static string RegistryValueDataTypeInt
            {
                get
                {
                    if ((cachedRegistryValueDataTypeInt == null))
                    {
                        cachedRegistryValueDataTypeInt = CoreManager.MomConsole.GetIntlStr(ResourceRegistryValueDataTypeInt);
                    }

                    return cachedRegistryValueDataTypeInt;
                }
            }

            /// <summary>
            /// RegistryValueDataTypeFloat
            /// </summary>
            public static string RegistryValueDataTypeFloat
            {
                get
                {
                    if ((cachedRegistryValueDataTypeFloat == null))
                    {
                        cachedRegistryValueDataTypeFloat = CoreManager.MomConsole.GetIntlStr(ResourceRegistryValueDataTypeFloat);
                    }

                    return cachedRegistryValueDataTypeFloat;
                }
            }

            /// <summary>
            /// FindButtonText
            /// </summary>
            public static string FindButtonText
            {
                get
                {
                    if ((cachedFindButtonText == null))
                    {
                        cachedFindButtonText = CoreManager.MomConsole.GetIntlStr(ResourceFindButtonText);
                    }

                    return cachedFindButtonText;
                }
            }

            /// <summary>
            /// RegistryValueDataTypeCheckIfExists
            /// </summary>
            public static string RegistryValueDataTypeCheckIfExists
            {
                get
                {
                    if ((cachedRegistryValueDataTypeCheckIfExists == null))
                    {
                        cachedRegistryValueDataTypeCheckIfExists = CoreManager.MomConsole.GetIntlStr(ResourceRegistryValueDataTypeCheckIfExists);
                    }

                    return cachedRegistryValueDataTypeCheckIfExists;
                }
            }

            /// <summary>
            /// AttributesViewNameColumn
            /// </summary>
            public static string AttributesViewNameColumn
            {
                get
                {
                    if ((cachedAttributesViewNameColumn == null))
                    {
                        cachedAttributesViewNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceAttributesViewNameColumn);
                    }

                    return cachedAttributesViewNameColumn;
                }
            }

            /// <summary>
            /// AttributesViewInheritedFromColumn
            /// </summary>
            public static string AttributesViewInheritedFromColumn
            {
                get
                {
                    if ((cachedAttributesViewInheritedFromColumn == null))
                    {
                        cachedAttributesViewInheritedFromColumn = CoreManager.MomConsole.GetIntlStr(ResourceAttributesViewInheritedFromColumn);
                    }

                    return cachedAttributesViewInheritedFromColumn;
                }
            }

            /// <summary>
            /// AttributesViewDiscoveryTypeColumn
            /// </summary>
            public static string AttributesViewDiscoveryTypeColumn
            {
                get
                {
                    if ((cachedAttributesViewDiscoveryTypeColumn == null))
                    {
                        cachedAttributesViewDiscoveryTypeColumn = CoreManager.MomConsole.GetIntlStr(ResourceAttributesViewDiscoveryTypeColumn);
                    }

                    return cachedAttributesViewDiscoveryTypeColumn;
                }
            }

            /// <summary>
            /// AttributesViewMPColumn
            /// </summary>
            public static string AttributesViewMPColumn
            {
                get
                {
                    if ((cachedAttributesViewMPColumn == null))
                    {
                        cachedAttributesViewMPColumn = CoreManager.MomConsole.GetIntlStr(ResourceAttributesViewMPColumn);
                    }

                    return cachedAttributesViewMPColumn;
                }
            }

            #endregion
        }
        #endregion
    }
}

