// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OpenNewWindowEventsViewDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-yoz] 12/25/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Events
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;
    
    #region Interface Definition - IOpenNewWindowEventsViewDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOpenNewWindowEventsViewDialogControls, for OpenNewWindowEventsViewDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-yoz] 12/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOpenNewWindowEventsViewDialogControls
    {
        /// <summary>
        /// Read-only property to access 1PropertyGridView
        /// </summary>
        DataGridView DataGridView1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access _1StaticControl
        /// </summary>
        StaticControl  StaticControl1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventsStaticControl
        /// </summary>
        StaticControl EventsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl0
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
        /// Read-only property to access 1Toolbar
        /// </summary>
        Toolbar Toolbar1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewToolbar
        /// </summary>
        Toolbar ViewToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Overrides
        /// </summary>
        Toolbar Overrides
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StatusBar1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StatusBar StatusBar1
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
    /// 	[v-yoz] 12/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class OpenNewWindowEventsViewDialog : Dialog, IOpenNewWindowEventsViewDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to 1PropertyGridView of type PropertyGridView
        /// </summary>
        private DataGridView cached1PropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to _1StaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_1StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EventsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to DetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDetailsStaticControl;
                
        /// <summary>
        /// Cache to hold a reference to 1Toolbar of type Toolbar
        /// </summary>
        private Toolbar cached1Toolbar;
        
        /// <summary>
        /// Cache to hold a reference to ViewToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedViewToolbar;
        
        /// <summary>
        /// Cache to hold a reference to Overrides of type Toolbar
        /// </summary>
        private Toolbar cachedOverrides;
        
        /// <summary>
        /// Cache to hold a reference to StatusBar1 of type StatusBar
        /// </summary>
        private StatusBar cachedStatusBar1;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OpenNewWindowEventsViewDialog of type AuthoringConsoleApp
        /// </param>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OpenNewWindowEventsViewDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IOpenNewWindowEventsViewDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOpenNewWindowEventsViewDialogControls Controls
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
        ///  Exposes access to the 1PropertyGridView control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DataGridView IOpenNewWindowEventsViewDialogControls.DataGridView1
        {
            get
            {
                if ((this.cached1PropertyGridView == null))
                {
                    this.cached1PropertyGridView = new DataGridView(this, OpenNewWindowEventsViewDialog.ControlIDs.DataGridView1);
                }
                
                return this.cached1PropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the _1StaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOpenNewWindowEventsViewDialogControls.StaticControl1
        {
            get
            {
                if ((this.cached_1StaticControl == null))
                {
                    this.cached_1StaticControl = new StaticControl(this, OpenNewWindowEventsViewDialog.ControlIDs.StaticControl1);
                }
                
                return this.cached_1StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOpenNewWindowEventsViewDialogControls.EventsStaticControl
        {
            get
            {
                if ((this.cachedEventsStaticControl == null))
                {
                    this.cachedEventsStaticControl = new StaticControl(this, OpenNewWindowEventsViewDialog.ControlIDs.EventsStaticControl);
                }
                
                return this.cachedEventsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOpenNewWindowEventsViewDialogControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, OpenNewWindowEventsViewDialog.ControlIDs.StaticControl0);
                }
                
                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOpenNewWindowEventsViewDialogControls.DetailsStaticControl
        {
            get
            {
                if ((this.cachedDetailsStaticControl == null))
                {
                    this.cachedDetailsStaticControl = new StaticControl(this, OpenNewWindowEventsViewDialog.ControlIDs.DetailsStaticControl);
                }
                
                return this.cachedDetailsStaticControl;
            }
        }               
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the 1Toolbar control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IOpenNewWindowEventsViewDialogControls.Toolbar1
        {
            get
            {
                if ((this.cached1Toolbar == null))
                {
                    this.cached1Toolbar = new Toolbar(this, OpenNewWindowEventsViewDialog.ControlIDs.Toolbar1);
                }
                
                return this.cached1Toolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewToolbar control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IOpenNewWindowEventsViewDialogControls.ViewToolbar
        {
            get
            {
                if ((this.cachedViewToolbar == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedViewToolbar = new Toolbar(wndTemp);
                }
                
                return this.cachedViewToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Overrides control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IOpenNewWindowEventsViewDialogControls.Overrides
        {
            get
            {
                if ((this.cachedOverrides == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedOverrides = new Toolbar(wndTemp);
                }
                
                return this.cachedOverrides;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusBar1 control
        /// </summary>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IOpenNewWindowEventsViewDialogControls.StatusBar1
        {
            get
            {
                if ((this.cachedStatusBar1 == null))
                {
                    this.cachedStatusBar1 = new StatusBar(this, OpenNewWindowEventsViewDialog.ControlIDs.StatusBar1);
                }
                
                return this.cachedStatusBar1;
            }
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.EventsDialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                        tempWindow = new Window(Strings.EventsDialogTitle, StringMatchSyntax.WildCard);

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
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Events
            /// </summary>
            public const string ResourceEventsDialogTitle =
                ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";

            #endregion

            #region Member Variables

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedEventsDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventsDialogTitle;

            #endregion

            #region Properties            

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event view "EventsDialogTitle" String
            /// </summary>
            /// <history>
            /// 	[v-yoz] 07April09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventsDialogTitle
            {
                get
                {
                    if ((cachedEventsDialogTitle == null))
                    {
                        cachedEventsDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceEventsDialogTitle);
                    }

                    return cachedEventsDialogTitle;
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
        /// 	[v-yoz] 12/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for 1PropertyGridView
            /// </summary>
            public const string DataGridView1 = "momGrid";
            
            /// <summary>
            /// Control ID for _1StaticControl
            /// </summary>
            public const string  StaticControl1 = "ViewSubtitle";
            
            /// <summary>
            /// Control ID for EventsStaticControl
            /// </summary>
            public const string EventsStaticControl = "ViewTitle";
            
            /// <summary>
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl0 = "rightLabel";
            
            /// <summary>
            /// Control ID for DetailsStaticControl
            /// </summary>
            public const string DetailsStaticControl = "DetailViewTitle";
            
            /// <summary>
            /// Control ID for 1Toolbar
            /// </summary>
            public const string Toolbar1 = "header";
            
            /// <summary>
            /// Control ID for StatusBar1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StatusBar1 = "consoleStatusBar";
        }
        #endregion
    }
}
