// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="BuildExpressionProperties.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 09-Sep-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IBuildExpressionPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IBuildExpressionPropertiesControls, for BuildExpressionProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 09-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IBuildExpressionPropertiesControls
    {
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
        /// Read-only property to access BuildTheExpressionToMatchOneOrMoreEventsStaticControl
        /// </summary>
        StaticControl BuildTheExpressionToMatchOneOrMoreEventsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FormulaGrid1
        /// </summary>
        PropertyGridView FormulaGrid1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionToolbar
        /// </summary>
        Toolbar DescriptionToolbar
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
    /// Class to encapsulate the Expression query builder, under Expression tab for properties.
    /// This class manages the advanced functions for build expression queries.
    /// </summary>
    /// <history>
    /// 	[ruhim] 09-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class BuildExpressionProperties : Dialog, IBuildExpressionPropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
        /// <summary>
        /// Cache to hold a reference to BuildTheExpressionToMatchOneOrMoreEventsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBuildTheExpressionToMatchOneOrMoreEventsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FormulaGrid1 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedFormulaGrid1;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedDescriptionToolbar;
        
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
        /// <param name='app'>
        /// Owner of BuildExpressionProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public BuildExpressionProperties(Mom.Test.UI.Core.Console.MomConsoleApp app)
            : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region IBuildExpressionProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IBuildExpressionPropertiesControls Controls
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
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IBuildExpressionPropertiesControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, BuildExpressionProperties.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BuildTheExpressionToMatchOneOrMoreEventsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBuildExpressionPropertiesControls.BuildTheExpressionToMatchOneOrMoreEventsStaticControl
        {
            get
            {
                if ((this.cachedBuildTheExpressionToMatchOneOrMoreEventsStaticControl == null))
                {
                    this.cachedBuildTheExpressionToMatchOneOrMoreEventsStaticControl = new StaticControl(this, BuildExpressionProperties.ControlIDs.BuildTheExpressionToMatchOneOrMoreEventsStaticControl);
                }
                return this.cachedBuildTheExpressionToMatchOneOrMoreEventsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormulaGrid1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IBuildExpressionPropertiesControls.FormulaGrid1
        {
            get
            {
                if ((this.cachedFormulaGrid1 == null))
                {
                    this.cachedFormulaGrid1 = new PropertyGridView(this, BuildExpressionProperties.ControlIDs.FormulaGrid1);
                }
                return this.cachedFormulaGrid1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionToolbar control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IBuildExpressionPropertiesControls.DescriptionToolbar
        {
            get
            {
                if ((this.cachedDescriptionToolbar == null))
                {
                    this.cachedDescriptionToolbar = new Toolbar(this, BuildExpressionProperties.ControlIDs.DescriptionToolbar);
                }
                return this.cachedDescriptionToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IBuildExpressionPropertiesControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, BuildExpressionProperties.ControlIDs.ToolStrip1);
                }
                return this.cachedToolStrip1;
            }
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }

            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 5;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
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
                        Core.Common.Utilities.LogMessage("Attempt "
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
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
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
        /// 	[ruhim] 09-Sep-05 Created
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
            private const string ResourceDialogTitle = "Monitor Properties -";
            
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
            /// Contains resource string for:  BuildTheExpressionToMatchOneOrMoreEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBuildTheExpressionToMatchOneOrMoreEvents = ";B&uild the expression to match one or more events:;ManagedString;Microsoft.MOM.U" +
                "I.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Expressi" +
                "onEvaluatorCondition;expressionPageLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FormulaGrid1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaGrid1 = ";formulaGrid1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaBuilderControl;formulaGrid." +
                "Text";
            
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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BuildTheExpressionToMatchOneOrMoreEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBuildTheExpressionToMatchOneOrMoreEvents;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FormulaGrid1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFormulaGrid1;
            
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
            /// 	[ruhim] 09-Sep-05 Created
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 09-Sep-05 Created
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
            /// Exposes access to the BuildTheExpressionToMatchOneOrMoreEvents translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 09-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BuildTheExpressionToMatchOneOrMoreEvents
            {
                get
                {
                    if ((cachedBuildTheExpressionToMatchOneOrMoreEvents == null))
                    {
                        cachedBuildTheExpressionToMatchOneOrMoreEvents = CoreManager.MomConsole.GetIntlStr(ResourceBuildTheExpressionToMatchOneOrMoreEvents);
                    }
                    return cachedBuildTheExpressionToMatchOneOrMoreEvents;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FormulaGrid1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 09-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaGrid1
            {
                get
                {
                    if ((cachedFormulaGrid1 == null))
                    {
                        cachedFormulaGrid1 = CoreManager.MomConsole.GetIntlStr(ResourceFormulaGrid1);
                    }
                    return cachedFormulaGrid1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 09-Sep-05 Created
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
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for BuildTheExpressionToMatchOneOrMoreEventsStaticControl
            /// </summary>
            public const string BuildTheExpressionToMatchOneOrMoreEventsStaticControl = "expressionPageLabel";
            
            /// <summary>
            /// Control ID for FormulaGrid1
            /// </summary>
            public const string FormulaGrid1 = "formulaGrid";
            
            /// <summary>
            /// Control ID for DescriptionToolbar
            /// </summary>
            public const string DescriptionToolbar = "formulaMenu";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "stripTop";
        }
        #endregion
    }
}
