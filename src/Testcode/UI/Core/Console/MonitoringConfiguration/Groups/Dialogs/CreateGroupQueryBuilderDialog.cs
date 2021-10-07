// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateGroupQueryBuilderDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[HainingW] 3/22/2006 Created
// 	[HainingW] 3/24/2006 Fixed Resource string and add a second constructor which takes title string
// 	[HainingW] 4/07/2006 Renamed some control variables
//  [KellyMor] 12-Jun-08 Fixed missing delay bug in retry loop catch block 
//                       in Init method
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Groups.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - ICreateGroupQueryBuilderDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateGroupQueryBuilderDialogControls, for CreateGroupQueryBuilderDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[HainingW] 3/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateGroupQueryBuilderDialogControls
    {
        /// <summary>
        /// Read-only property to access DesiredClassStaticControl
        /// </summary>
        StaticControl DesiredClassStaticControl
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
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FormulaGrid
        /// </summary>
        PropertyGridView FormulaGrid
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Toolbar
        /// </summary>
        Toolbar FormulaGridToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddButton
        /// </summary>
        Button AddButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DesiredClassComboBox
        /// </summary>
        ComboBox DesiredClassComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PropertyListView
        /// </summary>
        ListView PropertyListView
        {
            get;
        }
    }

    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Query Builder" dialog invoked by the Create Group Wizard.
    /// </summary>
    /// <history>
    /// 	[HainingW] 3/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateGroupQueryBuilderDialog : Dialog, ICreateGroupQueryBuilderDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to DesiredClassStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDesiredClassStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to FormulaGrid of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedFormulaGrid;
        
        /// <summary>
        /// Cache to hold a reference to FormulaGridToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedFormulaGridToolbar;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to DesiredClassComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDesiredClassComboBox;

        /// <summary>
        /// Cache to hold a reference to PropertyListView of type ListView
        /// </summary>
        private ListView cachedPropertyListView;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with no dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateGroupQueryBuilderDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateGroupQueryBuilderDialog(MomConsoleApp app) 
            : base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateGroupQueryBuilderDialog of type MomConsoleApp
        /// </param>
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateGroupQueryBuilderDialog(MomConsoleApp app, string title)
            : base(app, Init(app, title))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        #endregion
        
        #region ICreateGroupQueryBuilderDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateGroupQueryBuilderDialogControls Controls
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
        ///  Routine to set/get the text in control DesiredClass
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DesiredClassText
        {
            get
            {
                return this.Controls.DesiredClassComboBox.Text;
            }
            
            set
            {
                this.Controls.DesiredClassComboBox.SelectByText(value, true);
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DesiredClassStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateGroupQueryBuilderDialogControls.DesiredClassStaticControl
        {
            get
            {
                if ((this.cachedDesiredClassStaticControl == null))
                {
                    this.cachedDesiredClassStaticControl = new StaticControl(this, CreateGroupQueryBuilderDialog.ControlIDs.DesiredClassStaticControl);
                }
                return this.cachedDesiredClassStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateGroupQueryBuilderDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateGroupQueryBuilderDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateGroupQueryBuilderDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, CreateGroupQueryBuilderDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormulaGrid control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView ICreateGroupQueryBuilderDialogControls.FormulaGrid
        {
            get
            {
                if ((this.cachedFormulaGrid == null))
                {
                    this.cachedFormulaGrid = new PropertyGridView(this, CreateGroupQueryBuilderDialog.ControlIDs.FormulaGrid);
                }
                return this.cachedFormulaGrid;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FormulaGridToolbar control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ICreateGroupQueryBuilderDialogControls.FormulaGridToolbar
        {
            get
            {
                if ((this.cachedFormulaGridToolbar == null))
                {
                    this.cachedFormulaGridToolbar = new Toolbar(this);
                }
                return this.cachedFormulaGridToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateGroupQueryBuilderDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, CreateGroupQueryBuilderDialog.ControlIDs.AddButton);
                }
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DesiredClassComboBox control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateGroupQueryBuilderDialogControls.DesiredClassComboBox
        {
            get
            {
                if ((this.cachedDesiredClassComboBox == null))
                {
                    this.cachedDesiredClassComboBox = new ComboBox(this, CreateGroupQueryBuilderDialog.ControlIDs.DesiredClassComboBox);
                }
                return this.cachedDesiredClassComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertyListView control
        /// </summary>
        /// <history>
        ///   [v-cheli] 12/15/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ICreateGroupQueryBuilderDialogControls.PropertyListView
        {
            get
            {
                if ((this.cachedPropertyListView == null))
                {
                    this.cachedPropertyListView = new ListView(this, new QID(";[UIA]AutomationId ='" + CreateGroupQueryBuilderDialog.ControlIDs.PropertyListView + "'"));
                }

                return this.cachedPropertyListView;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
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
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }

        #endregion
 
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[HainingW] 3/24/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            Utilities.LogMessage("CreateGroupQueryBuilderDialog :: Init(app)");
            Window tempWindow = Init(app, Strings.DialogTitle);
            return tempWindow;
        }
       
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, string title)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            Utilities.LogMessage("CreateGroupQueryBuilderDialog :: Init(app, title)");

            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(title,
                                        StringMatchSyntax.ExactMatch,
                                        WindowClassNames.Dialog,
                                        StringMatchSyntax.ExactMatch,
                                        app.MainWindow,
                                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
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
                        tempWindow = new Window(title + "*", StringMatchSyntax.WildCard);
                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // Check for success
                if (tempWindow == null)
                {
                    // Log the failure
                    Utilities.LogMessage("Failed to find window with title:  '" + title + "'");
                    // Throw the existing WindowNotFound exception
                    throw;
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
        /// 	[HainingW] 3/22/2006 Created
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
            private const string ResourceDialogTitle =  ";Create Group Wizard - Query Builder;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.FormulaDialog;$this.Text";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DesiredClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDesiredClass = 
                ";Select the desired Class and click the Add button to begin building the formula:" +
                ";ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement." +
                "Internal.UI.Authoring.Pages.FormulaDialog;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FormulaGrid
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFormulaGrid = ";formulaGrid1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.Controls.FormulaBuilder.FormulaBuilderControl;formulaGrid." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";Add;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement" +
                ".Internal.UI.Authoring.Pages.FormulaDialog;addButton.Text";
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
            /// Caches the translated resource string for:  DesiredClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDesiredClass;
            
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
            /// Caches the translated resource string for:  FormulaGrid
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFormulaGrid;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/22/2006 Created
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
            /// Exposes access to the DesiredClass translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DesiredClass
            {
                get
                {
                    if ((cachedDesiredClass == null))
                    {
                        cachedDesiredClass = CoreManager.MomConsole.GetIntlStr(ResourceDesiredClass);
                    }
                    return cachedDesiredClass;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/22/2006 Created
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
            /// 	[HainingW] 3/22/2006 Created
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
            /// Exposes access to the FormulaGrid translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FormulaGrid
            {
                get
                {
                    if ((cachedFormulaGrid == null))
                    {
                        cachedFormulaGrid = CoreManager.MomConsole.GetIntlStr(ResourceFormulaGrid);
                    }
                    return cachedFormulaGrid;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Add
            {
                get
                {
                    if ((cachedAdd == null))
                    {
                        cachedAdd = CoreManager.MomConsole.GetIntlStr(ResourceAdd);
                    }
                    return cachedAdd;
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
        /// 	[HainingW] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for DesiredClassStaticControl
            /// </summary>
            public const string DesiredClassStaticControl = "label1";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for FormulaGrid
            /// </summary>
            public const string FormulaGrid = "formulaGrid";
            
            /// <summary>
            /// Control ID for Toolbar
            /// </summary>
            public const string FormulaGridToolbar = "formulaMenu";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for DesiredClassComboBox
            /// </summary>
            public const string DesiredClassComboBox = "classesDropDown";

            /// <summary>
            /// Control ID for PropertyListView
            /// </summary>
            public const string PropertyListView = "ListBox";
        }
        #endregion
    }
}
