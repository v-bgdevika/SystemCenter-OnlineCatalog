// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectEventLogDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 19-Aug-05 Created
//  [ruhim] 29May08 Increasing the number of retries for init method to fix timing issue
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
    
    #region Interface Definition - ISelectEventLogDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectEventLogDialogControls, for SelectEventLogDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 19-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectEventLogDialogControls
    {
        /// <summary>
        /// Read-only property to access NoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl
        /// </summary>
        StaticControl NoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView
        /// </summary>
        ListView EventLogNameListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectEventLogToUseStaticControl
        /// </summary>
        StaticControl SelectEventLogToUseStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComputerStaticControl
        /// </summary>
        StaticControl ComputerStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button2
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Select Event Log" dialog of the Create Monitor Wizard.
    /// This class manages the advanced functions for the "Select Event Log" dialog
    /// </summary>
    /// <history>
    /// 	[ruhim] 19-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectEventLogDialog : Window, ISelectEventLogDialogControls
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
        /// Cache to hold a reference to NoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView of type ListView
        /// </summary>
        private ListView cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView;
        
        /// <summary>
        /// Cache to hold a reference to SelectEventLogToUseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectEventLogToUseStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComputerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button2 of type Button
        /// </summary>
        private Button cachedButton2;
        
        /// <summary>
        /// Cache to hold a reference to LogNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedLogNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>        
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectEventLogDialog() : 
                base(Init())
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region ISelectEventLogDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectEventLogDialogControls Controls
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
        /// 	[ruhim] 19-Aug-05 Created
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
        ///  Exposes access to the NoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectEventLogDialogControls.NoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl
        {
            get
            {
                if ((this.cachedNoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl == null))
                {
                    this.cachedNoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl = new StaticControl(this, SelectEventLogDialog.ControlIDs.NoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl);
                }
                return this.cachedNoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectEventLogDialogControls.EventLogNameListView
        {
            get
            {
                if ((this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView == null))
                {
                    this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView = new ListView(this, SelectEventLogDialog.ControlIDs.NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView);
                }
                return this.cachedNoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectEventLogToUseStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectEventLogDialogControls.SelectEventLogToUseStaticControl
        {
            get
            {
                if ((this.cachedSelectEventLogToUseStaticControl == null))
                {
                    this.cachedSelectEventLogToUseStaticControl = new StaticControl(this, SelectEventLogDialog.ControlIDs.SelectEventLogToUseStaticControl);
                }
                return this.cachedSelectEventLogToUseStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectEventLogDialogControls.ComputerStaticControl
        {
            get
            {
                if ((this.cachedComputerStaticControl == null))
                {
                    this.cachedComputerStaticControl = new StaticControl(this, SelectEventLogDialog.ControlIDs.ComputerStaticControl);
                }
                return this.cachedComputerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectEventLogDialogControls.Button2
        {
            get
            {
                if ((this.cachedButton2 == null))
                {
                    this.cachedButton2 = new Button(this, SelectEventLogDialog.ControlIDs.Button2);
                }
                return this.cachedButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LogNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectEventLogDialogControls.LogNameTextBox
        {
            get
            {
                if ((this.cachedLogNameTextBox == null))
                {
                    this.cachedLogNameTextBox = new TextBox(this, SelectEventLogDialog.ControlIDs.LogNameTextBox);
                }
                return this.cachedLogNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectEventLogDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectEventLogDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectEventLogDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectEventLogDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button2
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton2()
        {
            this.Controls.Button2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>       
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init()
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.WindowTitle
                    + "*",
                    StringMatchSyntax.WildCard);
                // These additional parameters were generated by DialogMaker
                // , however; they are not necessary and often cause the
                // window constructor to fail.
                // , WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, ownerWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the wizard dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 20;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.WindowTitle + "'");
                //app.LogMessage("Looking for window with title:  '"
                //    + Strings.WindowTitle + "'");
                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;

                    try
                    {
                        // look for the window again using wildcard matching
                        tempWindow = new Window(
                            Strings.WindowTitle + "*",
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
                        //app.LogMessage("Attempt "
                        //    + numberOfTries
                        //    + " of "
                        //    + MAXTRIES
                        //    + "...");
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.WindowTitle
                        + "'.\n\n" + ex.Message);
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
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
                ";Select event log;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventLogSelectorForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteActualLogNameWillBeStoredInTheMOMDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteActualLogNameWillBeStoredInTheMOMDatabase = ";Note: Actual log name will be stored in the MOM database;ManagedString;Microsoft" +
                ".MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Ev" +
                "entLogSelectorForm;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectEventLogToUse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectEventLogToUse = ";&Select event log to use:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.EventLogSelectorForm;selectLogLab" +
                "el.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Computer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputer = ";Co&mputer:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.EventLogSelectorForm;computerLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bU;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
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
            /// Caches the translated resource string for:  NoteActualLogNameWillBeStoredInTheMOMDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteActualLogNameWillBeStoredInTheMOMDatabase;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectEventLogToUse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectEventLogToUse;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Computer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19-Aug-05 Created
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
            /// Exposes access to the NoteActualLogNameWillBeStoredInTheMOMDatabase translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteActualLogNameWillBeStoredInTheMOMDatabase
            {
                get
                {
                    if ((cachedNoteActualLogNameWillBeStoredInTheMOMDatabase == null))
                    {
                        cachedNoteActualLogNameWillBeStoredInTheMOMDatabase = CoreManager.MomConsole.GetIntlStr(ResourceNoteActualLogNameWillBeStoredInTheMOMDatabase);
                    }
                    return cachedNoteActualLogNameWillBeStoredInTheMOMDatabase;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectEventLogToUse translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectEventLogToUse
            {
                get
                {
                    if ((cachedSelectEventLogToUse == null))
                    {
                        cachedSelectEventLogToUse = CoreManager.MomConsole.GetIntlStr(ResourceSelectEventLogToUse);
                    }
                    return cachedSelectEventLogToUse;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Computer translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Computer
            {
                get
                {
                    if ((cachedComputer == null))
                    {
                        cachedComputer = CoreManager.MomConsole.GetIntlStr(ResourceComputer);
                    }
                    return cachedComputer;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19-Aug-05 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19-Aug-05 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 19-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for NoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl
            /// </summary>
            public const string NoteActualLogNameWillBeStoredInTheMOMDatabaseStaticControl = "label2";
            
            /// <summary>
            /// Control ID for NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView
            /// </summary>
            public const string NoteTheEventLogMustExistInTheTheComputerWhereTheTargetManagedEntityIsHostedForEventsToBeReadListView = "logListView";
            
            /// <summary>
            /// Control ID for SelectEventLogToUseStaticControl
            /// </summary>
            public const string SelectEventLogToUseStaticControl = "selectLogLabel";
            
            /// <summary>
            /// Control ID for ComputerStaticControl
            /// </summary>
            public const string ComputerStaticControl = "computerLabel";
            
            /// <summary>
            /// Control ID for Button2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button2 = "browseButton";
            
            /// <summary>
            /// Control ID for LogNameTextBox
            /// </summary>
            public const string LogNameTextBox = "computerNameTextbox";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
        }
        #endregion
    }
}
