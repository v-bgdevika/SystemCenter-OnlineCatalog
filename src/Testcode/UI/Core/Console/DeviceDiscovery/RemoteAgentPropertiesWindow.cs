// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="RemoteAgentPropertiesWindow.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  MOMv3 Test UI automation
// </summary>
// <history>
//  [KellyMor] 28-Aug-05    Created
//  [KellyMor] 15-Sep-05    Updated resource string for the dialog title
//  [KellyMor] 16-Feb-05    Updated resource string for Window title again
//  [KellyMor] 27-Feb-06    Updated resource strings
//  [KellyMor] 02-Mar-06    Updated resource string for Window title yet again
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 24-Jul-06    Added click interface and methods for OK, Cancel, and Apply
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IRemoteAgentPropertiesWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IRemoteAgentPropertiesWindowControls, for RemoteAgentPropertiesWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 28-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRemoteAgentPropertiesWindowControls
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
        /// Read-only property to access TODOStaticControl
        /// </summary>
        StaticControl TODOStaticControl
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

        /// <summary>
        /// Read-only property to access OK button
        /// </summary>
        Button OkButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Cancel button
        /// </summary>
        Button CancelButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Apply button
        /// </summary>
        Button ApplyButton
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate Remote Agent Properties dialog functionality
    /// </summary>
    /// <history>
    /// 	[KellyMor] 28-Aug-05 Created
    ///     [KellyMor] 15-Sep-05 Updated resource string for the dialog title
    /// </history>
    /// -----------------------------------------------------------------------------
    public class RemoteAgentPropertiesWindow : Window, IRemoteAgentPropertiesWindowControls
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
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab0TabControl;
        
        /// <summary>
        /// Cache to hold a reference to TODOStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTODOStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;

        /// <summary>
        /// Cache to hold a reference to OkButton of type Button
        /// </summary>
        private Button cachedOkButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of RemoteAgentPropertiesWindow of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public RemoteAgentPropertiesWindow(Maui.Core.App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IRemoteAgentPropertiesWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRemoteAgentPropertiesWindowControls Controls
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
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IRemoteAgentPropertiesWindowControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, RemoteAgentPropertiesWindow.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TODOStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IRemoteAgentPropertiesWindowControls.TODOStaticControl
        {
            get
            {
                if ((this.cachedTODOStaticControl == null))
                {
                    this.cachedTODOStaticControl = new StaticControl(this, RemoteAgentPropertiesWindow.ControlIDs.TODOStaticControl);
                }
                return this.cachedTODOStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IRemoteAgentPropertiesWindowControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, RemoteAgentPropertiesWindow.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OkButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-Jul-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRemoteAgentPropertiesWindowControls.OkButton
        {
            get
            {
                if ((this.cachedOkButton == null))
                {
                    this.cachedOkButton = new Button(this, RemoteAgentPropertiesWindow.ControlIDs.OkButton);
                }
                return this.cachedOkButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-Jul-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRemoteAgentPropertiesWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, RemoteAgentPropertiesWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-Jul-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRemoteAgentPropertiesWindowControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, RemoteAgentPropertiesWindow.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }

        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ok
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-Jul-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOk()
        {
            this.Controls.OkButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 24-Jul-06 Created
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
        /// 	[KellyMor] 24-Jul-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }

        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        ///  <param name="ownerWindow">Maui.Core.App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 28-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(Maui.Core.App ownerWindow)
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
                        Strings.WindowTitle + "'");

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
        ///     [KellyMor] 15-Sep-05 Updated resource string for the dialog title
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
            private const string ResourceWindowTitle = ";Agentless Computer Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RemoteAgentProperties";
            
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
            /// Contains resource string for:  TODO
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTODO = ";//TODO;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.Administration.AgentGeneral;todo.Text";
            
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
            private static string cachedWindowTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TODO
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTODO;
            
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
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    return cachedWindowTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-Aug-05 Created
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
            /// Exposes access to the TODO translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TODO
            {
                get
                {
                    if ((cachedTODO == null))
                    {
                        cachedTODO = CoreManager.MomConsole.GetIntlStr(ResourceTODO);
                    }
                    return cachedTODO;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 28-Aug-05 Created
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
        /// 	[KellyMor] 28-Aug-05 Created
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
            /// Control ID for TODOStaticControl
            /// </summary>
            public const string TODOStaticControl = "todo";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "stripTop";

            /// <summary>
            /// Control ID for OkButton
            /// </summary>
            public const string OkButton = "okButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
        }
        #endregion
    }
}
