// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectWindowsServiceDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 22-Aug-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - ISelectWindowsServiceDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectWindowsServiceDialogControls, for SelectWindowsServiceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 22-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectWindowsServiceDialogControls
    {
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
        /// Read-only property to access NoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl
        /// </summary>
        StaticControl NoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAServiceBelowStaticControl
        /// </summary>
        StaticControl SelectAServiceBelowStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceNameListView
        /// </summary>
        ListView ServiceNameListView
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
        /// Read-only property to access ServiceNameTextBox
        /// </summary>
        TextBox ServiceNameTextBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Select Windows Service" window 
    /// for the Service Name dialog in the Create Monitor Wizard.
    /// </summary>
    /// <history>
    /// 	[ruhim] 22-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectWindowsServiceDialog : Window, ISelectWindowsServiceDialogControls
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
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to NoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to SelectAServiceBelowStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectAServiceBelowStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceNameListView of type ListView
        /// </summary>
        private ListView cachedServiceNameListView;
        
        /// <summary>
        /// Cache to hold a reference to ComputerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceNameTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>        
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectWindowsServiceDialog() : 
                base(Init())
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region ISelectWindowsServiceDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectWindowsServiceDialogControls Controls
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
        /// 	[ruhim] 22-Aug-05 Created
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
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectWindowsServiceDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectWindowsServiceDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectWindowsServiceDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectWindowsServiceDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectWindowsServiceDialogControls.NoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl
        {
            get
            {
                if ((this.cachedNoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl == null))
                {
                    this.cachedNoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl = new StaticControl(this, SelectWindowsServiceDialog.ControlIDs.NoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl);
                }
                return this.cachedNoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectWindowsServiceDialogControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, SelectWindowsServiceDialog.ControlIDs.Button1);
                }
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAServiceBelowStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectWindowsServiceDialogControls.SelectAServiceBelowStaticControl
        {
            get
            {
                if ((this.cachedSelectAServiceBelowStaticControl == null))
                {
                    this.cachedSelectAServiceBelowStaticControl = new StaticControl(this, SelectWindowsServiceDialog.ControlIDs.SelectAServiceBelowStaticControl);
                }
                return this.cachedSelectAServiceBelowStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ISelectWindowsServiceDialogControls.ServiceNameListView
        {
            get
            {
                if ((this.cachedServiceNameListView == null))
                {
                    this.cachedServiceNameListView = new ListView(this, new QID(";[UIA]AutomationId ='" + SelectWindowsServiceDialog.ControlIDs.ServiceNameListView + "'"));
                }
                return this.cachedServiceNameListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectWindowsServiceDialogControls.ComputerStaticControl
        {
            get
            {
                if ((this.cachedComputerStaticControl == null))
                {
                    this.cachedComputerStaticControl = new StaticControl(this, SelectWindowsServiceDialog.ControlIDs.ComputerStaticControl);
                }
                return this.cachedComputerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceNameTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectWindowsServiceDialogControls.ServiceNameTextBox
        {
            get
            {
                if ((this.cachedServiceNameTextBox == null))
                {
                    this.cachedServiceNameTextBox = new TextBox(this, SelectWindowsServiceDialog.ControlIDs.ServiceNameTextBox);
                }
                return this.cachedServiceNameTextBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
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
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>        
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
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
                const int MAXTRIES = 10;
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
        /// 	[ruhim] 22-Aug-05 Created
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
            private const string ResourceWindowTitle = //"Select Windows Service";
                ";Select Windows Service;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServiceBrowserForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bU;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteTheActualNameWillBeStoredInTheMOMDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteTheActualNameWillBeStoredInTheMOMDatabase = ";Note: The actual name will be stored in the MOM database.;ManagedString;Microsof" +
                "t.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.S" +
                "erviceBrowserForm;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAServiceBelow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAServiceBelow = ";S&elect a service below:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.ServiceBrowserForm;chooseLabel.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Computer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputer = ";Co&mputer:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.EventLogSelectorForm;computerLabel.Text";
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
            /// Caches the translated resource string for:  NoteTheActualNameWillBeStoredInTheMOMDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteTheActualNameWillBeStoredInTheMOMDatabase;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAServiceBelow
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAServiceBelow;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Computer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputer;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Aug-05 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Aug-05 Created
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
            /// 	[ruhim] 22-Aug-05 Created
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
            /// Exposes access to the NoteTheActualNameWillBeStoredInTheMOMDatabase translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteTheActualNameWillBeStoredInTheMOMDatabase
            {
                get
                {
                    if ((cachedNoteTheActualNameWillBeStoredInTheMOMDatabase == null))
                    {
                        cachedNoteTheActualNameWillBeStoredInTheMOMDatabase = CoreManager.MomConsole.GetIntlStr(ResourceNoteTheActualNameWillBeStoredInTheMOMDatabase);
                    }
                    return cachedNoteTheActualNameWillBeStoredInTheMOMDatabase;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAServiceBelow translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectAServiceBelow
            {
                get
                {
                    if ((cachedSelectAServiceBelow == null))
                    {
                        cachedSelectAServiceBelow = CoreManager.MomConsole.GetIntlStr(ResourceSelectAServiceBelow);
                    }
                    return cachedSelectAServiceBelow;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Computer translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22-Aug-05 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[ruhim] 22-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for NoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl
            /// </summary>
            public const string NoteTheActualNameWillBeStoredInTheMOMDatabaseStaticControl = "label1";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "browseButton";
            
            /// <summary>
            /// Control ID for SelectAServiceBelowStaticControl
            /// </summary>
            public const string SelectAServiceBelowStaticControl = "chooseLabel";
            
            /// <summary>
            /// Control ID for ServiceNameListView
            /// </summary>
            public const string ServiceNameListView = "serviceListView";
            
            /// <summary>
            /// Control ID for ComputerStaticControl
            /// </summary>
            public const string ComputerStaticControl = "computerLabel";
            
            /// <summary>
            /// Control ID for ServiceNameTextBox
            /// </summary>
            public const string ServiceNameTextBox = "computerNameTextBox";
        }
        #endregion
    }
}
