// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ComputerPickerDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sharatja] 8/7/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IComputerPickerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IComputerPickerDialogControls, for ComputerPickerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IComputerPickerDialogControls
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
        /// Read-only property to access SelectedComputersListView
        /// </summary>
        ListView SelectedComputersListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableComputersStaticControl
        /// </summary>
        StaticControl AvailableComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AvailableComputersListView
        /// </summary>
        ListView AvailableComputersListView
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
        /// Read-only property to access RemoveButton
        /// </summary>
        Button RemoveButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedComputersStaticControl
        /// </summary>
        StaticControl SelectedComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OptionComboBox
        /// </summary>
        ComboBox OptionComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OptionStaticControl
        /// </summary>
        StaticControl OptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HeaderTextStaticControl
        /// </summary>
        StaticControl HeaderTextStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchTextBox
        /// </summary>
        TextBox SearchTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchStaticControl
        /// </summary>
        StaticControl SearchStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchButton
        /// </summary>
        Button SearchButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AsyncCancelButton
        /// </summary>
        Button AsyncCancelButton
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
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ComputerPickerDialog : Dialog, IComputerPickerDialogControls
    {
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
        /// Cache to hold a reference to SelectedComputersListView of type ListView
        /// </summary>
        private ListView cachedSelectedComputersListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableComputersListView of type ListView
        /// </summary>
        private ListView cachedAvailableComputersListView;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectedComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OptionComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedOptionComboBox;
        
        /// <summary>
        /// Cache to hold a reference to OptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HeaderTextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHeaderTextStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchTextBox of type TextBox
        /// </summary>
        private TextBox cachedSearchTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SearchStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;

        /// <summary>
        /// Cache to hold a reference to AsyncCancelButton of type Button
        /// </summary>
        private Button cachedAsyncCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ComputerPickerDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ComputerPickerDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IComputerPickerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IComputerPickerDialogControls Controls
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
        ///  Routine to set/get the text in control Distribution
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DistributionText
        {
            get
            {
                return this.Controls.OptionComboBox.Text;
            }
            
            set
            {
                this.Controls.OptionComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Search
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchText
        {
            get
            {
                return this.Controls.SearchTextBox.Text;
            }
            
            set
            {
                this.Controls.SearchTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerPickerDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ComputerPickerDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerPickerDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ComputerPickerDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedComputersListView control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IComputerPickerDialogControls.SelectedComputersListView
        {
            get
            {
                if ((this.cachedSelectedComputersListView == null))
                {
                    this.cachedSelectedComputersListView = new ListView(this, ComputerPickerDialog.ControlIDs.SelectedComputersListView);
                }
                return this.cachedSelectedComputersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerPickerDialogControls.AvailableComputersStaticControl
        {
            get
            {
                if ((this.cachedAvailableComputersStaticControl == null))
                {
                    this.cachedAvailableComputersStaticControl = new StaticControl(this, ComputerPickerDialog.ControlIDs.AvailableItemsStaticControl);
                }
                return this.cachedAvailableComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableComputersListView control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IComputerPickerDialogControls.AvailableComputersListView
        {
            get
            {
                if ((this.cachedAvailableComputersListView == null))
                {
                    this.cachedAvailableComputersListView = new ListView(this, ComputerPickerDialog.ControlIDs.AvailableItemsListView);
                }
                return this.cachedAvailableComputersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerPickerDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, ComputerPickerDialog.ControlIDs.AddButton);
                }
                return this.cachedAddButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RemoveButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerPickerDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, ComputerPickerDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerPickerDialogControls.SelectedComputersStaticControl
        {
            get
            {
                if ((this.cachedSelectedComputersStaticControl == null))
                {
                    this.cachedSelectedComputersStaticControl = new StaticControl(this, ComputerPickerDialog.ControlIDs.SelectedObjectsStaticControl);
                }
                return this.cachedSelectedComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptionComboBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IComputerPickerDialogControls.OptionComboBox
        {
            get
            {
                if ((this.cachedOptionComboBox == null))
                {
                    this.cachedOptionComboBox = new ComboBox(this, ComputerPickerDialog.ControlIDs.DistributionComboBox);
                }
                return this.cachedOptionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerPickerDialogControls.OptionStaticControl
        {
            get
            {
                if ((this.cachedOptionStaticControl == null))
                {
                    this.cachedOptionStaticControl = new StaticControl(this, ComputerPickerDialog.ControlIDs.OptionStaticControl);
                }
                return this.cachedOptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeaderStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerPickerDialogControls.HeaderTextStaticControl
        {
            get
            {
                if ((this.cachedHeaderTextStaticControl == null))
                {
                    this.cachedHeaderTextStaticControl = new StaticControl(this, ComputerPickerDialog.ControlIDs.HeaderStaticControl);
                }
                return this.cachedHeaderTextStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTextBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IComputerPickerDialogControls.SearchTextBox
        {
            get
            {
                if ((this.cachedSearchTextBox == null))
                {
                    this.cachedSearchTextBox = new TextBox(this, ComputerPickerDialog.ControlIDs.SearchTextBox);
                }
                return this.cachedSearchTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerPickerDialogControls.SearchStaticControl
        {
            get
            {
                if ((this.cachedSearchStaticControl == null))
                {
                    this.cachedSearchStaticControl = new StaticControl(this, ComputerPickerDialog.ControlIDs.SearchStaticControl);
                }
                return this.cachedSearchStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerPickerDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, ComputerPickerDialog.ControlIDs.SearchButton);
                }
                return this.cachedSearchButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AsyncCancelButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 9/10/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerPickerDialogControls.AsyncCancelButton
        {
            get
            {
                // The ID for this control (cancelButton) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAsyncCancelButton == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
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

                    this.cachedAsyncCancelButton = new Button(wndTemp);
                }
                return this.cachedAsyncCancelButton;
            }
        }
        
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
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
        /// 	[sharatja] 8/7/2008 Created
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
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdd()
        {
            this.Controls.AddButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Remove
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRemove()
        {
            this.Controls.RemoveButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Search
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AsyncCancel
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAsyncCancel()
        {
            this.Controls.AsyncCancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
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
                const int MAXTRIES = 7;
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
        /// 	[sharatja] 8/7/2008 Created
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
            private const string ResourceDialogTitle = ";Computer Search;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ComputerPickerDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources;CancelText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems = ";Available items;ManagedString;Microsoft.Mom.UI.Common.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Controls.ChooserControl;availableObjects.CaptionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";&Add;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSchedul" +
                "ePage;periods.AddButtonText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";&Remove;ManagedString;Corgent.Diagramming.CommandResources.dll;Corgent.Diagrammi" +
                "ng.CommandResources.Properties.Resources;Command_Remove";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedObjects = ";Selected &objects;ManagedString;Microsoft.Mom.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Controls.ChooserControl;selectedObjects.CaptionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Option
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOption = ";Option:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Dialogs.PickerDialogs.ComputerPickerControl;label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HeaderText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderText = ";To add computers, search for available computers and then add them to the selected c" +
                "omputers list.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ComputerPickerControl;label1.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";Search:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Dialogs.PickerDialogs.ComputerPickerControl;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AsyncCancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAsyncCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources;CancelText";
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
            /// Caches the translated resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAvailableItems;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemove;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectedObjects;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Option
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOption;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HeaderText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHeaderText;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AsyncCancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAsyncCancel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the AvailableItems translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AvailableItems
            {
                get
                {
                    if ((cachedAvailableItems == null))
                    {
                        cachedAvailableItems = CoreManager.MomConsole.GetIntlStr(ResourceAvailableItems);
                    }
                    return cachedAvailableItems;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Remove
            {
                get
                {
                    if ((cachedRemove == null))
                    {
                        cachedRemove = CoreManager.MomConsole.GetIntlStr(ResourceRemove);
                    }
                    return cachedRemove;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectedObjects
            {
                get
                {
                    if ((cachedSelectedObjects == null))
                    {
                        cachedSelectedObjects = CoreManager.MomConsole.GetIntlStr(ResourceSelectedObjects);
                    }
                    return cachedSelectedObjects;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Option translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Option
            {
                get
                {
                    if ((cachedOption == null))
                    {
                        cachedOption = CoreManager.MomConsole.GetIntlStr(ResourceOption);
                    }
                    return cachedOption;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HeaderText translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HeaderText
            {
                get
                {
                    if ((cachedHeaderText == null))
                    {
                        cachedHeaderText = CoreManager.MomConsole.GetIntlStr(ResourceHeaderText);
                    }
                    return cachedHeaderText;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Search
            {
                get
                {
                    if ((cachedSearch == null))
                    {
                        cachedSearch = CoreManager.MomConsole.GetIntlStr(ResourceSearch);
                    }
                    return cachedSearch;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AsyncCancel translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AsyncCancel
            {
                get
                {
                    if ((cachedAsyncCancel == null))
                    {
                        cachedAsyncCancel = CoreManager.MomConsole.GetIntlStr(ResourceAsyncCancel);
                    }
                    return cachedAsyncCancel;
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
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";

            /// <summary>
            /// Control ID for AsyncCancelButton
            /// </summary>
            public const string AsyncCancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for SelectedComputersListView
            /// </summary>
            public const string SelectedComputersListView = "selectedItemsListview";
            
            /// <summary>
            /// Control ID for AvailableComputersStaticControl
            /// </summary>
            public const string AvailableItemsStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for AvailableComputersListView
            /// </summary>
            public const string AvailableItemsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for SelectedComputersStaticControl
            /// </summary>
            public const string SelectedObjectsStaticControl = "selectedObjectsLabel";
            
            /// <summary>
            /// Control ID for OptionComboBox
            /// </summary>
            public const string DistributionComboBox = "optionSelecter";
            
            /// <summary>
            /// Control ID for OptionStaticControl
            /// </summary>
            public const string OptionStaticControl = "label3";
            
            /// <summary>
            /// Control ID for HeaderStaticControl
            /// </summary>
            public const string HeaderStaticControl = "label1";
            
            /// <summary>
            /// Control ID for SearchTextBox
            /// </summary>
            public const string SearchTextBox = "filterEntry";
            
            /// <summary>
            /// Control ID for SearchStaticControl
            /// </summary>
            public const string SearchStaticControl = "label2";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";

        }
        #endregion
    }
}
