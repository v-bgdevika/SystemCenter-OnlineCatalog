// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SelectPerformanceCounterDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Select Performance Counter
// </summary>
// <history>
// 	[mbickle] 14APR06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    #endregion

    #region Interface Definition - ISelectPerformanceCounterDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISelectPerformanceCounterDialogControls, for SelectPerformanceCounterDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 14APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISelectPerformanceCounterDialogControls
    {
        /// <summary>
        /// Read-only property to access PerformanceCounterStaticControl
        /// </summary>
        StaticControl PerformanceCounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseOrEnterComputerNameStaticControl
        /// </summary>
        StaticControl BrowseOrEnterComputerNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectInstanceFromListStaticControl
        /// </summary>
        StaticControl SelectInstanceFromListStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllInstancesCheckBox
        /// </summary>
        CheckBox AllInstancesCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectInstanceFromListListBox
        /// </summary>
        ListBox SelectInstanceFromListListBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExplainButton
        /// </summary>
        Button ExplainButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectComboBox
        /// </summary>
        ComboBox ObjectComboBox
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
        /// Read-only property to access BrowseOrEnterComputerNameTextBox
        /// </summary>
        TextBox BrowseOrEnterComputerNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectCounterFromListListBox
        /// </summary>
        ListBox SelectCounterFromListListBox
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
        
        /// <summary>
        /// Read-only property to access SelectCounterFromListStaticControl
        /// </summary>
        StaticControl SelectCounterFromListStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ObjectStaticControl
        /// </summary>
        StaticControl ObjectStaticControl
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
    /// 	[mbickle] 14APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SelectPerformanceCounterDialog : Dialog, ISelectPerformanceCounterDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PerformanceCounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BrowseOrEnterComputerNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBrowseOrEnterComputerNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectInstanceFromListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectInstanceFromListStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AllInstancesCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedAllInstancesCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectInstanceFromListListBox of type ListBox
        /// </summary>
        private ListBox cachedSelectInstanceFromListListBox;
        
        /// <summary>
        /// Cache to hold a reference to ExplainButton of type Button
        /// </summary>
        private Button cachedExplainButton;
        
        /// <summary>
        /// Cache to hold a reference to ObjectComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedObjectComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ComputerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to BrowseOrEnterComputerNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedBrowseOrEnterComputerNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectCounterFromListListBox of type ListBox
        /// </summary>
        private ListBox cachedSelectCounterFromListListBox;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectCounterFromListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectCounterFromListStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ObjectStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedObjectStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SelectPerformanceCounterDialog of type App
        /// </param>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SelectPerformanceCounterDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISelectPerformanceCounterDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISelectPerformanceCounterDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox AllInstances
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool AllInstances
        {
            get
            {
                return this.Controls.AllInstancesCheckBox.Checked;
            }
            
            set
            {
                this.Controls.AllInstancesCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Object
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ObjectText
        {
            get
            {
                return this.Controls.ObjectComboBox.Text;
            }
            
            set
            {
                this.Controls.ObjectComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control BrowseOrEnterComputerName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string BrowseOrEnterComputerNameText
        {
            get
            {
                return this.Controls.BrowseOrEnterComputerNameTextBox.Text;
            }
            
            set
            {
                this.Controls.BrowseOrEnterComputerNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceCounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectPerformanceCounterDialogControls.PerformanceCounterStaticControl
        {
            get
            {
                if ((this.cachedPerformanceCounterStaticControl == null))
                {
                    this.cachedPerformanceCounterStaticControl = new StaticControl(this, SelectPerformanceCounterDialog.ControlIDs.PerformanceCounterStaticControl);
                }
                return this.cachedPerformanceCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseOrEnterComputerNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectPerformanceCounterDialogControls.BrowseOrEnterComputerNameStaticControl
        {
            get
            {
                if ((this.cachedBrowseOrEnterComputerNameStaticControl == null))
                {
                    this.cachedBrowseOrEnterComputerNameStaticControl = new StaticControl(this, SelectPerformanceCounterDialog.ControlIDs.BrowseOrEnterComputerNameStaticControl);
                }
                return this.cachedBrowseOrEnterComputerNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectInstanceFromListStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectPerformanceCounterDialogControls.SelectInstanceFromListStaticControl
        {
            get
            {
                if ((this.cachedSelectInstanceFromListStaticControl == null))
                {
                    this.cachedSelectInstanceFromListStaticControl = new StaticControl(this, SelectPerformanceCounterDialog.ControlIDs.SelectInstanceFromListStaticControl);
                }
                return this.cachedSelectInstanceFromListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllInstancesCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISelectPerformanceCounterDialogControls.AllInstancesCheckBox
        {
            get
            {
                if ((this.cachedAllInstancesCheckBox == null))
                {
                    this.cachedAllInstancesCheckBox = new CheckBox(this, SelectPerformanceCounterDialog.ControlIDs.AllInstancesCheckBox);
                }
                return this.cachedAllInstancesCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectInstanceFromListListBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ISelectPerformanceCounterDialogControls.SelectInstanceFromListListBox
        {
            get
            {
                if ((this.cachedSelectInstanceFromListListBox == null))
                {
                    this.cachedSelectInstanceFromListListBox = new ListBox(this, SelectPerformanceCounterDialog.ControlIDs.SelectInstanceFromListListBox);
                }
                return this.cachedSelectInstanceFromListListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExplainButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectPerformanceCounterDialogControls.ExplainButton
        {
            get
            {
                if ((this.cachedExplainButton == null))
                {
                    this.cachedExplainButton = new Button(this, SelectPerformanceCounterDialog.ControlIDs.ExplainButton);
                }
                return this.cachedExplainButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISelectPerformanceCounterDialogControls.ObjectComboBox
        {
            get
            {
                if ((this.cachedObjectComboBox == null))
                {
                    this.cachedObjectComboBox = new ComboBox(this, SelectPerformanceCounterDialog.ControlIDs.ObjectComboBox);
                }
                return this.cachedObjectComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectPerformanceCounterDialogControls.ComputerStaticControl
        {
            get
            {
                if ((this.cachedComputerStaticControl == null))
                {
                    this.cachedComputerStaticControl = new StaticControl(this, SelectPerformanceCounterDialog.ControlIDs.ComputerStaticControl);
                }
                return this.cachedComputerStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectPerformanceCounterDialogControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, SelectPerformanceCounterDialog.ControlIDs.Button0);
                }
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseOrEnterComputerNameTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISelectPerformanceCounterDialogControls.BrowseOrEnterComputerNameTextBox
        {
            get
            {
                if ((this.cachedBrowseOrEnterComputerNameTextBox == null))
                {
                    this.cachedBrowseOrEnterComputerNameTextBox = new TextBox(this, SelectPerformanceCounterDialog.ControlIDs.BrowseOrEnterComputerNameTextBox);
                }
                return this.cachedBrowseOrEnterComputerNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectCounterFromListListBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox ISelectPerformanceCounterDialogControls.SelectCounterFromListListBox
        {
            get
            {
                if ((this.cachedSelectCounterFromListListBox == null))
                {
                    this.cachedSelectCounterFromListListBox = new ListBox(this, SelectPerformanceCounterDialog.ControlIDs.SelectCounterFromListListBox);
                }
                return this.cachedSelectCounterFromListListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectPerformanceCounterDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SelectPerformanceCounterDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISelectPerformanceCounterDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SelectPerformanceCounterDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectCounterFromListStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectPerformanceCounterDialogControls.SelectCounterFromListStaticControl
        {
            get
            {
                if ((this.cachedSelectCounterFromListStaticControl == null))
                {
                    this.cachedSelectCounterFromListStaticControl = new StaticControl(this, SelectPerformanceCounterDialog.ControlIDs.SelectCounterFromListStaticControl);
                }
                return this.cachedSelectCounterFromListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ObjectStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISelectPerformanceCounterDialogControls.ObjectStaticControl
        {
            get
            {
                if ((this.cachedObjectStaticControl == null))
                {
                    this.cachedObjectStaticControl = new StaticControl(this, SelectPerformanceCounterDialog.ControlIDs.ObjectStaticControl);
                }
                return this.cachedObjectStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AllInstances
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAllInstances()
        {
            this.Controls.AllInstancesCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Explain
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickExplain()
        {
            this.Controls.ExplainButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 14APR06 Created
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
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
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
        /// 	[mbickle] 14APR06 Created
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
            private const string ResourceDialogTitle = ";Select Performance Counter;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceCounter = ";Performance counter;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;pageSectionLabel2.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BrowseOrEnterComputerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowseOrEnterComputerName = ";Browse or enter computer name;ManagedString;Microsoft.MOM.UI.Components.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EventLogSelectorForm;lineSepa" +
                "rator1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectInstanceFromList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectInstanceFromList = ";S&elect instance from list:;ManagedString;Microsoft.MOM.UI.Components.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;selectInstan" +
                "ceLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllInstances
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllInstances = ";All instan&ces;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;includeAllCheckBox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Explain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExplain = ";E&xplain...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;explainButton.Text";
            
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
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectCounterFromList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectCounterFromList = ";&Select counter from list:;ManagedString;Microsoft.MOM.UI.Components.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.PerfCounterBrowser;selectCounter" +
                "Label.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Object
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObject = ";&Object:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.Pages.PerfCounterBrowser;objectLabel.Text";
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
            /// Caches the translated resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceCounter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BrowseOrEnterComputerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowseOrEnterComputerName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectInstanceFromList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectInstanceFromList;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllInstances
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllInstances;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Explain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExplain;
            
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectCounterFromList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectCounterFromList;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Object
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObject;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
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
            /// Exposes access to the PerformanceCounter translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceCounter
            {
                get
                {
                    if ((cachedPerformanceCounter == null))
                    {
                        cachedPerformanceCounter = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceCounter);
                    }
                    return cachedPerformanceCounter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BrowseOrEnterComputerName translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BrowseOrEnterComputerName
            {
                get
                {
                    if ((cachedBrowseOrEnterComputerName == null))
                    {
                        cachedBrowseOrEnterComputerName = CoreManager.MomConsole.GetIntlStr(ResourceBrowseOrEnterComputerName);
                    }
                    return cachedBrowseOrEnterComputerName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectInstanceFromList translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectInstanceFromList
            {
                get
                {
                    if ((cachedSelectInstanceFromList == null))
                    {
                        cachedSelectInstanceFromList = CoreManager.MomConsole.GetIntlStr(ResourceSelectInstanceFromList);
                    }
                    return cachedSelectInstanceFromList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllInstances translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllInstances
            {
                get
                {
                    if ((cachedAllInstances == null))
                    {
                        cachedAllInstances = CoreManager.MomConsole.GetIntlStr(ResourceAllInstances);
                    }
                    return cachedAllInstances;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Explain translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Explain
            {
                get
                {
                    if ((cachedExplain == null))
                    {
                        cachedExplain = CoreManager.MomConsole.GetIntlStr(ResourceExplain);
                    }
                    return cachedExplain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Computer translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
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
            /// 	[mbickle] 14APR06 Created
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
            /// 	[mbickle] 14APR06 Created
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
            /// Exposes access to the SelectCounterFromList translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectCounterFromList
            {
                get
                {
                    if ((cachedSelectCounterFromList == null))
                    {
                        cachedSelectCounterFromList = CoreManager.MomConsole.GetIntlStr(ResourceSelectCounterFromList);
                    }
                    return cachedSelectCounterFromList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Object translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Object
            {
                get
                {
                    if ((cachedObject == null))
                    {
                        cachedObject = CoreManager.MomConsole.GetIntlStr(ResourceObject);
                    }
                    return cachedObject;
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
        /// 	[mbickle] 14APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PerformanceCounterStaticControl
            /// </summary>
            public const string PerformanceCounterStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for BrowseOrEnterComputerNameStaticControl
            /// </summary>
            public const string BrowseOrEnterComputerNameStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for SelectInstanceFromListStaticControl
            /// </summary>
            public const string SelectInstanceFromListStaticControl = "selectInstanceLabel";
            
            /// <summary>
            /// Control ID for AllInstancesCheckBox
            /// </summary>
            public const string AllInstancesCheckBox = "includeAllCheckBox";
            
            /// <summary>
            /// Control ID for SelectInstanceFromListListBox
            /// </summary>
            public const string SelectInstanceFromListListBox = "instanceListbox";
            
            /// <summary>
            /// Control ID for ExplainButton
            /// </summary>
            public const string ExplainButton = "explainButton";
            
            /// <summary>
            /// Control ID for ObjectComboBox
            /// </summary>
            public const string ObjectComboBox = "objectComboBox";
            
            /// <summary>
            /// Control ID for ComputerStaticControl
            /// </summary>
            public const string ComputerStaticControl = "computerLabel";
            
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "browseButton";
            
            /// <summary>
            /// Control ID for BrowseOrEnterComputerNameTextBox
            /// </summary>
            public const string BrowseOrEnterComputerNameTextBox = "computerNameTextbox";
            
            /// <summary>
            /// Control ID for SelectCounterFromListListBox
            /// </summary>
            public const string SelectCounterFromListListBox = "counterListbox";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for SelectCounterFromListStaticControl
            /// </summary>
            public const string SelectCounterFromListStaticControl = "selectCounterLabel";
            
            /// <summary>
            /// Control ID for ObjectStaticControl
            /// </summary>
            public const string ObjectStaticControl = "objectLabel";
        }
        #endregion
    }
}
