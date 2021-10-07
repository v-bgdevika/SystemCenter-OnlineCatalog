// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceDiagramLegendWindow.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Automation
// </summary>
// <history>
// 	[KellyMor] 08-Sep-05 Created
//  [KellyMor] 10-Oct-07 Updated Init method
//                       Updated window title resource string
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.ServiceDiagram
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IServiceDiagramLegendWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceDiagramLegendWindowControls, for ServiceDiagramLegendWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 08-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceDiagramLegendWindowControls
    {
        /// <summary>
        /// Read-only property to access SystemMomManagementServerStaticControl
        /// </summary>
        StaticControl SystemMomManagementServerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SystemWindowsComputerStaticControl
        /// </summary>
        StaticControl SystemWindowsComputerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChildContainmentStaticControl
        /// </summary>
        StaticControl ChildContainmentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParentContainmentStaticControl
        /// </summary>
        StaticControl ParentContainmentStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SuccessStaticControl
        /// </summary>
        StaticControl SuccessStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningStaticControl
        /// </summary>
        StaticControl WarningStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CriticalErrorStaticControl
        /// </summary>
        StaticControl CriticalErrorStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UnknownStaticControl
        /// </summary>
        StaticControl UnknownStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to automate the legend window
    /// </summary>
    /// <history>
    /// 	[KellyMor] 08-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServiceDiagramLegendWindow : Window, IServiceDiagramLegendWindowControls
    {
        #region Protected Internal Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        protected internal static Window activeWindow;
        #endregion
        
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SystemMomManagementServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSystemMomManagementServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SystemWindowsComputerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSystemWindowsComputerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChildContainmentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChildContainmentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ParentContainmentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParentContainmentStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SuccessStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSuccessStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WarningStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWarningStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CriticalErrorStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCriticalErrorStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UnknownStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUnknownStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of ServiceDiagramLegendWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceDiagramLegendWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IServiceDiagramLegendWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceDiagramLegendWindowControls Controls
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
        ///  Exposes access to the SystemMomManagementServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceDiagramLegendWindowControls.SystemMomManagementServerStaticControl
        {
            get
            {
                if ((this.cachedSystemMomManagementServerStaticControl == null))
                {
                    this.cachedSystemMomManagementServerStaticControl = new StaticControl(this, ServiceDiagramLegendWindow.ControlIDs.SystemMomManagementServerStaticControl);
                }
                return this.cachedSystemMomManagementServerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SystemWindowsComputerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceDiagramLegendWindowControls.SystemWindowsComputerStaticControl
        {
            get
            {
                if ((this.cachedSystemWindowsComputerStaticControl == null))
                {
                    this.cachedSystemWindowsComputerStaticControl = new StaticControl(this, ServiceDiagramLegendWindow.ControlIDs.SystemWindowsComputerStaticControl);
                }
                return this.cachedSystemWindowsComputerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChildContainmentStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceDiagramLegendWindowControls.ChildContainmentStaticControl
        {
            get
            {
                if ((this.cachedChildContainmentStaticControl == null))
                {
                    this.cachedChildContainmentStaticControl = new StaticControl(this, ServiceDiagramLegendWindow.ControlIDs.ChildContainmentStaticControl);
                }
                return this.cachedChildContainmentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParentContainmentStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceDiagramLegendWindowControls.ParentContainmentStaticControl
        {
            get
            {
                if ((this.cachedParentContainmentStaticControl == null))
                {
                    this.cachedParentContainmentStaticControl = new StaticControl(this, ServiceDiagramLegendWindow.ControlIDs.ParentContainmentStaticControl);
                }
                return this.cachedParentContainmentStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SuccessStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceDiagramLegendWindowControls.SuccessStaticControl
        {
            get
            {
                if ((this.cachedSuccessStaticControl == null))
                {
                    this.cachedSuccessStaticControl = new StaticControl(this, ServiceDiagramLegendWindow.ControlIDs.SuccessStaticControl);
                }
                return this.cachedSuccessStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WarningStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceDiagramLegendWindowControls.WarningStaticControl
        {
            get
            {
                if ((this.cachedWarningStaticControl == null))
                {
                    this.cachedWarningStaticControl = new StaticControl(this, ServiceDiagramLegendWindow.ControlIDs.WarningStaticControl);
                }
                return this.cachedWarningStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CriticalErrorStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceDiagramLegendWindowControls.CriticalErrorStaticControl
        {
            get
            {
                if ((this.cachedCriticalErrorStaticControl == null))
                {
                    this.cachedCriticalErrorStaticControl = new StaticControl(this, ServiceDiagramLegendWindow.ControlIDs.CriticalErrorStaticControl);
                }
                return this.cachedCriticalErrorStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UnknownStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceDiagramLegendWindowControls.UnknownStaticControl
        {
            get
            {
                if ((this.cachedUnknownStaticControl == null))
                {
                    this.cachedUnknownStaticControl = new StaticControl(this, ServiceDiagramLegendWindow.ControlIDs.UnknownStaticControl);
                }
                return this.cachedUnknownStaticControl;
            }
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        /// <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = 
                    new Window(
                        CoreManager.MomConsole.GetIntlStr(Strings.WindowTitle), 
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
                                Strings.WindowTitle + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage("Failed to find window with title:  '" + Strings.WindowTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// String definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 08-Sep-05 Created
        ///     [KellyMor] 10-Oct-07 Updated window title resource string
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
            private const string ResourceWindowTitle = 
                ";Legend" + 
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" + 
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramLegend" + 
                ";$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SystemMomManagementServer
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSystemMomManagementServer = "System.Mom.ManagementServer";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SystemWindowsComputer
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSystemWindowsComputer = "System.Windows.Computer";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChildContainment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChildContainment = ";Child Containment;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Views.SharedResources;ServiceDiagramLegendChildCo" +
                "ntainment";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ParentContainment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceParentContainment = ";Parent Containment;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Views.SharedResources;ServiceDiagramLegendParent" +
                "Containment";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Success
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSuccess = ";Success;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.Pages.OperationalStatesMappingPage;Su" +
                "ccess";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Warning
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWarning = ";Warning;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Internal.UI.Authoring.Pages.OperationalStatesMappingPage;Wa" +
                "rning";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CriticalError
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCriticalError = ";Critical Error;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Views.SharedResources;StateRed1Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Unknown
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUnknown = ";Unknown;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Views.SharedResources;StateGray1Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SystemMomManagementServer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSystemMomManagementServer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SystemWindowsComputer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSystemWindowsComputer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChildContainment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChildContainment;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ParentContainment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedParentContainment;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Success
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSuccess;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Warning
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWarning;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CriticalError
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCriticalError;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Unknown
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUnknown;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    return cachedWindowTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SystemMomManagementServer translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SystemMomManagementServer
            {
                get
                {
                    if ((cachedSystemMomManagementServer == null))
                    {
                        cachedSystemMomManagementServer = CoreManager.MomConsole.GetIntlStr(ResourceSystemMomManagementServer);
                    }
                    return cachedSystemMomManagementServer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SystemWindowsComputer translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SystemWindowsComputer
            {
                get
                {
                    if ((cachedSystemWindowsComputer == null))
                    {
                        cachedSystemWindowsComputer = CoreManager.MomConsole.GetIntlStr(ResourceSystemWindowsComputer);
                    }
                    return cachedSystemWindowsComputer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChildContainment translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChildContainment
            {
                get
                {
                    if ((cachedChildContainment == null))
                    {
                        cachedChildContainment = CoreManager.MomConsole.GetIntlStr(ResourceChildContainment);
                    }
                    return cachedChildContainment;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ParentContainment translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ParentContainment
            {
                get
                {
                    if ((cachedParentContainment == null))
                    {
                        cachedParentContainment = CoreManager.MomConsole.GetIntlStr(ResourceParentContainment);
                    }
                    return cachedParentContainment;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Success translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Success
            {
                get
                {
                    if ((cachedSuccess == null))
                    {
                        cachedSuccess = CoreManager.MomConsole.GetIntlStr(ResourceSuccess);
                    }
                    return cachedSuccess;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Warning translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
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
            /// Exposes access to the CriticalError translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CriticalError
            {
                get
                {
                    if ((cachedCriticalError == null))
                    {
                        cachedCriticalError = CoreManager.MomConsole.GetIntlStr(ResourceCriticalError);
                    }
                    return cachedCriticalError;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Unknown translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 08-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Unknown
            {
                get
                {
                    if ((cachedUnknown == null))
                    {
                        cachedUnknown = CoreManager.MomConsole.GetIntlStr(ResourceUnknown);
                    }
                    return cachedUnknown;
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
        /// 	[KellyMor] 08-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SystemMomManagementServerStaticControl
            /// </summary>
            public const string SystemMomManagementServerStaticControl = "descriptionLabel0";
            
            /// <summary>
            /// Control ID for SystemWindowsComputerStaticControl
            /// </summary>
            public const string SystemWindowsComputerStaticControl = "descriptionLabel1";
            
            /// <summary>
            /// Control ID for ChildContainmentStaticControl
            /// </summary>
            public const string ChildContainmentStaticControl = "descriptionLabel2";
            
            /// <summary>
            /// Control ID for ParentContainmentStaticControl
            /// </summary>
            public const string ParentContainmentStaticControl = "descriptionLabel3";
            
            /// <summary>
            /// Control ID for SuccessStaticControl
            /// </summary>
            public const string SuccessStaticControl = "descriptionLabel4";
            
            /// <summary>
            /// Control ID for WarningStaticControl
            /// </summary>
            public const string WarningStaticControl = "descriptionLabel5";
            
            /// <summary>
            /// Control ID for CriticalErrorStaticControl
            /// </summary>
            public const string CriticalErrorStaticControl = "descriptionLabel6";
            
            /// <summary>
            /// Control ID for UnknownStaticControl
            /// </summary>
            public const string UnknownStaticControl = "descriptionLabel7";
        }
        #endregion
    }
}
