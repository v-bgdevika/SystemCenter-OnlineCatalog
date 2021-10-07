// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ObjectPickerDialog.cs">
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

namespace Mom.Test.UI.Core.Console.RunAsProfile
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IObjectPickerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IObjectPickerDialogControls, for ObjectPickerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IObjectPickerDialogControls
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
        /// Read-only property to access SelectedItemsListView
        /// </summary>
        ListView SelectedItemsListView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AvailableItemsStaticControl
        /// </summary>
        StaticControl AvailableItemsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SelectedItemsListview
        /// </summary>
        ListView AvailableItemsListView
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
        /// Read-only property to access SelectedItemsStaticControl
        /// </summary>
        StaticControl SelectedItemsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookForComboBox
        /// </summary>
        ComboBox LookForComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilterByTextBox
        /// </summary>
        TextBox FilterByTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LookForStaticControl
        /// </summary>
        StaticControl LookForStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilterByStaticControl
        /// </summary>
        StaticControl FilterByStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access HeaderStaticControl
        /// </summary>
        StaticControl HeaderStaticControl
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
    public class ObjectPickerDialog : Dialog, IObjectPickerDialogControls
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
        /// Cache to hold a reference to SelectedItemsListView of type ListView
        /// </summary>
        private ListView cachedSelectedItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedItemsListview of type ListView
        /// </summary>
        private ListView cachedAvailableItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectedItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LookForComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedLookForComboBox;
        
        /// <summary>
        /// Cache to hold a reference to FilterByTextBox of type TextBox
        /// </summary>
        private TextBox cachedFilterByTextBox;
        
        /// <summary>
        /// Cache to hold a reference to LookForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLookForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FilterByStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilterByStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HeaderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHeaderStaticControl;
        
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
        /// Owner of ObjectPickerDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ObjectPickerDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IObjectPickerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IObjectPickerDialogControls Controls
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
        ///  Routine to set/get the text in control HeaderText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HeaderText
        {
            get
            {
                return this.Controls.LookForComboBox.Text;
            }
            
            set
            {
                this.Controls.LookForComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Option
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string OptionText
        {
            get
            {
                return this.Controls.FilterByTextBox.Text;
            }
            
            set
            {
                this.Controls.FilterByTextBox.Text = value;
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
        Button IObjectPickerDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ObjectPickerDialog.ControlIDs.CancelButton);
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
        Button IObjectPickerDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ObjectPickerDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedItemsListView control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IObjectPickerDialogControls.SelectedItemsListView
        {
            get
            {
                if ((this.cachedSelectedItemsListView == null))
                {
                    this.cachedSelectedItemsListView = new ListView(this, ObjectPickerDialog.ControlIDs.SelectedItemsListview);
                }
                return this.cachedSelectedItemsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectPickerDialogControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.AvailableItemsStaticControl);
                }
                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedItemsListview control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IObjectPickerDialogControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = new ListView(this, ObjectPickerDialog.ControlIDs.AvailableItemsListView);
                }
                return this.cachedAvailableItemsListView;
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
        Button IObjectPickerDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, ObjectPickerDialog.ControlIDs.AddButton);
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
        Button IObjectPickerDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, ObjectPickerDialog.ControlIDs.RemoveButton);
                }
                return this.cachedRemoveButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectPickerDialogControls.SelectedItemsStaticControl
        {
            get
            {
                if ((this.cachedSelectedObjectsStaticControl == null))
                {
                    this.cachedSelectedObjectsStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.SelectedItemsStaticControl);
                }
                return this.cachedSelectedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForComboBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IObjectPickerDialogControls.LookForComboBox
        {
            get
            {
                if ((this.cachedLookForComboBox == null))
                {
                    this.cachedLookForComboBox = new ComboBox(this, ObjectPickerDialog.ControlIDs.LookForComboBox);
                }
                return this.cachedLookForComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterByTextBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IObjectPickerDialogControls.FilterByTextBox
        {
            get
            {
                if ((this.cachedFilterByTextBox == null))
                {
                    this.cachedFilterByTextBox = new TextBox(this, ObjectPickerDialog.ControlIDs.FilterByTextBox);
                }
                return this.cachedFilterByTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LookForStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectPickerDialogControls.LookForStaticControl
        {
            get
            {
                if ((this.cachedLookForStaticControl == null))
                {
                    this.cachedLookForStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.LookForStaticControl);
                }
                return this.cachedLookForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterByStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectPickerDialogControls.FilterByStaticControl
        {
            get
            {
                if ((this.cachedFilterByStaticControl == null))
                {
                    this.cachedFilterByStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.FilterByStaticControl);
                }
                return this.cachedFilterByStaticControl;
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
        StaticControl IObjectPickerDialogControls.HeaderStaticControl
        {
            get
            {
                if ((this.cachedHeaderStaticControl == null))
                {
                    this.cachedHeaderStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.HeaderStaticControl);
                }
                return this.cachedHeaderStaticControl;
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
        Button IObjectPickerDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, ObjectPickerDialog.ControlIDs.SearchButton);
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
        Button IObjectPickerDialogControls.AsyncCancelButton
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
        /// 	[sharatja] 9/10/2008 Created
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
            private const string ResourceDialogTitle = ";Object Search;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerDialog;$this.Text";
            
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
            /// Contains resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLookFor = ";Look for:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.GroupServiceChooser;searchLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterBy = ";Filter by:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerControl;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HeaderText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderText =
                @";To add objects, search for the objects and then add them to the selected objects list." +
                ";ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.ObjectPickerControl" +
                ";label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";Search;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.Rep" +
                "ortMonitoringObjectSearchCriteria;searchButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AsyncCancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAsyncCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources;CancelText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MPAny
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMPAny = ";(Any);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.PickerDialogResources;MPAny";
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
            /// Caches the translated resource string for:  LookFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLookFor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilterBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterBy;
            
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MPAny
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMPAny;
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
            /// Exposes access to the LookFor translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LookFor
            {
                get
                {
                    if ((cachedLookFor == null))
                    {
                        cachedLookFor = CoreManager.MomConsole.GetIntlStr(ResourceLookFor);
                    }
                    return cachedLookFor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FilterBy translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterBy
            {
                get
                {
                    if ((cachedFilterBy == null))
                    {
                        cachedFilterBy = CoreManager.MomConsole.GetIntlStr(ResourceFilterBy);
                    }
                    return cachedFilterBy;
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
            /// 	[sharatja] 9/10/2008 Created
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

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MPAny translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 9/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MPAny
            {
                get
                {
                    if ((cachedMPAny == null))
                    {
                        cachedMPAny = CoreManager.MomConsole.GetIntlStr(ResourceMPAny);
                    }
                    return cachedMPAny;
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
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for AvailableItemsListView
            /// </summary>
            public const string AvailableItemsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AvailableItemsStaticControl
            /// </summary>
            public const string AvailableItemsStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for SelectedItemsListview
            /// </summary>
            public const string SelectedItemsListview = "selectedItemsListview";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for SelectedItemsStaticControl
            /// </summary>
            public const string SelectedItemsStaticControl = "selectedObjectsLabel";
            
            /// <summary>
            /// Control ID for LookForComboBox
            /// </summary>
            public const string LookForComboBox = "classSelector";
            
            /// <summary>
            /// Control ID for FilterByTextBox
            /// </summary>
            public const string FilterByTextBox = "filterEntry";
            
            /// <summary>
            /// Control ID for LookForStaticControl
            /// </summary>
            public const string LookForStaticControl = "label3";
            
            /// <summary>
            /// Control ID for FilterByStaticControl
            /// </summary>
            public const string FilterByStaticControl = "label2";
            
            /// <summary>
            /// Control ID for HeaderStaticControl
            /// </summary>
            public const string HeaderStaticControl = "label1";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for AsyncCancelButton
            /// </summary>
            public const string AsyncCancelButton = "cancelButton";
        }
        #endregion
    }
}
