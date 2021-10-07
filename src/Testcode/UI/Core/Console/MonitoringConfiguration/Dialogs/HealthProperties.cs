// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="HealthProperties.cs">
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
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IHealthPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IHealthPropertiesControls, for HealthProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 01-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHealthPropertiesControls
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
        /// Read-only property to access DataGridView1
        /// </summary>
        PropertyGridView DataGridView1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl
        /// </summary>
        StaticControl SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl
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
    /// Class to encapsulate the "Health" TAB of the Windows Service Monitor Properties.
    /// This class manages the advanced functions for the "Health" Tab Properties
    /// </summary>
    /// <history>
    /// 	[ruhim] 01-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class HealthProperties : Dialog, IHealthPropertiesControls
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
        /// Cache to hold a reference to DataGridView1 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataGridView1;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl;
        
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
        /// Owner of HealthProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public HealthProperties(Maui.Core.App app)
            : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IHealthProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IHealthPropertiesControls Controls
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
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IHealthPropertiesControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, HealthProperties.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IHealthPropertiesControls.DataGridView1
        {
            get
            {
                if ((this.cachedDataGridView1 == null))
                {
                    this.cachedDataGridView1 = new PropertyGridView(this, HealthProperties.ControlIDs.DataGridView1);
                }
                return this.cachedDataGridView1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthPropertiesControls.SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl
        {
            get
            {
                if ((this.cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl == null))
                {
                    this.cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl = new StaticControl(this, HealthProperties.ControlIDs.SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl);
                }
                return this.cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl;
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
        Toolbar IHealthPropertiesControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, HealthProperties.ControlIDs.ToolStrip1);
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
        /// 	[ruhim] 01-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.            
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 10;
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
                "Monitor Properties -";
            
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
            /// Contains resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGridView1 = ";dataGridView1;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Internal.UI.Authoring.Pages.OperationalStatesMappingP" +
                "age;statesGridView.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect = @";Specify what health state should be generated for each of the conditions that this monitor will detect.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.CreateMonitorWizard.OperationalStatesMappingPage;label1.Text";
            
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
            /// Caches the translated resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataGridView1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect;
            
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
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
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataGridView1
            {
                get
                {
                    if ((cachedDataGridView1 == null))
                    {
                        cachedDataGridView1 = CoreManager.MomConsole.GetIntlStr(ResourceDataGridView1);
                    }
                    return cachedDataGridView1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect
            {
                get
                {
                    if ((cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect == null))
                    {
                        cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect);
                    }
                    return cachedSpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetect;
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for DataGridView1
            /// </summary>
            public const string DataGridView1 = "statesGridView";
            
            /// <summary>
            /// Control ID for SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl
            /// </summary>
            public const string SpecifyWhatHealthStateShouldBeGeneratedForEachOfTheConditionsThatThisMonitorWillDetectStaticControl = "label1";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "stripTop";
        }
        #endregion
    }
}
