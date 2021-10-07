// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceNameProperties.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 01-Sep-05 Created
// 	[v-brucec] 15-Aug-09 Changed format of dialog title.
// 	[v-brucec] 01-Sep-09 Added parameter "title" to method Init()
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    using System.ComponentModel;
    using System.Globalization;

    #region Interface Definition - IServiceNamePropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceNamePropertiesControls, for ServiceNameProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 01-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceNamePropertiesControls
    {
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
        /// Read-only property to access NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl
        /// </summary>
        StaticControl NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceNameStaticControl
        /// </summary>
        StaticControl ServiceNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceNameTextBox
        /// </summary>
        TextBox ServiceNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl
        /// </summary>
        StaticControl YouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Service Name" TAB of the Windows Service Monitor Properties.
    /// This class manages the advanced functions for the "Service Name" Tab Properties
    /// </summary>
    /// <history>
    /// 	[ruhim] 01-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServiceNameProperties : Dialog, IServiceNamePropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to YouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>Owner of ServiceNameProperties of type App</param>
        /// <param name="title">Dialog Title</param>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceNameProperties(Maui.Core.App app, string title)
            : 
                base(app, Init(app, title))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IServiceNameProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceNamePropertiesControls Controls
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
        ///  Routine to set/get the text in control ServiceName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceNameText
        {
            get
            {
                return this.Controls.ServiceNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ServiceNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IServiceNamePropertiesControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, ServiceNameProperties.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNamePropertiesControls.NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl
        {
            get
            {
                if ((this.cachedNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl == null))
                {
                    this.cachedNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl = new StaticControl(this, ServiceNameProperties.ControlIDs.NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl);
                }
                return this.cachedNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNamePropertiesControls.ServiceNameStaticControl
        {
            get
            {
                if ((this.cachedServiceNameStaticControl == null))
                {
                    this.cachedServiceNameStaticControl = new StaticControl(this, ServiceNameProperties.ControlIDs.ServiceNameStaticControl);
                }
                return this.cachedServiceNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceNamePropertiesControls.ServiceNameTextBox
        {
            get
            {
                if ((this.cachedServiceNameTextBox == null))
                {
                    this.cachedServiceNameTextBox = new TextBox(this, ServiceNameProperties.ControlIDs.ServiceNameTextBox);
                }
                return this.cachedServiceNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceNamePropertiesControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, ServiceNameProperties.ControlIDs.Button0);
                }
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceNamePropertiesControls.YouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl
        {
            get
            {
                if ((this.cachedYouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl == null))
                {
                    this.cachedYouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl = new StaticControl(this, ServiceNameProperties.ControlIDs.YouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl);
                }
                return this.cachedYouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IServiceNamePropertiesControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, ServiceNameProperties.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog with specified title.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <param name="title">specified title.</param>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        ///	    [v-brucec] 15-Aug-09 Changed format of dialog title.
        ///	    [v-brucec] 01-Sep-09 Add title as parameter
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app, string title)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            string tempTitle = string.Empty;

            if (!string.IsNullOrEmpty(title))
            {
                tempTitle = string.Format(CultureInfo.CurrentUICulture, Strings.DialogTitle, title);
            }

            try
            {
                tempWindow = new Window("*" + tempTitle,
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 10;
                Core.Common.Utilities.LogMessage("ServiceNameProperties.Init :: Looking for window with title:  '"
                    + tempTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            "*" + tempTitle,
                            StringMatchSyntax.WildCard);

                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);

                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("ServiceNameProperties.Init :: Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }

                }

                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window "
                        + "with a title of '" + tempTitle
                        + "'.\n\n" + ex.Message);
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
        /// 	[ruhim] 01-Sep-05 Created
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
            private const string ResourceDialogTitle = 
            ";{0} Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;MPObjectFormatString";
            
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
            /// Contains resource string for:  NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted = ";Note: The service must exist in the computer where the target managed entity is " +
                "hosted.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.Pages.ServiceStateProbePage;noteLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceName = ";&Service name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.ServiceStateProbePage;serviceNameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanBrowseToAComputerToViewAndSelectFromAvailableServices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanBrowseToAComputerToViewAndSelectFromAvailableServices = ";You can browse to a computer to view and select from available services.;Managed" +
                "String;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Intern" +
                "al.UI.Authoring.Pages.ServiceStateProbePage;infoLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
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
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanBrowseToAComputerToViewAndSelectFromAvailableServices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanBrowseToAComputerToViewAndSelectFromAvailableServices;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
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
            /// Exposes access to the NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted
            {
                get
                {
                    if ((cachedNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted == null))
                    {
                        cachedNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted = CoreManager.MomConsole.GetIntlStr(ResourceNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted);
                    }
                    return cachedNoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHosted;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceName
            {
                get
                {
                    if ((cachedServiceName == null))
                    {
                        cachedServiceName = CoreManager.MomConsole.GetIntlStr(ResourceServiceName);
                    }
                    return cachedServiceName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanBrowseToAComputerToViewAndSelectFromAvailableServices translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanBrowseToAComputerToViewAndSelectFromAvailableServices
            {
                get
                {
                    if ((cachedYouCanBrowseToAComputerToViewAndSelectFromAvailableServices == null))
                    {
                        cachedYouCanBrowseToAComputerToViewAndSelectFromAvailableServices = CoreManager.MomConsole.GetIntlStr(ResourceYouCanBrowseToAComputerToViewAndSelectFromAvailableServices);
                    }
                    return cachedYouCanBrowseToAComputerToViewAndSelectFromAvailableServices;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1
            {
                get
                {
                    if ((cachedToolStrip1 == null))
                    {
                        cachedToolStrip1 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1);
                    }
                    return cachedToolStrip1;
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
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl
            /// </summary>
            public const string NoteTheServiceMustExistInTheComputerWhereTheTargetManagedEntityIsHostedStaticControl = "noteLabel";
            
            /// <summary>
            /// Control ID for ServiceNameStaticControl
            /// </summary>
            public const string ServiceNameStaticControl = "serviceNameLabel";
            
            /// <summary>
            /// Control ID for ServiceNameTextBox
            /// </summary>
            public const string ServiceNameTextBox = "serviceNameTextBox";
            
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "browseButton";
            
            /// <summary>
            /// Control ID for YouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl
            /// </summary>
            public const string YouCanBrowseToAComputerToViewAndSelectFromAvailableServicesStaticControl = "infoLabel";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "stripTop";
        }
        #endregion
    }
}
