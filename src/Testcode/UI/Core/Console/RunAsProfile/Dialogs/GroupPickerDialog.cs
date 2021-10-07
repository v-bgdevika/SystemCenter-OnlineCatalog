// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GroupPickerDialog.cs">
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
    
    #region Interface Definition - IGroupPickerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGroupPickerDialogControls, for GroupPickerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGroupPickerDialogControls
    {
        /// <summary>
        /// Read-only property to access ViewMembersStaticControl
        /// </summary>
        StaticControl ViewMembersStaticControl
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
        /// Read-only property to access AvailableItemsListView
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
        /// Read-only property to access ManagementPackComboBox
        /// </summary>
        ComboBox ManagementPackComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilterByOptionalTextBox
        /// </summary>
        TextBox FilterByOptionalTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ManagementPackStaticControl
        /// </summary>
        StaticControl ManagementPackStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access FilterByOptionalStaticControl
        /// </summary>
        StaticControl FilterByOptionalStaticControl
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
    public class GroupPickerDialog : Dialog, IGroupPickerDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ViewMembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedItemsListView of type ListView
        /// </summary>
        private ListView cachedSelectedItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsListView of type ListView
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
        private StaticControl cachedSelectedItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedOptionComboBox;
        
        /// <summary>
        /// Cache to hold a reference to FilterByOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedFilterByOptionalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FilterByOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilterByOptionalStaticControl;
        
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
        /// Owner of GroupPickerDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupPickerDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IGroupPickerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGroupPickerDialogControls Controls
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
                return this.Controls.ManagementPackComboBox.Text;
            }
            
            set
            {
                this.Controls.ManagementPackComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FilterByOptionalTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FilterByOptionalText
        {
            get
            {
                return this.Controls.FilterByOptionalTextBox.Text;
            }
            
            set
            {
                this.Controls.FilterByOptionalTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewMembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupPickerDialogControls.ViewMembersStaticControl
        {
            get
            {
                if ((this.cachedViewMembersStaticControl == null))
                {
                    this.cachedViewMembersStaticControl = new StaticControl(this, GroupPickerDialog.ControlIDs.ViewMembersStaticControl);
                }
                return this.cachedViewMembersStaticControl;
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
        ListView IGroupPickerDialogControls.SelectedItemsListView
        {
            get
            {
                if ((this.cachedSelectedItemsListView == null))
                {
                    this.cachedSelectedItemsListView = new ListView(this, GroupPickerDialog.ControlIDs.SelectedItemsListview);
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
        StaticControl IGroupPickerDialogControls.AvailableItemsStaticControl
        {
            get
            {
                if ((this.cachedAvailableItemsStaticControl == null))
                {
                    this.cachedAvailableItemsStaticControl = new StaticControl(this, GroupPickerDialog.ControlIDs.AvailableItemsStaticControl);
                }
                return this.cachedAvailableItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsListView control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IGroupPickerDialogControls.AvailableItemsListView
        {
            get
            {
                if ((this.cachedAvailableItemsListView == null))
                {
                    this.cachedAvailableItemsListView = new ListView(this, GroupPickerDialog.ControlIDs.AvailableItemsListView);
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
        Button IGroupPickerDialogControls.AddButton
        {
            get
            {
                if ((this.cachedAddButton == null))
                {
                    this.cachedAddButton = new Button(this, GroupPickerDialog.ControlIDs.AddButton);
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
        Button IGroupPickerDialogControls.RemoveButton
        {
            get
            {
                if ((this.cachedRemoveButton == null))
                {
                    this.cachedRemoveButton = new Button(this, GroupPickerDialog.ControlIDs.RemoveButton);
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
        StaticControl IGroupPickerDialogControls.SelectedItemsStaticControl
        {
            get
            {
                if ((this.cachedSelectedItemsStaticControl == null))
                {
                    this.cachedSelectedItemsStaticControl = new StaticControl(this, GroupPickerDialog.ControlIDs.SelectedItemsStaticControl);
                }
                return this.cachedSelectedItemsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupPickerDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GroupPickerDialog.ControlIDs.CancelButton);
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
        Button IGroupPickerDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, GroupPickerDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IGroupPickerDialogControls.ManagementPackComboBox
        {
            get
            {
                if ((this.cachedOptionComboBox == null))
                {
                    this.cachedOptionComboBox = new ComboBox(this, GroupPickerDialog.ControlIDs.OptionComboBox);
                }
                return this.cachedOptionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterByOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IGroupPickerDialogControls.FilterByOptionalTextBox
        {
            get
            {
                if ((this.cachedFilterByOptionalTextBox == null))
                {
                    this.cachedFilterByOptionalTextBox = new TextBox(this, GroupPickerDialog.ControlIDs.FilterByOptionalTextBox);
                }
                return this.cachedFilterByOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupPickerDialogControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, GroupPickerDialog.ControlIDs.ManagementPackStaticControl);
                }
                return this.cachedManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterByOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupPickerDialogControls.FilterByOptionalStaticControl
        {
            get
            {
                if ((this.cachedFilterByOptionalStaticControl == null))
                {
                    this.cachedFilterByOptionalStaticControl = new StaticControl(this, GroupPickerDialog.ControlIDs.FilterByOptionalStaticControl);
                }
                return this.cachedFilterByOptionalStaticControl;
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
        StaticControl IGroupPickerDialogControls.HeaderStaticControl
        {
            get
            {
                if ((this.cachedHeaderStaticControl == null))
                {
                    this.cachedHeaderStaticControl = new StaticControl(this, GroupPickerDialog.ControlIDs.HeaderStaticControl);
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
        Button IGroupPickerDialogControls.SearchButton
        {
            get
            {
                if ((this.cachedSearchButton == null))
                {
                    this.cachedSearchButton = new Button(this, GroupPickerDialog.ControlIDs.SearchButton);
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
        Button IGroupPickerDialogControls.AsyncCancelButton
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
                    for (i = 0; (i <= 3); i = (i + 1))
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
            private const string ResourceDialogTitle = ";Group Search;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.GroupPickerDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewMembers = ";View members...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Dialogs.PickerDialogs.GroupPickerDialog;groupsLinkL" +
                "abel.Text";
            
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
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = ";Management pack:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;mpL" +
                "abel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FilterByOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterByOptional = ";Filter by: (optional);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.GroupClassPickerControl" +
                "Base;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HeaderText
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderText =
                @";To add groups, search for the group by name and management pack and then add them to the selected objects list." +
                ";ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Dialogs.PickerDialogs.GroupPickerControl" +
                ";$this.DescriptionText";
            
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
            /// Caches the translated resource string for:  ViewMembers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewMembers;
            
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
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  FilterByOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterByOptional;
            
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
            /// Exposes access to the ViewMembers translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewMembers
            {
                get
                {
                    if ((cachedViewMembers == null))
                    {
                        cachedViewMembers = CoreManager.MomConsole.GetIntlStr(ResourceViewMembers);
                    }
                    return cachedViewMembers;
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
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPack
            {
                get
                {
                    if ((cachedManagementPack == null))
                    {
                        cachedManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceManagementPack);
                    }
                    return cachedManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FilterByOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterByOptional
            {
                get
                {
                    if ((cachedFilterByOptional == null))
                    {
                        cachedFilterByOptional = CoreManager.MomConsole.GetIntlStr(ResourceFilterByOptional);
                    }
                    return cachedFilterByOptional;
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
            /// Control ID for ViewMembersStaticControl
            /// </summary>
            public const string ViewMembersStaticControl = "groupsLinkLabel";
            
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
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for ManagementPackComboBox
            /// </summary>
            public const string OptionComboBox = "mpSelector";
            
            /// <summary>
            /// Control ID for FilterByOptionalTextBox
            /// </summary>
            public const string FilterByOptionalTextBox = "filterEntry";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "label3";
            
            /// <summary>
            /// Control ID for FilterByOptionalStaticControl
            /// </summary>
            public const string FilterByOptionalStaticControl = "label2";
            
            /// <summary>
            /// Control ID for HeaderStaticControl
            /// </summary>
            public const string HeaderStaticControl = "descriptionLabel";
            
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
