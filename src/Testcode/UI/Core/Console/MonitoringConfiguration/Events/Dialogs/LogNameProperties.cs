// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="LogNameProperties.cs">
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
    
    #region Interface Definition - ILogNamePropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ILogNamePropertiesControls, for LogNameProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 09-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ILogNamePropertiesControls
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
        /// Read-only property to access NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo
        /// </summary>
        StaticControl NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LogNameStaticControl
        /// </summary>
        StaticControl LogNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LogNameTextBox
        /// </summary>
        TextBox LogNameTextBox
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
        /// Read-only property to access SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta
        /// </summary>
        StaticControl SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta
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
    /// Class to encapsulate methods for the Log Name tab for under event monitor properties.
    /// </summary>
    /// <history>
    /// 	[ruhim] 09-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class LogNameProperties : Dialog, ILogNamePropertiesControls
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
        /// Cache to hold a reference to NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo of type StaticControl
        /// </summary>
        private StaticControl cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo;
        
        /// <summary>
        /// Cache to hold a reference to LogNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLogNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LogNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedLogNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta;
        
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
        /// Owner of LogNameProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public LogNameProperties(Mom.Test.UI.Core.Console.MomConsoleApp app)
            : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion
        
        #region ILogNameProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ILogNamePropertiesControls Controls
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
        ///  Routine to set/get the text in control LogName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string LogNameText
        {
            get
            {
                return this.Controls.LogNameTextBox.Text;
            }
            
            set
            {
                this.Controls.LogNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab0TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ILogNamePropertiesControls.Tab0TabControl
        {
            get
            {
                if ((this.cachedTab0TabControl == null))
                {
                    this.cachedTab0TabControl = new TabControl(this, LogNameProperties.ControlIDs.Tab0TabControl);
                }
                return this.cachedTab0TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNamePropertiesControls.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo
        {
            get
            {
                if ((this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo == null))
                {
                    this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo = new StaticControl(this, LogNameProperties.ControlIDs.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo);
                }
                return this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LogNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNamePropertiesControls.LogNameStaticControl
        {
            get
            {
                if ((this.cachedLogNameStaticControl == null))
                {
                    this.cachedLogNameStaticControl = new StaticControl(this, LogNameProperties.ControlIDs.LogNameStaticControl);
                }
                return this.cachedLogNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LogNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ILogNamePropertiesControls.LogNameTextBox
        {
            get
            {
                if ((this.cachedLogNameTextBox == null))
                {
                    this.cachedLogNameTextBox = new TextBox(this, LogNameProperties.ControlIDs.LogNameTextBox);
                }
                return this.cachedLogNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ILogNamePropertiesControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, LogNameProperties.ControlIDs.Button0);
                }
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta control
        /// </summary>
        /// <history>
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ILogNamePropertiesControls.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta
        {
            get
            {
                if ((this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta == null))
                {
                    this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta = new StaticControl(this, LogNameProperties.ControlIDs.SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta);
                }
                return this.cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta;
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
        Toolbar ILogNamePropertiesControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, LogNameProperties.ControlIDs.ToolStrip1);
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
        /// 	[ruhim] 09-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
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
            /// Contains resource string for:  Tab0
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab0 = "Tab0";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead = ";Note: The event log must exist in the the computer where the target managed enti" +
                "ty is hosted for events to be read.;ManagedString;Microsoft.MOM.UI.Components.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;noteLa" +
                "bel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LogName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLogName = ";Log name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.EvtLogDataSource;logNameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs = @";Specify an event log name to read events from. You can browse to a computer to view and select from available event logs. ;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;infoLabel.Text";
            
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
            /// Caches the translated resource string for:  NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LogName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLogName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs;
            
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
            /// Exposes access to the Tab0 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 09-Sep-05 Created
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
            /// Exposes access to the NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 09-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead
            {
                get
                {
                    if ((cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead == null))
                    {
                        cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead = CoreManager.MomConsole.GetIntlStr(ResourceNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead);
                    }
                    return cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeRead;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LogName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 09-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LogName
            {
                get
                {
                    if ((cachedLogName == null))
                    {
                        cachedLogName = CoreManager.MomConsole.GetIntlStr(ResourceLogName);
                    }
                    return cachedLogName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 09-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs
            {
                get
                {
                    if ((cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs == null))
                    {
                        cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs);
                    }
                    return cachedSpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogs;
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
            /// Control ID for Tab0TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab0TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo
            /// </summary>
            public const string NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadStaticCo = "noteLabel";
            
            /// <summary>
            /// Control ID for LogNameStaticControl
            /// </summary>
            public const string LogNameStaticControl = "logNameLabel";
            
            /// <summary>
            /// Control ID for LogNameTextBox
            /// </summary>
            public const string LogNameTextBox = "logNameTextBox";
            
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "browseButton";
            
            /// <summary>
            /// Control ID for SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta
            /// </summary>
            public const string SpecifyAnEventLogNameToReadEventsFromYouCanBrowseToAComputerToViewAndSelectFromAvailableEventLogsSta = "infoLabel";
            
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "stripTop";
        }
        #endregion
    }
}
