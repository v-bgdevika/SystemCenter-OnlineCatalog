// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ObjectPickerDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[HainingW] 3/31/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
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
    /// 	[HainingW] 3/31/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IObjectPickerDialogControls
    {
        /// <summary>
        /// Read-only property to access AvailableItemsListView
        /// </summary>
        ListView AvailableItemsListView
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
        /// Read-only property to access SelectedObjectsListView
        /// </summary>
        ListView SelectedObjectsListView
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
        /// Read-only property to access SelectedObjectsStaticControl
        /// </summary>
        StaticControl SelectedObjectsStaticControl
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
        /// Read-only property to access FilterByPartOfNameOptionalStaticControl
        /// </summary>
        StaticControl FilterByPartOfNameOptionalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchForStaticControl
        /// </summary>
        StaticControl SearchForStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchForComboBox
        /// </summary>
        ComboBox SearchForComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectObjectsToBeMembersOfThisGroupStaticControl
        /// </summary>
        StaticControl SelectObjectsToBeMembersOfThisGroupStaticControl
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
        /// Read-only property to access FilterByPartOfNameOptionalTextBox
        /// </summary>
        TextBox FilterByPartOfNameOptionalTextBox
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
    /// 	[HainingW] 3/31/2006 Created
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
        /// Cache to hold a reference to AvailableItemsListView of type ListView
        /// </summary>
        private ListView cachedAvailableItemsListView;
        
        /// <summary>
        /// Cache to hold a reference to AvailableItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableItemsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectedObjectsListView of type ListView
        /// </summary>
        private ListView cachedSelectedObjectsListView;
        
        /// <summary>
        /// Cache to hold a reference to AddButton of type Button
        /// </summary>
        private Button cachedAddButton;
        
        /// <summary>
        /// Cache to hold a reference to RemoveButton of type Button
        /// </summary>
        private Button cachedRemoveButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectedObjectsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectedObjectsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to FilterByPartOfNameOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFilterByPartOfNameOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchForStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchForStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchForComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSearchForComboBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectObjectsToBeMembersOfThisGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectObjectsToBeMembersOfThisGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SearchButton of type Button
        /// </summary>
        private Button cachedSearchButton;
        
        /// <summary>
        /// Cache to hold a reference to FilterByPartOfNameOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedFilterByPartOfNameOptionalTextBox;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with no dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of ObjectPickerDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ObjectPickerDialog(MomConsoleApp app) 
            : base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of ObjectPickerDialog of type MomConsoleApp
        /// </param>
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ObjectPickerDialog(MomConsoleApp app, string title)
            : base(app, Init(app, title))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        #endregion
        
        #region IObjectPickerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
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
        ///  Routine to set/get the text in control SearchFor
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchForText
        {
            get
            {
                return this.Controls.SearchForComboBox.Text;
            }
            
            set
            {
                this.Controls.SearchForComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FilterByPartOfNameOptional
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FilterByPartOfNameOptionalText
        {
            get
            {
                return this.Controls.FilterByPartOfNameOptionalTextBox.Text;
            }
            
            set
            {
                this.Controls.FilterByPartOfNameOptionalTextBox.Text = value;
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AvailableItemsListView control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
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
        ///  Exposes access to the AvailableItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
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
        ///  Exposes access to the SelectedObjectsListView control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IObjectPickerDialogControls.SelectedObjectsListView
        {
            get
            {
                if ((this.cachedSelectedObjectsListView == null))
                {
                    this.cachedSelectedObjectsListView = new ListView(this, ObjectPickerDialog.ControlIDs.SelectedObjectsListView);
                }
                return this.cachedSelectedObjectsListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
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
        /// 	[HainingW] 3/31/2006 Created
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
        ///  Exposes access to the SelectedObjectsStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectPickerDialogControls.SelectedObjectsStaticControl
        {
            get
            {
                if ((this.cachedSelectedObjectsStaticControl == null))
                {
                    this.cachedSelectedObjectsStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.SelectedObjectsStaticControl);
                }
                return this.cachedSelectedObjectsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
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
        /// 	[HainingW] 3/31/2006 Created
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
        ///  Exposes access to the FilterByPartOfNameOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectPickerDialogControls.FilterByPartOfNameOptionalStaticControl
        {
            get
            {
                if ((this.cachedFilterByPartOfNameOptionalStaticControl == null))
                {
                    this.cachedFilterByPartOfNameOptionalStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.FilterByPartOfNameOptionalStaticControl);
                }
                return this.cachedFilterByPartOfNameOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchForStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectPickerDialogControls.SearchForStaticControl
        {
            get
            {
                if ((this.cachedSearchForStaticControl == null))
                {
                    this.cachedSearchForStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.SearchForStaticControl);
                }
                return this.cachedSearchForStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchForComboBox control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IObjectPickerDialogControls.SearchForComboBox
        {
            get
            {
                if ((this.cachedSearchForComboBox == null))
                {
                    this.cachedSearchForComboBox = new ComboBox(this, ObjectPickerDialog.ControlIDs.SearchForComboBox);
                }
                return this.cachedSearchForComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectObjectsToBeMembersOfThisGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IObjectPickerDialogControls.SelectObjectsToBeMembersOfThisGroupStaticControl
        {
            get
            {
                if ((this.cachedSelectObjectsToBeMembersOfThisGroupStaticControl == null))
                {
                    this.cachedSelectObjectsToBeMembersOfThisGroupStaticControl = new StaticControl(this, ObjectPickerDialog.ControlIDs.SelectObjectsToBeMembersOfThisGroupStaticControl);
                }
                return this.cachedSelectObjectsToBeMembersOfThisGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
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
        ///  Exposes access to the FilterByPartOfNameOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IObjectPickerDialogControls.FilterByPartOfNameOptionalTextBox
        {
            get
            {
                if ((this.cachedFilterByPartOfNameOptionalTextBox == null))
                {
                    this.cachedFilterByPartOfNameOptionalTextBox = new TextBox(this, ObjectPickerDialog.ControlIDs.FilterByPartOfNameOptionalTextBox);
                }
                return this.cachedFilterByPartOfNameOptionalTextBox;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Add
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
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
        /// 	[HainingW] 3/31/2006 Created
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
        /// 	[HainingW] 3/31/2006 Created
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
        /// 	[HainingW] 3/31/2006 Created
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
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSearch()
        {
            this.Controls.SearchButton.Click();
        }

        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            Utilities.LogMessage("ObjectPickerDialog :: Init(app)");
            Window tempWindow = Init(app, Strings.DialogTitle);
            return tempWindow;
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, string title)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            Utilities.LogMessage("ObjectPickerDialog :: Init(app, title)");

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
        /// 	[HainingW] 3/31/2006 Created
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
            /// TODO: Create an enum so that we can switch between different dialog titles.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = @";Create Group Wizard - Object Selection;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ObjectPickerDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableItems = ";Available items;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Controls.AvailableObjectsControl;availableItemsLabel.Te" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdd = ";&Add;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.Controls.FormulaBuilder.RowContextMenuStrip;MenuAdd";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemove = ";&Remove;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.Controls.SelectedObjectsControl;removeButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectedObjects = ";Selected &objects;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Controls.SelectedObjectsControl;selectedObjectsLabel." +
                "Text";
            
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
            /// Contains resource string for:  FilterByPartOfNameOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFilterByPartOfNameOptional = ";Filter by part of name (optional):;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.GroupSearchCriteri" +
                "a;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchFor = ";Search for:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseMa" +
                "nagement.Internal.UI.Authoring.Pages.ObjectSearchCriteria;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectObjectsToBeMembersOfThisGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectObjectsToBeMembersOfThisGroup = ";Select objects to be members of this group.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ObjectSea" +
                "rchCriteria;searchHelpLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";Search;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.GroupSearchCriteria;searchButton.Text";
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
            /// Caches the translated resource string for:  FilterByPartOfNameOptional
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFilterByPartOfNameOptional;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SearchFor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchFor;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectObjectsToBeMembersOfThisGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectObjectsToBeMembersOfThisGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/31/2006 Created
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
            /// Exposes access to the AvailableItems translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/31/2006 Created
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
            /// 	[HainingW] 3/31/2006 Created
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
            /// 	[HainingW] 3/31/2006 Created
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
            /// 	[HainingW] 3/31/2006 Created
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
            /// 	[HainingW] 3/31/2006 Created
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
            /// 	[HainingW] 3/31/2006 Created
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
            /// Exposes access to the FilterByPartOfNameOptional translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/31/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FilterByPartOfNameOptional
            {
                get
                {
                    if ((cachedFilterByPartOfNameOptional == null))
                    {
                        cachedFilterByPartOfNameOptional = CoreManager.MomConsole.GetIntlStr(ResourceFilterByPartOfNameOptional);
                    }
                    return cachedFilterByPartOfNameOptional;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchFor translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/31/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchFor
            {
                get
                {
                    if ((cachedSearchFor == null))
                    {
                        cachedSearchFor = CoreManager.MomConsole.GetIntlStr(ResourceSearchFor);
                    }
                    return cachedSearchFor;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectObjectsToBeMembersOfThisGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/31/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectObjectsToBeMembersOfThisGroup
            {
                get
                {
                    if ((cachedSelectObjectsToBeMembersOfThisGroup == null))
                    {
                        cachedSelectObjectsToBeMembersOfThisGroup = CoreManager.MomConsole.GetIntlStr(ResourceSelectObjectsToBeMembersOfThisGroup);
                    }
                    return cachedSelectObjectsToBeMembersOfThisGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/31/2006 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/31/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for AvailableItemsListView
            /// </summary>
            public const string AvailableItemsListView = "availableItemsListView";
            
            /// <summary>
            /// Control ID for AvailableItemsStaticControl
            /// </summary>
            public const string AvailableItemsStaticControl = "availableItemsLabel";
            
            /// <summary>
            /// Control ID for SelectedObjectsListView
            /// </summary>
            public const string SelectedObjectsListView = "selectedItemsListview";
            
            /// <summary>
            /// Control ID for AddButton
            /// </summary>
            public const string AddButton = "addButton";
            
            /// <summary>
            /// Control ID for RemoveButton
            /// </summary>
            public const string RemoveButton = "removeButton";
            
            /// <summary>
            /// Control ID for SelectedObjectsStaticControl
            /// </summary>
            public const string SelectedObjectsStaticControl = "selectedObjectsLabel";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for FilterByPartOfNameOptionalStaticControl
            /// </summary>
            public const string FilterByPartOfNameOptionalStaticControl = "label2";
            
            /// <summary>
            /// Control ID for SearchForStaticControl
            /// </summary>
            public const string SearchForStaticControl = "label1";
            
            /// <summary>
            /// Control ID for SearchForComboBox
            /// </summary>
            public const string SearchForComboBox = "comboBox1";
            
            /// <summary>
            /// Control ID for SelectObjectsToBeMembersOfThisGroupStaticControl
            /// </summary>
            public const string SelectObjectsToBeMembersOfThisGroupStaticControl = "searchHelpLabel";
            
            /// <summary>
            /// Control ID for SearchButton
            /// </summary>
            public const string SearchButton = "searchButton";
            
            /// <summary>
            /// Control ID for FilterByPartOfNameOptionalTextBox
            /// </summary>
            public const string FilterByPartOfNameOptionalTextBox = "nameFilterText";
        }
        #endregion
    }
}
